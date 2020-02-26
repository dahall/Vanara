using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Text;
using static Vanara.PInvoke.ShlwApi;

namespace Vanara.Windows.Shell
{
	/// <summary>Represents a Shell file association defined in the Windows Registry. Wraps <see cref="IQueryAssociations"/>.</summary>
	public class ShellAssociation
	{
		private IQueryAssociations qassoc;

		/// <summary>Initializes a new instance of the <see cref="ShellAssociation"/> class.</summary>
		/// <param name="ext">The file extension. This should be in the ".ext" format.</param>
		private ShellAssociation(string ext) => Extension = ext;

		/// <summary>Gets all the file associations defined for the system.</summary>
		/// <value>Returns a <see cref="IReadOnlyDictionary{TKey, TValue}"/> value.</value>
		public static IReadOnlyDictionary<string, ShellAssociation> FileAssociations { get; } = new ShellAssociationDictionary(true);

		/// <summary>
		/// The icon reference of the app associated with the file type or URI scheme. This is configured by users in their default program settings.
		/// </summary>
		public string AppIconReference => GetString(ASSOCSTR.ASSOCSTR_APPICONREFERENCE);

		/// <summary>
		/// The AppUserModelID of the app associated with the file type or URI scheme. This is configured by users in their default program settings.
		/// </summary>
		public string AppId => GetString(ASSOCSTR.ASSOCSTR_APPID);

		/// <summary>
		/// The publisher of the app associated with the file type or URI scheme. This is configured by users in their default program settings.
		/// </summary>
		public string AppPublisher => GetString(ASSOCSTR.ASSOCSTR_APPPUBLISHER);

		/// <summary>
		/// Introduced in Internet Explorer 6. Returns the path to the icon resources to use by default for this association. Positive
		/// numbers indicate an index into the dll's resource table, while negative numbers indicate a resource ID. An example of the syntax
		/// for the resource is "c:\myfolder\myfile.dll,-1".
		/// </summary>
		public IconLocation DefaultIcon => IconLocation.TryParse(GetString(ASSOCSTR.ASSOCSTR_DEFAULTICON), out var loc) ? loc : null;

		/// <summary>The extension string.</summary>
		public string Extension { get; }

		/// <summary>The friendly name of an executable file.</summary>
		public string FriendlyAppName => GetString(ASSOCSTR.ASSOCSTR_FRIENDLYAPPNAME);

		/// <summary>The friendly name of a document type.</summary>
		public string FriendlyDocName => GetString(ASSOCSTR.ASSOCSTR_FRIENDLYDOCNAME);

		/// <summary>
		/// Corresponds to the InfoTip registry value. Returns an info tip for an item, or list of properties in the form of an
		/// IPropertyDescriptionList from which to create an info tip, such as when hovering the cursor over a file name. The list of
		/// properties can be parsed with PSGetPropertyDescriptionListFromString.
		/// </summary>
		public string InfoTip => GetString(ASSOCSTR.ASSOCSTR_INFOTIP);

		/// <summary>
		/// The ProgID provided by the app associated with the file type or URI scheme. This if configured by users in their default program settings.
		/// </summary>
		public ProgId ProgId => ProgId.Open(GetString(ASSOCSTR.ASSOCSTR_PROGID), true, true, true);

		/// <summary>
		/// Introduced in Internet Explorer 6. For an object that has a Shell extension associated with it, you can use this to retrieve the
		/// CLSID of that Shell extension object by passing a string representation of the IID of the interface you want to retrieve as the
		/// parameter of IQueryAssociations::GetString. For example, if you want to retrieve a handler that implements the IExtractImage
		/// interface, you would specify "{BB2E617C-0920-11d1-9A0B-00C04FC2D6C1}", which is the IID of IExtractImage.
		/// </summary>
		public IndirectString ShellExtension => IndirectString.TryParse(GetString(ASSOCSTR.ASSOCSTR_SHELLEXTENSION), out var s) ? s : null;

		/// <summary>Introduced in Windows 8.</summary>
		public Guid? SupportedUriProtocols { get { try { return new Guid(GetString(ASSOCSTR.ASSOCSTR_SUPPORTED_URI_PROTOCOLS)); } catch { return null; } } }

		/// <summary>Gets the command verbs for this file association.</summary>
		/// <value>Returns a <see cref="IReadOnlyDictionary{TKey, TValue}"/> value.</value>
		public IReadOnlyDictionary<string, CommandVerb> Verbs => throw new NotImplementedException(); // TODO

		#region AllPropLists // TODO: Enhance

		/// <summary>
		/// Introduced in Internet Explorer 6. Describes a general type of MIME file association, such as image and bmp, so that applications
		/// can make general assumptions about a specific file type.
		/// </summary>
		public string ContentType => GetString(ASSOCSTR.ASSOCSTR_CONTENTTYPE);

