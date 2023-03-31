using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke;

public static partial class AdvApi32
{
	/// <summary>The AllocateAndInitializeSid function allocates and initializes a security identifier (SID) with up to eight subauthorities.</summary>
	/// <param name="sia">
	/// A pointer to a SID_IDENTIFIER_AUTHORITY structure. This structure provides the top-level identifier authority value to set in the SID.
	/// </param>
	/// <param name="subAuthorityCount">
	/// Specifies the number of subauthorities to place in the SID. This parameter also identifies how many of the subauthority
	/// parameters have meaningful values. This parameter must contain a value from 1 to 8.
	/// <para>
	/// For example, a value of 3 indicates that the subauthority values specified by the dwSubAuthority0, dwSubAuthority1, and
	/// dwSubAuthority2 parameters have meaningful values and to ignore the remainder.
	/// </para>
	/// </param>
	/// <param name="dwSubAuthority0">Subauthority value to place in the SID.</param>
	/// <param name="dwSubAuthority1">Subauthority value to place in the SID.</param>
	/// <param name="dwSubAuthority2">Subauthority value to place in the SID.</param>
	/// <param name="dwSubAuthority3">Subauthority value to place in the SID.</param>
	/// <param name="dwSubAuthority4">Subauthority value to place in the SID.</param>
	/// <param name="dwSubAuthority5">Subauthority value to place in the SID.</param>
	/// <param name="dwSubAuthority6">Subauthority value to place in the SID.</param>
	/// <param name="dwSubAuthority7">Subauthority value to place in the SID.</param>
	/// <param name="pSid">A pointer to a variable that receives the pointer to the allocated and initialized SID structure.</param>
	/// <returns>
	/// If the function succeeds, the return value is nonzero. If the function fails, the return value is zero.To get extended error
	/// information, call GetLastError.
	/// </returns>
	[DllImport(Lib.AdvApi32, ExactSpelling = true, SetLastError = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	[PInvokeData("securitybaseapi.h", MSDNShortId = "aa375213")]
	public static extern bool AllocateAndInitializeSid([In] PSID_IDENTIFIER_AUTHORITY sia,
		byte subAuthorityCount, int dwSubAuthority0, int dwSubAuthority1,
		int dwSubAuthority2, int dwSubAuthority3, int dwSubAuthority4,
		int dwSubAuthority5, int dwSubAuthority6, int dwSubAuthority7, out SafeAllocatedSID pSid);

	/// <summary>The CopySid function copies a security identifier (SID) to a buffer.</summary>
	/// <param name="cbDestSid">Specifies the length, in bytes, of the buffer receiving the copy of the SID.</param>
	/// <param name="destSid">A pointer to a buffer that receives a copy of the source SID structure.</param>
	/// <param name="sourceSid">
	/// A pointer to a SID structure that the function copies to the buffer pointed to by the pDestinationSid parameter.
	/// </param>
	/// <returns>
	/// If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error
	/// information, call GetLastError.
	/// </returns>
	[DllImport(Lib.AdvApi32, ExactSpelling = true, SetLastError = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	[PInvokeData("securitybaseapi.h", MSDNShortId = "aa376404")]
	public static extern bool CopySid(int cbDestSid, IntPtr destSid, PSID sourceSid);

	/// <summary>The <c>CreateWellKnownSid</c> function creates a SID for predefined aliases.</summary>
	/// <param name="WellKnownSidType">Member of the WELL_KNOWN_SID_TYPE enumeration that specifies what the SID will identify.</param>
	/// <param name="DomainSid">
	/// A pointer to a SID that identifies the domain to use when creating the SID. Pass <c>NULL</c> to use the local computer.
	/// </param>
	/// <param name="pSid">A pointer to memory where <c>CreateWellKnownSid</c> will store the new SID.</param>
	/// <param name="cbSid">
	/// A pointer to a <c>DWORD</c> that contains the number of bytes available at pSid. The <c>CreateWellKnownSid</c> function stores
	/// the number of bytes actually used at this location.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. For extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-createwellknownsid BOOL
	// CreateWellKnownSid( WELL_KNOWN_SID_TYPE WellKnownSidType, PSID DomainSid, PSID pSid, DWORD *cbSid );
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("securitybaseapi.h", MSDNShortId = "00e75bae-fbce-41a3-a0bc-c345c36f2c84")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CreateWellKnownSid(WELL_KNOWN_SID_TYPE WellKnownSidType, PSID DomainSid, SafePSID pSid, ref uint cbSid);

	/// <summary>The <c>EqualDomainSid</c> function determines whether two SIDs are from the same domain.</summary>
	/// <param name="pSid1">
	/// A pointer to one of the two SIDs to compare. This SID must be either an account domain SID or a BUILTIN SID.
	/// </param>
	/// <param name="pSid2">
	/// A pointer to one of the two SIDs to compare. This SID must be either an account domain SID or a BUILTIN SID.
	/// </param>
	/// <param name="pfEqual">
	/// A pointer to a BOOL that <c>EqualDomainSid</c> sets to <c>TRUE</c> if the domains of the two SIDs are equal or <c>FALSE</c> if
	/// they are not equal. This value cannot be <c>NULL</c>.
	/// </param>
	/// <returns>
	/// <para>
	/// If both SIDs are account domain SIDs and/or BUILTIN SIDs, the return value is nonzero. In addition, *pfEqual is set to
	/// <c>TRUE</c> if the domains of the two SIDs are equal; otherwise *pfEqual is set to <c>FALSE</c>.
	/// </para>
	/// <para>
	/// If one or more of the SIDS is neither an account domain SID nor a BUILTIN SID, then the return value is <c>FALSE</c>. To get
	/// extended error information, call GetLastError. <c>GetLastError</c> returns ERROR_NON_DOMAIN_SID if either SID is not an account
	/// domain SID or BUILTIN SID.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-equaldomainsid BOOL EqualDomainSid( PSID
	// pSid1, PSID pSid2, BOOL *pfEqual );
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("securitybaseapi.h", MSDNShortId = "a7eea3bd-33e0-427c-b023-07851c192eb2")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool EqualDomainSid(PSID pSid1, PSID pSid2, [MarshalAs(UnmanagedType.Bool)] out bool pfEqual);

	/// <summary>
	/// The <c>EqualPrefixSid</c> function tests two security-identifier (SID) prefix values for equality. A SID prefix is the entire SID
	/// except for the last subauthority value.
	/// </summary>
	/// <param name="pSid1">A pointer to the first SID structure to compare. This structure is assumed to be valid.</param>
	/// <param name="pSid2">A pointer to the second SID structure to compare. This structure is assumed to be valid.</param>
	/// <returns>
	/// <para>If the SID prefixes are equal, the return value is nonzero.</para>
	/// <para>If the SID prefixes are not equal, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>EqualPrefixSid</c> function enables a server application in one domain to verify an attempt by a user to log on to another
	/// domain. For example, if a user attempts to log on to RemoteDomain from a workstation in LocalDomain, the server for LocalDomain
	/// can request the SIDs for the user and the user's groups from RemoteDomain. The domain controller for RemoteDomain responds with
	/// the relevant SIDs.
	/// </para>
	/// <para>
	/// All SIDs for a specified domain have the same prefix. When the server receives the user's SIDs, the server can call the
	/// <c>EqualPrefixSid</c> function for each SID, comparing the user or group SID against the SID for RemoteDomain. If any of the SID
	/// prefixes are not equal, the server refuses the logon attempt.
	/// </para>
	/// <para>
	/// It is advisable to modify the SID for a domain before comparing it with a group or user SID. If the SID for RemoteDomain is
	/// S-1–1234–8, each group or user SID for that domain has S-1–1234–8 as its prefix. To compare the SIDs by using the
	/// <c>EqualPrefixSid</c> function, an application copies the domain SID and adds any subauthority (RID) value to the copy, thereby
	/// creating a SID in the form S-1–1234–8–0. The application then uses the modified domain SID as a template against which the group
	/// and user SIDs are compared.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-equalprefixsid BOOL EqualPrefixSid( PSID
	// pSid1, PSID pSid2 );
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("securitybaseapi.h", MSDNShortId = "ef41de63-4ab5-40c6-8b16-b960e1308b5b")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool EqualPrefixSid(PSID pSid1, PSID pSid2);

	/// <summary>
	/// The EqualSid function tests two security identifier (SID) values for equality. Two SIDs must match exactly to be considered equal.
	/// </summary>
	/// <param name="sid1">A pointer to the first SID structure to compare. This structure is assumed to be valid.</param>
	/// <param name="sid2">A pointer to the second SID structure to compare. This structure is assumed to be valid.</param>
	/// <returns>
	/// If the SID structures are equal, the return value is nonzero.
	/// <para>If the SID structures are not equal, the return value is zero. To get extended error information, call GetLastError.</para>
	/// <para>If either SID structure is not valid, the return value is undefined.</para>
	/// </returns>
	[DllImport(Lib.AdvApi32, ExactSpelling = true, SetLastError = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	[PInvokeData("securitybaseapi.h", MSDNShortId = "aa446622")]
	public static extern bool EqualSid(PSID sid1, PSID sid2);

	/// <summary>
	/// The FreeSid function frees a security identifier (SID) previously allocated by using the AllocateAndInitializeSid function.
	/// </summary>
	/// <param name="pSid">A pointer to the SID structure to free.</param>
	/// <returns>
	/// If the function succeeds, the function returns NULL. If the function fails, it returns a pointer to the SID structure represented
	/// by the pSid parameter.
	/// </returns>
	[DllImport(Lib.AdvApi32, ExactSpelling = true, SetLastError = true)]
	[PInvokeData("securitybaseapi.h", MSDNShortId = "aa446631")]
	public static extern PSID FreeSid(PSID pSid);

	/// <summary>The GetLengthSid function returns the length, in bytes, of a valid security identifier (SID).</summary>
	/// <param name="pSid">A pointer to the SID structure whose length is returned. The structure is assumed to be valid.</param>
	/// <returns>
	/// If the SID structure is valid, the return value is the length, in bytes, of the SID structure.
	/// <para>
	/// If the SID structure is not valid, the return value is undefined. Before calling GetLengthSid, pass the SID to the IsValidSid
	/// function to verify that the SID is valid.
	/// </para>
	/// </returns>
	[DllImport(Lib.AdvApi32, ExactSpelling = true, SetLastError = true)]
	[PInvokeData("securitybaseapi.h", MSDNShortId = "aa446642")]
	public static extern int GetLengthSid(PSID pSid);

	/// <summary>
	/// <para>
	/// The <c>GetSidIdentifierAuthority</c> function returns a pointer to the SID_IDENTIFIER_AUTHORITY structure in a specified security
	/// identifier (SID).
	/// </para>
	/// </summary>
	/// <param name="pSid">
	/// <para>A pointer to the SID structure for which a pointer to the SID_IDENTIFIER_AUTHORITY structure is returned.</para>
	/// <para>
	/// This function does not handle SID structures that are not valid. Call the IsValidSid function to verify that the <c>SID</c>
	/// structure is valid before you call this function.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is a pointer to the SID_IDENTIFIER_AUTHORITY structure for the specified SID structure.
	/// </para>
	/// <para>
	/// If the function fails, the return value is undefined. The function fails if the SID structure pointed to by the pSid parameter is
	/// not valid. To get extended error information, call GetLastError.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function uses a 32-bit RID value. For applications that require a larger RID value, use CreateWellKnownSid and related functions.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-getsididentifierauthority
	// PSID_IDENTIFIER_AUTHORITY GetSidIdentifierAuthority( PSID pSid );
	[DllImport(Lib.AdvApi32, SetLastError = true, EntryPoint = "GetSidIdentifierAuthority")]
	[PInvokeData("securitybaseapi.h", MSDNShortId = "67a06e7b-775f-424c-ab36-0fc9b93b801a")]
	internal static extern IntPtr InternalGetSidIdentifierAuthority(PSID pSid);

	/// <summary>
	/// The <c>GetSidIdentifierAuthority</c> function returns a pointer to the SID_IDENTIFIER_AUTHORITY structure in a specified
	/// security identifier (SID).
	/// </summary>
	/// <param name="pSid">
	/// <para>A pointer to the SID structure for which a pointer to the SID_IDENTIFIER_AUTHORITY structure is returned.</para>
	/// <para>
	/// This function does not handle SID structures that are not valid. Call the IsValidSid function to verify that the <c>SID</c>
	/// structure is valid before you call this function.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is a pointer to the SID_IDENTIFIER_AUTHORITY structure for the specified SID structure.
	/// </para>
	/// <para>
	/// If the function fails, the return value is undefined. The function fails if the SID structure pointed to by the pSid parameter
	/// is not valid. To get extended error information, call GetLastError.
	/// </para>
	/// </returns>
	/// <remarks>
	/// This function uses a 32-bit RID value. For applications that require a larger RID value, use CreateWellKnownSid and related functions.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-getsididentifierauthority
	// PSID_IDENTIFIER_AUTHORITY GetSidIdentifierAuthority( PSID pSid );
	[PInvokeData("securitybaseapi.h", MSDNShortId = "67a06e7b-775f-424c-ab36-0fc9b93b801a")]
	public static PSID_IDENTIFIER_AUTHORITY GetSidIdentifierAuthority(PSID pSid) => new(InternalGetSidIdentifierAuthority(pSid));

	/// <summary>
	/// <para>
	/// The <c>GetSidLengthRequired</c> function returns the length, in bytes, of the buffer required to store a SID with a specified
	/// number of subauthorities.
	/// </para>
	/// </summary>
	/// <param name="nSubAuthorityCount">
	/// <para>Specifies the number of subauthorities to be stored in the SID structure.</para>
	/// </param>
	/// <returns>
	/// <para>The return value is the length, in bytes, of the buffer required to store the SID structure. This function cannot fail.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The SID structure specified in nSubAuthorityCount uses a 32-bit RID value. For applications that require longer RID values, use
	/// CreateWellKnownSid and related functions.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-getsidlengthrequired DWORD
	// GetSidLengthRequired( UCHAR nSubAuthorityCount );
	[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("securitybaseapi.h", MSDNShortId = "a481fb4f-20bd-4f44-a3d5-d8b8d6228339")]
	public static extern uint GetSidLengthRequired(byte nSubAuthorityCount);

	/// <summary>
	/// The GetSidSubAuthority function returns a pointer to a specified subauthority in a security identifier (SID). The subauthority
	/// value is a relative identifier (RID).
	/// </summary>
	/// <param name="pSid">A pointer to the SID structure from which a pointer to a subauthority is to be returned.</param>
	/// <param name="nSubAuthority">
	/// Specifies an index value identifying the subauthority array element whose address the function will return. The function performs
	/// no validation tests on this value. An application can call the GetSidSubAuthorityCount function to discover the range of
	/// acceptable values.
	/// </param>
	/// <returns>
	/// If the function succeeds, the return value is a pointer to the specified SID subauthority. To get extended error information,
	/// call GetLastError.
	/// <para>
	/// If the function fails, the return value is undefined. The function fails if the specified SID structure is not valid or if the
	/// index value specified by the nSubAuthority parameter is out of bounds.
	/// </para>
	/// </returns>
	[DllImport(Lib.AdvApi32, EntryPoint = "GetSidSubAuthority", SetLastError = true)]
	[PInvokeData("securitybaseapi.h", MSDNShortId = "aa446657")]
	internal static extern IntPtr InternalGetSidSubAuthority(PSID pSid, uint nSubAuthority);

	/// <summary>
	/// The GetSidSubAuthority function returns a pointer to a specified subauthority in a security identifier (SID). The subauthority
	/// value is a relative identifier (RID).
	/// </summary>
	/// <param name="pSid">A pointer to the SID structure from which a pointer to a subauthority is to be returned.</param>
	/// <param name="nSubAuthority">
	/// Specifies an index value identifying the subauthority array element whose address the function will return. The function performs
	/// no validation tests on this value. An application can call the GetSidSubAuthorityCount function to discover the range of
	/// acceptable values.
	/// </param>
	/// <returns>
	/// On success, the return value is the specified SID subauthority.
	/// <para>
	/// If the function fails, an exception is thrown. The function fails if the specified SID structure is not valid or if the index
	/// value specified by the nSubAuthority parameter is out of bounds.
	/// </para>
	/// </returns>
	[PInvokeData("securitybaseapi.h", MSDNShortId = "aa446657")]
	public static uint GetSidSubAuthority(PSID pSid, uint nSubAuthority)
	{
		var ptr = InternalGetSidSubAuthority(pSid, nSubAuthority);
		Win32Error.GetLastError().ThrowIfFailed();
		return unchecked((uint)Marshal.ReadInt32(ptr));
	}

	/// <summary>
	/// The <c>GetSidSubAuthorityCount</c> function returns a pointer to the member in a security identifier (SID) structure that
	/// contains the subauthority count.
	/// </summary>
	/// <param name="pSid">
	/// <para>A pointer to the SID structure from which a pointer to the subauthority count is returned.</para>
	/// <para>
	/// This function does not handle SID structures that are not valid. Call the IsValidSid function to verify that the <c>SID</c>
	/// structure is valid before you call this function.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a pointer to the subauthority count for the specified SID structure.</para>
	/// <para>
	/// If the function fails, the return value is undefined. The function fails if the specified SID structure is not valid. To get
	/// extended error information, call GetLastError.
	/// </para>
	/// </returns>
	/// <remarks>
	/// The SID structure specified in pSid uses a 32-bit value. For applications that require longer RID values, use CreateWellKnownSid
	/// and related functions.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-getsidsubauthoritycount PUCHAR
	// GetSidSubAuthorityCount( PSID pSid );
	[DllImport(Lib.AdvApi32, SetLastError = true, EntryPoint = "GetSidSubAuthorityCount")]
	[PInvokeData("securitybaseapi.h", MSDNShortId = "ca81fb91-f5a1-4dc6-83ec-eadb62a37805")]
	internal static extern IntPtr InternalGetSidSubAuthorityCount(PSID pSid);

	/// <summary>
	/// The <c>GetSidSubAuthorityCount</c> function returns a pointer to the member in a security identifier (SID) structure that
	/// contains the subauthority count.
	/// </summary>
	/// <param name="pSid">
	/// <para>A pointer to the SID structure from which a pointer to the subauthority count is returned.</para>
	/// <para>
	/// This function does not handle SID structures that are not valid. Call the IsValidSid function to verify that the <c>SID</c>
	/// structure is valid before you call this function.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is the subauthority count for the specified SID structure.</para>
	/// <para>
	/// If the function fails, an exception is thrown. The function fails if the specified SID structure is not valid. To get
	/// extended error information, call GetLastError.
	/// </para>
	/// </returns>
	/// <remarks>
	/// The SID structure specified in pSid uses a 32-bit value. For applications that require longer RID values, use CreateWellKnownSid
	/// and related functions.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-getsidsubauthoritycount PUCHAR
	// GetSidSubAuthorityCount( PSID pSid );
	[PInvokeData("securitybaseapi.h", MSDNShortId = "ca81fb91-f5a1-4dc6-83ec-eadb62a37805")]
	public static byte GetSidSubAuthorityCount(PSID pSid)
	{
		var ptr = InternalGetSidSubAuthorityCount(pSid);
		Win32Error.GetLastError().ThrowIfFailed();
		return Marshal.ReadByte(ptr);
	}

	/// <summary>
	/// The <c>GetWindowsAccountDomainSid</c> function receives a security identifier (SID) and returns a SID representing the domain of
	/// that SID.
	/// </summary>
	/// <param name="pSid">A pointer to the SID to examine.</param>
	/// <param name="pDomainSid">Pointer that <c>GetWindowsAccountDomainSid</c> fills with a pointer to a SID representing the domain.</param>
	/// <param name="cbDomainSid">
	/// A pointer to a <c>DWORD</c> that <c>GetWindowsAccountDomainSid</c> fills with the size of the domain SID, in bytes.
	/// </param>
	/// <returns>
	/// <para>Returns <c>TRUE</c> if successful.</para>
	/// <para>Otherwise, returns <c>FALSE</c>. For extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-getwindowsaccountdomainsid BOOL
	// GetWindowsAccountDomainSid( PSID pSid, PSID pDomainSid, DWORD *cbDomainSid );
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("securitybaseapi.h", MSDNShortId = "ee2ba1b4-1bef-4d79-bb18-512705e2c378")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetWindowsAccountDomainSid(PSID pSid, SafePSID pDomainSid, ref uint cbDomainSid);

	/// <summary>
	/// The <c>GetWindowsAccountDomainSid</c> function receives a security identifier (SID) and returns a SID representing the domain of
	/// that SID.
	/// </summary>
	/// <param name="pSid">A pointer to the SID to examine.</param>
	/// <param name="pDomainSid">An allocated safe pointer to a SID representing the domain.</param>
	/// <returns>
	/// <para>Returns <see langword="true"/> if successful.</para>
	/// <para>Otherwise, returns <see langword="false"/>. For extended error information, call GetLastError.</para>
	/// </returns>
	[PInvokeData("securitybaseapi.h", MSDNShortId = "ee2ba1b4-1bef-4d79-bb18-512705e2c378")]
	public static bool GetWindowsAccountDomainSid(PSID pSid, out SafePSID pDomainSid)
	{
		uint sz = 0;
		if (!GetWindowsAccountDomainSid(pSid, SafePSID.Null, ref sz) && sz == 0)
		{
			pDomainSid = SafePSID.Null;
			return false;
		}
		pDomainSid = new SafePSID(sz);
		return GetWindowsAccountDomainSid(pSid, pDomainSid, ref sz);
	}

	/// <summary>The <c>InitializeSid</c> function initializes a security identifier (SID).</summary>
	/// <param name="Sid">A pointer to a SID structure to be initialized.</param>
	/// <param name="pIdentifierAuthority">A pointer to a SID_IDENTIFIER_AUTHORITY structure to set in the SID structure.</param>
	/// <param name="nSubAuthorityCount">
	/// Specifies the number of subauthorities to set in the SID. Values of the subauthority must be set separately, as described in the
	/// following Remarks section.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Although the <c>InitializeSid</c> function sets the number of subauthorities for the SID, it does not set the subauthority
	/// values. This must be done separately, using functions such as GetSidSubAuthority.
	/// </para>
	/// <para>An application can use the AllocateAndInitializeSid function to initialize a SID and set its subauthority values.</para>
	/// <para>This function uses a 32-bit RID value. For applications that require a larger RID value, use CreateWellKnownSid.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-initializesid BOOL InitializeSid( PSID
	// Sid, PSID_IDENTIFIER_AUTHORITY pIdentifierAuthority, BYTE nSubAuthorityCount );
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("securitybaseapi.h", MSDNShortId = "b2d803a5-faaf-4066-ba2c-0442c71bb150")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool InitializeSid(PSID Sid, PSID_IDENTIFIER_AUTHORITY pIdentifierAuthority, byte nSubAuthorityCount);

	/// <summary>
	/// The IsValidSid function validates a security identifier (SID) by verifying that the revision number is within a known range, and
	/// that the number of subauthorities is less than the maximum.
	/// </summary>
	/// <param name="pSid">A pointer to the SID structure to validate. This parameter cannot be NULL.</param>
	/// <returns>
	/// If the SID structure is valid, the return value is nonzero. If the SID structure is not valid, the return value is zero. There is
	/// no extended error information for this function; do not call GetLastError.
	/// </returns>
	[PInvokeData("securitybaseapi.h", MSDNShortId = "aa379151")]
	[DllImport(Lib.AdvApi32, ExactSpelling = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool IsValidSid(PSID pSid);

	/// <summary>The <c>IsWellKnownSid</c> function compares a SID to a well-known SID and returns <c>TRUE</c> if they match.</summary>
	/// <param name="pSid">A pointer to the SID to test.</param>
	/// <param name="WellKnownSidType">Member of the WELL_KNOWN_SID_TYPE enumeration to compare with the SID at pSid.</param>
	/// <returns>
	/// <para>Returns <c>TRUE</c> if the SID at pSid matches the well-known SID indicated by WellKnownSidType.</para>
	/// <para>Otherwise, returns <c>FALSE</c>.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-iswellknownsid BOOL IsWellKnownSid( PSID
	// pSid, WELL_KNOWN_SID_TYPE WellKnownSidType );
	[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("securitybaseapi.h", MSDNShortId = "1a08c70c-00fa-4c62-883d-4f17f9d7c04b")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool IsWellKnownSid(PSID pSid, WELL_KNOWN_SID_TYPE WellKnownSidType);

	/// <summary>Provides a <see cref="SafeHandle"/> to an allocated SID that is released at disposal using FreeSid.</summary>
	public class SafeAllocatedSID : SafeHANDLE, ISecurityObject
	{
		/// <summary>Initializes a new instance of the <see cref="SafeAllocatedSID"/> class.</summary>
		private SafeAllocatedSID() : base() { }

		/// <summary>Performs an implicit conversion from <see cref="SafeAllocatedSID"/> to <see cref="PSID"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator PSID(SafeAllocatedSID h) => h.handle;

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() => FreeSid(this).IsNull;
	}
}