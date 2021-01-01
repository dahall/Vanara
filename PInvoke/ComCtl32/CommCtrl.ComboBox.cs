using System;
using System.Runtime.InteropServices;
using static Vanara.PInvoke.User32;

namespace Vanara.PInvoke
{
	public static partial class ComCtl32
	{
		/// <summary>Window class for Extended Combo Box.</summary>
		public const string WC_COMBOBOXEX = "ComboBoxEx32";

		/// <summary>A value that specifies the action that generated the CBEN_ENDEDIT notification code.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb775750")]
		public enum CBEN_ENDEDIT_FLAG
		{
			/// <summary>The edit box lost the keyboard focus.</summary>
			CBENF_KILLFOCUS = 1,

			/// <summary>The user completed the edit operation by pressing ENTER.</summary>
			CBENF_RETURN = 2,

			/// <summary>The user pressed ESC.</summary>
			CBENF_ESCAPE = 3,

			/// <summary>The user activated the drop-down list.</summary>
			CBENF_DROPDOWN = 4,
		}

		/// <summary>
		/// A set of bit flags that specify attributes of COMBOBOXEXITEM or of an operation that is using this structure. The flags specify
		/// members that are valid or must be filled in.
		/// </summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb775746")]
		[Flags]
		public enum ComboBoxExItemMask
		{
			/// <summary>The pszText member is valid or must be filled in.</summary>
			CBEIF_TEXT = 0x00000001,

			/// <summary>The iImage member is valid or must be filled in.</summary>
			CBEIF_IMAGE = 0x00000002,

			/// <summary>The iSelectedImage member is valid or must be filled in.</summary>
			CBEIF_SELECTEDIMAGE = 0x00000004,

			/// <summary>The iOverlay member is valid or must be filled in.</summary>
			CBEIF_OVERLAY = 0x00000008,

			/// <summary>The iIndent member is valid or must be filled in.</summary>
			CBEIF_INDENT = 0x00000010,

			/// <summary>The lParam member is valid or must be filled in.</summary>
			CBEIF_LPARAM = 0x00000020,

			/// <summary>
			/// Set this flag when processing CBEN_GETDISPINFO; the ComboBoxEx control will retain the supplied information and will not
			/// request it again.
			/// </summary>
			CBEIF_DI_SETITEM = 0x10000000,
		}

		/// <summary>Support the extended styles that are listed in this section as well as most standard combo box control styles.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb775742")]
		public enum ComboBoxExStyle
		{
			/// <summary>The edit box and the dropdown list will not display item images.</summary>
			CBES_EX_NOEDITIMAGE = 0x00000001,

			/// <summary>The edit box and the dropdown list will not display item images.</summary>
			CBES_EX_NOEDITIMAGEINDENT = 0x00000002,

			/// <summary>
			/// Windows NT only. The edit box will use the slash (/), backslash (\), and period (.) characters as word delimiters. This makes
			/// keyboard shortcuts for word-by-word cursor movement effective in path names and URLs.
			/// </summary>
			CBES_EX_PATHWORDBREAKPROC = 0x00000004,

			/// <summary>
			/// Allows the ComboBoxEx control to be vertically sized smaller than its contained combo box control. If the ComboBoxEx is sized
			/// smaller than the combo box, the combo box will be clipped.
			/// </summary>
			CBES_EX_NOSIZELIMIT = 0x00000008,

			/// <summary>
			/// BSTR searches in the list will be case sensitive. This includes searches as a result of text being typed in the edit box and
			/// the CB_FINDSTRINGEXACT message.
			/// </summary>
			CBES_EX_CASESENSITIVE = 0x00000010,

			/// <summary>
			/// Windows Vista and later. Causes items in the drop-down list and the edit box (when the edit box is read only) to be truncated
			/// with an ellipsis ("...") rather than just clipped by the edge of the control. This is useful when the control needs to be set
			/// to a fixed width, yet the entries in the list may be long.
			/// </summary>
			CBES_EX_TEXTENDELLIPSIS = 0x00000020,
		}

		/// <summary>Contains combo box status information.</summary>
		[PInvokeData("Winuser.h", MSDNShortId = "bb775798")]
		[StructLayout(LayoutKind.Sequential)]
		public struct COMBOBOXINFO
		{
			/// <summary>The size, in bytes, of the structure. The calling application must set this to sizeof(COMBOBOXINFO).</summary>
			public int cbSize;

