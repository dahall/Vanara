namespace Vanara.PInvoke;

/// <summary>Items from the WsmSvc.dll</summary>
public static partial class WsmSvc
{
	/// <summary>
	/// <para>
	/// The <c>__WSManEnumFlags</c> enumeration contains constants, as listed in the following list, used in the flags parameter by
	/// calls to <c>IWSManSession::Enumerate</c>.
	/// </para>
	/// <para>
	/// Be aware that <c>WSManFlagReturnObject</c> and <c>WSManFlagHierarchyDeep</c> are the default if the flags parameter is not specified.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/winrm/enumeration-constants
	[PInvokeData("wsmandisp.h")]
	[Flags]
	public enum WSManEnumFlags
	{
		/// <summary>
		/// <para>This flag controls how the filter parameter in the call to Session.Enumerate is interpreted by WinRM.</para>
		/// <para>
		/// The format of the filter may be an XML fragment or a string of plain text. The format is determined by the filter dialect of
		/// the filter used in the call to Session.Enumerate or IWSManSession::Enumerate, which is specific to the operation performed.
		/// </para>
		/// <para>
		/// If the dialect parameter is not specified, WinRM attempts to determine the dialect based on the first character of the
		/// filter. If the first character is &lt;, but the filter is not actually an XML fragment, then this flag should be set. For
		/// example, a filter in the following format requires that you set WSManFlagNonXmlText so that the filter is correctly interpreted:
		/// </para>
		/// <code>&lt;25 &amp;&amp; &gt; 1</code>
		/// <para>
		/// If the filter is an XML fragment, then this flag is not required because the fragment starts with &lt;, which WinRM
		/// correctly interprets as XML. For example,
		/// </para>
		/// <code>&lt;filter&gt;select * from aDataStructure&lt;/filter&gt;</code>
		/// <para>If the filter is in plain text that does not start with &lt;, then this flag is not required. For example,</para>
		/// <code>select * from aDataStructure</code>
		/// </summary>
		WSManFlagNonXmlText = 0x00000001,

		/// <summary>Batches contain the requested XML instances. This is the default value for the flag parameter.</summary>
		WSManFlagReturnObject = 0x00000000,

		/// <summary>Batches contain endpoint references (EPRs) for the corresponding XML instances, but not the actual instances.</summary>
		WSManFlagReturnEPR = 0x00000002,

		/// <summary>Batches contain both the requested XML instances and the corresponding EPRs contained in a wsman:Items element.</summary>
		WSManFlagReturnObjectAndEPR = 0x00000004,

		/// <summary>Derived class instances are included and are represented according to their actual schemas.</summary>
		WSManFlagHierarchyDeep = 0x00000000,

		/// <summary>Derived class instances are excluded. Only instances of the requested type are shown.</summary>
		WSManFlagHierarchyShallow = 0x00000020,

		/// <summary>
		/// Derived class instances are included and are represented according to the base class schema. Properties defined in the
		/// derived class are not shown.
		/// </summary>
		WSManFlagHierarchyDeepBasePropsOnly = 0x00000040,

		/// <summary/>
		WSManFlagAssociatedInstance = 0x00000000,

		/// <summary/>
		WSManFlagAssociationInstance = 0x00000080
	}

	/// <summary>Defines the proxy access type flags.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/ne-wsmandisp-wsmanproxyaccesstypeflags typedef enum
	// _WSManProxyAccessTypeFlags { WSManProxyIEConfig, WSManProxyWinHttpConfig, WSManProxyAutoDetect, WSManProxyNoProxyServer } WSManProxyAccessTypeFlags;
	[PInvokeData("wsmandisp.h", MSDNShortId = "NE:wsmandisp._WSManProxyAccessTypeFlags")]
	[Flags]
	public enum WSManProxyAccessTypeFlags
	{
		/// <summary>Use the Internet Explorer proxy configuration for the current user.</summary>
		WSManProxyIEConfig = 0x01,

		/// <summary>Use the proxy settings configured for WinHTTP. This is the default setting.</summary>
		WSManProxyWinHttpConfig = 0x02,

		/// <summary>Force autodetection of a proxy.</summary>
		WSManProxyAutoDetect = 0x04,

		/// <summary>Do not use a proxy server. All host names are resolved locally.</summary>
		WSManProxyNoProxyServer = 0x08,
	}

	/// <summary>Determines the proxy authentication mechanism.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/ne-wsmandisp-wsmanproxyauthenticationflags typedef enum
	// _WSManProxyAuthenticationFlags { WSManFlagProxyAuthenticationUseNegotiate, WSManFlagProxyAuthenticationUseBasic,
	// WSManFlagProxyAuthenticationUseDigest } WSManProxyAuthenticationFlags;
	[PInvokeData("wsmandisp.h", MSDNShortId = "NE:wsmandisp._WSManProxyAuthenticationFlags")]
	[Flags]
	public enum WSManProxyAuthenticationFlags
	{
		/// <summary>
		/// Use Negotiate authentication. The client sends a request to the server to authenticate. The server determines whether to use
		/// Kerberos or NTLM. In general, Kerberos is selected to authenticate a domain account and NTLM is selected for local computer
		/// accounts. But there are also some special cases in which Kerberos/NTLM are selected. The user name should be specified in
		/// the form DOMAIN\username for a domain user or SERVERNAME\username for a local user on a server computer.
		/// </summary>
		WSManFlagProxyAuthenticationUseNegotiate = 0x01,

		/// <summary>
		/// Use Basic authentication. The client presents credentials in the form of a user name and password that are directly
		/// transmitted in the request message.
		/// </summary>
		WSManFlagProxyAuthenticationUseBasic = 0x02,

		/// <summary>
		/// Use Digest authentication. Only the client computer can initiate a Digest authentication request. The client sends a request
		/// to the server to authenticate and receives from the server a token string. The client then sends the resource request,
		/// including the user name and a cryptographic hash of the password combined with the token string. Digest authentication is
		/// supported for HTTP and HTTPS.
		/// </summary>
		WSManFlagProxyAuthenticationUseDigest = 0x04,
	}

	/// <summary>Constants that specify encoding, encryption, and service principal name port.</summary>
	[PInvokeData("wsmandisp.h")]
	[Flags]
	public enum WSManSessionFlags : int
	{
		/// <summary>Sends the request in UTF8 rather than UTF16.</summary>
		WSManFlagUTF8 = 1,

		/// <summary>
		/// Use the user name and password as the credentials. Set this flag when you create a ConnectionOptions object and supply
		/// Username and Password. The credentials can be a domain account or an account on the local computer. By default, the account
		/// must be a member of the local Administrators group on the local or remote computer. However, the WinRM service can be
		/// configured to allow other users. For more information, see Installation and Configuration for Windows Remote Management. You
		/// can set this flag when you specify credentials for Negotiate authentication (also known as Windows Integrated
		/// Authentication) or for Basic authentication.
		/// </summary>
		WSManFlagCredUsernamePassword = 0x1000,

		/// <summary>
		/// When connecting over HTTPS, the client does not validate that the server certificate is signed by a trusted certification
		/// authority (CA). Use this value only when the remote computer is trusted by other means, for example, if the remote computer
		/// is part of a network that is physically secure and isolated or the remote computer is listed as a trusted host in the WinRM configuration.
		/// </summary>
		WSManFlagSkipCACheck = 0x2000,

		/// <summary>
		/// When connecting over HTTPS, the client will not validate that the common name (CN) in the server certificate matches the
		/// computer name in the connection string. Use only when the remote computer is trusted by other means, for example, if the
		/// remote computer is part of a network that is physically secure and isolated or the remote computer is listed as a trusted
		/// host in the WinRM configuration.
		/// </summary>
		WSManFlagSkipCNCheck = 0x4000,

		/// <summary>
		/// Use no authentication. Specify this constant when testing a connection to a remote computer to determine if a service that
		/// implements the WS-Management protocol is configured to listen for data requests. WSManFlagUseNoAuthentication cannot be
		/// combined with any other Session constant.
		/// </summary>
		WSManFlagUseNoAuthentication = 0x8000,

		/// <summary>
		/// Use Digest authentication. Only the client computer can initiate a Digest authentication request. The client sends a request
		/// to the server to authenticate and receives a token string from the server. The client then sends the resource request,
		/// including the user name and a cryptographic hash of the password combined with the token string. Digest authentication is
		/// supported for HTTP and HTTPS. WinRM client scripts and applications can specify Digest authentication, but not the service.
		/// </summary>
		WSManFlagUseDigest = 0x10000,

		/// <summary>
		/// Use Negotiate authentication. The client sends a request to the server to authenticate. The server determines whether to use
		/// Kerberos or NTLM. Kerberos is selected to authenticate a domain account and NTLM is selected for local computer accounts.
		/// The user name should be specified in the form domain\username for a domain user or servername\username for a local user on a
		/// server computer.
		/// <para>
		/// User Account Control (UAC) affects access to the WinRM service.When Negotiate authentication is used in a workgroup or
		/// domain, only the built-in Administrator account can access the service.To allow all accounts in the Administrators group to
		/// access the service, set the following registry key to 1: HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\system\LocalAccountTokenFilterPolicy.
		/// </para>
		/// </summary>
		WSManFlagUseNegotiate = 0x20000,

		/// <summary>
		/// Use Basic authentication. The client presents credentials in the form of a user name and password, directly transmitted in
		/// the request message. You can specify only credentials that identify a local administrator account on the remote computer.
		/// </summary>
		WSManFlagUseBasic = 0x40000,

		/// <summary>Use Kerberos authentication. The client and server mutually authenticate using Kerberos tickets.</summary>
		WSManFlagUseKerberos = 0x80000,

		/// <summary>
		/// Do not encrypt the messages sent over the network. This setting is allowed only if the listener is configured so that
		/// AllowUnencrypted is set to True.
		/// </summary>
		WSManFlagNoEncryption = 0x100000,

		/// <summary>Use client certificate-based authentication.</summary>
		WSManFlagUseClientCertificate = 0x200000,

		/// <summary>
		/// Specify the Service Principal Name (SPN) port when connecting directly to remote BMC hardware, also known as an out-of-band
		/// connection. Because both the WinRM server computer and the BMC hardware can share the same IP address, this flag indicates
		/// that the SPN port number must be used to determine whether the connection is to the service or directly to the BMC. For more
		/// information, see Name Formats for Unique SPNs.
		/// </summary>
		WSManFlagEnableSPNServerPort = 0x400000,

		/// <summary>Sends the request in UTF16.</summary>
		WSManFlagUTF16 = 0x800000,

		/// <summary>Use Credential Security Support Provider (CredSSP) authentication.</summary>
		WSManFlagUseCredSsp = 0x1000000,

		/// <summary>Do not check for certificate revocation during authentication.</summary>
		WSManFlagSkipRevocationCheck = 0x2000000,

		/// <summary>Allow implicit credentials.</summary>
		WSManFlagAllowNegotiateImplicitCredentials = 0x4000000,

		/// <summary>Use Secure Socket Layer, enables HTTPS.</summary>
		WSManFlagUseSsl = 0x8000000
	}

