using System.ComponentModel.DataAnnotations;

namespace Vanara.PInvoke;

public static partial class Kernel32
{
	/// <summary>The maximum length of the command line.</summary>
	public const int RESTART_MAX_CMD_LINE = 1024;

	/// <summary>
	/// Application-defined callback function used to save data and application state information in the event the application encounters
	/// an unhandled exception or becomes unresponsive.
	/// </summary>
	/// <param name="pvParameter">
	/// Context information specified when you called the RegisterApplicationRecoveryCallback function to register for recovery.
	/// </param>
	/// <returns>The return value is not used and should be 0.</returns>
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	[PInvokeData("Winbase.h", MSDNShortId = "aa373202")]
	public delegate uint ApplicationRecoveryCallback([In, Optional] IntPtr pvParameter);

	/// <summary>
	/// The <c>ACTCTX_COMPATIBILITY_ELEMENT_TYPE</c> enumeration describes the compatibility element in the application manifest.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winnt/ne-winnt-actctx_compatibility_element_type typedef enum {
	// ACTCTX_COMPATIBILITY_ELEMENT_TYPE_UNKNOWN, ACTCTX_COMPATIBILITY_ELEMENT_TYPE_OS, ACTCTX_COMPATIBILITY_ELEMENT_TYPE_MITIGATION,
	// ACTCTX_COMPATIBILITY_ELEMENT_TYPE_MAXVERSIONTESTED } ;
	[PInvokeData("winnt.h", MSDNShortId = "3a3c99e5-9a73-4688-8192-baee0078c17c")]
	public enum ACTCTX_COMPATIBILITY_ELEMENT_TYPE
	{
		/// <summary/>
		ACTCTX_COMPATIBILITY_ELEMENT_TYPE_UNKNOWN,

		/// <summary/>
		ACTCTX_COMPATIBILITY_ELEMENT_TYPE_OS,

		/// <summary/>
		ACTCTX_COMPATIBILITY_ELEMENT_TYPE_MITIGATION,

		/// <summary/>
		ACTCTX_COMPATIBILITY_ELEMENT_TYPE_MAXVERSIONTESTED,
	}

	/// <summary>The <c>ACTCTX_REQUESTED_RUN_LEVEL</c> enumeration describes the requested run level of the activation context.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winnt/ne-winnt-actctx_requested_run_level typedef enum {
	// ACTCTX_RUN_LEVEL_UNSPECIFIED, ACTCTX_RUN_LEVEL_AS_INVOKER, ACTCTX_RUN_LEVEL_HIGHEST_AVAILABLE, ACTCTX_RUN_LEVEL_REQUIRE_ADMIN,
	// ACTCTX_RUN_LEVEL_NUMBERS } ;
	[PInvokeData("winnt.h", MSDNShortId = "3bf75a4d-a209-43e4-9fe2-f7da1602fc6c")]
	public enum ACTCTX_REQUESTED_RUN_LEVEL
	{
		/// <summary>The application manifest does not specify a requested run level for the application.</summary>
		ACTCTX_RUN_LEVEL_UNSPECIFIED,

		/// <summary>The application manifest requests the least privilege level to run the application.</summary>
		ACTCTX_RUN_LEVEL_AS_INVOKER,

		/// <summary>The application manifest requests the highest privilege level to run the application.</summary>
		ACTCTX_RUN_LEVEL_HIGHEST_AVAILABLE,

		/// <summary>The application manifest requests the administrator privilege level to run the application.</summary>
		ACTCTX_RUN_LEVEL_REQUIRE_ADMIN,

		/// <summary>Total number of possible run levels.</summary>
		ACTCTX_RUN_LEVEL_NUMBERS,
	}

	/// <summary>Flags that determine in which section FindActCtxSectionString searches.</summary>
	public enum ACTCTX_SECTION
	{
		/// <summary/>
		ACTIVATION_CONTEXT_SECTION_ASSEMBLY_INFORMATION = 1,
		/// <summary/>
		ACTIVATION_CONTEXT_SECTION_DLL_REDIRECTION = 2,
		/// <summary/>
		ACTIVATION_CONTEXT_SECTION_WINDOW_CLASS_REDIRECTION = 3,
		/// <summary/>
		ACTIVATION_CONTEXT_SECTION_COM_SERVER_REDIRECTION = 4,
		/// <summary/>
		ACTIVATION_CONTEXT_SECTION_COM_INTERFACE_REDIRECTION = 5,
		/// <summary/>
		ACTIVATION_CONTEXT_SECTION_COM_TYPE_LIBRARY_REDIRECTION = 6,
		/// <summary/>
		ACTIVATION_CONTEXT_SECTION_COM_PROGID_REDIRECTION = 7,
		/// <summary/>
		ACTIVATION_CONTEXT_SECTION_GLOBAL_OBJECT_RENAME_TABLE = 8,
		/// <summary/>
		ACTIVATION_CONTEXT_SECTION_CLR_SURROGATES = 9,
		/// <summary/>
		ACTIVATION_CONTEXT_SECTION_APPLICATION_SETTINGS = 10,
		/// <summary/>
		ACTIVATION_CONTEXT_SECTION_COMPATIBILITY_INFO = 11,
		/// <summary/>
		ACTIVATION_CONTEXT_SECTION_WINRT_ACTIVATABLE_CLASSES = 12
	}

	/// <summary>Flags that indicate how the values included in <see cref="ACTCTX"/> are to be used.</summary>
	[Flags]
	[PInvokeData("Winbase.h")]
	public enum ActCtxFlags
	{
		/// <summary>No values are set.</summary>
		ACTCTX_FLAG_NONE = 0x00000000,

		/// <summary>The <see cref="ACTCTX.wProcessorArchitecture"/> value is set.</summary>
		ACTCTX_FLAG_PROCESSOR_ARCHITECTURE_VALID = 0x00000001,

		/// <summary>The <see cref="ACTCTX.wLangId"/> value is set.</summary>
		ACTCTX_FLAG_LANGID_VALID = 0x00000002,

		/// <summary>The <see cref="ACTCTX.lpAssemblyDirectory"/> value is set.</summary>
		ACTCTX_FLAG_ASSEMBLY_DIRECTORY_VALID = 0x00000004,

		/// <summary>The <see cref="ACTCTX.lpResourceName"/> value is set.</summary>
		ACTCTX_FLAG_RESOURCE_NAME_VALID = 0x00000008,

		/// <summary>Set the activation context to be the process default when calling <see cref="CreateActCtx"/>.</summary>
		ACTCTX_FLAG_SET_PROCESS_DEFAULT = 0x00000010,

		/// <summary>The <see cref="ACTCTX.lpApplicationName"/> value is set.</summary>
		ACTCTX_FLAG_APPLICATION_NAME_VALID = 0x00000020,

		/// <summary>
		/// Use when calling <see cref="CreateActCtx"/> to identify that <see cref="ACTCTX.lpSource"/> contains an assembly identifier.
		/// </summary>
		ACTCTX_FLAG_SOURCE_IS_ASSEMBLYREF = 0x00000040,

		/// <summary>The <see cref="ACTCTX.hModule"/> value is set.</summary>
		ACTCTX_FLAG_HMODULE_VALID = 0x00000080
	}

	/// <summary></summary>
	public enum ACTIVATION_CONTEXT_INFO_CLASS
	{
		/// <summary>Not available.</summary>
		[CorrespondingType(typeof(ACTIVATION_CONTEXT_BASIC_INFORMATION))]
		ActivationContextBasicInformation = 1,

		/// <summary>
		/// If QueryActCtxW is called with this option and the function succeeds, the returned buffer contains detailed information about
		/// the activation context. This information is in the form of the ACTIVATION_CONTEXT_DETAILED_INFORMATION structure.
		/// </summary>
		[CorrespondingType(typeof(ACTIVATION_CONTEXT_DETAILED_INFORMATION))]
		ActivationContextDetailedInformation = 2,

		/// <summary>
		/// If QueryActCtxW is called with this option and the function succeeds, the buffer contains information about the assembly that
		/// has the index specified in pvSubInstance. This information is in the form of the
		/// ACTIVATION_CONTEXT_ASSEMBLY_DETAILED_INFORMATION structure.
		/// </summary>
		[CorrespondingType(typeof(ACTIVATION_CONTEXT_ASSEMBLY_DETAILED_INFORMATION))]
		AssemblyDetailedInformationInActivationContext = 3,

		/// <summary>
		/// Information about a file in one of the assemblies in Activation Context. The pvSubInstance parameter must point to an
		/// <see cref="ACTIVATION_CONTEXT_QUERY_INDEX"/> structure. If QueryActCtxW is called with this option and the function succeeds,
		/// the returned buffer contains information for a file in the assembly. This information is in the form of the
		/// ASSEMBLY_FILE_DETAILED_INFORMATION structure.
		/// </summary>
		[CorrespondingType(typeof(ASSEMBLY_FILE_DETAILED_INFORMATION))]
		FileInformationInAssemblyOfAssemblyInActivationContext = 4,

		/// <summary>
		/// If QueryActCtxW is called with this option and the function succeeds, the buffer contains information about requested run
		/// level of the activation context. This information is in the form of the ACTIVATION_CONTEXT_RUN_LEVEL_INFORMATION structure.
		/// Windows Server 2003 and Windows XP: This value is not available.
		/// </summary>
		[CorrespondingType(typeof(ACTIVATION_CONTEXT_RUN_LEVEL_INFORMATION))]
		RunlevelInformationInActivationContext = 5,

		/// <summary>
		/// If QueryActCtxW is called with this option and the function succeeds, the buffer contains information about requested
		/// compatibility context. This information is in the form of the ACTIVATION_CONTEXT_COMPATIBILITY_INFORMATION structure.Windows
		/// Server 2008 and earlier, and Windows Vista and
		/// earlier: This value is not available. This option is available beginning with Windows Server 2008 R2 and Windows 7.
		/// </summary>
		[CorrespondingType(typeof(ACTIVATION_CONTEXT_COMPATIBILITY_INFORMATION))]
		[CorrespondingType(typeof(ACTIVATION_CONTEXT_COMPATIBILITY_INFORMATION_UNMGD))]
		CompatibilityInformationInActivationContext = 6,

