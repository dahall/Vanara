using static Vanara.PInvoke.AdvApi32;

namespace Vanara.PInvoke;

public static partial class Ole32
{
	/// <summary>
	/// The following values are used as flags in the access mask of an Access Control Entry (ACE) in a component-related security descriptor.
	/// </summary>
	// https://learn.microsoft.com/en-us/openspecs/windows_protocols/ms-coma/a7395012-15a8-4f7c-ada9-d16bef022be3
	[PInvokeData("combaseapi.h")]
	[Flags]
	public enum COM_RIGHTS : uint
	{
		/// <summary>
		/// In an OldVersionComponentAccessMask (section 2.2.2.21.1.2), this value represents a combination of all of the rights represented
		/// by COM_RIGHTS_EXECUTE_LOCAL, COM_RIGHTS_EXECUTE_REMOTE, COM_RIGHTS_ACTIVATE_LOCAL, and COM_RIGHTS_ACTIVATE_REMOTE.
		/// <para>
		/// In a NewVersionComponentAccessMask (section 2.2.2.21.1.3), this flag has no specific meaning but is required to be set for
		/// historical reasons.
		/// </para>
		/// </summary>
		COM_RIGHTS_EXECUTE = 0x00000001,

		/// <summary>
		/// In a NewVersionComponentAccessMask, this value represents the right of a security principal to use ORB-specific local mechanisms
		/// to cause a component to be executed, where the precise meaning of execute depends on the context.
		/// <para>
		/// In a component access security descriptor, this right controls whether or not a principal is authorized to execute method calls
		/// on component instances.
		/// </para>
		/// <para>
		/// In a component launch security descriptor, this right controls whether or not a principal is authorized to create a process in
		/// which the component will be hosted.
		/// </para>
		/// </summary>
		COM_RIGHTS_EXECUTE_LOCAL = 0x00000002,

		/// <summary>
		/// In a NewVersionComponentAccessMask, this value represents the right of a security principal to use ORB-specific remote mechanisms
		/// to cause a component to be executed, where the precise meaning of execute depends on the context.
		/// <para>
		/// In a component access security descriptor, this right controls whether or not a principal is authorized to execute method calls
		/// on component instances.
		/// </para>
		/// <para>
		/// In a component launch security descriptor, this right controls whether or not a principal is authorized to create a process in
		/// which the component will be hosted.
		/// </para>
		/// </summary>
		COM_RIGHTS_EXECUTE_REMOTE = 0x00000004,

		/// <summary>
		/// In a NewVersionComponentAccessMask, this value represents the right of a security principal to use ORB-specific local mechanisms
		/// to activate a component.
		/// <para>This right is meaningful only in a component launch security descriptor.</para>
		/// </summary>
		COM_RIGHTS_ACTIVATE_LOCAL = 0x00000008,

		/// <summary>
		/// In a NewVersionComponentAccessMask, this value represents the right of a security principal to use ORB-specific local mechanisms
		/// to activate a component.
		/// <para>This right is meaningful only in a component launch security descriptor.</para>
		/// </summary>
		COM_RIGHTS_ACTIVATE_REMOTE = 0x000000010,

		/// <summary></summary>
		COM_RIGHTS_RESERVED1 = 32,

		/// <summary></summary>
		COM_RIGHTS_RESERVED2 = 64,
	}

