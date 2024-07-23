using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using static Vanara.PInvoke.AdvApi32;

namespace Vanara.PInvoke;

/// <summary>Extension methods for PACE, PACL and PSECURITY_DESCRIPTOR.</summary>
public static class WinNTExtensions
{
	/// <summary>Gets the number of ACEs held by an ACL.</summary>
	/// <param name="pACL">The pointer to the ACL structure to query.</param>
	/// <returns>The ace count.</returns>
	public static uint AceCount(this PACL pACL) => IsValidAcl(pACL) && GetAclInformation(pACL, out ACL_SIZE_INFORMATION si) ? si.AceCount : 0;

	/// <summary>Gets the total number of bytes allocated to the ACL.</summary>
	/// <param name="pACL">The pointer to the ACL structure to query.</param>
	/// <returns>The total of the free and used bytes in the ACL.</returns>
	public static uint BytesAllocated(this PACL pACL) => IsValidAcl(pACL) && GetAclInformation(pACL, out ACL_SIZE_INFORMATION si) ? si.AclBytesFree + si.AclBytesInUse : 0;

	/// <summary>Compares two Access Control Entries given their pointers.</summary>
	/// <param name="x">The pointer to the first ACE to compare.</param>
	/// <param name="y">The pointer to the second ACE to compare.</param>
	/// <returns>
	/// <para>
	/// A signed integer that indicates the relative values of <paramref name="x"/> and <paramref name="y"/>, as shown in the following table.
	/// </para>
	/// <list type="table">
	/// <item>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </item>
	/// <item>
	/// <description>Less than zero</description>
	/// <description><paramref name="x"/> is less than <paramref name="y"/>.</description>
	/// </item>
	/// <item>
	/// <description>Zero</description>
	/// <description><paramref name="x"/> equals <paramref name="y"/>.</description>
	/// </item>
	/// <item>
	/// <description>Greater than zero</description>
	/// <description><paramref name="x"/> is greater than <paramref name="y"/>.</description>
	/// </item>
	/// </list>
	/// </returns>
	public static int CompareTo(this PACE x, PACE y)
	{
		if ((IntPtr)x == (IntPtr)y) return 0;
		if (x.IsNull && y.IsNull) return 0;
		if (y.IsNull) return 1;
		if (x.IsNull) return -1;
		var lh = x.GetHeader();
		var rh = y.GetHeader();
		var ret = lh.AceTypeNative.CompareTo(rh.AceTypeNative);
		if (ret != 0) return ret;
		ret = lh.AceFlags.CompareTo(rh.AceFlags);
		if (ret != 0) return ret;
		ret = lh.AceSize.CompareTo(rh.AceSize);
		if (ret != 0) return ret;
		var lm = x.GetMask();
		var rm = y.GetMask();
		ret = lm.CompareTo(rm);
		if (ret != 0) return ret;
		if (x.IsObjectAce())
		{
			ref ACCESS_ALLOWED_OBJECT_ACE loa = ref ((IntPtr)x).AsRef<ACCESS_ALLOWED_OBJECT_ACE>();
			ref ACCESS_ALLOWED_OBJECT_ACE roa = ref ((IntPtr)y).AsRef<ACCESS_ALLOWED_OBJECT_ACE>();
			ret = loa.Flags.CompareTo(roa.Flags);
			if (ret != 0) return ret;
			ret = loa.ObjectType.CompareTo(roa.ObjectType);
			if (ret != 0) return ret;
			ret = loa.InheritedObjectType.CompareTo(roa.InheritedObjectType);
			if (ret != 0) return ret;
		}
		using var ls = x.GetSid();
		using var rs = y.GetSid();
		return ls.ToString("D").CompareTo(rs.ToString("D"));
	}