		/// <summary>The activation context manifest resource name</summary>
		ActivationContextManifestResourceName = 7,
	}

	/// <summary></summary>
	[Flags]
	[PInvokeData("Winbase.h", MSDNShortId = "aa373344")]
	public enum ApplicationRestartFlags
	{
		/// <summary>Do not restart the process if it terminates due to an unhandled exception.</summary>
		RESTART_NO_CRASH = 1,

		/// <summary>Do not restart the process if it terminates due to the application not responding.</summary>
		RESTART_NO_HANG = 2,

		/// <summary>Do not restart the process if it terminates due to the installation of an update.</summary>
		RESTART_NO_PATCH = 4,

		/// <summary>Do not restart the process if the computer is restarted as the result of an update.</summary>
		RESTART_NO_REBOOT = 8,
	}

	/// <summary></summary>
	[PInvokeData("Winbase.h")]
	public enum DeactivateActCtxFlag
	{
		/// <summary>
		/// If this value is set and the cookie specified in the ulCookie parameter is in the top frame of the activation stack, the
		/// activation context is popped from the stack and thereby deactivated.
		/// <para>
		/// If this value is set and the cookie specified in the ulCookie parameter is not in the top frame of the activation stack, this
		/// function searches down the stack for the cookie.
		/// </para>
		/// <para>If the cookie is found, a STATUS_SXS_EARLY_DEACTIVATION exception is thrown.</para>
		/// <para>If the cookie is not found, a STATUS_SXS_INVALID_DEACTIVATION exception is thrown.</para>
		/// <para>This value should be specified in most cases.</para>
		/// </summary>
		None = 0,

		/// <summary>
		/// If this value is set and the cookie specified in the ulCookie parameter is in the top frame of the activation stack, the
		/// function returns an ERROR_INVALID_PARAMETER error code. Call GetLastError to obtain this code.
		/// <para>
		/// If this value is set and the cookie is not on the activation stack, a STATUS_SXS_INVALID_DEACTIVATION exception will be thrown.
		/// </para>
		/// <para>
		/// If this value is set and the cookie is in a lower frame of the activation stack, all of the frames down to and including the
		/// frame the cookie is in is popped from the stack.
		/// </para>
		/// </summary>
		DEACTIVATE_ACTCTX_FLAG_FORCE_EARLY_DEACTIVATION = 1
	}

	/// <summary>Flags that determine how FindActCtxSectionString operates.</summary>
	public enum FIND_ACTCTX_SECTION
	{
		/// <summary>
		/// This function returns the activation context handle where the redirection data was found in the hActCtx member of the
		/// ACTCTX_SECTION_KEYED_DATA structure. The caller must use ReleaseActCtx to release this activation context.
		/// </summary>
		FIND_ACTCTX_SECTION_KEY_RETURN_HACTCTX = 0x00000001,

		/// <summary>Undocumented.</summary>
		FIND_ACTCTX_SECTION_KEY_RETURN_FLAGS = 0x00000002,

		/// <summary>Undocumented.</summary>
		FIND_ACTCTX_SECTION_KEY_RETURN_ASSEMBLY_METADATA = 0x00000004
	}

	/// <summary></summary>
	[PInvokeData("Winbase.h")]
	public enum QueryActCtxFlag : uint
	{
		/// <summary>
		/// QueryActCtxW queries the activation context active on the thread instead of the context specified by hActCtx. This is usually
		/// the last activation context passed to ActivateActCtx. If ActivateActCtx has not been called, the active activation context
		/// can be the activation context used by the executable of the current process. In other cases, the operating system determines
		/// the active activation context. For example, when the callback function to a new thread is called, the active activation
		/// context may be the context that was active when you created the thread by calling CreateThread.
		/// </summary>
		QUERY_ACTCTX_FLAG_USE_ACTIVE_ACTCTX = 0x00000004,

		/// <summary>
		/// QueryActCtxW interprets hActCtx as an HMODULE data type and queries an activation context that is associated with a DLL or
		/// EXE. When a DLL or EXE is loaded, the loader checks for a manifest stored in a resource. If the loader finds an RT_MANIFEST
		/// resource with a resource identifier set to ISOLATIONAWARE_MANIFEST_ RESOURCE_ID, the loader associates the resulting
		/// activation context with the DLL or EXE. This is the activation context that QueryActCtxW queries when the
		/// QUERY_ACTCTX_FLAG_ACTCTX_IS_HMODULE flag has been set.
		/// </summary>
		QUERY_ACTCTX_FLAG_ACTCTX_IS_HMODULE = 0x00000008,

		/// <summary>
		/// QueryActCtxW interprets hActCtx as an address within a DLL or EXE and queries an activation context that has been associated
		/// with the DLL or EXE. This can be any address within the DLL or EXE. For example, the address of any function within a DLL or
		/// EXE or the address of any static data, such as a constant string. When a DLL or EXE is loaded, the loader checks for a
		/// manifest stored in a resource in the same way as QUERY_ACTCTX_FLAG_ACTCTX_IS_HMODULE.
		/// </summary>
		QUERY_ACTCTX_FLAG_ACTCTX_IS_ADDRESS = 0x00000010,

		/// <summary>Undocumented.</summary>
		QUERY_ACTCTX_FLAG_NO_ADDREF = 0x80000000,
	}

	/// <summary>
	/// The <c>ActivateActCtx</c> function activates the specified activation context. It does this by pushing the specified activation
	/// context to the top of the activation stack. The specified activation context is thus associated with the current thread and any
	/// appropriate side-by-side API functions.
	/// </summary>
	/// <param name="hActCtx">
	/// Handle to an <c>ACTCTX</c> structure that contains information on the activation context that is to be made active.
	/// </param>
	/// <param name="lpCookie">
	/// Pointer to a <c>ULONG_PTR</c> that functions as a cookie, uniquely identifying a specific, activated activation context.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>TRUE</c>. Otherwise, it returns <c>FALSE</c>.</para>
	/// <para>
	/// This function sets errors that can be retrieved by calling <c>GetLastError</c>. For an example, see Retrieving the Last-Error
	/// Code. For a complete list of error codes, see System Error Codes.
	/// </para>
	/// </returns>
	// BOOL ActivateActCtx( _In_ HANDLE hActCtx, _Out_ ULONG_PTR *lpCookie); https://msdn.microsoft.com/en-us/library/windows/desktop/aa374151(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("Winbase.h", MSDNShortId = "aa374151")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ActivateActCtx([In, AddAsMember] HACTCTX hActCtx, out IntPtr lpCookie);

	/// <summary>The <c>AddRefActCtx</c> function increments the reference count of the specified activation context.</summary>
	/// <param name="hActCtx">
	/// Handle to an <c>ACTCTX</c> structure that contains information on the activation context for which the reference count is to be incremented.
	/// </param>
	/// <returns>This function does not return a value.</returns>
	// void AddRefActCtx( _In_ HANDLE hActCtx); https://msdn.microsoft.com/en-us/library/windows/desktop/aa374171(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Winbase.h", MSDNShortId = "aa374171")]
	public static extern void AddRefActCtx([In, AddAsMember] HACTCTX hActCtx);

	/// <summary>Indicates that the calling application has completed its data recovery.</summary>
	/// <param name="bSuccess">Specify <c>TRUE</c> to indicate that the data was successfully recovered; otherwise, <c>FALSE</c>.</param>
	/// <returns>This function does not return a value.</returns>
	// VOID WINAPI ApplicationRecoveryFinished( _In_ BOOL bSuccess); https://msdn.microsoft.com/en-us/library/windows/desktop/aa373328(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Winbase.h", MSDNShortId = "aa373328")]
	public static extern void ApplicationRecoveryFinished([MarshalAs(UnmanagedType.Bool)] bool bSuccess);

	/// <summary>Indicates that the calling application is continuing to recover data.</summary>
	/// <param name="pbCanceled">
	/// Indicates whether the user has canceled the recovery process. Set by WER if the user clicks the Cancel button.
	/// </param>
	/// <returns>
	/// <para>This function returns <c>S_OK</c> on success or one of the following error codes.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_FAIL</term>
	/// <term>You can call this function only after Windows Error Reporting has called your recovery callback function.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>The pbCancelled cannot be NULL.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </returns>
	// HRESULT WINAPI ApplicationRecoveryInProgress( _Out_ PBOOL pbCanceled); https://msdn.microsoft.com/en-us/library/windows/desktop/aa373329(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Winbase.h", MSDNShortId = "aa373329")]
	public static extern HRESULT ApplicationRecoveryInProgress([Out, MarshalAs(UnmanagedType.Bool)] out bool pbCanceled);

	/// <summary>The <c>CreateActCtx</c> function creates an activation context.</summary>
	/// <param name="pActCtx">Pointer to an <c>ACTCTX</c> structure that contains information about the activation context to be created.</param>
	/// <returns>
	/// <para>If the function succeeds, it returns a handle to the returned activation context. Otherwise, it returns INVALID_HANDLE_VALUE.</para>
	/// <para>
	/// This function sets errors that can be retrieved by calling <c>GetLastError</c>. For an example, see Retrieving the Last-Error
	/// Code. For a complete list of error codes, see System Error Codes.
	/// </para>
	/// </returns>
	// HANDLE CreateActCtx( _Inout_ PACTCTX pActCtx); https://msdn.microsoft.com/en-us/library/windows/desktop/aa375125(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("Winbase.h", MSDNShortId = "aa375125")]
	[return: AddAsCtor]
	public static extern SafeHACTCTX CreateActCtx(in ACTCTX pActCtx);

