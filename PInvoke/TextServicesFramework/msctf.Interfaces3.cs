using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

using TfClientId = System.UInt32;

using TfEditCookie = System.UInt32;

namespace Vanara.PInvoke;

public static partial class MSCTF
{
	/// <summary>
	/// The <c>ITfRangeACP</c> interface is implemented by the TSF manager and is used by an application character position (ACP)-based
	/// application to access and manipulate range objects. This interface is derived from the ITfRange interface. Obtain an instance of
	/// this interface by querying an <c>ITfRange</c> object for IID_ITfRangeACP.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-itfrangeacp
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.ITfRangeACP")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("057A6296-029B-4154-B79A-0D461D4EA94C")]
	public interface ITfRangeACP : ITfRange
	{
		/// <summary>The <c>ITfRange::GetText</c> method obtains the content covered by this range of text.</summary>
		/// <param name="ec">Edit cookie that identifies the edit context obtained from ITfDocumentMgr::CreateContext or ITfEditSession::DoEditSession.</param>
		/// <param name="dwFlags">
		/// <para>Bit fields that specify optional behavior.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TF_TF_MOVESTART</term>
		/// <term>Start anchor of the range is advanced to the position after the last character returned.</term>
		/// </item>
		/// <item>
		/// <term>TF_TF_IGNOREEND</term>
		/// <term>
		/// Method attempts to fill pchText with the maximum number of characters, instead of halting the copy at the position occupied
		/// by the end anchor of the range.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pchText">Pointer to a buffer to receive the text in the range.</param>
		/// <param name="cchMax">Maximum size of the text buffer.</param>
		/// <param name="pcch">Pointer to a ULONG representing the number of characters written to the pchText text buffer.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfrange-gettext HRESULT GetText( TfEditCookie ec, DWORD
		// dwFlags, WCHAR *pchText, ULONG cchMax, ULONG *pcch );
		new void GetText([In] TfEditCookie ec, [In] TF_TF dwFlags, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pchText, uint cchMax, out uint pcch);

		/// <summary>
		/// The <c>ITfRange::SetText</c> method replaces the content covered by the range of text. For an empty range object, the method
		/// results in an insertion at the location of the range. If the new content is an empty string (cch = 0), the method deletes
		/// the existing content within the range.
		/// </summary>
		/// <param name="ec">Identifies the edit context obtained from ITfDocumentMgr::CreateContext or ITfEditSession::DoEditSession.</param>
		/// <param name="dwFlags">
		/// Specifies optional behavior for correction of content. If set to the value of TF_ST_CORRECTION, then the operation is a
		/// correction of the existing content, not a creation of new content, and original text properties are preserved.
		/// </param>
		/// <param name="pchText">Pointer to a buffer that contains the text to replace the range contents.</param>
		/// <param name="cch">Contains the number of characters in pchText.</param>
		/// <remarks>
		/// <para>
		/// When a range covers multiple regions, call <c>ITfRange::SetText</c> on each region separately. Otherwise, the method can fail.
		/// </para>
		/// <para>
		/// By default, text services start and end a temporary composition that covers the range, to ensure that context owners
		/// consistently recognize compositions over edited text. If the composition owner rejects a default composition, then the
		/// method returns TF_E_COMPOSITION_REJECTED. Default compositions are only created if the caller has not already started one.
		/// If the caller has an active composition, the call fails.
		/// </para>
		/// <para>
		/// The TF_CHAR_EMBEDDED object placeholder character might not be passed into this method. ITfRange::InsertEmbedded should be
		/// used instead.
		/// </para>
		/// <para>
		/// For inserting text, the ITFInsertAtSelection:InsertTextAtSelection method does not require a selection range to be
		/// allocated, and avoids the requirement that the range match the selection.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfrange-settext HRESULT SetText( TfEditCookie ec, DWORD
		// dwFlags, const WCHAR *pchText, LONG cch );
		new void SetText([In] TfEditCookie ec, [In] TF_ST dwFlags, [In, MarshalAs(UnmanagedType.LPWStr)] string pchText, int cch);

		/// <summary>
		/// The <c>ITfRange::GetFormattedText</c> method obtains formatted content contained within a range of text. The content is
		/// packaged in an object that supports the IDataObject interface.
		/// </summary>
		/// <param name="ec">Edit cookie obtained from ITfDocumentMgr::CreateContext or ITfEditSession::DoEditSession.</param>
		/// <returns>
		/// Pointer to an <c>IDataObject</c> pointer that receives an object that contains the formatted content. The formatted content
		/// is obtained using a STGMEDIUM global memory handle.
		/// </returns>
		/// <remarks>The format and storage type of the <c>IDataObject</c> are determined by the application to which the range belongs.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfrange-getformattedtext HRESULT GetFormattedText(
		// TfEditCookie ec, IDataObject **ppDataObject );
		new IDataObject GetFormattedText([In] TfEditCookie ec);

		/// <summary>
		/// The <c>ITfRange::GetEmbedded</c> method obtains content that corresponds to a TS_CHAR_EMBEDDED character in the text stream.
		/// The start anchor of the range of text is positioned just before the character of interest.
		/// </summary>
		/// <param name="ec">Edit cookie obtained from ITfDocumentMgr::CreateContext or ITfEditSession::DoEditSession.</param>
		/// <param name="rguidService">
		/// <para>Identifier that specifies how the embedded content is obtained.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>GUID_TS_SERVICE_ACCESSIBLE</term>
		/// <term>Output should be an Accessible object.</term>
		/// </item>
		/// <item>
		/// <term>GUID_TS_SERVICE_ACTIVEX</term>
		/// <term>Caller requires a direct pointer to the object that supports the interface specified by riid.</term>
		/// </item>
		/// <item>
		/// <term>GUID_TS_SERVICE_DATAOBJECT</term>
		/// <term>
		/// Content should be obtained as an IDataObject data transfer object, with riid being IID_IDataObject. Clients should specify
		/// this option when a copy of the content is required.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Caller-defined</term>
		/// <term>Text services and context owners can define custom GUIDs.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="riid">UUID of the interface of the requested object.</param>
		/// <returns>Pointer to the object. It can be cast to match riid.</returns>
		/// <remarks>
		/// While the obtained object might not support certain interfaces, it is likely that the object will support those interfaces
		/// associated with embedded documents or controls such as <c>IOleObject</c>, <c>IDataObject</c>, <c>IViewObject</c>,
		/// <c>IPersistStorage</c>, <c>IOleCache</c>, or <c>IDispatch</c>. The caller must use <c>QueryInterface</c> to probe for any
		/// interesting interface. If the method succeeds but riid is <c>NULL</c>, the application indicates the presence of an embedded
		/// object but does not expose the object itself. Text processors can still benefit from a notification about the potential word break.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfrange-getembedded HRESULT GetEmbedded( TfEditCookie ec,
		// REFGUID rguidService, REFIID riid, IUnknown **ppunk );
		[return: MarshalAs(UnmanagedType.IUnknown)]
		new object GetEmbedded([In] TfEditCookie ec, in Guid rguidService, in Guid riid);

		/// <summary>
		/// The <c>ITfRange::InsertEmbedded</c> method inserts an object at the location of the start anchor of the range of text.
		/// </summary>
		/// <param name="ec">Edit cookie obtained from ITfDocumentMgr::CreateContext or ITfEditSession::DoEditSession.</param>
		/// <param name="dwFlags">
		/// Bit fields that specify how insertion should occur. If TF_IE_CORRECTION is set, the operation is a correction, so that other
		/// text services can preserve data associated with the original text.
		/// </param>
		/// <param name="pDataObject">Pointer to the data transfer object to be inserted.</param>
		/// <remarks>
		/// <para>
		/// Use this method to insert objects into the text stream, because the TF_CHAR_EMBEDDED object placeholder character cannot be
		/// passed into ITfRange::SetText. This method is modeled after the OLE clipboard API, with applications using pDataObject as
		/// they would an IDataObject returned from OleGetClipboard.
		/// </para>
		/// <para>
		/// When a range covers multiple regions, the method should be called on each region separately. Otherwise, the method might fail.
		/// </para>
		/// <para>
		/// By default, text services start and end a temporary composition that covers the range, to ensure that context owners
		/// consistently recognize compositions over edited text. If the composition owner rejects a default composition, then the
		/// method returns TF_E_COMPOSITION_REJECTED. Default compositions are only created if the caller has not already started one.
		/// If the caller has an active composition, the call fails.
		/// </para>
		/// <para>To determine in advance whether a context owner supports insertion of a particular object, use ITfQueryEmbedded::QueryInsertEmbedded.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfrange-insertembedded HRESULT InsertEmbedded(
		// TfEditCookie ec, DWORD dwFlags, IDataObject *pDataObject );
		new void InsertEmbedded([In] TfEditCookie ec, [In] TF_IE dwFlags, [In] IDataObject pDataObject);

		/// <summary>Moves the start anchor of the range.</summary>
		/// <param name="ec">
		/// Contains an edit cookie that identifies the edit context. This is obtained from ITfDocumentMgr::CreateContext or ITfEditSession::DoEditSession.
		/// </param>
		/// <param name="cchReq">
		/// Contains the number of characters the start anchor is shifted. A negative value causes the anchor to move backward and a
		/// positive value causes the anchor to move forward.
		/// </param>
		/// <param name="pcch">Pointer to a <c>LONG</c> value that receives the number of characters the anchor was shifted.</param>
		/// <param name="pHalt">
		/// Pointer to a TF_HALTCOND structure that contains conditions about the shift. This parameter is optional and can be <c>NULL</c>.
		/// </param>
		/// <remarks>
		/// <para>The start and end positions of a range are called anchors.</para>
		/// <para>
		/// This method cannot move an anchor beyond a region boundary. If the shift reaches a region boundary, the number of characters
		/// actually shifted will be less than requested. ITfRange::ShiftStartRegion is used to shift the anchor to an adjacent region.
		/// </para>
		/// <para>
		/// If the shift operation causes the range start anchor to move past the end anchor, the end anchor is moved to the same
		/// location as the start anchor.
		/// </para>
		/// <para>
		/// <c>ITfRange::ShiftStart</c> can be a lengthy operation. For better performance, use ITfRange::ShiftStartToRange when possible.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfrange-shiftstart HRESULT ShiftStart( TfEditCookie ec,
		// LONG cchReq, LONG *pcch, const TF_HALTCOND *pHalt );
		new void ShiftStart([In] TfEditCookie ec, int cchReq, out int pcch, [In, Optional] TF_HALTCOND pHalt);

		/// <summary>Moves the end anchor of the range.</summary>
		/// <param name="ec">
		/// Contains an edit cookie that identifies the edit context. This is obtained from ITfDocumentMgr::CreateContext or ITfEditSession::DoEditSession.
		/// </param>
		/// <param name="cchReq">
		/// Contains the number of characters that the end anchor is shifted. A negative value causes the anchor to move backward and a
		/// positive value causes the anchor to move forward.
		/// </param>
		/// <param name="pcch">Pointer to a <c>LONG</c> value that receives the number of characters the anchor shifted.</param>
		/// <param name="pHalt">
		/// Pointer to a TF_HALTCOND structure that contains conditions on the shift. This parameter is optional and can be <c>NULL</c>.
		/// </param>
		/// <remarks>
		/// <para>The start and end positions of a range are called anchors.</para>
		/// <para>
		/// This method cannot move an anchor beyond a region boundary. If the shift reaches a region boundary, the number of characters
		/// actually shifted will be less than requested. ITfRange::ShiftEndRegion is used to shift the anchor to an adjacent region.
		/// </para>
		/// <para>
		/// If the shift operation causes the range end anchor to move past the start anchor, the start anchor is moved to the same
		/// location as the end anchor.
		/// </para>
		/// <para>ITfRange::ShiftEnd can be a lengthy operation. For better performance, use ITfRange::ShiftEndToRange when possible.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfrange-shiftend HRESULT ShiftEnd( TfEditCookie ec, LONG
		// cchReq, LONG *pcch, const TF_HALTCOND *pHalt );
		new void ShiftEnd([In] TfEditCookie ec, int cchReq, out int pcch, [In, Optional] TF_HALTCOND pHalt);

		/// <summary>Moves the start anchor of this range to an anchor within another range.</summary>
		/// <param name="ec">
		/// Contains an edit cookie that identifies the edit context obtained from ITfDocumentMgr::CreateContext or ITfEditSession::DoEditSession.
		/// </param>
		/// <param name="pRange">Pointer to an ITfRange interface that contains the anchor that the start anchor is moved to.</param>
		/// <param name="aPos">
		/// Contains one of the TfAnchor values that specifies which anchor of pRange the start anchor is moved to.
		/// </param>
		/// <remarks>
		/// <para>The start and end positions of a range are called anchors.</para>
		/// <para>
		/// If the shift operation causes the range start anchor to move past the end anchor, the end anchor is moved to the same
		/// location as the start anchor.
		/// </para>
		/// <para>This method is more efficient than ITfRange::ShiftStart and should be used when possible.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfrange-shiftstarttorange HRESULT ShiftStartToRange(
		// TfEditCookie ec, ITfRange *pRange, TfAnchor aPos );
		new void ShiftStartToRange([In] TfEditCookie ec, [In] ITfRange pRange, [In] TfAnchor aPos);

		/// <summary>Moves the end anchor of this range to an anchor within another range.</summary>
		/// <param name="ec">
		/// Contains an edit cookie that identifies the edit context obtained from ITfDocumentMgr::CreateContext or ITfEditSession::DoEditSession.
		/// </param>
		/// <param name="pRange">Pointer to an ITfRange interface that contains the anchor that the end anchor is moved to.</param>
		/// <param name="aPos">
		/// Contains one of the TfAnchor values that specify which anchor of pRange the end anchor will get moved to.
		/// </param>
		/// <remarks>
		/// <para>The start and end positions of a range are called anchors.</para>
		/// <para>
		/// If the shift operation causes the range end anchor to move past the start anchor, the start anchor is moved to the same
		/// location as the end anchor.
		/// </para>
		/// <para>This method is more efficient than ITfRange::ShiftEnd and should be used.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfrange-shiftendtorange HRESULT ShiftEndToRange(
		// TfEditCookie ec, ITfRange *pRange, TfAnchor aPos );
		new void ShiftEndToRange([In] TfEditCookie ec, [In] ITfRange pRange, [In] TfAnchor aPos);

