using Microsoft.Win32;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace Vanara.Windows.Shell.Registration;

/// <summary>Represents the registration entries for an application.</summary>
/// <example>
/// <code title="Register application with associated extensions.">
///using (var appReg = AppRegistration.Register(Application.ExecutablePath, systemWide))
///{
///   appReg.SupportedTypes.Add(".doc");
///   appReg.SupportedTypes.Add(".txt");
///}
/// </code>
/// </example>
/// <seealso cref="RegBasedSettings"/>
public class AppRegistration : RegBasedSettings
{
	internal const string appPathsSubKey = @"Software\Microsoft\Windows\CurrentVersion\App Paths";
	internal const string appsSubKey = "Applications";

	// This is the subkey at [HKCU|HKLM]\Software\Microsoft\Windows\CurrentVersion\App Paths\{appname}.exe
	private readonly PathSubKey? pathKey;

	internal AppRegistration(RegistryKey appKey, RegistryKey? pathKey, bool readOnly) : base(appKey, readOnly)
	{
		this.pathKey = pathKey is null ? null : new PathSubKey(pathKey, readOnly);
		SupportedTypes = new RegBasedKeyCollection(appKey.OpenSubKey("SupportedTypes", !readOnly)!, readOnly);
		Verbs = new CommandVerbDictionary(this, ReadOnly);
	}

	/// <summary>
	/// Gets or sets a value indicating that your application can accept a URL (instead of a file name) on the command line.
	/// Applications that can open documents directly from the internet, like web browsers and media players, should set this entry.
	/// <para>
	/// When the ShellExecuteEx function starts an application and UseUrl is false, ShellExecuteEx downloads the document to a local
	/// file and invokes the handler on the local copy.
	/// </para>
	/// <para>
	/// For example, if the application has this entry set and a user right-clicks on a file stored on a web server, the Open verb will
	/// be made available.If not, the user will have to download the file and open the local copy.
	/// </para>
	/// <para>
	/// In Windows Vista and earlier, this entry indicated that the URL should be passed to the application along with a local file
	/// name, when called via ShellExecuteEx. In Windows 7, it indicates that the application can understand any http or https url that
	/// is passed to it, without having to supply the cache file name as well.
	/// </para>
	/// </summary>
	/// <value><see langword="true"/> if the application accepts a URL on the command-line; otherwise, <see langword="false"/>.</value>
	[DefaultValue(false)]
	public bool AcceptsUrls
	{
		get => (uint)(pathKey?.key.GetValue("UseUrl", 0) ?? 0) != 0;
		set => PathKey.UpdateValue("UseUrl", value ? 1U : 0U, RegistryValueKind.DWord);
	}

	/// <summary>
	/// Gets or sets a value that enables an application to provide a specific icon to represent the application instead of the first
	/// icon stored in the .exe file.
	/// </summary>
	/// <value>The default icon.</value>
	[DefaultValue(null)]
	public IconLocation? DefaultIcon
	{
		get => IconLocation.TryParse(key.GetSubKeyDefaultValue("DefaultIcon")?.ToString() ?? "", out var loc) ? loc : null;
		set => UpdateKeyValue("DefaultIcon", value?.ToString());
	}

	/// <summary>
	/// Gets or sets a value indicating whether debugger applications should avoid file dialog deadlocks when debugging the Windows
	/// Explorer process. Setting DontUseDesktopChangeRouter to <see langword="true"/> produces a slightly less efficient handling of
	/// the change notifications, however.
	/// </summary>
	/// <value><see langword="true"/> if [dont use desktop change router]; otherwise, <see langword="false"/>.</value>
	[DefaultValue(false)]
	public bool DontUseDesktopChangeRouter
	{
		get => (uint)(pathKey?.key.GetValue("DontUseDesktopChangeRouter", 0U) ?? 0U) != 0U;
		set => PathKey.UpdateValue("DontUseDesktopChangeRouter", value ? 1U : 0U, RegistryValueKind.DWord);
	}

	/// <summary>
	/// Gets or sets the CLSID of an object (usually a local server rather than an in-process server) that implements IDropTarget. By
	/// default, when the drop target is an executable file, and no DropTarget value is provided, the Shell converts the list of dropped
	/// files into a command-line parameter and passes it to ShellExecuteEx through lpParameters.
	/// </summary>
	/// <value>The drop target's CLSID.</value>
	[DefaultValue(null)]
	public Guid? DropTarget
	{
		get => pathKey?.key.GetGuidValue("DropTarget");
		set => PathKey.UpdateValue("DropTarget", value.HasValue ? value.Value.ToString("B") : null);
	}

