using Microsoft.Win32.SafeHandles;
using System;
using System.ComponentModel;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security;
using Vanara.Extensions;
using Vanara.InteropServices;

// ReSharper disable InconsistentNaming ReSharper disable FieldCanBeMadeReadOnly.Global

namespace Vanara.PInvoke
{
	/// <summary>Platform invokable enumerated types, constants and functions from ntdsapi.h</summary>
	public static partial class NTDSApi
	{
		private const uint NO_ERROR = 0;

		/// <summary>
		/// Defines the errors returned by the status member of the <see cref="DS_NAME_RESULT_ITEM"/> structure. These are potential errors that may be
		/// encountered while a name is converted by the <see cref="DsCrackNames(SafeDsHandle, string[], DS_NAME_FORMAT, DS_NAME_FORMAT, DS_NAME_FLAGS)"/> function.
		/// </summary>
		[PInvokeData("Ntdsapi.h", MSDNShortId = "ms676061")]
		public enum DS_NAME_ERROR
		{
			/// <summary>The conversion was successful.</summary>
			DS_NAME_NO_ERROR = 0,

			/// <summary>A generic processing error occurred.</summary>
			DS_NAME_ERROR_RESOLVING = 1,

			/// <summary>The name cannot be found or the caller does not have permission to access the name.</summary>
			DS_NAME_ERROR_NOT_FOUND = 2,

			/// <summary>The input name is mapped to more than one output name or the desired format did not have a single, unique value for the object found.</summary>
			DS_NAME_ERROR_NOT_UNIQUE = 3,

			/// <summary>
			/// The input name was found, but the associated output format cannot be found. This can occur if the object does not have all the required attributes.
			/// </summary>
			DS_NAME_ERROR_NO_MAPPING = 4,

			/// <summary>
			/// Unable to resolve entire name, but was able to determine in which domain object resides. The caller is expected to retry the call at a domain
			/// controller for the specified domain. The entire name cannot be resolved, but the domain that the object resides in could be determined. The
			/// pDomain member of the DS_NAME_RESULT_ITEM contains valid data when this error is specified.
			/// </summary>
			DS_NAME_ERROR_DOMAIN_ONLY = 5,

			/// <summary>A syntactical mapping cannot be performed on the client without transmitting over the network.</summary>
			DS_NAME_ERROR_NO_SYNTACTICAL_MAPPING = 6,

			/// <summary>The name is from an external trusted forest.</summary>
			DS_NAME_ERROR_TRUST_REFERRAL = 7
		}

		/// <summary>
		/// Used to define how the name syntax will be cracked. These flags are used by the <see cref="DsCrackNames(SafeDsHandle, string[], DS_NAME_FORMAT, DS_NAME_FORMAT, DS_NAME_FLAGS)"/> function.
		/// </summary>
		[Flags]
		[PInvokeData("Ntdsapi.h", MSDNShortId = "ms676062")]
		public enum DS_NAME_FLAGS
		{
			/// <summary>Indicates that there are no associated flags.</summary>
			DS_NAME_NO_FLAGS = 0x0,

			/// <summary>
			/// Performs a syntactical mapping at the client without transferring over the network. The only syntactic mapping supported is from
			/// DS_FQDN_1779_NAME to DS_CANONICAL_NAME or DS_CANONICAL_NAME_EX. <see cref="DsCrackNames(SafeDsHandle, string[], DS_NAME_FORMAT, DS_NAME_FORMAT, DS_NAME_FLAGS)"/>
			/// returns the DS_NAME_ERROR_NO_SYNTACTICAL_MAPPING flag if a syntactical mapping is not possible.
			/// </summary>
			DS_NAME_FLAG_SYNTACTICAL_ONLY = 0x1,

			/// <summary>Forces a trip to the domain controller for evaluation, even if the syntax could be cracked locally.</summary>
			DS_NAME_FLAG_EVAL_AT_DC = 0x2,

