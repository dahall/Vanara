using System;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Kernel32
	{
		/// <summary>Optional actions.</summary>
		[Flags]
		public enum DUPLICATE_HANDLE_OPTIONS : uint
		{
			/// <summary>Closes the source handle. This occurs regardless of any error status returned.</summary>
			DUPLICATE_CLOSE_SOURCE = 0x00000001,
			/// <summary>Ignores the dwDesiredAccess parameter. The duplicate handle has the same access as the source handle.</summary>
			DUPLICATE_SAME_ACCESS = 0x00000002,
		}

		/// <summary>A set of bit flags that specify properties of the object handle.</summary>
		[Flags]
		public enum HANDLE_FLAG
		{
			/// <summary>None.</summary>
			NONE = 0,
			/// <summary>
			/// If this flag is set, a child process created with the bInheritHandles parameter of CreateProcess set to TRUE will inherit the object handle.
			/// </summary>
			HANDLE_FLAG_INHERIT = 1,
			/// <summary>If this flag is set, calling the CloseHandle function will not close the object handle.</summary>
			HANDLE_FLAG_PROTECT_FROM_CLOSE = 2
		}

		/// <summary>Closes an open object handle.</summary>
		/// <param name="hObject">A valid handle to an open object.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// <para>
		/// If the application is running under a debugger, the function will throw an exception if it receives either a handle value that is not valid or a
		/// pseudo-handle value. This can happen if you close a handle twice, or if you call <c>CloseHandle</c> on a handle returned by the <c>FindFirstFile</c>
		/// function instead of calling the <c>FindClose</c> function.
		/// </para>
		/// </returns>
		// BOOL WINAPI CloseHandle( _In_ HANDLE hObject); https://msdn.microsoft.com/en-us/library/windows/desktop/ms724211(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[PInvokeData("Winbase.h", MSDNShortId = "ms724211")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CloseHandle(IntPtr hObject);

		/// <summary>Compares two object handles to determine if they refer to the same underlying kernel object.</summary>
		/// <param name="hFirstObjectHandle">The first object handle to compare.</param>
		/// <param name="hSecondObjectHandle">The second object handle to compare.</param>
		/// <returns>A Boolean value that indicates if the two handles refer to the same underlying kernel object. TRUE if the same, otherwise FALSE.</returns>
		// BOOL WINAPI CompareObjectHandles( _In_ HANDLE hFirstObjectHandle, _In_ HANDLE hSecondObjectHandle); https://msdn.microsoft.com/en-us/library/windows/desktop/mt438733(v=vs.85).aspx
		[DllImport(Lib.KernelBase, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Handleapi.h", MSDNShortId = "mt438733")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CompareObjectHandles(IntPtr hFirstObjectHandle, IntPtr hSecondObjectHandle);

		/// <summary>Duplicates an object handle.</summary>
		/// <param name="hSourceProcessHandle">
		/// <para>A handle to the process with the handle to be duplicated.</para>
		/// <para>The handle must have the PROCESS_DUP_HANDLE access right. For more information, see Process Security and Access Rights.</para>
		/// </param>
		/// <param name="hSourceHandle">
		/// The handle to be duplicated. This is an open object handle that is valid in the context of the source process. For a list of objects whose handles
		/// can be duplicated, see the following Remarks section.
		/// </param>
		/// <param name="hTargetProcessHandle">
		/// A handle to the process that is to receive the duplicated handle. The handle must have the PROCESS_DUP_HANDLE access right.
		/// </param>
		/// <param name="lpTargetHandle">
		/// <para>A pointer to a variable that receives the duplicate handle. This handle value is valid in the context of the target process.</para>
		/// <para>
		/// If hSourceHandle is a pseudo handle returned by <c>GetCurrentProcess</c> or <c>GetCurrentThread</c>, <c>DuplicateHandle</c> converts it to a real
		/// handle to a process or thread, respectively.
		/// </para>
		/// <para>
		/// If lpTargetHandle is <c>NULL</c>, the function duplicates the handle, but does not return the duplicate handle value to the caller. This behavior
		/// exists only for backward compatibility with previous versions of this function. You should not use this feature, as you will lose system resources
		/// until the target process terminates.
		/// </para>
		/// </param>
		/// <param name="dwDesiredAccess">
		/// <para>The access requested for the new handle. For the flags that can be specified for each object type, see the following Remarks section.</para>
		/// <para>
		/// This parameter is ignored if the dwOptions parameter specifies the DUPLICATE_SAME_ACCESS flag. Otherwise, the flags that can be specified depend on
		/// the type of object whose handle is to be duplicated.
		/// </para>
		/// </param>
		/// <param name="bInheritHandle">
		/// A variable that indicates whether the handle is inheritable. If <c>TRUE</c>, the duplicate handle can be inherited by new processes created by the
		/// target process. If <c>FALSE</c>, the new handle cannot be inherited.
		/// </param>
		/// <param name="dwOptions">
		/// <para>Optional actions. This parameter can be zero, or any combination of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>DUPLICATE_CLOSE_SOURCE0x00000001</term>
		/// <term>Closes the source handle. This occurs regardless of any error status returned.</term>
		/// </item>
		/// <item>
		/// <term>DUPLICATE_SAME_ACCESS0x00000002</term>
		/// <term>Ignores the dwDesiredAccess parameter. The duplicate handle has the same access as the source handle.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI DuplicateHandle( _In_ HANDLE hSourceProcessHandle, _In_ HANDLE hSourceHandle, _In_ HANDLE hTargetProcessHandle, _Out_ LPHANDLE
		// lpTargetHandle, _In_ DWORD dwDesiredAccess, _In_ BOOL bInheritHandle, _In_ DWORD dwOptions); https://msdn.microsoft.com/en-us/library/windows/desktop/ms724251(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("Winbase.h", MSDNShortId = "ms724251")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool DuplicateHandle(
			[In] IntPtr hSourceProcessHandle, [In] IntPtr hSourceHandle, [In] IntPtr hTargetProcessHandle, out IntPtr lpTargetHandle, uint dwDesiredAccess,
			[MarshalAs(UnmanagedType.Bool)] bool bInheritHandle, DUPLICATE_HANDLE_OPTIONS dwOptions);

		/// <summary>Retrieves certain properties of an object handle.</summary>
		/// <param name="hObject">
		/// <para>A handle to an object whose information is to be retrieved.</para>
		/// <para>
		/// You can specify a handle to one of the following types of objects: access token, console input buffer, console screen buffer, event, file, file
		/// mapping, job, mailslot, mutex, pipe, printer, process, registry key, semaphore, serial communication device, socket, thread, or waitable timer.
		/// </para>
		/// </param>
		/// <param name="lpdwFlags">
		/// <para>A pointer to a variable that receives a set of bit flags that specify properties of the object handle or 0. The following values are defined.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>HANDLE_FLAG_INHERIT0x00000001</term>
		/// <term>If this flag is set, a child process created with the bInheritHandles parameter of CreateProcess set to TRUE will inherit the object handle.</term>
		/// </item>
		/// <item>
		/// <term>HANDLE_FLAG_PROTECT_FROM_CLOSE0x00000002</term>
		/// <term>If this flag is set, calling the CloseHandle function will not close the object handle.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI GetHandleInformation( _In_ HANDLE hObject, _Out_ LPDWORD lpdwFlags); https://msdn.microsoft.com/en-us/library/windows/desktop/ms724329(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("Winbase.h", MSDNShortId = "ms724329")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetHandleInformation([In] IntPtr hObject, out HANDLE_FLAG lpdwFlags);

		/// <summary>Sets certain properties of an object handle.</summary>
		/// <param name="hObject">
		/// <para>A handle to an object whose information is to be set.</para>
		/// <para>
		/// You can specify a handle to one of the following types of objects: access token, console input buffer, console screen buffer, event, file, file
		/// mapping, job, mailslot, mutex, pipe, printer, process, registry key, semaphore, serial communication device, socket, thread, or waitable timer.
		/// </para>
		/// </param>
		/// <param name="dwMask">A mask that specifies the bit flags to be changed. Use the same constants shown in the description of dwFlags.</param>
		/// <param name="dwFlags">
		/// <para>Set of bit flags that specifies properties of the object handle. This parameter can be 0 or one or more of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>HANDLE_FLAG_INHERIT0x00000001</term>
		/// <term>If this flag is set, a child process created with the bInheritHandles parameter of CreateProcess set to TRUE will inherit the object handle.</term>
		/// </item>
		/// <item>
		/// <term>HANDLE_FLAG_PROTECT_FROM_CLOSE0x00000002</term>
		/// <term>If this flag is set, calling the CloseHandle function will not close the object handle.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI SetHandleInformation( _In_ HANDLE hObject, _In_ DWORD dwMask, _In_ DWORD dwFlags);// https://msdn.microsoft.com/en-us/library/windows/desktop/ms724935(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("Winbase.h", MSDNShortId = "ms724935")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetHandleInformation([In] IntPtr hObject, HANDLE_FLAG dwMask, HANDLE_FLAG dwFlags);
	}
}