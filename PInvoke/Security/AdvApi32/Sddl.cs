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
		/// <para>
		/// The <c>ConvertSecurityDescriptorToStringSecurityDescriptor</c> function converts a security descriptor to a string format. You
		/// can use the string format to store or transmit the security descriptor.
		/// </para>
		/// <para>
		/// To convert the string-format security descriptor back to a valid, functional security descriptor, call the
		/// ConvertStringSecurityDescriptorToSecurityDescriptor function.
		/// </para>
		/// </summary>
		/// <param name="SecurityDescriptor">
		/// <para>A pointer to the security descriptor to convert. The security descriptor can be in absolute or self-relative format.</para>
		/// </param>
		/// <param name="RequestedStringSDRevision">
		/// <para>Specifies the revision level of the output StringSecurityDescriptor string. Currently this value must be SDDL_REVISION_1.</para>
		/// </param>
		/// <param name="SecurityInformation">
		/// <para>
		/// Specifies a combination of the SECURITY_INFORMATION bit flags to indicate the components of the security descriptor to include in
		/// the output string.
		/// </para>
		/// </param>
		/// <param name="&#x9;&#x9;&#x9;&#x9;The BACKUP_SECURITY_INFORMATION &#x9;flag is not applicable to this function. If the BACKUP_SECURITY_INFORMATION &#x9;flag is passed in, the &amp;lt;i&amp;gt;SecurityInformation&amp;lt;/i&amp;gt; parameter returns TRUE with &amp;lt;b&amp;gt;null&amp;lt;/b&amp;gt; string output.&#xA;"/>
		/// <param name="StringSecurityDescriptor">
		/// <para>
		/// A pointer to a variable that receives a pointer to a <c>null</c>-terminated security descriptor string. For a description of the
		/// string format, see Security Descriptor String Format. To free the returned buffer, call the LocalFree function.
		/// </para>
		/// </param>
		/// <param name="StringSecurityDescriptorLen">
		/// <para>
		/// A pointer to a variable that receives the size, in <c>TCHAR</c> s, of the security descriptor string returned in the
		/// StringSecurityDescriptor buffer. This parameter can be <c>NULL</c> if you do not need to retrieve the size. The size represents
		/// the size of the buffer in <c>WCHAR</c> s, not the number of <c>WCHAR</c> s in the string.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>
		/// If the function fails, the return value is zero. To get extended error information, call GetLastError. The <c>GetLastError</c>
		/// function may return one of the following error codes.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>A parameter is not valid.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_UNKNOWN_REVISION</term>
		/// <term>The revision level is not valid.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NONE_MAPPED</term>
		/// <term>A security identifier (SID) in the input security descriptor could not be found in an account lookup operation.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_ACL</term>
		/// <term>
		/// The access control list (ACL) is not valid. This error is returned if the SE_DACL_PRESENT flag is set in the input security
		/// descriptor and the DACL is NULL.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If the DACL is <c>NULL</c>, and the SE_DACL_PRESENT control bit is set in the input security descriptor, the function fails.
		/// </para>
		/// <para>
		/// If the DACL is <c>NULL</c>, and the SE_DACL_PRESENT control bit is not set in the input security descriptor, the resulting
		/// security descriptor string does not have a D: component. For more information, see Security Descriptor String Format.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sddl/nf-sddl-convertsecuritydescriptortostringsecuritydescriptora
		// BOOL ConvertSecurityDescriptorToStringSecurityDescriptorA( PSECURITY_DESCRIPTOR SecurityDescriptor, DWORD RequestedStringSDRevision, SECURITY_INFORMATION SecurityInformation, LPSTR *StringSecurityDescriptor, PULONG StringSecurityDescriptorLen );
		[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("sddl.h", MSDNShortId = "36140833-8e30-4c32-a88a-c10751b6c223")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ConvertSecurityDescriptorToStringSecurityDescriptor(SafeSecurityDescriptor SecurityDescriptor, SDDL_REVISION RequestedStringSDRevision, 
			SECURITY_INFORMATION SecurityInformation, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LocalStringMarshaler), MarshalCookie = "Auto")] out string StringSecurityDescriptor, out uint StringSecurityDescriptorLen);

		/// <summary>
		/// <para>
		/// The <c>ConvertStringSecurityDescriptorToSecurityDescriptor</c> function converts a string-format security descriptor into a
		/// valid, functional security descriptor. This function retrieves a security descriptor that the
		/// ConvertSecurityDescriptorToStringSecurityDescriptor function converted to string format.
		/// </para>
		/// </summary>
		/// <param name="StringSecurityDescriptor">
		/// <para>A pointer to a null-terminated string containing the string-format security descriptor to convert.</para>
		/// </param>
		/// <param name="StringSDRevision">
		/// <para>Specifies the revision level of the StringSecurityDescriptor string. Currently this value must be SDDL_REVISION_1.</para>
		/// </param>
		/// <param name="SecurityDescriptor">
		/// <para>
		/// A pointer to a variable that receives a pointer to the converted security descriptor. The returned security descriptor is
		/// self-relative. To free the returned buffer, call the LocalFree function. To convert the security descriptor to an absolute
		/// security descriptor, use the MakeAbsoluteSD function.
		/// </para>
		/// </param>
		/// <param name="SecurityDescriptorSize">
		/// <para>
		/// A pointer to a variable that receives the size, in bytes, of the converted security descriptor. This parameter can be NULL.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>
		/// If the function fails, the return value is zero. To get extended error information, call GetLastError. <c>GetLastError</c> may
		/// return one of the following error codes.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>A parameter is not valid.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_UNKNOWN_REVISION</term>
		/// <term>The SDDL revision level is not valid.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NONE_MAPPED</term>
		/// <term>A security identifier (SID) in the input security descriptor string could not be found in an account lookup operation.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If <c>ace_type</c> is ACCESS_ALLOWED_OBJECT_ACE_TYPE and neither <c>object_guid</c> nor <c>inherit_object_guid</c> has a GUID
		/// specified, then <c>ConvertStringSecurityDescriptorToSecurityDescriptor</c> converts <c>ace_type</c> to ACCESS_ALLOWED_ACE_TYPE.
		/// For information about the <c>ace_type</c>, <c>object_guid</c>, and <c>inherit_object_guid</c> fields, see Ace Strings.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sddl/nf-sddl-convertstringsecuritydescriptortosecuritydescriptora
		// BOOL ConvertStringSecurityDescriptorToSecurityDescriptorA( LPCSTR StringSecurityDescriptor, DWORD StringSDRevision, PSECURITY_DESCRIPTOR *SecurityDescriptor, PULONG SecurityDescriptorSize );
		[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("sddl.h", MSDNShortId = "c5654148-fb4c-436d-9378-a1168fc82607")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ConvertStringSecurityDescriptorToSecurityDescriptor(string StringSecurityDescriptor, SDDL_REVISION StringSDRevision,
			out SafeSecurityDescriptor SecurityDescriptor, out uint SecurityDescriptorSize);
	}
}
