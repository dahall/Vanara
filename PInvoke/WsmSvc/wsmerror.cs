namespace Vanara.PInvoke;

public static partial class WsmSvc
{
	static WsmSvc() => StaticFieldValueHash.AddFields<Win32Error, uint, WsmError>(Lib_WsmSvc);

	/// <summary>WSMAN specific error codes</summary>
	public enum WsmError : uint
	{
		/// <summary>
		/// The WS-Management service cannot process the request. The service cannot find the resource identified by the resource URI and selectors.
		/// </summary>
		ERROR_WSMAN_RESOURCE_NOT_FOUND = 0x80338000,

		/// <summary>
		/// The WS-Management service cannot process the request. The WS-Addressing action URI is invalid. Check the documentation for
		/// information on how to construct an action URI.
		/// </summary>
		ERROR_WSMAN_INVALID_ACTIONURI = 0x80338001,

		/// <summary>
		/// Same text as ERROR_WSMAN_INVALID_RESOURCE_URI, but some code in R2 uses this error code The WS-Management service cannot process
		/// the request. The resource URI is missing or it has an incorrect format. Check the documentation or use the following command for
		/// information on how to construct a resource URI: "winrm help uris".
		/// </summary>
		ERROR_WSMAN_INVALID_URI = 0x80338002,

		/// <summary>An error was encountered inside the plugin.</summary>
		ERROR_WSMAN_PROVIDER_FAILURE = 0x80338003,

		/// <summary>
		/// The WS-Management service cannot complete the request. The WSManEnumerator object is full and no more items can be added.
		/// </summary>
		ERROR_WSMAN_BATCH_COMPLETE = 0x80338004,

		/// <summary>
		/// The WS-Management configuration is corrupted. Use the following command to restore defaults: %n%n winrm invoke Restore
		/// http://schemas.microsoft.com/wbem/wsman/1/config @{} %n%n Then add any custom configuration settings.
		/// </summary>
		ERROR_WSMAN_CONFIG_CORRUPTED = 0x80338005,

		/// <summary>The WS-Management service cannot process a pull request because a pull operation is already in progress.</summary>
		ERROR_WSMAN_PULL_IN_PROGRESS = 0x80338006,

		/// <summary>The WS-Management enumeration session is finished or cancelled and cannot be used. Start a new enumeration.</summary>
		ERROR_WSMAN_ENUMERATION_CLOSED = 0x80338007,

		/// <summary>The event subscription is already closed and cannot be used. Start a new subscription.</summary>
		ERROR_WSMAN_SUBSCRIPTION_CLOSED = 0x80338008,

		/// <summary>The event subscription session is closing and cannot be used. Start a new subscription.</summary>
		ERROR_WSMAN_SUBSCRIPTION_CLOSE_IN_PROGRESS = 0x80338009,

		/// <summary>
		/// The application or script that has an event subscription did not request a pull operation within the heartbeat interval. The
		/// subscription session was closed. Start a new subscription.
		/// </summary>
		ERROR_WSMAN_SUBSCRIPTION_CLIENT_DID_NOT_CALL_WITHIN_HEARTBEAT = 0x8033800A,

		/// <summary>
		/// The event source did not return events within the heartbeat interval. The subscription session was closed. Start a new subscription.
		/// </summary>
		ERROR_WSMAN_SUBSCRIPTION_NO_HEARTBEAT = 0x8033800B,

		/// <summary>
		/// The WS-Management service does not support the specified timeout. The value specified is smaller than the minimum allowed value
		/// for this setting. Change the timeout value and try the request again.
		/// </summary>
		ERROR_WSMAN_UNSUPPORTED_TIMEOUT = 0x8033800C,

		/// <summary>
		/// wsa, code=VersionMismatch, subcode=, details=version mismatch The WS-Management service does not support the SOAP version
		/// specified in the request.
		/// </summary>
		ERROR_WSMAN_SOAP_VERSION_MISMATCH = 0x8033800D,

		/// <summary>
		/// wsa, code=DataEncodingUnknown, subcode=, details=version mismatch The WS-Management service does not support the encoding
		/// specified in the request.
		/// </summary>
		ERROR_WSMAN_SOAP_DATA_ENCODING_UNKNOWN = 0x8033800E,

		/// <summary>
		/// wsa, code=Sender, subcode=WS-Addressing InvalidMessageInformationHeader, details=invalid_header The WS-Management service cannot
		/// process the request. The request contains one or more invalid SOAP headers.
		/// </summary>
		ERROR_WSMAN_INVALID_MESSAGE_INFORMATION_HEADER = 0x8033800F,

		/// <summary>
		/// The WS-Management service cannot process a SOAP header in the request that is marked as mustUnderstand by the client. This could
		/// be caused by the use of a version of the protocol which is not supported, or may be an incompatibility between the client and
		/// server implementations.
		/// </summary>
		ERROR_WSMAN_SOAP_FAULT_MUST_UNDERSTAND = 0x80338010,

		/// <summary>
		/// wsa, code=Sender, subcode=WS-Addressing MessageInformationHeaderRequired, details=missing_header The WS-Management service cannot
		/// process the request. The request does not have all the expected SOAP headers.
		/// </summary>
		ERROR_WSMAN_MESSAGE_INFORMATION_HEADER_REQUIRED = 0x80338011,

		/// <summary>
		/// wsa, code=Sender, subcode=WS-Addressing DestinationUnreachable, details= The client cannot connect to the destination specified
		/// in the request. Verify that the service on the destination is running and is accepting requests. Consult the logs and
		/// documentation for the WS-Management service running on the destination, most commonly IIS or WinRM. If the destination is the
		/// WinRM service, run the following command on the destination to analyze and configure the WinRM service: "winrm quickconfig".
		/// </summary>
		ERROR_WSMAN_DESTINATION_UNREACHABLE = 0x80338012,

		/// <summary>
		/// wsa, code=Sender, subcode=WS-Addressing ActionNotsupported, details=action The WS-Management service does not support the action
		/// specified in the request.
		/// </summary>
		ERROR_WSMAN_ACTION_NOT_SUPPORTED = 0x80338013,

		/// <summary>
		/// This is probably what will wrap all other Windows error codes and so should not explicitly be used wsa, code=Receiver,
		/// subcode=WS-Addressing EndpointUnavailable, details= The WS-Management service cannot process the request because the resource is
		/// offline. Retry the request later when the resource is online.
		/// </summary>
		ERROR_WSMAN_ENDPOINT_UNAVAILABLE = 0x80338014,

		/// <summary>
		/// wsa, code=Sender, subcode=wxf:InvalidRepresentation, details= The WS-Management service cannot identify the format of the object
		/// passed to a Put or Create method. The input XML may not be appropriate for the resource or uses the wrong schema for the
		/// resource. Change the input XML in the request.
		/// </summary>
		ERROR_WSMAN_INVALID_REPRESENTATION = 0x80338015,

		/// <summary>
		/// wsen, code=Sender, subcode=WS-Enumeration InvalidExpirationTime, details= The expiration time passed to the WS-Management
		/// Enumerate method is not valid. The time value may be zero or refer to a time in the past. Change the expiration time and try the
		/// request again.
		/// </summary>
		ERROR_WSMAN_ENUMERATE_INVALID_EXPIRATION_TIME = 0x80338016,

		/// <summary>
		/// wsman, code=Sender, subcode=WS-Management UnsupportedFeature - WS-Management faultDetail/ExpirationTime, details= The data source
		/// does not support expiration time. Remove the expiration time from the request and try the request again.
		/// </summary>
		ERROR_WSMAN_ENUMERATE_UNSUPPORTED_EXPIRATION_TIME = 0x80338017,

		/// <summary>
		/// wsen, code=Sender, subcode=WS-Enumeration FilteringNotSupported, details= The data source does not support filtering. Remove the
		/// filter from the request and try the request again.
		/// </summary>
		ERROR_WSMAN_ENUMERATE_FILTERING_NOT_SUPPORTED = 0x80338018,

		/// <summary>
		/// wsen, code=Sender, subcode=WS-Enumeration FilterDialectRequestedUnavailable, details=supported_dialects The filter dialect (the
		/// type associated with the filter) was not supported for this resource. Change the filter dialect or remove it from the request and
		/// try the request again.
		/// </summary>
		ERROR_WSMAN_ENUMERATE_FILTER_DIALECT_REQUESTED_UNAVAILABLE = 0x80338019,

		/// <summary>
		/// wsen, code=Sender, subcode=WS-Enumeration CannotProcessFilter, details= The data source could not process the filter. The filter
		/// might be missing or it might be invalid. Change the filter and try the request again.
		/// </summary>
		ERROR_WSMAN_ENUMERATE_CANNOT_PROCESS_FILTER = 0x8033801A,

		/// <summary>
		/// wsen, code=Receiver, subcode=WS-Enumeration InvalidEnumerationContext, details= The WS-Enumeration context in the enumeration is
		/// not valid. Enumeration may have been completed or canceled. You cannot use this enumeration context anymore. Start a new enumeration.
		/// </summary>
		ERROR_WSMAN_ENUMERATE_INVALID_ENUMERATION_CONTEXT = 0x8033801B,

		/// <summary>
		/// wsen, code=Receiver, subcode=WS-Enumeration TimedOut, details= The pull operation did not get any data in the MaxTime duration.
		/// But the enumeration is still valid. The client can attempt to do another pull request to retrieve data.
		/// </summary>
		ERROR_WSMAN_ENUMERATE_TIMED_OUT = 0x8033801C,

		/// <summary>
		/// wsen, code=Receiver, subcode=WS-Enumeration UnableToRenew, details= The WS-Management service cannot renew the enumeration. Start
		/// a new enumeration.
		/// </summary>
		ERROR_WSMAN_ENUMERATE_UNABLE_TO_RENEW = 0x8033801D,

		/// <summary>
		/// wse, code=Sender, subcode=WS-Eventing DeliveryModeRequestedUnavailable, details=List of delivery modes that are supported The
		/// WS-Management service does not support the delivery mode for the specified resource. The client should change the subscription to
		/// use one of the supported delivery modes.
		/// </summary>
		ERROR_WSMAN_EVENTING_DELIVERY_MODE_REQUESTED_UNAVAILABLE = 0x8033801E,

		/// <summary>
		/// wse, code=Sender, subcode=WS-Eventing InvalidExpirationTime, details= The expiration time of the subscription is invalid. The
		/// time is either not supported, zero or a time that happened in the past. Change the expiration time and try the request again.
		/// </summary>
		ERROR_WSMAN_EVENTING_INVALID_EXPIRATION_TIME = 0x8033801F,

		/// <summary>
		/// wse, code=Sender, subcode=WS-Eventing UnsupportedExpirationType, details= The expiration time specified for subscription was
		/// invalid. Specify the expiration time as a duration.
		/// </summary>
		ERROR_WSMAN_EVENTING_UNSUPPORTED_EXPIRATION_TYPE = 0x80338020,

		/// <summary>
		/// wse, code=Sender, subcode=WS-Eventing FilteringNotSupported, details= The event source does not support filtering. Remove the
		/// filter from the request and try the request again.
		/// </summary>
		ERROR_WSMAN_EVENTING_FILTERING_NOT_SUPPORTED = 0x80338021,

		/// <summary>
		/// wse, code=Sender, subcode=WS-Eventing FilteringRequestedUnavailable, details= The event source cannot process the specified
		/// filter. Change the filter or remove it from the request and try the request again.
		/// </summary>
		ERROR_WSMAN_EVENTING_FILTERING_REQUESTED_UNAVAILABLE = 0x80338022,

		/// <summary>
		/// wse, code=Receiver, subcode=WS-Eventing EventSourceUnableToProcess, details= The event source cannot process the subscription.
		/// </summary>
		ERROR_WSMAN_EVENTING_SOURCE_UNABLE_TO_PROCESS = 0x80338023,

		/// <summary>
		/// wse, code=Receiver, subcode=WS-Eventing UnableToRenew, details= The WS-Management service cannot renew the event subscription.
		/// Create a new subscription.
		/// </summary>
		ERROR_WSMAN_EVENTING_UNABLE_TO_RENEW = 0x80338024,

		/// <summary>
		/// wse, code=Sender, subcode=WS-Eventing InvalidMessage, details= The WS-Management service cannot complete the WS-Eventing request
		/// because the request had some unknown or invalid content and could not be processed.
		/// </summary>
		ERROR_WSMAN_EVENTING_INVALID_MESSAGE = 0x80338025,

		/// <summary>The WS-Management service cannot process the response because it is larger than the maximum size allowed.</summary>
		ERROR_WSMAN_ENVELOPE_TOO_LARGE = 0x80338026,

		/// <summary>
		/// wsman, code=Sender, subcode=WS-Management InvalidBody, details= The WS-Management service cannot process the request because the
		/// request packet does not have a valid SOAP body.
		/// </summary>
		ERROR_WSMAN_INVALID_SOAP_BODY = 0x80338027,

		/// <summary>
		/// wsman, code=Sender, subcode=WS-Management InvalidResumptionContext, details= The resumption context specified in the subscription
		/// is invalid. It may have expired, or be in the wrong format.
		/// </summary>
		ERROR_WSMAN_INVALID_RESUMPTION_CONTEXT = 0x80338028,

		/// <summary>
		/// wsman, code=Receiver, subcode=WS-Management Timedout, details= The WS-Management service cannot complete the operation within the
		/// time specified in OperationTimeout.
		/// </summary>
		ERROR_WSMAN_OPERATION_TIMEDOUT = 0x80338029,

		/// <summary>
		/// wsman, code=Sender, subcode=WS-Management ResumptionNotSupported, details= The event source does not support subscriptions that
		/// can be resumed.
		/// </summary>
		ERROR_WSMAN_RESUMPTION_NOT_SUPPORTED = 0x8033802A,

		/// <summary>
		/// wsman, code=Sender, subcode=WS-Management ResumptionTypeNotSupported, details= The WS-Management service does not support the
		/// type of resumption requested by the subscription.
		/// </summary>
		ERROR_WSMAN_RESUMPTION_TYPE_NOT_SUPPORTED = 0x8033802B,

		/// <summary>
		/// wsman, code=Sender, subcode=WS-Management UnsupportedEncoding, details= The request contains character encoding that is
		/// unsupported. WS-Management only supports requests that are encoded in UTF-8 or UTF-16. Change the character encoding in the
		/// request and try the request again.
		/// </summary>
		ERROR_WSMAN_UNSUPPORTED_ENCODING = 0x8033802C,

		/// <summary>wsman, code=Sender, subcode=WS-Management UriLimit, details= The URI is longer than the maximum length allowed.</summary>
		ERROR_WSMAN_URI_LIMIT = 0x8033802D,

		/// <summary>
		/// wsman, code=Sender, subcode=WS-Management InvalidProposedID, details= The WS-Management service cannot process the request
		/// because the subscription ID is invalid.
		/// </summary>
		ERROR_WSMAN_INVALID_PROPOSED_ID = 0x8033802E,

		/// <summary>
		/// wsman, code=Sender, subcode=WS-Management InvalidBatchParameter, details= The WS-Management service cannot process the batch
		/// request. The request must specify either MaxItems, MaxCharacters, or MaxTime.
		/// </summary>
		ERROR_WSMAN_INVALID_BATCH_PARAMETER = 0x8033802F,

		/// <summary>
		/// wsman, code=Sender, subcode=WS-Management NoAck, details= The receiver of the event did not acknowledge the event delivery.
		/// Submit the subscription again without the acknowledgement option.
		/// </summary>
		ERROR_WSMAN_NO_ACK = 0x80338030,

		/// <summary>
		/// wsman, code=Sender, subcode=WS-Management ActionMismatch, details= The WS-Management service cannot process the request because
		/// the WS-Addressing Action URI in the request is not compatible with the resource.
		/// </summary>
		ERROR_WSMAN_ACTION_MISMATCH = 0x80338031,

		/// <summary>
		/// wsman, code=Sender, subcode=WS-Management Concurrency, details= The WS-Management service cannot complete the WS-Addressing
		/// Action URI in the request because the resource was already in use.
		/// </summary>
		ERROR_WSMAN_CONCURRENCY = 0x80338032,

		/// <summary>
		/// wsman, code=Sender, subcode=WS-Management AlreadyExists, details= The WS-Management service cannot create the resource because it
		/// already exists.
		/// </summary>
		ERROR_WSMAN_ALREADY_EXISTS = 0x80338033,

		/// <summary>
		/// wsman, code=Receiver, subcode=WS-Management DeliveryRefused, details= The WS-Management service cannot complete the request
		/// because the receiver does not accept the delivery of events. The receiver requests that the subscription be cancelled. Event
		/// receivers return this message to force the cancellation of a subscription.
		/// </summary>
		ERROR_WSMAN_DELIVERY_REFUSED = 0x80338034,

		/// <summary>
		/// wsman, code=Sender, subcode=WS-Management EncodingLimit, details= The WS-Management service cannot process the request because
		/// the encoding of the request exceeds an internal encoding limit. Reconfigure the client to send messages which fit the encoding
		/// limits of the service.
		/// </summary>
		ERROR_WSMAN_ENCODING_LIMIT = 0x80338035,

		/// <summary>
		/// wsman, code=Sender, subcode=wsse:FailedAuthentication, details= The WS-Management service cannot authenticate the sender.
		/// </summary>
		ERROR_WSMAN_FAILED_AUTHENTICATION = 0x80338036,

		/// <summary>
		/// wsman, code=Sender, subcode=WS-Management IncompatibleEPR, details= The WS-Management service does not support the format of the
		/// WS-Addressing Endpoint Reference.
		/// </summary>
		ERROR_WSMAN_INCOMPATIBLE_EPR = 0x80338037,

		/// <summary>
		/// wsman, code=Sender, subcode=WS-Management InvalidBookmark, details= The bookmark in the subscription is invalid. The bookmark may
		/// be expired or corrupted. Issue a new subscription without any bookmarks or locate the correct bookmark.
		/// </summary>
		ERROR_WSMAN_INVALID_BOOKMARK = 0x80338038,

		/// <summary>
		/// wsman, code=Sender, subcode=WS-Management InvalidOptions, details= The WS-Management service cannot process the request because
		/// one or more options are not valid. The option names or values may not be valid or they are used in incorrect combinations.
		/// Retrieve the catalog entry for the resource and determine how to correct the invalid option values.
		/// </summary>
		ERROR_WSMAN_INVALID_OPTIONS = 0x80338039,

