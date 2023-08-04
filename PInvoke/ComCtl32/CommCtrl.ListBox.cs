namespace Vanara.PInvoke;

public static partial class ComCtl32
{
	/// <summary>The name of the registered message used to handle drag list box messages.</summary>
	public const string DRAGLISTMSGSTRING = "commctrl_DragListMsg";

	/// <summary>Return value from drag list box message handler.</summary>
	public static readonly IntPtr DL_COPYCURSOR = (IntPtr)2;

	/// <summary>Return value from drag list box message handler.</summary>
	public static readonly IntPtr DL_CURSORSET = (IntPtr)0;

	/// <summary>Return value from drag list box message handler.</summary>
	public static readonly IntPtr DL_MOVECURSOR = (IntPtr)3;

	/// <summary>Return value from drag list box message handler.</summary>
	public static readonly IntPtr DL_STOPCURSOR = (IntPtr)1;

	/// <summary>
	/// Contains information about a drag event. The pointer to <c>DRAGLISTINFO</c> is passed as the <c>lParam</c> parameter of the drag list message.
	/// </summary>
	[PInvokeData("commctrl.h", MSDNShortId = "NS:commctrl.tagDRAGLISTINFO")]
	public enum DL : uint
	{
		/// <summary>The user has clicked the left mouse button on a list item.</summary>
		DL_BEGINDRAG = User32.WM_USER + 0x133,

		/// <summary>The user has canceled the drag operation by clicking the right mouse button or pressing the ESC key.</summary>
		DL_CANCELDRAG = User32.WM_USER + 0x136,

		/// <summary>The user has moved the mouse while dragging an item.</summary>
		DL_DRAGGING = User32.WM_USER + 0x134,

		/// <summary>The user has released the left mouse button, completing a drag operation.</summary>
		DL_DROPPED = User32.WM_USER + 0x135,
	}

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
	/// A scroll flag. If this parameter is <c>TRUE</c> and the point is directly above or below the list box, the function scrolls the list
	/// box by one line and returns -1. Otherwise, the function does not scroll the list box.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>int</c></para>
	/// <para>Returns the item identifier if the point is over a list item, or -1 otherwise.</para>
	/// </returns>
	// int LBItemFromPt( HWND hLB, POINT pt, BOOL bAutoScroll); https://msdn.microsoft.com/en-us/library/windows/desktop/bb761724(v=vs.85).aspx
	[DllImport(Lib.ComCtl32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Commctrl.h", MSDNShortId = "bb761724")]
	public static extern int LBItemFromPt(HWND hLB, POINT pt, [MarshalAs(UnmanagedType.Bool)] bool bAutoScroll);

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

	/// <summary>
	/// Contains information about a drag event. The pointer to <c>DRAGLISTINFO</c> is passed as the <c>lParam</c> parameter of the drag list message.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/commctrl/ns-commctrl-draglistinfo typedef struct tagDRAGLISTINFO { UINT
	// uNotification; HWND hWnd; POINT ptCursor; } DRAGLISTINFO, *LPDRAGLISTINFO;
	[PInvokeData("commctrl.h", MSDNShortId = "NS:commctrl.tagDRAGLISTINFO")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DRAGLISTINFO
	{
		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The notification code that specifies the type of drag event. This member can be one of the following values:</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>DL_BEGINDRAG</c></description>
		/// <description>The user has clicked the left mouse button on a list item.</description>
		/// </item>
		/// <item>
		/// <description><c>DL_CANCELDRAG</c></description>
		/// <description>The user has canceled the drag operation by clicking the right mouse button or pressing the ESC key.</description>
		/// </item>
		/// <item>
		/// <description><c>DL_DRAGGING</c></description>
		/// <description>The user has moved the mouse while dragging an item.</description>
		/// </item>
		/// <item>
		/// <description><c>DL_DROPPED</c></description>
		/// <description>The user has released the left mouse button, completing a drag operation.</description>
		/// </item>
		/// </list>
		/// </summary>
		public DL uNotification;

		/// <summary>
		/// <para>Type: <c>HWND</c></para>
		/// <para>A handle to the drag list box.</para>
		/// </summary>
		public HWND hWnd;

		/// <summary>
		/// <para>Type: <c>POINT</c></para>
		/// <para>A POINT structure that contains the current x- and y-coordinates of the mouse cursor.</para>
		/// </summary>
		public POINT ptCursor;
	}
}