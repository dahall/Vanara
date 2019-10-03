using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using static Vanara.PInvoke.Shell32;
using static Vanara.PInvoke.ShlwApi;

namespace Vanara.Windows.Shell
{
	/// <summary>Contains static methods used to register and unregister shell items in the Windows Registry.</summary>
	public static class ShellRegistrar
	{
		/*
			HRESULT RegisterAppDropTarget() const;

			// create registry entries for drop target based static verb. the specified CLSID will be

			HRESULT RegisterCreateProcessVerb(PCWSTR pszProgID, PCWSTR pszVerb, PCWSTR pszCmdLine, PCWSTR pszVerbDisplayName) const;
			HRESULT RegisterDropTargetVerb(PCWSTR pszProgID, PCWSTR pszVerb, PCWSTR pszVerbDisplayName) const;
			HRESULT RegisterExecuteCommandVerb(PCWSTR pszProgID, PCWSTR pszVerb, PCWSTR pszVerbDisplayName) const;
			HRESULT RegisterExplorerCommandVerb(PCWSTR pszProgID, PCWSTR pszVerb, PCWSTR pszVerbDisplayName) const;
			HRESULT RegisterExplorerCommandStateHandler(PCWSTR pszProgID, PCWSTR pszVerb) const;
			HRESULT RegisterVerbAttribute(PCWSTR pszProgID, PCWSTR pszVerb, PCWSTR pszValueName) const;
			HRESULT RegisterVerbAttribute(PCWSTR pszProgID, PCWSTR pszVerb, PCWSTR pszValueName, PCWSTR pszValue) const;
			HRESULT RegisterVerbAttribute(PCWSTR pszProgID, PCWSTR pszVerb, PCWSTR pszValueName, DWORD dwValue) const;
			HRESULT RegisterVerbDefaultAndOrder(PCWSTR pszProgID, PCWSTR pszVerbOrderFirstIsDefault) const;

			HRESULT RegisterPlayerVerbs(PCWSTR const rgpszAssociation[], UINT countAssociation,
										PCWSTR pszVerb, PCWSTR pszTitle) const;

			HRESULT UnRegisterVerb(PCWSTR pszProgID, PCWSTR pszVerb) const;
			HRESULT UnRegisterVerbs(PCWSTR const rgpszAssociation[], UINT countAssociation, PCWSTR pszVerb) const;

			HRESULT RegisterContextMenuHandler(PCWSTR pszProgID, PCWSTR pszDescription) const;
			HRESULT RegisterRightDragContextMenuHandler(PCWSTR pszProgID, PCWSTR pszDescription) const;

			HRESULT RegisterAppShortcutInSendTo() const;

			HRESULT RegisterThumbnailHandler(PCWSTR pszExtension) const;
			HRESULT RegisterPropertyHandler(PCWSTR pszExtension) const;
			HRESULT UnRegisterPropertyHandler(PCWSTR pszExtension) const;

			HRESULT RegisterLinkHandler(PCWSTR pszProgID) const;

			HRESULT RegisterExtensionWithProgID(PCWSTR pszFileExtension, PCWSTR pszProgID) const;
			HRESULT RegisterOpenWith(PCWSTR pszFileExtension, PCWSTR pszProgID) const;
			HRESULT RegisterNewMenuNullFile(PCWSTR pszFileExtension, PCWSTR pszProgID) const;
			HRESULT RegisterNewMenuData(PCWSTR pszFileExtension, PCWSTR pszProgID, PCSTR pszBase64) const;
			HRESULT RegisterKind(PCWSTR pszFileExtension, PCWSTR pszKindValue) const;
			HRESULT UnRegisterKind(PCWSTR pszFileExtension) const;
			HRESULT RegisterPropertyHandlerOverride(PCWSTR pszProperty) const;

			HRESULT RegisterHandlerSupportedProtocols(PCWSTR pszProtocol) const;

			HRESULT RegisterProgIDValue(PCWSTR pszProgID, PCWSTR pszValueName) const;
			HRESULT RegisterProgIDValue(PCWSTR pszProgID, PCWSTR pszValueName, PCWSTR pszValue) const;
			HRESULT RegisterProgIDValue(PCWSTR pszProgID, PCWSTR pszValueName, DWORD dwValue) const;

		*/