	/// <summary>The <c>DeactivateActCtx</c> function deactivates the activation context corresponding to the specified cookie.</summary>
	/// <param name="dwFlags">
	/// <para>Flags that indicate how the deactivation is to occur.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>0</term>
	/// <term>
	/// If this value is set and the cookie specified in the ulCookie parameter is in the top frame of the activation stack, the
	/// activation context is popped from the stack and thereby deactivated. If this value is set and the cookie specified in the
	/// ulCookie parameter is not in the top frame of the activation stack, this function searches down the stack for the cookie.If the
	/// cookie is found, a STATUS_SXS_EARLY_DEACTIVATION exception is thrown.If the cookie is not found, a
	/// STATUS_SXS_INVALID_DEACTIVATION exception is thrown.This value should be specified in most cases.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DEACTIVATE_ACTCTX_FLAG_FORCE_EARLY_DEACTIVATION</term>
	/// <term>
	/// If this value is set and the cookie specified in the ulCookie parameter is in the top frame of the activation stack, the function
	/// returns an ERROR_INVALID_PARAMETER error code. Call GetLastError to obtain this code. If this value is set and the cookie is not
	/// on the activation stack, a STATUS_SXS_INVALID_DEACTIVATION exception will be thrown.If this value is set and the cookie is in a
	/// lower frame of the activation stack, all of the frames down to and including the frame the cookie is in is popped from the stack.
	/// </term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <param name="ulCookie">
	/// The ULONG_PTR that was passed into the call to <c>ActivateActCtx</c>. This value is used as a cookie to identify a specific
	/// activated activation context.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>TRUE</c>. Otherwise, it returns <c>FALSE</c>.</para>
	/// <para>
	/// This function sets errors that can be retrieved by calling <c>GetLastError</c>. For an example, see Retrieving the Last-Error
	/// Code. For a complete list of error codes, see System Error Codes.
	/// </para>
	/// </returns>
	// BOOL DeactivateActCtx( _In_ DWORD dwFlags, _In_ ULONG_PTR ulCookie); https://msdn.microsoft.com/en-us/library/windows/desktop/aa375140(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("Winbase.h", MSDNShortId = "aa375140")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DeactivateActCtx(DeactivateActCtxFlag dwFlags, [In] IntPtr ulCookie);

	/// <summary>
	/// The <c>FindActCtxSectionGuid</c> function retrieves information on a specific GUID in the current activation context and returns
	/// a <c>ACTCTX_SECTION_KEYED_DATA</c> structure.
	/// </summary>
	/// <param name="dwFlags">
	/// <para>Flags that determine how this function is to operate. Only the following flag is currently defined.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>FIND_ACTCTX_SECTION_KEY_RETURN_HACTCTX</term>
	/// <term>
	/// This function returns the activation context handle where the redirection data was found in the hActCtx member of the
	/// ACTCTX_SECTION_KEYED_DATA structure. The caller must use ReleaseActCtx to release this activation context.
	/// </term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <param name="lpExtensionGuid">Reserved; must be null.</param>
	/// <param name="ulSectionId">
	/// <para>Identifier of the section of the activation context in which to search for the specified GUID.</para>
	/// <para>The following are valid GUID section identifiers:</para>
	/// <para>The following is a valid GUID section identifier beginning with Windows Server 2003 and Windows XP with SP1:</para>
	/// </param>
	/// <param name="lpGuidToFind">Pointer to a GUID to be used as the search criteria.</param>
	/// <param name="ReturnedData">
	/// Pointer to an <c>ACTCTX_SECTION_KEYED_DATA</c> structure to be filled out with the requested GUID information.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>TRUE</c>. Otherwise, it returns <c>FALSE</c>.</para>
	/// <para>
	/// This function sets errors that can be retrieved by calling <c>GetLastError</c>. For an example, see Retrieving the Last-Error
	/// Code. For a complete list of error codes, see System Error Codes.
	/// </para>
	/// </returns>
	// BOOL FindActCtxSectionGuid( _In_ DWORD dwFlags, _In_ const GUID *lpExtensionGuid, _In_ ULONG ulSectionId, _In_ const GUID
	// *lpGuidToFind, _Out_ PACTCTX_SECTION_KEYED_DATA ReturnedData); https://msdn.microsoft.com/en-us/library/windows/desktop/aa375148(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("Winbase.h", MSDNShortId = "aa375148")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool FindActCtxSectionGuid(FIND_ACTCTX_SECTION dwFlags, [In, Optional] GuidPtr lpExtensionGuid, ACTCTX_SECTION ulSectionId, in Guid lpGuidToFind, out ACTCTX_SECTION_KEYED_DATA ReturnedData);

	/// <summary>
	/// The <c>FindActCtxSectionString</c> function retrieves information on a specific string in the current activation context and
	/// returns a <c>ACTCTX_SECTION_KEYED_DATA</c> structure.
	/// </summary>
	/// <param name="dwFlags">
	/// <para>Flags that determine how this function is to operate. Only the following flag is currently defined.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>FIND_ACTCTX_SECTION_KEY_RETURN_HACTCTX</term>
	/// <term>
	/// This function returns the activation context handle where the redirection data was found in the hActCtx member of the
	/// ACTCTX_SECTION_KEYED_DATA structure. The caller must use ReleaseActCtx to release this activation context.
	/// </term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <param name="lpExtensionGuid">Reserved; must be null.</param>
	/// <param name="ulSectionId">
	/// <para>Identifier of the string section of the activation context in which to search for the specific string.</para>
	/// <para>The following are valid string section identifiers:</para>
	/// </param>
	/// <param name="lpStringToFind">Pointer to a null-terminated string to be used as the search criteria.</param>
	/// <param name="ReturnedData">
	/// Pointer to an <c>ACTCTX_SECTION_KEYED_DATA</c> structure to be filled out with the requested string information.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>TRUE</c>. Otherwise, it returns <c>FALSE</c>.</para>
	/// <para>
	/// This function sets errors that can be retrieved by calling <c>GetLastError</c>. For an example, see Retrieving the Last-Error
	/// Code. For a complete list of error codes, see System Error Codes.
	/// </para>
	/// </returns>
	// BOOL FindActCtxSectionString( _In_ DWORD dwFlags, _In_ const GUID *lpExtensionGuid, _In_ ULONG ulSectionId, _In_ LPCTSTR
	// lpStringToFind, _Out_ PACTCTX_SECTION_KEYED_DATA ReturnedData); https://msdn.microsoft.com/en-us/library/windows/desktop/aa375149(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("Winbase.h", MSDNShortId = "aa375149")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool FindActCtxSectionString(FIND_ACTCTX_SECTION dwFlags, [In, Optional] GuidPtr lpExtensionGuid, ACTCTX_SECTION ulSectionId, string lpStringToFind, out ACTCTX_SECTION_KEYED_DATA ReturnedData);

	/// <summary>
	/// Retrieves a pointer to the callback routine registered for the specified process. The address returned is in the virtual address
	/// space of the process.
	/// </summary>
	/// <param name="hProcess">A handle to the process. This handle must have the PROCESS_VM_READ access right.</param>
	/// <param name="pRecoveryCallback">A pointer to the recovery callback function. For more information, see <c>ApplicationRecoveryCallback</c>.</param>
	/// <param name="ppvParameter">A pointer to the callback parameter.</param>
	/// <param name="pdwPingInterval">The recovery ping interval, in 100-nanosecond intervals.</param>
	/// <param name="pdwFlags">Reserved for future use.</param>
	/// <returns>
	/// <para>This function returns <c>S_OK</c> on success or one of the following error codes.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_FALSE</term>
	/// <term>The application did not register for recovery.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One or more parameters are not valid.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </returns>
	// HRESULT WINAPI GetApplicationRecoveryCallback( _In_ HANDLE hProcess, _Out_ APPLICATION_RECOVERY_CALLBACK *pRecoveryCallback, _Out_ PVOID
	// *ppvParameter, _Out_ PDWORD pdwPingInterval, _Out_ PDWORD pdwFlags); https://msdn.microsoft.com/en-us/library/windows/desktop/aa373343(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Winbase.h", MSDNShortId = "aa373343")]
	public static extern HRESULT GetApplicationRecoveryCallback([In] HPROCESS hProcess, out ApplicationRecoveryCallback pRecoveryCallback, out IntPtr ppvParameter, out uint pdwPingInterval, out int pdwFlags);

	/// <summary>Retrieves the restart information registered for the specified process.</summary>
	/// <param name="hProcess">A handle to the process. This handle must have the PROCESS_VM_READ access right.</param>
	/// <param name="pwzCommandline">
	/// A pointer to a buffer that receives the restart command line specified by the application when it called the
	/// <c>RegisterApplicationRestart</c> function. The maximum size of the command line, in characters, is RESTART_MAX_CMD_LINE. Can be
	/// <c>NULL</c> if pcchSize is zero.
	/// </param>
	/// <param name="pcchSize">
	/// <para>On input, specifies the size of the pwzCommandLine buffer, in characters.</para>
	/// <para>
	/// If the buffer is not large enough to receive the command line, the function fails with
	/// HRESULT_FROM_WIN32(ERROR_INSUFFICIENT_BUFFER) and sets this parameter to the required buffer size, in characters.
	/// </para>
	/// <para>On output, specifies the size of the buffer that was used.</para>
	/// <para>
	/// To determine the required buffer size, set pwzCommandLine to <c>NULL</c> and this parameter to zero. The size includes one for
	/// the <c>null</c>-terminator character. Note that the function returns S_OK, not HRESULT_FROM_WIN32(ERROR_INSUFFICIENT_BUFFER) in
	/// this case.
	/// </para>
	/// </param>
	/// <param name="pdwFlags">
	/// A pointer to a variable that receives the flags specified by the application when it called the <c>RegisterApplicationRestart</c> function.
	/// </param>
	/// <returns>
	/// <para>This function returns <c>S_OK</c> on success or one of the following error codes.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One or more parameters are not valid.</term>
	/// </item>
	/// <item>
	/// <term>HRESULT_FROM_WIN32(ERROR_NOT_FOUND)</term>
	/// <term>The application did not register for restart.</term>
	/// </item>
	/// <item>
	/// <term>HRESULT_FROM_WIN32(ERROR_INSUFFICIENT_BUFFER)</term>
	/// <term>
	/// The pwzCommandLine buffer is too small. The function returns the required buffer size in pcchSize. Use the required size to
	/// reallocate the buffer.
	/// </term>
	/// </item>
	/// </list>
	/// </para>
	/// </returns>
	// HRESULT WINAPI GetApplicationRestartSettings( _In_ HANDLE hProcess, _Out_opt_ PWSTR pwzCommandline, _Inout_ PDWORD pcchSize,
	// _Out_opt_ PDWORD pdwFlags); https://msdn.microsoft.com/en-us/library/windows/desktop/aa373344(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("Winbase.h", MSDNShortId = "aa373344")]
	public static extern HRESULT GetApplicationRestartSettings([In] HPROCESS hProcess, [Out, SizeDef(nameof(pcchSize), SizingMethod.Query | SizingMethod.CheckLastError)] StringBuilder? pwzCommandline,
		[Range(0, RESTART_MAX_CMD_LINE)] ref uint pcchSize, out ApplicationRestartFlags pdwFlags);

