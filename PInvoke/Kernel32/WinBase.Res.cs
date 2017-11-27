using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;

namespace Vanara.PInvoke
{
	public static partial class Kernel32
	{
		/// <summary>
		/// An application-defined callback function used with the EnumResourceNames and EnumResourceNamesEx functions. It receives the type and name of a
		/// resource. The ENUMRESNAMEPROC type defines a pointer to this callback function. EnumResNameProc is a placeholder for the application-defined function name.
		/// </summary>
		/// <param name="hModule">
		/// A handle to the module whose executable file contains the resources that are being enumerated. If this parameter is NULL, the function enumerates the
		/// resource names in the module used to create the current process.
		/// </param>
		/// <param name="lpszType">
		/// The type of resource for which the name is being enumerated. Alternately, rather than a pointer, this parameter can be MAKEINTRESOURCE(ID), where ID
		/// is an integer value representing a predefined resource type. For standard resource types, see Resource Types. For more information, see the Remarks
		/// section below.
		/// </param>
		/// <param name="lpszName">
		/// The name of a resource of the type being enumerated. Alternately, rather than a pointer, this parameter can be MAKEINTRESOURCE(ID), where ID is the
		/// integer identifier of the resource. For more information, see the Remarks section below.
		/// </param>
		/// <param name="lParam">
		/// An application-defined parameter passed to the EnumResourceNames or EnumResourceNamesEx function. This parameter can be used in error checking.
		/// </param>
		/// <returns>Returns TRUE to continue enumeration or FALSE to stop enumeration.</returns>
		[UnmanagedFunctionPointer(CallingConvention.Winapi, SetLastError = true, CharSet = CharSet.Unicode)]
		[SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("winbase.h")]
		public delegate bool EnumResNameProc(IntPtr hModule, string lpszType, string lpszName, IntPtr lParam);

		[UnmanagedFunctionPointer(CallingConvention.Winapi, SetLastError = true, CharSet = CharSet.Unicode)]
		[SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("winbase.h")]
		private delegate bool EnumResNameProcManaged(IntPtr hModule, IntPtr lpszType, IntPtr lpszName, ResList lParam);

