using System;
using System.Linq;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.Ws2_32;
using DNS_STATUS = Vanara.PInvoke.Win32Error;
using IP4_ADDRESS = Vanara.PInvoke.Ws2_32.IN_ADDR;
using IP6_ADDRESS = Vanara.PInvoke.Ws2_32.IN6_ADDR;

namespace Vanara.PInvoke
{
	/// <summary>Functions, structures and constants from windns.h.</summary>
	public static partial class DnsApi
	{
		/// <summary>Defines the maximum sockaddr length for DNS addresses</summary>
		public const int DNS_ADDR_MAX_SOCKADDR_LENGTH = 32;

		/// <summary/>
		public const int DNS_ATMA_MAX_ADDR_LENGTH = 20;

		/// <summary/>
		public const int DNS_MAX_NAME_BUFFER_LENGTH = 256;

		/// <summary/>
		public const uint DNS_QUERY_REQUEST_VERSION1 = 0x1;

		/// <summary/>
		public const uint DNS_QUERY_REQUEST_VERSION2 = 0x2;

		/// <summary/>
		public const uint DNS_QUERY_RESULTS_VERSION1 = 0x1;

		/// <summary>The format of the ATM address in <c>Address</c>.</summary>
		[PInvokeData("windns.h", MSDNShortId = "09df3990-36bd-4656-b5cd-792e521adf9d")]
		public enum ATMA : byte
		{
			/// <summary>
			/// An address of the form: +358.400.1234567\0. The null-terminated hex characters map one-to-one into the ATM address with
			/// arbitrarily placed "." separators. The '+' indicates it is an E.164 format address. Its length is less than
			/// DNS_ATMA_MAX_ADDR_LENGTH bytes.
			/// </summary>
			DNS_ATMA_FORMAT_E164 = 1,

			/// <summary>
			/// An address of the form: 39.246f.123456789abcdefa0123.00123456789a.00. It is a 40 hex character address mapped to 20 octets
			/// with arbitrarily placed "." separators. Its length is exactly DNS_ATMA_AESA_ADDR_LENGTH bytes.
			/// </summary>
			DNS_ATMA_FORMAT_AESA = 2,
		}

		/// <summary>The <c>DNS_CHARSET</c> enumeration specifies the character set used.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/windns/ne-windns-dns_charset typedef enum _DNS_CHARSET { DnsCharSetUnknown,
		// DnsCharSetUnicode, DnsCharSetUtf8, DnsCharSetAnsi } DNS_CHARSET;
		[PInvokeData("windns.h", MSDNShortId = "2674a4e5-c3e2-4a25-bd6f-1fc6b4db3012")]
		public enum DNS_CHARSET
		{
			/// <summary>The character set is unknown.</summary>
			DnsCharSetUnknown,

			/// <summary>The character set is Unicode.</summary>
			DnsCharSetUnicode,

			/// <summary>The character set is UTF8.</summary>
			DnsCharSetUtf8,

			/// <summary>The character set is ANSI.</summary>
			DnsCharSetAnsi,
		}

		/// <summary>A value that represents the RR DNS Record Class.</summary>
		[PInvokeData("windns.h")]
		public enum DNS_CLASS : ushort
		{
			/// <summary/>
			DNS_CLASS_INTERNET = 0x0001,

			/// <summary/>
			DNS_CLASS_CSNET = 0x0002,

			/// <summary/>
			DNS_CLASS_CHAOS = 0x0003,

			/// <summary/>
			DNS_CLASS_HESIOD = 0x0004,

			/// <summary/>
			DNS_CLASS_NONE = 0x00fe,

			/// <summary/>
			DNS_CLASS_ALL = 0x00ff,

			/// <summary/>
			DNS_CLASS_ANY = 0x00ff,

			/// <summary/>
			DNS_CLASS_UNICAST_RESPONSE = 0x8000
		}

		/// <summary>A value that specifies whether to allocate memory for the configuration information.</summary>
		[PInvokeData("windns.h", MSDNShortId = "83de7df8-7e89-42fe-b609-1dc173afc9df")]
		[Flags]
		public enum DNS_CONFIG_FLAG : uint
		{
			/// <summary>Set Flag to DNS_CONFIG_FLAG_ALLOC to allocate memory; otherwise, set it to 0.</summary>
			DNS_CONFIG_FLAG_ALLOC = 1
		}

		/// <summary>The <c>DNS_CONFIG_TYPE</c> enumeration provides DNS configuration type information.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/windns/ne-windns-dns_config_type typedef enum { DnsConfigPrimaryDomainName_W,
		// DnsConfigPrimaryDomainName_A, DnsConfigPrimaryDomainName_UTF8, DnsConfigAdapterDomainName_W, DnsConfigAdapterDomainName_A,
		// DnsConfigAdapterDomainName_UTF8, DnsConfigDnsServerList, DnsConfigSearchList, DnsConfigAdapterInfo,
		// DnsConfigPrimaryHostNameRegistrationEnabled, DnsConfigAdapterHostNameRegistrationEnabled, DnsConfigAddressRegistrationMaxCount,
		// DnsConfigHostName_W, DnsConfigHostName_A, DnsConfigHostName_UTF8, DnsConfigFullHostName_W, DnsConfigFullHostName_A,
		// DnsConfigFullHostName_UTF8, DnsConfigNameServer } DNS_CONFIG_TYPE;
		[PInvokeData("windns.h", MSDNShortId = "e0f0cc05-dcfe-48df-8dbd-e756cfa69154")]
		public enum DNS_CONFIG_TYPE
		{
			/// <summary>For use with Unicode on Windows 2000.</summary>
			[CorrespondingType(typeof(string))]
			[CorrespondingType(typeof(StrPtrUni))]
			DnsConfigPrimaryDomainName_W,

			/// <summary>For use with ANSI on Windows 2000.</summary>
			[CorrespondingType(typeof(StrPtrAnsi))]
			DnsConfigPrimaryDomainName_A,

			/// <summary>For use with UTF8 on Windows 2000.</summary>
			DnsConfigPrimaryDomainName_UTF8,

			/// <summary>Not currently available.</summary>
			DnsConfigAdapterDomainName_W,

			/// <summary>Not currently available.</summary>
			DnsConfigAdapterDomainName_A,

			/// <summary>Not currently available.</summary>
			DnsConfigAdapterDomainName_UTF8,

			/// <summary>For configuring a DNS Server list on Windows 2000.</summary>
			[CorrespondingType(typeof(IP4_ARRAY))]
			DnsConfigDnsServerList,

			/// <summary>Not currently available.</summary>
			DnsConfigSearchList,

			/// <summary>Not currently available.</summary>
			DnsConfigAdapterInfo,

			/// <summary>Specifies that primary host name registration is enabled on Windows 2000.</summary>
			[CorrespondingType(typeof(uint))]
			DnsConfigPrimaryHostNameRegistrationEnabled,

			/// <summary>Specifies that adapter host name registration is enabled on Windows 2000.</summary>
			[CorrespondingType(typeof(uint))]
			DnsConfigAdapterHostNameRegistrationEnabled,

			/// <summary>Specifies configuration of the maximum number of address registrations on Windows 2000.</summary>
			[CorrespondingType(typeof(uint))]
			DnsConfigAddressRegistrationMaxCount,

			/// <summary>
			/// Specifies configuration of the host name in Unicode on Windows XP, Windows Server 2003, and later versions of Windows.
			/// </summary>
			[CorrespondingType(typeof(string))]
			[CorrespondingType(typeof(StrPtrUni))]
			DnsConfigHostName_W,

			/// <summary>Specifies configuration of the host name in ANSI on Windows XP, Windows Server 2003, and later versions of Windows.</summary>
			[CorrespondingType(typeof(StrPtrAnsi))]
			DnsConfigHostName_A,

			/// <summary>Specifies configuration of the host name in UTF8 on Windows XP, Windows Server 2003, and later versions of Windows.</summary>
			DnsConfigHostName_UTF8,

			/// <summary>
			/// Specifies configuration of the full host name (fully qualified domain name) in Unicode on Windows XP, Windows Server 2003,
			/// and later versions of Windows.
			/// </summary>
			[CorrespondingType(typeof(string))]
			[CorrespondingType(typeof(StrPtrUni))]
			DnsConfigFullHostName_W,

			/// <summary>
			/// Specifies configuration of the full host name (fully qualified domain name) in ANSI on Windows XP, Windows Server 2003, and
			/// later versions of Windows.
			/// </summary>
			[CorrespondingType(typeof(StrPtrAnsi))]
			DnsConfigFullHostName_A,

			/// <summary>
			/// Specifies configuration of the full host name (fully qualified domain name) in UTF8 on Windows XP, Windows Server 2003, and
			/// later versions of Windows.
			/// </summary>
			DnsConfigFullHostName_UTF8,

			/// <summary/>
			DnsConfigNameServer,
		}

		/// <summary>The <c>DNS_FREE_TYPE</c> enumeration specifies the type of data to free.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/windns/ne-windns-dns_free_type typedef enum { DnsFreeFlat, DnsFreeRecordList,
		// DnsFreeParsedMessageFields } DNS_FREE_TYPE;
		[PInvokeData("windns.h", MSDNShortId = "976982a1-08f1-4c67-b823-1eea34f0c643")]
		public enum DNS_FREE_TYPE
		{
			/// <summary>The data freed is a flat structure.</summary>
			DnsFreeFlat,

			/// <summary>
			/// The data freed is a Resource Record list, and includes subfields of the DNS_RECORD structure. Resources freed include
			/// structures returned by the DnsQuery and DnsRecordSetCopyEx functions.
			/// </summary>
			DnsFreeRecordList,

			/// <summary>The data freed is a parsed message field.</summary>
			DnsFreeParsedMessageFields,
		}

		/// <summary>The <c>DNS_NAME_FORMAT</c> enumeration specifies name format information for DNS.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/windns/ne-windns-dns_name_format typedef enum _DNS_NAME_FORMAT {
		// DnsNameDomain, DnsNameDomainLabel, DnsNameHostnameFull, DnsNameHostnameLabel, DnsNameWildcard, DnsNameSrvRecord,
		// DnsNameValidateTld } DNS_NAME_FORMAT;
		[PInvokeData("windns.h", MSDNShortId = "f6f1cff3-4bff-4a07-bbc6-5255030b4164")]
		public enum DNS_NAME_FORMAT
		{
			/// <summary>The name format is a DNS domain.</summary>
			DnsNameDomain,

			/// <summary>The name format is a DNS domain label.</summary>
			DnsNameDomainLabel,

			/// <summary>The name format is a full DNS host name.</summary>
			DnsNameHostnameFull,

			/// <summary>The name format is a DNS host label.</summary>
			DnsNameHostnameLabel,

			/// <summary>The name format is a DNS wildcard.</summary>
			DnsNameWildcard,

			/// <summary>The name format is a DNS SRV record.</summary>
			DnsNameSrvRecord,

			/// <summary>Windows 7 or later: The name format is a DNS domain or a full DNS host name.</summary>
			DnsNameValidateTld,
		}

		/// <summary>A value representing the type of the query.</summary>
		[PInvokeData("windns.h")]
		public enum DNS_OPCODE : ushort
		{
			/// <summary/>
			DNS_OPCODE_QUERY = 0,

			/// <summary/>
			DNS_OPCODE_IQUERY = 1,

			/// <summary/>
			DNS_OPCODE_SERVER_STATUS = 2,

			/// <summary/>
			DNS_OPCODE_UNKNOWN = 3,

			/// <summary/>
			DNS_OPCODE_NOTIFY = 4,

			/// <summary/>
			DNS_OPCODE_UPDATE = 5,
		}

		/// <summary>
		/// The <c>DNS_PROXY_INFORMATION_TYPE</c> enumeration defines the proxy information type in the DNS_PROXY_INFORMATION structure.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/windns/ne-windns-dns_proxy_information_type typedef enum
		// DNS_PROXY_INFORMATION_TYPE { DNS_PROXY_INFORMATION_DIRECT, DNS_PROXY_INFORMATION_DEFAULT_SETTINGS,
		// DNS_PROXY_INFORMATION_PROXY_NAME, DNS_PROXY_INFORMATION_DOES_NOT_EXIST } ;
		[PInvokeData("windns.h", MSDNShortId = "983d38f3-3ee7-4df6-a9ff-f908f250020f")]
		public enum DNS_PROXY_INFORMATION_TYPE
		{
			/// <summary>The type is bypass proxy information.</summary>
			DNS_PROXY_INFORMATION_DIRECT,

			/// <summary>The type is the user's default browser proxy settings.</summary>
			DNS_PROXY_INFORMATION_DEFAULT_SETTINGS,

			/// <summary>The type is defined by the proxyName member of the DNS_PROXY_INFORMATION structure.</summary>
			DNS_PROXY_INFORMATION_PROXY_NAME,

			/// <summary>
			/// The type does not exist. DNS policy does not have proxy information for this name space. This type is used if no wildcard
			/// policy exists and there is no default proxy information.
			/// </summary>
			DNS_PROXY_INFORMATION_DOES_NOT_EXIST,
		}

		/// <summary>A value representing the query options.</summary>
		[PInvokeData("windns.h")]
		[Flags]
		public enum DNS_QUERY_OPTIONS : ulong
		{
			/// <summary/>
			DNS_QUERY_STANDARD = 0x00000000,

			/// <summary/>
			DNS_QUERY_ACCEPT_TRUNCATED_RESPONSE = 0x00000001,

			/// <summary/>
			DNS_QUERY_USE_TCP_ONLY = 0x00000002,

			/// <summary/>
			DNS_QUERY_NO_RECURSION = 0x00000004,

			/// <summary/>
			DNS_QUERY_BYPASS_CACHE = 0x00000008,

			/// <summary/>
			DNS_QUERY_NO_WIRE_QUERY = 0x00000010,

			/// <summary/>
			DNS_QUERY_NO_LOCAL_NAME = 0x00000020,

			/// <summary/>
			DNS_QUERY_NO_HOSTS_FILE = 0x00000040,

			/// <summary/>
			DNS_QUERY_NO_NETBT = 0x00000080,

			/// <summary/>
			DNS_QUERY_WIRE_ONLY = 0x00000100,

			/// <summary/>
			DNS_QUERY_RETURN_MESSAGE = 0x00000200,

			/// <summary/>
			DNS_QUERY_MULTICAST_ONLY = 0x00000400,

			/// <summary/>
			DNS_QUERY_NO_MULTICAST = 0x00000800,

			/// <summary/>
			DNS_QUERY_TREAT_AS_FQDN = 0x00001000,

			/// <summary/>
			DNS_QUERY_ADDRCONFIG = 0x00002000,

			/// <summary/>
			DNS_QUERY_DUAL_ADDR = 0x00004000,

			/// <summary>Undocumented flag used by ipconfig to display DNS cache.</summary>
			DNS_QUERY_LOCAL = 0x00008000,

			/// <summary/>
			DNS_QUERY_DONT_RESET_TTL_VALUES = 0x00100000,

			/// <summary/>
			DNS_QUERY_DISABLE_IDN_ENCODING = 0x00200000,

			/// <summary/>
			DNS_QUERY_APPEND_MULTILABEL = 0x00800000,

			/// <summary/>
			DNS_QUERY_DNSSEC_OK = 0x01000000,

			/// <summary/>
			DNS_QUERY_DNSSEC_CHECKING_DISABLED = 0x02000000,

			/// <summary/>
			DNS_QUERY_RESERVED = 0xf0000000,
		}

		/// <summary>An error or response code, expressed in expanded RCODE format.</summary>
		[PInvokeData("windns.h", MSDNShortId = "4dad3449-3e41-47d9-89c2-10fa6e51573b")]
		public enum DNS_RCODE : ushort
		{
			/// <summary>No error.</summary>
			DNS_RCODE_NOERROR = 0,

			/// <summary>Format error.</summary>
			DNS_RCODE_FORMERR = 1,

			/// <summary>Server failure.</summary>
			DNS_RCODE_SERVFAIL = 2,

			/// <summary>Name error</summary>
			DNS_RCODE_NXDOMAIN = 3,

			/// <summary>Not implemented.</summary>
			DNS_RCODE_NOTIMPL = 4,

			/// <summary>Connection refused.</summary>
			DNS_RCODE_REFUSED = 5,

			/// <summary>Domain name should not exist.</summary>
			DNS_RCODE_YXDOMAIN = 6,

			/// <summary>Resource Record (RR) set should not exist.</summary>
			DNS_RCODE_YXRRSET = 7,

			/// <summary>RR set does not exist</summary>
			DNS_RCODE_NXRRSET = 8,

			/// <summary>Not authoritative for zone</summary>
			DNS_RCODE_NOTAUTH = 9,

			/// <summary>Name not in zone</summary>
			DNS_RCODE_NOTZONE = 10,

			/// <summary>Bad version.</summary>
			DNS_RCODE_BADVERS = 16,

			/// <summary>The pSignature of the DNS_TSIG_DATA RR is bad.</summary>
			DNS_RCODE_BADSIG = 16,

			/// <summary>The pKey field is bad.</summary>
			DNS_RCODE_BADKEY = 17,

			/// <summary>A timestamp is bad.</summary>
			DNS_RCODE_BADTIME = 18,
		}

		/// <summary>
		/// The <c>DNS_SECTION</c> enumeration is used in record flags, and as an index into DNS wire message header section counts.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/windns/ne-windns-dns_section typedef enum _DnsSection { DnsSectionQuestion,
		// DnsSectionAnswer, DnsSectionAuthority, DnsSectionAddtional } DNS_SECTION;
		[PInvokeData("windns.h", MSDNShortId = "d51ef2c7-c2bb-4eed-a026-a559460352b6")]
		public enum DNS_SECTION
		{
			/// <summary>The DNS section specified is a DNS question.</summary>
			DnsSectionQuestion,

			/// <summary>The DNS section specified is a DNS answer.</summary>
			DnsSectionAnswer,

			/// <summary>The DNS section specified indicates a DNS authority.</summary>
			DnsSectionAuthority,

			/// <summary>The DNS section specified is additional DNS information.</summary>
			DnsSectionAddtional,
		}

		/// <summary>A scheme used for key agreement or the purpose of the TKEY DNS Message.</summary>
		[PInvokeData("windns.h", MSDNShortId = "4dad3449-3e41-47d9-89c2-10fa6e51573b")]
		public enum DNS_TKEY_MODE : ushort
		{
			/// <summary>The key is assigned by the DNS server and is not negotiated.</summary>
			DNS_TKEY_MODE_SERVER_ASSIGN = 1,

			/// <summary>The Diffie-Hellman key exchange algorithm is used to negotiate the key.</summary>
			DNS_TKEY_MODE_DIFFIE_HELLMAN = 2,

