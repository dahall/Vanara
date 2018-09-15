using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Vanara.PInvoke
{
	public static partial class User32
	{
		/// <summary>Messages sent by Clipboard functions to the message window to notify of operations.</summary>
		[PInvokeData("Winuser.h", MSDNShortId = "clipboard-notifications")]
		public enum ClipboardNotificationMessage
		{
			/// <summary>
			/// <para>
			/// Sent to the clipboard owner by a clipboard viewer window to request the name of a <c>CF_OWNERDISPLAY</c> clipboard format.
			/// </para>
			/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
			/// </summary>
			/// <returns>
			/// <para>If an application processes this message, it should return zero.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// In response to this message, the clipboard owner should copy the name of the owner-display format to the specified buffer,
			/// not exceeding the buffer size specified by the wParam parameter.
			/// </para>
			/// <para>
			/// A clipboard viewer window sends this message to the clipboard owner to determine the name of the <c>CF_OWNERDISPLAY</c>
			/// format for example, to initialize a menu listing available formats.
			/// </para>
			/// </remarks>
			WM_ASKCBFORMATNAME = 0x030C,

			/// <summary>
			/// <para>Sent to the first window in the clipboard viewer chain when a window is being removed from the chain.</para>
			/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
			/// </summary>
			/// <returns>
			/// <para>If an application processes this message, it should return zero.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// Each clipboard viewer window saves the handle to the next window in the clipboard viewer chain. Initially, this handle is the
			/// return value of the <c>SetClipboardViewer</c> function.
			/// </para>
			/// <para>
			/// When a clipboard viewer window receives the <c>WM_CHANGECBCHAIN</c> message, it should call the <c>SendMessage</c> function
			/// to pass the message to the next window in the chain, unless the next window is the window being removed. In this case, the
			/// clipboard viewer should save the handle specified by the lParam parameter as the next window in the chain.
			/// </para>
			/// </remarks>
			WM_CHANGECBCHAIN = 0x030D,

			/// <summary>
			/// <para>Sent when the contents of the clipboard have changed.</para>
			/// </summary>
			/// <returns>
			/// <para>If an application processes this message, it should return zero.</para>
			/// </returns>
			/// <remarks>
			/// <para>To register a window to receive this message, use the <c>AddClipboardFormatListener</c> function.</para>
			/// </remarks>
			WM_CLIPBOARDUPDATE = 0x031D,

			/// <summary>
			/// <para>Sent to the clipboard owner when a call to the <c>EmptyClipboard</c> function empties the clipboard.</para>
			/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
			/// </summary>
			/// <returns>
			/// <para>If an application processes this message, it should return zero.</para>
			/// </returns>
			WM_DESTROYCLIPBOARD = 0x0307,

			/// <summary>
			/// <para>
			/// Sent to the first window in the clipboard viewer chain when the content of the clipboard changes. This enables a clipboard
			/// viewer window to display the new content of the clipboard.
			/// </para>
			/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
			/// </summary>
			/// <remarks>
			/// <para>
			/// Only clipboard viewer windows receive this message. These are windows that have been added to the clipboard viewer chain by
			/// using the <c>SetClipboardViewer</c> function.
			/// </para>
			/// <para>
			/// Each window that receives the <c>WM_DRAWCLIPBOARD</c> message must call the <c>SendMessage</c> function to pass the message
			/// on to the next window in the clipboard viewer chain. The handle to the next window in the chain is returned by
			/// <c>SetClipboardViewer</c>, and may change in response to a <c>WM_CHANGECBCHAIN</c> message.
			/// </para>
			/// </remarks>
			WM_DRAWCLIPBOARD = 0x0308,

			/// <summary>
			/// <para>
			/// Sent to the clipboard owner by a clipboard viewer window. This occurs when the clipboard contains data in the
			/// <c>CF_OWNERDISPLAY</c> format and an event occurs in the clipboard viewer's horizontal scroll bar. The owner should scroll
			/// the clipboard image and update the scroll bar values.
			/// </para>
			/// </summary>
			/// <returns>
			/// <para>If an application processes this message, it should return zero.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// The clipboard owner can use the <c>ScrollWindow</c> function to scroll the image in the clipboard viewer window and
			/// invalidate the appropriate region.
			/// </para>
			/// </remarks>
			WM_HSCROLLCLIPBOARD = 0x030E,

			/// <summary>
			/// <para>
			/// Sent to the clipboard owner by a clipboard viewer window when the clipboard contains data in the <c>CF_OWNERDISPLAY</c>
			/// format and the clipboard viewer's client area needs repainting.
			/// </para>
			/// </summary>
			/// <returns>
			/// <para>If an application processes this message, it should return zero.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// To determine whether the entire client area or just a portion of it needs repainting, the clipboard owner must compare the
			/// dimensions of the drawing area given in the <c>rcPaint</c> member of <c>PAINTSTRUCT</c> to the dimensions given in the most
			/// recent <c>WM_SIZECLIPBOARD</c> message.
			/// </para>
			/// <para>
			/// The clipboard owner must use the <c>GlobalLock</c> function to lock the memory that contains the <c>PAINTSTRUCT</c>
			/// structure. Before returning, the clipboard owner must unlock that memory by using the <c>GlobalUnlock</c> function.
			/// </para>
			/// </remarks>
			WM_PAINTCLIPBOARD = 0x0309,

			/// <summary>
			/// <para>
			/// Sent to the clipboard owner before it is destroyed, if the clipboard owner has delayed rendering one or more clipboard
			/// formats. For the content of the clipboard to remain available to other applications, the clipboard owner must render data in
			/// all the formats it is capable of generating, and place the data on the clipboard by calling the <c>SetClipboardData</c> function.
			/// </para>
			/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
			/// </summary>
			/// <returns>
			/// <para>If an application processes this message, it should return zero.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// When responding to a <c>WM_RENDERALLFORMATS</c> message, the clipboard owner must call the <c>OpenClipboard</c> and
			/// <c>EmptyClipboard</c> functions before calling <c>SetClipboardData</c>.
			/// </para>
			/// <para>
			/// When the application returns, the system removes any unrendered formats from the list of available clipboard formats. For
			/// information about delayed rendering, see <c>SetClipboardData</c>.
			/// </para>
			/// </remarks>
			WM_RENDERALLFORMATS = 0x0306,

			/// <summary>
			/// <para>
			/// Sent to the clipboard owner if it has delayed rendering a specific clipboard format and if an application has requested data
			/// in that format. The clipboard owner must render data in the specified format and place it on the clipboard by calling the
			/// <c>SetClipboardData</c> function.
			/// </para>
			/// </summary>
			/// <returns>
			/// <para>If an application processes this message, it should return zero.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// When responding to a <c>WM_RENDERFORMAT</c> message, the clipboard owner must not open the clipboard before calling <c>SetClipboardData</c>.
			/// </para>
			/// </remarks>
			WM_RENDERFORMAT = 0x0305,

			/// <summary>
			/// <para>
			/// Sent to the clipboard owner by a clipboard viewer window when the clipboard contains data in the <c>CF_OWNERDISPLAY</c>
			/// format and the clipboard viewer's client area has changed size.
			/// </para>
			/// </summary>
			/// <returns>
			/// <para>If an application processes this message, it should return zero.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// When the clipboard viewer window is about to be destroyed or resized, a <c>WM_SIZECLIPBOARD</c> message is sent with a null
			/// rectangle (0, 0, 0, 0) as the new size. This permits the clipboard owner to free its display resources.
			/// </para>
			/// <para>
			/// The clipboard owner must use the <c>GlobalLock</c> function to lock the memory object that contains <c>RECT</c>. Before
			/// returning, the clipboard owner must unlock the object by using the <c>GlobalUnlock</c> function.
			/// </para>
			/// </remarks>
			WM_SIZECLIPBOARD = 0x030B,

			/// <summary>
			/// <para>
			/// Sent to the clipboard owner by a clipboard viewer window when the clipboard contains data in the <c>CF_OWNERDISPLAY</c>
			/// format and an event occurs in the clipboard viewer's vertical scroll bar. The owner should scroll the clipboard image and
			/// update the scroll bar values.
			/// </para>
			/// </summary>
			/// <returns>
			/// <para>If an application processes this message, it should return zero.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// The clipboard owner can use the <c>ScrollWindow</c> function to scroll the image in the clipboard viewer window and
			/// invalidate the appropriate region.
			/// </para>
			/// </remarks>
			WM_VSCROLLCLIPBOARD = 0x030A,
		}

		/// <summary><para>The clipboard formats defined by the system are called standard clipboard formats.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/dataxchg/standard-clipboard-formats
		[PInvokeData("Winuser.h", MSDNShortId = "f0af4e61-7ef1-4263-b2c5-e4114515124f")]
		public enum StandardClipboardFormat : uint
		{
			/// <summary>A handle to a bitmap (HBITMAP).</summary>
			CF_BITMAP = 2,

			/// <summary>A memory object containing a BITMAPINFO structure followed by the bitmap bits.</summary>
			CF_DIB = 8,

			/// <summary>
			/// A memory object containing a BITMAPV5HEADER structure followed by the bitmap color space information and the bitmap bits.
			/// </summary>
			CF_DIBV5 = 17,

			/// <summary>Software Arts' Data Interchange Format.</summary>
			CF_DIF = 5,

			/// <summary>
			/// Bitmap display format associated with a private format. The hMem parameter must be a handle to data that can be displayed in
			/// bitmap format in lieu of the privately formatted data.
			/// </summary>
			CF_DSPBITMAP = 0x0082,

			/// <summary>
			/// Enhanced metafile display format associated with a private format. The hMem parameter must be a handle to data that can be
			/// displayed in enhanced metafile format in lieu of the privately formatted data.
			/// </summary>
			CF_DSPENHMETAFILE = 0x008E,

			/// <summary>
			/// Metafile-picture display format associated with a private format. The hMem parameter must be a handle to data that can be
			/// displayed in metafile-picture format in lieu of the privately formatted data.
			/// </summary>
			CF_DSPMETAFILEPICT = 0x0083,

			/// <summary>
			/// Text display format associated with a private format. The hMem parameter must be a handle to data that can be displayed in
			/// text format in lieu of the privately formatted data.
			/// </summary>
			CF_DSPTEXT = 0x0081,

			/// <summary>A handle to an enhanced metafile (HENHMETAFILE).</summary>
			CF_ENHMETAFILE = 14,

			/// <summary>
			/// Start of a range of integer values for application-defined GDI object clipboard formats. The end of the range is CF_GDIOBJLAST.
			/// <para>
			/// Handles associated with clipboard formats in this range are not automatically deleted using the GlobalFree function when the
			/// clipboard is emptied. Also, when using values in this range, the hMem parameter is not a handle to a GDI object, but is a
			/// handle allocated by the GlobalAlloc function with the GMEM_MOVEABLE flag.
			/// </para>
			/// </summary>
			CF_GDIOBJFIRST = 0x0300,

			/// <summary>See CF_GDIOBJFIRST.</summary>
			CF_GDIOBJLAST = 0x03FF,

			/// <summary>
			/// A handle to type HDROP that identifies a list of files. An application can retrieve information about the files by passing
			/// the handle to the DragQueryFile function.
			/// </summary>
			CF_HDROP = 15,

			/// <summary>
			/// The data is a handle to the locale identifier associated with text in the clipboard. When you close the clipboard, if it
			/// contains CF_TEXT data but no CF_LOCALE data, the system automatically sets the CF_LOCALE format to the current input
			/// language. You can use the CF_LOCALE format to associate a different locale with the clipboard text.
			/// <para>
			/// An application that pastes text from the clipboard can retrieve this format to determine which character set was used to
			/// generate the text.
			/// </para>
			/// <para>
			/// Note that the clipboard does not support plain text in multiple character sets. To achieve this, use a formatted text data
			/// type such as RTF instead.
			/// </para>
			/// <para>
			/// The system uses the code page associated with CF_LOCALE to implicitly convert from CF_TEXT to CF_UNICODETEXT. Therefore, the
			/// correct code page table is used for the conversion.
			/// </para>
			/// </summary>
			CF_LOCALE = 16,

			/// <summary>
			/// Handle to a metafile picture format as defined by the METAFILEPICT structure. When passing a CF_METAFILEPICT handle by means
			/// of DDE, the application responsible for deleting hMem should also free the metafile referred to by the CF_METAFILEPICT handle.
			/// </summary>
			CF_METAFILEPICT = 3,

			/// <summary>
			/// Text format containing characters in the OEM character set. Each line ends with a carriage return/linefeed (CR-LF)
			/// combination. A null character signals the end of the data.
			/// </summary>
			CF_OEMTEXT = 7,

			/// <summary>
			/// Owner-display format. The clipboard owner must display and update the clipboard viewer window, and receive the
			/// WM_ASKCBFORMATNAME, WM_HSCROLLCLIPBOARD, WM_PAINTCLIPBOARD, WM_SIZECLIPBOARD, and WM_VSCROLLCLIPBOARD messages. The hMem
			/// parameter must be NULL.
			/// </summary>
			CF_OWNERDISPLAY = 0x0080,

			/// <summary>
			/// Handle to a color palette. Whenever an application places data in the clipboard that depends on or assumes a color palette,
			/// it should place the palette on the clipboard as well.
			/// <para>
			/// If the clipboard contains data in the CF_PALETTE (logical color palette) format, the application should use the SelectPalette
			/// and RealizePalette functions to realize (compare) any other data in the clipboard against that logical palette.
			/// </para>
			/// <para>
			/// When displaying clipboard data, the clipboard always uses as its current palette any object on the clipboard that is in the
			/// CF_PALETTE format.
			/// </para>
			/// </summary>
			CF_PALETTE = 9,

			/// <summary>Data for the pen extensions to the Microsoft Windows for Pen Computing.</summary>
			CF_PENDATA = 10,

			/// <summary>
			/// Start of a range of integer values for private clipboard formats. The range ends with CF_PRIVATELAST. Handles associated with
			/// private clipboard formats are not freed automatically; the clipboard owner must free such handles, typically in response to
			/// the WM_DESTROYCLIPBOARD message.
			/// </summary>
			CF_PRIVATEFIRST = 0x0200,

			/// <summary>See CF_PRIVATEFIRST.</summary>
			CF_PRIVATELAST = 0x02FF,

			/// <summary>Represents audio data more complex than can be represented in a CF_WAVE standard wave format.</summary>
			CF_RIFF = 11,

			/// <summary>Microsoft Symbolic Link (SYLK) format.</summary>
			CF_SYLK = 4,

			/// <summary>
			/// Text format. Each line ends with a carriage return/linefeed (CR-LF) combination. A null character signals the end of the
			/// data. Use this format for ANSI text.
			/// </summary>
			CF_TEXT = 1,

			/// <summary>Tagged-image file format.</summary>
			CF_TIFF = 6,

			/// <summary>
			/// Unicode text format. Each line ends with a carriage return/linefeed (CR-LF) combination. A null character signals the end of
			/// the data.
			/// </summary>
			CF_UNICODETEXT = 13,

			/// <summary>Represents audio data in one of the standard wave formats, such as 11 kHz or 22 kHz PCM.</summary>
			CF_WAVE = 12,
		}

		/// <summary>
		/// <para>Places the given window in the system-maintained clipboard format listener list.</para>
		/// </summary>
		/// <param name="hwnd">
		/// <para>Type: <c>HWND</c></para>
		/// <para>A handle to the window to be placed in the clipboard format listener list.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Returns <c>TRUE</c> if successful, <c>FALSE</c> otherwise. Call GetLastError for additional details.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// When a window has been added to the clipboard format listener list, it is posted a WM_CLIPBOARDUPDATE message whenever the
		/// contents of the clipboard have changed.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-addclipboardformatlistener BOOL
		// AddClipboardFormatListener( HWND hwnd );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "addclipboardformatlistener")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool AddClipboardFormatListener(HandleRef hwnd);

		/// <summary>
		/// <para>Removes a specified window from the chain of clipboard viewers.</para>
		/// </summary>
		/// <param name="hWndRemove">
		/// <para>Type: <c>HWND</c></para>
		/// <para>A handle to the window to be removed from the chain. The handle must have been passed to the SetClipboardViewer function.</para>
		/// </param>
		/// <param name="hWndNewNext">
		/// <para>Type: <c>HWND</c></para>
		/// <para>
		/// A handle to the window that follows the hWndRemove window in the clipboard viewer chain. (This is the handle returned by
		/// SetClipboardViewer, unless the sequence was changed in response to a WM_CHANGECBCHAIN message.)
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// The return value indicates the result of passing the WM_CHANGECBCHAIN message to the windows in the clipboard viewer chain.
		/// Because a window in the chain typically returns <c>FALSE</c> when it processes <c>WM_CHANGECBCHAIN</c>, the return value from
		/// <c>ChangeClipboardChain</c> is typically <c>FALSE</c>. If there is only one window in the chain, the return value is typically <c>TRUE</c>.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The window identified by hWndNewNext replaces the hWndRemove window in the chain. The SetClipboardViewer function sends a
		/// WM_CHANGECBCHAIN message to the first window in the clipboard viewer chain.
		/// </para>
		/// <para>For an example, see Removing a Window from the Clipboard Viewer Chain.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-changeclipboardchain BOOL ChangeClipboardChain( HWND
		// hWndRemove, HWND hWndNewNext );
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "changeclipboardchain")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ChangeClipboardChain(HandleRef hWndRemove, HandleRef hWndNewNext);

		/// <summary>
		/// <para>Closes the clipboard.</para>
		/// </summary>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// When the window has finished examining or changing the clipboard, close the clipboard by calling <c>CloseClipboard</c>. This
		/// enables other windows to access the clipboard.
		/// </para>
		/// <para>Do not place an object on the clipboard after calling <c>CloseClipboard</c>.</para>
		/// <para>Examples</para>
		/// <para>For an example, see Example of a Clipboard Viewer.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-closeclipboard BOOL CloseClipboard( );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "closeclipboard")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CloseClipboard();

		/// <summary>
		/// <para>Retrieves the number of different data formats currently on the clipboard.</para>
		/// </summary>
		/// <returns>
		/// <para>Type: <c>int</c></para>
		/// <para>If the function succeeds, the return value is the number of different data formats currently on the clipboard.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-countclipboardformats int CountClipboardFormats( );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "countclipboardformats")]
		public static extern int CountClipboardFormats();

		/// <summary>
		/// <para>
		/// Empties the clipboard and frees handles to data in the clipboard. The function then assigns ownership of the clipboard to the
		/// window that currently has the clipboard open.
		/// </para>
		/// </summary>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Before calling <c>EmptyClipboard</c>, an application must open the clipboard by using the OpenClipboard function. If the
		/// application specifies a <c>NULL</c> window handle when opening the clipboard, <c>EmptyClipboard</c> succeeds but sets the
		/// clipboard owner to <c>NULL</c>. Note that this causes SetClipboardData to fail.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Copying Information to the Clipboard.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-emptyclipboard BOOL EmptyClipboard( );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "emptyclipboard")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool EmptyClipboard();

		/// <summary>
		/// <para>Enumerates the data formats currently available on the clipboard.</para>
		/// <para>
		/// Clipboard data formats are stored in an ordered list. To perform an enumeration of clipboard data formats, you make a series of
		/// calls to the <c>EnumClipboardFormats</c> function. For each call, the format parameter specifies an available clipboard format,
		/// and the function returns the next available clipboard format.
		/// </para>
		/// </summary>
		/// <param name="format">
		/// <para>Type: <c>UINT</c></para>
		/// <para>A clipboard format that is known to be available.</para>
		/// <para>
		/// To start an enumeration of clipboard formats, set format to zero. When format is zero, the function retrieves the first available
		/// clipboard format. For subsequent calls during an enumeration, set format to the result of the previous
		/// <c>EnumClipboardFormats</c> call.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// If the function succeeds, the return value is the clipboard format that follows the specified format, namely the next available
		/// clipboard format.
		/// </para>
		/// <para>
		/// If the function fails, the return value is zero. To get extended error information, call GetLastError. If the clipboard is not
		/// open, the function fails.
		/// </para>
		/// <para>
		/// If there are no more clipboard formats to enumerate, the return value is zero. In this case, the GetLastError function returns
		/// the value <c>ERROR_SUCCESS</c>. This lets you distinguish between function failure and the end of enumeration.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// You must open the clipboard before enumerating its formats. Use the OpenClipboard function to open the clipboard. The
		/// <c>EnumClipboardFormats</c> function fails if the clipboard is not open.
		/// </para>
		/// <para>
		/// The <c>EnumClipboardFormats</c> function enumerates formats in the order that they were placed on the clipboard. If you are
		/// copying information to the clipboard, add clipboard objects in order from the most descriptive clipboard format to the least
		/// descriptive clipboard format. If you are pasting information from the clipboard, retrieve the first clipboard format that you can
		/// handle. That will be the most descriptive clipboard format that you can handle.
		/// </para>
		/// <para>
		/// The system provides automatic type conversions for certain clipboard formats. In the case of such a format, this function
		/// enumerates the specified format, then enumerates the formats to which it can be converted. For more information, see Standard
		/// Clipboard Formats and Synthesized Clipboard Formats.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Example of a Clipboard Viewer.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-enumclipboardformats UINT EnumClipboardFormats( UINT
		// format );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "enumclipboardformats")]
		public static extern uint EnumClipboardFormats(uint format);

		/// <summary>
		/// <para>Enumerates the data formats currently available on the clipboard.</para>
		/// <para>Clipboard data formats are stored in an ordered list.</para>
		/// </summary>
		/// <returns>An enumeration of the data formats currently available on the clipboard.</returns>
		/// <remarks>
		/// <para>
		/// You must open the clipboard before enumerating its formats. Use the OpenClipboard function to open the clipboard. The
		/// <c>EnumClipboardFormats</c> function fails if the clipboard is not open.
		/// </para>
		/// <para>
		/// The <c>EnumClipboardFormats</c> function enumerates formats in the order that they were placed on the clipboard. If you are
		/// copying information to the clipboard, add clipboard objects in order from the most descriptive clipboard format to the least
		/// descriptive clipboard format. If you are pasting information from the clipboard, retrieve the first clipboard format that you can
		/// handle. That will be the most descriptive clipboard format that you can handle.
		/// </para>
		/// <para>
		/// The system provides automatic type conversions for certain clipboard formats. In the case of such a format, this function
		/// enumerates the specified format, then enumerates the formats to which it can be converted. For more information, see Standard
		/// Clipboard Formats and Synthesized Clipboard Formats.
		/// </para>
		/// </remarks>
		public static IEnumerable<uint> EnumClipboardFormats()
		{
			var fmt = 0U;
			while (true)
			{
				fmt = EnumClipboardFormats(fmt);
				if (fmt > 0)
					yield return fmt;
				else
				{
					Win32Error.GetLastError().ThrowIfFailed();
					break;
				}
			}
		}

		/// <summary>
		/// <para>Retrieves data from the clipboard in a specified format. The clipboard must have been opened previously.</para>
		/// </summary>
		/// <param name="uFormat">
		/// <para>Type: <c>UINT</c></para>
		/// <para>A clipboard format. For a description of the standard clipboard formats, see Standard Clipboard Formats.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HANDLE</c></para>
		/// <para>If the function succeeds, the return value is the handle to a clipboard object in the specified format.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para><c>Caution</c> Clipboard data is not trusted. Parse the data carefully before using it in your application.</para>
		/// <para>An application can enumerate the available formats in advance by using the EnumClipboardFormats function.</para>
		/// <para>
		/// The clipboard controls the handle that the <c>GetClipboardData</c> function returns, not the application. The application should
		/// copy the data immediately. The application must not free the handle nor leave it locked. The application must not use the handle
		/// after the EmptyClipboard or CloseClipboard function is called, or after the SetClipboardData function is called with the same
		/// clipboard format.
		/// </para>
		/// <para>
		/// The system performs implicit data format conversions between certain clipboard formats when an application calls the
		/// <c>GetClipboardData</c> function. For example, if the CF_OEMTEXT format is on the clipboard, a window can retrieve data in the
		/// CF_TEXT format. The format on the clipboard is converted to the requested format on demand. For more information, see Synthesized
		/// Clipboard Formats.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Copying Information to the Clipboard.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getclipboarddata HANDLE GetClipboardData( UINT uFormat );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "getclipboarddata")]
		public static extern IntPtr GetClipboardData(uint uFormat);

		/// <summary>
		/// <para>
		/// Retrieves from the clipboard the name of the specified registered format. The function copies the name to the specified buffer.
		/// </para>
		/// </summary>
		/// <param name="format">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The type of format to be retrieved. This parameter must not specify any of the predefined clipboard formats.</para>
		/// </param>
		/// <param name="lpszFormatName">
		/// <para>Type: <c>LPTSTR</c></para>
		/// <para>The buffer that is to receive the format name.</para>
		/// </param>
		/// <param name="cchMaxCount">
		/// <para>Type: <c>int</c></para>
		/// <para>The maximum length, in characters, of the string to be copied to the buffer. If the name exceeds this limit, it is truncated.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>int</c></para>
		/// <para>If the function succeeds, the return value is the length, in characters, of the string copied to the buffer.</para>
		/// <para>
		/// If the function fails, the return value is zero, indicating that the requested format does not exist or is predefined. To get
		/// extended error information, call GetLastError.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>Security Considerations</para>
		/// <para>
		/// Using this function incorrectly might compromise the security of your program. For example, miscalculating the proper size of the
		/// lpszFormatName buffer, especially when the application is used in both ANSI and Unicode versions, can cause a buffer overflow.
		/// Also, note that the string is truncated if it is longer than the cchMaxCount parameter, which can lead to loss of information.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Example of a Clipboard Viewer.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getclipboardformatnamea int GetClipboardFormatNameA( UINT
		// format, LPSTR lpszFormatName, int cchMaxCount );
		[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("winuser.h", MSDNShortId = "getclipboardformatname")]
		public static extern int GetClipboardFormatName(uint format, StringBuilder lpszFormatName, int cchMaxCount);

		/// <summary>
		/// <para>Retrieves the window handle of the current owner of the clipboard.</para>
		/// </summary>
		/// <returns>
		/// <para>Type: <c>HWND</c></para>
		/// <para>If the function succeeds, the return value is the handle to the window that owns the clipboard.</para>
		/// <para>If the clipboard is not owned, the return value is <c>NULL</c>. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>The clipboard can still contain data even if the clipboard is not currently owned.</para>
		/// <para>
		/// In general, the clipboard owner is the window that last placed data in clipboard. The EmptyClipboard function assigns clipboard ownership.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Example of a Clipboard Viewer.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getclipboardowner HWND GetClipboardOwner( );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "getclipboardowner")]
		public static extern IntPtr GetClipboardOwner();

		/// <summary>
		/// <para>Retrieves the clipboard sequence number for the current window station.</para>
		/// </summary>
		/// <returns>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// The return value is the clipboard sequence number. If you do not have <c>WINSTA_ACCESSCLIPBOARD</c> access to the window station,
		/// the function returns zero.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The system keeps a serial number for the clipboard for each window station. This number is incremented whenever the contents of
		/// the clipboard change or the clipboard is emptied. You can track this value to determine whether the clipboard contents have
		/// changed and optimize creating DataObjects. If clipboard rendering is delayed, the sequence number is not incremented until the
		/// changes are rendered.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getclipboardsequencenumber DWORD
		// GetClipboardSequenceNumber( );
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "getclipboardsequencenumber")]
		public static extern uint GetClipboardSequenceNumber();

		/// <summary>
		/// <para>Retrieves the handle to the first window in the clipboard viewer chain.</para>
		/// </summary>
		/// <returns>
		/// <para>Type: <c>HWND</c></para>
		/// <para>If the function succeeds, the return value is the handle to the first window in the clipboard viewer chain.</para>
		/// <para>If there is no clipboard viewer, the return value is <c>NULL</c>. To get extended error information, call GetLastError.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getclipboardviewer HWND GetClipboardViewer( );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "getclipboardviewer")]
		public static extern IntPtr GetClipboardViewer();

		/// <summary>
		/// <para>Retrieves the handle to the window that currently has the clipboard open.</para>
		/// </summary>
		/// <returns>
		/// <para>Type: <c>HWND</c></para>
		/// <para>
		/// If the function succeeds, the return value is the handle to the window that has the clipboard open. If no window has the
		/// clipboard open, the return value is <c>NULL</c>. To get extended error information, call GetLastError.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If an application or DLL specifies a <c>NULL</c> window handle when calling the OpenClipboard function, the clipboard is opened
		/// but is not associated with a window. In such a case, <c>GetOpenClipboardWindow</c> returns <c>NULL</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getopenclipboardwindow HWND GetOpenClipboardWindow( );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "getopenclipboardwindow")]
		public static extern IntPtr GetOpenClipboardWindow();

		/// <summary>
		/// <para>Retrieves the first available clipboard format in the specified list.</para>
		/// </summary>
		/// <param name="paFormatPriorityList">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>
		/// The clipboard formats, in priority order. For a description of the standard clipboard formats, see Standard Clipboard Formats .
		/// </para>
		/// </param>
		/// <param name="cFormats">
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// The number of entries in the paFormatPriorityList array. This value must not be greater than the number of entries in the list.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// If the function succeeds, the return value is the first clipboard format in the list for which data is available. If the
		/// clipboard is empty, the return value is NULL. If the clipboard contains data, but not in any of the specified formats, the return
		/// value is –1. To get extended error information, call GetLastError.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getpriorityclipboardformat int GetPriorityClipboardFormat(
		// UINT *paFormatPriorityList, int cFormats );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "getpriorityclipboardformat")]
		public static extern int GetPriorityClipboardFormat([MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] paFormatPriorityList, int cFormats);

		/// <summary>
		/// <para>Retrieves the currently supported clipboard formats.</para>
		/// </summary>
		/// <param name="lpuiFormats">
		/// <para>Type: <c>PUINT</c></para>
		/// <para>An array of clipboard formats. For a description of the standard clipboard formats, see Standard Clipboard Formats.</para>
		/// </param>
		/// <param name="cFormats">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of entries in the array pointed to by lpuiFormats.</para>
		/// </param>
		/// <param name="pcFormatsOut">
		/// <para>Type: <c>PUINT</c></para>
		/// <para>The actual number of clipboard formats in the array pointed to by lpuiFormats.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>The function returns <c>TRUE</c> if successful; otherwise, <c>FALSE</c>. Call GetLastError for additional details.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getupdatedclipboardformats BOOL
		// GetUpdatedClipboardFormats( PUINT lpuiFormats, UINT cFormats, PUINT pcFormatsOut );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "getupdatedclipboardformats")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetUpdatedClipboardFormats([MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] lpuiFormats, uint cFormats, out uint pcFormatsOut);

		/// <summary>
		/// <para>Determines whether the clipboard contains data in the specified format.</para>
		/// </summary>
		/// <param name="format">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// A standard or registered clipboard format. For a description of the standard clipboard formats, see Standard Clipboard Formats .
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>If the clipboard format is available, the return value is nonzero.</para>
		/// <para>If the clipboard format is not available, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Typically, an application that recognizes only one clipboard format would call this function when processing the WM_INITMENU or
		/// WM_INITMENUPOPUP message. The application would then enable or disable the Paste menu item, depending on the return value.
		/// Applications that recognize more than one clipboard format should use the GetPriorityClipboardFormat function for this purpose.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Pasting Information from the Clipboard.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-isclipboardformatavailable BOOL
		// IsClipboardFormatAvailable( UINT format );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "isclipboardformatavailable")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool IsClipboardFormatAvailable(uint format);

		/// <summary>
		/// <para>Opens the clipboard for examination and prevents other applications from modifying the clipboard content.</para>
		/// </summary>
		/// <param name="hWndNewOwner">
		/// <para>Type: <c>HWND</c></para>
		/// <para>
		/// A handle to the window to be associated with the open clipboard. If this parameter is <c>NULL</c>, the open clipboard is
		/// associated with the current task.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para><c>OpenClipboard</c> fails if another window has the clipboard open.</para>
		/// <para>An application should call the CloseClipboard function after every successful call to <c>OpenClipboard</c>.</para>
		/// <para>
		/// The window identified by the hWndNewOwner parameter does not become the clipboard owner unless the EmptyClipboard function is called.
		/// </para>
		/// <para>
		/// If an application calls <c>OpenClipboard</c> with hwnd set to <c>NULL</c>, EmptyClipboard sets the clipboard owner to
		/// <c>NULL</c>; this causes SetClipboardData to fail.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Copying Information to the Clipboard.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-openclipboard BOOL OpenClipboard( HWND hWndNewOwner );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "openclipboard")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool OpenClipboard(HandleRef hWndNewOwner);

		/// <summary>
		/// <para>Registers a new clipboard format. This format can then be used as a valid clipboard format.</para>
		/// </summary>
		/// <param name="lpszFormat">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>The name of the new format.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>UINT</c></para>
		/// <para>If the function succeeds, the return value identifies the registered clipboard format.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If a registered format with the specified name already exists, a new format is not registered and the return value identifies the
		/// existing format. This enables more than one application to copy and paste data using the same registered clipboard format. Note
		/// that the format name comparison is case-insensitive.
		/// </para>
		/// <para>Registered clipboard formats are identified by values in the range 0xC000 through 0xFFFF.</para>
		/// <para>
		/// When registered clipboard formats are placed on or retrieved from the clipboard, they must be in the form of an <c>HGLOBAL</c> value.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Registering a Clipboard Format.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-registerclipboardformata UINT RegisterClipboardFormatA(
		// LPCSTR lpszFormat );
		[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("winuser.h", MSDNShortId = "registerclipboardformat")]
		public static extern uint RegisterClipboardFormat(string lpszFormat);

		/// <summary>
		/// <para>Removes the given window from the system-maintained clipboard format listener list.</para>
		/// </summary>
		/// <param name="hwnd">
		/// <para>Type: <c>HWND</c></para>
		/// <para>A handle to the window to remove from the clipboard format listener list.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Returns <c>TRUE</c> if successful, <c>FALSE</c> otherwise. Call GetLastError for additional details.</para>
		/// </returns>
		/// <remarks>
		/// <para>When a window has been removed from the clipboard format listener list, it will no longer receive WM_CLIPBOARDUPDATE messages.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-removeclipboardformatlistener BOOL
		// RemoveClipboardFormatListener( HWND hwnd );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "removeclipboardformatlistener")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool RemoveClipboardFormatListener(HandleRef hwnd);

		/// <summary>
		/// <para>
		/// Places data on the clipboard in a specified clipboard format. The window must be the current clipboard owner, and the application
		/// must have called the OpenClipboard function. (When responding to the WM_RENDERFORMAT and WM_RENDERALLFORMATS messages, the
		/// clipboard owner must not call <c>OpenClipboard</c> before calling <c>SetClipboardData</c>.)
		/// </para>
		/// </summary>
		/// <param name="uFormat">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// The clipboard format. This parameter can be a registered format or any of the standard clipboard formats. For more information,
		/// see Standard Clipboard Formats and Registered Clipboard Formats.
		/// </para>
		/// </param>
		/// <param name="hMem">
		/// <para>Type: <c>HANDLE</c></para>
		/// <para>
		/// A handle to the data in the specified format. This parameter can be <c>NULL</c>, indicating that the window provides data in the
		/// specified clipboard format (renders the format) upon request. If a window delays rendering, it must process the WM_RENDERFORMAT
		/// and WM_RENDERALLFORMATS messages.
		/// </para>
		/// <para>
		/// If <c>SetClipboardData</c> succeeds, the system owns the object identified by the hMem parameter. The application may not write
		/// to or free the data once ownership has been transferred to the system, but it can lock and read from the data until the
		/// CloseClipboard function is called. (The memory must be unlocked before the Clipboard is closed.) If the hMem parameter identifies
		/// a memory object, the object must have been allocated using the function with the <c>GMEM_MOVEABLE</c> flag.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HANDLE</c></para>
		/// <para>If the function succeeds, the return value is the handle to the data.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>Windows 8:</c> Bitmaps to be shared with Windows Store app apps must be in the <c>CF_BITMAP</c> format (device-dependent bitmap).
		/// </para>
		/// <para>
		/// If an application calls <c>SetClipboardData</c> in response to WM_RENDERFORMAT or WM_RENDERALLFORMATS, the application should not
		/// use the handle after <c>SetClipboardData</c> has been called.
		/// </para>
		/// <para>
		/// If an application calls OpenClipboard with hwnd set to <c>NULL</c>, EmptyClipboard sets the clipboard owner to <c>NULL</c>; this
		/// causes <c>SetClipboardData</c> to fail.
		/// </para>
		/// <para>
		/// The system performs implicit data format conversions between certain clipboard formats when an application calls the
		/// GetClipboardData function. For example, if the <c>CF_OEMTEXT</c> format is on the clipboard, a window can retrieve data in the
		/// <c>CF_TEXT</c> format. The format on the clipboard is converted to the requested format on demand. For more information, see
		/// Synthesized Clipboard Formats.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Copying Information to the Clipboard.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-setclipboarddata HANDLE SetClipboardData( UINT uFormat,
		// HANDLE hMem );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "setclipboarddata")]
		public static extern IntPtr SetClipboardData(uint uFormat, IntPtr hMem);

		/// <summary>
		/// <para>
		/// Adds the specified window to the chain of clipboard viewers. Clipboard viewer windows receive a WM_DRAWCLIPBOARD message whenever
		/// the content of the clipboard changes. This function is used for backward compatibility with earlier versions of Windows.
		/// </para>
		/// </summary>
		/// <param name="hWndNewViewer">
		/// <para>Type: <c>HWND</c></para>
		/// <para>A handle to the window to be added to the clipboard chain.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HWND</c></para>
		/// <para>
		/// If the function succeeds, the return value identifies the next window in the clipboard viewer chain. If an error occurs or there
		/// are no other windows in the clipboard viewer chain, the return value is NULL. To get extended error information, call GetLastError.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The windows that are part of the clipboard viewer chain, called clipboard viewer windows, must process the clipboard messages
		/// WM_CHANGECBCHAIN and WM_DRAWCLIPBOARD. Each clipboard viewer window calls the SendMessage function to pass these messages to the
		/// next window in the clipboard viewer chain.
		/// </para>
		/// <para>
		/// A clipboard viewer window must eventually remove itself from the clipboard viewer chain by calling the ChangeClipboardChain
		/// function — for example, in response to the WM_DESTROY message.
		/// </para>
		/// <para>
		/// The <c>SetClipboardViewer</c> function exists to provide backward compatibility with earlier versions of Windows. The clipboard
		/// viewer chain can be broken by an application that fails to handle the clipboard chain messages properly. New applications should
		/// use more robust techniques such as the clipboard sequence number or the registration of a clipboard format listener. For further
		/// details on these alternatives techniques, see Monitoring Clipboard Contents.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Adding a Window to the Clipboard Viewer Chain.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-setclipboardviewer HWND SetClipboardViewer( HWND
		// hWndNewViewer );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "setclipboardviewer")]
		public static extern IntPtr SetClipboardViewer(HandleRef hWndNewViewer);

		/// <summary>
		/// <para>Defines the metafile picture format used for exchanging metafile data through the clipboard.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/ns-wingdi-tagmetafilepict typedef struct tagMETAFILEPICT { LONG mm;
		// LONG xExt; LONG yExt; HMETAFILE hMF; } METAFILEPICT, *LPMETAFILEPICT;
		[PInvokeData("wingdi.h", MSDNShortId = "metafilepict")]
		[StructLayout(LayoutKind.Sequential)]
		public struct METAFILEPICT
		{
			/// <summary>
			/// <para>Type: <c>LONG</c></para>
			/// <para>The mapping mode in which the picture is drawn.</para>
			/// </summary>
			public int mm;

			/// <summary>
			/// <para>Type: <c>LONG</c></para>
			/// <para>
			/// The size of the metafile picture for all modes except the <c>MM_ISOTROPIC</c> and <c>MM_ANISOTROPIC</c> modes. (For more
			/// information about these modes, see the <c>yExt</c> member.) The x-extent specifies the width of the rectangle within which
			/// the picture is drawn. The coordinates are in units that correspond to the mapping mode.
			/// </para>
			/// </summary>
			public int xExt;

			/// <summary>
			/// <para>Type: <c>LONG</c></para>
			/// <para>
			/// The size of the metafile picture for all modes except the <c>MM_ISOTROPIC</c> and <c>MM_ANISOTROPIC</c> modes. The y-extent
			/// specifies the height of the rectangle within which the picture is drawn. The coordinates are in units that correspond to the
			/// mapping mode. For <c>MM_ISOTROPIC</c> and <c>MM_ANISOTROPIC</c> modes, which can be scaled, the <c>xExt</c> and <c>yExt</c>
			/// members contain an optional suggested size in <c>MM_HIMETRIC</c> units. For <c>MM_ANISOTROPIC</c> pictures, <c>xExt</c> and
			/// <c>yExt</c> can be zero when no suggested size is supplied. For <c>MM_ISOTROPIC</c> pictures, an aspect ratio must be
			/// supplied even when no suggested size is given. (If a suggested size is given, the aspect ratio is implied by the size.) To
			/// give an aspect ratio without implying a suggested size, set <c>xExt</c> and <c>yExt</c> to negative values whose ratio is the
			/// appropriate aspect ratio. The magnitude of the negative <c>xExt</c> and <c>yExt</c> values is ignored; only the ratio is used.
			/// </para>
			/// </summary>
			public int yExt;

			/// <summary>
			/// <para>Type: <c>HMETAFILE</c></para>
			/// <para>A handle to a memory metafile.</para>
			/// </summary>
			public IntPtr hMF;
		}
	}
}