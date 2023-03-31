using System;
using System.Runtime.InteropServices;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.PropSys;

namespace Vanara.PInvoke;

/// <summary>Interfaces and constants from the Function Discovery API.</summary>
// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/fundisc/fd-portal
public static partial class FunDisc
{
	/// <summary>The type of event.</summary>
	[PInvokeData("functiondiscoveryapi.h")]
	public enum FD_EVENTID : uint
	{
		/// <summary/>
		FD_EVENTID_PRIVATE = 100,

		/// <summary/>
		FD_EVENTID = 1000,

		/// <summary>
		/// The search was completed by a provider. Typically, this notification is sent by network protocol providers where the
		/// protocol specifies a defined interval in which search results will be accepted. Both the WSD and SSDP providers use this
		/// event type. Once this notification is sent, a query ignores all incoming responses to the initial search or probe request.
		/// However, the query will still monitor for Hello or Bye messages (used to indicate when a device is added or removed). The
		/// query will continue to monitor for these events until Release is called on the query object. This notification will not be
		/// sent if a catastrophic error occurs. For information about how this event is implemented or used by a specific provider,
		/// follow the link to the provider documentation from the Built-in Providers topic.
		/// </summary>
		FD_EVENTID_SEARCHCOMPLETE = FD_EVENTID,

		/// <summary>Not used by Function Discovery clients.</summary>
		FD_EVENTID_ASYNCTHREADEXIT = FD_EVENTID + 1,

		/// <summary>Not used by Function Discovery clients.</summary>
		FD_EVENTID_SEARCHSTART = FD_EVENTID + 2,

		/// <summary>
		/// The IP address of the NIC changed. The WSD provider implements this notification. Events may be sent when a power event
		/// occurs (for example, when machine wakes from sleep) or when roaming with a laptop.
		/// </summary>
		FD_EVENTID_IPADDRESSCHANGE = FD_EVENTID + 3,

		/// <summary/>
		FD_EVENTID_QUERYREFRESH = FD_EVENTID + 4,
	}

	/// <summary/>
	[PInvokeData("functiondiscoveryapi.h")]
	public enum QueryCategoryType
	{
		/// <summary/>
		QCT_PROVIDER = 0,

		/// <summary/>
		QCT_LAYERED = 1
	}

	/// <summary>
	/// <para>
	/// [Function Discovery is available for use in the operating systems specified in the Requirements section. It may be altered or
	/// unavailable in subsequent versions.]
	/// </para>
	/// <para>
	/// Represents the type of action Function Discovery is performing on the specified function instance. This information is used by
	/// the client program's change notification handler.
	/// </para>
	/// </summary>
	/// <remarks>
	/// When a client program implements the IFunctionDiscoveryNotification interface and passes the address of the interface to one of
	/// the Query methods, Function Discovery calls the client program's IFunctionDiscoveryNotification::OnUpdate method to notify the
	/// client program when a function instance which meets the query parameters has been added, removed, or modified.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/functiondiscoveryapi/ne-functiondiscoveryapi-queryupdateaction typedef enum
	// tagQueryUpdateAction { QUA_ADD, QUA_REMOVE, QUA_CHANGE } QueryUpdateAction;
	[PInvokeData("functiondiscoveryapi.h", MSDNShortId = "NE:functiondiscoveryapi.tagQueryUpdateAction")]
	public enum QueryUpdateAction
	{
		/// <summary>Function Discovery is adding the specified function instance.</summary>
		QUA_ADD,

		/// <summary>Function Discovery is removing the specified function instance.</summary>
		QUA_REMOVE,

		/// <summary>Function Discovery is modifying the specified function instance.</summary>
		QUA_CHANGE,
	}

	/// <summary>
	/// <para>
	/// [Function Discovery is available for use in the operating systems specified in the Requirements section. It may be altered or
	/// unavailable in subsequent versions.]
	/// </para>
	/// <para>Determines the visibility of the function instance's data.</para>
	/// </summary>
	/// <remarks>
	/// All data operations and function instances are stored in HKEY_LOCAL_MACHINE. Access to a function instance or its data with
	/// system-wide visibility must be performed with Administrator access permissions.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/functiondiscoveryapi/ne-functiondiscoveryapi-systemvisibilityflags typedef
	// enum tagSystemVisibilityFlags { SVF_SYSTEM, SVF_USER } SystemVisibilityFlags;
	[PInvokeData("functiondiscoveryapi.h", MSDNShortId = "NE:functiondiscoveryapi.tagSystemVisibilityFlags")]
	public enum SystemVisibilityFlags
	{
		/// <summary>The function instance's data is available to all users on the system.</summary>
		SVF_SYSTEM,

		/// <summary>The function instance's data is accessible only to the current user.</summary>
		SVF_USER,
	}

	/// <summary>
	/// <para>
	/// [Function Discovery is available for use in the operating systems specified in the Requirements section. It may be altered or
	/// unavailable in subsequent versions.]
	/// </para>
	/// <para>
	/// This interface is used by client programs to discover function instances, get the default function instance for a category, and
	/// create advanced Function Discovery query objects that enable registering Function Discovery defaults, among other things.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/functiondiscoveryapi/nn-functiondiscoveryapi-ifunctiondiscovery
	[PInvokeData("functiondiscoveryapi.h", MSDNShortId = "NN:functiondiscoveryapi.IFunctionDiscovery")]
	[ComImport, Guid("4df99b70-e148-4432-b004-4c9eeb535a5e"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(FunctionDiscovery))]
	public interface IFunctionDiscovery
	{
		/// <summary>
		/// <para>
		/// [Function Discovery is available for use in the operating systems specified in the Requirements section. It may be altered
		/// or unavailable in subsequent versions.]
		/// </para>
		/// <para>Gets the specified collection of function instances, based on category and subcategory.</para>
		/// </summary>
		/// <param name="pszCategory">The identifier of the category to be enumerated. See Category Definitions.</param>
		/// <param name="pszSubCategory">
		/// The identifier of the subcategory to be enumerated. See Subcategory Definitions. This parameter can be <c>NULL</c>.
		/// </param>
		/// <param name="fIncludeAllSubCategories">
		/// <para>
		/// If <c>TRUE</c>, this method recursively enumerates all the subcategories of the category specified in pszCategory, returning
		/// a collection containing function instances from all the subcategories of pszCategory.
		/// </para>
		/// <para>
		/// If <c>FALSE</c>, this method restricts itself to returning function instances in the category specified by pszCategory and
		/// the subcategory specified by pszSubCategory.
		/// </para>
		/// </param>
		/// <param name="ppIFunctionInstanceCollection">
		/// A pointer to an IFunctionInstanceCollection interface pointer that receives the function instance collection containing the
		/// requested function instances. The collection is empty if no qualifying function instances are found.
		/// </param>
		/// <returns>
		/// <para>Possible return values include, but are not limited to, the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method completed successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The value of pszCategory is invalid. The value returned in ppIFunctionInstanceCollection parameter is NULL.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>The method is unable to allocate the memory required to perform this operation.</term>
		/// </item>
		/// <item>
		/// <term>HRESULT_FROM_WIN32(ERROR_FILE_NOT_FOUND) 0x80070002</term>
		/// <term>The value of pszCategory or pszSubCategory is unknown.</term>
		/// </item>
		/// <item>
		/// <term>E_PENDING</term>
		/// <term>The call was executed for a provider that returns results asynchronously.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Some function discovery providers return their query results with the IFunctionDiscoveryNotification interface.
		/// <c>GetInstanceCollection</c> does not find function instances that are returned in this way and will fail with E_PENDING. It
		/// is recommended that clients use the CreateInstanceQuery method of the IFunctionDiscovery interface to find function
		/// instances for such providers.
		/// </para>
		/// <para>
		/// If the method succeeds but no function instances were found that matched the query parameters, then <c>S_OK</c> is returned
		/// and ppFunctionInstanceCollection points to an empty collection (the collection's GetCount method returns 0).
		/// </para>
		/// <para>
		/// Subcategory queries are only supported for layered categories and some provider categories. The Registry Provider, the PnP-X
		/// association provider, and the publication provider support subcategory queries. Custom providers can be explicitly designed
		/// to support subcategory queries. For other providers, function instance collections can be filtered using query constraints.
		/// For a list of query constraints, see Constraint Definitions.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following code returns the function instances associated with the SSDP provider in the Microsoft.Networking.Devices namespace.
		/// </para>
		/// <para>
		/// <code>hr = spDisco-&gt;GetInstanceCollection(FCTN_CATEGORY_NETWORKDEVICES, FCTN_SUBCAT_NETWORKDEVICES_SSDP, FALSE, &amp;spFunctionInstanceCollection);</code>
		/// </para>
		/// <para>
		/// See interface constraints on IFunctionInstanceQuery to filter on multiple interfaces at one time or to filter on providers
		/// that do not support subcategory queries.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/functiondiscoveryapi/nf-functiondiscoveryapi-ifunctiondiscovery-getinstancecollection
		// HRESULT GetInstanceCollection( const WCHAR *pszCategory, const WCHAR *pszSubCategory, BOOL fIncludeAllSubCategories,
		// IFunctionInstanceCollection **ppIFunctionInstanceCollection );
		[PreserveSig]
		HRESULT GetInstanceCollection([MarshalAs(UnmanagedType.LPWStr)] string pszCategory, [MarshalAs(UnmanagedType.LPWStr), Optional] string? pszSubCategory,
			[MarshalAs(UnmanagedType.Bool)] bool fIncludeAllSubCategories, out IFunctionInstanceCollection ppIFunctionInstanceCollection);

