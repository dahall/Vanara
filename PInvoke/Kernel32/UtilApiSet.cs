using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Kernel32
	{
		/// <summary>
		/// Generates simple tones on the speaker. The function is synchronous; it performs an alertable wait and does not return control to its caller until the
		/// sound finishes.
		/// </summary>
		/// <param name="dwFreq">The frequency of the sound, in hertz. This parameter must be in the range 37 through 32,767 (0x25 through 0x7FFF).</param>
		/// <param name="dwDuration">The duration of the sound, in milliseconds.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI Beep( _In_ DWORD dwFreq, _In_ DWORD dwDuration); https://msdn.microsoft.com/en-us/library/windows/desktop/ms679277(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms679277")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool Beep(uint dwFreq, uint dwDuration);

		/// <summary>Decodes a pointer that was previously encoded with <c>EncodePointer</c>.</summary>
		/// <param name="Ptr">The pointer to be decoded.</param>
		/// <returns>The function returns the decoded pointer.</returns>
		// PVOID DecodePointer( PVOID Ptr ); https://msdn.microsoft.com/en-us/library/bb432242(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("UtilApiSet.h", MSDNShortId = "bb432242")]
		public static extern IntPtr DecodePointer([In] IntPtr Ptr);

		/// <summary>
		/// <para>
		/// [Some information relates to pre-released product which may be substantially modified before it's commercially released. Microsoft makes no
		/// warranties, express or implied, with respect to the information provided here.]
		/// </para>
		/// <para>Decodes a pointer in a specified process that was previously encoded with <c>EncodePointer</c> or <c>EncodeRemotePointer</c>.</para>
		/// </summary>
		/// <param name="ProcessHandle">Handle to the remote process that owns the pointer.</param>
		/// <param name="Ptr">The pointer to be decoded.</param>
		/// <param name="DecodedPtr">The decoded pointer.</param>
		/// <returns>Returns S_OK if successful, otherwise the function failed.</returns>
		// HRESULT WINAPI DecodeRemotePointer( _In_ HANDLE ProcessHandle, _In_opt_ PVOID Ptr, _Out_ PVOID * DecodedPtr ); https://msdn.microsoft.com/en-us/library/dn877133(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("UtilApiSet.h", MSDNShortId = "dn877133")]
		public static extern HRESULT DecodeRemotePointer(IntPtr ProcessHandle, IntPtr Ptr, out IntPtr DecodedPtr);

		/// <summary>Decodes a pointer that was previously encoded with EncodeSystemPointer.</summary>
		/// <param name="Ptr">The system pointer to be decoded.</param>
		/// <returns>The function returns the decoded pointer.</returns>
		// PVOID DecodeSystemPointer( PVOID Ptr ); https://msdn.microsoft.com/en-us/library/bb432243(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("UtilApiSet.h", MSDNShortId = "bb432243")]
		public static extern IntPtr DecodeSystemPointer([In] IntPtr Ptr);

		/// <summary>Encodes the specified pointer. Encoded pointers can be used to provide another layer of protection for pointer values.</summary>
		/// <param name="Ptr">The pointer to be encoded.</param>
		/// <returns>The function returns the encoded pointer.</returns>
		// PVOID EncodePointer( _In_ PVOID Ptr ); https://msdn.microsoft.com/en-us/library/bb432254(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("UtilApiSet.h", MSDNShortId = "bb432254")]
		public static extern IntPtr EncodePointer([In] IntPtr Ptr);

		/// <summary>
		/// <para>
		/// [Some information relates to pre-released product which may be substantially modified before it's commercially released. Microsoft makes no
		/// warranties, express or implied, with respect to the information provided here.]
		/// </para>
		/// <para>Encodes the specified pointer of the specified process. Encoded pointers can be used to provide another layer of protection for pointer values.</para>
		/// </summary>
		/// <param name="ProcessHandle">Handle to the remote process that owns the pointer.</param>
		/// <param name="Ptr">The pointer to be encoded.</param>
		/// <param name="EncodedPtr">The encoded pointer.</param>
		/// <returns>Returns S_OK if successful, otherwise the function failed.</returns>
		// HRESULT WINAPI EncodeRemotePointer( _In_ HANDLE ProcessHandle, _In_opt_ PVOID Ptr, _Out_ PVOID * EncodedPtr ); https://msdn.microsoft.com/en-us/library/dn877135(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("UtilApiSet.h", MSDNShortId = "dn877135")]
		public static extern HRESULT EncodeRemotePointer(IntPtr ProcessHandle, IntPtr Ptr, out IntPtr EncodedPtr);

		/// <summary>
		/// Encodes the specified pointer with a system-specific value. Encoded pointers can be used to provide another layer of protection for pointer values.
		/// </summary>
		/// <param name="Ptr">The system pointer to be encoded.</param>
		/// <returns>The function returns the encoded pointer.</returns>
		// PVOID EncodeSystemPointer( PVOID Ptr ); https://msdn.microsoft.com/en-us/library/bb432255(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("UtilApiSet.h", MSDNShortId = "bb432255")]
		public static extern IntPtr EncodeSystemPointer([In] IntPtr Ptr);
	}
}