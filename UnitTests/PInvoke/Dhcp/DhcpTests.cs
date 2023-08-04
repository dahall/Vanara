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
		Assert.That(() =>
		{
			TestContext.WriteLine(new IPAddress(RequestParam<uint>(adp.Id, DHCP_OPTION_ID.OPTION_SUBNET_MASK)));
			TestContext.WriteLine(new IPAddress(RequestParam<uint>(adp.Id, DHCP_OPTION_ID.OPTION_ROUTER_ADDRESS)));
			TestContext.WriteLine(new IPAddress(RequestParam<uint>(adp.Id, DHCP_OPTION_ID.OPTION_BROADCAST_ADDRESS)));
			Array.ConvertAll(RequestParam<uint[]>(adp.Id, DHCP_OPTION_ID.OPTION_TIME_SERVERS) ?? new uint[0], a => new IPAddress(a)).WriteValues();
			TestContext.WriteLine(RequestParam<string>(adp.Id, DHCP_OPTION_ID.OPTION_HOST_NAME));
			TestContext.WriteLine(RequestParam<string>(adp.Id, DHCP_OPTION_ID.OPTION_DOMAIN_NAME));
			TestContext.WriteLine(RequestParam<string>(adp.Id, DHCP_OPTION_ID.OPTION_MSFT_IE_PROXY));
		}, Throws.Nothing);
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

	private static T RequestParam<T>(string adapterName, DHCP_OPTION_ID optionId, byte[] classId = null)
	{
		using SafeCoTaskMemHandle pClassIdData = new(classId);
		using SafeCoTaskMemStruct<DHCPCAPI_CLASSID> pClass = (DHCPCAPI_CLASSID?)(classId is null ? null : new DHCPCAPI_CLASSID() { nBytesData = (uint)classId.Length, Data = pClassIdData });
		DHCPCAPI_PARAMS_ARRAY sendParams = new();
		using var pparam = new SafeCoTaskMemStruct<DHCPAPI_PARAMS>(new DHCPAPI_PARAMS { OptionId = optionId });
		DHCPCAPI_PARAMS_ARRAY reqParams = new() { nParams = 1, Params = pparam };
		uint sz = 0;
		DhcpRequestParams(DHCPCAPI_REQUEST.DHCPCAPI_REQUEST_SYNCHRONOUS, default, adapterName, pClass, sendParams, reqParams, IntPtr.Zero, ref sz, null).ThrowUnless(Win32Error.ERROR_MORE_DATA);
		if (sz == 0) return default;
		using var buffer = new SafeCoTaskMemHandle(sz);
		Guid appId = Guid.NewGuid();
		DhcpRequestParams(DHCPCAPI_REQUEST.DHCPCAPI_REQUEST_SYNCHRONOUS, default, adapterName, pClass, sendParams, reqParams, buffer, ref sz, appId.ToString("N")).ThrowIfFailed();
		try
		{
			//if (!typeof(T).IsPrimitive && typeof(T) != typeof(string))
			//	reqParamCache.Add(appId, buffer);
			var p = pparam.Value;
			if (typeof(T).IsArray)
			{
				var elemType = typeof(T).GetElementType();
				try
				{
					var elemSz = InteropExtensions.SizeOf(elemType);
					return (T)(object)p.Data.ToArray(elemType, p.nBytesData / elemSz, 0, p.nBytesData);
				}
				catch
				{
					throw new ArgumentException("Unable to process array of specfied type.");
				}
			}
			return p.Data.Convert<T>(p.nBytesData, CharSet.Ansi);
		}
		finally
		{
			DhcpUndoRequestParams(0, default, adapterName, appId.ToString("N"));
		}
	}

	internal static DHCP_IP_ADDRESS IPAddrFromStr(string addr)
	{
		if (!IPAddress.TryParse(addr, out var ip) || ip.AddressFamily != System.Net.Sockets.AddressFamily.InterNetwork)
			return 0;
#pragma warning disable CS0618 // Type or member is obsolete
		return (uint)ip.Address;
#pragma warning restore CS0618 // Type or member is obsolete
	}

	static IEnumerable<IPAddress> GetDhcpServers() => NetworkInterface.GetAllNetworkInterfaces().Where(i => i.OperationalStatus == OperationalStatus.Up).SelectMany(i => i.GetIPProperties().DhcpServerAddresses).Distinct();
}