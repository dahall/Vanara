namespace Vanara.PInvoke.VssApi;

/// <summary>The <c>IVssAdmin</c> interface manages providers registered with VSS.</summary>
// https://docs.microsoft.com/en-us/windows/win32/api/vsadmin/nn-vsadmin-ivssadmin
[PInvokeData("vsadmin.h", MSDNShortId = "NN:vsadmin.IVssAdmin")]
[ComImport, Guid("77ED5996-2F63-11d3-8A39-00C04F72D8E3"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(VSSCoordinator))]
public interface IVssAdmin
{
	/// <summary>The <c>RegisterProvider</c> method registers a new shadow copy provider.</summary>
	/// <param name="pProviderId">
	/// The <c>VSS_ID</c> that uniquely and persistently identifies the provider. After it is defined, the ProviderId parameter should
	/// remain the same, even when the software revision is updated. A ProviderId parameter should be changed only when the
	/// functionality changes enough that both providers would be active on the same system. A requester may use the ProviderId
	/// parameter to request that a specific provider be used in a shadow copy creation.
	/// </param>
	/// <param name="ClassId">The CLSID of the provider.</param>
	/// <param name="pwszProviderName">The name of the provider.</param>
	/// <param name="eProviderType">
	/// A VSS_PROVIDER_TYPE enumeration value that specifies the provider type. Note that <c>VSS_PROV_HARDWARE</c> is not a valid
	/// provider type on Windows client operating system versions. Hardware providers will run only on Windows server operating system versions.
	/// </param>
	/// <param name="pwszProviderVersion">The version of the provider.</param>
	/// <param name="ProviderVersionId">
	/// The <c>VSS_ID</c> that uniquely identifies this version of the provider. The combination of the pProviderId and
	/// ProviderVersionId parameters should be unique. The ProviderVersionId parameter can be the same as the ProviderVersionId
	/// parameter of another provider.
	/// </param>
	/// <remarks>
	/// <para>
	/// If the hardware provider is updated, the setup application should call the UnregisterProvider method to unregister the outdated
	/// version, and then call the <c>RegisterProvider</c> method to register the updated provider.
	/// </para>
	/// <para><c>Note</c> Hardware providers can only be registered on Windows Server operating systems.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vsadmin/nf-vsadmin-ivssadmin-registerprovider HRESULT RegisterProvider( [in]
	// VSS_ID pProviderId, [in] CLSID ClassId, [in] VSS_PWSZ pwszProviderName, [in] VSS_PROVIDER_TYPE eProviderType, [in] VSS_PWSZ
	// pwszProviderVersion, [in] VSS_ID ProviderVersionId );
	void RegisterProvider(Guid pProviderId, Guid ClassId, [MarshalAs(UnmanagedType.LPWStr)] string pwszProviderName,
		VSS_PROVIDER_TYPE eProviderType, [MarshalAs(UnmanagedType.LPWStr)] string pwszProviderVersion, Guid ProviderVersionId);

	/// <summary>The <c>UnregisterProvider</c> method unregisters an existing provider.</summary>
	/// <param name="ProviderId">The <c>VSS_ID</c> of the provider.</param>
	// https://docs.microsoft.com/en-us/windows/win32/api/vsadmin/nf-vsadmin-ivssadmin-unregisterprovider HRESULT UnregisterProvider(
	// [in] VSS_ID ProviderId );
	void UnregisterProvider(Guid ProviderId);

	/// <summary>The <c>QueryProviders</c> method queries all registered providers.</summary>
	/// <returns>The address of an IVssEnumObject interface pointer, which is initialized on return. Callers must release the interface.</returns>
	/// <remarks>
	/// Calling the IVssEnumObject::Next method on the IVssEnumObject interface returned though the ppEnum parameter will return
	/// VSS_OBJECT_PROP structures containing a VSS_PROVIDER_PROP structure for each registered provider.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vsadmin/nf-vsadmin-ivssadmin-queryproviders HRESULT QueryProviders( [out]
	// IVssEnumObject **ppEnum );
	IVssEnumObject QueryProviders();

	/// <summary>
	/// <para>Not supported.</para>
	/// <para>This method is reserved for system use.</para>
	/// </summary>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vsadmin/nf-vsadmin-ivssadmin-abortallsnapshotsinprogress HRESULT AbortAllSnapshotsInProgress();
	void AbortAllSnapshotsInProgress();
}

