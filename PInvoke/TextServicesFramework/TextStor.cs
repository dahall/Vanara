using System.Runtime.InteropServices.ComTypes;
using TS_ATTRID = System.Guid;
using TsViewCookie = System.UInt32;

namespace Vanara.PInvoke;

public static partial class MSCTF
{
	/// <summary>Application does not support the data type contained in the IDataObject object to be inserted using ITextStoreACP::InsertEmbedded.</summary>
	public static readonly HRESULT TS_E_FORMAT = unchecked((int)0x8004020a);

	/// <summary>Parameter is not within the bounding box of any character.</summary>
	public static readonly HRESULT TS_E_INVALIDPOINT = unchecked((int)0x80040207);

	/// <summary>Range specified extends outside the document.</summary>
	public static readonly HRESULT TS_E_INVALIDPOS = unchecked((int)0x80040200);

	/// <summary>Object does not support the requested interface.</summary>
	public static readonly HRESULT TS_E_NOINTERFACE = unchecked((int)0x80040204);

	/// <summary>Application has not calculated a text layout.</summary>
	public static readonly HRESULT TS_E_NOLAYOUT = unchecked((int)0x80040206);

	/// <summary>Application does not have a read-only lock or read/write lock for the document.</summary>
	public static readonly HRESULT TS_E_NOLOCK = unchecked((int)0x80040201);

	/// <summary>Embedded content offset is not positioned before a TF_CHAR_EMBEDDED character.</summary>
	public static readonly HRESULT TS_E_NOOBJECT = unchecked((int)0x80040202);

	/// <summary>Document has no selection.</summary>
	public static readonly HRESULT TS_E_NOSELECTION = unchecked((int)0x80040205);

	/// <summary>Content cannot be returned to match the service GUID.</summary>
	public static readonly HRESULT TS_E_NOSERVICE = unchecked((int)0x80040203);

	/// <summary>Document is read-only. Cannot modify content.</summary>
	public static readonly HRESULT TS_E_READONLY = unchecked((int)0x80040209);

	/// <summary>Document cannot be locked synchronously.</summary>
	public static readonly HRESULT TS_E_SYNCHRONOUS = unchecked(0x00040300);

	/// <summary>Document successfully received an asynchronous lock.</summary>
	public static readonly HRESULT TS_S_ASYNC = 0x1;

	/// <summary>
	/// Specifies the character position to return based upon the screen coordinates of the point relative to a character bounding box.
	/// By default, the character position returned is the character bounding box containing the screen coordinates of the point. If the
	/// point is outside a character bounding box, the method returns <c>NULL</c> or TF_E_INVALIDPOINT. Other bit flags for this
	/// parameter are as follows.
	/// </summary>
	[PInvokeData("textstor.h")]
	[Flags]
	public enum GXFPF : uint
	{
		/// <term>
		/// If the screen coordinates of the point are contained in a character bounding box, the character position returned is the
		/// bounding edge closest to the screen coordinates of the point.
		/// </term>
		GXFPF_ROUND_NEAREST = 0x1,

		/// <term>
		/// If the screen coordinates of the point are not contained in a character bounding box, the closest character position is returned.
		/// </term>
		GXFPF_NEAREST = 0x2,
	}

	/// <summary>The following flags specify the events that call the <c>AdviseSink</c> methods.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/tsf/ts-as--constants
	[PInvokeData("textstor.h")]
	[Flags]
	public enum TS_AS : uint
	{
		/// <summary>Text is changed in the document.</summary>
		TS_AS_TEXT_CHANGE = 0x01,

		/// <summary>Text is selected in the document.</summary>
		TS_AS_SEL_CHANGE = 0x02,

		/// <summary>The layout of the document is changed.</summary>
		TS_AS_LAYOUT_CHANGE = 0x04,

		/// <summary>The attributes of the document is changed.</summary>
		TS_AS_ATTR_CHANGE = 0x08,

		/// <summary>The status of the document is changed.</summary>
		TS_AS_STATUS_CHANGE = 0x10,

		/// <summary>One of the previous four events occurred in the document.</summary>
		TS_AS_ALL_SINKS = (TS_AS_TEXT_CHANGE | TS_AS_SEL_CHANGE | TS_AS_LAYOUT_CHANGE | TS_AS_ATTR_CHANGE | TS_AS_STATUS_CHANGE),
	}

	/// <summary>
	/// The TS_ATTR_* constants are used to obtain and change the values of document attributes. These constants form possible values of
	/// bitfield flags in ITextStoreACP and ITextStoreAnchor methods.
	/// </summary>
	[PInvokeData("textstor.h")]
	[Flags]
	public enum TS_ATTR_FIND : uint
	{
		/// <summary>
		/// Search backward from the start character or anchor position for the position where a transition occurs in a document
		/// attribute value. The default is search forward.
		/// </summary>
		TS_ATTR_FIND_BACKWARDS = (0x1),

		/// <summary>
		/// Return the number of characters between the start character or anchor position (acpStart in
		/// ITextStoreACP::FindNextAttrTransition or paStart in ITextStoreAnchor::FindNextAttrTransition ) and the position at which an
		/// attribute transition occurs.
		/// </summary>
		TS_ATTR_FIND_WANT_OFFSET = (0x2),

		/// <summary>
		/// Used by ITextStoreAnchor::FindNextAttrTransition to position the input anchor at the next attribute transition, if one is
		/// found. Otherwise the input anchor is not modified.
		/// </summary>
		TS_ATTR_FIND_UPDATESTART = (0x4),

		/// <summary>Load supported document attribute values into the TS_ATTRVAL structure.</summary>
		TS_ATTR_FIND_WANT_VALUE = (0x8),

		/// <summary>
		/// Used by ITextStoreACP::RequestAttrsTransitioningAtPosition and ITextStoreAnchor::RequestAttrsTransitioningAtPosition to
		/// obtain the document attribute values that end at the specified character or anchor position.
		/// </summary>
		TS_ATTR_FIND_WANT_END = (0x10),

		/// <summary>Reserved.</summary>
		TS_ATTR_FIND_HIDDEN = (0x20),
	}

	/// <summary>The TS_CH_* constants are used internally by TSF to indicate that text deletions have occurred.</summary>
	[PInvokeData("textstor.h")]
	[Flags]
	public enum TS_CH : uint
	{
		/// <summary>Text preceding the character position has been deleted.</summary>
		TS_CH_PRECEDING_DEL = 1,

		/// <summary>Text following the character position has been deleted.</summary>
		TS_CH_FOLLOWING_DEL = 2,
	}

	/// <summary>Bit fields that specify how the method deals with hidden text.</summary>
	[PInvokeData("textstor.h")]
	[Flags]
	public enum TS_GEA
	{
		/// <summary>Hidden text is skipped over.</summary>
		TS_GEA_NONE = 0x0,

		/// <summary>An embedded object can be located within hidden text.</summary>
		TS_GEA_HIDDEN = 0x1
	}

	/// <summary></summary>
	[PInvokeData("textstor.h")]
	[Flags]
	public enum TS_GTA
	{
		/// <summary>The ts gta hidden</summary>
		TS_GTA_HIDDEN = 0x1
	}

	/// <summary>
	/// <para>
	/// The TS_IAS_* constants are used as bitfield flags to control insertion of text or embedded objects at a selection or insertion point.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/tsf/ts-ias--constants
	[PInvokeData("textstor.h")]
	[Flags]
	public enum TS_IAS : uint
	{
		/// <term>Text is inserted and the range pointer is set to NULL upon exit. Cannot be combined with the TS_IAS_QUERYONLY flag.</term>
		TS_IAS_NOQUERY = 0x1,

		/// <term>
		/// Do not perform the insertion. Caller only requires the range pointer to be set. Cannot be combined with the TS_IAS_NOQUERY flag.
		/// </term>
		TS_IAS_QUERYONLY = 0x2,
	}

	/// <summary>The TS_IE_* constants describe how to insert text that can contain embedded objects used by text services.</summary>
	/// <remarks>These constants are used in the dwFlags parameter of ITextStoreACP::InsertEmbedded and ITextStoreAnchor::InsertEmbedded.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/tsf/ts-ie--constants
	[PInvokeData("textstor.h", MSDNShortId = "NN:textstor.ITextStoreACP")]
	public enum TS_IE : uint
	{
		/// <summary>
		/// The text is a transform (correction) of existing content, and any special text markup information (metadata) is retained,
		/// such as .wav file data or a language identifier.
		/// </summary>
		TS_IE_CORRECTION = 0x1,

		/// <summary>Not used.</summary>
		[Obsolete("Not used.")]
		TS_IE_COMPOSITION = 0x2,
	}

	/// <summary>Specifies the type of lock requested.</summary>
	[PInvokeData("textstor.h")]
	[Flags]
	public enum TS_LF : uint
	{
		/// <summary>The document has a synchronous-lock if this flag is combined with other flags.</summary>
		TS_LF_SYNC = 0x1,

		/// <summary>The document has a read-only lock and cannot be modified.</summary>
		TS_LF_READ = 0x2,

		/// <summary>The document has a read/write lock and can be modified.</summary>
		TS_LF_READWRITE = 0x6,
	}

	/// <summary>
	/// A set of flags that can be changed by an app at run time. For example, an app can enable a check box for the user to reset the
	/// status of documentation. This member can contain zero, or one or more of the following values.
	/// </summary>
	[PInvokeData("textstor.h")]
	[Flags]
	public enum TS_SD : uint
	{
		/// <summary>The document is read-only.</summary>
		TS_SD_READONLY = 0x001,

		/// <summary>The document is loading.</summary>
		TS_SD_LOADING = 0x002,

		/// <summary>Reserved</summary>
		TS_SD_RESERVED = 0x004,

		/// <summary>
		/// Starting with Windows 8.1: The document supports autocorrection provided by the touch keyboard. This support can change
		/// during the lifetime of the control.
		/// </summary>
		TS_SD_TKBAUTOCORRECTENABLE = 0x008,   // document owner sets this flag in order to receive auto-correction from the Windows touch keyboard

		/// <summary>
		/// Starting with Windows 8.1: The document supports text suggestions provided by the touch keyboard. This support can change
		/// during the lifetime of the control.
		/// </summary>
		TS_SD_TKBPREDICTIONENABLE = 0x010,   // document owner sets this flag in order to receive prediction from the Windows touch keyboard

		/// <summary>
		/// Starting with Windows 8.1: The text control owning the document sets this flag to indicate its support of Input Method
		/// Editor (IME) UI integration. When specified, the IME should attempt to align the candidate window below the text box instead
		/// of floating near the cursor.
		/// </summary>
		TS_SD_UIINTEGRATIONENABLE = 0x020,   // indicates that text control supports IME UI integration

		/// <summary>used by UWP text controls to disable default automatic SIP invocation</summary>
		TS_SD_INPUTPANEMANUALDISPLAYENABLE = 0x040,     //

		/// <summary>used by UWP text controls to enable embedded handwriting</summary>
		TS_SD_EMBEDDEDHANDWRITINGVIEW_ENABLED = 0x080,  //

		/// <summary>used by UWP text controls to show/hide embedded handwriting view</summary>
		TS_SD_EMBEDDEDHANDWRITINGVIEW_VISIBLE = 0x100,  //
	}

	/// <summary>
	/// The TS_Shift_* constants are used by the <c>IAnchor</c> interface for manipulation of hidden text and character counting.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/tsf/ts-shift--constants
	[PInvokeData("textstor.h")]
	[Flags]
	public enum TS_SHIFT : uint
	{
		/// <summary>
		/// Specifies that the anchor will be shifted to the next region boundary, including the boundary of a hidden text region. If
		/// not set, the anchor will be shifted past any adjacent hidden text until a region of visible text is found.
		/// </summary>
		TS_SHIFT_COUNT_HIDDEN = 0x1,

		/// <summary>Not used.</summary>
		[Obsolete("Not used.")]
		TS_SHIFT_HALT_HIDDEN = 0x2,

		/// <summary>Not used.</summary>
		TS_SHIFT_HALT_VISIBLE = 0x4,

		/// <summary>The anchor is not shifted.</summary>
		TS_SHIFT_COUNT_ONLY = 0x8,
	}

	/// <summary>
	/// A set of flags that cannot be changed at run time. This member can contain zero, or one or more of the following values.
	/// </summary>
	[PInvokeData("textstor.h")]
	[Flags]
	public enum TS_SS : uint
	{
		/// <summary>The document supports multiple selections.</summary>
		TS_SS_DISJOINTSEL = 0x001,

		/// <summary>The document can contain multiple regions.</summary>
		TS_SS_REGIONS = 0x002,

		/// <summary>The document is expected to have a short usage cycle.</summary>
		TS_SS_TRANSITORY = 0x004,

		/// <summary>if set, the document will never contain hidden text (for perf)</summary>
		TS_SS_NOHIDDENTEXT = 0x008,

		/// <summary>Starting with Windows 8: The document supports autocorrection provided by the touch keyboard.</summary>
		TS_SS_TKBAUTOCORRECTENABLE = 0x010,   // document owner sets this flag in order to receive auto-correction from the Windows touch keyboard

		/// <summary>Starting with Windows 8: The document supports text suggestions provided by the touch keyboard.</summary>
		TS_SS_TKBPREDICTIONENABLE = 0x020,   // document owner sets this flag in order to receive prediction from the Windows touch keyboard

		/// <summary>document is provided on behalf of a UWP control</summary>
		TS_SS_UWPCONTROL = 0x040,   //
	}

	/// <summary>ITextStoreACP::SetText, ITextStoreAnchor::SetText, or ITextStoreACPSink::OnTextChange parameters.</summary>
	[PInvokeData("textstor.h")]
	[Flags]
	public enum TS_ST : uint
	{
		/// <summary>None.</summary>
		TS_ST_NONE = 0x0,

		/// <summary>
		/// The text is a transform (correction) of existing content, and any special text markup information (metadata) is retained,
		/// such as .wav file data or a language identifier. The client defines the type of markup information to be retained.
		/// </summary>
		TS_ST_CORRECTION = 0x1,
	}

	/// <summary>ITextStoreAnchorSink::OnTextChange paramneter.</summary>
	[PInvokeData("textstor.h")]
	[Flags]
	public enum TS_TC : uint
	{
		/// <summary>None.</summary>
		TS_TC_NONE = 0x0,

		/// <summary>
		/// If dwFlags parameter of ITextStoreAnchorSink::OnTextChange is set to this value, the text is a transform (correction) of
		/// existing content, and any special text markup information (metadata) is retained, such as .wav file data or a language identifier.
		/// </summary>
		TS_TC_CORRECTION = 0x1,
	}

	/// <summary>Elements of the <c>TsActiveSelEnd</c> enumeration specify which end of a text store selection is active.</summary>
	/// <remarks>
	/// <para>
	/// The active end of a selection is the end likely to respond to user actions. For example, in many applications, holding down the
	/// SHIFT key while using the arrow keys will change the selection. The end of the selection that moves is the active end of the selection.
	/// </para>
	/// <para>This enumeration is used in the TS_SELECTIONSTYLE structure.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/textstor/ne-textstor-tsactiveselend
	[PInvokeData("textstor.h", MSDNShortId = "NE:textstor.__MIDL___MIDL_itf_textstor_0000_0000_0001")]
	[Guid("05FCF85B-5E9C-4C3E-AB71-29471D4F38E7")]
	public enum TsActiveSelEnd : uint
	{
		/// <summary>The selection has no active end. This is typical for all selections other than the default selection.</summary>
		TS_AE_NONE,

		/// <summary>The active end of the selection is at the start of the range of text.</summary>
		TS_AE_START,

		/// <summary>The active end of the selection is at the end of the range of text.</summary>
		TS_AE_END,
	}

	/// <summary>Elements of the <c>TsGravity</c> enumeration specify the gravity type associated with an IAnchor object.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/textstor/ne-textstor-tsgravity
	[PInvokeData("textstor.h", MSDNShortId = "NE:textstor.__MIDL_IAnchor_0001")]
	[Guid("DAA8601E-7695-426F-9BB7-498A6AA64B68")]
	public enum TsGravity : uint
	{
		/// <summary>The anchor has backward gravity. For more information about anchor gravity, see Ranges.</summary>
		TS_GR_BACKWARD,

		/// <summary>The anchor has forward gravity. For more information about anchor gravity, see Ranges.</summary>
		TS_GR_FORWARD,
	}

	/// <summary>
	/// Elements of the <c>TsLayoutCode</c> enumeration are used to specify the type of layout change in an
	/// ITextStoreACPSink::OnLayoutChange or ITextStoreAnchorSink::OnLayoutChange notification.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/textstor/ne-textstor-tslayoutcode
	[PInvokeData("textstor.h", MSDNShortId = "NE:textstor.__MIDL___MIDL_itf_textstor_0000_0000_0002")]
	[Guid("7899D7C4-5F07-493C-A89A-FAC8E777F476")]
	public enum TsLayoutCode : uint
	{
		/// <summary>The view has just been created.</summary>
		TS_LC_CREATE,

		/// <summary>The view layout has changed.</summary>
		TS_LC_CHANGE,

		/// <summary>The view is about to be destroyed.</summary>
		TS_LC_DESTROY,
	}

	/// <summary>
	/// Elements of the <c>TsRunType</c> enumeration specify if a text run is visible, hidden, or is a private data type embedded in the
	/// text run.
	/// </summary>
	/// <remarks>
	/// <para>
	/// A text run is a collection of consecutive characters that is visible, hidden, or contains embedded data. For example, the text,
	/// Hello World in HTML might be &lt;b&gt;Hello &lt;/b&gt;&lt;i&gt;World&lt;/i&gt;. This text would be defined using the TsRunType
	/// as in the following.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Text Run</term>
	/// <term>Value</term>
	/// </listheader>
	/// <item>
	/// <term>&lt;b&gt;</term>
	/// <term>TS_RT_HIDDEN</term>
	/// </item>
	/// <item>
	/// <term>Hello&lt;space&gt;</term>
	/// <term>TS_RT_PLAIN</term>
	/// </item>
	/// <item>
	/// <term>&lt;/b&gt;</term>
	/// <term>TS_RT_HIDDEN</term>
	/// </item>
	/// <item>
	/// <term>&lt;i&gt;</term>
	/// <term>TS_RT_HIDDEN</term>
	/// </item>
	/// <item>
	/// <term>World</term>
	/// <term>TS_RT_PLAIN</term>
	/// </item>
	/// <item>
	/// <term>&lt;/i&gt;</term>
	/// <term>TS_RT_HIDDEN</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/textstor/ne-textstor-tsruntype
	[PInvokeData("textstor.h", MSDNShortId = "NE:textstor.__MIDL___MIDL_itf_textstor_0000_0000_0003")]
	[Guid("033B0DF0-F193-4170-B47B-141AFC247878")]
	public enum TsRunType : uint
	{
		/// <summary>The text run is visible.</summary>
		TS_RT_PLAIN,

		/// <summary>The text run is hidden.</summary>
		TS_RT_HIDDEN,

		/// <summary>The text run is a private data type embedded in the text run.</summary>
		TS_RT_OPAQUE,
	}

	/// <summary>Elements of the <c>TsShiftDir</c> enumeration specify which direction an anchor is moved.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/textstor/ne-textstor-tsshiftdir
	[PInvokeData("textstor.h", MSDNShortId = "NE:textstor.__MIDL_IAnchor_0002")]
	[Guid("898E19DF-4FB4-4AF3-8DAF-9B3C1145C79D")]
	public enum TsShiftDir : uint
	{
		/// <summary>Specifies that the anchor will be moved to the region immediately preceding a range of text.</summary>
		TS_SD_BACKWARD,

		/// <summary>Specifies that the anchor will be moved to the region immediately following a range of text.</summary>
		TS_SD_FORWARD,
	}