		/// <summary>Moves the start anchor into an adjacent region.</summary>
		/// <param name="ec">
		/// Contains an edit cookie that identifies the edit context obtained from ITfDocumentMgr::CreateContext or ITfEditSession::DoEditSession.
		/// </param>
		/// <param name="dir">
		/// Contains one of the TfShiftDir values that specifies which adjacent region the start anchor is moved to.
		/// </param>
		/// <returns>
		/// Pointer to a <c>BOOL</c> that receives a flag that indicates if the anchor is positioned adjacent to another region.
		/// Receives a nonzero value if the anchor is not adjacent to another region or zero otherwise.
		/// </returns>
		/// <remarks>
		/// <para>The start and end positions of a range are called anchors.</para>
		/// <para>
		/// The anchor must be positioned adjacent to the desired region prior to calling this method. If it is not, then pfNoRegion
		/// receives a nonzero value and the anchor is not moved. If the anchor is adjacent to the desired region, pfNoRegion receives
		/// zero and the anchor is moved to the region.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfrange-shiftstartregion HRESULT ShiftStartRegion(
		// TfEditCookie ec, TfShiftDir dir, BOOL *pfNoRegion );
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool ShiftStartRegion([In] TfEditCookie ec, [In] TfShiftDir dir);

		/// <summary>Moves the end anchor into an adjacent region.</summary>
		/// <param name="ec">
		/// Contains an edit cookie that identifies the edit context obtained from ITfDocumentMgr::CreateContext or ITfEditSession::DoEditSession.
		/// </param>
		/// <param name="dir">Contains one of the TfShiftDir values that specify which adjacent region the end anchor is moved to.</param>
		/// <returns>
		/// Pointer to a <c>BOOL</c> value that receives a flag that indicates if the anchor is positioned adjacent to another region.
		/// Receives a nonzero value if the anchor is not adjacent to another region or zero otherwise.
		/// </returns>
		/// <remarks>
		/// <para>The start and end positions of a range are known as anchors.</para>
		/// <para>
		/// The anchor must be positioned adjacent to the desired region prior to calling this method. If it is not, then pfNoRegion
		/// receives a nonzero value and the anchor is not moved. If the anchor is adjacent to the desired region, pfNoRegion receives
		/// zero and the anchor is moved into the region.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfrange-shiftendregion HRESULT ShiftEndRegion(
		// TfEditCookie ec, TfShiftDir dir, BOOL *pfNoRegion );
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool ShiftEndRegion([In] TfEditCookie ec, [In] TfShiftDir dir);

		/// <summary>
		/// The <c>ITfRange::IsEmpty</c> method verifies that the range of text is empty because the start and end anchors occupy the
		/// same position.
		/// </summary>
		/// <param name="ec">Edit cookie that identifies the edit context. It is obtained from ITfDocumentMgr::CreateContext or ITfEditSession::DoEditSession.</param>
		/// <returns>
		/// Pointer to a Boolean value. <c>TRUE</c> indicates the range is empty; <c>FALSE</c> indicates the range is not empty.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfrange-isempty HRESULT IsEmpty( TfEditCookie ec, BOOL
		// *pfEmpty );
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool IsEmpty([In] TfEditCookie ec);

		/// <summary>
		/// The <c>ITfRange::Collapse</c> method clears the range of text by moving its start anchor and end anchor to the same position.
		/// </summary>
		/// <param name="ec">Edit cookie obtained from ITfDocumentMgr::CreateContext or ITfEditSession::DoEditSession.</param>
		/// <param name="aPos">
		/// <para>TfAnchor enumeration that describes how to collapse the range.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TF_ANCHOR_START</term>
		/// <term>The end anchor is moved to the location of the start anchor.</term>
		/// </item>
		/// <item>
		/// <term>TF_ANCHOR_END</term>
		/// <term>The start anchor is moved to the location of the end anchor.</term>
		/// </item>
		/// </list>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfrange-collapse HRESULT Collapse( TfEditCookie ec,
		// TfAnchor aPos );
		new void Collapse([In] TfEditCookie ec, [In] TfAnchor aPos);

		/// <summary>
		/// The <c>ITfRange::IsEqualStart</c> method verifies that the start anchor of this range of text matches an anchor of another
		/// specified range.
		/// </summary>
		/// <param name="ec">Edit cookie obtained from ITfDocumentMgr::CreateContext or ITfEditSession::DoEditSession.</param>
		/// <param name="pWith">Pointer to a specified range in which an anchor is to be compared to this range start anchor.</param>
		/// <param name="aPos">
		/// <para>Enumeration element that indicates which anchor of the specified pWith range to compare to this range start anchor.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TF_ANCHOR_START</term>
		/// <term>Compares this range start anchor with the specified range start anchor.</term>
		/// </item>
		/// <item>
		/// <term>TF_ANCHOR_END</term>
		/// <term>Compares this range start anchor with the specified range end anchor.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// Pointer to a Boolean value. Upon return, <c>TRUE</c> indicates that the specified pWith range anchor matches this range
		/// start anchor. <c>FALSE</c> indicates otherwise.
		/// </returns>
		/// <remarks>This method is identical to, but more efficient than, ITfRange::CompareStart.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfrange-isequalstart HRESULT IsEqualStart( TfEditCookie
		// ec, ITfRange *pWith, TfAnchor aPos, BOOL *pfEqual );
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool IsEqualStart([In] TfEditCookie ec, [In] ITfRange pWith, [In] TfAnchor aPos);

		/// <summary>
		/// The ITfRange::IsEqualStart method verifies that the end anchor of this range of text matches an anchor of another specified range.
		/// </summary>
		/// <param name="ec">Edit cookie obtained from ITfDocumentMgr::CreateContext or ITfEditSession::DoEditSession.</param>
		/// <param name="pWith">Pointer to a specified range in which an anchor is to be compared to this range end anchor.</param>
		/// <param name="aPos">
		/// <para>Enumeration element that indicates which anchor of the specified pWith range to compare with this range end anchor.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TF_ANCHOR_START</term>
		/// <term>Compares this range end anchor with the specified range start anchor.</term>
		/// </item>
		/// <item>
		/// <term>TF_ANCHOR_END</term>
		/// <term>Compares this range end anchor with the specified range end anchor.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// Pointer to a Boolean value. Upon return, <c>TRUE</c> indicates that the specified pWith range anchor matches this range end
		/// anchor. <c>FALSE</c> indicates otherwise.
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method is identical to <c>ITfRange::IsEqualStart</c>, except that the end anchor of this range is compared to an anchor
		/// of another specified range.
		/// </para>
		/// <para>This method is functionally equivalent to, but more efficient than, ITfRange::CompareEnd.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfrange-isequalend HRESULT IsEqualEnd( TfEditCookie ec,
		// ITfRange *pWith, TfAnchor aPos, BOOL *pfEqual );
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool IsEqualEnd([In] TfEditCookie ec, [In] ITfRange pWith, [In] TfAnchor aPos);

		/// <summary>
		/// The <c>ITfRange::CompareStart</c> method compares the start anchor position of this range of text to an anchor in another range.
		/// </summary>
		/// <param name="ec">Edit cookie obtained from ITfDocumentMgr::CreateContext or ITfEditSession::DoEditSession.</param>
		/// <param name="pWith">Pointer to a specified range in which an anchor is to be compared to this range start anchor.</param>
		/// <param name="aPos">
		/// <para>Enumeration element that indicates which anchor of the specified pWith range to compare to this range start anchor.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TF_ANCHOR_START</term>
		/// <term>Compare this range start anchor with the specified range start anchor.</term>
		/// </item>
		/// <item>
		/// <term>TF_ANCHOR_END</term>
		/// <term>Compare this range start anchor with the specified range end anchor.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Pointer to the result of the comparison between this range start anchor and the specified pWith range anchor.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>-1</term>
		/// <term>
		/// This start anchor is behind the anchor of the specified range (position of this start anchor &lt; position of the anchor of
		/// the specified range).
		/// </term>
		/// </item>
		/// <item>
		/// <term>0</term>
		/// <term>This start anchor is at the same position as the anchor of the specified range.</term>
		/// </item>
		/// <item>
		/// <term>+1</term>
		/// <term>
		/// This start anchor is ahead of the anchor of the specified range (position of this start anchor &gt; position of the anchor
		/// of the specified range).
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// This method will never return 0 unless the two anchors are in a single region. If the caller only requires information about
		/// whether the two anchors are positioned at the same location, ITfRange::IsEqualStart is more efficient.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfrange-comparestart HRESULT CompareStart( TfEditCookie
		// ec, ITfRange *pWith, TfAnchor aPos, LONG *plResult );
		new int CompareStart([In] TfEditCookie ec, [In] ITfRange pWith, [In] TfAnchor aPos);

		/// <summary>
		/// The <c>ITfRange::CompareEnd</c> method compares the end anchor position of this range of text to an anchor in another range.
		/// </summary>
		/// <param name="ec">Edit cookie obtained from ITfDocumentMgr::CreateContext or ITfEditSession::DoEditSession.</param>
		/// <param name="pWith">Pointer to a specified range in which an anchor is to be compared with this range end anchor.</param>
		/// <param name="aPos">
		/// <para>Enumeration element that indicates which anchor of the specified pWith range to compare with this range end anchor.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TF_ANCHOR_START</term>
		/// <term>Compare this range end anchor with the specified range start anchor.</term>
		/// </item>
		/// <item>
		/// <term>TF_ANCHOR_END</term>
		/// <term>Compare this range end anchor with the specified range end anchor.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Pointer to the result of the comparison between this range end anchor and the anchor of the specified pWith range.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>-1</term>
		/// <term>
		/// This end anchor is behind the anchor of the specified range (position of this end anchor &lt; position of the anchor of the
		/// specified range).
		/// </term>
		/// </item>
		/// <item>
		/// <term>0</term>
		/// <term>This end anchor is at the same position as the anchor of the specified range.</term>
		/// </item>
		/// <item>
		/// <term>+1</term>
		/// <term>
		/// This end anchor is ahead of the anchor of the specified range (position of this end anchor &gt; position of the anchor of
		/// the specified range).
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method will never return 0 unless the two anchors are in a single region. If the caller only requires information about
		/// whether the two anchors are positioned at the same location, ITfRange::IsEqualEnd is more efficient.
		/// </para>
		/// <para>
		/// This method is identical to ITfRange::CompareStart, except that the end anchor of this range is compared to an anchor of
		/// another specified range.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfrange-compareend HRESULT CompareEnd( TfEditCookie ec,
		// ITfRange *pWith, TfAnchor aPos, LONG *plResult );
		new int CompareEnd([In] TfEditCookie ec, [In] ITfRange pWith, [In] TfAnchor aPos);

		/// <summary>The <c>ITfRange::AdjustForInsert</c> method expands or contracts a range of text to adjust for text insertion.</summary>
		/// <param name="ec">Edit cookie obtained from ITfDocumentMgr::CreateContext or ITfEditSession::DoEditSession.</param>
		/// <param name="cchInsert">
		/// Character count of the inserted text. This count is used in a futurecall to ITfRange::SetText. If the character count is
		/// unknown, 0 can be used.
		/// </param>
		/// <returns>
		/// Pointer to a flag that indicates whether the context owner will accept ( <c>TRUE</c>) or reject ( <c>FALSE</c>) the insertion.
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method should be used to prepare a range to initiate a new composition, before editing begins. It should be used only
		/// when the text is not inserted at the current selection. ITFInsertAtSelection:InsertTextAtSelection or
		/// ITfInsertAtSelection::InsertEmbeddedAtSelection are the correct methods to use when text is inserted at the current selection.
		/// </para>
		/// <para>
		/// The context owner can use this method to preserve behavior and help maintain a consistent user experience. For example,
		/// certain characters or objects in the context can be preserved from modifications, or overtyping can be supported.
		/// </para>
		/// <para>
		/// This method is not necessary when modifying an existing composition. It is acceptable to call <c>ITfRange::SetText</c>
		/// directly to modify text previously entered by the caller.
		/// </para>
		/// <para>
		/// On exit, if *pfInsertOk is set to <c>FALSE</c>, a future call to <c>ITfRange::SetText</c> or ITfRange::InsertEmbedded with
		/// this range is likely to fail. Otherwise, *pfInsertOk will be set to <c>TRUE</c>, and the range start anchor or end anchor
		/// can be repositioned at the discretion of the context owner.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfrange-adjustforinsert HRESULT AdjustForInsert(
		// TfEditCookie ec, ULONG cchInsert, BOOL *pfInsertOk );
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool AdjustForInsert([In] TfEditCookie ec, uint cchInsert);

		/// <summary>Obtains the gravity of the anchors in the object.</summary>
		/// <param name="pgStart">Pointer to a TfGravity value that receives the gravity of the start anchor.</param>
		/// <param name="pgEnd">Pointer to a <c>TfGravity</c> value that receives the gravity of the end anchor.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfrange-getgravity HRESULT GetGravity( TfGravity *pgStart,
		// TfGravity *pgEnd );
		new void GetGravity(out TfGravity pgStart, out TfGravity pgEnd);

		/// <summary>Sets the gravity of the anchors in the object.</summary>
		/// <param name="ec">
		/// Contains an edit cookie that identifies the edit context obtained from ITfDocumentMgr::CreateContext or ITfEditSession::DoEditSession.
		/// </param>
		/// <param name="gStart">Contains one of the TfGravity values that specifies the gravity of the start anchor.</param>
		/// <param name="gEnd">Contains one of the <c>TfGravity</c> values that specifies the gravity of the end anchor.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfrange-setgravity HRESULT SetGravity( TfEditCookie ec,
		// TfGravity gStart, TfGravity gEnd );
		new void SetGravity([In] TfEditCookie ec, [In] TfGravity gStart, [In] TfGravity gEnd);

		/// <summary>The <c>ITfRange::Clone</c> method duplicates this range of text.</summary>
		/// <returns>Pointer to a new range object that references this range.</returns>
		/// <remarks>
		/// <para>
		/// The resulting new range object can be modified without affecting the original. However, modifying the document that contains
		/// the new range might cause the original range's anchors to be repositioned.
		/// </para>
		/// <para>The gravity of the original is preserved in the new range.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfrange-clone HRESULT Clone( ITfRange **ppClone );
		new ITfRange Clone();

		/// <summary>Obtains the context object to which the range belongs.</summary>
		/// <returns>Pointer to an ITfContext interface pointer that receives the context object that the range belongs to.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfrange-getcontext HRESULT GetContext( ITfContext
		// **ppContext );
		new ITfContext GetContext();