	/// <summary>Enables the management of access to objects and properties on the objects.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/iaccess/nn-iaccess-iaccesscontrol
	[PInvokeData("iaccess.h", MSDNShortId = "NN:iaccess.IAccessControl")]
	[ComImport, Guid("EEDD23E0-8410-11CE-A1C3-08002B2B8D8F"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAccessControl
	{
		/// <summary>Merges the new list of access rights with the existing access rights on the object.</summary>
		/// <param name="pAccessList">A pointer to the ACTRL_ACCESS structure that contains an array of access lists for the object.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// <para>
		/// Merging the new access rights list with the existing access rights ensures that the object will have at least the indicated
		/// access rights. This merge process consists of adding the new denied access rights before the old denied access rights, and
		/// the new allowed access rights before the existing allowed rights. None of the existing rights are removed.
		/// </para>
		/// <para>Following a merge, the access rights on an object are ordered as follows:</para>
		/// <list type="number">
		/// <item>
		/// <term>[New Access Denied]</term>
		/// </item>
		/// <item>
		/// <term>[Old Access Denied]</term>
		/// </item>
		/// <item>
		/// <term>[New Access Allowed]</term>
		/// </item>
		/// <item>
		/// <term>[Old Access Allowed]</term>
		/// </item>
		/// </list>
		/// <para>
		/// The system-supplied implementation of [ACTRL_ACCESS](../accctrl/ns-accctrl-explicit_access_a.md) structure be set to 1. In
		/// addition, the <c>lpProperty</c> member of the ACTRL_PROPERTY_ENTRYW structure must be <c>NULL</c> to indicate that the
		/// access entry list applies to the object itself.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/iaccess/nf-iaccess-iaccesscontrol-grantaccessrights HRESULT
		// GrantAccessRights( PACTRL_ACCESSW pAccessList );
		[PreserveSig]
		HRESULT GrantAccessRights(in EXPLICIT_ACCESS pAccessList);

		/// <summary>Replaces the existing access rights on an object with the specified list.</summary>
		/// <param name="pAccessList">
		/// A pointer to the ACTRL_ACCESS list that contains an array of access lists to be written to the object.
		/// </param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/iaccess/nf-iaccess-iaccesscontrol-setaccessrights HRESULT SetAccessRights(
		// PACTRL_ACCESSW pAccessList );
		[PreserveSig]
		HRESULT SetAccessRights(in EXPLICIT_ACCESS pAccessList);

		/// <summary>Sets the owner or the group of an item.</summary>
		/// <param name="pOwner">The address of the TRUSTEE structure for the owner.</param>
		/// <param name="pGroup">The address of the TRUSTEE structure for the group.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>The <c>SetOwner</c> method is not implemented by CLSID_DCOMAccessControl.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/iaccess/nf-iaccess-iaccesscontrol-setowner HRESULT SetOwner( PTRUSTEEW
		// pOwner, PTRUSTEEW pGroup );
		[PreserveSig]
		HRESULT SetOwner(in TRUSTEE pOwner, in TRUSTEE pGroup);

		/// <summary>Removes any explicit entries for the list of trustees.</summary>
		/// <param name="lpProperty">
		/// The name of the property. If you are using the COM implementation of IAccessControl, this parameter must be <c>NULL</c>.
		/// </param>
		/// <param name="cTrustees">The number of trustees in the list. This parameter cannot be 0.</param>
		/// <param name="prgTrustees">A pointer to an array of trustee names. See TRUSTEE.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>Even after removing explicit entries, the trustees might still have access entries due to group inclusion.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/iaccess/nf-iaccess-iaccesscontrol-revokeaccessrights HRESULT
		// RevokeAccessRights( StrPtrUni lpProperty, ULONG cTrustees, TRUSTEEW [] prgTrustees );
		[PreserveSig]
		HRESULT RevokeAccessRights([MarshalAs(UnmanagedType.LPWStr)] string? lpProperty, uint cTrustees,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] TRUSTEE[] prgTrustees);

		/// <summary>Gets the entire list of access rights and/or the owner and group for the specified object.</summary>
		/// <param name="lpProperty">
		/// The name of the property. If you are using the COM implementation of IAccessControl, this parameter must be <c>NULL</c>.
		/// </param>
		/// <param name="ppAccessList">
		/// <para>
		/// The address of the pointer variable that receives a pointer to the access list structure. This parameter cannot be ACTRL_ACCESS.
		/// </para>
		/// <para>
		/// If the call succeeds, the caller must free the allocated memory with the CoTaskMemFree function. Note that the memory is
		/// allocate(all_nodes), which means that all the substructures are allocated in one block. Therefore, the entire data structure
		/// must be freed by a single call to <c>CoTaskMemFree</c>.
		/// </para>
		/// </param>
		/// <param name="ppOwner">
		/// A pointer to a TRUSTEE structure that receives the owner information. If this parameter is not <c>NULL</c> and the function
		/// succeeds, the caller must free the memory with CoTaskMemFree.
		/// </param>
		/// <param name="ppGroup">
		/// A pointer to a TRUSTEE structure that receives the group information. If this parameter is not <c>NULL</c> and the function
		/// succeeds, the caller must free the memory with CoTaskMemFree.
		/// </param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/iaccess/nf-iaccess-iaccesscontrol-getallaccessrights HRESULT
		// GetAllAccessRights( StrPtrUni lpProperty, PACTRL_ACCESSW_ALLOCATE_ALL_NODES *ppAccessList, PTRUSTEEW *ppOwner, PTRUSTEEW
		// *ppGroup );
		[PreserveSig]
		HRESULT GetAllAccessRights([MarshalAs(UnmanagedType.LPWStr)] string? lpProperty, out SafeCoTaskMemHandle ppAccessList,
			out SafeCoTaskMemHandle ppOwner, out SafeCoTaskMemHandle ppGroup);

		/// <summary>Determines whether the specified trustee has access rights to the object or property.</summary>
		/// <param name="pTrustee">A pointer to a TRUSTEE structure.</param>
		/// <param name="lpProperty">
		/// The name of the property. If you are using the COM implementation of IAccessControl, this parameter must be <c>NULL</c>.
		/// </param>
		/// <param name="AccessRights">
		/// The access rights on the object. If you are using the COM implementation of IAccessControl, this value must be either 0 or 1 (COM_RIGHTS_EXECUTE).
		/// </param>
		/// <param name="pfAccessAllowed">Indicates whether access is allowed.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// <para>
		/// In the system-supplied implementation of IAccessControl (CLSID_DCOMAccessControl), <c>IsAccessAllowed</c> can be called only
		/// during a distributed COM call, and the only valid trustee name is the name of the client.
		/// </para>
		/// <para>
		/// The following tables list the object-specific access permissions used with the Directory Service and storage implementation
		/// of IAccessControl.
		/// </para>
		/// <para>The following permissions are specific to DS objects.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Access permission</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ACTRL_DS_OPEN</term>
		/// <term>Open a DS object</term>
		/// </item>
		/// <item>
		/// <term>ACTRL_DS_CREATE_CHILD</term>
		/// <term>Create a child object</term>
		/// </item>
		/// <item>
		/// <term>ACTRL_DS_DELETE_CHILD</term>
		/// <term>Delete a child object</term>
		/// </item>
		/// <item>
		/// <term>ACTRL_DS_LIST</term>
		/// <term>Enumerate an object</term>
		/// </item>
		/// <item>
		/// <term>ACTRL_DS_SELF</term>
		/// <term>Update a member list involving the trustee</term>
		/// </item>
		/// <item>
		/// <term>ACTRL_DS_READ_PROP</term>
		/// <term>Read properties</term>
		/// </item>
		/// <item>
		/// <term>ACTRL_DS_WRITE_PROP</term>
		/// <term>Write properties</term>
		/// </item>
		/// </list>
		/// <para>The following permissions are specific to file objects.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Access permission</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ACTRL_FILE_READ</term>
		/// <term>Read from a file</term>
		/// </item>
		/// <item>
		/// <term>ACTRL_FILE_WRITE</term>
		/// <term>Write to a file</term>
		/// </item>
		/// <item>
		/// <term>ACTRL_FILE_APPEND</term>
		/// <term>Append to a file</term>
		/// </item>
		/// <item>
		/// <term>ACTRL_FILE_READ_PROP</term>
		/// <term>Read file properties or extended attributes</term>
		/// </item>
		/// <item>
		/// <term>ACTRL_FILE_WRITE_PROP</term>
		/// <term>Write file properties or extended attributes</term>
		/// </item>
		/// <item>
		/// <term>ACTRL_FILE_EXECUTE</term>
		/// <term>Execute the file</term>
		/// </item>
		/// <item>
		/// <term>ACTRL_FILE_READ_ATTRIB</term>
		/// <term>Read the file attributes</term>
		/// </item>
		/// <item>
		/// <term>ACTRL_FILE_WRITE_ATTRIB</term>
		/// <term>Write the file attributes</term>
		/// </item>
		/// </list>
		/// <para>The following permissions are specific to directory objects.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Access permission</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ACTRL_DIR_LIST</term>
		/// <term>List the contents of a directory</term>
		/// </item>
		/// <item>
		/// <term>ACTRL_DIR_CREATE_OBJECT</term>
		/// <term>Create a child object (file) in a directory</term>
		/// </item>
		/// <item>
		/// <term>ACTRL_DIR_CREATE_CHILD</term>
		/// <term>Create a subdirectory</term>
		/// </item>
		/// <item>
		/// <term>ACTRL_DIR_DELETE_CHILD</term>
		/// <term>Delete a subdirectory</term>
		/// </item>
		/// <item>
		/// <term>ACTRL_DIR_TRAVERSE</term>
		/// <term>Traverse the directory</term>
		/// </item>
		/// </list>
		/// <para>The following permissions are specific to kernel objects.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Access permission</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ACTRL_KERNEL_TERMINATE</term>
		/// <term>Terminate a process or thread</term>
		/// </item>
		/// <item>
		/// <term>ACTRL_KERNEL_THREAD</term>
		/// <term>Create a thread</term>
		/// </item>
		/// <item>
		/// <term>ACTRL_KERNEL_VM</term>
		/// <term>Perform address space operations</term>
		/// </item>
		/// <item>
		/// <term>ACTRL_KERNEL_VM_READ</term>
		/// <term>Read from memory</term>
		/// </item>
		/// <item>
		/// <term>ACTRL_KERNEL_VM_WRITE</term>
		/// <term>Write to memory</term>
		/// </item>
		/// <item>
		/// <term>ACTRL_KERNEL_DUP_HANDLE</term>
		/// <term>Duplicate a handle</term>
		/// </item>
		/// <item>
		/// <term>ACTRL_KERNEL_PROCESS</term>
		/// <term>Create a process</term>
		/// </item>
		/// <item>
		/// <term>ACTRL_KERNEL_SET_INFO</term>
		/// <term>Get kernel object information or state</term>
		/// </item>
		/// <item>
		/// <term>ACTRL_KERNEL_GET_INFO</term>
		/// <term>Set kernel object information or state</term>
		/// </item>
		/// <item>
		/// <term>ACTRL_KERNEL_CONTROL</term>
		/// <term>Control a kernel object (such as suspending a thread)</term>
		/// </item>
		/// <item>
		/// <term>ACTRL_KERNEL_ALERT</term>
		/// <term>Alert a kernel object.</term>
		/// </item>
		/// <item>
		/// <term>ACTRL_KERNEL_GET_CONTEXT</term>
		/// <term>Get the thread context</term>
		/// </item>
		/// <item>
		/// <term>ACTRL_KERNEL_SET_CONTEXT</term>
		/// <term>Set the thread context</term>
		/// </item>
		/// <item>
		/// <term>ACTRL_KERNEL_TOKEN</term>
		/// <term>Set the thread token</term>
		/// </item>
		/// <item>
		/// <term>ACTRL_KERNEL_IMPERSONATE</term>
		/// <term>Impersonate a client</term>
		/// </item>
		/// <item>
		/// <term>ACTRL_KERNEL_DIMPERSONATE</term>
		/// <term>Directly impersonate a client</term>
		/// </item>
		/// </list>
		/// <para>The following permissions are specific to printer objects.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Access permission</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ACTRL_PRINT_SADMIN</term>
		/// <term>Administer a print server</term>
		/// </item>
		/// <item>
		/// <term>ACTRL_PRINT_SLIST</term>
		/// <term>Enumerate a print server</term>
		/// </item>
		/// <item>
		/// <term>ACTRL_PRINT_PADMIN</term>
		/// <term>Administer a printer</term>
		/// </item>
		/// <item>
		/// <term>ACTRL_PRINT_PUSE</term>
		/// <term>Use a printer</term>
		/// </item>
		/// <item>
		/// <term>ACTRL_PRINT_JADMIN</term>
		/// <term>Administer a print job</term>
		/// </item>
		/// </list>
		/// <para>The following permissions are specific to service objects.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Access permission</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ACTRL_SVC_GET_INFO</term>
		/// <term>Start a service</term>
		/// </item>
		/// <item>
		/// <term>ACTRL_SVC_SET_INFO</term>
		/// <term>Stop a service</term>
		/// </item>
		/// <item>
		/// <term>ACTRL_SVC_STATUS</term>
		/// <term>Pause a service</term>
		/// </item>
		/// <item>
		/// <term>ACTRL_SVC_LIST</term>
		/// <term>Enumerate the services</term>
		/// </item>
		/// <item>
		/// <term>ACTRL_SVC_START</term>
		/// <term>Start a service</term>
		/// </item>
		/// <item>
		/// <term>ACTRL_SVC_STOP</term>
		/// <term>Stop a service</term>
		/// </item>
		/// <item>
		/// <term>ACTRL_SVC_PAUSE</term>
		/// <term>Pause a service</term>
		/// </item>
		/// <item>
		/// <term>ACTRL_SVC_INTERROGATE</term>
		/// <term>Query the service for current status</term>
		/// </item>
		/// <item>
		/// <term>ACTRL_SVC_UCONTROL</term>
		/// <term>User-defined control</term>
		/// </item>
		/// </list>
		/// <para>The following permissions are specific to registry objects.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Access permission</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ACTRL_REG_QUERY</term>
		/// <term>Read a registry subkey</term>
		/// </item>
		/// <item>
		/// <term>ACTRL_REG_SET</term>
		/// <term>Write a registry subkey</term>
		/// </item>
		/// <item>
		/// <term>ACTRL_REG_CREATE_CHILD</term>
		/// <term>Create a registry subkey</term>
		/// </item>
		/// <item>
		/// <term>ACTRL_REG_LIST</term>
		/// <term>Enumerate a registry subkey</term>
		/// </item>
		/// <item>
		/// <term>ACTRL_REG_NOTIFY</term>
		/// <term>Create a registry notification</term>
		/// </item>
		/// <item>
		/// <term>ACTRL_REG_LINK</term>
		/// <term>Create a symbolic link</term>
		/// </item>
		/// </list>
		/// <para>The following permissions are specific to window objects.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Access permission</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ACTRL_WIN_CLIPBRD</term>
		/// <term>Enable access to the clipboard</term>
		/// </item>
		/// <item>
		/// <term>ACTRL_WIN_GLOBAL_ATOMS</term>
		/// <term>Enable global-atom access</term>
		/// </item>
		/// <item>
		/// <term>ACTRL_WIN_CREATE</term>
		/// <term>Create desktop access</term>
		/// </item>
		/// <item>
		/// <term>ACTRL_WIN_LIST_DESK</term>
		/// <term>Enumerate the desktops</term>
		/// </item>
		/// <item>
		/// <term>ACTRL_WIN_LIST</term>
		/// <term>Enumerate the window station</term>
		/// </item>
		/// <item>
		/// <term>ACTRL_WIN_READ_ATTRIBS</term>
		/// <term>Read the attributes</term>
		/// </item>
		/// <item>
		/// <term>ACTRL_WIN_WRITE_ATTRIBS</term>
		/// <term>Write the attributes</term>
		/// </item>
		/// <item>
		/// <term>ACTRL_WIN_SCREEN</term>
		/// <term>Enable access to the screen</term>
		/// </item>
		/// <item>
		/// <term>ACTRL_WIN_EXIT</term>
		/// <term>Call ExitWindows or ExitWindowsEx</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/iaccess/nf-iaccess-iaccesscontrol-isaccessallowed HRESULT IsAccessAllowed(
		// PTRUSTEEW pTrustee, StrPtrUni lpProperty, ACCESS_RIGHTS AccessRights, BOOL *pfAccessAllowed );
		[PreserveSig]
		HRESULT IsAccessAllowed(in TRUSTEE pTrustee, [MarshalAs(UnmanagedType.LPWStr)] string? lpProperty, COM_RIGHTS AccessRights,
			[MarshalAs(UnmanagedType.Bool)] out bool pfAccessAllowed);
	}
}