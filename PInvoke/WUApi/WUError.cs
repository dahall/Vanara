namespace Vanara.PInvoke;

/// <summary>PInvoke API (methods, structures and constants) imported from Windows Update API.</summary>
public static partial class WUApi
{
	static WUApi()
	{
		StaticFieldValueHash.AddFields<HRESULT, int, WUError>(Lib_WUApi);
		//ErrorHelper.AddErrorMessageLookupFunction<WUError>();
	}

	/// <summary>
	/// HRESULT error codes from wuerror.h. These are the same as the Windows Update error codes.
	/// </summary>
	[PInvokeData("wuerror.h")]
	public enum WUError
	{
		/// <summary>Windows Update Agent was stopped successfully.</summary>
		WU_S_SERVICE_STOP = 0x00240001,

		/// <summary>Windows Update Agent updated itself.</summary>
		WU_S_SELFUPDATE = 0x00240002,

		/// <summary>Operation completed successfully but there were errors applying the updates.</summary>
		WU_S_UPDATE_ERROR = 0x00240003,

		/// <summary>A callback was marked to be disconnected later because the request to disconnect the operation came while a callback was executing.</summary>
		WU_S_MARKED_FOR_DISCONNECT = 0x00240004,

		/// <summary>The system must be restarted to complete installation of the update.</summary>
		WU_S_REBOOT_REQUIRED = 0x00240005,

		/// <summary>The update to be installed is already installed on the system.</summary>
		WU_S_ALREADY_INSTALLED = 0x00240006,

		/// <summary>The update to be removed is not installed on the system.</summary>
		WU_S_ALREADY_UNINSTALLED = 0x00240007,

		/// <summary>The update to be downloaded has already been downloaded.</summary>
		WU_S_ALREADY_DOWNLOADED = 0x00240008,

		/// <summary>The operation completed successfully, but some updates were skipped because the system is running on batteries.</summary>
		WU_S_SOME_UPDATES_SKIPPED_ON_BATTERY = 0x00240009,

		/// <summary>The update to be reverted is not present on the system.</summary>
		WU_S_ALREADY_REVERTED = 0x0024000A,

		/// <summary>The operation is skipped because the update service does not support the requested search criteria.</summary>
		WU_S_SEARCH_CRITERIA_NOT_SUPPORTED = 0x00240010,

		/// <summary>The installation operation for the update is still in progress.</summary>
		WU_S_UH_INSTALLSTILLPENDING = 0x00242015,

		/// <summary>The actual download size has been calculated by the handler.</summary>
		WU_S_UH_DOWNLOAD_SIZE_CALCULATED = 0x00242016,

		/// <summary>No operation was required by the server-initiated healing server response.</summary>
		WU_S_SIH_NOOP = 0x00245001,

		/// <summary>The update to be downloaded is already being downloaded.</summary>
		WU_S_DM_ALREADYDOWNLOADING = 0x00246001,

		/// <summary>Metadata verification was skipped by enforcement mode.</summary>
		WU_S_METADATA_SKIPPED_BY_ENFORCEMENTMODE = 0x00247101,

		/// <summary>A server configuration refresh resulted in metadata signature verification to be ignored.</summary>
		WU_S_METADATA_IGNORED_SIGNATURE_VERIFICATION = 0x00247102,

		/// <summary>Search operation completed successfully but one or more services were shedding load.</summary>
		WU_S_SEARCH_LOAD_SHEDDING = 0x00248001,

		/// <summary>There was no need to retrieve an AAD device ticket.</summary>
		WU_S_AAD_DEVICE_TICKET_NOT_NEEDED = 0x00248002,

		/// <summary>Windows Update Agent was unable to provide the service.</summary>
		WU_E_NO_SERVICE = unchecked((int)0x80240001),

		/// <summary>The maximum capacity of the service was exceeded.</summary>
		WU_E_MAX_CAPACITY_REACHED = unchecked((int)0x80240002),

		/// <summary>An ID cannot be found.</summary>
		WU_E_UNKNOWN_ID = unchecked((int)0x80240003),

		/// <summary>The object could not be initialized.</summary>
		WU_E_NOT_INITIALIZED = unchecked((int)0x80240004),

		/// <summary>The update handler requested a byte range overlapping a previously requested range.</summary>
		WU_E_RANGEOVERLAP = unchecked((int)0x80240005),

		/// <summary>The requested number of byte ranges exceeds the maximum number (2^31 - 1).</summary>
		WU_E_TOOMANYRANGES = unchecked((int)0x80240006),

		/// <summary>The index to a collection was invalid.</summary>
		WU_E_INVALIDINDEX = unchecked((int)0x80240007),

		/// <summary>The key for the item queried could not be found.</summary>
		WU_E_ITEMNOTFOUND = unchecked((int)0x80240008),

		/// <summary>Another conflicting operation was in progress. Some operations such as installation cannot be performed twice simultaneously.</summary>
		WU_E_OPERATIONINPROGRESS = unchecked((int)0x80240009),

		/// <summary>Cancellation of the operation was not allowed.</summary>
		WU_E_COULDNOTCANCEL = unchecked((int)0x8024000A),

		/// <summary>Operation was cancelled.</summary>
		WU_E_CALL_CANCELLED = unchecked((int)0x8024000B),

		/// <summary>No operation was required.</summary>
		WU_E_NOOP = unchecked((int)0x8024000C),

		/// <summary>Windows Update Agent could not find required information in the update's XML data.</summary>
		WU_E_XML_MISSINGDATA = unchecked((int)0x8024000D),

		/// <summary>Windows Update Agent found invalid information in the update's XML data.</summary>
		WU_E_XML_INVALID = unchecked((int)0x8024000E),

		/// <summary>Circular update relationships were detected in the metadata.</summary>
		WU_E_CYCLE_DETECTED = unchecked((int)0x8024000F),

		/// <summary>Update relationships too deep to evaluate were evaluated.</summary>
		WU_E_TOO_DEEP_RELATION = unchecked((int)0x80240010),

		/// <summary>An invalid update relationship was detected.</summary>
		WU_E_INVALID_RELATIONSHIP = unchecked((int)0x80240011),

		/// <summary>An invalid registry value was read.</summary>
		WU_E_REG_VALUE_INVALID = unchecked((int)0x80240012),

		/// <summary>Operation tried to add a duplicate item to a list.</summary>
		WU_E_DUPLICATE_ITEM = unchecked((int)0x80240013),

		/// <summary>Updates requested for install are not installable by caller.</summary>
		WU_E_INVALID_INSTALL_REQUESTED = unchecked((int)0x80240014),

		/// <summary>Operation tried to install while another installation was in progress or the system was pending a mandatory restart.</summary>
		WU_E_INSTALL_NOT_ALLOWED = unchecked((int)0x80240016),

		/// <summary>Operation was not performed because there are no applicable updates.</summary>
		WU_E_NOT_APPLICABLE = unchecked((int)0x80240017),

		/// <summary>Operation failed because a required user token is missing.</summary>
		WU_E_NO_USERTOKEN = unchecked((int)0x80240018),

		/// <summary>An exclusive update cannot be installed with other updates at the same time.</summary>
		WU_E_EXCLUSIVE_INSTALL_CONFLICT = unchecked((int)0x80240019),

		/// <summary>A policy value was not set.</summary>
		WU_E_POLICY_NOT_SET = unchecked((int)0x8024001A),

		/// <summary>The operation could not be performed because the Windows Update Agent is self-updating.</summary>
		WU_E_SELFUPDATE_IN_PROGRESS = unchecked((int)0x8024001B),

		/// <summary>An update contains invalid metadata.</summary>
		WU_E_INVALID_UPDATE = unchecked((int)0x8024001D),

		/// <summary>Operation did not complete because the service or system was being shut down.</summary>
		WU_E_SERVICE_STOP = unchecked((int)0x8024001E),

		/// <summary>Operation did not complete because the network connection was unavailable.</summary>
		WU_E_NO_CONNECTION = unchecked((int)0x8024001F),

		/// <summary>Operation did not complete because there is no logged-on interactive user.</summary>
		WU_E_NO_INTERACTIVE_USER = unchecked((int)0x80240020),

		/// <summary>Operation did not complete because it timed out.</summary>
		WU_E_TIME_OUT = unchecked((int)0x80240021),

		/// <summary>Operation failed for all the updates.</summary>
		WU_E_ALL_UPDATES_FAILED = unchecked((int)0x80240022),

		/// <summary>The license terms for all updates were declined.</summary>
		WU_E_EULAS_DECLINED = unchecked((int)0x80240023),

		/// <summary>There are no updates.</summary>
		WU_E_NO_UPDATE = unchecked((int)0x80240024),

		/// <summary>Group Policy settings prevented access to Windows Update.</summary>
		WU_E_USER_ACCESS_DISABLED = unchecked((int)0x80240025),

		/// <summary>The type of update is invalid.</summary>
		WU_E_INVALID_UPDATE_TYPE = unchecked((int)0x80240026),

		/// <summary>The URL exceeded the maximum length.</summary>
		WU_E_URL_TOO_LONG = unchecked((int)0x80240027),

		/// <summary>The update could not be uninstalled because the request did not originate from a WSUS server.</summary>
		WU_E_UNINSTALL_NOT_ALLOWED = unchecked((int)0x80240028),

		/// <summary>Search may have missed some updates before there is an unlicensed application on the system.</summary>
		WU_E_INVALID_PRODUCT_LICENSE = unchecked((int)0x80240029),

		/// <summary>A component required to detect applicable updates was missing.</summary>
		WU_E_MISSING_HANDLER = unchecked((int)0x8024002A),

		/// <summary>An operation did not complete because it requires a newer version of server.</summary>
		WU_E_LEGACYSERVER = unchecked((int)0x8024002B),

		/// <summary>A delta-compressed update could not be installed because it required the source.</summary>
		WU_E_BIN_SOURCE_ABSENT = unchecked((int)0x8024002C),

		/// <summary>A full-file update could not be installed because it required the source.</summary>
		WU_E_SOURCE_ABSENT = unchecked((int)0x8024002D),

		/// <summary>Access to an unmanaged server is not allowed.</summary>
		WU_E_WU_DISABLED = unchecked((int)0x8024002E),

		/// <summary>Operation did not complete because the DisableWindowsUpdateAccess policy was set.</summary>
		WU_E_CALL_CANCELLED_BY_POLICY = unchecked((int)0x8024002F),

