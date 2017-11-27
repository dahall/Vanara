using NUnit.Framework;
using System;
using System.Linq;
using static Vanara.PInvoke.NetApi32;

namespace Vanara.PInvoke.Tests
{
	[TestFixture()]
	public class NetApi32Tests
	{
		[Test()]
		public void DsGetDcNameTest()
		{
			DsGetDcName(null, null, IntPtr.Zero, null, DsGetDcNameFlags.DS_RETURN_DNS_NAME, out SafeNetApiBuffer dcInfo);
			var dci = dcInfo.ToStructure<DOMAIN_CONTROLLER_INFO>();
			Assert.NotNull(dci.DomainControllerName);
		}

		[Test()]
		public void NetApiBufferFreeTest()
		{
			Assert.That(NetServerGetInfo(null, 100, out SafeNetApiBuffer bufptr).Succeeded);
			bufptr.Dispose();
			Assert.True(bufptr.IsClosed);
		}

		[Test()]
		public void NetServerEnumTest()
		{
			var l = NetServerEnum<SERVER_INFO_101>().ToList();
			Assert.NotZero(l.Count);
			Assert.NotNull(l[0].sv101_name);
		}

		[Test()]
		public void NetServerGetInfoTest()
		{
			var i = NetServerGetInfo<SERVER_INFO_100>(null);
			Assert.AreEqual(i.sv100_name, Environment.MachineName);
		}
	}
}