		/// <summary>
		/// wsman, code=Sender, subcode=WS-Management InvalidParameter, details= The WS-Management service cannot process the request because
		/// a parameter for the operation is not valid.
		/// </summary>
		ERROR_WSMAN_INVALID_PARAMETER = 0x8033803A,

		/// <summary>
		/// wsman, code=Sender, subcode=WS-Management InvalidResourceURI, details= The WS-Management service cannot process the request. The
		/// resource URI is missing or it has an incorrect format. Check the documentation or use the following command for information on
		/// how to construct a resource URI: "winrm help uris".
		/// </summary>
		ERROR_WSMAN_INVALID_RESOURCE_URI = 0x8033803B,

		/// <summary>
		/// wsman, code=Sender, subcode=WS-Management InvalidSystem, details= The WS-Management service requires a valid System URI to
		/// process the request.
		/// </summary>
		ERROR_WSMAN_INVALID_SYSTEM = 0x8033803C,

		/// <summary>
		/// wsman, code=Sender, subcode=WS-Management InvalidSelectors, details= The WS-Management service cannot process the request because
		/// the selectors for the resource are not valid.
		/// </summary>
		ERROR_WSMAN_INVALID_SELECTORS = 0x8033803D,

		/// <summary>
		/// wsman, code=Sender, subcode=WS-Management MetadaRedirect, details= The requested metadata is not available at the current
		/// address. Retry the request with a new address.
		/// </summary>
		ERROR_WSMAN_METADATA_REDIRECT = 0x8033803E,

		/// <summary>
		/// wsman, code=Sender, subcode=WS-Management QuotaLimit, details= The WS-Management service is busy servicing other requests. Retry later.
		/// </summary>
		ERROR_WSMAN_QUOTA_LIMIT = 0x8033803F,

		/// <summary>
		/// wsman, code=Sender, subcode=WS-Management RenameFailure, details= The WS-Management service cannot rename the resource. The
		/// selectors for the resource are not correct. The resource may exist already, the address may be incorrect, or the resource URI may
		/// be invalid. Change the request and retry.
		/// </summary>
		ERROR_WSMAN_RENAME_FAILURE = 0x80338040,

		/// <summary>
		/// wsman, code=Sender, subcode=WS-Management SchemaValidationError, details= The SOAP XML in the message does not match the
		/// corresponding XML schema definition. Change the XML and retry.
		/// </summary>
		ERROR_WSMAN_SCHEMA_VALIDATION_ERROR = 0x80338041,

		/// <summary>
		/// wsman, code=Sender, subcode=WS-Management UnsupportedFeature, details= The WS-Management service does not support the specified
		/// feature. Remove the unsupported feature from the request and retry.
		/// </summary>
		ERROR_WSMAN_UNSUPPORTED_FEATURE = 0x80338042,

		/// <summary>The WS-Management service cannot process the request because the XML is invalid.</summary>
		ERROR_WSMAN_INVALID_XML = 0x80338043,

		/// <summary>The WS-Management service cannot process the request because the URI contains an unexpected selector.</summary>
		ERROR_WSMAN_INVALID_KEY = 0x80338044,

		/// <summary>The event source is attempting to deliver an event when a delivery is in progress already.</summary>
		ERROR_WSMAN_DELIVER_IN_PROGRESS = 0x80338045,

		/// <summary>The WS-Management service cannot locate the system.</summary>
		ERROR_WSMAN_SYSTEM_NOT_FOUND = 0x80338046,

		/// <summary>The maximum envelope size in the request is too large. Change the maximum envelope size and try the request again.</summary>
		ERROR_WSMAN_MAX_ENVELOPE_SIZE = 0x80338047,

		/// <summary>The response that the WS-Management service computed exceeds the maximum envelope size in the request.</summary>
		ERROR_WSMAN_MAX_ENVELOPE_SIZE_EXCEEDED = 0x80338048,

		/// <summary>The response that the WS-Management service computed exceed the internal limit for envelope size.</summary>
		ERROR_WSMAN_SERVER_ENVELOPE_LIMIT = 0x80338049,

		/// <summary>The WS-Management service cannot process the request because the URI contains too many selectors.</summary>
		ERROR_WSMAN_SELECTOR_LIMIT = 0x8033804A,

		/// <summary>The WS-Management service cannot process the request because it contains too many options.</summary>
		ERROR_WSMAN_OPTION_LIMIT = 0x8033804B,

		/// <summary>
		/// The WS-Management service does not support the character set used in the request. Change the request to use UTF-8 or UTF-16.
		/// </summary>
		ERROR_WSMAN_CHARACTER_SET = 0x8033804C,

		/// <summary>The operation succeeded and cannot be reversed but the result is too large to send.</summary>
		ERROR_WSMAN_UNREPORTABLE_SUCCESS = 0x8033804D,

		/// <summary>The WS-Management service does not support white space in the request XML.</summary>
		ERROR_WSMAN_WHITESPACE = 0x8033804E,

		/// <summary>
		/// The WS-Management service does not support the filter dialect in the request. The filter dialect is the type of filter, such as
		/// XPath or WQL.
		/// </summary>
		ERROR_WSMAN_FILTERING_REQUIRED = 0x8033804F,

		/// <summary>The WS-Management service cannot process the request because it contains a bookmark that is expired.</summary>
		ERROR_WSMAN_BOOKMARK_EXPIRED = 0x80338050,

		/// <summary>
		/// The WS-Management provider does not support the specified option set because mustComply for one of the options is set to true.
		/// Change mustComply for one of the options to false.
		/// </summary>
		ERROR_WSMAN_OPTIONS_NOT_SUPPORTED = 0x80338051,

		/// <summary>The WS-Management service cannot process the request because one or more of the options has an invalid name.</summary>
		ERROR_WSMAN_OPTIONS_INVALID_NAME = 0x80338052,

		/// <summary>The WS-Management service cannot process the request because one or more of the options has an invalid value.</summary>
		ERROR_WSMAN_OPTIONS_INVALID_VALUE = 0x80338053,

		/// <summary>
		/// The WS-Management service cannot process the request. A parameter that is required for the operation is not the correct type.
		/// </summary>
		ERROR_WSMAN_PARAMETER_TYPE_MISMATCH = 0x80338054,

		/// <summary>The WS-Management service cannot process the request. A parameter name is invalid.</summary>
		ERROR_WSMAN_INVALID_PARAMETER_NAME = 0x80338055,

		/// <summary>The WS-Management service cannot process the request because the XML content has invalid values.</summary>
		ERROR_WSMAN_INVALID_XML_VALUES = 0x80338056,

		/// <summary>The WS-Management service cannot process the request because the XML content has missing values.</summary>
		ERROR_WSMAN_INVALID_XML_MISSING_VALUES = 0x80338057,

		/// <summary>
		/// The WS-Management service cannot identify the format of the object passed to a Put or Create method. The XML namespace for the
		/// input XML is invalid. Change the XML namespace for the input XML in the request.
		/// </summary>
		ERROR_WSMAN_INVALID_XML_NAMESPACE = 0x80338058,

		/// <summary>The WS-Management service cannot process the request because an XML fragment in the URI is invalid.</summary>
		ERROR_WSMAN_INVALID_XML_FRAGMENT = 0x80338059,

		/// <summary>The WS-Management service cannot process the request because the request did not contain all required selectors.</summary>
		ERROR_WSMAN_INSUFFCIENT_SELECTORS = 0x8033805A,

		/// <summary>The WS-Management service cannot process the request because the request contained invalid selectors for the resource.</summary>
		ERROR_WSMAN_UNEXPECTED_SELECTORS = 0x8033805B,

		/// <summary>The WS-Management service cannot process the request because a value for a selector is of the wrong type.</summary>
		ERROR_WSMAN_SELECTOR_TYPEMISMATCH = 0x8033805C,

		/// <summary>The WS-Management service cannot process the request because a value for the selector is invalid.</summary>
		ERROR_WSMAN_INVALID_SELECTOR_VALUE = 0x8033805D,

		/// <summary>The WS-Management service cannot process the request because the selectors for the resource are ambiguous.</summary>
		ERROR_WSMAN_AMBIGUOUS_SELECTORS = 0x8033805E,

		/// <summary>The WS-Management service cannot process the request because the request contains duplicate selectors.</summary>
		ERROR_WSMAN_DUPLICATE_SELECTORS = 0x8033805F,

		/// <summary>
		/// The WS-Management service cannot process the request because the request contains invalid selectors for the target resource.
		/// </summary>
		ERROR_WSMAN_INVALID_TARGET_SELECTORS = 0x80338060,

		/// <summary>The WS-Management service cannot process the request because the request contains an invalid URI for the target resource.</summary>
		ERROR_WSMAN_INVALID_TARGET_RESOURCEURI = 0x80338061,

		/// <summary>The WS-Management service cannot process the request because the request contains an invalid target system.</summary>
		ERROR_WSMAN_INVALID_TARGET_SYSTEM = 0x80338062,

		/// <summary>The WS-Management service cannot process a Create request because the target already exists.</summary>
		ERROR_WSMAN_TARGET_ALREADY_EXISTS = 0x80338063,

		/// <summary>The WS-Management service does not support the mode of authorization.</summary>
		ERROR_WSMAN_AUTHORIZATION_MODE_NOT_SUPPORTED = 0x80338064,

		/// <summary>The client does not support acknowledgment.</summary>
		ERROR_WSMAN_ACK_NOT_SUPPORTED = 0x80338065,

		/// <summary>The data source does not support timeouts for the operation.</summary>
		ERROR_WSMAN_OPERATION_TIMEOUT_NOT_SUPPORTED = 0x80338066,

		/// <summary>The WS-Management service does not support the locale.</summary>
		ERROR_WSMAN_LOCALE_NOT_SUPPORTED = 0x80338067,

		/// <summary>The WS-Management service does not support the expiration time.</summary>
		ERROR_WSMAN_EXPIRATION_TIME_NOT_SUPPORTED = 0x80338068,

		/// <summary>The WS-Management service does not retry deliveries.</summary>
		ERROR_WSMAN_DELIVERY_RETRIES_NOT_SUPPORTED = 0x80338069,

		/// <summary>The event source does not support heartbeats.</summary>
		ERROR_WSMAN_HEARTBEATS_NOT_SUPPORTED = 0x8033806A,

		/// <summary>The event source does not support bookmarks.</summary>
		ERROR_WSMAN_BOOKMARKS_NOT_SUPPORTED = 0x8033806B,

		/// <summary>The WS-Management service does not support the configuration for MaxItems.</summary>
		ERROR_WSMAN_MAXITEMS_NOT_SUPPORTED = 0x8033806C,

		/// <summary>The WS-Management service does not support the configuration for MaxTime.</summary>
		ERROR_WSMAN_MAXTIME_NOT_SUPPORTED = 0x8033806D,

		/// <summary>The WS-Management service does not support the value in the configuration for MaxEnvelopeSize.</summary>
		ERROR_WSMAN_MAXENVELOPE_SIZE_NOT_SUPPORTED = 0x8033806E,

		/// <summary>The event source does not support the MaxEnvelopePolicy.</summary>
		ERROR_WSMAN_MAXENVELOPE_POLICY_NOT_SUPPORTED = 0x8033806F,

		/// <summary>The WS-Management service does not support unfiltered enumeration.</summary>
		ERROR_WSMAN_FILTERING_REQUIRED_NOT_SUPPORTED = 0x80338070,

		/// <summary>The WS-Management service does not support insecure addresses.</summary>
		ERROR_WSMAN_INSECURE_ADDRESS_NOT_SUPPORTED = 0x80338071,

		/// <summary>The WS-Management service does not support format mismatch.</summary>
		ERROR_WSMAN_FORMAT_MISMATCH_NOT_SUPPORTED = 0x80338072,

		/// <summary>The WS-Management service does not support the format of the security token.</summary>
		ERROR_WSMAN_FORMAT_SECURITY_TOKEN_NOT_SUPPORTED = 0x80338073,

		/// <summary>The service returned a response that indicates that the method is unsupported.</summary>
		ERROR_WSMAN_BAD_METHOD = 0x80338074,

		/// <summary>The WS-Management service does not support the specified media type.</summary>
		ERROR_WSMAN_UNSUPPORTED_MEDIA = 0x80338075,

		/// <summary>The WS-Management service does not support the addressing mode.</summary>
		ERROR_WSMAN_UNSUPPORTED_ADDRESSING_MODE = 0x80338076,

		/// <summary>The WS-Management service does not support fragment transfer.</summary>
		ERROR_WSMAN_FRAGMENT_TRANSFER_NOT_SUPPORTED = 0x80338077,

		/// <summary>The client sent a request before the enumeration was initialized.</summary>
		ERROR_WSMAN_ENUMERATION_INITIALIZING = 0x80338078,

		/// <summary>The WS-Management service failed to locate the component that can process the request.</summary>
		ERROR_WSMAN_CONNECTOR_GET = 0x80338079,

		/// <summary>A syntax error occurred in the query string for the resource URI.</summary>
		ERROR_WSMAN_URI_QUERY_STRING_SYNTAX_ERROR = 0x8033807A,

		/// <summary>The MAC that is configured is not in the list of enabled DHCP adapters on the computer.</summary>
		ERROR_WSMAN_INEXISTENT_MAC_ADDRESS = 0x8033807B,

		/// <summary>The MAC address that is configured does not have any unicast addresses.</summary>
		ERROR_WSMAN_NO_UNICAST_ADDRESSES = 0x8033807C,

		/// <summary>The WS-Management service cannot find the dynamic IP address on the adapter with the configured MAC address.</summary>
		ERROR_WSMAN_NO_DHCP_ADDRESSES = 0x8033807D,

		/// <summary>The WS-Management service cannot process the request because the envelope size in the request is too small.</summary>
		ERROR_WSMAN_MIN_ENVELOPE_SIZE = 0x8033807E,

		/// <summary>
		/// The WS-Management service cannot process the request. The EndPointReference contains more nested EndPointReferences than
		/// WS-Management supports.
		/// </summary>
		ERROR_WSMAN_EPR_NESTING_EXCEEDED = 0x8033807F,

		/// <summary>The WS-Management service cannot initialize the request.</summary>
		ERROR_WSMAN_REQUEST_INIT_ERROR = 0x80338080,

		/// <summary>The WS-Management service cannot process the request because the timeout header in the request is invalid.</summary>
		ERROR_WSMAN_INVALID_TIMEOUT_HEADER = 0x80338081,

		/// <summary>The WS-Management service cannot find the certificate that was requested.</summary>
		ERROR_WSMAN_CERT_NOT_FOUND = 0x80338082,

		/// <summary>The WS-Management service cannot process the request. The data source failed to return results for the request.</summary>
		ERROR_WSMAN_PLUGIN_FAILED = 0x80338083,

		/// <summary>The enumeration is invalid because previous Pull request failed.</summary>
		ERROR_WSMAN_ENUMERATION_INVALID = 0x80338084,

		/// <summary>The WS-Management service cannot change a mutual configuration.</summary>
		ERROR_WSMAN_CONFIG_CANNOT_CHANGE_MUTUAL = 0x80338085,

		/// <summary>The WS-Management service does not support the specified enumeration mode.</summary>
		ERROR_WSMAN_ENUMERATION_MODE_UNSUPPORTED = 0x80338086,

		/// <summary>
		/// The WS-Management service cannot guarantee that all data is returned in the requested locale as some data sources may not be able
		/// to comply. Resend the remote request with locale as a hint (the SOAP header should have mustUnderstand="false")
		/// </summary>
		ERROR_WSMAN_MUSTUNDERSTAND_ON_LOCALE_UNSUPPORTED = 0x80338087,

		/// <summary>The WSMan group policy configuration is corrupted.</summary>
		ERROR_WSMAN_POLICY_CORRUPTED = 0x80338088,

		/// <summary>
		/// The listener address specified is invalid. The address can be specified in one of the following formats: *,
		/// IP:&lt;ip_address&gt;, MAC:&lt;mac_address&gt;. Change the listener address and try the request again.
		/// </summary>
		ERROR_WSMAN_LISTENER_ADDRESS_INVALID = 0x80338089,

		/// <summary>Cannot change GPO controlled setting.</summary>
		ERROR_WSMAN_CONFIG_CANNOT_CHANGE_GPO_CONTROLLED_SETTING = 0x8033808A,

		/// <summary>The client is attempting to concurrently receive events from a single subscription session.This is not supported.</summary>
		ERROR_WSMAN_EVENTING_CONCURRENT_CLIENT_RECEIVE = 0x8033808B,

		/// <summary>
		/// The source is sending event batches faster than the subscriber can consume. This can happen if acknowledgments are not specified
		/// for the subscription and new events are arriving from the source before the client has consumed them.
		/// </summary>
		ERROR_WSMAN_EVENTING_FAST_SENDER = 0x8033808C,

		/// <summary>The source is sending events in a connection that did not match the security restrictions imposed by the client.</summary>
		ERROR_WSMAN_EVENTING_INSECURE_PUSHSUBSCRIPTION_CONNECTION = 0x8033808D,

		/// <summary>
		/// The WS-Management client cannot process the request. The event source identity does not match the identity of the machine that
		/// the client subscribed to.
		/// </summary>
		ERROR_WSMAN_EVENTING_INVALID_EVENTSOURCE = 0x8033808E,

		/// <summary>The client could not start a valid listener to receive subscription events based on the specified input settings.</summary>
		ERROR_WSMAN_EVENTING_NOMATCHING_LISTENER = 0x8033808F,

		/// <summary>The fragment path dialect is not supported for this resource.</summary>
		ERROR_WSMAN_FRAGMENT_DIALECT_REQUESTED_UNAVAILABLE = 0x80338090,

		/// <summary>Cannot execute the Fragment-Level operation. The fragment path cannot be missing if the fragment dialect is specified.</summary>
		ERROR_WSMAN_MISSING_FRAGMENT_PATH = 0x80338091,

		/// <summary>Cannot execute the Fragment-Level operation because of invalid value for the fragment dialect.</summary>
		ERROR_WSMAN_INVALID_FRAGMENT_DIALECT = 0x80338092,

		/// <summary>
		/// Cannot execute the Fragment-Level operation because the fragment path is invalid. Check the syntax of the fragment path string.
		/// Also check the spelling and the case of the property names in the fragment path string: they have to match the spelling and the
		/// case of the resource properties.
		/// </summary>
		ERROR_WSMAN_INVALID_FRAGMENT_PATH = 0x80338093,