		/// <summary>The format of the proxy list was invalid.</summary>
		WU_E_INVALID_PROXY_SERVER = unchecked((int)0x80240030),

		/// <summary>The file is in the wrong format.</summary>
		WU_E_INVALID_FILE = unchecked((int)0x80240031),

		/// <summary>The search criteria string was invalid.</summary>
		WU_E_INVALID_CRITERIA = unchecked((int)0x80240032),

		/// <summary>License terms could not be downloaded.</summary>
		WU_E_EULA_UNAVAILABLE = unchecked((int)0x80240033),

		/// <summary>Update failed to download.</summary>
		WU_E_DOWNLOAD_FAILED = unchecked((int)0x80240034),

		/// <summary>The update was not processed.</summary>
		WU_E_UPDATE_NOT_PROCESSED = unchecked((int)0x80240035),

		/// <summary>The object's current state did not allow the operation.</summary>
		WU_E_INVALID_OPERATION = unchecked((int)0x80240036),

		/// <summary>The functionality for the operation is not supported.</summary>
		WU_E_NOT_SUPPORTED = unchecked((int)0x80240037),

		/// <summary>The downloaded file has an unexpected content type.</summary>
		WU_E_WINHTTP_INVALID_FILE = unchecked((int)0x80240038),

		/// <summary>Agent is asked by server to resync too many times.</summary>
		WU_E_TOO_MANY_RESYNC = unchecked((int)0x80240039),

		/// <summary>WUA API method does not run on Server Core installation.</summary>
		WU_E_NO_SERVER_CORE_SUPPORT = unchecked((int)0x80240040),

		/// <summary>Service is not available while sysprep is running.</summary>
		WU_E_SYSPREP_IN_PROGRESS = unchecked((int)0x80240041),

		/// <summary>The update service is no longer registered with AU.</summary>
		WU_E_UNKNOWN_SERVICE = unchecked((int)0x80240042),

		/// <summary>There is no support for WUA UI.</summary>
		WU_E_NO_UI_SUPPORT = unchecked((int)0x80240043),

		/// <summary>Only administrators can perform this operation on per-machine updates.</summary>
		WU_E_PER_MACHINE_UPDATE_ACCESS_DENIED = unchecked((int)0x80240044),

		/// <summary>A search was attempted with a scope that is not currently supported for this type of search.</summary>
		WU_E_UNSUPPORTED_SEARCHSCOPE = unchecked((int)0x80240045),

		/// <summary>The URL does not point to a file.</summary>
		WU_E_BAD_FILE_URL = unchecked((int)0x80240046),

		/// <summary>The update could not be reverted.</summary>
		WU_E_REVERT_NOT_ALLOWED = unchecked((int)0x80240047),

		/// <summary>The featured update notification info returned by the server is invalid.</summary>
		WU_E_INVALID_NOTIFICATION_INFO = unchecked((int)0x80240048),

		/// <summary>The data is out of range.</summary>
		WU_E_OUTOFRANGE = unchecked((int)0x80240049),

		/// <summary>Windows Update agent operations are not available while OS setup is running.</summary>
		WU_E_SETUP_IN_PROGRESS = unchecked((int)0x8024004A),

		/// <summary>An orphaned downloadjob was found with no active callers.</summary>
		WU_E_ORPHANED_DOWNLOAD_JOB = unchecked((int)0x8024004B),

		/// <summary>An update could not be installed because the system battery power level is too low.</summary>
		WU_E_LOW_BATTERY = unchecked((int)0x8024004C),

		/// <summary>The downloaded infrastructure file is incorrectly formatted.</summary>
		WU_E_INFRASTRUCTUREFILE_INVALID_FORMAT = unchecked((int)0x8024004D),

		/// <summary>The infrastructure file must be downloaded using strong SSL.</summary>
		WU_E_INFRASTRUCTUREFILE_REQUIRES_SSL = unchecked((int)0x8024004E),

		/// <summary>A discovery call contributed to a non-zero operation count at idle timer shutdown.</summary>
		WU_E_IDLESHUTDOWN_OPCOUNT_DISCOVERY = unchecked((int)0x8024004F),

		/// <summary>A search call contributed to a non-zero operation count at idle timer shutdown.</summary>
		WU_E_IDLESHUTDOWN_OPCOUNT_SEARCH = unchecked((int)0x80240050),

		/// <summary>A download call contributed to a non-zero operation count at idle timer shutdown.</summary>
		WU_E_IDLESHUTDOWN_OPCOUNT_DOWNLOAD = unchecked((int)0x80240051),

		/// <summary>An install call contributed to a non-zero operation count at idle timer shutdown.</summary>
		WU_E_IDLESHUTDOWN_OPCOUNT_INSTALL = unchecked((int)0x80240052),

		/// <summary>An unspecified call contributed to a non-zero operation count at idle timer shutdown.</summary>
		WU_E_IDLESHUTDOWN_OPCOUNT_OTHER = unchecked((int)0x80240053),

		/// <summary>An interactive user cancelled this operation, which was started from the Windows Update Agent UI.</summary>
		WU_E_INTERACTIVE_CALL_CANCELLED = unchecked((int)0x80240054),

		/// <summary>Automatic Updates cancelled this operation because it applies to an update that is no longer applicable to this computer.</summary>
		WU_E_AU_CALL_CANCELLED = unchecked((int)0x80240055),

		/// <summary>This version or edition of the operating system doesn't support the needed functionality.</summary>
		WU_E_SYSTEM_UNSUPPORTED = unchecked((int)0x80240056),

		/// <summary>The requested update download or install handler, or update applicability expression evaluator, is not provided by this Agent plugin.</summary>
		WU_E_NO_SUCH_HANDLER_PLUGIN = unchecked((int)0x80240057),

		/// <summary>The requested serialization version is not supported.</summary>
		WU_E_INVALID_SERIALIZATION_VERSION = unchecked((int)0x80240058),

		/// <summary>The current network cost does not meet the conditions set by the network cost policy.</summary>
		WU_E_NETWORK_COST_EXCEEDS_POLICY = unchecked((int)0x80240059),

		/// <summary>The call is cancelled because it applies to an update that is hidden (no longer applicable to this computer).</summary>
		WU_E_CALL_CANCELLED_BY_HIDE = unchecked((int)0x8024005A),

		/// <summary>The call is cancelled because it applies to an update that is invalid (no longer applicable to this computer).</summary>
		WU_E_CALL_CANCELLED_BY_INVALID = unchecked((int)0x8024005B),

		/// <summary>The specified volume id is invalid.</summary>
		WU_E_INVALID_VOLUMEID = unchecked((int)0x8024005C),

		/// <summary>The specified volume id is unrecognized by the system.</summary>
		WU_E_UNRECOGNIZED_VOLUMEID = unchecked((int)0x8024005D),

		/// <summary>The installation extended error code is not specified.</summary>
		WU_E_EXTENDEDERROR_NOTSET = unchecked((int)0x8024005E),

		/// <summary>The installation extended error code is set to general fail.</summary>
		WU_E_EXTENDEDERROR_FAILED = unchecked((int)0x8024005F),

		/// <summary>A service registration call contributed to a non-zero operation count at idle timer shutdown.</summary>
		WU_E_IDLESHUTDOWN_OPCOUNT_SERVICEREGISTRATION = unchecked((int)0x80240060),

		/// <summary>Signature validation of the file fails to find valid SHA2+ signature on MS signed payload.</summary>
		WU_E_FILETRUST_SHA2SIGNATURE_MISSING = unchecked((int)0x80240061),

		/// <summary>The update is not in the servicing approval list.</summary>
		WU_E_UPDATE_NOT_APPROVED = unchecked((int)0x80240062),

		/// <summary>The search call was cancelled by another interactive search against the same service.</summary>
		WU_E_CALL_CANCELLED_BY_INTERACTIVE_SEARCH = unchecked((int)0x80240063),

		/// <summary>Resume of install job not allowed due to another installation in progress.</summary>
		WU_E_INSTALL_JOB_RESUME_NOT_ALLOWED = unchecked((int)0x80240064),

		/// <summary>Resume of install job not allowed because job is not suspended.</summary>
		WU_E_INSTALL_JOB_NOT_SUSPENDED = unchecked((int)0x80240065),

		/// <summary>User context passed to installation from caller with insufficient privileges.</summary>
		WU_E_INSTALL_USERCONTEXT_ACCESSDENIED = unchecked((int)0x80240066),

		/// <summary>An operation failed due to reasons not covered by another error code.</summary>
		WU_E_UNEXPECTED = unchecked((int)0x80240FFF),

		/// <summary>Search may have missed some updates because the Windows Installer is less than version 3.1.</summary>
		WU_E_MSI_WRONG_VERSION = unchecked((int)0x80241001),

		/// <summary>Search may have missed some updates because the Windows Installer is not configured.</summary>
		WU_E_MSI_NOT_CONFIGURED = unchecked((int)0x80241002),

		/// <summary>Search may have missed some updates because policy has disabled Windows Installer patching.</summary>
		WU_E_MSP_DISABLED = unchecked((int)0x80241003),

		/// <summary>An update could not be applied because the application is installed per-user.</summary>
		WU_E_MSI_WRONG_APP_CONTEXT = unchecked((int)0x80241004),

		/// <summary>Search may have missed some updates because the Windows Installer is less than version 3.1.</summary>
		WU_E_MSI_NOT_PRESENT = unchecked((int)0x80241005),

		/// <summary>Search may have missed some updates because there was a failure of the Windows Installer.</summary>
		WU_E_MSP_UNEXPECTED = unchecked((int)0x80241FFF),

		/// <summary>WU_E_PT_SOAPCLIENT_* error codes map to the SOAPCLIENT_ERROR enum of the ATL Server Library.</summary>
		WU_E_PT_SOAPCLIENT_BASE = unchecked((int)0x80244000),

		/// <summary>Same as SOAPCLIENT_INITIALIZE_ERROR - initialization of the SOAP client failed, possibly because of an MSXML installation failure.</summary>
		WU_E_PT_SOAPCLIENT_INITIALIZE = unchecked((int)0x80244001),

		/// <summary>Same as SOAPCLIENT_OUTOFMEMORY - SOAP client failed because it ran out of memory.</summary>
		WU_E_PT_SOAPCLIENT_OUTOFMEMORY = unchecked((int)0x80244002),

