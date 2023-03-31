using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.AdvApi32;
using static Vanara.PInvoke.Crypt32;
using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;

namespace Vanara.PInvoke;

/// <summary>Items from the P2P.dll</summary>
public static partial class P2P
{
	/// <summary>
	/// The <c>PeerCreatePeerName</c> function creates a new name based on the existing name of the specified peer identity and
	/// classifier. However, a new identity is not created by a call to <c>PeerCreatePeerName</c>.
	/// </summary>
	/// <param name="pwzIdentity">
	/// <para>
	/// Specifies the identity to use as the basis for the new peer name. If pwzIdentity is <c>NULL</c>, the name created is not based
	/// on any peer identity, and is therefore an unsecured name.
	/// </para>
	/// <para>This parameter can only be <c>NULL</c> if pwzClassifier is not <c>NULL</c>.</para>
	/// </param>
	/// <param name="pwzClassifier">
	/// <para>
	/// Pointer to the Unicode string that contains the new classifier. This classifier is appended to the existing authority portion of
	/// the peer name of the specified identity. This string is 150 characters long, including the <c>NULL</c> terminator. Specify
	/// <c>NULL</c> to return the peer name of the identity.
	/// </para>
	/// <para>This parameter can only be <c>NULL</c> if pwzIdentity is not <c>NULL</c>.</para>
	/// </param>
	/// <param name="ppwzPeerName">
	/// Pointer that receives a pointer to the new peer name. When this string is not required anymore, free it by calling PeerFreeData.
	/// </param>
	/// <returns>
	/// <para>If the function call succeeds, the return value is <c>S_OK</c>. Otherwise, it returns one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the parameters is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>There is not enough memory to perform the specified operation.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>The parameter ppwzPeername must be set to null before the <c>PeerCreatePeerName</c> function is called.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peercreatepeername NOT_BUILD_WINDOWS_DEPRECATE HRESULT
	// PeerCreatePeerName( PCWSTR pwzIdentity, PCWSTR pwzClassifier, PWSTR *ppwzPeerName );
	[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerCreatePeerName")]
	public static extern HRESULT PeerCreatePeerName([Optional, MarshalAs(UnmanagedType.LPWStr)] string? pwzIdentity, [Optional, MarshalAs(UnmanagedType.LPWStr)] string? pwzClassifier,
		[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(PeerStringMarshaler))] out string ppwzPeerName);

