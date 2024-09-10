namespace Vanara.PInvoke;

public static partial class ActiveDS
{
	/// <summary>
	/// <para>The <c>ADS_ATTR_DEF</c> structure is used only as a part of <c>IDirectorySchemaMgmt</c>, which is an obsolete interface. The following information is provided for legacy purposes only.</para>
	/// <para>The <c>ADS_ATTR_DEF</c> structure describes schema data for an attribute. It is used to manage attribute definitions in the schema.</para>
	/// </summary>
	/// <remarks>In ADSI, attributes and properties are used interchangeably.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ns-iads-ads_attr_def
	// typedef struct _ads_attr_def { LPWSTR pszAttrName; ADSTYPE dwADsType; DWORD dwMinRange; DWORD dwMaxRange; BOOL fMultiValued; } ADS_ATTR_DEF, *PADS_ATTR_DEF;
	[PInvokeData("iads.h", MSDNShortId = "NS:iads._ads_attr_def")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ADS_ATTR_DEF
	{
		/// <summary>The null-terminated Unicode string that contains the name of the attribute.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pszAttrName;
		/// <summary>Data type of the attribute as defined by ADSTYPEENUM.</summary>
		public ADSTYPE dwADsType;
		/// <summary>Minimum legal range for this attribute.</summary>
		public uint dwMinRange;
		/// <summary>Maximum legal range for this attribute.</summary>
		public uint dwMaxRange;
		/// <summary>Whether or not this attribute takes more than one value.</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool fMultiValued;
	}

	/// <summary>The <c>ADS_ATTR_INFO</c> structure is used to contain one or more attribute values for use with the IDirectoryObject::CreateDSObject, IDirectoryObject::GetObjectAttributes, or IDirectoryObject::SetObjectAttributes method.</summary>
	/// <remarks>
	/// <para>In ADSI, attributes and properties are used interchangeably. Set attributes, when creating a directory service object, using the IDirectoryObject::CreateDSObject method. The IDirectoryObject interface also supports the IDirectoryObject::GetObjectAttributes and IDirectoryObject::SetObjectAttributes methods for retrieving and modifying the attributes of the object in a directory.</para>
	/// <para>Memory for the array of ADSVALUE structures is not allocated with this structure.</para>
	/// <para>The value of the <c>dwControlCode</c> member is ignored when the structure is used as an OUT parameter.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ns-iads-ads_attr_info
	// typedef struct _ads_attr_info { LPWSTR pszAttrName; DWORD dwControlCode; ADSTYPE dwADsType; PADSVALUE pADsValues; DWORD dwNumValues; } ADS_ATTR_INFO, *PADS_ATTR_INFO;
	[PInvokeData("iads.h", MSDNShortId = "NS:iads._ads_attr_info")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ADS_ATTR_INFO
	{
		/// <summary>The null-terminated Unicode string that contains the attribute name.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pszAttrName;
		/// <summary>Contains one of the ADSI Attribute Modification Types values that determines the type of operation to be performed on the attribute value.</summary>
		public ADS_ATTR dwControlCode;
		/// <summary>A value from the ADSTYPEENUM enumeration that indicates the data type of the attribute.</summary>
		public ADSTYPE dwADsType;
		/// <summary>Pointer to an array of ADSVALUE structures that contain values for the attribute.</summary>
		public ArrayPointer<ADSVALUE> pADsValues;
		/// <summary>Size of the <c>pADsValues</c> array.</summary>
		public uint dwNumValues;
	}

	/// <summary>The <c>ADS_BACKLINK</c> structure is an ADSI representation of the <c>Back Link</c> attribute syntax.</summary>
	/// <remarks>A <c>Back Link</c> attribute contains one or more servers that hold an external reference to the attached object.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ns-iads-ads_backlink
	// typedef struct __MIDL___MIDL_itf_ads_0000_0000_0008 { DWORD RemoteID; LPWSTR ObjectName; } ADS_BACKLINK, *PADS_BACKLINK;
	[PInvokeData("iads.h", MSDNShortId = "NS:iads.__MIDL___MIDL_itf_ads_0000_0000_0008")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ADS_BACKLINK
	{
		/// <summary>Identifier of the remote server that requires an external reference to the object specified by <c>ObjectName</c>. See below.</summary>
		public uint RemoteID;
		/// <summary>The null-terminated Unicode string that specifies the name of an object to which the <c>Back Link</c> attribute is attached.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string ObjectName;
	}

	/// <summary>The <c>ADS_CASEIGNORE_LIST</c> structure is an ADSI representation of the <c>Case Ignore List</c> attribute syntax.</summary>
	/// <remarks>A <c>Case Ignore List</c> attribute represents an ordered sequence of case insensitive strings.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ns-iads-ads_caseignore_list
	// typedef struct _ADS_CASEIGNORE_LIST { struct _ADS_CASEIGNORE_LIST *Next; LPWSTR String; } ADS_CASEIGNORE_LIST, *PADS_CASEIGNORE_LIST;
	[PInvokeData("iads.h", MSDNShortId = "NS:iads._ADS_CASEIGNORE_LIST")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ADS_CASEIGNORE_LIST
	{
		/// <summary>Pointer to the next <c>ADS_CASEIGNORE_LIST</c> in the list of case-insensitive strings.</summary>
		public IntPtr Next;
		/// <summary>The null-terminated Unicode string value of the current entry of the list.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string String;
	}

	/// <summary>
	/// <para>The <c>ADS_CLASS_DEF</c> structure is used only as a part of <c>IDirectorySchemaMgmt</c>, which is an obsolete interface. The information that follows is provided for legacy purposes only.</para>
	/// <para>The <c>ADS_CLASS_DEF</c> structure holds the definitions of an object class.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ns-iads-ads_class_def
	// typedef struct _ads_class_def { LPWSTR pszClassName; DWORD dwMandatoryAttrs; LPWSTR *ppszMandatoryAttrs; DWORD optionalAttrs; LPWSTR **ppszOptionalAttrs; DWORD dwNamingAttrs; LPWSTR **ppszNamingAttrs; DWORD dwSuperClasses; LPWSTR **ppszSuperClasses; BOOL fIsContainer; } ADS_CLASS_DEF, *PADS_CLASS_DEF;
	[PInvokeData("iads.h", MSDNShortId = "NS:iads._ads_class_def")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ADS_CLASS_DEF
	{
		/// <summary>The null-terminated Unicode string that specifies the class name.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pszClassName;
		/// <summary>The number of mandatory class attributes.</summary>
		public uint dwMandatoryAttrs;
		/// <summary>Pointer to an array of null-terminated Unicode strings that contain the names of the mandatory attributes.</summary>
		public LPCWSTRArrayPointer ppszMandatoryAttrs;
		/// <summary>Number of optional attributes of the class.</summary>
		public uint optionalAttrs;
		/// <summary>Pointer to an array of null-terminated Unicode strings that contain the names of the optional attributes.</summary>
		public LPCWSTRArrayPointer ppszOptionalAttrs;
		/// <summary>Number of naming attributes.</summary>
		public uint dwNamingAttrs;
		/// <summary>Pointer to an array of null-terminated Unicode strings that contain the names of the naming attributes.</summary>
		public LPCWSTRArrayPointer ppszNamingAttrs;
		/// <summary>Number of super classes of an object of this class.</summary>
		public uint dwSuperClasses;
		/// <summary>Pointer to an array of null-terminated Unicode strings that contain the names of the super classes.</summary>
		public LPCWSTRArrayPointer ppszSuperClasses;
		/// <summary>Flags that indicate the object of the class is a container when it is <c>TRUE</c> and not a container when <c>FALSE</c>.</summary>
		public bool fIsContainer;
	}

	/// <summary>The <c>ADS_DN_WITH_BINARY</c> structure is used with the ADSVALUE structure to contain a distinguished name attribute value that also contains binary data.</summary>
	/// <remarks>When extending the active directory schema to add <c>ADS_DN_WITH_BINARY</c>, you must also specify the otherWellKnownGuid attribute definition. Add the following to the ldf file attribute definition: omObjectClass:: KoZIhvcUAQEBCw==</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ns-iads-ads_dn_with_binary
	// typedef struct __MIDL___MIDL_itf_ads_0000_0000_0015 { DWORD dwLength; LPBYTE lpBinaryValue; LPWSTR pszDNString; } ADS_DN_WITH_BINARY, *PADS_DN_WITH_BINARY;
	[PInvokeData("iads.h", MSDNShortId = "NS:iads.__MIDL___MIDL_itf_ads_0000_0000_0015")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ADS_DN_WITH_BINARY
	{
		/// <summary>Contains the length, in bytes, of the binary data in <c>lpBinaryValue</c>.</summary>
		public uint dwLength;
		/// <summary>Pointer to an array of bytes that contains the binary data for the attribute. The <c>dwLength</c> member contains the number of bytes in this array.</summary>
		public IntPtr lpBinaryValue;
		/// <summary>Pointer to a null-terminated Unicode string that contains the distinguished name.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pszDNString;
	}

	/// <summary>The <c>ADS_DN_WITH_STRING</c> structure is used with the ADSVALUE structure to contain a distinguished name attribute value that also contains string data.</summary>
	/// <remarks>When extending the active directory schema to add <c>ADS_DN_WITH_STRING</c>, you must also specify the otherWellKnownGuid attribute definition. Add the following to the ldf file attribute definition: omObjectClass:: KoZIhvcUAQEBDA==</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ns-iads-ads_dn_with_string
	// typedef struct __MIDL___MIDL_itf_ads_0000_0000_0016 { LPWSTR pszStringValue; LPWSTR pszDNString; } ADS_DN_WITH_STRING, *PADS_DN_WITH_STRING;
	[PInvokeData("iads.h", MSDNShortId = "NS:iads.__MIDL___MIDL_itf_ads_0000_0000_0016")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ADS_DN_WITH_STRING
	{
		/// <summary>Pointer to a null-terminated Unicode string that contains the string value of the attribute.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pszStringValue;
		/// <summary>Pointer to a null-terminated Unicode string that contains the distinguished name.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pszDNString;
	}

	/// <summary>The <c>ADS_EMAIL</c> structure is an ADSI representation of the <c>EMail Address</c> attribute syntax.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ns-iads-ads_email
	// typedef struct __MIDL___MIDL_itf_ads_0000_0000_0014 { LPWSTR Address; DWORD Type; } ADS_EMAIL, *PADS_EMAIL;
	[PInvokeData("iads.h", MSDNShortId = "NS:iads.__MIDL___MIDL_itf_ads_0000_0000_0014")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ADS_EMAIL
	{
		/// <summary>The null-terminated Unicode string that contains the user address.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string Address;
		/// <summary>Type of the email message.</summary>
		public uint Type;
	}

	/// <summary>The <c>ADS_FAXNUMBER</c> structure is an ADSI representation of the <c>Facsimile Telephone Number</c> attribute syntax.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ns-iads-ads_faxnumber
	// typedef struct __MIDL___MIDL_itf_ads_0000_0000_0013 { LPWSTR TelephoneNumber; DWORD NumberOfBits; LPBYTE Parameters; } ADS_FAXNUMBER, *PADS_FAXNUMBER;
	[PInvokeData("iads.h", MSDNShortId = "NS:iads.__MIDL___MIDL_itf_ads_0000_0000_0013")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ADS_FAXNUMBER
	{
		/// <summary>The null-terminated Unicode string value that contains the telephone number of the facsimile (fax) machine.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string TelephoneNumber;
		/// <summary>The number of data bits.</summary>
		public uint NumberOfBits;
		/// <summary>Optional parameters for the fax machine.</summary>
		public IntPtr Parameters;
	}

	/// <summary>The <c>ADS_HOLD</c> structure is an ADSI representation of the <c>Hold</c> attribute syntax.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ns-iads-ads_hold
	// typedef struct __MIDL___MIDL_itf_ads_0000_0000_0010 { LPWSTR ObjectName; DWORD Amount; } ADS_HOLD, *PADS_HOLD;
	[PInvokeData("iads.h", MSDNShortId = "NS:iads.__MIDL___MIDL_itf_ads_0000_0000_0010")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ADS_HOLD
	{
		/// <summary>The null-terminated Unicode string that contains the name of an object put on hold.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string ObjectName;
		/// <summary>Number of charges that a server places against the user on hold while it verifies the user account balance.</summary>
		public uint Amount;
	}

	/// <summary>The <c>ADS_NETADDRESS</c> structure is an ADSI representation of the <c>Net Address</c> attribute syntax.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ns-iads-ads_netaddress
	// typedef struct __MIDL___MIDL_itf_ads_0000_0000_0011 { DWORD AddressType; DWORD AddressLength; BYTE *Address; } ADS_NETADDRESS, *PADS_NETADDRESS;
	[PInvokeData("iads.h", MSDNShortId = "NS:iads.__MIDL___MIDL_itf_ads_0000_0000_0011")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ADS_NETADDRESS
	{
		/// <summary>Types of communication protocols.</summary>
		public uint AddressType;
		/// <summary>Address length in bytes.</summary>
		public uint AddressLength;
		/// <summary>A network address.</summary>
		public IntPtr Address;
	}

	/// <summary>The <c>ADS_NT_SECURITY_DESCRIPTOR</c> structure defines the data type of the security descriptor for Windows.</summary>
	/// <remarks>The <c>ADS_NT_SECURITY_DESCRIPTOR</c> structure is normally used as a member of the ADSVALUE structure definition.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ns-iads-ads_nt_security_descriptor
	// typedef struct __MIDL___MIDL_itf_ads_0000_0000_0003 { DWORD dwLength; LPBYTE lpValue; } ADS_NT_SECURITY_DESCRIPTOR, *PADS_NT_SECURITY_DESCRIPTOR;
	[PInvokeData("iads.h", MSDNShortId = "NS:iads.__MIDL___MIDL_itf_ads_0000_0000_0003")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ADS_NT_SECURITY_DESCRIPTOR
	{
		/// <summary>The length data, in bytes.</summary>
		public uint dwLength;
		/// <summary>Pointer to the security descriptor, represented as a byte array.</summary>
		public IntPtr lpValue;
	}

	/// <summary>The <c>ADS_OBJECT_INFO</c> structure specifies the data, including the identity and location, of a directory service object.</summary>
	/// <remarks>To obtain the object data, non-Automation clients call the IDirectoryObject::GetObjectInformation method, which takes an out parameter, a pointer to an <c>ADS_OBJECT_INFO</c> structure allocated in the heap. Automation clients can accomplish the same task by calling IADs::GetInfo.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ns-iads-ads_object_info
	// typedef struct _ads_object_info { LPWSTR pszRDN; LPWSTR pszObjectDN; LPWSTR pszParentDN; LPWSTR pszSchemaDN; LPWSTR pszClassName; } ADS_OBJECT_INFO, *PADS_OBJECT_INFO;
	[PInvokeData("iads.h", MSDNShortId = "NS:iads._ads_object_info")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ADS_OBJECT_INFO
	{
		/// <summary>The null-terminated Unicode string that contains the relative distinguished name of the directory service object.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pszRDN;
		/// <summary>The null-terminated Unicode string that contains the distinguished name of the directory service object.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pszObjectDN;
		/// <summary>The null-terminated Unicode string that contains the distinguished name of the parent object.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pszParentDN;
		/// <summary>The null-terminated Unicode string that contains the distinguished name of the schema class of the object.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pszSchemaDN;
		/// <summary>The null-terminated Unicode string that contains the name of the class of which this object is an instance.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pszClassName;
	}

	/// <summary>The <c>ADS_OCTET_LIST</c> structure is an ADSI representation of an ordered sequence of single-byte strings.</summary>
	/// <remarks>For more information, see Novell NetWare Directory Services Schema Specification, version 1.1.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ns-iads-ads_octet_list
	// typedef struct _ADS_OCTET_LIST { struct _ADS_OCTET_LIST *Next; DWORD Length; BYTE *Data; } ADS_OCTET_LIST, *PADS_OCTET_LIST;
	[PInvokeData("iads.h", MSDNShortId = "NS:iads._ADS_OCTET_LIST")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ADS_OCTET_LIST
	{
		/// <summary>Pointer to the next <c>ADS_OCTET_LIST</c> entry in the list.</summary>
		public IntPtr Next;
		/// <summary>Contains the length, in bytes, of the list.</summary>
		public uint Length;
		/// <summary>Pointer to an array of BYTEs that contains the list. The <c>Length</c> member of this structure contains the number of BYTEs in this array.</summary>
		public IntPtr Data;
	}

	/// <summary>The <c>ADS_OCTET_STRING</c> structure is an ADSI representation of the <c>Octet String</c> attribute syntax used in Active Directory.</summary>
	/// <remarks>Memory for the byte array must be allocated separately.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ns-iads-ads_octet_string
	// typedef struct __MIDL___MIDL_itf_ads_0000_0000_0002 { DWORD dwLength; LPBYTE lpValue; } ADS_OCTET_STRING, *PADS_OCTET_STRING;
	[PInvokeData("iads.h", MSDNShortId = "NS:iads.__MIDL___MIDL_itf_ads_0000_0000_0002")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ADS_OCTET_STRING
	{
		/// <summary>The size, in bytes, of the character array.</summary>
		public uint dwLength;
		/// <summary>Pointer to an array of single byte characters not interpreted by the underlying directory.</summary>
		public IntPtr lpValue;
	}

	/// <summary>The <c>ADS_PATH</c> structure is an ADSI representation of the <c>Path</c> attribute syntax.</summary>
	/// <remarks>The <c>Path</c> attribute in represents a file system path.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ns-iads-ads_path
	// typedef struct __MIDL___MIDL_itf_ads_0000_0000_0005 { DWORD Type; LPWSTR VolumeName; LPWSTR Path; } ADS_PATH, *PADS_PATH;
	[PInvokeData("iads.h", MSDNShortId = "NS:iads.__MIDL___MIDL_itf_ads_0000_0000_0005")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ADS_PATH
	{
		/// <summary>Type of file in the file system.</summary>
		public ADS_PATHTYPE Type;
		/// <summary>The null-terminated Unicode string that contains the name of an existing volume in the file system.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string VolumeName;
		/// <summary>The null-terminated Unicode string that contains the path of a directory in the file system.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string Path;
	}

	/// <summary>The <c>ADS_POSTALADDRESS</c> structure is an ADSI representation of the <c>Postal Address</c> attribute.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ns-iads-ads_postaladdress
	// typedef struct __MIDL___MIDL_itf_ads_0000_0000_0006 { LPWSTR PostalAddress[6]; } ADS_POSTALADDRESS, *PADS_POSTALADDRESS;
	[PInvokeData("iads.h", MSDNShortId = "NS:iads.__MIDL___MIDL_itf_ads_0000_0000_0006")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct ADS_POSTALADDRESS
	{
		/// <summary>An array of six null-terminated Unicode strings that represent the postal address.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 6)]
		public string PostalAddress;
	}

	/// <summary>The <c>ADS_PROV_SPECIFIC</c> structure contains provider-specific data represented as a binary large object (BLOB).</summary>
	/// <remarks>
	/// <para>The <c>ADS_PROV_SPECIFIC</c> structure is one of the data types used as a member of the ADSVALUE structure definition. The data is represented as a BLOB here, although the actual data can be packed in any format, such as a C structure. The provider writer must publish the specific data format under the BLOB.</para>
	/// <para>ADSI may also return attributes as <c>ADS_PROV_SPECIFIC</c> if unable to determine the correct attribute syntax type as would occur if, for example, the schema was unavailable.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ns-iads-ads_prov_specific
	// typedef struct __MIDL___MIDL_itf_ads_0000_0000_0004 { DWORD dwLength; LPBYTE lpValue; } ADS_PROV_SPECIFIC, *PADS_PROV_SPECIFIC;
	[PInvokeData("iads.h", MSDNShortId = "NS:iads.__MIDL___MIDL_itf_ads_0000_0000_0004")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ADS_PROV_SPECIFIC
	{
		/// <summary>The size of the character array.</summary>
		public uint dwLength;
		/// <summary>A pointer to an array of bytes.</summary>
		public IntPtr lpValue;
	}

	/// <summary>The <c>ADS_REPLICAPOINTER</c> structure represents an ADSI representation of the Replica Pointer attribute syntax.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ns-iads-ads_replicapointer
	// typedef struct __MIDL___MIDL_itf_ads_0000_0000_0012 { LPWSTR ServerName; DWORD ReplicaType; DWORD ReplicaNumber; DWORD Count; PADS_NETADDRESS ReplicaAddressHints; } ADS_REPLICAPOINTER, *PADS_REPLICAPOINTER;
	[PInvokeData("iads.h", MSDNShortId = "NS:iads.__MIDL___MIDL_itf_ads_0000_0000_0012")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ADS_REPLICAPOINTER
	{
		/// <summary>The null-terminated Unicode string that contains the name of the name server that holds the replica.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string ServerName;
		/// <summary>Type of replica: master, secondary, or read-only.</summary>
		public uint ReplicaType;
		/// <summary>Replica identification number.</summary>
		public uint ReplicaNumber;
		/// <summary>The number of existing replicas.</summary>
		public uint Count;
		/// <summary>A network address that is a likely reference to a node leading to the name server.</summary>
		public ArrayPointer<ADS_NETADDRESS> ReplicaAddressHints;
	}

	/// <summary>The <c>ADS_SEARCH_COLUMN</c> structure specifies the contents of a search column in the query returned from the directory service database.</summary>
	/// <remarks>
	/// <para>The <c>ADS_SEARCH_COLUMN</c> structure only contains a pointer to the array of ADSVALUE structures. Memory for the structure must be allocated separately.</para>
	/// <para>For more information about <c>ADS_SEARCH_COLUMN</c>, see IDirectorySearch::GetColumn.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ns-iads-ads_search_column
	// typedef struct ads_search_column { LPWSTR pszAttrName; ADSTYPE dwADsType; PADSVALUE pADsValues; DWORD dwNumValues; HANDLE hReserved; } ADS_SEARCH_COLUMN, *PADS_SEARCH_COLUMN;
	[PInvokeData("iads.h", MSDNShortId = "NS:iads.ads_search_column")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ADS_SEARCH_COLUMN
	{
		/// <summary>A null-terminated Unicode string that contains the name of the attribute whose values are contained in the current search column.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pszAttrName;
		/// <summary>Value from the ADSTYPEENUM enumeration that indicates how the attribute values are interpreted.</summary>
		public ADSTYPE dwADsType;
		/// <summary>Array of ADSVALUE structures that contain values of the attribute in the current search column for the current row.</summary>
		public ArrayPointer<ADSVALUE> pADsValues;
		/// <summary>Size of the <c>pADsValues</c> array.</summary>
		public uint dwNumValues;
		/// <summary>Reserved for internal use by providers.</summary>
		public HANDLE hReserved;
	}

	/// <summary>The <c>ADS_SEARCHPREF_INFO</c> structure specifies the query preferences.</summary>
	/// <remarks>
	/// <para>To setup a search preference, assign appropriate values to the fields of an <c>ADS_SEARCHPREF_INFO</c> structure passed to the server. The <c>vValue</c> member of the <c>ADS_SEARCHPREF_INFO</c> structure is an ADSVALUE structure. The following table lists the ADS_SEARCHPREF_ENUM values, the corresponding values for the <c>dwType</c> member of the <c>ADSVALUE</c> structure, and the <c>ADSVALUE</c> member that is used for the specified type.</para>
	/// <list type="table">
	/// <listheader>
	/// <description>ADS_SEARCHPREF_ENUM Value</description>
	/// <description><c>dwType</c> member of ADSVALUE</description>
	/// <description>ADSVALUE member</description>
	/// </listheader>
	/// <item>
	/// <description><c>ADS_SEARCHPREF_ASYNCHRONOUS</c></description>
	/// <description><c>ADSTYPE_BOOLEAN</c></description>
	/// <description><c>Boolean</c></description>
	/// </item>
	/// <item>
	/// <description><c>ADS_SEARCHPREF_DEREF_ALIASES</c></description>
	/// <description><c>ADSTYPE_INTEGER</c></description>
	/// <description><c>Integer</c></description>
	/// </item>
	/// <item>
	/// <description><c>ADS_SEARCHPREF_SIZE_LIMIT</c></description>
	/// <description><c>ADSTYPE_INTEGER</c></description>
	/// <description><c>Integer</c></description>
	/// </item>
	/// <item>
	/// <description><c>ADS_SEARCHPREF_TIME_LIMIT</c></description>
	/// <description><c>ADSTYPE_INTEGER</c></description>
	/// <description><c>Integer</c></description>
	/// </item>
	/// <item>
	/// <description><c>ADS_SEARCHPREF_ATTRIBTYPES_ONLY</c></description>
	/// <description><c>ADSTYPE_BOOLEAN</c></description>
	/// <description><c>Boolean</c></description>
	/// </item>
	/// <item>
	/// <description><c>ADS_SEARCHPREF_SEARCH_SCOPE</c></description>
	/// <description><c>ADSTYPE_INTEGER</c></description>
	/// <description><c>Integer</c></description>
	/// </item>
	/// <item>
	/// <description><c>ADS_SEARCHPREF_TIMEOUT</c></description>
	/// <description><c>ADSTYPE_INTEGER</c></description>
	/// <description><c>Integer</c></description>
	/// </item>
	/// <item>
	/// <description><c>ADS_SEARCHPREF_PAGESIZE</c></description>
	/// <description><c>ADSTYPE_INTEGER</c></description>
	/// <description><c>Integer</c></description>
	/// </item>
	/// <item>
	/// <description><c>ADS_SEARCHPREF_PAGED_TIME_LIMIT</c></description>
	/// <description><c>ADSTYPE_INTEGER</c></description>
	/// <description><c>Integer</c></description>
	/// </item>
	/// <item>
	/// <description><c>ADS_SEARCHPREF_CHASE_REFERRALS</c></description>
	/// <description><c>ADSTYPE_INTEGER</c></description>
	/// <description><c>Integer</c></description>
	/// </item>
	/// <item>
	/// <description><c>ADS_SEARCHPREF_SORT_ON</c></description>
	/// <description><c>ADSTYPE_PROV_SPECIFIC</c></description>
	/// <description><c>ProviderSpecific</c></description>
	/// </item>
	/// <item>
	/// <description><c>ADS_SEARCHPREF_CACHE_RESULTS</c></description>
	/// <description><c>ADSTYPE_BOOLEAN</c></description>
	/// <description><c>Boolean</c></description>
	/// </item>
	/// <item>
	/// <description><c>ADS_SEARCHPREF_DIRSYNC</c></description>
	/// <description><c>ADSTYPE_PROV_SPECIFIC</c></description>
	/// <description><c>ProviderSpecific</c></description>
	/// </item>
	/// <item>
	/// <description><c>ADS_SEARCHPREF_TOMBSTONE</c></description>
	/// <description><c>ADSTYPE_BOOLEAN</c></description>
	/// <description><c>Boolean</c></description>
	/// </item>
	/// <item>
	/// <description><c>ADS_SEARCHPREF_VLV</c></description>
	/// <description><c>ADSTYPE_PROV_SPECIFIC</c></description>
	/// <description><c>ProviderSpecific</c></description>
	/// </item>
	/// <item>
	/// <description><c>ADS_SEARCHPREF_ATTRIBUTE_QUERY</c></description>
	/// <description><c>ADSTYPE_CASE_IGNORE_STRING</c></description>
	/// <description><c>CaseIgnoreString</c></description>
	/// </item>
	/// <item>
	/// <description><c>ADS_SEARCHPREF_SECURITY_MASK</c></description>
	/// <description><c>ADSTYPE_INTEGER</c></description>
	/// <description><c>Integer</c></description>
	/// </item>
	/// <item>
	/// <description><c>ADS_SEARCHPREF_DIRSYNC_FLAG</c></description>
	/// <description><c>ADSTYPE_INTEGER</c></description>
	/// <description><c>Integer</c></description>
	/// </item>
	/// <item>
	/// <description><c>ADS_SEARCHPREF_EXTENDED_DN</c></description>
	/// <description><c>ADSTYPE_INTEGER</c></description>
	/// <description><c>Integer</c></description>
	/// </item>
	/// </list>
	/// <para> </para>
	/// <para>For more information and examples of how to use the <c>ADS_SEARCHPREF_INFO</c> structure, see the discussions of the IDirectorySearch::SetSearchPreference method and the ADS_SEARCHPREF_ENUM enumeration.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ns-iads-ads_searchpref_info
	// typedef struct ads_searchpref_info { ADS_SEARCHPREF dwSearchPref; ADSVALUE vValue; ADS_STATUS dwStatus; } ADS_SEARCHPREF_INFO, *PADS_SEARCHPREF_INFO, *LPADS_SEARCHPREF_INFO;
	[PInvokeData("iads.h", MSDNShortId = "NS:iads.ads_searchpref_info")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ADS_SEARCHPREF_INFO
	{
		/// <summary>Contains one of the ADS_SEARCHPREF_ENUM enumeration values that specifies the search option to set.</summary>
		public ADS_SEARCHPREF dwSearchPref;
		/// <summary>Contains a ADSVALUE structure that specifies the data type and value of the search preference.</summary>
		public ADSVALUE vValue;
		/// <summary>Receives one of the ADS_STATUSENUM enumeration values that indicates the status of the search preference. The IDirectorySearch::SetSearchPreference method will fill in this member when it is called.</summary>
		public ADS_STATUS dwStatus;
	}

	/// <summary>The <c>ADS_SORTKEY</c> structure specifies how to sort a query.</summary>
	/// <remarks>
	/// <para>In Active Directory, if <c>TRUE</c>, the <c>fReverseorder</c> member specifies that the sort results be ordered from the lowest to the highest.</para>
	/// <para>When using the LDAP system provider, the <c>pszReserved</c> member corresponds to the <c>sk_matchruleoid</c> of the LDAPSortKey structure and may be set to a NULL-terminated string that specifies the object identifier (OID) of the matching rule for the sort. For more information, see <c>LDAPSortKey</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ns-iads-ads_sortkey
	// typedef struct _ads_sortkey { LPWSTR pszAttrType; LPWSTR pszReserved; BOOLEAN fReverseorder; } ADS_SORTKEY, *PADS_SORTKEY;
	[PInvokeData("iads.h", MSDNShortId = "NS:iads._ads_sortkey")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ADS_SORTKEY
	{
		/// <summary>The null-terminated Unicode string that contains the attribute type.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pszAttrType;
		/// <summary>Reserved.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pszReserved;
		/// <summary>Reverse the order of the sorted results.</summary>
		[MarshalAs(UnmanagedType.U1)]
		public bool fReverseorder;
	}

	/// <summary>The <c>ADS_TIMESTAMP</c> structure is an ADSI representation of the <c>Timestamp</c> attribute syntax.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ns-iads-ads_timestamp
	// typedef struct __MIDL___MIDL_itf_ads_0000_0000_0007 { DWORD WholeSeconds; DWORD EventID; } ADS_TIMESTAMP, *PADS_TIMESTAMP;
	[PInvokeData("iads.h", MSDNShortId = "NS:iads.__MIDL___MIDL_itf_ads_0000_0000_0007")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ADS_TIMESTAMP
	{
		/// <summary>Number of seconds, with zero value being equal to 12:00 AM, January, 1970, UTC.</summary>
		public uint WholeSeconds;
		/// <summary>An event identifier, in the order of occurrence, within the period specified by <c>WholeSeconds</c>.</summary>
		public uint EventID;
	}

	/// <summary>The <c>ADS_TYPEDNAME</c> structure represents an ADSI representation of <c>Typed Name</c> attribute syntax.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ns-iads-ads_typedname
	// typedef struct __MIDL___MIDL_itf_ads_0000_0000_0009 { LPWSTR ObjectName; DWORD Level; DWORD Interval; } ADS_TYPEDNAME, *PADS_TYPEDNAME;
	[PInvokeData("iads.h", MSDNShortId = "NS:iads.__MIDL___MIDL_itf_ads_0000_0000_0009")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ADS_TYPEDNAME
	{
		/// <summary>The null-terminated Unicode string that contains an object name.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string ObjectName;
		/// <summary>The priority associated with the object.</summary>
		public uint Level;
		/// <summary>The frequency of reference of the object.</summary>
		public uint Interval;
	}

	/// <summary>
	/// <para>The <c>ADSVALUE</c> structure contains a value specified as an ADSI data type. These data types can be ADSI Simple Data Types or ADSI-defined custom data types that include C-style structures.</para>
	/// <para>The ADS_ATTR_INFO structure contains an array of <c>ADSVALUE</c> structures. Each <c>ADSVALUE</c> structure contains a single attribute value.</para>
	/// </summary>
	/// <remarks>Members of the <c>ADSVALUE</c> structure specify the data type of attributes. For more information and a code example, see ADS_ATTR_INFO.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ns-iads-adsvalue
	// typedef struct _adsvalue { ADSTYPE dwType; union { ADS_DN_STRING DNString; ADS_CASE_EXACT_STRING CaseExactString; ADS_CASE_IGNORE_STRING CaseIgnoreString; ADS_PRINTABLE_STRING PrintableString; ADS_NUMERIC_STRING NumericString; ADS_BOOLEAN Boolean; ADS_INTEGER Integer; ADS_OCTET_STRING OctetString; ADS_UTC_TIME UTCTime; ADS_LARGE_INTEGER LargeInteger; ADS_OBJECT_CLASS ClassName; ADS_PROV_SPECIFIC ProviderSpecific; PADS_CASEIGNORE_LIST pCaseIgnoreList; PADS_OCTET_LIST pOctetList; PADS_PATH pPath; PADS_POSTALADDRESS pPostalAddress; ADS_TIMESTAMP Timestamp; ADS_BACKLINK BackLink; PADS_TYPEDNAME pTypedName; ADS_HOLD Hold; PADS_NETADDRESS pNetAddress; PADS_REPLICAPOINTER pReplicaPointer; PADS_FAXNUMBER pFaxNumber; ADS_EMAIL Email; ADS_NT_SECURITY_DESCRIPTOR SecurityDescriptor; PADS_DN_WITH_BINARY pDNWithBinary; PADS_DN_WITH_STRING pDNWithString; }; } ADSVALUE, *PADSVALUE, *LPADSVALUE;
	[PInvokeData("iads.h", MSDNShortId = "NS:iads._adsvalue")]
	[StructLayout(LayoutKind.Explicit)]
	public struct ADSVALUE
	{
		/// <summary>Data type used to interpret the union member of the structure. Values of this member are taken from the ADSTYPEENUM enumeration.</summary>
		[FieldOffset(0)]
		public ADSTYPE dwType;
		/// <summary>The null-terminated Unicode string that identifies the distinguished name (path) of a directory service object, as defined by <c>ADS_DN_STRING</c>, an ADSI simple data type.</summary>
		[FieldOffset(4)]
		public StrPtrUni DNString;
		/// <summary>The null-terminated Unicode string to be interpreted case-sensitively, as defined by <c>ADS_CASE_EXACT_STRING</c>, an ADSI simple data type.</summary>
		[FieldOffset(4)]
		public StrPtrUni CaseExactString;
		/// <summary>The null-terminated Unicode string to be interpreted without regard to case, as defined by <c>ADS_CASE_IGNORE_STRING</c>, an ADSI simple data type.</summary>
		[FieldOffset(4)]
		public StrPtrUni CaseIgnoreString;
		/// <summary>The null-terminated Unicode string that can be displayed or printed, as defined by <c>ADS_PRINTABLE_STRING</c>, an ADSI simple data type.</summary>
		[FieldOffset(4)]
		public StrPtrUni PrintableString;
		/// <summary>The null-terminated Unicode string that contains numerals to be interpreted as text, as defined by <c>ADS_NUMERIC_STRING</c>, an ADSI simple data type.</summary>
		[FieldOffset(4)]
		public StrPtrUni NumericString;
		/// <summary>Boolean value, as defined by <c>ADS_BOOLEAN</c>, an ADSI simple data type.</summary>
		[FieldOffset(4)]
		public BOOL Boolean;
		/// <summary>Integer value, as defined by <c>ADS_INTEGER</c>, an ADSI simple data type.</summary>
		[FieldOffset(4)]
		public int Integer;
		/// <summary>An octet string, as defined by ADS_OCTET_STRING, an ADSI-defined data type.</summary>
		[FieldOffset(4)]
		public ADS_OCTET_STRING OctetString;
		/// <summary>Time specified as Coordinated Universal Time (UTC), as defined by <c>ADS_UTC_TIME</c>, an ADSI simple data type.</summary>
		[FieldOffset(4)]
		public SYSTEMTIME UTCTime;
		/// <summary>Long integer value, as defined by <c>ADS_LARGE_INTEGER</c>, an ADSI simple data type.</summary>
		[FieldOffset(4)]
		public long LargeInteger;
		/// <summary>Class name string, as defined by <c>ADS_OBJECT_CLASS</c>, an ADSI simple data type.</summary>
		[FieldOffset(4)]
		public StrPtrUni ClassName;
		/// <summary>Provider-specific structure, as defined by ADS_PROV_SPECIFIC, an ADSI-defined data type.</summary>
		[FieldOffset(4)]
		public ADS_PROV_SPECIFIC ProviderSpecific;
		/*
		/// <summary>Pointer to a ADS_CASEIGNORE_LIST, an ADSI-defined data type.</summary>
		[FieldOffset(4)]
		public StructPointer<ADS_CASEIGNORE_LIST> pCaseIgnoreList;
		/// <summary>Pointer to a list of ADS_OCTET_LIST, an ADSI-defined data type.</summary>
		[FieldOffset(4)]
		public ArrayPointer<ADS_OCTET_LIST> pOctetList;
		/// <summary>Pointer to the ADS_PATH name, an ADSI-defined data type.</summary>
		[FieldOffset(4)]
		public StructPointer<ADS_PATH> pPath;
		/// <summary>Pointer to the ADS_POSTALADDRESS data, an ADSI-defined data type.</summary>
		[FieldOffset(4)]
		public StructPointer<ADS_POSTALADDRESS> pPostalAddress;
		/// <summary>Time stamp of the ADS_TIMESTAMP type, an ADSI-defined data type.</summary>
		[FieldOffset(4)]
		public ADS_TIMESTAMP Timestamp;
		/// <summary>A link of the ADS_BACKLINK type, an ADSI-defined data type.</summary>
		[FieldOffset(4)]
		public ADS_BACKLINK BackLink;
		/// <summary>Pointer to the ADS_TYPEDNAME name, an ADSI-defined data type.</summary>
		[FieldOffset(4)]
		public StructPointer<ADS_TYPEDNAME> pTypedName;
		/// <summary>A data structure of the ADS_HOLD type, an ADSI-defined data type.</summary>
		[FieldOffset(4)]
		public ADS_HOLD Hold;
		/// <summary>Pointer to the ADS_NETADDRESS data, an ADSI-defined data type.</summary>
		[FieldOffset(4)]
		public StructPointer<ADS_NETADDRESS> pNetAddress;
		/// <summary>Pointer to a replica pointer of ADS_REPLICAPOINTER, an ADSI-defined data type.</summary>
		[FieldOffset(4)]
		public StructPointer<ADS_REPLICAPOINTER> pReplicaPointer;
		/// <summary>Pointer to a facsimile number of ADS_FAXNUMBER, an ADSI-defined data type.</summary>
		[FieldOffset(4)]
		public StructPointer<ADS_FAXNUMBER> pFaxNumber;
		/// <summary>Email address of a user of ADS_EMAIL, an ADSI-defined data type.</summary>
		[FieldOffset(4)]
		public ADS_EMAIL Email;
		/// <summary>Windows security descriptor, as defined by ADS_NT_SECURITY_DESCRIPTOR, an ADSI-defined data type.</summary>
		[FieldOffset(4)]
		public ADS_NT_SECURITY_DESCRIPTOR SecurityDescriptor;
		/// <summary>Pointer to an ADS_DN_WITH_BINARY structure that maps a distinguished name of an object to its GUID value.</summary>
		[FieldOffset(4)]
		public StructPointer<ADS_DN_WITH_BINARY> pDNWithBinary;
		/// <summary>Pointer to an ADS_DN_WITH_STRING structure that maps a distinguished name of an object to a nonvarying string value.</summary>
		[FieldOffset(4)]
		public StructPointer<ADS_DN_WITH_STRING> pDNWithString;
		*/
	}

	/// <summary>The <c>ADS_VLV</c> structure contains metadata used to conduct virtual list view (VLV) searches. This structure serves two roles. First, it specifies the search preferences sent to the server. Second, it returns the VLV metadata from the server.</summary>
	/// <remarks>
	/// <para>To set the VLV by <c>dwContentCount</c> and <c>dwOffset</c>, you must also set the <c>pszTarget</c> to a <c>NULL</c> value. If <c>pszTarget</c> contains a non-<c>NULL</c> value, then it is used as the offset, otherwise, <c>lOffset</c> is used as the offset. It is recommended that you initialize the structure to zero.</para>
	/// <para>Examples</para>
	/// <para>The following code example shows how to retrieve the first 30 entries in a result set.</para>
	/// <para>The following code example shows how to retrieve the first 50 entries in a result set that start with the letters "Ha".</para>
	/// <para>The following code example shows how to retrieve the first 100 entries at the 60% approximate target, assuming that the server previously returned <c>dwContentCount</c> as 4294.</para>
	/// <para><c>Note</c>  vlvResp represents an <c>ADS_VLV</c> structure previously returned by the server.</para>
	/// <para> </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ns-iads-ads_vlv
	// typedef struct _ads_vlv { DWORD dwBeforeCount; DWORD dwAfterCount; DWORD dwOffset; DWORD dwContentCount; LPWSTR pszTarget; DWORD dwContextIDLength; LPBYTE lpContextID; } ADS_VLV, *PADS_VLV;
	[PInvokeData("iads.h", MSDNShortId = "NS:iads._ads_vlv")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ADS_VLV
	{
		/// <summary>Indicates the number of entries, before the target entry, that the client requests from the server.</summary>
		public uint dwBeforeCount;
		/// <summary>Indicates the number of entries, after the target entry, that the client requests from the server.</summary>
		public uint dwAfterCount;
		/// <summary>On input, indicates the target entry's requested offset within the list. If the client specifies an offset which equals the client's assumed content count, then the target is the last entry in the list. On output, indicates the server's best estimate as to the actual offset of the returned target entry's position in the list.</summary>
		public uint dwOffset;
		/// <summary>The input value represents the client's estimated value for the content count. The output value is the server's estimate of the content count. If the client sends a content count of zero, this means that the server must use its estimate of the content count in place of the client's.</summary>
		public uint dwContentCount;
		/// <summary>Optional. Null-terminated Unicode string that indicates the desired target entry requested by the client. If this parameter contains a non-<c>NULL</c> value, the server ignores the value specified in <c>dwOffset</c> and search for the first target entry whose value for the primary sort key is greater than or equal to the specified string, based on the sort order of the list.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pszTarget;
		/// <summary>Optional. Parameter that indicates the length of the context identifier. On input, if passing a context identifier in <c>lpContextID</c>, this must be set to the size of the identifier in bytes. Otherwise, it must be set equal to zero. On output, if <c>lpContextID</c> contains a non-<c>NULL</c> value, this indicates the length, in bytes, of the context ID returned by the server.</summary>
		public uint dwContextIDLength;
		/// <summary>Optional. Indicates the server-generated context identifier. This parameter may be sent to clients. If a client receives this parameter, it should return it unchanged in a subsequent request which relates to the same list. This interaction may enhance the performance and effectiveness of the servers. If not passing a context identifier to the server, this member must be set to <c>NULL</c> value. On output, if this member contains a non-<c>NULL</c> value, this points to the context ID returned by the server.</summary>
		public IntPtr lpContextID;
	}

}