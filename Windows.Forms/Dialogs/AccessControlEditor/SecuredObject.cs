using Microsoft.Win32;
using System.IO;
using System.Reflection;
using System.Security.AccessControl;
using Vanara.Extensions.Reflection;

namespace Vanara.Security.AccessControl;

/* Derivatives of NativeObjectSecurity: (default is Group|Owner|Access)
	Security												Object.GetSecurityControl()						V	Sec	Nm
	===========												===========================						==	===	===
	Pipes.PipeSecurity							Pipes.PipeStream						3.5	N
	EventWaitHandleSecurity									System.Threading.EventWaitHandle				2	N
	FileSystemSecurity										DirectoryInfo, FileInfo				2	Y	Name
	FileSystemSecurity										FileStream							2	N	Name
	MutexSecurity											System.Threading.Mutex							2	N
	ObjectSecurity<T>																						4	N
	RegistrySecurity										System.Win32.RegistryKey						2	Y	Name
	SemaphoreSecurity										System.Threading.Semaphore						2	N
	MemoryMappedFiles.MemoryMappedFileSecurity	MemoryMappedFiles.MemoryMappedFile	4	N
*/

internal class SecuredObject
{
	private static readonly string[] nonContainerTypes = ["FileSecurity", "PipeSecurity", "CryptoKeySecurity", "MemoryMappedFileSecurity", "TaskSecurity"];

	public SecuredObject(CommonObjectSecurity security, string objName, string displayName)
	{
		ObjectSecurity = security;
		ObjectName = objName;
		DisplayName = displayName;
		IsContainer = IsContainerObject(ObjectSecurity);
		MandatoryLabel = new SystemMandatoryLabel(ObjectSecurity);
	}

	/// <summary>Initializes with the specified known object.</summary>
	/// <param name="knownObject">The known object. See Remarks section for acceptable object types.</param>
	/// <remarks>
	/// Known objects can include:
	/// <list type="bullet">
	///   <item><description>Pipes.PipeStream</description></item>
	///   <item><description><see cref="System.Threading.EventWaitHandle"/></description></item>
	///   <item><description><see cref="DirectoryInfo"/></description></item>
	///   <item><description><see cref="FileInfo"/></description></item>
	///   <item><description><see cref="FileStream"/></description></item>
	///   <item><description><see cref="System.Threading.Mutex"/></description></item>
	///   <item><description>System.Win32.RegistryKey</description></item>
	///   <item><description><see cref="System.Threading.Semaphore"/></description></item>
	///   <item><description>MemoryMappedFiles.MemoryMappedFile</description></item>
	///   <item><description><see cref="CommonObjectSecurity"/> or derived class. <c>Note:</c> When using this option, be sure to 
	///   set the <see cref="IsContainer"/>, <see cref="ResourceType"/>, <see cref="ObjectName"/>, and <see cref="TargetServer"/> properties.</description></item>
	///   <item><description>Any object that supports the following methods and properties:
	///     <list type="bullet"><item><description><code>GetAccessControl()</code> or <code>GetAccessControl(AccessControlSections)</code> method</description></item>
	///     <item><description><code>SetAccessControl(CommonObjectSecurity)</code> method</description></item>
	///     <item><description><code>Name</code> or <code>FullName</code> property</description></item>
	///     </list>
	///   </description></item>
	/// </list>
	/// </remarks>
	public SecuredObject(object knownObject)
	{
		const AccessControlSections minACS = AccessControlSections.Access | AccessControlSections.Group | AccessControlSections.Owner;

		// Special handling for files and directories
		if (knownObject is FileSystemInfo fsi)
		{
			IsContainer = knownObject is DirectoryInfo;
			TargetServer = null;
			try
			{
				ObjectSecurity = IsContainer ? new DirectorySecurity(fsi.FullName, AccessControlSections.All) : new FileSecurity(fsi.FullName, AccessControlSections.All);
			}
			catch (PrivilegeNotHeldException)
			{
				ObjectSecurity = IsContainer ? new DirectorySecurity(fsi.FullName, minACS) : new FileSecurity(fsi.FullName, minACS);
			}
			DisplayName = fsi.Name;
			ObjectName = fsi.FullName;
			BaseObject = ObjectSecurity;
			goto FinalInit;
		}
		// Special handling for Tasks
		else if (knownObject.GetType().FullName is "Microsoft.Win32.TaskScheduler.Task" or "Microsoft.Win32.TaskScheduler.TaskFolder")
		{
			IsContainer = knownObject.GetType().Name == "TaskFolder";
			TargetServer = knownObject.GetPropertyValue<object>("TaskService")?.GetPropertyValue<string>("TargetServer");
		}

		// Get the security object using the standard "GetAccessControl" method
		CommonObjectSecurity? objectSecurity = null;
		if (objectSecurity == null)
		{
			try { objectSecurity = knownObject.InvokeMethod<CommonObjectSecurity>("GetAccessControl", AccessControlSections.All); }
			catch (TargetInvocationException)
			{
				try { objectSecurity = knownObject.InvokeMethod<CommonObjectSecurity>("GetAccessControl", minACS); }
				catch { }
			}
			catch { }
		}
		if (objectSecurity == null)
		{
			try { objectSecurity = knownObject.InvokeMethod<CommonObjectSecurity>("GetAccessControl"); }
			catch { }
		}
		ObjectSecurity = objectSecurity ?? throw new ArgumentException("Object must be valid and have a GetAccessControl member."); ;

		// Get the object names
		switch (knownObject.GetType().Name)
		{
			case "RegistryKey":
				ObjectName = knownObject.GetPropertyValue<string>("Name") ?? throw new ArgumentException("Unable to retrieve an object name.", nameof(knownObject));
				DisplayName = Path.GetFileNameWithoutExtension(ObjectName);
				break;

			case "Task":
				DisplayName = knownObject.GetPropertyValue<string>("Name") ?? throw new ArgumentException("Unable to retrieve an object name.", nameof(knownObject));
				ObjectName = knownObject.GetPropertyValue<string>("Path") ?? throw new ArgumentException("Unable to retrieve an object path.", nameof(knownObject));
				break;

			default:
				DisplayName = knownObject.GetPropertyValue<string>("Name") ?? throw new ArgumentException("Unable to retrieve an object name.", nameof(knownObject));
				ObjectName = knownObject.GetPropertyValue<string>("FullName") ?? DisplayName ?? throw new ArgumentException("Unable to retrieve an object name or full name.", nameof(knownObject));
				break;
		}

		// Set the base object
		BaseObject = knownObject;
		IsContainer = IsContainerObject(ObjectSecurity);

FinalInit:
		MandatoryLabel = new SystemMandatoryLabel(ObjectSecurity);
	}

