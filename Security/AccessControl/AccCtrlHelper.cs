using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security.Principal;
using Vanara.InteropServices;
using Vanara.PInvoke;
using static Vanara.PInvoke.AdvApi32;

namespace Vanara.Security.AccessControl
{
	/// <summary>Enables access to managed <see cref="SecurityIdentifier"/> as unmanaged <see cref="PSID"/>.</summary>
	/// <seealso cref="Vanara.InteropServices.PinnedObject"/>
	public class PinnedSid : PinnedObject
	{
		private readonly byte[] bytes;

		public PinnedSid(SecurityIdentifier sid)
		{
			bytes = new byte[sid.BinaryLength];
			sid.GetBinaryForm(bytes, 0);
			SetObject(bytes);
		}

		public PSID PSID => PSID.CreateFromPtr(this);
	}

	/// <summary>Enables access to managed <see cref="RawAcl"/> as unmanaged <see cref="T:byte[]"/>.</summary>
	public class PinnedAcl : PinnedObject
	{
		private readonly byte[] bytes;

		public PinnedAcl(RawAcl acl)
		{
			bytes = new byte[acl.BinaryLength];
			acl.GetBinaryForm(bytes, 0);
			SetObject(bytes);
		}
	}

	/// <summary>Enables access to managed <see cref="ObjectSecurity"/> as unmanaged <see cref="T:byte[]"/>.</summary>
	public class PinnedSecurityDescriptor : PinnedObject
	{
		private readonly byte[] bytes;

		public PinnedSecurityDescriptor(ObjectSecurity sd)
		{
			bytes = sd.GetSecurityDescriptorBinaryForm();
			SetObject(bytes);
		}
	}

	/// <summary>Helper methods for working with Access Control structures.</summary>
	public static class AccessControlHelper
	{
		public static ACCESS_ALLOWED_ACE GetAce(IntPtr pAcl, int aceIndex)
		{
			if (AdvApi32.GetAce(pAcl, aceIndex, out IntPtr acePtr))
				return (ACCESS_ALLOWED_ACE)Marshal.PtrToStructure(acePtr, typeof(ACCESS_ALLOWED_ACE));
			throw new System.ComponentModel.Win32Exception();
		}

		public static uint GetAceCount(IntPtr pAcl) => GetAclInfo(pAcl).AceCount;

		public static ACL_SIZE_INFORMATION GetAclInfo(IntPtr pAcl)
		{
			var si = new ACL_SIZE_INFORMATION();
			if (!GetAclInformation(pAcl, ref si, (uint)Marshal.SizeOf(si), ACL_INFORMATION_CLASS.AclSizeInformation))
				throw new System.ComponentModel.Win32Exception();
			return si;
		}

		public static uint GetAclSize(IntPtr pAcl) => GetAclInfo(pAcl).AclBytesInUse;

		public static uint GetEffectiveRights(this PSID pSid, SafeSecurityDescriptor pSD)
		{
			var t = new TRUSTEE(pSid);
			GetSecurityDescriptorDacl(pSD, out bool daclPresent, out IntPtr pDacl, out bool daclDefaulted);
			uint access = 0;
			GetEffectiveRightsFromAcl(pDacl, t, ref access);
			return access;
		}

		public static uint GetEffectiveRights(this RawSecurityDescriptor sd, SecurityIdentifier sid)
		{
			var t = new TRUSTEE(GetPSID(sid));
			uint access = 0;
			using (var pDacl = new PinnedAcl(sd.DiscretionaryAcl))
				GetEffectiveRightsFromAcl(pDacl, t, ref access);

			return access;
		}

		public static IEnumerable<INHERITED_FROM> GetInheritanceSource(string objectName, System.Security.AccessControl.ResourceType objectType,
			SECURITY_INFORMATION securityInfo, bool container, IntPtr pAcl, ref GENERIC_MAPPING pGenericMapping)
		{
			var objSize = Marshal.SizeOf(typeof(INHERITED_FROM));
			var aceCount = GetAceCount(pAcl);
			using (var pInherit = new SafeInheritedFromArray((ushort)aceCount))
			{
				AdvApi32.GetInheritanceSource(objectName, (SE_OBJECT_TYPE)objectType, securityInfo, container, null, 0, pAcl, IntPtr.Zero, ref pGenericMapping, pInherit).ThrowIfFailed();
				return pInherit.Results;
			}
		}

		public static PSID GetPSID(this SecurityIdentifier sid) { using (var ps = new PinnedSid(sid)) return ps.PSID; }

		public static SafeSecurityDescriptor GetPrivateObjectSecurity(this SafeSecurityDescriptor pSD, SECURITY_INFORMATION si)
		{
			var pResSD = SafeSecurityDescriptor.Null;
			AdvApi32.GetPrivateObjectSecurity(pSD, si, pResSD, 0, out uint ret);
			if (ret > 0)
			{
				pResSD = new SafeSecurityDescriptor((int)ret);
				if (!pResSD.IsInvalid && !AdvApi32.GetPrivateObjectSecurity(pSD, si, pResSD, ret, out ret))
					Win32Error.GetLastError().ThrowIfFailed();
			}
			return pResSD;
		}

		public static RawAcl RawAclFromPtr(IntPtr pAcl)
		{
			var len = GetAclSize(pAcl);
			var dest = new byte[len];
			Marshal.Copy(pAcl, dest, 0, (int)len);
			return new RawAcl(dest, 0);
		}

		public static string ToSddl(this SafeSecurityDescriptor pSD, SECURITY_INFORMATION si) => ConvertSecurityDescriptorToStringSecurityDescriptor(pSD, SDDL_REVISION.SDDL_REVISION_1, si, out var ssd, out var _) ? ssd : null;
	}
}