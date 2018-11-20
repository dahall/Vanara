using NUnit.Framework;
using System;
using System.Linq;
using System.Security.Principal;
using Vanara.InteropServices;
using static Vanara.PInvoke.AdvApi32;

namespace Vanara.PInvoke.Tests
{
	[TestFixture()]
	public class PSIDTests
	{
		[Test()]
		public void PSIDTest()
		{
			var sid = GetCurrentSid();
			Assert.That(!sid.IsInvalid);
			Assert.That(sid.IsValidSid);
			Assert.That(sid.ToString(), Does.StartWith("S-1-5"));

			var sid2 = new SafePSID(sid);
			Assert.That(!sid2.IsInvalid);
			Assert.That(sid2.ToString(), Is.EqualTo(sid.ToString()));

			var sid3 = new SafePSID("S-1-1-0");
			var id2 = new SecurityIdentifier((IntPtr)sid3);
			Assert.That(id2.IsWellKnown(WellKnownSidType.WorldSid));

			var sid4 = new SafePSID(100);
			Assert.That(!sid4.IsClosed);
			Assert.That(!sid4.IsValidSid);
			Assert.That(sid4.Size, Is.EqualTo(100));
			sid4.Dispose();
			Assert.That(sid4.IsClosed);
			Assert.That(sid4.Size, Is.EqualTo(0));

			Assert.That(sid.Equals("X"), Is.False);
			Assert.That(sid.Equals(sid3), Is.False);
		}

		[Test()]
		public void CopyTest()
		{
			var sid = GetCurrentSid();
			Assert.That(!sid.IsInvalid);
			Assert.That(sid.IsValidSid);
			Assert.That(sid.ToString(), Does.StartWith("S-1-5"));
		}

		public static SafePSID GetCurrentSid() => new SafePSID(WindowsIdentity.GetCurrent().User.GetBytes());

		[Test()]
		public void InitTest()
		{
			var sid = GetCurrentSid();
			var sidStr = sid.ToString();
			Assert.That(sidStr, Does.StartWith("S-1-5-"));
			var ssid = sid.ToString().Substring(6).Split('-').Select(int.Parse).ToArray();
			var i = ssid[0];
			var dest = new int[ssid.Length - 1];
			Array.Copy(ssid, 1, dest, 0, ssid.Length - 1);
			var sid2 = SafePSID.Init(KnownSIDAuthority.SECURITY_NT_AUTHORITY, i, dest);
			Assert.That(sid2.IsValidSid);
			Assert.That(sid, Is.EqualTo(sid2));
		}

		[Test()]
		public void CloneTest()
		{
			var sid = GetCurrentSid();
			var sid2 = sid.Clone();
			Assert.That(sid2.IsValidSid);
			Assert.That(sid, Is.EqualTo(sid2));
		}

		[Test()]
		public void GetBinaryForm()
		{
			var sid = new SafePSID("S-1-1-0");
			Assert.That(sid.GetBinaryForm(), Is.EquivalentTo(new SecurityIdentifier(WellKnownSidType.WorldSid, null).GetBytes()));
		}

		[Test()]
		public void ToStringTest()
		{
			var sid = SafePSID.Init(KnownSIDAuthority.SECURITY_WORLD_SID_AUTHORITY, KnownSIDRelativeID.SECURITY_WORLD_RID);
			Assert.That(sid.ToString(), Is.EqualTo("S-1-1-0"));
		}
	}

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
}