			/// <summary>The call fails if the domain controller is not a global catalog server.</summary>
			DS_NAME_FLAG_GCVERIFY = 0x4,

			/// <summary>Enables cross forest trust referral.</summary>
			DS_NAME_FLAG_TRUST_REFERRAL = 0x8
		}

		/// <summary>
		/// Provides formats to use for input and output names for the <see cref="DsCrackNames(SafeDsHandle, string[], DS_NAME_FORMAT, DS_NAME_FORMAT, DS_NAME_FLAGS)"/> function.
		/// </summary>
		[PInvokeData("Ntdsapi.h", MSDNShortId = "ms676245")]
		public enum DS_NAME_FORMAT
		{
			/// <summary>
			/// Indicates the name is using an unknown name type. This format can impact performance because it forces the server to attempt to match all
			/// possible formats. Only use this value if the input format is unknown.
			/// </summary>
			DS_UNKNOWN_NAME = 0,

			/// <summary>
			/// Indicates that the fully qualified distinguished name is used. For example: CN = someone, OU = Users, DC = Engineering, DC = Fabrikam, DC = Com
			/// </summary>
			DS_FQDN_1779_NAME = 1,

			/// <summary>
			/// Indicates a Windows NT 4.0 account name. For example: Engineering\someone The domain-only version includes two trailing backslashes (\\).
			/// </summary>
			DS_NT4_ACCOUNT_NAME = 2,

			/// <summary>
			/// Indicates a user-friendly display name, for example, Jeff Smith. The display name is not necessarily the same as relative distinguished name (RDN).
			/// </summary>
			DS_DISPLAY_NAME = 3,

			/// <summary>Indicates a GUID string that the IIDFromString function returns. For example: {4fa050f0-f561-11cf-bdd9-00aa003a77b6}</summary>
			DS_UNIQUE_ID_NAME = 6,

			/// <summary>
			/// Indicates a complete canonical name. For example: engineering.fabrikam.com/software/someone The domain-only version includes a trailing forward
			/// slash (/).
			/// </summary>
			DS_CANONICAL_NAME = 7,

			/// <summary>Indicates that it is using the user principal name (UPN). For example: someone@engineering.fabrikam.com</summary>
			DS_USER_PRINCIPAL_NAME = 8,

			/// <summary>
			/// This element is the same as DS_CANONICAL_NAME except that the rightmost forward slash (/) is replaced with a newline character (\n), even in a
			/// domain-only case. For example: engineering.fabrikam.com/software\nsomeone
			/// </summary>
			DS_CANONICAL_NAME_EX = 9,

			/// <summary>Indicates it is using a generalized service principal name. For example: www/www.fabrikam.com@fabrikam.com</summary>
			DS_SERVICE_PRINCIPAL_NAME = 10,

			/// <summary>
			/// Indicates a Security Identifier (SID) for the object. This can be either the current SID or a SID from the object SID history. The SID string can
			/// use either the standard string representation of a SID, or one of the string constants defined in Sddl.h. For more information about converting a
			/// binary SID into a SID string, see SID Strings. The following is an example of a SID string: S-1-5-21-397955417-626881126-188441444-501
			/// </summary>
			DS_SID_OR_SID_HISTORY_NAME = 11,

			/// <summary>Not supported by the Directory Service (DS) APIs.</summary>
			DS_DNS_DOMAIN_NAME = 12,

			/// <summary>
			/// This causes DsCrackNames to return the distinguished names of all naming contexts in the current forest. The formatDesired parameter is ignored.
			/// cNames must be at least one and all strings in rpNames must have a length greater than zero characters. The contents of the rpNames strings is ignored.
			/// </summary>
			DS_LIST_NCS = unchecked((int)0xfffffff6)
		}

