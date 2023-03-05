using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace Vanara.PInvoke;

public static partial class Kernel32
{
	/// <summary>
	/// An application-defined callback function used with the <c>EnumResourceLanguages</c> and <c>EnumResourceLanguagesEx</c> functions.
	/// It receives the type, name, and language of a resource item. The <c>ENUMRESLANGPROC</c> type defines a pointer to this callback
	/// function. EnumResLangProc is a placeholder for the application-defined function name.
	/// </summary>
	/// <param name="hModule">
	/// <para>Type: <c>HMODULE</c></para>
	/// <para>
	/// A handle to the module whose executable file contains the resources for which the languages are being enumerated. If this
	/// parameter is <c>NULL</c>, the function enumerates the resource languages in the module used to create the current process.
	/// </para>
	/// </param>
	/// <param name="lpszType">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>
	/// The type of resource for which the language is being enumerated. Alternately, rather than a pointer, this parameter can be ,
	/// where ID is an integer value representing a predefined resource type. For standard resource types, see Resource Types. For more
	/// information, see the Remarks section below.
	/// </para>
	/// </param>
	/// <param name="lpszName">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>
	/// The name of the resource for which the language is being enumerated. Alternately, rather than a pointer, this parameter can be
	/// <c>MAKEINTRESOURCE</c>(ID), where ID is the integer identifier of the resource. For more information, see the Remarks section below.
	/// </para>
	/// </param>
	/// <param name="wIDLanguage">
	/// <para>Type: <c>WORD</c></para>
	/// <para>
	/// The language identifier for the resource for which the language is being enumerated. The <c>EnumResourceLanguages</c> or
	/// <c>EnumResourceLanguagesEx</c> function provides this value. For a list of the primary language identifiers and sublanguage
	/// identifiers that constitute a language identifier, see <c>MAKELANGID</c>.
	/// </para>
	/// </param>
	/// <param name="lParam">
	/// <para>Type: <c>LONG_PTR</c></para>
	/// <para>
	/// The application-defined parameter passed to the <c>EnumResourceLanguages</c> or <c>EnumResourceLanguagesEx</c> function. This
	/// parameter can be used in error checking.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>Returns <c>TRUE</c> to continue enumeration or <c>FALSE</c> to stop enumeration.</para>
	/// </returns>
	// BOOL CALLBACK EnumResLangProc( _In_opt_ HMODULE hModule, _In_ LPCTSTR lpszType, _In_ LPCTSTR lpszName, _In_ WORD wIDLanguage, _In_
	// LONG_PTR lParam); https://msdn.microsoft.com/en-us/library/windows/desktop/ms648033(v=vs.85).aspx
	[PInvokeData("Winbase.h", MSDNShortId = "ms648033")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Unicode)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public delegate bool EnumResLangProc([In] HINSTANCE hModule, [In] ResourceId lpszType, [In] ResourceId lpszName, ushort wIDLanguage, [In] IntPtr lParam);

