using System;
using System.Security.AccessControl;
using System.Security.Principal;
using Vanara.Extensions;
using Vanara.InteropServices;
using Vanara.PInvoke;
using static Vanara.PInvoke.AdvApi32;

namespace Vanara.Security.AccessControl;

/// <summary>Helper methods for working with Access Control structures.</summary>
public static class AccessControlHelper
{
	/// <summary>Gets the number of ACEs held by an ACL.</summary>
	/// <param name="pAcl">The pointer to the ACL structure to query.</param>
	/// <returns>The ace count.</returns>
	[Obsolete("This function will be retired in a future release. Use the AceCount extension method from Vanara.PInvoke.WinNTExtensions in the Vanara.PInvoke.Security package.")]
	public static uint GetAceCount(this PACL pAcl) => pAcl.AceCount();

	/// <summary>Gets the size, in bytes, of an ACL. If the ACL is not valid, 0 is returned.</summary>
	/// <param name="pAcl">The pointer to the ACL structure to query.</param>
	/// <returns>The size, in bytes, of an ACL. If the ACL is not valid, 0 is returned.</returns>
	[Obsolete("This function will be retired in a future release. Use the Length extension method from Vanara.PInvoke.WinNTExtensions in the Vanara.PInvoke.Security package.")]
	public static uint GetAclSize(PACL pAcl) => pAcl.Length();

	/// <summary>Gets the access rights for the identity on the provided security descriptor.</summary>
	/// <param name="pSD">The security descriptor to check for access rights.</param>
	/// <param name="pSid">The SID of the identity for which to get the rights.</param>
	/// <returns>The access rights bitmask.</returns>
	public static uint GetEffectiveRights(this PSECURITY_DESCRIPTOR pSD, PSID pSid)
	{
		BuildTrusteeWithSid(out var t, pSid);
		GetSecurityDescriptorDacl(pSD, out _, out var pDacl, out _);
		GetEffectiveRightsFromAcl(pDacl, t, out var access);
		return access;
	}

	/// <summary>Gets the access rights for the identity on the provided security descriptor.</summary>
	/// <param name="sd">The security descriptor to check for access rights.</param>
	/// <param name="sid">The SID of the identity for which to get the rights.</param>
	/// <returns>The access rights bitmask.</returns>
	public static uint GetEffectiveRights(this RawSecurityDescriptor sd, SecurityIdentifier sid)
	{
		BuildTrusteeWithSid(out var t, GetPSID(sid));
		using var pDacl = new PinnedAcl(sd.DiscretionaryAcl);
		GetEffectiveRightsFromAcl(pDacl.PACL, t, out var access);
		return access;
	}

	/// <summary>Gets a pointer to a SID from a <see cref="SecurityIdentifier"/>.</summary>
	/// <param name="sid">The <see cref="SecurityIdentifier"/> instance.</param>
	/// <returns>The PSID value.</returns>
	public static PSID GetPSID(this SecurityIdentifier sid)
	{
		using var ps = new PinnedSid(sid);
		return ps.PSID;
	}

	/// <summary>Gets the <see cref="RawAcl"/> equivalent of an ACL.</summary>
	/// <param name="pAcl">The pointer to an ACL structure.</param>
	/// <returns>The <see cref="RawAcl"/> instance.</returns>
	public static RawAcl RawAclFromPtr(PACL pAcl) => new RawAcl(((IntPtr)pAcl).ToByteArray((int)pAcl.Length()), 0);

	/// <summary>Converts a security descriptor to its SDDL string format.</summary>
	/// <param name="pSD">The security descriptor.</param>
	/// <param name="si">The elements of the security descriptor to return.</param>
	/// <returns>The SDDL string representation of the security descriptor.</returns>
	public static string ToSddl(this PSECURITY_DESCRIPTOR pSD, SECURITY_INFORMATION si) => ConvertSecurityDescriptorToStringSecurityDescriptor(pSD, si);

	/// <summary>Converts a security descriptor to its SDDL string format.</summary>
	/// <param name="pSD">The security descriptor.</param>
	/// <param name="si">The elements of the security descriptor to return.</param>
	/// <returns>The SDDL string representation of the security descriptor.</returns>
	public static string ToSddl(this SafePSECURITY_DESCRIPTOR pSD, SECURITY_INFORMATION si) => ConvertSecurityDescriptorToStringSecurityDescriptor(pSD, si);
}

/// <summary>Enables access to managed <see cref="RawAcl"/> as unmanaged <see cref="T:byte[]"/>.</summary>
public class PinnedAcl : PinnedObject
{
	private readonly byte[] bytes;

	/// <summary>Initializes a new instance of the <see cref="PinnedAcl"/> class.</summary>
	/// <param name="acl">The <see cref="RawAcl"/> instance.</param>
	public PinnedAcl(RawAcl acl)
	{
		bytes = new byte[acl.BinaryLength];
		acl.GetBinaryForm(bytes, 0);
		SetObject(bytes);
	}

	/// <summary>Gets the PACL value.</summary>
	public PACL PACL => (IntPtr)this;
}

/// <summary>Enables access to managed <see cref="ObjectSecurity"/> as unmanaged <see cref="T:byte[]"/>.</summary>
public class PinnedSecurityDescriptor : PinnedObject
{
	private readonly byte[] bytes;

	/// <summary>Initializes a new instance of the <see cref="PinnedSecurityDescriptor"/> class.</summary>
	/// <param name="sd">The object security.</param>
	public PinnedSecurityDescriptor(ObjectSecurity sd)
	{
		bytes = sd.GetSecurityDescriptorBinaryForm();
		SetObject(bytes);
	}

	/// <summary>Gets the PSECURITY_DESCRIPTOR value.</summary>
	public PSECURITY_DESCRIPTOR PSECURITY_DESCRIPTOR => (IntPtr)this;
}

/// <summary>Enables access to managed <see cref="SecurityIdentifier"/> as unmanaged <see cref="PSID"/>.</summary>
/// <seealso cref="Vanara.InteropServices.PinnedObject"/>
public class PinnedSid : PinnedObject
{
	private readonly byte[] bytes;

	/// <summary>Initializes a new instance of the <see cref="PinnedSid"/> class.</summary>
	/// <param name="sid">The sid.</param>
	public PinnedSid(SecurityIdentifier sid)
	{
		bytes = new byte[sid.BinaryLength];
		sid.GetBinaryForm(bytes, 0);
		SetObject(bytes);
	}

	/// <summary>Gets the PSID value.</summary>
	public PSID PSID => (IntPtr)this;
}