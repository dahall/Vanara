using System.Collections.Generic;
using System.Linq;

namespace Vanara.PInvoke;

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
	[PInvokeData("systemtopology.h", MSDNShortId = "ms683203")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetNumaHighestNodeNumber(out uint HighestNodeNumber);

	/// <summary>Retrieves the multi-group processor mask of the specified node.</summary>
	/// <param name="NodeNumber">Supplies the zero-based node number for the node of interest.</param>
	/// <param name="ProcessorMasks">
	/// <para>An array of GROUP_AFFINITY structures, which upon successful return describes the processor mask of the specified node.</para>
	/// <para>
	/// Each element in the array describes a set of processors that belong to the node within a single processor group. There will be one
	/// element in the resulting array for each processor group this node has active processors in.
	/// </para>
	/// </param>
	/// <param name="ProcessorMaskCount">Specifies the size of the ProcessorMasks array, in elements.</param>
	/// <param name="RequiredMaskCount">
	/// <para>On successful return, specifies the number of affinity structures written to the array.</para>
	/// <para>
	/// If the input array was too small, the function fails with <c>ERROR_INSUFFICIENT_BUFFER</c> and sets the RequiredMaskCount parameter
	/// to the number of elements required.
	/// </para>
	/// <para>The number of required elements is always less than or equal to the maximum group count returned by GetMaximumProcessorGroupCount.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero and extended error information can be retrieved by calling GetLastError.</para>
	/// <para>
	/// If the array supplied is too small, the error value is <c>ERROR_INSUFFICIENT_BUFFER</c> and the RequiredMaskCount parameter is set to
	/// the number of elements required.
	/// </para>
	/// <para>
	/// If the NodeNumber supplied is invalid (i.e. greater than the value returned by GetNumaHighestNodeNumber), the error value is <c>ERROR_INVALID_PARAMETER</c>.
	/// </para>
	/// </returns>
	/// <remarks>
	/// If the node specified does not have any processors associated with it (i.e. it only contains memory or peripherals), then the
	/// RequiredMaskCount returned will be 0 and no structures will be written to the array.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/systemtopologyapi/nf-systemtopologyapi-getnumanodeprocessormask2
	// BOOL GetNumaNodeProcessorMask2( USHORT NodeNumber, PGROUP_AFFINITY ProcessorMasks, USHORT ProcessorMaskCount, PUSHORT RequiredMaskCount );
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("systemtopologyapi.h", MSDNShortId = "NF:systemtopologyapi.GetNumaNodeProcessorMask2")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetNumaNodeProcessorMask2(ushort NodeNumber, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2),
		SizeDef(nameof(ProcessorMaskCount), SizingMethod.Query | SizingMethod.CheckLastError, OutVarName = nameof(RequiredMaskCount))] GROUP_AFFINITY[]? ProcessorMasks,
		ushort ProcessorMaskCount, out ushort RequiredMaskCount);

	/// <summary>Retrieves the multi-group processor mask of the specified node.</summary>
	/// <param name="NodeNumber">Supplies the zero-based node number for the node of interest.</param>
	/// <returns>
	/// <para>An array of GROUP_AFFINITY structures, which upon successful return describes the processor mask of the specified node.</para>
	/// <para>
	/// Each element in the array describes a set of processors that belong to the node within a single processor group. There will be one
	/// element in the resulting array for each processor group this node has active processors in.
	/// </para>
	/// </returns>
	/// <remarks>
	/// If the node specified does not have any processors associated with it (i.e. it only contains memory or peripherals), then the
	/// RequiredMaskCount returned will be 0 and no structures will be written to the array.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/systemtopologyapi/nf-systemtopologyapi-getnumanodeprocessormask2
	// BOOL GetNumaNodeProcessorMask2( USHORT NodeNumber, PGROUP_AFFINITY ProcessorMasks, USHORT ProcessorMaskCount, PUSHORT RequiredMaskCount );
	[PInvokeData("systemtopologyapi.h", MSDNShortId = "NF:systemtopologyapi.GetNumaNodeProcessorMask2")]
	public static GROUP_AFFINITY[] GetNumaNodeProcessorMask2(ushort NodeNumber)
	{
		if (!GetNumaNodeProcessorMask2(NodeNumber, null, 0, out var c))
			Win32Error.ThrowLastErrorUnless(Win32Error.ERROR_INSUFFICIENT_BUFFER);
		var result = new GROUP_AFFINITY[c];
		if (c > 0)
			Win32Error.ThrowLastErrorIfFalse(GetNumaNodeProcessorMask2(NodeNumber, result, c, out _));
		return result;
	}

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
	[PInvokeData("systemtopology.h", MSDNShortId = "dd405493")]
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
	[PInvokeData("systemtopology.h", MSDNShortId = "dd405495")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetNumaProximityNodeEx(uint ProximityId, out ushort NodeNumber);

	/// <summary>Represents a processor group-specific affinity, such as the affinity of a thread.</summary>
	// typedef struct _GROUP_AFFINITY { KAFFINITY Mask; WORD Group; WORD Reserved[3];} GROUP_AFFINITY, *PGROUP_AFFINITY; https://msdn.microsoft.com/en-us/library/windows/desktop/dd405500(v=vs.85).aspx
	[PInvokeData("WinNT.h", MSDNShortId = "dd405500")]
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct GROUP_AFFINITY
	{
		/// <summary>A bitmap that specifies the affinity for zero or more processors within the specified group.</summary>
		public nuint Mask;

		/// <summary>The processor group number.</summary>
		public ushort Group;

		/// <summary>This member is reserved.</summary>
		private readonly ushort Reserved1;

		/// <summary>This member is reserved.</summary>
		private readonly ushort Reserved2;

		/// <summary>This member is reserved.</summary>
		private readonly ushort Reserved3;

		/// <summary>Gets or sets the affinitized processors in the <see cref="Mask"/> field as their indexed hitIndices.</summary>
		/// <value>The affinitized processors.</value>
		public IEnumerable<uint> AffinitizedProcessors
		{
			readonly get => BitHelper.BitMaskToHitList((uint)Mask);
			set => Mask = BitHelper.HitListToBitMask<uint>(value);
		}
	}
}