using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Dynamic;
using System.Linq;
using System.Management;

namespace Vanara.Management;

/// <summary>A dynamic object to handle WMI <see cref="ManagementBaseObject"/> references.</summary>
/// <seealso cref="System.Dynamic.DynamicObject"/>
/// <seealso cref="System.IDisposable"/>
public class DynamicMgmtObject : DynamicObject, IDisposable
{
	private readonly ManagementObject obj;

	/// <summary>Initializes a new instance of the <see cref="DynamicMgmtObject"/> class.</summary>
	/// <param name="obj">The object.</param>
	public DynamicMgmtObject(ManagementObject obj) => this.obj = obj ?? throw new ArgumentNullException(nameof(obj));

	/// <summary>Initializes a new instance of the <see cref="DynamicMgmtObject"/> class.</summary>
	/// <param name="scope">The scope.</param>
	/// <param name="service">The service name.</param>
	public DynamicMgmtObject(ManagementScope scope, string service)
	{
		if (!scope.IsConnected)
			scope.Connect();

		obj = scope.GetWMIService(service) ?? throw new ArgumentException("Unable to get WMI service", nameof(service));
	}

	/// <summary>Initializes a new instance of the <see cref="DynamicMgmtObject"/> class.</summary>
	/// <param name="wmiclass">The class.</param>
	public DynamicMgmtObject(ManagementClass wmiclass) => obj = wmiclass.CreateInstance();

	/// <summary>Performs an implicit conversion from <see cref="ManagementObject"/> to <see cref="DynamicMgmtObject"/>.</summary>
	/// <param name="mbo">The <see cref="ManagementObject"/>.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator DynamicMgmtObject(ManagementObject mbo) => new(mbo);

	/// <inheritdoc/>
	public void Dispose() => ((IDisposable)obj).Dispose();

	/// <inheritdoc/>
	public override IEnumerable<string> GetDynamicMemberNames() => obj.Properties.Cast<PropertyData>().Select(d => d.Name);

	/// <inheritdoc/>
	public override bool TryConvert(ConvertBinder binder, [NotNullWhen(true)] out object? result)
	{
		if (binder.Type == typeof(ManagementObject))
		{
			result = obj;
			return true;
		}
		return base.TryConvert(binder, out result);
	}

	/// <inheritdoc/>
	public override bool TryGetMember(GetMemberBinder binder, [NotNullWhen(true)] out object? result)
	{
		try { result = obj.GetPropertyValue(binder.Name); return true; }
		catch (ManagementException)
		{
			result = binder.Name switch
			{
				"ClassPath" or "ManagementClassPath" => obj.ClassPath,
				"Path" or "ManagementPath" => obj.Path,
				"Scope" or "ManagementScope" => obj.Scope,
				_ => null
			};
			return result is not null;
		}
	}

	/// <inheritdoc/>
	public override bool TryInvokeMember(InvokeMemberBinder binder, object?[]? args, [NotNullWhen(true)] out object? result)
	{
		if (args?.Length == 1)
		{
			ManagementBaseObject? input = null;
			if (args[0] is ManagementBaseObject mbo)
			{
				input = mbo;
			}
			else if (args[0] is IDictionary<string, object> eo)
			{
				input = obj.GetMethodParameters(binder.Name);
				foreach (KeyValuePair<string, object> kv in eo)
					input[kv.Key] = kv.Value;
			}
			else if (args[0] is (string Key, object Value)[] a)
			{
				input = obj.GetMethodParameters(binder.Name);
				foreach ((string Key, object Value) in a)
					input[Key] = Value;
			}
			if (input is not null)
			{
				result = obj.InvokeMethod(binder.Name, input, new());
				return true;
			}
		}

		try
		{
			result = obj.InvokeMethod(binder.Name, args!);
			return true;
		}
		catch (ManagementException) { }
		return base.TryInvokeMember(binder, args, out result);
	}

	/// <inheritdoc/>
	public override bool TrySetMember(SetMemberBinder binder, object? value)
	{
		try { obj.SetPropertyValue(binder.Name, value!); return true; }
		catch (ManagementException)
		{
			switch (binder.Name)
			{
				case "Path":
				case "ManagementPath":
					obj.Path = value as ManagementPath ?? throw new ArgumentNullException(nameof(value));
					return true;

				case "Scope":
				case "ManagementScope":
					obj.Scope = value as ManagementScope ?? throw new ArgumentNullException(nameof(value));
					return true;

				default:
					return false;
			}
		}
	}
}