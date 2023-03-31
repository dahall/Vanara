using NUnit.Framework;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.AdvApi32;

namespace Vanara.PInvoke.Tests;

public static class UtilExt
{
	public static byte[] GetBytes(this SecurityIdentifier si)
	{
		if (si == null) return new byte[0];
		var sidLen = si.BinaryLength;
		var bytes = new byte[sidLen];
		si.GetBinaryForm(bytes, 0);
		return bytes;
	}
}

[TestFixture()]
public class PSIDTests
{
	[Test()]
	public void AllocateAndInitializeSidTest()
	{
		var b = AllocateAndInitializeSid(KnownSIDAuthority.SECURITY_WORLD_SID_AUTHORITY, 1, KnownSIDRelativeID.SECURITY_WORLD_RID, 0, 0, 0, 0, 0, 0, 0, out var pSid);
		Assert.That(b);
		var everyone = new SecurityIdentifier(WellKnownSidType.WorldSid, null);
		var esid = new byte[everyone.BinaryLength];
		everyone.GetBinaryForm(esid, 0);
		var peSid = new SafeByteArray(esid);
		Assert.That(EqualSid(pSid, (IntPtr)peSid));
		ConvertStringSidToSid("S-1-2-0", out var lsid);
		Assert.That(EqualSid(pSid, (IntPtr)lsid), Is.False);
		string s = null;
		Assert.That(IsValidSid(pSid), Is.True);
		Assert.That(() => s = ConvertSidToStringSid(pSid), Throws.Nothing);
		Assert.That(s, Is.EqualTo("S-1-1-0"));
		Assert.That(GetSidSubAuthority(pSid, 0), Is.EqualTo(0));
		var len = GetLengthSid(pSid);
		var p2 = new SafePSID(len);
		b = CopySid(len, (IntPtr)p2, pSid);
		Assert.That(EqualSid(p2, pSid));
		Assert.That(b);
	}

	[Test()]
	public void CloneTest()
	{
		using var sid = SafePSID.Current;
		using var sid2 = sid.Clone();
		Assert.That(sid2.IsValidSid);
		Assert.That(sid, Is.EqualTo(sid2));
	}

	[Test()]
	public void CopyTest()
	{
		using var sid = SafePSID.Current;
		Assert.That(!sid.IsInvalid);
		Assert.That(sid.IsValidSid);
		Assert.That(sid.ToString(), Does.StartWith("S-1-5"));
	}

	[Test]
	public void EqualDomainSidTest()
	{
		Assert.That(EqualDomainSid(SafePSID.Current, SafePSID.Current, out var eq), ResultIs.Successful);
		Assert.That(eq, Is.True);
	}

	[Test]
	public void EqualPrefixSidTest()
	{
		Assert.That(EqualPrefixSid(SafePSID.Current, SafePSID.Everyone), Is.False);
	}

	[Test]
	public void EqualsTest()
	{
		using var ssid = new SafePSID("S-1-1-0");
		using var esid = SafePSID.Everyone;
		using var mesid = SafePSID.Current;
		Assert.That(ssid == esid, Is.True);
		Assert.That(ssid != mesid, Is.True);
		Assert.That(ssid.Equals(null), Is.False);
		Assert.That(ssid == null, Is.False);
		Assert.That(ssid.Equals((PSID)esid), Is.True);
		Assert.That(ssid.Equals((IntPtr)esid), Is.True);
		Assert.That(ssid.Equals((object)esid), Is.True);
		Assert.That(ssid.Equals((object)(PSID)esid), Is.True);
		Assert.That(ssid.Equals((object)(IntPtr)esid), Is.True);
		Assert.That(ssid.Equals((object)54), Is.False);
	}

	[Test()]
	public void GetBinaryForm()
	{
		using var sid = new SafePSID("S-1-1-0");
		Assert.That(sid.GetBinaryForm(), Is.EquivalentTo(new SecurityIdentifier(WellKnownSidType.WorldSid, null).GetBytes()));
	}

	[Test]
	public void GetSidIdentifierAuthorityTest()
	{
		Assert.That(GetSidIdentifierAuthority(SafePSID.Everyone), Is.EqualTo(KnownSIDAuthority.SECURITY_WORLD_SID_AUTHORITY));
	}

	[Test]
	public void GetSidLengthRequiredTest()
	{
		Assert.That(GetSidLengthRequired(6), ResultIs.Not.Value(0));
	}

	[Test]
	public void GetSidSubAuthorityTest()
	{
		Assert.That(GetSidSubAuthority(SafePSID.Everyone, 0), ResultIs.Value(0));
	}

	[Test]
	public void GetSidSubAuthorityCountTest()
	{
		Assert.That(GetSidSubAuthorityCount(SafePSID.Everyone), ResultIs.Value(1));
	}

	[Test]
	public void GetWindowsAccountDomainSidTest()
	{
		Assert.That(GetWindowsAccountDomainSid(SafePSID.Current, out var pDomSid), ResultIs.Successful);
		Assert.That(pDomSid.IsValidSid);
	}

	[Test]
	public void InitializeSidTest()
	{
		using var pSid = new SafePSID(32);
		Assert.That(InitializeSid(pSid, KnownSIDAuthority.SECURITY_LOCAL_SID_AUTHORITY, 2), ResultIs.Successful);
	}

	[Test]
	public void IsWellKnownSidTest()
	{
		Assert.That(IsWellKnownSid(SafePSID.Everyone, WELL_KNOWN_SID_TYPE.WinWorldSid), Is.True);
	}