	/// <summary>
	/// Provides methods and properties used to create a session, represented by a Session object. Any Windows Remote Management
	/// operations require creation of a Session that connects to a remote computer, base management controller (BMC), or the local
	/// computer. Operations include getting, writing, or enumerating data, or invoking methods.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nn-wsmandisp-iwsman
	[PInvokeData("wsmandisp.h", MSDNShortId = "NN:wsmandisp.IWSMan")]
	[ComImport, Guid("190D8637-5CD3-496d-AD24-69636BB5A3B5"), InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[CoClass(typeof(WSMan))]
	public interface IWSMan
	{
		/// <summary>Creates a Session object that can then be used for subsequent network operations.</summary>
		/// <param name="connection">
		/// The protocol and service to connect to, including either IPv4 or IPv6. The format of the connection information is as
		/// follows: &lt;Transport&gt;&lt;Address&gt;&lt;Suffix&gt;. For examples, see Remarks. If no connection information is
		/// provided, the local computer is used.
		/// </param>
		/// <param name="flags">
		/// <para>
		/// The session flags that specify the authentication method, such as Negotiate authentication or Digest authentication, for
		/// connecting to a remote computer. These flags also specify other session connection information, such as encoding or
		/// encryption. This parameter must contain one or more of the flags in <c>__WSManSessionFlags</c> for a remote connection. For
		/// more information, see Session Constants. No flag settings are required for a connection to the WinRM service on the local computer.
		/// </para>
		/// <para>
		/// If no authentication flags are specified, Kerberos is used unless one of the following conditions is true, in which case
		/// Negotiate is used:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>explicit credentials are supplied and the destination host is trusted</term>
		/// </item>
		/// <item>
		/// <term>the destination host is "localhost", "127.0.0.1" or "[::1]"</term>
		/// </item>
		/// <item>
		/// <term>the client computer is in a workgroup and the destination host is trusted</term>
		/// </item>
		/// </list>
		/// <para>For more information, see</para>
		/// <para>Authentication for Remote Connections</para>
		/// <para>and the</para>
		/// <para>connectionOptions</para>
		/// <para>parameter.</para>
		/// </param>
		/// <param name="connectionOptions">
		/// A pointer to an IWSManConnectionOptions object that contains a user name and password. The default is <c>NULL</c>.
		/// </param>
		/// <param name="session">A pointer to a new IWSManSession object.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// <para>
		/// The following list contains examples of formats used to specify connection information in the connection parameter (when
		/// creating an HTTPS session, the &lt;Address&gt; field must match the server computer certificate name, otherwise a failure occurs):
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>"https://service"
		/// <para>Uses HTTPS to connect to the default web service location.</para>
		/// </term>
		/// </item>
		/// <item>
		/// <term>"https://service.corp.com/websvcs/wsman"
		/// <para>Uses HTTPS to connect to the specific web service location.</para>
		/// </term>
		/// </item>
		/// <item>
		/// <term>"https://[E3D7:0000:0000:0000:51F4:9BC8:C0A8:6420]"
		/// <para>Uses HTTPS and IPv6 with the default port.</para>
		/// </term>
		/// </item>
		/// <item>
		/// <term>"https://[E3D7:0000:0000:0000:51F4:9BC8:C0A8:6420]:9999/wsman"
		/// <para>Uses HTTPS and IPv6 with the given port.</para>
		/// </term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsman-createsession HRESULT CreateSession( BSTR
		// connection, long flags, IDispatch *connectionOptions, IDispatch **session );
		[PreserveSig, DispId(1)]
		HRESULT CreateSession([MarshalAs(UnmanagedType.BStr)] string connection, [Optional] WSManSessionFlags flags,
			IWSManConnectionOptions connectionOptions, out IWSManSession session);

		/// <summary>Creates an IWSManConnectionOptions object that specifies the user name and password used when creating a session.</summary>
		/// <param name="connectionOptions">A pointer to a new IWSManConnectionOptions object.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsman-createconnectionoptions HRESULT
		// CreateConnectionOptions( IDispatch **connectionOptions );
		[PreserveSig, DispId(2)]
		HRESULT CreateConnectionOptions(out IWSManConnectionOptions connectionOptions);

		/// <summary>
		/// <para>Gets the command line of the process that loads the automation component.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/winrm/wsman-commandline WSMan.CommandLine As BSTR
		[DispId(3)]
		string CommandLine
		{
			[DispId(3)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>
		/// Gets additional error information, in an XML stream, for the preceding call to an IWSMan method if Windows Remote Management
		/// service was unable to create an IWSManSession object, an IWSManConnectionOptions object, or an IWSManResourceLocator object.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsman-get_error HRESULT get_Error( BSTR *value );
		[DispId(4)]
		string Error
		{
			[DispId(4)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}
	}

	/// <summary>
	/// The <c>IWSManConnectionOptions</c> object is passed to the IWSMan::CreateSession method to provide the user name and password
	/// associated with the local account on the remote computer. If no parameters are supplied, then the credentials of the account
	/// running the script are the default values.
	/// </summary>
	/// <remarks>
	/// If a Windows Remote Management client application is running under impersonation, then a failure occurs if you set the Password
	/// property. A client application is a script or other program that sends a request to WinRM on the local or a remote computer. The
	/// client application may be running under impersonation because it called a function like ImpersonateClient. An Active Server Page
	/// (ASP) or service cannot request a user name and password if the ASP process runs under an account that impersonates a client.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nn-wsmandisp-iwsmanconnectionoptions
	[PInvokeData("wsmandisp.h", MSDNShortId = "NN:wsmandisp.IWSManConnectionOptions")]
	[ComImport, Guid("F704E861-9E52-464f-B786-DA5EB2320FDD"), InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface IWSManConnectionOptions
	{
		/// <summary>
		/// <para>
		/// Sets and gets the user name of a local or a domain account on the remote computer. This property determines the user name
		/// for authentication. If no value is supplied and the <c>WSManFlagCredUsernamePassword</c> flag is not set, then the user name
		/// of the account that is running the script is used.
		/// </para>
		/// <para>
		/// If the <c>WSManFlagCredUsernamePassword</c> flag is set but no user name is specified, the script prompts the user to enter
		/// the user name and password. If no user name and password are entered then an access denied error is returned. For more
		/// information, see Authentication for Remote Connections.
		/// </para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>
		/// You can supply UserName and Password for a domain account when using Negotiate or Kerberos authentication, or for a local
		/// account with Basic authentication. To connect to a local account, the WSMan.CreateSession flags must contain the combination
		/// of the <c>WSManFlagUseBasic</c> flag and the <c>WsmanFlagCredUserNamePassword</c> flag. To connect to a domain account, the
		/// <c>WSMan.CreateSession</c> flags must contain the combination of the <c>WSManFlagUseNegotiate</c> flag and the
		/// <c>WsmanFlagCredUserNamePassword</c> flag, or the combination of the <c>WSManFlagUseKerberos</c> flag and the
		/// <c>WsmanFlagCredUserNamePassword</c> flag. For a domain account, <c>UserName</c> must be specified in the form
		/// "computer\username", where the "computer" part of the string can be either the name or the IP address. For more information,
		/// see Authentication for Remote Connections.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanconnectionoptions-get_username HRESULT
		// get_UserName( BSTR *name );
		[DispId(1)]
		string UserName
		{
			[DispId(1)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;

			[DispId(1)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>
		/// Sets the password of a local or a domain account on the remote computer. For more information, see Authentication for Remote Connections.
		/// </para>
		/// <para>This property is write-only.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanconnectionoptions-put_password HRESULT
		// put_Password( BSTR password );
		[DispId(2)]
		string Password
		{
			[DispId(2)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}
	}

	/// <summary>
	/// The <c>IWSManConnectionOptionsEx</c> object is passed to the IWSMan::CreateSession method to provide the thumbprint of the
	/// client certificate used for authentication.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nn-wsmandisp-iwsmanconnectionoptionsex
	[PInvokeData("wsmandisp.h", MSDNShortId = "NN:wsmandisp.IWSManConnectionOptionsEx")]
	[ComImport, Guid("EF43EDF7-2A48-4d93-9526-8BD6AB6D4A6B"), InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface IWSManConnectionOptionsEx : IWSManConnectionOptions
	{
		/// <summary>
		/// <para>
		/// Sets and gets the user name of a local or a domain account on the remote computer. This property determines the user name
		/// for authentication. If no value is supplied and the <c>WSManFlagCredUsernamePassword</c> flag is not set, then the user name
		/// of the account that is running the script is used.
		/// </para>
		/// <para>
		/// If the <c>WSManFlagCredUsernamePassword</c> flag is set but no user name is specified, the script prompts the user to enter
		/// the user name and password. If no user name and password are entered then an access denied error is returned. For more
		/// information, see Authentication for Remote Connections.
		/// </para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>
		/// You can supply UserName and Password for a domain account when using Negotiate or Kerberos authentication, or for a local
		/// account with Basic authentication. To connect to a local account, the WSMan.CreateSession flags must contain the combination
		/// of the <c>WSManFlagUseBasic</c> flag and the <c>WsmanFlagCredUserNamePassword</c> flag. To connect to a domain account, the
		/// <c>WSMan.CreateSession</c> flags must contain the combination of the <c>WSManFlagUseNegotiate</c> flag and the
		/// <c>WsmanFlagCredUserNamePassword</c> flag, or the combination of the <c>WSManFlagUseKerberos</c> flag and the
		/// <c>WsmanFlagCredUserNamePassword</c> flag. For a domain account, <c>UserName</c> must be specified in the form
		/// "computer\username", where the "computer" part of the string can be either the name or the IP address. For more information,
		/// see Authentication for Remote Connections.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanconnectionoptions-get_username HRESULT
		// get_UserName( BSTR *name );
		[DispId(1)]
		new string UserName
		{
			[DispId(1)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;

			[DispId(1)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>
		/// Sets the password of a local or a domain account on the remote computer. For more information, see Authentication for Remote Connections.
		/// </para>
		/// <para>This property is write-only.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanconnectionoptions-put_password HRESULT
		// put_Password( BSTR password );
		[DispId(2)]
		new string Password
		{
			[DispId(2)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>Sets or gets the certificate thumbprint to use when authenticating by using client certificate authentication.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanconnectionoptionsex-get_certificatethumbprint
		// HRESULT get_CertificateThumbprint( BSTR *thumbprint );
		[DispId(3)]
		string CertificateThumbprint
		{
			[DispId(3)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;

			[DispId(3)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}
	}

	/// <summary>
	/// The <c>IWSManConnectionOptionsEx2</c> object is passed to the IWSMan::CreateSession method to provide the authentication
	/// mechanism, access type, and credentials to connect to a proxy server.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nn-wsmandisp-iwsmanconnectionoptionsex2
	[PInvokeData("wsmandisp.h", MSDNShortId = "NN:wsmandisp.IWSManConnectionOptionsEx2")]
	[ComImport, Guid("F500C9EC-24EE-48ab-B38D-FC9A164C658E"), InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface IWSManConnectionOptionsEx2 : IWSManConnectionOptionsEx
	{
		/// <summary>
		/// <para>
		/// Sets and gets the user name of a local or a domain account on the remote computer. This property determines the user name
		/// for authentication. If no value is supplied and the <c>WSManFlagCredUsernamePassword</c> flag is not set, then the user name
		/// of the account that is running the script is used.
		/// </para>
		/// <para>
		/// If the <c>WSManFlagCredUsernamePassword</c> flag is set but no user name is specified, the script prompts the user to enter
		/// the user name and password. If no user name and password are entered then an access denied error is returned. For more
		/// information, see Authentication for Remote Connections.
		/// </para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>
		/// You can supply UserName and Password for a domain account when using Negotiate or Kerberos authentication, or for a local
		/// account with Basic authentication. To connect to a local account, the WSMan.CreateSession flags must contain the combination
		/// of the <c>WSManFlagUseBasic</c> flag and the <c>WsmanFlagCredUserNamePassword</c> flag. To connect to a domain account, the
		/// <c>WSMan.CreateSession</c> flags must contain the combination of the <c>WSManFlagUseNegotiate</c> flag and the
		/// <c>WsmanFlagCredUserNamePassword</c> flag, or the combination of the <c>WSManFlagUseKerberos</c> flag and the
		/// <c>WsmanFlagCredUserNamePassword</c> flag. For a domain account, <c>UserName</c> must be specified in the form
		/// "computer\username", where the "computer" part of the string can be either the name or the IP address. For more information,
		/// see Authentication for Remote Connections.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanconnectionoptions-get_username HRESULT
		// get_UserName( BSTR *name );
		[DispId(1)]
		new string UserName
		{
			[DispId(1)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;

			[DispId(1)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>
		/// Sets the password of a local or a domain account on the remote computer. For more information, see Authentication for Remote Connections.
		/// </para>
		/// <para>This property is write-only.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanconnectionoptions-put_password HRESULT
		// put_Password( BSTR password );
		[DispId(2)]
		new string Password
		{
			[DispId(2)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>Sets or gets the certificate thumbprint to use when authenticating by using client certificate authentication.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanconnectionoptionsex-get_certificatethumbprint
		// HRESULT get_CertificateThumbprint( BSTR *thumbprint );
		[DispId(3)]
		new string CertificateThumbprint
		{
			[DispId(3)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;

			[DispId(3)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>Sets the proxy information for the session.</summary>
		/// <param name="accessType">
		/// Specifies the proxy access type. This parameter must be set to one of the values in the WSManProxyAccessTypeFlags
		/// enumeration. The default value is <c>WSManProxyWinHttpConfig</c>.
		/// </param>
		/// <param name="authenticationMechanism">
		/// Specifies the authentication mechanism to use for the proxy. This parameter is optional and the default value is 0. If this
		/// parameter is set to 0, the WinRM client chooses either Kerberos or Negotiate. Otherwise, this parameter must be set to one
		/// of the values in the WSManProxyAuthenticationFlags enumeration. The default value from the enumeration is <c>WSManFlagProxyAuthenticationUseNegotiate</c>.
		/// </param>
		/// <param name="userName">
		/// Specifies the user name for proxy authentication. This parameter is optional. If a value is not specified for this
		/// parameter, the default credentials are used.
		/// </param>
		/// <param name="password">
		/// Specifies the password for proxy authentication. This parameter is optional. If a value is not specified for this parameter,
		/// the default credentials are used.
		/// </param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>The default credentials are the credentials under which the current thread is operating.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanconnectionoptionsex2-setproxy HRESULT
		// SetProxy( long accessType, long authenticationMechanism, BSTR userName, BSTR password );
		[PreserveSig, DispId(4)]
		HRESULT SetProxy([Optional] WSManProxyAccessTypeFlags accessType, [Optional] WSManProxyAuthenticationFlags authenticationMechanism,
			[Optional, MarshalAs(UnmanagedType.BStr)] string? userName, [Optional, MarshalAs(UnmanagedType.BStr)] string? password);

		/// <summary>
		/// Returns the value of the proxy access type flag <c>WSManProxyIEConfig</c> for use in the accessType parameter of the
		/// IWSManConnectionOptionsEx2::SetProxy method.
		/// </summary>
		/// <returns>Specifies the value of the constant.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanconnectionoptionsex2-proxyieconfig HRESULT
		// ProxyIEConfig( long *value );
		[DispId(5)]
		WSManProxyAccessTypeFlags ProxyIEConfig();

		/// <summary>
		/// Returns the value of the proxy access type flag <c>WSManProxyWinHttpConfig</c> for use in the accessType parameter of the
		/// IWSManConnectionOptionsEx2::SetProxy method.
		/// </summary>
		/// <returns>Specifies the value of the constant.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanconnectionoptionsex2-proxywinhttpconfig
		// HRESULT ProxyWinHttpConfig( long *value );
		[DispId(6)]
		WSManProxyAccessTypeFlags ProxyWinHttpConfig();

		/// <summary>
		/// Returns the value of the proxy access type flag <c>WSManProxyAutoDetect</c> for use in the accessType parameter of the
		/// IWSManConnectionOptionsEx2::SetProxy method.
		/// </summary>
		/// <returns>Specifies the value of the constant.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanconnectionoptionsex2-proxyautodetect HRESULT
		// ProxyAutoDetect( long *value );
		[DispId(7)]
		WSManProxyAccessTypeFlags ProxyAutoDetect();

		/// <summary>
		/// Returns the value of the proxy access type flag <c>WSManProxyNoProxyServer</c> for use in the accessType parameter of the
		/// IWSManConnectionOptionsEx2::SetProxy method.
		/// </summary>
		/// <returns>Specifies the value of the constant.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanconnectionoptionsex2-proxynoproxyserver
		// HRESULT ProxyNoProxyServer( long *value );
		[DispId(8)]
		WSManProxyAccessTypeFlags ProxyNoProxyServer();

		/// <summary>
		/// Returns the value of the proxy authentication flag <c>WSManFlagProxyAuthenticationUseNegotiate</c> for use in the
		/// authenticationMechanism parameter of the IWSManConnectionOptionsEx2::SetProxy method.
		/// </summary>
		/// <returns>Specifies the value of the constant.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanconnectionoptionsex2-proxyauthenticationusenegotiate
		// HRESULT ProxyAuthenticationUseNegotiate( long *value );
		[DispId(9)]
		WSManProxyAuthenticationFlags ProxyAuthenticationUseNegotiate();

		/// <summary>
		/// Returns the value of the proxy authentication flag <c>WSManFlagProxyAuthenticationUseBasic</c> for use in the
		/// authenticationMechanism parameter of the IWSManConnectionOptionsEx2::SetProxy method.
		/// </summary>
		/// <returns>Specifies the value of the constant.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanconnectionoptionsex2-proxyauthenticationusebasic
		// HRESULT ProxyAuthenticationUseBasic( long *value );
		[DispId(10)]
		WSManProxyAuthenticationFlags ProxyAuthenticationUseBasic();

		/// <summary>
		/// Returns the value of the proxy authentication flag <c>WSManFlagProxyAuthenticationUseDigest</c> for use in the
		/// authenticationMechanism parameter of the IWSManConnectionOptionsEx2::SetProxy method.
		/// </summary>
		/// <returns>Specifies the value of the constant.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanconnectionoptionsex2-proxyauthenticationusedigest
		// HRESULT ProxyAuthenticationUseDigest( long *value );
		[DispId(11)]
		WSManProxyAuthenticationFlags ProxyAuthenticationUseDigest();
	}

	/// <summary>
	/// Represents a stream of results returned from operations such as a WS-Management protocol WS-Enumeration:Enumerate operation.
	/// </summary>
	/// <remarks>
	/// <para>The corresponding scripting object is Enumerator.</para>
	/// <para>To limit the number of items that are read, set the IWSManSession::BatchItems property.</para>
	/// <para>Be aware that freeing the enumeration object clears pending enumeration requests.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nn-wsmandisp-iwsmanenumerator
	[PInvokeData("wsmandisp.h", MSDNShortId = "NN:wsmandisp.IWSManEnumerator")]
	[ComImport, Guid("F3457CA9-ABB9-4fa5-B850-90E8CA300E7F"), InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface IWSManEnumerator
	{
		/// <summary>Retrieves an item from the resource and returns an XML representation of the item.</summary>
		/// <param name="resource">The XML representation of the item.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// <para>
		/// To start an enumeration, use IWSManSession.Enumerate. To perform a WS-Eventing:Pull operation that continues reading items
		/// in the enumeration, use <c>IWSManEnumerator.ReadItem</c>.
		/// </para>
		/// <para>To limit the number of items that are read, set the Session.BatchItems property.</para>
		/// <para>Be aware that freeing the enumeration object clears pending enumeration requests.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanenumerator-readitem HRESULT ReadItem( BSTR
		// *resource );
		[PreserveSig, DispId(1)]
		HRESULT ReadItem([MarshalAs(UnmanagedType.BStr)] out string resource);

		/// <summary>
		/// <para>Indicates that the end of items in the IWSManEnumerator object has been reached by calls to IWSManEnumerator::ReadItem.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanenumerator-get_atendofstream HRESULT
		// get_AtEndOfStream( VARIANT_BOOL *eos );
		[DispId(2)]
		bool AtEndOfStream
		{
			[DispId(2)]
			get;
		}

		/// <summary>
		/// <para>Gets an XML representation of additional error information.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanenumerator-get_error HRESULT get_Error( BSTR
		// *value );
		[DispId(8)]
		string Error
		{
			[DispId(8)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}
	}

	/// <summary>
	/// Extends the methods and properties of the IWSMan interface to include creating IWSManResourceLocator objects, methods that
	/// return enumeration and session flag values, and a method to get extended error information.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nn-wsmandisp-iwsmanex
	[PInvokeData("wsmandisp.h", MSDNShortId = "NN:wsmandisp.IWSManEx")]
	[ComImport, Guid("2D53BDAA-798E-49e6-A1AA-74D01256F411"), InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[CoClass(typeof(WSMan))]
	public interface IWSManEx : IWSMan
	{
		/// <summary>Creates a Session object that can then be used for subsequent network operations.</summary>
		/// <param name="connection">
		/// The protocol and service to connect to, including either IPv4 or IPv6. The format of the connection information is as
		/// follows: &lt;Transport&gt;&lt;Address&gt;&lt;Suffix&gt;. For examples, see Remarks. If no connection information is
		/// provided, the local computer is used.
		/// </param>
		/// <param name="flags">
		/// <para>
		/// The session flags that specify the authentication method, such as Negotiate authentication or Digest authentication, for
		/// connecting to a remote computer. These flags also specify other session connection information, such as encoding or
		/// encryption. This parameter must contain one or more of the flags in <c>__WSManSessionFlags</c> for a remote connection. For
		/// more information, see Session Constants. No flag settings are required for a connection to the WinRM service on the local computer.
		/// </para>
		/// <para>
		/// If no authentication flags are specified, Kerberos is used unless one of the following conditions is true, in which case
		/// Negotiate is used:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>explicit credentials are supplied and the destination host is trusted</term>
		/// </item>
		/// <item>
		/// <term>the destination host is "localhost", "127.0.0.1" or "[::1]"</term>
		/// </item>
		/// <item>
		/// <term>the client computer is in a workgroup and the destination host is trusted</term>
		/// </item>
		/// </list>
		/// <para>For more information, see</para>
		/// <para>Authentication for Remote Connections</para>
		/// <para>and the</para>
		/// <para>connectionOptions</para>
		/// <para>parameter.</para>
		/// </param>
		/// <param name="connectionOptions">
		/// A pointer to an IWSManConnectionOptions object that contains a user name and password. The default is <c>NULL</c>.
		/// </param>
		/// <param name="session">A pointer to a new IWSManSession object.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// <para>
		/// The following list contains examples of formats used to specify connection information in the connection parameter (when
		/// creating an HTTPS session, the &lt;Address&gt; field must match the server computer certificate name, otherwise a failure occurs):
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>"https://service"
		/// <para>Uses HTTPS to connect to the default web service location.</para>
		/// </term>
		/// </item>
		/// <item>
		/// <term>"https://service.corp.com/websvcs/wsman"
		/// <para>Uses HTTPS to connect to the specific web service location.</para>
		/// </term>
		/// </item>
		/// <item>
		/// <term>"https://[E3D7:0000:0000:0000:51F4:9BC8:C0A8:6420]"
		/// <para>Uses HTTPS and IPv6 with the default port.</para>
		/// </term>
		/// </item>
		/// <item>
		/// <term>"https://[E3D7:0000:0000:0000:51F4:9BC8:C0A8:6420]:9999/wsman"
		/// <para>Uses HTTPS and IPv6 with the given port.</para>
		/// </term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsman-createsession HRESULT CreateSession( BSTR
		// connection, long flags, IDispatch *connectionOptions, IDispatch **session );
		[PreserveSig, DispId(1)]
		new HRESULT CreateSession([MarshalAs(UnmanagedType.BStr)] string connection, [Optional] WSManSessionFlags flags,
			IWSManConnectionOptions connectionOptions, out IWSManSession session);

		/// <summary>Creates an IWSManConnectionOptions object that specifies the user name and password used when creating a session.</summary>
		/// <param name="connectionOptions">A pointer to a new IWSManConnectionOptions object.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsman-createconnectionoptions HRESULT
		// CreateConnectionOptions( IDispatch **connectionOptions );
		[PreserveSig, DispId(2)]
		new HRESULT CreateConnectionOptions(out IWSManConnectionOptions connectionOptions);

		/// <summary>
		/// <para>Gets the command line of the process that loads the automation component.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/winrm/wsman-commandline WSMan.CommandLine As BSTR
		[DispId(3)]
		new string CommandLine
		{
			[DispId(3)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>
		/// Gets additional error information, in an XML stream, for the preceding call to an IWSMan method if Windows Remote Management
		/// service was unable to create an IWSManSession object, an IWSManConnectionOptions object, or an IWSManResourceLocator object.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsman-get_error HRESULT get_Error( BSTR *value );
		[DispId(4)]
		new string Error
		{
			[DispId(4)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// Creates a ResourceLocator object that can be used instead of a resource URI in Session object operations such as
		/// IWSManSession.Get, IWSManSession.Put, or Session.Enumerate.
		/// </summary>
		/// <param name="strResourceLocator">
		/// The resource URI for the resource. For more information about URI strings, see Resource URIs.
		/// </param>
		/// <param name="newResourceLocator">A pointer to a new instance of IWSManResourceLocator.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// If the <c>FragmentDialect</c> property is not specified in the IWSManResourceLocator object, the default is the XPath 1.0
		/// specification. For more information, see http://www.w3.org/TR/xpath.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanex-createresourcelocator HRESULT
		// CreateResourceLocator( BSTR strResourceLocator, IDispatch **newResourceLocator );
		[PreserveSig, DispId(5)]
		HRESULT CreateResourceLocator([MarshalAs(UnmanagedType.BStr)] string strResourceLocator,
			out IWSManResourceLocator newResourceLocator);

		/// <summary>
		/// <para>
		/// The WSMan.SessionFlagUTF8 method returns the value of the authentication flag <c>WSManFlagUTF8</c> for use in the flags
		/// parameter of IWSMan::CreateSession.
		/// </para>
		/// <para>
		/// <c>WSManFlagUTF8</c> is a constant in the <c>__WSManSessionFlags</c> enumeration. For more information, see Other Session Constants.
		/// </para>
		/// </summary>
		/// <returns>The value of the constant.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanex-sessionflagutf8 HRESULT SessionFlagUTF8(
		// long *flags );
		[DispId(6)]
		WSManSessionFlags SessionFlagUTF8();

		/// <summary>
		/// <para>
		/// The <c>IWSMan.SessionFlagCredUsernamePassword</c> method returns the value of the authentication flag
		/// <c>WSManFlagCredUsernamePassword</c> for use in the flags parameter of IWSMan::CreateSession.
		/// </para>
		/// <para>
		/// <c>WSManFlagCredUsernamePassword</c> is a constant in the <c>__WSManSessionFlags</c> enumeration. For more information, see
		/// Authentication Constants.
		/// </para>
		/// </summary>
		/// <returns>The value of the constant.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanex-sessionflagcredusernamepassword HRESULT
		// SessionFlagCredUsernamePassword( long *flags );
		[DispId(7)]
		WSManSessionFlags SessionFlagCredUsernamePassword();

		/// <summary>
		/// <para>
		/// The WSMan.SessionFlagSkipCACheck method returns the value of the <c>WSManFlagSkipCACheck</c> authentication flag for use in
		/// the flags parameter of the IWSMan::CreateSession method.
		/// </para>
		/// <para>
		/// <c>WSManFlagSkipCACheck</c> is a constant in the <c>__WSManSessionFlags</c> enumeration. For more information, see
		/// Authentication Constants.
		/// </para>
		/// </summary>
		/// <returns>The value of the constant.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanex-sessionflagskipcacheck HRESULT
		// SessionFlagSkipCACheck( long *flags );
		[DispId(8)]
		WSManSessionFlags SessionFlagSkipCACheck();

		/// <summary>
		/// <para>
		/// The WSMan.SessionFlagSkipCNCheck method returns the value of the authentication flag <c>WSManFlagSkipCNCheck</c> for use in
		/// the flags parameter of IWSMan::CreateSession.
		/// </para>
		/// <para>
		/// <c>WSManFlagSkipCNCheck</c> is a constant in the <c>__WSManSessionFlags</c> enumeration. For more information, see
		/// Authentication Constants.
		/// </para>
		/// </summary>
		/// <returns>The value of the constant.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanex-sessionflagskipcncheck HRESULT
		// SessionFlagSkipCNCheck( long *flags );
		[DispId(9)]
		WSManSessionFlags SessionFlagSkipCNCheck();

		/// <summary>
		/// <para>
		/// The WSMan.SessionFlagUseDigest method returns the value of the authentication flag <c>WSManFlagUseDigest</c> for use in the
		/// flags parameter of IWSMan::CreateSession.
		/// </para>
		/// <para>
		/// <c>WSManFlagUseDigest</c> is a constant in the <c>__WSManSessionFlags</c> enumeration. For more information, see
		/// Authentication Constants.
		/// </para>
		/// </summary>
		/// <returns>The value of the constant.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanex-sessionflagusedigest HRESULT
		// SessionFlagUseDigest( long *flags );
		[DispId(10)]
		WSManSessionFlags SessionFlagUseDigest();

		/// <summary>
		/// <para>
		/// The WSMan.SessionFlagUseNegotiate method returns the value of the authentication flag <c>WSManFlagUseNegotiate</c> for use
		/// in the flags parameter of IWSMan::CreateSession.
		/// </para>
		/// <para>
		/// <c>WSManFlagUseNegotiate</c> is a constant in the <c>__WSManSessionFlags</c> enumeration. For more information, see
		/// Authentication Constants.
		/// </para>
		/// </summary>
		/// <returns>The value of the constant.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanex-sessionflagusenegotiate HRESULT
		// SessionFlagUseNegotiate( long *flags );
		[DispId(11)]
		WSManSessionFlags SessionFlagUseNegotiate();

		/// <summary>
		/// <para>
		/// The WSMan.SessionFlagUseBasic method returns the value of the authentication flag <c>WSManFlagUseBasic</c> for use in the
		/// flags parameter of IWSMan::CreateSession.
		/// </para>
		/// <para>
		/// <c>WSManFlagUseBasic</c> is a constant in the <c>__WSManSessionFlags</c> enumeration. For more information, see
		/// Authentication Constants.
		/// </para>
		/// </summary>
		/// <returns>The value of the constant.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanex-sessionflagusebasic HRESULT
		// SessionFlagUseBasic( long *flags );
		[DispId(12)]
		WSManSessionFlags SessionFlagUseBasic();

		/// <summary>
		/// <para>
		/// The WSMan.WSMan.SessionFlagUseKerberos method returns the value of the authentication flag <c>WSManFlagUseKerberos</c> for
		/// use in the flags parameter of IWSMan::CreateSession.
		/// </para>
		/// <para>
		/// <c>WSManFlagUseKerberos</c> is a constant in the <c>__WSManSessionFlags</c> enumeration. For more information, see
		/// Authentication Constants.
		/// </para>
		/// </summary>
		/// <returns>The value of the constant.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanex-sessionflagusekerberos HRESULT
		// SessionFlagUseKerberos( long *flags );
		[DispId(13)]
		WSManSessionFlags SessionFlagUseKerberos();

		/// <summary>
		/// <para>
		/// The WSMan.SessionFlagNoEncryption method returns the value of the authentication flag <c>WSManFlagNoEncryption</c> for use
		/// in the flags parameter of IWSMan::CreateSession.
		/// </para>
		/// <para>
		/// <c>WSManFlagNoEncryption</c> is a constant in the <c>__WSManSessionFlags</c> enumeration. For more information, see Other
		/// Session Constants.
		/// </para>
		/// </summary>
		/// <returns>The value of the constant.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanex-sessionflagnoencryption HRESULT
		// SessionFlagNoEncryption( long *flags );
		[DispId(14)]
		WSManSessionFlags SessionFlagNoEncryption();

		/// <summary>
		/// <para>
		/// The WSMan.SessionFlagEnableSPNServerPort method returns the value of the authentication flag
		/// <c>WSManFlagEnableSPNServerPort</c> for use in the flags parameter of IWSMan::CreateSession.
		/// </para>
		/// <para>
		/// <c>WSManFlagEnableSPNServerPort</c> is a constant in the <c>__WSManSessionFlags</c> enumeration. For more information, see
		/// Other Session Constants.
		/// </para>
		/// </summary>
		/// <returns>The value of the constant.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanex-sessionflagenablespnserverport HRESULT
		// SessionFlagEnableSPNServerPort( long *flags );
		[DispId(15)]
		WSManSessionFlags SessionFlagEnableSPNServerPort();

		/// <summary>
		/// <para>
		/// The WSMan.SessionFlagUseNoAuthentication method returns the value of the authentication flag
		/// <c>WSManFlagUseNoAuthentication</c> for use in the flags parameter of IWSMan::CreateSession.
		/// </para>
		/// <para>
		/// <c>WSManFlagUseNoAuthentication</c> is a constant in the <c>__WSManSessionFlags</c> enumeration. For more information, see
		/// Authentication Constants.
		/// </para>
		/// </summary>
		/// <returns>The value of the constant.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanex-sessionflagusenoauthentication HRESULT
		// SessionFlagUseNoAuthentication( long *flags );
		[DispId(16)]
		WSManSessionFlags SessionFlagUseNoAuthentication();

		/// <summary>
		/// <para>
		/// The <c>IWSManEx::EnumerationFlagNonXmlText</c> method returns the value of the enumeration constant
		/// <c>WSManFlagNonXmlText</c> for use in the flags parameter of the IWSManSession::Enumerate method.
		/// </para>
		/// <para>
		/// <c>WSManFlagNonXmlText</c> is a constant in the <c>__WSManEnumFlags</c> enumeration. For more information, see Enumeration Constants.
		/// </para>
		/// </summary>
		/// <returns>The value of the constant.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanex-enumerationflagnonxmltext HRESULT
		// EnumerationFlagNonXmlText( long *flags );
		[DispId(17)]
		WSManEnumFlags EnumerationFlagNonXmlText();

		/// <summary>
		/// <para>
		/// The <c>IWSManEx::EnumerationFlagReturnEPR</c> method returns the value of the enumeration constant
		/// <c>EnumerationFlagReturnEPR</c> for use in the flags parameter of the IWSManSession::Enumerate method.
		/// </para>
		/// <para>
		/// <c>EnumerationFlagReturnEPR</c> is a constant in the <c>_WSManEnumFlags</c> enumeration and is described in Enumeration Constants.
		/// </para>
		/// </summary>
		/// <returns>The value of the constant.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanex-enumerationflagreturnepr HRESULT
		// EnumerationFlagReturnEPR( long *flags );
		[DispId(18)]
		WSManEnumFlags EnumerationFlagReturnEPR();

		/// <summary>
		/// <para>
		/// The <c>IWSManEx::EnumerationFlagReturnObjectAndEPR</c> method returns the value of the enumeration constant
		/// <c>EnumerationFlagReturnObjectAndEPR</c> for use in the flags parameter of the IWSManSession::Enumerate method.
		/// </para>
		/// <para>
		/// <c>EnumerationFlagReturnObjectAndEPR</c> is a constant in the <c>_WSManEnumFlags</c> enumeration and is described in
		/// Enumeration Constants.
		/// </para>
		/// </summary>
		/// <returns>The value of the constant.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanex-enumerationflagreturnobjectandepr HRESULT
		// EnumerationFlagReturnObjectAndEPR( long *flags );
		[DispId(19)]
		WSManEnumFlags EnumerationFlagReturnObjectAndEPR();

		/// <summary>
		/// Returns a formatted string containing the text of an error number. This method performs the same operation as the
		/// <c>Winrm</c> command-line <c>winrm helpmsg</c> error number.
		/// </summary>
		/// <param name="errorNumber">
		/// Error message number in decimal or hexadecimal from WinRM, WinHTTP, or other operating system components.
		/// </param>
		/// <param name="errorMessage">Error message string formatted like messages returned from the <c>Winrm</c> command.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>The corresponding scripting method is WSMan.GetErrorMessage.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanex-geterrormessage HRESULT GetErrorMessage(
		// DWORD errorNumber, BSTR *errorMessage );
		[PreserveSig, DispId(20)]
		HRESULT GetErrorMessage(uint errorNumber, [MarshalAs(UnmanagedType.BStr)] out string errorMessage);

		/// <summary>
		/// <para>
		/// The <c>IWSManEx::EnumerationFlagHierarchyDeep</c> method returns the value of the enumeration constant
		/// <c>EnumerationFlagHierarchyDeep</c> for use in the flags parameter of the IWSManSession::Enumerate method.
		/// </para>
		/// <para>
		/// <c>EnumerationFlagHierarchyDeep</c> is a constant in the <c>_WSManEnumFlags</c> enumeration and is described in Enumeration Constants.
		/// </para>
		/// </summary>
		/// <returns>The value of the constant.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanex-enumerationflaghierarchydeep HRESULT
		// EnumerationFlagHierarchyDeep( long *flags );
		[DispId(21)]
		WSManEnumFlags EnumerationFlagHierarchyDeep();

		/// <summary>
		/// <para>
		/// The <c>IWSManEx::EnumerationFlagHierarchyShallow</c> method returns the value of the enumeration constant
		/// <c>EnumerationFlagHierarchyShallow</c> for use in the flags parameter of the IWSManSession::Enumerate method.
		/// </para>
		/// <para>
		/// <c>EnumerationFlagHierarchyShallow</c> is a constant in the <c>_WSManEnumFlags</c> enumeration and is described in
		/// Enumeration Constants.
		/// </para>
		/// </summary>
		/// <returns>The value of the constant.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanex-enumerationflaghierarchyshallow HRESULT
		// EnumerationFlagHierarchyShallow( long *flags );
		[DispId(22)]
		WSManEnumFlags EnumerationFlagHierarchyShallow();

		/// <summary>
		/// <para>
		/// The <c>IWSManEx::EnumerationFlagHierarchyDeepBasePropsOnly</c> method returns the value of the enumeration constant
		/// <c>EnumerationFlagHierarchyDeepBasePropsOnly</c> for use in the flags parameter of the IWSManSession::Enumerate method.
		/// </para>
		/// <para>
		/// <c>EnumerationFlagHierarchyDeepBasePropsOnly</c> is a constant in the <c>_WSManEnumFlags</c> enumeration and is described in
		/// Enumeration Constants.
		/// </para>
		/// </summary>
		/// <returns>The value of the constant.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanex-enumerationflaghierarchydeepbasepropsonly
		// HRESULT EnumerationFlagHierarchyDeepBasePropsOnly( long *flags );
		[DispId(23)]
		WSManEnumFlags EnumerationFlagHierarchyDeepBasePropsOnly();

		/// <summary>
		/// <para>
		/// The <c>IWSManEx::EnumerationFlagReturnObject</c> method returns the value of the enumeration constant
		/// <c>EnumerationFlagReturnObject</c> for use in the flags parameter of the IWSManSession::Enumerate method.
		/// </para>
		/// <para>
		/// <c>EnumerationFlagReturnObject</c> is a constant in the <c>_WSManEnumFlags</c> enumeration and is described in Enumeration Constants.
		/// </para>
		/// </summary>
		/// <returns>The value of the constant.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanex-enumerationflagreturnobject HRESULT
		// EnumerationFlagReturnObject( long *flags );
		[DispId(24)]
		WSManEnumFlags EnumerationFlagReturnObject();
	}

	/// <summary>
	/// Extends the methods and properties of the IWSManEx interface to include a method that returns a session flag value related to
	/// authentication using client certificates.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nn-wsmandisp-iwsmanex2
	[PInvokeData("wsmandisp.h", MSDNShortId = "NN:wsmandisp.IWSManEx2")]
	[ComImport, Guid("1D1B5AE0-42D9-4021-8261-3987619512E9"), InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[CoClass(typeof(WSMan))]
	public interface IWSManEx2 : IWSManEx
	{
		/// <summary>Creates a Session object that can then be used for subsequent network operations.</summary>
		/// <param name="connection">
		/// The protocol and service to connect to, including either IPv4 or IPv6. The format of the connection information is as
		/// follows: &lt;Transport&gt;&lt;Address&gt;&lt;Suffix&gt;. For examples, see Remarks. If no connection information is
		/// provided, the local computer is used.
		/// </param>
		/// <param name="flags">
		/// <para>
		/// The session flags that specify the authentication method, such as Negotiate authentication or Digest authentication, for
		/// connecting to a remote computer. These flags also specify other session connection information, such as encoding or
		/// encryption. This parameter must contain one or more of the flags in <c>__WSManSessionFlags</c> for a remote connection. For
		/// more information, see Session Constants. No flag settings are required for a connection to the WinRM service on the local computer.
		/// </para>
		/// <para>
		/// If no authentication flags are specified, Kerberos is used unless one of the following conditions is true, in which case
		/// Negotiate is used:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>explicit credentials are supplied and the destination host is trusted</term>
		/// </item>
		/// <item>
		/// <term>the destination host is "localhost", "127.0.0.1" or "[::1]"</term>
		/// </item>
		/// <item>
		/// <term>the client computer is in a workgroup and the destination host is trusted</term>
		/// </item>
		/// </list>
		/// <para>For more information, see</para>
		/// <para>Authentication for Remote Connections</para>
		/// <para>and the</para>
		/// <para>connectionOptions</para>
		/// <para>parameter.</para>
		/// </param>
		/// <param name="connectionOptions">
		/// A pointer to an IWSManConnectionOptions object that contains a user name and password. The default is <c>NULL</c>.
		/// </param>
		/// <param name="session">A pointer to a new IWSManSession object.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// <para>
		/// The following list contains examples of formats used to specify connection information in the connection parameter (when
		/// creating an HTTPS session, the &lt;Address&gt; field must match the server computer certificate name, otherwise a failure occurs):
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>"https://service"
		/// <para>Uses HTTPS to connect to the default web service location.</para>
		/// </term>
		/// </item>
		/// <item>
		/// <term>"https://service.corp.com/websvcs/wsman"
		/// <para>Uses HTTPS to connect to the specific web service location.</para>
		/// </term>
		/// </item>
		/// <item>
		/// <term>"https://[E3D7:0000:0000:0000:51F4:9BC8:C0A8:6420]"
		/// <para>Uses HTTPS and IPv6 with the default port.</para>
		/// </term>
		/// </item>
		/// <item>
		/// <term>"https://[E3D7:0000:0000:0000:51F4:9BC8:C0A8:6420]:9999/wsman"
		/// <para>Uses HTTPS and IPv6 with the given port.</para>
		/// </term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsman-createsession HRESULT CreateSession( BSTR
		// connection, long flags, IDispatch *connectionOptions, IDispatch **session );
		[PreserveSig, DispId(1)]
		new HRESULT CreateSession([MarshalAs(UnmanagedType.BStr)] string connection, [Optional] WSManSessionFlags flags,
			IWSManConnectionOptions connectionOptions, out IWSManSession session);

		/// <summary>Creates an IWSManConnectionOptions object that specifies the user name and password used when creating a session.</summary>
		/// <param name="connectionOptions">A pointer to a new IWSManConnectionOptions object.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsman-createconnectionoptions HRESULT
		// CreateConnectionOptions( IDispatch **connectionOptions );
		[PreserveSig, DispId(2)]
		new HRESULT CreateConnectionOptions(out IWSManConnectionOptions connectionOptions);

		/// <summary>
		/// <para>Gets the command line of the process that loads the automation component.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/winrm/wsman-commandline WSMan.CommandLine As BSTR
		[DispId(3)]
		new string CommandLine
		{
			[DispId(3)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>
		/// Gets additional error information, in an XML stream, for the preceding call to an IWSMan method if Windows Remote Management
		/// service was unable to create an IWSManSession object, an IWSManConnectionOptions object, or an IWSManResourceLocator object.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsman-get_error HRESULT get_Error( BSTR *value );
		[DispId(4)]
		new string Error
		{
			[DispId(4)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// Creates a ResourceLocator object that can be used instead of a resource URI in Session object operations such as
		/// IWSManSession.Get, IWSManSession.Put, or Session.Enumerate.
		/// </summary>
		/// <param name="strResourceLocator">
		/// The resource URI for the resource. For more information about URI strings, see Resource URIs.
		/// </param>
		/// <param name="newResourceLocator">A pointer to a new instance of IWSManResourceLocator.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// If the <c>FragmentDialect</c> property is not specified in the IWSManResourceLocator object, the default is the XPath 1.0
		/// specification. For more information, see http://www.w3.org/TR/xpath.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanex-createresourcelocator HRESULT
		// CreateResourceLocator( BSTR strResourceLocator, IDispatch **newResourceLocator );
		[PreserveSig, DispId(5)]
		new HRESULT CreateResourceLocator([MarshalAs(UnmanagedType.BStr)] string strResourceLocator,
			out IWSManResourceLocator newResourceLocator);

		/// <summary>
		/// <para>
		/// The WSMan.SessionFlagUTF8 method returns the value of the authentication flag <c>WSManFlagUTF8</c> for use in the flags
		/// parameter of IWSMan::CreateSession.
		/// </para>
		/// <para>
		/// <c>WSManFlagUTF8</c> is a constant in the <c>__WSManSessionFlags</c> enumeration. For more information, see Other Session Constants.
		/// </para>
		/// </summary>
		/// <returns>The value of the constant.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanex-sessionflagutf8 HRESULT SessionFlagUTF8(
		// long *flags );
		[DispId(6)]
		new WSManSessionFlags SessionFlagUTF8();

		/// <summary>
		/// <para>
		/// The <c>IWSMan.SessionFlagCredUsernamePassword</c> method returns the value of the authentication flag
		/// <c>WSManFlagCredUsernamePassword</c> for use in the flags parameter of IWSMan::CreateSession.
		/// </para>
		/// <para>
		/// <c>WSManFlagCredUsernamePassword</c> is a constant in the <c>__WSManSessionFlags</c> enumeration. For more information, see
		/// Authentication Constants.
		/// </para>
		/// </summary>
		/// <returns>The value of the constant.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanex-sessionflagcredusernamepassword HRESULT
		// SessionFlagCredUsernamePassword( long *flags );
		[DispId(7)]
		new WSManSessionFlags SessionFlagCredUsernamePassword();

		/// <summary>
		/// <para>
		/// The WSMan.SessionFlagSkipCACheck method returns the value of the <c>WSManFlagSkipCACheck</c> authentication flag for use in
		/// the flags parameter of the IWSMan::CreateSession method.
		/// </para>
		/// <para>
		/// <c>WSManFlagSkipCACheck</c> is a constant in the <c>__WSManSessionFlags</c> enumeration. For more information, see
		/// Authentication Constants.
		/// </para>
		/// </summary>
		/// <returns>The value of the constant.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanex-sessionflagskipcacheck HRESULT
		// SessionFlagSkipCACheck( long *flags );
		[DispId(8)]
		new WSManSessionFlags SessionFlagSkipCACheck();

		/// <summary>
		/// <para>
		/// The WSMan.SessionFlagSkipCNCheck method returns the value of the authentication flag <c>WSManFlagSkipCNCheck</c> for use in
		/// the flags parameter of IWSMan::CreateSession.
		/// </para>
		/// <para>
		/// <c>WSManFlagSkipCNCheck</c> is a constant in the <c>__WSManSessionFlags</c> enumeration. For more information, see
		/// Authentication Constants.
		/// </para>
		/// </summary>
		/// <returns>The value of the constant.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanex-sessionflagskipcncheck HRESULT
		// SessionFlagSkipCNCheck( long *flags );
		[DispId(9)]
		new WSManSessionFlags SessionFlagSkipCNCheck();

		/// <summary>
		/// <para>
		/// The WSMan.SessionFlagUseDigest method returns the value of the authentication flag <c>WSManFlagUseDigest</c> for use in the
		/// flags parameter of IWSMan::CreateSession.
		/// </para>
		/// <para>
		/// <c>WSManFlagUseDigest</c> is a constant in the <c>__WSManSessionFlags</c> enumeration. For more information, see
		/// Authentication Constants.
		/// </para>
		/// </summary>
		/// <returns>The value of the constant.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanex-sessionflagusedigest HRESULT
		// SessionFlagUseDigest( long *flags );
		[DispId(10)]
		new WSManSessionFlags SessionFlagUseDigest();

		/// <summary>
		/// <para>
		/// The WSMan.SessionFlagUseNegotiate method returns the value of the authentication flag <c>WSManFlagUseNegotiate</c> for use
		/// in the flags parameter of IWSMan::CreateSession.
		/// </para>
		/// <para>
		/// <c>WSManFlagUseNegotiate</c> is a constant in the <c>__WSManSessionFlags</c> enumeration. For more information, see
		/// Authentication Constants.
		/// </para>
		/// </summary>
		/// <returns>The value of the constant.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanex-sessionflagusenegotiate HRESULT
		// SessionFlagUseNegotiate( long *flags );
		[DispId(11)]
		new WSManSessionFlags SessionFlagUseNegotiate();

		/// <summary>
		/// <para>
		/// The WSMan.SessionFlagUseBasic method returns the value of the authentication flag <c>WSManFlagUseBasic</c> for use in the
		/// flags parameter of IWSMan::CreateSession.
		/// </para>
		/// <para>
		/// <c>WSManFlagUseBasic</c> is a constant in the <c>__WSManSessionFlags</c> enumeration. For more information, see
		/// Authentication Constants.
		/// </para>
		/// </summary>
		/// <returns>The value of the constant.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanex-sessionflagusebasic HRESULT
		// SessionFlagUseBasic( long *flags );
		[DispId(12)]
		new WSManSessionFlags SessionFlagUseBasic();

		/// <summary>
		/// <para>
		/// The WSMan.WSMan.SessionFlagUseKerberos method returns the value of the authentication flag <c>WSManFlagUseKerberos</c> for
		/// use in the flags parameter of IWSMan::CreateSession.
		/// </para>
		/// <para>
		/// <c>WSManFlagUseKerberos</c> is a constant in the <c>__WSManSessionFlags</c> enumeration. For more information, see
		/// Authentication Constants.
		/// </para>
		/// </summary>
		/// <returns>The value of the constant.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanex-sessionflagusekerberos HRESULT
		// SessionFlagUseKerberos( long *flags );
		[DispId(13)]
		new WSManSessionFlags SessionFlagUseKerberos();

		/// <summary>
		/// <para>
		/// The WSMan.SessionFlagNoEncryption method returns the value of the authentication flag <c>WSManFlagNoEncryption</c> for use
		/// in the flags parameter of IWSMan::CreateSession.
		/// </para>
		/// <para>
		/// <c>WSManFlagNoEncryption</c> is a constant in the <c>__WSManSessionFlags</c> enumeration. For more information, see Other
		/// Session Constants.
		/// </para>
		/// </summary>
		/// <returns>The value of the constant.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanex-sessionflagnoencryption HRESULT
		// SessionFlagNoEncryption( long *flags );
		[DispId(14)]
		new WSManSessionFlags SessionFlagNoEncryption();

		/// <summary>
		/// <para>
		/// The WSMan.SessionFlagEnableSPNServerPort method returns the value of the authentication flag
		/// <c>WSManFlagEnableSPNServerPort</c> for use in the flags parameter of IWSMan::CreateSession.
		/// </para>
		/// <para>
		/// <c>WSManFlagEnableSPNServerPort</c> is a constant in the <c>__WSManSessionFlags</c> enumeration. For more information, see
		/// Other Session Constants.
		/// </para>
		/// </summary>
		/// <returns>The value of the constant.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanex-sessionflagenablespnserverport HRESULT
		// SessionFlagEnableSPNServerPort( long *flags );
		[DispId(15)]
		new WSManSessionFlags SessionFlagEnableSPNServerPort();

		/// <summary>
		/// <para>
		/// The WSMan.SessionFlagUseNoAuthentication method returns the value of the authentication flag
		/// <c>WSManFlagUseNoAuthentication</c> for use in the flags parameter of IWSMan::CreateSession.
		/// </para>
		/// <para>
		/// <c>WSManFlagUseNoAuthentication</c> is a constant in the <c>__WSManSessionFlags</c> enumeration. For more information, see
		/// Authentication Constants.
		/// </para>
		/// </summary>
		/// <returns>The value of the constant.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanex-sessionflagusenoauthentication HRESULT
		// SessionFlagUseNoAuthentication( long *flags );
		[DispId(16)]
		new WSManSessionFlags SessionFlagUseNoAuthentication();

		/// <summary>
		/// <para>
		/// The <c>IWSManEx::EnumerationFlagNonXmlText</c> method returns the value of the enumeration constant
		/// <c>WSManFlagNonXmlText</c> for use in the flags parameter of the IWSManSession::Enumerate method.
		/// </para>
		/// <para>
		/// <c>WSManFlagNonXmlText</c> is a constant in the <c>__WSManEnumFlags</c> enumeration. For more information, see Enumeration Constants.
		/// </para>
		/// </summary>
		/// <returns>The value of the constant.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanex-enumerationflagnonxmltext HRESULT
		// EnumerationFlagNonXmlText( long *flags );
		[DispId(17)]
		new WSManEnumFlags EnumerationFlagNonXmlText();

		/// <summary>
		/// <para>
		/// The <c>IWSManEx::EnumerationFlagReturnEPR</c> method returns the value of the enumeration constant
		/// <c>EnumerationFlagReturnEPR</c> for use in the flags parameter of the IWSManSession::Enumerate method.
		/// </para>
		/// <para>
		/// <c>EnumerationFlagReturnEPR</c> is a constant in the <c>_WSManEnumFlags</c> enumeration and is described in Enumeration Constants.
		/// </para>
		/// </summary>
		/// <returns>The value of the constant.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanex-enumerationflagreturnepr HRESULT
		// EnumerationFlagReturnEPR( long *flags );
		[DispId(18)]
		new WSManEnumFlags EnumerationFlagReturnEPR();

		/// <summary>
		/// <para>
		/// The <c>IWSManEx::EnumerationFlagReturnObjectAndEPR</c> method returns the value of the enumeration constant
		/// <c>EnumerationFlagReturnObjectAndEPR</c> for use in the flags parameter of the IWSManSession::Enumerate method.
		/// </para>
		/// <para>
		/// <c>EnumerationFlagReturnObjectAndEPR</c> is a constant in the <c>_WSManEnumFlags</c> enumeration and is described in
		/// Enumeration Constants.
		/// </para>
		/// </summary>
		/// <returns>The value of the constant.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanex-enumerationflagreturnobjectandepr HRESULT
		// EnumerationFlagReturnObjectAndEPR( long *flags );
		[DispId(19)]
		new WSManEnumFlags EnumerationFlagReturnObjectAndEPR();

		/// <summary>
		/// Returns a formatted string containing the text of an error number. This method performs the same operation as the
		/// <c>Winrm</c> command-line <c>winrm helpmsg</c> error number.
		/// </summary>
		/// <param name="errorNumber">
		/// Error message number in decimal or hexadecimal from WinRM, WinHTTP, or other operating system components.
		/// </param>
		/// <param name="errorMessage">Error message string formatted like messages returned from the <c>Winrm</c> command.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>The corresponding scripting method is WSMan.GetErrorMessage.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanex-geterrormessage HRESULT GetErrorMessage(
		// DWORD errorNumber, BSTR *errorMessage );
		[PreserveSig, DispId(20)]
		new HRESULT GetErrorMessage(uint errorNumber, [MarshalAs(UnmanagedType.BStr)] out string errorMessage);

		/// <summary>
		/// <para>
		/// The <c>IWSManEx::EnumerationFlagHierarchyDeep</c> method returns the value of the enumeration constant
		/// <c>EnumerationFlagHierarchyDeep</c> for use in the flags parameter of the IWSManSession::Enumerate method.
		/// </para>
		/// <para>
		/// <c>EnumerationFlagHierarchyDeep</c> is a constant in the <c>_WSManEnumFlags</c> enumeration and is described in Enumeration Constants.
		/// </para>
		/// </summary>
		/// <returns>The value of the constant.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanex-enumerationflaghierarchydeep HRESULT
		// EnumerationFlagHierarchyDeep( long *flags );
		[DispId(21)]
		new WSManEnumFlags EnumerationFlagHierarchyDeep();

		/// <summary>
		/// <para>
		/// The <c>IWSManEx::EnumerationFlagHierarchyShallow</c> method returns the value of the enumeration constant
		/// <c>EnumerationFlagHierarchyShallow</c> for use in the flags parameter of the IWSManSession::Enumerate method.
		/// </para>
		/// <para>
		/// <c>EnumerationFlagHierarchyShallow</c> is a constant in the <c>_WSManEnumFlags</c> enumeration and is described in
		/// Enumeration Constants.
		/// </para>
		/// </summary>
		/// <returns>The value of the constant.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanex-enumerationflaghierarchyshallow HRESULT
		// EnumerationFlagHierarchyShallow( long *flags );
		[DispId(22)]
		new WSManEnumFlags EnumerationFlagHierarchyShallow();

		/// <summary>
		/// <para>
		/// The <c>IWSManEx::EnumerationFlagHierarchyDeepBasePropsOnly</c> method returns the value of the enumeration constant
		/// <c>EnumerationFlagHierarchyDeepBasePropsOnly</c> for use in the flags parameter of the IWSManSession::Enumerate method.
		/// </para>
		/// <para>
		/// <c>EnumerationFlagHierarchyDeepBasePropsOnly</c> is a constant in the <c>_WSManEnumFlags</c> enumeration and is described in
		/// Enumeration Constants.
		/// </para>
		/// </summary>
		/// <returns>The value of the constant.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanex-enumerationflaghierarchydeepbasepropsonly
		// HRESULT EnumerationFlagHierarchyDeepBasePropsOnly( long *flags );
		[DispId(23)]
		new WSManEnumFlags EnumerationFlagHierarchyDeepBasePropsOnly();

		/// <summary>
		/// <para>
		/// The <c>IWSManEx::EnumerationFlagReturnObject</c> method returns the value of the enumeration constant
		/// <c>EnumerationFlagReturnObject</c> for use in the flags parameter of the IWSManSession::Enumerate method.
		/// </para>
		/// <para>
		/// <c>EnumerationFlagReturnObject</c> is a constant in the <c>_WSManEnumFlags</c> enumeration and is described in Enumeration Constants.
		/// </para>
		/// </summary>
		/// <returns>The value of the constant.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanex-enumerationflagreturnobject HRESULT
		// EnumerationFlagReturnObject( long *flags );
		[DispId(24)]
		new WSManEnumFlags EnumerationFlagReturnObject();

		/// <summary>
		/// <para>
		/// Returns the value of the authentication flag <c>WSManFlagUseClientCertificate</c> for use in the flags parameter of IWSMan::CreateSession.
		/// </para>
		/// <para>
		/// <c>WSManFlagUseClientCertificate</c> is a constant in the <c>__WSManSessionFlags</c> enumeration. For more information, see
		/// Authentication Constants.
		/// </para>
		/// </summary>
		/// <returns>The session flags to use.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanex2-sessionflaguseclientcertificate HRESULT
		// SessionFlagUseClientCertificate( long *flags );
		[DispId(25)]
		WSManSessionFlags SessionFlagUseClientCertificate();
	}

	/// <summary>
	/// Extends the methods and properties of the IWSManEx interface to include a method that returns a session flag value related to
	/// authentication using the Credential Security Support Provider (CredSSP).
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nn-wsmandisp-iwsmanex3
	[PInvokeData("wsmandisp.h", MSDNShortId = "NN:wsmandisp.IWSManEx3")]
	[ComImport, Guid("6400E966-011D-4eac-8474-049E0848AFAD"), InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[CoClass(typeof(WSMan))]
	public interface IWSManEx3 : IWSManEx2
	{
		/// <summary>Creates a Session object that can then be used for subsequent network operations.</summary>
		/// <param name="connection">
		/// The protocol and service to connect to, including either IPv4 or IPv6. The format of the connection information is as
		/// follows: &lt;Transport&gt;&lt;Address&gt;&lt;Suffix&gt;. For examples, see Remarks. If no connection information is
		/// provided, the local computer is used.
		/// </param>
		/// <param name="flags">
		/// <para>
		/// The session flags that specify the authentication method, such as Negotiate authentication or Digest authentication, for
		/// connecting to a remote computer. These flags also specify other session connection information, such as encoding or
		/// encryption. This parameter must contain one or more of the flags in <c>__WSManSessionFlags</c> for a remote connection. For
		/// more information, see Session Constants. No flag settings are required for a connection to the WinRM service on the local computer.
		/// </para>
		/// <para>
		/// If no authentication flags are specified, Kerberos is used unless one of the following conditions is true, in which case
		/// Negotiate is used:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>explicit credentials are supplied and the destination host is trusted</term>
		/// </item>
		/// <item>
		/// <term>the destination host is "localhost", "127.0.0.1" or "[::1]"</term>
		/// </item>
		/// <item>
		/// <term>the client computer is in a workgroup and the destination host is trusted</term>
		/// </item>
		/// </list>
		/// <para>For more information, see</para>
		/// <para>Authentication for Remote Connections</para>
		/// <para>and the</para>
		/// <para>connectionOptions</para>
		/// <para>parameter.</para>
		/// </param>
		/// <param name="connectionOptions">
		/// A pointer to an IWSManConnectionOptions object that contains a user name and password. The default is <c>NULL</c>.
		/// </param>
		/// <param name="session">A pointer to a new IWSManSession object.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// <para>
		/// The following list contains examples of formats used to specify connection information in the connection parameter (when
		/// creating an HTTPS session, the &lt;Address&gt; field must match the server computer certificate name, otherwise a failure occurs):
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>"https://service"
		/// <para>Uses HTTPS to connect to the default web service location.</para>
		/// </term>
		/// </item>
		/// <item>
		/// <term>"https://service.corp.com/websvcs/wsman"
		/// <para>Uses HTTPS to connect to the specific web service location.</para>
		/// </term>
		/// </item>
		/// <item>
		/// <term>"https://[E3D7:0000:0000:0000:51F4:9BC8:C0A8:6420]"
		/// <para>Uses HTTPS and IPv6 with the default port.</para>
		/// </term>
		/// </item>
		/// <item>
		/// <term>"https://[E3D7:0000:0000:0000:51F4:9BC8:C0A8:6420]:9999/wsman"
		/// <para>Uses HTTPS and IPv6 with the given port.</para>
		/// </term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsman-createsession HRESULT CreateSession( BSTR
		// connection, long flags, IDispatch *connectionOptions, IDispatch **session );
		[PreserveSig, DispId(1)]
		new HRESULT CreateSession([MarshalAs(UnmanagedType.BStr)] string connection, [Optional] WSManSessionFlags flags,
			IWSManConnectionOptions connectionOptions, out IWSManSession session);

		/// <summary>Creates an IWSManConnectionOptions object that specifies the user name and password used when creating a session.</summary>
		/// <param name="connectionOptions">A pointer to a new IWSManConnectionOptions object.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsman-createconnectionoptions HRESULT
		// CreateConnectionOptions( IDispatch **connectionOptions );
		[PreserveSig, DispId(2)]
		new HRESULT CreateConnectionOptions(out IWSManConnectionOptions connectionOptions);

		/// <summary>
		/// <para>Gets the command line of the process that loads the automation component.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/winrm/wsman-commandline WSMan.CommandLine As BSTR
		[DispId(3)]
		new string CommandLine
		{
			[DispId(3)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>
		/// Gets additional error information, in an XML stream, for the preceding call to an IWSMan method if Windows Remote Management
		/// service was unable to create an IWSManSession object, an IWSManConnectionOptions object, or an IWSManResourceLocator object.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsman-get_error HRESULT get_Error( BSTR *value );
		[DispId(4)]
		new string Error
		{
			[DispId(4)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// Creates a ResourceLocator object that can be used instead of a resource URI in Session object operations such as
		/// IWSManSession.Get, IWSManSession.Put, or Session.Enumerate.
		/// </summary>
		/// <param name="strResourceLocator">
		/// The resource URI for the resource. For more information about URI strings, see Resource URIs.
		/// </param>
		/// <param name="newResourceLocator">A pointer to a new instance of IWSManResourceLocator.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// If the <c>FragmentDialect</c> property is not specified in the IWSManResourceLocator object, the default is the XPath 1.0
		/// specification. For more information, see http://www.w3.org/TR/xpath.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanex-createresourcelocator HRESULT
		// CreateResourceLocator( BSTR strResourceLocator, IDispatch **newResourceLocator );
		[PreserveSig, DispId(5)]
		new HRESULT CreateResourceLocator([MarshalAs(UnmanagedType.BStr)] string strResourceLocator,
			out IWSManResourceLocator newResourceLocator);

		/// <summary>
		/// <para>
		/// The WSMan.SessionFlagUTF8 method returns the value of the authentication flag <c>WSManFlagUTF8</c> for use in the flags
		/// parameter of IWSMan::CreateSession.
		/// </para>
		/// <para>
		/// <c>WSManFlagUTF8</c> is a constant in the <c>__WSManSessionFlags</c> enumeration. For more information, see Other Session Constants.
		/// </para>
		/// </summary>
		/// <returns>The value of the constant.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanex-sessionflagutf8 HRESULT SessionFlagUTF8(
		// long *flags );
		[DispId(6)]
		new WSManSessionFlags SessionFlagUTF8();

		/// <summary>
		/// <para>
		/// The <c>IWSMan.SessionFlagCredUsernamePassword</c> method returns the value of the authentication flag
		/// <c>WSManFlagCredUsernamePassword</c> for use in the flags parameter of IWSMan::CreateSession.
		/// </para>
		/// <para>
		/// <c>WSManFlagCredUsernamePassword</c> is a constant in the <c>__WSManSessionFlags</c> enumeration. For more information, see
		/// Authentication Constants.
		/// </para>
		/// </summary>
		/// <returns>The value of the constant.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanex-sessionflagcredusernamepassword HRESULT
		// SessionFlagCredUsernamePassword( long *flags );
		[DispId(7)]
		new WSManSessionFlags SessionFlagCredUsernamePassword();

		/// <summary>
		/// <para>
		/// The WSMan.SessionFlagSkipCACheck method returns the value of the <c>WSManFlagSkipCACheck</c> authentication flag for use in
		/// the flags parameter of the IWSMan::CreateSession method.
		/// </para>
		/// <para>
		/// <c>WSManFlagSkipCACheck</c> is a constant in the <c>__WSManSessionFlags</c> enumeration. For more information, see
		/// Authentication Constants.
		/// </para>
		/// </summary>
		/// <returns>The value of the constant.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanex-sessionflagskipcacheck HRESULT
		// SessionFlagSkipCACheck( long *flags );
		[DispId(8)]
		new WSManSessionFlags SessionFlagSkipCACheck();

		/// <summary>
		/// <para>
		/// The WSMan.SessionFlagSkipCNCheck method returns the value of the authentication flag <c>WSManFlagSkipCNCheck</c> for use in
		/// the flags parameter of IWSMan::CreateSession.
		/// </para>
		/// <para>
		/// <c>WSManFlagSkipCNCheck</c> is a constant in the <c>__WSManSessionFlags</c> enumeration. For more information, see
		/// Authentication Constants.
		/// </para>
		/// </summary>
		/// <returns>The value of the constant.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanex-sessionflagskipcncheck HRESULT
		// SessionFlagSkipCNCheck( long *flags );
		[DispId(9)]
		new WSManSessionFlags SessionFlagSkipCNCheck();

		/// <summary>
		/// <para>
		/// The WSMan.SessionFlagUseDigest method returns the value of the authentication flag <c>WSManFlagUseDigest</c> for use in the
		/// flags parameter of IWSMan::CreateSession.
		/// </para>
		/// <para>
		/// <c>WSManFlagUseDigest</c> is a constant in the <c>__WSManSessionFlags</c> enumeration. For more information, see
		/// Authentication Constants.
		/// </para>
		/// </summary>
		/// <returns>The value of the constant.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanex-sessionflagusedigest HRESULT
		// SessionFlagUseDigest( long *flags );
		[DispId(10)]
		new WSManSessionFlags SessionFlagUseDigest();

		/// <summary>
		/// <para>
		/// The WSMan.SessionFlagUseNegotiate method returns the value of the authentication flag <c>WSManFlagUseNegotiate</c> for use
		/// in the flags parameter of IWSMan::CreateSession.
		/// </para>
		/// <para>
		/// <c>WSManFlagUseNegotiate</c> is a constant in the <c>__WSManSessionFlags</c> enumeration. For more information, see
		/// Authentication Constants.
		/// </para>
		/// </summary>
		/// <returns>The value of the constant.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanex-sessionflagusenegotiate HRESULT
		// SessionFlagUseNegotiate( long *flags );
		[DispId(11)]
		new WSManSessionFlags SessionFlagUseNegotiate();

		/// <summary>
		/// <para>
		/// The WSMan.SessionFlagUseBasic method returns the value of the authentication flag <c>WSManFlagUseBasic</c> for use in the
		/// flags parameter of IWSMan::CreateSession.
		/// </para>
		/// <para>
		/// <c>WSManFlagUseBasic</c> is a constant in the <c>__WSManSessionFlags</c> enumeration. For more information, see
		/// Authentication Constants.
		/// </para>
		/// </summary>
		/// <returns>The value of the constant.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanex-sessionflagusebasic HRESULT
		// SessionFlagUseBasic( long *flags );
		[DispId(12)]
		new WSManSessionFlags SessionFlagUseBasic();

		/// <summary>
		/// <para>
		/// The WSMan.WSMan.SessionFlagUseKerberos method returns the value of the authentication flag <c>WSManFlagUseKerberos</c> for
		/// use in the flags parameter of IWSMan::CreateSession.
		/// </para>
		/// <para>
		/// <c>WSManFlagUseKerberos</c> is a constant in the <c>__WSManSessionFlags</c> enumeration. For more information, see
		/// Authentication Constants.
		/// </para>
		/// </summary>
		/// <returns>The value of the constant.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanex-sessionflagusekerberos HRESULT
		// SessionFlagUseKerberos( long *flags );
		[DispId(13)]
		new WSManSessionFlags SessionFlagUseKerberos();

		/// <summary>
		/// <para>
		/// The WSMan.SessionFlagNoEncryption method returns the value of the authentication flag <c>WSManFlagNoEncryption</c> for use
		/// in the flags parameter of IWSMan::CreateSession.
		/// </para>
		/// <para>
		/// <c>WSManFlagNoEncryption</c> is a constant in the <c>__WSManSessionFlags</c> enumeration. For more information, see Other
		/// Session Constants.
		/// </para>
		/// </summary>
		/// <returns>The value of the constant.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanex-sessionflagnoencryption HRESULT
		// SessionFlagNoEncryption( long *flags );
		[DispId(14)]
		new WSManSessionFlags SessionFlagNoEncryption();

		/// <summary>
		/// <para>
		/// The WSMan.SessionFlagEnableSPNServerPort method returns the value of the authentication flag
		/// <c>WSManFlagEnableSPNServerPort</c> for use in the flags parameter of IWSMan::CreateSession.
		/// </para>
		/// <para>
		/// <c>WSManFlagEnableSPNServerPort</c> is a constant in the <c>__WSManSessionFlags</c> enumeration. For more information, see
		/// Other Session Constants.
		/// </para>
		/// </summary>
		/// <returns>The value of the constant.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanex-sessionflagenablespnserverport HRESULT
		// SessionFlagEnableSPNServerPort( long *flags );
		[DispId(15)]
		new WSManSessionFlags SessionFlagEnableSPNServerPort();

		/// <summary>
		/// <para>
		/// The WSMan.SessionFlagUseNoAuthentication method returns the value of the authentication flag
		/// <c>WSManFlagUseNoAuthentication</c> for use in the flags parameter of IWSMan::CreateSession.
		/// </para>
		/// <para>
		/// <c>WSManFlagUseNoAuthentication</c> is a constant in the <c>__WSManSessionFlags</c> enumeration. For more information, see
		/// Authentication Constants.
		/// </para>
		/// </summary>
		/// <returns>The value of the constant.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanex-sessionflagusenoauthentication HRESULT
		// SessionFlagUseNoAuthentication( long *flags );
		[DispId(16)]
		new WSManSessionFlags SessionFlagUseNoAuthentication();

		/// <summary>
		/// <para>
		/// The <c>IWSManEx::EnumerationFlagNonXmlText</c> method returns the value of the enumeration constant
		/// <c>WSManFlagNonXmlText</c> for use in the flags parameter of the IWSManSession::Enumerate method.
		/// </para>
		/// <para>
		/// <c>WSManFlagNonXmlText</c> is a constant in the <c>__WSManEnumFlags</c> enumeration. For more information, see Enumeration Constants.
		/// </para>
		/// </summary>
		/// <returns>The value of the constant.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanex-enumerationflagnonxmltext HRESULT
		// EnumerationFlagNonXmlText( long *flags );
		[DispId(17)]
		new WSManEnumFlags EnumerationFlagNonXmlText();

		/// <summary>
		/// <para>
		/// The <c>IWSManEx::EnumerationFlagReturnEPR</c> method returns the value of the enumeration constant
		/// <c>EnumerationFlagReturnEPR</c> for use in the flags parameter of the IWSManSession::Enumerate method.
		/// </para>
		/// <para>
		/// <c>EnumerationFlagReturnEPR</c> is a constant in the <c>_WSManEnumFlags</c> enumeration and is described in Enumeration Constants.
		/// </para>
		/// </summary>
		/// <returns>The value of the constant.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanex-enumerationflagreturnepr HRESULT
		// EnumerationFlagReturnEPR( long *flags );
		[DispId(18)]
		new WSManEnumFlags EnumerationFlagReturnEPR();

		/// <summary>
		/// <para>
		/// The <c>IWSManEx::EnumerationFlagReturnObjectAndEPR</c> method returns the value of the enumeration constant
		/// <c>EnumerationFlagReturnObjectAndEPR</c> for use in the flags parameter of the IWSManSession::Enumerate method.
		/// </para>
		/// <para>
		/// <c>EnumerationFlagReturnObjectAndEPR</c> is a constant in the <c>_WSManEnumFlags</c> enumeration and is described in
		/// Enumeration Constants.
		/// </para>
		/// </summary>
		/// <returns>The value of the constant.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanex-enumerationflagreturnobjectandepr HRESULT
		// EnumerationFlagReturnObjectAndEPR( long *flags );
		[DispId(19)]
		new WSManEnumFlags EnumerationFlagReturnObjectAndEPR();

		/// <summary>
		/// Returns a formatted string containing the text of an error number. This method performs the same operation as the
		/// <c>Winrm</c> command-line <c>winrm helpmsg</c> error number.
		/// </summary>
		/// <param name="errorNumber">
		/// Error message number in decimal or hexadecimal from WinRM, WinHTTP, or other operating system components.
		/// </param>
		/// <param name="errorMessage">Error message string formatted like messages returned from the <c>Winrm</c> command.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>The corresponding scripting method is WSMan.GetErrorMessage.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanex-geterrormessage HRESULT GetErrorMessage(
		// DWORD errorNumber, BSTR *errorMessage );
		[PreserveSig, DispId(20)]
		new HRESULT GetErrorMessage(uint errorNumber, [MarshalAs(UnmanagedType.BStr)] out string errorMessage);

		/// <summary>
		/// <para>
		/// The <c>IWSManEx::EnumerationFlagHierarchyDeep</c> method returns the value of the enumeration constant
		/// <c>EnumerationFlagHierarchyDeep</c> for use in the flags parameter of the IWSManSession::Enumerate method.
		/// </para>
		/// <para>
		/// <c>EnumerationFlagHierarchyDeep</c> is a constant in the <c>_WSManEnumFlags</c> enumeration and is described in Enumeration Constants.
		/// </para>
		/// </summary>
		/// <returns>The value of the constant.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanex-enumerationflaghierarchydeep HRESULT
		// EnumerationFlagHierarchyDeep( long *flags );
		[DispId(21)]
		new WSManEnumFlags EnumerationFlagHierarchyDeep();

		/// <summary>
		/// <para>
		/// The <c>IWSManEx::EnumerationFlagHierarchyShallow</c> method returns the value of the enumeration constant
		/// <c>EnumerationFlagHierarchyShallow</c> for use in the flags parameter of the IWSManSession::Enumerate method.
		/// </para>
		/// <para>
		/// <c>EnumerationFlagHierarchyShallow</c> is a constant in the <c>_WSManEnumFlags</c> enumeration and is described in
		/// Enumeration Constants.
		/// </para>
		/// </summary>
		/// <returns>The value of the constant.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanex-enumerationflaghierarchyshallow HRESULT
		// EnumerationFlagHierarchyShallow( long *flags );
		[DispId(22)]
		new WSManEnumFlags EnumerationFlagHierarchyShallow();

		/// <summary>
		/// <para>
		/// The <c>IWSManEx::EnumerationFlagHierarchyDeepBasePropsOnly</c> method returns the value of the enumeration constant
		/// <c>EnumerationFlagHierarchyDeepBasePropsOnly</c> for use in the flags parameter of the IWSManSession::Enumerate method.
		/// </para>
		/// <para>
		/// <c>EnumerationFlagHierarchyDeepBasePropsOnly</c> is a constant in the <c>_WSManEnumFlags</c> enumeration and is described in
		/// Enumeration Constants.
		/// </para>
		/// </summary>
		/// <returns>The value of the constant.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanex-enumerationflaghierarchydeepbasepropsonly
		// HRESULT EnumerationFlagHierarchyDeepBasePropsOnly( long *flags );
		[DispId(23)]
		new WSManEnumFlags EnumerationFlagHierarchyDeepBasePropsOnly();

		/// <summary>
		/// <para>
		/// The <c>IWSManEx::EnumerationFlagReturnObject</c> method returns the value of the enumeration constant
		/// <c>EnumerationFlagReturnObject</c> for use in the flags parameter of the IWSManSession::Enumerate method.
		/// </para>
		/// <para>
		/// <c>EnumerationFlagReturnObject</c> is a constant in the <c>_WSManEnumFlags</c> enumeration and is described in Enumeration Constants.
		/// </para>
		/// </summary>
		/// <returns>The value of the constant.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanex-enumerationflagreturnobject HRESULT
		// EnumerationFlagReturnObject( long *flags );
		[DispId(24)]
		new WSManEnumFlags EnumerationFlagReturnObject();

		/// <summary>
		/// <para>
		/// Returns the value of the authentication flag <c>WSManFlagUseClientCertificate</c> for use in the flags parameter of IWSMan::CreateSession.
		/// </para>
		/// <para>
		/// <c>WSManFlagUseClientCertificate</c> is a constant in the <c>__WSManSessionFlags</c> enumeration. For more information, see
		/// Authentication Constants.
		/// </para>
		/// </summary>
		/// <returns>The session flags to use.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanex2-sessionflaguseclientcertificate HRESULT
		// SessionFlagUseClientCertificate( long *flags );
		[DispId(25)]
		new WSManSessionFlags SessionFlagUseClientCertificate();

		/// <summary>
		/// <para>
		/// The WSMan.SessionFlagUTF16 method returns the value of the authentication flag <c>WSManFlagUTF16</c> for use in the flags
		/// parameter of IWSMan::CreateSession.
		/// </para>
		/// <para>
		/// <c>WSManFlagUTF16</c> is a constant in the <c>__WSManSessionFlags</c> enumeration. For more information, see Other Session Constants.
		/// </para>
		/// </summary>
		/// <returns>The value of the constant.</returns>
		[DispId(26)]
		WSManSessionFlags SessionFlagUTF16();

		/// <summary>
		/// <para>Returns the value of the authentication flag <c>WSManFlagUseCredSsp</c> for use in the flags parameter of IWSMan::CreateSession.</para>
		/// <para>
		/// <c>WSManFlagUseCredSsp</c> is a constant in the <c>__WSManSessionFlags</c> enumeration. For more information, see
		/// Authentication Constants.
		/// </para>
		/// </summary>
		/// <returns>The value of the constant.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanex3-sessionflagusecredssp HRESULT
		// SessionFlagUseCredSsp( long *flags );
		[DispId(27)]
		WSManSessionFlags SessionFlagUseCredSsp();

		/// <summary>
		/// <para>
		/// Returns the value of the enumeration constant <c>WSManFlagAssociationInstance</c> for use in the flags parameter of the
		/// IWSManSession::Enumerate method.
		/// </para>
		/// <para>
		/// <c>WSManFlagAssociationInstance</c> is a constant in the <c>_WSManEnumFlags</c> enumeration and is described in Enumeration Constants.
		/// </para>
		/// </summary>
		/// <returns>The value of the constant.</returns>
		[DispId(28)]
		WSManEnumFlags EnumerationFlagAssociationInstance();

		/// <summary>
		/// <para>
		/// Returns the value of the enumeration constant <c>WSManFlagAssociatedInstance</c> for use in the flags parameter of the
		/// IWSManSession::Enumerate method.
		/// </para>
		/// <para>
		/// <c>WSManFlagAssociatedInstance</c> is a constant in the <c>_WSManEnumFlags</c> enumeration and is described in Enumeration Constants.
		/// </para>
		/// </summary>
		/// <returns>The value of the constant.</returns>
		[DispId(29)]
		WSManEnumFlags EnumerationFlagAssociatedInstance();

		/// <summary>
		/// <para>
		/// Returns the value of the authentication flag <c>WSManFlagSkipRevocationCheck</c> for use in the flags parameter of IWSMan::CreateSession.
		/// </para>
		/// <para>
		/// <c>WSManFlagSkipRevocationCheck</c> is a constant in the <c>__WSManSessionFlags</c> enumeration. For more information, see
		/// Authentication Constants.
		/// </para>
		/// </summary>
		/// <returns>The value of the constant.</returns>
		[DispId(30)]
		WSManSessionFlags SessionFlagSkipRevocationCheck();

		/// <summary>
		/// <para>
		/// Returns the value of the authentication flag <c>WSManFlagAllowNegotiateImplicitCredentials</c> for use in the flags
		/// parameter of IWSMan::CreateSession.
		/// </para>
		/// <para>
		/// <c>WSManFlagAllowNegotiateImplicitCredentials</c> is a constant in the <c>__WSManSessionFlags</c> enumeration. For more
		/// information, see Authentication Constants.
		/// </para>
		/// </summary>
		/// <returns>The value of the constant.</returns>
		[DispId(31)]
		WSManSessionFlags SessionFlagAllowNegotiateImplicitCredentials();

		/// <summary>
		/// <para>Returns the value of the authentication flag <c>WSManFlagUseSsl</c> for use in the flags parameter of IWSMan::CreateSession.</para>
		/// <para>
		/// <c>WSManFlagUseSsl</c> is a constant in the <c>__WSManSessionFlags</c> enumeration. For more information, see Authentication Constants.
		/// </para>
		/// </summary>
		/// <returns>The value of the constant.</returns>
		[DispId(32)]
		WSManSessionFlags SessionFlagUseSsl();
	}

	/// <summary>
	/// Supplies the path to a resource. You can use an <c>IWSManResourceLocator</c> object instead of a resource URI in IWSManSession
	/// object operations such as IWSManSession.Get, IWSManSession.Put, or IWSManSession.Enumerate.
	/// </summary>
	/// <remarks>The corresponding scripting object is ResourceLocator.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nn-wsmandisp-iwsmanresourcelocator
	[PInvokeData("wsmandisp.h", MSDNShortId = "NN:wsmandisp.IWSManResourceLocator")]
	[ComImport, Guid("A7A1BA28-DE41-466a-AD0A-C4059EAD7428"), InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface IWSManResourceLocator
	{
		/// <summary>
		/// <para>
		/// The resource URI of the requested resource. This property can contain only the path, not a query string for specific instances.
		/// </para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>
		/// <para>The following is an example of a proper path for <c>ResourceURI</c>.</para>
		/// <para>
		/// <code>"http://schemas.microsoft.com/wbem/wsman/1/wmi/root/cimv2/Win32_Service"</code>
		/// </para>
		/// <para>
		/// The following path does not work because it contains a key for a specific instance. Use the
		/// <c>ResourceLocator.AddSelector</c> method to specify a particular instance.
		/// </para>
		/// <para>
		/// <code>"http://schemas.microsoft.com/wbem/wsman/1/wmi/root/cimv2/Win32_Service?Name=winmgmt"</code>
		/// </para>
		/// <para><c>IWSManResourceLocator::ResourceURI</c> is the corresponding C++ method.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/winrm/resourcelocator-resourceuri ResourceLocator.ResourceURI As string
		[DispId(1)]
		string ResourceUri
		{
			[DispId(1)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;

			[DispId(1)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// Adds a selector to the ResourceLocator object. The selector specifies a particular instance of a resource. You can provide
		/// an IWSManResourceLocator object instead of specifying a resource URI in IWSManSession object operations such as Get, Put, or Enumerate.
		/// </summary>
		/// <param name="resourceSelName">
		/// The selector name. For example, when requesting WMI data, this parameter is the key property for a WMI class.
		/// </param>
		/// <param name="selValue">
		/// The selector value. For example, for WMI data, this parameter contains a value for a key property that identifies a specific instance.
		/// </param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanresourcelocator-addselector HRESULT
		// AddSelector( BSTR resourceSelName, VARIANT selValue );
		[PreserveSig, DispId(2)]
		HRESULT AddSelector([MarshalAs(UnmanagedType.BStr)] string resourceSelName, [In, MarshalAs(UnmanagedType.Struct)] object selValue);

		/// <summary>
		/// Removes all the selectors from a ResourceLocator object. You can provide a ResourceLocator object instead of specifying a
		/// resource URI in IWSManSession object operations such as Get, Put, or Enumerate.
		/// </summary>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanresourcelocator-clearselectors HRESULT ClearSelectors();
		[PreserveSig, DispId(3)]
		HRESULT ClearSelectors();

		/// <summary>
		/// <para>
		/// Gets or sets the path for a resource fragment or property when <c>ResourceLocator</c> is used in <c>Session</c> object
		/// operations such as <c>Session.Get</c>, <c>Session.Put</c>, or <c>Session.Enumerate</c>.
		/// </para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>
		/// <para><c>IWSManResourceLocator::FragmentPath</c> is the corresponding C++ property.</para>
		/// <para>
		/// You can specify one element of an array property by supplying the array index as shown in the following example. Be aware
		/// that array indexing starts with 1 rather than 0.
		/// </para>
		/// <para>
		/// <code>Const Uri = "http://schemas.microsoft.com/wbem/wsman/1/wmi/root/cimv2/Win32_NetworkAdapterConfiguration" Const FragmentPath = "DNSServerSearchOrder[1]"</code>
		/// </para>
		/// <para>To get the whole array, specify the array property name as shown in the following example.</para>
		/// <para>
		/// <code>Const Uri = "http://schemas.microsoft.com/wbem/wsman/1/wmi/root/cimv2/Win32_NetworkAdapterConfiguration" Const FragmentPath = "DNSServerSearchOrder"</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/winrm/resourcelocator-fragmentpath ResourceLocator.FragmentPath
		[DispId(4)]
		string FragmentPath
		{
			[DispId(4)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(4)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>
		/// Gets or sets the language dialect for a resource fragment dialect when <c>ResourceLocator</c> is used in <c>Session</c>
		/// object operations such as <c>Session.Get</c>, <c>Session.Put</c>, or <c>Session.Enumerate</c>. A fragment represents one
		/// property or part of a resource. You can provide a <c>ResourceLocator</c> object instead of specifying a resource URI in
		/// <c>Session</c> object operations. The dialect indicates what XML language describes the fragment to the service that
		/// implements the WS-Management Protocol and receives the request.
		/// </para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks><c>IWSManResourceLocator::FragmentDialect</c> is the corresponding C++ property.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/winrm/resourcelocator-fragmentdialect ResourceLocator.FragmentDialect As string
		[DispId(5)]
		string FragmentDialect
		{
			[DispId(5)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(5)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// Adds data required to process the request. For example, some WMI providers may require an IWbemContext or SWbemNamedValueSet
		/// object with provider-specific information. You can provide a ResourceLocator object instead of specifying a resource URI in
		/// IWSManSession object operations such as Get, Put, or Enumerate.
		/// </summary>
		/// <param name="OptionName">The name of the optional data object.</param>
		/// <param name="OptionValue">A value supplied for the optional data object.</param>
		/// <param name="mustComply">A flag that indicates the option must be processed. The default is <c>False</c> (0).</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanresourcelocator-addoption HRESULT AddOption(
		// BSTR OptionName, VARIANT OptionValue, BOOL mustComply );
		[PreserveSig, DispId(6)]
		HRESULT AddOption([MarshalAs(UnmanagedType.BStr)] string OptionName, [In, MarshalAs(UnmanagedType.Struct)] object OptionValue,
			[MarshalAs(UnmanagedType.Bool)] bool mustComply);

		/// <summary>
		/// <para>
		/// Gets or sets the <c>MustUnderstandOptions</c> value for the ResourceLocator object. You can provide an IWSManResourceLocator
		/// object instead of specifying a resource URI in IWSManSession object operations such as Get, Put, or Enumerate.
		/// </para>
		/// <para>This property is read/write.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanresourcelocator-put_mustunderstandoptions
		// HRESULT put_MustUnderstandOptions( BOOL mustUnderstand );
		[DispId(7)]
		bool MustUnderstandOptions
		{
			[DispId(7)]
			[return: MarshalAs(UnmanagedType.Bool)]
			get;
			[DispId(7)]
			[param: In, MarshalAs(UnmanagedType.Bool)]
			set;
		}

		/// <summary>
		/// Removes any options from the ResourceLocator object. You can provide a ResourceLocator object instead of specifying a
		/// resource URI in IWSManSession object operations such as Get, Put, or Enumerate.
		/// </summary>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanresourcelocator-clearoptions HRESULT ClearOptions();
		[PreserveSig, DispId(8)]
		HRESULT ClearOptions();

		/// <summary>
		/// <para>Gets an XML representation of additional error information.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmanresourcelocator-get_error HRESULT get_Error(
		// BSTR *value );
		[DispId(9)]
		string Error
		{
			[DispId(9)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}
	}

	/// <summary>
	/// Defines operations and session settings. Any Windows Remote Management operations require creation of an <c>IWSManSession</c>
	/// object that connects to a remote computer, base management controller (BMC), or the local computer. WinRM network operations
	/// include getting, writing, enumerating data, or invoking methods. The methods of the <c>IWSManSession</c> object mirror the basic
	/// operations defined in the WS-Management protocol.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nn-wsmandisp-iwsmansession
	[PInvokeData("wsmandisp.h", MSDNShortId = "NN:wsmandisp.IWSManSession")]
	[ComImport, Guid("FC84FC58-1286-40c4-9DA0-C8EF6EC241E0"), InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface IWSManSession
	{
		/// <summary>
		/// Retrieves the resource specified by the URI and returns an XML representation of the current instance of the resource.
		/// </summary>
		/// <param name="resourceUri">
		/// <para>The identifier of the resource to be retrieved.</para>
		/// <para>This parameter can contain one of the following:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// URI with or without selectors. When calling the Get method to obtain a WMI resource, use the key property or properties of
		/// the object.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ResourceLocator object which may contain selectors, fragments, or options.</term>
		/// </item>
		/// <item>
		/// <term>
		/// WS-Addressing endpoint reference as described in the WS-Management protocol standard. For more information about the public
		/// specification for the WS-Management protocol, see Management Specifications Index Page.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="flags">Reserved for future use. Must be set to 0.</param>
		/// <param name="resource">A value that, upon success, is an XML representation of the resource.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmansession-get HRESULT Get( VARIANT resourceUri,
		// long flags, BSTR *resource );
		[PreserveSig, DispId(1)]
		HRESULT Get([In, MarshalAs(UnmanagedType.Struct)] object resourceUri, [Optional] int flags,
			[MarshalAs(UnmanagedType.BStr)] out string resource);

		/// <summary>Updates a resource.</summary>
		/// <param name="resourceUri">
		/// <para>The identifier of the resource to be updated.</para>
		/// <para>This parameter can contain one of the following:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// URI with or without selectors. When calling the <c>Put</c> method to obtain a WMI resource, use the key property or
		/// properties of the object.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ResourceLocator object which may contain selectors, fragments, or options.</term>
		/// </item>
		/// <item>
		/// <term>
		/// WS-Addressing endpoint reference as described in the WS-Management protocol standard. For more information about the public
		/// specification for the WS-Management protocol, see Management Specifications Index Page.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="resource">The updated resource content.</param>
		/// <param name="flags">Reserved for future use. Must be set to 0.</param>
		/// <param name="resultResource">The XML stream that contains the updated resource content.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmansession-put HRESULT Put( VARIANT resourceUri,
		// BSTR resource, long flags, BSTR *resultResource );
		[PreserveSig, DispId(2)]
		HRESULT Put([In, MarshalAs(UnmanagedType.Struct)] object resourceUri, [MarshalAs(UnmanagedType.BStr)] string resource,
			[Optional] int flags, [MarshalAs(UnmanagedType.BStr)] out string resultResource);

		/// <summary>Creates a new instance of a resource and returns the endpoint reference (EPR) of the new object.</summary>
		/// <param name="resourceUri">
		/// <para>The identifier of the resource to create.</para>
		/// <para>This parameter can contain one of the following:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// URI with one or more selectors. Be aware that the WMI plug-in does not support creating any resource other than a
		/// WS-Management protocol listener.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ResourceLocator object which may contain selectors, fragments, or options.</term>
		/// </item>
		/// <item>
		/// <term>
		/// WS-Addressing endpoint reference as described in the WS-Management protocol standard. For more information about the public
		/// specification for the WS-Management protocol, see Management Specifications Index Page.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="resource">An XML string that contains resource content.</param>
		/// <param name="flags">Reserved. Must be set to 0.</param>
		/// <param name="newUri">The EPR of the new resource.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// <c>IWSManSession::Create</c> is only used for creating new instances of a resource. Use the IWSManSession::Put method to
		/// update existing instances of a resource. After you obtain the new resource URI, you can call IWSManSession::Get to retrieve
		/// the new object. The new object contains any properties that the resource provider assigns when creating the new object. For
		/// example, if you create a new WS-Management protocollistener and retrieve the listener object using Session.Get, then you
		/// also obtain the <c>Port</c>, <c>Enabled</c>, and <c>ListeningOn</c> properties.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmansession-create HRESULT Create( VARIANT
		// resourceUri, BSTR resource, long flags, BSTR *newUri );
		[PreserveSig, DispId(3)]
		HRESULT Create([In, MarshalAs(UnmanagedType.Struct)] object resourceUri, [MarshalAs(UnmanagedType.BStr)] string resource,
			[Optional] int flags, [MarshalAs(UnmanagedType.BStr)] out string newUri);

		/// <summary>Deletes the resource specified in the resource URI.</summary>
		/// <param name="resourceUri">
		/// The URI of the resource to be deleted. You can also use an IWSManResourceLocator object to specify the resource.
		/// </param>
		/// <param name="flags">Reserved for future use. Must be set to 0.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmansession-delete HRESULT Delete( VARIANT
		// resourceUri, long flags );
		[PreserveSig, DispId(4)]
		HRESULT Delete([In, MarshalAs(UnmanagedType.Struct)] object resourceUri, [Optional] int flags);

		/// <summary>Invokes a method and returns the results of the method call.</summary>
		/// <param name="actionUri">The URI of the method to invoke.</param>
		/// <param name="resourceUri">
		/// <para>The identifier of the resource to invoke a method.</para>
		/// <para>This parameter can contain one of the following:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>URI with or without selectors.</term>
		/// </item>
		/// <item>
		/// <term>ResourceLocator object which may contain selectors, fragments, or options.</term>
		/// </item>
		/// <item>
		/// <term>
		/// WS-Addressing endpoint reference as described in the WS-Management protocol standard. For more information about the public
		/// specification for the WS-Management protocol, see Management Specifications Index Page.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="parameters">
		/// An XML representation of the input for the method. This string must be supplied or this method will fail.
		/// </param>
		/// <param name="flags">Reserved for future use. Must be set to 0.</param>
		/// <param name="result">An XML representation of the method output.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmansession-invoke HRESULT Invoke( BSTR
		// actionUri, VARIANT resourceUri, BSTR parameters, long flags, BSTR *result );
		[PreserveSig, DispId(5)]
		HRESULT Invoke([MarshalAs(UnmanagedType.BStr)] string actionUri, [In, MarshalAs(UnmanagedType.Struct)] object resourceUri,
			[MarshalAs(UnmanagedType.BStr)] string parameters, [Optional] int flags, [MarshalAs(UnmanagedType.BStr)] out string result);

		/// <summary>
		/// Enumerates a table, data collection, or log resource. To create a query, include a filter parameter and a dialect parameter
		/// in an enumeration. You can also use an IWSManResourceLocator object to create queries. For more information, see Enumerating
		/// or Listing All the Instances of a Resource.
		/// </summary>
		/// <param name="resourceUri">
		/// <para>The identifier of the resource to be retrieved.</para>
		/// <para>The following list contains identifiers that this parameter can contain:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// URI with one or more selectors. When calling the <c>Enumerate</c> method to obtain a WMI resource, use the key property or
		/// properties of the object.
		/// </term>
		/// </item>
		/// <item>
		/// <term>You can use selectors, fragments, or options. For more information, see IWSManResourceLocator.</term>
		/// </item>
		/// <item>
		/// <term>
		/// WS-Addressing endpoint reference as described in the WS-Management protocol standard. For more information about the public
		/// specification for the WS-Management protocol, see the Management Specifications Index Page.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="filter">
		/// <para>
		/// A filter that defines what items in the resource are returned by the enumeration. When the resource is enumerated, only
		/// those items that match the filter criteria are returned. Including a filter parameter and a dialect parameter in an
		/// enumeration converts the enumeration into a query.
		/// </para>
		/// <para>
		/// If you have an IWSManResourceLocator object for the resourceURI parameter, then this parameter should not be used. Instead,
		/// use the selector and fragment functionality of <c>IWSManResourceLocator</c>.
		/// </para>
		/// </param>
		/// <param name="dialect">
		/// <para>The language used by the filter. WQL, a subset of SQL used by WMI, is the only language supported.</para>
		/// <para>
		/// If you have a IWSManResourceLocator object for the resourceURI parameter, then this parameter should not be used. Instead,
		/// use the selector and fragment functionality of <c>IWSManResourceLocator</c>.
		/// </para>
		/// </param>
		/// <param name="flags">
		/// This parameter must contain a flag in the <c>__WSManEnumFlags</c> enumeration. For more information, see Enumeration Constants.
		/// </param>
		/// <param name="resultSet">An IWSManEnumerator object that contains the results of the enumeration.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// <para>
		/// Call <c>IWSManSession::Enumerate</c> to start an enumeration operation. Thereafter, call IWSManEnumerator::ReadItem using
		/// the returned IWSManEnumerator object until the end of items is indicated by the AtEndOfStream property.
		/// </para>
		/// <para>
		/// Be aware that if the flags include the Enumeration Constants <c>WSManFlagHierarchyDeepBasePropsOnly</c> or
		/// <c>WSManFlagHierarchyShallow</c> then Windows Remote Management service returns the error code <c>ERROR_WSMAN_POLYMORPHISM_MODE_UNSUPPORTED</c>.
		/// </para>
		/// <para>For more information about limiting network calls during an enumeration, see the BatchItems property.</para>
		/// <para>
		/// If a filter is specified, it must be a valid document with respect to the schema of the resource. The dialect parameter is
		/// optional. However, if the filter string begins with &lt;, but is not an XML fragment, then either include the dialect
		/// parameter or set the <c>WSManFlagNonXmlText</c> flag in the flags parameter. For more information, see Enumeration Constants.
		/// </para>
		/// <para>The corresponding scripting method is Session.Enumerate.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmansession-enumerate HRESULT Enumerate( VARIANT
		// resourceUri, BSTR filter, BSTR dialect, long flags, IDispatch **resultSet );
		[PreserveSig, DispId(6)]
		HRESULT Enumerate([In, MarshalAs(UnmanagedType.Struct)] object resourceUri, [MarshalAs(UnmanagedType.BStr)] string filter,
			[MarshalAs(UnmanagedType.BStr)] string dialect, WSManEnumFlags flags, out IWSManEnumerator resultSet);

		/// <summary>
		/// The <c>IWSManSession::Identify</c> method queries a remote computer to determine if it supports the WS-Management protocol.
		/// For more information, see Detecting Whether a Remote Computer Supports WS-Management Protocol.
		/// </summary>
		/// <param name="flags">The only flag that is accepted is <c>WSManFlagUseNoAuthentication</c>.</param>
		/// <param name="result">
		/// A value that, upon success, is an XML string that specifies the WS-Management protocol version, the operating system vendor
		/// and, if the request was sent authenticated, the operating system version.
		/// </param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmansession-identify HRESULT Identify( long
		// flags, BSTR *result );
		[PreserveSig, DispId(7)]
		HRESULT Identify(WSManSessionFlags flags, [MarshalAs(UnmanagedType.BStr)] out string result);

		/// <summary>
		/// <para>Gets additional error information in an XML stream for the preceding call to an IWSManSession object method.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nf-wsmandisp-iwsmansession-get_error HRESULT get_Error( BSTR
		// *value );
		[DispId(8)]
		string Error
		{
			[DispId(8)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>
		/// Sets and gets the number of items in each enumeration batch. This value cannot be changed during an enumeration. The
		/// resource provider may set a limit.
		/// </para>
		/// <para>This property is read-write.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsmandisp/nn-wsmandisp-iwsmanenumerator
		[DispId(9)]
		int BatchItems
		{
			[DispId(9)]
			get;

			[DispId(9)]
			[param: In]
			set;
		}

		/// <summary>
		/// <para>
		/// Sets and gets the maximum amount of time, in milliseconds, that the client application waits for Windows Remote Management
		/// to complete its operations.
		/// </para>
		/// <para>This property is read-write.</para>
		/// </summary>
		[DispId(10)]
		int Timeout
		{
			[DispId(10)]
			get;

			[DispId(10)]
			[param: In]
			set;
		}
	}

	/// <summary>Provides methods and properties used to create a session, represented by a <c>Session</c> object. Any Windows Remote Management operations require creation of a <c>Session</c> that connects to a remote computer, base management controller (BMC), or the local computer. Operations include getting, writing, enumerating data, or invoking methods.</summary>
	/// <remarks>The <c>WSMan</c> object corresponds to the <c>IWSMan</c> and <c>IWSManEx</c> interfaces. <c>WSMan</c> is the only object that can be created directly using CreateObject.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/winrm/wsman
	[PInvokeData("wsmandisp.h")]
	[ComImport, Guid("BCED617B-EC03-420b-8508-977DC7A686BD"), ClassInterface(ClassInterfaceType.None)]
	public class WSMan { }
}