/// <summary>Undocumented.</summary>
[ComImport, Guid("7858A9F8-B1FA-41a6-964F-B9B36B8CD8D8"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(VSSCoordinator))]
public interface IVssAdminEx : IVssAdmin
{
	/// <summary>The <c>RegisterProvider</c> method registers a new shadow copy provider.</summary>
	/// <param name="pProviderId">
	/// The <c>VSS_ID</c> that uniquely and persistently identifies the provider. After it is defined, the ProviderId parameter should
	/// remain the same, even when the software revision is updated. A ProviderId parameter should be changed only when the
	/// functionality changes enough that both providers would be active on the same system. A requester may use the ProviderId
	/// parameter to request that a specific provider be used in a shadow copy creation.
	/// </param>
	/// <param name="ClassId">The CLSID of the provider.</param>
	/// <param name="pwszProviderName">The name of the provider.</param>
	/// <param name="eProviderType">
	/// A VSS_PROVIDER_TYPE enumeration value that specifies the provider type. Note that <c>VSS_PROV_HARDWARE</c> is not a valid
	/// provider type on Windows client operating system versions. Hardware providers will run only on Windows server operating system versions.
	/// </param>
	/// <param name="pwszProviderVersion">The version of the provider.</param>
	/// <param name="ProviderVersionId">
	/// The <c>VSS_ID</c> that uniquely identifies this version of the provider. The combination of the pProviderId and
	/// ProviderVersionId parameters should be unique. The ProviderVersionId parameter can be the same as the ProviderVersionId
	/// parameter of another provider.
	/// </param>
	/// <remarks>
	/// <para>
	/// If the hardware provider is updated, the setup application should call the UnregisterProvider method to unregister the outdated
	/// version, and then call the <c>RegisterProvider</c> method to register the updated provider.
	/// </para>
	/// <para><c>Note</c> Hardware providers can only be registered on Windows Server operating systems.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vsadmin/nf-vsadmin-ivssadmin-registerprovider HRESULT RegisterProvider( [in]
	// VSS_ID pProviderId, [in] CLSID ClassId, [in] VSS_PWSZ pwszProviderName, [in] VSS_PROVIDER_TYPE eProviderType, [in] VSS_PWSZ
	// pwszProviderVersion, [in] VSS_ID ProviderVersionId );
	new void RegisterProvider(Guid pProviderId, Guid ClassId, [MarshalAs(UnmanagedType.LPWStr)] string pwszProviderName,
		VSS_PROVIDER_TYPE eProviderType, [MarshalAs(UnmanagedType.LPWStr)] string pwszProviderVersion, Guid ProviderVersionId);

	/// <summary>The <c>UnregisterProvider</c> method unregisters an existing provider.</summary>
	/// <param name="ProviderId">The <c>VSS_ID</c> of the provider.</param>
	// https://docs.microsoft.com/en-us/windows/win32/api/vsadmin/nf-vsadmin-ivssadmin-unregisterprovider HRESULT UnregisterProvider(
	// [in] VSS_ID ProviderId );
	new void UnregisterProvider(Guid ProviderId);

	/// <summary>The <c>QueryProviders</c> method queries all registered providers.</summary>
	/// <returns>The address of an IVssEnumObject interface pointer, which is initialized on return. Callers must release the interface.</returns>
	/// <remarks>
	/// Calling the IVssEnumObject::Next method on the IVssEnumObject interface returned though the ppEnum parameter will return
	/// VSS_OBJECT_PROP structures containing a VSS_PROVIDER_PROP structure for each registered provider.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vsadmin/nf-vsadmin-ivssadmin-queryproviders HRESULT QueryProviders( [out]
	// IVssEnumObject **ppEnum );
	new IVssEnumObject QueryProviders();

	/// <summary>
	/// <para>Not supported.</para>
	/// <para>This method is reserved for system use.</para>
	/// </summary>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vsadmin/nf-vsadmin-ivssadmin-abortallsnapshotsinprogress HRESULT AbortAllSnapshotsInProgress();
	new void AbortAllSnapshotsInProgress();

	/// <summary>Inform caller of features that provider supports</summary>
	/// <param name="pProviderId">The provider identifier.</param>
	/// <returns>The original capability mask</returns>
	VSS_PROVIDER_CAPABILITIES GetProviderCapability(Guid pProviderId);

	/// <summary>Retrieve persistent context of given provider</summary>
	/// <param name="ProviderId">The provider identifier.</param>
	/// <returns>The context</returns>
	int GetProviderContext(Guid ProviderId);

	/// <summary>
	/// Set persistent context of specified provider The setting is persisted in registry by VSS It is automatically applied to the
	/// snapshot context Requestors should NOT call this method
	/// </summary>
	/// <param name="ProviderId">The provider identifier.</param>
	/// <param name="lContext">The context.</param>
	void SetProviderContext(Guid ProviderId, int lContext);
}

/// <summary>CLSID_VSSCoordinator.</summary>
[ComImport, Guid("E579AB5F-1CC4-44b4-BED9-DE0991FF0623"), ClassInterface(ClassInterfaceType.None)]
public class VSSCoordinator { }