	/// <summary>
	/// <para>
	/// The <c>IAnchor</c> interface is implemented by the TSF manager. Clients of Microsoft Active Accessibility use <c>IAnchor</c>
	/// anchor objects to delimit a range of text within a text stream.
	/// </para>
	/// <para>The interface ID is IID_IAnchor.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nn-textstor-ianchor
	[PInvokeData("textstor.h", MSDNShortId = "NN:textstor.IAnchor")]
	[ComImport, Guid("0FEB7E34-5A60-4356-8EF7-ABDEC2FF7CF8"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAnchor
	{
		/// <summary>Sets the gravity of the anchor.</summary>
		/// <param name="gravity">
		/// Contains a value from the TsGravity enumeration that specifies a new forward or backward gravity for the anchor.
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-ianchor-setgravity HRESULT SetGravity( TsGravity
		// gravity );
		void SetGravity([In] TsGravity gravity);

		/// <summary>The <c>IAnchor::GetGravity</c> method retrieves the gravity of the anchor in an IAnchor object.</summary>
		/// <returns>Pointer that receives a TsGravity value that specifies the anchor gravity.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-ianchor-getgravity HRESULT GetGravity( TsGravity
		// *pgravity );
		TsGravity GetGravity();

		/// <summary>
		/// The <c>IAnchor::IsEqual</c> method evaluates two anchors within a text stream and returns a Boolean value that specifies the
		/// equality or inequality of the anchor positions.
		/// </summary>
		/// <param name="paWith">
		/// Specifies an anchor to compare to the primary anchor. Used to determine the equality of the two anchor positions.
		/// </param>
		/// <returns>
		/// A Boolean value that specifies whether the two anchors are positioned at the same location. If set to <c>TRUE</c>, the two
		/// anchors occupy the same location. If set to <c>FALSE</c>, the two anchors do not occupy the same location.
		/// </returns>
		/// <remarks>
		/// <para>
		/// Anchors are always positioned between characters or regions. When two anchors are between the same characters, being at the
		/// same offset within the text stream, and within the same region, <c>IAnchor::IsEqual</c> returns <c>TRUE</c>. Otherwise it
		/// returns <c>FALSE</c>.
		/// </para>
		/// <para>
		/// IAnchor::Compare incorporates the same functionality as <c>IAnchor::IsEqual</c>. However, because <c>IAnchor::IsEqual</c> is
		/// more specific, it can have a more efficient implementation on the server.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-ianchor-isequal HRESULT IsEqual( IAnchor *paWith,
		// BOOL *pfEqual );
		[return: MarshalAs(UnmanagedType.Bool)]
		bool IsEqual([In] IAnchor paWith);

		/// <summary>The <c>IAnchor::Compare</c> method compares the relative position of two anchors within a text stream.</summary>
		/// <param name="paWith">
		/// An anchor object to compare to the primary anchor. Used to determine the relative position of the two anchors.
		/// </param>
		/// <returns>
		/// <para>Result of the comparison of the positions of the two anchors.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>-1</term>
		/// <term>The primary anchor is positioned earlier in the text stream than paWith.</term>
		/// </item>
		/// <item>
		/// <term>0</term>
		/// <term>The primary anchor is positioned at the same location as paWith.</term>
		/// </item>
		/// <item>
		/// <term>+1</term>
		/// <term>The primary anchor is positioned later in the text stream than paWith.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// The value 0 is returned for *plResult only when the two anchors are in a single region. Anchor positions include the spaces
		/// between regions. If you only need to determine if the two anchors are positioned at the same location, IAnchor::IsEqual is
		/// more efficient.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-ianchor-compare HRESULT Compare( IAnchor *paWith,
		// LONG *plResult );
		int Compare([In] IAnchor paWith);

		/// <summary>The <c>IAnchor::Shift</c> method shifts the anchor forward or backward within a text stream.</summary>
		/// <param name="dwFlags">
		/// <para>Bit fields that are used to avoid anchor positioning.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TS_SHIFT_COUNT_ONLY</term>
		/// <term>
		/// The anchor is not shifted. If the flag is not set (dwFlags = 0), the anchor will be shifted as specified by the other
		/// parameter settings.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="cchReq">The number of characters to move the anchor within the text stream.</param>
		/// <param name="pcch">
		/// The actual number of characters moved within the text stream. The method will set pcch to zero if it fails.
		/// </param>
		/// <param name="paHaltAnchor">Reference to an anchor that blocks the shift. Set to <c>NULL</c> to avoid blocking the shift.</param>
		/// <remarks>
		/// <para>
		/// cchReq and pcch parameters can be negative, meaning a shift backward in the text stream, or positive, meaning a shift
		/// forward. The actual number of characters shifted can be less than cchReq if the beginning or end of the document is
		/// encountered, a region boundary is encountered, or if paHaltAnchor receives an anchor that blocks the shift.
		/// </para>
		/// <para>
		/// If paHaltAnchor receives an anchor that blocks the shift, the application will truncate the shift at the position occupied
		/// by paHaltAnchor. If paHaltAnchor is not within the span of text covered by the shift, it has no relevance to the shift and
		/// is ignored.
		/// </para>
		/// <para>
		/// For example, if the anchor referenced by paHaltAnchor lies 8 characters ahead of the anchor in the stream, and a client
		/// calls <c>Shift</c> (0, 10, pcch, paHaltAnchor), then on exit the anchor will have moved only 8 characters. If the anchor
		/// referenced by paHaltAnchor is equal to the current anchor to be moved, then <c>Shift</c> will return successfully without
		/// moving the anchor at all. In this case pcch will be 0.
		/// </para>
		/// <para>
		/// The anchor shift is always blocked by region boundaries, as if the beginning or end of the document were encountered. This
		/// will be indicated on exit by the actual shift pcch being smaller in absolute value than the requested shift cchReq. In this
		/// case, clients can use IAnchor::ShiftRegion to shift the anchor into an adjacent region.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-ianchor-shift HRESULT Shift( DWORD dwFlags, LONG
		// cchReq, LONG *pcch, IAnchor *paHaltAnchor );
		void Shift([In] uint dwFlags, [In] int cchReq, out int pcch, [In] IAnchor paHaltAnchor);

		/// <summary>The <c>IAnchor::ShiftTo</c> method shifts the current anchor to the same position as another anchor.</summary>
		/// <param name="paSite">Anchor occupying a position that the current anchor will be moved to.</param>
		/// <remarks>Implementing this method is usually more efficient than an equivalent IAnchor::Shift operation.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-ianchor-shiftto HRESULT ShiftTo( IAnchor *paSite );
		void ShiftTo([In] IAnchor paSite);

		/// <summary>Shifts the anchor into an adjacent region in the text stream.</summary>
		/// <param name="dwFlags">
		/// <para>
		/// Bitfields that are used to control anchor repositioning around hidden text, or to avoid actual repositioning of the anchor.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TS_SHIFT_COUNT_HIDDEN</term>
		/// <term>
		/// Specifies that the anchor will be shifted to the next region boundary, including the boundary of a hidden text region. If
		/// not set, the anchor will be shifted past any adjacent hidden text until a region of visible text is found.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TS_SHIFT_COUNT_ONLY</term>
		/// <term>The anchor is not shifted.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="dir">
		/// <para>Contains one of the TsShiftDir values that specifies which adjacent region the anchor is moved to.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TS_SD_BACKWARD</term>
		/// <term>Specifies that the anchor will be moved to the region immediately preceding a range of text.</term>
		/// </item>
		/// <item>
		/// <term>TS_SD_FORWARD</term>
		/// <term>Specifies that the anchor will be moved to the region immediately following a range of text.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Boolean value that specifies whether a shift of the anchor occurred.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TRUE</term>
		/// <term>The shift failed, and the anchor was not repositioned.</term>
		/// </item>
		/// <item>
		/// <term>FALSE</term>
		/// <term>The shift succeeded.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-ianchor-shiftregion HRESULT ShiftRegion( DWORD
		// dwFlags, TsShiftDir dir, BOOL *pfNoRegion );
		[return: MarshalAs(UnmanagedType.Bool)]
		bool ShiftRegion([In] uint dwFlags, [In] TsShiftDir dir);

		/// <summary>This method has not been implemented.</summary>
		/// <param name="dwMask">Not used.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-ianchor-setchangehistorymask HRESULT
		// SetChangeHistoryMask( DWORD dwMask );
		void SetChangeHistoryMask([In, Optional] uint dwMask);

		/// <summary>
		/// The <c>IAnchor::GetChangeHistory</c> method gets the history of deletions that have occurred immediately preceding or
		/// following the anchor.
		/// </summary>
		/// <returns>
		/// <para>
		/// Bit field flags that specify that deletions have occurred immediately preceding or following the anchor. One or both of the
		/// following values can be set.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TS_CH_PRECEDING_DEL</term>
		/// <term>Text preceding the anchor has been deleted.</term>
		/// </item>
		/// <item>
		/// <term>TS_CH_FOLLOWING_DEL</term>
		/// <term>Text following the anchor has been deleted.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The pdwHistory change flags must be set when deletions adjacent to the anchor have occurred.</para>
		/// <para>The change flags remain set until they are cleared with a call to IAnchor::ClearChangeHistory.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-ianchor-getchangehistory HRESULT GetChangeHistory(
		// DWORD *pdwHistory );
		TS_CH GetChangeHistory();

		/// <summary>The <c>IAnchor::ClearChangeHistory</c> method clears the anchor change history flags.</summary>
		/// <remarks>
		/// Applications should clear the anchor change history flags after receiving this call. The change history flags were set by IAnchor::GetChangeHistory.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-ianchor-clearchangehistory HRESULT ClearChangeHistory();
		void ClearChangeHistory();

		/// <summary>
		/// The <c>IAnchor::Clone</c> method produces a new anchor object positioned at the same location, and with the same gravity, as
		/// the current anchor.
		/// </summary>
		/// <returns>A new anchor object, identical to the current anchor.</returns>
		/// <remarks>The change history and change history masks are both cleared in the cloned anchor.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-ianchor-clone HRESULT Clone( IAnchor **ppaClone );
		IAnchor Clone();
	}

	/// <summary>
	/// <para>
	/// The <c>ITextStoreACP</c> interface is implemented by the application and is used by the TSF manager to manipulate text streams
	/// or text stores in TSF. An application can obtain an instance of this interface with a call to the ITfDocumentMgr::CreateContext
	/// method. The interface ID is IID_ITextStoreACP.
	/// </para>
	/// <para>
	/// This interface exposes text stores through an application character position (ACP) format. Applications that use an anchor-based
	/// format should use ITextStoreAnchor.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nn-textstor-itextstoreacp
	[PInvokeData("textstor.h", MSDNShortId = "NN:textstor.ITextStoreACP")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("28888FE3-C2A0-483A-A3EA-8CB1CE51FF3D")]
	public interface ITextStoreACP
	{
		/// <summary>
		/// The <c>ITextStoreACP::AdviseSink</c> method installs a new advise sink from the ITextStoreACPSink interface or modifies an
		/// existing advise sink. The sink interface is specified by the punk parameter.
		/// </summary>
		/// <param name="riid">Specifies the sink interface.</param>
		/// <param name="punk">Pointer to the sink interface. Cannot be <c>NULL</c>.</param>
		/// <param name="dwMask">
		/// Specifies the events that notify the advise sink. For more information about possible parameter values, see TS_AS_* Constants.
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>CONNECT_E_ADVISELIMIT</term>
		/// <term>A sink interface pointer could not be obtained.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The specified sink interface is unsupported.</term>
		/// </item>
		/// <item>
		/// <term>E_UNEXPECTED</term>
		/// <term>The specified sink object could not be obtained.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Subsequent calls with the same interface, represented by the punk parameter, are handled as requests to update the dwMask
		/// parameter. Servers should not call the <c>AddRef</c> method on the sink in response to such a request.
		/// </para>
		/// <para>
		/// Servers only maintain a single connection point. Attempts to advise a second sink object fail until the original sink object
		/// is removed. Applications should use the ITextStoreACP::UnadviseSink method to unregister the sink object when notifications
		/// are not required.
		/// </para>
		/// <para>Use this method to get the ITextStoreACPServices interface.</para>
		/// <para>Examples</para>
		/// <para>CMyTextEditor ITextStoreACP</para>
		/// <para>
		/// <code> STDMETHODIMP CMyTextEditor::AdviseSink(REFIID riid, IUnknown *punk, DWORD dwMask) { HRESULT hr; IUnknown *punkID; typedef struct { IUnknown *punkID; ITextStoreACPSink *pTextStoreACPSink; DWORD dwMask; }ADVISE_SINK, *PADVISE_SINK; // Determine if the sink interface exists. // Get the pointer to the IUnknown interface and check if the IUnknown // pointer is the same as a pointer to an existing sink. // If the sink exists, update the existing sink with the // dwMask parameters passed to this method. hr = QueryInterface(IID_IUnknown, (LPVOID*)&amp;punkID); if(FAILED(hr)) { hr = E_INVALIDARG; } if(punkID == m_AdviseSink.punkID) { m_AdviseSink.dwMask = dwMask; hr = S_OK; } // If the sink does not exist, do the following: // 1. Install a new sink. // 2. Keep the pointer to the IUnknown interface to uniquely // identify this advise sink. // 3. Set the dwMask parameter of this new sink to the dwMask // parameters passed to this method. // 4. Increment the reference count. // 5. Release the IUnknown pointer, since this pointer is no // longer required. if(IsEqualIID(riid, IID_ITextStoreACPSink)) { punk-&gt;QueryInterface(IID_ITextStoreACPSink, (LPVOID*)&amp;m_AdviseSink.pTextStoreACPSink); m_AdviseSink.punkID = punkID; m_AdviseSink.dwMask = dwMask; punkID-&gt;AddRef(); punkID-&gt;Release(); hr = S_OK; } return hr; }</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreacp-advisesink HRESULT AdviseSink( REFIID
		// riid, IUnknown *punk, DWORD dwMask );
		[PreserveSig]
		HRESULT AdviseSink(in Guid riid, [In, MarshalAs(UnmanagedType.IUnknown)] object punk, [In] TS_AS dwMask);

		/// <summary>
		/// The <c>ITextStoreACP::UnadviseSink</c> method is called by an application to indicate that it no longer requires
		/// notifications from the TSF manager. The TSF manager will release the sink interface and stop notifications.
		/// </summary>
		/// <param name="punk">Pointer to a sink object. Cannot be <c>NULL</c>.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>CONNECT_E_NOCONNECTION</term>
		/// <term>There is no active sink object.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Every call to the ITextStoreAnchor::AdviseSink method, which registers a new sink object, should be matched by a call to
		/// this method. Calls to the <c>ITextStoreAnchor::AdviseSink</c> method that only update the dwMask parameter of a sink which
		/// was previously registered, do not require a call to the ITextStoreAnchor::UnadviseSink method.
		/// </para>
		/// <para>
		/// For example, to register a sink object, an application calls the <c>ITextStoreAnchor::AdviseSink</c> method the first time.
		/// After registering the sink object, the application can call the <c>ITextStoreAnchor::AdviseSink</c> method again with the
		/// same sink object to change the dwMask parameter. To unregister the sink object, an application calls the
		/// <c>ITextStoreAnchor::UnadviseSink</c> method.
		/// </para>
		/// <para>
		/// The punk parameter must have the same COM identity as the pointer originally passed in the
		/// <c>ITextStoreAnchor::AdviseSink</c> method.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreacp-unadvisesink HRESULT UnadviseSink(
		// IUnknown *punk );
		[PreserveSig]
		HRESULT UnadviseSink([In, MarshalAs(UnmanagedType.IUnknown)] object punk);

		/// <summary>
		/// The <c>ITextStoreACP::RequestLock</c> method is called by the TSF manager to provide a document lock in order to modify the
		/// document. This method calls the ITextStoreACPSink::OnLockGranted method to create the document lock.
		/// </summary>
		/// <param name="dwLockFlags">
		/// <para>Specifies the type of lock requested.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TS_LF_READ</term>
		/// <term>The document has a read-only lock and cannot be modified.</term>
		/// </item>
		/// <item>
		/// <term>TS_LF_READWRITE</term>
		/// <term>The document has a read/write lock and can be modified.</term>
		/// </item>
		/// <item>
		/// <term>TS_LF_SYNC</term>
		/// <term>The document has a synchronous-lock if this flag is combined with other flags.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="phrSession">
		/// <para>
		/// If the lock request is synchronous, receives an HRESULT value from the ITextStoreAnchorSink::OnLockGranted method that
		/// specifies the result of the lock request.
		/// </para>
		/// <para>
		/// If the lock request is asynchronous and the result is TS_S_ASYNC, the document receives an asynchronous lock. If the lock
		/// request is asynchronous and the result is TS_E_SYNCHRONOUS, the document cannot be locked synchronously.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>An unspecified error occurred.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method uses the <c>ITextStoreACPSink::OnLockGranted</c> method to lock the document. Applications must never modify the
		/// document or send change notifications using the ITextStoreACPSink::OnTextChange method from within the
		/// <c>ITextStoreACP::RequestLock</c> method. If the application has pending changes to report, the application can only respond
		/// to the asynchronous lock request.
		/// </para>
		/// <para>
		/// Applications should not attempt to queue multiple <c>ITextStoreACP::RequestLock</c> method calls, because the application
		/// requires only a single callback. If the caller makes several read requests and one or more write requests, however, the
		/// callback should be for write access.
		/// </para>
		/// <para>
		/// Successful requests for synchronous locks supersede requests for asynchronous locks. Unsuccessful requests for synchronous
		/// locks do not supersede requests for asynchronous locks. The implementation must still serve the outstanding asynchronous
		/// request, if one exists.
		/// </para>
		/// <para>
		/// If the lock is granted before the <c>ITextStoreACP::RequestLock</c> method returns, the phrSession parameter will receive
		/// the HRESULT returned by the <c>ITextStoreACPSink::OnLockGranted</c> method. If the call is successful, but the lock will be
		/// granted later, the phrSession parameter receives the TS_S_ASYNC flag. The phrSession parameter should be ignored if
		/// <c>ITextStoreACP::RequestLock</c> returns anything other than S_OK.
		/// </para>
		/// <para>
		/// A caller should never call this method reentrantly, except in the case that the caller holds a read-only lock. In this case
		/// the method can be called reentrantly to ask for an asynchronous write lock. The write lock will be granted later, after the
		/// read-only lock ends.
		/// </para>
		/// <para>For more information about document locks, see Document Locks.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreacp-requestlock HRESULT RequestLock( DWORD
		// dwLockFlags, HRESULT *phrSession );
		[PreserveSig]
		HRESULT RequestLock([In] TS_LF dwLockFlags, out HRESULT phrSession);

		/// <summary>
		/// The <c>ITextStoreACP::GetStatus</c> method obtains the document status. The document status is returned through the
		/// TS_STATUS structure.
		/// </summary>
		/// <param name="pdcs">Receives the <c>TS_STATUS</c> structure that contains the document status. Cannot be <c>NULL</c>.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The pointer to the TS_STATUS parameter is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreacp-getstatus HRESULT GetStatus( TS_STATUS
		// *pdcs );
		[PreserveSig]
		HRESULT GetStatus(out TS_STATUS pdcs);

		/// <summary>
		/// The <c>ITextStoreACP::QueryInsert</c> method determines whether the specified start and end character positions are valid.
		/// Use this method to adjust an edit to a document before executing the edit. The method must not return values outside the
		/// range of the document.
		/// </summary>
		/// <param name="acpTestStart">Starting application character position for inserted text.</param>
		/// <param name="acpTestEnd">
		/// Ending application character position for the inserted text. This value is equal to acpTextStart if the text is inserted at
		/// a point instead of replacing selected text.
		/// </param>
		/// <param name="cch">Length of replacement text.</param>
		/// <param name="pacpResultStart">
		/// Returns the new starting application character position of the inserted text. If this parameter is <c>NULL</c>, then text
		/// cannot be inserted at the specified position. This value cannot be outside the document range.
		/// </param>
		/// <param name="pacpResultEnd">
		/// Returns the new ending application character position of the inserted text. If this parameter is <c>NULL</c>, then
		/// pacpResultStart is set to <c>NULL</c> and text cannot be inserted at the specified position. This value cannot be outside
		/// the document range.
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>An unspecified error occurred.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The acpTestStart or acpTestEnd parameters are invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// The values of pacpResultStart and pacpResultEnd depend upon how the application inserts text into the document. If
		/// pacpResultStart and pacpResultEnd are the same as acpTextStart, the cursor is at the beginning of the inserted text after
		/// insertion. If pacpResultStart and pacpResultEnd are the same as acpTextEnd, the cursor is at the end of the inserted text
		/// after insertion. If the difference between pacpResultStart and pacpResultEnd is equal to the length of the inserted text,
		/// the inserted text is highlighted after insertion.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreacp-queryinsert HRESULT QueryInsert( LONG
		// acpTestStart, LONG acpTestEnd, ULONG cch, LONG *pacpResultStart, LONG *pacpResultEnd );
		[PreserveSig]
		HRESULT QueryInsert([In] int acpTestStart, [In] int acpTestEnd, [In] uint cch, out int pacpResultStart, out int pacpResultEnd);

		/// <summary>
		/// The <c>ITextStoreACP::GetSelection</c> method returns the character position of a text selection in a document. This method
		/// supports multiple text selections. The caller must have a read-only lock on the document before calling this method.
		/// </summary>
		/// <param name="ulIndex">
		/// Specifies the text selections that start the process. If the TF_DEFAULT_SELECTION constant is specified for this parameter,
		/// the input selection starts the process.
		/// </param>
		/// <param name="ulCount">Specifies the maximum number of selections to return.</param>
		/// <param name="pSelection">
		/// Receives the style, start, and end character positions of the selected text. These values are put into the TS_SELECTION_ACP structure.
		/// </param>
		/// <param name="pcFetched">Receives the number of pSelection structures returned.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_NOLOCK</term>
		/// <term>The caller does not have a read-only lock on the document.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_NOSELECTION</term>
		/// <term>The document has no selection.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreacp-getselection HRESULT GetSelection(
		// ULONG ulIndex, ULONG ulCount, TS_SELECTION_ACP *pSelection, ULONG *pcFetched );
		[PreserveSig]
		HRESULT GetSelection([In] uint ulIndex, [In] uint ulCount, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] TS_SELECTION_ACP[] pSelection, [NullAllowed] out uint pcFetched);

		/// <summary>
		/// The <c>ITextStoreACP::SetSelection</c> method selects text within the document. The application must have a read/write lock
		/// on the document before calling this method.
		/// </summary>
		/// <param name="ulCount">Specifies the number of text selections in pSelection.</param>
		/// <param name="pSelection">
		/// <para>Specifies the style, start, and end character positions of the text selected through the TS_SELECTION_ACP structure.</para>
		/// <para>
		/// When the start and end character positions are equal, the method places a caret at that character position. There can be
		/// only one caret at a time in the document.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>An unspecified error occurred.</term>
		/// </item>
		/// <item>
		/// <term>TF_E_INVALIDPOS</term>
		/// <term>The character positions specified are beyond the text in the document.</term>
		/// </item>
		/// <item>
		/// <term>TF_E_NOLOCK</term>
		/// <term>The caller does not have a read/write lock.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreacp-setselection HRESULT SetSelection(
		// ULONG ulCount, const TS_SELECTION_ACP *pSelection );
		[PreserveSig]
		HRESULT SetSelection([In] uint ulCount, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] TS_SELECTION_ACP[] pSelection);

		/// <summary>
		/// The <c>ITextStoreACP::GetText</c> method returns information about text at a specified character position. This method
		/// returns the visible and hidden text and indicates if embedded data is attached to the text.
		/// </summary>
		/// <param name="acpStart">Specifies the starting character position.</param>
		/// <param name="acpEnd">
		/// Specifies the ending character position. If this parameter is 1, then return all text in the text store.
		/// </param>
		/// <param name="pchPlain">
		/// Specifies the buffer to receive the plain text data. If this parameter is <c>NULL</c>, then the cchPlainReq parameter must
		/// be 0.
		/// </param>
		/// <param name="cchPlainReq">Specifies the number of plain text characters passed to the method.</param>
		/// <param name="pcchPlainRet">
		/// Receives the number of characters copied into the plain text buffer. This parameter cannot be <c>NULL</c>. Use a parameter
		/// if values are not required.
		/// </param>
		/// <param name="prgRunInfo">Receives an array of TS_RUNINFO structures. May be <c>NULL</c> only if cRunInfoReq = 0.</param>
		/// <param name="cRunInfoReq">Specifies the size, in characters, of the text run buffer.</param>
		/// <param name="pcRunInfoRet">
		/// Receives the number of <c>TS_RUNINFO</c> structures written to the text run buffer. This parameter cannot be <c>NULL</c>.
		/// </param>
		/// <param name="pacpNext">Receives the character position of the next unread character. Cannot be <c>NULL</c>.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>TF_E_INVALIDPOS</term>
		/// <term>The acpStart or acpEnd parameters are outside of the document text.</term>
		/// </item>
		/// <item>
		/// <term>TF_E_NOLOCK</term>
		/// <term>The caller does not have a read-only lock on the document.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Callers that use this method must have a read-only lock on the document by calling the <c>ITextStoreACP::RequestLock</c>
		/// method. Without a read-only lock, the method fails and returns TF_E_NOLOCK.
		/// </para>
		/// <para>
		/// Applications can also truncate the method return values for internal reasons. Callers should carefully examine the return
		/// characters and text run counts to get the required return values. If the return values are incomplete, repeatedly call the
		/// method until the return values are complete.
		/// </para>
		/// <para>
		/// The caller can request plain text only by setting the cRunInfoReq parameter to 0 and the prgRunInfo parameter to
		/// <c>NULL</c>. The caller can request only text run data by setting the cchPlainReq parameter to 0 and the pchPlain parameter
		/// to <c>NULL</c>. However, the caller must still supply valid non- <c>null</c> values for pcchPlainRet, even if this parameter
		/// is not used.
		/// </para>
		/// <para>
		/// If acpEnd is -1, then it should be handled as if set at the end of the stream. Otherwise, it will be greater than or equal
		/// to zero.
		/// </para>
		/// <para>
		/// On exit, pacpNext should be set to the character position of the next character in the stream not referenced by the return
		/// values. A caller would use this to quickly scan text with multiple ITextStoreACP::GetText calls.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreacp-gettext HRESULT GetText( LONG acpStart,
		// LONG acpEnd, WCHAR *pchPlain, ULONG cchPlainReq, ULONG *pcchPlainRet, TS_RUNINFO *prgRunInfo, ULONG cRunInfoReq, ULONG
		// *pcRunInfoRet, LONG *pacpNext );
		[PreserveSig]
		HRESULT GetText([In] int acpStart, [In] int acpEnd, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pchPlain, [In] uint cchPlainReq,
			out uint pcchPlainRet, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 7)] TS_RUNINFO[] prgRunInfo, [In] uint cRunInfoReq, out uint pcRunInfoRet, out int pacpNext);

		/// <summary>The <c>ITextStoreACP::SetText</c> method sets the text selection to the supplied character positions.</summary>
		/// <param name="dwFlags">
		/// If set to the value of TS_ST_CORRECTION, the text is a transform (correction) of existing content, and any special text
		/// markup information (metadata) is retained, such as .wav file data or a language identifier. The client defines the type of
		/// markup information to be retained.
		/// </param>
		/// <param name="acpStart">Specifies the starting character position of the text to replace.</param>
		/// <param name="acpEnd">
		/// Specifies the ending character position of the text to replace. This parameter is ignored if the value is 1.
		/// </param>
		/// <param name="pchText">
		/// Specifies the pointer to the replacement text. The text string does not have to be <c>NULL</c> terminated, because the text
		/// character count is specified in the cch parameter.
		/// </param>
		/// <param name="cch">Specifies the number of characters in the replacement text.</param>
		/// <param name="pChange">
		/// <para>Pointer to a TS_TEXTCHANGE structure with the following data.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>acpStart</term>
		/// <term>The starting application character position before the text is inserted into the document.</term>
		/// </item>
		/// <item>
		/// <term>acpOldEnd</term>
		/// <term>
		/// The ending position before the text is inserted into the document. This value is the same as acpStart for an insertion
		/// point. If this value is different from acpStart, then text was selected prior to the text insertion.
		/// </term>
		/// </item>
		/// <item>
		/// <term>acpNewEnd</term>
		/// <term>The ending position after the text insertion occurred.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_INVALIDPOS</term>
		/// <term>The acpStart or acpEnd parameter is outside of the document text.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_NOLOCK</term>
		/// <term>The caller does not have a read/write lock.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_READONLY</term>
		/// <term>The document is read-only. Content cannot be modified.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_REGION</term>
		/// <term>An attempt was made to modify text across a region boundary.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Applications should start a composition by first using ITextStoreACP::InsertTextAtSelection. <c>ITextStoreACP::SetText</c>
		/// should be used only within an existing composition. If there is no active composition at the time <c>SetText</c> is called,
		/// the TSF manager creates a composition that lasts just long enough to wrap the call to <c>SetText</c>.
		/// </para>
		/// <para>The acpStart and acpEnd character positions cannot be outside the document range.</para>
		/// <para>Applications should not call the ITextStoreACPSink::OnTextChange method in response to this method.</para>
		/// <para>
		/// This method should call the ITextStoreACP::SetSelection method to select the text to be changed. After successfully
		/// executing the <c>ITextStoreACP::SetSelection</c> method, this method then calls the
		/// <c>ITextStoreACP::InsertTextAtSelection</c> method to perform the actual text change.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreacp-settext HRESULT SetText( DWORD dwFlags,
		// LONG acpStart, LONG acpEnd, const WCHAR *pchText, ULONG cch, TS_TEXTCHANGE *pChange );
		[PreserveSig]
		HRESULT SetText([In] TS_ST dwFlags, [In] int acpStart, [In] int acpEnd, [In, MarshalAs(UnmanagedType.LPWStr)] string pchText, [In] uint cch, out TS_TEXTCHANGE pChange);

		/// <summary>
		/// The <c>ITextStoreACP::GetFormattedText</c> method returns formatted text data about a specified text string. The caller must
		/// have a read/write lock on the document before calling this method.
		/// </summary>
		/// <param name="acpStart">Specifies the starting character position of the text to get in the document.</param>
		/// <param name="acpEnd">
		/// Specifies the ending character position of the text to get in the document. This parameter is ignored if the value is 1.
		/// </param>
		/// <param name="ppDataObject">Receives the pointer to the <c>IDataObject</c> object that contains the formatted text.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_NOLOCK</term>
		/// <term>The caller does not have a read/write lock on the document.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreacp-getformattedtext HRESULT
		// GetFormattedText( LONG acpStart, LONG acpEnd, IDataObject **ppDataObject );
		[PreserveSig]
		HRESULT GetFormattedText([In] int acpStart, [In] int acpEnd, [Out, MarshalAs(UnmanagedType.Interface)] out IDataObject ppDataObject);

		/// <summary>Gets an embedded document.</summary>
		/// <param name="acpPos">Contains the character position, within the document, from where the object is obtained.</param>
		/// <param name="rguidService">
		/// <para>Contains a GUID value that defines the requested format of the obtained object. This can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>GUID_TS_SERVICE_DATAOBJECT</term>
		/// <term>The object should be obtained as an IDataObject object.</term>
		/// </item>
		/// <item>
		/// <term>GUID_TS_SERVICE_ACCESSIBLE</term>
		/// <term>The object should be obtained as an Accessible object.</term>
		/// </item>
		/// <item>
		/// <term>GUID_TS_SERVICE_ACTIVEX</term>
		/// <term>The object should be obtained as an ActiveX object.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="riid">Specifies the interface type requested.</param>
		/// <param name="ppunk">Pointer to an <c>IUnknown</c> pointer that receives the requested interface.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One or more parameters are invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_NOTIMPL</term>
		/// <term>The application does not support embedded objects.</term>
		/// </item>
		/// <item>
		/// <term>TF_E_INVALIDPOS</term>
		/// <term>acpPos is not within the document.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_NOINTERFACE</term>
		/// <term>The requested interface type is unsupported.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_NOLOCK</term>
		/// <term>The caller does not have a read-only lock.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_NOOBJECT</term>
		/// <term>There is no embedded object at acpPos.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_NOSERVICE</term>
		/// <term>The service type specified in rguidService is unsupported.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// The caller must use <c>QueryInterface</c> to probe for appropriate interfaces. Prospective interfaces include those
		/// associated with embedded documents or controls such as <c>IOleObject</c> , <c>IDataObject</c> , <c>IViewObject</c> ,
		/// <c>IPersistStorage</c> , <c>IOleCache</c> , or <c>IDispatch</c> .
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreacp-getembedded HRESULT GetEmbedded( LONG
		// acpPos, REFGUID rguidService, REFIID riid, IUnknown **ppunk );
		[PreserveSig]
		HRESULT GetEmbedded([In] int acpPos, in Guid rguidService, in Guid riid, [Out, MarshalAs(UnmanagedType.IUnknown)] out object ppunk);

		/// <summary>Gets a value indicating whether the specified object can be inserted into the document.</summary>
		/// <param name="pguidService">Pointer to the object type. Can be <c>NULL</c>.</param>
		/// <param name="pFormatEtc">
		/// Pointer to the FORMATETC structure that contains format data of the object. This parameter cannot be <c>NULL</c> if the
		/// pguidService parameter is <c>NULL</c>.
		/// </param>
		/// <param name="pfInsertable">
		/// Receives <c>TRUE</c> if the object type can be inserted into the document or <c>FALSE</c> if the object type cannot be
		/// inserted into the document.
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The pFormatEtc parameter is NULL.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>The clipboard formats supported by the document are dependent on the application.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreacp-queryinsertembedded HRESULT
		// QueryInsertEmbedded( const GUID *pguidService, const FORMATETC *pFormatEtc, BOOL *pfInsertable );
		[PreserveSig]
		HRESULT QueryInsertEmbedded([In, Optional] GuidPtr pguidService, [In, Optional] IntPtr pFormatEtc, [Out, MarshalAs(UnmanagedType.Bool)] out bool pfInsertable);

		/// <summary>Inserts an embedded object at the specified character.</summary>
		/// <param name="dwFlags">Must be TS_IE_CORRECTION.</param>
		/// <param name="acpStart">Contains the starting character position where the object is inserted.</param>
		/// <param name="acpEnd">Contains the ending character position where the object is inserted.</param>
		/// <param name="pDataObject">Pointer to an IDataObject interface that contains data about the object inserted.</param>
		/// <param name="pChange">Pointer to a TS_TEXTCHANGE structure that receives data about the modified text.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One or more parameters are invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_NOTIMPL</term>
		/// <term>The application does not support embedded objects.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_FORMAT</term>
		/// <term>The application does not support the data type contained in pDataObject.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_INVALIDPOS</term>
		/// <term>acpStart and/or acpEnd are not within the document.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_NOLOCK</term>
		/// <term>The caller does not have a read/write lock.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreacp-insertembedded HRESULT InsertEmbedded(
		// DWORD dwFlags, LONG acpStart, LONG acpEnd, IDataObject *pDataObject, TS_TEXTCHANGE *pChange );
		[PreserveSig]
		HRESULT InsertEmbedded([In] TS_IE dwFlags, [In] int acpStart, [In] int acpEnd, [In] IDataObject pDataObject, out TS_TEXTCHANGE pChange);

		/// <summary>
		/// The <c>ITextStoreACP::InsertTextAtSelection</c> method inserts text at the insertion point or selection. A caller must have
		/// a read/write lock on the document before inserting text.
		/// </summary>
		/// <param name="dwFlags">
		/// <para>
		/// Specifies whether the pacpStart and pacpEnd parameters and the TS_TEXTCHANGE structure contain the results of the text insertion.
		/// </para>
		/// <para>The TF_IAS_NOQUERY and TF_IAS_QUERYONLY flags cannot be combined.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>
		/// Text insertion will occur, and the pacpStart and pacpEnd parameters will contain the results of the text insertion. The
		/// TS_TEXTCHANGE structure must be filled with this flag.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TF_IAS_NOQUERY</term>
		/// <term>
		/// Text is inserted, the values of the pacpStart and pacpEnd parameters can be NULL, and the TS_TEXTCHANGE structure must be
		/// filled. Use this flag to view the results of the text insertion.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TF_IAS_QUERYONLY</term>
		/// <term>
		/// Text is not inserted, and the values for the pacpStart and pacpEnd parameters contain the results of the text insertion. The
		/// values of these parameters depend on how the application implements text insertion into a document. For more information,
		/// see the Remarks section. Use this flag to view the results of the text insertion without actually inserting the text. It is
		/// not required that you fill the TS_TEXTCHANGE structure if you use this flag.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pchText">Pointer to the string to insert in the document. The string can be <c>NULL</c> terminated.</param>
		/// <param name="cch">Specifies the text length.</param>
		/// <param name="pacpStart">Pointer to the starting application character position where the text insertion occurs.</param>
		/// <param name="pacpEnd">
		/// Pointer to the ending application character position where the text insertion occurs. This parameter value is the same as
		/// the value of the pacpStart parameter for an insertion point.
		/// </param>
		/// <param name="pChange">
		/// <para>Pointer to a <c>TS_TEXTCHANGE</c> structure with the following members.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>acpStart</term>
		/// <term>The starting application character position before the text is inserted into the document.</term>
		/// </item>
		/// <item>
		/// <term>acpOldEnd</term>
		/// <term>
		/// The ending application character position before the text is inserted into the document. This value is the same as acpStart
		/// for an insertion point. If this value is different from acpStart, then text was selected prior to the text insertion.
		/// </term>
		/// </item>
		/// <item>
		/// <term>acpNewEnd</term>
		/// <term>The end position after the text insertion occurred.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_NOLOCK</term>
		/// <term>The caller does not have a lock on the document.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The pchText parameter is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The values of the pacpStart and the pacpEnd parameters depend upon how the client application inserts text into a document.
		/// For example, if the application sets the cursor at the start of the inserted text after text insertion, then the value for
		/// the pacpStart and pacpEnd parameters is the same as the <c>acpStart</c> member of the <c>TS_TEXTCHANGE</c> structure.
		/// </para>
		/// <para>Applications should not call the ITextStoreACPSink::OnTextChange method in response to this method.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreacp-inserttextatselection HRESULT
		// InsertTextAtSelection( DWORD dwFlags, const WCHAR *pchText, ULONG cch, LONG *pacpStart, LONG *pacpEnd, TS_TEXTCHANGE *pChange );
		[PreserveSig]
		HRESULT InsertTextAtSelection([In] TS_IAS dwFlags, [In, MarshalAs(UnmanagedType.LPWStr)] string pchText, [In] uint cch, out int pacpStart, out int pacpEnd, out TS_TEXTCHANGE pChange);

		/// <summary>
		/// The <c>ITextStoreACP::InsertEmbeddedAtSelection</c> method inserts an IDataObject object at the insertion point or
		/// selection. The client that calls this method must have a read/write lock before inserting an <c>IDataObject</c> object into
		/// the document.
		/// </summary>
		/// <param name="dwFlags">
		/// <para>
		/// Specifies whether the pacpStart and pacpEnd parameters and the TS_TEXTCHANGE structure will contain the results of the
		/// object insertion.
		/// </para>
		/// <para>The TF_IAS_NOQUERY and TF_IAS_QUERYONLY flags cannot be combined.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>
		/// Text insertion will occur, and the pacpStart and pacpEnd parameters will contain the results of the text insertion. The
		/// TS_TEXTCHANGE structure must be filled with this flag.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TF_IAS_NOQUERY</term>
		/// <term>
		/// Text is inserted, the values of the pacpStart and pacpEnd parameters can be NULL, and the TS_TEXTCHANGE structure must be
		/// filled. Use this flag if the results of the text insertion are not required.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TF_IAS_QUERYONLY</term>
		/// <term>
		/// Text is not inserted, and the values for the pacpStart and pacpEnd parameter contain the results of the text insertion. The
		/// values of these parameters depend on how the application implements text insertion into a document. For more information,
		/// see the Remarks section. Use this flag to view the results of the text insertion without actually inserting the text, for
		/// example, to predict the results of collapsing or otherwise adjusting a selection. It is not required that you fill the
		/// TS_TEXTCHANGE structure with this flag.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pDataObject">Pointer to the <c>IDataObject</c> object to be inserted.</param>
		/// <param name="pacpStart">Pointer to the starting application character position where the object insertion will occur.</param>
		/// <param name="pacpEnd">
		/// Pointer to the ending application character position where the object insertion will occur. This parameter value will be the
		/// same as the value of the pacpStart parameter for an insertion point.
		/// </param>
		/// <param name="pChange">
		/// <para>Pointer to a <c>TS_TEXTCHANGE</c> structure with the following members.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>acpStart</term>
		/// <term>The starting application character position before the object is inserted into the document.</term>
		/// </item>
		/// <item>
		/// <term>acpOldEnd</term>
		/// <term>
		/// The ending application character position before the object is inserted into the document. This value is the same as
		/// acpStart for an insertion point. If this value is different from acpStart, then text was selected prior to the object insertion.
		/// </term>
		/// </item>
		/// <item>
		/// <term>acpNewEnd</term>
		/// <term>The ending application character position after the object insertion took place.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The pchText parameter is invalid.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_NOLOCK</term>
		/// <term>The caller does not have a lock on the document.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// The values of the pacpStart and pacpEnd parameters depend upon how the client application inserts an object into a document.
		/// For example, if the application sets the cursor at the start of the object after object insertion, then the value of the
		/// pacpStart and pacpEnd parameters is the same as the <c>acpStart</c> member of the <c>TS_TEXTCHANGE</c> structure.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreacp-insertembeddedatselection HRESULT
		// InsertEmbeddedAtSelection( DWORD dwFlags, IDataObject *pDataObject, LONG *pacpStart, LONG *pacpEnd, TS_TEXTCHANGE *pChange );
		[PreserveSig]
		HRESULT InsertEmbeddedAtSelection([In] TS_IAS dwFlags, [In] IDataObject pDataObject, out int pacpStart, out int pacpEnd, out TS_TEXTCHANGE pChange);

		/// <summary>Get the attributes that are supported in the document.</summary>
		/// <param name="dwFlags">
		/// Specifies whether a subsequent call to the ITextStoreAnchor::RetrieveRequestedAttrs method will contain the supported
		/// attributes. If the TS_ATTR_FIND_WANT_VALUE flag is specified, the default attribute values will be those in the TS_ATTRVAL
		/// structure after the subsequent call to <c>ITextStoreAnchor::RetrieveRequestedAttrs</c>. If any other flag is specified for
		/// this parameter, the method only verifies that the attribute is supported and that the <c>varValue</c> member of the
		/// <c>TS_ATTRVAL</c> structure is set to VT_EMPTY.
		/// </param>
		/// <param name="cFilterAttrs">Specifies the number of supported attributes to obtain.</param>
		/// <param name="paFilterAttrs">
		/// Pointer to the TS_ATTRID data type that specifies the attribute to verify. The method returns only the attributes specified
		/// by <c>TS_ATTRID</c>, even though other attributes can be supported.
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>An unspecified error occurred.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>The method was unable to allocate sufficient memory to complete the operation.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreacp-requestsupportedattrs HRESULT
		// RequestSupportedAttrs( DWORD dwFlags, ULONG cFilterAttrs, const TS_ATTRID *paFilterAttrs );
		[PreserveSig]
		HRESULT RequestSupportedAttrs([In] TS_ATTR_FIND dwFlags, [In] uint cFilterAttrs, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] TS_ATTRID[] paFilterAttrs);