		/// <summary>
		/// The DsBind function binds to a domain controller.DsBind uses the default process credentials to bind to the domain controller. To specify alternate
		/// credentials, use the DsBindWithCred function.
		/// </summary>
		/// <remarks>
		/// The behavior of the DsBind function is determined by the contents of the DomainControllerName and DnsDomainName parameters. The following list
		/// describes the behavior of this function based on the contents of these parameters.
		/// <list type="table">
		/// <listheader><description>DomainControllerName</description><description>DnsDomainName</description><description>Description</description></listheader>
		/// <item><description><c>NULL</c></description><description><c>NULL</c></description><description>DsBind will attempt to bind to a global catalog server in the forest of the local computer.</description></item>
		/// <item><description>(value)</description><description><c>NULL</c></description><description>DsBind will attempt to bind to the domain controller specified by the DomainControllerName parameter.</description></item>
		/// <item><description><c>NULL</c></description><description>(value)</description><description>DsBind will attempt to bind to any domain controller in the domain specified by DnsDomainName parameter.</description></item>
		/// <item><description>(value)</description><description>(value)</description><description>The DomainControllerName parameter takes precedence. DsBind will attempt to bind to the domain controller specified by the DomainControllerName parameter.</description></item>
		/// </list>
		/// </remarks>
		/// <param name="DomainControllerName">
		/// Pointer to a null-terminated string that contains the name of the domain controller to bind to. This name can be the name of the domain controller or
		/// the fully qualified DNS name of the domain controller. Either name type can, optionally, be preceded by two backslash characters. All of the
		/// following examples represent correctly formatted domain controller names:
		/// <list type="bullet">
		/// <item><definition>"FAB-DC-01"</definition></item>
		/// <item><definition>"\\FAB-DC-01"</definition></item>
		/// <item><definition>"FAB-DC-01.fabrikam.com"</definition></item>
		/// <item><definition>"\\FAB-DC-01.fabrikam.com"</definition></item>
		/// </list>
		/// <para>This parameter can be NULL. For more information, see Remarks.</para>
		/// </param>
		/// <param name="DnsDomainName">
		/// Pointer to a null-terminated string that contains the fully qualified DNS name of the domain to bind to. This parameter can be NULL. For more
		/// information, see Remarks.
		/// </param>
		/// <param name="phDS">Address of a HANDLE value that receives the binding handle. To close this handle, pass it to the DsUnBind function.</param>
		/// <returns>Returns ERROR_SUCCESS if successful or a Windows or RPC error code otherwise.</returns>
		[DllImport(Lib.NTDSApi, CharSet = CharSet.Auto, SetLastError = true)]
		[PInvokeData("Ntdsapi.h", MSDNShortId = "ms675931")]
		public static extern uint DsBind(string DomainControllerName, string DnsDomainName, out IntPtr phDS);

		/// <summary>The DsBindWithCred function binds to a domain controller using the specified credentials.</summary>
		/// <param name="DomainControllerName">
		/// Pointer to a null-terminated string that contains the name of the domain controller to bind to. This name can be the name of the domain controller or
		/// the fully qualified DNS name of the domain controller. Either name type can, optionally, be preceded by two backslash characters. All of the
		/// following examples represent correctly formatted domain controller names:
		/// <list type="bullet">
		/// <item><definition>"FAB-DC-01"</definition></item>
		/// <item><definition>"\\FAB-DC-01"</definition></item>
		/// <item><definition>"FAB-DC-01.fabrikam.com"</definition></item>
		/// <item><definition>"\\FAB-DC-01.fabrikam.com"</definition></item>
		/// </list>
		/// <para>This parameter can be NULL. For more information, see Remarks.</para>
		/// </param>
		/// <param name="DnsDomainName">
		/// Pointer to a null-terminated string that contains the fully qualified DNS name of the domain to bind to. This parameter can be NULL. For more
		/// information, see Remarks.
		/// </param>
		/// <param name="AuthIdentity">
		/// Contains an RPC_AUTH_IDENTITY_HANDLE value that represents the credentials to be used for the bind. The DsMakePasswordCredentials function is used to
		/// obtain this value. If this parameter is NULL, the credentials of the calling thread are used.
		/// <para>DsUnBind must be called before freeing this handle with the DsFreePasswordCredentials function.</para>
		/// </param>
		/// <param name="phDS">Address of a HANDLE value that receives the binding handle. To close this handle, pass it to the DsUnBind function.</param>
		/// <returns>Returns ERROR_SUCCESS if successful or a Windows or RPC error code otherwise.</returns>
		[DllImport(Lib.NTDSApi, CharSet = CharSet.Auto, SetLastError = true)]
		[PInvokeData("Ntdsapi.h", MSDNShortId = "ms675961")]
		public static extern uint DsBindWithCred(
			string DomainControllerName, // in, optional
			string DnsDomainName, // in, optional
			SafeDsPasswordCredentialsHandle AuthIdentity, // in, optional
			out IntPtr phDS);

