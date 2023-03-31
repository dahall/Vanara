namespace Vanara.PInvoke;

public static partial class FunDisc
{
#pragma warning disable CS1591
	///////////////////////////////////////////////////////////////////////////////
	// QUERY Constraint defines
	///////////////////////////////////////////////////////////////////////////////

	public const int MAX_FDCONSTRAINTNAME_LENGTH = 100;
	public const int MAX_FDCONSTRAINTVALUE_LENGTH = 1000;

	// Common Provider specific Constraints
	public const string FD_QUERYCONSTRAINT_PROVIDERINSTANCEID = "ProviderInstanceID";
	public const string FD_QUERYCONSTRAINT_SUBCATEGORY = "Subcategory";
	public const string FD_QUERYCONSTRAINT_RECURSESUBCATEGORY = "RecurseSubcategory";
	public const string FD_QUERYCONSTRAINT_VISIBILITY = "Visibility";
	// FD_CONSTRAINTVALUE_VISIBILITY_DEFAULT you want just default instances (visible as defined by the provider)
	// FD_CONSTRAINTVALUE_VISIBILITY_ALL (default) you want both visible and not visible/hidden instances (as defined by the provider)
	public const string FD_QUERYCONSTRAINT_COMCLSCONTEXT = "COMClsContext";
	public const string FD_QUERYCONSTRAINT_ROUTINGSCOPE = "RoutingScope";

	// Common Provider specific Constraints values
	public const string FD_CONSTRAINTVALUE_TRUE = "TRUE";
	public const string FD_CONSTRAINTVALUE_FALSE = "FALSE";
	public const string FD_CONSTRAINTVALUE_RECURSESUBCATEGORY_TRUE = FD_CONSTRAINTVALUE_TRUE;
	public const string FD_CONSTRAINTVALUE_VISIBILITY_DEFAULT = "0";
	public const string FD_CONSTRAINTVALUE_VISIBILITY_ALL = "1";
	public const string FD_CONSTRAINTVALUE_COMCLSCONTEXT_INPROC_SERVER = "1";
	public const string FD_CONSTRAINTVALUE_COMCLSCONTEXT_LOCAL_SERVER = "4";

	public const string FD_CONSTRAINTVALUE_PAIRED = "Paired";
	public const string FD_CONSTRAINTVALUE_UNPAIRED = "UnPaired";
	public const string FD_CONSTRAINTVALUE_ALL = "All";

	public const string FD_CONSTRAINTVALUE_ROUTINGSCOPE_ALL = "All";
	public const string FD_CONSTRAINTVALUE_ROUTINGSCOPE_DIRECT = "Direct";

	///////////////////////////////////////////////////////////////////////////////
	// Provider inquiry constraints
	public const string FD_QUERYCONSTRAINT_PAIRING_STATE = "PairingState";
	// if unset, provider default is FD_CONSTRAINTVALUE_PAIRED
	// FD_CONSTRAINTVALUE_PAIRED will return all paired devices
	// FD_CONSTRAINTVALUE_UNPAIRED will return all unpaired devices within wireless or wired range
	// FD_CONSTRAINTVALUE_ALL will return all devices cached and within wireless or wired range
	public const string FD_QUERYCONSTRAINT_INQUIRY_TIMEOUT = "InquiryModeTimeout";   // #seconds 6-600 supported, default is 300

	///////////////////////////////////////////////////////////////////////////////
	// PNP Provider specific Constraints
	public const string PROVIDERPNP_QUERYCONSTRAINT_INTERFACECLASS = "InterfaceClass";
	public const string PROVIDERPNP_QUERYCONSTRAINT_NOTPRESENT = "NotPresent";
	public const string PROVIDERPNP_QUERYCONSTRAINT_NOTIFICATIONSONLY = "NotifyOnly";
	// PNP_CONSTRAINTVALUE_NOTPRESENT you want "not present" instances as well
	// "FALSE" (default) you want only DIGCF_PRESENT instances.
	// PNP Provider specific Constraints values
	public const string PNP_CONSTRAINTVALUE_NOTPRESENT = FD_CONSTRAINTVALUE_TRUE;
	public const string PNP_CONSTRAINTVALUE_NOTIFICATIONSONLY = FD_CONSTRAINTVALUE_TRUE;

	///////////////////////////////////////////////////////////////////////////////
	// SSDP Provider specific Constraints
	public const string PROVIDERSSDP_QUERYCONSTRAINT_TYPE = "Type";
	public const string PROVIDERSSDP_QUERYCONSTRAINT_CUSTOMXMLPROPERTY = "CustomXmlProperty";