		/// <summary>
		/// <para>
		/// [Function Discovery is available for use in the operating systems specified in the Requirements section. It may be altered
		/// or unavailable in subsequent versions.]
		/// </para>
		/// <para>Gets the specified function instance, based on identifier.</para>
		/// </summary>
		/// <param name="pszFunctionInstanceIdentity">The identifier of the function instance (see GetID).</param>
		/// <param name="ppIFunctionInstance">A pointer to an IFunctionInstance interface pointer used to return the interface.</param>
		/// <returns>
		/// <para>Possible return values include, but are not limited to, the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method completed successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The value of pszFunctionInstanceIdentity is invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>The method is unable to allocate the memory required to perform this operation.</term>
		/// </item>
		/// <item>
		/// <term>HRESULT_FROM_WIN32(ERROR_OBJECT_NOT_FOUND) 0x800710d8</term>
		/// <term>The function instance represented by the specified ID does not exist on this computer.</term>
		/// </item>
		/// <item>
		/// <term>E_PENDING</term>
		/// <term>The call was executed for a provider that returns results asynchronously.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// Some function discovery providers return their query results with the IFunctionDiscoveryNotification interface.
		/// <c>GetInstance</c> does not find function instances that are returned in this way and will fail with E_PENDING. It is
		/// recommended that clients use the CreateInstanceQuery method of the IFunctionDiscovery interface to find function instances
		/// for such providers.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/functiondiscoveryapi/nf-functiondiscoveryapi-ifunctiondiscovery-getinstance
		// HRESULT GetInstance( const WCHAR *pszFunctionInstanceIdentity, IFunctionInstance **ppIFunctionInstance );
		[PreserveSig]
		HRESULT GetInstance([MarshalAs(UnmanagedType.LPWStr)] string pszFunctionInstanceIdentity, out IFunctionInstance ppIFunctionInstance);

		/// <summary>
		/// <para>
		/// [Function Discovery is available for use in the operating systems specified in the Requirements section. It may be altered
		/// or unavailable in subsequent versions.]
		/// </para>
		/// <para>Creates a query for a collection of specific function instances.</para>
		/// </summary>
		/// <param name="pszCategory">The category for the query. See Category Definitions.</param>
		/// <param name="pszSubCategory">
		/// <para>The subcategory for the query. See Subcategory Definitions. This parameter can be <c>NULL</c>.</para>
		/// <para>
		/// Subcategory queries are only supported for layered categories and some provider categories. The Registry Provider, the PnP-X
		/// association provider, and the publication provider support subcategory queries. Custom providers can be explicitly designed
		/// to support subcategory queries. This means the pszSubCategory parameter should be set to a non- <c>NULL</c> value only when
		/// the pszCategory parameter is set to <c>FCTN_CATEGORY_REGISTRY</c>, <c>FCTN_CATEGORY_PUBLICATION</c>,
		/// <c>FCTN_CATEGORY_PNPXASSOCIATION</c>, or a custom category value defined for either a layered category or a custom provider
		/// supporting subcategory queries.
		/// </para>
		/// </param>
		/// <param name="fIncludeAllSubCategories">
		/// <para>
		/// If <c>TRUE</c>, this method recursively creates a query for all the subcategories of the category specified in pszCategory,
		/// returning a collection containing function instances from all the subcategories of pszCategory.
		/// </para>
		/// <para>
		/// If <c>FALSE</c>, this method restricts the created query to returning function instances in the category specified by
		/// pszCategory and the subcategory specified by pszSubCategory.
		/// </para>
		/// </param>
		/// <param name="pIFunctionDiscoveryNotification">
		/// A pointer to the IFunctionDiscoveryNotification interface implemented by the calling application. This parameter can be
		/// <c>NULL</c>. This pointer is valid until the returned query object is released.
		/// </param>
		/// <param name="pfdqcQueryContext">
		/// A pointer to the context in which the query was created. The type <c>ulong</c> is defined as a DWORDLONG.
		/// </param>
		/// <param name="ppIFunctionInstanceCollectionQuery">A pointer to the IFunctionInstanceCollectionQuery interface pointer.</param>
		/// <returns>
		/// <para>Possible return values include, but are not limited to, the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method completed successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>
		/// The value of pszCategory or pIID is invalid. The value returned in ppIFunctionInstanceCollectionQuery parameter is NULL.
		/// </term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>The method is unable to allocate the memory required to perform this operation.</term>
		/// </item>
		/// <item>
		/// <term>HRESULT_FROM_WIN32(ERROR_FILE_NOT_FOUND) 0x80070002</term>
		/// <term>The value of pszCategory or pszSubCategory is unknown.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If pIFunctionDiscoveryNotification is specified, it enables the Function Discovery change notification process. This
		/// parameter can be <c>NULL</c>. However, it is required for network providers since they do not return synchronous results.
		/// Function Discovery network providers only return instances through the IFunctionDiscoveryNotification interface.
		/// </para>
		/// <para>
		/// This method only initializes the query call. The Execute method of the IFunctionInstanceCollectionQuery interface returned
		/// in ppIFunctionInstanceCollectionQuery must be called to perform the query and return any data.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/functiondiscoveryapi/nf-functiondiscoveryapi-ifunctiondiscovery-createinstancecollectionquery
		// HRESULT CreateInstanceCollectionQuery( const WCHAR *pszCategory, const WCHAR *pszSubCategory, BOOL fIncludeAllSubCategories,
		// IFunctionDiscoveryNotification *pIFunctionDiscoveryNotification, ulong *pfdqcQueryContext, IFunctionInstanceCollectionQuery
		// **ppIFunctionInstanceCollectionQuery );
		[PreserveSig]
		HRESULT CreateInstanceCollectionQuery([MarshalAs(UnmanagedType.LPWStr)] string pszCategory,
			[MarshalAs(UnmanagedType.LPWStr), Optional] string? pszSubCategory,
			[MarshalAs(UnmanagedType.Bool)] bool fIncludeAllSubCategories,
			IFunctionDiscoveryNotification pIFunctionDiscoveryNotification, ref ulong pfdqcQueryContext,
			out IFunctionInstanceCollectionQuery ppIFunctionInstanceCollectionQuery);

