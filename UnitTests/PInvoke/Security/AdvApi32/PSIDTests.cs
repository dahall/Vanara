using NUnit.Framework;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using Vanara.Extensions;
using static Vanara.PInvoke.AdvApi32;

namespace Vanara.PInvoke.Tests
{
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
		public static SafePSID GetCurrentSid() => new SafePSID(WindowsIdentity.GetCurrent().User.GetBytes());

		[Test()]
		public void CloneTest()
		{
			var sid = GetCurrentSid();
			var sid2 = sid.Clone();
			Assert.That(sid2.IsValidSid);
			Assert.That(sid, Is.EqualTo(sid2));
		}

		[Test()]
		public void CopyTest()
		{
			var sid = GetCurrentSid();
			Assert.That(!sid.IsInvalid);
			Assert.That(sid.IsValidSid);
			Assert.That(sid.ToString(), Does.StartWith("S-1-5"));
		}

		[Test]
		public void EqualsTest()
		{
			var ssid = new SafePSID("S-1-1-0");
			var esid = SafePSID.Everyone;
			var mesid = SafePSID.Current;
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
			var sid = new SafePSID("S-1-1-0");
			Assert.That(sid.GetBinaryForm(), Is.EquivalentTo(new SecurityIdentifier(WellKnownSidType.WorldSid, null).GetBytes()));
		}

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
			var sid = SafePSID.Init(KnownSIDAuthority.SECURITY_WORLD_SID_AUTHORITY, KnownSIDRelativeID.SECURITY_WORLD_RID);
			Assert.That(sid.ToString(), Is.EqualTo("S-1-1-0"));
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
}