			/// <summary>The key is exchanged through Generic Security Services-Application Program Interface (GSS-API) negotiation.</summary>
			DNS_TKEY_MODE_GSS = 3,

			/// <summary>The key is assigned by the DNS resolver and is not negotiated.</summary>
			DNS_TKEY_MODE_RESOLVER_ASSIGN = 4,
		}

		/// <summary>DNS record types.</summary>
		[PInvokeData("windns.h")]
		public enum DNS_TYPE : ushort
		{
			/// <summary/>
			[CorrespondingType(typeof(DNS_A_DATA))]
			DNS_TYPE_A = 0x0001,

			/// <summary/>
			[CorrespondingType(typeof(DNS_PTR_DATA))]
			DNS_TYPE_NS = 0x0002,

			/// <summary/>
			[CorrespondingType(typeof(DNS_PTR_DATA))]
			DNS_TYPE_MD = 0x0003,

			/// <summary/>
			[CorrespondingType(typeof(DNS_PTR_DATA))]
			DNS_TYPE_MF = 0x0004,

			/// <summary/>
			[CorrespondingType(typeof(DNS_PTR_DATA))]
			DNS_TYPE_CNAME = 0x0005,

			/// <summary/>
			[CorrespondingType(typeof(DNS_SOA_DATA))]
			DNS_TYPE_SOA = 0x0006,

			/// <summary/>
			[CorrespondingType(typeof(DNS_PTR_DATA))]
			DNS_TYPE_MB = 0x0007,

			/// <summary/>
			[CorrespondingType(typeof(DNS_PTR_DATA))]
			DNS_TYPE_MG = 0x0008,

			/// <summary/>
			[CorrespondingType(typeof(DNS_PTR_DATA))]
			DNS_TYPE_MR = 0x0009,

			/// <summary/>
			[CorrespondingType(typeof(DNS_NULL_DATA))]
			DNS_TYPE_NULL = 0x000a,

			/// <summary/>
			[CorrespondingType(typeof(DNS_WKS_DATA))]
			DNS_TYPE_WKS = 0x000b,

			/// <summary/>
			[CorrespondingType(typeof(DNS_PTR_DATA))]
			DNS_TYPE_PTR = 0x000c,

			/// <summary/>
			[CorrespondingType(typeof(DNS_TXT_DATA))]
			DNS_TYPE_HINFO = 0x000d,

			/// <summary/>
			[CorrespondingType(typeof(DNS_MINFO_DATA))]
			DNS_TYPE_MINFO = 0x000e,

			/// <summary/>
			[CorrespondingType(typeof(DNS_MX_DATA))]
			DNS_TYPE_MX = 0x000f,

			/// <summary/>
			[CorrespondingType(typeof(DNS_TXT_DATA))]
			DNS_TYPE_TEXT = 0x0010,

			/// <summary/>
			[CorrespondingType(typeof(DNS_MINFO_DATA))]
			DNS_TYPE_RP = 0x0011,

			/// <summary/>
			[CorrespondingType(typeof(DNS_MX_DATA))]
			DNS_TYPE_AFSDB = 0x0012,

			/// <summary/>
			[CorrespondingType(typeof(DNS_TXT_DATA))]
			DNS_TYPE_X25 = 0x0013,

			/// <summary/>
			[CorrespondingType(typeof(DNS_TXT_DATA))]
			DNS_TYPE_ISDN = 0x0014,

			/// <summary/>
			[CorrespondingType(typeof(DNS_MX_DATA))]
			DNS_TYPE_RT = 0x0015,

			/// <summary/>
			DNS_TYPE_NSAP = 0x0016,

			/// <summary/>
			DNS_TYPE_NSAPPTR = 0x0017,

			/// <summary/>
			[CorrespondingType(typeof(DNS_SIG_DATA))]
			DNS_TYPE_SIG = 0x0018,

			/// <summary/>
			[CorrespondingType(typeof(DNS_KEY_DATA))]
			DNS_TYPE_KEY = 0x0019,

			/// <summary/>
			DNS_TYPE_PX = 0x001a,

			/// <summary/>
			DNS_TYPE_GPOS = 0x001b,

			/// <summary/>
			[CorrespondingType(typeof(DNS_AAAA_DATA))]
			DNS_TYPE_AAAA = 0x001c,

			/// <summary/>
			[CorrespondingType(typeof(DNS_LOC_DATA))]
			DNS_TYPE_LOC = 0x001d,

			/// <summary/>
			[CorrespondingType(typeof(DNS_NXT_DATA))]
			DNS_TYPE_NXT = 0x001e,

			/// <summary/>
			DNS_TYPE_EID = 0x001f,

			/// <summary/>
			DNS_TYPE_NIMLOC = 0x0020,

			/// <summary/>
			[CorrespondingType(typeof(DNS_SRV_DATA))]
			DNS_TYPE_SRV = 0x0021,

			/// <summary/>
			[CorrespondingType(typeof(DNS_ATMA_DATA))]
			DNS_TYPE_ATMA = 0x0022,

			/// <summary/>
			[CorrespondingType(typeof(DNS_NAPTR_DATA))]
			DNS_TYPE_NAPTR = 0x0023,

			/// <summary/>
			DNS_TYPE_KX = 0x0024,

			/// <summary/>
			DNS_TYPE_CERT = 0x0025,

			/// <summary/>
			DNS_TYPE_A6 = 0x0026,

			/// <summary/>
			[CorrespondingType(typeof(DNS_PTR_DATA))]
			DNS_TYPE_DNAME = 0x0027,

			/// <summary/>
			DNS_TYPE_SINK = 0x0028,

			/// <summary/>
			[CorrespondingType(typeof(DNS_OPT_DATA))]
			DNS_TYPE_OPT = 0x0029,

			/// <summary/>
			[CorrespondingType(typeof(DNS_DS_DATA))]
			DNS_TYPE_DS = 0x002b,

			/// <summary/>
			DNS_TYPE_RRSIG = 0x002e,

			/// <summary/>
			[CorrespondingType(typeof(DNS_NSEC_DATA))]
			DNS_TYPE_NSEC = 0x002f,

			/// <summary/>
			DNS_TYPE_DNSKEY = 0x0030,

			/// <summary/>
			[CorrespondingType(typeof(DNS_DHCID_DATA))]
			DNS_TYPE_DHCID = 0x0031,

			/// <summary/>
			[CorrespondingType(typeof(DNS_NSEC3_DATA))]
			DNS_TYPE_NSEC3 = 0x0032,

			/// <summary/>
			[CorrespondingType(typeof(DNS_NSEC3PARAM_DATA))]
			DNS_TYPE_NSEC3PARAM = 0x0033,

			/// <summary/>
			[CorrespondingType(typeof(DNS_TLSA_DATA))]
			DNS_TYPE_TLSA = 0x0034,

			/// <summary/>
			DNS_TYPE_UINFO = 0x0064,

			/// <summary/>
			DNS_TYPE_UID = 0x0065,

			/// <summary/>
			DNS_TYPE_GID = 0x0066,

			/// <summary/>
			DNS_TYPE_UNSPEC = 0x0067,

			/// <summary/>
			DNS_TYPE_ADDRS = 0x00f8,

			/// <summary/>
			[CorrespondingType(typeof(DNS_TKEY_DATA))]
			DNS_TYPE_TKEY = 0x00f9,

			/// <summary/>
			[CorrespondingType(typeof(DNS_TSIG_DATA))]
			DNS_TYPE_TSIG = 0x00fa,

			/// <summary/>
			DNS_TYPE_IXFR = 0x00fb,

			/// <summary/>
			DNS_TYPE_AXFR = 0x00fc,

			/// <summary/>
			DNS_TYPE_MAILB = 0x00fd,

			/// <summary/>
			DNS_TYPE_MAILA = 0x00fe,

			/// <summary/>
			DNS_TYPE_ALL = 0x00ff,

			/// <summary/>
			DNS_TYPE_ANY = 0x00ff,

			/// <summary/>
			[CorrespondingType(typeof(DNS_WINS_DATA))]
			DNS_TYPE_WINS = 0xff01,

			/// <summary/>
			[CorrespondingType(typeof(DNS_WINSR_DATA))]
			DNS_TYPE_WINSR = 0xff02,

			/// <summary/>
			[CorrespondingType(typeof(DNS_WINSR_DATA))]
			DNS_TYPE_NBSTAT = (DNS_TYPE_WINSR),
		}

		/// <summary>A value that contains a bitmap of DNS Update Options.</summary>
		[PInvokeData("windns.h", MSDNShortId = "7b99f440-72fa-4cf4-9267-98f436e99a50")]
		[Flags]
		public enum DNS_UPDATE : uint
		{
			/// <summary/>
			DNS_UPDATE_SECURITY_USE_DEFAULT = 0x00000000,

			/// <summary/>
			DNS_UPDATE_SECURITY_OFF = 0x00000010,

			/// <summary/>
			DNS_UPDATE_SECURITY_ON = 0x00000020,

			/// <summary/>
			DNS_UPDATE_SECURITY_ONLY = 0x00000100,

			/// <summary/>
			DNS_UPDATE_CACHE_SECURITY_CONTEXT = 0x00000200,

			/// <summary/>
			DNS_UPDATE_TEST_USE_LOCAL_SYS_ACCT = 0x00000400,

			/// <summary/>
			DNS_UPDATE_FORCE_SECURITY_NEGO = 0x00000800,

			/// <summary/>
			DNS_UPDATE_TRY_ALL_MASTER_SERVERS = 0x00001000,

			/// <summary/>
			DNS_UPDATE_SKIP_NO_UPDATE_ADAPTERS = 0x00002000,

			/// <summary/>
			DNS_UPDATE_REMOTE_SERVER = 0x00004000,

			/// <summary/>
			DNS_UPDATE_RESERVED = 0xffff0000,
		}

		/// <summary>The WINS mapping flag that specifies whether the record must be included in zone replication.</summary>
		[PInvokeData("windns.h", MSDNShortId = "df41c397-e662-42b4-9193-6776f9071898")]
		public enum DNS_WINS_FLAG : uint
		{
			/// <summary>Record is not local, replicate across zones.</summary>
			DNS_WINS_FLAG_SCOPE = 0x80000000,

			/// <summary>Record is local, do not replicate.</summary>
			DNS_WINS_FLAG_LOCAL = 0x00010000,
		}

		/// <summary>Represents the query validation status.</summary>
		[PInvokeData("windns.h", MSDNShortId = "5b362d05-87b2-44dd-8198-bcb5ab5a64f6")]
		public enum DnsServerStatus : uint
		{
			/// <summary>No errors. The call was successful.</summary>
			ERROR_SUCCESS = 0,

			/// <summary>server IP address was invalid.</summary>
			DNS_VALSVR_ERROR_INVALID_ADDR = 0x01,

			/// <summary>queryName FQDN was invalid.</summary>
			DNS_VALSVR_ERROR_INVALID_NAME = 0x02,

			/// <summary>DNS server was unreachable.</summary>
			DNS_VALSVR_ERROR_UNREACHABLE = 0x03,

			/// <summary>Timeout waiting for the DNS server response.</summary>
			DNS_VALSVR_ERROR_NO_RESPONSE = 0x04,

			/// <summary>DNS server was not authoritative or queryName was not found.</summary>
			DNS_VALSVR_ERROR_NO_AUTH = 0x05,

			/// <summary>DNS server refused the query.</summary>
			DNS_VALSVR_ERROR_REFUSED = 0x06,

			/// <summary>
			/// The TCP query did not return ERROR_SUCCESS after the validation system had already completed a successful query to the DNS
			/// server using UDP.
			/// </summary>
			DNS_VALSVR_ERROR_NO_TCP = 0x10,

			/// <summary>An unknown error occurred.</summary>
			DNS_VALSVR_ERROR_UNKNOWN = 0xFF,
		}

		/// <summary>The <c>DNS_A_DATA</c> structure represents a DNS address (A) record as specified in section 3.4.1 of RFC 1035.</summary>
		/// <remarks>
		/// The <c>DNS_A_DATA</c> structure is used in conjunction with the DNS_RECORD structure to programmatically manage DNS entries.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/windns/ns-windns-dns_a_data typedef struct { IP4_ADDRESS IpAddress; }
		// DNS_A_DATA, *PDNS_A_DATA;
		[PInvokeData("windns.h", MSDNShortId = "0fd21930-1319-4ae7-b46f-2b744f4faae9")]
		[StructLayout(LayoutKind.Sequential)]
		public struct DNS_A_DATA
		{
			/// <summary>An IP4_ADDRESS data type that contains an IPv4 address.</summary>
			public IP4_ADDRESS IpAddress;
		}

		/// <summary>The <c>DNS_AAAA_DATA</c> structure represents a DNS IPv6 (AAAA) record as specified in RFC 3596.</summary>
		/// <remarks>
		/// The <c>DNS_AAAA_DATA</c> structure is used in conjunction with the DNS_RECORD structure to programmatically manage DNS entries.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/windns/ns-windns-dns_aaaa_data typedef struct { IP6_ADDRESS Ip6Address; }
		// DNS_AAAA_DATA, *PDNS_AAAA_DATA;
		[PInvokeData("windns.h", MSDNShortId = "0bc48e86-368c-431c-b67a-b7689dca8d3c")]
		[StructLayout(LayoutKind.Sequential)]
		public struct DNS_AAAA_DATA
		{
			/// <summary>An IP6_ADDRESS data type that contains an IPv6 address.</summary>
			public IP6_ADDRESS Ip6Address;
		}

		/// <summary>A <c>DNS_ADDR</c> structure stores an IPv4 or IPv6 address.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/windns/ns-windns-dns_addr typedef struct _DnsAddr { CHAR
		// MaxSa[DNS_ADDR_MAX_SOCKADDR_LENGTH]; DWORD DnsAddrUserDword[8]; } DNS_ADDR, *PDNS_ADDR;
		[PInvokeData("windns.h", MSDNShortId = "c14e6fc0-34b3-40e8-b9b8-61e4aea01677")]
		[StructLayout(LayoutKind.Sequential)]
		public struct DNS_ADDR
		{
			/// <summary>
			/// A value that contains the socket IP address. It is a sockaddr_in structure if the address is IPv4 and a sockaddr_in6
			/// structure if the address is IPv6.
			/// </summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = DNS_ADDR_MAX_SOCKADDR_LENGTH)]
			public byte[] MaxSa;

			/// <summary>Reserved. Must be 0.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
			public uint[] DnsAddrUserDword;

			/// <summary>Performs an explicit conversion from <see cref="DNS_ADDR"/> to <see cref="System.Net.IPAddress"/>.</summary>
			/// <param name="dnsAddr">The DNS address.</param>
			/// <returns>The resulting <see cref="System.Net.IPAddress"/> instance from the conversion.</returns>
			public static explicit operator System.Net.IPAddress(DNS_ADDR dnsAddr) => new System.Net.IPAddress(dnsAddr.MaxSa);
		}

