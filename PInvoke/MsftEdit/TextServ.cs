using System.Runtime.InteropServices.ComTypes;
using static Vanara.PInvoke.Imm32;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.UIAutomationCore;
using static Vanara.PInvoke.User32;

namespace Vanara.PInvoke;

public static partial class MsftEdit
{
	/// <summary>The type of change that occurred.</summary>
	[PInvokeData("textserv.h", MSDNShortId = "NS:textserv.CHANGENOTIFY")]
	[Flags]
	public enum CN : uint
	{
		/// <summary>No significant change occurred.</summary>
		CN_GENERIC = 0,

		/// <summary>The text changed.</summary>
		CN_TEXTCHANGED = 1,

		/// <summary>A new undo action was added.</summary>
		CN_NEWUNDO = 2,

		/// <summary>A new redo action was added.</summary>
		CN_NEWREDO = 4,
	}

	/// <summary>Indicates the edit style flags to retrieve.</summary>
	[PInvokeData("textserv.h")]
	[Flags]
	public enum TXES : uint
	{
		/// <summary>Indicates that the host of the rich edit control is a dialog box.</summary>
		TXES_ISDIALOG = 0x00000001
	}

	/// <summary>A variable that the text host sets to indicate the background style.</summary>
	[PInvokeData("textserv.h")]
	public enum TXTBACKSTYLE
	{
		/// <summary>Background shows through.</summary>
		TXTBACK_TRANSPARENT = 0,

		/// <summary>Background does not show through.</summary>
		TXTBACK_OPAQUE,
	}

	/// <summary>Bits representing properties to be changed or their flags.</summary>
	[PInvokeData("textserv.h", MSDNShortId = "NL:textserv.ITextServices")]
	[Flags]
	public enum TXTBIT : uint
	{
		/// <summary>Show last password char momentarily</summary>
		TXTBIT_FLASHLASTPASSWORDCHAR = 0x10000000,

		/// <summary>Use advanced input features.</summary>
		TXTBIT_ADVANCEDINPUT = 0x20000000,

		/// <summary>If TRUE, beeping is enabled.</summary>
		TXTBIT_ALLOWBEEP = 0x800,

		/// <summary>If TRUE, the AutoWordSelect feature is enabled.</summary>
		TXTBIT_AUTOWORDSEL = 0x80,

		/// <summary>If TRUE, the backstyle changed. See TxGetBackStyle.</summary>
		TXTBIT_BACKSTYLECHANGE = 0x4000,

		/// <summary>If TRUE, the character format changed.</summary>
		TXTBIT_CHARFORMATCHANGE = 0x20000,

		/// <summary>If TRUE, the client rectangle changed.</summary>
		TXTBIT_CLIENTRECTCHANGE = 0x100000,

		/// <summary>If TRUE, dragging is disabled.</summary>
		TXTBIT_DISABLEDRAG = 0x1000,

		/// <summary>Use Direct2D/DirectWrite for this instance, and not GDI/Uniscribe.</summary>
		TXTBIT_D2DDWRITE = 0x1000000,

		/// <summary>Render glyphs to the nearest pixel positions. Valid only if D2DDWRITE is set.</summary>
		TXTBIT_D2DPIXELSNAPPED = 0x4000000,

		/// <summary>
		/// Draw lines with subpixel precision. Don't pixel-snap text lines, underline, and strikethrough in the secondary text flow
		/// direction (usually vertical). Valid only if D2DDWRITE is set and D2DPIXELSNAPPED is not set.
		/// </summary>
		TXTBIT_D2DSUBPIXELLINES = 0x8000000,

		/// <summary>Render text using simple typography (no glyph rendering). This value is valid only if TXTBIT_D2DDWRITE is also specified.</summary>
		TXTBIT_D2DSIMPLETYPOGRAPHY = 0x2000000,

		/// <summary>If TRUE, the size of the client rectangle changed.</summary>
		TXTBIT_EXTENTCHANGE = 0x80000,

		/// <summary>
		/// If TRUE, the text services object should hide the selection when the control is inactive. If FALSE, the selection should be
		/// displayed when the control is inactive.
		/// <para>Note, this implies TXTBIT_SAVESELECTION is TRUE.</para>
		/// </summary>
		TXTBIT_HIDESELECTION = 0x20,

		/// <summary>If TRUE, the maximum length for text in the control changed.</summary>
		TXTBIT_MAXLENGTHCHANGE = 0x8000,

		/// <summary>
		/// If TRUE, the text services object should work in multiline mode. Use the TXTBIT_WORDWRAP value to determine whether to wrap the
		/// lines to the view rectangle or clip them.
		/// <para>
		/// If FALSE, the text services object should not process a carriage return/line feed from the ENTER key and it should truncate
		/// incoming text containing hard line breaks just before the first line break. It is also acceptable to truncate text that is set
		/// with ITextServices::TxSetText, because it is the responsibility of the host not to use a single-line control when bound to a
		/// multiline field.
		/// </para>
		/// </summary>
		TXTBIT_MULTILINE = 2,

		/// <summary>Don't reference TLS data on behalf of this instance.</summary>
		TXTBIT_NOTHREADREFCOUNT = 0x400000,

		/// <summary>If TRUE, the paragraph format changed.</summary>
		TXTBIT_PARAFORMATCHANGE = 0x40000,

		/// <summary>
		/// If TRUE, the text services object should not accept any editing change through the user interface. However, it should still
		/// accept programmatic changes through EM_SETTEXTEX, EM_REPLACESEL, and ITextServices::TxSetText. Also, the user should still be
		/// able to move the insertion point, select text, and carry out other operations that don't modify content, such as Copy.
		/// </summary>
		TXTBIT_READONLY = 4,

		/// <summary>
		/// If TRUE, the text services object should be in rich-text mode.
		/// <para>If FALSE, it is in plain-text mode.</para>
		/// <para>
		/// Note, this affects how editing commands are applied. For example, applying bold to part of the text in a plain-edit control makes
		/// the entire text bold. However, for a rich-edit control, this makes only the selected text bold.
		/// </para>
		/// </summary>
		TXTBIT_RICHTEXT = 1,

		/// <summary>
		/// If TRUE, the boundaries of the selection should be saved when the control is inactive.
		/// <para>If FALSE, when the control goes active again the selection boundaries can be reset to start = 0, length = 0.</para>
		/// </summary>
		TXTBIT_SAVESELECTION = 0x40,

		/// <summary>If TRUE, the scroll bar has changed.</summary>
		TXTBIT_SCROLLBARCHANGE = 0x10000,

		/// <summary>If TRUE, the selection bar width has changed</summary>
		TXTBIT_SELBARCHANGE = 0x200,

		/// <summary>
		/// If set, the accelerator character should be underlined.
		/// <para>This must be set in order to call TxGetAcceleratorPos.</para>
		/// </summary>
		TXTBIT_SHOWACCELERATOR = 8,

		/// <summary>Show password strings.</summary>
		TXTBIT_SHOWPASSWORD = 0x800000,

		/// <summary>Not supported.</summary>
		TXTBIT_USECURRENTBKG = 0x200000,

		/// <summary>
		/// If TRUE, display text using the password character obtained by TxGetPasswordChar.
		/// <para>
		/// The notification on this property can mean either that the password character changed or that the password character was not used
		/// before but is used now (or vice versa).
		/// </para>
		/// </summary>
		TXTBIT_USEPASSWORD = 0x10,

		/// <summary>Not supported.</summary>
		TXTBIT_VERTICAL = 0x100,

		/// <summary>If TRUE, the inset changed.</summary>
		TXTBIT_VIEWINSETCHANGE = 0x2000,

		/// <summary>
		/// If TRUE and TXTBIT_MULTILINE is also TRUE, multiline controls should wrap the line to the view rectangle. If this property is
		/// FALSE and TXTBIT_MULTILINE is TRUE, the lines should not be wrapped but clipped. The right side of the view rectangle should be ignored.
		/// <para>If TXTBIT_MULTILINE is FALSE, this property has no effect.</para>
		/// </summary>
		TXTBIT_WORDWRAP = 0x400,
	}

	/// <summary>The type of fitting requested.</summary>
	[PInvokeData("textserv.h", MSDNShortId = "NL:textserv.ITextServices")]
	[Flags]
	public enum TXTNATURALSIZE : uint
	{
		/// <summary>Resize the control so that it fits indented content.</summary>
		TXTNS_FITTOCONTENT2 = 0,

		/// <summary>
		/// Resize the control to fit the entire text by formatting the text to the width that is passed in. The text services object returns
		/// the height of the entire text and the width of the widest line. For example, this should be done when the user double-clicks one
		/// of the control's handles.
		/// </summary>
		TXTNS_FITTOCONTENT = 1,

		/// <summary>
		/// Resize the control to show an integral number of lines (no line is clipped). Format enough text to fill the width and height that
		/// is passed in, and then return a height that is rounded to the nearest line boundary.
		/// <para>
		/// <note type="note">The passed and returned width and height correspond to the view rectangle. The host should adjust back to the
		/// client rectangle as needed. Because these values represent the extent of the text object, they are input and output in HIMETRIC
		/// coordinates (each HIMETRIC unit is .01 millimeter), and measuring does not include any zoom factor. For a discussion of the zoom
		/// factor, see TxGetExtent.</note>
		/// </para>
		/// </summary>
		TXTNS_ROUNDTOLINE = 2,

		/// <summary>Resize the control so that it fits indented content and trailing whitespace.</summary>
		TXTNS_FITTOCONTENT3 = 3,

		/// <summary>Resize the control so that it fits unindented content and trailing whitespace.</summary>
		TXTNS_FITTOCONTENTWSP = 4,

		/// <summary>For a plain-text control, include the height of the final carriage return when calculating the size.</summary>
		TXTNS_INCLUDELASTLINE = 0x40000000,

		/// <summary>Use English Metric Units (EMUs) instead of pixels as the measuring units for this method's parameters.</summary>
		TXTNS_EMU = 0x80000000,
	}

	/// <summary>Specifies the view to draw.</summary>
	[PInvokeData("textserv.h", MSDNShortId = "NL:textserv.ITextServices")]
	public enum TXTVIEW
	{
		/// <summary>Draw the inplace active view.</summary>
		TXTVIEW_ACTIVE = 0,

		/// <summary>Draw a view other than the inplace active view; for example, a print preview.</summary>
		TXTVIEW_INACTIVE = 1,
	}

	/*
	/// <summary>Provides Microsoft UI Automation accessibility information about a windowless rich edit control.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nn-textserv-irichedituiainformation
	[PInvokeData("textserv.h", MSDNShortId = "NN:textserv.IRichEditUiaInformation")]
	[ComImport, Guid(""), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IRichEditUiaInformation
	{
		/// <summary>Retrieves the bounding rectangle of a windowless rich edit control.</summary>
		/// <param name="pUiaRect">
		/// <para>Type: <c>UiaRect*</c></para>
		/// <para>The bounding rectangle, in screen coordinates.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-irichedituiainformation-getboundaryrectangle HRESULT
		// GetBoundaryRectangle( UiaRect *pUiaRect );
		[PreserveSig]
		HRESULT GetBoundaryRectangle(out UiaRect pUiaRect);

		/// <summary>Indicates whether a windowless rich edit control is currently visible.</summary>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns S_OK if the windowless rich edit control is visible, or S_FALSE otherwise.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-irichedituiainformation-isvisible HRESULT IsVisible();
		[PreserveSig]
		HRESULT IsVisible();
	}
	*/