		/// <summary>Same as SOAPCLIENT_GENERATE_ERROR - SOAP client failed to generate the request.</summary>
		WU_E_PT_SOAPCLIENT_GENERATE = unchecked((int)0x80244003),

		/// <summary>Same as SOAPCLIENT_CONNECT_ERROR - SOAP client failed to connect to the server.</summary>
		WU_E_PT_SOAPCLIENT_CONNECT = unchecked((int)0x80244004),

		/// <summary>Same as SOAPCLIENT_SEND_ERROR - SOAP client failed to send a message for reasons of WU_E_WINHTTP_* error codes.</summary>
		WU_E_PT_SOAPCLIENT_SEND = unchecked((int)0x80244005),

		/// <summary>Same as SOAPCLIENT_SERVER_ERROR - SOAP client failed because there was a server error.</summary>
		WU_E_PT_SOAPCLIENT_SERVER = unchecked((int)0x80244006),

		/// <summary>Same as SOAPCLIENT_SOAPFAULT - SOAP client failed because there was a SOAP fault for reasons of WU_E_PT_SOAP_* error codes.</summary>
		WU_E_PT_SOAPCLIENT_SOAPFAULT = unchecked((int)0x80244007),

		/// <summary>Same as SOAPCLIENT_PARSEFAULT_ERROR - SOAP client failed to parse a SOAP fault.</summary>
		WU_E_PT_SOAPCLIENT_PARSEFAULT = unchecked((int)0x80244008),

		/// <summary>Same as SOAPCLIENT_READ_ERROR - SOAP client failed while reading the response from the server.</summary>
		WU_E_PT_SOAPCLIENT_READ = unchecked((int)0x80244009),

		/// <summary>Same as SOAPCLIENT_PARSE_ERROR - SOAP client failed to parse the response from the server.</summary>
		WU_E_PT_SOAPCLIENT_PARSE = unchecked((int)0x8024400A),

		/// <summary>Same as SOAP_E_VERSION_MISMATCH - SOAP client found an unrecognizable namespace for the SOAP envelope.</summary>
		WU_E_PT_SOAP_VERSION = unchecked((int)0x8024400B),

		/// <summary>Same as SOAP_E_MUST_UNDERSTAND - SOAP client was unable to understand a header.</summary>
		WU_E_PT_SOAP_MUST_UNDERSTAND = unchecked((int)0x8024400C),

		/// <summary>Same as SOAP_E_CLIENT - SOAP client found the message was malformed; fix before resending.</summary>
		WU_E_PT_SOAP_CLIENT = unchecked((int)0x8024400D),

		/// <summary>Same as SOAP_E_SERVER - The SOAP message could not be processed due to a server error; resend later.</summary>
		WU_E_PT_SOAP_SERVER = unchecked((int)0x8024400E),

		/// <summary>There was an unspecified Windows Management Instrumentation (WMI) error.</summary>
		WU_E_PT_WMI_ERROR = unchecked((int)0x8024400F),

		/// <summary>The number of round trips to the server exceeded the maximum limit.</summary>
		WU_E_PT_EXCEEDED_MAX_SERVER_TRIPS = unchecked((int)0x80244010),

		/// <summary>WUServer policy value is missing in the registry.</summary>
		WU_E_PT_SUS_SERVER_NOT_SET = unchecked((int)0x80244011),

		/// <summary>Initialization failed because the object was already initialized.</summary>
		WU_E_PT_DOUBLE_INITIALIZATION = unchecked((int)0x80244012),

		/// <summary>The computer name could not be determined.</summary>
		WU_E_PT_INVALID_COMPUTER_NAME = unchecked((int)0x80244013),

		/// <summary>The reply from the server indicates that the server was changed or the cookie was invalid; refresh the state of the internal cache and retry.</summary>
		WU_E_PT_REFRESH_CACHE_REQUIRED = unchecked((int)0x80244015),

		/// <summary>Same as HTTP status 400 - the server could not process the request due to invalid syntax.</summary>
		WU_E_PT_HTTP_STATUS_BAD_REQUEST = unchecked((int)0x80244016),

		/// <summary>Same as HTTP status 401 - the requested resource requires user authentication.</summary>
		WU_E_PT_HTTP_STATUS_DENIED = unchecked((int)0x80244017),

		/// <summary>Same as HTTP status 403 - server understood the request, but declined to fulfill it.</summary>
		WU_E_PT_HTTP_STATUS_FORBIDDEN = unchecked((int)0x80244018),

		/// <summary>Same as HTTP status 404 - the server cannot find the requested URI (Uniform Resource Identifier).</summary>
		WU_E_PT_HTTP_STATUS_NOT_FOUND    = unchecked((int)0x80244019),

		/// <summary>Same as HTTP status 405 - the HTTP method is not allowed.</summary>
		WU_E_PT_HTTP_STATUS_BAD_METHOD = unchecked((int)0x8024401A),

		/// <summary>Same as HTTP status 407 - proxy authentication is required.</summary>
		WU_E_PT_HTTP_STATUS_PROXY_AUTH_REQ = unchecked((int)0x8024401B),

		/// <summary>Same as HTTP status 408 - the server timed out waiting for the request.</summary>
		WU_E_PT_HTTP_STATUS_REQUEST_TIMEOUT = unchecked((int)0x8024401C),

		/// <summary>Same as HTTP status 409 - the request was not completed due to a conflict with the current state of the resource.</summary>
		WU_E_PT_HTTP_STATUS_CONFLICT = unchecked((int)0x8024401D),

		/// <summary>Same as HTTP status 410 - requested resource is no longer available at the server.</summary>
		WU_E_PT_HTTP_STATUS_GONE = unchecked((int)0x8024401E),

		/// <summary>Same as HTTP status 500 - an error internal to the server prevented fulfilling the request.</summary>
		WU_E_PT_HTTP_STATUS_SERVER_ERROR = unchecked((int)0x8024401F),

		/// <summary>Same as HTTP status 500 - server does not support the functionality required to fulfill the request.</summary>
		WU_E_PT_HTTP_STATUS_NOT_SUPPORTED = unchecked((int)0x80244020),

		/// <summary>Same as HTTP status 502 - the server, while acting as a gateway or proxy, received an invalid response from the upstream server it accessed in attempting to fulfill the request.</summary>
		WU_E_PT_HTTP_STATUS_BAD_GATEWAY = unchecked((int)0x80244021),

		/// <summary>Same as HTTP status 503 - the service is temporarily overloaded.</summary>
		WU_E_PT_HTTP_STATUS_SERVICE_UNAVAIL = unchecked((int)0x80244022),

		/// <summary>Same as HTTP status 503 - the request was timed out waiting for a gateway.</summary>
		WU_E_PT_HTTP_STATUS_GATEWAY_TIMEOUT = unchecked((int)0x80244023),

		/// <summary>Same as HTTP status 505 - the server does not support the HTTP protocol version used for the request.</summary>
		WU_E_PT_HTTP_STATUS_VERSION_NOT_SUP = unchecked((int)0x80244024),

		/// <summary>Operation failed due to a changed file location; refresh internal state and resend.</summary>
		WU_E_PT_FILE_LOCATIONS_CHANGED = unchecked((int)0x80244025),

		/// <summary>Operation failed because Windows Update Agent does not support registration with a non-WSUS server.</summary>
		WU_E_PT_REGISTRATION_NOT_SUPPORTED = unchecked((int)0x80244026),

		/// <summary>The server returned an empty authentication information list.</summary>
		WU_E_PT_NO_AUTH_PLUGINS_REQUESTED = unchecked((int)0x80244027),

		/// <summary>Windows Update Agent was unable to create any valid authentication cookies.</summary>
		WU_E_PT_NO_AUTH_COOKIES_CREATED = unchecked((int)0x80244028),

		/// <summary>A configuration property value was wrong.</summary>
		WU_E_PT_INVALID_CONFIG_PROP = unchecked((int)0x80244029),

		/// <summary>A configuration property value was missing.</summary>
		WU_E_PT_CONFIG_PROP_MISSING = unchecked((int)0x8024402A),

		/// <summary>The HTTP request could not be completed and the reason did not correspond to any of the WU_E_PT_HTTP_* error codes.</summary>
		WU_E_PT_HTTP_STATUS_NOT_MAPPED = unchecked((int)0x8024402B),

		/// <summary>Same as ERROR_WINHTTP_NAME_NOT_RESOLVED - the proxy server or target server name cannot be resolved.</summary>
		WU_E_PT_WINHTTP_NAME_NOT_RESOLVED = unchecked((int)0x8024402C),

		/// <summary>The server is shedding load.</summary>
		WU_E_PT_LOAD_SHEDDING = unchecked((int)0x8024402D),

		/// <summary>Windows Update Agent failed to download a redirector cabinet file with a new redirectorId value from the server during the recovery.</summary>
		WU_E_PT_SAME_REDIR_ID = unchecked((int)0x8024502D),

		/// <summary>A redirector recovery action did not complete because the server is managed.</summary>
		WU_E_PT_NO_MANAGED_RECOVER = unchecked((int)0x8024502E),

		/// <summary>External cab file processing completed with some errors.</summary>
		WU_E_PT_ECP_SUCCEEDED_WITH_ERRORS = unchecked((int)0x8024402F),

		/// <summary>The external cab processor initialization did not complete.</summary>
		WU_E_PT_ECP_INIT_FAILED = unchecked((int)0x80244030),

		/// <summary>The format of a metadata file was invalid.</summary>
		WU_E_PT_ECP_INVALID_FILE_FORMAT = unchecked((int)0x80244031),

		/// <summary>External cab processor found invalid metadata.</summary>
		WU_E_PT_ECP_INVALID_METADATA = unchecked((int)0x80244032),

		/// <summary>The file digest could not be extracted from an external cab file.</summary>
		WU_E_PT_ECP_FAILURE_TO_EXTRACT_DIGEST = unchecked((int)0x80244033),

		/// <summary>An external cab file could not be decompressed.</summary>
		WU_E_PT_ECP_FAILURE_TO_DECOMPRESS_CAB_FILE = unchecked((int)0x80244034),

		/// <summary>External cab processor was unable to get file locations.</summary>
		WU_E_PT_ECP_FILE_LOCATION_ERROR = unchecked((int)0x80244035),