		/// <summary>
		/// The DsCrackNames function converts an array of directory service object names from one format to another. Name conversion enables client applications
		/// to map between the multiple names used to identify various directory service objects. For example, user objects can be identified by SAM account
		/// names (Domain\UserName), user principal name (UserName@Domain.com), or distinguished name.
		/// <note type="note">This function uses many handles and memory allocations that can be unwieldy. It is recommended to use the 
		/// <see cref="DsCrackNames(SafeDsHandle, string[], DS_NAME_FORMAT, DS_NAME_FORMAT, DS_NAME_FLAGS)"/> method instead.</note>
		/// </summary>
		/// <param name="hSafeDs">
		/// Contains a directory service handle obtained from either the DSBind or DSBindWithCred function. If flags contains DS_NAME_FLAG_SYNTACTICAL_ONLY, hDS
		/// can be NULL.
		/// </param>
		/// <param name="flags">Contains one or more of the DS_NAME_FLAGS values used to determine how the name syntax will be cracked.</param>
		/// <param name="formatOffered">Contains one of the DS_NAME_FORMAT values that identifies the format of the input names.</param>
		/// <param name="formatDesired">
		/// Contains one of the DS_NAME_FORMAT values that identifies the format of the output names. The DS_SID_OR_SID_HISTORY_NAME value is not supported.
		/// </param>
		/// <param name="cNames">Contains the number of elements in the rpNames array.</param>
		/// <param name="rpNames">Pointer to an array of pointers to null-terminated strings that contain names to be converted.</param>
		/// <param name="ppResult">
		/// Pointer to a PDS_NAME_RESULT value that receives a DS_NAME_RESULT structure that contains the converted names. The caller must free this memory, when
		/// it is no longer required, by calling DsFreeNameResult.
		/// </param>
		/// <returns>Returns a Win32 error value, an RPC error value, or one of the following.</returns>
		[DllImport(Lib.NTDSApi, CharSet = CharSet.Auto, SetLastError = true)]
		[PInvokeData("Ntdsapi.h", MSDNShortId = "ms675970")]
		public static extern uint DsCrackNames(
			SafeDsHandle hSafeDs,
			DS_NAME_FLAGS flags,
			DS_NAME_FORMAT formatOffered,
			DS_NAME_FORMAT formatDesired,
			uint cNames,
			[MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPTStr, SizeParamIndex = 4)] string[] rpNames,
			out SafeDsNameResult ppResult);