		/// <summary>Obtains the application character position and length of the range object.</summary>
		/// <param name="pacpAnchor">
		/// Pointer to a <c>LONG</c> value that receives the application character position of the range start anchor.
		/// </param>
		/// <param name="pcch">Pointer to a <c>LONG</c> value that receives the number of characters in the range.</param>
		/// <remarks>
		/// This method should only be called by the owner of the ACP-based context because the character position and range length will
		/// only have meaning to a caller that recognizes the text store implementation.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfrangeacp-getextent HRESULT GetExtent( LONG *pacpAnchor,
		// LONG *pcch );
		void GetExtent(out int pacpAnchor, out int pcch);

		/// <summary>Sets the application character position and length of the range object.</summary>
		/// <param name="acpAnchor">Contains the application character position of the range start anchor.</param>
		/// <param name="cch">Contains the number of characters in the range.</param>
		/// <remarks>
		/// This method should only be called by the owner of the ACP-based context because the character position and range length will
		/// only have meaning to a caller that recognizes the text store implementation.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfrangeacp-setextent HRESULT SetExtent( LONG acpAnchor,
		// LONG cch );
		void SetExtent(int acpAnchor, int cch);
	}

	/// <summary>
	/// The <c>ITfRangeBackup</c> interface is implemented by the TSF manager and is used by a text service to create a backup copy of
	/// the data contained in a range object. This backup copy can be used later to restore the range object. An instance of this
	/// interface is obtained by calling ITfContext::CreateRangeBackup.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-itfrangebackup
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.ITfRangeBackup")]
	[ComImport, Guid("463A506D-6992-49D2-9B88-93D55E70BB16"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ITfRangeBackup
	{
		/// <summary>Restores a specified range object into the TSF context.</summary>
		/// <param name="ec">Contains an edit cookie that identifies the edit session. This is the value passed to ITfEditSession::DoEditSession.</param>
		/// <param name="pRange">
		/// Pointer to an ITfRange object that receives the backup information. If this parameter is <c>NULL</c>, the backup information
		/// is restored into a copy of the range originally backed up by <c>ITfContext::CreateRangeBackup</c>.
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfrangebackup-restore HRESULT Restore( TfEditCookie ec,
		// ITfRange *pRange );
		void Restore([In] TfEditCookie ec, [In] ITfRange pRange);
	}

	/// <summary>
	/// The <c>ITfCandidateListUIElement</c> interface is implemented by a text service that has a UI for reading information UI at the
	/// near caret.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-itfreadinginformationuielement
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.ITfReadingInformationUIElement")]
	[ComImport, Guid("EA1EA139-19DF-11D7-A6D2-00065B84435C"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ITfReadingInformationUIElement : ITfUIElement
	{
		/// <summary>The <c>ITfUIElement::GetDescription</c> method returns the description of the UI element.</summary>
		/// <param name="pbstrDescription">[in] A pointer to BSTR that contains the description of the UI element.</param>
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
		/// <term>One or more parameters are invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfuielement-getdescription HRESULT GetDescription( BSTR
		// *pbstrDescription );
		[PreserveSig]
		new HRESULT GetDescription([Out, MarshalAs(UnmanagedType.BStr)] out string pbstrDescription);

		/// <summary>The <c>ITfUIElement::GetGUID</c> method returns the unique id of this UI element.</summary>
		/// <param name="pguid">[out] A pointer to receive the GUID of the UI element.</param>
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
		/// <term>One or more parameters are invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfuielement-getguid HRESULT GetGUID( GUID *pguid );
		[PreserveSig]
		new HRESULT GetGUID(out Guid pguid);

		/// <summary>The <c>ITfUIElement::Show</c> method shows the text service's UI of this UI element.</summary>
		/// <param name="bShow">
		/// [in] <c>TRUE</c> to show the original UI of the element. <c>FALSE</c> to hide the original UI of the element.
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
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfuielement-show HRESULT Show( BOOL bShow );
		[PreserveSig]
		new HRESULT Show([In, MarshalAs(UnmanagedType.Bool)] bool bShow);

		/// <summary>
		/// The <c>ITfUIElement::IsShown</c> method returns true if the UI is currently shown by a text service; otherwise false.
		/// </summary>
		/// <param name="pbShow">[out] A pointer to bool of the current show status of the original UI of this element.</param>
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
		/// <term>One or more parameters are invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfuielement-isshown HRESULT IsShown( BOOL *pbShow );
		[PreserveSig]
		new HRESULT IsShown([Out, MarshalAs(UnmanagedType.Bool)] out bool pbShow);

		/// <summary>This method returns the flag that tells which part of this element was updated.</summary>
		/// <param name="pdwFlags">
		/// <para>[out] A pointer to receive the flags that is a combination of the following bits:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TF_RIUIE_CONTEXT</term>
		/// <term>The target ITfContext was changed.</term>
		/// </item>
		/// <item>
		/// <term>TF_RIUIE_STRING</term>
		/// <term>The reading information string was changed.</term>
		/// </item>
		/// <item>
		/// <term>TF_RIUIE_MAXREADINGSTRINGLENGTH</term>
		/// <term>The max length of the reading information string was changed.</term>
		/// </item>
		/// <item>
		/// <term>TF_RIUIE_ERRORINDEX</term>
		/// <term>The error index of the reading information string was changed.</term>
		/// </item>
		/// <item>
		/// <term>TF_RIUIE_VERTICALORDER</term>
		/// <term>The vertical order preference was changed.</term>
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
		/// <term>E_FAIL</term>
		/// <term>An unspecified error occurred.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One or more parameters are invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfreadinginformationuielement-getupdatedflags HRESULT
		// GetUpdatedFlags( DWORD *pdwFlags );
		[PreserveSig]
		HRESULT GetUpdatedFlags(out TF_RIUIE pdwFlags);

		/// <summary>This method returns the target ITfContext of this reading information UI.</summary>
		/// <param name="ppic">[out] A pointer to receive the target ITfContext interface of this UI element.</param>
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
		/// <term>One or more parameters are invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfreadinginformationuielement-getcontext HRESULT
		// GetContext( ITfContext **ppic );
		[PreserveSig]
		HRESULT GetContext(out ITfContext ppic);

		/// <summary>This method returns the string on the reading information UI.</summary>
		/// <param name="pstr">[out] A pointer to the BSTR of the reading information string.</param>
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
		/// <term>One or more parameters are invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfreadinginformationuielement-getstring HRESULT GetString(
		// BSTR *pstr );
		[PreserveSig]
		HRESULT GetString([Out, MarshalAs(UnmanagedType.BStr)] out string pstr);

		/// <summary>
		/// The <c>ITfReadingInformationUIElement::GetMaxReadingStringLength</c> method returns the max string count of the reading
		/// information UI.
		/// </summary>
		/// <param name="pcchMax">[out] A pointer to the max length of the reading information string.</param>
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
		/// <term>One or more parameters are invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfreadinginformationuielement-getmaxreadingstringlength
		// HRESULT GetMaxReadingStringLength( UINT *pcchMax );
		[PreserveSig]
		HRESULT GetMaxReadingStringLength(out uint pcchMax);

		/// <summary>This method returns the char index where the typing error occurs.</summary>
		/// <param name="pErrorIndex">[out] A pointer to receive the char index where the typing error occurs.</param>
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
		/// <term>One or more parameters are invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfreadinginformationuielement-geterrorindex HRESULT
		// GetErrorIndex( UINT *pErrorIndex );
		[PreserveSig]
		HRESULT GetErrorIndex(out uint pErrorIndex);

		/// <summary>This method returns if the UI prefers to be shown in vertical order.</summary>
		/// <param name="pfVertical">[out] True if the UI prefers to be shown in the vertical order.</param>
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
		/// <term>One or more parameters are invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfreadinginformationuielement-isverticalorderpreferred
		// HRESULT IsVerticalOrderPreferred( BOOL *pfVertical );
		[PreserveSig]
		HRESULT IsVerticalOrderPreferred([Out, MarshalAs(UnmanagedType.Bool)] out bool pfVertical);
	}

	/// <summary>
	/// The <c>ITfReadOnlyProperty</c> interface is implemented by the TSF manager and used by an application or text service to obtain
	/// property data.
	/// </summary>
	/// <remarks>An instance of this interface is obtained by using ITfContext::GetAppProperty or ITfContext::TrackProperties.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-itfreadonlyproperty
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.ITfReadOnlyProperty")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("17D49A3D-F8B8-4B2F-B254-52319DD64C53")]
	public interface ITfReadOnlyProperty
	{
		/// <summary>Obtains the property identifier.</summary>
		/// <returns>
		/// <para>
		/// Pointer to a <c>GUID</c> value that receives the property type identifier. This is the value that the property provider
		/// passed to ITfCategoryMgr::RegisterCategory when the property was registered. This can be one of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>GUID_TFCAT_PROPSTYLE_STATIC</term>
		/// <term>The property is a static property.</term>
		/// </item>
		/// <item>
		/// <term>GUID_TFCAT_PROPSTYLE_STATICCOMPACT</term>
		/// <term>The property is a static-compact property.</term>
		/// </item>
		/// <item>
		/// <term>GUID_TFCAT_PROPSTYLE_CUSTOM</term>
		/// <term>The property is a custom property.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfreadonlyproperty-gettype HRESULT GetType( GUID *pguid );
		Guid GetType();

		/// <summary>Obtains an enumeration of ranges that contain unique values of the property within the given range.</summary>
		/// <param name="ec">
		/// Contains an edit cookie that identifies the edit context. This is obtained from ITfDocumentMgr::CreateContext or ITfEditSession::DoEditSession.
		/// </param>
		/// <param name="ppEnum">
		/// Pointer to an IEnumTfRanges interface pointer that receives the enumerator object. The caller must release this object when
		/// it is no longer required.
		/// </param>
		/// <param name="pTargetRange">
		/// Pointer to an ITfRange interface that specifies the range to scan for unique property values. This parameter is optional and
		/// can be <c>NULL</c>. For more information, see the Remarks section.
		/// </param>
		/// <remarks>
		/// <para>
		/// <c>Note:</c> If an application does not implement ITextStoreACP::FindNextAttrTransition,
		/// <c>ITfReadOnlyProperty::EnumRanges</c> fails with E_FAIL.
		/// </para>
		/// <para>
		/// The enumerator obtained by this method will contain a range for each unique value, including empty values, of the specified
		/// property. For example, a hypothetical color property can be applied to the following marked up text:
		/// </para>
		/// <para>
		/// <code> COLOR: RR GGGGGGGG TEXT: this is some colored text</code>
		/// </para>
		/// <para>
		/// When <c>ITfReadOnlyProperty::EnumRanges</c> is called with pTargetRange set to this range, the enumerator will contain five ranges.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Range Index</term>
		/// <term>Color Property Value</term>
		/// <term>Range Text</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>&lt;empty&gt;</term>
		/// <term>"this "</term>
		/// </item>
		/// <item>
		/// <term>1</term>
		/// <term>R</term>
		/// <term>"is"</term>
		/// </item>
		/// <item>
		/// <term>2</term>
		/// <term>&lt;empty&gt;</term>
		/// <term>" some "</term>
		/// </item>
		/// <item>
		/// <term>3</term>
		/// <term>G</term>
		/// <term>"colored "</term>
		/// </item>
		/// <item>
		/// <term>4</term>
		/// <term>&lt;empty&gt;</term>
		/// <term>"text"</term>
		/// </item>
		/// </list>
		/// <para>
		/// If pTargetRange is <c>NULL</c>, then the enumerator will begin and end with the first and last range that contains a
		/// non-empty property value in the context. Specifying <c>NULL</c> for pTargetRange in the above example would result in an
		/// enumerator with three ranges.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Range Index</term>
		/// <term>Color Property Value</term>
		/// <term>Text Within Range</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>R</term>
		/// <term>"is"</term>
		/// </item>
		/// <item>
		/// <term>1</term>
		/// <term>&lt;empty&gt;</term>
		/// <term>" some "</term>
		/// </item>
		/// <item>
		/// <term>2</term>
		/// <term>G</term>
		/// <term>"colored "</term>
		/// </item>
		/// </list>
		/// <para>
		/// The enumerated ranges will begin and end with the start and end anchors of pTargetRange, even if either anchor is positioned
		/// in the middle of a property.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfreadonlyproperty-enumranges HRESULT EnumRanges(
		// TfEditCookie ec, IEnumTfRanges **ppEnum, ITfRange *pTargetRange );
		void EnumRanges([In] TfEditCookie ec, out IEnumTfRanges ppEnum, [In, Optional] ITfRange pTargetRange);

		/// <summary>Obtains the value of the property for a range of text.</summary>
		/// <param name="ec">
		/// Contains an edit cookie that identifies the edit context. This is obtained from ITfDocumentMgr::CreateContext or ITfEditSession::DoEditSession.
		/// </param>
		/// <param name="pRange">Pointer to an ITfRange interface that specifies the range to obtain the property for.</param>
		/// <returns>
		/// Pointer to a <c>VARIANT</c> value that receives the property value. The data type and contents of this value is defined by
		/// the property owner and must be recognized by the caller in order to use this value. The caller must release this data, when
		/// it is no longer required, by passing this value to the <c>VariantClear</c> API.
		/// </returns>
		/// <remarks>
		/// <para>
		/// If the property has no value over pRange, pRange contains more than one value for the property or the property does not
		/// completely cover pRange, pvarValue receives a VT_EMPTY value and the method returns S_FALSE.
		/// </para>
		/// <para>
		/// <code> COLOR: RR GGGGGGGG TEXT: this is some colored text range--&gt;||&lt;-</code>
		/// </para>
		/// <para>
		/// <code> COLOR: RR GGGGGGGG TEXT: this is some colored text range--&gt;| |&lt;-</code>
		/// </para>
		/// <para>
		/// <code> COLOR: RR GGGGGGGG TEXT: this is some colored text range--&gt;| |&lt;-</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfreadonlyproperty-getvalue HRESULT GetValue( TfEditCookie
		// ec, ITfRange *pRange, VARIANT *pvarValue );
		[return: MarshalAs(UnmanagedType.Struct)]
		object GetValue([In] TfEditCookie ec, [In] ITfRange pRange);

		/// <summary>Obtains the context object for the property.</summary>
		/// <returns>
		/// Pointer to an ITfContext interface pointer that receives the context object. The caller must release this object when it is
		/// no longer required.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfreadonlyproperty-getcontext HRESULT GetContext(
		// ITfContext **ppContext );
		ITfContext GetContext();
	}

	/// <summary>
	/// The <c>ITfSource</c> interface is implemented by the TSF manager. It is used by applications and text services to install and
	/// uninstall advise sinks.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The TSF manager has different implementations of <c>ITfSource</c>, depending upon how the <c>ITfSource</c> interface is
	/// obtained. The difference in the implementations is the types of advise sinks that can be installed with the interface. The
	/// different implementations can be obtained from the following objects.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>ITfThreadMgr</term>
	/// </item>
	/// <item>
	/// <term>ITfContext</term>
	/// </item>
	/// <item>
	/// <term>ITfCompartment</term>
	/// </item>
	/// <item>
	/// <term>ITfInputProcessorProfiles</term>
	/// </item>
	/// <item>
	/// <term>ITfLangBarItem</term>
	/// </item>
	/// </list>
	/// <para>For more information about advise sinks that can be installed by each implementation, see ITfSource::AdviseSink.</para>
	/// <para>Examples</para>
	/// <para><c>ITfThreadMgr</c></para>
	/// <para>
	/// <code> HRESULT hr; ITfSource *pSource; hr = pThreadManager-&gt;QueryInterface(IID_ITfSource, (LPVOID*)&amp;pSource); if(SUCCEEDED(hr)) { //Use the ITfSource interface. pSource-&gt;Release(); }</code>
	/// </para>
	/// <para><c>ITfContext</c></para>
	/// <para>
	/// <code> HRESULT hr; ITfSource *pSource; hr = pContext-&gt;QueryInterface(IID_ITfSource, (LPVOID*)&amp;pSource); if(SUCCEEDED(hr)) { //Use the ITfSource interface. pSource-&gt;Release(); }</code>
	/// </para>
	/// <para><c>ITfCompartment</c></para>
	/// <para>
	/// <code> HRESULT hr; ITfSource *pSource; hr = pCompartmentManager-&gt;QueryInterface(IID_ITfSource, (LPVOID*)&amp;pSource); if(SUCCEEDED(hr)) { //Use the ITfSource interface. pSource-&gt;Release(); }</code>
	/// </para>
	/// <para><c>ITfInputProcessorProfiles</c></para>
	/// <para>
	/// <code> HRESULT hr; ITfSource *pSource; hr = pProfiles-&gt;QueryInterface(IID_ITfSource, (LPVOID*)&amp;pSource); if(SUCCEEDED(hr)) { //Use the ITfSource interface. pSource-&gt;Release(); }</code>
	/// </para>
	/// <para><c>ITfLangBarItem</c></para>
	/// <para>
	/// <code> HRESULT hr; ITfSource *pSource; hr = pLangBarItem-&gt;QueryInterface(IID_ITfSource, (LPVOID*)&amp;pSource); if(SUCCEEDED(hr)) { //Use the ITfSource interface. pSource-&gt;Release(); }</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-itfsource
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.ITfSource")]
	[ComImport, Guid("4EA48A35-60AE-446F-8FD6-E6A8D82459F7"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ITfSource
	{
		/// <summary>Installs an advise sink.</summary>
		/// <param name="riid">
		/// <para>Identifies the type of advise sink to install.</para>
		/// <para>
		/// This parameter can be one of the following values when the <c>ITfSource</c> object is obtained from an ITfThreadMgr object.
		/// </para>
		/// <para>This parameter can be one of the following values when the ITfSource object is obtained from an ITfContext object.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>IID_ITfActiveLanguageProfileNotifySink</term>
		/// <term>Installs an ITfActiveLanguageProfileNotifySink advise sink.</term>
		/// </item>
		/// <item>
		/// <term>IID_ITfDisplayAttributeNotifySink</term>
		/// <term>Installs an ITfDisplayAttributeNotifySink advise sink.</term>
		/// </item>
		/// <item>
		/// <term>IID_ITfKeyTraceEventSink</term>
		/// <term>Installs an ITfKeyTraceEventSink advise sink.</term>
		/// </item>
		/// <item>
		/// <term>IID_ITfPreservedKeyNotifySink</term>
		/// <term>Installs an ITfPreservedKeyNotifySink advise sink.</term>
		/// </item>
		/// <item>
		/// <term>IID_ITfThreadFocusSink</term>
		/// <term>Installs an ITfThreadFocusSink advise sink.</term>
		/// </item>
		/// <item>
		/// <term>IID_ITfThreadMgrEventSink</term>
		/// <term>Installs an ITfThreadMgrEventSink advise sink.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="punk">The advise sink <c>IUnknown</c> pointer.</param>
		/// <param name="pdwCookie">
		/// Address of a DWORD value that receives an identifying cookie. This value is used to uninstall the advise sink in a
		/// subsequent call to ITfSource::UnadviseSink. Receives (DWORD)-1 if a failure occurs.
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfsource-advisesink HRESULT AdviseSink( REFIID riid,
		// IUnknown *punk, DWORD *pdwCookie );
		void AdviseSink(in Guid riid, [In, MarshalAs(UnmanagedType.IUnknown)] object punk, out uint pdwCookie);

		/// <summary>Uninstalls an advise sink.</summary>
		/// <param name="dwCookie">
		/// A DWORD that identifies the advise sink to uninstall. This value is provided by a previous call to ITfSource::AdviseSink.
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfsource-unadvisesink HRESULT UnadviseSink( DWORD dwCookie );
		void UnadviseSink(uint dwCookie);
	}

	/// <summary>
	/// The <c>ITfSourceSingle</c> interface is implemented by the TSF manager. It is used by applications and text services to install
	/// and remove various advise sinks. This interface differs from ITfSource in that advise sinks installed with
	/// <c>ITfSourceSingle</c> only support one advise sink at a time whereas advise sinks installed with <c>ITfSource</c> support
	/// multiple simultaneous advise sinks.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The TSF manager has different implementations of <c>ITfSourceSingle</c>, depending upon how the <c>ITfSourceSingle</c> interface
	/// is obtained. The difference in the implementations is the types of advise sinks that can be installed with the interface. The
	/// different implementations can be obtained from the following objects.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>ITfThreadMgr</term>
	/// </item>
	/// <item>
	/// <term>ITfContext</term>
	/// </item>
	/// </list>
	/// <para>For more information about advise sinks that can be installed by each implementation, see ITfSourceSingle::AdviseSingleSink.</para>
	/// <para>Examples</para>
	/// <para><c>ITfThreadMgr</c></para>
	/// <para>
	/// <code> HRESULT hr; ITfSourceSingle *pSourceSingle; hr = pThreadManager-&gt;QueryInterface(IID_ITfSourceSingle, (LPVOID*)&amp;pSourceSingle); if(SUCCEEDED(hr)) { //Use the ITfSourceSingle interface. pSourceSingle-&gt;Release(); }</code>
	/// </para>
	/// <para><c>ITfContext</c></para>
	/// <para>
	/// <code> HRESULT hr; ITfSourceSingle *pSourceSingle; hr = pContext-&gt;QueryInterface(IID_ITfSourceSingle, (LPVOID*)&amp;pSourceSingle); if(SUCCEEDED(hr)) { //Use the ITfSourceSingle interface. pSourceSingle-&gt;Release(); }</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-itfsourcesingle
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.ITfSourceSingle")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("73131F9C-56A9-49DD-B0EE-D046633F7528")]
	public interface ITfSourceSingle
	{
		/// <summary>Installs an advise sink.</summary>
		/// <param name="tid">Contains a <c>TfClientId</c> value that identifies the client.</param>
		/// <param name="riid">
		/// <para>Identifies the type of advise sink to install.</para>
		/// <para>
		/// This parameter can be one of the following values when the ITfSourceSingle object is obtained from an ITfThreadMgr object.
		/// </para>
		/// <para>
		/// This parameter can be one of the following values when the <c>ITfSourceSingle</c> object is obtained from an ITfContext object.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>IID_ITfCleanupContextDurationSink</term>
		/// <term>Installs a ITfCleanupContextDurationSink advise sink.</term>
		/// </item>
		/// <item>
		/// <term>IID_ITfFunctionProvider</term>
		/// <term>Registers the client as a function provider. The punk parameter is an ITfFunctionProvider interface pointer.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="punk">Pointer to the advise sink <c>IUnknown</c> pointer.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfsourcesingle-advisesinglesink HRESULT AdviseSingleSink(
		// TfClientId tid, REFIID riid, IUnknown *punk );
		void AdviseSingleSink([In] TfClientId tid, in Guid riid, [In, MarshalAs(UnmanagedType.IUnknown)] object punk);

		/// <summary>Uninstalls an advise sink.</summary>
		/// <param name="tid">Contains a <c>TfClientId</c> value that identifies the client.</param>
		/// <param name="riid">
		/// <para>Identifies the type of advise sink to uninstall. This can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>IID_ITfCleanupContextDurationSink</term>
		/// <term>Uninstalls the ITfCleanupContextDurationSink advise sink. Applies to: Text service</term>
		/// </item>
		/// <item>
		/// <term>IID_ITfCleanupContextSink</term>
		/// <term>Uninstalls the ITfCleanupContextSink advise sink. Applies to: Text service</term>
		/// </item>
		/// <item>
		/// <term>IID_ITfFunctionProvider</term>
		/// <term>Unregisters the client as a function provider. Applies to: Text Service and Application</term>
		/// </item>
		/// </list>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfsourcesingle-unadvisesinglesink HRESULT
		// UnadviseSingleSink( TfClientId tid, REFIID riid );
		void UnadviseSingleSink([In] TfClientId tid, in Guid riid);
	}

	/// <summary>The <c>ITfSpeechUIServer</c> interface manages the speech-related user interface on the TSF language bar.</summary>
	/// <remarks>
	/// <para>
	/// The user interface elements on the TSF language bar managed by this interface include the microphone button, the speech
	/// configuration menu button, the dictation button, the command button, and the speech balloon. The standard speech text service
	/// usually manages these user interface elements in an application, including initialization. This type of application does not
	/// require the <c>ITfSpeechUIServer</c> interface.
	/// </para>
	/// <para>
	/// An application that does not use the speech text service might require use of the features provided by the speech-related
	/// interface elements. In that case, the following code example shows how an application can obtain a pointer to the
	/// <c>ITfSpeechUIServer</c> interface by calling the CoCreateInstance function with the CLSID_SpeechUIServer <c>CLSID</c>.
	/// </para>
	/// <para>
	/// <code> HRESULT hr; ITfSpeechUIServer* piSpeechUIServer; hr = CoCreateInstance(CLSID_SpeechUIServer, NULL, CLSCTX_INPROC_SERVER, IID_ITfSpeechUIServer, (void**)&amp;piSpeechUIServer);</code>
	/// </para>
	/// <para>
	/// Subsequently, the application can use the ITfSpeechUIServer::Initialize method to initialize the user interface and the other
	/// methods of the <c>ITfSpeechUIServer</c> interface to manage the user interface.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ctfspui/nn-ctfspui-itfspeechuiserver
	[PInvokeData("ctfspui.h", MSDNShortId = "NN:ctfspui.ITfSpeechUIServer")]
	[ComImport, Guid("90E9A944-9244-489F-A78F-DE67AFC013A7"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ITfSpeechUIServer
	{
		/// <summary>Initializes the speech-related user interface elements on the TSF language bar.</summary>
		/// <remarks>
		/// The standard speech text service usually initializes the speech-related user interface on the TSF language bar. When a
		/// TSF-enabled application, that does not use the speech text service, requires use of the ITfSpeechUIServer interface, it
		/// initializes the user interface with this method.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctfspui/nf-ctfspui-itfspeechuiserver-initialize HRESULT Initialize();
		void Initialize();

		/// <summary>Sets the visibility state of the speech-related user interface elements on the TSF language bar.</summary>
		/// <param name="fShow">Specifies whether to show (TRUE) or not show (FALSE) the speech-related user interface elements.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctfspui/nf-ctfspui-itfspeechuiserver-showui HRESULT ShowUI( BOOL fShow );
		void ShowUI([In, MarshalAs(UnmanagedType.Bool)] bool fShow);

		/// <summary>Sets the style and text of the speech balloon on the TSF language bar.</summary>
		/// <param name="style">Contains a TfLBBalloonStyle element that specifies the balloon style.</param>
		/// <param name="pch">Pointer to a zero-terminated Unicode string that contains the text to show in the balloon.</param>
		/// <param name="cch">Specifies the number of characters in the string of the pch parameter.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctfspui/nf-ctfspui-itfspeechuiserver-updateballoon HRESULT UpdateBalloon(
		// TfLBBalloonStyle style, const WCHAR *pch, ULONG cch );
		void UpdateBalloon([In] TfLBBalloonStyle style, [In, MarshalAs(UnmanagedType.LPWStr)] string pch, uint cch);
	}

	/// <summary>
	/// The <c>ITfStatusSink</c> interface supports changes to the global document status. This advise sink is installed by calling
	/// ITfSource::AdviseSink with IID_ITfStatusSink. A text service can optionally implement this interface.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-itfstatussink
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.ITfStatusSink")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("6B7D8D73-B267-4F69-B32E-1CA321CE4F45")]
	public interface ITfStatusSink
	{
		/// <summary>Receives a notification when one of the dynamic flags of the TF_STATUS structure changes.</summary>
		/// <param name="pic">Pointer to the ITfContext interface whose status has changed.</param>
		/// <param name="dwFlags">Indicates that one of the dynamic flags changed.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// This method receives a callback when one of the flags of the <c>dwDynamicFlags</c> member of the <c>TF_STATUS</c> structure
		/// changes value. To obtain the changed flag(s), use the <see cref="ITfContext.GetStatus"/> method.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfstatussink-onstatuschange HRESULT OnStatusChange(
		// ITfContext *pic, DWORD dwFlags );
		[PreserveSig]
		HRESULT OnStatusChange([In] ITfContext pic, uint dwFlags);
	}

	/// <summary>
	/// The <c>ITfTextEditSink</c> interface supports completion of an edit session that involves read/write access. Install this advise
	/// sink by calling ITfSource::AdviseSink with IID_ITfTextEditSink. A text service or application can optionally implement this interface.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-itftexteditsink
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.ITfTextEditSink")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("8127D409-CCD3-4683-967A-B43D5B482BF7")]
	public interface ITfTextEditSink
	{
		/// <summary>
		/// Receives a notification upon completion of an ITfEditSession::DoEditSession method that has read/write access to the context.
		/// </summary>
		/// <param name="pic">Pointer to the ITfContext interface for the edited context.</param>
		/// <param name="ecReadOnly">Specifies a TfEditCookie value for read-only access to the context.</param>
		/// <param name="pEditRecord">Pointer to the ITfEditRecord interface used to access the modifications to the context.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// <para>
		/// An edit session with read/write access is requested with a call to the ITfContext::RequestEditSession method using the
		/// TF_ES_READWRITE flag, which establishes an <c>ITfEditSession::DoEditSession</c> method to perform the session. When such a
		/// <c>ITfEditSession::DoEditSession</c> method completes, TSF calls this method.
		/// </para>
		/// <para>
		/// A text service can use the ecReadOnly parameter only to view the context. If changes are required, the text service must use
		/// an asynchronous call to the <c>ITfContext::RequestEditSession</c> method. However, a text service should modify only text
		/// that it previously entered as part of a composition. Otherwise, two or more text services could repeatedly modify the same
		/// text. A text service can use the ITfContext::InWriteSession method to determine if it performed the completed edit session.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itftexteditsink-onendedit HRESULT OnEndEdit( ITfContext
		// *pic, TfEditCookie ecReadOnly, ITfEditRecord *pEditRecord );
		[PreserveSig]
		HRESULT OnEndEdit([In] ITfContext pic, [In] TfEditCookie ecReadOnly, [In] ITfEditRecord pEditRecord);
	}

	/// <summary>
	/// The <c>ITfTextInputProcessor</c> interface is implemented by a text service and used by the TSF manager to activate and
	/// deactivate the text service. The manager obtains a pointer to this interface when it creates an instance of the text service for
	/// a thread with a call to CoCreateInstance.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-itftextinputprocessor
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.ITfTextInputProcessor")]
	[ComImport, Guid("AA80E7F7-2021-11D2-93E0-0060B067B86E"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ITfTextInputProcessor
	{
		/// <summary>Activates a text service when a user session starts.</summary>
		/// <param name="ptim">Pointer to the ITfThreadMgr interface for the thread manager that owns the text service.</param>
		/// <param name="tid">Specifies the client identifier for the text service.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// <para>
		/// TSF calls this method after creating an instance of a text service with a call to CoCreateInstance. This enables operations
		/// necessary to start the text service.
		/// </para>
		/// <para>
		/// This method usually adds a reference to the thread manager for the session and advise sinks for events that involve the text
		/// service, such as change of focus, keystrokes, and window events. It also customizes the language bar for the text service.
		/// </para>
		/// <para>
		/// The corresponding ITfTextInputProcessor::Deactivate method that shuts down the text service must release all references to
		/// the ptim parameter.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itftextinputprocessor-activate HRESULT Activate(
		// ITfThreadMgr *ptim, TfClientId tid );
		[PreserveSig]
		HRESULT Activate([In] ITfThreadMgr ptim, [In] TfClientId tid);

		/// <summary>Deactivates a text service when a user session ends.</summary>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// <para>
		/// TSF calls this method immediately before releasing its final reference to a text service. This provides the opportunity to
		/// perform operations necessary to shut down the text service.
		/// </para>
		/// <para>
		/// This method usually unadvises sinks for events that involve the text service. It can also close any user interface elements
		/// of the text service.
		/// </para>
		/// <para>
		/// Before this method returns, it must release all references to the ptim parameter passed to the text service by the
		/// ITfTextInputProcessor::Activate method.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itftextinputprocessor-deactivate HRESULT Deactivate();
		[PreserveSig]
		HRESULT Deactivate();
	}

	/// <summary>
	/// The <c>ITfTextInputProcessorEx</c> interface is implemented by a text service and used by the TSF manager to activate and
	/// deactivate the text service. The manager obtains a pointer to this interface when it creates an instance of the text service for
	/// a thread with a call to CoCreateInstance.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-itftextinputprocessorex
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.ITfTextInputProcessorEx")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("6E4E2102-F9CD-433D-B496-303CE03A6507")]
	public interface ITfTextInputProcessorEx : ITfTextInputProcessor
	{
		/// <summary>Activates a text service when a user session starts.</summary>
		/// <param name="ptim">Pointer to the ITfThreadMgr interface for the thread manager that owns the text service.</param>
		/// <param name="tid">Specifies the client identifier for the text service.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// <para>
		/// TSF calls this method after creating an instance of a text service with a call to CoCreateInstance. This enables operations
		/// necessary to start the text service.
		/// </para>
		/// <para>
		/// This method usually adds a reference to the thread manager for the session and advise sinks for events that involve the text
		/// service, such as change of focus, keystrokes, and window events. It also customizes the language bar for the text service.
		/// </para>
		/// <para>
		/// The corresponding ITfTextInputProcessor::Deactivate method that shuts down the text service must release all references to
		/// the ptim parameter.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itftextinputprocessor-activate HRESULT Activate(
		// ITfThreadMgr *ptim, TfClientId tid );
		[PreserveSig]
		new HRESULT Activate([In] ITfThreadMgr ptim, [In] TfClientId tid);

		/// <summary>Deactivates a text service when a user session ends.</summary>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// <para>
		/// TSF calls this method immediately before releasing its final reference to a text service. This provides the opportunity to
		/// perform operations necessary to shut down the text service.
		/// </para>
		/// <para>
		/// This method usually unadvises sinks for events that involve the text service. It can also close any user interface elements
		/// of the text service.
		/// </para>
		/// <para>
		/// Before this method returns, it must release all references to the ptim parameter passed to the text service by the
		/// ITfTextInputProcessor::Activate method.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itftextinputprocessor-deactivate HRESULT Deactivate();
		[PreserveSig]
		new HRESULT Deactivate();

		/// <summary>
		/// The <c>ITfTextInputProcessorEx::ActivateEx</c> method activates a text service when a user session starts. If the text
		/// service implements <c>ITfTextInputProcessorEx</c> and <c>ActivateEx</c> is called, ITfTextInputProcessor::Activate will not
		/// be called.
		/// </summary>
		/// <param name="ptim">[in] Pointer to the ITfThreadMgr interface for the thread manager that owns the text service.</param>
		/// <param name="tid">[in] Specifies the client identifier for the text service.</param>
		/// <param name="dwFlags">
		/// <para>[in] The combination of the following bits:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TF_TMAE_SECUREMODE</term>
		/// <term>A text service is activated as secure mode. A text service may not want to show the setting dialog box.</term>
		/// </item>
		/// <item>
		/// <term>TF_TMAE_COMLESS</term>
		/// <term>
		/// A text service is activated as com less mode. TSF was activated without COM. COM may not be initialized or COM may be
		/// initialized as MTA.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TF_TMAE_WOW16</term>
		/// <term>The current thread is 16 bit task.</term>
		/// </item>
		/// <item>
		/// <term>TF_TMAE_CONSOLE</term>
		/// <term>A text service is activated for console usage.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>The TSF manager ignores the return value of this method.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itftextinputprocessorex-activateex HRESULT ActivateEx(
		// ITfThreadMgr *ptim, TfClientId tid, DWORD dwFlags );
		[PreserveSig]
		HRESULT ActivateEx([In] ITfThreadMgr ptim, [In] TfClientId tid, [In] TF_TMAE dwFlags);
	}

	/// <summary>
	/// The <c>ITfTextLayoutSink</c> interface supports the context layout change by an application. Install this advise sink by calling
	/// ITfSource::AdviseSink with IID_ITfTextLayoutSink. A text service can optionally implement this interface.
	/// </summary>
	/// <remarks>TSF does not currently support multiple views; some features of this interface are limited.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-itftextlayoutsink
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.ITfTextLayoutSink")]
	[ComImport, Guid("2AF2D06A-DD5B-4927-A0B4-54F19C91FADE"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ITfTextLayoutSink
	{
		/// <summary>Receives a notification when the layout of a context view changes.</summary>
		/// <param name="pic">Pointer to the ITfContext interface for the context that changed.</param>
		/// <param name="lcode">Specifies the TfLayoutCode element that describes the layout change.</param>
		/// <param name="pView">Pointer to the ITfContextView interface for the context view in that the layout change occurred.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// Each context has a default view for which a reference can be obtained using the ITfContext::GetActiveView method. The method
		/// returns only the value TF_LC_CHANGE for the lcode parameter for this view, because the values are possible only for multiple
		/// views. Because TSF does not support multiple views, this method never receives other values of the <c>TfLayoutCode</c> enumeration.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itftextlayoutsink-onlayoutchange HRESULT OnLayoutChange(
		// ITfContext *pic, TfLayoutCode lcode, ITfContextView *pView );
		[PreserveSig]
		HRESULT OnLayoutChange([In] ITfContext pic, [In] TfLayoutCode lcode, [In] ITfContextView pView);
	}

	/// <summary>
	/// The <c>ITfThreadFocusSink</c> interface is implemented by an application or TSF text service to receive notifications when the
	/// thread receives or loses the UI focus. This advise sink is installed by calling the TSF Manager's ITfSource::AdviseSink with IID_ITfThreadFocusSink.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-itfthreadfocussink
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.ITfThreadFocusSink")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("C0F1DB0C-3A20-405C-A303-96B6010A885F")]
	public interface ITfThreadFocusSink
	{
		/// <summary>Called when the thread receives the UI focus.</summary>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfthreadfocussink-onsetthreadfocus HRESULT OnSetThreadFocus();
		[PreserveSig]
		HRESULT OnSetThreadFocus();

		/// <summary>Called when the thread loses the UI focus.</summary>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfthreadfocussink-onkillthreadfocus HRESULT OnKillThreadFocus();
		[PreserveSig]
		HRESULT OnKillThreadFocus();
	}

	/// <summary>
	/// The <c>ITfThreadMgr</c> defines the primary object implemented by the TSF manager. <c>ITfThreadMgr</c> is used by applications
	/// and text services to activate and deactivate text services, create document managers, and maintain the document context focus.
	/// </summary>
	/// <remarks>
	/// <para>
	/// An application obtains a pointer to this interface by calling CoCreateInstance with CLSID_TF_ThreadMgr as demonstrated below.
	/// </para>
	/// <para>A text service receives a pointer to this interface in its ITfTextInputProcessor::Activate method.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-itfthreadmgr
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.ITfThreadMgr")]
	[ComImport, Guid("AA80E801-2021-11D2-93E0-0060B067B86E"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(TF_ThreadMgr))]
	public interface ITfThreadMgr
	{
		/// <summary>Activates TSF for the calling thread.</summary>
		/// <returns>Pointer to a TfClientId value that receives a client identifier.</returns>
		/// <remarks>
		/// This method can be called more than once from a thread, but each call must be matched with a corresponding call to
		/// ITfThreadMgr::Deactivate from the same thread.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfthreadmgr-activate HRESULT Activate( TfClientId *ptid );
		TfClientId Activate();

		/// <summary>Deactivates TSF for the calling thread.</summary>
		/// <remarks>
		/// Each call to this method must be matched with a previous call to <c>ITfThreadMgr::Activate</c> . This method must be called
		/// from the same thread that the corresponding <c>ITfThreadMgr::Activate</c> call was made from.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfthreadmgr-deactivate HRESULT Deactivate();
		void Deactivate();

		/// <summary>Creates a document manager object.</summary>
		/// <returns>Pointer to an ITfDocumentMgr interface that receives the document manager object.</returns>
		/// <remarks>The caller must release the document manager when it is no longer required.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfthreadmgr-createdocumentmgr HRESULT CreateDocumentMgr(
		// ITfDocumentMgr **ppdim );
		ITfDocumentMgr CreateDocumentMgr();

		/// <summary>Returns an enumerator for all the document managers within the calling thread.</summary>
		/// <returns>Pointer to a IEnumTfDocumentMgrs interface that receives the enumerator.</returns>
		/// <remarks>The caller must release the enumerator when it is no longer required.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfthreadmgr-enumdocumentmgrs HRESULT EnumDocumentMgrs(
		// IEnumTfDocumentMgrs **ppEnum );
		IEnumTfDocumentMgrs EnumDocumentMgrs();

		/// <summary>Returns the document manager that has the input focus.</summary>
		/// <returns>
		/// Pointer to a ITfDocumentMgr interface that receives the document manager with the current input focus. Receives <c>NULL</c>
		/// if no document manager has the focus.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfthreadmgr-getfocus HRESULT GetFocus( ITfDocumentMgr
		// **ppdimFocus );
		ITfDocumentMgr GetFocus();

		/// <summary>Sets the input focus to the specified document manager.</summary>
		/// <param name="pdimFocus">Pointer to a ITfDocumentMgr interface that receives the input focus. This parameter cannot be <c>NULL</c>.</param>
		/// <remarks>
		/// The application must call this method when the document window receives the input focus. If the application associates a
		/// window with a document manager using ITfThreadMgr::AssociateFocus, the TSF manager calls this method for the application.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfthreadmgr-setfocus HRESULT SetFocus( ITfDocumentMgr
		// *pdimFocus );
		void SetFocus([In] ITfDocumentMgr pdimFocus);

		/// <summary>Associates the focus for a window with a document manager object.</summary>
		/// <param name="hwnd">Handle of the window to associate the focus with.</param>
		/// <param name="pdimNew">
		/// Pointer to the document manager to associate the focus with. The TSF manager does not increment the object reference count.
		/// This value can be <c>NULL</c>.
		/// </param>
		/// <returns>
		/// Receives the document manager previously associated with the window. Receives <c>NULL</c> if there is no previous
		/// association. This parameter cannot be <c>NULL</c>.
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method is provided as a convenience to the application developer. Associating the focus for a window with a document
		/// manager causes the TSF manager to automatically call ITfThreadMgr::SetFocus with the associated document manager when the
		/// associated window receives the focus.
		/// </para>
		/// <para>
		/// This method can only associate a single window with a single document manager. If the implementation associates multiple
		/// document managers with a single window, or the opposite, the implementation must call <c>ITfThreadMgr::SetFocus</c> to set
		/// the focus to the proper document manager.
		/// </para>
		/// <para>
		/// To restore the previous focus association, call this method with the same window handle and the value returned in the
		/// original call ppdimPrev for pdimNew. The following is an example.
		/// </para>
		/// <para>
		/// <code> //associate the focus for m_hwnd with m_pDocMgr pThreadMgr-&gt;AssociateFocus(m_hwnd, m_pDocMgr, &amp;m_pPrevDocMgr); //Restore the original focus association. ITfDocumentMgr *pTempDocMgr = NULL; pThreadMgr-&gt;AssociateFocus(m_hwnd, m_pPrevDocMgr, &amp;pTempDocMgr); if(pTempDocMgr) { pTempDocMgr-&gt;Release(); } if(m_pPrevDocMgr) { m_pPrevDocMgr-&gt;Release(); }</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfthreadmgr-associatefocus HRESULT AssociateFocus( HWND
		// hwnd, ITfDocumentMgr *pdimNew, ITfDocumentMgr **ppdimPrev );
		ITfDocumentMgr AssociateFocus([In] HWND hwnd, [In] ITfDocumentMgr pdimNew);

		/// <summary>Determines if the calling thread has the TSF input focus.</summary>
		/// <returns>
		/// Pointer to a BOOL that receives a value that indicates if the calling thread has input focus. This parameter receives a
		/// nonzero value if the calling thread has the focus or zero otherwise.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfthreadmgr-isthreadfocus HRESULT IsThreadFocus( BOOL
		// *pfThreadFocus );
		[return: MarshalAs(UnmanagedType.Bool)]
		bool IsThreadFocus();

		/// <summary>Obtains the specified function provider object.</summary>
		/// <param name="clsid">
		/// <para>
		/// CLSID of the desired function provider. This can be the CLSID of a function provider registered for the calling thread or
		/// one of the following predefined values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>GUID_SYSTEM_FUNCTIONPROVIDER</term>
		/// <term>Obtains the TSF system function provider.</term>
		/// </item>
		/// <item>
		/// <term>GUID_APP_FUNCTIONPROVIDER</term>
		/// <term>
		/// Obtains the function provider implemented by the current application. This object is not available if the application does
		/// not register itself as a function provider.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>Pointer to a ITfFunctionProvider interface that receives the function provider.</returns>
		/// <remarks>A function provider registers by calling the TSF manager ITfSourceSingle::AdviseSingleSink method with IID_ITfFunctionProvider.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfthreadmgr-getfunctionprovider HRESULT
		// GetFunctionProvider( REFCLSID clsid, ITfFunctionProvider **ppFuncProv );
		ITfFunctionProvider GetFunctionProvider(in Guid clsid);

		/// <summary>Obtains an enumerator for all of the function providers registered for the calling thread.</summary>
		/// <returns>Address of a IEnumTfFunctionProviders interface that receives the function provider enumerator.</returns>
		/// <remarks>
		/// <para>
		/// The enumerator only contains the registered function providers. The enumerator will not contain the predefined function
		/// providers as described in ITfThreadMgr::GetFunctionProvider.
		/// </para>
		/// <para>A function provider registers itself by calling the TSF manager ITfSourceSingle::AdviseSingleSink method with IID_ITfFunctionProvider.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfthreadmgr-enumfunctionproviders HRESULT
		// EnumFunctionProviders( IEnumTfFunctionProviders **ppEnum );
		IEnumTfFunctionProviders EnumFunctionProviders();

		/// <summary>Obtains the global compartment manager object.</summary>
		/// <returns>Pointer to a ITfCompartmentMgr interface that receives the global compartment manager.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfthreadmgr-getglobalcompartment HRESULT
		// GetGlobalCompartment( ITfCompartmentMgr **ppCompMgr );
		ITfCompartmentMgr GetGlobalCompartment();
	}

	/// <summary>
	/// The <c>ITfThreadMgr2</c> defines the primary object implemented by the TSF manager. <c>ITfThreadMgr2</c> is used by applications
	/// and text services to activate and deactivate text services, create document managers, and maintain the document context focus.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-itfthreadmgr2
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.ITfThreadMgr2")]
	[ComImport, Guid("0ab198ef-6477-4ee8-8812-6780edb82d5e"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(TF_ThreadMgr))]
	public interface ITfThreadMgr2
	{
		/// <summary>Activates TSF for the calling thread.</summary>
		/// <returns>Pointer to a TfClientId value that receives a client identifier.</returns>
		/// <remarks>
		/// This method can be called more than once from a thread, but each call must be matched with a corresponding call to
		/// ITfThreadMgr::Deactivate from the same thread.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfthreadmgr-activate HRESULT Activate( TfClientId *ptid );
		TfClientId Activate();

		/// <summary>Deactivates TSF for the calling thread.</summary>
		/// <remarks>
		/// Each call to this method must be matched with a previous call to <c>ITfThreadMgr::Activate</c> . This method must be called
		/// from the same thread that the corresponding <c>ITfThreadMgr::Activate</c> call was made from.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfthreadmgr-deactivate HRESULT Deactivate();
		void Deactivate();

		/// <summary>Creates a document manager object.</summary>
		/// <returns>Pointer to an ITfDocumentMgr interface that receives the document manager object.</returns>
		/// <remarks>The caller must release the document manager when it is no longer required.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfthreadmgr-createdocumentmgr HRESULT CreateDocumentMgr(
		// ITfDocumentMgr **ppdim );
		ITfDocumentMgr CreateDocumentMgr();

		/// <summary>Returns an enumerator for all the document managers within the calling thread.</summary>
		/// <returns>Pointer to a IEnumTfDocumentMgrs interface that receives the enumerator.</returns>
		/// <remarks>The caller must release the enumerator when it is no longer required.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfthreadmgr-enumdocumentmgrs HRESULT EnumDocumentMgrs(
		// IEnumTfDocumentMgrs **ppEnum );
		IEnumTfDocumentMgrs EnumDocumentMgrs();

		/// <summary>Returns the document manager that has the input focus.</summary>
		/// <returns>
		/// Pointer to a ITfDocumentMgr interface that receives the document manager with the current input focus. Receives <c>NULL</c>
		/// if no document manager has the focus.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfthreadmgr-getfocus HRESULT GetFocus( ITfDocumentMgr
		// **ppdimFocus );
		ITfDocumentMgr GetFocus();

		/// <summary>Sets the input focus to the specified document manager.</summary>
		/// <param name="pdimFocus">Pointer to a ITfDocumentMgr interface that receives the input focus. This parameter cannot be <c>NULL</c>.</param>
		/// <remarks>
		/// The application must call this method when the document window receives the input focus. If the application associates a
		/// window with a document manager using ITfThreadMgr::AssociateFocus, the TSF manager calls this method for the application.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfthreadmgr-setfocus HRESULT SetFocus( ITfDocumentMgr
		// *pdimFocus );
		void SetFocus([In] ITfDocumentMgr pdimFocus);

		/// <summary>Determines if the calling thread has the TSF input focus.</summary>
		/// <returns>
		/// Pointer to a BOOL that receives a value that indicates if the calling thread has input focus. This parameter receives a
		/// nonzero value if the calling thread has the focus or zero otherwise.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfthreadmgr-isthreadfocus HRESULT IsThreadFocus( BOOL
		// *pfThreadFocus );
		[return: MarshalAs(UnmanagedType.Bool)]
		bool IsThreadFocus();

		/// <summary>Obtains the specified function provider object.</summary>
		/// <param name="clsid">
		/// <para>
		/// CLSID of the desired function provider. This can be the CLSID of a function provider registered for the calling thread or
		/// one of the following predefined values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>GUID_SYSTEM_FUNCTIONPROVIDER</term>
		/// <term>Obtains the TSF system function provider.</term>
		/// </item>
		/// <item>
		/// <term>GUID_APP_FUNCTIONPROVIDER</term>
		/// <term>
		/// Obtains the function provider implemented by the current application. This object is not available if the application does
		/// not register itself as a function provider.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>Pointer to a ITfFunctionProvider interface that receives the function provider.</returns>
		/// <remarks>A function provider registers by calling the TSF manager ITfSourceSingle::AdviseSingleSink method with IID_ITfFunctionProvider.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfthreadmgr-getfunctionprovider HRESULT
		// GetFunctionProvider( REFCLSID clsid, ITfFunctionProvider **ppFuncProv );
		ITfFunctionProvider GetFunctionProvider(in Guid clsid);

		/// <summary>Obtains an enumerator for all of the function providers registered for the calling thread.</summary>
		/// <returns>Address of a IEnumTfFunctionProviders interface that receives the function provider enumerator.</returns>
		/// <remarks>
		/// <para>
		/// The enumerator only contains the registered function providers. The enumerator will not contain the predefined function
		/// providers as described in ITfThreadMgr::GetFunctionProvider.
		/// </para>
		/// <para>A function provider registers itself by calling the TSF manager ITfSourceSingle::AdviseSingleSink method with IID_ITfFunctionProvider.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfthreadmgr-enumfunctionproviders HRESULT
		// EnumFunctionProviders( IEnumTfFunctionProviders **ppEnum );
		IEnumTfFunctionProviders EnumFunctionProviders();

		/// <summary>Obtains the global compartment manager object.</summary>
		/// <returns>Pointer to a ITfCompartmentMgr interface that receives the global compartment manager.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfthreadmgr-getglobalcompartment HRESULT
		// GetGlobalCompartment( ITfCompartmentMgr **ppCompMgr );
		ITfCompartmentMgr GetGlobalCompartment();

		/// <summary>Initializes and activates TSF for the calling thread with a flag that specifies how TSF is activated.</summary>
		/// <param name="ptid">[out] Pointer to a TfClientId value that receives a client identifier.</param>
		/// <param name="dwFlags">
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TF_TMAE_NOACTIVATETIP</term>
		/// <term>
		/// Text services will not be activated while this method is called. They will be activated when the calling thread has focus asynchronously.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TF_TMAE_SECUREMODE</term>
		/// <term>TSF is activated in secure mode. Only text services that support the secure mode will be activated.</term>
		/// </item>
		/// <item>
		/// <term>TF_TMAE_UIELEMENTENABLEDONLY</term>
		/// <term>TSF activates only text services that are categorized in GUID_TFCAT_TIPCAP_UIELEMENTENABLED.</term>
		/// </item>
		/// <item>
		/// <term>TF_TMAE_COMLESS</term>
		/// <term>TSF does not use COM. TSF activate only text services that are categorized in GUID_TFCAT_TIPCAP_COMLESS.</term>
		/// </item>
		/// <item>
		/// <term>TF_TMAE_NOACTIVATEKEYBOARDLAYOUT</term>
		/// <term>
		/// TSF does not sync the current keyboard layout while this method is called. The keyboard layout will be adjusted when the
		/// calling thread gets focus. This flag must be used with TF_TMAE_NOACTIVATETIP.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfthreadmgr2-activateex HRESULT ActivateEx( TfClientId
		// *ptid, DWORD dwFlags );
		void ActivateEx(out TfClientId ptid, [In] TF_TMAE dwFlags);

		/// <summary>Gets the active flags of the calling thread.</summary>
		/// <returns>
		/// <para>The pointer to the DWORD value to receives the active flags of TSF.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TF_TMF_NOACTIVATETIP</term>
		/// <term>TSF was activated with the TF_TMAE_NOACTIVATETIP flag.</term>
		/// </item>
		/// <item>
		/// <term>TF_TMF_SECUREMODE</term>
		/// <term>TSF is running as secure mode.</term>
		/// </item>
		/// <item>
		/// <term>TF_TMF_UIELEMENTENABLEDONLY</term>
		/// <term>TSF is running with text services that support only UIElement.</term>
		/// </item>
		/// <item>
		/// <term>TF_TMF_COMLESS</term>
		/// <term>TSF is running without COM.</term>
		/// </item>
		/// <item>
		/// <term>TF_TMF_WOW16</term>
		/// <term>TSF is running in 16bit task.</term>
		/// </item>
		/// <item>
		/// <term>TF_TMF_CONSOLE</term>
		/// <term>TSF is running for console.</term>
		/// </item>
		/// <item>
		/// <term>TF_TMF_IMMERSIVEMODE</term>
		/// <term>TSF is active in a Windows Store app.</term>
		/// </item>
		/// <item>
		/// <term>TF_TMF_ACTIVATED</term>
		/// <term>TSF is active.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfthreadmgr2-getactiveflags HRESULT GetActiveFlags( DWORD
		// *lpdwFlags );
		TF_TMF GetActiveFlags();

		/// <summary>Suspends handling keystrokes.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfthreadmgr2-suspendkeystrokehandling HRESULT SuspendKeystrokeHandling();
		void SuspendKeystrokeHandling();

		/// <summary>Resumes suspended keystroke handling.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfthreadmgr2-resumekeystrokehandling HRESULT ResumeKeystrokeHandling();
		void ResumeKeystrokeHandling();
	}

	/// <summary>
	/// The <c>ITfThreadMgrEventSink</c> interface is implemented by an application or TSF text service to receive notifications of
	/// certain thread manager events. Call the TSF manager ITfSource::AdviseSink with IID_ITfThreadMgrEventSink to install this advise sink.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-itfthreadmgreventsink
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.ITfThreadMgrEventSink")]
	[ComImport, Guid("AA80E80E-2021-11D2-93E0-0060B067B86E"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ITfThreadMgrEventSink
	{
		/// <summary>Called when the first context is added to the context stack</summary>
		/// <param name="pdim">Pointer to the document manager object.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfthreadmgreventsink-oninitdocumentmgr HRESULT
		// OnInitDocumentMgr( ITfDocumentMgr *pdim );
		[PreserveSig]
		HRESULT OnInitDocumentMgr([In] ITfDocumentMgr pdim);

		/// <summary>Called when the last context is removed from the context stack</summary>
		/// <param name="pdim">Pointer to the document manager object.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfthreadmgreventsink-onuninitdocumentmgr HRESULT
		// OnUninitDocumentMgr( ITfDocumentMgr *pdim );
		[PreserveSig]
		HRESULT OnUninitDocumentMgr([In] ITfDocumentMgr pdim);

		/// <summary>Called when a document view receives or loses the focus</summary>
		/// <param name="pdimFocus">
		/// Pointer to the document manager receiving the input focus. If no document is receiving the focus, this will be <c>NULL</c>.
		/// </param>
		/// <param name="pdimPrevFocus">
		/// Pointer to the document manager that previously had the input focus. If no document had the focus, this will be <c>NULL</c>.
		/// </param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfthreadmgreventsink-onsetfocus HRESULT OnSetFocus(
		// ITfDocumentMgr *pdimFocus, ITfDocumentMgr *pdimPrevFocus );
		[PreserveSig]
		HRESULT OnSetFocus([In] ITfDocumentMgr pdimFocus, [In] ITfDocumentMgr pdimPrevFocus);

		/// <summary>Called when a context is added to the context stack</summary>
		/// <param name="pic">Pointer to the context added to the stack.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfthreadmgreventsink-onpushcontext HRESULT OnPushContext(
		// ITfContext *pic );
		[PreserveSig]
		HRESULT OnPushContext([In] ITfContext pic);

		/// <summary>Called when a context is removed from the context stack</summary>
		/// <param name="pic">Pointer to the context removed from the stack.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfthreadmgreventsink-onpopcontext HRESULT OnPopContext(
		// ITfContext *pic );
		[PreserveSig]
		HRESULT OnPopContext([In] ITfContext pic);
	}

	/// <summary>
	/// The <c>ITfThreadMgrEx</c> interface is used by the application to activate the textservices with some flags. ITfThreadMgrEx can
	/// be obtained by QI from ITfThreadMgr.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-itfthreadmgrex
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.ITfThreadMgrEx")]
	[ComImport, Guid("3E90ADE3-7594-4CB0-BB58-69628F5F458C"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(TF_ThreadMgr))]
	public interface ITfThreadMgrEx : ITfThreadMgr
	{
		/// <summary>Activates TSF for the calling thread.</summary>
		/// <returns>Pointer to a TfClientId value that receives a client identifier.</returns>
		/// <remarks>
		/// This method can be called more than once from a thread, but each call must be matched with a corresponding call to
		/// ITfThreadMgr::Deactivate from the same thread.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfthreadmgr-activate HRESULT Activate( TfClientId *ptid );
		new TfClientId Activate();

		/// <summary>Deactivates TSF for the calling thread.</summary>
		/// <remarks>
		/// Each call to this method must be matched with a previous call to <c>ITfThreadMgr::Activate</c> . This method must be called
		/// from the same thread that the corresponding <c>ITfThreadMgr::Activate</c> call was made from.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfthreadmgr-deactivate HRESULT Deactivate();
		new void Deactivate();

		/// <summary>Creates a document manager object.</summary>
		/// <returns>Pointer to an ITfDocumentMgr interface that receives the document manager object.</returns>
		/// <remarks>The caller must release the document manager when it is no longer required.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfthreadmgr-createdocumentmgr HRESULT CreateDocumentMgr(
		// ITfDocumentMgr **ppdim );
		new ITfDocumentMgr CreateDocumentMgr();

		/// <summary>Returns an enumerator for all the document managers within the calling thread.</summary>
		/// <returns>Pointer to a IEnumTfDocumentMgrs interface that receives the enumerator.</returns>
		/// <remarks>The caller must release the enumerator when it is no longer required.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfthreadmgr-enumdocumentmgrs HRESULT EnumDocumentMgrs(
		// IEnumTfDocumentMgrs **ppEnum );
		new IEnumTfDocumentMgrs EnumDocumentMgrs();

		/// <summary>Returns the document manager that has the input focus.</summary>
		/// <returns>
		/// Pointer to a ITfDocumentMgr interface that receives the document manager with the current input focus. Receives <c>NULL</c>
		/// if no document manager has the focus.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfthreadmgr-getfocus HRESULT GetFocus( ITfDocumentMgr
		// **ppdimFocus );
		new ITfDocumentMgr GetFocus();

		/// <summary>Sets the input focus to the specified document manager.</summary>
		/// <param name="pdimFocus">Pointer to a ITfDocumentMgr interface that receives the input focus. This parameter cannot be <c>NULL</c>.</param>
		/// <remarks>
		/// The application must call this method when the document window receives the input focus. If the application associates a
		/// window with a document manager using ITfThreadMgr::AssociateFocus, the TSF manager calls this method for the application.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfthreadmgr-setfocus HRESULT SetFocus( ITfDocumentMgr
		// *pdimFocus );
		new void SetFocus([In] ITfDocumentMgr pdimFocus);

		/// <summary>Associates the focus for a window with a document manager object.</summary>
		/// <param name="hwnd">Handle of the window to associate the focus with.</param>
		/// <param name="pdimNew">
		/// Pointer to the document manager to associate the focus with. The TSF manager does not increment the object reference count.
		/// This value can be <c>NULL</c>.
		/// </param>
		/// <returns>
		/// Receives the document manager previously associated with the window. Receives <c>NULL</c> if there is no previous
		/// association. This parameter cannot be <c>NULL</c>.
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method is provided as a convenience to the application developer. Associating the focus for a window with a document
		/// manager causes the TSF manager to automatically call ITfThreadMgr::SetFocus with the associated document manager when the
		/// associated window receives the focus.
		/// </para>
		/// <para>
		/// This method can only associate a single window with a single document manager. If the implementation associates multiple
		/// document managers with a single window, or the opposite, the implementation must call <c>ITfThreadMgr::SetFocus</c> to set
		/// the focus to the proper document manager.
		/// </para>
		/// <para>
		/// To restore the previous focus association, call this method with the same window handle and the value returned in the
		/// original call ppdimPrev for pdimNew. The following is an example.
		/// </para>
		/// <para>
		/// <code> //associate the focus for m_hwnd with m_pDocMgr pThreadMgr-&gt;AssociateFocus(m_hwnd, m_pDocMgr, &amp;m_pPrevDocMgr); //Restore the original focus association. ITfDocumentMgr *pTempDocMgr = NULL; pThreadMgr-&gt;AssociateFocus(m_hwnd, m_pPrevDocMgr, &amp;pTempDocMgr); if(pTempDocMgr) { pTempDocMgr-&gt;Release(); } if(m_pPrevDocMgr) { m_pPrevDocMgr-&gt;Release(); }</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfthreadmgr-associatefocus HRESULT AssociateFocus( HWND
		// hwnd, ITfDocumentMgr *pdimNew, ITfDocumentMgr **ppdimPrev );
		new ITfDocumentMgr AssociateFocus([In] HWND hwnd, [In] ITfDocumentMgr pdimNew);

		/// <summary>Determines if the calling thread has the TSF input focus.</summary>
		/// <returns>
		/// Pointer to a BOOL that receives a value that indicates if the calling thread has input focus. This parameter receives a
		/// nonzero value if the calling thread has the focus or zero otherwise.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfthreadmgr-isthreadfocus HRESULT IsThreadFocus( BOOL
		// *pfThreadFocus );
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool IsThreadFocus();

		/// <summary>Obtains the specified function provider object.</summary>
		/// <param name="clsid">
		/// <para>
		/// CLSID of the desired function provider. This can be the CLSID of a function provider registered for the calling thread or
		/// one of the following predefined values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>GUID_SYSTEM_FUNCTIONPROVIDER</term>
		/// <term>Obtains the TSF system function provider.</term>
		/// </item>
		/// <item>
		/// <term>GUID_APP_FUNCTIONPROVIDER</term>
		/// <term>
		/// Obtains the function provider implemented by the current application. This object is not available if the application does
		/// not register itself as a function provider.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>Pointer to a ITfFunctionProvider interface that receives the function provider.</returns>
		/// <remarks>A function provider registers by calling the TSF manager ITfSourceSingle::AdviseSingleSink method with IID_ITfFunctionProvider.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfthreadmgr-getfunctionprovider HRESULT
		// GetFunctionProvider( REFCLSID clsid, ITfFunctionProvider **ppFuncProv );
		new ITfFunctionProvider GetFunctionProvider(in Guid clsid);

		/// <summary>Obtains an enumerator for all of the function providers registered for the calling thread.</summary>
		/// <returns>Address of a IEnumTfFunctionProviders interface that receives the function provider enumerator.</returns>
		/// <remarks>
		/// <para>
		/// The enumerator only contains the registered function providers. The enumerator will not contain the predefined function
		/// providers as described in ITfThreadMgr::GetFunctionProvider.
		/// </para>
		/// <para>A function provider registers itself by calling the TSF manager ITfSourceSingle::AdviseSingleSink method with IID_ITfFunctionProvider.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfthreadmgr-enumfunctionproviders HRESULT
		// EnumFunctionProviders( IEnumTfFunctionProviders **ppEnum );
		new IEnumTfFunctionProviders EnumFunctionProviders();

		/// <summary>Obtains the global compartment manager object.</summary>
		/// <returns>Pointer to a ITfCompartmentMgr interface that receives the global compartment manager.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfthreadmgr-getglobalcompartment HRESULT
		// GetGlobalCompartment( ITfCompartmentMgr **ppCompMgr );
		new ITfCompartmentMgr GetGlobalCompartment();

		/// <summary>
		/// The <c>ITfThreadMgrEx::ActivateEx</c> method is used by an application to initialize and activate TSF for the calling
		/// thread. Unlike ITfThreadMgr::Activate, ITfThreadMgrEx::ActivateEx can take a flag to specify how TSF is activated.
		/// </summary>
		/// <param name="ptid">[out] Pointer to a TfClientId value that receives a client identifier.</param>
		/// <param name="dwFlags">
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TF_TMAE_NOACTIVATETIP</term>
		/// <term>
		/// Text services will not be activated while ITfThreadMgrEx::ActivateEx is called. They will be activated when the calling
		/// thread has focus asynchronously.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TF_TMAE_SECUREMODE</term>
		/// <term>TSF is activated in secure mode. Only text services that support the secure mode will be activated.</term>
		/// </item>
		/// <item>
		/// <term>TF_TMAE_UIELEMENTENABLEDONLY</term>
		/// <term>TSF activates only text services that are categorized in GUID_TFCAT_TIPCAP_UIELEMENTENABLED.</term>
		/// </item>
		/// <item>
		/// <term>TF_TMAE_COMLESS</term>
		/// <term>TSF does not use COM. TSF activate only text services that are categorized in GUID_TFCAT_TIPCAP_COMLESS.</term>
		/// </item>
		/// <item>
		/// <term>TF_TMAE_NOACTIVATEKEYBOARDLAYOUT</term>
		/// <term>
		/// TSF does not sync the current keyboard layout while ITfThreadMgrEx::ActivateEx() is called. The keyboard layout will be
		/// adjusted when the calling thread gets focus. This flag must be used with TF_TMAE_NOACTIVATETIP.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfthreadmgrex-activateex HRESULT ActivateEx( TfClientId
		// *ptid, DWORD dwFlags );
		void ActivateEx(out TfClientId ptid, [In] TF_TMAE dwFlags);

		/// <summary>The <c>ITfThreadMgrEx::GetActiveFlags</c> method returns the flags TSF is active with.</summary>
		/// <returns>
		/// <para>The pointer to the DWORD value to receives the active flags of TSF.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TF_TMF_NOACTIVATETIP</term>
		/// <term>TSF was activated with the TF_TMAE_NOACTIVATETIP flag.</term>
		/// </item>
		/// <item>
		/// <term>TF_TMF_SECUREMODE</term>
		/// <term>TSF is running as secure mode.</term>
		/// </item>
		/// <item>
		/// <term>TF_TMF_UIELEMENTENABLEDONLY</term>
		/// <term>TSF is running with text services that support only UIElement.</term>
		/// </item>
		/// <item>
		/// <term>TF_TMF_COMLESS</term>
		/// <term>TSF is running without COM.</term>
		/// </item>
		/// <item>
		/// <term>TF_TMF_WOW16</term>
		/// <term>TSF is running in 16bit task.</term>
		/// </item>
		/// <item>
		/// <term>TF_TMF_CONSOLE</term>
		/// <term>TSF is running for console.</term>
		/// </item>
		/// <item>
		/// <term>TF_TMF_ACTIVATED</term>
		/// <term>TSF is active.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfthreadmgrex-getactiveflags HRESULT GetActiveFlags( DWORD
		// *lpdwFlags );
		TF_TMF GetActiveFlags();
	}

	/// <summary>
	/// The <c>ITfToolTipUIElement</c> interface is implemented by a text service that wants to show a tooltip on its UI. A fullscreen
	/// application which wants to draw all UI by itself may want to draw the tooltip also or it can just hide the tooltip or of course
	/// it can let the text service show it. However, it does not guarantee that a text service can show the tooltip correctly when
	/// other UI are asked to be hidden.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-itftooltipuielement
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.ITfToolTipUIElement")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("52B18B5C-555D-46B2-B00A-FA680144FBDB")]
	public interface ITfToolTipUIElement : ITfUIElement
	{
		/// <summary>The <c>ITfUIElement::GetDescription</c> method returns the description of the UI element.</summary>
		/// <param name="pbstrDescription">[in] A pointer to BSTR that contains the description of the UI element.</param>
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
		/// <term>One or more parameters are invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfuielement-getdescription HRESULT GetDescription( BSTR
		// *pbstrDescription );
		[PreserveSig]
		new HRESULT GetDescription([Out, MarshalAs(UnmanagedType.BStr)] out string pbstrDescription);

		/// <summary>The <c>ITfUIElement::GetGUID</c> method returns the unique id of this UI element.</summary>
		/// <param name="pguid">[out] A pointer to receive the GUID of the UI element.</param>
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
		/// <term>One or more parameters are invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfuielement-getguid HRESULT GetGUID( GUID *pguid );
		[PreserveSig]
		new HRESULT GetGUID(out Guid pguid);

		/// <summary>The <c>ITfUIElement::Show</c> method shows the text service's UI of this UI element.</summary>
		/// <param name="bShow">
		/// [in] <c>TRUE</c> to show the original UI of the element. <c>FALSE</c> to hide the original UI of the element.
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
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfuielement-show HRESULT Show( BOOL bShow );
		[PreserveSig]
		new HRESULT Show([In, MarshalAs(UnmanagedType.Bool)] bool bShow);

		/// <summary>
		/// The <c>ITfUIElement::IsShown</c> method returns true if the UI is currently shown by a text service; otherwise false.
		/// </summary>
		/// <param name="pbShow">[out] A pointer to bool of the current show status of the original UI of this element.</param>
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
		/// <term>One or more parameters are invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfuielement-isshown HRESULT IsShown( BOOL *pbShow );
		[PreserveSig]
		new HRESULT IsShown([Out, MarshalAs(UnmanagedType.Bool)] out bool pbShow);

		/// <summary>Returns the string of the tooltip.</summary>
		/// <param name="pstr">[out] A pointer to receive BSTR. This is the string for the tooltip.</param>
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
		/// <term>One or more parameters are invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itftooltipuielement-getstring HRESULT GetString( BSTR *pstr );
		[PreserveSig]
		HRESULT GetString([Out, MarshalAs(UnmanagedType.BStr)] out string pstr);
	}

	/// <summary>
	/// The <c>ITfTransitoryExtensionSink</c> interface is implemented by the application that uses Transitory Extension dim. The
	/// application can track the changes that happened in the transitory extension by using this sink interface.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-itftransitoryextensionsink
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.ITfTransitoryExtensionSink")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("A615096F-1C57-4813-8A15-55EE6E5A839C")]
	public interface ITfTransitoryExtensionSink
	{
		/// <summary>Transitory Document has been updated.</summary>
		/// <param name="pic">[in] A pointer of ITfContext interface. This is a context object in which the update happened.</param>
		/// <param name="ecReadOnly">
		/// [in] A read only edit cookie to access the pic. Using this edit cookie, the application can get the text that is contained
		/// in the context object.
		/// </param>
		/// <param name="pResultRange">
		/// [in] A pointer of the ITfRange interface. This is the range of the result string (determined string).
		/// </param>
		/// <param name="pCompositionRange">
		/// [in] A pointer of the ITfRange interface. This is the range of the current composition string.
		/// </param>
		/// <param name="pfDeleteResultRange">
		/// [out] A pointer to return the bool value. If it is true, TSF manager deletes the result range so only the current
		/// composition range remains in the transitory extension.
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
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itftransitoryextensionsink-ontransitoryextensionupdated
		// HRESULT OnTransitoryExtensionUpdated( ITfContext *pic, TfEditCookie ecReadOnly, ITfRange *pResultRange, ITfRange
		// *pCompositionRange, BOOL *pfDeleteResultRange );
		[PreserveSig]
		HRESULT OnTransitoryExtensionUpdated([In] ITfContext pic, [In] TfEditCookie ecReadOnly, [In] ITfRange pResultRange, [In] ITfRange pCompositionRange,
			[Out, MarshalAs(UnmanagedType.Bool)] out bool pfDeleteResultRange);
	}

	/// <summary>
	/// The <c>ITfTransitoryExtensionUIElement</c> interface is implemented by TSF manager which provides the UI of transitory
	/// extension. The application that is in UILess mode will use this interface to determine if the original UI should be shown or the
	/// content of this UI should be drown by the application.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-itftransitoryextensionuielement
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.ITfTransitoryExtensionUIElement")]
	[ComImport, Guid("858F956A-972F-42A2-A2F2-0321E1ABE209"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ITfTransitoryExtensionUIElement : ITfUIElement
	{
		/// <summary>The <c>ITfUIElement::GetDescription</c> method returns the description of the UI element.</summary>
		/// <param name="pbstrDescription">[in] A pointer to BSTR that contains the description of the UI element.</param>
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
		/// <term>One or more parameters are invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfuielement-getdescription HRESULT GetDescription( BSTR
		// *pbstrDescription );
		[PreserveSig]
		new HRESULT GetDescription([Out, MarshalAs(UnmanagedType.BStr)] out string pbstrDescription);

		/// <summary>The <c>ITfUIElement::GetGUID</c> method returns the unique id of this UI element.</summary>
		/// <param name="pguid">[out] A pointer to receive the GUID of the UI element.</param>
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
		/// <term>One or more parameters are invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfuielement-getguid HRESULT GetGUID( GUID *pguid );
		[PreserveSig]
		new HRESULT GetGUID(out Guid pguid);

		/// <summary>The <c>ITfUIElement::Show</c> method shows the text service's UI of this UI element.</summary>
		/// <param name="bShow">
		/// [in] <c>TRUE</c> to show the original UI of the element. <c>FALSE</c> to hide the original UI of the element.
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
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfuielement-show HRESULT Show( BOOL bShow );
		[PreserveSig]
		new HRESULT Show([In, MarshalAs(UnmanagedType.Bool)] bool bShow);

		/// <summary>
		/// The <c>ITfUIElement::IsShown</c> method returns true if the UI is currently shown by a text service; otherwise false.
		/// </summary>
		/// <param name="pbShow">[out] A pointer to bool of the current show status of the original UI of this element.</param>
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
		/// <term>One or more parameters are invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfuielement-isshown HRESULT IsShown( BOOL *pbShow );
		[PreserveSig]
		new HRESULT IsShown([Out, MarshalAs(UnmanagedType.Bool)] out bool pbShow);

		/// <summary>
		/// The <c>ITfTransitoryExtensionUIElement::GetDocumentMgr</c> method returns the pointer of the transitory document manager.
		/// </summary>
		/// <param name="ppdim">
		/// [out] A pointer to receive the ITfDocumentMgr interface pointer. This document manager object contains a context object that
		/// has the ITfContext interface and contains the text of the transitory extension.
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
		/// <term>One or more parameters are invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itftransitoryextensionuielement-getdocumentmgr HRESULT
		// GetDocumentMgr( ITfDocumentMgr **ppdim );
		[PreserveSig]
		HRESULT GetDocumentMgr(out ITfDocumentMgr ppdim);
	}

	/// <summary>The ITfUIElement interface is a base interface of the UIElement object and is implemented by a text service.</summary>
	/// <remarks>
	/// A text service may implement some other UIElement interface such as ITfCandidateListUIElement in the same object that can be
	/// obtained by QI. A text service may implement only the <c>ITfUIElement</c> interface to a UI object that does not have to be
	/// drawn by the application but the show status can be controlled by the application. A text service that is categorized by
	/// GUID_TFCAT_TIPCAP_UIELEMENTENABLED needs to implement ITfUIElement for any UI object.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-itfuielement
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.ITfUIElement")]
	[ComImport, Guid("EA1EA137-19DF-11D7-A6D2-00065B84435C"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ITfUIElement
	{
		/// <summary>The <c>ITfUIElement::GetDescription</c> method returns the description of the UI element.</summary>
		/// <param name="pbstrDescription">[in] A pointer to BSTR that contains the description of the UI element.</param>
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
		/// <term>One or more parameters are invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfuielement-getdescription HRESULT GetDescription( BSTR
		// *pbstrDescription );
		[PreserveSig]
		HRESULT GetDescription([Out, MarshalAs(UnmanagedType.BStr)] out string pbstrDescription);

		/// <summary>The <c>ITfUIElement::GetGUID</c> method returns the unique id of this UI element.</summary>
		/// <param name="pguid">[out] A pointer to receive the GUID of the UI element.</param>
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
		/// <term>One or more parameters are invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfuielement-getguid HRESULT GetGUID( GUID *pguid );
		[PreserveSig]
		HRESULT GetGUID(out Guid pguid);

		/// <summary>The <c>ITfUIElement::Show</c> method shows the text service's UI of this UI element.</summary>
		/// <param name="bShow">
		/// [in] <c>TRUE</c> to show the original UI of the element. <c>FALSE</c> to hide the original UI of the element.
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
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfuielement-show HRESULT Show( BOOL bShow );
		[PreserveSig]
		HRESULT Show([In, MarshalAs(UnmanagedType.Bool)] bool bShow);

		/// <summary>
		/// The <c>ITfUIElement::IsShown</c> method returns true if the UI is currently shown by a text service; otherwise false.
		/// </summary>
		/// <param name="pbShow">[out] A pointer to bool of the current show status of the original UI of this element.</param>
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
		/// <term>One or more parameters are invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfuielement-isshown HRESULT IsShown( BOOL *pbShow );
		[PreserveSig]
		HRESULT IsShown([Out, MarshalAs(UnmanagedType.Bool)] out bool pbShow);
	}

	/// <summary>
	/// The <c>ITfUIElementMgr</c> interface is implemented by TSF manager and used by an application or a text service. An application
	/// and a text service can obtain this interface by ITfThreadMgr::QueryInterface with IID_ITfUIElementMgr.
	/// </summary>
	/// <remarks>
	/// A text service that supports UIElement must call <c>ITfUIElementMgr</c> whenever the UI is shown, updated or hidden. Then the
	/// application can control the visibility of the UI.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-itfuielementmgr
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.ITfUIElementMgr")]
	[ComImport, Guid("EA1EA135-19DF-11D7-A6D2-00065B84435C"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ITfUIElementMgr
	{
		/// <summary>
		/// The <c>ITfUIElementMgr::BeginUIElement</c> method is called by a text service before showing UI. The value returned
		/// determines whether the UI for the text service should be shown or not.
		/// </summary>
		/// <param name="pElement">[in] A pointer to the ITfUIElement interface of the UIElement object.</param>
		/// <param name="pbShow">
		/// [in, out] If false is returned, the application may draw the UI by itself and a text service does not show its own UI for
		/// this UI element.
		/// </param>
		/// <param name="pdwUIElementId">[out] A pointer to receive the ID of this UI element.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfuielementmgr-beginuielement HRESULT BeginUIElement(
		// ITfUIElement *pElement, BOOL *pbShow, DWORD *pdwUIElementId );
		void BeginUIElement([In] ITfUIElement pElement, [Out, MarshalAs(UnmanagedType.Bool)] out bool pbShow, out uint pdwUIElementId);

		/// <summary>The <c>ITfUIElementMgr::UpdateUIElement</c> method is called by a text service when the UI element must be updated.</summary>
		/// <param name="dwUIElementId">[in] The element id to update the UI element.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfuielementmgr-updateuielement HRESULT UpdateUIElement(
		// DWORD dwUIElementId );
		void UpdateUIElement(uint dwUIElementId);

		/// <summary>The <c>ITfUIElementMgr::EndUIElement</c> method is called by a text service when the element of UI is hidden.</summary>
		/// <param name="dwUIElementId">[in] The element id to hide the UI element.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfuielementmgr-enduielement HRESULT EndUIElement( DWORD
		// dwUIElementId );
		void EndUIElement(uint dwUIElementId);

		/// <summary>The <c>ITfUIElementMgr::GetUIElement</c> method gets the ITfUIElement interface of the element id.</summary>
		/// <param name="dwUIELementId">[in] The element id to get the ITfUIElement interface.</param>
		/// <returns>[out] A pointer to receive ITfUIElement interface.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfuielementmgr-getuielement HRESULT GetUIElement( DWORD
		// dwUIELementId, ITfUIElement **ppElement );
		ITfUIElement GetUIElement(uint dwUIELementId);

		/// <summary>
		/// The <c>ITfUIElementMgr::EnumUIElements</c> method returns IEnumTfUIElements interface pointer to enumerate the ITfUIElement.
		/// </summary>
		/// <returns>[in] A pointer to receive the IEnumTfUIElements interface.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfuielementmgr-enumuielements HRESULT EnumUIElements(
		// IEnumTfUIElements **ppEnum );
		IEnumTfUIElements EnumUIElements();
	}

	/// <summary>
	/// The <c>ITfUIElementSink</c> interface is implemented by an application to receive notifications when the UI element is changed.
	/// </summary>
	/// <remarks>
	/// To install this advise sink, obtain an ITfSource object from an ITfUIElementMgr object by calling
	/// <c>ITfUIElementMgr::QueryInterface</c> with IID_ ITfSource. Then call ITfSource::AdviseSink with IID_ ITfUIElementSink.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-itfuielementsink
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.ITfUIElementSink")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("EA1EA136-19DF-11D7-A6D2-00065B84435C")]
	public interface ITfUIElementSink
	{
		/// <summary>
		/// The <c>ITfUIElementSink::BeginUIElement</c> method is called when the UIElement started. This sink can let the textservice
		/// to draw or not to draw the UI element.
		/// </summary>
		/// <param name="dwUIElementId">[in] Id of the UIElement that was started.</param>
		/// <param name="pbShow">
		/// [in, out] Return <c>true</c> if the application does not draw the UIElement content and the text service draws its original
		/// UI content. Return <c>false</c> if the application draws the UIElement's content and stops the text service from drawing it.
		/// The application can get the ITfUIElement interface by using ITfUIElementMgr::GetUIElement and it can evaluate if it can
		/// handle the UIElement by QI with <c>IID_ITfCandidateListUIElement</c> or with other UIElement interfaces. The application can
		/// always return <c>FALSE</c> if it is unknown or it cannot be handled. In this case, the text service will not show any extra
		/// UI on the screen. This is a good way for some full screen applications. Alternatively, the application can return
		/// <c>TRUE</c> to use TextService's UI on some particular or unknown UIs.
		/// </param>
		/// <returns>
		/// <para>The TSF manager ignores the return value of this method.</para>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfuielementsink-beginuielement HRESULT BeginUIElement(
		// DWORD dwUIElementId, BOOL *pbShow );
		[PreserveSig]
		HRESULT BeginUIElement(uint dwUIElementId, [MarshalAs(UnmanagedType.Bool)] out bool pbShow);

		/// <summary>The <c>ITfUIElementSink::UpdateUIElement</c> method is called when the contents of the UIElement is updated.</summary>
		/// <param name="dwUIElementId">[in] Id of the UIElement that has had its content updated.</param>
		/// <returns>The TSF manager ignores the return value of this method.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfuielementsink-updateuielement HRESULT UpdateUIElement(
		// DWORD dwUIElementId );
		[PreserveSig]
		HRESULT UpdateUIElement(uint dwUIElementId);

		/// <summary>The <c>ITfUIElementSink::EndUIElement</c> method is called when the UIElement is finished.</summary>
		/// <param name="dwUIElementId">[in] Id of the UIElement that is finished.</param>
		/// <returns>The TSF manager ignores the return value of this method.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfuielementsink-enduielement HRESULT EndUIElement( DWORD
		// dwUIElementId );
		[PreserveSig]
		HRESULT EndUIElement(uint dwUIElementId);
	}

	/// <summary>Obtains a list of the installed languages.</summary>
	/// <param name="ipp">The interface.</param>
	/// <returns>The array of identifiers of the currently installed languages.</returns>
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.ITfInputProcessorProfiles")]
	public static LANGID[] GetLanguageList(this ITfInputProcessorProfiles ipp)
	{
		ipp.GetLanguageList(out InteropServices.SafeCoTaskMemHandle mem, out var c);
		return mem.ToArray<LANGID>((int)c);
	}

	/// <summary>CLSID_TF_CategoryMgr</summary>
	[PInvokeData("msctf.h")]
	[ComImport, Guid("a4b544a1-438d-4b41-9325-869523e2d6c7"), ClassInterface(ClassInterfaceType.None)]
	public class TF_CategoryMgr
	{
	}

	/// <summary>CLSID_TF_DisplayAttributeMgr</summary>
	[PInvokeData("msctf.h")]
	[ComImport, Guid("3ce74de4-53d3-4d74-8b83-431b3828ba53"), ClassInterface(ClassInterfaceType.None)]
	public class TF_DisplayAttributeMgr
	{
	}

	/// <summary>CLSID_TF_InputProcessorProfiles</summary>
	[PInvokeData("msctf.h")]
	[ComImport, Guid("33c53a50-f456-4884-b049-85fd643ecfed"), ClassInterface(ClassInterfaceType.None)]
	public class TF_InputProcessorProfiles
	{
	}

	/// <summary>CLSID_TF_LangBarItemMgr</summary>
	[PInvokeData("msctf.h")]
	[ComImport, Guid("b9931692-a2b3-4fab-bf33-9ec6f9fb96ac"), ClassInterface(ClassInterfaceType.None)]
	public class TF_LangBarItemMgr
	{
	}

	/// <summary>CLSID_TF_LangBarMgr</summary>
	[PInvokeData("msctf.h")]
	[ComImport, Guid("ebb08c45-6c4a-4fdc-ae53-4eb8c4c7db8e"), ClassInterface(ClassInterfaceType.None)]
	public class TF_LangBarMgr
	{
	}

	/// <summary>CLSID_TF_ThreadMgr</summary>
	[PInvokeData("msctf.h")]
	[ComImport, Guid("529a9e6b-6587-4f23-ab9e-9c7d683e3c50"), ClassInterface(ClassInterfaceType.None)]
	public class TF_ThreadMgr
	{
	}
}