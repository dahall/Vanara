namespace Vanara.PInvoke
{
	public static partial class ComCtl32
	{
		internal const int CCM_FIRST = 0x2000;

		/// <summary>General Control Messages</summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/bumper-general-control-reference-messages
		[PInvokeData("Commctrl.h")]
		public enum CommonControlMessage
		{
			/// <summary/>
			CCM_SETBKCOLOR = CCM_FIRST + 1, // lParam is bkColor

			/// <summary/>
			CCM_SETCOLORSCHEME = CCM_FIRST + 2, // lParam is color scheme

			/// <summary/>
			CCM_GETCOLORSCHEME = CCM_FIRST + 3, // fills in COLORSCHEME pointed to by lParam

			/// <summary/>
			CCM_GETDROPTARGET = CCM_FIRST + 4,

			/// <summary>
			/// Sets the Unicode character format flag for the control. This message enables you to change the character set used by the
			/// control at run time rather than having to re-create the control.
			/// </summary>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>
			/// A value that determines the character set that is used by the control. If this value is <c>TRUE</c>, the control will use
			/// Unicode characters. If this value is <c>FALSE</c>, the control will use ANSI characters.
			/// </para>
			/// <para><em>lParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>Returns the previous Unicode format flag for the control.</para>
			// https://docs.microsoft.com/en-us/windows/win32/controls/ccm-setunicodeformat
			CCM_SETUNICODEFORMAT = CCM_FIRST + 5,

			/// <summary>Gets the Unicode character format flag for the control.</summary>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><em>lParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>
			/// Returns the Unicode format flag for the control. If this value is nonzero, the control is using Unicode characters. If this
			/// value is zero, the control is using ANSI characters.
			/// </para>
			// https://docs.microsoft.com/en-us/windows/win32/controls/ccm-getunicodeformat
			CCM_GETUNICODEFORMAT = CCM_FIRST + 6,

			/// <summary>This message is used to inform the control that you are expecting a behavior associated with a particular version.</summary>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>The version number.</para>
			/// <para><em>lParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>
			/// Returns the version specified in the previous <c>CCM_SETVERSION</c> message. If wParam is set to a value greater than the
			/// current DLL version, it returns -1.
			/// </para>
			/// <remarks>
			/// <para>
			/// In a few cases, a control may behave differently, depending on the version. This primarily applies to bugs that were fixed in
			/// later versions. The <c>CCM_SETVERSION</c> message enables you to inform the control which behavior is expected. You can
			/// determine which version you have specified by sending a <c>CCM_GETVERSION</c> message. For an example of how to use this
			/// message, see Custom Draw With List-View and Tree-View Controls.
			/// </para>
			/// <para>
			/// If you have ComCtl32.dll version 6 installed, regardless of what value you set in wParam, the <c>CCM_SETVERSION</c> message
			/// returns version 6.
			/// </para>
			/// <para>
			/// <para>Note</para>
			/// <para>This message only sets the version number for the control to which it is sent.</para>
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/ccm-setversion
			CCM_SETVERSION = CCM_FIRST + 0x7,

			/// <summary>Gets the version number for a control set by the most recent <c>CCM_SETVERSION</c> message.</summary>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><em>lParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>
			/// Returns the version number set by the most recent <c>CCM_SETVERSION</c> message. If no such message has been sent, it returns zero.
			/// </para>
			/// <remarks>
			/// <para>
			/// This message does not return the DLL version. See Shell Versions for a discussion of how to use <c>DllGetVersion</c> to
			/// retrieve the current DLL version.
			/// </para>
			/// <para>
			/// <para>Note</para>
			/// <para>The version number is set on a control by control basis, and may not be the same for all controls.</para>
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/ccm-getversion
			CCM_GETVERSION = CCM_FIRST + 0x8,

			/// <summary/>
			CCM_SETNOTIFYWINDOW = CCM_FIRST + 0x9, // wParam == hwndParent.

			/// <summary>Sets the visual style of a control.</summary>
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
			/// To use this message, you must provide a manifest specifying Comclt32.dll version 6.0. For more information on manifests, see
			/// Enabling Visual Styles.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/ccm-setwindowtheme
			CCM_SETWINDOWTHEME = CCM_FIRST + 0xb,

			/// <summary>
			/// Enables automatic high dots per inch (dpi) scaling in Tree-View controls, List-View controls, ComboBoxEx controls, Header
			/// controls, Buttons, Toolbar controls, Animation controls, and Image Lists.
			/// </summary>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Set to <c>TRUE</c>.</para>
			/// <para><em>lParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>The return value is not used.</para>
			/// <remarks>
			/// <para>Quick Launch and Taskbar should not specify a dpi scaling, because the images are already scaled.</para>
			/// <para>Any control that uses an image list created with the SmallIcon metric should not scale its icons.</para>
			/// <para>
			/// <para>Note</para>
			/// <para>
			/// To use this API, you must provide a manifest that specifies Comclt32.dll version 6.0. For more information on manifests, see
			/// Enabling Visual Styles.
			/// </para>
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/ccm-dpiscale
			CCM_DPISCALE = CCM_FIRST + 0xc, // wParam == Awareness
		}
	}
}