	/// <summary>Compares two Access Control Lists given their pointers.</summary>
	/// <param name="x">The pointer to the first ACL to compare.</param>
	/// <param name="y">The pointer to the second ACL to compare.</param>
	/// <returns>
	/// <para>
	/// A signed integer that indicates the relative values of <paramref name="x"/> and <paramref name="y"/>, as shown in the following table.
	/// </para>
	/// <list type="table">
	/// <item>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </item>
	/// <item>
	/// <description>Less than zero</description>
	/// <description><paramref name="x"/> is less than <paramref name="y"/>.</description>
	/// </item>
	/// <item>
	/// <description>Zero</description>
	/// <description><paramref name="x"/> equals <paramref name="y"/>.</description>
	/// </item>
	/// <item>
	/// <description>Greater than zero</description>
	/// <description><paramref name="x"/> is greater than <paramref name="y"/>.</description>
	/// </item>
	/// </list>
	/// </returns>
	public static int CompareTo(this PACL x, PACL y)
	{
		if ((IntPtr)x == (IntPtr)y) return 0;
		if (!x.IsValidAcl() && !y.IsValidAcl()) return 0;
		if (!y.IsValidAcl()) return 1;
		if (!x.IsValidAcl()) return -1;
		GetAclInformation(x, out ACL_REVISION_INFORMATION lr);
		GetAclInformation(y, out ACL_REVISION_INFORMATION rr);
		var ret = lr.AclRevision.CompareTo(rr);
		if (ret != 0) return ret;
		GetAclInformation(x, out ACL_SIZE_INFORMATION li);
		GetAclInformation(y, out ACL_SIZE_INFORMATION ri);
		ret = li.AceCount.CompareTo(ri.AceCount);
		if (ret != 0) return ret;
		ret = li.AclBytesInUse.CompareTo(ri.AclBytesInUse);
		if (ret != 0) return ret;
		for (uint i = 0; i < li.AceCount; i++)
		{
			ret = x.GetAce(i).CompareTo(y.GetAce(i));
			if (ret != 0) return ret;
		}
		return 0;
	}

	/// <summary>Enumerates the ACEs in an ACL.</summary>
	/// <param name="pAcl">A pointer to an ACL that contains the ACE to be retrieved.</param>
	/// <returns>A sequence of PACE values from the ACL.</returns>
	public static IEnumerable<PACE> EnumerateAces(this PACL pAcl)
	{
		for (var i = 0U; i < pAcl.AceCount(); i++)
			yield return GetAce(pAcl, i);
	}

	/// <summary>Indicates whether the values of two specified Access Control Entries are equal, given their pointers.</summary>
	/// <param name="x">The first value to compare.</param>
	/// <param name="y">The second value to compare.</param>
	/// <returns><see langword="true"/> if <paramref name="x"/> and <paramref name="y"/> are equal; otherwise, <see langword="false"/>.</returns>
	public static bool Equals(this PACE x, PACE y) => CompareTo(x, y) == 0;

	/// <summary>Indicates whether the values of two specified Access Control List are equal, given their pointers.</summary>
	/// <param name="x">The first value to compare.</param>
	/// <param name="y">The second value to compare.</param>
	/// <returns><see langword="true"/> if <paramref name="x"/> and <paramref name="y"/> are equal; otherwise, <see langword="false"/>.</returns>
	public static bool Equals(this PACL x, PACL y) => CompareTo(x, y) == 0;

	/// <summary>The <c>GetAce</c> function obtains a pointer to an access control entry (ACE) in an access control list (ACL).</summary>
	/// <param name="pAcl">A pointer to an ACL that contains the ACE to be retrieved.</param>
	/// <param name="aceIndex">
	/// The index of the ACE to be retrieved. A value of zero corresponds to the first ACE in the ACL, a value of one to the second ACE,
	/// and so on.
	/// </param>
	/// <returns>A pointer to the ACE.</returns>
	public static PACE GetAce(this PACL pAcl, uint aceIndex)
	{
		Win32Error.ThrowLastErrorIfFalse(AdvApi32.GetAce(pAcl, aceIndex, out var acePtr));
		return acePtr;
	}

