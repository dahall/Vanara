using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Vanara.PInvoke
{
	public static partial class ShlwApi
	{
		/// <summary>CLSID_QueryAssociations</summary>
		public static readonly Guid CLSID_QueryAssociations = new Guid("a07034fd-6caa-4954-ac3f-97a27216f98a");

		/// <summary>Provides information to the <c>IQueryAssociations</c> interface methods.</summary>
		// typedef enum { ASSOCF_NONE = 0x00000000, ASSOCF_INIT_NOREMAPCLSID = 0x00000001, ASSOCF_INIT_BYEXENAME = 0x00000002,
		// ASSOCF_OPEN_BYEXENAME = 0x00000002, ASSOCF_INIT_DEFAULTTOSTAR = 0x00000004, ASSOCF_INIT_DEFAULTTOFOLDER = 0x00000008,
		// ASSOCF_NOUSERSETTINGS = 0x00000010, ASSOCF_NOTRUNCATE = 0x00000020, ASSOCF_VERIFY = 0x00000040, ASSOCF_REMAPRUNDLL = 0x00000080,
		// ASSOCF_NOFIXUPS = 0x00000100, ASSOCF_IGNOREBASECLASS = 0x00000200, ASSOCF_INIT_IGNOREUNKNOWN = 0x00000400,
		// ASSOCF_INIT_FIXED_PROGID = 0x00000800, ASSOCF_IS_PROTOCOL = 0x00001000, ASSOCF_INIT_FOR_FILE = 0x00002000} ASSOCF; https://msdn.microsoft.com/en-us/library/windows/desktop/bb762471(v=vs.85).aspx
		[Flags]
		[PInvokeData("Shlwapi.h", MSDNShortId = "bb762471")]
		public enum ASSOCF
		{
			/// <summary>None of the following options are set.</summary>
			ASSOCF_NONE = 0x00000000,

			/// <summary>Instructs <c>IQueryAssociations</c> interface methods not to map CLSID values to ProgID values.</summary>
			ASSOCF_INIT_NOREMAPCLSID = 0x00000001,

			/// <summary>
			/// Identifies the value of the pwszAssoc parameter of <c>IQueryAssociations::Init</c> as an executable file name. If this flag
			/// is not set, the root key will be set to the ProgID associated with the <c>.exe</c> key instead of the executable file's ProgID.
			/// </summary>
			ASSOCF_INIT_BYEXENAME = 0x00000002,

			/// <summary>Identical to <c><c>ASSOCF_INIT_BYEXENAME</c></c>.</summary>
			ASSOCF_OPEN_BYEXENAME = 0x00000002,

			/// <summary>
			/// Specifies that when an <c>IQueryAssociations</c> method does not find the requested value under the root key, it should
			/// attempt to retrieve the comparable value from the <c>*</c> subkey.
			/// </summary>
			ASSOCF_INIT_DEFAULTTOSTAR = 0x00000004,

			/// <summary>
			/// Specifies that when a <c>IQueryAssociations</c> method does not find the requested value under the root key, it should
			/// attempt to retrieve the comparable value from the <c>Folder</c> subkey.
			/// </summary>
			ASSOCF_INIT_DEFAULTTOFOLDER = 0x00000008,

			/// <summary>
			/// Specifies that only <c>HKEY_CLASSES_ROOT</c> should be searched, and that <c>HKEY_CURRENT_USER</c> should be ignored.
			/// </summary>
			ASSOCF_NOUSERSETTINGS = 0x00000010,

			/// <summary>
			/// Specifies that the return string should not be truncated. Instead, return an error value and the required size for the
			/// complete string.
			/// </summary>
			ASSOCF_NOTRUNCATE = 0x00000020,

			/// <summary>
			/// Specifies that the return string should not be truncated. Instead, return an error value and the required size for the
			/// complete string.
			/// </summary>
			ASSOCF_VERIFY = 0x00000040,

			/// <summary>
			/// Instructs <c>IQueryAssociations</c> methods to ignore Rundll.exe and return information about its target. Typically
			/// <c>IQueryAssociations</c> methods return information about the first .exe or .dll in a command string. If a command uses
			/// Rundll.exe, setting this flag tells the method to ignore Rundll.exe and return information about its target.
			/// </summary>
			ASSOCF_REMAPRUNDLL = 0x00000080,

			/// <summary>
			/// Instructs <c>IQueryAssociations</c> methods not to fix errors in the registry, such as the friendly name of a function not
			/// matching the one found in the .exe file.
			/// </summary>
			ASSOCF_NOFIXUPS = 0x00000100,

			/// <summary>Specifies that the BaseClass value should be ignored.</summary>
			ASSOCF_IGNOREBASECLASS = 0x00000200,

			/// <summary><c>Introduced in Windows 7</c>. Specifies that the "Unknown" ProgID should be ignored; instead, fail.</summary>
			ASSOCF_INIT_IGNOREUNKNOWN = 0x00000400,

			/// <summary>
			/// <c>Introduced in Windows 8</c>. Specifies that the supplied ProgID should be mapped using the system defaults, rather than
			/// the current user defaults.
			/// </summary>
			ASSOCF_INIT_FIXED_PROGID = 0x00000800,

			/// <summary>
			/// <c>Introduced in Windows 8</c>. Specifies that the value is a protocol, and should be mapped using the current user defaults.
			/// </summary>
			ASSOCF_IS_PROTOCOL = 0x00001000,

			/// <summary>
			/// <c>Introduced in Windows 8.1</c>. Specifies that the ProgID corresponds with a file extension based association. Use together
			/// with <c>ASSOCF_INIT_FIXED_PROGID</c>.
			/// </summary>
			ASSOCF_INIT_FOR_FILE = 0x00002000
		}

		/// <summary>
		/// <para>Specifies the type of key to be returned by IQueryAssociations::GetKey.</para>
		/// </summary>
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

			/// <summary/>
			ASSOCKEY_MAX,
		}

		/// <summary>
		/// <para>Used by IQueryAssociations::GetString to define the type of string that is to be returned.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/ne-shlwapi-assocstr
		[PInvokeData("shlwapi.h", MSDNShortId = "b5fd3d25-3630-4dd8-acd2-d2e4ed571604")]
		public enum ASSOCSTR
		{
			/// <summary>A command string associated with a Shell verb.</summary>
			ASSOCSTR_COMMAND = 1,

			/// <summary>
			/// An executable from a Shell verb command string. For example, this string is found as the (Default) value for a subkey such as
			/// HKEY_CLASSES_ROOT\\shell\Open\command. If the command uses Rundll.exe, set the ASSOCF_REMAPRUNDLL flag in the parameter of
			/// IQueryAssociations::GetString to retrieve the target executable. This type of string will identify the code that will be
			/// invoked in the implementation of the verb.
			/// </summary>
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

			/// <summary>
			/// Corresponds to the InfoTip registry value. Returns an info tip for an item, or list of properties in the form of an
			/// IPropertyDescriptionList from which to create an info tip, such as when hovering the cursor over a file name. The list of
			/// properties can be parsed with PSGetPropertyDescriptionListFromString.
			/// </summary>
			ASSOCSTR_INFOTIP,

			/// <summary>
			/// Introduced in Internet Explorer 6. Corresponds to the QuickTip registry value. Same as ASSOCSTR_INFOTIP, except that it
			/// always returns a list of property names in the form of an IPropertyDescriptionList. The difference between this value and
			/// ASSOCSTR_INFOTIP is that this returns properties that are safe for any scenario that causes slow property retrieval, such as
			/// offline or slow networks. Some of the properties returned from ASSOCSTR_INFOTIP might not be appropriate for slow property
			/// retrieval scenarios. The list of properties can be parsed with PSGetPropertyDescriptionListFromString.
			/// </summary>
			ASSOCSTR_QUICKTIP,

			/// <summary>
			/// Introduced in Internet Explorer 6. Corresponds to the TileInfo registry value. Contains a list of properties to be displayed
			/// for a particular file type in a Windows Explorer window that is in tile view. This is the same as ASSOCSTR_INFOTIP, but, like
			/// ASSOCSTR_QUICKTIP, it also returns a list of property names in the form of an IPropertyDescriptionList. The list of
			/// properties can be parsed with PSGetPropertyDescriptionListFromString.
			/// </summary>
			ASSOCSTR_TILEINFO,

			/// <summary>
			/// Introduced in Internet Explorer 6. Describes a general type of MIME file association, such as image and bmp, so that
			/// applications can make general assumptions about a specific file type.
			/// </summary>
			ASSOCSTR_CONTENTTYPE,

			/// <summary>
			/// Introduced in Internet Explorer 6. Returns the path to the icon resources to use by default for this association. Positive
			/// numbers indicate an index into the dll's resource table, while negative numbers indicate a resource ID. An example of the
			/// syntax for the resource is "c:\myfolder\myfile.dll,-1".
			/// </summary>
			ASSOCSTR_DEFAULTICON,

			/// <summary>
			/// Introduced in Internet Explorer 6. For an object that has a Shell extension associated with it, you can use this to retrieve
			/// the CLSID of that Shell extension object by passing a string representation of the IID of the interface you want to retrieve
			/// as the parameter of IQueryAssociations::GetString. For example, if you want to retrieve a handler that implements the
			/// IExtractImage interface, you would specify "{BB2E617C-0920-11d1-9A0B-00C04FC2D6C1}", which is the IID of IExtractImage.
			/// </summary>
			ASSOCSTR_SHELLEXTENSION,

			/// <summary>
			/// Introduced in Internet Explorer 8.. For a verb invoked through COM and the IDropTarget interface, you can use this flag to
			/// retrieve the IDropTarget object's CLSID. This CLSID is registered in the DropTarget subkey. The verb is specified in the
			/// parameter in the call to IQueryAssociations::GetString. This type of string will identify the code that will be invoked in
			/// the implementation of the verb.
			/// </summary>
			ASSOCSTR_DROPTARGET,

			/// <summary>
			/// Introduced in Internet Explorer 8.. For a verb invoked through COM and the IExecuteCommand interface, you can use this flag
			/// to retrieve the IExecuteCommand object's CLSID. This CLSID is registered in the verb's command subkey as the DelegateExecute
			/// entry. The verb is specified in the parameter in the call to IQueryAssociations::GetString. This type of string will identify
			/// the code that will be invoked in the implementation of the verb.
			/// </summary>
			ASSOCSTR_DELEGATEEXECUTE,

			/// <summary>Introduced in Windows 8.</summary>
			ASSOCSTR_SUPPORTED_URI_PROTOCOLS,

			/// <summary>
			/// The ProgID provided by the app associated with the file type or URI scheme. This if configured by users in their default
			/// program settings.
			/// </summary>
			ASSOCSTR_PROGID,

			/// <summary>
			/// The AppUserModelID of the app associated with the file type or URI scheme. This is configured by users in their default
			/// program settings.
			/// </summary>
			ASSOCSTR_APPID,

			/// <summary>
			/// The publisher of the app associated with the file type or URI scheme. This is configured by users in their default program settings.
			/// </summary>
			ASSOCSTR_APPPUBLISHER,

			/// <summary>
			/// The icon reference of the app associated with the file type or URI scheme. This is configured by users in their default
			/// program settings.
			/// </summary>
			ASSOCSTR_APPICONREFERENCE,

			/// <summary>The maximum defined ASSOCSTR value, used for validation purposes.</summary>
			ASSOCSTR_MAX,
		}

		/// <summary>
		/// <para>Specifies a file's perceived type. This set of constants is used in the AssocGetPerceivedType function.</para>
		/// </summary>
		/// <remarks>
		/// <para>Prior to Windows Vista, this enumeration was declared in Shlwapi.h.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shtypes/ne-shtypes-tagperceived typedef enum tagPERCEIVED {
		// PERCEIVED_TYPE_FIRST , PERCEIVED_TYPE_CUSTOM , PERCEIVED_TYPE_UNSPECIFIED , PERCEIVED_TYPE_FOLDER , PERCEIVED_TYPE_UNKNOWN ,
		// PERCEIVED_TYPE_TEXT , PERCEIVED_TYPE_IMAGE , PERCEIVED_TYPE_AUDIO , PERCEIVED_TYPE_VIDEO , PERCEIVED_TYPE_COMPRESSED ,
		// PERCEIVED_TYPE_DOCUMENT , PERCEIVED_TYPE_SYSTEM , PERCEIVED_TYPE_APPLICATION , PERCEIVED_TYPE_GAMEMEDIA , PERCEIVED_TYPE_CONTACTS
		// , PERCEIVED_TYPE_LAST } PERCEIVED;
		[PInvokeData("shtypes.h", MSDNShortId = "dbaf5894-1ed6-446f-ac15-12ba4c7326e7")]
		public enum PERCEIVED
		{
			/// <summary>The file's perceived type as defined in the registry is not a known type.</summary>
			PERCEIVED_TYPE_CUSTOM = -3,

			/// <summary>The file does not have a perceived type.</summary>
			PERCEIVED_TYPE_UNSPECIFIED = -2,

			/// <summary>Not used.</summary>
			PERCEIVED_TYPE_FOLDER = -1,

			/// <summary>
			/// The file's perceived type hasn't yet been requested. This is the cached type of the object when it is created. This value is
			/// never returned by AssocGetPerceivedType.
			/// </summary>
			PERCEIVED_TYPE_UNKNOWN = 0,

			/// <summary>The file's perceived type is "text".</summary>
			PERCEIVED_TYPE_TEXT = 1,

			/// <summary>The file's perceived type is "image".</summary>
			PERCEIVED_TYPE_IMAGE = 2,

			/// <summary>The file's perceived type is "audio".</summary>
			PERCEIVED_TYPE_AUDIO = 3,

			/// <summary>The file's perceived type is "video".</summary>
			PERCEIVED_TYPE_VIDEO = 4,

			/// <summary>The file's perceived type is "compressed".</summary>
			PERCEIVED_TYPE_COMPRESSED = 5,

			/// <summary>The file's perceived type is "document".</summary>
			PERCEIVED_TYPE_DOCUMENT = 6,

			/// <summary>The file's perceived type is "system".</summary>
			PERCEIVED_TYPE_SYSTEM = 7,

			/// <summary>The file's perceived type is "application".</summary>
			PERCEIVED_TYPE_APPLICATION = 8,

			/// <summary>Windows Vista and later. The file's perceived type is "gamemedia".</summary>
			PERCEIVED_TYPE_GAMEMEDIA = 9,

			/// <summary>Windows Vista and later. The file's perceived type is "contacts"</summary>
			PERCEIVED_TYPE_CONTACTS = 10,
		}

		/// <summary>Indicates the source of the perceived type information.</summary>
		[PInvokeData("shlwapi.h", MSDNShortId = "d37f1574-b261-43bf-9712-05a569ab4246")]
		[Flags]
		public enum PERCEIVEDFLAG : uint
		{
			/// <summary>No perceived type was found (PERCEIVED_TYPE_UNSPECIFIED).</summary>
			PERCEIVEDFLAG_UNDEFINED = 0x0000,

			/// <summary>The perceived type was determined through an association in the registry.</summary>
			PERCEIVEDFLAG_SOFTCODED = 0x0001,

			/// <summary>The perceived type is inherently known to Windows.</summary>
			PERCEIVEDFLAG_HARDCODED = 0x0002,

			/// <summary>The perceived type was determined through a codec provided with Windows.</summary>
			PERCEIVEDFLAG_NATIVESUPPORT = 0x0004,

			/// <summary>The perceived type is supported by the GDI+ library.</summary>
			PERCEIVEDFLAG_GDIPLUS = 0x0010,

			/// <summary>The perceived type is supported by the Windows Media SDK.</summary>
			PERCEIVEDFLAG_WMSDK = 0x0020,

			/// <summary>The perceived type is supported by Windows compressed folders.</summary>
			PERCEIVEDFLAG_ZIPFOLDER = 0x0040,
		}

		/// <summary>
		/// Exposes methods that simplify the process of retrieving information stored in the registry in association with defining a file
		/// type or protocol and associating it with an application.
		/// </summary>
		// https://msdn.microsoft.com/en-us/library/windows/desktop/bb761400(v=vs.85).aspx
		[PInvokeData("Shlwapi.h", MSDNShortId = "bb761400")]
		[ComImport, Guid("c46ca590-3c3f-11d2-bee6-0000f805ca57"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IQueryAssociations
		{
			/// <summary>Initializes the IQueryAssociations interface and sets the root key to the appropriate ProgID.</summary>
			/// <param name="flags">
			/// A flag that specifies how the search is to be initialized. It is typically set to zero, but it can also take one of the
			/// following ASSOCF values.
			/// </param>
			/// <param name="pszAssoc">
			/// A Unicode string that is used to determine the root key. If a value is specified for hkProgid, set this parameter to NULL.
			/// Four types of string can be used:
			/// <list type="bullet">
			/// <item>
			/// <term>File name extension</term>
			/// <description>A file name extension, such as .txt.</description>
			/// </item>
			/// <item>
			/// <term>CLSID</term>
			/// <description>A CLSID GUID in the standard "{GUID}" format.</description>
			/// </item>
			/// <item>
			/// <term>ProgID</term>
			/// <description>An application's ProgID, such as Word.Document.8.</description>
			/// </item>
			/// <item>
			/// <term>Executable name</term>
			/// <description>The name of an application's .exe file. The ASSOCF_OPEN_BYEXENAME flag must be set in flags.</description>
			/// </item>
			/// </list>
			/// </param>
			/// <param name="hkProgid">
			/// The HKEY value of the subkey that is used as a root key. The search looks only below this key. If a value is specified for
			/// pwszAssoc, set this parameter to NULL.
			/// </param>
			/// <param name="hwnd">The HWND.</param>
			void Init(ASSOCF flags, [Optional, MarshalAs(UnmanagedType.LPWStr)] string pszAssoc, [Optional] HKEY hkProgid, [Optional] HWND hwnd);

			/// <summary>Searches for and retrieves a file or protocol association-related string from the registry.</summary>
			/// <param name="flags">A flag that can be used to control the search. It can be any combination of the following ASSOCF values.</param>
			/// <param name="str">An ASSOCSTR value that specifies the type of string that is to be returned.</param>
			/// <param name="pszExtra">
			/// A pointer to an optional, null-terminated Unicode string with information about the location of the string. It is typically
			/// set to a Shell verb such as open. Set this parameter to NULL if it is not used.
			/// </param>
			/// <param name="pszOut">
			/// A pointer to a null-terminated Unicode string used to return the requested string. Set this parameter to NULL to retrieve the
			/// required buffer size.
			/// </param>
			/// <param name="pcchOut">
			/// A pointer to a value that, on entry, is set to the number of characters in the pwszOut buffer. When the function returns
			/// successfully, it points to the number of characters placed in the buffer.
			/// <para>
			/// If the ASSOCF_NOTRUNCATE flag is set in flags and the buffer specified in pwszOut is too small, the function returns
			/// E_POINTER and pcchOut points to the required size of the buffer.
			/// </para>
			/// <para>If pwszOut is NULL, the function returns S_FALSE and pcchOut points to the required size of the buffer.</para>
			/// </param>
			void GetString(ASSOCF flags, ASSOCSTR str, [Optional, MarshalAs(UnmanagedType.LPWStr)] string pszExtra, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszOut, ref uint pcchOut);

			/// <summary>Searches for and retrieves a file or protocol association-related key from the registry.</summary>
			/// <param name="flags">The ASSOCF value that can be used to control the search.</param>
			/// <param name="data">The ASSOCKEY value that specifies the type of key that is to be returned.</param>
			/// <param name="pszExtra">
			/// A pointer to an optional, null-terminated Unicode string with information about the location of the key. It is normally set
			/// to a Shell verb such as open. Set this parameter to NULL if it is not used.
			/// </param>
			/// <param name="phkeyOut">A pointer to the key's HKEY value.</param>
			void GetKey(ASSOCF flags, ASSOCKEY data, [Optional, MarshalAs(UnmanagedType.LPWStr)] string pszExtra, out HKEY phkeyOut);

			/// <summary>Searches for and retrieves file or protocol association-related binary data from the registry.</summary>
			/// <param name="flags">The ASSOCF value that can be used to control the search.</param>
			/// <param name="data">The ASSOCDATA value that specifies the type of data that is to be returned.</param>
			/// <param name="pszExtra">
			/// A pointer to an optional, null-terminated Unicode string with information about the location of the data. It is normally set
			/// to a Shell verb such as open. Set this parameter to NULL if it is not used.
			/// </param>
			/// <param name="pvOut">A pointer to a value that, when this method returns successfully, receives the requested data value.</param>
			/// <param name="pcbOut">
			/// A pointer to a value that, when this method is called, holds the size of pvOut, in bytes. When this method returns
			/// successfully, the value contains the size of the data actually retrieved.
			/// </param>
			void GetData(ASSOCF flags, ASSOCDATA data, [Optional, MarshalAs(UnmanagedType.LPWStr)] string pszExtra, IntPtr pvOut, ref uint pcbOut);

			/// <summary>This method is not implemented.</summary>
			/// <param name="flags">Undocumented.</param>
			/// <param name="assocenum">Undocumented.</param>
			/// <param name="pszExtra">Undocumented.</param>
			/// <param name="riid">Undocumented.</param>
			/// <param name="ppvOut">Undocumented.</param>
			void GetEnum(ASSOCF flags, ASSOCENUM assocenum, [MarshalAs(UnmanagedType.LPWStr)] string pszExtra, in Guid riid, out IntPtr ppvOut);
		}

		/// <summary>Returns a pointer to an IQueryAssociations object.</summary>
		/// <param name="clsid">
		/// <para>Type: <c>CLSID</c></para>
		/// <para>
		/// The CLSID of the object that exposes the interface. This parameter must be set to CLSID_QueryAssociations, which is defined in Shlguid.h.
		/// </para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <c>REFIID</c></para>
		/// <para>Reference to the IID IID_IQueryAssociations, which is defined in Shlguid.h.</para>
		/// </param>
		/// <param name="ppv">
		/// <para>Type: <c>void*</c></para>
		/// <para>When this method returns, contains the IQueryAssociations interface pointer requested in riid.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>As of Windows Vista, AssocCreateForClasses is preferred to <c>AssocCreate</c>.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-assoccreate LWSTDAPI AssocCreate( CLSID clsid, REFIID
		// riid, void **ppv );
		[DllImport(Lib.Shlwapi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("shlwapi.h", MSDNShortId = "33099e0e-73e3-4047-804f-765a59e42e3f")]
		public static extern HRESULT AssocCreate([In] Guid clsid, in Guid riid, out IQueryAssociations ppv);

		/// <summary>Returns a pointer to an IQueryAssociations object.</summary>
		/// <returns>The requested IQueryAssociations interface pointer.</returns>
		public static IQueryAssociations AssocCreate() { AssocCreate(CLSID_QueryAssociations, typeof(IQueryAssociations).GUID, out var qa).ThrowIfFailed(); return qa; }

		/// <summary>
		/// <para>Retrieves a file's perceived type based on its extension.</para>
		/// </summary>
		/// <param name="pszExt">
		/// <para>Type: <c>PCWSTR</c></para>
		/// <para>A pointer to a buffer that contains the file's extension. This should include the leading period, for example ".txt".</para>
		/// </param>
		/// <param name="ptype">
		/// <para>Type: <c>PERCEIVED*</c></para>
		/// <para>A pointer to a PERCEIVED value that indicates the perceived type.</para>
		/// </param>
		/// <param name="pflag">
		/// <para>Type: <c>PERCEIVEDFLAG*</c></para>
		/// <para>A pointer to a value that indicates the source of the perceived type information. One or more of the following values.</para>
		/// <para>PERCEIVEDFLAG_UNDEFINED (0x0000)</para>
		/// <para>No perceived type was found (PERCEIVED_TYPE_UNSPECIFIED).</para>
		/// <para>PERCEIVEDFLAG_SOFTCODED (0x0001)</para>
		/// <para>The perceived type was determined through an association in the registry.</para>
		/// <para>PERCEIVEDFLAG_HARDCODED (0x0002)</para>
		/// <para>The perceived type is inherently known to Windows.</para>
		/// <para>PERCEIVEDFLAG_NATIVESUPPORT (0x0004)</para>
		/// <para>The perceived type was determined through a codec provided with Windows.</para>
		/// <para>PERCEIVEDFLAG_GDIPLUS (0x0010)</para>
		/// <para>The perceived type is supported by the GDI+ library.</para>
		/// <para>PERCEIVEDFLAG_WMSDK (0x0020)</para>
		/// <para>The perceived type is supported by the Windows Media SDK.</para>
		/// <para>PERCEIVEDFLAG_ZIPFOLDER (0x0040)</para>
		/// <para>The perceived type is supported by Windows compressed folders.</para>
		/// </param>
		/// <param name="ppszType">
		/// <para>Type: <c>PWSTR*</c></para>
		/// <para>
		/// If the function returns a success code, this contains the address of a pointer to a buffer that receives the perceived type
		/// string, for instance "text" or "video". This value can be <c>NULL</c>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This function first compares the extension against a hard-coded set of extensions known to Windows. If that search fails to
		/// reveal a match, the registered associations under HKEY_CLASSES_ROOT are searched for a key that matches the extension and
		/// contains a PerceivedType value. If that value is found, the extension set is again searched for a match. If again no match is
		/// found, the perceived type is determined to be PERCEIVED_TYPE_CUSTOM. If either a key that matches the extension or a
		/// PerceivedType value is not found, the perceived type is reported as PERCEIVED_TYPE_UNSPECIFIED.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-assocgetperceivedtype LWSTDAPI AssocGetPerceivedType(
		// PCWSTR pszExt, PERCEIVED *ptype, PERCEIVEDFLAG *pflag, PWSTR *ppszType );
		[DllImport(Lib.Shlwapi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("shlwapi.h", MSDNShortId = "d37f1574-b261-43bf-9712-05a569ab4246")]
		public static extern HRESULT AssocGetPerceivedType([MarshalAs(UnmanagedType.LPWStr)] string pszExt, out PERCEIVED ptype, out PERCEIVEDFLAG pflag, [MarshalAs(UnmanagedType.LPWStr)] ref StringBuilder ppszType);

		/// <summary>
		/// <para>Determines whether a file type is considered a potential security risk.</para>
		/// </summary>
		/// <param name="pszAssoc">
		/// <para>Type: <c>PCWSTR</c></para>
		/// <para>
		/// A pointer to a string that contains the type of file in question. This may be either an extension such as ".exe" or a progid such
		/// as "exefile".
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Returns <c>TRUE</c> if the file type is considered dangerous; otherwise, <c>FALSE</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Files that are determined to be potentially dangerous, such as .exe files, should be handled with more care than other files. For
		/// example, Windows Internet Explorer version 6.01 or later uses <c>AssocIsDangerous</c> to determine whether it should issue
		/// stronger warning language in its download dialog box. ShellExecuteEx uses <c>AssocIsDangerous</c> to trigger zone checking using
		/// the methods of the IInternetSecurityManager interface in conjunction with the URLACTION_SHELL_SHELLEXECUTE flag.
		/// </para>
		/// <para>
		/// The determination of a file's potential risk is made by checking its type against several sources, including a list of known
		/// dangerous types and the presence of the FTA_AlwaysUnsafe flag in the registry. On systems running Windows XPService Pack 1 (SP1)
		/// or later or Windows Server 2003, it also uses the SaferiIsExecutableFileType function to determine whether a file type is executable.
		/// </para>
		/// <para>
		/// Applications that can take advantage of <c>AssocIsDangerous</c> include email programs, browsers, chat clients capable of
		/// downloading files, and any application that moves files or data from one zone of trust to another.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-associsdangerous BOOL AssocIsDangerous( PCWSTR pszAssoc );
		[DllImport(Lib.Shlwapi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("shlwapi.h", MSDNShortId = "4e0bc3ce-f9d2-4766-8b19-c0954d71e890")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool AssocIsDangerous([MarshalAs(UnmanagedType.LPWStr)] string pszAssoc);

		/// <summary>
		/// <para>Searches for and retrieves a key related to a file or protocol association from the registry.</para>
		/// </summary>
		/// <param name="flags">
		/// <para>Type: <c>ASSOCF</c></para>
		/// <para>
		/// The flags that can be used to control the search. It can be any combination of ASSOCF values, except that only one ASSOCF_INIT
		/// value can be included.
		/// </para>
		/// </param>
		/// <param name="key">
		/// <para>Type: <c>ASSOCKEY</c></para>
		/// <para>The ASSOCKEY value that specifies the type of key that is to be returned.</para>
		/// </param>
		/// <param name="pszAssoc">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>A pointer to a null-terminated string that is used to determine the root key. Four types of strings can be used.</para>
		/// <para>File name extension</para>
		/// <para>A file name extension, such as .txt.</para>
		/// <para>CLSID</para>
		/// <para>A CLSID GUID in the standard "{GUID}" format.</para>
		/// <para>ProgID</para>
		/// <para>An application's ProgID, such as <c>Word.Document.8</c>.</para>
		/// <para>Executable name</para>
		/// <para>The name of an application's .exe file. The ASSOCF_OPEN_BYEXENAME flag must be set in flags.</para>
		/// </param>
		/// <param name="pszExtra">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>
		/// A pointer to an optional null-terminated string with additional information about the location of the string. It is normally set
		/// to a Shell verb such as <c>open</c>. Set this parameter to <c>NULL</c> if it is not used.
		/// </para>
		/// </param>
		/// <param name="phkeyOut">
		/// <para>Type: <c>HKEY*</c></para>
		/// <para>A pointer to the key's HKEY value.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns S_OK if successful, or a COM error value otherwise.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This function is a wrapper for the IQueryAssociations interface. It is intended to simplify the process of using the interface.
		/// For further discussion of how the file and protocol association functions work, see <c>IQueryAssociations</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-assocquerykeya LWSTDAPI AssocQueryKeyA( ASSOCF flags,
		// ASSOCKEY key, LPCSTR pszAssoc, LPCSTR pszExtra, HKEY *phkeyOut );
		[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shlwapi.h", MSDNShortId = "9eaeb885-0428-48c3-82a7-5dc21d5015ce")]
		public static extern HRESULT AssocQueryKey(ASSOCF flags, ASSOCKEY key, string pszAssoc, string pszExtra, out HKEY phkeyOut);

		/// <summary>
		/// <para>Searches for and retrieves a file or protocol association-related string from the registry.</para>
		/// </summary>
		/// <param name="flags">
		/// <para>Type: <c>ASSOCF</c></para>
		/// <para>
		/// The flags that can be used to control the search. It can be any combination of ASSOCF values, except that only one ASSOCF_INIT
		/// value can be included.
		/// </para>
		/// </param>
		/// <param name="str">
		/// <para>Type: <c>ASSOCSTR</c></para>
		/// <para>The ASSOCSTR value that specifies the type of string that is to be returned.</para>
		/// </param>
		/// <param name="pszAssoc">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>
		/// A pointer to a null-terminated string that is used to determine the root key. The following four types of strings can be used.
		/// </para>
		/// <para>File name extension</para>
		/// <para>A file name extension, such as .txt.</para>
		/// <para>CLSID</para>
		/// <para>A CLSID GUID in the standard "{GUID}" format.</para>
		/// <para>ProgID</para>
		/// <para>An application's ProgID, such as <c>Word.Document.8</c>.</para>
		/// <para>Executable name</para>
		/// <para>The name of an application's .exe file. The ASSOCF_OPEN_BYEXENAME flag must be set in flags.</para>
		/// </param>
		/// <param name="pszExtra">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>
		/// An optional null-terminated string with additional information about the location of the string. It is typically set to a Shell
		/// verb such as <c>open</c>. Set this parameter to <c>NULL</c> if it is not used.
		/// </para>
		/// </param>
		/// <param name="pszOut">
		/// <para>Type: <c>LPTSTR</c></para>
		/// <para>
		/// Pointer to a null-terminated string that, when this function returns successfully, receives the requested string. Set this
		/// parameter to <c>NULL</c> to retrieve the required buffer size.
		/// </para>
		/// </param>
		/// <param name="pcchOut">
		/// <para>Type: <c>DWORD*</c></para>
		/// <para>
		/// A pointer to a value that, when calling the function, is set to the number of characters in the pszOut buffer. When the function
		/// returns successfully, the value is set to the number of characters actually placed in the buffer.
		/// </para>
		/// <para>
		/// If the ASSOCF_NOTRUNCATE flag is set in flags and the buffer specified in pszOut is too small, the function returns E_POINTER and
		/// the value is set to the required size of the buffer.
		/// </para>
		/// <para>
		/// If pszOut is <c>NULL</c>, the function returns S_FALSE and pcchOut points to the required size, in characters, of the buffer.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns a standard COM error value, including the following:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Error</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Success.</term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>The pszOut buffer is too small to hold the entire string.</term>
		/// </item>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>pszOut is NULL. pcchOut contains the required buffer size.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This function is a wrapper for the IQueryAssociations interface. The <c>AssocQueryString</c> function is intended to simplify the
		/// process of using <c>IQueryAssociations</c> interface.
		/// </para>
		/// <para>
		/// Once an item is selected, the host must decide which (if any) preview handler is available for that item. Preview handlers are
		/// typically registered on file name extensions or ProgID, but some preview handlers are only instantiated for items within
		/// particular shell folders (the MAPI preview handler is associated with any items that came from the MAPI Shell folder, for
		/// example). Thus, the host must use IQueryAssociations to determine which preview handler to use. For further discussion of how the
		/// file and protocol association functions work, see IQueryAssociations.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shlwapi/nf-shlwapi-assocquerystringa LWSTDAPI AssocQueryStringA( ASSOCF
		// flags, ASSOCSTR str, LPCSTR pszAssoc, LPCSTR pszExtra, LPSTR pszOut, DWORD *pcchOut );
		[DllImport(Lib.Shlwapi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("shlwapi.h", MSDNShortId = "026b841d-b831-475e-a788-2c79801e20b8")]
		public static extern HRESULT AssocQueryString(ASSOCF flags, ASSOCSTR str, string pszAssoc, string pszExtra, StringBuilder pszOut, ref uint pcchOut);
	}
}