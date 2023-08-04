using Microsoft.Win32.SafeHandles;
using System.Collections.Generic;
using System.Linq;
using Vanara.PInvoke;
using static Vanara.PInvoke.Shell32;
using static Vanara.PInvoke.ShlwApi;

namespace Vanara.Windows.Shell;

/// <summary>Represents a Shell file association defined in the Windows Registry. Wraps <see cref="IQueryAssociations"/>.</summary>
public class ShellAssociation
{
	private IQueryAssociations qassoc;

	/// <summary>Initializes a new instance of the <see cref="ShellAssociation"/> class.</summary>
	/// <param name="pQA">The IQueryAssociations instance to use.</param>
	/// <param name="ext">The optional file extension. This should be in the ".ext" format.</param>
	internal ShellAssociation(IQueryAssociations pQA, string ext) : this(ext) => qassoc = pQA;

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
	/// Introduced in Internet Explorer 6. Describes a general type of MIME file association, such as image and bmp, so that
	/// applications can make general assumptions about a specific file type.
	/// </summary>
	public string ContentType => GetString(ASSOCSTR.ASSOCSTR_CONTENTTYPE);

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

	/// <summary>Gets a list of file name extension handlers.</summary>
	/// <value>The handlers for this association.</value>
	public IReadOnlyList<ShellAssociationHandler> Handlers
	{
		get
		{
			if (SHAssocEnumHandlers(Extension, ASSOC_FILTER.ASSOC_FILTER_NONE, out var ieah).Failed)
				return (IReadOnlyList<ShellAssociationHandler>)new List<ShellAssociationHandler>();
			using var pieah = ComReleaserFactory.Create(ieah);
			var e = new Collections.IEnumFromCom<IAssocHandler>(ieah.Next, () => { });
			return (IReadOnlyList<ShellAssociationHandler>)e.Select(i => new ShellAssociationHandler(i)).ToList();
		}
	}

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
	/// Introduced in Internet Explorer 6. Corresponds to the QuickTip registry value. Same as ASSOCSTR_INFOTIP, except that it always
	/// returns a list of property names in the form of an IPropertyDescriptionList. The difference between this value and
	/// ASSOCSTR_INFOTIP is that this returns properties that are safe for any scenario that causes slow property retrieval, such as
	/// offline or slow networks. Some of the properties returned from ASSOCSTR_INFOTIP might not be appropriate for slow property
	/// retrieval scenarios. The list of properties can be parsed with PSGetPropertyDescriptionListFromString.
	/// </summary>
	public string QuickTip => GetString(ASSOCSTR.ASSOCSTR_QUICKTIP);

	/// <summary>
	/// Introduced in Internet Explorer 6. For an object that has a Shell extension associated with it, you can use this to retrieve the
	/// CLSID of that Shell extension object by passing a string representation of the IID of the interface you want to retrieve as the
	/// parameter of IQueryAssociations::GetString. For example, if you want to retrieve a handler that implements the IExtractImage
	/// interface, you would specify "{BB2E617C-0920-11d1-9A0B-00C04FC2D6C1}", which is the IID of IExtractImage.
	/// </summary>
	public IndirectString ShellExtension => IndirectString.TryParse(GetString(ASSOCSTR.ASSOCSTR_SHELLEXTENSION), out var s) ? s : null;

	/// <summary>Introduced in Windows 8.</summary>
	public Guid? SupportedUriProtocols { get { try { return new Guid(GetString(ASSOCSTR.ASSOCSTR_SUPPORTED_URI_PROTOCOLS)); } catch { return null; } } }

	/// <summary>
	/// Introduced in Internet Explorer 6. Corresponds to the TileInfo registry value. Contains a list of properties to be displayed for
	/// a particular file type in a Windows Explorer window that is in tile view. This is the same as ASSOCSTR_INFOTIP, but, like
	/// ASSOCSTR_QUICKTIP, it also returns a list of property names in the form of an IPropertyDescriptionList. The list of properties
	/// can be parsed with PSGetPropertyDescriptionListFromString.
	/// </summary>
	public string TileInfo => GetString(ASSOCSTR.ASSOCSTR_TILEINFO);

	/// <summary>Gets the command verbs for this file association.</summary>
	/// <value>Returns a <see cref="IReadOnlyDictionary{TKey, TValue}"/> value.</value>
	public IReadOnlyDictionary<string, CommandVerb> Verbs => null; //throw new NotImplementedException(); // TODO

