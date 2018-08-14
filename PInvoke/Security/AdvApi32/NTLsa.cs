using System;
using System.Runtime.InteropServices;
using static Vanara.PInvoke.NetSecApi;

// ReSharper disable InconsistentNaming ReSharper disable FieldCanBeMadeReadOnly.Global ReSharper disable InconsistentNaming

namespace Vanara.PInvoke
{
	public static partial class AdvApi32
	{
		/// <summary>Access mask for accounts.</summary>
		[Flags]
		[PInvokeData("ntlsa.h")]
		public enum LsaAccountAccessMask : uint
		{
			/// <summary>
			/// This access type is required to read the account information. This includes the privileges assigned to the account, memory quotas assigned, and
			/// any special access types granted.
			/// </summary>
			ACCOUNT_VIEW = 0x00000001,

			/// <summary>This access type is required to assign privileges to or remove privileges from an account.</summary>
			ACCOUNT_ADJUST_PRIVILEGES = 0x00000002,

			/// <summary>This access type is required to change the system quotas assigned to an account.</summary>
			ACCOUNT_ADJUST_QUOTAS = 0x00000004,

			/// <summary>This access type is required to update the system access flags for the account.</summary>
			ACCOUNT_ADJUST_SYSTEM_ACCESS = 0x00000008,

			/// <summary>The account all access</summary>
			ACCOUNT_ALL_ACCESS = ACCESS_MASK.STANDARD_RIGHTS_REQUIRED |
								 ACCOUNT_VIEW |
								 ACCOUNT_ADJUST_PRIVILEGES |
								 ACCOUNT_ADJUST_QUOTAS |
								 ACCOUNT_ADJUST_SYSTEM_ACCESS,

			/// <summary>The account read</summary>
			ACCOUNT_READ = ACCESS_MASK.STANDARD_RIGHTS_READ |
						   ACCOUNT_VIEW,

			/// <summary>The account write</summary>
			ACCOUNT_WRITE = ACCESS_MASK.STANDARD_RIGHTS_WRITE |
							ACCOUNT_ADJUST_PRIVILEGES |
							ACCOUNT_ADJUST_QUOTAS |
							ACCOUNT_ADJUST_SYSTEM_ACCESS,

			/// <summary>The account execute</summary>
			ACCOUNT_EXECUTE = ACCESS_MASK.STANDARD_RIGHTS_EXECUTE,
		}

		/// <summary>Flags used by LsaLookupNames2.</summary>
		[Flags]
		[PInvokeData("ntlsa.h")]
		public enum LsaLookupNamesFlags : uint
		{
			/// <summary>
			/// The function searches only on the local systems for names that do not specify a domain. The function does search on remote systems for names that
			/// do specify a domain.
			/// </summary>
			LSA_LOOKUP_ISOLATED_AS_LOCAL = 0x80000000
		}

		/// <summary>Flags used by LsaLookupSids2.</summary>
		[Flags]
		[PInvokeData("ntlsa.h")]
		public enum LsaLookupSidsFlags : uint
		{
			/// <summary>Internet SIDs from identity providers for connected accounts are disallowed. Connected accounts are those accounts which have a corresponding shadow account in the local SAM database connected to an online identity provider. For example, MicrosoftAccount is a connected account.</summary>
			LSA_LOOKUP_DISALLOW_CONNECTED_ACCOUNT_INTERNET_SID = 0x80000000,
			/// <summary>Returns the internet names. Otherwise the NT4 style name (domain\username) is returned. The exception is if the Microsoft Account internet SID is specified, in which case the internet name is returned unless LSA_LOOKUP_DISALLOW_NON_WINDOWS_INTERNET_SID is specified.</summary>
			LSA_LOOKUP_PREFER_INTERNET_NAMES = 0x40000000,
			/// <summary>Always returns local SAM account names even for Internet provider identities.</summary>
			LSA_LOOKUP_RETURN_LOCAL_NAMES = 0
		}

		/// <summary>
		/// The LsaGetAppliedCAPIDs function returns an array of central access policies (CAPs) identifiers (CAPIDs) of all the CAPs applied on a specific computer.
		/// </summary>
		/// <param name="systemName">
		/// The name of the specific computer. The name can have the form of "ComputerName" or "\\ComputerName". If this parameter is NULL, then the function
		/// returns the CAPIDs of the local computer.
		/// </param>
		/// <param name="CAPIDs">
		/// A pointer to a variable that receives an array of pointers to CAPIDs that identify the CAPs available on the specified computer. When you have
		/// finished using the CAPIDs, call the LsaFreeMemory function on each element in the array and the entire array.
		/// </param>
		/// <param name="CAPIDCount">
		/// A pointer to a variable that receives the number of CAPs that are available on the specified computer. The array returned in the CAPIDs parameter
		/// contains the same number of elements as the CAPIDCount parameter.
		/// </param>
		/// <returns>
		/// If the function succeeds, the return value is STATUS_SUCCESS.
		/// <para>
		/// If the function fails, the return value is one of the LSA Policy Function Return Values. You can use the LsaNtStatusToWinError function to convert
		/// the NTSTATUS code to a Windows error code.
		/// </para>
		/// </returns>
		[DllImport(Lib.AdvApi32, ExactSpelling = true, SetLastError = true, CharSet = CharSet.Unicode)]
		[PInvokeData("ntlsa.h", MSDNShortId = "hh846251")]
		public static extern uint LsaGetAppliedCAPIDs(
			[In, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LsaUnicodeStringMarshaler))] string systemName,
			out SafeLsaMemoryHandle CAPIDs, out uint CAPIDCount);
	}
}