		/// <summary>A wrapper function for the DsCrackNames OS call</summary>
		/// <param name="hSafeDs">
		/// Contains a directory service handle obtained from either the DSBind or DSBindWithCred function. If flags contains DS_NAME_FLAG_SYNTACTICAL_ONLY, hDS
		/// can be NULL.
		/// </param>
		/// <param name="names">The names to be converted.</param>
		/// <param name="formatDesired">
		/// Contains one of the DS_NAME_FORMAT values that identifies the format of the output names. The DS_SID_OR_SID_HISTORY_NAME value is not supported.
		/// </param>
		/// <param name="formatOffered">Contains one of the DS_NAME_FORMAT values that identifies the format of the input names.</param>
		/// <param name="flags">Contains one or m ore of the DS_NAME_FLAGS values used to determine how the name syntax will be cracked.</param>
		/// <returns>The crack results.</returns>
		[PInvokeData("Ntdsapi.h", MSDNShortId = "ms675970")]
		public static DS_NAME_RESULT_ITEM[] DsCrackNames(SafeDsHandle hSafeDs, string[] names,
			DS_NAME_FORMAT formatDesired = DS_NAME_FORMAT.DS_USER_PRINCIPAL_NAME,
			DS_NAME_FORMAT formatOffered = DS_NAME_FORMAT.DS_UNKNOWN_NAME,
			DS_NAME_FLAGS flags = DS_NAME_FLAGS.DS_NAME_NO_FLAGS)
		{
			var err = DsCrackNames(hSafeDs, flags, formatOffered, formatDesired, (uint)(names?.Length ?? 0), names, out SafeDsNameResult pResult);
			new Win32Error((int)err).ThrowIfFailed();
			return pResult.Items;
		}

		/// <summary>
		/// The DsFreeNameResult function frees the memory held by a DS_NAME_RESULT structure. Use this function to free the memory allocated by the DsCrackNames function.
		/// </summary>
		/// <param name="pResult">Pointer to the DS_NAME_RESULT structure to be freed.</param>
		[DllImport(Lib.NTDSApi, CharSet = CharSet.Auto)]
		[PInvokeData("Ntdsapi.h", MSDNShortId = "ms675978")]
		public static extern void DsFreeNameResult(IntPtr pResult /* DS_NAME_RESULT* */);

		/// <summary>Frees memory allocated for a credentials structure by the DsMakePasswordCredentials function.</summary>
		/// <param name="AuthIdentity">Handle of the credential structure to be freed.</param>
		[DllImport(Lib.NTDSApi, ExactSpelling = true)]
		[PInvokeData("Ntdsapi.h", MSDNShortId = "ms675979")]
		public static extern void DsFreePasswordCredentials(IntPtr AuthIdentity);

		/// <summary>Constructs a credential handle suitable for use with the DsBindWithCred function.</summary>
		/// <remarks>
		/// A null, default credential handle is created if User, Domain and Password are all NULL. Otherwise, User must be present. The Domain parameter may be
		/// NULL when User is fully qualified, such as a user in UPN format; for example, "someone@fabrikam.com".
		/// <para>When the handle returned in pAuthIdentity is passed to DsBindWithCred, DsUnBind must be called before freeing the handle with DsFreePasswordCredentials.</para>
		/// </remarks>
		/// <param name="User">A string that contains the user name to use for the credentials.</param>
		/// <param name="Domain">A string that contains the domain that the user is a member of.</param>
		/// <param name="Password">A string that contains the password to use for the credentials.</param>
		/// <param name="pAuthIdentity">
		/// An RPC_AUTH_IDENTITY_HANDLE value that receives the credential handle. This handle is used in a subsequent call to DsBindWithCred. This handle must
		/// be freed with the DsFreePasswordCredentials function when it is no longer required.
		/// </param>
		/// <returns>Returns a Windows error code.</returns>
		[DllImport(Lib.NTDSApi, CharSet = CharSet.Auto)]
		[PInvokeData("Ntdsapi.h", MSDNShortId = "ms676006")]
		public static extern Win32Error DsMakePasswordCredentials(string User, string Domain, string Password, out IntPtr pAuthIdentity);

		/// <summary>The DsUnBind function finds an RPC session with a domain controller and unbinds a handle to the directory service (DS).</summary>
		/// <param name="phDS">Pointer to a bind handle to the directory service. This handle is provided by a call to DsBind, DsBindWithCred, or DsBindWithSpn.</param>
		/// <returns>0</returns>
		[DllImport(Lib.NTDSApi, CharSet = CharSet.Auto, SetLastError = true)]
		[PInvokeData("Ntdsapi.h", MSDNShortId = "ms676053")]
		public static extern uint DsUnBind(ref IntPtr phDS);

