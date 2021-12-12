using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke.VssApi
{
	/// <summary>Contains the methods used by VSS to manage shadow copy volumes.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/vsprov/nn-vsprov-ivssfilesharesnapshotprovider
	[PInvokeData("vsprov.h", MSDNShortId = "NN:vsprov.IVssFileShareSnapshotProvider")]
	[ComImport, Guid("c8636060-7c2e-11df-8c4a-0800200c9a66"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IVssFileShareSnapshotProvider
	{
		/// <summary>Sets the context for the subsequent shadow copy-related operations.</summary>
		/// <param name="lContext">
		/// The context to be set. The context must be one of the supported values of _VSS_SNAPSHOT_CONTEXT or a supported combination of
		/// _VSS_VOLUME_SNAPSHOT_ATTRIBUTES and <c>_VSS_SNAPSHOT_CONTEXT</c> values.
		/// </param>
		/// <returns>
		/// <para>The following are the valid return codes for this method.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The context was set successfully.</term>
		/// </item>
		/// <item>
		/// <term><c>E_ACCESSDENIED</c></term>
		/// <term>The caller does not have sufficient backup privileges or is not an administrator.</term>
		/// </item>
		/// <item>
		/// <term><c>E_INVALIDARG</c></term>
		/// <term>One of the parameter values is not valid.</term>
		/// </item>
		/// <item>
		/// <term><c>E_OUTOFMEMORY</c></term>
		/// <term>The caller is out of memory or other system resources.</term>
		/// </item>
		/// <item>
		/// <term><c>VSS_E_BAD_STATE</c></term>
		/// <term>The context is frozen and cannot be changed.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The default context for VSS shadow copies is VSS_CTX_BACKUP.</para>
		/// <para>
		/// <c>Windows XP:</c> The only supported context is the default context, VSS_CTX_BACKUP. Therefore, calling SetContext under
		/// Windows XP returns E_NOTIMPL.
		/// </para>
		/// <para>
		/// For more information about how the context that is set by SetContext affects how a shadow copy is created and managed, see
		/// Implementation Details for Creating Shadow Copies.
		/// </para>
		/// <para>For a complete discussion of the permitted shadow copy contexts, see _VSS_SNAPSHOT_CONTEXT and _VSS_VOLUME_SNAPSHOT_ATTRIBUTES.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsprov/nf-vsprov-ivssfilesharesnapshotprovider-setcontext HRESULT SetContext(
		// [in] LONG lContext );
		[PreserveSig]
		HRESULT SetContext(VSS_SNAPSHOT_CONTEXT lContext);

		/// <summary>Gets the VSS_SNAPSHOT_PROP structure for a file share snapshot.</summary>
		/// <param name="SnapshotId">Shadow copy identifier.</param>
		/// <param name="pProp">
		/// The address of a caller-allocated VSS_SNAPSHOT_PROP structure that receives the shadow copy properties. The provider is
		/// responsible for setting the members of this structure. All members are required except <c>m_pwszExposedName</c> and
		/// <c>m_pwszExposedPath</c>, which the provider can set to <c>NULL</c>. The provider allocates memory for all string members that
		/// it sets in the structure. When the structure is no longer needed, the caller is responsible for freeing these strings by calling
		/// the VssFreeSnapshotProperties function.
		/// </param>
		/// <returns>
		/// <para>The following are the valid return codes for this method.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The requested information was successfully returned.</term>
		/// </item>
		/// <item>
		/// <term><c>E_ACCESSDENIED</c></term>
		/// <term>The caller does not have sufficient backup privileges or is not an administrator.</term>
		/// </item>
		/// <item>
		/// <term><c>E_INVALIDARG</c></term>
		/// <term>One of the parameter values is not valid.</term>
		/// </item>
		/// <item>
		/// <term><c>E_OUTOFMEMORY</c></term>
		/// <term>The caller is out of memory or other system resources.</term>
		/// </item>
		/// <item>
		/// <term><c>VSS_E_OBJECT_NOT_FOUND</c></term>
		/// <term>The specified volume was not found.</term>
		/// </item>
		/// <item>
		/// <term><c>VSS_E_PROVIDER_VETO</c></term>
		/// <term>
		/// Provider error. The provider logged the error in the event log. For more information, see Event and Error Handling Under VSS.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>VSS_E_UNEXPECTED</c></term>
		/// <term>
		/// Unexpected error. The error code is logged in the error log file. For more information, see Event and Error Handling Under VSS.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The caller should set the contents of the VSS_SNAPSHOT_PROP structure to zero before calling the GetSnapshotProperties method.
		/// </para>
		/// <para>The provider is responsible for allocating and freeing the strings in the VSS_SNAPSHOT_PROP structure.</para>
		/// <para>
		/// The VSS coordinator calls this method during the PostSnapshot phase of snapshot creation in order to retrieve the snapshot
		/// access path (UNC path for file share snapshots). The coordinator calls this method after PreFinalCommitSnapshots and before it
		/// invokes PostSnapshot in the writers.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsprov/nf-vsprov-ivssfilesharesnapshotprovider-getsnapshotproperties HRESULT
		// GetSnapshotProperties( [in] VSS_ID SnapshotId, [out] VSS_SNAPSHOT_PROP *pProp );
		[PreserveSig]
		HRESULT GetSnapshotProperties(Guid SnapshotId, out VSS_SNAPSHOT_PROP pProp);

		/// <summary>
		/// Gets an enumeration of VSS_SNAPSHOT_PROP structures for all file share snapshots that are available to the application server.
		/// </summary>
		/// <param name="QueriedObjectId">Reserved for system use. The value of this parameter must be GUID_NULL.</param>
		/// <param name="eQueriedObjectType">Reserved for system use. The value of this parameter must be VSS_OBJECT_NONE.</param>
		/// <param name="eReturnedObjectsType">Reserved for system use. The value of this parameter must be VSS_OBJECT_SNAPSHOT.</param>
		/// <param name="ppEnum">
		/// The address of an IVssEnumObject interface pointer, which is initialized on return. Callers must release the interface. This
		/// parameter is required and cannot be null.
		/// </param>
		/// <returns>
		/// <para>The following are the valid return codes for this method.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The query operation was successful.</term>
		/// </item>
		/// <item>
		/// <term><c>E_ACCESSDENIED</c></term>
		/// <term>The caller does not have sufficient backup privileges or is not an administrator.</term>
		/// </item>
		/// <item>
		/// <term><c>E_INVALIDARG</c></term>
		/// <term>One of the parameter values is not valid.</term>
		/// </item>
		/// <item>
		/// <term><c>E_OUTOFMEMORY</c></term>
		/// <term>The caller is out of memory or other system resources.</term>
		/// </item>
		/// <item>
		/// <term><c>VSS_E_PROVIDER_VETO</c></term>
		/// <term>
		/// Provider error. The provider logged the error in the event log. For more information, see Event and Error Handling Under VSS.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>This method is typically called in response to requester generated snapshot query operations.</para>
		/// <para>
		/// Calling the IVssEnumObject::Next method on the IVssEnumObject interface that is returned though the <c>ppEnum</c> parameter will
		/// return VSS_OBJECT_PROP structures containing a VSS_SNAPSHOT_PROP structure for each shadow copy.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsprov/nf-vsprov-ivssfilesharesnapshotprovider-query HRESULT Query( [in]
		// VSS_ID QueriedObjectId, [in] VSS_OBJECT_TYPE eQueriedObjectType, [in] VSS_OBJECT_TYPE eReturnedObjectsType, [out] IVssEnumObject
		// **ppEnum );
		[PreserveSig]
		HRESULT Query(Guid QueriedObjectId, VSS_OBJECT_TYPE eQueriedObjectType, VSS_OBJECT_TYPE eReturnedObjectsType, out IVssEnumObject ppEnum);

		/// <summary>Deletes specific snapshots, or all snapshots in a specified snapshot set.</summary>
		/// <param name="SourceObjectId">Identifier of the shadow copy or shadow copy set to be deleted.</param>
		/// <param name="eSourceObjectType">Type of the object to be deleted. The value of this parameter is VSS_OBJECT_SNAPSHOT or VSS_OBJECT_SNAPSHOT_SET.</param>
		/// <param name="bForceDelete">
		/// If the value of this parameter is <c>TRUE</c>, the provider will do everything possible to delete the shadow copy or shadow
		/// copies in a shadow copy set. If it is <c>FALSE</c>, no additional effort will be made.
		/// </param>
		/// <param name="plDeletedSnapshots">Pointer to a variable that receives the number of shadow copies that were deleted.</param>
		/// <param name="pNondeletedSnapshotID">
		/// If an error occurs, this parameter receives a pointer to the identifier of the first shadow copy that could not be deleted.
		/// Otherwise, it points to GUID_NULL.
		/// </param>
		/// <returns>
		/// <para>The following are the valid return codes for this method.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The shadow copies were successfully deleted.</term>
		/// </item>
		/// <item>
		/// <term><c>E_ACCESSDENIED</c></term>
		/// <term>The caller does not have sufficient backup privileges or is not an administrator.</term>
		/// </item>
		/// <item>
		/// <term><c>E_INVALIDARG</c></term>
		/// <term>One of the parameter values is not valid.</term>
		/// </item>
		/// <item>
		/// <term><c>E_OUTOFMEMORY</c></term>
		/// <term>The caller is out of memory or other system resources.</term>
		/// </item>
		/// <item>
		/// <term><c>VSS_E_OBJECT_NOT_FOUND</c></term>
		/// <term>The specified shadow copies were not found.</term>
		/// </item>
		/// <item>
		/// <term><c>VSS_E_PROVIDER_VETO</c></term>
		/// <term>
		/// Provider error. The provider logged the error in the event log. For more information, see Event and Error Handling Under VSS.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// The VSS coordinator calls this method as part of the snapshot auto-release process. The method is also called in response to
		/// requester driven delete operations.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsprov/nf-vsprov-ivssfilesharesnapshotprovider-deletesnapshots HRESULT
		// DeleteSnapshots( [in] VSS_ID SourceObjectId, [in] VSS_OBJECT_TYPE eSourceObjectType, [in] BOOL bForceDelete, [out] LONG
		// *plDeletedSnapshots, [out] VSS_ID *pNondeletedSnapshotID );
		[PreserveSig]
		HRESULT DeleteSnapshots(Guid SourceObjectId, VSS_OBJECT_TYPE eSourceObjectType, [MarshalAs(UnmanagedType.Bool)] bool bForceDelete, out int plDeletedSnapshots, out Guid pNondeletedSnapshotID);

		/// <summary>VSS calls this method for each shadow copy that is added to the shadow copy set.</summary>
		/// <param name="SnapshotSetId">Shadow copy set identifier.</param>
		/// <param name="SnapshotId">Identifier of the shadow copy to be created.</param>
		/// <param name="pwszSharePath">The file share path.</param>
		/// <param name="lNewContext">
		/// The context for the shadow copy set. This context consists of a bitmask of _VSS_VOLUME_SNAPSHOT_ATTRIBUTES values.
		/// </param>
		/// <param name="ProviderId">The provider ID.</param>
		/// <returns>
		/// <para>The following are the valid return codes for this method.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The shadow copy was successfully created.</term>
		/// </item>
		/// <item>
		/// <term><c>E_ACCESSDENIED</c></term>
		/// <term>The caller does not have sufficient backup privileges or is not an administrator.</term>
		/// </item>
		/// <item>
		/// <term><c>E_INVALIDARG</c></term>
		/// <term>One of the parameter values is not valid.</term>
		/// </item>
		/// <item>
		/// <term><c>E_OUTOFMEMORY</c></term>
		/// <term>The caller is out of memory or other system resources.</term>
		/// </item>
		/// <item>
		/// <term><c>VSS_E_OBJECT_NOT_FOUND</c></term>
		/// <term>The specified volume was not found.</term>
		/// </item>
		/// <item>
		/// <term><c>VSS_E_PROVIDER_VETO</c></term>
		/// <term>
		/// Provider error. The provider logged the error in the event log. For more information, see Event and Error Handling Under VSS.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>VSS_E_UNSUPPORTED_CONTEXT</c></term>
		/// <term>The specified context is not supported.</term>
		/// </item>
		/// <item>
		/// <term><c>VSS_E_VOLUME_NOT_SUPPORTED_BY_PROVIDER</c></term>
		/// <term>The provider does not support the specified volume.</term>
		/// </item>
		/// <item>
		/// <term><c>VSS_E_UNEXPECTED</c></term>
		/// <term>
		/// Unexpected error. The error code is logged in the error log file. For more information, see Event and Error Handling Under VSS.
		/// <c>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:</c> This value is not supported until Windows Server
		/// 2008 R2 and Windows 7. E_UNEXPECTED is used instead.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsprov/nf-vsprov-ivssfilesharesnapshotprovider-beginpreparesnapshot HRESULT
		// BeginPrepareSnapshot( [in] VSS_ID SnapshotSetId, [in] VSS_ID SnapshotId, [in] VSS_PWSZ pwszSharePath, [in] LONG lNewContext, [in]
		// VSS_ID ProviderId );
		[PreserveSig]
		HRESULT BeginPrepareSnapshot(Guid SnapshotSetId, Guid SnapshotId, [MarshalAs(UnmanagedType.LPWStr)] string pwszSharePath,
			VSS_VOLUME_SNAPSHOT_ATTRIBUTES lNewContext, Guid ProviderId);

		/// <summary>Determines whether the given Universal Naming Convention (UNC) path is supported by this provider.</summary>
		/// <param name="pwszSharePath">The path to the file share.</param>
		/// <param name="pbSupportedByThisProvider">
		/// This parameter receives <c>TRUE</c> if shadow copies are supported on the specified volume, otherwise <c>FALSE</c>.
		/// </param>
		/// <returns>
		/// <para>The following are the valid return codes for this method.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The requested information was successfully returned.</term>
		/// </item>
		/// <item>
		/// <term><c>E_ACCESSDENIED</c></term>
		/// <term>The caller does not have sufficient backup privileges or is not an administrator.</term>
		/// </item>
		/// <item>
		/// <term><c>E_INVALIDARG</c></term>
		/// <term>One of the parameter values is not valid.</term>
		/// </item>
		/// <item>
		/// <term><c>VSS_E_NESTED_VOLUME_LIMIT</c></term>
		/// <term>
		/// The specified volume is nested too deeply to participate in the VSS operation. <c>Windows Server 2008, Windows Vista, Windows
		/// Server 2003 and Windows XP:</c> This return code is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>E_OUTOFMEMORY</c></term>
		/// <term>The caller is out of memory or other system resources.</term>
		/// </item>
		/// <item>
		/// <term><c>VSS_E_OBJECT_NOT_FOUND</c></term>
		/// <term>The specified volume was not found.</term>
		/// </item>
		/// <item>
		/// <term><c>VSS_E_PROVIDER_VETO</c></term>
		/// <term>
		/// Provider error. The provider logged the error in the event log. For more information, see Event and Error Handling Under VSS.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>VSS_E_UNEXPECTED</c></term>
		/// <term>
		/// Unexpected error. The error code is logged in the error log file. For more information, see Event and Error Handling Under VSS.
		/// <c>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:</c> This value is not supported until Windows Server
		/// 2008 R2 and Windows 7. E_UNEXPECTED is used instead.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// The VSS coordinator calls this method as part of AddToSnapshotSet to determine which provider to use for snapshot creation.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsprov/nf-vsprov-ivssfilesharesnapshotprovider-ispathsupported HRESULT
		// IsPathSupported( [in] VSS_PWSZ pwszSharePath, [out] BOOL *pbSupportedByThisProvider );
		[PreserveSig]
		HRESULT IsPathSupported([MarshalAs(UnmanagedType.LPWStr)] string pwszSharePath, [MarshalAs(UnmanagedType.Bool)] out bool pbSupportedByThisProvider);

		/// <summary>Determines whether the given Universal Naming Convention (UNC) path currently has any snapshots.</summary>
		/// <param name="pwszSharePath">The path to the file share.</param>
		/// <param name="pbSnapshotsPresent">
		/// This parameter receives <c>TRUE</c> if the volume has a shadow copy, or <c>FALSE</c> if the volume does not have a shadow copy.
		/// </param>
		/// <param name="plSnapshotCompatibility">
		/// A bitmask of VSS_SNAPSHOT_COMPATIBILITY values that indicate whether certain volume control or file I/O operations are disabled
		/// for the given volume, if the volume has a shadow copy.
		/// </param>
		/// <returns>
		/// <para>The following are the valid return codes for this method.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The requested information was successfully returned.</term>
		/// </item>
		/// <item>
		/// <term><c>E_ACCESSDENIED</c></term>
		/// <term>The caller does not have sufficient backup privileges or is not an administrator.</term>
		/// </item>
		/// <item>
		/// <term><c>E_INVALIDARG</c></term>
		/// <term>One of the parameter values is not valid.</term>
		/// </item>
		/// <item>
		/// <term><c>E_OUTOFMEMORY</c></term>
		/// <term>The caller is out of memory or other system resources.</term>
		/// </item>
		/// <item>
		/// <term><c>VSS_E_OBJECT_NOT_FOUND</c></term>
		/// <term>The specified volume was not found.</term>
		/// </item>
		/// <item>
		/// <term><c>VSS_E_PROVIDER_VETO</c></term>
		/// <term>
		/// Provider error. The provider logged the error in the event log. For more information, see Event and Error Handling Under VSS.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>VSS_E_UNEXPECTED</c></term>
		/// <term>
		/// Unexpected error. The error code is logged in the error log file. For more information, see Event and Error Handling Under VSS.
		/// <c>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:</c> This value is not supported until Windows Server
		/// 2008 R2 and Windows 7. E_UNEXPECTED is used instead.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsprov/nf-vsprov-ivssfilesharesnapshotprovider-ispathsnapshotted HRESULT
		// IsPathSnapshotted( [in] VSS_PWSZ pwszSharePath, [out] BOOL *pbSnapshotsPresent, [out] LONG *plSnapshotCompatibility );
		[PreserveSig]
		HRESULT IsPathSnapshotted([MarshalAs(UnmanagedType.LPWStr)] string pwszSharePath, [MarshalAs(UnmanagedType.Bool)] out bool pbSnapshotsPresent,
			out VSS_SNAPSHOT_COMPATIBILITY plSnapshotCompatibility);

		/// <summary>Requests the provider to set a property value for the specified snapshot.</summary>
		/// <param name="SnapshotId">Shadow copy identifier. This parameter is required and cannot be GUID_NULL.</param>
		/// <param name="eSnapshotPropertyId">A VSS_SNAPSHOT_PROPERTY_ID value that specifies the property to be set for the shadow copy.</param>
		/// <param name="vProperty">
		/// The value to be set for the property. See the VSS_SNAPSHOT_PROP structure for valid data types and descriptions of the
		/// properties that can be set for a shadow copy.
		/// </param>
		/// <returns>
		/// <para>The following are the valid return codes for this method.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The property was set successfully.</term>
		/// </item>
		/// <item>
		/// <term><c>E_ACCESSDENIED</c></term>
		/// <term>The caller does not have sufficient backup privileges or is not an administrator.</term>
		/// </item>
		/// <item>
		/// <term><c>E_INVALIDARG</c></term>
		/// <term>One of the parameter values is not valid.</term>
		/// </item>
		/// <item>
		/// <term><c>E_OUTOFMEMORY</c></term>
		/// <term>The caller is out of memory or other system resources.</term>
		/// </item>
		/// <item>
		/// <term><c>VSS_E_OBJECT_NOT_FOUND</c></term>
		/// <term>The specified shadow copy was not found.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsprov/nf-vsprov-ivssfilesharesnapshotprovider-setsnapshotproperty HRESULT
		// SetSnapshotProperty( [in] VSS_ID SnapshotId, [in] VSS_SNAPSHOT_PROPERTY_ID eSnapshotPropertyId, [in] VARIANT vProperty );
		[PreserveSig]
		HRESULT SetSnapshotProperty(Guid SnapshotId, VSS_SNAPSHOT_PROPERTY_ID eSnapshotPropertyId, object vProperty);
	}

	/// <summary>
	/// <para>
	/// The <c>IVssHardwareSnapshotProvider</c> interface contains the methods used by VSS to map volumes to LUNs, discover LUNs created
	/// during the shadow copy process, and transport LUNs on a SAN. All hardware providers must support this interface.
	/// </para>
	/// <para><c>Note</c> Hardware providers are only supported on Windows Server operating systems.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/vsprov/nn-vsprov-ivsshardwaresnapshotprovider
	[PInvokeData("vsprov.h", MSDNShortId = "NN:vsprov.IVssHardwareSnapshotProvider")]
	[ComImport, Guid("9593A157-44E9-4344-BBEB-44FBF9B06B10"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IVssHardwareSnapshotProvider
	{
		/// <summary>
		/// <para>
		/// The <c>AreLunsSupported</c> method determines whether the hardware provider supports shadow copy creation for all LUNs that
		/// contribute to the volume. VSS calls the <c>AreLunsSupported</c> method for each volume that is added to the shadow copy set.
		/// Before calling this method, VSS determines the LUNs that contribute to the volume.
		/// </para>
		/// <para>For a specific volume, each LUN can contribute only once. A specific LUN may contribute to multiple volumes.</para>
		/// <para><c>Note</c> Hardware providers are only supported on Windows Server operating systems.</para>
		/// </summary>
		/// <param name="lLunCount">Count of LUNs contributing to this shadow copy volume.</param>
		/// <param name="lContext">
		/// Shadow copy context for the current shadow copy set as enumerated by a bitmask of flags from the _VSS_VOLUME_SNAPSHOT_ATTRIBUTES
		/// enumeration. If the <c>VSS_VOLSNAP_ATTR_TRANSPORTABLE</c> flag is set, the shadow copy set is transportable.
		/// </param>
		/// <param name="rgwszDevices">List of devices corresponding to the LUNs to be shadow copied.</param>
		/// <param name="pLunInformation">
		/// Array of <c>lLunCount</c> VDS_LUN_INFORMATION structures, one for each LUN contributing to this shadow copy volume.
		/// </param>
		/// <param name="pbIsSupported">
		/// Pointer to a <c>BOOL</c> value. If all devices are supported for shadow copy, the provider should store a <c>TRUE</c> value at
		/// the location pointed to by <c>pbIsSupported</c>.
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c><c>S_OK</c></c> 0x00000000L</term>
		/// <term>The operation was successfully completed.</term>
		/// </item>
		/// <item>
		/// <term><c><c>E_OUTOFMEMORY</c></c> 0x8007000EL</term>
		/// <term>Out of memory or other system resources.</term>
		/// </item>
		/// <item>
		/// <term><c>E_INVALIDARG</c> 0x80070057L</term>
		/// <term>One of the parameter values is not valid.</term>
		/// </item>
		/// <item>
		/// <term><c><c>VSS_E_PROVIDER_VETO</c></c> 0x80042306L</term>
		/// <term>
		/// An unexpected provider error occurred. The provider must report an event in the application event log providing the user with
		/// information on how to resolve the problem.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If the hardware subsystem supports the SCSI Inquiry Data and Vital Product Data page 80 (device serial number) and page 83
		/// (device identity) guidelines, the provider should not need to modify the structures in the <c>pLunInformation</c> array.
		/// </para>
		/// <para>
		/// In any case, the <c>AreLunsSupported</c> method should not modify the value of the <c>m_rgInterconnects</c> member of any
		/// VDS_LUN_INFORMATION structure in the <c>pLunInformation</c> array.
		/// </para>
		/// <para>
		/// If the provider supports hardware shadow copy creation for all of the LUNs in the <c>pLunInformation</c> array, it should return
		/// <c>TRUE</c> in the <c>BOOL</c> value that the <c>pbIsSupported</c> parameter points to. If the provider does not support
		/// hardware shadow copies for one or more LUNs, it must set this <c>BOOL</c> value to <c>FALSE</c>.
		/// </para>
		/// <para>
		/// The provider must never agree to create shadow copies if it cannot, even if the problem is only temporary. If a transient
		/// condition, such as low resources, makes it impossible for the provider to create a shadow copy using one or more LUNs when
		/// <c>AreLunsSupported</c> is called, the provider must set the <c>BOOL</c> value to <c>FALSE</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsprov/nf-vsprov-ivsshardwaresnapshotprovider-arelunssupported HRESULT
		// AreLunsSupported( [in] LONG lLunCount, [in] LONG lContext, [in] VSS_PWSZ *rgwszDevices, [in, out] VDS_LUN_INFORMATION
		// *pLunInformation, [out] BOOL *pbIsSupported );
		[PreserveSig]
		HRESULT AreLunsSupported(int lLunCount, VSS_VOLUME_SNAPSHOT_ATTRIBUTES lContext,
			[In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr, SizeParamIndex = 0)] string[] rgwszDevices,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] VDS_LUN_INFORMATION[] pLunInformation,
			[MarshalAs(UnmanagedType.Bool)] out bool pbIsSupported);

		/// <summary>
		/// <para>
		/// The <c>FillInLunInfo</c> method prompts the hardware provider to indicate whether it supports the corresponding disk device and
		/// correct any omissions in the VDS_LUN_INFORMATION structure. VSS calls the <c>FillInLunInfo</c> method after the
		/// IVssHardwareSnapshotProvider::LocateLuns method or before the IVssHardwareSnapshotProvider::OnLunEmpty method to obtain the
		/// VDS_LUN_INFORMATION structure associated with a shadow copy LUN. VSS will compare the <c>VDS_LUN_INFORMATION</c> structure
		/// received in the IVssHardwareSnapshotProvider::GetTargetLuns method to identify shadow copy LUNs. If the structures do not match,
		/// the requester will receive <c>VSS_S_SOME_SNAPSHOTS_NOT_IMPORTED</c>, which indicates a mismatch.
		/// </para>
		/// <para><c>Note</c> Hardware providers are only supported on Windows Server operating systems.</para>
		/// </summary>
		/// <param name="wszDeviceName">Device corresponding to the shadow copy LUN.</param>
		/// <param name="pLunInfo">The VDS_LUN_INFORMATION structure for the shadow copy LUN.</param>
		/// <param name="pbIsSupported">
		/// The provider must return <c>TRUE</c> in the location pointed to by the <c>pbIsSupported</c> parameter if the device is supported.
		/// </param>
		/// <returns>
		/// <para>VSS ignores this method's return value.</para>
		/// <para><c>Windows Server 2003:</c> VSS does not ignore the return value, which can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c> 0x00000000L</term>
		/// <term>The operation was successfully completed.</term>
		/// </item>
		/// <item>
		/// <term><c>E_OUTOFMEMORY</c> 0x8007000EL</term>
		/// <term>Out of memory or other system resources.</term>
		/// </item>
		/// <item>
		/// <term><c>E_INVALIDARG</c> 0x80070057L</term>
		/// <term>One of the parameter values is not valid.</term>
		/// </item>
		/// <item>
		/// <term><c>VSS_E_PROVIDER_VETO</c> 0x80042306L</term>
		/// <term>
		/// An unexpected provider error has occurred. The provider must report an event in the application event log providing the user
		/// with information on how to resolve the problem.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// VSS calls the <c>FillInLunInfo</c> method for each VDS_LUN_INFORMATION structure that the provider previously initialized in its
		/// GetTargetLuns method. VSS also calls the <c>FillInLunInfo</c> method for each new disk device that arrives in the system during
		/// the import process.
		/// </para>
		/// <para>
		/// The provider can correct any omissions in the VDS_LUN_INFORMATION structure received in the <c>pLunInfo</c> parameter. However,
		/// the provider should not modify the value of the <c>m_rgInterconnects</c> member of this structure.
		/// </para>
		/// <para>
		/// The members of the VDS_LUN_INFORMATION structure correspond to the SCSI Inquiry Data and Vital Product Data page 80 (device
		/// serial number) information, with the following exceptions:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>The <c>m_version</c> member must be set to <c>VER_VDS_LUN_INFORMATION</c>.</term>
		/// </item>
		/// <item>
		/// <term>
		/// The <c>m_BusType</c> member is ignored in comparisons during import. This value depends on the PnP storage stack on the
		/// corresponding disk device. Usually this is <c>VDSBusTypeScsi</c>.
		/// </term>
		/// </item>
		/// <item>
		/// <term>The <c>m_diskSignature</c> member is ignored in comparisons during import. The provider must set this member to GUID_NULL.</term>
		/// </item>
		/// </list>
		/// <para>
		/// The members of the VDS_STORAGE_DEVICE_ID_DESCRIPTOR structure (in the <c>m_deviceIdDescriptor</c> member of the
		/// VDS_LUN_INFORMATION structure) correspond to the page 83 information. In this structure, each VDS_STORAGE_IDENTIFIER structure
		/// corresponds to the STORAGE_IDENTIFIER structure for a device identifier (that is, a storage identifier with an association type
		/// of zero). For more information about the STORAGE_IDENTIFIER structure, see the Windows Driver Kit (WDK) documentation.
		/// </para>
		/// <para>
		/// If the <c>FillInLunInfo</c> method is called for a LUN that is unknown to the provider, the provider should not return an error.
		/// Instead, it should return <c>FALSE</c> in the <c>BOOL</c> value that the <c>pbIsSupported</c> parameter points to and return
		/// success. If the provider recognizes the LUN, it should set the <c>BOOL</c> value to <c>TRUE</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsprov/nf-vsprov-ivsshardwaresnapshotprovider-fillinluninfo HRESULT
		// FillInLunInfo( [in] VSS_PWSZ wszDeviceName, [in, out] VDS_LUN_INFORMATION *pLunInfo, [out] BOOL *pbIsSupported );
		[PreserveSig]
		HRESULT FillInLunInfo([MarshalAs(UnmanagedType.LPWStr)] string wszDeviceName, ref VDS_LUN_INFORMATION pLunInfo,
			[MarshalAs(UnmanagedType.Bool)] out bool pbIsSupported);

		/// <summary>
		/// <para>The <c>BeginPrepareSnapshot</c> method is called for each shadow copy that is added to the shadow copy set.</para>
		/// <para><c>Note</c> Hardware providers are only supported on Windows Server operating systems.</para>
		/// </summary>
		/// <param name="SnapshotSetId">Shadow copy set identifier.</param>
		/// <param name="SnapshotId">Identifier of the shadow copy to be created.</param>
		/// <param name="lContext">Shadow copy context for current shadow copy set as enumerated by _VSS_VOLUME_SNAPSHOT_ATTRIBUTES.</param>
		/// <param name="lLunCount">Count of LUNs contributing to this shadow copy volume.</param>
		/// <param name="rgDeviceNames">
		/// Pointer to array of <c>lLunCount</c> pointers to strings, each string containing the name of a LUN to be shadow copied.
		/// </param>
		/// <param name="rgLunInformation">
		/// Pointer to array of <c>lLunCount</c> VDS_LUN_INFORMATION structures, one for each LUN contributing to this shadow copy volume.
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c><c>S_OK</c></c> 0x00000000L</term>
		/// <term>The operation was successfully completed.</term>
		/// </item>
		/// <item>
		/// <term><c><c>E_OUTOFMEMORY</c></c> 0x8007000EL</term>
		/// <term>Out of memory or other system resources.</term>
		/// </item>
		/// <item>
		/// <term><c>E_INVALIDARG</c> 0x80070057L</term>
		/// <term>One of the parameter values is not valid.</term>
		/// </item>
		/// <item>
		/// <term><c><c>VSS_E_MAXIMUM_NUMBER_OF_VOLUMES_REACHED</c></c> 0x80042312L</term>
		/// <term>The provider has reached the maximum number of volumes it can support.</term>
		/// </item>
		/// <item>
		/// <term><c>VSS_E_NESTED_VOLUME_LIMIT</c></term>
		/// <term>
		/// The specified volume is nested too deeply to participate in the VSS operation. <c>Windows Server 2008, Windows Vista, Windows
		/// Server 2003 and Windows XP:</c> This return code is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c><c>VSS_E_PROVIDER_VETO</c></c> 0x80042306L</term>
		/// <term>
		/// An unexpected provider error occurred. The provider must report an event in the application event log providing the user with
		/// information on how to resolve the problem.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c><c>VSS_E_VOLUME_NOT_SUPPORTED_BY_PROVIDER</c></c> 0x8004230EL</term>
		/// <term>The provider does not support this volume.</term>
		/// </item>
		/// <item>
		/// <term><c><c>VSS_E_UNSUPPORTED_CONTEXT</c></c> 0x8004231BL</term>
		/// <term>The context specified by <c>lContext</c> is not supported.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>This method cannot be called for a virtual hard disk (VHD) that is nested inside another VHD.</para>
		/// <para><c>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:</c> VHDs are not supported.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsprov/nf-vsprov-ivsshardwaresnapshotprovider-beginpreparesnapshot HRESULT
		// BeginPrepareSnapshot( [in] VSS_ID SnapshotSetId, [in] VSS_ID SnapshotId, [in] LONG lContext, [in] LONG lLunCount, [in] VSS_PWSZ
		// *rgDeviceNames, [in, out] VDS_LUN_INFORMATION *rgLunInformation );
		[PreserveSig]
		HRESULT BeginPrepareSnapshot(Guid SnapshotSetId, Guid SnapshotId, VSS_VOLUME_SNAPSHOT_ATTRIBUTES lContext, int lLunCount,
			[In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr, SizeParamIndex = 3)] string[] rgDeviceNames,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] VDS_LUN_INFORMATION[] rgLunInformation);

		/// <summary>
		/// <para>
		/// The <c>GetTargetLuns</c> method prompts the hardware provider to initialize the VDS_LUN_INFORMATION structures for the newly
		/// created shadow copy LUNs. The <c>GetTargetLuns</c> method is called after the IVssProviderCreateSnapshotSet::PostCommitSnapshots
		/// method. Identifying information for each newly created LUN is returned to VSS through VDS_LUN_INFORMATION structures.
		/// </para>
		/// <para><c>Note</c> Hardware providers are only supported on Windows Server operating systems.</para>
		/// </summary>
		/// <param name="lLunCount">Count of LUNs that contribute to the original volume.</param>
		/// <param name="rgDeviceNames">
		/// Pointer to an array of <c>lLunCount</c> pointers to strings. Each string contains the name of an original LUN to be shadow copied.
		/// </param>
		/// <param name="rgSourceLuns">
		/// Pointer to an array of <c>lLunCount</c> VDS_LUN_INFORMATION structures, one for each LUN that contributes to the original volume.
		/// </param>
		/// <param name="rgDestinationLuns">
		/// Pointer to an array of <c>lLunCount</c> VDS_LUN_INFORMATION structures, one for each new shadow copy LUN created during shadow
		/// copy processing. There should be a one-to-one correspondence between the elements of the <c>rgSourceLuns</c> and
		/// <c>rgDestinationLuns</c> arrays.
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c><c>S_OK</c></c> 0x00000000L</term>
		/// <term>The operation was successfully completed.</term>
		/// </item>
		/// <item>
		/// <term><c><c>E_OUTOFMEMORY</c></c> 0x8007000EL</term>
		/// <term>Out of memory or other system resources.</term>
		/// </item>
		/// <item>
		/// <term><c>E_INVALIDARG</c> 0x80070057L</term>
		/// <term>One of the parameter values is not valid.</term>
		/// </item>
		/// <item>
		/// <term><c><c>VSS_E_PROVIDER_VETO</c></c> 0x80042306L</term>
		/// <term>
		/// An unexpected provider error occurred. The provider must report an event in the application event log providing the user with
		/// information on how to resolve the problem.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// In the <c>rgDestinationLuns</c> parameter, VSS supplies an empty VDS_LUN_INFORMATION structure for each newly created shadow
		/// copy LUN. The shadow copy LUNs are not surfaced or visible to the system. The provider should initialize the members of the
		/// <c>VDS_LUN_INFORMATION</c> structure with the appropriate SCSI Inquiry Data and Vital Product Data page 80 (device serial
		/// number) and page 83 (device identity) information. The structure should contain correct member values such that the shadow copy
		/// LUNs can be located by Windows from the original computer or any other computer connected to the SAN.
		/// </para>
		/// <para>The members of the VDS_LUN_INFORMATION structure correspond to the page 80 information, with the following exceptions:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>The <c>m_version</c> member must be set to <c>VER_VDS_LUN_INFORMATION</c>.</term>
		/// </item>
		/// <item>
		/// <term>
		/// The <c>m_BusType</c> member is ignored in comparisons during import. This value depends on the PnP storage stack on the
		/// corresponding disk device. Usually this is <c>VDSBusTypeScsi</c>.
		/// </term>
		/// </item>
		/// <item>
		/// <term>The <c>m_diskSignature</c> member is ignored in comparisons during import. The provider must set this member to GUID_NULL.</term>
		/// </item>
		/// </list>
		/// <para>
		/// The members of the VDS_STORAGE_DEVICE_ID_DESCRIPTOR structure (in the <c>m_deviceIdDescriptor</c> member of the
		/// VDS_LUN_INFORMATION structure) correspond to the page 83 information. In this structure, each VDS_STORAGE_IDENTIFIER structure
		/// corresponds to the STORAGE_IDENTIFIER structure for a device identifier (that is, a storage identifier with an association type
		/// of zero). For more information about the STORAGE_IDENTIFIER structure, see the Windows Driver Kit (WDK) documentation.
		/// </para>
		/// <para>
		/// The VDS_LUN_INFORMATION structures returned here must be the same as the structures provided in the
		/// IVssHardwareSnapshotProvider::FillInLunInfo method during import so that VSS can use this information to identify the newly
		/// arriving shadow copy LUNs at import. These same structures will be passed to the provider in the
		/// IVssHardwareSnapshotProvider::LocateLuns method.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsprov/nf-vsprov-ivsshardwaresnapshotprovider-gettargetluns HRESULT
		// GetTargetLuns( [in] LONG lLunCount, [in] VSS_PWSZ *rgDeviceNames, [in] VDS_LUN_INFORMATION *rgSourceLuns, [in, out]
		// VDS_LUN_INFORMATION *rgDestinationLuns );
		[PreserveSig]
		HRESULT GetTargetLuns(int lLunCount,
			[In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr, SizeParamIndex = 0)] string[] rgDeviceNames,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] VDS_LUN_INFORMATION[] rgSourceLuns,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] VDS_LUN_INFORMATION[] rgDestinationLuns);

		/// <summary>
		/// <para>
		/// The <c>LocateLuns</c> method prompts the hardware provider to make the shadow copy LUNs visible to the computer. The
		/// <c>LocateLuns</c> method is called by VSS when a hardware shadow copy set is imported to a computer. The provider is responsible
		/// for any unmasking (or "surfacing") at the hardware level.
		/// </para>
		/// <para><c>Note</c> Hardware providers are only supported on Windows Server operating systems.</para>
		/// </summary>
		/// <param name="lLunCount">Number of LUNs that contribute to this shadow copy set.</param>
		/// <param name="rgSourceLuns">
		/// Pointer to an array of <c>iLunCount</c> VDS_LUN_INFORMATION structures, one for each LUN that is part of the shadow copy set to
		/// be imported.
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c><c>S_OK</c></c> 0x00000000L</term>
		/// <term>The operation was successfully completed.</term>
		/// </item>
		/// <item>
		/// <term><c><c>E_OUTOFMEMORY</c></c> 0x8007000EL</term>
		/// <term>Out of memory or other system resources.</term>
		/// </item>
		/// <item>
		/// <term><c>E_INVALIDARG</c> 0x80070057L</term>
		/// <term>One of the parameter values is not valid.</term>
		/// </item>
		/// <item>
		/// <term><c><c>VSS_E_PROVIDER_VETO</c></c> 0x80042306L</term>
		/// <term>
		/// An unexpected provider error occurred. The provider must report an event in the application event log providing the user with
		/// information on how to resolve the problem.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// In the <c>rgSourceLuns</c> parameter, VSS supplies the same array of VDS_LUN_INFORMATION structures that the provider previously
		/// initialized in its IVssHardwareSnapshotProvider::GetTargetLuns method. For each <c>VDS_LUN_INFORMATION</c> structure in the
		/// array, the provider should unmask (or "surface") the corresponding shadow copy LUN to the computer.
		/// </para>
		/// <para>
		/// Immediately after this method returns, VSS will perform a rescan and enumeration to detect any arrived devices. This causes any
		/// exposed LUNs to be discovered by the PnP manager. In parallel with listening for disk arrivals, VSS will also listen for hidden
		/// volume arrivals. VSS will stop listening after all volumes that contribute to a shadow copy set appear in the system or a
		/// time-out occurs. If some disk or volume devices fail to appear in this window, the requester will be told that only some of the
		/// shadow copies were imported by VSS returning <c>VSS_S_SOME_SNAPSHOTS_NOT_IMPORTED</c> to the requester. The requester will also
		/// receive the same error from VSS if the VDS_LUN_INFORMATION structures received from the GetTargetLuns and
		/// IVssHardwareSnapshotProvider::FillInLunInfo methods do not match.
		/// </para>
		/// <para>This method cannot be used to map shadow copy LUNs as read-only.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsprov/nf-vsprov-ivsshardwaresnapshotprovider-locateluns HRESULT LocateLuns(
		// [in] LONG lLunCount, [in] VDS_LUN_INFORMATION *rgSourceLuns );
		[PreserveSig]
		HRESULT LocateLuns(int lLunCount, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] VDS_LUN_INFORMATION[] rgSourceLuns);

		/// <summary>
		/// <para>
		/// The <c>OnLunEmpty</c> method is called whenever VSS determines that a shadow copy LUN contains no interesting data. All shadow
		/// copies have been deleted (which also causes deletion of the LUN.) The LUN resources may be reclaimed by the provider and reused
		/// for another purpose. VSS will dismount any affected volumes. A provider should not issue a rescan during <c>OnLunEmpty</c>. VSS
		/// will handle this cleanup.
		/// </para>
		/// <para><c>Note</c> Hardware providers are only supported on Windows Server operating systems.</para>
		/// </summary>
		/// <param name="wszDeviceName">Device corresponding to the LUN that contains the shadow copy to be deleted.</param>
		/// <param name="pInformation">
		/// Pointer to a VDS_LUN_INFORMATION structure containing information about the LUN containing the shadow copy to be deleted.
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c><c>S_OK</c></c> 0x00000000L</term>
		/// <term>The operation was successfully completed.</term>
		/// </item>
		/// <item>
		/// <term><c><c>E_OUTOFMEMORY</c></c> 0x8007000EL</term>
		/// <term>Out of memory or other system resources.</term>
		/// </item>
		/// <item>
		/// <term><c>E_INVALIDARG</c> 0x80070057L</term>
		/// <term>One of the parameter values is not valid.</term>
		/// </item>
		/// <item>
		/// <term><c><c>VSS_E_PROVIDER_VETO</c></c> 0x80042306L</term>
		/// <term>
		/// An unexpected provider error occurred. The provider must report an event in the application event log providing the user with
		/// information on how to resolve the problem.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Hardware providers should delete a shadow copy and reclaim the LUN if and only if <c>OnLunEmpty</c> is being called. A hardware
		/// shadow copy may be used as the backup media itself, therefore the LUNs should be treated with the same care the storage array
		/// treats LUNs used for regular disks. Reclaiming LUNs outside of processing for <c>OnLunEmpty</c> should be limited to emergency
		/// or an administrator performing explicit action manually.
		/// </para>
		/// <para>
		/// In the case of persistent shadow copies, the requester deletes the shadow copy when it is no longer needed. In the case of
		/// nonpersistent auto-release shadow copies, the VSS service deletes the shadow copy when the requester calls IUnknown::Release on
		/// the IVssBackupComponents object. In the case of nonpersistent non-auto-release shadow copies, the VSS service deletes the shadow
		/// copy when the computer is restarted. In all cases, the VSS service calls the provider's <c>OnLunEmpty</c> method as needed for
		/// each shadow copy LUN.
		/// </para>
		/// <para>
		/// Note that <c>OnLunEmpty</c> is called on a best effort basis. VSS invokes the method only when the LUN is guaranteed to be
		/// empty. There may be many cases where the LUN is empty but VSS is unable to detect this due to errors or external circumstances.
		/// In this case, the user should use storage management software to clear this state.
		/// </para>
		/// <para>Some examples:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// When a shadow copy LUN is moved to a different host but not actually transported or imported through VSS, then that LUN appears
		/// as any other LUN, and volumes can be simply deleted without any notification of VSS.
		/// </term>
		/// </item>
		/// <item>
		/// <term>A crash or unexpected reboot in the middle of a shadow copy creation.</term>
		/// </item>
		/// <item>
		/// <term>A canceled import.</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsprov/nf-vsprov-ivsshardwaresnapshotprovider-onlunempty HRESULT OnLunEmpty(
		// [in] VSS_PWSZ wszDeviceName, [in] VDS_LUN_INFORMATION *pInformation );
		[PreserveSig]
		HRESULT OnLunEmpty([MarshalAs(UnmanagedType.LPWStr)] string wszDeviceName, in VDS_LUN_INFORMATION pInformation);
	}

	/// <summary>
	/// <para>
	/// Provides an additional method used by VSS to notify hardware providers of LUN state changes. All hardware providers must support
	/// this interface.
	/// </para>
	/// <para><c>Note</c> Hardware providers are only supported on Windows Server operating systems.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/vsprov/nn-vsprov-ivsshardwaresnapshotproviderex
	[PInvokeData("vsprov.h", MSDNShortId = "NN:vsprov.IVssHardwareSnapshotProviderEx")]
	[ComImport, Guid("7F5BA925-CDB1-4d11-A71F-339EB7E709FD"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IVssHardwareSnapshotProviderEx : IVssHardwareSnapshotProvider
	{
		/// <summary>
		/// <para>Not supported.</para>
		/// <para>This method is reserved for future use.</para>
		/// </summary>
		/// <param name="pllOriginalCapabilityMask">This parameter is reserved for future use.</param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsprov/nf-vsprov-ivsshardwaresnapshotproviderex-getprovidercapabilities
		// HRESULT GetProviderCapabilities( ULONGLONG *pllOriginalCapabilityMask );
		[PreserveSig]
		HRESULT GetProviderCapabilities(out ulong pllOriginalCapabilityMask);

		/// <summary>
		/// <para>The VSS service calls this method to notify hardware providers of a LUN state change.</para>
		/// <para><c>Note</c> Hardware providers are only supported on Windows Server operating systems.</para>
		/// </summary>
		/// <param name="pSnapshotLuns">
		/// A pointer to an array of <c>dwCount</c> VDS_LUN_INFORMATION structures, one for each LUN that contributes to the shadow copy volume.
		/// </param>
		/// <param name="pOriginalLuns">
		/// A pointer to an array of <c>dwCount</c> VDS_LUN_INFORMATION structures, one for each LUN that contributes to the original volume.
		/// </param>
		/// <param name="dwCount">
		/// Number of elements in the <c>pSnapshotLuns</c> array. This is also the number of elements in the <c>pOriginalLuns</c> array.
		/// </param>
		/// <param name="dwFlags">
		/// <para>
		/// A bitmask of _VSS_HARDWARE_OPTIONS flags that provide information about the state change that the shadow copy LUNs have
		/// undergone. The following table describes how each flag is used in this parameter.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>VSS_ONLUNSTATECHANGE_NOTIFY_READ_WRITE</c> 0x00000100</term>
		/// <term>The shadow copy LUN will be converted permanently to read-write.</term>
		/// </item>
		/// <item>
		/// <term><c>VSS_ONLUNSTATECHANGE_NOTIFY_LUN_PRE_RECOVERY</c> 0x00000200</term>
		/// <term>The shadow copy LUNs will be converted temporarily to read-write and are about to undergo TxF recovery or VSS auto-recovery.</term>
		/// </item>
		/// <item>
		/// <term><c>VSS_ONLUNSTATECHANGE_NOTIFY_LUN_POST_RECOVERY</c> 0x00000400</term>
		/// <term>The shadow copy LUNs have just undergone TxF recovery or VSS auto-recovery and have been converted back to read-only.</term>
		/// </item>
		/// <item>
		/// <term><c>VSS_ONLUNSTATECHANGE_DO_MASK_LUNS</c> 0x00000800</term>
		/// <term>The shadow copy LUNs must be masked from the current machine but not deleted.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c><c>S_OK</c></c> 0x00000000L</term>
		/// <term>The operation was successfully completed.</term>
		/// </item>
		/// <item>
		/// <term><c><c>E_OUTOFMEMORY</c></c> 0x8007000EL</term>
		/// <term>Out of memory or other system resources.</term>
		/// </item>
		/// <item>
		/// <term><c>E_INVALIDARG</c> 0x80070057L</term>
		/// <term>One of the parameter values is not valid.</term>
		/// </item>
		/// <item>
		/// <term><c><c>VSS_E_PROVIDER_VETO</c></c> 0x80042306L</term>
		/// <term>
		/// An unexpected provider error occurred. If this is returned, the error must be described in an entry in the application event
		/// log, giving the user information on how to resolve the problem.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsprov/nf-vsprov-ivsshardwaresnapshotproviderex-onlunstatechange HRESULT
		// OnLunStateChange( [in] VDS_LUN_INFORMATION *pSnapshotLuns, [in] VDS_LUN_INFORMATION *pOriginalLuns, [in] DWORD dwCount, [in]
		// DWORD dwFlags );
		[PreserveSig]
		HRESULT OnLunStateChange([In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] VDS_LUN_INFORMATION[] pSnapshotLuns,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] VDS_LUN_INFORMATION[] pOriginalLuns,
			uint dwCount, VSS_HARDWARE_OPTIONS dwFlags);

		/// <summary>The VSS service calls this method to notify hardware providers that a LUN resynchronization is needed.</summary>
		/// <param name="pSourceLuns">
		/// A pointer to an array of <c>dwCount</c> VDS_LUN_INFORMATION structures, one for each LUN that contributes to the shadow copy volume.
		/// </param>
		/// <param name="pTargetLuns">
		/// A pointer to an array of <c>dwCount</c> VDS_LUN_INFORMATION structures, one for each LUN that contributes to the destination
		/// volume where the contents of the shadow copy volume are to be copied.
		/// </param>
		/// <param name="dwCount">
		/// The number of elements in the <c>pSourceLuns</c> array. This is also the number of elements in the <c>pTargetLuns</c> array.
		/// </param>
		/// <param name="ppAsync">
		/// A pointer to a location that will receive an IVssAsync interface pointer that can be used to retrieve the status of the
		/// resynchronization operation. When the operation is complete, the caller must release the interface pointer by calling the
		/// IUnknown::Release method.
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c> 0x00000000L</term>
		/// <term>The operation was successfully completed.</term>
		/// </item>
		/// <item>
		/// <term><c>E_OUTOFMEMORY</c> 0x8007000EL</term>
		/// <term>Out of memory or other system resources.</term>
		/// </item>
		/// <item>
		/// <term><c>VSS_E_PROVIDER_VETO</c> 0x80042306L</term>
		/// <term>
		/// An unexpected provider error occurred. If this error code is returned, the error must be described in an entry in the
		/// application event log, giving the user information on how to resolve the problem.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>VSS_E_INSUFFICIENT_STORAGE</c> 0x8004231FL</term>
		/// <term>The provider cannot perform the operation because there is not enough disk space.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The destination LUNs can be the LUNs that contribute to the original production volume from which the shadow copy was created,
		/// or they can be new or existing LUNs that are used to replace an original volume that is removed from production.
		/// </para>
		/// <para>
		/// The provider must perform the resynchronization by copying data at the LUN array level, not at the host level. This means that
		/// the provider cannot implement LUN resynchronization by simply copying the contents of the source LUN to the destination LUN. The
		/// I/O that is required to perform the LUN resynchronization must be performed in the hardware, through the disk devices of the
		/// resynchronized LUNs, and not through the host computer. This I/O should be completely transparent to the host computer.
		/// </para>
		/// <para>When the resynchronization is complete, the LUNs are fully functional and are available for I/O operations.</para>
		/// <para>The underlying disk hardware must support unique page 83 device identifiers.</para>
		/// <para>
		/// If the destination LUN is larger than the source LUN, the provider must resize the destination LUN if necessary to ensure that
		/// it matches the source LUN after resynchronization.
		/// </para>
		/// <para>
		/// This method cannot be called in WinPE, and it cannot be called in Safe mode. Before calling this method, the caller must use the
		/// IVssBackupComponents::InitializeForRestore method to prepare for the resynchronization.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsprov/nf-vsprov-ivsshardwaresnapshotproviderex-resyncluns HRESULT ResyncLuns(
		// [in] VDS_LUN_INFORMATION *pSourceLuns, [in] VDS_LUN_INFORMATION *pTargetLuns, [in] DWORD dwCount, [out] IVssAsync **ppAsync );
		[PreserveSig]
		HRESULT ResyncLuns([In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] VDS_LUN_INFORMATION[] pSourceLuns,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] VDS_LUN_INFORMATION[] pTargetLuns, uint dwCount,
			out IVssAsync ppAsync);

		/// <summary>
		/// <para>Not supported.</para>
		/// <para>This method is reserved for future use.</para>
		/// </summary>
		/// <param name="pSnapshotLuns">This parameter is reserved for future use.</param>
		/// <param name="pOriginalLuns">This parameter is reserved for future use.</param>
		/// <param name="dwCount">This parameter is reserved for future use.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsprov/nf-vsprov-ivsshardwaresnapshotproviderex-onreuseluns HRESULT
		// OnReuseLuns( VDS_LUN_INFORMATION *pSnapshotLuns, VDS_LUN_INFORMATION *pOriginalLuns, DWORD dwCount );
		[PreserveSig]
		HRESULT OnReuseLuns([In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] VDS_LUN_INFORMATION[] pSnapshotLuns,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] VDS_LUN_INFORMATION[] pOriginalLuns,
			uint dwCount);
	}

	/// <summary>The <c>IVssProviderCreateSnapshotSet</c> interface contains the methods used during shadow copy creation.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/vsprov/nn-vsprov-ivssprovidercreatesnapshotset
	[PInvokeData("vsprov.h", MSDNShortId = "NN:vsprov.IVssProviderCreateSnapshotSet")]
	[ComImport, Guid("5F894E5B-1E39-4778-8E23-9ABAD9F0E08C"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IVssProviderCreateSnapshotSet
	{
		/// <summary>
		/// The <c>EndPrepareSnapshots</c> method is called once for the complete shadow copy set, after the last
		/// IVssHardwareSnapshotProvider::BeginPrepareSnapshot call. This method is intended as a point where the provider can wait for any
		/// shadow copy preparation work to complete. Because <c>EndPrepareSnapshots</c> may take a long time to complete, a provider should
		/// be prepared to accept an AbortSnapshots method call at any time and immediately end the preparation work.
		/// </summary>
		/// <param name="SnapshotSetId">The <c>VSS_ID</c> of the shadow copy set.</param>
		/// <returns>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c><c>S_OK</c></c> 0x00000000L</term>
		/// <term>The operation was successfully completed.</term>
		/// </item>
		/// <item>
		/// <term><c><c>E_OUTOFMEMORY</c></c> 0x8007000EL</term>
		/// <term>Out of memory or other system resources.</term>
		/// </item>
		/// <item>
		/// <term><c>E_INVALIDARG</c> 0x80070057L</term>
		/// <term>One of the parameter values is not valid.</term>
		/// </item>
		/// <item>
		/// <term><c><c>VSS_E_INSUFFICIENT_STORAGE</c></c> 0x8004231FL</term>
		/// <term>
		/// There is not enough disk storage to create a shadow copy. Insufficient disk space can also generate <c>VSS_E_PROVIDER_VETO</c>
		/// or <c>VSS_E_OBJECT_NOT_FOUND</c> error return values.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c><c>VSS_E_OBJECT_NOT_FOUND</c></c> 0x80042308L</term>
		/// <term>The <c>SnapshotSetId</c> parameter refers to an object that was not found.</term>
		/// </item>
		/// <item>
		/// <term><c><c>VSS_E_PROVIDER_VETO</c></c> 0x80042306L</term>
		/// <term>
		/// An unexpected provider error occurred. If this is returned, the error must be described in an entry in the application event
		/// log, giving the user information on how to resolve the problem.
		/// </term>
		/// </item>
		/// </list>
		/// <para>If any other value is returned, VSS will write an event to the event log and convert the error to <c>VSS_E_UNEXPECTED_PROVIDER_ERROR</c>.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsprov/nf-vsprov-ivssprovidercreatesnapshotset-endpreparesnapshots HRESULT
		// EndPrepareSnapshots( [in] VSS_ID SnapshotSetId );
		[PreserveSig]
		HRESULT EndPrepareSnapshots(Guid SnapshotSetId);

		/// <summary>
		/// The <c>PreCommitSnapshots</c> method ensures the provider is ready to quickly commit the prepared LUNs. This happens immediately
		/// before the flush-and-hold writes, but while applications are in a frozen state. During this call the provider should prepare all
		/// shadow copies in the shadow copy set indicated by <c>SnapshotSetId</c> for committing by the CommitSnapshots method call that
		/// will follow. While the provider is processing this method, the applications have been frozen, so the time spent in this method
		/// should be minimized.
		/// </summary>
		/// <param name="SnapshotSetId">The <c>VSS_ID</c> that identifies the shadow copy set.</param>
		/// <returns>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c><c>S_OK</c></c> 0x00000000L</term>
		/// <term>The operation was successfully completed.</term>
		/// </item>
		/// <item>
		/// <term><c><c>E_OUTOFMEMORY</c></c> 0x8007000EL</term>
		/// <term>Out of memory or other system resources.</term>
		/// </item>
		/// <item>
		/// <term><c>E_INVALIDARG</c> 0x80070057L</term>
		/// <term>One of the parameter values is not valid.</term>
		/// </item>
		/// <item>
		/// <term><c><c>VSS_E_OBJECT_NOT_FOUND</c></c> 0x80042308L</term>
		/// <term>The <c>SnapshotSetId</c> parameter refers to an object that was not found.</term>
		/// </item>
		/// <item>
		/// <term><c><c>VSS_E_PROVIDER_VETO</c></c> 0x80042306L</term>
		/// <term>
		/// An unexpected provider error occurred. If this is returned, the error must be described in an entry in the application event
		/// log, giving the user information on how to resolve the problem.
		/// </term>
		/// </item>
		/// </list>
		/// <para>If any other value is returned, VSS will write an event to the event log and convert the error to <c>VSS_E_UNEXPECTED_PROVIDER_ERROR</c>.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsprov/nf-vsprov-ivssprovidercreatesnapshotset-precommitsnapshots HRESULT
		// PreCommitSnapshots( [in] VSS_ID SnapshotSetId );
		[PreserveSig]
		HRESULT PreCommitSnapshots(Guid SnapshotSetId);

		/// <summary>The <c>CommitSnapshots</c> method quickly commits all LUNs in this provider.</summary>
		/// <param name="SnapshotSetId">The <c>VSS_ID</c> that identifies the shadow copy set.</param>
		/// <returns>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c><c>S_OK</c></c> 0x00000000L</term>
		/// <term>The operation was successfully completed.</term>
		/// </item>
		/// <item>
		/// <term><c><c>E_OUTOFMEMORY</c></c> 0x8007000EL</term>
		/// <term>Out of memory or other system resources.</term>
		/// </item>
		/// <item>
		/// <term><c>E_INVALIDARG</c> 0x80070057L</term>
		/// <term>One of the parameter values is not valid.</term>
		/// </item>
		/// <item>
		/// <term><c><c>VSS_E_OBJECT_NOT_FOUND</c></c> 0x80042308L</term>
		/// <term>The <c>SnapshotSetId</c> parameter refers to an object that was not found.</term>
		/// </item>
		/// <item>
		/// <term><c><c>VSS_E_PROVIDER_VETO</c></c> 0x80042306L</term>
		/// <term>An unexpected provider error occurred. The provider must log the details of this error in the application event log.</term>
		/// </item>
		/// </list>
		/// <para>If any other value is returned, VSS will write an event to the event log and convert the error to <c>VSS_E_UNEXPECTED_PROVIDER_ERROR</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method is called at the defined time at which the shadow copies should be taken. For each prepared LUN in this shadow copy
		/// set, the provider will perform the work required to persist the point-in-time LUN contents. While this method is executing, both
		/// applications and the I/O subsystem are largely quiescent. The provider must minimize the amount of time spent in this method. As
		/// a general rule, this method should take less than one second to complete. This method is called during the Flush and Hold
		/// window, and VSS Kernel Support will cancel the Flush and Hold if the release is not received within 10 seconds, which would
		/// cause VSS to fail the shadow copy creation process. If each provider takes more than a second or two to complete this call,
		/// there is a high probability that the entire shadow copy creation will fail.
		/// </para>
		/// <para>
		/// Because the I/O system is quiescent, the provider must take care to not initiate any I/O as it could deadlock the system - for
		/// example debug or tracing I/O by this method or any calls made from this method. Memory mapped files and paging I/O will not be
		/// frozen at this time.
		/// </para>
		/// <para>
		/// Note that the I/O system is quiescent only while this method is executing. Immediately after the last provider's
		/// <c>CommitSnapshots</c> method returns, the VSS service releases all pending writes on the source LUNs. If the provider performs
		/// any synchronization of the source and shadow copy LUNs, this synchronization must be completed before the provider's
		/// <c>CommitSnapshots</c> method returns; it cannot be performed asynchronously.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsprov/nf-vsprov-ivssprovidercreatesnapshotset-commitsnapshots HRESULT
		// CommitSnapshots( [in] VSS_ID SnapshotSetId );
		[PreserveSig]
		HRESULT CommitSnapshots(Guid SnapshotSetId);

		/// <summary>
		/// The <c>PostCommitSnapshots</c> method is called after all providers involved in the shadow copy set have succeeded with
		/// CommitSnapshots. The lock on the I/O system has been lifted, but the applications have not yet been unfrozen. This is an
		/// opportunity for the provider to perform additional cleanup work after the shadow copy commit.
		/// </summary>
		/// <param name="SnapshotSetId">The <c>VSS_ID</c> that identifies the shadow copy set.</param>
		/// <param name="lSnapshotsCount">Count of shadow copies in the shadow copy set.</param>
		/// <returns>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c><c>S_OK</c></c> 0x00000000L</term>
		/// <term>The operation was successfully completed.</term>
		/// </item>
		/// <item>
		/// <term><c><c>E_OUTOFMEMORY</c></c> 0x8007000EL</term>
		/// <term>Out of memory or other system resources.</term>
		/// </item>
		/// <item>
		/// <term><c>E_INVALIDARG</c> 0x80070057L</term>
		/// <term>One of the parameter values is not valid.</term>
		/// </item>
		/// <item>
		/// <term><c><c>VSS_E_OBJECT_NOT_FOUND</c></c> 0x80042308L</term>
		/// <term>The <c>SnapshotSetId</c> parameter refers to an object that was not found.</term>
		/// </item>
		/// <item>
		/// <term><c><c>VSS_E_PROVIDER_VETO</c></c> 0x80042306L</term>
		/// <term>
		/// An unexpected provider error occurred. If this is returned, the error must be described in an entry in the application event
		/// log, giving the user information on how to resolve the problem.
		/// </term>
		/// </item>
		/// </list>
		/// <para>If any other value is returned, VSS will write an event to the event log and convert the error to <c>VSS_E_UNEXPECTED_PROVIDER_ERROR</c>.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsprov/nf-vsprov-ivssprovidercreatesnapshotset-postcommitsnapshots HRESULT
		// PostCommitSnapshots( [in] VSS_ID SnapshotSetId, [in] LONG lSnapshotsCount );
		[PreserveSig]
		HRESULT PostCommitSnapshots(Guid SnapshotSetId, int lSnapshotsCount);

		/// <summary>
		/// The <c>PreFinalCommitSnapshots</c> method enables providers to support auto-recover shadow copies. If the shadow copy has the
		/// <c>VSS_VOLSNAP_ATTR_AUTORECOVER</c> flag set in the context, the volume can receive a large number of writes during the
		/// auto-recovery operation.
		/// </summary>
		/// <param name="SnapshotSetId">The <c>VSS_ID</c> that identifies the shadow copy set.</param>
		/// <returns>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c><c>S_OK</c></c> 0x00000000L</term>
		/// <term>The operation was successfully completed.</term>
		/// </item>
		/// <item>
		/// <term><c><c>E_OUTOFMEMORY</c></c> 0x8007000EL</term>
		/// <term>Out of memory or other system resources.</term>
		/// </item>
		/// <item>
		/// <term><c>E_INVALIDARG</c> 0x80070057L</term>
		/// <term>One of the parameter values is not valid.</term>
		/// </item>
		/// <item>
		/// <term><c><c>VSS_E_PROVIDER_VETO</c></c> 0x80042306L</term>
		/// <term>
		/// An unexpected provider error occurred. If this is returned, the error must be described in an entry in the application event
		/// log, giving the user information on how to resolve the problem.
		/// </term>
		/// </item>
		/// </list>
		/// <para>If any other value is returned, VSS will write an event to the event log and convert the error to <c>VSS_E_UNEXPECTED_PROVIDER_ERROR</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method was added to enable binary compatibility when the auto-recover feature was introduced in Windows Server 2003 with
		/// Service Pack 1 (SP1).
		/// </para>
		/// <para>
		/// <c>Note</c> For Windows Server 2003, it is recommended that hardware providers implement this method using the following example:
		/// </para>
		/// <para>
		/// <code>HRESULT PreFinalCommitSnapshots( VSS_ID /* SnapshotSetId */ ) { return S_OK; }</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsprov/nf-vsprov-ivssprovidercreatesnapshotset-prefinalcommitsnapshots HRESULT
		// PreFinalCommitSnapshots( [in] VSS_ID SnapshotSetId );
		[PreserveSig]
		HRESULT PreFinalCommitSnapshots(Guid SnapshotSetId);

		/// <summary>
		/// The <c>PostFinalCommitSnapshots</c> method supports auto-recover shadow copies. VSS calls this method to notify the provider
		/// that the volume will now be read-only until a requester calls IVssBackupComponents::BreakSnapshotSet.
		/// </summary>
		/// <param name="SnapshotSetId">The <c>VSS_ID</c> that identifies the shadow copy set.</param>
		/// <returns>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c><c>S_OK</c></c> 0x00000000L</term>
		/// <term>The operation was successfully completed.</term>
		/// </item>
		/// <item>
		/// <term><c><c>E_OUTOFMEMORY</c></c> 0x8007000EL</term>
		/// <term>Out of memory or other system resources.</term>
		/// </item>
		/// <item>
		/// <term><c>E_INVALIDARG</c> 0x80070057L</term>
		/// <term>One of the parameter values is not valid.</term>
		/// </item>
		/// <item>
		/// <term><c><c>VSS_E_PROVIDER_VETO</c></c> 0x80042306L</term>
		/// <term>
		/// An unexpected provider error occurred. If this is returned, the error must be described in an entry in the application event
		/// log, giving the user information on how to resolve the problem.
		/// </term>
		/// </item>
		/// </list>
		/// <para>If any other value is returned, VSS will write an event to the event log and convert the error to <c>VSS_E_UNEXPECTED_PROVIDER_ERROR</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method was added in Windows Server 2003 to enable binary compatibility when the auto-recover feature was introduced in
		/// Windows Server 2003 with Service Pack 1 (SP1).
		/// </para>
		/// <para>
		/// <c>Note</c> For Windows Server 2003, it is recommended that hardware providers implement this method using the following example:
		/// </para>
		/// <para>
		/// <code>HRESULT PostFinalCommitSnapshots( VSS_ID /* SnapshotSetId */ ) { return S_OK; }</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsprov/nf-vsprov-ivssprovidercreatesnapshotset-postfinalcommitsnapshots
		// HRESULT PostFinalCommitSnapshots( [in] VSS_ID SnapshotSetId );
		[PreserveSig]
		HRESULT PostFinalCommitSnapshots(Guid SnapshotSetId);

		/// <summary>
		/// The <c>AbortSnapshots</c> method aborts prepared shadow copies in this provider. This includes all non-committed shadow copies
		/// and pre-committed ones.
		/// </summary>
		/// <param name="SnapshotSetId">The <c>VSS_ID</c> that identifies the shadow copy set.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c><c>S_OK</c></c> 0x00000000L</term>
		/// <term>The operation was successfully completed.</term>
		/// </item>
		/// <item>
		/// <term><c><c>E_OUTOFMEMORY</c></c> 0x8007000EL</term>
		/// <term>Out of memory or other system resources.</term>
		/// </item>
		/// <item>
		/// <term><c>E_INVALIDARG</c> 0x80070057L</term>
		/// <term>One of the parameter values is not valid.</term>
		/// </item>
		/// <item>
		/// <term><c><c>VSS_E_OBJECT_NOT_FOUND</c></c> 0x80042308L</term>
		/// <term>The <c>SnapshotSetId</c> parameter refers to an object that was not found.</term>
		/// </item>
		/// <item>
		/// <term><c><c>VSS_E_PROVIDER_VETO</c></c> 0x80042306L</term>
		/// <term>
		/// An unexpected provider error occurred. The provider must log a message in the application event log providing the user with
		/// information on how to resolve the problem.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// VSS will only call <c>AbortSnapshots</c> after the requester has called IVssBackupComponents::DoSnapshotSet, even if the shadow
		/// copy fails or is aborted before this point. This means that a provider will not receive an <c>AbortSnapshots</c> call until
		/// after EndPrepareSnapshots has been called. If a shadow copy is aborted or fails before this point, the provider is not given any
		/// indication until a new shadow copy is started. For this reason, the provider must be prepared to handle an out-of-sequence
		/// IVssHardwareSnapshotProvider::BeginPrepareSnapshot call at any point. This out-of-sequence call represents the start of a new
		/// shadow copy creation sequence and will have a new shadow copy set ID.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsprov/nf-vsprov-ivssprovidercreatesnapshotset-abortsnapshots HRESULT
		// AbortSnapshots( [in] VSS_ID SnapshotSetId );
		[PreserveSig]
		HRESULT AbortSnapshots(Guid SnapshotSetId);
	}

	/// <summary>The <c>IVssProviderNotifications</c> interface manages providers registered with VSS.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/vsprov/nn-vsprov-ivssprovidernotifications
	[PInvokeData("vsprov.h", MSDNShortId = "NN:vsprov.IVssProviderNotifications")]
	[ComImport, Guid("E561901F-03A5-4afe-86D0-72BAEECE7004"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IVssProviderNotifications
	{
		/// <summary>The <c>OnLoad</c> method notifies a provider that it was loaded.</summary>
		/// <param name="pCallback">This parameter is reserved.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c><c>S_OK</c></c> 0x00000000L</term>
		/// <term>The operation was successfully completed.</term>
		/// </item>
		/// <item>
		/// <term><c><c>E_OUTOFMEMORY</c></c> 0x8007000EL</term>
		/// <term>Out of memory or other system resources.</term>
		/// </item>
		/// <item>
		/// <term><c>E_INVALIDARG</c> 0x80070057L</term>
		/// <term>One of the parameter values is not valid.</term>
		/// </item>
		/// <item>
		/// <term><c><c>VSS_E_PROVIDER_VETO</c></c> 0x80042306L</term>
		/// <term>
		/// An unexpected provider error occurred. If this is returned, the error must be described in an entry in the application event
		/// log, giving the user information on how to resolve the problem.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsprov/nf-vsprov-ivssprovidernotifications-onload HRESULT OnLoad( [in]
		// IUnknown *pCallback );
		[PreserveSig]
		HRESULT OnLoad([In, Optional, MarshalAs(UnmanagedType.IUnknown)] object pCallback);

		/// <summary>The <c>OnUnload</c> method notifies the provider to prepare to be unloaded.</summary>
		/// <param name="bForceUnload">If <c>TRUE</c>, the provider must prepare to be released.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c><c>S_OK</c></c> 0x00000000L</term>
		/// <term>There are no pending operations and the provider is ready to be released.</term>
		/// </item>
		/// <item>
		/// <term><c>S_FALSE</c> 0x00000001L</term>
		/// <term>The provider should not be unloaded. This value can only be returned if <c>bForceUnload</c> is <c>FALSE</c>.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>If <c>bForceUnload</c> is <c>TRUE</c>, the return value must be <c>S_OK</c>.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsprov/nf-vsprov-ivssprovidernotifications-onunload HRESULT OnUnload( [in]
		// BOOL bForceUnload );
		[PreserveSig]
		HRESULT OnUnload([MarshalAs(UnmanagedType.Bool)] bool bForceUnload);
	}

	/// <summary>Contains the methods used by VSS to manage shadow copy volumes. All software providers must support this interface.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/vsprov/nn-vsprov-ivsssoftwaresnapshotprovider
	[PInvokeData("vsprov.h", MSDNShortId = "NN:vsprov.IVssSoftwareSnapshotProvider")]
	[ComImport, Guid("609e123e-2c5a-44d3-8f01-0b1d9a47d1ff"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IVssSoftwareSnapshotProvider
	{
		/// <summary>Sets the context for subsequent shadow copy-related operations.</summary>
		/// <param name="lContext">
		/// The context to be set. The context must be one of the supported values of _VSS_SNAPSHOT_CONTEXT or a supported combination of
		/// _VSS_VOLUME_SNAPSHOT_ATTRIBUTES and <c>_VSS_SNAPSHOT_CONTEXT</c> values.
		/// </param>
		/// <returns>
		/// <para>The following are the valid return codes for this method.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The context was set successfully.</term>
		/// </item>
		/// <item>
		/// <term><c>E_ACCESSDENIED</c></term>
		/// <term>The caller does not have sufficient backup privileges or is not an administrator.</term>
		/// </item>
		/// <item>
		/// <term><c>E_INVALIDARG</c></term>
		/// <term>One of the parameter values is not valid.</term>
		/// </item>
		/// <item>
		/// <term><c>E_OUTOFMEMORY</c></term>
		/// <term>The caller is out of memory or other system resources.</term>
		/// </item>
		/// <item>
		/// <term><c>VSS_E_BAD_STATE</c></term>
		/// <term>The context is frozen and cannot be changed.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The default context for VSS shadow copies is VSS_CTX_BACKUP.</para>
		/// <para>
		/// <c>Windows XP:</c> The only supported context is the default context, VSS_CTX_BACKUP. Therefore, calling <c>SetContext</c> under
		/// Windows XP returns E_NOTIMPL.
		/// </para>
		/// <para>
		/// For more information about how the context that is set by <c>SetContext</c> affects how a shadow copy is created and managed,
		/// see Implementation Details for Creating Shadow Copies.
		/// </para>
		/// <para>For a complete discussion of the permitted shadow copy contexts, see _VSS_SNAPSHOT_CONTEXT and _VSS_VOLUME_SNAPSHOT_ATTRIBUTES.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsprov/nf-vsprov-ivsssoftwaresnapshotprovider-setcontext HRESULT SetContext(
		// [in] LONG lContext );
		[PreserveSig]
		HRESULT SetContext(VSS_SNAPSHOT_CONTEXT lContext);

		/// <summary>Gets the properties of the specified shadow copy.</summary>
		/// <param name="SnapshotId">Shadow copy identifier.</param>
		/// <param name="pProp">
		/// The address of a caller-allocated VSS_SNAPSHOT_PROP structure that receives the shadow copy properties. The provider is
		/// responsible for setting the members of this structure. All members are required except <c>m_pwszExposedName</c> and
		/// <c>m_pwszExposedPath</c>, which the provider can set to <c>NULL</c>. The provider allocates memory for all string members that
		/// it sets in the structure. When the structure is no longer needed, the caller is responsible for freeing these strings by calling
		/// the VssFreeSnapshotProperties function.
		/// </param>
		/// <returns>
		/// <para>The following are the valid return codes for this method.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The requested information was successfully returned.</term>
		/// </item>
		/// <item>
		/// <term><c>E_ACCESSDENIED</c></term>
		/// <term>The caller does not have sufficient backup privileges or is not an administrator.</term>
		/// </item>
		/// <item>
		/// <term><c>E_INVALIDARG</c></term>
		/// <term>One of the parameter values is not valid.</term>
		/// </item>
		/// <item>
		/// <term><c>E_OUTOFMEMORY</c></term>
		/// <term>The caller is out of memory or other system resources.</term>
		/// </item>
		/// <item>
		/// <term><c>VSS_E_OBJECT_NOT_FOUND</c></term>
		/// <term>The specified volume was not found.</term>
		/// </item>
		/// <item>
		/// <term><c>VSS_E_PROVIDER_VETO</c></term>
		/// <term>
		/// Provider error. The provider logged the error in the event log. For more information, see Event and Error Handling Under VSS.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>VSS_E_UNEXPECTED</c></term>
		/// <term>
		/// Unexpected error. The error code is logged in the error log file. For more information, see Event and Error Handling Under VSS.
		/// <c>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:</c> This value is not supported until Windows Server
		/// 2008 R2 and Windows 7. E_UNEXPECTED is used instead.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The caller should set the contents of the VSS_SNAPSHOT_PROP structure to zero before calling the <c>GetSnapshotProperties</c> method.
		/// </para>
		/// <para>The provider is responsible for allocating and freeing the strings in the VSS_SNAPSHOT_PROP structure.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsprov/nf-vsprov-ivsssoftwaresnapshotprovider-getsnapshotproperties HRESULT
		// GetSnapshotProperties( [in] VSS_ID SnapshotId, [out] VSS_SNAPSHOT_PROP *pProp );
		[PreserveSig]
		HRESULT GetSnapshotProperties(Guid SnapshotId, out VSS_SNAPSHOT_PROP pProp);

		/// <summary>Queries the provider for information about the shadow copies that the provider has completed.</summary>
		/// <param name="QueriedObjectId">Reserved for system use. The value of this parameter must be GUID_NULL.</param>
		/// <param name="eQueriedObjectType">Reserved for system use. The value of this parameter must be VSS_OBJECT_NONE.</param>
		/// <param name="eReturnedObjectsType">Reserved for system use. The value of this parameter must be VSS_OBJECT_SNAPSHOT.</param>
		/// <param name="ppEnum">
		/// The address of an IVssEnumObject interface pointer, which is initialized on return. Callers must release the interface. This
		/// parameter is required and cannot be null.
		/// </param>
		/// <returns>
		/// <para>The following are the valid return codes for this method.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The query operation was successful.</term>
		/// </item>
		/// <item>
		/// <term><c>E_ACCESSDENIED</c></term>
		/// <term>The caller does not have sufficient backup privileges or is not an administrator.</term>
		/// </item>
		/// <item>
		/// <term><c>E_INVALIDARG</c></term>
		/// <term>One of the parameter values is not valid.</term>
		/// </item>
		/// <item>
		/// <term><c>E_OUTOFMEMORY</c></term>
		/// <term>The caller is out of memory or other system resources.</term>
		/// </item>
		/// <item>
		/// <term><c>VSS_E_PROVIDER_VETO</c></term>
		/// <term>
		/// Provider error. The provider logged the error in the event log. For more information, see Event and Error Handling Under VSS.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// Calling the IVssEnumObject::Next method on the IVssEnumObject interface that is returned though the <c>ppEnum</c> parameter will
		/// return VSS_OBJECT_PROP structures containing a VSS_SNAPSHOT_PROP structure for each shadow copy.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsprov/nf-vsprov-ivsssoftwaresnapshotprovider-query HRESULT Query( [in] VSS_ID
		// QueriedObjectId, [in] VSS_OBJECT_TYPE eQueriedObjectType, [in] VSS_OBJECT_TYPE eReturnedObjectsType, [out] IVssEnumObject
		// **ppEnum );
		[PreserveSig]
		HRESULT Query(Guid QueriedObjectId, VSS_OBJECT_TYPE eQueriedObjectType, VSS_OBJECT_TYPE eReturnedObjectsType, out IVssEnumObject ppEnum);

		/// <summary>Deletes one or more shadow copies or a shadow copy set.</summary>
		/// <param name="SourceObjectId">Identifier of the shadow copy or shadow copy set to be deleted.</param>
		/// <param name="eSourceObjectType">Type of the object to be deleted. The value of this parameter is VSS_OBJECT_SNAPSHOT or VSS_OBJECT_SNAPSHOT_SET.</param>
		/// <param name="bForceDelete">
		/// If the value of this parameter is <c>TRUE</c>, the provider will do everything possible to delete the shadow copy or shadow
		/// copies in a shadow copy set. If it is <c>FALSE</c>, no additional effort will be made.
		/// </param>
		/// <param name="plDeletedSnapshots">Pointer to a variable that receives the number of shadow copies that were deleted.</param>
		/// <param name="pNondeletedSnapshotID">
		/// If an error occurs, this parameter receives a pointer to the identifier of the first shadow copy that could not be deleted.
		/// Otherwise, it points to GUID_NULL.
		/// </param>
		/// <returns>
		/// <para>The following are the valid return codes for this method.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The shadow copies were successfully deleted.</term>
		/// </item>
		/// <item>
		/// <term><c>E_ACCESSDENIED</c></term>
		/// <term>The caller does not have sufficient backup privileges or is not an administrator.</term>
		/// </item>
		/// <item>
		/// <term><c>E_INVALIDARG</c></term>
		/// <term>One of the parameter values is not valid.</term>
		/// </item>
		/// <item>
		/// <term><c>E_OUTOFMEMORY</c></term>
		/// <term>The caller is out of memory or other system resources.</term>
		/// </item>
		/// <item>
		/// <term><c>VSS_E_OBJECT_NOT_FOUND</c></term>
		/// <term>The specified shadow copies were not found.</term>
		/// </item>
		/// <item>
		/// <term><c>VSS_E_PROVIDER_VETO</c></term>
		/// <term>
		/// Provider error. The provider logged the error in the event log. For more information, see Event and Error Handling Under VSS.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// Multiple shadow copies in a shadow copy set are deleted sequentially. If an error occurs during one of these individual
		/// deletions, <c>DeleteSnapshots</c> will return immediately; no attempt will be made to delete any remaining shadow copies. The
		/// VSS_ID of the undeleted shadow copy is returned in <c>pNondeletedSnapshotID</c>.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsprov/nf-vsprov-ivsssoftwaresnapshotprovider-deletesnapshots HRESULT
		// DeleteSnapshots( [in] VSS_ID SourceObjectId, [in] VSS_OBJECT_TYPE eSourceObjectType, [in] BOOL bForceDelete, [out] LONG
		// *plDeletedSnapshots, [out] VSS_ID *pNondeletedSnapshotID );
		[PreserveSig]
		HRESULT DeleteSnapshots(Guid SourceObjectId, VSS_OBJECT_TYPE eSourceObjectType, [MarshalAs(UnmanagedType.Bool)] bool bForceDelete,
			out int plDeletedSnapshots, out Guid pNondeletedSnapshotID);

		/// <summary>VSS calls this method for each shadow copy that is added to the shadow copy set.</summary>
		/// <param name="SnapshotSetId">Shadow copy set identifier.</param>
		/// <param name="SnapshotId">Identifier of the shadow copy to be created.</param>
		/// <param name="pwszVolumeName">
		/// <para>
		/// Null-terminated wide character string containing the volume name. The name must be in one of the following formats and must
		/// include a trailing backslash (\):
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>The path of a mounted folder, for example, Y:\MountX\</term>
		/// </item>
		/// <item>
		/// <term>A drive letter, for example, D:\</term>
		/// </item>
		/// <item>
		/// <term>A volume GUID path of the form \\?\ <c>Volume</c>{ <c>GUID</c>}\ (where <c>GUID</c> identifies the volume)</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="lNewContext">
		/// The context for the shadow copy set. This context consists of a bitmask of _VSS_VOLUME_SNAPSHOT_ATTRIBUTES values.
		/// </param>
		/// <returns>
		/// <para>The following are the valid return codes for this method.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The shadow copy was successfully created.</term>
		/// </item>
		/// <item>
		/// <term><c>E_ACCESSDENIED</c></term>
		/// <term>The caller does not have sufficient backup privileges or is not an administrator.</term>
		/// </item>
		/// <item>
		/// <term><c>E_INVALIDARG</c></term>
		/// <term>One of the parameter values is not valid.</term>
		/// </item>
		/// <item>
		/// <term><c>E_OUTOFMEMORY</c></term>
		/// <term>The caller is out of memory or other system resources.</term>
		/// </item>
		/// <item>
		/// <term><c>VSS_E_OBJECT_NOT_FOUND</c></term>
		/// <term>The specified volume was not found.</term>
		/// </item>
		/// <item>
		/// <term><c>VSS_E_PROVIDER_VETO</c></term>
		/// <term>
		/// Provider error. The provider logged the error in the event log. For more information, see Event and Error Handling Under VSS.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>VSS_E_UNSUPPORTED_CONTEXT</c></term>
		/// <term>The specified context is not supported.</term>
		/// </item>
		/// <item>
		/// <term><c>VSS_E_VOLUME_NOT_SUPPORTED_BY_PROVIDER</c></term>
		/// <term>The provider does not support the specified volume.</term>
		/// </item>
		/// <item>
		/// <term><c>VSS_E_UNEXPECTED</c></term>
		/// <term>
		/// Unexpected error. The error code is logged in the error log file. For more information, see Event and Error Handling Under VSS.
		/// <c>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:</c> This value is not supported until Windows Server
		/// 2008 R2 and Windows 7. E_UNEXPECTED is used instead.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsprov/nf-vsprov-ivsssoftwaresnapshotprovider-beginpreparesnapshot HRESULT
		// BeginPrepareSnapshot( [in] VSS_ID SnapshotSetId, [in] VSS_ID SnapshotId, [in] VSS_PWSZ pwszVolumeName, [in] LONG lNewContext );
		[PreserveSig]
		HRESULT BeginPrepareSnapshot(Guid SnapshotSetId, Guid SnapshotId, [MarshalAs(UnmanagedType.LPWStr)] string pwszVolumeName,
			VSS_VOLUME_SNAPSHOT_ATTRIBUTES lNewContext);

		/// <summary>Determines whether the provider supports shadow copies on the specified volume.</summary>
		/// <param name="pwszVolumeName">
		/// <para>
		/// Null-terminated wide character string containing the volume name. The name must be in one of the following formats and must
		/// include a trailing backslash (\):
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>The path of a mounted folder, for example, Y:\MountX\</term>
		/// </item>
		/// <item>
		/// <term>A drive letter, for example, D:\</term>
		/// </item>
		/// <item>
		/// <term>A volume GUID path of the form \\?\ <c>Volume</c>{ <c>GUID</c>}\ (where <c>GUID</c> identifies the volume)</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pbSupportedByThisProvider">
		/// This parameter receives <c>TRUE</c> if shadow copies are supported on the specified volume, otherwise <c>FALSE</c>.
		/// </param>
		/// <returns>
		/// <para>The following are the valid return codes for this method.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The requested information was successfully returned.</term>
		/// </item>
		/// <item>
		/// <term><c>E_ACCESSDENIED</c></term>
		/// <term>The caller does not have sufficient backup privileges or is not an administrator.</term>
		/// </item>
		/// <item>
		/// <term><c>E_INVALIDARG</c></term>
		/// <term>One of the parameter values is not valid.</term>
		/// </item>
		/// <item>
		/// <term><c>VSS_E_NESTED_VOLUME_LIMIT</c></term>
		/// <term>
		/// The specified volume is nested too deeply to participate in the VSS operation. <c>Windows Server 2008, Windows Vista, Windows
		/// Server 2003 and Windows XP:</c> This return code is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>E_OUTOFMEMORY</c></term>
		/// <term>The caller is out of memory or other system resources.</term>
		/// </item>
		/// <item>
		/// <term><c>VSS_E_OBJECT_NOT_FOUND</c></term>
		/// <term>The specified volume was not found.</term>
		/// </item>
		/// <item>
		/// <term><c>VSS_E_PROVIDER_VETO</c></term>
		/// <term>
		/// Provider error. The provider logged the error in the event log. For more information, see Event and Error Handling Under VSS.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>VSS_E_UNEXPECTED</c></term>
		/// <term>
		/// Unexpected error. The error code is logged in the error log file. For more information, see Event and Error Handling Under VSS.
		/// <c>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:</c> This value is not supported until Windows Server
		/// 2008 R2 and Windows 7. E_UNEXPECTED is used instead.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>IsVolumeSupported</c> method will return <c>TRUE</c> if it is possible to create shadow copies on the given volume, even
		/// if the current configuration does not allow the creation of shadow copies on that volume at the present time.
		/// </para>
		/// <para>
		/// For example, if the maximum number of shadow copies has been reached on a given volume (and therefore no more shadow copies can
		/// be created on that volume), the method will still indicate that the volume can be shadow copied.
		/// </para>
		/// <para>This method cannot be called for a virtual hard disk (VHD) that is nested inside another VHD.</para>
		/// <para><c>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:</c> VHDs are not supported.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsprov/nf-vsprov-ivsssoftwaresnapshotprovider-isvolumesupported HRESULT
		// IsVolumeSupported( [in] VSS_PWSZ pwszVolumeName, [out] BOOL *pbSupportedByThisProvider );
		[PreserveSig]
		HRESULT IsVolumeSupported([MarshalAs(UnmanagedType.LPWStr)] string pwszVolumeName, [MarshalAs(UnmanagedType.Bool)] out bool pbSupportedByThisProvider);

		/// <summary>Determines whether any shadow copies exist for the specified volume.</summary>
		/// <param name="pwszVolumeName">
		/// <para>
		/// Null-terminated wide character string containing the volume name. The name must be in one of the following formats and must
		/// include a trailing backslash (\):
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>The path of a mounted folder, for example, Y:\MountX\</term>
		/// </item>
		/// <item>
		/// <term>A drive letter, for example, D:\</term>
		/// </item>
		/// <item>
		/// <term>A volume GUID path of the form \\?\ <c>Volume</c>{ <c>GUID</c>}\ (where GUID identifies the volume)</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pbSnapshotsPresent">
		/// This parameter receives <c>TRUE</c> if the volume has a shadow copy, or <c>FALSE</c> if the volume does not have a shadow copy.
		/// </param>
		/// <param name="plSnapshotCompatibility">
		/// A bitmask of VSS_SNAPSHOT_COMPATIBILITY values that indicate whether certain volume control or file I/O operations are disabled
		/// for the given volume, if the volume has a shadow copy.
		/// </param>
		/// <returns>
		/// <para>The following are the valid return codes for this method.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The requested information was successfully returned.</term>
		/// </item>
		/// <item>
		/// <term><c>E_ACCESSDENIED</c></term>
		/// <term>The caller does not have sufficient backup privileges or is not an administrator.</term>
		/// </item>
		/// <item>
		/// <term><c>E_INVALIDARG</c></term>
		/// <term>One of the parameter values is not valid.</term>
		/// </item>
		/// <item>
		/// <term><c>E_OUTOFMEMORY</c></term>
		/// <term>The caller is out of memory or other system resources.</term>
		/// </item>
		/// <item>
		/// <term><c>VSS_E_OBJECT_NOT_FOUND</c></term>
		/// <term>The specified volume was not found.</term>
		/// </item>
		/// <item>
		/// <term><c>VSS_E_PROVIDER_VETO</c></term>
		/// <term>
		/// Provider error. The provider logged the error in the event log. For more information, see Event and Error Handling Under VSS.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>VSS_E_UNEXPECTED</c></term>
		/// <term>
		/// Unexpected error. The error code is logged in the error log file. For more information, see Event and Error Handling Under VSS.
		/// <c>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:</c> This value is not supported until Windows Server
		/// 2008 R2 and Windows 7. E_UNEXPECTED is used instead.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// If no volume control or file I/O operations are disabled for the selected volume, then the shadow copy capability of the
		/// selected volume returned by <c>plSnapshotCapability</c> will be zero.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsprov/nf-vsprov-ivsssoftwaresnapshotprovider-isvolumesnapshotted HRESULT
		// IsVolumeSnapshotted( [in] VSS_PWSZ pwszVolumeName, [out] BOOL *pbSnapshotsPresent, [out] LONG *plSnapshotCompatibility );
		[PreserveSig]
		HRESULT IsVolumeSnapshotted([MarshalAs(UnmanagedType.LPWStr)] string pwszVolumeName, [MarshalAs(UnmanagedType.Bool)] out bool pbSnapshotsPresent,
			out VSS_SNAPSHOT_COMPATIBILITY plSnapshotCompatibility);

		/// <summary>Sets a property for a shadow copy.</summary>
		/// <param name="SnapshotId">Shadow copy identifier. This parameter is required and cannot be GUID_NULL.</param>
		/// <param name="eSnapshotPropertyId">A VSS_SNAPSHOT_PROPERTY_ID value that specifies the property to be set for the shadow copy.</param>
		/// <param name="vProperty">
		/// The value to be set for the property. See the VSS_SNAPSHOT_PROP structure for valid data types and descriptions of the
		/// properties that can be set for a shadow copy.
		/// </param>
		/// <returns>
		/// <para>The following are the valid return codes for this method.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The property was set successfully.</term>
		/// </item>
		/// <item>
		/// <term><c>E_ACCESSDENIED</c></term>
		/// <term>The caller does not have sufficient backup privileges or is not an administrator.</term>
		/// </item>
		/// <item>
		/// <term><c>E_INVALIDARG</c></term>
		/// <term>One of the parameter values is not valid.</term>
		/// </item>
		/// <item>
		/// <term><c>E_OUTOFMEMORY</c></term>
		/// <term>The caller is out of memory or other system resources.</term>
		/// </item>
		/// <item>
		/// <term><c>VSS_E_OBJECT_NOT_FOUND</c></term>
		/// <term>The specified shadow copy was not found.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsprov/nf-vsprov-ivsssoftwaresnapshotprovider-setsnapshotproperty HRESULT
		// SetSnapshotProperty( [in] VSS_ID SnapshotId, [in] VSS_SNAPSHOT_PROPERTY_ID eSnapshotPropertyId, [in] VARIANT vProperty );
		[PreserveSig]
		HRESULT SetSnapshotProperty(Guid SnapshotId, VSS_SNAPSHOT_PROPERTY_ID eSnapshotPropertyId, object vProperty);

		/// <summary>
		/// Reverts a volume to a previous shadow copy. Only shadow copies created with persistent contexts (VSS_CTX_APP_ROLLBACK,
		/// VSS_CTX_CLIENT_ACCESSIBLE, VSS_CTX_CLIENT_ACCESSIBLE_WRITERS, or VSS_CTX_NAS_ROLLBACK) are supported.
		/// </summary>
		/// <param name="SnapshotId">Shadow copy identifier of the shadow copy to revert.</param>
		/// <returns>
		/// <para>The following are the valid return codes for this method.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The revert operation was successful.</term>
		/// </item>
		/// <item>
		/// <term><c>E_ACCESSDENIED</c></term>
		/// <term>The caller does not have sufficient backup privileges or is not an administrator.</term>
		/// </item>
		/// <item>
		/// <term><c>E_INVALIDARG</c></term>
		/// <term>One of the parameter values is not valid.</term>
		/// </item>
		/// <item>
		/// <term><c>E_OUTOFMEMORY</c></term>
		/// <term>The caller is out of memory or other system resources.</term>
		/// </item>
		/// <item>
		/// <term><c><c>VSS_E_REVERT_IN_PROGRESS</c></c></term>
		/// <term>The volume already has a revert operation in process.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// This operation cannot be canceled, or undone once completed. If the computer is rebooted during the revert operation, the revert
		/// process will continue when the system is restarted.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsprov/nf-vsprov-ivsssoftwaresnapshotprovider-reverttosnapshot HRESULT
		// RevertToSnapshot( [in] VSS_ID SnapshotId );
		[PreserveSig]
		HRESULT RevertToSnapshot(Guid SnapshotId);

		/// <summary>Returns an IVssAsync interface pointer that can be used to determine the status of the revert operation.</summary>
		/// <param name="pwszVolume">
		/// <para>
		/// Null-terminated wide character string containing the volume name. The name must be in one of the following formats and must
		/// include a trailing backslash (\):
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>The path of a mounted folder, for example, Y:\MountX\</term>
		/// </item>
		/// <item>
		/// <term>A drive letter, for example, D:\</term>
		/// </item>
		/// <item>
		/// <term>A volume GUID path of the form \\?\ <c>Volume</c>{ <c>GUID</c>}\ (where <c>GUID</c> identifies the volume)</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="ppAsync">
		/// Pointer to a location that will receive an IVssAsync interface pointer that can be used to retrieve the status of the revert
		/// operation. When the operation is complete, the caller must release the interface pointer by calling the IUnknown::Release method.
		/// </param>
		/// <returns>
		/// <para>The following are the valid return codes for this method.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The status of the revert operation was successfully queried.</term>
		/// </item>
		/// <item>
		/// <term><c>E_ACCESSDENIED</c></term>
		/// <term>The caller does not have sufficient backup privileges or is not an administrator.</term>
		/// </item>
		/// <item>
		/// <term><c>E_INVALIDARG</c></term>
		/// <term>One of the parameter values is not valid.</term>
		/// </item>
		/// <item>
		/// <term><c>E_OUTOFMEMORY</c></term>
		/// <term>The caller is out of memory or other system resources.</term>
		/// </item>
		/// <item>
		/// <term><c><c>VSS_E_OBJECT_NOT_FOUND</c></c></term>
		/// <term>The <c>pwszVolume</c> parameter does not specify a valid volume.</term>
		/// </item>
		/// <item>
		/// <term><c><c>VSS_E_VOLUME_NOT_SUPPORTED</c></c></term>
		/// <term>The revert operation is not supported on this volume.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// The revert operation will continue even if the computer is rebooted, and cannot be canceled or undone, except by restoring a
		/// backup that was created using another method. The IVssAsync::QueryStatus method cannot return VSS_S_ASYNC_CANCELLED, because the
		/// revert operation cannot be canceled after it has started.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsprov/nf-vsprov-ivsssoftwaresnapshotprovider-queryrevertstatus HRESULT
		// QueryRevertStatus( [in] VSS_PWSZ pwszVolume, [out] IVssAsync **ppAsync );
		[PreserveSig]
		HRESULT QueryRevertStatus([MarshalAs(UnmanagedType.LPWStr)] string pwszVolume, out IVssAsync ppAsync);
	}
}