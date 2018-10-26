using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using Vanara.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class AdvApi32
	{
		/// <summary>The ConvertSidToStringSid function converts a security identifier (SID) to a string format suitable for display, storage, or transmission.</summary>
		/// <param name="Sid">A pointer to the SID structure to be converted.</param>
		/// <param name="StringSid">
		/// A pointer to a variable that receives a pointer to a null-terminated SID string. To free the returned buffer, call the LocalFree function.
		/// </param>
		/// <returns>
		/// If the function succeeds, the return value is nonzero. If the function fails, the return value is zero.To get extended error information, call GetLastError.
		/// </returns>
		[DllImport(Lib.AdvApi32, CharSet = CharSet.Auto, SetLastError = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("sddl.h", MSDNShortId = "aa376399")]
		public static extern bool ConvertSidToStringSid(PSID Sid, out SafeHGlobalHandle StringSid);

		/// <summary>Converts a security identifier (SID) to a string format suitable for display, storage, or transmission.</summary>
		/// <param name="Sid">The SID structure to be converted.</param>
		/// <returns>A null-terminated SID string.</returns>
		[PInvokeData("sddl.h", MSDNShortId = "aa376399")]
		public static string ConvertSidToStringSid(PSID Sid) => ConvertSidToStringSid(Sid, out SafeHGlobalHandle str) ? str.ToString(-1) : throw new Win32Exception();

		/// <summary>
		/// The ConvertStringSidToSid function converts a string-format security identifier (SID) into a valid, functional SID. You can use this function to
		/// retrieve a SID that the ConvertSidToStringSid function converted to string format.
		/// </summary>
		/// <param name="pStringSid">
		/// A pointer to a null-terminated string containing the string-format SID to convert. The SID string can use either the standard S-R-I-S-S… format for
		/// SID strings, or the SID string constant format, such as "BA" for built-in administrators. For more information about SID string notation, see SID Components.
		/// </param>
		/// <param name="sid">A pointer to a variable that receives a pointer to the converted SID. To free the returned buffer, call the LocalFree function.</param>
		/// <returns>
		/// If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error information, call GetLastError.
		/// </returns>
		[DllImport(Lib.AdvApi32, CharSet = CharSet.Auto, SetLastError = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("sddl.h", MSDNShortId = "aa376402")]
		public static extern bool ConvertStringSidToSid(string pStringSid, out PSID sid);

		/// <summary>
		/// The ConvertStringSidToSid function converts a string-format security identifier (SID) into a valid, functional SID. You can use this function to
		/// retrieve a SID that the ConvertSidToStringSid function converted to string format.
		/// </summary>
		/// <param name="pStringSid">
		/// A pointer to a null-terminated string containing the string-format SID to convert. The SID string can use either the standard S-R-I-S-S… format for
		/// SID strings, or the SID string constant format, such as "BA" for built-in administrators. For more information about SID string notation, see SID Components.
		/// </param>
		/// <param name="sid">A pointer to a variable that receives a pointer to the converted SID. To free the returned buffer, call the LocalFree function.</param>
		/// <returns>
		/// If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error information, call GetLastError.
		/// </returns>
		[DllImport(Lib.AdvApi32, CharSet = CharSet.Auto, SetLastError = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("Sddl.h", MSDNShortId = "aa376402")]
		public static extern bool ConvertStringSidToSid(string pStringSid, out IntPtr sid);
	}
}