			/// <summary>A RECT structure that specifies the coordinates of the edit box.</summary>
			public RECT rcItem;

			/// <summary>A RECT structure that specifies the coordinates of the button that contains the drop-down arrow.</summary>
			public RECT rcButton;

			/// <summary>The combo box button state.</summary>
			public ComboBoxInfoState buttonState;

			/// <summary>A handle to the combo box.</summary>
			public HWND hwndCombo;

			/// <summary>A handle to the edit box.</summary>
			public HWND hwndEdit;

			/// <summary>A handle to the drop-down list.</summary>
			public HWND hwndList;

			/// <summary>Creates an instance of the <see cref="COMBOBOXINFO"/> structure from a handle and retrieves its values.</summary>
			/// <param name="hComboBox">The handle to a ComboBox.</param>
			/// <returns>A <see cref="COMBOBOXINFO"/> structure with values from the supplied handle.</returns>
			public static COMBOBOXINFO FromHandle(HWND hComboBox)
			{
				if (hComboBox.IsNull)
					throw new ArgumentException("ComboBox handle cannot be NULL.", nameof(hComboBox));

				var cbi = new COMBOBOXINFO() { cbSize = Marshal.SizeOf(typeof(COMBOBOXINFO)) };
				SendMessage(hComboBox, ComboBoxMessage.CB_GETCOMBOBOXINFO, 0, ref cbi);
				return cbi;
			}

			/// <summary>Gets a value indicating whether this <see cref="COMBOBOXINFO"/> is invisible.</summary>
			/// <value><c>true</c> if invisible; otherwise, <c>false</c>.</value>
			public bool Invisible => (buttonState & ComboBoxInfoState.STATE_SYSTEM_INVISIBLE) == ComboBoxInfoState.STATE_SYSTEM_INVISIBLE;

			/// <summary>Gets a value indicating whether this <see cref="COMBOBOXINFO"/> is pressed.</summary>
			/// <value><c>true</c> if pressed; otherwise, <c>false</c>.</value>
			public bool Pressed => (buttonState & ComboBoxInfoState.STATE_SYSTEM_PRESSED) == ComboBoxInfoState.STATE_SYSTEM_PRESSED;

			/// <summary>Gets the item rectangle.</summary>
			/// <value>The item rectangle.</value>
			public System.Drawing.Rectangle ItemRectangle => rcItem;

			/// <summary>Gets the button rectangle.</summary>
			/// <value>The button rectangle.</value>
			public System.Drawing.Rectangle ButtonRectangle => rcButton;
		}

		/// <summary>Contains information used with the CBEN_DRAGBEGIN notification code.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb775748")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct NMCBEDRAGBEGIN
		{
			/// <summary>The NMHDR structure that contains information about the notification code.</summary>
			public NMHDR hdr;

			/// <summary>
			/// The zero-based index of the item being dragged. This value will always be -1, indicating that the item being dragged is the
			/// item displayed in the edit portion of the control.
			/// </summary>
			public int iItemId;

			/// <summary>The character buffer that contains the text of the item being dragged.</summary>
			public string szText;
		}

		/// <summary>
		/// Contains information about the conclusion of an edit operation within a ComboBoxEx control. This structure is used with the
		/// CBEN_ENDEDIT notification code.
		/// </summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb775750")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct NMCBEENDEDIT
		{
			/// <summary>The NMHDR structure that contains information about the notification code.</summary>
			public NMHDR hdr;

			/// <summary>
			/// A value indicating whether the contents of the control's edit box have changed. This value is nonzero if the contents have
			/// been modified, or zero otherwise.
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)] public bool fChanged;

			/// <summary>
			/// The zero-based index of the item that will be selected after completing the edit operation. This value can be CB_ERR if no
			/// item will be selected.
			/// </summary>
			public int iNewSelection;

			/// <summary>A zero-terminated string that contains the text from within the control's edit box.</summary>
			public string szText;