		/// <summary>
		/// <para>
		/// [Function Discovery is available for use in the operating systems specified in the Requirements section. It may be altered
		/// or unavailable in subsequent versions.]
		/// </para>
		/// <para>Creates a query for a specific function instance.</para>
		/// </summary>
		/// <param name="pszFunctionInstanceIdentity">The identifier of the function instance.</param>
		/// <param name="pIFunctionDiscoveryNotification">
		/// A pointer to the IFunctionDiscoveryNotification interface implemented by the calling application. If specified, it enables
		/// the Function Discovery change notification process. This parameter can be <c>NULL</c>; however it is required for network providers.
		/// </param>
		/// <param name="pfdqcQueryContext">
		/// A pointer to the context in which the query was created. The type <c>ulong</c> is defined as a DWORDLONG.
		/// </param>
		/// <param name="ppIFunctionInstanceQuery">
		/// A pointer to an IFunctionInstanceQuery interface pointer used to return the generated query.
		/// </param>
		/// <returns>
		/// <para>Possible return values include, but are not limited to, the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method completed successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>ppIFunctionInstanceQuery is NULL.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>The method is unable to allocate the memory required to perform this operation.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Function Discovery Network providers only return instances through the IFunctionDiscoveryNotification interface.</para>
		/// <para>
		/// This method only initializes the query call. The Execute method of the IFunctionInstanceQuery interface returned in
		/// ppIFunctionInstanceQuery must be called to perform the query and return any data.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/functiondiscoveryapi/nf-functiondiscoveryapi-ifunctiondiscovery-createinstancequery
		// HRESULT CreateInstanceQuery( const WCHAR *pszFunctionInstanceIdentity, IFunctionDiscoveryNotification
		// *pIFunctionDiscoveryNotification, ulong *pfdqcQueryContext, IFunctionInstanceQuery **ppIFunctionInstanceQuery );
		[PreserveSig]
		HRESULT CreateInstanceQuery([MarshalAs(UnmanagedType.LPWStr)] string pszFunctionInstanceIdentity,
			IFunctionDiscoveryNotification pIFunctionDiscoveryNotification, ref ulong pfdqcQueryContext,
			out IFunctionInstanceQuery ppIFunctionInstanceQuery);

		/// <summary>
		/// <para>
		/// [Function Discovery is available for use in the operating systems specified in the Requirements section. It may be altered
		/// or unavailable in subsequent versions.]
		/// </para>
		/// <para>Creates or modifies a function instance.</para>
		/// </summary>
		/// <param name="enumSystemVisibility">
		/// <para>
		/// A SystemVisibilityFlags value that specifies whether the created function instance is visible system wide or only to the
		/// current user.
		/// </para>
		/// <para>
		/// <c>Note</c> The function instance is stored in HKEY_LOCAL_MACHINE regardless of the enumSystemVisibility value. The user
		/// must have Administrator access to add a function instance.
		/// </para>
		/// </param>
		/// <param name="pszCategory">The category of the created function instance. See Category Definitions.</param>
		/// <param name="pszSubCategory">
		/// The subcategory of the created function instance. See Subcategory Definitions. The maximum length of this string is MAX_PATH.
		/// </param>
		/// <param name="pszCategoryIdentity">The provider instance identifier string. This string is returned from GetProviderInstanceID.</param>
		/// <param name="ppIFunctionInstance">A pointer to an IFunctionInstance interface pointer that receives the function instance.</param>
		/// <returns>
		/// <para>Possible return values include, but are not limited to, the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method completed successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The value of enumSystemVisibility, pszCategory, or pszCategoryIdentity is invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>The method is unable to allocate the memory required to perform this operation.</term>
		/// </item>
		/// <item>
		/// <term>E_ACCESSDENIED</term>
		/// <term>The user has insufficient access permission to perform the requested action.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>The provider does not support adding function instances directly using the AddInstance method.</term>
		/// </item>
		/// <item>
		/// <term>HRESULT_FROM_WIN32(ERROR_FILE_NOT_FOUND) 0x80070002</term>
		/// <term>The value of pszCategory or pszSubCategory is unknown.</term>
		/// </item>
		/// <item>
		/// <term>STRSAFE_E_INVALID_PARAMETER</term>
		/// <term>An invalid parameter was specified. This error is returned when the length of the pszSubCategory string exceeds MAX_PATH.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method temporarily creates a new function instance for the specified category and subcategory. The provider that
		/// implements the category is responsible for persisting the metadata associated with the newly created function instance using
		/// the IFunctionDiscoveryProviderFactory::CreateInstance method.
		/// </para>
		/// <para>
		/// The function instance is not written to the registry if its associated property store does not have any values. Use the
		/// IFunctionInstance::OpenPropertyStore method to check the property store values.
		/// </para>
		/// <para>
		/// If a function instance already exists for the specified category and subcategory, the existing registry entry is
		/// overwritten. The <c>AddInstance</c> method returns S_OK. The Function Discovery change notification process invokes the
		/// calling application's IFunctionDiscoveryNotification::OnUpdate method with enumQueryUpdateAction set to <c>QUA_CHANGE</c>.
		/// </para>
		/// <para><c>Note</c> The IFunctionDiscoveryNotification::OnUpdate method is not supported by any current provider.</para>
		/// <para>
		/// Whether the new function instance is capable of being visible system-wide or only to the user depends on the provider. The
		/// registry provider initially sets its default function instance visibility to system wide.
		/// </para>
		/// <para>
		/// Access permission to change HKEY_LOCAL_MACHINE\SYSTEM registry keys is required in order to add or remove function instances
		/// using the registry provider (Administrator or Power User access).
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/functiondiscoveryapi/nf-functiondiscoveryapi-ifunctiondiscovery-addinstance
		// HRESULT AddInstance( SystemVisibilityFlags enumSystemVisibility, const WCHAR *pszCategory, const WCHAR *pszSubCategory, const
		// WCHAR *pszCategoryIdentity, IFunctionInstance **ppIFunctionInstance );
		[PreserveSig]
		HRESULT AddInstance(SystemVisibilityFlags enumSystemVisibility, [MarshalAs(UnmanagedType.LPWStr)] string pszCategory,
			[MarshalAs(UnmanagedType.LPWStr), Optional] string? pszSubCategory,
			[MarshalAs(UnmanagedType.LPWStr)] string pszCategoryIdentity, out IFunctionInstance ppIFunctionInstance);

		/// <summary>
		/// <para>
		/// [Function Discovery is available for use in the operating systems specified in the Requirements section. It may be altered
		/// or unavailable in subsequent versions.]
		/// </para>
		/// <para>Removes the specified function instance, based on category and subcategory.</para>
		/// </summary>
		/// <param name="enumSystemVisibility">
		/// A SystemVisibilityFlags value that specifies whether the function instance is removed system-wide or only for the current user.
		/// </param>
		/// <param name="pszCategory">The category of the function instance. See Category Definitions.</param>
		/// <param name="pszSubCategory">
		/// The subcategory of the function instance to be removed. See Subcategory Definitions. This parameter can be <c>NULL</c>.
		/// </param>
		/// <param name="pszCategoryIdentity">The provider instance identifier string. This string is returned from GetProviderInstanceID.</param>
		/// <returns>
		/// <para>Possible return values include, but are not limited to, the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method completed successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The value of pszCategoryIdentity is invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>The method is unable to allocate the memory required to perform this operation.</term>
		/// </item>
		/// <item>
		/// <term>E_ACCESSDENIED</term>
		/// <term>The user has insufficient access permission to perform the requested action.</term>
		/// </item>
		/// <item>
		/// <term>HRESULT_FROM_WIN32(ERROR_FILE_NOT_FOUND) 0x80070002</term>
		/// <term>The value of pszCategory or pszSubCategory is unknown.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Access permission to change HKEY_LOCAL_MACHINE\SYSTEM registry keys is required in order to add or remove function instances
		/// using the registry provider (Administrator or Power User access levels). The user must have Administrator access to remove a
		/// function instance system-wide.
		/// </para>
		/// <para><c>Note</c> This method is not supported by all providers.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/functiondiscoveryapi/nf-functiondiscoveryapi-ifunctiondiscovery-removeinstance
		// HRESULT RemoveInstance( SystemVisibilityFlags enumSystemVisibility, const WCHAR *pszCategory, const WCHAR *pszSubCategory,
		// const WCHAR *pszCategoryIdentity );
		[PreserveSig]
		HRESULT RemoveInstance(SystemVisibilityFlags enumSystemVisibility, [MarshalAs(UnmanagedType.LPWStr)] string pszCategory,
			[MarshalAs(UnmanagedType.LPWStr), Optional] string? pszSubCategory,
			[MarshalAs(UnmanagedType.LPWStr)] string pszCategoryIdentity);
	}

