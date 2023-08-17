using Microsoft.Win32;
using System.Collections.Generic;
using System.ComponentModel;
using static Vanara.PInvoke.ShlwApi;

namespace Vanara.Windows.Shell.Registration;

/// <summary>Manages registry entries related to file types and file associations.</summary>
public class FileTypeAssociation : RegBasedSettings
{
	internal FileTypeAssociation(string ext, RegistryKey key, bool readOnly) : base(key, readOnly)
	{
		Extension = ext;
		var owpi = readOnly ? key.OpenSubKey("OpenWithProgIds", false) : key.CreateSubKey("OpenWithProgIds", RegistryKeyPermissionCheck.ReadWriteSubTree);
		OpenWithProgIds = new RegBasedKeyCollection(owpi!, readOnly);
	}

	/// <summary>Gets or sets the Content Type value to the file type's MIME content type.</summary>
	/// <value>The MIME content type.</value>
	[DefaultValue(null)]
	public string? ContentType
	{
		get => key.GetValue("ContentType")?.ToString();
		set => UpdateValue("ContentType", value);
	}

	/// <summary>Gets or sets the default value of the extension subkey to the ProgID to which it is linked.</summary>
	/// <value>The default ProgID for this extension.</value>
	/// <exception cref="InvalidOperationException">The specified ProgId is not registered with the system.</exception>
	[DefaultValue(null)]
	public string? DefaultProgId
	{
		get => key.GetValue(null)?.ToString();
		set
		{
			if (value is not null && !Registry.ClassesRoot.HasSubKey(value))
				throw new InvalidOperationException("The specified ProgId is not registered with the system.");
			var old = DefaultProgId;
			if (old != null) OpenWithProgIds.Add(old);
			UpdateValue(null, value);
			if (value != null) OpenWithProgIds.Add(value);
		}
	}

	/// <summary>Gets the extension of this file association.</summary>
	/// <value>The extension.</value>
	public string Extension { get; }

	/// <summary>
	/// Gets a list of alternate ProgIDs for this file type. The programs for these ProgIDs appear in the Open with menu and are
	/// available as default Windows Store apps for the file type. Whenever an application takes over this file type by changing the
	/// default value, it should also add an entry to this list.
	/// </summary>
	/// <value>The open with prog ids.</value>
	public ICollection<string> OpenWithProgIds { get; }

	/// <summary>
	/// Gets or sets the PerceivedType to which the file belongs, if any. This value is not used by Windows versions prior to Windows
	/// Vista. For more information, see "Perceived Types and Application Registration".
	/// </summary>
	[DefaultValue(null)]
	public PERCEIVED? PerceivedType
	{
		get
		{
			var value = key.GetValue("PerceivedType")?.ToString();
			return value is null ? null : (PERCEIVED)Enum.Parse(typeof(PERCEIVED), "PERCEIVED_TYPE_" + value.ToUpper());
		}
		set => UpdateValue("PerceivedType", value?.ToString().Substring(15).ToLower());
	}

	//public string LongExtension;
	// .ext => ProgId => shellnew ??

	/// <summary>Opens the specified extension for reading or editing.</summary>
	/// <param name="extension">The file extension to examine. This value must be in the format ".ext".</param>
	/// <param name="systemWide">
	/// If <see langword="true"/>, examine the file association system-wide. If <see langword="false"/>, examine the file association
	/// for the current user only.
	/// </param>
	/// <param name="readOnly">
	/// If <see langword="true"/>, provides read-only access to the registration; If <see langword="false"/>, the properties can be set
	/// to update the registration values.
	/// </param>
	/// <returns>The requested <see cref="FileTypeAssociation"/> instance.</returns>
	public static FileTypeAssociation Open(string extension, bool systemWide = false, bool readOnly = true)
	{
		RegistryKey key = ShellRegistrar.GetRoot(systemWide, !readOnly, extension ?? throw new ArgumentNullException(nameof(extension))) ??
			Registry.ClassesRoot.OpenSubKey(extension, !readOnly) ?? throw new ArgumentException("Unable to load specified extension", nameof(extension));
		return new FileTypeAssociation(extension, key, readOnly);
	}

	/// <summary>Registers the specified files extension.</summary>
	/// <param name="extension">The file extension to register. This value must be in the format ".ext".</param>
	/// <param name="systemWide">
	/// If <see langword="true"/>, register the file association system-wide. If <see langword="false"/>, register the file association
	/// for the current user only.
	/// </param>
	/// <returns>A <see cref="FileTypeAssociation"/> instance to continue definition of file extension settings.</returns>
	public static FileTypeAssociation Register(string extension, bool systemWide = false)
	{
		if (extension is null) throw new ArgumentNullException(nameof(extension));
		if (!extension.StartsWith(".")) throw new ArgumentException("The value must be in the format \".ext\"", nameof(extension));
		var root = ShellRegistrar.GetRoot(systemWide, true, extension)!;
		return new FileTypeAssociation(extension, root, false);
	}

	/// <summary>
	/// <para>Unregisters the file association.</para>
	/// <note type="warning">Removing a file association can break multiple applications since this will remove all ProgId associations.
	/// Do this with extreme caution and forethought. Consider just removing the ProgId for your application using <see cref="OpenWithProgIds"/>.</note>
	/// </summary>
	/// <param name="extension">The file extension to unregister. This value must be in the format ".ext".</param>
	/// <param name="systemWide">
	/// If <span class="keyword"><span class="languageSpecificText"><span class="cs">true</span><span class="vb">True</span><span
	/// class="cpp">true</span></span></span><span class="nu"><span class="keyword">true</span> ( <span class="keyword">True</span> in
	/// Visual Basic)</span>, unregister the file association system-wide. If <span class="keyword"><span
	/// class="languageSpecificText"><span class="cs">false</span><span class="vb">False</span><span
	/// class="cpp">false</span></span></span><span class="nu"><span class="keyword">false</span> ( <span class="keyword">False</span>
	/// in Visual Basic)</span>, unregister the file association for the current user only.
	/// </param>
	/// <exception cref="InvalidOperationException">Unable to find association key in the registry.</exception>
	public static void Unregister(string extension, bool systemWide = false)
	{
		if (extension is null) throw new ArgumentNullException(nameof(extension));
		if (!extension.StartsWith(".")) throw new ArgumentException("The value must be in the format \".ext\"", nameof(extension));
		using (var sk = ShellRegistrar.GetRoot(systemWide, true)!)
			try { sk.DeleteSubKeyTree(extension); } catch { sk.DeleteSubKey(extension, false); }
		ShellRegistrar.NotifyShell();
	}

	/// <inheritdoc/>
	public override void Dispose()
	{
		base.Dispose();
		ShellRegistrar.NotifyShell();
	}
}