using System;
using System.Runtime.InteropServices;
using Vanara.Extensions;

namespace Vanara.PInvoke;

public static partial class AdvApi32
{
	/// <summary>
	/// <para>
	/// The <c>LSA_OBJECT_ATTRIBUTES</c> structure is used with the LsaOpenPolicy function to specify the attributes of the connection to
	/// the Policy object.
	/// </para>
	/// <para>
	/// When you call LsaOpenPolicy, initialize the members of this structure to <c>NULL</c> or zero because the function does not use
	/// the information.
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>The <c>LSA_OBJECT_ATTRIBUTES</c> structure is defined in the LsaLookup.h header file.</para>
	/// <para>
	/// <c>Windows Server 2008 with SP2 and earlier, Windows Vista with SP2 and earlier, Windows Server 2003, Windows XP/2000:</c> The
	/// <c>LSA_OBJECT_ATTRIBUTES</c> structure is defined in the NTSecAPI.h header file.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lsalookup/ns-lsalookup-_lsa_object_attributes typedef struct
	// _LSA_OBJECT_ATTRIBUTES { ULONG Length; HANDLE RootDirectory; PLSA_UNICODE_STRING ObjectName; ULONG Attributes; PVOID
	// SecurityDescriptor; PVOID SecurityQualityOfService; } LSA_OBJECT_ATTRIBUTES, *PLSA_OBJECT_ATTRIBUTES;
	[PInvokeData("lsalookup.h", MSDNShortId = "ad05cb52-8e58-46a9-b3e8-0c9c2a24a997")]
	[StructLayout(LayoutKind.Sequential)]
	public struct LSA_OBJECT_ATTRIBUTES
	{
		/// <summary>Specifies the size, in bytes, of the LSA_OBJECT_ATTRIBUTES structure.</summary>
		public int Length;

		/// <summary>Should be <c>NULL</c>.</summary>
		public IntPtr RootDirectory;

		/// <summary>Should be <c>NULL</c>.</summary>
		public IntPtr ObjectName;

		/// <summary>Should be zero.</summary>
		public int Attributes;

		/// <summary>Should be <c>NULL</c>.</summary>
		public IntPtr SecurityDescriptor;

		/// <summary>Should be <c>NULL</c>.</summary>
		public IntPtr SecurityQualityOfService;

		/// <summary>Returns a completely empty reference. This value should be used when calling <see cref="LsaOpenPolicy(string, in LSA_OBJECT_ATTRIBUTES, LsaPolicyRights, out SafeLSA_HANDLE)"/>.</summary>
		/// <value>An <see cref="LSA_OBJECT_ATTRIBUTES"/> instance with all members set to <c>NULL</c> or zero.</value>
		public static LSA_OBJECT_ATTRIBUTES Empty { get; } = new LSA_OBJECT_ATTRIBUTES();
	}

