using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Kernel32
	{
		/// <summary>
		/// Causes a breakpoint exception to occur in the specified process. This allows the calling thread to signal the debugger to handle the exception.
		/// </summary>
		/// <param name="Process">A handle to the process.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI DebugBreakProcess( _In_ HANDLE Process);
		// https://msdn.microsoft.com/en-us/library/windows/desktop/ms679298(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms679298")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool DebugBreakProcess([In] HPROCESS Process);

		/// <summary>Sets the action to be performed when the calling thread exits.</summary>
		/// <param name="KillOnExit">
		/// If this parameter is <c>TRUE</c>, the thread terminates all attached processes on exit (note that this is the default). Otherwise, the thread
		/// detaches from all processes being debugged on exit.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI DebugSetProcessKillOnExit( _In_ BOOL KillOnExit); https://msdn.microsoft.com/en-us/library/windows/desktop/ms679307(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms679307")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool DebugSetProcessKillOnExit([MarshalAs(UnmanagedType.Bool)] bool KillOnExit);

		/// <summary>Transfers execution control to the debugger. The behavior of the debugger thereafter is specific to the type of debugger used.</summary>
		/// <param name="ExitCode">The error code associated with the exit.</param>
		/// <returns>This function does not return a value.</returns>
		// void WINAPI FatalExit( _In_ int ExitCode);
		// https://msdn.microsoft.com/en-us/library/windows/desktop/ms679337(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms679337")]
		public static extern void FatalExit(int ExitCode);

		/// <summary>Retrieves a descriptor table entry for the specified selector and thread.</summary>
		/// <param name="hThread">
		/// A handle to the thread containing the specified selector. The handle must have THREAD_QUERY_INFORMATION access. For more information, see Thread
		/// Security and Access Rights.
		/// </param>
		/// <param name="dwSelector">The global or local selector value to look up in the thread's descriptor tables.</param>
		/// <param name="lpSelectorEntry">
		/// A pointer to an <c>LDT_ENTRY</c> structure that receives a copy of the descriptor table entry if the specified selector has an entry in the specified
		/// thread's descriptor table. This information can be used to convert a segment-relative address to a linear virtual address.
		/// </param>
		/// <returns>
		/// <para>
		/// If the function succeeds, the return value is nonzero. In that case, the structure pointed to by the lpSelectorEntry parameter receives a copy of the
		/// specified descriptor table entry.
		/// </para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI GetThreadSelectorEntry( _In_ HANDLE hThread, _In_ DWORD dwSelector, _Out_ LPLDT_ENTRY lpSelectorEntry);
		// https://msdn.microsoft.com/en-us/library/windows/desktop/ms679363(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms679363")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetThreadSelectorEntry([In] HTHREAD hThread, uint dwSelector, out LDT_ENTRY lpSelectorEntry);

		/// <summary>Describes an entry in the descriptor table. This structure is valid only on x86-based systems.</summary>
		// typedef struct _LDT_ENTRY { WORD LimitLow; WORD BaseLow; union { struct { BYTE BaseMid; BYTE Flags1; BYTE Flags2; BYTE BaseHi; } Bytes; struct { DWORD BaseMid :8; DWORD Type :5; DWORD Dpl :2; DWORD Pres :1; DWORD LimitHi :4; DWORD Sys :1; DWORD Reserved_0 :1; DWORD Default_Big :1; DWORD Granularity :1; DWORD BaseHi :8; } Bits; } HighWord;} LDT_ENTRY, *PLDT_ENTRY;
		// https://msdn.microsoft.com/en-us/library/windows/desktop/ms680348(v=vs.85).aspx
		[PInvokeData("WinNT.h", MSDNShortId = "ms680348")]
		[StructLayout(LayoutKind.Sequential, Pack = 2)]
		public struct LDT_ENTRY
		{
			/// <summary>The low-order part of the address of the last byte in the segment.</summary>
			public ushort LimitLow;
			/// <summary>The low-order part of the base address of the segment.</summary>
			public ushort BaseLow;

			private uint bits;

			/// <summary>The middle bits (16â€“23) of the base address of the segment.</summary>
			public byte BaseMid { get => GetBits(0, 8); set => SetBits(0, 8, value); }

			/// <summary>The type of segment. This member can be one of the following values:
			/// <list type="bullet">
			/// <item><term>0: Read-only data segment</term></item>
			/// <item><term>1: Read-write data segment</term></item>
			/// <item><term>2: Unused segment</term></item>
			/// <item><term>3: Read-write expand-down data segment</term></item>
			/// <item><term>4: Execute-only code segment</term></item>
			/// <item><term>5: Executable-readable code segment</term></item>
			/// <item><term>6: Execute-only "conforming" code segment</term></item>
			/// <item><term>7: Executable-readable "conforming" code segment</term></item>
			/// </list></summary>
			public byte Type { get => GetBits(8, 5); set => SetBits(8, 5, value); }

			/// <summary>The privilege level of the descriptor. This member is an integer value in the range 0 (most privileged) through 3 (least privileged).</summary>
			public byte Dpl { get => GetBits(13, 2); set => SetBits(13, 2, value); }

			/// <summary>The present flag. This member is 1 if the segment is present in physical memory or 0 if it is not.</summary>
			public byte Pres { get => GetBits(15, 1); set => SetBits(15, 1, value); }

			/// <summary>The high bits (16â€“19) of the address of the last byte in the segment.</summary>
			public byte LimitHi { get => GetBits(16, 4); set => SetBits(16, 4, value); }

			/// <summary>The space that is available to system programmers. This member might be used for marking segments in some system-specific way.</summary>
			public byte Sys { get => GetBits(20, 1); set => SetBits(20, 1, value); }

			/// <summary>Reserved.</summary>
			public byte Reserved_0 { get => GetBits(21, 1); set => SetBits(21, 1, value); }

			/// <summary>The size of segment. If the segment is a data segment, this member contains 1 if the segment is larger than 64 kilobytes (K) or 0 if the segment is smaller than or equal to 64K.
			/// <para>If the segment is a code segment, this member contains 1 if the segment is a code segment and runs with the default (native mode) instruction set.This member contains 0 if the code segment is an 80286 code segment and runs with 16-bit offsets and the 80286-compatible instruction set.</para></summary>
			public byte Default_Big { get => GetBits(22, 1); set => SetBits(22, 1, value); }

			/// <summary>The granularity. This member contains 0 if the segment is byte granular, 1 if the segment is page granular.</summary>
			public byte Granularity { get => GetBits(23, 1); set => SetBits(23, 1, value); }

			/// <summary>The high bits (24â€“31) of the base address of the segment.</summary>
			public byte BaseHi { get => GetBits(24, 8); set => SetBits(24, 8, value); }

			private byte GetBits(int offset, int len) => (byte)((bits & (((1 << len) - 1) << offset)) >> offset);

			private void SetBits(int offset, int len, byte value) { var mask = (uint)(((1 << len) - 1) << offset); bits = (bits & ~mask) | (uint)(value << offset); }
		}
	}
}