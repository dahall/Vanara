using System.Drawing;
using static Vanara.PInvoke.Ole32;

namespace Vanara.PInvoke;

public static partial class PropSys
{
	/// <summary>
	/// <para>
	/// Indicates flags that modify the property store object retrieved by methods that create a property store, such as
	/// IShellItem2::GetPropertyStore or IPropertyStoreFactory::GetPropertyStore.
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>If the Shell item is a file, the property store contains the following items.</para>
	/// <list type="bullet">
	/// <item>Properties from the file system that concern the file.</item>
	/// <item>Properties from the file itself that are provided by the file's property handler, unless the file is offline (see GPS_OPENSLOWITEM).</item>
	/// </list>
	/// <para>Non-file Shell items return a similar read-only store.</para>
	/// <para><c>Note</c> GPS_INCLUDEOFFLINEPROPERTIES has been superseded by GPS_OPENSLOWITEM.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/ne-propsys-getpropertystoreflags
	[Flags]
	[PInvokeData("propsys.h", MSDNShortId = "d3fde1b9-b19f-431d-9cea-bffc289ee683")]
	public enum GETPROPERTYSTOREFLAGS
	{
		/// <summary>
		/// Meaning to a calling process: Succeed at getting the store, even if some properties are not returned. Note: Some values may
		/// be different, or missing, compared to a store without this flag.
		/// <para>
		/// Meaning to a file folder: Succeed and return a store, even if the handler or innate store has an error during creation. Only
		/// fail if substores fail.
		/// </para>
		/// <para>Meaning to other folders: Succeed on getting the store, even if some properties are not returned.</para>
		/// <para>Combination with other flags: Cannot be combined with GPS_TEMPORARY, GPS_READWRITE, or GPS_HANDLERPROPERTIESONLY.</para>
		/// </summary>
		GPS_BESTEFFORT = 0x40,

		/// <summary>
		/// Meaning to a calling process: Return a read-only property store that contains all properties. Slow items (offline files) are
		/// not opened.
		/// <para>Combination with other flags: Can be overridden by other flags.</para>
		/// </summary>
		GPS_DEFAULT = 0,

		/// <summary>
		/// Meaning to a calling process: Delay memory-intensive operations, such as file access, until a property is requested that
		/// requires such access.
		/// <para>
		/// Meaning to a file folder: Do not create the handler until needed; for example, either GetCount/GetAt or GetValue, where the
		/// innate store does not satisfy the request. Note: GetValue might fail due to file access problems.
		/// </para>
		/// <para>
		/// Meaning to other folders: If the folder has memory-intensive properties, such as delegating to a file folder or network
		/// access, it can optimize performance by supporting IDelayedPropertyStoreFactory and splitting up its properties into a fast
		/// and a slow store. It can then use delayed MUX to recombine them.
		/// </para>
		/// <para>Combination with other flags: Cannot be combined with GPS_TEMPORARY or GPS_READWRITE.</para>
		/// </summary>
		GPS_DELAYCREATION = 0x20,

		/// <summary>
		/// Meaning to a calling process: Provides a store that does not involve reading from the disk or network. Note: Some values may
		/// be different, or missing, compared to a store without this flag.
		/// <para>Meaning to a file folder: Include the "innate" and "fallback" stores only. Do not load the handler.</para>
		/// <para>
		/// Meaning to other folders: Include only properties that are available in memory or can be computed very quickly (no properties
		/// from disk, network, or peripheral IO devices). This is normally only data sources from the IDLIST. When delegating to other
		/// folders, pass this flag on to them.
		/// </para>
		/// <para>
		/// Combination with other flags: Cannot be combined with GPS_TEMPORARY, GPS_READWRITE, GPS_HANDLERPROPERTIESONLY, or GPS_DELAYCREATION.
		/// </para>
		/// </summary>
		GPS_FASTPROPERTIESONLY = 8,

		/// <summary>
		/// Meaning to a calling process: Include only properties directly from the property handler, which opens the file on the disk,
		/// network, or device.
		/// <para>Meaning to a file folder: Only include properties directly from the handler.</para>
		/// <para>
		/// Meaning to other folders: When delegating to a file folder, pass this flag on to the file folder; do not do any multiplexing
		/// (MUX). When not delegating to a file folder, ignore this flag instead of returning a failure code.
		/// </para>
		/// <para>Combination with other flags: Cannot be combined with GPS_TEMPORARY, GPS_FASTPROPERTIESONLY, or GPS_BESTEFFORT.</para>
		/// </summary>
		GPS_HANDLERPROPERTIESONLY = 1,

		/// <summary>Mask for valid GETPROPERTYSTOREFLAGS values.</summary>
		GPS_MASK_VALID = 0x1fff,

		/// <summary>
		/// Windows 7 and later. Callers should use this flag only if they are already holding an opportunistic lock (oplock) on the file
		/// because without an oplock, the bind operation cannot continue. By default, the Shell requests an oplock on a file before
		/// binding to the property handler. This flag disables the default behavior.
		/// <para><c>Windows Server 2008 and Windows Vista:</c> This flag is not available.</para>
		/// </summary>
		GPS_NO_OPLOCK = 0x80,

		/// <summary>
		/// Meaning to a calling process: Open a slow item (offline file) if necessary.
		/// <para>
		/// Meaning to a file folder: Retrieve a file from offline storage, if necessary. Note: Without this flag, the handler is not
		/// created for offline files.
		/// </para>
		/// <para>Meaning to other folders: Do not return any properties that are very slow.</para>
		/// <para>Combination with other flags: Cannot be combined with GPS_TEMPORARY or GPS_FASTPROPERTIESONLY.</para>
		/// </summary>
		GPS_OPENSLOWITEM = 0x10,

		/// <summary>
		/// Meaning to a calling process: Can write properties to the item. Note: The store may contain fewer properties than a read-only store.
		/// <para>Meaning to a file folder: ReadWrite.</para>
		/// <para>
		/// Meaning to other folders: ReadWrite. Note: When using default MUX, return a single unmultiplexed store because the default
		/// MUX does not support ReadWrite.
		/// </para>
		/// <para>
		/// Combination with other flags: Cannot be combined with GPS_TEMPORARY, GPS_FASTPROPERTIESONLY, GPS_BESTEFFORT, or
		/// GPS_DELAYCREATION. Implies GPS_HANDLERPROPERTIESONLY.
		/// </para>
		/// </summary>
		GPS_READWRITE = 2,

		/// <summary>
		/// Meaning to a calling process: Provides a writable store, with no initial properties, that exists for the lifetime of the
		/// Shell item instance; basically, a property bag attached to the item instance.
		/// <para>Meaning to a file folder: Not applicable. Handled by the Shell item.</para>
		/// <para>Meaning to other folders: Not applicable. Handled by the Shell item.</para>
		/// <para>Combination with other flags: Cannot be combined with any other flag. Implies GPS_READWRITE.</para>
		/// </summary>
		GPS_TEMPORARY = 4,

		/// <summary>Windows 8 and later. Use this flag to retrieve only properties from the indexer for WDS results.</summary>
		GPS_PREFERQUERYPROPERTIES = 0x100,

		/// <summary>Include properties from the file's secondary stream.</summary>
		GPS_EXTRINSICPROPERTIES = 0x200,

		/// <summary>Include only properties from the file's secondary stream.</summary>
		GPS_EXTRINSICPROPERTIESONLY = 0x400,

		/// <summary/>
		GPS_VOLATILEPROPERTIES = 0x800,

		/// <summary/>
		GPS_VOLATILEPROPERTIESONLY = 0x1000,
	}

	/// <summary>Set options for the behavior of the property storage.</summary>
	[PInvokeData("propsys.h")]
	[Flags]
	public enum PERSIST_SPROPSTORE_FLAGS
	{
		/// <summary>Windows 7 and later. The property store object is read/write.</summary>
		FPSPS_DEFAULT = 0x00000000,

		/// <summary>The property store object is read-only.</summary>
		FPSPS_READONLY = 0x00000001,

		/// <summary>
		/// Introduced in Windows 8. New property values that are added to the property store through the IPropertyStore::SetValue
		/// method will cause the IPersistStream::IsDirty method to return S_OK. If this flag is not set, the addition of new property
		/// values to the property store does not affect the value returned by IPersistStream::IsDirty.
		/// </summary>
		FPSPS_TREAT_NEW_VALUES_AS_DIRTY = 0x00000002,
	}

	/// <summary>
	/// <para>Converts the value of a property to the canonical value, according to the property description.</para>
	/// </summary>
	/// <param name="key">
	/// <para>Type: <c>REFPROPERTYKEY</c></para>
	/// <para>Reference to a PROPERTYKEY structure that identifies the property whose value is to be coerced.</para>
	/// </param>
	/// <param name="ppropvar">
	/// <para>Type: <c>PROPVARIANT*</c></para>
	/// <para>
	/// On entry, contains a pointer to a PROPVARIANT structure that contains the original value. When this function returns
	/// successfully, contains the canonical value.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>Possible return values include the following:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>The function succeeded. The property value specified by ppropvar is now in a canonical form.</term>
	/// </item>
	/// <item>
	/// <term>INPLACE_S_TRUNCATED</term>
	/// <term>The property value specified by ppropvar is now in a truncated, canonical form.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>The ppropvar parameter is invalid. The PROPVARIANT structure has been cleared.</term>
	/// </item>
	/// <item>
	/// <term>TYPE_E_TYPEMISMATCH</term>
	/// <term>
	/// Coercion from the value's type to the property description's type was not possible. The PROPVARIANT structure has been cleared.
	/// </term>
	/// </item>
	/// <item>
	/// <term>Any other failure code</term>
	/// <term>
	/// Coercion from the value's type to the property description's type was not possible. The PROPVARIANT structure has been cleared.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>This function is a wrapper around the system's implementation of IPropertyDescription::CoerceToCanonicalValue.</para>
	/// <para>
	/// Most property descriptions specify the type that their values are expected to use. For example, the property description for
	/// System.Title specifies that System.Title values should be of type VT_LPWSTR. This function coerces values to this type, and then
	/// coerces the result into a canonical form.
	/// </para>
	/// <para>
	/// It is important to note that if this function fails, it will have already called PropVariantClear on the input PROPVARIANT
	/// structure. Only if this function succeeds is the calling application responsible for calling <c>PropVariantClear</c> on ppropvar
	/// when the structure is no longer needed.
	/// </para>
	/// <para>
	/// The coercion performed by this function is also performed by the property system during calls to IPropertyStore::GetValue and
	/// IPropertyStore::SetValue. Applications can either depend on the property system to perform the coercions or can use this function
	/// to perform the coercion at a time of the application's choosing.
	/// </para>
	/// <para>The coercion is performed in four steps, as follows:</para>
	/// <list type="number">
	/// <item>
	/// <term>The following values are converted to VT_EMPTY.</term>
	/// </item>
	/// <item>
	/// <term>
	/// If the value is not of type VT_EMPTY after Step 1, it is converted to the type specified by the property description. The type of
	/// a property description can be obtained by calling IPropertyDescription::GetPropertyType. For information on how the property
	/// schema influences the type of a property description, see typeInfo. Conversions are performed as follows:
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// After Steps 2 and 3, the value is coerced into a canonical form based on its type. The canonical forms are summarized in the
	/// following table.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If applicable, the value is checked against the property description type enumeration. The checks in the following table apply.
	/// </term>
	/// </item>
	/// </list>
	/// <para>Examples</para>
	/// <para>
	/// The following example, to be included as part of a larger program, demonstrates how to use PSCoerceToCanonicalValue to coerce a
	/// value to the type required for PKEY_Keywords.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nf-propsys-pscoercetocanonicalvalue PSSTDAPI
	// PSCoerceToCanonicalValue( REFPROPERTYKEY key, PROPVARIANT *ppropvar );
	[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("propsys.h", MSDNShortId = "8225dd01-47cc-451e-b6a6-c16ddf62ca20")]
	public static extern HRESULT PSCoerceToCanonicalValue(in PROPERTYKEY key, PROPVARIANT ppropvar);

