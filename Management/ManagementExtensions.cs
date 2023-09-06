using System.ComponentModel;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace Vanara.Management;

/// <summary>Extension methods to work more easily with <see cref="System.Management"/>.</summary>
public static class ManagementExtensions
{
	internal enum JobState : ushort
	{
		New = 2,
		Starting = 3,
		Running = 4,
		Suspended = 5,
		ShuttingDown = 6,
		Completed = 7,
		Terminated = 8,
		Killed = 9,
		Exception = 10,
		Service = 11,
		QueryPending = 12,
		CompletedWithWarnings = 32768
	}

	/// <summary>Calls a service method that returns a Job asynchronously.</summary>
	/// <param name="scope">The scope.</param>
	/// <param name="cancellationToken">The cancellation token.</param>
	/// <param name="progress">The progress.</param>
	/// <param name="service">The service.</param>
	/// <param name="method">The method.</param>
	/// <param name="values">The values.</param>
	/// <returns>The resulting <see cref="ManagementBaseObject"/>.</returns>
	public static async Task<ManagementBaseObject> CallJobMethodAsync(this ManagementScope scope, CancellationToken cancellationToken, IProgress<int>? progress, string service, string method, params (string, object)[] values) =>
		await Task.Factory.StartNew(() =>
		{
			if (!scope.IsConnected)
				scope.Connect();

			using ManagementObject imgMgmtSvc = scope.GetWMIService(service) ?? throw new ArgumentException("Unable to find service.", nameof(service));
			using ManagementBaseObject inParams = imgMgmtSvc.GetMethodParameters(method);
			foreach ((string, object) kv in values)
				inParams[kv.Item1] = kv.Item2;

			ManagementBaseObject outputParameters = imgMgmtSvc.InvokeMethod(method, inParams, new());

			const int sleepDur = 500;

			if (outputParameters.IsAsync())
			{
				// The method invoked an asynchronous operation. Get the Job object and wait for it to complete. Then we can check its result.
				using ManagementObject job = new((string)outputParameters["Job"]) { Scope = scope };

				while (!job.GetProp<JobState>("JobState").IsJobComplete())
				{
					if (progress is not null)
					{
						try { progress.Report(job.GetProp<ushort>("PercentComplete")); }
						catch { }
					}

					Task.Delay(sleepDur);

					// ManagementObjects are offline objects. Call Get() on the object to have its current property state.
					job.Get();
				}

				switch (job.GetProp<JobState>("JobState"))
				{
					case JobState.Terminated:
					case JobState.Killed:
						throw new ThreadInterruptedException();
					case JobState.Exception:
						ManagementBaseObject errOut = job.InvokeMethod("GetError", null!, new());
						var xml = new XmlDocument();
						xml.LoadXml(errOut.GetProp<string>("Error"));
						if (xml.DocumentElement is null) throw new InvalidOperationException("Error XML is invalid.");
						var errMsg = xml.DocumentElement.SelectSingleNode(@"//PROPERTY[@NAME='Message']/VALUE")?.InnerText;
						var ex = new InvalidOperationException(errMsg);
#if DEBUG
						foreach (var p in job.Properties.Cast<PropertyData>())
							ex.Data.Add(p.Name, p.Value);
#endif
						throw ex;
					case JobState.Completed:
					case JobState.CompletedWithWarnings:
						outputParameters.SetPropertyValue("ReturnValue", 0);
						break;

					default:
						break;
				}
			}
			progress?.Report(100);
			return outputParameters;
		}, cancellationToken);