		/// <summary>
		/// wsman, code=Sender, subcode=WS-Management UnsupportedFeature, details= /FormatMismatch The specified batch parameter is
		/// incompatible with the specified event delivery mode. This can happen if batchSettings for a specific mode are passed for a
		/// different mode. For example, batchSettings like "MaxItems" and "MaxLatency" are not compatible with single event push mode or
		/// pull mode.
		/// </summary>
		ERROR_WSMAN_EVENTING_INCOMPATIBLE_BATCHPARAMS_AND_DELIVERYMODE = 0x80338094,

		/// <summary>
		/// wsman, code=Sender, subcode=WS-Eventing EventSourceUnableToProcess, details= /UnusableAddress The connectivity test from the push
		/// subscription source to the client failed. This can happen if the client machine initiating the push subscription is unreachable
		/// from the server machine where the event source is located. Possible reasons include firewall or some other network boundary.
		/// Modify subscription to use Pull based subscription.
		/// </summary>
		ERROR_WSMAN_EVENTING_LOOPBACK_TESTFAILED = 0x80338095,

		/// <summary>
		/// wsman, code=Sender, subcode=WS-Management UnsupportedFeature, details= /AddressingMode The subscribe packet had an EndTo element
		/// address that does not match the NotifyTo element address or it was invalid. For subscription the EndTo element need not be
		/// present in the subscription request. If it exists then it's address should match the address specified in NotifyTo element.
		/// </summary>
		ERROR_WSMAN_EVENTING_INVALID_ENDTO_ADDRESSS = 0x80338096,

		/// <summary>
		/// The event source sent an event packet whose header could not be processed by the client. This can happen if it was malformed or
		/// if the header had a mustUnderstand attribute that could not be understood by the client.
		/// </summary>
		ERROR_WSMAN_EVENTING_INVALID_INCOMING_EVENT_PACKET_HEADER = 0x80338097,

		/// <summary>
		/// An operation is being attempted on a session that is being closed.This can happen if the session that is being used is also being
		/// closed by another thread.
		/// </summary>
		ERROR_WSMAN_SESSION_ALREADY_CLOSED = 0x80338098,

		/// <summary>
		/// The listener on which the subscription session was established is no longer valid. This can happen if the WSMAN service listener
		/// configuration has been changed and a subscription was already active and using one of the configurations that was deleted.
		/// </summary>
		ERROR_WSMAN_SUBSCRIPTION_LISTENER_NOLONGERVALID = 0x80338099,

		/// <summary>The system failed to load the plugin.</summary>
		ERROR_WSMAN_PROVIDER_LOAD_FAILED = 0x8033809A,

		/// <summary>
		/// wse, code=Receiver, subcode=WS Eventing SourceShuttingDown, details=, The WS-Management service on the remote machine with which
		/// this subscription had been set up has requested that the subscription be closed. This can happen if the WS-Management service on
		/// the remote machine was being shutdown. To correct this problem restart the WS-Management service on the remote machine and
		/// re-create the subscription.
		/// </summary>
		ERROR_WSMAN_EVENTING_SUBSCRIPTIONCLOSED_BYREMOTESERVICE = 0x8033809B,

		/// <summary>
		/// wse, code=Receiver, subcode=WS Eventing DeliveryFailure, details=, The event source was unable to deliver events to the
		/// client.This can happen due to network issues preventing the source from connecting to the client.
		/// </summary>
		ERROR_WSMAN_EVENTING_DELIVERYFAILED_FROMSOURCE = 0x8033809C,

		/// <summary>An unknown security error occurred.</summary>
		ERROR_WSMAN_SECURITY_UNMAPPED = 0x8033809D,

		/// <summary>wse, code=Receiver, subcode=WS Eventing SourceCancelling, details=, The event source cancelled the subscription session.</summary>
		ERROR_WSMAN_EVENTING_SUBSCRIPTION_CANCELLED_BYSOURCE = 0x8033809E,

		/// <summary>TrustedHosts list contains an invalid hostname or hostname pattern.</summary>
		ERROR_WSMAN_INVALID_HOSTNAME_PATTERN = 0x8033809F,

		/// <summary>
		/// wsman, code=Sender, subcode=WS-Management UnsupportedFeature, details= /AddressingMode The subscribe packet does not have
		/// NotifyTo element in the delivery section.
		/// </summary>
		ERROR_WSMAN_EVENTING_MISSING_NOTIFYTO = 0x803380A0,

		/// <summary>
		/// wsman, code=Sender, subcode=WS-Management UnsupportedFeature, details= /AddressingMode The subscribe packet does not have Address
		/// element in the NotifyTo section.
		/// </summary>
		ERROR_WSMAN_EVENTING_MISSING_NOTIFYTO_ADDRESSS = 0x803380A1,

		/// <summary>
		/// wsman, code=Sender, subcode=WS-Management UnsupportedFeature, details= /AddressingMode The subscribe packet contains invalid
		/// Address in the NotifyTo section.
		/// </summary>
		ERROR_WSMAN_EVENTING_INVALID_NOTIFYTO_ADDRESSS = 0x803380A2,

		/// <summary>
		/// wsman, code=Sender, subcode=WS-Management UnsupportedFeature, details= /AddressingMode The subscribe packet contains invalid
		/// Locale value in the delivery section.
		/// </summary>
		ERROR_WSMAN_EVENTING_INVALID_LOCALE_IN_DELIVERY = 0x803380A3,

		/// <summary>
		/// wsman, code=Sender, subcode=WS-Management UnsupportedFeature, details= /AddressingMode The subscribe packet contains invalid
		/// heartbeat value.
		/// </summary>
		ERROR_WSMAN_EVENTING_INVALID_HEARTBEAT = 0x803380A4,

		/// <summary>The WS-Management service cannot process the request. This request is valid only when the -remote option is specified.</summary>
		ERROR_WSMAN_MACHINE_OPTION_REQUIRED = 0x803380A5,

		/// <summary>
		/// wsman, code=Sender, subcode=WS-Management UnsupportedFeature, details=/OptionSet The WS-Management service does not support the
		/// options feature for the specified resource. Remove the options from the request and retry.
		/// </summary>
		ERROR_WSMAN_UNSUPPORTED_FEATURE_OPTIONS = 0x803380A6,

		/// <summary>
		/// wsman, code=Sender, subcode=WS-Management UnsupportedFeature, details= /AddressingMode The subscribe packet contains batch size
		/// value which is smaller than supported value.
		/// </summary>
		ERROR_WSMAN_BATCHSIZE_TOO_SMALL = 0x803380A7,

		/// <summary>
		/// wse, code=Sender, subcode=WS-Eventing DeliveryModeRequestedUnavailable, details=List of delivery modes that are supported The
		/// WS-Management service cannot process the subscribe request. The delivery mode is either invalid or missing.
		/// </summary>
		ERROR_WSMAN_EVENTING_DELIVERY_MODE_REQUESTED_INVALID = 0x803380A8,

		/// <summary>The WS-Management service cannot process the request. The provider method was not found.</summary>
		ERROR_WSMAN_PROVSYS_NOT_SUPPORTED = 0x803380A9,

		/// <summary>
		/// The WinRM client could not create a push subscription because there are no listeners configured that match the specified hostname
		/// and transport, or because there is no enabled firewall exception on the port used by the selected listener. Change the hostname
		/// and transport, create an appropriate firewall exception, or run winrm quickconfig.
		/// </summary>
		ERROR_WSMAN_PUSH_SUBSCRIPTION_CONFIG_INVALID = 0x803380AA,

		/// <summary>
		/// The WinRM client could not process the request because credentials were specified along with the 'no authentication' flag. No
		/// user name, password or client certificate should be specified with the 'no authentication' option.
		/// </summary>
		ERROR_WSMAN_CREDS_PASSED_WITH_NO_AUTH_FLAG = 0x803380AB,

		/// <summary>
		/// The WinRM client cannot process the request. An invalid flag was specified for this request. Remove or change the invalid flag
		/// and try the request again.
		/// </summary>
		ERROR_WSMAN_CLIENT_INVALID_FLAG = 0x803380AC,

		/// <summary>
		/// The WinRM client cannot process the request. The request must specify only one authentication mechanism. If the No Authentication
		/// flag is set, no authentication mechanism should be specified. Change the request to specify only one authentication mechanism or
		/// 'no authentication' and try again.
		/// </summary>
		ERROR_WSMAN_CLIENT_MULTIPLE_AUTH_FLAGS = 0x803380AD,

		/// <summary>
		/// The WinRM client cannot process the request. The SPN Server Port can only be used when the authentication mechanism is Negotiate
		/// or Kerberos. Remove the SPN Server Port or change the authentication mechanism and try the request again.
		/// </summary>
		ERROR_WSMAN_CLIENT_SPN_WRONG_AUTH = 0x803380AE,

		/// <summary>
		/// The WinRM client cannot process the request. The request must not include credentials when using a smart card or default
		/// certificate. Remove the credentials or change the authentication mechanism and try the request again.
		/// </summary>
		ERROR_WSMAN_CLIENT_CERT_UNNEEDED_CREDS = 0x803380AF,

		/// <summary>
		/// The WinRM client cannot process the request. Requests must include user name and password when Basic or Digest authentication
		/// mechanism is used. Add the user name and password or change the authentication mechanism and try the request again.
		/// </summary>
		ERROR_WSMAN_CLIENT_USERNAME_PASSWORD_NEEDED = 0x803380B0,

		/// <summary>
		/// The WinRM client cannot process the request. Requests must not include user name and password when a certificate is used for
		/// authentication. Remove the user name and password or change the authentication mechanism and try the request again.
		/// </summary>
		ERROR_WSMAN_CLIENT_CERT_UNNEEDED_USERNAME = 0x803380B1,

		/// <summary>
		/// The WinRM client cannot process the request. Requests must include credentials if they specify the following flag:
		/// WSManFlagCredUsernamePassword. Add the credentials or remove the WSManFlagCredUsernamePassword flag and try the request again.
		/// </summary>
		ERROR_WSMAN_CLIENT_CREDENTIALS_NEEDED = 0x803380B2,

		/// <summary>
		/// The WinRM client cannot process the request. Requests with credentials must include the following flag:
		/// WSManFlagCredUsernamePassword. Add the flag or remove the credentials and try the request again.
		/// </summary>
		ERROR_WSMAN_CLIENT_CREDENTIALS_FLAG_NEEDED = 0x803380B3,

		/// <summary>
		/// The WinRM client cannot process the request. Requests must include the certificate thumbprint when a certificate is used for
		/// authentication. Change the request to include the certificate thumbprint and try again.
		/// </summary>
		ERROR_WSMAN_CLIENT_CERT_NEEDED = 0x803380B4,

		/// <summary>
		/// The WinRM client cannot process the request. Requests must include the type of certificate to use for authentication. Change the
		/// request to include the type of the certificate and try again.
		/// </summary>
		ERROR_WSMAN_CLIENT_CERT_UNKNOWN_TYPE = 0x803380B5,

		/// <summary>
		/// The WinRM client cannot process the request. Requests must include the location (machine or user certificate store) of the
		/// certificate used for authentication. Change the request to include the location of the certificate and try again.
		/// </summary>
		ERROR_WSMAN_CLIENT_CERT_UNKNOWN_LOCATION = 0x803380B6,

		/// <summary>
		/// The WinRM client cannot process the request. The certificate structure was incomplete. Change the certificate structure and try
		/// the request again.
		/// </summary>
		ERROR_WSMAN_CLIENT_INVALID_CERT = 0x803380B7,

		/// <summary>
		/// The WinRM client cannot process the request. Credentials must not be provided for local requests. Remove the credentials and try
		/// the request again.
		/// </summary>
		ERROR_WSMAN_CLIENT_LOCAL_INVALID_CREDS = 0x803380B8,

		/// <summary>
		/// The WinRM client cannot process the request. Connection options must not be provided for local requests. Remove the connection
		/// options and try the request again.
		/// </summary>
		ERROR_WSMAN_CLIENT_LOCAL_INVALID_CONNECTION_OPTIONS = 0x803380B9,

		/// <summary>
		/// The WinRM client cannot process the request. One of the parameters required for the WSManCreateSession function is null or zero.
		/// Change the request to include the missing parameter and try again.
		/// </summary>
		ERROR_WSMAN_CLIENT_CREATESESSION_NULL_PARAM = 0x803380BA,

		/// <summary>
		/// The WinRM client cannot process the request. One of the parameters required for the WSManEnumerate function is null or zero.
		/// Change the request to include the missing parameter and try again.
		/// </summary>
		ERROR_WSMAN_CLIENT_ENUMERATE_NULL_PARAM = 0x803380BB,

		/// <summary>
		/// The WinRM client cannot process the request. One of the parameters required for the WSManSubscribe function is null or zero.
		/// Change the request to include the missing parameter and try again.
		/// </summary>
		ERROR_WSMAN_CLIENT_SUBSCRIBE_NULL_PARAM = 0x803380BC,

		/// <summary>
		/// The WinRM client cannot process the request. The parameter that should contain the result of the request is null. Change the
		/// request to include the missing parameter and try again.
		/// </summary>
		ERROR_WSMAN_CLIENT_NULL_RESULT_PARAM = 0x803380BD,

		/// <summary>
		/// The WinRM client cannot process the request. The request is missing the session or enumeration handle. Change the request to
		/// include the missing parameter and try again.
		/// </summary>
		ERROR_WSMAN_CLIENT_NO_HANDLE = 0x803380BE,

		/// <summary>
		/// The WinRM client cannot process the request. The resource URI must not be "" (blank or empty string) or NULL. Change the resource
		/// URI and try the request again.
		/// </summary>
		ERROR_WSMAN_CLIENT_BLANK_URI = 0x803380BF,

		/// <summary>
		/// The WinRM client cannot process the request. The resource locator was invalid. Change the resource locator and try the request again.
		/// </summary>
		ERROR_WSMAN_CLIENT_INVALID_RESOURCE_LOCATOR = 0x803380C0,

		/// <summary>
		/// The WinRM client cannot process the request. The input XML must not be "" (blank or empty string) or NULL. Change the input XML
		/// and try the request again.
		/// </summary>
		ERROR_WSMAN_CLIENT_BLANK_INPUT_XML = 0x803380C1,

		/// <summary>
		/// The WinRM client cannot process the request. The maximum number of elements to be retrieved in a batch is too small. Change the
		/// value for the maximum number of elements in a batch and try the request again.
		/// </summary>
		ERROR_WSMAN_CLIENT_BATCH_ITEMS_TOO_SMALL = 0x803380C2,

		/// <summary>
		/// The WinRM client cannot process the request. The maximum number of characters to be retrieved in a batch is too small. Change the
		/// value for the maximum number of characters in a batch and try the request again.
		/// </summary>
		ERROR_WSMAN_CLIENT_MAX_CHARS_TOO_SMALL = 0x803380C3,

		/// <summary>
		/// The WinRM client cannot process the request. The action URI must not be "" (blank or empty string) or NULL. Change the action URI
		/// and try the request again.
		/// </summary>
		ERROR_WSMAN_CLIENT_BLANK_ACTION_URI = 0x803380C4,

		/// <summary>
		/// The WinRM client cannot process the request. The heartbeat interval must be greater than 0. Change the heartbeat interval and try
		/// the request again.
		/// </summary>
		ERROR_WSMAN_CLIENT_ZERO_HEARTBEAT = 0x803380C5,

		/// <summary>
		/// The WinRM client cannot process the request. The request must contain one and only one delivery mode. Change the request to
		/// contain only one delivery mode and try again.
		/// </summary>
		ERROR_WSMAN_CLIENT_MULTIPLE_DELIVERY_MODES = 0x803380C6,

		/// <summary>
		/// The WinRM client cannot process the request. The request contained multiple settings for the policy regarding the maximum
		/// envelope size. Change the request to contain only one setting for the policy and try again.
		/// </summary>
		ERROR_WSMAN_CLIENT_MULTIPLE_ENVELOPE_POLICIES = 0x803380C7,

		/// <summary>
		/// The WinRM client cannot process the request. The request contained an expiration time, but did not specify if it was absolute or
		/// relative. Change the request to specify the type of the expiration time (absolute or relative) and try again.
		/// </summary>
		ERROR_WSMAN_CLIENT_UNKNOWN_EXPIRATION_TYPE = 0x803380C8,

		/// <summary>
		/// The WinRM client cannot process the request. The request specified the type of the expiration time (absolute or relative) but it
		/// did not contain an expiration time. Change the request to include the expiration time and try again.
		/// </summary>
		ERROR_WSMAN_CLIENT_MISSING_EXPIRATION = 0x803380C9,

		/// <summary>
		/// The WinRM client cannot process the request. The pull subscription request contained flags related to a push subscription. Change
		/// the flags and try the request again.
		/// </summary>
		ERROR_WSMAN_CLIENT_PULL_INVALID_FLAGS = 0x803380CA,

		/// <summary>
		/// The WinRM client cannot process the request because the push subscription request contained an unsupported delivery transport.
		/// HTTP and HTTPS are the only currently supported transports. Change the delivery transport and try the request again.
		/// </summary>
		ERROR_WSMAN_CLIENT_PUSH_UNSUPPORTED_TRANSPORT = 0x803380CB,

		/// <summary>
		/// The WinRM client cannot process the request. The delivery address for push subscriptions was too long. Change the delivery
		/// address and try the request again.
		/// </summary>
		ERROR_WSMAN_CLIENT_PUSH_HOST_TOO_LONG = 0x803380CC,

		/// <summary>
		/// The WinRM client cannot process the request. The request contained the compression option but contained an unrecognized value.
		/// Change the value for the compression option and try the request again.
		/// </summary>
		ERROR_WSMAN_CLIENT_COMPRESSION_INVALID_OPTION = 0x803380CD,

		/// <summary>
		/// The WinRM client cannot process the request. One of the parameters required for the WSManDeliverEndSubscriptionNotification
		/// function is null or zero. Change the request to include the missing parameter and try again.
		/// </summary>
		ERROR_WSMAN_CLIENT_DELIVERENDSUBSCRIPTION_NULL_PARAM = 0x803380CE,

		/// <summary>
		/// The WinRM client cannot process the request. One of the parameters required for the WSManDeliverEvents function is null or zero.
		/// Change the request to include the missing parameter and try again.
		/// </summary>
		ERROR_WSMAN_CLIENT_DELIVEREVENTS_NULL_PARAM = 0x803380CF,

