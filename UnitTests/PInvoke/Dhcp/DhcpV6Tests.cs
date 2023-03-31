using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.Dhcp;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class DhcpV6Tests
{
	[OneTimeSetUp]
	public void _Setup() => Dhcpv6CApiInitialize(out _);

	[OneTimeTearDown]
	public void _TearDown() => Dhcpv6CApiCleanup();

	[Test]
	public void Dhcpv6RequestParamsTest()
	{
		using var pparam = new SafeCoTaskMemStruct<DHCPV6CAPI_PARAMS>(new DHCPV6CAPI_PARAMS { OptionId = DHCPV6_OPTION_ID.DHCPV6_OPTION_CLIENTID });
		var recdParams = new DHCPV6CAPI_PARAMS_ARRAY { nParams = 1, Params = pparam };
		uint sz = 1000;
		using var mem = new SafeCoTaskMemHandle(sz);
		Assert.That(Dhcpv6RequestParams(false, default, DhcpTests.adp.Id, IntPtr.Zero, recdParams, mem, ref sz), ResultIs.Successful);
	}

	[Test]
	public void Dhcpv6RequestPrefixTest()
	{
		using var pPrefix = new SafeNativeArray<DHCPV6Prefix>(1);
		using var duid = new SafeCoTaskMemHandle(128);
		var pfxLease = new DHCPV6PrefixLeaseInformation { iaid = 7, nPrefixes = 1, prefixArray = pPrefix, ServerId = duid, ServerIdLen = duid.Size };
		Assert.That(Dhcpv6RequestPrefix(DhcpTests.adp.Id, IntPtr.Zero, ref pfxLease, out var ttw), ResultIs.Successful);
		if (ttw != uint.MaxValue)
		{
			Kernel32.Sleep(ttw * 1000);
			Assert.That(Dhcpv6RenewPrefix(DhcpTests.adp.Id, IntPtr.Zero, ref pfxLease, out ttw, false), ResultIs.Successful);
		}
		if (ttw != uint.MaxValue) Kernel32.Sleep(ttw * 1000);
		Assert.That(Dhcpv6ReleasePrefix(DhcpTests.adp.Id, IntPtr.Zero, pfxLease), ResultIs.Successful);
	}
}