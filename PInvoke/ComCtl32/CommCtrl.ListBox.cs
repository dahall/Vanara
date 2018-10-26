using System.Drawing;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class ComCtl32
	{
		/// <summary>Draws the insert icon in the parent window of the specified drag list box.</summary>
		/// <param name="handParent">
		/// <para>Type: <c><c>HWND</c></c></para>
		/// <para>A handle to the parent window of the drag list box.</para>
		/// </param>
		/// <param name="hLB">
		/// <para>Type: <c><c>HWND</c></c></para>
		/// <para>A handle to the drag list box.</para>
		/// </param>
		/// <param name="nItem">
		/// <para>Type: <c>int</c></para>
		/// <para>The identifier of the icon item to be drawn.</para>
		/// </param>
		/// <returns>No return value.</returns>
		// void DrawInsert( HWND handParent, HWND hLB, int nItem); https://msdn.microsoft.com/en-us/library/windows/desktop/bb761723(v=vs.85).aspx
		[DllImport(Lib.ComCtl32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Commctrl.h", MSDNShortId = "bb761723")]
		public static extern void DrawInsert(HWND handParent, HWND hLB, int nItem);

		/// <summary>Retrieves the index of the item at the specified point in a list box.</summary>
		/// <param name="hLB">
		/// <para>Type: <c><c>HWND</c></c></para>
		/// <para>A handle to the list box to check.</para>
		/// </param>
		/// <param name="pt">
		/// <para>Type: <c><c>POINT</c></c></para>
		/// <para>A <c>POINT</c> structure that contains the screen coordinates to check.</para>
		/// </param>
		/// <param name="bAutoScroll">
		/// <para>Type: <c><c>BOOL</c></c></para>
		/// <para>
		/// A scroll flag. If this parameter is <c>TRUE</c> and the point is directly above or below the list box, the function scrolls the
		/// list box by one line and returns -1. Otherwise, the function does not scroll the list box.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>int</c></para>
		/// <para>Returns the item identifier if the point is over a list item, or -1 otherwise.</para>
		/// </returns>
		// int LBItemFromPt( HWND hLB, POINT pt, BOOL bAutoScroll); https://msdn.microsoft.com/en-us/library/windows/desktop/bb761724(v=vs.85).aspx
		[DllImport(Lib.ComCtl32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Commctrl.h", MSDNShortId = "bb761724")]
		public static extern int LBItemFromPt(HWND hLB, Point pt, [MarshalAs(UnmanagedType.Bool)] bool bAutoScroll);

		/// <summary>Changes the specified single-selection list box to a drag list box.</summary>
		/// <param name="hLB">
		/// <para>Type: <c><c>HWND</c></c></para>
		/// <para>A handle to the single-selection list box.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c><c>BOOL</c></c></para>
		/// <para>Returns nonzero if successful, or zero otherwise.</para>
		/// </returns>
		// BOOL MakeDragList( HWND hLB); https://msdn.microsoft.com/en-us/library/windows/desktop/bb761725(v=vs.85).aspx
		[DllImport(Lib.ComCtl32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Commctrl.h", MSDNShortId = "bb761725")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool MakeDragList(HWND hLB);
	}
}