		/// <summary>
		/// The WinRM client cannot process the request. One of the parameters required for the WSManGetBookmark function is null or zero.
		/// Change the request to include the missing parameter and try again.
		/// </summary>
		ERROR_WSMAN_CLIENT_GETBOOKMARK_NULL_PARAM = 0x803380D0,

		/// <summary>
		/// The WinRM client cannot process the request. One of the parameters required for the WSManDecodeObject function is null or zero.
		/// Change the request to include the missing parameter and try again.
		/// </summary>
		ERROR_WSMAN_CLIENT_DECODEOBJECT_NULL_PARAM = 0x803380D1,

		/// <summary>
		/// The WinRM client cannot process the request. One of the parameters required for the WSManEncodeObject(Ex) function is null or
		/// zero. Change the request to include the missing parameter and try again.
		/// </summary>
		ERROR_WSMAN_CLIENT_ENCODEOBJECT_NULL_PARAM = 0x803380D2,

		/// <summary>
		/// The WinRM client cannot process the request. One of the parameters required for the WSManEnumeratorAddObject function is null or
		/// zero. Change the request to include the missing parameter and try again.
		/// </summary>
		ERROR_WSMAN_CLIENT_ENUMERATORADDOBJECT_NULL_PARAM = 0x803380D3,

		/// <summary>
		/// The WinRM client cannot process the request. One of the parameters required for the WSManEnumeratorNextObject function is null or
		/// zero. Change the request to include the missing parameter and try again.
		/// </summary>
		ERROR_WSMAN_CLIENT_ENUMERATORNEXTOBJECT_NULL_PARAM = 0x803380D4,

		/// <summary>
		/// The WinRM client cannot process the request. One of the parameters required for the WSManConstructError function is null or zero.
		/// Change the request to include the missing parameter and try again.
		/// </summary>
		ERROR_WSMAN_CLIENT_CONSTRUCTERROR_NULL_PARAM = 0x803380D5,

		/// <summary>
		/// The WinRM service cannot process the request. Push subscriptions are not supported for local session. Change subscription type to
		/// Pull and try again.
		/// </summary>
		ERROR_WSMAN_SERVER_NONPULLSUBSCRIBE_NULL_PARAM = 0x803380D6,

		/// <summary>
		/// The WinRM client cannot process the request. The unencrypted flag only applies to the HTTP transport. Remove the unencrypted flag
		/// or change the transport and try again the request.
		/// </summary>
		ERROR_WSMAN_CLIENT_UNENCRYPTED_HTTP_ONLY = 0x803380D7,

		/// <summary>
		/// The WinRM client cannot process the request. Certificate parameters are not valid when the HTTP transport is also specified.
		/// Remove the certificate parameters or change the transport and try again the request.
		/// </summary>
		ERROR_WSMAN_CANNOT_USE_CERTIFICATES_FOR_HTTP = 0x803380D8,

		/// <summary>
		/// The WinRM client cannot process the request. The connection string should be of the form
		/// [&lt;transport&gt;://]&lt;host&gt;[:&lt;port&gt;][/&lt;suffix&gt;] where transport is one of "http" or "https". Transport, port
		/// and suffix are optional. The host may be a hostname or an IP address. For IPv6 addresses, enclose the address in brackets - e.g.
		/// "http://[1::2]:80/wsman". Change the connection string and try the request again.
		/// </summary>
		ERROR_WSMAN_CONNECTIONSTR_INVALID = 0x803380D9,

		/// <summary>
		/// The WinRM client cannot process the request. The connection string contains an unsupported transport. Valid transports are "http"
		/// or "https". Change the connection string and try the request again.
		/// </summary>
		ERROR_WSMAN_TRANSPORT_NOT_SUPPORTED = 0x803380DA,

		/// <summary>
		/// The WinRM client cannot process the request because the port specified in the connection string is not valid. Verify the port and
		/// retry the request. Valid values are between 1 and 65535. Change the value for port and try the request again.
		/// </summary>
		ERROR_WSMAN_PORT_INVALID = 0x803380DB,

		/// <summary>
		/// The WinRM client cannot process the request. The port specified in the configuration is invalid. Valid values are between 1 and
		/// 65535. Change the value for port and try the request again.
		/// </summary>
		ERROR_WSMAN_CONFIG_PORT_INVALID = 0x803380DC,

		/// <summary>
		/// The WinRM service cannot process the request. WSMAN_FLAG_SEND_HEARTBEAT flag requires the event enumerator to be empty. Change
		/// the flag or change the event enumerator and try the request again.
		/// </summary>
		ERROR_WSMAN_SENDHEARBEAT_EMPTY_ENUMERATOR = 0x803380DD,

		/// <summary>
		/// The WinRM client cannot process the request. Unencrypted traffic is currently disabled in the client configuration. Change the
		/// client configuration and try the request again.
		/// </summary>
		ERROR_WSMAN_CLIENT_UNENCRYPTED_DISABLED = 0x803380DE,

		/// <summary>
		/// The WinRM client cannot process the request. Basic authentication is currently disabled in the client configuration. Change the
		/// client configuration and try the request again.
		/// </summary>
		ERROR_WSMAN_CLIENT_BASIC_AUTHENTICATION_DISABLED = 0x803380DF,

		/// <summary>
		/// The WinRM client cannot process the request. Digest authentication is currently disabled in the client configuration. Change the
		/// client configuration and try the request again.
		/// </summary>
		ERROR_WSMAN_CLIENT_DIGEST_AUTHENTICATION_DISABLED = 0x803380E0,

		/// <summary>
		/// The WinRM client cannot process the request. Negotiate authentication is currently disabled in the client configuration. Change
		/// the client configuration and try the request again. If this is a request for the local configuration, use one of the enabled
		/// authentication mechanisms still enabled. To use Kerberos, specify the local computer name as the remote destination. To use
		/// Basic, specify the local computer name as the remote destination, specify Basic authentication and provide user name and password.
		/// </summary>
		ERROR_WSMAN_CLIENT_NEGOTIATE_AUTHENTICATION_DISABLED = 0x803380E1,

		/// <summary>
		/// The WinRM client cannot process the request. Kerberos authentication is currently disabled in the client configuration. Change
		/// the client configuration and try the request again.
		/// </summary>
		ERROR_WSMAN_CLIENT_KERBEROS_AUTHENTICATION_DISABLED = 0x803380E2,

		/// <summary>
		/// The WinRM client cannot process the request. Certificate authentication is currently disabled in the client configuration. Change
		/// the client configuration and try the request again.
		/// </summary>
		ERROR_WSMAN_CLIENT_CERTIFICATES_AUTHENTICATION_DISABLED = 0x803380E3,

		/// <summary>
		/// The WinRM client cannot process the request. If the authentication scheme is different from Kerberos, or if the client computer
		/// is not joined to a domain, then HTTPS transport must be used or the destination machine must be added to the TrustedHosts
		/// configuration setting. Use winrm.cmd to configure TrustedHosts. Note that computers in the TrustedHosts list might not be
		/// authenticated. You can get more information about that by running the following command: winrm help config.
		/// </summary>
		ERROR_WSMAN_SERVER_NOT_TRUSTED = 0x803380E4,

		/// <summary>
		/// The WinRM client cannot process the request. Default credentials with Negotiate over HTTP can be used only if the target machine
		/// is part of the TrustedHosts list or the Allow implicit credentials for Negotiate option is specified.
		/// </summary>
		ERROR_WSMAN_EXPLICIT_CREDENTIALS_REQUIRED = 0x803380E5,

		/// <summary>
		/// The WinRM client cannot process the request. The CertificateThumbprint property must be empty when the SSL configuration will be
		/// shared with another service.
		/// </summary>
		ERROR_WSMAN_CERT_THUMBPRINT_NOT_BLANK = 0x803380E6,

		/// <summary>
		/// The WinRM client cannot process the request. The CertificateThumbprint property must not be "" (blank or empty string) or NULL.
		/// </summary>
		ERROR_WSMAN_CERT_THUMBPRINT_BLANK = 0x803380E7,

		/// <summary>
		/// The WinRM client cannot process the request. The WinRM client tried to create an SSL configuration for a pair of IP address and
		/// port according to the request, but the SSL configuration for that pair is owned by another service and cannot be shared. Use a
		/// different IP address and port combination and try the request again.
		/// </summary>
		ERROR_WSMAN_CONFIG_CANNOT_SHARE_SSL_CONFIG = 0x803380E8,

		/// <summary>The WinRM client cannot process the request. The certificate CN and the hostname that were provided do not match.</summary>
		ERROR_WSMAN_CONFIG_CERT_CN_DOES_NOT_MATCH_HOSTNAME = 0x803380E9,

		/// <summary>Not used</summary>
		ERROR_WSMAN_CONFIG_HOSTNAME_CHANGE_WITHOUT_CERT = 0x803380EA,

		/// <summary>
		/// The WinRM client cannot process the request. When HTTP is the transport, the Certificate thumbprint must be blank. HTTP does not
		/// use the Certificate thumbprint.
		/// </summary>
		ERROR_WSMAN_CONFIG_THUMBPRINT_SHOULD_BE_EMPTY = 0x803380EB,

		/// <summary>
		/// The WinRM client cannot process the request. The IP Filter is invalid. Ranges are specified using the syntax IP1-IP2. Multiple
		/// ranges are separated using , as delimiter. * is used to indicate that the service should listen on all available IPs on the
		/// machine. When * is used, other ranges in the filter are ignored. If filter is blank, the service doesn't listen on any address.
		/// For example, if service should be restricted to listen on only IPv4 addresses, IPv6 filter should be left empty. %nExample IPv4
		/// filters: 2.0.0.1-2.0.0.20, 24.0.0.1-24.0.0.22 %n Example IPv6 filters: 3FFE:FFFF:7654:FEDA:1245:BA98:0000:0000-3FFE:FFFF:7654:FEDA:1245:BA98:3210:4562
		/// </summary>
		ERROR_WSMAN_INVALID_IPFILTER = 0x803380EC,

		/// <summary>
		/// The WinRM client cannot process the request. The input XML modifies selectors or keys for the instance. You cannot create a new
		/// instance or change the identity of an instance by changing the keys. Change the input XML and try the request again.
		/// </summary>
		ERROR_WSMAN_CANNOT_CHANGE_KEYS = 0x803380ED,

		/// <summary>
		/// The WinRM client cannot process the request. The Enhanced Key Usage (EKU) field of the certificate is not set to "Server
		/// Authentication". Retry the request with a certificate that has the correct EKU.
		/// </summary>
		ERROR_WSMAN_CERT_INVALID_USAGE = 0x803380EE,

		/// <summary>The WinRM client cannot process the request. The response from the destination computer does not include any results.</summary>
		ERROR_WSMAN_RESPONSE_NO_RESULTS = 0x803380EF,

		/// <summary>
		/// The WinRM client cannot process the request. The response to a create request did not contain a valid end point reference. The
		/// ResourceCreated element was not found or did not contain valid content.
		/// </summary>
		ERROR_WSMAN_CREATE_RESPONSE_NO_EPR = 0x803380F0,

		/// <summary>
		/// The WinRM client cannot process the request. The response from the destination computer does not contain a valid SOAP enumeration context.
		/// </summary>
		ERROR_WSMAN_RESPONSE_INVALID_ENUMERATION_CONTEXT = 0x803380F1,

		/// <summary>
		/// The WinRM client cannot process the request. The response from the destination computer contains a WS-Management FragmentTransfer
		/// header but the content of the body is not wrapped by the WS-Management XmlFragment wrapper.
		/// </summary>
		ERROR_WSMAN_RESPONSE_NO_XML_FRAGMENT_WRAPPER = 0x803380F2,

		/// <summary>
		/// The WinRM client cannot process the request. The response from the destination computer contains one or more invalid SOAP headers.
		/// </summary>
		ERROR_WSMAN_RESPONSE_INVALID_MESSAGE_INFORMATION_HEADER = 0x803380F3,

		/// <summary>
		/// The WinRM client cannot process the request. It cannot find any SOAP Headers or Body elements in the response from the
		/// destination computer.
		/// </summary>
		ERROR_WSMAN_RESPONSE_NO_SOAP_HEADER_BODY = 0x803380F4,

		/// <summary>The WinRM client cannot process the request. The destination computer returned an empty response to the request.</summary>
		ERROR_WSMAN_HTTP_NO_RESPONSE_DATA = 0x803380F5,

		/// <summary>The WinRM client cannot process the request. The destination computer returned an invalid SOAP fault.</summary>
		ERROR_WSMAN_RESPONSE_INVALID_SOAP_FAULT = 0x803380F6,

		/// <summary>
		/// The WinRM client cannot process the request. It cannot determine the content type of the HTTP response from the destination
		/// computer. The content type is absent or invalid.
		/// </summary>
		ERROR_WSMAN_HTTP_INVALID_CONTENT_TYPE_IN_RESPONSE_DATA = 0x803380F7,

		/// <summary>
		/// The WinRM client cannot process the request. The HTTP response from the destination computer was not in the same format as the
		/// request. A Unicode request packet may have been sent and an ANSI packet received.
		/// </summary>
		ERROR_WSMAN_HTTP_CONTENT_TYPE_MISSMATCH_RESPONSE_DATA = 0x803380F8,

		/// <summary>
		/// The WinRM client cannot process the request. The encrypted message body has an invalid format and cannot be decrypted. Ensure
		/// that the service is encrypting the message body according to the specifications.
		/// </summary>
		ERROR_WSMAN_CANNOT_DECRYPT = 0x803380F9,

		/// <summary>
		/// The WinRM client cannot process the request. The resource URI is not valid: it does not contain keys, but the class selected is
		/// not a singleton. To access an instance which is not a singleton, keys must be provided. Use the following command to get more
		/// information in how to construct a resource URI: "winrm help uris".
		/// </summary>
		ERROR_WSMAN_INVALID_URI_WMI_SINGLETON = 0x803380FA,

		/// <summary>
		/// The WinRM client cannot process the request. The resource URI for an enumeration operation with WQL filter must not contain keys
		/// and the class name must be '*' (star). Use the following command to get more information in how to construct a resource URI:
		/// "winrm help uris".
		/// </summary>
		ERROR_WSMAN_INVALID_URI_WMI_ENUM_WQL = 0x803380FB,

		/// <summary>The WS-Management identification operation is only available on remote sessions.</summary>
		ERROR_WSMAN_NO_IDENTIFY_FOR_LOCAL_SESSION = 0x803380FC,

		/// <summary>Subscribe operation with Push delivery mode is only available on remote sessions.</summary>
		ERROR_WSMAN_NO_PUSH_SUBSCRIPTION_FOR_LOCAL_SESSION = 0x803380FD,

		/// <summary>
		/// The subscription manager address is invalid. The response was not received from the address to which the subscription request was sent.
		/// </summary>
		ERROR_WSMAN_INVALID_SUBSCRIPTION_MANAGER = 0x803380FE,

		/// <summary>Only subscriptions with Pull delivery mode are supported by the plugin.</summary>
		ERROR_WSMAN_NON_PULL_SUBSCRIPTION_NOT_SUPPORTED = 0x803380FF,

		/// <summary>WinRM cannot process the request because the WMI object contains too many levels of nested embedded objects.</summary>
		ERROR_WSMAN_WMI_MAX_NESTED = 0x80338100,

		/// <summary>
		/// The WS-Management service cannot process the request. It does not support retrieving a WMI object that contains a property of
		/// type CIM_REFERENCE and the value of that property contains a remote machine name.
		/// </summary>
		ERROR_WSMAN_REMOTE_CIMPATH_NOT_SUPPORTED = 0x80338101,

		/// <summary>
		/// The WS-Management service cannot process the request. The WMI service reported that the WMI provider could not perform the
		/// requested operation.
		/// </summary>
		ERROR_WSMAN_WMI_PROVIDER_NOT_CAPABLE = 0x80338102,

		/// <summary>
		/// The WS-Management service cannot process the request. A value retrieved from the WMI service or the WMI provider is invalid.
		/// </summary>
		ERROR_WSMAN_WMI_INVALID_VALUE = 0x80338103,

		/// <summary>The WS-Management service cannot process the request. The WMI service returned an 'access denied' error.</summary>
		ERROR_WSMAN_WMI_SVC_ACCESS_DENIED = 0x80338104,

		/// <summary>The WS-Management service cannot process the request. The WMI provider returned an 'access denied' error.</summary>
		ERROR_WSMAN_WMI_PROVIDER_ACCESS_DENIED = 0x80338105,

		/// <summary>
		/// The WS-Management service cannot process the request. An 'access denied' error was received when connecting to the WMI service on
		/// the computer specified.
		/// </summary>
		ERROR_WSMAN_WMI_CANNOT_CONNECT_ACCESS_DENIED = 0x80338106,

		/// <summary>The WS-Management service cannot process the request because the filter XML is invalid.</summary>
		ERROR_WSMAN_INVALID_FILTER_XML = 0x80338107,

		/// <summary>
		/// The WS-Management service cannot process the request. The resource URI for an Enumerate operation must not contain keys.
		/// </summary>
		ERROR_WSMAN_ENUMERATE_WMI_INVALID_KEY = 0x80338108,

		/// <summary>
		/// Cannot execute the Fragment-Level operation because the fragment path contains either "" (blank or empty string) or NULL. Change
		/// the value of the fragment path and try the request again.
		/// </summary>
		ERROR_WSMAN_INVALID_FRAGMENT_PATH_BLANK = 0x80338109,

		/// <summary>
		/// The WinRM client cannot process the request. The response received from the destination machine contains invalid characters and
		/// cannot be processed.
		/// </summary>
		ERROR_WSMAN_INVALID_CHARACTERS_IN_RESPONSE = 0x8033810A,

		/// <summary>
		/// The WinRM client cannot process the request. Kerberos authentication cannot be used when the destination is an IP address.
		/// Specify a DNS or NetBIOS destination or specify Basic or Negotiate authentication.
		/// </summary>
		ERROR_WSMAN_KERBEROS_IPADDRESS = 0x8033810B,

		/// <summary>
		/// The WinRM client cannot process the request. Kerberos authentication cannot be used with implicit credentials if the client
		/// computer is not joined to a domain. Use explicit credentials or specify a different authentication mechanism than Kerberos.
		/// </summary>
		ERROR_WSMAN_CLIENT_WORKGROUP_NO_KERBEROS = 0x8033810C,