		/// <summary>Gets the CLSID for the specified type.</summary>
		/// <param name="type">The type.</param>
		/// <returns>The CLSID value for the type. Calls <see cref="Marshal.GenerateGuidForType"/> to get the value.</returns>
		public static Guid CLSID(this Type type) => Marshal.GenerateGuidForType(type);

		/// <summary>Gets the file extensions associated with a given ProgID.</summary>
		/// <param name="progId">The ProgID.</param>
		/// <returns>An enumeration of file extensions in the form ".ext".</returns>
		public static IEnumerable<string> GetAssociatedFileExtensions(string progId) =>
			GetRoot().GetSubKeyNames().Where(n => n.StartsWith(".") && Registry.ClassesRoot.HasSubKey($"{n}\\{progId}"));

		/// <summary>Determines if the specified type is registered as a COM Local Server.</summary>
		/// <typeparam name="TComObject">The type of the COM object.</typeparam>
		/// <param name="assembly">
		/// The assembly used to get the full path of the executable. If this value is <see langword="null"/>, then the assembly of
		/// <typeparamref name="TComObject"/> will be used.
		/// </param>
		/// <param name="systemWide">
		/// If set to <see langword="true"/>, registration is checked in HKLM; otherwise it is registered for the user only
		/// in HKCU.
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