	// SSDP Provider specific Constraints values
	public const string SSDP_CONSTRAINTVALUE_TYPE_ALL = "ssdp:all";
	public const string SSDP_CONSTRAINTVALUE_TYPE_ROOT = "upnp:rootdevice";
	public const string SSDP_CONSTRAINTVALUE_TYPE_DEVICE_PREFIX = "urn:schemas-upnp-org:device:";
	public const string SSDP_CONSTRAINTVALUE_TYPE_SVC_PREFIX = "urn:schemas-upnp-org:service:";

	public const string SSDP_CONSTRAINTVALUE_TYPE_DEV_LIGHTING = SSDP_CONSTRAINTVALUE_TYPE_DEVICE_PREFIX + "Lighting:1";
	public const string SSDP_CONSTRAINTVALUE_TYPE_DEV_REMINDER = SSDP_CONSTRAINTVALUE_TYPE_DEVICE_PREFIX + "Reminder:1";
	public const string SSDP_CONSTRAINTVALUE_TYPE_DEV_POWERDEVICE = SSDP_CONSTRAINTVALUE_TYPE_DEVICE_PREFIX + "PowerDevice:1";
	public const string SSDP_CONSTRAINTVALUE_TYPE_DEV_IGD = SSDP_CONSTRAINTVALUE_TYPE_DEVICE_PREFIX + "InternetGatewayDevice:1";
	public const string SSDP_CONSTRAINTVALUE_TYPE_DEV_WANDEVICE = SSDP_CONSTRAINTVALUE_TYPE_DEVICE_PREFIX + "WANDevice:1";
	public const string SSDP_CONSTRAINTVALUE_TYPE_DEV_LANDEVICE = SSDP_CONSTRAINTVALUE_TYPE_DEVICE_PREFIX + "LANDevice:1";
	public const string SSDP_CONSTRAINTVALUE_TYPE_DEV_WANCONNDEVICE = SSDP_CONSTRAINTVALUE_TYPE_DEVICE_PREFIX + "WANConnectionDevice:1";
	public const string SSDP_CONSTRAINTVALUE_TYPE_DEV_LUXMETER = SSDP_CONSTRAINTVALUE_TYPE_DEVICE_PREFIX + "Luxmeter:1";
	public const string SSDP_CONSTRAINTVALUE_TYPE_DEV_MDARNDR = SSDP_CONSTRAINTVALUE_TYPE_DEVICE_PREFIX + "MediaRenderer:1";
	public const string SSDP_CONSTRAINTVALUE_TYPE_DEV_MDASRVR = SSDP_CONSTRAINTVALUE_TYPE_DEVICE_PREFIX + "MediaServer:1";

	public const string SSDP_CONSTRAINTVALUE_TYPE_SVC_SCANNER = SSDP_CONSTRAINTVALUE_TYPE_SVC_PREFIX + "Scanner:1";
	public const string SSDP_CONSTRAINTVALUE_TYPE_SVC_DIMMING = SSDP_CONSTRAINTVALUE_TYPE_SVC_PREFIX + "DimmingService:1";

	///////////////////////////////////////////////////////////////////////////////
	// WSD Provider specific Constraints
	public const string PROVIDERWSD_QUERYCONSTRAINT_DIRECTEDADDRESS = "RemoteAddress";
	public const string PROVIDERWSD_QUERYCONSTRAINT_TYPE = "Type";
	public const string PROVIDERWSD_QUERYCONSTRAINT_SCOPE = "Scope";
	public const string PROVIDERWSD_QUERYCONSTRAINT_SECURITY_REQUIREMENTS = "SecurityRequirements";
	public const string PROVIDERWSD_QUERYCONSTRAINT_SSL_CERT_FOR_CLIENT_AUTH = "SSLClientAuthCert";
	public const string PROVIDERWSD_QUERYCONSTRAINT_SSL_CERTHASH_FOR_SERVER_AUTH = "SSLServerAuthCertHash";

	// WSD provider specific Constraint values
	public const string WSD_CONSTRAINTVALUE_REQUIRE_SECURECHANNEL = "1";
	public const string WSD_CONSTRAINTVALUE_REQUIRE_SECURECHANNEL_AND_COMPACTSIGNATURE = "2";
	public const string WSD_CONSTRAINTVALUE_NO_TRUST_VERIFICATION = "3";

	///////////////////////////////////////////////////////////////////////////////
	// NetBios Provider specific Constraints
	public const string PROVIDERWNET_QUERYCONSTRAINT_TYPE = "Type";
	public const string PROVIDERWNET_QUERYCONSTRAINT_PROPERTIES = "Properties";
	public const string PROVIDERWNET_QUERYCONSTRAINT_RESOURCETYPE = "ResourceType";