	/// <summary>
	/// The <c>PeerEnumGroups</c> function creates and returns a peer enumeration handle used to enumerate all the peer groups
	/// associated with a specific peer identity.
	/// </summary>
	/// <param name="pwzIdentity">Specifies the peer identity to enumerate groups for.</param>
	/// <param name="phPeerEnum">
	/// Receives a handle to the peer enumeration that contains the list of peer groups that the specified identity is a member of, with
	/// each item represented as a pointer to a PEER_NAME_PAIR structure. Pass this handle to PeerGetNextItem to retrieve the items;
	/// when finished, call PeerEndEnumeration release the memory.
	/// </param>
	/// <returns>
	/// <para>If the function call succeeds, the return value is S_OK. Otherwise, it returns one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the parameters is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>There is not enough memory to perform the specified operation.</term>
	/// </item>
	/// <item>
	/// <term>PEER_E_NOT_FOUND</term>
	/// <term>The specified peer identity cannot be found.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Once the application has obtained the enumeration handle, use PeerGetNextItem and PeerGetItemCount to enumerate the peer groups.
	/// </para>
	/// <para>When enumerating peer groups, PeerGetNextItem returns an array of pointers to PEER_NAME_PAIR structures.</para>
	/// <para>Call PeerEndEnumeration to free the peer enumeration handle when it is no longer required.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peerenumgroups NOT_BUILD_WINDOWS_DEPRECATE HRESULT PeerEnumGroups(
	// PCWSTR pwzIdentity, HPEERENUM *phPeerEnum );
	[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerEnumGroups")]
	public static extern HRESULT PeerEnumGroups([MarshalAs(UnmanagedType.LPWStr)] string pwzIdentity, out SafeHPEERENUM phPeerEnum);

	/// <summary>The <c>PeerEnumGroups</c> function enumerates all the peer groups associated with a specific peer identity.</summary>
	/// <param name="pwzIdentity">Specifies the peer identity to enumerate groups for.</param>
	/// <returns>
	/// The peer enumeration that contains the list of peer groups that the specified identity is a member of, with each item
	/// represented as a pointer to a PEER_NAME_PAIR structure.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peerenumgroups NOT_BUILD_WINDOWS_DEPRECATE HRESULT PeerEnumGroups(
	// PCWSTR pwzIdentity, HPEERENUM *phPeerEnum );
	[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerEnumGroups")]
	public static SafePeerList<PEER_NAME_PAIR> PeerEnumGroups(string pwzIdentity) =>
		PeerEnum<PEER_NAME_PAIR>(() => { PeerEnumGroups(pwzIdentity, out var h).ThrowIfFailed(); return h; });

	/// <summary>
	/// The <c>PeerEnumIdentities</c> function creates and returns a peer enumeration handle used to enumerate all the peer identities
	/// that belong to a specific user.
	/// </summary>
	/// <param name="phPeerEnum">
	/// Receives a handle to the peer enumeration that contains the list of peer identities, with each item represented as a pointer to
	/// a PEER_NAME_PAIR structure. Pass this handle to PeerGetNextItem to retrieve the items; when finished, call PeerEndEnumeration to
	/// release the memory.
	/// </param>
	/// <returns>
	/// <para>If the function call succeeds, the return value is S_OK. Otherwise, it returns one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the parameters is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>There is not enough memory to perform the specified operation.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Once the application has obtained the peer enumeration handle, use PeerGetNextItem and PeerGetItemCount to enumerate the peer identities.
	/// </para>
	/// <para>When enumerating peer identities, PeerGetNextItem returns an array of pointers to PEER_NAME_PAIR structures.</para>
	/// <para>Call PeerEndEnumeration to free the enumeration handle when it is no longer required.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peerenumidentities NOT_BUILD_WINDOWS_DEPRECATE HRESULT
	// PeerEnumIdentities( HPEERENUM *phPeerEnum );
	[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerEnumIdentities")]
	public static extern HRESULT PeerEnumIdentities(out SafeHPEERENUM phPeerEnum);

	/// <summary>The <c>PeerEnumIdentities</c> function enumerates all the peer identities that belong to a specific user.</summary>
	/// <returns>
	/// The peer enumeration that contains the list of peer identities, with each item represented as a pointer to a PEER_NAME_PAIR
	/// structure. ///
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peerenumidentities NOT_BUILD_WINDOWS_DEPRECATE HRESULT
	// PeerEnumIdentities( HPEERENUM *phPeerEnum );
	[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerEnumIdentities")]
	public static SafePeerList<PEER_NAME_PAIR> PeerEnumIdentities() =>
		PeerEnum<PEER_NAME_PAIR>(() => { PeerEnumIdentities(out var h).ThrowIfFailed(); return h; });

	/// <summary>
	/// The <c>PeerIdentityCreate</c> function creates a new peer identity and returns its name. The name of the peer identity must be
	/// passed in all subsequent calls to the Peer Identity Manager, Peer Grouping, or PNRP functions that operate on behalf of the peer
	/// identity. The peer identity name specifies which peer identity is being used.
	/// </summary>
	/// <param name="pwzClassifier">
	/// Specifies the classifier to append to the published peer identity name. This string is a Unicode string, and can be <c>NULL</c>.
	/// This string can only be 150 characters long, including the <c>NULL</c> terminator.
	/// </param>
	/// <param name="pwzFriendlyName">
	/// Specifies the friendly name of the peer identity. This is a Unicode string, and can be <c>NULL</c>. This string can only be 256
	/// characters long, including the <c>NULL</c> terminator. If pwzFriendlyName is <c>NULL</c>, the name of the identity is the
	/// friendly name. The friendly name is optional, and it does not have to be unique.
	/// </param>
	/// <param name="hCryptProv">
	/// <para>
	/// Handle to the cryptographic service provider (CSP) that contains an AT_KEYEXCHANGE key pair of at least 1024 bits in length.
	/// This key pair is used as the basis for a new peer identity. If hCryptProv is zero (0), a new key pair is generated for the peer identity.
	/// </para>
	/// <para>
	/// <c>Note</c> The Identity Manager API does not support a CSP that has user protected keys. If a CSP that has user protected keys
	/// is used, <c>PeerIdentityCreate</c> returns <c>E_INVALIDARG</c>.
	/// </para>
	/// </param>
	/// <param name="ppwzIdentity">
	/// Receives a pointer to the name of an peer identity that is created. This name must be used in all subsequent calls to the Peer
	/// Identity Manager, Peer Grouping, or PNRP functions that operate on behalf of the peer identity. Returns <c>NULL</c> if the peer
	/// identity cannot be created.
	/// </param>
	/// <returns>
	/// <para>If the function call succeeds, the return value is <c>S_OK</c>. Otherwise, it returns one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The handle to the key specified by hCryptProv is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the parameters is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>There is not enough memory to perform the specified operation.</term>
	/// </item>
	/// <item>
	/// <term>PEER_E_ALREADY_EXISTS</term>
	/// <term>The peer identity already exists. Only occurs if an peer identity based on the specified key and classifier already exists.</term>
	/// </item>
	/// <item>
	/// <term>PEER_E_NO_KEY_ACCESS</term>
	/// <term>
	/// Access to the peer identity or peer group keys is denied. Typically, this is caused by an incorrect access control list (ACL)
	/// for the folder that contains the user or computer keys. This can happen when the ACL has been reset manually.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PEER_E_TOO_MANY_IDENTITIES</term>
	/// <term>The peer identity cannot be created because there are too many peer identities.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The key pair and the classifier are used to generate the peer name of a new peer identity. After an peer identity is created, it
	/// is automatically stored on the disk.
	/// </para>
	/// <para>
	/// The name of the identity should be freed by using PeerFreeData. This does not delete the peer identity. To delete the identity,
	/// use PeerIdentityDelete function.
	/// </para>
	/// <para>If hCryptProv is not <c>NULL</c>, it can be released by using CryptReleaseContext after the call returns.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peeridentitycreate NOT_BUILD_WINDOWS_DEPRECATE HRESULT
	// PeerIdentityCreate( PCWSTR pwzClassifier, PCWSTR pwzFriendlyName, HCRYPTPROV hCryptProv, PWSTR *ppwzIdentity );
	[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerIdentityCreate")]
	public static extern HRESULT PeerIdentityCreate([Optional, MarshalAs(UnmanagedType.LPWStr)] string? pwzClassifier,
		[Optional, MarshalAs(UnmanagedType.LPWStr)] string? pwzFriendlyName, [In, Optional] HCRYPTPROV hCryptProv,
		[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(PeerStringMarshaler))] out string ppwzIdentity);

	/// <summary>
	/// The <c>PeerIdentityDelete</c> function permanently deletes a peer identity. This includes removing all certificates, private
	/// keys, and all group information associated with a specified peer identity.
	/// </summary>
	/// <param name="pwzIdentity">Specifies a peer identity to delete.</param>
	/// <returns>
	/// <para>If the function call succeeds, the return value is <c>S_OK</c>. Otherwise, it returns one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>The parameter is not valid.</term>
	/// </item>
	/// <item>
	/// <term>PEER_E_GROUPS_EXIST</term>
	/// <term>
	/// The peer identity cannot be deleted because it has peer groups associated with it. All peer groups associated with the specified
	/// identity must be deleted by using PeerGroupDelete before a call to PeerIdentityDelete can succeed.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PEER_E_NOT_FOUND</term>
	/// <term>A peer identity that matches the specified name cannot be found.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peeridentitydelete NOT_BUILD_WINDOWS_DEPRECATE HRESULT
	// PeerIdentityDelete( PCWSTR pwzIdentity );
	[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerIdentityDelete")]
	public static extern HRESULT PeerIdentityDelete([MarshalAs(UnmanagedType.LPWStr)] string pwzIdentity);

	/// <summary>
	/// The <c>PeerIdentityExport</c> function allows a user to export one peer identity. The user can then transfer the peer identity
	/// to a different computer.
	/// </summary>
	/// <param name="pwzIdentity">Specifies the peer identity to export. This parameter is required and does not have a default value.</param>
	/// <param name="pwzPassword">
	/// Specifies the password to use to encrypt the peer identity. This parameter cannot be <c>NULL</c>. This password must also be
	/// used to import the peer identity, or the import operation fails.
	/// </param>
	/// <param name="ppwzExportXML">
	/// Receives a pointer to the exported peer identity in XML format. If the export operation is successful, the application must free
	/// ppwzExportXML by calling PeerFreeData.
	/// </param>
	/// <returns>
	/// <para>If the function call succeeds, the return value is <c>S_OK</c>. Otherwise, it returns one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the parameters is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>There is not enough memory to perform the specified operation.</term>
	/// </item>
	/// <item>
	/// <term>PEER_E_NO_KEY_ACCESS</term>
	/// <term>
	/// Access to the peer identity or peer group keys was denied. This is typically caused by an incorrect access control list (ACL)
	/// for the folder that contains the user or computer keys. This can happen when the ACL has been manually reset.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PEER_E_NOT_FOUND</term>
	/// <term>The specified peer identity does not exist.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Peer-to-peer group membership credentials are not exported. Only one peer identity is exported. An exported peer identity can be
	/// imported on another computer by using PeerIdentityImport.
	/// </para>
	/// <para>
	/// Exporting a peer identity does not remove it from a local ccmputer, it makes a copy of it. The copy can be used to backup and
	/// restore a peer identity.
	/// </para>
	/// <para>The XML fragment used by <c>PeerIdentityExport</c> is as follows:</para>
	/// <para>
	/// <code>&lt;PEERIDENTITYEXPORT VERSION="1.0"&gt; &lt;PEERNAME&gt; &lt;!-- UTF-8 encoded peer name of the identity --&gt; &lt;/PEERNAME&gt; &lt;DATA xmlns:dt="urn:schemas-microsoft-com:datatypes" dt:dt="bin.base64"&gt; &lt;!-- base64 encoded / PFX encoded and encrypted IDC with the private key --&gt; &lt;/DATA&gt; &lt;/PEERIDENTITYEXPORT&gt;</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peeridentityexport NOT_BUILD_WINDOWS_DEPRECATE HRESULT
	// PeerIdentityExport( PCWSTR pwzIdentity, PCWSTR pwzPassword, PWSTR *ppwzExportXML );
	[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerIdentityExport")]
	public static extern HRESULT PeerIdentityExport([MarshalAs(UnmanagedType.LPWStr)] string pwzIdentity, [MarshalAs(UnmanagedType.LPWStr)] string pwzPassword,
		[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(PeerStringMarshaler))] out string ppwzExportXML);

	/// <summary>The <c>PeerIdentityGetCryptKey</c> function retrieves a handle to a cryptographic service provider (CSP).</summary>
	/// <param name="pwzIdentity">Specifies the peer identity to retrieve the key pair for.</param>
	/// <param name="phCryptProv">
	/// Receives a pointer to the handle of the cryptographic service provider (CSP) that contains an AT_KEYEXCHANGE RSA key pair.
	/// </param>
	/// <returns>
	/// <para>If the function call succeeds, the return value is <c>S_OK</c>. Otherwise, it returns one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the parameters is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>There is not enough memory to perform the specified operation.</term>
	/// </item>
	/// <item>
	/// <term>PEER_E_NO_KEY_ACCESS</term>
	/// <term>
	/// Access to the peer identity or peer group keys is denied. Typically, this is caused by an incorrect access control list (ACL)
	/// for the folder that contains the user or computer keys. This can happen when the ACL has been manually reset.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PEER_E_NOT_FOUND</term>
	/// <term>An identity that matches the specified name cannot be found.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>The key can be retrieved by calling CryptGetUserKey.</para>
	/// <para>When the handle is not required anymore, the application is responsible for releasing the handle by using <see cref="CryptReleaseContext"/>.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peeridentitygetcryptkey NOT_BUILD_WINDOWS_DEPRECATE HRESULT
	// PeerIdentityGetCryptKey( PCWSTR pwzIdentity, HCRYPTPROV *phCryptProv );
	[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerIdentityGetCryptKey")]
	public static extern HRESULT PeerIdentityGetCryptKey([MarshalAs(UnmanagedType.LPWStr)] string pwzIdentity, out SafeHCRYPTPROV phCryptProv);

	/// <summary>The <c>PeerIdentityGetDefault</c> function retrieves the default peer name set for the current user.</summary>
	/// <param name="ppwzPeerName">
	/// Pointer to the address of a zero-terminated Unicode string that contains the default name of the current user.
	/// </param>
	/// <returns>
	/// <para>If the function call succeeds, the return value is <c>S_OK</c>. Otherwise, it returns one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the parameters is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>There is not enough memory to perform the specified operation.</term>
	/// </item>
	/// <item>
	/// <term>PEER_E_NOT_FOUND</term>
	/// <term>A peer identity that matches the specified name cannot be found.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peeridentitygetdefault NOT_BUILD_WINDOWS_DEPRECATE HRESULT
	// PeerIdentityGetDefault( PWSTR *ppwzPeerName );
	[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerIdentityGetDefault")]
	public static extern HRESULT PeerIdentityGetDefault([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(PeerStringMarshaler))] out string ppwzPeerName);

	/// <summary>The <c>PeerIdentityGetFriendlyName</c> function returns the friendly name of the peer identity.</summary>
	/// <param name="pwzIdentity">Specifies the peer identity to obtain a friendly name.</param>
	/// <param name="ppwzFriendlyName">
	/// Receives a pointer to the friendly name. When ppwzFriendlyName is not required anymore, the application is responsible for
	/// freeing this string by calling PeerFreeData.
	/// </param>
	/// <returns>
	/// <para>If the function call succeeds, the return value is <c>S_OK</c>. Otherwise, it returns one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the parameters is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>There is not enough memory to perform the specified operation.</term>
	/// </item>
	/// <item>
	/// <term>PEER_E_NO_KEY_ACCESS</term>
	/// <term>
	/// Access to the peer identity or peer group keys is denied. Typically, this is caused by an incorrect access control list (ACL)
	/// for the folder that contains the user or computer keys. This can happen when the ACL has been reset manually.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PEER_E_NOT_FOUND</term>
	/// <term>A peer identity that matches the specified name cannot be found.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peeridentitygetfriendlyname NOT_BUILD_WINDOWS_DEPRECATE HRESULT
	// PeerIdentityGetFriendlyName( PCWSTR pwzIdentity, PWSTR *ppwzFriendlyName );
	[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerIdentityGetFriendlyName")]
	public static extern HRESULT PeerIdentityGetFriendlyName([MarshalAs(UnmanagedType.LPWStr)] string pwzIdentity,
		[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(PeerStringMarshaler))] out string ppwzFriendlyName);

	/// <summary>
	/// The <c>PeerIdentityGetXML</c> function returns a description of the peer identity, which can then be passed to third parties and
	/// used to invite a peer identity into a peer group. This information is returned as an XML fragment.
	/// </summary>
	/// <param name="pwzIdentity">
	/// Specifies the peer identity to retrieve peer identity information for. When this parameter is passed as <c>NULL</c>, a "default"
	/// identity will be generated for the user by the peer infrastructure.
	/// </param>
	/// <param name="ppwzIdentityXML">
	/// Pointer to a pointer to a Unicode string that contains the XML fragment. When ppwzIdentityXML is no longer required, the
	/// application is responsible for freeing this string by calling PeerFreeData.
	/// </param>
	/// <returns>
	/// <para>If the function call succeeds, the return value is S_OK. Otherwise, it returns one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_HANDLE</term>
	/// <term>The handle to the identity is invalid.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the parameters is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>There is not enough memory to perform the specified operation.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>The XML fragment returned has the following structure:</para>
	/// <para>
	/// <code>&lt;PEERIDENTITYINFO VERSION="1.0"&gt; &lt;IDC xmlns:dt="urn:schemas-microsoft-com:datatypes" dt:dt="bin.base64"&gt; Base 64 encoded certificate. &lt;/IDC&gt; &lt;/PEERIDENTITYINFO&gt;</code>
	/// </para>
	/// <para>This XML fragment is used when creating an invitation to join a group.</para>
	/// <para>
	/// Applications are not allowed to add tags within the <c>PEERIDENTITYINFO</c> tag or modify this XML fragment in any way.
	/// Applications are allowed to incorporate this XML fragment into other XML documents, but must strip out all application-specific
	/// XML before passing this fragment to the PeerGroupCreateInvitation.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peeridentitygetxml NOT_BUILD_WINDOWS_DEPRECATE HRESULT
	// PeerIdentityGetXML( PCWSTR pwzIdentity, PWSTR *ppwzIdentityXML );
	[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerIdentityGetXML")]
	public static extern HRESULT PeerIdentityGetXML([MarshalAs(UnmanagedType.LPWStr)] string pwzIdentity,
		[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(PeerStringMarshaler))] out string ppwzIdentityXML);

	/// <summary>
	/// The <c>PeerIdentityImport</c> function imports one peer identity. If the peer identity exists on a computer,
	/// <c>PEER_E_ALREADY_EXISTS</c> is returned.
	/// </summary>
	/// <param name="pwzImportXML">
	/// Pointer to the XML format peer identity to import, which is returned by PeerIdentityExport. This binary data must match the
	/// exported data byte-for-byte. The XML must remain valid XML with no extra characters.
	/// </param>
	/// <param name="pwzPassword">
	/// Specifies the password to use to de-crypt a peer identity. The password must be identical to the password supplied to
	/// PeerIdentityExport. This parameter cannot be <c>NULL</c>.
	/// </param>
	/// <param name="ppwzIdentity">
	/// Pointer to a string that represents a peer identity that is imported. If the import operation is successful, the application
	/// must free ppwzIdentity by calling PeerFreeData.
	/// </param>
	/// <returns>
	/// <para>If the function call succeeds, the return value is <c>S_OK</c>. Otherwise, it returns one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the parameters is not valid, or the XML data in ppwzImportXML has been tampered with.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>There is not enough memory to perform the specified operation.</term>
	/// </item>
	/// <item>
	/// <term>PEER_E_ALREADY_EXISTS</term>
	/// <term>The peer identity already exists on this computer.</term>
	/// </item>
	/// <item>
	/// <term>PEER_E_NO_KEY_ACCESS</term>
	/// <term>
	/// Access to the peer identity or peer group keys is denied. Typically, this is caused by an incorrect access control list (ACL)
	/// for the folder that contains the user or computer keys. This can happen when the ACL has been reset manually.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>The XML fragment used by <c>PeerIdentityImport</c> is as follows:</para>
	/// <para>
	/// <code>&lt;PEERIDENTITYEXPORT VERSION="1.0"&gt; &lt;IDENTITY&gt; &lt;!-- UTF-8 encoded peer name of the identity --&gt; &lt;/IDENTITY&gt; &lt;IDENTITYDATA xmlns:dt="urn:schemas-microsoft-com:datatypes" dt:dt="bin.base64"&gt; &lt;!-- base64 encoded / PFX encoded and encrypted IDC with the private key --&gt; &lt;/IDENTTYDATA&gt; &lt;/PEERIDENTITYEXPORT&gt;</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peeridentityimport NOT_BUILD_WINDOWS_DEPRECATE HRESULT
	// PeerIdentityImport( PCWSTR pwzImportXML, PCWSTR pwzPassword, PWSTR *ppwzIdentity );
	[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerIdentityImport")]
	public static extern HRESULT PeerIdentityImport([MarshalAs(UnmanagedType.LPWStr)] string pwzImportXML, [MarshalAs(UnmanagedType.LPWStr)] string pwzPassword,
		[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(PeerStringMarshaler))] out string ppwzIdentity);

	/// <summary>
	/// The <c>PeerIdentitySetFriendlyName</c> function modifies the friendly name for a specified peer identity. The friendly name is
	/// the human-readable name.
	/// </summary>
	/// <param name="pwzIdentity">Specifies a peer identity to modify.</param>
	/// <param name="pwzFriendlyName">
	/// Specifies a new friendly name. Specify <c>NULL</c> or an empty string to reset a friendly name to the default value, which is
	/// the Unicode version of the peer name.
	/// </param>
	/// <returns>
	/// <para>If the function call succeeds, the return value is <c>S_OK</c>. Otherwise, it returns one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the parameters is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>There is not enough memory to perform the specified operation.</term>
	/// </item>
	/// <item>
	/// <term>PEER_E_NO_KEY_ACCESS</term>
	/// <term>
	/// Access to the peer identity or peer group keys is denied. Typically, this is caused by an incorrect access control list (ACL)
	/// for the folder that contains the user or computer keys. This can happen when the ACL has been reset manually.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PEER_E_NOT_FOUND</term>
	/// <term>A peer identity that matches a specified name cannot be found.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peeridentitysetfriendlyname NOT_BUILD_WINDOWS_DEPRECATE HRESULT
	// PeerIdentitySetFriendlyName( PCWSTR pwzIdentity, PCWSTR pwzFriendlyName );
	[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerIdentitySetFriendlyName")]
	public static extern HRESULT PeerIdentitySetFriendlyName([MarshalAs(UnmanagedType.LPWStr)] string pwzIdentity, [Optional, MarshalAs(UnmanagedType.LPWStr)] string? pwzFriendlyName);
}