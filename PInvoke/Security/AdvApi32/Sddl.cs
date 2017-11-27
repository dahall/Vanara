using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using Vanara.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class AdvApi32
	{
		/// <summary>Contains values to indicate the requested SDDL format.</summary>
		public enum SDDL_REVISION
		{
			/// <summary>SDDL revision 1.</summary>
			SDDL_REVISION_1 = 1
		}

		/// <summary>
		/// The ConvertSecurityDescriptorToStringSecurityDescriptor function converts a security descriptor to a string format. You can use the string format to
		/// store or transmit the security descriptor.
		/// <para>
		/// To convert the string-format security descriptor back to a valid, functional security descriptor, call the
		/// ConvertStringSecurityDescriptorToSecurityDescriptor function.
		/// </para>
		/// </summary>
		/// <param name="SecurityDescriptor">A pointer to the security descriptor to convert. The security descriptor can be in absolute or self-relative format.</param>
		/// <param name="RequestedStringSDRevision">
		/// Specifies the revision level of the output StringSecurityDescriptor string. Currently this value must be SDDL_REVISION_1.
		/// </param>
		/// <param name="SecurityInformation">
		/// Specifies a combination of the SECURITY_INFORMATION bit flags to indicate the components of the security descriptor to include in the output string.
		/// The BACKUP_SECURITY_INFORMATION flag is not applicable to this function. If the BACKUP_SECURITY_INFORMATION flag is passed in, the
		/// SecurityInformation parameter returns TRUE with null string output.
		/// </param>
		/// <param name="StringSecurityDescriptor">
		/// A pointer to a variable that receives a pointer to a null-terminated security descriptor string. For a description of the string format, see Security
		/// Descriptor String Format. To free the returned buffer, call the LocalFree function.
		/// </param>
		/// <param name="StringSecurityDescriptorLen">
		/// A pointer to a variable that receives the size, in TCHARs, of the security descriptor string returned in the StringSecurityDescriptor buffer. This
		/// parameter can be NULL if you do not need to retrieve the size.
		/// </param>
		/// <returns>
		/// If the function succeeds, the return value is nonzero. If the function fails, the return value is zero.To get extended error information, call GetLastError.
		/// </returns>
		[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("sddl.h", MSDNShortId = "aa376397")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ConvertSecurityDescriptorToStringSecurityDescriptor(IntPtr SecurityDescriptor, SDDL_REVISION RequestedStringSDRevision, 
			SECURITY_INFORMATION SecurityInformation, out SafeHGlobalHandle StringSecurityDescriptor, out uint StringSecurityDescriptorLen);

		/// <summary>The ConvertStringSecurityDescriptorToSecurityDescriptor function converts a string-format security descriptor into a valid, functional security descriptor. This function retrieves a security descriptor that the ConvertSecurityDescriptorToStringSecurityDescriptor function converted to string format.</summary>
		/// <param name="StringSecurityDescriptor">A pointer to a null-terminated string containing the string-format security descriptor to convert.</param>
		/// <param name="StringSDRevision">Specifies the revision level of the StringSecurityDescriptor string. Currently this value must be SDDL_REVISION_1.</param>
		/// <param name="SecurityDescriptor">A pointer to a variable that receives a pointer to the converted security descriptor. The returned security descriptor is self-relative. To free the returned buffer, call the LocalFree function. To convert the security descriptor to an absolute security descriptor, use the MakeAbsoluteSD function.</param>
		/// <param name="SecurityDescriptorSize">A pointer to a variable that receives the size, in bytes, of the converted security descriptor. This parameter can be NULL.</param>
		/// <returns>If the function succeeds, the return value is <c>true</c>. If the function fails, the return value is <c>false</c>. To get extended error information, call GetLastError.</returns>
		[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto, ThrowOnUnmappableChar = true)]
		[PInvokeData("sddl.h", MSDNShortId = "aa376401")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ConvertStringSecurityDescriptorToSecurityDescriptor([In] string StringSecurityDescriptor, SDDL_REVISION StringSDRevision,
			out SafeHGlobalHandle SecurityDescriptor, out uint SecurityDescriptorSize);
	}
}
