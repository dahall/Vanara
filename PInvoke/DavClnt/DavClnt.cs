namespace Vanara.PInvoke;

/// <summary>Items from the DavClnt.dll.</summary>
public static partial class DavClnt
{
	private const string Lib_DavClnt = "DavClnt.dll";

	/// <summary>
	/// <para>The WebDAV client calls the application-defined DavAuthCallback callback function to prompt the user for credentials.</para>
	/// <para>
	/// The PFNDAVAUTHCALLBACK type defines a pointer to this callback function. DavAuthCallback is a placeholder for the
	/// application-defined function name.
	/// </para>
	/// </summary>
	/// <param name="lpwzServerName">A pointer to a <c>NULL</c>-terminated Unicode string that contains the name of the target server.</param>
	/// <param name="lpwzRemoteName">A pointer to a <c>NULL</c>-terminated Unicode string that contains the name of the network resource.</param>
	/// <param name="dwAuthScheme">
	/// <para>A bitmask of flags that specify the authentication schemes to be used.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>DAV_AUTHN_SCHEME_BASIC 0x00000001</term>
	/// <term>Basic authentication is to be used.</term>
	/// </item>
	/// <item>
	/// <term>DAV_AUTHN_SCHEME_NTLM 0x00000002</term>
	/// <term>Microsoft NTLM authentication is to be used.</term>
	/// </item>
	/// <item>
	/// <term>DAV_AUTHN_SCHEME_PASSPORT 0x00000004</term>
	/// <term>Passport authentication is to be used.</term>
	/// </item>
	/// <item>
	/// <term>DAV_AUTHN_SCHEME_DIGEST 0x00000008</term>
	/// <term>Microsoft Digest authentication is to be used.</term>
	/// </item>
	/// <item>
	/// <term>DAV_AUTHN_SCHEME_NEGOTIATE 0x00000010</term>
	/// <term>Microsoft Negotiate is to be used.</term>
	/// </item>
	/// <item>
	/// <term>DAV_AUTHN_SCHEME_CERT 0x00010000</term>
	/// <term>Certificate authentication is to be used.</term>
	/// </item>
	/// <item>
	/// <term>DAV_AUTHN_SCHEME_FBA 0x00100000</term>
	/// <term>Forms-based authentication is to be used.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwFlags">
	/// The flags that the WebDAV service passed in the dwFlags parameter when it called the NPAddConnection3 function.
	/// </param>
	/// <param name="pCallbackCred">A pointer to a DAV_CALLBACK_CRED structure.</param>
	/// <param name="NextStep">The next step.</param>
	/// <param name="pFreeCred">The p free cred.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code.</para>
	/// </returns>
	/// <remarks>
	/// <para>The DavAuthCallback callback function must be registered by calling the DavRegisterAuthCallback function.</para>
	/// <para>To unregister this callback function, use the DavUnregisterAuthCallback function.</para>
	/// <para>
	/// This callback function should prompt the user for credentials (either a user name and password or an authentication BLOB) and
	/// store this information in the appropriate member of the DAV_CALLBACK_CRED structure that the pCallbackCred parameter points to.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/davclnt/nc-davclnt-pfndavauthcallback PFNDAVAUTHCALLBACK Pfndavauthcallback;
	// DWORD Pfndavauthcallback( LPWSTR lpwzServerName, LPWSTR lpwzRemoteName, DWORD dwAuthScheme, DWORD dwFlags, PDAV_CALLBACK_CRED
	// pCallbackCred, AUTHNEXTSTEP *NextStep, PFNDAVAUTHCALLBACK_FREECRED *pFreeCred ) {...}
	[PInvokeData("davclnt.h", MSDNShortId = "6ac191ac-e63f-431f-893b-92c69320db58")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Unicode)]
	public delegate Win32Error DavAuthCallback(string lpwzServerName, string lpwzRemoteName, DAV_AUTHN_SCHEME dwAuthScheme, uint dwFlags,
		ref DAV_CALLBACK_CRED pCallbackCred, ref AUTHNEXTSTEP NextStep, out DavFreeCredCallback pFreeCred);

	/// <summary>
	/// <para>
	/// The WebDAV client calls the application-defined DavFreeCredCallback callback function to free the credential information that was
	/// retrieved by the DavAuthCallback callback function.
	/// </para>
	/// <para>
	/// The PFNDAVAUTHCALLBACK_FREECRED type defines a pointer to this callback function. DavFreeCredCallback is a placeholder for the
	/// application-defined function name.
	/// </para>
	/// </summary>
	/// <param name="pbuffer">
	/// A pointer to the DAV_CALLBACK_AUTH_UNP or DAV_CALLBACK_AUTH_BLOB structure that was used in the DavAuthCallback callback function.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code.</para>
	/// </returns>
	/// <remarks>
	/// <para>The DavFreeCredCallback callback function must be registered by calling the DavRegisterAuthCallback function.</para>
	/// <para>
	/// This callback function should free only the buffer that the <c>pBuffer</c> member of the DAV_CALLBACK_AUTH_UNP or
	/// DAV_CALLBACK_AUTH_BLOB structure points to, not the entire structure.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/davclnt/nc-davclnt-pfndavauthcallback_freecred PFNDAVAUTHCALLBACK_FREECRED
	// PfndavauthcallbackFreecred; DWORD PfndavauthcallbackFreecred( PVOID pbuffer ) {...}
	[PInvokeData("davclnt.h", MSDNShortId = "96bacda5-8f24-4119-b0ae-82ff8aff54b4")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Unicode)]
	public delegate Win32Error DavFreeCredCallback(IntPtr pbuffer);

	/// <summary>
	/// <para>Specifies the next action that the WebDAV client should take after a successful call to the DavAuthCallback callback function.</para>
	/// </summary>
	/// <remarks>
	/// <para>This enumeration provides the values for the NextStep parameter of the DavAuthCallback callback function.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/davclnt/ne-davclnt-__unnamed_enum_0 typedef enum { DefaultBehavior,
	// RetryRequest, CancelRequest } ;
	[PInvokeData("davclnt.h", MSDNShortId = "e9ce9e61-c395-4f6b-843c-c1caa13ac3b4")]
	public enum AUTHNEXTSTEP
	{
		/// <summary>
		/// Retry the connection request without using the DavAuthCallback callback function. This is the same as the default behavior if
		/// no callback function is registered.
		/// </summary>
		DefaultBehavior,

		/// <summary>Retry the connection request using the credentials that were retrieved by the DavAuthCallback function.</summary>
		RetryRequest,

		/// <summary>Cancel the connection request.</summary>
		CancelRequest,
	}

	/// <summary>Authentication scheme.</summary>
	[PInvokeData("davclnt.h", MSDNShortId = "6ac191ac-e63f-431f-893b-92c69320db58")]
	[Flags]
	public enum DAV_AUTHN_SCHEME
	{
		/// <summary>Basic authentication is to be used.</summary>
		DAV_AUTHN_SCHEME_BASIC = 0x00000001,

		/// <summary>Microsoft NTLM authentication is to be used.</summary>
		DAV_AUTHN_SCHEME_NTLM = 0x00000002,

		/// <summary>Passport authentication is to be used.</summary>
		DAV_AUTHN_SCHEME_PASSPORT = 0x00000004,

		/// <summary>Microsoft Digest authentication is to be used.</summary>
		DAV_AUTHN_SCHEME_DIGEST = 0x00000008,

		/// <summary>Microsoft Negotiate is to be used.</summary>
		DAV_AUTHN_SCHEME_NEGOTIATE = 0x00000010,

		/// <summary>Certificate authentication is to be used.</summary>
		DAV_AUTHN_SCHEME_CERT = 0x00010000,

		/// <summary>Forms-based authentication is to be used.</summary>
		DAV_AUTHN_SCHEME_FBA = 0x00100000,
	}

	/// <summary>Creates a secure connection to a WebDAV server or to a remote file or directory on a WebDAV server.</summary>
	/// <param name="ConnectionHandle">A pointer to a variable that receives the connection handle.</param>
	/// <param name="RemoteName">
	/// A pointer to a <c>null</c>-terminated Unicode string that contains the path to the remote file or directory. This string must
	/// begin with the "https://" prefix.
	/// </param>
	/// <param name="UserName">
	/// A pointer to a <c>null</c>-terminated Unicode string that contains the user name to be used for the connection. This parameter is
	/// optional and can be <c>NULL</c>.
	/// </param>
	/// <param name="Password">
	/// A pointer to a <c>null</c>-terminated Unicode string that contains the password to be used for the connection. This parameter is
	/// optional and can be <c>NULL</c>.
	/// </param>
	/// <param name="ClientCert">
	/// A pointer to a buffer that contains the client certificate to be used for the connection. The certificate must be in a serialized form.
	/// </param>
	/// <param name="CertSize">Size, in bytes, of the client certificate.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code.</para>
	/// </returns>
	/// <remarks>
	/// <para>To close the connection, use the DavDeleteConnection function.</para>
	/// <para>
	/// Use this function when you are connecting to a WebDAV server using the Secure Sockets Layer (SSL) protocol and therefore must
	/// specify a certificate. To connect to a WebDAV server without specifying a certificate, use a Windows networking function such as
	/// WNetAddConnection2 or WNetAddConnection3.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/davclnt/nf-davclnt-davaddconnection DWORD DavAddConnection( HANDLE
	// *ConnectionHandle, LPCWSTR RemoteName, LPCWSTR UserName, LPCWSTR Password, PBYTE ClientCert, DWORD CertSize );
	[DllImport(Lib_DavClnt, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("davclnt.h", MSDNShortId = "d69cba04-503c-4d21-b762-3094c0921e28")]
	public static extern Win32Error DavAddConnection(out SafeDavConnectionHandle ConnectionHandle, string RemoteName, string? UserName, string? Password, IntPtr ClientCert, uint CertSize);

	/// <summary>Closes all connections to a WebDAV server or a remote file or directory on a WebDAV server.</summary>
	/// <param name="lpName">
	/// <para>
	/// Pointer to a null-terminated Unicode string that contains the name of the remote file or server. This string must be in one of
	/// the following formats:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>http://server/path</term>
	/// </item>
	/// <item>
	/// <term>\\server\path</term>
	/// </item>
	/// <item>
	/// <term>server</term>
	/// </item>
	/// </list>
	/// <para>where</para>
	/// <para>server</para>
	/// <para>is the name of a WebDAV server, and</para>
	/// <para>path</para>
	/// <para>is the path to a remote file or directory on the server.</para>
	/// </param>
	/// <param name="fForce">
	/// A Boolean value that specifies whether the connection should be closed if there are open files. Set this parameter to
	/// <c>FALSE</c> if the connection should be closed only if there are no open files. Set this parameter to <c>TRUE</c> if the
	/// connection should be closed even if there are open files.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code or network error code such as one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>The lpName parameter contained a value that was not valid.</term>
	/// </item>
	/// <item>
	/// <term>WN_BAD_NETNAME</term>
	/// <term>The lpName parameter contained a value that was not a valid remote file name.</term>
	/// </item>
	/// <item>
	/// <term>WN_NOT_CONNECTED</term>
	/// <term>No connections to the remote file or server were found.</term>
	/// </item>
	/// <item>
	/// <term>WN_OPEN_FILES</term>
	/// <term>There are open files on the connection, and fForce parameter was set to FALSE.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/davclnt/nf-davclnt-davcancelconnectionstoserver DWORD
	// DavCancelConnectionsToServer( LPWSTR lpName, BOOL fForce );
	[DllImport(Lib_DavClnt, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("davclnt.h", MSDNShortId = "6eb3b011-4cd3-45ec-a07e-c8743d35a176")]
	public static extern Win32Error DavCancelConnectionsToServer(string lpName, [MarshalAs(UnmanagedType.Bool)] bool fForce);

	/// <summary>Closes a connection that was created by using the DavAddConnection function.</summary>
	/// <param name="ConnectionHandle">A handle to an open connection that was created by using the DavAddConnection function.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/davclnt/nf-davclnt-davdeleteconnection DWORD DavDeleteConnection( HANDLE
	// ConnectionHandle );
	[DllImport(Lib_DavClnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("davclnt.h", MSDNShortId = "736b8a16-30db-410e-8295-97730297d04b")]
	public static extern Win32Error DavDeleteConnection(HANDLE ConnectionHandle);

	/// <summary>Flushes the data from the local version of a remote file to the WebDAV server.</summary>
	/// <param name="hFile">
	/// <para>A handle to an open file on a WebDAV server.</para>
	/// <para>The file handle must have the GENERIC_WRITE access right. For more information, see File Security and Access Rights.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, or if hFile is a handle to an encrypted file, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// When an application creates or opens a remote file on a WebDAV server, the WebDAV service downloads the file to the local
	/// computer, and the application receives a handle to the open file on the server. Any changes that the application makes to the
	/// local file have no effect on the remote file until the file handle is closed and the local version of the file is uploaded to the
	/// server. Because the file handle is closed at the same time that the file is saved to the server, the application cannot check
	/// whether the file was saved successfully.
	/// </para>
	/// <para>
	/// To avoid this problem, use the <c>DavFlushFile</c> function to flush the data from the local version of the file to the remote
	/// file on the WebDAV server. If the function succeeds, this means that the file was saved successfully.
	/// </para>
	/// <para>
	/// This function does not flush encrypted files. If hFile is a handle to an encrypted file, <c>DavFlushFile</c> returns
	/// ERROR_SUCCESS without flushing the file data.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/davclnt/nf-davclnt-davflushfile DWORD DavFlushFile( HANDLE hFile );
	[DllImport(Lib_DavClnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("davclnt.h", MSDNShortId = "0022a5ba-a4b2-4289-91be-db7f52e62f91")]
	public static extern Win32Error DavFlushFile(HANDLE hFile);

	/// <summary>Retrieves the extended error code information that the WebDAV server returned for the previous failed I/O operation.</summary>
	/// <param name="hFile">
	/// A handle to an open file for which the previous I/O operation has failed. If the previous operation is a failed create operation,
	/// in which case there is no open file handle, specify INVALID_HANDLE_VALUE for this parameter.
	/// </param>
	/// <param name="ExtError">Pointer to a variable that receives the extended error code.</param>
	/// <param name="ExtErrorString">
	/// Pointer to a buffer that receives the extended error information as a null-terminated Unicode string.
	/// </param>
	/// <param name="cChSize">
	/// <para>
	/// A pointer to a variable that on input specifies the size, in Unicode characters, of the buffer that the ExtErrorString parameter
	/// points to. This value must be at least 1024 characters.
	/// </para>
	/// <para>
	/// If the function succeeds, on output the variable receives the number of characters that are actually copied into the buffer. If
	/// the function fails with ERROR_INSUFFICIENT_BUFFER, the variable receives 1024, but no characters are copied into the
	/// ExtErrorString buffer.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code, such as one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>One or more parameter values were not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSUFFICIENT_BUFFER</term>
	/// <term>The value that the cChSize parameter points to was less than 1024.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>If you call this function for a file handle whose previous I/O operation was successful, it returns ERROR_INVALID_PARAMETER.</remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/davclnt/nf-davclnt-davgetextendederror DWORD DavGetExtendedError( HANDLE
	// hFile, DWORD *ExtError, LPWSTR ExtErrorString, DWORD *cChSize );
	[DllImport(Lib_DavClnt, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("davclnt.h", MSDNShortId = "939b6163-b7ae-4ab7-9bcc-a02cbf34ca63")]
	public static extern Win32Error DavGetExtendedError(HANDLE hFile, out Win32Error ExtError, StringBuilder ExtErrorString, ref uint cChSize);

	/// <summary>Converts the specified UNC path to an equivalent HTTP path.</summary>
	/// <param name="UncPath">
	/// <para>A pointer to a <c>null</c>-terminated Unicode string that contains the UNC path. This path must be in the following format:</para>
	/// <para>\server[@SSL][@port][&lt;i&gt;path]</para>
	/// <para>where</para>
	/// <list type="bullet">
	/// <item>
	/// <term>server is the server name.</term>
	/// </item>
	/// <item>
	/// <term>@SSL is optional and indicates a request for an SSL connection.</term>
	/// </item>
	/// <item>
	/// <term>port is an optional port number. The standard ports are 80 for http and 443 for https (SSL).</term>
	/// </item>
	/// <item>
	/// <term>path is optional and specifies a path to a remote file or directory on the server.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="Url">A pointer to a caller-allocated buffer that receives the HTTP path as a <c>null</c>-terminated Unicode string.</param>
	/// <param name="lpSize">
	/// A pointer to a variable that on input specifies the maximum size, in Unicode characters, of the buffer that the HttpPath
	/// parameter points to. If the function succeeds, on output the variable receives the number of characters that were copied into the
	/// buffer. If the function fails with ERROR_INSUFFICIENT_BUFFER, on output the variable receives the number of characters needed to
	/// store the HTTP path, including the "http://" or "https://" prefix and the terminating <c>NULL</c> character.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code, such as the following value.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INSUFFICIENT_BUFFER</term>
	/// <term>The buffer that the HttpPath parameter points to was not large enough to store the HTTP path.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/davclnt/nf-davclnt-davgethttpfromuncpath DWORD DavGetHTTPFromUNCPath( LPCWSTR
	// UncPath, LPWSTR Url, LPDWORD lpSize );
	[DllImport(Lib_DavClnt, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("davclnt.h", MSDNShortId = "caa83e54-a029-45aa-9681-26b2be54fea3")]
	public static extern Win32Error DavGetHTTPFromUNCPath(string UncPath, StringBuilder Url, ref uint lpSize);

	/// <summary>Returns the file lock owner for a file that is locked on a WebDAV server.</summary>
	/// <param name="FileName">
	/// <para>
	/// A pointer to a <c>null</c>-terminated Unicode string that contains the name of a locked file on the WebDAV server. This string
	/// must be in one of the following formats:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>\\server\path\filename</term>
	/// </item>
	/// <item>
	/// <term>drive:\filename</term>
	/// </item>
	/// </list>
	/// <para>where</para>
	/// <para>server</para>
	/// <para>is the name of a server,</para>
	/// <para>path</para>
	/// <para>is the path to a remote file on the server,</para>
	/// <para>filename</para>
	/// <para>is a valid file name, and</para>
	/// <para>drive</para>
	/// <para>is the drive letter that a remote share is mapped to on the local computer. (A</para>
	/// <para>share</para>
	/// <para>is a directory on a server that is made available to users over the network.)</para>
	/// </param>
	/// <param name="LockOwnerName">
	/// A pointer to a caller-allocated buffer that receives the name of the owner of the file lock. This parameter is optional and can
	/// be <c>NULL</c>. If it is <c>NULL</c>, the LockOwnerNameLengthInBytes parameter must point to zero on input.
	/// </param>
	/// <param name="LockOwnerNameLengthInBytes">
	/// A pointer to a variable that on input specifies the maximum size, in Unicode characters, of the buffer that the LockOwnerName
	/// parameter points to. If the function succeeds, on output the variable receives the number of characters that were copied into the
	/// buffer. If the function fails with ERROR_INSUFFICIENT_BUFFER, on output the variable receives the number of characters needed to
	/// store the lock owner name, including the terminating <c>NULL</c> character.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code, such as one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INSUFFICIENT_BUFFER</term>
	/// <term>The buffer that the LockOwnerName parameter points to was not large enough to store the lock owner name.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>
	/// One or more parameter values were not valid. For example, this error code is returned if the FileName parameter is a null pointer.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If a call to a function such as CreateFile for a file on a WebDAV server fails with ERROR_LOCK_VIOLATION, you can use the
	/// <c>DavGetTheLockOwnerOfTheFile</c> function to determine the owner of the file lock.
	/// </para>
	/// <para>
	/// To obtain the required buffer length for the LockOwnerName buffer, call <c>DavGetTheLockOwnerOfTheFile</c> with LockOwnerName set
	/// to <c>NULL</c> and LockOwnerNameLengthInBytes set to zero. The return value is ERROR_INSUFFICIENT_BUFFER, and on output the
	/// LockOwnerNameLengthInBytes parameter receives the required buffer length.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/davclnt/nf-davclnt-davgetthelockownerofthefile DWORD
	// DavGetTheLockOwnerOfTheFile( LPCWSTR FileName, PWSTR LockOwnerName, PULONG LockOwnerNameLengthInBytes );
	[DllImport(Lib_DavClnt, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("davclnt.h", MSDNShortId = "94a4607c-2770-4656-8710-987d6b951e0e")]
	public static extern Win32Error DavGetTheLockOwnerOfTheFile(string FileName, StringBuilder? LockOwnerName, ref uint LockOwnerNameLengthInBytes);

	/// <summary>Converts the specified HTTP path to an equivalent UNC path.</summary>
	/// <param name="Url">
	/// <para>
	/// A pointer to a <c>null</c>-terminated Unicode string that contains the HTTP path. This string can be in any of the following
	/// formats, where server is the server name and path is the path to a remote file or directory on the server:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>http://server/path</term>
	/// </item>
	/// <item>
	/// <term>http://server</term>
	/// </item>
	/// <item>
	/// <term>\\http://server/path</term>
	/// </item>
	/// <item>
	/// <term>\\http://server</term>
	/// </item>
	/// <item>
	/// <term>https://server/path</term>
	/// </item>
	/// <item>
	/// <term>https://server</term>
	/// </item>
	/// <item>
	/// <term>\\https://server/path</term>
	/// </item>
	/// <item>
	/// <term>\\https://server</term>
	/// </item>
	/// <item>
	/// <term>\\server\path</term>
	/// </item>
	/// <item>
	/// <term>\\server</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="UncPath">
	/// A pointer to a caller-allocated buffer that receives the UNC path as a <c>null</c>-terminated Unicode string.
	/// </param>
	/// <param name="lpSize">
	/// A pointer to a variable that on input specifies the maximum size, in Unicode characters, of the buffer that the UncPath parameter
	/// points to. If the function succeeds, on output the variable receives the number of characters that were copied into the buffer,
	/// including the terminating <c>NULL</c> character. If the function fails with ERROR_INSUFFICIENT_BUFFER, on output the variable
	/// receives the number of characters needed to store the UNC path, including the terminating <c>NULL</c> character.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code, such as the following value.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INSUFFICIENT_BUFFER</term>
	/// <term>The buffer that the UncPath parameter points to was not large enough to store the UNC path.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/davclnt/nf-davclnt-davgetuncfromhttppath DWORD DavGetUNCFromHTTPPath( LPCWSTR
	// Url, LPWSTR UncPath, LPDWORD lpSize );
	[DllImport(Lib_DavClnt, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("davclnt.h", MSDNShortId = "e9613e4a-5ba1-4954-bc7a-7843249f031e")]
	public static extern Win32Error DavGetUNCFromHTTPPath(string Url, StringBuilder UncPath, ref uint lpSize);

	/// <summary>Invalidates the contents of the local cache for a remote file on a WebDAV server.</summary>
	/// <param name="URLName">
	/// A pointer to a Unicode string that contains the name of a remote file on a WebDAV server. This name can be an HTTP path name
	/// (URL) or a UNC path name.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>DavInvalidateCache</c> function marks the contents of the locally cached file (for the specified URL) for deletion. If
	/// this function succeeds, the local file cache is no longer valid. This function fails if there are any handles opened against the
	/// file either by the same process or by a different process on the local computer.
	/// </para>
	/// <para>
	/// If the item that is named in the URLName parameter is not present in the cache, <c>DavInvalidateCache</c> returns ERROR_SUCCESS
	/// without invalidating the cache.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/davclnt/nf-davclnt-davinvalidatecache DWORD DavInvalidateCache( LPCWSTR
	// URLName );
	[DllImport(Lib_DavClnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("davclnt.h", MSDNShortId = "f111b19c-5472-463a-b33d-7d2188d224e8")]
	public static extern Win32Error DavInvalidateCache([MarshalAs(UnmanagedType.LPWStr)] string URLName);

	/// <summary>Registers an application-defined callback function that the WebDAV client can use to prompt the user for credentials.</summary>
	/// <param name="CallBack">A pointer to a function of type PFNDAVAUTHCALLBACK.</param>
	/// <param name="Version">This parameter is reserved for future use.</param>
	/// <returns>
	/// If the function succeeds, the return value is an opaque handle. Note that <c>OPAQUE_HANDLE</c> is defined to be a <c>DWORD</c> value.
	/// </returns>
	/// <remarks>
	/// <para>The WebDAV client uses the callback function when it is unable to connect to a remote resource using default credentials.</para>
	/// <para>
	/// To unregister the callback function, use the DavUnregisterAuthCallback function, passing the returned opaque handle in the
	/// hCallback parameter.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/davclnt/nf-davclnt-davregisterauthcallback OPAQUE_HANDLE
	// DavRegisterAuthCallback( PFNDAVAUTHCALLBACK CallBack, ULONG Version );
	[DllImport(Lib_DavClnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("davclnt.h", MSDNShortId = "7b381929-174f-4b7b-aa22-dc7a2c3e3b4d")]
	public static extern uint DavRegisterAuthCallback(DavAuthCallback CallBack, uint Version);

	/// <summary>Unregisters a registered callback function that the WebDAV client uses to prompt the user for credentials.</summary>
	/// <param name="hCallback">The opaque handle that was returned by the DavRegisterAuthCallback function.</param>
	/// <remarks>To register the callback function, use the DavRegisterAuthCallback function.</remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/davclnt/nf-davclnt-davunregisterauthcallback void DavUnregisterAuthCallback(
	// OPAQUE_HANDLE hCallback );
	[DllImport(Lib_DavClnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("davclnt.h", MSDNShortId = "5277d9ce-22e6-49d5-9a9c-c02993605bdf")]
	public static extern void DavUnregisterAuthCallback(uint hCallback);

	/// <summary>Stores an authentication BLOB that was retrieved by the DavAuthCallback callback function.</summary>
	/// <remarks>
	/// <para>This structure is included as a member in the DAV_CALLBACK_CRED structure.</para>
	/// <para>
	/// The DavFreeCredCallback callback function should free only the buffer that the <c>pBuffer</c> member points to, not the entire structure.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/davclnt/ns-davclnt-_dav_callback_auth_blob typedef struct
	// _DAV_CALLBACK_AUTH_BLOB { PVOID pBuffer; ULONG ulSize; ULONG ulType; } DAV_CALLBACK_AUTH_BLOB, *PDAV_CALLBACK_AUTH_BLOB;
	[PInvokeData("davclnt.h", MSDNShortId = "59976cb0-ed68-4db0-b8f8-cfe5e778916b")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DAV_CALLBACK_AUTH_BLOB
	{
		/// <summary>A pointer to a buffer that receives the authentication BLOB.</summary>
		public IntPtr pBuffer;

		/// <summary>The size, in bytes, of the buffer that the <c>pBuffer</c> member points to.</summary>
		public uint ulSize;

		/// <summary>
		/// <para>The data type of the buffer that the <c>pBuffer</c> member points to.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>1</term>
		/// <term>PCCERT_CONTEXT</term>
		/// </item>
		/// </list>
		/// </summary>
		public uint ulType;
	}

	/// <summary>Stores user name and password information that was retrieved by the DavAuthCallback callback function.</summary>
	/// <remarks>
	/// <para>This structure is included as a member in the DAV_CALLBACK_CRED structure.</para>
	/// <para>
	/// The DavFreeCredCallback callback function should free only the buffer that the <c>pBuffer</c> member points to, not the entire structure.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/davclnt/ns-davclnt-_dav_callback_auth_unp typedef struct
	// _DAV_CALLBACK_AUTH_UNP { LPWSTR pszUserName; ULONG ulUserNameLength; LPWSTR pszPassword; ULONG ulPasswordLength; }
	// DAV_CALLBACK_AUTH_UNP, *PDAV_CALLBACK_AUTH_UNP;
	[PInvokeData("davclnt.h", MSDNShortId = "47420a67-bf3f-40d9-bfc4-ac2cb2776a40")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DAV_CALLBACK_AUTH_UNP
	{
		/// <summary>
		/// A pointer to a string that contains the user name. This string is allocated by the DavAuthCallback callback function.
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pszUserName;

		/// <summary>The length, in WCHAR, of the user name, not including the terminating <c>NULL</c> character.</summary>
		public uint ulUserNameLength;

		/// <summary>A pointer to a string that contains the password. This string is allocated by DavAuthCallback.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pszPassword;

		/// <summary>The length, in WCHAR, of the password, not including the terminating <c>NULL</c> character.</summary>
		public uint ulPasswordLength;
	}

	/// <summary>Stores user credential information that was retrieved by the DavAuthCallback callback function.</summary>
	/// <remarks>This structure is used by the DavAuthCallback callback function.</remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/davclnt/ns-davclnt-_dav_callback_cred typedef struct _DAV_CALLBACK_CRED {
	// DAV_CALLBACK_AUTH_BLOB AuthBlob; DAV_CALLBACK_AUTH_UNP UNPBlob; BOOL bAuthBlobValid; BOOL bSave; } DAV_CALLBACK_CRED, *PDAV_CALLBACK_CRED;
	[PInvokeData("davclnt.h", MSDNShortId = "5414d7b5-b506-4d0a-a4b8-89ab7878d674")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct DAV_CALLBACK_CRED
	{
		/// <summary>
		/// If the <c>bAuthBlobValid</c> member is <c>TRUE</c>, this member is a DAV_CALLBACK_AUTH_BLOB structure that contains the user
		/// credential information.
		/// </summary>
		public DAV_CALLBACK_AUTH_BLOB AuthBlob;

		/// <summary>
		/// If the <c>bAuthBlobValid</c> member is <c>FALSE</c>, this member is a DAV_CALLBACK_AUTH_UNP structure that contains the user
		/// credential information.
		/// </summary>
		public DAV_CALLBACK_AUTH_UNP UNPBlob;

		/// <summary>
		/// <c>TRUE</c> if the credential information is stored in the <c>AuthBlob</c> member, and the <c>UNPBlob</c> member should be
		/// ignored. <c>FALSE</c> if it is stored in the <c>UNPBlob</c> member, and the <c>AuthBlob</c> member should be ignored.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool bAuthBlobValid;

		/// <summary><c>TRUE</c> if the credential information was written to the credential manager, or <c>FALSE</c> otherwise.</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool bSave;
	}

	/// <summary>Provides a <see cref="SafeHandle"/> for a WebDAV connection that is disposed using <see cref="DavDeleteConnection"/>.</summary>
	[AutoSafeHandle("DavDeleteConnection(handle).Succeeded")]
	public partial class SafeDavConnectionHandle { }
}