		/// <summary>Gets text attributes at the specified character position.</summary>
		/// <param name="acpPos">Specifies the application character position in the document.</param>
		/// <param name="cFilterAttrs">Specifies the number of attributes to obtain.</param>
		/// <param name="paFilterAttrs">Pointer to the TS_ATTRID data type that specifies the attribute to verify.</param>
		/// <param name="dwFlags">Must be zero.</param>
		/// <returns>This method has no return values.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreacp-requestattrsatposition HRESULT
		// RequestAttrsAtPosition( LONG acpPos, ULONG cFilterAttrs, const TS_ATTRID *paFilterAttrs, DWORD dwFlags );
		[PreserveSig]
		HRESULT RequestAttrsAtPosition([In] int acpPos, [In] uint cFilterAttrs, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] TS_ATTRID[] paFilterAttrs, TS_ATTR_FIND dwFlags = 0);

		/// <summary>Gets text attributes transitioning at the specified character position.</summary>
		/// <param name="acpPos">Specifies the application character position in the document.</param>
		/// <param name="cFilterAttrs">Specifies the number of attributes to obtain.</param>
		/// <param name="paFilterAttrs">Pointer to the TS_ATTRID data type that specifies the attribute to verify.</param>
		/// <param name="dwFlags">
		/// <para>
		/// Specifies attributes for the call to the ITextStoreACP::RetrieveRequestedAttrs method. If this parameter is not set, the
		/// method returns the attributes that start at the specified position. Other possible values for this parameter are the following.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TS_ATTR_FIND_WANT_END</term>
		/// <term>Obtains the attributes that end at the specified application character position.</term>
		/// </item>
		/// <item>
		/// <term>TS_ATTR_FIND_WANT_VALUE</term>
		/// <term>
		/// Obtains the value of the attribute in addition to the attribute. The attribute value is put into the varValue member of the
		/// TS_ATTRVAL structure during the ITextStoreACP::RetrieveRequestedAttrs method call.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// In the sentence, "This is italic text.", the italic attribute starts before the word italic and ends after the word text.
		/// </para>
		/// <para>
		/// If the flag TS_ATTR_FIND_WANT_END is set in dwFlags, the method would return the italic attribute for the text "italic
		/// &lt;anchor&gt;normal", because there is an end transition at the anchor location.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreacp-requestattrstransitioningatposition
		// HRESULT RequestAttrsTransitioningAtPosition( LONG acpPos, ULONG cFilterAttrs, const TS_ATTRID *paFilterAttrs, DWORD dwFlags );
		[PreserveSig]
		HRESULT RequestAttrsTransitioningAtPosition([In] int acpPos, [In] uint cFilterAttrs, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] TS_ATTRID[] paFilterAttrs, [In] TS_ATTR_FIND dwFlags);

		/// <summary>
		/// The <c>ITextStoreACP::FindNextAttrTransition</c> method determines the character position where a transition occurs in an
		/// attribute value. The specified attribute to check is application-dependent.
		/// </summary>
		/// <param name="acpStart">Specifies the character position to start the search for an attribute transition.</param>
		/// <param name="acpHalt">Specifies the character position to end the search for an attribute transition.</param>
		/// <param name="cFilterAttrs">Specifies the number of attributes to check.</param>
		/// <param name="paFilterAttrs">Pointer to the TS_ATTRID data type that specifies the attribute to check.</param>
		/// <param name="dwFlags">
		/// <para>Specifies the direction to search for an attribute transition. By default, the method searches forward.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TS_ATTR_FIND_BACKWARDS</term>
		/// <term>The method searches backward.</term>
		/// </item>
		/// <item>
		/// <term>TS_ATTR_FIND_WANT_OFFSET</term>
		/// <term>The plFoundOffset parameter receives the character offset of the attribute transition from acpStart.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pacpNext">Receives the next character position to check for an attribute transition.</param>
		/// <param name="pfFound">
		/// Receives a Boolean value of <c>TRUE</c> if an attribute transition was found, otherwise <c>FALSE</c> is returned.
		/// </param>
		/// <param name="plFoundOffset">
		/// Receives the character position of the attribute transition (not ACP positions). If TS_ATTR_FIND_WANT_OFFSET flag is set in
		/// dwFlags, receives the character offset of the attribute transition from acpStart.
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_INVALIDPOS</term>
		/// <term>The character positions specified are beyond the text in the document.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <c>Note</c> If an application does not implement <c>ITextStoreACP::FindNextAttrTransition</c>,
		/// ITfReadOnlyProperty::EnumRanges fails with E_FAIL.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreacp-findnextattrtransition HRESULT
		// FindNextAttrTransition( LONG acpStart, LONG acpHalt, ULONG cFilterAttrs, const TS_ATTRID *paFilterAttrs, DWORD dwFlags, LONG
		// *pacpNext, BOOL *pfFound, LONG *plFoundOffset );
		[PreserveSig]
		HRESULT FindNextAttrTransition([In] int acpStart, [In] int acpHalt, [In] uint cFilterAttrs, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] TS_ATTRID[] paFilterAttrs,
			[In] TS_ATTR_FIND dwFlags, out int pacpNext, [MarshalAs(UnmanagedType.Bool)] out bool pfFound, out int plFoundOffset);

		/// <summary>Gets the attributes returned by a call to an attribute request method.</summary>
		/// <param name="ulCount">Specifies the number of supported attributes to obtain.</param>
		/// <param name="paAttrVals">
		/// Pointer to the TS_ATTRVAL structure that receives the supported attributes. The members of this structure depend upon the
		/// dwFlags parameter of the calling method.
		/// </param>
		/// <param name="pcFetched">Receives the number of supported attributes.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreacp-retrieverequestedattrs HRESULT
		// RetrieveRequestedAttrs( ULONG ulCount, TS_ATTRVAL *paAttrVals, ULONG *pcFetched );
		[PreserveSig]
		HRESULT RetrieveRequestedAttrs([In] uint ulCount, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] TS_ATTRVAL[] paAttrVals, [NullAllowed] out uint pcFetched);

		/// <summary>The <c>ITextStoreACP::GetEndACP</c> method returns the number of characters in a document.</summary>
		/// <param name="pacp">Receives the character position of the last character in the document plus one.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_NOTIMPL</term>
		/// <term>
		/// The application has not implemented this method. This is usually an indication that calculating the end position requires
		/// excessive resources. If the end position is necessary, you can use ITextStoreACP::GetText to calculate it, though this can
		/// also be a memory-intensive operation, paging in arbitrarily large amounts of memory from disk.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TS_E_NOLOCK</term>
		/// <term>The caller does not have a read-only lock.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreacp-getendacp HRESULT GetEndACP( LONG *pacp );
		[PreserveSig]
		HRESULT GetEndACP(out int pacp);

		/// <summary>
		/// The <c>ITextStoreACP::GetActiveView</c> method returns a TsViewCookie data type that specifies the current active view.
		/// </summary>
		/// <param name="pvcView">Receives the <c>TsViewCookie</c> data type that specifies the current active view.</param>
		/// <returns>This method has no return values.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreacp-getactiveview HRESULT GetActiveView(
		// TsViewCookie *pvcView );
		[PreserveSig]
		HRESULT GetActiveView(out TsViewCookie pvcView);

		/// <summary>
		/// The <c>ITextStoreACP::GetACPFromPoint</c> method converts a point in screen coordinates to an application character position.
		/// </summary>
		/// <param name="vcView">Specifies the context view.</param>
		/// <param name="ptScreen">Pointer to the <c>POINT</c> structure with the screen coordinates of the point.</param>
		/// <param name="dwFlags">
		/// <para>
		/// Specifies the character position to return based upon the screen coordinates of the point relative to a character bounding
		/// box. By default, the character position returned is the character bounding box containing the screen coordinates of the
		/// point. If the point is outside a character bounding box, the method returns <c>NULL</c> or TF_E_INVALIDPOINT. Other bit
		/// flags for this parameter are as follows.
		/// </para>
		/// <para>The bit flags can be combined.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>GXFPF_ROUND_NEAREST</term>
		/// <term>
		/// If the screen coordinates of the point are contained in a character bounding box, the character position returned is the
		/// bounding edge closest to the screen coordinates of the point.
		/// </term>
		/// </item>
		/// <item>
		/// <term>GXFPF_NEAREST</term>
		/// <term>
		/// If the screen coordinates of the point are not contained in a character bounding box, the closest character position is returned.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pacp">Receives the character position that corresponds to the screen coordinates of the point.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_INVALIDPOINT</term>
		/// <term>The ptScreen parameter is not within the bounding box of any character.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_NOLAYOUT</term>
		/// <term>The application has not calculated a text layout.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The point 1 screen coordinates cause the pacp parameter to be 0 by default or if the dwFlags parameter is set to
		/// GXFPF_NEAREST because the point 1 screen coordinates are inside the character bounding box of character position 0. If the
		/// dwFlags parameter is set to GXFPF_ROUND_NEAREST for point 1, the pacp parameter is 1 because the point 1 screen coordinates
		/// are closest to range position 1. Range position 1 is the starting range position of character position 1.
		/// </para>
		/// <para>
		/// For the point 2 screen coordinates, the method returns <c>TF_E_INVALIDPOINT</c> by default or if the dwFlags parameter is
		/// set to <c>GXFPF_NEAREST</c> because the point 2 screen coordinates are outside a character bounding box. If the dwFlags
		/// parameter is set to <c>GXFPF_ROUND_NEAREST</c>, then the point 2 screen coordinates causes the pacp parameter to be 1,
		/// because the closest character position to the point 2 screen coordinates is character position 1.
		/// </para>
		/// <para><c>Point 1</c></para>
		/// <list type="bullet">
		/// <item>
		/// <term>Default-- pacp = 0 --The screen coordinates point is inside the character bounding box of Character Position 0.</term>
		/// </item>
		/// <item>
		/// <term>
		/// <c>GXFPF_ROUND_NEAREST</c> -- pacp = 1 --The screen coordinates of the point is closest to Range Position 1 which is the
		/// starting range position of Character Position 1.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// <c>GXFPF_NEAREST</c> -- pacp = 0 --The default behavior occurs because the point is within the character bounding box of
		/// Character Position 0.
		/// </term>
		/// </item>
		/// </list>
		/// <para><c>Point 2</c></para>
		/// <list type="bullet">
		/// <item>
		/// <term>Default-- hr = TF_E_INVALIDPOINT --The screen coordinates of the point is outside a character bounding box.</term>
		/// </item>
		/// <item>
		/// <term>
		/// GXPF_ROUND_NEAREST-- hr = TF_E_INVALIDPOINT --The default behavior occurs because the screen coordinates of the point are
		/// outside a character bounding box.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// GXPF_NEAREST-- pacp = 1 --The closest character position to the screen coordinates of the point is Character Position 1.
		/// </term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreacp-getacpfrompoint HRESULT
		// GetACPFromPoint( TsViewCookie vcView, const POINT *ptScreen, DWORD dwFlags, LONG *pacp );
		[PreserveSig]
		HRESULT GetACPFromPoint([In] TsViewCookie vcView, in POINT ptScreen, [In] GXFPF dwFlags, out int pacp);

		/// <summary>
		/// The <c>ITextStoreACP::GetTextExt</c> method returns the bounding box, in screen coordinates, of the text at a specified
		/// character position. The caller must have a read-only lock on the document before calling this method.
		/// </summary>
		/// <param name="vcView">Specifies the context view.</param>
		/// <param name="acpStart">Specifies the starting character position of the text to get in the document.</param>
		/// <param name="acpEnd">Specifies the ending character position of the text to get in the document.</param>
		/// <param name="prc">Receives the bounding box in screen coordinates of the text at the specified character positions.</param>
		/// <param name="pfClipped">
		/// Receives a Boolean value that specifies if the text in the bounding box has been clipped. If this parameter is <c>TRUE</c>,
		/// the bounding box contains clipped text and does not include the entire requested text range. The bounding box is clipped
		/// because the requested range is not visible.
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_INVALIDARG</term>
		/// <term>The specified start and end character positions are equal.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_INVALIDPOS</term>
		/// <term>The range specified by the acpStart and acpEnd parameters extends past the beginning or end of the document.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_NOLAYOUT</term>
		/// <term>The application has not calculated a text layout.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_NOLOCK</term>
		/// <term>The caller does not have a read-only lock on the document.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// If the document window is minimized, or if the specified text is not currently visible, the method returns S_OK with the prc
		/// parameter set to {0,0,0,0}.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreacp-gettextext HRESULT GetTextExt(
		// TsViewCookie vcView, LONG acpStart, LONG acpEnd, RECT *prc, BOOL *pfClipped );
		[PreserveSig]
		HRESULT GetTextExt([In] TsViewCookie vcView, [In] int acpStart, [In] int acpEnd, out RECT prc, [Out, MarshalAs(UnmanagedType.Bool)] out bool pfClipped);

		/// <summary>
		/// The <c>ITextStoreACP::GetScreenExt</c> method returns the bounding box screen coordinates of the display surface where the
		/// text stream is rendered.
		/// </summary>
		/// <param name="vcView">Specifies the context view.</param>
		/// <param name="prc">Receives the bounding box screen coordinates of the display surface of the document.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The specified vcView parameter is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// If the text is not currently displayed, for example, if the document window is minimized, the prc parameter is set to { 0,
		/// 0, 0, 0 }.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreacp-getscreenext HRESULT GetScreenExt(
		// TsViewCookie vcView, RECT *prc );
		[PreserveSig]
		HRESULT GetScreenExt([In] TsViewCookie vcView, out RECT prc);

		/// <summary>The <c>ITextStoreACP::GetWnd</c> method returns the handle to a window that corresponds to the current document.</summary>
		/// <param name="vcView">Specifies the TsViewCookie data type that corresponds to the current document.</param>
		/// <param name="phwnd">
		/// Receives a pointer to the handle of the window that corresponds to the current document. This parameter can be <c>NULL</c>
		/// if the document does not have the corresponding handle to the window.
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The TsViewCookie data type is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// A document cannot have a corresponding window handle if the document is in memory but not displayed on the screen, or if the
		/// document is a windowless control and the control does not recognize the window handle of the owner of the windowless
		/// controls. Callers cannot assume that the phwnd parameter will receive a non- <c>NULL</c> value even if the method is
		/// successful. Callers can also receive a <c>NULL</c> value for the phwnd parameter.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreacp-getwnd HRESULT GetWnd( TsViewCookie
		// vcView, HWND *phwnd );
		[PreserveSig]
		HRESULT GetWnd([In] TsViewCookie vcView, out HWND phwnd);
	}

	/// <summary>
	/// <para>
	/// The <c>ITextStoreACP2</c> interface is implemented by the application and is used by the TSF manager to manipulate text streams
	/// or text stores in TSF. An application can obtain an instance of this interface with a call to the CreateContext method. The
	/// interface ID is <c>IID_ITextStoreACP2</c>.
	/// </para>
	/// <para>
	/// This interface exposes text stores through an application character position (ACP) format. Applications that use an anchor-based
	/// format should use ITextStoreAnchor.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nn-textstor-itextstoreacp2
	[PInvokeData("textstor.h", MSDNShortId = "NN:textstor.ITextStoreACP2")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("f86ad89f-5fe4-4b8d-bb9f-ef3797a84f1f")]
	public interface ITextStoreACP2
	{
		/// <summary>
		/// Installs a new advise sink from the ITextStoreACPSink interface or modifies an existing advise sink. The sink interface is
		/// specified by the punk parameter.
		/// </summary>
		/// <param name="riid">Specifies the sink interface.</param>
		/// <param name="punk">Pointer to the sink interface. Cannot be <c>NULL</c>.</param>
		/// <param name="dwMask">
		/// Specifies the events that notify the advise sink. For more information about possible parameter values, see TS_AS_* Constants.
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>CONNECT_E_ADVISELIMIT</term>
		/// <term>A sink interface pointer could not be obtained.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The specified sink interface is unsupported.</term>
		/// </item>
		/// <item>
		/// <term>E_UNEXPECTED</term>
		/// <term>The specified sink object could not be obtained.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreacp2-advisesink HRESULT AdviseSink( REFIID
		// riid, IUnknown *punk, DWORD dwMask );
		[PreserveSig]
		HRESULT AdviseSink(in Guid riid, [In, MarshalAs(UnmanagedType.IUnknown)] object punk, [In] TS_AS dwMask);

		/// <summary>
		/// Called by an application to indicate that it no longer requires notifications from the TSF manager. The TSF manager will
		/// release the sink interface and stop notifications.
		/// </summary>
		/// <param name="punk">Pointer to a sink object. Cannot be <c>NULL</c>.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>CONNECT_E_NOCONNECTION</term>
		/// <term>There is no active sink object.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Every call to the AdviseSink method, which registers a new sink object, should be matched by a call to this method. Calls to
		/// the <c>AdviseSink</c> method that only update the dwMask parameter of a sink which was previously registered, do not require
		/// a call to the <c>UnadviseSink</c> method.
		/// </para>
		/// <para>
		/// For example, to register a sink object, an application calls the AdviseSink method the first time. After registering the
		/// sink object, the application can call the <c>AdviseSink</c> method again with the same sink object to change the dwMask
		/// parameter. To unregister the sink object, an application calls the <c>UnadviseSink</c> method.
		/// </para>
		/// <para>The punk parameter must have the same COM identity as the pointer originally passed in the AdviseSink method.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreacp2-unadvisesink HRESULT UnadviseSink(
		// IUnknown *punk );
		[PreserveSig]
		HRESULT UnadviseSink([In, MarshalAs(UnmanagedType.IUnknown)] object punk);

		/// <summary>
		/// Called by the TSF manager to provide a document lock in order to modify the document. This method calls the OnLockGranted
		/// method to create the document lock.
		/// </summary>
		/// <param name="dwLockFlags">
		/// <para>Specifies the type of lock requested.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TS_LF_READ</term>
		/// <term>The document has a read-only lock and cannot be modified.</term>
		/// </item>
		/// <item>
		/// <term>TS_LF_READWRITE</term>
		/// <term>The document has a read/write lock and can be modified.</term>
		/// </item>
		/// <item>
		/// <term>TS_LF_SYNC</term>
		/// <term>The document has a synchronous-lock if this flag is combined with other flags.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="phrSession">
		/// <para>
		/// If the lock request is synchronous, receives an HRESULT value from the OnLockGranted method that specifies the result of the
		/// lock request.
		/// </para>
		/// <para>
		/// If the lock request is asynchronous and the result is TS_S_ASYNC, the document receives an asynchronous lock. If the lock
		/// request is asynchronous and the result is TS_E_SYNCHRONOUS, the document can't be locked synchronously.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>An unspecified error occurred.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method uses the OnLockGranted method to lock the document. Applications must never modify the document or send change
		/// notifications using the OnTextChange method from within the <c>RequestLock</c> method. If the application has pending
		/// changes to report, the application can only respond to the asynchronous lock request.
		/// </para>
		/// <para>
		/// Applications should not attempt to queue multiple <c>RequestLock</c> method calls, because the application requires only a
		/// single callback. If the caller makes several read requests and one or more write requests, however, the callback should be
		/// for write access.
		/// </para>
		/// <para>
		/// Successful requests for synchronous locks supersede requests for asynchronous locks. Unsuccessful requests for synchronous
		/// locks do not supersede requests for asynchronous locks. The implementation must still serve the outstanding asynchronous
		/// request, if one exists.
		/// </para>
		/// <para>
		/// If the lock is granted before the <c>RequestLock</c> method returns, the phrSession parameter will receive the HRESULT
		/// returned by the OnLockGranted method. If the call is successful, but the lock will be granted later, the phrSession
		/// parameter receives the TS_S_ASYNC flag. The phrSession parameter should be ignored if <c>RequestLock</c> returns anything
		/// other than S_OK.
		/// </para>
		/// <para>
		/// A caller should never call this method reentrantly, except in the case that the caller holds a read-only lock. In this case
		/// the method can be called reentrantly to ask for an asynchronous write lock. The write lock will be granted later, after the
		/// read-only lock ends.
		/// </para>
		/// <para>For more information about document locks, see Document Locks.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreacp2-requestlock HRESULT RequestLock( DWORD
		// dwLockFlags, HRESULT *phrSession );
		[PreserveSig]
		HRESULT RequestLock([In] TS_LF dwLockFlags, out HRESULT phrSession);

		/// <summary>Gets the document status. The document status is returned through the TS_STATUS structure.</summary>
		/// <param name="pdcs">Receives the TS_STATUS structure that contains the document status. Cannot be <c>NULL</c>.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The pointer to the TS_STATUS parameter is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreacp2-getstatus HRESULT GetStatus( TS_STATUS
		// *pdcs );
		[PreserveSig]
		HRESULT GetStatus(out TS_STATUS pdcs);

		/// <summary>
		/// Determines whether the specified start and end character positions are valid. Use this method to adjust an edit to a
		/// document before executing the edit. The method must not return values outside the range of the document.
		/// </summary>
		/// <param name="acpTestStart">Starting application character position for inserted text.</param>
		/// <param name="acpTestEnd">
		/// Ending application character position for the inserted text. This value is equal to acpTextStart if the text is inserted at
		/// a point instead of replacing selected text.
		/// </param>
		/// <param name="cch">Length of replacement text.</param>
		/// <param name="pacpResultStart">
		/// Returns the new starting application character position of the inserted text. If this parameter is <c>NULL</c>, then text
		/// cannot be inserted at the specified position. This value cannot be outside the document range.
		/// </param>
		/// <param name="pacpResultEnd">
		/// Returns the new ending application character position of the inserted text. If this parameter is <c>NULL</c>, then
		/// pacpResultStart is set to <c>NULL</c> and text cannot be inserted at the specified position. This value cannot be outside
		/// the document range.
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>An unspecified error occurred.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The acpTestStart or acpTestEnd parameters are invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// The values of pacpResultStart and pacpResultEnd depend upon how the application inserts text into the document. If
		/// pacpResultStart and pacpResultEnd are the same as acpTextStart, the cursor is at the beginning of the inserted text after
		/// insertion. If pacpResultStart and pacpResultEnd are the same as acpTextEnd, the cursor is at the end of the inserted text
		/// after insertion. If the difference between pacpResultStart and pacpResultEnd is equal to the length of the inserted text,
		/// the inserted text is highlighted after insertion.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreacp2-queryinsert HRESULT QueryInsert( LONG
		// acpTestStart, LONG acpTestEnd, ULONG cch, LONG *pacpResultStart, LONG *pacpResultEnd );
		[PreserveSig]
		HRESULT QueryInsert([In] int acpTestStart, [In] int acpTestEnd, [In] uint cch, out int pacpResultStart, out int pacpResultEnd);

		/// <summary>
		/// Gets the character position of a text selection in a document. This method supports multiple text selections. The caller
		/// must have a read-only lock on the document before calling this method.
		/// </summary>
		/// <param name="ulIndex">
		/// Specifies the text selections that start the process. If the TF_DEFAULT_SELECTION constant is specified for this parameter,
		/// the input selection starts the process.
		/// </param>
		/// <param name="ulCount">Specifies the maximum number of selections to return.</param>
		/// <param name="pSelection">
		/// Receives the style, start, and end character positions of the selected text. These values are put into the TS_SELECTION_ACP structure.
		/// </param>
		/// <param name="pcFetched">Receives the number of pSelection structures returned.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_NOLOCK</term>
		/// <term>The caller does not have a read-only lock on the document.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_NOSELECTION</term>
		/// <term>The document has no selection.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreacp2-getselection HRESULT GetSelection(
		// ULONG ulIndex, ULONG ulCount, TS_SELECTION_ACP *pSelection, ULONG *pcFetched );
		[PreserveSig]
		HRESULT GetSelection([In] uint ulIndex, [In] uint ulCount, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] TS_SELECTION_ACP[] pSelection, [NullAllowed] out uint pcFetched);

		/// <summary>
		/// Selects text within the document. The application must have a read/write lock on the document before calling this method.
		/// </summary>
		/// <param name="ulCount">Specifies the number of text selections in pSelection.</param>
		/// <param name="pSelection">
		/// <para>Specifies the style, start, and end character positions of the text selected through the TS_SELECTION_ACP structure.</para>
		/// <para>
		/// When the start and end character positions are equal, the method places a caret at that character position. There can be
		/// only one caret at a time in the document.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>An unspecified error occurred.</term>
		/// </item>
		/// <item>
		/// <term>TF_E_INVALIDPOS</term>
		/// <term>The character positions specified are beyond the text in the document.</term>
		/// </item>
		/// <item>
		/// <term>TF_E_NOLOCK</term>
		/// <term>The caller does not have a read/write lock.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreacp2-setselection HRESULT SetSelection(
		// ULONG ulCount, const TS_SELECTION_ACP *pSelection );
		[PreserveSig]
		HRESULT SetSelection([In] uint ulCount, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] TS_SELECTION_ACP[] pSelection);

		/// <summary>
		/// Gets info about text at a specified character position. This method returns the visible and hidden text and indicates if
		/// embedded data is attached to the text.
		/// </summary>
		/// <param name="acpStart">Specifies the starting character position.</param>
		/// <param name="acpEnd">
		/// Specifies the ending character position. If this parameter is 1, then return all text in the text store.
		/// </param>
		/// <param name="pchPlain">
		/// Specifies the buffer to receive the plain text data. If this parameter is <c>NULL</c>, then the cchPlainReq parameter must
		/// be 0.
		/// </param>
		/// <param name="cchPlainReq">Specifies the number of plain text characters passed to the method.</param>
		/// <param name="pcchPlainRet">
		/// Receives the number of characters copied into the plain text buffer. This parameter cannot be <c>NULL</c>. Use a parameter
		/// if values are not required.
		/// </param>
		/// <param name="prgRunInfo">Receives an array of TS_RUNINFO structures. May be <c>NULL</c> only if cRunInfoReq = 0.</param>
		/// <param name="cRunInfoReq">Specifies the size, in characters, of the text run buffer.</param>
		/// <param name="pcRunInfoRet">
		/// Receives the number of <c>TS_RUNINFO</c> structures written to the text run buffer. This parameter cannot be <c>NULL</c>.
		/// </param>
		/// <param name="pacpNext">Receives the character position of the next unread character. Cannot be <c>NULL</c>.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>TF_E_INVALIDPOS</term>
		/// <term>The acpStart or acpEnd parameters are outside of the document text.</term>
		/// </item>
		/// <item>
		/// <term>TF_E_NOLOCK</term>
		/// <term>The caller does not have a read-only lock on the document.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Callers that use this method must have a read-only lock on the document by calling the RequestLock method. Without a
		/// read-only lock, the method fails and returns TF_E_NOLOCK.
		/// </para>
		/// <para>
		/// Applications can also truncate the method return values for internal reasons. Callers should carefully examine the return
		/// characters and text run counts to get the required return values. If the return values are incomplete, repeatedly call the
		/// method until the return values are complete.
		/// </para>
		/// <para>
		/// The caller can request plain text only by setting the cRunInfoReq parameter to 0 and the prgRunInfo parameter to
		/// <c>NULL</c>. The caller can request only text run data by setting the cchPlainReq parameter to 0 and the pchPlain parameter
		/// to <c>NULL</c>. However, the caller must still supply valid non- <c>null</c> values for pcchPlainRet, even if this parameter
		/// is not used.
		/// </para>
		/// <para>
		/// If acpEnd is -1, then it should be handled as if set at the end of the stream. Otherwise, it will be greater than or equal
		/// to zero.
		/// </para>
		/// <para>
		/// On exit, pacpNext should be set to the character position of the next character in the stream not referenced by the return
		/// values. A caller would use this to quickly scan text with multiple <c>GetText</c> calls.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreacp2-gettext HRESULT GetText( LONG
		// acpStart, LONG acpEnd, WCHAR *pchPlain, ULONG cchPlainReq, ULONG *pcchPlainRet, TS_RUNINFO *prgRunInfo, ULONG cRunInfoReq,
		// ULONG *pcRunInfoRet, LONG *pacpNext );
		[PreserveSig]
		HRESULT GetText([In] int acpStart, [In] int acpEnd, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pchPlain, [In] uint cchPlainReq,
			out uint pcchPlainRet, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 7)] TS_RUNINFO[] prgRunInfo, [In] uint cRunInfoReq, out uint pcRunInfoRet, out int pacpNext);

		/// <summary>Sets the text selection to the supplied character positions.</summary>
		/// <param name="dwFlags">
		/// If set to the value of <c>TS_ST_CORRECTION</c>, the text is a transform (correction) of existing content, and any special
		/// text markup information (metadata) is retained, such as .wav file data or a language identifier. The client defines the type
		/// of markup information to be retained.
		/// </param>
		/// <param name="acpStart">Specifies the starting character position of the text to replace.</param>
		/// <param name="acpEnd">
		/// Specifies the ending character position of the text to replace. This parameter is ignored if the value is 1.
		/// </param>
		/// <param name="pchText">
		/// Specifies the pointer to the replacement text. The text string does not have to be <c>NULL</c> terminated, because the text
		/// character count is specified in the cch parameter.
		/// </param>
		/// <param name="cch">Specifies the number of characters in the replacement text.</param>
		/// <param name="pChange">
		/// <para>Pointer to a TS_TEXTCHANGE structure with the following data.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>acpStart</term>
		/// <term>The starting application character position before the text is inserted into the document.</term>
		/// </item>
		/// <item>
		/// <term>acpOldEnd</term>
		/// <term>
		/// The ending position before the text is inserted into the document. This value is the same as acpStart for an insertion
		/// point. If this value is different from acpStart, then text was selected prior to the text insertion.
		/// </term>
		/// </item>
		/// <item>
		/// <term>acpNewEnd</term>
		/// <term>The ending position after the text insertion occurred.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_INVALIDPOS</term>
		/// <term>The acpStart or acpEnd parameter is outside of the document text.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_NOLOCK</term>
		/// <term>The caller does not have a read/write lock.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_READONLY</term>
		/// <term>The document is read-only. Content cannot be modified.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_REGION</term>
		/// <term>An attempt was made to modify text across a region boundary.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Applications should start a composition by first using InsertTextAtSelection. <c>SetText</c> should be used only within an
		/// existing composition. If there is no active composition at the time <c>SetText</c> is called, the TSF manager creates a
		/// composition that lasts just long enough to wrap the call to <c>SetText</c>.
		/// </para>
		/// <para>The acpStart and acpEnd character positions cannot be outside the document range.</para>
		/// <para>Applications should not call the OnTextChange method in response to this method.</para>
		/// <para>
		/// This method should call the SetSelection method to select the text to be changed. After successfully executing the
		/// <c>SetSelection</c> method, this method then calls the InsertTextAtSelection method to perform the actual text change.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreacp2-settext HRESULT SetText( DWORD
		// dwFlags, LONG acpStart, LONG acpEnd, const WCHAR *pchText, ULONG cch, TS_TEXTCHANGE *pChange );
		[PreserveSig]
		HRESULT SetText([In] TS_ST dwFlags, [In] int acpStart, [In] int acpEnd, [In, MarshalAs(UnmanagedType.LPWStr)] string pchText, [In] uint cch, out TS_TEXTCHANGE pChange);

		/// <summary>
		/// Gets formatted text data about a specified text string. The caller must have a read/write lock on the document before
		/// calling this method.
		/// </summary>
		/// <param name="acpStart">Specifies the starting character position of the text to get in the document.</param>
		/// <param name="acpEnd">
		/// Specifies the ending character position of the text to get in the document. This parameter is ignored if the value is 1.
		/// </param>
		/// <param name="ppDataObject">Receives the pointer to the IDataObject object that contains the formatted text.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_NOLOCK</term>
		/// <term>The caller does not have a read/write lock on the document.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreacp2-getformattedtext HRESULT
		// GetFormattedText( LONG acpStart, LONG acpEnd, IDataObject **ppDataObject );
		[PreserveSig]
		HRESULT GetFormattedText([In] int acpStart, [In] int acpEnd, [Out, MarshalAs(UnmanagedType.Interface)] out IDataObject ppDataObject);

		/// <summary>Gets an embedded document.</summary>
		/// <param name="acpPos">Contains the character position, within the document, from where the object is obtained.</param>
		/// <param name="rguidService">
		/// <para>Contains a GUID value that defines the requested format of the obtained object. This can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>GUID_TS_SERVICE_DATAOBJECT</term>
		/// <term>The object should be obtained as an IDataObject object.</term>
		/// </item>
		/// <item>
		/// <term>GUID_TS_SERVICE_ACCESSIBLE</term>
		/// <term>The object should be obtained as an Accessible object.</term>
		/// </item>
		/// <item>
		/// <term>GUID_TS_SERVICE_ACTIVEX</term>
		/// <term>The object should be obtained as an ActiveX object.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="riid">Specifies the interface type requested.</param>
		/// <param name="ppunk">Pointer to an <c>IUnknown</c> pointer that receives the requested interface.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One or more parameters are invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_NOTIMPL</term>
		/// <term>The application does not support embedded objects.</term>
		/// </item>
		/// <item>
		/// <term>TF_E_INVALIDPOS</term>
		/// <term>acpPos is not within the document.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_NOINTERFACE</term>
		/// <term>The requested interface type is unsupported.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_NOLOCK</term>
		/// <term>The caller does not have a read-only lock.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_NOOBJECT</term>
		/// <term>There is no embedded object at acpPos.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_NOSERVICE</term>
		/// <term>The service type specified in rguidService is unsupported.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// Use QueryInterface to probe for appropriate interfaces. Prospective interfaces include those associated with embedded
		/// documents or controls such as <c>IOleObject</c> , <c>IDataObject</c> , <c>IViewObject</c> , <c>IPersistStorage</c> ,
		/// <c>IOleCache</c> , or <c>IDispatch</c> .
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreacp2-getembedded HRESULT GetEmbedded( LONG
		// acpPos, REFGUID rguidService, REFIID riid, IUnknown **ppunk );
		[PreserveSig]
		HRESULT GetEmbedded([In] int acpPos, in Guid rguidService, in Guid riid, [Out, MarshalAs(UnmanagedType.IUnknown)] out object ppunk);

		/// <summary>Gets a value indicating whether the specified object can be inserted into the document.</summary>
		/// <param name="pguidService">Pointer to the object type. Can be <c>NULL</c>.</param>
		/// <param name="pFormatEtc">
		/// Pointer to the FORMATETC structure that contains format data of the object. This parameter cannot be <c>NULL</c> if the
		/// pguidService parameter is <c>NULL</c>.
		/// </param>
		/// <param name="pfInsertable">
		/// Receives <c>TRUE</c> if the object type can be inserted into the document or <c>FALSE</c> if the object type can't be
		/// inserted into the document.
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The pFormatEtc parameter is NULL.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>The clipboard formats supported by the document are dependent on the application.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreacp2-queryinsertembedded HRESULT
		// QueryInsertEmbedded( const GUID *pguidService, const FORMATETC *pFormatEtc, BOOL *pfInsertable );
		[PreserveSig]
		HRESULT QueryInsertEmbedded([In, Optional] GuidPtr pguidService, [In, Optional] IntPtr pFormatEtc, [Out, MarshalAs(UnmanagedType.Bool)] out bool pfInsertable);

		/// <summary>Inserts an embedded object at the specified character.</summary>
		/// <param name="dwFlags">Must be TS_IE_CORRECTION.</param>
		/// <param name="acpStart">Contains the starting character position where the object is inserted.</param>
		/// <param name="acpEnd">Contains the ending character position where the object is inserted.</param>
		/// <param name="pDataObject">Pointer to an IDataObject interface that contains data about the object inserted.</param>
		/// <param name="pChange">Pointer to a TS_TEXTCHANGE structure that receives data about the modified text.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One or more parameters are invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_NOTIMPL</term>
		/// <term>The application does not support embedded objects.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_FORMAT</term>
		/// <term>The application does not support the data type contained in pDataObject.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_INVALIDPOS</term>
		/// <term>acpStart and/or acpEnd are not within the document.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_NOLOCK</term>
		/// <term>The caller does not have a read/write lock.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreacp2-insertembedded HRESULT InsertEmbedded(
		// DWORD dwFlags, LONG acpStart, LONG acpEnd, IDataObject *pDataObject, TS_TEXTCHANGE *pChange );
		[PreserveSig]
		HRESULT InsertEmbedded([In] TS_IE dwFlags, [In] int acpStart, [In] int acpEnd, [In] IDataObject pDataObject, out TS_TEXTCHANGE pChange);

		/// <summary>
		/// Inserts text at the insertion point or selection. A caller must have a read/write lock on the document before inserting text.
		/// </summary>
		/// <param name="dwFlags"/>
		/// <param name="pchText"/>
		/// <param name="cch"/>
		/// <param name="pacpStart"/>
		/// <param name="pacpEnd"/>
		/// <param name="pChange"/>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// <para>
		/// The values of the pacpStart and the pacpEnd parameters depend upon how the client application inserts text into a document.
		/// For example, if the application sets the cursor at the start of the inserted text after text insertion, then the value for
		/// the pacpStart and pacpEnd parameters is the same as the <c>acpStart</c> member of the TS_TEXTCHANGE structure.
		/// </para>
		/// <para>Applications should not call the OnTextChange method in response to this method.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreacp2-inserttextatselection HRESULT
		// InsertTextAtSelection( DWORD dwFlags, const WCHAR *pchText, ULONG cch, LONG *pacpStart, LONG *pacpEnd, TS_TEXTCHANGE *pChange );
		[PreserveSig]
		HRESULT InsertTextAtSelection([In] TF_IAS dwFlags, [In, MarshalAs(UnmanagedType.LPWStr)] string pchText, [In] uint cch, out int pacpStart, out int pacpEnd, out TS_TEXTCHANGE pChange);

		/// <summary>
		/// Inserts an IDataObject at the insertion point or selection. The client that calls this method must have a read/write lock
		/// before inserting an IDataObject object into the document.
		/// </summary>
		/// <param name="dwFlags">
		/// <para>
		/// Specifies whether the pacpStart and pacpEnd parameters and the TS_TEXTCHANGE structure will contain the results of the
		/// object insertion.
		/// </para>
		/// <para>The TF_IAS_NOQUERY and TF_IAS_QUERYONLY flags cannot be combined.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>
		/// Text insertion will occur, and the pacpStart and pacpEnd parameters will contain the results of the text insertion. The
		/// TS_TEXTCHANGE structure must be filled with this flag.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TF_IAS_NOQUERY</term>
		/// <term>
		/// Text is inserted, the values of the pacpStart and pacpEnd parameters can be NULL, and the TS_TEXTCHANGE structure must be
		/// filled. Use this flag if the results of the text insertion are not required.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TF_IAS_QUERYONLY</term>
		/// <term>
		/// Text is not inserted, and the values for the pacpStart and pacpEnd parameter contain the results of the text insertion. The
		/// values of these parameters depend on how the application implements text insertion into a document. For more information,
		/// see the Remarks section. Use this flag to view the results of the text insertion without actually inserting the text, for
		/// example, to predict the results of collapsing or otherwise adjusting a selection. It is not required that you fill the
		/// TS_TEXTCHANGE structure with this flag.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pDataObject">Pointer to the IDataObject object to be inserted.</param>
		/// <param name="pacpStart">Pointer to the starting application character position where the object insertion will occur.</param>
		/// <param name="pacpEnd">
		/// Pointer to the ending application character position where the object insertion will occur. This parameter value will be the
		/// same as the value of the pacpStart parameter for an insertion point.
		/// </param>
		/// <param name="pChange">
		/// <para>Pointer to a TS_TEXTCHANGE structure with the following members.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>acpStart</term>
		/// <term>The starting application character position before the object is inserted into the document.</term>
		/// </item>
		/// <item>
		/// <term>acpOldEnd</term>
		/// <term>
		/// The ending application character position before the object is inserted into the document. This value is the same as
		/// acpStart for an insertion point. If this value is different from acpStart, then text was selected prior to the object insertion.
		/// </term>
		/// </item>
		/// <item>
		/// <term>acpNewEnd</term>
		/// <term>The ending application character position after the object insertion took place.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The pchText parameter is invalid.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_NOLOCK</term>
		/// <term>The caller does not have a lock on the document.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// The values of the pacpStart and pacpEnd parameters depend upon how the client application inserts an object into a document.
		/// For example, if the application sets the cursor at the start of the object after object insertion, then the value of the
		/// pacpStart and pacpEnd parameters is the same as the <c>acpStart</c> member of the TS_TEXTCHANGE structure.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreacp2-insertembeddedatselection HRESULT
		// InsertEmbeddedAtSelection( DWORD dwFlags, IDataObject *pDataObject, LONG *pacpStart, LONG *pacpEnd, TS_TEXTCHANGE *pChange );
		[PreserveSig]
		HRESULT InsertEmbeddedAtSelection([In] TF_IAS dwFlags, [In] IDataObject pDataObject, out int pacpStart, out int pacpEnd, out TS_TEXTCHANGE pChange);

		/// <summary>Get the attributes that are supported in the document.</summary>
		/// <param name="dwFlags">
		/// Specifies whether a subsequent call to the RetrieveRequestedAttrs method will contain the supported attributes. If the
		/// <c>TS_ATTR_FIND_WANT_VALUE</c> flag is specified, the default attribute values will be those in the TS_ATTRVAL structure
		/// after the subsequent call to <c>RetrieveRequestedAttrs</c>. If any other flag is specified for this parameter, the method
		/// only verifies that the attribute is supported and that the <c>varValue</c> member of the <c>TS_ATTRVAL</c> structure is set
		/// to <c>VT_EMPTY</c>.
		/// </param>
		/// <param name="cFilterAttrs">Specifies the number of supported attributes to obtain.</param>
		/// <param name="paFilterAttrs">
		/// Pointer to the TS_ATTRID data type that specifies the attribute to verify. The method returns only the attributes specified
		/// by <c>TS_ATTRID</c>, even though other attributes can be supported.
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>An unspecified error occurred.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>The method was unable to allocate sufficient memory to complete the operation.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreacp2-requestsupportedattrs HRESULT
		// RequestSupportedAttrs( DWORD dwFlags, ULONG cFilterAttrs, const TS_ATTRID *paFilterAttrs );
		[PreserveSig]
		HRESULT RequestSupportedAttrs([In] TS_ATTR_FIND dwFlags, [In] uint cFilterAttrs, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] TS_ATTRID[] paFilterAttrs);

		/// <summary>Gets text attributes at the specified character position.</summary>
		/// <param name="acpPos">Specifies the application character position in the document.</param>
		/// <param name="cFilterAttrs">Specifies the number of attributes to obtain.</param>
		/// <param name="paFilterAttrs">Pointer to the TS_ATTRID data type that specifies the attribute to verify.</param>
		/// <param name="dwFlags">
		/// <para>
		/// Specifies attributes for the call to the RetrieveRequestedAttrs method. If this parameter is not set, the method returns the
		/// attributes that start at the specified position. Other possible values for this parameter are the following.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TS_ATTR_FIND_WANT_END</term>
		/// <term>Obtains the attributes that end at the specified application character position.</term>
		/// </item>
		/// <item>
		/// <term>TS_ATTR_FIND_WANT_VALUE</term>
		/// <term>
		/// Obtains the value of the attribute in addition to the attribute. The attribute value is put into the varValue member of the
		/// TS_ATTRVAL structure during the RetrieveRequestedAttrs method call.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// In the sentence, "This is italic text.", the italic attribute starts before the word italic and ends after the word text.
		/// </para>
		/// <para>
		/// If the flag <c>TS_ATTR_FIND_WANT_END</c> is set in dwFlags, the method would return the italic attribute for the text
		/// "italic &lt;anchor&gt;normal", because there is an end transition at the anchor location.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreacp2-requestattrsatposition HRESULT
		// RequestAttrsAtPosition( LONG acpPos, ULONG cFilterAttrs, const TS_ATTRID *paFilterAttrs, DWORD dwFlags );
		[PreserveSig]
		HRESULT RequestAttrsAtPosition([In] int acpPos, [In] uint cFilterAttrs, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] TS_ATTRID[] paFilterAttrs, uint dwFlags = 0);

		/// <summary>Gets text attributes transitioning at the specified character position.</summary>
		/// <param name="acpPos">Specifies the application character position in the document.</param>
		/// <param name="cFilterAttrs">Specifies the number of attributes to obtain.</param>
		/// <param name="paFilterAttrs">Pointer to the TS_ATTRID data type that specifies the attribute to verify.</param>
		/// <param name="dwFlags">
		/// <para>
		/// Specifies attributes for the call to the RetrieveRequestedAttrs method. If this parameter is not set, the method returns the
		/// attributes that start at the specified position. Other possible values for this parameter are the following.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TS_ATTR_FIND_WANT_END</term>
		/// <term>Obtains the attributes that end at the specified application character position.</term>
		/// </item>
		/// <item>
		/// <term>TS_ATTR_FIND_WANT_VALUE</term>
		/// <term>
		/// Obtains the value of the attribute in addition to the attribute. The attribute value is put into the varValue member of the
		/// TS_ATTRVAL structure during the RetrieveRequestedAttrs method call.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// In the sentence, "This is italic text.", the italic attribute starts before the word italic and ends after the word text.
		/// </para>
		/// <para>
		/// If the flag TS_ATTR_FIND_WANT_END is set in dwFlags, the method would return the italic attribute for the text "italic
		/// &lt;anchor&gt;normal", because there is an end transition at the anchor location.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreacp2-requestattrstransitioningatposition
		// HRESULT RequestAttrsTransitioningAtPosition( LONG acpPos, ULONG cFilterAttrs, const TS_ATTRID *paFilterAttrs, DWORD dwFlags );
		[PreserveSig]
		HRESULT RequestAttrsTransitioningAtPosition([In] int acpPos, [In] uint cFilterAttrs, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] TS_ATTRID[] paFilterAttrs, [In] TS_ATTR_FIND dwFlags);

		/// <summary>
		/// Determines the character position where a transition occurs in an attribute value. The specified attribute to check is application-dependent.
		/// </summary>
		/// <param name="acpStart">Specifies the character position to start the search for an attribute transition.</param>
		/// <param name="acpHalt">Specifies the character position to end the search for an attribute transition.</param>
		/// <param name="cFilterAttrs">Specifies the number of attributes to check.</param>
		/// <param name="paFilterAttrs">Pointer to the TS_ATTRID data type that specifies the attribute to check.</param>
		/// <param name="dwFlags">
		/// <para>Specifies the direction to search for an attribute transition. By default, the method searches forward.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TS_ATTR_FIND_BACKWARDS</term>
		/// <term>The method searches backward.</term>
		/// </item>
		/// <item>
		/// <term>TS_ATTR_FIND_WANT_OFFSET</term>
		/// <term>The plFoundOffset parameter receives the character offset of the attribute transition from acpStart.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pacpNext">Receives the next character position to check for an attribute transition.</param>
		/// <param name="pfFound">
		/// Receives a Boolean value of <c>TRUE</c> if an attribute transition was found, otherwise <c>FALSE</c> is returned.
		/// </param>
		/// <param name="plFoundOffset">
		/// Receives the character position of the attribute transition (not ACP positions). If TS_ATTR_FIND_WANT_OFFSET flag is set in
		/// dwFlags, receives the character offset of the attribute transition from acpStart.
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_INVALIDPOS</term>
		/// <term>The character positions specified are beyond the text in the document.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <c>Note</c> If an application does not implement <c>FindNextAttrTransition</c>, ITfReadOnlyProperty::EnumRanges fails with <c>E_FAIL</c>.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreacp2-findnextattrtransition HRESULT
		// FindNextAttrTransition( LONG acpStart, LONG acpHalt, ULONG cFilterAttrs, const TS_ATTRID *paFilterAttrs, DWORD dwFlags, LONG
		// *pacpNext, BOOL *pfFound, LONG *plFoundOffset );
		[PreserveSig]
		HRESULT FindNextAttrTransition([In] int acpStart, [In] int acpHalt, [In] uint cFilterAttrs, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] TS_ATTRID[] paFilterAttrs,
			[In] TS_ATTR_FIND dwFlags, out int pacpNext, [MarshalAs(UnmanagedType.Bool)] out bool pfFound, out int plFoundOffset);

		/// <summary>Gets the attributes returned by a call to an attribute request method.</summary>
		/// <param name="ulCount">Specifies the number of supported attributes to obtain.</param>
		/// <param name="paAttrVals">
		/// Pointer to the TS_ATTRVAL structure that receives the supported attributes. The members of this structure depend upon the
		/// dwFlags parameter of the calling method.
		/// </param>
		/// <param name="pcFetched">Receives the number of supported attributes.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreacp2-retrieverequestedattrs HRESULT
		// RetrieveRequestedAttrs( ULONG ulCount, TS_ATTRVAL *paAttrVals, ULONG *pcFetched );
		[PreserveSig]
		HRESULT RetrieveRequestedAttrs([In] uint ulCount, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] TS_ATTRVAL[] paAttrVals, [NullAllowed] out uint pcFetched);

		/// <summary>Gets the number of characters in a document.</summary>
		/// <param name="pacp">Receives the character position of the last character in the document plus one.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_NOTIMPL</term>
		/// <term>
		/// The application has not implemented this method. This is usually an indication that calculating the end position requires
		/// excessive resources. If the end position is necessary, you can use GetText to calculate it, though this can also be a
		/// memory-intensive operation, paging in arbitrarily large amounts of memory from disk.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TS_E_NOLOCK</term>
		/// <term>The caller does not have a read-only lock.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreacp2-getendacp HRESULT GetEndACP( LONG
		// *pacp );
		[PreserveSig]
		HRESULT GetEndACP(out int pacp);

		/// <summary>Gets a TsViewCookie that represents the current active view.</summary>
		/// <param name="pvcView">Receives the <c>TsViewCookie</c> data type that specifies the current active view.</param>
		/// <returns>This method has no return values.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreacp2-getactiveview HRESULT GetActiveView(
		// TsViewCookie *pvcView );
		[PreserveSig]
		HRESULT GetActiveView(out TsViewCookie pvcView);

		/// <summary>Converts a point in screen coordinates to an application character position.</summary>
		/// <param name="vcView">Specifies the context view.</param>
		/// <param name="ptScreen">Pointer to the <c>POINT</c> structure with the screen coordinates of the point.</param>
		/// <param name="dwFlags">
		/// <para>
		/// Specifies the character position to return based upon the screen coordinates of the point relative to a character bounding
		/// box. By default, the character position returned is the character bounding box containing the screen coordinates of the
		/// point. If the point is outside a character bounding box, the method returns <c>NULL</c> or TF_E_INVALIDPOINT. Other bit
		/// flags for this parameter are as follows.
		/// </para>
		/// <para>The bit flags can be combined.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>GXFPF_ROUND_NEAREST</term>
		/// <term>
		/// If the screen coordinates of the point are contained in a character bounding box, the character position returned is the
		/// bounding edge closest to the screen coordinates of the point.
		/// </term>
		/// </item>
		/// <item>
		/// <term>GXFPF_NEAREST</term>
		/// <term>
		/// If the screen coordinates of the point are not contained in a character bounding box, the closest character position is returned.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pacp">Receives the character position that corresponds to the screen coordinates of the point.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_INVALIDPOINT</term>
		/// <term>The ptScreen parameter is not within the bounding box of any character.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_NOLAYOUT</term>
		/// <term>The application has not calculated a text layout.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreacp2-getacpfrompoint HRESULT
		// GetACPFromPoint( TsViewCookie vcView, const POINT *ptScreen, DWORD dwFlags, LONG *pacp );
		[PreserveSig]
		HRESULT GetACPFromPoint([In] TsViewCookie vcView, in POINT ptScreen, [In] GXFPF dwFlags, out int pacp);

		/// <summary>
		/// Gets the bounding box, in screen coordinates, of the text at a specified character position. The caller must have a
		/// read-only lock on the document before calling this method.
		/// </summary>
		/// <param name="vcView">Specifies the context view.</param>
		/// <param name="acpStart">Specifies the starting character position of the text to get in the document.</param>
		/// <param name="acpEnd">Specifies the ending character position of the text to get in the document.</param>
		/// <param name="prc">Receives the bounding box in screen coordinates of the text at the specified character positions.</param>
		/// <param name="pfClipped">
		/// Receives a Boolean value that specifies if the text in the bounding box has been clipped. If this parameter is <c>TRUE</c>,
		/// the bounding box contains clipped text and does not include the entire requested text range. The bounding box is clipped
		/// because the requested range is not visible.
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_INVALIDARG</term>
		/// <term>The specified start and end character positions are equal.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_INVALIDPOS</term>
		/// <term>The range specified by the acpStart and acpEnd parameters extends past the beginning or end of the document.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_NOLAYOUT</term>
		/// <term>The application has not calculated a text layout.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_NOLOCK</term>
		/// <term>The caller does not have a read-only lock on the document.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// If the document window is minimized, or if the specified text is not currently visible, the method returns <c>S_OK</c> with
		/// the prc parameter set to {0,0,0,0}.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreacp2-gettextext HRESULT GetTextExt(
		// TsViewCookie vcView, LONG acpStart, LONG acpEnd, RECT *prc, BOOL *pfClipped );
		[PreserveSig]
		HRESULT GetTextExt([In] TsViewCookie vcView, [In] int acpStart, [In] int acpEnd, out RECT prc, [Out, MarshalAs(UnmanagedType.Bool)] out bool pfClipped);

		/// <summary>Gets the bounding box screen coordinates of the display surface where the text stream is rendered.</summary>
		/// <param name="vcView">Specifies the context view.</param>
		/// <param name="prc">Receives the bounding box screen coordinates of the display surface of the document.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The specified vcView parameter is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// If the text is not currently displayed, for example, if the document window is minimized, the prc parameter is set to { 0,
		/// 0, 0, 0 }.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreacp2-getscreenext HRESULT GetScreenExt(
		// TsViewCookie vcView, RECT *prc );
		[PreserveSig]
		HRESULT GetScreenExt([In] TsViewCookie vcView, out RECT prc);
	}

	/// <summary>
	/// The <c>ITextStoreACPSink</c> interface is implemented by the TSF manager and is used by an ACP-based application to notify the
	/// manager when certain events occur. The manager installs this advise sink by calling ITextStoreACP::AdviseSink.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nn-textstor-itextstoreacpsink
	[PInvokeData("textstor.h", MSDNShortId = "NN:textstor.ITextStoreACPSink")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("22D44C94-A419-4542-A272-AE26093ECECF")]
	public interface ITextStoreACPSink
	{
		/// <summary>Called when the text of a document changes.</summary>
		/// <param name="dwFlags">
		/// <para>
		/// Contains a set of flags that specify additional information about the text change. This can be one or more of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>The text has changed.</term>
		/// </item>
		/// <item>
		/// <term>TS_ST_CORRECTION</term>
		/// <term>
		/// The text is a transform (correction) of existing content, and any special text markup information (metadata) is retained,
		/// such as .wav file data or a language identifier. This flag is used for applications that need to preserve data associated
		/// with the original text.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pChange">Pointer to a TS_TEXTCHANGE structure that contains text change data.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>pChange is invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>A memory allocation failure occurred.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_NOLOCK</term>
		/// <term>
		/// The TSF manager holds a lock on the document. This typically indicates that the method was called from within another
		/// ITextStoreACP method, such as ITextStoreACP::SetText.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>ITextStoreACPSink::OnTextChange</c> is never called when the text is modified by one of the <c>ITextStoreACP</c>
		/// interface methods, such as <c>ITextStoreACP::SetText</c> or ITextStoreACP::InsertTextAtSelection.
		/// </para>
		/// <para>When calling this method, the application must be able to grant a document lock.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreacpsink-ontextchange HRESULT OnTextChange(
		// DWORD dwFlags, const TS_TEXTCHANGE *pChange );
		[PreserveSig]
		HRESULT OnTextChange([In] TS_ST dwFlags, in TS_TEXTCHANGE pChange);

		/// <summary>Called when the selection within the document changes.</summary>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_NOLOCK</term>
		/// <term>The manager holds a lock on the document.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>ITextStoreACPSink::OnSelectionChange</c> is never called when the selection is modified by one of the ITextStoreACP
		/// interface methods, such as ITextStoreACP::SetSelection or ITextStoreACP::InsertTextAtSelection.
		/// </para>
		/// <para>When calling this method, the application must be able to grant a document lock.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreacpsink-onselectionchange HRESULT OnSelectionChange();
		[PreserveSig]
		HRESULT OnSelectionChange();

		/// <summary>Called when the layout (on-screen representation) of the document changes.</summary>
		/// <param name="lcode">Contains a TsLayoutCode value that defines the type of change.</param>
		/// <param name="vcView">Contains an application-defined cookie that identifies the document. For more information, see ITextStoreACP::GetActiveView.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A layout change can be in response to a change to the text, font size, window movement, window resizing, or other change
		/// that affects the displayed text.
		/// </para>
		/// <para>
		/// If a call to ITextStoreACP::GetTextExt or ITextStoreACP::GetACPFromPoint returns TS_E_NOLAYOUT because the application has
		/// not calculated the layout, the application must call <c>ITextStoreACPSink::OnLayoutChange</c> when the layout is available.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreacpsink-onlayoutchange HRESULT
		// OnLayoutChange( TsLayoutCode lcode, TsViewCookie vcView );
		[PreserveSig]
		HRESULT OnLayoutChange([In] TsLayoutCode lcode, [In] TsViewCookie vcView);

		/// <summary>Called when the status of the document changes.</summary>
		/// <param name="dwFlags">
		/// Contains a value that specifies the new status. For more information about possible values, see the <c>dwDynamicFlags</c>
		/// member of the TS_STATUS structure.
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreacpsink-onstatuschange HRESULT
		// OnStatusChange( DWORD dwFlags );
		[PreserveSig]
		HRESULT OnStatusChange(TS_SD dwFlags);

		/// <summary>Called when the value of one or more text attribute changes.</summary>
		/// <param name="acpStart">Specifies the starting point of the attribute change.</param>
		/// <param name="acpEnd">Specifies the ending point of the attribute change.</param>
		/// <param name="cAttrs">Specifies the number of attributes in the paAttrs array.</param>
		/// <param name="paAttrs">Pointer to an array of TS_ATTRID values that identify the attributes changed.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>A memory allocation failure occurred.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One or more parameters are invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreacpsink-onattrschange HRESULT
		// OnAttrsChange( LONG acpStart, LONG acpEnd, ULONG cAttrs, const TS_ATTRID *paAttrs );
		[PreserveSig]
		HRESULT OnAttrsChange(int acpStart, int acpEnd, uint cAttrs, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] TS_ATTRID[] paAttrs);

		/// <summary>Called to grant a document lock.</summary>
		/// <param name="dwLockFlags">
		/// <para>
		/// Contains a set of flags that identify the type of lock requested and other lock request data. This can be one of the
		/// following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TS_LF_READ</term>
		/// <term>The lock is read-only.</term>
		/// </item>
		/// <item>
		/// <term>TS_LF_READWRITE</term>
		/// <term>The lock is read/write.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>dwLockFlags is invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_UNEXPECTED</term>
		/// <term>The wrong type of lock was granted.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A document lock is requested by calling <c>ITextStoreACP::RequestLock</c> . The application grants the lock request by
		/// calling <c>ITextStoreACPSink::OnLockGranted</c> with the requested lock type. The lock is only valid during the
		/// <c>OnLockGranted</c> call. When <c>OnLockGranted</c> returns, the document is considered unlocked.
		/// </para>
		/// <para>The lock type, specified in dwLockFlags, must match the requested lock type in the corresponding call to <c>ITextStoreACP::RequestLock</c>.</para>
		/// <para>
		/// If a synchronous lock request is made from within <c>ITextStoreACP::RequestLock</c>, then the caller must also provide the
		/// return value from <c>ITextStoreACP::RequestLock</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreacpsink-onlockgranted HRESULT
		// OnLockGranted( DWORD dwLockFlags );
		[PreserveSig]
		HRESULT OnLockGranted(TS_LF dwLockFlags);

		/// <summary>Called when an edit transaction is started.</summary>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method causes the ITfEditTransactionSink::OnStartEditTransaction method to be called on all installed edit transaction sinks.
		/// </para>
		/// <para>
		/// An edit transaction is a group of text changes that should be processed at one time. Calling this method allows a text
		/// service to queue the upcoming changes until ITextStoreACPSink::OnEndEditTransaction is called. When
		/// <c>ITextStoreACPSink::OnEndEditTransaction</c> is called, the text service will process all queued changes. Use of edit
		/// transactions is optional.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreacpsink-onstartedittransaction HRESULT OnStartEditTransaction();
		[PreserveSig]
		HRESULT OnStartEditTransaction();

		/// <summary>Called when an edit transaction is terminated.</summary>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method causes the ITfEditTransactionSink::OnEndEditTransaction method to be called on all installed edit transaction sinks.
		/// </para>
		/// <para>
		/// An edit transaction is a group of text changes that should be processed at one time. Calling
		/// ITextStoreACPSink::OnStartEditTransaction allows a text service to queue the upcoming changes until
		/// <c>ITextStoreACPSink::OnEndEditTransaction</c> is called. When <c>ITextStoreACPSink::OnEndEditTransaction</c> is called, the
		/// text service will process all of the queued changes. Use of edit transactions is optional.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreacpsink-onendedittransaction HRESULT OnEndEditTransaction();
		[PreserveSig]
		HRESULT OnEndEditTransaction();
	}

	/// <summary>Undocumented.</summary>
	[PInvokeData("textstor.h")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("2bdf9464-41e2-43e3-950c-a6865ba25cd4")]
	public interface ITextStoreACPSinkEx : ITextStoreACPSink
	{
		/// <summary>Called when the text of a document changes.</summary>
		/// <param name="dwFlags">
		/// <para>
		/// Contains a set of flags that specify additional information about the text change. This can be one or more of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>The text has changed.</term>
		/// </item>
		/// <item>
		/// <term>TS_ST_CORRECTION</term>
		/// <term>
		/// The text is a transform (correction) of existing content, and any special text markup information (metadata) is retained,
		/// such as .wav file data or a language identifier. This flag is used for applications that need to preserve data associated
		/// with the original text.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pChange">Pointer to a TS_TEXTCHANGE structure that contains text change data.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>pChange is invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>A memory allocation failure occurred.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_NOLOCK</term>
		/// <term>
		/// The TSF manager holds a lock on the document. This typically indicates that the method was called from within another
		/// ITextStoreACP method, such as ITextStoreACP::SetText.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>ITextStoreACPSink::OnTextChange</c> is never called when the text is modified by one of the <c>ITextStoreACP</c>
		/// interface methods, such as <c>ITextStoreACP::SetText</c> or ITextStoreACP::InsertTextAtSelection.
		/// </para>
		/// <para>When calling this method, the application must be able to grant a document lock.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreacpsink-ontextchange HRESULT OnTextChange(
		// DWORD dwFlags, const TS_TEXTCHANGE *pChange );
		[PreserveSig]
		new HRESULT OnTextChange([In] TS_ST dwFlags, in TS_TEXTCHANGE pChange);

		/// <summary>Called when the selection within the document changes.</summary>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_NOLOCK</term>
		/// <term>The manager holds a lock on the document.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>ITextStoreACPSink::OnSelectionChange</c> is never called when the selection is modified by one of the ITextStoreACP
		/// interface methods, such as ITextStoreACP::SetSelection or ITextStoreACP::InsertTextAtSelection.
		/// </para>
		/// <para>When calling this method, the application must be able to grant a document lock.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreacpsink-onselectionchange HRESULT OnSelectionChange();
		[PreserveSig]
		new HRESULT OnSelectionChange();

		/// <summary>Called when the layout (on-screen representation) of the document changes.</summary>
		/// <param name="lcode">Contains a TsLayoutCode value that defines the type of change.</param>
		/// <param name="vcView">Contains an application-defined cookie that identifies the document. For more information, see ITextStoreACP::GetActiveView.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A layout change can be in response to a change to the text, font size, window movement, window resizing, or other change
		/// that affects the displayed text.
		/// </para>
		/// <para>
		/// If a call to ITextStoreACP::GetTextExt or ITextStoreACP::GetACPFromPoint returns TS_E_NOLAYOUT because the application has
		/// not calculated the layout, the application must call <c>ITextStoreACPSink::OnLayoutChange</c> when the layout is available.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreacpsink-onlayoutchange HRESULT
		// OnLayoutChange( TsLayoutCode lcode, TsViewCookie vcView );
		[PreserveSig]
		new HRESULT OnLayoutChange([In] TsLayoutCode lcode, [In] TsViewCookie vcView);

		/// <summary>Called when the status of the document changes.</summary>
		/// <param name="dwFlags">
		/// Contains a value that specifies the new status. For more information about possible values, see the <c>dwDynamicFlags</c>
		/// member of the TS_STATUS structure.
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreacpsink-onstatuschange HRESULT
		// OnStatusChange( DWORD dwFlags );
		[PreserveSig]
		new HRESULT OnStatusChange(TS_SD dwFlags);

		/// <summary>Called when the value of one or more text attribute changes.</summary>
		/// <param name="acpStart">Specifies the starting point of the attribute change.</param>
		/// <param name="acpEnd">Specifies the ending point of the attribute change.</param>
		/// <param name="cAttrs">Specifies the number of attributes in the paAttrs array.</param>
		/// <param name="paAttrs">Pointer to an array of TS_ATTRID values that identify the attributes changed.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>A memory allocation failure occurred.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One or more parameters are invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreacpsink-onattrschange HRESULT
		// OnAttrsChange( LONG acpStart, LONG acpEnd, ULONG cAttrs, const TS_ATTRID *paAttrs );
		[PreserveSig]
		new HRESULT OnAttrsChange(int acpStart, int acpEnd, uint cAttrs, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] TS_ATTRID[] paAttrs);

		/// <summary>Called to grant a document lock.</summary>
		/// <param name="dwLockFlags">
		/// <para>
		/// Contains a set of flags that identify the type of lock requested and other lock request data. This can be one of the
		/// following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TS_LF_READ</term>
		/// <term>The lock is read-only.</term>
		/// </item>
		/// <item>
		/// <term>TS_LF_READWRITE</term>
		/// <term>The lock is read/write.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>dwLockFlags is invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_UNEXPECTED</term>
		/// <term>The wrong type of lock was granted.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A document lock is requested by calling <c>ITextStoreACP::RequestLock</c> . The application grants the lock request by
		/// calling <c>ITextStoreACPSink::OnLockGranted</c> with the requested lock type. The lock is only valid during the
		/// <c>OnLockGranted</c> call. When <c>OnLockGranted</c> returns, the document is considered unlocked.
		/// </para>
		/// <para>The lock type, specified in dwLockFlags, must match the requested lock type in the corresponding call to <c>ITextStoreACP::RequestLock</c>.</para>
		/// <para>
		/// If a synchronous lock request is made from within <c>ITextStoreACP::RequestLock</c>, then the caller must also provide the
		/// return value from <c>ITextStoreACP::RequestLock</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreacpsink-onlockgranted HRESULT
		// OnLockGranted( DWORD dwLockFlags );
		[PreserveSig]
		new HRESULT OnLockGranted(TS_LF dwLockFlags);

		/// <summary>Called when an edit transaction is started.</summary>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method causes the ITfEditTransactionSink::OnStartEditTransaction method to be called on all installed edit transaction sinks.
		/// </para>
		/// <para>
		/// An edit transaction is a group of text changes that should be processed at one time. Calling this method allows a text
		/// service to queue the upcoming changes until ITextStoreACPSink::OnEndEditTransaction is called. When
		/// <c>ITextStoreACPSink::OnEndEditTransaction</c> is called, the text service will process all queued changes. Use of edit
		/// transactions is optional.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreacpsink-onstartedittransaction HRESULT OnStartEditTransaction();
		[PreserveSig]
		new HRESULT OnStartEditTransaction();

		/// <summary>Called when an edit transaction is terminated.</summary>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method causes the ITfEditTransactionSink::OnEndEditTransaction method to be called on all installed edit transaction sinks.
		/// </para>
		/// <para>
		/// An edit transaction is a group of text changes that should be processed at one time. Calling
		/// ITextStoreACPSink::OnStartEditTransaction allows a text service to queue the upcoming changes until
		/// <c>ITextStoreACPSink::OnEndEditTransaction</c> is called. When <c>ITextStoreACPSink::OnEndEditTransaction</c> is called, the
		/// text service will process all of the queued changes. Use of edit transactions is optional.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreacpsink-onendedittransaction HRESULT OnEndEditTransaction();
		[PreserveSig]
		new HRESULT OnEndEditTransaction();

		/// <summary>Called when disconnect.</summary>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// </list>
		/// </returns>
		[PreserveSig]
		HRESULT OnDisconnect();
	}

	/// <summary>
	/// <para>
	/// The ITextStoreAnchor interface is implemented by a Microsoft Active Accessibility client and is used by the TSF manager to
	/// manipulate text streams. Ranges of text within a stream are delimited by anchor objects. these anchor objects are exposed and
	/// manipulated by the IAnchor interface.
	/// </para>
	/// <para>An application can obtain an instance of this interface with Microsoft Active Accessibility. The interface ID is IID_ITextStoreAnchor.</para>
	/// <para>To use the application character position (ACP) model for text manipulation, use ITextStoreACP instead.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nn-textstor-itextstoreanchor
	[PInvokeData("textstor.h", MSDNShortId = "NN:textstor.ITextStoreAnchor")]
	[ComImport, Guid("9B2077B0-5F18-4DEC-BEE9-3CC722F5DFE0"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ITextStoreAnchor
	{
		/// <summary>
		/// The <c>ITextStoreAnchor::AdviseSink</c> method installs a new advise sink from the ITextStoreAnchorSink interface or
		/// modifies an existing advise sink.
		/// </summary>
		/// <param name="riid">Specifies the sink interface. The only supported value is IID_ITextStoreAnchorSink.</param>
		/// <param name="punk">Pointer to the sink interface to advise. Cannot be <c>NULL</c>.</param>
		/// <param name="dwMask">
		/// Specifies the events that notify the advise sink. For more information about possible parameter values, see TS_AS_* Constants.
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>The specified sink interface riid could not be obtained.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The specified sink interface is unsupported.</term>
		/// </item>
		/// <item>
		/// <term>E_UNEXPECTED</term>
		/// <term>The specified sink object could not be obtained.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Subsequent calls with the same interface, represented by the punk parameter, are handled as requests to update the dwMask
		/// parameter. Servers should not call the <c>AddRef</c> method on the sink in response to such a request.
		/// </para>
		/// <para>
		/// Servers only maintain a single connection point. Attempts to advise a second sink object fail until the original sink object
		/// is removed. Applications should use the ITextStoreAnchor::UnadviseSink method to unregister the sink object when
		/// notifications are not required.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreanchor-advisesink HRESULT AdviseSink(
		// REFIID riid, IUnknown *punk, DWORD dwMask );
		[PreserveSig]
		HRESULT AdviseSink(in Guid riid, [In, MarshalAs(UnmanagedType.IUnknown)] object punk, [In] TS_AS dwMask);

		/// <summary>Called by an application to indicate that it no longer requires notifications from the TSF manager.</summary>
		/// <param name="punk">Pointer to a sink object. Cannot be <c>NULL</c>.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>CONNECT_E_NOCONNECTION</term>
		/// <term>There is no active sink object.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Every call to the ITextStoreAnchor::AdviseSink method, which registers a new sink object, should be matched by a call to
		/// this method. If AdviseSink has only updated the dwMask parameter of a sink which was previously registered, a call to
		/// <c>UnadviseSink</c> is not required.
		/// </para>
		/// <para>
		/// For example, to register a sink object, an application calls the <c>AdviseSink</c> method the first time. The application
		/// can then call the <c>AdviseSink</c> method again with the same sink object to change the dwMask parameter. To unregister the
		/// sink object, an application calls the <c>UnadviseSink</c> method.
		/// </para>
		/// <para>The punk parameter must have the same COM identity as the pointer originally passed in the <c>AdviseSink</c> method.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreanchor-unadvisesink HRESULT UnadviseSink(
		// IUnknown *punk );
		[PreserveSig]
		HRESULT UnadviseSink([In, MarshalAs(UnmanagedType.IUnknown)] object punk);

		/// <summary>Used by the TSF manager to provide a document lock in order to modify the text stream.</summary>
		/// <param name="dwLockFlags">
		/// <para>Specifies the type of lock requested.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TS_LF_READ</term>
		/// <term>The document has a read-only lock and cannot be modified.</term>
		/// </item>
		/// <item>
		/// <term>TS_LF_READWRITE</term>
		/// <term>The document has a read/write lock and can be modified.</term>
		/// </item>
		/// <item>
		/// <term>TS_LF_SYNC</term>
		/// <term>The document has a synchronous-lock if this flag is combined with other flags.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="phrSession">
		/// <para>
		/// If the lock request is synchronous, receives an HRESULT value from the ITextStoreAnchorSink::OnLockGranted method that
		/// specifies the result of the lock request.
		/// </para>
		/// <para>
		/// If the lock request is asynchronous and the result is TS_S_ASYNC, the document receives an asynchronous lock. If the lock
		/// request is asynchronous and the result is TS_E_SYNCHRONOUS, the document cannot be locked synchronously.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>An unspecified error occurred.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method uses the <c>ITextStoreAnchorSink::OnLockGranted</c> method to lock the document. Applications must never modify
		/// the document or send change notifications using the ITextStoreAnchorSink::OnTextChange method from within the
		/// <c>ITextStoreAnchor::RequestLock</c> method. If the application has pending changes to report, the application can only
		/// respond to the asynchronous lock request.
		/// </para>
		/// <para>
		/// Applications should not attempt to queue multiple <c>ITextStoreAnchor::RequestLock</c> method calls, because the application
		/// requires only a single callback. If the caller makes several read requests and one or more write requests, however, the
		/// callback should be for write access.
		/// </para>
		/// <para>
		/// Successful requests for synchronous locks supersede requests for asynchronous locks. Unsuccessful requests for synchronous
		/// locks do not supersede requests for asynchronous locks. The implementation must still serve the outstanding asynchronous
		/// request, if one exists.
		/// </para>
		/// <para>
		/// If the lock is granted before the <c>ITextStoreAnchor::RequestLock</c> method returns, the phrSession parameter will receive
		/// the HRESULT returned by the <c>ITextStoreAnchorSink::OnLockGranted</c> method. If the call is successful, but the lock will
		/// be granted later, the phrSession parameter receives the TS_S_ASYNC flag. The phrSession parameter should be ignored if
		/// <c>ITextStoreAnchor::RequestLock</c> returns anything other than S_OK.
		/// </para>
		/// <para>
		/// A caller should never call this method reentrantly, except in the case that the caller holds a read-only lock. In this case
		/// the method can be called reentrantly to ask for an asynchronous write lock. The write lock will be granted later, after the
		/// read-only lock ends.
		/// </para>
		/// <para>For more information about document locks, see Document Locks.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreanchor-requestlock HRESULT RequestLock(
		// DWORD dwLockFlags, HRESULT *phrSession );
		[PreserveSig]
		HRESULT RequestLock([In] TS_LF dwLockFlags, out HRESULT phrSession);

		/// <summary>
		/// The <c>ITextStoreAnchor::GetStatus</c> method obtains the document status. The document status is returned through the
		/// TS_STATUS structure.
		/// </summary>
		/// <param name="pdcs">Receives the TS_STATUS structure that contains the document status. Cannot be <c>NULL</c>.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The pointer to the TS_STATUS parameter is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreanchor-getstatus HRESULT GetStatus(
		// TS_STATUS *pdcs );
		[PreserveSig]
		HRESULT GetStatus(out TS_STATUS pdcs);

		/// <summary>
		/// The <c>ITextStoreAnchor::QueryInsert</c> method determines whether the specified start and end anchors are valid. Use this
		/// method to adjust an edit to a document before you execute the edit. The method must not return values outside the range of
		/// the document.
		/// </summary>
		/// <param name="paTestStart">Receives a pointer to a start anchor for the inserted text.</param>
		/// <param name="paTestEnd">
		/// Receives a pointer to an end anchor for the inserted text. This is the same as paTestStart if the text is inserted at a
		/// point instead of replacing selected text.
		/// </param>
		/// <param name="cch">Length of replacement text.</param>
		/// <param name="ppaResultStart">
		/// Pointer to the new anchor object at the starting location for the inserted text. If the value of this parameter is
		/// <c>NULL</c>, then text cannot be inserted at the specified position. This anchor cannot be outside the document.
		/// </param>
		/// <param name="ppaResultEnd">
		/// Pointer to the new anchor object at the ending location for the inserted text. If the value of this parameter is
		/// <c>NULL</c>, then text cannot be inserted at the specified position. This anchor cannot be outside the document.
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>An unspecified error occurred.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The paTestStart or paTestEnd parameters are invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>The attempt to instantiate the ppaResultStart and/or ppaResultEnd anchors failed.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// The values of ppaResultStart and ppaResultEnd depend upon how the application inserts text into the document. If
		/// ppaResultStart and ppaResultEnd are the same as paTestStart, the cursor is at the beginning of the inserted text after
		/// insertion. If ppaResultStart and ppaResultEnd are the same as paTextEnd, the cursor is at the end of the inserted text after insertion.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreanchor-queryinsert HRESULT QueryInsert(
		// IAnchor *paTestStart, IAnchor *paTestEnd, ULONG cch, IAnchor **ppaResultStart, IAnchor **ppaResultEnd );
		[PreserveSig]
		HRESULT QueryInsert([In] IAnchor paTestStart, [In] IAnchor paTestEnd, uint cch, out IAnchor ppaResultStart, out IAnchor ppaResultEnd);

		/// <summary>
		/// The <c>ITextStoreAnchor::GetSelection</c> method returns the offset of a text selection in a text stream. This method
		/// supports multiple text selections. The caller must have a read-only lock on the document before calling this method.
		/// </summary>
		/// <param name="ulIndex">
		/// Specifies the text selections that start the process. If the TF_DEFAULT_SELECTION constant is specified for this parameter,
		/// the input selection starts the process, and only a single selection (the one appropriate for input operations) will be returned.
		/// </param>
		/// <param name="ulCount">Specifies the maximum number of selections to return.</param>
		/// <param name="pSelection">
		/// Receives the style, start, and end character positions of the selected text. These values are put into the
		/// TS_SELECTION_ANCHOR structure.
		/// </param>
		/// <param name="pcFetched">Receives the number of pSelection structures returned.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>The method was unable to load the start or end anchor into the TS_SELECTION_ANCHOR structure.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>The method was unable to allocate memory for the selection.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_NOLOCK</term>
		/// <term>The caller does not have a read-only lock on the document.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_NOSELECTION</term>
		/// <term>The document has no selection.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreanchor-getselection HRESULT GetSelection(
		// ULONG ulIndex, ULONG ulCount, TS_SELECTION_ANCHOR *pSelection, ULONG *pcFetched );
		[PreserveSig]
		HRESULT GetSelection(uint ulIndex, uint ulCount, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] TS_SELECTION_ANCHOR[] pSelection, [NullAllowed] out uint pcFetched);

		/// <summary>Selects text within the document.</summary>
		/// <param name="ulCount">Specifies the number of text selections in pSelection.</param>
		/// <param name="pSelection">
		/// <para>
		/// Specifies the style, start, and end character positions of the text selected through the TS_SELECTION_ANCHOR structure. The
		/// start anchor member <c>paStart</c> of the structure must never follow the end anchor member <c>paEnd</c>, although they
		/// might be at the same location.
		/// </para>
		/// <para>
		/// When <c>paStart</c> = <c>paEnd</c>, the method places a caret at the anchor location. There can be only one caret at a time
		/// in the text stream.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>An unspecified error occurred.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>The method was unable to allocate sufficient memory to complete the operation.</term>
		/// </item>
		/// <item>
		/// <term>TF_E_INVALIDPOS</term>
		/// <term>The anchor locations specified are beyond the text in the document.</term>
		/// </item>
		/// <item>
		/// <term>TF_E_NOLOCK</term>
		/// <term>The caller does not have a read/write lock.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreanchor-setselection HRESULT SetSelection(
		// ULONG ulCount, const TS_SELECTION_ANCHOR *pSelection );
		[PreserveSig]
		HRESULT SetSelection(uint ulCount, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] TS_SELECTION_ANCHOR[] pSelection);

		/// <summary>
		/// The <c>ITextStoreAnchor::GetText</c> method returns information about text at a specified anchor position. This method
		/// returns the visible and hidden text and indicates if embedded data is attached to the text.
		/// </summary>
		/// <param name="dwFlags">Not used; should be zero.</param>
		/// <param name="paStart">Specifies the starting anchor position.</param>
		/// <param name="paEnd">
		/// Specifies the ending anchor position. If <c>NULL</c>, it is treated as if it were an anchor positioned at the very end of
		/// the text stream.
		/// </param>
		/// <param name="pchText">Specifies the buffer to receive the text. May be <c>NULL</c> only when cchReq = 0.</param>
		/// <param name="cchReq">Specifies the pchText buffer size in characters.</param>
		/// <param name="pcch">Receives the number of characters copied into the pchText buffer.</param>
		/// <param name="fUpdateAnchor">If <c>TRUE</c>, paStart will be repositioned just past the last character copied to pchText.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method completed successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>The method was unable to obtain a valid interface pointer to paStart and/or paEnd.</term>
		/// </item>
		/// <item>
		/// <term>TF_E_INVALIDPOS</term>
		/// <term>The paStart or paEnd anchors are outside of the document text.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_NOLOCK</term>
		/// <term>The caller does not have a read-only lock on the document.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Callers that use this method must have a read-only lock on the document by calling the ITextStoreAnchor::RequestLock method.
		/// Without a read-only lock, the method fails and returns TF_E_NOLOCK.
		/// </para>
		/// <para>Applications can truncate the method return values for internal reasons.</para>
		/// <para>To quickly scan text with multiple <c>GetText</c> calls, a caller would use fUpdateAnchor = <c>TRUE</c>.</para>
		/// <para>
		/// The actual number of characters copied could be less than cchReq if the number of characters between paStart and paEnd is
		/// less than cchReq.
		/// </para>
		/// <para>The behavior of <c>GetText</c> is not affected by any region boundaries covered by the returned text.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreanchor-gettext HRESULT GetText( DWORD
		// dwFlags, IAnchor *paStart, IAnchor *paEnd, WCHAR *pchText, ULONG cchReq, ULONG *pcch, BOOL fUpdateAnchor );
		[PreserveSig]
		HRESULT GetText(uint dwFlags, [In] IAnchor paStart, [In] IAnchor paEnd, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pchText, uint cchReq, out uint pcch,
			[In, MarshalAs(UnmanagedType.Bool)] bool fUpdateAnchor);

		/// <summary>The <c>ITextStoreAnchor::SetText</c> method sets the text selection between two supplied anchor locations.</summary>
		/// <param name="dwFlags">
		/// If set to the value of TS_ST_CORRECTION, the text is a transform (correction) of existing content, and any special text
		/// markup information (metadata) is retained, such as .wav file data or a language identifier. The client defines the type of
		/// markup information to be retained.
		/// </param>
		/// <param name="paStart">Pointer to the anchor at the start of the range of text to replace.</param>
		/// <param name="paEnd">
		/// Pointer to the anchor at the end of the range of text to replace. Must always follow or be at the same position as paStart.
		/// </param>
		/// <param name="pchText">
		/// Pointer to the replacement text. The text string does not have to be <c>NULL</c> terminated, because the text character
		/// count is specified in the cch parameter.
		/// </param>
		/// <param name="cch">Specifies the number of characters in the replacement text.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>The method could not instantiate one of the anchors paStart or paEnd.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_INVALIDPOS</term>
		/// <term>The location of paStart or paEnd is outside of the document text.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_NOLOCK</term>
		/// <term>The caller does not have a read/write lock.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_READONLY</term>
		/// <term>The document is read-only. Content cannot be modified.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_REGION</term>
		/// <term>An attempt was made to modify text across a region boundary.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Applications should start a composition by first using ITextStoreAnchor::InsertTextAtSelection.
		/// <c>ITextStoreAnchor::SetText</c> should be used only within an existing composition. If there is no active composition at
		/// the time <c>SetText</c> is called, the TSF manager creates a composition that lasts just long enough to wrap the call to <c>SetText</c>.
		/// </para>
		/// <para>
		/// Callers must hold a write lock obtained through ITextStoreAnchor::RequestLock. Otherwise, <c>ITextStoreAnchor::SetText</c>
		/// will fail with TS_E_NOLOCK.
		/// </para>
		/// <para>If paStart is at the same location as paEnd, then the operation is an insertion, and no existing text will be removed.</para>
		/// <para>TS_CHAR_EMBEDDED cannot be passed into this method. For embedded objects, use ITextStoreAnchor::InsertEmbedded instead.</para>
		/// <para>
		/// This method will fail if the range of text replaced covers any region boundary. Instead, callers should make multiple calls
		/// to the method, one for each region.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreanchor-settext HRESULT SetText( DWORD
		// dwFlags, IAnchor *paStart, IAnchor *paEnd, const WCHAR *pchText, ULONG cch );
		[PreserveSig]
		HRESULT SetText([In] TS_ST dwFlags, [In] IAnchor paStart, [In] IAnchor paEnd, [In, MarshalAs(UnmanagedType.LPWStr)] string pchText, uint cch);

		/// <summary>The <c>ITextStoreAnchor::GetFormattedText</c> method returns formatted text information from a text stream.</summary>
		/// <param name="paStart">Anchor position at which to start retrieval of formatted text.</param>
		/// <param name="paEnd">Anchor position at which to end retrieval of formatted text.</param>
		/// <param name="ppDataObject">Pointer to the IDataObject object that contains the formatted text.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>The method was unable to obtain a valid interface pointer to the start and/or end anchors.</term>
		/// </item>
		/// <item>
		/// <term>E_NOTIMPL</term>
		/// <term>An application can return this value if the method is not implemented.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_NOLOCK</term>
		/// <term>The caller does not have a read/write lock on the document.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// Text, embedded objects, and any formatting are wrapped into a single <c>IDataObject</c> object. In this way private
		/// appliation-specific formatting associated with text can be preserved by a client.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreanchor-getformattedtext HRESULT
		// GetFormattedText( IAnchor *paStart, IAnchor *paEnd, IDataObject **ppDataObject );
		[PreserveSig]
		HRESULT GetFormattedText([In] IAnchor paStart, [In] IAnchor paEnd, out IDataObject ppDataObject);

		/// <summary>The <c>ITextStoreAnchor::GetEmbedded</c> method obtains an embedded object from a text stream.</summary>
		/// <param name="dwFlags">
		/// Bit fields that specify how the method deals with hidden text. If set to TS_GEA_HIDDEN, an embedded object can be located
		/// within hidden text. Otherwise hidden text is skipped over.
		/// </param>
		/// <param name="paPos">
		/// Pointer to an anchor positioned immediately in front of the embedded object, as denoted by a TS_CHAR_EMBEDDED character.
		/// </param>
		/// <param name="rguidService">
		/// <para>Contains a GUID value that defines the requested format of the obtained object. This can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>GUID_TS_SERVICE_DATAOBJECT</term>
		/// <term>The object should be obtained as an IDataObject data object.</term>
		/// </item>
		/// <item>
		/// <term>GUID_TS_SERVICE_ACCESSIBLE</term>
		/// <term>The object should be obtained as an Accessible object.</term>
		/// </item>
		/// <item>
		/// <term>GUID_TS_SERVICE_ACTIVEX</term>
		/// <term>The object should be obtained as an ActiveX object.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="riid">Specifies the interface type requested.</param>
		/// <param name="ppunk">Pointer to an <c>IUnknown</c> pointer that receives the requested interface.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>The method failed to obtain the requested object.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One or more parameters are invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_NOTIMPL</term>
		/// <term>The implementing application does not expose embedded objects in its text stream.</term>
		/// </item>
		/// <item>
		/// <term>TF_E_INVALIDPOS</term>
		/// <term>The requested paPos anchor is not within the document.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_NOINTERFACE</term>
		/// <term>The requested interface type is unsupported.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_NOLOCK</term>
		/// <term>The caller does not have a read-only lock.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_NOOBJECT</term>
		/// <term>There is no paPos anchor immediately in front of a TS_CHAR_EMBEDDED character.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_NOSERVICE</term>
		/// <term>The service type specified in rguidService is unsupported.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// The caller must use <c>QueryInterface</c> to probe for appropriate interfaces. Prospective interfaces include those
		/// associated with embedded documents or controls such as <c>IOleObject</c>, <c>IDataObject</c>, <c>IViewObject</c>,
		/// <c>IPersistStorage</c>, <c>IOleCache</c>, or <c>IDispatch</c>.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreanchor-getembedded HRESULT GetEmbedded(
		// DWORD dwFlags, IAnchor *paPos, REFGUID rguidService, REFIID riid, IUnknown **ppunk );
		[PreserveSig]
		HRESULT GetEmbedded(TS_GEA dwFlags, [In] IAnchor paPos, in Guid rguidService, in Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object ppunk);

		/// <summary>Inserts an IDataObject data object into a text stream.</summary>
		/// <param name="dwFlags">Must be TS_IE_CORRECTION.</param>
		/// <param name="paStart">Pointer to the anchor at the start of the object to be inserted.</param>
		/// <param name="paEnd">Pointer to the anchor at the end of the object to be inserted.</param>
		/// <param name="pDataObject">Pointer to an <c>IDataObject</c> data object.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>The method was unable to obtain a valid interface pointer to the start and/or end anchors.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One or more input parameters are invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_NOTIMPL</term>
		/// <term>The application does not support embedded objects.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_FORMAT</term>
		/// <term>The application does not support the data type contained in pDataObject.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_INVALIDPOS</term>
		/// <term>paStart and/or paEnd are not within the document.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_NOLOCK</term>
		/// <term>The caller does not have a read/write lock.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreanchor-insertembedded HRESULT
		// InsertEmbedded( DWORD dwFlags, IAnchor *paStart, IAnchor *paEnd, IDataObject *pDataObject );
		[PreserveSig]
		HRESULT InsertEmbedded([In] TS_IE dwFlags, [In] IAnchor paStart, [In] IAnchor paEnd, [In] IDataObject pDataObject);

		/// <summary>Obtains the supported attributes of a text stream.</summary>
		/// <param name="dwFlags">
		/// Specifies whether a subsequent call to the <c>ITextStoreAnchor::RetrieveRequestedAttrs</c> method will contain the supported
		/// attributes. If the TS_ATTR_FIND_WANT_VALUE flag is specified, the default attribute values will be those in the TS_ATTRVAL
		/// structure after the subsequent call to <c>ITextStoreAnchor::RetrieveRequestedAttrs</c>. If any other flag is specified for
		/// this parameter, the method only verifies that the attribute is supported and that the <c>varValue</c> member of the
		/// <c>TS_ATTRVAL</c> structure is set to VT_EMPTY.
		/// </param>
		/// <param name="cFilterAttrs">Specifies the number of supported attributes to obtain.</param>
		/// <param name="paFilterAttrs">
		/// Pointer to the TS_ATTRID data type that specifies the attribute to verify. The method returns only the attributes specified
		/// by <c>TS_ATTRID</c>, even though other attributes might be supported.
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>An unspecified error occurred.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>The method was unable to allocate sufficient memory to complete the operation.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreanchor-requestsupportedattrs HRESULT
		// RequestSupportedAttrs( DWORD dwFlags, ULONG cFilterAttrs, const TS_ATTRID *paFilterAttrs );
		[PreserveSig]
		HRESULT RequestSupportedAttrs(TS_ATTR_FIND dwFlags, uint cFilterAttrs, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] TS_ATTRID[] paFilterAttrs);

		/// <summary>Obtains a list of attributes that begin or end at the specified anchor location.</summary>
		/// <param name="paPos">Pointer to the anchor.</param>
		/// <param name="cFilterAttrs">Specifies the number of attributes to obtain.</param>
		/// <param name="paFilterAttrs">Pointer to the TS_ATTRID data type that specifies the attribute to verify.</param>
		/// <param name="dwFlags">Must be zero.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The paPos anchor is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreanchor-requestattrsatposition HRESULT
		// RequestAttrsAtPosition( IAnchor *paPos, ULONG cFilterAttrs, const TS_ATTRID *paFilterAttrs, DWORD dwFlags );
		[PreserveSig]
		HRESULT RequestAttrsAtPosition([In] IAnchor paPos, uint cFilterAttrs, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] TS_ATTRID[] paFilterAttrs, uint dwFlags = 0);

		/// <summary>Obtains a list of attributes that begin or end at the specified anchor location.</summary>
		/// <param name="paPos">Pointer to the anchor.</param>
		/// <param name="cFilterAttrs">Specifies the number of attributes to obtain.</param>
		/// <param name="paFilterAttrs">Pointer to the TS_ATTRID data type that specifies the attribute to verify.</param>
		/// <param name="dwFlags">
		/// <para>
		/// Specifies attributes for the call to the ITextStoreAnchor::RetrieveRequestedAttrs method. If this parameter is not set, the
		/// method returns the attributes that start at the specified anchor location. Other possible values for this parameter are the following.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TS_ATTR_FIND_WANT_END</term>
		/// <term>Obtains the attributes that end at the specified anchor location.</term>
		/// </item>
		/// <item>
		/// <term>TS_ATTR_FIND_WANT_VALUE</term>
		/// <term>
		/// Obtains the value of the attribute in addition to the attribute. The attribute value is put into the varValue member of the
		/// TS_ATTRVAL structure during the ITextStoreAnchor::RetrieveRequestedAttrs method call.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>paPos is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// In the sentence, "This is italic text.", the italic attribute starts before the word italic and ends after the word text.
		/// </para>
		/// <para>
		/// If the flag TS_ATTR_FIND_WANT_END is set in dwFlags, the method would return the italic attribute for the text "italic
		/// &lt;anchor&gt;normal", because there is an end transition at the anchor location.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreanchor-requestattrstransitioningatposition
		// HRESULT RequestAttrsTransitioningAtPosition( IAnchor *paPos, ULONG cFilterAttrs, const TS_ATTRID *paFilterAttrs, DWORD
		// dwFlags );
		[PreserveSig]
		HRESULT RequestAttrsTransitioningAtPosition([In] IAnchor paPos, uint cFilterAttrs, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] TS_ATTRID[] paFilterAttrs, [In] TS_ATTR_FIND dwFlags);

		/// <summary>
		/// The <c>ITextStoreAnchor::FindNextAttrTransition</c> method finds the location in the text stream where a transition occurs
		/// in an attribute value. The specified attribute to check is application-dependent.
		/// </summary>
		/// <param name="paStart">Pointer to the anchor position at the start of a range to search for an attribute transition.</param>
		/// <param name="paHalt">Pointer to the anchor position at the end of a range to search for an attribute transition.</param>
		/// <param name="cFilterAttrs">Specifies the number of attributes to check.</param>
		/// <param name="paFilterAttrs">
		/// Pointer to the TS_ATTRID data type that specifies the attribute to check. Pre-defined attributes are given in tsattrs.h.
		/// </param>
		/// <param name="dwFlags">
		/// <para>Specifies the direction to search for an attribute transition. By default, the method searches forward.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TS_ATTR_FIND_BACKWARDS</term>
		/// <term>The method searches backward in the text stream.</term>
		/// </item>
		/// <item>
		/// <term>TS_ATTR_FIND_UPDATESTART</term>
		/// <term>
		/// The method positions the input anchor paStart at the next attribute transition, if one is found. Otherwise the input anchor
		/// is not modified.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TS_ATTR_FIND_WANT_OFFSET</term>
		/// <term>The plFoundOffset parameter receives the character offset of the attribute transition from paStart.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pfFound">
		/// Receives a Boolean value of <c>TRUE</c> if an attribute transition was found, otherwise <c>FALSE</c> is returned.
		/// </param>
		/// <param name="plFoundOffset">Receives the character offset of the attribute transition from the start anchor paStart.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>paStart and/or paHalt are invalid.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_INVALIDPOS</term>
		/// <term>The character positions specified are beyond the text in the document.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreanchor-findnextattrtransition HRESULT
		// FindNextAttrTransition( IAnchor *paStart, IAnchor *paHalt, ULONG cFilterAttrs, const TS_ATTRID *paFilterAttrs, DWORD dwFlags,
		// BOOL *pfFound, LONG *plFoundOffset );
		[PreserveSig]
		HRESULT FindNextAttrTransition([In] IAnchor paStart, [In] IAnchor paHalt, uint cFilterAttrs, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] TS_ATTRID[] paFilterAttrs,
			TS_ATTR_FIND dwFlags, [Out, MarshalAs(UnmanagedType.Bool)] out bool pfFound, out int plFoundOffset);

		/// <summary>
		/// Returns the attributes obtained by the RequestAttrsAtPosition, RequestAttrsTransitioningAtPosition, or RequestSupportedAttrs methods.
		/// </summary>
		/// <param name="ulCount">Specifies the number of supported attributes to obtain.</param>
		/// <param name="paAttrVals">
		/// Pointer to the TS_ATTRVAL structure that receives the supported attributes. The members of this structure depend upon the
		/// dwFlags parameter of the calling method.
		/// </param>
		/// <param name="pcFetched">Receives the number of supported attributes.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreanchor-retrieverequestedattrs HRESULT
		// RetrieveRequestedAttrs( ULONG ulCount, TS_ATTRVAL *paAttrVals, ULONG *pcFetched );
		[PreserveSig]
		HRESULT RetrieveRequestedAttrs(uint ulCount, [Out] TS_ATTRVAL[] paAttrVals, [NullAllowed] out uint pcFetched);

		/// <summary>The <c>ITextStoreAnchor::GetStart</c> method returns an anchor positioned at the start of the text stream.</summary>
		/// <param name="ppaStart">Pointer to an anchor object located at the start of the text stream.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>ppaStart is invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>The attempt to instantiate an anchor at the start of the text stream failed.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreanchor-getstart HRESULT GetStart( IAnchor
		// **ppaStart );
		[PreserveSig]
		HRESULT GetStart(out IAnchor ppaStart);

		/// <summary>The <c>ITextStoreAnchor::GetEnd</c> method returns an anchor positioned at the end of the text stream.</summary>
		/// <param name="ppaEnd">Pointer to an anchor object located at the very end of the text stream.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>ppaEnd is invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_NOTIMPL</term>
		/// <term>
		/// The application has not implemented this method. This is usually an indication that calculating the end position requires
		/// excessive resources. If the end position is necessary, you can use ITextStoreAnchor::GetText to calculate it, though this
		/// might also be a memory-intensive operation, paging in arbitrarily large amounts of memory from disk.
		/// </term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>The attempt to instantiate an anchor at the end of the document failed.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_NOLOCK</term>
		/// <term>The caller does not have a read-only lock.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreanchor-getend HRESULT GetEnd( IAnchor
		// **ppaEnd );
		[PreserveSig]
		HRESULT GetEnd(out IAnchor ppaEnd);

		/// <summary>
		/// The <c>ITextStoreAnchor::GetActiveView</c> method returns a TsViewCookie data type that specifies the current active view.
		/// TSF supports only a single active view, so a given text store should always return the same <c>TsViewCookie</c> data type.
		/// </summary>
		/// <param name="pvcView">Receives the <c>TsViewCookie</c> data type that specifies the current active view.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>pvcView is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreanchor-getactiveview HRESULT GetActiveView(
		// TsViewCookie *pvcView );
		[PreserveSig]
		HRESULT GetActiveView(out TsViewCookie pvcView);

		/// <summary>
		/// The <c>ITextStoreAnchor::GetAnchorFromPoint</c> method converts a point in screen coordinates to an anchor positioned at a
		/// corresponding location.
		/// </summary>
		/// <param name="vcView">Specifies the context view.</param>
		/// <param name="ptScreen">Pointer to the <c>POINT</c> structure with the screen coordinates of the point.</param>
		/// <param name="dwFlags">
		/// <para>
		/// Specifies the anchor position to return based upon the screen coordinates of the point relative to a character bounding box.
		/// By default, the anchor position returned is the character bounding box containing the screen coordinates of the point. If
		/// the point is outside a character bounding box, the method returns <c>NULL</c> or TF_E_INVALIDPOINT. Other bit flags for this
		/// parameter are as follows.
		/// </para>
		/// <para>The bit flags can be combined.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>GXFPF_ROUND_NEAREST</term>
		/// <term>
		/// If the screen coordinates of the point are contained in a character bounding box, an anchor is returned at the bounding edge
		/// closest to the screen coordinates of the point.
		/// </term>
		/// </item>
		/// <item>
		/// <term>GXFPF_NEAREST</term>
		/// <term>
		/// If the screen coordinates of the point are not contained in a character bounding box, an anchor at the closest character
		/// position is returned.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="ppaSite">Pointer to an anchor object at a location corresponding to the screen coordinates ptScreen.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>The method failed.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One or more input parameters is invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>The attempt to instantiate an anchor at the specified location failed.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_INVALIDPOINT</term>
		/// <term>The ptScreen parameter is not within the bounding box of any character.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_NOLAYOUT</term>
		/// <term>The application has not calculated a text layout yet.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The point 1 screen coordinates cause the offset (character position) of anchor ppaSite to be 0 by default or if the dwFlags
		/// parameter is set to GXFPF_NEAREST because the point 1 screen coordinates are inside the character bounding box of character
		/// position 0. If the dwFlags parameter is set to GXFPF_ROUND_NEAREST for point 1, the anchor offset is 1 because the point 1
		/// screen coordinates are closest to range position 1. Range position 1 is the starting range position of character position 1.
		/// </para>
		/// <para>
		/// For the point 2 screen coordinates, the method returns <c>TF_E_INVALIDPOINT</c> by default or if the dwFlags parameter is
		/// set to <c>GXFPF_NEAREST</c> because the point 2 screen coordinates are outside a character bounding box. If the dwFlags
		/// parameter is set to <c>GXFPF_ROUND_NEAREST</c>, then the point 2 screen coordinates causes the anchor offset to be 1,
		/// because the closest character position to the point 2 screen coordinates is character position 1.
		/// </para>
		/// <para><c>Point 1</c></para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// Default-- anchor offset = 0 --The screen coordinates point is inside the character bounding box of Character Position 0.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// <c>GXFPF_ROUND_NEAREST</c> -- anchor offset = 1 --The screen coordinates of the point is closest to Range Position 1 which
		/// is the starting range position of Character Position 1.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// <c>GXFPF_NEAREST</c> -- anchor offset = 0 --The default behavior occurs because the point is within the character bounding
		/// box of Character Position 0.
		/// </term>
		/// </item>
		/// </list>
		/// <para><c>Point 2</c></para>
		/// <list type="bullet">
		/// <item>
		/// <term>Default-- hr = TF_E_INVALIDPOINT --The screen coordinates of the point are outside a character bounding box.</term>
		/// </item>
		/// <item>
		/// <term>
		/// GXPF_ROUND_NEAREST-- hr = TF_E_INVALIDPOINT --The default behavior occurs because the screen coordinates of the point is
		/// outside a character bounding box.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// GXPF_NEAREST-- anchor offset = 1 --The closest character position to the screen coordinates of the point is Character
		/// Position 1.
		/// </term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreanchor-getanchorfrompoint HRESULT
		// GetAnchorFromPoint( TsViewCookie vcView, const POINT *ptScreen, DWORD dwFlags, IAnchor **ppaSite );
		[PreserveSig]
		HRESULT GetAnchorFromPoint([In] TsViewCookie vcView, in POINT ptScreen, GXFPF dwFlags, out IAnchor ppaSite);

		/// <summary>
		/// The <c>ITextStoreAnchor::GetTextExt</c> method returns the bounding box, in screen coordinates, of a range of text. The
		/// caller must have a read-only lock on the document before calling this method.
		/// </summary>
		/// <param name="vcView">Specifies the context view.</param>
		/// <param name="paStart">Specifies the anchor positioned at the start of the range.</param>
		/// <param name="paEnd">Specifies the anchor positioned at the end of the range.</param>
		/// <param name="prc">Receives the bounding box of the text range in screen coordinates.</param>
		/// <param name="pfClipped">
		/// Receives a Boolean value that specifies if the text in the bounding box has been clipped. If <c>TRUE</c>, the bounding box
		/// contains clipped text and does not include the entire requested text range. The bounding box is clipped because the
		/// requested range is not visible.
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>The method was unable to obtain a valid interface pointer to the start and/or end anchors.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_INVALIDARG</term>
		/// <term>One or more of the input parameters is invalid.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_INVALIDPOS</term>
		/// <term>The range specified by the paStart and paEnd parameters extends past the beginning or end of the document.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_NOLAYOUT</term>
		/// <term>The application has not calculated a text layout. Any further calls will not succeed until the application calls ITextStoreAnchorSink::OnLayoutChange.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_NOLOCK</term>
		/// <term>The caller does not have a read-only lock on the document.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// If the document window is minimized, or if the specified text is not currently visible, the method returns S_OK with the prc
		/// parameter set to {0,0,0,0}.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreanchor-gettextext HRESULT GetTextExt(
		// TsViewCookie vcView, IAnchor *paStart, IAnchor *paEnd, RECT *prc, BOOL *pfClipped );
		[PreserveSig]
		HRESULT GetTextExt([In] TsViewCookie vcView, [In] IAnchor paStart, [In] IAnchor paEnd, out RECT prc, [Out, MarshalAs(UnmanagedType.Bool)] out bool pfClipped);

		/// <summary>
		/// The <c>ITextStoreAnchor::GetScreenExt</c> method returns the bounding box screen coordinates of the display surface where
		/// the text stream is rendered.
		/// </summary>
		/// <param name="vcView">Specifies the context view.</param>
		/// <param name="prc">Receives the bounding box screen coordinates of the display surface of the document.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The specified vcView parameter is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// If the text is not currently displayed, for example, if the document window is minimized, the prc parameter is set to { 0,
		/// 0, 0, 0 }.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreanchor-getscreenext HRESULT GetScreenExt(
		// TsViewCookie vcView, RECT *prc );
		[PreserveSig]
		HRESULT GetScreenExt([In] TsViewCookie vcView, out RECT prc);

		/// <summary>
		/// The <c>ITextStoreAnchor::GetWnd</c> method returns the handle to a window that corresponds to the current text stream.
		/// </summary>
		/// <param name="vcView">Specifies the TsViewCookie data type that corresponds to the current document.</param>
		/// <param name="phwnd">
		/// Receives a pointer to the handle of the window that corresponds to the current document. This parameter can be <c>NULL</c>
		/// if the document does not have the corresponding handle to the window.
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The TsViewCookie data type is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// A document might not have a corresponding window handle if the document is in memory but not displayed on the screen, or if
		/// the document is a windowless control and the control does not recognize the window handle of the owner of the windowless
		/// controls. Callers cannot assume that the phwnd parameter will receive a non- <c>NULL</c> value even if the method is
		/// successful. Callers can also receive a <c>NULL</c> value for the phwnd parameter.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreanchor-getwnd HRESULT GetWnd( TsViewCookie
		// vcView, HWND *phwnd );
		[PreserveSig]
		HRESULT GetWnd([In] TsViewCookie vcView, out HWND phwnd);

		/// <summary>
		/// Determines whether the document can accept an embedded object through the InsertEmbedded or InsertEmbeddedAtSelection methods.
		/// </summary>
		/// <param name="pguidService">Pointer to the object type. If <c>NULL</c>, pFormatEtc should be used.</param>
		/// <param name="pFormatEtc">
		/// Pointer to the FORMATETC structure that contains format data of the object. This parameter cannot be <c>NULL</c> if the
		/// pguidService parameter is <c>NULL</c>.
		/// </param>
		/// <param name="pfInsertable">
		/// Receives <c>TRUE</c> if the object type can be inserted into the document or <c>FALSE</c> if the object type cannot be
		/// inserted into the document.
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The pFormatEtc parameter is NULL.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>The clipboard formats supported by the document are dependent on the application.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreanchor-queryinsertembedded HRESULT
		// QueryInsertEmbedded( const GUID *pguidService, const FORMATETC *pFormatEtc, BOOL *pfInsertable );
		[PreserveSig]
		HRESULT QueryInsertEmbedded([In, Optional] GuidPtr pguidService, [In, Optional] IntPtr pFormatEtc, [Out, MarshalAs(UnmanagedType.Bool)] out bool pfInsertable);

		/// <summary>Inserts text at the insertion point or selection.</summary>
		/// <param name="dwFlags">
		/// <para>Specifies whether the paStart and paEnd parameters will contain the results of the text insertion.</para>
		/// <para>The TF_IAS_NOQUERY and TF_IAS_QUERYONLY flags cannot be combined.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TF_IAS_NOQUERY</term>
		/// <term>
		/// Text is inserted, and the values of the ppaStart and ppaEnd parameters can be NULL. Use this flag if the results of the text
		/// insertion are not required.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TF_IAS_QUERYONLY</term>
		/// <term>
		/// Text is not inserted, and the ppaStart and ppaEnd anchors contain the results of the text insertion. The values of these
		/// parameters depend on how the application implements text insertion into a document. Use this flag to view the results of the
		/// text insertion without actually inserting the text. Zero-length text can be inserted.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pchText">Pointer to the string to insert in the document. The string can be <c>NULL</c> terminated.</param>
		/// <param name="cch">Specifies the text length.</param>
		/// <param name="ppaStart">Pointer to the anchor object at the start of the text insertion.</param>
		/// <param name="ppaEnd">
		/// Pointer to the anchor object at the end of the text insertion. For an insertion point, this parameter value will be the same
		/// as the value of the ppaStart parameter.
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>The method could not instantiate one of the anchors paStart or paEnd.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The pchText parameter is invalid.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_NOLOCK</term>
		/// <term>The caller does not have a lock on the document.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreanchor-inserttextatselection HRESULT
		// InsertTextAtSelection( DWORD dwFlags, const WCHAR *pchText, ULONG cch, IAnchor **ppaStart, IAnchor **ppaEnd );
		[PreserveSig]
		HRESULT InsertTextAtSelection([In] TF_IAS dwFlags, [In, MarshalAs(UnmanagedType.LPWStr)] string pchText, uint cch, out IAnchor ppaStart, out IAnchor ppaEnd);

		/// <summary>
		/// The <c>ITextStoreAnchor::InsertEmbeddedAtSelection</c> method inserts an IDataObject object at the insertion point or
		/// selection. The client that calls this method must have a read/write lock before inserting an <c>IDataObject</c> into the
		/// text stream.
		/// </summary>
		/// <param name="dwFlags">
		/// <para>Specifies whether the paStart and paEnd parameters will contain the results of the object insertion.</para>
		/// <para>The TF_IAS_NOQUERY and TF_IAS_QUERYONLY flags cannot be combined.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TF_IAS_NOQUERY</term>
		/// <term>
		/// Text is inserted, and the values of the ppaStart and ppaEnd parameters can be NULL. Use this flag if the results of the text
		/// insertion are not required.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TF_IAS_QUERYONLY</term>
		/// <term>
		/// Text is not inserted, and the ppaStart and ppaEnd anchors contain the results of the text insertion. The values of these
		/// parameters depend on how the application implements text insertion into a document. Use this flag to view the results of the
		/// text insertion without actually inserting the text, for example, to predict the results of collapsing or otherwise adjusting
		/// a selection.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pDataObject">Pointer to the <c>IDataObject</c> object to be inserted.</param>
		/// <param name="ppaStart">Pointer to the anchor object at the start of the object insertion.</param>
		/// <param name="ppaEnd">
		/// Pointer to the anchor object at the end of the object insertion. For an insertion point, this parameter value will be the
		/// same as the value of the ppaStart parameter.
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>The method could not instantiate one of the anchors paStart or paEnd.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The pchText parameter is invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>The method could not instantiate one of the anchors paStart or paEnd.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_NOLOCK</term>
		/// <term>The caller does not have a lock on the document.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// Clients must use this method to insert an object into a text stream, since a TS_CHAR_EMBEDDED constant cannot be passed into ITextStoreAnchor::SetText.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreanchor-insertembeddedatselection HRESULT
		// InsertEmbeddedAtSelection( DWORD dwFlags, IDataObject *pDataObject, IAnchor **ppaStart, IAnchor **ppaEnd );
		[PreserveSig]
		HRESULT InsertEmbeddedAtSelection([In] TF_IAS dwFlags, [In] IDataObject pDataObject, out IAnchor ppaStart, out IAnchor ppaEnd);
	}

	/// <summary>Undocumented.</summary>
	[PInvokeData("textstor.h")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("A2DE3BC1-3D8E-11d3-81A9-F753FBE61A00")]
	public interface ITextStoreAnchorEx
	{
		/// <summary>Scrolls to rect.</summary>
		/// <param name="pStart">The p start.</param>
		/// <param name="pEnd">The p end.</param>
		/// <param name="rc">The rc.</param>
		/// <param name="dwPosition">The dw position.</param>
		/// <returns></returns>
		[PreserveSig]
		HRESULT ScrollToRect([In] IAnchor pStart, [In] IAnchor pEnd, in RECT rc, uint dwPosition);
	}

	/// <summary>
	/// <para>
	/// The <c>ITextStoreAnchorSink</c> interface is implemented by the TSF manager and is used by an anchor-based application to notify
	/// the manager when certain events occur. The manager installs this advise sink by calling ITextStoreAnchor::AdviseSink.
	/// </para>
	/// <para>The interface ID is IID_ITextStoreAnchorSink.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nn-textstor-itextstoreanchorsink
	[PInvokeData("textstor.h", MSDNShortId = "NN:textstor.ITextStoreAnchorSink")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("AA80E905-2021-11D2-93E0-0060B067B86E")]
	public interface ITextStoreAnchorSink
	{
		/// <summary>Called when text in the text stream changes.</summary>
		/// <param name="dwFlags">
		/// <para>
		/// Contains a set of flags that specify additional information about the text change. This can be one or more of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>The text has changed.</term>
		/// </item>
		/// <item>
		/// <term>TS_TC_CORRECTION</term>
		/// <term>
		/// The text is a transform (correction) of existing content, and any special text markup information (metadata) is retained,
		/// such as .wav file data or a language identifier. This flag is used for applications that need to preserve data associated
		/// with the original text.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="paStart">Pointer to an anchor located at the start of the changed text.</param>
		/// <param name="paEnd">Pointer to an anchor located at the end of the changed text.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>The method was unable to create cloned anchors to contain the change.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>paStart or paEnd is invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>A memory allocation failure occurred.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_NOLOCK</term>
		/// <term>
		/// The TSF manager holds a lock on the document. This typically indicates that the method was called from within another
		/// ITextStoreAnchor method, such as ITextStoreAnchor::SetText.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method is called only when the application modifies its own text, not when a client modifies text with one of the
		/// <c>ITextStoreAnchor</c> methods, such as <c>ITextStoreAnchor::SetText</c> or ITextStoreAnchor::InsertTextAtSelection.
		/// </para>
		/// <para>When calling this method, the application must be able to grant a document lock.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreanchorsink-ontextchange HRESULT
		// OnTextChange( DWORD dwFlags, IAnchor *paStart, IAnchor *paEnd );
		[PreserveSig]
		HRESULT OnTextChange([In] TS_TC dwFlags, [In] IAnchor paStart, [In] IAnchor paEnd);

		/// <summary>
		/// The <c>ITextStoreAnchorSink::OnSelectionChange</c> method is called when the selection within the text stream changes. This
		/// method should be called whenever the return value of a potential call to ITextStoreAnchor::GetSelection has changed.
		/// </summary>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_NOLOCK</term>
		/// <term>The manager holds a lock on the document.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method only needs to be called when the application modifies the selection itself, not when a client modifies the
		/// selection with ITextStoreAnchor::SetSelection, ITextStoreAnchor::InsertTextAtSelection, or other ITextStoreAnchor methods.
		/// </para>
		/// <para>When calling this method, the application must be able to grant a document lock.</para>
		/// <para>
		/// Applications should expect reentrant client calls to ITextStoreAnchor::RequestLock from within this method. An application
		/// can grant the lock request synchronously, or, because several changes have been cached, it can grant the lock asynchronously.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreanchorsink-onselectionchange HRESULT OnSelectionChange();
		[PreserveSig]
		HRESULT OnSelectionChange();

		/// <summary>
		/// The <c>ITextStoreAnchorSink::OnLayoutChange</c> method is called when the layout (on-screen representation) of the document changes.
		/// </summary>
		/// <param name="lcode">Contains a TsLayoutCode value that defines the type of change.</param>
		/// <param name="vcView">Contains an application-defined cookie that identifies the document. For more information, see ITextStoreAnchor::GetActiveView.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A layout change can be in response to a change to the text, font size, window movement, window resizing, or other change
		/// that affects the displayed text.
		/// </para>
		/// <para>
		/// If a call to ITextStoreAnchor::GetTextExt or ITextStoreAnchor::GetAnchorFromPoint returns TS_E_NOLAYOUT because the
		/// application has not calculated the layout, the application must call <c>ITextStoreAnchorSink::OnLayoutChange</c> when the
		/// layout is available.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreanchorsink-onlayoutchange HRESULT
		// OnLayoutChange( TsLayoutCode lcode, TsViewCookie vcView );
		[PreserveSig]
		HRESULT OnLayoutChange([In] TsLayoutCode lcode, [In] TsViewCookie vcView);

		/// <summary>Called when the text stream status changes.</summary>
		/// <param name="dwFlags">
		/// Contains a value that specifies the new status. For more information about possible values, see the <c>dwDynamicFlags</c>
		/// member of the TS_STATUS structure.
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// Applications should call this method whenever ITextStoreAnchor::GetStatus returns a new value for any of the
		/// <c>dwDynamicFlags</c> member of <c>TS_STATUS</c> .
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreanchorsink-onstatuschange HRESULT
		// OnStatusChange( DWORD dwFlags );
		[PreserveSig]
		HRESULT OnStatusChange(TS_SD dwFlags);

		/// <summary>
		/// The <c>ITextStoreAnchorSink::OnAttrsChange</c> method is called when the value of one or more text attributes changes.
		/// </summary>
		/// <param name="paStart">Pointer to the start anchor of the range of text that has the attribute change.</param>
		/// <param name="paEnd">Pointer to the end anchor of the range of text that has the attribute change.</param>
		/// <param name="cAttrs">Specifies the number of attributes in the paAttrs array.</param>
		/// <param name="paAttrs">Pointer to an array of TS_ATTRID values that identify the attributes changed.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One or more parameters are invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreanchorsink-onattrschange HRESULT
		// OnAttrsChange( IAnchor *paStart, IAnchor *paEnd, ULONG cAttrs, const TS_ATTRID *paAttrs );
		[PreserveSig]
		HRESULT OnAttrsChange([In] IAnchor paStart, [In] IAnchor paEnd, uint cAttrs, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] TS_ATTRID[] paAttrs);

		/// <summary>Called to grant a document lock.</summary>
		/// <param name="dwLockFlags">
		/// <para>
		/// Contains a set of flags that identify the type of lock requested and other lock request data. This can be one of the
		/// following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TS_LF_READ</term>
		/// <term>The lock is read-only.</term>
		/// </item>
		/// <item>
		/// <term>TS_LF_READWRITE</term>
		/// <term>The lock is read/write.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>dwLockFlags is invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_UNEXPECTED</term>
		/// <term>The wrong type of lock was granted.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A document lock is requested by calling ITextStoreAnchor::RequestLock. The application grants the lock request by calling
		/// <c>ITextStoreAnchorSink::OnLockGranted</c> with the requested lock type. The lock is only valid during the
		/// <c>OnLockGranted</c> call. When <c>OnLockGranted</c> returns, the document is considered unlocked.
		/// </para>
		/// <para>The lock type, specified in dwLockFlags, must match the requested lock type in the corresponding call to <c>ITextStoreAnchor::RequestLock</c>.</para>
		/// <para>Calls to <c>ITextStoreAnchor::RequestLock</c> from within <c>OnLockGranted</c> will return an error value.</para>
		/// <para>Applications must not call any of the ITextStoreAnchorSink methods from within the context of <c>OnLockGranted</c>.</para>
		/// <para>
		/// If a synchronous lock request is made from within <c>ITextStoreAnchor::RequestLock</c>, then the caller must also provide
		/// the return value from <c>ITextStoreAnchor::RequestLock</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreanchorsink-onlockgranted HRESULT
		// OnLockGranted( DWORD dwLockFlags );
		[PreserveSig]
		HRESULT OnLockGranted(TS_LF dwLockFlags);

		/// <summary>Called when an edit transaction is started.</summary>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>This method will be called on all installed edit transaction sinks.</para>
		/// <para>
		/// An edit transaction is a group of text changes that should be processed at one time. Calling this method allows a text
		/// service to queue the upcoming changes until ITextStoreAnchorSink::OnEndEditTransaction is called. When
		/// <c>ITextStoreAnchorSink::OnEndEditTransaction</c> is called, the text service will process all queued changes.
		/// </para>
		/// <para>Use of edit transactions is optional.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreanchorsink-onstartedittransaction HRESULT OnStartEditTransaction();
		[PreserveSig]
		HRESULT OnStartEditTransaction();

		/// <summary>Called when an edit transaction is terminated.</summary>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_UNEXPECTED</term>
		/// <term>The reference count of the edit transaction is incorrect.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method causes the ITfEditTransactionSink::OnEndEditTransaction method to be called on all installed edit transaction sinks.
		/// </para>
		/// <para>
		/// An edit transaction is a group of text changes that should be processed at one time. Calling
		/// ITextStoreAnchorSink::OnStartEditTransaction allows a text service to queue the upcoming changes until
		/// <c>ITextStoreAnchorSink::OnEndEditTransaction</c> is called. When <c>ITextStoreAnchorSink::OnEndEditTransaction</c> is
		/// called, the text service will process all of the queued changes.
		/// </para>
		/// <para>Use of edit transactions is optional.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreanchorsink-onendedittransaction HRESULT OnEndEditTransaction();
		[PreserveSig]
		HRESULT OnEndEditTransaction();
	}

	/// <summary>
	/// <para>
	/// The <c>ITextStoreAnchorSink</c> interface is implemented by the TSF manager and is used by an anchor-based application to notify
	/// the manager when certain events occur. The manager installs this advise sink by calling ITextStoreAnchor::AdviseSink.
	/// </para>
	/// <para>The interface ID is IID_ITextStoreAnchorSink.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nn-textstor-itextstoreanchorsink
	[PInvokeData("textstor.h", MSDNShortId = "NN:textstor.ITextStoreAnchorSink")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("25642426-028d-4474-977b-111bb114fe3e")]
	public interface ITextStoreAnchorSinkEx : ITextStoreAnchorSink
	{
		/// <summary>Called when text in the text stream changes.</summary>
		/// <param name="dwFlags">
		/// <para>
		/// Contains a set of flags that specify additional information about the text change. This can be one or more of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>The text has changed.</term>
		/// </item>
		/// <item>
		/// <term>TS_TC_CORRECTION</term>
		/// <term>
		/// The text is a transform (correction) of existing content, and any special text markup information (metadata) is retained,
		/// such as .wav file data or a language identifier. This flag is used for applications that need to preserve data associated
		/// with the original text.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="paStart">Pointer to an anchor located at the start of the changed text.</param>
		/// <param name="paEnd">Pointer to an anchor located at the end of the changed text.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>The method was unable to create cloned anchors to contain the change.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>paStart or paEnd is invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>A memory allocation failure occurred.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_NOLOCK</term>
		/// <term>
		/// The TSF manager holds a lock on the document. This typically indicates that the method was called from within another
		/// ITextStoreAnchor method, such as ITextStoreAnchor::SetText.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method is called only when the application modifies its own text, not when a client modifies text with one of the
		/// <c>ITextStoreAnchor</c> methods, such as <c>ITextStoreAnchor::SetText</c> or ITextStoreAnchor::InsertTextAtSelection.
		/// </para>
		/// <para>When calling this method, the application must be able to grant a document lock.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreanchorsink-ontextchange HRESULT
		// OnTextChange( DWORD dwFlags, IAnchor *paStart, IAnchor *paEnd );
		[PreserveSig]
		new HRESULT OnTextChange([In] TS_TC dwFlags, [In] IAnchor paStart, [In] IAnchor paEnd);

		/// <summary>
		/// The <c>ITextStoreAnchorSink::OnSelectionChange</c> method is called when the selection within the text stream changes. This
		/// method should be called whenever the return value of a potential call to ITextStoreAnchor::GetSelection has changed.
		/// </summary>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_NOLOCK</term>
		/// <term>The manager holds a lock on the document.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method only needs to be called when the application modifies the selection itself, not when a client modifies the
		/// selection with ITextStoreAnchor::SetSelection, ITextStoreAnchor::InsertTextAtSelection, or other ITextStoreAnchor methods.
		/// </para>
		/// <para>When calling this method, the application must be able to grant a document lock.</para>
		/// <para>
		/// Applications should expect reentrant client calls to ITextStoreAnchor::RequestLock from within this method. An application
		/// can grant the lock request synchronously, or, because several changes have been cached, it can grant the lock asynchronously.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreanchorsink-onselectionchange HRESULT OnSelectionChange();
		[PreserveSig]
		new HRESULT OnSelectionChange();

		/// <summary>
		/// The <c>ITextStoreAnchorSink::OnLayoutChange</c> method is called when the layout (on-screen representation) of the document changes.
		/// </summary>
		/// <param name="lcode">Contains a TsLayoutCode value that defines the type of change.</param>
		/// <param name="vcView">Contains an application-defined cookie that identifies the document. For more information, see ITextStoreAnchor::GetActiveView.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A layout change can be in response to a change to the text, font size, window movement, window resizing, or other change
		/// that affects the displayed text.
		/// </para>
		/// <para>
		/// If a call to ITextStoreAnchor::GetTextExt or ITextStoreAnchor::GetAnchorFromPoint returns TS_E_NOLAYOUT because the
		/// application has not calculated the layout, the application must call <c>ITextStoreAnchorSink::OnLayoutChange</c> when the
		/// layout is available.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreanchorsink-onlayoutchange HRESULT
		// OnLayoutChange( TsLayoutCode lcode, TsViewCookie vcView );
		[PreserveSig]
		new HRESULT OnLayoutChange([In] TsLayoutCode lcode, [In] TsViewCookie vcView);

		/// <summary>Called when the text stream status changes.</summary>
		/// <param name="dwFlags">
		/// Contains a value that specifies the new status. For more information about possible values, see the <c>dwDynamicFlags</c>
		/// member of the TS_STATUS structure.
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// Applications should call this method whenever ITextStoreAnchor::GetStatus returns a new value for any of the
		/// <c>dwDynamicFlags</c> member of <c>TS_STATUS</c> .
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreanchorsink-onstatuschange HRESULT
		// OnStatusChange( DWORD dwFlags );
		[PreserveSig]
		new HRESULT OnStatusChange(TS_SD dwFlags);

		/// <summary>
		/// The <c>ITextStoreAnchorSink::OnAttrsChange</c> method is called when the value of one or more text attributes changes.
		/// </summary>
		/// <param name="paStart">Pointer to the start anchor of the range of text that has the attribute change.</param>
		/// <param name="paEnd">Pointer to the end anchor of the range of text that has the attribute change.</param>
		/// <param name="cAttrs">Specifies the number of attributes in the paAttrs array.</param>
		/// <param name="paAttrs">Pointer to an array of TS_ATTRID values that identify the attributes changed.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One or more parameters are invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreanchorsink-onattrschange HRESULT
		// OnAttrsChange( IAnchor *paStart, IAnchor *paEnd, ULONG cAttrs, const TS_ATTRID *paAttrs );
		[PreserveSig]
		new HRESULT OnAttrsChange([In] IAnchor paStart, [In] IAnchor paEnd, uint cAttrs, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] TS_ATTRID[] paAttrs);

		/// <summary>Called to grant a document lock.</summary>
		/// <param name="dwLockFlags">
		/// <para>
		/// Contains a set of flags that identify the type of lock requested and other lock request data. This can be one of the
		/// following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TS_LF_READ</term>
		/// <term>The lock is read-only.</term>
		/// </item>
		/// <item>
		/// <term>TS_LF_READWRITE</term>
		/// <term>The lock is read/write.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>dwLockFlags is invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_UNEXPECTED</term>
		/// <term>The wrong type of lock was granted.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A document lock is requested by calling ITextStoreAnchor::RequestLock. The application grants the lock request by calling
		/// <c>ITextStoreAnchorSink::OnLockGranted</c> with the requested lock type. The lock is only valid during the
		/// <c>OnLockGranted</c> call. When <c>OnLockGranted</c> returns, the document is considered unlocked.
		/// </para>
		/// <para>The lock type, specified in dwLockFlags, must match the requested lock type in the corresponding call to <c>ITextStoreAnchor::RequestLock</c>.</para>
		/// <para>Calls to <c>ITextStoreAnchor::RequestLock</c> from within <c>OnLockGranted</c> will return an error value.</para>
		/// <para>Applications must not call any of the ITextStoreAnchorSink methods from within the context of <c>OnLockGranted</c>.</para>
		/// <para>
		/// If a synchronous lock request is made from within <c>ITextStoreAnchor::RequestLock</c>, then the caller must also provide
		/// the return value from <c>ITextStoreAnchor::RequestLock</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreanchorsink-onlockgranted HRESULT
		// OnLockGranted( DWORD dwLockFlags );
		[PreserveSig]
		new HRESULT OnLockGranted(TS_LF dwLockFlags);

		/// <summary>Called when an edit transaction is started.</summary>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>This method will be called on all installed edit transaction sinks.</para>
		/// <para>
		/// An edit transaction is a group of text changes that should be processed at one time. Calling this method allows a text
		/// service to queue the upcoming changes until ITextStoreAnchorSink::OnEndEditTransaction is called. When
		/// <c>ITextStoreAnchorSink::OnEndEditTransaction</c> is called, the text service will process all queued changes.
		/// </para>
		/// <para>Use of edit transactions is optional.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreanchorsink-onstartedittransaction HRESULT OnStartEditTransaction();
		[PreserveSig]
		new HRESULT OnStartEditTransaction();

		/// <summary>Called when an edit transaction is terminated.</summary>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_UNEXPECTED</term>
		/// <term>The reference count of the edit transaction is incorrect.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method causes the ITfEditTransactionSink::OnEndEditTransaction method to be called on all installed edit transaction sinks.
		/// </para>
		/// <para>
		/// An edit transaction is a group of text changes that should be processed at one time. Calling
		/// ITextStoreAnchorSink::OnStartEditTransaction allows a text service to queue the upcoming changes until
		/// <c>ITextStoreAnchorSink::OnEndEditTransaction</c> is called. When <c>ITextStoreAnchorSink::OnEndEditTransaction</c> is
		/// called, the text service will process all of the queued changes.
		/// </para>
		/// <para>Use of edit transactions is optional.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/textstor/nf-textstor-itextstoreanchorsink-onendedittransaction HRESULT OnEndEditTransaction();
		[PreserveSig]
		new HRESULT OnEndEditTransaction();

		/// <summary>Called when disconnected.</summary>
		/// <returns></returns>
		[PreserveSig]
		HRESULT OnDisconnect();
	}

	/// <summary>The <c>TS_ATTRVAL</c> structure contains document attribute values.</summary>
	/// <remarks>
	/// An application uses attributes to expose its data to TSF, whereas text services use properties to expose their data to TSF.
	/// <c>TS_ATTRVAL</c> is used in ITextStoreACP and ITextStoreAnchor methods.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/textstor/ns-textstor-ts_attrval typedef struct TS_ATTRVAL { TS_ATTRID idAttr;
	// DWORD dwOverlapId; VARIANT varValue; } TS_ATTRVAL;
	[PInvokeData("textstor.h", MSDNShortId = "NS:textstor.TS_ATTRVAL")]
	[StructLayout(LayoutKind.Sequential, Pack = 8), Guid("2CC2B33F-1174-4507-B8D9-5BC0EB37C197")]
	public struct TS_ATTRVAL
	{
		/// <summary>GUID for the attribute type.</summary>
		public TS_ATTRID idAttr;

		/// <summary>
		/// A unique identifier of this attribute when overlapped with other attributes. This is a feature in Microsoft Active
		/// Accessibility. In TSF, this parameter value is zero (0). Any nonzero value is ignored.
		/// </summary>
		public uint dwOverlapId;

		/// <summary>Value of the attribute.</summary>
		[MarshalAs(UnmanagedType.Struct)]
		public object varValue;
	}

	/// <summary>The <c>TS_RUNINFO</c> structure specifies the properties of text run data.</summary>
	/// <remarks>
	/// <para>
	/// A text run is a collection of consecutive visible, hidden, or embedded characters. For example, the text, Hello World in HTML
	/// might be &lt;b&gt;Hello &lt;/b&gt;&lt;i&gt;World&lt;/i&gt;. This text is represented in the TS_RUNINFO structure as follows.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Text Run</term>
	/// <term>uCount</term>
	/// <term>TsRunType</term>
	/// </listheader>
	/// <item>
	/// <term>&lt;b&gt;</term>
	/// <term>3</term>
	/// <term>TS_RT_HIDDEN</term>
	/// </item>
	/// <item>
	/// <term>Hello&lt;space&gt;</term>
	/// <term>5</term>
	/// <term>TS_RT_PLAIN</term>
	/// </item>
	/// <item>
	/// <term>&lt;/b&gt;&lt;i&gt;</term>
	/// <term>7</term>
	/// <term>TS_RT_HIDDEN</term>
	/// </item>
	/// <item>
	/// <term>World</term>
	/// <term>5</term>
	/// <term>TS_RT_PLAIN</term>
	/// </item>
	/// <item>
	/// <term>&lt;/i&gt;</term>
	/// <term>4</term>
	/// <term>TS_RT_HIDDEN</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/textstor/ns-textstor-ts_runinfo typedef struct TS_RUNINFO { ULONG uCount;
	// TsRunType type; } TS_RUNINFO;
	[PInvokeData("textstor.h", MSDNShortId = "NS:textstor.TS_RUNINFO")]
	[StructLayout(LayoutKind.Sequential, Pack = 4), Guid("A6231949-37C5-4B74-A24E-2A26C327201D")]
	public struct TS_RUNINFO
	{
		/// <summary>Specifies the number of characters in the text run.</summary>
		public uint uCount;

		/// <summary>
		/// Specifies the text run type. If this parameter is TS_RT_PLAIN, the text run is visible. If this parameter is TS_RT_HIDDEN,
		/// the text run is hidden. If this parameter is TS_RT_OPAQUE, the text run is a private data type embedded in the text by
		/// application or text service that implements the ITextStore interface.
		/// </summary>
		public TsRunType type;
	}

	/// <summary>The <c>TS_SELECTION_ACP</c> structure contains ACP-based text selection data.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/textstor/ns-textstor-ts_selection_acp typedef struct TS_SELECTION_ACP { LONG
	// acpStart; LONG acpEnd; TS_SELECTIONSTYLE style; } TS_SELECTION_ACP;
	[PInvokeData("textstor.h", MSDNShortId = "NS:textstor.TS_SELECTION_ACP")]
	[StructLayout(LayoutKind.Sequential, Pack = 4), Guid("C4B9C33B-8A0D-4426-BEBE-D444A4701FE9")]
	public struct TS_SELECTION_ACP
	{
		/// <summary>Contains the start position of the selection.</summary>
		public int acpStart;

		/// <summary>Contains the end position of the selection.</summary>
		public int acpEnd;

		/// <summary>A TS_SELECTIONSTYLE structure that contains additional selection data.</summary>
		public TS_SELECTIONSTYLE style;
	}

	/// <summary>The <c>TS_SELECTION_ANCHOR</c> structure contains anchor-based text selection data.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/textstor/ns-textstor-ts_selection_anchor typedef struct TS_SELECTION_ANCHOR {
	// IAnchor *paStart; IAnchor *paEnd; TS_SELECTIONSTYLE style; } TS_SELECTION_ANCHOR;
	[PInvokeData("textstor.h", MSDNShortId = "NS:textstor.TS_SELECTION_ANCHOR")]
	[StructLayout(LayoutKind.Sequential, Pack = 4), Guid("B03413D2-0723-4C4E-9E08-2E9C1FF3772B")]
	public struct TS_SELECTION_ANCHOR
	{
		/// <summary>Contains the start anchor of the selection.</summary>
		public IAnchor paStart;

		/// <summary>Contains the end anchor of the selection.</summary>
		public IAnchor paEnd;

		/// <summary>A TS_SELECTIONSTYLE structure that contains additional selection data.</summary>
		public TS_SELECTIONSTYLE style;
	}

	/// <summary>The <c>TS_SELECTIONSTYLE</c> structure represents the style of a selection.</summary>
	/// <remarks>
	/// An interim character selection is the length of one character and is visually represented as a solid rectangle that is usually
	/// flashing. This is a standard UI element of Korean and some Chinese character compositions. <c>fInterimChar</c> is an indication
	/// that a specific character is being composed. <c>fInterimChar</c> can only be nonzero for a single selection. In this case, there
	/// will be no caret because the highlight takes its place.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/textstor/ns-textstor-ts_selectionstyle typedef struct TS_SELECTIONSTYLE {
	// TsActiveSelEnd ase; BOOL fInterimChar; } TS_SELECTIONSTYLE;
	[PInvokeData("textstor.h", MSDNShortId = "NS:textstor.TS_SELECTIONSTYLE")]
	[StructLayout(LayoutKind.Sequential, Pack = 4), Guid("7ECC3FFA-8F73-4D91-98ED-76F8AC5B1600")]
	public struct TS_SELECTIONSTYLE
	{
		/// <summary>Specifies the active end of the selection. For more information, see TsActiveSelEnd.</summary>
		public TsActiveSelEnd ase;

		/// <summary>
		/// Indicates if the selection is an interim character. If this value is nonzero, then the seleciton is an interim character and
		/// <c>ase</c> will be TS_AE_NONE. If this value is zero, the selection is not an interim character.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool fInterimChar;
	}

	/// <summary>The <c>TS_STATUS</c> structure contains document status data.</summary>
	/// <remarks>
	/// <para>The TF_STATUS structure contains document status data.</para>
	/// <para>TF_STATUS is an alias for <c>TS_STATUS</c>.</para>
	/// <para>
	/// <c>dwDynamicFlags</c> contains a set of flags that can be changed by an app at run time. For example, an app can enable a check
	/// box for the user to reset the status of documentation. This member can contain zero, or one or more of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>TF_SD_LOADING</term>
	/// <term>The document is loading.</term>
	/// </item>
	/// <item>
	/// <term>TF_SD_READONLY</term>
	/// <term>The document is read-only.</term>
	/// </item>
	/// <item>
	/// <term>TS_SD_UIINTEGRATIONENABLE</term>
	/// <term>
	/// Starting with Windows 8.1: The text control owning the document sets this flag to indicate its support of Input Method Editor
	/// (IME) UI integration. When specified, the IME should attempt to align the candidate window below the text box instead of
	/// floating near the cursor.
	/// </term>
	/// </item>
	/// <item>
	/// <term>TF_SD_TKBAUTOCORRECTENABLE</term>
	/// <term>
	/// Starting with Windows 8.1: The document supports autocorrection provided by the touch keyboard. This support can change during
	/// the lifetime of the control.
	/// </term>
	/// </item>
	/// <item>
	/// <term>TF_SD_TKBPREDICTIONENABLE</term>
	/// <term>
	/// Starting with Windows 8.1: The document supports text suggestions provided by the touch keyboard. This support can change during
	/// the lifetime of the control.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// <c>dwStaticFlags</c> contains a set of flags that cannot be changed at run time. This member can contain zero, or one or more of
	/// the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>TF_SS_DISJOINTSEL</term>
	/// <term>The document supports multiple selections.</term>
	/// </item>
	/// <item>
	/// <term>TF_SS_REGIONS</term>
	/// <term>The document can contain multiple regions.</term>
	/// </item>
	/// <item>
	/// <term>TF_SS_TRANSITORY</term>
	/// <term>The document is expected to have a short usage cycle.</term>
	/// </item>
	/// <item>
	/// <term>TF_SS_TKBAUTOCORRECTENABLE</term>
	/// <term>Starting with Windows 8: The document supports autocorrection provided by the touch keyboard.</term>
	/// </item>
	/// <item>
	/// <term>TF_SS_TKBPREDICTIONENABLE</term>
	/// <term>Starting with Windows 8: The document supports text suggestions provided by the touch keyboard.</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/textstor/ns-textstor-ts_status typedef struct TS_STATUS { DWORD
	// dwDynamicFlags; DWORD dwStaticFlags; } TS_STATUS;
	[PInvokeData("textstor.h", MSDNShortId = "NS:textstor.TS_STATUS")]
	[StructLayout(LayoutKind.Sequential, Pack = 4), Guid("FEC4F516-C503-45B1-A5FD-7A3D8AB07049")]
	public struct TS_STATUS
	{
		/// <summary>
		/// <para>
		/// Contains a set of flags that can be changed by an app at run time. For example, an app can enable a check box for the user
		/// to reset the document status. This member can contain zero, or one or more of the following values.
		/// </para>
		/// </summary>
		public TS_SD dwDynamicFlags;

		/// <summary>
		/// <para>
		/// Contains a set of flags that cannot be changed at run time. This member can contain zero, or one or more of the following values.
		/// </para>
		/// </summary>
		public TS_SS dwStaticFlags;
	}

	/// <summary>The <c>TS_TEXTCHANGE</c> structure contains text change data.</summary>
	/// <remarks>
	/// The possible text changes include insert, delete, and replace. For example, if you replace the first "t" of "text" with "T",
	/// <c>acpStart</c> =0, <c>acpOldEnd</c> =1, and <c>acpNewEnd</c> =1. If you delete the last "t", <c>acpStart</c> =3,
	/// <c>acpOldEnd</c> =4, and <c>acpNewEnd</c> =3. If an "a" is inserted between "e" and "x", <c>acpStart</c> =2, <c>acpOldEnd</c>
	/// =2, and <c>acpNewEnd</c> =3.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/textstor/ns-textstor-ts_textchange typedef struct TS_TEXTCHANGE { LONG
	// acpStart; LONG acpOldEnd; LONG acpNewEnd; } TS_TEXTCHANGE;
	[PInvokeData("textstor.h", MSDNShortId = "NS:textstor.TS_TEXTCHANGE")]
	[StructLayout(LayoutKind.Sequential, Pack = 4), Guid("F3181BD6-BCF0-41D3-A81C-474B17EC38FB")]
	public struct TS_TEXTCHANGE
	{
		/// <summary>Contains the starting character position of the change.</summary>
		public int acpStart;

		/// <summary>Contains the ending character position before the text is changed.</summary>
		public int acpOldEnd;

		/// <summary>Contains the ending character position after the text is changed.</summary>
		public int acpNewEnd;
	}

	/// <summary>
	/// The following values identify attributes obtained with the ITfContext::GetAppProperty method. The data format and contents of
	/// each property type are included.
	/// </summary>
	[PInvokeData("tsattrs.h")]
	public static class TSATTRID
	{
		/// <summary>Not used.</summary>
		public static readonly Guid TSATTRID_App = new(0xa80f77df, 0x4237, 0x40e5, 0x84, 0x9c, 0xb5, 0xfa, 0x51, 0xc1, 0x3a, 0xc7);

		/// <summary>Contains a nonzero value if the text contains a spelling error or zero otherwise.</summary>
		public static readonly Guid TSATTRID_App_IncorrectGrammar = new(0xbd54e398, 0xad03, 0x4b74, 0xb6, 0xb3, 0x5e, 0xdb, 0x19, 0x99, 0x63, 0x88);

		/// <summary>Contains a nonzero value if the text contains a grammar error or zero otherwise.</summary>
		public static readonly Guid TSATTRID_App_IncorrectSpelling = new(0xf42de43c, 0xef12, 0x430d, 0x94, 0x4c, 0x9a, 0x08, 0x97, 0x0a, 0x25, 0xd2);

		/// <summary>Not used.</summary>
		public static readonly Guid TSATTRID_Font = new(0x573ea825, 0x749b, 0x4f8a, 0x9c, 0xfd, 0x21, 0xc3, 0x60, 0x5c, 0xa8, 0x28);

		/// <summary>Contains the face name of the text font.</summary>
		public static readonly Guid TSATTRID_Font_FaceName = new(0xb536aeb6, 0x053b, 0x4eb8, 0xb6, 0x5a, 0x50, 0xda, 0x1e, 0x81, 0xe7, 0x2e);

		/// <summary>Contains the point size of the text font.</summary>
		public static readonly Guid TSATTRID_Font_SizePts = new(0xc8493302, 0xa5e9, 0x456d, 0xaf, 0x04, 0x80, 0x05, 0xe4, 0x13, 0x0f, 0x03);

		/// <summary>Not used.</summary>
		public static readonly Guid TSATTRID_Font_Style = new(0x68b2a77f, 0x6b0e, 0x4f28, 0x81, 0x77, 0x57, 0x1c, 0x2f, 0x3a, 0x42, 0xb1);

		/// <summary>Not used.</summary>
		public static readonly Guid TSATTRID_Font_Style_Animation = new(0xdcf73d22, 0xe029, 0x47b7, 0xbb, 0x36, 0xf2, 0x63, 0xa3, 0xd0, 0x04, 0xcc);

		/// <summary>Contains a nonzero value if the text has the specified animation or zero otherwise.</summary>
		public static readonly Guid TSATTRID_Font_Style_Animation_BlinkingBackground = new(0x86e5b104, 0x0104, 0x4b10, 0xb5, 0x85, 0x00, 0xf2, 0x52, 0x75, 0x22, 0xb5);

		/// <summary>Contains a nonzero value if the text has the specified animation or zero otherwise.</summary>
		public static readonly Guid TSATTRID_Font_Style_Animation_LasVegasLights = new(0xf40423d5, 0xf87, 0x4f8f, 0xba, 0xda, 0xe6, 0xd6, 0xc, 0x25, 0xe1, 0x52);

		/// <summary>Contains a nonzero value if the text has the specified animation or zero otherwise.</summary>
		public static readonly Guid TSATTRID_Font_Style_Animation_MarchingBlackAnts = new(0x7644e067, 0xf186, 0x4902, 0xbf, 0xc6, 0xec, 0x81, 0x5a, 0xa2, 0x0e, 0x9d);

		/// <summary>Contains a nonzero value if the text has the specified animation or zero otherwise.</summary>
		public static readonly Guid TSATTRID_Font_Style_Animation_MarchingRedAnts = new(0x78368dad, 0x50fb, 0x4c6f, 0x84, 0x0b, 0xd4, 0x86, 0xbb, 0x6c, 0xf7, 0x81);

		/// <summary>Contains a nonzero value if the text has the specified animation or zero otherwise.</summary>
		public static readonly Guid TSATTRID_Font_Style_Animation_Shimmer = new(0x2ce31b58, 0x5293, 0x4c36, 0x88, 0x09, 0xbf, 0x8b, 0xb5, 0x1a, 0x27, 0xb3);

		/// <summary>Contains a nonzero value if the text has the specified animation or zero otherwise.</summary>
		public static readonly Guid TSATTRID_Font_Style_Animation_SparkleText = new(0x533aad20, 0x962c, 0x4e9f, 0x8c, 0x09, 0xb4, 0x2e, 0xa4, 0x74, 0x97, 0x11);

		/// <summary>Contains a nonzero value if the text has the specified animation or zero otherwise.</summary>
		public static readonly Guid TSATTRID_Font_Style_Animation_WipeDown = new(0x5872e874, 0x367b, 0x4803, 0xb1, 0x60, 0xc9, 0x0f, 0xf6, 0x25, 0x69, 0xd0);

		/// <summary>Contains a nonzero value if the text has the specified animation or zero otherwise.</summary>
		public static readonly Guid TSATTRID_Font_Style_Animation_WipeRight = new(0xb855cbe3, 0x3d2c, 0x4600, 0xb1, 0xe9, 0xe1, 0xc9, 0xce, 0x02, 0xf8, 0x42);

		/// <summary>Contains the RGB value of the text background. Contains 0xFF000000 if the text color is automatic.</summary>
		public static readonly Guid TSATTRID_Font_Style_BackgroundColor = new(0xb50eaa4e, 0x3091, 0x4468, 0x81, 0xdb, 0xd7, 0x9e, 0xa1, 0x90, 0xc7, 0xc7);

		/// <summary>Contains a nonzero value if the text is blinking or zero otherwise.</summary>
		public static readonly Guid TSATTRID_Font_Style_Blink = new(0xbfb2c036, 0x7acf, 0x4532, 0xb7, 0x20, 0xb4, 0x16, 0xdd, 0x77, 0x65, 0xa8);

		/// <summary>Contains a nonzero value if the text is bold or zero otherwise.</summary>
		public static readonly Guid TSATTRID_Font_Style_Bold = new(0x48813a43, 0x8a20, 0x4940, 0x8e, 0x58, 0x97, 0x82, 0x3f, 0x7b, 0x26, 0x8a);

		/// <summary>Contains a nonzero value if the text is capitalized or zero otherwise.</summary>
		public static readonly Guid TSATTRID_Font_Style_Capitalize = new(0x7d85a3ba, 0xb4fd, 0x43b3, 0xbe, 0xfc, 0x6b, 0x98, 0x5c, 0x84, 0x31, 0x41);

		/// <summary>Contains the RGB value of the text color. Contains 0xFF000000 if the text color is automatic.</summary>
		public static readonly Guid TSATTRID_Font_Style_Color = new(0x857a7a37, 0xb8af, 0x4e9a, 0x81, 0xb4, 0xac, 0xf7, 0x00, 0xc8, 0x41, 0x1b);

		/// <summary>Contains a nonzero value if the text is embossed or zero otherwise.</summary>
		public static readonly Guid TSATTRID_Font_Style_Emboss = new(0xbd8ed742, 0x349e, 0x4e37, 0x82, 0xfb, 0x43, 0x79, 0x79, 0xcb, 0x53, 0xa7);

		/// <summary>Contains a nonzero value if the text is engraved or zero otherwise.</summary>
		public static readonly Guid TSATTRID_Font_Style_Engrave = new(0x9c3371de, 0x8332, 0x4897, 0xbe, 0x5d, 0x89, 0x23, 0x32, 0x23, 0x17, 0x9a);

		/// <summary>Contains the font height. For more information, see the lfHeight member of the LOGFONT structure.</summary>
		public static readonly Guid TSATTRID_Font_Style_Height = new(0x7e937477, 0x12e6, 0x458b, 0x92, 0x6a, 0x1f, 0xa4, 0x4e, 0xe8, 0xf3, 0x91);

		/// <summary>Contains a nonzero value if the text is hidden or zero otherwise.</summary>
		public static readonly Guid TSATTRID_Font_Style_Hidden = new(0xb1e28770, 0x881c, 0x475f, 0x86, 0x3f, 0x88, 0x7a, 0x64, 0x7b, 0x10, 0x90);

		/// <summary>Contains a nonzero value if the text is italic or zero otherwise.</summary>
		public static readonly Guid TSATTRID_Font_Style_Italic = new(0x8740682a, 0xa765, 0x48e1, 0xac, 0xfc, 0xd2, 0x22, 0x22, 0xb2, 0xf8, 0x10);

		/// <summary>Contains the minimum kerning size. For more information, see ITextFont::GetKerning.</summary>
		public static readonly Guid TSATTRID_Font_Style_Kerning = new(0xcc26e1b4, 0x2f9a, 0x47c8, 0x8b, 0xff, 0xbf, 0x1e, 0xb7, 0xcc, 0xe0, 0xdd);

		/// <summary>Contains a nonzero value if the text is lowercase or zero otherwise.</summary>
		public static readonly Guid TSATTRID_Font_Style_Lowercase = new(0x76d8ccb5, 0xca7b, 0x4498, 0x8e, 0xe9, 0xd5, 0xc4, 0xf6, 0xf7, 0x4c, 0x60);

		/// <summary>Contains a nonzero value if the text is outlined or zero otherwise.</summary>
		public static readonly Guid TSATTRID_Font_Style_Outlined = new(0x10e6db31, 0xdb0d, 0x4ac6, 0xa7, 0xf5, 0x9c, 0x9c, 0xff, 0x6f, 0x2a, 0xb4);

		/// <summary>Contains a nonzero value if the text is overlined or zero otherwise.</summary>
		public static readonly Guid TSATTRID_Font_Style_Overline = new(0xe3989f4a, 0x992b, 0x4301, 0x8c, 0xe1, 0xa5, 0xb7, 0xc6, 0xd1, 0xf3, 0xc8);

		/// <summary>Contains a nonzero value if the text is double overlined or zero otherwise.</summary>
		public static readonly Guid TSATTRID_Font_Style_Overline_Double = new(0xdc46063a, 0xe115, 0x46e3, 0xbc, 0xd8, 0xca, 0x67, 0x72, 0xaa, 0x95, 0xb4);

		/// <summary>Contains a nonzero value if the text is single overlined or zero otherwise.</summary>
		public static readonly Guid TSATTRID_Font_Style_Overline_Single = new(0x8440d94c, 0x51ce, 0x47b2, 0x8d, 0x4c, 0x15, 0x75, 0x1e, 0x5f, 0x72, 0x1b);

		/// <summary>Contains the font position.</summary>
		public static readonly Guid TSATTRID_Font_Style_Position = new(0x15cd26ab, 0xf2fb, 0x4062, 0xb5, 0xa6, 0x9a, 0x49, 0xe1, 0xa5, 0xcc, 0x0b);

		/// <summary>Contains a nonzero value if the text is protected or zero otherwise.</summary>
		public static readonly Guid TSATTRID_Font_Style_Protected = new(0x1c557cb2, 0x14cf, 0x4554, 0xa5, 0x74, 0xec, 0xb2, 0xf7, 0xe7, 0xef, 0xd4);

		/// <summary>Contains a nonzero value if the text is shadowed or zero otherwise.</summary>
		public static readonly Guid TSATTRID_Font_Style_Shadow = new(0x5f686d2f, 0xc6cd, 0x4c56, 0x8a, 0x1a, 0x99, 0x4a, 0x4b, 0x97, 0x66, 0xbe);

		/// <summary>Contains a nonzero value if the text is lowercase or zero otherwise.</summary>
		public static readonly Guid TSATTRID_Font_Style_SmallCaps = new(0xfacb6bc6, 0x9100, 0x4cc6, 0xb9, 0x69, 0x11, 0xee, 0xa4, 0x5a, 0x86, 0xb4);

		/// <summary>Contains the font spacing.</summary>
		public static readonly Guid TSATTRID_Font_Style_Spacing = new(0x98c1200d, 0x8f06, 0x409a, 0x8e, 0x49, 0x6a, 0x55, 0x4b, 0xf7, 0xc1, 0x53);

		/// <summary>Not used.</summary>
		public static readonly Guid TSATTRID_Font_Style_Strikethrough = new(0x0c562193, 0x2d08, 0x4668, 0x96, 0x01, 0xce, 0xd4, 0x13, 0x09, 0xd7, 0xaf);

		/// <summary>Contains a nonzero value if the text is double strikethrough or zero otherwise.</summary>
		public static readonly Guid TSATTRID_Font_Style_Strikethrough_Double = new(0x62489b31, 0xa3e7, 0x4f94, 0xac, 0x43, 0xeb, 0xaf, 0x8f, 0xcc, 0x7a, 0x9f);

		/// <summary>Contains a nonzero value if the text is single strikethrough or zero otherwise.</summary>
		public static readonly Guid TSATTRID_Font_Style_Strikethrough_Single = new(0x75d736b6, 0x3c8f, 0x4b97, 0xab, 0x78, 0x18, 0x77, 0xcb, 0x99, 0x0d, 0x31);

		/// <summary>Contains a nonzero value if the text is subscript or zero otherwise.</summary>
		public static readonly Guid TSATTRID_Font_Style_Subscript = new(0x5774fb84, 0x389b, 0x43bc, 0xa7, 0x4b, 0x15, 0x68, 0x34, 0x7c, 0xf0, 0xf4);

		/// <summary>Contains a nonzero value if the text is superscript or zero otherwise.</summary>
		public static readonly Guid TSATTRID_Font_Style_Superscript = new(0x2ea4993c, 0x563c, 0x49aa, 0x93, 0x72, 0x0b, 0xef, 0x09, 0xa9, 0x25, 0x5b);

		/// <summary>Contains a nonzero value if the text is underlined or zero otherwise.</summary>
		public static readonly Guid TSATTRID_Font_Style_Underline = new(0xc3c9c9f3, 0x7902, 0x444b, 0x9a, 0x7b, 0x48, 0xe7, 0x0f, 0x4b, 0x50, 0xf7);

		/// <summary>Contains a nonzero value if the text is double underlined or zero otherwise.</summary>
		public static readonly Guid TSATTRID_Font_Style_Underline_Double = new(0x74d24aa6, 0x1db3, 0x4c69, 0xa1, 0x76, 0x31, 0x12, 0x0e, 0x75, 0x86, 0xd5);

		/// <summary>Contains a nonzero value if the text is single underlined or zero otherwise.</summary>
		public static readonly Guid TSATTRID_Font_Style_Underline_Single = new(0x1b6720e5, 0x0f73, 0x4951, 0xa6, 0xb3, 0x6f, 0x19, 0xe4, 0x3c, 0x94, 0x61);

		/// <summary>Contains a nonzero value if the text is uppercase or zero otherwise.</summary>
		public static readonly Guid TSATTRID_Font_Style_Uppercase = new(0x33a300e8, 0xe340, 0x4937, 0xb6, 0x97, 0x8f, 0x23, 0x40, 0x45, 0xcd, 0x9a);

		/// <summary>
		/// Contains the font weight. For more information about possible values, see the lfWeight member of the LOGFONT structure.
		/// </summary>
		public static readonly Guid TSATTRID_Font_Style_Weight = new(0x12f3189c, 0x8bb0, 0x461b, 0xb1, 0xfa, 0xea, 0xf9, 0x07, 0x04, 0x7f, 0xe0);

		/// <summary>Not used.</summary>
		public static readonly Guid TSATTRID_List = new(0x436d673b, 0x26f1, 0x4aee, 0x9e, 0x65, 0x8f, 0x83, 0xa4, 0xed, 0x48, 0x84);

		/// <summary>Contains the index level of the list. 1 is the outermost level, 2 is the next level, and so on.</summary>
		public static readonly Guid TSATTRID_List_LevelIndel = new(0x7f7cc899, 0x311f, 0x487b, 0xad, 0x5d, 0xe2, 0xa4, 0x59, 0xe1, 0x2d, 0x42);

		/// <summary>Not used.</summary>
		public static readonly Guid TSATTRID_List_Type = new(0xae3e665e, 0x4bce, 0x49e3, 0xa0, 0xfe, 0x2d, 0xb4, 0x7d, 0x3a, 0x17, 0xae);

		/// <summary>Contains a nonzero value if the list is an arabic numeral list or zero otherwise.</summary>
		public static readonly Guid TSATTRID_List_Type_Arabic = new(0x1338c5d6, 0x98a3, 0x4fa3, 0x9b, 0xd1, 0x7a, 0x60, 0xee, 0xf8, 0xe9, 0xe0);

		/// <summary>Contains a nonzero value if the list is a bulleted list or zero otherwise.</summary>
		public static readonly Guid TSATTRID_List_Type_Bullet = new(0xbccd77c5, 0x4c4d, 0x4ce2, 0xb1, 0x02, 0x55, 0x9f, 0x3b, 0x2b, 0xfc, 0xea);

		/// <summary>Contains a nonzero value if the list is a lowercase lettered list or zero otherwise.</summary>
		public static readonly Guid TSATTRID_List_Type_LowerLetter = new(0x96372285, 0xf3cf, 0x491e, 0xa9, 0x25, 0x38, 0x32, 0x34, 0x7f, 0xd2, 0x37);

		/// <summary>Contains a nonzero value if the list is a lowercase roman numeral list or zero otherwise.</summary>
		public static readonly Guid TSATTRID_List_Type_LowerRoman = new(0x90466262, 0x3980, 0x4b8e, 0x93, 0x68, 0x91, 0x8b, 0xd1, 0x21, 0x8a, 0x41);

		/// <summary>Contains a nonzero value if the list is an upper-case lettered list or zero otherwise.</summary>
		public static readonly Guid TSATTRID_List_Type_UpperLetter = new(0x7987b7cd, 0xce52, 0x428b, 0x9b, 0x95, 0xa3, 0x57, 0xf6, 0xf1, 0x0c, 0x45);

		/// <summary>Contains a nonzero value if the list is an uppercase roman numeral list or zero otherwise.</summary>
		public static readonly Guid TSATTRID_List_Type_UpperRoman = new(0x0f6ab552, 0x4a80, 0x467f, 0xb2, 0xf1, 0x12, 0x7e, 0x2a, 0xa3, 0xba, 0x9e);

		/// <summary>Not used.</summary>
		public static readonly Guid TSATTRID_OTHERS = new(0xb3c32af9, 0x57d0, 0x46a9, 0xbc, 0xa8, 0xda, 0xc2, 0x38, 0xa1, 0x30, 0x57);

		/// <summary>Not used.</summary>
		public static readonly Guid TSATTRID_Text = new(0x7edb8e68, 0x81f9, 0x449d, 0xa1, 0x5a, 0x87, 0xa8, 0x38, 0x8f, 0xaa, 0xc0);

		/// <summary>Not used.</summary>
		public static readonly Guid TSATTRID_Text_Alignment = new(0x139941e6, 0x1767, 0x456d, 0x93, 0x8e, 0x35, 0xba, 0x56, 0x8b, 0x5c, 0xd4);

		/// <summary>Contains a nonzero value if the text is centered or zero otherwise.</summary>
		public static readonly Guid TSATTRID_Text_Alignment_Center = new(0xa4a95c16, 0x53bf, 0x4d55, 0x8b, 0x87, 0x4b, 0xdd, 0x8d, 0x42, 0x75, 0xfc);

		/// <summary>Contains a nonzero value if the text is justified or zero otherwise.</summary>
		public static readonly Guid TSATTRID_Text_Alignment_Justify = new(0xed350740, 0xa0f7, 0x42d3, 0x8e, 0xa8, 0xf8, 0x1b, 0x64, 0x88, 0xfa, 0xf0);

		/// <summary>Contains a nonzero value if the text is left aligned or zero otherwise.</summary>
		public static readonly Guid TSATTRID_Text_Alignment_Left = new(0x16ae95d3, 0x6361, 0x43a2, 0x84, 0x95, 0xd0, 0x0f, 0x39, 0x7f, 0x16, 0x93);

		/// <summary>Contains a nonzero value if the text is right aligned or zero otherwise.</summary>
		public static readonly Guid TSATTRID_Text_Alignment_Right = new(0xb36f0f98, 0x1b9e, 0x4360, 0x86, 0x16, 0x03, 0xfb, 0x08, 0xa7, 0x84, 0x56);

		/// <summary>Contains a nonzero value if the text is an embedded object or zero otherwise.</summary>
		public static readonly Guid TSATTRID_Text_EmbeddedObject = new(0x7edb8e68, 0x81f9, 0x449d, 0xa1, 0x5a, 0x87, 0xa8, 0x38, 0x8f, 0xaa, 0xc0);

		/// <summary>Contains a nonzero value if the text is hyphenated or zero otherwise.</summary>
		public static readonly Guid TSATTRID_Text_Hyphenation = new(0xdadf4525, 0x618e, 0x49eb, 0xb1, 0xa8, 0x3b, 0x68, 0xbd, 0x76, 0x48, 0xe3);

		/// <summary>Contains the LANGID language identifier of the text.</summary>
		public static readonly Guid TSATTRID_Text_Language = new(0xd8c04ef1, 0x5753, 0x4c25, 0x88, 0x87, 0x85, 0x44, 0x3f, 0xe5, 0xf8, 0x19);

		/// <summary>
		/// Contains a pointer to a link object. The caller must use the QueryInterface method to obtain the desired interface, such as IUniformResourceLocator.
		/// </summary>
		public static readonly Guid TSATTRID_Text_Link = new(0x47cd9051, 0x3722, 0x4cd8, 0xb7, 0xc8, 0x4e, 0x17, 0xca, 0x17, 0x59, 0xf5);

		/// <summary>Specifies the angle, in tenths of degrees, between text base line and the x-axis of the device.</summary>
		public static readonly Guid TSATTRID_Text_Orientation = new(0x6bab707f, 0x8785, 0x4c39, 0x8b, 0x52, 0x96, 0xf8, 0x78, 0x30, 0x3f, 0xfb);

		/// <summary>Not used.</summary>
		public static readonly Guid TSATTRID_Text_Para = new(0x5edc5822, 0x99dc, 0x4dd6, 0xae, 0xc3, 0xb6, 0x2b, 0xaa, 0x5b, 0x2e, 0x7c);

		/// <summary>Contains the number of points that the first line of a paragraph is indented.</summary>
		public static readonly Guid TSATTRID_Text_Para_FirstLineIndent = new(0x07c97a13, 0x7472, 0x4dd8, 0x90, 0xa9, 0x91, 0xe3, 0xd7, 0xe4, 0xf2, 0x9c);

		/// <summary>Contains the number of points that the paragraph is indented from the left.</summary>
		public static readonly Guid TSATTRID_Text_Para_LeftIndent = new(0xfb2848e9, 0x7471, 0x41c9, 0xb6, 0xb3, 0x8a, 0x14, 0x50, 0xe0, 0x18, 0x97);

		/// <summary>Not used.</summary>
		public static readonly Guid TSATTRID_Text_Para_LineSpacing = new(0x699b380d, 0x7f8c, 0x46d6, 0xa7, 0x3b, 0xdf, 0xe3, 0xd1, 0x53, 0x8d, 0xf3);

		/// <summary>Contains the minimum number of lines for the line spacing of the paragraph.</summary>
		public static readonly Guid TSATTRID_Text_Para_LineSpacing_AtLeast = new(0xadfedf31, 0x2d44, 0x4434, 0xa5, 0xff, 0x7f, 0x4c, 0x49, 0x90, 0xa9, 0x05);

		/// <summary>Contains a nonzero value if the paragraph is double spaced or zero otherwise.</summary>
		public static readonly Guid TSATTRID_Text_Para_LineSpacing_Double = new(0x82fb1805, 0xa6c4, 0x4231, 0xac, 0x12, 0x62, 0x60, 0xaf, 0x2a, 0xba, 0x28);

		/// <summary>Contains the exact number of lines for the line spacing of the paragraph.</summary>
		public static readonly Guid TSATTRID_Text_Para_LineSpacing_Exactly = new(0x3d45ad40, 0x23de, 0x48d7, 0xa6, 0xb3, 0x76, 0x54, 0x20, 0xc6, 0x20, 0xcc);

		/// <summary>Contains the number of lines for the multiple line spacing of the paragraph.</summary>
		public static readonly Guid TSATTRID_Text_Para_LineSpacing_Multiple = new(0x910f1e3c, 0xd6d0, 0x4f65, 0x8a, 0x3c, 0x42, 0xb4, 0xb3, 0x18, 0x68, 0xc5);

		/// <summary>Contains a nonzero value if the paragraph is one and one half line spaced or zero otherwise.</summary>
		public static readonly Guid TSATTRID_Text_Para_LineSpacing_OnePtFive = new(0x0428a021, 0x0397, 0x4b57, 0x9a, 0x17, 0x07, 0x95, 0x99, 0x4c, 0xd3, 0xc5);

		/// <summary>Contains a nonzero value if the paragraph is single spaced or zero otherwise.</summary>
		public static readonly Guid TSATTRID_Text_Para_LineSpacing_Single = new(0xed350740, 0xa0f7, 0x42d3, 0x8e, 0xa8, 0xf8, 0x1b, 0x64, 0x88, 0xfa, 0xf0);

		/// <summary>Contains the number of points that the paragraph is indented from the right.</summary>
		public static readonly Guid TSATTRID_Text_Para_RightIndent = new(0x2c7f26f9, 0xa5e2, 0x48da, 0xb9, 0x8a, 0x52, 0x0c, 0xb1, 0x65, 0x13, 0xbf);

		/// <summary>Contains the number of points of spacing after the paragraph.</summary>
		public static readonly Guid TSATTRID_Text_Para_SpaceAfter = new(0x7b0a3f55, 0x22dc, 0x425f, 0xa4, 0x11, 0x93, 0xda, 0x1d, 0x8f, 0x9b, 0xaa);

		/// <summary>Contains the number of points of spacing before the paragraph.</summary>
		public static readonly Guid TSATTRID_Text_Para_SpaceBefore = new(0x8df98589, 0x194a, 0x4601, 0xb2, 0x51, 0x98, 0x65, 0xa3, 0xe9, 0x06, 0xdd);

		/// <summary>Contains zero if the text is read-only or nonzero otherwise.</summary>
		public static readonly Guid TSATTRID_Text_ReadOnly = new(0x85836617, 0xde32, 0x4afd, 0xa5, 0x0f, 0xa2, 0xdb, 0x11, 0x0e, 0x6e, 0x4d);

		/// <summary>Contains zero if the text is right-to-left reading or nonzero otherwise.</summary>
		public static readonly Guid TSATTRID_Text_RightToLeft = new(0xca666e71, 0x1b08, 0x453d, 0xbf, 0xdd, 0x28, 0xe0, 0x8c, 0x8a, 0xaf, 0x7a);

		/// <summary>
		/// Specifies if the text is vertical or horizontal. Contains zero if the text is horizontal or nonzero if the text is vertical.
		/// </summary>
		public static readonly Guid TSATTRID_Text_VerticalWriting = new(0x6bba8195, 0x046f, 0x4ea9, 0xb3, 0x11, 0x97, 0xfd, 0x66, 0xc4, 0x27, 0x4b);
	}
}