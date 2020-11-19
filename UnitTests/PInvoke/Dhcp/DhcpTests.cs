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

namespace Vanara.PInvoke.Tests
{
	[TestFixture]
	public class DhcpTests
	{
		internal readonly static NetworkInterface adp = NetworkInterface.GetAllNetworkInterfaces().Where(i => i.OperationalStatus == OperationalStatus.Up).FirstOrDefault();
		internal readonly static string dhcpSvr = GetDhcpServers().FirstOrDefault()?.ToString();
		internal const string dhcpSub = "192.168.0.0";

		[OneTimeSetUp]
		public void _Setup() => DhcpCApiInitialize(out _).ThrowIfFailed();

		[OneTimeTearDown]
		public void _TearDown() => DhcpCApiCleanup();

		[Test]
		public void DhcpRequestParamsTest()
		{
			var sendParams = default(DHCPCAPI_PARAMS_ARRAY);
			using var pparam = new SafeCoTaskMemStruct<DHCPAPI_PARAMS>(new DHCPAPI_PARAMS { OptionId = DHCP_OPTION_ID.OPTION_SUBNET_MASK });
			//using var pparam = new SafeCoTaskMemStruct<DHCPAPI_PARAMS>(new DHCPAPI_PARAMS { OptionId = DHCP_OPTION_ID.OPTION_HOST_NAME });
			var reqParams = new DHCPCAPI_PARAMS_ARRAY { nParams = 1, Params = pparam };
			uint sz = 1000;
			using var mem = new SafeCoTaskMemHandle(sz);
			Assert.That(DhcpRequestParams(DHCPCAPI_REQUEST.DHCPCAPI_REQUEST_SYNCHRONOUS, default, adp.Id, IntPtr.Zero, sendParams, reqParams, mem, ref sz, null), ResultIs.Successful);
			var p = pparam.Value;
			Assert.That(p.nBytesData, Is.GreaterThan(0));
			TestContext.Write(new IPAddress(p.Data.ToArray<byte>(4)).ToString());
			//TestContext.Write(StringHelper.GetString(p.Data, CharSet.Ansi, p.nBytesData));
		}

		[Test]
		public void DhcpRegisterParamChangeTest()
		{
			using var pparam = new SafeCoTaskMemStruct<DHCPAPI_PARAMS>(new DHCPAPI_PARAMS { OptionId = DHCP_OPTION_ID.OPTION_ROUTER_ADDRESS });
			//using var pparam = new SafeCoTaskMemStruct<DHCPAPI_PARAMS>(new DHCPAPI_PARAMS { OptionId = DHCP_OPTION_ID.OPTION_HOST_NAME });
			var watchParams = new DHCPCAPI_PARAMS_ARRAY { nParams = 1, Params = pparam };
			Assert.That(DhcpRegisterParamChange(DHCPCAPI_REGISTER_HANDLE_EVENT, default, adp.Id, IntPtr.Zero, watchParams, out var hEvent), ResultIs.Successful);
			Kernel32.WaitForSingleObject(hEvent, 2000);
			Assert.That(DhcpDeRegisterParamChange(Event: hEvent), ResultIs.Successful);
		}

		internal static DHCP_IP_ADDRESS IPAddrFromStr(string addr)
		{
			if (!System.Net.IPAddress.TryParse(addr, out var ip) || ip.AddressFamily != System.Net.Sockets.AddressFamily.InterNetwork)
				return 0;
#pragma warning disable CS0618 // Type or member is obsolete
			return (uint)ip.Address;
#pragma warning restore CS0618 // Type or member is obsolete
		}

		static IEnumerable<IPAddress> GetDhcpServers() => NetworkInterface.GetAllNetworkInterfaces().Where(i => i.OperationalStatus == OperationalStatus.Up).SelectMany(i => i.GetIPProperties().DhcpServerAddresses).Distinct();
	}
}