	/// <summary>
	/// <para>Creates an adapter from an IPropertyStore.</para>
	/// </summary>
	/// <param name="pps">
	/// <para>Type: <c>IPropertyStore*</c></para>
	/// <para>Pointer to an IPropertyStore object that represents the property store.</para>
	/// </param>
	/// <param name="riid">
	/// <para>Type: <c>REFIID</c></para>
	/// <para>Reference to an IID.</para>
	/// </param>
	/// <param name="ppv">
	/// <para>Type: <c>void**</c></para>
	/// <para>When this function returns, contains the interface pointer requested in riid.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
	/// </returns>
	/// <remarks>
	/// <para>The adapter object implements IPropertySetStorage, IPropertyStore, IPropertyStoreCapabilities, and IObjectProvider.</para>
	/// <para>
	/// Use this function if you need an object that implements IPropertyStore with an API that requires an IPropertySetStorage
	/// interface. The object created can also be useful to a namespace extension that wants to provide support for binding to namespace
	/// items using <c>IPropertySetStorage</c>. Applications must call this object from only one thread at a time.
	/// </para>
	/// <para>
	/// The adapter property store created by this function retains a reference to the source IPropertyStore interface. Therefore, the
	/// calling application is free to release its reference to the source <c>IPropertyStore</c> whenever convenient after calling this function.
	/// </para>
	/// <para>
	/// The adapter property store makes calls to methods on the IPropertyStore interface as appropriate. Therefore, if the calling
	/// application is writing values to the store, it should call the IPropertyStore::Commit method on only one of the interfaces.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following example, to be included as part of a larger program, demonstrates how to use PSCreateAdapterFromPropertyStore to
	/// use an adapter property store to convert an IPropertyStore interface into an IPropertySetStorage interface.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nf-propsys-pscreateadapterfrompropertystore PSSTDAPI
	// PSCreateAdapterFromPropertyStore( IPropertyStore *pps, REFIID riid, void **ppv );
	[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("propsys.h", MSDNShortId = "a3489f95-e790-481a-af6e-f30527dc476c")]
	public static extern HRESULT PSCreateAdapterFromPropertyStore(IPropertyStore pps, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object? ppv);

	/// <summary>
	/// <para>Creates a read-only, delayed-binding property store that contains multiple property stores.</para>
	/// </summary>
	/// <param name="flags">
	/// <para>Type: <c>GETPROPERTYSTOREFLAGS</c></para>
	/// <para>One or more GETPROPERTYSTOREFLAGS values. These values specify details of the created property store object.</para>
	/// </param>
	/// <param name="pdpsf">
	/// <para>Type: <c>IDelayedPropertyStoreFactory*</c></para>
	/// <para>Interface pointer to an instance of IDelayedPropertyStoreFactory.</para>
	/// </param>
	/// <param name="rgStoreIds">
	/// <para>Type: <c>const DWORD*</c></para>
	/// <para>Pointer to an array of property store IDs. This array does not need to be initialized.</para>
	/// </param>
	/// <param name="cStores">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>The number of elements in the array pointed to by rgStoreIds.</para>
	/// </param>
	/// <param name="riid">
	/// <para>Type: <c>REFIID</c></para>
	/// <para>Reference to the requested IID of the interface that will represent the created property store.</para>
	/// </param>
	/// <param name="ppv">
	/// <para>Type: <c>void**</c></para>
	/// <para>When this function returns, contains the interface pointer requested in riid. This is typically IPropertyStore.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function creates a Component Object Model (COM) object that implements IPropertyStore, INamedPropertyStore, IObjectProvider,
	/// and IPropertyStoreCapabilities.
	/// </para>
	/// <para>Applications must call this object from only one thread at a time.</para>
	/// <para>
	/// You must initialize COM with CoInitialize or OleInitialize before you call PSCreateDelayedMultiplexPropertyStore. COM must remain
	/// initialized for the lifetime of this object.
	/// </para>
	/// <para>
	/// PSCreateDelayedMultiplexPropertyStore is designed as an alternative to PSCreateMultiplexPropertyStore, which requires that the
	/// array of property stores be initialized before it creates the multiplex property store.
	/// </para>
	/// <para>
	/// The delayed binding mechanism is designed as a performance enhancement for calls to IPropertyStore::GetValue on a multiplex
	/// property store. When asked for the value of a property, the delayed multiplex property store checks each of the property stores
	/// for the value. After the value is found, there is no need to create and initialize subsequent stores. The delayed multiplex
	/// property store stops searching for a value when one of the property stores returns a success code and a non-VT_EMPTY value.
	/// </para>
	/// <para>
	/// When the delayed multiplex property store needs to access a particular property store, it first checks to see if it has already
	/// obtained an interface to that property store. If not, it calls IDelayedPropertyStoreFactory::GetDelayedPropertyStore with the
	/// appropriate property store ID to obtain the property store. It always uses the property store IDs in the order in which they are
	/// provided by the application. It is possible that not all IDs will be used.
	/// </para>
	/// <para>
	/// If the call to IDelayedPropertyStoreFactory fails with E_NOTIMPL or E_ACCESSDENIED for a particular property store ID, or if the
	/// application specified GPS_BESTEFFORT, then the failure is ignored and the delayed multiplex property store moves on to the next
	/// property store.
	/// </para>
	/// <para>
	/// In some cases, it might be beneficial to use PSCreateDelayedMultiplexPropertyStore in place of PSCreateMultiplexPropertyStore.
	/// For example, if an application needs to multiplex two property stores and the first property store is not memory-intensive to
	/// initialize and provides PKEY_Size information. Often, calling applications ask for a multiplex property store and then ask for
	/// only PKEY_Size before they release the object. In such a case, the application could avoid the cost of initializing the second
	/// property store by calling <c>PSCreateDelayedMultiplexPropertyStore</c> and implementing IDelayedPropertyStoreFactory.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following example, to be included as part of a larger program, demonstrates how to use PSCreateDelayedMultiplexPropertyStore
	/// in an implementation of IPropertyStoreFactory::GetPropertyStore.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nf-propsys-pscreatedelayedmultiplexpropertystore PSSTDAPI
	// PSCreateDelayedMultiplexPropertyStore( GETPROPERTYSTOREFLAGS flags, IDelayedPropertyStoreFactory *pdpsf, const DWORD *rgStoreIds,
	// DWORD cStores, REFIID riid, void **ppv );
	[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("propsys.h", MSDNShortId = "8b264d7e-6124-4724-8d23-605101705893")]
	public static extern HRESULT PSCreateDelayedMultiplexPropertyStore(GETPROPERTYSTOREFLAGS flags, IDelayedPropertyStoreFactory pdpsf,
		[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] uint[] rgStoreIds, uint cStores, in Guid riid,
		out IPropertyStore ppv);

