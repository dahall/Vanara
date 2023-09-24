using static Vanara.PInvoke.Crypt32;

namespace Vanara.PInvoke;

public static partial class WinTrust
{
	public const string DRIVER_CLEANUPPOLICY_FUNCTION = "DriverCleanupPolicy";

	public const string DRIVER_FINALPOLPROV_FUNCTION = "DriverFinalPolicy";

	public const string DRIVER_INITPROV_FUNCTION = "DriverInitializePolicy";

	public const string GENERIC_CHAIN_CERTTRUST_FUNCTION = "GenericChainCertificateTrust";

	public const string GENERIC_CHAIN_FINALPOLICY_FUNCTION = "GenericChainFinalProv";

	public const string HTTPS_CERTTRUST_FUNCTION = "HTTPSCertificateTrust";

	public const string HTTPS_CHKCERT_FUNCTION = "HTTPSCheckCertProv";

	public const string HTTPS_FINALPOLICY_FUNCTION = "HTTPSFinalProv";

	public const string OFFICE_CLEANUPPOLICY_FUNCTION = "OfficeCleanupPolicy";

	public const string OFFICE_INITPROV_FUNCTION = "OfficeInitializePolicy";

	public const string SP_CHKCERT_FUNCTION = "SoftpubCheckCert";

	public const string SP_CLEANUPPOLICY_FUNCTION = "SoftpubCleanup";

	public const string SP_FINALPOLICY_FUNCTION = "SoftpubAuthenticode";

	public const string SP_GENERIC_CERT_INIT_FUNCTION = "SoftpubDefCertInit";

	public const string SP_INIT_FUNCTION = "SoftpubInitialize";

	public const string SP_OBJTRUST_FUNCTION = "SoftpubLoadMessage";

	public const string SP_SIGTRUST_FUNCTION = "SoftpubLoadSignature";

	public const string SP_TESTDUMPPOLICY_FUNCTION_TEST = "SoftpubDumpStructure";

	/// <summary>
	/// Assigned to the pgActionID parameter of WinVerifyTrust to verify the authenticity of a file against the Config CI policy. This is an
	/// Authenticode add-on Policy Provider,
	/// </summary>
	public static readonly Guid CONFIG_CI_ACTION_VERIFY = new(0x6078065b, 0x8f22, 0x4b13, 0xbd, 0x9b, 0x5b, 0x76, 0x27, 0x76, 0xf3, 0x86);

	/// <summary>
	/// Assigned to the pgActionID parameter of WinVerifyTrust to verify the authenticity of a WHQL signed driver. This is an Authenticode
	/// add-on Policy Provider,
	/// </summary>
	public static readonly Guid DRIVER_ACTION_VERIFY = new(0xf750e6c3, 0x38ee, 0x11d1, 0x85, 0xe5, 0x0, 0xc0, 0x4f, 0xc2, 0x95, 0xee);

	/// <summary>Assigned to the pgActionID parameter of WinVerifyTrust to verify the SSL/PCT connections through IE.</summary>
	public static readonly Guid HTTPSPROV_ACTION = new(0x573e31f8, 0xaaba, 0x11d0, 0x8c, 0xcb, 0x0, 0xc0, 0x4f, 0xc2, 0x95, 0xee);

	/// <summary>
	/// Assigned to the pgActionID parameter of WinVerifyTrust to verify the authenticity of a Structured Storage file using the Microsoft
	/// Office Authenticode add-on Policy Provider,
	/// </summary>
	public static readonly Guid OFFICESIGN_ACTION_VERIFY = new(0x5555c2cd, 0x17fb, 0x11d1, 0x85, 0xc4, 0x0, 0xc0, 0x4f, 0xc2, 0x95, 0xee);

	/// <summary>
	/// Assigned to the pgActionID parameter of WinVerifyTrust to verify a certificate chain only. This is only valid when passing in a
	/// certificate context in the WinVerifyTrust input structures.
	/// </summary>
	public static readonly Guid WINTRUST_ACTION_GENERIC_CERT_VERIFY = new(0x189a3842, 0x3041, 0x11d1, 0x85, 0xe1, 0x0, 0xc0, 0x4f, 0xc2, 0x95, 0xee);

	/// <summary>
	/// Assigned to the pgActionID parameter of WinVerifyTrust to verify certificate chains created from any object type: file, cert, signer,
	/// ... A callback is provided to implement the final chain policy using the chain context for each signer and counter signer.
	/// </summary>
	public static readonly Guid WINTRUST_ACTION_GENERIC_CHAIN_VERIFY = new(0xfc451c16, 0xac75, 0x11d1, 0xb4, 0xb8, 0x00, 0xc0, 0x4f, 0xb6, 0x6e, 0xa0);

	/// <summary>
	/// Assigned to the pgActionID parameter of WinVerifyTrust to verify the authenticity of a file/object using the Microsoft Authenticode
	/// Policy Provider.
	/// </summary>
	public static readonly Guid WINTRUST_ACTION_GENERIC_VERIFY_V2 = new(0xaac56b, 0xcd44, 0x11d0, 0x8c, 0xc2, 0x0, 0xc0, 0x4f, 0xc2, 0x95, 0xee);

