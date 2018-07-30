using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace Vanara.PInvoke
{
	public static partial class ShlwApi
	{
		/// <summary>
		/// <para>Truncates a path to fit within a certain number of characters by replacing path components with ellipses.</para>
		/// </summary>
		/// <param name="pszOut">
		/// <para>Type: <c>LPTSTR</c></para>
		/// <para>The address of the string that has been altered.</para>
		/// </param>
		/// <param name="pszSrc">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>A pointer to a null-terminated string of length MAX_PATH that contains the path to be altered.</para>
		/// </param>
		/// <param name="cchMax">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// The maximum number of characters to be contained in the new string, including the terminating null character. For example, if =
		/// 8, the resulting string can contain a maximum of 7 characters plus the terminating null character.
		/// </para>
		/// </param>
		/// <param name="dwFlags">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>Reserved. Must be 0.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The '/' separator will be used instead of '' if the original string used it. If points to a file name that is too long, instead
		/// of a path, the file name will be truncated to characters, including the ellipsis and the terminating <c>NULL</c> character. For
		/// example, if the input file name is "My Filename" and is 10, <c>PathCompactPathEx</c> will return "My Fil...".
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-pathcompactpathexa
		// BOOL PathCompactPathExA( LPSTR pszOut, LPCSTR pszSrc, UINT cchMax, DWORD dwFlags );
		[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shlwapi.h", MSDNShortId = "ff108ee6-3d71-4ab2-a04a-d4bcce408f88")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool PathCompactPathEx(StringBuilder pszOut, string pszSrc, uint cchMax, uint dwFlags = 0);

		/// <summary>Searches for a file.</summary>
		/// <param name="pszFile">
		/// <para>Type: <c>LPTSTR</c></para>
		/// <para>
		/// A pointer to a null-terminated string of length MAX_PATH that contains the file name for which to search. If the search is successful, this parameter
		/// is used to return the fully qualified path name.
		/// </para>
		/// </param>
		/// <param name="ppszOtherDirs">
		/// <para>Type: <c>LPCTSTR*</c></para>
		/// <para>An optional, null-terminated array of directories to be searched first. This value can be <c>NULL</c>.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </returns>
		// BOOL PathFindOnPath( _Inout_ LPTSTR pszFile, _In_opt_ LPCTSTR *ppszOtherDirs);
		// https://msdn.microsoft.com/en-us/library/windows/desktop/bb773594(v=vs.85).aspx
		[PInvokeData("Shlwapi.h", MSDNShortId = "bb773594")]
		[DllImport(Lib.Shlwapi, CharSet = CharSet.Auto, SetLastError = false)]
		public static extern bool PathFindOnPath(StringBuilder pszFile, [In] string[] ppszOtherDirs);

		/// <summary>Opens or creates a file and retrieves a stream to read or write to that file.</summary>
		/// <param name="pszFile">A pointer to a null-terminated string that specifies the file name.</param>
		/// <param name="grfMode">One or more STGM values that are used to specify the file access mode and how the object that exposes the stream is created and deleted.</param>
		/// <param name="dwAttributes">One or more flag values that specify file attributes in the case that a new file is created. For a complete list of possible values, see the dwFlagsAndAttributes parameter of the CreateFile function.</param>
		/// <param name="fCreate">A BOOL value that helps specify, in conjunction with grfMode, how existing files should be treated when creating the stream. See Remarks for details.</param>
		/// <param name="pstmTemplate">Reserved.</param>
		/// <param name="ppstm">Receives an IStream interface pointer for the stream associated with the file.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.Shlwapi, CharSet = CharSet.Unicode, ExactSpelling = true)]
		[PInvokeData("Shlwapi.h", MSDNShortId = "bb759866")]
		public static extern HRESULT SHCreateStreamOnFileEx(string pszFile, STGM grfMode, FileFlagsAndAttributes dwAttributes,
			[MarshalAs(UnmanagedType.Bool)] bool fCreate, [Optional] IStream pstmTemplate, out IStream ppstm);

		/// <summary>
		/// Exposes methods that simplify the process of retrieving information stored in the registry in association with defining a file
		/// type or protocol and associating it with an application.
		/// </summary>
		// https://msdn.microsoft.com/en-us/library/windows/desktop/bb761400(v=vs.85).aspx
		[PInvokeData("Shlwapi.h", MSDNShortId = "bb761400")]
		[ComImport, Guid("c46ca590-3c3f-11d2-bee6-0000f805ca57"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IQueryAssociations
		{
			/// <summary>
			/// Initializes the IQueryAssociations interface and sets the root key to the appropriate ProgID.
			/// </summary>
			/// <param name="flags">A flag that specifies how the search is to be initialized. It is typically set to zero, but it can also take one of the following ASSOCF values.</param>
			/// <param name="pszAssoc">A Unicode string that is used to determine the root key. If a value is specified for hkProgid, set this parameter to NULL. Four types of string can be used:
			/// <list type="bullet">
			/// <item><term>File name extension</term><description>A file name extension, such as .txt.</description></item>
			/// <item><term>CLSID</term><description>A CLSID GUID in the standard "{GUID}" format.</description></item>
			/// <item><term>ProgID</term><description>An application's ProgID, such as Word.Document.8.</description></item>
			/// <item><term>Executable name</term><description>The name of an application's .exe file. The ASSOCF_OPEN_BYEXENAME flag must be set in flags.</description></item>
			/// </list></param>
			/// <param name="hkProgid">The HKEY value of the subkey that is used as a root key. The search looks only below this key. If a value is specified for pwszAssoc, set this parameter to NULL.</param>
			/// <param name="hwnd">The HWND.</param>
			void Init(ASSOCF flags, [Optional, MarshalAs(UnmanagedType.LPWStr)] string pszAssoc, [Optional] IntPtr hkProgid, [Optional] IntPtr hwnd);
			/// <summary>
			/// Searches for and retrieves a file or protocol association-related string from the registry.
			/// </summary>
			/// <param name="flags">A flag that can be used to control the search. It can be any combination of the following ASSOCF values.</param>
			/// <param name="str">An ASSOCSTR value that specifies the type of string that is to be returned.</param>
			/// <param name="pszExtra">A pointer to an optional, null-terminated Unicode string with information about the location of the string. It is typically set to a Shell verb such as open. Set this parameter to NULL if it is not used.</param>
			/// <param name="pszOut">A pointer to a null-terminated Unicode string used to return the requested string. Set this parameter to NULL to retrieve the required buffer size.</param>
			/// <param name="pcchOut">A pointer to a value that, on entry, is set to the number of characters in the pwszOut buffer. When the function returns successfully, it points to the number of characters placed in the buffer.
			/// <para>If the ASSOCF_NOTRUNCATE flag is set in flags and the buffer specified in pwszOut is too small, the function returns E_POINTER and pcchOut points to the required size of the buffer.</para>
			/// <para>If pwszOut is NULL, the function returns S_FALSE and pcchOut points to the required size of the buffer.</para></param>
			void GetString(ASSOCF flags, ASSOCSTR str, [Optional, MarshalAs(UnmanagedType.LPWStr)] string pszExtra, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszOut, ref uint pcchOut);
			/// <summary>
			/// Searches for and retrieves a file or protocol association-related key from the registry.
			/// </summary>
			/// <param name="flags">The ASSOCF value that can be used to control the search.</param>
			/// <param name="data">The ASSOCKEY value that specifies the type of key that is to be returned.</param>
			/// <param name="pszExtra">A pointer to an optional, null-terminated Unicode string with information about the location of the key. It is normally set to a Shell verb such as open. Set this parameter to NULL if it is not used.</param>
			/// <param name="phkeyOut">A pointer to the key's HKEY value.</param>
			void GetKey(ASSOCF flags, ASSOCKEY key, [Optional, MarshalAs(UnmanagedType.LPWStr)] string pszExtra, out IntPtr phkeyOut);
			/// <summary>
			/// Searches for and retrieves file or protocol association-related binary data from the registry.
			/// </summary>
			/// <param name="flags">The ASSOCF value that can be used to control the search.</param>
			/// <param name="data">The ASSOCDATA value that specifies the type of data that is to be returned.</param>
			/// <param name="pszExtra">A pointer to an optional, null-terminated Unicode string with information about the location of the data. It is normally set to a Shell verb such as open. Set this parameter to NULL if it is not used.</param>
			/// <param name="pvOut">A pointer to a value that, when this method returns successfully, receives the requested data value.</param>
			/// <param name="pcbOut">A pointer to a value that, when this method is called, holds the size of pvOut, in bytes. When this method returns successfully, the value contains the size of the data actually retrieved.</param>
			void GetData(ASSOCF flags, ASSOCDATA data, [Optional, MarshalAs(UnmanagedType.LPWStr)] string pszExtra, IntPtr pvOut, ref uint pcbOut);
			/// <summary>
			/// This method is not implemented.
			/// </summary>
			/// <param name="flags">Undocumented.</param>
			/// <param name="assocenum">Undocumented.</param>
			/// <param name="pszExtra">Undocumented.</param>
			/// <param name="riid">Undocumented.</param>
			/// <param name="ppvOut">Undocumented.</param>
			void GetEnum(ASSOCF flags, ASSOCENUM assocenum, [MarshalAs(UnmanagedType.LPWStr)] string pszExtra, [MarshalAs(UnmanagedType.LPStruct)] Guid riid, out IntPtr ppvOut);
		}

		/// <summary>Provides information to the <c>IQueryAssociations</c> interface methods.</summary>
		// typedef enum { ASSOCF_NONE = 0x00000000, ASSOCF_INIT_NOREMAPCLSID = 0x00000001, ASSOCF_INIT_BYEXENAME = 0x00000002, ASSOCF_OPEN_BYEXENAME = 0x00000002, ASSOCF_INIT_DEFAULTTOSTAR = 0x00000004, ASSOCF_INIT_DEFAULTTOFOLDER = 0x00000008, ASSOCF_NOUSERSETTINGS = 0x00000010, ASSOCF_NOTRUNCATE = 0x00000020, ASSOCF_VERIFY = 0x00000040, ASSOCF_REMAPRUNDLL = 0x00000080, ASSOCF_NOFIXUPS = 0x00000100, ASSOCF_IGNOREBASECLASS = 0x00000200, ASSOCF_INIT_IGNOREUNKNOWN = 0x00000400, ASSOCF_INIT_FIXED_PROGID = 0x00000800, ASSOCF_IS_PROTOCOL = 0x00001000, ASSOCF_INIT_FOR_FILE = 0x00002000} ASSOCF;
		// https://msdn.microsoft.com/en-us/library/windows/desktop/bb762471(v=vs.85).aspx
		[Flags]
		[PInvokeData("Shlwapi.h", MSDNShortId = "bb762471")]
		public enum ASSOCF
		{
			/// <summary>None of the following options are set.</summary>
			ASSOCF_NONE = 0x00000000,
			/// <summary>Instructs <c>IQueryAssociations</c> interface methods not to map CLSID values to ProgID values.</summary>
			ASSOCF_INIT_NOREMAPCLSID = 0x00000001,
			/// <summary>Identifies the value of the pwszAssoc parameter of <c>IQueryAssociations::Init</c> as an executable file name. If this flag is not set, the root key will be set to the ProgID associated with the <c>.exe</c> key instead of the executable file&#39;s ProgID.</summary>
			ASSOCF_INIT_BYEXENAME = 0x00000002,
			/// <summary>Identical to <c><c>ASSOCF_INIT_BYEXENAME</c></c>.</summary>
			ASSOCF_OPEN_BYEXENAME = 0x00000002,
			/// <summary>Specifies that when an <c>IQueryAssociations</c> method does not find the requested value under the root key, it should attempt to retrieve the comparable value from the <c>*</c> subkey.</summary>
			ASSOCF_INIT_DEFAULTTOSTAR = 0x00000004,
			/// <summary>Specifies that when a <c>IQueryAssociations</c> method does not find the requested value under the root key, it should attempt to retrieve the comparable value from the <c>Folder</c> subkey.</summary>
			ASSOCF_INIT_DEFAULTTOFOLDER = 0x00000008,
			/// <summary>Specifies that only <c>HKEY_CLASSES_ROOT</c> should be searched, and that <c>HKEY_CURRENT_USER</c> should be ignored.</summary>
			ASSOCF_NOUSERSETTINGS = 0x00000010,
			/// <summary>
			/// Specifies that the return string should not be truncated. Instead, return an error value and the required size for the
			/// complete string.
			/// </summary>
			ASSOCF_NOTRUNCATE = 0x00000020,
			/// <summary>Specifies that the return string should not be truncated. Instead, return an error value and the required size for the complete string.</summary>
			ASSOCF_VERIFY = 0x00000040,
			/// <summary>Instructs <c>IQueryAssociations</c> methods to ignore Rundll.exe and return information about its target. Typically <c>IQueryAssociations</c> methods return information about the first .exe or .dll in a command string. If a command uses Rundll.exe, setting this flag tells the method to ignore Rundll.exe and return information about its target.</summary>
			ASSOCF_REMAPRUNDLL = 0x00000080,
			/// <summary>Instructs <c>IQueryAssociations</c> methods not to fix errors in the registry, such as the friendly name of a function not matching the one found in the .exe file.</summary>
			ASSOCF_NOFIXUPS = 0x00000100,
			/// <summary>Specifies that the BaseClass value should be ignored.</summary>
			ASSOCF_IGNOREBASECLASS = 0x00000200,
			/// <summary><c>Introduced in Windows 7</c>. Specifies that the &quot;Unknown&quot; ProgID should be ignored; instead, fail.</summary>
			ASSOCF_INIT_IGNOREUNKNOWN = 0x00000400,
			/// <summary><c>Introduced in Windows 8</c>. Specifies that the supplied ProgID should be mapped using the system defaults, rather than the current user defaults.</summary>
			ASSOCF_INIT_FIXED_PROGID = 0x00000800,
			/// <summary><c>Introduced in Windows 8</c>. Specifies that the value is a protocol, and should be mapped using the current user defaults.</summary>
			ASSOCF_IS_PROTOCOL = 0x00001000,
			/// <summary><c>Introduced in Windows 8.1</c>. Specifies that the ProgID corresponds with a file extension based association. Use together with <c>ASSOCF_INIT_FIXED_PROGID</c>.</summary>
			ASSOCF_INIT_FOR_FILE = 0x00002000
		}

		/// <summary><para>Used by IQueryAssociations::GetString to define the type of string that is to be returned.</para></summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/ne-shlwapi-assocstr
		[PInvokeData("shlwapi.h", MSDNShortId = "b5fd3d25-3630-4dd8-acd2-d2e4ed571604")]
		public enum ASSOCSTR
		{
			/// <summary>A command string associated with a Shell verb.</summary>
			ASSOCSTR_COMMAND = 1,
			/// <summary>An executable from a Shell verb command string. For example, this string is found as the (Default) value for a subkey such as HKEY_CLASSES_ROOT\\shell\Open\command. If the command uses Rundll.exe, set the ASSOCF_REMAPRUNDLL flag in the parameter of IQueryAssociations::GetString to retrieve the target executable. This type of string will identify the code that will be invoked in the implementation of the verb.</summary>
			ASSOCSTR_EXECUTABLE,
			/// <summary>The friendly name of a document type.</summary>
			ASSOCSTR_FRIENDLYDOCNAME,
			/// <summary>The friendly name of an executable file.</summary>
			ASSOCSTR_FRIENDLYAPPNAME,
			/// <summary>Ignore the information associated with the open subkey.</summary>
			ASSOCSTR_NOOPEN,
			/// <summary>Look under the ShellNew subkey.</summary>
			ASSOCSTR_SHELLNEWVALUE,
			/// <summary>The DDE command to use to create a process.</summary>
			ASSOCSTR_DDEIFEXEC,
			/// <summary>The application name in a DDE broadcast.</summary>
			ASSOCSTR_DDEAPPLICATION,
			/// <summary>The topic name in a DDE broadcast.</summary>
			ASSOCSTR_DDETOPIC,
			/// <summary>Corresponds to the InfoTip registry value. Returns an info tip for an item, or list of properties in the form of an IPropertyDescriptionList from which to create an info tip, such as when hovering the cursor over a file name. The list of properties can be parsed with PSGetPropertyDescriptionListFromString.</summary>
			ASSOCSTR_INFOTIP,
			/// <summary>Introduced in Internet Explorer 6. Corresponds to the QuickTip registry value. Same as ASSOCSTR_INFOTIP, except that it always returns a list of property names in the form of an IPropertyDescriptionList. The difference between this value and ASSOCSTR_INFOTIP is that this returns properties that are safe for any scenario that causes slow property retrieval, such as offline or slow networks. Some of the properties returned from ASSOCSTR_INFOTIP might not be appropriate for slow property retrieval scenarios. The list of properties can be parsed with PSGetPropertyDescriptionListFromString.</summary>
			ASSOCSTR_QUICKTIP,
			/// <summary>Introduced in Internet Explorer 6. Corresponds to the TileInfo registry value. Contains a list of properties to be displayed for a particular file type in a Windows Explorer window that is in tile view. This is the same as ASSOCSTR_INFOTIP, but, like ASSOCSTR_QUICKTIP, it also returns a list of property names in the form of an IPropertyDescriptionList. The list of properties can be parsed with PSGetPropertyDescriptionListFromString.</summary>
			ASSOCSTR_TILEINFO,
			/// <summary>Introduced in Internet Explorer 6. Describes a general type of MIME file association, such as image and bmp, so that applications can make general assumptions about a specific file type.</summary>
			ASSOCSTR_CONTENTTYPE,
			/// <summary>Introduced in Internet Explorer 6. Returns the path to the icon resources to use by default for this association. Positive numbers indicate an index into the dll&#39;s resource table, while negative numbers indicate a resource ID. An example of the syntax for the resource is &quot;c:\myfolder\myfile.dll,-1&quot;.</summary>
			ASSOCSTR_DEFAULTICON,
			/// <summary>Introduced in Internet Explorer 6. For an object that has a Shell extension associated with it, you can use this to retrieve the CLSID of that Shell extension object by passing a string representation of the IID of the interface you want to retrieve as the parameter of IQueryAssociations::GetString. For example, if you want to retrieve a handler that implements the IExtractImage interface, you would specify &quot;{BB2E617C-0920-11d1-9A0B-00C04FC2D6C1}&quot;, which is the IID of IExtractImage.</summary>
			ASSOCSTR_SHELLEXTENSION,
			/// <summary>Introduced in Internet Explorer 8.. For a verb invoked through COM and the IDropTarget interface, you can use this flag to retrieve the IDropTarget object&#39;s CLSID. This CLSID is registered in the DropTarget subkey. The verb is specified in the parameter in the call to IQueryAssociations::GetString. This type of string will identify the code that will be invoked in the implementation of the verb.</summary>
			ASSOCSTR_DROPTARGET,
			/// <summary>Introduced in Internet Explorer 8.. For a verb invoked through COM and the IExecuteCommand interface, you can use this flag to retrieve the IExecuteCommand object&#39;s CLSID. This CLSID is registered in the verb&#39;s command subkey as the DelegateExecute entry. The verb is specified in the parameter in the call to IQueryAssociations::GetString. This type of string will identify the code that will be invoked in the implementation of the verb.</summary>
			ASSOCSTR_DELEGATEEXECUTE,
			/// <summary>Introduced in Windows 8.</summary>
			ASSOCSTR_SUPPORTED_URI_PROTOCOLS,
			/// <summary>The ProgID provided by the app associated with the file type or URI scheme. This if configured by users in their default program settings.</summary>
			ASSOCSTR_PROGID,
			/// <summary>The AppUserModelID of the app associated with the file type or URI scheme. This is configured by users in their default program settings.</summary>
			ASSOCSTR_APPID,
			/// <summary>The publisher of the app associated with the file type or URI scheme. This is configured by users in their default program settings.</summary>
			ASSOCSTR_APPPUBLISHER,
			/// <summary>The icon reference of the app associated with the file type or URI scheme. This is configured by users in their default program settings.</summary>
			ASSOCSTR_APPICONREFERENCE,
			/// <summary>The maximum defined ASSOCSTR value, used for validation purposes.</summary>
			ASSOCSTR_MAX,
		}

		/// <summary><para>Specifies the type of key to be returned by IQueryAssociations::GetKey.</para></summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/ne-shlwapi-assockey
		[PInvokeData("shlwapi.h", MSDNShortId = "f4ac0ba0-4113-498f-a51b-74a37fe33d49")]
		public enum ASSOCKEY
		{
			/// <summary>A key that is passed to ShellExecuteEx through a SHELLEXECUTEINFO structure.</summary>
			ASSOCKEY_SHELLEXECCLASS = 1,
			/// <summary>An Application key for the file type.</summary>
			ASSOCKEY_APP,
			/// <summary>A ProgID or class key.</summary>
			ASSOCKEY_CLASS,
			/// <summary>A BaseClass value.</summary>
			ASSOCKEY_BASECLASS,
			/// <summary />
			ASSOCKEY_MAX,
		}

		/// <summary><para>Used by IQueryAssociations::GetData to define the type of data that is to be returned.</para></summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/ne-shlwapi-assocdata
		[PInvokeData("shlwapi.h", MSDNShortId = "0ae5c8db-81fd-4d00-8e54-0c474f1bfd06")]
		public enum ASSOCDATA
		{
			/// <summary>The component descriptor to pass to the Windows Installer API.</summary>
			ASSOCDATA_MSIDESCRIPTOR = 1,
			/// <summary>Attempts to activate a window are restricted. There is no data associated with this value.</summary>
			ASSOCDATA_NOACTIVATEHANDLER,
			/// <summary />
			ASSOCDATA_UNUSED1,
			/// <summary>Defaults to user specified association.</summary>
			ASSOCDATA_HASPERUSERASSOC,
			/// <summary>Internet Explorer version 6 or later. Gets the data stored in the EditFlags value of a file association PROGID registry key. This value consists of one or more FILETYPEATTRIBUTEFLAGS. Compare against those values to determine which attributes have been set.</summary>
			ASSOCDATA_EDITFLAGS,
			/// <summary>Internet Explorer version 6 or later. Uses the parameter from the IQueryAssociations::GetData method as the value name.</summary>
			ASSOCDATA_VALUE,
			/// <summary />
			ASSOCDATA_MAX,
		}

		/// <summary><para>Used by IQueryAssociations::GetEnum to define the type of enum that is to be returned.</para></summary>
		public enum ASSOCENUM
		{
			/// <summary>Nothing.</summary>
			ASSOCENUM_NONE
		}
	}
}