	/// <summary>Gets the ace value as the structure defined by the ACE's type.</summary>
	/// <param name="pAce">The ACE pointer.</param>
	/// <returns>The structure pointed to by <paramref name="pAce"/> and defined by the ACE's type.</returns>
	public static object? GetAceStruct(this PACE pAce)
	{
		var hdr = pAce.GetHeader();
		var type = CorrespondingTypeAttribute.GetCorrespondingTypes(hdr.AceTypeNative).FirstOrDefault();
		return type is null ? null : ((IntPtr)pAce).ToStructure(type);
	}

	/// <summary>Gets the Flags for an ACE, if defined.</summary>
	/// <param name="pAce">A pointer to an ACE.</param>
	/// <returns>The Flags value, if this is an object ACE, otherwise <see langword="null"/>.</returns>
	/// <exception cref="ArgumentNullException">pAce</exception>
	public static AdvApi32.ObjectAceFlags? GetFlags(this PACE pAce)
	{
		if (pAce.IsNull) throw new ArgumentNullException(nameof(pAce));
		return !pAce.IsObjectAce() ? null : pAce.DangerousGetHandle().AsRef<ACCESS_ALLOWED_OBJECT_ACE>().Flags;
	}

	/// <summary>Gets the header for an ACE.</summary>
	/// <param name="pAce">A pointer to an ACE.</param>
	/// <returns>The <see cref="ACE_HEADER"/> value.</returns>
	/// <exception cref="ArgumentNullException">pAce</exception>
	public static ACE_HEADER GetHeader(this PACE pAce) => !pAce.IsNull ? pAce.DangerousGetHandle().AsRef<ACE_HEADER>() : throw new ArgumentNullException(nameof(pAce));

	/// <summary>Gets the InheritedObjectType for an ACE, if defined.</summary>
	/// <param name="pAce">A pointer to an ACE.</param>
	/// <returns>The InheritedObjectType value, if this is an object ACE, otherwise <see langword="null"/>.</returns>
	/// <exception cref="ArgumentNullException">pAce</exception>
	public static Guid? GetInheritedObjectType(this PACE pAce)
	{
		if (pAce.IsNull) throw new ArgumentNullException(nameof(pAce));
		return !pAce.IsObjectAce() ? null : pAce.DangerousGetHandle().AsRef<ACCESS_ALLOWED_OBJECT_ACE>().InheritedObjectType;
	}

	/// <summary>
	/// The function gets the integrity level of the token. Integrity level is only available on Windows Vista and newer operating
	/// systems, thus GetIntegrityLevel throws an exception if it is called on systems prior to Windows Vista.
	/// </summary>
	/// <returns>Returns the integrity level of the token.</returns>
	public static MANDATORY_LEVEL GetIntegrityLevel(this HTOKEN token)
	{
		// Marshal the TOKEN_MANDATORY_LABEL struct from native to .NET object. 
		var tokenIL = GetTokenInformation<TOKEN_MANDATORY_LABEL>(token, TOKEN_INFORMATION_CLASS.TokenIntegrityLevel);

		// Integrity Level SIDs are in the form of S-1-16-0xXXXX. (e.g. S-1-16-0x1000 stands for low integrity level SID). There is one and only one subauthority.
		return (MANDATORY_LEVEL)GetSidSubAuthority(tokenIL.Label.Sid, 0);
	}

