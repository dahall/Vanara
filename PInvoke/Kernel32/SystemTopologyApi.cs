using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Kernel32
	{
		/// <summary>Retrieves the node that currently has the highest number.</summary>
		/// <param name="HighestNodeNumber">The number of the highest node.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI GetNumaHighestNodeNumber( _Out_ PULONG HighestNodeNumber); https://msdn.microsoft.com/en-us/library/windows/desktop/ms683203(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms683203")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetNumaHighestNodeNumber(out uint HighestNodeNumber);

		/// <summary>Retrieves the processor mask for a node regardless of the processor group the node belongs to.</summary>
		/// <param name="Node">The node number.</param>
		/// <param name="ProcessorMask">
		/// <para>
		/// A pointer to a <c>GROUP_AFFINITY</c> structure that receives the processor mask for the specified node. A processor mask is a bit
		/// vector in which each bit represents a processor and whether it is in the node.
		/// </para>
		/// <para>If the specified node has no processors configured, the <c>Mask</c> member is zero and the <c>Group</c> member is undefined.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero.</para>
		/// </returns>
		// BOOL GetNumaNodeProcessorMaskEx( _In_ USHORT Node, _Out_ PGROUP_AFFINITY ProcessorMask); https://msdn.microsoft.com/en-us/library/windows/desktop/dd405493(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "dd405493")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetNumaNodeProcessorMaskEx(ushort Node, out GROUP_AFFINITY ProcessorMask);

		/// <summary>Retrieves the NUMA node number that corresponds to the specified proximity identifier as a <c>USHORT</c> value.</summary>
		/// <param name="ProximityId">The proximity identifier of the node.</param>
		/// <param name="NodeNumber">Points to a variable to receive the node number for the specified proximity identifier.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero.</para>
		/// </returns>
		// BOOL GetNumaProximityNodeEx( _In_ ULONG ProximityId, _Out_ PUSHORT NodeNumber); https://msdn.microsoft.com/en-us/library/windows/desktop/dd405495(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "dd405495")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetNumaProximityNodeEx(uint ProximityId, out ushort NodeNumber);

		/// <summary>Represents a processor group-specific affinity, such as the affinity of a thread.</summary>
		// typedef struct _GROUP_AFFINITY { KAFFINITY Mask; WORD Group; WORD Reserved[3];} GROUP_AFFINITY, *PGROUP_AFFINITY; https://msdn.microsoft.com/en-us/library/windows/desktop/dd405500(v=vs.85).aspx
		[PInvokeData("WinNT.h", MSDNShortId = "dd405500")]
		[StructLayout(LayoutKind.Sequential, Pack = 4)]
		public struct GROUP_AFFINITY
		{
			/// <summary>A bitmap that specifies the affinity for zero or more processors within the specified group.</summary>
			public UIntPtr Mask;

			/// <summary>The processor group number.</summary>
			public ushort Group;

			/// <summary>This member is reserved.</summary>
			private ushort Reserved1;

			/// <summary>This member is reserved.</summary>
			private ushort Reserved2;

			/// <summary>This member is reserved.</summary>
			private ushort Reserved3;
		}
	}
}