	/// <summary>
	/// Gets or sets the localizable name to display for an application instead of just the version information appearing, which may not
	/// be localizable. The association query ASSOCSTR reads this registry entry value and falls back to use the FileDescription name in
	/// the version information. If that name is missing, the association query defaults to the display name of the file. Applications
	/// should use ASSOCSTR_FRIENDLYAPPNAME to retrieve this information to obtain the proper behavior.
	/// </summary>
	/// <value>The friendly name of the application.</value>
	[DefaultValue(null)]
	public IndirectString? FriendlyAppName
	{
		get => IndirectString.TryParse(key.GetValue("FriendlyAppName")?.ToString(), out var loc) ? loc : null;
		set => UpdateValue("FriendlyAppName", value?.ToString());
	}

	/// <summary>
	/// Gets or sets the fully qualified path to the application. The application name provided can be stated with or without its .exe
	/// extension. If necessary, the ShellExecuteEx function adds the extension when searching App Paths subkey.
	/// </summary>
	/// <value>The full path of the application.</value>
	/// <exception cref="InvalidOperationException">
	/// The executable name cannot be changed once set. Only it's directory can be changed.
	/// </exception>
	public string FullPath
	{
		get => pathKey?.key.GetValue(null)?.ToString() ?? "";
		set
		{
			if (!string.Equals(Path.GetFileName(PathKey.key.Name), Path.GetFileName(value), StringComparison.CurrentCultureIgnoreCase))
				throw new InvalidOperationException("The executable name cannot be changed once set. Only it's directory can be changed.");
			UpdateValue(null, value);
			UpdateValue("Path", Path.GetDirectoryName(value));
		}
	}

	/// <summary>
	/// Gets or sets a value indicating that the process is a host process, such as Rundll32.exe or Dllhost.exe, and should not be
	/// considered for Start menu pinning or inclusion in the Most Frequently Used (MFU) list. When launched with a shortcut that
	/// contains a non-null argument list or an explicit Application User Model IDs (AppUserModelIDs), the process can be pinned (as
	/// that shortcut). Such shortcuts are candidates for inclusion in the MFU list.
	/// </summary>
	/// <value><see langword="true"/> if this process is a host process; otherwise, <see langword="false"/>.</value>
	[DefaultValue(false)]
	public bool IsHostApp
	{
		get => key.HasValue("IsHostApp");
		set => UpdateValue("IsHostApp", value ? string.Empty : null, RegistryValueKind.String);
	}

	/// <summary>
	/// Gets or sets a value that indicates that no application is specified for opening this file type. Be aware that if an
	/// OpenWithProgIDs subkey has been set for an application by file type, and the ProgID subkey itself does not also have a
	/// NoOpenWith entry, that application will appear in the list of recommended or available applications even if it has specified the
	/// NoOpenWith entry. For more information, see How to Include an Application in the Open With Dialog Box and How to exclude an
	/// Application from the Open with Dialog Box.
	/// </summary>
	/// <value><see langword="true"/> if no application is specified for opening this file type; otherwise, <see langword="false"/>.</value>
	[DefaultValue(false)]
	public bool NoOpenWith
	{
		get => key.HasValue("NoOpenWith");
		set => UpdateValue("NoOpenWith", value ? string.Empty : null, RegistryValueKind.String);
	}

	/// <summary>
	/// Gets or sets a value indicating that the application executable and shortcuts should be excluded from the Start menu and from
	/// pinning or inclusion in the MFU list. This entry is typically used to exclude system tools, installers and uninstallers, and
	/// readme files.
	/// </summary>
	/// <value>
	/// <see langword="true"/> if this app should be excluded from the Start menu and from pinning or inclusion in the MFU list;
	/// otherwise, <see langword="false"/>.
	/// </value>
	[DefaultValue(false)]
	public bool NoStartPage
	{
		get => key.HasValue("NoStartPage");
		set => UpdateValue("NoStartPage", value ? string.Empty : null, RegistryValueKind.String);
	}

	/// <summary>
	/// Gets or sets a string that contains the URL protocol schemes for a given key. This can contain multiple values to indicate which
	/// schemes are supported. This string follows the format of <c>scheme1:scheme2</c>. If this list is not empty, <c>file:</c> will be
	/// added to the string. This protocol is implicitly supported when SupportedProtocols is defined.
	/// </summary>
	/// <value>The supported protocols.</value>
	[DefaultValue(null)]
	public string? SupportedProtocols
	{
		get => pathKey?.key.GetValue("SupportedProtocols")?.ToString();
		set => PathKey.UpdateValue("SupportedProtocols", value);
	}