		/// <summary>The server does not support category-specific search; Full catalog search has to be issued instead.</summary>
		WU_E_PT_CATALOG_SYNC_REQUIRED = unchecked((int)0x80240436),

		/// <summary>There was a problem authorizing with the service.</summary>
		WU_E_PT_SECURITY_VERIFICATION_FAILURE = unchecked((int)0x80240437),

		/// <summary>There is no route or network connectivity to the endpoint.</summary>
		WU_E_PT_ENDPOINT_UNREACHABLE = unchecked((int)0x80240438),

		/// <summary>The data received does not meet the data contract expectations.</summary>
		WU_E_PT_INVALID_FORMAT = unchecked((int)0x80240439),

		/// <summary>The url is invalid.</summary>
		WU_E_PT_INVALID_URL = unchecked((int)0x8024043A),

		/// <summary>Unable to load NWS runtime.</summary>
		WU_E_PT_NWS_NOT_LOADED = unchecked((int)0x8024043B),

		/// <summary>The proxy auth scheme is not supported.</summary>
		WU_E_PT_PROXY_AUTH_SCHEME_NOT_SUPPORTED = unchecked((int)0x8024043C),

		/// <summary>The requested service property is not available.</summary>
		WU_E_SERVICEPROP_NOTAVAIL = unchecked((int)0x8024043D),

		/// <summary>The endpoint provider plugin requires online refresh.</summary>
		WU_E_PT_ENDPOINT_REFRESH_REQUIRED = unchecked((int)0x8024043E),

		/// <summary>A URL for the requested service endpoint is not available.</summary>
		WU_E_PT_ENDPOINTURL_NOTAVAIL = unchecked((int)0x8024043F),

		/// <summary>The connection to the service endpoint died.</summary>
		WU_E_PT_ENDPOINT_DISCONNECTED = unchecked((int)0x80240440),

		/// <summary>The operation is invalid because protocol talker is in an inappropriate state.</summary>
		WU_E_PT_INVALID_OPERATION = unchecked((int)0x80240441),

		/// <summary>The object is in a faulted state due to a previous error.</summary>
		WU_E_PT_OBJECT_FAULTED = unchecked((int)0x80240442),

		/// <summary>The operation would lead to numeric overflow.</summary>
		WU_E_PT_NUMERIC_OVERFLOW = unchecked((int)0x80240443),

		/// <summary>The operation was aborted.</summary>
		WU_E_PT_OPERATION_ABORTED = unchecked((int)0x80240444),

		/// <summary>The operation was abandoned.</summary>
		WU_E_PT_OPERATION_ABANDONED = unchecked((int)0x80240445),

		/// <summary>A quota was exceeded.</summary>
		WU_E_PT_QUOTA_EXCEEDED = unchecked((int)0x80240446),

		/// <summary>The information was not available in the specified language.</summary>
		WU_E_PT_NO_TRANSLATION_AVAILABLE = unchecked((int)0x80240447),

		/// <summary>The address is already being used.</summary>
		WU_E_PT_ADDRESS_IN_USE = unchecked((int)0x80240448),

		/// <summary>The address is not valid for this context.</summary>
		WU_E_PT_ADDRESS_NOT_AVAILABLE = unchecked((int)0x80240449),

		/// <summary>Unrecognized error occurred in the Windows Web Services framework.</summary>
		WU_E_PT_OTHER = unchecked((int)0x8024044A),

		/// <summary>A security operation failed in the Windows Web Services framework.</summary>
		WU_E_PT_SECURITY_SYSTEM_FAILURE = unchecked((int)0x8024044B),

		/// <summary>The client is data boundary restricted and needs to talk to a restricted endpoint.</summary>
		WU_E_PT_DATA_BOUNDARY_RESTRICTED = unchecked((int)0x80244100),

		/// <summary>The client hit an error in retrievingg AAD device ticket.</summary>
		WU_E_PT_GENERAL_AAD_CLIENT_ERROR = unchecked((int)0x80244101),

		/// <summary>A communication error not covered by another WU_E_PT_* error code.</summary>
		WU_E_PT_UNEXPECTED = unchecked((int)0x80244FFF),

		/// <summary>The redirector XML document could not be loaded into the DOM class.</summary>
		WU_E_REDIRECTOR_LOAD_XML = unchecked((int)0x80245001),

		/// <summary>The redirector XML document is missing some required information.</summary>
		WU_E_REDIRECTOR_S_FALSE = unchecked((int)0x80245002),

		/// <summary>The redirectorId in the downloaded redirector cab is less than in the cached cab.</summary>
		WU_E_REDIRECTOR_ID_SMALLER = unchecked((int)0x80245003),

		/// <summary>The service ID is not supported in the service environment.</summary>
		WU_E_REDIRECTOR_UNKNOWN_SERVICE = unchecked((int)0x80245004),

		/// <summary>The response from the redirector server had an unsupported content type.</summary>
		WU_E_REDIRECTOR_UNSUPPORTED_CONTENTTYPE = unchecked((int)0x80245005),

		/// <summary>The response from the redirector server had an error status or was invalid.</summary>
		WU_E_REDIRECTOR_INVALID_RESPONSE = unchecked((int)0x80245006),

		/// <summary>The maximum number of name value pairs was exceeded by the attribute provider.</summary>
		WU_E_REDIRECTOR_ATTRPROVIDER_EXCEEDED_MAX_NAMEVALUE = unchecked((int)0x80245008),

		/// <summary>The name received from the attribute provider was invalid.</summary>
		WU_E_REDIRECTOR_ATTRPROVIDER_INVALID_NAME = unchecked((int)0x80245009),

		/// <summary>The value received from the attribute provider was invalid.</summary>
		WU_E_REDIRECTOR_ATTRPROVIDER_INVALID_VALUE = unchecked((int)0x8024500A),

		/// <summary>There was an error in connecting to or parsing the response from the Service Locator Service redirector server.</summary>
		WU_E_REDIRECTOR_SLS_GENERIC_ERROR = unchecked((int)0x8024500B),

		/// <summary>Connections to the redirector server are disallowed by managed policy.</summary>
		WU_E_REDIRECTOR_CONNECT_POLICY = unchecked((int)0x8024500C),

		/// <summary>The redirector would go online but is disallowed by caller configuration.</summary>
		WU_E_REDIRECTOR_ONLINE_DISALLOWED = unchecked((int)0x8024500D),

		/// <summary>The redirector failed for reasons not covered by another WU_E_REDIRECTOR_* error code.</summary>
		WU_E_REDIRECTOR_UNEXPECTED = unchecked((int)0x802450FF),

		/// <summary>Verification of the servicing engine package failed.</summary>
		WU_E_SIH_VERIFY_DOWNLOAD_ENGINE = unchecked((int)0x80245101),

		/// <summary>Verification of a servicing package failed.</summary>
		WU_E_SIH_VERIFY_DOWNLOAD_PAYLOAD = unchecked((int)0x80245102),

		/// <summary>Verification of the staged engine failed.</summary>
		WU_E_SIH_VERIFY_STAGE_ENGINE = unchecked((int)0x80245103),

		/// <summary>Verification of a staged payload failed.</summary>
		WU_E_SIH_VERIFY_STAGE_PAYLOAD = unchecked((int)0x80245104),

		/// <summary>An internal error occurred where the servicing action was not found.</summary>
		WU_E_SIH_ACTION_NOT_FOUND = unchecked((int)0x80245105),

		/// <summary>There was a parse error in the service environment response.</summary>
		WU_E_SIH_SLS_PARSE = unchecked((int)0x80245106),

		/// <summary>A downloaded file failed an integrity check.</summary>
		WU_E_SIH_INVALIDHASH = unchecked((int)0x80245107),

		/// <summary>No engine was provided by the server-initiated healing server response.</summary>
		WU_E_SIH_NO_ENGINE = unchecked((int)0x80245108),

		/// <summary>Post-reboot install failed.</summary>
		WU_E_SIH_POST_REBOOT_INSTALL_FAILED = unchecked((int)0x80245109),

		/// <summary>There were pending reboot actions, but cached SLS response was not found post-reboot.</summary>
		WU_E_SIH_POST_REBOOT_NO_CACHED_SLS_RESPONSE = unchecked((int)0x8024510A),

		/// <summary>Parsing command line arguments failed.</summary>
		WU_E_SIH_PARSE = unchecked((int)0x8024510B),

		/// <summary>Security check failed.</summary>
		WU_E_SIH_SECURITY = unchecked((int)0x8024510C),

		/// <summary>PPL check failed.</summary>
		WU_E_SIH_PPL = unchecked((int)0x8024510D),

		/// <summary>Execution was disabled by policy.</summary>
		WU_E_SIH_POLICY = unchecked((int)0x8024510E),

		/// <summary>A standard exception was caught.</summary>
		WU_E_SIH_STDEXCEPTION = unchecked((int)0x8024510F),

		/// <summary>A non-standard exception was caught.</summary>
		WU_E_SIH_NONSTDEXCEPTION = unchecked((int)0x80245110),

		/// <summary>The server-initiated healing engine encountered an exception not covered by another WU_E_SIH_* error code.</summary>
		WU_E_SIH_ENGINE_EXCEPTION = unchecked((int)0x80245111),

		/// <summary>You are running SIH Client with cmd not supported on your platform.</summary>
		WU_E_SIH_BLOCKED_FOR_PLATFORM = unchecked((int)0x80245112),

		/// <summary>Another SIH Client is already running.</summary>
		WU_E_SIH_ANOTHER_INSTANCE_RUNNING = unchecked((int)0x80245113),

		/// <summary>Disable DNS resiliency feature per service configuration.</summary>
		WU_E_SIH_DNSRESILIENCY_OFF = unchecked((int)0x80245114),

		/// <summary>There was a failure for reasons not covered by another WU_E_SIH_* error code.</summary>
		WU_E_SIH_UNEXPECTED = unchecked((int)0x802451FF),

		/// <summary>A driver was skipped.</summary>
		WU_E_DRV_PRUNED = unchecked((int)0x8024C001),

		/// <summary>A property for the driver could not be found. It may not conform with required specifications.</summary>
		WU_E_DRV_NOPROP_OR_LEGACY = unchecked((int)0x8024C002),

		/// <summary>The registry type read for the driver does not match the expected type.</summary>
		WU_E_DRV_REG_MISMATCH = unchecked((int)0x8024C003),