	/// <summary>
	/// The function gets the integrity level of the security descriptor. Integrity level is only available on Windows Vista and newer
	/// operating systems, thus GetIntegrityLevel throws an exception if it is called on systems prior to Windows Vista.
	/// </summary>
	/// <returns>Returns the integrity level of the security descriptor.</returns>
	public static MANDATORY_LEVEL GetIntegrityLevel(this PSECURITY_DESCRIPTOR pSD)
	{
		if (GetSecurityDescriptorSacl(pSD, out var present, out var sacl, out _) && present)
		{
			// Marshal the TOKEN_MANDATORY_LABEL struct from native to .NET object.
			var pACE = sacl.EnumerateAces().FirstOrDefault(a => a.GetAceType() == (AceType)0x11 /*SYSTEM_MANDATORY_LABEL_ACE_TYPE*/);
			if (!pACE.IsNull)
			{
				using var psid = pACE.GetSid();
				// Integrity Level SIDs are in the form of S-1-16-0xXXXX. (e.g. S-1-16-0x1000 stands for low integrity level SID). There is one and only one subauthority.
				return (MANDATORY_LEVEL)GetSidSubAuthority(psid, 0);
			}
		}
		return MANDATORY_LEVEL.MandatoryLevelUntrusted;
	}

	/// <summary>Gets the mask for an ACE.</summary>
	/// <param name="pAce">A pointer to an ACE.</param>
	/// <returns>The ACCESS_MASK value.</returns>
	/// <exception cref="ArgumentNullException">pAce</exception>
	public static uint GetMask(this PACE pAce)
	{
		if (pAce.IsNull) throw new ArgumentNullException(nameof(pAce));
		var offset = Marshal.SizeOf(typeof(ACE_HEADER));
		return unchecked((uint)Marshal.ReadInt32(((IntPtr)pAce).Offset(offset)));
	}

	/// <summary>Gets the ObjectType for an ACE, if defined.</summary>
	/// <param name="pAce">A pointer to an ACE.</param>
	/// <returns>The ObjectType value, if this is an object ACE, otherwise <see langword="null"/>.</returns>
	/// <exception cref="ArgumentNullException">pAce</exception>
	public static Guid? GetObjectType(this PACE pAce)
	{
		if (pAce.IsNull) throw new ArgumentNullException(nameof(pAce));
		return !pAce.IsObjectAce() ? null : pAce.DangerousGetHandle().AsRef<ACCESS_ALLOWED_OBJECT_ACE>().ObjectType;
	}

	/// <summary>Gets the SID for an ACE.</summary>
	/// <param name="pAce">A pointer to an ACE.</param>
	/// <returns>The SID value.</returns>
	/// <exception cref="ArgumentNullException">pAce</exception>
	public static SafePSID GetSid(this PACE pAce)
	{
		if (pAce.IsNull) throw new ArgumentNullException(nameof(pAce));
		var offset = Marshal.SizeOf(typeof(ACE_HEADER)) + sizeof(uint);
		if (pAce.IsObjectAce()) offset += sizeof(uint) + Marshal.SizeOf(typeof(Guid)) * 2;
		if (pAce.IsAlarmAce())
			return GetSid((PACE)((IntPtr)pAce).Offset(offset));
		return SafePSID.CreateFromPtr(((IntPtr)pAce).Offset(offset));
	}

	/// <summary>Gets the AceType for an ACE, if defined.</summary>
	/// <param name="pAce">A pointer to an ACE.</param>
	/// <returns>The AceType value.</returns>
	public static AceType GetAceType(this PACE pAce) => GetHeader(pAce).AceType;

	/// <summary>Determines if a ACE is an alarm ACE.</summary>
	/// <param name="pAce">A pointer to an ACE.</param>
	/// <returns><see langword="true"/> if is this is an alarm ACE; otherwise, <see langword="false"/>.</returns>
	/// <exception cref="ArgumentNullException">pAce</exception>
	/// <exception cref="ArgumentOutOfRangeException">pAce - Unknown ACE type.</exception>
	public static bool IsAlarmAce(this PACE pAce)
	{
		if (pAce.IsNull) throw new ArgumentNullException(nameof(pAce));
		var aceType = (byte)GetHeader(pAce).AceTypeNative;
		if (aceType > 0x15) throw new ArgumentOutOfRangeException(nameof(pAce), "Unknown ACE type.");
		return aceType is 0x3 or 0x8 or 0xE or 0x10;
	}