	/// <summary>The <c>GetCurrentActCtx</c> function returns the handle to the active activation context of the calling thread.</summary>
	/// <param name="lphActCtx">
	/// Pointer to the returned <c>ACTCTX</c> structure that contains information on the active activation context.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>TRUE</c>. Otherwise, it returns <c>FALSE</c>.</para>
	/// <para>
	/// This function sets errors that can be retrieved by calling <c>GetLastError</c>. For an example, see Retrieving the Last-Error
	/// Code. For a complete list of error codes, see System Error Codes.
	/// </para>
	/// </returns>
	// BOOL GetCurrentActCtx( _Out_ HANDLE *lphActCtx); https://msdn.microsoft.com/en-us/library/windows/desktop/aa375152(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("Winbase.h", MSDNShortId = "aa375152")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetCurrentActCtx(out HACTCTX lphActCtx);

	/// <summary>
	/// The <c>QueryActCtxSettingsW</c> function specifies the activation context, and the namespace and name of the attribute that is to
	/// be queried.
	/// </summary>
	/// <param name="dwFlags">This value must be 0.</param>
	/// <param name="hActCtx">A handle to the activation context that is being queried.</param>
	/// <param name="settingsNameSpace">
	/// <para>
	/// A pointer to a string that contains the value <c>"http://schemas.microsoft.com/SMI/2005/WindowsSettings"</c> or <c>NULL</c>.
	/// These values are equivalent.
	/// </para>
	/// <para>
	/// <c>Windows 8 and Windows Server 2012:</c> A pointer to a string that contains the value
	/// <c>"http://schemas.microsoft.com/SMI/2011/WindowsSettings"</c> is also a valid parameter. A <c>NULL</c> is still equivalent to
	/// the previous value.
	/// </para>
	/// </param>
	/// <param name="settingName">The name of the attribute to be queried.</param>
	/// <param name="pvBuffer">A pointer to the buffer that receives the query result.</param>
	/// <param name="dwBuffer">The size of the buffer in characters that receives the query result.</param>
	/// <param name="pdwWrittenOrRequired">
	/// A pointer to a value which is the number of characters written to the buffer specified by pvBuffer or that is required to hold
	/// the query result.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>TRUE</c>. Otherwise, it returns <c>FALSE</c>.</para>
	/// <para>
	/// This function sets errors that can be retrieved by calling <c>GetLastError</c>. For an example, see Retrieving the Last-Error
	/// Code. For a complete list of error codes, see System Error Codes.
	/// </para>
	/// </returns>
	// BOOL QueryActCtxSettingsW( _In_opt_ DWORD dwFlags, _In_opt_ HANDLE hActCtx, _In_opt_ PCWSTR settingsNameSpace, _In_ PCWSTR
	// settingName, _Out_ PWSTR pvBuffer, _In_ SIZE_T dwBuffer, _Out_opt_ SIZE_T *pdwWrittenOrRequired); https://msdn.microsoft.com/en-us/library/windows/desktop/aa375700(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("Winbase.h", MSDNShortId = "aa375700")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool QueryActCtxSettingsW([Optional, Ignore] uint dwFlags, [In, AddAsMember] HACTCTX hActCtx, [Optional, Ignore] string? settingsNameSpace,
		string settingName, [Out, SizeDef(nameof(dwBuffer), SizingMethod.Query, OutVarName = nameof(pdwWrittenOrRequired))] StringBuilder? pvBuffer, SizeT dwBuffer, out SizeT pdwWrittenOrRequired);

	/// <summary>The <c>QueryActCtxW</c> function queries the activation context.</summary>
	/// <param name="dwFlags">
	/// <para>This parameter should be set to one of the following flag bits.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Flag</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>QUERY_ACTCTX_FLAG_USE_ACTIVE_ACTCTX</term>
	/// <term>
	/// QueryActCtxW queries the activation context active on the thread instead of the context specified by hActCtx. This is usually the
	/// last activation context passed to ActivateActCtx. If ActivateActCtx has not been called, the active activation context can be the
	/// activation context used by the executable of the current process. In other cases, the operating system determines the active
	/// activation context. For example, when the callback function to a new thread is called, the active activation context may be the
	/// context that was active when you created the thread by calling CreateThread.
	/// </term>
	/// </item>
	/// <item>
	/// <term>QUERY_ACTCTX_FLAG_ACTCTX_IS_HMODULE</term>
	/// <term>
	/// QueryActCtxW interprets hActCtx as an HMODULE data type and queries an activation context that is associated with a DLL or EXE.
	/// When a DLL or EXE is loaded, the loader checks for a manifest stored in a resource. If the loader finds an RT_MANIFEST resource
	/// with a resource identifier set to ISOLATIONAWARE_MANIFEST_ RESOURCE_ID, the loader associates the resulting activation context
	/// with the DLL or EXE. This is the activation context that QueryActCtxW queries when the QUERY_ACTCTX_FLAG_ACTCTX_IS_HMODULE flag
	/// has been set.
	/// </term>
	/// </item>
	/// <item>
	/// <term>QUERY_ACTCTX_FLAG_ACTCTX_IS_ADDRESS</term>
	/// <term>
	/// QueryActCtxW interprets hActCtx as an address within a DLL or EXE and queries an activation context that has been associated with
	/// the DLL or EXE. This can be any address within the DLL or EXE. For example, the address of any function within a DLL or EXE or
	/// the address of any static data, such as a constant string. When a DLL or EXE is loaded, the loader checks for a manifest stored
	/// in a resource in the same way as QUERY_ACTCTX_FLAG_ACTCTX_IS_HMODULE.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="hActCtx">Handle to the activation context that is being queried.</param>
	/// <param name="pvSubInstance">
	/// <para>
	/// Index of the assembly, or assembly and file combination, in the activation context. The meaning of the pvSubInstance depends on
	/// the option specified by the value of the ulInfoClass parameter.
	/// </para>
	/// <para>This parameter may be null.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>ulInfoClass Option</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>AssemblyDetailedInformationInActivationContext</term>
	/// <term>
	/// Pointer to a DWORD that specifies the index of the assembly within the activation context. This is the activation context that
	/// QueryActCtxW queries.
	/// </term>
	/// </item>
	/// <item>
	/// <term>FileInformationInAssemblyOfAssemblyInActivationContext</term>
	/// <term>
	/// Pointer to an ACTIVATION_CONTEXT_QUERY_INDEX structure. If QueryActCtxW is called with this option and the function succeeds, the
	/// returned buffer contains information for a file in the assembly. This information is in the form of the
	/// ASSEMBLY_FILE_DETAILED_INFORMATION structure.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="ulInfoClass">
	/// <para>This parameter can have only the values shown in the following table.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Option</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ActivationContextBasicInformation 1</term>
	/// <term>Not available.</term>
	/// </item>
	/// <item>
	/// <term>ActivationContextDetailedInformation 2</term>
	/// <term>
	/// If QueryActCtxW is called with this option and the function succeeds, the returned buffer contains detailed information about the
	/// activation context. This information is in the form of the ACTIVATION_CONTEXT_DETAILED_INFORMATION structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>AssemblyDetailedInformationInActivationContext 3</term>
	/// <term>
	/// If QueryActCtxW is called with this option and the function succeeds, the buffer contains information about the assembly that has
	/// the index specified in pvSubInstance. This information is in the form of the ACTIVATION_CONTEXT_ASSEMBLY_DETAILED_INFORMATION structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>FileInformationInAssemblyOfAssemblyInActivationContext 4</term>
	/// <term>
	/// Information about a file in one of the assemblies in Activation Context. The pvSubInstance parameter must point to an
	/// ACTIVATION_CONTEXT_QUERY_INDEX structure. If QueryActCtxW is called with this option and the function succeeds, the returned
	/// buffer contains information for a file in the assembly. This information is in the form of the ASSEMBLY_FILE_DETAILED_INFORMATION structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>RunlevelInformationInActivationContext 5</term>
	/// <term>
	/// If QueryActCtxW is called with this option and the function succeeds, the buffer contains information about requested run level
	/// of the activation context. This information is in the form of the ACTIVATION_CONTEXT_RUN_LEVEL_INFORMATION structure. Windows
	/// Server 2003 and Windows XP: This value is not available.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CompatibilityInformationInActivationContext 6</term>
	/// <term>
	/// If QueryActCtxW is called with this option and the function succeeds, the buffer contains information about requested
	/// compatibility context. This information is in the form of the ACTIVATION_CONTEXT_COMPATIBILITY_INFORMATION structure. Windows
	/// Server 2008 and earlier, and Windows Vista and earlier: This value is not available. This option is available beginning with
	/// Windows Server 2008 R2 and Windows 7.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pvBuffer">
	/// Pointer to a buffer that holds the returned information. This parameter is optional. If pvBuffer is <c>null</c>, then cbBuffer
	/// must be zero. If the size of the buffer pointed to by pvBuffer is too small, <c>QueryActCtxW</c> returns
	/// ERROR_INSUFFICIENT_BUFFER and no data is written into the buffer. See the Remarks section for the method you can use to determine
	/// the required size of the buffer.
	/// </param>
	/// <param name="cbBuffer">Size of the buffer in bytes pointed to by pvBuffer. This parameter is optional.</param>
	/// <param name="pcbWrittenOrRequired">
	/// Number of bytes written or required. The parameter pcbWrittenOrRequired can only be <c>NULL</c> when pvBuffer is <c>NULL</c>. If
	/// pcbWrittenOrRequired is non- <c>NULL</c>, it is filled with the number of bytes required to store the returned buffer.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>TRUE</c>. Otherwise, it returns <c>FALSE</c>.</para>
	/// <para>
	/// This function sets errors that can be retrieved by calling GetLastError. For an example, see Retrieving the Last-Error Code. For
	/// a complete list of error codes, see System Error Codes.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The parameter cbBuffer specifies the size in bytes of the buffer pointed to by pvBuffer. If pvBuffer is <c>NULL</c>, then
	/// cbBuffer must be 0. The parameter pcbWrittenOrRequired can only be <c>NULL</c> if pvBuffer is <c>NULL</c>. If
	/// pcbWrittenOrRequired is non- <c>NULL</c> on return, it is filled with the number of bytes required to store the returned
	/// information. When the information data returned is larger than the provided buffer, <c>QueryActCtxW</c> returns
	/// ERROR_INSUFFICIENT_BUFFER and no data is written to the buffer pointed to by pvBuffer.
	/// </para>
	/// <para>The following example shows the method of calling first with a small buffer and then recalling if the buffer is too small.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-queryactctxw
	// BOOL QueryActCtxW( DWORD dwFlags, HANDLE hActCtx, PVOID pvSubInstance, ULONG ulInfoClass, PVOID pvBuffer, SIZE_T cbBuffer, SIZE_T *pcbWrittenOrRequired );
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("winbase.h", MSDNShortId = "7d45f63f-0baf-4236-b245-d36f9eb32e8c")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool QueryActCtxW(QueryActCtxFlag dwFlags, [In] HACTCTX hActCtx, [In, Optional] IntPtr pvSubInstance,
		ACTIVATION_CONTEXT_INFO_CLASS ulInfoClass, IntPtr pvBuffer, SizeT cbBuffer, out SizeT pcbWrittenOrRequired);

	/// <summary>The <c>QueryActCtxW</c> function queries the activation context.</summary>
	/// <typeparam name="T">The type of the requested return value.</typeparam>
	/// <param name="dwFlags">
	/// <para>This parameter should be set to one of the following flag bits.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Flag</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>QUERY_ACTCTX_FLAG_USE_ACTIVE_ACTCTX</term>
	/// <term>
	/// QueryActCtxW queries the activation context active on the thread instead of the context specified by hActCtx. This is usually the
	/// last activation context passed to ActivateActCtx. If ActivateActCtx has not been called, the active activation context can be the
	/// activation context used by the executable of the current process. In other cases, the operating system determines the active
	/// activation context. For example, when the callback function to a new thread is called, the active activation context may be the
	/// context that was active when you created the thread by calling CreateThread.
	/// </term>
	/// </item>
	/// <item>
	/// <term>QUERY_ACTCTX_FLAG_ACTCTX_IS_HMODULE</term>
	/// <term>
	/// QueryActCtxW interprets hActCtx as an HMODULE data type and queries an activation context that is associated with a DLL or EXE.
	/// When a DLL or EXE is loaded, the loader checks for a manifest stored in a resource. If the loader finds an RT_MANIFEST resource
	/// with a resource identifier set to ISOLATIONAWARE_MANIFEST_ RESOURCE_ID, the loader associates the resulting activation context
	/// with the DLL or EXE. This is the activation context that QueryActCtxW queries when the QUERY_ACTCTX_FLAG_ACTCTX_IS_HMODULE flag
	/// has been set.
	/// </term>
	/// </item>
	/// <item>
	/// <term>QUERY_ACTCTX_FLAG_ACTCTX_IS_ADDRESS</term>
	/// <term>
	/// QueryActCtxW interprets hActCtx as an address within a DLL or EXE and queries an activation context that has been associated with
	/// the DLL or EXE. This can be any address within the DLL or EXE. For example, the address of any function within a DLL or EXE or
	/// the address of any static data, such as a constant string. When a DLL or EXE is loaded, the loader checks for a manifest stored
	/// in a resource in the same way as QUERY_ACTCTX_FLAG_ACTCTX_IS_HMODULE.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="hActCtx">Handle to the activation context that is being queried.</param>
	/// <param name="ulInfoClass">
	/// <para>This parameter can have only the values shown in the following table.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Option</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ActivationContextBasicInformation 1</term>
	/// <term>Not available.</term>
	/// </item>
	/// <item>
	/// <term>ActivationContextDetailedInformation 2</term>
	/// <term>
	/// If QueryActCtxW is called with this option and the function succeeds, the returned buffer contains detailed information about the
	/// activation context. This information is in the form of the ACTIVATION_CONTEXT_DETAILED_INFORMATION structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>AssemblyDetailedInformationInActivationContext 3</term>
	/// <term>
	/// If QueryActCtxW is called with this option and the function succeeds, the buffer contains information about the assembly that has
	/// the index specified in pvSubInstance. This information is in the form of the ACTIVATION_CONTEXT_ASSEMBLY_DETAILED_INFORMATION structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>FileInformationInAssemblyOfAssemblyInActivationContext 4</term>
	/// <term>
	/// Information about a file in one of the assemblies in Activation Context. The pvSubInstance parameter must point to an
	/// ACTIVATION_CONTEXT_QUERY_INDEX structure. If QueryActCtxW is called with this option and the function succeeds, the returned
	/// buffer contains information for a file in the assembly. This information is in the form of the ASSEMBLY_FILE_DETAILED_INFORMATION structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>RunlevelInformationInActivationContext 5</term>
	/// <term>
	/// If QueryActCtxW is called with this option and the function succeeds, the buffer contains information about requested run level
	/// of the activation context. This information is in the form of the ACTIVATION_CONTEXT_RUN_LEVEL_INFORMATION structure. Windows
	/// Server 2003 and Windows XP: This value is not available.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CompatibilityInformationInActivationContext 6</term>
	/// <term>
	/// If QueryActCtxW is called with this option and the function succeeds, the buffer contains information about requested
	/// compatibility context. This information is in the form of the ACTIVATION_CONTEXT_COMPATIBILITY_INFORMATION structure. Windows
	/// Server 2008 and earlier, and Windows Vista and earlier: This value is not available. This option is available beginning with
	/// Windows Server 2008 R2 and Windows 7.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pvSubInstance">
	/// <para>
	/// Index of the assembly, or assembly and file combination, in the activation context. The meaning of the pvSubInstance depends on
	/// the option specified by the value of the ulInfoClass parameter.
	/// </para>
	/// <para>This parameter may be null.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>ulInfoClass Option</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>AssemblyDetailedInformationInActivationContext</term>
	/// <term>
	/// Pointer to a DWORD that specifies the index of the assembly within the activation context. This is the activation context that
	/// QueryActCtxW queries.
	/// </term>
	/// </item>
	/// <item>
	/// <term>FileInformationInAssemblyOfAssemblyInActivationContext</term>
	/// <term>
	/// Pointer to an ACTIVATION_CONTEXT_QUERY_INDEX structure. If QueryActCtxW is called with this option and the function succeeds, the
	/// returned buffer contains information for a file in the assembly. This information is in the form of the
	/// ASSEMBLY_FILE_DETAILED_INFORMATION structure.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>The returned information.</returns>
	/// <exception cref="ArgumentException"></exception>
	public static T QueryActCtxW<T>(QueryActCtxFlag dwFlags, [In, AddAsMember] HACTCTX hActCtx, ACTIVATION_CONTEXT_INFO_CLASS ulInfoClass, [In] object? pvSubInstance = null) where T : struct
	{
		if (!CorrespondingTypeAttribute.CanGet(ulInfoClass, typeof(T))) throw new ArgumentException(null, nameof(ulInfoClass));
		if (!QueryActCtxW(dwFlags, hActCtx, pvSubInstance is null ? IntPtr.Zero : new PinnedObject(pvSubInstance), ulInfoClass, default, 0, out var req) && req == 0)
			Win32Error.ThrowLastError();
		using var mem = new SafeCoTaskMemHandle(req);
		if (!QueryActCtxW(dwFlags, hActCtx, pvSubInstance is null ? IntPtr.Zero : new PinnedObject(pvSubInstance), ulInfoClass, (IntPtr)mem, mem.Size, out req))
			Win32Error.ThrowLastError();
		if (typeof(T) == typeof(ACTIVATION_CONTEXT_COMPATIBILITY_INFORMATION))
			return (T)(object)new ACTIVATION_CONTEXT_COMPATIBILITY_INFORMATION((IntPtr)mem);
		return mem.ToStructure<T>();
	}

	/// <summary>Registers the active instance of an application for recovery.</summary>
	/// <param name="pRecoveryCallback">A pointer to the recovery callback function. For more information, see <c>ApplicationRecoveryCallback</c>.</param>
	/// <param name="pvParameter">A pointer to a variable to be passed to the callback function. Can be <c>NULL</c>.</param>
	/// <param name="dwPingInterval">
	/// <para>
	/// The recovery ping interval, in milliseconds. By default, the interval is 5 seconds (RECOVERY_DEFAULT_PING_INTERVAL). The maximum
	/// interval is 5 minutes. If you specify zero, the default interval is used.
	/// </para>
	/// <para>
	/// You must call the <c>ApplicationRecoveryInProgress</c> function within the specified interval to indicate to ARR that you are
	/// still actively recovering; otherwise, WER terminates recovery. Typically, you perform recovery in a loop with each iteration
	/// lasting no longer than the ping interval. Each iteration performs a block of recovery work followed by a call to
	/// <c>ApplicationRecoveryInProgress</c>. Since you also use <c>ApplicationRecoveryInProgress</c> to determine if the user wants to
	/// cancel recovery, you should consider a smaller interval, so you do not perform a lot of work unnecessarily.
	/// </para>
	/// </param>
	/// <param name="dwFlags">Reserved for future use. Set to zero.</param>
	/// <returns>
	/// <para>This function returns <c>S_OK</c> on success or one of the following error codes.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_FAIL</term>
	/// <term>Internal error; the registration failed.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>The ping interval cannot be more than five minutes.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </returns>
	// HRESULT WINAPI RegisterApplicationRecoveryCallback( _In_ APPLICATION_RECOVERY_CALLBACK pRecoveryCallback, _In_opt_ PVOID
	// pvParameter, _In_ DWORD dwPingInterval, _In_ DWORD dwFlags); https://msdn.microsoft.com/en-us/library/windows/desktop/aa373345(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Winbase.h", MSDNShortId = "aa373345")]
	public static extern HRESULT RegisterApplicationRecoveryCallback(ApplicationRecoveryCallback pRecoveryCallback, [Optional] IntPtr pvParameter, [Optional] uint dwPingInterval, [Optional] uint dwFlags);

	/// <summary>Registers the active instance of an application for restart.</summary>
	/// <param name="pwzCommandline">
	/// <para>
	/// A pointer to a Unicode string that specifies the command-line arguments for the application when it is restarted. The maximum
	/// size of the command line that you can specify is RESTART_MAX_CMD_LINE characters. Do not include the name of the executable in
	/// the command line; this function adds it for you.
	/// </para>
	/// <para>
	/// If this parameter is <c>NULL</c> or an empty string, the previously registered command line is removed. If the argument contains
	/// spaces, use quotes around the argument.
	/// </para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>This parameter can be 0 or one or more of the following values.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>RESTART_NO_CRASH1</term>
	/// <term>Do not restart the process if it terminates due to an unhandled exception.</term>
	/// </item>
	/// <item>
	/// <term>RESTART_NO_HANG2</term>
	/// <term>Do not restart the process if it terminates due to the application not responding.</term>
	/// </item>
	/// <item>
	/// <term>RESTART_NO_PATCH4</term>
	/// <term>Do not restart the process if it terminates due to the installation of an update.</term>
	/// </item>
	/// <item>
	/// <term>RESTART_NO_REBOOT8</term>
	/// <term>Do not restart the process if the computer is restarted as the result of an update.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <returns>
	/// <para>This function returns <c>S_OK</c> on success or one of the following error codes.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_FAIL</term>
	/// <term>Internal error.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>The specified command line is too long.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </returns>
	// HRESULT WINAPI RegisterApplicationRestart( _In_opt_ PCWSTR pwzCommandline, _In_ DWORD dwFlags); https://msdn.microsoft.com/en-us/library/windows/desktop/aa373347(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("Winbase.h", MSDNShortId = "aa373347")]
	public static extern HRESULT RegisterApplicationRestart(string? pwzCommandline, [Optional] ApplicationRestartFlags dwFlags);

	/// <summary>The <c>ReleaseActCtx</c> function decrements the reference count of the specified activation context.</summary>
	/// <param name="hActCtx">
	/// Handle to the <c>ACTCTX</c> structure that contains information on the activation context for which the reference count is to be decremented.
	/// </param>
	/// <returns>
	/// This function does not return a value. On successful completion, the activation context reference count is decremented. The
	/// recipient of the reference-counted object must decrement the reference count when the object is no longer required.
	/// </returns>
	// void ReleaseActCtx( _In_ HANDLE hActCtx); https://msdn.microsoft.com/en-us/library/windows/desktop/aa375713(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Winbase.h", MSDNShortId = "aa375713")]
	public static extern void ReleaseActCtx([In, AddAsMember] HACTCTX hActCtx);

	/// <summary>Removes the active instance of an application from the recovery list.</summary>
	/// <returns>
	/// <para>This function returns <c>S_OK</c> on success or one of the following error codes.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_FAIL</term>
	/// <term>Internal error.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </returns>
	// HRESULT WINAPI UnregisterApplicationRecoveryCallback(void); https://msdn.microsoft.com/en-us/library/windows/desktop/aa373348(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Winbase.h", MSDNShortId = "aa373348")]
	public static extern HRESULT UnregisterApplicationRecoveryCallback();

	/// <summary>Removes the active instance of an application from the restart list.</summary>
	/// <remarks>
	/// You do not need to call this function before exiting. You need to remove the registration only if you choose to not restart the
	/// application. For example, you could remove the registration if your application entered a corrupted state where a future restart
	/// would also fail. You must call this function before the application fails abnormally.
	/// </remarks>
	/// <returns>This function returns S_OK on success</returns>
	[DllImport(Lib.Kernel32, ExactSpelling = true)]
	[PInvokeData("Winbase.h", MSDNShortId = "aa373349")]
	public static extern HRESULT UnregisterApplicationRestart();

	/// <summary>The <c>ZombifyActCtx</c> function deactivates the specified activation context, but does not deallocate it.</summary>
	/// <param name="hActCtx">Handle to the activation context that is to be deactivated.</param>
	/// <returns>
	/// <para>
	/// If the function succeeds, it returns <c>TRUE</c>. If a <c>null</c> handle is passed in the hActCtx parameter,
	/// NULL_INVALID_PARAMETER will be returned. Otherwise, it returns <c>FALSE</c>.
	/// </para>
	/// <para>
	/// This function sets errors that can be retrieved by calling <c>GetLastError</c>. For an example, see Retrieving the Last-Error
	/// Code. For a complete list of error codes, see System Error Codes.
	/// </para>
	/// </returns>
	// BOOL ZombifyActCtx( _In_ HANDLE hActCtx); https://msdn.microsoft.com/en-us/library/windows/desktop/aa376622(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("Winbase.h", MSDNShortId = "aa376622")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ZombifyActCtx(HACTCTX hActCtx);

	/// <summary>The ACTCTX structure is used by the CreateActCtx function to create the activation context.</summary>
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	[PInvokeData("Winbase.h", MSDNShortId = "aa374149")]
	public struct ACTCTX(string? source = null)
	{
		/// <summary>The size, in bytes, of this structure. This is used to determine the version of this structure.</summary>
		public int cbSize = Marshal.SizeOf<ACTCTX>();

		/// <summary>
		/// Flags that indicate how the values included in this structure are to be used. Set any undefined bits in dwFlags to 0. If any
		/// undefined bits are not set to 0, the call to CreateActCtx that creates the activation context fails and returns an invalid
		/// parameter error code.
		/// </summary>
		public ActCtxFlags dwFlags;

		/// <summary>
		/// Null-terminated string specifying the path of the manifest file or PE image to be used to create the activation context. If
		/// this path refers to an EXE or DLL file, the lpResourceName member is required.
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string? lpSource = source;

		/// <summary>Identifies the type of processor used. Specifies the system's processor architecture.</summary>
		public ProcessorArchitecture wProcessorArchitecture;

		/// <summary>
		/// Specifies the language manifest that should be used. The default is the current user's current UI language.
		/// <para>If the requested language cannot be found, an approximation is searched for using the following order:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>The current user's specific language. For example, for US English (1033).</description>
		/// </item>
		/// <item>
		/// <description>The current user's primary language. For example, for English (9).</description>
		/// </item>
		/// <item>
		/// <description>The current system's specific language.</description>
		/// </item>
		/// <item>
		/// <description>The current system's primary language.</description>
		/// </item>
		/// <item>
		/// <description>A nonspecific worldwide language. Language neutral (0).</description>
		/// </item>
		/// </list>
		/// </summary>
		public ushort wLangId;

		/// <summary>
		/// The base directory in which to perform private assembly probing if assemblies in the activation context are not present in
		/// the system-wide store.
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string? lpAssemblyDirectory;

		/// <summary>
		/// Pointer to a null-terminated string that contains the resource name to be loaded from the PE specified in hModule or
		/// lpSource. If the resource name is an integer, set this member using MAKEINTRESOURCE. This member is required if lpSource
		/// refers to an EXE or DLL.
		/// </summary>
		public ResourceId lpResourceName;

		/// <summary>
		/// The name of the current application. If the value of this member is set to null, the name of the executable that launched the
		/// current process is used.
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string? lpApplicationName;

		/// <summary>
		/// Use this member rather than lpSource if you have already loaded a DLL and wish to use it to create activation contexts rather
		/// than using a path in lpSource. See lpResourceName for the rules of looking up resources in this module.
		/// </summary>
		public HINSTANCE hModule;

		/// <summary>Gets an empty instance with only the cbSize parameter initialized.</summary>
		public static ACTCTX Empty => new();
	}

	/// <summary>
	/// The <c>ACTCTX_SECTION_KEYED_DATA</c> structure is used by the <c>FindActCtxSectionString</c> and <c>FindActCtxSectionGuid</c>
	/// functions to return the activation context information along with either the GUID or 32-bit integer-tagged activation context section.
	/// </summary>
	// typedef struct tagACTCTX_SECTION_KEYED_DATA { ULONG cbSize; ULONG ulDataFormatVersion; PVOID lpData; ULONG ulLength; PVOID
	// lpSectionGlobalData; ULONG ulSectionGlobalDataLength; PVOID lpSectionBase; ULONG ulSectionTotalLength; HANDLE hActCtx; HANDLE
	// ulAssemblyRosterIndex;} ACTCTX_SECTION_KEYED_DATA, *PACTCTX_SECTION_KEYED_DATA;
	[StructLayout(LayoutKind.Sequential)]
	[PInvokeData("Winbase.h", MSDNShortId = "aa374148")]
	public struct ACTCTX_SECTION_KEYED_DATA
	{
		/// <summary>The size, in bytes, of the activation context keyed data structure.</summary>
		public uint cbSize;

		/// <summary>
		/// Number that indicates the format of the data in the section where the key was found. Clients should verify that the data
		/// format version is as expected rather than trying to interpret the values of unfamiliar data formats. This number is only
		/// changed when major non-backward-compatible changes to the section data formats need to be made. The current format version is 1.
		/// </summary>
		public uint ulDataFormatVersion;

		/// <summary>Pointer to the redirection data found associated with the section identifier and key.</summary>
		public IntPtr lpData;

		/// <summary>
		/// Number of bytes in the structure referred to by <c>lpData</c>. Note that the data structures grow over time; do not access
		/// members in the instance data that extend beyond <c>ulLength</c>.
		/// </summary>
		public uint ulLength;

		/// <summary>
		/// Returned pointer to a section-specific data structure which is global to the activation context section where the key was
		/// found. Its interpretation depends on the section identifier requested.
		/// </summary>
		public IntPtr lpSectionGlobalData;

		/// <summary>
		/// <para>Number of bytes in the section global data block referred to by <c>lpSectionGlobalData</c>.</para>
		/// <para>
		/// Note that the data structures grow over time and you may receive an old format activation context data block; do not access
		/// members in the section global data that extend beyond <c>ulSectionGlobalDataLength</c>.
		/// </para>
		/// </summary>
		public uint ulSectionGlobalDataLength;

		/// <summary>
		/// Pointer to the base of the section where the key was found. Some instance data contains offsets relative to the section base
		/// address, in which case this pointer value is used.
		/// </summary>
		public IntPtr lpSectionBase;

		/// <summary>
		/// Number of bytes for the entire section starting at <c>lpSectionBase</c>. May be used to verify that offset/length pairs,
		/// which are specified as relative to the section base are wholly contained in the section.
		/// </summary>
		public uint ulSectionTotalLength;

		/// <summary>
		/// <para>
		/// Handle to the activation context where the key was found. First, the active activation context for the thread is searched,
		/// followed by the process-default activation context and then the system-compatible-default-activation context. This member
		/// indicates which activation context contained the section and key requested. This is only returned if the
		/// FIND_ACTCTX_SECTION_KEY_RETURN_HACTCTX flag is passed.
		/// </para>
		/// <para>
		/// Note that when this is returned, the caller must call <c>ReleaseActCtx</c>() on the activation context handle returned to
		/// release system resources when all other references to the activation context have been released.
		/// </para>
		/// </summary>
		public HACTCTX hActCtx;

		/// <summary>
		/// Cardinal number of the assembly in the activation context that provided the redirection information found. This value can be
		/// presented to <c>QueryActCtxW</c> for more information about the contributing assembly.
		/// </summary>
		public uint ulAssemblyRosterIndex;
	}

	/// <summary>The <c>ACTIVATION_CONTEXT_ASSEMBLY_DETAILED_INFORMATION</c> structure is used by the QueryActCtxW function.</summary>
	/// <remarks>
	/// If QueryActCtxW is called with the AssemblyDetailedInformationInActivationContext option, and the function succeeds, the
	/// information in the returned buffer is in the form of the <c>ACTIVATION_CONTEXT_ASSEMBLY_DETAILED_INFORMATION</c> structure.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-activation_context_assembly_detailed_information typedef struct
	// _ACTIVATION_CONTEXT_ASSEMBLY_DETAILED_INFORMATION { DWORD ulFlags; DWORD ulEncodedAssemblyIdentityLength; DWORD
	// ulManifestPathType; DWORD ulManifestPathLength; LARGE_INTEGER liManifestLastWriteTime; DWORD ulPolicyPathType; DWORD
	// ulPolicyPathLength; LARGE_INTEGER liPolicyLastWriteTime; DWORD ulMetadataSatelliteRosterIndex; DWORD ulManifestVersionMajor; DWORD
	// ulManifestVersionMinor; DWORD ulPolicyVersionMajor; DWORD ulPolicyVersionMinor; DWORD ulAssemblyDirectoryNameLength; PCWSTR
	// lpAssemblyEncodedAssemblyIdentity; PCWSTR lpAssemblyManifestPath; PCWSTR lpAssemblyPolicyPath; PCWSTR lpAssemblyDirectoryName;
	// DWORD ulFileCount; } ACTIVATION_CONTEXT_ASSEMBLY_DETAILED_INFORMATION, *PACTIVATION_CONTEXT_ASSEMBLY_DETAILED_INFORMATION;
	[PInvokeData("winnt.h", MSDNShortId = "b093cc6a-55ea-49bf-904d-2b43517f9b02")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct ACTIVATION_CONTEXT_ASSEMBLY_DETAILED_INFORMATION
	{
		/// <summary>This value is always 0.</summary>
		public uint ulFlags;

		/// <summary>Length of the encoded assembly identity in bytes.</summary>
		public uint ulEncodedAssemblyIdentityLength;

		/// <summary>This value always a constant.</summary>
		public uint ulManifestPathType;

		/// <summary>Length of the assembly manifest path in bytes.</summary>
		public uint ulManifestPathLength;

		/// <summary>The last time the manifest was written. This is in the form of a <c>FILETIME</c> data structure.</summary>
		public int liManifestLastWriteTime;

		/// <summary>This value always a constant.</summary>
		public uint ulPolicyPathType;

		/// <summary>Length of the publisher policy path in bytes.</summary>
		public uint ulPolicyPathLength;

		/// <summary>The last time the policy was written. This is in the form of a <c>FILETIME</c> data structure.</summary>
		public int liPolicyLastWriteTime;

		/// <summary>Metadata satellite roster index.</summary>
		public uint ulMetadataSatelliteRosterIndex;

		/// <summary>Major version of the assembly queried by QueryActCtxW. For more information, see Assembly Versions.</summary>
		public uint ulManifestVersionMajor;

		/// <summary>Minor version of the assembly queried by QueryActCtxW. For more information, see Assembly Versions.</summary>
		public uint ulManifestVersionMinor;

		/// <summary>Major version of any policy, if one exists.</summary>
		public uint ulPolicyVersionMajor;

		/// <summary>Minor version of any policy, if one exists.</summary>
		public uint ulPolicyVersionMinor;

		/// <summary>Length of the assembly directory name in bytes.</summary>
		public uint ulAssemblyDirectoryNameLength;

		/// <summary>Pointer to a null-terminated string that contains a textually-encoded format of the assembly's identity.</summary>
		[MarshalAs(UnmanagedType.LPWStr)] public string lpAssemblyEncodedAssemblyIdentity;

		/// <summary>Pointer to a null-terminated string that indicates the original path to this assembly's manifest.</summary>
		[MarshalAs(UnmanagedType.LPWStr)] public string lpAssemblyManifestPath;

		/// <summary>
		/// Pointer to a null-terminated string that indicates the path of whatever policy assembly was used to determine that this
		/// version of the assembly should be loaded. If this member is null, no policy was used to decide to load this version.
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)] public string lpAssemblyPolicyPath;

		/// <summary>Pointer to a null-terminated string that indicates the folder from which this assembly was loaded.</summary>
		[MarshalAs(UnmanagedType.LPWStr)] public string lpAssemblyDirectoryName;

		/// <summary/>
		public uint ulFileCount;
	}

	/// <summary>Undocumented.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct ACTIVATION_CONTEXT_BASIC_INFORMATION
	{
		/// <summary>Undocumented.</summary>
		public HACTCTX hActCtx;

		/// <summary>Undocumented.</summary>
		public uint dwFlags;
	}

	/// <summary>The <c>ACTIVATION_CONTEXT_COMPATIBILITY_INFORMATION_UNMGD</c> structure is used by the QueryActCtxW function.</summary>
	/// <remarks>
	/// The following example requires Windows Server 2008 R2 or Windows 7 and shows the method to retrieve information about the
	/// compatibility context.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-activation_context_compatibility_information typedef struct
	// _ACTIVATION_CONTEXT_COMPATIBILITY_INFORMATION { DWORD ElementCount; COMPATIBILITY_CONTEXT_ELEMENT Elements[]; }
	// ACTIVATION_CONTEXT_COMPATIBILITY_INFORMATION, *PACTIVATION_CONTEXT_COMPATIBILITY_INFORMATION;
	[PInvokeData("winnt.h", MSDNShortId = "d8c1ef4a-8e64-45bd-a185-b4af7932a0d2")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ACTIVATION_CONTEXT_COMPATIBILITY_INFORMATION_UNMGD
	{
		/// <summary>The number of compatibility elements defined in the application manifest.</summary>
		public uint ElementCount;

		/// <summary>
		/// This is an array of COMPATIBILITY_CONTEXT_ELEMENT structures. Each structure describes one compatibility element in the
		/// application manifest.
		/// </summary>
		[SizeDef(nameof(ElementCount))]
		public ArrayPointer<COMPATIBILITY_CONTEXT_ELEMENT> Elements;
	}

	/// <summary>
	/// The <c>ACTIVATION_CONTEXT_COMPATIBILITY_INFORMATION</c> structure is the managed equivalent of the
	/// <c>ACTIVATION_CONTEXT_COMPATIBILITY_INFORMATION_UNMGD</c> structure used by the QueryActCtxW function.
	/// </summary>
	public struct ACTIVATION_CONTEXT_COMPATIBILITY_INFORMATION
	{
		/// <summary>
		/// This is an array of COMPATIBILITY_CONTEXT_ELEMENT structures. Each structure describes one compatibility element in the
		/// application manifest.
		/// </summary>
		public COMPATIBILITY_CONTEXT_ELEMENT[] Elements;

		/// <summary>Initializes a new instance of the <see cref="ACTIVATION_CONTEXT_COMPATIBILITY_INFORMATION"/> struct.</summary>
		/// <param name="mem">The unmanaged pointer to this info.</param>
		internal ACTIVATION_CONTEXT_COMPATIBILITY_INFORMATION(IntPtr mem)
		{
			ref ACTIVATION_CONTEXT_COMPATIBILITY_INFORMATION_UNMGD u = ref mem.AsRef<ACTIVATION_CONTEXT_COMPATIBILITY_INFORMATION_UNMGD>();
			Elements = u.Elements.ToArray(u.ElementCount);
		}
	}

	/// <summary>The <c>ACTIVATION_CONTEXT_DETAILED_INFORMATION</c> structure is used by the QueryActCtxW function.</summary>
	/// <remarks>
	/// If QueryActCtxW is called with the ActivationContextDetailedInformation option, and the function succeeds, the information in the
	/// returned buffer is in the form of the <c>ACTIVATION_CONTEXT_DETAILED_INFORMATION</c> structure. The following is an example of a
	/// structure used to hold detailed information about the activation context and a call from <c>QueryActCtxW</c>.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-activation_context_detailed_information typedef struct
	// _ACTIVATION_CONTEXT_DETAILED_INFORMATION { DWORD dwFlags; DWORD ulFormatVersion; DWORD ulAssemblyCount; DWORD
	// ulRootManifestPathType; DWORD ulRootManifestPathChars; DWORD ulRootConfigurationPathType; DWORD ulRootConfigurationPathChars;
	// DWORD ulAppDirPathType; DWORD ulAppDirPathChars; PCWSTR lpRootManifestPath; PCWSTR lpRootConfigurationPath; PCWSTR lpAppDirPath; }
	// ACTIVATION_CONTEXT_DETAILED_INFORMATION, *PACTIVATION_CONTEXT_DETAILED_INFORMATION;
	[PInvokeData("winnt.h", MSDNShortId = "58e4acfe-d5c8-45ae-bf32-469229ffc836")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct ACTIVATION_CONTEXT_DETAILED_INFORMATION
	{
		/// <summary>This value is always 0.</summary>
		public uint dwFlags;

		/// <summary>
		/// This value specifies the format of the returned information. On WindowsÂ XP and WindowsÂ Server 2003 this member is always 1.
		/// </summary>
		public uint ulFormatVersion;

		/// <summary>Number of assemblies in the activation context.</summary>
		public uint ulAssemblyCount;

		/// <summary>
		/// <para>Specifies the kind of path from which this assembly's manifest was loaded.</para>
		/// <para>This member is always one of the following constants:</para>
		/// </summary>
		public uint ulRootManifestPathType;

		/// <summary>Number of characters in the manifest path.</summary>
		public uint ulRootManifestPathChars;

		/// <summary>
		/// <para>Specifies the kind of path from which this assembly's application configuration manifest was loaded.</para>
		/// <para>This member is always one of the following constants:</para>
		/// </summary>
		public uint ulRootConfigurationPathType;

		/// <summary>Number of characters in any application configuration file path.</summary>
		public uint ulRootConfigurationPathChars;

		/// <summary>
		/// <para>Specifies the kind of path from which this application manifest was loaded.</para>
		/// <para>This member is always one of the following constants:</para>
		/// </summary>
		public uint ulAppDirPathType;

		/// <summary>Number of characters in the application directory.</summary>
		public uint ulAppDirPathChars;

		/// <summary>Path of the application manifest.</summary>
		[MarshalAs(UnmanagedType.LPWStr)] public string lpRootManifestPath;

		/// <summary>Path of the configuration file.</summary>
		[MarshalAs(UnmanagedType.LPWStr)] public string lpRootConfigurationPath;

		/// <summary>Path of the application directory.</summary>
		[MarshalAs(UnmanagedType.LPWStr)] public string lpAppDirPath;
	}

	/// <summary>The <c>ACTIVATION_CONTEXT_QUERY_INDEX</c> structure is used by QueryActCtxW function.</summary>
	/// <remarks>
	/// Calling the QueryActCtxW function with the FileInformationInAssemblyOfAssemblyInActivationContext option requires that the
	/// pvSubInstance parameter point to an <c>ACTIVATION_CONTEXT_QUERY_INDEX</c> structure. See the sample for
	/// ASSEMBLY_FILE_DETAILED_INFORMATION for an example of its use.
	/// </remarks>
	/// <remarks>Initializes a new instance of the <see cref="ACTIVATION_CONTEXT_QUERY_INDEX"/> struct.</remarks>
	/// <param name="asmIndex">One-based index of the assembly whose file table is to be queried.</param>
	/// <param name="fileIndex">Zero-based index of the file in the above assembly to be queried.</param>
	// https://docs.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-activation_context_query_index typedef struct
	// _ACTIVATION_CONTEXT_QUERY_INDEX { DWORD ulAssemblyIndex; DWORD ulFileIndexInAssembly; } ACTIVATION_CONTEXT_QUERY_INDEX, *PACTIVATION_CONTEXT_QUERY_INDEX;
	[PInvokeData("winnt.h", MSDNShortId = "eb15895c-07c9-4b68-83ef-2f2b8e3b271c")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ACTIVATION_CONTEXT_QUERY_INDEX(uint asmIndex, uint fileIndex)
	{
		/// <summary>One-based index of the assembly whose file table is to be queried.</summary>
		public uint ulAssemblyIndex = asmIndex;

		/// <summary>Zero-based index of the file in the above assembly to be queried.</summary>
		public uint ulFileIndexInAssembly = fileIndex;
	}

	/// <summary>The <c>ACTIVATION_CONTEXT_RUN_LEVEL_INFORMATION</c> structure is used by the QueryActCtxW function.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-activation_context_run_level_information typedef struct
	// _ACTIVATION_CONTEXT_RUN_LEVEL_INFORMATION { DWORD ulFlags; ACTCTX_REQUESTED_RUN_LEVEL RunLevel; DWORD UiAccess; }
	// ACTIVATION_CONTEXT_RUN_LEVEL_INFORMATION, *PACTIVATION_CONTEXT_RUN_LEVEL_INFORMATION;
	[PInvokeData("winnt.h", MSDNShortId = "1c4e7333-6982-4d58-ab2a-d1993c59d0ef")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ACTIVATION_CONTEXT_RUN_LEVEL_INFORMATION
	{
		/// <summary>This parameter is reserved for future use. This parameter currently returns 0.</summary>
		public uint ulFlags;

		/// <summary>A ACTCTX_REQUESTED_RUN_LEVEL enumeration value that gives the requested run level of the activation context.</summary>
		public ACTCTX_REQUESTED_RUN_LEVEL RunLevel;

		/// <summary>
		/// This parameter returns zero if the <c>uiAccess</c> attribute in the application manifest is false. This parameter returns a
		/// non-zero value if the <c>uiAccess</c> attribute in the manifest is true. True means that UI accessibility applications
		/// require access higher privileges.
		/// </summary>
		public uint UiAccess;
	}

	/// <summary>The <c>ASSEMBLY_FILE_DETAILED_INFORMATION</c> structure is used by the QueryActCtxW function.</summary>
	/// <remarks>
	/// If QueryActCtxW is called with the FileInformationInAssemblyOfAssemblyInActivationContext option, and the function succeeds, the
	/// information in the returned buffer is in form of the <c>ASSEMBLY_FILE_DETAILED_INFORMATION</c> structure. The following is an
	/// example of a structure used to hold detailed information about the activation context and a call from <c>QueryActCtxW</c>.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-_assembly_file_detailed_information typedef struct
	// _ASSEMBLY_FILE_DETAILED_INFORMATION { DWORD ulFlags; DWORD ulFilenameLength; DWORD ulPathLength; PCWSTR lpFileName; PCWSTR
	// lpFilePath; } ASSEMBLY_FILE_DETAILED_INFORMATION, *PASSEMBLY_FILE_DETAILED_INFORMATION;
	[PInvokeData("winnt.h", MSDNShortId = "7f1e5155-a6c1-4b6a-be47-37fab337186c")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct ASSEMBLY_FILE_DETAILED_INFORMATION
	{
		/// <summary>This value is always 0.</summary>
		public uint ulFlags;

		/// <summary>
		/// Length in bytes of the file name pointed to by <c>lpFileName</c>. The count does not include the terminating null character.
		/// </summary>
		public uint ulFilenameLength;

		/// <summary>
		/// Length in bytes of the path string pointed to by <c>lpFilePath</c> The count does not include the terminating null character.
		/// </summary>
		public uint ulPathLength;

		/// <summary>Null-terminated string that specifies the name of the file.</summary>
		[MarshalAs(UnmanagedType.LPWStr)] public string lpFileName;

		/// <summary>Null-terminated string that specifies the path to the file named in <c>lpFileName</c>.</summary>
		[MarshalAs(UnmanagedType.LPWStr)] public string lpFilePath;
	}

	/// <summary>
	/// The <c>COMPATIBILITY_CONTEXT_ELEMENT</c> structure is used by the QueryActCtxW function as part of the
	/// ACTIVATION_CONTEXT_COMPATIBILITY_INFORMATION structure.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-_compatibility_context_element typedef struct
	// _COMPATIBILITY_CONTEXT_ELEMENT { GUID Id; ACTCTX_COMPATIBILITY_ELEMENT_TYPE Type; } COMPATIBILITY_CONTEXT_ELEMENT, *PCOMPATIBILITY_CONTEXT_ELEMENT;
	[PInvokeData("winnt.h", MSDNShortId = "3e654f44-43f6-4282-b277-14ed6e25abf2")]
	[StructLayout(LayoutKind.Sequential)]
	public struct COMPATIBILITY_CONTEXT_ELEMENT
	{
		/// <summary>
		/// <para>This is a <c>GUID</c> that specifies a version of Windows.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>{e2011457-1546-43c5-a5fe-008deee3d3f0}</term>
		/// <term>Windows Vista</term>
		/// </item>
		/// <item>
		/// <term>{35138b9a-5d96-4fbd-8e2d-a2440225f93a}</term>
		/// <term>Windows 7</term>
		/// </item>
		/// </list>
		/// </summary>
		public Guid Id;

		/// <summary>
		/// A value of the ACTCTX_COMPATIBILITY_ELEMENT_TYPE enumeration that describes the compatibility elements in the application manifest.
		/// </summary>
		public ACTCTX_COMPATIBILITY_ELEMENT_TYPE Type;
	}

	public partial class SafeHACTCTX
	{
		/// <summary>Gets the handle to the active activation context of the calling thread.</summary>
		public static SafeHACTCTX GetCurrent()
		{
			if (!GetCurrentActCtx(out var h))
				Win32Error.ThrowLastError();
			return new SafeHACTCTX((IntPtr)h, false);
		}
	}
}