		/// <summary>The driver update is missing metadata.</summary>
		WU_E_DRV_NO_METADATA = unchecked((int)0x8024C004),

		/// <summary>The driver update is missing a required attribute.</summary>
		WU_E_DRV_MISSING_ATTRIBUTE = unchecked((int)0x8024C005),

		/// <summary>Driver synchronization failed.</summary>
		WU_E_DRV_SYNC_FAILED = unchecked((int)0x8024C006),

		/// <summary>Information required for the synchronization of applicable printers is missing.</summary>
		WU_E_DRV_NO_PRINTER_CONTENT = unchecked((int)0x8024C007),

		/// <summary>After installing a driver update, the updated device has reported a problem.</summary>
		WU_E_DRV_DEVICE_PROBLEM = unchecked((int)0x8024C008),

		/// <summary>A driver error not covered by another WU_E_DRV_* code.</summary>
		WU_E_DRV_UNEXPECTED = unchecked((int)0x8024CFFF),

		/// <summary>An operation failed because Windows Update Agent is shutting down.</summary>
		WU_E_DS_SHUTDOWN = unchecked((int)0x80248000),

		/// <summary>An operation failed because the data store was in use.</summary>
		WU_E_DS_INUSE = unchecked((int)0x80248001),

		/// <summary>The current and expected states of the data store do not match.</summary>
		WU_E_DS_INVALID = unchecked((int)0x80248002),

		/// <summary>The data store is missing a table.</summary>
		WU_E_DS_TABLEMISSING = unchecked((int)0x80248003),

		/// <summary>The data store contains a table with unexpected columns.</summary>
		WU_E_DS_TABLEINCORRECT = unchecked((int)0x80248004),

		/// <summary>A table could not be opened because the table is not in the data store.</summary>
		WU_E_DS_INVALIDTABLENAME = unchecked((int)0x80248005),

		/// <summary>The current and expected versions of the data store do not match.</summary>
		WU_E_DS_BADVERSION = unchecked((int)0x80248006),

		/// <summary>The information requested is not in the data store.</summary>
		WU_E_DS_NODATA = unchecked((int)0x80248007),

		/// <summary>The data store is missing required information or has a NULL in a table column that requires a non-null value.</summary>
		WU_E_DS_MISSINGDATA = unchecked((int)0x80248008),

		/// <summary>The data store is missing required information or has a reference to missing license terms, file, localized property or linked row.</summary>
		WU_E_DS_MISSINGREF = unchecked((int)0x80248009),

		/// <summary>The update was not processed because its update handler could not be recognized.</summary>
		WU_E_DS_UNKNOWNHANDLER = unchecked((int)0x8024800A),

		/// <summary>The update was not deleted because it is still referenced by one or more services.</summary>
		WU_E_DS_CANTDELETE = unchecked((int)0x8024800B),

		/// <summary>The data store section could not be locked within the allotted time.</summary>
		WU_E_DS_LOCKTIMEOUTEXPIRED = unchecked((int)0x8024800C),

		/// <summary>The category was not added because it contains no parent categories and is not a top-level category itself.</summary>
		WU_E_DS_NOCATEGORIES = unchecked((int)0x8024800D),

		/// <summary>The row was not added because an existing row has the same primary key.</summary>
		WU_E_DS_ROWEXISTS = unchecked((int)0x8024800E),

		/// <summary>The data store could not be initialized because it was locked by another process.</summary>
		WU_E_DS_STOREFILELOCKED = unchecked((int)0x8024800F),

		/// <summary>The data store is not allowed to be registered with COM in the current process.</summary>
		WU_E_DS_CANNOTREGISTER = unchecked((int)0x80248010),

		/// <summary>Could not create a data store object in another process.</summary>
		WU_E_DS_UNABLETOSTART = unchecked((int)0x80248011),

		/// <summary>The server sent the same update to the client with two different revision IDs.</summary>
		WU_E_DS_DUPLICATEUPDATEID = unchecked((int)0x80248013),

		/// <summary>An operation did not complete because the service is not in the data store.</summary>
		WU_E_DS_UNKNOWNSERVICE = unchecked((int)0x80248014),

		/// <summary>An operation did not complete because the registration of the service has expired.</summary>
		WU_E_DS_SERVICEEXPIRED = unchecked((int)0x80248015),

		/// <summary>A request to hide an update was declined because it is a mandatory update or because it was deployed with a deadline.</summary>
		WU_E_DS_DECLINENOTALLOWED = unchecked((int)0x80248016),

		/// <summary>A table was not closed because it is not associated with the session.</summary>
		WU_E_DS_TABLESESSIONMISMATCH = unchecked((int)0x80248017),

		/// <summary>A table was not closed because it is not associated with the session.</summary>
		WU_E_DS_SESSIONLOCKMISMATCH = unchecked((int)0x80248018),

		/// <summary>A request to remove the Windows Update service or to unregister it with Automatic Updates was declined because it is a built-in service and/or Automatic Updates cannot fall back to another service.</summary>
		WU_E_DS_NEEDWINDOWSSERVICE = unchecked((int)0x80248019),

		/// <summary>A request was declined because the operation is not allowed.</summary>
		WU_E_DS_INVALIDOPERATION = unchecked((int)0x8024801A),

		/// <summary>The schema of the current data store and the schema of a table in a backup XML document do not match.</summary>
		WU_E_DS_SCHEMAMISMATCH = unchecked((int)0x8024801B),

		/// <summary>The data store requires a session reset; release the session and retry with a new session.</summary>
		WU_E_DS_RESETREQUIRED = unchecked((int)0x8024801C),

		/// <summary>A data store operation did not complete because it was requested with an impersonated identity.</summary>
		WU_E_DS_IMPERSONATED = unchecked((int)0x8024801D),

		/// <summary>An operation against update metadata did not complete because the data was never received from server.</summary>
		WU_E_DS_DATANOTAVAILABLE = unchecked((int)0x8024801E),

		/// <summary>An operation against update metadata did not complete because the data was available but not loaded from datastore.</summary>
		WU_E_DS_DATANOTLOADED = unchecked((int)0x8024801F),

		/// <summary>A data store operation did not complete because no such update revision is known.</summary>
		WU_E_DS_NODATA_NOSUCHREVISION = unchecked((int)0x80248020),

		/// <summary>A data store operation did not complete because no such update is known.</summary>
		WU_E_DS_NODATA_NOSUCHUPDATE = unchecked((int)0x80248021),

		/// <summary>A data store operation did not complete because an update's EULA information is missing.</summary>
		WU_E_DS_NODATA_EULA = unchecked((int)0x80248022),

		/// <summary>A data store operation did not complete because a service's information is missing.</summary>
		WU_E_DS_NODATA_SERVICE = unchecked((int)0x80248023),

		/// <summary>A data store operation did not complete because a service's synchronization information is missing.</summary>
		WU_E_DS_NODATA_COOKIE = unchecked((int)0x80248024),

		/// <summary>A data store operation did not complete because a timer's information is missing.</summary>
		WU_E_DS_NODATA_TIMER = unchecked((int)0x80248025),

		/// <summary>A data store operation did not complete because a download's information is missing.</summary>
		WU_E_DS_NODATA_CCR = unchecked((int)0x80248026),

		/// <summary>A data store operation did not complete because a file's information is missing.</summary>
		WU_E_DS_NODATA_FILE = unchecked((int)0x80248027),

		/// <summary>A data store operation did not complete because a download job's information is missing.</summary>
		WU_E_DS_NODATA_DOWNLOADJOB = unchecked((int)0x80248028),

		/// <summary>A data store operation did not complete because a service's timestamp information is missing.</summary>
		WU_E_DS_NODATA_TMI = unchecked((int)0x80248029),

		/// <summary>A data store error not covered by another WU_E_DS_* code.</summary>
		WU_E_DS_UNEXPECTED = unchecked((int)0x80248FFF),

		/// <summary>Parsing of the rule file failed.</summary>
		WU_E_INVENTORY_PARSEFAILED = unchecked((int)0x80249001),

		/// <summary>Failed to get the requested inventory type from the server.</summary>
		WU_E_INVENTORY_GET_INVENTORY_TYPE_FAILED = unchecked((int)0x80249002),

		/// <summary>Failed to upload inventory result to the server.</summary>
		WU_E_INVENTORY_RESULT_UPLOAD_FAILED = unchecked((int)0x80249003),

		/// <summary>There was an inventory error not covered by another error code.</summary>
		WU_E_INVENTORY_UNEXPECTED = unchecked((int)0x80249004),

		/// <summary>A WMI error occurred when enumerating the instances for a particular class.</summary>
		WU_E_INVENTORY_WMI_ERROR = unchecked((int)0x80249005),

		/// <summary>Automatic Updates was unable to service incoming requests.</summary>
		WU_E_AU_NOSERVICE = unchecked((int)0x8024A000),

		/// <summary>The old version of the Automatic Updates client has stopped because the WSUS server has been upgraded.</summary>
		WU_E_AU_NONLEGACYSERVER = unchecked((int)0x8024A002),

		/// <summary>The old version of the Automatic Updates client was disabled.</summary>
		WU_E_AU_LEGACYCLIENTDISABLED = unchecked((int)0x8024A003),

		/// <summary>Automatic Updates was unable to process incoming requests because it was paused.</summary>
		WU_E_AU_PAUSED = unchecked((int)0x8024A004),

		/// <summary>No unmanaged service is registered with AU.</summary>
		WU_E_AU_NO_REGISTERED_SERVICE = unchecked((int)0x8024A005),

		/// <summary>The default service registered with AU changed during the search.</summary>
		WU_E_AU_DETECT_SVCID_MISMATCH = unchecked((int)0x8024A006),

		/// <summary>A reboot is in progress.</summary>
		WU_E_REBOOT_IN_PROGRESS = unchecked((int)0x8024A007),

		/// <summary>Automatic Updates can't process incoming requests while Windows Welcome is running.</summary>
		WU_E_AU_OOBE_IN_PROGRESS = unchecked((int)0x8024A008),

		/// <summary>An Automatic Updates error not covered by another WU_E_AU * code.</summary>
		WU_E_AU_UNEXPECTED = unchecked((int)0x8024AFFF),