		/// <summary>Used with the DsCrackNames function to contain the names converted by the function.</summary>
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		[PInvokeData("Ntdsapi.h", MSDNShortId = "ms676246")]
		public struct DS_NAME_RESULT
		{
			/// <summary>Contains the number of elements in the rItems array.</summary>
			public uint cItems;

			/// <summary>Contains an array of DS_NAME_RESULT_ITEM structure pointers. Each element of this array represents a single converted name.</summary>
			public IntPtr rItems; // PDS_NAME_RESULT_ITEM

			/// <summary>Enumeration of DS_NAME_RESULT_ITEM structures. Each element of this array represents a single converted name.</summary>
			public DS_NAME_RESULT_ITEM[] Items => rItems.ToArray<DS_NAME_RESULT_ITEM>((int)cItems);
		}

		/// <summary>Contains a name converted by the DsCrackNames function, along with associated error and domain data.</summary>
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		[PInvokeData("Ntdsapi.h", MSDNShortId = "ms676246")]
		public struct DS_NAME_RESULT_ITEM
		{
			/// <summary>Contains one of the DS_NAME_ERROR values that indicates the status of this name conversion.</summary>
			public DS_NAME_ERROR status;

			/// <summary>
			/// A string that specifies the DNS domain in which the object resides. This member will contain valid data if status contains DS_NAME_NO_ERROR or DS_NAME_ERROR_DOMAIN_ONLY.
			/// </summary>
			public string pDomain;

			/// <summary>A string that specifies the newly formatted object name.</summary>
			public string pName;

			/// <summary>Returns a <see cref="string"/> that represents this instance.</summary>
			/// <returns>A <see cref="string"/> that represents this instance.</returns>
			public override string ToString() => status == DS_NAME_ERROR.DS_NAME_NO_ERROR ? pName : $"{status}";
		}

		/// <summary>
		/// A <see cref="SafeHandle"/> for the results from <see cref="DsCrackNames(SafeDsHandle,DS_NAME_FLAGS,DS_NAME_FORMAT,DS_NAME_FORMAT,uint,string[],out SafeDsNameResult)"/>.
		/// </summary>
		/// <seealso cref="GenericSafeHandle"/>
		[PInvokeData("Ntdsapi.h")]
		public class SafeDsNameResult : GenericSafeHandle
		{
			/// <summary>Initializes a new instance of the <see cref="SafeDsNameResult"/> class.</summary>
			public SafeDsNameResult() : base(h => { DsFreeNameResult(h); return true; }) { }

			/// <summary>An array of DS_NAME_RESULT_ITEM structures. Each element of this array represents a single converted name.</summary>
			public DS_NAME_RESULT_ITEM[] Items => IsInvalid ? new DS_NAME_RESULT_ITEM[0] : handle.ToStructure<DS_NAME_RESULT>().Items;
		}