	/// <summary>
	/// Assigned to the pgActionID parameter of WinVerifyTrust to dump the CRYPT_PROVIDER_DATA structure to a file after calling the
	/// Authenticode Policy Provider.
	/// </summary>
	public static readonly Guid WINTRUST_ACTION_TRUSTPROVIDER_TEST = new(0x573e31f8, 0xddba, 0x11d0, 0x8c, 0xcb, 0x0, 0xc0, 0x4f, 0xc2, 0x95, 0xee);

	public unsafe delegate HRESULT PFN_WTD_GENERIC_CHAIN_POLICY_CALLBACK(in CRYPT_PROVIDER_DATA pProvData,
		uint dwStepError, uint dwRegPolicySettings, uint cSigner,
		[In] WTD_GENERIC_CHAIN_POLICY_SIGNER_INFO** rgpSigner, [In] void* pvPolicyArg);

	public enum CCPI : uint
	{
		CCPI_RESULT_ALLOW = 1,
		CCPI_RESULT_DENY = 2,
		CCPI_RESULT_AUDIT = 3,
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct CONFIG_CI_PROV_INFO
	{
		public uint cbSize;
		public uint dwPolicies;
		public uint dwScenario;
		public CRYPTOAPI_BLOB* pPolicies;
		public CONFIG_CI_PROV_INFO_RESULT result;
	}

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct CONFIG_CI_PROV_INFO_RESULT
	{
		public HRESULT hr;
		public CCPI dwResult;
		public uint dwPolicyIndex;
		[MarshalAs(UnmanagedType.U1)]
		public bool fIsExplicitDeny;
	}

	/// <summary>
	/// NOTES:
	/// 1. dwPlatform must_ be set to a non-zero value in order for proper version checking to be done.
	/// 2. dwVersion is no longer used, sOSVersionLow and sOsVersionhigh have taken its place
	/// 3. If dwBuildNumberLow and dwBuildNumberHigh are 0, they are unused. Otherwise, they are considered to be extensions of sOSVersionLow
	/// and sOSVersionHigh respectively. Make special note of this when reading note 4.
	/// 4. If you are validating against a single OS version, then set both sOSVersionLow and sOSVersion high, to the version you are
	/// validating against. If sOSVersionLow and sOSVersionHigh are different, then the validation is done for the whole version range, from
	/// sOSVersionLow to sOSVersionHigh.
	/// </summary>
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DRIVER_VER_INFO
	{
		private const int MAX_PATH = 260;
		public uint cbStruct; // [In] - set to Marshal.SizeOf(typeof(DRIVER_VER_INFO))
		public IntPtr dwReserved1; // [In] - set to default
		public IntPtr dwReserved2; // [In] - set to default
		public uint dwPlatform; // [In] - OPTIONAL: platform to use
		public uint dwVersion; // [In] - OPTIONAL: major version to use (NOT USED!!!)

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
		public string wszVersion; // [Out]"),: version string from catalog file

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
		public string wszSignedBy; // [Out]"),: signer display name from certificate

		public PCCERT_CONTEXT pcSignerCertContext; // [Out]"),: client MUST free this!!!
		public DRIVER_VER_MAJORMINOR sOSVersionLow; // [In] - OPTIONAL: lowest compatible version
		public DRIVER_VER_MAJORMINOR sOSVersionHigh; // [In] - OPTIONAL: highest compatible version
		public uint dwBuildNumberLow; // [In] - OPTIONAL: added to sOSVersionLow as third node for finer version granularity
		public uint dwBuildNumberHigh; // [In] - OPTIONAL: added to sOSVersionHigh as third node for finer version granularity
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct DRIVER_VER_MAJORMINOR
	{
		public uint dwMajor;
		public uint dwMinor;
	}

	// The fields in the following data structure are passed to CertGetCertificateChain().
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct WTD_GENERIC_CHAIN_POLICY_CREATE_INFO
	{
		public uint cbStruct;
		public HCERTCHAINENGINE hChainEngine;
		public CERT_CHAIN_PARA* pChainPara;
		public CertChainFlags dwFlags;
		public IntPtr pvReserved;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct WTD_GENERIC_CHAIN_POLICY_DATA
	{
		public uint cbStruct;
		public WTD_GENERIC_CHAIN_POLICY_CREATE_INFO* pSignerChainInfo;
		public WTD_GENERIC_CHAIN_POLICY_CREATE_INFO* pCounterSignerChainInfo;
		public PFN_WTD_GENERIC_CHAIN_POLICY_CALLBACK pfnPolicyCallback;
		public IntPtr pvPolicyArg;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct WTD_GENERIC_CHAIN_POLICY_SIGNER_INFO
	{
		public uint cbStruct;
		public PCCERT_CHAIN_CONTEXT pChainContext;
		public uint dwSignerType;
		public CMSG_SIGNER_INFO* pMsgSignerInfo;
		public uint dwError;
		public uint cCounterSigner;
		public WTD_GENERIC_CHAIN_POLICY_SIGNER_INFO* rgpCounterSigner;
	}
}