		/// <summary>The WinRM client cannot process the request. The batch settings parameter is invalid.</summary>
		ERROR_WSMAN_INVALID_BATCH_SETTINGS_PARAMETER = 0x8033810D,

		/// <summary>
		/// The WinRM client cannot process the request. If you do not specify an authentication mechanism or you specify Kerberos, then you
		/// cannot use "localhost" or "127.0.0.1" or "[::1]" for the remote host name. You can explicitly specify a different authentication
		/// mechanism than Kerberos or specify the remote host as a DNS name or NetBIOS name.
		/// </summary>
		ERROR_WSMAN_SERVER_DESTINATION_LOCALHOST = 0x8033810E,

		/// <summary>The WinRM client received an unknown HTTP status code from the remote WS-Management service.</summary>
		ERROR_WSMAN_UNKNOWN_HTTP_STATUS_RETURNED = 0x8033810F,

		/// <summary>
		/// This error message is deprecated The WinRM client received a HTTP redirect status code from the remote WS-Management service.
		/// WinRM does not support redirects.
		/// </summary>
		ERROR_WSMAN_UNSUPPORTED_HTTP_STATUS_REDIRECT = 0x80338110,

		/// <summary>
		/// The WinRM client sent a request to the remote WS-Management service and was notified that the request size exceeded the
		/// configured MaxEnvelopeSize quota.
		/// </summary>
		ERROR_WSMAN_HTTP_REQUEST_TOO_LARGE_STATUS = 0x80338111,

		/// <summary>
		/// The connection to the specified remote host was refused. Verify that the WS-Management service is running on the remote host and
		/// configured to listen for requests on the correct port and HTTP URL.
		/// </summary>
		ERROR_WSMAN_HTTP_SERVICE_UNAVAILABLE_STATUS = 0x80338112,

		/// <summary>
		/// The WinRM client sent a request to an HTTP server and got a response saying the requested HTTP URL was not available. This is
		/// usually returned by a HTTP server that does not support the WS-Management protocol.
		/// </summary>
		ERROR_WSMAN_HTTP_NOT_FOUND_STATUS = 0x80338113,

		/// <summary>
		/// The subscribe packet had a Locale element with missing lang attribute. The lang attribute is required for the Locale element.
		/// </summary>
		ERROR_WSMAN_EVENTING_MISSING_LOCALE_IN_DELIVERY = 0x80338114,

		/// <summary>
		/// Cannot create a WinRM listener on HTTPS because this machine does not have an appropriate certificate. To be used for SSL, a
		/// certificate must have a CN matching the hostname, be appropriate for Server Authentication, and not be expired, revoked, or self-signed.
		/// </summary>
		ERROR_WSMAN_QUICK_CONFIG_FAILED_CERT_REQUIRED = 0x80338115,

		/// <summary>Firewall does not allow exceptions; WinRM cannot be setup for remote access.</summary>
		ERROR_WSMAN_QUICK_CONFIG_FIREWALL_EXCEPTIONS_DISALLOWED = 0x80338116,

		/// <summary>
		/// The Windows Remote Management (WinRM) service cannot be configured for remote access because Group Policy does not allow local
		/// firewall changes. Check the Group Policy settings to allow local firewall exceptions and add WinRM to the firewall exceptions.
		/// </summary>
		ERROR_WSMAN_QUICK_CONFIG_LOCAL_POLICY_CHANGE_DISALLOWED = 0x80338117,

		/// <summary>
		/// The WinRM client cannot process the request because the selector name is not valid. Change the selector name and retry the request.
		/// </summary>
		ERROR_WSMAN_INVALID_SELECTOR_NAME = 0x80338118,

		/// <summary>The WS-Management service does not support the encoding type specified.</summary>
		ERROR_WSMAN_ENCODING_TYPE = 0x80338119,

		/// <summary>
		/// The WS-Management service cannot process the request because the selector values do not match a known resource, or the resource
		/// is offline. Retry the request later when the resource is online, or try a different selector.
		/// </summary>
		ERROR_WSMAN_ENDPOINT_UNAVAILABLE_INVALID_VALUE = 0x8033811A,

		/// <summary>The WS-Management service cannot process the request because the a header in the request is invalid.</summary>
		ERROR_WSMAN_INVALID_HEADER = 0x8033811B,

		/// <summary>The expiration time specified for enumeration was invalid. Specify the expiration time as a duration.</summary>
		ERROR_WSMAN_ENUMERATE_UNSUPPORTED_EXPIRATION_TYPE = 0x8033811C,

		/// <summary>
		/// The WS-Management service received a request which specified a maximum number of elements, but the service does not support this
		/// feature. Retry the request without this element specified.
		/// </summary>
		ERROR_WSMAN_MAX_ELEMENTS_NOT_SUPPORTED = 0x8033811D,

		/// <summary>The WS-Management service cannot process the request. The WMI provider returned an 'invalid parameter' error.</summary>
		ERROR_WSMAN_WMI_PROVIDER_INVALID_PARAMETER = 0x8033811E,

		/// <summary>
		/// The WinRM client cannot process the request. The request must contain one and only one enumeration mode. Change the request to
		/// contain only one enumeration mode and try again.
		/// </summary>
		ERROR_WSMAN_CLIENT_MULTIPLE_ENUM_MODE_FLAGS = 0x8033811F,

		/// <summary>
		/// The WinRS client cannot process the request. An invalid flag was specified for this request. Remove or change the invalid flag
		/// and try the request again.
		/// </summary>
		ERROR_WINRS_CLIENT_INVALID_FLAG = 0x80338120,

		/// <summary>
		/// The WinRS client cannot process the request. One of the parameters required is null or zero. Change the request to include the
		/// missing parameter and try again.
		/// </summary>
		ERROR_WINRS_CLIENT_NULL_PARAM = 0x80338121,

		/// <summary>
		/// wsman, code=Sender, subcode=WS-Management CannotProcessFilter, details= The data source could not process the filter. The filter
		/// might be missing, invalid or too complex to process. If a service only supports a subset of a filter dialect (such as XPath level
		/// 1), it may return this fault for valid filter expressions outside of the supported subset. Change the filter and try the request again.
		/// </summary>
		ERROR_WSMAN_CANNOT_PROCESS_FILTER = 0x80338122,

		/// <summary>
		/// The WinRM client cannot process the request. One of the parameters required for the WSManEnumeratorAddEvent function is null or
		/// zero. Change the request to include the missing parameter and try again.
		/// </summary>
		ERROR_WSMAN_CLIENT_ENUMERATORADDEVENT_NULL_PARAM = 0x80338123,

		/// <summary>
		/// The WinRM client cannot process the request. The object parameter for the WSManEnumeratorAddObject function is null or zero, but
		/// the enumeration mode is Object or ObjectAndEPR.
		/// </summary>
		ERROR_WSMAN_ADDOBJECT_MISSING_OBJECT = 0x80338124,

		/// <summary>
		/// The WinRM client cannot process the request. The EPR parameter for the WSManEnumeratorAddObject function is null or zero, but the
		/// enumeration mode is EPR or ObjectAndEPR.
		/// </summary>
		ERROR_WSMAN_ADDOBJECT_MISSING_EPR = 0x80338125,

		/// <summary>
		/// Returned by client when get timeout from network layer WinRM cannot complete the operation. Verify that the specified computer
		/// name is valid, that the computer is accessible over the network, and that a firewall exception for the WinRM service is enabled
		/// and allows access from this computer. By default, the WinRM firewall exception for public profiles limits access to remote
		/// computers within the same local subnet.
		/// </summary>
		ERROR_WSMAN_NETWORK_TIMEDOUT = 0x80338126,

		/// <summary>Not used. To be removed.</summary>
		ERROR_WINRS_RECEIVE_IN_PROGRESS = 0x80338127,

		/// <summary>The WinRS client cannot process the Receive request because the shell plugin returned an empty response to the request.</summary>
		ERROR_WINRS_RECEIVE_NO_RESPONSE_DATA = 0x80338128,

		/// <summary>
		/// The WinRM Shell client cannot process the request. One of the parameters required for the WSManCreateShell function is null or
		/// zero. Change the request to include the missing parameter and try again.
		/// </summary>
		ERROR_WINRS_CLIENT_CREATESHELL_NULL_PARAM = 0x80338129,

		/// <summary>
		/// The WinRM Shell client cannot process the request. One of the parameters required for the WinrsCloseShell function is null or
		/// zero. Change the request to include the missing parameter and try again.
		/// </summary>
		ERROR_WINRS_CLIENT_CLOSESHELL_NULL_PARAM = 0x8033812A,

		/// <summary>
		/// The WinRS client cannot process the request. The parameter required for the WinrsFreeCreateShellResult function is null or zero.
		/// Change the request to include the missing parameter and try again.
		/// </summary>
		ERROR_WINRS_CLIENT_FREECREATESHELLRESULT_NULL_PARAM = 0x8033812B,

		/// <summary>
		/// The WinRM Shell client cannot process the request. One of the parameters required for the WSManRunShellCommand function is null
		/// or zero. Change the request to include the missing parameter and try again.
		/// </summary>
		ERROR_WINRS_CLIENT_RUNCOMMAND_NULL_PARAM = 0x8033812C,

		/// <summary>
		/// The WinRS client cannot process the request. The parameter required for the WinrsFreeRunCommandResult function is null or zero.
		/// Change the request to include the missing parameter and try again.
		/// </summary>
		ERROR_WINRS_CLIENT_FREERUNCOMMANDRESULT_NULL_PARAM = 0x8033812D,

		/// <summary>
		/// The WinRM Shell client cannot process the request. One of the parameters required for the WSManSignalShell function is null or
		/// zero. Change the request to include the missing parameter and try again.
		/// </summary>
		ERROR_WINRS_CLIENT_SIGNAL_NULL_PARAM = 0x8033812E,

		/// <summary>
		/// The WinRM Shell client cannot process the request. One of the parameters required for the WSMansReceiveShellOutput function is
		/// null or zero. Change the request to include the missing parameter and try again.
		/// </summary>
		ERROR_WINRS_CLIENT_RECEIVE_NULL_PARAM = 0x8033812F,

		/// <summary>
		/// The WinRS client cannot process the request. The parameter required for the WinrsFreePullResult function is null or zero. Change
		/// the request to include the missing parameter and try again.
		/// </summary>
		ERROR_WINRS_CLIENT_FREEPULLRESULT_NULL_PARAM = 0x80338130,

		/// <summary>
		/// The WinRS client cannot process the request. One of the parameters required for the WinrsPull function is null or zero. Change
		/// the request to include the missing parameter and try again.
		/// </summary>
		ERROR_WINRS_CLIENT_PULL_NULL_PARAM = 0x80338131,

		/// <summary>
		/// The WinRS client cannot process the request. The parameter required for the WinrsCloseReceiveHandle function is null or zero.
		/// Change the request to include the missing parameter and try again.
		/// </summary>
		ERROR_WINRS_CLIENT_CLOSERECEIVEHANDLE_NULL_PARAM = 0x80338132,

		/// <summary>
		/// The WinRM Shell client cannot process the request. One of the parameters required for the WSManSendShellInput function is null or
		/// zero. Change the request to include the missing parameter and try again.
		/// </summary>
		ERROR_WINRS_CLIENT_SEND_NULL_PARAM = 0x80338133,

		/// <summary>
		/// The WinRS client cannot process the request. One of the parameters required for the WinrsPush function is null or zero. Change
		/// the request to include the missing parameter and try again.
		/// </summary>
		ERROR_WINRS_CLIENT_PUSH_NULL_PARAM = 0x80338134,

		/// <summary>
		/// The WinRS client cannot process the request. The parameter required for the WinrsCloseSendHandle function is null or zero. Change
		/// the request to include the missing parameter and try again.
		/// </summary>
		ERROR_WINRS_CLIENT_CLOSESENDHANDLE_NULL_PARAM = 0x80338135,

		/// <summary>
		/// The WinRS client cannot process the request. One of the parameters required for the WinrsGet function is null or zero. Change the
		/// request to include the missing parameter and try again.
		/// </summary>
		ERROR_WINRS_CLIENT_GET_NULL_PARAM = 0x80338136,

		/// <summary>
		/// The WS-Management service does not support the specified polymorphism mode. Try changing the polymorphism mode specified, and try again.
		/// </summary>
		ERROR_WSMAN_POLYMORPHISM_MODE_UNSUPPORTED = 0x80338137,

		/// <summary>
		/// The WS-Management service cannot process the request because the specified URI is not supported on the service side. Retry the
		/// request with local session.
		/// </summary>
		ERROR_WSMAN_REQUEST_NOT_SUPPORTED_AT_SERVICE = 0x80338138,

		/// <summary>
		/// The WS-Management service cannot process the request. A DMTF resource URI was used to access a non-DMTF class. Try again using a
		/// non-DMTF resource URI.
		/// </summary>
		ERROR_WSMAN_URI_NON_DMTF_CLASS = 0x80338139,

		/// <summary>
		/// The WS-Management service cannot process the request. The DMTF class in the repository uses a different major version number from
		/// the requested class. This class can be accessed using a non-DMTF resource URI.
		/// </summary>
		ERROR_WSMAN_URI_WRONG_DMTF_VERSION = 0x8033813A,

		/// <summary>
		/// The WS-Management service cannot process the request. The resource URI and __cimnamespace selector attempted to use different
		/// namespaces. Try removing the __cimnamespace selector or using a DMTF resource URI. If a non-DMTF resource URI is used with a
		/// __cimnamespace selector, the namespaces must match.
		/// </summary>
		ERROR_WSMAN_DIFFERENT_CIM_SELECTOR = 0x8033813B,

		/// <summary>
		/// The WS-Management client cannot process the request. To use the WSManSubscribe API the user has to be running under Network
		/// Service account. No other account is supported currently for push subscriptions.
		/// </summary>
		ERROR_WSMAN_PUSHSUBSCRIPTION_INVALIDUSERACCOUNT = 0x8033813C,

		/// <summary>
		/// The WS-Management client cannot process the request. The event source machine is not joined to a domain. To set up a push
		/// subscription session to an event source the source has to be connected to a domain. To fix this problem either join the event
		/// source machine to a domain or use PULL as the delivery mode for the subscription.
		/// </summary>
		ERROR_WSMAN_EVENTING_NONDOMAINJOINED_PUBLISHER = 0x8033813D,

		/// <summary>
		/// The WS-Management client cannot process the request. The subscriber machine is not joined to a domain. To set up a push
		/// subscription session to an event source, the subscriber machine has to be connected to a domain. To fix this problem either join
		/// the subscriber machine to a domain or use PULL as the delivery mode for the subscription.
		/// </summary>
		ERROR_WSMAN_EVENTING_NONDOMAINJOINED_COLLECTOR = 0x8033813E,

		/// <summary>
		/// The WinRM client cannot process the request because it is trying to update a read-only setting. Remove this setting from the
		/// command and try again.
		/// </summary>
		ERROR_WSMAN_CONFIG_READONLY_PROPERTY = 0x8033813F,

		/// <summary>
		/// The WinRS client cannot process the request. The server cannot set Code Page. You may want to use the CHCP command to change the
		/// client Code Page to 437 and receive the results in English.
		/// </summary>
		ERROR_WINRS_CODE_PAGE_NOT_SUPPORTED = 0x80338140,

		/// <summary>Not used. To be removed.</summary>
		ERROR_WSMAN_CLIENT_DISABLE_LOOPBACK_WITH_EXPLICIT_CREDENTIALS = 0x80338141,

		/// <summary>Not used. To be removed.</summary>
		ERROR_WSMAN_CLIENT_INVALID_DISABLE_LOOPBACK = 0x80338142,

		/// <summary>
		/// The WS-Management client received too many results from the server. The server implementation should never return more items than
		/// are specified by the client.
		/// </summary>
		ERROR_WSMAN_CLIENT_ENUM_RECEIVED_TOO_MANY_ITEMS = 0x80338143,

		/// <summary>
		/// The WinRM client cannot process the request. A certificate thumbprint was specified together with a user name or password. Only
		/// one credentials type can be specified. Remove the credentials type that does not correspond to the intended authentication
		/// mechanism and retry the request.
		/// </summary>
		ERROR_WSMAN_MULTIPLE_CREDENTIALS = 0x80338144,

		/// <summary>
		/// The WinRM client cannot process the request. The flag that specifies the authentication mechanism to use is incorrect. Remove or
		/// change the invalid flag and try the request again.
		/// </summary>
		ERROR_WSMAN_AUTHENTICATION_INVALID_FLAG = 0x80338145,

		/// <summary>
		/// The WinRM client cannot process the request. When an authentication mechanism is not specified, only user name and password
		/// credentials are allowed. If you want to use a different type of credentials then you need to specify the authentication
		/// mechanism. Specify the authentication mechanism or the correct credentials and try the request again.
		/// </summary>
		ERROR_WSMAN_CLIENT_CREDENTIALS_FOR_DEFAULT_AUTHENTICATION = 0x80338146,

		/// <summary>
		/// The WinRM client cannot process the request. For authentication mechanisms that require the credentials of an user account, both
		/// user name and password must be specified. Specify the missing user name or password and try the request again.
		/// </summary>
		ERROR_WSMAN_CLIENT_USERNAME_AND_PASSWORD_NEEDED = 0x80338147,

		/// <summary>
		/// The WinRM client cannot process the request. If you are using a machine certificate, it must contain a DNS name in the Subject
		/// Alternative Name extension or in the Subject Name field, and no UPN name. If you are using a user certificate, the Subject
		/// Alternative Name extension must contain a UPN name and must not contain a DNS name. Change the certificate structure and try the
		/// request again.
		/// </summary>
		ERROR_WSMAN_CLIENT_INVALID_CERT_DNS_OR_UPN = 0x80338148,

		/// <summary>
		/// The WinRM Shell client cannot process the request. One of the environment variable name passed to the WSManCreateShell function
		/// is null or zero. Change the request to include the missing parameter and try again.
		/// </summary>
		ERROR_WSMAN_CREATESHELL_NULL_ENVIRONMENT_VARIABLE_NAME = 0x80338149,

		/// <summary>
		/// An operation is being attempted on a shell that is being closed. This can happen if the shell that is being used is also being
		/// closed by another thread.
		/// </summary>
		ERROR_WSMAN_SHELL_ALREADY_CLOSED = 0x8033814A,

