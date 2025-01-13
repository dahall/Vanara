namespace Vanara.PInvoke;

public static partial class DXGI
{
	/// <summary>Flags used with ReportLiveObjects to specify the amount of info to report about an object's lifetime.</summary>
	/// <remarks>
	/// <para>Use this enumeration with IDXGIDebug::ReportLiveObjects.</para>
	/// <para><c>Note</c>  This API requires the Windows Software Development Kit (SDK) for Windows 8.</para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxgidebug/ne-dxgidebug-dxgi_debug_rlo_flags typedef enum DXGI_DEBUG_RLO_FLAGS {
	// DXGI_DEBUG_RLO_SUMMARY = 0x1, DXGI_DEBUG_RLO_DETAIL = 0x2, DXGI_DEBUG_RLO_IGNORE_INTERNAL = 0x4, DXGI_DEBUG_RLO_ALL = 0x7 } ;
	[PInvokeData("dxgidebug.h", MSDNShortId = "NE:dxgidebug.DXGI_DEBUG_RLO_FLAGS"), Flags]
	public enum DXGI_DEBUG_RLO_FLAGS
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0x1</para>
		/// <para>A flag that specifies to obtain a summary about an object's lifetime.</para>
		/// </summary>
		DXGI_DEBUG_RLO_SUMMARY = 0x1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x2</para>
		/// <para>A flag that specifies to obtain detailed info about an object's lifetime.</para>
		/// </summary>
		DXGI_DEBUG_RLO_DETAIL = 0x2,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x4</para>
		/// <para>This flag indicates to ignore objects which have no external refcounts keeping them alive.</para>
		/// <para>D3D objects are printed using an external refcount and an internal refcount.</para>
		/// <para>Typically, all objects are printed.</para>
		/// <para>
		/// This flag means ignore the objects whose external refcount is 0, because the application is not responsible for keeping them alive.
		/// </para>
		/// </summary>
		DXGI_DEBUG_RLO_IGNORE_INTERNAL = 0x4,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x7</para>
		/// <para>A flag that specifies to obtain both a summary and detailed info about an object's lifetime.</para>
		/// </summary>
		DXGI_DEBUG_RLO_ALL = 0x7,
	}

	/// <summary>Values that specify categories of debug messages.</summary>
	/// <remarks>
	/// <para>
	/// Use this enumeration when you call IDXGIInfoQueue::GetMessage to retrieve a message and when you call IDXGIInfoQueue::AddMessage to
	/// add a message. When you create an info queue filter, you can use these values to allow or deny any categories of messages to pass
	/// through the storage and retrieval filters.
	/// </para>
	/// <para><c>Note</c>  This API requires the Windows Software Development Kit (SDK) for Windows 8.</para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxgidebug/ne-dxgidebug-dxgi_info_queue_message_category typedef enum
	// DXGI_INFO_QUEUE_MESSAGE_CATEGORY { DXGI_INFO_QUEUE_MESSAGE_CATEGORY_UNKNOWN = 0, DXGI_INFO_QUEUE_MESSAGE_CATEGORY_MISCELLANEOUS,
	// DXGI_INFO_QUEUE_MESSAGE_CATEGORY_INITIALIZATION, DXGI_INFO_QUEUE_MESSAGE_CATEGORY_CLEANUP,
	// DXGI_INFO_QUEUE_MESSAGE_CATEGORY_COMPILATION, DXGI_INFO_QUEUE_MESSAGE_CATEGORY_STATE_CREATION,
	// DXGI_INFO_QUEUE_MESSAGE_CATEGORY_STATE_SETTING, DXGI_INFO_QUEUE_MESSAGE_CATEGORY_STATE_GETTING,
	// DXGI_INFO_QUEUE_MESSAGE_CATEGORY_RESOURCE_MANIPULATION, DXGI_INFO_QUEUE_MESSAGE_CATEGORY_EXECUTION,
	// DXGI_INFO_QUEUE_MESSAGE_CATEGORY_SHADER } ;
	[PInvokeData("dxgidebug.h", MSDNShortId = "NE:dxgidebug.DXGI_INFO_QUEUE_MESSAGE_CATEGORY")]
	public enum DXGI_INFO_QUEUE_MESSAGE_CATEGORY
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Unknown category.</para>
		/// </summary>
		DXGI_INFO_QUEUE_MESSAGE_CATEGORY_UNKNOWN,

		/// <summary>Miscellaneous category.</summary>
		DXGI_INFO_QUEUE_MESSAGE_CATEGORY_MISCELLANEOUS,

		/// <summary>Initialization category.</summary>
		DXGI_INFO_QUEUE_MESSAGE_CATEGORY_INITIALIZATION,

		/// <summary>Cleanup category.</summary>
		DXGI_INFO_QUEUE_MESSAGE_CATEGORY_CLEANUP,

		/// <summary>Compilation category.</summary>
		DXGI_INFO_QUEUE_MESSAGE_CATEGORY_COMPILATION,

		/// <summary>State creation category.</summary>
		DXGI_INFO_QUEUE_MESSAGE_CATEGORY_STATE_CREATION,

		/// <summary>State setting category.</summary>
		DXGI_INFO_QUEUE_MESSAGE_CATEGORY_STATE_SETTING,

		/// <summary>State getting category.</summary>
		DXGI_INFO_QUEUE_MESSAGE_CATEGORY_STATE_GETTING,

		/// <summary>Resource manipulation category.</summary>
		DXGI_INFO_QUEUE_MESSAGE_CATEGORY_RESOURCE_MANIPULATION,

		/// <summary>Execution category.</summary>
		DXGI_INFO_QUEUE_MESSAGE_CATEGORY_EXECUTION,

		/// <summary>Shader category.</summary>
		DXGI_INFO_QUEUE_MESSAGE_CATEGORY_SHADER,
	}

	/// <summary>Values that specify debug message severity levels for an information queue.</summary>
	/// <remarks>
	/// <para>
	/// Use this enumeration when you call IDXGIInfoQueue::GetMessage to retrieve a message and when you call IDXGIInfoQueue::AddMessage to
	/// add a message. Also, use this enumeration with IDXGIInfoQueue::AddApplicationMessage.
	/// </para>
	/// <para><c>Note</c>  This API requires the Windows Software Development Kit (SDK) for Windows 8.</para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxgidebug/ne-dxgidebug-dxgi_info_queue_message_severity typedef enum
	// DXGI_INFO_QUEUE_MESSAGE_SEVERITY { DXGI_INFO_QUEUE_MESSAGE_SEVERITY_CORRUPTION = 0, DXGI_INFO_QUEUE_MESSAGE_SEVERITY_ERROR,
	// DXGI_INFO_QUEUE_MESSAGE_SEVERITY_WARNING, DXGI_INFO_QUEUE_MESSAGE_SEVERITY_INFO, DXGI_INFO_QUEUE_MESSAGE_SEVERITY_MESSAGE } ;
	[PInvokeData("dxgidebug.h", MSDNShortId = "NE:dxgidebug.DXGI_INFO_QUEUE_MESSAGE_SEVERITY")]
	public enum DXGI_INFO_QUEUE_MESSAGE_SEVERITY
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Defines some type of corruption that has occurred.</para>
		/// </summary>
		DXGI_INFO_QUEUE_MESSAGE_SEVERITY_CORRUPTION,

		/// <summary>Defines an error message.</summary>
		DXGI_INFO_QUEUE_MESSAGE_SEVERITY_ERROR,

		/// <summary>Defines a warning message.</summary>
		DXGI_INFO_QUEUE_MESSAGE_SEVERITY_WARNING,

		/// <summary>Defines an information message.</summary>
		DXGI_INFO_QUEUE_MESSAGE_SEVERITY_INFO,

		/// <summary>Defines a message other than corruption, error, warning, or information.</summary>
		DXGI_INFO_QUEUE_MESSAGE_SEVERITY_MESSAGE,
	}

	/// <summary>This interface controls debug settings, and can only be used if the debug layer is turned on.</summary>
	/// <remarks>
	/// <para>This interface is obtained by calling the <c>DXGIGetDebugInterface</c> function.</para>
	/// <para>For more info about the debug layer, see <c>Debug Layer</c>.</para>
	/// <para><b>Windows Phone 8:</b> This API is supported.</para>
	/// <note>This API requires the Windows Software Development Kit (SDK) for Windows 8.</note>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxgidebug/nn-dxgidebug-idxgidebug
	[PInvokeData("dxgidebug.h", MSDNShortId = "NN:dxgidebug.IDXGIDebug"), ComImport, Guid("119e7452-de9e-40fe-8806-88f90c12b441"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDXGIDebug
	{
		/// <summary>
		/// <para>Reports info about the lifetime of an object or objects.</para>
		/// <para>See the <c>Memory management sample</c>.</para>
		/// </summary>
		/// <param name="apiid">
		/// The globally unique identifier (GUID) of the object or objects to get info about. Use one of the <c>DXGI_DEBUG_ID</c> GUIDs.
		/// </param>
		/// <param name="flags">A <c>DXGI_DEBUG_RLO_FLAGS</c>-typed value that specifies the amount of info to report.</param>
		/// <returns>Returns S_OK if successful; an error code otherwise. For a list of error codes, see <c>DXGI_ERROR</c>.</returns>
		/// <remarks>
		/// <para><b>Note</b>  This API requires the Windows Software Development Kit (SDK) for Windows 8.</para>
		/// <para></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgidebug/nf-dxgidebug-idxgidebug-reportliveobjects HRESULT
		// ReportLiveObjects( GUID apiid, DXGI_DEBUG_RLO_FLAGS flags );
		[PreserveSig]
		HRESULT ReportLiveObjects(Guid apiid, DXGI_DEBUG_RLO_FLAGS flags);
	}

	/// <summary>
	/// Controls debug settings for Microsoft DirectX Graphics Infrastructure (DXGI). You can use the <b>IDXGIDebug1</b> interface in
	/// Windows Store apps.
	/// </summary>
	/// <remarks>
	/// <para>Call the <c>DXGIGetDebugInterface1</c> function to obtain the <b>IDXGIDebug1</b> interface.</para>
	/// <para>The <b>IDXGIDebug1</b> interface can be used only if the debug layer is turned on. For more info, see <c>Debug Layer</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxgidebug/nn-dxgidebug-idxgidebug1
	[PInvokeData("dxgidebug.h", MSDNShortId = "NN:dxgidebug.IDXGIDebug1"), ComImport, Guid("c5a05f0c-16f2-4adf-9f4d-a8c4d58ac550"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDXGIDebug1 : IDXGIDebug
	{
		/// <summary>
		/// <para>Reports info about the lifetime of an object or objects.</para>
		/// <para>See the <c>Memory management sample</c>.</para>
		/// </summary>
		/// <param name="apiid">
		/// The globally unique identifier (GUID) of the object or objects to get info about. Use one of the <c>DXGI_DEBUG_ID</c> GUIDs.
		/// </param>
		/// <param name="flags">A <c>DXGI_DEBUG_RLO_FLAGS</c>-typed value that specifies the amount of info to report.</param>
		/// <returns>Returns S_OK if successful; an error code otherwise. For a list of error codes, see <c>DXGI_ERROR</c>.</returns>
		/// <remarks>
		/// <para><b>Note</b>  This API requires the Windows Software Development Kit (SDK) for Windows 8.</para>
		/// <para></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgidebug/nf-dxgidebug-idxgidebug-reportliveobjects HRESULT
		// ReportLiveObjects( GUID apiid, DXGI_DEBUG_RLO_FLAGS flags );
		[PreserveSig]
		new HRESULT ReportLiveObjects(Guid apiid, DXGI_DEBUG_RLO_FLAGS flags);

		/// <summary>Starts tracking leaks for the current thread.</summary>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgidebug/nf-dxgidebug-idxgidebug1-enableleaktrackingforthread void EnableLeakTrackingForThread();
		[PreserveSig]
		void EnableLeakTrackingForThread();

		/// <summary>Stops tracking leaks for the current thread.</summary>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgidebug/nf-dxgidebug-idxgidebug1-disableleaktrackingforthread void DisableLeakTrackingForThread();
		[PreserveSig]
		void DisableLeakTrackingForThread();

		/// <summary>Gets a value indicating whether leak tracking is turned on for the current thread.</summary>
		/// <returns><b>TRUE</b> if leak tracking is turned on for the current thread; otherwise, <b>FALSE</b>.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgidebug/nf-dxgidebug-idxgidebug1-isleaktrackingenabledforthread BOOL IsLeakTrackingEnabledForThread();
		[PreserveSig]
		bool IsLeakTrackingEnabledForThread();
	}

	/// <summary>This interface controls the debug information queue, and can only be used if the debug layer is turned on.</summary>
	/// <remarks>
	/// <para>This interface is obtained by calling the <c>DXGIGetDebugInterface</c> function.</para>
	/// <para>For more info about the debug layer, see <c>Debug Layer</c>.</para>
	/// <para><b>Note</b>  This API requires the Windows Software Development Kit (SDK) for Windows 8.</para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxgidebug/nn-dxgidebug-idxgiinfoqueue
	[PInvokeData("dxgidebug.h", MSDNShortId = "NN:dxgidebug.IDXGIInfoQueue"), ComImport, Guid("d67441c7-672a-476f-9e82-cd55b44949ce"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDXGIInfoQueue
	{
		/// <summary>Sets the maximum number of messages that can be added to the message queue.</summary>
		/// <param name="Producer">A <c>DXGI_DEBUG_ID</c> value that identifies the entity that sets the limit on the number of messages.</param>
		/// <param name="MessageCountLimit">The maximum number of messages that can be added to the queue. –1 means no limit.</param>
		/// <returns>Returns S_OK if successful; an error code otherwise. For a list of error codes, see <c>DXGI_ERROR</c>.</returns>
		/// <remarks>
		/// <para><b>Note</b>  This API requires the Windows Software Development Kit (SDK) for Windows 8.</para>
		/// <para></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgidebug/nf-dxgidebug-idxgiinfoqueue-setmessagecountlimit HRESULT
		// SetMessageCountLimit( [in] DXGI_DEBUG_ID Producer, [in] UINT64 MessageCountLimit );
		[PreserveSig]
		HRESULT SetMessageCountLimit(DXGI_DEBUG_ID Producer, ulong MessageCountLimit);

		/// <summary>Clears all messages from the message queue.</summary>
		/// <param name="Producer">A <c>DXGI_DEBUG_ID</c> value that identifies the entity that clears the messages.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para><b>Note</b>  This API requires the Windows Software Development Kit (SDK) for Windows 8.</para>
		/// <para></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgidebug/nf-dxgidebug-idxgiinfoqueue-clearstoredmessages void
		// ClearStoredMessages( [in] DXGI_DEBUG_ID Producer );
		[PreserveSig]
		void ClearStoredMessages(DXGI_DEBUG_ID Producer);

		/// <summary>Gets a message from the message queue.</summary>
		/// <param name="Producer">A <c>DXGI_DEBUG_ID</c> value that identifies the entity that gets the message.</param>
		/// <param name="MessageIndex">
		/// An index into the message queue after an optional retrieval filter has been applied. This can be between 0 and the number of
		/// messages in the message queue that pass through the retrieval filter. Call
		/// <c>IDXGIInfoQueue::GetNumStoredMessagesAllowedByRetrievalFilters</c> to obtain this number. 0 is the message at the beginning of
		/// the message queue.
		/// </param>
		/// <param name="pMessage">A pointer to a <c>DXGI_INFO_QUEUE_MESSAGE</c> structure that describes the message.</param>
		/// <param name="pMessageByteLength">
		/// A pointer to a variable that receives the size, in bytes, of the message description that <i>pMessage</i> points to. This size
		/// includes the size of the <c>DXGI_INFO_QUEUE_MESSAGE</c> structure in bytes.
		/// </param>
		/// <returns>Returns S_OK if successful; an error code otherwise. For a list of error codes, see <c>DXGI_ERROR</c>.</returns>
		/// <remarks>
		/// <para>This method doesn't remove any messages from the message queue.</para>
		/// <para>This method gets a message from the message queue after an optional retrieval filter has been applied.</para>
		/// <para>
		/// Call this method twice to retrieve a message, first to obtain the size of the message and second to get the message. Here is a
		/// typical example:
		/// </para>
		/// <para>
		/// <c>// Get the size of the message. SIZE_T messageLength = 0; HRESULT hr = pInfoQueue-&gt;GetMessage(DXGI_DEBUG_ALL, 0, NULL,
		/// &amp;messageLength); if(hr == S_FALSE){ // Allocate space and get the message. DXGI_INFO_QUEUE_MESSAGE * pMessage =
		/// (DXGI_INFO_QUEUE_MESSAGE*)malloc(messageLength); hr = pInfoQueue-&gt;GetMessage(DXGI_DEBUG_ALL, 0, pMessage,
		/// &amp;messageLength); // Do something with the message and free it if(hr == S_OK){ // ... // ... // ... free(pMessage); } }</c>
		/// </para>
		/// <para><b>Note</b>  This API requires the Windows Software Development Kit (SDK) for Windows 8.</para>
		/// <para></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgidebug/nf-dxgidebug-idxgiinfoqueue-getmessage HRESULT GetMessage( [in]
		// DXGI_DEBUG_ID Producer, [in] UINT64 MessageIndex, [out, optional] DXGI_INFO_QUEUE_MESSAGE *pMessage, [in, out] SIZE_T
		// *pMessageByteLength );
		[PreserveSig]
		HRESULT GetMessage(DXGI_DEBUG_ID Producer, ulong MessageIndex, [Out, Optional] ManagedStructPointer<DXGI_INFO_QUEUE_MESSAGE> pMessage, ref SizeT pMessageByteLength);

		/// <summary>Gets the number of messages that can pass through a retrieval filter.</summary>
		/// <param name="Producer">A <c>DXGI_DEBUG_ID</c> value that identifies the entity that gets the number.</param>
		/// <returns>Returns the number of messages that can pass through a retrieval filter.</returns>
		/// <remarks>
		/// <para><b>Note</b>  This API requires the Windows Software Development Kit (SDK) for Windows 8.</para>
		/// <para></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgidebug/nf-dxgidebug-idxgiinfoqueue-getnumstoredmessagesallowedbyretrievalfilters
		// UINT64 GetNumStoredMessagesAllowedByRetrievalFilters( [in] DXGI_DEBUG_ID Producer );
		[PreserveSig]
		ulong GetNumStoredMessagesAllowedByRetrievalFilters(DXGI_DEBUG_ID Producer);

		/// <summary>Gets the number of messages currently stored in the message queue.</summary>
		/// <param name="Producer">A <c>DXGI_DEBUG_ID</c> value that identifies the entity that gets the number.</param>
		/// <returns>Returns the number of messages currently stored in the message queue.</returns>
		/// <remarks>
		/// <para><b>Note</b>  This API requires the Windows Software Development Kit (SDK) for Windows 8.</para>
		/// <para></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgidebug/nf-dxgidebug-idxgiinfoqueue-getnumstoredmessages UINT64
		// GetNumStoredMessages( [in] DXGI_DEBUG_ID Producer );
		[PreserveSig]
		ulong GetNumStoredMessages(DXGI_DEBUG_ID Producer);

		/// <summary>Gets the number of messages that were discarded due to the message count limit.</summary>
		/// <param name="Producer">A <c>DXGI_DEBUG_ID</c> value that identifies the entity that gets the number.</param>
		/// <returns>Returns the number of messages that were discarded.</returns>
		/// <remarks>
		/// <para>
		/// Get and set the message count limit with <c>IDXGIInfoQueue::GetMessageCountLimit</c> and
		/// <c>IDXGIInfoQueue::SetMessageCountLimit</c>, respectively.
		/// </para>
		/// <para><b>Note</b>  This API requires the Windows Software Development Kit (SDK) for Windows 8.</para>
		/// <para></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgidebug/nf-dxgidebug-idxgiinfoqueue-getnummessagesdiscardedbymessagecountlimit
		// UINT64 GetNumMessagesDiscardedByMessageCountLimit( [in] DXGI_DEBUG_ID Producer );
		[PreserveSig]
		ulong GetNumMessagesDiscardedByMessageCountLimit(DXGI_DEBUG_ID Producer);

		/// <summary>Gets the maximum number of messages that can be added to the message queue.</summary>
		/// <param name="Producer">A <c>DXGI_DEBUG_ID</c> value that identifies the entity that gets the number.</param>
		/// <returns>Returns the maximum number of messages that can be added to the queue. –1 means no limit.</returns>
		/// <remarks>
		/// <para>When the number of messages in the message queue reaches the maximum limit, new messages coming in push old messages out.</para>
		/// <para><b>Note</b>  This API requires the Windows Software Development Kit (SDK) for Windows 8.</para>
		/// <para></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgidebug/nf-dxgidebug-idxgiinfoqueue-getmessagecountlimit UINT64
		// GetMessageCountLimit( [in] DXGI_DEBUG_ID Producer );
		[PreserveSig]
		ulong GetMessageCountLimit(DXGI_DEBUG_ID Producer);

		/// <summary>Gets the number of messages that a storage filter allowed to pass through.</summary>
		/// <param name="Producer">A <c>DXGI_DEBUG_ID</c> value that identifies the entity that gets the number.</param>
		/// <returns>Returns the number of messages allowed by a storage filter.</returns>
		/// <remarks>
		/// <para><b>Note</b>  This API requires the Windows Software Development Kit (SDK) for Windows 8.</para>
		/// <para></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgidebug/nf-dxgidebug-idxgiinfoqueue-getnummessagesallowedbystoragefilter
		// UINT64 GetNumMessagesAllowedByStorageFilter( [in] DXGI_DEBUG_ID Producer );
		[PreserveSig]
		ulong GetNumMessagesAllowedByStorageFilter(DXGI_DEBUG_ID Producer);

		/// <summary>Gets the number of messages that were denied passage through a storage filter.</summary>
		/// <param name="Producer">A <c>DXGI_DEBUG_ID</c> value that identifies the entity that gets the number.</param>
		/// <returns>Returns the number of messages denied by a storage filter.</returns>
		/// <remarks>
		/// <para><b>Note</b>  This API requires the Windows Software Development Kit (SDK) for Windows 8.</para>
		/// <para></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgidebug/nf-dxgidebug-idxgiinfoqueue-getnummessagesdeniedbystoragefilter
		// UINT64 GetNumMessagesDeniedByStorageFilter( [in] DXGI_DEBUG_ID Producer );
		[PreserveSig]
		ulong GetNumMessagesDeniedByStorageFilter(DXGI_DEBUG_ID Producer);

		/// <summary>Adds storage filters to the top of the storage-filter stack.</summary>
		/// <param name="Producer">A <c>DXGI_DEBUG_ID</c> value that identifies the entity that produced the filters.</param>
		/// <param name="pFilter">An array of <c>DXGI_INFO_QUEUE_FILTER</c> structures that describe the filters.</param>
		/// <returns>Returns S_OK if successful; an error code otherwise. For a list of error codes, see <c>DXGI_ERROR</c>.</returns>
		/// <remarks>
		/// <para><b>Note</b>  This API requires the Windows Software Development Kit (SDK) for Windows 8.</para>
		/// <para></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgidebug/nf-dxgidebug-idxgiinfoqueue-addstoragefilterentries HRESULT
		// AddStorageFilterEntries( [in] DXGI_DEBUG_ID Producer, [in] DXGI_INFO_QUEUE_FILTER *pFilter );
		[PreserveSig]
		HRESULT AddStorageFilterEntries(DXGI_DEBUG_ID Producer, in DXGI_INFO_QUEUE_FILTER pFilter);

		/// <summary>Gets the storage filter at the top of the storage-filter stack.</summary>
		/// <param name="Producer">A <c>DXGI_DEBUG_ID</c> value that identifies the entity that gets the filter.</param>
		/// <param name="pFilter">A pointer to a <c>DXGI_INFO_QUEUE_FILTER</c> structure that describes the filter.</param>
		/// <param name="pFilterByteLength">
		/// A pointer to a variable that receives the size, in bytes, of the filter description to which <i>pFilter</i> points. If
		/// <i>pFilter</i> is <b>NULL</b>, <b>GetStorageFilter</b> outputs the size of the storage filter.
		/// </param>
		/// <returns>Returns S_OK if successful; an error code otherwise. For a list of error codes, see <c>DXGI_ERROR</c>.</returns>
		/// <remarks>
		/// <para><b>Note</b>  This API requires the Windows Software Development Kit (SDK) for Windows 8.</para>
		/// <para></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgidebug/nf-dxgidebug-idxgiinfoqueue-getstoragefilter HRESULT
		// GetStorageFilter( [in] DXGI_DEBUG_ID Producer, [out, optional] DXGI_INFO_QUEUE_FILTER *pFilter, [in, out] SIZE_T
		// *pFilterByteLength );
		[PreserveSig]
		HRESULT GetStorageFilter(DXGI_DEBUG_ID Producer, [Out, Optional] StructPointer<DXGI_INFO_QUEUE_FILTER> pFilter, ref SizeT pFilterByteLength);

		/// <summary>Removes a storage filter from the top of the storage-filter stack.</summary>
		/// <param name="Producer">A <c>DXGI_DEBUG_ID</c> value that identifies the entity that removes the filter.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para><b>Note</b>  This API requires the Windows Software Development Kit (SDK) for Windows 8.</para>
		/// <para></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgidebug/nf-dxgidebug-idxgiinfoqueue-clearstoragefilter void
		// ClearStorageFilter( [in] DXGI_DEBUG_ID Producer );
		[PreserveSig]
		void ClearStorageFilter(DXGI_DEBUG_ID Producer);

		/// <summary>Pushes an empty storage filter onto the storage-filter stack.</summary>
		/// <param name="Producer">A <c>DXGI_DEBUG_ID</c> value that identifies the entity that pushes the empty storage filter.</param>
		/// <returns>Returns S_OK if successful; an error code otherwise. For a list of error codes, see <c>DXGI_ERROR</c>.</returns>
		/// <remarks>
		/// <para>An empty storage filter allows all messages to pass through.</para>
		/// <para><b>Note</b>  This API requires the Windows Software Development Kit (SDK) for Windows 8.</para>
		/// <para></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgidebug/nf-dxgidebug-idxgiinfoqueue-pushemptystoragefilter HRESULT
		// PushEmptyStorageFilter( [in] DXGI_DEBUG_ID Producer );
		[PreserveSig]
		HRESULT PushEmptyStorageFilter(DXGI_DEBUG_ID Producer);

		/// <summary>Pushes a deny-all storage filter onto the storage-filter stack.</summary>
		/// <param name="Producer">A <c>DXGI_DEBUG_ID</c> value that identifies the entity that pushes the filter.</param>
		/// <returns>Returns S_OK if successful; an error code otherwise. For a list of error codes, see <c>DXGI_ERROR</c>.</returns>
		/// <remarks>
		/// <para>A deny-all storage filter prevents all messages from passing through.</para>
		/// <para><b>Note</b>  This API requires the Windows Software Development Kit (SDK) for Windows 8.</para>
		/// <para></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgidebug/nf-dxgidebug-idxgiinfoqueue-pushdenyallstoragefilter HRESULT
		// PushDenyAllStorageFilter( [in] DXGI_DEBUG_ID Producer );
		[PreserveSig]
		HRESULT PushDenyAllStorageFilter(DXGI_DEBUG_ID Producer);

		/// <summary>
		/// Pushes a copy of the storage filter that is currently on the top of the storage-filter stack onto the storage-filter stack.
		/// </summary>
		/// <param name="Producer">A <c>DXGI_DEBUG_ID</c> value that identifies the entity that pushes the copy of the storage filter.</param>
		/// <returns>Returns S_OK if successful; an error code otherwise. For a list of error codes, see <c>DXGI_ERROR</c>.</returns>
		/// <remarks>
		/// <para><b>Note</b>  This API requires the Windows Software Development Kit (SDK) for Windows 8.</para>
		/// <para></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgidebug/nf-dxgidebug-idxgiinfoqueue-pushcopyofstoragefilter HRESULT
		// PushCopyOfStorageFilter( [in] DXGI_DEBUG_ID Producer );
		[PreserveSig]
		HRESULT PushCopyOfStorageFilter(DXGI_DEBUG_ID Producer);

		/// <summary>Pushes a storage filter onto the storage-filter stack.</summary>
		/// <param name="Producer">A <c>DXGI_DEBUG_ID</c> value that identifies the entity that pushes the filter.</param>
		/// <param name="pFilter">A pointer to a <c>DXGI_INFO_QUEUE_FILTER</c> structure that describes the filter.</param>
		/// <returns>Returns S_OK if successful; an error code otherwise. For a list of error codes, see <c>DXGI_ERROR</c>.</returns>
		/// <remarks>
		/// <para><b>Note</b>  This API requires the Windows Software Development Kit (SDK) for Windows 8.</para>
		/// <para></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgidebug/nf-dxgidebug-idxgiinfoqueue-pushstoragefilter HRESULT
		// PushStorageFilter( [in] DXGI_DEBUG_ID Producer, [in] DXGI_INFO_QUEUE_FILTER *pFilter );
		[PreserveSig]
		HRESULT PushStorageFilter(DXGI_DEBUG_ID Producer, in DXGI_INFO_QUEUE_FILTER pFilter);

		/// <summary>Pops a storage filter from the top of the storage-filter stack.</summary>
		/// <param name="Producer">A <c>DXGI_DEBUG_ID</c> value that identifies the entity that pops the filter.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para><b>Note</b>  This API requires the Windows Software Development Kit (SDK) for Windows 8.</para>
		/// <para></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgidebug/nf-dxgidebug-idxgiinfoqueue-popstoragefilter void PopStorageFilter(
		// [in] DXGI_DEBUG_ID Producer );
		[PreserveSig]
		void PopStorageFilter(DXGI_DEBUG_ID Producer);

		/// <summary>Gets the size of the storage-filter stack in bytes.</summary>
		/// <param name="Producer">A <c>DXGI_DEBUG_ID</c> value that identifies the entity that gets the size.</param>
		/// <returns>Returns the size of the storage-filter stack in bytes.</returns>
		/// <remarks>
		/// <para><b>Note</b>  This API requires the Windows Software Development Kit (SDK) for Windows 8.</para>
		/// <para></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgidebug/nf-dxgidebug-idxgiinfoqueue-getstoragefilterstacksize UINT
		// GetStorageFilterStackSize( [in] DXGI_DEBUG_ID Producer );
		[PreserveSig]
		uint GetStorageFilterStackSize(DXGI_DEBUG_ID Producer);

		/// <summary>Adds retrieval filters to the top of the retrieval-filter stack.</summary>
		/// <param name="Producer">A <c>DXGI_DEBUG_ID</c> value that identifies the entity that produced the filters.</param>
		/// <param name="pFilter">An array of <c>DXGI_INFO_QUEUE_FILTER</c> structures that describe the filters.</param>
		/// <returns>Returns S_OK if successful; an error code otherwise. For a list of error codes, see <c>DXGI_ERROR</c>.</returns>
		/// <remarks>
		/// <para><b>Note</b>  This API requires the Windows Software Development Kit (SDK) for Windows 8.</para>
		/// <para></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgidebug/nf-dxgidebug-idxgiinfoqueue-addretrievalfilterentries HRESULT
		// AddRetrievalFilterEntries( [in] DXGI_DEBUG_ID Producer, [in] DXGI_INFO_QUEUE_FILTER *pFilter );
		[PreserveSig]
		HRESULT AddRetrievalFilterEntries(DXGI_DEBUG_ID Producer, in DXGI_INFO_QUEUE_FILTER pFilter);

		/// <summary>Gets the retrieval filter at the top of the retrieval-filter stack.</summary>
		/// <param name="Producer">A <c>DXGI_DEBUG_ID</c> value that identifies the entity that gets the filter.</param>
		/// <param name="pFilter">A pointer to a <c>DXGI_INFO_QUEUE_FILTER</c> structure that describes the filter.</param>
		/// <param name="pFilterByteLength">
		/// A pointer to a variable that receives the size, in bytes, of the filter description to which <i>pFilter</i> points. If
		/// <i>pFilter</i> is <b>NULL</b>, <b>GetRetrievalFilter</b> outputs the size of the retrieval filter.
		/// </param>
		/// <returns>Returns S_OK if successful; an error code otherwise. For a list of error codes, see <c>DXGI_ERROR</c>.</returns>
		/// <remarks>
		/// <para><b>Note</b>  This API requires the Windows Software Development Kit (SDK) for Windows 8.</para>
		/// <para></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgidebug/nf-dxgidebug-idxgiinfoqueue-getretrievalfilter HRESULT
		// GetRetrievalFilter( [in] DXGI_DEBUG_ID Producer, [out, optional] DXGI_INFO_QUEUE_FILTER *pFilter, [in, out] SIZE_T
		// *pFilterByteLength );
		[PreserveSig]
		HRESULT GetRetrievalFilter(DXGI_DEBUG_ID Producer, [Out, Optional] StructPointer<DXGI_INFO_QUEUE_FILTER> pFilter, ref SizeT pFilterByteLength);

		/// <summary>Removes a retrieval filter from the top of the retrieval-filter stack.</summary>
		/// <param name="Producer">A <c>DXGI_DEBUG_ID</c> value that identifies the entity that removes the filter.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para><b>Note</b>  This API requires the Windows Software Development Kit (SDK) for Windows 8.</para>
		/// <para></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgidebug/nf-dxgidebug-idxgiinfoqueue-clearretrievalfilter void
		// ClearRetrievalFilter( [in] DXGI_DEBUG_ID Producer );
		[PreserveSig]
		void ClearRetrievalFilter(DXGI_DEBUG_ID Producer);

		/// <summary>Pushes an empty retrieval filter onto the retrieval-filter stack.</summary>
		/// <param name="Producer">A <c>DXGI_DEBUG_ID</c> value that identifies the entity that pushes the empty retrieval filter.</param>
		/// <returns>Returns S_OK if successful; an error code otherwise. For a list of error codes, see <c>DXGI_ERROR</c>.</returns>
		/// <remarks>
		/// <para>An empty retrieval filter allows all messages to pass through.</para>
		/// <para><b>Note</b>  This API requires the Windows Software Development Kit (SDK) for Windows 8.</para>
		/// <para></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgidebug/nf-dxgidebug-idxgiinfoqueue-pushemptyretrievalfilter HRESULT
		// PushEmptyRetrievalFilter( [in] DXGI_DEBUG_ID Producer );
		[PreserveSig]
		HRESULT PushEmptyRetrievalFilter(DXGI_DEBUG_ID Producer);

		/// <summary>Pushes a deny-all retrieval filter onto the retrieval-filter stack.</summary>
		/// <param name="Producer">A <c>DXGI_DEBUG_ID</c> value that identifies the entity that pushes the deny-all retrieval filter.</param>
		/// <returns>Returns S_OK if successful; an error code otherwise. For a list of error codes, see <c>DXGI_ERROR</c>.</returns>
		/// <remarks>
		/// <para>A deny-all retrieval filter prevents all messages from passing through.</para>
		/// <para><b>Note</b>  This API requires the Windows Software Development Kit (SDK) for Windows 8.</para>
		/// <para></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgidebug/nf-dxgidebug-idxgiinfoqueue-pushdenyallretrievalfilter HRESULT
		// PushDenyAllRetrievalFilter( [in] DXGI_DEBUG_ID Producer );
		[PreserveSig]
		HRESULT PushDenyAllRetrievalFilter(DXGI_DEBUG_ID Producer);

		/// <summary>
		/// Pushes a copy of the retrieval filter that is currently on the top of the retrieval-filter stack onto the retrieval-filter stack.
		/// </summary>
		/// <param name="Producer">A <c>DXGI_DEBUG_ID</c> value that identifies the entity that pushes the copy of the retrieval filter.</param>
		/// <returns>Returns S_OK if successful; an error code otherwise. For a list of error codes, see <c>DXGI_ERROR</c>.</returns>
		/// <remarks>
		/// <para><b>Note</b>  This API requires the Windows Software Development Kit (SDK) for Windows 8.</para>
		/// <para></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgidebug/nf-dxgidebug-idxgiinfoqueue-pushcopyofretrievalfilter HRESULT
		// PushCopyOfRetrievalFilter( [in] DXGI_DEBUG_ID Producer );
		[PreserveSig]
		HRESULT PushCopyOfRetrievalFilter(DXGI_DEBUG_ID Producer);

		/// <summary>Pushes a retrieval filter onto the retrieval-filter stack.</summary>
		/// <param name="Producer">A <c>DXGI_DEBUG_ID</c> value that identifies the entity that pushes the filter.</param>
		/// <param name="pFilter">A pointer to a <c>DXGI_INFO_QUEUE_FILTER</c> structure that describes the filter.</param>
		/// <returns>Returns S_OK if successful; an error code otherwise. For a list of error codes, see <c>DXGI_ERROR</c>.</returns>
		/// <remarks>
		/// <para><b>Note</b>  This API requires the Windows Software Development Kit (SDK) for Windows 8.</para>
		/// <para></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgidebug/nf-dxgidebug-idxgiinfoqueue-pushretrievalfilter HRESULT
		// PushRetrievalFilter( [in] DXGI_DEBUG_ID Producer, [in] DXGI_INFO_QUEUE_FILTER *pFilter );
		[PreserveSig]
		HRESULT PushRetrievalFilter(DXGI_DEBUG_ID Producer, in DXGI_INFO_QUEUE_FILTER pFilter);

		/// <summary>Pops a retrieval filter from the top of the retrieval-filter stack.</summary>
		/// <param name="Producer">A <c>DXGI_DEBUG_ID</c> value that identifies the entity that pops the filter.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para><b>Note</b>  This API requires the Windows Software Development Kit (SDK) for Windows 8.</para>
		/// <para></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgidebug/nf-dxgidebug-idxgiinfoqueue-popretrievalfilter void
		// PopRetrievalFilter( [in] DXGI_DEBUG_ID Producer );
		[PreserveSig]
		void PopRetrievalFilter(DXGI_DEBUG_ID Producer);

		/// <summary>Gets the size of the retrieval-filter stack in bytes.</summary>
		/// <param name="Producer">A <c>DXGI_DEBUG_ID</c> value that identifies the entity that gets the size.</param>
		/// <returns>Returns the size of the retrieval-filter stack in bytes.</returns>
		/// <remarks>
		/// <para><b>Note</b>  This API requires the Windows Software Development Kit (SDK) for Windows 8.</para>
		/// <para></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgidebug/nf-dxgidebug-idxgiinfoqueue-getretrievalfilterstacksize UINT
		// GetRetrievalFilterStackSize( [in] DXGI_DEBUG_ID Producer );
		[PreserveSig]
		uint GetRetrievalFilterStackSize(DXGI_DEBUG_ID Producer);

		/// <summary>Adds a debug message to the message queue and sends that message to the debug output.</summary>
		/// <param name="Producer">A <c>DXGI_DEBUG_ID</c> value that identifies the entity that produced the message.</param>
		/// <param name="Category">A <c>DXGI_INFO_QUEUE_MESSAGE_CATEGORY</c>-typed value that specifies the category of the message.</param>
		/// <param name="Severity">A <c>DXGI_INFO_QUEUE_MESSAGE_SEVERITY</c>-typed value that specifies the severity of the message.</param>
		/// <param name="ID">An integer that uniquely identifies the message.</param>
		/// <param name="pDescription">The message string.</param>
		/// <returns>Returns S_OK if successful; an error code otherwise. For a list of error codes, see <c>DXGI_ERROR</c>.</returns>
		/// <remarks>
		/// <para><b>Note</b>  This API requires the Windows Software Development Kit (SDK) for Windows 8.</para>
		/// <para></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgidebug/nf-dxgidebug-idxgiinfoqueue-addmessage HRESULT AddMessage( [in]
		// DXGI_DEBUG_ID Producer, [in] DXGI_INFO_QUEUE_MESSAGE_CATEGORY Category, [in] DXGI_INFO_QUEUE_MESSAGE_SEVERITY Severity, [in]
		// DXGI_INFO_QUEUE_MESSAGE_ID ID, [in] LPCSTR pDescription );
		[PreserveSig]
		HRESULT AddMessage(DXGI_DEBUG_ID Producer, DXGI_INFO_QUEUE_MESSAGE_CATEGORY Category, DXGI_INFO_QUEUE_MESSAGE_SEVERITY Severity, int ID,
			[MarshalAs(UnmanagedType.LPStr)] string pDescription);

		/// <summary>Adds a user-defined message to the message queue and sends that message to the debug output.</summary>
		/// <param name="Severity">A <c>DXGI_INFO_QUEUE_MESSAGE_SEVERITY</c>-typed value that specifies the severity of the message.</param>
		/// <param name="pDescription">The message string.</param>
		/// <returns>Returns S_OK if successful; an error code otherwise. For a list of error codes, see <c>DXGI_ERROR</c>.</returns>
		/// <remarks>
		/// <para><b>Note</b>  This API requires the Windows Software Development Kit (SDK) for Windows 8.</para>
		/// <para></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgidebug/nf-dxgidebug-idxgiinfoqueue-addapplicationmessage HRESULT
		// AddApplicationMessage( [in] DXGI_INFO_QUEUE_MESSAGE_SEVERITY Severity, [in] LPCSTR pDescription );
		[PreserveSig]
		HRESULT AddApplicationMessage(DXGI_INFO_QUEUE_MESSAGE_SEVERITY Severity, [MarshalAs(UnmanagedType.LPStr)] string pDescription);

		/// <summary>Sets a message category to break on when a message with that category passes through the storage filter.</summary>
		/// <param name="Producer">A <c>DXGI_DEBUG_ID</c> value that identifies the entity that sets the breaking condition.</param>
		/// <param name="Category">A <c>DXGI_INFO_QUEUE_MESSAGE_CATEGORY</c>-typed value that specifies the category of the message.</param>
		/// <param name="bEnable">
		/// A Boolean value that specifies whether <b>SetBreakOnCategory</b> turns on or off this breaking condition ( <b>TRUE</b> for on,
		/// <b>FALSE</b> for off).
		/// </param>
		/// <returns>Returns S_OK if successful; an error code otherwise. For a list of error codes, see <c>DXGI_ERROR</c>.</returns>
		/// <remarks>
		/// <para><b>Note</b>  This API requires the Windows Software Development Kit (SDK) for Windows 8.</para>
		/// <para></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgidebug/nf-dxgidebug-idxgiinfoqueue-setbreakoncategory HRESULT
		// SetBreakOnCategory( [in] DXGI_DEBUG_ID Producer, [in] DXGI_INFO_QUEUE_MESSAGE_CATEGORY Category, [in] BOOL bEnable );
		[PreserveSig]
		HRESULT SetBreakOnCategory(DXGI_DEBUG_ID Producer, DXGI_INFO_QUEUE_MESSAGE_CATEGORY Category, bool bEnable);

		/// <summary>Sets a message severity level to break on when a message with that severity level passes through the storage filter.</summary>
		/// <param name="Producer">A <c>DXGI_DEBUG_ID</c> value that identifies the entity that sets the breaking condition.</param>
		/// <param name="Severity">A <c>DXGI_INFO_QUEUE_MESSAGE_SEVERITY</c>-typed value that specifies the severity of the message.</param>
		/// <param name="bEnable">
		/// A Boolean value that specifies whether <b>SetBreakOnSeverity</b> turns on or off this breaking condition ( <b>TRUE</b> for on,
		/// <b>FALSE</b> for off).
		/// </param>
		/// <returns>Returns S_OK if successful; an error code otherwise. For a list of error codes, see <c>DXGI_ERROR</c>.</returns>
		/// <remarks>
		/// <para><b>Note</b>  This API requires the Windows Software Development Kit (SDK) for Windows 8.</para>
		/// <para></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgidebug/nf-dxgidebug-idxgiinfoqueue-setbreakonseverity HRESULT
		// SetBreakOnSeverity( [in] DXGI_DEBUG_ID Producer, [in] DXGI_INFO_QUEUE_MESSAGE_SEVERITY Severity, [in] BOOL bEnable );
		[PreserveSig]
		HRESULT SetBreakOnSeverity(DXGI_DEBUG_ID Producer, DXGI_INFO_QUEUE_MESSAGE_SEVERITY Severity, bool bEnable);

		/// <summary>Sets a message identifier to break on when a message with that identifier passes through the storage filter.</summary>
		/// <param name="Producer">A <c>DXGI_DEBUG_ID</c> value that identifies the entity that sets the breaking condition.</param>
		/// <param name="ID">An integer value that specifies the identifier of the message.</param>
		/// <param name="bEnable">
		/// A Boolean value that specifies whether <b>SetBreakOnID</b> turns on or off this breaking condition ( <b>TRUE</b> for on,
		/// <b>FALSE</b> for off).
		/// </param>
		/// <returns>Returns S_OK if successful; an error code otherwise. For a list of error codes, see <c>DXGI_ERROR</c>.</returns>
		/// <remarks>
		/// <para><b>Note</b>  This API requires the Windows Software Development Kit (SDK) for Windows 8.</para>
		/// <para></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgidebug/nf-dxgidebug-idxgiinfoqueue-setbreakonid HRESULT SetBreakOnID( [in]
		// DXGI_DEBUG_ID Producer, [in] DXGI_INFO_QUEUE_MESSAGE_ID ID, [in] BOOL bEnable );
		[PreserveSig]
		HRESULT SetBreakOnID(DXGI_DEBUG_ID Producer, int ID, bool bEnable);

		/// <summary>Determines whether the break on a message category is turned on or off.</summary>
		/// <param name="Producer">A <c>DXGI_DEBUG_ID</c> value that identifies the entity that gets the breaking status.</param>
		/// <param name="Category">A <c>DXGI_INFO_QUEUE_MESSAGE_CATEGORY</c>-typed value that specifies the category of the message.</param>
		/// <returns>
		/// Returns a Boolean value that specifies whether this category of breaking condition is turned on or off ( <b>TRUE</b> for on,
		/// <b>FALSE</b> for off).
		/// </returns>
		/// <remarks>
		/// <para><b>Note</b>  This API requires the Windows Software Development Kit (SDK) for Windows 8.</para>
		/// <para></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgidebug/nf-dxgidebug-idxgiinfoqueue-getbreakoncategory BOOL
		// GetBreakOnCategory( [in] DXGI_DEBUG_ID Producer, [in] DXGI_INFO_QUEUE_MESSAGE_CATEGORY Category );
		[PreserveSig]
		bool GetBreakOnCategory(DXGI_DEBUG_ID Producer, DXGI_INFO_QUEUE_MESSAGE_CATEGORY Category);

		/// <summary>Determines whether the break on a message severity level is turned on or off.</summary>
		/// <param name="Producer">A <c>DXGI_DEBUG_ID</c> value that identifies the entity that gets the breaking status.</param>
		/// <param name="Severity">A <c>DXGI_INFO_QUEUE_MESSAGE_SEVERITY</c>-typed value that specifies the severity of the message.</param>
		/// <returns>
		/// Returns a Boolean value that specifies whether this severity of breaking condition is turned on or off ( <b>TRUE</b> for on,
		/// <b>FALSE</b> for off).
		/// </returns>
		/// <remarks>
		/// <para><b>Note</b>  This API requires the Windows Software Development Kit (SDK) for Windows 8.</para>
		/// <para></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgidebug/nf-dxgidebug-idxgiinfoqueue-getbreakonseverity BOOL
		// GetBreakOnSeverity( [in] DXGI_DEBUG_ID Producer, [in] DXGI_INFO_QUEUE_MESSAGE_SEVERITY Severity );
		[PreserveSig]
		bool GetBreakOnSeverity(DXGI_DEBUG_ID Producer, DXGI_INFO_QUEUE_MESSAGE_SEVERITY Severity);

		/// <summary>Determines whether the break on a message identifier is turned on or off.</summary>
		/// <param name="Producer">A <c>DXGI_DEBUG_ID</c> value that identifies the entity that gets the breaking status.</param>
		/// <param name="ID">An integer value that specifies the identifier of the message.</param>
		/// <returns>
		/// Returns a Boolean value that specifies whether this break on a message identifier is turned on or off ( <b>TRUE</b> for on,
		/// <b>FALSE</b> for off).
		/// </returns>
		/// <remarks>
		/// <para><b>Note</b>  This API requires the Windows Software Development Kit (SDK) for Windows 8.</para>
		/// <para></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgidebug/nf-dxgidebug-idxgiinfoqueue-getbreakonid BOOL GetBreakOnID( [in]
		// DXGI_DEBUG_ID Producer, [in] DXGI_INFO_QUEUE_MESSAGE_ID ID );
		[PreserveSig]
		bool GetBreakOnID(DXGI_DEBUG_ID Producer, int ID);

		/// <summary>Turns the debug output on or off.</summary>
		/// <param name="Producer">A <c>DXGI_DEBUG_ID</c> value that identifies the entity that gets the mute status.</param>
		/// <param name="bMute">
		/// A Boolean value that specifies whether to turn the debug output on or off ( <b>TRUE</b> for on, <b>FALSE</b> for off).
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para><b>Note</b>  This API requires the Windows Software Development Kit (SDK) for Windows 8.</para>
		/// <para></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgidebug/nf-dxgidebug-idxgiinfoqueue-setmutedebugoutput void
		// SetMuteDebugOutput( [in] DXGI_DEBUG_ID Producer, [in] BOOL bMute );
		[PreserveSig]
		void SetMuteDebugOutput(DXGI_DEBUG_ID Producer, bool bMute);

		/// <summary>Determines whether the debug output is turned on or off.</summary>
		/// <param name="Producer">A <c>DXGI_DEBUG_ID</c> value that identifies the entity that gets the mute status.</param>
		/// <returns>
		/// Returns a Boolean value that specifies whether the debug output is turned on or off ( <b>TRUE</b> for on, <b>FALSE</b> for off).
		/// </returns>
		/// <remarks>
		/// <para><b>Note</b>  This API requires the Windows Software Development Kit (SDK) for Windows 8.</para>
		/// <para></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dxgidebug/nf-dxgidebug-idxgiinfoqueue-getmutedebugoutput BOOL
		// GetMuteDebugOutput( [in] DXGI_DEBUG_ID Producer );
		[PreserveSig]
		bool GetMuteDebugOutput(DXGI_DEBUG_ID Producer);
	}

	/// <summary>Retrieves a debugging interface.</summary>
	/// <param name="riid">The globally unique identifier (GUID) of the requested interface type.</param>
	/// <param name="ppDebug">A pointer to a buffer that receives a pointer to the debugging interface.</param>
	/// <returns>Returns S_OK if successful; an error code otherwise. For a list of error codes, see DXGI_ERROR.</returns>
	/// <remarks>
	/// <para>IDXGIDebug and IDXGIInfoQueue are debugging interfaces.</para>
	/// <para>
	/// To access <c>DXGIGetDebugInterface</c>, call the GetModuleHandle function to get Dxgidebug.dll and the GetProcAddress function to
	/// get the address of <c>DXGIGetDebugInterface</c>. <c>Windows 8.1:  </c> Starting in Windows 8.1, Windows Store apps call the
	/// DXGIGetDebugInterface1 function to get an IDXGIDebug1 interface.
	/// </para>
	/// <para><c>Note</c>  This API requires the Windows Software Development Kit (SDK) for Windows 8.</para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxgidebug/nf-dxgidebug-dxgigetdebuginterface HRESULT DXGIGetDebugInterface(
	// REFIID riid, void **ppDebug );
	[PInvokeData("dxgidebug.h", MSDNShortId = "NF:dxgidebug.DXGIGetDebugInterface"), DllImport("dxgidebug.dll", SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT DXGIGetDebugInterface(in Guid riid, [MarshalAs(UnmanagedType.Interface)] out object? ppDebug);

	/// <summary>Describes a debug message filter, which contains lists of message types to allow and deny.</summary>
	/// <remarks>
	/// <para>Use with an IDXGIInfoQueue interface.</para>
	/// <para><c>Note</c>  This API requires the Windows Software Development Kit (SDK) for Windows 8.</para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxgidebug/ns-dxgidebug-dxgi_info_queue_filter typedef struct
	// DXGI_INFO_QUEUE_FILTER { DXGI_INFO_QUEUE_FILTER_DESC AllowList; DXGI_INFO_QUEUE_FILTER_DESC DenyList; } DXGI_INFO_QUEUE_FILTER;
	[PInvokeData("dxgidebug.h", MSDNShortId = "NS:dxgidebug.DXGI_INFO_QUEUE_FILTER"), StructLayout(LayoutKind.Sequential)]
	public struct DXGI_INFO_QUEUE_FILTER
	{
		/// <summary>A DXGI_INFO_QUEUE_FILTER_DESC structure that describes the types of messages to allow.</summary>
		public DXGI_INFO_QUEUE_FILTER_DESC AllowList;

		/// <summary>A DXGI_INFO_QUEUE_FILTER_DESC structure that describes the types of messages to deny.</summary>
		public DXGI_INFO_QUEUE_FILTER_DESC DenyList;
	}

	/// <summary>Describes the types of messages to allow or deny to pass through a filter.</summary>
	/// <remarks>
	/// <para>This structure is a member of the DXGI_INFO_QUEUE_FILTER structure.</para>
	/// <para>This API requires the Windows Software Development Kit (SDK) for Windows 8.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxgidebug/ns-dxgidebug-dxgi_info_queue_filter_desc typedef struct
	// DXGI_INFO_QUEUE_FILTER_DESC { UINT NumCategories; DXGI_INFO_QUEUE_MESSAGE_CATEGORY *pCategoryList; UINT NumSeverities;
	// DXGI_INFO_QUEUE_MESSAGE_SEVERITY *pSeverityList; UINT NumIDs; DXGI_INFO_QUEUE_MESSAGE_ID *pIDList; } DXGI_INFO_QUEUE_FILTER_DESC;
	[PInvokeData("dxgidebug.h", MSDNShortId = "NS:dxgidebug.DXGI_INFO_QUEUE_FILTER_DESC"), StructLayout(LayoutKind.Sequential)]
	public struct DXGI_INFO_QUEUE_FILTER_DESC
	{
		/// <summary>The number of message categories to allow or deny.</summary>
		public uint NumCategories;

		/// <summary>
		/// An array of DXGI_INFO_QUEUE_MESSAGE_CATEGORY enumeration values that describe the message categories to allow or deny. The array
		/// must have at least <c>NumCategories</c> number of elements.
		/// </summary>
		public ArrayPointer<DXGI_INFO_QUEUE_MESSAGE_CATEGORY> pCategoryList;

		/// <summary>The number of message severity levels to allow or deny.</summary>
		public uint NumSeverities;

		/// <summary>
		/// An array of DXGI_INFO_QUEUE_MESSAGE_SEVERITY enumeration values that describe the message severity levels to allow or deny. The
		/// array must have at least <c>NumSeverities</c> number of elements.
		/// </summary>
		public ArrayPointer<DXGI_INFO_QUEUE_MESSAGE_SEVERITY> pSeverityList;

		/// <summary>The number of message IDs to allow or deny.</summary>
		public uint NumIDs;

		/// <summary>
		/// An array of integers that represent the message IDs to allow or deny. The array must have at least <c>NumIDs</c> number of elements.
		/// </summary>
		public ArrayPointer<int> pIDList;
	}

	/// <summary>Describes a debug message in the information queue.</summary>
	/// <remarks>
	/// <para>IDXGIInfoQueue::GetMessage returns a pointer to this structure.</para>
	/// <para><c>Note</c>  This API requires the Windows Software Development Kit (SDK) for Windows 8.</para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxgidebug/ns-dxgidebug-dxgi_info_queue_message typedef struct
	// DXGI_INFO_QUEUE_MESSAGE { DXGI_DEBUG_ID Producer; DXGI_INFO_QUEUE_MESSAGE_CATEGORY Category; DXGI_INFO_QUEUE_MESSAGE_SEVERITY
	// Severity; DXGI_INFO_QUEUE_MESSAGE_ID ID; const char *pDescription; SIZE_T DescriptionByteLength; } DXGI_INFO_QUEUE_MESSAGE;
	[PInvokeData("dxgidebug.h", MSDNShortId = "NS:dxgidebug.DXGI_INFO_QUEUE_MESSAGE"), StructLayout(LayoutKind.Sequential)]
	public struct DXGI_INFO_QUEUE_MESSAGE
	{
		/// <summary>A <see cref="DXGI_DEBUG_ID"/> value that identifies the entity that produced the message.</summary>
		public Guid Producer;

		/// <summary>A DXGI_INFO_QUEUE_MESSAGE_CATEGORY-typed value that specifies the category of the message.</summary>
		public DXGI_INFO_QUEUE_MESSAGE_CATEGORY Category;

		/// <summary>A DXGI_INFO_QUEUE_MESSAGE_SEVERITY-typed value that specifies the severity of the message.</summary>
		public DXGI_INFO_QUEUE_MESSAGE_SEVERITY Severity;

		/// <summary>An integer that uniquely identifies the message.</summary>
		public int ID;

		/// <summary>The message string.</summary>
		[MarshalAs(UnmanagedType.LPStr)]
		public string? pDescription;

		/// <summary>The length of the message string at <c>pDescription</c>, in bytes.</summary>
		public SizeT DescriptionByteLength;
	}
}