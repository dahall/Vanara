using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Security;
using Vanara.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Kernel32
	{
		/// <summary>Flags that may be passed to the <see cref="LoadLibraryEx"/> function.</summary>
		[PInvokeData("libloaderapi.h")]
		[Flags]
		public enum LoadLibraryExFlags
		{
			/// <summary>Define no flags, the function will behave as <see cref="LoadLibrary"/> does.</summary>
			None = 0,

			/// <summary>
			/// If this value is used, and the executable module is a DLL, the system does not call DllMain for process and thread initialization and
			/// termination. Also, the system does not load additional executable modules that are referenced by the specified module.
			/// </summary>
			/// <remarks>
			/// Do not use this value; it is provided only for backward compatibility. If you are planning to access only data or resources in the DLL, use 
			/// <see cref="LOAD_LIBRARY_AS_DATAFILE_EXCLUSIVE"/> or <see cref="LOAD_LIBRARY_AS_IMAGE_RESOURCE"/> or both. Otherwise, load the library as a DLL or
			/// executable module using the LoadLibrary function.
			/// </remarks>
			DONT_RESOLVE_DLL_REFERENCES = 0x00000001,

			/// <summary>
			/// If this value is used, the system does not check AppLocker rules or apply Software Restriction Policies for the DLL. This action applies only to
			/// the DLL being loaded and not to its dependencies. This value is recommended for use in setup programs that must run extracted DLLs during installation.
			/// </summary>
			/// <remarks>
			/// <para>
			/// Windows Server 2008 R2 and Windows 7: On systems with KB2532445 installed, the caller must be running as "LocalSystem" or "TrustedInstaller";
			/// otherwise the system ignores this flag. For more information, see "You can circumvent AppLocker rules by using an Office macro on a computer that
			/// is running Windows 7 or Windows Server 2008 R2" in the Help and Support Knowledge Base at http://support.microsoft.com/kb/2532445.
			/// </para>
			/// <para>
			/// Windows Server 2008, Windows Vista, Windows Server 2003, and Windows XP: AppLocker was introduced in Windows 7 and Windows Server 2008 R2.
			/// </para>
			/// </remarks>
			LOAD_IGNORE_CODE_AUTHZ_LEVEL = 0x00000010,

			/// <summary>
			/// If this value is used, the system maps the file into the calling process's virtual address space as if it were a data file. Nothing is done to
			/// execute or prepare to execute the mapped file. Therefore, you cannot call functions like GetModuleFileName, GetModuleHandle or GetProcAddress
			/// with this DLL. Using this value causes writes to read-only memory to raise an access violation. Use this flag when you want to load a DLL only to
			/// extract messages or resources from it.
			/// <para>This value can be used with <see cref="LOAD_LIBRARY_AS_IMAGE_RESOURCE"/>.</para>
			/// </summary>
			LOAD_LIBRARY_AS_DATAFILE = 0x00000002,

			/// <summary>
			/// Similar to <see cref="LOAD_LIBRARY_AS_DATAFILE"/>, except that the DLL file is opened with exclusive write access for the calling process. Other
			/// processes cannot open the DLL file for write access while it is in use. However, the DLL can still be opened by other processes.
			/// <para>This value can be used with <see cref="LOAD_LIBRARY_AS_IMAGE_RESOURCE"/>.</para>
			/// </summary>
			/// <remarks>Windows Server 2003 and Windows XP: This value is not supported until Windows Vista.</remarks>
			LOAD_LIBRARY_AS_DATAFILE_EXCLUSIVE = 0x00000040,

			/// <summary>
			/// If this value is used, the system maps the file into the process's virtual address space as an image file. However, the loader does not load the
			/// static imports or perform the other usual initialization steps. Use this flag when you want to load a DLL only to extract messages or resources
			/// from it.
			/// <para>
			/// Unless the application depends on the file having the in-memory layout of an image, this value should be used with either 
			/// <see cref="LOAD_LIBRARY_AS_DATAFILE_EXCLUSIVE"/> or <see cref="LOAD_LIBRARY_AS_DATAFILE"/>. For more information, see the Remarks section.
			/// </para>
			/// </summary>
			LOAD_LIBRARY_AS_IMAGE_RESOURCE = 0x00000020,

			/// <summary>
			/// If this value is used, the application's installation directory is searched for the DLL and its dependencies. Directories in the standard search
			/// path are not searched. This value cannot be combined with <see cref="LOAD_WITH_ALTERED_SEARCH_PATH"/>.
			/// </summary>
			/// <remarks>
			/// Windows 7, Windows Server 2008 R2, Windows Vista, and Windows Server 2008: This value requires KB2533623 to be installed.
			/// <para>Windows Server 2003 and Windows XP: This value is not supported.</para>
			/// </remarks>
			LOAD_LIBRARY_SEARCH_APPLICATION_DIR = 0x00000200,

			/// <summary>
			/// This value is a combination of <see cref="LOAD_LIBRARY_SEARCH_APPLICATION_DIR"/>, <see cref="LOAD_LIBRARY_SEARCH_SYSTEM32"/>, and
			/// <see cref="LOAD_LIBRARY_SEARCH_USER_DIRS"/>. Directories in the standard search path are not searched. This value cannot be combined with <see cref="LOAD_WITH_ALTERED_SEARCH_PATH"/>.
			/// <para>This value represents the recommended maximum number of directories an application should include in its DLL search path.</para>
			/// </summary>
			/// <remarks>
			/// Windows 7, Windows Server 2008 R2, Windows Vista, and Windows Server 2008: This value requires KB2533623 to be installed.
			/// <para>Windows Server 2003 and Windows XP: This value is not supported.</para>
			/// </remarks>
			LOAD_LIBRARY_SEARCH_DEFAULT_DIRS = 0x00001000,

			/// <summary>
			/// If this value is used, the directory that contains the DLL is temporarily added to the beginning of the list of directories that are searched for
			/// the DLL's dependencies. Directories in the standard search path are not searched.
			/// <para>The lpFileName parameter must specify a fully qualified path. This value cannot be combined with <see cref="LOAD_WITH_ALTERED_SEARCH_PATH"/>.</para>
			/// <para>
			/// For example, if Lib2.dll is a dependency of C:\Dir1\Lib1.dll, loading Lib1.dll with this value causes the system to search for Lib2.dll only in
			/// C:\Dir1. To search for Lib2.dll in C:\Dir1 and all of the directories in the DLL search path, combine this value with <see cref="LOAD_LIBRARY_SEARCH_DEFAULT_DIRS"/>.
			/// </para>
			/// </summary>
			/// <remarks>
			/// Windows 7, Windows Server 2008 R2, Windows Vista, and Windows Server 2008: This value requires KB2533623 to be installed.
			/// <para>Windows Server 2003 and Windows XP: This value is not supported.</para>
			/// </remarks>
			LOAD_LIBRARY_SEARCH_DLL_LOAD_DIR = 0x00000100,

			/// <summary>
			/// If this value is used, %windows%\system32 is searched for the DLL and its dependencies. Directories in the standard search path are not searched.
			/// This value cannot be combined with <see cref="LOAD_WITH_ALTERED_SEARCH_PATH"/>.
			/// </summary>
			/// <remarks>
			/// Windows 7, Windows Server 2008 R2, Windows Vista, and Windows Server 2008: This value requires KB2533623 to be installed.
			/// <para>Windows Server 2003 and Windows XP: This value is not supported.</para>
			/// </remarks>
			LOAD_LIBRARY_SEARCH_SYSTEM32 = 0x00000800,

			/// <summary>
			/// If this value is used, directories added using the AddDllDirectory or the SetDllDirectory function are searched for the DLL and its dependencies.
			/// If more than one directory has been added, the order in which the directories are searched is unspecified. Directories in the standard search
			/// path are not searched. This value cannot be combined with <see cref="LOAD_WITH_ALTERED_SEARCH_PATH"/>.
			/// </summary>
			/// <remarks>
			/// Windows 7, Windows Server 2008 R2, Windows Vista, and Windows Server 2008: This value requires KB2533623 to be installed.
			/// <para>Windows Server 2003 and Windows XP: This value is not supported.</para>
			/// </remarks>
			LOAD_LIBRARY_SEARCH_USER_DIRS = 0x00000400,

			/// <summary>
			/// If this value is used and lpFileName specifies an absolute path, the system uses the alternate file search strategy discussed in the Remarks
			/// section to find associated executable modules that the specified module causes to be loaded. If this value is used and lpFileName specifies a
			/// relative path, the behavior is undefined.
			/// <para>
			/// If this value is not used, or if lpFileName does not specify a path, the system uses the standard search strategy discussed in the Remarks
			/// section to find associated executable modules that the specified module causes to be loaded.
			/// </para>
			/// <para>This value cannot be combined with any LOAD_LIBRARY_SEARCH flag.</para>
			/// </summary>
			LOAD_WITH_ALTERED_SEARCH_PATH = 0x00000008
		}

		/// <summary>
		/// Loads the specified module into the address space of the calling process. The specified module may cause other modules to be loaded.
		/// <para>For additional load options, use the LoadLibraryEx function.</para>
		/// </summary>
		/// <param name="lpFileName">
		/// The name of the module. This can be either a library module (a .dll file) or an executable module (an .exe file). The name specified is the file name
		/// of the module and is not related to the name stored in the library module itself, as specified by the LIBRARY keyword in the module-definition (.def) file.
		/// <para>If the string specifies a full path, the function searches only that path for the module.</para>
		/// <para>If the string specifies a relative path or a module name without a path, the function uses a standard search strategy to find the module.</para>
		/// <para>If the function cannot find the module, the function fails. When specifying a path, be sure to use backslashes (\), not forward slashes (/).</para>
		/// <para>
		/// If the string specifies a module name without a path and the file name extension is omitted, the function appends the default library extension .dll
		/// to the module name. To prevent the function from appending .dll to the module name, include a trailing point character (.) in the module name string.
		/// </para>
		/// </param>
		/// <returns>
		/// If the function succeeds, the return value is a handle to the loaded module.
		/// <para>If the function fails, the return value is an invalid handle. To get extended error information, call GetLastError.</para>
		/// </returns>
		[PInvokeData("LibLoaderAPI.h", MSDNShortId = "ms684175")]
		[DllImport(Lib.Kernel32, CharSet = CharSet.Auto, SetLastError = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern IntPtr LoadLibrary([In, MarshalAs(UnmanagedType.LPTStr)] string lpFileName);

		/// <summary>Loads the specified module into the address space of the calling process. The specified module may cause other modules to be loaded.</summary>
		/// <param name="lpFileName">
		/// <para>
		/// A string that specifies the file name of the module to load. This name is not related to the name stored in a library module itself, as specified by
		/// the LIBRARY keyword in the module-definition (.def) file.
		/// </para>
		/// <para>
		/// The module can be a library module (a .dll file) or an executable module (an .exe file). If the specified module is an executable module, static
		/// imports are not loaded; instead, the module is loaded as if <see cref="LoadLibraryExFlags.DONT_RESOLVE_DLL_REFERENCES"/> was specified. See the
		/// <paramref name="dwFlags"/> parameter for more information.
		/// </para>
		/// <para>
		/// If the string specifies a module name without a path and the file name extension is omitted, the function appends the default library extension .dll
		/// to the module name. To prevent the function from appending .dll to the module name, include a trailing point character (.) in the module name string.
		/// </para>
		/// <para>
		/// If the string specifies a fully qualified path, the function searches only that path for the module. When specifying a path, be sure to use
		/// backslashes (\), not forward slashes (/). For more information about paths, see Naming Files, Paths, and Namespaces.
		/// </para>
		/// <para>
		/// If the string specifies a module name without a path and more than one loaded module has the same base name and extension, the function returns a
		/// handle to the module that was loaded first.
		/// </para>
		/// <para>
		/// If the string specifies a module name without a path and a module of the same name is not already loaded, or if the string specifies a module name
		/// with a relative path, the function searches for the specified module. The function also searches for modules if loading the specified module causes
		/// the system to load other associated modules (that is, if the module has dependencies). The directories that are searched and the order in which they
		/// are searched depend on the specified path and the dwFlags parameter.
		/// </para>
		/// <para>If the function cannot find the module or one of its dependencies, the function fails.</para>
		/// </param>
		/// <param name="hFile">This parameter is reserved for future use. It must be <see langword="null"/>.</param>
		/// <param name="dwFlags">
		/// The action to be taken when loading the module. If <see cref="LoadLibraryExFlags.None"/> is specified, the behavior of this function is identical to
		/// that of the LoadLibrary function.
		/// </param>
		/// <returns>
		/// If the function succeeds, the return value is a handle to the loaded module.
		/// <para>If the function fails, the return value is an invalid handle. To get extended error information, call GetLastError.</para>
		/// </returns>
		[PInvokeData("LibLoaderAPI.h", MSDNShortId = "ms683182")]
		[DllImport(Lib.Kernel32, CharSet = CharSet.Auto, SetLastError = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
		[SuppressUnmanagedCodeSecurity]
		public static extern IntPtr LoadLibraryEx([In, MarshalAs(UnmanagedType.LPTStr)] string lpFileName, IntPtr hFile,
			LoadLibraryExFlags dwFlags);

		/// <summary>A safe handle for HMODULE.</summary>
		/// <seealso cref="GenericSafeHandle"/>
		[PInvokeData("LibLoaderAPI.h")]
		public class SafeLibraryHandle : GenericSafeHandle
		{
			/// <summary>Initializes a new instance of the <see cref="Vanara.PInvoke.SafeLibraryHandle"/> class.</summary>
			public SafeLibraryHandle() : this(IntPtr.Zero) { }

			/// <summary>Initializes a new instance of the <see cref="Vanara.PInvoke.SafeLibraryHandle"/> class.</summary>
			/// <param name="fileName">
			/// <para>
			/// A string that specifies the file name of the module to load. This name is not related to the name stored in a library module itself, as specified
			/// by the LIBRARY keyword in the module-definition (.def) file.
			/// </para>
			/// <para>
			/// The module can be a library module (a .dll file) or an executable module (an .exe file). If the specified module is an executable module, static
			/// imports are not loaded; instead, the module is loaded as if <see cref="LoadLibraryExFlags.DONT_RESOLVE_DLL_REFERENCES"/> was specified. See the
			/// <paramref name="flags"/> parameter for more information.
			/// </para>
			/// <para>
			/// If the string specifies a module name without a path and the file name extension is omitted, the function appends the default library extension
			/// .dll to the module name. To prevent the function from appending .dll to the module name, include a trailing point character (.) in the module
			/// name string.
			/// </para>
			/// <para>
			/// If the string specifies a fully qualified path, the function searches only that path for the module. When specifying a path, be sure to use
			/// backslashes (\), not forward slashes (/). For more information about paths, see Naming Files, Paths, and Namespaces.
			/// </para>
			/// <para>
			/// If the string specifies a module name without a path and more than one loaded module has the same base name and extension, the function returns a
			/// handle to the module that was loaded first.
			/// </para>
			/// <para>
			/// If the string specifies a module name without a path and a module of the same name is not already loaded, or if the string specifies a module
			/// name with a relative path, the function searches for the specified module. The function also searches for modules if loading the specified module
			/// causes the system to load other associated modules (that is, if the module has dependencies). The directories that are searched and the order in
			/// which they are searched depend on the specified path and the dwFlags parameter.
			/// </para>
			/// <para>If the function cannot find the module or one of its dependencies, the function fails.</para>
			/// </param>
			/// <param name="flags">The action to be taken when loading the module.</param>
			public SafeLibraryHandle(string fileName, LoadLibraryExFlags flags = 0) : base(FreeLibrary)
			{
				var hLib = LoadLibraryEx(fileName, IntPtr.Zero, flags);
				if (hLib == IntPtr.Zero)
					throw new Win32Exception();
				SetHandle(hLib);
			}

			/// <summary>Initializes a new instance of the <see cref="Vanara.PInvoke.SafeLibraryHandle"/> class.</summary>
			/// <param name="handle">An existing handle created by <see cref="LoadLibrary"/> or <see cref="LoadLibraryEx"/>.</param>
			/// <param name="own">if set to <c>true</c> calls <see cref="FreeLibrary"/> on disposal.</param>
			public SafeLibraryHandle(IntPtr handle, bool own = true) : base(handle, FreeLibrary, own) { }

			/// <summary>A handle that may be used in place of <see cref="IntPtr.Zero"/>.</summary>
			public static SafeLibraryHandle Null { get; } = new SafeLibraryHandle(IntPtr.Zero);
		}
	}
}