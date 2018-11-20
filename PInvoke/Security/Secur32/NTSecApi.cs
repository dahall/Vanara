using System;
using System.Runtime.InteropServices;
using static Vanara.PInvoke.AdvApi32;

namespace Vanara.PInvoke
{
	/// <summary>Functions, enumerations and structures found in Secur32.dll.</summary>
	public static partial class Secur32
	{
		/// <summary>The Kerberos authentication package name.</summary>
		[PInvokeData("Ntsecapi.h")]
		public const string MICROSOFT_KERBEROS_NAME = "Kerberos";

		/// <summary>The MSV1_0 authentication package name.</summary>
		[PInvokeData("Ntsecapi.h")]
		public const string MSV1_0_PACKAGE_NAME = "MICROSOFT_AUTHENTICATION_PACKAGE_V1_0";

		/// <summary>The Negotiate authentication package name.</summary>
		[PInvokeData("Security.h")]
		public const string NEGOSSP_NAME = "Negotiate";

		/// <summary>
		/// <para>The <c>LsaConnectUntrusted</c> function establishes an untrusted connection to the LSA server.</para>
		/// </summary>
		/// <param name="LsaHandle">
		/// <para>Pointer to a handle that receives the connection handle, which must be provided in future authentication services.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is STATUS_SUCCESS.</para>
		/// <para>If the function fails, the return value is an NTSTATUS code. For more information, see LSA Policy Function Return Values.</para>
		/// <para>The LsaNtStatusToWinError function converts an NTSTATUS code to a Windows error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>LsaConnectUntrusted</c> returns a handle to an untrusted connection; it does not verify any information about the caller. The
		/// handle should be closed using the LsaDeregisterLogonProcess function.
		/// </para>
		/// <para>
		/// If your application simply needs to query information from authentication packages, you can use the handle returned by this
		/// function in calls to LsaCallAuthenticationPackage and LsaLookupAuthenticationPackage.
		/// </para>
		/// <para>Applications with the SeTcbPrivilege privilege may create a trusted connection by calling LsaRegisterLogonProcess.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ntsecapi/nf-ntsecapi-lsaconnectuntrusted NTSTATUS LsaConnectUntrusted(
		// PHANDLE LsaHandle );
		[DllImport(Lib.Secur32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ntsecapi.h", MSDNShortId = "b54917c8-51cd-4891-9613-f37a4a46448b")]
		// public static extern NTStatus LsaConnectUntrusted(ref IntPtr LsaHandle);
		public static extern NTStatus LsaConnectUntrusted(out SafeLsaConnectionHandle LsaHandle);

		/// <summary>
		/// The LsaDeregisterLogonProcess function deletes the caller's logon application context and closes the connection to the LSA server.
		/// </summary>
		/// <param name="LsaHandle">Handle obtained from a LsaRegisterLogonProcess or LsaConnectUntrusted call.</param>
		/// <returns>
		/// If the function succeeds, the return value is STATUS_SUCCESS.
		/// <para>If the function fails, the return value is an NTSTATUS code. For more information, see LSA Policy Function Return Values.</para>
		/// <para>The LsaNtStatusToWinError function converts an NTSTATUS code to a Windows error code.</para>
		/// </returns>
		[DllImport(Lib.Secur32, ExactSpelling = true)]
		[PInvokeData("Ntsecapi.h", MSDNShortId = "aa378269")]
		public static extern NTStatus LsaDeregisterLogonProcess(LsaConnectionHandle LsaHandle);

		/// <summary>The LsaLookupAuthenticationPackage function obtains the unique identifier of an authentication package.</summary>
		/// <param name="LsaHandle">Handle obtained from a previous call to LsaRegisterLogonProcess or LsaConnectUntrusted.</param>
		/// <param name="PackageName">A string that specifies the name of the authentication package. The package name must not exceed 127 bytes in length. The following table lists the names of the Microsoft-provided authentication packages.
		/// <list type="table">
		/// <listheader><term>Value</term><term>Meaning</term></listheader>
		/// <item><term>MSV1_0_PACKAGE_NAME</term><description>The MSV1_0 authentication package name.</description></item>
		/// <item><term>MICROSOFT_KERBEROS_NAME</term><description>The Kerberos authentication package name.</description></item>
		/// <item><term>NEGOSSP_NAME</term><description>The Negotiate authentication package name.</description></item>
		/// </list>
		///</param>
		/// <param name="AuthenticationPackage">Pointer to a ULONG that receives the authentication package identifier.</param>
		/// <returns>If the function succeeds, the return value is STATUS_SUCCESS.
		/// <para>If the function fails, the return value is an NTSTATUS code. The following are possible error codes.</para>
		/// <list type="table">
		/// <listheader><term>Return code</term><term>Description</term></listheader>
		/// <item><term>STATUS_NO_SUCH_PACKAGE</term><description>The specified authentication package is unknown to the LSA.</description></item>
		/// <item><term>STATUS_NAME_TOO_LONG</term><description>The authentication package name exceeds 127 bytes.</description></item>
		/// </list></returns>
		[DllImport(Lib.Secur32, ExactSpelling = true)]
		[PInvokeData("Ntsecapi.h", MSDNShortId = "aa378297")]
		public static extern NTStatus LsaLookupAuthenticationPackage(LsaConnectionHandle LsaHandle, [In, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LsaStringMarshaler))] string PackageName, out int AuthenticationPackage);