	[Test()]
	public void InitTest()
	{
		using var sid = SafePSID.Current;
		var sidStr = sid.ToString();
		Assert.That(sidStr, Does.StartWith("S-1-5-"));
		var ssid = sid.ToString().Substring(6).Split('-').Select(int.Parse).ToArray();
		var i = ssid[0];
		var dest = new int[ssid.Length - 1];
		Array.Copy(ssid, 1, dest, 0, ssid.Length - 1);
		using var sid2 = SafePSID.Init(KnownSIDAuthority.SECURITY_NT_AUTHORITY, i, dest);
		Assert.That(sid2.IsValidSid);
		Assert.That(sid, Is.EqualTo(sid2));
	}

	[Test()]
	public void PSIDTest()
	{
		using var sid = SafePSID.Current;
		Assert.That(!sid.IsInvalid);
		Assert.That(sid.IsValidSid);
		Assert.That(sid.ToString(), Does.StartWith("S-1-5"));

		using var sid2 = new SafePSID(sid);
		Assert.That(!sid2.IsInvalid);
		Assert.That(sid2.ToString(), Is.EqualTo(sid.ToString()));

		using var sid3 = new SafePSID("S-1-1-0");
		var id2 = new SecurityIdentifier((IntPtr)sid3);
		Assert.That(id2.IsWellKnown(WellKnownSidType.WorldSid));

		using var sid4 = new SafePSID(100);
		Assert.That(!sid4.IsClosed);
		Assert.That(!sid4.IsValidSid);
		Assert.That((int)sid4.Size, Is.EqualTo(100));
		sid4.Dispose();
		Assert.That(sid4.IsClosed);
		Assert.That((int)sid4.Size, Is.EqualTo(0));

		Assert.That(sid.Equals("X"), Is.False);
		Assert.That(sid.Equals(sid3), Is.False);
	}

	[Test()]
	public void ToStringTest()
	{
		using var sid = SafePSID.Everyone;
		const string sddl = "S-1-1-0";
		Assert.That(sid.ToString(), Is.EqualTo(sddl));
		Assert.That(sid.ToString(null), Is.EqualTo(sddl));
		Assert.That(sid.ToString(""), Is.EqualTo(sddl));
		Assert.That(sid.ToString("D"), Is.EqualTo(sddl));
		Assert.That(sid.ToString("B"), Is.EqualTo("01 01 00 00 00 00 00 01 00 00 00 00"));
		Assert.That(sid.ToString("N"), Is.EqualTo("Everyone"));
		Assert.That(sid.ToString("P"), Is.EqualTo("Everyone"));

		Assert.That(SafePSID.Null.ToString(), Is.EqualTo("0"));

		Assert.That(new SafePSID(new byte[] { 12, 255 }).ToString(), Is.EqualTo("Invalid"));
	}

	[Test]
	public void SafePSIDArrayCtorTest()
	{
		var sids = new[] { SafePSID.Current, SafePSID.Everyone };
		SafePSIDArray safeArr = null;
		Assert.That(() => safeArr = new SafePSIDArray((SafePSID[])null), Throws.ArgumentNullException);
		Assert.That(() => safeArr = new SafePSIDArray(new SafePSID[0]), Throws.Nothing);
		Assert.That(safeArr.Count, Is.Zero);
		Assert.That(() => safeArr = new SafePSIDArray(sids), Throws.Nothing);
		Assert.That(safeArr.Count, Is.EqualTo(sids.Length));
		Assert.That(() => safeArr = new SafePSIDArray(Array.ConvertAll(sids, s => (PSID)s)), Throws.Nothing);
		Assert.That(safeArr.Count, Is.EqualTo(sids.Length));
		Assert.That(EqualSid(safeArr[0], SafePSID.Current), Is.True);
		Assert.That(EqualSid(safeArr[1], SafePSID.Everyone), Is.True);
		Assert.That(() => safeArr[2], Throws.Exception);
		Assert.That(safeArr, Is.EquivalentTo(sids));
	}

	[Test]
	public void SafePSIDArrayCtorTest2()
	{
		// Build in-memory SID array
		var sids = new[] { SafePSID.Current, SafePSID.Everyone };

		SafePSIDArray safeArr = null;
		Assert.That(() => safeArr = new SafePSIDArray(IntPtr.Zero, 0), Throws.Nothing);
		Assert.That(safeArr.Count, Is.Zero);

		// Unowned
		var ptr = Build();
		Assert.That(() => safeArr = new SafePSIDArray(ptr, sids.Length, false), Throws.Nothing);
		Assert.That(safeArr.Count, Is.EqualTo(sids.Length));
		foreach (var psid in ptr.ToIEnum<IntPtr>(sids.Length))
			Kernel32.LocalFree(psid);
		Kernel32.LocalFree(ptr);
		safeArr.Dispose();

		// Owned
		ptr = Build();
		Assert.That(() => safeArr = new SafePSIDArray(ptr, sids.Length, true), Throws.Nothing);
		Assert.That(safeArr.Count, Is.EqualTo(sids.Length));
		safeArr.Dispose();

		IntPtr Build()
		{
			var len = sids.Length * IntPtr.Size + sids.Sum(p => p.Length);
			var mem = Kernel32.LocalAlloc(Kernel32.LMEM.LPTR, sids.Length * IntPtr.Size);
			for (var i = 0; i < sids.Length; i++)
			{
				var sid = sids[i];
				var psid = Kernel32.LocalAlloc(Kernel32.LMEM.LPTR, sid.Length);
				Marshal.Copy(sid.GetBinaryForm(), 0, (IntPtr)psid, sid.Length);
				Marshal.WriteIntPtr((IntPtr)mem, i * IntPtr.Size, (IntPtr)psid);
			}
			return (IntPtr)mem;
		}
	}
}