		/// <summary>
		/// The WinRM Shell client cannot process the request. One of the stream id name passed to the WSManCreateShell function is null or
		/// zero. Change the request to include the missing parameter and try again.
		/// </summary>
		ERROR_WSMAN_CREATESHELL_NULL_STREAMID = 0x8033814B,

		/// <summary>
		/// The WinRM Shell client cannot process the request. The shell handle passed to the WSMan Shell function is not valid. The shell
		/// handle is valid only when WSManCreateShell function completes successfully. Change the request including a valid shell handle and
		/// try again.
		/// </summary>
		ERROR_WSMAN_SHELL_INVALID_SHELL_HANDLE = 0x8033814C,

		/// <summary>
		/// The WinRM Shell client cannot process the request. The command handle passed to the WSMan Shell function is not valid. The
		/// command handle is valid only when WSManRunShellCommand function completes successfully. Change the request including a valid
		/// shell handle and try again.
		/// </summary>
		ERROR_WSMAN_SHELL_INVALID_COMMAND_HANDLE = 0x8033814D,

		/// <summary>
		/// The WinRM Shell client cannot process the request. One of the argument value passed to the WSManRunShellCommand function is null
		/// or zero. Change the request to include the missing parameter and try again.
		/// </summary>
		ERROR_WSMAN_RUNSHELLCOMMAND_NULL_ARGUMENT = 0x8033814E,

		/// <summary>
		/// An operation is being attempted on a command that is being closed. This can happen if the command handle that is being used is
		/// also being freed by another thread.
		/// </summary>
		ERROR_WSMAN_COMMAND_ALREADY_CLOSED = 0x8033814F,

		/// <summary>
		/// The WinRM Shell client cannot process the request. The stream id index from within WSMAN_STREAM_ELEMENT passed to the
		/// WSManSendShellInput function is invalid. The stream id index should be an index from within inputStreamSet array passed to the
		/// WSManCreateShell function. Change the request with a valid index and try again.
		/// </summary>
		ERROR_WSMAN_SENDSHELLINPUT_INVALID_STREAMID_INDEX = 0x80338150,

		/// <summary>Not used. To be removed.</summary>
		ERROR_WSMAN_SHELL_SYNCHRONOUS_NOT_SUPPORTED = 0x80338151,

		/// <summary>
		/// The WS-Management operations to update the certificate mapping store of the WINRM service config can only be done remotely.
		/// </summary>
		ERROR_WSMAN_NO_CERTMAPPING_OPERATION_FOR_LOCAL_SESSION = 0x80338152,

		/// <summary>
		/// The WINRM certificate mapping configuration store has reached an internal limit and cannot create any more entries. Remove some
		/// entries and try again.
		/// </summary>
		ERROR_WSMAN_CERTMAPPING_CONFIGLIMIT_EXCEEDED = 0x80338153,

		/// <summary>
		/// The WINRM certificate mapping configuration operation cannot be completed because the user credentials could not be verified.
		/// Please check the username and password used for mapping this certificate and verify that it is a non-domain account and try again.
		/// </summary>
		ERROR_WSMAN_CERTMAPPING_INVALIDUSERCREDENTIALS = 0x80338154,

		/// <summary>
		/// The WinRM client cannot process the request. The Enhanced Key Usage (EKU) field of the certificate is not set to "Client
		/// Authentication". Retry the request with a certificate that has the correct EKU.
		/// </summary>
		ERROR_WSMAN_CERT_INVALID_USAGE_CLIENT = 0x80338155,

		/// <summary>
		/// The WinRM client cannot process the request. A certificate thumbprint was specified, but the following flag is missing:
		/// WSManFlagUseClientCertificate. Add the flag and try the request again.
		/// </summary>
		ERROR_WSMAN_CERT_MISSING_AUTH_FLAG = 0x80338156,

		/// <summary>
		/// The WinRM client cannot process the request. The following flags cannot be specified together: WSManFlagUseClientCertificate and
		/// WSManFlagCredUsernamePassword. Remove one of the flags and try the request again.
		/// </summary>
		ERROR_WSMAN_CERT_MULTIPLE_CREDENTIALS_FLAG = 0x80338157,

		/// <summary>
		/// The WinRM client cannot process the request because the CustomRemoteShell URI specified is invalid. CustomRemoteShell URI should
		/// start with WinRM shell resource URI prefix: "http://schemas.microsoft.com/wbem/wsman/1/windows/shell". The URI should not contain
		/// invalid characters including '*', '?', white spaces and tabs. The CustomRemoteShell URI cannot be longer than 1023 characters.
		/// </summary>
		ERROR_WSMAN_CONFIG_SHELL_URI_INVALID = 0x80338158,

		/// <summary>
		/// The WinRM client cannot process the request because the CustomRemoteShell URI specified is invalid. Windows command shell URI
		/// ("http://schemas.microsoft.com/wbem/wsman/1/windows/shell/cmd") cannot be a CustomRemoteShell URI.
		/// </summary>
		ERROR_WSMAN_CONFIG_SHELL_URI_CMDSHELLURI_NOTPERMITTED = 0x80338159,

		/// <summary>
		/// The WinRM client cannot process the request because the process path specified for the CustomRemoteShell table entry is invalid.
		/// The process path should be absolute and should point to an existing executable.
		/// </summary>
		ERROR_WSMAN_CONFIG_SHELLURI_INVALID_PROCESSPATH = 0x8033815A,

		/// <summary>Not used. To be removed.</summary>
		ERROR_WINRS_SHELL_URI_INVALID = 0x8033815B,

		/// <summary>The WinRM client cannot process the request because the provided security descriptor is invalid.</summary>
		ERROR_WSMAN_INVALID_SECURITY_DESCRIPTOR = 0x8033815C,

		/// <summary>
		/// The WinRM service cannot process the request because the WS-Policy contained in the DeliverTo is too complex or uses a structure
		/// not understood by the service. The WinRM service supports a single layer of policy assertions underneath a wsp:ExactlyOne element.
		/// </summary>
		ERROR_WSMAN_POLICY_TOO_COMPLEX = 0x8033815D,

		/// <summary>
		/// The WinRM service cannot process the request because the WS-Policy contained in the DeliverTo does not contain any options that
		/// the service can comply with. The WinRM service supports the following profiles: Negotiate or Kerberos over HTTP, Negotiate or
		/// Kerberos over HTTPS, and mutual certificate authentication over HTTPS using issuer thumbprints.
		/// </summary>
		ERROR_WSMAN_POLICY_CANNOT_COMPLY = 0x8033815E,

		/// <summary>The WinRM service cannot process the request because the wsman:ConnectionRetry element in the DeliverTo is invalid.</summary>
		ERROR_WSMAN_INVALID_CONNECTIONRETRY = 0x8033815F,

		/// <summary>
		/// WinRM cannot make the configuration change. The URI supplied for the certificate mapping operation is not valid. It must contain
		/// at least one character. It must not contain internal whitespace. It must not contain '?' character. A prefix may be specified by
		/// using "*" as the last character. The URI cannot be longer than 1023 characters.
		/// </summary>
		ERROR_WSMAN_URISECURITY_INVALIDURIKEY = 0x80338160,

		/// <summary>
		/// WinRM cannot make the configuration change. The Subject used for the certificate mapping operation is not valid. It must contain
		/// at least one character. It must contain at most one "*" character which should be the first character. (This may be the only
		/// character in which case it matches all subjects). The Subject cannot be longer than 1023 characters.
		/// </summary>
		ERROR_WSMAN_CERTMAPPING_INVALIDSUBJECTKEY = 0x80338161,

		/// <summary>
		/// WinRM cannot make the configuration change because the Issuer used for the certificate mapping operation is not valid. The
		/// certificate identified by the issuer thumbprint must be present in the machine "Trusted Root Certification Authorities" or
		/// "Intermediate Certification Authorities" store. The certificate must have key usage that allows it to sign other certificates.
		/// </summary>
		ERROR_WSMAN_CERTMAPPING_INVALIDISSUERKEY = 0x80338162,

		/// <summary>
		/// The WinRM client cannot process the request because the type field in the WSMAN_ALLOWED_PUBLISHERS argument is invalid.
		/// Collector-initiated subscriptions must use WSMAN_SINGLE_PUBLISHER and Source-initiated subscriptions must use WSMAN_MULTIPLE_PUBLISHERS.
		/// </summary>
		ERROR_WSMAN_INVALID_PUBLISHERS_TYPE = 0x80338163,

		/// <summary>
		/// The WinRM client cannot process the request because the delivery retry parameters are invalid. If delivery retry is requested,
		/// the deliveryRetryInterval and deliveryRetryAttempts fields must both be nonzero.
		/// </summary>
		ERROR_WSMAN_CLIENT_INVALID_DELIVERY_RETRY = 0x80338164,

		/// <summary>
		/// The WinRM client cannot process the request. The required WSMAN_ALLOWED_PUBLISHERS settings is null or zero. Change the request
		/// to include the missing parameter and try again.
		/// </summary>
		ERROR_WSMAN_CLIENT_NULL_PUBLISHERS = 0x80338165,

		/// <summary>
		/// The WinRM client cannot process the request because client certificate subject filters were specified without any issuers. When
		/// using client certificate authentication, specify at least one issuer thumbprint.
		/// </summary>
		ERROR_WSMAN_CLIENT_NULL_ISSUERS = 0x80338166,

		/// <summary>
		/// The WinRM client cannot process the request because the subscription contains no domain or non-domain sources. Subscriptions
		/// using WSMAN_MULTIPLE_PUBLISHERS must specify either a security descriptor or an issuer list or both.
		/// </summary>
		ERROR_WSMAN_CLIENT_NO_SOURCES = 0x80338167,

		/// <summary>
		/// The WinRM service cannot process the request because the subscription manager returned invalid enumeration results. The
		/// m:Subscription XML object or m:Version element is missing or invalid.
		/// </summary>
		ERROR_WSMAN_INVALID_SUBSCRIBE_OBJECT = 0x80338168,

		/// <summary>
		/// WinRM firewall exception will not work since one of the network connection types on this machine is set to Public. Change the
		/// network connection type to either Domain or Private and try again.
		/// </summary>
		ERROR_WSMAN_PUBLIC_FIREWALL_PROFILE_ACTIVE = 0x80338169,

		/// <summary>
		/// WinRM cannot make the configuration change. The Password used for updating the certificate mapping configuration is not valid. It
		/// cannot be longer than 255 characters.
		/// </summary>
		ERROR_WSMAN_CERTMAPPING_PASSWORDTOOLONG = 0x8033816A,

		/// <summary>
		/// WinRM cannot make the configuration change. The Password used for updating the certificate mapping configuration is not valid. A
		/// user account used for configuring a certificate mapping cannot have a blank password.
		/// </summary>
		ERROR_WSMAN_CERTMAPPING_PASSWORDBLANK = 0x8033816B,

		/// <summary>
		/// WinRM cannot make the configuration change. The credential used for updating or creating the certificate mapping configuration is
		/// not valid. The credential consists of both Password and UserName being supplied together in a pair.
		/// </summary>
		ERROR_WSMAN_CERTMAPPING_PASSWORDUSERTUPLE = 0x8033816C,

		/// <summary>
		/// The WinRM service executed an operation and the provider returned inconclusive information regarding success or failure of the
		/// operation. The status was marked as failed, but no error code was given.
		/// </summary>
		ERROR_WSMAN_INVALID_PROVIDER_RESPONSE = 0x8033816D,

		/// <summary>
		/// The WS-Management service on the remote machine cannot process the shell request. This can happen if the WS-Management service on
		/// the remote machine was being shutdown. To correct this problem restart the WS-Management service on the remote machine and
		/// re-send the shell request.
		/// </summary>
		ERROR_WSMAN_SHELL_NOT_INITIALIZED = 0x8033816E,

		/// <summary>
		/// The WinRM service cannot process the request. The URI parameter is the key to CustomRemoteShell table and cannot be modified.
		/// </summary>
		ERROR_WSMAN_CONFIG_SHELLURI_INVALID_OPERATION_ON_KEY = 0x8033816F,

		/// <summary>
		/// The WinRM client received an HTTP server error status (500), but the remote service did not include any other information about
		/// the cause of the failure.
		/// </summary>
		ERROR_WSMAN_HTTP_STATUS_SERVER_ERROR = 0x80338170,

		/// <summary>
		/// The WinRM client received an HTTP bad request status (400), but the remote service did not include any other information about
		/// the cause of the failure.
		/// </summary>
		ERROR_WSMAN_HTTP_STATUS_BAD_REQUEST = 0x80338171,

		/// <summary>
		/// The WinRM service cannot make the configuration change. The selector keys of Subject, URI or Issuer cannot be changed by
		/// overriding the selector key value in the body.
		/// </summary>
		ERROR_WSMAN_CONFIG_CANNOT_CHANGE_CERTMAPPING_KEYS = 0x80338172,

		/// <summary>The WinRM client cannot process the request because it received an HTML error packet.</summary>
		ERROR_WSMAN_HTML_ERROR = 0x80338173,

		/// <summary>
		/// The WinRM client cannot process the request. One of the parameters required for the WSManInitialize function is null or zero.
		/// Change the request to include the missing parameter and try again.
		/// </summary>
		ERROR_WSMAN_CLIENT_INITIALIZE_NULL_PARAM = 0x80338174,

		/// <summary>
		/// The WinRM client cannot process the request. An invalid flag was specified for the WSManInitialize API call. Remove or change the
		/// invalid flag and try the call again.
		/// </summary>
		ERROR_WSMAN_CLIENT_INVALID_INIT_APPLICATION_FLAG = 0x80338175,

		/// <summary>
		/// The WinRM client cannot process the request. An invalid flag was specified for the WSManDeinitialize API call. Remove or change
		/// the invalid flag and try the call again.
		/// </summary>
		ERROR_WSMAN_CLIENT_INVALID_DEINIT_APPLICATION_FLAG = 0x80338176,

		/// <summary>
		/// The WinRM client cannot process the request. One of the parameters required for the WSManSetSessionOption function is null or
		/// zero. Change the request to include the missing parameter and try again.
		/// </summary>
		ERROR_WSMAN_CLIENT_SETSESSIONOPTION_NULL_PARAM = 0x80338177,

		/// <summary>
		/// The WinRM client cannot process the request. One of the parameters required for the WSManSetSessionOption function is invalid.
		/// Change the invalid parameter and try again.
		/// </summary>
		ERROR_WSMAN_CLIENT_SETSESSIONOPTION_INVALID_PARAM = 0x80338178,

		/// <summary>
		/// The WinRM client cannot process the request. One of the parameters required to get a session option is invalid. Change the
		/// invalid parameter and try again.
		/// </summary>
		ERROR_WSMAN_CLIENT_GETSESSIONOPTION_INVALID_PARAM = 0x80338179,

		/// <summary>
		/// The WinRM Shell client cannot process the request. One of the parameters required for the WSManCreateShell function is null or
		/// zero. Change the request to include the missing parameter and try again.
		/// </summary>
		ERROR_WSMAN_CLIENT_CREATESHELL_NULL_PARAM = 0x8033817A,

		/// <summary>
		/// The WinRM client cannot process the request. An invalid flag was specified for the WSManCreateShell API call. Remove or change
		/// the invalid flag and try the call again.
		/// </summary>
		ERROR_WSMAN_CLIENT_INVALID_CREATE_SHELL_FLAG = 0x8033817B,

		/// <summary>
		/// The WinRM client cannot process the request. An invalid flag was specified for the WSManCloseShell API call. Remove or change the
		/// invalid flag and try the call again.
		/// </summary>
		ERROR_WSMAN_CLIENT_INVALID_CLOSE_SHELL_FLAG = 0x8033817C,

		/// <summary>
		/// The WinRM client cannot process the request. An invalid flag was specified for the WSManCloseCommand API call. Remove or change
		/// the invalid flag and try the call again.
		/// </summary>
		ERROR_WSMAN_CLIENT_INVALID_CLOSE_COMMAND_FLAG = 0x8033817D,

		/// <summary>
		/// The WinRM Shell client cannot process the request. One of the parameters required for the WSManCloseShell function is null or
		/// zero. Change the request to include the missing parameter and try again.
		/// </summary>
		ERROR_WSMAN_CLIENT_CLOSESHELL_NULL_PARAM = 0x8033817E,

		/// <summary>
		/// The WinRM Shell client cannot process the request. One of the parameters required for the WSManCloseCommand function is null or
		/// zero. Change the request to include the missing parameter and try again.
		/// </summary>
		ERROR_WSMAN_CLIENT_CLOSECOMMAND_NULL_PARAM = 0x8033817F,

		/// <summary>
		/// The WinRM Shell client cannot process the request. One of the parameters required for the WSManRunShellCommand function is null
		/// or zero. Change the request to include the missing parameter and try again.
		/// </summary>
		ERROR_WSMAN_CLIENT_RUNCOMMAND_NULL_PARAM = 0x80338180,

		/// <summary>
		/// The WinRM client cannot process the request. An invalid flag was specified for the WSManRunShellCommand API call. Remove or
		/// change the invalid flag and try the call again.
		/// </summary>
		ERROR_WSMAN_CLIENT_INVALID_RUNCOMMAND_FLAG = 0x80338181,

		/// <summary>
		/// The WinRM client cannot process the request. You must wait for the WSManRunShellCommand API call to complete before calling
		/// WSManCloseShellOperationEx API.
		/// </summary>
		ERROR_WSMAN_CLIENT_RUNCOMMAND_NOTCOMPLETED = 0x80338182,

		/// <summary>
		/// The WinRM client cannot process the request. The response to a Command request did not contain a valid CommandResponse element.
		/// The CommandResponse element was not found or did not contain valid content.
		/// </summary>
		ERROR_WSMAN_NO_COMMAND_RESPONSE = 0x80338183,

		/// <summary>
		/// The WinRM client cannot process the request. The OptionSet element is invalid. Change the request to include a valid OptionSet
		/// element and try again.
		/// </summary>
		ERROR_WSMAN_INVALID_OPTIONSET = 0x80338184,

		/// <summary>
		/// The WinRM client cannot process the request. The response to a Command request did not contain a valid CommandResponse element.
		/// The CommandId element was not found or did not contain valid content.
		/// </summary>
		ERROR_WSMAN_NO_COMMANDID = 0x80338185,