	/// <summary>Initializes a new instance of the <see cref="ShellAssociation"/> class based on the supplied executable name.</summary>
	/// <param name="appExeName">The full path of the application executable.</param>
	/// <returns>A <see cref="ShellAssociation"/> instance if <paramref name="appExeName"/> exists; <see langword="null"/> otherwise.</returns>
	public static ShellAssociation CreateFromAppExeName(string appExeName) => CreateAndInit(ASSOCF.ASSOCF_INIT_BYEXENAME, appExeName);

	/// <summary>Initializes a new instance of the <see cref="ShellAssociation"/> class based on the supplied CLSID.</summary>
	/// <param name="classId">The CLSID.</param>
	/// <returns>A <see cref="ShellAssociation"/> instance if <paramref name="classId"/> exists; <see langword="null"/> otherwise.</returns>
	public static ShellAssociation CreateFromCLSID(Guid classId) => CreateAndInit(0, classId.ToString("B"));

	/// <summary>
	/// Initializes a new instance of the <see cref="ShellAssociation"/> class based on the supplied programmatic identifier (ProgId).
	/// </summary>
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

	/// <summary>Searches for and retrieves file or protocol association-related binary data from the registry.</summary>
	/// <param name="data">The ASSOCDATA value that specifies the type of data that is to be returned.</param>
	/// <param name="extra">
	/// An optional string with information about the location of the data. It is normally set to a Shell verb such as open. Set this
	/// parameter to <see langword="null"/> if it is not used.
	/// </param>
	/// <returns>A value that, when this method returns successfully, receives the requested data value.</returns>
	public SafeCoTaskMemHandle GetData(ASSOCDATA data, string extra = null)
	{
		try
		{
			const ASSOCF flags = 0;
			var sz = 0U;
			qassoc.GetData(flags, data, extra, default, ref sz);
			if (sz == 0) return null;
			var ret = new SafeCoTaskMemHandle(sz);
			qassoc.GetData(flags, data, extra, ret, ref sz);
			return ret;
		}
		catch (COMException e) when (e.ErrorCode == HRESULT.HRESULT_FROM_WIN32(Win32Error.ERROR_NO_ASSOCIATION))
		{
			return null;
		}
	}

	/// <summary>Searches for and retrieves a file or protocol association-related key from the registry.</summary>
	/// <param name="key">The ASSOCKEY value that specifies the type of key that is to be returned.</param>
	/// <param name="extra">
	/// An optional string with information about the location of the key. It is normally set to a Shell verb such as open. Set this
	/// parameter to <see langword="null"/> if it is not used.
	/// </param>
	/// <returns>A handle to the resulting registry key.</returns>
	public SafeRegistryHandle GetKey(ASSOCKEY key, string extra = null)
	{
		const ASSOCF flags = 0;
		qassoc.GetKey(flags, key, extra, out var hkey);
		return new SafeRegistryHandle((IntPtr)hkey, true);
	}