		/// <summary>A request for a remote update handler could not be completed because no remote process is available.</summary>
		WU_E_UH_REMOTEUNAVAILABLE = unchecked((int)0x80242000),

		/// <summary>A request for a remote update handler could not be completed because the handler is local only.</summary>
		WU_E_UH_LOCALONLY = unchecked((int)0x80242001),

		/// <summary>A request for an update handler could not be completed because the handler could not be recognized.</summary>
		WU_E_UH_UNKNOWNHANDLER = unchecked((int)0x80242002),

		/// <summary>A remote update handler could not be created because one already exists.</summary>
		WU_E_UH_REMOTEALREADYACTIVE = unchecked((int)0x80242003),

		/// <summary>A request for the handler to install (uninstall) an update could not be completed because the update does not support install (uninstall).</summary>
		WU_E_UH_DOESNOTSUPPORTACTION = unchecked((int)0x80242004),

		/// <summary>An operation did not complete because the wrong handler was specified.</summary>
		WU_E_UH_WRONGHANDLER = unchecked((int)0x80242005),

		/// <summary>A handler operation could not be completed because the update contains invalid metadata.</summary>
		WU_E_UH_INVALIDMETADATA = unchecked((int)0x80242006),

		/// <summary>An operation could not be completed because the installer exceeded the time limit.</summary>
		WU_E_UH_INSTALLERHUNG = unchecked((int)0x80242007),

		/// <summary>An operation being done by the update handler was cancelled.</summary>
		WU_E_UH_OPERATIONCANCELLED = unchecked((int)0x80242008),

		/// <summary>An operation could not be completed because the handler-specific metadata is invalid.</summary>
		WU_E_UH_BADHANDLERXML = unchecked((int)0x80242009),

		/// <summary>A request to the handler to install an update could not be completed because the update requires user input.</summary>
		WU_E_UH_CANREQUIREINPUT = unchecked((int)0x8024200A),

		/// <summary>The installer failed to install (uninstall) one or more updates.</summary>
		WU_E_UH_INSTALLERFAILURE = unchecked((int)0x8024200B),

		/// <summary>The update handler should download self-contained content rather than delta-compressed content for the update.</summary>
		WU_E_UH_FALLBACKTOSELFCONTAINED = unchecked((int)0x8024200C),

		/// <summary>The update handler did not install the update because it needs to be downloaded again.</summary>
		WU_E_UH_NEEDANOTHERDOWNLOAD = unchecked((int)0x8024200D),

		/// <summary>The update handler failed to send notification of the status of the install (uninstall) operation.</summary>
		WU_E_UH_NOTIFYFAILURE = unchecked((int)0x8024200E),

		/// <summary>The file names contained in the update metadata and in the update package are inconsistent.</summary>
		WU_E_UH_INCONSISTENT_FILE_NAMES = unchecked((int)0x8024200F),

		/// <summary>The update handler failed to fall back to the self-contained content.</summary>
		WU_E_UH_FALLBACKERROR = unchecked((int)0x80242010),

		/// <summary>The update handler has exceeded the maximum number of download requests.</summary>
		WU_E_UH_TOOMANYDOWNLOADREQUESTS = unchecked((int)0x80242011),

		/// <summary>The update handler has received an unexpected response from CBS.</summary>
		WU_E_UH_UNEXPECTEDCBSRESPONSE = unchecked((int)0x80242012),

		/// <summary>The update metadata contains an invalid CBS package identifier.</summary>
		WU_E_UH_BADCBSPACKAGEID = unchecked((int)0x80242013),

		/// <summary>The post-reboot operation for the update is still in progress.</summary>
		WU_E_UH_POSTREBOOTSTILLPENDING = unchecked((int)0x80242014),

		/// <summary>The result of the post-reboot operation for the update could not be determined.</summary>
		WU_E_UH_POSTREBOOTRESULTUNKNOWN = unchecked((int)0x80242015),

		/// <summary>The state of the update after its post-reboot operation has completed is unexpected.</summary>
		WU_E_UH_POSTREBOOTUNEXPECTEDSTATE = unchecked((int)0x80242016),

		/// <summary>The OS servicing stack must be updated before this update is downloaded or installed.</summary>
		WU_E_UH_NEW_SERVICING_STACK_REQUIRED = unchecked((int)0x80242017),

		/// <summary>A callback installer called back with an error.</summary>
		WU_E_UH_CALLED_BACK_FAILURE = unchecked((int)0x80242018),

		/// <summary>The custom installer signature did not match the signature required by the update.</summary>
		WU_E_UH_CUSTOMINSTALLER_INVALID_SIGNATURE = unchecked((int)0x80242019),

		/// <summary>The installer does not support the installation configuration.</summary>
		WU_E_UH_UNSUPPORTED_INSTALLCONTEXT = unchecked((int)0x8024201A),

		/// <summary>The targeted session for install is invalid.</summary>
		WU_E_UH_INVALID_TARGETSESSION = unchecked((int)0x8024201B),

		/// <summary>The handler failed to decrypt the update files.</summary>
		WU_E_UH_DECRYPTFAILURE = unchecked((int)0x8024201C),

		/// <summary>The update handler is disabled until the system reboots.</summary>
		WU_E_UH_HANDLER_DISABLEDUNTILREBOOT = unchecked((int)0x8024201D),

		/// <summary>The AppX infrastructure is not present on the system.</summary>
		WU_E_UH_APPX_NOT_PRESENT = unchecked((int)0x8024201E),

		/// <summary>The update cannot be committed because it has not been previously installed or staged.</summary>
		WU_E_UH_NOTREADYTOCOMMIT = unchecked((int)0x8024201F),

		/// <summary>The specified volume is not a valid AppX package volume.</summary>
		WU_E_UH_APPX_INVALID_PACKAGE_VOLUME = unchecked((int)0x80242020),

		/// <summary>The configured default storage volume is unavailable.</summary>
		WU_E_UH_APPX_DEFAULT_PACKAGE_VOLUME_UNAVAILABLE = unchecked((int)0x80242021),

		/// <summary>The volume on which the application is installed is unavailable.</summary>
		WU_E_UH_APPX_INSTALLED_PACKAGE_VOLUME_UNAVAILABLE = unchecked((int)0x80242022),

		/// <summary>The specified package family is not present on the system.</summary>
		WU_E_UH_APPX_PACKAGE_FAMILY_NOT_FOUND = unchecked((int)0x80242023),

		/// <summary>Unable to find a package volume marked as system.</summary>
		WU_E_UH_APPX_SYSTEM_VOLUME_NOT_FOUND = unchecked((int)0x80242024),

		/// <summary>An update handler error not covered by another WU_E_UH_* code.</summary>
		WU_E_UH_UNEXPECTED = unchecked((int)0x80242FFF),

		/// <summary>A download manager operation could not be completed because the requested file does not have a URL.</summary>
		WU_E_DM_URLNOTAVAILABLE = unchecked((int)0x80246001),

		/// <summary>A download manager operation could not be completed because the file digest was not recognized.</summary>
		WU_E_DM_INCORRECTFILEHASH = unchecked((int)0x80246002),

		/// <summary>A download manager operation could not be completed because the file metadata requested an unrecognized hash algorithm.</summary>
		WU_E_DM_UNKNOWNALGORITHM = unchecked((int)0x80246003),

		/// <summary>An operation could not be completed because a download request is required from the download handler.</summary>
		WU_E_DM_NEEDDOWNLOADREQUEST = unchecked((int)0x80246004),

		/// <summary>A download manager operation could not be completed because the network connection was unavailable.</summary>
		WU_E_DM_NONETWORK = unchecked((int)0x80246005),

		/// <summary>A download manager operation could not be completed because the version of Background Intelligent Transfer Service (BITS) is incompatible.</summary>
		WU_E_DM_WRONGBITSVERSION = unchecked((int)0x80246006),

		/// <summary>The update has not been downloaded.</summary>
		WU_E_DM_NOTDOWNLOADED = unchecked((int)0x80246007),

		/// <summary>A download manager operation failed because the download manager was unable to connect the Background Intelligent Transfer Service (BITS).</summary>
		WU_E_DM_FAILTOCONNECTTOBITS = unchecked((int)0x80246008),

		/// <summary>A download manager operation failed because there was an unspecified Background Intelligent Transfer Service (BITS) transfer error.</summary>
		WU_E_DM_BITSTRANSFERERROR = unchecked((int)0x80246009),

		/// <summary>A download must be restarted because the location of the source of the download has changed.</summary>
		WU_E_DM_DOWNLOADLOCATIONCHANGED = unchecked((int)0x8024600A),

		/// <summary>A download must be restarted because the update content changed in a new revision.</summary>
		WU_E_DM_CONTENTCHANGED = unchecked((int)0x8024600B),

		/// <summary>A download failed because the current network limits downloads by update size for the update service.</summary>
		WU_E_DM_DOWNLOADLIMITEDBYUPDATESIZE = unchecked((int)0x8024600C),

		/// <summary>The download failed because the client was denied authorization to download the content.</summary>
		WU_E_DM_UNAUTHORIZED = unchecked((int)0x8024600E),

		/// <summary>The download failed because the user token associated with the BITS job no longer exists.</summary>
		WU_E_DM_BG_ERROR_TOKEN_REQUIRED = unchecked((int)0x8024600F),

		/// <summary>The sandbox directory for the downloaded update was not found.</summary>
		WU_E_DM_DOWNLOADSANDBOXNOTFOUND = unchecked((int)0x80246010),

		/// <summary>The downloaded update has an unknown file path.</summary>
		WU_E_DM_DOWNLOADFILEPATHUNKNOWN = unchecked((int)0x80246011),

		/// <summary>One or more of the files for the downloaded update is missing.</summary>
		WU_E_DM_DOWNLOADFILEMISSING = unchecked((int)0x80246012),

		/// <summary>An attempt was made to access a downloaded update that has already been removed.</summary>
		WU_E_DM_UPDATEREMOVED = unchecked((int)0x80246013),

		/// <summary>Windows Update couldn't find a needed portion of a downloaded update's file.</summary>
		WU_E_DM_READRANGEFAILED = unchecked((int)0x80246014),

		/// <summary>The download failed because the client was denied authorization to download the content due to no user logged on.</summary>
		WU_E_DM_UNAUTHORIZED_NO_USER = unchecked((int)0x80246016),