		/// <summary>
		/// Enumerates resources of a specified type within a binary module. For Windows Vista and later, this is typically a language-neutral Portable
		/// Executable (LN file), and the enumeration will also include resources from the corresponding language-specific resource files (.mui files) that
		/// contain localizable language resources. It is also possible for hModule to specify an .mui file, in which case only that file is searched for resources.
		/// </summary>
		/// <param name="hModule">
		/// A handle to a module to be searched. Starting with Windows Vista, if this is an LN file, then appropriate .mui files (if any exist) are included in
		/// the search.
		/// <para>If this parameter is NULL, that is equivalent to passing in a handle to the module used to create the current process.</para>
		/// </param>
		/// <param name="lpszType">
		/// The type of the resource for which the name is being enumerated. Alternately, rather than a pointer, this parameter can be MAKEINTRESOURCE(ID), where
		/// ID is an integer value representing a predefined resource type.
		/// </param>
		/// <param name="lpEnumFunc">A pointer to the callback function to be called for each enumerated resource name or ID.</param>
		/// <param name="lParam">An application-defined value passed to the callback function. This parameter can be used in error checking.</param>
		/// <returns>
		/// The return value is TRUE if the function succeeds or FALSE if the function does not find a resource of the type specified, or if the function fails
		/// for another reason. To get extended error information, call GetLastError.
		/// </returns>
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Unicode)]
		[SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms648037")]
		public static extern bool EnumResourceNames(SafeLibraryHandle hModule, string lpszType, EnumResNameProc lpEnumFunc, IntPtr lParam);

		/// <summary>
		/// Enumerates resources of a specified type within a binary module. For Windows Vista and later, this is typically a language-neutral Portable
		/// Executable (LN file), and the enumeration will also include resources from the corresponding language-specific resource files (.mui files) that
		/// contain localizable language resources. It is also possible for hModule to specify an .mui file, in which case only that file is searched for resources.
		/// </summary>
		/// <param name="hModule">
		/// A handle to a module to be searched. Starting with Windows Vista, if this is an LN file, then appropriate .mui files (if any exist) are included in
		/// the search.
		/// <para>If this parameter is NULL, that is equivalent to passing in a handle to the module used to create the current process.</para>
		/// </param>
		/// <param name="type">
		/// The type of the resource for which the name is being enumerated. Alternately, rather than a string, this parameter can be MAKEINTRESOURCE(ID), where
		/// ID is an integer value representing a predefined resource type.
		/// </param>
		/// <returns>A list of strings for each of the resources matching <paramref name="type"/>.</returns>
		[PInvokeData("WinBase.h", MSDNShortId = "ms648037")]
		public static IList<SafeResourceId> EnumResourceNames(SafeLibraryHandle hModule, SafeResourceId type)
		{
			var list = new ResList();
			if (!EnumResourceNames(hModule, type, (ptr, intPtr, name, param) => { param.L.Add(new SafeResourceId(name)); return true; }, list))
				Win32Error.ThrowLastError();
			return list.L;
		}

		/// <summary>
		/// Determines the location of a resource with the specified type and name in the specified module.
		/// <para>To specify a language, use the FindResourceEx function.</para>
		/// </summary>
		/// <param name="hModule">
		/// A handle to the module whose portable executable file or an accompanying MUI file contains the resource. If this parameter is Null, the function
		/// searches the module used to create the current process.
		/// </param>
		/// <param name="lpName">
		/// The name of the resource. Alternately, rather than a pointer, this parameter can be MAKEINTRESOURCE, where wInteger is the integer identifier of the resource.
		/// </param>
		/// <param name="lpType">
		/// The resource type. Alternately, rather than a pointer, this parameter can be MAKEINTRESOURCE, where wInteger is the integer identifier of the given
		/// resource type.
		/// </param>
		/// <returns>
		/// If the function succeeds, the return value is a handle to the specified resource's information block. To obtain a handle to the resource, pass this
		/// handle to the <see cref="LoadResource"/> function.
		/// <para>If the function fails, the return value is NULL. To get extended error information, call GetLastError.</para>
		/// </returns>
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Unicode)]
		[SuppressUnmanagedCodeSecurity]
		[PInvokeData("WinBase.h", MSDNShortId = "ms648042")]
		public static extern IntPtr FindResource(SafeLibraryHandle hModule, SafeResourceId lpName, SafeResourceId lpType);

		/// <summary>Retrieves a handle that can be used to obtain a pointer to the first byte of the specified resource in memory.</summary>
		/// <param name="hModule">
		/// A handle to the module whose executable file contains the resource. If hModule is <see cref="SafeLibraryHandle.Null"/>, the system loads the resource
		/// from the module that was used to create the current process.
		/// </param>
		/// <param name="hResInfo">A handle to the resource to be loaded. This handle is returned by the FindResource or FindResourceEx function.</param>
		/// <returns>
		/// If the function succeeds, the return value is a handle to the data associated with the resource.
		/// <para>If the function fails, the return value is NULL. To get extended error information, call GetLastError.</para>
		/// </returns>
		[DllImport(Lib.Kernel32, SetLastError = true)]
		[SuppressUnmanagedCodeSecurity]
		[PInvokeData("WinBase.h", MSDNShortId = "ms648046")]
		public static extern IntPtr LoadResource(SafeLibraryHandle hModule, IntPtr hResInfo);

		/// <summary>Retrieves a pointer to the specified resource in memory.</summary>
		/// <param name="hResData">A handle to the resource to be accessed. The <see cref="LoadResource"/> function returns this handle.</param>
		/// <returns>If the loaded resource is available, the return value is a pointer to the first byte of the resource; otherwise, it is NULL.</returns>
		[DllImport(Lib.Kernel32, SetLastError = true)]
		[SuppressUnmanagedCodeSecurity]
		[PInvokeData("WinBase.h", MSDNShortId = "ms648047")]
		public static extern IntPtr LockResource(IntPtr hResData);

		/// <summary>Retrieves the size, in bytes, of the specified resource.</summary>
		/// <param name="hModule">A handle to the module whose executable file contains the resource.</param>
		/// <param name="hResInfo">A handle to the resource. This handle must be created by using the FindResource or FindResourceEx function.</param>
		/// <returns>
		/// If the function succeeds, the return value is the number of bytes in the resource. If the function fails, the return value is zero. To get extended
		/// error information, call GetLastError.
		/// </returns>
		[DllImport(Lib.Kernel32, SetLastError = true)]
		[SuppressUnmanagedCodeSecurity]
		[PInvokeData("WinBase.h", MSDNShortId = "ms648048")]
		public static extern int SizeofResource(SafeLibraryHandle hModule, IntPtr hResInfo);

		/// <summary>
		/// Enumerates resources of a specified type within a binary module. For Windows Vista and later, this is typically a language-neutral Portable
		/// Executable (LN file), and the enumeration will also include resources from the corresponding language-specific resource files (.mui files) that
		/// contain localizable language resources. It is also possible for hModule to specify an .mui file, in which case only that file is searched for resources.
		/// </summary>
		/// <param name="hModule">
		/// A handle to a module to be searched. Starting with Windows Vista, if this is an LN file, then appropriate .mui files (if any exist) are included in
		/// the search.
		/// <para>If this parameter is NULL, that is equivalent to passing in a handle to the module used to create the current process.</para>
		/// </param>
		/// <param name="lpszType">
		/// The type of the resource for which the name is being enumerated. Alternately, rather than a pointer, this parameter can be MAKEINTRESOURCE(ID), where
		/// ID is an integer value representing a predefined resource type.
		/// </param>
		/// <param name="lpEnumFunc">A pointer to the callback function to be called for each enumerated resource name or ID.</param>
		/// <param name="lParam">An application-defined value passed to the callback function. This parameter can be used in error checking.</param>
		/// <returns>
		/// The return value is TRUE if the function succeeds or FALSE if the function does not find a resource of the type specified, or if the function fails
		/// for another reason. To get extended error information, call GetLastError.
		/// </returns>
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Unicode)]
		[SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("FileAPI.h", MSDNShortId = "aa365467")]
		private static extern bool EnumResourceNames(SafeLibraryHandle hModule, IntPtr lpszType, EnumResNameProcManaged lpEnumFunc, ResList lParam);

		private class ResList { public List<SafeResourceId> L { get; } = new List<SafeResourceId>(); }
	}
}