	/// <summary>Determines if a ACE is an object ACE.</summary>
	/// <param name="pAce">A pointer to an ACE.</param>
	/// <returns><see langword="true"/> if is this is an object ACE; otherwise, <see langword="false"/>.</returns>
	/// <exception cref="ArgumentNullException">pAce</exception>
	/// <exception cref="ArgumentOutOfRangeException">pAce - Unknown ACE type.</exception>
	public static bool IsObjectAce(this PACE pAce)
	{
		if (pAce.IsNull) throw new ArgumentNullException(nameof(pAce));
		var aceType = (byte)GetHeader(pAce).AceTypeNative;
		if (aceType > 0x15) throw new ArgumentOutOfRangeException(nameof(pAce), "Unknown ACE type.");
		return aceType is >= 0x5 and <= 0x8 or 0xB or 0xC or 0xF or 0x10;
	}

	/// <summary>Determines whether the security descriptor is self-relative.</summary>
	/// <param name="pSD">The pointer to the SECURITY_DESCRIPTOR structure to query.</param>
	/// <returns><c>true</c> if it is self-relative; otherwise, <c>false</c>.</returns>
	public static bool IsSelfRelative(this PSECURITY_DESCRIPTOR pSD) => GetSecurityDescriptorControl(pSD, out var ctrl, out _) ? ctrl.IsFlagSet(SECURITY_DESCRIPTOR_CONTROL.SE_SELF_RELATIVE) : throw Win32Error.GetLastError().GetException()!;

	/// <summary>Validates an access control list (ACL).</summary>
	/// <param name="pAcl">The pointer to the ACL structure to query.</param>
	/// <returns><c>true</c> if the ACL is valid; otherwise, <c>false</c>.</returns>
	public static bool IsValidAcl(this PACL pAcl) => AdvApi32.IsValidAcl(pAcl);

	/// <summary>Determines whether the components of a security descriptor are valid.</summary>
	/// <param name="pSD">The pointer to the SECURITY_DESCRIPTOR structure to query.</param>
	/// <returns>
	/// <c>true</c> if the components of the security descriptor are valid. If any of the components of the security descriptor are not
	/// valid, the return value is <c>false</c>.
	/// </returns>
	public static bool IsValidSecurityDescriptor(this PSECURITY_DESCRIPTOR pSD) => AdvApi32.IsValidSecurityDescriptor(pSD);

	/// <summary>Gets the size, in bytes, of an ACE.</summary>
	/// <param name="pAce">The pointer to the ACE structure to query.</param>
	/// <returns>The size, in bytes, of the ACE.</returns>
	public static uint Length(this PACE pAce) => GetHeader(pAce).AceSize;

	/// <summary>Gets the size, in bytes, of an ACL. If the ACL is not valid, 0 is returned.</summary>
	/// <param name="pACL">The pointer to the ACL structure to query.</param>
	/// <returns>The size, in bytes, of an ACL. If the ACL is not valid, 0 is returned.</returns>
	public static uint Length(this PACL pACL) => IsValidAcl(pACL) && GetAclInformation(pACL, out ACL_SIZE_INFORMATION si) ? si.AclBytesInUse : 0;

	/// <summary>Gets the size, in bytes, of a security descriptor. If it is not valid, 0 is returned.</summary>
	/// <param name="pSD">The pointer to the SECURITY_DESCRIPTOR structure to query.</param>
	/// <returns>The size, in bytes, of a security descriptor. If it is not valid, 0 is returned.</returns>
	public static uint Length(this PSECURITY_DESCRIPTOR pSD) => IsValidSecurityDescriptor(pSD) ? GetSecurityDescriptorLength(pSD) : 0U;

	/// <summary>Gets the revision number for the ACL.</summary>
	/// <param name="pACL">The pointer to the ACL structure to query.</param>
	/// <value>The revision.</value>
	public static uint Revision(this PACL pACL) => IsValidAcl(pACL) && GetAclInformation(pACL, out ACL_REVISION_INFORMATION ri) ? ri.AclRevision : 0U;
}