		/// <summary>The download failed because the local user was denied authorization to download the content.</summary>
		WU_E_DM_UNAUTHORIZED_LOCAL_USER = unchecked((int)0x80246017),

		/// <summary>The download failed because the domain user was denied authorization to download the content.</summary>
		WU_E_DM_UNAUTHORIZED_DOMAIN_USER = unchecked((int)0x80246018),

		/// <summary>The download failed because the MSA account associated with the user was denied authorization to download the content.</summary>
		WU_E_DM_UNAUTHORIZED_MSA_USER = unchecked((int)0x80246019),

		/// <summary>The download will be continued by falling back to BITS to download the content.</summary>
		WU_E_DM_FALLINGBACKTOBITS = unchecked((int)0x8024601A),

		/// <summary>Another caller has requested download to a different volume.</summary>
		WU_E_DM_DOWNLOAD_VOLUME_CONFLICT = unchecked((int)0x8024601B),

		/// <summary>The hash of the update's sandbox does not match the expected value.</summary>
		WU_E_DM_SANDBOX_HASH_MISMATCH = unchecked((int)0x8024601C),

		/// <summary>The hard reserve id specified conflicts with an id from another caller.</summary>
		WU_E_DM_HARDRESERVEID_CONFLICT = unchecked((int)0x8024601D),

		/// <summary>The update has to be downloaded via DO.</summary>
		WU_E_DM_DOSVC_REQUIRED = unchecked((int)0x8024601E),

		/// <summary>There was a download manager error not covered by another WU_E_DM_* error code.</summary>
		WU_E_DM_UNEXPECTED = unchecked((int)0x80246FFF),

		/// <summary>Windows Update Agent could not be updated because an INF file contains invalid information.</summary>
		WU_E_SETUP_INVALID_INFDATA = unchecked((int)0x8024D001),

		/// <summary>Windows Update Agent could not be updated because the wuident.cab file contains invalid information.</summary>
		WU_E_SETUP_INVALID_IDENTDATA = unchecked((int)0x8024D002),

		/// <summary>Windows Update Agent could not be updated because of an internal error that caused setup initialization to be performed twice.</summary>
		WU_E_SETUP_ALREADY_INITIALIZED = unchecked((int)0x8024D003),

		/// <summary>Windows Update Agent could not be updated because setup initialization never completed successfully.</summary>
		WU_E_SETUP_NOT_INITIALIZED = unchecked((int)0x8024D004),

		/// <summary>Windows Update Agent could not be updated because the versions specified in the INF do not match the actual source file versions.</summary>
		WU_E_SETUP_SOURCE_VERSION_MISMATCH = unchecked((int)0x8024D005),

		/// <summary>Windows Update Agent could not be updated because a WUA file on the target system is newer than the corresponding source file.</summary>
		WU_E_SETUP_TARGET_VERSION_GREATER = unchecked((int)0x8024D006),

		/// <summary>Windows Update Agent could not be updated because regsvr32.exe returned an error.</summary>
		WU_E_SETUP_REGISTRATION_FAILED = unchecked((int)0x8024D007),

		/// <summary>An update to the Windows Update Agent was skipped because previous attempts to update have failed.</summary>
		WU_E_SELFUPDATE_SKIP_ON_FAILURE = unchecked((int)0x8024D008),

		/// <summary>An update to the Windows Update Agent was skipped due to a directive in the wuident.cab file.</summary>
		WU_E_SETUP_SKIP_UPDATE = unchecked((int)0x8024D009),

		/// <summary>Windows Update Agent could not be updated because the current system configuration is not supported.</summary>
		WU_E_SETUP_UNSUPPORTED_CONFIGURATION = unchecked((int)0x8024D00A),

		/// <summary>Windows Update Agent could not be updated because the system is configured to block the update.</summary>
		WU_E_SETUP_BLOCKED_CONFIGURATION = unchecked((int)0x8024D00B),

		/// <summary>Windows Update Agent could not be updated because a restart of the system is required.</summary>
		WU_E_SETUP_REBOOT_TO_FIX = unchecked((int)0x8024D00C),

		/// <summary>Windows Update Agent setup is already running.</summary>
		WU_E_SETUP_ALREADYRUNNING = unchecked((int)0x8024D00D),

		/// <summary>Windows Update Agent setup package requires a reboot to complete installation.</summary>
		WU_E_SETUP_REBOOTREQUIRED = unchecked((int)0x8024D00E),

		/// <summary>Windows Update Agent could not be updated because the setup handler failed during execution.</summary>
		WU_E_SETUP_HANDLER_EXEC_FAILURE = unchecked((int)0x8024D00F),

		/// <summary>Windows Update Agent could not be updated because the registry contains invalid information.</summary>
		WU_E_SETUP_INVALID_REGISTRY_DATA = unchecked((int)0x8024D010),

		/// <summary>Windows Update Agent must be updated before search can continue.</summary>
		WU_E_SELFUPDATE_REQUIRED = unchecked((int)0x8024D011),

		/// <summary>Windows Update Agent must be updated before search can continue.  An administrator is required to perform the operation.</summary>
		WU_E_SELFUPDATE_REQUIRED_ADMIN = unchecked((int)0x8024D012),

		/// <summary>Windows Update Agent could not be updated because the server does not contain update information for this version.</summary>
		WU_E_SETUP_WRONG_SERVER_VERSION = unchecked((int)0x8024D013),

		/// <summary>Windows Update Agent is successfully updated, but a reboot is required to complete the setup.</summary>
		WU_E_SETUP_DEFERRABLE_REBOOT_PENDING = unchecked((int)0x8024D014),

		/// <summary>Windows Update Agent is successfully updated, but a reboot is required to complete the setup.</summary>
		WU_E_SETUP_NON_DEFERRABLE_REBOOT_PENDING = unchecked((int)0x8024D015),

		/// <summary>Windows Update Agent could not be updated because of an unknown error.</summary>
		WU_E_SETUP_FAIL = unchecked((int)0x8024D016),

		/// <summary>Windows Update Agent could not be updated because of an error not covered by another WU_E_SETUP_* error code.</summary>
		WU_E_SETUP_UNEXPECTED = unchecked((int)0x8024DFFF),

		/// <summary>An expression evaluator operation could not be completed because an expression was unrecognized.</summary>
		WU_E_EE_UNKNOWN_EXPRESSION = unchecked((int)0x8024E001),

		/// <summary>An expression evaluator operation could not be completed because an expression was invalid.</summary>
		WU_E_EE_INVALID_EXPRESSION = unchecked((int)0x8024E002),

		/// <summary>An expression evaluator operation could not be completed because an expression contains an incorrect number of metadata nodes.</summary>
		WU_E_EE_MISSING_METADATA = unchecked((int)0x8024E003),

		/// <summary>An expression evaluator operation could not be completed because the version of the serialized expression data is invalid.</summary>
		WU_E_EE_INVALID_VERSION = unchecked((int)0x8024E004),

		/// <summary>The expression evaluator could not be initialized.</summary>
		WU_E_EE_NOT_INITIALIZED = unchecked((int)0x8024E005),

		/// <summary>An expression evaluator operation could not be completed because there was an invalid attribute.</summary>
		WU_E_EE_INVALID_ATTRIBUTEDATA = unchecked((int)0x8024E006),

		/// <summary>An expression evaluator operation could not be completed because the cluster state of the computer could not be determined.</summary>
		WU_E_EE_CLUSTER_ERROR = unchecked((int)0x8024E007),

		/// <summary>There was an expression evaluator error not covered by another WU_E_EE_* error code.</summary>
		WU_E_EE_UNEXPECTED = unchecked((int)0x8024EFFF),

		/// <summary>The results of download and installation could not be read from the registry due to an unrecognized data format version.</summary>
		WU_E_INSTALLATION_RESULTS_UNKNOWN_VERSION = unchecked((int)0x80243001),

		/// <summary>The results of download and installation could not be read from the registry due to an invalid data format.</summary>
		WU_E_INSTALLATION_RESULTS_INVALID_DATA = unchecked((int)0x80243002),

		/// <summary>The results of download and installation are not available; the operation may have failed to start.</summary>
		WU_E_INSTALLATION_RESULTS_NOT_FOUND = unchecked((int)0x80243003),

		/// <summary>A failure occurred when trying to create an icon in the taskbar notification area.</summary>
		WU_E_TRAYICON_FAILURE = unchecked((int)0x80243004),

		/// <summary>Unable to show UI when in non-UI mode; WU client UI modules may not be installed.</summary>
		WU_E_NON_UI_MODE = unchecked((int)0x80243FFD),

		/// <summary>Unsupported version of WU client UI exported functions.</summary>
		WU_E_WUCLTUI_UNSUPPORTED_VERSION = unchecked((int)0x80243FFE),

		/// <summary>There was a user interface error not covered by another WU_E_AUCLIENT_* error code.</summary>
		WU_E_AUCLIENT_UNEXPECTED = unchecked((int)0x80243FFF),

		/// <summary>The event cache file was defective.</summary>
		WU_E_REPORTER_EVENTCACHECORRUPT = unchecked((int)0x8024F001),

		/// <summary>The XML in the event namespace descriptor could not be parsed.</summary>
		WU_E_REPORTER_EVENTNAMESPACEPARSEFAILED = unchecked((int)0x8024F002),

		/// <summary>The XML in the event namespace descriptor could not be parsed.</summary>
		WU_E_INVALID_EVENT = unchecked((int)0x8024F003),

		/// <summary>The server rejected an event because the server was too busy.</summary>
		WU_E_SERVER_BUSY = unchecked((int)0x8024F004),

		/// <summary>The specified callback cookie is not found.</summary>
		WU_E_CALLBACK_COOKIE_NOT_FOUND = unchecked((int)0x8024F005),

		/// <summary>There was a reporter error not covered by another error code.</summary>
		WU_E_REPORTER_UNEXPECTED = unchecked((int)0x8024FFFF),

		/// <summary>An operation could not be completed because the scan package was invalid.</summary>
		WU_E_OL_INVALID_SCANFILE = unchecked((int)0x80247001),

		/// <summary>An operation could not be completed because the scan package requires a greater version of the Windows Update Agent.</summary>
		WU_E_OL_NEWCLIENT_REQUIRED = unchecked((int)0x80247002),

		/// <summary>An invalid event payload was specified.</summary>
		WU_E_INVALID_EVENT_PAYLOAD = unchecked((int)0x80247003),

