using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using static Vanara.PInvoke.Shell32;
using static Vanara.PInvoke.ShlwApi;

namespace Vanara.Windows.Shell
{
	/// <summary>Static class that has methods used to register and unregister shell items in the Windows Registry.</summary>
	public static class ShellRegistrar
	{
		/*
			HRESULT RegisterAppDropTarget() const;

			// create registry entries for drop target based static verb. the specified clsid will be

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

		public static IEnumerable<string> GetAssociatedFileExtensions(string progId) =>
			Registry.ClassesRoot.GetSubKeyNames().Where(n => n.StartsWith(".") && Registry.ClassesRoot.HasSubKey($"{n}\\{progId}"));

		public static void RegisterApplication(string fullExePath, bool userOnly = false, bool acceptsUrls = false, Guid? dropTarget = null, IndirectString friendlyName = null,
			IEnumerable<string> supportedTypes = null, IconLocation defaultIcon = null, bool noStartPage = false, IconLocation taskGroupIcon = null,
			bool useExecutableForTaskbarGroupIcon = false)
		{
			if (fullExePath == null) throw new ArgumentNullException(nameof(fullExePath));
			fullExePath = Path.GetFullPath(fullExePath);
			var fn = Path.GetFileName(fullExePath).ToLower();

			// Handle registrations in user or machine "App Paths"
			using (var reg = ComRegistrar.GetRoot(!userOnly, true, @"Software\Microsoft\Windows\CurrentVersion\App Paths"))
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
			using (var reg = Registry.ClassesRoot.OpenSubKey(@"Applications"))
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

		public static CommandVerb RegisterCommandVerb(RegistryKey parentKey, string verb, string displayName = null, string command = null)
		{
			var vkey = parentKey.CreateSubKey("shell\\" + verb) ?? throw new InvalidOperationException("Unable to create required key in registry.");
			var v = new CommandVerb(vkey, verb, false);
			if (!(displayName is null)) v.DisplayName = displayName;
			if (!(command is null)) v.Command = command;
			NotifyShell();
			return v;
		}

		public static void RegisterFileAssociation(string ext, string progId, PERCEIVED perceivedType = PERCEIVED.PERCEIVED_TYPE_UNSPECIFIED, string contentType = null)
		{
			if (ext == null) throw new ArgumentNullException(nameof(ext));
			if (!ext.StartsWith(".")) throw new ArgumentException("Extension must start with a '.'", nameof(ext));
			if (progId == null) throw new ArgumentNullException(nameof(progId));
			if (!IsDefined(progId)) throw new ArgumentException("Undefined ProgId value.", nameof(progId));
			using (var pkey = Registry.ClassesRoot.CreateSubKey(ext))
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

		public static ProgId RegisterProgID(string progId, string typeName)
		{
			if (progId == null) throw new ArgumentNullException(nameof(progId));
			if (progId.Length > 39 || !Regex.IsMatch(progId, @"^[a-zA-Z][\w\.]+$", RegexOptions.Singleline))
				throw new ArgumentException("A ProgID may not have more then 39 characters, must start with a letter, and may only contain letters, numbers and periods.");
			if (Registry.ClassesRoot.HasSubKey(progId)) throw new ArgumentException("ProgID already exists", nameof(progId));
			return new ProgId(progId, Registry.ClassesRoot.CreateSubKey(progId, typeName), false);
		}

		public static void UnregisterFileAssociation(string ext, string progId, bool throwOnMissing = true)
		{
			using (var sk = Registry.ClassesRoot.OpenSubKey(ext, true))
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

		public static void UnregisterProgID(string progId, IEnumerable<string> fileExtensions = null)
		{
			try
			{
				Registry.ClassesRoot.DeleteSubKeyTree(progId);
			}
			catch
			{
				Registry.ClassesRoot.DeleteSubKey(progId, false);
			}

			if (fileExtensions == null) return;

			foreach (var ext in fileExtensions)
				UnregisterFileAssociation(ext, progId, false);

			NotifyShell();
		}

		internal static void NotifyShell() => SHChangeNotify(SHCNE.SHCNE_ASSOCCHANGED, SHCNF.SHCNF_FLUSHNOWAIT | SHCNF.SHCNF_IDLIST);

		private static bool IsDefined(string rootValue) => Registry.ClassesRoot.HasSubKey(rootValue);
	}
}