	/// <summary>
	/// Gets or sets the file types that the application supports. Doing so enables the application to be listed in the cascade menu of
	/// the Open with dialog box.
	/// </summary>
	/// <value>The supported files types.</value>
	public ICollection<string> SupportedTypes { get; }

	/// <summary>
	/// Gets or sets the icon used to override the taskbar icon. The window icon is normally used for the taskbar. Setting the
	/// TaskbarGroupIcon entry causes the system to use the icon from the .exe for the application instead.
	/// </summary>
	/// <value>The taskbar icon override.</value>
	[DefaultValue(null)]
	public IconLocation? TaskbarGroupIcon
	{
		get => IconLocation.TryParse(key.GetValue("TaskbarGroupIcon", null)?.ToString(), out var loc) ? loc : null;
		set => UpdateValue("TaskbarGroupIcon", value?.ToString());
	}

	/// <summary>
	/// Gets or sets a value that determines if the taskbar should use the default icon of this executable if there is no pinnable
	/// shortcut for this application, and instead of the icon of the window that was first encountered.
	/// </summary>
	/// <value><see langword="true"/> if the taskbar should use the default icon of this executable; otherwise, <see langword="false"/>.</value>
	[DefaultValue(false)]
	public bool UseExecutableForTaskbarGroupIcon
	{
		get => key.HasValue("UseExecutableForTaskbarGroupIcon");
		set => UpdateValue("UseExecutableForTaskbarGroupIcon", value ? string.Empty : null, RegistryValueKind.String);
	}

	/// <summary>
	/// Gets the verbs for calling the application from OpenWith. Without a verb definition specified here, the system assumes that the
	/// application supports CreateProcess, and passes the file name on the command line. This functionality applies to all the verb
	/// methods, including DropTarget, ExecuteCommand, and Dynamic Data Exchange (DDE).
	/// </summary>
	/// <value>The command verbs associated with the app.</value>
	public CommandVerbDictionary Verbs { get; }

	private PathSubKey PathKey => pathKey ?? throw new InvalidOperationException("No App Path is defined.");

	/// <summary>Opens the application registration information for the specified application.</summary>
	/// <param name="appFileName">The file name (no directory) of the application executable for which to get settings.</param>
	/// <param name="readOnly">
	/// If <see langword="true"/>, provides read-only access to the registration; If <see langword="false"/>, the properties can be set
	/// to update the registration values.
	/// </param>
	/// <returns>A <see cref="AppRegistration"/> instance.</returns>
	/// <exception cref="ArgumentNullException">fullApplicationPath</exception>
	/// <exception cref="InvalidOperationException">Unable to create application key in the 'App Paths' subkey.</exception>
	public static AppRegistration Open(string appFileName, bool readOnly)
	{
		if (string.IsNullOrEmpty(appFileName)) throw new ArgumentNullException(nameof(appFileName));
		var fn = appFileName.ToLower();
		var skName = Path.Combine(appPathsSubKey, fn);
		// Handle registrations in user or machine "App Paths"
		bool systemWide = Registry.LocalMachine.HasSubKey(skName) || !Registry.CurrentUser.HasSubKey(skName);
		return Open(fn, systemWide, readOnly);
	}

	/// <summary>Opens the application registration information for the specified application.</summary>
	/// <param name="fullApplicationPath">The full path of the application executable for which to get settings.</param>
	/// <param name="systemWide">
	/// If <see langword="true"/>, register the application system-wide. If <see langword="false"/>, register the application for the
	/// current user only.
	/// </param>
	/// <param name="readOnly">
	/// If <see langword="true"/>, provides read-only access to the registration; If <see langword="false"/>, the properties can be set
	/// to update the registration values.
	/// </param>
	/// <returns>A <see cref="AppRegistration"/> instance.</returns>
	/// <exception cref="ArgumentNullException">fullApplicationPath</exception>
	/// <exception cref="InvalidOperationException">Unable to create application key in the 'App Paths' subkey.</exception>
	public static AppRegistration OpenPath(string fullApplicationPath, bool systemWide, bool readOnly)
	{
		if (string.IsNullOrEmpty(fullApplicationPath)) throw new ArgumentNullException(nameof(fullApplicationPath));
		var fn = Path.GetFileName(fullApplicationPath).ToLower();
		return Open(fn, systemWide, readOnly);
	}