			/// <summary>A value that specifies the action that generated the CBEN_ENDEDIT notification code.</summary>
			public CBEN_ENDEDIT_FLAG iWhy;
		}

		/// <summary>Contains information specific to ComboBoxEx items for use with notification codes.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb775752")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct NMCOMBOBOXEX
		{
			/// <summary>The NMHDR structure that contains information about the notification code.</summary>
			public NMHDR hdr;

			/// <summary>
			/// The COMBOBOXEXITEM structure that holds item information specific to the current notification. Upon receiving a notification
			/// code, the COMBOBOXEXITEM structure holds information required for the owner to respond. The members of this structure are
			/// often used as fields for the owner to return values in response to the notification.
			/// </summary>
			public COMBOBOXEXITEM ceItem;
		}

		/// <summary>Contains information about an item in a ComboBoxEx control.</summary>
		/// <seealso cref="System.IDisposable"/>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb775746")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public sealed class COMBOBOXEXITEM : IDisposable
		{
			/// <summary>
			/// A set of bit flags that specify attributes of this structure or of an operation that is using this structure. The flags
			/// specify members that are valid or must be filled in.
			/// </summary>
			public ComboBoxExItemMask mask;

			/// <summary>The zero-based index of the item.</summary>
			[MarshalAs(UnmanagedType.SysInt)] public int iItem;

			/// <summary>
			/// A pointer to a character buffer that contains or receives the item's text. If text information is being retrieved, this
			/// member must be set to the address of a character buffer that will receive the text. The size of this buffer must also be
			/// indicated in cchTextMax. If this member is set to LPSTR_TEXTCALLBACK, the control will request the information by using the
			/// CBEN_GETDISPINFO notification codes.
			/// </summary>
			public IntPtr pszText;

			/// <summary>The length of pszText, in TCHARs. If text information is being set, this member is ignored.</summary>
			public int cchTextMax;

			/// <summary>
			/// The zero-based index of an image within the image list. The specified image will be displayed for the item when it is not
			/// selected. If this member is set to I_IMAGECALLBACK, the control will request the information by using CBEN_GETDISPINFO
			/// notification codes.
			/// </summary>
			public int iImage;

			/// <summary>
			/// The zero-based index of an image within the image list. The specified image will be displayed for the item when it is
			/// selected. If this member is set to I_IMAGECALLBACK, the control will request the information by using CBEN_GETDISPINFO
			/// notification codes.
			/// </summary>
			public int iSelectedImage;

			/// <summary>
			/// The one-based index of an overlay image within the image list. If this member is set to I_IMAGECALLBACK, the control will
			/// request the information by using CBEN_GETDISPINFO notification codes.
			/// </summary>
			public int iOverlay;

			/// <summary>
			/// The number of indent spaces to display for the item. Each indentation equals 10 pixels. If this member is set to
			/// I_INDENTCALLBACK, the control will request the information by using CBEN_GETDISPINFO notification codes.
			/// </summary>
			public int iIndent;

			/// <summary>A value specific to the item.</summary>
			public IntPtr lParam;

			/// <summary>Initializes a new instance of the <see cref="COMBOBOXEXITEM"/> class.</summary>
			/// <param name="textBufferSize">Size of the text buffer. If this value is 0, no buffer is created.</param>
			public COMBOBOXEXITEM(int textBufferSize = 0) : this(textBufferSize == 0 ? null : new string('\0', textBufferSize)) { }

			/// <summary>Initializes a new instance of the <see cref="COMBOBOXEXITEM"/> class.</summary>
			/// <param name="text">The text.</param>
			public COMBOBOXEXITEM(string text) => Text = text;

			/// <summary>Gets or sets the item's text.</summary>
			/// <value>The text value.</value>
			public string Text
			{
				get => pszText == LPSTR_TEXTCALLBACK ? null : Marshal.PtrToStringAuto(pszText);
				set
				{
					((IDisposable)this).Dispose();
					if (value == null) return;
					pszText = Marshal.StringToCoTaskMemAuto(value);
					cchTextMax = value.Length;
					mask |= ComboBoxExItemMask.CBEIF_TEXT;
				}
			}

			/// <summary>Gets or sets a value indicating whether to use a text callback method.</summary>
			/// <value><c>true</c> if using text callback method; otherwise, <c>false</c>.</value>
			public bool UseTextCallback
			{
				get => pszText == LPSTR_TEXTCALLBACK;
				set
				{
					if (value)
					{
						((IDisposable)this).Dispose();
						pszText = LPSTR_TEXTCALLBACK;
					}
					mask |= ComboBoxExItemMask.CBEIF_TEXT;
				}
			}

			/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
			void IDisposable.Dispose()
			{
				if (pszText != IntPtr.Zero && pszText != LPSTR_TEXTCALLBACK)
				{
					Marshal.FreeCoTaskMem(pszText);
					pszText = IntPtr.Zero;
					cchTextMax = 0;
				}
			}
		}
	}
}