	/// <summary>
	/// The LSA_STRING structure is used by various Local Security Authority (LSA) functions to specify a string. Also an example of
	/// unnecessary over-engineering and re-engineering.
	/// </summary>
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Size = 8)]
	[PInvokeData("LsaLookup.h", MSDNShortId = "aa378522")]
	public struct LSA_STRING
	{
		/// <summary>
		/// Specifies the length, in bytes, of the string pointed to by the Buffer member, not including the terminating null character,
		/// if any.
		/// </summary>
		public ushort length;

		/// <summary>
		/// Specifies the total size, in bytes, of the memory allocated for Buffer. Up to MaximumLength bytes can be written into the
		/// buffer without trampling memory.
		/// </summary>
		public ushort MaximumLength;

		/// <summary>Pointer to a string. Note that the strings returned by the various LSA functions might not be null-terminated.</summary>
		[MarshalAs(UnmanagedType.LPStr)]
		public string? Buffer;

		/// <summary>Initializes a new instance of the <see cref="LSA_STRING"/> struct from a string.</summary>
		/// <param name="s">The string value.</param>
		/// <exception cref="ArgumentException">String exceeds 32Kb of data.</exception>
		public LSA_STRING(string? s)
		{
			if (s == null)
			{
				length = MaximumLength = 0;
				Buffer = null;
			}
			else
			{
				var l = s.Length;
				if (l >= ushort.MaxValue)
					throw new ArgumentException("String too long");
				Buffer = s;
				length = (ushort)l;
				MaximumLength = (ushort)(l + 1);
			}
		}

		/// <summary>Gets the number of characters in the string.</summary>
		public int Length => length;

		/// <summary>Returns a <see cref="string"/> that represents this instance.</summary>
		/// <returns>A <see cref="string"/> that represents this instance.</returns>
		public override string ToString() => Buffer?.Substring(0, Length) ?? string.Empty;

		/// <summary>Performs an implicit conversion from <see cref="LSA_STRING"/> to <see cref="string"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator string(LSA_STRING value) => value.ToString();
	}

	/// <summary>
	/// <para>
	/// The <c>LSA_TRANSLATED_NAME</c> structure is used with the LsaLookupSids function to return information about the account
	/// identified by a SID.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lsalookup/ns-lsalookup-_lsa_translated_name typedef struct
	// _LSA_TRANSLATED_NAME { SID_NAME_USE Use; LSA_UNICODE_STRING Name; LONG DomainIndex; } LSA_TRANSLATED_NAME, *PLSA_TRANSLATED_NAME;
	[PInvokeData("lsalookup.h", MSDNShortId = "edea8317-5cdf-4d1e-9e6d-fcf17b91adb7")]
	[StructLayout(LayoutKind.Sequential)]
	public struct LSA_TRANSLATED_NAME
	{
		/// <summary>An SID_NAME_USE enumeration value that identifies the type of SID.</summary>
		public SID_NAME_USE Use;

		/// <summary>
		/// An LSA_UNICODE_STRING structure that contains the isolated name of the translated SID. An isolated name is a user, group, or
		/// local group account name without the domain name (for example, user_name, rather than Acctg\user_name).
		/// </summary>
		public LSA_UNICODE_STRING Name;

		/// <summary>
		/// The index of an entry in a related LSA_REFERENCED_DOMAIN_LIST data structure which describes the domain that owns the
		/// account. If there is no corresponding reference domain for an entry, then DomainIndex will contain a negative value.
		/// </summary>
		public int DomainIndex;
	}

	/// <summary>
	/// <para>
	/// The <c>LSA_TRANSLATED_SID2</c> structure contains SIDs that are retrieved based on account names. This structure is used by the
	/// LsaLookupNames2 function.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lsalookup/ns-lsalookup-_lsa_translated_sid2 typedef struct
	// _LSA_TRANSLATED_SID2 { SID_NAME_USE Use; PSID Sid; LONG DomainIndex; ULONG Flags; } LSA_TRANSLATED_SID2, *PLSA_TRANSLATED_SID2;
	[PInvokeData("lsalookup.h", MSDNShortId = "792de958-8e24-46d8-b484-159435bc96e3")]
	[StructLayout(LayoutKind.Sequential)]
	public struct LSA_TRANSLATED_SID2
	{
		/// <summary>
		/// An SID_NAME_USE enumeration value that identifies the use of the SID. If this value is SidTypeUnknown or SidTypeInvalid, the
		/// rest of the information in the structure is not valid and should be ignored.
		/// </summary>
		public SID_NAME_USE Use;

		/// <summary>The complete SID of the account.</summary>
		public PSID Sid;

		/// <summary>
		/// The index of an entry in a related LSA_REFERENCED_DOMAIN_LIST data structure which describes the domain that owns the
		/// account. If there is no corresponding reference domain for an entry, then DomainIndex will contain a negative value.
		/// </summary>
		public int DomainIndex;

		/// <summary>Not used.</summary>
		public uint Flags;
	}

	/// <summary>A custom marshaler for functions using LSA_STRING so that managed strings can be used.</summary>
	/// <seealso cref="ICustomMarshaler"/>
	internal class LsaStringMarshaler : ICustomMarshaler
	{
		public static ICustomMarshaler GetInstance(string cookie) => new LsaStringMarshaler();

		public void CleanUpManagedData(object ManagedObj)
		{
		}

		public void CleanUpNativeData(IntPtr pNativeData)
		{
			if (pNativeData == IntPtr.Zero) return;
			Marshal.FreeCoTaskMem(pNativeData);
			pNativeData = IntPtr.Zero;
		}

		public int GetNativeDataSize() => Marshal.SizeOf(typeof(LSA_STRING));

		public IntPtr MarshalManagedToNative(object ManagedObj)
		{
			if (ManagedObj is not string s)
				return IntPtr.Zero;
			var str = new LSA_STRING(s);
			return str.MarshalToPtr(Marshal.AllocCoTaskMem, out var _);
		}

		public object MarshalNativeToManaged(IntPtr pNativeData)
		{
			if (pNativeData == IntPtr.Zero) return string.Empty;
			var ret = pNativeData.ToStructure<LSA_STRING>();
			var s = (string)ret.ToString().Clone();
			//LsaFreeMemory(pNativeData);
			return s;
		}
	}
}