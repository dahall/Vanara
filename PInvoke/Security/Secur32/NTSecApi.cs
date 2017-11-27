using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.AdvApi32;

namespace Vanara.PInvoke
{
	public static partial class NetSecApi
	{
		/// <summary>The MSV1_0 authentication package name.</summary>
		[PInvokeData("Ntsecapi.h")]
		public const string MSV1_0_PACKAGE_NAME = "MICROSOFT_AUTHENTICATION_PACKAGE_V1_0";
		/// <summary>The Kerberos authentication package name.</summary>
		[PInvokeData("Ntsecapi.h")]
		public const string MICROSOFT_KERBEROS_NAME = "Kerberos";
		/// <summary>The Negotiate authentication package name.</summary>
		[PInvokeData("Security.h")]
		public const string NEGOSSP_NAME = "Negotiate";

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
		public static extern uint LsaLookupAuthenticationPackage(SafeLsaConnectionHandle LsaHandle, [In, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LsaStringMarshaler))] string PackageName, out int AuthenticationPackage);

		/// <summary>The LsaConnectUntrusted function establishes an untrusted connection to the LSA server.</summary>
		/// <param name="LsaHandle">Pointer to a handle that receives the connection handle, which must be provided in future authentication services.</param>
		/// <returns>If the function succeeds, the return value is STATUS_SUCCESS.
		/// <para>If the function fails, the return value is an NTSTATUS code. For more information, see LSA Policy Function Return Values.</para>
		/// <para>The LsaNtStatusToWinError function converts an NTSTATUS code to a Windows error code.</para></returns>
		[DllImport(Lib.Secur32, ExactSpelling = true)]
		[PInvokeData("Ntsecapi.h", MSDNShortId = "aa378265")]
		public static extern uint LsaConnectUntrusted(out SafeLsaConnectionHandle LsaHandle);

		/// <summary>The LsaDeregisterLogonProcess function deletes the caller's logon application context and closes the connection to the LSA server.</summary>
		/// <param name="LsaHandle">Handle obtained from a LsaRegisterLogonProcess or LsaConnectUntrusted call.</param>
		/// <returns>If the function succeeds, the return value is STATUS_SUCCESS.
		/// <para>If the function fails, the return value is an NTSTATUS code. For more information, see LSA Policy Function Return Values.</para>
		/// <para>The LsaNtStatusToWinError function converts an NTSTATUS code to a Windows error code.</para></returns>
		[DllImport(Lib.Secur32, ExactSpelling = true)]
		[PInvokeData("Ntsecapi.h", MSDNShortId = "aa378269")]
		public static extern uint LsaDeregisterLogonProcess(IntPtr LsaHandle);

		/// <summary>The LsaRegisterLogonProcess function establishes a connection to the LSA server and verifies that the caller is a logon application.</summary>
		/// <param name="LogonProcessName">String identifying the logon application. This should be a printable name suitable for display to administrators. For example, the Windows logon application might use the name "User32LogonProcess". This name is used by the LSA during auditing. LsaRegisterLogonProcess does not check whether the name is already in use. This string must not exceed 127 bytes.</param>
		/// <param name="LsaHandle">Pointer that receives a handle used in future authentication function calls.</param>
		/// <param name="SecurityMode">The value returned is not meaningful and should be ignored.</param>
		/// <returns>If the function succeeds, the return value is STATUS_SUCCESS.
		/// <para>If the function fails, the return value is an NTSTATUS code. For more information, see LSA Policy Function Return Values.</para>
		/// <para>The LsaNtStatusToWinError function converts an NTSTATUS code to a Windows error code.</para></returns>
		[DllImport(Lib.Secur32, ExactSpelling = true)]
		[PInvokeData("Ntsecapi.h", MSDNShortId = "aa378318")]
		public static extern uint LsaRegisterLogonProcess([In, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LsaStringMarshaler))] string LogonProcessName, out SafeLsaConnectionHandle LsaHandle, out uint SecurityMode);

		/// <summary>
		/// A SafeHandle for security descriptors. If owned, will call LocalFree on the pointer when disposed.
		/// </summary>
		[PInvokeData("Ntsecapi.h")]
		public class SafeLsaConnectionHandle : GenericSafeHandle
		{
			/// <summary>Initializes a new instance of the <see cref="SafeLsaConnectionHandle"/> class.</summary>
			public SafeLsaConnectionHandle() : this(IntPtr.Zero) {}

			/// <summary>Initializes a new instance of the <see cref="SafeLsaConnectionHandle"/> class from an existing pointer.</summary>
			/// <param name="handle">The connection handle.</param>
			/// <param name="own">if set to <c>true</c> indicates that this pointer should be freed when disposed.</param>
			public SafeLsaConnectionHandle(IntPtr handle, bool own = true) : base(handle, h => LsaDeregisterLogonProcess(h) == 0, own) { }
		}
	}
}