		/// <summary>
		/// Introduced in Internet Explorer 6. Corresponds to the QuickTip registry value. Same as ASSOCSTR_INFOTIP, except that it always
		/// returns a list of property names in the form of an IPropertyDescriptionList. The difference between this value and
		/// ASSOCSTR_INFOTIP is that this returns properties that are safe for any scenario that causes slow property retrieval, such as
		/// offline or slow networks. Some of the properties returned from ASSOCSTR_INFOTIP might not be appropriate for slow property
		/// retrieval scenarios. The list of properties can be parsed with PSGetPropertyDescriptionListFromString.
		/// </summary>
		public string QuickTip => GetString(ASSOCSTR.ASSOCSTR_QUICKTIP);

		/// <summary>
		/// Introduced in Internet Explorer 6. Corresponds to the TileInfo registry value. Contains a list of properties to be displayed for
		/// a particular file type in a Windows Explorer window that is in tile view. This is the same as ASSOCSTR_INFOTIP, but, like
		/// ASSOCSTR_QUICKTIP, it also returns a list of property names in the form of an IPropertyDescriptionList. The list of properties
		/// can be parsed with PSGetPropertyDescriptionListFromString.
		/// </summary>
		public string TileInfo => GetString(ASSOCSTR.ASSOCSTR_TILEINFO);

		#endregion AllPropLists // TODO: Enhance

		/// <summary>Initializes a new instance of the <see cref="ShellAssociation"/> class based on the supplied executable name.</summary>
		/// <param name="appExeName">The full path of the application executable.</param>
		/// <returns>A <see cref="ShellAssociation"/> instance if <paramref name="appExeName"/> exists; <see langword="null"/> otherwise.</returns>
		public static ShellAssociation CreateFromAppExeName(string appExeName) => CreateAndInit(ASSOCF.ASSOCF_INIT_BYEXENAME, appExeName);

		/// <summary>Initializes a new instance of the <see cref="ShellAssociation"/> class based on the supplied CLSID.</summary>
		/// <param name="classId">The CLSID.</param>
		/// <returns>A <see cref="ShellAssociation"/> instance if <paramref name="classId"/> exists; <see langword="null"/> otherwise.</returns>
		public static ShellAssociation CreateFromCLSID(Guid classId) => CreateAndInit(0, classId.ToString("B"));

		/// <summary>Initializes a new instance of the <see cref="ShellAssociation"/> class based on the supplied programmatic identifier (ProgId).</summary>
		/// <param name="progId">The ProgId.</param>
		/// <returns>A <see cref="ShellAssociation"/> instance if <paramref name="progId"/> exists; <see langword="null"/> otherwise.</returns>
		public static ShellAssociation CreateFromProgId(string progId) => CreateAndInit(0, progId);

		/// <summary>Initializes a new instance of the <see cref="ShellAssociation"/> class based on the supplied file extension.</summary>
		/// <param name="ext">The file extension. This should be in the ".ext" format.</param>
		/// <returns>A <see cref="ShellAssociation"/> instance if <paramref name="ext"/> exists; <see langword="null"/> otherwise.</returns>
		public static ShellAssociation FromFileExtension(string ext)
		{
			if (ext is null) throw new ArgumentNullException(nameof(ext));
			if (!ext.StartsWith(".")) throw new ArgumentException("The value must be in the format \".ext\"", nameof(ext));
			return CreateAndInit(ASSOCF.ASSOCF_INIT_DEFAULTTOSTAR, ext);
		}

		private static ShellAssociation CreateAndInit(ASSOCF flags, string assoc)
		{
			// if (Environment.OSVersion.Version.Major >= 6)
			//var elements = new[] { new ASSOCIATIONELEMENT { ac = ASSOCCLASS.ASSOCCLASS_PROGID_STR, pszClass = progId } };
			//AssocCreateForClasses(elements, (uint)elements.Length, typeof(IQueryAssociations).GUID, out var iq).ThrowIfFailed();
			//ret.qassoc = (IQueryAssociations)iq;

			var ret = new ShellAssociation(assoc) { qassoc = AssocCreate() };
			try
			{
				ret.qassoc.Init(flags, assoc);
				return ret;
			}
			catch
			{
				return null;
			}
		}

		private SafeRegistryHandle GetKey(ASSOCKEY key, string extra = null)
		{
			const ASSOCF flags = 0;
			qassoc.GetKey(flags, key, extra, out var hkey);
			return new SafeRegistryHandle((IntPtr)hkey, true);
		}

		private string GetString(ASSOCSTR astr, string extra = null)
		{
			const ASSOCF flags = ASSOCF.ASSOCF_NOTRUNCATE | ASSOCF.ASSOCF_REMAPRUNDLL;
			var sz = 0U;
			qassoc.GetString(flags, astr, extra, null, ref sz);
			var sb = new StringBuilder((int)sz, (int)sz);
			qassoc.GetString(flags, astr, extra, sb, ref sz);
			return sb.ToString();
		}
	}
}