	public enum SystemMandatoryLabelLevel
	{
		None = 0,
		Low = 0x1000,
		Medium = 0x2000,
		High = 0x3000
	}

	[Flags]
	public enum SystemMandatoryLabelPolicy
	{
		None = 0,
		NoWriteUp = 1,
		NoReadUp = 2,
		NoExecuteUp = 4
	}

	public object? BaseObject { get; }

	public string DisplayName { get; set; }

	public bool IsContainer { get; set; }

	public SystemMandatoryLabel MandatoryLabel { get; }

	public string ObjectName { get; set; }

	public CommonObjectSecurity ObjectSecurity { get; }

	public ResourceType ResourceType => GetResourceType(ObjectSecurity);

	public string? TargetServer { get; set; }

	public static object GetAccessMask(CommonObjectSecurity acl, AuthorizationRule rule)
	{
		if (rule.GetType() == acl.AccessRuleType || rule.GetType() == acl.AuditRuleType)
		{
			var accRightType = acl.AccessRightType;
			foreach (var pi in rule.GetType().GetProperties())
				if (pi.PropertyType == accRightType)
					return Enum.ToObject(accRightType, pi.GetValue(rule, null) ?? 0);
		}
		throw new ArgumentException();
	}

	public static object GetKnownObject(ResourceType resType, string objName, string? serverName)
	{
		object? obj = null;
		switch (resType)
		{
			case ResourceType.FileObject:
				if (!string.IsNullOrEmpty(serverName))
					objName = Path.Combine(serverName, objName);
				if (File.Exists(objName))
					obj = new FileInfo(objName);
				else if (Directory.Exists(objName))
					obj = new DirectoryInfo(objName);
				break;

			case ResourceType.RegistryKey:
				obj = GetKeyFromKeyName(objName, serverName);
				break;

			case Windows.Forms.AccessControlEditorDialog.taskResourceType:
				obj = GetTaskObj(objName, serverName);
				break;
		}
		return obj ?? throw new ArgumentException("Unable to create an object from supplied arguments.");
	}

	public static ResourceType GetResourceType(CommonObjectSecurity sec) => sec.GetType().Name switch
	{
		"FileSecurity" or "DirectorySecurity" or "CryptoKeySecurity" => ResourceType.FileObject,
		"PipeSecurity" or "EventWaitHandleSecurity" or "MutexSecurity" or "MemoryMappedFileSecurity" or "SemaphoreSecurity" => ResourceType.KernelObject,
		"RegistrySecurity" => ResourceType.RegistryKey,
		"TaskSecurity" => Windows.Forms.AccessControlEditorDialog.taskResourceType,
		_ => ResourceType.Unknown,
	};

	public static bool IsContainerObject(CommonObjectSecurity sec)
	{
		var secTypeName = sec.GetType().Name;
		return !Array.Exists(nonContainerTypes, s => secTypeName == s);
	}

	public object GetAccessMask(AuthorizationRule rule) => GetAccessMask(ObjectSecurity, rule);