		/// <summary>A <see cref="SafeHandle"/> for handles bound to directory services.</summary>
		/// <seealso cref="Microsoft.Win32.SafeHandles.SafeHandleZeroOrMinusOneIsInvalid"/>
		[SuppressUnmanagedCodeSecurity, ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[PInvokeData("Ntdsapi.h")]
		public class SafeDsHandle : GenericSafeHandle
		{
			/// <summary>Initializes a new instance of the <see cref="SafeDsHandle"/> class.</summary>
			public SafeDsHandle() : this(null, null) { }

			/// <summary>Initializes a new instance of the <see cref="SafeDsHandle"/> class from an existing bound handle.</summary>
			/// <param name="hDs">
			/// A handle retrieved from a call to <see cref="DsBind(string, string, out IntPtr)"/> or <see cref="DsBindWithCred(string, string, SafeDsPasswordCredentialsHandle, out IntPtr)"/>.
			/// </param>
			public SafeDsHandle(IntPtr hDs) : base(hDs, Release) { }

			/// <summary>Initializes a new instance of the <see cref="SafeDsHandle"/> class bound to a domain and/or DC.</summary>
			/// <remarks>
			/// The behavior of the constructor is determined by the contents of the domainControllerName and dnsDomainName parameters. The following list
			/// describes the behavior of this constructor based on the contents of these parameters.
			/// <list type="table">
			/// <listheader><description>domainControllerName</description><description>dnsDomainName</description><description>Description</description></listheader>
			/// <item><description><c>NULL</c></description><description><c>NULL</c></description><description>Will attempt to bind to a global catalog server in the forest of the local computer.</description></item>
			/// <item><description>(value)</description><description><c>NULL</c></description><description>Will attempt to bind to the domain controller specified by the domainControllerName parameter.</description></item>
			/// <item><description><c>NULL</c></description><description>(value)</description><description>Will attempt to bind to any domain controller in the domain specified by dnsDomainName parameter.</description></item>
			/// <item><description>(value)</description><description>(value)</description><description>The domainControllerName parameter takes precedence. Will attempt to bind to the domain controller specified by the domainControllerName parameter.</description></item>
			/// </list>
			/// </remarks>
			/// <param name="dnsDomainName">
			/// A string that contains the fully qualified DNS name of the domain to bind to. This parameter can be NULL. For more information, see Remarks.
			/// </param>
			/// <param name="domainControllerName">
			/// A string that contains the name of the domain controller to bind to. This name can be the name of the domain controller or the fully qualified
			/// DNS name of the domain controller. Either name type can, optionally, be preceded by two backslash characters. All of the following examples
			/// represent correctly formatted domain controller names:
			/// <list type="bullet">
			/// <item><definition>"FAB-DC-01"</definition></item>
			/// <item><definition>"\\FAB-DC-01"</definition></item>
			/// <item><definition>"FAB-DC-01.fabrikam.com"</definition></item>
			/// <item><definition>"\\FAB-DC-01.fabrikam.com"</definition></item>
			/// </list>
			/// <para>This parameter can be NULL. For more information, see Remarks.</para>
			/// </param>
			public SafeDsHandle(string dnsDomainName, string domainControllerName) : base(Release)
			{
				var res = DsBind(domainControllerName, dnsDomainName, out handle);
				if (res != NO_ERROR)
					throw new Win32Exception((int)res);
			}

			/// <summary>Initializes a new instance of the <see cref="SafeDsHandle"/> class from a user credential and then bound to a domain and/or DC.</summary>
			/// <remarks>
			/// The behavior of the constructor is determined by the contents of the domainControllerName and dnsDomainName parameters. The following list
			/// describes the behavior of this constructor based on the contents of these parameters.
			/// <list type="table">
			/// <listheader><description>domainControllerName</description><description>dnsDomainName</description><description>Description</description></listheader>
			/// <item><description><c>NULL</c></description><description><c>NULL</c></description><description>Will attempt to bind to a global catalog server in the forest of the local computer.</description></item>
			/// <item><description>(value)</description><description><c>NULL</c></description><description>Will attempt to bind to the domain controller specified by the domainControllerName parameter.</description></item>
			/// <item><description><c>NULL</c></description><description>(value)</description><description>Will attempt to bind to any domain controller in the domain specified by dnsDomainName parameter.</description></item>
			/// <item><description>(value)</description><description>(value)</description><description>The domainControllerName parameter takes precedence. Will attempt to bind to the domain controller specified by the domainControllerName parameter.</description></item>
			/// </list>
			/// </remarks>
			/// <param name="authIdentity">
			/// Contains an <see cref="SafeDsPasswordCredentialsHandle"/> value that represents the credentials to be used for the bind.
			/// </param>
			/// <param name="dnsDomainName">
			/// A string that contains the fully qualified DNS name of the domain to bind to. This parameter can be NULL. For more information, see Remarks.
			/// </param>
			/// <param name="domainControllerName">
			/// A string that contains the name of the domain controller to bind to. This name can be the name of the domain controller or the fully qualified
			/// DNS name of the domain controller. Either name type can, optionally, be preceded by two backslash characters. All of the following examples
			/// represent correctly formatted domain controller names:
			/// <list type="bullet">
			/// <item><definition>"FAB-DC-01"</definition></item>
			/// <item><definition>"\\FAB-DC-01"</definition></item>
			/// <item><definition>"FAB-DC-01.fabrikam.com"</definition></item>
			/// <item><definition>"\\FAB-DC-01.fabrikam.com"</definition></item>
			/// </list>
			/// <para>This parameter can be NULL. For more information, see Remarks.</para>
			/// </param>
			public SafeDsHandle(SafeDsPasswordCredentialsHandle authIdentity, string dnsDomainName, string domainControllerName) : base(Release)
			{
				var res = DsBindWithCred(domainControllerName, dnsDomainName, authIdentity, out handle);
				if (res != NO_ERROR)
					new Win32Error((int)res).ThrowIfFailed();
			}

			/// <summary>Gets a <c>NULL</c> equivalent for a bound directory services handle.</summary>
			public static SafeDsHandle Null { get; } = new SafeDsHandle(IntPtr.Zero);

			/// <summary>When overridden in a derived class, executes the code required to free the handle.</summary>
			/// <returns>
			/// true if the handle is released successfully; otherwise, in the event of a catastrophic failure, false. In this case, it generates a
			/// releaseHandleFailed MDA Managed Debugging Assistant.
			/// </returns>
			private static bool Release(IntPtr handle) => DsUnBind(ref handle) == 0;
		}

		/// <summary>
		/// Constructs a <see cref="SafeHandle"/> that encapsulates the value retrieved from <see cref="DsMakePasswordCredentials(string, string, string, out IntPtr)"/>.
		/// </summary>
		/// <seealso cref="Microsoft.Win32.SafeHandles.SafeHandleMinusOneIsInvalid"/>
		[PInvokeData("Ntdsapi.h")]
		public class SafeDsPasswordCredentialsHandle : SafeHandleMinusOneIsInvalid
		{
			/// <summary>Initializes a new instance of the <see cref="SafeDsPasswordCredentialsHandle"/> class from user credentials.</summary>
			/// <param name="user">String that contains the user name to use for the credentials.</param>
			/// <param name="domain">String that contains the domain that the user is a member of.</param>
			/// <param name="password">String that contains the password to use for the credentials.</param>
			public SafeDsPasswordCredentialsHandle(string user, string domain, string password) : base(true)
			{
				if (user == null && domain == null && password == null ||
				    domain == null && user != null && user.Contains("@") && password != null ||
				    user != null && domain != null & password != null)
				{
					var r = DsMakePasswordCredentials(user, domain, password, out handle);
					r.ThrowIfFailed();
				}
				else
					throw new ArgumentException(@"Invalid parameters.");
			}

			/// <summary>Initializes a new instance of the <see cref="SafeDsPasswordCredentialsHandle"/> class from user credentials.</summary>
			/// <param name="user">
			/// String that contains a fully qualified user name to use for the credentials, such as a user in UPN format; for example, "someone@fabrikam.com".
			/// </param>
			/// <param name="password">String that contains the password to use for the credentials.</param>
			public SafeDsPasswordCredentialsHandle(string user = null, string password = null) : this(user, null, password)
			{
			}

			/// <summary>When overridden in a derived class, executes the code required to free the handle.</summary>
			/// <returns>
			/// true if the handle is released successfully; otherwise, in the event of a catastrophic failure, false. In this case, it generates a
			/// releaseHandleFailed MDA Managed Debugging Assistant.
			/// </returns>
			protected override bool ReleaseHandle() { DsFreePasswordCredentials(handle); return true; }
		}
	}
}