		/// <summary>
		/// The LsaRegisterLogonProcess function establishes a connection to the LSA server and verifies that the caller is a logon application.
		/// </summary>
		/// <param name="LogonProcessName">
		/// String identifying the logon application. This should be a printable name suitable for display to administrators. For example,
		/// the Windows logon application might use the name "User32LogonProcess". This name is used by the LSA during auditing.
		/// LsaRegisterLogonProcess does not check whether the name is already in use. This string must not exceed 127 bytes.
		/// </param>
		/// <param name="LsaHandle">Pointer that receives a handle used in future authentication function calls.</param>
		/// <param name="SecurityMode">The value returned is not meaningful and should be ignored.</param>
		/// <returns>
		/// If the function succeeds, the return value is STATUS_SUCCESS.
		/// <para>If the function fails, the return value is an NTSTATUS code. For more information, see LSA Policy Function Return Values.</para>
		/// <para>The LsaNtStatusToWinError function converts an NTSTATUS code to a Windows error code.</para>
		/// </returns>
		[DllImport(Lib.Secur32, ExactSpelling = true)]
		[PInvokeData("Ntsecapi.h", MSDNShortId = "aa378318")]
		public static extern NTStatus LsaRegisterLogonProcess([In, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LsaStringMarshaler))] string LogonProcessName, out SafeLsaConnectionHandle LsaHandle, out uint SecurityMode);

		/// <summary>Provides a handle to an LSA connection.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct LsaConnectionHandle : IHandle
		{
			private IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="LsaConnectionHandle"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public LsaConnectionHandle(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="LsaConnectionHandle"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static LsaConnectionHandle NULL => new LsaConnectionHandle(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="LsaConnectionHandle"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(LsaConnectionHandle h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="LsaConnectionHandle"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator LsaConnectionHandle(IntPtr h) => new LsaConnectionHandle(h);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(LsaConnectionHandle h1, LsaConnectionHandle h2) => !(h1 == h2);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(LsaConnectionHandle h1, LsaConnectionHandle h2) => h1.Equals(h2);

			/// <inheritdoc/>
			public override bool Equals(object obj) => obj is LsaConnectionHandle h ? handle == h.handle : false;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
		}

		/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="LsaConnectionHandle"/> that is disposed using <see cref="LsaDeregisterLogonProcess"/>.</summary>
		public class SafeLsaConnectionHandle : HANDLE
		{
			/// <summary>Initializes a new instance of the <see cref="SafeLsaConnectionHandle"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafeLsaConnectionHandle(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SafeLsaConnectionHandle"/> class.</summary>
			private SafeLsaConnectionHandle() : base() { }

			/// <summary>Performs an implicit conversion from <see cref="SafeLsaConnectionHandle"/> to <see cref="LsaConnectionHandle"/>.</summary>
			/// <param name="h">The safe handle instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator LsaConnectionHandle(SafeLsaConnectionHandle h) => h.handle;

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() => LsaDeregisterLogonProcess(this).Succeeded;
		}

/*
AuditComputeEffectivePolicyBySid function
AuditComputeEffectivePolicyByToken function
AuditEnumerateCategories function
AuditEnumeratePerUserPolicy function
AuditEnumerateSubCategories function
AuditFree function
AuditLookupCategoryGuidFromCategoryId function
AuditLookupCategoryIdFromCategoryGuid function
AuditLookupCategoryNameA function
AuditLookupCategoryNameW function
AuditLookupSubCategoryNameA function
AuditLookupSubCategoryNameW function
AuditQueryGlobalSaclA function
AuditQueryGlobalSaclW function
AuditQueryPerUserPolicy function
AuditQuerySecurity function
AuditQuerySystemPolicy function
AuditSetGlobalSaclA function
AuditSetGlobalSaclW function
AuditSetPerUserPolicy function
AuditSetSecurity function
AuditSetSystemPolicy function
KERB_CRYPTO_KEY structure
LsaCallAuthenticationPackage function
LsaCreateTrustedDomainEx function
LsaDeleteTrustedDomain function
LsaEnumerateLogonSessions function
LsaEnumerateTrustedDomains function
LsaEnumerateTrustedDomainsEx function
LsaGetLogonSessionData function
LsaLogonUser function
LsaLookupNames function
LsaLookupSids function
LsaOpenTrustedDomainByName function
LsaQueryDomainInformationPolicy function
LsaQueryForestTrustInformation function
LsaQueryInformationPolicy function
LsaQueryTrustedDomainInfoByName function
LsaRegisterPolicyChangeNotification function
LsaRetrievePrivateData function
LsaSetDomainInformationPolicy function
LsaSetForestTrustInformation function
LsaSetInformationPolicy function
LsaSetTrustedDomainInfoByName function
LsaStorePrivateData function
LsaUnregisterPolicyChangeNotification function
PSAM_INIT_NOTIFICATION_ROUTINE callback function
PSAM_PASSWORD_FILTER_ROUTINE callback function
PSAM_PASSWORD_NOTIFICATION_ROUTINE callback function
RtlDecryptMemory function
RtlEncryptMemory function
RtlGenRandom function
*/
	}
}