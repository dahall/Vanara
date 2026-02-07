using System.Runtime.InteropServices.ComTypes;
using static Vanara.PInvoke.Ole32;

using HKL = System.IntPtr;
using LPARAM = System.IntPtr;
using TfClientId = System.UInt32;
using TfEditCookie = System.UInt32;
using WPARAM = System.IntPtr;

namespace Vanara.PInvoke;

public static partial class MSCTF
{
	/// <summary>
	/// The <c>ITfContextOwnerServices</c> interface is implemented by the manager and used by a text service or application acting as
	/// context owners. The interface provides notification changes to sinks and other services to context owners that do not implement
	/// the ITextStoreACP or ITextStoreAnchor interfaces. Clients obtain this interface by calling the ITfContext::QueryInterface method.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-itfcontextownerservices
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.ITfContextOwnerServices")]
	[ComImport, Guid("B23EB630-3E1C-11D3-A745-0050040AB407"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ITfContextOwnerServices
	{
		/// <summary>
		/// The <c>ITfContextOwnerServices::OnLayoutChange</c> method is called by the context owner when the on-screen representation
		/// of the text stream is updated during a composition. Text stream updates include when the position of the window that
		/// contains the text is changed or if the screen coordinates of the text change.
		/// </summary>
		/// <remarks>
		/// <para>
		/// A call to <c>ITfContextOwnerServices::OnLayoutChange</c> could be in response to a text edit, font size change, window
		/// movement/resizing, and so on.
		/// </para>
		/// <para>
		/// If a call to ITfContextView::GetTextExt or ITfContextOwner::GetACPFromPoint fails because the application did not calculate
		/// the screen layout (Return Value: TS_E_NOLAYOUT), the application must then call
		/// <c>ITfContextOwnerServices::OnLayoutChange</c> when the information is ready.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcontextownerservices-onlayoutchange HRESULT OnLayoutChange();
		void OnLayoutChange();

		/// <summary>
		/// The <c>ITfContextOwnerServices::OnStatusChange</c> method is called by the context owner when the <c>dwDynamicFlags</c>
		/// member of the <see cref="TS_STATUS"/> structure returned by the ITfContextOwner::GetStatus method changes.
		/// </summary>
		/// <param name="dwFlags">Specifies the dynamic status flag.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcontextownerservices-onstatuschange HRESULT
		// OnStatusChange( DWORD dwFlags );
		void OnStatusChange(TS_SD dwFlags);

		/// <summary>Called by a context owner to generate notifications that a support attribute value changed.</summary>
		/// <param name="rguidAttribute">Specifies the GUID of the support attribute.</param>
		/// <remarks>
		/// A support attribute is a read-only property maintained by the context owner. The supported attributes are in the Tsattrs.h
		/// header file.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcontextownerservices-onattributechange HRESULT
		// OnAttributeChange( REFGUID rguidAttribute );
		void OnAttributeChange(in Guid rguidAttribute);

		/// <summary>
		/// The <c>ITfContextOwnerServices::Serialize</c> method obtains a property from a range of text and writes the property data
		/// into a stream object. This enables an application to store property data, for example, when writing the data to a file.
		/// </summary>
		/// <param name="pProp">Pointer to an ITfProperty interface that identifies the property to serialize.</param>
		/// <param name="pRange">Pointer to an ITfRange interface that identifies the range that the property is obtained from.</param>
		/// <param name="pHdr">Pointer to a TF_PERSISTENT_PROPERTY_HEADER_ACP structure that receives the header data for the property.</param>
		/// <param name="pStream">Pointer to an <c>IStream</c> object that the TSF manager will write the property data to.</param>
		/// <remarks>
		/// <para>
		/// The property header data placed in pHdr is common to all properties and must be preserved with the data written into
		/// pStream. This same data pair must be passed to ITfContextOwnerServices::Unserialize to restore the property data.
		/// </para>
		/// <para>An application can save all of the properties for the entire document by performing the following steps.</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Enumerate all properties using ITfContext::EnumProperties.</term>
		/// </item>
		/// <item>
		/// <term>Within each property, enumerate the ranges using ITfReadOnlyProperty::EnumRanges.</term>
		/// </item>
		/// <item>
		/// <term>Pass the current property and range to this method.</term>
		/// </item>
		/// <item>
		/// <term>Write the data placed in pHdr to the file.</term>
		/// </item>
		/// <item>
		/// <term>Write the data added to pStream to the file.</term>
		/// </item>
		/// </list>
		/// <para>When calling this method, the application must be able to grant a synchronous read-only lock.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcontextownerservices-serialize HRESULT Serialize(
		// ITfProperty *pProp, ITfRange *pRange, TF_PERSISTENT_PROPERTY_HEADER_ACP *pHdr, IStream *pStream );
		void Serialize([In] ITfProperty pProp, [In] ITfRange pRange, out TF_PERSISTENT_PROPERTY_HEADER_ACP pHdr, [In] IStream pStream);

		/// <summary>Applies previously serialized property data to a property object.</summary>
		/// <param name="pProp">Pointer to an ITfProperty object that receives the property data.</param>
		/// <param name="pHdr">Pointer to a TF_PERSISTENT_PROPERTY_HEADER_ACP structure that contains the header data for the property.</param>
		/// <param name="pStream">
		/// Pointer to an <c>IStream</c> object that contains the property data. This parameter can be <c>NULL</c> if pLoader is not
		/// <c>NULL</c>. This parameter is ignored if pLoader is not <c>NULL</c>.
		/// </param>
		/// <param name="pLoader">
		/// Pointer to an ITfPersistentPropertyLoaderACP object that the TSF manager uses to obtain the property data. This parameter
		/// can be <c>NULL</c> if pStream is not <c>NULL</c>.
		/// </param>
		/// <remarks>
		/// <para>
		/// If pStream is specified rather than pLoader, the property data is read from pStream during the call to this method. If
		/// pLoader is specified rather than pStream, the property data is read from pLoader asynchronously. Using pStream can cause
		/// long delays if the property data is large.
		/// </para>
		/// <para>When calling this method, the application must be able to grant a synchronous read-only lock.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcontextownerservices-unserialize HRESULT Unserialize(
		// ITfProperty *pProp, const TF_PERSISTENT_PROPERTY_HEADER_ACP *pHdr, IStream *pStream, ITfPersistentPropertyLoaderACP *pLoader );
		void Unserialize([In] ITfProperty pProp, in TF_PERSISTENT_PROPERTY_HEADER_ACP pHdr, [In, Optional] IStream? pStream,
			[In, Optional] ITfPersistentPropertyLoaderACP? pLoader);

		/// <summary>Forces a property load.</summary>
		/// <param name="pProp">Pointer to an ITfProperty object that specifies the property to load.</param>
		/// <remarks>The application must be able to grant a synchronous read-only lock before calling this method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcontextownerservices-forceloadproperty HRESULT
		// ForceLoadProperty( ITfProperty *pProp );
		void ForceLoadProperty([In] ITfProperty pProp);

		/// <summary>
		/// The <c>ITfContextOwnerServices::CreateRange</c> method creates a new ranged based upon a specified character position.
		/// </summary>
		/// <param name="acpStart">Specifies the starting character position of the range.</param>
		/// <param name="acpEnd">Specifies the ending character position of the range.</param>
		/// <returns>Receives a pointer to the range object within the specified starting and ending character positions.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcontextownerservices-createrange HRESULT CreateRange(
		// LONG acpStart, LONG acpEnd, ITfRangeACP **ppRange );
		ITfRangeACP CreateRange(int acpStart, int acpEnd);
	}

	/// <summary>
	/// The <c>ITfContextView</c> interface is implemented by the TSF manager and used by a client (application or text service) to
	/// obtain information about a context view. Clients obtain this interface by calling the ITfContext::GetActiveView method which
	/// returns a pointer to the <c>ITfContextView</c> object.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-itfcontextview
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.ITfContextView")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("2433BF8E-0F9B-435C-BA2C-180611978C30")]
	public interface ITfContextView
	{
		/// <summary>
		/// The <c>ITfContextView::GetRangeFromPoint</c> method converts a point, in screen coordinates, to an empty range of text
		/// positioned at a corresponding location.
		/// </summary>
		/// <param name="ec">Specifies the edit cookie with read-only access.</param>
		/// <param name="ppt">Specifies the point in screen coordinates.</param>
		/// <param name="dwFlags">
		/// <para>
		/// Specifies the range position to return based upon the screen coordinates of the point to a character bounding box. By
		/// default, the range position returned is the character bounding box containing the screen coordinates of the point. If the
		/// point is outside a character bounding box, the method returns <c>NULL</c> or TF_E_INVALIDPOINT. Other bit flags for this
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
		/// If the screen coordinates of the point are contained in a character bounding box, the range position returned is the
		/// bounding edge closest to the screen coordinates of the point.
		/// </term>
		/// </item>
		/// <item>
		/// <term>GXFPF_NEAREST</term>
		/// <term>
		/// If the screen coordinates of the point are not contained in a character bounding box, the closest range position is returned.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>Receives a pointer to the ITfRange interface.</returns>
		/// <remarks>
		/// By default, the method will return a range positioned at 0 for point 1 and TF_E_INVALIDPOINT for point 2. If the dwFlags
		/// parameter is set to GXFPF_ROUND_NEAREST, the method returns range position 1 for point 1. If the dwFlags parameter is set to
		/// GXFPF_NEAREST then the method returns range position 2 for point 2.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcontextview-getrangefrompoint HRESULT GetRangeFromPoint(
		// TfEditCookie ec, const POINT *ppt, DWORD dwFlags, ITfRange **ppRange );
		ITfRange? GetRangeFromPoint([In] TfEditCookie ec, in POINT ppt, GXFPF dwFlags);

		/// <summary>
		/// The <c>ITfContextView::GetTextExt</c> method returns the bounding box, in screen coordinates, of a range of text.
		/// </summary>
		/// <param name="ec">Specifies an edit cookie with read-only access.</param>
		/// <param name="pRange">Specifies the range to query</param>
		/// <param name="prc">Receives the bounding box, in screen coordinates, of the range.</param>
		/// <param name="pfClipped">
		/// Receives the Boolean value that specifies if the text in the bounding box has been clipped. If this parameter is
		/// <c>TRUE</c>, the bounding box contains clipped text and does not include the entire requested range. The bounding box is
		/// clipped because of the requested range is not visible.
		/// </param>
		/// <remarks>
		/// If the document window is minimized, or if the specified text is not currently visible, the method returns S_OK with the prc
		/// parameter set to {0,0,0,0}.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcontextview-gettextext HRESULT GetTextExt( TfEditCookie
		// ec, ITfRange *pRange, RECT *prc, BOOL *pfClipped );
		void GetTextExt([In] TfEditCookie ec, [In] ITfRange pRange, out RECT prc, [Out, MarshalAs(UnmanagedType.Bool)] out bool pfClipped);

		/// <summary>
		/// The <c>ITfContextView::GetScreenExt</c> method returns the bounding box, in screen coordinates, of the document display.
		/// </summary>
		/// <returns>Receives the bounding box, in screen coordinates, of the display surface.</returns>
		/// <remarks>The prc parameter is cleared to {0,0,0,0} if the document is not currently displayed.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcontextview-getscreenext HRESULT GetScreenExt( RECT *prc );
		RECT GetScreenExt();

		/// <summary>The <c>ITfContextView::GetWnd</c> method returns the handle to a window that corresponds to the current document.</summary>
		/// <returns>Receives a pointer to the handle of the window that corresponds to the current document.</returns>
		/// <remarks>
		/// A document might not have a corresponding window handle if the document is in memory but not displayed on the screen or if
		/// the document is a windowless control and the control does not have the window handle of the owner of the windowless
		/// controls. Callers cannot assume that the phwnd parameter will receive a non- <c>NULL</c> value even if the method is
		/// successful. Callers can also receive a <c>NULL</c> value for the phwnd parameter.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcontextview-getwnd HRESULT GetWnd( HWND *phwnd );
		HWND GetWnd();
	}

	/// <summary>
	/// The <c>ITfCreatePropertyStore</c> interface is implemented by a text service to support persistence of property store data. The
	/// TSF manager uses this interface to determine if a property store can be serialized and to create a property store object for a
	/// serialized property.
	/// </summary>
	/// <remarks>
	/// When a property store is unserialized, the TSF manager creates an object from the CLSID obtained from
	/// ITfPropertyStore::GetPropertyRangeCreator and obtain an <c>ITfCreatePropertyStore</c> interface pointer from it. The manager
	/// then uses <c>ITfCreatePropertyStore::CreatePropertyStore</c> to create the property store object.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-itfcreatepropertystore
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.ITfCreatePropertyStore")]
	[ComImport, Guid("2463FBF0-B0AF-11D2-AFC5-00105A2799B5"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ITfCreatePropertyStore
	{
		/// <summary>Determines if a property store can be stored as persistent data.</summary>
		/// <param name="guidProp">Contains the type identifier of the property. For more information, see ITfPropertyStore::GetType.</param>
		/// <param name="pRange">Pointer to an ITfRange object that contains the text covered by the property store.</param>
		/// <param name="pPropStore">Pointer to the ITfPropertyStore object.</param>
		/// <param name="pfSerializable">
		/// Pointer to a <c>BOOL</c> that receives a flag that indicates if the property store can be serialized. Receives nonzero if
		/// the property store can be serialized or zero otherwise.
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
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcreatepropertystore-isstoreserializable HRESULT
		// IsStoreSerializable( REFGUID guidProp, ITfRange *pRange, ITfPropertyStore *pPropStore, BOOL *pfSerializable );
		[PreserveSig]
		HRESULT IsStoreSerializable(in Guid guidProp, [In] ITfRange pRange, [In] ITfPropertyStore pPropStore, [Out, MarshalAs(UnmanagedType.Bool)] out bool pfSerializable);

		/// <summary>Creates a property store object from serialized property store data.</summary>
		/// <param name="guidProp">Contains the type identifier of the property. For more information, see ITfPropertyStore::GetType.</param>
		/// <param name="pRange">Pointer to an ITfRange object that contains the text to be covered by the property store.</param>
		/// <param name="cb">Contains the size, in bytes, of the property store data contained in pStream.</param>
		/// <param name="pStream">Pointer to an <c>IStream</c> object that contains the property store data.</param>
		/// <param name="ppStore">
		/// Pointer to an ITfPropertyStore interface pointer that receives the property store object created by this method.
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
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcreatepropertystore-createpropertystore HRESULT
		// CreatePropertyStore( REFGUID guidProp, ITfRange *pRange, ULONG cb, IStream *pStream, ITfPropertyStore **ppStore );
		[PreserveSig]
		HRESULT CreatePropertyStore(in Guid guidProp, [In] ITfRange pRange, uint cb, [In] IStream pStream, out ITfPropertyStore ppStore);
	}

	/// <summary>
	/// The <c>ITfDisplayAttributeInfo</c> interface is implemented by a text service to provide display attribute data. This interface
	/// is used by any component, most often an application, that must determine how text displays.
	/// </summary>
	/// <remarks>
	/// <para>An application obtains an instance of this interface by calling ITfDisplayAttributeMgr::GetDisplayAttributeInfo or IEnumTfDisplayAttributeInfo::Next.</para>
	/// <para>A text service supplies an instance of this interface in its ITfDisplayAttributeProvider::GetDisplayAttributeInfo method.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-itfdisplayattributeinfo
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.ITfDisplayAttributeInfo")]
	[ComImport, Guid("70528852-2F26-4AEA-8C96-215150578932"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ITfDisplayAttributeInfo
	{
		/// <summary>Obtains the GUID for the display attribute.</summary>
		/// <param name="pguid">Pointer to a GUID value that receives the GUID for the display attribute.</param>
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
		/// <term>pguid is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfdisplayattributeinfo-getguid HRESULT GetGUID( GUID
		// *pguid );
		[PreserveSig]
		HRESULT GetGUID(out Guid pguid);

		/// <summary>Obtains the description string of the display attribute.</summary>
		/// <param name="pbstrDesc">
		/// Pointer to a BSTR value that receives the description string. This value must be allocated using SysAllocString. The caller
		/// must free this memory using SysFreeString when it is no longer required.
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
		/// <term>pbstrDesc is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfdisplayattributeinfo-getdescription HRESULT
		// GetDescription( BSTR *pbstrDesc );
		[PreserveSig]
		HRESULT GetDescription([Out, MarshalAs(UnmanagedType.BStr)] out string pbstrDesc);

		/// <summary>Obtains the display attribute data.</summary>
		/// <param name="pda">Pointer to a TF_DISPLAYATTRIBUTE structure that receives display attribute data.</param>
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
		/// <term>pda is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfdisplayattributeinfo-getattributeinfo HRESULT
		// GetAttributeInfo( TF_DISPLAYATTRIBUTE *pda );
		[PreserveSig]
		HRESULT GetAttributeInfo(out TF_DISPLAYATTRIBUTE pda);

		/// <summary>Sets the new attribute data.</summary>
		/// <param name="pda">Pointer to a TF_DISPLAYATTRIBUTE structure that contains the new display attribute data.</param>
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
		/// <term>The display attribute provider does not support attribute modification.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>pda is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// The implementation of this method should not call ITfDisplayAttributeMgr::OnUpdateInfo in response to this method. The
		/// caller must do so. This avoids redundant notifications if more than one attribute is modified. The caller must eventually
		/// call <c>ITfDisplayAttributeMgr::OnUpdateInfo</c> so that other clients will receive an attribute update notification.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfdisplayattributeinfo-setattributeinfo HRESULT
		// SetAttributeInfo( const TF_DISPLAYATTRIBUTE *pda );
		[PreserveSig]
		HRESULT SetAttributeInfo(in TF_DISPLAYATTRIBUTE pda);

		/// <summary>Resets the display attribute data to its default value.</summary>
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
		/// <term>The display attribute provider does not support attribute modification.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// The implementation of this method should not call ITfDisplayAttributeMgr::OnUpdateInfo in response to this method. The
		/// caller must do so. This avoids redundant notifications if more than one attribute is modified. The caller must eventually
		/// call <c>ITfDisplayAttributeMgr::OnUpdateInfo</c> so that other clients will receive an attribute update notification.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfdisplayattributeinfo-reset HRESULT Reset();
		[PreserveSig]
		HRESULT Reset();
	}

	/// <summary>
	/// The <c>ITfDisplayAttributeMgr</c> interface is implemented by the TSF manager and used by an application to obtain and enumerate
	/// display attributes. Individual display attributes are accessed through the ITfDisplayAttributeInfo interface.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-itfdisplayattributemgr
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.ITfDisplayAttributeMgr")]
	[ComImport, Guid("8DED7393-5DB1-475C-9E71-A39111B0FF67"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(TF_DisplayAttributeMgr))]
	public interface ITfDisplayAttributeMgr
	{
		/// <summary>Called when a display attribute is changed.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfdisplayattributemgr-onupdateinfo HRESULT OnUpdateInfo();
		void OnUpdateInfo();

		/// <summary>Obtains a display attribute enumerator object.</summary>
		/// <returns>Pointer to an IEnumTfDisplayAttributeInfo interface pointer that receives the enumerator object.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfdisplayattributemgr-enumdisplayattributeinfo HRESULT
		// EnumDisplayAttributeInfo( IEnumTfDisplayAttributeInfo **ppEnum );
		IEnumTfDisplayAttributeInfo EnumDisplayAttributeInfo();

		/// <summary>Obtains a display attribute data object.</summary>
		/// <param name="guid">
		/// Contains a GUID that identifies the display attribute data requested. This value is obtained by obtaining the
		/// GUID_PROP_ATTRIBUTE property for the range of text. For more information, see ITfContext::GetProperty and ITfContext::TrackProperties.
		/// </param>
		/// <param name="ppInfo">Pointer to an ITfDisplayAttributeInfo interface pointer that receives the object.</param>
		/// <param name="pclsidOwner">
		/// Pointer to a CLSID value that receives the CLSID of the display attribute provider. This parameter can be <c>NULL</c> if the
		/// CLSID is not required.
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfdisplayattributemgr-getdisplayattributeinfo HRESULT
		// GetDisplayAttributeInfo( REFGUID guid, ITfDisplayAttributeInfo **ppInfo, CLSID *pclsidOwner );
		void GetDisplayAttributeInfo(in Guid guid, out ITfDisplayAttributeInfo ppInfo, [NullAllowed] out Guid pclsidOwner);
	}

	/// <summary>
	/// The <c>ITfDisplayAttributeNotifySink</c> interface is implemented by an application to receive a notification when display
	/// attribute information is updated. This advise sink is installed by calling the TSF manager's ITfSource::AdviseSink with IID_ITfDisplayAttributeNotifySink.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-itfdisplayattributenotifysink
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.ITfDisplayAttributeNotifySink")]
	[ComImport, Guid("AD56F402-E162-4F25-908F-7D577CF9BDA9"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ITfDisplayAttributeNotifySink
	{
		/// <summary>Called when display attribute information is updated.</summary>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfdisplayattributenotifysink-onupdateinfo HRESULT OnUpdateInfo();
		[PreserveSig]
		HRESULT OnUpdateInfo();
	}

	/// <summary>
	/// <para>
	/// The <c>ITfDisplayAttributeProvider</c> interface is implemented by a text service and is used by the TSF manager to enumerate
	/// and obtain individual display attribute information objects.
	/// </para>
	/// <para>
	/// The TSF manager obtains an instance of this interface by calling CoCreateInstance with the class identifier passed to
	/// ITfCategoryMgr::RegisterCategory with GUID_TFCAT_DISPLAYATTRIBUTEPROVIDER and IID_ITfDisplayAttributeProvider. For more
	/// information, see Providing Display Attributes.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-itfdisplayattributeprovider
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.ITfDisplayAttributeProvider")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("FEE47777-163C-4769-996A-6E9C50AD8F54")]
	public interface ITfDisplayAttributeProvider
	{
		/// <summary>Obtains an enumerator that contains all display attribute info objects supported by the display attribute provider.</summary>
		/// <param name="ppEnum">
		/// Pointer to an IEnumTfDisplayAttributeInfo interface pointer that receives the enumerator object. The caller must release
		/// this interface when it is no longer required.
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
		/// <term>ppEnum is invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>A memory allocation failure occurred.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfdisplayattributeprovider-enumdisplayattributeinfo
		// HRESULT EnumDisplayAttributeInfo( IEnumTfDisplayAttributeInfo **ppEnum );
		[PreserveSig]
		HRESULT EnumDisplayAttributeInfo(out IEnumTfDisplayAttributeInfo ppEnum);

		/// <summary>Obtains a display attribute provider object for a particular display attribute.</summary>
		/// <param name="guid">
		/// Contains a GUID value that identifies the display attribute to obtain the display attribute information object for. The text
		/// service must publish these values and what they indicate. This identifier can also be obtained by enumerating the display
		/// attributes for a range of text.
		/// </param>
		/// <param name="ppInfo">
		/// Pointer to an ITfDisplayAttributeInfo interface pointer that receives the display attribute information object.
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
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>A memory allocation failure occurred.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfdisplayattributeprovider-getdisplayattributeinfo HRESULT
		// GetDisplayAttributeInfo( REFGUID guid, ITfDisplayAttributeInfo **ppInfo );
		[PreserveSig]
		HRESULT GetDisplayAttributeInfo(in Guid guid, out ITfDisplayAttributeInfo? ppInfo);
	}

	/// <summary>
	/// The <c>ITfDocumentMgr</c> interface is implemented by the TSF manager and used by an application or text service to create and
	/// manage text contexts. To obtain an instance of this interface call ITfThreadMgr::CreateDocumentMgr.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-itfdocumentmgr
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.ITfDocumentMgr")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("AA80E7F4-2021-11D2-93E0-0060B067B86E")]
	public interface ITfDocumentMgr
	{
		/// <summary>Creates a context object.</summary>
		/// <param name="tidOwner">
		/// The client identifier. For an application, this value is provided by a previous call to ITfThreadMgr::Activate. For a text
		/// service, this value is provided in the text service ITfTextInputProcessor::Activate method.
		/// </param>
		/// <param name="dwFlags">Reserved, must be zero.</param>
		/// <param name="punk">
		/// Pointer to an object that supports the ITextStoreACP or ITfContextOwnerCompositionSink interfaces. This value can be <c>NULL</c>.
		/// </param>
		/// <param name="ppic">Address of an ITfContext pointer that receives the context.</param>
		/// <param name="pecTextStore">
		/// Pointer to a TfEditCookie value that receives an edit cookie for the new context. This value identifies the context in
		/// various methods.
		/// </param>
		/// <remarks>
		/// All references to the punk parameter are released when the context is destroyed or when the context is removed from the
		/// stack with the ITfDocumentMgr::Pop method.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfdocumentmgr-createcontext HRESULT CreateContext(
		// TfClientId tidOwner, DWORD dwFlags, IUnknown *punk, ITfContext **ppic, TfEditCookie *pecTextStore );
		void CreateContext([In] TfClientId tidOwner, [Optional] uint dwFlags, [In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? punk, out ITfContext ppic, out TfEditCookie pecTextStore);

		/// <summary>Adds a context to the top of the context stack.</summary>
		/// <param name="pic">
		/// Pointer to the ITfContext object to be added to the stack. This object is obtained from a previous call to ITfDocumentMgr::CreateContext.
		/// </param>
		/// <remarks>
		/// <para>The first context added to the stack becomes the main document context.</para>
		/// <para>
		/// The TSF manager and text services only interact with the context at the top of the stack. Normally, only the main document
		/// context is on the stack. Occasionally, it is necessary to add a second context to the stack. For example, when a text
		/// service must display a modal UI, such as a candidate list. During this time, the text service will add its context to the
		/// stack. When the text service UI is no longer required, the text service removes the context from the stack. The main context
		/// then returns to the top of the stack. To simplify this process and prevent multiple modal UIs from being displayed, there is
		/// a maximum of two contexts allowed on the stack.
		/// </para>
		/// <para>
		/// This method causes the ITfThreadMgrEventSink::OnPushContext method of all installed thread manager event sinks to be called.
		/// If this is the first context to be added to the stack, this method causes the ITfThreadMgrEventSink::OnInitDocumentMgr
		/// method of all installed thread manager event sinks to be called.
		/// </para>
		/// <para>ITfDocumentMgr::Pop must be called to remove this context from the context stack.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfdocumentmgr-push HRESULT Push( ITfContext *pic );
		void Push([In] ITfContext pic);

		/// <summary>Removes the context from the top of the context stack.</summary>
		/// <param name="dwFlags">
		/// If this value is 0, only the context at the top of the stack is removed. If this value is TF_POPF_ALL, all of the contexts
		/// are removed from the stack.
		/// </param>
		/// <remarks>
		/// <para>This method must be called from the same thread as the corresponding ITfDocumentMgr::Push call.</para>
		/// <para>
		/// The first context added to the stack becomes the primary context. The primary context cannot be removed from the stack
		/// without using the TF_POPF_ALL flag. When the document is uninitialized, this method should be called with the TF_POPF_ALL
		/// flag. This causes the document manager to remove all contexts from the context stack and terminate any text service UI. Do
		/// not use the TF_POPF_ALL flag at any other time.
		/// </para>
		/// <para>
		/// This method causes the ITfThreadMgrEventSink::OnPopContext method of all installed thread manager event sinks to be called.
		/// If the last context is removed from the stack, this method causes the ITfThreadMgrEventSink::OnUninitDocumentMgr method of
		/// all installed thread manager event sinks to be called.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfdocumentmgr-pop HRESULT Pop( DWORD dwFlags );
		void Pop([In] TF_POPF dwFlags);

		/// <summary>Obtains the context at the top of the context stack.</summary>
		/// <returns>Address of an ITfContext pointer that receives the context.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfdocumentmgr-gettop HRESULT GetTop( ITfContext **ppic );
		ITfContext GetTop();

		/// <summary>Obtains the context at the base of the context stack.</summary>
		/// <returns>Address of an ITfContext pointer that receives the context.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfdocumentmgr-getbase HRESULT GetBase( ITfContext **ppic );
		ITfContext GetBase();

		/// <summary>Obtains a context enumerator.</summary>
		/// <returns>Address of an IEnumTfContexts pointer that receives the enumerator.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfdocumentmgr-enumcontexts HRESULT EnumContexts(
		// IEnumTfContexts **ppEnum );
		IEnumTfContexts EnumContexts();
	}

	/// <summary>
	/// The <c>ITfEditRecord</c> interface is implemented by the TSF manager and is used by a text edit sink to determine what was
	/// changed during an edit session. An instance of this interface is passed to the text edit sink when the
	/// ITfTextEditSink::OnEndEdit method is called.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-itfeditrecord
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.ITfEditRecord")]
	[ComImport, Guid("42D4D099-7C1A-4A89-B836-6C6F22160DF0"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ITfEditRecord
	{
		/// <summary>Determines if the selection has changed during the edit session.</summary>
		/// <returns>
		/// Pointer to a <c>BOOL</c> value that receives a value that indicates if the selection changed due to an edit session.
		/// Receives a nonzero value if the selection changed or zero otherwise.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfeditrecord-getselectionstatus HRESULT
		// GetSelectionStatus( BOOL *pfChanged );
		[return: MarshalAs(UnmanagedType.Bool)]
		bool GetSelectionStatus();

		/// <summary>
		/// Obtains an enumerator that contains a collection of range objects that cover the specified properties and/or text that
		/// changed during the edit session.
		/// </summary>
		/// <param name="dwFlags">
		/// <para>Contains a combination of the following values that specify the behavior of this method.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>
		/// Specifies that the method will obtain a collection of range objects that cover the specified properties changed during the
		/// edit session. prgProperties cannot be NULL and cProperties must be greater than zero.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TF_GTP_INCL_TEXT</term>
		/// <term>
		/// Specifies that the method will obtain the collection of range objects that cover the text changed during the edit session.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="prgProperties">
		/// <para>
		/// Pointer to an array of <c>GUID</c> values that identify the properties to search for changes for. This method searches the
		/// properties that changed during the edit session and, if the property is contained in this array, a range object that covers
		/// the property that changed is added to ppEnum.
		/// </para>
		/// <para>This array must be at least cProperties elements in size.</para>
		/// <para>This parameter is ignored if dwFlags contains TF_GTP_INCL_TEXT and cProperties is zero.</para>
		/// </param>
		/// <param name="cProperties">
		/// <para>Specifies the number of elements in the prgProperties array.</para>
		/// <para>This parameter can be zero if dwFlags contains TF_GTP_INCL_TEXT. This indicates that no property changes are obtained.</para>
		/// </param>
		/// <returns>Pointer to an IEnumTfRanges interface pointer that receives the enumerator object.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfeditrecord-gettextandpropertyupdates HRESULT
		// GetTextAndPropertyUpdates( DWORD dwFlags, const GUID **prgProperties, ULONG cProperties, IEnumTfRanges **ppEnum );
		IEnumTfRanges GetTextAndPropertyUpdates([In] TF_GTP dwFlags, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] Guid[]? prgProperties, [In, Optional] uint cProperties);
	}

	/// <summary>
	/// The <c>ITfEditSession</c> interface is implemented by a text service and used by the TSF manager to read and/or modify the text
	/// and properties of a context.
	/// </summary>
	/// <remarks>
	/// <para>
	/// A text service initiates an edit session by calling ITfContext::RequestEditSession, passing a pointer to the
	/// <c>ITfEditSession</c> interface. When the edit session is granted, the TSF manager calls <c>DoEditSession</c>.
	/// </para>
	/// <para>
	/// If the context is destroyed before the application grants a lock, or if the calling text service is deactivated before a lock is
	/// granted, the <c>DoEditSession</c> method is not called. For this reason, a text service should put cleanup operations for an
	/// edit session in the <c>ITfEditSession</c> interface destructor rather than in the <c>DoEditSession</c> method.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-itfeditsession
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.ITfEditSession")]
	[ComImport, Guid("AA80E803-2021-11D2-93E0-0060B067B86E"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ITfEditSession
	{
		/// <summary>Called to enable a text service to read and/or modify the contents of a context.</summary>
		/// <param name="ec">
		/// Contains a TfEditCookie value that uniquely identifies the edit session. This cookie is used to access the context with
		/// methods such as ITfRange::GetText.
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
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfeditsession-doeditsession HRESULT DoEditSession(
		// TfEditCookie ec );
		[PreserveSig]
		HRESULT DoEditSession([In] TfEditCookie ec);
	}

	/// <summary>
	/// The <c>ITfEditTransactionSink</c> interface is implemented by a text service and used by the TSF manager to support edit
	/// transactions. An edit transaction is a series of edits that use multiple document locks. A text service can optionally implement
	/// this interface. This advise sink is installed by calling ITfSource::AdviseSink with IID_ITfEditTransactionSink.
	/// </summary>
	/// <remarks>
	/// An edit transaction involves multiple document locks, and usually includes multiple ITfTextEditSink::OnEndEdit method callbacks.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-itfedittransactionsink
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.ITfEditTransactionSink")]
	[ComImport, Guid("708FBF70-B520-416B-B06C-2C41AB44F8BA"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ITfEditTransactionSink
	{
		/// <summary>Indicates the start of an edit transaction.</summary>
		/// <param name="pic">Pointer to the ITfContext interface involved in the transaction.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// The TSF manager calls this method at the start of an edit transaction. A text service might delay reevaluation of the
		/// changing context of the transaction due to the multiple ITfTextEditSink::OnEndEdit notifications until after receiving the
		/// corresponding ITfEditTransactionSink::OnEndEditTransaction callback.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfedittransactionsink-onstartedittransaction HRESULT
		// OnStartEditTransaction( ITfContext *pic );
		[PreserveSig]
		HRESULT OnStartEditTransaction([In] ITfContext pic);

		/// <summary>Indicates the end of an edit transaction.</summary>
		/// <param name="pic">Pointer to the ITfContext interface involved in the transaction.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// The TSF manager calls this method at the end of an edit transaction. A text service can delay reevaluation of the changing
		/// context of the transaction due to the multiple ITfTextEditSink::OnEndEdit method notifications until after receiving this callback.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfedittransactionsink-onendedittransaction HRESULT
		// OnEndEditTransaction( ITfContext *pic );
		[PreserveSig]
		HRESULT OnEndEditTransaction([In] ITfContext pic);
	}

	/// <summary>
	/// The <c>ITfFunctionProvider</c> interface is implemented by an application or text service to provide various function objects.
	/// </summary>
	/// <remarks>
	/// A function provider is registered by calling ITFSourceSingle::AdviseSingleSink with IID_ITfFunctionProvider when the text
	/// service is activated. The text service should unregister its function provider with ITFSourceSingle::UnadviseSingleSink when it
	/// is deactivated.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-itffunctionprovider
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.ITfFunctionProvider")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("101D6610-0990-11D3-8DF0-00105A2799B5")]
	public interface ITfFunctionProvider
	{
		/// <summary>Obtains the type identifier for the function provider.</summary>
		/// <param name="pguid">Pointer to a GUID value that receives the type identifier of the function provider.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>pguid is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itffunctionprovider-gettype HRESULT GetType( GUID *pguid );
		[PreserveSig]
		HRESULT GetType(out Guid pguid);

		/// <summary>Obtains the description of the function provider.</summary>
		/// <param name="pbstrDesc">
		/// Pointer to a BSTR that receives the description string. This value must be allocated using SysAllocString. The caller must
		/// this memory using SysFreeString when it is no longer required.
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
		/// <term>E_OUTOFMEMORY</term>
		/// <term>A memory allocation failure occurred.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>pbstrDesc is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itffunctionprovider-getdescription HRESULT GetDescription(
		// BSTR *pbstrDesc );
		[PreserveSig]
		HRESULT GetDescription([Out, MarshalAs(UnmanagedType.BStr)] out string? pbstrDesc);

		/// <summary>Obtains the specified function object.</summary>
		/// <param name="rguid">
		/// Contains a GUID value that identifies the function group that the requested function belongs to. This value can be GUID_NULL.
		/// </param>
		/// <param name="riid">
		/// Contains an interface identifier that identifies the requested function within the group specified by rguid. This value can
		/// be specified by the application, text service, or one of the IID_ITfFn* values.
		/// </param>
		/// <param name="ppunk">Pointer to an <c>IUnknown</c> interface pointer that receives the requested function interface.</param>
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
		/// <term>E_NOINTERFACE</term>
		/// <term>The requested function is unsupported.</term>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itffunctionprovider-getfunction HRESULT GetFunction(
		// REFGUID rguid, REFIID riid, IUnknown **ppunk );
		[PreserveSig]
		HRESULT GetFunction(in Guid rguid, in Guid riid, [Out, MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object? ppunk);
	}

	/// <summary>
	/// The <c>ITfInputProcessorProfileActivationSink</c> interface is implemented by an application to receive notifications when the
	/// profile changes.
	/// </summary>
	/// <remarks>
	/// To install this advise sink, obtain an ITfSource object from an ITfThreadMgr object by calling
	/// <c>ITfThreadMgr::QueryInterface</c> with <c>IID_ ITfSource</c>. Then call ITfSource::AdviseSink with <c>IID_ITfInputProcessorProfileActivationSink</c>.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-itfinputprocessorprofileactivationsink
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.ITfInputProcessorProfileActivationSink")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("71C6E74E-0F28-11D8-A82A-00065B84435C")]
	public interface ITfInputProcessorProfileActivationSink
	{
		/// <summary>
		/// The ITfInputProcessorProfileActivationSink::OnActivated method is a callback that is called when an input processor profile
		/// is activated or deactivated.
		/// </summary>
		/// <param name="dwProfileType">
		/// <para>[in] The type of this profile. This is one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TF_PROFILETYPE_INPUTPROCESSOR</term>
		/// <term>This is a text service.</term>
		/// </item>
		/// <item>
		/// <term>TF_PROFILETYPE_KEYBOARDLAYOUT</term>
		/// <term>This is a keyboard layout.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="langid">[in] Specifies the language id of the profile.</param>
		/// <param name="clsid">
		/// [in] Specifies the CLSID of the text service. If dwProfileType is TF_PROFILETYPE_KEYBOARDLAYOUT, this is CLSID_NULL.
		/// </param>
		/// <param name="catid">
		/// [in] Specifies the category of this text service. This category is GUID_TFCAT_TIP_KEYBOARD, GUID_TFCAT_TIP_SPEECH,
		/// GUID_TFCAT_TIP_HANDWRITING or something in GUID_TFCAT_CATEGORY_OF_TIP. If dwProfileType is TF_PROFILETYPE_KEYBOARDLAYOUT,
		/// this is GUID_NULL.
		/// </param>
		/// <param name="guidProfile">
		/// [in] Specifies the GUID to identify the profile. If dwProfileType is TF_PROFILETYPE_KEYBOARDLAYOUT, this is GUID_NULL.
		/// </param>
		/// <param name="hkl">
		/// [in] Specifies the keyboard layout handle of this profile. If dwProfileType is TF_PROFILETYPE_ INPUTPROCESSOR, this is <c>NULL</c>.
		/// </param>
		/// <param name="dwFlags">
		/// <para>[in]</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TF_IPSINK_FLAG_ACTIVE</term>
		/// <term>This is on if this profile is activated.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>The TSF manager ignores the return value of this method.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfinputprocessorprofileactivationsink-onactivated HRESULT
		// OnActivated( DWORD dwProfileType, LANGID langid, REFCLSID clsid, REFGUID catid, REFGUID guidProfile, HKL hkl, DWORD dwFlags );
		[PreserveSig]
		HRESULT OnActivated([In] TF_PROFILETYPE dwProfileType, [In] LANGID langid, in Guid clsid, in Guid catid, in Guid guidProfile, [In, Optional] HKL hkl, [In] TF_IPSINK_FLAG dwFlags);
	}

	/// <summary>
	/// The <c>ITfInputProcessorProfileMgr</c> interface is implemented by the TSF manager and used by an application or text service to
	/// manipulate the language profile of one or more text services.
	/// </summary>
	/// <remarks>
	/// <para>
	/// Unlike ITfInputProcessorProfiles, ITfInputProcessorProfileMgr can manage both keyboard layout and text services seamlessly. In
	/// Windows Vista, it is recommended to use this interface instead of using the following methods:
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-itfinputprocessorprofilemgr
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.ITfInputProcessorProfileMgr")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("71C6E74C-0F28-11D8-A82A-00065B84435C"), CoClass(typeof(TF_InputProcessorProfiles))]
	public interface ITfInputProcessorProfileMgr
	{
		/// <summary>
		/// The <c>ITfInputProcessorProfileMgr::ActivateProfile</c> method activates the specified text service's profile or keyboard layout.
		/// </summary>
		/// <param name="dwProfileType">
		/// <para>[in] The type of this profile. This is one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TF_PROFILETYPE_INPUTPROCESSOR</term>
		/// <term>This is a text service.</term>
		/// </item>
		/// <item>
		/// <term>TF_PROFILETYPE_KEYBOARDLAYOUT</term>
		/// <term>This is a keyboard layout.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="langid">[in] The language id of the profile to be activated.</param>
		/// <param name="clsid">
		/// [in] The CLSID of the text service of the profile to be activated. This must be CLSID_NULL if dwProfileType is TF_PROFILETYPE_KEYBOARDLAYOUT.
		/// </param>
		/// <param name="guidProfile">
		/// [in] The guidProfile of the profile to be activated. This must be GUID_NULL if dwProfileType is TF_PROFILETYPE_KEYBOARDLAYOUT.
		/// </param>
		/// <param name="hkl">[in] The handle of the keyboard layout. This must be <c>NULL</c> if dwProfileType is TF_PROFILETYPE_INPUTPROCESSOR.</param>
		/// <param name="dwFlags">
		/// <para>The combination of the following bits:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TF_IPPMF_FORPROCESS</term>
		/// <term>Activate this profile for all threads in the process.</term>
		/// </item>
		/// <item>
		/// <term>TF_IPPMF_FORSESSION</term>
		/// <term>Activate this profile for all threads in the current desktop.</term>
		/// </item>
		/// <item>
		/// <term>TF_IPPMF_ENABLEPROFILE</term>
		/// <term>Update the registry to enable this profile for this user.</term>
		/// </item>
		/// <item>
		/// <term>TF_IPPMF_DISABLEPROFILE</term>
		/// <term/>
		/// </item>
		/// <item>
		/// <term>TF_IPPMF_DONTCARECURRENTINPUTLANGUAGE</term>
		/// <term>
		/// If the current input language does not match with the requested profile's language, TSF marks this profile to be activated
		/// when the requested input language is switched. If this flag is off and the current input language is not matched, this
		/// method fails.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfinputprocessorprofilemgr-activateprofile HRESULT
		// ActivateProfile( DWORD dwProfileType, LANGID langid, REFCLSID clsid, REFGUID guidProfile, HKL hkl, DWORD dwFlags );
		void ActivateProfile([In] TF_PROFILETYPE dwProfileType, [In] LANGID langid, in Guid clsid, in Guid guidProfile, [In, Optional] HKL hkl, [In] TF_IPPMF dwFlags);

		/// <summary>
		/// The <c>ITfInputProcessorProfileMgr::DeactivateProfile</c> method deactivates the specified text service's profile or
		/// keyboard layout.
		/// </summary>
		/// <param name="dwProfileType">
		/// <para>[in] The type of this profile. This is one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TF_PROFILETYPE_INPUTPROCESSOR</term>
		/// <term>This is a text service.</term>
		/// </item>
		/// <item>
		/// <term>TF_PROFILETYPE_KEYBOARDLAYOUT</term>
		/// <term>This is a keyboard layout.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="langid">[in] The language id of the profile to be activated.</param>
		/// <param name="clsid">
		/// [in] The CLSID of the text service of the profile to be activated. This must be CLSID_NULL if dwProfileType is TF_PROFILETYPE_KEYBOARDLAYOUT.
		/// </param>
		/// <param name="guidProfile">
		/// [in] The guidProfile of the profile to be activated. This must be GUID_NULL if dwProfileType is TF_PROFILETYPE_KEYBOARDLAYOUT.
		/// </param>
		/// <param name="hkl">[in] The handle of the keyboard layout. This must be <c>NULL</c> if dwProfileType is TF_PROFILETYPE_INPUTPROCESSOR.</param>
		/// <param name="dwFlags">
		/// <para>The combination of the following bits:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TF_IPPMF_FORPROCESS</term>
		/// <term>Deactivate this profile for all threads in the process.</term>
		/// </item>
		/// <item>
		/// <term>TF_IPPMF_FORSESSION</term>
		/// <term>Deactivate this profile for all threads in the current desktop.</term>
		/// </item>
		/// <item>
		/// <term>TF_IPPMF_DISABLEPROFILE</term>
		/// <term/>
		/// </item>
		/// </list>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfinputprocessorprofilemgr-deactivateprofile HRESULT
		// DeactivateProfile( DWORD dwProfileType, LANGID langid, REFCLSID clsid, REFGUID guidProfile, HKL hkl, DWORD dwFlags );
		void DeactivateProfile([In] TF_PROFILETYPE dwProfileType, [In] LANGID langid, in Guid clsid, in Guid guidProfile, [In, Optional] HKL hkl, [In] TF_IPPMF dwFlags);

		/// <summary>
		/// The <c>ITfInputProcessorProfileMgr::GetProfile</c> method returns the information of the specified text service's profile or
		/// keyboard layout in TF_INPUTPROCESSORPROFILE structure.
		/// </summary>
		/// <param name="dwProfileType">
		/// <para>[in] The type of this profile. This is one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TF_PROFILETYPE_INPUTPROCESSOR</term>
		/// <term>This is a text service.</term>
		/// </item>
		/// <item>
		/// <term>TF_PROFILETYPE_KEYBOARDLAYOUT</term>
		/// <term>This is a keyboard layout.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="langid">[in] The language id of the profile to be activated.</param>
		/// <param name="clsid">
		/// [in] The CLSID of the text service of the profile to be activated. This must be CLSID_NULL if dwProfileType is TF_PROFILETYPE_KEYBOARDLAYOUT.
		/// </param>
		/// <param name="guidProfile">
		/// [in] The guidProfile of the profile to be activated. This must be GUID_NULL if dwProfileType is TF_PROFILETYPE_KEYBOARDLAYOUT.
		/// </param>
		/// <param name="hkl">[in] The handle of the keyboard layout. This must be <c>NULL</c> if dwProfileType is TF_PROFILETYPE_INPUTPROCESSOR.</param>
		/// <returns>[out] The buffer to receive TF_INPUTPROCESSORPROFILE.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfinputprocessorprofilemgr-getprofile HRESULT GetProfile(
		// DWORD dwProfileType, LANGID langid, REFCLSID clsid, REFGUID guidProfile, HKL hkl, TF_INPUTPROCESSORPROFILE *pProfile );
		TF_INPUTPROCESSORPROFILE GetProfile([In] TF_PROFILETYPE dwProfileType, [In] LANGID langid, in Guid clsid, in Guid guidProfile, [In, Optional] HKL hkl);

		/// <summary>The <c>ITfInputProcessorProfileMgr::EnumProfiles</c> method returns profiles to be enumerated.</summary>
		/// <param name="langid">[in] langid of the profiles to be enumerated. If langid is 0, all profiles will be enumerated.</param>
		/// <returns>[out] The pointer to receive a pointer of IEnumTfInputProcessorProfiles interface.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfinputprocessorprofilemgr-enumprofiles HRESULT
		// EnumProfiles( LANGID langid, IEnumTfInputProcessorProfiles **ppEnum );
		IEnumTfInputProcessorProfiles EnumProfiles([In] LANGID langid);

		/// <summary>
		/// The <c>ITfInputProcessorProfileMgr::ReleaseInputProcessor</c> method deactivates the profiles belonging to the text services
		/// of the specified CLSID and releases the instance of ITfTextInputProcessorEx interface.
		/// </summary>
		/// <param name="rclsid">[in] CLSID of the textservice to be released.</param>
		/// <param name="dwFlags">
		/// <para>[in]</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TF_RIP_FLAG_FREEUNUSEDLIBRARIES</term>
		/// <term>
		/// If this bit is on, this method calls CoFreeUnusedLibrariesEx() so the text services DLL might be freed if it does not have
		/// any more COM/DLL reference. Warning: This flag could cause some other unrelated COM/DLL free.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfinputprocessorprofilemgr-releaseinputprocessor HRESULT
		// ReleaseInputProcessor( REFCLSID rclsid, DWORD dwFlags );
		void ReleaseInputProcessor(in Guid rclsid, [In] TF_RIP_FLAG dwFlags);

		/// <summary>/// The <c>ITfInputProcessorProfileMgr::RegisterProfile</c> method registers the text service and the profile.</summary>
		/// <param name="rclsid">[in] CLSID of the text service.</param>
		/// <param name="langid">[in] The language id of the profile.</param>
		/// <param name="guidProfile">[in] The GUID to identify the profile.</param>
		/// <param name="pchDesc">[in, size_is(cchDesc)] The description of the profile.</param>
		/// <param name="cchDesc">[in] The length of pchDesc.</param>
		/// <param name="pchIconFile">[in, size_is(cchFile] The full path of the icon file.</param>
		/// <param name="cchFile">[in] The length of pchIconFile.</param>
		/// <param name="uIconIndex">[in] The icon index of the icon file for this profile.</param>
		/// <param name="hklSubstitute">[in] The substitute hkl of this profile.</param>
		/// <param name="dwPreferredLayout">[in] Unused. this must be 0.</param>
		/// <param name="bEnabledByDefault">[in] True if this profile is enabled by default.</param>
		/// <param name="dwFlags">
		/// <para>[in] The combination of the following bits:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TF_RP_HIDDENINSETTINGUI</term>
		/// <term>This profile will not appear in the setting UI.</term>
		/// </item>
		/// <item>
		/// <term>TF_RP_LOCALPROCESS</term>
		/// <term>This profile is available only on the local process.</term>
		/// </item>
		/// <item>
		/// <term>TF_RP_LOCALTHREAD</term>
		/// <term>This profile is available only on the local thread.</term>
		/// </item>
		/// </list>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfinputprocessorprofilemgr-registerprofile HRESULT
		// RegisterProfile( REFCLSID rclsid, LANGID langid, REFGUID guidProfile, const WCHAR *pchDesc, ULONG cchDesc, const WCHAR
		// *pchIconFile, ULONG cchFile, ULONG uIconIndex, HKL hklsubstitute, DWORD dwPreferredLayout, BOOL bEnabledByDefault, DWORD
		// dwFlags );
		void RegisterProfile(in Guid rclsid, [In] LANGID langid, in Guid guidProfile, [In, MarshalAs(UnmanagedType.LPWStr)] string pchDesc, uint cchDesc,
			[In, MarshalAs(UnmanagedType.LPWStr)] string pchIconFile, uint cchFile, uint uIconIndex, [In] HKL hklSubstitute, uint dwPreferredLayout,
			[In, MarshalAs(UnmanagedType.Bool)] bool bEnabledByDefault, [In] TF_RP dwFlags);

		/// <summary>The <c>ITfInputProcessorProfileMgr::UnregisterProfile</c> method unregisters the text service and the profile.</summary>
		/// <param name="rclsid">[in] CLSID of the text service.</param>
		/// <param name="langid">[in] The language id of the profile.</param>
		/// <param name="guidProfile">[in] The GUID to identify the profile.</param>
		/// <param name="dwFlags">
		/// <para>[in] The combination of the following bits:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TF_URP_ALLPROFILES</term>
		/// <term>
		/// If this bit is on, UnregistrProfile unregisters all profiles of the rclsid parameter. The langid and guidProfile parameters
		/// are ignored.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TF_URP_LOCALPROCESS</term>
		/// <term>The profile was registered on the local process.</term>
		/// </item>
		/// <item>
		/// <term>TF_URP_LOCALTHREAD</term>
		/// <term>The profile was registered on the local thread.</term>
		/// </item>
		/// </list>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfinputprocessorprofilemgr-unregisterprofile HRESULT
		// UnregisterProfile( REFCLSID rclsid, LANGID langid, REFGUID guidProfile, DWORD dwFlags );
		void UnregisterProfile(in Guid rclsid, [In, Optional] LANGID langid, [Optional] in Guid guidProfile, [In] TF_URP dwFlags);

		/// <summary>This method returns the current active profile.</summary>
		/// <param name="catid">
		/// [in] The category id for the profile. This must be GUID_TFCAT_TIP_KEYBOARD. Only GUID_TFCAT_TIP_KEYBOARD is supported.
		/// </param>
		/// <returns>[out] The buffer to receive the profile information.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfinputprocessorprofilemgr-getactiveprofile HRESULT
		// GetActiveProfile( REFGUID catid, TF_INPUTPROCESSORPROFILE *pProfile );
		TF_INPUTPROCESSORPROFILE GetActiveProfile(in Guid catid);
	}

	/// <summary>
	/// The <c>ITfInputProcessorProfiles</c> interface is implemented by the TSF manager and used by an application or text service to
	/// manipulate the language profile of one or more text services.
	/// </summary>
	/// <remarks>
	/// <para>To obtain a pointer to this interface, call CoCreateInstance with CLSID_TF_InputProcessorProfiles.</para>
	/// <para>Examples</para>
	/// <para><c>ITfInputProcessorProfiles</c></para>
	/// <para>
	/// <code language="cs">HRESULT hr;
	/// ITfInputProcessorProfiles *pProfiles;
	/// //Create the object.
	/// hr = CoCreateInstance( CLSID_TF_InputProcessorProfiles, NULL, CLSCTX_INPROC_SERVER, IID_ITfInputProcessorProfiles, (LPVOID*)&amp;pProfiles);
	/// if(SUCCEEDED(hr)) {
	///   //Use the interface.
	///   //Release the interface.
	///   pProfiles-&gt;Release();
	/// }</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-itfinputprocessorprofiles
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.ITfInputProcessorProfiles")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("1F02B6C5-7842-4EE6-8A0B-9A24183A95CA"), CoClass(typeof(TF_InputProcessorProfiles))]
	public interface ITfInputProcessorProfiles
	{
		/// <summary>Adds a text service to Text Services Foundation (TSF).</summary>
		/// <param name="rclsid">Contains the CLSID of the text service to register.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfinputprocessorprofiles-register HRESULT Register(
		// REFCLSID rclsid );
		void Register(in Guid rclsid);

		/// <summary>Removes a text service from TSF.</summary>
		/// <param name="rclsid">Contains the text service CLSID to unregister.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfinputprocessorprofiles-unregister HRESULT Unregister(
		// REFCLSID rclsid );
		void Unregister(in Guid rclsid);

		/// <summary>Creates a language profile that consists of a specific text service and a specific language identifier.</summary>
		/// <param name="rclsid">Contains the text service CLSID.</param>
		/// <param name="langid">
		/// Contains a <c>LANGID</c> value that specifies the language identifier of the profile that the text service is added to. If
		/// this contains -1, the text service is added to all languages.
		/// </param>
		/// <param name="guidProfile">
		/// Contains a GUID value that identifies the language profile. This is the value obtained by
		/// ITfInputProcessorProfiles::GetActiveLanguageProfile when the profile is active.
		/// </param>
		/// <param name="pchDesc">
		/// Pointer to a <c>WCHAR</c> buffer that contains the description string for the text service in the profile. This is the text
		/// service name displayed in the language bar.
		/// </param>
		/// <param name="cchDesc">
		/// Contains the length, in characters, of the description string in pchDesc. If this contains -1, pchDesc is assumed to be a
		/// <c>NULL</c>-terminated string.
		/// </param>
		/// <param name="pchIconFile">
		/// <para>
		/// Pointer to a <c>WCHAR</c> buffer that contains the path and file name of the file that contains the icon to be displayed in
		/// the language bar for the text service in the profile. This file can be an executable (.exe), DLL (.dll) or icon (.ico) file.
		/// </para>
		/// <para>This parameter is optional and can be <c>NULL</c>. In this case, a default icon is displayed for the text service.</para>
		/// </param>
		/// <param name="cchFile">
		/// Contains the length, in characters, of the icon file string in pchIconFile. If this contains -1, pchIconFile is assumed to
		/// be a <c>NULL</c>-terminated string. This parameter is ignored if pchIconFile is <c>NULL</c>.
		/// </param>
		/// <param name="uIconIndex">
		/// Contains the zero-based index of the icon in pchIconFile to be displayed in the language bar for the text service in the
		/// profile. This parameter is ignored if pchIconFile is <c>NULL</c>.
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfinputprocessorprofiles-addlanguageprofile HRESULT
		// AddLanguageProfile( REFCLSID rclsid, LANGID langid, REFGUID guidProfile, const WCHAR *pchDesc, ULONG cchDesc, const WCHAR
		// *pchIconFile, ULONG cchFile, ULONG uIconIndex );
		void AddLanguageProfile(in Guid rclsid, [In] LANGID langid, in Guid guidProfile, [In, MarshalAs(UnmanagedType.LPWStr)] string pchDesc, uint cchDesc,
			[In, MarshalAs(UnmanagedType.LPWStr), Optional] string? pchIconFile, [Optional] uint cchFile, [Optional] uint uIconIndex);

		/// <summary>Removes a language profile.</summary>
		/// <param name="rclsid">Contains the text service CLSID.</param>
		/// <param name="langid">Contains a <c>LANGID</c> value that specifies the language identifier of the profile.</param>
		/// <param name="guidProfile">
		/// Contains a GUID value that identifies the language profile. This is the value specified in
		/// ITfInputProcessorProfiles::AddLanguageProfile when the profile was added.
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfinputprocessorprofiles-removelanguageprofile HRESULT
		// RemoveLanguageProfile( REFCLSID rclsid, LANGID langid, REFGUID guidProfile );
		void RemoveLanguageProfile(in Guid rclsid, [In] LANGID langid, in Guid guidProfile);

		/// <summary>Obtains an enumerator that contains the class identifiers of all registered text services.</summary>
		/// <returns>
		/// Pointer to an <c>IEnumGUID</c> interface pointer that receives the enumerator object. The enumerator contains the CLSID for
		/// each registered text service. The caller must release this object when it is no longer required.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfinputprocessorprofiles-enuminputprocessorinfo HRESULT
		// EnumInputProcessorInfo( IEnumGUID **ppEnum );
		IEnumGUID EnumInputProcessorInfo();

		/// <summary>Obtains the default profile for a specific language.</summary>
		/// <param name="langid">Contains a <c>LANGID</c> value that specifies which language to obtain the default profile for.</param>
		/// <param name="catid">
		/// Contains a GUID value that identifies the category that the text service is registered under. This can be a user-defined
		/// category or one of the predefined category values.
		/// </param>
		/// <param name="pclsid">
		/// Pointer to a <c>CLSID</c> value that receives the class identifier of the default text service for the language.
		/// </param>
		/// <param name="pguidProfile">Pointer to a <c>GUID</c> value that receives the identifier of the default profile for the language.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfinputprocessorprofiles-getdefaultlanguageprofile HRESULT
		// GetDefaultLanguageProfile( LANGID langid, REFGUID catid, CLSID *pclsid, GUID *pguidProfile );
		void GetDefaultLanguageProfile([In] LANGID langid, in Guid catid, out Guid pclsid, out Guid pguidProfile);

		/// <summary>Sets the default profile for a specific language.</summary>
		/// <param name="langid">Contains a LANGID value that specifies which language to set the default profile for.</param>
		/// <param name="rclsid">Contains the CLSID of the text service that will be the default for the language.</param>
		/// <param name="guidProfiles">Contains a GUID value that identifies the language profile that will be the default.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfinputprocessorprofiles-setdefaultlanguageprofile HRESULT
		// SetDefaultLanguageProfile( LANGID langid, REFCLSID rclsid, REFGUID guidProfiles );
		void SetDefaultLanguageProfile([In] LANGID langid, in Guid rclsid, in Guid guidProfiles);

		/// <summary>Sets the active text service for a specific language.</summary>
		/// <param name="rclsid">Contains the CLSID of the text service to make active.</param>
		/// <param name="langid">
		/// Contains a <c>LANGID</c> value that specifies which language to set the default profile for. This method fails if this is
		/// not the currently active language.
		/// </param>
		/// <param name="guidProfiles">Contains a GUID value that identifies the language profile to make active.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfinputprocessorprofiles-activatelanguageprofile HRESULT
		// ActivateLanguageProfile( REFCLSID rclsid, LANGID langid, REFGUID guidProfiles );
		void ActivateLanguageProfile(in Guid rclsid, [In] LANGID langid, in Guid guidProfiles);

		/// <summary>Obtains the identifier of the currently active language profile for a specific text service.</summary>
		/// <param name="rclsid">Contains the text service CLSID.</param>
		/// <param name="plangid">Pointer to a <c>LANGID</c> value that receives the active profile language identifier.</param>
		/// <param name="pguidProfile">
		/// Pointer to a <c>GUID</c> value that receives the language profile identifier. This is the value specified in
		/// ITfInputProcessorProfiles::AddLanguageProfile when the profile was added.
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfinputprocessorprofiles-getactivelanguageprofile HRESULT
		// GetActiveLanguageProfile( REFCLSID rclsid, LANGID *plangid, GUID *pguidProfile );
		void GetActiveLanguageProfile(in Guid rclsid, out LANGID plangid, out Guid pguidProfile);

		/// <summary>Obtains the description string for a language profile.</summary>
		/// <param name="rclsid">Contains the CLSID of the text service to obtain the profile description for.</param>
		/// <param name="langid">Contains a <c>LANGID</c> value that specifies which language to obtain the profile description for.</param>
		/// <param name="guidProfile">Contains a GUID value that identifies the language to obtain the profile description for.</param>
		/// <returns>
		/// Pointer to a <c>BSTR</c> value that receives the description string. The caller is responsible for freeing this memory using
		/// SysFreeString when it is no longer required.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfinputprocessorprofiles-getlanguageprofiledescription
		// HRESULT GetLanguageProfileDescription( REFCLSID rclsid, LANGID langid, REFGUID guidProfile, BSTR *pbstrProfile );
		[return: MarshalAs(UnmanagedType.BStr)]
		string GetLanguageProfileDescription(in Guid rclsid, [In] LANGID langid, in Guid guidProfile);

		/// <summary>Obtains the identifier of the currently active language.</summary>
		/// <returns>Pointer to a <c>LANGID</c> value that receives the language identifier of the currently active language.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfinputprocessorprofiles-getcurrentlanguage HRESULT
		// GetCurrentLanguage( LANGID *plangid );
		LANGID GetCurrentLanguage();

		/// <summary>Sets the currently active language.</summary>
		/// <param name="langid">Contains the <c>LANGID</c> of the language to make active.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfinputprocessorprofiles-changecurrentlanguage HRESULT
		// ChangeCurrentLanguage( LANGID langid );
		void ChangeCurrentLanguage([In] LANGID langid);

		/// <summary>Obtains a list of the installed languages.</summary>
		/// <param name="ppLangId">
		/// Pointer to a <c>LANGID</c> pointer that receives the array of identifiers of the currently installed languages. The number
		/// of identifiers placed in this array is supplied in pulCount. The array is allocated by this method. The caller must free
		/// this memory when it is no longer required using CoTaskMemFree.
		/// </param>
		/// <param name="pulCount">Pointer to a ULONG value the receives the number of identifiers placed in the array at ppLangId.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfinputprocessorprofiles-getlanguagelist HRESULT
		// GetLanguageList( LANGID **ppLangId, ULONG *pulCount );
		void GetLanguageList(out SafeCoTaskMemHandle ppLangId, out uint pulCount);

		/// <summary>Obtains an enumerator that contains all of the profiles for a specific langauage.</summary>
		/// <param name="langid">Contains a <c>LANGID</c> value that specifies the language to obtain an enumerator for.</param>
		/// <returns>Pointer to an IEnumTfLanguageProfiles interface pointer that receives the enumerator object.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfinputprocessorprofiles-enumlanguageprofiles HRESULT
		// EnumLanguageProfiles( LANGID langid, IEnumTfLanguageProfiles **ppEnum );
		IEnumTfLanguageProfiles EnumLanguageProfiles([In] LANGID langid);

		/// <summary>Enables or disables a language profile for the current user.</summary>
		/// <param name="rclsid">Contains the CLSID of the text service of the profile to be enabled or disabled.</param>
		/// <param name="langid">Contains a <c>LANGID</c> value that specifies the language of the profile to be enabled or disabled.</param>
		/// <param name="guidProfile">Contains a GUID value that identifies the profile to be enabled or disabled.</param>
		/// <param name="fEnable">
		/// Contains a <c>BOOL</c> value that specifies if the profile will be enabled or disabled. If this contains a nonzero value,
		/// the profile will be enabled. If this contains zero, the profile will be disabled.
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfinputprocessorprofiles-enablelanguageprofile HRESULT
		// EnableLanguageProfile( REFCLSID rclsid, LANGID langid, REFGUID guidProfile, BOOL fEnable );
		void EnableLanguageProfile(in Guid rclsid, [In] LANGID langid, in Guid guidProfile, [In, MarshalAs(UnmanagedType.Bool)] bool fEnable);

		/// <summary>Determines if a specific language profile is enabled or disabled.</summary>
		/// <param name="rclsid">Contains the CLSID of the text service of the profile in question.</param>
		/// <param name="langid">Contains a <c>LANGID</c> value that specifies the language of the profile in question.</param>
		/// <param name="guidProfile">Contains a GUID value that identifies the profile in question.</param>
		/// <returns>
		/// Pointer to a <c>BOOL</c> value that receives a value that specifies if the profile is enabled or disabled. If this receives
		/// a nonzero value, the profile is enabled. If this receives zero, the profile is disabled.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfinputprocessorprofiles-isenabledlanguageprofile HRESULT
		// IsEnabledLanguageProfile( REFCLSID rclsid, LANGID langid, REFGUID guidProfile, BOOL *pfEnable );
		[return: MarshalAs(UnmanagedType.Bool)]
		bool IsEnabledLanguageProfile(in Guid rclsid, [In] LANGID langid, in Guid guidProfile);

		/// <summary>Enables or disables a language profile by default for all users.</summary>
		/// <param name="rclsid">Contains the CLSID of the text service of the profile to be enabled or disabled.</param>
		/// <param name="langid">Contains a <c>LANGID</c> value that specifies the language of the profile to be enabled or disabled.</param>
		/// <param name="guidProfile">Contains a GUID value that identifies the profile to be enabled or disabled.</param>
		/// <returns>
		/// Contains a <c>BOOL</c> value that specifies if the profile is enabled or disabled. If this contains a nonzero value, the
		/// profile is enabled. If this contains zero, the profile is disabled.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfinputprocessorprofiles-enablelanguageprofilebydefault
		// HRESULT EnableLanguageProfileByDefault( REFCLSID rclsid, LANGID langid, REFGUID guidProfile, BOOL fEnable );
		[return: MarshalAs(UnmanagedType.Bool)]
		bool EnableLanguageProfileByDefault(in Guid rclsid, [In] LANGID langid, in Guid guidProfile);

		/// <summary>Sets a substitute keyboard layout for the specified language profile.</summary>
		/// <param name="rclsid">Contains the CLSID of the text service of the profile in question.</param>
		/// <param name="langid">Contains a <c>LANGID</c> value that specifies the language of the profile in question.</param>
		/// <param name="guidProfile">Contains a GUID value that identifies the profile in question.</param>
		/// <param name="hKL">
		/// Contains an <c>HKL</c> value that specifies the input locale identifier for the substitute keyboard. Obtain this value by
		/// calling LoadKeyboardLayout.
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfinputprocessorprofiles-substitutekeyboardlayout HRESULT
		// SubstituteKeyboardLayout( REFCLSID rclsid, LANGID langid, REFGUID guidProfile, HKL hKL );
		void SubstituteKeyboardLayout(in Guid rclsid, [In] LANGID langid, in Guid guidProfile, [In] HKL hKL);
	}

	/// <summary>
	/// This interface is implemented by the TSF manager and used by a text service or application to set the display description of the
	/// language profile. To obtain an instance of this interface, call <c>ITfInputProcessorProfiles::QueryInterface</c> with <c>IID_ITfInputProcessorProfilesEx</c>.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-itfinputprocessorprofilesex
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.ITfInputProcessorProfilesEx")]
	[ComImport, Guid("892F230F-FE00-4A41-A98E-FCD6DE0D35EF"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(TF_InputProcessorProfiles))]
	public interface ITfInputProcessorProfilesEx : ITfInputProcessorProfiles
	{
		/// <summary>Adds a text service to Text Services Foundation (TSF).</summary>
		/// <param name="rclsid">Contains the CLSID of the text service to register.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfinputprocessorprofiles-register HRESULT Register(
		// REFCLSID rclsid );
		new void Register(in Guid rclsid);

		/// <summary>Removes a text service from TSF.</summary>
		/// <param name="rclsid">Contains the text service CLSID to unregister.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfinputprocessorprofiles-unregister HRESULT Unregister(
		// REFCLSID rclsid );
		new void Unregister(in Guid rclsid);

		/// <summary>Creates a language profile that consists of a specific text service and a specific language identifier.</summary>
		/// <param name="rclsid">Contains the text service CLSID.</param>
		/// <param name="langid">
		/// Contains a <c>LANGID</c> value that specifies the language identifier of the profile that the text service is added to. If
		/// this contains -1, the text service is added to all languages.
		/// </param>
		/// <param name="guidProfile">
		/// Contains a GUID value that identifies the language profile. This is the value obtained by
		/// ITfInputProcessorProfiles::GetActiveLanguageProfile when the profile is active.
		/// </param>
		/// <param name="pchDesc">
		/// Pointer to a <c>WCHAR</c> buffer that contains the description string for the text service in the profile. This is the text
		/// service name displayed in the language bar.
		/// </param>
		/// <param name="cchDesc">
		/// Contains the length, in characters, of the description string in pchDesc. If this contains -1, pchDesc is assumed to be a
		/// <c>NULL</c>-terminated string.
		/// </param>
		/// <param name="pchIconFile">
		/// <para>
		/// Pointer to a <c>WCHAR</c> buffer that contains the path and file name of the file that contains the icon to be displayed in
		/// the language bar for the text service in the profile. This file can be an executable (.exe), DLL (.dll) or icon (.ico) file.
		/// </para>
		/// <para>This parameter is optional and can be <c>NULL</c>. In this case, a default icon is displayed for the text service.</para>
		/// </param>
		/// <param name="cchFile">
		/// Contains the length, in characters, of the icon file string in pchIconFile. If this contains -1, pchIconFile is assumed to
		/// be a <c>NULL</c>-terminated string. This parameter is ignored if pchIconFile is <c>NULL</c>.
		/// </param>
		/// <param name="uIconIndex">
		/// Contains the zero-based index of the icon in pchIconFile to be displayed in the language bar for the text service in the
		/// profile. This parameter is ignored if pchIconFile is <c>NULL</c>.
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfinputprocessorprofiles-addlanguageprofile HRESULT
		// AddLanguageProfile( REFCLSID rclsid, LANGID langid, REFGUID guidProfile, const WCHAR *pchDesc, ULONG cchDesc, const WCHAR
		// *pchIconFile, ULONG cchFile, ULONG uIconIndex );
		new void AddLanguageProfile(in Guid rclsid, [In] LANGID langid, in Guid guidProfile, [In, MarshalAs(UnmanagedType.LPWStr)] string pchDesc, uint cchDesc,
			[In, MarshalAs(UnmanagedType.LPWStr), Optional] string? pchIconFile, [Optional] uint cchFile, [Optional] uint uIconIndex);

		/// <summary>Removes a language profile.</summary>
		/// <param name="rclsid">Contains the text service CLSID.</param>
		/// <param name="langid">Contains a <c>LANGID</c> value that specifies the language identifier of the profile.</param>
		/// <param name="guidProfile">
		/// Contains a GUID value that identifies the language profile. This is the value specified in
		/// ITfInputProcessorProfiles::AddLanguageProfile when the profile was added.
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfinputprocessorprofiles-removelanguageprofile HRESULT
		// RemoveLanguageProfile( REFCLSID rclsid, LANGID langid, REFGUID guidProfile );
		new void RemoveLanguageProfile(in Guid rclsid, [In] LANGID langid, in Guid guidProfile);

		/// <summary>Obtains an enumerator that contains the class identifiers of all registered text services.</summary>
		/// <returns>
		/// Pointer to an <c>IEnumGUID</c> interface pointer that receives the enumerator object. The enumerator contains the CLSID for
		/// each registered text service. The caller must release this object when it is no longer required.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfinputprocessorprofiles-enuminputprocessorinfo HRESULT
		// EnumInputProcessorInfo( IEnumGUID **ppEnum );
		new IEnumGUID EnumInputProcessorInfo();

		/// <summary>Obtains the default profile for a specific language.</summary>
		/// <param name="langid">Contains a <c>LANGID</c> value that specifies which language to obtain the default profile for.</param>
		/// <param name="catid">
		/// Contains a GUID value that identifies the category that the text service is registered under. This can be a user-defined
		/// category or one of the predefined category values.
		/// </param>
		/// <param name="pclsid">
		/// Pointer to a <c>CLSID</c> value that receives the class identifier of the default text service for the language.
		/// </param>
		/// <param name="pguidProfile">Pointer to a <c>GUID</c> value that receives the identifier of the default profile for the language.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfinputprocessorprofiles-getdefaultlanguageprofile HRESULT
		// GetDefaultLanguageProfile( LANGID langid, REFGUID catid, CLSID *pclsid, GUID *pguidProfile );
		new void GetDefaultLanguageProfile([In] LANGID langid, in Guid catid, out Guid pclsid, out Guid pguidProfile);

		/// <summary>Sets the default profile for a specific language.</summary>
		/// <param name="langid">Contains a LANGID value that specifies which language to set the default profile for.</param>
		/// <param name="rclsid">Contains the CLSID of the text service that will be the default for the language.</param>
		/// <param name="guidProfiles">Contains a GUID value that identifies the language profile that will be the default.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfinputprocessorprofiles-setdefaultlanguageprofile HRESULT
		// SetDefaultLanguageProfile( LANGID langid, REFCLSID rclsid, REFGUID guidProfiles );
		new void SetDefaultLanguageProfile([In] LANGID langid, in Guid rclsid, in Guid guidProfiles);

		/// <summary>Sets the active text service for a specific language.</summary>
		/// <param name="rclsid">Contains the CLSID of the text service to make active.</param>
		/// <param name="langid">
		/// Contains a <c>LANGID</c> value that specifies which language to set the default profile for. This method fails if this is
		/// not the currently active language.
		/// </param>
		/// <param name="guidProfiles">Contains a GUID value that identifies the language profile to make active.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfinputprocessorprofiles-activatelanguageprofile HRESULT
		// ActivateLanguageProfile( REFCLSID rclsid, LANGID langid, REFGUID guidProfiles );
		new void ActivateLanguageProfile(in Guid rclsid, [In] LANGID langid, in Guid guidProfiles);

		/// <summary>Obtains the identifier of the currently active language profile for a specific text service.</summary>
		/// <param name="rclsid">Contains the text service CLSID.</param>
		/// <param name="plangid">Pointer to a <c>LANGID</c> value that receives the active profile language identifier.</param>
		/// <param name="pguidProfile">
		/// Pointer to a <c>GUID</c> value that receives the language profile identifier. This is the value specified in
		/// ITfInputProcessorProfiles::AddLanguageProfile when the profile was added.
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfinputprocessorprofiles-getactivelanguageprofile HRESULT
		// GetActiveLanguageProfile( REFCLSID rclsid, LANGID *plangid, GUID *pguidProfile );
		new void GetActiveLanguageProfile(in Guid rclsid, out LANGID plangid, out Guid pguidProfile);

		/// <summary>Obtains the description string for a language profile.</summary>
		/// <param name="rclsid">Contains the CLSID of the text service to obtain the profile description for.</param>
		/// <param name="langid">Contains a <c>LANGID</c> value that specifies which language to obtain the profile description for.</param>
		/// <param name="guidProfile">Contains a GUID value that identifies the language to obtain the profile description for.</param>
		/// <returns>
		/// Pointer to a <c>BSTR</c> value that receives the description string. The caller is responsible for freeing this memory using
		/// SysFreeString when it is no longer required.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfinputprocessorprofiles-getlanguageprofiledescription
		// HRESULT GetLanguageProfileDescription( REFCLSID rclsid, LANGID langid, REFGUID guidProfile, BSTR *pbstrProfile );
		[return: MarshalAs(UnmanagedType.BStr)]
		new string GetLanguageProfileDescription(in Guid rclsid, [In] LANGID langid, in Guid guidProfile);

		/// <summary>Obtains the identifier of the currently active language.</summary>
		/// <returns>Pointer to a <c>LANGID</c> value that receives the language identifier of the currently active language.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfinputprocessorprofiles-getcurrentlanguage HRESULT
		// GetCurrentLanguage( LANGID *plangid );
		new LANGID GetCurrentLanguage();

		/// <summary>Sets the currently active language.</summary>
		/// <param name="langid">Contains the <c>LANGID</c> of the language to make active.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfinputprocessorprofiles-changecurrentlanguage HRESULT
		// ChangeCurrentLanguage( LANGID langid );
		new void ChangeCurrentLanguage([In] LANGID langid);

		/// <summary>Obtains a list of the installed languages.</summary>
		/// <param name="ppLangId">
		/// Pointer to a <c>LANGID</c> pointer that receives the array of identifiers of the currently installed languages. The number
		/// of identifiers placed in this array is supplied in pulCount. The array is allocated by this method. The caller must free
		/// this memory when it is no longer required using CoTaskMemFree.
		/// </param>
		/// <param name="pulCount">Pointer to a ULONG value the receives the number of identifiers placed in the array at ppLangId.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfinputprocessorprofiles-getlanguagelist HRESULT
		// GetLanguageList( LANGID **ppLangId, ULONG *pulCount );
		new void GetLanguageList(out SafeCoTaskMemHandle ppLangId, out uint pulCount);

		/// <summary>Obtains an enumerator that contains all of the profiles for a specific langauage.</summary>
		/// <param name="langid">Contains a <c>LANGID</c> value that specifies the language to obtain an enumerator for.</param>
		/// <returns>Pointer to an IEnumTfLanguageProfiles interface pointer that receives the enumerator object.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfinputprocessorprofiles-enumlanguageprofiles HRESULT
		// EnumLanguageProfiles( LANGID langid, IEnumTfLanguageProfiles **ppEnum );
		new IEnumTfLanguageProfiles EnumLanguageProfiles([In] LANGID langid);

		/// <summary>Enables or disables a language profile for the current user.</summary>
		/// <param name="rclsid">Contains the CLSID of the text service of the profile to be enabled or disabled.</param>
		/// <param name="langid">Contains a <c>LANGID</c> value that specifies the language of the profile to be enabled or disabled.</param>
		/// <param name="guidProfile">Contains a GUID value that identifies the profile to be enabled or disabled.</param>
		/// <param name="fEnable">
		/// Contains a <c>BOOL</c> value that specifies if the profile will be enabled or disabled. If this contains a nonzero value,
		/// the profile will be enabled. If this contains zero, the profile will be disabled.
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfinputprocessorprofiles-enablelanguageprofile HRESULT
		// EnableLanguageProfile( REFCLSID rclsid, LANGID langid, REFGUID guidProfile, BOOL fEnable );
		new void EnableLanguageProfile(in Guid rclsid, [In] LANGID langid, in Guid guidProfile, [In, MarshalAs(UnmanagedType.Bool)] bool fEnable);

		/// <summary>Determines if a specific language profile is enabled or disabled.</summary>
		/// <param name="rclsid">Contains the CLSID of the text service of the profile in question.</param>
		/// <param name="langid">Contains a <c>LANGID</c> value that specifies the language of the profile in question.</param>
		/// <param name="guidProfile">Contains a GUID value that identifies the profile in question.</param>
		/// <returns>
		/// Pointer to a <c>BOOL</c> value that receives a value that specifies if the profile is enabled or disabled. If this receives
		/// a nonzero value, the profile is enabled. If this receives zero, the profile is disabled.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfinputprocessorprofiles-isenabledlanguageprofile HRESULT
		// IsEnabledLanguageProfile( REFCLSID rclsid, LANGID langid, REFGUID guidProfile, BOOL *pfEnable );
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool IsEnabledLanguageProfile(in Guid rclsid, [In] LANGID langid, in Guid guidProfile);

		/// <summary>Enables or disables a language profile by default for all users.</summary>
		/// <param name="rclsid">Contains the CLSID of the text service of the profile to be enabled or disabled.</param>
		/// <param name="langid">Contains a <c>LANGID</c> value that specifies the language of the profile to be enabled or disabled.</param>
		/// <param name="guidProfile">Contains a GUID value that identifies the profile to be enabled or disabled.</param>
		/// <returns>
		/// Contains a <c>BOOL</c> value that specifies if the profile is enabled or disabled. If this contains a nonzero value, the
		/// profile is enabled. If this contains zero, the profile is disabled.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfinputprocessorprofiles-enablelanguageprofilebydefault
		// HRESULT EnableLanguageProfileByDefault( REFCLSID rclsid, LANGID langid, REFGUID guidProfile, BOOL fEnable );
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool EnableLanguageProfileByDefault(in Guid rclsid, [In] LANGID langid, in Guid guidProfile);

		/// <summary>Sets a substitute keyboard layout for the specified language profile.</summary>
		/// <param name="rclsid">Contains the CLSID of the text service of the profile in question.</param>
		/// <param name="langid">Contains a <c>LANGID</c> value that specifies the language of the profile in question.</param>
		/// <param name="guidProfile">Contains a GUID value that identifies the profile in question.</param>
		/// <param name="hKL">
		/// Contains an <c>HKL</c> value that specifies the input locale identifier for the substitute keyboard. Obtain this value by
		/// calling LoadKeyboardLayout.
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfinputprocessorprofiles-substitutekeyboardlayout HRESULT
		// SubstituteKeyboardLayout( REFCLSID rclsid, LANGID langid, REFGUID guidProfile, HKL hKL );
		new void SubstituteKeyboardLayout(in Guid rclsid, [In] LANGID langid, in Guid guidProfile, [In] HKL hKL);

		/// <summary>
		/// <para>Redistributable: Requires TSF 1.0 on Windows 2000.</para>
		/// <para>Header: Declared in Msctf.idl and Msctf.h.</para>
		/// <para>Library: Included as a resource in Msctf.dll.</para>
		/// </summary>
		/// <param name="rclsid"/>
		/// <param name="langid"/>
		/// <param name="guidProfile"/>
		/// <param name="pchFile"/>
		/// <param name="cchFile"/>
		/// <param name="uResId"/>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfinputprocessorprofilesex-setlanguageprofiledisplayname
		// HRESULT SetLanguageProfileDisplayName( REFCLSID rclsid, LANGID langid, REFGUID guidProfile, const WCHAR *pchFile, ULONG
		// cchFile, ULONG uResId );
		void SetLanguageProfileDisplayName(in Guid rclsid, [In] LANGID langid, in Guid guidProfile, [In, MarshalAs(UnmanagedType.LPWStr)] string pchFile, uint cchFile, uint uResId);
	}

	/// <summary>
	/// This interface is implemented by the TSF manager and is used by an application or text service to manipulate the substitute
	/// input locale identifier (keyboard layout) of a text service profile. The interface ID is IID_ITfInputProcessorProfileSubstituteLayout.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-itfinputprocessorprofilesubstitutelayout
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.ITfInputProcessorProfileSubstituteLayout")]
	[ComImport, Guid("4FD67194-1002-4513-BFF2-C0DDF6258552"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ITfInputProcessorProfileSubstituteLayout
	{
		/// <summary>Retrieves the input locale identifier (keyboard layout).</summary>
		/// <param name="rclsid">Contains the class identifier of the text service.</param>
		/// <param name="langid">Specifies the language of the profile. See Language Identifiers.</param>
		/// <param name="guidProfile">Identifies the profile GUID.</param>
		/// <param name="phKL">Pointer to an <c>HKL</c> value that specifies the substitute input locale identifier.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfinputprocessorprofilesubstitutelayout-getsubstitutekeyboardlayout
		// HRESULT GetSubstituteKeyboardLayout( REFCLSID rclsid, LANGID langid, REFGUID guidProfile, HKL *phKL );
		[PreserveSig]
		HRESULT GetSubstituteKeyboardLayout(in Guid rclsid, [In] LANGID langid, in Guid guidProfile, out HKL phKL);
	}

	/// <summary>
	/// The <c>ITfInsertAtSelection</c> interface is implemented by the manager and is used by a text service to insert text or an
	/// embedded object in a context. The text service obtains this interface by calling ITfContext::QueryInterface.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-itfinsertatselection
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.ITfInsertAtSelection")]
	[ComImport, Guid("55CE16BA-3014-41C1-9CEB-FADE1446AC6C"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ITfInsertAtSelection
	{
		/// <summary>Inserts text at the selection or insertion point.</summary>
		/// <param name="ec">Identifies the edit context. This is obtained from ITfDocumentMgr::CreateContext or ITfEditSession::DoEditSession.</param>
		/// <param name="dwFlags">
		/// <para>Bit field with one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TF_IAS_NOQUERY</term>
		/// <term>ppRange is NULL. This flag cannot be combined with the TF_IAS_QUERYONLY flag.</term>
		/// </item>
		/// <item>
		/// <term>TF_IAS_QUERYONLY</term>
		/// <term>
		/// The context is not modified, but ppRange is set as if the insert had occurred. Read-only access is sufficient. If this flag
		/// is not set, ec must have read/write access. This flag cannot be combined with the TF_IAS_NOQUERY flag.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TF_IAS_NO_DEFAULT_COMPOSITION</term>
		/// <term>
		/// The manager will not create a default composition if a composition is required. The caller must create a composition object
		/// that covers the inserted text before releasing the context lock.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pchText">Specifies the text to insert.</param>
		/// <param name="cch">Specifies the character count of the text in pchText.</param>
		/// <returns>Receives the position of the inserted object.</returns>
		/// <remarks>To insert an IDataObject object instead of text, use ITfInsertAtSelection::InsertEmbeddedAtSelection.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfinsertatselection-inserttextatselection HRESULT
		// InsertTextAtSelection( TfEditCookie ec, DWORD dwFlags, const WCHAR *pchText, LONG cch, ITfRange **ppRange );
		ITfRange? InsertTextAtSelection([In] TfEditCookie ec, [In] TF_IAS dwFlags, [In, MarshalAs(UnmanagedType.LPWStr)] string pchText, int cch);

		/// <summary>
		/// The <c>ITfInsertAtSelection::InsertEmbeddedAtSelection</c> method inserts an IDataObject object at the selection or
		/// insertion point.
		/// </summary>
		/// <param name="ec">Identifies the edit context. This is obtained from ITfDocumentMgr::CreateContext or ITfEditSession::DoEditSession.</param>
		/// <param name="dwFlags">
		/// <para>Bit field with one of the following values:</para>
		/// <para>TF_IAS_NOQUERY</para>
		/// <para>The ppRange parameter is <c>NULL</c> on exit.</para>
		/// <para>TF_IAS_QUERYONLY</para>
		/// <para>
		/// Context is not modified but the ppRange parameter is set as if the insert occurred. Read-only access is sufficient. If this
		/// flag is not set, the ec parameter must have read/write access.
		/// </para>
		/// <para>TF_IAS_NO_DEFAULT_COMPOSITION</para>
		/// <para>
		/// The TSF manager does not create a default composition if a composition is required. The caller must create a composition
		/// object that covers the inserted text before releasing the context lock.
		/// </para>
		/// </param>
		/// <param name="pDataObject">Pointer to object to insert.</param>
		/// <returns>Position of the inserted object. Optional.</returns>
		/// <remarks>
		/// <para>
		/// Callers can use the ITfQueryEmbedded::QueryInsertEmbedded method to determine if a particular object type is likely to be
		/// accepted by this method.
		/// </para>
		/// <para>To insert text instead of an <c>IDataObject</c> object, use the ITfInsertAtSelection::InsertTextAtSelection method.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfinsertatselection-insertembeddedatselection HRESULT
		// InsertEmbeddedAtSelection( TfEditCookie ec, DWORD dwFlags, IDataObject *pDataObject, ITfRange **ppRange );
		ITfRange? InsertEmbeddedAtSelection([In] TfEditCookie ec, [In] TF_IAS dwFlags, [In, Optional] IDataObject? pDataObject);
	}

	/// <summary>
	/// The <c>ITfKeyEventSink</c> interface is implemented by a text service to receive keyboard and focus event notifications. To
	/// install this event sink, call ITfKeystrokeMgr::AdviseKeyEventSink.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-itfkeyeventsink
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.ITfKeyEventSink")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("AA80E7F5-2021-11D2-93E0-0060B067B86E")]
	public interface ITfKeyEventSink
	{
		/// <summary>Called when a TSF text service receives or loses the keyboard focus.</summary>
		/// <param name="fForeground">If <c>TRUE</c>, the test service receives the focus. Otherwise the text service loses the focus.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfkeyeventsink-onsetfocus HRESULT OnSetFocus( BOOL
		// fForeground );
		[PreserveSig]
		HRESULT OnSetFocus([In, MarshalAs(UnmanagedType.Bool)] bool fForeground);

		/// <summary>Called to determine if a text service will handle a key down event.</summary>
		/// <param name="pic">Pointer to the input context that receives the key event.</param>
		/// <param name="wParam">
		/// Specifies the virtual-key code of the key. For more information about this parameter, see the wParam parameter in WM_KEYDOWN.
		/// </param>
		/// <param name="lParam">
		/// Specifies the repeat count, scan code, extended-key flag, context code, previous key-state flag, and transition-state flag
		/// of the key. For more information about this parameter, see the lParam parameter in WM_KEYDOWN.
		/// </param>
		/// <param name="pfEaten">
		/// Pointer to a BOOL that, on exit, indicates if the key event would be handled. If this value receives <c>TRUE</c>, the key
		/// event would be handled. If this value is <c>FALSE</c>, the key event would not be handled.
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
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfkeyeventsink-ontestkeydown HRESULT OnTestKeyDown(
		// ITfContext *pic, WPARAM wParam, LPARAM lParam, BOOL *pfEaten );
		[PreserveSig]
		HRESULT OnTestKeyDown([In] ITfContext pic, [In] WPARAM wParam, [In] LPARAM lParam, [Out, MarshalAs(UnmanagedType.Bool)] out bool pfEaten);

		/// <summary>Called to determine if a text service will handle a key up event.</summary>
		/// <param name="pic">Pointer to the input context that receives the key event.</param>
		/// <param name="wParam">
		/// Specifies the virtual-key code of the key. For more information about this parameter, see the wParam parameter in WM_KEYUP.
		/// </param>
		/// <param name="lParam">
		/// Specifies the repeat count, scan code, extended-key flag, context code, previous key-state flag, and transition-state flag
		/// of the key. For more information about this parameter, see the lParam parameter in WM_KEYUP.
		/// </param>
		/// <param name="pfEaten">
		/// Pointer to a BOOL that, on exit, indicates if the key event would be handled. If this value receives <c>TRUE</c>, the key
		/// event would be handled. If this value receives <c>FALSE</c>, the key event would not be handled.
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
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfkeyeventsink-ontestkeyup HRESULT OnTestKeyUp( ITfContext
		// *pic, WPARAM wParam, LPARAM lParam, BOOL *pfEaten );
		[PreserveSig]
		HRESULT OnTestKeyUp([In] ITfContext pic, [In] WPARAM wParam, [In] LPARAM lParam, [Out, MarshalAs(UnmanagedType.Bool)] out bool pfEaten);

		/// <summary>Called when a key down event occurs.</summary>
		/// <param name="pic">Pointer to the input context that receives the key event.</param>
		/// <param name="wParam">
		/// Specifies the virtual-key code of the key. For more information about this parameter, see the wParam parameter in WM_KEYDOWN.
		/// </param>
		/// <param name="lParam">
		/// Specifies the repeat count, scan code, extended-key flag, context code, previous key-state flag, and transition-state flag
		/// of the key. For more information about this parameter, see the lParam parameter in WM_KEYDOWN.
		/// </param>
		/// <param name="pfEaten">
		/// Pointer to a BOOL that, on exit, indicates if the key event was handled. If this value receives <c>TRUE</c>, the key event
		/// was handled. If this value is <c>FALSE</c>, the key event was not handled.
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
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfkeyeventsink-onkeydown HRESULT OnKeyDown( ITfContext
		// *pic, WPARAM wParam, LPARAM lParam, BOOL *pfEaten );
		[PreserveSig]
		HRESULT OnKeyDown([In] ITfContext pic, [In] WPARAM wParam, [In] LPARAM lParam, [Out, MarshalAs(UnmanagedType.Bool)] out bool pfEaten);

		/// <summary>Called when a key up event occurs.</summary>
		/// <param name="pic">Pointer to the input context that receives the key event.</param>
		/// <param name="wParam">
		/// Specifies the virtual-key code of the key. For more information about this parameter, see the wParam parameter in WM_KEYUP.
		/// </param>
		/// <param name="lParam">
		/// Specifies the repeat count, scan code, extended-key flag, context code, previous key-state flag, and transition-state flag
		/// of the key. For more information about this parameter, see the lParam parameter in WM_KEYUP.
		/// </param>
		/// <param name="pfEaten">
		/// Pointer to a BOOL that, on exit, indicates if the key event was handled. If this value receives <c>TRUE</c>, the key event
		/// was handled. If this value receives <c>FALSE</c>, the key event was not handled.
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
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfkeyeventsink-onkeyup HRESULT OnKeyUp( ITfContext *pic,
		// WPARAM wParam, LPARAM lParam, BOOL *pfEaten );
		[PreserveSig]
		HRESULT OnKeyUp([In] ITfContext pic, [In] WPARAM wParam, [In] LPARAM lParam, [Out, MarshalAs(UnmanagedType.Bool)] out bool pfEaten);

		/// <summary>Called when a preserved key event occurs.</summary>
		/// <param name="pic">Pointer to the input context that receives the key event.</param>
		/// <param name="rguid">Contains the command GUID of the preserved key.</param>
		/// <param name="pfEaten">
		/// Pointer to a BOOL value that, on exit, indicates if the preserved key event was handled. If this value receives <c>TRUE</c>,
		/// the preserved key event was handled. If this value receives <c>FALSE</c>, the preserved key event was not handled.
		/// </param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfkeyeventsink-onpreservedkey HRESULT OnPreservedKey(
		// ITfContext *pic, REFGUID rguid, BOOL *pfEaten );
		[PreserveSig]
		HRESULT OnPreservedKey([In] ITfContext pic, in Guid rguid, [Out, MarshalAs(UnmanagedType.Bool)] out bool pfEaten);
	}

	/// <summary>
	/// The <c>ITfKeystrokeMgr</c> interface is implemented by the TSF manager and used by applications and text services to interact
	/// with the keyboard manager.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-itfkeystrokemgr
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.ITfKeystrokeMgr")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("AA80E7F0-2021-11D2-93E0-0060B067B86E")]
	public interface ITfKeystrokeMgr
	{
		/// <summary>Installs a key event sink to receive keyboard events.</summary>
		/// <param name="tid">Identifier of the client that owns the key event sink. This value is obtained by a previous call to ITfThreadMgr::Activate.</param>
		/// <param name="pSink">Pointer to a ITfKeyEventSink interface.</param>
		/// <param name="fForeground">
		/// Specifies if this key event sink is made the foreground key event sink. If this is <c>TRUE</c>, this key event sink is made
		/// the foreground key event sink. Otherwise, this key event sink does not become the foreground key event sink.
		/// </param>
		/// <remarks>
		/// The foreground key event sink receives all keyboard events. A non-foreground key event sink only receives preserved keys and
		/// key events that occur over text that marked owned by the client identifier.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfkeystrokemgr-advisekeyeventsink HRESULT
		// AdviseKeyEventSink( TfClientId tid, ITfKeyEventSink *pSink, BOOL fForeground );
		void AdviseKeyEventSink([In] TfClientId tid, [In] ITfKeyEventSink pSink, [In, MarshalAs(UnmanagedType.Bool)] bool fForeground);

		/// <summary>Removes a key event sink.</summary>
		/// <param name="tid">
		/// Identifier of the client that owns the key event sink. This value was passed when the advise sink was installed using ITfKeystrokeMgr::AdviseKeyEventSink.
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfkeystrokemgr-unadvisekeyeventsink HRESULT
		// UnadviseKeyEventSink( TfClientId tid );
		void UnadviseKeyEventSink([In] TfClientId tid);

		/// <summary>Obtains the class identifier of the foreground TSF text service.</summary>
		/// <returns>Pointer to a CLSID that receives the class identifier of the foreground TSF text service.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfkeystrokemgr-getforeground HRESULT GetForeground( CLSID
		// *pclsid );
		Guid GetForeground();

		/// <summary>Determines if the keystroke manager will handle a key down event.</summary>
		/// <param name="wParam">
		/// Specifies the virtual-key code of the key. For more information about this parameter, see the wParam parameter in WM_KEYDOWN.
		/// </param>
		/// <param name="lParam">
		/// Specifies the repeat count, scan code, extended-key flag, context code, previous key-state flag, and transition-state flag
		/// of the key. For more information about this parameter, see the lParam parameter in WM_KEYDOWN.
		/// </param>
		/// <returns>
		/// Pointer to a BOOL that indicates if the key event would be handled. If this value receives <c>TRUE</c>, the key event would
		/// be handled and the event should not be forwarded to the application. If this value is <c>FALSE</c>, the key event would not
		/// be handled and the event should be forwarded to the application.
		/// </returns>
		/// <remarks>
		/// <para>
		/// An application can determine if a key event will be handled by the keystroke manager with this method. If this method is
		/// successful and pfEaten receives <c>TRUE</c>, the application should call ITfKeystrokeMgr::KeyDown. If this method does not
		/// return S_OK or pfEaten receives <c>FALSE</c>, the application should not call <c>ITfKeystrokeMgr::KeyDown</c> . The
		/// following is an example of how this is implemented.
		/// </para>
		/// <para>
		/// <code> if(msg.message == WM_KEYDOWN) { if( pKeyboardMgr-&gt;TestKeyDown(msg.wParam, msg.lParam, &amp;fEaten) == S_OK &amp;&amp; fEaten &amp;&amp; pKeyboardMgr-&gt;KeyDown(msg.wParam, msg.lParam, &amp;fEaten) == S_OK &amp;&amp; fEaten) { //The key was handled by the keystroke manager or a TSF text service. Do not pass the key to the application. continue; } else { //Let the application process the key. } }</code>
		/// </para>
		/// <para>
		/// If the keystroke manager does not handle the key event, it passes the key event to the TSF text services by calling the text
		/// service ITfKeyEventSink::OnTestKeyDown method.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfkeystrokemgr-testkeydown HRESULT TestKeyDown( WPARAM
		// wParam, LPARAM lParam, BOOL *pfEaten );
		[return: MarshalAs(UnmanagedType.Bool)]
		bool TestKeyDown([In] WPARAM wParam, [In] LPARAM lParam);

		/// <summary>Determines if the keystroke manager will handle a key up event.</summary>
		/// <param name="wParam">
		/// Specifies the virtual-key code of the key. For more information about this parameter, see the wParam parameter in WM_KEYUP.
		/// </param>
		/// <param name="lParam">
		/// Specifies the repeat count, scan code, extended-key flag, context code, previous key-state flag, and transition-state flag
		/// of the key. For more information about this parameter, see the lParam parameter in WM_KEYUP.
		/// </param>
		/// <returns>
		/// Pointer to a BOOL that indicates if the key event is handled. If this value receives <c>TRUE</c>, the key event is handled
		/// and the event should not be forwarded to the application. If this value is <c>FALSE</c>, the key event is not handled and
		/// the event should be forwarded to the application.
		/// </returns>
		/// <remarks>
		/// <para>
		/// An application can determine if a key event is handled by the keystroke manager with this method. If this method is
		/// successful and pfEaten receives <c>TRUE</c>, the application should call ITfKeystrokeMgr::KeyUp. If this method does not
		/// return S_OK or pfEaten receives <c>FALSE</c>, the application should not call <c>ITfKeystrokeMgr::KeyUp</c> . The following
		/// is an example of how this is implemented.
		/// </para>
		/// <para>
		/// <code> if(msg.message == WM_KEYUP) { if( pKeyboardMgr-&gt;TestKeyUp(msg.wParam, msg.lParam, &amp;fEaten) == S_OK &amp;&amp; fEaten &amp;&amp; pKeyboardMgr-&gt;KeyUp(msg.wParam, msg.lParam, &amp;fEaten) == S_OK &amp;&amp; fEaten) { The key was handled by the keystroke manager or a text service. Do not pass the key to the application. continue; } else { //Let the application process the key. } }</code>
		/// </para>
		/// <para>
		/// If the keystroke manager does not handle the key event, it passes the key event to the TSF text service by calling the TSF
		/// text service ITfKeyEventSink::OnTestKeyUp method.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfkeystrokemgr-testkeyup HRESULT TestKeyUp( WPARAM wParam,
		// LPARAM lParam, BOOL *pfEaten );
		[return: MarshalAs(UnmanagedType.Bool)]
		bool TestKeyUp([In] WPARAM wParam, [In] LPARAM lParam);

		/// <summary>Passes a key down event to the keystroke manager.</summary>
		/// <param name="wParam">
		/// Specifies the virtual-key code of the key. For more information about this parameter, see the wParam parameter in WM_KEYDOWN.
		/// </param>
		/// <param name="lParam">
		/// Specifies the repeat count, scan code, extended-key flag, context code, previous key-state flag, and transition-state flag
		/// of the key. For more information about this parameter, see the lParam parameter in WM_KEYDOWN.
		/// </param>
		/// <returns>
		/// Pointer to a BOOL that, on exit, indicates if the key event was handled. If this value receives <c>TRUE</c>, the key event
		/// was handled and the event should not be forwarded to the application. If this value is <c>FALSE</c>, the key event was not
		/// handled and the event should be forwarded to the application.
		/// </returns>
		/// <remarks>
		/// <para>
		/// If this method is successful and pfEaten receives <c>TRUE</c>, the application should not process the key down event. If
		/// this method does not return S_OK or pfEaten receives <c>FALSE</c>, the application should process the key down event. The
		/// following is an example of how this is implemented.
		/// </para>
		/// <para>
		/// <code> if(msg.message == WM_KEYDOWN) { if( pKeyboardMgr-&gt;TestKeyDown(msg.wParam, msg.lParam, &amp;fEaten) == S_OK &amp;&amp; fEaten &amp;&amp; pKeyboardMgr-&gt;KeyDown(msg.wParam, msg.lParam, &amp;fEaten) == S_OK &amp;&amp; fEaten) { //The key was handled by the keystroke manager or a TSF text service. Do not pass the key to the application. continue; } else { //Let the application process the key. } }</code>
		/// </para>
		/// <para>
		/// If the keystroke manager does not handle the key event, it passes the key event to TSF text services by calling the TSF text
		/// service ITfKeyEventSink::OnKeyDown method.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfkeystrokemgr-keydown HRESULT KeyDown( WPARAM wParam,
		// LPARAM lParam, BOOL *pfEaten );
		[return: MarshalAs(UnmanagedType.Bool)]
		bool KeyDown([In] WPARAM wParam, [In] LPARAM lParam);

		/// <summary>Passes a key up event to the keystroke manager.</summary>
		/// <param name="wParam">
		/// Specifies the virtual-key code of the key. For more information about this parameter, see the wParam parameter in WM_KEYUP.
		/// </param>
		/// <param name="lParam">
		/// Specifies the repeat count, scan code, extended-key flag, context code, previous key-state flag, and transition-state flag
		/// of the key. For more information about this parameter, see the lParam parameter in WM_KEYUP.
		/// </param>
		/// <returns>
		/// Pointer to a BOOL that, on exit, indicates if the key event will be handled. If this value receives <c>TRUE</c>, the key
		/// event would be handled and the event should not be forwarded to the application. If this value is <c>FALSE</c>, the key
		/// event would not be handled and the event should be forwarded to the application.
		/// </returns>
		/// <remarks>
		/// <para>
		/// If this method is successful and pfEaten receives <c>TRUE</c>, the application should not process the key down event. If
		/// this method does not return S_OK or pfEaten receives <c>FALSE</c>, the application should process the key down event. The
		/// following is an example of how this is implemented.
		/// </para>
		/// <para>
		/// <code> if(msg.message == WM_KEYUP) { if( pKeyboardMgr-&gt;TestKeyUp(msg.wParam, msg.lParam, &amp;fEaten) == S_OK &amp;&amp; fEaten &amp;&amp; pKeyboardMgr-&gt;KeyUp(msg.wParam, msg.lParam, &amp;fEaten) == S_OK &amp;&amp; fEaten) { //The key was handled by the keystroke manager or a TSF text service. Do not pass the key to the application. continue; } else { //Let the application process the key. } }</code>
		/// </para>
		/// <para>
		/// If the keystroke manager does not handle the key event, it passes the key event to the text services by a call to the text
		/// service ITfKeyEventSink::OnKeyUp method.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfkeystrokemgr-keyup HRESULT KeyUp( WPARAM wParam, LPARAM
		// lParam, BOOL *pfEaten );
		[return: MarshalAs(UnmanagedType.Bool)]
		bool KeyUp([In] WPARAM wParam, [In] LPARAM lParam);

		/// <summary>Obtains the command GUID for a preserved key.</summary>
		/// <param name="pic">Pointer to the application context. This value is returned by a previous call to ITfDocumentMgr::CreateContext.</param>
		/// <param name="pprekey">
		/// Pointer to a TF_PRESERVEDKEY structure that identifies the preserved key to obtain. The <c>uVKey</c> member contains the
		/// virtual key code and the <c>uModifiers</c> member identifies the modifiers of the preserved key. The <c>uVKey</c> member
		/// must be less than 256.
		/// </param>
		/// <returns>
		/// Pointer to a GUID value that receives the command GUID of the preserved key. This is the GUID passed in the TSF text service
		/// call to ITfKeystrokeMgr::PreserveKey. This value receives GUID_NULL if the preserved key is not found.
		/// </returns>
		/// <remarks>
		/// Preserved keys are registered by TSF text services and used to provide keyboard shortcuts to common commands implemented by
		/// the TSF text service.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfkeystrokemgr-getpreservedkey HRESULT GetPreservedKey(
		// ITfContext *pic, const TF_PRESERVEDKEY *pprekey, GUID *pguid );
		Guid GetPreservedKey([In] ITfContext pic, in TF_PRESERVEDKEY pprekey);

		/// <summary>Determines if a command GUID and key combination is a preserved key.</summary>
		/// <param name="rguid">
		/// Specifies the command GUID of the preserved key. This is the GUID passed in the text service call to ITfKeystrokeMgr::PreserveKey.
		/// </param>
		/// <param name="pprekey">
		/// Pointer to a TF_PRESERVEDKEY structure that identifies the preserved key. The <c>uVKey</c> member contains the virtual key
		/// code and the <c>uModifiers</c> member identifies the modifiers of the preserved key. The <c>uVKey</c> member must be less
		/// than 256.
		/// </param>
		/// <returns>
		/// Pointer to a BOOL that receives <c>TRUE</c> if the command GUID and key combination is a registered preserved key, or
		/// <c>FALSE</c> otherwise.
		/// </returns>
		/// <remarks>
		/// Preserved keys are registered by TSF text services and provide keyboard shortcuts to common commands implemented by the TSF
		/// text service.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfkeystrokemgr-ispreservedkey HRESULT IsPreservedKey(
		// REFGUID rguid, const TF_PRESERVEDKEY *pprekey, BOOL *pfRegistered );
		[return: MarshalAs(UnmanagedType.Bool)]
		bool IsPreservedKey(in Guid rguid, in TF_PRESERVEDKEY pprekey);

		/// <summary>Registers a preserved key.</summary>
		/// <param name="tid">
		/// Contains the client identifier of the TSF text service. This value is passed to the TSF text service in its
		/// ITfTextInputProcessor::Activate method.
		/// </param>
		/// <param name="rguid">
		/// Contains the command GUID of the preserved key. This value is passed to the TSF text service ITfKeyEventSink::OnPreservedKey
		/// method to identify the preserved key when the preserved key is activated.
		/// </param>
		/// <param name="prekey">
		/// Pointer to a TF_PRESERVEDKEY structure that specifies the preserved key. The <c>uVKey</c> member contains the virtual key
		/// code and the <c>uModifiers</c> member identifies the modifiers of the preserved key.
		/// </param>
		/// <param name="pchDesc">
		/// Pointer to a Unicode string that contains the description of the preserved key. This cannot be <c>NULL</c> unless cchDesc is zero.
		/// </param>
		/// <param name="cchDesc">
		/// Specifies the number of characters in pchDesc. Pass zero for this parameter if no description is required.
		/// </param>
		/// <remarks>
		/// Preserved keys are registered by TSF text services and provide keyboard shortcuts to common commands implemented by the TSF
		/// text service.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfkeystrokemgr-preservekey HRESULT PreserveKey( TfClientId
		// tid, REFGUID rguid, const TF_PRESERVEDKEY *prekey, const WCHAR *pchDesc, ULONG cchDesc );
		void PreserveKey([In] TfClientId tid, in Guid rguid, in TF_PRESERVEDKEY prekey, [In, MarshalAs(UnmanagedType.LPWStr)] string pchDesc, uint cchDesc);

		/// <summary>Unregisters a preserved key.</summary>
		/// <param name="rguid">Contains the command GUID of the preserved key.</param>
		/// <param name="pprekey">
		/// Pointer to a TF_PRESERVEDKEY structure that specifies the preserved key. The uVKey member contains the virtual key code and
		/// the uModifiers member identifies the modifiers of the preserved key.
		/// </param>
		/// <remarks>
		/// Preserved keys are registered by TSF text services and provide keyboard shortcuts to common commands implemented by the TSF
		/// text service.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfkeystrokemgr-unpreservekey HRESULT UnpreserveKey(
		// REFGUID rguid, const TF_PRESERVEDKEY *pprekey );
		void UnpreserveKey(in Guid rguid, in TF_PRESERVEDKEY pprekey);

		/// <summary>Modifies the description string of an existing preserved key.</summary>
		/// <param name="rguid">Contains the command GUID of the preserved key.</param>
		/// <param name="pchDesc">
		/// Pointer to a Unicode string that contains the new description of the preserved key. This cannot be <c>NULL</c> unless
		/// cchDesc is zero.
		/// </param>
		/// <param name="cchDesc">Number of characters in pchDesc. Pass zero for this parameter if no description is required.</param>
		/// <remarks>
		/// Preserved keys are registered by TSF text services and provide keyboard shortcuts to common commands implemented by the TSF
		/// text service.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfkeystrokemgr-setpreservedkeydescription HRESULT
		// SetPreservedKeyDescription( REFGUID rguid, const WCHAR *pchDesc, ULONG cchDesc );
		void SetPreservedKeyDescription(in Guid rguid, [In, MarshalAs(UnmanagedType.LPWStr)] string pchDesc, uint cchDesc);

		/// <summary>Obtains the description string of an existing preserved key.</summary>
		/// <param name="rguid">Contains the command GUID of the preserved key.</param>
		/// <returns>Pointer to a BSTR value the receives the description string. The caller must free this memory using SysFreeString.</returns>
		/// <remarks>
		/// Preserved keys are registered by TSF text services and provide keyboard shortcuts to common commands implemented by the TSF
		/// text service.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfkeystrokemgr-getpreservedkeydescription HRESULT
		// GetPreservedKeyDescription( REFGUID rguid, BSTR *pbstrDesc );
		[return: MarshalAs(UnmanagedType.BStr)]
		string GetPreservedKeyDescription(in Guid rguid);

		/// <summary>Simulates the execution of a preserved key sequence.</summary>
		/// <param name="pic">Pointer to the application context. This value was returned by a previous call to ITfDocumentMgr::CreateContext.</param>
		/// <param name="rguid">Contains the command GUID of the preserved key.</param>
		/// <param name="pfEaten">
		/// Pointer to a BOOL that indicates if the key event was handled. If this value receives <c>TRUE</c>, the key event was
		/// handled. If this value is <c>FALSE</c>, the key event was not handled.
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfkeystrokemgr-simulatepreservedkey HRESULT
		// SimulatePreservedKey( ITfContext *pic, REFGUID rguid, BOOL *pfEaten );
		void SimulatePreservedKey([In] ITfContext pic, in Guid rguid, [Out, MarshalAs(UnmanagedType.Bool)] out bool pfEaten);
	}

	/// <summary>
	/// The <c>ITfKeyTraceEventSink</c> interface is implemented by an application or text service to receive key stroke event
	/// notifications before the event is processed by the target. This advise sink is installed by calling the thread manager
	/// ITfSource::AdviseSink method with IID_ITfKeyTraceEventSink.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The difference between <c>ITfKeyTraceEventSink</c> and ITfKeyEventSink events is that <c>ITfKeyTraceEventSink</c> events occur
	/// before any filtering or processing of the key event occurs. The <c>ITfKeyTraceEventSink</c> events also occur before the target
	/// application can process the key event.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// <code> HRESULT hr; ITfSource *pSource; hr = pThreadMgr-&gt;QueryInterface(IID_ITfSource, (LPVOID*)&amp;pSource); if(SUCCEEDED(hr)) { hr = pSource-&gt;AdviseSink(IID_ITfKeyTraceEventSink, pKeyTraceEventSink, &amp;m_dwKeyTraveEventSinkCookie); pSource-&gt;Release(); }</code>
	/// </para>
	/// <para>
	/// <code> HRESULT hr; ITfSource *pSource; hr = pThreadMgr-&gt;QueryInterface(IID_ITfSource, (LPVOID*)&amp;pSource); if(SUCCEEDED(hr)) { hr = pSource-&gt;UnadviseSink(m_dwKeyTraveEventSinkCookie); pSource-&gt;Release(); }</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-itfkeytraceeventsink
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.ITfKeyTraceEventSink")]
	[ComImport, Guid("1CD4C13B-1C36-4191-A70A-7F3E611F367D"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ITfKeyTraceEventSink
	{
		/// <summary>Called when a key down event occurs.</summary>
		/// <param name="wParam">
		/// The WPARAM of the key event. For more information about this parameter, see the wParam parameter in WM_KEYDOWN.
		/// </param>
		/// <param name="lParam">
		/// The LPARAM of the key event. For more information about this parameter, see the lParam parameter in WM_KEYDOWN.
		/// </param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfkeytraceeventsink-onkeytracedown HRESULT OnKeyTraceDown(
		// WPARAM wParam, LPARAM lParam );
		[PreserveSig]
		HRESULT OnKeyTraceDown([In] WPARAM wParam, [In] LPARAM lParam);

		/// <summary>Called when a key up event occurs.</summary>
		/// <param name="wParam">
		/// The WPARAM of the key event. For more information about this parameter, see the wParam parameter in WM_KEYUP.
		/// </param>
		/// <param name="lParam">
		/// The LPARAM of the key event. For more information about this parameter, see the lParam parameter in WM_KEYUP.
		/// </param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfkeytraceeventsink-onkeytraceup HRESULT OnKeyTraceUp(
		// WPARAM wParam, LPARAM lParam );
		[PreserveSig]
		HRESULT OnKeyTraceUp([In] WPARAM wParam, [In] LPARAM lParam);
	}

	/// <summary>
	/// <para>
	/// The <c>ITfLanguageProfileNotifySink</c> interface is implemented by an application to receive notifications when the language
	/// profile changes.
	/// </para>
	/// <para>
	/// To install this advise sink, obtain an ITfSource object from an ITfInputProcessorProfiles object by calling
	/// <c>ITfInputProcessorProfiles::QueryInterface</c> with <c>IID_ITfSource</c>. Then call ITfSource::AdviseSink with <c>IID_ITfLanguageProfileNotifySink</c>.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-itflanguageprofilenotifysink
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.ITfLanguageProfileNotifySink")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("43C9FE15-F494-4C17-9DE2-B8A4AC350AA8")]
	public interface ITfLanguageProfileNotifySink
	{
		/// <summary>Called when the language profile is about to change.</summary>
		/// <param name="langid">Contains a <c>LANGID</c> value the identifies the new language profile.</param>
		/// <param name="pfAccept">
		/// Pointer to a <c>BOOL</c> value that receives a flag that permits or prevents the language profile change. Receives zero to
		/// prevent the language profile change or nonzero to permit the language profile change.
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
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itflanguageprofilenotifysink-onlanguagechange HRESULT
		// OnLanguageChange( LANGID langid, BOOL *pfAccept );
		[PreserveSig]
		HRESULT OnLanguageChange([In] LANGID langid, [Out, MarshalAs(UnmanagedType.Bool)] out bool pfAccept);

		/// <summary>Called after the language profile has changed.</summary>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itflanguageprofilenotifysink-onlanguagechanged HRESULT OnLanguageChanged();
		[PreserveSig]
		HRESULT OnLanguageChanged();
	}

	/// <summary>
	/// The <c>ITfMessagePump</c> interface is implemented by the TSF manager and is used by an application to obtain messages from the
	/// application message queue. The methods of this interface are wrappers for the GetMessage and PeekMessage functions. This
	/// interface enables the TSF manager to perform any necessary pre-message or post-message processing.
	/// </summary>
	/// <remarks>
	/// <para>
	/// If the application is Unicode, it should use the PeekMessageW and GetMessageW methods. Otherwise, the application should use the
	/// PeekMessageA and GetMessageA methods.
	/// </para>
	/// <para>Examples</para>
	/// <para>ITfThreadMgr</para>
	/// <para>
	/// <code> HRESULT hr; ITfMessagePump *pMessagePump; hr = pThreadManager-&gt;QueryInterface(IID_ITfMessagePump, (LPVOID*)&amp;pMessagePump); if(SUCCEEDED(hr)) { //Use the ITfMessagePump interface. //Release the ITfMessagePump interface. pMessagePump-&gt;Release(); }</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-itfmessagepump
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.ITfMessagePump")]
	[ComImport, Guid("8F1B8AD8-0B6B-4874-90C5-BD76011E8F7C"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ITfMessagePump
	{
		/// <summary>
		/// Obtains a message from the message queue and returns if no message is obtained. This is the ANSI version of this method.
		/// </summary>
		/// <param name="pMsg">Pointer to a MSG structure that receives message data.</param>
		/// <param name="hwnd">
		/// Handle to the window whose messages are obtained. The window must belong to the current thread. If this value is
		/// <c>NULL</c>, this method obtains messages for any window owned by the calling thread.
		/// </param>
		/// <param name="wMsgFilterMin">Specifies the lowest message value to obtain.</param>
		/// <param name="wMsgFilterMax">Specifies the highest message value to obtain.</param>
		/// <param name="wRemoveMsg">Specifies how messages are handled. For more information, see the <c>PeekMessage</c> function.</param>
		/// <returns>Pointer to a BOOL that receives the return value from the <c>PeekMessage</c> function.</returns>
		/// <remarks>
		/// If wMsgFilterMin and wMsgFilterMax are both zero, this method returns all available messages; that is, no range filtering is performed.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfmessagepump-peekmessagea HRESULT PeekMessageA( LPMSG
		// pMsg, HWND hwnd, UINT wMsgFilterMin, UINT wMsgFilterMax, UINT wRemoveMsg, BOOL *pfResult );
		[return: MarshalAs(UnmanagedType.Bool)]
		bool PeekMessageA(out MSG pMsg, [In, Optional] HWND hwnd, [In, Optional] uint wMsgFilterMin, [In, Optional] uint wMsgFilterMax, User32.PM wRemoveMsg);

		/// <summary>
		/// Obtains a message from the message queue and does not return until a message is obtained. This is the ANSI version of this method.
		/// </summary>
		/// <param name="pMsg">Pointer to a MSG structure that receives message data.</param>
		/// <param name="hwnd">
		/// Handle to the window whose messages are obtained. The window must belong to the current thread. If this value is
		/// <c>NULL</c>, this method obtains messages for any window that belongs to the calling thread.
		/// </param>
		/// <param name="wMsgFilterMin">Specifies the lowest message value obtained.</param>
		/// <param name="wMsgFilterMax">Specifies the highest message value obtained.</param>
		/// <returns>Pointer to a BOOL value that receives the return value from the <c>GetMessage</c> function.</returns>
		/// <remarks>
		/// If wMsgFilterMin and wMsgFilterMax are both zero, this method returns all available messages; that is, no range filtering is performed.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfmessagepump-getmessagea HRESULT GetMessageA( LPMSG pMsg,
		// HWND hwnd, UINT wMsgFilterMin, UINT wMsgFilterMax, BOOL *pfResult );
		[return: MarshalAs(UnmanagedType.Bool)]
		bool GetMessageA(out MSG pMsg, [In, Optional] HWND hwnd, [In, Optional] uint wMsgFilterMin, [In, Optional] uint wMsgFilterMax);

		/// <summary>
		/// Obtains a message from the message queue and returns if no message is obtained. This is the Unicode version of this method.
		/// </summary>
		/// <param name="pMsg">Pointer to a MSG structure that receives message data.</param>
		/// <param name="hwnd">
		/// Handle to the window whose messages are obtained. The window must belong to the current thread. If this value is
		/// <c>NULL</c>, this method obtains messages for any window that belongs to the calling thread.
		/// </param>
		/// <param name="wMsgFilterMin">Specifies the lowest message value to obtain.</param>
		/// <param name="wMsgFilterMax">Specifies the highest message value to obtain.</param>
		/// <param name="wRemoveMsg">Specifies how messages are handled. For more information, see the <c>PeekMessage</c> function.</param>
		/// <returns>Pointer to a BOOL that receives the return value from the <c>PeekMessage</c> function.</returns>
		/// <remarks>
		/// If wMsgFilterMin and wMsgFilterMax are both zero, this method returns all available messages; that is, no range filtering is performed.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfmessagepump-peekmessagew HRESULT PeekMessageW( LPMSG
		// pMsg, HWND hwnd, UINT wMsgFilterMin, UINT wMsgFilterMax, UINT wRemoveMsg, BOOL *pfResult );
		[return: MarshalAs(UnmanagedType.Bool)]
		bool PeekMessageW(out MSG pMsg, [In, Optional] HWND hwnd, [In, Optional] uint wMsgFilterMin, [In, Optional] uint wMsgFilterMax, User32.PM wRemoveMsg);

		/// <summary>
		/// Obtains a message from the message queue and does not return until a message is obtained. This is the Unicode version of
		/// this method.
		/// </summary>
		/// <param name="pMsg">Pointer to a MSG structure that receives message data.</param>
		/// <param name="hwnd">
		/// Handle to the window whose messages are obtained. The window must belong to the current thread. If this value is
		/// <c>NULL</c>, this method obtains messages for any window owned by the calling thread.
		/// </param>
		/// <param name="wMsgFilterMin">Specifies the lowest message value to obtain.</param>
		/// <param name="wMsgFilterMax">Specifies the highest message value to obtain.</param>
		/// <returns>Pointer to a BOOL that receives the return value from the <c>GetMessage</c> function.</returns>
		/// <remarks>
		/// If wMsgFilterMin and wMsgFilterMax are both zero, this method returns all available messages; that is, no range filtering is performed.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfmessagepump-getmessagew HRESULT GetMessageW( LPMSG pMsg,
		// HWND hwnd, UINT wMsgFilterMin, UINT wMsgFilterMax, BOOL *pfResult );
		[return: MarshalAs(UnmanagedType.Bool)]
		bool GetMessageW(out MSG pMsg, [In, Optional] HWND hwnd, [In, Optional] uint wMsgFilterMin, [In, Optional] uint wMsgFilterMax);
	}

	/// <summary>
	/// The <c>ITfMouseSink</c> interface is implemented by a text service to receive mouse event notifications. A mouse event sink is
	/// installed with the ITfMouseTracker::AdviseMouseSink method of one of the ITfMouseTracker interfaces.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-itfmousesink
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.ITfMouseSink")]
	[ComImport, Guid("A1ADAAA2-3A24-449D-AC96-5183E7F5C217"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ITfMouseSink
	{
		/// <summary>Called when a mouse event occurs over a range of text.</summary>
		/// <param name="uEdge">
		/// Contains the offset, in characters, of the mouse position from the start of the range of text. For more information, see the
		/// Remarks section.
		/// </param>
		/// <param name="uQuadrant">
		/// Contains the zero-based quadrant index, relative to the edge, that the mouse position lies in. For more information, see the
		/// Remarks section.
		/// </param>
		/// <param name="dwBtnStatus">
		/// Indicates the mouse button state at the time of the event. See the wParam parameter of the WM_MOUSEMOVE message for possible values.
		/// </param>
		/// <param name="pfEaten">
		/// Pointer to a BOOL that, on exit, indicates if the mouse event was handled. If this value receives <c>TRUE</c>, the mouse
		/// event was handled. If this value is <c>FALSE</c>, the mouse event was not handled.
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
		/// The caller should translate double-click events into multiple mouse button down events. This enables a text service to
		/// detect double-click events even if the context window does not support double-clicks.
		/// </para>
		/// <para>
		/// uEdge contains the offset, in characters, of the mouse position from the start of the text range. The mouse position is
		/// always rounded to the closest edge. Each edge is divided into four equal quadrants with two quadrants preceding the edge and
		/// two quadrants following the edge. uQuadrant contains the zero-based quadrant index of the mouse position. In the figure
		/// below, point "X" is in quadrant 2 of edge 1 and point "Y" is in quadrant 1 of edge 3.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfmousesink-onmouseevent HRESULT OnMouseEvent( ULONG
		// uEdge, ULONG uQuadrant, DWORD dwBtnStatus, BOOL *pfEaten );
		[PreserveSig]
		HRESULT OnMouseEvent(uint uEdge, uint uQuadrant, MouseButtonState dwBtnStatus, [Out, MarshalAs(UnmanagedType.Bool)] out bool pfEaten);
	}

	/// <summary>
	/// The <c>ITfMouseTracker</c> interface is implemented by the TSF manager and is used by a text service to manage mouse event
	/// notification sinks. An instance of this interface is obtained by querying an ITfContext object for IID_ITfMouseTracker.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-itfmousetracker
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.ITfMouseTracker")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("09D146CD-A544-4132-925B-7AFA8EF322D0")]
	public interface ITfMouseTracker
	{
		/// <summary>Installs a mouse event sink.</summary>
		/// <param name="range">
		/// Pointer to an ITfRange interface that specifies the range of text that the mouse sink is installed for.
		/// </param>
		/// <param name="pSink">Pointer to the ITfMouseSink interface.</param>
		/// <param name="pdwCookie">Pointer to a DWORD value that receives a cookie that identifies the mouse event sink.</param>
		/// <remarks>
		/// <para>
		/// When the advise sink is installed, a mouse event that occurs over the range specified by range will result in the mouse
		/// event sink ITfMouseSink::OnMouseEvent call.
		/// </para>
		/// <para>
		/// The value placed in pdwCookie must be saved and passed to ITfMouseTracker::UnadviseMouseSink to remove the mouse event sink.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfmousetracker-advisemousesink HRESULT AdviseMouseSink(
		// ITfRange *range, ITfMouseSink *pSink, DWORD *pdwCookie );
		void AdviseMouseSink([In] ITfRange range, [In] ITfMouseSink pSink, out uint pdwCookie);

		/// <summary>Uninstalls a mouse event sink.</summary>
		/// <param name="dwCookie">Specifies the mouse advise sink identifier. This value is obtained by a call to ITfMouseTracker::AdviseMouseSink.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfmousetracker-unadvisemousesink HRESULT
		// UnadviseMouseSink( DWORD dwCookie );
		void UnadviseMouseSink(uint dwCookie);
	}

	/// <summary>
	/// The <c>ITfMouseTrackerACP</c> interface is implemented by an application to support mouse event sinks. This interface is used by
	/// the TSF manager to add and remove mouse event sinks in an ACP-based application. The TSF manager obtains this interface by
	/// calling the application's ITextStoreACP::QueryInterface with IID_ITfMouseTrackerACP.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-itfmousetrackeracp
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.ITfMouseTrackerACP")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("3BDD78E2-C16E-47FD-B883-CE6FACC1A208")]
	public interface ITfMouseTrackerACP
	{
		/// <summary>Called to install a mouse event sink.</summary>
		/// <param name="range">
		/// Pointer to an ITfRange interface that specifies the range of text that the mouse sink is installed for.
		/// </param>
		/// <param name="pSink">
		/// Pointer to the ITfMouseSink interface. The application must increment this object reference count and save the interface.
		/// </param>
		/// <param name="pdwCookie">Pointer to a DWORD that receives a cookie that identifies the mouse event sink.</param>
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
		/// <term>The application does not support mouse event sinks.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// When this advise sink is installed, a mouse event that occurs over the range specified by range will result in the mouse
		/// event sink ITfMouseSink::OnMouseEvent method being called.
		/// </para>
		/// <para>
		/// The value placed in pdwCookie will be saved by the caller and passed to the ITfMouseTrackerACP::UnadviseMouseSink method to
		/// remove the mouse event sink.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfmousetrackeracp-advisemousesink HRESULT AdviseMouseSink(
		// ITfRangeACP *range, ITfMouseSink *pSink, DWORD *pdwCookie );
		[PreserveSig]
		HRESULT AdviseMouseSink([In] ITfRangeACP range, [In] ITfMouseSink pSink, out uint pdwCookie);

		/// <summary>Called to remove a mouse event sink.</summary>
		/// <param name="dwCookie">Specifies the mouse advise sink identifier. This value is obtained by a call to ITfMouseTrackerACP::AdviseMouseSink.</param>
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
		/// <term>The application does not support mouse event sinks.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// The application must release the ITfMouseSink supplied in the <c>ITfMouseTrackerACP::AdviseMouseSink</c> call associated
		/// with dwCookie.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfmousetrackeracp-unadvisemousesink HRESULT
		// UnadviseMouseSink( DWORD dwCookie );
		[PreserveSig]
		HRESULT UnadviseMouseSink(uint dwCookie);
	}

	/// <summary>
	/// The <c>ITfPersistentPropertyLoaderACP</c> interface is implemented by an application and used by the TSF manager to load
	/// properties asynchronously. An application passes an instance of this interface when calling ITextStoreACPServices::Unserialize.
	/// When properties are loaded by a call to <c>ITextStoreACPServices::Unserialize</c> , this interface is used to load properties
	/// when required rather than all at once.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-itfpersistentpropertyloaderacp
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.ITfPersistentPropertyLoaderACP")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("4EF89150-0807-11D3-8DF0-00105A2799B5")]
	public interface ITfPersistentPropertyLoaderACP
	{
		/// <summary>Called to load a property.</summary>
		/// <param name="pHdr">
		/// Pointer to a TF_PERSISTENT_PROPERTY_HEADER_ACP structure that identifies the property to load. This structure contains the
		/// same data as the structure passed to ITextStoreACPServices::Unserialize.
		/// </param>
		/// <param name="ppStream">Pointer to an <c>IStream</c> interface pointer that receives the stream object.</param>
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
		/// <term>E_OUTOFMEMORY</term>
		/// <term>A memory allocation failure occurred.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Only property data is written to the stream. The header data is not written to the stream.</para>
		/// <para>
		/// Obtain the original position of the stream before writing to the stream. The original position should be restored in the
		/// stream before returning from this method.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfpersistentpropertyloaderacp-loadproperty HRESULT
		// LoadProperty( const TF_PERSISTENT_PROPERTY_HEADER_ACP *pHdr, IStream **ppStream );
		[PreserveSig]
		HRESULT LoadProperty(in TF_PERSISTENT_PROPERTY_HEADER_ACP pHdr, out IStream? ppStream);
	}

	/// <summary>
	/// The <c>ITfPreservedKeyNotifySink</c> interface is implemented by an application or TSF text service to receive notifications
	/// when keys are preserved, unpreserved, or when a preserved key description changes. This advise sink is installed by calling the
	/// TSF manager ITfSource::AdviseSink with IID_ITfPreservedKeyNotifySink.
	/// </summary>
	/// <remarks>Preserved keys are keyboard shortcuts that an application or TSF text service can register with the TSF manager.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-itfpreservedkeynotifysink
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.ITfPreservedKeyNotifySink")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("6F77C993-D2B1-446E-853E-5912EFC8A286")]
	public interface ITfPreservedKeyNotifySink
	{
		/// <summary>Called when a key is preserved, unpreserved, or when a preserved key description changes.</summary>
		/// <param name="pprekey">Pointer to a TF_PRESERVEDKEY structure that contains data about the key.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// To determine if the key is unpreserved, call ITfKeystrokeMgr::IsPreservedKey, passing pprekey. If the key is not found, it
		/// is unpreserved. If the key is found, it is either preserved or the description has changed. Unless you keep track of the
		/// current key description and compare the previous description with the current description in response to this notification,
		/// there is no way to determine if this notification is in response to a key preserved or the description changed.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfpreservedkeynotifysink-onupdated HRESULT OnUpdated(
		// const TF_PRESERVEDKEY *pprekey );
		[PreserveSig]
		HRESULT OnUpdated(in TF_PRESERVEDKEY pprekey);
	}

	/// <summary>
	/// The <c>ITfProperty</c> interface is implemented by the TSF manager and used by a client (application or text service) to modify
	/// a property value.
	/// </summary>
	/// <remarks>An instance of this interface is obtained in various ways, such as ITfContext::GetProperty or IEnumTfProperties::Next.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-itfproperty
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.ITfProperty")]
	[ComImport, Guid("E2449660-9542-11D2-BF46-00105A2799B5"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ITfProperty : ITfReadOnlyProperty
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
		new Guid GetType();

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
		new void EnumRanges([In] TfEditCookie ec, out IEnumTfRanges ppEnum, [In, Optional] ITfRange? pTargetRange);

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
		new object GetValue([In] TfEditCookie ec, [In] ITfRange pRange);

		/// <summary>Obtains the context object for the property.</summary>
		/// <returns>
		/// Pointer to an ITfContext interface pointer that receives the context object. The caller must release this object when it is
		/// no longer required.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfreadonlyproperty-getcontext HRESULT GetContext(
		// ITfContext **ppContext );
		new ITfContext GetContext();

		/// <summary>Obtains a range that covers the text that contains a non-empty value for the property.</summary>
		/// <param name="ec">
		/// Contains an edit cookie that identifies the edit context. This is obtained from ITfDocumentMgr::CreateContext or ITfEditSession::DoEditSession.
		/// </param>
		/// <param name="pRange">
		/// Pointer to an ITfRange interface that contains the point to obtain the property range for. The point will either be the
		/// start anchor or end anchor of this range, based upon the value of aPos.
		/// </param>
		/// <param name="ppRange">Pointer to an <c>ITfRange</c> interface pointer that receives the requested range object.</param>
		/// <param name="aPos">
		/// Contains one of the TfAnchor values which specifies which anchor of pRange is used as the point to obtain the property range for.
		/// </param>
		/// <remarks>
		/// <para>
		/// This method obtains a range of text that contains a non-empty value for the property. If the property has no value at the
		/// specified point, ppRange receives <c>NULL</c> and the method returns S_FALSE. In the following example, if aPos contains
		/// TF_ANCHOR_START, the returned range would contain "is". If aPos contains TF_ANCHOR_END, the method would return S_FALSE
		/// because the property does not exist at the end point of the range.
		/// </para>
		/// <para>
		/// <code> COLOR: RRRRR RR GGGGGGGG TEXT: this &lt;a&gt;is som&lt;/a&gt;e colored text</code>
		/// </para>
		/// <para>
		/// If aPos contains TF_ANCHOR_START, this method ignores property ranges that end immediately before the start anchor.
		/// Likewise, if aPos contains TF_ANCHOR_END, this method ignores property ranges that start immediately after the end anchor.
		/// In the following example, if aPos contains TF_ANCHOR_START, the returned range would contain "colored " and not "some "
		/// because the R value property ends at the start anchor point and the G value property begins at the start anchor. If aPos
		/// contains TF_ANCHOR_END, the returned range would contain "colored " and not "text".
		/// </para>
		/// <para>
		/// <code> COLOR: RRRRR GGGGGGGG BBBB TEXT: this is some &lt;a&gt;colored &lt;/a&gt;text</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfproperty-findrange HRESULT FindRange( TfEditCookie ec,
		// ITfRange *pRange, ITfRange **ppRange, TfAnchor aPos );
		void FindRange([In] TfEditCookie ec, [In] ITfRange pRange, out ITfRange? ppRange, [In] TfAnchor aPos);

		/// <summary>Sets the value of the property for a range of text using a property store object.</summary>
		/// <param name="ec">
		/// Contains an edit cookie that identifies the edit context. This is obtained from ITfDocumentMgr::CreateContext or ITfEditSession::DoEditSession.
		/// </param>
		/// <param name="pRange">
		/// Pointer to an ITfRange interface that contains the range that the property value is set for. This parameter cannot be
		/// <c>NULL</c>. This method fails if pRange is empty.
		/// </param>
		/// <param name="pPropStore">Pointer to an ITfPropertyStore interface that obtains the property data.</param>
		/// <remarks>
		/// <para>
		/// Property values set with ITfProperty::SetValue will be discarded when the text that the property value covers is modified.
		/// To gain control over what happens to a property value when the text is modified, use <c>ITfProperty::SetValueStore</c> .
		/// </para>
		/// <para>
		/// Values set with <c>ITfProperty::SetValue</c> will be serialized, except for values of type VT_UNKNOWN, which are not
		/// serialized. If a property value of type VT_UNKNOWN must be serialized, use <c>ITfProperty::SetValueStore</c> instead.
		/// </para>
		/// <para>Overlapping property values of the same type are unsupported.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfproperty-setvaluestore HRESULT SetValueStore(
		// TfEditCookie ec, ITfRange *pRange, ITfPropertyStore *pPropStore );
		void SetValueStore([In] TfEditCookie ec, [In] ITfRange pRange, [In] ITfPropertyStore pPropStore);

		/// <summary>Sets the value of the property for a range.</summary>
		/// <param name="ec">
		/// Contains an edit cookie that identifies the edit context. This is obtained from ITfDocumentMgr::CreateContext or ITfEditSession::DoEditSession.
		/// </param>
		/// <param name="pRange">
		/// Pointer to an ITfRange interface that contains the range that the property value is set for. This parameter cannot be
		/// <c>NULL</c>. This method will fail if pRange is empty.
		/// </param>
		/// <param name="pvarValue">
		/// Pointer to a <c>VARIANT</c> structure that contains the new property value. Only values of type VT_I4, VT_UNKNOWN, VT_BSTR
		/// and VT_EMPTY are supported.
		/// </param>
		/// <remarks>
		/// <para>
		/// Property values set with this method will be discarded when the text that the property value covers is modified. To gain
		/// custom control over a value response to text edits, use ITfProperty::SetValueStore.
		/// </para>
		/// <para>
		/// Values set with this method are serialized, except for values of type VT_UNKNOWN, which are not serialized. If a property
		/// value of type VT_UNKNOWN must be serialized, use <c>ITfProperty::SetValueStore</c> instead.
		/// </para>
		/// <para>Overlapping property values of the same type are unsupported.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfproperty-setvalue HRESULT SetValue( TfEditCookie ec,
		// ITfRange *pRange, const VARIANT *pvarValue );
		void SetValue([In] TfEditCookie ec, [In] ITfRange pRange, [In, MarshalAs(UnmanagedType.Struct)] object pvarValue);

		/// <summary>Empties the property value over the specified range.</summary>
		/// <param name="ec">
		/// Contains an edit cookie that identifies the edit context. This is obtained from ITfDocumentMgr::CreateContext or ITfEditSession::DoEditSession.
		/// </param>
		/// <param name="pRange">
		/// Pointer to an ITfRange interface that contains the range that the property is cleared for. If this parameter is <c>NULL</c>,
		/// all values for this property over the entire edit context are cleared.
		/// </param>
		/// <remarks>
		/// It is not necessary to call this method when a context is about to be destroyed. The TSF manager will clear all properties
		/// when the context is removed from the context stack.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfproperty-clear HRESULT Clear( TfEditCookie ec, ITfRange
		// *pRange );
		void Clear([In] TfEditCookie ec, [In, Optional] ITfRange? pRange);
	}

	/// <summary>
	/// The <c>ITfPropertyStore</c> interface is implemented by a text service and used by the TSF manager to provide non-static
	/// property values. An instance of this interface is passed to ITfProperty::SetValueStore.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-itfpropertystore
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.ITfPropertyStore")]
	[ComImport, Guid("6834B120-88CB-11D2-BF45-00105A2799B5"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ITfPropertyStore
	{
		/// <summary>Obtains the property identifier.</summary>
		/// <param name="pguid">Pointer to a <c>GUID</c> value that receives the property identifier.</param>
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
		/// <term>pguid is invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>An unspecified error occurred.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfpropertystore-gettype HRESULT GetType( GUID *pguid );
		[PreserveSig]
		HRESULT GetType(out Guid pguid);

		/// <summary>This method is reserved, but must be implemented.</summary>
		/// <param name="pdwReserved">
		/// Pointer to a <c>DWORD</c> value the receives the data type. This parameter is reserved and must be set to zero.
		/// </param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfpropertystore-getdatatype HRESULT GetDataType( DWORD
		// *pdwReserved );
		[PreserveSig]
		HRESULT GetDataType(out uint pdwReserved);

		/// <summary>Obtains the property store data.</summary>
		/// <param name="pvarValue">Pointer to a <c>VARIANT</c> value that receives property data.</param>
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
		/// <term>pvarValue is invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>An unspecified error occurred.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfpropertystore-getdata HRESULT GetData( VARIANT
		// *pvarValue );
		[PreserveSig]
		HRESULT GetData([Out, MarshalAs(UnmanagedType.Struct)] out object pvarValue);

		/// <summary>Called when the text that the property store applies to is modified.</summary>
		/// <param name="dwFlags">
		/// <para>
		/// Contains a set of flags that provide additional information about the text change. This can be zero or the following value.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TF_TU_CORRECTION</term>
		/// <term>
		/// The text change is the result of a correction. This implies that the semantics of the text have not changed. An example of
		/// this is when the spelling checker corrects a misspelled word.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pRangeNew">Pointer to an ITfRange interface that contains the range of text modified.</param>
		/// <param name="pfAccept">
		/// Pointer to a <c>BOOL</c> variable that receives a value that indicates if the property store should be retained. Receives a
		/// nonzero value if the property store should be retained or zero if the property store should be discarded. If the property
		/// store is discarded, the TSF manager will set the property value to VT_EMPTY and release the property store.
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
		/// <remarks>If this method returns any value other than S_OK, the property store is discarded.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfpropertystore-ontextupdated HRESULT OnTextUpdated( DWORD
		// dwFlags, ITfRange *pRangeNew, BOOL *pfAccept );
		[PreserveSig]
		HRESULT OnTextUpdated(uint dwFlags, [In] ITfRange pRangeNew, [Out, MarshalAs(UnmanagedType.Bool)] out bool pfAccept);

		/// <summary>Called when the text that the property store applies to is truncated.</summary>
		/// <param name="pRangeNew">Pointer to an ITfRange interface that contains the truncated range.</param>
		/// <param name="pfFree">
		/// Pointer to a <c>BOOL</c> variable that receives a value that indicates if the property store should be retained. Receives a
		/// nonzero value if the property store should be retained or zero if the property store should be discarded. If the property
		/// store is discarded, the TSF manager will set the property value to VT_EMPTY and release the property store.
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
		/// <remarks>If this method returns a value other than S_OK, the property store is discarded.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfpropertystore-shrink HRESULT Shrink( ITfRange
		// *pRangeNew, BOOL *pfFree );
		[PreserveSig]
		HRESULT Shrink([In] ITfRange pRangeNew, [Out, MarshalAs(UnmanagedType.Bool)] out bool pfFree);

		/// <summary>Called when the text covered by the property is split into two ranges.</summary>
		/// <param name="pRangeThis">
		/// Pointer to an ITfRange object that contains the range that the property store now covers. This will be the range of text
		/// closest to the beginning of the context.
		/// </param>
		/// <param name="pRangeNew">
		/// Pointer to an ITfRange object that contains the range that the new property store will cover. This will be the range of text
		/// closest to the end of the context.
		/// </param>
		/// <param name="ppPropStore">
		/// Pointer to an ITfPropertyStore interface pointer that receives a new property store object that will cover the range
		/// specified by pRangeNew.
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
		/// This method creates a new property store object to cover pRangeNew and returns the pointer to this object in ppPropStore. If
		/// no new property store is returned, the original property store is discarded and the property store for both ranges is set to empty.
		/// </para>
		/// <para>If this method returns any value other than S_OK, the original property store is discarded.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfpropertystore-divide HRESULT Divide( ITfRange
		// *pRangeThis, ITfRange *pRangeNew, ITfPropertyStore **ppPropStore );
		[PreserveSig]
		HRESULT Divide([In] ITfRange pRangeThis, [In] ITfRange pRangeNew, out ITfPropertyStore ppPropStore);

		/// <summary>Creates an exact copy of the property store object.</summary>
		/// <param name="pPropStore">Pointer to an ITfPropertyStore interface pointer that receives the new property store object.</param>
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
		/// </list>
		/// </returns>
		/// <remarks>
		/// This method creates a new property store object and initializes the new object so that it will operate as an exact copy of
		/// the original property store object. The new object must be completely independent of the original object.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfpropertystore-clone HRESULT Clone( ITfPropertyStore
		// **pPropStore );
		[PreserveSig]
		HRESULT Clone(out ITfPropertyStore pPropStore);

		/// <summary>Obtains the class identifier of the property store owner.</summary>
		/// <param name="pclsid">
		/// Pointer to a <c>CLSID</c> that receives the class identifier of the registered text service that implements
		/// ITfCreatePropertyStore. The method can return CLSID_NULL for this parameter if property store persistence is unsupported.
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
		/// When the property store is unserialized, the TSF manager creates an object of this CLSID and obtains an
		/// <c>ITfCreatePropertyStore</c> interface pointer from it. The manager then uses the <c>ITfCreatePropertyStore</c> object to
		/// create the property store object.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfpropertystore-getpropertyrangecreator HRESULT
		// GetPropertyRangeCreator( CLSID *pclsid );
		[PreserveSig]
		HRESULT GetPropertyRangeCreator(out Guid pclsid);

		/// <summary>Called to write the property store data into a stream for serialization.</summary>
		/// <param name="pStream">Pointer to an <c>IStream</c> object that the property store data is written to.</param>
		/// <param name="pcb">Pointer to a <c>ULONG</c> value that receives the number of bytes written to the stream.</param>
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
		/// <remarks>
		/// The method must not move the stream insertion point before writing to the stream. The method must leave the insertion point
		/// at the end of the data written by the method.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfpropertystore-serialize HRESULT Serialize( IStream
		// *pStream, ULONG *pcb );
		[PreserveSig]
		HRESULT Serialize([In] IStream pStream, out uint pcb);
	}

	/// <summary>
	/// The <c>ITfQueryEmbedded</c> interface is implemented by the TSF manager and used by a text service to determine if a context can
	/// accept an embedded object.
	/// </summary>
	/// <remarks>
	/// <para>To obtain an instance of this interface, call the <c>ITfContext::QueryInterface</c> method with IID_ITfQueryEmbedded.</para>
	/// <para>Examples</para>
	/// <para>ITfContext</para>
	/// <para>
	/// <code> HRESULT hr; ITfQueryEmbedded *pQueryEmbedded; hr = pContext-&gt;QueryInterface(IID_ITfQueryEmbedded, (LPVOID*)&amp;pQueryEmbedded); if(SUCCEEDED(hr)) { //Use the ITfQueryEmbedded interface. pQueryEmbedded-&gt;Release(); }</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-itfqueryembedded
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.ITfQueryEmbedded")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("0FAB9BDB-D250-4169-84E5-6BE118FDD7A8")]
	public interface ITfQueryEmbedded
	{
		/// <summary>Determines if the active context can accept an embedded object.</summary>
		/// <param name="pguidService">
		/// A GUID that identifies the service associated with the object. This value can be <c>NULL</c> if pFormatEtc is valid.
		/// </param>
		/// <param name="pFormatEtc">
		/// Pointer to a FORMATETC structure that contains data about the object to be embedded. This value can be <c>NULL</c> if
		/// pguidService is valid.
		/// </param>
		/// <returns>
		/// Pointer to a Boolean value that receives the query result. This value receives a nonzero value if the object can be
		/// embedded, or zero otherwise.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfqueryembedded-queryinsertembedded HRESULT
		// QueryInsertEmbedded( const GUID *pguidService, const FORMATETC *pFormatEtc, BOOL *pfInsertable );
		[return: MarshalAs(UnmanagedType.Bool)]
		unsafe bool QueryInsertEmbedded([In, Optional] Guid* pguidService, [In, Optional] FORMATETC* pFormatEtc);
	}

	/// <summary>
	/// The <c>ITfRange</c> interface is used by text services and applications to reference and manipulate text within a given context.
	/// The interface ID is IID_ITfRange.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The TSF manager implements this interface. For more information about ranges, anchors, embedded objects, and other text
	/// properties used by TSF, see Ranges, Embedded Objects, and other topics within Using Text Services Framework.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// Once an ITfComposition composition object is instantiated, a pointer to an <c>ITfRange</c> interface pointer can be obtained by
	/// calling the ITfComposition::GetRange method, as shown in the following code example.
	/// </para>
	/// <para>
	/// <code> HRESULT hr; ITfComposition *pComposition; ITfRange *pRange; WCHAR *achBuffer[64]; // Buffer to receive text. ULONG cch; hr = pComposition-&gt;GetRange(&amp;pRange); if(SUCCEEDED(hr)) { // Loop to scan text: do { cch = ARRAYSIZE(achBuffer); hr = pRange-&gt;GetText(ec, TF_TF_MOVESTART | TF_TF_IGNOREEND, achBuffer, cch, &amp;cch); if(SUCCEEDED(hr)) { // Do something with the text. pRange-&gt;Release(); } } while (cch == ARRAYSIZE(achBuffer)); pComposition-&gt;Release(); }</code>
	/// </para>
	/// <para>A pointer to a current <c>ITfRange</c> object can be obtained from the &lt;range&gt; element of the TF_SELECTION structure.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-itfrange
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.ITfRange")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("AA80E7FF-2021-11D2-93E0-0060B067B86E")]
	public interface ITfRange
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
		void GetText([In] TfEditCookie ec, [In] TF_TF dwFlags, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pchText, uint cchMax, out uint pcch);

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
		void SetText([In] TfEditCookie ec, [In] TF_ST dwFlags, [In, MarshalAs(UnmanagedType.LPWStr)] string pchText, int cch);

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
		IDataObject GetFormattedText([In] TfEditCookie ec);

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
		object? GetEmbedded([In] TfEditCookie ec, in Guid rguidService, in Guid riid);

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
		void InsertEmbedded([In] TfEditCookie ec, [In] TF_IE dwFlags, [In] IDataObject pDataObject);

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
		void ShiftStart([In] TfEditCookie ec, int cchReq, out int pcch, [In, Optional] TF_HALTCOND pHalt);

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
		void ShiftEnd([In] TfEditCookie ec, int cchReq, out int pcch, [In, Optional] TF_HALTCOND pHalt);

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
		void ShiftStartToRange([In] TfEditCookie ec, [In] ITfRange pRange, [In] TfAnchor aPos);

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
		void ShiftEndToRange([In] TfEditCookie ec, [In] ITfRange pRange, [In] TfAnchor aPos);

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
		bool ShiftStartRegion([In] TfEditCookie ec, [In] TfShiftDir dir);

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
		bool ShiftEndRegion([In] TfEditCookie ec, [In] TfShiftDir dir);

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
		bool IsEmpty([In] TfEditCookie ec);

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
		void Collapse([In] TfEditCookie ec, [In] TfAnchor aPos);

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
		bool IsEqualStart([In] TfEditCookie ec, [In] ITfRange pWith, [In] TfAnchor aPos);

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
		bool IsEqualEnd([In] TfEditCookie ec, [In] ITfRange pWith, [In] TfAnchor aPos);

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
		int CompareStart([In] TfEditCookie ec, [In] ITfRange pWith, [In] TfAnchor aPos);

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
		int CompareEnd([In] TfEditCookie ec, [In] ITfRange pWith, [In] TfAnchor aPos);

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
		bool AdjustForInsert([In] TfEditCookie ec, uint cchInsert);

		/// <summary>Obtains the gravity of the anchors in the object.</summary>
		/// <param name="pgStart">Pointer to a TfGravity value that receives the gravity of the start anchor.</param>
		/// <param name="pgEnd">Pointer to a <c>TfGravity</c> value that receives the gravity of the end anchor.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfrange-getgravity HRESULT GetGravity( TfGravity *pgStart,
		// TfGravity *pgEnd );
		void GetGravity(out TfGravity pgStart, out TfGravity pgEnd);

		/// <summary>Sets the gravity of the anchors in the object.</summary>
		/// <param name="ec">
		/// Contains an edit cookie that identifies the edit context obtained from ITfDocumentMgr::CreateContext or ITfEditSession::DoEditSession.
		/// </param>
		/// <param name="gStart">Contains one of the TfGravity values that specifies the gravity of the start anchor.</param>
		/// <param name="gEnd">Contains one of the <c>TfGravity</c> values that specifies the gravity of the end anchor.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfrange-setgravity HRESULT SetGravity( TfEditCookie ec,
		// TfGravity gStart, TfGravity gEnd );
		void SetGravity([In] TfEditCookie ec, [In] TfGravity gStart, [In] TfGravity gEnd);

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
		ITfRange Clone();

		/// <summary>Obtains the context object to which the range belongs.</summary>
		/// <returns>Pointer to an ITfContext interface pointer that receives the context object that the range belongs to.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfrange-getcontext HRESULT GetContext( ITfContext
		// **ppContext );
		ITfContext GetContext();
	}

	/// <summary>Obtains the specified function object.</summary>
	/// <typeparam name="T">The type of the requested function within the group specified by rguid.</typeparam>
	/// <param name="fp">The ITfFunctionProvider instance.</param>
	/// <param name="rguid">
	/// Contains a GUID value that identifies the function group that the requested function belongs to. This value can be GUID_NULL.
	/// </param>
	/// <returns>An interface of <typeparamref name="T"/> that receives the requested function interface.</returns>
	public static T? GetFunction<T>(this ITfFunctionProvider fp, Guid rguid = default) where T : class
	{
		HRESULT hr = fp.GetFunction(rguid, typeof(T).GUID, out var obj);
		return hr.Succeeded ? (T)obj! : (hr == HRESULT.E_NOINTERFACE ? null : throw hr.GetException()!);
	}

	/// <summary>The <c>ITfRange::GetText</c> method obtains the content covered by this range of text.</summary>
	/// <param name="range">The ITfRange instance.</param>
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
	/// Method attempts to fill pchText with the maximum number of characters, instead of halting the copy at the position occupied by
	/// the end anchor of the range.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>The text in the range.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfrange-gettext HRESULT GetText( TfEditCookie ec, DWORD
	// dwFlags, WCHAR *pchText, ULONG cchMax, ULONG *pcch );
	public static string GetText(this ITfRange range, [In] TfEditCookie ec, TF_TF dwFlags = 0)
	{
		var sb = new StringBuilder(Kernel32.MAX_PATH * 2);
		range.GetText(ec, dwFlags, sb, (uint)sb.Capacity, out var len);
		sb.Length = (int)len;
		return sb.ToString();
	}
}