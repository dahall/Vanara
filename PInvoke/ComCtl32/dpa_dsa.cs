using System.Runtime.InteropServices.ComTypes;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke;

public static partial class ComCtl32
{
	/// <summary>Indicates a failure on the DSA_InsertItem when returned.</summary>
	public const int DA_ERR = -1;

	/// <summary>Used by DSA_InsertItem to indicate that the item should be inserted at the end of the array.</summary>
	public const int DA_LAST = 0x7FFFFFFF;

	/// <summary>Defines the prototype for the compare function used by <c>DSA_Sort</c>.</summary>
	/// <param name="p1">
	/// <para>Type: <c>void*</c></para>
	/// <para>A pointer to the first item in the comparison.</para>
	/// </param>
	/// <param name="p2">
	/// <para>Type: <c>void*</c></para>
	/// <para>A pointer to the second item in the comparison.</para>
	/// </param>
	/// <param name="lParam">
	/// <para>Type: <c><c>LPARAM</c></c></para>
	/// <para>Additional data passed to pfnCmp.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>int</c></para>
	/// <para>
	/// The meaning of the return values depends on the function that uses this callback prototype. The return values for <c>DSA_Sort</c>
	/// are the following.
	/// </para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>less than 0</term>
	/// <term>If p1 should be sorted ahead of p2.</term>
	/// </listheader>
	/// <item>
	/// <term>equal to 0</term>
	/// <term>If p1 and p2 should be sorted together.</term>
	/// </item>
	/// <item>
	/// <term>greater than 0</term>
	/// <term>If p1 should be sorted after p2.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </returns>
	// typedef int ( CALLBACK *PFNDACOMPARE)( _In_opt_ void *p1, _In_opt_ void *p2, _In_ LPARAM lParam); https://msdn.microsoft.com/en-us/library/windows/desktop/bb775707(v=vs.85).aspx
	[PInvokeData("Commctrl.h", MSDNShortId = "bb775707")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	public delegate int PFNDACOMPARE(IntPtr p1, IntPtr p2, IntPtr lParam);

	/// <summary>
	/// Defines the prototype for the compare function used by <c>DSA_Sort</c> when the items being compared are constant objects.
	/// </summary>
	/// <param name="p1">
	/// <para>Type: <c>const void*</c></para>
	/// <para>A pointer to the first item in the comparison.</para>
	/// </param>
	/// <param name="p2">
	/// <para>Type: <c>const void*</c></para>
	/// <para>A pointer to the second item in the comparison.</para>
	/// </param>
	/// <param name="lParam">
	/// <para>Type: <c><c>LPARAM</c></c></para>
	/// <para>Additional data passed to pfnCmp.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>int</c></para>
	/// <para>
	/// The meaning of the return values depends on the function that uses this callback prototype. The return values for <c>DSA_Sort</c>
	/// are as follows:
	/// </para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>less than 0</term>
	/// <term>If p1 should be sorted ahead of p2.</term>
	/// </listheader>
	/// <item>
	/// <term>equal to 0</term>
	/// <term>If p1 and p2 should be sorted together.</term>
	/// </item>
	/// <item>
	/// <term>greater than 0</term>
	/// <term>If p1 should be sorted after p2.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </returns>
	// typedef int ( CALLBACK *PFNDACOMPARECONST)( _In_opt_ const void *p1, _In_opt_ const void *p2, _In_ LPARAM lParam); https://msdn.microsoft.com/en-us/library/windows/desktop/bb775709(v=vs.85).aspx
	[PInvokeData("Commctrl.h", MSDNShortId = "bb775709")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	public delegate int PFNDACOMPARECONST(IntPtr p1, IntPtr p2, IntPtr lParam);

	/// <summary>
	/// Defines the prototype for the callback function used by dynamic structure array (DSA) and dynamic pointer array (DPA) functions.
	/// </summary>
	/// <param name="p">
	/// <para>Type: <c>void*</c></para>
	/// <para>A pointer to the structure to be enumerated.</para>
	/// </param>
	/// <param name="pData">
	/// <para>Type: <c>void*</c></para>
	/// <para>The value that was passed in the pData parameter to function <c>DSA_EnumCallback</c>.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>int</c></para>
	/// <para>
	/// The return value is used to determine whether to terminate or continue the iteration. A return value of zero indicates that the
	/// iteration should stop; nonzero indicates that the iteration should continue.
	/// </para>
	/// </returns>
	// typedef int ( CALLBACK *PFNDAENUMCALLBACK)( _In_opt_ void *p, _In_opt_ void *pData); https://msdn.microsoft.com/en-us/library/windows/desktop/bb775711(v=vs.85).aspx
	[PInvokeData("Commctrl.h", MSDNShortId = "bb775711")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	public delegate int PFNDAENUMCALLBACK(IntPtr p, IntPtr pData);

	/// <summary>
	/// Defines the prototype for the callback function used by dynamic structure array (DSA) and dynamic pointer array (DPA) functions
	/// when the items involved are pointers to constant data.
	/// </summary>
	/// <param name="p">
	/// <para>Type: <c>const void*</c></para>
	/// <para>A pointer to the constant structure to be enumerated.</para>
	/// </param>
	/// <param name="pData">
	/// <para>Type: <c>void*</c></para>
	/// <para>A value that was passed in the pData parameter to function <c>DSA_EnumCallback</c> or function <c>DPA_EnumCallback</c>.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>int</c></para>
	/// <para>
	/// The return value is used to determine whether to terminate or continue the iteration. A return value of zero indicates that the
	/// iteration should stop; nonzero indicates that the iteration should continue.
	/// </para>
	/// </returns>
	// typedef int ( CALLBACK *PFNDAENUMCALLBACKCONST)( _In_opt_ const void *p, _In_opt_ void *pData); https://msdn.microsoft.com/en-us/library/windows/desktop/bb775713(v=vs.85).aspx
	[PInvokeData("Commctrl.h", MSDNShortId = "bb775713")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	public delegate int PFNDAENUMCALLBACKCONST(IntPtr p, IntPtr pData);

	/// <summary>Defines the prototype for the merge function used by <c>DPA_Merge</c>.</summary>
	/// <param name="uMsg">
	/// <para>Type: <c><c>UINT</c></c></para>
	/// <para>A message that instructs this function how to handle the merge. One of the following values.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>DPAMM_MERGE0x1</term>
	/// <term>
	/// Perform any additional processing needed when merging pvSrc into pvDest. The function should return a pointer to an item that
	/// contains the result of the merge. The value returned by the merge function is stored into the destination, which overwrites the
	/// previous value. If the merge function returns NULL, then the merge operation is abandoned.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DPAMM_DELETE0x2</term>
	/// <term>Perform any additional processing needed when a delete occurs as part of the merge. The function should return NULL.</term>
	/// </item>
	/// <item>
	/// <term>DPAMM_INSERT0x3</term>
	/// <term>
	/// Perform any user-defined processing when the merge results in an item being inserted as part of the merge. The return value of
	/// this function should point to the item result that is inserted as part of the merge. If the merge function returns NULL, then the
	/// merge operation is abandoned.
	/// </term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <param name="pvDest">
	/// <para>Type: <c>void*</c></para>
	/// <para>A pointer to the first item in the merge.</para>
	/// </param>
	/// <param name="pvSrc">
	/// <para>Type: <c>void*</c></para>
	/// <para>A pointer to the second item in the merge.</para>
	/// </param>
	/// <param name="lParam">
	/// <para>Type: <c><c>LPARAM</c></c></para>
	/// <para>Additional data that can be used by the merge callback.</para>
	/// </param>
	/// <returns>
	/// A pointer to the item which results from the merge or <c>NULL</c> if there is a failure when <c>DPAMM_MERGE</c> or
	/// <c>DPAMM_INSERT</c> is used.
	/// </returns>
	// typedef void* ( CALLBACK *PFNDPAMERGE)( _In_ UINT uMsg, _In_ void *pvDest, _In_ void *pvSrc, _In_ LPARAM lParam); https://msdn.microsoft.com/en-us/library/windows/desktop/bb775721(v=vs.85).aspx
	[PInvokeData("Commctrl.h", MSDNShortId = "bb775721")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	public delegate IntPtr PFNDPAMERGE(DPAMM uMsg, IntPtr pvDest, IntPtr pvSrc, IntPtr lParam);

	/// <summary>Defines the prototype for the merge function used by <c>DPA_Merge</c>, using constant values.</summary>
	/// <param name="uMsg">
	/// <para>Type: <c><c>UINT</c></c></para>
	/// <para>A message that instructs this function how to handle the merge. One of the following values.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>DPAMM_MERGE0x1</term>
	/// <term>
	/// Perform any additional processing needed when merging p2 into p1. The function should return a pointer to an item that contains
	/// the result of the merge.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DPAMM_DELETE0x2</term>
	/// <term>Perform any additional processing needed when a delete occurs as part of the merge. The function should return NULL.</term>
	/// </item>
	/// <item>
	/// <term>DPAMM_INSERT0x3</term>
	/// <term>
	/// Perform any user-defined processing when the merge results in an item being inserted as part of the merge. The return value of
	/// this function should point to the item result that is inserted as part of the merge.
	/// </term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <param name="pvDest">
	/// <para>Type: <c>const void*</c></para>
	/// <para>A pointer to the destination item in the merge.</para>
	/// </param>
	/// <param name="pvSrc">
	/// <para>Type: <c>const void*</c></para>
	/// <para>A pointer to the source item in the merge.</para>
	/// </param>
	/// <param name="lParam">
	/// <para>Type: <c><c>LPARAM</c></c></para>
	/// <para>Additional data that can be used by the merge callback.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>const void*</c></para>
	/// <para>
	/// A pointer to constant data which results from the merge, or <c>NULL</c> if there is a failure when DPAMM_MERGE or DPAMM_INSERT is used.
	/// </para>
	/// </returns>
	// typedef const void* ( CALLBACK *PFNDPAMERGECONST)( _In_ UINT uMsg, _In_ const void *pvDest, _In_ const void *pvSrc, _In_ LPARAM
	// lParam); https://msdn.microsoft.com/en-us/library/windows/desktop/bb775723(v=vs.85).aspx
	[PInvokeData("Commctrl.h", MSDNShortId = "bb775723")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	public delegate IntPtr PFNDPAMERGECONST(DPAMM uMsg, IntPtr pvDest, IntPtr pvSrc, IntPtr lParam);

	/// <summary>Defines the prototype for the callback function used by <c>DPA_LoadStream</c> and <c>DPA_SaveStream</c>.</summary>
	/// <param name="pinfo">
	/// <para>Type: <c>DPASTREAMINFO*</c></para>
	/// <para>A pointer to a <c>DPASTREAMINFO</c> structure.</para>
	/// </param>
	/// <param name="pstream">
	/// <para>Type: <c>struct IStream*</c></para>
	/// <para>An <c>IStream</c> object to read from or write to.</para>
	/// </param>
	/// <param name="pvInstData">
	/// <para>Type: <c>void*</c></para>
	/// <para>A void pointer to callback data that the client passed to <c>DPA_LoadStream</c> or <c>DPA_SaveStream</c>.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c><c>HRESULT</c></c></para>
	/// <para>If this function pointer succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
	/// </returns>
	// typedef HRESULT ( CALLBACK *PFNDPASTREAM)( _In_ DPASTREAMINFO *pinfo, _In_ struct IStream *pstream, _In_opt_ void *pvInstData); https://msdn.microsoft.com/en-us/library/windows/desktop/bb775725(v=vs.85).aspx
	[PInvokeData("Commctrl.h", MSDNShortId = "bb775725")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	public delegate HRESULT PFNDPASTREAM(ref DPASTREAMINFO pinfo, IStream pstream, IntPtr pvInstData);

	/// <summary>
	/// Options determining the method used to merge the two arrays. DPAM_NORMAL, DPAM_UNION, and DPAM_UNION are mutually exclusive—only
	/// one of those flags can be set, optionally in conjunction with DPAM_SORTED.
	/// </summary>
	[Flags]
	public enum DPAM
	{
		/// <summary>The arrays are presorted; skip sorting. If this flag is not set, the arrays are sorted before they are merged.</summary>
		DPAM_SORTED = 0x00000001,

		/// <summary>
		/// The final array consists of all of the elements originally present in hdpaDest. If any of those elements are also found in
		/// hdpaSrc, those elements are merged in the final array. The PFNDPAMERGE callback function is called with the DPAMM_MERGE
		/// message. When this flag is set, the final size of the array at hdpaDest is the same as its initial size.
		/// </summary>
		DPAM_NORMAL = 0x00000002,

		/// <summary>
		/// The final array is the union of all elements in both arrays. Elements found in both arrays are merged in the final array.
		/// Elements found in only one array or the other are added as found. When this flag is set, the PFNDPAMERGE callback function
		/// can be called with the DPAMM_MERGE or DPAMM_INSERT message. The final size of the array is at least the size of the larger of
		/// hdpaDest and hdpaSrc, and at most the sum of the two.
		/// </summary>
		DPAM_UNION = 0x00000004,

		/// <summary>
		/// Only elements found in both hdpaSrc and hdpaDest are merged to form the final array. When this flag is set, the PFNDPAMERGE
		/// callback function can be called with the DPAMM_MERGE or DPAMM_DELETE message. The final size of the array can range between 0
		/// and the smaller of hdpaDest and hdpaSrc.
		/// </summary>
		DPAM_INTERSECT = 0x00000008,
	}

	/// <summary>A message that instructs this function how to handle the merge.</summary>
	public enum DPAMM
	{
		/// <summary>
		/// Perform any additional processing needed when merging pvSrc into pvDest. The function should return a pointer to an item that
		/// contains the result of the merge. The value returned by the merge function is stored into the destination, which overwrites
		/// the previous value. If the merge function returns NULL, then the merge operation is abandoned.
		/// </summary>
		DPAMM_MERGE = 1,

		/// <summary>
		/// Perform any additional processing needed when a delete occurs as part of the merge. The function should return NULL.
		/// </summary>
		DPAMM_DELETE = 2,

		/// <summary>
		/// Perform any user-defined processing when the merge results in an item being inserted as part of the merge. The return value
		/// of this function should point to the item result that is inserted as part of the merge. If the merge function returns NULL,
		/// then the merge operation is abandoned.
		/// </summary>
		DPAMM_INSERT = 3
	}

	/// <summary>Options for DPA_Search.</summary>
	[Flags]
	public enum DPAS
	{
		/// <summary>Indicates that the DPA is sorted.</summary>
		DPAS_SORTED = 0x0001,

		/// <summary>
		/// This value is only valid in conjunction with DPAS_SORTED. If the item is not found, return the position where the item is
		/// expected to be found in the sorted DPA.
		/// </summary>
		DPAS_INSERTBEFORE = 0x0002,

		/// <summary>
		/// This value is only valid in conjunction with DPAS_SORTED. If the item is not found, return the position where the item is
		/// expected to be found in the sorted DPA.
		/// </summary>
		DPAS_INSERTAFTER = 0x0004
	}

	/// <summary>Inserts a new item at the end of a dynamic pointer array (DPA).</summary>
	/// <param name="pdpa">A handle to a DPA.</param>
	/// <param name="pitem">A pointer to the item that is to be inserted.</param>
	/// <returns>Returns the index of the new item or , if the append action fails.</returns>
	// int DPA_AppendPtr( HDPA pdpa, void *pitem); https://msdn.microsoft.com/en-us/library/windows/desktop/bb775585(v=vs.85).aspx
	[PInvokeData("Dpa_dsa.h", MSDNShortId = "bb775585")]
	public static int DPA_AppendPtr(HDPA pdpa, IntPtr pitem) => DPA_InsertPtr(pdpa, DA_LAST, pitem);

	/// <summary>
	/// <para>
	/// [ <c>DPA_Clone</c> is available through Windows XP with Service Pack 2 (SP2). It might be altered or unavailable in subsequent versions.]
	/// </para>
	/// <para>Duplicates a dynamic pointer array (DPA).</para>
	/// </summary>
	/// <param name="hdpaSource">
	/// <para>Type: <c>const HDPA</c></para>
	/// <para>A handle to an existing DPA to copy.</para>
	/// </param>
	/// <param name="hdpaNew">
	/// <para>Type: <c>HDPA</c></para>
	/// <para>When <c>NULL</c>, a new array is copied from hdpaSource.</para>
	/// <para>
	/// This parameter can also contain an array created with <c>DPA_Create</c> or <c>DPA_CreateEx</c>. The data is overwritten but the
	/// original delta size and heap handle retained.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HDPA</c></para>
	/// <para>The handle to the new or altered DPA (hdpaNew) if successful; otherwise, <c>NULL</c>.</para>
	/// </returns>
	// HDPA WINAPI DPA_Clone( _In_ const HDPA hdpaSource, _Inout_opt_ HDPA hdpaNew); https://msdn.microsoft.com/en-us/library/windows/desktop/bb775601(v=vs.85).aspx
	[DllImport(Lib.ComCtl32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Dpa_dsa.h", MSDNShortId = "bb775601")]
	public static extern SafeHDPA DPA_Clone(HDPA hdpaSource, [Optional] HDPA hdpaNew);

	/// <summary>
	/// <para>
	/// [ <c>DPA_Create</c> is available for use in the operating systems specified in the Requirements section. It may be altered or
	/// unavailable in subsequent versions.]
	/// </para>
	/// <para>Creates a dynamic pointer array (DPA).</para>
	/// </summary>
	/// <param name="cpGrow">
	/// <para>Type: <c>int</c></para>
	/// <para>The number of elements by which the array should be expanded, if the DPA needs to be enlarged.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HDPA</c></para>
	/// <para>Returns a handle to a DPA if successful, or <c>NULL</c> if the call fails.</para>
	/// </returns>
	// HDPA WINAPI DPA_Create( int cpGrow); https://msdn.microsoft.com/en-us/library/windows/desktop/bb775603(v=vs.85).aspx
	[DllImport(Lib.ComCtl32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Dpa_dsa.h", MSDNShortId = "bb775603")]
	public static extern SafeHDPA DPA_Create(int cpGrow);

	/// <summary>Creates a dynamic pointer array (DPA) using a given specified size and heap location.</summary>
	/// <param name="cpGrow">
	/// <para>Type: <c>int</c></para>
	/// <para>The number of elements by which the array should be expanded, if the DPA needs to be enlarged.</para>
	/// </param>
	/// <param name="hheap">
	/// <para>Type: <c><c>HANDLE</c></c></para>
	/// <para>A handle to the heap where the array is stored.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HDPA</c></para>
	/// <para>Returns a handle to a DPA if successful, or <c>NULL</c> if the call fails.</para>
	/// </returns>
	// HDPA WINAPI DPA_CreateEx( _In_ int cpGrow, _In_opt_ HANDLE hheap); https://msdn.microsoft.com/en-us/library/windows/desktop/bb775605(v=vs.85).aspx
	[DllImport(Lib.ComCtl32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Dpa_dsa.h", MSDNShortId = "bb775605")]
	public static extern SafeHDPA DPA_CreateEx(int cpGrow, [Optional] HHEAP hheap);

	/// <summary>
	/// <para>
	/// [ <c>DPA_DeleteAllPtrs</c> is available for use in the operating systems specified in the Requirements section. It may be altered
	/// or unavailable in subsequent versions.]
	/// </para>
	/// <para>Removes all items from a dynamic pointer array (DPA) and shrinks the DPA accordingly.</para>
	/// </summary>
	/// <param name="pdpa">
	/// <para>Type: <c>HDPA</c></para>
	/// <para>Handle to a DPA.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c><c>BOOL</c></c></para>
	/// <para>Returns <c>TRUE</c> on success or <c>FALSE</c> on failure.</para>
	/// </returns>
	// BOOL WINAPI DPA_DeleteAllPtrs( HDPA pdpa); https://msdn.microsoft.com/en-us/library/windows/desktop/bb775607(v=vs.85).aspx
	[DllImport(Lib.ComCtl32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Dpa_dsa.h", MSDNShortId = "bb775607")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DPA_DeleteAllPtrs(HDPA pdpa);

	/// <summary>
	/// <para>
	/// [ <c>DPA_DeletePtr</c> is available for use in the operating systems specified in the Requirements section. It may be altered or
	/// unavailable in subsequent versions.]
	/// </para>
	/// <para>Removes an item from a dynamic pointer array (DPA). The DPA shrinks if necessary to accommodate the removed item.</para>
	/// </summary>
	/// <param name="pdpa">
	/// <para>Type: <c>HDPA</c></para>
	/// <para>A handle to a DPA.</para>
	/// </param>
	/// <param name="index">
	/// <para>Type: <c>int</c></para>
	/// <para>An index of item to be removed from DPA.</para>
	/// </param>
	/// <returns>Returns the removed item or <c>NULL</c>, if the call fails.</returns>
	// void* WINAPI DPA_DeletePtr( HDPA pdpa, int index); https://msdn.microsoft.com/en-us/library/windows/desktop/bb775609(v=vs.85).aspx
	[DllImport(Lib.ComCtl32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Dpa_dsa.h", MSDNShortId = "bb775609")]
	public static extern IntPtr DPA_DeletePtr(HDPA pdpa, int index);

	/// <summary>
	/// <para>
	/// [ <c>DPA_Destroy</c> is available for use in the operating systems specified in the Requirements section. It may be altered or
	/// unavailable in subsequent versions.]
	/// </para>
	/// <para>Frees a Dynamic Pointer Array (DPA).</para>
	/// </summary>
	/// <param name="pdpa">
	/// <para>Type: <c>HDPA</c></para>
	/// <para>A handle to a DPA.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c><c>BOOL</c></c></para>
	/// <para>Returns <c>TRUE</c> on success, <c>FALSE</c> on failure.</para>
	/// </returns>
	// BOOL WINAPI DPA_Destroy( HDPA pdpa); https://msdn.microsoft.com/en-us/library/windows/desktop/bb775611(v=vs.85).aspx
	[DllImport(Lib.ComCtl32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Dpa_dsa.h", MSDNShortId = "bb775611")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DPA_Destroy(HDPA pdpa);

	/// <summary>
	/// <para>
	/// [ <c>DPA_DestroyCallback</c> is available for use in the operating systems specified in the Requirements section. It may be
	/// altered or unavailable in subsequent versions.]
	/// </para>
	/// <para>Calls pfnCB on each element of the dynamic pointer array (DPA), then frees the DPA.</para>
	/// </summary>
	/// <param name="pdpa">
	/// <para>Type: <c>HDPA</c></para>
	/// <para>A handle to a DPA.</para>
	/// </param>
	/// <param name="pfnCB">
	/// <para>Type: <c><c>PFNDPAENUMCALLBACK</c></c></para>
	/// <para>A callback function pointer. See <c>PFNDPAENUMCALLBACK</c> for the callback function prototype.</para>
	/// </param>
	/// <param name="pData">
	/// <para>Type: <c>void*</c></para>
	/// <para>A callback data pointer. pData is passed as a parameter to pfnCB.</para>
	/// </param>
	/// <returns>No return value.</returns>
	// void WINAPI DPA_DestroyCallback( HDPA pdpa, PFNDPAENUMCALLBACK pfnCB, void *pData); https://msdn.microsoft.com/en-us/library/windows/desktop/bb775613(v=vs.85).aspx
	[DllImport(Lib.ComCtl32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Dpa_dsa.h", MSDNShortId = "bb775613")]
	public static extern void DPA_DestroyCallback(HDPA pdpa, PFNDAENUMCALLBACK pfnCB, IntPtr pData);

	/// <summary>
	/// <para>
	/// [ <c>DPA_EnumCallback</c> is available for use in the operating systems specified in the Requirements section. It may be altered
	/// or unavailable in subsequent versions.]
	/// </para>
	/// <para>Iterates through the Dynamic Pointer Array (DPA) and calls pfnCB on each item.</para>
	/// </summary>
	/// <param name="pdpa">
	/// <para>Type: <c>HDPA</c></para>
	/// <para>A handle to a DPA.</para>
	/// </param>
	/// <param name="pfnCB">
	/// <para>Type: <c><c>PFNDPAENUMCALLBACK</c></c></para>
	/// <para>A callback function pointer. See <c>PFNDPAENUMCALLBACK</c> for the callback function prototype.</para>
	/// </param>
	/// <param name="pData">
	/// <para>Type: <c>void*</c></para>
	/// <para>A callback data pointer. pData is passed as a parameter to pfnCB.</para>
	/// </param>
	/// <returns>No return value.</returns>
	// void WINAPI DPA_EnumCallback( HDPA pdpa, PFNDPAENUMCALLBACK pfnCB, void *pData); https://msdn.microsoft.com/en-us/library/windows/desktop/bb775615(v=vs.85).aspx
	[DllImport(Lib.ComCtl32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Dpa_dsa.h", MSDNShortId = "bb775615")]
	public static extern void DPA_EnumCallback(HDPA pdpa, PFNDAENUMCALLBACK pfnCB, IntPtr pData);

	/// <summary>Deletes the last pointer from a dynamic pointer array (DPA).</summary>
	/// <param name="hdpa">A handle to an existing DPA.</param>
	/// <returns>This macro does not return a value.</returns>
	// void DPA_FastDeleteLastPtr( [in] HDPA hdpa); https://msdn.microsoft.com/en-us/library/windows/desktop/bb775586(v=vs.85).aspx
	[PInvokeData("Dpa_dsa.h", MSDNShortId = "bb775586")]
	public static void DPA_FastDeleteLastPtr(HDPA hdpa) => DPA_SetPtrCount(hdpa, DPA_GetPtrCount(hdpa) - 1);

	/// <summary>Gets the value of the specified pointer in the dynamic pointer array (DPA).</summary>
	/// <param name="hdpa">A handle to an existing DPA.</param>
	/// <param name="i">The index of the DPA item.</param>
	/// <returns>No return value.</returns>
	// void DPA_FastGetPtr( [in] HDPA hdpa, [in] int i); https://msdn.microsoft.com/en-us/library/windows/desktop/bb775587(v=vs.85).aspx
	[PInvokeData("Dpa_dsa.h", MSDNShortId = "bb775587")]
	public static IntPtr DPA_FastGetPtr(HDPA hdpa, int i) => Marshal.ReadIntPtr(DPA_GetPtrPtr(hdpa), IntPtr.Size * i);

	/// <summary>
	/// <para>
	/// [ <c>DPA_GetPtr</c> is available for use in the operating systems specified in the Requirements section. It may be altered or
	/// unavailable in subsequent versions.]
	/// </para>
	/// <para>Gets an item from a dynamic pointer array (DPA).</para>
	/// </summary>
	/// <param name="pdpa">
	/// <para>Type: <c>HDPA</c></para>
	/// <para>A handle to a DPA.</para>
	/// </param>
	/// <param name="index">
	/// <para>Type: <c>int</c></para>
	/// <para>The index of item to be retrieved.</para>
	/// </param>
	/// <returns>Returns the specified item or <c>NULL</c>, if the call fails.</returns>
	// void* WINAPI DPA_GetPtr( HDPA pdpa, int index); https://msdn.microsoft.com/en-us/library/windows/desktop/bb775617(v=vs.85).aspx
	[DllImport(Lib.ComCtl32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Dpa_dsa.h", MSDNShortId = "bb775617")]
	public static extern IntPtr DPA_GetPtr(HDPA pdpa, int index);

	/// <summary>Gets the number of pointers in a dynamic pointer array (DPA).</summary>
	/// <param name="hdpa">A handle to an existing DPA.</param>
	/// <returns>Returns the number of pointers (elements) the DPA contains.</returns>
	// int DPA_GetPtrCount( [in] HDPA hdpa); https://msdn.microsoft.com/en-us/library/windows/desktop/bb775588(v=vs.85).aspx
	[PInvokeData("Dpa_dsa.h", MSDNShortId = "bb775588")]
	public static int DPA_GetPtrCount(HDPA hdpa) => Marshal.ReadInt32((IntPtr)hdpa);

	/// <summary>
	/// <para>
	/// [ <c>DPA_GetPtrIndex</c> is available through Windows XP with Service Pack 2 (SP2). It might be altered or unavailable in
	/// subsequent versions.]
	/// </para>
	/// <para>Gets the index of a matching item found in a dynamic pointer array (DPA).</para>
	/// </summary>
	/// <param name="hdpa">
	/// <para>Type: <c>HDPA</c></para>
	/// <para>A handle to an existing DPA.</para>
	/// </param>
	/// <param name="pvoid">
	/// <para>Type: <c>const void*</c></para>
	/// <para>A pointer to an item to locate in hdpa.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>int</c></para>
	/// <para>The index of the item pointed to by pvoid, if found; otherwise, -1.</para>
	/// </returns>
	// int WINAPI DPA_GetPtrIndex( _In_ HDPA hdpa, _In_ const void *pvoid); https://msdn.microsoft.com/en-us/library/windows/desktop/bb775619(v=vs.85).aspx
	[DllImport(Lib.ComCtl32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Dpa_dsa.h", MSDNShortId = "bb775619")]
	public static extern int DPA_GetPtrIndex(HDPA hdpa, IntPtr pvoid);

	/// <summary>Gets the pointer to the internal pointer array of a dynamic pointer array (DPA).</summary>
	/// <param name="hdpa">A handle to an existing DPA.</param>
	/// <returns>
	/// Returns a pointer to the array of pointers managed by the DPA. To retrieve the number of pointers in the array, call macro <c>DPA_GetPtrCount</c>.
	/// </returns>
	// void DPA_GetPtrPtr( [in] HDPA hdpa); https://msdn.microsoft.com/en-us/library/windows/desktop/bb775589(v=vs.85).aspx
	[PInvokeData("Dpa_dsa.h", MSDNShortId = "bb775589")]
	public static IntPtr DPA_GetPtrPtr(HDPA hdpa) => ((IntPtr)hdpa).Offset(IntPtr.Size);

	/// <summary>Gets the size of a dynamic pointer array (DPA).</summary>
	/// <param name="pdpa">
	/// <para>Type: <c>HDPA</c></para>
	/// <para>A handle to an existing DPA.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c><c>ULONGLONG</c></c></para>
	/// <para>
	/// Returns the size of the DPA, including the internal bookkeeping information. If pdpa is <c>NULL</c>, the function returns zero.
	/// </para>
	/// </returns>
	// ULONGLONG DPA_GetSize( _In_ HDPA pdpa); https://msdn.microsoft.com/en-us/library/windows/desktop/bb775621(v=vs.85).aspx
	[DllImport(Lib.ComCtl32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Dpa_dsa.h", MSDNShortId = "bb775621")]
	public static extern ulong DPA_GetSize(HDPA pdpa);

	/// <summary>Changes the number of pointers in a dynamic pointer array (DPA).</summary>
	/// <param name="hdpa">
	/// <para>Type: <c>HDPA</c></para>
	/// <para>A handle to an existing DPA.</para>
	/// </param>
	/// <param name="cp">
	/// <para>Type: <c>int</c></para>
	/// <para>The number of pointers desired in the DPA.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c><c>BOOL</c></c></para>
	/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
	/// </returns>
	// BOOL DPA_Grow( _In_ HDPA hdpa, _In_ int cp); https://msdn.microsoft.com/en-us/library/windows/desktop/bb775623(v=vs.85).aspx
	[DllImport(Lib.ComCtl32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Dpa_dsa.h", MSDNShortId = "bb775623")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DPA_Grow(HDPA hdpa, int cp);

	/// <summary>
	/// <para>
	/// [ <c>DPA_InsertPtr</c> is available for use in the operating systems specified in the Requirements section. It may be altered or
	/// unavailable in subsequent versions.]
	/// </para>
	/// <para>
	/// Inserts a new item at a specified position in a dynamic pointer array (DPA). If neccessary, the DPA expands to accommodate the
	/// new item.
	/// </para>
	/// </summary>
	/// <param name="pdpa">
	/// <para>Type: <c>HDPA</c></para>
	/// <para>A handle to a DPA.</para>
	/// </param>
	/// <param name="index">
	/// <para>Type: <c>int</c></para>
	/// <para>Tbe position where new item is to be inserted.</para>
	/// </param>
	/// <param name="p">
	/// <para>Type: <c>void*</c></para>
	/// <para>A pointer to the item that is to be inserted.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>int</c></para>
	/// <para>Returns the index of the new item or , if the insertion fails.</para>
	/// </returns>
	// int WINAPI DPA_InsertPtr( HDPA pdpa, int index, void *p); https://msdn.microsoft.com/en-us/library/windows/desktop/bb775625(v=vs.85).aspx
	[DllImport(Lib.ComCtl32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Dpa_dsa.h", MSDNShortId = "bb775625")]
	public static extern int DPA_InsertPtr(HDPA pdpa, int index, IntPtr p);

	/// <summary>
	/// <para>[ <c>DPA_LoadStream</c> is available in Windows Vista. It might be altered or unavailable in subsequent versions. ]</para>
	/// <para>Loads the dynamic pointer array (DPA) from a stream by calling the specified callback function to read each element.</para>
	/// </summary>
	/// <param name="ppdpa">
	/// <para>Type: <c>HDPA*</c></para>
	/// <para>A handle to a DPA.</para>
	/// </param>
	/// <param name="pfn">
	/// <para>Type: <c><c>PFNDPASTREAM</c></c></para>
	/// <para>The callback function. See <c>PFNDPASTREAM</c> for the callback function prototype.</para>
	/// </param>
	/// <param name="pstm">
	/// <para>Type: <c><c>IStream</c>*</c></para>
	/// <para>An <c>IStream</c> object.</para>
	/// </param>
	/// <param name="pvInstData">
	/// <para>Type: <c>void*</c></para>
	/// <para>A pointer to callback data. pvInstData is passed as a parameter to pfn.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c><c>HRESULT</c></c></para>
	/// <para>Returns one of the following values.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>Indicates that the callback function was successful and the element was loaded.</term>
	/// </item>
	/// <item>
	/// <term>S_FALSE</term>
	/// <term>Indicates that the callback function was unsuccessful in loading the element; however, the process should continue.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>Indicates that one or more of the parameters is invalid.</term>
	/// </item>
	/// <item>
	/// <term>E_FAIL</term>
	/// <term>Indicates that the stream object could not be read.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>The buffer length is invalid or there was insufficient memory to complete the operation.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </returns>
	// HRESULT WINAPI DPA_LoadStream( _Out_ HDPA *ppdpa, _In_ PFNDPASTREAM pfn, _In_ IStream *pstm, _In_ void *pvInstData); https://msdn.microsoft.com/en-us/library/windows/desktop/bb775627(v=vs.85).aspx
	[DllImport(Lib.ComCtl32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Dpa_dsa.h", MSDNShortId = "bb775627")]
	public static extern HRESULT DPA_LoadStream(out SafeHDPA ppdpa, PFNDPASTREAM pfn, IStream pstm, IntPtr pvInstData);

	/// <summary>
	/// <para>
	/// [ <c>DPA_Merge</c> is available through Windows XP with Service Pack 2 (SP2). It might be altered or unavailable in subsequent versions.]
	/// </para>
	/// <para>Combines the contents of two dynamic pointer arrays (DPAs).</para>
	/// </summary>
	/// <param name="hdpaDest">
	/// <para>Type: <c>HDPA</c></para>
	/// <para>
	/// A handle to the first DPA. This array can be optionally presorted. When this function returns, contains the handle to the merged array.
	/// </para>
	/// </param>
	/// <param name="hdpaSrc">
	/// <para>Type: <c>HDPA</c></para>
	/// <para>A handle to the second DPA. This array can be optionally presorted.</para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>Type: <c><c>DWORD</c></c></para>
	/// <para>
	/// Options determining the method used to merge the two arrays. DPAM_NORMAL, DPAM_UNION, and DPAM_UNION are mutually exclusive—only
	/// one of those flags can be set, optionally in conjunction with DPAM_SORTED.
	/// </para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>DPAM_SORTED0x00000001</term>
	/// <term>The arrays are presorted; skip sorting. If this flag is not set, the arrays are sorted before they are merged.</term>
	/// </item>
	/// <item>
	/// <term>DPAM_NORMAL0x00000002</term>
	/// <term>
	/// The final array consists of all of the elements originally present in hdpaDest. If any of those elements are also found in
	/// hdpaSrc, those elements are merged in the final array. The PFNDPAMERGE callback function is called with the DPAMM_MERGE message.
	/// When this flag is set, the final size of the array at hdpaDest is the same as its initial size.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DPAM_UNION0x00000004</term>
	/// <term>
	/// The final array is the union of all elements in both arrays. Elements found in both arrays are merged in the final array.
	/// Elements found in only one array or the other are added as found. When this flag is set, the PFNDPAMERGE callback function can be
	/// called with the DPAMM_MERGE or DPAMM_INSERT message. The final size of the array is at least the size of the larger of hdpaDest
	/// and hdpaSrc, and at most the sum of the two.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DPAM_INTERSECT0x00000008</term>
	/// <term>
	/// Only elements found in both hdpaSrc and hdpaDest are merged to form the final array. When this flag is set, the PFNDPAMERGE
	/// callback function can be called with the DPAMM_MERGE or DPAMM_DELETE message. The final size of the array can range between 0 and
	/// the smaller of hdpaDest and hdpaSrc.
	/// </term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <param name="pfnCompare">
	/// <para>Type: <c><c>PFNDPACOMPARE</c></c></para>
	/// <para>
	/// The <c>PFNDPACOMPARE</c> callback function that compares two elements, one from each DPA, to determine whether they are the same
	/// item. If so, the callback function pointed to by pfnCompare is called.
	/// </para>
	/// </param>
	/// <param name="pfnMerge">
	/// <para>Type: <c><c>PFNDPAMERGE</c></c></para>
	/// <para>
	/// The <c>PFNDPAMERGE</c> callback function that merges the contents when an element is found in both DPAs and is found to be the
	/// same item by <c>PFNDPACOMPARE</c>.
	/// </para>
	/// </param>
	/// <param name="lParam">
	/// <para>Type: <c><c>LPARAM</c></c></para>
	/// <para>Additional parameter used to declare the basis of comparison upon which equality is determined.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c><c>BOOL</c></c></para>
	/// <para><c>TRUE</c> if successful; otherwise, <c>FALSE</c>.</para>
	/// </returns>
	// BOOL WINAPI DPA_Merge( _Inout_ HDPA hdpaDest, _In_ HDPA hdpaSrc, _In_ DWORD dwFlags, _In_ PFNDPACOMPARE pfnCompare, _In_
	// PFNDPAMERGE pfnMerge, _In_ LPARAM lParam); https://msdn.microsoft.com/en-us/library/windows/desktop/bb775629(v=vs.85).aspx
	[DllImport(Lib.ComCtl32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Dpa_dsa.h", MSDNShortId = "bb775629")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DPA_Merge(HDPA hdpaDest, HDPA hdpaSrc, DPAM dwFlags, PFNDACOMPARE pfnCompare, PFNDPAMERGE pfnMerge, IntPtr lParam);

	/// <summary>
	/// <para>[ <c>DPA_SaveStream</c> is available in Windows Vista. It might be altered or unavailable in subsequent versions. ]</para>
	/// <para>
	/// Saves the dynamic pointer array (DPA) to a stream by writing out a header, and then calling the specified callback function to
	/// write each element.
	/// </para>
	/// </summary>
	/// <param name="pdpa">
	/// <para>Type: <c>HDPA</c></para>
	/// <para>Receives a handle to a DPA.</para>
	/// </param>
	/// <param name="pfn">
	/// <para>Type: <c><c>PFNDPASTREAM</c></c></para>
	/// <para>The callback function. See <c>PFNDPASTREAM</c> for the callback function prototype.</para>
	/// </param>
	/// <param name="pstm">
	/// <para>Type: <c><c>IStream</c>*</c></para>
	/// <para>An <c>IStream</c> object.</para>
	/// </param>
	/// <param name="pvInstData">
	/// <para>Type: <c>void*</c></para>
	/// <para>A pointer to callback data. pvInstData is passed as a parameter to pfn.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c><c>HRESULT</c></c></para>
	/// <para>Returns one of the following values.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>Indicates that the callback function was unsuccessful in saving the element; however, the process should continue.</term>
	/// </item>
	/// <item>
	/// <term>S_FALSE</term>
	/// <term>Indicates that even though the callback was unsuccessful, the process was uninterrupted.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>Indicates that one or more of the parameters is invalid.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </returns>
	// HRESULT WINAPI DPA_SaveStream( _In_ HDPA pdpa, _In_ PFNDPASTREAM pfn, _In_ IStream *pstm, _In_ void *pvInstData); https://msdn.microsoft.com/en-us/library/windows/desktop/bb775631(v=vs.85).aspx
	[DllImport(Lib.ComCtl32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Dpa_dsa.h", MSDNShortId = "bb775631")]
	public static extern HRESULT DPA_SaveStream(HDPA pdpa, PFNDPASTREAM pfn, IStream pstm, IntPtr pvInstData);

	/// <summary>
	/// <para>
	/// [ <c>DPA_Search</c> is available for use in the operating systems specified in the Requirements section. It may be altered or
	/// unavailable in subsequent versions.]
	/// </para>
	/// <para>Finds an item in a dynamic pointer array (DPA).</para>
	/// </summary>
	/// <param name="pdpa">
	/// <para>Type: <c>HDPA</c></para>
	/// <para>A handle to a DPA.</para>
	/// </param>
	/// <param name="pFind">
	/// <para>Type: <c>void*</c></para>
	/// <para>A pointer to search for.</para>
	/// </param>
	/// <param name="iStart">
	/// <para>Type: <c>int</c></para>
	/// <para>The index at which to start search.</para>
	/// </param>
	/// <param name="pfnCmp">
	/// <para>Type: <c><c>PFNDPACOMPARE</c></c></para>
	/// <para>A comparison function pointer. See <c>PFNDPACOMPARE</c> for the comparison function prototype.</para>
	/// </param>
	/// <param name="lParam">
	/// <para>Type: <c><c>LPARAM</c></c></para>
	/// <para>An additional parameter to be passed to pfnCmp.</para>
	/// </param>
	/// <param name="options">
	/// <para>Type: <c><c>UINT</c></c></para>
	/// <para>This parameter may be one or more of the following.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>DPAS_SORTED</term>
	/// <term>Indicates that the DPA is sorted.</term>
	/// </item>
	/// <item>
	/// <term>DPAS_INSERTBEFORE</term>
	/// <term>
	/// This value is only valid in conjunction with DPAS_SORTED. If the item is not found, return the position where the item is
	/// expected to be found in the sorted DPA.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DPAS_INSERTAFTER</term>
	/// <term>
	/// This value is only valid in conjunction with DPAS_SORTED. If the item is not found, return the position where the item is
	/// expected to be found in the sorted DPA.
	/// </term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>int</c></para>
	/// <para>Returns the index where the item was found in the DPA or if the item was not found.</para>
	/// </returns>
	// int WINAPI DPA_Search( HDPA pdpa, void *pFind, int iStart, PFNDPACOMPARE pfnCmp, LPARAM lParam, UINT options); https://msdn.microsoft.com/en-us/library/windows/desktop/bb775633(v=vs.85).aspx
	[DllImport(Lib.ComCtl32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Dpa_dsa.h", MSDNShortId = "bb775633")]
	public static extern int DPA_Search(HDPA pdpa, IntPtr pFind, int iStart, PFNDACOMPARE pfnCmp, IntPtr lParam, DPAS options);

	/// <summary>
	/// <para>
	/// [ <c>DPA_SetPtr</c> is available for use in the operating systems specified in the Requirements section. It may be altered or
	/// unavailable in subsequent versions.]
	/// </para>
	/// <para>Assigns a value to an item in a dynamic pointer array (DPA).</para>
	/// </summary>
	/// <param name="pdpa">
	/// <para>Type: <c>HDPA</c></para>
	/// <para>A handle to a DPA.</para>
	/// </param>
	/// <param name="index">
	/// <para>Type: <c>int</c></para>
	/// <para>The index of the item in the DPA.</para>
	/// </param>
	/// <param name="p">
	/// <para>Type: <c>void*</c></para>
	/// <para>A pointer to the value to assign to the specified DPA item.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c><c>BOOL</c></c></para>
	/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
	/// </returns>
	// BOOL WINAPI DPA_SetPtr( HDPA pdpa, int index, void *p); https://msdn.microsoft.com/en-us/library/windows/desktop/bb775635(v=vs.85).aspx
	[DllImport(Lib.ComCtl32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Dpa_dsa.h", MSDNShortId = "bb775635")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DPA_SetPtr(HDPA pdpa, int index, IntPtr p);

	/// <summary>Sets the number of pointers in a dynamic pointer array (DPA).</summary>
	/// <param name="hdpa">A handle to an existing DPA.</param>
	/// <param name="cItems">The number of items in the DPA.</param>
	/// <returns>Returns the number of pointers (elements) the DPA contains.</returns>
	// int DPA_SetPtrCount( [in] HDPA hdpa, [in] int cItems); https://msdn.microsoft.com/en-us/library/windows/desktop/dd375911(v=vs.85).aspx
	[PInvokeData("Dpa_dsa.h", MSDNShortId = "dd375911")]
	public static int DPA_SetPtrCount(HDPA hdpa, int cItems) { Marshal.WriteInt32((IntPtr)hdpa, cItems); return cItems; }

	/// <summary>
	/// <para>
	/// [ <c>DPA_Sort</c> is available for use in the operating systems specified in the Requirements section. It may be altered or
	/// unavailable in subsequent versions.]
	/// </para>
	/// <para>Sorts the items in a Dynamic Pointer Array (DPA).</para>
	/// </summary>
	/// <param name="pdpa">
	/// <para>Type: <c>HDPA</c></para>
	/// <para>A handle to a DPA.</para>
	/// </param>
	/// <param name="pfnCmp">
	/// <para>Type: <c><c>PFNDPACOMPARE</c></c></para>
	/// <para>A comparison function pointer. See <c>PFNDPACOMPARE</c> for the comparison function prototype.</para>
	/// </param>
	/// <param name="lParam">
	/// <para>Type: <c><c>LPARAM</c></c></para>
	/// <para>An additional parameter to be passed to pfnCmp.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c><c>BOOL</c></c></para>
	/// <para>Returns <c>TRUE</c> on success or <c>FALSE</c> on failure.</para>
	/// </returns>
	// BOOL WINAPI DPA_Sort( HDPA pdpa, PFNDPACOMPARE pfnCmp, LPARAM lParam); https://msdn.microsoft.com/en-us/library/windows/desktop/bb775637(v=vs.85).aspx
	[DllImport(Lib.ComCtl32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Dpa_dsa.h", MSDNShortId = "bb775637")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DPA_Sort(HDPA pdpa, PFNDACOMPARE pfnCmp, IntPtr lParam);

	/// <summary>Inserts a new item before or after a specified existing item.</summary>
	/// <param name="pdpa">
	/// <para>Type: <c>HDPA</c></para>
	/// <para>A handle to a DPA.</para>
	/// </param>
	/// <param name="pFind">
	/// <para>Type: <c>void*</c></para>
	/// <para>An item pointer which is used to determine the insertion point for the new item (see Remarks).</para>
	/// </param>
	/// <param name="iStart">
	/// <para>Type: <c>int</c></para>
	/// <para>The index in the DPA at which to begin searching for pFind.</para>
	/// </param>
	/// <param name="pfnCmp">
	/// <para>Type: <c><c>PFNDPACOMPARE</c></c></para>
	/// <para>
	/// A pointer to the comparison function. See <c>PFNDPACOMPARE</c> or <c>PFNDPACOMPARECONST</c> for the comparison function prototype.
	/// </para>
	/// </param>
	/// <param name="lParam">
	/// <para>Type: <c><c>LPARAM</c></c></para>
	/// <para>An additional parameter used to pass information to the comparison function pointed to by pfnCmp.</para>
	/// </param>
	/// <param name="options">
	/// <para>Type: <c><c>UINT</c></c></para>
	/// <para>The insertion point. Must be one of the following values.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>DPAS_INSERTBEFORE</term>
	/// <term>Insert the new item before the pFind item.</term>
	/// </item>
	/// <item>
	/// <term>DPAS_INSERTAFTER</term>
	/// <term>Insert the new item after the pFind item.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <param name="pitem">
	/// <para>Type: <c>void*</c></para>
	/// <para>A pointer to the item that is to be inserted.</para>
	/// </param>
	/// <returns>Returns the index of the new item or , if the insert action fails.</returns>
	// int DPA_SortedInsertPtr( HDPA pdpa, void *pFind, int iStart, PFNDPACOMPARE pfnCmp, LPARAM lParam, UINT options, void *pitem); https://msdn.microsoft.com/en-us/library/windows/desktop/bb775590(v=vs.85).aspx
	[PInvokeData("Dpa_dsa.h", MSDNShortId = "bb775590")]
	public static int DPA_SortedInsertPtr(HDPA pdpa, IntPtr pFind, int iStart, PFNDACOMPARE pfnCmp, IntPtr lParam, DPAS options, IntPtr pitem) =>
		DPA_InsertPtr(pdpa, DPA_Search(pdpa, pFind, iStart, pfnCmp, lParam, DPAS.DPAS_SORTED | options), pitem);

	/// <summary>Appends a new item to the end of a dynamic structure array (DSA).</summary>
	/// <param name="pdsa">A handle to the DSA in which to insert the item.</param>
	/// <param name="pItem">A pointer to the item that is to be inserted.</param>
	/// <returns>Returns the index of the new item if the append action succeeds, or if the append action fails.</returns>
	// int DSA_AppendItem( [in] HDSA pdsa, [in] void *pItem); https://msdn.microsoft.com/en-us/library/windows/desktop/bb775591(v=vs.85).aspx
	[PInvokeData("Dpa_dsa.h", MSDNShortId = "bb775591")]
	public static int DSA_AppendItem(HDSA pdsa, IntPtr pItem) => DSA_InsertItem(pdsa, DA_LAST, pItem);

	/// <summary>Duplicates a dynamic structure array (DSA).</summary>
	/// <param name="hdsa">
	/// <para>Type: <c>HDSA</c></para>
	/// <para>A handle to an existing DSA.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HDSA</c></para>
	/// <para>Returns a handle to the clone, or <c>NULL</c> if the operation fails.</para>
	/// </returns>
	// HDSA DSA_Clone( _In_ HDSA hdsa); https://msdn.microsoft.com/en-us/library/windows/desktop/bb775645(v=vs.85).aspx
	[DllImport(Lib.ComCtl32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Dpa_dsa.h", MSDNShortId = "bb775645")]
	public static extern SafeHDSA DSA_Clone(HDSA hdsa);

	/// <summary>
	/// <para>
	/// [ <c>DSA_Create</c> is available for use in the operating systems specified in the Requirements section. It may be altered or
	/// unavailable in subsequent versions.]
	/// </para>
	/// <para>Creates a dynamic structure array (DSA).</para>
	/// </summary>
	/// <param name="cbItem">
	/// <para>Type: <c>int</c></para>
	/// <para>The size, in bytes, of the item.</para>
	/// </param>
	/// <param name="cbItemGrow">
	/// <para>Type: <c>int</c></para>
	/// <para>The number of items by which the array should be incremented, if the DSA needs to be enlarged.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HDSA</c></para>
	/// <para>Returns a handle to a DSA if successful, or <c>NULL</c> if the creation fails.</para>
	/// </returns>
	// HDSA WINAPI DSA_Create( _In_ int cbItem, _In_ int cbItemGrow); https://msdn.microsoft.com/en-us/library/windows/desktop/bb775647(v=vs.85).aspx
	[DllImport(Lib.ComCtl32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Dpa_dsa.h", MSDNShortId = "bb775647")]
	public static extern SafeHDSA DSA_Create(int cbItem, int cbItemGrow);

	/// <summary>Deletes all items from a dynamic structure array (DSA).</summary>
	/// <param name="hdsa">
	/// <para>Type: <c>HDSA</c></para>
	/// <para>A handle to an existing DSA.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c><c>BOOL</c></c></para>
	/// <para><c>TRUE</c> if the items were successfully deleted; otherwise, <c>FALSE</c>.</para>
	/// </returns>
	// BOOL DSA_DeleteAllItems( _In_ HDSA hdsa); https://msdn.microsoft.com/en-us/library/windows/desktop/bb775649(v=vs.85).aspx
	[DllImport(Lib.ComCtl32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Dpa_dsa.h", MSDNShortId = "bb775649")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DSA_DeleteAllItems(HDSA hdsa);

	/// <summary>
	/// <para>
	/// [ <c>DSA_DeleteItem</c> is available through Windows XP with Service Pack 2 (SP2). It might be altered or unavailable in
	/// subsequent versions.]
	/// </para>
	/// <para>Deletes an item from a dynamic structure array (DSA).</para>
	/// </summary>
	/// <param name="hdsa">
	/// <para>Type: <c>HDSA</c></para>
	/// <para>A handle to an existing DSA.</para>
	/// </param>
	/// <param name="nPosition">
	/// <para>Type: <c>int</c></para>
	/// <para>The zero-based index of the item to delete.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c><c>BOOL</c></c></para>
	/// <para><c>TRUE</c> if the item was successfully deleted; otherwise, <c>FALSE</c>.</para>
	/// </returns>
	// BOOL WINAPI DSA_DeleteItem( _In_ HDSA hdsa, _In_ int nPosition); https://msdn.microsoft.com/en-us/library/windows/desktop/bb775651(v=vs.85).aspx
	[DllImport(Lib.ComCtl32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Dpa_dsa.h", MSDNShortId = "bb775651")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DSA_DeleteItem(HDSA hdsa, int nPosition);

	/// <summary>
	/// <para>
	/// [ <c>DSA_Destroy</c> is available for use in the operating systems specified in the Requirements section. It may be altered or
	/// unavailable in subsequent versions.]
	/// </para>
	/// <para>Frees a dynamic structure array (DSA).</para>
	/// </summary>
	/// <param name="pdsa">
	/// <para>Type: <c>HDSA</c></para>
	/// <para>A handle to a DSA to destroy.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c><c>BOOL</c></c></para>
	/// <para>Returns <c>TRUE</c> on success, <c>FALSE</c> on failure.</para>
	/// </returns>
	// BOOL WINAPI DSA_Destroy( _In_ HDSA pdsa); https://msdn.microsoft.com/en-us/library/windows/desktop/bb775653(v=vs.85).aspx
	[DllImport(Lib.ComCtl32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Dpa_dsa.h", MSDNShortId = "bb775653")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DSA_Destroy(HDSA pdsa);

	/// <summary>
	/// <para>
	/// [ <c>DSA_DestroyCallback</c> is available for use in the operating systems specified in the Requirements section. It may be
	/// altered or unavailable in subsequent versions.]
	/// </para>
	/// <para>
	/// Iterates through a dynamic structure array (DSA), calling a specified callback function on each item. Upon reaching the end of
	/// the array, the DSA is freed.
	/// </para>
	/// </summary>
	/// <param name="pdsa">
	/// <para>Type: <c>HDSA</c></para>
	/// <para>A handle to a DSA to walk and destroy.</para>
	/// </param>
	/// <param name="pfnCB">
	/// <para>Type: <c><c>PFNDSAENUMCALLBACK</c></c></para>
	/// <para>A callback function pointer. For the callback function prototype, see <c>PFNDSAENUMCALLBACK</c>.</para>
	/// </param>
	/// <param name="pData">
	/// <para>Type: <c>void*</c></para>
	/// <para>A callback data pointer. This pointer is, in turn, passed as a parameter to pfnCB.</para>
	/// </param>
	/// <returns>This function does not return a value.</returns>
	// void WINAPI DSA_DestroyCallback( _In_ HDSA pdsa, _In_ PFNDSAENUMCALLBACK pfnCB, _In_ void *pData); https://msdn.microsoft.com/en-us/library/windows/desktop/bb775655(v=vs.85).aspx
	[DllImport(Lib.ComCtl32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Dpa_dsa.h", MSDNShortId = "bb775655")]
	public static extern void DSA_DestroyCallback(HDSA pdsa, PFNDAENUMCALLBACK pfnCB, IntPtr pData);

	/// <summary>Iterates through the dynamic structure array (DSA) and calls pfnCB on each item.</summary>
	/// <param name="hdsa">
	/// <para>Type: <c>HDSA</c></para>
	/// <para>A handle to an existing DSA.</para>
	/// </param>
	/// <param name="pfnCB">
	/// <para>Type: <c><c>PFNDAENUMCALLBACK</c>*</c></para>
	/// <para>A callback function pointer. See <c>PFNDSAENUMCALLBACK</c> for the callback function prototype.</para>
	/// </param>
	/// <param name="pData">
	/// <para>Type: <c>void*</c></para>
	/// <para>A callback data pointer. pData is passed as a parameter to pfnCB.</para>
	/// </param>
	/// <returns>This function does not return a value.</returns>
	// void DSA_EnumCallback( _In_ HDSA hdsa, _In_ PFNDAENUMCALLBACK *pfnCB, _In_ void *pData); https://msdn.microsoft.com/en-us/library/windows/desktop/bb775657(v=vs.85).aspx
	[DllImport(Lib.ComCtl32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Dpa_dsa.h", MSDNShortId = "bb775657")]
	public static extern void DSA_EnumCallback(HDSA hdsa, PFNDAENUMCALLBACK pfnCB, IntPtr pData);

	/// <summary>Gets an element from a dynamic structure array (DSA).</summary>
	/// <param name="pdsa">
	/// <para>Type: <c>HDSA</c></para>
	/// <para>A handle to the DSA containing the element.</para>
	/// </param>
	/// <param name="index">
	/// <para>Type: <c>int</c></para>
	/// <para>The index of the element to be retrieved (zero-based).</para>
	/// </param>
	/// <param name="pitem">
	/// <para>Type: <c>void*</c></para>
	/// <para>A pointer to a buffer which is filled with a copy of the specified element of the DSA.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c><c>BOOL</c></c></para>
	/// <para>Returns <c>TRUE</c> if successful or <c>FALSE</c> otherwise.</para>
	/// </returns>
	// BOOL WINAPI DSA_GetItem( _In_ HDSA pdsa, _In_ int index, _Out_ void *pitem); https://msdn.microsoft.com/en-us/library/windows/desktop/bb775659(v=vs.85).aspx
	[DllImport(Lib.ComCtl32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Dpa_dsa.h", MSDNShortId = "bb775659")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DSA_GetItem(HDSA pdsa, int index, [Out] IntPtr pitem);

	/// <summary>Gets the number of items in a dynamic structure array (DSA).</summary>
	/// <param name="hdsa">A handle to an existing DSA.</param>
	/// <returns>Returns the number of items in the DSA.</returns>
	// int DSA_GetItemCount( [in] HDSA hdsa); https://msdn.microsoft.com/en-us/library/windows/desktop/bb775592(v=vs.85).aspx
	[PInvokeData("Dpa_dsa.h", MSDNShortId = "bb775592")]
	public static int DSA_GetItemCount(HDSA hdsa) => Marshal.ReadInt32((IntPtr)hdsa);

	/// <summary>
	/// <para>
	/// [ <c>DSA_GetItemPtr</c> is available for use in the operating systems specified in the Requirements section. It may be altered or
	/// unavailable in subsequent versions.]
	/// </para>
	/// <para>Gets a pointer to an element from a dynamic structure array (DSA).</para>
	/// </summary>
	/// <param name="pdsa">
	/// <para>Type: <c>HDSA</c></para>
	/// <para>A handle to the DSA containing the element.</para>
	/// </param>
	/// <param name="index">
	/// <para>Type: <c>int</c></para>
	/// <para>The index of the element to be retrieved (zero-based).</para>
	/// </param>
	/// <returns>Returns a pointer to the specified element or <c>NULL</c> if the call fails.</returns>
	// void* WINAPI DSA_GetItemPtr( _In_ HDSA pdsa, _In_ int index); https://msdn.microsoft.com/en-us/library/windows/desktop/bb775661(v=vs.85).aspx
	[DllImport(Lib.ComCtl32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Dpa_dsa.h", MSDNShortId = "bb775661")]
	public static extern IntPtr DSA_GetItemPtr(HDSA pdsa, int index);

	/// <summary>Gets the size of the dynamic structure array (DSA).</summary>
	/// <param name="hdsa">
	/// <para>Type: <c>HDSA</c></para>
	/// <para>A handle to an existing DSA.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c><c>ULONGLONG</c></c></para>
	/// <para>
	/// Returns the size of the DSA, including the internal bookkeeping information, in bytes. If hdsa is <c>NULL</c>, the function
	/// returns zero.
	/// </para>
	/// </returns>
	// ULONGLONG DSA_GetSize( _In_ HDSA hdsa); https://msdn.microsoft.com/en-us/library/windows/desktop/bb775663(v=vs.85).aspx
	[DllImport(Lib.ComCtl32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Dpa_dsa.h", MSDNShortId = "bb775663")]
	public static extern ulong DSA_GetSize(HDSA hdsa);

	/// <summary>
	/// <para>
	/// [ <c>DSA_InsertItem</c> is available for use in the operating systems specified in the Requirements section. It may be altered or
	/// unavailable in subsequent versions.]
	/// </para>
	/// <para>Inserts a new item into a dynamic structure array (DSA). If necessary, the DSA expands to accommodate the new item.</para>
	/// </summary>
	/// <param name="pdsa">
	/// <para>Type: <c>HDSA</c></para>
	/// <para>A handle to the DSA in which to insert the item.</para>
	/// </param>
	/// <param name="index">
	/// <para>Type: <c>int</c></para>
	/// <para>The position in the DSA where new item is to be inserted, or DSA_APPEND to insert the item at the end of the array.</para>
	/// </param>
	/// <param name="pItem">
	/// <para>Type: <c>void*</c></para>
	/// <para>A pointer to the item that is to be inserted.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>int</c></para>
	/// <para>Returns the index of the new item if the insertion succeeds, or DSA_ERR () if the insertion fails.</para>
	/// </returns>
	// int WINAPI DSA_InsertItem( _In_ HDSA pdsa, _In_ int index, _In_ void *pItem); https://msdn.microsoft.com/en-us/library/windows/desktop/bb775665(v=vs.85).aspx
	[DllImport(Lib.ComCtl32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Dpa_dsa.h", MSDNShortId = "bb775665")]
	public static extern int DSA_InsertItem(HDSA pdsa, int index, IntPtr pItem);

	/// <summary>
	/// <para>
	/// [ <c>DSA_SetItem</c> is available for use in the operating systems specified in the Requirements section. It may be altered or
	/// unavailable in subsequent versions.]
	/// </para>
	/// <para>Inserts a new item into a dynamic structure array (DSA). If necessary, the DSA expands to accommodate the new item.</para>
	/// </summary>
	/// <param name="pdsa">
	/// <para>Type: <c>HDSA</c></para>
	/// <para>A handle to an existing DSA that contains the element.</para>
	/// </param>
	/// <param name="index">
	/// <para>Type: <c>int</c></para>
	/// <para>The zero-based index of the item to set.</para>
	/// </param>
	/// <param name="pItem">
	/// <para>Type: <c>void*</c></para>
	/// <para>A pointer to the item that will replace the specified item in the array.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>Returns <c>TRUE</c> on success or <c>FALSE</c> on failure.</para>
	/// </returns>
	// BOOL WINAPI DSA_SetItem( _In_ HDSA hdsa, _In_ int index, _In_ void *pItem); https://msdn.microsoft.com/en-us/library/windows/desktop/bb775668(v=vs.85).aspx
	[DllImport(Lib.ComCtl32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Dpa_dsa.h", MSDNShortId = "bb775668")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DSA_SetItem(HDSA pdsa, int index, IntPtr pItem);

	/// <summary>Sorts the items in a dynamic structure array (DSA).</summary>
	/// <param name="pdsa">
	/// <para>Type: <c>HDSA</c></para>
	/// <para>A handle to an existing DSA.</para>
	/// </param>
	/// <param name="pfnCompare">
	/// <para>Type: <c><c>PFNDACOMPARE</c></c></para>
	/// <para>A comparison function pointer. See <c>PFNDPACOMPARE</c> for the comparison function prototype.</para>
	/// </param>
	/// <param name="lParam">
	/// <para>Type: <c><c>LPARAM</c></c></para>
	/// <para>An additional parameter to be passed to pfnCmp.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c><c>BOOL</c></c></para>
	/// <para>Returns <c>TRUE</c> on success or <c>FALSE</c> on failure.</para>
	/// </returns>
	// BOOL DSA_Sort( _In_ HDSA pdsa, _In_ PFNDACOMPARE pfnCompare, _In_ LPARAM lParam); https://msdn.microsoft.com/en-us/library/windows/desktop/bb775670(v=vs.85).aspx
	[DllImport(Lib.ComCtl32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Dpa_dsa.h", MSDNShortId = "bb775670")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DSA_Sort(HDSA pdsa, PFNDACOMPARE pfnCompare, IntPtr lParam);

	/// <summary>Sets ppszCurrent to a copy of pszNew and frees the previous value, if necessary.</summary>
	/// <param name="ppszCurrent">
	/// <para>Type: <c><c>LPTSTR</c>*</c></para>
	/// <para>The address of a pointer to the current string. The current string is freed and the pointer is set to a copy of pszNew.</para>
	/// </param>
	/// <param name="pszNew">
	/// <para>Type: <c><c>LPCTSTR</c></c></para>
	/// <para>A pointer to the string to copy into ppszCurrent.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c><c>BOOL</c></c></para>
	/// <para>Returns <c>TRUE</c> if successful; otherwise, <c>FALSE</c>.</para>
	/// </returns>
	// BOOL WINAPI Str_SetPtr( _Inout_ LPTSTR *ppszCurrent, LPCTSTR pszNew); https://msdn.microsoft.com/en-us/library/windows/desktop/bb775735(v=vs.85).aspx
	[DllImport(Lib.ComCtl32, SetLastError = false, EntryPoint = "Str_SetPtrW", CharSet = CharSet.Unicode)]
	[PInvokeData("Commctrl.h", MSDNShortId = "bb775735")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool Str_SetPtr(ref IntPtr ppszCurrent, string pszNew);

	/// <summary>Contains a stream item used by the <c>PFNDPASTREAM</c> callback function.</summary>
	// typedef struct _DPASTREAMINFO { int iPos; void *pvItem;} DPASTREAMINFO; https://msdn.microsoft.com/en-us/library/windows/desktop/bb775504(v=vs.85).aspx
	[PInvokeData("Dpa_dsa.h", MSDNShortId = "bb775504")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DPASTREAMINFO
	{
		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>An index of the item in the DPA.</para>
		/// </summary>
		public int iPos;

		/// <summary>
		/// <para>Type: <c>void*</c></para>
		/// <para>A void pointer to the item data.</para>
		/// </summary>
		public IntPtr pvItem;
	}

	/// <summary>Provides a <see cref="SafeHandle"/> to a that releases a created HDPA instance at disposal using DPA_Destroy.</summary>
	[AutoSafeHandle("DPA_Destroy(handle)", typeof(HDPA))]
	public partial class SafeHDPA { }

	/// <summary>Provides a <see cref="SafeHandle"/> to a that releases a created HDSA instance at disposal using DSA_Destroy.</summary>
	[AutoSafeHandle("DSA_Destroy(handle)", typeof(HDSA))]
	public partial class SafeHDSA { }
}