		/// <summary>
		/// The WinRM Shell client cannot process the request. One of the parameters required for the WSManSignalShell function is null or
		/// zero. Change the request to include the missing parameter and try again.
		/// </summary>
		ERROR_WSMAN_CLIENT_SIGNAL_NULL_PARAM = 0x80338186,

		/// <summary>
		/// The WinRM client cannot process the request. An invalid flag was specified for the WSManSignalShell API call. Remove or change
		/// the invalid flag and try the call again.
		/// </summary>
		ERROR_WSMAN_CLIENT_INVALID_SIGNAL_SHELL_FLAG = 0x80338187,

		/// <summary>
		/// The WinRM Shell client cannot process the request. One of the parameters required for the WSManSendShellInput function is null or
		/// zero. Change the request to include the missing parameter and try again.
		/// </summary>
		ERROR_WSMAN_CLIENT_SEND_NULL_PARAM = 0x80338188,

		/// <summary>
		/// The WinRM client cannot process the request. An invalid flag was specified for the WSManSendShellInput API call. Remove or change
		/// the invalid flag and try the call again.
		/// </summary>
		ERROR_WSMAN_CLIENT_INVALID_SEND_SHELL_FLAG = 0x80338189,

		/// <summary>
		/// The WinRM client cannot process the request. An invalid parameter was specified for the WSManSendShellInput API call. streamData
		/// parameter should be specified in binary format using WSMAN_DATA_TYPE_BINARY type. Change the invalid parameter and try the call again.
		/// </summary>
		ERROR_WSMAN_CLIENT_INVALID_SEND_SHELL_PARAMETER = 0x8033818A,

		/// <summary>
		/// The WinRM Shell client cannot process the request. The stream name passed to the WSManSendShellInput function is not valid. The
		/// input stream name should be specified as part of the input streams during shell creation using WSManCreateShell function. Change
		/// the request including a valid input stream name and try again.
		/// </summary>
		ERROR_WSMAN_SHELL_INVALID_INPUT_STREAM = 0x8033818B,

		/// <summary>
		/// The WinRM Shell client cannot process the request. One of the parameters required for the WSManReceiveShellOutput function is
		/// null or zero. Change the request to include the missing parameter and try again.
		/// </summary>
		ERROR_WSMAN_CLIENT_RECEIVE_NULL_PARAM = 0x8033818C,

		/// <summary>
		/// The WinRM Shell client cannot process the request. The stream or list of streams passed to the WSManReceiveShellOutput function
		/// is not valid. The desired stream names should be specified as part of the output streams during shell creation using
		/// WSManCreateShell function. Change the request including valid desired streams and try again.
		/// </summary>
		ERROR_WSMAN_SHELL_INVALID_DESIRED_STREAMS = 0x8033818D,

		/// <summary>
		/// The WinRM client cannot process the request. An invalid flag was specified for the WSManReceiveShellOutput API call. Remove or
		/// change the invalid flag and try the call again.
		/// </summary>
		ERROR_WSMAN_CLIENT_INVALID_RECEIVE_SHELL_FLAG = 0x8033818E,

		/// <summary>
		/// The WinRM client cannot process the request. The response to a Receive request did not contain a valid ReceiveResponse element.
		/// The ReceiveResponse element was not found or did not contain valid content.
		/// </summary>
		ERROR_WSMAN_NO_RECEIVE_RESPONSE = 0x8033818F,

		/// <summary>The WSMan plugin configuration is corrupted.</summary>
		ERROR_WSMAN_PLUGIN_CONFIGURATION_CORRUPTED = 0x80338190,

		/// <summary>The file path specified is either not absolute, not in the system32 directory, or not valid.</summary>
		ERROR_WSMAN_INVALID_FILEPATH = 0x80338191,

		/// <summary>The file specified does not exist.</summary>
		ERROR_WSMAN_FILE_NOT_PRESENT = 0x80338192,

		/// <summary>The WSMan extension failed to read IIS configuration.</summary>
		ERROR_WSMAN_IISCONFIGURATION_READ_FAILED = 0x80338193,

		/// <summary>The WinRM client cannot process the request. The locale option is invalid. Change the locale and try again.</summary>
		ERROR_WSMAN_CLIENT_INVALID_LOCALE = 0x80338194,

		/// <summary>The WinRM client cannot process the request. The UI language option is invalid. Change the UI language and try again.</summary>
		ERROR_WSMAN_CLIENT_INVALID_UI_LANGUAGE = 0x80338195,

		/// <summary>
		/// The WinRM client cannot process the request. One of the parameters required for the WSManGetErrorMessage function is null or
		/// zero. Change the request to include the missing parameter and try again.
		/// </summary>
		ERROR_WSMAN_CLIENT_GETERRORMESSAGE_NULL_PARAM = 0x80338196,

		/// <summary>
		/// The WinRM client cannot process the request. The language code parameter is invalid. The language code parameter should be either
		/// NULL or a valid RFC 3066 language code. Change the language code and try the request again.
		/// </summary>
		ERROR_WSMAN_CLIENT_INVALID_LANGUAGE_CODE = 0x80338197,

		/// <summary>
		/// The WinRM client cannot process the request. An invalid flag was specified for the WSManGetErrorMessage API call. Remove or
		/// change the invalid flag and try the call again.
		/// </summary>
		ERROR_WSMAN_CLIENT_INVALID_GETERRORMESSAGE_FLAG = 0x80338198,

		/// <summary>
		/// The WinRM service cannot process the request because the request needs to be sent to a different machine. Use the redirect
		/// information to send the request to a new machine.
		/// </summary>
		ERROR_WSMAN_REDIRECT_REQUESTED = 0x80338199,

		/// <summary>
		/// The WinRM client cannot process the request. The flag that specifies the proxy authentication mechanism to use is incorrect.
		/// Remove or change the invalid flag and try the request again.
		/// </summary>
		ERROR_WSMAN_PROXY_AUTHENTICATION_INVALID_FLAG = 0x8033819A,

		/// <summary>
		/// The WinRM client cannot process the request. The credentials for proxy authentication are not specified correctly. Both user name
		/// and password credentials must be valid. Specify the correct credentials and try the request again.
		/// </summary>
		ERROR_WSMAN_CLIENT_CREDENTIALS_FOR_PROXY_AUTHENTICATION = 0x8033819B,

		/// <summary>
		/// The WinRM client cannot process the request. The proxy access type is incorrect. Use one of the proxy access type flags; the
		/// flags cannot be combined. Change the invalid proxy access type and try the request again.
		/// </summary>
		ERROR_WSMAN_PROXY_ACCESS_TYPE = 0x8033819C,

		/// <summary>
		/// The WinRM client cannot process the request. The direct connection to the server option cannot be used with non empty proxy
		/// authentication data. Change the invalid proxy access type or use empty proxy authentication data and try the request again.
		/// </summary>
		ERROR_WSMAN_INVALID_OPTION_NO_PROXY_SERVER = 0x8033819D,

		/// <summary>
		/// The WinRM client cannot process the request. One of the parameters required for the WSManGetSessionOptionAsDword function is null
		/// or zero. Change the request to include the missing parameter and try again.
		/// </summary>
		ERROR_WSMAN_CLIENT_GETSESSIONOPTION_DWORD_NULL_PARAM = 0x8033819E,

		/// <summary>
		/// The WinRM client cannot process the request. One of the parameters required for the WSManGetSessionOptionAsDword function is
		/// invalid. Change the invalid parameter and try again.
		/// </summary>
		ERROR_WSMAN_CLIENT_GETSESSIONOPTION_DWORD_INVALID_PARAM = 0x8033819F,

		/// <summary>
		/// The WinRM client cannot process the request. One of the parameters required for the WSManGetSessionOptionAsString function is
		/// invalid. Change the invalid parameter and try again.
		/// </summary>
		ERROR_WSMAN_CLIENT_GETSESSIONOPTION_STRING_INVALID_PARAM = 0x803381A0,

		/// <summary>
		/// The WinRM client cannot process the request. Requests must include user name and password when CredSSP authentication mechanism
		/// is used. Add the user name and password or change the authentication mechanism and try the request again.
		/// </summary>
		ERROR_WSMAN_CREDSSP_USERNAME_PASSWORD_NEEDED = 0x803381A1,

		/// <summary>
		/// The WinRM client cannot process the request. CredSSP authentication is currently disabled in the client configuration. Change the
		/// client configuration and try the request again. CredSSP authentication must also be enabled in the server configuration. Also,
		/// Group Policy must be edited to allow credential delegation to the target computer. Use gpedit.msc and look at the following
		/// policy: Computer Configuration -&gt; Administrative Templates -&gt; System -&gt; Credentials Delegation -&gt; Allow Delegating
		/// Fresh Credentials. Verify that it is enabled and configured with an SPN appropriate for the target computer. For example, for a
		/// target computer name "myserver.domain.com", the SPN can be one of the following: WSMAN/myserver.domain.com or WSMAN/*.domain.com
		/// </summary>
		ERROR_WSMAN_CLIENT_CREDSSP_AUTHENTICATION_DISABLED = 0x803381A2,

		/// <summary>
		/// The WinRM client cannot process the request. A computer policy does not allow the delegation of the user credentials to the
		/// target computer. Use gpedit.msc and look at the following policy: Computer Configuration -&gt; Administrative Templates -&gt;
		/// System -&gt; Credentials Delegation -&gt; Allow Delegating Fresh Credentials. Verify that it is enabled and configured with an
		/// SPN appropriate for the target computer. For example, for a target computer name "myserver.domain.com", the SPN can be one of the
		/// following: WSMAN/myserver.domain.com or WSMAN/*.domain.com.
		/// </summary>
		ERROR_WSMAN_CLIENT_ALLOWFRESHCREDENTIALS = 0x803381A3,

		/// <summary>
		/// The WinRM client cannot process the request. A computer policy does not allow the delegation of the user credentials to the
		/// target computer because the computer is not trusted. The identity of the target computer can be verified if you configure the
		/// WSMAN service to use a valid certificate using the following command: winrm set winrm/config/service
		/// @{CertificateThumbprint="&lt;thumbprint&gt;"} Or you can check the Event Viewer for an event that specifies that the following
		/// SPN could not be created: WSMAN/&lt;computerFQDN&gt;. If you find this event, you can manually create the SPN using setspn.exe .
		/// If the SPN exists, but CredSSP cannot use Kerberos to validate the identity of the target computer and you still want to allow
		/// the delegation of the user credentials to the target computer, use gpedit.msc and look at the following policy: Computer
		/// Configuration -&gt; Administrative Templates -&gt; System -&gt; Credentials Delegation -&gt; Allow Fresh Credentials with
		/// NTLM-only Server Authentication. Verify that it is enabled and configured with an SPN appropriate for the target computer. For
		/// example, for a target computer name "myserver.domain.com", the SPN can be one of the following: WSMAN/myserver.domain.com or
		/// WSMAN/*.domain.com. Try the request again after these changes.
		/// </summary>
		ERROR_WSMAN_CLIENT_ALLOWFRESHCREDENTIALS_NTLMONLY = 0x803381A4,

		/// <summary>
		/// The WS-Management service cannot process the request. The maximum number of concurrent shells for this user has been exceeded.
		/// Close existing shells or raise the quota for this user.
		/// </summary>
		ERROR_WSMAN_QUOTA_MAX_SHELLS = 0x803381A5,

		/// <summary>
		/// The WS-Management service cannot process the request. The maximum number of concurrent operations for this user has been
		/// exceeded. Close existing operations for this user, or raise the quota for this user.
		/// </summary>
		ERROR_WSMAN_QUOTA_MAX_OPERATIONS = 0x803381A6,

		/// <summary>
		/// The WS-Management service cannot process the request. The load quota for this user has been exceeded. Send future requests at a
		/// slower rate or raise the quota for this user.
		/// </summary>
		ERROR_WSMAN_QUOTA_USER = 0x803381A7,

		/// <summary>
		/// The WS-Management service cannot process the request. The load quota for the system has been exceeded. Send future requests at a
		/// slower rate or raise the system quota.
		/// </summary>
		ERROR_WSMAN_QUOTA_SYSTEM = 0x803381A8,

		/// <summary>
		/// The WS-Management service cannot complete the authorization under the given token. A previous authorization attempt for the same
		/// user resulted in a different token. The user record will be revoked and the next request will reauthorize.
		/// </summary>
		ERROR_WSMAN_DIFFERENT_AUTHZ_TOKEN = 0x803381A9,

		/// <summary>
		/// An application tried to retrieve the HTTP Redirect location from the session when no redirect error
		/// (ERROR_WSMAN_REDIRECT_REQUESTED) was returned. The application needs to be updated so as to only retrieve the location after this
		/// error is returned.
		/// </summary>
		ERROR_WSMAN_REDIRECT_LOCATION_NOT_AVAILABLE = 0x803381AA,

		/// <summary>
		/// The WS-Management service cannot process the request. The maximum number of users executing shell operations has been exceeded.
		/// Retry after some time or raise the quota for concurrent shell users.
		/// </summary>
		ERROR_WSMAN_QUOTA_MAX_SHELLUSERS = 0x803381AB,

		/// <summary>The WS-Management service cannot process the request. The service is configured to not accept any remote shell requests.</summary>
		ERROR_WSMAN_REMOTESHELLS_NOT_ALLOWED = 0x803381AC,

		/// <summary>
		/// The WS-Management service cannot complete the Pull operation for the enumeration because the wsman:MaxEnvelopeSize,
		/// wsen:MaxCharacters or wsen:MaxElements parameters differ from those specified to the enumeration. The application needs to
		/// specify the same parameters for Pull as were specified for the enumeration.
		/// </summary>
		ERROR_WSMAN_PULL_PARAMS_NOT_SAME_AS_ENUM = 0x803381AD,

		/// <summary>
		/// The WinRM service cannot process the request because it is trying to update a deprecated setting. Remove this setting from the
		/// command and try again.
		/// </summary>
		ERROR_WSMAN_DEPRECATED_CONFIG_SETTING = 0x803381AE,

		/// <summary>
		/// The WS-Management service cannot process the configuration settings. A Security element contains a URI that does not match its
		/// parent Resource element.
		/// </summary>
		ERROR_WSMAN_URI_SECURITY_URI = 0x803381AF,

		/// <summary>
		/// The WinRM client cannot process the request. Allow implicit credentials for Negotiate authentication option is only valid for
		/// HTTPS transport. Remove the allow implicit credentials for Negotiate authentication option and try the request again.
		/// </summary>
		ERROR_WSMAN_CANNOT_USE_ALLOW_NEGOTIATE_IMPLICIT_CREDENTIALS_FOR_HTTP = 0x803381B0,

		/// <summary>
		/// The WinRM client cannot process the request. Setting proxy information is not valid when the HTTP transport is specified. Remove
		/// the proxy information or change the transport and try the request again.
		/// </summary>
		ERROR_WSMAN_CANNOT_USE_PROXY_SETTINGS_FOR_HTTP = 0x803381B1,

		/// <summary>
		/// The WinRM client cannot process the request. Setting proxy information is not valid when the authentication mechanism with the
		/// remote machine is Kerberos. Remove the proxy information or change the authentication mechanism and try the request again.
		/// </summary>
		ERROR_WSMAN_CANNOT_USE_PROXY_SETTINGS_FOR_KERBEROS = 0x803381B2,

		/// <summary>
		/// The WinRM client cannot process the request. Setting proxy information is not valid when the authentication mechanism with the
		/// remote machine is CredSSP. Remove the proxy information or change the authentication mechanism and try the request again.
		/// </summary>
		ERROR_WSMAN_CANNOT_USE_PROXY_SETTINGS_FOR_CREDSSP = 0x803381B3,

		/// <summary>
		/// The WinRM client cannot process the request. The request must specify only one authentication mechanism for proxy. Change the
		/// request to specify only one authentication mechanism and try again.
		/// </summary>
		ERROR_WSMAN_CLIENT_MULTIPLE_PROXY_AUTH_FLAGS = 0x803381B4,

		/// <summary>
		/// The WinRM client received a redirect error from the server when it is not appropriate. The only time a redirect error can be
		/// reported correctly is during the authorization of a user. This would result in a properly formatted redirect response from the
		/// server that includes the redirect endpoint.
		/// </summary>
		ERROR_WSMAN_INVALID_REDIRECT_ERROR = 0x803381B5,

		/// <summary>The WinRM service received a redirect error from an authorization plug-in where the redirect location was too long.</summary>
		ERROR_REDIRECT_LOCATION_TOO_LONG = 0x803381B6,

		/// <summary>The WinRM service received a HTTP redirect message redirecting the client but the location URL is invalid.</summary>
		ERROR_REDIRECT_LOCATION_INVALID = 0x803381B7,

		/// <summary>
		/// The WinRM service cannot process the request. The Channel Binding Token Hardening Level (CbtHardeningLevel) value is invalid. The
		/// valid values are "None", "Relaxed" and "Strict". Change the CbtHardeningLevel value and try again.
		/// </summary>
		ERROR_SERVICE_CBT_HARDENING_INVALID = 0x803381B8,

		/// <summary>The WinRM client cannot process the request because the server name cannot be resolved.</summary>
		ERROR_WSMAN_NAME_NOT_RESOLVED = 0x803381B9,

		/// <summary>
		/// The SSL connection cannot be established. Verify that the service on the remote host is properly configured to listen for HTTPS
		/// requests. Consult the logs and documentation for the WS-Management service running on the destination, most commonly IIS or
		/// WinRM. If the destination is the WinRM service, run the following command on the destination to analyze and configure the WinRM
		/// service: "winrm quickconfig -transport:https".
		/// </summary>
		ERROR_WSMAN_SSL_CONNECTION_ABORTED = 0x803381BA,

		/// <summary>
		/// The WinRM client cannot process the request. Default authentication may be used with an IP address under the following
		/// conditions: the transport is HTTPS or the destination is in the TrustedHosts list, and explicit credentials are provided. Use
		/// winrm.cmd to configure TrustedHosts. Note that computers in the TrustedHosts list might not be authenticated. For more
		/// information on how to set TrustedHosts run the following command: winrm help config.
		/// </summary>
		ERROR_WSMAN_DEFAULTAUTH_IPADDRESS = 0x803381BB,

		/// <summary>The WinRM client cannot process the request. Custom Remote Shell has been deprecated and cannot be used.</summary>
		ERROR_WSMAN_CUSTOMREMOTESHELL_DEPRECATED = 0x803381BC,