	public void Persist(object? newBase = null)
	{
		var obj = (newBase ?? BaseObject) ?? throw new ArgumentNullException(nameof(newBase), @"Either newBase or BaseObject must not be null.");
		var mi = obj.GetType().GetMethod("SetAccessControl", BindingFlags.Public | BindingFlags.Instance, null, Type.EmptyTypes, null) ?? throw new InvalidOperationException("Either newBase or BaseObject must represent a securable object.");
		mi.Invoke(obj, [ObjectSecurity]);
	}

	private static RegistryKey? GetKeyFromKeyName(string? keyName, string? serverName)
	{
		if (keyName == null)
			return null;

		var index = keyName.IndexOf('\\');
		var str = index != -1 ? keyName.Substring(0, index).ToUpper(System.Globalization.CultureInfo.InvariantCulture) : keyName.ToUpper(System.Globalization.CultureInfo.InvariantCulture);

		RegistryHive hive = str switch
		{
			"HKEY_CURRENT_USER" => RegistryHive.CurrentUser,
			"HKEY_LOCAL_MACHINE" => RegistryHive.LocalMachine,
			"HKEY_CLASSES_ROOT" => RegistryHive.ClassesRoot,
			"HKEY_USERS" => RegistryHive.Users,
			"HKEY_PERFORMANCE_DATA" => RegistryHive.PerformanceData,
			"HKEY_CURRENT_CONFIG" => RegistryHive.CurrentConfig,
			_ => 0,
		};
		if (hive == 0) return null;
		serverName ??= string.Empty;

		using var retVal = RegistryKey.OpenRemoteBaseKey(hive, serverName);

		if (index == -1 || index == keyName.Length)
			return retVal;

		var subKeyName = keyName.Substring(index + 1, keyName.Length - index - 1);
		return retVal.OpenSubKey(subKeyName);
	}

	private static object? GetTaskObj(string objName, string? serverName)
	{
		try
		{
			var tsType = Extensions.ReflectionExtensions.LoadType("Microsoft.Win32.TaskScheduler.TaskService", "Microsoft.Win32.TaskScheduler.dll") ??
						 Extensions.ReflectionExtensions.LoadType("Microsoft.Win32.TaskScheduler.TaskService", "Microsoft.Win32.TaskScheduler-Merged.dll");
			if (tsType != null)
			{
				var ts = Activator.CreateInstance(tsType, serverName, null, null, "", false);
				if (ts != null)
				{
					try
					{
						var r = ts.InvokeMethod<object>("GetFolder", objName);
						if (r != null)
							return r;
					}
					catch { }

					try
					{
						var r = ts.InvokeMethod<object>("GetTask", objName);
						if (r != null)
							return r;
					}
					catch { }

					try
					{
						var r = ts.InvokeMethod<object>("FindTask", objName, true);
						if (r != null)
							return r;
					}
					catch { }
				}
			}
		}
		catch { }
		return null;
	}

	public class SystemMandatoryLabel
	{
		public SystemMandatoryLabel(CommonObjectSecurity sec)
		{
			Policy = SystemMandatoryLabelPolicy.None;
			Level = SystemMandatoryLabelLevel.None;

			try
			{
				var sd = new RawSecurityDescriptor(sec.GetSecurityDescriptorBinaryForm(), 0);
				if (sd.SystemAcl != null)
				{
					foreach (var ace in sd.SystemAcl)
					{
						if ((int)ace.AceType == 0x11)
						{
							var aceBytes = new byte[ace.BinaryLength];
							ace.GetBinaryForm(aceBytes, 0);
							//_policy = new IntegrityPolicy(aceBytes, 4);
							//_level = new IntegrityLevel(aceBytes, 8);
						}
					}
				}
			}
			catch { }
			/*byte[] saclBinaryForm = new byte[sd.SystemAcl.BinaryLength];
			sd.SystemAcl.GetBinaryForm(saclBinaryForm, 0);
			GenericAce ace = null;
			if (null != saclBinaryForm)
			{
				RawAcl aclRaw = new RawAcl(saclBinaryForm, 0);
				if (0 >= aclRaw.Count) throw new ArgumentException("No ACEs in ACL", "saclBinaryForm");
				ace = aclRaw[0];
				if (Win32.SYSTEM_MANDATORY_LABEL_ACE_TYPE != (int)ace.AceType)
					throw new ArgumentException("No Mandatory Integrity Label in ACL", "saclBinaryForm");
				byte[] aceBytes = new byte[ace.BinaryLength];
				ace.GetBinaryForm(aceBytes, 0);
				_policy = new IntegrityPolicy(aceBytes, 4);
				_level = new IntegrityLevel(aceBytes, 8);
				return;
			}
			throw new ArgumentNullException("saclBinaryForm");*/
		}

		public bool IsSet => Policy != SystemMandatoryLabelPolicy.None && Level != SystemMandatoryLabelLevel.None;

		public SystemMandatoryLabelLevel Level { get; }

		public SystemMandatoryLabelPolicy Policy { get; }
	}
}