	/// <summary>Searches for and retrieves a file or protocol association-related string from the registry.</summary>
	/// <param name="astr">An ASSOCSTR value that specifies the type of string that is to be returned.</param>
	/// <param name="extra">
	/// An optional string with information about the location of the string. It is typically set to a Shell verb such as open. Set this
	/// parameter to <see langword="null"/> if it is not used.
	/// </param>
	/// <returns>
	/// A string used to return the requested string. If there are no results for this value, <see langword="null"/> is returned.
	/// </returns>
	public string GetString(ASSOCSTR astr, string extra = null)
	{
		try
		{
			const ASSOCF flags = ASSOCF.ASSOCF_NOTRUNCATE | ASSOCF.ASSOCF_REMAPRUNDLL;
			var sz = 0U;
			qassoc.GetString(flags, astr, extra, null, ref sz);
			var sb = new StringBuilder((int)sz, (int)sz);
			qassoc.GetString(flags, astr, extra, sb, ref sz);
			return sb.ToString();
		}
		catch (COMException e) when (e.ErrorCode == HRESULT.HRESULT_FROM_WIN32(Win32Error.ERROR_NO_ASSOCIATION))
		{
			return null;
		}
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

	/// <summary>Represents a handler (executable) for a <see cref="ShellAssociation"/>.</summary>
	public class ShellAssociationHandler : ComObjWrapper<ShellAssociationHandler, IAssocHandler>
	{
		internal ShellAssociationHandler(IAssocHandler h) : base(h)
		{
		}

		/// <summary>Retrieves the location of the icon associated with the application.</summary>
		/// <value>
		/// An <see cref="IconLocation"/> instance that contains the path and the index of the icon within the resource file for the
		/// application's icon.
		/// </value>
		public IconLocation IconLocation => ComInterface.GetIconLocation(out var p, out var i).Succeeded ? new IconLocation(p, i) : null;

		/// <summary>Indicates whether the application is registered as a recommended handler for the queried file type.</summary>
		/// <value><see langword="true"/> if this instance is recommended; otherwise, <see langword="false"/>.</value>
		/// <remarks>
		/// <para>
		/// Applications that register themselves as handlers for particular file types can specify whether they are recommended
		/// handlers. This has no effect on the actual behavior of the applications when launched. It is simply provided as a hint to
		/// the user and a value that the UI can utilize programmatically, if desired. For example, the Shell's <c>Open With</c> dialog
		/// separates entries into <c>Recommended Programs</c> and <c>Other Programs</c>.
		/// </para>
		/// <para>
		/// Note that program recommendations may change over time. One example is provided when the user chooses an application from
		/// the <c>Other Programs</c> of the <c>Open With</c> dialog to open a particular file type. That may cause the Shell to
		/// "promote" that application to recommended status for that file type. Because the recommended status may change over time,
		/// applications should not cache this value, but query it each time it is needed.
		/// </para>
		/// </remarks>
		public bool IsRecommended => ComInterface.IsRecommended() == HRESULT.S_OK;

		/// <summary>Retrieves the full path and file name of the executable file associated with the file type.</summary>
		/// <value>A string that contains the full path of the file, including the file name.</value>
		public string Name => ComInterface.GetName(out var n).Succeeded ? n : null;

		/// <summary>Retrieves the display name of an application.</summary>
		/// <value>A string that contains the display name of the application.</value>
		public string UIName => ComInterface.GetUIName(out var n).Succeeded ? n : null;

		/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
		public override bool Equals(IAssocHandler other) => Name.Equals(other.GetName(out var n).Succeeded ? n : null);

		/// <summary>Returns a hash code for this instance.</summary>
		/// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
		public override int GetHashCode() => Name.GetHashCode();

		/// <summary>Directly invokes the associated handler.</summary>
		/// <param name="items">A sequence of selected items on which to invoke the handler.</param>
		/// <remarks>
		/// <para>
		/// IAssocHandler objects are typically used to populate an <c>Open With</c> menu. When one of those menu items is selected,
		/// this method is called to launch the chosen application.
		/// </para>
		/// <para>Invoke and CreateInvoker</para>
		/// <para>
		/// The IDataObject used by these methods can represent either a single file or a selection of multiple files. Not all
		/// applications support the multiple file option. The applications that do support that scenario might impose other
		/// restrictions, such as the number of files that can be opened simultaneously, or the acceptable combination of file types.
		/// </para>
		/// <para>
		/// Therefore, an application often must determine whether the handler supports the selection before trying to invoke the
		/// handler. For example, an application might enable a menu item only if it has verified that the selection in question was
		/// supported by that handler.
		/// </para>
		/// </remarks>
		public void Invoke(params ShellItem[] items)
		{
			if (items.Length == 0)
				throw new ArgumentException("", nameof(items));

			if (items.Length == 1)
			{
				ComInterface.Invoke(items[0].DataObject).ThrowIfFailed();
			}
			else
			{
				ComInterface.CreateInvoker(CreateDataObj(items), out var invoker).ThrowIfFailed();
				using var pInvoker = ComReleaserFactory.Create(invoker);
				var hr = invoker.SupportsSelection();
				if (hr == HRESULT.S_FALSE)
					throw new ArgumentException("This handler is unable to support the selections provided.", nameof(items));
				hr.ThrowIfFailed();
				invoker.Invoke().ThrowIfFailed();
			}
		}

		/// <summary>Sets an application as the default application for this file type.</summary>
		/// <param name="description">
		/// <para>A string that contains the display name of the application.</para>
		/// </param>
		public void MakeDefault(string description) => ComInterface.MakeDefault(description).ThrowIfFailed();

		private static System.Runtime.InteropServices.ComTypes.IDataObject CreateDataObj(IEnumerable<ShellItem> items)
		{
			if ((items?.Count() ?? 0) == 0)
				throw new ArgumentNullException(nameof(items));

			if (items is not ShellItemArray litems)
				litems = new ShellItemArray(items);
			return litems.ToDataObject();
		}
	}
}