	/// <summary>
	/// <para>
	/// [Function Discovery is available for use in the operating systems specified in the Requirements section. It may be altered or
	/// unavailable in subsequent versions.]
	/// </para>
	/// <para>
	/// This interface is implemented by the client program to support asynchronous queries and is called by Function Discovery to
	/// notify the client program when a function instance that meets the query parameters has been added or removed.
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// This interface must be implemented by the client program in order to receive notifications from Function Discovery. The address
	/// of the client program's implementation is passed to one of the query methods to enable notifications for function instances
	/// which meet the query parameters.
	/// </para>
	/// <para>
	/// Function Discovery calls the client program's IFunctionDiscoveryNotification::OnUpdate method to perform the actual
	/// notification, which is generated for a function instance when it is added or removed.
	/// </para>
	/// <para>Examples</para>
	/// <para>The examples that appear on individual method pages are based on the following class declaration.</para>
	/// <para>
	/// <code>class CMyNotificationListener : public CFunctionDiscoveryNotificationWrapper { public: CMyNotificationListener() { m_hAddEvent = CreateEvent( NULL, FALSE, FALSE, NULL ); m_hRemoveEvent = CreateEvent( NULL, FALSE, FALSE, NULL ); m_hChangeEvent = CreateEvent( NULL, FALSE, FALSE, NULL ); } ~CMyNotificationListener() { CloseHandle( m_hAddEvent ); CloseHandle( m_hRemoveEvent ); CloseHandle( m_hChangeEvent ); } private: HANDLE m_hAddEvent, m_hRemoveEvent, m_hChangeEvent; };</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/functiondiscoveryapi/nn-functiondiscoveryapi-ifunctiondiscoverynotification
	[PInvokeData("functiondiscoveryapi.h", MSDNShortId = "NN:functiondiscoveryapi.IFunctionDiscoveryNotification")]
	[ComImport, Guid("5f6c1ba8-5330-422e-a368-572b244d3f87"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IFunctionDiscoveryNotification
	{
		/// <summary>
		/// <para>
		/// [Function Discovery is available for use in the operating systems specified in the Requirements section. It may be altered
		/// or unavailable in subsequent versions.]
		/// </para>
		/// <para>
		/// Indicates that a function instance has been added, removed, or changed. This method is implemented by the client program and
		/// is called by Function Discovery.
		/// </para>
		/// </summary>
		/// <param name="enumQueryUpdateAction">
		/// A QueryUpdateAction value that specifies the type of action Function Discovery is performing on the specified function instance.
		/// </param>
		/// <param name="fdqcQueryContext">
		/// The context registered for change notification. The type <c>ulong</c> is defined as a DWORDLONG. This parameter can be <c>NULL</c>.
		/// </param>
		/// <param name="pIFunctionInstance">
		/// An IFunctionInstance interface pointer that represents the function instance being affected by the update.
		/// </param>
		/// <returns>
		/// <para>
		/// The client program's implementation of the <c>OnUpdate</c> method should return one of the following <c>HRESULT</c> values
		/// to the caller.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method completed successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The value of one of the input parameters is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Do not call <c>Release</c> on the query object from this method. Doing so could cause a deadlock. If <c>Release</c> is
		/// called on a query object from another thread while a callback is in process, the object will not be released until the
		/// callback has finished.
		/// </para>
		/// <para>
		/// All notifications passed to Function Discovery by providers are queued and returned to the client one by one. Callbacks are
		/// synchronized so that a client will only receive one notification at a time.
		/// </para>
		/// <para>
		/// Because other IFunctionDiscoveryNotification method calls may be made in other threads, any changes made to the thread state
		/// during the call must be restored before exiting the method.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following code shows an OnUpdate handler implementation. The <c>CMyNotificationListener</c> class is defined in the
		/// IFunctionDiscoveryNotification topic.
		/// </para>
		/// <para>
		/// <code>#include &lt;windows.h&gt; HRESULT STDMETHODCALLTYPE CMyNotificationListener::OnUpdate( IN QueryUpdateAction Action, IN ulong fdqcQueryContext, IN IFunctionInstance *pInstance) { HRESULT hr = S_OK; switch (Action) { case QUA_ADD: SetEvent( m_hAddEvent ); break; case QUA_REMOVE: SetEvent( m_hRemoveEvent ); break; case QUA_CHANGE: SetEvent( m_hChangeEvent ); break; } return S_OK; }</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/functiondiscoveryapi/nf-functiondiscoveryapi-ifunctiondiscoverynotification-onupdate
		// HRESULT OnUpdate( QueryUpdateAction enumQueryUpdateAction, ulong fdqcQueryContext, IFunctionInstance *pIFunctionInstance );
		[PreserveSig]
		HRESULT OnUpdate(QueryUpdateAction enumQueryUpdateAction, ulong fdqcQueryContext, IFunctionInstance pIFunctionInstance);

		/// <summary>
		/// <para>
		/// [Function Discovery is available for use in the operating systems specified in the Requirements section. It may be altered
		/// or unavailable in subsequent versions.]
		/// </para>
		/// <para>Receives errors that occur during asynchronous query processing.</para>
		/// </summary>
		/// <param name="hr">The query error that is being reported.</param>
		/// <param name="fdqcQueryContext">
		/// The context registered for change notification. The type <c>FDQUERYCONTEXT</c> is defined as a DWORDLONG.
		/// </param>
		/// <param name="pszProvider">The name of the provider.</param>
		/// <returns>
		/// <para>
		/// The client program's implementation of the <c>OnError</c> method should return one of the following <c>HRESULT</c> values to
		/// the caller.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method completed successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The value of one of the input parameters is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Typically, clients will expect that any asynchronous error is fatal and that the query will stop returning results, but
		/// custom provider documentation could indicate otherwise for specific error codes.
		/// </para>
		/// <para>
		/// Do not call <c>Release</c> on the query object from this method. Doing so could cause a deadlock. If <c>Release</c> is
		/// called on a query object from another thread while a callback is in process, the object will not be released until the
		/// callback has finished.
		/// </para>
		/// <para>
		/// All notifications passed to Function Discovery by providers are queued and returned to the client one by one. Callbacks are
		/// synchronized so that a client will only receive one notification at a time.
		/// </para>
		/// <para>
		/// Because other IFunctionDiscoveryNotification method calls may be made in other threads, any changes made to the thread state
		/// during the call must be restored before exiting the method.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/functiondiscoveryapi/nf-functiondiscoveryapi-ifunctiondiscoverynotification-onerror
		// HRESULT OnError( HRESULT hr, FDQUERYCONTEXT fdqcQueryContext, const WCHAR *pszProvider );
		[PreserveSig]
		HRESULT OnError(HRESULT hr, ulong fdqcQueryContext, [MarshalAs(UnmanagedType.LPWStr)] string pszProvider);

		/// <summary>
		/// <para>
		/// [Function Discovery is available for use in the operating systems specified in the Requirements section. It may be altered
		/// or unavailable in subsequent versions.]
		/// </para>
		/// <para>Receives any add, remove, or update events during a notification.</para>
		/// </summary>
		/// <param name="dwEventID">
		/// <para>The type of event.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>FD_EVENTID_SEARCHCOMPLETE 1000</term>
		/// <term>
		/// The search was completed by a provider. Typically, this notification is sent by network protocol providers where the
		/// protocol specifies a defined interval in which search results will be accepted. Both the WSD and SSDP providers use this
		/// event type. Once this notification is sent, a query ignores all incoming responses to the initial search or probe request.
		/// However, the query will still monitor for Hello or Bye messages (used to indicate when a device is added or removed). The
		/// query will continue to monitor for these events until Release is called on the query object. This notification will not be
		/// sent if a catastrophic error occurs. For information about how this event is implemented or used by a specific provider,
		/// follow the link to the provider documentation from the Built-in Providers topic.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FD_EVENTID_ASYNCTHREADEXIT 1001</term>
		/// <term>Not used by Function Discovery clients.</term>
		/// </item>
		/// <item>
		/// <term>FD_EVENTID_SEARCHSTART 1002</term>
		/// <term>Not used by Function Discovery clients.</term>
		/// </item>
		/// <item>
		/// <term>FD_EVENTID_IPADDRESSCHANGE 1003</term>
		/// <term>
		/// The IP address of the NIC changed. The WSD provider implements this notification. Events may be sent when a power event
		/// occurs (for example, when machine wakes from sleep) or when roaming with a laptop.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="fdqcQueryContext">
		/// The context registered for change notification. The type <c>FDQUERYCONTEXT</c> is defined as a <c>DWORDLONG</c>. This
		/// parameter can be <c>NULL</c>.
		/// </param>
		/// <param name="pszProvider">The name of the provider.</param>
		/// <returns>
		/// <para>
		/// The client program's implementation of the <c>OnEvent</c> method should return one of the following <c>HRESULT</c> values to
		/// the caller.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method completed successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The value of one of the input parameters is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Function Discovery providers (SSDP and WSD) use this method to implement notifications that a search pass is complete.</para>
		/// <para>
		/// Do not call <c>Release</c> on the query object from this method. Doing so could cause a deadlock. If <c>Release</c> is
		/// called on a query object from another thread while a callback is in process, the object will not be released until the
		/// callback has finished.
		/// </para>
		/// <para>
		/// All notifications passed to Function Discovery by providers are queued and returned to the client one by one. Callbacks are
		/// synchronized so that a client will only receive one notification at a time.
		/// </para>
		/// <para>
		/// Because other IFunctionDiscoveryNotification method calls may be made in other threads, any changes made to the thread state
		/// during the call must be restored before exiting the method.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following example shows an OnEvent handler implementation. The <c>CMyNotificationListener</c> class is defined in the
		/// IFunctionDiscoveryNotification topic.
		/// </para>
		/// <para>
		/// <code>#include &lt;windows.h&gt; HRESULT CMyNotificationListener::OnEvent( IN DWORD dwEventID, IN FDQUERYCONTEXT fdqcQueryContext, IN const WCHAR * pszProvider ) { HRESULT hr = S_OK; HANDLE hSearchComplete = INVALID_HANDLE_VALUE; hSearchComplete = OpenEventW( EVENT_ALL_ACCESS, FALSE, L"SearchComplete" ); if( NULL == hSearchComplete ) { return hr; } if( FD_EVENTID_SEARCHCOMPLETE == dwEventID ) { SetEvent( hSearchComplete ); } CloseHandle( hSearchComplete ); return hr; }</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/functiondiscoveryapi/nf-functiondiscoveryapi-ifunctiondiscoverynotification-onevent
		// HRESULT OnEvent( DWORD dwEventID, FDQUERYCONTEXT fdqcQueryContext, const WCHAR *pszProvider );
		[PreserveSig]
		HRESULT OnEvent(FD_EVENTID dwEventID, ulong fdqcQueryContext, [MarshalAs(UnmanagedType.LPWStr)] string pszProvider);
	}

	/// <summary>
	/// <para>
	/// [Function Discovery is available for use in the operating systems specified in the Requirements section. It may be altered or
	/// unavailable in subsequent versions.]
	/// </para>
	/// <para>
	/// A function instance is created as the result of calling one of the IFunctionDiscovery methods; client program do not create
	/// these objects themselves.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/functiondiscoveryapi/nn-functiondiscoveryapi-ifunctioninstance
	[PInvokeData("functiondiscoveryapi.h", MSDNShortId = "NN:functiondiscoveryapi.IFunctionInstance")]
	[ComImport, Guid("33591c10-0bed-4f02-b0ab-1530d5533ee9"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IFunctionInstance
	{
		/// <summary>Performs as a factory for services that are exposed through an implementation of IServiceProvider.</summary>
		/// <param name="guidService">A unique identifier of the requested service.</param>
		/// <param name="riid">A unique identifier of the interface which the caller wishes to receive for the service.</param>
		/// <param name="ppvObject">The interface specified by the <paramref name="riid"/> parameter.</param>
		/// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[PreserveSig]
		HRESULT QueryService(in Guid guidService, in Guid riid, [MarshalAs(UnmanagedType.Interface, IidParameterIndex = 1)] out object ppvObject);

		/// <summary>
		/// <para>
		/// [Function Discovery is available for use in the operating systems specified in the Requirements section. It may be altered
		/// or unavailable in subsequent versions.]
		/// </para>
		/// <para>
		/// Gets the identifier string for the function instance. This identifier can be saved and later used to re-query for the same
		/// function instance through IFunctionDiscovery::GetInstance.
		/// </para>
		/// </summary>
		/// <param name="ppszCoMemIdentity">
		/// <para>The function instance identifier string. There is no upper limit on the size of this string.</para>
		/// <para>
		/// This string is a composed string generated by Function Discovery. It has the provider instance identifier string as a
		/// substring. For more information about provider identifiers, see IFunctionInstance::GetProviderInstanceID.
		/// </para>
		/// <para>
		/// For function instances returned by a built-in provider, this identifier is guaranteed to uniquely identify a resource on a
		/// system, even if the resource is disconnected and reconnected. For function instances returned by custom providers, the
		/// function instance identifier is unique if the provider has a unique provider identifier.
		/// </para>
		/// <para>
		/// This identifier should not be manipulated or manufactured programmatically. The string should only be used to retrieve
		/// function instances and for comparison purposes.
		/// </para>
		/// <para>Be sure to free this buffer using CoTaskMemFree.</para>
		/// </param>
		/// <returns>
		/// <para>Possible return values include, but are not limited to, the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method completed successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The value of ppszCoMemID is invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>The method is unable to allocate the memory required to perform this operation.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/functiondiscoveryapi/nf-functiondiscoveryapi-ifunctioninstance-getid
		// HRESULT GetID( WCHAR **ppszCoMemIdentity );
		[PreserveSig]
		HRESULT GetID([MarshalAs(UnmanagedType.LPWStr)] out string ppszCoMemIdentity);

		/// <summary>
		/// <para>
		/// [Function Discovery is available for use in the operating systems specified in the Requirements section. It may be altered
		/// or unavailable in subsequent versions.]
		/// </para>
		/// <para>Gets the identifier string for the provider instance. This string is the unique identifier for the provider instance.</para>
		/// </summary>
		/// <param name="ppszCoMemProviderInstanceIdentity">
		/// <para>The provider instance identifier string. For root devices, this string has the same value as PKEY_PNPX_GlobalIdentity.</para>
		/// <para>Be sure to free this buffer using CoTaskMemFree.</para>
		/// </param>
		/// <returns>
		/// <para>Possible return values include, but are not limited to, the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method completed successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The value of ppszCoMemProviderInstanceID is invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>The method is unable to allocate the memory required to perform this operation.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/functiondiscoveryapi/nf-functiondiscoveryapi-ifunctioninstance-getproviderinstanceid
		// HRESULT GetProviderInstanceID( WCHAR **ppszCoMemProviderInstanceIdentity );
		[PreserveSig]
		HRESULT GetProviderInstanceID([MarshalAs(UnmanagedType.LPWStr)] out string ppszCoMemProviderInstanceIdentity);

		/// <summary>
		/// <para>
		/// [Function Discovery is available for use in the operating systems specified in the Requirements section. It may be altered
		/// or unavailable in subsequent versions.]
		/// </para>
		/// <para>
		/// Opens the property store for the function instance. The property store contains metadata about the function instance, such
		/// as its name, icon, installation date, and other information.
		/// </para>
		/// </summary>
		/// <param name="dwStgAccess">
		/// <para>The access mode to be assigned to the open stream. For this method, the following access modes are supported:</para>
		/// <para>STGM_READ</para>
		/// <para>STGM_READWRITE</para>
		/// <para>STGM_WRITE</para>
		/// </param>
		/// <param name="ppIPropertyStore">A pointer to an IPropertyStore interface pointer.</param>
		/// <returns>
		/// <para>Possible return values include, but are not limited to, the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method completed successfully.</term>
		/// </item>
		/// <item>
		/// <term>STG_E_ACCESSDENIED</term>
		/// <term>
		/// The method could not open a writeable property store because the caller has insufficient access or the discovery provider
		/// does not allow write access to its property store.
		/// </term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The value of dwStgAccess is invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>The ppIPropertyStore points to invalid memory.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>The method is unable to allocate the memory required to perform this operation.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Only one property store per function instance can be open at a time. If <c>OpenPropertyStore</c> is called twice on the same
		/// function instance, both ppIPropertyStore pointers would point to the same property store. Furthermore, the access mode (as
		/// specified by the dwStgAccess parameter) would be determined by the most recent <c>OpenPropertyStore</c> call. Applications
		/// should call <c>Release</c> to close a property store before opening another.
		/// </para>
		/// <para>
		/// It is possible that <c>OpenPropertyStore</c> will return a property store for a device that has been removed. In this case,
		/// the property keys in the store will be empty. This situation may occur if the device's devnode was deleted but the property
		/// store associated with the device's function instance is still accessible. This situation occurs rarely.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/functiondiscoveryapi/nf-functiondiscoveryapi-ifunctioninstance-openpropertystore
		// HRESULT OpenPropertyStore( DWORD dwStgAccess, IPropertyStore **ppIPropertyStore );
		[PreserveSig]
		HRESULT OpenPropertyStore(STGM dwStgAccess, out IPropertyStore ppIPropertyStore);

		/// <summary>
		/// <para>
		/// [Function Discovery is available for use in the operating systems specified in the Requirements section. It may be altered
		/// or unavailable in subsequent versions.]
		/// </para>
		/// <para>Gets the category and subcategory strings for the function instance.</para>
		/// </summary>
		/// <param name="ppszCoMemCategory">
		/// <para>The null-terminated identifier string of the category. See Category Definitions.</para>
		/// <para>Be sure to free this buffer using CoTaskMemFree.</para>
		/// </param>
		/// <param name="ppszCoMemSubCategory">The null-terminated identifier string of the subcategory. See Subcategory Definitions.</param>
		/// <returns>
		/// <para>Possible return values include, but are not limited to, the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method completed successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>The method is unable to allocate the memory required to perform this operation.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// The category and subcategory of a function instance always refer to the provider category from which a function instance comes.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/functiondiscoveryapi/nf-functiondiscoveryapi-ifunctioninstance-getcategory
		// HRESULT GetCategory( WCHAR **ppszCoMemCategory, WCHAR **ppszCoMemSubCategory );
		[PreserveSig]
		HRESULT GetCategory([MarshalAs(UnmanagedType.LPWStr)] out string ppszCoMemCategory, [MarshalAs(UnmanagedType.LPWStr)] out string ppszCoMemSubCategory);
	}

	/// <summary>
	/// <para>
	/// [Function Discovery is available for use in the operating systems specified in the Requirements section. It may be altered or
	/// unavailable in subsequent versions.]
	/// </para>
	/// <para>
	/// This interface represents a group of IFunctionInstance objects returned as the result of a query or get instance request through
	/// one of the IFunctionDiscovery methods; client program do not create these collections themselves.
	/// </para>
	/// </summary>
	/// <remarks>
	/// The <c>IFunctionInstanceCollection</c> interface allows a client program to enumerate a collection of IFunctionInstance objects.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/functiondiscoveryapi/nn-functiondiscoveryapi-ifunctioninstancecollection
	[PInvokeData("functiondiscoveryapi.h", MSDNShortId = "NN:functiondiscoveryapi.IFunctionInstanceCollection")]
	[ComImport, Guid("f0a3d895-855c-42a2-948d-2f97d450ecb1"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(FunctionInstanceCollection))]
	public interface IFunctionInstanceCollection
	{
		/// <summary>
		/// <para>
		/// [Function Discovery is available for use in the operating systems specified in the Requirements section. It may be altered
		/// or unavailable in subsequent versions.]
		/// </para>
		/// <para>Gets the number of function instances in the collection.</para>
		/// </summary>
		/// <param name="pdwCount">The number of function instances.</param>
		/// <returns>
		/// <para>Possible return values include, but are not limited to, the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method completed successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The pdwCount parameter is NULL.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// The <c>GetCount</c> and Item methods enables you to enumerate all of the function instances contained in a collection using
		/// a simple <c>for</c> or <c>while</c> loop.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/functiondiscoveryapi/nf-functiondiscoveryapi-ifunctioninstancecollection-getcount
		// HRESULT GetCount( DWORD *pdwCount );
		[PreserveSig]
		HRESULT GetCount(out uint pdwCount);

		/// <summary>
		/// <para>
		/// [Function Discovery is available for use in the operating systems specified in the Requirements section. It may be altered
		/// or unavailable in subsequent versions.]
		/// </para>
		/// <para>Gets the specified function instance and its index from the collection.</para>
		/// </summary>
		/// <param name="pszInstanceIdentity">The identifier of the function instance to be retrieved (see GetID).</param>
		/// <param name="pdwIndex">The index number.</param>
		/// <param name="ppIFunctionInstance">A pointer to an IFunctionInstance interface pointer that receives the function instance.</param>
		/// <returns>
		/// <para>Possible return values include, but are not limited to, the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method completed successfully.</term>
		/// </item>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>The function instance identified by pInstanceIdentity is not present in the function instance collection.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The value of pdwIndex or pInstanceIdentity is invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>The method is unable to allocate the memory required to perform this operation.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/functiondiscoveryapi/nf-functiondiscoveryapi-ifunctioninstancecollection-get
		// HRESULT Get( const WCHAR *pszInstanceIdentity, DWORD *pdwIndex, IFunctionInstance **ppIFunctionInstance );
		[PreserveSig]
		HRESULT Get([MarshalAs(UnmanagedType.LPWStr)] string pszInstanceIdentity, out uint pdwIndex, out IFunctionInstance ppIFunctionInstance);

		/// <summary>
		/// <para>
		/// [Function Discovery is available for use in the operating systems specified in the Requirements section. It may be altered
		/// or unavailable in subsequent versions.]
		/// </para>
		/// <para>Gets the specified function instance, by index.</para>
		/// </summary>
		/// <param name="dwIndex">The zero-based index of the function instance to be retrieved.</param>
		/// <param name="ppIFunctionInstance">A pointer to an IFunctionInstance interface pointer that receives the function instance.</param>
		/// <returns>
		/// <para>Possible return values include, but are not limited to, the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method completed successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The ppFunctionInstance parameter is NULL or dwIndex is out of range.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// The GetCount and <c>Item</c> methods enables you to enumerate all of the function instances contained in a collection using
		/// a simple <c>for</c> or <c>while</c> loop.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/functiondiscoveryapi/nf-functiondiscoveryapi-ifunctioninstancecollection-item
		// HRESULT Item( DWORD dwIndex, IFunctionInstance **ppIFunctionInstance );
		[PreserveSig]
		HRESULT Item(uint dwIndex, out IFunctionInstance ppIFunctionInstance);

		/// <summary>
		/// <para>
		/// [Function Discovery is available for use in the operating systems specified in the Requirements section. It may be altered
		/// or unavailable in subsequent versions.]
		/// </para>
		/// <para>Adds a function instance to the collection.</para>
		/// </summary>
		/// <param name="pIFunctionInstance">
		/// A pointer to an IFunctionInstance interface for the function instance to be added to the collection.
		/// </param>
		/// <returns>
		/// <para>Possible return values include, but are not limited to, the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method completed successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The value of pIFunctionInstance is invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>The method is unable to allocate the memory required to perform this operation.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/functiondiscoveryapi/nf-functiondiscoveryapi-ifunctioninstancecollection-add
		// HRESULT Add( IFunctionInstance *pIFunctionInstance );
		[PreserveSig]
		HRESULT Add(IFunctionInstance pIFunctionInstance);

		/// <summary>
		/// <para>
		/// [Function Discovery is available for use in the operating systems specified in the Requirements section. It may be altered
		/// or unavailable in subsequent versions.]
		/// </para>
		/// <para>Deletes the specified function instance and returns a pointer to the function instance being removed.</para>
		/// </summary>
		/// <param name="dwIndex">The index number within the collection.</param>
		/// <param name="ppIFunctionInstance">A pointer to an IFunctionInstance interface pointer that receives the function instance.</param>
		/// <returns>
		/// <para>Possible return values include, but are not limited to, the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method completed successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The value of dwIndex is invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>The method is unable to allocate the memory required to perform this operation.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/functiondiscoveryapi/nf-functiondiscoveryapi-ifunctioninstancecollection-remove
		// HRESULT Remove( DWORD dwIndex, IFunctionInstance **ppIFunctionInstance );
		[PreserveSig]
		HRESULT Remove(uint dwIndex, out IFunctionInstance ppIFunctionInstance);

		/// <summary>
		/// <para>
		/// [Function Discovery is available for use in the operating systems specified in the Requirements section. It may be altered
		/// or unavailable in subsequent versions.]
		/// </para>
		/// <para>Removes the specified function instance from the collection.</para>
		/// </summary>
		/// <param name="dwIndex">The index number of the item to be removed from the collection.</param>
		/// <returns>
		/// <para>Possible return values include, but are not limited to, the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method completed successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The value of dwIndex is invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>The method is unable to allocate the memory required to perform this operation.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/functiondiscoveryapi/nf-functiondiscoveryapi-ifunctioninstancecollection-delete
		// HRESULT Delete( DWORD dwIndex );
		[PreserveSig]
		HRESULT Delete(uint dwIndex);

		/// <summary>
		/// <para>
		/// [Function Discovery is available for use in the operating systems specified in the Requirements section. It may be altered
		/// or unavailable in subsequent versions.]
		/// </para>
		/// <para>Removes all function instances from the collection.</para>
		/// </summary>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/functiondiscoveryapi/nf-functiondiscoveryapi-ifunctioninstancecollection-deleteall
		// HRESULT DeleteAll();
		[PreserveSig]
		HRESULT DeleteAll();
	}

	/// <summary>
	/// <para>
	/// [Function Discovery is available for use in the operating systems specified in the Requirements section. It may be altered or
	/// unavailable in subsequent versions.]
	/// </para>
	/// <para>
	/// This interface implements the asynchronous query for a collection of function instances based on category and subcategory. A
	/// pointer to this interface is returned when the collection query is created by the client program.
	/// </para>
	/// </summary>
	/// <remarks>The Execute method must be invoked by the client program before any data can be retrieved from the query object.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/functiondiscoveryapi/nn-functiondiscoveryapi-ifunctioninstancecollectionquery
	[PInvokeData("functiondiscoveryapi.h", MSDNShortId = "NN:functiondiscoveryapi.IFunctionInstanceCollectionQuery")]
	[ComImport, Guid("57cc6fd2-c09a-4289-bb72-25f04142058e"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IFunctionInstanceCollectionQuery
	{
		/// <summary>
		/// <para>
		/// [Function Discovery is available for use in the operating systems specified in the Requirements section. It may be altered
		/// or unavailable in subsequent versions.]
		/// </para>
		/// <para>The <c>AddQueryConstraint</c> method adds a query constraint to the query.</para>
		/// <para>This method enables the application to filter the result set to only those instances that fulfill this constraint.</para>
		/// </summary>
		/// <param name="pszConstraintName">The query constraint.</param>
		/// <param name="pszConstraintValue">The constraint value.</param>
		/// <returns>
		/// <para>Possible return values include, but are not limited to, the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method completed successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>The method is unable to allocate the memory required to perform this operation.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>If multiple constraints are added, all constraints must be supported to satisfy the query.</para>
		/// <para>
		/// <c>AddQueryConstraint</c> will fail with an error if the IFunctionInstanceCollectionQuery object includes all subcategories
		/// and the <c>AddQueryConstraint</c> method is called with the pszConstraintName parameter set to
		/// <c>FD_QUERYCONSTRAINT_PROVIDERINSTANCEID</c>. To avoid this error, create a <c>IFunctionInstanceCollectionQuery</c> object
		/// that does not include all subcategories. You can create such an object by calling CreateInstanceCollectionQuery with the
		/// fIncludeAllSubCategories parameter set to <c>false</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/functiondiscoveryapi/nf-functiondiscoveryapi-ifunctioninstancecollectionquery-addqueryconstraint
		// HRESULT AddQueryConstraint( const WCHAR *pszConstraintName, const WCHAR *pszConstraintValue );
		[PreserveSig]
		HRESULT AddQueryConstraint([MarshalAs(UnmanagedType.LPWStr)] string pszConstraintName, [MarshalAs(UnmanagedType.LPWStr)] string pszConstraintValue);

		/// <summary>
		/// <para>
		/// [Function Discovery is available for use in the operating systems specified in the Requirements section. It may be altered
		/// or unavailable in subsequent versions.]
		/// </para>
		/// <para>Adds a property constraint to the query.</para>
		/// <para>This method limits query results to only function instances with a property key (PKEY) matching the specified constraint.</para>
		/// </summary>
		/// <param name="Key">The property key (PKEY) for the constraint. For more information about PKEYs, see Key Definitions.</param>
		/// <param name="pv">
		/// <para>A <c>PROPVARIANT</c> used for the constraint. This type must match the PROPVARIANT type associated with Key.</para>
		/// <para>
		/// The following shows possible values. Note that only a subset of the PROPVARIANT types supported by the built-in providers
		/// can be used as a property constraint.
		/// </para>
		/// <para>VT_BOOL</para>
		/// <para>VT_I2</para>
		/// <para>VT_I4</para>
		/// <para>VT_I8</para>
		/// <para>VT_INT</para>
		/// <para>VT_LPWSTR</para>
		/// <para>VT_LPWSTR|VT_VECTOR</para>
		/// <para>VT_UI2</para>
		/// <para>VT_UI4</para>
		/// <para>VT_UI8</para>
		/// <para>VT_UINT</para>
		/// </param>
		/// <param name="enumPropertyConstraint">
		/// A PropertyConstraint value that specifies the type of comparison to use when comparing the constraint's PKEY to the function
		/// instance's PKEY.
		/// </param>
		/// <returns>
		/// <para>Possible return values include, but are not limited to, the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method completed successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>The method is unable to allocate the memory required to perform this operation.</term>
		/// </item>
		/// <item>
		/// <term>HRESULT_FROM_WIN32(ERROR_NOT_SUPPORTED)</term>
		/// <term>
		/// The constraint specified for the query is not supported. Either the constraint is not supported for a specific VARENUM type,
		/// or the VARENUM type is not supported at all.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A function instance will only match a property constraint when the PROPVARIANT type of the function instance's PKEY matches
		/// the PROPVARIANT type of the constraint's PKEY and the function instance's PKEY value matches the constraint's PKEY value
		/// using the comparison operator specified by enumPropertyConstraint.
		/// </para>
		/// <para>If multiple constraints are added, all constraints must be supported to satisfy the query.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/functiondiscoveryapi/nf-functiondiscoveryapi-ifunctioninstancecollectionquery-addpropertyconstraint
		// HRESULT AddPropertyConstraint( REFPROPERTYKEY Key, const PROPVARIANT *pv, PropertyConstraint enumPropertyConstraint );
		[PreserveSig]
		HRESULT AddPropertyConstraint(in PROPERTYKEY Key, PROPVARIANT pv, PropertyConstraint enumPropertyConstraint);

		/// <summary>
		/// <para>
		/// [Function Discovery is available for use in the operating systems specified in the Requirements section. It may be altered
		/// or unavailable in subsequent versions.]
		/// </para>
		/// <para>Performs the query defined by IFunctionDiscovery::CreateInstanceCollectionQuery.</para>
		/// </summary>
		/// <param name="ppIFunctionInstanceCollection">
		/// A pointer to an IFunctionInstanceCollection interface pointer that receives the requested function instance collection.
		/// </param>
		/// <returns>
		/// <para>Possible return values include, but are not limited to, the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method completed successfully. Results are returned synchronously in ppIFunctonInstanceCollecton.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>The method is unable to allocate the memory required to perform this operation.</term>
		/// </item>
		/// <item>
		/// <term>E_PENDING</term>
		/// <term>Some of the results will be returned by asynchronous notification. See the remarks for details.</term>
		/// </item>
		/// </list>
		/// <para>
		/// A predefined query is a query of a layered category. When a predefined query is executed, each provider that returns a
		/// function instance also returns an HRESULT value. The provider HRESULT values are aggregated, and the value returned by the
		/// <c>Execute</c> method reflects these aggregate results. Results are aggregated as follows:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>If all providers return <c>S_OK</c>, <c>Execute</c> returns <c>S_OK</c>.</term>
		/// </item>
		/// <item>
		/// <term>
		/// If at least one provider returns <c>E_PENDING</c>, and all other providers return either <c>S_OK</c> or <c>E_PENDING</c>,
		/// <c>Execute</c> returns <c>E_PENDING</c>.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// If all providers return an error value (that is, a value other than <c>S_OK</c> or <c>E_PENDING</c>), <c>Execute</c> returns
		/// the error value returned by the network provider that was last queried. Also, if the client's IFunctionDiscoveryNotification
		/// callback routine was provided to IFunctionDiscovery::CreateInstanceCollectionQuery, an OnError notification is sent for each
		/// provider. Each <c>OnError</c> notification contains the HRESULT returned by the provider.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// If at least one provider returns an error value, and all other providers return <c>S_OK</c>, <c>Execute</c> returns
		/// <c>S_OK</c>. OnError notifications are sent as described above.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// If at least one provider returns an error value, and at least one provider returns <c>E_PENDING</c>, <c>Execute</c> returns
		/// <c>E_PENDING</c>. OnError notifications are sent as described above.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// When <c>Execute</c> returns <c>S_OK</c>, ppIFunctionInstanceCollection contains the results of the query. If an
		/// IFunctionDiscoveryNotification interface is provided to the CreateInstanceCollectionQuery method of IFunctionDiscovery, then
		/// changes to the results will be communicated using that interface.
		/// </para>
		/// <para>
		/// When <c>Execute</c> returns <c>E_PENDING</c>, the result set will be returned asynchronously through the
		/// IFunctionDiscoveryNotification interface provided to the CreateInstanceCollectionQuery method of IFunctionDiscovery.
		/// ppIFunctionInstanceCollection may be <c>NULL</c> or may contain a partial result set. The enumeration is complete once the
		/// OnEvent method of <c>IFunctionDiscoveryNotification</c> is called with <c>FD_EVENTID_SEARCHCOMPLETE</c>. After the
		/// <c>FD_EVENTID_SEARCHCOMPLETE</c> event is received, additional notifications are updates to the results.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method must be must be invoked by the client program before any data can be retrieved from the query object. When
		/// called, this method performs the following:
		/// </para>
		/// <list type="number">
		/// <item>
		/// <term>Retrieves the function instance collection object.</term>
		/// </item>
		/// <item>
		/// <term>Queries the provider of the category that is passed into IFunctionDiscovery::CreateInstanceCollectionQuery.</term>
		/// </item>
		/// <item>
		/// <term>Retrieves the category provider.</term>
		/// </item>
		/// <item>
		/// <term>Queries the category provider using the subcategory data to generate the collection using query constraints.</term>
		/// </item>
		/// <item>
		/// <term>
		/// Initiates the update notification mechanism if the address of the client program's IFunctionDiscoveryNotification callback
		/// routine is provided to IFunctionDiscovery::CreateInstanceCollectionQuery.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Caches the collection data and returns.</term>
		/// </item>
		/// </list>
		/// <para>
		/// Function Discovery network providers only return function instances through the IFunctionDiscoveryNotification interface.
		/// They return no function instances directly when this method is invoked. Instead, Execute simply initiates an entirely
		/// asynchronous retrieval operation and returns <c>E_PENDING</c> to indicate that the results will be returned asynchronously.
		/// Notifications must be used to retrieve function instances from Function Discovery network providers.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/functiondiscoveryapi/nf-functiondiscoveryapi-ifunctioninstancecollectionquery-execute
		// HRESULT Execute( IFunctionInstanceCollection **ppIFunctionInstanceCollection );
		[PreserveSig]
		HRESULT Execute(out IFunctionInstanceCollection ppIFunctionInstanceCollection);
	}

	/// <summary>
	/// <para>
	/// [Function Discovery is available for use in the operating systems specified in the Requirements section. It may be altered or
	/// unavailable in subsequent versions.]
	/// </para>
	/// <para>
	/// This interface implements the asynchronous query for a function instance based on category and subcategory. A pointer to this
	/// interface is returned when the query is created by the client program.
	/// </para>
	/// </summary>
	/// <remarks>The Execute method must be invoked by the client program before any data can be retrieved from the query object.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/functiondiscoveryapi/nn-functiondiscoveryapi-ifunctioninstancequery
	[PInvokeData("functiondiscoveryapi.h", MSDNShortId = "NN:functiondiscoveryapi.IFunctionInstanceQuery")]
	[ComImport, Guid("6242bc6b-90ec-4b37-bb46-e229fd84ed95"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IFunctionInstanceQuery
	{
		/// <summary>
		/// <para>
		/// [Function Discovery is available for use in the operating systems specified in the Requirements section. It may be altered
		/// or unavailable in subsequent versions.]
		/// </para>
		/// <para>Performs the query defined by IFunctionDiscovery::CreateInstanceQuery.</para>
		/// </summary>
		/// <param name="ppIFunctionInstance">
		/// A pointer to an IFunctionInstance interface pointer that receives the requested function instance.
		/// </param>
		/// <returns>
		/// <para>Possible return values include, but are not limited to, the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method completed successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The ppIFunctionInstance parameter is NULL.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>The method is unable to allocate the memory required to perform this operation.</term>
		/// </item>
		/// <item>
		/// <term>E_PENDING</term>
		/// <term>The results to be returned by a provider will come through asynchronous notification.</term>
		/// </item>
		/// <item>
		/// <term>HRESULT_FROM_WIN32(ERROR_OBJECT_NOT_FOUND) 0x800710d8</term>
		/// <term>The function instance represented by the specified ID does not exist on this computer.</term>
		/// </item>
		/// <item>
		/// <term>HRESULT_FROM_WIN32(ERROR_KEY_DELETED) 0x800703fa</term>
		/// <term>
		/// The function instance could not be returned because the key corresponding to the function instance was deleted by another
		/// process. This error is returned by the registry provider if a key is deleted while query processing is taking place.
		/// </term>
		/// </item>
		/// <item>
		/// <term>HRESULT_FROM_WIN32(ERROR_FILE_NOT_FOUND) 0x80070002</term>
		/// <term>
		/// The function instance could not be returned because the key corresponding to the function instance could not be found. This
		/// error is returned by the registry provider when the provider could not find matching instances for an instance query.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// A predefined query is a query of a layered category. When a predefined query is executed, each provider that returns a
		/// function instance also returns an HRESULT value. The provider HRESULT values are aggregated, and the value returned by the
		/// Execute method reflects these aggregate results. Results are aggregated as follows:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>If all providers return S_OK, Execute returns S_OK.</term>
		/// </item>
		/// <item>
		/// <term>
		/// If at least one provider returns E_PENDING, and all other providers return either S_OK or E_PENDING, Execute returns E_PENDING.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// If all providers return an error value (that is, a value other than S_OK or E_PENDING), Execute returns the error value
		/// returned by the network provider that was last queried. Also, if the client's IFunctionDiscoveryNotification callback
		/// routine was provided to IFunctionDiscovery::CreateInstanceCollectionQuery, an OnError notification is sent for each
		/// provider. Each <c>OnError</c> notification contains the HRESULT returned by the provider.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// If at least one provider returns an error value, and all other providers return S_OK, Execute returns S_OK. OnError
		/// notification(s) are sent as described above.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// If at least one provider returns an error value, and at least one provider returns E_PENDING, Execute returns E_PENDING.
		/// OnError notification(s) are sent as described above.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method must be must be invoked by the client program to retrieve data from the query object. When called, this method
		/// performs the following:
		/// </para>
		/// <list type="number">
		/// <item>
		/// <term>Retrieves the function instance.</term>
		/// </item>
		/// <item>
		/// <term>
		/// Initiates the update notification mechanism if the address of the client program's IFunctionDiscoveryNotification callback
		/// routine is provided to IFunctionDiscovery::CreateInstanceQuery.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// Function Discovery network providers only return function instances through the IFunctionDiscoveryNotification interface.
		/// They return no function instances directly when this method is invoked. Instead, <c>Execute</c> simply initiates an entirely
		/// asynchronous retrieval operation and returns E_PENDING to indicate that the results will be returned asynchronously.
		/// Notifications must be used to retrieve function instances from Function Discovery network providers.
		/// </para>
		/// <para>
		/// If <c>Execute</c> is called twice on the same query object, the first query is terminated before the second query executes.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/functiondiscoveryapi/nf-functiondiscoveryapi-ifunctioninstancequery-execute
		// HRESULT Execute( IFunctionInstance **ppIFunctionInstance );
		[PreserveSig]
		HRESULT Execute(out IFunctionInstance ppIFunctionInstance);
	}

	/// <summary>CLSID_FunctionDiscovery</summary>
	[PInvokeData("functiondiscoveryapi.h")]
	[ComImport, Guid("C72BE2EC-8E90-452c-B29A-AB8FF1C071FC"), ClassInterface(ClassInterfaceType.None)]
	public class FunctionDiscovery { }

	/// <summary>CLSID_FunctionInstanceCollection</summary>
	[PInvokeData("functiondiscoveryapi.h")]
	[ComImport, Guid("ba818ce5-b55f-443f-ad39-2fe89be6191f"), ClassInterface(ClassInterfaceType.None)]
	public class FunctionInstanceCollection { }
}