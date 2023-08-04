using System.Security;

namespace Vanara.PInvoke;

public static partial class Shell32
{
	/// <summary>Specifies which objects are enumerated for autocompletion lists.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/shlobj_core/ne-shlobj_core-autocompletelistoptions typedef enum
	// _tagAUTOCOMPLETELISTOPTIONS { ACLO_NONE = 0, ACLO_CURRENTDIR = 1, ACLO_MYCOMPUTER = 2, ACLO_DESKTOP = 4, ACLO_FAVORITES = 8,
	// ACLO_FILESYSONLY = 16, ACLO_FILESYSDIRS = 32, ACLO_VIRTUALNAMESPACE = 64 } AUTOCOMPLETELISTOPTIONS;
	[PInvokeData("shlobj_core.h", MSDNShortId = "NE:shlobj_core._tagAUTOCOMPLETELISTOPTIONS")]
	[Flags]
	public enum AUTOCOMPLETELISTOPTIONS
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>No enumeration should take place.</para>
		/// </summary>
		ACLO_NONE = 0,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>Only the current directory should be enumerated.</para>
		/// </summary>
		ACLO_CURRENTDIR = 1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>Only MyComputer should be enumerated.</para>
		/// </summary>
		ACLO_MYCOMPUTER = 2,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>Only the Desktop Folder should be enumerated.</para>
		/// </summary>
		ACLO_DESKTOP = 4,

		/// <summary>
		/// <para>Value:</para>
		/// <para>8</para>
		/// <para>Only the Favorites Folder should be enumerated.</para>
		/// </summary>
		ACLO_FAVORITES = 8,

		/// <summary>
		/// <para>Value:</para>
		/// <para>16</para>
		/// <para>Only the file system should be enumerated.</para>
		/// </summary>
		ACLO_FILESYSONLY = 16,

		/// <summary>
		/// <para>Value:</para>
		/// <para>32</para>
		/// <para>Internet Explorer 6 or greater:</para>
		/// <para>The file system dirs, UNC shares, and UNC servers should be enumerated.</para>
		/// </summary>
		ACLO_FILESYSDIRS = 32,