	/// <summary>
	/// An application-defined callback function used with the <c>EnumResourceNames</c> and <c>EnumResourceNamesEx</c> functions. It
	/// receives the type and name of a resource. The <c>ENUMRESNAMEPROC</c> type defines a pointer to this callback function.
	/// EnumResNameProc is a placeholder for the application-defined function name.
	/// </summary>
	/// <param name="hModule">
	/// <para>Type: <c>HMODULE</c></para>
	/// <para>
	/// A handle to the module whose executable file contains the resources that are being enumerated. If this parameter is <c>NULL</c>,
	/// the function enumerates the resource names in the module used to create the current process.
	/// </para>
	/// </param>
	/// <param name="lpszType">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>
	/// The type of resource for which the name is being enumerated. Alternately, rather than a pointer, this parameter can be , where ID
	/// is an integer value representing a predefined resource type. For standard resource types, see Resource Types. For more
	/// information, see the Remarks section below.
	/// </para>
	/// </param>
	/// <param name="lpszName">
	/// <para>Type: <c>LPTSTR</c></para>
	/// <para>
	/// The name of a resource of the type being enumerated. Alternately, rather than a pointer, this parameter can be , where ID is the
	/// integer identifier of the resource. For more information, see the Remarks section below.
	/// </para>
	/// </param>
	/// <param name="lParam">
	/// <para>Type: <c>LONG_PTR</c></para>
	/// <para>
	/// An application-defined parameter passed to the <c>EnumResourceNames</c> or <c>EnumResourceNamesEx</c> function. This parameter
	/// can be used in error checking.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>Returns <c>TRUE</c> to continue enumeration or <c>FALSE</c> to stop enumeration.</para>
	/// </returns>
	// BOOL CALLBACK EnumResNameProc( _In_opt_ HMODULE hModule, _In_ LPCTSTR lpszType, _In_ LPTSTR lpszName, _In_ LONG_PTR lParam); https://msdn.microsoft.com/en-us/library/windows/desktop/ms648034(v=vs.85).aspx
	[UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Unicode)]
	[SuppressUnmanagedCodeSecurity]
	[PInvokeData("Winbase.h", MSDNShortId = "ms648034")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public delegate bool EnumResNameProc(HINSTANCE hModule, ResourceId lpszType, ResourceId lpszName, IntPtr lParam);

	/// <summary>
	/// An application-defined callback function used with the <c>EnumResourceTypes</c> and <c>EnumResourceTypesEx</c> functions. It
	/// receives resource types. The <c>ENUMRESTYPEPROC</c> type defines a pointer to this callback function. EnumResTypeProc is a
	/// placeholder for the application-defined function name.
	/// </summary>
	/// <param name="hModule">
	/// <para>Type: <c>HMODULE</c></para>
	/// <para>
	/// A handle to the module whose executable file contains the resources for which the types are to be enumerated. If this parameter
	/// is <c>NULL</c>, the function enumerates the resource types in the module used to create the current process.
	/// </para>
	/// </param>
	/// <param name="lpszType">
	/// <para>Type: <c>LPTSTR</c></para>
	/// <para>
	/// The type of resource for which the type is being enumerated. Alternately, rather than a pointer, this parameter can be
	/// <c>MAKEINTRESOURCE</c>(ID), where ID is the integer identifier of the given resource type. For standard resource types, see
	/// Resource Types. For more information, see the Remarks section below.
	/// </para>
	/// </param>
	/// <param name="lParam">
	/// <para>Type: <c>LONG_PTR</c></para>
	/// <para>
	/// An application-defined parameter passed to the <c>EnumResourceTypes</c> or <c>EnumResourceTypesEx</c> function. This parameter
	/// can be used in error checking.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>Returns <c>TRUE</c> to continue enumeration or <c>FALSE</c> to stop enumeration.</para>
	/// </returns>
	// BOOL CALLBACK EnumResTypeProc( _In_opt_ HMODULE hModule, _In_ LPTSTR lpszType, _In_ LONG_PTR lParam); https://msdn.microsoft.com/en-us/library/windows/desktop/ms648041(v=vs.85).aspx
	[UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Unicode)]
	[PInvokeData("Winbase.h", MSDNShortId = "ms648041")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public delegate bool EnumResTypeProc(HINSTANCE hModule, ResourceId lpszType, IntPtr lParam);

	/// <summary>Flags used by <see cref="GetModuleHandleEx(GET_MODULE_HANDLE_EX_FLAG, IntPtr, out SafeHINSTANCE)"/>.</summary>
	[PInvokeData("Winbase.h", MSDNShortId = "ms683200")]
	[Flags]
	public enum GET_MODULE_HANDLE_EX_FLAG
	{
		/// <summary>The lpModuleName parameter is an address in the module.</summary>
		GET_MODULE_HANDLE_EX_FLAG_PIN = 0x00000001,

		/// <summary>
		/// The module stays loaded until the process is terminated, no matter how many times FreeLibrary is called.
		/// <para>This option cannot be used with GET_MODULE_HANDLE_EX_FLAG_UNCHANGED_REFCOUNT.</para>
		/// </summary>
		GET_MODULE_HANDLE_EX_FLAG_UNCHANGED_REFCOUNT = 0x00000002,

		/// <summary>
		/// The reference count for the module is not incremented. This option is equivalent to the behavior of GetModuleHandle. Do not
		/// pass the retrieved module handle to the FreeLibrary function; doing so can cause the DLL to be unmapped prematurely. For more
		/// information, see Remarks.
		/// <para>This option cannot be used with GET_MODULE_HANDLE_EX_FLAG_PIN.</para>
		/// </summary>
		GET_MODULE_HANDLE_EX_FLAG_FROM_ADDRESS = 0x00000004,
	}

	/// <summary>Flags that may be passed to the <see cref="LoadLibraryEx(string, IntPtr, LoadLibraryExFlags)"/> function.</summary>
	[PInvokeData("libloaderapi.h")]
	[Flags]
	public enum LoadLibraryExFlags
	{
		/// <summary>Define no flags, the function will behave as <see cref="LoadLibrary"/> does.</summary>
		None = 0,

		/// <summary>
		/// If this value is used, and the executable module is a DLL, the system does not call DllMain for process and thread
		/// initialization and termination. Also, the system does not load additional executable modules that are referenced by the
		/// specified module.
		/// </summary>
		/// <remarks>
		/// Do not use this value; it is provided only for backward compatibility. If you are planning to access only data or resources
		/// in the DLL, use <see cref="LOAD_LIBRARY_AS_DATAFILE_EXCLUSIVE"/> or <see cref="LOAD_LIBRARY_AS_IMAGE_RESOURCE"/> or both.
		/// Otherwise, load the library as a DLL or executable module using the LoadLibrary function.
		/// </remarks>
		DONT_RESOLVE_DLL_REFERENCES = 0x00000001,

		/// <summary>
		/// If this value is used, the system does not check AppLocker rules or apply Software Restriction Policies for the DLL. This
		/// action applies only to the DLL being loaded and not to its dependencies. This value is recommended for use in setup programs
		/// that must run extracted DLLs during installation.
		/// </summary>
		/// <remarks>
		/// <para>
		/// Windows Server 2008 R2 and Windows 7: On systems with KB2532445 installed, the caller must be running as "LocalSystem" or
		/// "TrustedInstaller"; otherwise the system ignores this flag. For more information, see "You can circumvent AppLocker rules by
		/// using an Office macro on a computer that is running Windows 7 or Windows Server 2008 R2" in the Help and Support Knowledge
		/// Base at http://support.microsoft.com/kb/2532445.
		/// </para>
		/// <para>
		/// Windows Server 2008, Windows Vista, Windows Server 2003, and Windows XP: AppLocker was introduced in Windows 7 and Windows
		/// Server 2008 R2.
		/// </para>
		/// </remarks>
		LOAD_IGNORE_CODE_AUTHZ_LEVEL = 0x00000010,

		/// <summary>
		/// If this value is used, the system maps the file into the calling process's virtual address space as if it were a data file.
		/// Nothing is done to execute or prepare to execute the mapped file. Therefore, you cannot call functions like
		/// GetModuleFileName, GetModuleHandle or GetProcAddress with this DLL. Using this value causes writes to read-only memory to
		/// raise an access violation. Use this flag when you want to load a DLL only to extract messages or resources from it.
		/// <para>This value can be used with <see cref="LOAD_LIBRARY_AS_IMAGE_RESOURCE"/>.</para>
		/// </summary>
		LOAD_LIBRARY_AS_DATAFILE = 0x00000002,

		/// <summary>
		/// Similar to <see cref="LOAD_LIBRARY_AS_DATAFILE"/>, except that the DLL file is opened with exclusive write access for the
		/// calling process. Other processes cannot open the DLL file for write access while it is in use. However, the DLL can still be
		/// opened by other processes.
		/// <para>This value can be used with <see cref="LOAD_LIBRARY_AS_IMAGE_RESOURCE"/>.</para>
		/// </summary>
		/// <remarks>Windows Server 2003 and Windows XP: This value is not supported until Windows Vista.</remarks>
		LOAD_LIBRARY_AS_DATAFILE_EXCLUSIVE = 0x00000040,

		/// <summary>
		/// If this value is used, the system maps the file into the process's virtual address space as an image file. However, the
		/// loader does not load the static imports or perform the other usual initialization steps. Use this flag when you want to load
		/// a DLL only to extract messages or resources from it.
		/// <para>
		/// Unless the application depends on the file having the in-memory layout of an image, this value should be used with either
		/// <see cref="LOAD_LIBRARY_AS_DATAFILE_EXCLUSIVE"/> or <see cref="LOAD_LIBRARY_AS_DATAFILE"/>. For more information, see the
		/// Remarks section.
		/// </para>
		/// </summary>
		LOAD_LIBRARY_AS_IMAGE_RESOURCE = 0x00000020,

		/// <summary>
		/// If this value is used, the application's installation directory is searched for the DLL and its dependencies. Directories in
		/// the standard search path are not searched. This value cannot be combined with <see cref="LOAD_WITH_ALTERED_SEARCH_PATH"/>.
		/// </summary>
		/// <remarks>
		/// Windows 7, Windows Server 2008 R2, Windows Vista, and Windows Server 2008: This value requires KB2533623 to be installed.
		/// <para>Windows Server 2003 and Windows XP: This value is not supported.</para>
		/// </remarks>
		LOAD_LIBRARY_SEARCH_APPLICATION_DIR = 0x00000200,

		/// <summary>
		/// This value is a combination of <see cref="LOAD_LIBRARY_SEARCH_APPLICATION_DIR"/>, <see cref="LOAD_LIBRARY_SEARCH_SYSTEM32"/>,
		/// and <see cref="LOAD_LIBRARY_SEARCH_USER_DIRS"/>. Directories in the standard search path are not searched. This value cannot
		/// be combined with <see cref="LOAD_WITH_ALTERED_SEARCH_PATH"/>.
		/// <para>
		/// This value represents the recommended maximum number of directories an application should include in its DLL search path.
		/// </para>
		/// </summary>
		/// <remarks>
		/// Windows 7, Windows Server 2008 R2, Windows Vista, and Windows Server 2008: This value requires KB2533623 to be installed.
		/// <para>Windows Server 2003 and Windows XP: This value is not supported.</para>
		/// </remarks>
		LOAD_LIBRARY_SEARCH_DEFAULT_DIRS = 0x00001000,

		/// <summary>
		/// If this value is used, the directory that contains the DLL is temporarily added to the beginning of the list of directories
		/// that are searched for the DLL's dependencies. Directories in the standard search path are not searched.
		/// <para>The lpFileName parameter must specify a fully qualified path. This value cannot be combined with <see cref="LOAD_WITH_ALTERED_SEARCH_PATH"/>.</para>
		/// <para>
		/// For example, if Lib2.dll is a dependency of C:\Dir1\Lib1.dll, loading Lib1.dll with this value causes the system to search
		/// for Lib2.dll only in C:\Dir1. To search for Lib2.dll in C:\Dir1 and all of the directories in the DLL search path, combine
		/// this value with <see cref="LOAD_LIBRARY_SEARCH_DEFAULT_DIRS"/>.
		/// </para>
		/// </summary>
		/// <remarks>
		/// Windows 7, Windows Server 2008 R2, Windows Vista, and Windows Server 2008: This value requires KB2533623 to be installed.
		/// <para>Windows Server 2003 and Windows XP: This value is not supported.</para>
		/// </remarks>
		LOAD_LIBRARY_SEARCH_DLL_LOAD_DIR = 0x00000100,

		/// <summary>
		/// If this value is used, %windows%\system32 is searched for the DLL and its dependencies. Directories in the standard search
		/// path are not searched. This value cannot be combined with <see cref="LOAD_WITH_ALTERED_SEARCH_PATH"/>.
		/// </summary>
		/// <remarks>
		/// Windows 7, Windows Server 2008 R2, Windows Vista, and Windows Server 2008: This value requires KB2533623 to be installed.
		/// <para>Windows Server 2003 and Windows XP: This value is not supported.</para>
		/// </remarks>
		LOAD_LIBRARY_SEARCH_SYSTEM32 = 0x00000800,

		/// <summary>
		/// If this value is used, directories added using the AddDllDirectory or the SetDllDirectory function are searched for the DLL
		/// and its dependencies. If more than one directory has been added, the order in which the directories are searched is
		/// unspecified. Directories in the standard search path are not searched. This value cannot be combined with <see cref="LOAD_WITH_ALTERED_SEARCH_PATH"/>.
		/// </summary>
		/// <remarks>
		/// Windows 7, Windows Server 2008 R2, Windows Vista, and Windows Server 2008: This value requires KB2533623 to be installed.
		/// <para>Windows Server 2003 and Windows XP: This value is not supported.</para>
		/// </remarks>
		LOAD_LIBRARY_SEARCH_USER_DIRS = 0x00000400,

		/// <summary>
		/// If this value is used and lpFileName specifies an absolute path, the system uses the alternate file search strategy discussed
		/// in the Remarks section to find associated executable modules that the specified module causes to be loaded. If this value is
		/// used and lpFileName specifies a relative path, the behavior is undefined.
		/// <para>
		/// If this value is not used, or if lpFileName does not specify a path, the system uses the standard search strategy discussed
		/// in the Remarks section to find associated executable modules that the specified module causes to be loaded.
		/// </para>
		/// <para>This value cannot be combined with any LOAD_LIBRARY_SEARCH flag.</para>
		/// </summary>
		LOAD_WITH_ALTERED_SEARCH_PATH = 0x00000008
	}

	/// <summary>The type of file to search.</summary>
	[Flags]
	public enum RESOURCE_ENUM_FLAGS
	{
		/// <summary>
		/// Searches the file specified by hModule, regardless of whether the file is an LN file, another type of LN file, or an .mui file.
		/// </summary>
		RESOURCE_ENUM_LN = 0x0001,

		/// <summary>
		/// Search for resources in .mui files associated with the LN file specified by hModule and with the current language
		/// preferences, following the usual Resource Loader strategy (see User Interface Language Management). Alternately, if LangId is
		/// nonzero, then only the specified .mui file will be searched. Typically this flag should be used only if hModule references an
		/// LN file. If hModule references an .mui file, then that file is actually covered by the RESOURCE_ENUM_LN flag, despite the
		/// name of the flag.
		/// </summary>
		RESOURCE_ENUM_MUI = 0x0002,

		/// <summary>Restricts the .mui files search to system-installed MUI languages.</summary>
		RESOURCE_ENUM_MUI_SYSTEM = 0x0004,

		/// <summary>
		/// Performs extra validation on the resource section and its reference in the PE header while doing the enumeration to ensure
		/// that resources are properly formatted. The validation sets a maximum limit of 260 characters for each name that is enumerated.
		/// </summary>
		RESOURCE_ENUM_VALIDATE = 0x0008,

		/// <summary>Undocumented.</summary>
		RESOURCE_ENUM_MODULE_EXACT = 0x0010,
	}

	/// <summary>Flags specifying details of the find operation.</summary>
	public enum SEARCH_FLAGS
	{
		/// <summary>
		/// Test to find out if the value specified by lpStringValue is the first value in the source string indicated by lpStringSource.
		/// </summary>
		FIND_STARTSWITH = 0x00100000,

		/// <summary>
		/// Test to find out if the value specified by lpStringValue is the last value in the source string indicated by lpStringSource.
		/// </summary>
		FIND_ENDSWITH = 0x00200000,

		/// <summary>Search the string, starting with the first character of the string.</summary>
		FIND_FROMSTART = 0x00400000,

		/// <summary>Search the string in the reverse direction, starting with the last character of the string.</summary>
		FIND_FROMEND = 0x00800000,
	}

	/// <summary>Adds a directory to the process DLL search path.</summary>
	/// <param name="NewDirectory">
	/// An absolute path to the directory to add to the search path. For example, to add the directory Dir2 to the process DLL search
	/// path, specify \Dir2. For more information about paths, see Naming Files, Paths, and Namespaces.
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is an opaque pointer that can be passed to <c>RemoveDllDirectory</c> to remove the DLL
	/// from the process DLL search path.
	/// </para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// DLL_DIRECTORY_COOKIE WINAPI AddDllDirectory( _In_ PCWSTR NewDirectory); https://msdn.microsoft.com/en-us/library/windows/desktop/hh310513(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("LibLoaderAPI.h", MSDNShortId = "hh310513")]
	public static extern IntPtr AddDllDirectory(string NewDirectory);

	/// <summary>
	/// Disables the DLL_THREAD_ATTACH and DLL_THREAD_DETACH notifications for the specified dynamic-link library (DLL). This can reduce
	/// the size of the working set for some applications.
	/// </summary>
	/// <param name="hModule">
	/// A handle to the DLL module for which the DLL_THREAD_ATTACH and DLL_THREAD_DETACH notifications are to be disabled. The
	/// <c>LoadLibrary</c>, <c>LoadLibraryEx</c>, or <c>GetModuleHandle</c> function returns this handle. Note that you cannot call
	/// <c>GetModuleHandle</c> with NULL because this returns the base address of the executable image, not the DLL image.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>
	/// If the function fails, the return value is zero. The <c>DisableThreadLibraryCalls</c> function fails if the DLL specified by
	/// hModule has active static thread local storage, or if hModule is an invalid module handle. To get extended error information,
	/// call <c>GetLastError</c>.
	/// </para>
	/// </returns>
	// BOOL WINAPI DisableThreadLibraryCalls( _In_ HMODULE hModule); https://msdn.microsoft.com/en-us/library/windows/desktop/ms682579(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("Winbase.h", MSDNShortId = "ms682579")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DisableThreadLibraryCalls([In] HINSTANCE hModule);

	/// <summary>Enumerates language-specific resources, of the specified type and name, associated with a binary module.</summary>
	/// <param name="hModule">
	/// <para>Type: <c>HMODULE</c></para>
	/// <para>
	/// The handle to a module to be searched. Starting with Windows Vista, if this is a language-neutral Portable Executable (LN file),
	/// then appropriate .mui files (if any exist) are included in the search. If this is a specific .mui file, only that file is
	/// searched for resources.
	/// </para>
	/// <para>If this parameter is <c>NULL</c>, that is equivalent to passing in a handle to the module used to create the current process.</para>
	/// </param>
	/// <param name="lpType">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>
	/// The type of resource for which the language is being enumerated. Alternately, rather than a pointer, this parameter can be
	/// <c>MAKEINTRESOURCE</c>(ID), where ID is an integer value representing a predefined resource type. For a list of predefined
	/// resource types, see Resource Types. For more information, see the Remarks section below.
	/// </para>
	/// </param>
	/// <param name="lpName">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>
	/// The name of the resource for which the language is being enumerated. Alternately, rather than a pointer, this parameter can be
	/// <c>MAKEINTRESOURCE</c>(ID), where ID is the integer identifier of the resource. For more information, see the Remarks section below.
	/// </para>
	/// </param>
	/// <param name="lpEnumFunc">
	/// <para>Type: <c>ENUMRESLANGPROC</c></para>
	/// <para>A pointer to the callback function to be called for each enumerated resource language. For more information, see EnumResLangProc.</para>
	/// </param>
	/// <param name="lParam">
	/// <para>Type: <c>LONG_PTR</c></para>
	/// <para>An application-defined value passed to the callback function. This parameter can be used in error checking.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>Returns <c>TRUE</c> if successful or <c>FALSE</c> otherwise. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// BOOL WINAPI EnumResourceLanguages( _In_ HMODULE hModule, _In_ LPCTSTR lpType, _In_ LPCTSTR lpName, _In_ ENUMRESLANGPROC
	// lpEnumFunc, _In_ LONG_PTR lParam); https://msdn.microsoft.com/en-us/library/windows/desktop/ms648035(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Unicode, EntryPoint = "EnumResourceLanguagesW")]
	[PInvokeData("Winbase.h", MSDNShortId = "ms648035")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool EnumResourceLanguages([In] HINSTANCE hModule, [In] SafeResourceId lpType, [In] SafeResourceId lpName, EnumResLangProc lpEnumFunc, [In, Optional] IntPtr lParam);

	/// <summary>
	/// Enumerates language-specific resources, of the specified type and name, associated with a specified binary module. Extends
	/// <c>EnumResourceLanguages</c> by allowing more control over the enumeration.
	/// </summary>
	/// <param name="hModule">
	/// <para>Type: <c>HMODULE</c></para>
	/// <para>
	/// The handle to a module to search. Typically this is a language-neutral Portable Executable (LN file), and if flag
	/// <c>RESOURCE_ENUM_MUI</c> is set, then appropriate .mui files are included in the search. Alternately, this can be a handle to an
	/// .mui file or other LN file. If this is a specific .mui file, only that file is searched for resources.
	/// </para>
	/// <para>If this parameter is <c>NULL</c>, it is equivalent to passing in a handle to the module used to create the current process.</para>
	/// </param>
	/// <param name="lpType">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>
	/// The type of the resource for which the language is being enumerated. Alternately, rather than a pointer, this parameter can be
	/// <c>MAKEINTRESOURCE</c>(ID), where ID is an integer value representing a predefined resource type. For a list of predefined
	/// resource types, see Resource Types. For more information, see the Remarks section below.
	/// </para>
	/// </param>
	/// <param name="lpName">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>
	/// The name of the resource for which the language is being enumerated. Alternately, rather than a pointer, this parameter can be
	/// <c>MAKEINTRESOURCE</c>(ID), where ID is the integer identifier of the resource. For more information, see the Remarks section below.
	/// </para>
	/// </param>
	/// <param name="lpEnumFunc">
	/// <para>Type: <c>ENUMRESLANGPROC</c></para>
	/// <para>A pointer to the callback function to be called for each enumerated resource language. For more information, see EnumResLangProc.</para>
	/// </param>
	/// <param name="lParam">
	/// <para>Type: <c>LONG_PTR</c></para>
	/// <para>An application-defined value passed to the callback function. This parameter can be used in error checking.</para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>
	/// The type of file to be searched. The following values are supported. Note that if dwFlags is zero, then the
	/// <c>RESOURCE_ENUM_LN</c> and <c>RESOURCE_ENUM_MUI</c> flags are assumed to be specified.
	/// </para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>RESOURCE_ENUM_MUI0x0002</term>
	/// <term>
	/// Search for language-specific resources in .mui files associated with the LN file specified by hModule. Alternately, if LangId is
	/// nonzero, the only .mui file searched will be the one matching the specified LangId. Typically this flag should be used only if
	/// hModule references an LN file. If hModule references an .mui file, then that file is actually covered by the RESOURCE_LN flag,
	/// despite the name of the flag. See the Remarks section below for sequence of search.
	/// </term>
	/// </item>
	/// <item>
	/// <term>RESOURCE_ENUM_LN0x0001</term>
	/// <term>
	/// Searches the file specified by hModule, regardless of whether the file is an LN file, another type of LN file, or an .mui file.
	/// </term>
	/// </item>
	/// <item>
	/// <term>RESOURCE_ENUM_MUI_SYSTEM0x0004</term>
	/// <term>Restricts the .mui files search to system-installed MUI languages.</term>
	/// </item>
	/// <item>
	/// <term>RESOURCE_ENUM_VALIDATE0x0008</term>
	/// <term>
	/// Performs extra validation on the resource section and its reference in the PE header while doing the enumeration to ensure that
	/// resources are properly formatted.
	/// </term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <param name="LangId">
	/// <para>Type: <c>LANGID</c></para>
	/// <para>
	/// The localization language used to filter the search in the .mui file. This parameter is used only when the
	/// <c>RESOURCE_ENUM_MUI</c> flag is set in dwFlags. If zero is specified, then all .mui files are included in the search. If a
	/// nonzero LangId is specified, then the only .mui file searched will be the one matching the specified LangId.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>
	/// Returns <c>TRUE</c> if the function succeeds or <c>FALSE</c> if the function does not find a resource of the type specified, or
	/// if the function fails for another reason. To get extended error information, call <c>GetLastError</c>.
	/// </para>
	/// </returns>
	// BOOL WINAPI EnumResourceLanguagesEx( _In_ HMODULE hModule, _In_ LPCTSTR lpType, _In_ LPCTSTR lpName, _In_ ENUMRESLANGPROC
	// lpEnumFunc, _In_ LONG_PTR lParam, _In_ DWORD dwFlags, _In_ LANGID LangId); https://msdn.microsoft.com/en-us/library/windows/desktop/ms648036(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Unicode, EntryPoint = "EnumResourceLanguagesExW")]
	[PInvokeData("Winbase.h", MSDNShortId = "ms648036")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool EnumResourceLanguagesEx([In] HINSTANCE hModule, [In] SafeResourceId lpType, [In] SafeResourceId lpName,
		EnumResLangProc lpEnumFunc, [In, Optional] IntPtr lParam, RESOURCE_ENUM_FLAGS dwFlags, ushort LangId);

	/// <summary>Enumerates language-specific resources, of the specified type and name, associated with a specified binary module.</summary>
	/// <param name="hModule">
	/// <para>
	/// The handle to a module to search. Typically this is a language-neutral Portable Executable (LN file), and if flag
	/// <c>RESOURCE_ENUM_MUI</c> is set, then appropriate .mui files are included in the search. Alternately, this can be a handle to an
	/// .mui file or other LN file. If this is a specific .mui file, only that file is searched for resources.
	/// </para>
	/// <para>If this parameter is <c>NULL</c>, it is equivalent to passing in a handle to the module used to create the current process.</para>
	/// </param>
	/// <param name="type">
	/// The type of the resource for which the language is being enumerated. Alternately, rather than a pointer, this parameter can be
	/// <c>MAKEINTRESOURCE</c>(ID), where ID is an integer value representing a predefined resource type. For a list of predefined
	/// resource types, see Resource Types. For more information, see the Remarks section below.
	/// </param>
	/// <param name="name">
	/// The name of the resource for which the language is being enumerated. Alternately, rather than a pointer, this parameter can be
	/// <c>MAKEINTRESOURCE</c>(ID), where ID is the integer identifier of the resource. For more information, see the Remarks section below.
	/// </param>
	/// <param name="flags">
	/// The type of file to be searched. Note that if <paramref name="flags"/> is zero, then the <c>RESOURCE_ENUM_LN</c> and
	/// <c>RESOURCE_ENUM_MUI</c> flags are assumed to be specified.
	/// </param>
	/// <param name="langFilter">
	/// The localization language used to filter the search in the .mui file. This parameter is used only when the
	/// <c>RESOURCE_ENUM_MUI</c> flag is set in dwFlags. If zero is specified, then all .mui files are included in the search. If a
	/// nonzero LangId is specified, then the only .mui file searched will be the one matching the specified LangId.
	/// </param>
	/// <returns>A list of the language identifiers (see Language Identifiers) for which a resource was found.</returns>
	[PInvokeData("Winbase.h", MSDNShortId = "ms648036")]
	public static IList<ushort> EnumResourceLanguagesEx(HINSTANCE hModule, SafeResourceId type, SafeResourceId name, RESOURCE_ENUM_FLAGS flags = 0, ushort langFilter = 0)
	{
		var list = new List<ushort>();
		if (!EnumResourceLanguagesEx(hModule, type, name, (p, i, n, luid, l) => { list.Add(luid); return true; }, IntPtr.Zero, flags, langFilter))
			Win32Error.ThrowLastError();
		return list;
	}

	/// <summary>
	/// Enumerates resources of a specified type within a binary module. For Windows Vista and later, this is typically a
	/// language-neutral Portable Executable (LN file), and the enumeration will also include resources from the corresponding
	/// language-specific resource files (.mui files) that contain localizable language resources. It is also possible for hModule to
	/// specify an .mui file, in which case only that file is searched for resources.
	/// </summary>
	/// <param name="hModule">
	/// A handle to a module to be searched. Starting with Windows Vista, if this is an LN file, then appropriate .mui files (if any
	/// exist) are included in the search.
	/// <para>If this parameter is NULL, that is equivalent to passing in a handle to the module used to create the current process.</para>
	/// </param>
	/// <param name="lpszType">
	/// The type of the resource for which the name is being enumerated. Alternately, rather than a pointer, this parameter can be
	/// MAKEINTRESOURCE(ID), where ID is an integer value representing a predefined resource type.
	/// </param>
	/// <param name="lpEnumFunc">A pointer to the callback function to be called for each enumerated resource name or ID.</param>
	/// <param name="lParam">An application-defined value passed to the callback function. This parameter can be used in error checking.</param>
	/// <returns>
	/// The return value is TRUE if the function succeeds or FALSE if the function does not find a resource of the type specified, or if
	/// the function fails for another reason. To get extended error information, call GetLastError.
	/// </returns>
	[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Unicode, EntryPoint = "EnumResourceNamesW")]
	[SuppressUnmanagedCodeSecurity]
	[PInvokeData("WinBase.h", MSDNShortId = "ms648037")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool EnumResourceNames(HINSTANCE hModule, SafeResourceId lpszType, EnumResNameProc lpEnumFunc, [In, Optional] IntPtr lParam);

	/// <summary>
	/// Enumerates resources of a specified type within a binary module. For Windows Vista and later, this is typically a
	/// language-neutral Portable Executable (LN file), and the enumeration will also include resources from the corresponding
	/// language-specific resource files (.mui files) that contain localizable language resources. It is also possible for hModule to
	/// specify an .mui file, in which case only that file is searched for resources.
	/// </summary>
	/// <param name="hModule">
	/// A handle to a module to be searched. Starting with Windows Vista, if this is an LN file, then appropriate .mui files (if any
	/// exist) are included in the search.
	/// <para>If this parameter is NULL, that is equivalent to passing in a handle to the module used to create the current process.</para>
	/// </param>
	/// <param name="type">
	/// The type of the resource for which the name is being enumerated. Alternately, rather than a string, this parameter can be
	/// MAKEINTRESOURCE(ID), where ID is an integer value representing a predefined resource type.
	/// </param>
	/// <param name="flags">
	/// <para>
	/// The type of file to search. The following values are supported. Note that if dwFlags is zero, then the <c>RESOURCE_ENUM_LN</c>
	/// and <c>RESOURCE_ENUM_MUI</c> flags are assumed to be specified.
	/// </para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>RESOURCE_ENUM_MUI0x0002</term>
	/// <term>
	/// Search for resources in .mui files associated with the LN file specified by hModule and with the current language preferences,
	/// following the usual Resource Loader strategy (see User Interface Language Management). Alternately, if LangId is nonzero, then
	/// only the specified .mui file will be searched. Typically this flag should be used only if hModule references an LN file. If
	/// hModule references an .mui file, then that file is actually covered by the RESOURCE_ENUM_LN flag, despite the name of the flag.
	/// </term>
	/// </item>
	/// <item>
	/// <term>RESOURCE_ENUM_LN0x0001</term>
	/// <term>
	/// Searches the file specified by hModule, regardless of whether the file is an LN file, another type of LN file, or an .mui file.
	/// </term>
	/// </item>
	/// <item>
	/// <term>RESOURCE_ENUM_VALIDATE0x0008</term>
	/// <term>
	/// Performs extra validation on the resource section and its reference in the PE header while doing the enumeration to ensure that
	/// resources are properly formatted. The validation sets a maximum limit of 260 characters for each name that is enumerated.
	/// </term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <param name="langFilter">
	/// <para>
	/// The localization language used to filter the search in the MUI module. This parameter is used only when the
	/// <c>RESOURCE_ENUM_MUI</c> flag is set in dwFlags. If zero is specified, then all .mui files that match current language
	/// preferences are included in the search, following the usual Resource Loader strategy (see User Interface Language Management). If
	/// a nonzero LangId is specified, then the only .mui file searched will be the one matching the specified LangId.
	/// </para>
	/// </param>
	/// ///
	/// <returns>A list of strings for each of the resources matching <paramref name="type"/>.</returns>
	[PInvokeData("WinBase.h", MSDNShortId = "ms648037")]
	public static IList<ResourceId> EnumResourceNamesEx(HINSTANCE hModule, SafeResourceId type, RESOURCE_ENUM_FLAGS flags = 0, ushort langFilter = 0) =>
		EnumResWrapper(p => EnumResourceNamesEx(hModule, type, p, default, flags, langFilter));

	/// <summary>
	/// Enumerates resources of a specified type that are associated with a specified binary module. The search can include both an LN
	/// file and its associated .mui files, or it can be limited in several ways.
	/// </summary>
	/// <param name="hModule">
	/// <para>Type: <c>HMODULE</c></para>
	/// <para>
	/// The handle to a module to search. Typically this is an LN file, and if flag <c>RESOURCE_ENUM_MUI</c> is set, then appropriate
	/// .mui files are included in the search. Alternately, this can be a handle to an .mui file or other LN file.
	/// </para>
	/// <para>If this parameter is <c>NULL</c>, it is equivalent to passing in a handle to the module used to create the current process.</para>
	/// </param>
	/// <param name="lpszType">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>
	/// The type of the resource for which the name is being enumerated. Alternately, rather than a pointer, this parameter can be
	/// <c>MAKEINTRESOURCE</c>(ID), where ID is an integer value representing a predefined resource type. For a list of predefined
	/// resource types, see <c>Resource Types</c>. For more information, see the Remarks section below.
	/// </para>
	/// </param>
	/// <param name="lpEnumFunc">
	/// <para>Type: <c>ENUMRESNAMEPROC</c></para>
	/// <para>A pointer to the callback function to be called for each enumerated resource name. For more information, see EnumResNameProc.</para>
	/// </param>
	/// <param name="lParam">
	/// <para>Type: <c>LONG_PTR</c></para>
	/// <para>An application-defined value passed to the callback function. This parameter can be used in error checking.</para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>
	/// The type of file to search. The following values are supported. Note that if dwFlags is zero, then the <c>RESOURCE_ENUM_LN</c>
	/// and <c>RESOURCE_ENUM_MUI</c> flags are assumed to be specified.
	/// </para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>RESOURCE_ENUM_MUI0x0002</term>
	/// <term>
	/// Search for resources in .mui files associated with the LN file specified by hModule and with the current language preferences,
	/// following the usual Resource Loader strategy (see User Interface Language Management). Alternately, if LangId is nonzero, then
	/// only the specified .mui file will be searched. Typically this flag should be used only if hModule references an LN file. If
	/// hModule references an .mui file, then that file is actually covered by the RESOURCE_ENUM_LN flag, despite the name of the flag.
	/// </term>
	/// </item>
	/// <item>
	/// <term>RESOURCE_ENUM_LN0x0001</term>
	/// <term>
	/// Searches the file specified by hModule, regardless of whether the file is an LN file, another type of LN file, or an .mui file.
	/// </term>
	/// </item>
	/// <item>
	/// <term>RESOURCE_ENUM_VALIDATE0x0008</term>
	/// <term>
	/// Performs extra validation on the resource section and its reference in the PE header while doing the enumeration to ensure that
	/// resources are properly formatted. The validation sets a maximum limit of 260 characters for each name that is enumerated.
	/// </term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <param name="LangId">
	/// <para>Type: <c>LANGID</c></para>
	/// <para>
	/// The localization language used to filter the search in the MUI module. This parameter is used only when the
	/// <c>RESOURCE_ENUM_MUI</c> flag is set in dwFlags. If zero is specified, then all .mui files that match current language
	/// preferences are included in the search, following the usual Resource Loader strategy (see User Interface Language Management). If
	/// a nonzero LangId is specified, then the only .mui file searched will be the one matching the specified LangId.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>
	/// The function <c>TRUE</c> if successful, or <c>FALSE</c> if the function does not find a resource of the type specified, or if the
	/// function fails for another reason. To get extended error information, call <c>GetLastError</c>.
	/// </para>
	/// </returns>
	// BOOL WINAPI EnumResourceNamesEx( _In_opt_ HMODULE hModule, _In_ LPCTSTR lpszType, _In_ ENUMRESNAMEPROC lpEnumFunc, _In_ LONG_PTR
	// lParam, _In_ DWORD dwFlags, _In_ LANGID LangId); https://msdn.microsoft.com/en-us/library/windows/desktop/ms648038(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Unicode, EntryPoint = "EnumResourceNamesExW")]
	[PInvokeData("Winbase.h", MSDNShortId = "ms648038")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool EnumResourceNamesEx(HINSTANCE hModule, SafeResourceId lpszType, EnumResNameProc lpEnumFunc, [In, Optional] IntPtr lParam, [Optional] RESOURCE_ENUM_FLAGS dwFlags, [Optional] ushort LangId);

	/// <summary>
	/// <para>
	/// Enumerates resource types within a binary module. Starting with Windows Vista, this is typically a language-neutral Portable
	/// Executable (LN file), and the enumeration also includes resources from one of the corresponding language-specific resource files
	/// (.mui files)—if one exists—that contain localizable language resources. It is also possible to use hModule to specify a .mui
	/// file, in which case only that file is searched for resource types.
	/// </para>
	/// <para>
	/// Alternately, applications can call <c>EnumResourceTypesEx</c>, which provides more precise control over which resource files to enumerate.
	/// </para>
	/// </summary>
	/// <param name="hModule">
	/// <para>Type: <c>HMODULE</c></para>
	/// <para>
	/// A handle to a module to be searched. This handle must be obtained through <c>LoadLibrary</c> or <c>LoadLibraryEx</c>. See Remarks
	/// for more information.
	/// </para>
	/// <para>If this parameter is <c>NULL</c>, that is equivalent to passing in a handle to the module used to create the current process.</para>
	/// </param>
	/// <param name="lpEnumFunc">
	/// <para>Type: <c>ENUMRESTYPEPROC</c></para>
	/// <para>
	/// A pointer to the callback function to be called for each enumerated resource type. For more information, see the
	/// <c>EnumResTypeProc</c> function.
	/// </para>
	/// </param>
	/// <param name="lParam">
	/// <para>Type: <c>LONG_PTR</c></para>
	/// <para>An application-defined value passed to the callback function.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>Returns <c>TRUE</c> if successful; otherwise, <c>FALSE</c>. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// BOOL WINAPI EnumResourceTypes( _In_opt_ HMODULE hModule, _In_ ENUMRESTYPEPROC lpEnumFunc, _In_ LONG_PTR lParam); https://msdn.microsoft.com/en-us/library/windows/desktop/ms648039(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Unicode, EntryPoint = "EnumResourceTypesW")]
	[PInvokeData("Winbase.h", MSDNShortId = "ms648039")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool EnumResourceTypes([In] HINSTANCE hModule, EnumResTypeProc lpEnumFunc, [In, Optional] IntPtr lParam);

	/// <summary>
	/// <para>
	/// Enumerates resource types associated with a specified binary module. The search can include both a language-neutral Portable
	/// Executable file (LN
	/// file) and its associated .mui files. Alternately, it can be limited to a single binary module of any type, or to the .mui files
	/// associated with a single LN file. The search can also be limited to a single associated .mui file that contains resources for a
	/// specific language.
	/// </para>
	/// <para>
	/// For each resource type found, <c>EnumResourceTypesEx</c> calls an application-defined callback function lpEnumFunc, passing the
	/// resource type it finds, as well as the various other parameters that were passed to <c>EnumResourceTypesEx</c>.
	/// </para>
	/// </summary>
	/// <param name="hModule">
	/// <para>Type: <c>HMODULE</c></para>
	/// <para>
	/// The handle to a module to be searched. Typically this is an LN file, and if flag <c>RESOURCE_ENUM_MUI</c> is set, then
	/// appropriate .mui files can be included in the search. Alternately, this can be a handle to an .mui file or other LN file.
	/// </para>
	/// <para>If this parameter is <c>NULL</c>, it is equivalent to passing in a handle to the module used to create the current process.</para>
	/// </param>
	/// <param name="lpEnumFunc">
	/// <para>Type: <c>ENUMRESTYPEPROC</c></para>
	/// <para>A pointer to the callback function to be called for each enumerated resource type. For more information, see <c>EnumResTypeProc</c>.</para>
	/// </param>
	/// <param name="lParam">
	/// <para>Type: <c>LONG_PTR</c></para>
	/// <para>An application-defined value passed to the callback function.</para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>
	/// The type of file to be searched. The following values are supported. Note that if dwFlags is zero, then the
	/// <c>RESOURCE_ENUM_LN</c> and <c>RESOURCE_ENUM_MUI</c> flags are assumed to be specified.
	/// </para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>RESOURCE_ENUM_MUI0x0002</term>
	/// <term>
	/// Search for resource types in one of the .mui files associated with the file specified by hModule and with the current language
	/// preferences, following the usual Resource Loader strategy (see User Interface Language Management). Alternately, if LangId is
	/// nonzero, then only the .mui file of the language as specified by LangId will be searched. Typically this flag should be used only
	/// if hModule references an LN file. If hModule references an .mui file, then that file is actually covered by the RESOURCE_ENUM_LN
	/// flag, despite the name of the flag.
	/// </term>
	/// </item>
	/// <item>
	/// <term>RESOURCE_ENUM_LN0x0001</term>
	/// <term>Searches only the file specified by hModule, regardless of whether the file is an LN file or an .mui file.</term>
	/// </item>
	/// <item>
	/// <term>RESOURCE_ENUM_VALIDATE0x0008</term>
	/// <term>
	/// Performs extra validation on the resource section and its reference in the PE header while doing the enumeration to ensure that
	/// resources are properly formatted. The validation sets a maximum limit of 260 characters for each type that is enumerated.
	/// </term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <param name="LangId">
	/// <para>Type: <c>LANGID</c></para>
	/// <para>
	/// The language used to filter the search in the MUI module. This parameter is used only when the <c>RESOURCE_ENUM_MUI</c> flag is
	/// set in dwFlags. If zero is specified, then all .mui files that match current language preferences are included in the search,
	/// following the usual Resource Loader strategy (see User Interface Language Management). If a nonzero LangId is specified, then the
	/// only .mui file searched will be the one matching the specified LangId.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>
	/// Returns <c>TRUE</c> if successful or <c>FALSE</c> if the function does not find a resource of the type specified, or if the
	/// function fails for another reason. To get extended error information, call <c>GetLastError</c>.
	/// </para>
	/// </returns>
	// BOOL WINAPI EnumResourceTypesEx( _In_opt_ HMODULE hModule, _In_ ENUMRESTYPEPROC lpEnumFunc, _In_ LONG_PTR lParam, _In_ DWORD
	// dwFlags, _In_ LANGID LangId); https://msdn.microsoft.com/en-us/library/windows/desktop/ms648040(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("Winbase.h", MSDNShortId = "ms648040")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool EnumResourceTypesEx(HINSTANCE hModule, EnumResTypeProc lpEnumFunc, IntPtr lParam, [In, Optional] RESOURCE_ENUM_FLAGS dwFlags, [In, Optional] ushort LangId);

	/// <summary>
	/// <para>
	/// Enumerates resource types associated with a specified binary module. The search can include both a language-neutral Portable
	/// Executable file (LN
	/// file) and its associated .mui files. Alternately, it can be limited to a single binary module of any type, or to the .mui files
	/// associated with a single LN file. The search can also be limited to a single associated .mui file that contains resources for a
	/// specific language.
	/// </para>
	/// </summary>
	/// <param name="hModule">
	/// <para>Type: <c>HMODULE</c></para>
	/// <para>
	/// The handle to a module to be searched. Typically this is an LN file, and if flag <c>RESOURCE_ENUM_MUI</c> is set, then
	/// appropriate .mui files can be included in the search. Alternately, this can be a handle to an .mui file or other LN file.
	/// </para>
	/// <para>If this parameter is <c>NULL</c>, it is equivalent to passing in a handle to the module used to create the current process.</para>
	/// </param>
	/// <param name="flags">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>
	/// The type of file to be searched. The following values are supported. Note that if dwFlags is zero, then the
	/// <c>RESOURCE_ENUM_LN</c> and <c>RESOURCE_ENUM_MUI</c> flags are assumed to be specified.
	/// </para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>RESOURCE_ENUM_MUI0x0002</term>
	/// <term>
	/// Search for resource types in one of the .mui files associated with the file specified by hModule and with the current language
	/// preferences, following the usual Resource Loader strategy (see User Interface Language Management). Alternately, if LangId is
	/// nonzero, then only the .mui file of the language as specified by LangId will be searched. Typically this flag should be used only
	/// if hModule references an LN file. If hModule references an .mui file, then that file is actually covered by the RESOURCE_ENUM_LN
	/// flag, despite the name of the flag.
	/// </term>
	/// </item>
	/// <item>
	/// <term>RESOURCE_ENUM_LN0x0001</term>
	/// <term>Searches only the file specified by hModule, regardless of whether the file is an LN file or an .mui file.</term>
	/// </item>
	/// <item>
	/// <term>RESOURCE_ENUM_VALIDATE0x0008</term>
	/// <term>
	/// Performs extra validation on the resource section and its reference in the PE header while doing the enumeration to ensure that
	/// resources are properly formatted. The validation sets a maximum limit of 260 characters for each type that is enumerated.
	/// </term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <param name="langFilter">
	/// <para>Type: <c>LANGID</c></para>
	/// <para>
	/// The language used to filter the search in the MUI module. This parameter is used only when the <c>RESOURCE_ENUM_MUI</c> flag is
	/// set in dwFlags. If zero is specified, then all .mui files that match current language preferences are included in the search,
	/// following the usual Resource Loader strategy (see User Interface Language Management). If a nonzero LangId is specified, then the
	/// only .mui file searched will be the one matching the specified LangId.
	/// </para>
	/// </param>
	/// <returns>List of resource identifiers.</returns>
	public static IList<ResourceId> EnumResourceTypesEx([In] HINSTANCE hModule, RESOURCE_ENUM_FLAGS flags = 0, ushort langFilter = 0)
	{
		var list = new List<ResourceId>();
		if (!EnumResourceTypesEx(hModule, (p, t, l) => { list.Add(t); return true; }, IntPtr.Zero, flags, langFilter))
			Win32Error.ThrowLastError();
		return list;
	}

	/// <summary>
	/// <para>Determines the location of a resource with the specified type and name in the specified module.</para>
	/// <para>To specify a language, use the <c>FindResourceEx</c> function.</para>
	/// </summary>
	/// <param name="hModule">
	/// <para>Type: <c>HMODULE</c></para>
	/// <para>
	/// A handle to the module whose portable executable file or an accompanying MUI file contains the resource. If this parameter is
	/// <c>NULL</c>, the function searches the module used to create the current process.
	/// </para>
	/// </param>
	/// <param name="lpName">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>
	/// The name of the resource. Alternately, rather than a pointer, this parameter can be <c>MAKEINTRESOURCE</c>(ID), where ID is the
	/// integer identifier of the resource. For more information, see the Remarks section below.
	/// </para>
	/// </param>
	/// <param name="lpType">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>
	/// The resource type. Alternately, rather than a pointer, this parameter can be <c>MAKEINTRESOURCE</c>(ID), where ID is the integer
	/// identifier of the given resource type. For standard resource types, see Resource Types. For more information, see the Remarks
	/// section below.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRSRC</c></para>
	/// <para>
	/// If the function succeeds, the return value is a handle to the specified resource's information block. To obtain a handle to the
	/// resource, pass this handle to the <see cref="LoadResource"/> function.
	/// </para>
	/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// HRSRC WINAPI FindResource( _In_opt_ HMODULE hModule, _In_ LPCTSTR lpName, _In_ LPCTSTR lpType); https://msdn.microsoft.com/en-us/library/windows/desktop/ms648042(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Unicode, EntryPoint = "FindResourceW")]
	[PInvokeData("Winbase.h", MSDNShortId = "ms648042")]
	public static extern HRSRC FindResource([In] HINSTANCE hModule, [In] SafeResourceId lpName, [In] SafeResourceId lpType);

	/// <summary>Determines the location of the resource with the specified type, name, and language in the specified module.</summary>
	/// <param name="hModule">
	/// <para>Type: <c>HMODULE</c></para>
	/// <para>
	/// A handle to the module whose portable executable file or an accompanying MUI file contains the resource. If this parameter is
	/// <c>NULL</c>, the function searches the module used to create the current process.
	/// </para>
	/// </param>
	/// <param name="lpType">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>
	/// The resource type. Alternately, rather than a pointer, this parameter can be <c>MAKEINTRESOURCE</c>(ID), where ID is the integer
	/// identifier of the given resource type. For standard resource types, see Resource Types. For more information, see the Remarks
	/// section below.
	/// </para>
	/// </param>
	/// <param name="lpName">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>
	/// The name of the resource. Alternately, rather than a pointer, this parameter can be <c>MAKEINTRESOURCE</c>(ID), where ID is the
	/// integer identifier of the resource. For more information, see the Remarks section below.
	/// </para>
	/// </param>
	/// <param name="wLanguage">
	/// <para>Type: <c>WORD</c></para>
	/// <para>The language of the resource. If this parameter is , the current language associated with the calling thread is used.</para>
	/// <para>
	/// To specify a language other than the current language, use the <c>MAKELANGID</c> macro to create this parameter. For more
	/// information, see <c>MAKELANGID</c>.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRSRC</c></para>
	/// <para>
	/// If the function succeeds, the return value is a handle to the specified resource's information block. To obtain a handle to the
	/// resource, pass this handle to the <c>LoadResource</c> function.
	/// </para>
	/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// HRSRC WINAPI FindResourceEx( _In_opt_ HMODULE hModule, _In_ LPCTSTR lpType, _In_ LPCTSTR lpName, _In_ WORD wLanguage); https://msdn.microsoft.com/en-us/library/windows/desktop/ms648043(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Unicode, EntryPoint = "FindResourceExW")]
	[PInvokeData("Winbase.h", MSDNShortId = "ms648043")]
	public static extern HRSRC FindResourceEx([In] HINSTANCE hModule, [In] SafeResourceId lpType, [In] SafeResourceId lpName, ushort wLanguage = 0);

	/// <summary>Locates a Unicode string (wide characters) in another Unicode string for a non-linguistic comparison.</summary>
	/// <param name="dwFindStringOrdinalFlags">
	/// <para>
	/// Flags specifying details of the find operation. These flags are mutually exclusive, with FIND_FROMSTART being the default. The
	/// application can specify just one of the find flags.
	/// </para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>FIND_FROMSTART</term>
	/// <term>Search the string, starting with the first character of the string.</term>
	/// </item>
	/// <item>
	/// <term>FIND_FROMEND</term>
	/// <term>Search the string in the reverse direction, starting with the last character of the string.</term>
	/// </item>
	/// <item>
	/// <term>FIND_STARTSWITH</term>
	/// <term>Test to find out if the value specified by lpStringValue is the first value in the source string indicated by lpStringSource.</term>
	/// </item>
	/// <item>
	/// <term>FIND_ENDSWITH</term>
	/// <term>Test to find out if the value specified by lpStringValue is the last value in the source string indicated by lpStringSource.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <param name="lpStringSource">Pointer to the source string, in which the function searches for the string specified by lpStringValue.</param>
	/// <param name="cchSource">
	/// Size, in characters excluding the terminating null character, of the string indicated by lpStringSource. The application must
	/// normally specify a positive number, or 0. The application can specify -1 if the source string is null-terminated and the function
	/// should calculate the size automatically.
	/// </param>
	/// <param name="lpStringValue">Pointer to the search string for which the function searches in the source string.</param>
	/// <param name="cchValue">
	/// Size, in characters excluding the terminating null character, of the string indicated by lpStringValue. The application must
	/// normally specify a positive number, or 0. The application can specify -1 if the string is null-terminated and the function should
	/// calculate the size automatically.
	/// </param>
	/// <param name="bIgnoreCase">
	/// <c>TRUE</c> if the function is to perform a case-insensitive comparison, and <c>FALSE</c> otherwise. The comparison is not a
	/// linguistic operation and is not appropriate for all locales and languages. Its behavior is similar to that for English.
	/// </param>
	/// <returns>
	/// <para>
	/// Returns a 0-based index into the source string indicated by lpStringSource if successful. If the function succeeds, the found
	/// string is the same size as the value of lpStringValue. A return value of 0 indicates that the function found a match at the
	/// beginning of the source string.
	/// </para>
	/// <para>
	/// The function returns -1 if it does not succeed or if it does not find the search string. To get extended error information, the
	/// application can call <c>GetLastError</c>, which can return one of the following error codes:
	/// </para>
	/// </returns>
	// int FindStringOrdinal( _In_ DWORD dwFindStringOrdinalFlags, _In_ LPCWSTR lpStringSource, _In_ int cchSource, _In_ LPCWSTR
	// lpStringValue, _In_ int cchValue, _In_ BOOL bIgnoreCase); https://msdn.microsoft.com/en-us/library/windows/desktop/dd318061(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("Libloaderapi.h", MSDNShortId = "dd318061")]
	public static extern int FindStringOrdinal(SEARCH_FLAGS dwFindStringOrdinalFlags, string lpStringSource, int cchSource, string lpStringValue, int cchValue, [MarshalAs(UnmanagedType.Bool)] bool bIgnoreCase);

	/// <summary>
	/// Frees the loaded dynamic-link library (DLL) module and, if necessary, decrements its reference count. When the reference count
	/// reaches zero, the module is unloaded from the address space of the calling process and the handle is no longer valid.
	/// </summary>
	/// <param name="hModule">
	/// A handle to the loaded library module. The <c>LoadLibrary</c>, <c>LoadLibraryEx</c>, <c>GetModuleHandle</c>, or
	/// <c>GetModuleHandleEx</c> function returns this handle.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call the <c>GetLastError</c> function.</para>
	/// </returns>
	// BOOL WINAPI FreeLibrary( _In_ HMODULE hModule); https://msdn.microsoft.com/en-us/library/windows/desktop/ms683152(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("Winbase.h", MSDNShortId = "ms683152")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool FreeLibrary(HINSTANCE hModule);

	/// <summary>
	/// Decrements the reference count of a loaded dynamic-link library (DLL) by one, then calls <c>ExitThread</c> to terminate the
	/// calling thread. The function does not return.
	/// </summary>
	/// <param name="hModule">
	/// <para>
	/// A handle to the DLL module whose reference count the function decrements. The <c>LoadLibrary</c> or <c>GetModuleHandleEx</c>
	/// function returns this handle.
	/// </para>
	/// <para>
	/// Do not call this function with a handle returned by the <c>GetModuleHandle</c> function, since this function does not maintain a
	/// reference count for the module.
	/// </para>
	/// </param>
	/// <param name="dwExitCode">The exit code for the calling thread.</param>
	/// <returns>This function does not return a value. Invalid module handles are ignored.</returns>
	// VOID WINAPI FreeLibraryAndExitThread( _In_ HMODULE hModule, _In_ DWORD dwExitCode); https://msdn.microsoft.com/en-us/library/windows/desktop/ms683153(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Winbase.h", MSDNShortId = "ms683153")]
	public static extern void FreeLibraryAndExitThread([In] HINSTANCE hModule, uint dwExitCode);

	/// <summary>
	/// <para>
	/// [This function is obsolete and is only supported for backward compatibility with 16-bit Windows. For 32-bit Windows applications,
	/// it is not necessary to free the resources loaded using <c>LoadResource</c>. If used on 32 or 64-bit Windows systems, this
	/// function will return <c>FALSE</c>.]
	/// </para>
	/// <para>
	/// Decrements (decreases by one) the reference count of a loaded resource. When the reference count reaches zero, the memory
	/// occupied by the resource is freed.
	/// </para>
	/// </summary>
	/// <param name="hglbResource">
	/// <para>Type: <c>HGLOBAL</c></para>
	/// <para>A handle of the resource. It is assumed that hglbResource was created by <c>LoadResource</c>.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>If the function succeeds, the return value is zero.</para>
	/// <para>If the function fails, the return value is nonzero, which indicates that the resource has not been freed.</para>
	/// </returns>
	// BOOL WINAPI FreeResource( _In_ HGLOBAL hglbResource); https://msdn.microsoft.com/en-us/library/windows/desktop/ms648044(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Winbase.h", MSDNShortId = "ms648044")]
	[Obsolete]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool FreeResource([In] HRSRCDATA hglbResource);

	/// <summary>
	/// <para>
	/// Retrieves the fully qualified path for the file that contains the specified module. The module must have been loaded by the
	/// current process.
	/// </para>
	/// <para>To locate the file for a module that was loaded by another process, use the <c>GetModuleFileNameEx</c> function.</para>
	/// </summary>
	/// <param name="hModule">
	/// <para>
	/// A handle to the loaded module whose path is being requested. If this parameter is <c>NULL</c>, <c>GetModuleFileName</c> retrieves
	/// the path of the executable file of the current process.
	/// </para>
	/// <para>
	/// The <c>GetModuleFileName</c> function does not retrieve the path for modules that were loaded using the
	/// <c>LOAD_LIBRARY_AS_DATAFILE</c> flag. For more information, see <c>LoadLibraryEx</c>.
	/// </para>
	/// </param>
	/// <param name="lpFilename">
	/// <para>
	/// A pointer to a buffer that receives the fully qualified path of the module. If the length of the path is less than the size that
	/// the nSize parameter specifies, the function succeeds and the path is returned as a null-terminated string.
	/// </para>
	/// <para>
	/// If the length of the path exceeds the size that the nSize parameter specifies, the function succeeds and the string is truncated
	/// to nSize characters including the terminating null character.
	/// </para>
	/// <para><c>Windows XP:</c> The string is truncated to nSize characters and is not null-terminated.</para>
	/// <para>
	/// The string returned will use the same format that was specified when the module was loaded. Therefore, the path can be a long or
	/// short file name, and can use the prefix "\\?\". For more information, see Naming a File.
	/// </para>
	/// </param>
	/// <param name="nSize">The size of the lpFilename buffer, in <c>TCHARs</c>.</param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is the length of the string that is copied to the buffer, in characters, not including
	/// the terminating null character. If the buffer is too small to hold the module name, the string is truncated to nSize characters
	/// including the terminating null character, the function returns nSize, and the function sets the last error to <c>ERROR_INSUFFICIENT_BUFFER</c>.
	/// </para>
	/// <para>
	/// <c>Windows XP:</c> If the buffer is too small to hold the module name, the function returns nSize. The last error code remains
	/// <c>ERROR_SUCCESS</c>. If nSize is zero, the return value is zero and the last error code is <c>ERROR_SUCCESS</c>.
	/// </para>
	/// <para>If the function fails, the return value is 0 (zero). To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// DWORD WINAPI GetModuleFileName( _In_opt_ HMODULE hModule, _Out_ LPTSTR lpFilename, _In_ DWORD nSize); https://msdn.microsoft.com/en-us/library/windows/desktop/ms683197(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("Winbase.h", MSDNShortId = "ms683197")]
	public static extern uint GetModuleFileName(HINSTANCE hModule, StringBuilder? lpFilename, uint nSize);

	/// <summary>
	/// Retrieves the fully qualified path for the file that contains the specified module. The module must have been loaded by the
	/// current process.
	/// <para>To locate the file for a module that was loaded by another process, use the GetModuleFileNameEx function.</para>
	/// </summary>
	/// <param name="hModule">
	/// A handle to the loaded module whose path is being requested. If this parameter is NULL, GetModuleFileName retrieves the path of
	/// the executable file of the current process.
	/// <para>
	/// The GetModuleFileName function does not retrieve the path for modules that were loaded using the LOAD_LIBRARY_AS_DATAFILE flag.
	/// For more information, see LoadLibraryEx.
	/// </para>
	/// </param>
	/// <returns>
	/// The string returned will use the same format that was specified when the module was loaded. Therefore, the path can be a long or
	/// short file name, and can use the prefix "\\?\". For more information, see Naming a File.
	/// </returns>
	[SecurityCritical]
	[PInvokeData("WinBase.h", MSDNShortId = "ms683197")]
	public static string GetModuleFileName(HINSTANCE hModule)
	{
		var buffer = new StringBuilder(MAX_PATH);
	Label_000B:
		var num1 = GetModuleFileName(hModule, buffer, (uint)buffer.Capacity);
		if (num1 == 0)
			throw new Win32Exception();
		if (num1 == buffer.Capacity && Marshal.GetLastWin32Error() == Win32Error.ERROR_INSUFFICIENT_BUFFER)
		{
			buffer.EnsureCapacity(buffer.Capacity * 2);
			goto Label_000B;
		}
		return buffer.ToString();
	}

	/// <summary>
	/// <para>Retrieves a module handle for the specified module. The module must have been loaded by the calling process.</para>
	/// <para>To avoid the race conditions described in the Remarks section, use the <c>GetModuleHandleEx</c> function.</para>
	/// </summary>
	/// <param name="lpModuleName">
	/// <para>
	/// The name of the loaded module (either a .dll or .exe file). If the file name extension is omitted, the default library extension
	/// .dll is appended. The file name string can include a trailing point character (.) to indicate that the module name has no
	/// extension. The string does not have to specify a path. When specifying a path, be sure to use backslashes (\), not forward
	/// slashes (/). The name is compared (case independently) to the names of modules currently mapped into the address space of the
	/// calling process.
	/// </para>
	/// <para>
	/// If this parameter is NULL, <c>GetModuleHandle</c> returns a handle to the file used to create the calling process (.exe file).
	/// </para>
	/// <para>
	/// The <c>GetModuleHandle</c> function does not retrieve handles for modules that were loaded using the
	/// <c>LOAD_LIBRARY_AS_DATAFILE</c> flag. For more information, see <c>LoadLibraryEx</c>.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a handle to the specified module.</para>
	/// <para>If the function fails, the return value is NULL. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// HMODULE WINAPI GetModuleHandle( _In_opt_ LPCTSTR lpModuleName); https://msdn.microsoft.com/en-us/library/windows/desktop/ms683199(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("Winbase.h", MSDNShortId = "ms683199")]
	public static extern SafeHINSTANCE GetModuleHandle([Optional] string? lpModuleName);

	/// <summary>
	/// Retrieves a module handle for the specified module and increments the module's reference count unless
	/// GET_MODULE_HANDLE_EX_FLAG_UNCHANGED_REFCOUNT is specified. The module must have been loaded by the calling process.
	/// </summary>
	/// <param name="dwFlags">
	/// This parameter can be zero or one or more of the following values. If the module's reference count is incremented, the caller
	/// must use the <c>FreeLibrary</c> function to decrement the reference count when the module handle is no longer needed.
	/// </param>
	/// <param name="lpModuleName">
	/// <para>The name of the loaded module (either a .dll or .exe file), or an address in the module (if dwFlags is GET_MODULE_HANDLE_EX_FLAG_FROM_ADDRESS).</para>
	/// <para>
	/// For a module name, if the file name extension is omitted, the default library extension .dll is appended. The file name string
	/// can include a trailing point character (.) to indicate that the module name has no extension. The string does not have to specify
	/// a path. When specifying a path, be sure to use backslashes (\), not forward slashes (/). The name is compared (case
	/// independently) to the names of modules currently mapped into the address space of the calling process.
	/// </para>
	/// <para>If this parameter is NULL, the function returns a handle to the file used to create the calling process (.exe file).</para>
	/// </param>
	/// <param name="phModule">
	/// <para>A handle to the specified module. If the function fails, this parameter is NULL.</para>
	/// <para>
	/// The <c>GetModuleHandleEx</c> function does not retrieve handles for modules that were loaded using the
	/// <c>LOAD_LIBRARY_AS_DATAFILE</c> flag. For more information, see <c>LoadLibraryEx</c>.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, see <c>GetLastError</c>.</para>
	/// </returns>
	// BOOL WINAPI GetModuleHandleEx( _In_ DWORD dwFlags, _In_opt_ LPCTSTR lpModuleName, _Out_ HMODULE *phModule); https://msdn.microsoft.com/en-us/library/windows/desktop/ms683200(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("Winbase.h", MSDNShortId = "ms683200")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetModuleHandleEx(GET_MODULE_HANDLE_EX_FLAG dwFlags, [Optional] string? lpModuleName, out SafeHINSTANCE phModule);

	/// <summary>
	/// Retrieves a module handle for the specified module and increments the module's reference count unless
	/// GET_MODULE_HANDLE_EX_FLAG_UNCHANGED_REFCOUNT is specified. The module must have been loaded by the calling process.
	/// </summary>
	/// <param name="dwFlags">
	/// This parameter can be zero or one or more of the following values. If the module's reference count is incremented, the caller
	/// must use the <c>FreeLibrary</c> function to decrement the reference count when the module handle is no longer needed.
	/// </param>
	/// <param name="lpModuleName">
	/// <para>The name of the loaded module (either a .dll or .exe file), or an address in the module (if dwFlags is GET_MODULE_HANDLE_EX_FLAG_FROM_ADDRESS).</para>
	/// <para>
	/// For a module name, if the file name extension is omitted, the default library extension .dll is appended. The file name string
	/// can include a trailing point character (.) to indicate that the module name has no extension. The string does not have to specify
	/// a path. When specifying a path, be sure to use backslashes (\), not forward slashes (/). The name is compared (case
	/// independently) to the names of modules currently mapped into the address space of the calling process.
	/// </para>
	/// <para>If this parameter is NULL, the function returns a handle to the file used to create the calling process (.exe file).</para>
	/// </param>
	/// <param name="phModule">
	/// <para>A handle to the specified module. If the function fails, this parameter is NULL.</para>
	/// <para>
	/// The <c>GetModuleHandleEx</c> function does not retrieve handles for modules that were loaded using the
	/// <c>LOAD_LIBRARY_AS_DATAFILE</c> flag. For more information, see <c>LoadLibraryEx</c>.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, see <c>GetLastError</c>.</para>
	/// </returns>
	// BOOL WINAPI GetModuleHandleEx( _In_ DWORD dwFlags, _In_opt_ LPCTSTR lpModuleName, _Out_ HMODULE *phModule); https://msdn.microsoft.com/en-us/library/windows/desktop/ms683200(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("Winbase.h", MSDNShortId = "ms683200")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetModuleHandleEx(GET_MODULE_HANDLE_EX_FLAG dwFlags, [In] IntPtr lpModuleName, out SafeHINSTANCE phModule);

	/// <summary>Retrieves the address of an exported function or variable from the specified dynamic-link library (DLL).</summary>
	/// <param name="hModule">
	/// <para>
	/// A handle to the DLL module that contains the function or variable. The <c>LoadLibrary</c>, <c>LoadLibraryEx</c>,
	/// <c>LoadPackagedLibrary</c>, or <c>GetModuleHandle</c> function returns this handle.
	/// </para>
	/// <para>
	/// The <c>GetProcAddress</c> function does not retrieve addresses from modules that were loaded using the
	/// <c>LOAD_LIBRARY_AS_DATAFILE</c> flag. For more information, see <c>LoadLibraryEx</c>.
	/// </para>
	/// </param>
	/// <param name="lpProcName">
	/// The function or variable name, or the function's ordinal value. If this parameter is an ordinal value, it must be in the
	/// low-order word; the high-order word must be zero.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is the address of the exported function or variable.</para>
	/// <para>If the function fails, the return value is NULL. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// FARPROC WINAPI GetProcAddress( _In_ HMODULE hModule, _In_ LPCSTR lpProcName); https://msdn.microsoft.com/en-us/library/windows/desktop/ms683212(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("Winbase.h", MSDNShortId = "ms683212")]
	public static extern IntPtr GetProcAddress(HINSTANCE hModule, [MarshalAs(UnmanagedType.LPStr)] string lpProcName);

	/// <summary>Retrieves the address of an exported function or variable from the specified dynamic-link library (DLL).</summary>
	/// <param name="hModule">
	/// <para>
	/// A handle to the DLL module that contains the function or variable. The <c>LoadLibrary</c>, <c>LoadLibraryEx</c>,
	/// <c>LoadPackagedLibrary</c>, or <c>GetModuleHandle</c> function returns this handle.
	/// </para>
	/// <para>
	/// The <c>GetProcAddress</c> function does not retrieve addresses from modules that were loaded using the
	/// <c>LOAD_LIBRARY_AS_DATAFILE</c> flag. For more information, see <c>LoadLibraryEx</c>.
	/// </para>
	/// </param>
	/// <param name="lpProcName">
	/// The function or variable name, or the function's ordinal value. If this parameter is an ordinal value, it must be in the
	/// low-order word; the high-order word must be zero.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is the address of the exported function or variable.</para>
	/// <para>If the function fails, the return value is NULL. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// FARPROC WINAPI GetProcAddress( _In_ HMODULE hModule, _In_ LPCSTR lpProcName); https://msdn.microsoft.com/en-us/library/windows/desktop/ms683212(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("Winbase.h", MSDNShortId = "ms683212")]
	public static extern IntPtr GetProcAddress(HINSTANCE hModule, IntPtr lpProcName);

	/// <summary>
	/// <para>
	/// Loads the specified module into the address space of the calling process. The specified module may cause other modules to be loaded.
	/// </para>
	/// <para>For additional load options, use the <c>LoadLibraryEx</c> function.</para>
	/// </summary>
	/// <param name="lpFileName">
	/// <para>
	/// The name of the module. This can be either a library module (a .dll file) or an executable module (an .exe file). The name
	/// specified is the file name of the module and is not related to the name stored in the library module itself, as specified by the
	/// <c>LIBRARY</c> keyword in the module-definition (.def) file.
	/// </para>
	/// <para>If the string specifies a full path, the function searches only that path for the module.</para>
	/// <para>
	/// If the string specifies a relative path or a module name without a path, the function uses a standard search strategy to find the
	/// module; for more information, see the Remarks.
	/// </para>
	/// <para>
	/// If the function cannot find the module, the function fails. When specifying a path, be sure to use backslashes (\), not forward
	/// slashes (/). For more information about paths, see Naming a File or Directory.
	/// </para>
	/// <para>
	/// If the string specifies a module name without a path and the file name extension is omitted, the function appends the default
	/// library extension .dll to the module name. To prevent the function from appending .dll to the module name, include a trailing
	/// point character (.) in the module name string.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a handle to the module.</para>
	/// <para>If the function fails, the return value is NULL. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// HMODULE WINAPI LoadLibrary( _In_ LPCTSTR lpFileName); https://msdn.microsoft.com/en-us/library/windows/desktop/ms684175(v=vs.85).aspx
	[PInvokeData("Winbase.h", MSDNShortId = "ms684175")]
	[DllImport(Lib.Kernel32, CharSet = CharSet.Auto, SetLastError = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
	public static extern SafeHINSTANCE LoadLibrary([In, MarshalAs(UnmanagedType.LPTStr)] string lpFileName);

	/// <summary>
	/// Loads the specified module into the address space of the calling process. The specified module may cause other modules to be loaded.
	/// </summary>
	/// <param name="lpFileName">
	/// <para>
	/// A string that specifies the file name of the module to load. This name is not related to the name stored in a library module
	/// itself, as specified by the <c>LIBRARY</c> keyword in the module-definition (.def) file.
	/// </para>
	/// <para>
	/// The module can be a library module (a .dll file) or an executable module (an .exe file). If the specified module is an executable
	/// module, static imports are not loaded; instead, the module is loaded as if <c>DONT_RESOLVE_DLL_REFERENCES</c> was specified. See
	/// the dwFlags parameter for more information.
	/// </para>
	/// <para>
	/// If the string specifies a module name without a path and the file name extension is omitted, the function appends the default
	/// library extension .dll to the module name. To prevent the function from appending .dll to the module name, include a trailing
	/// point character (.) in the module name string.
	/// </para>
	/// <para>
	/// If the string specifies a fully qualified path, the function searches only that path for the module. When specifying a path, be
	/// sure to use backslashes (\), not forward slashes (/). For more information about paths, see Naming Files, Paths, and Namespaces.
	/// </para>
	/// <para>
	/// If the string specifies a module name without a path and more than one loaded module has the same base name and extension, the
	/// function returns a handle to the module that was loaded first.
	/// </para>
	/// <para>
	/// If the string specifies a module name without a path and a module of the same name is not already loaded, or if the string
	/// specifies a module name with a relative path, the function searches for the specified module. The function also searches for
	/// modules if loading the specified module causes the system to load other associated modules (that is, if the module has
	/// dependencies). The directories that are searched and the order in which they are searched depend on the specified path and the
	/// dwFlags parameter. For more information, see Remarks.
	/// </para>
	/// <para>If the function cannot find the module or one of its dependencies, the function fails.</para>
	/// </param>
	/// <param name="hFile">This parameter is reserved for future use. It must be <c>NULL</c>.</param>
	/// <param name="dwFlags">
	/// <para>
	/// The action to be taken when loading the module. If no flags are specified, the behavior of this function is identical to that of
	/// the <c>LoadLibrary</c> function. This parameter can be one of the following values.
	/// </para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>DONT_RESOLVE_DLL_REFERENCES0x00000001</term>
	/// <term>
	/// If this value is used, and the executable module is a DLL, the system does not call DllMain for process and thread initialization
	/// and termination. Also, the system does not load additional executable modules that are referenced by the specified module.
	/// </term>
	/// </item>
	/// <item>
	/// <term>LOAD_IGNORE_CODE_AUTHZ_LEVEL0x00000010</term>
	/// <term>
	/// If this value is used, the system does not check AppLocker rules or apply Software Restriction Policies for the DLL. This action
	/// applies only to the DLL being loaded and not to its dependencies. This value is recommended for use in setup programs that must
	/// run extracted DLLs during installation.Windows Server 2008 R2 and Windows 7: On systems with KB2532445 installed, the caller must
	/// be running as &amp;quot;LocalSystem&amp;quot; or &amp;quot;TrustedInstaller&amp;quot;; otherwise the system ignores this flag.
	/// For more information, see &amp;quot;You can circumvent AppLocker rules by using an Office macro on a computer that is running
	/// Windows 7 or Windows Server 2008 R2&amp;quot; in the Help and Support Knowledge Base at
	/// http://support.microsoft.com/kb/2532445.Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: AppLocker was
	/// introduced in Windows 7 and Windows Server 2008 R2.
	/// </term>
	/// </item>
	/// <item>
	/// <term>LOAD_LIBRARY_AS_DATAFILE0x00000002</term>
	/// <term>
	/// If this value is used, the system maps the file into the calling process's virtual address space as if it were a data file.
	/// Nothing is done to execute or prepare to execute the mapped file. Therefore, you cannot call functions like GetModuleFileName,
	/// GetModuleHandle or GetProcAddress with this DLL. Using this value causes writes to read-only memory to raise an access violation.
	/// Use this flag when you want to load a DLL only to extract messages or resources from it.This value can be used with
	/// LOAD_LIBRARY_AS_IMAGE_RESOURCE. For more information, see Remarks.
	/// </term>
	/// </item>
	/// <item>
	/// <term>LOAD_LIBRARY_AS_DATAFILE_EXCLUSIVE0x00000040</term>
	/// <term>
	/// Similar to LOAD_LIBRARY_AS_DATAFILE, except that the DLL file is opened with exclusive write access for the calling process.
	/// Other processes cannot open the DLL file for write access while it is in use. However, the DLL can still be opened by other
	/// processes.This value can be used with LOAD_LIBRARY_AS_IMAGE_RESOURCE. For more information, see Remarks.Windows Server 2003 and
	/// Windows XP: This value is not supported until Windows Vista.
	/// </term>
	/// </item>
	/// <item>
	/// <term>LOAD_LIBRARY_AS_IMAGE_RESOURCE0x00000020</term>
	/// <term>
	/// If this value is used, the system maps the file into the process's virtual address space as an image file. However, the loader
	/// does not load the static imports or perform the other usual initialization steps. Use this flag when you want to load a DLL only
	/// to extract messages or resources from it.Unless the application depends on the file having the in-memory layout of an image, this
	/// value should be used with either LOAD_LIBRARY_AS_DATAFILE_EXCLUSIVE or LOAD_LIBRARY_AS_DATAFILE. For more information, see the
	/// Remarks section.Windows Server 2003 and Windows XP: This value is not supported until Windows Vista.
	/// </term>
	/// </item>
	/// <item>
	/// <term>LOAD_LIBRARY_SEARCH_APPLICATION_DIR0x00000200</term>
	/// <term>
	/// If this value is used, the application's installation directory is searched for the DLL and its dependencies. Directories in the
	/// standard search path are not searched. This value cannot be combined with LOAD_WITH_ALTERED_SEARCH_PATH.Windows 7, Windows Server
	/// 2008 R2, Windows Vista and Windows Server 2008: This value requires KB2533623 to be installed.Windows Server 2003 and Windows XP:
	/// This value is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>LOAD_LIBRARY_SEARCH_DEFAULT_DIRS0x00001000</term>
	/// <term>
	/// This value is a combination of LOAD_LIBRARY_SEARCH_APPLICATION_DIR, LOAD_LIBRARY_SEARCH_SYSTEM32, and
	/// LOAD_LIBRARY_SEARCH_USER_DIRS. Directories in the standard search path are not searched. This value cannot be combined with
	/// LOAD_WITH_ALTERED_SEARCH_PATH.This value represents the recommended maximum number of directories an application should include
	/// in its DLL search path.Windows 7, Windows Server 2008 R2, Windows Vista and Windows Server 2008: This value requires KB2533623 to
	/// be installed.Windows Server 2003 and Windows XP: This value is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>LOAD_LIBRARY_SEARCH_DLL_LOAD_DIR0x00000100</term>
	/// <term>
	/// If this value is used, the directory that contains the DLL is temporarily added to the beginning of the list of directories that
	/// are searched for the DLL's dependencies. Directories in the standard search path are not searched.The lpFileName parameter must
	/// specify a fully qualified path. This value cannot be combined with LOAD_WITH_ALTERED_SEARCH_PATH.For example, if Lib2.dll is a
	/// dependency of C:\Dir1\Lib1.dll, loading Lib1.dll with this value causes the system to search for Lib2.dll only in C:\Dir1. To
	/// search for Lib2.dll in C:\Dir1 and all of the directories in the DLL search path, combine this value with
	/// LOAD_LIBRARY_DEFAULT_DIRS.Windows 7, Windows Server 2008 R2, Windows Vista and Windows Server 2008: This value requires KB2533623
	/// to be installed.Windows Server 2003 and Windows XP: This value is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>LOAD_LIBRARY_SEARCH_SYSTEM320x00000800</term>
	/// <term>
	/// If this value is used, %windows%\system32 is searched for the DLL and its dependencies. Directories in the standard search path
	/// are not searched. This value cannot be combined with LOAD_WITH_ALTERED_SEARCH_PATH.Windows 7, Windows Server 2008 R2, Windows
	/// Vista and Windows Server 2008: This value requires KB2533623 to be installed.Windows Server 2003 and Windows XP: This value is
	/// not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>LOAD_LIBRARY_SEARCH_USER_DIRS0x00000400</term>
	/// <term>
	/// If this value is used, directories added using the AddDllDirectory or the SetDllDirectory function are searched for the DLL and
	/// its dependencies. If more than one directory has been added, the order in which the directories are searched is unspecified.
	/// Directories in the standard search path are not searched. This value cannot be combined with
	/// LOAD_WITH_ALTERED_SEARCH_PATH.Windows 7, Windows Server 2008 R2, Windows Vista and Windows Server
	/// 2008: This value requires KB2533623 to be installed.Windows Server 2003 and Windows XP: This value is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>LOAD_WITH_ALTERED_SEARCH_PATH0x00000008</term>
	/// <term>
	/// If this value is used and lpFileName specifies an absolute path, the system uses the alternate file search strategy discussed in
	/// the Remarks section to find associated executable modules that the specified module causes to be loaded. If this value is used
	/// and lpFileName specifies a relative path, the behavior is undefined.If this value is not used, or if lpFileName does not specify
	/// a path, the system uses the standard search strategy discussed in the Remarks section to find associated executable modules that
	/// the specified module causes to be loaded.This value cannot be combined with any LOAD_LIBRARY_SEARCH flag.
	/// </term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a handle to the loaded module.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// HMODULE WINAPI LoadLibraryEx( _In_ LPCTSTR lpFileName, _Reserved_ HANDLE hFile, _In_ DWORD dwFlags); https://msdn.microsoft.com/en-us/library/windows/desktop/ms684179(v=vs.85).aspx
	[DllImport(Lib.Kernel32, CharSet = CharSet.Auto, SetLastError = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
	[PInvokeData("LibLoaderAPI.h", MSDNShortId = "ms684179")]
	[SuppressUnmanagedCodeSecurity]
	public static extern SafeHINSTANCE LoadLibraryEx(string lpFileName, IntPtr hFile, [Optional] LoadLibraryExFlags dwFlags);

	/// <summary>
	/// Loads the specified module into the address space of the calling process. The specified module may cause other modules to be loaded.
	/// </summary>
	/// <param name="lpFileName">
	/// <para>
	/// A string that specifies the file name of the module to load. This name is not related to the name stored in a library module
	/// itself, as specified by the <c>LIBRARY</c> keyword in the module-definition (.def) file.
	/// </para>
	/// <para>
	/// The module can be a library module (a .dll file) or an executable module (an .exe file). If the specified module is an executable
	/// module, static imports are not loaded; instead, the module is loaded as if <c>DONT_RESOLVE_DLL_REFERENCES</c> was specified. See
	/// the dwFlags parameter for more information.
	/// </para>
	/// <para>
	/// If the string specifies a module name without a path and the file name extension is omitted, the function appends the default
	/// library extension .dll to the module name. To prevent the function from appending .dll to the module name, include a trailing
	/// point character (.) in the module name string.
	/// </para>
	/// <para>
	/// If the string specifies a fully qualified path, the function searches only that path for the module. When specifying a path, be
	/// sure to use backslashes (\), not forward slashes (/). For more information about paths, see Naming Files, Paths, and Namespaces.
	/// </para>
	/// <para>
	/// If the string specifies a module name without a path and more than one loaded module has the same base name and extension, the
	/// function returns a handle to the module that was loaded first.
	/// </para>
	/// <para>
	/// If the string specifies a module name without a path and a module of the same name is not already loaded, or if the string
	/// specifies a module name with a relative path, the function searches for the specified module. The function also searches for
	/// modules if loading the specified module causes the system to load other associated modules (that is, if the module has
	/// dependencies). The directories that are searched and the order in which they are searched depend on the specified path and the
	/// dwFlags parameter. For more information, see Remarks.
	/// </para>
	/// <para>If the function cannot find the module or one of its dependencies, the function fails.</para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>
	/// The action to be taken when loading the module. If no flags are specified, the behavior of this function is identical to that of
	/// the <c>LoadLibrary</c> function. This parameter can be one of the following values.
	/// </para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>DONT_RESOLVE_DLL_REFERENCES0x00000001</term>
	/// <term>
	/// If this value is used, and the executable module is a DLL, the system does not call DllMain for process and thread initialization
	/// and termination. Also, the system does not load additional executable modules that are referenced by the specified module.
	/// </term>
	/// </item>
	/// <item>
	/// <term>LOAD_IGNORE_CODE_AUTHZ_LEVEL0x00000010</term>
	/// <term>
	/// If this value is used, the system does not check AppLocker rules or apply Software Restriction Policies for the DLL. This action
	/// applies only to the DLL being loaded and not to its dependencies. This value is recommended for use in setup programs that must
	/// run extracted DLLs during installation.Windows Server 2008 R2 and Windows 7: On systems with KB2532445 installed, the caller must
	/// be running as &amp;quot;LocalSystem&amp;quot; or &amp;quot;TrustedInstaller&amp;quot;; otherwise the system ignores this flag.
	/// For more information, see &amp;quot;You can circumvent AppLocker rules by using an Office macro on a computer that is running
	/// Windows 7 or Windows Server 2008 R2&amp;quot; in the Help and Support Knowledge Base at
	/// http://support.microsoft.com/kb/2532445.Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: AppLocker was
	/// introduced in Windows 7 and Windows Server 2008 R2.
	/// </term>
	/// </item>
	/// <item>
	/// <term>LOAD_LIBRARY_AS_DATAFILE0x00000002</term>
	/// <term>
	/// If this value is used, the system maps the file into the calling process's virtual address space as if it were a data file.
	/// Nothing is done to execute or prepare to execute the mapped file. Therefore, you cannot call functions like GetModuleFileName,
	/// GetModuleHandle or GetProcAddress with this DLL. Using this value causes writes to read-only memory to raise an access violation.
	/// Use this flag when you want to load a DLL only to extract messages or resources from it.This value can be used with
	/// LOAD_LIBRARY_AS_IMAGE_RESOURCE. For more information, see Remarks.
	/// </term>
	/// </item>
	/// <item>
	/// <term>LOAD_LIBRARY_AS_DATAFILE_EXCLUSIVE0x00000040</term>
	/// <term>
	/// Similar to LOAD_LIBRARY_AS_DATAFILE, except that the DLL file is opened with exclusive write access for the calling process.
	/// Other processes cannot open the DLL file for write access while it is in use. However, the DLL can still be opened by other
	/// processes.This value can be used with LOAD_LIBRARY_AS_IMAGE_RESOURCE. For more information, see Remarks.Windows Server 2003 and
	/// Windows XP: This value is not supported until Windows Vista.
	/// </term>
	/// </item>
	/// <item>
	/// <term>LOAD_LIBRARY_AS_IMAGE_RESOURCE0x00000020</term>
	/// <term>
	/// If this value is used, the system maps the file into the process's virtual address space as an image file. However, the loader
	/// does not load the static imports or perform the other usual initialization steps. Use this flag when you want to load a DLL only
	/// to extract messages or resources from it.Unless the application depends on the file having the in-memory layout of an image, this
	/// value should be used with either LOAD_LIBRARY_AS_DATAFILE_EXCLUSIVE or LOAD_LIBRARY_AS_DATAFILE. For more information, see the
	/// Remarks section.Windows Server 2003 and Windows XP: This value is not supported until Windows Vista.
	/// </term>
	/// </item>
	/// <item>
	/// <term>LOAD_LIBRARY_SEARCH_APPLICATION_DIR0x00000200</term>
	/// <term>
	/// If this value is used, the application's installation directory is searched for the DLL and its dependencies. Directories in the
	/// standard search path are not searched. This value cannot be combined with LOAD_WITH_ALTERED_SEARCH_PATH.Windows 7, Windows Server
	/// 2008 R2, Windows Vista and Windows Server 2008: This value requires KB2533623 to be installed.Windows Server 2003 and Windows XP:
	/// This value is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>LOAD_LIBRARY_SEARCH_DEFAULT_DIRS0x00001000</term>
	/// <term>
	/// This value is a combination of LOAD_LIBRARY_SEARCH_APPLICATION_DIR, LOAD_LIBRARY_SEARCH_SYSTEM32, and
	/// LOAD_LIBRARY_SEARCH_USER_DIRS. Directories in the standard search path are not searched. This value cannot be combined with
	/// LOAD_WITH_ALTERED_SEARCH_PATH.This value represents the recommended maximum number of directories an application should include
	/// in its DLL search path.Windows 7, Windows Server 2008 R2, Windows Vista and Windows Server 2008: This value requires KB2533623 to
	/// be installed.Windows Server 2003 and Windows XP: This value is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>LOAD_LIBRARY_SEARCH_DLL_LOAD_DIR0x00000100</term>
	/// <term>
	/// If this value is used, the directory that contains the DLL is temporarily added to the beginning of the list of directories that
	/// are searched for the DLL's dependencies. Directories in the standard search path are not searched.The lpFileName parameter must
	/// specify a fully qualified path. This value cannot be combined with LOAD_WITH_ALTERED_SEARCH_PATH.For example, if Lib2.dll is a
	/// dependency of C:\Dir1\Lib1.dll, loading Lib1.dll with this value causes the system to search for Lib2.dll only in C:\Dir1. To
	/// search for Lib2.dll in C:\Dir1 and all of the directories in the DLL search path, combine this value with
	/// LOAD_LIBRARY_DEFAULT_DIRS.Windows 7, Windows Server 2008 R2, Windows Vista and Windows Server 2008: This value requires KB2533623
	/// to be installed.Windows Server 2003 and Windows XP: This value is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>LOAD_LIBRARY_SEARCH_SYSTEM320x00000800</term>
	/// <term>
	/// If this value is used, %windows%\system32 is searched for the DLL and its dependencies. Directories in the standard search path
	/// are not searched. This value cannot be combined with LOAD_WITH_ALTERED_SEARCH_PATH.Windows 7, Windows Server 2008 R2, Windows
	/// Vista and Windows Server 2008: This value requires KB2533623 to be installed.Windows Server 2003 and Windows XP: This value is
	/// not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>LOAD_LIBRARY_SEARCH_USER_DIRS0x00000400</term>
	/// <term>
	/// If this value is used, directories added using the AddDllDirectory or the SetDllDirectory function are searched for the DLL and
	/// its dependencies. If more than one directory has been added, the order in which the directories are searched is unspecified.
	/// Directories in the standard search path are not searched. This value cannot be combined with
	/// LOAD_WITH_ALTERED_SEARCH_PATH.Windows 7, Windows Server 2008 R2, Windows Vista and Windows Server
	/// 2008: This value requires KB2533623 to be installed.Windows Server 2003 and Windows XP: This value is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>LOAD_WITH_ALTERED_SEARCH_PATH0x00000008</term>
	/// <term>
	/// If this value is used and lpFileName specifies an absolute path, the system uses the alternate file search strategy discussed in
	/// the Remarks section to find associated executable modules that the specified module causes to be loaded. If this value is used
	/// and lpFileName specifies a relative path, the behavior is undefined.If this value is not used, or if lpFileName does not specify
	/// a path, the system uses the standard search strategy discussed in the Remarks section to find associated executable modules that
	/// the specified module causes to be loaded.This value cannot be combined with any LOAD_LIBRARY_SEARCH flag.
	/// </term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a handle to the loaded module.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// HMODULE WINAPI LoadLibraryEx( _In_ LPCTSTR lpFileName, _Reserved_ HANDLE hFile, _In_ DWORD dwFlags); https://msdn.microsoft.com/en-us/library/windows/desktop/ms684179(v=vs.85).aspx
	[PInvokeData("LibLoaderAPI.h", MSDNShortId = "ms684179")]
	[SuppressUnmanagedCodeSecurity]
	public static SafeHINSTANCE LoadLibraryEx(string lpFileName, LoadLibraryExFlags dwFlags = 0) => LoadLibraryEx(lpFileName, IntPtr.Zero, dwFlags);

	/// <summary>Retrieves a handle that can be used to obtain a pointer to the first byte of the specified resource in memory.</summary>
	/// <param name="hModule">
	/// <para>Type: <c>HMODULE</c></para>
	/// <para>
	/// A handle to the module whose executable file contains the resource. If hModule is <c>NULL</c>, the system loads the resource from
	/// the module that was used to create the current process.
	/// </para>
	/// </param>
	/// <param name="hResInfo">
	/// <para>Type: <c>HRSRC</c></para>
	/// <para>A handle to the resource to be loaded. This handle is returned by the <c>FindResource</c> or <c>FindResourceEx</c> function.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HGLOBAL</c></para>
	/// <para>If the function succeeds, the return value is a handle to the data associated with the resource.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// HGLOBAL WINAPI LoadResource( _In_opt_ HMODULE hModule, _In_ HRSRC hResInfo); https://msdn.microsoft.com/en-us/library/windows/desktop/ms648046(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("Winbase.h", MSDNShortId = "ms648046")]
	[SuppressUnmanagedCodeSecurity]
	public static extern HRSRCDATA LoadResource(HINSTANCE hModule, HRSRC hResInfo);

	/// <summary>Retrieves a pointer to the specified resource in memory.</summary>
	/// <param name="hResData">
	/// <para>Type: <c>HGLOBAL</c></para>
	/// <para>
	/// A handle to the resource to be accessed. The <c>LoadResource</c> function returns this handle. Note that this parameter is listed
	/// as an <c>HGLOBAL</c> variable only for backward compatibility. Do not pass any value as a parameter other than a successful
	/// return value from the <c>LoadResource</c> function.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>LPVOID</c></para>
	/// <para>
	/// If the loaded resource is available, the return value is a pointer to the first byte of the resource; otherwise, it is <c>NULL</c>.
	/// </para>
	/// </returns>
	// LPVOID WINAPI LockResource( _In_ HGLOBAL hResData); https://msdn.microsoft.com/en-us/library/windows/desktop/ms648047(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Winbase.h", MSDNShortId = "ms648047")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr LockResource(HRSRCDATA hResData);

	/// <summary>Determines whether the specified function in a delay-loaded DLL is available on the system.</summary>
	/// <param name="hParentModule">
	/// A handle to the calling module. Desktop applications can use the GetModuleHandle or GetModuleHandleEx function to get this
	/// handle. Windows Store apps should set this parameter to <c>static_cast&lt;HMODULE&gt;(&amp;__ImageBase)</c>.
	/// </param>
	/// <param name="lpDllName">
	/// <para>The file name of the delay-loaded DLL that exports the specified function. This parameter is case-insensitive.</para>
	/// <para>
	/// Windows Store apps should specify API sets, rather than monolithic DLLs. For example, api-ms-win-core-memory-l1-1-1.dll, rather
	/// than kernel32.dll.
	/// </para>
	/// </param>
	/// <param name="lpProcName">The name of the function to query. This parameter is case-sensitive.</param>
	/// <param name="Reserved">This parameter is reserved and must be zero (0).</param>
	/// <returns>
	/// TRUE if the specified function is available on the system. If the specified function is not available on the system, this
	/// function returns FALSE. To get extended error information, call GetLastError.
	/// </returns>
	/// <remarks>
	/// <para>
	/// A delay-loaded DLL is statically linked but not actually loaded into memory until the running application references a symbol
	/// exported by that DLL. Applications often delay load DLLs that contain functions the application might call only rarely or not at
	/// all, because the DLL is only loaded when it is needed instead of being loaded at application startup like other statically linked
	/// DLLs. This helps improve application performance, especially during initialization. A delay-load DLL is specified at link time
	/// with the /DELAYLOAD (Delay Load Import) linker option.
	/// </para>
	/// <para>
	/// Applications that target multiple versions of Windows or multiple Windows device families also rely on delay-loaded DLLs to make
	/// visible extra features when they are available.
	/// </para>
	/// <para>
	/// A desktop application can use delayed loading as an alternative to runtime dynamic linking that uses LoadLibrary or LoadLibraryEx
	/// to load a DLL and GetProcAddress to get a pointer to a function. A Windows Store app cannot use <c>LoadLibrary</c> or
	/// <c>LoadLibraryEx</c>, so to get the benefits to runtime dynamic linking, a Windows Store app must use the delayed loading mechanism.
	/// </para>
	/// <para>
	/// To check whether a function in a delay-loaded DLL is available on the system, the application calls
	/// <c>QueryOptionalDelayLoadedAPI</c> with the specified function. If <c>QueryOptionalDelayLoadedAPI</c> succeeds, the application
	/// can safely call the specified function.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following example shows how to use <c>QueryOptionalDelayLoadedAPI</c> to determine whether the VirtualAllocEx function is
	/// available on the system.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/libloaderapi2/nf-libloaderapi2-queryoptionaldelayloadedapi
	// BOOL QueryOptionalDelayLoadedAPI( HMODULE hParentModule, LPCSTR lpDllName, LPCSTR lpProcName, DWORD Reserved );
	[DllImport(Lib.KernelBase, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("libloaderapi2.h", MSDNShortId = "43690689-4372-48ae-ac6d-230250f05f7c")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool QueryOptionalDelayLoadedAPI(HINSTANCE hParentModule, [MarshalAs(UnmanagedType.LPStr)] string lpDllName, [MarshalAs(UnmanagedType.LPStr)] string lpProcName, uint Reserved = 0);

	/// <summary>Removes a directory that was added to the process DLL search path by using <c>AddDllDirectory</c>.</summary>
	/// <param name="Cookie">The cookie returned by <c>AddDllDirectory</c> when the directory was added to the search path.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// BOOL WINAPI RemoveDllDirectory( _In_ DLL_DIRECTORY_COOKIE Cookie); https://msdn.microsoft.com/en-us/library/windows/desktop/hh310514(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("LibLoaderAPI.h", MSDNShortId = "hh310514")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool RemoveDllDirectory(IntPtr Cookie);

	/// <summary>
	/// Specifies a default set of directories to search when the calling process loads a DLL. This search path is used when
	/// <c>LoadLibraryEx</c> is called with no <c>LOAD_LIBRARY_SEARCH</c> flags.
	/// </summary>
	/// <param name="DirectoryFlags">
	/// <para>The directories to search. This parameter can be any combination of the following values.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>LOAD_LIBRARY_SEARCH_APPLICATION_DIR0x00000200</term>
	/// <term>If this value is used, the application's installation directory is searched.</term>
	/// </item>
	/// <item>
	/// <term>LOAD_LIBRARY_SEARCH_DEFAULT_DIRS0x00001000</term>
	/// <term>
	/// This value is a combination of LOAD_LIBRARY_SEARCH_APPLICATION_DIR, LOAD_LIBRARY_SEARCH_SYSTEM32, and
	/// LOAD_LIBRARY_SEARCH_USER_DIRS.This value represents the recommended maximum number of directories an application should include
	/// in its DLL search path.
	/// </term>
	/// </item>
	/// <item>
	/// <term>LOAD_LIBRARY_SEARCH_SYSTEM320x00000800</term>
	/// <term>If this value is used, %windows%\system32 is searched.</term>
	/// </item>
	/// <item>
	/// <term>LOAD_LIBRARY_SEARCH_USER_DIRS0x00000400</term>
	/// <term>
	/// If this value is used, any path explicitly added using the AddDllDirectory or SetDllDirectory function is searched. If more than
	/// one directory has been added, the order in which those directories are searched is unspecified.
	/// </term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// BOOL WINAPI SetDefaultDllDirectories( _In_ DWORD DirectoryFlags); https://msdn.microsoft.com/en-us/library/windows/desktop/hh310515(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("LibLoaderAPI.h", MSDNShortId = "hh310515")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetDefaultDllDirectories(LoadLibraryExFlags DirectoryFlags);

	/// <summary>Retrieves the size, in bytes, of the specified resource.</summary>
	/// <param name="hModule">
	/// <para>Type: <c>HMODULE</c></para>
	/// <para>A handle to the module whose executable file contains the resource.</para>
	/// </param>
	/// <param name="hResInfo">
	/// <para>Type: <c>HRSRC</c></para>
	/// <para>A handle to the resource. This handle must be created by using the <c>FindResource</c> or <c>FindResourceEx</c> function.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>DWORD</c></para>
	/// <para>If the function succeeds, the return value is the number of bytes in the resource.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// DWORD WINAPI SizeofResource( _In_opt_ HMODULE hModule, _In_ HRSRC hResInfo); https://msdn.microsoft.com/en-us/library/windows/desktop/ms648048(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("Winbase.h", MSDNShortId = "ms648048")]
	public static extern uint SizeofResource(HINSTANCE hModule, HRSRC hResInfo);

	private static IList<ResourceId> EnumResWrapper(Func<EnumResNameProc, bool> f)
	{
		var list = new List<ResourceId>();
		Win32Error.ThrowLastErrorIfFalse(f((m, t, name, l) => { list.Add(name); return true; }));
		return list;
	}

	/// <summary>Provides a handle to a resource.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct HRSRC : IHandle
	{
		private readonly IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HRSRC"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HRSRC(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HRSRC"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HRSRC NULL => new(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="HRSRC"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HRSRC h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HRSRC"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HRSRC(IntPtr h) => new(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HRSRC h1, HRSRC h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HRSRC h1, HRSRC h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj is HRSRC h && handle == h.handle;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a handle to resource data.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct HRSRCDATA : IHandle
	{
		private readonly IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HRSRCDATA"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HRSRCDATA(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HRSRCDATA"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HRSRCDATA NULL => new(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="HRSRCDATA"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HRSRCDATA h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HRSRCDATA"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HRSRCDATA(IntPtr h) => new(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HRSRCDATA h1, HRSRCDATA h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HRSRCDATA h1, HRSRCDATA h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj is HRSRCDATA h && handle == h.handle;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a <see cref="SafeHandle"/> to a that releases a created HINSTANCE instance at disposal using FreeLibrary.</summary>
	[PInvokeData("LibLoaderAPI.h")]
	public class SafeHINSTANCE : SafeHANDLE
	{
		/// <summary>Initializes a new instance of the <see cref="HINSTANCE"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		public SafeHINSTANCE(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		private SafeHINSTANCE() : base() { }

		/// <summary>
		/// Gets a value indicating whether the module was loaded as a data file (LOAD_LIBRARY_AS_DATAFILE or
		/// LOAD_LIBRARY_AS_DATAFILE_EXCLUSIVE). Equivalent to LDR_IS_DATAFILE.
		/// </summary>
		public bool IsDataFile => (handle.ToInt64() & 1) != 0;

		/// <summary>
		/// Gets a value indicating whether the module was loaded as an image file (LOAD_LIBRARY_AS_IMAGE_RESOURCE). Equivalent to LDR_IS_IMAGEMAPPING.
		/// </summary>
		public bool IsImageMapping => (handle.ToInt64() & 2) != 0;

		/// <summary>
		/// Gets a value indicating whether the module was loaded as either a data file or an image file. Equivalent to LDR_IS_RESOURCE.
		/// </summary>
		public bool IsResource => (handle.ToInt64() & 3) != 0;

		/// <summary>Performs an implicit conversion from <see cref="SafeHINSTANCE"/> to <see cref="HINSTANCE"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HINSTANCE(SafeHINSTANCE h) => h.handle;

		/// <summary>Retrieves the address of an exported function or variable from the specified dynamic-link library (DLL).</summary>
		/// <param name="procName">The function or variable name.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is the address of the exported function or variable.</para>
		/// <para>If the function fails, an exception with the error is thrown.</para>
		/// </returns>
		public IntPtr GetProcAddress(string procName) => Win32Error.ThrowLastErrorIfNull(Kernel32.GetProcAddress(handle, procName));

		/// <summary>Retrieves the address of an exported function or variable from the specified dynamic-link library (DLL).</summary>
		/// <param name="ordinal">The function's ordinal value.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is the address of the exported function or variable.</para>
		/// <para>If the function fails, an exception with the error is thrown.</para>
		/// </returns>
		public IntPtr GetProcAddress(int ordinal) => GetProcAddress($"#{ordinal}");

		/// <summary>Retrieves a delegate for an exported function or variable from the specified dynamic-link library (DLL).</summary>
		/// <typeparam name="T">The delegate type to which to convert that function pointer.</typeparam>
		/// <param name="procName">The function or variable name.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is the exported function or variable's delegate.</para>
		/// <para>If the function fails, an exception with the error is thrown.</para>
		/// </returns>
		public T GetProcAddress<T>(string procName) where T : Delegate
		{
			var ptr = Win32Error.ThrowLastErrorIfNull(Kernel32.GetProcAddress(handle, procName));
			return (T)Marshal.GetDelegateForFunctionPointer(ptr, typeof(T));
		}

		/// <summary>Retrieves a delegate for an exported function or variable from the specified dynamic-link library (DLL).</summary>
		/// <typeparam name="T">The delegate type to which to convert that function pointer.</typeparam>
		/// <param name="ordinal">The function's ordinal value.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is the exported function or variable's delegate.</para>
		/// <para>If the function fails, an exception with the error is thrown.</para>
		/// </returns>
		public T GetProcAddress<T>(int ordinal) where T : Delegate => GetProcAddress<T>($"#{ordinal}");

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() => FreeLibrary(this);
	}
}