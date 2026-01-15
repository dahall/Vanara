using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.PortableDeviceApi;

namespace Vanara.PInvoke;

/// <summary>Elements from the Enhanced Storage API.</summary>
public static partial class EnhancedStorage
    {
        /// <summary>Identifier used to communicate support for RSA 1024 bit keys.</summary>
        public const string CERT_RSA_1024_OID = "1.2.840.113549.1.1.1,1024";

        /// <summary>Identifier used to communicate support for RSA 2048 bit keys.</summary>
        public const string CERT_RSA_2048_OID = "1.2.840.113549.1.1.1,2048";

        /// <summary>Identifier used to communicate support for RSA 3072 bit keys.</summary>
        public const string CERT_RSA_3072_OID = "1.2.840.113549.1.1.1,3072";

        /// <summary>Identifier used to communicate support for RSASSA PSS-SHA-1 signature algorithm.</summary>
        public const string CERT_RSASSA_PSS_SHA1_OID = "1.2.840.113549.1.1.10,1.3.14.3.2.26";

        /// <summary>Identifier used to communicate support for RSASSA PSS-SHA-256 signature algorithm.</summary>
        public const string CERT_RSASSA_PSS_SHA256_OID = "1.2.840.113549.1.1.10,2.16.840.1.101.3.4.2.1";

        /// <summary>Identifier used to communicate support for RSASSA PSS-SHA-384 signature algorithm.</summary>
        public const string CERT_RSASSA_PSS_SHA384_OID = "1.2.840.113549.1.1.10,2.16.840.1.101.3.4.2.2";

        /// <summary>Identifier used to communicate support for RSASSA PSS-SHA-512 signature algorithm.</summary>
        public const string CERT_RSASSA_PSS_SHA512_OID = "1.2.840.113549.1.1.10,2.16.840.1.101.3.4.2.3";

        /// <summary>
        /// <code>
        ///ENHANCED_STORAGE_CAPABILITY_ASYMMETRIC_KEY_CRYPTOGRAPHY
        ///[VT_LPWSTR] Semi-colon delimited string of asymmetric key cryptography supported
        /// </code>
        /// </summary>
        [CorrespondingType(typeof(LPWSTR))]
        public static readonly PROPERTYKEY ENHANCED_STORAGE_CAPABILITY_ASYMMETRIC_KEY_CRYPTOGRAPHY = new(new Guid(0x91248166, 0xb832, 0x4ad4, 0xba, 0xa4, 0x7c, 0xa0, 0xb6, 0xb2, 0x79, 0x8c), 4002);

        /// <summary>
        /// <code>
        ///ENHANCED_STORAGE_CAPABILITY_CERTIFICATE_EXTENSION_PARSING
        ///[ VT_BOOL ] Boolean indicating whether certificate extension fields are supported
        /// </code>
        /// </summary>
        [CorrespondingType(typeof(bool))]
        public static readonly PROPERTYKEY ENHANCED_STORAGE_CAPABILITY_CERTIFICATE_EXTENSION_PARSING = new(new Guid(0x91248166, 0xb832, 0x4ad4, 0xba, 0xa4, 0x7c, 0xa0, 0xb6, 0xb2, 0x79, 0x8c), 4005);

        /// <summary>
        /// <code>
        ///ENHANCED_STORAGE_CAPABILITY_HASH_ALGS
        ///[VT_LPWSTR] Semi-colon delimited string of hash algorithm identifiers
        /// </code>
        /// </summary>
        [CorrespondingType(typeof(LPWSTR))]
        public static readonly PROPERTYKEY ENHANCED_STORAGE_CAPABILITY_HASH_ALGS = new(new Guid(0x91248166, 0xb832, 0x4ad4, 0xba, 0xa4, 0x7c, 0xa0, 0xb6, 0xb2, 0x79, 0x8c), 4001);

        /// <summary>
        /// <code>
        ///ENHANCED_STORAGE_CAPABILITY_RENDER_USER_DATA_UNUSABLE
        ///[ VT_BOOL ] Boolean indicating whether silo can render user data unusable
        /// </code>
        /// </summary>
        [CorrespondingType(typeof(bool))]
        public static readonly PROPERTYKEY ENHANCED_STORAGE_CAPABILITY_RENDER_USER_DATA_UNUSABLE = new(new Guid(0x91248166, 0xb832, 0x4ad4, 0xba, 0xa4, 0x7c, 0xa0, 0xb6, 0xb2, 0x79, 0x8c), 4004);

        /// <summary>
        /// <code>
        ///ENHANCED_STORAGE_CAPABILITY_SIGNING_ALGS
        ///[VT_LPWSTR] Semi-colon delimited string of signing algorithm identifiers
        /// </code>
        /// </summary>
        [CorrespondingType(typeof(LPWSTR))]
        public static readonly PROPERTYKEY ENHANCED_STORAGE_CAPABILITY_SIGNING_ALGS = new(new Guid(0x91248166, 0xb832, 0x4ad4, 0xba, 0xa4, 0x7c, 0xa0, 0xb6, 0xb2, 0x79, 0x8c), 4003);

        /// <summary>
        /// <code>
        ///ENHANCED_STORAGE_COMMAND_CERT_ADMIN_CERTIFICATE_AUTHENTICATION
        ///This command will attempt to do an admin authentication based on the PCp
        ///(or XCp) from the device.
        ///This is an admin command - it requires both read and write access.
        ///Access:
        ///(FILE_READ_ACCESS | FILE_WRITE_ACCESS)
        ///Parameters:
        ///None
        ///Results:
        ///WPD_PROPERTY_COMMON_HRESULT
        /// </code>
        /// </summary>
        [WPDCommand(WPD_COMMAND_ACCESS_TYPES.WPD_COMMAND_ACCESS_READWRITE)]
        [WPDCommandResult(nameof(WPD_PROPERTY_COMMON_HRESULT), true)]
        public static readonly PROPERTYKEY ENHANCED_STORAGE_COMMAND_CERT_ADMIN_CERTIFICATE_AUTHENTICATION = new(new Guid(0x91248166, 0xb832, 0x4ad4, 0xba, 0xa4, 0x7c, 0xa0, 0xb6, 0xb2, 0x79, 0x8c), 103);

        /// <summary>
        /// <code>
        ///ENHANCED_STORAGE_COMMAND_CERT_CREATE_CERTIFICATE_REQUEST
        ///This command will esk the device to create a certificate request.
        ///This will then be signed by the application's chosen CA.
        ///Access:
        ///(FILE_READ_ACCESS | FILE_WRITE_ACCESS)
        ///Parameters:
        ///None.
        ///Results:
        ///WPD_PROPERTY_COMMON_HRESULT
        ///ENHANCED_STORAGE_PROPERTY_CERTIFICATE_REQUEST [VT_VECTOR | VT_UI1]
        /// </code>
        /// </summary>
        [WPDCommand(WPD_COMMAND_ACCESS_TYPES.WPD_COMMAND_ACCESS_READWRITE)]
        [WPDCommandResult(nameof(WPD_PROPERTY_COMMON_HRESULT), true)]
        [WPDCommandResult(nameof(ENHANCED_STORAGE_PROPERTY_CERTIFICATE_REQUEST), true)]
        public static readonly PROPERTYKEY ENHANCED_STORAGE_COMMAND_CERT_CREATE_CERTIFICATE_REQUEST = new(new Guid(0x91248166, 0xb832, 0x4ad4, 0xba, 0xa4, 0x7c, 0xa0, 0xb6, 0xb2, 0x79, 0x8c), 108);

        /// <summary>
        /// <code>
        ///DEVICE_AUTHENTICATION
        ///ENHANCED_STORAGE_COMMAND_CERT_DEVICE_CERTIFICATE_AUTHENTICATION
        ///This command will attempt to do a device authentication operation. If
        ///an index or certificate is specified, it will use that certificate. It
        ///must be ASCm or ASCh.
        ///The default behavior is to authenticate ASCm.
        ///Access:
        ///(FILE_READ_ACCESS)
        ///Parameters:
        ///[ Optional ] ENHANCED_STORAGE_PROPERTY_CERTIFICATE_INDEX [VT_UINT]
        ///[ Optional ] ENHANCED_STORAGE_PROPERTY_CERTIFICATE [VT_VECTOR | VT_UI1]
        ///Results:
        ///WPD_PROPERTY_COMMON_HRESULT
        /// </code>
        /// </summary>
        [WPDCommand]
        [WPDCommandParam(nameof(ENHANCED_STORAGE_PROPERTY_CERTIFICATE_INDEX), false)]
        [WPDCommandParam(nameof(ENHANCED_STORAGE_PROPERTY_CERTIFICATE), false)]
        [WPDCommandResult(nameof(WPD_PROPERTY_COMMON_HRESULT), true)]
        public static readonly PROPERTYKEY ENHANCED_STORAGE_COMMAND_CERT_DEVICE_CERTIFICATE_AUTHENTICATION = new(new Guid(0x91248166, 0xb832, 0x4ad4, 0xba, 0xa4, 0x7c, 0xa0, 0xb6, 0xb2, 0x79, 0x8c), 102);

        /// <summary>
        /// <code>
        ///ENHANCED_STORAGE_COMMAND_CERT_GET_ACT_FRIENDLY_NAME
        ///This command will return the friendly name of the ACT containing the silo.
        ///Access:
        ///(FILE_READ_ACCESS)
        ///Parameters:
        ///None.
        ///Results:
        ///WPD_PROPERTY_COMMON_HRESULT
        ///[optional] ENHANCED_STORAGE_PROPERTY_CERTIFICATE_ACT_FRIENDLY_NAME [VT_LPWSTR]
        /// </code>
        /// </summary>
        [WPDCommand]
        [WPDCommandResult(nameof(WPD_PROPERTY_COMMON_HRESULT), true)]
        [WPDCommandResult(nameof(ENHANCED_STORAGE_PROPERTY_CERTIFICATE_ACT_FRIENDLY_NAME), false)]
        public static readonly PROPERTYKEY ENHANCED_STORAGE_COMMAND_CERT_GET_ACT_FRIENDLY_NAME = new(new Guid(0x91248166, 0xb832, 0x4ad4, 0xba, 0xa4, 0x7c, 0xa0, 0xb6, 0xb2, 0x79, 0x8c), 113);

        /// <summary>
        /// <code>
        ///ENHANCED_STORAGE_COMMAND_CERT_GET_CERTIFICATE
        ///This command will return the certificate at the certificate index location.
        ///Index 0 is a special location that returns the ASCm chain in PKCS7 format.
        ///Access:
        ///(FILE_READ_ACCESS)
        ///Parameters:
        ///[ Required ] ENHANCED_STORAGE_PROPERTY_CERTIFICATE_INDEX [VT_UINT]
        ///Results:
        ///WPD_PROPERTY_COMMON_HRESULT
        ///ENHANCED_STORAGE_PROPERTY_CERTIFICATE_TYPE [VT_UINT]
        ///ENHANCED_STORAGE_PROPERTY_VALIDATION_POLICY [VT_UINT]
        ///ENHANCED_STORAGE_PROPERTY_SIGNER_CERTIFICATE_INDEX [VT_UINT]
        ///ENHANCED_STORAGE_PROPERTY_NEXT_CERTIFICATE_INDEX [VT_UINT]
        ///ENHANCED_STORAGE_PROPERTY_NEXT_CERTIFICATE_OF_TYPE_INDEX [VT_UINT]
        ///ENHANCED_STORAGE_PROPERTY_CERTIFICATE_LENGTH [VT_UINT]
        ///ENHANCED_STORAGE_PROPERTY_CERTIFICATE [VT_VECTOR | VT_UI1]
        /// </code>
        /// </summary>
        [WPDCommand]
        [WPDCommandParam(nameof(ENHANCED_STORAGE_PROPERTY_CERTIFICATE_INDEX), true)]
        [WPDCommandResult(nameof(WPD_PROPERTY_COMMON_HRESULT), true)]
        [WPDCommandResult(nameof(ENHANCED_STORAGE_PROPERTY_CERTIFICATE_TYPE), true)]
        [WPDCommandResult(nameof(ENHANCED_STORAGE_PROPERTY_VALIDATION_POLICY), true)]
        [WPDCommandResult(nameof(ENHANCED_STORAGE_PROPERTY_SIGNER_CERTIFICATE_INDEX), true)]
        [WPDCommandResult(nameof(ENHANCED_STORAGE_PROPERTY_NEXT_CERTIFICATE_INDEX), true)]
        [WPDCommandResult(nameof(ENHANCED_STORAGE_PROPERTY_NEXT_CERTIFICATE_OF_TYPE_INDEX), true)]
        [WPDCommandResult(nameof(ENHANCED_STORAGE_PROPERTY_CERTIFICATE_LENGTH), true)]
        [WPDCommandResult(nameof(ENHANCED_STORAGE_PROPERTY_CERTIFICATE), true)]
        public static readonly PROPERTYKEY ENHANCED_STORAGE_COMMAND_CERT_GET_CERTIFICATE = new(new Guid(0x91248166, 0xb832, 0x4ad4, 0xba, 0xa4, 0x7c, 0xa0, 0xb6, 0xb2, 0x79, 0x8c), 106);

        /// <summary>
        /// <code>
        ///ENHANCED_STORAGE_COMMAND_CERT_GET_CERTIFICATE_COUNT
        ///This command will get the number of certificate slots on the device.
        ///Access:
        ///(FILE_READ_ACCESS)
        ///Parameters:
        ///none.
        ///Results:
        ///WPD_PROPERTY_COMMON_HRESULT
        ///ENHANCED_STORAGE_PROPERTY_MAX_CERTIFICATE_COUNT [VT_UINT]
        ///ENHANCED_STORAGE_PROPERTY_STORED_CERTIFICATE_COUNT [VT_UINT]
        /// </code>
        /// </summary>
        [WPDCommand]
        [WPDCommandResult(nameof(WPD_PROPERTY_COMMON_HRESULT), true)]
        [WPDCommandResult(nameof(ENHANCED_STORAGE_PROPERTY_MAX_CERTIFICATE_COUNT), true)]
        [WPDCommandResult(nameof(ENHANCED_STORAGE_PROPERTY_STORED_CERTIFICATE_COUNT), true)]
        public static readonly PROPERTYKEY ENHANCED_STORAGE_COMMAND_CERT_GET_CERTIFICATE_COUNT = new(new Guid(0x91248166, 0xb832, 0x4ad4, 0xba, 0xa4, 0x7c, 0xa0, 0xb6, 0xb2, 0x79, 0x8c), 105);

        /// <summary>
        /// <code>
        ///ENHANCED_STORAGE_COMMAND_CERT_GET_SILO_CAPABILITIES
        ///This command will return the silo capabilities as a collection of
        ///capabilities.
        ///Access:
        ///(FILE_READ_ACCESS)
        ///Parameters:
        ///None.
        ///Results:
        ///WPD_PROPERTY_COMMON_HRESULT
        ///ENHANCED_STORAGE_PROPERTY_CERTIFICATE_SILO_CAPABILITIES [VT_UNKNOWN]
        ///- ENHANCED_STORAGE_CAPABILITY_HASH_ALGS [VT_LPWSTR - semi-colon delimited]
        ///- ENHANCED_STORAGE_CAPABILITY_ASYMMETRIC_KEY_CRYPTOGRAPHY [VT_LPWSTR - semi-colon delimited]
        ///- ENHANCED_STORAGE_CAPABILITY_SIGNING_ALGS [VT_LPWSTR - semi-colon delimited]
        ///- ENHANCED_STORAGE_CAPABILITY_RENDER_USER_DATA_UNUSABLE [ VT_BOOL ]
        ///- ENHANCED_STORAGE_CAPABILITY_CERTIFICATE_EXTENSION_PARSING [ VT_BOOL ]
        /// </code>
        /// </summary>
        [WPDCommand]
        [WPDCommandResult(nameof(WPD_PROPERTY_COMMON_HRESULT), true)]
        [WPDCommandResult(nameof(ENHANCED_STORAGE_PROPERTY_CERTIFICATE_SILO_CAPABILITIES), true)]
        [WPDCommandResult(nameof(ENHANCED_STORAGE_CAPABILITY_HASH_ALGS), true)]
        [WPDCommandResult(nameof(ENHANCED_STORAGE_CAPABILITY_ASYMMETRIC_KEY_CRYPTOGRAPHY), true)]
        [WPDCommandResult(nameof(ENHANCED_STORAGE_CAPABILITY_SIGNING_ALGS), true)]
        [WPDCommandResult(nameof(ENHANCED_STORAGE_PROPERTY_NEXT_CERTIFICATE_OF_TYPE_INDEX), true)]
        [WPDCommandResult(nameof(ENHANCED_STORAGE_CAPABILITY_RENDER_USER_DATA_UNUSABLE), true)]
        [WPDCommandResult(nameof(ENHANCED_STORAGE_CAPABILITY_CERTIFICATE_EXTENSION_PARSING), true)]
        public static readonly PROPERTYKEY ENHANCED_STORAGE_COMMAND_CERT_GET_SILO_CAPABILITIES = new(new Guid(0x91248166, 0xb832, 0x4ad4, 0xba, 0xa4, 0x7c, 0xa0, 0xb6, 0xb2, 0x79, 0x8c), 112);

        /// <summary>
        /// <code>
        ///ENHANCED_STORAGE_COMMAND_CERT_GET_SILO_CAPABILITY
        ///This command will issue a command to get a silo capability from the
        ///silo. Data returned is in the format returned from the silo.
        ///Access:
        ///(FILE_READ_ACCESS)
        ///Parameters:
        ///[ Required ] ENHANCED_STORAGE_PROPERTY_CERTIFICATE_CAPABILITY_TYPE [VT_UINT]
        ///Results:
        ///WPD_PROPERTY_COMMON_HRESULT
        ///ENHANCED_STORAGE_PROPERTY_CERTIFICATE_SILO_CAPABILITY [VT_VECTOR | VT_UI1]
        /// </code>
        /// </summary>
        [WPDCommand]
        [WPDCommandParam(nameof(ENHANCED_STORAGE_PROPERTY_CERTIFICATE_CAPABILITY_TYPE), true)]
        [WPDCommandResult(nameof(WPD_PROPERTY_COMMON_HRESULT), true)]
        [WPDCommandResult(nameof(ENHANCED_STORAGE_PROPERTY_CERTIFICATE_SILO_CAPABILITY), true)]
        public static readonly PROPERTYKEY ENHANCED_STORAGE_COMMAND_CERT_GET_SILO_CAPABILITY = new(new Guid(0x91248166, 0xb832, 0x4ad4, 0xba, 0xa4, 0x7c, 0xa0, 0xb6, 0xb2, 0x79, 0x8c), 111);

        /// <summary>
        /// <code>
        ///ENHANCED_STORAGE_COMMAND_CERT_GET_SILO_GUID
        ///This command will return the silo's GUID.
        ///Access:
        ///(FILE_READ_ACCESS)
        ///Parameters:
        ///None.
        ///Results:
        ///WPD_PROPERTY_COMMON_HRESULT
        ///ENHANCED_STORAGE_PROPERTY_CERTIFICATE_SILO_GUID [VT_LPWSTR]
        /// </code>
        /// </summary>
        [WPDCommand]
        [WPDCommandResult(nameof(WPD_PROPERTY_COMMON_HRESULT), true)]
        [WPDCommandResult(nameof(ENHANCED_STORAGE_PROPERTY_CERTIFICATE_SILO_GUID), true)]
        public static readonly PROPERTYKEY ENHANCED_STORAGE_COMMAND_CERT_GET_SILO_GUID = new(new Guid(0x91248166, 0xb832, 0x4ad4, 0xba, 0xa4, 0x7c, 0xa0, 0xb6, 0xb2, 0x79, 0x8c), 114);

        /// <summary>
        /// <code>
        ///ENHANCED_STORAGE_COMMAND_CERT_HOST_CERTIFICATE_AUTHENTICATION
        ///This command will attempt to do a host authentication based on an HCh
        ///(or XCh) from the device. If an index or certificate is specified, it
        ///will use that certificate.
        ///The default behavior is to authenticate any of the HCh certs present on
        ///the device if possible (or XCh.)
        ///Access:
        ///(FILE_READ_ACCESS)
        ///Parameters:
        ///[ Optional ] ENHANCED_STORAGE_PROPERTY_CERTIFICATE_INDEX [VT_UINT]
        ///[ Optional ] ENHANCED_STORAGE_PROPERTY_CERTIFICATE [VT_VECTOR | VT_UI1]
        ///Results:
        ///WPD_PROPERTY_COMMON_HRESULT
        /// </code>
        /// </summary>
        [WPDCommand]
        [WPDCommandParam(nameof(ENHANCED_STORAGE_PROPERTY_CERTIFICATE_INDEX), false)]
        [WPDCommandParam(nameof(ENHANCED_STORAGE_PROPERTY_CERTIFICATE), false)]
        [WPDCommandResult(nameof(WPD_PROPERTY_COMMON_HRESULT), true)]
        public static readonly PROPERTYKEY ENHANCED_STORAGE_COMMAND_CERT_HOST_CERTIFICATE_AUTHENTICATION = new(new Guid(0x91248166, 0xb832, 0x4ad4, 0xba, 0xa4, 0x7c, 0xa0, 0xb6, 0xb2, 0x79, 0x8c), 101);

        /// <summary>
        /// <code>
        ///ENHANCED_STORAGE_COMMAND_CERT_INITIALIZE_TO_MANUFACTURER_STATE
        ///This command will attempt to initialized to the manufacturer state.
        ///Requires PCp authentication.
        ///Access:
        ///(FILE_READ_ACCESS | FILE_WRITE_ACCESS)
        ///Parameters:
        ///None.
        ///Results:
        ///WPD_PROPERTY_COMMON_HRESULT
        /// </code>
        /// </summary>
        [WPDCommand(WPD_COMMAND_ACCESS_TYPES.WPD_COMMAND_ACCESS_READWRITE)]
        [WPDCommandResult(nameof(WPD_PROPERTY_COMMON_HRESULT), true)]
        public static readonly PROPERTYKEY ENHANCED_STORAGE_COMMAND_CERT_INITIALIZE_TO_MANUFACTURER_STATE = new(new Guid(0x91248166, 0xb832, 0x4ad4, 0xba, 0xa4, 0x7c, 0xa0, 0xb6, 0xb2, 0x79, 0x8c), 104);

        /// <summary>
        /// <code>
        ///ENHANCED_STORAGE_COMMAND_CERT_SET_CERTIFICATE
        ///This command will set a certificate to the certificate index location.
        ///Requires admin authentication.
        ///Access:
        ///(FILE_READ_ACCESS | FILE_WRITE_ACCESS)
        ///Parameters:
        ///[ Required ] ENHANCED_STORAGE_PROPERTY_CERTIFICATE_INDEX [VT_UINT]
        ///[ Required ] ENHANCED_STORAGE_PROPERTY_CERTIFICATE_TYPE [VT_UINT]
        ///[ Required ] ENHANCED_STORAGE_PROPERTY_VALIDATION_POLICY [VT_UINT]
        ///[ Required ] ENHANCED_STORAGE_PROPERTY_SIGNER_CERTIFICATE_INDEX [VT_UINT]
        ///[ Required ] ENHANCED_STORAGE_PROPERTY_CERTIFICATE [VT_VECTOR | VT_UI1]
        ///Results:
        ///WPD_PROPERTY_COMMON_HRESULT
        /// </code>
        /// </summary>
        [WPDCommand(WPD_COMMAND_ACCESS_TYPES.WPD_COMMAND_ACCESS_READWRITE)]
        [WPDCommandParam(nameof(ENHANCED_STORAGE_PROPERTY_CERTIFICATE_INDEX), true)]
        [WPDCommandParam(nameof(ENHANCED_STORAGE_PROPERTY_CERTIFICATE_TYPE), true)]
        [WPDCommandParam(nameof(ENHANCED_STORAGE_PROPERTY_VALIDATION_POLICY), true)]
        [WPDCommandParam(nameof(ENHANCED_STORAGE_PROPERTY_SIGNER_CERTIFICATE_INDEX), true)]
        [WPDCommandParam(nameof(ENHANCED_STORAGE_PROPERTY_CERTIFICATE), true)]
        [WPDCommandResult(nameof(WPD_PROPERTY_COMMON_HRESULT), true)]
        public static readonly PROPERTYKEY ENHANCED_STORAGE_COMMAND_CERT_SET_CERTIFICATE = new(new Guid(0x91248166, 0xb832, 0x4ad4, 0xba, 0xa4, 0x7c, 0xa0, 0xb6, 0xb2, 0x79, 0x8c), 107);

        /// <summary>
        /// <code>
        ///ENHANCED_STORAGE_COMMAND_CERT_UNAUTHENTICATION
        ///This command will issue a command to set the cert silo to the
        ///initialized state.
        ///Access:
        ///(FILE_READ_ACCESS | FILE_WRITE_ACCESS)
        ///Parameters:
        ///[ Optional ] ENHANCED_STORAGE_PROPERTY_TEMPORARY_UNAUTHENTICATION
        ///Results:
        ///WPD_PROPERTY_COMMON_HRESULT
        /// </code>
        /// </summary>
        [WPDCommand(WPD_COMMAND_ACCESS_TYPES.WPD_COMMAND_ACCESS_READWRITE)]
        [WPDCommandParam(nameof(ENHANCED_STORAGE_PROPERTY_TEMPORARY_UNAUTHENTICATION), false)]
        [WPDCommandResult(nameof(WPD_PROPERTY_COMMON_HRESULT), true)]
        public static readonly PROPERTYKEY ENHANCED_STORAGE_COMMAND_CERT_UNAUTHENTICATION = new(new Guid(0x91248166, 0xb832, 0x4ad4, 0xba, 0xa4, 0x7c, 0xa0, 0xb6, 0xb2, 0x79, 0x8c), 110);

        /// <summary>
        /// <code>
        ///ENHANCED_STORAGE_COMMAND_PASSWORD_AUTHORIZE_ACT_ACCESS
        ///This command attempts to authenticate to the silo for ACT's data access
        ///Access:
        ///(FILE_READ_ACCESS | FILE_WRITE_ACCESS)
        ///Parameters:
        ///[ Required ] ENHANCED_STORAGE_PROPERTY_PASSWORD
        ///[ Required ] ENHANCED_STORAGE_PROPERTY_PASSWORD_INDICATOR
        ///Results:
        ///WPD_PROPERTY_COMMON_HRESULT - status code for the operation
        /// </code>
        /// </summary>
        [WPDCommand(WPD_COMMAND_ACCESS_TYPES.WPD_COMMAND_ACCESS_READWRITE)]
        [WPDCommandParam(nameof(ENHANCED_STORAGE_PROPERTY_PASSWORD), true)]
        [WPDCommandParam(nameof(ENHANCED_STORAGE_PROPERTY_PASSWORD_INDICATOR), true)]
        [WPDCommandResult(nameof(WPD_PROPERTY_COMMON_HRESULT), true)]
        public static readonly PROPERTYKEY ENHANCED_STORAGE_COMMAND_PASSWORD_AUTHORIZE_ACT_ACCESS = new(new Guid(0x91248166, 0xb832, 0x4ad4, 0xba, 0xa4, 0x7c, 0xa0, 0xb6, 0xb2, 0x79, 0x8c), 203);

        /// <summary>
        /// <code>
        ///ENHANCED_STORAGE_COMMAND_PASSWORD_CHANGE_PASSWORD
        ///This command changes the password for adminstritor or user account
        ///Access:
        ///(FILE_READ_ACCESS | FILE_WRITE_ACCESS)
        ///Parameters:
        ///[ Required ] ENHANCED_STORAGE_PROPERTY_PASSWORD_INDICATOR
        ///[ Required ] ENHANCED_STORAGE_PROPERTY_PASSWORD
        ///[ Required ] ENHANCED_STORAGE_PROPERTY_NEW_PASSWORD
        ///[ Required ] ENHANCED_STORAGE_PROPERTY_NEW_HINT
        ///[ Required ] ENHANCED_STORAGE_PROPERTY_NEW_PASSWORD_INDICATOR
        ///[ Optional ] ENHANCED_STORAGE_PROPERTY_SECURITY_IDENTIFIER
        ///Results:
        ///WPD_PROPERTY_COMMON_HRESULT - status code for the operation
        /// </code>
        /// </summary>
        [WPDCommand(WPD_COMMAND_ACCESS_TYPES.WPD_COMMAND_ACCESS_READWRITE)]
        [WPDCommandParam(nameof(ENHANCED_STORAGE_PROPERTY_PASSWORD_INDICATOR), true)]
        [WPDCommandParam(nameof(ENHANCED_STORAGE_PROPERTY_PASSWORD), true)]
        [WPDCommandParam(nameof(ENHANCED_STORAGE_PROPERTY_NEW_PASSWORD), true)]
        [WPDCommandParam(nameof(ENHANCED_STORAGE_PROPERTY_USER_HINT), true)]
        [WPDCommandParam(nameof(ENHANCED_STORAGE_PROPERTY_NEW_PASSWORD_INDICATOR), true)]
        [WPDCommandParam(nameof(ENHANCED_STORAGE_PROPERTY_SECURITY_IDENTIFIER), false)]
        [WPDCommandResult(nameof(WPD_PROPERTY_COMMON_HRESULT), true)]
        public static readonly PROPERTYKEY ENHANCED_STORAGE_COMMAND_PASSWORD_CHANGE_PASSWORD = new(new Guid(0x91248166, 0xb832, 0x4ad4, 0xba, 0xa4, 0x7c, 0xa0, 0xb6, 0xb2, 0x79, 0x8c), 209);

        /// <summary>
        /// <code>
        ///ENHANCED_STORAGE_COMMAND_PASSWORD_CONFIG_ADMINISTRATOR
        ///This command configures the administrator account
        ///Access:
        ///(FILE_READ_ACCESS | FILE_WRITE_ACCESS)
        ///Parameters:
        ///[ Optional ] ENHANCED_STORAGE_PROPERTY_MAX_AUTH_FAILURES
        ///[ Optional ] ENHANCED_STORAGE_PROPERTY_AUTH_REQUIRED_FOR_INITIALIZE
        ///Results:
        ///WPD_PROPERTY_COMMON_HRESULT - status code for the operation
        /// </code>
        /// </summary>
        [WPDCommand(WPD_COMMAND_ACCESS_TYPES.WPD_COMMAND_ACCESS_READWRITE)]
        [WPDCommandParam(nameof(ENHANCED_STORAGE_PROPERTY_PASSWORD), true)]
        [WPDCommandParam(nameof(ENHANCED_STORAGE_PROPERTY_SILO_FRIENDLYNAME_SPECIFIED), false)]
        [WPDCommandParam(nameof(ENHANCED_STORAGE_PROPERTY_SILO_NAME), false)]
        [WPDCommandParam(nameof(ENHANCED_STORAGE_PROPERTY_MAX_AUTH_FAILURES), false)]
        [WPDCommandResult(nameof(WPD_PROPERTY_COMMON_HRESULT), true)]
        public static readonly PROPERTYKEY ENHANCED_STORAGE_COMMAND_PASSWORD_CONFIG_ADMINISTRATOR = new(new Guid(0x91248166, 0xb832, 0x4ad4, 0xba, 0xa4, 0x7c, 0xa0, 0xb6, 0xb2, 0x79, 0x8c), 206);

        /// <summary>
        /// <code>
        ///ENHANCED_STORAGE_COMMAND_PASSWORD_CREATE_USER
        ///This command creates a user account
        ///Access:
        ///(FILE_READ_ACCESS | FILE_WRITE_ACCESS)
        ///Parameters:
        ///[ Required ] ENHANCED_STORAGE_PROPERTY_PASSWORD
        ///[ Required ] ENHANCED_STORAGE_PROPERTY_NEW_PASSWORD
        ///[ Required ] ENHANCED_STORAGE_PROPERTY_USER_HINT
        ///[ Required ] ENHANCED_STORAGE_PROPERTY_USER_NAME
        ///[ Optional ] ENHANCED_STORAGE_PROPERTY_MAX_AUTH_FAILURES
        ///Results:
        ///WPD_PROPERTY_COMMON_HRESULT - status code for the operation
        /// </code>
        /// </summary>
        [WPDCommand(WPD_COMMAND_ACCESS_TYPES.WPD_COMMAND_ACCESS_READWRITE)]
        [WPDCommandParam(nameof(ENHANCED_STORAGE_PROPERTY_PASSWORD), true)]
        [WPDCommandParam(nameof(ENHANCED_STORAGE_PROPERTY_NEW_PASSWORD), true)]
        [WPDCommandParam(nameof(ENHANCED_STORAGE_PROPERTY_USER_HINT), true)]
        [WPDCommandParam(nameof(ENHANCED_STORAGE_PROPERTY_USER_NAME), true)]
        [WPDCommandParam(nameof(ENHANCED_STORAGE_PROPERTY_MAX_AUTH_FAILURES), false)]
        [WPDCommandResult(nameof(WPD_PROPERTY_COMMON_HRESULT), true)]
        public static readonly PROPERTYKEY ENHANCED_STORAGE_COMMAND_PASSWORD_CREATE_USER = new(new Guid(0x91248166, 0xb832, 0x4ad4, 0xba, 0xa4, 0x7c, 0xa0, 0xb6, 0xb2, 0x79, 0x8c), 207);

        /// <summary>
        /// <code>
        ///ENHANCED_STORAGE_COMMAND_PASSWORD_DELETE_USER
        ///This command deletes the existing user account
        ///Access:
        ///(FILE_READ_ACCESS | FILE_WRITE_ACCESS)
        ///Parameters:
        ///none
        ///Results:
        ///WPD_PROPERTY_COMMON_HRESULT - status code for the operation
        /// </code>
        /// </summary>
        [WPDCommand(WPD_COMMAND_ACCESS_TYPES.WPD_COMMAND_ACCESS_READWRITE)]
        [WPDCommandResult(nameof(WPD_PROPERTY_COMMON_HRESULT), true)]
        public static readonly PROPERTYKEY ENHANCED_STORAGE_COMMAND_PASSWORD_DELETE_USER = new(new Guid(0x91248166, 0xb832, 0x4ad4, 0xba, 0xa4, 0x7c, 0xa0, 0xb6, 0xb2, 0x79, 0x8c), 208);

        /// <summary>
        /// <code>
        ///ENHANCED_STORAGE_COMMAND_PASSWORD_INITIALIZE_USER_PASSWORD
        ///This command initializes the existing user password
        ///Access:
        ///(FILE_READ_ACCESS | FILE_WRITE_ACCESS)
        ///Parameters:
        ///[ Required ] ENHANCED_STORAGE_PROPERTY_PASSWORD
        ///[ Required ] ENHANCED_STORAGE_PROPERTY_NEW_PASSWORD
        ///[ Required ] ENHANCED_STORAGE_PROPERTY_NEW_HINT
        ///Results:
        ///WPD_PROPERTY_COMMON_HRESULT - status code for the operation
        /// </code>
        /// </summary>
        [WPDCommand(WPD_COMMAND_ACCESS_TYPES.WPD_COMMAND_ACCESS_READWRITE)]
        [WPDCommandParam(nameof(ENHANCED_STORAGE_PROPERTY_PASSWORD), true)]
        [WPDCommandParam(nameof(ENHANCED_STORAGE_PROPERTY_NEW_PASSWORD), true)]
        [WPDCommandParam(nameof(ENHANCED_STORAGE_PROPERTY_USER_HINT), true)]
        [WPDCommandResult(nameof(WPD_PROPERTY_COMMON_HRESULT), true)]
        public static readonly PROPERTYKEY ENHANCED_STORAGE_COMMAND_PASSWORD_INITIALIZE_USER_PASSWORD = new(new Guid(0x91248166, 0xb832, 0x4ad4, 0xba, 0xa4, 0x7c, 0xa0, 0xb6, 0xb2, 0x79, 0x8c), 210);

        /// <summary>
        /// <code>
        ///ENHANCED_STORAGE_COMMAND_PASSWORD_QUERY_INFORMATION
        ///This command queries the current password silo information
        ///Access:
        ///(FILE_READ_ACCESS)
        ///Parameters:
        ///none
        ///Results:
        ///ENHANCED_STORAGE_PROPERTY_AUTHENTICATION_STATE
        ///ENHANCED_STORAGE_PROPERTY_PASSWORD_SILO_INFO
        ///ENHANCED_STORAGE_PROPERTY_ADMIN_HINT
        ///ENHANCED_STORAGE_PROPERTY_USER_HINT
        ///ENHANCED_STORAGE_PROPERTY_USER_NAME
        ///WPD_PROPERTY_COMMON_HRESULT - status code for the operation
        /// </code>
        /// </summary>
        [WPDCommand]
        [WPDCommandResult(nameof(ENHANCED_STORAGE_PROPERTY_AUTHENTICATION_STATE), true)]
        [WPDCommandResult(nameof(ENHANCED_STORAGE_PROPERTY_PASSWORD_SILO_INFO), true)]
        [WPDCommandResult(nameof(ENHANCED_STORAGE_PROPERTY_ADMIN_HINT), true)]
        [WPDCommandResult(nameof(ENHANCED_STORAGE_PROPERTY_USER_HINT), true)]
        [WPDCommandResult(nameof(ENHANCED_STORAGE_PROPERTY_USER_NAME), true)]
        [WPDCommandResult(nameof(WPD_PROPERTY_COMMON_HRESULT), true)]
        public static readonly PROPERTYKEY ENHANCED_STORAGE_COMMAND_PASSWORD_QUERY_INFORMATION = new(new Guid(0x91248166, 0xb832, 0x4ad4, 0xba, 0xa4, 0x7c, 0xa0, 0xb6, 0xb2, 0x79, 0x8c), 205);

        /// <summary>
        /// <code>
        ///ENHANCED_STORAGE_COMMAND_PASSWORD_START_INITIALIZE_TO_MANUFACTURER_STATE
        ///This command starts the initialization process
        ///Access:
        ///(FILE_READ_ACCESS | FILE_WRITE_ACCESS)
        ///Parameters:
        ///[ Optional ] ENHANCED_STORAGE_PROPERTY_SECURITY_IDENTIFIER
        ///Results:
        ///WPD_PROPERTY_COMMON_HRESULT - status code for the operation
        /// </code>
        /// </summary>
        [WPDCommand(WPD_COMMAND_ACCESS_TYPES.WPD_COMMAND_ACCESS_READWRITE)]
        [WPDCommandParam(nameof(ENHANCED_STORAGE_PROPERTY_SECURITY_IDENTIFIER), false)]
        [WPDCommandResult(nameof(WPD_PROPERTY_COMMON_HRESULT), true)]
        public static readonly PROPERTYKEY ENHANCED_STORAGE_COMMAND_PASSWORD_START_INITIALIZE_TO_MANUFACTURER_STATE = new(new Guid(0x91248166, 0xb832, 0x4ad4, 0xba, 0xa4, 0x7c, 0xa0, 0xb6, 0xb2, 0x79, 0x8c), 211);

        /// <summary>
        /// <code>
        ///ENHANCED_STORAGE_COMMAND_PASSWORD_UNAUTHORIZE_ACT_ACCESS
        ///This command attempts to un-authenticate to the silo for ACT's data
        ///access.
        ///Access:
        ///(FILE_READ_ACCESS | FILE_WRITE_ACCESS)
        ///Parameters:
        ///[ Optional ] ENHANCED_STORAGE_PROPERTY_PASSWORD
        ///[ Optional ] ENHANCED_STORAGE_PROPERTY_PASSWORD_INDICATOR
        ///[ Optional ] ENHANCED_STORAGE_PROPERTY_TEMPORARY_UNAUTHENTICATION
        ///Results:
        ///WPD_PROPERTY_COMMON_HRESULT - status code for the operation
        /// </code>
        /// </summary>
        [WPDCommand(WPD_COMMAND_ACCESS_TYPES.WPD_COMMAND_ACCESS_READWRITE)]
        [WPDCommandParam(nameof(ENHANCED_STORAGE_PROPERTY_PASSWORD), false)]
        [WPDCommandParam(nameof(ENHANCED_STORAGE_PROPERTY_PASSWORD_INDICATOR), false)]
        [WPDCommandParam(nameof(ENHANCED_STORAGE_PROPERTY_TEMPORARY_UNAUTHENTICATION), false)]
        [WPDCommandResult(nameof(WPD_PROPERTY_COMMON_HRESULT), true)]
        public static readonly PROPERTYKEY ENHANCED_STORAGE_COMMAND_PASSWORD_UNAUTHORIZE_ACT_ACCESS = new(new Guid(0x91248166, 0xb832, 0x4ad4, 0xba, 0xa4, 0x7c, 0xa0, 0xb6, 0xb2, 0x79, 0x8c), 204);

        ///<summary><code>
        /// ENHANCED_STORAGE_COMMAND_SILO_ENUMERATE_SILOS
        ///     This command will enumerate the silo information for the specified silo type
        ///  Access:
        ///     (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
        ///  Parameters:
        ///      [ Required ] ENHANCED_STORAGE_PROPERTY_QUERY_SILO_TYPE
        ///  Results:
        ///     WPD_PROPERTY_COMMON_HRESULT
        /// </code></summary>
        [WPDCommand(WPD_COMMAND_ACCESS_TYPES.WPD_COMMAND_ACCESS_READWRITE)]
        [WPDCommandParam(nameof(ENHANCED_STORAGE_PROPERTY_QUERY_SILO_TYPE), true)]
        [WPDCommandResult(nameof(WPD_PROPERTY_COMMON_HRESULT), true)]
        public static readonly PROPERTYKEY ENHANCED_STORAGE_COMMAND_SILO_ENUMERATE_SILOS = new(new Guid(0x91248166, 0xb832, 0x4ad4, 0xba, 0xa4, 0x7c, 0xa0, 0xb6, 0xb2, 0x79, 0x8c), 11);

        /// <summary>
        /// <code>
        ///ENHANCED_STORAGE_COMMAND_SILO_GET_AUTHENTICATION_STATE
        ///This command will return the authentication state for the silo.
        ///Access:
        ///(FILE_READ_ACCESS | FILE_WRITE_ACCESS)
        ///Parameters:
        ///None.
        ///Results:
        ///WPD_PROPERTY_COMMON_HRESULT - The last status code for Authentication or UnAuthentication
        ///ENHANCED_STORAGE_PROPERTY_AUTHENTICATION_STATE [VT_UI4]
        /// </code>
        /// </summary>
        [WPDCommand(WPD_COMMAND_ACCESS_TYPES.WPD_COMMAND_ACCESS_READWRITE)]
        [WPDCommandResult(nameof(WPD_PROPERTY_COMMON_HRESULT), true)]
        [WPDCommandResult(nameof(ENHANCED_STORAGE_PROPERTY_AUTHENTICATION_STATE), true)]
        public static readonly PROPERTYKEY ENHANCED_STORAGE_COMMAND_SILO_GET_AUTHENTICATION_STATE = new(new Guid(0x91248166, 0xb832, 0x4ad4, 0xba, 0xa4, 0x7c, 0xa0, 0xb6, 0xb2, 0x79, 0x8c), 7);

        /// <summary>
        /// <code>
        ///ENHANCED_STORAGE_COMMAND_SILO_IS_AUTHENTICATION_SILO
        ///This command will return whether or not the silo is an authentication silo.
        ///Access:
        ///(FILE_READ_ACCESS | FILE_WRITE_ACCESS)
        ///Parameters:
        ///None.
        ///Results:
        ///WPD_PROPERTY_COMMON_HRESULT - The last status code for Authentication or UnAuthentication
        ///ENHANCED_STORAGE_PROPERTY_IS_AUTHENTICATION_SILO [VT_BOOLEAN] - TRUE if an Auth-C silo, FALSE otherwise
        /// </code>
        /// </summary>
        [WPDCommand(WPD_COMMAND_ACCESS_TYPES.WPD_COMMAND_ACCESS_READWRITE)]
        [WPDCommandResult(nameof(WPD_PROPERTY_COMMON_HRESULT), true)]
        [WPDCommandResult(nameof(ENHANCED_STORAGE_PROPERTY_IS_AUTHENTICATION_SILO), true)]
        public static readonly PROPERTYKEY ENHANCED_STORAGE_COMMAND_SILO_IS_AUTHENTICATION_SILO = new(new Guid(0x91248166, 0xb832, 0x4ad4, 0xba, 0xa4, 0x7c, 0xa0, 0xb6, 0xb2, 0x79, 0x8c), 6);

        /// <summary>
        /// <code>
        ///ENHANCED_STORAGE_PROPERTY_ADMIN_HINT
        ///[ VT_LPCSTR ] The admin hint
        /// </code>
        /// </summary>
        [CorrespondingType(typeof(LPSTR))]
        public static readonly PROPERTYKEY ENHANCED_STORAGE_PROPERTY_ADMIN_HINT = new(new Guid(0x91248166, 0xb832, 0x4ad4, 0xba, 0xa4, 0x7c, 0xa0, 0xb6, 0xb2, 0x79, 0x8c), 2011);

        /// <summary>
        /// <code>
        ///ENHANCED_STORAGE_PROPERTY_AUTHENTICATION_STATE
        ///[ VT_UI4 ] Authentication status of the Enhanced Storage Silo
        /// </code>
        /// </summary>
        [CorrespondingType(typeof(ENHANCED_STORAGE_AUTHN_STATE))]
        public static readonly PROPERTYKEY ENHANCED_STORAGE_PROPERTY_AUTHENTICATION_STATE = new(new Guid(0x91248166, 0xb832, 0x4ad4, 0xba, 0xa4, 0x7c, 0xa0, 0xb6, 0xb2, 0x79, 0x8c), 1006);

        /// <summary>
        /// <code>
        ///ENHANCED_STORAGE_PROPERTY_CERTIFICATE
        ///[ VT_VECTOR | VT_UI1 ] The certificate buffer in X.509 format
        /// </code>
        /// </summary>
        [CorrespondingType(typeof(byte[]))]
        public static readonly PROPERTYKEY ENHANCED_STORAGE_PROPERTY_CERTIFICATE = new(new Guid(0x91248166, 0xb832, 0x4ad4, 0xba, 0xa4, 0x7c, 0xa0, 0xb6, 0xb2, 0x79, 0x8c), 3009);

        /// <summary>
        /// <code>
        ///ENHANCED_STORAGE_PROPERTY_CERTIFICATE_ACT_FRIENDLY_NAME
        ///[ VT_LPWSTR ] The certificate silo's ACT friendly name
        /// </code>
        /// </summary>
        [CorrespondingType(typeof(LPWSTR))]
        public static readonly PROPERTYKEY ENHANCED_STORAGE_PROPERTY_CERTIFICATE_ACT_FRIENDLY_NAME = new(new Guid(0x91248166, 0xb832, 0x4ad4, 0xba, 0xa4, 0x7c, 0xa0, 0xb6, 0xb2, 0x79, 0x8c), 3014);

        /// <summary>
        /// <code>
        ///ENHANCED_STORAGE_PROPERTY_CERTIFICATE_CAPABILITY_TYPE
        ///[ VT_UINT ] Silo capability type
        /// </code>
        /// </summary>
        [CorrespondingType(typeof(CERT_CAPABILITY))]
        public static readonly PROPERTYKEY ENHANCED_STORAGE_PROPERTY_CERTIFICATE_CAPABILITY_TYPE = new(new Guid(0x91248166, 0xb832, 0x4ad4, 0xba, 0xa4, 0x7c, 0xa0, 0xb6, 0xb2, 0x79, 0x8c), 3011);

        /// <summary>
        /// <code>
        ///ENHANCED_STORAGE_PROPERTY_CERTIFICATE_INDEX
        ///[ VT_UINT ] The index for the certificate slot on the device
        /// </code>
        /// </summary>
        [CorrespondingType(typeof(uint))]
        public static readonly PROPERTYKEY ENHANCED_STORAGE_PROPERTY_CERTIFICATE_INDEX = new(new Guid(0x91248166, 0xb832, 0x4ad4, 0xba, 0xa4, 0x7c, 0xa0, 0xb6, 0xb2, 0x79, 0x8c), 3003);

        /// <summary>
        /// <code>
        ///ENHANCED_STORAGE_PROPERTY_CERTIFICATE_LENGTH
        ///[ VT_UINT ] Length of the certificate in bytes
        /// </code>
        /// </summary>
        [CorrespondingType(typeof(uint))]
        public static readonly PROPERTYKEY ENHANCED_STORAGE_PROPERTY_CERTIFICATE_LENGTH = new(new Guid(0x91248166, 0xb832, 0x4ad4, 0xba, 0xa4, 0x7c, 0xa0, 0xb6, 0xb2, 0x79, 0x8c), 3008);

        /// <summary>
        /// <code>
        ///ENHANCED_STORAGE_PROPERTY_CERTIFICATE_REQUEST
        ///[ VT_VECTOR | VT_UI1 ] The certificate request buffer
        /// </code>
        /// </summary>
        [CorrespondingType(typeof(byte[]))]
        public static readonly PROPERTYKEY ENHANCED_STORAGE_PROPERTY_CERTIFICATE_REQUEST = new(new Guid(0x91248166, 0xb832, 0x4ad4, 0xba, 0xa4, 0x7c, 0xa0, 0xb6, 0xb2, 0x79, 0x8c), 3010);

        /// <summary>
        /// <code>
        ///ENHANCED_STORAGE_PROPERTY_CERTIFICATE_SILO_CAPABILITIES
        ///[ VT_UNKNOWN ] The certificate silo capabilities returned in a collection
        /// </code>
        /// </summary>
        public static readonly PROPERTYKEY ENHANCED_STORAGE_PROPERTY_CERTIFICATE_SILO_CAPABILITIES = new(new Guid(0x91248166, 0xb832, 0x4ad4, 0xba, 0xa4, 0x7c, 0xa0, 0xb6, 0xb2, 0x79, 0x8c), 3013);

        /// <summary>
        /// <code>
        ///ENHANCED_STORAGE_PROPERTY_CERTIFICATE_SILO_CAPABILITY
        ///[ VT_VECTOR | VT_UINT ] The "raw" capability data return from the silo
        /// </code>
        /// </summary>
        [CorrespondingType(typeof(byte[]))]
        public static readonly PROPERTYKEY ENHANCED_STORAGE_PROPERTY_CERTIFICATE_SILO_CAPABILITY = new(new Guid(0x91248166, 0xb832, 0x4ad4, 0xba, 0xa4, 0x7c, 0xa0, 0xb6, 0xb2, 0x79, 0x8c), 3012);

        /// <summary>
        /// <code>
        ///ENHANCED_STORAGE_PROPERTY_CERTIFICATE_SILO_GUID
        ///[ VT_LPWSTR ] The certificate silo GUID
        /// </code>
        /// </summary>
        [CorrespondingType(typeof(LPWSTR))]
        public static readonly PROPERTYKEY ENHANCED_STORAGE_PROPERTY_CERTIFICATE_SILO_GUID = new(new Guid(0x91248166, 0xb832, 0x4ad4, 0xba, 0xa4, 0x7c, 0xa0, 0xb6, 0xb2, 0x79, 0x8c), 3015);

        /// <summary>
        /// <code>
        ///ENHANCED_STORAGE_PROPERTY_CERTIFICATE_TYPE
        ///[ VT_UINT ] The type of certificate
        /// </code>
        /// </summary>
        [CorrespondingType(typeof(CERT_TYPE))]
        public static readonly PROPERTYKEY ENHANCED_STORAGE_PROPERTY_CERTIFICATE_TYPE = new(new Guid(0x91248166, 0xb832, 0x4ad4, 0xba, 0xa4, 0x7c, 0xa0, 0xb6, 0xb2, 0x79, 0x8c), 3004);

        /// <summary>
        /// <code>
        ///ENHANCED_STORAGE_PROPERTY_IS_AUTHENTICATION_SILO
        ///[ VT_BOOL ] Is this silo an authentication silo?
        /// </code>
        /// </summary>
        [CorrespondingType(typeof(bool))]
        public static readonly PROPERTYKEY ENHANCED_STORAGE_PROPERTY_IS_AUTHENTICATION_SILO = new(new Guid(0x91248166, 0xb832, 0x4ad4, 0xba, 0xa4, 0x7c, 0xa0, 0xb6, 0xb2, 0x79, 0x8c), 1009);

        /// <summary>
        /// <code>
        ///ENHANCED_STORAGE_PROPERTY_MAX_AUTH_FAILURES
        ///[ VT_UI4 ] Maximum number of password authentication failures
        /// </code>
        /// </summary>
        [CorrespondingType(typeof(uint))]
        public static readonly PROPERTYKEY ENHANCED_STORAGE_PROPERTY_MAX_AUTH_FAILURES = new(new Guid(0x91248166, 0xb832, 0x4ad4, 0xba, 0xa4, 0x7c, 0xa0, 0xb6, 0xb2, 0x79, 0x8c), 2001);

        /// <summary>
        /// <code>
        ///ENHANCED_STORAGE_PROPERTY_MAX_CERTIFICATE_COUNT
        ///[ VT_UINT ] The number of certificate slots available on the device
        /// </code>
        /// </summary>
        [CorrespondingType(typeof(uint))]
        public static readonly PROPERTYKEY ENHANCED_STORAGE_PROPERTY_MAX_CERTIFICATE_COUNT = new(new Guid(0x91248166, 0xb832, 0x4ad4, 0xba, 0xa4, 0x7c, 0xa0, 0xb6, 0xb2, 0x79, 0x8c), 3001);

        /// <summary>
        /// <code>
        ///ENHANCED_STORAGE_PROPERTY_NEW_PASSWORD
        ///[ VT_BLOB ] The new password.  Used to re-set the password
        /// </code>
        /// </summary>
        [CorrespondingType(typeof(BLOB))]

        public static readonly PROPERTYKEY ENHANCED_STORAGE_PROPERTY_NEW_PASSWORD = new(new Guid(0x91248166, 0xb832, 0x4ad4, 0xba, 0xa4, 0x7c, 0xa0, 0xb6, 0xb2, 0x79, 0x8c), 2008);

        /// <summary>
        /// <code>
        ///ENHANCED_STORAGE_PROPERTY_NEW_PASSWORD_INDICATOR
        ///[ VT_BOOL ] TRUE: user, FALSE: admin
        /// </code>
        /// </summary>
        [CorrespondingType(typeof(bool))]
        public static readonly PROPERTYKEY ENHANCED_STORAGE_PROPERTY_NEW_PASSWORD_INDICATOR = new(new Guid(0x91248166, 0xb832, 0x4ad4, 0xba, 0xa4, 0x7c, 0xa0, 0xb6, 0xb2, 0x79, 0x8c), 2007);

        /// <summary>
        /// <code>
        ///ENHANCED_STORAGE_PROPERTY_NEXT_CERTIFICATE_INDEX
        ///[ VT_UINT ] The index of the next valid cert
        /// </code>
        /// </summary>
        [CorrespondingType(typeof(uint))]
        public static readonly PROPERTYKEY ENHANCED_STORAGE_PROPERTY_NEXT_CERTIFICATE_INDEX = new(new Guid(0x91248166, 0xb832, 0x4ad4, 0xba, 0xa4, 0x7c, 0xa0, 0xb6, 0xb2, 0x79, 0x8c), 3006);

        /// <summary>
        /// <code>
        ///ENHANCED_STORAGE_PROPERTY_NEXT_CERTIFICATE_OF_TYPE_INDEX
        ///[ VT_UINT ] The index of the next valid cert of same type
        /// </code>
        /// </summary>
        [CorrespondingType(typeof(uint))]
        public static readonly PROPERTYKEY ENHANCED_STORAGE_PROPERTY_NEXT_CERTIFICATE_OF_TYPE_INDEX = new(new Guid(0x91248166, 0xb832, 0x4ad4, 0xba, 0xa4, 0x7c, 0xa0, 0xb6, 0xb2, 0x79, 0x8c), 3007);

        /// <summary>
        /// <code>
        ///ENHANCED_STORAGE_PROPERTY_OLD_PASSWORD
        ///[ VT_BLOB ] The password used for changing password.
        /// </code>
        /// </summary>
        [CorrespondingType(typeof(BLOB))]
        public static readonly PROPERTYKEY ENHANCED_STORAGE_PROPERTY_OLD_PASSWORD = new(new Guid(0x91248166, 0xb832, 0x4ad4, 0xba, 0xa4, 0x7c, 0xa0, 0xb6, 0xb2, 0x79, 0x8c), 2005);

        /// <summary>
        /// <code>
        ///ENHANCED_STORAGE_PROPERTY_PASSWORD
        ///[ VT_BLOB ] The password to send or set
        /// </code>
        /// </summary>
        [CorrespondingType(typeof(BLOB))]
        public static readonly PROPERTYKEY ENHANCED_STORAGE_PROPERTY_PASSWORD = new(new Guid(0x91248166, 0xb832, 0x4ad4, 0xba, 0xa4, 0x7c, 0xa0, 0xb6, 0xb2, 0x79, 0x8c), 2004);

        /// <summary>
        /// <code>
        ///ENHANCED_STORAGE_PROPERTY_PASSWORD_INDICATOR
        ///[ VT_BOOL ] TRUE: user, FALSE: admin
        /// </code>
        /// </summary>
        [CorrespondingType(typeof(bool))]
        public static readonly PROPERTYKEY ENHANCED_STORAGE_PROPERTY_PASSWORD_INDICATOR = new(new Guid(0x91248166, 0xb832, 0x4ad4, 0xba, 0xa4, 0x7c, 0xa0, 0xb6, 0xb2, 0x79, 0x8c), 2006);

        /// <summary>
        /// <code>
        ///ENHANCED_STORAGE_PROPERTY_PASSWORD_SILO_INFO
        ///[ VT_BLOB ] The password silo information
        /// </code>
        /// </summary>
        [CorrespondingType(typeof(BLOB))]
        public static readonly PROPERTYKEY ENHANCED_STORAGE_PROPERTY_PASSWORD_SILO_INFO = new(new Guid(0x91248166, 0xb832, 0x4ad4, 0xba, 0xa4, 0x7c, 0xa0, 0xb6, 0xb2, 0x79, 0x8c), 2014);

        /// <summary>
        /// <code>
        ///ENHANCED_STORAGE_PROPERTY_QUERY_SILO_RESULTS
        ///[ VT_BLOB ] Query Silo Properties result
        /// </code>
        /// </summary>
        [CorrespondingType(typeof(BLOB))]
        public static readonly PROPERTYKEY ENHANCED_STORAGE_PROPERTY_QUERY_SILO_RESULTS = new(new Guid(0x91248166, 0xb832, 0x4ad4, 0xba, 0xa4, 0x7c, 0xa0, 0xb6, 0xb2, 0x79, 0x8c), 2017);

        /// <summary>
        /// <code>
        ///ENHANCED_STORAGE_PROPERTY_QUERY_SILO_TYPE
        ///[ VT_UINT ] Query Silo Type
        /// </code>
        /// </summary>
        [CorrespondingType(typeof(uint))]
        public static readonly PROPERTYKEY ENHANCED_STORAGE_PROPERTY_QUERY_SILO_TYPE = new(new Guid(0x91248166, 0xb832, 0x4ad4, 0xba, 0xa4, 0x7c, 0xa0, 0xb6, 0xb2, 0x79, 0x8c), 2016);

        /// <summary>
        /// <code>
        ///ENHANCED_STORAGE_PROPERTY_SECURITY_IDENTIFIER
        ///[ VT_BLOB ] Security Identifier for the password silo device
        /// </code>
        /// </summary>
        [CorrespondingType(typeof(BLOB))]
        public static readonly PROPERTYKEY ENHANCED_STORAGE_PROPERTY_SECURITY_IDENTIFIER = new(new Guid(0x91248166, 0xb832, 0x4ad4, 0xba, 0xa4, 0x7c, 0xa0, 0xb6, 0xb2, 0x79, 0x8c), 2015);

        /// <summary>
        /// <code>
        ///ENHANCED_STORAGE_PROPERTY_SIGNER CERTIFICATE_INDEX
        ///[ VT_UINT ] The index for the signer certificate slot on the device
        /// </code>
        /// </summary>
        [CorrespondingType(typeof(uint))]
        public static readonly PROPERTYKEY ENHANCED_STORAGE_PROPERTY_SIGNER_CERTIFICATE_INDEX = new(new Guid(0x91248166, 0xb832, 0x4ad4, 0xba, 0xa4, 0x7c, 0xa0, 0xb6, 0xb2, 0x79, 0x8c), 3016);

        /// <summary>
        /// <code>
        ///ENHANCED_STORAGE_PROPERTY_SILO_FRIENDLYNAME_SPECIFIED
        ///[ VT_BOOL ] Flag to indicate if silo friendly name is given
        /// </code>
        /// </summary>
        [CorrespondingType(typeof(bool))]
        public static readonly PROPERTYKEY ENHANCED_STORAGE_PROPERTY_SILO_FRIENDLYNAME_SPECIFIED = new(new Guid(0x91248166, 0xb832, 0x4ad4, 0xba, 0xa4, 0x7c, 0xa0, 0xb6, 0xb2, 0x79, 0x8c), 2013);

        /// <summary>
        /// <code>
        ///ENHANCED_STORAGE_PROPERTY_SILO_NAME
        ///[ VT_LPCSTR ] The friendly name for the silo
        /// </code>
        /// </summary>
        [CorrespondingType(typeof(LPSTR))]
        public static readonly PROPERTYKEY ENHANCED_STORAGE_PROPERTY_SILO_NAME = new(new Guid(0x91248166, 0xb832, 0x4ad4, 0xba, 0xa4, 0x7c, 0xa0, 0xb6, 0xb2, 0x79, 0x8c), 2012);

        /// <summary>
        /// <code>
        ///ENHANCED_STORAGE_PROPERTY_STORED_CERTIFICATE_COUNT
        ///[ VT_UINT ] The number of certificate slots in use on the device
        /// </code>
        /// </summary>
        [CorrespondingType(typeof(uint))]
        public static readonly PROPERTYKEY ENHANCED_STORAGE_PROPERTY_STORED_CERTIFICATE_COUNT = new(new Guid(0x91248166, 0xb832, 0x4ad4, 0xba, 0xa4, 0x7c, 0xa0, 0xb6, 0xb2, 0x79, 0x8c), 3002);

        /// <summary>
        /// <code>
        ///ENHANCED_STORAGE_PROPERTY_TEMPORARY_UNAUTHENTICATION
        ///[ VT_BOOL ] TRUE: temporary, FALSE: persistent
        /// </code>
        /// </summary>
        [CorrespondingType(typeof(bool))]
        public static readonly PROPERTYKEY ENHANCED_STORAGE_PROPERTY_TEMPORARY_UNAUTHENTICATION = new(new Guid(0x91248166, 0xb832, 0x4ad4, 0xba, 0xa4, 0x7c, 0xa0, 0xb6, 0xb2, 0x79, 0x8c), 1010);

        /// <summary>
        /// <code>
        ///ENHANCED_STORAGE_PROPERTY_USER_HINT
        ///[ VT_LPCSTR ] The user hint
        /// </code>
        /// </summary>
        [CorrespondingType(typeof(LPSTR))]
        public static readonly PROPERTYKEY ENHANCED_STORAGE_PROPERTY_USER_HINT = new(new Guid(0x91248166, 0xb832, 0x4ad4, 0xba, 0xa4, 0x7c, 0xa0, 0xb6, 0xb2, 0x79, 0x8c), 2009);

        /// <summary>
        /// <code>
        ///ENHANCED_STORAGE_PROPERTY_USER_NAME
        ///[ VT_LPCSTR ] The friendly user name
        /// </code>
        /// </summary>
        [CorrespondingType(typeof(LPSTR))]
        public static readonly PROPERTYKEY ENHANCED_STORAGE_PROPERTY_USER_NAME = new(new Guid(0x91248166, 0xb832, 0x4ad4, 0xba, 0xa4, 0x7c, 0xa0, 0xb6, 0xb2, 0x79, 0x8c), 2010);

        /// <summary>
        /// <code>
        ///ENHANCED_STORAGE_PROPERTY_VALIDATION_POLICY
        ///[ VT_UINT ] The validation policy for the certificate
        /// </code>
        /// </summary>
        [CorrespondingType(typeof(CERT_VALIDATION_POLICY))]
        public static readonly PROPERTYKEY ENHANCED_STORAGE_PROPERTY_VALIDATION_POLICY = new(new Guid(0x91248166, 0xb832, 0x4ad4, 0xba, 0xa4, 0x7c, 0xa0, 0xb6, 0xb2, 0x79, 0x8c), 3005);

        /// <summary>{3897F6A4-FD35-4bc8-A0B7-5DBBA36ADAFA}</summary>
        public static readonly Guid GUID_DEVINTERFACE_ENHANCED_STORAGE_SILO = new(0x3897f6a4, 0xfd35, 0x4bc8, 0xa0, 0xb7, 0x5d, 0xbb, 0xa3, 0x6a, 0xda, 0xfa);

        /// <summary>This category is for commands and parameters for storage functional objects.</summary>
        public static readonly Guid WPD_CATEGORY_ENHANCED_STORAGE = new(0x91248166, 0xb832, 0x4ad4, 0xba, 0xa4, 0x7c, 0xa0, 0xb6, 0xb2, 0x79, 0x8c);

        /// <summary>
        /// <para>The following constants indicate the capabilities, algorithms, and cryptography supported by the certificate silo.</para>
        /// </summary>
        /// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/enstor/cert-capability
        [PInvokeData("ehstorapi.h")]
        public enum CERT_CAPABILITY
        {
            /// <summary>Hashing algorithms supported (e.g. SHA-1, SHA-256, etc).</summary>
            CERT_CAPABILITY_HASH_ALG = 0x1,

            /// <summary>Asymmetric key cryptography supported (e.g. RSA 1024 bit key).</summary>
            CERT_CAPABILITY_ASYMMETRIC_KEY_CRYPTOGRAPHY = 0x2,

            /// <summary>Signature algorithms supported (e.g. RSASSA PSS-SHA1 RSASSA PKCS v1.5 SHA-1).</summary>
            CERT_CAPABILITY_SIGNATURE_ALG = 0x3,

            /// <summary>
            /// Certificate support provided in the certificate silo. Currently, only certificate extension field parsing is supported.
            /// </summary>
            CERT_CAPABILITY_CERTIFICATE_SUPPORT = 0x4,

            /// <summary>Optional features supported by the certificate silo.</summary>
            CERT_CAPABILITY_OPTIONAL_FEATURES = 0x5,

            /// <summary>This is used to indicate the first reserved value.</summary>
            CERT_MAX_CAPABILITY = 0xFF,
        }

        /// <summary>The following constants indicate the type of certificate being used for validation.</summary>
        /// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/enstor/cert-type
        [PInvokeData("ehstorapi.h")]
        public enum CERT_TYPE
        {
            /// <summary>No certificate</summary>
            CERT_TYPE_EMPTY = 0x00,

            /// <summary>Manufacturer Certificate</summary>
            CERT_TYPE_ASCm = 0x01,

            /// <summary>Provisioning Certificate</summary>
            CERT_TYPE_PCp = 0x02,

            /// <summary>Authentication Silo Certificate</summary>
            CERT_TYPE_ASCh = 0x03,

            /// <summary>Host Certificate</summary>
            CERT_TYPE_HCh = 0x04,

            /// <summary>Signer Certificate</summary>
            CERT_TYPE_SIGNER = 0x06,
        }

        /// <summary>The following constants indicate the certificate validation policies supported during certificate validation.</summary>
        /// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/enstor/cert-validation-policy
        [PInvokeData("ehstorapi.h")]
        public enum CERT_VALIDATION_POLICY
        {
            /// <summary>This value is reserved.</summary>
            CERT_VALIDATION_POLICY_RESERVED = 0x00,

            /// <summary>The corresponding private key of the stored certificate is used for authentication.</summary>
            CERT_VALIDATION_POLICY_NONE = 0x01,

            /// <summary>The certificate and certificate chain conforms to the basic validation policy.</summary>
            CERT_VALIDATION_POLICY_BASIC = 0x02,

            /// <summary>
            /// The certificate chain conforms to the extended validation policy. The use of this validation policy must result in an error
            /// condition of the Certificate Silo if it does not support parsing of certificate extensions.
            /// </summary>
            CERT_VALIDATION_POLICY_EXTENDED = 0x03,
        }

        /// <summary>State definitions for ENHANCED_STORAGE_PROPERTY_AUTHENTICATION_STATE</summary>
        public enum ENHANCED_STORAGE_AUTHN_STATE : uint
        {
            /// <summary>Initial setting before PnP entry and the silo state is unknow.</summary>
            ENHANCED_STORAGE_AUTHN_STATE_UNKNOWN = 0x00000000,

            /// <summary>The silo has not been provisioned</summary>
            ENHANCED_STORAGE_AUTHN_STATE_NO_AUTHENTICATION_REQUIRED = 0x00000001,

            /// <summary>The silo is not authenticated</summary>
            ENHANCED_STORAGE_AUTHN_STATE_NOT_AUTHENTICATED = 0x00000002,

            /// <summary>The silo is authenticated</summary>
            ENHANCED_STORAGE_AUTHN_STATE_AUTHENTICATED = 0x00000003,

            /// <summary>Authentication was denied.</summary>
            ENHANCED_STORAGE_AUTHN_STATE_AUTHENTICATION_DENIED = 0x80000001,

            /// <summary>The silo timed out or another device error happened</summary>
            ENHANCED_STORAGE_AUTHN_STATE_DEVICE_ERROR = 0x80000002,
        }

        /// <summary>
        /// The <c>ENHANCED_STORAGE_PASSWORD_SILO_INFORMATION</c> structure contains data that defines the capabilities and requirements of
        /// a password silo.
        /// </summary>
        /// https://docs.microsoft.com/en-us/windows/win32/api/ehstorextensions/ns-ehstorextensions-enhanced_storage_password_silo_information
        /// typedef struct _ENHANCED_STORAGE_PASSWORD_SILO_INFORMATION { BYTE CurrentAdminFailures; BYTE CurrentUserFailures; DWORD
        /// TotalUserAuthenticationCount; DWORD TotalAdminAuthenticationCount; BOOL FipsCompliant; BOOL SecurityIDAvailable; BOOL
        /// InitializeInProgress; BOOL ITMSArmed; BOOL ITMSArmable; BOOL UserCreated; BOOL ResetOnPORDefault; BOOL ResetOnPORCurrent; BYTE
        /// MaxAdminFailures; BYTE MaxUserFailures; DWORD TimeToCompleteInitialization; DWORD TimeRemainingToCompleteInitialization; DWORD
        /// MinTimeToAuthenticate; BYTE MaxAdminPasswordSize; BYTE MinAdminPasswordSize; BYTE MaxAdminHintSize; BYTE MaxUserPasswordSize;
        /// BYTE MinUserPasswordSize; BYTE MaxUserHintSize; BYTE MaxUserNameSize; BYTE MaxSiloNameSize; WORD MaxChallengeSize; }
        /// ENHANCED_STORAGE_PASSWORD_SILO_INFORMATION, *PENHANCED_STORAGE_PASSWORD_SILO_INFORMATION;
        [PInvokeData("ehstorextensions.h", MSDNShortId = "NS:ehstorextensions._ENHANCED_STORAGE_PASSWORD_SILO_INFORMATION")]
        [StructLayout(LayoutKind.Sequential, Pack = 2)]
        public struct ENHANCED_STORAGE_PASSWORD_SILO_INFORMATION
        {
            /// <summary>
            /// This is the current number of consecutive unsuccessful authentication attempts using administrator password. This value is
            /// reset to 0 after a successful authentication.
            /// </summary>
            public byte CurrentAdminFailures;

            /// <summary>
            /// This is the current number of consecutive unsuccessful authentication attempts using user password. This value is reset to 0
            /// after a successful authentication.
            /// </summary>
            public byte CurrentUserFailures;

            /// <summary>Total number of authentication attempts attempted on this silo using the user password.</summary>
            public uint TotalUserAuthenticationCount;

            /// <summary>Total number of authentication attempts attempted on this silo using the administrator password.</summary>
            public uint TotalAdminAuthenticationCount;

            /// <summary>
            /// <c>TRUE</c> if the silo claims compliance with the Federal Information Processing Standard (FIPS); otherwise, <c>FALSE</c>.
            /// </summary>
            [MarshalAs(UnmanagedType.Bool)]
            public bool FipsCompliant;

            /// <summary><c>TRUE</c> if a device-unique security identifier provided by the manufacturer is available; otherwise, <c>FALSE</c>.</summary>
            [MarshalAs(UnmanagedType.Bool)]
            public bool SecurityIDAvailable;

            /// <summary><c>TRUE</c> if an initialization is in progress; otherwise, <c>FALSE</c>.</summary>
            [MarshalAs(UnmanagedType.Bool)]
            public bool InitializeInProgress;

            /// <summary>
            /// <c>TRUE</c> if the silo is set to prepare for initialization to the default state set by the manufacturer; otherwise, <c>FALSE</c>.
            /// </summary>
            [MarshalAs(UnmanagedType.Bool)]
            public bool ITMSArmed;

            /// <summary>
            /// <c>TRUE</c> if the silo is capable of initializing to the default state set by the manufacturer; otherwise, <c>FALSE</c>.
            /// </summary>
            [MarshalAs(UnmanagedType.Bool)]
            public bool ITMSArmable;

            /// <summary><c>TRUE</c> if the user account has been created in the password silo; otherwise, <c>FALSE</c>.</summary>
            [MarshalAs(UnmanagedType.Bool)]
            public bool UserCreated;

            /// <summary>
            /// <c>TRUE</c> if the silo resets Administrator authentication failure count to zero upon power cycle. This is the default
            /// behavior for the silo. If <c>FALSE</c>, the silo will not reset Administrator authentication failure count to zero upon
            /// power cycle.
            /// </summary>
            [MarshalAs(UnmanagedType.Bool)]
            public bool ResetOnPORDefault;

            /// <summary>
            /// <c>TRUE</c> if the silo is currently set to reset Administrator authentication failure count to zero upon power cycle;
            /// Otherwise <c>FALSE</c>. This configuration is affected by changes introduced by the host or the implementation of factory
            /// default settings.
            /// </summary>
            [MarshalAs(UnmanagedType.Bool)]
            public bool ResetOnPORCurrent;

            /// <summary>
            /// This is the maximum number of consecutive unsuccessful authentication attempts using administrator password allowed by the
            /// silo before it will block the administrator.
            /// </summary>
            public byte MaxAdminFailures;

            /// <summary>
            /// This is the maximum number of consecutive unsuccessful authentication attempts using user password allowed by the silo
            /// before it will block user.
            /// </summary>
            public byte MaxUserFailures;

            /// <summary>Estimated time (in milliseconds) for the device to complete the initialize to manufacturing function.</summary>
            public uint TimeToCompleteInitialization;

            /// <summary>
            /// Time remaining (in milliseconds) for the silo to complete the initialize to manufacturing function. The value of this field
            /// is zero if the silo is currently not in the process of initialization.
            /// </summary>
            public uint TimeRemainingToCompleteInitialization;

            /// <summary>Minimum time (in milliseconds) the silo will require to complete an authentication operation.</summary>
            public uint MinTimeToAuthenticate;

            /// <summary>This is the maximum number of bytes that the silo supports for administrator password.</summary>
            public byte MaxAdminPasswordSize;

            /// <summary>This is the minimum number of bytes that the silo requires for administrator password.</summary>
            public byte MinAdminPasswordSize;

            /// <summary>This is the maximum number of bytes that the silo supports for administrator password hint.</summary>
            public byte MaxAdminHintSize;

            /// <summary>This is the maximum number of bytes that the silo supports for user password.</summary>
            public byte MaxUserPasswordSize;

            /// <summary>This is the minimum number of bytes that the silo requires for user password.</summary>
            public byte MinUserPasswordSize;

            /// <summary>This is the maximum number of bytes that the silo supports for user password hint.</summary>
            public byte MaxUserHintSize;

            /// <summary>This is the maximum number of bytes that the silo supports for friendly user name.</summary>
            public byte MaxUserNameSize;

            /// <summary>The maximum number of bytes that the silo supports for the silo name.</summary>
            public byte MaxSiloNameSize;

            /// <summary>The maximum number of bytes that the device supports for challenge.</summary>
            public ushort MaxChallengeSize;
        }

        /*
        /// <summary>Defines all Commands associated with WPD_CATEGORY_ENHANCED_STORAGE.</summary>
        public static class Commands
        {
            /// <summary>Authentication specific commands</summary>
            public static class Authentication
            {
                /// <summary>This command will enumerate the silo information for the specified silo type.</summary>
                public static CommandData EnumerateSilos => new(ENHANCED_STORAGE_COMMAND_SILO_ENUMERATE_SILOS,
                    new[] { ENHANCED_STORAGE_PROPERTY_QUERY_SILO_TYPE },
                    new[] { ENHANCED_STORAGE_PROPERTY_QUERY_SILO_RESULTS });

                /// <summary>This command will return the authentication state for the silo.</summary>
                public static CommandData GetAuthenticationState => new(ENHANCED_STORAGE_COMMAND_SILO_GET_AUTHENTICATION_STATE,
                    null,
                    new[] { ENHANCED_STORAGE_PROPERTY_AUTHENTICATION_STATE });

                /// <summary>This command will return whether or not the silo is an authentication silo.</summary>
                public static CommandData IsAuthenticationSilo => new(ENHANCED_STORAGE_COMMAND_SILO_IS_AUTHENTICATION_SILO,
                    null,
                    new[] { ENHANCED_STORAGE_PROPERTY_IS_AUTHENTICATION_SILO });
            }

            /// <summary>Certificate specific commands</summary>
            public static class Certificate
            {
                /// <summary>
                /// This command will attempt to initiate an administrative authentication based on the PCp or XCp certificate on the silo.
                /// </summary>
                public static CommandData AdminCertificateAuthentication => new(ENHANCED_STORAGE_COMMAND_CERT_ADMIN_CERTIFICATE_AUTHENTICATION);

                /// <summary>
                /// This command retrieves a certificate request from the silo. The returned certificate request can then be used to
                /// generate an ASCh certificate
                /// </summary>
                public static CommandData CreateCertificateRequest => new(ENHANCED_STORAGE_COMMAND_CERT_CREATE_CERTIFICATE_REQUEST,
                    null,
                    new[] { ENHANCED_STORAGE_PROPERTY_CERTIFICATE_REQUEST });

                /// <summary>
                /// This command will attempt to initiate a device authentication. If an index or certificate is specified, it will be used.
                /// The certificate must be a ASCm or ASCh. The default behavior is to attempt authentication using the ASCm or all ASCh
                /// certificates present on the silo.
                /// </summary>
                public static CommandData DeviceCertificateAuthentication => new(ENHANCED_STORAGE_COMMAND_CERT_DEVICE_CERTIFICATE_AUTHENTICATION,
                    new[] { ENHANCED_STORAGE_PROPERTY_CERTIFICATE_INDEX, }, null, true);

                /// <summary>This command retrieves the friendly name of the ACT containing the silo.</summary>
                public static CommandData GetACTFriendlyName => new(ENHANCED_STORAGE_COMMAND_CERT_GET_ACT_FRIENDLY_NAME,
                    null, new[] { ENHANCED_STORAGE_PROPERTY_CERTIFICATE_ACT_FRIENDLY_NAME }, true);

                /// <summary>
                /// This command will return the certificate stored at the certificate index location. Index '0' is a special location that
                /// returns the ASCm chain in the PKCS7 format.
                /// </summary>
                public static CommandData GetCertificate => new(ENHANCED_STORAGE_COMMAND_CERT_GET_CERTIFICATE,
                    new[] { ENHANCED_STORAGE_PROPERTY_CERTIFICATE_INDEX },
                    new[] { ENHANCED_STORAGE_PROPERTY_CERTIFICATE_TYPE, ENHANCED_STORAGE_PROPERTY_VALIDATION_POLICY,
                        ENHANCED_STORAGE_PROPERTY_SIGNER_CERTIFICATE_INDEX, ENHANCED_STORAGE_PROPERTY_NEXT_CERTIFICATE_INDEX,
                        ENHANCED_STORAGE_PROPERTY_NEXT_CERTIFICATE_OF_TYPE_INDEX, ENHANCED_STORAGE_PROPERTY_CERTIFICATE_LENGTH,
                        ENHANCED_STORAGE_PROPERTY_CERTIFICATE },
                    true);

                /// <summary>
                /// This command will retrieve the number of certificate slots as well as the number of certificates stored in the silo.
                /// </summary>
                public static CommandData GetCertificateCount => new(ENHANCED_STORAGE_COMMAND_CERT_GET_CERTIFICATE_COUNT,
                    null, new[] { ENHANCED_STORAGE_PROPERTY_MAX_CERTIFICATE_COUNT, ENHANCED_STORAGE_PROPERTY_STORED_CERTIFICATE_COUNT }, true);

                /// <summary>This command retrieves all capabilities from a silo as a collection.</summary>
                public static CommandData GetSiloCapabilities => new(ENHANCED_STORAGE_COMMAND_CERT_GET_SILO_CAPABILITIES,
                    null,
                    new[] { ENHANCED_STORAGE_PROPERTY_CERTIFICATE_SILO_CAPABILITIES, ENHANCED_STORAGE_CAPABILITY_ASYMMETRIC_KEY_CRYPTOGRAPHY,
                        ENHANCED_STORAGE_CAPABILITY_SIGNING_ALGS, ENHANCED_STORAGE_CAPABILITY_RENDER_USER_DATA_UNUSABLE,
                        ENHANCED_STORAGE_CAPABILITY_CERTIFICATE_EXTENSION_PARSING, }, true);

                /// <summary>This command retrieves a capability from the silo. Data returned is in the format native to the silo.</summary>
                public static CommandData GetSiloCapability => new(ENHANCED_STORAGE_COMMAND_CERT_GET_SILO_CAPABILITY,
                    new[] { ENHANCED_STORAGE_PROPERTY_CERTIFICATE_CAPABILITY_TYPE },
                    new[] { ENHANCED_STORAGE_PROPERTY_CERTIFICATE_SILO_CAPABILITY }, true);

                /// <summary>This command will retrieve the GUID associated with the silo.</summary>
                public static CommandData GetSiloGuid => new(ENHANCED_STORAGE_COMMAND_CERT_GET_SILO_GUID,
                    null, new[] { ENHANCED_STORAGE_PROPERTY_CERTIFICATE_SILO_GUID }, true);

                /// <summary>
                /// This command will attempt to initiate a host authentication based on an HCh (or XCh) from the silo. If an index or
                /// certificate is specified, it will be used. The default behavior is to attempt authentication of all HCh or XCh
                /// certificates present on the silo.
                /// </summary>
                public static CommandData HostCertificateAuthentication => new(ENHANCED_STORAGE_COMMAND_CERT_HOST_CERTIFICATE_AUTHENTICATION,
                    new[] { ENHANCED_STORAGE_PROPERTY_CERTIFICATE_INDEX, ENHANCED_STORAGE_PROPERTY_CERTIFICATE }, null, true);

                /// <summary>
                /// This command will attempt to initialize the silo to the manufacturer state. This command requires a successful
                /// administrative authentication. If an administrative authentication has not yet been accomplished, the command will
                /// initiate an administrative authentication operation before initializing the silo to the manufacturer state.
                /// </summary>
                public static CommandData InitializeToManufacturerState => new(ENHANCED_STORAGE_COMMAND_CERT_INITIALIZE_TO_MANUFACTURER_STATE);

                /// <summary>
                /// This command will set a certificate to the certificate index location. This command requires administrative authentication.
                /// </summary>
                public static CommandData SetCertificate => new(ENHANCED_STORAGE_COMMAND_CERT_SET_CERTIFICATE,
                    new[] { ENHANCED_STORAGE_PROPERTY_CERTIFICATE_INDEX, ENHANCED_STORAGE_PROPERTY_CERTIFICATE_TYPE,
                        ENHANCED_STORAGE_PROPERTY_VALIDATION_POLICY, ENHANCED_STORAGE_PROPERTY_SIGNER_CERTIFICATE_INDEX,
                        ENHANCED_STORAGE_PROPERTY_CERTIFICATE },
                    null);

                /// <summary>This command will reset the authentication state of the cert silo to the 'Initialized' state.</summary>
                public static CommandData Unauthentication => new(ENHANCED_STORAGE_COMMAND_CERT_UNAUTHENTICATION);
            }

            /// <summary>Password specific commands</summary>
            public static class Password
            {
                /// <summary>This command attempts to authenticate to the silo for access to the data in the ACT.</summary>
                public static CommandData AuthorizeACTAccess => new(ENHANCED_STORAGE_COMMAND_PASSWORD_AUTHORIZE_ACT_ACCESS,
                    new[] { ENHANCED_STORAGE_PROPERTY_PASSWORD, ENHANCED_STORAGE_PROPERTY_PASSWORD_INDICATOR });

                /// <summary>This command attempts to deauthenticate to the silo for access to the data in the ACT.</summary>
                public static CommandData UnauthorizeACTAccess => new(ENHANCED_STORAGE_COMMAND_PASSWORD_UNAUTHORIZE_ACT_ACCESS,
                    new[] { ENHANCED_STORAGE_PROPERTY_PASSWORD, ENHANCED_STORAGE_PROPERTY_PASSWORD_INDICATOR });

                /// <summary>This command queries the current silo password information.</summary>
                public static CommandData QueryInformation => new(ENHANCED_STORAGE_COMMAND_PASSWORD_QUERY_INFORMATION,
                    null,
                    new[] {ENHANCED_STORAGE_PROPERTY_AUTHENTICATION_STATE, ENHANCED_STORAGE_PROPERTY_PASSWORD_SILO_INFO,
                        ENHANCED_STORAGE_PROPERTY_ADMIN_HINT, ENHANCED_STORAGE_PROPERTY_USER_HINT, ENHANCED_STORAGE_PROPERTY_USER_NAME,
                        ENHANCED_STORAGE_PROPERTY_SILO_NAME }, true);

                /// <summary>This command configures the administrator account.</summary>
                public static CommandData ConfigAdministrator => new(ENHANCED_STORAGE_COMMAND_PASSWORD_CONFIG_ADMINISTRATOR,
                    new[] { ENHANCED_STORAGE_PROPERTY_PASSWORD, ENHANCED_STORAGE_PROPERTY_MAX_AUTH_FAILURES,
                        ENHANCED_STORAGE_PROPERTY_SILO_FRIENDLYNAME_SPECIFIED, ENHANCED_STORAGE_PROPERTY_SILO_NAME }, null);

                /// <summary>This command creates a user account.</summary>
                public static CommandData CreateUser => new(ENHANCED_STORAGE_COMMAND_PASSWORD_CREATE_USER,
                    new[] { ENHANCED_STORAGE_PROPERTY_PASSWORD, ENHANCED_STORAGE_PROPERTY_NEW_PASSWORD,
                        ENHANCED_STORAGE_PROPERTY_USER_HINT, ENHANCED_STORAGE_PROPERTY_USER_NAME,
                        ENHANCED_STORAGE_PROPERTY_MAX_AUTH_FAILURES }, null);

                /// <summary>This command deletes a user account.</summary>
                public static CommandData DeleteUser => new(ENHANCED_STORAGE_COMMAND_PASSWORD_DELETE_USER,
                    new[] { ENHANCED_STORAGE_PROPERTY_PASSWORD }, null);

                /// <summary>This command changes the password for an administrator or user account.</summary>
                public static CommandData ChangePassword => new(ENHANCED_STORAGE_COMMAND_PASSWORD_CHANGE_PASSWORD,
                    new[] { ENHANCED_STORAGE_PROPERTY_PASSWORD_INDICATOR , ENHANCED_STORAGE_PROPERTY_PASSWORD,
                        ENHANCED_STORAGE_PROPERTY_NEW_PASSWORD, ENHANCED_STORAGE_PROPERTY_NEW_PASSWORD_INDICATOR,
                        ENHANCED_STORAGE_PROPERTY_USER_HINT, ENHANCED_STORAGE_PROPERTY_ADMIN_HINT ,
                        ENHANCED_STORAGE_PROPERTY_SECURITY_IDENTIFIER }, null);

                /// <summary>This command initializes an existing user password.</summary>
                public static CommandData InitializeUserPassword => new(ENHANCED_STORAGE_COMMAND_PASSWORD_INITIALIZE_USER_PASSWORD,
                    new[] { ENHANCED_STORAGE_PROPERTY_PASSWORD, ENHANCED_STORAGE_PROPERTY_NEW_PASSWORD, ENHANCED_STORAGE_PROPERTY_USER_HINT }, null);

                /// <summary>This command starts the initialization of the silo to the manufacturer state.</summary>
                public static CommandData InitializeToManufacturerState => new(ENHANCED_STORAGE_COMMAND_PASSWORD_START_INITIALIZE_TO_MANUFACTURER_STATE,
                    new[] { ENHANCED_STORAGE_PROPERTY_SECURITY_IDENTIFIER }, null);
            }
        }

        public class CommandData
        {
            private readonly List<PROPERTYKEY> results;

            internal CommandData(PROPERTYKEY id, IEnumerable<PROPERTYKEY> parameters = null, IEnumerable<PROPERTYKEY> results = null, bool readOnly = false)
            {
                Id = id;
                Parameters = (IReadOnlyList<PROPERTYKEY>)(parameters?.ToList() ?? new List<PROPERTYKEY>(0));
                this.results = results?.ToList() ?? new List<PROPERTYKEY>(1);
                if (!this.results.Contains(PortableDeviceApi.WPD_PROPERTY_COMMON_HRESULT))
                    this.results.Add(PortableDeviceApi.WPD_PROPERTY_COMMON_HRESULT);
                IsReadOnly = readOnly;
            }

            public PROPERTYKEY Id { get; }

            public bool IsReadOnly { get; }
            public IReadOnlyList<PROPERTYKEY> Parameters { get; }
            public IReadOnlyList<PROPERTYKEY> Results => (IReadOnlyList<PROPERTYKEY>)results;
        }
        */
    }