		/// <summary>The size of the event payload submitted is invalid.</summary>
		WU_E_INVALID_EVENT_PAYLOADSIZE = unchecked((int)0x80247004),

		/// <summary>The service is not registered.</summary>
		WU_E_SERVICE_NOT_REGISTERED = unchecked((int)0x80247005),

		/// <summary>Search using the scan package failed.</summary>
		WU_E_OL_UNEXPECTED = unchecked((int)0x80247FFF),

		/// <summary>No operation was required by update metadata verification.</summary>
		WU_E_METADATA_NOOP = unchecked((int)0x80247100),

		/// <summary>The binary encoding of metadata config data was invalid.</summary>
		WU_E_METADATA_CONFIG_INVALID_BINARY_ENCODING = unchecked((int)0x80247101),

		/// <summary>Unable to fetch required configuration for metadata signature verification.</summary>
		WU_E_METADATA_FETCH_CONFIG = unchecked((int)0x80247102),

		/// <summary>A metadata verification operation failed due to an invalid parameter.</summary>
		WU_E_METADATA_INVALID_PARAMETER = unchecked((int)0x80247104),

		/// <summary>A metadata verification operation failed due to reasons not covered by another error code.</summary>
		WU_E_METADATA_UNEXPECTED = unchecked((int)0x80247105),

		/// <summary>None of the update metadata had verification data, which may be disabled on the update server.</summary>
		WU_E_METADATA_NO_VERIFICATION_DATA = unchecked((int)0x80247106),

		/// <summary>The fragment signing configuration used for verifying update metadata signatures was bad.</summary>
		WU_E_METADATA_BAD_FRAGMENTSIGNING_CONFIG = unchecked((int)0x80247107),

		/// <summary>There was an unexpected operational failure while parsing fragment signing configuration.</summary>
		WU_E_METADATA_FAILURE_PROCESSING_FRAGMENTSIGNING_CONFIG = unchecked((int)0x80247108),

		/// <summary>Required xml data was missing from configuration.</summary>
		WU_E_METADATA_XML_MISSING = unchecked((int)0x80247120),

		/// <summary>Required fragmentsigning data was missing from xml configuration.</summary>
		WU_E_METADATA_XML_FRAGMENTSIGNING_MISSING = unchecked((int)0x80247121),

		/// <summary>Required mode data was missing from xml configuration.</summary>
		WU_E_METADATA_XML_MODE_MISSING = unchecked((int)0x80247122),

		/// <summary>An invalid metadata enforcement mode was detected.</summary>
		WU_E_METADATA_XML_MODE_INVALID = unchecked((int)0x80247123),

		/// <summary>An invalid timestamp validity window configuration was detected.</summary>
		WU_E_METADATA_XML_VALIDITY_INVALID = unchecked((int)0x80247124),

		/// <summary>Required leaf certificate data was missing from xml configuration.</summary>
		WU_E_METADATA_XML_LEAFCERT_MISSING = unchecked((int)0x80247125),

		/// <summary>Required intermediate certificate data was missing from xml configuration.</summary>
		WU_E_METADATA_XML_INTERMEDIATECERT_MISSING = unchecked((int)0x80247126),

		/// <summary>Required leaf certificate id attribute was missing from xml configuration.</summary>
		WU_E_METADATA_XML_LEAFCERT_ID_MISSING = unchecked((int)0x80247127),

		/// <summary>Required certificate base64CerData attribute was missing from xml configuration.</summary>
		WU_E_METADATA_XML_BASE64CERDATA_MISSING = unchecked((int)0x80247128),

		/// <summary>The metadata for an update was found to have a bad or invalid digital signature.</summary>
		WU_E_METADATA_BAD_SIGNATURE = unchecked((int)0x80247140),

		/// <summary>An unsupported hash algorithm for metadata verification was specified.</summary>
		WU_E_METADATA_UNSUPPORTED_HASH_ALG = unchecked((int)0x80247141),

		/// <summary>An error occurred during an update's metadata signature verification.</summary>
		WU_E_METADATA_SIGNATURE_VERIFY_FAILED = unchecked((int)0x80247142),

		/// <summary>An failure occurred while verifying trust for metadata signing certificate chains.</summary>
		WU_E_METADATATRUST_CERTIFICATECHAIN_VERIFICATION = unchecked((int)0x80247150),

		/// <summary>A metadata signing certificate had an untrusted certificate chain.</summary>
		WU_E_METADATATRUST_UNTRUSTED_CERTIFICATECHAIN = unchecked((int)0x80247151),

		/// <summary>An expected metadata timestamp token was missing.</summary>
		WU_E_METADATA_TIMESTAMP_TOKEN_MISSING = unchecked((int)0x80247160),

		/// <summary>A metadata Timestamp token failed verification.</summary>
		WU_E_METADATA_TIMESTAMP_TOKEN_VERIFICATION_FAILED = unchecked((int)0x80247161),

		/// <summary>A metadata timestamp token signer certificate chain was untrusted.</summary>
		WU_E_METADATA_TIMESTAMP_TOKEN_UNTRUSTED = unchecked((int)0x80247162),

		/// <summary>A metadata signature timestamp token was no longer within the validity window.</summary>
		WU_E_METADATA_TIMESTAMP_TOKEN_VALIDITY_WINDOW = unchecked((int)0x80247163),

		/// <summary>A metadata timestamp token failed signature validation</summary>
		WU_E_METADATA_TIMESTAMP_TOKEN_SIGNATURE = unchecked((int)0x80247164),

		/// <summary>A metadata timestamp token certificate failed certificate chain verification.</summary>
		WU_E_METADATA_TIMESTAMP_TOKEN_CERTCHAIN = unchecked((int)0x80247165),

		/// <summary>A failure occurred when refreshing a missing timestamp token from the network.</summary>
		WU_E_METADATA_TIMESTAMP_TOKEN_REFRESHONLINE = unchecked((int)0x80247166),

		/// <summary>All update metadata verification timestamp tokens from the timestamp token cache are invalid.</summary>
		WU_E_METADATA_TIMESTAMP_TOKEN_ALL_BAD = unchecked((int)0x80247167),

		/// <summary>No update metadata verification timestamp tokens exist in the timestamp token cache.</summary>
		WU_E_METADATA_TIMESTAMP_TOKEN_NODATA = unchecked((int)0x80247168),

		/// <summary>An error occurred during cache lookup of update metadata verification timestamp token.</summary>
		WU_E_METADATA_TIMESTAMP_TOKEN_CACHELOOKUP = unchecked((int)0x80247169),

		/// <summary>An metadata timestamp token validity window failed unexpectedly due to reasons not covered by another error code.</summary>
		WU_E_METADATA_TIMESTAMP_TOKEN_VALIDITYWINDOW_UNEXPECTED = unchecked((int)0x8024717E),

		/// <summary>An metadata timestamp token verification operation failed due to reasons not covered by another error code.</summary>
		WU_E_METADATA_TIMESTAMP_TOKEN_UNEXPECTED = unchecked((int)0x8024717F),

		/// <summary>An expected metadata signing certificate was missing.</summary>
		WU_E_METADATA_CERT_MISSING = unchecked((int)0x80247180),

		/// <summary>The transport encoding of a metadata signing leaf certificate was malformed.</summary>
		WU_E_METADATA_LEAFCERT_BAD_TRANSPORT_ENCODING = unchecked((int)0x80247181),

		/// <summary>The transport encoding of a metadata signing intermediate certificate was malformed.</summary>
		WU_E_METADATA_INTCERT_BAD_TRANSPORT_ENCODING = unchecked((int)0x80247182),

		/// <summary>A metadata certificate chain was untrusted.</summary>
		WU_E_METADATA_CERT_UNTRUSTED = unchecked((int)0x80247183),

		/// <summary>The task is currently in progress.</summary>
		WU_E_WUTASK_INPROGRESS = unchecked((int)0x8024B001),

		/// <summary>The operation cannot be completed since the task status is currently disabled.</summary>
		WU_E_WUTASK_STATUS_DISABLED = unchecked((int)0x8024B002),

		/// <summary>The operation cannot be completed since the task is not yet started.</summary>
		WU_E_WUTASK_NOT_STARTED = unchecked((int)0x8024B003),

		/// <summary>The task was stopped and needs to be run again to complete.</summary>
		WU_E_WUTASK_RETRY = unchecked((int)0x8024B004),

		/// <summary>Cannot cancel a non-scheduled install.</summary>
		WU_E_WUTASK_CANCELINSTALL_DISALLOWED = unchecked((int)0x8024B005),

		/// <summary>Hardware capability meta data was not found after a sync with the service.</summary>
		WU_E_UNKNOWN_HARDWARECAPABILITY = unchecked((int)0x8024B101),

		/// <summary>Hardware capability meta data was malformed and/or failed to parse.</summary>
		WU_E_BAD_XML_HARDWARECAPABILITY = unchecked((int)0x8024B102),

		/// <summary>Unable to complete action due to WMI dependency, which isn't supported on this platform.</summary>
		WU_E_WMI_NOT_SUPPORTED = unchecked((int)0x8024B103),

		/// <summary>Merging of the update is not allowed</summary>
		WU_E_UPDATE_MERGE_NOT_ALLOWED = unchecked((int)0x8024B104),

		/// <summary>Installing merged updates only. So skipping non mergeable updates.</summary>
		WU_E_SKIPPED_UPDATE_INSTALLATION = unchecked((int)0x8024B105),

		/// <summary>SLS response returned invalid revision number.</summary>
		WU_E_SLS_INVALID_REVISION = unchecked((int)0x8024B201),

		/// <summary>File signature validation fails to find valid RSA signature on infrastructure payload.</summary>
		WU_E_FILETRUST_DUALSIGNATURE_RSA = unchecked((int)0x8024B301),

		/// <summary>File signature validation fails to find valid ECC signature on infrastructure payload.</summary>
		WU_E_FILETRUST_DUALSIGNATURE_ECC = unchecked((int)0x8024B302),

		/// <summary>The subject is not trusted by WU for the specified action.</summary>
		WU_E_TRUST_SUBJECT_NOT_TRUSTED = unchecked((int)0x8024B303),

		/// <summary>Unknown trust provider for WU.</summary>
		WU_E_TRUST_PROVIDER_UNKNOWN = unchecked((int)0x8024B304),
	}
}