	/// <summary>Gets the embedded instance string usable by WMI</summary>
	/// <typeparam name="T">The type of the instance.</typeparam>
	/// <param name="instance">The instance.</param>
	/// <param name="serverName">Name of the server.</param>
	/// <returns>Embedded instance string usable by WMI.</returns>
	/// <exception cref="System.InvalidOperationException">Generic type does not have a DataContract attribute.</exception>
	public static string GetInstanceText<T>(T instance, string serverName = ".")
	{
		DataContractAttribute attr = typeof(T).GetCustomAttributes<DataContractAttribute>(false).FirstOrDefault() ?? throw new InvalidOperationException("Generic type does not have a DataContract attribute.");
		var path = new ManagementPath() { Server = serverName, NamespacePath = attr.Namespace!, ClassName = attr.Name! };

		using var settingsClass = new ManagementClass(path);
		using ManagementObject settingsInstance = settingsClass.CreateInstance();

		foreach (PropertyInfo pi in typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
		{
			if (pi.GetCustomAttributes<IgnoreDataMemberAttribute>().Any() || !pi.CanRead)
				continue;
			DataMemberAttribute mattr = pi.GetCustomAttributes<DataMemberAttribute>(false).FirstOrDefault() ?? new DataMemberAttribute() { Name = pi.Name };
			var val = pi.PropertyType.IsEnum ? Convert.ChangeType(pi.GetValue(instance), pi.PropertyType.GetEnumUnderlyingType()) : pi.GetValue(instance);
			settingsInstance.SetPropertyValue(mattr.Name!, val!);
		}

		return settingsInstance.GetText(TextFormat.WmiDtd20);
	}

	/// <summary>Gets the specified property value of <paramref name="prop"/> from <paramref name="obj"/>.</summary>
	/// <typeparam name="T">The property type</typeparam>
	/// <param name="obj">The object.</param>
	/// <param name="prop">The property name.</param>
	/// <returns>The property value.</returns>
	public static T GetProp<T>(this ManagementBaseObject obj, string prop) => typeof(T).IsEnum ? (T)Enum.ToObject(typeof(T), obj[prop]) : (T)obj[prop];

	/// <summary>Gets the result from a return value or throws the appropriate exception.</summary>
	/// <param name="output">The method output object.</param>
	/// <param name="throwAll">if set to <see langword="true"/> throws all exceptions including those for 4096 and 32768.</param>
	/// <returns><see langword="true"/> on success; otherwise <see langword="false"/>.</returns>
	public static bool GetResultOrThrow(this ManagementBaseObject output, bool throwAll = false) => output.GetProp<uint>("ReturnValue") switch
	{
		0 => true,
		4096 => throwAll ? throw new SynchronizationLockException() : false,
		32768 => throwAll ? throw new Exception() : false,
		32769 => throw new UnauthorizedAccessException(),
		32770 => throw new NotSupportedException(),
		32773 => throw new ArgumentException(),
		32779 => throw new System.IO.FileNotFoundException(),
		32778 => throw new OutOfMemoryException(),
		32772 => throw new TimeoutException(),
		//Status is unknown(32771)
		//System is in use(32774)
		//Invalid state for this operation(32775)
		//Incorrect data type(32776)
		//System is not available(32777)
		_ => throw new Exception(),
	};

	/// <summary>Gets the specifid WMI service from a scope.</summary>
	/// <param name="scope">The scope.</param>
	/// <param name="path">The service path.</param>
	/// <returns>The service object.</returns>
	public static ManagementObject? GetWMIService(this ManagementScope scope, string path)
	{
		using ManagementClass imageManagementServiceClass = new(path) { Scope = scope };
		return imageManagementServiceClass.GetInstances().Cast<ManagementObject>().FirstOrDefault();
	}

	/// <summary>
	/// Parses an embedded instance returned from the server and creates a new instance of <typeparamref name="T"/> with that information.
	/// </summary>
	/// <typeparam name="T">The type to fill with information from <paramref name="embeddedInstance"/>.</typeparam>
	/// <param name="embeddedInstance">The embedded instance.</param>
	/// <returns>An instance of <typeparamref name="T"/> with the data contained in the embedded instance.</returns>
	/// <exception cref="FormatException">If there was a problem parsing the embedded instance.</exception>
	/// <exception cref="ArgumentNullException">If either param is null.</exception>
	public static T Parse<T>(string? embeddedInstance) where T : class, new()
	{
		if (embeddedInstance is null) throw new FormatException();
		var doc = new XmlDocument();
		doc.LoadXml(embeddedInstance);

		XmlNodeList nodelist = doc.SelectNodes(@"/INSTANCE/@CLASSNAME") ?? throw new FormatException();
		var className = typeof(T).GetCustomAttributes<DataContractAttribute>(false).FirstOrDefault()?.Name ?? typeof(T).Name;
		if (nodelist.Count != 1 || nodelist[0]?.Value != className)
		{
			throw new FormatException();
		}

		var output = new T();
		foreach (PropertyInfo pi in typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
		{
			if (pi.GetCustomAttributes<IgnoreDataMemberAttribute>().Any() || !pi.CanWrite)
				continue;
			DataMemberAttribute attr = pi.GetCustomAttributes<DataMemberAttribute>(false).FirstOrDefault() ?? new DataMemberAttribute() { Name = pi.Name };

			if (pi.PropertyType.IsArray)
			{
				if (doc.SelectSingleNode($@"//PROPERTY.ARRAY[@NAME = '{attr.Name}']") is not null)
				{
					var array = doc.SelectNodes($@"//PROPERTY.ARRAY[@NAME = '{attr.Name}']/VALUE.ARRAY/VALUE")?.Cast<XmlNode>().Select(n => n.InnerText).ToArray() ?? new string[0];
					var ret = Array.CreateInstance(pi.PropertyType.GetElementType()!, array.Length);
					for (int i = 0; i < array.Length; i++)
						ret.SetValue(GetVal(pi.PropertyType.GetElementType()!, array[i]), i);
					pi.SetValue(output, ret);
				}
				else if (attr.IsRequired)
					throw new FormatException();
			}
			else
			{
				nodelist = doc.SelectNodes($@"//PROPERTY[@NAME = '{attr.Name}']/VALUE/child::text()") ?? throw new FormatException();
				if (attr.IsRequired && nodelist.Count != 1)
					throw new FormatException();
				if (nodelist.Count == 0)
					continue;
				pi.SetValue(output, GetVal(pi.PropertyType, nodelist[0]?.Value));
			}
		}
		return output;

		static object? GetVal(Type type, string? value)
		{
			if (value is null)
				return null;
			if (type == typeof(string))
				return value;
			if (type.IsEnum)
			{
				TypeConverter cv = TypeDescriptor.GetConverter(type.GetEnumUnderlyingType());
				var val = (value is not null ? cv.ConvertFromInvariantString(value) : null) ?? throw new FormatException();
				if (!Enum.IsDefined(type, val))
					throw new FormatException();
				return Enum.ToObject(type, val);
			}
			else
			{
				TypeConverter cv = TypeDescriptor.GetConverter(type);
				return cv.ConvertFromInvariantString(value);
			}
		}
	}

	/// <summary>Converts a string in CIM_DATETIME format to a <see cref="DateTime"/>.</summary>
	/// <param name="cimdate">The CIM_DATETIME string in 'yyyymmddHHMMSS.mmmmmmsUUU' format.</param>
	/// <returns>A <see cref="DateTime"/> value in GMT equivalent to <paramref name="cimdate"/> or <see langword="null"/> if unable to process.</returns>
	public static DateTime? CimToDateTime(string? cimdate)
	{
		if (cimdate is null || !(cimdate.Length is 14 or 21 or 25))
			return null;
		var dts = cimdate;
		if (dts.Length == 14)
			dts += ".000000";
		if (dts.Length == 21)
			dts += "+000";
		if (!short.TryParse(dts.Substring(21, 4), out var utcOffset))
			return null;
		dts = $"{dts.Substring(0, 21)}{(utcOffset < 0 ? '-' : '+')}{Math.Abs(utcOffset) / 60:D2}:{Math.Abs(utcOffset) % 60:D2}";
		if (!DateTime.TryParseExact(dts, "yyyyMMddHHmmss.FFFFFFFzzz", null, System.Globalization.DateTimeStyles.None, out var dt))
			return null;
		return dt;
	}

	/// <summary>Converts a <see cref="DateTime"/> value to CIM_DATETIME format.</summary>
	/// <param name="dt">The <see cref="DateTime"/> value.</param>
	/// <returns>A CIM_DATETIME string in 'yyyymmddHHMMSS.mmmmmmsUUU' format.</returns>
	public static string DateTimeToCim(this DateTime dt) => $"{dt.ToUniversalTime():yyyyMMddHHmmss.FFFFFFF}+000";

	/// <summary>Verifies whether a job is completed.</summary>
	/// <param name="jobStateObj">An object that represents the JobState of the job.</param>
	/// <returns>True if the job is completed, False otherwise.</returns>
	internal static bool IsJobComplete(this JobState jobStateObj) =>
		jobStateObj is JobState.Completed or JobState.CompletedWithWarnings or JobState.Terminated or JobState.Exception or JobState.Killed;

	/// <summary>Verifies whether a job succeeded.</summary>
	/// <param name="jobStateObj">An object representing the JobState of the job.</param>
	/// <returns><c>true</c> if the job succeeded; otherwise, <c>false</c>.</returns>
	internal static bool IsJobSuccessful(this JobState jobStateObj) => jobStateObj is JobState.Completed or JobState.CompletedWithWarnings;

	private static bool IsAsync(this ManagementBaseObject output) => output.GetProp<uint>("ReturnValue") == 4096;
}