		/// <summary>
		/// <para>Value:</para>
		/// <para>64</para>
		/// <para>Windows Internet Explorer 7 or greater:</para>
		/// <para>The virtual namespace should be enumerated.</para>
		/// </summary>
		ACLO_VIRTUALNAMESPACE = 64,
	}

	/// <summary>Exposes a method that improves the efficiency of autocompletion when the candidate strings are organized in a hierarchy.</summary>
	/// <remarks>
	/// <para>Autocompletion typically requires the following three components:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>The autocompletion client. This client is a window, such as a dialog box, that hosts the edit control.</description>
	/// </item>
	/// <item>
	/// <description>
	/// The autocompletion object (CLSID_AutoComplete). This object is provided by the system, and handles the user interface, parsing, and
	/// background thread management.
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// The autocompletion list object. This object is responsible for providing lists of candidate strings to the autocompletion object.
	/// </description>
	/// </item>
	/// </list>
	/// <para>
	/// A simple autocompletion list object needs only to export IEnumString in addition to IUnknown. When the user enters characters in the
	/// edit box, the autocompletion object calls the list object's <c>IEnumString</c> interface to enumerate the list of strings that can be
	/// used to complete the partial string. The list object maintains a namespace and decides which of those strings are relevant.
	/// </para>
	/// <para>
	/// The simplest approach a list object takes is to return every string in its namespace every time the autocompletion object makes a
	/// request. For a discussion of how to implement this type of list object, see IAutoComplete. However, this approach is practical only
	/// if the namespace is relatively small. When large numbers of strings are involved, the list object must restrict itself to a small
	/// subset of the namespace.
	/// </para>
	/// <para>
	/// The <c>IACList</c> interface is exported by autocompletion list objects to help them choose a sensible subset of strings from a
	/// hierarchically organized namespace. With a large namespace, this procedure substantially increases the efficiency of autocompletion.
	/// The basic procedure is as follows:
	/// </para>
	/// <list type="number">
	/// <item>
	/// <description>
	/// The autocomplete object calls the list object's IEnumString interface. The list object returns the names of the top-level items in
	/// the hierarchy. For example, if the namespace consists of every file and folder on the C: drive, the list object returns the fully
	/// qualified paths of the folders and files contained in the C:\ directory.
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// The user continues to type until he or she enters a delimiter. The '\' and '/' characters are recognized as delimiters by the
	/// autocompletion object.
	/// </description>
	/// </item>
	/// <item>
	/// <description>The autocompletion object calls the list object's IACList::Expand method and passes it the current partial string.</description>
	/// </item>
	/// <item>
	/// <description>
	/// The autocomplete object calls the list object's IEnumString interface again to request a new list of strings. If the partial string
	/// matches one of the top-level items in the namespace, the list object returns the names of the items that fall immediately under the
	/// selected item. For instance, if the user has entered "C:\Program Files\", the list object returns the names of the files and folders
	/// contained in that directory. If the name passed to IACList::Expand does not match any top-level item, the list object can simply stop
	/// returning strings until the autocomplete object calls <c>IACList::Expand</c> with a string that is in the list object's namespace.
	/// </description>
	/// </item>
	/// <item>
	/// <description>The process continues until the user selects a string, typically by pressing the <c>ENTER</c> key.</description>
	/// </item>
	/// </list>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/shlobj_core/nn-shlobj_core-iaclist
	[PInvokeData("shlobj_core.h", MSDNShortId = "NN:shlobj_core.IACList")]
	[ComImport, Guid("77A130B0-94FD-11D0-A544-00C04FD7d062"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IACList
	{
		/// <summary>Requests that the autocompletion client generate candidate strings associated with a specified item in its namespace.</summary>
		/// <param name="pszExpand">
		/// <para>Type: <c>PCWSTR</c></para>
		/// <para>A pointer to a null-terminated, Unicode string to be expanded by the autocomplete object.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The autocomplete object calls this method when a delimiter is entered in the edit control. If the string pointed to by
		/// <c>pszExpand</c> matches an item in the autocompletion client's namespace, the client generates strings for those items that fall
		/// immediately under <c>pszExpand</c> in its namespace hierarchy. The client returns those strings next time the autocompletion
		/// object calls the client's IEnumString interface.
		/// </para>
		/// <para>
		/// For example, assuming that the client's namespace consists of all the files and folders on the C: drive, and <c>pszExpand</c> is
		/// set to "C:\Program Files", the client should generate a list of strings corresponding to the fully qualified paths of the files
		/// and subfolders of "C:\Program Files".
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/shlobj_core/nf-shlobj_core-iaclist-expand HRESULT Expand( [in] PCWSTR
		// pszExpand );
		[PreserveSig]
		HRESULT Expand(string pszExpand);
	}

	/// <summary>Extends the IACList interface to enable clients of an autocomplete object to retrieve and set option flags.</summary>
	/// <remarks>
	/// <para>This interface also provides the methods of the IACList interface from which it inherits.</para>
	/// <para>When to Implement</para>
	/// <para>
	/// Autocompletion clients implement this interface to enable the autocomplete object to retrieve and set options. The options are
	/// basically a request that the client generate a list with the names of all the files and subfolders contained by one or more specified
	/// folders. The autocomplete object then calls the client's IEnumString interface to request the strings.
	/// </para>
	/// <para>When to Use</para>
	/// <para>Typically, this interface is not used directly by applications.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/shlobj_core/nn-shlobj_core-iaclist2
	[PInvokeData("shlobj_core.h", MSDNShortId = "NN:shlobj_core.IACList2")]
	[ComImport, Guid("470141a0-5186-11d2-bbb6-0060977b464c"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IACList2 : IACList
	{
		/// <summary>Requests that the autocompletion client generate candidate strings associated with a specified item in its namespace.</summary>
		/// <param name="pszExpand">
		/// <para>Type: <c>PCWSTR</c></para>
		/// <para>A pointer to a null-terminated, Unicode string to be expanded by the autocomplete object.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The autocomplete object calls this method when a delimiter is entered in the edit control. If the string pointed to by
		/// <c>pszExpand</c> matches an item in the autocompletion client's namespace, the client generates strings for those items that fall
		/// immediately under <c>pszExpand</c> in its namespace hierarchy. The client returns those strings next time the autocompletion
		/// object calls the client's IEnumString interface.
		/// </para>
		/// <para>
		/// For example, assuming that the client's namespace consists of all the files and folders on the C: drive, and <c>pszExpand</c> is
		/// set to "C:\Program Files", the client should generate a list of strings corresponding to the fully qualified paths of the files
		/// and subfolders of "C:\Program Files".
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/shlobj_core/nf-shlobj_core-iaclist-expand HRESULT Expand( [in] PCWSTR
		// pszExpand );
		[PreserveSig]
		new HRESULT Expand(string pszExpand);

		/// <summary>Sets the current autocomplete options.</summary>
		/// <param name="dwFlag">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// New option flags. Use these flags to ask the client to include the names of the files and subfolders of the specified folders the
		/// next time the client's IEnumString interface is called. This parameter can contain one or more of the following flags.
		/// </para>
		/// <para>ACLO_CURRENTDIR</para>
		/// <para>Enumerate the current working directory.</para>
		/// <para>ACLO_DESKTOP</para>
		/// <para>Enumerate the Desktop folder.</para>
		/// <para>ACLO_FAVORITES</para>
		/// <para>Enumerate the Favorites folder.</para>
		/// <para>ACLO_FILESYSONLY</para>
		/// <para>Enumerate only those items that are part of the file system. Do not enumerate items contained by virtual folders.</para>
		/// <para>ACLO_FILESYSDIRS</para>
		/// <para>Enumerate only the file system directories, UNC shares, and UNC servers.</para>
		/// <para>ACLO_MYCOMPUTER</para>
		/// <para>Enumerate the My Computer folder.</para>
		/// <para>ACLO_NONE</para>
		/// <para>Do not enumerate anything.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns S_OK if successful, or a COM error value otherwise.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/shlobj_core/nf-shlobj_core-iaclist2-setoptions HRESULT SetOptions( [in] DWORD
		// dwFlag );
		[PreserveSig]
		HRESULT SetOptions(AUTOCOMPLETELISTOPTIONS dwFlag);

		/// <summary>Gets the current autocomplete options.</summary>
		/// <param name="pdwFlag">
		/// <para>Type: <c>DWORD*</c></para>
		/// <para>
		/// A pointer to a value that will hold the current option flag when the method returns. This can be a combination of the following values.
		/// </para>
		/// <para>ACLO_CURRENTDIR</para>
		/// <para>Enumerate the current working directory.</para>
		/// <para>ACLO_DESKTOP</para>
		/// <para>Enumerate the Desktop folder.</para>
		/// <para>ACLO_FAVORITES</para>
		/// <para>Enumerate the Favorites folder.</para>
		/// <para>ACLO_FILESYSONLY</para>
		/// <para>Enumerate only items that are part of the file system. Do not enumerate items contained by virtual folders.</para>
		/// <para>ACLO_FILESYSDIRS</para>
		/// <para>Enumerate only the file system directories, UNC shares, and UNC servers.</para>
		/// <para>ACLO_MYCOMPUTER</para>
		/// <para>Enumerate the My Computer folder.</para>
		/// <para>ACLO_NONE</para>
		/// <para>Do not enumerate anything.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns S_OK if successful, or a COM error value otherwise.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/shlobj_core/nf-shlobj_core-iaclist2-getoptions HRESULT GetOptions( [out] DWORD
		// *pdwFlag );
		[PreserveSig]
		HRESULT GetOptions(out AUTOCOMPLETELISTOPTIONS pdwFlag);
	}

	/// <summary>Exposes methods that enable a client to retrieve or set an object's current working directory.</summary>
	/// <remarks>
	/// <para>Implement this interface if your object allows clients to retrieve or set the current working directory.</para>
	/// <para>Use this interface to retrieve or set the working directory of the object that exports it.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/shlobj/nn-shlobj-icurrentworkingdirectory
	[PInvokeData("shlobj.h", MSDNShortId = "NN:shlobj.ICurrentWorkingDirectory")]
	[ComImport, Guid("91956D21-9276-11d1-921A-006097DF5BD4"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ICurrentWorkingDirectory
	{
		/// <summary>Gets the current working directory.</summary>
		/// <param name="pwzPath">
		/// <para>Type: <c>PWSTR</c></para>
		/// <para>
		/// Pointer to a buffer that, when this method returns successfully, receives the current working directory's fully qualified path as
		/// a null-terminated Unicode string.
		/// </para>
		/// </param>
		/// <param name="cchSize">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The size of the buffer in Unicode characters, including the terminating <c>NULL</c> character.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/shlobj/nf-shlobj-icurrentworkingdirectory-getdirectory HRESULT GetDirectory(
		// [out] PWSTR pwzPath, DWORD cchSize );
		[PreserveSig]
		HRESULT GetDirectory(out StringBuilder pwzPath, uint cchSize);

		/// <summary>Sets the current working directory.</summary>
		/// <param name="pwzPath">
		/// <para>Type: <c>PCWSTR</c></para>
		/// <para>A pointer to the fully qualified path of the new working directory, as a null-terminated Unicode string.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/shlobj/nf-shlobj-icurrentworkingdirectory-setdirectory HRESULT SetDirectory(
		// [in] PCWSTR pwzPath );
		[PreserveSig]
		HRESULT SetDirectory(string pwzPath);
	}

	/// <summary>Exposes methods that allow a client to append or remove an object from a collection of objects managed by a server object.</summary>
	/// <remarks>
	/// <para>
	/// This interface is implemented by objects that manage a collection of other objects. It is exported to allow clients of the object to
	/// request that objects be added to or removed from the collection.
	/// </para>
	/// <para>Use this interface to add or delete an object from the server object's collection of managed objects.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/shlobj_core/nn-shlobj_core-iobjmgr
	[PInvokeData("shlobj_core.h", MSDNShortId = "NN:shlobj_core.IObjMgr")]
	[ComImport, Guid("00BB2761-6A77-11D0-A535-00C04FD7D062"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(ACLMulti))]
	public interface IObjMgr
	{
		/// <summary>Appends an object to the collection of managed objects.</summary>
		/// <param name="punk">
		/// <para>Type: <c>IUnknown*</c></para>
		/// <para>The address of the IUnknown interface of the object to be added to the list.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/shlobj_core/nf-shlobj_core-iobjmgr-append HRESULT Append( [in] IUnknown *punk );
		void Append([In, MarshalAs(UnmanagedType.IUnknown)] object punk);

		/// <summary>Removes an object from the collection of managed objects.</summary>
		/// <param name="punk">
		/// <para>Type: <c>IUnknown*</c></para>
		/// <para>The address of the IUnknown interface of the object to be removed from the list.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/shlobj_core/nf-shlobj_core-iobjmgr-remove HRESULT Remove( [in] IUnknown *punk );
		void Remove([In, MarshalAs(UnmanagedType.IUnknown)] object punk);
	}

	/// <summary>An autocomplete object (CLSID_ACLMulti).</summary>
	[ComImport, SuppressUnmanagedCodeSecurity, Guid("00BB2765-6A77-11D0-A535-00C04FD7D062"), ClassInterface(ClassInterfaceType.None)]
	public class ACLMulti { }
}