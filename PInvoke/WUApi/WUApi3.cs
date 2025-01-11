namespace Vanara.PInvoke;

/// <summary>PInvoke API (methods, structures and constants) imported from Windows Update API.</summary>
public static partial class WUApi
{
	/// <summary>Represents the download content of an update.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nn-wuapi-iupdatedownloadcontent
	[PInvokeData("wuapi.h", MSDNShortId = "NN:wuapi.IUpdateDownloadContent")]
	[ComImport, Guid("54A2CB2D-9A0C-48B6-8A50-9ABB69EE2D02")]
	public interface IUpdateDownloadContent
	{
		/// <summary>
		/// <para>Gets the location of the download content on the server that hosts the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatedownloadcontent-get_downloadurl HRESULT get_DownloadUrl(
		// BSTR *retval );
		[DispId(1610743809)]
		string DownloadUrl
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743809)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}
	}

	/// <summary>Represents the download content of an update.</summary>
	/// <remarks>
	/// The <c>IUpdateDownloadContent2</c> interface may require you to update the Windows Update Agent (WUA). For more information, see
	/// Updating Windows Update Agent.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nn-wuapi-iupdatedownloadcontent2
	[PInvokeData("wuapi.h", MSDNShortId = "NN:wuapi.IUpdateDownloadContent2")]
	[ComImport, Guid("C97AD11B-F257-420B-9D9F-377F733F6F68")]
	public interface IUpdateDownloadContent2 : IUpdateDownloadContent
	{
		/// <summary>
		/// <para>Gets the location of the download content on the server that hosts the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		[DispId(1610743809)]
		new string DownloadUrl
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743809)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether an update is a binary update or a full-file update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// The IUpdateDownloadContent2 interface may require you to update the Windows Update Agent (WUA). For more information, see
		/// Updating Windows Update Agent.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatedownloadcontent2-get_isdeltacompressedcontent HRESULT
		// get_IsDeltaCompressedContent( VARIANT_BOOL *retval );
		[DispId(1610809345)]
		bool IsDeltaCompressedContent
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809345)]
			get;
		}
	}

	/// <summary>Represents a collection of download contents for an update.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nn-wuapi-iupdatedownloadcontentcollection
	[PInvokeData("wuapi.h", MSDNShortId = "NN:wuapi.IUpdateDownloadContentCollection")]
	[ComImport, Guid("BC5513C8-B3B8-4BF7-A4D4-361C0D8C88BA")]
	public interface IUpdateDownloadContentCollection : IEnumerable
	{
		/// <summary>
		/// <para>Gets the download content for an update from an IUpdateDownloadContentCollection interface.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <param name="index"/>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatedownloadcontentcollection-get_item HRESULT get_Item(
		// LONG index, IUpdateDownloadContent **retval );
		[DispId(0)]
		IUpdateDownloadContent this[[In] int index]
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>Gets an IEnumVARIANT interface that is used to enumerate the collection.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatedownloadcontentcollection-get__newenum HRESULT
		// get__NewEnum( IUnknown **retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(-4)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "System.Runtime.InteropServices.CustomMarshalers.EnumeratorToEnumVariantMarshaler, CustomMarshalers, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
		new IEnumerator GetEnumerator();

		/// <summary>
		/// <para>Gets the number of elements in the collection.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatedownloadcontentcollection-get_count HRESULT get_Count(
		// LONG *retval );
		[DispId(1610743809)]
		int Count
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743809)]
			get;
		}
	}

	/// <summary>Downloads updates from the server.</summary>
	/// <remarks>
	/// You can create an instance of this interface by using the UpdateDownloader coclass. Use the Microsoft.Update.Downloader program
	/// identifier to create the object.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nn-wuapi-iupdatedownloader
	[PInvokeData("wuapi.h", MSDNShortId = "NN:wuapi.IUpdateDownloader")]
	[ComImport, Guid("68f1c6f9-7ecc-4666-a464-247fe12496c3"), CoClass(typeof(UpdateDownloaderClass))]
	public interface IUpdateDownloader
	{
		/// <summary>
		/// <para>Gets and sets the current client application.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>Returns the value Unknown if the client application has not set the property.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatedownloader-get_clientapplicationid HRESULT
		// get_ClientApplicationID( BSTR *retval );
		[DispId(0x60020001)]
		string? ClientApplicationID
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020001)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020001)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>
		/// Gets and sets a Boolean value that indicates whether the Windows Update Agent (WUA) forces the download of updates that are
		/// already installed or that cannot be installed.
		/// </para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>This method returns <c>WU_E_INVALID_OPERATION</c> if the object that is implementing the interface is locked down.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatedownloader-get_isforced HRESULT get_IsForced(
		// VARIANT_BOOL *retval );
		[DispId(0x60020002)]
		bool IsForced
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020002)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020002)]
			[param: In]
			set;
		}

		/// <summary>
		/// <para>Gets and sets the priority level of the download.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatedownloader-get_priority HRESULT get_Priority(
		// DownloadPriority *retval );
		[DispId(0x60020003), ComAliasName("WUApiLib.DownloadPriority")]
		DownloadPriority Priority
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020003)]
			[return: ComAliasName("WUApiLib.DownloadPriority")]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020003)]
			[param: In, ComAliasName("WUApiLib.DownloadPriority")]
			set;
		}

		/// <summary>
		/// <para>Gets and sets an interface that contains a read-only collection of the updates that are specified for download.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatedownloader-put_updates HRESULT put_Updates(
		// IUpdateCollection *value );
		[DispId(0x60020004)]
		IUpdateCollection? Updates
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020004)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020004)]
			[param: In, MarshalAs(UnmanagedType.Interface)]
			set;
		}

		/// <summary>Starts an asynchronous download of the content files that are associated with the updates.</summary>
		/// <param name="onProgressChanged">
		/// An IDownloadProgressChangedCallback interface that is called periodically for download progress changes before download is complete.
		/// </param>
		/// <param name="onCompleted">
		/// An IDownloadCompletedCallback interface (C++/COM) that is called when an asynchronous download operation is complete.
		/// </param>
		/// <param name="state">
		/// <para>
		/// The caller-specific state that the AsyncState property of the IDownloadJob interface returns. A caller may use this parameter to
		/// attach a value to the download job object. This allows the caller to retrieve custom information about that download job object
		/// at a later time.
		/// </para>
		/// <para><c>Note</c>  
		/// <para>
		/// The AsyncState property of the IDownloadJob interface can be retrieved, but it cannot be set. This does not prevent the caller
		/// from changing the contents of the object already set to the <c>AsyncState</c> property of the <c>IDownloadJob</c> interface. In
		/// other words, if the <c>AsyncState</c> property contains a number, the number cannot be changed. But, if the <c>AsyncState</c>
		/// property contains a safe array or an object, the contents of the safe array or the object can be changed at will. The value is
		/// released when the caller releases <c>IDownloadJob</c> by calling IUpdateDownloader::EndDownload.
		/// </para>
		/// </para>
		/// <para></para>
		/// </param>
		/// <returns>
		/// An IDownloadJob interface that contains the properties and methods that are available to a download operation that has started.
		/// </returns>
		/// <remarks>
		/// <para>
		/// As an alternative to implementing the IDownloadProgressChangedCallback interface, you can use a script to implement a callback
		/// routine of any identifier with DISPID 0 on an automation object. The type of the <c>onProgressChanged</c> parameter is <c>IUnknown*</c>.
		/// </para>
		/// <para>
		/// As an alternative to implementing the IDownloadCompletedCallback interface, you can use a script to implement a callback routine
		/// of any identifier with DISPID 0 on an automation object. The type of the <c>onCompleted</c> parameter is <c>IUnknown*</c>.
		/// </para>
		/// <para>This method returns <c>WU_E_INVALID_OPERATION</c> if the object that is implementing the interface is locked down.</para>
		/// <para>
		/// This method returns <c>WU_E_NO_UPDATE</c> if the Updates property of the IUpdateDownloader interface is not set. This method also
		/// returns WU_E_NO_UPDATE if the <c>Updates</c> property is set to an empty collection.
		/// </para>
		/// <para>This method returns <c>SUS_E_NOT_INITIALIZED</c> if the download job contains no updates.</para>
		/// <para>
		/// When you use any asynchronous WUA API in your app, you might need to implement a time-out mechanism. For more info about how to
		/// perform asynchronous WUA operations, see Guidelines for Asynchronous WUA Operations.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatedownloader-begindownload HRESULT BeginDownload( [in]
		// IUnknown *onProgressChanged, [in] IUnknown *onCompleted, [in] VARIANT state, [out] IDownloadJob **retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020005)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IDownloadJob BeginDownload([In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? onProgressChanged,
			[In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? onCompleted, [In, MarshalAs(UnmanagedType.Struct)] object? state);

		/// <summary>Starts a synchronous download of the content files that are associated with the updates.</summary>
		/// <returns>An IDownloadResult interface that contains result codes for the download.</returns>
		/// <remarks>
		/// <para>This method returns <c>WU_E_INVALID_OPERATION</c> if the object that is implementing the interface is locked down.</para>
		/// <para>
		/// This method returns <c>WU_E_NO_UPDATE</c> if the Updates property of the IUpdateDownloader interface is not set. This method also
		/// returns <c>WU_E_NO_UPDATE</c> if the <c>Updates</c> property is set to an empty collection.
		/// </para>
		/// <para>This method returns <c>SUS_E_NOT_INITIALIZED</c> if the download job does not contain updates.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatedownloader-download HRESULT Download( [out]
		// IDownloadResult **retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020006)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IDownloadResult Download();

		/// <summary>Completes an asynchronous download.</summary>
		/// <param name="value">The IDownloadJob interface pointer that BeginDownload returns.</param>
		/// <returns>An IDownloadResult interface that contains result codes for a download.</returns>
		/// <remarks>
		/// <para>This method returns <c>WU_E_INVALID_OPERATION</c> if the object that is implementing the interface is locked down.</para>
		/// <para>
		/// When you use any asynchronous WUA API in your app, you might need to implement a time-out mechanism. For more info about how to
		/// perform asynchronous WUA operations, see Guidelines for Asynchronous WUA Operations.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatedownloader-enddownload HRESULT EndDownload( [in]
		// IDownloadJob *value, [out] IDownloadResult **retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020007)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IDownloadResult EndDownload([In, MarshalAs(UnmanagedType.Interface)] IDownloadJob value);
	}

	/// <summary>Contains the properties that indicate the status of a download operation for an update.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nn-wuapi-iupdatedownloadresult
	[PInvokeData("wuapi.h", MSDNShortId = "NN:wuapi.IUpdateDownloadResult")]
	[ComImport, Guid("bf99af76-b575-42ad-8aa4-33cbb5477af1")]
	public interface IUpdateDownloadResult
	{
		/// <summary>
		/// <para>Gets the exception <c>HRESULT</c> value, if any, that is raised during the operation on the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatedownloadresult-get_hresult HRESULT get_HResult( LONG
		// *retval );
		[DispId(0x60020001)]
		int HResult
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020001)]
			get;
		}

		/// <summary>
		/// <para>Gets an OperationResultCode enumeration value that specifies the result of an operation on the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatedownloadresult-get_resultcode HRESULT get_ResultCode(
		// OperationResultCode *retval );
		[ComAliasName("WUApiLib.OperationResultCode"), DispId(0x60020002)]
		OperationResultCode ResultCode
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020002)]
			[return: ComAliasName("WUApiLib.OperationResultCode")]
			get;
		}
	}

	/// <summary>
	/// Represents info about the aspects of search results returned in the ISearchResult object that were incomplete. For more info, see Remarks.
	/// </summary>
	/// <remarks>
	/// The <c>IUpdateException</c> object is returned as part of the ISearchResult::Warnings property when a search succeeds but can't
	/// return complete results. For example, Windows Update might not have been able to retrieve all of the update metadata for a given
	/// update from the server. In this situation, the search results returned in the ISearchResult object are usable, but they aren't
	/// necessarily complete. The properties of the <c>IUpdateException</c> objects that are returned by the <c>ISearchResult::Warnings</c>
	/// property contain info about the aspects of the search that were incomplete. This info is unlikely to be useful programmatically, but
	/// can sometimes be useful for debugging.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nn-wuapi-iupdateexception
	[PInvokeData("wuapi.h", MSDNShortId = "NN:wuapi.IUpdateException")]
	[ComImport, DefaultMember("Message"), Guid("A376DD5E-09D4-427F-AF7C-FED5B6E1C1D6")]
	public interface IUpdateException
	{
		/// <summary>
		/// <para>Gets a message that describes the search results.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateexception-get_message HRESULT get_Message( BSTR *retval );
		[DispId(0)]
		string? Message
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets the Windows-based <c>HRESULT</c> code for the search results.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateexception-get_hresult HRESULT get_HResult( LONG *retval );
		[DispId(1610743809)]
		int HResult
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743809)]
			get;
		}

		/// <summary>
		/// <para>Gets the context of search results.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateexception-get_context HRESULT get_Context(
		// UpdateExceptionContext *retval );
		[DispId(1610743810), ComAliasName("WUApiLib.UpdateExceptionContext")]
		UpdateExceptionContext Context
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743810)]
			[return: ComAliasName("WUApiLib.UpdateExceptionContext")]
			get;
		}
	}

	/// <summary>Represents an ordered read-only list of IUpdateException interfaces.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nn-wuapi-iupdateexceptioncollection
	[PInvokeData("wuapi.h", MSDNShortId = "NN:wuapi.IUpdateExceptionCollection")]
	[ComImport, Guid("503626A3-8E14-4729-9355-0FE664BD2321")]
	public interface IUpdateExceptionCollection : IEnumerable
	{
		/// <summary>
		/// <para>Gets an IUpdateException interface in the collection.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <param name="index"/>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateexceptioncollection-get_item HRESULT get_Item( LONG
		// index, IUpdateException **retval );
		[DispId(0)]
		IUpdateException this[[In] int index]
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>Gets an IEnumVARIANT interface that can be used to enumerate the collection.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateexceptioncollection-get__newenum HRESULT get__NewEnum(
		// IUnknown **retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(-4)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "System.Runtime.InteropServices.CustomMarshalers.EnumeratorToEnumVariantMarshaler, CustomMarshalers, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
		new IEnumerator GetEnumerator();

		/// <summary>
		/// <para>Gets the number of elements in the collection.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateexceptioncollection-get_count HRESULT get_Count( LONG
		// *retval );
		[DispId(1610743809)]
		int Count
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743809)]
			get;
		}
	}

	/// <summary>Represents the recorded history of an update.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nn-wuapi-iupdatehistoryentry
	[PInvokeData("wuapi.h", MSDNShortId = "NN:wuapi.IUpdateHistoryEntry")]
	[ComImport, Guid("BE56A644-AF0E-4E0E-A311-C1D8E695CBFF")]
	public interface IUpdateHistoryEntry
	{
		/// <summary>
		/// <para>Gets an UpdateOperation value that specifies the operation on an update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatehistoryentry-get_operation HRESULT get_Operation(
		// tagUpdateOperation *retval );
		[DispId(1610743809)]
		UpdateOperation Operation
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743809)]
			get;
		}

		/// <summary>
		/// <para>Gets an OperationResultCode value that specifies the result of an operation on an update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatehistoryentry-get_resultcode HRESULT get_ResultCode(
		// OperationResultCode *retval );
		[ComAliasName("WUApiLib.OperationResultCode"), DispId(1610743810)]
		OperationResultCode ResultCode
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743810)]
			[return: ComAliasName("WUApiLib.OperationResultCode")]
			get;
		}

		/// <summary>
		/// <para>Gets the <c>HRESULT</c> value that is returned from the operation on an update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// The returned value is a mapped exception code. To retrieve the actual exception code, use the UnmappedResultCode property.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatehistoryentry-get_hresult HRESULT get_HResult( LONG
		// *retval );
		[DispId(1610743811)]
		int HResult
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743811)]
			get;
		}

		/// <summary>
		/// <para>Gets the date and the time an update was applied.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatehistoryentry-get_date HRESULT get_Date( DATE *retval );
		[DispId(1610743812)]
		DateTime Date
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743812)]
			get;
		}

		/// <summary>
		/// <para>Gets the IUpdateIdentity interface that contains the identity of the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatehistoryentry-get_updateidentity HRESULT
		// get_UpdateIdentity( IUpdateIdentity **retval );
		[DispId(1610743813)]
		IUpdateIdentity UpdateIdentity
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743813)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>Gets the title of an update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The information that this property returns is for the default user interface (UI) language of the user. However, note the following:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// If the default UI language of the user is unavailable, Windows Update Agent (WUA) uses the default UI language of the computer.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If the default language of the computer is unavailable, WUA uses the language that the provider of the update recommends.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatehistoryentry-get_title HRESULT get_Title( BSTR *retval );
		[DispId(1610743814)]
		string Title
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743814)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets the description of an update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The information that this property returns is for the default user interface (UI) language of the user. However, note the following:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// If the default UI language of the user is unavailable, Windows Update Agent (WUA) uses the default UI language of the computer.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If the default language of the computer is unavailable, WUA uses the language that the provider of the update recommends.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatehistoryentry-get_description HRESULT get_Description(
		// BSTR *retval );
		[DispId(1610743815)]
		string? Description
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743815)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets the unmapped result code that is returned from an operation on an update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>The returned value is an unmapped result code. To retrieve a mapped exception code, use the HResult property.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatehistoryentry-get_unmappedresultcode HRESULT
		// get_UnmappedResultCode( LONG *retval );
		[DispId(1610743816)]
		int UnmappedResultCode
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743816)]
			get;
		}

		/// <summary>
		/// <para>Gets the identifier of the client application that processed an update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>Returns the Unknown value if the client application has not set the property.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatehistoryentry-get_clientapplicationid HRESULT
		// get_ClientApplicationID( BSTR *retval );
		[DispId(1610743817)]
		string ClientApplicationID
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743817)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets the ServerSelection value that indicates which server provided an update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatehistoryentry-get_serverselection HRESULT
		// get_ServerSelection( ServerSelection *retval );
		[ComAliasName("WUApiLib.ServerSelection"), DispId(1610743818)]
		ServerSelection ServerSelection
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743818)]
			[return: ComAliasName("WUApiLib.ServerSelection")]
			get;
		}

		/// <summary>
		/// <para>
		/// Gets the service identifier of an update service that is not a Windows update. This property is meaningful only if the
		/// ServerSelection property returns <c>ssOthers</c>.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatehistoryentry-get_serviceid HRESULT get_ServiceID( BSTR
		// *retval );
		[DispId(1610743819)]
		string? ServiceID
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743819)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets the IStringCollection interface that contains the uninstallation steps for an update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The information that this property returns is for the default user interface (UI) language of the user. However, note the following:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// If the default UI language of the user is unavailable, Windows Update Agent (WUA) uses the default UI language of the computer.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If the default language of the computer is unavailable, WUA uses the language that the provider of the update recommends.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatehistoryentry-get_uninstallationsteps HRESULT
		// get_UninstallationSteps( IStringCollection **retval );
		[DispId(1610743820)]
		IStringCollection UninstallationSteps
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743820)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>Gets the uninstallation notes of an update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The information that this property returns is for the default user interface (UI) language of the user. However, note the following:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// If the default UI language of the user is unavailable, Windows Update Agent (WUA) uses the default UI language of the computer.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If the default language of the computer is unavailable, WUA uses the language that the provider of the update recommends.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatehistoryentry-get_uninstallationnotes HRESULT
		// get_UninstallationNotes( BSTR *retval );
		[DispId(1610743821)]
		string? UninstallationNotes
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743821)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets a hyperlink to the language-specific support information for an update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The information that this property returns is for the default user interface (UI) language of the user. However, note the following:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// If the default UI language of the user is unavailable, Windows Update Agent (WUA) uses the default UI language of the computer.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If the default language of the computer is unavailable, WUA uses the language that the provider of the update recommends.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatehistoryentry-get_supporturl HRESULT get_SupportUrl( BSTR
		// *retval );
		[DispId(1610743822)]
		string SupportUrl
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743822)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}
	}

	/// <summary>Represents the recorded history of an update.</summary>
	/// <remarks>
	/// The <c>IUpdateHistoryEntry2</c> interface may require you to update Windows Update Agent (WUA). For more information, see Updating
	/// Windows Update Agent.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nn-wuapi-iupdatehistoryentry2
	[PInvokeData("wuapi.h", MSDNShortId = "NN:wuapi.IUpdateHistoryEntry2")]
	[ComImport, Guid("C2BFB780-4539-4132-AB8C-0A8772013AB6")]
	public interface IUpdateHistoryEntry2 : IUpdateHistoryEntry
	{
		/// <summary>
		/// <para>Gets an UpdateOperation value that specifies the operation on an update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatehistoryentry-get_operation HRESULT get_Operation(
		// tagUpdateOperation *retval );
		[DispId(1610743809)]
		new UpdateOperation Operation
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743809)]
			get;
		}

		/// <summary>
		/// <para>Gets an OperationResultCode value that specifies the result of an operation on an update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatehistoryentry-get_resultcode HRESULT get_ResultCode(
		// OperationResultCode *retval );
		[ComAliasName("WUApiLib.OperationResultCode"), DispId(1610743810)]
		new OperationResultCode ResultCode
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743810)]
			[return: ComAliasName("WUApiLib.OperationResultCode")]
			get;
		}

		/// <summary>
		/// <para>Gets the <c>HRESULT</c> value that is returned from the operation on an update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// The returned value is a mapped exception code. To retrieve the actual exception code, use the UnmappedResultCode property.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatehistoryentry-get_hresult HRESULT get_HResult( LONG
		// *retval );
		[DispId(1610743811)]
		new int HResult
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743811)]
			get;
		}

		/// <summary>
		/// <para>Gets the date and the time an update was applied.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatehistoryentry-get_date HRESULT get_Date( DATE *retval );
		[DispId(1610743812)]
		new DateTime Date
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743812)]
			get;
		}

		/// <summary>
		/// <para>Gets the IUpdateIdentity interface that contains the identity of the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatehistoryentry-get_updateidentity HRESULT
		// get_UpdateIdentity( IUpdateIdentity **retval );
		[DispId(1610743813)]
		new IUpdateIdentity UpdateIdentity
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743813)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>Gets the title of an update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The information that this property returns is for the default user interface (UI) language of the user. However, note the following:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// If the default UI language of the user is unavailable, Windows Update Agent (WUA) uses the default UI language of the computer.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If the default language of the computer is unavailable, WUA uses the language that the provider of the update recommends.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatehistoryentry-get_title HRESULT get_Title( BSTR *retval );
		[DispId(1610743814)]
		new string Title
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743814)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets the description of an update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The information that this property returns is for the default user interface (UI) language of the user. However, note the following:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// If the default UI language of the user is unavailable, Windows Update Agent (WUA) uses the default UI language of the computer.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If the default language of the computer is unavailable, WUA uses the language that the provider of the update recommends.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatehistoryentry-get_description HRESULT get_Description(
		// BSTR *retval );
		[DispId(1610743815)]
		new string? Description
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743815)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets the unmapped result code that is returned from an operation on an update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>The returned value is an unmapped result code. To retrieve a mapped exception code, use the HResult property.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatehistoryentry-get_unmappedresultcode HRESULT
		// get_UnmappedResultCode( LONG *retval );
		[DispId(1610743816)]
		new int UnmappedResultCode
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743816)]
			get;
		}

		/// <summary>
		/// <para>Gets the identifier of the client application that processed an update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>Returns the Unknown value if the client application has not set the property.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatehistoryentry-get_clientapplicationid HRESULT
		// get_ClientApplicationID( BSTR *retval );
		[DispId(1610743817)]
		new string ClientApplicationID
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743817)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets the ServerSelection value that indicates which server provided an update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatehistoryentry-get_serverselection HRESULT
		// get_ServerSelection( ServerSelection *retval );
		[ComAliasName("WUApiLib.ServerSelection"), DispId(1610743818)]
		new ServerSelection ServerSelection
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743818)]
			[return: ComAliasName("WUApiLib.ServerSelection")]
			get;
		}

		/// <summary>
		/// <para>
		/// Gets the service identifier of an update service that is not a Windows update. This property is meaningful only if the
		/// ServerSelection property returns <c>ssOthers</c>.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatehistoryentry-get_serviceid HRESULT get_ServiceID( BSTR
		// *retval );
		[DispId(1610743819)]
		new string? ServiceID
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743819)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets the IStringCollection interface that contains the uninstallation steps for an update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The information that this property returns is for the default user interface (UI) language of the user. However, note the following:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// If the default UI language of the user is unavailable, Windows Update Agent (WUA) uses the default UI language of the computer.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If the default language of the computer is unavailable, WUA uses the language that the provider of the update recommends.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatehistoryentry-get_uninstallationsteps HRESULT
		// get_UninstallationSteps( IStringCollection **retval );
		[DispId(1610743820)]
		new IStringCollection UninstallationSteps
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743820)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>Gets the uninstallation notes of an update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The information that this property returns is for the default user interface (UI) language of the user. However, note the following:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// If the default UI language of the user is unavailable, Windows Update Agent (WUA) uses the default UI language of the computer.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If the default language of the computer is unavailable, WUA uses the language that the provider of the update recommends.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatehistoryentry-get_uninstallationnotes HRESULT
		// get_UninstallationNotes( BSTR *retval );
		[DispId(1610743821)]
		new string? UninstallationNotes
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743821)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets a hyperlink to the language-specific support information for an update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The information that this property returns is for the default user interface (UI) language of the user. However, note the following:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// If the default UI language of the user is unavailable, Windows Update Agent (WUA) uses the default UI language of the computer.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If the default language of the computer is unavailable, WUA uses the language that the provider of the update recommends.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatehistoryentry-get_supporturl HRESULT get_SupportUrl( BSTR
		// *retval );
		[DispId(1610743822)]
		new string SupportUrl
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743822)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets a collection of the update categories to which an update belongs.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The IUpdateHistoryEntry2 interface may require you to update Windows Update Agent (WUA). For more information, see Updating
		/// Windows Update Agent.
		/// </para>
		/// <para>
		/// The information that this property returns is for the default user interface (UI) language of the user. If the default UI
		/// language of the user is unavailable, WUA uses the default UI language of the computer. If the default language of the computer is
		/// unavailable, WUA uses the language that the provider of the update recommends.
		/// </para>
		/// <para>
		/// Because there is a Categories property of the IUpdate interface and a <c>Categories</c> property of the IUpdateHistoryEntry2
		/// interface, the information that is used by the localized properties of the ICategory interface depends on the WUA object that
		/// owns the <c>ICategory</c> interface. If the <c>ICategory</c> interface is returned from the <c>Categories</c> property of
		/// <c>IUpdate</c>, it follows the localization rules of <c>IUpdate</c>. If the <c>ICategory</c> interface is returned from the
		/// <c>Categories</c> property of <c>IUpdateHistoryEntry2</c>, it follows the localization rules of <c>IUpdateHistoryEntry2</c>.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatehistoryentry2-get_categories HRESULT get_Categories(
		// ICategoryCollection **retval );
		[DispId(1610809345)]
		ICategoryCollection Categories
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809345)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}
	}

	/// <summary>Represents an ordered read-only list of IUpdateHistoryEntry interfaces.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nn-wuapi-iupdatehistoryentrycollection
	[PInvokeData("wuapi.h", MSDNShortId = "NN:wuapi.IUpdateHistoryEntryCollection")]
	[ComImport, Guid("A7F04F3C-A290-435B-AADF-A116C3357A5C")]
	public interface IUpdateHistoryEntryCollection : IEnumerable
	{
		/// <summary>
		/// <para>Gets an IUpdateHistoryEntry interface in the collection.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <param name="index"/>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatehistoryentrycollection-get_item HRESULT get_Item( LONG
		// index, IUpdateHistoryEntry **retval );
		[DispId(0)]
		IUpdateHistoryEntry this[[In] int index]
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>Gets an IEnumVARIANT interface that can be used to enumerate the collection.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatehistoryentrycollection-get__newenum HRESULT
		// get__NewEnum( IUnknown **retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(-4)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "System.Runtime.InteropServices.CustomMarshalers.EnumeratorToEnumVariantMarshaler, CustomMarshalers, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
		new IEnumerator GetEnumerator();

		/// <summary>Gets the number of elements in the collection.</summary>
		// https://github.com/MicrosoftDocs/sdk-api/blob/docs/sdk-api-src/content/wuapi/nf-wuapi-iupdatehistoryentrycollection-get_count.md
		[DispId(1610743809)]
		int Count
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743809)]
			get;
		}
	}

	/// <summary>Represents the unique identifier of an update.</summary>
	/// <remarks>You can create an instance of this interface by using the UpdateIdentity coclass.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nn-wuapi-iupdateidentity
	[PInvokeData("wuapi.h", MSDNShortId = "NN:wuapi.IUpdateIdentity")]
	[ComImport, Guid("46297823-9940-4C09-AED9-CD3EA6D05968")]
	public interface IUpdateIdentity
	{
		/// <summary>Gest the revision number of the update.</summary>
		// https://learn.microsoft.com/en-us/openspecs/windows_protocols/ms-uamg/e9c2b583-44a9-4300-9650-871c15c07a65
		[DispId(1610743810)]
		int RevisionNumber
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743810)]
			get;
		}

		/// <summary>Gets the revision-independent identifier of an update.</summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateidentity-get_updateid HRESULT get_UpdateID( BSTR *retval );
		[DispId(1610743811)]
		string UpdateID
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743811)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}
	}

	/// <summary>Contains the properties and the methods that are available to the status of an installation or uninstallation of an update.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nn-wuapi-iupdateinstallationresult
	[PInvokeData("wuapi.h", MSDNShortId = "NN:wuapi.IUpdateInstallationResult")]
	[ComImport, Guid("D940F0F8-3CBB-4FD0-993F-471E7F2328AD")]
	public interface IUpdateInstallationResult
	{
		/// <summary>
		/// <para>Gets the <c>HRESULT</c> exception value that is raised during the operation on an update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateinstallationresult-get_hresult HRESULT get_HResult( LONG
		// *retval );
		[DispId(0x60020001)]
		int HResult
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020001)]
			get;
		}

		/// <summary>
		/// <para>
		/// Gets a Boolean value that indicates whether a system restart is required on a computer to complete the installation of an update.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateinstallationresult-get_rebootrequired HRESULT
		// get_RebootRequired( VARIANT_BOOL *retval );
		[DispId(0x60020002)]
		bool RebootRequired
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020002)]
			get;
		}

		/// <summary>
		/// <para>Gets an OperationResultCode value that specifies the result of an operation on an update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateinstallationresult-get_resultcode HRESULT
		// get_ResultCode( OperationResultCode *retval );
		[ComAliasName("WUApiLib.OperationResultCode"), DispId(0x60020003)]
		OperationResultCode ResultCode
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020003)]
			[return: ComAliasName("WUApiLib.OperationResultCode")]
			get;
		}
	}

	/// <summary>Installs or uninstalls updates from or onto a computer.</summary>
	/// <remarks>
	/// This interface can be instantiated by using the UpdateInstaller coclass. Use the Microsoft.Update.Installer program identifier to
	/// create the object.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nn-wuapi-iupdateinstaller
	[PInvokeData("wuapi.h", MSDNShortId = "NN:wuapi.IUpdateInstaller")]
	[ComImport, ComConversionLoss, Guid("7b929c68-ccdc-4226-96b1-8724600b54c2"), CoClass(typeof(UpdateInstallerClass))]
	public interface IUpdateInstaller
	{
		/// <summary>
		/// <para>Gets and sets the current client application.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>Returns the Unknown value if the client application has not set the property.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateinstaller-put_clientapplicationid HRESULT
		// put_ClientApplicationID( BSTR value );
		[DispId(0x60020001)]
		string? ClientApplicationID
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020001)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020001)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>Gets or sets a Boolean value that indicates whether to forcibly install or uninstall an update.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// A forced installation is an installation in which an update is installed even if the metadata indicates that the update is
		/// already installed. A forced uninstallation is an uninstallation in which an update is removed even if the metadata indicates that
		/// the update is not installed.
		/// </para>
		/// <para>
		/// Before you use <c>IsForced</c> to force an installation, determine whether the update is installed and available. If an update is
		/// not installed, a forced installation fails. For example, an update can be downloaded, and then its corresponding files removed
		/// from the cache after the expiration limit. In this case, if the files are not installed, a forced installation of the update fails.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateinstaller-put_isforced HRESULT put_IsForced(
		// VARIANT_BOOL value );
		[DispId(0x60020002)]
		bool IsForced
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020002)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020002)]
			[param: In]
			set;
		}

		/// <summary>
		/// <para>Gets and sets a handle to the parent window that can contain a dialog box.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>
		/// This property can be changed only by a user on the computer. This property cannot be accessed by using the <c>IDispatch</c> interface.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateinstaller-get_parenthwnd HRESULT get_ParentHwnd( HWND
		// *retval );
		[ComAliasName("WUApiLib.wireHWND"), DispId(0x60020003)]
		HWND ParentHwnd
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020003)]
			[return: ComAliasName("WUApiLib.wireHWND")]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020003)]
			[param: In, ComAliasName("WUApiLib.wireHWND")]
			set;
		}

		/// <summary>
		/// <para>Gets and sets the interface that represents the parent window that can contain a dialog box.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>
		/// This property can be changed only by a user on the computer. This property can be accessed by using the IDispatch interface.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateinstaller-get_parentwindow HRESULT get_ParentWindow(
		// IUnknown **retval );
		[DispId(0x60020004)]
		object? parentWindow
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020004)]
			[return: MarshalAs(UnmanagedType.IUnknown)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020004)]
			[param: In, MarshalAs(UnmanagedType.IUnknown)]
			set;
		}

		/// <summary>
		/// <para>Gets and sets an interface that contains a read-only collection of the updates that are specified for installation or uninstallation.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateinstaller-get_updates HRESULT get_Updates(
		// IUpdateCollection **retval );
		[DispId(0x60020005)]
		IUpdateCollection Updates
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020005)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020005)]
			[param: In, MarshalAs(UnmanagedType.Interface)]
			set;
		}

		/// <summary>Starts an asynchronous installation of the updates.</summary>
		/// <param name="onProgressChanged">
		/// An IInstallationProgressChangedCallback interface that is called periodically for installation progress changes before the
		/// installation is complete.
		/// </param>
		/// <param name="onCompleted">An IInstallationCompletedCallback interface that is called when an installation operation is complete.</param>
		/// <param name="state">The caller-specific state that is returned by the AsyncState property of the IInstallationJob interface.</param>
		/// <returns>
		/// An IInstallationJob interface that contains the properties and methods that are available to an asynchronous installation
		/// operation that was initiated.
		/// </returns>
		/// <remarks>
		/// <para>
		/// If you call this method from a scripting language, set the <c>onProgressChanged</c> parameter to the identifier of an Automation
		/// object with a dispatch identifier (DSIPID) of zero (0) that implements the callback routine. Do the same thing for the
		/// <c>onCompleted</c> parameter.
		/// </para>
		/// <para>
		/// This method returns WU_E_NO_UPDATE if the Updates property of IUpdateInstaller is not set. This method also returns
		/// WU_E_NO_UPDATE if the <c>Updates</c> property is set to an empty collection.
		/// </para>
		/// <para>
		/// When you use any asynchronous WUA API in your app, you might need to implement a time-out mechanism. For more info about how to
		/// perform asynchronous WUA operations, see Guidelines for Asynchronous WUA Operations.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateinstaller-begininstall HRESULT BeginInstall( [in]
		// IUnknown *onProgressChanged, [in] IUnknown *onCompleted, [in] VARIANT state, [out] IInstallationJob **retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020006)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IInstallationJob BeginInstall([In, MarshalAs(UnmanagedType.IUnknown)] object onProgressChanged,
			[In, MarshalAs(UnmanagedType.IUnknown)] object onCompleted, [In, MarshalAs(UnmanagedType.Struct)] object? state);

		/// <summary>Starts an asynchronous uninstallation of the updates.</summary>
		/// <param name="onProgressChanged">
		/// An IInstallationProgressChangedCallback interface that is called periodically for uninstallation progress changes before the
		/// uninstallation is complete.
		/// </param>
		/// <param name="onCompleted">An IInstallationCompletedCallback interface that is called when an installation operation is complete.</param>
		/// <param name="state">The caller-specific state that the AsyncState property IInstallationJob interface returns.</param>
		/// <returns>
		/// An IInstallationJob interface that contains the properties and methods that are available to an asynchronous uninstall operation
		/// that was initiated.
		/// </returns>
		/// <remarks>
		/// <para>
		/// If you call this method from a scripting language, set the <c>onProgressChanged</c> parameter to the identifier of an Automation
		/// object with a dispatch identifier (DSIPID) of zero (0) that implements the callback routine. Do the same thing for the
		/// <c>onCompleted</c> parameter.
		/// </para>
		/// <para>
		/// This method returns WU_E_NO_UPDATE if the Updates property of IUpdateInstaller is not set. This method also returns
		/// WU_E_NO_UPDATE if the <c>Updates</c> property is set to an empty collection.
		/// </para>
		/// <para>
		/// When you use any asynchronous WUA API in your app, you might need to implement a time-out mechanism. For more info about how to
		/// perform asynchronous WUA operations, see Guidelines for Asynchronous WUA Operations.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateinstaller-beginuninstall HRESULT BeginUninstall( [in]
		// IUnknown *onProgressChanged, [in] IUnknown *onCompleted, [in] VARIANT state, [out] IInstallationJob **retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020007)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IInstallationJob BeginUninstall([In, MarshalAs(UnmanagedType.IUnknown)] object onProgressChanged,
			[In, MarshalAs(UnmanagedType.IUnknown)] object onCompleted, [In, MarshalAs(UnmanagedType.Struct)] object? state);

		/// <summary>Completes an asynchronous installation of the updates.</summary>
		/// <param name="value">The IInstallationJob interface that is returned by the BeginInstall method.</param>
		/// <returns>An IInstallationResult interface that represents the overall result of the installation operation.</returns>
		/// <remarks>
		/// When you use any asynchronous WUA API in your app, you might need to implement a time-out mechanism. For more info about how to
		/// perform asynchronous WUA operations, see Guidelines for Asynchronous WUA Operations.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateinstaller-endinstall HRESULT EndInstall( [in]
		// IInstallationJob *value, [out] IInstallationResult **retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020008)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IInstallationResult EndInstall([In, MarshalAs(UnmanagedType.Interface)] IInstallationJob value);

		/// <summary>Completes an asynchronous uninstallation of the updates.</summary>
		/// <param name="value">The IInstallationJob interface that the BeginUninstall method returns.</param>
		/// <returns>An IInstallationResult interface that represents the overall result of an uninstallation operation.</returns>
		/// <remarks>
		/// When you use any asynchronous WUA API in your app, you might need to implement a time-out mechanism. For more info about how to
		/// perform asynchronous WUA operations, see Guidelines for Asynchronous WUA Operations.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateinstaller-enduninstall HRESULT EndUninstall( [in]
		// IInstallationJob *value, [out] IInstallationResult **retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020009)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IInstallationResult EndUninstall([In, MarshalAs(UnmanagedType.Interface)] IInstallationJob value);

		/// <summary>Starts a synchronous installation of the updates.</summary>
		/// <returns>
		/// An IInstallationResult interface that represents the results of an installation operation for each update that is specified in a request.
		/// </returns>
		/// <remarks>
		/// This method returns WU_E_NO_UPDATE if the Updates property of IUpdateInstaller is not set. This method also returns
		/// WU_E_NO_UPDATE if the <c>Updates</c> property is set to an empty collection.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateinstaller-install HRESULT Install( [out]
		// IInstallationResult **retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000a)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IInstallationResult Install();

		/// <summary>Starts a wizard that guides the local user through the steps to install the updates.</summary>
		/// <param name="dialogTitle">
		/// <para>An optional string value to be displayed in the title bar of the wizard.</para>
		/// <para>If an empty string value is used, the following text is displayed: Download and Install Updates.</para>
		/// </param>
		/// <returns>
		/// An IInstallationResult interface that represents the results of an installation operation for each update that is specified in
		/// the request.
		/// </returns>
		/// <remarks>
		/// This method returns WU_E_NO_UPDATE if the Updates property of IUpdateInstaller is not set. This method also returns
		/// WU_E_NO_UPDATE if the <c>Updates</c> property is set to an empty collection.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateinstaller-runwizard HRESULT RunWizard( [in, optional]
		// BSTR dialogTitle, [out] IInstallationResult **retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000b)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IInstallationResult RunWizard([In, MarshalAs(UnmanagedType.BStr)] string dialogTitle = "");

		/// <summary>
		/// <para>
		/// Gets a Boolean value that indicates whether an installation or uninstallation is in progress on a computer at a specific time.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// A new installation or uninstallation is processed only when no other installation or uninstallation is in progress. While an
		/// installation or uninstallation is in progress, a new installation or uninstallation immediately fails with the
		/// <c>WU_E_OPERATIONINPROGRESS</c> error. The <c>IsBusy</c> property does not secure an opportunity for the caller to begin a new
		/// installation or uninstallation. If the <c>IsBusy</c> property or a recent installation or uninstallation failure indicates that
		/// another installation or uninstallation is already in progress, the caller should attempt the installation or uninstallation later.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateinstaller-get_isbusy HRESULT get_IsBusy( VARIANT_BOOL
		// *retval );
		[DispId(0x6002000c)]
		bool IsBusy
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000c)]
			get;
		}

		/// <summary>Starts a synchronous uninstallation of the updates.</summary>
		/// <returns>
		/// An IInstallationResult interface that represents the results of an uninstallation operation for each update that is specified in
		/// a request.
		/// </returns>
		/// <remarks>
		/// This method returns WU_E_NO_UPDATE if the Updates property of IUpdateInstaller is not set. This method also returns
		/// WU_E_NO_UPDATE if the <c>Updates</c> property is set to an empty collection.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateinstaller-uninstall HRESULT Uninstall( [out]
		// IInstallationResult **retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000d)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IInstallationResult Uninstall();

		/// <summary>
		/// <para>Gets and sets a Boolean value that indicates whether to show source prompts to the user when installing the updates.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateinstaller-put_allowsourceprompts HRESULT
		// put_AllowSourcePrompts( VARIANT_BOOL value );
		[DispId(0x6002000e)]
		bool AllowSourcePrompts
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000e)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000e)]
			[param: In]
			set;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether a system restart is required before installing or uninstalling updates.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateinstaller-get_rebootrequiredbeforeinstallation HRESULT
		// get_RebootRequiredBeforeInstallation( VARIANT_BOOL *retval );
		[DispId(0x6002000f)]
		bool RebootRequiredBeforeInstallation
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000f)]
			get;
		}
	}

	/// <summary>Installs or uninstalls updates on a computer.</summary>
	/// <remarks>
	/// You can create an instance of this interface by using the UpdateInstaller coclass. Use the Microsoft.Update.Installer program
	/// identifier to create the object.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nn-wuapi-iupdateinstaller2
	[PInvokeData("wuapi.h", MSDNShortId = "NN:wuapi.IUpdateInstaller2")]
	[ComImport, Guid("3442d4fe-224d-4cee-98cf-30e0c4d229e6"), CoClass(typeof(UpdateInstallerClass))]
	public interface IUpdateInstaller2 : IUpdateInstaller
	{
		/// <summary>
		/// <para>Gets and sets the current client application.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>Returns the Unknown value if the client application has not set the property.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateinstaller-put_clientapplicationid HRESULT
		// put_ClientApplicationID( BSTR value );
		[DispId(0x60020001)]
		new string? ClientApplicationID
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020001)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020001)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>Gets or sets a Boolean value that indicates whether to forcibly install or uninstall an update.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// A forced installation is an installation in which an update is installed even if the metadata indicates that the update is
		/// already installed. A forced uninstallation is an uninstallation in which an update is removed even if the metadata indicates that
		/// the update is not installed.
		/// </para>
		/// <para>
		/// Before you use <c>IsForced</c> to force an installation, determine whether the update is installed and available. If an update is
		/// not installed, a forced installation fails. For example, an update can be downloaded, and then its corresponding files removed
		/// from the cache after the expiration limit. In this case, if the files are not installed, a forced installation of the update fails.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateinstaller-put_isforced HRESULT put_IsForced(
		// VARIANT_BOOL value );
		[DispId(0x60020002)]
		new bool IsForced
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020002)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020002)]
			[param: In]
			set;
		}

		/// <summary>
		/// <para>Gets and sets a handle to the parent window that can contain a dialog box.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>
		/// This property can be changed only by a user on the computer. This property cannot be accessed by using the <c>IDispatch</c> interface.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateinstaller-get_parenthwnd HRESULT get_ParentHwnd( HWND
		// *retval );
		[ComAliasName("WUApiLib.wireHWND"), DispId(0x60020003)]
		new HWND ParentHwnd
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020003)]
			[return: ComAliasName("WUApiLib.wireHWND")]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020003)]
			[param: In, ComAliasName("WUApiLib.wireHWND")]
			set;
		}

		/// <summary>
		/// <para>Gets and sets the interface that represents the parent window that can contain a dialog box.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>
		/// This property can be changed only by a user on the computer. This property can be accessed by using the IDispatch interface.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateinstaller-get_parentwindow HRESULT get_ParentWindow(
		// IUnknown **retval );
		[DispId(0x60020004)]
		new object? parentWindow
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020004)]
			[return: MarshalAs(UnmanagedType.IUnknown)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020004)]
			[param: In, MarshalAs(UnmanagedType.IUnknown)]
			set;
		}

		/// <summary>
		/// <para>Gets and sets an interface that contains a read-only collection of the updates that are specified for installation or uninstallation.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateinstaller-get_updates HRESULT get_Updates(
		// IUpdateCollection **retval );
		[DispId(0x60020005)]
		new IUpdateCollection Updates
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020005)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020005)]
			[param: In, MarshalAs(UnmanagedType.Interface)]
			set;
		}

		/// <summary>Starts an asynchronous installation of the updates.</summary>
		/// <param name="onProgressChanged">
		/// An IInstallationProgressChangedCallback interface that is called periodically for installation progress changes before the
		/// installation is complete.
		/// </param>
		/// <param name="onCompleted">An IInstallationCompletedCallback interface that is called when an installation operation is complete.</param>
		/// <param name="state">The caller-specific state that is returned by the AsyncState property of the IInstallationJob interface.</param>
		/// <returns>
		/// An IInstallationJob interface that contains the properties and methods that are available to an asynchronous installation
		/// operation that was initiated.
		/// </returns>
		/// <remarks>
		/// <para>
		/// If you call this method from a scripting language, set the <c>onProgressChanged</c> parameter to the identifier of an Automation
		/// object with a dispatch identifier (DSIPID) of zero (0) that implements the callback routine. Do the same thing for the
		/// <c>onCompleted</c> parameter.
		/// </para>
		/// <para>
		/// This method returns WU_E_NO_UPDATE if the Updates property of IUpdateInstaller is not set. This method also returns
		/// WU_E_NO_UPDATE if the <c>Updates</c> property is set to an empty collection.
		/// </para>
		/// <para>
		/// When you use any asynchronous WUA API in your app, you might need to implement a time-out mechanism. For more info about how to
		/// perform asynchronous WUA operations, see Guidelines for Asynchronous WUA Operations.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateinstaller-begininstall HRESULT BeginInstall( [in]
		// IUnknown *onProgressChanged, [in] IUnknown *onCompleted, [in] VARIANT state, [out] IInstallationJob **retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020006)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IInstallationJob BeginInstall([In, MarshalAs(UnmanagedType.IUnknown)] object onProgressChanged,
			[In, MarshalAs(UnmanagedType.IUnknown)] object onCompleted, [In, MarshalAs(UnmanagedType.Struct)] object? state);

		/// <summary>Starts an asynchronous uninstallation of the updates.</summary>
		/// <param name="onProgressChanged">
		/// An IInstallationProgressChangedCallback interface that is called periodically for uninstallation progress changes before the
		/// uninstallation is complete.
		/// </param>
		/// <param name="onCompleted">An IInstallationCompletedCallback interface that is called when an installation operation is complete.</param>
		/// <param name="state">The caller-specific state that the AsyncState property IInstallationJob interface returns.</param>
		/// <returns>
		/// An IInstallationJob interface that contains the properties and methods that are available to an asynchronous uninstall operation
		/// that was initiated.
		/// </returns>
		/// <remarks>
		/// <para>
		/// If you call this method from a scripting language, set the <c>onProgressChanged</c> parameter to the identifier of an Automation
		/// object with a dispatch identifier (DSIPID) of zero (0) that implements the callback routine. Do the same thing for the
		/// <c>onCompleted</c> parameter.
		/// </para>
		/// <para>
		/// This method returns WU_E_NO_UPDATE if the Updates property of IUpdateInstaller is not set. This method also returns
		/// WU_E_NO_UPDATE if the <c>Updates</c> property is set to an empty collection.
		/// </para>
		/// <para>
		/// When you use any asynchronous WUA API in your app, you might need to implement a time-out mechanism. For more info about how to
		/// perform asynchronous WUA operations, see Guidelines for Asynchronous WUA Operations.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateinstaller-beginuninstall HRESULT BeginUninstall( [in]
		// IUnknown *onProgressChanged, [in] IUnknown *onCompleted, [in] VARIANT state, [out] IInstallationJob **retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020007)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IInstallationJob BeginUninstall([In, MarshalAs(UnmanagedType.IUnknown)] object onProgressChanged,
			[In, MarshalAs(UnmanagedType.IUnknown)] object onCompleted, [In, MarshalAs(UnmanagedType.Struct)] object? state);

		/// <summary>Completes an asynchronous installation of the updates.</summary>
		/// <param name="value">The IInstallationJob interface that is returned by the BeginInstall method.</param>
		/// <returns>An IInstallationResult interface that represents the overall result of the installation operation.</returns>
		/// <remarks>
		/// When you use any asynchronous WUA API in your app, you might need to implement a time-out mechanism. For more info about how to
		/// perform asynchronous WUA operations, see Guidelines for Asynchronous WUA Operations.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateinstaller-endinstall HRESULT EndInstall( [in]
		// IInstallationJob *value, [out] IInstallationResult **retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020008)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IInstallationResult EndInstall([In, MarshalAs(UnmanagedType.Interface)] IInstallationJob value);

		/// <summary>Completes an asynchronous uninstallation of the updates.</summary>
		/// <param name="value">The IInstallationJob interface that the BeginUninstall method returns.</param>
		/// <returns>An IInstallationResult interface that represents the overall result of an uninstallation operation.</returns>
		/// <remarks>
		/// When you use any asynchronous WUA API in your app, you might need to implement a time-out mechanism. For more info about how to
		/// perform asynchronous WUA operations, see Guidelines for Asynchronous WUA Operations.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateinstaller-enduninstall HRESULT EndUninstall( [in]
		// IInstallationJob *value, [out] IInstallationResult **retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020009)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IInstallationResult EndUninstall([In, MarshalAs(UnmanagedType.Interface)] IInstallationJob value);

		/// <summary>Starts a synchronous installation of the updates.</summary>
		/// <returns>
		/// An IInstallationResult interface that represents the results of an installation operation for each update that is specified in a request.
		/// </returns>
		/// <remarks>
		/// This method returns WU_E_NO_UPDATE if the Updates property of IUpdateInstaller is not set. This method also returns
		/// WU_E_NO_UPDATE if the <c>Updates</c> property is set to an empty collection.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateinstaller-install HRESULT Install( [out]
		// IInstallationResult **retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000a)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IInstallationResult Install();

		/// <summary>Starts a wizard that guides the local user through the steps to install the updates.</summary>
		/// <param name="dialogTitle">
		/// <para>An optional string value to be displayed in the title bar of the wizard.</para>
		/// <para>If an empty string value is used, the following text is displayed: Download and Install Updates.</para>
		/// </param>
		/// <returns>
		/// An IInstallationResult interface that represents the results of an installation operation for each update that is specified in
		/// the request.
		/// </returns>
		/// <remarks>
		/// This method returns WU_E_NO_UPDATE if the Updates property of IUpdateInstaller is not set. This method also returns
		/// WU_E_NO_UPDATE if the <c>Updates</c> property is set to an empty collection.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateinstaller-runwizard HRESULT RunWizard( [in, optional]
		// BSTR dialogTitle, [out] IInstallationResult **retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000b)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IInstallationResult RunWizard([In, MarshalAs(UnmanagedType.BStr)] string dialogTitle = "");

		/// <summary>
		/// <para>
		/// Gets a Boolean value that indicates whether an installation or uninstallation is in progress on a computer at a specific time.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// A new installation or uninstallation is processed only when no other installation or uninstallation is in progress. While an
		/// installation or uninstallation is in progress, a new installation or uninstallation immediately fails with the
		/// <c>WU_E_OPERATIONINPROGRESS</c> error. The <c>IsBusy</c> property does not secure an opportunity for the caller to begin a new
		/// installation or uninstallation. If the <c>IsBusy</c> property or a recent installation or uninstallation failure indicates that
		/// another installation or uninstallation is already in progress, the caller should attempt the installation or uninstallation later.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateinstaller-get_isbusy HRESULT get_IsBusy( VARIANT_BOOL
		// *retval );
		[DispId(0x6002000c)]
		new bool IsBusy
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000c)]
			get;
		}

		/// <summary>Starts a synchronous uninstallation of the updates.</summary>
		/// <returns>
		/// An IInstallationResult interface that represents the results of an uninstallation operation for each update that is specified in
		/// a request.
		/// </returns>
		/// <remarks>
		/// This method returns WU_E_NO_UPDATE if the Updates property of IUpdateInstaller is not set. This method also returns
		/// WU_E_NO_UPDATE if the <c>Updates</c> property is set to an empty collection.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateinstaller-uninstall HRESULT Uninstall( [out]
		// IInstallationResult **retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000d)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IInstallationResult Uninstall();

		/// <summary>
		/// <para>Gets and sets a Boolean value that indicates whether to show source prompts to the user when installing the updates.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateinstaller-put_allowsourceprompts HRESULT
		// put_AllowSourcePrompts( VARIANT_BOOL value );
		[DispId(0x6002000e)]
		new bool AllowSourcePrompts
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000e)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000e)]
			[param: In]
			set;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether a system restart is required before installing or uninstalling updates.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateinstaller-get_rebootrequiredbeforeinstallation HRESULT
		// get_RebootRequiredBeforeInstallation( VARIANT_BOOL *retval );
		[DispId(0x6002000f)]
		new bool RebootRequiredBeforeInstallation
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000f)]
			get;
		}

		/// <summary>
		/// <para>Gets and sets a Boolean value that indicates whether Windows Installer is forced to install the updates without user interaction.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>
		/// You cannot forcibly silence some updates. If an update does not support this action, and you try to install the update, the
		/// update returns the following: WU_E_UH_DOESNOTSUPPORTACTION.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateinstaller2-put_forcequiet HRESULT put_ForceQuiet(
		// VARIANT_BOOL value );
		[DispId(0x60030001)]
		bool ForceQuiet
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60030001)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60030001)]
			[param: In]
			set;
		}
	}

	/// <summary>
	/// Installs or uninstalls updates on a computer. This property is only used when installing Microsoft Store app updates. It has no
	/// effect when installing non-Microsoft Store app updates such as operating system, Defender, or driver updates.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nn-wuapi-iupdateinstaller3
	[PInvokeData("wuapi.h", MSDNShortId = "NN:wuapi.IUpdateInstaller3")]
	[ComImport, Guid("16d11c35-099a-48d0-8338-5fae64047f8e")]
	public interface IUpdateInstaller3 : IUpdateInstaller2
	{
		/// <summary>
		/// <para>Gets and sets the current client application.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>Returns the Unknown value if the client application has not set the property.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateinstaller-put_clientapplicationid HRESULT
		// put_ClientApplicationID( BSTR value );
		[DispId(0x60020001)]
		new string? ClientApplicationID
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020001)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020001)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>Gets or sets a Boolean value that indicates whether to forcibly install or uninstall an update.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// A forced installation is an installation in which an update is installed even if the metadata indicates that the update is
		/// already installed. A forced uninstallation is an uninstallation in which an update is removed even if the metadata indicates that
		/// the update is not installed.
		/// </para>
		/// <para>
		/// Before you use <c>IsForced</c> to force an installation, determine whether the update is installed and available. If an update is
		/// not installed, a forced installation fails. For example, an update can be downloaded, and then its corresponding files removed
		/// from the cache after the expiration limit. In this case, if the files are not installed, a forced installation of the update fails.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateinstaller-put_isforced HRESULT put_IsForced(
		// VARIANT_BOOL value );
		[DispId(0x60020002)]
		new bool IsForced
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020002)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020002)]
			[param: In]
			set;
		}

		/// <summary>
		/// <para>Gets and sets a handle to the parent window that can contain a dialog box.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>
		/// This property can be changed only by a user on the computer. This property cannot be accessed by using the <c>IDispatch</c> interface.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateinstaller-get_parenthwnd HRESULT get_ParentHwnd( HWND
		// *retval );
		[ComAliasName("WUApiLib.wireHWND"), DispId(0x60020003)]
		new HWND ParentHwnd
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020003)]
			[return: ComAliasName("WUApiLib.wireHWND")]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020003)]
			[param: In, ComAliasName("WUApiLib.wireHWND")]
			set;
		}

		/// <summary>
		/// <para>Gets and sets the interface that represents the parent window that can contain a dialog box.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>
		/// This property can be changed only by a user on the computer. This property can be accessed by using the IDispatch interface.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateinstaller-get_parentwindow HRESULT get_ParentWindow(
		// IUnknown **retval );
		[DispId(0x60020004)]
		new object? parentWindow
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020004)]
			[return: MarshalAs(UnmanagedType.IUnknown)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020004)]
			[param: In, MarshalAs(UnmanagedType.IUnknown)]
			set;
		}

		/// <summary>
		/// <para>Gets and sets an interface that contains a read-only collection of the updates that are specified for installation or uninstallation.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateinstaller-get_updates HRESULT get_Updates(
		// IUpdateCollection **retval );
		[DispId(0x60020005)]
		new IUpdateCollection Updates
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020005)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020005)]
			[param: In, MarshalAs(UnmanagedType.Interface)]
			set;
		}

		/// <summary>Starts an asynchronous installation of the updates.</summary>
		/// <param name="onProgressChanged">
		/// An IInstallationProgressChangedCallback interface that is called periodically for installation progress changes before the
		/// installation is complete.
		/// </param>
		/// <param name="onCompleted">An IInstallationCompletedCallback interface that is called when an installation operation is complete.</param>
		/// <param name="state">The caller-specific state that is returned by the AsyncState property of the IInstallationJob interface.</param>
		/// <returns>
		/// An IInstallationJob interface that contains the properties and methods that are available to an asynchronous installation
		/// operation that was initiated.
		/// </returns>
		/// <remarks>
		/// <para>
		/// If you call this method from a scripting language, set the <c>onProgressChanged</c> parameter to the identifier of an Automation
		/// object with a dispatch identifier (DSIPID) of zero (0) that implements the callback routine. Do the same thing for the
		/// <c>onCompleted</c> parameter.
		/// </para>
		/// <para>
		/// This method returns WU_E_NO_UPDATE if the Updates property of IUpdateInstaller is not set. This method also returns
		/// WU_E_NO_UPDATE if the <c>Updates</c> property is set to an empty collection.
		/// </para>
		/// <para>
		/// When you use any asynchronous WUA API in your app, you might need to implement a time-out mechanism. For more info about how to
		/// perform asynchronous WUA operations, see Guidelines for Asynchronous WUA Operations.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateinstaller-begininstall HRESULT BeginInstall( [in]
		// IUnknown *onProgressChanged, [in] IUnknown *onCompleted, [in] VARIANT state, [out] IInstallationJob **retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020006)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IInstallationJob BeginInstall([In, MarshalAs(UnmanagedType.IUnknown)] object onProgressChanged,
			[In, MarshalAs(UnmanagedType.IUnknown)] object onCompleted, [In, MarshalAs(UnmanagedType.Struct)] object? state);

		/// <summary>Starts an asynchronous uninstallation of the updates.</summary>
		/// <param name="onProgressChanged">
		/// An IInstallationProgressChangedCallback interface that is called periodically for uninstallation progress changes before the
		/// uninstallation is complete.
		/// </param>
		/// <param name="onCompleted">An IInstallationCompletedCallback interface that is called when an installation operation is complete.</param>
		/// <param name="state">The caller-specific state that the AsyncState property IInstallationJob interface returns.</param>
		/// <returns>
		/// An IInstallationJob interface that contains the properties and methods that are available to an asynchronous uninstall operation
		/// that was initiated.
		/// </returns>
		/// <remarks>
		/// <para>
		/// If you call this method from a scripting language, set the <c>onProgressChanged</c> parameter to the identifier of an Automation
		/// object with a dispatch identifier (DSIPID) of zero (0) that implements the callback routine. Do the same thing for the
		/// <c>onCompleted</c> parameter.
		/// </para>
		/// <para>
		/// This method returns WU_E_NO_UPDATE if the Updates property of IUpdateInstaller is not set. This method also returns
		/// WU_E_NO_UPDATE if the <c>Updates</c> property is set to an empty collection.
		/// </para>
		/// <para>
		/// When you use any asynchronous WUA API in your app, you might need to implement a time-out mechanism. For more info about how to
		/// perform asynchronous WUA operations, see Guidelines for Asynchronous WUA Operations.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateinstaller-beginuninstall HRESULT BeginUninstall( [in]
		// IUnknown *onProgressChanged, [in] IUnknown *onCompleted, [in] VARIANT state, [out] IInstallationJob **retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020007)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IInstallationJob BeginUninstall([In, MarshalAs(UnmanagedType.IUnknown)] object onProgressChanged,
			[In, MarshalAs(UnmanagedType.IUnknown)] object onCompleted, [In, MarshalAs(UnmanagedType.Struct)] object? state);

		/// <summary>Completes an asynchronous installation of the updates.</summary>
		/// <param name="value">The IInstallationJob interface that is returned by the BeginInstall method.</param>
		/// <returns>An IInstallationResult interface that represents the overall result of the installation operation.</returns>
		/// <remarks>
		/// When you use any asynchronous WUA API in your app, you might need to implement a time-out mechanism. For more info about how to
		/// perform asynchronous WUA operations, see Guidelines for Asynchronous WUA Operations.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateinstaller-endinstall HRESULT EndInstall( [in]
		// IInstallationJob *value, [out] IInstallationResult **retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020008)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IInstallationResult EndInstall([In, MarshalAs(UnmanagedType.Interface)] IInstallationJob value);

		/// <summary>Completes an asynchronous uninstallation of the updates.</summary>
		/// <param name="value">The IInstallationJob interface that the BeginUninstall method returns.</param>
		/// <returns>An IInstallationResult interface that represents the overall result of an uninstallation operation.</returns>
		/// <remarks>
		/// When you use any asynchronous WUA API in your app, you might need to implement a time-out mechanism. For more info about how to
		/// perform asynchronous WUA operations, see Guidelines for Asynchronous WUA Operations.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateinstaller-enduninstall HRESULT EndUninstall( [in]
		// IInstallationJob *value, [out] IInstallationResult **retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020009)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IInstallationResult EndUninstall([In, MarshalAs(UnmanagedType.Interface)] IInstallationJob value);

		/// <summary>Starts a synchronous installation of the updates.</summary>
		/// <returns>
		/// An IInstallationResult interface that represents the results of an installation operation for each update that is specified in a request.
		/// </returns>
		/// <remarks>
		/// This method returns WU_E_NO_UPDATE if the Updates property of IUpdateInstaller is not set. This method also returns
		/// WU_E_NO_UPDATE if the <c>Updates</c> property is set to an empty collection.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateinstaller-install HRESULT Install( [out]
		// IInstallationResult **retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000a)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IInstallationResult Install();

		/// <summary>Starts a wizard that guides the local user through the steps to install the updates.</summary>
		/// <param name="dialogTitle">
		/// <para>An optional string value to be displayed in the title bar of the wizard.</para>
		/// <para>If an empty string value is used, the following text is displayed: Download and Install Updates.</para>
		/// </param>
		/// <returns>
		/// An IInstallationResult interface that represents the results of an installation operation for each update that is specified in
		/// the request.
		/// </returns>
		/// <remarks>
		/// This method returns WU_E_NO_UPDATE if the Updates property of IUpdateInstaller is not set. This method also returns
		/// WU_E_NO_UPDATE if the <c>Updates</c> property is set to an empty collection.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateinstaller-runwizard HRESULT RunWizard( [in, optional]
		// BSTR dialogTitle, [out] IInstallationResult **retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000b)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IInstallationResult RunWizard([In, MarshalAs(UnmanagedType.BStr)] string dialogTitle = "");

		/// <summary>
		/// <para>
		/// Gets a Boolean value that indicates whether an installation or uninstallation is in progress on a computer at a specific time.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// A new installation or uninstallation is processed only when no other installation or uninstallation is in progress. While an
		/// installation or uninstallation is in progress, a new installation or uninstallation immediately fails with the
		/// <c>WU_E_OPERATIONINPROGRESS</c> error. The <c>IsBusy</c> property does not secure an opportunity for the caller to begin a new
		/// installation or uninstallation. If the <c>IsBusy</c> property or a recent installation or uninstallation failure indicates that
		/// another installation or uninstallation is already in progress, the caller should attempt the installation or uninstallation later.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateinstaller-get_isbusy HRESULT get_IsBusy( VARIANT_BOOL
		// *retval );
		[DispId(0x6002000c)]
		new bool IsBusy
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000c)]
			get;
		}

		/// <summary>Starts a synchronous uninstallation of the updates.</summary>
		/// <returns>
		/// An IInstallationResult interface that represents the results of an uninstallation operation for each update that is specified in
		/// a request.
		/// </returns>
		/// <remarks>
		/// This method returns WU_E_NO_UPDATE if the Updates property of IUpdateInstaller is not set. This method also returns
		/// WU_E_NO_UPDATE if the <c>Updates</c> property is set to an empty collection.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateinstaller-uninstall HRESULT Uninstall( [out]
		// IInstallationResult **retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000d)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IInstallationResult Uninstall();

		/// <summary>
		/// <para>Gets and sets a Boolean value that indicates whether to show source prompts to the user when installing the updates.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateinstaller-put_allowsourceprompts HRESULT
		// put_AllowSourcePrompts( VARIANT_BOOL value );
		[DispId(0x6002000e)]
		new bool AllowSourcePrompts
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000e)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000e)]
			[param: In]
			set;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether a system restart is required before installing or uninstalling updates.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateinstaller-get_rebootrequiredbeforeinstallation HRESULT
		// get_RebootRequiredBeforeInstallation( VARIANT_BOOL *retval );
		[DispId(0x6002000f)]
		new bool RebootRequiredBeforeInstallation
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000f)]
			get;
		}

		/// <summary>
		/// <para>Gets and sets a Boolean value that indicates whether Windows Installer is forced to install the updates without user interaction.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>
		/// You cannot forcibly silence some updates. If an update does not support this action, and you try to install the update, the
		/// update returns the following: WU_E_UH_DOESNOTSUPPORTACTION.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateinstaller2-put_forcequiet HRESULT put_ForceQuiet(
		// VARIANT_BOOL value );
		[DispId(0x60030001)]
		new bool ForceQuiet
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60030001)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60030001)]
			[param: In]
			set;
		}

		/// <summary>
		/// Gets a value indicating whether the update installer will attempt to close applications, blocking immediate installation of updates.
		/// </summary>
		/// <returns>True if the installer will attempt to close applications.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateinstaller3-get_attemptcloseappsifnecessary HRESULT
		// get_AttemptCloseAppsIfNecessary( [out] VARIANT_BOOL *retval );
		[DispId(0x60040001)]
		bool AttemptCloseAppsIfNecessary
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60040001)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60040001)]
			[param: In]
			set;
		}
	}

	/// <summary>Provides methods to finalize updates that were previously staged or installed.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nn-wuapi-iupdateinstaller4
	[PInvokeData("wuapi.h", MSDNShortId = "NN:wuapi.IUpdateInstaller4")]
	[ComImport, Guid("EF8208EA-2304-492D-9109-23813B0958E1"), CoClass(typeof(UpdateInstallerClass))]
	public interface IUpdateInstaller4 : IUpdateInstaller3
	{
		/// <summary>
		/// <para>Gets and sets the current client application.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>Returns the Unknown value if the client application has not set the property.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateinstaller-put_clientapplicationid HRESULT
		// put_ClientApplicationID( BSTR value );
		[DispId(0x60020001)]
		new string? ClientApplicationID
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020001)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020001)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>Gets or sets a Boolean value that indicates whether to forcibly install or uninstall an update.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// A forced installation is an installation in which an update is installed even if the metadata indicates that the update is
		/// already installed. A forced uninstallation is an uninstallation in which an update is removed even if the metadata indicates that
		/// the update is not installed.
		/// </para>
		/// <para>
		/// Before you use <c>IsForced</c> to force an installation, determine whether the update is installed and available. If an update is
		/// not installed, a forced installation fails. For example, an update can be downloaded, and then its corresponding files removed
		/// from the cache after the expiration limit. In this case, if the files are not installed, a forced installation of the update fails.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateinstaller-put_isforced HRESULT put_IsForced(
		// VARIANT_BOOL value );
		[DispId(0x60020002)]
		new bool IsForced
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020002)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020002)]
			[param: In]
			set;
		}

		/// <summary>
		/// <para>Gets and sets a handle to the parent window that can contain a dialog box.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>
		/// This property can be changed only by a user on the computer. This property cannot be accessed by using the <c>IDispatch</c> interface.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateinstaller-get_parenthwnd HRESULT get_ParentHwnd( HWND
		// *retval );
		[ComAliasName("WUApiLib.wireHWND"), DispId(0x60020003)]
		new HWND ParentHwnd
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020003)]
			[return: ComAliasName("WUApiLib.wireHWND")]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020003)]
			[param: In, ComAliasName("WUApiLib.wireHWND")]
			set;
		}

		/// <summary>
		/// <para>Gets and sets the interface that represents the parent window that can contain a dialog box.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>
		/// This property can be changed only by a user on the computer. This property can be accessed by using the IDispatch interface.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateinstaller-get_parentwindow HRESULT get_ParentWindow(
		// IUnknown **retval );
		[DispId(0x60020004)]
		new object? parentWindow
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020004)]
			[return: MarshalAs(UnmanagedType.IUnknown)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020004)]
			[param: In, MarshalAs(UnmanagedType.IUnknown)]
			set;
		}

		/// <summary>
		/// <para>Gets and sets an interface that contains a read-only collection of the updates that are specified for installation or uninstallation.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateinstaller-get_updates HRESULT get_Updates(
		// IUpdateCollection **retval );
		[DispId(0x60020005)]
		new IUpdateCollection Updates
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020005)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020005)]
			[param: In, MarshalAs(UnmanagedType.Interface)]
			set;
		}

		/// <summary>Starts an asynchronous installation of the updates.</summary>
		/// <param name="onProgressChanged">
		/// An IInstallationProgressChangedCallback interface that is called periodically for installation progress changes before the
		/// installation is complete.
		/// </param>
		/// <param name="onCompleted">An IInstallationCompletedCallback interface that is called when an installation operation is complete.</param>
		/// <param name="state">The caller-specific state that is returned by the AsyncState property of the IInstallationJob interface.</param>
		/// <returns>
		/// An IInstallationJob interface that contains the properties and methods that are available to an asynchronous installation
		/// operation that was initiated.
		/// </returns>
		/// <remarks>
		/// <para>
		/// If you call this method from a scripting language, set the <c>onProgressChanged</c> parameter to the identifier of an Automation
		/// object with a dispatch identifier (DSIPID) of zero (0) that implements the callback routine. Do the same thing for the
		/// <c>onCompleted</c> parameter.
		/// </para>
		/// <para>
		/// This method returns WU_E_NO_UPDATE if the Updates property of IUpdateInstaller is not set. This method also returns
		/// WU_E_NO_UPDATE if the <c>Updates</c> property is set to an empty collection.
		/// </para>
		/// <para>
		/// When you use any asynchronous WUA API in your app, you might need to implement a time-out mechanism. For more info about how to
		/// perform asynchronous WUA operations, see Guidelines for Asynchronous WUA Operations.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateinstaller-begininstall HRESULT BeginInstall( [in]
		// IUnknown *onProgressChanged, [in] IUnknown *onCompleted, [in] VARIANT state, [out] IInstallationJob **retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020006)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IInstallationJob BeginInstall([In, MarshalAs(UnmanagedType.IUnknown)] object onProgressChanged,
			[In, MarshalAs(UnmanagedType.IUnknown)] object onCompleted, [In, MarshalAs(UnmanagedType.Struct)] object? state);

		/// <summary>Starts an asynchronous uninstallation of the updates.</summary>
		/// <param name="onProgressChanged">
		/// An IInstallationProgressChangedCallback interface that is called periodically for uninstallation progress changes before the
		/// uninstallation is complete.
		/// </param>
		/// <param name="onCompleted">An IInstallationCompletedCallback interface that is called when an installation operation is complete.</param>
		/// <param name="state">The caller-specific state that the AsyncState property IInstallationJob interface returns.</param>
		/// <returns>
		/// An IInstallationJob interface that contains the properties and methods that are available to an asynchronous uninstall operation
		/// that was initiated.
		/// </returns>
		/// <remarks>
		/// <para>
		/// If you call this method from a scripting language, set the <c>onProgressChanged</c> parameter to the identifier of an Automation
		/// object with a dispatch identifier (DSIPID) of zero (0) that implements the callback routine. Do the same thing for the
		/// <c>onCompleted</c> parameter.
		/// </para>
		/// <para>
		/// This method returns WU_E_NO_UPDATE if the Updates property of IUpdateInstaller is not set. This method also returns
		/// WU_E_NO_UPDATE if the <c>Updates</c> property is set to an empty collection.
		/// </para>
		/// <para>
		/// When you use any asynchronous WUA API in your app, you might need to implement a time-out mechanism. For more info about how to
		/// perform asynchronous WUA operations, see Guidelines for Asynchronous WUA Operations.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateinstaller-beginuninstall HRESULT BeginUninstall( [in]
		// IUnknown *onProgressChanged, [in] IUnknown *onCompleted, [in] VARIANT state, [out] IInstallationJob **retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020007)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IInstallationJob BeginUninstall([In, MarshalAs(UnmanagedType.IUnknown)] object onProgressChanged,
			[In, MarshalAs(UnmanagedType.IUnknown)] object onCompleted, [In, MarshalAs(UnmanagedType.Struct)] object? state);

		/// <summary>Completes an asynchronous installation of the updates.</summary>
		/// <param name="value">The IInstallationJob interface that is returned by the BeginInstall method.</param>
		/// <returns>An IInstallationResult interface that represents the overall result of the installation operation.</returns>
		/// <remarks>
		/// When you use any asynchronous WUA API in your app, you might need to implement a time-out mechanism. For more info about how to
		/// perform asynchronous WUA operations, see Guidelines for Asynchronous WUA Operations.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateinstaller-endinstall HRESULT EndInstall( [in]
		// IInstallationJob *value, [out] IInstallationResult **retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020008)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IInstallationResult EndInstall([In, MarshalAs(UnmanagedType.Interface)] IInstallationJob value);

		/// <summary>Completes an asynchronous uninstallation of the updates.</summary>
		/// <param name="value">The IInstallationJob interface that the BeginUninstall method returns.</param>
		/// <returns>An IInstallationResult interface that represents the overall result of an uninstallation operation.</returns>
		/// <remarks>
		/// When you use any asynchronous WUA API in your app, you might need to implement a time-out mechanism. For more info about how to
		/// perform asynchronous WUA operations, see Guidelines for Asynchronous WUA Operations.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateinstaller-enduninstall HRESULT EndUninstall( [in]
		// IInstallationJob *value, [out] IInstallationResult **retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020009)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IInstallationResult EndUninstall([In, MarshalAs(UnmanagedType.Interface)] IInstallationJob value);

		/// <summary>Starts a synchronous installation of the updates.</summary>
		/// <returns>
		/// An IInstallationResult interface that represents the results of an installation operation for each update that is specified in a request.
		/// </returns>
		/// <remarks>
		/// This method returns WU_E_NO_UPDATE if the Updates property of IUpdateInstaller is not set. This method also returns
		/// WU_E_NO_UPDATE if the <c>Updates</c> property is set to an empty collection.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateinstaller-install HRESULT Install( [out]
		// IInstallationResult **retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000a)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IInstallationResult Install();

		/// <summary>Starts a wizard that guides the local user through the steps to install the updates.</summary>
		/// <param name="dialogTitle">
		/// <para>An optional string value to be displayed in the title bar of the wizard.</para>
		/// <para>If an empty string value is used, the following text is displayed: Download and Install Updates.</para>
		/// </param>
		/// <returns>
		/// An IInstallationResult interface that represents the results of an installation operation for each update that is specified in
		/// the request.
		/// </returns>
		/// <remarks>
		/// This method returns WU_E_NO_UPDATE if the Updates property of IUpdateInstaller is not set. This method also returns
		/// WU_E_NO_UPDATE if the <c>Updates</c> property is set to an empty collection.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateinstaller-runwizard HRESULT RunWizard( [in, optional]
		// BSTR dialogTitle, [out] IInstallationResult **retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000b)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IInstallationResult RunWizard([In, MarshalAs(UnmanagedType.BStr)] string dialogTitle = "");

		/// <summary>
		/// <para>
		/// Gets a Boolean value that indicates whether an installation or uninstallation is in progress on a computer at a specific time.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// A new installation or uninstallation is processed only when no other installation or uninstallation is in progress. While an
		/// installation or uninstallation is in progress, a new installation or uninstallation immediately fails with the
		/// <c>WU_E_OPERATIONINPROGRESS</c> error. The <c>IsBusy</c> property does not secure an opportunity for the caller to begin a new
		/// installation or uninstallation. If the <c>IsBusy</c> property or a recent installation or uninstallation failure indicates that
		/// another installation or uninstallation is already in progress, the caller should attempt the installation or uninstallation later.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateinstaller-get_isbusy HRESULT get_IsBusy( VARIANT_BOOL
		// *retval );
		[DispId(0x6002000c)]
		new bool IsBusy
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000c)]
			get;
		}

		/// <summary>Starts a synchronous uninstallation of the updates.</summary>
		/// <returns>
		/// An IInstallationResult interface that represents the results of an uninstallation operation for each update that is specified in
		/// a request.
		/// </returns>
		/// <remarks>
		/// This method returns WU_E_NO_UPDATE if the Updates property of IUpdateInstaller is not set. This method also returns
		/// WU_E_NO_UPDATE if the <c>Updates</c> property is set to an empty collection.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateinstaller-uninstall HRESULT Uninstall( [out]
		// IInstallationResult **retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000d)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IInstallationResult Uninstall();

		/// <summary>
		/// <para>Gets and sets a Boolean value that indicates whether to show source prompts to the user when installing the updates.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateinstaller-put_allowsourceprompts HRESULT
		// put_AllowSourcePrompts( VARIANT_BOOL value );
		[DispId(0x6002000e)]
		new bool AllowSourcePrompts
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000e)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000e)]
			[param: In]
			set;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether a system restart is required before installing or uninstalling updates.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateinstaller-get_rebootrequiredbeforeinstallation HRESULT
		// get_RebootRequiredBeforeInstallation( VARIANT_BOOL *retval );
		[DispId(0x6002000f)]
		new bool RebootRequiredBeforeInstallation
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6002000f)]
			get;
		}

		/// <summary>
		/// <para>Gets and sets a Boolean value that indicates whether Windows Installer is forced to install the updates without user interaction.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>
		/// You cannot forcibly silence some updates. If an update does not support this action, and you try to install the update, the
		/// update returns the following: WU_E_UH_DOESNOTSUPPORTACTION.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateinstaller2-put_forcequiet HRESULT put_ForceQuiet(
		// VARIANT_BOOL value );
		[DispId(0x60030001)]
		new bool ForceQuiet
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60030001)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60030001)]
			[param: In]
			set;
		}

		/// <summary>
		/// Gets a value indicating whether the update installer will attempt to close applications, blocking immediate installation of updates.
		/// </summary>
		/// <returns>True if the installer will attempt to close applications.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateinstaller3-get_attemptcloseappsifnecessary HRESULT
		// get_AttemptCloseAppsIfNecessary( [out] VARIANT_BOOL *retval );
		[DispId(0x60040001)]
		new bool AttemptCloseAppsIfNecessary
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60040001)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60040001)]
			[param: In]
			set;
		}

		/// <summary>Finalizes updates that were previously staged or installed.</summary>
		/// <param name="dwFlags">Reserved for future use.</param>
		/// <remarks>
		/// <para>
		/// The <c>Commit</c> API was made public in the 1809 SDK. Any app compiled with the wuapi.h header can use the <c>Commit</c> method
		/// on previous versions of Windows 10 as well.
		/// </para>
		/// <para>
		/// <c>Commit</c> should only be called once. This call should happen just prior to commencing a reboot. Calling it multiple times
		/// prior to a reboot is not supported and may cause the update to fail.
		/// </para>
		/// <para>
		/// Calling <c>Commit</c> is required prior to rebooting when a feature update is pending reboot. If <c>Commit</c> is not called in
		/// this circumstance the update won’t be finalized and installed during the reboot.
		/// </para>
		/// <para><c>Commit</c> is safe to call prior to reboot for any other types of updates as well.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateinstaller4-commit HRESULT Commit( DWORD dwFlags );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60040002)]
		void Commit([In] uint dwFlags);
	}

	/// <summary>Restricts access to methods and properties of objects that implements the method of this interface.</summary>
	/// <remarks>
	/// <para>
	/// The <c>IUpdateLockdown</c> interface is derived from IUnknown, not IDispatch. It cannot be accessed by using a script. This interface
	/// restricts access to the Windows Update website.
	/// </para>
	/// <para>The following classes implement the <c>IUpdateLockdown</c> interface:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>AutomaticUpdates</description>
	/// </item>
	/// <item>
	/// <description>UpdateDownloader</description>
	/// </item>
	/// <item>
	/// <description>UpdateInstaller</description>
	/// </item>
	/// <item>
	/// <description>UpdateServiceManager</description>
	/// </item>
	/// <item>
	/// <description>WebProxy</description>
	/// </item>
	/// </list>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nn-wuapi-iupdatelockdown
	[PInvokeData("wuapi.h", MSDNShortId = "NN:wuapi.IUpdateLockdown")]
	[ComImport, Guid("A976C28D-75A1-42AA-94AE-8AF8B872089A"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IUpdateLockdown
	{
		/// <summary>Restricts access to the methods and properties of the object that implements this method.</summary>
		/// <param name="flags">
		/// <para>The option to restrict access to various Windows Update Agent (WUA) objects from the Windows Update website.</para>
		/// <para>
		/// Setting this parameter to <c>uloForWebsiteAccess</c> or to 1 (one) restricts access to the WUA interfaces that implement the
		/// IUpdateLockdown interface.
		/// </para>
		/// <para>
		/// For a list of the methods and properties that the WUA interfaces restrict when this value is specified, see the "Remarks" section.
		/// </para>
		/// </param>
		/// <remarks>
		/// <para>The following table identifies the interfaces that implement the IUpdateLockdown interface.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>WUA object</description>
		/// <description>Restricted methods and properties</description>
		/// </listheader>
		/// <item>
		/// <description>IAutomaticUpdates</description>
		/// <description>Pause Resume</description>
		/// </item>
		/// <item>
		/// <description>IAutomaticUpdatesSettings</description>
		/// <description>Save</description>
		/// </item>
		/// <item>
		/// <description>IUpdate</description>
		/// <description>AcceptEula CopyFromCache CopyToCache</description>
		/// </item>
		/// <item>
		/// <description>IUpdateDownloader</description>
		/// <description>BeginDownload Download EndDownload IsForced (cannot set)</description>
		/// </item>
		/// <item>
		/// <description>IUpdateInstaller</description>
		/// <description>BeginInstall BeginUninstall EndInstall EndUninstall Install IsForced (cannot set) Uninstall</description>
		/// </item>
		/// <item>
		/// <description>IUpdateServiceManager</description>
		/// <description>AddScanPackageService RemoveService SetOption</description>
		/// </item>
		/// <item>
		/// <description>IWebProxy</description>
		/// <description>
		/// Address (cannot set) AutoDetect (cannot set) BypassList (cannot set) BypassProxyOnLocal (cannot set) SetPassword UserName (cannot set)
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatelockdown-lockdown HRESULT LockDown( [in] LONG flags );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void LockDown([In] UpdateLockdownOption flags);
	}

	/// <summary>Searches for updates on a server.</summary>
	/// <remarks>
	/// You can create an instance of this interface by using the UpdateSearcher coclass. Use the Microsoft.Update.Searcher program
	/// identifier to create the object.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nn-wuapi-iupdatesearcher
	[PInvokeData("wuapi.h", MSDNShortId = "NN:wuapi.IUpdateSearcher")]
	[ComImport, Guid("8F45ABF1-F9AE-4B95-A933-F0F66E5056EA"), CoClass(typeof(UpdateSearcherClass))]
	public interface IUpdateSearcher
	{
		/// <summary>
		/// <para>
		/// Gets and sets a Boolean value that indicates whether future calls to the BeginSearch and Search methods result in an automatic
		/// upgrade to Windows Update Agent (WUA). Currently, this property's valid value corresponds to the option that does not
		/// automatically upgrade WUA.
		/// </para>
		/// <para>This property is read/write.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatesearcher-get_canautomaticallyupgradeservice HRESULT
		// get_CanAutomaticallyUpgradeService( VARIANT_BOOL *retval );
		[DispId(1610743809)]
		bool CanAutomaticallyUpgradeService
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743809)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743809)]
			[param: In]
			set;
		}

		/// <summary>
		/// <para>Identifies the current client application.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>Returns the Unknown value if the client application has not set the property.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatesearcher-get_clientapplicationid HRESULT
		// get_ClientApplicationID( BSTR *retval );
		[DispId(1610743811)]
		string ClientApplicationID
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743811)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743811)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>
		/// Gets and sets a Boolean value that indicates whether the search results include updates that are superseded by other updates in
		/// the search results.
		/// </para>
		/// <para>This property is read/write.</para>
		/// <para>
		/// <para>Note</para>
		/// <para>This property is no longer supported in Windows 10, version 1709 (build 16299), and later OS releases.</para>
		/// </para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatesearcher-get_includepotentiallysupersededupdates HRESULT
		// get_IncludePotentiallySupersededUpdates( VARIANT_BOOL *retval );
		[DispId(1610743812)]
		bool IncludePotentiallySupersededUpdates
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743812)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743812)]
			[param: In]
			set;
		}

		/// <summary>
		/// <para>Gets and sets a ServerSelection value that indicates the server to search for updates.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>
		/// The site that is not a Windows Update site that is specified by the value of the ServiceID property is searched only if the value
		/// of the <c>ServerSelection</c> property is ssOthers.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatesearcher-get_serverselection HRESULT
		// get_ServerSelection( ServerSelection *retval );
		[DispId(1610743815), ComAliasName("WUApiLib.ServerSelection")]
		ServerSelection ServerSelection
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743815)]
			[return: ComAliasName("WUApiLib.ServerSelection")]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743815)]
			[param: In, ComAliasName("WUApiLib.ServerSelection")]
			set;
		}

		/// <summary>Begins execution of an asynchronous search for updates. The search uses the search options that are currently configured.</summary>
		/// <param name="criteria">A string that specifies the search criteria.</param>
		/// <param name="onCompleted">An ISearchCompletedCallback interface that is called when an asynchronous search operation is complete.</param>
		/// <param name="state">The caller-specific state that is returned by the AsyncState property of the ISearchJob interface.</param>
		/// <returns>
		/// <para>An ISearchJob interface that represents the current operation that might be pending.</para>
		/// <para>The caller passes the returned value to the EndSearch method to complete a search operation.</para>
		/// </returns>
		/// <remarks>
		/// <para>For a complete description of search criteria syntax, see Search.</para>
		/// <para>
		/// As an alternative to implementing the ISearchCompletedCallback interface, you can use a script to implement a callback routine of
		/// any identifier with DISPID 0 on an automation object. The type of the <c>onCompleted</c> parameter is <c>IUnknown*</c>.
		/// </para>
		/// <para>
		/// When you use any asynchronous WUA API in your app, you might need to implement a time-out mechanism. For more info about how to
		/// perform asynchronous WUA operations, see Guidelines for Asynchronous WUA Operations.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatesearcher-beginsearch HRESULT BeginSearch( [in] BSTR
		// criteria, [in] IUnknown *onCompleted, [in] VARIANT state, [out] ISearchJob **retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743816)]
		[return: MarshalAs(UnmanagedType.Interface)]
		ISearchJob BeginSearch([In, MarshalAs(UnmanagedType.BStr)] string criteria,
			[In] ISearchCompletedCallback onCompleted, [In, Optional, MarshalAs(UnmanagedType.Struct)] object? state);

		/// <summary>Completes an asynchronous search for updates.</summary>
		/// <param name="searchJob">The ISearchJob interface that the BeginSearch method returns.</param>
		/// <returns>
		/// <para>An ISearchResult interface that contains the following:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>The result of an operation</description>
		/// </item>
		/// <item>
		/// <description>A collection of updates that match the search criteria</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// When you use any asynchronous WUA API in your app, you might need to implement a time-out mechanism. For more info about how to
		/// perform asynchronous WUA operations, see Guidelines for Asynchronous WUA Operations.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatesearcher-endsearch HRESULT EndSearch( [in] ISearchJob
		// *searchJob, [out] ISearchResult **retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743817)]
		[return: MarshalAs(UnmanagedType.Interface)]
		ISearchResult EndSearch([In, MarshalAs(UnmanagedType.Interface)] ISearchJob searchJob);

		/// <summary>Converts a string into a string that can be used as a literal value in a search criteria string.</summary>
		/// <param name="unescaped">A string to be escaped.</param>
		/// <returns>The resulting escaped string.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatesearcher-escapestring HRESULT EscapeString( [in] BSTR
		// unescaped, [out] BSTR *retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743818)]
		[return: MarshalAs(UnmanagedType.BStr)]
		string? EscapeString([In, MarshalAs(UnmanagedType.BStr)] string? unescaped);

		/// <summary>Synchronously queries the computer for the history of the update events.</summary>
		/// <param name="startIndex">The index of the first event to retrieve.</param>
		/// <param name="count">The number of events to retrieve.</param>
		/// <returns>
		/// A pointer to an IUpdateHistoryEntryCollection interface that contains matching event records on the computer in descending
		/// chronological order.
		/// </returns>
		/// <remarks>
		/// This method returns <c>WU_E_INVALIDINDEX</c> if the <c>startIndex</c> parameter is less than 0 (zero) or if the <c>Count</c>
		/// parameter is less than or equal to 0 (zero).
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatesearcher-queryhistory HRESULT QueryHistory( [in] LONG
		// startIndex, [in] LONG count, [out] IUpdateHistoryEntryCollection **retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743819)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IUpdateHistoryEntryCollection QueryHistory([In] int startIndex, [In] int count);

		/// <summary>Performs a synchronous search for updates. The search uses the search options that are currently configured.</summary>
		/// <param name="criteria">A string that specifies the search criteria.</param>
		/// <returns>
		/// <para>An ISearchResult interface that contains the following:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>The result of an operation</description>
		/// </item>
		/// <item>
		/// <description>A collection of updates that match the search criteria</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The string that is used for the <c>criteria</c> parameter must match the custom search language for the <c>Search</c> method. The
		/// string consists of criteria that are evaluated to determine the updates to return.
		/// </para>
		/// <para>
		/// Each criterion specifies an update property name and value. With some restrictions, multiple criteria can be connected with the
		/// <c>AND</c> and <c>OR</c> operators. The <c>=</c> (equal) and <c>!=</c> (not-equal) operators are both supported. When you use
		/// Windows Update Agent (WUA), the <c>!=</c> (not-equal) operator can be used only with the type criterion.
		/// </para>
		/// <para>
		/// The search criteria syntax is based on the WHERE clause of an SQL query expression. Most of the supported criteria map directly
		/// to update properties. These update properties resemble the elements in a virtual XML document that contains the entire server
		/// catalog. For example, if you specify a search criteria string of "AutoSelectOnWebSites = 1", the search returns all the updates
		/// that have a AutoSelectOnWebSites property with a value of <c>VARIANT_TRUE</c>.
		/// </para>
		/// <para>
		/// A single criterion consists of " <c>Name</c> = <c>Value</c>" or " <c>Name</c> != <c>Value</c>", where " <c>Name</c>" is one of
		/// the supported criterion names, and " <c>Value</c>" is a string or an integer. The <c>AND</c> and <c>OR</c> operators can be used
		/// to connect multiple criteria. However, <c>OR</c> can be used only at the top level of the search criteria. Therefore, "(x=1 and
		/// y=1) or (z=1)" is valid, but "(x=1) and (y=1 or z=1)" is not valid.
		/// </para>
		/// <para>
		/// The supported value types are integers and strings. An integer must be specified in base 10, and negative numbers are prefixed
		/// with a minus sign ( <c>-</c>). A string must be escaped and enclosed in single quotation marks ('). All string comparisons are
		/// case-insensitive unless specified.
		/// </para>
		/// <para>
		/// The following table identifies all the public support criteria in the order of evaluation precedence. More criteria may be added
		/// to this list in the future.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Criterion</description>
		/// <description>Type</description>
		/// <description>Allowed operators</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>Type</description>
		/// <description><c>string</c></description>
		/// <description><c>=</c>, <c>!=</c></description>
		/// <description>Finds updates of a specific type, such as "'Driver'" and "'Software'".</description>
		/// </item>
		/// <item>
		/// <description>DeploymentAction</description>
		/// <description><c>string</c></description>
		/// <description><c>=</c></description>
		/// <description>
		/// Finds updates that are deployed for a specific action, such as an installation or uninstallation that the administrator of a
		/// server specifies. "DeploymentAction='Installation'" finds updates that are deployed for installation on a destination computer.
		/// "DeploymentAction='Uninstallation'" depends on the other query criteria. "DeploymentAction='Uninstallation'" finds updates that
		/// are deployed for uninstallation on a destination computer. "DeploymentAction='Uninstallation'" depends on the other query
		/// criteria. If this criterion is not explicitly specified, each group of criteria that is joined to an <c>AND</c> operator implies "DeploymentAction='Installation'".
		/// </description>
		/// </item>
		/// <item>
		/// <description>IsAssigned</description>
		/// <description><c>int(bool)</c></description>
		/// <description><c>=</c></description>
		/// <description>
		/// Finds updates that are intended for deployment by Automatic Updates. "IsAssigned=1" finds updates that are intended for
		/// deployment by Automatic Updates, which depends on the other query criteria. At most, one assigned Windows-based driver update is
		/// returned for each local device on a destination computer. "IsAssigned=0" finds updates that are not intended to be deployed by
		/// Automatic Updates.
		/// </description>
		/// </item>
		/// <item>
		/// <description>BrowseOnly</description>
		/// <description><c>int(bool)</c></description>
		/// <description><c>=</c></description>
		/// <description>
		/// "BrowseOnly=1" finds updates that are considered optional. "BrowseOnly=0" finds updates that are not considered optional.
		/// </description>
		/// </item>
		/// <item>
		/// <description>AutoSelectOnWebSites</description>
		/// <description><c>int(bool)</c></description>
		/// <description><c>=</c></description>
		/// <description>
		/// Finds updates where the AutoSelectOnWebSites property has the specified value. "AutoSelectOnWebSites=1" finds updates that are
		/// flagged to be automatically selected by Windows Update. "AutoSelectOnWebSites=0" finds updates that are not flagged for Automatic Updates.
		/// </description>
		/// </item>
		/// <item>
		/// <description>UpdateID</description>
		/// <description><c>string(UUID)</c></description>
		/// <description><c>=</c>, <c>!=</c></description>
		/// <description>
		/// Finds updates for which the value of the UpdateIdentity.UpdateID property matches the specified value. Can be used with the
		/// <c>!=</c> operator to find all the updates that do not have an <c>UpdateIdentity.UpdateID</c> of the specified value. For
		/// example, "UpdateID='12345678-9abc-def0-1234-56789abcdef0'" finds updates for UpdateIdentity.UpdateID that equal
		/// 12345678-9abc-def0-1234-56789abcdef0. For example, "UpdateID!='12345678-9abc-def0-1234-56789abcdef0'" finds updates for
		/// UpdateIdentity.UpdateID that are not equal to 12345678-9abc-def0-1234-56789abcdef0. For example,
		/// "UpdateID='12345678-9abc-def0-1234-56789abcdef0' and RevisionNumber=100" can be used to find the update for
		/// UpdateIdentity.UpdateID that equals 12345678-9abc-def0-1234-56789abcdef0 and whose UpdateIdentity.RevisionNumber equals 100.
		/// </description>
		/// </item>
		/// <item>
		/// <description>RevisionNumber</description>
		/// <description><c>int</c></description>
		/// <description><c>=</c></description>
		/// <description>
		/// Finds updates for which the value of the UpdateIdentity.RevisionNumber property matches the specified value. For example,
		/// "RevisionNumber=2" finds updates where UpdateIdentity.RevisionNumber equals 2. This criterion must be combined with the UpdateID property.
		/// </description>
		/// </item>
		/// <item>
		/// <description>CategoryIDs</description>
		/// <description><c>string(uuid)</c></description>
		/// <description><c>contains</c></description>
		/// <description>Finds updates that belong to a specified category.</description>
		/// </item>
		/// <item>
		/// <description>IsInstalled</description>
		/// <description><c>int(bool)</c></description>
		/// <description><c>=</c></description>
		/// <description>
		/// Finds updates that are installed on the destination computer. "IsInstalled=1" finds updates that are installed on the destination
		/// computer. "IsInstalled=0" finds updates that are not installed on the destination computer.
		/// </description>
		/// </item>
		/// <item>
		/// <description>IsHidden</description>
		/// <description><c>int(bool)</c></description>
		/// <description><c>=</c></description>
		/// <description>
		/// Finds updates that are marked as hidden on the destination computer. "IsHidden=1" finds updates that are marked as hidden on a
		/// destination computer. When you use this clause, you can set the UpdateSearcher.IncludePotentiallySupersededUpdates property to
		/// <c>VARIANT_TRUE</c> so that a search returns the hidden updates. The hidden updates might be superseded by other updates in the
		/// same results. "IsHidden=0" finds updates that are not marked as hidden. If the UpdateSearcher.IncludePotentiallySupersededUpdates
		/// property is set to <c>VARIANT_FALSE</c>, it is better to include that clause in the search filter string so that the updates that
		/// are superseded by hidden updates are included in the search results. <c>VARIANT_FALSE</c> is the default value.
		/// </description>
		/// </item>
		/// <item>
		/// <description>IsPresent</description>
		/// <description><c>int(bool)</c></description>
		/// <description><c>=</c></description>
		/// <description>
		/// When set to 1, finds updates that are present on a computer. "IsPresent=1" finds updates that are present on a destination
		/// computer. If the update is valid for one or more products, the update is considered present if it is installed for one or more of
		/// the products. "IsPresent=0" finds updates that are not installed for any product on a destination computer.
		/// </description>
		/// </item>
		/// <item>
		/// <description>RebootRequired</description>
		/// <description><c>int(bool)</c></description>
		/// <description><c>=</c></description>
		/// <description>
		/// Finds updates that require a computer to be restarted to complete an installation or uninstallation. "RebootRequired=1" finds
		/// updates that require a computer to be restarted to complete an installation or uninstallation. "RebootRequired=0" finds updates
		/// that do not require a computer to be restarted to complete an installation or uninstallation.
		/// </description>
		/// </item>
		/// </list>
		/// <para>The default search criteria for a search are as follows:</para>
		/// <para>
		/// To find all the hidden updates (by using the UpdateSearcher.IncludePotentiallySupersededUpdates property set to
		/// <c>VARIANT_TRUE</c>), use the following criterion:
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatesearcher-search HRESULT Search( [in] BSTR criteria,
		// [out] ISearchResult **retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743820)]
		[return: MarshalAs(UnmanagedType.Interface)]
		ISearchResult Search([In, MarshalAs(UnmanagedType.BStr)] string criteria);

		/// <summary>
		/// <para>Gets and sets a Boolean value that indicates whether the UpdateSearcher goes online to search for updates.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatesearcher-put_online HRESULT put_Online( VARIANT_BOOL
		// value );
		[DispId(1610743821)]
		bool Online
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743821)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743821)]
			[param: In]
			set;
		}

		/// <summary>Returns the number of update events on the computer.</summary>
		/// <returns>The number of update events on the computer.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatesearcher-gettotalhistorycount HRESULT
		// GetTotalHistoryCount( [out] LONG *retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743822)]
		int GetTotalHistoryCount();

		/// <summary>
		/// <para>Gets and sets a site to search when the site to search is not a Windows Update site.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>
		/// The site that is not a Windows Update site that is specified by the value of the <c>ServiceID</c> property is searched only if
		/// the value of the ServerSelection property is ssOthers.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatesearcher-get_serviceid HRESULT get_ServiceID( BSTR
		// *retval );
		[DispId(1610743823)]
		string? ServiceID
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743823)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743823)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}
	}

	/// <summary>Searches for updates on a server.</summary>
	/// <remarks>
	/// The <c>IUpdateSearcher2</c> interface may require you to update Windows Update Agent (WUA). For more information, see Updating
	/// Windows Update Agent.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nn-wuapi-iupdatesearcher2
	[PInvokeData("wuapi.h", MSDNShortId = "NN:wuapi.IUpdateSearcher2")]
	[ComImport, Guid("4CBDCB2D-1589-4BEB-BD1C-3E582FF0ADD0"), CoClass(typeof(UpdateSearcherClass))]
	public interface IUpdateSearcher2 : IUpdateSearcher
	{
		/// <summary>
		/// <para>
		/// Gets and sets a Boolean value that indicates whether future calls to the BeginSearch and Search methods result in an automatic
		/// upgrade to Windows Update Agent (WUA). Currently, this property's valid value corresponds to the option that does not
		/// automatically upgrade WUA.
		/// </para>
		/// <para>This property is read/write.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatesearcher-get_canautomaticallyupgradeservice HRESULT
		// get_CanAutomaticallyUpgradeService( VARIANT_BOOL *retval );
		[DispId(1610743809)]
		new bool CanAutomaticallyUpgradeService
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743809)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743809)]
			[param: In]
			set;
		}

		/// <summary>
		/// <para>Identifies the current client application.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>Returns the Unknown value if the client application has not set the property.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatesearcher-get_clientapplicationid HRESULT
		// get_ClientApplicationID( BSTR *retval );
		[DispId(1610743811)]
		new string ClientApplicationID
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743811)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743811)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>
		/// Gets and sets a Boolean value that indicates whether the search results include updates that are superseded by other updates in
		/// the search results.
		/// </para>
		/// <para>This property is read/write.</para>
		/// <para>
		/// <para>Note</para>
		/// <para>This property is no longer supported in Windows 10, version 1709 (build 16299), and later OS releases.</para>
		/// </para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatesearcher-get_includepotentiallysupersededupdates HRESULT
		// get_IncludePotentiallySupersededUpdates( VARIANT_BOOL *retval );
		[DispId(1610743812)]
		new bool IncludePotentiallySupersededUpdates
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743812)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743812)]
			[param: In]
			set;
		}

		/// <summary>
		/// <para>Gets and sets a ServerSelection value that indicates the server to search for updates.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>
		/// The site that is not a Windows Update site that is specified by the value of the ServiceID property is searched only if the value
		/// of the <c>ServerSelection</c> property is ssOthers.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatesearcher-get_serverselection HRESULT
		// get_ServerSelection( ServerSelection *retval );
		[DispId(1610743815), ComAliasName("WUApiLib.ServerSelection")]
		new ServerSelection ServerSelection
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743815)]
			[return: ComAliasName("WUApiLib.ServerSelection")]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743815)]
			[param: In, ComAliasName("WUApiLib.ServerSelection")]
			set;
		}

		/// <summary>Begins execution of an asynchronous search for updates. The search uses the search options that are currently configured.</summary>
		/// <param name="criteria">A string that specifies the search criteria.</param>
		/// <param name="onCompleted">An ISearchCompletedCallback interface that is called when an asynchronous search operation is complete.</param>
		/// <param name="state">The caller-specific state that is returned by the AsyncState property of the ISearchJob interface.</param>
		/// <returns>
		/// <para>An ISearchJob interface that represents the current operation that might be pending.</para>
		/// <para>The caller passes the returned value to the EndSearch method to complete a search operation.</para>
		/// </returns>
		/// <remarks>
		/// <para>For a complete description of search criteria syntax, see Search.</para>
		/// <para>
		/// As an alternative to implementing the ISearchCompletedCallback interface, you can use a script to implement a callback routine of
		/// any identifier with DISPID 0 on an automation object. The type of the <c>onCompleted</c> parameter is <c>IUnknown*</c>.
		/// </para>
		/// <para>
		/// When you use any asynchronous WUA API in your app, you might need to implement a time-out mechanism. For more info about how to
		/// perform asynchronous WUA operations, see Guidelines for Asynchronous WUA Operations.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatesearcher-beginsearch HRESULT BeginSearch( [in] BSTR
		// criteria, [in] IUnknown *onCompleted, [in] VARIANT state, [out] ISearchJob **retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743816)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new ISearchJob BeginSearch([In, MarshalAs(UnmanagedType.BStr)] string criteria,
			[In, MarshalAs(UnmanagedType.IUnknown)] ISearchCompletedCallback onCompleted, [In, MarshalAs(UnmanagedType.Struct)] object state);

		/// <summary>Completes an asynchronous search for updates.</summary>
		/// <param name="searchJob">The ISearchJob interface that the BeginSearch method returns.</param>
		/// <returns>
		/// <para>An ISearchResult interface that contains the following:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>The result of an operation</description>
		/// </item>
		/// <item>
		/// <description>A collection of updates that match the search criteria</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// When you use any asynchronous WUA API in your app, you might need to implement a time-out mechanism. For more info about how to
		/// perform asynchronous WUA operations, see Guidelines for Asynchronous WUA Operations.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatesearcher-endsearch HRESULT EndSearch( [in] ISearchJob
		// *searchJob, [out] ISearchResult **retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743817)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new ISearchResult EndSearch([In, MarshalAs(UnmanagedType.Interface)] ISearchJob searchJob);

		/// <summary>Converts a string into a string that can be used as a literal value in a search criteria string.</summary>
		/// <param name="unescaped">A string to be escaped.</param>
		/// <returns>The resulting escaped string.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatesearcher-escapestring HRESULT EscapeString( [in] BSTR
		// unescaped, [out] BSTR *retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743818)]
		[return: MarshalAs(UnmanagedType.BStr)]
		new string? EscapeString([In, MarshalAs(UnmanagedType.BStr)] string? unescaped);

		/// <summary>Synchronously queries the computer for the history of the update events.</summary>
		/// <param name="startIndex">The index of the first event to retrieve.</param>
		/// <param name="count">The number of events to retrieve.</param>
		/// <returns>
		/// A pointer to an IUpdateHistoryEntryCollection interface that contains matching event records on the computer in descending
		/// chronological order.
		/// </returns>
		/// <remarks>
		/// This method returns <c>WU_E_INVALIDINDEX</c> if the <c>startIndex</c> parameter is less than 0 (zero) or if the <c>Count</c>
		/// parameter is less than or equal to 0 (zero).
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatesearcher-queryhistory HRESULT QueryHistory( [in] LONG
		// startIndex, [in] LONG count, [out] IUpdateHistoryEntryCollection **retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743819)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IUpdateHistoryEntryCollection QueryHistory([In] int startIndex, [In] int count);

		/// <summary>Performs a synchronous search for updates. The search uses the search options that are currently configured.</summary>
		/// <param name="criteria">A string that specifies the search criteria.</param>
		/// <returns>
		/// <para>An ISearchResult interface that contains the following:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>The result of an operation</description>
		/// </item>
		/// <item>
		/// <description>A collection of updates that match the search criteria</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The string that is used for the <c>criteria</c> parameter must match the custom search language for the <c>Search</c> method. The
		/// string consists of criteria that are evaluated to determine the updates to return.
		/// </para>
		/// <para>
		/// Each criterion specifies an update property name and value. With some restrictions, multiple criteria can be connected with the
		/// <c>AND</c> and <c>OR</c> operators. The <c>=</c> (equal) and <c>!=</c> (not-equal) operators are both supported. When you use
		/// Windows Update Agent (WUA), the <c>!=</c> (not-equal) operator can be used only with the type criterion.
		/// </para>
		/// <para>
		/// The search criteria syntax is based on the WHERE clause of an SQL query expression. Most of the supported criteria map directly
		/// to update properties. These update properties resemble the elements in a virtual XML document that contains the entire server
		/// catalog. For example, if you specify a search criteria string of "AutoSelectOnWebSites = 1", the search returns all the updates
		/// that have a AutoSelectOnWebSites property with a value of <c>VARIANT_TRUE</c>.
		/// </para>
		/// <para>
		/// A single criterion consists of " <c>Name</c> = <c>Value</c>" or " <c>Name</c> != <c>Value</c>", where " <c>Name</c>" is one of
		/// the supported criterion names, and " <c>Value</c>" is a string or an integer. The <c>AND</c> and <c>OR</c> operators can be used
		/// to connect multiple criteria. However, <c>OR</c> can be used only at the top level of the search criteria. Therefore, "(x=1 and
		/// y=1) or (z=1)" is valid, but "(x=1) and (y=1 or z=1)" is not valid.
		/// </para>
		/// <para>
		/// The supported value types are integers and strings. An integer must be specified in base 10, and negative numbers are prefixed
		/// with a minus sign ( <c>-</c>). A string must be escaped and enclosed in single quotation marks ('). All string comparisons are
		/// case-insensitive unless specified.
		/// </para>
		/// <para>
		/// The following table identifies all the public support criteria in the order of evaluation precedence. More criteria may be added
		/// to this list in the future.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Criterion</description>
		/// <description>Type</description>
		/// <description>Allowed operators</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>Type</description>
		/// <description><c>string</c></description>
		/// <description><c>=</c>, <c>!=</c></description>
		/// <description>Finds updates of a specific type, such as "'Driver'" and "'Software'".</description>
		/// </item>
		/// <item>
		/// <description>DeploymentAction</description>
		/// <description><c>string</c></description>
		/// <description><c>=</c></description>
		/// <description>
		/// Finds updates that are deployed for a specific action, such as an installation or uninstallation that the administrator of a
		/// server specifies. "DeploymentAction='Installation'" finds updates that are deployed for installation on a destination computer.
		/// "DeploymentAction='Uninstallation'" depends on the other query criteria. "DeploymentAction='Uninstallation'" finds updates that
		/// are deployed for uninstallation on a destination computer. "DeploymentAction='Uninstallation'" depends on the other query
		/// criteria. If this criterion is not explicitly specified, each group of criteria that is joined to an <c>AND</c> operator implies "DeploymentAction='Installation'".
		/// </description>
		/// </item>
		/// <item>
		/// <description>IsAssigned</description>
		/// <description><c>int(bool)</c></description>
		/// <description><c>=</c></description>
		/// <description>
		/// Finds updates that are intended for deployment by Automatic Updates. "IsAssigned=1" finds updates that are intended for
		/// deployment by Automatic Updates, which depends on the other query criteria. At most, one assigned Windows-based driver update is
		/// returned for each local device on a destination computer. "IsAssigned=0" finds updates that are not intended to be deployed by
		/// Automatic Updates.
		/// </description>
		/// </item>
		/// <item>
		/// <description>BrowseOnly</description>
		/// <description><c>int(bool)</c></description>
		/// <description><c>=</c></description>
		/// <description>
		/// "BrowseOnly=1" finds updates that are considered optional. "BrowseOnly=0" finds updates that are not considered optional.
		/// </description>
		/// </item>
		/// <item>
		/// <description>AutoSelectOnWebSites</description>
		/// <description><c>int(bool)</c></description>
		/// <description><c>=</c></description>
		/// <description>
		/// Finds updates where the AutoSelectOnWebSites property has the specified value. "AutoSelectOnWebSites=1" finds updates that are
		/// flagged to be automatically selected by Windows Update. "AutoSelectOnWebSites=0" finds updates that are not flagged for Automatic Updates.
		/// </description>
		/// </item>
		/// <item>
		/// <description>UpdateID</description>
		/// <description><c>string(UUID)</c></description>
		/// <description><c>=</c>, <c>!=</c></description>
		/// <description>
		/// Finds updates for which the value of the UpdateIdentity.UpdateID property matches the specified value. Can be used with the
		/// <c>!=</c> operator to find all the updates that do not have an <c>UpdateIdentity.UpdateID</c> of the specified value. For
		/// example, "UpdateID='12345678-9abc-def0-1234-56789abcdef0'" finds updates for UpdateIdentity.UpdateID that equal
		/// 12345678-9abc-def0-1234-56789abcdef0. For example, "UpdateID!='12345678-9abc-def0-1234-56789abcdef0'" finds updates for
		/// UpdateIdentity.UpdateID that are not equal to 12345678-9abc-def0-1234-56789abcdef0. For example,
		/// "UpdateID='12345678-9abc-def0-1234-56789abcdef0' and RevisionNumber=100" can be used to find the update for
		/// UpdateIdentity.UpdateID that equals 12345678-9abc-def0-1234-56789abcdef0 and whose UpdateIdentity.RevisionNumber equals 100.
		/// </description>
		/// </item>
		/// <item>
		/// <description>RevisionNumber</description>
		/// <description><c>int</c></description>
		/// <description><c>=</c></description>
		/// <description>
		/// Finds updates for which the value of the UpdateIdentity.RevisionNumber property matches the specified value. For example,
		/// "RevisionNumber=2" finds updates where UpdateIdentity.RevisionNumber equals 2. This criterion must be combined with the UpdateID property.
		/// </description>
		/// </item>
		/// <item>
		/// <description>CategoryIDs</description>
		/// <description><c>string(uuid)</c></description>
		/// <description><c>contains</c></description>
		/// <description>Finds updates that belong to a specified category.</description>
		/// </item>
		/// <item>
		/// <description>IsInstalled</description>
		/// <description><c>int(bool)</c></description>
		/// <description><c>=</c></description>
		/// <description>
		/// Finds updates that are installed on the destination computer. "IsInstalled=1" finds updates that are installed on the destination
		/// computer. "IsInstalled=0" finds updates that are not installed on the destination computer.
		/// </description>
		/// </item>
		/// <item>
		/// <description>IsHidden</description>
		/// <description><c>int(bool)</c></description>
		/// <description><c>=</c></description>
		/// <description>
		/// Finds updates that are marked as hidden on the destination computer. "IsHidden=1" finds updates that are marked as hidden on a
		/// destination computer. When you use this clause, you can set the UpdateSearcher.IncludePotentiallySupersededUpdates property to
		/// <c>VARIANT_TRUE</c> so that a search returns the hidden updates. The hidden updates might be superseded by other updates in the
		/// same results. "IsHidden=0" finds updates that are not marked as hidden. If the UpdateSearcher.IncludePotentiallySupersededUpdates
		/// property is set to <c>VARIANT_FALSE</c>, it is better to include that clause in the search filter string so that the updates that
		/// are superseded by hidden updates are included in the search results. <c>VARIANT_FALSE</c> is the default value.
		/// </description>
		/// </item>
		/// <item>
		/// <description>IsPresent</description>
		/// <description><c>int(bool)</c></description>
		/// <description><c>=</c></description>
		/// <description>
		/// When set to 1, finds updates that are present on a computer. "IsPresent=1" finds updates that are present on a destination
		/// computer. If the update is valid for one or more products, the update is considered present if it is installed for one or more of
		/// the products. "IsPresent=0" finds updates that are not installed for any product on a destination computer.
		/// </description>
		/// </item>
		/// <item>
		/// <description>RebootRequired</description>
		/// <description><c>int(bool)</c></description>
		/// <description><c>=</c></description>
		/// <description>
		/// Finds updates that require a computer to be restarted to complete an installation or uninstallation. "RebootRequired=1" finds
		/// updates that require a computer to be restarted to complete an installation or uninstallation. "RebootRequired=0" finds updates
		/// that do not require a computer to be restarted to complete an installation or uninstallation.
		/// </description>
		/// </item>
		/// </list>
		/// <para>The default search criteria for a search are as follows:</para>
		/// <para>
		/// To find all the hidden updates (by using the UpdateSearcher.IncludePotentiallySupersededUpdates property set to
		/// <c>VARIANT_TRUE</c>), use the following criterion:
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatesearcher-search HRESULT Search( [in] BSTR criteria,
		// [out] ISearchResult **retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743820)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new ISearchResult Search([In, MarshalAs(UnmanagedType.BStr)] string criteria);

		/// <summary>
		/// <para>Gets and sets a Boolean value that indicates whether the UpdateSearcher goes online to search for updates.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatesearcher-put_online HRESULT put_Online( VARIANT_BOOL
		// value );
		[DispId(1610743821)]
		new bool Online
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743821)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743821)]
			[param: In]
			set;
		}

		/// <summary>Returns the number of update events on the computer.</summary>
		/// <returns>The number of update events on the computer.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatesearcher-gettotalhistorycount HRESULT
		// GetTotalHistoryCount( [out] LONG *retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743822)]
		new int GetTotalHistoryCount();

		/// <summary>
		/// <para>Gets and sets a site to search when the site to search is not a Windows Update site.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>
		/// The site that is not a Windows Update site that is specified by the value of the <c>ServiceID</c> property is searched only if
		/// the value of the ServerSelection property is ssOthers.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatesearcher-get_serviceid HRESULT get_ServiceID( BSTR
		// *retval );
		[DispId(1610743823)]
		new string? ServiceID
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743823)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743823)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>
		/// Gets and sets a Boolean value that indicates whether to ignore the download priority. The download priority determines whether
		/// one update should replace another update.
		/// </para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>
		/// The IUpdateSearcher2 interface may require you to update Windows Update Agent (WUA). For more information, see Updating Windows
		/// Update Agent.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatesearcher2-get_ignoredownloadpriority HRESULT
		// get_IgnoreDownloadPriority( VARIANT_BOOL *retval );
		[DispId(1610809345)]
		bool IgnoreDownloadPriority
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809345)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809345)]
			[param: In]
			set;
		}
	}

	/// <summary>Searches for updates on a server.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nn-wuapi-iupdatesearcher3
	[PInvokeData("wuapi.h", MSDNShortId = "NN:wuapi.IUpdateSearcher3")]
	[ComImport, Guid("04C6895D-EAF2-4034-97F3-311DE9BE413A"), CoClass(typeof(UpdateSearcherClass))]
	public interface IUpdateSearcher3 : IUpdateSearcher2
	{
		/// <summary>
		/// <para>
		/// Gets and sets a Boolean value that indicates whether future calls to the BeginSearch and Search methods result in an automatic
		/// upgrade to Windows Update Agent (WUA). Currently, this property's valid value corresponds to the option that does not
		/// automatically upgrade WUA.
		/// </para>
		/// <para>This property is read/write.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatesearcher-get_canautomaticallyupgradeservice HRESULT
		// get_CanAutomaticallyUpgradeService( VARIANT_BOOL *retval );
		[DispId(1610743809)]
		new bool CanAutomaticallyUpgradeService
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743809)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743809)]
			[param: In]
			set;
		}

		/// <summary>
		/// <para>Identifies the current client application.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>Returns the Unknown value if the client application has not set the property.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatesearcher-get_clientapplicationid HRESULT
		// get_ClientApplicationID( BSTR *retval );
		[DispId(1610743811)]
		new string ClientApplicationID
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743811)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743811)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>
		/// Gets and sets a Boolean value that indicates whether the search results include updates that are superseded by other updates in
		/// the search results.
		/// </para>
		/// <para>This property is read/write.</para>
		/// <para>
		/// <para>Note</para>
		/// <para>This property is no longer supported in Windows 10, version 1709 (build 16299), and later OS releases.</para>
		/// </para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatesearcher-get_includepotentiallysupersededupdates HRESULT
		// get_IncludePotentiallySupersededUpdates( VARIANT_BOOL *retval );
		[DispId(1610743812)]
		new bool IncludePotentiallySupersededUpdates
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743812)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743812)]
			[param: In]
			set;
		}

		/// <summary>
		/// <para>Gets and sets a ServerSelection value that indicates the server to search for updates.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>
		/// The site that is not a Windows Update site that is specified by the value of the ServiceID property is searched only if the value
		/// of the <c>ServerSelection</c> property is ssOthers.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatesearcher-get_serverselection HRESULT
		// get_ServerSelection( ServerSelection *retval );
		[DispId(1610743815), ComAliasName("WUApiLib.ServerSelection")]
		new ServerSelection ServerSelection
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743815)]
			[return: ComAliasName("WUApiLib.ServerSelection")]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743815)]
			[param: In, ComAliasName("WUApiLib.ServerSelection")]
			set;
		}

		/// <summary>Begins execution of an asynchronous search for updates. The search uses the search options that are currently configured.</summary>
		/// <param name="criteria">A string that specifies the search criteria.</param>
		/// <param name="onCompleted">An ISearchCompletedCallback interface that is called when an asynchronous search operation is complete.</param>
		/// <param name="state">The caller-specific state that is returned by the AsyncState property of the ISearchJob interface.</param>
		/// <returns>
		/// <para>An ISearchJob interface that represents the current operation that might be pending.</para>
		/// <para>The caller passes the returned value to the EndSearch method to complete a search operation.</para>
		/// </returns>
		/// <remarks>
		/// <para>For a complete description of search criteria syntax, see Search.</para>
		/// <para>
		/// As an alternative to implementing the ISearchCompletedCallback interface, you can use a script to implement a callback routine of
		/// any identifier with DISPID 0 on an automation object. The type of the <c>onCompleted</c> parameter is <c>IUnknown*</c>.
		/// </para>
		/// <para>
		/// When you use any asynchronous WUA API in your app, you might need to implement a time-out mechanism. For more info about how to
		/// perform asynchronous WUA operations, see Guidelines for Asynchronous WUA Operations.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatesearcher-beginsearch HRESULT BeginSearch( [in] BSTR
		// criteria, [in] IUnknown *onCompleted, [in] VARIANT state, [out] ISearchJob **retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743816)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new ISearchJob BeginSearch([In, MarshalAs(UnmanagedType.BStr)] string criteria,
			[In, MarshalAs(UnmanagedType.IUnknown)] ISearchCompletedCallback onCompleted, [In, MarshalAs(UnmanagedType.Struct)] object state);

		/// <summary>Completes an asynchronous search for updates.</summary>
		/// <param name="searchJob">The ISearchJob interface that the BeginSearch method returns.</param>
		/// <returns>
		/// <para>An ISearchResult interface that contains the following:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>The result of an operation</description>
		/// </item>
		/// <item>
		/// <description>A collection of updates that match the search criteria</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// When you use any asynchronous WUA API in your app, you might need to implement a time-out mechanism. For more info about how to
		/// perform asynchronous WUA operations, see Guidelines for Asynchronous WUA Operations.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatesearcher-endsearch HRESULT EndSearch( [in] ISearchJob
		// *searchJob, [out] ISearchResult **retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743817)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new ISearchResult EndSearch([In, MarshalAs(UnmanagedType.Interface)] ISearchJob searchJob);

		/// <summary>Converts a string into a string that can be used as a literal value in a search criteria string.</summary>
		/// <param name="unescaped">A string to be escaped.</param>
		/// <returns>The resulting escaped string.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatesearcher-escapestring HRESULT EscapeString( [in] BSTR
		// unescaped, [out] BSTR *retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743818)]
		[return: MarshalAs(UnmanagedType.BStr)]
		new string? EscapeString([In, MarshalAs(UnmanagedType.BStr)] string? unescaped);

		/// <summary>Synchronously queries the computer for the history of the update events.</summary>
		/// <param name="startIndex">The index of the first event to retrieve.</param>
		/// <param name="count">The number of events to retrieve.</param>
		/// <returns>
		/// A pointer to an IUpdateHistoryEntryCollection interface that contains matching event records on the computer in descending
		/// chronological order.
		/// </returns>
		/// <remarks>
		/// This method returns <c>WU_E_INVALIDINDEX</c> if the <c>startIndex</c> parameter is less than 0 (zero) or if the <c>Count</c>
		/// parameter is less than or equal to 0 (zero).
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatesearcher-queryhistory HRESULT QueryHistory( [in] LONG
		// startIndex, [in] LONG count, [out] IUpdateHistoryEntryCollection **retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743819)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IUpdateHistoryEntryCollection QueryHistory([In] int startIndex, [In] int count);

		/// <summary>Performs a synchronous search for updates. The search uses the search options that are currently configured.</summary>
		/// <param name="criteria">A string that specifies the search criteria.</param>
		/// <returns>
		/// <para>An ISearchResult interface that contains the following:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>The result of an operation</description>
		/// </item>
		/// <item>
		/// <description>A collection of updates that match the search criteria</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The string that is used for the <c>criteria</c> parameter must match the custom search language for the <c>Search</c> method. The
		/// string consists of criteria that are evaluated to determine the updates to return.
		/// </para>
		/// <para>
		/// Each criterion specifies an update property name and value. With some restrictions, multiple criteria can be connected with the
		/// <c>AND</c> and <c>OR</c> operators. The <c>=</c> (equal) and <c>!=</c> (not-equal) operators are both supported. When you use
		/// Windows Update Agent (WUA), the <c>!=</c> (not-equal) operator can be used only with the type criterion.
		/// </para>
		/// <para>
		/// The search criteria syntax is based on the WHERE clause of an SQL query expression. Most of the supported criteria map directly
		/// to update properties. These update properties resemble the elements in a virtual XML document that contains the entire server
		/// catalog. For example, if you specify a search criteria string of "AutoSelectOnWebSites = 1", the search returns all the updates
		/// that have a AutoSelectOnWebSites property with a value of <c>VARIANT_TRUE</c>.
		/// </para>
		/// <para>
		/// A single criterion consists of " <c>Name</c> = <c>Value</c>" or " <c>Name</c> != <c>Value</c>", where " <c>Name</c>" is one of
		/// the supported criterion names, and " <c>Value</c>" is a string or an integer. The <c>AND</c> and <c>OR</c> operators can be used
		/// to connect multiple criteria. However, <c>OR</c> can be used only at the top level of the search criteria. Therefore, "(x=1 and
		/// y=1) or (z=1)" is valid, but "(x=1) and (y=1 or z=1)" is not valid.
		/// </para>
		/// <para>
		/// The supported value types are integers and strings. An integer must be specified in base 10, and negative numbers are prefixed
		/// with a minus sign ( <c>-</c>). A string must be escaped and enclosed in single quotation marks ('). All string comparisons are
		/// case-insensitive unless specified.
		/// </para>
		/// <para>
		/// The following table identifies all the public support criteria in the order of evaluation precedence. More criteria may be added
		/// to this list in the future.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Criterion</description>
		/// <description>Type</description>
		/// <description>Allowed operators</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>Type</description>
		/// <description><c>string</c></description>
		/// <description><c>=</c>, <c>!=</c></description>
		/// <description>Finds updates of a specific type, such as "'Driver'" and "'Software'".</description>
		/// </item>
		/// <item>
		/// <description>DeploymentAction</description>
		/// <description><c>string</c></description>
		/// <description><c>=</c></description>
		/// <description>
		/// Finds updates that are deployed for a specific action, such as an installation or uninstallation that the administrator of a
		/// server specifies. "DeploymentAction='Installation'" finds updates that are deployed for installation on a destination computer.
		/// "DeploymentAction='Uninstallation'" depends on the other query criteria. "DeploymentAction='Uninstallation'" finds updates that
		/// are deployed for uninstallation on a destination computer. "DeploymentAction='Uninstallation'" depends on the other query
		/// criteria. If this criterion is not explicitly specified, each group of criteria that is joined to an <c>AND</c> operator implies "DeploymentAction='Installation'".
		/// </description>
		/// </item>
		/// <item>
		/// <description>IsAssigned</description>
		/// <description><c>int(bool)</c></description>
		/// <description><c>=</c></description>
		/// <description>
		/// Finds updates that are intended for deployment by Automatic Updates. "IsAssigned=1" finds updates that are intended for
		/// deployment by Automatic Updates, which depends on the other query criteria. At most, one assigned Windows-based driver update is
		/// returned for each local device on a destination computer. "IsAssigned=0" finds updates that are not intended to be deployed by
		/// Automatic Updates.
		/// </description>
		/// </item>
		/// <item>
		/// <description>BrowseOnly</description>
		/// <description><c>int(bool)</c></description>
		/// <description><c>=</c></description>
		/// <description>
		/// "BrowseOnly=1" finds updates that are considered optional. "BrowseOnly=0" finds updates that are not considered optional.
		/// </description>
		/// </item>
		/// <item>
		/// <description>AutoSelectOnWebSites</description>
		/// <description><c>int(bool)</c></description>
		/// <description><c>=</c></description>
		/// <description>
		/// Finds updates where the AutoSelectOnWebSites property has the specified value. "AutoSelectOnWebSites=1" finds updates that are
		/// flagged to be automatically selected by Windows Update. "AutoSelectOnWebSites=0" finds updates that are not flagged for Automatic Updates.
		/// </description>
		/// </item>
		/// <item>
		/// <description>UpdateID</description>
		/// <description><c>string(UUID)</c></description>
		/// <description><c>=</c>, <c>!=</c></description>
		/// <description>
		/// Finds updates for which the value of the UpdateIdentity.UpdateID property matches the specified value. Can be used with the
		/// <c>!=</c> operator to find all the updates that do not have an <c>UpdateIdentity.UpdateID</c> of the specified value. For
		/// example, "UpdateID='12345678-9abc-def0-1234-56789abcdef0'" finds updates for UpdateIdentity.UpdateID that equal
		/// 12345678-9abc-def0-1234-56789abcdef0. For example, "UpdateID!='12345678-9abc-def0-1234-56789abcdef0'" finds updates for
		/// UpdateIdentity.UpdateID that are not equal to 12345678-9abc-def0-1234-56789abcdef0. For example,
		/// "UpdateID='12345678-9abc-def0-1234-56789abcdef0' and RevisionNumber=100" can be used to find the update for
		/// UpdateIdentity.UpdateID that equals 12345678-9abc-def0-1234-56789abcdef0 and whose UpdateIdentity.RevisionNumber equals 100.
		/// </description>
		/// </item>
		/// <item>
		/// <description>RevisionNumber</description>
		/// <description><c>int</c></description>
		/// <description><c>=</c></description>
		/// <description>
		/// Finds updates for which the value of the UpdateIdentity.RevisionNumber property matches the specified value. For example,
		/// "RevisionNumber=2" finds updates where UpdateIdentity.RevisionNumber equals 2. This criterion must be combined with the UpdateID property.
		/// </description>
		/// </item>
		/// <item>
		/// <description>CategoryIDs</description>
		/// <description><c>string(uuid)</c></description>
		/// <description><c>contains</c></description>
		/// <description>Finds updates that belong to a specified category.</description>
		/// </item>
		/// <item>
		/// <description>IsInstalled</description>
		/// <description><c>int(bool)</c></description>
		/// <description><c>=</c></description>
		/// <description>
		/// Finds updates that are installed on the destination computer. "IsInstalled=1" finds updates that are installed on the destination
		/// computer. "IsInstalled=0" finds updates that are not installed on the destination computer.
		/// </description>
		/// </item>
		/// <item>
		/// <description>IsHidden</description>
		/// <description><c>int(bool)</c></description>
		/// <description><c>=</c></description>
		/// <description>
		/// Finds updates that are marked as hidden on the destination computer. "IsHidden=1" finds updates that are marked as hidden on a
		/// destination computer. When you use this clause, you can set the UpdateSearcher.IncludePotentiallySupersededUpdates property to
		/// <c>VARIANT_TRUE</c> so that a search returns the hidden updates. The hidden updates might be superseded by other updates in the
		/// same results. "IsHidden=0" finds updates that are not marked as hidden. If the UpdateSearcher.IncludePotentiallySupersededUpdates
		/// property is set to <c>VARIANT_FALSE</c>, it is better to include that clause in the search filter string so that the updates that
		/// are superseded by hidden updates are included in the search results. <c>VARIANT_FALSE</c> is the default value.
		/// </description>
		/// </item>
		/// <item>
		/// <description>IsPresent</description>
		/// <description><c>int(bool)</c></description>
		/// <description><c>=</c></description>
		/// <description>
		/// When set to 1, finds updates that are present on a computer. "IsPresent=1" finds updates that are present on a destination
		/// computer. If the update is valid for one or more products, the update is considered present if it is installed for one or more of
		/// the products. "IsPresent=0" finds updates that are not installed for any product on a destination computer.
		/// </description>
		/// </item>
		/// <item>
		/// <description>RebootRequired</description>
		/// <description><c>int(bool)</c></description>
		/// <description><c>=</c></description>
		/// <description>
		/// Finds updates that require a computer to be restarted to complete an installation or uninstallation. "RebootRequired=1" finds
		/// updates that require a computer to be restarted to complete an installation or uninstallation. "RebootRequired=0" finds updates
		/// that do not require a computer to be restarted to complete an installation or uninstallation.
		/// </description>
		/// </item>
		/// </list>
		/// <para>The default search criteria for a search are as follows:</para>
		/// <para>
		/// To find all the hidden updates (by using the UpdateSearcher.IncludePotentiallySupersededUpdates property set to
		/// <c>VARIANT_TRUE</c>), use the following criterion:
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatesearcher-search HRESULT Search( [in] BSTR criteria,
		// [out] ISearchResult **retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743820)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new ISearchResult Search([In, MarshalAs(UnmanagedType.BStr)] string criteria);

		/// <summary>
		/// <para>Gets and sets a Boolean value that indicates whether the UpdateSearcher goes online to search for updates.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatesearcher-put_online HRESULT put_Online( VARIANT_BOOL
		// value );
		[DispId(1610743821)]
		new bool Online
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743821)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743821)]
			[param: In]
			set;
		}

		/// <summary>Returns the number of update events on the computer.</summary>
		/// <returns>The number of update events on the computer.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatesearcher-gettotalhistorycount HRESULT
		// GetTotalHistoryCount( [out] LONG *retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743822)]
		new int GetTotalHistoryCount();

		/// <summary>
		/// <para>Gets and sets a site to search when the site to search is not a Windows Update site.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>
		/// The site that is not a Windows Update site that is specified by the value of the <c>ServiceID</c> property is searched only if
		/// the value of the ServerSelection property is ssOthers.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatesearcher-get_serviceid HRESULT get_ServiceID( BSTR
		// *retval );
		[DispId(1610743823)]
		new string? ServiceID
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743823)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743823)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>
		/// Gets and sets a Boolean value that indicates whether to ignore the download priority. The download priority determines whether
		/// one update should replace another update.
		/// </para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>
		/// The IUpdateSearcher2 interface may require you to update Windows Update Agent (WUA). For more information, see Updating Windows
		/// Update Agent.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatesearcher2-get_ignoredownloadpriority HRESULT
		// get_IgnoreDownloadPriority( VARIANT_BOOL *retval );
		[DispId(1610809345)]
		new bool IgnoreDownloadPriority
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809345)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809345)]
			[param: In]
			set;
		}

		/// <summary>Gets or sets the search scope.</summary>
		/// <value>The search scope.</value>
		[DispId(1610874881), ComAliasName("WUApiLib.SearchScope")]
		SearchScope SearchScope
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610874881)]
			[return: ComAliasName("WUApiLib.SearchScope")]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610874881)]
			[param: In, ComAliasName("WUApiLib.SearchScope")]
			set;
		}
	}

	/// <summary>Contains information about a service that is registered with Windows Update Agent (WUA) or with Automatic Updates.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nn-wuapi-iupdateservice
	[PInvokeData("wuapi.h", MSDNShortId = "NN:wuapi.IUpdateService")]
	[ComImport, DefaultMember("Name"), Guid("76B3B17E-AED6-4DA5-85F0-83587F81ABE3")]
	public interface IUpdateService
	{
		/// <summary>
		/// <para>Gets the name of the service.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// The localized properties of an update are returned in the language that corresponds to the user default user interface (UI)
		/// language of the caller. If a property of an update is unavailable in such language, it will be returned in the system default UI
		/// language on the specified computer. If the property is unavailable in either languages mentioned, then it will be returned in the
		/// language recommended, if any, by the provider of the Update. Otherwise the Update Service will choose a language as it sees fit
		/// for the property.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateservice-get_name HRESULT get_Name( BSTR *retval );
		[DispId(0)]
		string? Name
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets an SHA-1 hash of the certificate that is used to sign the contents of the service.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateservice-get_contentvalidationcert HRESULT
		// get_ContentValidationCert( VARIANT *retval );
		[DispId(1610743809)]
		object? ContentValidationCert
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743809)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// <para>Gets the date on which the authorization cabinet file expires.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateservice-get_expirationdate HRESULT get_ExpirationDate(
		// DATE *retval );
		[DispId(1610743810)]
		DateTime? ExpirationDate
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743810)]
			get;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether a service is a managed service.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateservice-get_ismanaged HRESULT get_IsManaged(
		// VARIANT_BOOL *retval );
		[DispId(1610743811)]
		bool IsManaged
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743811)]
			get;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether a service is registered with Automatic Updates.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateservice-get_isregisteredwithau HRESULT
		// get_IsRegisteredWithAU( VARIANT_BOOL *retval );
		[DispId(1610743812)]
		bool IsRegisteredWithAU
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743812)]
			get;
		}

		/// <summary>
		/// <para>Gets the date on which the authorization cabinet file was issued.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateservice-get_issuedate HRESULT get_IssueDate( DATE
		// *retval );
		[DispId(1610743813)]
		DateTime IssueDate
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743813)]
			get;
		}

		/// <summary>
		/// <para>Gets a Boolean value indicates whether the current service offers updates from Windows Updates.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateservice-get_offerswindowsupdates HRESULT
		// get_OffersWindowsUpdates( VARIANT_BOOL *retval );
		[DispId(1610743814)]
		bool OffersWindowsUpdates
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743814)]
			get;
		}

		/// <summary>
		/// <para>The <c>RedirectUrls</c> property contains the URLs for the redirector cabinet file.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateservice-get_redirecturls HRESULT get_RedirectUrls(
		// IStringCollection **retval );
		[DispId(1610743815)]
		IStringCollection RedirectUrls
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743815)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>The <c>ServiceID</c> property retrieves or sets the identifier for a service.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateservice-get_serviceid HRESULT get_ServiceID( BSTR
		// *retval );
		[DispId(1610743816)]
		string ServiceID
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743816)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether a service is based on a scan package.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateservice-get_isscanpackageservice HRESULT
		// get_IsScanPackageService( VARIANT_BOOL *retval );
		[DispId(1610743818)]
		bool IsScanPackageService
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743818)]
			get;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether the service can register with Automatic Updates.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateservice-get_canregisterwithau HRESULT
		// get_CanRegisterWithAU( VARIANT_BOOL *retval );
		[DispId(1610743819)]
		bool CanRegisterWithAU
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743819)]
			get;
		}

		/// <summary>
		/// <para>The <c>ServiceUrl</c> property retrieves the URL for the service.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateservice-get_serviceurl HRESULT get_ServiceUrl( BSTR
		// *retval );
		[DispId(1610743820)]
		string? ServiceUrl
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743820)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>The <c>SetupPrefix</c> property identifies the prefix for the setup files.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateservice-get_setupprefix HRESULT get_SetupPrefix( BSTR
		// *retval );
		[DispId(1610743821)]
		string? SetupPrefix
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743821)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}
	}

	/// <summary>Contains information about a service that is registered with Windows Update Agent (WUA) or with Automatic Updates.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nn-wuapi-iupdateservice2
	[PInvokeData("wuapi.h", MSDNShortId = "NN:wuapi.IUpdateService2")]
	[ComImport, DefaultMember("Name"), Guid("1518B460-6518-4172-940F-C75883B24CEB")]
	public interface IUpdateService2 : IUpdateService
	{
		/// <summary>
		/// <para>Gets the name of the service.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// The localized properties of an update are returned in the language that corresponds to the user default user interface (UI)
		/// language of the caller. If a property of an update is unavailable in such language, it will be returned in the system default UI
		/// language on the specified computer. If the property is unavailable in either languages mentioned, then it will be returned in the
		/// language recommended, if any, by the provider of the Update. Otherwise the Update Service will choose a language as it sees fit
		/// for the property.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateservice-get_name HRESULT get_Name( BSTR *retval );
		[DispId(0)]
		new string? Name
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets an SHA-1 hash of the certificate that is used to sign the contents of the service.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateservice-get_contentvalidationcert HRESULT
		// get_ContentValidationCert( VARIANT *retval );
		[DispId(1610743809)]
		new object? ContentValidationCert
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743809)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// <para>Gets the date on which the authorization cabinet file expires.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateservice-get_expirationdate HRESULT get_ExpirationDate(
		// DATE *retval );
		[DispId(1610743810)]
		new DateTime ExpirationDate
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743810)]
			get;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether a service is a managed service.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateservice-get_ismanaged HRESULT get_IsManaged(
		// VARIANT_BOOL *retval );
		[DispId(1610743811)]
		new bool IsManaged
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743811)]
			get;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether a service is registered with Automatic Updates.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateservice-get_isregisteredwithau HRESULT
		// get_IsRegisteredWithAU( VARIANT_BOOL *retval );
		[DispId(1610743812)]
		new bool IsRegisteredWithAU
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743812)]
			get;
		}

		/// <summary>
		/// <para>Gets the date on which the authorization cabinet file was issued.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateservice-get_issuedate HRESULT get_IssueDate( DATE
		// *retval );
		[DispId(1610743813)]
		new DateTime IssueDate
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743813)]
			get;
		}

		/// <summary>
		/// <para>Gets a Boolean value indicates whether the current service offers updates from Windows Updates.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateservice-get_offerswindowsupdates HRESULT
		// get_OffersWindowsUpdates( VARIANT_BOOL *retval );
		[DispId(1610743814)]
		new bool OffersWindowsUpdates
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743814)]
			get;
		}

		/// <summary>
		/// <para>The <c>RedirectUrls</c> property contains the URLs for the redirector cabinet file.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateservice-get_redirecturls HRESULT get_RedirectUrls(
		// IStringCollection **retval );
		[DispId(1610743815)]
		new IStringCollection RedirectUrls
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743815)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>The <c>ServiceID</c> property retrieves or sets the identifier for a service.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateservice-get_serviceid HRESULT get_ServiceID( BSTR
		// *retval );
		[DispId(1610743816)]
		new string? ServiceID
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743816)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether a service is based on a scan package.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateservice-get_isscanpackageservice HRESULT
		// get_IsScanPackageService( VARIANT_BOOL *retval );
		[DispId(1610743818)]
		new bool IsScanPackageService
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743818)]
			get;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether the service can register with Automatic Updates.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateservice-get_canregisterwithau HRESULT
		// get_CanRegisterWithAU( VARIANT_BOOL *retval );
		[DispId(1610743819)]
		new bool CanRegisterWithAU
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743819)]
			get;
		}

		/// <summary>
		/// <para>The <c>ServiceUrl</c> property retrieves the URL for the service.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateservice-get_serviceurl HRESULT get_ServiceUrl( BSTR
		// *retval );
		[DispId(1610743820)]
		new string? ServiceUrl
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743820)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>The <c>SetupPrefix</c> property identifies the prefix for the setup files.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateservice-get_setupprefix HRESULT get_SetupPrefix( BSTR
		// *retval );
		[DispId(1610743821)]
		new string? SetupPrefix
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743821)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>
		/// Gets a Boolean value that indicates whether the service is registered with Automatic Updates and whether the service is currently
		/// used by Automatic Updates as the default service.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateservice2-get_isdefaultauservice HRESULT
		// get_IsDefaultAUService( VARIANT_BOOL *retval );
		[DispId(1610809345)]
		bool IsDefaultAUService
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809345)]
			get;
		}
	}

	/// <summary>Represents a list of IUpdateService interfaces.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nn-wuapi-iupdateservicecollection
	[PInvokeData("wuapi.h", MSDNShortId = "NN:wuapi.IUpdateServiceCollection")]
	[ComImport, Guid("9B0353AA-0E52-44FF-B8B0-1F7FA0437F88")]
	public interface IUpdateServiceCollection : IEnumerable
	{
		/// <summary>
		/// <para>Gets and sets an IUpdateService interface in a collection.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <param name="index"/>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateservicecollection-get_item HRESULT get_Item( LONG index,
		// IUpdateService **retval );
		[DispId(0)]
		IUpdateService this[[In] int index]
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>Gets an IEnumVARIANT interface that can be used to enumerate the collection.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateservicecollection-get__newenum HRESULT get__NewEnum(
		// IUnknown **retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(-4)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "System.Runtime.InteropServices.CustomMarshalers.EnumeratorToEnumVariantMarshaler, CustomMarshalers, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
		new IEnumerator GetEnumerator();

		/// <summary>
		/// <para>Gets the number of elements in the collection.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateservicecollection-get_count HRESULT get_Count( LONG
		// *retval );
		[DispId(1610743809)]
		int Count
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743809)]
			get;
		}
	}
}