	public const string WNET_CONSTRAINTVALUE_TYPE_ALL = "All";
	public const string WNET_CONSTRAINTVALUE_TYPE_SERVER = "Server";   // Default;
	public const string WNET_CONSTRAINTVALUE_TYPE_DOMAIN = "Domain";

	public const string WNET_CONSTRAINTVALUE_PROPERTIES_ALL = "All";
	public const string WNET_CONSTRAINTVALUE_PROPERTIES_LIMITED = "Limited";  // Default;

	public const string WNET_CONSTRAINTVALUE_RESOURCETYPE_DISK = "Disk";             // All non-printer shares (dwDisplayType == RESOURCEDISPLAYTYPE_SHARE and dwType != RESOURCETYPE_PRINT);
	public const string WNET_CONSTRAINTVALUE_RESOURCETYPE_PRINTER = "Printer";          // All printer shares (dwDisplayType == RESOURCEDISPLAYTYPE_SHARE and dwType == RESOURCETYPE_PRINT);
	public const string WNET_CONSTRAINTVALUE_RESOURCETYPE_DISKORPRINTER = "DiskOrPrinter";    // All shares (dwDisplayType == RESOURCEDISPLAYTYPE_SHARE);

	public const string ONLINE_PROVIDER_DEVICES_QUERYCONSTRAINT_OWNERNAME = "OwnerName";

	///////////////////////////////////////////////////////////////////////////////
	// Device Display Object Provider specific Constraints
	public const string PROVIDERDDO_QUERYCONSTRAINT_DEVICEFUNCTIONDISPLAYOBJECTS = "DeviceFunctionDisplayObjects";
	public const string PROVIDERDDO_QUERYCONSTRAINT_ONLYCONNECTEDDEVICES = "OnlyConnectedDevices";
	public const string PROVIDERDDO_QUERYCONSTRAINT_DEVICEINTERFACES = "DeviceInterfaces";

	/// <summary>
	/// <para>
	/// [Function Discovery is available for use in the operating systems specified in the Requirements section. It may be altered or
	/// unavailable in subsequent versions.]
	/// </para>
	/// <para>
	/// Qualifies the filter conditions used for searching for function instances. This enumeration is used when adding a constraint to
	/// a query using the IFunctionInstanceCollectionQuery::AddPropertyConstraint method.
	/// </para>
	/// <para>
	/// A function instance will only match a property constraint when the property key (PKEY) passed to AddPropertyConstraint has the
	/// same PROPVARIANT type as the PKEY in the function instance's property store and the PROPVARIANT value satisfies the constraint's
	/// filter conditions.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/functiondiscoveryconstraints/ne-functiondiscoveryconstraints-propertyconstraint
	// typedef enum tagPropertyConstraint { QC_EQUALS, QC_NOTEQUAL, QC_LESSTHAN, QC_LESSTHANOREQUAL, QC_GREATERTHAN,
	// QC_GREATERTHANOREQUAL, QC_STARTSWITH, QC_EXISTS, QC_DOESNOTEXIST, QC_CONTAINS } PropertyConstraint;
	[PInvokeData("functiondiscoveryconstraints.h", MSDNShortId = "NE:functiondiscoveryconstraints.tagPropertyConstraint")]
	public enum PropertyConstraint
	{
		/// <summary>The constraint's PKEY and the function instance's PKEY must be equal.</summary>
		QC_EQUALS,

		/// <summary>The constraint's PKEY and the function instance's PKEY must not be equal.</summary>
		QC_NOTEQUAL,

		/// <summary>The constraint's PKEY must be less than the function instance's PKEY. This value can be used only with numbers.</summary>
		QC_LESSTHAN,

		/// <summary>
		/// The constraint's PKEY must be less than or equal to the function instance's PKEY. This value can be used only with numbers.
		/// </summary>
		QC_LESSTHANOREQUAL,

		/// <summary>The constraint's PKEY must be greater than the function instance's PKEY. This value can be used only with numbers.</summary>
		QC_GREATERTHAN,

		/// <summary>
		/// The constraint's PKEY must be greater than or equal to the function instance's PKEY. This value can be used only with numbers.
		/// </summary>
		QC_GREATERTHANOREQUAL,

		/// <summary>
		/// The constraint's PKEY must be the start of the function instance's PKEY. This value can be used with strings only.
		/// </summary>
		QC_STARTSWITH,

		/// <summary>The property must exist.</summary>
		QC_EXISTS,

		/// <summary>The property must not exist.</summary>
		QC_DOESNOTEXIST,

		/// <summary>
		/// The constraint's PKEY value must be contained within the function instance's PKEY value. This filter is only supported for
		/// PROPVARIANTs of type VT_LPWSTR or VT_VECTOR
		/// </summary>
		QC_CONTAINS,
	}
}