	/// <summary>
	/// Enables the host container of a windowless rich edit control to override the control's Microsoft UI Automation accessibility properties.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nn-textserv-irichedituiaoverrides
	[PInvokeData("textserv.h", MSDNShortId = "NN:textserv.IRicheditUiaOverrides")]
	[ComImport, Guid("F2FB5CC0-B5A9-437F-9BA2-47632082269F"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IRicheditUiaOverrides
	{
		/// <summary>
		/// Retrieves the host container's override value for the specified Microsoft UI Automation accessibility property of a windowless
		/// rich edit control.
		/// </summary>
		/// <param name="propertyId">
		/// <para>Type: <c>PROPERTYID</c></para>
		/// <para>The identifier of the property to retrieve.</para>
		/// </param>
		/// <param name="pRetValue">
		/// <para>Type: <c>VARIANT*</c></para>
		/// <para>The host container's override value for the <c>propertyId</c> property.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-irichedituiaoverrides-getpropertyoverridevalue HRESULT
		// GetPropertyOverrideValue( PROPERTYID propertyId, VARIANT *pRetValue );
		[PreserveSig]
		HRESULT GetPropertyOverrideValue(int /*PROPERTYID*/ propertyId, out object pRetValue);
	}

	/// <summary>
	/// Enables the host container of a windowless rich edit control to obtain the Microsoft UI Automation provider for the parent of the control.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nn-textserv-iricheditwindowlessaccessibility
	[PInvokeData("textserv.h", MSDNShortId = "NN:textserv.IRicheditWindowlessAccessibility")]
	[ComImport, Guid("983E572D-20CD-460B-9104-83111592DD10"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IRicheditWindowlessAccessibility
	{
		/// <summary>Obtains a Microsoft UI Automation provider object for the parent of a windowless rich edit control.</summary>
		/// <param name="pSite">
		/// <para>Type: <c>IRawElementProviderWindowlessSite*</c></para>
		/// <para>The ActiveX control site that hosts the windowless rich edit control.</para>
		/// </param>
		/// <param name="ppProvider">
		/// <para>Type: <c>IRawElementProviderSimple**</c></para>
		/// <para>The UI Automation provider for the windowless rich edit control's parent.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-iricheditwindowlessaccessibility-createprovider HRESULT
		// CreateProvider( IRawElementProviderWindowlessSite *pSite, IRawElementProviderSimple **ppProvider );
		[PreserveSig]
		HRESULT CreateProvider(IRawElementProviderWindowlessSite pSite, out IRawElementProviderSimple ppProvider);
	}

	/// <summary>The <c>ITextHost</c> interface is used by a text services object to obtain text host services.</summary>
	/// <remarks>
	/// <para>You must implement the <c>ITextHost</c> interface before you call the CreateTextServices function.</para>
	/// <para>
	/// Applications do not call the <c>ITextHost</c> methods. A text services object created by the CreateTextServices function calls the
	/// interface methods.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nl-textserv-itexthost
	[PInvokeData("textserv.h", MSDNShortId = "NL:textserv.ITextHost")]
	[ComVisible(true), Guid("13E670F4-1A5A-11CF-ABEB-00AA00B65EA1"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ITextHost
	{
		/// <summary>Sets the default character format for the text host.</summary>
		/// <param name="pCF">
		/// <para>Type: <c>const CHARFORMAT*</c></para>
		/// <para>The new default-character format.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Return S_OK if the method succeeds.</para>
		/// <para>
		/// Return one of the following COM error codes if the method fails. For more information on COM error codes, see Error Handling in COM.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>E_INVALIDARG</c></description>
		/// <description>One or more arguments are not valid.</description>
		/// </item>
		/// <item>
		/// <description><c>E_FAIL</c></description>
		/// <description>Unspecified error.</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost-ontxcharformatchange HRESULT
		// OnTxCharFormatChange( [in] const CHARFORMATW *pCF );
		[PreserveSig]
		HRESULT OnTxCharFormatChange(in CHARFORMAT pCF);

		/// <summary>Sets the default paragraph format for the text host.</summary>
		/// <param name="pPF">
		/// <para>Type: <c>const PARAFORMAT*</c></para>
		/// <para>The new default paragraph format.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Return S_OK if the method succeeds.</para>
		/// <para>
		/// Return one of the following COM error codes if the method fails. For more information on COM error codes, see Error Handling in COM.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>E_INVALIDARG</c></description>
		/// <description>One or more arguments are not valid.</description>
		/// </item>
		/// <item>
		/// <description><c>E_FAIL</c></description>
		/// <description>Unspecified error.</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost-ontxparaformatchange HRESULT
		// OnTxParaFormatChange( [in] const PARAFORMAT *pPF );
		[PreserveSig]
		HRESULT OnTxParaFormatChange(in PARAFORMAT pPF);

		/// <summary>Notifies the text host that the control is active.</summary>
		/// <param name="plOldState">
		/// <para>Type: <c>LONG*</c></para>
		/// <para>The previous activation state.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Return S_OK if the method succeeds.</para>
		/// <para>
		/// Return the following COM error code if the method fails. For more information on COM error codes, see Error Handling in COM.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>E_FAIL</c></description>
		/// <description>Activation is not possible at this time.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>It is legal for the host to refuse an activation request; for example, the control may be minimized and thus invisible.</para>
		/// <para>The caller should be able to gracefully handle failure to activate.</para>
		/// <para>No matter how many times this method is called, only one ITextHost::TxDeactivate call is necessary to deactivate the control.</para>
		/// <para>
		/// This function returns an opaque handle in <c>plOldState</c>. The caller (the text services object) should save this handle and
		/// use it in a subsequent call to ITextHost::TxDeactivate.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost-txactivate HRESULT TxActivate( LONG *plOldState );
		[PreserveSig]
		HRESULT TxActivate(out int plOldState);

		/// <summary>Converts text host coordinates to screen coordinates.</summary>
		/// <param name="lppt">
		/// <para>Type: <c>LPPOINT</c></para>
		/// <para>The client coordinates to convert.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Return <c>TRUE</c> if the method succeeds.</para>
		/// <para>Return <c>FALSE</c> if the method fails.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This call is valid at any time, although it is allowed to fail. In general, if the text services object needs to translate from
		/// client coordinates (for example, for the TOM GetPoint method) the text services object is visible.
		/// </para>
		/// <para>However, if no conversion is possible, then the method fails.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost-txclienttoscreen BOOL TxClientToScreen( [in]
		// LPPOINT lppt );
		[PreserveSig]
		bool TxClientToScreen(in POINT lppt);

		/// <summary>Creates a new shape for windowless rich edit control's caret.</summary>
		/// <param name="hbmp">
		/// <para>Type: <c>HBITMAP</c></para>
		/// <para>Handle to the bitmap for the new caret shape.</para>
		/// <para>If the windowless rich edit control has the SES_LOGICALCARET style, <c>hbmp</c> is a combination of the following values:</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>CARET_CUSTOM</c></description>
		/// <description>An adorned caret. This value is valid only if CARET_RTL is also specified.</description>
		/// </item>
		/// <item>
		/// <description><c>CARET_ITALIC</c></description>
		/// <description>An italicized caret.</description>
		/// </item>
		/// <item>
		/// <description><c>CARET_NONE</c></description>
		/// <description>A blinking vertical bar.</description>
		/// </item>
		/// <item>
		/// <description><c>CARET_NULL</c></description>
		/// <description>An empty bitmap (for non-degenerate text selection).</description>
		/// </item>
		/// <item>
		/// <description><c>CARET_ROTATE90</c></description>
		/// <description>A caret that is rotated clockwise by 90 degrees.</description>
		/// </item>
		/// <item>
		/// <description><c>CARET_RTL</c></description>
		/// <description>The caret moves right to left.</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="xWidth">
		/// <para>Type: <c>INT</c></para>
		/// <para>Caret width, in logical units.</para>
		/// </param>
		/// <param name="yHeight">
		/// <para>Type: <c>INT</c></para>
		/// <para>Caret height, in logical units.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Return <c>TRUE</c> if the method succeeds.</para>
		/// <para>Return <c>FALSE</c> if the method fails.</para>
		/// </returns>
		/// <remarks>This method is only valid when the control is in-place active; calls while the control is inactive may fail.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost-txcreatecaret BOOL TxCreateCaret( [in] HBITMAP
		// hbmp, [in] INT xWidth, [in] INT yHeight );
		[PreserveSig]
		bool TxCreateCaret([In] HBITMAP hbmp, int xWidth, int yHeight);

		/// <summary>Notifies the text host that the control is now inactive.</summary>
		/// <param name="lNewState">
		/// <para>Type: <c>LONG</c></para>
		/// <para>New state of the control. Typically it is the value returned by ITextHost::TxActivate.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Return S_OK if the method succeeds.</para>
		/// <para>
		/// Return the following COM error code if the method fails. For more information on COM error codes, see Error Handling in COM.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>E_FAIL</c></description>
		/// <description>Unspecified error.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// No matter how many times this method is called, only one call to ITextHost::TxActivate is necessary to activate the control.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost-txdeactivate HRESULT TxDeactivate( LONG
		// lNewState );
		[PreserveSig]
		HRESULT TxDeactivate(int lNewState);

		/// <summary>Enables or disables one or both scroll bar arrows in the text host window.</summary>
		/// <param name="fuSBFlags">
		/// <para>Type: <c>INT</c></para>
		/// <para>Specifies which scroll bar is affected. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>SB_BOTH</c></description>
		/// <description>Affects both the horizontal and vertical scroll bars.</description>
		/// </item>
		/// <item>
		/// <description><c>SB_HORZ</c></description>
		/// <description>Affects the horizontal scroll bar.</description>
		/// </item>
		/// <item>
		/// <description><c>SB_VERT</c></description>
		/// <description>Affects the vertical scroll bar.</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="fuArrowflags">
		/// <para>Type: <c>INT</c></para>
		/// <para>Specifies which scroll bar arrows are enabled or disabled. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>ESB_DISABLE_BOTH</c></description>
		/// <description>Disables both arrows on a scroll bar.</description>
		/// </item>
		/// <item>
		/// <description><c>ESB_DISABLE_DOWN</c></description>
		/// <description>Disables the down arrow on a vertical scroll bar.</description>
		/// </item>
		/// <item>
		/// <description><c>ESB_DISABLE_LEFT</c></description>
		/// <description>Disables the left arrow on a horizontal scroll bar.</description>
		/// </item>
		/// <item>
		/// <description><c>ESB_DISABLE_LTUP</c></description>
		/// <description>Disables the left arrow on a horizontal scroll bar or the up arrow of a vertical scroll bar.</description>
		/// </item>
		/// <item>
		/// <description><c>ESB_DISABLE_RIGHT</c></description>
		/// <description>Disables the right arrow on a horizontal scroll bar.</description>
		/// </item>
		/// <item>
		/// <description><c>ESB_DISABLE_RTDN</c></description>
		/// <description>Disables the right arrow on a horizontal scroll bar or the down arrow of a vertical scroll bar.</description>
		/// </item>
		/// <item>
		/// <description><c>ESB_DISABLE_UP</c></description>
		/// <description>Disables the up arrow on a vertical scroll bar.</description>
		/// </item>
		/// <item>
		/// <description><c>ESB_ENABLE_BOTH</c></description>
		/// <description>Enables both arrows on a scroll bar.</description>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Return nonzero if the arrows are enabled or disabled as specified.</para>
		/// <para>Return zero if the arrows are already in the requested state or an error occurs.</para>
		/// </returns>
		/// <remarks>This method is only valid when the control is in-place active; calls while the control is inactive may fail.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost-txenablescrollbar BOOL TxEnableScrollBar( [in]
		// INT fuSBFlags, [in] INT fuArrowflags );
		[PreserveSig]
		bool TxEnableScrollBar(SB fuSBFlags, ESB_FLAGS fuArrowflags);

		/// <summary>Requests the special character to use for the underlining accelerator character.</summary>
		/// <param name="pcp">
		/// <para>Type: <c>LONG*</c></para>
		/// <para>
		/// The character position of the character to underline. This variable is set by the text host. A character position of â1 (that
		/// is, negative one) indicates that no character should be underlined.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>The return value is <c>S_OK</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Accelerators allow keyboard shortcuts, or accelerator keys, to various UI elements (such as buttons). Typically, the shortcut
		/// character is underlined.
		/// </para>
		/// <para>
		/// This method tells the text services object which character is the accelerator and thus should be underlined. Note that the text
		/// services object does <c>not</c> process accelerators; that is the responsibility of the host.
		/// </para>
		/// <para>This method is typically only called if the TXTBIT_SHOWACCELERATOR bit is set in the text services object. See OnTxPropertyBitsChange.</para>
		/// <para>
		/// <c>Note</c> Â Â <c>Any</c> change to the text in the text services object results in the invalidation of the accelerator
		/// underlining. In this case, it is the host's responsibility to recalculate the appropriate character position and inform the text
		/// services object that a new accelerator is available.
		/// </para>
		/// <para>Â</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost-txgetacceleratorpos HRESULT
		// TxGetAcceleratorPos( LONG *pcp );
		[PreserveSig]
		HRESULT TxGetAcceleratorPos(out int pcp);

		/// <summary>Requests the background style of the text host.</summary>
		/// <param name="pstyle">
		/// <para>Type: <c>TXTBACKSTYLE*</c></para>
		/// <para>
		/// A variable that the text host sets to indicate the background style. The style is one of the following values from the
		/// <c>TXTBACKSTYLE</c> enumeration.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>TXTBACK_TRANSPARENT</c></description>
		/// <description>Background shows through.</description>
		/// </item>
		/// <item>
		/// <description><c>TXTBACK_OPAQUE</c></description>
		/// <description>Background does not show through.</description>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>The return value is <c>S_OK</c>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost-txgetbackstyle HRESULT TxGetBackStyle(
		// TXTBACKSTYLE *pstyle );
		[PreserveSig]
		HRESULT TxGetBackStyle(out TXTBACKSTYLE pstyle);

		/// <summary>Requests the text host's default character format.</summary>
		/// <param name="ppCF">
		/// <para>Type: <c>const CHARFORMAT**</c></para>
		/// <para>The default character format.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Return S_OK if the method succeeds.</para>
		/// <para>
		/// Return the following COM error code if the method fails. For more information on COM error codes, see Error Handling in COM.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>E_NOTIMPL</c></description>
		/// <description>Not implemented.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// The text host retains ownership of the CHARFORMAT returned. However, the pointer returned must remain valid until the text host
		/// notifies the text services object through OnTxPropertyBitsChange that the default character format has changed.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost-txgetcharformat HRESULT TxGetCharFormat( const
		// CHARFORMATW **ppCF );
		[PreserveSig]
		HRESULT TxGetCharFormat(out IntPtr /* CHARFORMATW* */ ppCF);

		/// <summary>Retrieves the client coordinates of the text host's client area.</summary>
		/// <param name="prc">
		/// <para>Type: <c>LPRECT</c></para>
		/// <para>The client coordinates of the text host's client area.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Return S_OK if the method succeeds.</para>
		/// <para>
		/// Return the following COM error code if the method fails. For more information on COM error codes, see Error Handling in COM.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>E_FAIL</c></description>
		/// <description>Unspecified error.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The client rectangle is the rectangle that the text services object is responsible for painting and managing. The host relies on
		/// the text services object for painting that area. And, the text services object must not paint or invalidate areas outside of that rectangle.
		/// </para>
		/// <para>The host forwards mouse messages to the text services object when the cursor is over the client rectangle.</para>
		/// <para>The client rectangle is expressed in client coordinates of the containing window.</para>
		/// <para><c>Important</c> Â Â The <c>ITextHost::TxGetClientRect</c> method will fail if called at an inactive time.</para>
		/// <para>Â</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost-txgetclientrect HRESULT TxGetClientRect( LPRECT
		// prc );
		[PreserveSig]
		HRESULT TxGetClientRect(out RECT prc);

		/// <summary>Requests the device context for the text host window.</summary>
		/// <returns>
		/// <para>Type: <c>HDC</c></para>
		/// <para>If the method succeeds, return the handle of the device context for the client area of the text host window.</para>
		/// <para>If the method fails, return <c>NULL</c>. For more information on COM error codes, see Error Handling in COM.</para>
		/// </returns>
		/// <remarks>This method is only valid when the control is in-place active; calls while the control is inactive may fail.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost-txgetdc HDC TxGetDC();
		[PreserveSig]
		HDC TxGetDC();

		/// <summary>Requests the native size of the control in HIMETRIC.</summary>
		/// <param name="lpExtent">
		/// <para>Type: <c>LPSIZEL</c></para>
		/// <para>The size of the control in HIMETRIC, that is, where the unit is .01 millimeter.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Return S_OK if the method succeeds.</para>
		/// <para>
		/// Return the following COM error code if the method fails. For more information on COM error codes, see Error Handling in COM.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>E_NOTIMPL</c></description>
		/// <description>Not implemented.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method is used by the text services object to implement zooming. The text services object derives the zoom factor from the
		/// ratio between the himetric and device pixel extent of the client rectangle. Each HIMETRIC unit corresponds to 0.01 millimeter.
		/// </para>
		/// <para>
		/// [vertical zoom factor] = [pixel height of the client rect] * 2540 / [HIMETRIC vertical extent] * [pixel per vertical inch (from
		/// device context)]
		/// </para>
		/// <para>
		/// If the vertical and horizontal zoom factors are not the same, the text services object can ignore the horizontal zoom factor and
		/// assume it is the same as the vertical one.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost-txgetextent HRESULT TxGetExtent( LPSIZEL
		// lpExtent );
		[PreserveSig]
		HRESULT TxGetExtent(out SIZE lpExtent);

		/// <summary>Gets the text host's maximum allowed length for the text.</summary>
		/// <param name="plength">
		/// <para>Type: <c>DWORD*</c></para>
		/// <para>
		/// The maximum allowed text length, in number of characters. If INFINITE is returned, the text services object can use as much
		/// memory as needed to store any specified text.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>The return value is <c>S_OK</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// When this maximum is reached, the text services object should reject any further character insertion and pasted text. TxSetText
		/// however should still accept (and set) text longer than the maximum length. This is because this method is used for binding and is
		/// critical to maintaining the integrity of the data to which the control is bound.
		/// </para>
		/// <para>This method parallels the EM_LIMITTEXT message.</para>
		/// <para>
		/// If the limit returned is less than the number of characters currently in the text services object, no data is lost. Instead, no
		/// edits are allowed to the text <c>other</c> than deletion until the text is reduced to below the limit.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost-txgetmaxlength HRESULT TxGetMaxLength( DWORD
		// *plength );
		[PreserveSig]
		HRESULT TxGetMaxLength(out uint plength);

		/// <summary>Requests the text host's default paragraph format.</summary>
		/// <param name="ppPF">
		/// <para>Type: <c>const PARAFORMAT**</c></para>
		/// <para>The default paragraph format.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Return S_OK if the method succeeds.</para>
		/// <para>
		/// Return the following COM error code if the method fails. For more information on COM error codes, see Error Handling in COM.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>E_NOTIMPL</c></description>
		/// <description>Not implemented.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// The host object retains ownership of the PARAFORMAT structure that is returned. However, the pointer returned must remain valid
		/// until the host notifies the text services object, through OnTxPropertyBitsChange, that the default paragraph format has changed.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost-txgetparaformat HRESULT TxGetParaFormat( const
		// PARAFORMAT **ppPF );
		[PreserveSig]
		HRESULT TxGetParaFormat(out IntPtr /* PARAFORMAT* */ ppPF);

		/// <summary>Requests the text host's password character.</summary>
		/// <param name="pch">
		/// <para>Type: <c>TCHAR*</c></para>
		/// <para>The password character.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Return S_OK if the password character is enabled.</para>
		/// <para>
		/// Return S_FALSE if the password character is not enabled. For more information on COM error codes, see Error Handling in COM.
		/// </para>
		/// </returns>
		/// <remarks>
		/// The password character is only shown if the TXTBIT_USEPASSWORD bit is enabled in the text services object. If the password
		/// character changes, re-enable the TXTBIT_USEPASSWORD bit through OnTxPropertyBitsChange.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost-txgetpasswordchar HRESULT TxGetPasswordChar(
		// [out] TCHAR *pch );
		[PreserveSig]
		HRESULT TxGetPasswordChar([MarshalAs(UnmanagedType.LPTStr)] out char pch);

		/// <summary>Requests the bit property settings for the text host.</summary>
		/// <param name="dwMask">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>Mask of properties in which the caller is interested. For the possible bit values, see <c>dwBits</c> in OnTxPropertyBitsChange.</para>
		/// </param>
		/// <param name="pdwBits">
		/// <para>Type: <c>DWORD*</c></para>
		/// <para>The current settings for the properties specified by <c>dwMask</c>.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>The return value is <c>S_OK</c>.</para>
		/// </returns>
		/// <remarks>This call is valid at any time, for any combination of requested property bits.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost-txgetpropertybits HRESULT TxGetPropertyBits(
		// [in] DWORD dwMask, [in] DWORD *pdwBits );
		[PreserveSig]
		HRESULT TxGetPropertyBits(TXTBIT dwMask, out TXTBIT pdwBits);

		/// <summary>Requests information about the scroll bars supported by the text host.</summary>
		/// <param name="pdwScrollBar">
		/// <para>Type: <c>DWORD*</c></para>
		/// <para>The scroll bar. This parameter can be a combination of the following window styles related to scroll bars.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><see cref="WindowStyles.WS_VSCROLL"/></description>
		/// <description>Supports a vertical scroll bar.</description>
		/// </item>
		/// <item>
		/// <description><see cref="WindowStyles.WS_HSCROLL"/></description>
		/// <description>Supports a horizontal scroll bar.</description>
		/// </item>
		/// <item>
		/// <description><see cref="RichEditStyle.ES_AUTOVSCROLL"/></description>
		/// <description>Automatically scrolls text up one page when the user presses ENTER on the last line.</description>
		/// </item>
		/// <item>
		/// <description><see cref="RichEditStyle.ES_AUTOHSCROLL"/></description>
		/// <description>
		/// Automatically scrolls text to the right by 10 characters when the user types a character at the end of the line. When the user
		/// presses ENTER, the control scrolls all text back to position zero.
		/// </description>
		/// </item>
		/// <item>
		/// <description><see cref="RichEditStyle.ES_DISABLENOSCROLL"/></description>
		/// <description>Disables scroll bars instead of hiding them when they are not needed.</description>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>The return value is <c>S_OK</c>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost-txgetscrollbars HRESULT TxGetScrollBars( DWORD
		// *pdwScrollBar );
		[PreserveSig]
		HRESULT TxGetScrollBars(out uint pdwScrollBar);

		/// <summary>Returns the size of selection bar in HIMETRIC.</summary>
		/// <param name="lSelBarWidth">
		/// <para>Type: <c>LONG*</c></para>
		/// <para>The width, in HIMETRIC (that is, where the units are .01 millimeter), of the selection bar.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>The return value is <c>S_OK</c>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost-txgetselectionbarwidth HRESULT
		// TxGetSelectionBarWidth( LONG *lSelBarWidth );
		[PreserveSig]
		HRESULT TxGetSelectionBarWidth(out int lSelBarWidth);

		/// <summary>Retrieves the text host's color for a specified display element.</summary>
		/// <param name="nIndex">
		/// <para>Type: <c>INT</c></para>
		/// <para>
		/// The display element whose color is to be retrieved. For a list of possible values for this parameter, see the GetSysColor function.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>COLORREF</c></para>
		/// <para>The value that identifies the red, green, and blue (RGB) color value of the specified element.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Note that the color returned may be <c>different</c> than the color that would be returned from a call to GetSysColor. This is
		/// the case if the host overrides the default system behavior.
		/// </para>
		/// <para>
		/// <c>Note</c> Â Â Hosts should be careful about overriding normal system behavior because it can result in inconsistent UI
		/// (particularly with respect to Accessibility options).
		/// </para>
		/// <para>Â</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost-txgetsyscolor COLORREF TxGetSysColor( [in] int
		// nIndex );
		[PreserveSig]
		COLORREF TxGetSysColor(int nIndex);

		/// <summary>Requests the dimensions of the white space inset around the text in the text host window.</summary>
		/// <param name="prc">
		/// <para>Type: <c>LPRECT</c></para>
		/// <para>
		/// The inset size, in client coordinates. The top, bottom, left, and right members of the RECT structure indicate how far in each
		/// direction the drawing should be inset.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>The return value is <c>S_OK</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The view inset is the amount of space on each side between the client rectangle and the view rectangle. The view rectangle (also
		/// called the Formatting rectangle) is the rectangle in which the text should be formatted .
		/// </para>
		/// <para>
		/// The view insets are passed in a RECT structure, but this is not really a rectangle. It should be treated as four independent
		/// values to subtract on each side of the client rectangle to figure the view rectangle.
		/// </para>
		/// <para>
		/// The view insets are passed in HIMETRIC (each HIMETRIC unit corresponds to 0.01 millimeter) so that they do not depend on the
		/// client rectangle and the rendering device context.
		/// </para>
		/// <para>
		/// View insets can be negative on either side of the client rectangle, leading to a bigger view rectangle than the client rectangle.
		/// The text should then be clipped to the client rectangle. If the view rectangle is wider than the client rectangle, then the host
		/// may add a horizontal scroll bar to the control.
		/// </para>
		/// <para>Single lineâtext services objects ignore the right boundary of the view rectangle when formatting text.</para>
		/// <para>The view inset is available from the host at all times, active or inactive.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost-txgetviewinset HRESULT TxGetViewInset( LPRECT
		// prc );
		[PreserveSig]
		HRESULT TxGetViewInset(out RECT prc);

		/// <summary>
		/// <para>Retrieves the Input Method Editor (IME) input context associated with the text services host.</para>
		/// <para>This method is used only in Asian-language versions of the operating system.</para>
		/// </summary>
		/// <returns>
		/// <para>Type: <c>HIMC</c></para>
		/// <para>The handle to the input context.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost-tximmgetcontext HIMC TxImmGetContext();
		[PreserveSig]
		HIMC TxImmGetContext();

		/// <summary>
		/// <para>
		/// Releases an input context returned by the ITextHost::TxImmGetContext method and unlocks the memory associated with the context.
		/// </para>
		/// <para>This method is used only in Asian-language versions of the operating system.</para>
		/// </summary>
		/// <param name="himc">
		/// <para>Type: <c>HIMC</c></para>
		/// <para>The input context.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost-tximmreleasecontext void TxImmReleaseContext(
		// [in] HIMC himc );
		[PreserveSig]
		void TxImmReleaseContext([In] HIMC himc);

		/// <summary>Specifies a rectangle for the text host to add to the update region of the text host window.</summary>
		/// <param name="prc">
		/// <para>Type: <c>LPCRECT</c></para>
		/// <para>The invalid rectangle.</para>
		/// </param>
		/// <param name="fMode">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// Specifies whether the background within the update region is to be erased when the update region is processed. If this parameter
		/// is <c>TRUE</c>, the background is erased when the BeginPaint function is called. If this parameter is <c>FALSE</c>, the
		/// background remains unchanged.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// This function may be called while inactive; however, the host implementation is free to invalidate an area greater than the
		/// requested RECT.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost-txinvalidaterect void TxInvalidateRect( [in]
		// LPCRECT prc, [in] BOOL fMode );
		[PreserveSig]
		void TxInvalidateRect(in RECT prc, bool fMode);

		/// <summary>Requests the text host to destroy the specified timer.</summary>
		/// <param name="idTimer">
		/// <para>Type: <c>UINT</c></para>
		/// <para>Identifier of the timer created by the ITextHost::TxSetTimer method.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>This method may be called at any time, whether the control is active or inactive.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost-txkilltimer void TxKillTimer( [in] UINT idTimer );
		[PreserveSig]
		void TxKillTimer(uint idTimer);

		/// <summary>Notifies the text host of various events.</summary>
		/// <param name="iNotify">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>Event to notify host of. One of the <c>EN_</c> notification codes.</para>
		/// </param>
		/// <param name="pv">
		/// <para>Type: <c>void*</c></para>
		/// <para>Extra data, dependent on <c>iNotify</c>.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Return S_OK if the method succeeds.</para>
		/// <para>Return S_FALSE if the method fails. For more information on COM error codes, see Error Handling in COM.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Note that there are two basic categories of events, <c>direct</c> and <c>delayed</c> . Direct events are sent immediately because
		/// they need some processing, for example, EN_PROTECTED. Delayed events are sent after all processing has occurred; the control is
		/// thus in a stable state. Examples of delayed notifications are EN_CHANGE, EN_ERRSPACE, and EN_SELCHANGE.
		/// </para>
		/// <para>
		/// The notification events are the same as the notification codes sent to the parent window of a rich edit window. The firing of
		/// events may be controlled with a mask set through the EM_SETEVENTMASK message.
		/// </para>
		/// <para>
		/// In general, it is legal to make calls to the text services object while processing this method; however, implementers are
		/// cautioned to avoid excessive recursion.
		/// </para>
		/// <para>The following is a list of the notifications that may be sent.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Notification</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description>EN_CHANGE</description>
		/// <description>
		/// Sent after the system updates the screen, when the user takes an action that may have altered text in the control.
		/// </description>
		/// </item>
		/// <item>
		/// <description>EN_DROPFILES</description>
		/// <description>Sent when either a WM_DROPFILES message or an IDropTarget::DragEnter notification is received.</description>
		/// </item>
		/// <item>
		/// <description>EN_ERRSPACE</description>
		/// <description>Sent when a control cannot allocate enough memory to meet a specified request.</description>
		/// </item>
		/// <item>
		/// <description>EN_HSCROLL</description>
		/// <description>Sent when the user clicks the control's horizontal scroll bar before the screen is updated.</description>
		/// </item>
		/// <item>
		/// <description>EN_KILLFOCUS</description>
		/// <description>Sent when the control loses the keyboard focus.</description>
		/// </item>
		/// <item>
		/// <description>EN_LINK</description>
		/// <description>
		/// Sent when a rich edit control receives various messages, such as mouse click messages, when the mouse pointer is over text that
		/// has the CFE_LINK effect.
		/// </description>
		/// </item>
		/// <item>
		/// <description>EN_MAXTEXT</description>
		/// <description>Sent when the current text insertion has exceeded the maximum number of characters for the control.</description>
		/// </item>
		/// <item>
		/// <description>EN_OLEOPFAILED</description>
		/// <description>Sent when a user action on an OLE object has failed.</description>
		/// </item>
		/// <item>
		/// <description>EN_PROTECTED</description>
		/// <description>Sent when the user takes an action that changes the protected range of text.</description>
		/// </item>
		/// <item>
		/// <description>EN_REQUESTRESIZE</description>
		/// <description>Sent when a rich edit control's contents are different from the control's window size.</description>
		/// </item>
		/// <item>
		/// <description>EN_SAVECLIPBOARD</description>
		/// <description>
		/// Sent when an edit control is being destroyed. The text host should indicate whether OleFlushClipboard should be called. Data
		/// indicating the number of characters and objects to be flushed is sent in the ENSAVECLIPBOARD data structure. Mask value is nothing.
		/// </description>
		/// </item>
		/// <item>
		/// <description>EN_SELCHANGE</description>
		/// <description>
		/// Sent when the current selection has changed. A SELCHANGE data structure is also sent, which indicates the new selection range at
		/// the type of data the selection is currently over. Controlled through the ENM_SELCHANGE mask.
		/// </description>
		/// </item>
		/// <item>
		/// <description>EN_SETFOCUS</description>
		/// <description>Sent when the edit control receives the keyboard focus. No extra data is sent; there is no mask.</description>
		/// </item>
		/// <item>
		/// <description>EN_STOPNOUNDO</description>
		/// <description>
		/// Sent when an action occurs for which the control cannot allocate enough memory to maintain the undo state. If S_FALSE is
		/// returned, the action will be stopped; otherwise, the action will continue.
		/// </description>
		/// </item>
		/// <item>
		/// <description>EN_UPDATE</description>
		/// <description>
		/// Sent before an edit control requests a redraw of altered data or text. No additional data is sent. This event is controlled
		/// through the ENM_UPDATE mask. <c>Rich Edit 2.0 and later:</c> The ENM_UPDATE mask is ignored and the EN_UPDATE notification code
		/// is always sent. However, when Microsoft Rich EditÂ 3.0 emulates Microsoft Rich EditÂ 1.0, the <c>ENM_UPDATE</c> mask controls
		/// this notification.
		/// </description>
		/// </item>
		/// <item>
		/// <description>EN_VSCROLL</description>
		/// <description>
		/// Sent when the user clicks an edit control's vertical scroll bar or when the user scrolls the mouse wheel over the edit control,
		/// before the screen is updated. This is controlled through the ENM_SCROLL mask; no extra data is sent.
		/// </description>
		/// </item>
		/// </list>
		/// <para>Â</para>
		/// <para><c>Note</c> Â Â The EN_MSGFILTER is not sent to <c>TxNotify</c>. To filter window messages, use TxSendMessage.</para>
		/// <para>Â</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost-txnotify HRESULT TxNotify( [in] DWORD iNotify,
		// [in] void *pv );
		[PreserveSig]
		HRESULT TxNotify(EditNotification iNotify, IntPtr pv);

		/// <summary>Releases the device context obtained by the ITextHost::TxGetDC method.</summary>
		/// <param name="hdc">
		/// <para>Type: <c>HDC</c></para>
		/// <para>Handle to the device context to release.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>INT</c></para>
		/// <para>Returns 1 if <c>hdc</c> was released; otherwise 0.</para>
		/// <para>For more information on COM error codes, see Error Handling in COM.</para>
		/// </returns>
		/// <remarks>This method is only valid when the control is in-place active; calls while the control is inactive may fail.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost-txreleasedc INT TxReleaseDC( [in] HDC hdc );
		[PreserveSig]
		int TxReleaseDC(HDC hdc);

		/// <summary>Converts the screen coordinates to the text host window coordinates.</summary>
		/// <param name="lppt">
		/// <para>Type: <c>LPPOINT</c></para>
		/// <para>The screen coordinates to convert.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Return <c>TRUE</c> if the call succeeds.</para>
		/// <para>Return <c>FALSE</c> if the call fails.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost-txscreentoclient BOOL TxScreenToClient( [in]
		// LPPOINT lppt );
		[PreserveSig]
		bool TxScreenToClient(in POINT lppt);

		/// <summary>Requests the text host to scroll the content of the specified client area.</summary>
		/// <param name="dx">
		/// <para>Type: <c>INT</c></para>
		/// <para>Amount of horizontal scrolling.</para>
		/// </param>
		/// <param name="dy">
		/// <para>Type: <c>INT</c></para>
		/// <para>Amount of vertical scrolling.</para>
		/// </param>
		/// <param name="lprcScroll">
		/// <para>Type: <c>LPCRECT</c></para>
		/// <para>The coordinates for the scroll rectangle.</para>
		/// </param>
		/// <param name="lprcClip">
		/// <para>Type: <c>LPCRECT</c></para>
		/// <para>The coordinates for the clip rectangle.</para>
		/// </param>
		/// <param name="hrgnUpdate">
		/// <para>Type: <c>HRGN</c></para>
		/// <para>Handle to the update region.</para>
		/// </param>
		/// <param name="lprcUpdate">
		/// <para>Type: <c>LPRECT</c></para>
		/// <para>The coordinates for the update rectangle.</para>
		/// </param>
		/// <param name="fuScroll">
		/// <para>Type: <c>UINT</c></para>
		/// <para>Scrolling flags. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>SW_ERASE</c></description>
		/// <description>
		/// Erases the newly invalidated region by sending a WM_ERASEBKGND message to the window when specified with the SW_INVALIDATE flag.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>SW_INVALIDATE</c></description>
		/// <description>Invalidates the region identified by the <c>hrgnUpdate</c> parameter after scrolling.</description>
		/// </item>
		/// <item>
		/// <description><c>SW_SCROLLCHILDREN</c></description>
		/// <description>
		/// Scrolls all child windows that intersect the rectangle pointed to by the <c>lprcScroll</c> parameter. The child windows are
		/// scrolled by the number of pixels specified by the <c>dx</c> and <c>dy</c> parameters. The system sends a WM_MOVE message to all
		/// child windows that intersect the <c>lprcScroll</c> rectangle, even if they do not move.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>SW_SMOOTHSCROLL</c></description>
		/// <description>
		/// Scrolls using smooth scrolling. Use the HIWORD portion of the <c>fuScroll</c> parameter to indicate how much time the
		/// smooth-scrolling operation should take.
		/// </description>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>This method is only valid when the control is in-place active; calls while the control is inactive may fail.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost-txscrollwindowex void TxScrollWindowEx( [in]
		// INT dx, [in] INT dy, [in] LPCRECT lprcScroll, [in] LPCRECT lprcClip, [in] HRGN hrgnUpdate, [in] LPRECT lprcUpdate, [in] UINT
		// fuScroll );
		[PreserveSig]
		void TxScrollWindowEx(int dx, int dy, in RECT lprcScroll, in RECT lprcClip, [In] HRGN hrgnUpdate, in RECT lprcUpdate, ScrollWindowFlags fuScroll);

		/// <summary>Sets the mouse capture in the text host's window.</summary>
		/// <param name="fCapture">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// Indicates whether to set or release the mouse capture. If <c>TRUE</c>, the mouse capture is set. If <c>FALSE</c>, the mouse
		/// capture is released.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>This method is only valid when the control is in-place active; calls while the control is inactive may do nothing.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost-txsetcapture void TxSetCapture( [in] BOOL
		// fCapture );
		[PreserveSig]
		void TxSetCapture(bool fCapture);

		/// <summary>Moves the caret position to the specified coordinates in the text host window.</summary>
		/// <param name="x">
		/// <para>Type: <c>INT</c></para>
		/// <para>Horizontal position (in client coordinates).</para>
		/// </param>
		/// <param name="y">
		/// <para>Type: <c>INT</c></para>
		/// <para>Vertical position (in client coordinates).</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Return <c>TRUE</c> if the method succeeds.</para>
		/// <para>Return <c>FALSE</c> if the method fails.</para>
		/// </returns>
		/// <remarks>This method is only valid when the control is in-place active; calls while the control is inactive may fail.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost-txsetcaretpos BOOL TxSetCaretPos( [in] INT x,
		// [in] INT y );
		[PreserveSig]
		bool TxSetCaretPos(int x, int y);

		/// <summary>Establishes a new cursor shape (I-beam) in the text host's window.</summary>
		/// <param name="hcur">
		/// <para>Type: <c>HCURSOR</c></para>
		/// <para>Handle to the cursor.</para>
		/// </param>
		/// <param name="fText">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>If <c>TRUE</c>, indicates the caller is trying to set the text cursor. See the Remarks section for more information.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>This method may be called at any time, whether the control is active or inactive.</para>
		/// <para>
		/// <c>TxSetCursor</c> should be called by the text services object to set the mouse cursor. If the <c>fText</c> parameter is
		/// <c>TRUE</c>, the text services object is trying to set the text cursor (the cursor appears as an I-beam when it is over text that
		/// is not selected). In this case, the host can set it to whatever the control MousePointer property is. This is required for
		/// Microsoft Visual Basic compatibility since, through the MousePointer property, the Visual Basic programmer has control over the
		/// shape of the mouse cursor.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost-txsetcursor void TxSetCursor( [in] HCURSOR
		// hcur, [in] BOOL fText );
		[PreserveSig]
		void TxSetCursor([In] HCURSOR hcur, bool fText);

		/// <summary>Sets the focus to the text host window.</summary>
		/// <returns>None</returns>
		/// <remarks>This method is only valid when the control is in-place active; calls while the control is inactive may fail.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost-txsetfocus void TxSetFocus();
		[PreserveSig]
		void TxSetFocus();

		/// <summary>
		/// Sets the position of the scroll box (thumb) in the specified scroll bar and, if requested, redraws the scroll bar to reflect the
		/// new position of the scroll box.
		/// </summary>
		/// <param name="fnBar">
		/// <para>Type: <c>INT</c></para>
		/// <para>Scroll bar flag. If this is SB_HORZ, horizontal scrolling is done. By default, vertical scrolling is done.</para>
		/// </param>
		/// <param name="nPos">
		/// <para>Type: <c>INT</c></para>
		/// <para>New position in scroll box. This must be within the range of scroll bar values set by ITextHost::TxSetScrollRange.</para>
		/// </param>
		/// <param name="fRedraw">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// Redraw flag. If <c>TRUE</c>, the scroll bar is redrawn with the new position of the scroll box. If <c>FALSE</c>, the scroll bar
		/// is not redrawn.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Return <c>TRUE</c> if the method succeeds.</para>
		/// <para>Return <c>FALSE</c> if the method fails.</para>
		/// </returns>
		/// <remarks>This method is only valid when the control is in-place active; calls while the control is inactive may fail.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost-txsetscrollpos BOOL TxSetScrollPos( [in] INT
		// fnBar, [in] INT nPos, [in] BOOL fRedraw );
		[PreserveSig]
		bool TxSetScrollPos(SB fnBar, int nPos, bool fRedraw);

		/// <summary>Sets the minimum and maximum position values for the specified scroll bar in the text host window.</summary>
		/// <param name="fnBar">
		/// <para>Type: <c>INT</c></para>
		/// <para>Scroll bar flag. If this is SB_HORZ, horizontal scrolling is done. By default, vertical scrolling is done.</para>
		/// </param>
		/// <param name="nMinPos">
		/// <para>Type: <c>LONG</c></para>
		/// <para>Minimum scrolling position.</para>
		/// </param>
		/// <param name="nMaxPos">
		/// <para>Type: <c>INT</c></para>
		/// <para>Maximum scrolling position.</para>
		/// </param>
		/// <param name="fRedraw">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Redraw flag. If <c>TRUE</c>, the scroll bar is redrawn to reflect the changes. If <c>FALSE</c>, the scroll bar is not redrawn.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Return <c>TRUE</c> if the arrows are enabled or disabled as specified.</para>
		/// <para>Return <c>FALSE</c> if the arrows are already in the requested state or an error occurs.</para>
		/// </returns>
		/// <remarks>This method is only valid when the control is in-place active; calls while the control is inactive may fail.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost-txsetscrollrange BOOL TxSetScrollRange( [in]
		// INT fnBar, [in] LONG nMinPos, [in] INT nMaxPos, BOOL fRedraw );
		[PreserveSig]
		bool TxSetScrollRange(SB fnBar, int nMinPos, int nMaxPos, bool fRedraw);

		/// <summary>Requests the text host to create a timer with a specified time-out.</summary>
		/// <param name="idTimer">
		/// <para>Type: <c>UINT</c></para>
		/// <para>Timer identifier.</para>
		/// </param>
		/// <param name="uTimeout">
		/// <para>Type: <c>UINT</c></para>
		/// <para>Time-out in milliseconds.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Return <c>TRUE</c> if the method succeeds.</para>
		/// <para>Return <c>FALSE</c> if the method fails.</para>
		/// </returns>
		/// <remarks><c>idTimer</c> is used in ITextHost::TxKillTimer.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost-txsettimer BOOL TxSetTimer( [in] UINT idTimer,
		// [in] UINT uTimeout );
		[PreserveSig]
		bool TxSetTimer(uint idTimer, uint uTimeout);

		/// <summary>Shows or hides the caret at the caret position in the text host window.</summary>
		/// <param name="fShow">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Flag. If <c>TRUE</c>, the caret is visible. If <c>FALSE</c>, the caret is hidden.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Return <c>TRUE</c> if the method succeeds.</para>
		/// <para>Return <c>FALSE</c> if the method fails.</para>
		/// </returns>
		/// <remarks>This method is only valid when the control is in-place active; calls while the control is inactive may fail.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost-txshowcaret BOOL TxShowCaret( [in] BOOL fShow );
		[PreserveSig]
		bool TxShowCaret(bool fShow);

		/// <summary>Shows or hides the scroll bar in the text host window.</summary>
		/// <param name="fnBar">
		/// <para>Type: <c>INT</c></para>
		/// <para>Specifies the scroll bar(s) to be shown or hidden. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description>SB_BOTH</description>
		/// <description>Shows or hides a window's standard horizontal and vertical scroll bars.</description>
		/// </item>
		/// <item>
		/// <description>SB_HORZ</description>
		/// <description>Shows or hides a window's standard horizontal scroll bars.</description>
		/// </item>
		/// <item>
		/// <description>SB_VERT</description>
		/// <description>Shows or hides a window's standard vertical scroll bar.</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="fShow">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Flag. If <c>TRUE</c>, the scroll bars indicated by <c>fnBar</c> is visible. If <c>FALSE</c>, the scroll bar is hidden.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Return <c>TRUE</c> if the method succeeds.</para>
		/// <para>Return <c>FALSE</c> if the method fails.</para>
		/// </returns>
		/// <remarks>This method is only valid when the control is in-place active; calls while the control is inactive may fail.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost-txshowscrollbar BOOL TxShowScrollBar( [in] INT
		// fnBar, [in] BOOL fShow );
		[PreserveSig]
		bool TxShowScrollBar(SB fnBar, bool fShow);

		/// <summary>Indicates to the text host that the update region has changed.</summary>
		/// <param name="fUpdate">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Update flag. If <c>TRUE</c>, the text host calls UpdateWindow; otherwise it does nothing. See the Remarks section.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The text services object must call <c>TxViewChange</c> every time its visual representation has changed, even if the control is
		/// inactive. If the control is active, then text services must also make sure the control's window is updated. It can do this in a
		/// number of ways:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// Call ITextHost::TxGetDC to get a device context for the control's window and then repaint or update the window. Afterward, call ITextHost::TxReleaseDC.
		/// </description>
		/// </item>
		/// <item>
		/// <description>Call ITextHost::TxInvalidateRect to invalidate the control's window.</description>
		/// </item>
		/// <item>
		/// <description>Call ITextHost::TxScrollWindowEx to scroll the control's window.</description>
		/// </item>
		/// </list>
		/// <para>
		/// After the text services object has updated the active view, it can call <c>TxViewChange</c> and set <c>fUpdate</c> to <c>TRUE</c>
		/// along with the call. By passing <c>TRUE</c>, the text host calls UpdateWindow to make sure any unpainted areas of the active
		/// control are repainted.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost-txviewchange void TxViewChange( [in] BOOL
		// fUpdate );
		[PreserveSig]
		void TxViewChange(bool fUpdate);
	}

	/// <summary>
	/// The <c>ITextHost2</c> interface extends the ITextHost interface. The purpose of these interfaces, along with ITextServices and
	/// ITextServices2, is to enable rich edit controls to run without a dedicated window. The rich edit client typically has a window (
	/// <c>HWND</c>) that it shares with a number of windowless controls.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nl-textserv-itexthost2
	[PInvokeData("textserv.h", MSDNShortId = "NL:textserv.ITextHost2")]
	[ComVisible(true), Guid("13e670f5-1a5a-11cf-abeb-00aa00b65ea1"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ITextHost2 : ITextHost
	{
		/// <summary>Requests the device context for the text host window.</summary>
		/// <returns>
		/// <para>Type: <c>HDC</c></para>
		/// <para>If the method succeeds, return the handle of the device context for the client area of the text host window.</para>
		/// <para>If the method fails, return <c>NULL</c>. For more information on COM error codes, see Error Handling in COM.</para>
		/// </returns>
		/// <remarks>This method is only valid when the control is in-place active; calls while the control is inactive may fail.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost-txgetdc HDC TxGetDC();
		[PreserveSig]
		new HDC TxGetDC();

		/// <summary>Releases the device context obtained by the ITextHost::TxGetDC method.</summary>
		/// <param name="hdc">
		/// <para>Type: <c>HDC</c></para>
		/// <para>Handle to the device context to release.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>INT</c></para>
		/// <para>Returns 1 if <c>hdc</c> was released; otherwise 0.</para>
		/// <para>For more information on COM error codes, see Error Handling in COM.</para>
		/// </returns>
		/// <remarks>This method is only valid when the control is in-place active; calls while the control is inactive may fail.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost-txreleasedc INT TxReleaseDC( [in] HDC hdc );
		[PreserveSig]
		new int TxReleaseDC(HDC hdc);

		/// <summary>Shows or hides the scroll bar in the text host window.</summary>
		/// <param name="fnBar">
		/// <para>Type: <c>INT</c></para>
		/// <para>Specifies the scroll bar(s) to be shown or hidden. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description>SB_BOTH</description>
		/// <description>Shows or hides a window's standard horizontal and vertical scroll bars.</description>
		/// </item>
		/// <item>
		/// <description>SB_HORZ</description>
		/// <description>Shows or hides a window's standard horizontal scroll bars.</description>
		/// </item>
		/// <item>
		/// <description>SB_VERT</description>
		/// <description>Shows or hides a window's standard vertical scroll bar.</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="fShow">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Flag. If <c>TRUE</c>, the scroll bars indicated by <c>fnBar</c> is visible. If <c>FALSE</c>, the scroll bar is hidden.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Return <c>TRUE</c> if the method succeeds.</para>
		/// <para>Return <c>FALSE</c> if the method fails.</para>
		/// </returns>
		/// <remarks>This method is only valid when the control is in-place active; calls while the control is inactive may fail.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost-txshowscrollbar BOOL TxShowScrollBar( [in] INT
		// fnBar, [in] BOOL fShow );
		[PreserveSig]
		new bool TxShowScrollBar(SB fnBar, bool fShow);

		/// <summary>Enables or disables one or both scroll bar arrows in the text host window.</summary>
		/// <param name="fuSBFlags">
		/// <para>Type: <c>INT</c></para>
		/// <para>Specifies which scroll bar is affected. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>SB_BOTH</c></description>
		/// <description>Affects both the horizontal and vertical scroll bars.</description>
		/// </item>
		/// <item>
		/// <description><c>SB_HORZ</c></description>
		/// <description>Affects the horizontal scroll bar.</description>
		/// </item>
		/// <item>
		/// <description><c>SB_VERT</c></description>
		/// <description>Affects the vertical scroll bar.</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="fuArrowflags">
		/// <para>Type: <c>INT</c></para>
		/// <para>Specifies which scroll bar arrows are enabled or disabled. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>ESB_DISABLE_BOTH</c></description>
		/// <description>Disables both arrows on a scroll bar.</description>
		/// </item>
		/// <item>
		/// <description><c>ESB_DISABLE_DOWN</c></description>
		/// <description>Disables the down arrow on a vertical scroll bar.</description>
		/// </item>
		/// <item>
		/// <description><c>ESB_DISABLE_LEFT</c></description>
		/// <description>Disables the left arrow on a horizontal scroll bar.</description>
		/// </item>
		/// <item>
		/// <description><c>ESB_DISABLE_LTUP</c></description>
		/// <description>Disables the left arrow on a horizontal scroll bar or the up arrow of a vertical scroll bar.</description>
		/// </item>
		/// <item>
		/// <description><c>ESB_DISABLE_RIGHT</c></description>
		/// <description>Disables the right arrow on a horizontal scroll bar.</description>
		/// </item>
		/// <item>
		/// <description><c>ESB_DISABLE_RTDN</c></description>
		/// <description>Disables the right arrow on a horizontal scroll bar or the down arrow of a vertical scroll bar.</description>
		/// </item>
		/// <item>
		/// <description><c>ESB_DISABLE_UP</c></description>
		/// <description>Disables the up arrow on a vertical scroll bar.</description>
		/// </item>
		/// <item>
		/// <description><c>ESB_ENABLE_BOTH</c></description>
		/// <description>Enables both arrows on a scroll bar.</description>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Return nonzero if the arrows are enabled or disabled as specified.</para>
		/// <para>Return zero if the arrows are already in the requested state or an error occurs.</para>
		/// </returns>
		/// <remarks>This method is only valid when the control is in-place active; calls while the control is inactive may fail.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost-txenablescrollbar BOOL TxEnableScrollBar( [in]
		// INT fuSBFlags, [in] INT fuArrowflags );
		[PreserveSig]
		new bool TxEnableScrollBar(SB fuSBFlags, ESB_FLAGS fuArrowflags);

		/// <summary>Sets the minimum and maximum position values for the specified scroll bar in the text host window.</summary>
		/// <param name="fnBar">
		/// <para>Type: <c>INT</c></para>
		/// <para>Scroll bar flag. If this is SB_HORZ, horizontal scrolling is done. By default, vertical scrolling is done.</para>
		/// </param>
		/// <param name="nMinPos">
		/// <para>Type: <c>LONG</c></para>
		/// <para>Minimum scrolling position.</para>
		/// </param>
		/// <param name="nMaxPos">
		/// <para>Type: <c>INT</c></para>
		/// <para>Maximum scrolling position.</para>
		/// </param>
		/// <param name="fRedraw">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Redraw flag. If <c>TRUE</c>, the scroll bar is redrawn to reflect the changes. If <c>FALSE</c>, the scroll bar is not redrawn.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Return <c>TRUE</c> if the arrows are enabled or disabled as specified.</para>
		/// <para>Return <c>FALSE</c> if the arrows are already in the requested state or an error occurs.</para>
		/// </returns>
		/// <remarks>This method is only valid when the control is in-place active; calls while the control is inactive may fail.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost-txsetscrollrange BOOL TxSetScrollRange( [in]
		// INT fnBar, [in] LONG nMinPos, [in] INT nMaxPos, BOOL fRedraw );
		[PreserveSig]
		new bool TxSetScrollRange(SB fnBar, int nMinPos, int nMaxPos, bool fRedraw);

		/// <summary>
		/// Sets the position of the scroll box (thumb) in the specified scroll bar and, if requested, redraws the scroll bar to reflect the
		/// new position of the scroll box.
		/// </summary>
		/// <param name="fnBar">
		/// <para>Type: <c>INT</c></para>
		/// <para>Scroll bar flag. If this is SB_HORZ, horizontal scrolling is done. By default, vertical scrolling is done.</para>
		/// </param>
		/// <param name="nPos">
		/// <para>Type: <c>INT</c></para>
		/// <para>New position in scroll box. This must be within the range of scroll bar values set by ITextHost::TxSetScrollRange.</para>
		/// </param>
		/// <param name="fRedraw">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// Redraw flag. If <c>TRUE</c>, the scroll bar is redrawn with the new position of the scroll box. If <c>FALSE</c>, the scroll bar
		/// is not redrawn.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Return <c>TRUE</c> if the method succeeds.</para>
		/// <para>Return <c>FALSE</c> if the method fails.</para>
		/// </returns>
		/// <remarks>This method is only valid when the control is in-place active; calls while the control is inactive may fail.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost-txsetscrollpos BOOL TxSetScrollPos( [in] INT
		// fnBar, [in] INT nPos, [in] BOOL fRedraw );
		[PreserveSig]
		new bool TxSetScrollPos(SB fnBar, int nPos, bool fRedraw);

		/// <summary>Specifies a rectangle for the text host to add to the update region of the text host window.</summary>
		/// <param name="prc">
		/// <para>Type: <c>LPCRECT</c></para>
		/// <para>The invalid rectangle.</para>
		/// </param>
		/// <param name="fMode">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// Specifies whether the background within the update region is to be erased when the update region is processed. If this parameter
		/// is <c>TRUE</c>, the background is erased when the BeginPaint function is called. If this parameter is <c>FALSE</c>, the
		/// background remains unchanged.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// This function may be called while inactive; however, the host implementation is free to invalidate an area greater than the
		/// requested RECT.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost-txinvalidaterect void TxInvalidateRect( [in]
		// LPCRECT prc, [in] BOOL fMode );
		[PreserveSig]
		new void TxInvalidateRect(in RECT prc, bool fMode);

		/// <summary>Indicates to the text host that the update region has changed.</summary>
		/// <param name="fUpdate">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Update flag. If <c>TRUE</c>, the text host calls UpdateWindow; otherwise it does nothing. See the Remarks section.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The text services object must call <c>TxViewChange</c> every time its visual representation has changed, even if the control is
		/// inactive. If the control is active, then text services must also make sure the control's window is updated. It can do this in a
		/// number of ways:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// Call ITextHost::TxGetDC to get a device context for the control's window and then repaint or update the window. Afterward, call ITextHost::TxReleaseDC.
		/// </description>
		/// </item>
		/// <item>
		/// <description>Call ITextHost::TxInvalidateRect to invalidate the control's window.</description>
		/// </item>
		/// <item>
		/// <description>Call ITextHost::TxScrollWindowEx to scroll the control's window.</description>
		/// </item>
		/// </list>
		/// <para>
		/// After the text services object has updated the active view, it can call <c>TxViewChange</c> and set <c>fUpdate</c> to <c>TRUE</c>
		/// along with the call. By passing <c>TRUE</c>, the text host calls UpdateWindow to make sure any unpainted areas of the active
		/// control are repainted.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost-txviewchange void TxViewChange( [in] BOOL
		// fUpdate );
		[PreserveSig]
		new void TxViewChange(bool fUpdate);

		/// <summary>Creates a new shape for windowless rich edit control's caret.</summary>
		/// <param name="hbmp">
		/// <para>Type: <c>HBITMAP</c></para>
		/// <para>Handle to the bitmap for the new caret shape.</para>
		/// <para>If the windowless rich edit control has the SES_LOGICALCARET style, <c>hbmp</c> is a combination of the following values:</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>CARET_CUSTOM</c></description>
		/// <description>An adorned caret. This value is valid only if CARET_RTL is also specified.</description>
		/// </item>
		/// <item>
		/// <description><c>CARET_ITALIC</c></description>
		/// <description>An italicized caret.</description>
		/// </item>
		/// <item>
		/// <description><c>CARET_NONE</c></description>
		/// <description>A blinking vertical bar.</description>
		/// </item>
		/// <item>
		/// <description><c>CARET_NULL</c></description>
		/// <description>An empty bitmap (for non-degenerate text selection).</description>
		/// </item>
		/// <item>
		/// <description><c>CARET_ROTATE90</c></description>
		/// <description>A caret that is rotated clockwise by 90 degrees.</description>
		/// </item>
		/// <item>
		/// <description><c>CARET_RTL</c></description>
		/// <description>The caret moves right to left.</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="xWidth">
		/// <para>Type: <c>INT</c></para>
		/// <para>Caret width, in logical units.</para>
		/// </param>
		/// <param name="yHeight">
		/// <para>Type: <c>INT</c></para>
		/// <para>Caret height, in logical units.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Return <c>TRUE</c> if the method succeeds.</para>
		/// <para>Return <c>FALSE</c> if the method fails.</para>
		/// </returns>
		/// <remarks>This method is only valid when the control is in-place active; calls while the control is inactive may fail.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost-txcreatecaret BOOL TxCreateCaret( [in] HBITMAP
		// hbmp, [in] INT xWidth, [in] INT yHeight );
		[PreserveSig]
		new bool TxCreateCaret([In] HBITMAP hbmp, int xWidth, int yHeight);

		/// <summary>Shows or hides the caret at the caret position in the text host window.</summary>
		/// <param name="fShow">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Flag. If <c>TRUE</c>, the caret is visible. If <c>FALSE</c>, the caret is hidden.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Return <c>TRUE</c> if the method succeeds.</para>
		/// <para>Return <c>FALSE</c> if the method fails.</para>
		/// </returns>
		/// <remarks>This method is only valid when the control is in-place active; calls while the control is inactive may fail.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost-txshowcaret BOOL TxShowCaret( [in] BOOL fShow );
		[PreserveSig]
		new bool TxShowCaret(bool fShow);

		/// <summary>Moves the caret position to the specified coordinates in the text host window.</summary>
		/// <param name="x">
		/// <para>Type: <c>INT</c></para>
		/// <para>Horizontal position (in client coordinates).</para>
		/// </param>
		/// <param name="y">
		/// <para>Type: <c>INT</c></para>
		/// <para>Vertical position (in client coordinates).</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Return <c>TRUE</c> if the method succeeds.</para>
		/// <para>Return <c>FALSE</c> if the method fails.</para>
		/// </returns>
		/// <remarks>This method is only valid when the control is in-place active; calls while the control is inactive may fail.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost-txsetcaretpos BOOL TxSetCaretPos( [in] INT x,
		// [in] INT y );
		[PreserveSig]
		new bool TxSetCaretPos(int x, int y);

		/// <summary>Requests the text host to create a timer with a specified time-out.</summary>
		/// <param name="idTimer">
		/// <para>Type: <c>UINT</c></para>
		/// <para>Timer identifier.</para>
		/// </param>
		/// <param name="uTimeout">
		/// <para>Type: <c>UINT</c></para>
		/// <para>Time-out in milliseconds.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Return <c>TRUE</c> if the method succeeds.</para>
		/// <para>Return <c>FALSE</c> if the method fails.</para>
		/// </returns>
		/// <remarks><c>idTimer</c> is used in ITextHost::TxKillTimer.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost-txsettimer BOOL TxSetTimer( [in] UINT idTimer,
		// [in] UINT uTimeout );
		[PreserveSig]
		new bool TxSetTimer(uint idTimer, uint uTimeout);

		/// <summary>Requests the text host to destroy the specified timer.</summary>
		/// <param name="idTimer">
		/// <para>Type: <c>UINT</c></para>
		/// <para>Identifier of the timer created by the ITextHost::TxSetTimer method.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>This method may be called at any time, whether the control is active or inactive.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost-txkilltimer void TxKillTimer( [in] UINT idTimer );
		[PreserveSig]
		new void TxKillTimer(uint idTimer);

		/// <summary>Requests the text host to scroll the content of the specified client area.</summary>
		/// <param name="dx">
		/// <para>Type: <c>INT</c></para>
		/// <para>Amount of horizontal scrolling.</para>
		/// </param>
		/// <param name="dy">
		/// <para>Type: <c>INT</c></para>
		/// <para>Amount of vertical scrolling.</para>
		/// </param>
		/// <param name="lprcScroll">
		/// <para>Type: <c>LPCRECT</c></para>
		/// <para>The coordinates for the scroll rectangle.</para>
		/// </param>
		/// <param name="lprcClip">
		/// <para>Type: <c>LPCRECT</c></para>
		/// <para>The coordinates for the clip rectangle.</para>
		/// </param>
		/// <param name="hrgnUpdate">
		/// <para>Type: <c>HRGN</c></para>
		/// <para>Handle to the update region.</para>
		/// </param>
		/// <param name="lprcUpdate">
		/// <para>Type: <c>LPRECT</c></para>
		/// <para>The coordinates for the update rectangle.</para>
		/// </param>
		/// <param name="fuScroll">
		/// <para>Type: <c>UINT</c></para>
		/// <para>Scrolling flags. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>SW_ERASE</c></description>
		/// <description>
		/// Erases the newly invalidated region by sending a WM_ERASEBKGND message to the window when specified with the SW_INVALIDATE flag.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>SW_INVALIDATE</c></description>
		/// <description>Invalidates the region identified by the <c>hrgnUpdate</c> parameter after scrolling.</description>
		/// </item>
		/// <item>
		/// <description><c>SW_SCROLLCHILDREN</c></description>
		/// <description>
		/// Scrolls all child windows that intersect the rectangle pointed to by the <c>lprcScroll</c> parameter. The child windows are
		/// scrolled by the number of pixels specified by the <c>dx</c> and <c>dy</c> parameters. The system sends a WM_MOVE message to all
		/// child windows that intersect the <c>lprcScroll</c> rectangle, even if they do not move.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>SW_SMOOTHSCROLL</c></description>
		/// <description>
		/// Scrolls using smooth scrolling. Use the HIWORD portion of the <c>fuScroll</c> parameter to indicate how much time the
		/// smooth-scrolling operation should take.
		/// </description>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>This method is only valid when the control is in-place active; calls while the control is inactive may fail.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost-txscrollwindowex void TxScrollWindowEx( [in]
		// INT dx, [in] INT dy, [in] LPCRECT lprcScroll, [in] LPCRECT lprcClip, [in] HRGN hrgnUpdate, [in] LPRECT lprcUpdate, [in] UINT
		// fuScroll );
		[PreserveSig]
		new void TxScrollWindowEx(int dx, int dy, in RECT lprcScroll, in RECT lprcClip, [In] HRGN hrgnUpdate, in RECT lprcUpdate, ScrollWindowFlags fuScroll);

		/// <summary>Sets the mouse capture in the text host's window.</summary>
		/// <param name="fCapture">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// Indicates whether to set or release the mouse capture. If <c>TRUE</c>, the mouse capture is set. If <c>FALSE</c>, the mouse
		/// capture is released.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>This method is only valid when the control is in-place active; calls while the control is inactive may do nothing.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost-txsetcapture void TxSetCapture( [in] BOOL
		// fCapture );
		[PreserveSig]
		new void TxSetCapture(bool fCapture);

		/// <summary>Sets the focus to the text host window.</summary>
		/// <returns>None</returns>
		/// <remarks>This method is only valid when the control is in-place active; calls while the control is inactive may fail.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost-txsetfocus void TxSetFocus();
		[PreserveSig]
		new void TxSetFocus();

		/// <summary>Establishes a new cursor shape (I-beam) in the text host's window.</summary>
		/// <param name="hcur">
		/// <para>Type: <c>HCURSOR</c></para>
		/// <para>Handle to the cursor.</para>
		/// </param>
		/// <param name="fText">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>If <c>TRUE</c>, indicates the caller is trying to set the text cursor. See the Remarks section for more information.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>This method may be called at any time, whether the control is active or inactive.</para>
		/// <para>
		/// <c>TxSetCursor</c> should be called by the text services object to set the mouse cursor. If the <c>fText</c> parameter is
		/// <c>TRUE</c>, the text services object is trying to set the text cursor (the cursor appears as an I-beam when it is over text that
		/// is not selected). In this case, the host can set it to whatever the control MousePointer property is. This is required for
		/// Microsoft Visual Basic compatibility since, through the MousePointer property, the Visual Basic programmer has control over the
		/// shape of the mouse cursor.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost-txsetcursor void TxSetCursor( [in] HCURSOR
		// hcur, [in] BOOL fText );
		[PreserveSig]
		new void TxSetCursor([In] HCURSOR hcur, bool fText);

		/// <summary>Converts the screen coordinates to the text host window coordinates.</summary>
		/// <param name="lppt">
		/// <para>Type: <c>LPPOINT</c></para>
		/// <para>The screen coordinates to convert.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Return <c>TRUE</c> if the call succeeds.</para>
		/// <para>Return <c>FALSE</c> if the call fails.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost-txscreentoclient BOOL TxScreenToClient( [in]
		// LPPOINT lppt );
		[PreserveSig]
		new bool TxScreenToClient(in POINT lppt);

		/// <summary>Converts text host coordinates to screen coordinates.</summary>
		/// <param name="lppt">
		/// <para>Type: <c>LPPOINT</c></para>
		/// <para>The client coordinates to convert.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Return <c>TRUE</c> if the method succeeds.</para>
		/// <para>Return <c>FALSE</c> if the method fails.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This call is valid at any time, although it is allowed to fail. In general, if the text services object needs to translate from
		/// client coordinates (for example, for the TOM GetPoint method) the text services object is visible.
		/// </para>
		/// <para>However, if no conversion is possible, then the method fails.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost-txclienttoscreen BOOL TxClientToScreen( [in]
		// LPPOINT lppt );
		[PreserveSig]
		new bool TxClientToScreen(in POINT lppt);

		/// <summary>Notifies the text host that the control is active.</summary>
		/// <param name="plOldState">
		/// <para>Type: <c>LONG*</c></para>
		/// <para>The previous activation state.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Return S_OK if the method succeeds.</para>
		/// <para>
		/// Return the following COM error code if the method fails. For more information on COM error codes, see Error Handling in COM.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>E_FAIL</c></description>
		/// <description>Activation is not possible at this time.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>It is legal for the host to refuse an activation request; for example, the control may be minimized and thus invisible.</para>
		/// <para>The caller should be able to gracefully handle failure to activate.</para>
		/// <para>No matter how many times this method is called, only one ITextHost::TxDeactivate call is necessary to deactivate the control.</para>
		/// <para>
		/// This function returns an opaque handle in <c>plOldState</c>. The caller (the text services object) should save this handle and
		/// use it in a subsequent call to ITextHost::TxDeactivate.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost-txactivate HRESULT TxActivate( LONG *plOldState );
		[PreserveSig]
		new HRESULT TxActivate(out int plOldState);

		/// <summary>Notifies the text host that the control is now inactive.</summary>
		/// <param name="lNewState">
		/// <para>Type: <c>LONG</c></para>
		/// <para>New state of the control. Typically it is the value returned by ITextHost::TxActivate.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Return S_OK if the method succeeds.</para>
		/// <para>
		/// Return the following COM error code if the method fails. For more information on COM error codes, see Error Handling in COM.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>E_FAIL</c></description>
		/// <description>Unspecified error.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// No matter how many times this method is called, only one call to ITextHost::TxActivate is necessary to activate the control.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost-txdeactivate HRESULT TxDeactivate( LONG
		// lNewState );
		[PreserveSig]
		new HRESULT TxDeactivate(int lNewState);

		/// <summary>Retrieves the client coordinates of the text host's client area.</summary>
		/// <param name="prc">
		/// <para>Type: <c>LPRECT</c></para>
		/// <para>The client coordinates of the text host's client area.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Return S_OK if the method succeeds.</para>
		/// <para>
		/// Return the following COM error code if the method fails. For more information on COM error codes, see Error Handling in COM.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>E_FAIL</c></description>
		/// <description>Unspecified error.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The client rectangle is the rectangle that the text services object is responsible for painting and managing. The host relies on
		/// the text services object for painting that area. And, the text services object must not paint or invalidate areas outside of that rectangle.
		/// </para>
		/// <para>The host forwards mouse messages to the text services object when the cursor is over the client rectangle.</para>
		/// <para>The client rectangle is expressed in client coordinates of the containing window.</para>
		/// <para><c>Important</c> Â Â The <c>ITextHost::TxGetClientRect</c> method will fail if called at an inactive time.</para>
		/// <para>Â</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost-txgetclientrect HRESULT TxGetClientRect( LPRECT
		// prc );
		[PreserveSig]
		new HRESULT TxGetClientRect(out RECT prc);

		/// <summary>Requests the dimensions of the white space inset around the text in the text host window.</summary>
		/// <param name="prc">
		/// <para>Type: <c>LPRECT</c></para>
		/// <para>
		/// The inset size, in client coordinates. The top, bottom, left, and right members of the RECT structure indicate how far in each
		/// direction the drawing should be inset.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>The return value is <c>S_OK</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The view inset is the amount of space on each side between the client rectangle and the view rectangle. The view rectangle (also
		/// called the Formatting rectangle) is the rectangle in which the text should be formatted .
		/// </para>
		/// <para>
		/// The view insets are passed in a RECT structure, but this is not really a rectangle. It should be treated as four independent
		/// values to subtract on each side of the client rectangle to figure the view rectangle.
		/// </para>
		/// <para>
		/// The view insets are passed in HIMETRIC (each HIMETRIC unit corresponds to 0.01 millimeter) so that they do not depend on the
		/// client rectangle and the rendering device context.
		/// </para>
		/// <para>
		/// View insets can be negative on either side of the client rectangle, leading to a bigger view rectangle than the client rectangle.
		/// The text should then be clipped to the client rectangle. If the view rectangle is wider than the client rectangle, then the host
		/// may add a horizontal scroll bar to the control.
		/// </para>
		/// <para>Single lineâtext services objects ignore the right boundary of the view rectangle when formatting text.</para>
		/// <para>The view inset is available from the host at all times, active or inactive.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost-txgetviewinset HRESULT TxGetViewInset( LPRECT
		// prc );
		[PreserveSig]
		new HRESULT TxGetViewInset(out RECT prc);

		/// <summary>Requests the text host's default character format.</summary>
		/// <param name="ppCF">
		/// <para>Type: <c>const CHARFORMAT**</c></para>
		/// <para>The default character format.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Return S_OK if the method succeeds.</para>
		/// <para>
		/// Return the following COM error code if the method fails. For more information on COM error codes, see Error Handling in COM.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>E_NOTIMPL</c></description>
		/// <description>Not implemented.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// The text host retains ownership of the CHARFORMAT returned. However, the pointer returned must remain valid until the text host
		/// notifies the text services object through OnTxPropertyBitsChange that the default character format has changed.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost-txgetcharformat HRESULT TxGetCharFormat( const
		// CHARFORMATW **ppCF );
		[PreserveSig]
		new HRESULT TxGetCharFormat(out IntPtr /* CHARFORMATW* */ ppCF);

		/// <summary>Requests the text host's default paragraph format.</summary>
		/// <param name="ppPF">
		/// <para>Type: <c>const PARAFORMAT**</c></para>
		/// <para>The default paragraph format.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Return S_OK if the method succeeds.</para>
		/// <para>
		/// Return the following COM error code if the method fails. For more information on COM error codes, see Error Handling in COM.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>E_NOTIMPL</c></description>
		/// <description>Not implemented.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// The host object retains ownership of the PARAFORMAT structure that is returned. However, the pointer returned must remain valid
		/// until the host notifies the text services object, through OnTxPropertyBitsChange, that the default paragraph format has changed.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost-txgetparaformat HRESULT TxGetParaFormat( const
		// PARAFORMAT **ppPF );
		[PreserveSig]
		new HRESULT TxGetParaFormat(out IntPtr /* PARAFORMAT* */ ppPF);

		/// <summary>Retrieves the text host's color for a specified display element.</summary>
		/// <param name="nIndex">
		/// <para>Type: <c>INT</c></para>
		/// <para>
		/// The display element whose color is to be retrieved. For a list of possible values for this parameter, see the GetSysColor function.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>COLORREF</c></para>
		/// <para>The value that identifies the red, green, and blue (RGB) color value of the specified element.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Note that the color returned may be <c>different</c> than the color that would be returned from a call to GetSysColor. This is
		/// the case if the host overrides the default system behavior.
		/// </para>
		/// <para>
		/// <c>Note</c> Â Â Hosts should be careful about overriding normal system behavior because it can result in inconsistent UI
		/// (particularly with respect to Accessibility options).
		/// </para>
		/// <para>Â</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost-txgetsyscolor COLORREF TxGetSysColor( [in] int
		// nIndex );
		[PreserveSig]
		new COLORREF TxGetSysColor(int nIndex);

		/// <summary>Requests the background style of the text host.</summary>
		/// <param name="pstyle">
		/// <para>Type: <c>TXTBACKSTYLE*</c></para>
		/// <para>
		/// A variable that the text host sets to indicate the background style. The style is one of the following values from the
		/// <c>TXTBACKSTYLE</c> enumeration.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>TXTBACK_TRANSPARENT</c></description>
		/// <description>Background shows through.</description>
		/// </item>
		/// <item>
		/// <description><c>TXTBACK_OPAQUE</c></description>
		/// <description>Background does not show through.</description>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>The return value is <c>S_OK</c>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost-txgetbackstyle HRESULT TxGetBackStyle(
		// TXTBACKSTYLE *pstyle );
		[PreserveSig]
		new HRESULT TxGetBackStyle(out TXTBACKSTYLE pstyle);

		/// <summary>Gets the text host's maximum allowed length for the text.</summary>
		/// <param name="plength">
		/// <para>Type: <c>DWORD*</c></para>
		/// <para>
		/// The maximum allowed text length, in number of characters. If INFINITE is returned, the text services object can use as much
		/// memory as needed to store any specified text.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>The return value is <c>S_OK</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// When this maximum is reached, the text services object should reject any further character insertion and pasted text. TxSetText
		/// however should still accept (and set) text longer than the maximum length. This is because this method is used for binding and is
		/// critical to maintaining the integrity of the data to which the control is bound.
		/// </para>
		/// <para>This method parallels the EM_LIMITTEXT message.</para>
		/// <para>
		/// If the limit returned is less than the number of characters currently in the text services object, no data is lost. Instead, no
		/// edits are allowed to the text <c>other</c> than deletion until the text is reduced to below the limit.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost-txgetmaxlength HRESULT TxGetMaxLength( DWORD
		// *plength );
		[PreserveSig]
		new HRESULT TxGetMaxLength(out uint plength);

		/// <summary>Requests information about the scroll bars supported by the text host.</summary>
		/// <param name="pdwScrollBar">
		/// <para>Type: <c>DWORD*</c></para>
		/// <para>The scroll bar. This parameter can be a combination of the following window styles related to scroll bars.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><see cref="WindowStyles.WS_VSCROLL"/></description>
		/// <description>Supports a vertical scroll bar.</description>
		/// </item>
		/// <item>
		/// <description><see cref="WindowStyles.WS_HSCROLL"/></description>
		/// <description>Supports a horizontal scroll bar.</description>
		/// </item>
		/// <item>
		/// <description><see cref="RichEditStyle.ES_AUTOVSCROLL"/></description>
		/// <description>Automatically scrolls text up one page when the user presses ENTER on the last line.</description>
		/// </item>
		/// <item>
		/// <description><see cref="RichEditStyle.ES_AUTOHSCROLL"/></description>
		/// <description>
		/// Automatically scrolls text to the right by 10 characters when the user types a character at the end of the line. When the user
		/// presses ENTER, the control scrolls all text back to position zero.
		/// </description>
		/// </item>
		/// <item>
		/// <description><see cref="RichEditStyle.ES_DISABLENOSCROLL"/></description>
		/// <description>Disables scroll bars instead of hiding them when they are not needed.</description>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>The return value is <c>S_OK</c>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost-txgetscrollbars HRESULT TxGetScrollBars( DWORD
		// *pdwScrollBar );
		[PreserveSig]
		new HRESULT TxGetScrollBars(out uint pdwScrollBar);

		/// <summary>Requests the text host's password character.</summary>
		/// <param name="pch">
		/// <para>Type: <c>TCHAR*</c></para>
		/// <para>The password character.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Return S_OK if the password character is enabled.</para>
		/// <para>
		/// Return S_FALSE if the password character is not enabled. For more information on COM error codes, see Error Handling in COM.
		/// </para>
		/// </returns>
		/// <remarks>
		/// The password character is only shown if the TXTBIT_USEPASSWORD bit is enabled in the text services object. If the password
		/// character changes, re-enable the TXTBIT_USEPASSWORD bit through OnTxPropertyBitsChange.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost-txgetpasswordchar HRESULT TxGetPasswordChar(
		// [out] TCHAR *pch );
		[PreserveSig]
		new HRESULT TxGetPasswordChar([MarshalAs(UnmanagedType.LPTStr)] out char pch);

		/// <summary>Requests the special character to use for the underlining accelerator character.</summary>
		/// <param name="pcp">
		/// <para>Type: <c>LONG*</c></para>
		/// <para>
		/// The character position of the character to underline. This variable is set by the text host. A character position of â1 (that
		/// is, negative one) indicates that no character should be underlined.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>The return value is <c>S_OK</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Accelerators allow keyboard shortcuts, or accelerator keys, to various UI elements (such as buttons). Typically, the shortcut
		/// character is underlined.
		/// </para>
		/// <para>
		/// This method tells the text services object which character is the accelerator and thus should be underlined. Note that the text
		/// services object does <c>not</c> process accelerators; that is the responsibility of the host.
		/// </para>
		/// <para>This method is typically only called if the TXTBIT_SHOWACCELERATOR bit is set in the text services object. See OnTxPropertyBitsChange.</para>
		/// <para>
		/// <c>Note</c> Â Â <c>Any</c> change to the text in the text services object results in the invalidation of the accelerator
		/// underlining. In this case, it is the host's responsibility to recalculate the appropriate character position and inform the text
		/// services object that a new accelerator is available.
		/// </para>
		/// <para>Â</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost-txgetacceleratorpos HRESULT
		// TxGetAcceleratorPos( LONG *pcp );
		[PreserveSig]
		new HRESULT TxGetAcceleratorPos(out int pcp);

		/// <summary>Requests the native size of the control in HIMETRIC.</summary>
		/// <param name="lpExtent">
		/// <para>Type: <c>LPSIZEL</c></para>
		/// <para>The size of the control in HIMETRIC, that is, where the unit is .01 millimeter.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Return S_OK if the method succeeds.</para>
		/// <para>
		/// Return the following COM error code if the method fails. For more information on COM error codes, see Error Handling in COM.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>E_NOTIMPL</c></description>
		/// <description>Not implemented.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method is used by the text services object to implement zooming. The text services object derives the zoom factor from the
		/// ratio between the himetric and device pixel extent of the client rectangle. Each HIMETRIC unit corresponds to 0.01 millimeter.
		/// </para>
		/// <para>
		/// [vertical zoom factor] = [pixel height of the client rect] * 2540 / [HIMETRIC vertical extent] * [pixel per vertical inch (from
		/// device context)]
		/// </para>
		/// <para>
		/// If the vertical and horizontal zoom factors are not the same, the text services object can ignore the horizontal zoom factor and
		/// assume it is the same as the vertical one.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost-txgetextent HRESULT TxGetExtent( LPSIZEL
		// lpExtent );
		[PreserveSig]
		new HRESULT TxGetExtent(out SIZE lpExtent);

		/// <summary>Sets the default character format for the text host.</summary>
		/// <param name="pCF">
		/// <para>Type: <c>const CHARFORMAT*</c></para>
		/// <para>The new default-character format.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Return S_OK if the method succeeds.</para>
		/// <para>
		/// Return one of the following COM error codes if the method fails. For more information on COM error codes, see Error Handling in COM.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>E_INVALIDARG</c></description>
		/// <description>One or more arguments are not valid.</description>
		/// </item>
		/// <item>
		/// <description><c>E_FAIL</c></description>
		/// <description>Unspecified error.</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost-ontxcharformatchange HRESULT
		// OnTxCharFormatChange( [in] const CHARFORMATW *pCF );
		[PreserveSig]
		new HRESULT OnTxCharFormatChange(in CHARFORMAT pCF);

		/// <summary>Sets the default paragraph format for the text host.</summary>
		/// <param name="pPF">
		/// <para>Type: <c>const PARAFORMAT*</c></para>
		/// <para>The new default paragraph format.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Return S_OK if the method succeeds.</para>
		/// <para>
		/// Return one of the following COM error codes if the method fails. For more information on COM error codes, see Error Handling in COM.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>E_INVALIDARG</c></description>
		/// <description>One or more arguments are not valid.</description>
		/// </item>
		/// <item>
		/// <description><c>E_FAIL</c></description>
		/// <description>Unspecified error.</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost-ontxparaformatchange HRESULT
		// OnTxParaFormatChange( [in] const PARAFORMAT *pPF );
		[PreserveSig]
		new HRESULT OnTxParaFormatChange(in PARAFORMAT pPF);

		/// <summary>Requests the bit property settings for the text host.</summary>
		/// <param name="dwMask">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>Mask of properties in which the caller is interested. For the possible bit values, see <c>dwBits</c> in OnTxPropertyBitsChange.</para>
		/// </param>
		/// <param name="pdwBits">
		/// <para>Type: <c>DWORD*</c></para>
		/// <para>The current settings for the properties specified by <c>dwMask</c>.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>The return value is <c>S_OK</c>.</para>
		/// </returns>
		/// <remarks>This call is valid at any time, for any combination of requested property bits.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost-txgetpropertybits HRESULT TxGetPropertyBits(
		// [in] DWORD dwMask, [in] DWORD *pdwBits );
		[PreserveSig]
		new HRESULT TxGetPropertyBits(TXTBIT dwMask, out TXTBIT pdwBits);

		/// <summary>Notifies the text host of various events.</summary>
		/// <param name="iNotify">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>Event to notify host of. One of the <c>EN_</c> notification codes.</para>
		/// </param>
		/// <param name="pv">
		/// <para>Type: <c>void*</c></para>
		/// <para>Extra data, dependent on <c>iNotify</c>.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Return S_OK if the method succeeds.</para>
		/// <para>Return S_FALSE if the method fails. For more information on COM error codes, see Error Handling in COM.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Note that there are two basic categories of events, <c>direct</c> and <c>delayed</c> . Direct events are sent immediately because
		/// they need some processing, for example, EN_PROTECTED. Delayed events are sent after all processing has occurred; the control is
		/// thus in a stable state. Examples of delayed notifications are EN_CHANGE, EN_ERRSPACE, and EN_SELCHANGE.
		/// </para>
		/// <para>
		/// The notification events are the same as the notification codes sent to the parent window of a rich edit window. The firing of
		/// events may be controlled with a mask set through the EM_SETEVENTMASK message.
		/// </para>
		/// <para>
		/// In general, it is legal to make calls to the text services object while processing this method; however, implementers are
		/// cautioned to avoid excessive recursion.
		/// </para>
		/// <para>The following is a list of the notifications that may be sent.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Notification</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description>EN_CHANGE</description>
		/// <description>
		/// Sent after the system updates the screen, when the user takes an action that may have altered text in the control.
		/// </description>
		/// </item>
		/// <item>
		/// <description>EN_DROPFILES</description>
		/// <description>Sent when either a WM_DROPFILES message or an IDropTarget::DragEnter notification is received.</description>
		/// </item>
		/// <item>
		/// <description>EN_ERRSPACE</description>
		/// <description>Sent when a control cannot allocate enough memory to meet a specified request.</description>
		/// </item>
		/// <item>
		/// <description>EN_HSCROLL</description>
		/// <description>Sent when the user clicks the control's horizontal scroll bar before the screen is updated.</description>
		/// </item>
		/// <item>
		/// <description>EN_KILLFOCUS</description>
		/// <description>Sent when the control loses the keyboard focus.</description>
		/// </item>
		/// <item>
		/// <description>EN_LINK</description>
		/// <description>
		/// Sent when a rich edit control receives various messages, such as mouse click messages, when the mouse pointer is over text that
		/// has the CFE_LINK effect.
		/// </description>
		/// </item>
		/// <item>
		/// <description>EN_MAXTEXT</description>
		/// <description>Sent when the current text insertion has exceeded the maximum number of characters for the control.</description>
		/// </item>
		/// <item>
		/// <description>EN_OLEOPFAILED</description>
		/// <description>Sent when a user action on an OLE object has failed.</description>
		/// </item>
		/// <item>
		/// <description>EN_PROTECTED</description>
		/// <description>Sent when the user takes an action that changes the protected range of text.</description>
		/// </item>
		/// <item>
		/// <description>EN_REQUESTRESIZE</description>
		/// <description>Sent when a rich edit control's contents are different from the control's window size.</description>
		/// </item>
		/// <item>
		/// <description>EN_SAVECLIPBOARD</description>
		/// <description>
		/// Sent when an edit control is being destroyed. The text host should indicate whether OleFlushClipboard should be called. Data
		/// indicating the number of characters and objects to be flushed is sent in the ENSAVECLIPBOARD data structure. Mask value is nothing.
		/// </description>
		/// </item>
		/// <item>
		/// <description>EN_SELCHANGE</description>
		/// <description>
		/// Sent when the current selection has changed. A SELCHANGE data structure is also sent, which indicates the new selection range at
		/// the type of data the selection is currently over. Controlled through the ENM_SELCHANGE mask.
		/// </description>
		/// </item>
		/// <item>
		/// <description>EN_SETFOCUS</description>
		/// <description>Sent when the edit control receives the keyboard focus. No extra data is sent; there is no mask.</description>
		/// </item>
		/// <item>
		/// <description>EN_STOPNOUNDO</description>
		/// <description>
		/// Sent when an action occurs for which the control cannot allocate enough memory to maintain the undo state. If S_FALSE is
		/// returned, the action will be stopped; otherwise, the action will continue.
		/// </description>
		/// </item>
		/// <item>
		/// <description>EN_UPDATE</description>
		/// <description>
		/// Sent before an edit control requests a redraw of altered data or text. No additional data is sent. This event is controlled
		/// through the ENM_UPDATE mask. <c>Rich Edit 2.0 and later:</c> The ENM_UPDATE mask is ignored and the EN_UPDATE notification code
		/// is always sent. However, when Microsoft Rich EditÂ 3.0 emulates Microsoft Rich EditÂ 1.0, the <c>ENM_UPDATE</c> mask controls
		/// this notification.
		/// </description>
		/// </item>
		/// <item>
		/// <description>EN_VSCROLL</description>
		/// <description>
		/// Sent when the user clicks an edit control's vertical scroll bar or when the user scrolls the mouse wheel over the edit control,
		/// before the screen is updated. This is controlled through the ENM_SCROLL mask; no extra data is sent.
		/// </description>
		/// </item>
		/// </list>
		/// <para>Â</para>
		/// <para><c>Note</c> Â Â The EN_MSGFILTER is not sent to <c>TxNotify</c>. To filter window messages, use TxSendMessage.</para>
		/// <para>Â</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost-txnotify HRESULT TxNotify( [in] DWORD iNotify,
		// [in] void *pv );
		[PreserveSig]
		new HRESULT TxNotify(EditNotification iNotify, IntPtr pv);

		/// <summary>
		/// <para>Retrieves the Input Method Editor (IME) input context associated with the text services host.</para>
		/// <para>This method is used only in Asian-language versions of the operating system.</para>
		/// </summary>
		/// <returns>
		/// <para>Type: <c>HIMC</c></para>
		/// <para>The handle to the input context.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost-tximmgetcontext HIMC TxImmGetContext();
		[PreserveSig]
		new HIMC TxImmGetContext();

		/// <summary>
		/// <para>
		/// Releases an input context returned by the ITextHost::TxImmGetContext method and unlocks the memory associated with the context.
		/// </para>
		/// <para>This method is used only in Asian-language versions of the operating system.</para>
		/// </summary>
		/// <param name="himc">
		/// <para>Type: <c>HIMC</c></para>
		/// <para>The input context.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost-tximmreleasecontext void TxImmReleaseContext(
		// [in] HIMC himc );
		[PreserveSig]
		new void TxImmReleaseContext([In] HIMC himc);

		/// <summary>Returns the size of selection bar in HIMETRIC.</summary>
		/// <param name="lSelBarWidth">
		/// <para>Type: <c>LONG*</c></para>
		/// <para>The width, in HIMETRIC (that is, where the units are .01 millimeter), of the selection bar.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>The return value is <c>S_OK</c>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost-txgetselectionbarwidth HRESULT
		// TxGetSelectionBarWidth( LONG *lSelBarWidth );
		[PreserveSig]
		new HRESULT TxGetSelectionBarWidth(out int lSelBarWidth);

		/// <summary>Discovers whether the message queue contains a WM_LBUTTONDBLCLK message that is pending for the text host window.</summary>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Returns <c>TRUE</c> if a WM_LBUTTONDBLCLK message is pending, or <c>FALSE</c> if not.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost2-txisdoubleclickpending BOOL TxIsDoubleClickPending();
		[PreserveSig]
		bool TxIsDoubleClickPending();

		/// <summary>Retrieves the handle of the text host window for the rich edit control.</summary>
		/// <param name="phwnd">
		/// <para>Type: <c>HWND*</c></para>
		/// <para>The handle of the text host window.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost2-txgetwindow HRESULT TxGetWindow( HWND *phwnd );
		[PreserveSig]
		HRESULT TxGetWindow(out HWND phwnd);

		/// <summary>Sets the rich edit control's host window as the foreground window.</summary>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost2-txsetforegroundwindow HRESULT TxSetForegroundWindow();
		[PreserveSig]
		HRESULT TxSetForegroundWindow();

		/// <summary>Retrieves the color palette of the rich edit control.</summary>
		/// <returns>
		/// <para>Type: <c>HPALETTE</c></para>
		/// <para>Returns the color palette, or <c>NULL</c> if the control uses the system default color palette.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost2-txgetpalette HPALETTE TxGetPalette();
		[PreserveSig]
		HPALETTE TxGetPalette();

		/// <summary>Gets whether Input Method Editor (IME) input is allowed and whether the edit styles include ES_SELFIME.</summary>
		/// <param name="pFlags">
		/// <para>Type: <c>LONG*</c></para>
		/// <para>The East Asian flags.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>ES_NOIME</c></description>
		/// <description>IME input is suppressed.</description>
		/// </item>
		/// <item>
		/// <description><c>ES_SELFIME</c></description>
		/// <description>The rich edit client handles IME input.</description>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost2-txgeteastasianflags HRESULT
		// TxGetEastAsianFlags( LONG *pFlags );
		[PreserveSig]
		HRESULT TxGetEastAsianFlags(out RichEditStyle pFlags);

		/// <summary>Sets the shape of the cursor in the text host window.</summary>
		/// <param name="hcur">
		/// <para>Type: <c>HCURSOR</c></para>
		/// <para>The new cursor shape.</para>
		/// </param>
		/// <param name="bText">
		/// <para>Type: <c>BOOL</c></para>
		/// <para><c>TRUE</c> if the cursor is used for text, or <c>FALSE</c> if not.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HCURSOR</c></para>
		/// <para>Returns the cursor that <c>hcur</c> is replacing.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost2-txsetcursor2 HCURSOR TxSetCursor2( HCURSOR
		// hcur, BOOL bText );
		[PreserveSig]
		HCURSOR TxSetCursor2(HCURSOR hcur, bool bText);

		/// <summary>Notifies the text host that text services have been freed.</summary>
		/// <returns>None</returns>
		/// <remarks>
		/// If the text host hasn't received this notification when the text host is shutting down, the text host can tell text services to
		/// release its text host reference count.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost2-txfreetextservicesnotification void TxFreeTextServicesNotification();
		[PreserveSig]
		void TxFreeTextServicesNotification();

		/// <summary>Gets whether a rich edit control is in a dialog box.</summary>
		/// <param name="dwItem">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>Mask that indicates the edit style flags to retrieve. It can be the following value.</para>
		/// <para>TXES_ISDIALOG</para>
		/// </param>
		/// <param name="pdwData">
		/// <para>Type: <c>DWORD*</c></para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>TXES_ISDIALOG</c></description>
		/// <description>Indicates that the host of the rich edit control is a dialog box.</description>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost2-txgeteditstyle HRESULT TxGetEditStyle( DWORD
		// dwItem, DWORD *pdwData );
		[PreserveSig]
		HRESULT TxGetEditStyle(TXES dwItem, out TXES pdwData);

		/// <summary>Retrieves the window styles and extended windows styles of the text host window.</summary>
		/// <param name="pdwStyle">
		/// <para>Type: <c>DWORD*</c></para>
		/// <para>The window styles. For a description of the possible values, see Window Styles.</para>
		/// </param>
		/// <param name="pdwExStyle">
		/// <para>Type: <c>DWORD*</c></para>
		/// <para>The extended windows styles. For a description of the possible values, see Extended Window Styles.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost2-txgetwindowstyles HRESULT TxGetWindowStyles(
		// DWORD *pdwStyle, DWORD *pdwExStyle );
		[PreserveSig]
		HRESULT TxGetWindowStyles(out WindowStyles pdwStyle, out WindowStylesEx pdwExStyle);

		/// <summary>Shows or hides the caret during the drop portion of a drag-and-drop operation (Direct2D only).</summary>
		/// <param name="fShow">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Show or hide flag. <c>TRUE</c> shows the drop caret, and <c>FALSE</c> hides it.</para>
		/// </param>
		/// <param name="hdc">
		/// <para>Type: <c>HDC</c></para>
		/// <para>The HDC.</para>
		/// </param>
		/// <param name="prc">
		/// <para>Type: <c>LPCRECT</c></para>
		/// <para>The drop caret rectangle.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost2-txshowdropcaret HRESULT TxShowDropCaret( BOOL
		// fShow, HDC hdc, LPCRECT prc );
		[PreserveSig]
		HRESULT TxShowDropCaret(bool fShow, HDC hdc, in RECT prc);

		/// <summary>Destroys the caret (Direct2D only).</summary>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost2-txdestroycaret HRESULT TxDestroyCaret();
		[PreserveSig]
		HRESULT TxDestroyCaret();

		/// <summary>Gets the horizontal scroll extent of the text host window.</summary>
		/// <param name="plHorzExtent">
		/// <para>Type: <c>LONG*</c></para>
		/// <para>The horizontal scroll extent.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>A rich edit control doesn't use the return value; instead, they get the scroll width from the widest line.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itexthost2-txgethorzextent HRESULT TxGetHorzExtent( LONG
		// *plHorzExtent );
		[PreserveSig]
		HRESULT TxGetHorzExtent(out int plHorzExtent);
	}

	/// <summary>Extends the Text Object Model (TOM) to provide extra functionality for windowless operation.</summary>
	/// <remarks>
	/// <para>
	/// In conjunction with the ITextHost interface, <c>ITextServices</c> provides the means by which a rich edit control can be used
	/// <c>without</c> creating a window.
	/// </para>
	/// <para>When to Implement</para>
	/// <para>Applications do not implement the <c>ITextServices</c> interface.</para>
	/// <para>When to Use</para>
	/// <para>
	/// Applications can call the CreateTextServices function to create a text services object. To retrieve an <c>ITextServices</c> pointer,
	/// call QueryInterface on the private IUnknown pointer returned by <c>CreateTextServices</c>. You can then call the <c>ITextServices</c>
	/// methods to send messages to the text services object.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nl-textserv-itextservices
	[PInvokeData("textserv.h", MSDNShortId = "NL:textserv.ITextServices")]
	[ComVisible(true), Guid("8D33F740-CF58-11CE-A89D-00AA006CADC5"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ITextServices
	{
		/// <summary>Used by the window host to forward messages sent from its window to the text services object.</summary>
		/// <param name="msg">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The message identifier.</para>
		/// </param>
		/// <param name="wparam">
		/// <para>Type: <c>WPARAM</c></para>
		/// <para>The <c>WPARAM</c> from the window's message.</para>
		/// </param>
		/// <param name="lparam">
		/// <para>Type: <c>LPARAM</c></para>
		/// <para>The <c>LPARAM</c> from the window's message.</para>
		/// </param>
		/// <param name="plresult">
		/// <para>Type: <c>LRESULT*</c></para>
		/// <para>The message's return <c>LRESULT</c>.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If the method succeeds, the return value is <c>S_OK</c>.</para>
		/// <para>
		/// If the method fails, the return value is one of the following <c>HRESULT</c> codes. For more information on COM error codes, see
		/// Error Handling in COM.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>E_OUTOFMEMORY</c></description>
		/// <description>Insufficient memory. NOERROR Message was processed, and some action was taken.</description>
		/// </item>
		/// <item>
		/// <description><c>S_FALSE</c></description>
		/// <description>
		/// Message was not processed. Typically indicates that the caller should process the message itself, potentially by calling DefWindowProc.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>S_MSG_KEYIGNORED</c></description>
		/// <description>Message processed, but no action was taken for the keystroke.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Note that two return values are passed back from this function. The return value that should be passed back from a window
		/// procedure is <c>plresult</c>. However, in some cases, the returned <c>LRESULT</c> does not contain enough information. For
		/// example, to implement moving the cursor around controls, it's useful to know if a keystroke (such as right arrow) was processed
		/// but ignored (for example, the caret is already at the rightmost position in the text). In these cases, more information may be
		/// returned through the returned <c>HRESULT</c>.
		/// </para>
		/// <para>
		/// WM_CHAR and WM_KEYDOWN should return the value S_MSG_KEYIGNORED when a key or character is recognized, but has no effect, given
		/// the current state. For example, S_MSG_KEYIGNORED should be returned in the following cases:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// Any keystroke that tries to move the insertion point to or beyond the beginning or the end of the document; when it is already at
		/// the beginning or end of the document, respectively.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// Any keystroke that tries to move the insertion point to or past the next line when it is already on the last line; or to or
		/// before the previous line when it is already on the first line.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// Any insertion of the character from WM_CHAR that would move the insertion point past the maximum length of the control.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itextservices-txsendmessage HRESULT TxSendMessage( UINT
		// msg, WPARAM wparam, LPARAM lparam, LRESULT *plresult );
		[PreserveSig]
		HRESULT TxSendMessage(uint msg, IntPtr wparam, IntPtr lparam, out IntPtr plresult);

		/// <summary>Draws the text services object.</summary>
		/// <param name="dwDrawAspect">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// Specifies the aspect to be drawn, that is, how the object is to be represented. Draw aspect can be one of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>DVASPECT_CONTENT</c></description>
		/// <description>
		/// Renders a screen image of the text content to the <c>hdcDraw</c> device context. The <c>hicTargetDev</c> and <c>ptd</c>
		/// parameters give information on the target device context if any (usually a printer).
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>DVASPECT_DOCPRINT</c></description>
		/// <description>
		/// Renders the object to the <c>hdcDraw</c> device context as though it were printed to a printer. Thus, the text services object
		/// can optimize for the printer (for example, not painting the background color, if white). Also, certain screen-specific elements
		/// (such as the selection) should not be rendered. <c>ITextServices::TxDraw</c> should render the <c>lprcBounds</c> rectangle,
		/// starting at the current scrolling position.
		/// </description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="lindex">
		/// <para>Type: <c>LONG</c></para>
		/// <para>Not supported.</para>
		/// </param>
		/// <param name="pvAspect">
		/// <para>Type: <c>void*</c></para>
		/// <para>Information for drawing optimizations.</para>
		/// </param>
		/// <param name="ptd">
		/// <para>Type: <c>DVTARGETDEVICE*</c></para>
		/// <para>The target device.</para>
		/// </param>
		/// <param name="hdcDraw">
		/// <para>Type: <c>HDC</c></para>
		/// <para>Rendering device context.</para>
		/// </param>
		/// <param name="hicTargetDev">
		/// <para>Type: <c>HDC</c></para>
		/// <para>Target information context.</para>
		/// </param>
		/// <param name="lprcBounds">
		/// <para>Type: <c>LPCRECTL</c></para>
		/// <para>The bounding (client) rectangle.</para>
		/// </param>
		/// <param name="lprcWBounds">
		/// <para>Type: <c>LPCRECTL</c></para>
		/// <para>The clipping rectangle for metafiles.</para>
		/// </param>
		/// <param name="lprcUpdate">
		/// <para>Type: <c>LPRECT</c></para>
		/// <para>The update region inside <c>lprcBounds</c>.</para>
		/// </param>
		/// <param name="pfnContinue">
		/// <para>Type: <c>BOOL CALLBACK*</c></para>
		/// <para>Not supported.</para>
		/// </param>
		/// <param name="dwContinue">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>Parameter to pass to continue function.</para>
		/// </param>
		/// <param name="lViewId">
		/// <para>Type: <c>LONG</c></para>
		/// <para>Specifies the view to draw.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>TXTVIEW_ACTIVE</c></description>
		/// <description>Draw the inplace active view.</description>
		/// </item>
		/// <item>
		/// <description><c>TXTVIEW_INACTIVE</c></description>
		/// <description>Draw a view other than the inplace active view; for example, a print preview.</description>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>The return value is typically <c>S_OK</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method renders the text services object. It accepts the same parameters as the corresponding IViewObject::Draw method in
		/// OLE, with the extra <c>lprcUpdate</c> and the <c>lViewId</c> parameters. It can be used while the host is in-place active or inactive.
		/// </para>
		/// <para>
		/// The <c>lprcBounds</c> parameter gives the rectangle to render, also called the client rectangle. This rectangle represents the
		/// position and extent of the entire image of the text services object to be drawn. It is expressed in the logical coordinate system
		/// of <c>hdcDraw</c>. If <c>lprcBounds</c> is <c>NULL</c> then the control must be active. In this case, the text services object
		/// should render the in-place active view (that is, the client rectangle that can be obtained by calling TxGetClientRect on the host).
		/// </para>
		/// <para>
		/// If the <c>lprcUpdate</c> parameter is not <c>NULL</c>, it gives the rectangle to update inside that client rectangle, in the
		/// logical coordinate system of <c>hdcDraw</c>. If <c>lprcUpdate</c> is <c>NULL</c>, the entire client rectangle should be painted.
		/// </para>
		/// <para>
		/// The text services object should render with the appropriate zoom factor, which can be obtained from the client rectangle and the
		/// native size given by TxGetExtent. For a discussion of the zoom factor, see <c>TxGetExtent</c>.
		/// </para>
		/// <para>General comments on OLE hosts and <c>ITextServices::TxDraw</c> (also for ITextServices::OnTxSetCursor, and ITextServices::TxQueryHitPoint):</para>
		/// <para>
		/// An OLE host can call the <c>ITextServices::TxDraw</c> method at any time with any rendering device context or client rectangle.
		/// An OLE object that is inactive only retains an extent. To get the rectangle in which to render, the host calls the
		/// IViewObject::Draw method. This rectangle is valid only for the scope of that method. Thus, the same control can be rendered
		/// consecutively in different rectangles and different device contexts, for example, because it is displayed simultaneously in
		/// different views on the screen.
		/// </para>
		/// <para>
		/// Normally, the client rectangle and device context passed to <c>ITextServices::TxDraw</c> should not be cached, because this would
		/// force the text services object to recalculate lines for every draw, which would impede performance. Instead, the text services
		/// object could cache the information that is computed for a specific client rectangle and device context (such as line breaks). On
		/// the next call to <c>ITextServices::TxDraw</c>, however, the validity of the cached information should be checked before it gets
		/// used, and updated information should be regenerated, if necessary.
		/// </para>
		/// <para>
		/// Also, take great care when the control is in-place active. This problem is even more complex since <c>ITextServices::TxDraw</c>
		/// can still be called to render other views than the one that is in-place active. In other words, the client rectangle passed to
		/// <c>ITextServices::TxDraw</c> may not be the same as the active one (passed to ITextServices::OnTxInPlaceActivate and obtained
		/// through TxGetClientRect on the host).
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itextservices-txdraw HRESULT TxDraw( [in] DWORD
		// dwDrawAspect, LONG lindex, [in] void *pvAspect, [in] DVTARGETDEVICE *ptd, [in] HDC hdcDraw, [in] HDC hicTargetDev, [in] LPCRECTL
		// lprcBounds, [in] LPCRECTL lprcWBounds, [in] LPRECT lprcUpdate, BOOL(* )(DWORD) pfnContinue, DWORD dwContinue, LONG lViewId );
		[PreserveSig]
		HRESULT TxDraw(DVASPECT dwDrawAspect, int lindex, IntPtr pvAspect, [In] DVTARGETDEVICE ptd, [In] HDC hdcDraw, [In] HDC hicTargetDev, in RECT lprcBounds,
			in RECT lprcWBounds, in RECT lprcUpdate, IntPtr pfnContinue, uint dwContinue, TXTVIEW lViewId);

		/// <summary>Returns horizontal scroll bar information.</summary>
		/// <param name="plMin">
		/// <para>Type: <c>LONG*</c></para>
		/// <para>The minimum scroll position.</para>
		/// </param>
		/// <param name="plMax">
		/// <para>Type: <c>LONG*</c></para>
		/// <para>The maximum scroll position.</para>
		/// </param>
		/// <param name="plPos">
		/// <para>Type: <c>LONG*</c></para>
		/// <para>The current scroll position.</para>
		/// </param>
		/// <param name="plPage">
		/// <para>Type: <c>LONG*</c></para>
		/// <para>The view width, in pixels.</para>
		/// </param>
		/// <param name="pfEnabled">
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>Indicates whether horizontal scrolling is enabled. If <c>TRUE</c>, horizontal scrolling is enabled.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>The method always returns <c>S_OK</c>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itextservices-txgethscroll HRESULT TxGetHScroll( LONG
		// *plMin, LONG *plMax, LONG *plPos, LONG *plPage, BOOL *pfEnabled );
		[PreserveSig]
		HRESULT TxGetHScroll(out int plMin, out int plMax, out int plPos, out int plPage, out bool pfEnabled);

		/// <summary>Returns vertical scroll bar state information.</summary>
		/// <param name="plMin">
		/// <para>Type: <c>LONG*</c></para>
		/// <para>The minimum scroll position.</para>
		/// </param>
		/// <param name="plMax">
		/// <para>Type: <c>LONG*</c></para>
		/// <para>The maximum scroll position.</para>
		/// </param>
		/// <param name="plPos">
		/// <para>Type: <c>LONG*</c></para>
		/// <para>The current scroll position.</para>
		/// </param>
		/// <param name="plPage">
		/// <para>Type: <c>LONG*</c></para>
		/// <para>The height of view in pixels.</para>
		/// </param>
		/// <param name="pfEnabled">
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>
		/// Indicates whether the vertical scroll bar is enabled. If <c>TRUE</c>, the vertical scroll bar is enabled; otherwise it is disabled.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If the method succeeds, the return value is <c>S_OK</c>.</para>
		/// <para>
		/// If the method fails, the return value is one of the following <c>HRESULT</c> codes. For more information on COM error codes, see
		/// Error Handling in COM.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>E_FAIL</c></description>
		/// <description>Unspecified error.</description>
		/// </item>
		/// <item>
		/// <description><c>E_INVALIDARG</c></description>
		/// <description>One or more arguments are not valid.</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itextservices-txgetvscroll HRESULT TxGetVScroll( LONG
		// *plMin, LONG *plMax, LONG *plPos, LONG *plPage, BOOL *pfEnabled );
		[PreserveSig]
		HRESULT TxGetVScroll(out int plMin, out int plMax, out int plPos, out int plPage, out bool pfEnabled);

		/// <summary>Notifies the text services object to set the cursor.</summary>
		/// <param name="dwDrawAspect">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>Draw aspect can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>DVASPECT_CONTENT</c></description>
		/// <description>
		/// Renders a screen image of the text content to the <c>hdcDraw</c> device context. The <c>hicTargetDev</c> and <c>ptd</c>
		/// parameters give information on the target device context if any (usually a printer).
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>DVASPECT_DOCPRINT</c></description>
		/// <description>
		/// Renders the object to the <c>hdcDraw</c> device context as though it were printed to a printer. Thus, the text services object
		/// can optimize for the printer (for example, not painting the background color, if white). Also, certain screen-specific elements
		/// (such as the selection) should not be rendered. <c>ITextServices::OnTxSetCursor</c> should render the <c>lprcClient</c>
		/// rectangle, starting at the current scrolling position.
		/// </description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="lindex">
		/// <para>Type: <c>LONG</c></para>
		/// <para>Not supported.</para>
		/// </param>
		/// <param name="pvAspect">
		/// <para>Type: <c>void*</c></para>
		/// <para>Information for drawing optimizations.</para>
		/// </param>
		/// <param name="ptd">
		/// <para>Type: <c>DVTARGETDEVICE*</c></para>
		/// <para>The target device.</para>
		/// </param>
		/// <param name="hdcDraw">
		/// <para>Type: <c>HDC</c></para>
		/// <para>Rendering device context.</para>
		/// </param>
		/// <param name="hicTargetDev">
		/// <para>Type: <c>HDC</c></para>
		/// <para>Target information context.</para>
		/// </param>
		/// <param name="lprcClient">
		/// <para>Type: <c>LPCRECT</c></para>
		/// <para>
		/// The control's client rectangle. The coordinates of the rectangle are in client coordinates of the containing window. <c>NULL</c>
		/// is a legal value.
		/// </para>
		/// </param>
		/// <param name="x">
		/// <para>Type: <c>INT</c></para>
		/// <para>x position of cursor, in the client coordinates of the containing window.</para>
		/// </param>
		/// <param name="y">
		/// <para>Type: <c>INT</c></para>
		/// <para>y position of cursor, in the client coordinates of the containing window.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If the method succeeds, the return value is <c>S_OK</c>.</para>
		/// <para>
		/// If the method fails, the return value is the following <c>HRESULT</c> code. For more information on COM error codes, see Error
		/// Handling in COM.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>E_INVALIDARG</c></description>
		/// <description>One or more illegal parameters.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The text services object may remeasure as a result of this call to determine the correct cursor. The correct cursor is set
		/// through TxSetCursor.
		/// </para>
		/// <para>
		/// The <c>lprcClient</c> parameter is the client rectangle of the view of the control over which the mouse cursor is positioned. The
		/// <c>lprcClient</c> parameter is in device coordinates of the containing window in the same way the WM_SIZE message is. This may
		/// not be the view that was rendered last. Furthermore, if the control is in-place active, this may not be the current active view .
		/// As a consequence, the text services object should check this rectangle against its current cache's value and determine whether
		/// recalculating the lines is necessary or not. The zoom factor should be included in this computation. For a discussion of the zoom
		/// factor, see TxGetExtent.
		/// </para>
		/// <para>
		/// This method should be called only for screen views of the control. Therefore the device context (DC) is not passed in, but should
		/// be assumed to be a screen DC.
		/// </para>
		/// <para>For more information, see the Remarks in ITextServices::TxDraw.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itextservices-ontxsetcursor HRESULT OnTxSetCursor( [in]
		// DWORD dwDrawAspect, LONG lindex, [in] void *pvAspect, [in] DVTARGETDEVICE *ptd, [in] HDC hdcDraw, [in] HDC hicTargetDev, [in]
		// LPCRECT lprcClient, [in] INT x, [in] INT y );
		[PreserveSig]
		HRESULT OnTxSetCursor(uint dwDrawAspect, int lindex, [In] IntPtr pvAspect, [In] DVTARGETDEVICE ptd, [In] HDC hdcDraw, [In] HDC hicTargetDev, in RECT lprcClient, int x, int y);

		/// <summary>Tests whether a specified point is within the rectangle of the text services object.</summary>
		/// <param name="dwDrawAspect">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>Draw aspect can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>DVASPECT_CONTENT</c></description>
		/// <description>
		/// Renders a screen image of the text content to the <c>hdcDraw</c> device context. The <c>hicTargetDev</c> and <c>ptd</c>
		/// parameters give information on the target device context if any (usually a printer).
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>DVASPECT_DOCPRINT</c></description>
		/// <description>
		/// Renders the object to the <c>hdcDraw</c> device context as though it were printed to a printer. Thus, the text services object
		/// can optimize for the printer (for example, not painting the background color, if white). Also, certain screen-specific elements
		/// (such as the selection) should not be rendered. ITextServices::TxGetNaturalSize should render the <c>lprcClient</c> rectangle,
		/// starting at the current scrolling position.
		/// </description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="lindex">
		/// <para>Type: <c>LONG</c></para>
		/// <para>Not supported.</para>
		/// </param>
		/// <param name="pvAspect">
		/// <para>Type: <c>void*</c></para>
		/// <para>Information for drawing optimizations.</para>
		/// </param>
		/// <param name="ptd">
		/// <para>Type: <c>DVTARGETDEVICE*</c></para>
		/// <para>Information on the target device.</para>
		/// </param>
		/// <param name="hdcDraw">
		/// <para>Type: <c>HDC</c></para>
		/// <para>Rendering device context.</para>
		/// </param>
		/// <param name="hicTargetDev">
		/// <para>Type: <c>HDC</c></para>
		/// <para>Target information context.</para>
		/// </param>
		/// <param name="lprcClient">
		/// <para>Type: <c>LPCRECT</c></para>
		/// <para>The control's client rectangle, in client (device) coordinates of the view in which the hit testing is done.</para>
		/// </param>
		/// <param name="x">
		/// <para>Type: <c>INT</c></para>
		/// <para>x-coordinate to check, in client coordinates, of the view in which hit testing is done.</para>
		/// </param>
		/// <param name="y">
		/// <para>Type: <c>INT</c></para>
		/// <para>y-coordinate to check, in client coordinates, of the view in which hit testing is done.</para>
		/// </param>
		/// <param name="pHitResult">
		/// <para>Type: <c>DWORD*</c></para>
		/// <para>The result of the hit test. It can be any of the following <c>TXTHITRESULT</c> enumeration values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>TXTHITRESULT_CLOSE</c></description>
		/// <description>The point is in the client rectangle and close to a nontransparent area.</description>
		/// </item>
		/// <item>
		/// <description><c>TXTHITRESULT_HIT</c></description>
		/// <description>The point is in the client rectangle and either over text or the background is not transparent.</description>
		/// </item>
		/// <item>
		/// <description><c>TXTHITRESULT_NOHIT</c></description>
		/// <description>The point is outside of the client rectangle.</description>
		/// </item>
		/// <item>
		/// <description><c>TXTHITRESULT_TRANSPARENT</c></description>
		/// <description>The point is in the client rectangle and either not over text or the background was transparent.</description>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>The return value is an <c>HRESULT</c> code.</para>
		/// </returns>
		/// <remarks>
		/// <para>This method allows the host to implement transparent hit testing on text.</para>
		/// <para>For more information, see the Remarks section in ITextServices::TxDraw and ITextServices::OnTxSetCursor.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itextservices-txqueryhitpoint HRESULT TxQueryHitPoint(
		// [in] DWORD dwDrawAspect, LONG lindex, [in] void *pvAspect, [in] DVTARGETDEVICE *ptd, [in] HDC hdcDraw, [in] HDC hicTargetDev, [in]
		// LPCRECT lprcClient, [in] INT x, [in] INT y, [out] DWORD *pHitResult );
		[PreserveSig]
		HRESULT TxQueryHitPoint(DVASPECT dwDrawAspect, int lindex, [In] IntPtr pvAspect, [In] DVTARGETDEVICE ptd, [In] HDC hdcDraw,
			[In] HDC hicTargetDev, in RECT lprcClient, int x, int y, out uint pHitResult);

		/// <summary>Notifies the text services object that this control is in-place active.</summary>
		/// <param name="prcClient">
		/// <para>Type: <c>const RECT*</c></para>
		/// <para>The control's client rectangle.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If the object is successfully activated, the return value is <c>S_OK</c>.</para>
		/// <para>
		/// If the object could not be activated due to error, the return value is E_FAIL. For more information on COM error codes, see Error
		/// Handling in COM.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// In-place active means that an embedded object is <c>running in-place</c> (for example, for regular controls and embeddings, it
		/// would have a window to draw in). In contrast, UI active means that an object currently has the <c>editing focus</c>. For example,
		/// things like menus and toolbars on the container may also contain elements from the UI-active control/embedding. There is only one
		/// UI-active control at any given time, while there can be many in-place active controls.
		/// </para>
		/// <para>
		/// Note, UI activation is different from getting the focus. To signal the text services object that the control is getting or losing
		/// focus, the host sends WM_SETFOCUS and WM_KILLFOCUS messages. Also, note that a windowless host will pass <c>NULL</c> as the
		/// <c>wParam</c> (window that lost the focus) for these messages.
		/// </para>
		/// <para>
		/// When making the transition directly from a nonactive state to the UI-active state, the host should call
		/// <c>ITextServices::OnTxInPlaceActivate</c> first and then ITextServices::OnTxUIActivate.
		/// </para>
		/// <para>
		/// <c>ITextServices::OnTxInPlaceActivate</c> takes as a parameter the client rectangle of the view being activated. This rectangle
		/// is given in client coordinates of the containing window. It is the same as would be obtained by calling TxGetClientRect on the host.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itextservices-ontxinplaceactivate HRESULT
		// OnTxInPlaceActivate( [in] LPCRECT prcClient );
		[PreserveSig]
		HRESULT OnTxInPlaceActivate(in RECT prcClient);

		/// <summary>Notifies the text services object that this control is no longer in-place active.</summary>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>The return value is always <c>S_OK</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// In-place activation refers to an embedded object <c>running in-place</c> (for example, for regular controls and embeddings, it
		/// would have a window to draw in). In contrast, UI active means that an object currently has the <c>editing focus</c>.
		/// Specifically, things like menus and toolbars on the container may also contain elements from the UI-active control/embedding.
		/// There can only be one UI-active control at any given time, while many can be in-place active at once.
		/// </para>
		/// <para>
		/// Note, UI activation is different from getting the focus. To let the text services object know that the control is getting or
		/// losing focus, the host will send WM_SETFOCUS and WM_KILLFOCUS messages. Also, note that a windowless host will pass <c>NULL</c>
		/// as the <c>wParam</c> (window that lost the focus) for these messages.
		/// </para>
		/// <para>
		/// When making the transition from the UI-active state to a nonactive state, the host should call ITextServices::OnTxUIDeactivate
		/// first and then <c>ITextServices::OnTxInPlaceDeactivate</c>.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itextservices-ontxinplacedeactivate HRESULT OnTxInPlaceDeactivate();
		[PreserveSig]
		HRESULT OnTxInPlaceDeactivate();

		/// <summary>Informs the text services object that the control is now UI active.</summary>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>The method always returns <c>S_OK</c>.</para>
		/// </returns>
		/// <remarks>See ITextServices::OnTxInPlaceActivate for a detailed description of activation.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itextservices-ontxuiactivate HRESULT OnTxUIActivate();
		[PreserveSig]
		HRESULT OnTxUIActivate();

		/// <summary>Informs the text services object that the control is no longer UI active.</summary>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>The method always returns <c>S_OK</c>.</para>
		/// </returns>
		/// <remarks>See ITextServices::OnTxInPlaceActivate for a detailed description of deactivation.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itextservices-ontxuideactivate HRESULT OnTxUIDeactivate();
		[PreserveSig]
		HRESULT OnTxUIDeactivate();

		/// <summary>Returns all of the Unicode plain text in the control as a <c>BSTR</c>.</summary>
		/// <param name="pbstrText">
		/// <para>Type: <c>BSTR *</c></para>
		/// <para>The Unicode plain text.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If the text is successfully returned in the output argument, the return value is <c>S_OK</c>.</para>
		/// <para>
		/// If the method fails, the return value is one of the following <c>HRESULT</c> codes. For more information on COM error codes, see
		/// Error Handling in COM.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>E_INVALIDARG</c></description>
		/// <description>Invalid <c>BSTR</c> pointer passed in.</description>
		/// </item>
		/// <item>
		/// <description><c>E_OUTOFMEMORY</c></description>
		/// <description>Could not allocate memory for copy of the text.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The host (caller) takes ownership of the returned <c>BSTR</c>.</para>
		/// <para>Other ways to retrieve plain text data are to use WM_GETTEXT or the Text Object Model (TOM)Â GetText method.</para>
		/// <para>If there is no text in the control, the <c>BSTR</c> is allocated and 0x000D is returned in it.</para>
		/// <para>The returned text will <c>not</c> necessarily be null-terminated.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itextservices-txgettext HRESULT TxGetText( BSTR
		// *pbstrText );
		[PreserveSig]
		HRESULT TxGetText([MarshalAs(UnmanagedType.BStr)] out string pbstrText);

		/// <summary>Sets all of the text in the control.</summary>
		/// <param name="pszText">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>The string which will replace the current text.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If the method succeeds, the return value is <c>S_OK</c>.</para>
		/// <para>
		/// If the method fails, the return value is the following <c>HRESULT</c> code. For more information on COM error codes, see Error
		/// Handling in COM.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>E_FAIL</c></description>
		/// <description>Text could not be updated.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method should be used with care; it essentially reinitializes the text services object with some new data. Any previous data
		/// and formatting information will be lost, including undo information.
		/// </para>
		/// <para>
		/// If previous data has been copied to the clipboard, that data will be rendered completely to the clipboard (through
		/// OleFlushClipboard) before it is discarded.
		/// </para>
		/// <para>This method does <c>not</c> support <c>Undo</c>.</para>
		/// <para>Two alternate approaches to setting text are WM_SETTEXT and SetText.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itextservices-txsettext HRESULT TxSetText( [in] LPCWSTR
		// pszText );
		[PreserveSig]
		HRESULT TxSetText([MarshalAs(UnmanagedType.LPWStr)] string pszText);

		/// <summary>Gets the target x position, that is, the current horizontal position of the caret.</summary>
		/// <param name="unnamedParam1"/>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If the x position of the caret is returned, the return value is <c>S_OK</c>.</para>
		/// <para>
		/// If the method fails, the return value is the following <c>HRESULT</c> code. For more information on COM error codes, see Error
		/// Handling in COM.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>E_FAIL</c></description>
		/// <description>There is no selection.</description>
		/// </item>
		/// <item>
		/// <description><c>E_INVALIDARG</c></description>
		/// <description>The input argument is invalid.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Together with ITextServices::OnTxSetCursor, this method allows you to maintain the horizontal caret position when moving the
		/// caret up and down. This capability is useful when moving the caret through forms.
		/// </para>
		/// <para>
		/// The target caret position is expressed as an x-coordinate on the display because other controls do not necessarily share the same
		/// attributes for column position.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itextservices-txgetcurtargetx HRESULT TxGetCurTargetX(
		// LONG *unnamedParam1 );
		[PreserveSig]
		HRESULT TxGetCurTargetX(out int unnamedParam1);

		/// <summary>
		/// Gets the base line position of the first visible line, in pixels, relative to the text services client rectangle. This permits
		/// aligning controls on their base lines.
		/// </summary>
		/// <param name="unnamedParam1"/>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If the method succeeds, the return value is <c>S_OK</c>.</para>
		/// <para>
		/// If the method fails, the return value is the following <c>HRESULT</c> code. For more information on COM error codes, see Error
		/// Handling in COM.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>E_NOTIMPL</c></description>
		/// <description>Not implemented.</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itextservices-txgetbaselinepos HRESULT TxGetBaseLinePos(
		// LONG *unnamedParam1 );
		[PreserveSig]
		HRESULT TxGetBaseLinePos(out int unnamedParam1);

		/// <summary>Allows a control to be resized so it fits its content appropriately.</summary>
		/// <param name="dwAspect">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The aspect for the drawing. It can be any of the values from the DVASPECT enumeration.</para>
		/// </param>
		/// <param name="hdcDraw">
		/// <para>Type: <c>HDC</c></para>
		/// <para>The device context into which drawing occurs.</para>
		/// </param>
		/// <param name="hicTargetDev">
		/// <para>Type: <c>HDC</c></para>
		/// <para>The device context for which text should be formatted (that is, for WYSIWYG).</para>
		/// </param>
		/// <param name="ptd">
		/// <para>Type: <c>DVTARGETDEVICE*</c></para>
		/// <para>More information on the target device.</para>
		/// </param>
		/// <param name="dwMode">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The type of fitting requested. It can be one of the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>TXTNS_EMU</c></description>
		/// <description>Use English Metric Units (EMUs) instead of pixels as the measuring units for this method's parameters.</description>
		/// </item>
		/// <item>
		/// <description><c>TXTNS_FITTOCONTENT</c></description>
		/// <description>
		/// Resize the control to fit the entire text by formatting the text to the width that is passed in. The text services object returns
		/// the height of the entire text and the width of the widest line. For example, this should be done when the user double-clicks one
		/// of the control's handles.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>TXTNS_FITTOCONTENT2</c></description>
		/// <description>Resize the control so that it fits indented content.</description>
		/// </item>
		/// <item>
		/// <description><c>TXTNS_FITTOCONTENT3</c></description>
		/// <description>Resize the control so that it fits indented content and trailing whitespace.</description>
		/// </item>
		/// <item>
		/// <description><c>TXTNS_FITTOCONTENTWSP</c></description>
		/// <description>Resize the control so that it fits unindented content and trailing whitespace.</description>
		/// </item>
		/// <item>
		/// <description><c>TXTNS_INCLUDELASTLINE</c></description>
		/// <description>For a plain-text control, include the height of the final carriage return when calculating the size.</description>
		/// </item>
		/// <item>
		/// <description><c>TXTNS_ROUNDTOLINE</c></description>
		/// <description>
		/// Resize the control to show an integral number of lines (no line is clipped). Format enough text to fill the width and height that
		/// is passed in, and then return a height that is rounded to the nearest line boundary.
		/// </description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="psizelExtent">
		/// <para>Type: <c>const SIZEL*</c></para>
		/// <para>Not supported.</para>
		/// </param>
		/// <param name="pwidth">
		/// <para>Type: <c>LONG*</c></para>
		/// <para>The width for the fitting defined by <c>dwMode</c>.</para>
		/// </param>
		/// <param name="pheight">
		/// <para>Type: <c>LONG*</c></para>
		/// <para>The height for the fitting defined by <c>dwMode</c>.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If the method succeeds, the return value is <c>S_OK</c>.</para>
		/// <para>
		/// If text services could not activate the object, the return value is one of the following <c>HRESULT</c> codes. For more
		/// information on COM error codes, see Error Handling in COM.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>E_FAIL</c></description>
		/// <description>Unable to determine correct size.</description>
		/// </item>
		/// <item>
		/// <description><c>E_INVALIDARG</c></description>
		/// <description>One or more arguments are not valid.</description>
		/// </item>
		/// <item>
		/// <description><c>E_OUTOFMEMORY</c></description>
		/// <description>Insufficient memory.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The first four parameters are similar to equivalent parameters in ITextServices::TxDraw and give the same information. In the
		/// case where the lines must be recalculated, it should use these values the same ways as in <c>ITextServices::TxDraw</c>.
		/// </para>
		/// <para>
		/// The <c>pwidth</c> and <c>pheight</c> parameters are in/out parameters. The host passes in the tentative width and height of the
		/// natural extent of the text object. The text services object compares these values against its current cached state, and if
		/// different, recalculate lines. Then, it computes and returns the natural size, as specified by <c>dwMode</c>.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itextservices-txgetnaturalsize HRESULT TxGetNaturalSize(
		// DWORD dwAspect, HDC hdcDraw, HDC hicTargetDev, DVTARGETDEVICE *ptd, DWORD dwMode, const SIZEL *psizelExtent, [in, out] LONG
		// *pwidth, [in, out] LONG *pheight );
		[PreserveSig]
		HRESULT TxGetNaturalSize(DVASPECT dwAspect, HDC hdcDraw, HDC hicTargetDev, [In] DVTARGETDEVICE ptd, TXTNATURALSIZE dwMode, in SIZE psizelExtent, ref int pwidth, ref int pheight);

		/// <summary>Gets the drop target for the text control.</summary>
		/// <param name="ppDropTarget">
		/// <para>Type: <c>IDropTarget**</c></para>
		/// <para>The target of a drag-and-drop operation in a specified window.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If the method got the drop target successfully, the return value is <c>S_OK</c>.</para>
		/// <para>For more information on COM error codes, see Error Handling in COM.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>E_OUTOFMEMORY</c></description>
		/// <description>Could not create the drop target.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// The host (caller) is responsible for calling RegisterDragDrop or RevokeDragDrop, and for calling Release on the returned drop
		/// target when done.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itextservices-txgetdroptarget HRESULT TxGetDropTarget(
		// IDropTarget **ppDropTarget );
		[PreserveSig]
		HRESULT TxGetDropTarget(out IDropTarget ppDropTarget);

		/// <summary>Sets properties (represented by bits) for the control.</summary>
		/// <param name="dwMask">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>Bits representing properties to be changed. For the possible bit values, see the TXTBIT_* values list in <c>dwBits</c>.</para>
		/// </param>
		/// <param name="dwBits">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>New values for bit properties. It can be any combination of the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>TXTBIT_ALLOWBEEP</c></description>
		/// <description>If <c>TRUE</c>, beeping is enabled.</description>
		/// </item>
		/// <item>
		/// <description><c>TXTBIT_AUTOWORDSEL</c></description>
		/// <description>If <c>TRUE</c>, the AutoWordSelect feature is enabled.</description>
		/// </item>
		/// <item>
		/// <description><c>TXTBIT_BACKSTYLECHANGE</c></description>
		/// <description>If <c>TRUE</c>, the backstyle changed. See TxGetBackStyle.</description>
		/// </item>
		/// <item>
		/// <description><c>TXTBIT_CHARFORMATCHANGE</c></description>
		/// <description>If <c>TRUE</c>, the character format changed.</description>
		/// </item>
		/// <item>
		/// <description><c>TXTBIT_CLIENTRECTCHANGE</c></description>
		/// <description>If <c>TRUE</c>, the client rectangle changed.</description>
		/// </item>
		/// <item>
		/// <description><c>TXTBIT_DISABLEDRAG</c></description>
		/// <description>If <c>TRUE</c>, dragging is disabled.</description>
		/// </item>
		/// <item>
		/// <description><c>TXTBIT_D2DDWRITE</c></description>
		/// <description>Use Direct2D/DirectWrite for this instance, and not GDI/Uniscribe.</description>
		/// </item>
		/// <item>
		/// <description><c>TXTBIT_D2DPIXELSNAPPED</c></description>
		/// <description>Render glyphs to the nearest pixel positions. Valid only if D2DDWRITE is set.</description>
		/// </item>
		/// <item>
		/// <description><c>TXTBIT_D2DSUBPIXELLINES</c></description>
		/// <description>
		/// Draw lines with subpixel precision. Don't pixel-snap text lines, underline, and strikethrough in the secondary text flow
		/// direction (usually vertical). Valid only if D2DDWRITE is set and D2DPIXELSNAPPED is not set.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>TXTBIT_D2DSIMPLETYPOGRAPHY</c></description>
		/// <description>
		/// Render text using simple typography (no glyph rendering). This value is valid only if TXTBIT_D2DDWRITE is also specified.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>TXTBIT_EXTENTCHANGE</c></description>
		/// <description>If <c>TRUE</c>, the size of the client rectangle changed.</description>
		/// </item>
		/// <item>
		/// <description><c>TXTBIT_HIDESELECTION</c></description>
		/// <description>
		/// If <c>TRUE</c>, the text services object should hide the selection when the control is inactive. If <c>FALSE</c>, the selection
		/// should be displayed when the control is inactive. Note, this implies <c>TXTBIT_SAVESELECTION</c> is <c>TRUE</c>.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>TXTBIT_MAXLENGTHCHANGE</c></description>
		/// <description>If <c>TRUE</c>, the maximum length for text in the control changed.</description>
		/// </item>
		/// <item>
		/// <description><c>TXTBIT_MULTILINE</c></description>
		/// <description>
		/// If <c>TRUE</c>, the text services object should work in multiline mode. Use the <c>TXTBIT_WORDWRAP</c> value to determine whether
		/// to wrap the lines to the view rectangle or clip them. If <c>FALSE</c>, the text services object should not process a carriage
		/// return/line feed from the ENTER key and it should truncate incoming text containing hard line breaks just before the first line
		/// break. It is also acceptable to truncate text that is set with ITextServices::TxSetText, because it is the responsibility of the
		/// host not to use a single-line control when bound to a multiline field.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>TXTBIT_NOTHREADREFCOUNT</c></description>
		/// <description>Don't reference TLS data on behalf of this instance.</description>
		/// </item>
		/// <item>
		/// <description><c>TXTBIT_PARAFORMATCHANGE</c></description>
		/// <description>If <c>TRUE</c>, the paragraph format changed.</description>
		/// </item>
		/// <item>
		/// <description><c>TXTBIT_READONLY</c></description>
		/// <description>
		/// If <c>TRUE</c>, the text services object should not accept any editing change through the user interface. However, it should
		/// still accept programmatic changes through EM_SETTEXTEX, EM_REPLACESEL, and ITextServices::TxSetText. Also, the user should still
		/// be able to move the insertion point, select text, and carry out other operations that don't modify content, such as Copy.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>TXTBIT_RICHTEXT</c></description>
		/// <description>
		/// If <c>TRUE</c>, the text services object should be in rich-text mode. If <c>FALSE</c>, it is in plain-text mode. Note, this
		/// affects how editing commands are applied. For example, applying bold to part of the text in a plain-edit control makes the entire
		/// text bold. However, for a rich-edit control, this makes only the selected text bold.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>TXTBIT_SAVESELECTION</c></description>
		/// <description>
		/// If <c>TRUE</c>, the boundaries of the selection should be saved when the control is inactive. If <c>FALSE</c>, when the control
		/// goes active again the selection boundaries can be reset to start = 0, length = 0.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>TXTBIT_SCROLLBARCHANGE</c></description>
		/// <description>If <c>TRUE</c>, the scroll bar has changed.</description>
		/// </item>
		/// <item>
		/// <description><c>TXTBIT_SELBARCHANGE</c></description>
		/// <description>If <c>TRUE</c>, the selection bar width has changed</description>
		/// </item>
		/// <item>
		/// <description><c>TXTBIT_SHOWACCELERATOR</c></description>
		/// <description>If set, the accelerator character should be underlined. This must be set in order to call TxGetAcceleratorPos.</description>
		/// </item>
		/// <item>
		/// <description><c>TXTBIT_SHOWPASSWORD</c></description>
		/// <description>Show password strings.</description>
		/// </item>
		/// <item>
		/// <description><c>TXTBIT_USECURRENTBKG</c></description>
		/// <description>Not supported.</description>
		/// </item>
		/// <item>
		/// <description><c>TXTBIT_USEPASSWORD</c></description>
		/// <description>
		/// If <c>TRUE</c>, display text using the password character obtained by TxGetPasswordChar. The notification on this property can
		/// mean either that the password character changed or that the password character was not used before but is used now (or vice versa).
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>TXTBIT_VERTICAL</c></description>
		/// <description>Not supported.</description>
		/// </item>
		/// <item>
		/// <description><c>TXTBIT_VIEWINSETCHANGE</c></description>
		/// <description>If <c>TRUE</c>, the inset changed.</description>
		/// </item>
		/// <item>
		/// <description><c>TXTBIT_WORDWRAP</c></description>
		/// <description>
		/// If <c>TRUE</c> and TXTBIT_MULTILINE is also <c>TRUE</c>, multiline controls should wrap the line to the view rectangle. If this
		/// property is <c>FALSE</c> and <c>TXTBIT_MULTILINE</c> is <c>TRUE</c>, the lines should not be wrapped but clipped. The right side
		/// of the view rectangle should be ignored. If <c>TXTBIT_MULTILINE</c> is <c>FALSE</c>, this property has no effect.
		/// </description>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If the method succeeds, the return value is <c>S_OK</c>.</para>
		/// <para>
		/// If the method fails, the return value is the following HRESULT code. For more information on COM error codes, see Error Handling
		/// in COM.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>E_NOTIMPL</c></description>
		/// <description>Not implemented.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The client rectangle is the rectangle that the text services object is responsible for painting and managing. The host relies on
		/// the text services object for painting that area. The text services object must not paint or invalidate areas outside of that
		/// rectangle. In addition, the host will forward mouse messages to the text services object when the cursor is over this rectangle.
		/// This rectangle is expressed in client coordinates of the containing window.
		/// </para>
		/// <para>
		/// The view inset is the amount of space on each side between the client rectangle and the view rectangle. The view rectangle (also
		/// called the Formatting rectangle) is the rectangle in which the text should be formatted. For more information, see TxGetViewInset.
		/// </para>
		/// <para>
		/// The backstyle is the style of the background of the client rectangle. It can be either TXTBACK_TRANSPARENT or TXTBACK_SOLID. See <c>TXTBACKSTYLE</c>.
		/// </para>
		/// <para>
		/// The scroll bar property indicates changes to the scroll bar: which scroll bar is present, whether scroll bars are hidden or
		/// disabled when scrolling is impossible, and also if auto-scrolling is enabled when the insertion point gets off the client rectangle.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itextservices-ontxpropertybitschange HRESULT
		// OnTxPropertyBitsChange( [in] DWORD dwMask, [in] DWORD dwBits );
		[PreserveSig]
		HRESULT OnTxPropertyBitsChange(TXTBIT dwMask, TXTBIT dwBits);

		/// <summary>
		/// Returns the cached drawing logical size (if any) that text services is using. Typically, this will be the size of the last client
		/// rectangle used in ITextServices::TxDraw, ITextServices::OnTxSetCursor, and so forth, although it is not guaranteed to be.
		/// </summary>
		/// <param name="pdwWidth">
		/// <para>Type: <c>DWORD*</c></para>
		/// <para>The width, in client coordinates.</para>
		/// </param>
		/// <param name="pdwHeight">
		/// <para>Type: <c>DWORD*</c></para>
		/// <para>The height (in client coordinates).</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If the method succeeds, the return value is an <c>HRESULT</c> code.</para>
		/// </returns>
		/// <remarks>
		/// This method can free the host from the need to maintain the cached drawing size information and the need to keep in synchronization.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itextservices-txgetcachedsize HRESULT TxGetCachedSize(
		// [in] DWORD *pdwWidth, [in] DWORD *pdwHeight );
		[PreserveSig]
		HRESULT TxGetCachedSize(out uint pdwWidth, out uint pdwHeight);
	}

	/// <summary>The <c>ITextServices2</c> interface extends the ITextServices interface.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nl-textserv-itextservices2
	[PInvokeData("textserv.h", MSDNShortId = "NL:textserv.ITextServices2")]
	[ComVisible(true), Guid("8D33F741-CF58-11CE-A89D-00AA006CADC5"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ITextServices2 : ITextServices
	{
		/// <summary>Used by the window host to forward messages sent from its window to the text services object.</summary>
		/// <param name="msg">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The message identifier.</para>
		/// </param>
		/// <param name="wparam">
		/// <para>Type: <c>WPARAM</c></para>
		/// <para>The <c>WPARAM</c> from the window's message.</para>
		/// </param>
		/// <param name="lparam">
		/// <para>Type: <c>LPARAM</c></para>
		/// <para>The <c>LPARAM</c> from the window's message.</para>
		/// </param>
		/// <param name="plresult">
		/// <para>Type: <c>LRESULT*</c></para>
		/// <para>The message's return <c>LRESULT</c>.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If the method succeeds, the return value is <c>S_OK</c>.</para>
		/// <para>
		/// If the method fails, the return value is one of the following <c>HRESULT</c> codes. For more information on COM error codes, see
		/// Error Handling in COM.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>E_OUTOFMEMORY</c></description>
		/// <description>Insufficient memory. NOERROR Message was processed, and some action was taken.</description>
		/// </item>
		/// <item>
		/// <description><c>S_FALSE</c></description>
		/// <description>
		/// Message was not processed. Typically indicates that the caller should process the message itself, potentially by calling DefWindowProc.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>S_MSG_KEYIGNORED</c></description>
		/// <description>Message processed, but no action was taken for the keystroke.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Note that two return values are passed back from this function. The return value that should be passed back from a window
		/// procedure is <c>plresult</c>. However, in some cases, the returned <c>LRESULT</c> does not contain enough information. For
		/// example, to implement moving the cursor around controls, it's useful to know if a keystroke (such as right arrow) was processed
		/// but ignored (for example, the caret is already at the rightmost position in the text). In these cases, more information may be
		/// returned through the returned <c>HRESULT</c>.
		/// </para>
		/// <para>
		/// WM_CHAR and WM_KEYDOWN should return the value S_MSG_KEYIGNORED when a key or character is recognized, but has no effect, given
		/// the current state. For example, S_MSG_KEYIGNORED should be returned in the following cases:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// Any keystroke that tries to move the insertion point to or beyond the beginning or the end of the document; when it is already at
		/// the beginning or end of the document, respectively.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// Any keystroke that tries to move the insertion point to or past the next line when it is already on the last line; or to or
		/// before the previous line when it is already on the first line.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// Any insertion of the character from WM_CHAR that would move the insertion point past the maximum length of the control.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itextservices-txsendmessage HRESULT TxSendMessage( UINT
		// msg, WPARAM wparam, LPARAM lparam, LRESULT *plresult );
		[PreserveSig]
		new HRESULT TxSendMessage(uint msg, IntPtr wparam, IntPtr lparam, out IntPtr plresult);

		/// <summary>Draws the text services object.</summary>
		/// <param name="dwDrawAspect">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// Specifies the aspect to be drawn, that is, how the object is to be represented. Draw aspect can be one of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>DVASPECT_CONTENT</c></description>
		/// <description>
		/// Renders a screen image of the text content to the <c>hdcDraw</c> device context. The <c>hicTargetDev</c> and <c>ptd</c>
		/// parameters give information on the target device context if any (usually a printer).
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>DVASPECT_DOCPRINT</c></description>
		/// <description>
		/// Renders the object to the <c>hdcDraw</c> device context as though it were printed to a printer. Thus, the text services object
		/// can optimize for the printer (for example, not painting the background color, if white). Also, certain screen-specific elements
		/// (such as the selection) should not be rendered. <c>ITextServices::TxDraw</c> should render the <c>lprcBounds</c> rectangle,
		/// starting at the current scrolling position.
		/// </description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="lindex">
		/// <para>Type: <c>LONG</c></para>
		/// <para>Not supported.</para>
		/// </param>
		/// <param name="pvAspect">
		/// <para>Type: <c>void*</c></para>
		/// <para>Information for drawing optimizations.</para>
		/// </param>
		/// <param name="ptd">
		/// <para>Type: <c>DVTARGETDEVICE*</c></para>
		/// <para>The target device.</para>
		/// </param>
		/// <param name="hdcDraw">
		/// <para>Type: <c>HDC</c></para>
		/// <para>Rendering device context.</para>
		/// </param>
		/// <param name="hicTargetDev">
		/// <para>Type: <c>HDC</c></para>
		/// <para>Target information context.</para>
		/// </param>
		/// <param name="lprcBounds">
		/// <para>Type: <c>LPCRECTL</c></para>
		/// <para>The bounding (client) rectangle.</para>
		/// </param>
		/// <param name="lprcWBounds">
		/// <para>Type: <c>LPCRECTL</c></para>
		/// <para>The clipping rectangle for metafiles.</para>
		/// </param>
		/// <param name="lprcUpdate">
		/// <para>Type: <c>LPRECT</c></para>
		/// <para>The update region inside <c>lprcBounds</c>.</para>
		/// </param>
		/// <param name="pfnContinue">
		/// <para>Type: <c>BOOL CALLBACK*</c></para>
		/// <para>Not supported.</para>
		/// </param>
		/// <param name="dwContinue">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>Parameter to pass to continue function.</para>
		/// </param>
		/// <param name="lViewId">
		/// <para>Type: <c>LONG</c></para>
		/// <para>Specifies the view to draw.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>TXTVIEW_ACTIVE</c></description>
		/// <description>Draw the inplace active view.</description>
		/// </item>
		/// <item>
		/// <description><c>TXTVIEW_INACTIVE</c></description>
		/// <description>Draw a view other than the inplace active view; for example, a print preview.</description>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>The return value is typically <c>S_OK</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method renders the text services object. It accepts the same parameters as the corresponding IViewObject::Draw method in
		/// OLE, with the extra <c>lprcUpdate</c> and the <c>lViewId</c> parameters. It can be used while the host is in-place active or inactive.
		/// </para>
		/// <para>
		/// The <c>lprcBounds</c> parameter gives the rectangle to render, also called the client rectangle. This rectangle represents the
		/// position and extent of the entire image of the text services object to be drawn. It is expressed in the logical coordinate system
		/// of <c>hdcDraw</c>. If <c>lprcBounds</c> is <c>NULL</c> then the control must be active. In this case, the text services object
		/// should render the in-place active view (that is, the client rectangle that can be obtained by calling TxGetClientRect on the host).
		/// </para>
		/// <para>
		/// If the <c>lprcUpdate</c> parameter is not <c>NULL</c>, it gives the rectangle to update inside that client rectangle, in the
		/// logical coordinate system of <c>hdcDraw</c>. If <c>lprcUpdate</c> is <c>NULL</c>, the entire client rectangle should be painted.
		/// </para>
		/// <para>
		/// The text services object should render with the appropriate zoom factor, which can be obtained from the client rectangle and the
		/// native size given by TxGetExtent. For a discussion of the zoom factor, see <c>TxGetExtent</c>.
		/// </para>
		/// <para>General comments on OLE hosts and <c>ITextServices::TxDraw</c> (also for ITextServices::OnTxSetCursor, and ITextServices::TxQueryHitPoint):</para>
		/// <para>
		/// An OLE host can call the <c>ITextServices::TxDraw</c> method at any time with any rendering device context or client rectangle.
		/// An OLE object that is inactive only retains an extent. To get the rectangle in which to render, the host calls the
		/// IViewObject::Draw method. This rectangle is valid only for the scope of that method. Thus, the same control can be rendered
		/// consecutively in different rectangles and different device contexts, for example, because it is displayed simultaneously in
		/// different views on the screen.
		/// </para>
		/// <para>
		/// Normally, the client rectangle and device context passed to <c>ITextServices::TxDraw</c> should not be cached, because this would
		/// force the text services object to recalculate lines for every draw, which would impede performance. Instead, the text services
		/// object could cache the information that is computed for a specific client rectangle and device context (such as line breaks). On
		/// the next call to <c>ITextServices::TxDraw</c>, however, the validity of the cached information should be checked before it gets
		/// used, and updated information should be regenerated, if necessary.
		/// </para>
		/// <para>
		/// Also, take great care when the control is in-place active. This problem is even more complex since <c>ITextServices::TxDraw</c>
		/// can still be called to render other views than the one that is in-place active. In other words, the client rectangle passed to
		/// <c>ITextServices::TxDraw</c> may not be the same as the active one (passed to ITextServices::OnTxInPlaceActivate and obtained
		/// through TxGetClientRect on the host).
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itextservices-txdraw HRESULT TxDraw( [in] DWORD
		// dwDrawAspect, LONG lindex, [in] void *pvAspect, [in] DVTARGETDEVICE *ptd, [in] HDC hdcDraw, [in] HDC hicTargetDev, [in] LPCRECTL
		// lprcBounds, [in] LPCRECTL lprcWBounds, [in] LPRECT lprcUpdate, BOOL(* )(DWORD) pfnContinue, DWORD dwContinue, LONG lViewId );
		[PreserveSig]
		new HRESULT TxDraw(DVASPECT dwDrawAspect, int lindex, IntPtr pvAspect, [In] DVTARGETDEVICE ptd, [In] HDC hdcDraw, [In] HDC hicTargetDev, in RECT lprcBounds,
			in RECT lprcWBounds, in RECT lprcUpdate, IntPtr pfnContinue, uint dwContinue, TXTVIEW lViewId);

		/// <summary>Returns horizontal scroll bar information.</summary>
		/// <param name="plMin">
		/// <para>Type: <c>LONG*</c></para>
		/// <para>The minimum scroll position.</para>
		/// </param>
		/// <param name="plMax">
		/// <para>Type: <c>LONG*</c></para>
		/// <para>The maximum scroll position.</para>
		/// </param>
		/// <param name="plPos">
		/// <para>Type: <c>LONG*</c></para>
		/// <para>The current scroll position.</para>
		/// </param>
		/// <param name="plPage">
		/// <para>Type: <c>LONG*</c></para>
		/// <para>The view width, in pixels.</para>
		/// </param>
		/// <param name="pfEnabled">
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>Indicates whether horizontal scrolling is enabled. If <c>TRUE</c>, horizontal scrolling is enabled.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>The method always returns <c>S_OK</c>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itextservices-txgethscroll HRESULT TxGetHScroll( LONG
		// *plMin, LONG *plMax, LONG *plPos, LONG *plPage, BOOL *pfEnabled );
		[PreserveSig]
		new HRESULT TxGetHScroll(out int plMin, out int plMax, out int plPos, out int plPage, out bool pfEnabled);

		/// <summary>Returns vertical scroll bar state information.</summary>
		/// <param name="plMin">
		/// <para>Type: <c>LONG*</c></para>
		/// <para>The minimum scroll position.</para>
		/// </param>
		/// <param name="plMax">
		/// <para>Type: <c>LONG*</c></para>
		/// <para>The maximum scroll position.</para>
		/// </param>
		/// <param name="plPos">
		/// <para>Type: <c>LONG*</c></para>
		/// <para>The current scroll position.</para>
		/// </param>
		/// <param name="plPage">
		/// <para>Type: <c>LONG*</c></para>
		/// <para>The height of view in pixels.</para>
		/// </param>
		/// <param name="pfEnabled">
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>
		/// Indicates whether the vertical scroll bar is enabled. If <c>TRUE</c>, the vertical scroll bar is enabled; otherwise it is disabled.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If the method succeeds, the return value is <c>S_OK</c>.</para>
		/// <para>
		/// If the method fails, the return value is one of the following <c>HRESULT</c> codes. For more information on COM error codes, see
		/// Error Handling in COM.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>E_FAIL</c></description>
		/// <description>Unspecified error.</description>
		/// </item>
		/// <item>
		/// <description><c>E_INVALIDARG</c></description>
		/// <description>One or more arguments are not valid.</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itextservices-txgetvscroll HRESULT TxGetVScroll( LONG
		// *plMin, LONG *plMax, LONG *plPos, LONG *plPage, BOOL *pfEnabled );
		[PreserveSig]
		new HRESULT TxGetVScroll(out int plMin, out int plMax, out int plPos, out int plPage, out bool pfEnabled);

		/// <summary>Notifies the text services object to set the cursor.</summary>
		/// <param name="dwDrawAspect">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>Draw aspect can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>DVASPECT_CONTENT</c></description>
		/// <description>
		/// Renders a screen image of the text content to the <c>hdcDraw</c> device context. The <c>hicTargetDev</c> and <c>ptd</c>
		/// parameters give information on the target device context if any (usually a printer).
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>DVASPECT_DOCPRINT</c></description>
		/// <description>
		/// Renders the object to the <c>hdcDraw</c> device context as though it were printed to a printer. Thus, the text services object
		/// can optimize for the printer (for example, not painting the background color, if white). Also, certain screen-specific elements
		/// (such as the selection) should not be rendered. <c>ITextServices::OnTxSetCursor</c> should render the <c>lprcClient</c>
		/// rectangle, starting at the current scrolling position.
		/// </description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="lindex">
		/// <para>Type: <c>LONG</c></para>
		/// <para>Not supported.</para>
		/// </param>
		/// <param name="pvAspect">
		/// <para>Type: <c>void*</c></para>
		/// <para>Information for drawing optimizations.</para>
		/// </param>
		/// <param name="ptd">
		/// <para>Type: <c>DVTARGETDEVICE*</c></para>
		/// <para>The target device.</para>
		/// </param>
		/// <param name="hdcDraw">
		/// <para>Type: <c>HDC</c></para>
		/// <para>Rendering device context.</para>
		/// </param>
		/// <param name="hicTargetDev">
		/// <para>Type: <c>HDC</c></para>
		/// <para>Target information context.</para>
		/// </param>
		/// <param name="lprcClient">
		/// <para>Type: <c>LPCRECT</c></para>
		/// <para>
		/// The control's client rectangle. The coordinates of the rectangle are in client coordinates of the containing window. <c>NULL</c>
		/// is a legal value.
		/// </para>
		/// </param>
		/// <param name="x">
		/// <para>Type: <c>INT</c></para>
		/// <para>x position of cursor, in the client coordinates of the containing window.</para>
		/// </param>
		/// <param name="y">
		/// <para>Type: <c>INT</c></para>
		/// <para>y position of cursor, in the client coordinates of the containing window.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If the method succeeds, the return value is <c>S_OK</c>.</para>
		/// <para>
		/// If the method fails, the return value is the following <c>HRESULT</c> code. For more information on COM error codes, see Error
		/// Handling in COM.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>E_INVALIDARG</c></description>
		/// <description>One or more illegal parameters.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The text services object may remeasure as a result of this call to determine the correct cursor. The correct cursor is set
		/// through TxSetCursor.
		/// </para>
		/// <para>
		/// The <c>lprcClient</c> parameter is the client rectangle of the view of the control over which the mouse cursor is positioned. The
		/// <c>lprcClient</c> parameter is in device coordinates of the containing window in the same way the WM_SIZE message is. This may
		/// not be the view that was rendered last. Furthermore, if the control is in-place active, this may not be the current active view .
		/// As a consequence, the text services object should check this rectangle against its current cache's value and determine whether
		/// recalculating the lines is necessary or not. The zoom factor should be included in this computation. For a discussion of the zoom
		/// factor, see TxGetExtent.
		/// </para>
		/// <para>
		/// This method should be called only for screen views of the control. Therefore the device context (DC) is not passed in, but should
		/// be assumed to be a screen DC.
		/// </para>
		/// <para>For more information, see the Remarks in ITextServices::TxDraw.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itextservices-ontxsetcursor HRESULT OnTxSetCursor( [in]
		// DWORD dwDrawAspect, LONG lindex, [in] void *pvAspect, [in] DVTARGETDEVICE *ptd, [in] HDC hdcDraw, [in] HDC hicTargetDev, [in]
		// LPCRECT lprcClient, [in] INT x, [in] INT y );
		[PreserveSig]
		new HRESULT OnTxSetCursor(uint dwDrawAspect, int lindex, [In] IntPtr pvAspect, [In] DVTARGETDEVICE ptd, [In] HDC hdcDraw, [In] HDC hicTargetDev, in RECT lprcClient, int x, int y);

		/// <summary>Tests whether a specified point is within the rectangle of the text services object.</summary>
		/// <param name="dwDrawAspect">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>Draw aspect can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>DVASPECT_CONTENT</c></description>
		/// <description>
		/// Renders a screen image of the text content to the <c>hdcDraw</c> device context. The <c>hicTargetDev</c> and <c>ptd</c>
		/// parameters give information on the target device context if any (usually a printer).
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>DVASPECT_DOCPRINT</c></description>
		/// <description>
		/// Renders the object to the <c>hdcDraw</c> device context as though it were printed to a printer. Thus, the text services object
		/// can optimize for the printer (for example, not painting the background color, if white). Also, certain screen-specific elements
		/// (such as the selection) should not be rendered. ITextServices::TxGetNaturalSize should render the <c>lprcClient</c> rectangle,
		/// starting at the current scrolling position.
		/// </description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="lindex">
		/// <para>Type: <c>LONG</c></para>
		/// <para>Not supported.</para>
		/// </param>
		/// <param name="pvAspect">
		/// <para>Type: <c>void*</c></para>
		/// <para>Information for drawing optimizations.</para>
		/// </param>
		/// <param name="ptd">
		/// <para>Type: <c>DVTARGETDEVICE*</c></para>
		/// <para>Information on the target device.</para>
		/// </param>
		/// <param name="hdcDraw">
		/// <para>Type: <c>HDC</c></para>
		/// <para>Rendering device context.</para>
		/// </param>
		/// <param name="hicTargetDev">
		/// <para>Type: <c>HDC</c></para>
		/// <para>Target information context.</para>
		/// </param>
		/// <param name="lprcClient">
		/// <para>Type: <c>LPCRECT</c></para>
		/// <para>The control's client rectangle, in client (device) coordinates of the view in which the hit testing is done.</para>
		/// </param>
		/// <param name="x">
		/// <para>Type: <c>INT</c></para>
		/// <para>x-coordinate to check, in client coordinates, of the view in which hit testing is done.</para>
		/// </param>
		/// <param name="y">
		/// <para>Type: <c>INT</c></para>
		/// <para>y-coordinate to check, in client coordinates, of the view in which hit testing is done.</para>
		/// </param>
		/// <param name="pHitResult">
		/// <para>Type: <c>DWORD*</c></para>
		/// <para>The result of the hit test. It can be any of the following <c>TXTHITRESULT</c> enumeration values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>TXTHITRESULT_CLOSE</c></description>
		/// <description>The point is in the client rectangle and close to a nontransparent area.</description>
		/// </item>
		/// <item>
		/// <description><c>TXTHITRESULT_HIT</c></description>
		/// <description>The point is in the client rectangle and either over text or the background is not transparent.</description>
		/// </item>
		/// <item>
		/// <description><c>TXTHITRESULT_NOHIT</c></description>
		/// <description>The point is outside of the client rectangle.</description>
		/// </item>
		/// <item>
		/// <description><c>TXTHITRESULT_TRANSPARENT</c></description>
		/// <description>The point is in the client rectangle and either not over text or the background was transparent.</description>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>The return value is an <c>HRESULT</c> code.</para>
		/// </returns>
		/// <remarks>
		/// <para>This method allows the host to implement transparent hit testing on text.</para>
		/// <para>For more information, see the Remarks section in ITextServices::TxDraw and ITextServices::OnTxSetCursor.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itextservices-txqueryhitpoint HRESULT TxQueryHitPoint(
		// [in] DWORD dwDrawAspect, LONG lindex, [in] void *pvAspect, [in] DVTARGETDEVICE *ptd, [in] HDC hdcDraw, [in] HDC hicTargetDev, [in]
		// LPCRECT lprcClient, [in] INT x, [in] INT y, [out] DWORD *pHitResult );
		[PreserveSig]
		new HRESULT TxQueryHitPoint(DVASPECT dwDrawAspect, int lindex, [In] IntPtr pvAspect, [In] DVTARGETDEVICE ptd, [In] HDC hdcDraw,
			[In] HDC hicTargetDev, in RECT lprcClient, int x, int y, out uint pHitResult);

		/// <summary>Notifies the text services object that this control is in-place active.</summary>
		/// <param name="prcClient">
		/// <para>Type: <c>const RECT*</c></para>
		/// <para>The control's client rectangle.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If the object is successfully activated, the return value is <c>S_OK</c>.</para>
		/// <para>
		/// If the object could not be activated due to error, the return value is E_FAIL. For more information on COM error codes, see Error
		/// Handling in COM.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// In-place active means that an embedded object is <c>running in-place</c> (for example, for regular controls and embeddings, it
		/// would have a window to draw in). In contrast, UI active means that an object currently has the <c>editing focus</c>. For example,
		/// things like menus and toolbars on the container may also contain elements from the UI-active control/embedding. There is only one
		/// UI-active control at any given time, while there can be many in-place active controls.
		/// </para>
		/// <para>
		/// Note, UI activation is different from getting the focus. To signal the text services object that the control is getting or losing
		/// focus, the host sends WM_SETFOCUS and WM_KILLFOCUS messages. Also, note that a windowless host will pass <c>NULL</c> as the
		/// <c>wParam</c> (window that lost the focus) for these messages.
		/// </para>
		/// <para>
		/// When making the transition directly from a nonactive state to the UI-active state, the host should call
		/// <c>ITextServices::OnTxInPlaceActivate</c> first and then ITextServices::OnTxUIActivate.
		/// </para>
		/// <para>
		/// <c>ITextServices::OnTxInPlaceActivate</c> takes as a parameter the client rectangle of the view being activated. This rectangle
		/// is given in client coordinates of the containing window. It is the same as would be obtained by calling TxGetClientRect on the host.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itextservices-ontxinplaceactivate HRESULT
		// OnTxInPlaceActivate( [in] LPCRECT prcClient );
		[PreserveSig]
		new HRESULT OnTxInPlaceActivate(in RECT prcClient);

		/// <summary>Notifies the text services object that this control is no longer in-place active.</summary>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>The return value is always <c>S_OK</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// In-place activation refers to an embedded object <c>running in-place</c> (for example, for regular controls and embeddings, it
		/// would have a window to draw in). In contrast, UI active means that an object currently has the <c>editing focus</c>.
		/// Specifically, things like menus and toolbars on the container may also contain elements from the UI-active control/embedding.
		/// There can only be one UI-active control at any given time, while many can be in-place active at once.
		/// </para>
		/// <para>
		/// Note, UI activation is different from getting the focus. To let the text services object know that the control is getting or
		/// losing focus, the host will send WM_SETFOCUS and WM_KILLFOCUS messages. Also, note that a windowless host will pass <c>NULL</c>
		/// as the <c>wParam</c> (window that lost the focus) for these messages.
		/// </para>
		/// <para>
		/// When making the transition from the UI-active state to a nonactive state, the host should call ITextServices::OnTxUIDeactivate
		/// first and then <c>ITextServices::OnTxInPlaceDeactivate</c>.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itextservices-ontxinplacedeactivate HRESULT OnTxInPlaceDeactivate();
		[PreserveSig]
		new HRESULT OnTxInPlaceDeactivate();

		/// <summary>Informs the text services object that the control is now UI active.</summary>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>The method always returns <c>S_OK</c>.</para>
		/// </returns>
		/// <remarks>See ITextServices::OnTxInPlaceActivate for a detailed description of activation.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itextservices-ontxuiactivate HRESULT OnTxUIActivate();
		[PreserveSig]
		new HRESULT OnTxUIActivate();

		/// <summary>Informs the text services object that the control is no longer UI active.</summary>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>The method always returns <c>S_OK</c>.</para>
		/// </returns>
		/// <remarks>See ITextServices::OnTxInPlaceActivate for a detailed description of deactivation.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itextservices-ontxuideactivate HRESULT OnTxUIDeactivate();
		[PreserveSig]
		new HRESULT OnTxUIDeactivate();

		/// <summary>Returns all of the Unicode plain text in the control as a <c>BSTR</c>.</summary>
		/// <param name="pbstrText">
		/// <para>Type: <c>BSTR *</c></para>
		/// <para>The Unicode plain text.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If the text is successfully returned in the output argument, the return value is <c>S_OK</c>.</para>
		/// <para>
		/// If the method fails, the return value is one of the following <c>HRESULT</c> codes. For more information on COM error codes, see
		/// Error Handling in COM.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>E_INVALIDARG</c></description>
		/// <description>Invalid <c>BSTR</c> pointer passed in.</description>
		/// </item>
		/// <item>
		/// <description><c>E_OUTOFMEMORY</c></description>
		/// <description>Could not allocate memory for copy of the text.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The host (caller) takes ownership of the returned <c>BSTR</c>.</para>
		/// <para>Other ways to retrieve plain text data are to use WM_GETTEXT or the Text Object Model (TOM)Â GetText method.</para>
		/// <para>If there is no text in the control, the <c>BSTR</c> is allocated and 0x000D is returned in it.</para>
		/// <para>The returned text will <c>not</c> necessarily be null-terminated.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itextservices-txgettext HRESULT TxGetText( BSTR
		// *pbstrText );
		[PreserveSig]
		new HRESULT TxGetText([MarshalAs(UnmanagedType.BStr)] out string pbstrText);

		/// <summary>Sets all of the text in the control.</summary>
		/// <param name="pszText">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>The string which will replace the current text.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If the method succeeds, the return value is <c>S_OK</c>.</para>
		/// <para>
		/// If the method fails, the return value is the following <c>HRESULT</c> code. For more information on COM error codes, see Error
		/// Handling in COM.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>E_FAIL</c></description>
		/// <description>Text could not be updated.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method should be used with care; it essentially reinitializes the text services object with some new data. Any previous data
		/// and formatting information will be lost, including undo information.
		/// </para>
		/// <para>
		/// If previous data has been copied to the clipboard, that data will be rendered completely to the clipboard (through
		/// OleFlushClipboard) before it is discarded.
		/// </para>
		/// <para>This method does <c>not</c> support <c>Undo</c>.</para>
		/// <para>Two alternate approaches to setting text are WM_SETTEXT and SetText.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itextservices-txsettext HRESULT TxSetText( [in] LPCWSTR
		// pszText );
		[PreserveSig]
		new HRESULT TxSetText([MarshalAs(UnmanagedType.LPWStr)] string pszText);

		/// <summary>Gets the target x position, that is, the current horizontal position of the caret.</summary>
		/// <param name="unnamedParam1"/>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If the x position of the caret is returned, the return value is <c>S_OK</c>.</para>
		/// <para>
		/// If the method fails, the return value is the following <c>HRESULT</c> code. For more information on COM error codes, see Error
		/// Handling in COM.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>E_FAIL</c></description>
		/// <description>There is no selection.</description>
		/// </item>
		/// <item>
		/// <description><c>E_INVALIDARG</c></description>
		/// <description>The input argument is invalid.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Together with ITextServices::OnTxSetCursor, this method allows you to maintain the horizontal caret position when moving the
		/// caret up and down. This capability is useful when moving the caret through forms.
		/// </para>
		/// <para>
		/// The target caret position is expressed as an x-coordinate on the display because other controls do not necessarily share the same
		/// attributes for column position.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itextservices-txgetcurtargetx HRESULT TxGetCurTargetX(
		// LONG *unnamedParam1 );
		[PreserveSig]
		new HRESULT TxGetCurTargetX(out int unnamedParam1);

		/// <summary>
		/// Gets the base line position of the first visible line, in pixels, relative to the text services client rectangle. This permits
		/// aligning controls on their base lines.
		/// </summary>
		/// <param name="unnamedParam1"/>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If the method succeeds, the return value is <c>S_OK</c>.</para>
		/// <para>
		/// If the method fails, the return value is the following <c>HRESULT</c> code. For more information on COM error codes, see Error
		/// Handling in COM.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>E_NOTIMPL</c></description>
		/// <description>Not implemented.</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itextservices-txgetbaselinepos HRESULT TxGetBaseLinePos(
		// LONG *unnamedParam1 );
		[PreserveSig]
		new HRESULT TxGetBaseLinePos(out int unnamedParam1);

		/// <summary>Allows a control to be resized so it fits its content appropriately.</summary>
		/// <param name="dwAspect">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The aspect for the drawing. It can be any of the values from the DVASPECT enumeration.</para>
		/// </param>
		/// <param name="hdcDraw">
		/// <para>Type: <c>HDC</c></para>
		/// <para>The device context into which drawing occurs.</para>
		/// </param>
		/// <param name="hicTargetDev">
		/// <para>Type: <c>HDC</c></para>
		/// <para>The device context for which text should be formatted (that is, for WYSIWYG).</para>
		/// </param>
		/// <param name="ptd">
		/// <para>Type: <c>DVTARGETDEVICE*</c></para>
		/// <para>More information on the target device.</para>
		/// </param>
		/// <param name="dwMode">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The type of fitting requested. It can be one of the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>TXTNS_EMU</c></description>
		/// <description>Use English Metric Units (EMUs) instead of pixels as the measuring units for this method's parameters.</description>
		/// </item>
		/// <item>
		/// <description><c>TXTNS_FITTOCONTENT</c></description>
		/// <description>
		/// Resize the control to fit the entire text by formatting the text to the width that is passed in. The text services object returns
		/// the height of the entire text and the width of the widest line. For example, this should be done when the user double-clicks one
		/// of the control's handles.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>TXTNS_FITTOCONTENT2</c></description>
		/// <description>Resize the control so that it fits indented content.</description>
		/// </item>
		/// <item>
		/// <description><c>TXTNS_FITTOCONTENT3</c></description>
		/// <description>Resize the control so that it fits indented content and trailing whitespace.</description>
		/// </item>
		/// <item>
		/// <description><c>TXTNS_FITTOCONTENTWSP</c></description>
		/// <description>Resize the control so that it fits unindented content and trailing whitespace.</description>
		/// </item>
		/// <item>
		/// <description><c>TXTNS_INCLUDELASTLINE</c></description>
		/// <description>For a plain-text control, include the height of the final carriage return when calculating the size.</description>
		/// </item>
		/// <item>
		/// <description><c>TXTNS_ROUNDTOLINE</c></description>
		/// <description>
		/// Resize the control to show an integral number of lines (no line is clipped). Format enough text to fill the width and height that
		/// is passed in, and then return a height that is rounded to the nearest line boundary.
		/// </description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="psizelExtent">
		/// <para>Type: <c>const SIZEL*</c></para>
		/// <para>Not supported.</para>
		/// </param>
		/// <param name="pwidth">
		/// <para>Type: <c>LONG*</c></para>
		/// <para>The width for the fitting defined by <c>dwMode</c>.</para>
		/// </param>
		/// <param name="pheight">
		/// <para>Type: <c>LONG*</c></para>
		/// <para>The height for the fitting defined by <c>dwMode</c>.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If the method succeeds, the return value is <c>S_OK</c>.</para>
		/// <para>
		/// If text services could not activate the object, the return value is one of the following <c>HRESULT</c> codes. For more
		/// information on COM error codes, see Error Handling in COM.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>E_FAIL</c></description>
		/// <description>Unable to determine correct size.</description>
		/// </item>
		/// <item>
		/// <description><c>E_INVALIDARG</c></description>
		/// <description>One or more arguments are not valid.</description>
		/// </item>
		/// <item>
		/// <description><c>E_OUTOFMEMORY</c></description>
		/// <description>Insufficient memory.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The first four parameters are similar to equivalent parameters in ITextServices::TxDraw and give the same information. In the
		/// case where the lines must be recalculated, it should use these values the same ways as in <c>ITextServices::TxDraw</c>.
		/// </para>
		/// <para>
		/// The <c>pwidth</c> and <c>pheight</c> parameters are in/out parameters. The host passes in the tentative width and height of the
		/// natural extent of the text object. The text services object compares these values against its current cached state, and if
		/// different, recalculate lines. Then, it computes and returns the natural size, as specified by <c>dwMode</c>.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itextservices-txgetnaturalsize HRESULT TxGetNaturalSize(
		// DWORD dwAspect, HDC hdcDraw, HDC hicTargetDev, DVTARGETDEVICE *ptd, DWORD dwMode, const SIZEL *psizelExtent, [in, out] LONG
		// *pwidth, [in, out] LONG *pheight );
		[PreserveSig]
		new HRESULT TxGetNaturalSize(DVASPECT dwAspect, HDC hdcDraw, HDC hicTargetDev, [In] DVTARGETDEVICE ptd, TXTNATURALSIZE dwMode, in SIZE psizelExtent, ref int pwidth, ref int pheight);

		/// <summary>Gets the drop target for the text control.</summary>
		/// <param name="ppDropTarget">
		/// <para>Type: <c>IDropTarget**</c></para>
		/// <para>The target of a drag-and-drop operation in a specified window.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If the method got the drop target successfully, the return value is <c>S_OK</c>.</para>
		/// <para>For more information on COM error codes, see Error Handling in COM.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>E_OUTOFMEMORY</c></description>
		/// <description>Could not create the drop target.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// The host (caller) is responsible for calling RegisterDragDrop or RevokeDragDrop, and for calling Release on the returned drop
		/// target when done.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itextservices-txgetdroptarget HRESULT TxGetDropTarget(
		// IDropTarget **ppDropTarget );
		[PreserveSig]
		new HRESULT TxGetDropTarget(out IDropTarget ppDropTarget);

		/// <summary>Sets properties (represented by bits) for the control.</summary>
		/// <param name="dwMask">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>Bits representing properties to be changed. For the possible bit values, see the TXTBIT_* values list in <c>dwBits</c>.</para>
		/// </param>
		/// <param name="dwBits">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>New values for bit properties. It can be any combination of the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>TXTBIT_ALLOWBEEP</c></description>
		/// <description>If <c>TRUE</c>, beeping is enabled.</description>
		/// </item>
		/// <item>
		/// <description><c>TXTBIT_AUTOWORDSEL</c></description>
		/// <description>If <c>TRUE</c>, the AutoWordSelect feature is enabled.</description>
		/// </item>
		/// <item>
		/// <description><c>TXTBIT_BACKSTYLECHANGE</c></description>
		/// <description>If <c>TRUE</c>, the backstyle changed. See TxGetBackStyle.</description>
		/// </item>
		/// <item>
		/// <description><c>TXTBIT_CHARFORMATCHANGE</c></description>
		/// <description>If <c>TRUE</c>, the character format changed.</description>
		/// </item>
		/// <item>
		/// <description><c>TXTBIT_CLIENTRECTCHANGE</c></description>
		/// <description>If <c>TRUE</c>, the client rectangle changed.</description>
		/// </item>
		/// <item>
		/// <description><c>TXTBIT_DISABLEDRAG</c></description>
		/// <description>If <c>TRUE</c>, dragging is disabled.</description>
		/// </item>
		/// <item>
		/// <description><c>TXTBIT_D2DDWRITE</c></description>
		/// <description>Use Direct2D/DirectWrite for this instance, and not GDI/Uniscribe.</description>
		/// </item>
		/// <item>
		/// <description><c>TXTBIT_D2DPIXELSNAPPED</c></description>
		/// <description>Render glyphs to the nearest pixel positions. Valid only if D2DDWRITE is set.</description>
		/// </item>
		/// <item>
		/// <description><c>TXTBIT_D2DSUBPIXELLINES</c></description>
		/// <description>
		/// Draw lines with subpixel precision. Don't pixel-snap text lines, underline, and strikethrough in the secondary text flow
		/// direction (usually vertical). Valid only if D2DDWRITE is set and D2DPIXELSNAPPED is not set.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>TXTBIT_D2DSIMPLETYPOGRAPHY</c></description>
		/// <description>
		/// Render text using simple typography (no glyph rendering). This value is valid only if TXTBIT_D2DDWRITE is also specified.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>TXTBIT_EXTENTCHANGE</c></description>
		/// <description>If <c>TRUE</c>, the size of the client rectangle changed.</description>
		/// </item>
		/// <item>
		/// <description><c>TXTBIT_HIDESELECTION</c></description>
		/// <description>
		/// If <c>TRUE</c>, the text services object should hide the selection when the control is inactive. If <c>FALSE</c>, the selection
		/// should be displayed when the control is inactive. Note, this implies <c>TXTBIT_SAVESELECTION</c> is <c>TRUE</c>.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>TXTBIT_MAXLENGTHCHANGE</c></description>
		/// <description>If <c>TRUE</c>, the maximum length for text in the control changed.</description>
		/// </item>
		/// <item>
		/// <description><c>TXTBIT_MULTILINE</c></description>
		/// <description>
		/// If <c>TRUE</c>, the text services object should work in multiline mode. Use the <c>TXTBIT_WORDWRAP</c> value to determine whether
		/// to wrap the lines to the view rectangle or clip them. If <c>FALSE</c>, the text services object should not process a carriage
		/// return/line feed from the ENTER key and it should truncate incoming text containing hard line breaks just before the first line
		/// break. It is also acceptable to truncate text that is set with ITextServices::TxSetText, because it is the responsibility of the
		/// host not to use a single-line control when bound to a multiline field.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>TXTBIT_NOTHREADREFCOUNT</c></description>
		/// <description>Don't reference TLS data on behalf of this instance.</description>
		/// </item>
		/// <item>
		/// <description><c>TXTBIT_PARAFORMATCHANGE</c></description>
		/// <description>If <c>TRUE</c>, the paragraph format changed.</description>
		/// </item>
		/// <item>
		/// <description><c>TXTBIT_READONLY</c></description>
		/// <description>
		/// If <c>TRUE</c>, the text services object should not accept any editing change through the user interface. However, it should
		/// still accept programmatic changes through EM_SETTEXTEX, EM_REPLACESEL, and ITextServices::TxSetText. Also, the user should still
		/// be able to move the insertion point, select text, and carry out other operations that don't modify content, such as Copy.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>TXTBIT_RICHTEXT</c></description>
		/// <description>
		/// If <c>TRUE</c>, the text services object should be in rich-text mode. If <c>FALSE</c>, it is in plain-text mode. Note, this
		/// affects how editing commands are applied. For example, applying bold to part of the text in a plain-edit control makes the entire
		/// text bold. However, for a rich-edit control, this makes only the selected text bold.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>TXTBIT_SAVESELECTION</c></description>
		/// <description>
		/// If <c>TRUE</c>, the boundaries of the selection should be saved when the control is inactive. If <c>FALSE</c>, when the control
		/// goes active again the selection boundaries can be reset to start = 0, length = 0.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>TXTBIT_SCROLLBARCHANGE</c></description>
		/// <description>If <c>TRUE</c>, the scroll bar has changed.</description>
		/// </item>
		/// <item>
		/// <description><c>TXTBIT_SELBARCHANGE</c></description>
		/// <description>If <c>TRUE</c>, the selection bar width has changed</description>
		/// </item>
		/// <item>
		/// <description><c>TXTBIT_SHOWACCELERATOR</c></description>
		/// <description>If set, the accelerator character should be underlined. This must be set in order to call TxGetAcceleratorPos.</description>
		/// </item>
		/// <item>
		/// <description><c>TXTBIT_SHOWPASSWORD</c></description>
		/// <description>Show password strings.</description>
		/// </item>
		/// <item>
		/// <description><c>TXTBIT_USECURRENTBKG</c></description>
		/// <description>Not supported.</description>
		/// </item>
		/// <item>
		/// <description><c>TXTBIT_USEPASSWORD</c></description>
		/// <description>
		/// If <c>TRUE</c>, display text using the password character obtained by TxGetPasswordChar. The notification on this property can
		/// mean either that the password character changed or that the password character was not used before but is used now (or vice versa).
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>TXTBIT_VERTICAL</c></description>
		/// <description>Not supported.</description>
		/// </item>
		/// <item>
		/// <description><c>TXTBIT_VIEWINSETCHANGE</c></description>
		/// <description>If <c>TRUE</c>, the inset changed.</description>
		/// </item>
		/// <item>
		/// <description><c>TXTBIT_WORDWRAP</c></description>
		/// <description>
		/// If <c>TRUE</c> and TXTBIT_MULTILINE is also <c>TRUE</c>, multiline controls should wrap the line to the view rectangle. If this
		/// property is <c>FALSE</c> and <c>TXTBIT_MULTILINE</c> is <c>TRUE</c>, the lines should not be wrapped but clipped. The right side
		/// of the view rectangle should be ignored. If <c>TXTBIT_MULTILINE</c> is <c>FALSE</c>, this property has no effect.
		/// </description>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If the method succeeds, the return value is <c>S_OK</c>.</para>
		/// <para>
		/// If the method fails, the return value is the following HRESULT code. For more information on COM error codes, see Error Handling
		/// in COM.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>E_NOTIMPL</c></description>
		/// <description>Not implemented.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The client rectangle is the rectangle that the text services object is responsible for painting and managing. The host relies on
		/// the text services object for painting that area. The text services object must not paint or invalidate areas outside of that
		/// rectangle. In addition, the host will forward mouse messages to the text services object when the cursor is over this rectangle.
		/// This rectangle is expressed in client coordinates of the containing window.
		/// </para>
		/// <para>
		/// The view inset is the amount of space on each side between the client rectangle and the view rectangle. The view rectangle (also
		/// called the Formatting rectangle) is the rectangle in which the text should be formatted. For more information, see TxGetViewInset.
		/// </para>
		/// <para>
		/// The backstyle is the style of the background of the client rectangle. It can be either TXTBACK_TRANSPARENT or TXTBACK_SOLID. See <c>TXTBACKSTYLE</c>.
		/// </para>
		/// <para>
		/// The scroll bar property indicates changes to the scroll bar: which scroll bar is present, whether scroll bars are hidden or
		/// disabled when scrolling is impossible, and also if auto-scrolling is enabled when the insertion point gets off the client rectangle.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itextservices-ontxpropertybitschange HRESULT
		// OnTxPropertyBitsChange( [in] DWORD dwMask, [in] DWORD dwBits );
		[PreserveSig]
		new HRESULT OnTxPropertyBitsChange(TXTBIT dwMask, TXTBIT dwBits);

		/// <summary>
		/// Returns the cached drawing logical size (if any) that text services is using. Typically, this will be the size of the last client
		/// rectangle used in ITextServices::TxDraw, ITextServices::OnTxSetCursor, and so forth, although it is not guaranteed to be.
		/// </summary>
		/// <param name="pdwWidth">
		/// <para>Type: <c>DWORD*</c></para>
		/// <para>The width, in client coordinates.</para>
		/// </param>
		/// <param name="pdwHeight">
		/// <para>Type: <c>DWORD*</c></para>
		/// <para>The height (in client coordinates).</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If the method succeeds, the return value is an <c>HRESULT</c> code.</para>
		/// </returns>
		/// <remarks>
		/// This method can free the host from the need to maintain the cached drawing size information and the need to keep in synchronization.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itextservices-txgetcachedsize HRESULT TxGetCachedSize(
		// [in] DWORD *pdwWidth, [in] DWORD *pdwHeight );
		[PreserveSig]
		new HRESULT TxGetCachedSize(out uint pdwWidth, out uint pdwHeight);

		/// <summary>
		/// Resizes a control so it fits its content appropriately. This method is similar to TxGetNaturalSize, but also retrieves the ascent
		/// of the top line of text.
		/// </summary>
		/// <param name="dwAspect">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The aspect for the drawing. It can be any of the values from the DVASPECT enumeration.</para>
		/// </param>
		/// <param name="hdcDraw">
		/// <para>Type: <c>HDC</c></para>
		/// <para>The device context into which drawing occurs.</para>
		/// </param>
		/// <param name="hicTargetDev">
		/// <para>Type: <c>HDC</c></para>
		/// <para>The device context for which text should be formatted (that is, for WYSIWYG).</para>
		/// </param>
		/// <param name="ptd">
		/// <para>Type: <c>DVTARGETDEVICE*</c></para>
		/// <para>More information on the target device.</para>
		/// </param>
		/// <param name="dwMode">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The type of fitting requested. It can be one of the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>TXTNS_EMU</c></description>
		/// <description>Use English Metric Units (EMUs) instead of pixels as the measuring units (both ways) for this method's parameters.</description>
		/// </item>
		/// <item>
		/// <description><c>TXTNS_FITTOCONTENT</c></description>
		/// <description>
		/// Resize the control to fit the entire text by formatting the text to the width that is passed in. The text services object returns
		/// the height of the entire text and the width of the widest line. For example, this should be done when the user double-clicks one
		/// of the control's handles.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>TXTNS_FITTOCONTENT2</c></description>
		/// <description>Resize the control so that it fits indented content.</description>
		/// </item>
		/// <item>
		/// <description><c>TXTNS_FITTOCONTENT3</c></description>
		/// <description>Resize the control so that it fits indented content and trailing white space.</description>
		/// </item>
		/// <item>
		/// <description><c>TXTNS_FITTOCONTENTWSP</c></description>
		/// <description>Resize the control so that it fits unindented content and trailing white space.</description>
		/// </item>
		/// <item>
		/// <description><c>TXTNS_INCLUDELASTLINE</c></description>
		/// <description>For a plain-text control, include the height of the final carriage return when calculating the size.</description>
		/// </item>
		/// <item>
		/// <description><c>TXTNS_ROUNDTOLINE</c></description>
		/// <description>
		/// Resize the control to show an integral number of lines (no line is clipped). Format enough text to fill the width and height that
		/// is passed in, and then return a height that is rounded to the nearest line boundary.
		/// </description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="psizelExtent">
		/// <para>Type: <c>const SIZEL*</c></para>
		/// <para>Sizes of extents (in HIMETRIC units) to use for zooming.</para>
		/// </param>
		/// <param name="pwidth">
		/// <para>Type: <c>LONG*</c></para>
		/// <para>The width for the fitting defined by <c>dwMode</c>.</para>
		/// </param>
		/// <param name="pheight">
		/// <para>Type: <c>LONG*</c></para>
		/// <para>The height for the fitting defined by <c>dwMode</c>.</para>
		/// </param>
		/// <param name="pascent">
		/// <para>Type: <c>LONG*</c></para>
		/// <para>For single-line controls, receives the ascent (units above the baseline) of characters in the top line of text.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If the method succeeds, the return value is <c>S_OK</c>.</para>
		/// <para>
		/// If text services could not activate the object, the return value is one of the following <c>HRESULT</c> codes. For more
		/// information on COM error codes, see Error Handling in COM.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>E_FAIL</c></description>
		/// <description>Unable to determine correct size.</description>
		/// </item>
		/// <item>
		/// <description><c>E_INVALIDARG</c></description>
		/// <description>One or more arguments are not valid.</description>
		/// </item>
		/// <item>
		/// <description><c>E_OUTOFMEMORY</c></description>
		/// <description>Insufficient memory.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The first four parameters are similar to equivalent parameters in ITextServices::TxDraw and give the same information. In the
		/// case where the lines must be recalculated, <c>TxGetNaturalSize2</c> uses these values in the same ways as in <c>ITextServices::TxDraw</c>.
		/// </para>
		/// <para>
		/// The <c>pwidth</c> and <c>pheight</c> parameters are in/out parameters. The host passes in the tentative width and height of the
		/// natural extent of the text object. The text services object compares these values against its current cached state, and if
		/// different, recalculates lines. Then, it computes and returns the natural size, as specified by <c>dwMode</c>.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following example shows how to initialize the <c>psizelExtent</c> parameter for to a zoom factor of 1:1. The ellipses
		/// indicate code that you need to provide.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itextservices2-txgetnaturalsize2 HRESULT
		// TxGetNaturalSize2( DWORD dwAspect, HDC hdcDraw, HDC hicTargetDev, DVTARGETDEVICE *ptd, DWORD dwMode, const SIZEL *psizelExtent,
		// LONG *pwidth, LONG *pheight, LONG *pascent );
		[PreserveSig]
		HRESULT TxGetNaturalSize2(DVASPECT dwAspect, HDC hdcDraw, HDC hicTargetDev, [In] DVTARGETDEVICE ptd, TXTNATURALSIZE dwMode, in SIZE psizelExtent, ref int pwidth, ref int pheight, out int pascent);

		/// <summary>Draws the text services object by using Direct2D rendering.</summary>
		/// <param name="pRenderTarget">
		/// <para>Type: <c>ID2D1RenderTarget*</c></para>
		/// <para>The Direct2D rendering object that draws the text services object.</para>
		/// </param>
		/// <param name="lprcBounds">
		/// <para>Type: <c>LPCRECTL</c></para>
		/// <para>The bounding (client) rectangle.</para>
		/// </param>
		/// <param name="lprcUpdate">
		/// <para>Type: <c>LPRECT</c></para>
		/// <para>
		/// The rectangle to update inside <c>lprcBounds</c> rectangle, in the logical coordinate system of drawing device context. If this
		/// parameter is NULL, the entire client rectangle should be drawn.
		/// </para>
		/// </param>
		/// <param name="lViewId">
		/// <para>Type: <c>LONG</c></para>
		/// <para>The view to draw.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>TXTVIEW_ACTIVE</c></description>
		/// <description>Draw the in-place active view.</description>
		/// </item>
		/// <item>
		/// <description><c>TXTVIEW_INACTIVE</c></description>
		/// <description>Draw a view other than the in-place active view, for example, a print preview.</description>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-itextservices2-txdrawd2d HRESULT TxDrawD2D(
		// ID2D1RenderTarget *pRenderTarget, LPCRECTL lprcBounds, LPRECT lprcUpdate, LONG lViewId );
		[PreserveSig]
		HRESULT TxDrawD2D([In, MarshalAs(UnmanagedType.IUnknown)] object /*ID2D1RenderTarget*/ pRenderTarget, in RECT lprcBounds, [In, Optional] PRECT lprcUpdate, TXTVIEW lViewId);
	}

	/// <summary>
	/// The <c>CreateTextServices</c> function creates an instance of a text services object. The text services object supports a variety of
	/// interfaces, including ITextServices and the Text Object Model (TOM).
	/// </summary>
	/// <param name="punkOuter">
	/// <para>Type: <c>IUnknown*</c></para>
	/// <para>
	/// Pointer to the controlling IUnknown interface on the outer object if the text services object is being created as part of an
	/// aggregate object. This parameter can be <c>NULL</c> if the object is not part of an aggregate.
	/// </para>
	/// </param>
	/// <param name="pITextHost">
	/// <para>Type: <c>ITextHost*</c></para>
	/// <para>Pointer to your implementation of the ITextHost interface. This pointer must not be <c>NULL</c>.</para>
	/// </param>
	/// <param name="ppUnk">
	/// <para>Type: <c>IUnknown**</c></para>
	/// <para>
	/// Pointer to a variable that receives a pointer to the private IUnknown of the text services object. You can call QueryInterface on
	/// this pointer to retrieve ITextServices or ITextDocument interface pointers.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>If the text services object was created successfully, the return value is S_OK.</para>
	/// <para>
	/// If the function fails, one of the following COM error codes are returned. For more information on COM error codes, see Error Handling
	/// in COM.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <description>Return code</description>
	/// <description>Description</description>
	/// </listheader>
	/// <item>
	/// <description><c>E_INVALIDARG</c></description>
	/// <description>An invalid argument was passed in.</description>
	/// </item>
	/// <item>
	/// <description><c>E_OUTOFMEMORY</c></description>
	/// <description>Memory for text services object could not be allocated.</description>
	/// </item>
	/// <item>
	/// <description><c>E_FAIL</c></description>
	/// <description>The text services object could not be initialized.</description>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// A text services object can be created as part of a standard COM-aggregated object. If it is, then callers should follow standard
	/// OLE32 rules for dealing with aggregated objects and caching interface pointers obtained through QueryInterface from the private IUnknown.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-createtextservices HRESULT CreateTextServices( [in] IUnknown
	// *punkOuter, [in] ITextHost *pITextHost, [out] IUnknown **ppUnk );
	[PInvokeData("textserv.h", MSDNShortId = "NF:textserv.CreateTextServices")]
	[DllImport(Lib_msftedit, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT CreateTextServices([In, Optional, MarshalAs(UnmanagedType.IUnknown)] object punkOuter,
		[In] ITextHost pITextHost, [MarshalAs(UnmanagedType.IUnknown)] out object ppUnk);

	/// <summary>Disconnects a host from a text services instance.</summary>
	/// <param name="pTextServices">
	/// <para>Type: <c>IUnknown*</c></para>
	/// <para>A text services instance created by a previous call to the CreateTextServices function.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>If the text services object was created successfully, the return value is S_OK.</para>
	/// <para>
	/// If the function fails, one of the following COM error codes are returned. For more information on COM error codes, see Error Handling
	/// in COM.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <description>Return code</description>
	/// <description>Description</description>
	/// </listheader>
	/// <item>
	/// <description><c>E_INVALIDARG</c></description>
	/// <description>The <c>pTextServices</c> parameter is not valid.</description>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// A host calls this function when the host is being freed. Calling this function is necessary because all text services instances
	/// maintain a host pointer for which the AddRef method has not been called. This function calls the Release method on the text services
	/// instance and, if this is not the last reference to the text services object, nulls out the host pointer in the text services object
	/// and prepares the control to handle failed operations that require host services. This function allows any other outstanding
	/// references to the text services object to work or fail gracefully depending on the service required.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/textserv/nf-textserv-shutdowntextservices HRESULT ShutdownTextServices( [in]
	// IUnknown *pTextServices );
	[PInvokeData("textserv.h", MSDNShortId = "NF:textserv.ShutdownTextServices")]
	[DllImport(Lib_msftedit, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT ShutdownTextServices([In, MarshalAs(UnmanagedType.IUnknown)] object pTextServices);

	/// <summary>
	/// Contains information that is associated with an EN_CHANGE notification code. A windowless rich edit control sends this notification
	/// to its host window when the content of the control changes.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/textserv/ns-textserv-changenotify struct CHANGENOTIFY { DWORD dwChangeType; void
	// *pvCookieData; };
	[PInvokeData("textserv.h", MSDNShortId = "NS:textserv.CHANGENOTIFY")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CHANGENOTIFY
	{
		/// <summary>
		/// <para>The type of change that occurred. It can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>CN_GENERIC</c></description>
		/// <description>No significant change occurred.</description>
		/// </item>
		/// <item>
		/// <description><c>CN_NEWREDO</c></description>
		/// <description>A new redo action was added.</description>
		/// </item>
		/// <item>
		/// <description><c>CN_NEWUNDO</c></description>
		/// <description>A new undo action was added.</description>
		/// </item>
		/// <item>
		/// <description><c>CN_TEXTCHANGED</c></description>
		/// <description>The text changed.</description>
		/// </item>
		/// </list>
		/// </summary>
		public CN dwChangeType;

		/// <summary>Cookie for the undo action that is associated with the change.</summary>
		public IntPtr pvCookieData;
	}
}