using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using Vanara.Windows.Shell.Registration;
using static Vanara.PInvoke.Shell32;

namespace Vanara.Windows.Shell;

/// <summary>Contains static methods used to register and unregister shell items in the Windows Registry.</summary>
public static class ShellRegistrar
{
	/// <summary>Gets a dictionary of registered applications in the current system.</summary>
	/// <value>The dictionary of registered applications.</value>
	public static IReadOnlyDictionary<string, AppRegistration> Applications { get; } = new AppDictionary(true);

	/// <summary>Gets a dictionary of registered file type associations in the current system.</summary>
	/// <value>The dictionary of file type associations.</value>
	public static IReadOnlyDictionary<string, FileTypeAssociation> FileTypeAssociations { get; } = new FileTypeDictionary(true);

	/// <summary>Gets a dictionary of registered ProgId's in the current system.</summary>
	/// <value>The dictionary of ProgId values.</value>
	public static IReadOnlyDictionary<string, ProgId> ProgIds { get; } = new ProgIdDictionary(true);

	/// <summary>Gets a dictionary of registered shell associations in the current system.</summary>
	/// <value>The dictionary of shell associations.</value>
	public static IReadOnlyDictionary<string, ShellAssociation> ShellAssociations { get; } = new ShellAssociationDictionary(true);

	/// <summary>Gets the CLSID for the specified type.</summary>
	/// <param name="type">The type.</param>
	/// <returns>The CLSID value for the type. Calls <see cref="Type.GUID"/> to get the value.</returns>
	public static Guid CLSID(this Type type) => type.GUID;

	/// <summary>Determines if the specified type is registered as a COM Local Server.</summary>
	/// <typeparam name="TComObject">The type of the COM object.</typeparam>
	/// <param name="assembly">
	/// The assembly used to get the full path of the executable. If this value is <see langword="null"/>, then the assembly of
	/// <typeparamref name="TComObject"/> will be used.
	/// </param>
	/// <param name="systemWide">
	/// If set to <see langword="true"/>, registration is checked in HKLM; otherwise it is registered for the user only in HKCU.
	/// </param>
	/// <param name="appId">The AppId to relate to this CLSID. If <see langword="null"/>, the CLSID value will be used.</param>
	public static bool IsRegisteredAsLocalServer<TComObject>(Assembly assembly = null, bool systemWide = false, Guid? appId = null) where TComObject : ComObject
	{
		var cmdLine = (assembly ?? typeof(TComObject).Assembly).Location;
		var clsid = GetClsid<TComObject>();
		var _appId = appId ?? clsid;

		using (var root = GetRoot(systemWide, true))
		{
			if (!root.HasSubKey(@"CLSID\" + clsid.ToRegString())) return false;
			using (var rClsid = root.OpenSubKey(@"CLSID\" + clsid.ToRegString() + @"\LocalServer32"))
				if (rClsid == null || !string.Equals(rClsid.GetValue("")?.ToString(), cmdLine, StringComparison.OrdinalIgnoreCase)) return false;
			if (!root.HasSubKey(@"AppID\" + _appId.ToRegString())) return false;
		}
		return true;
	}

#if NETFRAMEWORK

	/// <summary>Registers the specified type as a COM Local Server.</summary>
	/// <typeparam name="TComObject">The type of the COM object.</typeparam>
	/// <param name="pszFriendlyName">The friendly name of the COM object.</param>
	/// <param name="cmdLineArgs">The command line arguments to supply to the executable on startup.</param>
	/// <param name="assembly">
	/// The assembly used to get the full path of the executable. If this value is <see langword="null"/>, then the assembly of
	/// <typeparamref name="TComObject"/> will be used.
	/// </param>
	/// <param name="systemWide">
	/// If set to <see langword="true"/>, the COM object is registered system-wide in HKLM; otherwise it is registered for the user only
	/// in HKCU.
	/// </param>
	/// <param name="appId">The AppId to relate to this CLSID. If <see langword="null"/>, the CLSID value will be used.</param>
	public static void RegisterLocalServer<TComObject>(string pszFriendlyName, string cmdLineArgs = null, Assembly assembly = null, bool systemWide = false, Guid? appId = null) where TComObject : ComObject
	{
		if (assembly == null) assembly = typeof(TComObject).Assembly;
		var cmdLine = assembly.Location;
		var qCmdLine = string.Concat("\"", cmdLine, "\"");
		var typelib = Marshal.GetTypeLibGuidForAssembly(assembly);
		var clsid = GetClsid<TComObject>();
		var _appId = appId ?? clsid;
		if (!(cmdLineArgs is null)) qCmdLine += " " + cmdLineArgs;

		using (var root = GetRoot(systemWide, true))
		using (root.CreateSubKey(@"AppID\" + _appId.ToRegString(), pszFriendlyName))
		using (var rClsid = root.CreateSubKey(@"CLSID\" + clsid.ToRegString(), pszFriendlyName))
		using (rClsid.CreateSubKey("TypeLib", typelib.ToRegString()))
		using (var rLS32 = rClsid.CreateSubKey("LocalServer32", cmdLineArgs is null ? qCmdLine : string.Concat("\"", qCmdLine, "\"")))
		{
			rClsid.SetValue("AppId", _appId.ToRegString());
			rLS32.SetValue("ServerExecutable", cmdLine);
		}
	}

#endif

	/// <summary>Unregisters the COM Local Server.</summary>
	/// <typeparam name="TComObject">The type of the COM object.</typeparam>
	/// <param name="systemWide">
	/// If set to <see langword="true"/>, the COM object is unregistered system-wide from HKLM; otherwise it is unregistered for the
	/// user only in HKCU.
	/// </param>
	/// <param name="appId">The AppId to relate to this CLSID. If <see langword="null"/>, the CLSID value will be used.</param>
	public static void UnregisterLocalServer<TComObject>(bool systemWide = false, Guid? appId = null) where TComObject : ComObject
	{
		var clsid = GetClsid<TComObject>();
		using (var root = GetRoot(systemWide, true))
		{
			root.DeleteSubKeyTree(@"AppID\" + (appId ?? clsid).ToRegString());
			root.DeleteSubKeyTree(@"CLSID\" + clsid.ToRegString());
		}
	}

	internal static RegistryKey GetRoot(bool systemWide = true, bool writable = false, string subkey = null)
	{
		if (!writable && subkey is null)
			return Registry.ClassesRoot;
		var key = systemWide ? Registry.LocalMachine : Registry.CurrentUser;
		var fullsubkey = @"Software\Classes" + (subkey is null ? "" : "\\" + subkey);
		return writable ? key.CreateSubKey(fullsubkey) : key.OpenSubKey(fullsubkey, writable);
	}

	internal static void NotifyShell() => SHChangeNotify(SHCNE.SHCNE_ASSOCCHANGED, SHCNF.SHCNF_FLUSHNOWAIT | SHCNF.SHCNF_IDLIST);

	private static Guid GetClsid<TComObject>() => typeof(TComObject).CLSID();
}