	/// <summary>
	/// <para>Creates an in-memory property store.</para>
	/// </summary>
	/// <param name="riid">
	/// <para>Type: <c>REFIID</c></para>
	/// <para>Reference to the requested interface ID.</para>
	/// </param>
	/// <param name="ppv">
	/// <para>Type: <c>void**</c></para>
	/// <para>When this function returns, contains a pointer to the desired interface, typically IPropertyStore or IPersistSerializedPropStorage.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function creates an in-memory property store object that implements IPropertyStore, INamedPropertyStore,
	/// IPropertyStoreCache, IPersistStream, IPropertyBag, and IPersistSerializedPropStorage.
	/// </para>
	/// <para>
	/// The memory property store does not correspond to a file and is designed for use as a cache. IPropertyStore::Commit is a no-op,
	/// and the data stored in the object persists only as long as the object does.
	/// </para>
	/// <para>
	/// The memory property store is thread safe. It aggregates the free-threaded marshaller and uses critical sections to protect its
	/// data members.
	/// </para>
	/// <para>Examples</para>
	/// <para>The following example, to be included as part of a larger program, demonstrates how to use PSCreateMemoryPropertyStore.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nf-propsys-pscreatememorypropertystore PSSTDAPI
	// PSCreateMemoryPropertyStore( REFIID riid, void **ppv );
	[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("propsys.h", MSDNShortId = "6e7a2ac0-2a4a-41ec-a2a8-ddbe8aa45bc9")]
	public static extern HRESULT PSCreateMemoryPropertyStore(in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)] out object? ppv);

	/// <summary>Creates an in-memory property store.</summary>
	/// <typeparam name="TIntf">The type of the interface.</typeparam>
	/// <returns>The requested interface from <typeparamref name="TIntf"/>, or <see langword="null"/> on failure.</returns>
	/// <remarks>
	/// <para>
	/// This function creates an in-memory property store object that implements IPropertyStore, INamedPropertyStore,
	/// IPropertyStoreCache, IPersistStream, IPropertyBag, and IPersistSerializedPropStorage.
	/// </para>
	/// <para>
	/// The memory property store does not correspond to a file and is designed for use as a cache. IPropertyStore::Commit is a no-op,
	/// and the data stored in the object persists only as long as the object does.
	/// </para>
	/// <para>
	/// The memory property store is thread safe. It aggregates the free-threaded marshaller and uses critical sections to protect its
	/// data members.
	/// </para>
	/// <para>Examples</para>
	/// <para>The following example, to be included as part of a larger program, demonstrates how to use PSCreateMemoryPropertyStore.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nf-propsys-pscreatememorypropertystore PSSTDAPI
	// PSCreateMemoryPropertyStore( REFIID riid, void **ppv );
	[PInvokeData("propsys.h", MSDNShortId = "6e7a2ac0-2a4a-41ec-a2a8-ddbe8aa45bc9")]
	public static TIntf? PSCreateMemoryPropertyStore<TIntf>() where TIntf : class { PSCreateMemoryPropertyStore(out TIntf? ppv).ThrowIfFailed(); return ppv; }

	/// <summary>
	/// <para>
	/// Creates a read-only property store that contains multiple property stores, each of which must support either IPropertyStore or IPropertySetStorage.
	/// </para>
	/// </summary>
	/// <param name="prgpunkStores">
	/// <para>Type: <c>IUnknown**</c></para>
	/// <para>Address of a pointer to an array of property stores that implement either IPropertyStore or IPropertySetStorage.</para>
	/// </param>
	/// <param name="cStores">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>The number of elements in the array referenced in prgpunkStores.</para>
	/// </param>
	/// <param name="riid">
	/// <para>Type: <c>REFIID</c></para>
	/// <para>Reference to the requested IID.</para>
	/// </param>
	/// <param name="ppv">
	/// <para>Type: <c>void**</c></para>
	/// <para>When this function returns, contains the interface pointer requested in riid. This is typically IPropertyStore.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function creates a Component Object Model (COM) object that implements IPropertyStore, INamedPropertyStore, IObjectProvider,
	/// and IPropertyStoreCapabilities. The multiplex property store object aggregates the properties exposed from multiple property stores.
	/// </para>
	/// <para>
	/// This object can be useful for aggregating the properties from multiple existing property store implementations in a Shell
	/// namespace extension, or for reusing an existing property store and providing additional read-only properties.
	/// </para>
	/// <para>Applications must call this object from only one thread at a time.</para>
	/// <para>
	/// You must initialize COM with CoInitialize or OleInitialize before you call PSCreateDelayedMultiplexPropertyStore. COM must remain
	/// initialized for the lifetime of this object.
	/// </para>
	/// <para>
	/// Each of the objects in the array prgpunkStores must implement either IPropertyStore or IPropertySetStorage. If an object
	/// implements <c>IPropertySetStorage</c>, it is wrapped using PSCreatePropertyStoreFromPropertySetStorage for use in the multiplex
	/// property store.
	/// </para>
	/// <para>
	/// The multiplex property store implementation of IPropertyStore::GetValue asks each of the provided property stores for the value.
	/// The multiplex property store stops searching when one of the property stores returns a success code and a non-VT_EMPTY value.
	/// Failure codes cause the search to end and are passed back to the calling application.
	/// </para>
	/// <para>
	/// The multiplex property store implementation of IPropertyStoreCapabilities::IsPropertyWritable delegates the call to the first
	/// store that implements IPropertyStoreCapabilities. If multiple stores implement <c>IPropertyStoreCapabilities</c>, the subsequent
	/// ones are ignored. If no store implements <c>IPropertyStoreCapabilities</c>, this method returns <c>S_OK</c>.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following example, to be included as part of a larger program, demonstrates how to use PSCreateMultiplexPropertyStore in an
	/// implementation of IPropertyStoreFactory::GetPropertyStore.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nf-propsys-pscreatemultiplexpropertystore PSSTDAPI
	// PSCreateMultiplexPropertyStore( IUnknown **prgpunkStores, DWORD cStores, REFIID riid, void **ppv );
	[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("propsys.h", MSDNShortId = "4a6b5a10-5ef2-42c7-bf3b-dfa743be252f")]
	public static extern HRESULT PSCreateMultiplexPropertyStore([In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 1)] object[] prgpunkStores,
		uint cStores, in Guid riid, out IPropertyStore ppv);

	/// <summary>
	/// <para>
	/// Accepts the IUnknown interface of an object that supports IPropertyStore or IPropertySetStorage. If the object supports
	/// <c>IPropertySetStorage</c>, it is wrapped so that it supports <c>IPropertyStore</c>.
	/// </para>
	/// </summary>
	/// <param name="punk">
	/// <para>Type: <c>IUnknown*</c></para>
	/// <para>A pointer to an interface that supports either IPropertyStore or IPropertySetStorage.</para>
	/// </param>
	/// <param name="grfMode">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>Specifies the access mode to use. One of these values:</para>
	/// <para>STGM_READ</para>
	/// <para>Open for reading.</para>
	/// <para>STGM_READWRITE</para>
	/// <para>Open for reading and writing.</para>
	/// </param>
	/// <param name="riid">
	/// <para>Type: <c>REFIID</c></para>
	/// <para>Reference to the requested IID.</para>
	/// </param>
	/// <param name="ppv">
	/// <para>Type: <c>void**</c></para>
	/// <para>When this function returns successfully, contains the address of a pointer to an interface guaranteed to support IPropertyStore.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
	/// </returns>
	/// <remarks>
	/// <para>If the object pointed to by punk already supports IPropertyStore, no wrapper is created and the punk is returned unaltered.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nf-propsys-pscreatepropertystorefromobject PSSTDAPI
	// PSCreatePropertyStoreFromObject( IUnknown *punk, DWORD grfMode, REFIID riid, void **ppv );
	[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("propsys.h", MSDNShortId = "010572d5-0357-4101-803e-0a27fc60ca5e")]
	public static extern HRESULT PSCreatePropertyStoreFromObject([MarshalAs(UnmanagedType.IUnknown)] object punk, STGM grfMode, in Guid riid,
		[MarshalAs(UnmanagedType.Interface)] out IPropertyStore ppv);

	/// <summary>
	/// <para>Wraps an IPropertySetStorage interface in an IPropertyStore interface.</para>
	/// </summary>
	/// <param name="ppss">
	/// <para>Type: <c>IPropertySetStorage*</c></para>
	/// <para>A pointer to an IPropertySetStorage interface.</para>
	/// </param>
	/// <param name="grfMode">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>
	/// Specifies the access mode to enforce. grfMode should match the access mode used to open the IPropertySetStorage. Valid values are
	/// as follows:
	/// </para>
	/// <para>STGM_READ</para>
	/// <para>
	/// Calls to IPropertyStore::SetValueupdate an internal cache of properties, and calls to IPropertyStore::Commitcall the appropriate
	/// IPropertySetStorage methods to write out the changed properties.
	/// </para>
	/// <para>STGM_WRITE</para>
	/// <para>Not supported.</para>
	/// <para>STGM_READWRITE</para>
	/// <para>Not supported.</para>
	/// </param>
	/// <param name="riid">
	/// <para>Type: <c>REFIID</c></para>
	/// <para>Reference to an IID.</para>
	/// </param>
	/// <param name="ppv">
	/// <para>Type: <c>void**</c></para>
	/// <para>When this function returns, contains the interface pointer specified in riid.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function wraps an IPropertySetStorage interface in an IPropertyStore interface. Any value other than <c>STGM_READ</c> for
	/// grfMode, causes calls to IPropertyStore::SetValue and IPropertyStore::Commit to fail with <c>STG_E_ACCESSDENIED.</c>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nf-propsys-pscreatepropertystorefrompropertysetstorage PSSTDAPI
	// PSCreatePropertyStoreFromPropertySetStorage( IPropertySetStorage *ppss, DWORD grfMode, REFIID riid, void **ppv );
	[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("propsys.h", MSDNShortId = "efba5a2a-df26-4f7e-9ddf-ec471e3d547c")]
	public static extern HRESULT PSCreatePropertyStoreFromPropertySetStorage(IPropertySetStorage ppss, STGM grfMode, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 2)] out object? ppv);

	/// <summary>
	/// <para>
	/// A wrapper API that calls the schema subsystem's IPropertySystem::EnumeratePropertyDescriptions. This function retrieves an
	/// instance of the subsystem object that implements IPropertyDescriptionList, to obtain either the entire list or a partial list of
	/// property descriptions in the system.
	/// </para>
	/// </summary>
	/// <param name="filterOn">
	/// <para>Type: <c>PROPDESC_ENUMFILTER</c></para>
	/// <para>The list to return. PROPDESC_ENUMFILTER shows the valid values for this method.</para>
	/// </param>
	/// <param name="riid">
	/// <para>Type: <c>REFIID</c></para>
	/// <para>Reference to the interface ID of the requested interface.</para>
	/// </param>
	/// <param name="ppv">
	/// <para>Type: <c>void**</c></para>
	/// <para>The address of an IPropertyDescriptionList interface pointer.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>PSSTDAPI</c></para>
	/// <para>Returns one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>Indicates an interface is obtained.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>Indicates that ppv is NULL.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// We recommend that you use the IID_PPV_ARGS macro, defined in objbase.h, to package the riid and ppv parameters. This macro
	/// provides the correct IID based on the interface pointed to by the value in ppv, eliminating the possibility of a coding error.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nf-propsys-psenumeratepropertydescriptions PSSTDAPI
	// PSEnumeratePropertyDescriptions( PROPDESC_ENUMFILTER filterOn, REFIID riid, void **ppv );
	[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("propsys.h", MSDNShortId = "687d5a32-3a2e-4b9b-b06c-ca06a6cd1595")]
	public static extern HRESULT PSEnumeratePropertyDescriptions(PROPDESC_ENUMFILTER filterOn, in Guid riid, out IPropertyDescriptionList ppv);

	/// <summary>
	/// <para>
	/// Gets a formatted, Unicode string representation of a property value stored in a PROPVARIANT structure. The caller is responsible
	/// for allocating the output buffer.
	/// </para>
	/// </summary>
	/// <param name="propkey">
	/// <para>Type: <c>REFPROPERTYKEY</c></para>
	/// <para>Reference to a PROPERTYKEY that names the property whose value is being retrieved.</para>
	/// </param>
	/// <param name="propvar">
	/// <para>Type: <c>REFPROPVARIANT</c></para>
	/// <para>Reference to a PROPVARIANT structure that contains the type and value of the property.</para>
	/// </param>
	/// <param name="pdfFlags">
	/// <para>Type: <c>PROPDESC_FORMAT_FLAGS</c></para>
	/// <para>A flag that specifies the format to apply to the property string. See PROPDESC_FORMAT_FLAGS for possible values.</para>
	/// </param>
	/// <param name="pwszText">
	/// <para>Type: <c>LPWSTR</c></para>
	/// <para>
	/// When the function returns, contains a pointer to the formatted value as a null-terminated, Unicode string. The calling
	/// application is responsible for allocating memory for the buffer before it calls PSFormatForDisplay.
	/// </para>
	/// </param>
	/// <param name="cchText">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>Specifies the length of the buffer at pwszText in <c>WCHAR</c><c>s</c>, including the terminating null character.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>Returns one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>The formatted string was successfully created.</term>
	/// </item>
	/// <item>
	/// <term>S_FALSE</term>
	/// <term>The formatted string was not created. S_FALSE indicates that an empty string resulted from a VT_EMPTY.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>Indicates allocation failed.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function calls the schema subsystem's implementation of IPropertySystem::FormatForDisplay. That call provides a Unicode
	/// string representation of a property value, with additional formatting based on one or more PROPDESC_FORMAT_FLAGS. If the
	/// PROPERTYKEY is not recognized by the schema subsystem, <c>IPropertySystem::FormatForDisplay</c> attempts to format the value
	/// according to the value's VARTYPE.
	/// </para>
	/// <para>You must initialize Component Object Model (COM) with CoInitialize or OleInitialize before you call PSFormatPropertyValue.</para>
	/// <para>
	/// The purpose of this function is to convert data into a string suitable for display to the user. The value is formatted according
	/// to the current locale, the language of the user, the PROPDESC_FORMAT_FLAGS, and the property description specified by the
	/// property key. For information on how the property description schema influences the formatting of the value, see the following topics:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>displayInfo</term>
	/// </item>
	/// <item>
	/// <term>stringFormat</term>
	/// </item>
	/// <item>
	/// <term>booleanFormat</term>
	/// </item>
	/// <item>
	/// <term>numberFormat</term>
	/// </item>
	/// <item>
	/// <term>NMDATETIMEFORMAT</term>
	/// </item>
	/// <item>
	/// <term>enumeratedList</term>
	/// </item>
	/// </list>
	/// <para>Typically, the <c>PROPDESC_FORMAT_FLAGS</c> are used to modify the format prescribed by the property description.</para>
	/// <para>
	/// The output string can contain Unicode directional characters. These nonspacing characters influence the Unicode bidirectional
	/// algorithm so that the values appear correctly when a left-to-right (LTR) language is drawn on a right-to-left (RTL) window, or an
	/// RTL is drawn on a LTR window. These characters include the following:
	/// </para>
	/// <para>
	/// The following properties use special formats and are unaffected by the PROPDESC_FORMAT_FLAGS. Note that examples cited are for
	/// strings with a current locale set to English; typically, output is localized except where noted.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Property</term>
	/// <term>Format</term>
	/// </listheader>
	/// <item>
	/// <term>System.FileAttributes</term>
	/// <term>
	/// The following file attributes are converted to letters and appended to create a string (for example, a value of 0x1801 is
	/// converted to "RCO"):
	/// </term>
	/// </item>
	/// <item>
	/// <term/>
	/// <term>FILE_ATTRIBUTE_READONLY- 'R'</term>
	/// </item>
	/// <item>
	/// <term/>
	/// <term>FILE_ATTRIBUTE_SYSTEM - 'S'</term>
	/// </item>
	/// <item>
	/// <term/>
	/// <term>FILE_ATTRIBUTE_ARCHIVE -'A'</term>
	/// </item>
	/// <item>
	/// <term/>
	/// <term>FILE_ATTRIBUTE_COMPRESSED - 'C'</term>
	/// </item>
	/// <item>
	/// <term/>
	/// <term>FILE_ATTRIBUTE_ENCRYPTED - 'E'</term>
	/// </item>
	/// <item>
	/// <term/>
	/// <term>FILE_ATTRIBUTE_OFFLINE - 'O'</term>
	/// </item>
	/// <item>
	/// <term/>
	/// <term>FILE_ATTRIBUTE_NOT_CONTENT_INDEXED - 'I'</term>
	/// </item>
	/// <item>
	/// <term>System.Photo.ISOSpeed</term>
	/// <term>For example, "ISO-400".</term>
	/// </item>
	/// <item>
	/// <term>System.Photo.ShutterSpeed</term>
	/// <term>The APEX value is converted to an exposure time using this formula: For example, "2 sec."or "1/125 sec.".</term>
	/// </item>
	/// <item>
	/// <term>System.Photo.ExposureTime</term>
	/// <term>For example, "2 sec."or "1/125 sec."</term>
	/// </item>
	/// <item>
	/// <term>System.Photo.Aperture</term>
	/// <term>The APEX value is converted to an F number using this formula: For example, "f/5.6".</term>
	/// </item>
	/// <item>
	/// <term>System.Photo.FNumber</term>
	/// <term>For example, "f/5.6".</term>
	/// </item>
	/// <item>
	/// <term>System.Photo.SubjectDistance</term>
	/// <term>For example, "15 m"or "250 mm".</term>
	/// </item>
	/// <item>
	/// <term>System.Photo.FocalLength</term>
	/// <term>For example, "50 mm".</term>
	/// </item>
	/// <item>
	/// <term>System.Photo.FlashEnergy</term>
	/// <term>For example, "500 bpcs".</term>
	/// </item>
	/// <item>
	/// <term>System.Photo.ExposureBias</term>
	/// <term>For example, "-2 step", " 0 step", or "+3 step".</term>
	/// </item>
	/// <item>
	/// <term>System.Computer.DecoratedFreeSpace</term>
	/// <term>For example, "105 MB free of 13.2 GB".</term>
	/// </item>
	/// <item>
	/// <term>System.ItemType</term>
	/// <term>For example, "Application" or "JPEG Image".</term>
	/// </item>
	/// <item>
	/// <term>System.ControlPanel.Category</term>
	/// <term>For example, "Appearance and Personalization".</term>
	/// </item>
	/// <item>
	/// <term>System.ComputerName</term>
	/// <term>For example, "LITWARE05 (this computer)" or "testbox07".</term>
	/// </item>
	/// </list>
	/// <para>
	/// If the property key does not correspond to a property description in any of the registered property schemas, then this function
	/// chooses a format based on the type of the value.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Type of the value</term>
	/// <term>Format</term>
	/// </listheader>
	/// <item>
	/// <term>VT_BOOLEAN</term>
	/// <term>Not supported.</term>
	/// </item>
	/// <item>
	/// <term>VT_FILETIME</term>
	/// <term>
	/// Date/time string as specified by PROPDESC_FORMAT_FLAGS and the current locale. PDFF_SHORTTIME and PDFF_SHORTDATE are the default.
	/// For example, "11/13/2006 3:22 PM".
	/// </term>
	/// </item>
	/// <item>
	/// <term>Numeric VARTYPE</term>
	/// <term>Decimal string in the current locale. For example, "42".</term>
	/// </item>
	/// <item>
	/// <term>VT_LPWSTR or other</term>
	/// <term>Converted to a string. Sequences of "\r", "\t", or "\n" are replaced with a single space.</term>
	/// </item>
	/// <item>
	/// <term>VT_VECTOR | anything</term>
	/// <term>Semicolon separated values. A semicolon is used regardless of locale.</term>
	/// </item>
	/// </list>
	/// <para>Examples</para>
	/// <para>
	/// The following example, to be included as part of a larger program, demonstrates how to use PSFormatForDisplay to format a rating value.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nf-propsys-psformatfordisplay PSSTDAPI PSFormatForDisplay(
	// REFPROPERTYKEY propkey, REFPROPVARIANT propvar, PROPDESC_FORMAT_FLAGS pdfFlags, LPWSTR pwszText, DWORD cchText );
	[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("propsys.h", MSDNShortId = "71442967-ee8a-448c-83cf-949934ddd152")]
	public static extern HRESULT PSFormatForDisplay(in PROPERTYKEY propkey, PROPVARIANT propvar, PROPDESC_FORMAT_FLAGS pdfFlags,
		[MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszText, uint cchText);

	/// <summary>
	/// <para>
	/// Gets a formatted, Unicode string representation of a property value stored in a PROPVARIANT structure. This function allocates
	/// memory for the output string.
	/// </para>
	/// </summary>
	/// <param name="key">
	/// <para>Type: <c>REFPROPERTYKEY</c></para>
	/// <para>Reference to a PROPERTYKEY that names the property whose value is being retrieved.</para>
	/// </param>
	/// <param name="propvar">
	/// <para>Type: <c>REFPROPVARIANT</c></para>
	/// <para>Reference to a PROPVARIANT structure that contains the type and value of the property.</para>
	/// </param>
	/// <param name="pdff">
	/// <para>Type: <c>PROPDESC_FORMAT_FLAGS</c></para>
	/// <para>One or more flags that specify the format to apply to the property string. See PROPDESC_FORMAT_FLAGS for possible values.</para>
	/// </param>
	/// <param name="ppszDisplay">
	/// <para>Type: <c>PWSTR*</c></para>
	/// <para>
	/// When the function returns, contains a pointer to a null-terminated, Unicode string representation of the requested property value.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>Returns one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>
	/// The formatted string was successfully created. S_OK together with an empty return string indicates that there was an empty input
	/// string or a non-empty value that was formatted as an empty string.
	/// </term>
	/// </item>
	/// <item>
	/// <term>S_FALSE</term>
	/// <term>
	/// The formatted string was not created. S_FALSE together with an empty return string indicates that the empty string resulted from
	/// a VT_EMPTY.
	/// </term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>Indicates allocation failed.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function calls the schema subsystem's implementation of IPropertySystem::FormatForDisplayAlloc. That call provides a Unicode
	/// string representation of a property value, with additional formatting based on one or more PROPDESC_FORMAT_FLAGS. If the
	/// PROPERTYKEY is not recognized by the schema subsystem, <c>IPropertySystem::FormatForDisplayAlloc</c> attempts to format the value
	/// according to the value's VARTYPE.
	/// </para>
	/// <para>You must initialize Component Object Model (COM) with CoInitialize or OleInitialize before you call PSFormatForDisplayAlloc.</para>
	/// <para>
	/// The function allocates memory through CoTaskMemAlloc and returns a pointer to that memory through the ppszDisplay parameter. The
	/// calling application must use CoTaskMemFree to release that resource when it is no longer needed.
	/// </para>
	/// <para>
	/// The purpose of this function is to convert data into a string suitable for display to the user. The value is formatted according
	/// to the current locale, the language of the user, the PROPDESC_FORMAT_FLAGS, and the property description specified by the
	/// property key. For information on how the property description schema influences the formatting of the value, see the following topics:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>displayInfo</term>
	/// </item>
	/// <item>
	/// <term>stringFormat</term>
	/// </item>
	/// <item>
	/// <term>booleanFormat</term>
	/// </item>
	/// <item>
	/// <term>numberFormat</term>
	/// </item>
	/// <item>
	/// <term>NMDATETIMEFORMAT</term>
	/// </item>
	/// <item>
	/// <term>enumeratedList</term>
	/// </item>
	/// </list>
	/// <para>Typically, the <c>PROPDESC_FORMAT_FLAGS</c> are used to modify the format prescribed by the property description.</para>
	/// <para>
	/// The output string can contain Unicode directional characters. These nonspacing characters influence the Unicode bidirectional
	/// algorithm so that the values appear correctly when a left-to-right (LTR) language is drawn on a right-to-left (RTL) window, or an
	/// RTL is drawn on a LTR window. These characters include the following:
	/// </para>
	/// <para>
	/// The following properties use special formats and are unaffected by the PROPDESC_FORMAT_FLAGS. Note that examples cited are for
	/// strings with a current locale set to English; typically, output is localized except where noted.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Property</term>
	/// <term>Format</term>
	/// </listheader>
	/// <item>
	/// <term>System.FileAttributes</term>
	/// <term>
	/// The following file attributes are converted to letters and appended to create a string (for example, a value of 0x1801
	/// (FILE_ATTRIBUTE_READONLY | FILE_ATTRIBUTE_COMPRESSED | FILE_ATTRIBUTE_OFFLINE) is converted to "RCO"):
	/// </term>
	/// </item>
	/// <item>
	/// <term>System.Photo.ISOSpeed</term>
	/// <term>For example, "ISO-400".</term>
	/// </item>
	/// <item>
	/// <term>System.Photo.ShutterSpeed</term>
	/// <term>The APEX value is converted to an exposure time using this formula: For example, "2 sec."or "1/125 sec.".</term>
	/// </item>
	/// <item>
	/// <term>System.Photo.ExposureTime</term>
	/// <term>For example, "2 sec."or "1/125 sec."</term>
	/// </item>
	/// <item>
	/// <term>System.Photo.Aperture</term>
	/// <term>The APEX value is converted to an F number using this formula: For example, "f/5.6".</term>
	/// </item>
	/// <item>
	/// <term>System.Photo.FNumber</term>
	/// <term>For example, "f/5.6".</term>
	/// </item>
	/// <item>
	/// <term>System.Photo.SubjectDistance</term>
	/// <term>For example, "15 m"or "250 mm".</term>
	/// </item>
	/// <item>
	/// <term>System.Photo.FocalLength</term>
	/// <term>For example, "50 mm".</term>
	/// </item>
	/// <item>
	/// <term>System.Photo.FlashEnergy</term>
	/// <term>For example, "500 bpcs".</term>
	/// </item>
	/// <item>
	/// <term>System.Photo.ExposureBias</term>
	/// <term>For example, "-2 step", " 0 step", or "+3 step".</term>
	/// </item>
	/// <item>
	/// <term>System.Computer.DecoratedFreeSpace</term>
	/// <term>For example, "105 MB free of 13.2 GB".</term>
	/// </item>
	/// <item>
	/// <term>System.ItemType</term>
	/// <term>For example, "Application" or "JPEG Image".</term>
	/// </item>
	/// <item>
	/// <term>System.ControlPanel.Category</term>
	/// <term>For example, "Appearance and Personalization".</term>
	/// </item>
	/// <item>
	/// <term>System.ComputerName</term>
	/// <term>For example, "LITWARE05 (this computer)" or "testbox07".</term>
	/// </item>
	/// </list>
	/// <para>
	/// If the property key does not correspond to a property description in any of the registered property schemas, then this function
	/// chooses a format based on the type of the value.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Type of the value</term>
	/// <term>Format</term>
	/// </listheader>
	/// <item>
	/// <term>VT_BOOLEAN</term>
	/// <term>Not supported.</term>
	/// </item>
	/// <item>
	/// <term>VT_FILETIME</term>
	/// <term>
	/// Date/time string as specified by PROPDESC_FORMAT_FLAGS and the current locale. PDFF_SHORTTIME and PDFF_SHORTDATE are the default.
	/// For example, "11/13/2006 3:22 PM".
	/// </term>
	/// </item>
	/// <item>
	/// <term>Numeric VARTYPE</term>
	/// <term>Decimal string in the current locale. For example, "42".</term>
	/// </item>
	/// <item>
	/// <term>VT_LPWSTR or other</term>
	/// <term>Converted to a string. Sequences of "\r", "\t", or "\n" are replaced with a single space.</term>
	/// </item>
	/// <item>
	/// <term>VT_VECTOR | anything</term>
	/// <term>Semicolon separated values. A semicolon is used regardless of locale.</term>
	/// </item>
	/// </list>
	/// <para>Examples</para>
	/// <para>
	/// The following example, to be included as part of a larger program, demonstrates how to use PSFormatForDisplayAlloc to format a
	/// rating value.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nf-propsys-psformatfordisplayalloc PSSTDAPI PSFormatForDisplayAlloc(
	// REFPROPERTYKEY key, REFPROPVARIANT propvar, PROPDESC_FORMAT_FLAGS pdff, PWSTR *ppszDisplay );
	[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("propsys.h", MSDNShortId = "d411ea72-fb29-47b6-a7f6-0839b3e2caf2")]
	public static extern HRESULT PSFormatForDisplayAlloc(in PROPERTYKEY key, PROPVARIANT propvar, PROPDESC_FORMAT_FLAGS pdff,
		[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CoTaskMemStringMarshaler))] out string ppszDisplay);

	/// <summary>
	/// <para>
	/// Gets a formatted, Unicode string representation of a property value stored in a property store. This function allocates memory
	/// for the output string.
	/// </para>
	/// </summary>
	/// <param name="pps">
	/// <para>Type: <c>IPropertyStore*</c></para>
	/// <para>Pointer to an IPropertyStore, which represents the property store from which the property value is taken.</para>
	/// </param>
	/// <param name="ppd">
	/// <para>Type: <c>IPropertyDescription*</c></para>
	/// <para>Pointer to an IPropertyDescription, which represents the property whose value is being retrieved.</para>
	/// </param>
	/// <param name="pdff">
	/// <para>Type: <c>PROPDESC_FORMAT_FLAGS</c></para>
	/// <para>
	/// One or more PROPDESC_FORMAT_FLAGS that specify the format to apply to the property string. See <c>PROPDESC_FORMAT_FLAGS</c> for
	/// possible values.
	/// </para>
	/// </param>
	/// <param name="ppszDisplay">
	/// <para>Type: <c>LPWSTR*</c></para>
	/// <para>When the function returns, contains a pointer to the formatted value as a null-terminated, Unicode string.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function uses the ppd parameter to call IPropertyDescription::FormatForDisplay. That call provides a Unicode string
	/// representation of a property value, with additional formatting based on one or more PROPDESC_FORMAT_FLAGS.
	/// </para>
	/// <para>You must initialize Component Object Model (COM) with CoInitialize or OleInitialize before you call PSFormatPropertyValue.</para>
	/// <para>
	/// The function allocates memory and returns a pointer to that memory in ppszDisplay. The calling application must use CoTaskMemFree
	/// to release the string specified by ppszDisplay when it is no longer needed.
	/// </para>
	/// <para>
	/// The purpose of this function is to convert data into a string suitable for display to the user. The value is formatted according
	/// to the current locale, the language of the user, the PROPDESC_FORMAT_FLAGS, and the property description specified by the
	/// property key. For information on how the property description schema influences the formatting of the value, see the following topics:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>displayInfo</term>
	/// </item>
	/// <item>
	/// <term>stringFormat</term>
	/// </item>
	/// <item>
	/// <term>booleanFormat</term>
	/// </item>
	/// <item>
	/// <term>numberFormat</term>
	/// </item>
	/// <item>
	/// <term>NMDATETIMEFORMAT</term>
	/// </item>
	/// <item>
	/// <term>enumeratedList</term>
	/// </item>
	/// </list>
	/// <para>Typically, the <c>PROPDESC_FORMAT_FLAGS</c> are used to modify the format prescribed by the property description.</para>
	/// <para>
	/// The output string can contain Unicode directional characters. These nonspacing characters influence the Unicode bidirectional
	/// algorithm so that the values appear correctly when a left-to-right (LTR) language is drawn on a right-to-left (RTL) window, or an
	/// RTL is drawn on a LTR window. These characters include the following:
	/// </para>
	/// <para>
	/// The following properties use special formats and are unaffected by the PROPDESC_FORMAT_FLAGS. Note that examples cited are for
	/// strings with a current locale set to English; typically, output is localized except where noted.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Property</term>
	/// <term>Format</term>
	/// </listheader>
	/// <item>
	/// <term>System.FileAttributes</term>
	/// <term>
	/// The following file attributes are converted to letters and appended to create a string (for example, a value of 0x1801
	/// (FILE_ATTRIBUTE_READONLY | FILE_ATTRIBUTE_COMPRESSED | FILE_ATTRIBUTE_OFFLINE) is converted to "RCO"):
	/// </term>
	/// </item>
	/// <item>
	/// <term>System.Photo.ISOSpeed</term>
	/// <term>For example, "ISO-400".</term>
	/// </item>
	/// <item>
	/// <term>System.Photo.ShutterSpeed</term>
	/// <term>The APEX value is converted to an exposure time using this formula: For example, "2 sec."or "1/125 sec.".</term>
	/// </item>
	/// <item>
	/// <term>System.Photo.ExposureTime</term>
	/// <term>For example, "2 sec."or "1/125 sec."</term>
	/// </item>
	/// <item>
	/// <term>System.Photo.Aperture</term>
	/// <term>The APEX value is converted to an F number using this formula: For example, "f/5.6".</term>
	/// </item>
	/// <item>
	/// <term>System.Photo.FNumber</term>
	/// <term>For example, "f/5.6".</term>
	/// </item>
	/// <item>
	/// <term>System.Photo.SubjectDistance</term>
	/// <term>For example, "15 m"or "250 mm".</term>
	/// </item>
	/// <item>
	/// <term>System.Photo.FocalLength</term>
	/// <term>For example, "50 mm".</term>
	/// </item>
	/// <item>
	/// <term>System.Photo.FlashEnergy</term>
	/// <term>For example, "500 bpcs".</term>
	/// </item>
	/// <item>
	/// <term>System.Photo.ExposureBias</term>
	/// <term>For example, "-2 step", " 0 step", or "+3 step".</term>
	/// </item>
	/// <item>
	/// <term>System.Computer.DecoratedFreeSpace</term>
	/// <term>For example, "105 MB free of 13.2 GB".</term>
	/// </item>
	/// <item>
	/// <term>System.ItemType</term>
	/// <term>For example, "Application" or "JPEG Image".</term>
	/// </item>
	/// <item>
	/// <term>System.ControlPanel.Category</term>
	/// <term>For example, "Appearance and Personalization".</term>
	/// </item>
	/// <item>
	/// <term>System.ComputerName</term>
	/// <term>For example, "LITWARE05 (this computer)" or "testbox07".</term>
	/// </item>
	/// </list>
	/// <para>
	/// If the property key does not correspond to a property description in any of the registered property schemas, then this function
	/// chooses a format based on the type of the value.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Type of the value</term>
	/// <term>Format</term>
	/// </listheader>
	/// <item>
	/// <term>VT_BOOLEAN</term>
	/// <term>Not supported.</term>
	/// </item>
	/// <item>
	/// <term>VT_FILETIME</term>
	/// <term>
	/// Date/time string as specified by PROPDESC_FORMAT_FLAGS and the current locale. PDFF_SHORTTIME and PDFF_SHORTDATE are the default.
	/// For example, "11/13/2006 3:22 PM".
	/// </term>
	/// </item>
	/// <item>
	/// <term>Numeric VARTYPE</term>
	/// <term>Decimal string in the current locale. For example, "42".</term>
	/// </item>
	/// <item>
	/// <term>VT_LPWSTR or other</term>
	/// <term>Converted to a string. Sequences of "\r", "\t", or "\n" are replaced with a single space.</term>
	/// </item>
	/// <item>
	/// <term>VT_VECTOR | anything</term>
	/// <term>Semicolon separated values. A semicolon is used regardless of locale.</term>
	/// </item>
	/// </list>
	/// <para>Examples</para>
	/// <para>
	/// The following example, to be included as part of a larger program, demonstrates how to use PSFormatPropertyValue to format a
	/// rating value.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nf-propsys-psformatpropertyvalue PSSTDAPI PSFormatPropertyValue(
	// IPropertyStore *pps, IPropertyDescription *ppd, PROPDESC_FORMAT_FLAGS pdff, LPWSTR *ppszDisplay );
	[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("propsys.h", MSDNShortId = "35c2b424-05bd-4d7d-8365-5900e165e2e2")]
	public static extern HRESULT PSFormatPropertyValue(IPropertyStore pps, IPropertyDescription ppd, PROPDESC_FORMAT_FLAGS pdff,
		[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CoTaskMemStringMarshaler))] out string ppszDisplay);

	/// <summary>
	/// <para>Gets an instance of a property description interface for a specified property.</para>
	/// </summary>
	/// <param name="propkey">
	/// <para>Type: <c>REFPROPERTYKEY</c></para>
	/// <para>A reference to a PROPERTYKEY structure that specifies the property.</para>
	/// </param>
	/// <param name="propvar">
	/// <para>Type: <c>REFIID</c></para>
	/// <para>A reference to the IID of the interface to retrieve through ppv.</para>
	/// </param>
	/// <param name="ppszImageRes">
	/// <para>Type: <c>void**</c></para>
	/// <para>When this function returns successfully, contains the interface pointer requested in riid.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>Returns <c>S_OK</c> if successful, or an error value otherwise, including the following:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>TYPE_E_ELEMENTNOTFOUND</term>
	/// <term/>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// We recommend that you use the IID_PPV_ARGS macro, defined in Objbase.h, to package the riid and ppv parameters. This macro
	/// provides the correct IID based on the interface pointed to by the value in ppv, which eliminates the possibility of a coding
	/// error in riid that could lead to unexpected results.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nf-propsys-psgetimagereferenceforvalue PSSTDAPI
	// PSGetImageReferenceForValue( REFPROPERTYKEY propkey, REFPROPVARIANT propvar, PWSTR *ppszImageRes );
	[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("propsys.h", MSDNShortId = "E37AF2ED-E3F9-4e50-9317-9DAF03AC543F")]
	public static extern HRESULT PSGetImageReferenceForValue(in PROPERTYKEY propkey, PROPVARIANT propvar,
		[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CoTaskMemStringMarshaler))] out string ppszImageRes);

	/// <summary>
	/// <para>Retrieves a property handler for a Shell item.</para>
	/// </summary>
	/// <param name="punkItem">
	/// <para>Type: <c>IUnknown*</c></para>
	/// <para>A pointer to the IUnknown interface of a Shell item that supports IShellItem.</para>
	/// <para><c>Windows XP:</c> Use SHCreateShellItem to create the Shell item.</para>
	/// <para>
	/// <c>Windows Vista:</c> Use SHCreateItemFromIDList, SHCreateItemFromParsingName, SHCreateItemFromRelativeName,
	/// SHCreateItemInKnownFolder, or SHCreateItemWithParent to create the Shell item.
	/// </para>
	/// </param>
	/// <param name="fReadWrite">
	/// <para>Type: <c>BOOL</c></para>
	/// <para><c>TRUE</c> to retrieve a read/write property handler. <c>FALSE</c> to retrieve a read-only property handler.</para>
	/// </param>
	/// <param name="riid">
	/// <para>Type: <c>REFIID</c></para>
	/// <para>
	/// Reference to the IID of the interface the handler object should return. This should be IPropertyStore or an interface derived
	/// from <c>IPropertyStore</c>.
	/// </para>
	/// </param>
	/// <param name="ppv">
	/// <para>Type: <c>void**</c></para>
	/// <para>When this function returns, contains the interface pointer requested in riid.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>PSSTDAPI</c></para>
	/// <para>Returns <c>S_OK</c> if successful, or an error value otherwise.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function is supported in Windows XP and Windows Vista. For applications supported only on Windows Vista or later, it is
	/// recommended that you use IShellItem2::GetPropertyStore instead of PSGetItemPropertyHandler. That method provides a richer set of
	/// properties in the property store that is returned.
	/// </para>
	/// <para>This function is approximately equivalent to passing the GPS_HANDLERPROPERTIESONLY flag to IShellItem2::GetPropertyStore.</para>
	/// <para>
	/// You must initialize Component Object Model (COM) with CoInitialize or OleInitialize before you call PSGetItemPropertyHandler. COM
	/// must remain initialized for the lifetime of this object.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following example, to be included as part of a larger program, demonstrates how to use PSGetItemPropertyHandler to obtain a
	/// property handler for an item.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nf-propsys-psgetitempropertyhandler PSSTDAPI
	// PSGetItemPropertyHandler( IUnknown *punkItem, BOOL fReadWrite, REFIID riid, void **ppv );
	[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("propsys.h", MSDNShortId = "7b7fd260-c863-41f7-8594-4ee435090228")]
	public static extern HRESULT PSGetItemPropertyHandler([MarshalAs(UnmanagedType.IUnknown)] object punkItem, [MarshalAs(UnmanagedType.Bool)] bool fReadWrite,
		in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 2)] out object? ppv);

	/// <summary>
	/// <para>Retrieves a property handler for a Shell item.</para>
	/// </summary>
	/// <param name="punkItem">
	/// <para>Type: <c>IUnknown*</c></para>
	/// <para>A pointer to the IUnknown interface of a Shell item that supports IShellItem.</para>
	/// <para><c>Windows XP:</c> Use SHCreateShellItem to create the Shell item.</para>
	/// <para>
	/// <c>Windows Vista:</c> Use SHCreateItemFromIDList, SHCreateItemFromParsingName, SHCreateItemFromRelativeName,
	/// SHCreateItemInKnownFolder, or SHCreateItemWithParent to create the Shell item.
	/// </para>
	/// </param>
	/// <param name="fReadWrite">
	/// <para>Type: <c>BOOL</c></para>
	/// <para><c>TRUE</c> to retrieve a read/write property handler. <c>FALSE</c> to retrieve a read-only property handler.</para>
	/// </param>
	/// <param name="punkCreateObject">
	/// <para>Type: <c>IUnknown*</c></para>
	/// <para>Pointer to the IUnknown interface of a class factory object that supports ICreateObject.</para>
	/// </param>
	/// <param name="riid">
	/// <para>Type: <c>REFIID</c></para>
	/// <para>A reference to the IID of the interface to retrieve through ppv.</para>
	/// </param>
	/// <param name="ppv">
	/// <para>Type: <c>void**</c></para>
	/// <para>
	/// When this function returns successfully, contains the interface pointer requested in riid. This is typically IPropertyStore or IPropertyStoreCapabilities.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>PSSTDAPI</c></para>
	/// <para>Returns <c>S_OK</c> if successful, or an error value otherwise.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function is supported in Windows XP as part of the Microsoft Windows Desktop Search (WDS) redistributable which includes
	/// IPropertyStore and supporting interfaces. For applications supported only on Windows Vista or later, we recommend that you use
	/// IShellItem2::GetPropertyStoreWithCreateObject instead of PSGetItemPropertyHandlerWithCreateObject because
	/// <c>IShellItem2::GetPropertyStoreWithCreateObject</c> provides a richer set of properties in the property store that is returned.
	/// </para>
	/// <para>This function is approximately equivalent to passing the GPS_HANDLERPROPERTIESONLY flag to IShellItem2::GetPropertyStoreWithCreateObject.</para>
	/// <para>
	/// The punkCreateObject parameter enables the creation of a property store in a different context than that of the caller. For
	/// instance, the ICreateObject implementation can cause the property store to be created in another process. This parameter is used
	/// only for property handlers that support it and that are registered under
	/// </para>
	/// <para>
	/// You must initialize Component Object Model (COM) with CoInitialize or OleInitialize before you call
	/// PSGetItemPropertyHandlerWithCreateObject. COM must remain initialized for the lifetime of this object.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following example, to be included as part of a larger program, demonstrates how to use
	/// PSGetItemPropertyHandlerWithCreateObject to obtain a property handler for an item.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nf-propsys-psgetitempropertyhandlerwithcreateobject PSSTDAPI
	// PSGetItemPropertyHandlerWithCreateObject( IUnknown *punkItem, BOOL fReadWrite, IUnknown *punkCreateObject, REFIID riid, void **ppv );
	[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("propsys.h", MSDNShortId = "82e0aa15-b67c-4c0a-bafb-f1dc5f822aec")]
	public static extern HRESULT PSGetItemPropertyHandlerWithCreateObject([MarshalAs(UnmanagedType.IUnknown)] object punkItem, [MarshalAs(UnmanagedType.Bool)] bool fReadWrite,
		[MarshalAs(UnmanagedType.IUnknown)] object punkCreateObject, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 3)] out object? ppv);

	/// <summary>
	/// <para>Gets a value from serialized property storage by property name.</para>
	/// </summary>
	/// <param name="psps">
	/// <para>Type: <c>PCUSERIALIZEDPROPSTORAGE</c></para>
	/// <para>
	/// A pointer to an allocated buffer that contains the serialized properties. Call IPersistSerializedPropStorage::GetPropertyStorage
	/// to obtain the buffer.
	/// </para>
	/// </param>
	/// <param name="cb">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>The size, in bytes, of the USERIALIZESPROPSTORAGE buffer pointed to by psps.</para>
	/// </param>
	/// <param name="pszName">
	/// <para>Type: <c>LPCWSTR</c></para>
	/// <para>A pointer to a null-terminated, Unicode string that contains the name of the property.</para>
	/// </param>
	/// <param name="ppropvar">
	/// <para>Type: <c>PROPVARIANT*</c></para>
	/// <para>When this function returns, contains the requested value.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>PSSTDAPI</c></para>
	/// <para>Returns <c>S_OK</c> if successful, or an error value otherwise.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function is intended to be called if the calling application already has a serialized property storage and needs no more
	/// than a few properties from storage. If many properties need to be retrieved, performance can be enhanced by creating a memory
	/// property store by calling PSCreateMemoryPropertyStore, initializing the property store by calling
	/// IPersistSerializedPropStorage::SetPropertyStorage, and using INamedPropertyStore or IPropertyStore to retrieve the properties.
	/// </para>
	/// <para>
	/// Note that PSGetNamedPropertyFromPropertyStorage works only on serialized buffers created by the system implementation of
	/// IPersistSerializedPropStorage. You must first obtain a memory property store by calling PSCreateMemoryPropertyStore; that store
	/// can then create a serialized buffer using the <c>IPersistSerializedPropStorage</c> interface.
	/// </para>
	/// <para>
	/// Although SERIALIZEDPROPSTORAGE is an opaque serialized data structure whose format may change in the future, earlier formats will
	/// be supported on subsequent versions of Windows. Because the format is opaque, applications should use supported property storage
	/// APIs to access and manipulate the serialized buffer (see IPersistSerializedPropStorage and PSGetPropertyFromPropertyStorage).
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following example, to be included as part of a larger program, demonstrates how to use PSGetNamedPropertyFromPropertyStorage
	/// to read a value from serialized property storage.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nf-propsys-psgetnamedpropertyfrompropertystorage PSSTDAPI
	// PSGetNamedPropertyFromPropertyStorage( PCUSERIALIZEDPROPSTORAGE psps, DWORD cb, LPCWSTR pszName, PROPVARIANT *ppropvar );
	[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("propsys.h", MSDNShortId = "bb4eedc0-9ef5-46f2-83e5-340b77b3d876")]
	public static extern HRESULT PSGetNamedPropertyFromPropertyStorage(IntPtr psps, uint cb, [MarshalAs(UnmanagedType.LPWStr)] string pszName, PROPVARIANT ppropvar);

	/// <summary>Retrieves the property's canonical name given its PROPERTYKEY.</summary>
	/// <param name="propkey">A pointer to a PROPERTYKEY structure containing the property's identifiers.</param>
	/// <param name="ppszCanonicalName">
	/// The address of a pointer to a buffer that receives the property name as a null-terminated Unicode string.
	/// </param>
	/// <returns>The result of the operation. S_OK indicates success.</returns>
	[DllImport(Lib.PropSys, ExactSpelling = true)]
	[PInvokeData("Propsys.h", MSDNShortId = "bb776502")]
	public static extern HRESULT PSGetNameFromPropertyKey(in PROPERTYKEY propkey, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CoTaskMemStringMarshaler))] out string ppszCanonicalName);

	/// <summary>Gets an instance of a property description interface for a property specified by a PROPERTYKEY structure.</summary>
	/// <param name="propkey">Reference to a PROPERTYKEY.</param>
	/// <param name="riid">Reference to the interface ID of the requested interface.</param>
	/// <param name="ppv">
	/// When this function returns, contains the interface pointer requested in riid. This is typically IPropertyDescription,
	/// IPropertyDescriptionAliasInfo, or IPropertyDescriptionSearchInfo.
	/// </param>
	/// <returns>The result of the operation. S_OK indicates success.</returns>
	[DllImport(Lib.PropSys, ExactSpelling = true)]
	[PInvokeData("Propsys.h", MSDNShortId = "bb776503")]
	public static extern HRESULT PSGetPropertyDescription(in PROPERTYKEY propkey, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object? ppv);

	/// <summary>
	/// <para>Gets an instance of a property description interface for a specified property name.</para>
	/// </summary>
	/// <param name="pszCanonicalName">
	/// <para>Type: <c>LPCWSTR</c></para>
	/// <para>A pointer to a null-terminated, Unicode string that identifies the property.</para>
	/// </param>
	/// <param name="riid">
	/// <para>Type: <c>REFIID</c></para>
	/// <para>Reference to the interface ID of the requested property.</para>
	/// </param>
	/// <param name="ppv">
	/// <para>Type: <c>void**</c></para>
	/// <para>
	/// When this function returns, contains the interface pointer requested in riid. This is typically IPropertyDescription,
	/// IPropertyDescriptionAliasInfo, or IPropertyDescriptionSearchInfo.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>PSSTDAPI</c></para>
	/// <para>Returns one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>The interface was obtained.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>The pszCanonicalName parameter is NULL.</term>
	/// </item>
	/// <item>
	/// <term>TYPE_E_ELEMENTNOTFOUND</term>
	/// <term>The canonical name does not exist in the schema subsystem cache.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// It is recommended that you use the IID_PPV_ARGS macro, defined in objbase.h, to package the riid and ppv parameters. This macro
	/// provides the correct IID based on the interface pointed to by the value in ppv, eliminating the possibility of a coding error.
	/// </para>
	/// <para>
	/// We recommend that pszCanonicalName point to the canonical name of a property, for example, . The canonical name is case sensitive.
	/// </para>
	/// <para>
	/// In addition to the new canonical names, callers can pass a legacy name for a property. The following table contains the complete
	/// list of supported legacy names and the canonical names they correspond to.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Property name</term>
	/// <term>Maps to property</term>
	/// </listheader>
	/// <item>
	/// <term>Access</term>
	/// <term>System.DateAccessed</term>
	/// </item>
	/// <item>
	/// <term>Album</term>
	/// <term>System.Music.AlbumTitle</term>
	/// </item>
	/// <item>
	/// <term>AllocSize</term>
	/// <term>System.FileAllocationSize</term>
	/// </item>
	/// <item>
	/// <term>Aperture</term>
	/// <term>System.Photo.Aperture</term>
	/// </item>
	/// <item>
	/// <term>Artist</term>
	/// <term>System.Music.Artist</term>
	/// </item>
	/// <item>
	/// <term>Attrib</term>
	/// <term>System.FileAttributes</term>
	/// </item>
	/// <item>
	/// <term>Attributes</term>
	/// <term>System.FileAttributes</term>
	/// </item>
	/// <item>
	/// <term>AttributesDescription</term>
	/// <term>System.FileAttributesDisplay</term>
	/// </item>
	/// <item>
	/// <term>Audio Format</term>
	/// <term>System.Audio.Format</term>
	/// </item>
	/// <item>
	/// <term>Audio Sample Size</term>
	/// <term>System.Audio.SampleSize</term>
	/// </item>
	/// <item>
	/// <term>BitDepth</term>
	/// <term>System.Image.BitDepth</term>
	/// </item>
	/// <item>
	/// <term>Bitrate</term>
	/// <term>System.Audio.EncodingBitrate</term>
	/// </item>
	/// <item>
	/// <term>CameraModel</term>
	/// <term>System.Photo.CameraModel</term>
	/// </item>
	/// <item>
	/// <term>Capacity</term>
	/// <term>System.Capacity</term>
	/// </item>
	/// <item>
	/// <term>Channels</term>
	/// <term>System.Audio.ChannelCount</term>
	/// </item>
	/// <item>
	/// <term>ColorSpace</term>
	/// <term>System.Image.ColorSpace</term>
	/// </item>
	/// <item>
	/// <term>Company</term>
	/// <term>System.Company</term>
	/// </item>
	/// <item>
	/// <term>Compression</term>
	/// <term>System.Video.Compression</term>
	/// </item>
	/// <item>
	/// <term>Compression</term>
	/// <term>System.Video.Compression</term>
	/// </item>
	/// <item>
	/// <term>Copyright</term>
	/// <term>System.Copyright</term>
	/// </item>
	/// <item>
	/// <term>Copyright</term>
	/// <term>System.Copyright</term>
	/// </item>
	/// <item>
	/// <term>Copyright</term>
	/// <term>System.Image.Copyright</term>
	/// </item>
	/// <item>
	/// <term>Create</term>
	/// <term>System.DateCreated</term>
	/// </item>
	/// <item>
	/// <term>CSCStatus</term>
	/// <term>System.OfflineStatus</term>
	/// </item>
	/// <item>
	/// <term>Data Rate</term>
	/// <term>System.Video.EncodingBitrate</term>
	/// </item>
	/// <item>
	/// <term>DateDeleted</term>
	/// <term>System.Recycle.DateDeleted</term>
	/// </item>
	/// <item>
	/// <term>DeletedFrom</term>
	/// <term>System.Recycle.DeletedFrom</term>
	/// </item>
	/// <item>
	/// <term>Dimensions</term>
	/// <term>System.Image.Dimensions</term>
	/// </item>
	/// <item>
	/// <term>Directory</term>
	/// <term>System.ItemFolderNameDisplay</term>
	/// </item>
	/// <item>
	/// <term>Distance</term>
	/// <term>System.Photo.SubjectDistance</term>
	/// </item>
	/// <item>
	/// <term>DocAppName</term>
	/// <term>System.ApplicationName</term>
	/// </item>
	/// <item>
	/// <term>DocAuthor</term>
	/// <term>System.Author</term>
	/// </item>
	/// <item>
	/// <term>DocByteCount</term>
	/// <term>System.Document.ByteCount</term>
	/// </item>
	/// <item>
	/// <term>DocCategory</term>
	/// <term>System.Category</term>
	/// </item>
	/// <item>
	/// <term>DocCharCount</term>
	/// <term>System.Document.CharacterCount</term>
	/// </item>
	/// <item>
	/// <term>DocComments</term>
	/// <term>System.Comment</term>
	/// </item>
	/// <item>
	/// <term>DocCompany</term>
	/// <term>System.Company</term>
	/// </item>
	/// <item>
	/// <term>DocCreatedTm</term>
	/// <term>System.Document.DateCreated</term>
	/// </item>
	/// <item>
	/// <term>DocEditTime</term>
	/// <term>System.Document.TotalEditingTime</term>
	/// </item>
	/// <item>
	/// <term>DocHiddenCount</term>
	/// <term>System.Document.HiddenSlideCount</term>
	/// </item>
	/// <item>
	/// <term>DocKeywords</term>
	/// <term>System.Keywords</term>
	/// </item>
	/// <item>
	/// <term>DocLastAuthor</term>
	/// <term>System.Document.LastAuthor</term>
	/// </item>
	/// <item>
	/// <term>DocLastPrinted</term>
	/// <term>System.Document.DatePrinted</term>
	/// </item>
	/// <item>
	/// <term>DocLastSavedTm</term>
	/// <term>System.Document.DateSaved</term>
	/// </item>
	/// <item>
	/// <term>DocLineCount</term>
	/// <term>System.Document.LineCount</term>
	/// </item>
	/// <item>
	/// <term>DocManager</term>
	/// <term>System.Document.Manager</term>
	/// </item>
	/// <item>
	/// <term>DocNoteCount</term>
	/// <term>System.Document.NoteCount</term>
	/// </item>
	/// <item>
	/// <term>DocPageCount</term>
	/// <term>System.Document.PageCount</term>
	/// </item>
	/// <item>
	/// <term>DocParaCount</term>
	/// <term>System.Document.ParagraphCount</term>
	/// </item>
	/// <item>
	/// <term>DocPresentationTarget</term>
	/// <term>System.Document.PresentationFormat</term>
	/// </item>
	/// <item>
	/// <term>DocRevNumber</term>
	/// <term>System.Document.RevisionNumber</term>
	/// </item>
	/// <item>
	/// <term>DocSlideCount</term>
	/// <term>System.Document.SlideCount</term>
	/// </item>
	/// <item>
	/// <term>DocSubject</term>
	/// <term>System.Subject</term>
	/// </item>
	/// <item>
	/// <term>DocTemplate</term>
	/// <term>System.Document.Template</term>
	/// </item>
	/// <item>
	/// <term>DocTitle</term>
	/// <term>System.Title</term>
	/// </item>
	/// <item>
	/// <term>DocWordCount</term>
	/// <term>System.Document.WordCount</term>
	/// </item>
	/// <item>
	/// <term>DRM Description</term>
	/// <term>System.DRM.Description</term>
	/// </item>
	/// <item>
	/// <term>Duration</term>
	/// <term>System.Media.Duration</term>
	/// </item>
	/// <item>
	/// <term>EquipMake</term>
	/// <term>System.Photo.CameraManufacturer</term>
	/// </item>
	/// <item>
	/// <term>ExposureBias</term>
	/// <term>System.Photo.ExposureBias</term>
	/// </item>
	/// <item>
	/// <term>ExposureProg</term>
	/// <term>System.Photo.ExposureProgram</term>
	/// </item>
	/// <item>
	/// <term>ExposureTime</term>
	/// <term>System.Photo.ExposureTime</term>
	/// </item>
	/// <item>
	/// <term>FaxCallerID</term>
	/// <term>System.Fax.CallerID</term>
	/// </item>
	/// <item>
	/// <term>FaxCSID</term>
	/// <term>System.Fax.CSID</term>
	/// </item>
	/// <item>
	/// <term>FaxRecipientName</term>
	/// <term>System.Fax.RecipientName</term>
	/// </item>
	/// <item>
	/// <term>FaxRecipientNumber</term>
	/// <term>System.Fax.RecipientNumber</term>
	/// </item>
	/// <item>
	/// <term>FaxRouting</term>
	/// <term>System.Fax.Routing</term>
	/// </item>
	/// <item>
	/// <term>FaxSenderName</term>
	/// <term>System.Fax.SenderName</term>
	/// </item>
	/// <item>
	/// <term>FaxTime</term>
	/// <term>System.Fax.Time</term>
	/// </item>
	/// <item>
	/// <term>FaxTSID</term>
	/// <term>System.Fax.TSID</term>
	/// </item>
	/// <item>
	/// <term>FileDescription</term>
	/// <term>System.FileDescription</term>
	/// </item>
	/// <item>
	/// <term>FileSystem</term>
	/// <term>System.Volume.FileSystem</term>
	/// </item>
	/// <item>
	/// <term>FileType</term>
	/// <term>System.Image.FileType</term>
	/// </item>
	/// <item>
	/// <term>FileVersion</term>
	/// <term>System.FileVersion</term>
	/// </item>
	/// <item>
	/// <term>Flash</term>
	/// <term>System.Photo.Flash</term>
	/// </item>
	/// <item>
	/// <term>FlashEnergy</term>
	/// <term>System.Photo.FlashEnergy</term>
	/// </item>
	/// <item>
	/// <term>FNumber</term>
	/// <term>System.Photo.FNumber</term>
	/// </item>
	/// <item>
	/// <term>FocalLength</term>
	/// <term>System.Photo.FocalLength</term>
	/// </item>
	/// <item>
	/// <term>Frame Rate</term>
	/// <term>System.Video.FrameRate</term>
	/// </item>
	/// <item>
	/// <term>FrameCount</term>
	/// <term>System.Media.FrameCount</term>
	/// </item>
	/// <item>
	/// <term>FreeSpace</term>
	/// <term>System.FreeSpace</term>
	/// </item>
	/// <item>
	/// <term>Genre</term>
	/// <term>System.Music.Genre</term>
	/// </item>
	/// <item>
	/// <term>ImageX</term>
	/// <term>System.Image.HorizontalSize</term>
	/// </item>
	/// <item>
	/// <term>ImageY</term>
	/// <term>System.Image.VerticalSize</term>
	/// </item>
	/// <item>
	/// <term>ISOSpeed</term>
	/// <term>System.Photo.ISOSpeed</term>
	/// </item>
	/// <item>
	/// <term>LightSource</term>
	/// <term>System.Photo.LightSource</term>
	/// </item>
	/// <item>
	/// <term>LinksUpToDate</term>
	/// <term>System.Document.LinksDirty</term>
	/// </item>
	/// <item>
	/// <term>LinkTarget</term>
	/// <term>System.Link.TargetParsingPath</term>
	/// </item>
	/// <item>
	/// <term>Lyrics</term>
	/// <term>System.Music.Lyrics</term>
	/// </item>
	/// <item>
	/// <term>Manager</term>
	/// <term>System.Document.Manager</term>
	/// </item>
	/// <item>
	/// <term>MeteringMode</term>
	/// <term>System.Photo.MeteringMode</term>
	/// </item>
	/// <item>
	/// <term>MMClipCount</term>
	/// <term>System.Document.MultimediaClipCount</term>
	/// </item>
	/// <item>
	/// <term>Name</term>
	/// <term>System.ItemNameDisplay</term>
	/// </item>
	/// <item>
	/// <term>Owner</term>
	/// <term>System.FileOwner</term>
	/// </item>
	/// <item>
	/// <term>Play Count</term>
	/// <term>System.DRM.PlayCount</term>
	/// </item>
	/// <item>
	/// <term>Play Expires</term>
	/// <term>System.DRM.DatePlayExpires</term>
	/// </item>
	/// <item>
	/// <term>Play Starts</term>
	/// <term>System.DRM.DatePlayStarts</term>
	/// </item>
	/// <item>
	/// <term>PresentationTarget</term>
	/// <term>System.Document.PresentationFormat</term>
	/// </item>
	/// <item>
	/// <term>ProductName</term>
	/// <term>System.Software.ProductName</term>
	/// </item>
	/// <item>
	/// <term>ProductVersion</term>
	/// <term>System.Software.ProductVersion</term>
	/// </item>
	/// <item>
	/// <term>Project</term>
	/// <term>System.Media.Project</term>
	/// </item>
	/// <item>
	/// <term>Protected</term>
	/// <term>System.DRM.IsProtected</term>
	/// </item>
	/// <item>
	/// <term>Rank</term>
	/// <term>System.Search.Rank</term>
	/// </item>
	/// <item>
	/// <term>Rating</term>
	/// <term>System.Rating</term>
	/// </item>
	/// <item>
	/// <term>ResolutionX</term>
	/// <term>System.Image.HorizontalResolution</term>
	/// </item>
	/// <item>
	/// <term>ResolutionY</term>
	/// <term>System.Image.VerticalResolution</term>
	/// </item>
	/// <item>
	/// <term>Sample Rate</term>
	/// <term>System.Audio.SampleRate</term>
	/// </item>
	/// <item>
	/// <term>Scale</term>
	/// <term>System.Document.Scale</term>
	/// </item>
	/// <item>
	/// <term>ShutterSpeed</term>
	/// <term>System.Photo.ShutterSpeed</term>
	/// </item>
	/// <item>
	/// <term>Size</term>
	/// <term>System.Size</term>
	/// </item>
	/// <item>
	/// <term>Software</term>
	/// <term>System.SoftwareUsed</term>
	/// </item>
	/// <item>
	/// <term>Status</term>
	/// <term>System.Media.Status</term>
	/// </item>
	/// <item>
	/// <term>Status</term>
	/// <term>System.Status</term>
	/// </item>
	/// <item>
	/// <term>Stream Name</term>
	/// <term>System.Video.StreamName</term>
	/// </item>
	/// <item>
	/// <term>SyncCopyIn</term>
	/// <term>System.Sync.CopyIn</term>
	/// </item>
	/// <item>
	/// <term>Track</term>
	/// <term>System.Music.TrackNumber</term>
	/// </item>
	/// <item>
	/// <term>Type</term>
	/// <term>System.ItemTypeText</term>
	/// </item>
	/// <item>
	/// <term>Video Sample Size</term>
	/// <term>System.Video.SampleSize</term>
	/// </item>
	/// <item>
	/// <term>WhenTaken</term>
	/// <term>System.Photo.DateTaken</term>
	/// </item>
	/// <item>
	/// <term>Write</term>
	/// <term>System.DateModified</term>
	/// </item>
	/// <item>
	/// <term>Year</term>
	/// <term>System.Media.Year</term>
	/// </item>
	/// </list>
	/// <para>Examples</para>
	/// <para>
	/// The following example, to be included as part of a larger program, demonstrates how to use PSGetPropertyDescriptionByName to
	/// retrieve the description for the ratings property.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nf-propsys-psgetpropertydescriptionbyname PSSTDAPI
	// PSGetPropertyDescriptionByName( LPCWSTR pszCanonicalName, REFIID riid, void **ppv );
	[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("propsys.h", MSDNShortId = "181ebbfb-66ed-4763-ad2d-acf3c800f9d2")]
	public static extern HRESULT PSGetPropertyDescriptionByName([MarshalAs(UnmanagedType.LPWStr)] string pszCanonicalName, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object? ppv);

	/// <summary>
	/// <para>Gets an instance of a property description list interface for a specified property list.</para>
	/// </summary>
	/// <param name="pszPropList">
	/// <para>Type: <c>LPCWSTR</c></para>
	/// <para>
	/// Pointer to a null-terminated, Unicode string that identifies the property list. See
	/// IPropertySystem::GetPropertyDescriptionListFromString for more information about the format of this parameter.
	/// </para>
	/// </param>
	/// <param name="riid">
	/// <para>Type: <c>REFIID</c></para>
	/// <para>Reference to the interface ID of the requested interface.</para>
	/// </param>
	/// <param name="ppv">
	/// <para>Type: <c>void**</c></para>
	/// <para>When this function returns, contains the interface pointer requested in riid. This is typically IPropertyDescriptionList.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>PSSTDAPI</c></para>
	/// <para>Returns one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>The interface was obtained.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>The ppv parameter is NULL.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function calls the property subsystem implementation of IPropertySystem::GetPropertyDescriptionListFromString to obtain a
	/// collection of properties provided as a semicolon-delimited property list string.
	/// </para>
	/// <para>
	/// We recommend that you use the <c>IID_PPV_ARGS</c> macro, defined in Objbase.h, to package the riid and ppv parameters. This macro
	/// provides the correct IID based on the interface pointed to by the value in ppv, which eliminates the possibility of a coding error.
	/// </para>
	/// <para>For more information about property schemas, see Property Schemas.</para>
	/// <para>Examples</para>
	/// <para>The following example, to be included as part of a larger program, demonstrates how to use PSGetPropertyDescriptionListFromString.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nf-propsys-psgetpropertydescriptionlistfromstring PSSTDAPI
	// PSGetPropertyDescriptionListFromString( LPCWSTR pszPropList, REFIID riid, void **ppv );
	[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("propsys.h", MSDNShortId = "348253ed-46ac-4643-bbf8-2d286ae97f07")]
	public static extern HRESULT PSGetPropertyDescriptionListFromString([MarshalAs(UnmanagedType.LPWStr)] string pszPropList, in Guid riid, out IPropertyDescriptionList ppv);

	/// <summary>
	/// <para>Gets the value of a property as stored in serialized property storage.</para>
	/// </summary>
	/// <param name="psps">
	/// <para>Type: <c>PCUSERIALIZEDPROPSTORAGE</c></para>
	/// <para>Pointer to an allocated buffer that contains the serialized properties. This buffer is obtained by a call to IPersistSerializedPropStorage::GetPropertyStorage.</para>
	/// </param>
	/// <param name="cb">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>The size, in bytes, of the <c>USERIALIZESPROPSTORAGE</c> buffer pointed to by psps.</para>
	/// </param>
	/// <param name="rpkey">
	/// <para>Type: <c>REFPROPERTYKEY</c></para>
	/// <para>Reference to the PROPERTYKEY that identifies the property for which to get the value.</para>
	/// </param>
	/// <param name="ppropvar">
	/// <para>Type: <c>PROPVARIANT**</c></para>
	/// <para>When this function returns, contains the requested value.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>PSSTDAPI</c></para>
	/// <para>Returns <c>S_OK</c> if successful, or an error value otherwise.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function is intended to be called if the calling application already has a serialized property storage and needs no more
	/// than a few properties from storage. If many properties need to be retrieved, performance can be enhanced by creating a memory
	/// property store through PSCreateMemoryPropertyStore, initializing the property store by calling
	/// IPersistSerializedPropStorage::SetPropertyStorage, and by using IPropertyStore to retrieve the properties.
	/// </para>
	/// <para>
	/// Note that PSGetPropertyFromPropertyStorage works only on serialized buffers created by the system implementation of
	/// IPersistSerializedPropStorage. You must first obtain a memory property store by calling PSCreateMemoryPropertyStore. That store
	/// can then create a serialized buffer using the <c>IPersistSerializedPropStorage</c> interface.
	/// </para>
	/// <para>
	/// Although SERIALIZEDPROPSTORAGE is an opaque serialized data structure whose format may change in the future, earlier formats will
	/// be supported on subsequent versions of Windows. Because the format is opaque, applications should use supported property storage
	/// APIs to access and manipulate the serialized buffer (see IPersistSerializedPropStorage).
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following example, to be included as part of a larger program, demonstrates how to use PSGetPropertyFromPropertyStorage to
	/// read a value from serialized property storage.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nf-propsys-psgetpropertyfrompropertystorage PSSTDAPI
	// PSGetPropertyFromPropertyStorage( PCUSERIALIZEDPROPSTORAGE psps, DWORD cb, REFPROPERTYKEY rpkey, PROPVARIANT *ppropvar );
	[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("propsys.h", MSDNShortId = "c649d25d-7971-4804-a5a2-3fd6860659b4")]
	public static extern HRESULT PSGetPropertyFromPropertyStorage(IntPtr psps, uint cb, in PROPERTYKEY rpkey, PROPVARIANT ppropvar);

	/// <summary>Gets the property key for a canonical property name.</summary>
	/// <param name="pszName">Pointer to a property name as a null-terminated, Unicode string.</param>
	/// <param name="ppropkey">When this function returns, contains the requested property key.</param>
	/// <returns>The result of the operation. S_OK indicates success.</returns>
	[DllImport(Lib.PropSys, ExactSpelling = true)]
	[PInvokeData("Propsys.h", MSDNShortId = "bb762081")]
	public static extern HRESULT PSGetPropertyKeyFromName([MarshalAs(UnmanagedType.LPWStr)] string pszName, out PROPERTYKEY ppropkey);

	/// <summary>
	/// <para>Gets an instance of the subsystem object that implements IPropertySystem.</para>
	/// </summary>
	/// <param name="riid">
	/// <para>Type: <c>REFIID</c></para>
	/// <para>Reference to the IID of the requested interface.</para>
	/// </param>
	/// <param name="ppv">
	/// <para>Type: <c>void**</c></para>
	/// <para>When this function returns, contains the interface pointer requested in riid. This is typically IPropertySystem.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>PSSTDAPI</c></para>
	/// <para>Returns one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>The interface was obtained.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>The ppv parameter is NULL.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// You must initialize Component Object Model (COM) with CoInitialize or OleInitialize prior to calling PSGetPropertySystem. COM
	/// must remain initialized for the lifetime of this object. The property system object aggregates the free-threaded marshaller and
	/// is thread-safe.
	/// </para>
	/// <para>
	/// We recommend that you use the IID_PPV_ARGS macro defined in Objbase.h to package the riid and ppv parameters. This macro provides
	/// the correct IID based on the interface pointed to by the value in ppv, which eliminates the possibility of a coding error.
	/// </para>
	/// <para>Examples</para>
	/// <para>The following example, to be included as part of a larger program, demonstrates how to use PSGetPropertySystem.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nf-propsys-psgetpropertysystem PSSTDAPI PSGetPropertySystem( REFIID
	// riid, void **ppv );
	[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("propsys.h", MSDNShortId = "ddbf7cea-b22f-4cf9-8b5f-804640086466")]
	public static extern HRESULT PSGetPropertySystem(in Guid riid, out IPropertySystem ppv);

	/// <summary>
	/// <para>Gets a property value from a property store.</para>
	/// </summary>
	/// <param name="pps">
	/// <para>Type: <c>IPropertyStore*</c></para>
	/// <para>Pointer to an instance of the IPropertyStore interface, which represents the property store from which to get the value.</para>
	/// </param>
	/// <param name="ppd">
	/// <para>Type: <c>IPropertyDescription*</c></para>
	/// <para>Pointer to an instance of the IPropertyDescription interface, which represents the property in the property store.</para>
	/// </param>
	/// <param name="ppropvar">
	/// <para>Type: <c>PROPVARIANT*</c></para>
	/// <para>Pointer to an uninitialized PROPVARIANT structure. When this function returns, points to the requested property value.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This helper function is used to read a property value from a store. If the calling code already has a PROPERTYKEY structure, it
	/// might be simpler to call IPropertyStore::GetValue directly.
	/// </para>
	/// <para>Examples</para>
	/// <para>The following example, to be included as part of a larger program, demonstrates how to use PSGetPropertyValue.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nf-propsys-psgetpropertyvalue PSSTDAPI PSGetPropertyValue(
	// IPropertyStore *pps, IPropertyDescription *ppd, PROPVARIANT *ppropvar );
	[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("propsys.h", MSDNShortId = "9369dc85-b006-4b30-a25e-58d53b76f334")]
	public static extern HRESULT PSGetPropertyValue(IPropertyStore pps, IPropertyDescription ppd, PROPVARIANT ppropvar);

	/// <summary>
	/// <para>Gets the class identifier (CLSID) of a per-computer, registered file property handler.</para>
	/// </summary>
	/// <param name="pszFilePath">
	/// <para>Type: <c>PCWSTR</c></para>
	/// <para>
	/// Pointer to a null-terminated, Unicode buffer that contains the absolute path of the file whose property handler CLSID is requested.
	/// </para>
	/// </param>
	/// <param name="pclsid">
	/// <para>Type: <c>CLSID*</c></para>
	/// <para>When this function returns, contains the requested property handler CLSID.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>PSSTDAPI</c></para>
	/// <para>Returns <c>S_OK</c> if successful, or an error value otherwise.</para>
	/// </returns>
	/// <remarks>
	/// <para>For information on how to register your handler, see Initializing Property Handlers.</para>
	/// <para>This function returns only those handlers registered under <c>HKEY_LOCAL_MACHINE</c>.</para>
	/// <para>
	/// Most calling applications should not need to call this method or use CoCreateInstance to create a property handler directly.
	/// Instead, calling applications should use IShellItem2::GetPropertyStore to create a property store for a Shell item on Windows
	/// Vista. <c>IShellItem2::GetPropertyStore</c> provides the largest set of available properties for a Shell item, and the most
	/// options for customizing exactly which properties to return.
	/// </para>
	/// <para>
	/// If no property handler is registered for the specified file, this function returns an error code. When this happens, it might
	/// still be possible to read certain file system properties from the property store returned from IShellItem2::GetPropertyStore.
	/// </para>
	/// <para>
	/// Applications that need to create a property handler from code and that must run both on Windows Vista and on Windows XP can call
	/// PSGetItemPropertyHandler to create a property store for a Shell item through the Microsoft Windows Desktop Search (WDS) redistributable.
	/// </para>
	/// <para>Examples</para>
	/// <para>The following example, to be included as part of a larger program, demonstrates how to use PSLookupPropertyHandlerCLSID.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nf-propsys-pslookuppropertyhandlerclsid PSSTDAPI
	// PSLookupPropertyHandlerCLSID( PCWSTR pszFilePath, CLSID *pclsid );
	[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("propsys.h", MSDNShortId = "43f90a33-9bd6-4e47-ab92-5e0d01ba268a")]
	public static extern HRESULT PSLookupPropertyHandlerCLSID([MarshalAs(UnmanagedType.LPWStr)] string pszFilePath, out Guid pclsid);

	/// <summary>
	/// <para>Converts a string to a PROPERTYKEY structure.</para>
	/// </summary>
	/// <param name="pszString">
	/// <para>Type: <c>LPCWSTR</c></para>
	/// <para>Pointer to a null-terminated, Unicode string to be converted.</para>
	/// </param>
	/// <param name="pkey">
	/// <para>Type: <c>PROPERTYKEY*</c></para>
	/// <para>When this function returns, contains a pointer to a PROPERTYKEY structure.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The string to be converted must be formatted as . For instance, the string that corresponds to is: . PSStringFromPropertyKey
	/// outputs strings in this format.
	/// </para>
	/// <para>This function succeeds for any valid property key string, even if the property does not exist in the property schema.</para>
	/// <para>Examples</para>
	/// <para>The following example, to be included as part of a larger program, demonstrates how to use PSPropertyKeyFromString.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nf-propsys-pspropertykeyfromstring PSSTDAPI PSPropertyKeyFromString(
	// LPCWSTR pszString, PROPERTYKEY *pkey );
	[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("propsys.h", MSDNShortId = "9096912a-14ad-4a45-a564-08f98fce3f96")]
	public static extern HRESULT PSPropertyKeyFromString([MarshalAs(UnmanagedType.LPWStr)] string pszString, out PROPERTYKEY pkey);

	/// <summary>
	/// <para>Not supported.</para>
	/// <para>It is valid to call this function, but it is not implemented to perform any function so there is no reason to do so.</para>
	/// </summary>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>Returns one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>Schema files reloaded.</term>
	/// </item>
	/// <item>
	/// <term>E_ACCESSDENIED</term>
	/// <term>The calling context does not have proper privileges.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nf-propsys-psrefreshpropertyschema PSSTDAPI PSRefreshPropertySchema( );
	[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("propsys.h", MSDNShortId = "07efbf66-3594-4b9d-b959-278dc9000572")]
	public static extern HRESULT PSRefreshPropertySchema();

	/// <summary>
	/// <para>Informs the schema subsystem of the addition of a property description schema file.</para>
	/// </summary>
	/// <param name="pszPath">
	/// <para>Type: <c>PCWSTR</c></para>
	/// <para>
	/// Pointer to the full file path, as a Unicode string, to the property description schema (.propdesc) file on the local machine.
	/// This can be either a fully-specified full path, or a full path that includes environment variables such as .
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>Returns one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>All property descriptions in the schema were registered.</term>
	/// </item>
	/// <item>
	/// <term>E_ACCESSDENIED</term>
	/// <term>The calling context does not have proper privileges.</term>
	/// </item>
	/// <item>
	/// <term>INPLACE_S_TRUNCATED</term>
	/// <term>
	/// One or more property descriptions in the schema failed to register. The specific failures are logged in the application event log.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function is a wrapper API for the schema subsystem's implementation of IPropertySystem::RegisterPropertySchema. Call this
	/// function only when the file is first installed on the computer. Typically, a setup application calls this function after it
	/// installs the .propdesc file, which should be stored in the install directory of the application under Program Files. Multiple
	/// calls can be made to <c>IPropertySystem::RegisterPropertySchema</c> in order to register multiple schema files.
	/// </para>
	/// <para>
	/// When registering property schema files, remember that they can be read by processes running as different users. Therefore, it is
	/// important to place a schema file in a location that grants read access to all users on the machine. Similarly, use the absolute
	/// path to the file in this function's pszPath parameter.
	/// </para>
	/// <para>
	/// <c>Note</c> Because schemas are specific to the machine and cannot be registered for each individual user, registering a file
	/// path under user profiles is not supported on Windows Vista.
	/// </para>
	/// <para>
	/// If a full or partial failure is encountered that prevents a property description from being loaded, the cause is recorded in the
	/// application event log. This function fails with E_ACCESSDENIED if the calling context does not have proper privileges, which
	/// includes write access to HKEY_LOCAL_MACHINE. It is the responsibility of the calling application to obtain privileges through
	/// User Account Control (UAC) mechanisms.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nf-propsys-psregisterpropertyschema PSSTDAPI
	// PSRegisterPropertySchema( PCWSTR pszPath );
	[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("propsys.h", MSDNShortId = "ea9c4361-fada-4b07-b450-dd0c6409745a")]
	public static extern HRESULT PSRegisterPropertySchema([MarshalAs(UnmanagedType.LPWStr)] string pszPath);

	/// <summary>
	/// <para>Sets the value of a property in a property store.</para>
	/// </summary>
	/// <param name="pps">
	/// <para>Type: <c>IPropertyStore*</c></para>
	/// <para>Pointer to an instance of the IPropertyStore interface, which represents the property store that contains the property.</para>
	/// </param>
	/// <param name="ppd">
	/// <para>Type: <c>IPropertyDescription*</c></para>
	/// <para>Pointer to an instance of the IPropertyDescription interface, which identifies the individual property.</para>
	/// </param>
	/// <param name="propvar">
	/// <para>Type: <c>REFPROPVARIANT</c></para>
	/// <para>Reference to a PROPVARIANT structure that contains the new value.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This helper function is used to write a property value to a store. If the calling code already has a PROPERTYKEY structure, it
	/// might be simpler to call IPropertyStore::SetValue directly.
	/// </para>
	/// <para>Examples</para>
	/// <para>The following example, to be included as part of a larger program, demonstrates how to use PSSetPropertyValue.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nf-propsys-pssetpropertyvalue PSSTDAPI PSSetPropertyValue(
	// IPropertyStore *pps, IPropertyDescription *ppd, REFPROPVARIANT propvar );
	[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("propsys.h", MSDNShortId = "b4f8c50d-93cd-4371-88b0-6ce58f023981")]
	public static extern HRESULT PSSetPropertyValue(IPropertyStore pps, IPropertyDescription ppd, PROPVARIANT propvar);

	/// <summary>
	/// <para>Creates a string that identifies a property from that property's key.</para>
	/// </summary>
	/// <param name="pkey">
	/// <para>Type: <c>REFPROPERTYKEY</c></para>
	/// <para>Reference to a PROPERTYKEY structure that identifies a property.</para>
	/// </param>
	/// <param name="psz">
	/// <para>Type: <c>LPWSTR</c></para>
	/// <para>Pointer to a buffer that receives the output string. The buffer should be large enough to contain PKEYSTR_MAX <c>WCHAR</c><c>s</c>.</para>
	/// </param>
	/// <param name="cch">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The length of the buffer pointed to by psz, in <c>WCHAR</c><c>s</c>.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
	/// </returns>
	/// <remarks>
	/// <para>The string format retrieved is . For example, the output string for is .</para>
	/// <para>Examples</para>
	/// <para>The following example, to be included as part of a larger program, demonstrates the use of PSPropertyKeyFromString.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nf-propsys-psstringfrompropertykey PSSTDAPI PSStringFromPropertyKey(
	// REFPROPERTYKEY pkey, LPWSTR psz, UINT cch );
	[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("propsys.h", MSDNShortId = "081f8e6d-9189-44f9-9b27-e85f4793da48")]
	public static extern HRESULT PSStringFromPropertyKey(in PROPERTYKEY pkey, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder psz, uint cch);

	/// <summary>
	/// <para>Informs the schema subsystem of the removal of a property description schema file.</para>
	/// </summary>
	/// <param name="pszPath">
	/// <para>Type: <c>PCWSTR</c></para>
	/// <para>
	/// Pointer to the full file path, as a Unicode string, to the property description schema (.propdesc) file on the local machine.
	/// This can be either a fully-specified full path, or a full path that includes environment variables such as .
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>Returns one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>The schema was unregistered.</term>
	/// </item>
	/// <item>
	/// <term>E_ACCESSDENIED</term>
	/// <term>The calling context does not have proper privileges.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function is a wrapper for the schema subsystem's implementation of IPropertySystem::UnregisterPropertySchema. Call this
	/// method when the file is being uninstalled from the computer. Typically, a setup application calls this method before or after
	/// uninstalling the .propdesc file. This method can be called after the file no longer exists.
	/// </para>
	/// <para>
	/// This function fails with a code of E_ACCESSDENIED if the calling context does not have proper privileges, which include write
	/// access to HKLM (HKEY_LOCAL_MACHINE). It is the responsibility of the calling application to obtain privileges through User
	/// Account Control (UAC) mechanisms.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nf-propsys-psunregisterpropertyschema PSSTDAPI
	// PSUnregisterPropertySchema( PCWSTR pszPath );
	[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("propsys.h", MSDNShortId = "57df82a9-8954-4c2b-b794-82ac542149e2")]
	public static extern HRESULT PSUnregisterPropertySchema([MarshalAs(UnmanagedType.LPWStr)] string pszPath);
}