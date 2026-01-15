namespace Vanara.PInvoke;

public static partial class WindowsDriverFramework
{
	/// <summary>
	/// A driver's <i>EvtCleanupCallback</i> event callback function removes the driver's references on an object so that the object can be deleted.
	/// </summary>
	/// <param name="Object">A handle to a framework object.</param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>
	/// The driver can specify an <i>EvtCleanupCallback</i> callback function in a <c>WDF_OBJECT_ATTRIBUTES</c> structure. This structure is
	/// used as input to all of the framework methods that create framework objects, such as <c>WdfDeviceCreate</c>.
	/// </para>
	/// <para>The framework calls the callback function when either the framework or a driver attempts to delete the object.</para>
	/// <para>
	/// If the driver has called <c>WdfObjectReference</c> to increase the reference count of an object, the driver must provide an
	/// <i>EvtCleanupCallback</i> callback function that calls <c>WdfObjectDereference</c>. This call ensures that the object's reference
	/// count is decremented to zero and, as a result, the framework can call the driver's <c>EvtDestroyCallback</c> callback function and
	/// then delete the object.
	/// </para>
	/// <para>
	/// If a driver supplies both an <i>EvtCleanupCallback</i> callback function and an <c>EvtDestroyCallback</c> callback function for an
	/// object, the framework calls the <i>EvtCleanupCallback</i> callback function first.
	/// </para>
	/// <para>
	/// After the framework calls an object's <i>EvtCleanupCallback</i> callback function, the driver can access the object only from its
	/// <c>EvtDestroyCallback</c> callback function. However, a driver should not attempt to call methods on an object from its EvtDestroyCallback.
	/// </para>
	/// <para>
	/// When a driver creates an object, it sometimes allocates object-specific memory buffers and stores the buffer pointers in the object's
	/// <c>context space</c>. The driver's <i>EvtCleanupCallback</i> or <c>EvtDestroyCallback</c> callback function can deallocate these
	/// memory buffers.
	/// </para>
	/// <para>
	/// Typically, if your driver does not call <c>WdfObjectReference</c> for an object, the object's <i>EvtCleanupCallback</i> callback
	/// function can deallocate object context allocations. In this case, the driver does not need an <c>EvtDestroyCallback</c> callback
	/// function for the object.
	/// </para>
	/// <para>
	/// When an object is deleted, the framework also deletes the object's children. With one exception, the framework calls the
	/// <i>EvtCleanupCallback</i> routines of child objects before calling those of their parent objects, so drivers are guaranteed that the
	/// parent object still exists when a child's <i>EvtCleanupCallback</i> routine runs.
	/// </para>
	/// <para>
	/// The exception to this guaranteed ordering applies to I/O requests that the driver completes at DISPATCH_LEVEL. If such an I/O request
	/// object has one or more children whose <i>EvtCleanupCallback</i> routines must be called at PASSIVE_LEVEL, the parent request might be
	/// deleted before one or more of its children. An object requires cleanup at PASSIVE_LEVEL if it must wait for something to complete or
	/// if it accesses paged memory.
	/// </para>
	/// <para>
	/// If the driver attempts to delete such an object (or the parent of such an object) while it is running at DISPATCH_LEVEL, the
	/// framework queues the <i>EvtCleanupCallback</i> to a work item for later processing at PASSIVE_LEVEL and then calls the cleanup
	/// callback for the parent object without determining whether the callbacks for the children have run.
	/// </para>
	/// <para>
	/// To avoid any problems that might result from this behavior, drivers should not set the request object as the parent for any object
	/// that requires cleanup at PASSIVE_LEVEL. By default, the parent for most objects is WDFDEVICE, so drivers should just accept the
	/// default. Generally, if the WDFDEVICE object is passed as a parameter (either directly or as part of a structure) to the method that
	/// creates the object, the WDFDEVICE is the default parent. For a complete list of default parents, see <c>Summary of Framework Objects</c>.
	/// </para>
	/// <para>
	/// If the above exception does not apply, the framework calls the child object's <i>EvtCleanupCallback</i> callback functions before
	/// calling the parent object's <i>EvtCleanupCallback</i> callback function. Next, if the child's reference count is zero, the framework
	/// calls the child object's <c>EvtDestroyCallback</c> callback function. Finally, if the parent's reference count is zero, the framework
	/// calls the parent object's <i>EvtDestroyCallback</i> callback function.
	/// </para>
	/// <para>For more information about deleting framework objects, see <c>Framework Object Life Cycle</c>.</para>
	/// <para>
	/// Typically, the framework calls the <i>EvtCleanupCallback</i> callback function at IRQL &lt;= DISPATCH_LEVEL. However, the framework
	/// calls the callback function at IRQL = PASSIVE_LEVEL in the following situations:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <description>
	/// The object's handle type is WDFDEVICE, WDFDRIVER, WDFDPC, WDFINTERRUPT, WDFIOTARGET, WDFQUEUE, WDFSTRING, WDFTIMER, or WDFWORKITEM.
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// The object's handle type is WDFMEMORY or WDFLOOKASIDE, and the driver has specified <b>PagedPool</b> for the <i>PoolType</i>
	/// parameter to <c>WdfMemoryCreate</c> or <c>WdfLookasideListCreate</c>.
	/// </description>
	/// </item>
	/// </list>
	/// <para>
	/// When a work-item object is deleted, either explicitly or because the work item's parent object is being deleted, then before calling
	/// the work item's <i>EvtCleanupCallback</i> callback function, the framework waits until all instances of the work item's
	/// <c>EvtWorkItem</c> callback function have returned. For more information, see <c>WdfWorkItemEnqueue</c>.
	/// </para>
	/// <para>
	/// Similarly, when a timer object is deleted, either explicitly or because the timer's parent object is being deleted, then before
	/// calling the timer's <i>EvtCleanupCallback</i> callback function, the framework waits until all instances of the timer's
	/// <c>EvtTimerFunc</c> event callback function have returned.
	/// </para>
	/// <para>
	/// Beginning with version 1.9 of the framework, the <i>wdfroletypes.h</i> header file contains some alternative, object type-specific,
	/// function types for the <i>EvtCleanupCallback</i> callback function. These alternative types help verification tools to determine
	/// whether the driver is properly using the callback function. Use the following table to determine which function type to use.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <description>Object Type</description>
	/// <description>Function Type</description>
	/// </listheader>
	/// <item>
	/// <description>Device object</description>
	/// <description>EVT_WDF_DEVICE_CONTEXT_CLEANUP</description>
	/// </item>
	/// <item>
	/// <description>I/O queue object</description>
	/// <description>EVT_WDF_IO_QUEUE_CONTEXT_CLEANUP_CALLBACK</description>
	/// </item>
	/// <item>
	/// <description>File object</description>
	/// <description>EVT_WDF_FILE_CONTEXT_CLEANUP_CALLBACK</description>
	/// </item>
	/// <item>
	/// <description>All other objects</description>
	/// <description>EVT_WDF_OBJECT_CONTEXT_CLEANUP</description>
	/// </item>
	/// </list>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdfobject/nc-wdfobject-evt_wdf_object_context_cleanup
	// EVT_WDF_OBJECT_CONTEXT_CLEANUP EvtWdfObjectContextCleanup; VOID EvtWdfObjectContextCleanup( [in] WDFOBJECT Object ) {...}
	[PInvokeData("wdfobject.h", MSDNShortId = "NC:wdfobject.EVT_WDF_OBJECT_CONTEXT_CLEANUP")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi, SetLastError = false)]
	public delegate void EVT_WDF_OBJECT_CONTEXT_CLEANUP([In] WDFOBJECT Object);

	/// <summary>
	/// A driver's <i>EvtDestroyCallback</i> event callback function performs operations that are associated with the deletion of a framework object.
	/// </summary>
	/// <param name="Object">A handle to a framework object.</param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>
	/// The driver can specify an <i>EvtDestroyCallback</i> callback function in a <c>WDF_OBJECT_ATTRIBUTES</c> structure. This structure is
	/// used as input to all of the framework methods that create framework objects, such as <c>WdfDeviceCreate</c>.
	/// </para>
	/// <para>
	/// The framework calls the <i>EvtDestroyCallback</i> callback function after the object's reference count has been decremented to zero.
	/// The framework deletes the object immediately after the <i>EvtDestroyCallback</i> callback function returns.
	/// </para>
	/// <para>The <i>EvtDestroyCallback</i> can access the object context but cannot call any methods on the object.</para>
	/// <para>
	/// If a driver supplies both an <c>EvtCleanupCallback</c> callback function and an <i>EvtDestroyCallback</i> callback function for an
	/// object, the framework calls the <i>EvtCleanupCallback</i> callback function first.
	/// </para>
	/// <para>
	/// When an object is deleted, the framework also deletes the object's children. The framework calls the child objects'
	/// <c>EvtCleanupCallback</c> callback functions before calling the parent object's <i>EvtCleanupCallback</i> callback function. Next, if
	/// the child's reference count is zero, the framework calls the child object's <i>EvtDestroyCallback</i> callback function. Finally, if
	/// the parent's reference count is zero, the framework calls the parent object's <i>EvtDestroyCallback</i> callback function.
	/// </para>
	/// <para>
	/// When a driver creates an object, it sometimes allocates object-specific memory buffers and stores the buffer pointers in the object's
	/// <c>context space</c>. The driver's <c>EvtCleanupCallback</c> or <i>EvtDestroyCallback</i> callback function can deallocate these
	/// memory buffers.
	/// </para>
	/// <para>For more information about deleting framework objects, see <c>Framework Object Life Cycle</c>.</para>
	/// <para>
	/// Typically, the framework calls the <i>EvtDestroyCallback</i> callback function at IRQL &lt;= DISPATCH_LEVEL. However, the framework
	/// calls the callback function at IRQL = PASSIVE_LEVEL in the following situations:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <description>
	/// The object's handle type is WDFDEVICE, WDFDRIVER, WDFDPC, WDFINTERRUPT, WDFIOTARGET, WDFQUEUE, WDFSTRING, WDFTIMER, or WDFWORKITEM.
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// The object's handle type is WDFMEMORY or WDFLOOKASIDE, and the driver has specified <b>PagedPool</b> for the <i>PoolType</i>
	/// parameter to <c>WdfMemoryCreate</c> or <c>WdfLookasideListCreate</c>.
	/// </description>
	/// </item>
	/// </list>
	/// <para>
	/// Beginning with version 1.9 of the framework, the <i>wdfroletypes.h</i> header file contains some alternative, object type-specific,
	/// function types for the <i>EvtDestroyCallback</i> callback function. These alternative types help verification tools to determine
	/// whether the driver is properly using the callback function. Use the following table to determine which function type to use.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <description>Object Type</description>
	/// <description>Function Type</description>
	/// </listheader>
	/// <item>
	/// <description>Device object</description>
	/// <description>EVT_WDF_DEVICE_CONTEXT_DESTROY</description>
	/// </item>
	/// <item>
	/// <description>I/O queue object</description>
	/// <description>EVT_WDF_IO_QUEUE_CONTEXT_DESTROY_CALLBACK</description>
	/// </item>
	/// <item>
	/// <description>File object</description>
	/// <description>EVT_WDF_FILE_CONTEXT_DESTROY_CALLBACK</description>
	/// </item>
	/// <item>
	/// <description>All other objects</description>
	/// <description>EVT_WDF_OBJECT_CONTEXT_DESTROY</description>
	/// </item>
	/// </list>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdfobject/nc-wdfobject-evt_wdf_object_context_destroy
	// EVT_WDF_OBJECT_CONTEXT_DESTROY EvtWdfObjectContextDestroy; VOID EvtWdfObjectContextDestroy( [in] WDFOBJECT Object ) {...}
	[PInvokeData("wdfobject.h", MSDNShortId = "NC:wdfobject.EVT_WDF_OBJECT_CONTEXT_DESTROY")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi, SetLastError = false)]
	public delegate void EVT_WDF_OBJECT_CONTEXT_DESTROY([In] WDFOBJECT Object);

	/// <summary>Internal use delegate that returns a pointer to a unique WDF_OBJECT_CONTEXT_TYPE_INFO structure for a given context type.</summary>
	public delegate StructPointer<WDF_OBJECT_CONTEXT_TYPE_INFO> PFN_GET_UNIQUE_CONTEXT_TYPE();

	/// <summary>
	/// The WDF_EXECUTION_LEVEL enumeration type specifies the maximum IRQL at which the framework will call the event callback functions
	/// that a driver has supplied for a framework object.
	/// </summary>
	/// <remarks>
	/// <para>
	/// Drivers use the WDF_EXECUTION_LEVEL enumeration type to specify the <b>ExecutionLevel</b> member of an object's
	/// <c>WDF_OBJECT_ATTRIBUTES</c> structure.
	/// </para>
	/// <para>You can specify an <b>ExecutionLevel</b> value for the following objects:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>Framework driver objects</description>
	/// </item>
	/// <item>
	/// <description>Framework device objects</description>
	/// </item>
	/// <item>
	/// <description>Framework file objects</description>
	/// </item>
	/// <item>
	/// <description>Framework general objects</description>
	/// </item>
	/// <item>
	/// <description>Framework queue objects (Framework versions 1.9 and later)</description>
	/// </item>
	/// <item>
	/// <description>Framework timer objects (Framework versions 1.9 and later)</description>
	/// </item>
	/// </list>
	/// <para><b>KMDF</b> By default, the framework sets the <b>ExecutionLevel</b> value of framework driver objects to <b>WdfExecutionLevelDispatch.</b></para>
	/// <para><b>UMDF</b> By default, the framework sets the <b>ExecutionLevel</b> value of framework driver objects to <b>WdfExecutionLevelPassive.</b></para>
	/// <para>The default <b>ExecutionLevel</b> value for all other objects is <b>WdfExecutionLevelInheritFromParent.</b></para>
	/// <para>
	/// For more information about execution levels for event callback functions, see <c>Synchronization Techniques for Framework-Based Drivers</c>.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdfobject/ne-wdfobject-_wdf_execution_level typedef enum
	// _WDF_EXECUTION_LEVEL { WdfExecutionLevelInvalid = 0x00, WdfExecutionLevelInheritFromParent, WdfExecutionLevelPassive,
	// WdfExecutionLevelDispatch } WDF_EXECUTION_LEVEL;
	[PInvokeData("wdfobject.h", MSDNShortId = "NE:wdfobject._WDF_EXECUTION_LEVEL")]
	public enum WDF_EXECUTION_LEVEL
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0x00</para>
		/// <para>Reserved for system use.</para>
		/// </summary>
		WdfExecutionLevelInvalid,

		/// <summary>
		/// The framework uses the maximum IRQL value of the object's parent, unless the object is one that requires IRQL = DISPATCH_LEVEL
		/// (such as a DPC object). This value is the default if a driver does not specify a WDF_EXECUTION_LEVEL-typed value.
		/// </summary>
		WdfExecutionLevelInheritFromParent,

		/// <summary>The framework always calls the object's callback functions at IRQL = PASSIVE_LEVEL.</summary>
		WdfExecutionLevelPassive,

		/// <summary>The framework calls the object's callback functions at IRQL &lt;= DISPATCH_LEVEL. Not available in UMDF.</summary>
		WdfExecutionLevelDispatch,
	}

	/// <summary>
	/// The WDF_SYNCHRONIZATION_SCOPE enumeration type specifies how the framework will synchronize execution of an object's event callback functions.
	/// </summary>
	/// <remarks>
	/// <para>
	/// Drivers use the WDF_SYNCHRONIZATION_SCOPE enumeration type to specify the <b>SynchronizationScope</b> member of an object's
	/// <c>WDF_OBJECT_ATTRIBUTES</c> structure.
	/// </para>
	/// <para>You can specify a <b>SynchronizationScope</b> value for only the following objects:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>Framework driver objects</description>
	/// </item>
	/// <item>
	/// <description>Framework device objects</description>
	/// </item>
	/// <item>
	/// <description>Framework queue objects</description>
	/// </item>
	/// </list>
	/// <para>
	/// The framework sets the <b>SynchronizationScope</b> value of framework driver objects to <b>WdfSynchronizationScopeNone</b>. It sets
	/// the <b>SynchronizationScope</b> value of framework device objects and framework queue objects to <b>WdfSynchronizationScopeInheritFromParent</b>.
	/// </para>
	/// <para>
	/// For more information about synchronization of a driver's event callback functions, see <c>Synchronization Techniques for
	/// Framework-Based Drivers</c>.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdfobject/ne-wdfobject-_wdf_synchronization_scope typedef enum
	// _WDF_SYNCHRONIZATION_SCOPE { WdfSynchronizationScopeInvalid = 0x00, WdfSynchronizationScopeInheritFromParent,
	// WdfSynchronizationScopeDevice, WdfSynchronizationScopeQueue, WdfSynchronizationScopeNone } WDF_SYNCHRONIZATION_SCOPE;
	[PInvokeData("wdfobject.h", MSDNShortId = "NE:wdfobject._WDF_SYNCHRONIZATION_SCOPE")]
	public enum WDF_SYNCHRONIZATION_SCOPE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0x00</para>
		/// <para>Reserved for system use.</para>
		/// </summary>
		WdfSynchronizationScopeInvalid,

		/// <summary>
		/// The framework uses the synchronization scope value that was specified for the object's parent object. This value is the default
		/// if a driver does not specify a WDF_SYNCHRONIZATION_SCOPE-typed value.
		/// </summary>
		WdfSynchronizationScopeInheritFromParent,

		/// <summary>
		/// <para>
		/// The framework synchronizes execution of the event callback functions of all queue and file objects that are underneath a device
		/// object in the driver's object hierarchy.
		/// </para>
		/// <para>Additionally, if the driver sets the</para>
		/// <para>AutomaticSerialization</para>
		/// <para>member to</para>
		/// <para>TRUE</para>
		/// <para>
		/// in the configuration structure for an interrupt, DPC, work-item, or timer object that is underneath the same device object, the
		/// framework also synchronizes that object's callback functions.
		/// </para>
		/// <para>
		/// The framework obtains the device object's synchronization lock before calling a callback function. Therefore, these callback
		/// functions run one at a time. However, if the driver creates multiple objects of the same type, but under different device
		/// objects, their event callback functions might run concurrently on a multiprocessor system.
		/// </para>
		/// </summary>
		WdfSynchronizationScopeDevice,

		/// <summary>
		/// <para>
		/// This value affects queue objects only. The framework synchronizes the event callback functions of the queue object so that only
		/// one executes at a time.
		/// </para>
		/// <para>Additionally, if the driver sets</para>
		/// <para>AutomaticSerialization</para>
		/// <para>to</para>
		/// <para>TRUE</para>
		/// <para>
		/// in the configuration structure for an interrupt, DPC, work-item, or timer object that is underneath the queue object or its
		/// parent device object, the framework also synchronizes that object's callback functions.
		/// </para>
		/// <para>
		/// The framework obtains the queue object's synchronization lock before calling any callback functions that belong to the object.
		/// </para>
		/// <para>
		/// If the driver creates multiple queue objects, their event callback functions might run concurrently on a multiprocessor system.
		/// </para>
		/// <para>For framework versions 1.9 and later, a driver should set</para>
		/// <para>WdfSynchronizationScopeQueue</para>
		/// <para>for individual queue objects. To use this scope with earlier versions of the framework, the driver must set</para>
		/// <para>WdfSynchronizationScopeQueue</para>
		/// <para>for the parent device object and</para>
		/// <para>WdfSynchronizationScopeInheritFromParent</para>
		/// <para>for the queue object.</para>
		/// </summary>
		WdfSynchronizationScopeQueue,

		/// <summary>
		/// The framework does not synchronize the object's event callback functions, so the callback functions might run concurrently on a
		/// multiprocessor system.
		/// </summary>
		WdfSynchronizationScopeNone,
	}

	/// <summary>The WDF_OBJECT_ATTRIBUTES structure describes attributes that can be associated with any framework object.</summary>
	/// <remarks>
	/// <para>The WDF_OBJECT_ATTRIBUTES structure is used as an input argument to several methods that create framework objects.</para>
	/// <para>To initialize a WDF_OBJECT_ATTRIBUTES structure, the driver must call <c>WDF_OBJECT_ATTRIBUTES_INIT</c>.</para>
	/// <para>
	/// Additionally, if you are defining object-specific context information for an object, you must use the
	/// <c>WDF_OBJECT_ATTRIBUTES_SET_CONTEXT_TYPE</c> macro.
	/// </para>
	/// <para>
	/// Alternatively, you can use the <c>WDF_OBJECT_ATTRIBUTES_INIT_CONTEXT_TYPE</c> macro instead of the WDF_OBJECT_ATTRIBUTES_INIT and
	/// WDF_OBJECT_ATTRIBUTES_SET_CONTEXT_TYPE macros.
	/// </para>
	/// <para>For more information about using these macros, see <c>Framework Object Context Space</c>.</para>
	/// <para>
	/// Use the <b>ContextSizeOverride</b> member of WDF_OBJECT_ATTRIBUTES if you want to create <c>object context space</c> that has a
	/// variable length. For example, you might define a context space structure that contains an array, as follows:
	/// </para>
	/// <para><c>typedef struct _MY_REQUEST_CONTEXT { ULONG ByteCount; BYTE Bytes[1]; } MY_REQUEST_CONTEXT, *PMY_REQUEST_CONTEXT; WDF_DECLARE_CONTEXT_TYPE(MY_REQUEST_CONTEXT);</c></para>
	/// <para>
	/// When your driver creates an object that uses the context space structure, it can use the <b>ContextSizeOverride</b> member to specify
	/// the context size that is needed for each individual object. For example, your driver might calculate the number of bytes that are
	/// needed in the array from the preceding example and then use <b>ContextSizeOverride</b> to specify the extra bytes, as follows:
	/// </para>
	/// <para>
	/// <c>WDF_OBJECT_ATTRIBUTES MyRequestObjectAttributes; PMY_REQUEST_CONTEXT pMyContext; WDF_OBJECT_ATTRIBUTES_INIT_CONTEXT_TYPE(
	/// &amp;MyRequestObjectAttributes, MY_REQUEST_CONTEXT ); MyRequestObjectAttributes.ContextSizeOverride = sizeof(MY_REQUEST_CONTEXT) +
	/// Num_Extra_Bytes - 1;</c>
	/// </para>
	/// <para>The driver can then create an object with a customized context size.</para>
	/// <para><c>status = WdfRequestCreate( &amp;MyRequestObjectAttributes, ioTarget, &amp;newRequest );</c></para>
	/// <para>For more information about the cleanup rules for a framework object hierarchy, see <c>Framework Object Life Cycle</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdfobject/ns-wdfobject-_wdf_object_attributes typedef struct
	// _WDF_OBJECT_ATTRIBUTES { ULONG Size; PFN_WDF_OBJECT_CONTEXT_CLEANUP EvtCleanupCallback; PFN_WDF_OBJECT_CONTEXT_DESTROY
	// EvtDestroyCallback; WDF_EXECUTION_LEVEL ExecutionLevel; WDF_SYNCHRONIZATION_SCOPE SynchronizationScope; WDFOBJECT ParentObject; size_t
	// ContextSizeOverride; PCWDF_OBJECT_CONTEXT_TYPE_INFO ContextTypeInfo; } WDF_OBJECT_ATTRIBUTES, *PWDF_OBJECT_ATTRIBUTES;
	[PInvokeData("wdfobject.h", MSDNShortId = "NS:wdfobject._WDF_OBJECT_ATTRIBUTES")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct WDF_OBJECT_ATTRIBUTES
	{
		/// <summary>The size, in bytes, of this structure.</summary>
		public uint Size;

		/// <summary>A pointer to the driver's <c>EvtCleanupCallback</c> callback function, or <b>NULL</b>.</summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public EVT_WDF_OBJECT_CONTEXT_CLEANUP EvtCleanupCallback;

		/// <summary>A pointer to the driver's <c>EvtDestroyCallback</c> callback function, or <b>NULL</b>.</summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public EVT_WDF_OBJECT_CONTEXT_DESTROY EvtDestroyCallback;

		/// <summary>
		/// A <c>WDF_EXECUTION_LEVEL</c>-typed value that specifies the maximum IRQL at which the framework will call the object's event
		/// callback functions. For a list of framework objects for which the driver can specify an <b>ExecutionLevel</b> value, see <c>WDF_EXECUTION_LEVEL</c>.
		/// </summary>
		public WDF_EXECUTION_LEVEL ExecutionLevel;

		/// <summary>
		/// A <c>WDF_SYNCHRONIZATION_SCOPE</c>-typed value that specifies how the framework will synchronize execution of the object's event
		/// callback functions. For a list of framework objects for which the driver can specify a <b>SynchronizationScope</b> value, see <c>WDF_SYNCHRONIZATION_SCOPE</c>.
		/// </summary>
		public WDF_SYNCHRONIZATION_SCOPE SynchronizationScope;

		/// <summary>
		/// <para>A handle to the object's parent object, or <b>NULL</b> if the object does not have a driver-specified parent.</para>
		/// <para>
		/// See <c>Summary of Framework Objects</c> for a table that shows the objects that allow a driver-specified parent. The table also
		/// shows the default parent of each object.
		/// </para>
		/// </summary>
		public WDFOBJECT ParentObject;

		/// <summary>
		/// If not zero, this value overrides the <b>ContextSize</b> member of the <c>WDF_OBJECT_CONTEXT_TYPE_INFO</c> structure that the
		/// <b>ContextTypeInfo</b> member references. This value is optional and can be zero. If the value is not zero, it must specify a
		/// size, in bytes, that is larger than the value that is specified for the <b>ContextSize</b> member of the
		/// WDF_OBJECT_CONTEXT_TYPE_INFO structure. For more information, see the following Remarks section.
		/// </summary>
		public SizeT ContextSizeOverride;

		/// <summary>
		/// A pointer to a <c>WDF_OBJECT_CONTEXT_TYPE_INFO</c> structure. The <c>WDF_OBJECT_ATTRIBUTES_SET_CONTEXT_TYPE</c> macro sets this pointer.
		/// </summary>
		public StructPointer<WDF_OBJECT_CONTEXT_TYPE_INFO> ContextTypeInfo;
	}

	/// <summary>The WDF_OBJECT_CONTEXT_TYPE_INFO structure describes a framework object's driver-defined context memory.</summary>
	/// <remarks>
	/// <para>
	/// For each object instance, the framework allocates context memory with a size that is based on the value of the <b>ContextSize</b>
	/// member or the value of the <b>ContextSizeOverride</b> member of the <c>WDF_OBJECT_ATTRIBUTES</c> structure.
	/// </para>
	/// <para>
	/// To create and initialize a WDF_OBJECT_CONTEXT_TYPE_INFO structure, drivers should use either the <c>WDF_DECLARE_CONTEXT_TYPE</c>
	/// macro or the <c>WDF_DECLARE_CONTEXT_TYPE_WITH_NAME</c> macro.
	/// </para>
	/// <para>
	/// To insert a pointer to this structure into a WDF_OBJECT_ATTRIBUTES structure, drivers should use the
	/// <c>WDF_OBJECT_ATTRIBUTES_SET_CONTEXT_TYPE</c> macro.
	/// </para>
	/// <para>For more information about using these macros, see <c>Framework Object Context Space</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdfobject/ns-wdfobject-_wdf_object_context_type_info typedef struct
	// _WDF_OBJECT_CONTEXT_TYPE_INFO { ULONG Size; LPCSTR ContextName; size_t ContextSize; PCWDF_OBJECT_CONTEXT_TYPE_INFO UniqueType;
	// PFN_GET_UNIQUE_CONTEXT_TYPE EvtDriverGetUniqueContextType; } WDF_OBJECT_CONTEXT_TYPE_INFO, *PWDF_OBJECT_CONTEXT_TYPE_INFO;
	[PInvokeData("wdfobject.h", MSDNShortId = "NS:wdfobject._WDF_OBJECT_CONTEXT_TYPE_INFO")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct WDF_OBJECT_CONTEXT_TYPE_INFO
	{
		/// <summary>The size, in bytes, of this structure.</summary>
		public uint Size;

		/// <summary>A quoted string that represents the name of a driver-defined structure that contains an object's context information.</summary>
		public LPWSTR ContextName;

		/// <summary>
		/// The size, in bytes, of the structure that the <b>ContextName</b> member specifies. The framework allocates space for this
		/// structure when it creates an object. If the <b>ContextSizeOverride</b> member of the <c>WDF_OBJECT_ATTRIBUTES</c> structure is
		/// nonzero, its value overrides the value in the <b>ContextSize</b> member.
		/// </summary>
		public SizeT ContextSize;

		/// <summary>For internal use.</summary>
		public StructPointer<WDF_OBJECT_CONTEXT_TYPE_INFO> UniqueType;

		/// <summary>For internal use: Function pointer of type <see cref="PFN_GET_UNIQUE_CONTEXT_TYPE"/>.</summary>
		public IntPtr EvtDriverGetUniqueContextType;
	}
}