		/// <summary>Registers the application.</summary>
		/// <param name="fullExePath">The full executable path.</param>
		/// <param name="userOnly">if set to <see langword="true" /> [user only].</param>
		/// <param name="acceptsUrls">if set to <see langword="true" /> [accepts urls].</param>
		/// <param name="dropTarget">The drop target.</param>
		/// <param name="friendlyName">Name of the friendly.</param>
		/// <param name="supportedTypes">The supported types.</param>
		/// <param name="defaultIcon">The default icon.</param>
		/// <param name="noStartPage">if set to <see langword="true" /> [no start page].</param>
		/// <param name="taskGroupIcon">The task group icon.</param>
		/// <param name="useExecutableForTaskbarGroupIcon">if set to <see langword="true" /> [use executable for taskbar group icon].</param>
		/// <exception cref="ArgumentNullException">fullExePath</exception>
		/// <exception cref="InvalidOperationException">
		/// Unable to create application key in the 'App Paths' subkey.
		/// or
		/// Unable to create application key in the HKCR\\Applications subkey.
		/// </exception>
		public static void RegisterApplication(string fullExePath, bool userOnly = false, bool acceptsUrls = false, Guid? dropTarget = null,
			IndirectString friendlyName = null, IEnumerable<string> supportedTypes = null, IconLocation defaultIcon = null, bool noStartPage = false,
			IconLocation taskGroupIcon = null, bool useExecutableForTaskbarGroupIcon = false)
		{
			if (fullExePath == null) throw new ArgumentNullException(nameof(fullExePath));
			fullExePath = Path.GetFullPath(fullExePath);
			var fn = Path.GetFileName(fullExePath).ToLower();

			// Handle registrations in user or machine "App Paths"
			using (var reg = GetRoot(!userOnly, true, @"Software\Microsoft\Windows\CurrentVersion\App Paths"))
			using (var sk = reg?.CreateSubKey(fn))
			{
				if (sk == null) throw new InvalidOperationException("Unable to create application key in the 'App Paths' subkey.");
				// Build short path and store as default value
				var shortPath = fullExePath;
				var l = fullExePath.Length + 5;
				var sb = new StringBuilder(l, l);
				var rl = PInvoke.Kernel32.GetShortPathName(fullExePath.Length > PInvoke.Kernel32.MAX_PATH ? @"\\?\" + fullExePath : fullExePath, sb, (uint)sb.Capacity);
				if (rl > 0 && rl <= l) shortPath = sb.ToString();
				sk.SetValue(null, shortPath);
				// Add Path value
				sk.SetValue("Path", Path.GetDirectoryName(fullExePath));
				// Add UseUrl value if needed
				if (acceptsUrls)
					sk.SetValue("UseUrl", 1U, RegistryValueKind.DWord);
				// Add DropTarget GUID if needed
				if (dropTarget != null)
					sk.SetValue("DropTarget", dropTarget.Value.ToString());
			}

			// Handle registrations in HKCR\Applications
			using (var reg = GetRoot(!userOnly, true, @"Applications"))
			using (var sk = reg?.CreateSubKey(fn))
			{
				if (sk == null) throw new InvalidOperationException("Unable to create application key in the HKCR\\Applications subkey.");
				if (friendlyName != null)
					sk.SetValue("FriendlyAppName", friendlyName.ToString());
				if (supportedTypes != null)
					using (var stk = sk.CreateSubKey("SupportedTypes"))
						foreach (var s in supportedTypes)
							stk?.SetValue(s, string.Empty, RegistryValueKind.String);
				if (defaultIcon != null)
					sk.CreateSubKey("DefaultIcon", defaultIcon.ToString());
				if (noStartPage)
					sk.SetValue("NoStartPage", string.Empty, RegistryValueKind.String);
				if (taskGroupIcon != null)
					sk.SetValue("TaskbarGroupIcon", taskGroupIcon.ToString());
				if (useExecutableForTaskbarGroupIcon)
					sk.SetValue("UseExecutableForTaskbarGroupIcon", string.Empty, RegistryValueKind.String);
			}

			NotifyShell();
		}

		/// <summary>Registers the command verb.</summary>
		/// <param name="parentKey">The parent key.</param>
		/// <param name="verb">The verb.</param>
		/// <param name="displayName">The display name.</param>
		/// <param name="command">The command.</param>
		/// <returns></returns>
		/// <exception cref="InvalidOperationException">Unable to create required key in registry.</exception>
		public static CommandVerb RegisterCommandVerb(RegistryKey parentKey, string verb, string displayName = null, string command = null)
		{
			var vkey = parentKey.CreateSubKey("shell\\" + verb) ?? throw new InvalidOperationException("Unable to create required key in registry.");
			var v = new CommandVerb(vkey, verb, false);
			if (!(displayName is null)) v.DisplayName = displayName;
			if (!(command is null)) v.Command = command;
			NotifyShell();
			return v;
		}

		/// <summary>Registers the file association.</summary>
		/// <param name="ext">The ext.</param>
		/// <param name="progId">The ProgID.</param>
		/// <param name="perceivedType">Type of the perceived.</param>
		/// <param name="contentType">Type of the content.</param>
		/// <param name="systemWide">if set to <c>true</c> register system wide.</param>
		/// <exception cref="ArgumentNullException">ext or progId</exception>
		/// <exception cref="ArgumentException">Extension must start with a '.' - ext or Undefined ProgId value. - progId</exception>
		/// <exception cref="InvalidOperationException">Unable to create association key in the registry.</exception>
		public static void RegisterFileAssociation(string ext, string progId, PERCEIVED perceivedType = PERCEIVED.PERCEIVED_TYPE_UNSPECIFIED, string contentType = null, bool systemWide = false)
		{
			if (ext == null) throw new ArgumentNullException(nameof(ext));
			if (!ext.StartsWith(".")) throw new ArgumentException("Extension must start with a '.'", nameof(ext));
			if (progId == null) throw new ArgumentNullException(nameof(progId));
			if (!IsDefined(progId)) throw new ArgumentException("Undefined ProgId value.", nameof(progId));
			using (var pkey = GetRoot(systemWide, true).CreateSubKey(ext))
			{
				if (pkey == null) throw new InvalidOperationException("Unable to create association key in the registry.");
				pkey.SetValue(null, progId);
				if (perceivedType > 0)
					pkey.SetValue("PerceivedType", perceivedType.ToString().Substring(15).ToLower());
				if (!string.IsNullOrEmpty(contentType))
					pkey.SetValue("Content Type", contentType);
			}
			NotifyShell();
		}

#if !NETCOREAPP3_0
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

		/// <summary>
		/// Registers the ProgID.
		/// </summary>
		/// <param name="progId">The ProgID.</param>
		/// <param name="typeName">Name of the type.</param>
		/// <param name="systemWide">if set to <c>true</c> register system wide.</param>
		/// <returns></returns>
		/// <exception cref="ArgumentNullException">progId</exception>
		/// <exception cref="ArgumentException">A ProgID may not have more then 39 characters, must start with a letter, and may only contain letters, numbers and periods.
		/// or
		/// ProgID already exists - progId</exception>
		public static ProgId RegisterProgID(string progId, string typeName, bool systemWide = false)
		{
			if (progId == null) throw new ArgumentNullException(nameof(progId));
			if (progId.Length > 39 || !Regex.IsMatch(progId, @"^[a-zA-Z][\w\.]+$", RegexOptions.Singleline))
				throw new ArgumentException("A ProgID may not have more then 39 characters, must start with a letter, and may only contain letters, numbers and periods.");
			if (GetRoot().HasSubKey(progId)) throw new ArgumentException("ProgID already exists", nameof(progId));
			return new ProgId(progId, GetRoot(systemWide, true).CreateSubKey(progId, typeName), false);
		}

		/// <summary>
		/// Unregisters the file association.
		/// </summary>
		/// <param name="ext">The ext.</param>
		/// <param name="progId">The ProgID.</param>
		/// <param name="throwOnMissing">if set to <see langword="true" /> [throw on missing].</param>
		/// <param name="systemWide">if set to <c>true</c> set system wide.</param>
		/// <exception cref="InvalidOperationException">Unable to find association key in the registry.</exception>
		public static void UnregisterFileAssociation(string ext, string progId, bool throwOnMissing = true, bool systemWide = false)
		{
			using (var sk = GetRoot(systemWide, true, ext))
			{
				if (sk == null)
				{
					if (throwOnMissing)
						throw new InvalidOperationException("Unable to find association key in the registry.");
					return;
				}
				try { sk.DeleteSubKeyTree(progId); } catch { }

				NotifyShell();
			}
		}

		/// <summary>Unregisters the COM Local Server.</summary>
		/// <typeparam name="TComObject">The type of the COM object.</typeparam>
		/// <param name="systemWide">
		/// If set to <see langword="true"/>, the COM object is unregistered system-wide from HKLM; otherwise it is unregistered for the user
		/// only in HKCU.
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

		/// <summary>Unregisters the ProgID.</summary>
		/// <param name="progId">The ProgID.</param>
		/// <param name="fileExtensions">The file extensions.</param>
		/// <param name="systemWide">if set to <c>true</c> unregister system wide.</param>
		public static void UnregisterProgID(string progId, IEnumerable<string> fileExtensions = null, bool systemWide = false)
		{
			try
			{
				GetRoot(systemWide, true).DeleteSubKeyTree(progId);
			}
			catch
			{
				GetRoot(systemWide, true).DeleteSubKey(progId, false);
			}

			if (fileExtensions == null) return;

			foreach (var ext in fileExtensions)
				UnregisterFileAssociation(ext, progId, false, systemWide);

			NotifyShell();
		}

		internal static RegistryKey GetRoot(bool systemWide = true, bool writable = false, string subkey = null)
		{
			if (!writable && subkey is null)
				return Registry.ClassesRoot;
			var key = systemWide ? Registry.LocalMachine : Registry.CurrentUser;
			return key.OpenSubKey(@"Software\Classes" + (subkey is null ? "" : "\\" + subkey), writable);
		}

		internal static void NotifyShell() => SHChangeNotify(SHCNE.SHCNE_ASSOCCHANGED, SHCNF.SHCNF_FLUSHNOWAIT | SHCNF.SHCNF_IDLIST);

		private static Guid GetClsid<TComObject>() => typeof(TComObject).CLSID();

		private static bool IsDefined(string rootValue) => Registry.ClassesRoot.HasSubKey(rootValue);
	}
}