	/// <summary>Registers the application on Windows 7 or later.</summary>
	/// <param name="fullApplicationPath">The full path of the application executable for which to get settings.</param>
	/// <param name="systemWide">
	/// If <see langword="true"/>, register the application system-wide. If <see langword="false"/>, register the application for the
	/// current user only.
	/// </param>
	/// <returns>A <see cref="AppRegistration"/> instance to continue definition of application settings.</returns>
	public static AppRegistration Register(string fullApplicationPath, bool systemWide = false)
	{
		if (string.IsNullOrEmpty(fullApplicationPath)) throw new ArgumentNullException(nameof(fullApplicationPath));
		fullApplicationPath = Path.GetFullPath(fullApplicationPath);
		var fn = Path.GetFileName(fullApplicationPath).ToLower();
		if (fn is null || fn.IndexOf('.') == -1)
			throw new ArgumentException("The application path must include a fully qualified application name and extension.", nameof(fullApplicationPath));

		// Handle registrations in user or machine "App Paths"
		var sk = (systemWide ? Registry.LocalMachine : Registry.CurrentUser).CreateSubKey(Path.Combine(appPathsSubKey, fn)) ?? throw new InvalidOperationException("Unable to create application key in the 'App Paths' subkey.");
		// Build short path and store as default value
		var shortPath = fullApplicationPath;
		var l = fullApplicationPath.Length + 5;
		var sb = new StringBuilder(l, l);
		var rl = PInvoke.Kernel32.GetShortPathName(fullApplicationPath.Length > PInvoke.Kernel32.MAX_PATH ? @"\\?\" + fullApplicationPath : fullApplicationPath, sb, (uint)sb.Capacity);
		if (rl > 0 && rl <= l) shortPath = sb.ToString();
		sk.SetValue(null, shortPath);
		// Add Path value
		var dir = Path.GetDirectoryName(fullApplicationPath);
		if (dir != null)
			sk.SetValue("Path", dir);

		// Handle registrations in HKCR\Applications
		var ska = ShellRegistrar.GetRoot(systemWide, true, Path.Combine(appsSubKey, fn)) ?? throw new InvalidOperationException("Unable to create application key in the HKCR\\Applications subkey.");
		return new AppRegistration(ska, sk, false);
	}

	/// <summary>Unregisters the application on Windows 7 or later.</summary>
	/// <param name="fullApplicationPath">The full path of the application executable to unregister.</param>
	/// <param name="systemWide">
	/// If <see langword="true"/>, unregister the application system-wide. If <see langword="false"/>, unregister the application for
	/// the current user only.
	/// </param>
	public static void Unregister(string fullApplicationPath, bool systemWide = false)
	{
		if (string.IsNullOrEmpty(fullApplicationPath)) throw new ArgumentNullException(nameof(fullApplicationPath));
		var fn = Path.GetFileName(fullApplicationPath).ToLower();
		using (var reg = (systemWide ? Registry.LocalMachine : Registry.CurrentUser).OpenSubKey(appPathsSubKey, true))
			reg?.DeleteSubKeyTree(fn);
		using (var reg = ShellRegistrar.GetRoot(systemWide, true, appsSubKey))
			reg?.DeleteSubKeyTree(fn);

		ShellRegistrar.NotifyShell();
	}

	/// <inheritdoc/>
	public override void Dispose()
	{
		pathKey?.Dispose();
		base.Dispose();
	}

	/// <summary>Opens the application registration information for the specified application.</summary>
	/// <param name="systemWide">
	/// If <see langword="true"/>, register the application system-wide. If <see langword="false"/>, register the application for the
	/// current user only.
	/// </param>
	/// <param name="appFileName">The file name (no directory) of the application executable for which to get settings.</param>
	/// <param name="readOnly">
	/// If <see langword="true"/>, provides read-only access to the registration; If <see langword="false"/>, the properties can be set
	/// to update the registration values.
	/// </param>
	/// <returns>A <see cref="AppRegistration"/> instance.</returns>
	/// <exception cref="ArgumentNullException">fullApplicationPath</exception>
	/// <exception cref="InvalidOperationException">Unable to create application key in the 'App Paths' subkey.</exception>
	internal static AppRegistration Open(string appFileName, bool systemWide, bool readOnly)
	{
		// Handle registrations in user or machine "App Paths"
		var appPath = Path.Combine(appsSubKey, appFileName.ToLower());
		var ska = (readOnly ? Registry.ClassesRoot.OpenSubKey(appPath) : ShellRegistrar.GetRoot(systemWide, true, appPath)) ?? throw new InvalidOperationException("Unable to open application key in the 'Applications' subkey.");
		var sk = (systemWide ? Registry.LocalMachine : Registry.CurrentUser).OpenSubKey(Path.Combine(appPathsSubKey, appFileName), !readOnly);
		return new AppRegistration(ska, sk, readOnly);
	}

	private class PathSubKey(RegistryKey key, bool readOnly) : RegBasedSettings(key, readOnly)
	{
	}
}