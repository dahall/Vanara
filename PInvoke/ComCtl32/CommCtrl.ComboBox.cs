using static Vanara.PInvoke.User32;

namespace Vanara.PInvoke;

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

	/// <summary>
	/// Window messages related to extended combo boxes. These messages are defined in Commctrl.h and are available starting with Windows Vista.
	/// </summary>
	[PInvokeData("Commctrl.h")]
	public enum ComboBoxExMessage
	{
		/// <summary>Sets an image list for a ComboBoxEx control.</summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>A handle to the image list to be set for the control.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// Returns the handle to the image list previously associated with the control, or returns <c>NULL</c> if no image list was
		/// previously set.
		/// </para>
		/// <remarks>
		/// <para>Important</para>
		/// <para>
		/// The height of images in your image list might change the size requirements of the ComboBoxEx control. It is recommended that you
		/// resize the control after sending this message to ensure that it is displayed properly.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/cbem-setimagelist
		[MsgParams(null, typeof(HIMAGELIST), LResultType = typeof(HIMAGELIST))]
		CBEM_SETIMAGELIST = WindowMessage.WM_USER + 2,

		/// <summary>Gets the handle to an image list assigned to a ComboBoxEx control.</summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the handle to the image list assigned to the control if successful, or <c>NULL</c> otherwise.</para>
		// https://learn.microsoft.com/en-us/windows/win32/controls/cbem-getimagelist
		[MsgParams(LResultType = typeof(HIMAGELIST))]
		CBEM_GETIMAGELIST = WindowMessage.WM_USER + 3,

		/// <summary>Removes an item from a ComboBoxEx control.</summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The zero-based index of the item to be removed.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// Returns an INT value that represents the number of items remaining in the control. If iIndex is invalid, the message returns CB_ERR.
		/// </para>
		/// <remarks>This message maps to the combo box control message <c>CB_DELETESTRING</c>.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/cbem-deleteitem
		[MsgParams(typeof(int), null, LResultType = typeof(int))]
		CBEM_DELETEITEM = ComboBoxMessage.CB_DELETESTRING,

		/// <summary>Gets the handle to the child combo box control.</summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the handle to the combo box control within the ComboBoxEx control.</para>
		// https://learn.microsoft.com/en-us/windows/win32/controls/cbem-getcombocontrol
		[MsgParams(LResultType = typeof(HWND))]
		CBEM_GETCOMBOCONTROL = WindowMessage.WM_USER + 6,

		/// <summary>
		/// Gets the handle to the edit control portion of a ComboBoxEx control. A ComboBoxEx control uses an edit box when it is set to the
		/// <c>CBS_DROPDOWN</c> style.
		/// </summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// Returns the handle to the edit control within the ComboBoxEx control if it uses the <c>CBS_DROPDOWN</c> style. Otherwise, the
		/// message returns <c>NULL</c>.
		/// </para>
		// https://learn.microsoft.com/en-us/windows/win32/controls/cbem-geteditcontrol
		[MsgParams(LResultType = typeof(HWND))]
		CBEM_GETEDITCONTROL = WindowMessage.WM_USER + 7,

		/// <summary/>
		[Obsolete("Use CBEM_SETEXTENDEDSTYLE instead.", false)]
		CBEM_SETEXSTYLE = WindowMessage.WM_USER + 8,

		/// <summary>Sets extended styles within a ComboBoxEx control.</summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// A <c>DWORD</c> value that indicates which styles in lParam are to be affected. Only the extended styles in wParam will be
		/// changed. If this parameter is zero, then all of the styles in lParam will be affected.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>A <c>DWORD</c> value that contains the ComboBoxEx Control Extended Styles to set for the control.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns a <c>DWORD</c> value that contains the extended styles previously used for the control.</para>
		/// <remarks>
		/// <para>
		/// wParam enables you to modify one or more extended styles without having to retrieve the existing styles first. For example, if
		/// you pass <c>CBES_EX_NOEDITIMAGE</c> for wParam and 0 for lParam, the <c>CBES_EX_NOEDITIMAGE</c> style will be cleared, but all
		/// other styles will remain the same.
		/// </para>
		/// <para>
		/// If you try to set an extended style for a ComboBoxEx control created with the <c>CBS_SIMPLE</c> style, it may not repaint properly.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/cbem-setextendedstyle
		[MsgParams(typeof(ComboBoxExStyle), typeof(ComboBoxExStyle), LResultType = typeof(ComboBoxExStyle))]
		CBEM_SETEXTENDEDSTYLE = WindowMessage.WM_USER + 14,

		/// <summary/>
		[Obsolete("Use CBEM_GETEXTENDEDSTYLE instead.", false)]
		CBEM_GETEXSTYLE = WindowMessage.WM_USER + 9,

		/// <summary>Gets the extended styles that are in use for a ComboBoxEx control.</summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns a DWORD value that contains the ComboBoxEx control extended styles in use for the control.</para>
		// https://learn.microsoft.com/en-us/windows/win32/controls/cbem-getextendedstyle
		[MsgParams(LResultType = typeof(ComboBoxExStyle))]
		CBEM_GETEXTENDEDSTYLE = WindowMessage.WM_USER + 9,

		/// <summary>
		/// Sets the UNICODE character format flag for the control. This message enables you to change the character set used by the control
		/// at run time rather than having to re-create the control.
		/// </summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// Determines the character set that is used by the control. If this value is nonzero, the control will use Unicode characters. If
		/// this value is zero, the control will use ANSI characters.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the previous Unicode format flag for the control.</para>
		/// <remarks>See the remarks for <c>CCM_SETUNICODEFORMAT</c> for a discussion of this message.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/cbem-setunicodeformat
		[MsgParams(typeof(BOOL), null, LResultType = typeof(BOOL))]
		CBEM_SETUNICODEFORMAT = 0x2005,

		/// <summary>Gets the UNICODE character format flag for the control.</summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// Returns the Unicode format flag for the control. If this value is nonzero, the control is using Unicode characters. If this value
		/// is zero, the control is using ANSI characters.
		/// </para>
		/// <remarks>See the remarks for <c>CCM_GETUNICODEFORMAT</c> for a discussion of this message.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/cbem-getunicodeformat
		[MsgParams(LResultType = typeof(BOOL))]
		CBEM_GETUNICODEFORMAT = 0x2006,

		/// <summary>Determines whether the user has changed the text of a ComboBoxEx edit control.</summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if the text in the control's edit box has been changed, or <c>FALSE</c> otherwise.</para>
		/// <remarks>
		/// <para>
		/// A ComboBoxEx control uses an edit box control when it is set to the <c>CBS_DROPDOWN</c> style. You can retrieve the edit box
		/// control's window handle by sending a <c>CBEM_GETEDITCONTROL</c> message.
		/// </para>
		/// <para>
		/// When the user begins editing, you will receive a CBEN_BEGINEDIT notification. When editing is complete, or the focus changes, you
		/// will receive a CBEN_ENDEDIT notification. The <c>CBEM_HASEDITCHANGED</c> message is only useful for determining whether the text
		/// has been changed if it is sent before the CBEN_ENDEDIT notification. If the message is sent afterward, it will return
		/// <c>FALSE</c>. For example, suppose the user starts to edit the text in the edit box but changes focus, generating a CBEN_ENDEDIT
		/// notification. If you then send a <c>CBEM_HASEDITCHANGED</c> message, it will return <c>FALSE</c>, even though the text has been changed.
		/// </para>
		/// <para>The <c>CBS_SIMPLE</c> style does not work correctly with <c>CBEM_HASEDITCHANGED</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/cbem-haseditchanged
		[MsgParams(LResultType = typeof(BOOL))]
		CBEM_HASEDITCHANGED = WindowMessage.WM_USER + 10,

		/// <summary>Inserts a new item in a ComboBoxEx control.</summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// A pointer to a <c>COMBOBOXEXITEM</c> structure that contains information about the item to be inserted. When the message is sent,
		/// the <c>iItem</c> member must be set to indicate the zero-based index at which to insert the item. To insert an item at the end of
		/// the list, set the <c>iItem</c> member to -1.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the index at which the new item was inserted if successful, or -1 otherwise.</para>
		// https://learn.microsoft.com/en-us/windows/win32/controls/cbem-insertitem
		[MsgParams(null, typeof(COMBOBOXEXITEM), LResultType = typeof(int))]
		CBEM_INSERTITEM = WindowMessage.WM_USER + 11,

		/// <summary>Sets the attributes for an item in a ComboBoxEx control.</summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// A pointer to a <c>COMBOBOXEXITEM</c> structure that contains the item information to be set. When the message is sent, the
		/// <c>mask</c> member of the structure must be set to indicate which attributes are valid and the <c>iItem</c> member must specify
		/// the zero-based index of the item to be modified. Setting the <c>iItem</c> member to -1 will modify the item displayed in the edit control.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns nonzero if successful, or zero otherwise.</para>
		// https://learn.microsoft.com/en-us/windows/win32/controls/cbem-setitem
		[MsgParams(null, typeof(COMBOBOXEXITEM), LResultType = typeof(BOOL))]
		CBEM_SETITEM = WindowMessage.WM_USER + 12,

		/// <summary>Gets item information for a given ComboBoxEx item.</summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>A pointer to a <c>COMBOBOXEXITEM</c> structure that receives the item information.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns nonzero if successful, or zero otherwise.</para>
		/// <remarks>
		/// <para>
		/// When the message is sent, the <c>iItem</c> and <c>mask</c> members of the structure must be set to indicate the index of the
		/// target item and the type of information to be retrieved. Other members are set as needed. For example, to retrieve text, you must
		/// set the CBEIF_TEXT flag in <c>mask</c>, and assign a value to <c>cchTextMax</c>. Setting the <c>iItem</c> member to -1 will
		/// retrieve the item displayed in the edit control.
		/// </para>
		/// <para>
		/// If the CBEIF_TEXT flag is set in the <c>mask</c> member of the <c>COMBOBOXEXITEM</c> structure, the control may change the
		/// <c>pszText</c> member of the structure to point to the new text instead of filling the buffer with the requested text.
		/// Applications should not assume that the text will always be placed in the requested buffer.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/Controls/cbem-getitem
		[MsgParams(null, typeof(COMBOBOXEXITEM), LResultType = typeof(BOOL))]
		CBEM_GETITEM = WindowMessage.WM_USER + 13,

		/// <summary>Sets the visual style of a ComboBoxEx control.</summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>A pointer to a Unicode string that contains the control visual style to set.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>The return value is not used.</para>
		/// <remarks>
		/// <para>Note</para>
		/// <para>
		/// To use this message, you must provide a manifest specifying Comclt32 version 6.0. For more information on manifests, see Enabling
		/// Visual Styles.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/cbem-setwindowtheme
		[MsgParams(null, typeof(StrPtrUni), LResultType = null)]
		CBEM_SETWINDOWTHEME = 0x200B,
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

	/// <summary>Contains information used with the CBEN_DRAGBEGIN notification code.</summary>
	[PInvokeData("Commctrl.h", MSDNShortId = "bb775748")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct NMCBEDRAGBEGIN : INotificationInfo
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
	public struct NMCBEENDEDIT : INotificationInfo
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
	public struct NMCOMBOBOXEX : INotificationInfo
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
	/// <seealso cref="IDisposable"/>
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
		public nint iItem;

		/// <summary>
		/// A pointer to a character buffer that contains or receives the item's text. If text information is being retrieved, this
		/// member must be set to the address of a character buffer that will receive the text. The size of this buffer must also be
		/// indicated in cchTextMax. If this member is set to LPSTR_TEXTCALLBACK, the control will request the information by using the
		/// CBEN_GETDISPINFO notification codes.
		/// </summary>
		public StrPtrAuto pszText;

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
		public COMBOBOXEXITEM(string? text) => Text = text;

		/// <summary>Gets or sets the item's text.</summary>
		/// <value>The text value.</value>
		public string? Text
		{
			get => pszText == LPSTR_TEXTCALLBACK ? null : pszText;
			set
			{
				((IDisposable)this).Dispose();
				if (value == null) return;
				pszText.Assign(value);
				cchTextMax = value.Length;
				mask |= ComboBoxExItemMask.CBEIF_TEXT;
			}
		}

		/// <summary>Gets or sets a value indicating whether to use a text callback method.</summary>
		/// <value><c>true</c> if using text callback method; otherwise, <c>false</c>.</value>
		public bool UseTextCallback
		{
			get => pszText.Equals(LPSTR_TEXTCALLBACK);
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
			if (!pszText.IsNull && !pszText.Equals(LPSTR_TEXTCALLBACK))
			{
				pszText.Free();
				cchTextMax = 0;
			}
		}
	}
}