		/// <summary>The <c>DNS_ADDR_ARRAY</c> structure stores an array of IPv4 or IPv6 addresses.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/windns/ns-windns-dns_addr_array typedef struct _DnsAddrArray { DWORD MaxCount;
		// DWORD AddrCount; DWORD Tag; WORD Family; WORD WordReserved; DWORD Flags; DWORD MatchFlag; DWORD Reserved1; DWORD Reserved2;
		// DNS_ADDR AddrArray[]; } DNS_ADDR_ARRAY, *PDNS_ADDR_ARRAY;
		[PInvokeData("windns.h", MSDNShortId = "5FD7F28B-D1A6-4731-ACB9-A7BB23CC1FB4")]
		[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<DNS_ADDR_ARRAY>), nameof(AddrCount))]
		[StructLayout(LayoutKind.Sequential)]
		public struct DNS_ADDR_ARRAY
		{
			/// <summary>Indicates, the size, in bytes, of this structure.</summary>
			public uint MaxCount;

			/// <summary>Indicates the number of DNS_ADDR structures contained in the <c>AddrArray</c> member.</summary>
			public uint AddrCount;

			/// <summary>Reserved. Do not use.</summary>
			public uint Tag;

			/// <summary>
			/// <para>A value that specifies the IP family. Possible values are:</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>AF_INET6</term>
			/// <term>IPv6</term>
			/// </item>
			/// <item>
			/// <term>AF_INET</term>
			/// <term>IPv4</term>
			/// </item>
			/// </list>
			/// </summary>
			public ADDRESS_FAMILY Family;

			/// <summary>Reserved. Do not use.</summary>
			public ushort WordReserved;

			/// <summary>Reserved. Do not use.</summary>
			public uint Flags;

			/// <summary>Reserved. Do not use.</summary>
			public uint MatchFlag;

			/// <summary>Reserved. Do not use.</summary>
			public uint Reserved1;

			/// <summary>Reserved. Do not use.</summary>
			public uint Reserved2;

			/// <summary>An array of DNS_ADDR structures that each contain an IP address.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
			public DNS_ADDR[] AddrArray;
		}

		/// <summary>The <c>DNS_ATMA_DATA</c> structure represents a DNS ATM address (ATMA) resource record (RR).</summary>
		/// <remarks>
		/// The <c>DNS_ATMA_DATA</c> structure is used in conjunction with the DNS_RECORD structure to programmatically manage DNS entries.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/windns/ns-windns-dns_atma_data typedef struct { BYTE AddressType; BYTE
		// Address[DNS_ATMA_MAX_ADDR_LENGTH]; } DNS_ATMA_DATA, *PDNS_ATMA_DATA;
		[PInvokeData("windns.h", MSDNShortId = "09df3990-36bd-4656-b5cd-792e521adf9d")]
		[StructLayout(LayoutKind.Sequential)]
		public struct DNS_ATMA_DATA
		{
			/// <summary>
			/// <para>The format of the ATM address in <c>Address</c>. The possible values for <c>AddressType</c> are:</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>DNS_ATMA_FORMAT_AESA</term>
			/// <term>
			/// An address of the form: 39.246f.123456789abcdefa0123.00123456789a.00. It is a 40 hex character address mapped to 20 octets
			/// with arbitrarily placed "." separators. Its length is exactly DNS_ATMA_AESA_ADDR_LENGTH bytes.
			/// </term>
			/// </item>
			/// <item>
			/// <term>DNS_ATMA_FORMAT_E164</term>
			/// <term>
			/// An address of the form: +358.400.1234567\0. The null-terminated hex characters map one-to-one into the ATM address with
			/// arbitrarily placed "." separators. The '+' indicates it is an E.164 format address. Its length is less than
			/// DNS_ATMA_MAX_ADDR_LENGTH bytes.
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			public ATMA AddressType;

			/// <summary>A <c>BYTE</c> array that contains the ATM address whose format is specified by <c>AddressType</c>.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = DNS_ATMA_MAX_ADDR_LENGTH)]
			public byte[] Address;
		}

		/// <summary>Undocumented.</summary>
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct DNS_CACHE_ENTRY
		{
			/// <summary>Pointer to next entry.</summary>
			public IntPtr pNext;

			/// <summary>DNS Record Name.</summary>
			public StrPtrUni pszName;

			/// <summary>DNS Record Type.</summary>
			public DNS_TYPE wType;

			/// <summary>Undocumented.</summary>
			public ushort wDataLength;

			/// <summary>Undocumented.</summary>
			public DNS_RECORD_FLAGS dwFlags;
		}

		/// <summary>
		/// The <c>DNS_DHCID_DATA</c> structure represents a DNS Dynamic Host Configuration Protocol Information (DHCID) resource record
		/// (RR) as specified in section 3 of RFC 4701.
		/// </summary>
		/// <remarks>
		/// The <c>DNS_DHCID_DATA</c> structure is used in conjunction with the DNS_RECORD structure to programmatically manage DNS entries.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/windns/ns-windns-dns_dhcid_data typedef struct { DWORD dwByteCount; #if ...
		// BYTE DHCID[]; #else BYTE DHCID[1]; #endif } DNS_DHCID_DATA, *PDNS_DHCID_DATA;
		[PInvokeData("windns.h", MSDNShortId = "868846bc-9f63-4bb3-ac8d-cea34232bb41")]
		[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<DNS_DHCID_DATA>), nameof(dwByteCount))]
		[StructLayout(LayoutKind.Sequential)]
		public struct DNS_DHCID_DATA
		{
			/// <summary>The length, in bytes, of <c>DHCID</c>.</summary>
			public uint dwByteCount;

			/// <summary>
			/// A <c>BYTE</c> array that contains the DHCID client, domain, and SHA-256 digest information as specified in section 4 of RFC 2671.
			/// </summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
			public byte[] DHCID;
		}

		/// <summary>
		/// The <c>DNS_DS_DATA</c> structure represents a DS resource record (RR) as specified in section 2 of RFC 4034 and is used to
		/// verify the contents of DNS_DNSKEY_DATA.
		/// </summary>
		/// <remarks>
		/// The <c>DNS_DS_DATA</c> structure is used in conjunction with the DNS_RECORD structure to programmatically manage DNS entries.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/windns/ns-windns-dns_ds_data typedef struct { WORD wKeyTag; BYTE chAlgorithm;
		// BYTE chDigestType; WORD wDigestLength; WORD wPad; #if ... BYTE Digest[]; #else BYTE Digest[1]; #endif } DNS_DS_DATA, *PDNS_DS_DATA;
		[PInvokeData("windns.h", MSDNShortId = "8624cc27-feb5-4e4a-8970-40aa1d43960e")]
		[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<DNS_DS_DATA>), nameof(wDigestLength))]
		[StructLayout(LayoutKind.Sequential)]
		public struct DNS_DS_DATA
		{
			/// <summary>
			/// A value that represents the method to choose which public key is used to verify <c>Signature</c> in DNS_RRSIG_DATA as
			/// specified in Appendix B of RFC 4034. This value is identical to the <c>wKeyTag</c> field in <c>DNS_RRSIG_DATA</c>.
			/// </summary>
			public ushort wKeyTag;

			/// <summary>
			/// <para>A value that specifies the algorithm defined by DNS_DNSKEY_DATA. The possible values are shown in the following table.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>1</term>
			/// <term>RSA/MD5 (RFC 2537)</term>
			/// </item>
			/// <item>
			/// <term>2</term>
			/// <term>Diffie-Hellman (RFC 2539)</term>
			/// </item>
			/// <item>
			/// <term>3</term>
			/// <term>DSA (RFC 2536)</term>
			/// </item>
			/// <item>
			/// <term>4</term>
			/// <term>Elliptic curve cryptography</term>
			/// </item>
			/// <item>
			/// <term>5</term>
			/// <term>RSA/SHA-1 (RFC 3110)</term>
			/// </item>
			/// </list>
			/// </summary>
			public byte chAlgorithm;

			/// <summary>
			/// <para>
			/// A value that specifies the cryptographic algorithm used to generate <c>Digest</c>. The possible values are shown in the
			/// following table.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>1</term>
			/// <term>SHA-1 (RFC 3174)</term>
			/// </item>
			/// </list>
			/// </summary>
			public byte chDigestType;

			/// <summary>
			/// The length, in bytes. of the message digest in <c>Digest</c>. This value is determined by the algorithm type in <c>chDigestType</c>.
			/// </summary>
			public ushort wDigestLength;

			/// <summary>Reserved for padding. Do not use.</summary>
			public ushort wPad;

			/// <summary>
			/// A <c>BYTE</c> array that contains a cryptographic digest of the DNSKEY RR and RDATA as specified in section 5.1.4 of RFC
			/// 4034. Its length is determined by <c>wDigestLength</c>.
			/// </summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
			public byte[] Digest;
		}

		/// <summary>
		/// The <c>DNS_HEADER</c> structure contains DNS header information used when sending DNS messages as specified in section 4.1.1 of
		/// RFC 1035.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/windns/ns-windns-dns_header typedef struct _DNS_HEADER { WORD Xid; BYTE
		// RecursionDesired : 1; BYTE Truncation : 1; BYTE Authoritative : 1; BYTE Opcode : 4; BYTE IsResponse : 1; BYTE ResponseCode : 4;
		// BYTE CheckingDisabled : 1; BYTE AuthenticatedData : 1; BYTE Reserved : 1; BYTE RecursionAvailable : 1; WORD QuestionCount; WORD
		// AnswerCount; WORD NameServerCount; WORD AdditionalCount; } DNS_HEADER, *PDNS_HEADER;
		[PInvokeData("windns.h", MSDNShortId = "e5bf19a1-4c71-482d-a075-1e149f94505b")]
		[StructLayout(LayoutKind.Sequential)]
		public struct DNS_HEADER
		{
			/// <summary>A value that specifies the unique DNS message identifier.</summary>
			public ushort Xid;

			private ushort flags;

			/// <summary>
			/// <para>A value that specifies whether recursive name query should be used by the DNS name server.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>0x00</term>
			/// <term>Do not use recursive name query.</term>
			/// </item>
			/// <item>
			/// <term>0x01</term>
			/// <term>Use recursive name query.</term>
			/// </item>
			/// </list>
			/// </summary>
			public bool RecursionDesired { get => BitHelper.GetBit(flags, 0); set => BitHelper.SetBit(ref flags, 0, value); }

			/// <summary>
			/// <para>A value that specifies whether the DNS message has been truncated.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>0x00</term>
			/// <term>The message is not truncated.</term>
			/// </item>
			/// <item>
			/// <term>0x01</term>
			/// <term>The message is truncated.</term>
			/// </item>
			/// </list>
			/// </summary>
			public bool Truncation { get => BitHelper.GetBit(flags, 1); set => BitHelper.SetBit(ref flags, 1, value); }

			/// <summary>
			/// <para>
			/// A value that specifies whether the DNS server from which the DNS message is being sent is authoritative for the domain
			/// name's zone.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>0x00</term>
			/// <term>The DNS server is not authoritative in the zone.</term>
			/// </item>
			/// <item>
			/// <term>0x01</term>
			/// <term>The DNS server is authoritative in the zone.</term>
			/// </item>
			/// </list>
			/// </summary>
			public bool Authoritative { get => BitHelper.GetBit(flags, 2); set => BitHelper.SetBit(ref flags, 2, value); }

			/// <summary>
			/// A value that specifies the operation code to be taken on the DNS message as defined in section 4.1.1 of RFC 1035 as the
			/// <c>OPCODE</c> field.
			/// </summary>
			public ushort Opcode { get => BitHelper.GetBits(flags, 3, 4); set => BitHelper.SetBits(ref flags, 3, 4, value); }

			/// <summary>
			/// <para>A value that specifies whether the DNS message is a query or a response message.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>0x00</term>
			/// <term>The DNS message is a query.</term>
			/// </item>
			/// <item>
			/// <term>0x01</term>
			/// <term>The DNS message is a response.</term>
			/// </item>
			/// </list>
			/// </summary>
			public bool IsResponse { get => BitHelper.GetBit(flags, 7); set => BitHelper.SetBit(ref flags, 7, value); }

			/// <summary>The DNS Response Code of the message.</summary>
			public ushort ResponseCode { get => BitHelper.GetBits(flags, 8, 4); set => BitHelper.SetBits(ref flags, 8, 4, value); }

			/// <summary>
			/// <para>Windows 7 or later: A value that specifies whether checking is supported by the DNS resolver.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>0x00</term>
			/// <term>Checking is enabled on the DNS resolver.</term>
			/// </item>
			/// <item>
			/// <term>0x01</term>
			/// <term>Checking is disabled on the DNS resolver.</term>
			/// </item>
			/// </list>
			/// </summary>
			public bool CheckingDisabled { get => BitHelper.GetBit(flags, 12); set => BitHelper.SetBit(ref flags, 12, value); }

			/// <summary>
			/// <para>
			/// Windows 7 or later: A value that specifies whether the DNS data following the <c>DNS_HEADER</c> is authenticated by the DNS server.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>0x00</term>
			/// <term>The DNS data is not authenticated.</term>
			/// </item>
			/// <item>
			/// <term>0x01</term>
			/// <term>The DNS data is authenticated.</term>
			/// </item>
			/// </list>
			/// </summary>
			public bool AuthenticatedData { get => BitHelper.GetBit(flags, 13); set => BitHelper.SetBit(ref flags, 13, value); }

			/// <summary>Reserved. Do not use.</summary>
			public bool Reserved { get => BitHelper.GetBit(flags, 14); set => BitHelper.SetBit(ref flags, 14, value); }

			/// <summary>
			/// <para>A value that specifies whether recursive name query is supported by the DNS name server.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>0x00</term>
			/// <term>Recursive name query is not supported.</term>
			/// </item>
			/// <item>
			/// <term>0x01</term>
			/// <term>Recursive name query is supported.</term>
			/// </item>
			/// </list>
			/// </summary>
			public bool RecursionAvailable { get => BitHelper.GetBit(flags, 15); set => BitHelper.SetBit(ref flags, 15, value); }

			/// <summary>The number of queries contained in the question section of the DNS message.</summary>
			public ushort QuestionCount;

			/// <summary>The number of resource records (RRs) contained in the answer section of the DNS message.</summary>
			public ushort AnswerCount;

			/// <summary>
			/// The number of DNS name server RRs contained in the authority section of the DNS message. This value is the number of DNS
			/// name servers the message has traversed in its search for resolution.
			/// </summary>
			public ushort NameServerCount;

			/// <summary>Reserved. Do not use.</summary>
			public ushort AdditionalCount;
		}

		/// <summary>The <c>DNS_KEY_DATA</c> structure represents a DNS key (KEY) resource record (RR) as specified in RFC 3445.</summary>
		/// <remarks>
		/// <para>
		/// The <c>DNS_KEY_DATA</c> structure is used in conjunction with the DNS_RECORD structure to programmatically manage DNS entries.
		/// </para>
		/// <para>The DNS_DNSKEY_DATA structure represents a DNSKEY resource record as specified in section 2 of RFC 4034.</para>
		/// <para>The DNS_DNSKEY_DATA structure is used in conjunction with the DNS_RECORD structure to programmatically manage DNS entries.</para>
		/// <para>
		/// The value of the <c>wFlags</c> member for DNS_DNSKEY_DATA is a set of flags that specify key properties as described in section
		/// 2.1.1 of RFC 4034.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/windns/ns-windns-dns_key_data typedef struct { WORD wFlags; BYTE chProtocol;
		// BYTE chAlgorithm; WORD wKeyLength; WORD wPad; #if ... BYTE Key[]; #else BYTE Key[1]; #endif } DNS_KEY_DATA, *PDNS_KEY_DATA,
		// DNS_DNSKEY_DATA, *PDNS_DNSKEY_DATA;
		[PInvokeData("windns.h", MSDNShortId = "d7d60322-4d06-4c57-b181-c6a38e09e1ef")]
		[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<DNS_KEY_DATA>), nameof(wKeyLength))]
		[StructLayout(LayoutKind.Sequential)]
		public struct DNS_KEY_DATA
		{
			/// <summary>A set of flags that specify whether this is a zone key as described in section 4 of RFC 3445.</summary>
			public ushort wFlags;

			/// <summary>
			/// <para>
			/// A value that specifies the protocol with which <c>Key</c> can be used. The possible values are shown in the following table.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>3</term>
			/// <term>Domain Name System Security Extensions (DNSSEC)</term>
			/// </item>
			/// </list>
			/// </summary>
			public byte chProtocol;

			/// <summary>
			/// <para>A value that specifies the algorithm to use with <c>Key</c>. The possible values are shown in the following table.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>1</term>
			/// <term>RSA/MD5 (RFC 2537)</term>
			/// </item>
			/// <item>
			/// <term>2</term>
			/// <term>Diffie-Hellman (RFC 2539)</term>
			/// </item>
			/// <item>
			/// <term>3</term>
			/// <term>DSA (RFC 2536)</term>
			/// </item>
			/// <item>
			/// <term>4</term>
			/// <term>Elliptic curve cryptography</term>
			/// </item>
			/// <item>
			/// <term>5</term>
			/// <term>RSA/SHA-1 (RFC 3110). DNS_DNSKEY_DATA only.</term>
			/// </item>
			/// </list>
			/// </summary>
			public byte chAlgorithm;

			/// <summary>The length, in bytes, of <c>Key</c>. This value is determined by the algorithm type in <c>chAlgorithm</c>.</summary>
			public ushort wKeyLength;

			/// <summary>Reserved. Do not use.</summary>
			public ushort wPad;

			/// <summary>
			/// A <c>BYTE</c> array that contains the public key for the algorithm in <c>chAlgorithm</c>, represented in base 64, as
			/// described in Appendix A of RFC 2535.
			/// </summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
			public byte[] Key;
		}

		/// <summary>The <c>DNS_LOC_DATA</c> structure represents a DNS location (LOC) resource record (RR) as specified in RFC 1876.</summary>
		/// <remarks>
		/// The <c>DNS_LOC_DATA</c> structure is used in conjunction with the DNS_RECORD structure to programmatically manage DNS entries.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/windns/ns-windns-dns_loc_data typedef struct { WORD wVersion; WORD wSize; WORD
		// wHorPrec; WORD wVerPrec; DWORD dwLatitude; DWORD dwLongitude; DWORD dwAltitude; } DNS_LOC_DATA, *PDNS_LOC_DATA;
		[PInvokeData("windns.h", MSDNShortId = "c1e05479-17f0-4993-8dcf-02036989d6dc")]
		[StructLayout(LayoutKind.Sequential)]
		public struct DNS_LOC_DATA
		{
			/// <summary>The version number of the representation. Must be zero.</summary>
			public ushort wVersion;

			/// <summary>The diameter of a sphere enclosing the described entity, defined as "SIZE" in section 2 of RFC 1876.</summary>
			public ushort wSize;

			/// <summary>The horizontal data precision, defined as "HORIZ PRE" in section 2 of RFC 1876.</summary>
			public ushort wHorPrec;

			/// <summary>The vertical data precision, defined as "VERT PRE" in section 2 of RFC 1876.</summary>
			public ushort wVerPrec;

			/// <summary>The latitude of the center of the sphere, defined as "LATITUDE" in section 2 of RFC 1876.</summary>
			public uint dwLatitude;

			/// <summary>The longitude of the center of the sphere, defined as "LONGITUDE" in section 2 of RFC 1876.</summary>
			public uint dwLongitude;

			/// <summary>The altitude of the center of the sphere, defined as "ALTITUDE" in section 2 of RFC 1876.</summary>
			public uint dwAltitude;
		}

		/// <summary>The <c>DNS_MESSAGE_BUFFER</c> structure stores message information for DNS queries.</summary>
		/// <remarks>
		/// <para>
		/// The <c>DNS_MESSAGE_BUFFER</c> is used by the system to store DNS query information, and make that information available through
		/// various DNS function calls.
		/// </para>
		/// <para>
		/// The DnsWriteQuestionToBuffer method should be used to write a DNS query into a <c>DNS_MESSAGE_BUFFER</c> structure and the
		/// DnsExtractRecordsFromMessage method should be used to read the DNS RRs from a <c>DNS_MESSAGE_BUFFER</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/windns/ns-windns-dns_message_buffer typedef struct _DNS_MESSAGE_BUFFER {
		// DNS_HEADER MessageHead; CHAR MessageBody[1]; } DNS_MESSAGE_BUFFER, *PDNS_MESSAGE_BUFFER;
		[PInvokeData("windns.h", MSDNShortId = "2a6fdf8f-ac30-4e32-9cde-67d41ddef8af")]
		[VanaraMarshaler(typeof(DNS_MESSAGE_BUFFER_Marshaler))]
		[StructLayout(LayoutKind.Sequential)]
		public struct DNS_MESSAGE_BUFFER
		{
			/// <summary>A DNS_HEADER structure that contains the header for the DNS message.</summary>
			public DNS_HEADER MessageHead;

			/// <summary>An array of characters that comprises the DNS query or resource records (RR).</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
			public byte[] MessageBody;
		}

		/// <summary>
		/// The <c>DNS_MINFO_DATA</c> structure represents a DNS mail information (MINFO) record as specified in section 3.3.7 of RFC 1035.
		/// </summary>
		/// <remarks>
		/// The <c>DNS_MINFO_DATA</c> structure is used in conjunction with the DNS_RECORD structure to programmatically manage DNS entries.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/windns/ns-windns-dns_minfo_dataa typedef struct { PSTR pNameMailbox; PSTR
		// pNameErrorsMailbox; } DNS_MINFO_DATAA, *PDNS_MINFO_DATAA;
		[PInvokeData("windns.h", MSDNShortId = "cd392b48-734f-462b-b893-855f07c30575")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct DNS_MINFO_DATA
		{
			/// <summary>
			/// A pointer to a string that represents the fully qualified domain name (FQDN) of the mailbox responsible for the mailing list
			/// or mailbox specified in the record's owner name.
			/// </summary>
			[MarshalAs(UnmanagedType.LPTStr)]
			public string pNameMailbox;

			/// <summary>
			/// A pointer to a string that represents the FQDN of the mailbox to receive error messages related to the mailing list.
			/// </summary>
			[MarshalAs(UnmanagedType.LPTStr)]
			public string pNameErrorsMailbox;
		}

		/// <summary>
		/// The <c>DNS_MX_DATA</c> structure represents a DNS mail exchanger (MX) record as specified in section 3.3.9 of RFC 1035.
		/// </summary>
		/// <remarks>
		/// The <c>DNS_MX_DATA</c> structure is used in conjunction with the DNS_RECORD structure to programmatically manage DNS entries.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/windns/ns-windns-dns_mx_dataa typedef struct { PSTR pNameExchange; WORD
		// wPreference; WORD Pad; } DNS_MX_DATAA, *PDNS_MX_DATAA;
		[PInvokeData("windns.h", MSDNShortId = "72a0b42e-a7af-42d2-b672-cf06d0b5d1ba")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct DNS_MX_DATA
		{
			/// <summary>
			/// A pointer to a string that represents the fully qualified domain name (FQDN) of the host willing to act as a mail exchange.
			/// </summary>
			[MarshalAs(UnmanagedType.LPTStr)]
			public string pNameExchange;

			/// <summary>A preference given to this resource record among others of the same owner. Lower values are preferred.</summary>
			public ushort wPreference;

			/// <summary>Reserved for padding. Do not use.</summary>
			public ushort Pad;
		}

		/// <summary>
		/// The <c>DNS_NAPTR_DATA</c> structure represents a Naming Authority Pointer (NAPTR) DNS Resource Record (RR) as specified in RFC 2915.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/windns/ns-windns-dns_naptr_dataw typedef struct { WORD wOrder; WORD
		// wPreference; PWSTR pFlags; PWSTR pService; PWSTR pRegularExpression; PWSTR pReplacement; } DNS_NAPTR_DATAW, *PDNS_NAPTR_DATAW;
		[PInvokeData("windns.h", MSDNShortId = "8f576efb-4ef3-4fc0-8cf5-d373460a3b3c")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct DNS_NAPTR_DATA
		{
			/// <summary>A value that determines the NAPTR RR processing order as defined in section 2 of RFC 2915.</summary>
			public ushort wOrder;

			/// <summary>
			/// A value that determines the NAPTR RR processing order for records with the same <c>wOrder</c> value as defined in section 2
			/// of RFC 2915.
			/// </summary>
			public ushort wPreference;

			/// <summary>
			/// A pointer to a string that represents a set of NAPTR RR flags which determine the interpretation and processing of NAPTR
			/// record fields as defined in section 2 of RFC 2915.
			/// </summary>
			[MarshalAs(UnmanagedType.LPTStr)] public string pFlags;

			/// <summary>
			/// A pointer to a string that represents the available services in this rewrite path as defined in section 2 of RFC 2915.
			/// </summary>
			[MarshalAs(UnmanagedType.LPTStr)] public string pService;

			/// <summary>A pointer to a string that represents a substitution expression as defined in sections 2 and 3 of RFC 2915.</summary>
			[MarshalAs(UnmanagedType.LPTStr)] public string pRegularExpression;

			/// <summary>A pointer to a string that represents the next NAPTR query name as defined in section 2 of RFC 2915.</summary>
			[MarshalAs(UnmanagedType.LPTStr)] public string pReplacement;
		}

		/// <summary>The <c>DNS_NSEC_DATA</c> structure represents an NSEC resource record (RR) as specified in section 4 of RFC 4034.</summary>
		/// <remarks>
		/// The <c>DNS_NSEC_DATA</c> structure is used in conjunction with the DNS_RECORD structure to programmatically manage DNS entries.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/windns/ns-windns-dns_nsec_dataa typedef struct { PSTR pNextDomainName; WORD
		// wTypeBitMapsLength; WORD wPad; #if ... BYTE TypeBitMaps[]; #else BYTE TypeBitMaps[1]; #endif } DNS_NSEC_DATAA, *PDNS_NSEC_DATAA;
		[PInvokeData("windns.h", MSDNShortId = "ea446732-bc6a-4597-b164-11bfd77c07f2")]
		[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<DNS_NSEC_DATA>), nameof(wTypeBitMapsLength))]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct DNS_NSEC_DATA
		{
			/// <summary>
			/// A pointer to a string that represents the authoritative owner name of the next domain in the canonical ordering of the zone
			/// as specified in section 4.1.1 of RFC 4034.
			/// </summary>
			[MarshalAs(UnmanagedType.LPTStr)] public string pNextDomainName;

			/// <summary>The length, in bytes, of <c>TypeBitMaps</c>.</summary>
			public ushort wTypeBitMapsLength;

			/// <summary>Reserved. Do not use.</summary>
			public ushort wPad;

			/// <summary>
			/// A <c>BYTE</c> array that contains a bitmap that specifies which RR types are supported by the NSEC RR owner. Each bit in the
			/// array corresponds to a DNS Record Type as defined in section in section 4.1.2 of RFC 4034.
			/// </summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
			public byte[] TypeBitMaps;
		}

		/// <summary>Undocumented.</summary>
		[PInvokeData("windns.h")]
		[VanaraMarshaler(typeof(SafeDNS_NSEC3_DATAMarshaler))]
		[StructLayout(LayoutKind.Sequential)]
		public struct DNS_NSEC3_DATA
		{
			/// <summary/>
			public byte chAlgorithm;

			/// <summary/>
			public byte bFlags;

			/// <summary/>
			public ushort wIterations;

			/// <summary/>
			public byte bSaltLength;

			/// <summary/>
			public byte bHashLength;

			/// <summary/>
			public ushort wTypeBitMapsLength;

			/// <summary/>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
			public byte[] chData;
		}

		/// <summary>Undocumented.</summary>
		[PInvokeData("windns.h")]
		[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<DNS_NSEC3PARAM_DATA>), nameof(bSaltLength))]
		[StructLayout(LayoutKind.Sequential)]
		public struct DNS_NSEC3PARAM_DATA
		{
			/// <summary/>
			public byte chAlgorithm;

			/// <summary/>
			public byte bFlags;

			/// <summary/>
			public ushort wIterations;

			/// <summary/>
			public byte bSaltLength;

			/// <summary/>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
			public byte[] bPad;        // keep salt field aligned

			/// <summary/>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
			public byte[] pbSalt;
		}

		/// <summary>
		/// The <c>DNS_NULL_DATA</c> structure represents NULL data for a DNS resource record as specified in section 3.3.10 of RFC 1035.
		/// </summary>
		/// <remarks>
		/// The <c>DNS_NULL_DATA</c> structure is used in conjunction with the DNS_RECORD structure to programmatically manage DNS entries.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/windns/ns-windns-dns_null_data typedef struct { DWORD dwByteCount; #if ...
		// BYTE Data[]; #else BYTE Data[1]; #endif } DNS_NULL_DATA, *PDNS_NULL_DATA;
		[PInvokeData("windns.h", MSDNShortId = "c31e468f-8efd-4173-bc2c-442ee4df737f")]
		[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<DNS_NULL_DATA>), nameof(dwByteCount))]
		[StructLayout(LayoutKind.Sequential)]
		public struct DNS_NULL_DATA
		{
			/// <summary>The number of bytes represented in <c>Data</c>.</summary>
			public uint dwByteCount;

			/// <summary>Null data.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
			public byte[] Data;
		}

		/// <summary>
		/// The <c>DNS_NXT_DATA</c> structure represents a DNS next (NXT) resource record (RR) as specified in section 5 of RFC 2535.
		/// </summary>
		/// <remarks>
		/// The <c>DNS_NXT_DATA</c> structure is used in conjunction with the DNS_RECORD structure to programmatically manage DNS entries.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/windns/ns-windns-dns_nxt_dataa typedef struct { PSTR pNameNext; WORD
		// wNumTypes; #if ... WORD wTypes[]; #else WORD wTypes[1]; #endif } DNS_NXT_DATAA, *PDNS_NXT_DATAA;
		[PInvokeData("windns.h", MSDNShortId = "0e5370c2-30d3-4bb7-85a0-f4412f5572fd")]
		[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<DNS_NXT_DATA>), nameof(wNumTypes))]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct DNS_NXT_DATA
		{
			/// <summary>A pointer to a string that represents the name of the next domain.</summary>
			[MarshalAs(UnmanagedType.LPTStr)] public string pNameNext;

			/// <summary>The number of elements in the <c>wTypes</c> array. <c>wNumTypes</c> must be 2 or greater but cannot exceed 8.</summary>
			public ushort wNumTypes;

			/// <summary>
			/// A <c>BYTE</c> array that contains a bitmap which specifies the RR types that are present in the next domain. Each bit in the
			/// array corresponds to a DNS Record Type as defined in section 5.2 of RFC 2535.
			/// </summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
			public ushort[] wTypes;
		}

		/// <summary>
		/// The <c>DNS_OPT_DATA</c> structure represents a DNS Option (OPT) resource record (RR) as specified in section 4 of RFC 2671.
		/// </summary>
		/// <remarks>
		/// The <c>DNS_OPT_DATA</c> structure is used in conjunction with the DNS_RECORD structure to programmatically manage DNS entries.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/windns/ns-windns-dns_opt_data typedef struct { WORD wDataLength; WORD wPad;
		// #if ... BYTE Data[]; #else BYTE Data[1]; #endif } DNS_OPT_DATA, *PDNS_OPT_DATA;
		[PInvokeData("windns.h", MSDNShortId = "a8e23127-a625-4206-abe8-0787b4ac0f30")]
		[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<DNS_OPT_DATA>), nameof(wDataLength))]
		[StructLayout(LayoutKind.Sequential)]
		public struct DNS_OPT_DATA
		{
			/// <summary>The length, in bytes, of <c>Data</c>.</summary>
			public ushort wDataLength;

			/// <summary>Reserved. Do not use.</summary>
			public ushort wPad;

			/// <summary>A <c>BYTE</c> array that contains variable transport level information as specified in section 4 of RFC 2671.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
			public byte[] Data;
		}

		/// <summary>
		/// The <c>DNS_PROXY_INFORMATION</c> structure contains the proxy information for a DNS server's name resolution policy table.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/windns/ns-windns-dns_proxy_information typedef struct DNS_PROXY_INFORMATION {
		// ULONG version; DNS_PROXY_INFORMATION_TYPE proxyInformationType; PWSTR proxyName; } DNS_PROXY_INFORMATION;
		[PInvokeData("windns.h", MSDNShortId = "cfe7653f-7e68-4e50-ba67-bd441f837ef8")]
		[StructLayout(LayoutKind.Sequential)]
		public struct DNS_PROXY_INFORMATION
		{
			/// <summary>A value that specifies the structure version. This value must be 1.</summary>
			public uint version;

			/// <summary>A DNS_PROXY_INFORMATION_TYPE enumeration that contains the proxy information type.</summary>
			public DNS_PROXY_INFORMATION_TYPE proxyInformationType;

			/// <summary>
			/// <para>
			/// A pointer to a string that contains the proxy server name if <c>proxyInformationType</c> is
			/// <c>DNS_PROXY_INFORMATION_PROXY_NAME</c>. Otherwise, this member is ignored.
			/// </para>
			/// <para><c>Note</c> To free this string, use the DnsFreeProxyName function.</para>
			/// </summary>
			public IntPtr proxyName;

			/// <inheritdoc/>
			public override string ToString() => $"{proxyInformationType}{(proxyInformationType == DNS_PROXY_INFORMATION_TYPE.DNS_PROXY_INFORMATION_PROXY_NAME ? $" {StringHelper.GetString(proxyName, CharSet.Unicode)}" : "")}";
		}

		/// <summary>The <c>DNS_PTR_DATA</c> structure represents a DNS pointer (PTR) record as specified in section 3.3.12 of RFC 1035.</summary>
		/// <remarks>
		/// The <c>DNS_PTR_DATA</c> structure is used in conjunction with the DNS_RECORD structure to programmatically manage DNS entries.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/windns/ns-windns-dns_ptr_dataa typedef struct { PSTR pNameHost; }
		// DNS_PTR_DATAA, *PDNS_PTR_DATAA;
		[PInvokeData("windns.h", MSDNShortId = "8b7f8898-ac91-46da-876c-889c427068a3")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct DNS_PTR_DATA
		{
			/// <summary>A pointer to a string that represents the pointer (PTR) record data.</summary>
			[MarshalAs(UnmanagedType.LPTStr)] public string pNameHost;
		}

		/// <summary>A <c>DNS_QUERY_CANCEL</c> structure can be used to cancel an asynchronous DNS query.</summary>
		/// <remarks>This structure is returned in the pCancelHandle parameter from a previous call to DnsQueryEx.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/windns/ns-windns-dns_query_cancel typedef struct _DNS_QUERY_CANCEL { CHAR
		// Reserved[32]; } DNS_QUERY_CANCEL, *PDNS_QUERY_CANCEL;
		[PInvokeData("windns.h", MSDNShortId = "543C6F9B-3200-44F6-A2B7-A5C7F5A927DB")]
		[StructLayout(LayoutKind.Sequential)]
		public struct DNS_QUERY_CANCEL
		{
			/// <summary>Contains a handle to the asynchronous query to cancel. Applications must not modify this value.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
			public byte[] Reserved;
		}

		/// <summary>The <c>DNS_QUERY_REQUEST</c> structure contains the DNS query parameters used in a call to DnsQueryEx.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/windns/ns-windns-dns_query_request typedef struct _DNS_QUERY_REQUEST { ULONG
		// Version; PCWSTR QueryName; WORD QueryType; ULONG64 QueryOptions; PDNS_ADDR_ARRAY pDnsServerList; ULONG InterfaceIndex;
		// PDNS_QUERY_COMPLETION_ROUTINE pQueryCompletionCallback; PVOID pQueryContext; } DNS_QUERY_REQUEST, *PDNS_QUERY_REQUEST;
		[PInvokeData("windns.h", MSDNShortId = "9C382800-DE71-4481-AC8D-9F89D6F59EE6")]
		[StructLayout(LayoutKind.Sequential)]
		public struct DNS_QUERY_REQUEST
		{
			/// <summary>
			/// <para>The structure version must be one of the following:</para>
			/// <para>DNS_QUERY_REQUEST_VERSION1 (1)</para>
			/// </summary>
			public uint Version;

			/// <summary>
			/// <para>A pointer to a string that represents the DNS name to query.</para>
			/// <para><c>Note</c> If <c>QueryName</c> is NULL, the query is for the local machine name.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)] public string QueryName;

			/// <summary>
			/// A value that represents the Resource Record (RR) DNS Record Type that is queried. <c>QueryType</c> determines the format of
			/// data pointed to by <c>pQueryRecords</c> returned in the DNS_QUERY_RESULT structure. For example, if the value of
			/// <c>wType</c> is <c>DNS_TYPE_A</c>, the format of data pointed to by <c>pQueryRecords</c> is DNS_A_DATA.
			/// </summary>
			public DNS_TYPE QueryType;

			/// <summary>
			/// A value that contains a bitmap of DNS Query Options to use in the DNS query. Options can be combined and all options
			/// override <c>DNS_QUERY_STANDARD</c>
			/// </summary>
			public DNS_QUERY_OPTIONS QueryOptions;

			/// <summary>A pointer to a DNS_ADDR_ARRAY structure that contains a list of DNS servers to use in the query.</summary>
			public IntPtr pDnsServerList;

			/// <summary>
			/// A value that contains the interface index over which the query is sent. If <c>InterfaceIndex</c> is 0, all interfaces will
			/// be considered.
			/// </summary>
			public uint InterfaceIndex;

			/// <summary>
			/// <para>
			/// A pointer to a DNS_QUERY_COMPLETION_ROUTINE callback that is used to return the results of an asynchronous query from a call
			/// to DnsQueryEx.
			/// </para>
			/// <para><c>Note</c> If NULL, DnsQueryEx is called synchronously.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.FunctionPtr)]
			public DNS_QUERY_COMPLETION_ROUTINE pQueryCompletionCallback;

			/// <summary>A pointer to a user context.</summary>
			public IntPtr pQueryContext;
		}

		/// <summary>A <c>DNS_QUERY_RESULT</c> structure contains the DNS query results returned from a call to DnsQueryEx.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/windns/ns-windns-dns_query_result typedef struct _DNS_QUERY_RESULT { ULONG
		// Version; DNS_STATUS QueryStatus; ULONG64 QueryOptions; PDNS_RECORD pQueryRecords; PVOID Reserved; } DNS_QUERY_RESULT, *PDNS_QUERY_RESULT;
		[PInvokeData("windns.h", MSDNShortId = "03EB1DC2-FAB0-45C5-B438-E8FFDD218F09")]
		[StructLayout(LayoutKind.Sequential)]
		public struct DNS_QUERY_RESULT
		{
			/// <summary>
			/// <para>The structure version must be one of the following:</para>
			/// <para>DNS_QUERY_REQUEST_VERSION1 (1)</para>
			/// </summary>
			public uint Version;

			/// <summary>
			/// <para>The return status of the call to DnsQueryEx.</para>
			/// <para>
			/// If the query was completed asynchronously and this structure was returned directly from DnsQueryEx, <c>QueryStatus</c>
			/// contains <c>DNS_REQUEST_PENDING</c>.
			/// </para>
			/// <para>
			/// If the query was completed synchronously or if this structure was returned by the DNS_QUERY_COMPLETION_ROUTINE DNS callback,
			/// <c>QueryStatus</c> contains ERROR_SUCCESS if successful or the appropriate DNS-specific error code as defined in Winerror.h.
			/// </para>
			/// </summary>
			public DNS_STATUS QueryStatus;

			/// <summary>
			/// A value that contains a bitmap of DNS Query Options that were used in the DNS query. Options can be combined and all options
			/// override <c>DNS_QUERY_STANDARD</c>
			/// </summary>
			public ulong QueryOptions;

			/// <summary>
			/// <para>A pointer to a DNS_RECORD structure.</para>
			/// <para>
			/// If the query was completed asynchronously and this structure was returned directly from DnsQueryEx, <c>pQueryRecords</c> is NULL.
			/// </para>
			/// <para>
			/// If the query was completed synchronously or if this structure was returned by the DNS_QUERY_COMPLETION_ROUTINE DNS callback,
			/// <c>pQueryRecords</c> contains a list of Resource Records (RR) that comprise the response.
			/// </para>
			/// <para><c>Note</c> Applications must free returned RR sets with the DnsRecordListFree function.</para>
			/// </summary>
			public IntPtr pQueryRecords;

			/// <summary/>
			public IntPtr Reserved;
		}

		/// <summary>The <c>DNS_RECORD</c> structure stores a DNS resource record (RR).</summary>
		/// <remarks>
		/// When building a <c>DNS_RECORD</c> list as an input argument for the various DNS update routines found in the DNS API, all flags
		/// in the <c>DNS_RECORD</c> structure should be set to zero.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/windns/ns-windns-dns_recorda typedef struct _DnsRecordA { struct _DnsRecordA
		// *pNext; PSTR pName; WORD wType; WORD wDataLength; union { DWORD DW; DNS_RECORD_FLAGS S; } Flags; DWORD dwTtl; DWORD dwReserved;
		// union { DNS_A_DATA A; DNS_SOA_DATAA SOA; DNS_SOA_DATAA Soa; DNS_PTR_DATAA PTR; DNS_PTR_DATAA Ptr; DNS_PTR_DATAA NS; DNS_PTR_DATAA
		// Ns; DNS_PTR_DATAA CNAME; DNS_PTR_DATAA Cname; DNS_PTR_DATAA DNAME; DNS_PTR_DATAA Dname; DNS_PTR_DATAA MB; DNS_PTR_DATAA Mb;
		// DNS_PTR_DATAA MD; DNS_PTR_DATAA Md; DNS_PTR_DATAA MF; DNS_PTR_DATAA Mf; DNS_PTR_DATAA MG; DNS_PTR_DATAA Mg; DNS_PTR_DATAA MR;
		// DNS_PTR_DATAA Mr; DNS_MINFO_DATAA MINFO; DNS_MINFO_DATAA Minfo; DNS_MINFO_DATAA RP; DNS_MINFO_DATAA Rp; DNS_MX_DATAA MX;
		// DNS_MX_DATAA Mx; DNS_MX_DATAA AFSDB; DNS_MX_DATAA Afsdb; DNS_MX_DATAA RT; DNS_MX_DATAA Rt; DNS_TXT_DATAA HINFO; DNS_TXT_DATAA
		// Hinfo; DNS_TXT_DATAA ISDN; DNS_TXT_DATAA Isdn; DNS_TXT_DATAA TXT; DNS_TXT_DATAA Txt; DNS_TXT_DATAA X25; DNS_NULL_DATA Null;
		// DNS_WKS_DATA WKS; DNS_WKS_DATA Wks; DNS_AAAA_DATA AAAA; DNS_KEY_DATA KEY; DNS_KEY_DATA Key; DNS_SIG_DATAA SIG; DNS_SIG_DATAA Sig;
		// DNS_ATMA_DATA ATMA; DNS_ATMA_DATA Atma; DNS_NXT_DATAA NXT; DNS_NXT_DATAA Nxt; DNS_SRV_DATAA SRV; DNS_SRV_DATAA Srv;
		// DNS_NAPTR_DATAA NAPTR; DNS_NAPTR_DATAA Naptr; DNS_OPT_DATA OPT; DNS_OPT_DATA Opt; DNS_DS_DATA DS; DNS_DS_DATA Ds; DNS_RRSIG_DATAA
		// RRSIG; DNS_RRSIG_DATAA Rrsig; DNS_NSEC_DATAA NSEC; DNS_NSEC_DATAA Nsec; DNS_DNSKEY_DATA DNSKEY; DNS_DNSKEY_DATA Dnskey;
		// DNS_TKEY_DATAA TKEY; DNS_TKEY_DATAA Tkey; DNS_TSIG_DATAA TSIG; DNS_TSIG_DATAA Tsig; DNS_WINS_DATA WINS; DNS_WINS_DATA Wins;
		// DNS_WINSR_DATAA WINSR; DNS_WINSR_DATAA WinsR; DNS_WINSR_DATAA NBSTAT; DNS_WINSR_DATAA Nbstat; DNS_DHCID_DATA DHCID;
		// DNS_NSEC3_DATA NSEC3; DNS_NSEC3_DATA Nsec3; DNS_NSEC3PARAM_DATA NSEC3PARAM; DNS_NSEC3PARAM_DATA Nsec3Param; DNS_TLSA_DATA TLSA;
		// DNS_TLSA_DATA Tlsa; DNS_UNKNOWN_DATA UNKNOWN; DNS_UNKNOWN_DATA Unknown; PBYTE pDataPtr; } Data; } DNS_RECORDA, *PDNS_RECORDA;
		[PInvokeData("windns.h", MSDNShortId = "ab7b96a5-346f-4e01-bb2a-885f44764590")]
		[StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Unicode)]
		public struct DNS_RECORD
		{
			/// <summary>A pointer to the next <c>DNS_RECORD</c> structure.</summary>
			public IntPtr pNext;

			/// <summary>
			/// A pointer to a string that represents the domain name of the record set. This must be in the string format that corresponds
			/// to the function called, such as ANSI, Unicode, or UTF8.
			/// </summary>
			[MarshalAs(UnmanagedType.LPTStr)] public string pName;

			/// <summary>
			/// A value that represents the RR DNS Record Type. <c>wType</c> determines the format of <c>Data</c>. For example, if the value
			/// of <c>wType</c> is <c>DNS_TYPE_A</c>, the data type of <c>Data</c> is DNS_A_DATA.
			/// </summary>
			public DNS_TYPE wType;

			/// <summary>
			/// The length, in bytes, of <c>Data</c>. For fixed-length data types, this value is the size of the corresponding data type,
			/// such as <c>sizeof(DNS_A_DATA)</c>. For the non-fixed data types, use one of the following macros to determine the length of
			/// the data:
			/// </summary>
			public ushort wDataLength;

			/// <summary>A set of flags in the form of a DNS_RECORD_FLAGS structure.</summary>
			public DNS_RECORD_FLAGS Flags;

			/// <summary>The DNS RR's Time To Live value (TTL), in seconds.</summary>
			public uint dwTtl;

			/// <summary>Reserved. Do not use.</summary>
			public uint dwReserved;

			// The next entries are contrived so that the structure works on either 32 or 64 systems. The total size of the variable is 40 bytes on X86 and 56 on X64.
			private IntPtr _Data;
			private IntPtr _fillPtr1;
			private IntPtr _fillPtr2;
			private IntPtr _fillPtr3;
			private ulong _fill8byte0;
			private ulong _fill8byte1;
			private ulong _fill8byte2;

			/// <summary>Gets the data value based on the value of <see cref="wType"/>.</summary>
			/// <returns>The value of <see cref="Data"/>.</returns>
			public object Data
			{
				get
				{
					if (wType == 0 || wDataLength == 0) return null;
					var type = CorrespondingTypeAttribute.GetCorrespondingTypes(wType, CorrespondingAction.GetSet).FirstOrDefault();
					var ptr = DataPtr;
					return type is null ? ptr : ptr.Convert(wDataLength, type, CharSet.Unicode);
				}
				set
				{
					wDataLength = (ushort)DataPtr.Write(value, 0, DataSize);
				}
			}

			private static readonly int DataSize = Marshal.SizeOf(typeof(DNS_RECORD)) - 16 - (IntPtr.Size * 2);

			/// <summary>Gets the pointer to the 'Data' union.</summary>
			/// <value>The 'Data' union pointer.</value>
			public IntPtr DataPtr
			{
				get
				{
					unsafe
					{
						fixed (void* p = &_Data)
						{
							return (IntPtr)p;
						}
					}
				}
			}

			/// <summary>Gets the data as a strongly-typed structure.</summary>
			/// <typeparam name="T">The type of the structure to extract.</typeparam>
			/// <returns>The resulting type.</returns>
			/// <exception cref="System.ArgumentException">The current record does not support retrieving the supplied type param.</exception>
			public T GetDataAsType<T>() where T : struct
			{
				if (wType == 0 || wDataLength == 0) return default;
				if (!CorrespondingTypeAttribute.CanGet<DNS_TYPE>(typeof(T), out var tType) || tType != wType)
					throw new ArgumentException("The current record does not support retrieving the supplied type param.");
				var ptr = DataPtr;
				return ptr.Convert<T>(wDataLength, CharSet.Unicode);
			}

			/*
			/// <summary>The DNS RR data type is determined by <c>wType</c> and is one of the following members:</summary>
			[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
			public struct DNS_RECORD_DATA
			{
				/// <summary>The RR data type is DNS_A_DATA. The value of <c>wType</c> is <c>DNS_TYPE_A</c>.</summary>
				[FieldOffset(0)] public DNS_A_DATA A;

				/// <summary>The RR data type is DNS_SOA_DATA. The value of <c>wType</c> is <c>DNS_TYPE_SOA</c>.</summary>
				[FieldOffset(0)] public DNS_SOA_DATA SOA;

				/// <summary>The RR data type is DNS_SOA_DATA. The value of <c>wType</c> is <c>DNS_TYPE_SOA</c>.</summary>
				[FieldOffset(0)] public DNS_SOA_DATA Soa;

				/// <summary>The RR data type is DNS_PTR_DATA. The value of <c>wType</c> is <c>DNS_TYPE_PTR</c>.</summary>
				[FieldOffset(0)] public DNS_PTR_DATA PTR;

				/// <summary>The RR data type is DNS_PTR_DATA. The value of <c>wType</c> is <c>DNS_TYPE_PTR</c>.</summary>
				[FieldOffset(0)] public DNS_PTR_DATA Ptr;

				/// <summary>The RR data type is DNS_PTR_DATA. The value of <c>wType</c> is <c>DNS_TYPE_PTR</c>.</summary>
				[FieldOffset(0)] public DNS_PTR_DATA NS;

				/// <summary>The RR data type is DNS_PTR_DATA. The value of <c>wType</c> is <c>DNS_TYPE_PTR</c>.</summary>
				[FieldOffset(0)] public DNS_PTR_DATA Ns;

				/// <summary>The RR data type is DNS_PTR_DATA. The value of <c>wType</c> is <c>DNS_TYPE_PTR</c>.</summary>
				[FieldOffset(0)] public DNS_PTR_DATA CNAME;

				/// <summary>The RR data type is DNS_PTR_DATA. The value of <c>wType</c> is <c>DNS_TYPE_PTR</c>.</summary>
				[FieldOffset(0)] public DNS_PTR_DATA Cname;

				/// <summary>The RR data type is DNS_PTR_DATA. The value of <c>wType</c> is <c>DNS_TYPE_PTR</c>.</summary>
				[FieldOffset(0)] public DNS_PTR_DATA DNAME;

				/// <summary>The RR data type is DNS_PTR_DATA. The value of <c>wType</c> is <c>DNS_TYPE_PTR</c>.</summary>
				[FieldOffset(0)] public DNS_PTR_DATA Dname;

				/// <summary>The RR data type is DNS_PTR_DATA. The value of <c>wType</c> is <c>DNS_TYPE_PTR</c>.</summary>
				[FieldOffset(0)] public DNS_PTR_DATA MB;

				/// <summary>The RR data type is DNS_PTR_DATA. The value of <c>wType</c> is <c>DNS_TYPE_PTR</c>.</summary>
				[FieldOffset(0)] public DNS_PTR_DATA Mb;

				/// <summary>The RR data type is DNS_PTR_DATA. The value of <c>wType</c> is <c>DNS_TYPE_PTR</c>.</summary>
				[FieldOffset(0)] public DNS_PTR_DATA MD;

				/// <summary>The RR data type is DNS_PTR_DATA. The value of <c>wType</c> is <c>DNS_TYPE_PTR</c>.</summary>
				[FieldOffset(0)] public DNS_PTR_DATA Md;

				/// <summary>The RR data type is DNS_PTR_DATA. The value of <c>wType</c> is <c>DNS_TYPE_PTR</c>.</summary>
				[FieldOffset(0)] public DNS_PTR_DATA MF;

				/// <summary>The RR data type is DNS_PTR_DATA. The value of <c>wType</c> is <c>DNS_TYPE_PTR</c>.</summary>
				[FieldOffset(0)] public DNS_PTR_DATA Mf;

				/// <summary>The RR data type is DNS_PTR_DATA. The value of <c>wType</c> is <c>DNS_TYPE_PTR</c>.</summary>
				[FieldOffset(0)] public DNS_PTR_DATA MG;

				/// <summary>The RR data type is DNS_PTR_DATA. The value of <c>wType</c> is <c>DNS_TYPE_PTR</c>.</summary>
				[FieldOffset(0)] public DNS_PTR_DATA Mg;

				/// <summary>The RR data type is DNS_PTR_DATA. The value of <c>wType</c> is <c>DNS_TYPE_PTR</c>.</summary>
				[FieldOffset(0)] public DNS_PTR_DATA MR;

				/// <summary>The RR data type is DNS_PTR_DATA. The value of <c>wType</c> is <c>DNS_TYPE_PTR</c>.</summary>
				[FieldOffset(0)] public DNS_PTR_DATA Mr;

				/// <summary>The RR data type is DNS_MINFO_DATA. The value of <c>wType</c> is <c>DNS_TYPE_MINFO</c>.</summary>
				[FieldOffset(0)] public DNS_MINFO_DATA MINFO;

				/// <summary>The RR data type is DNS_MINFO_DATA. The value of <c>wType</c> is <c>DNS_TYPE_MINFO</c>.</summary>
				[FieldOffset(0)] public DNS_MINFO_DATA Minfo;

				/// <summary>The RR data type is DNS_MINFO_DATA. The value of <c>wType</c> is <c>DNS_TYPE_MINFO</c>.</summary>
				[FieldOffset(0)] public DNS_MINFO_DATA RP;

				/// <summary>The RR data type is DNS_MINFO_DATA. The value of <c>wType</c> is <c>DNS_TYPE_MINFO</c>.</summary>
				[FieldOffset(0)] public DNS_MINFO_DATA Rp;

				/// <summary>The RR data type is DNS_MX_DATA. The value of <c>wType</c> is <c>DNS_TYPE_MX</c>.</summary>
				[FieldOffset(0)] public DNS_MX_DATA MX;

				/// <summary>The RR data type is DNS_MX_DATA. The value of <c>wType</c> is <c>DNS_TYPE_MX</c>.</summary>
				[FieldOffset(0)] public DNS_MX_DATA Mx;

				/// <summary>The RR data type is DNS_MX_DATA. The value of <c>wType</c> is <c>DNS_TYPE_MX</c>.</summary>
				[FieldOffset(0)] public DNS_MX_DATA AFSDB;

				/// <summary>The RR data type is DNS_MX_DATA. The value of <c>wType</c> is <c>DNS_TYPE_MX</c>.</summary>
				[FieldOffset(0)] public DNS_MX_DATA Afsdb;

				/// <summary>The RR data type is DNS_MX_DATA. The value of <c>wType</c> is <c>DNS_TYPE_MX</c>.</summary>
				[FieldOffset(0)] public DNS_MX_DATA RT;

				/// <summary>The RR data type is DNS_MX_DATA. The value of <c>wType</c> is <c>DNS_TYPE_MX</c>.</summary>
				[FieldOffset(0)] public DNS_MX_DATA Rt;

				/// <summary>The RR data type is DNS_TXT_DATA. The value of <c>wType</c> is <c>DNS_TYPE_TXT</c>.</summary>
				[FieldOffset(0)] public DNS_TXT_DATA HINFO;

				/// <summary>The RR data type is DNS_TXT_DATA. The value of <c>wType</c> is <c>DNS_TYPE_TXT</c>.</summary>
				[FieldOffset(0)] public DNS_TXT_DATA Hinfo;

				/// <summary>The RR data type is DNS_TXT_DATA. The value of <c>wType</c> is <c>DNS_TYPE_TXT</c>.</summary>
				[FieldOffset(0)] public DNS_TXT_DATA ISDN;

				/// <summary>The RR data type is DNS_TXT_DATA. The value of <c>wType</c> is <c>DNS_TYPE_TXT</c>.</summary>
				[FieldOffset(0)] public DNS_TXT_DATA Isdn;

				/// <summary>The RR data type is DNS_TXT_DATA. The value of <c>wType</c> is <c>DNS_TYPE_TXT</c>.</summary>
				[FieldOffset(0)] public DNS_TXT_DATA TXT;

				/// <summary>The RR data type is DNS_TXT_DATA. The value of <c>wType</c> is <c>DNS_TYPE_TXT</c>.</summary>
				[FieldOffset(0)] public DNS_TXT_DATA Txt;

				/// <summary>The RR data type is DNS_TXT_DATA. The value of <c>wType</c> is <c>DNS_TYPE_TXT</c>.</summary>
				[FieldOffset(0)] public DNS_TXT_DATA X25;

				/// <summary>The RR data type is DNS_NULL_DATA. The value of <c>wType</c> is <c>DNS_TYPE_NULL</c>.</summary>
				[FieldOffset(0)] public DNS_NULL_DATA Null;

				/// <summary>The RR data type is DNS_WKS_DATA. The value of <c>wType</c> is <c>DNS_TYPE_WKS</c>.</summary>
				[FieldOffset(0)] public DNS_WKS_DATA WKS;

				/// <summary>The RR data type is DNS_WKS_DATA. The value of <c>wType</c> is <c>DNS_TYPE_WKS</c>.</summary>
				[FieldOffset(0)] public DNS_WKS_DATA Wks;

				/// <summary>The RR data type is DNS_AAAA_DATA. The value of <c>wType</c> is <c>DNS_TYPE_AAAA</c>.</summary>
				[FieldOffset(0)] public DNS_AAAA_DATA AAAA;

				/// <summary>The RR data type is DNS_KEY_DATA. The value of <c>wType</c> is <c>DNS_TYPE_KEY</c>.</summary>
				[FieldOffset(0)] public DNS_KEY_DATA KEY;

				/// <summary>The RR data type is DNS_KEY_DATA. The value of <c>wType</c> is <c>DNS_TYPE_KEY</c>.</summary>
				[FieldOffset(0)] public DNS_KEY_DATA Key;

				/// <summary>The RR data type is DNS_SIG_DATA. The value of <c>wType</c> is <c>DNS_TYPE_SIG</c>.</summary>
				[FieldOffset(0)] public DNS_SIG_DATA SIG;

				/// <summary>The RR data type is DNS_SIG_DATA. The value of <c>wType</c> is <c>DNS_TYPE_SIG</c>.</summary>
				[FieldOffset(0)] public DNS_SIG_DATA Sig;

				/// <summary>The RR data type is DNS_ATMA_DATA. The value of <c>wType</c> is <c>DNS_TYPE_ATMA</c>.</summary>
				[FieldOffset(0)] public DNS_ATMA_DATA ATMA;

				/// <summary>The RR data type is DNS_ATMA_DATA. The value of <c>wType</c> is <c>DNS_TYPE_ATMA</c>.</summary>
				[FieldOffset(0)] public DNS_ATMA_DATA Atma;

				/// <summary>The RR data type is DNS_NXT_DATA. The value of <c>wType</c> is <c>DNS_TYPE_NXT</c>.</summary>
				[FieldOffset(0)] public DNS_NXT_DATA NXT;

				/// <summary>The RR data type is DNS_NXT_DATA. The value of <c>wType</c> is <c>DNS_TYPE_NXT</c>.</summary>
				[FieldOffset(0)] public DNS_NXT_DATA Nxt;

				/// <summary>The RR data type is DNS_SRV_DATA. The value of <c>wType</c> is <c>DNS_TYPE_SRV</c>.</summary>
				[FieldOffset(0)] public DNS_SRV_DATA SRV;

				/// <summary>The RR data type is DNS_SRV_DATA. The value of <c>wType</c> is <c>DNS_TYPE_SRV</c>.</summary>
				[FieldOffset(0)] public DNS_SRV_DATA Srv;

				/// <summary>The RR data type is DNS_NAPTR_DATA. The value of <c>wType</c> is <c>DNS_TYPE_NAPTR</c>.</summary>
				[FieldOffset(0)] public DNS_NAPTR_DATA NAPTR;

				/// <summary>The RR data type is DNS_NAPTR_DATA. The value of <c>wType</c> is <c>DNS_TYPE_NAPTR</c>.</summary>
				[FieldOffset(0)] public DNS_NAPTR_DATA Naptr;

				/// <summary>The RR data type is DNS_OPT_DATA. The value of <c>wType</c> is <c>DNS_TYPE_OPT</c>.</summary>
				[FieldOffset(0)] public DNS_OPT_DATA OPT;

				/// <summary>The RR data type is DNS_OPT_DATA. The value of <c>wType</c> is <c>DNS_TYPE_OPT</c>.</summary>
				[FieldOffset(0)] public DNS_OPT_DATA Opt;

				/// <summary>The RR data type is DNS_DS_DATA. The value of <c>wType</c> is <c>DNS_TYPE_DS</c>.</summary>
				[FieldOffset(0)] public DNS_DS_DATA DS;

				/// <summary>The RR data type is DNS_DS_DATA. The value of <c>wType</c> is <c>DNS_TYPE_DS</c>.</summary>
				[FieldOffset(0)] public DNS_DS_DATA Ds;

				/// <summary>The RR data type is DNS_SIG_DATA. The value of <c>wType</c> is <c>DNS_TYPE_RRSIG</c>.</summary>
				[FieldOffset(0)] public DNS_SIG_DATA RRSIG;

				/// <summary>The RR data type is DNS_SIG_DATA. The value of <c>wType</c> is <c>DNS_TYPE_RRSIG</c>.</summary>
				[FieldOffset(0)] public DNS_SIG_DATA Rrsig;

				/// <summary>The RR data type is DNSEC_DATA. The value of <c>wType</c> is <c>DNS_TYPEEC</c>.</summary>
				[FieldOffset(0)] public DNS_NSEC_DATA NSEC;

				/// <summary>The RR data type is DNSEC_DATA. The value of <c>wType</c> is <c>DNS_TYPEEC</c>.</summary>
				[FieldOffset(0)] public DNS_NSEC_DATA Nsec;

				/// <summary>The RR data type is DNS_DNSKEY_DATA. The value of <c>wType</c> is <c>DNS_TYPE_DNSKEY</c>.</summary>
				[FieldOffset(0)] public DNS_KEY_DATA DNSKEY;

				/// <summary>The RR data type is DNS_DNSKEY_DATA. The value of <c>wType</c> is <c>DNS_TYPE_DNSKEY</c>.</summary>
				[FieldOffset(0)] public DNS_KEY_DATA Dnskey;

				/// <summary>The RR data type is DNS_TKEY_DATA. The value of <c>wType</c> is <c>DNS_TYPE_TKEY</c>.</summary>
				[FieldOffset(0)] public DNS_TKEY_DATA TKEY;

				/// <summary>The RR data type is DNS_TKEY_DATA. The value of <c>wType</c> is <c>DNS_TYPE_TKEY</c>.</summary>
				[FieldOffset(0)] public DNS_TKEY_DATA Tkey;

				/// <summary>The RR data type is DNS_TSIG_DATA. The value of <c>wType</c> is <c>DNS_TYPE_TSIG</c>.</summary>
				[FieldOffset(0)] public DNS_TSIG_DATA TSIG;

				/// <summary>The RR data type is DNS_TSIG_DATA. The value of <c>wType</c> is <c>DNS_TYPE_TSIG</c>.</summary>
				[FieldOffset(0)] public DNS_TSIG_DATA Tsig;

				/// <summary>The RR data type is DNS_WINS_DATA. The value of <c>wType</c> is <c>DNS_TYPE_WINS</c>.</summary>
				[FieldOffset(0)] public DNS_WINS_DATA WINS;

				/// <summary>The RR data type is DNS_WINS_DATA. The value of <c>wType</c> is <c>DNS_TYPE_WINS</c>.</summary>
				[FieldOffset(0)] public DNS_WINS_DATA Wins;

				/// <summary>The RR data type is DNS_WINSR_DATA. The value of <c>wType</c> is <c>DNS_TYPE_WINSR</c>.</summary>
				[FieldOffset(0)] public DNS_WINSR_DATA WINSR;

				/// <summary>The RR data type is DNS_WINSR_DATA. The value of <c>wType</c> is <c>DNS_TYPE_WINSR</c>.</summary>
				[FieldOffset(0)] public DNS_WINSR_DATA WinsR;

				/// <summary>The RR data type is DNS_WINSR_DATA. The value of <c>wType</c> is <c>DNS_TYPE_WINSR</c>.</summary>
				[FieldOffset(0)] public DNS_WINSR_DATA NBSTAT;

				/// <summary>The RR data type is DNS_WINSR_DATA. The value of <c>wType</c> is <c>DNS_TYPE_WINSR</c>.</summary>
				[FieldOffset(0)] public DNS_WINSR_DATA Nbstat;

				/// <summary>The RR data type is DNS_DHCID_DATA. The value of <c>wType</c> is <c>DNS_TYPE_DHCID</c>.</summary>
				[FieldOffset(0)] public DNS_DHCID_DATA DHCID;

				/// <summary>The RR data type is DNS_NSEC3_DATA. The value of <c>wType</c> is <c>DNS_TYPEEC3</c>.</summary>
				[FieldOffset(0)] public DNS_NSEC3_DATA NSEC3;

				/// <summary>The RR data type is DNS_NSEC3_DATA. The value of <c>wType</c> is <c>DNS_TYPEEC3</c>.</summary>
				[FieldOffset(0)] public DNS_NSEC3_DATA Nsec3;

				/// <summary>The RR data type is DNS_NSEC3PARAM_DATA. The value of <c>wType</c> is <c>DNS_TYPEEC3PARAM</c>.</summary>
				[FieldOffset(0)] public DNS_NSEC3PARAM_DATA NSEC3PARAM;

				/// <summary>The RR data type is DNS_NSEC3PARAM_DATA. The value of <c>wType</c> is <c>DNS_TYPEEC3PARAM</c>.</summary>
				[FieldOffset(0)] public DNS_NSEC3PARAM_DATA Nsec3Param;

				/// <summary>The RR data type is DNS_TLSA_DATA. The value of <c>wType</c> is <c>DNS_TYPE_TLSA</c>.</summary>
				[FieldOffset(0)] public DNS_TLSA_DATA TLSA;

				/// <summary>The RR data type is DNS_TLSA_DATA. The value of <c>wType</c> is <c>DNS_TYPE_TLSA</c>.</summary>
				[FieldOffset(0)] public DNS_TLSA_DATA Tlsa;

				/// <summary>The RR data type is DNS_UNKNOWN_DATA. The value of <c>wType</c> is <c>DNS_TYPE_UNKNOWN</c>.</summary>
				[FieldOffset(0)] public DNS_UNKNOWN_DATA UNKNOWN;

				/// <summary>The RR data type is DNS_UNKNOWN_DATA. The value of <c>wType</c> is <c>DNS_TYPE_UNKNOWN</c>.</summary>
				[FieldOffset(0)] public DNS_UNKNOWN_DATA Unknown;

				/// <summary/>
				[FieldOffset(0)] public IntPtr pDataPtr;
			}
			*/
		}

		/// <summary>The <c>DNS_RECORD_FLAGS</c> structure is used to set flags for use in the DNS_RECORD structure.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/windns/ns-windns-dns_record_flags typedef struct _DnsRecordFlags { DWORD
		// Section : 2; DWORD Delete : 1; DWORD CharSet : 2; DWORD Unused : 3; DWORD Reserved : 24; } DNS_RECORD_FLAGS;
		[PInvokeData("windns.h", MSDNShortId = "53c1c8bc-20b0-4b15-b2b6-9c9854f73ee3")]
		[StructLayout(LayoutKind.Sequential)]
		public struct DNS_RECORD_FLAGS
		{
			/// <summary>A value that contains a bitmap of DNS Record Flags.</summary>
			public uint DW;

			/// <summary>A DNS_SECTION value that specifies the section of interest returned from the DnsQuery function call.</summary>
			public uint Section { get => BitHelper.GetBits(DW, 0, 2); set => BitHelper.SetBits(ref DW, 0, 2, value); }

			/// <summary>Reserved. Do not use.</summary>
			public bool Delete { get => BitHelper.GetBit(DW, 2); set => BitHelper.SetBit(ref DW, 2, value); }

			/// <summary>A DNS_CHARSET value that specifies the character set used in the associated function call.</summary>
			public uint CharSet { get => BitHelper.GetBits(DW, 3, 2); set => BitHelper.SetBits(ref DW, 3, 2, value); }

			/// <summary>Reserved. Do not use.</summary>
			public uint Unused { get => BitHelper.GetBits(DW, 5, 3); set => BitHelper.SetBits(ref DW, 5, 3, value); }
		}

		/// <summary>The <c>DNS_RRSET</c> structure contains information about a DNS Resource Record (RR) set.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/windns/ns-windns-dns_rrset typedef struct _DnsRRSet { PDNS_RECORD pFirstRR;
		// PDNS_RECORD pLastRR; } DNS_RRSET, *PDNS_RRSET;
		[PInvokeData("windns.h", MSDNShortId = "bd87a8db-ca27-490b-85f4-912297b77a2b")]
		[StructLayout(LayoutKind.Sequential)]
		public struct DNS_RRSET
		{
			/// <summary>A pointer to a DNS_RECORD structure that contains the first DNS RR in the set.</summary>
			public IntPtr pFirstRR;

			/// <summary>A pointer to a DNS_RECORD structure that contains the last DNS RR in the set.</summary>
			public IntPtr pLastRR;
		}

		/// <summary>Contains the query parameters used in a call to DnsServiceBrowse.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/windns/ns-windns-dns_service_browse_request typedef struct
		// _DNS_SERVICE_BROWSE_REQUEST { ULONG Version; ULONG InterfaceIndex; PCWSTR QueryName; union { PDNS_SERVICE_BROWSE_CALLBACK
		// pBrowseCallback; DNS_QUERY_COMPLETION_ROUTINE *pBrowseCallbackV2; }; PVOID pQueryContext; } DNS_SERVICE_BROWSE_REQUEST, *PDNS_SERVICE_BROWSE_REQUEST;
		[PInvokeData("windns.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct DNS_SERVICE_BROWSE_REQUEST
		{
			/// <summary>
			/// The structure version must be either <c>DNS_QUERY_REQUEST_VERSION1</c> or <c>DNS_QUERY_REQUEST_VERSION2</c>. The value
			/// determines which of or is active.
			/// </summary>
			public uint Version;

			/// <summary>
			/// A value that contains the interface index over which the query is sent. If is 0, then all interfaces will be considered.
			/// </summary>
			public uint InterfaceIndex;

			/// <summary>
			/// A pointer to a string that represents the service type whose matching services you wish to browse for. It takes the
			/// generalized form "_&lt;ServiceType&gt;._&lt;TransportProtocol&gt;.local". For example, "_http._tcp.local", which defines a
			/// query to browse for http services on the local link.
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)] public string QueryName;

			/// <summary>The callback function based on <see cref="Version"/>.</summary>
			public DNS_SERVICE_BROWSE_REQUEST_CALLBACK Callback;

			/// <summary>The callback function based on <see cref="Version"/>.</summary>
			[StructLayout(LayoutKind.Explicit)]
			public struct DNS_SERVICE_BROWSE_REQUEST_CALLBACK
			{
				/// <summary>
				/// A pointer to a function (of type DNS_SERVICE_BROWSE_CALLBACK) that represents the callback to be invoked asynchronously.
				/// This field is used if <see cref="Version"/> is <c>DNS_QUERY_REQUEST_VERSION1</c>.
				/// </summary>
				[FieldOffset(0), MarshalAs(UnmanagedType.FunctionPtr)] public DNS_SERVICE_BROWSE_CALLBACK pBrowseCallback;

				/// <summary>
				/// A pointer to a function (of type DNS_QUERY_COMPLETION_ROUTINE) that represents the callback to be invoked
				/// asynchronously. This field is used if <see cref="Version"/> is <c>DNS_QUERY_REQUEST_VERSION2</c>.
				/// </summary>
				[FieldOffset(0), MarshalAs(UnmanagedType.FunctionPtr)] public DNS_QUERY_COMPLETION_ROUTINE pBrowseCallbackV2;
			}

			/// <summary>A pointer to a user context.</summary>
			public IntPtr pQueryContext;
		}

		/// <summary>Used to cancel an asynchronous DNS-SD operation.</summary>
		/// <remarks>This structure is returned in the parameter from a previous call to DnsServiceBrowse, DnsServiceRegister, or DnsServiceResolve.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/windns/ns-windns-dns_service_cancel typedef struct _DNS_SERVICE_CANCEL { PVOID
		// reserved; } DNS_SERVICE_CANCEL, *PDNS_SERVICE_CANCEL;
		[PInvokeData("windns.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct DNS_SERVICE_CANCEL
		{
			/// <summary>
			/// Contains a handle associated with the asynchronous operation to cancel. Your application must not modify this value.
			/// </summary>
			public IntPtr reserved;
		}

		/// <summary>Represents a DNS service running on the network.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/windns/ns-windns-dns_service_instance typedef struct _DNS_SERVICE_INSTANCE {
		// #if ... DNSSD_RPC_STRING pszInstanceName; #else LPWSTR pszInstanceName; #endif #if ... DNSSD_RPC_STRING pszHostName; #else LPWSTR
		// pszHostName; #endif IP4_ADDRESS *ip4Address; IP6_ADDRESS *ip6Address; WORD wPort; WORD wPriority; WORD wWeight; DWORD
		// dwPropertyCount; #if ... DNSSD_RPC_STRING *keys; #if ... DNSSD_RPC_STRING *values; #else PWSTR *keys; #endif #else PWSTR *values;
		// #endif DWORD dwInterfaceIndex; } DNS_SERVICE_INSTANCE, *PDNS_SERVICE_INSTANCE;
		[PInvokeData("windns.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct DNS_SERVICE_INSTANCE
		{
			/// <summary>
			/// A string that represents the service name. This is a fully qualified domain name that begins with a service name, and ends
			/// with ".local". It takes the generalized form "&lt;ServiceName&gt;._&lt;ServiceType&gt;._&lt;TransportProtocol&gt;.local".
			/// For example, "MyMusicServer._http._tcp.local".
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)] public string pszInstanceName;

			/// <summary>A string that represents the name of the host of the service.</summary>
			[MarshalAs(UnmanagedType.LPWStr)] public string pszHostName;

			/// <summary>A pointer to an <c>IP4_ADDRESS</c> structure that represents the service-associated IPv4 address.</summary>
			public IntPtr ip4Address;

			/// <summary>A pointer to an IP6_ADDRESS structure that represents the service-associated IPv6 address.</summary>
			public IntPtr ip6Address;

			/// <summary>A value that represents the port on which the service is running.</summary>
			public ushort wPort;

			/// <summary>A value that represents the service priority.</summary>
			public ushort wPriority;

			/// <summary>A value that represents the service weight.</summary>
			public ushort wWeight;

			/// <summary>The number of properties—defines the number of elements in the arrays of the and parameters.</summary>
			public uint dwPropertyCount;

			/// <summary/>
			public IntPtr keys;

			/// <summary/>
			public IntPtr values;

			/// <summary>A value that contains the interface index on which the service was discovered.</summary>
			public uint dwInterfaceIndex;
		}

		/// <summary>
		/// Contains the information necessary to advertise a service using DnsServiceRegister, or to stop advertising it using DnsServiceDeRegister.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/windns/ns-windns-dns_service_register_request typedef struct
		// _DNS_SERVICE_REGISTER_REQUEST { ULONG Version; ULONG InterfaceIndex; PDNS_SERVICE_INSTANCE pServiceInstance;
		// PDNS_SERVICE_REGISTER_COMPLETE pRegisterCompletionCallback; PVOID pQueryContext; HANDLE hCredentials; BOOL unicastEnabled; }
		// DNS_SERVICE_REGISTER_REQUEST, *PDNS_SERVICE_REGISTER_REQUEST;
		[PInvokeData("windns.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct DNS_SERVICE_REGISTER_REQUEST
		{
			/// <summary>The structure version must be <c>DNS_QUERY_REQUEST_VERSION1</c>.</summary>
			public uint Version;

			/// <summary>
			/// A value that contains the interface index over which the service is to be advertised. If is 0, then all interfaces will be considered.
			/// </summary>
			public uint InterfaceIndex;

			/// <summary>A pointer to a DNS_SERVICE_INSTANCE structure that describes the service to be registered.</summary>
			public IntPtr pServiceInstance;

			/// <summary>A pointer to a function (of type DNS_SERVICE_REGISTER_COMPLETE) that represents the callback to be invoked asynchronously.</summary>
			[MarshalAs(UnmanagedType.FunctionPtr)]
			public DNS_SERVICE_REGISTER_COMPLETE pRegisterCompletionCallback;

			/// <summary>A pointer to a user context.</summary>
			public IntPtr pQueryContext;

			/// <summary>Not used.</summary>
			public HANDLE hCredentials;

			/// <summary>
			/// <see langword="true"/> if the DNS protocol should be used to advertise the service; <see langword="false"/> if the mDNS
			/// protocol should be used.
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)] public bool unicastEnabled;
		}

		/// <summary>
		/// Contains the query parameters used in a call to DnsServiceResolve. Use that function, and this structure, after you've found a
		/// specific service name that you'd like to connect to.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/windns/ns-windns-dns_service_resolve_request typedef struct
		// _DNS_SERVICE_RESOLVE_REQUEST { ULONG Version; ULONG InterfaceIndex; PWSTR QueryName; PDNS_SERVICE_RESOLVE_COMPLETE
		// pResolveCompletionCallback; PVOID pQueryContext; } DNS_SERVICE_RESOLVE_REQUEST, *PDNS_SERVICE_RESOLVE_REQUEST;
		[PInvokeData("windns.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct DNS_SERVICE_RESOLVE_REQUEST
		{
			/// <summary>The structure version must be <c>DNS_QUERY_REQUEST_VERSION1</c>.</summary>
			public uint Version;

			/// <summary>
			/// A value that contains the interface index over which the query is sent. If is 0, then all interfaces will be considered.
			/// </summary>
			public uint InterfaceIndex;

			/// <summary>
			/// A pointer to a string that represents the service name. This is a fully qualified domain name that begins with a service
			/// name, and ends with ".local". It takes the generalized form
			/// "&lt;ServiceName&gt;._&lt;ServiceType&gt;._&lt;TransportProtocol&gt;.local". For example, "MyMusicServer._http._tcp.local".
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)] public string QueryName;

			/// <summary>A pointer to a function (of type DNS_SERVICE_RESOLVE_COMPLETE) that represents the callback to be invoked asynchronously.</summary>
			[MarshalAs(UnmanagedType.FunctionPtr)]
			public DNS_SERVICE_RESOLVE_COMPLETE pResolveCompletionCallback;

			/// <summary>A pointer to a user context.</summary>
			public IntPtr pQueryContext;
		}

		/// <summary>
		/// The <c>DNS_RRSIG_DATA</c> structure represents a DNS Security Extensions (DNSSEC) cryptographic signature (SIG) resource record
		/// (RR) as specified in RFC 4034.
		/// </summary>
		/// <remarks>
		/// The <c>DNS_RRSIG_DATA</c> structure is used in conjunction with the DNS_RECORD structure to programmatically manage DNS entries.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/windns/ns-windns-dns_sig_dataa typedef struct { WORD wTypeCovered; BYTE
		// chAlgorithm; BYTE chLabelCount; DWORD dwOriginalTtl; DWORD dwExpiration; DWORD dwTimeSigned; WORD wKeyTag; WORD wSignatureLength;
		// PSTR pNameSigner; #if ... BYTE Signature[]; #else BYTE Signature[1]; #endif } DNS_SIG_DATAA, *PDNS_SIG_DATAA, DNS_RRSIG_DATAA, *PDNS_RRSIG_DATAA;
		[PInvokeData("windns.h", MSDNShortId = "09c2f515-acc1-402f-8e62-a0d273031633")]
		[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<DNS_SIG_DATA>), nameof(wSignatureLength))]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct DNS_SIG_DATA
		{
			/// <summary>The DNS Record Type of the signed RRs.</summary>
			public ushort wTypeCovered;

			/// <summary>
			/// <para>
			/// A value that specifies the algorithm used to generate <c>Signature</c>. The possible values are shown in the following table.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>1</term>
			/// <term>RSA/MD5 (RFC 2537)</term>
			/// </item>
			/// <item>
			/// <term>2</term>
			/// <term>Diffie-Hellman (RFC 2539)</term>
			/// </item>
			/// <item>
			/// <term>3</term>
			/// <term>DSA (RFC 2536)</term>
			/// </item>
			/// <item>
			/// <term>4</term>
			/// <term>Elliptic curve cryptography</term>
			/// </item>
			/// <item>
			/// <term>5</term>
			/// <term>RSA/SHA-1 (RFC 3110)</term>
			/// </item>
			/// </list>
			/// </summary>
			public byte chAlgorithm;

			/// <summary>The number of labels in the original signature RR owner name as specified in section 3.1.3 of RFC 4034.</summary>
			public byte chLabelCount;

			/// <summary>The Time-to-Live (TTL) value of the RR set signed by <c>Signature</c>.</summary>
			public uint dwOriginalTtl;

			/// <summary>
			/// The expiration date of <c>Signature</c>, expressed in seconds since the beginning of January 1, 1970, Greenwich Mean Time
			/// (GMT), excluding leap seconds.
			/// </summary>
			public uint dwExpiration;

			/// <summary>
			/// The date and time at which <c>Signature</c> becomes valid, expressed in seconds since the beginning of January 1, 1970,
			/// Greenwich Mean Time (GMT), excluding leap seconds.
			/// </summary>
			public uint dwTimeSigned;

			/// <summary>
			/// A value that represents the method to choose which public key is used to verify <c>Signature</c> as specified Appendix B of
			/// RFC 4034.
			/// </summary>
			public ushort wKeyTag;

			/// <summary/>
			public ushort wSignatureLength;

			/// <summary>A pointer to a string that represents the name of the <c>Signature</c> generator.</summary>
			[MarshalAs(UnmanagedType.LPTStr)] public string pNameSigner;

			/// <summary>A <c>BYTE</c> array that contains the RR set signature as specified in section 3.1.8 of RFC 4034.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
			public byte[] Signature;
		}

		/// <summary>
		/// The <c>DNS_SOA_DATA</c> structure represents a DNS start of authority (SOA) record as specified in section 3.3.13 of RFC 1035.
		/// </summary>
		/// <remarks>
		/// The <c>DNS_SOA_DATA</c> structure is used in conjunction with the DNS_RECORD structure to programmatically manage DNS entries.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/windns/ns-windns-dns_soa_dataa typedef struct { PSTR pNamePrimaryServer; PSTR
		// pNameAdministrator; DWORD dwSerialNo; DWORD dwRefresh; DWORD dwRetry; DWORD dwExpire; DWORD dwDefaultTtl; } DNS_SOA_DATAA, *PDNS_SOA_DATAA;
		[PInvokeData("windns.h", MSDNShortId = "715cbb70-91fe-47ac-a713-1fe0701d4f8c")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct DNS_SOA_DATA
		{
			/// <summary>
			/// A pointer to a string that represents the name of the authoritative DNS server for the zone to which the record belongs.
			/// </summary>
			[MarshalAs(UnmanagedType.LPTStr)] public string pNamePrimaryServer;

			/// <summary>A pointer to a string that represents the name of the responsible party for the zone to which the record belongs.</summary>
			[MarshalAs(UnmanagedType.LPTStr)] public string pNameAdministrator;

			/// <summary>The serial number of the SOA record.</summary>
			public uint dwSerialNo;

			/// <summary>The time, in seconds, before the zone containing this record should be refreshed.</summary>
			public uint dwRefresh;

			/// <summary>The time, in seconds, before retrying a failed refresh of the zone to which this record belongs.</summary>
			public uint dwRetry;

			/// <summary>The time, in seconds, before an unresponsive zone is no longer authoritative.</summary>
			public uint dwExpire;

			/// <summary>
			/// The lower limit on the time, in seconds, that a DNS server or caching resolver are allowed to cache any resource records
			/// (RR) from the zone to which this record belongs.
			/// </summary>
			public uint dwDefaultTtl;
		}

		/// <summary>The <c>DNS_SRV_DATA</c> structure represents a DNS service (SRV) record as specified in RFC 2782.</summary>
		/// <remarks>
		/// The <c>DNS_SRV_DATA</c> structure is used in conjunction with the DNS_RECORD structure to programmatically manage DNS entries.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/windns/ns-windns-dns_srv_dataa typedef struct { PSTR pNameTarget; WORD
		// wPriority; WORD wWeight; WORD wPort; WORD Pad; } DNS_SRV_DATAA, *PDNS_SRV_DATAA;
		[PInvokeData("windns.h", MSDNShortId = "212db7ac-a5e3-4e58-b1c2-0eb551403dfc")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct DNS_SRV_DATA
		{
			/// <summary>A pointer to a string that represents the target host.</summary>
			[MarshalAs(UnmanagedType.LPTStr)] public string pNameTarget;

			/// <summary>
			/// The priority of the target host specified in <c>pNameTarget</c>. Lower numbers imply higher priority to clients attempting
			/// to use this service.
			/// </summary>
			public ushort wPriority;

			/// <summary>
			/// The relative weight of the target host in <c>pNameTarget</c> to other hosts with the same <c>wPriority</c>. The chances of
			/// using this host should be proportional to its weight.
			/// </summary>
			public ushort wWeight;

			/// <summary>The port used on the target host for this service.</summary>
			public ushort wPort;

			/// <summary>Reserved for padding. Do not use.</summary>
			public ushort Pad;
		}

		/// <summary>
		/// The <c>DNS_TKEY_DATA</c> structure represents a DNS TKEY resource record, used to establish and delete an algorithm's
		/// shared-secret keys between a DNS resolver and server as specified in RFC 2930.
		/// </summary>
		/// <remarks>
		/// The <c>DNS_TKEY_DATA</c> structure is used in conjunction with the DNS_RECORD structure to programmatically manage DNS entries.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/windns/ns-windns-dns_tkey_dataa typedef struct { PSTR pNameAlgorithm; PBYTE
		// pAlgorithmPacket; PBYTE pKey; PBYTE pOtherData; DWORD dwCreateTime; DWORD dwExpireTime; WORD wMode; WORD wError; WORD wKeyLength;
		// WORD wOtherLength; UCHAR cAlgNameLength; BOOL bPacketPointers; } DNS_TKEY_DATAA, *PDNS_TKEY_DATAA;
		[PInvokeData("windns.h", MSDNShortId = "4dad3449-3e41-47d9-89c2-10fa6e51573b")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct DNS_TKEY_DATA
		{
			/// <summary>A pointer to a string that represents the name of the key as defined in section 2.1 of RFC 2930.</summary>
			[MarshalAs(UnmanagedType.LPTStr)] public string pNameAlgorithm;

			/// <summary>
			/// A pointer to a string representing the name of the algorithm as defined in section 2.3 of RFC 2930. <c>pKey</c> is used to
			/// derive the algorithm specific keys.
			/// </summary>
			public IntPtr pAlgorithmPacket;

			/// <summary>A pointer to the variable-length shared-secret key.</summary>
			public IntPtr pKey;

			/// <summary>Reserved. Do not use.</summary>
			public IntPtr pOtherData;

			/// <summary>
			/// The date and time at which the key was created, expressed in seconds since the beginning of January 1, 1970, Greenwich Mean
			/// Time (GMT), excluding leap seconds.
			/// </summary>
			public uint dwCreateTime;

			/// <summary>
			/// The expiration date of the key, expressed in seconds since the beginning of January 1, 1970, Greenwich Mean Time (GMT),
			/// excluding leap seconds.
			/// </summary>
			public uint dwExpireTime;

			/// <summary>
			/// <para>
			/// A scheme used for key agreement or the purpose of the TKEY DNS Message. Possible values for <c>wMode</c> are listed below:
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>DNS_TKEY_MODE_SERVER_ASSIGN</term>
			/// <term>The key is assigned by the DNS server and is not negotiated.</term>
			/// </item>
			/// <item>
			/// <term>DNS_TKEY_MODE_DIFFIE_HELLMAN</term>
			/// <term>The Diffie-Hellman key exchange algorithm is used to negotiate the key.</term>
			/// </item>
			/// <item>
			/// <term>DNS_TKEY_MODE_GSS</term>
			/// <term>The key is exchanged through Generic Security Services-Application Program Interface (GSS-API) negotiation.</term>
			/// </item>
			/// <item>
			/// <term>DNS_TKEY_MODE_RESOLVER_ASSIGN</term>
			/// <term>The key is assigned by the DNS resolver and is not negotiated.</term>
			/// </item>
			/// </list>
			/// </summary>
			public DNS_TKEY_MODE wMode;

			/// <summary>
			/// <para>An error, expressed in expanded RCODE format that covers TSIG and TKEY RR processing.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>DNS_RCODE_BADSIG</term>
			/// <term>The pSignature of the DNS_TSIG_DATA RR is bad.</term>
			/// </item>
			/// <item>
			/// <term>DNS_RCODE_BADKEY</term>
			/// <term>The pKey field is bad.</term>
			/// </item>
			/// <item>
			/// <term>DNS_RCODE_BADTIME</term>
			/// <term>A timestamp is bad.</term>
			/// </item>
			/// </list>
			/// </summary>
			public DNS_RCODE wError;

			/// <summary>Length, in bytes, of the <c>pKey</c> member.</summary>
			public ushort wKeyLength;

			/// <summary>The length, in bytes, of the <c>pOtherData</c> member.</summary>
			public ushort wOtherLength;

			/// <summary>The length, in bytes, of the <c>pNameAlgorithm</c> member.</summary>
			public byte cAlgNameLength;

			/// <summary>Reserved. Do not use.</summary>
			[MarshalAs(UnmanagedType.Bool)] public bool bPacketPointers;
		}

		/// <summary>Undocumented.</summary>
		[PInvokeData("windns.h")]
		[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<DNS_TLSA_DATA>), nameof(bCertificateAssociationDataLength))]
		[StructLayout(LayoutKind.Sequential)]
		public struct DNS_TLSA_DATA
		{
			/// <summary/>
			public byte bCertUsage;

			/// <summary/>
			public byte bSelector;

			/// <summary/>
			public byte bMatchingType;

			/// <summary/>
			public ushort bCertificateAssociationDataLength;

			/// <summary/>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
			public byte[] bPad;        // keep certificate association data field aligned

			/// <summary/>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
			public byte[] bCertificateAssociationData;
		}

		/// <summary>
		/// The <c>DNS_TSIG_DATA</c> structure represents a secret key transaction authentication (TSIG) resource record (RR) as specified
		/// in RFC 2845 and RFC 3645.
		/// </summary>
		/// <remarks>
		/// The <c>DNS_TSIG_DATA</c> structure is used in conjunction with the DNS_RECORD structure to programmatically manage DNS entries.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/windns/ns-windns-dns_tsig_dataa typedef struct { PSTR pNameAlgorithm; PBYTE
		// pAlgorithmPacket; PBYTE pSignature; PBYTE pOtherData; LONGLONG i64CreateTime; WORD wFudgeTime; WORD wOriginalXid; WORD wError;
		// WORD wSigLength; WORD wOtherLength; UCHAR cAlgNameLength; BOOL bPacketPointers; } DNS_TSIG_DATAA, *PDNS_TSIG_DATAA;
		[PInvokeData("windns.h", MSDNShortId = "32077169-d319-45c0-982f-8d470cd70111")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct DNS_TSIG_DATA
		{
			/// <summary>
			/// A pointer to a string that represents the name of the key used to generate <c>pSignature</c> as defined in section 2.3 of
			/// RFC 2845.
			/// </summary>
			[MarshalAs(UnmanagedType.LPTStr)] public string pNameAlgorithm;

			/// <summary>
			/// <para>
			/// A pointer to a string that represents the name of the algorithm used to generate <c>pSignature</c> as defined in section 2.3
			/// of RFC 2845.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>"gss.microsoft.com"</term>
			/// <term>
			/// Windows 2000 Server only: Generic Security Service Algorithm for Secret Key Transaction Authentication for DNS (GSS-API) as
			/// defined in RFC 3645.
			/// </term>
			/// </item>
			/// <item>
			/// <term>"gss-tsig"</term>
			/// <term>Generic Security Service Algorithm for Secret Key Transaction Authentication for DNS (GSS-API) as defined in RFC 3645.</term>
			/// </item>
			/// </list>
			/// </summary>
			public IntPtr pAlgorithmPacket;

			/// <summary>
			/// A pointer to the Message Authentication Code (MAC) generated by the algorithm in <c>pAlgorithmPacket</c>. The length, in
			/// bytes, and composition of <c>pSignature</c> are determined by <c>pAlgorithmPacket</c>.
			/// </summary>
			public IntPtr pSignature;

			/// <summary>
			/// If <c>wError</c> contains the RCODE, <c>BADTIME</c>, <c>pOtherData</c> is a BYTE array that contains the server's current
			/// time, otherwise it is <c>NULL</c>. Time is expressed in seconds since the beginning of January 1, 1970, Greenwich Mean Time
			/// (GMT), excluding leap seconds.
			/// </summary>
			public IntPtr pOtherData;

			/// <summary>
			/// The time <c>pSignature</c> was generated, expressed in seconds since the beginning of January 1, 1970, Greenwich Mean Time
			/// (GMT), excluding leap seconds.
			/// </summary>
			public int i64CreateTime;

			/// <summary>The time, in seconds, <c>i64CreateTime</c> may be in error.</summary>
			public ushort wFudgeTime;

			/// <summary>The Xid identifier of the original message.</summary>
			public ushort wOriginalXid;

			/// <summary>
			/// <para>An error, expressed in expanded RCODE format that covers TSIG and TKEY RR processing.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>DNS_RCODE_BADSIG</term>
			/// <term>The pSignature field is bad.</term>
			/// </item>
			/// <item>
			/// <term>DNS_RCODE_BADKEY</term>
			/// <term>The pKey field of the DNS_TKEY_DATA RR is bad.</term>
			/// </item>
			/// <item>
			/// <term>DNS_RCODE_BADTIME</term>
			/// <term>A timestamp is bad.</term>
			/// </item>
			/// </list>
			/// </summary>
			public DNS_RCODE wError;

			/// <summary>The length, in bytes, of the <c>pSignature</c> member.</summary>
			public ushort wSigLength;

			/// <summary>The length, in bytes, of the <c>pOtherData</c> member.</summary>
			public ushort wOtherLength;

			/// <summary>The length, in bytes, of the <c>pAlgorithmPacket</c> member.</summary>
			public byte cAlgNameLength;

			/// <summary>Reserved for future use. Do not use.</summary>
			[MarshalAs(UnmanagedType.Bool)] public bool bPacketPointers;
		}

		/// <summary>The <c>DNS_TXT_DATA</c> structure represents a DNS text (TXT) record as specified in section 3.3.14 of RFC 1035.</summary>
		/// <remarks>
		/// The <c>DNS_TXT_DATA</c> structure is used in conjunction with the DNS_RECORD structure to programmatically manage DNS entries.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/windns/ns-windns-dns_txt_dataa typedef struct { DWORD dwStringCount; #if ...
		// PSTR pStringArray[]; #else PSTR pStringArray[1]; #endif } DNS_TXT_DATAA, *PDNS_TXT_DATAA;
		[PInvokeData("windns.h", MSDNShortId = "3ff643e2-d736-45d5-8cf8-ab5e63caf44b")]
		[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<DNS_TXT_DATA>), nameof(dwStringCount))]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct DNS_TXT_DATA
		{
			/// <summary>The number of strings represented in <c>pStringArray</c>.</summary>
			public uint dwStringCount;

			/// <summary>An array of strings representing the descriptive text of the TXT resource record.</summary>
			[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.LPTStr, SizeConst = 1)]
			public string[] pStringArray;
		}

		/// <summary>Undocumented.</summary>
		[PInvokeData("windns.h")]
		[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<DNS_UNKNOWN_DATA>), nameof(dwByteCount))]
		[StructLayout(LayoutKind.Sequential)]
		public struct DNS_UNKNOWN_DATA
		{
			/// <summary/>
			public uint dwByteCount;

			/// <summary/>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
			public byte[] bData;
		}

		/// <summary>The <c>DNS_WINS_DATA</c> structure represents a DNS Windows Internet Name Service (WINS) record.</summary>
		/// <remarks>
		/// The <c>DNS_WINS_DATA</c> structure is used in conjunction with the DNS_RECORD structure to programmatically manage DNS entries.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/windns/ns-windns-dns_wins_data typedef struct { DWORD dwMappingFlag; DWORD
		// dwLookupTimeout; DWORD dwCacheTimeout; DWORD cWinsServerCount; IP4_ADDRESS WinsServers[1]; } DNS_WINS_DATA, *PDNS_WINS_DATA;
		[PInvokeData("windns.h", MSDNShortId = "df41c397-e662-42b4-9193-6776f9071898")]
		[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<DNS_WINS_DATA>), nameof(cWinsServerCount))]
		[StructLayout(LayoutKind.Sequential)]
		public struct DNS_WINS_DATA
		{
			/// <summary>
			/// <para>
			/// The WINS mapping flag that specifies whether the record must be included in zone replication. <c>dwMappingFlag</c> must be
			/// one of these mutually exclusive values:
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>DNS_WINS_FLAG_SCOPE</term>
			/// <term>Record is not local, replicate across zones.</term>
			/// </item>
			/// <item>
			/// <term>DNS_WINS_FLAG_LOCAL</term>
			/// <term>Record is local, do not replicate.</term>
			/// </item>
			/// </list>
			/// </summary>
			public DNS_WINS_FLAG dwMappingFlag;

			/// <summary>The time, in seconds, that a DNS Server attempts resolution using WINS lookup.</summary>
			public uint dwLookupTimeout;

			/// <summary>The time, in seconds, that a DNS Server using WINS lookup may cache the WINS Server's response.</summary>
			public uint dwCacheTimeout;

			/// <summary>The number of WINS Servers listed in <c>WinsServers</c>.</summary>
			public uint cWinsServerCount;

			/// <summary>An array of IP4_ARRAY structures that contain the IPv4 address of the WINS lookup Servers.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
			public IP4_ADDRESS[] WinsServers;
		}

		/// <summary>The <c>DNS_WINSR_DATA</c> structure represents a DNS Windows Internet Name Service reverse-lookup (WINSR) record.</summary>
		/// <remarks>
		/// The <c>DNS_WINSR_DATA</c> structure is used in conjunction with the DNS_RECORD structure to programmatically manage DNS entries.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/windns/ns-windns-dns_winsr_dataa typedef struct { DWORD dwMappingFlag; DWORD
		// dwLookupTimeout; DWORD dwCacheTimeout; PSTR pNameResultDomain; } DNS_WINSR_DATAA, *PDNS_WINSR_DATAA;
		[PInvokeData("windns.h", MSDNShortId = "a7e79e30-905f-42a5-a4de-02d71adfe95e")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct DNS_WINSR_DATA
		{
			/// <summary>
			/// <para>
			/// The WINS mapping flag that specifies whether the record must be included into the zone replication. <c>dwMappingFlag</c>
			/// must be one of these mutually exclusive values:
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>DNS_WINS_FLAG_SCOPE</term>
			/// <term>Record is not local, replicate across zones.</term>
			/// </item>
			/// <item>
			/// <term>DNS_WINS_FLAG_LOCAL</term>
			/// <term>Record is local, do not replicate.</term>
			/// </item>
			/// </list>
			/// </summary>
			public DNS_WINS_FLAG dwMappingFlag;

			/// <summary>The time, in seconds, that a DNS Server attempts resolution using WINS lookup.</summary>
			public uint dwLookupTimeout;

			/// <summary>The time, in seconds, that a DNS Server using WINS lookup may cache the WINS Server's response.</summary>
			public uint dwCacheTimeout;

			/// <summary>A pointer to a string that represents the domain name to append to the name returned by a WINS reverse-lookup.</summary>
			[MarshalAs(UnmanagedType.LPTStr)] public string pNameResultDomain;
		}

		/// <summary>
		/// The <c>DNS_WIRE_QUESTION</c> structure contains information about a DNS question transmitted across the network as specified in
		/// section 4.1.2 of RFC 1035..
		/// </summary>
		/// <remarks>When constructing a DNS message, the question name must precede the <c>DNS_WIRE_QUESTION</c> structure.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/windns/ns-windns-dns_wire_question typedef struct _DNS_WIRE_QUESTION { WORD
		// QuestionType; WORD QuestionClass; } DNS_WIRE_QUESTION, *PDNS_WIRE_QUESTION;
		[PInvokeData("windns.h", MSDNShortId = "50498f20-0896-4471-8355-edd997aa4bcd")]
		[StructLayout(LayoutKind.Sequential)]
		public struct DNS_WIRE_QUESTION
		{
			/// <summary>A value that represents the question section's DNS Question Type.</summary>
			public ushort QuestionType;

			/// <summary>A value that represents the question section's DNS Question Class.</summary>
			public ushort QuestionClass;
		}

		/// <summary>
		/// The <c>DNS_WIRE_RECORD</c> structure contains information about a DNS wire record transmitted across the network as specified in
		/// section 4.1.3 of RFC 1035.
		/// </summary>
		/// <remarks>
		/// When constructing a DNS message, the <c>DNS_WIRE_RECORD</c> structure is immediately followed by the record data and is preceded
		/// by the DNS RR's domain name.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/windns/ns-windns-dns_wire_record typedef struct _DNS_WIRE_RECORD { WORD
		// RecordType; WORD RecordClass; DWORD TimeToLive; WORD DataLength; } DNS_WIRE_RECORD, *PDNS_WIRE_RECORD;
		[PInvokeData("windns.h", MSDNShortId = "fb36930c-dd43-427a-8034-078c99497a3e")]
		[StructLayout(LayoutKind.Sequential)]
		public struct DNS_WIRE_RECORD
		{
			/// <summary>
			/// A value that represents the RR DNS Response Type. <c>RecordType</c> determines the format of record data that follows the
			/// <c>DNS_WIRE_RECORD</c> structure. For example, if the value of <c>RecordType</c> is <c>DNS_TYPE_A</c>, the data type of
			/// record data is DNS_A_DATA.
			/// </summary>
			public DNS_TYPE RecordType;

			/// <summary>A value that represents the RR DNS Record Class.</summary>
			public DNS_CLASS RecordClass;

			/// <summary>The DNS Resource Record's Time To Live value (TTL), in seconds.</summary>
			public uint TimeToLive;

			/// <summary>The length, in bytes, of the DNS record data that follows the <c>DNS_WIRE_RECORD</c>.</summary>
			public ushort DataLength;
		}

		/// <summary>
		/// The <c>DNS_WKS_DATA</c> structure represents a DNS well-known services (WKS) record as specified in section 3.4.2 of RFC 1035.
		/// </summary>
		/// <remarks>
		/// The <c>DNS_WKS_DATA</c> structure is used in conjunction with the DNS_RECORD structure to programmatically manage DNS entries.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/windns/ns-windns-dns_wks_data typedef struct { IP4_ADDRESS IpAddress; UCHAR
		// chProtocol; BYTE BitMask[1]; } DNS_WKS_DATA, *PDNS_WKS_DATA;
		[PInvokeData("windns.h", MSDNShortId = "94477345-74e7-40bf-a75b-e4bf67f1c17b")]
		[StructLayout(LayoutKind.Sequential)]
		public struct DNS_WKS_DATA
		{
			/// <summary>An IP4_ADDRESS data type that contains the IPv4 address for this resource record (RR).</summary>
			public IP4_ADDRESS IpAddress;

			/// <summary>
			/// <para>A value that represents the IP protocol for this RR as defined in RFC 1010.</para>
			/// <para>Transmission Control Protocol (TCP) (6)</para>
			/// <para>User Datagram Protocol (UDP) (17)</para>
			/// </summary>
			public byte chProtocol;

			/// <summary>
			/// A variable-length bitmask whose bits correspond to the port number of well known services offered by the protocol specified
			/// in <c>chProtocol</c>. The bitmask has one bit for every port of the supported protocol, but must be a multiple of a
			/// <c>BYTE</c>. Bit 0 corresponds to port 1, bit 1 corresponds to port 2, and so forth for a maximum of 1024 bits.
			/// </summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
			public byte[] BitMask;
		}

		/// <summary>The <c>IP4_ARRAY</c> structure stores an array of IPv4 addresses.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/windns/ns-windns-ip4_array typedef struct _IP4_ARRAY { DWORD AddrCount; #if
		// ... IP4_ADDRESS AddrArray[]; #else IP4_ADDRESS AddrArray[1]; #endif } IP4_ARRAY, *PIP4_ARRAY;
		[PInvokeData("windns.h", MSDNShortId = "4273a739-129c-4951-b6df-aef4332ce0cb")]
		[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<IP4_ARRAY>), nameof(AddrCount))]
		[StructLayout(LayoutKind.Sequential)]
		public struct IP4_ARRAY
		{
			/// <summary>The number of IPv4 addresses in <c>AddrArray</c>.</summary>
			public uint AddrCount;

			/// <summary>An array of IP4_ADDRESS data types that contains a list of IPv4 address.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
			public IP4_ADDRESS[] AddrArray;
		}

		/// <summary>Contains information related to an ongoing MDNS query. Your application must not modify its contents.</summary>
		/// <remarks>This structure is for internal use only.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/windns/ns-windns-mdns_query_handle typedef struct _MDNS_QUERY_HANDLE { WCHAR
		// nameBuf[DNS_MAX_NAME_BUFFER_LENGTH]; WORD wType; PVOID pSubscription; PVOID pWnfCallbackParams; ULONG stateNameData[2]; }
		// MDNS_QUERY_HANDLE, *PMDNS_QUERY_HANDLE;
		[PInvokeData("windns.h")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct MDNS_QUERY_HANDLE
		{
			/// <summary>A value representing the queried name.</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = DNS_MAX_NAME_BUFFER_LENGTH)] public string nameBuf;

			/// <summary>A value representing the type of the query.</summary>
			public DNS_OPCODE wType;

			/// <summary>Reserved. Do not use.</summary>
			public IntPtr pSubscription;

			/// <summary>Reserved. Do not use.</summary>
			public IntPtr pWnfCallbackParams;

			/// <summary>Reserved. Do not use.</summary>
			public ulong stateNameData;
		}

		/// <summary>Contains the necessary information to perform an mDNS query.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/windns/ns-windns-mdns_query_request typedef struct _MDNS_QUERY_REQUEST { ULONG
		// Version; ULONG ulRefCount; PCWSTR Query; WORD QueryType; ULONG64 QueryOptions; ULONG InterfaceIndex; PMDNS_QUERY_CALLBACK
		// pQueryCallback; PVOID pQueryContext; BOOL fAnswerReceived; ULONG ulResendCount; } MDNS_QUERY_REQUEST, *PMDNS_QUERY_REQUEST;
		[PInvokeData("windns.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MDNS_QUERY_REQUEST
		{
			/// <summary>The structure version must be <c>DNS_QUERY_REQUEST_VERSION1</c>.</summary>
			public uint Version;

			/// <summary>Reserved. Do not use.</summary>
			public uint ulRefCount;

			/// <summary>A string representing the name to be queried over mDNS.</summary>
			[MarshalAs(UnmanagedType.LPWStr)] public string Query;

			/// <summary>A value representing the type of the records to be queried. See DNS_RECORD_TYPE for possible values.</summary>
			public DNS_TYPE QueryType;

			/// <summary>A value representing the query options. <c>DNS_QUERY_STANDARD</c> is the only supported value.</summary>
			public DNS_QUERY_OPTIONS QueryOptions;

			/// <summary>
			/// A value that contains the interface index over which the service is to be advertised. If is 0, then all interfaces will be considered.
			/// </summary>
			public uint InterfaceIndex;

			/// <summary>
			/// A pointer to a function (of type MDNS_QUERY_CALLBACK) that represents the callback to be invoked asynchronously whenever
			/// mDNS results are available.
			/// </summary>
			[MarshalAs(UnmanagedType.FunctionPtr)]
			public MDNS_QUERY_CALLBACK pQueryCallback;

			/// <summary>A pointer to a user context.</summary>
			public IntPtr pQueryContext;

			/// <summary>Reserved. Do not use.</summary>
			[MarshalAs(UnmanagedType.Bool)] public bool fAnswerReceived;

			/// <summary>Reserved. Do not use.</summary>
			public uint ulResendCount;
		}

		/// <summary>Represents a DNS service running on the network.</summary>
		[PInvokeData("windns.h")]
		public class SafePDNS_SERVICE_INSTANCE : SafeHANDLE
		{
			private uint _dwInterfaceIndex;
			private IP4_ADDRESS? _ip4Address;
			private IP6_ADDRESS? _ip6Address;
			private string[] _keys;
			private string _pszHostName;
			private string _pszInstanceName;
			private string[] _values;
			private ushort _wPort;
			private ushort _wPriority;
			private ushort _wWeight;
			private bool populated = false;

			/// <summary>A value that contains the interface index on which the service was discovered.</summary>
			public uint dwInterfaceIndex => PopulateFetch(ref _dwInterfaceIndex);

			/// <summary>A pointer to an <c>IP4_ADDRESS</c> structure that represents the service-associated IPv4 address.</summary>
			public IP4_ADDRESS? ip4Address => PopulateFetch(ref _ip4Address);

			/// <summary>A pointer to an IP6_ADDRESS structure that represents the service-associated IPv6 address.</summary>
			public IP6_ADDRESS? ip6Address => PopulateFetch(ref _ip6Address);

			/// <summary/>
			public string[] keys => PopulateFetch(ref _keys);

			/// <summary>A string that represents the name of the host of the service.</summary>
			public string pszHostName => PopulateFetch(ref _pszHostName);

			/// <summary>
			/// A string that represents the service name. This is a fully qualified domain name that begins with a service name, and ends
			/// with ".local". It takes the generalized form "&lt;ServiceName&gt;._&lt;ServiceType&gt;._&lt;TransportProtocol&gt;.local".
			/// For example, "MyMusicServer._http._tcp.local".
			/// </summary>
			public string pszInstanceName => PopulateFetch(ref _pszInstanceName);

			/// <summary/>
			public string[] values => PopulateFetch(ref _values);

			/// <summary>A value that represents the port on which the service is running.</summary>
			public ushort wPort => PopulateFetch(ref _wPort);

			/// <summary>A value that represents the service priority.</summary>
			public ushort wPriority => PopulateFetch(ref _wPriority);

			/// <summary>A value that represents the service weight.</summary>
			public ushort wWeight => PopulateFetch(ref _wWeight);

			/// <summary>Performs an implicit conversion from <see cref="SafePDNS_SERVICE_INSTANCE"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="instance">The instance.</param>
			/// <returns>The resulting <see cref="IntPtr"/> instance from the conversion.</returns>
			public static implicit operator IntPtr(SafePDNS_SERVICE_INSTANCE instance) => instance.handle;

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() { DnsServiceFreeInstance(handle); return true; }

			private T PopulateFetch<T>(ref T value)
			{
				if (!populated && !IsInvalid && !IsClosed)
				{
					var val = handle.ToStructure<DNS_SERVICE_INSTANCE>();
					_pszInstanceName = val.pszInstanceName;
					_pszHostName = val.pszHostName;
					_ip4Address = val.ip4Address.ToNullableStructure<IP4_ADDRESS>();
					_ip6Address = val.ip6Address.ToNullableStructure<IP6_ADDRESS>();
					_wPort = val.wPort;
					_wPriority = val.wPriority;
					_wWeight = val.wWeight;
					_keys = val.keys.ToStringEnum((int)val.dwPropertyCount, CharSet.Unicode).ToArray();
					_values = val.values.ToStringEnum((int)val.dwPropertyCount, CharSet.Unicode).ToArray();
					_dwInterfaceIndex = val.dwInterfaceIndex;
					populated = true;
				}
				return value;
			}
		}

		internal class PDNS_MESSAGE_BUFFER : SafeAnysizeStructBase<DNS_MESSAGE_BUFFER>
		{
			public PDNS_MESSAGE_BUFFER(IntPtr allocatedMemory, SizeT size) : base(allocatedMemory, size, false) { }

			protected override int GetArrayLength(in DNS_MESSAGE_BUFFER local) => Size - 12;
		}

		internal class DNS_MESSAGE_BUFFER_Marshaler : IVanaraMarshaler
		{
			public DNS_MESSAGE_BUFFER_Marshaler() { }

			SizeT IVanaraMarshaler.GetNativeSize() => Marshal.SizeOf(typeof(DNS_MESSAGE_BUFFER));

			SafeAllocatedMemoryHandle IVanaraMarshaler.MarshalManagedToNative(object managedObject) => SafeCoTaskMemHandle.Null;

			object IVanaraMarshaler.MarshalNativeToManaged(IntPtr pNativeData, SizeT allocatedBytes)
			{
				if (pNativeData == IntPtr.Zero) return null;
				using var s = new PDNS_MESSAGE_BUFFER(pNativeData, allocatedBytes);
				return s.Value;
			}
		}

		internal class SafeDNS_NSEC3_DATA : SafeAnysizeStructBase<DNS_NSEC3_DATA>
		{
			internal SafeDNS_NSEC3_DATA(DNS_NSEC3_DATA value) : base(baseSz)
			{
				ToNative(value);
			}

			internal SafeDNS_NSEC3_DATA(IntPtr allocatedMemory, SizeT size) : base(allocatedMemory, size, false)
			{
				if (allocatedMemory == IntPtr.Zero) throw new ArgumentNullException(nameof(allocatedMemory));
				if (baseSz > size) throw new OutOfMemoryException();
			}

			protected override int GetArrayLength(in DNS_NSEC3_DATA local) => local.bSaltLength + local.bHashLength + local.wTypeBitMapsLength;
		}

		internal class SafeDNS_NSEC3_DATAMarshaler : IVanaraMarshaler
		{
			/// <summary>Initializes a new instance of the <see cref="SafeDNS_NSEC3_DATAMarshaler"/> class.</summary>
			/// <param name="_">The .</param>
			public SafeDNS_NSEC3_DATAMarshaler(string _) { }

			SizeT IVanaraMarshaler.GetNativeSize() => Marshal.SizeOf(typeof(DNS_NSEC3_DATA));

			SafeAllocatedMemoryHandle IVanaraMarshaler.MarshalManagedToNative(object managedObject) =>
				managedObject is null ? SafeCoTaskMemHandle.Null : (SafeAllocatedMemoryHandle)new SafeDNS_NSEC3_DATA((DNS_NSEC3_DATA)managedObject);

			object IVanaraMarshaler.MarshalNativeToManaged(IntPtr pNativeData, SizeT allocatedBytes)
			{
				if (pNativeData == IntPtr.Zero) return null;
				using var s = new SafeDNS_NSEC3_DATA(pNativeData, allocatedBytes);
				return s.Value;
			}
		}
	}
}