		/// <summary>The WinRM client cannot process the request. The feature in use has been deprecated and cannot be used.</summary>
		ERROR_WSMAN_FEATURE_DEPRECATED = 0x803381BD,

		/// <summary>The WinRM client used a parameter to specify the use of SSL while specifying http in the connection string.</summary>
		ERROR_WSMAN_INVALID_USESSL_PARAM = 0x803381BE,

		/// <summary>The WinRM service cannot process the request because the security for this resource URI cannot be changed.</summary>
		ERROR_WSMAN_INVALID_CONFIGSDDL_URL = 0x803381BF,

		/// <summary>
		/// The WinRM service cannot process the request. The enumeration request expects a selector based filter to specify the shell identifier.
		/// </summary>
		ERROR_WSMAN_ENUMERATE_SHELLCOMAMNDS_FILTER_EXPECTED = 0x803381C0,

		/// <summary>The WinRM service cannot process the request. The enumeration of end point resources for shell commands is not supported.</summary>
		ERROR_WSMAN_ENUMERATE_SHELLCOMMANDS_EPRS_NOTSUPPORTED = 0x803381C1,

		/// <summary>The WinRM Shell client cannot process the request because the shell name has exceeded 255 characters in length.</summary>
		ERROR_WSMAN_CLIENT_CREATESHELL_NAME_INVALID = 0x803381C2,

		/// <summary>
		/// The WinRM runAs configuration operation cannot be completed because the user credentials could not be verified. Verify that the
		/// username and password used for configuration are valid and retry the operation.
		/// </summary>
		ERROR_WSMAN_RUNAS_INVALIDUSERCREDENTIALS = 0x803381C3,

		/// <summary>The WinRM service cannot process the request because the WinRS shell instance is currently disconnected.</summary>
		ERROR_WINRS_SHELL_DISCONNECTED = 0x803381C4,

		/// <summary>
		/// The WinRM service cannot process the request. This WinRS shell instance does not support disconnect and reconnect operations
		/// because it was created by an older WinRS client or its provider does not support the disconnect operation.
		/// </summary>
		ERROR_WINRS_SHELL_DISCONNECT_NOT_SUPPORTED = 0x803381C5,

		/// <summary>The WinRM service cannot process the request because the WinRS shell instance is connected to a different client.</summary>
		ERROR_WINRS_SHELL_CLIENTSESSIONID_MISMATCH = 0x803381C6,

		/// <summary>
		/// The WinRM Shell client cannot process the request. One of the parameters required for the WSManDisconnectShell function is null
		/// or zero. Change the request to include the missing parameter and try again.
		/// </summary>
		ERROR_WSMAN_CLIENT_DISCONNECTSHELL_NULL_PARAM = 0x803381C7,

		/// <summary>
		/// The WinRM Shell client cannot process the request. One of the parameters required for the WSManReconnectShell function is null or
		/// zero. Change the request to include the missing parameter and try again.
		/// </summary>
		ERROR_WSMAN_CLIENT_RECONNECTSHELL_NULL_PARAM = 0x803381C8,

		/// <summary>
		/// The WinRM Shell client cannot process the request. One of the parameters required for the WSManConnectShell function is null or
		/// zero. Change the request to include the missing parameter and try again.
		/// </summary>
		ERROR_WSMAN_CLIENT_CONNECTSHELL_NULL_PARAM = 0x803381C9,

		/// <summary>
		/// The WinRM Shell client cannot process the request. One of the parameters required for the WSManConnectShellCommand function is
		/// null or zero. Change the request to include the missing parameter and try again.
		/// </summary>
		ERROR_WSMAN_CLIENT_CONNECTCOMMAND_NULL_PARAM = 0x803381CA,

		/// <summary>The WinRM client cannot process the request. The body response is not a valid connect request response.</summary>
		ERROR_WINRS_CONNECT_RESPONSE_BAD_BODY = 0x803381CB,

		/// <summary>The WinRM Shell client cannot process the request. The command is currently terminating or was terminated.</summary>
		ERROR_WSMAN_COMMAND_TERMINATED = 0x803381CC,

		/// <summary>The WinRM service cannot process the request. The WinRS shell instance is currently connected to a different client.</summary>
		ERROR_WINRS_SHELL_CONNECTED_TO_DIFFERENT_CLIENT = 0x803381CD,

		/// <summary>
		/// The WinRM client encountered an error while communicating with the WinRM service during the disconnect operation. The shell has
		/// been disconnected and the streams were possibly suspended abruptly.
		/// </summary>
		ERROR_WINRS_SHELL_DISCONNECT_OPERATION_NOT_GRACEFUL = 0x803381CE,

		/// <summary>
		/// The WinRM client cannot process the request. A disconnect operation cannot be performed on a WinRS shell instance that is already disconnected.
		/// </summary>
		ERROR_WINRS_SHELL_DISCONNECT_OPERATION_NOT_VALID = 0x803381CF,

		/// <summary>
		/// The WinRM client cannot process the request. A reconnect operation cannot be performed on a WinRS shell instance that is
		/// currently connected.
		/// </summary>
		ERROR_WINRS_SHELL_RECONNECT_OPERATION_NOT_VALID = 0x803381D0,

		/// <summary>An error was encountered while subscribing to the Group Policy change notification.</summary>
		ERROR_WSMAN_CONFIG_GROUP_POLICY_CHANGE_NOTIFICATION_SUBSCRIPTION_FAILED = 0x803381D1,

		/// <summary>
		/// The WinRM Shell client cannot process the request. One of the parameters required for the WSManReconnectShellCommand function is
		/// null or zero. Change the request to include the missing parameter and try again.
		/// </summary>
		ERROR_WSMAN_CLIENT_RECONNECTSHELLCOMMAND_NULL_PARAM = 0x803381D2,

		/// <summary>
		/// The WinRM client cannot process the request. A reconnect operation cannot be performed on a WinRS shell command instance that is
		/// currently connected.
		/// </summary>
		ERROR_WINRS_SHELLCOMMAND_RECONNECT_OPERATION_NOT_VALID = 0x803381D3,

		/// <summary>
		/// The WinRM service cannot process the request because the command ID specified by the client is not a valid GUID. Modify the
		/// request and retry the request.
		/// </summary>
		ERROR_WINRS_SHELLCOMMAND_CLIENTID_NOT_VALID = 0x803381D4,

		/// <summary>
		/// The WinRM service cannot process the request because the shell ID specified by the client is not a valid GUID. Provide a valid ID
		/// and try again.
		/// </summary>
		ERROR_WINRS_SHELL_CLIENTID_NOT_VALID = 0x803381D5,

		/// <summary>The WinRM service cannot process the request. A command already exists with the command ID specified by the client.</summary>
		ERROR_WINRS_SHELLCOMMAND_CLIENTID_RESOURCE_CONFLICT = 0x803381D6,

		/// <summary>The WinRM service cannot process the request. A resource already exists with the shell ID specified by the client.</summary>
		ERROR_WINRS_SHELL_CLIENTID_RESOURCE_CONFLICT = 0x803381D7,

		/// <summary>
		/// The WinRM client cannot process the request. A disconnect operation cannot be performed on a WinRS shell command instance that is disconnected.
		/// </summary>
		ERROR_WINRS_SHELLCOMMAND_DISCONNECT_OPERATION_NOT_VALID = 0x803381D8,

		/// <summary>
		/// The WS-Management service cannot process the request. The resource URI for the Subscribe operation must not contain keys.
		/// </summary>
		ERROR_WSMAN_SUBSCRIBE_WMI_INVALID_KEY = 0x803381D9,

		/// <summary>
		/// The WinRM client cannot process the request. A flag that is not valid was specified for the WSManDisconnectShell method. Remove
		/// or change the flag and retry the operation.
		/// </summary>
		ERROR_WSMAN_CLIENT_INVALID_DISCONNECT_SHELL_FLAG = 0x803381DA,

		/// <summary>
		/// The WinRM client cannot process the request because the command handle is not associated with the provided shell handle.
		/// </summary>
		ERROR_WSMAN_CLIENT_INVALID_SHELL_COMMAND_PAIR = 0x803381DB,

		/// <summary>
		/// The WS-Management service did not receive a response for an extended semantics operation within the timeframe specified in the
		/// OperationTimeout setting.
		/// </summary>
		ERROR_WSMAN_SEMANTICCALLBACK_TIMEDOUT = 0x803381DC,

		/// <summary>The WS-Management service is configured to not allow remote requests.</summary>
		ERROR_WSMAN_SERVICE_REMOTE_ACCESS_DISABLED = 0x803381DD,

		/// <summary>The WS-Management service cannot process the request because the stream is currently disconnected.</summary>
		ERROR_WSMAN_SERVICE_STREAM_DISCONNECTED = 0x803381DE,

		/// <summary>
		/// The creation of a new Shell failed. Verify that the RunAsPassword value is correctly configured and that the Group Policy setting
		/// "Disallow WinRM from storing RunAs credentials" is Disabled or Not Configured. To enable WinRM to store RunAs credentials, change
		/// this Group Policy setting to Disabled.
		/// </summary>
		ERROR_WSMAN_CREATESHELL_RUNAS_FAILED = 0x803381DF,

		/// <summary>
		/// The supplied plugin configuration XML is not valid. To enable WinRM to store RunAs credentials, change the "Disallow WinRM from
		/// storing RunAs credentials" Group Policy setting to Disabled.
		/// </summary>
		ERROR_WSMAN_INVALID_XML_RUNAS_DISABLED = 0x803381E0,

		/// <summary>
		/// The WinRM client cannot process the request because the XML instance does not match the class schema provided by the server.
		/// </summary>
		ERROR_WSMAN_WRONG_METADATA = 0x803381E1,

		/// <summary>
		/// The WinRM client cannot process the request because the XML contains an unsupported type. Verify the XML and retry the operation.
		/// </summary>
		ERROR_WSMAN_UNSUPPORTED_TYPE = 0x803381E2,

		/// <summary>
		/// The WS-Management service cannot process the request. The service is configured to reject remote connection requests for this plugin.
		/// </summary>
		ERROR_WSMAN_REMOTE_CONNECTION_NOT_ALLOWED = 0x803381E3,

		/// <summary>
		/// The WS-Management service cannot process the request. This user has exceeded the maximum number of concurrent shells allowed for
		/// this plugin. Close at least one open shell or raise the plugin quota for this user.
		/// </summary>
		ERROR_WSMAN_QUOTA_MAX_SHELLS_PPQ = 0x803381E4,

		/// <summary>
		/// The WS-Management service cannot process the request. The maximum number of users executing remote operations has been exceeded
		/// for this plugin. Retry the request later or raise the quota for concurrent users.
		/// </summary>
		ERROR_WSMAN_QUOTA_MAX_USERS_PPQ = 0x803381E5,

		/// <summary>
		/// The WS-Management service cannot process the request. The maximum number of concurrent shells allowed for this plugin has been
		/// exceeded. Retry the request later or raise the Maximum Shells per Plugin quota.
		/// </summary>
		ERROR_WSMAN_QUOTA_MAX_PLUGINSHELLS_PPQ = 0x803381E6,

		/// <summary>
		/// The WS-Management service cannot process the request. The maximum number of concurrent operations allowed for this plugin has
		/// been exceeded. Retry the request later or raise the Maximum Operations per Plugin quota.
		/// </summary>
		ERROR_WSMAN_QUOTA_MAX_PLUGINOPERATIONS_PPQ = 0x803381E7,

		/// <summary>
		/// The WS-Management service cannot process the request. This user has exceeded the maximum number of allowed concurrent operations.
		/// Retry the request later or raise the Maximum Operations per User quota.
		/// </summary>
		ERROR_WSMAN_QUOTA_MAX_OPERATIONS_USER_PPQ = 0x803381E8,

		/// <summary>
		/// The WS-Management service cannot process the request. The maximum number of concurrent commands per shell has been exceeded.
		/// Retry the request later or raise the Maximum Commands per Shell quota.
		/// </summary>
		ERROR_WSMAN_QUOTA_MAX_COMMANDS_PER_SHELL_PPQ = 0x803381E9,

		/// <summary>
		/// The WS-Management service cannot process the request. There are not enough resources available to process this operation. Retry
		/// the operation later or close one or more of the currently running operations.
		/// </summary>
		ERROR_WSMAN_QUOTA_MIN_REQUIREMENT_NOT_AVAILABLE_PPQ = 0x803381EA,

		/// <summary>The WinRM client cannot process the request because the MI Deserializer cannot be created.</summary>
		ERROR_WSMAN_NEW_DESERIALIZER = 0x803381EB,

		/// <summary>The WinRM client cannot process the request because the metadata could not be deserialized.</summary>
		ERROR_WSMAN_DESERIALIZE_CLASS = 0x803381EC,

		/// <summary>The WinRM client cannot process the request because the metadata failed to be retrieved from the server.</summary>
		ERROR_WSMAN_GETCLASS = 0x803381ED,

		/// <summary>The WinRM client cannot process the request because a WinRM session could not be created.</summary>
		ERROR_WSMAN_NEW_SESSION = 0x803381EE,

		/// <summary>
		/// The WinRM client cannot process the request because the target object has a key property set to NULL. Incomplete objects cannot
		/// be used as the target of an operation.
		/// </summary>
		ERROR_WSMAN_NULL_KEY = 0x803381EF,

		/// <summary>
		/// The WinRM client cannot process the request as the server identity could not be verified. If the identity of the server is
		/// trusted, add it to the TrustedHosts list and retry the request. Use winrm.cmd to configure TrustedHosts. Note that computers in
		/// the TrustedHosts list might not be authenticated. For more information on how to set TrustedHosts, run the following command:
		/// winrm help config
		/// </summary>
		ERROR_WSMAN_MUTUAL_AUTH_FAILED = 0x803381F0,

		/// <summary>The WinRM client cannot process the request because the octet string array type is not supported.</summary>
		ERROR_WSMAN_UNSUPPORTED_OCTETTYPE = 0x803381F1,

		/// <summary>The WS-Management service cannot process the request. The requested IdleTimeout is outside the allowed range.</summary>
		ERROR_WINRS_IDLETIMEOUT_OUTOFBOUNDS = 0x803381F2,

		/// <summary>
		/// The WinRM client cannot process the request because insufficient metadata is available. The application does not allow all
		/// properties to be returned as strings, but the server does not support correctly typing the properties. Change the request to
		/// allow all properties to be returned as strings and retry the request.
		/// </summary>
		ERROR_WSMAN_INSUFFICIENT_METADATA_FOR_BASIC = 0x803381F3,

		/// <summary>
		/// The WinRM client cannot process the request because the MI_OperationOptions contained both a Resource URI and a Resource URI
		/// Prefix. Specify only one of these two options and try again.
		/// </summary>
		ERROR_WSMAN_INVALID_LITERAL_URI = 0x803381F4,

		/// <summary>
		/// The WinRM client cannot process the request because keysOnly and WSMAN_ENUMERATIONMODE_OBJECTONLY were specified at the same
		/// time. These two settings are incompatible. Remove the WSMAN_ENUMERATIONMODE_OBJECTONLY option, or set keysOnly to MI_FALSE, and
		/// retry the request.
		/// </summary>
		ERROR_WSMAN_OBJECTONLY_INVALID = 0x803381F5,

		/// <summary>
		/// The WinRM client cannot process the request because the class name is not valid. Supply a valid class name or set the Resource
		/// URI option and retry the request.
		/// </summary>
		ERROR_WSMAN_MISSING_CLASSNAME = 0x803381F6,

		/// <summary>
		/// wsman, code=Sender, subcode=WS-Management UnsupportedFeature, details= /AddressingMode The subscribe packet contains an Encoding
		/// value that is not valid in the delivery section.
		/// </summary>
		ERROR_WSMAN_EVENTING_INVALID_ENCODING_IN_DELIVERY = 0x803381F7,

		/// <summary>
		/// The WinRM client cannot process the request. The destination computer name must be a hostname or an IP address, and must not be a
		/// URL. To use an IPv6 address, enclose the address in brackets, like the following: "[::1]". The transport, port number, and URL
		/// prefix may be controlled by setting the appropriate destination options. Change the destination computer name string and retry
		/// the operation.
		/// </summary>
		ERROR_WSMAN_DESTINATION_INVALID = 0x803381F8,

		/// <summary>
		/// The server does not support WS-Management Identify operations. Skip the TestConnection part of the request and try again.
		/// </summary>
		ERROR_WSMAN_UNSUPPORTED_FEATURE_IDENTIFY = 0x803381F9,

		/// <summary>
		/// The WS-Management service cannot process the operation. The operation is being attempted on a client session that is unusable.
		/// This may be related to a recent restart of the WS-Management service. Please create a new client session and retry the operation
		/// if re-executing the operation does not have undesired behavior.
		/// </summary>
		ERROR_WSMAN_CLIENT_SESSION_UNUSABLE = 0x803381FA,

		/// <summary>
		/// The WS-Management service cannot process the operation. An attempt to create a virtual account failed. Ensure that WinRM service
		/// is running as Local System and that it has TCB privilege enabled.
		/// </summary>
		ERROR_WSMAN_VIRTUALACCOUNT_NOTSUPPORTED = 0x803381FB,

		/// <summary>
		/// The WS-Management service cannot process the operation. Virtual account feature is only available in Windows 7, Server 2008 R2
		/// and above.
		/// </summary>
		ERROR_WSMAN_VIRTUALACCOUNT_NOTSUPPORTED_DOWNLEVEL = 0x803381FC,

		/// <summary>
		/// The WS-Management service cannot process the operation. An attempt to logon using the configured RunAs Managed Service Account failed.
		/// </summary>
		ERROR_WSMAN_RUNASUSER_MANAGEDACCOUNT_LOGON_FAILED = 0x803381FD,

		/// <summary>
		/// The WS-Management service cannot process the operation. An attempt to query mapped credential failed. This will happen if the
		/// security context associated with WinRM service has changed since the credential was originally mapped.
		/// </summary>
		ERROR_WSMAN_CERTMAPPING_CREDENTIAL_MANAGEMENT_FAILIED = 0x803381FE,

		/// <summary>The event source of the push subscription is in disable or inactive on the Event controller server.</summary>
		ERROR_WSMAN_EVENTING_PUSH_SUBSCRIPTION_NOACTIVATE_EVENTSOURCE = 0x803381FF,
	}
}