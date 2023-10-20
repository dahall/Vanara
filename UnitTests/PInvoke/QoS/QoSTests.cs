using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Linq;
using System.Net.Sockets;
using Vanara.InteropServices;
using static Vanara.PInvoke.Qwave;
using static Vanara.PInvoke.Traffic;
using static Vanara.PInvoke.Ws2_32;

namespace Vanara.PInvoke.Tests;
[TestFixture]
public class QoSTests
{
	[OneTimeSetUp]
	public void _Setup()
	{
	}

	[OneTimeTearDown]
	public void _TearDown()
	{
	}

	[Test]
	public void StructTest() => TestContext.Write(string.Join("\n", TestHelper.GetNestedStructSizes(typeof(Traffic))));

	[Test]
	public void TcEnumerateFlowsTest()
	{
		TCI_CLIENT_FUNC_LIST list = new() { ClNotifyHandler = NotifyHandler };
		Assert.That(TcRegisterClient(CURRENT_TCI_VERSION, default, list, out var hCli), ResultIs.Successful);
		try
		{
			string ifcName = TcEnumerateInterfaces(hCli).First(i => i.AddressListDesc.AddressList.AddressCount > 0).pInterfaceName;
			TestContext.WriteLine($"Interface: {ifcName}");
			Assert.That(TcOpenInterface(ifcName, hCli, default, out var hIfc), ResultIs.Successful);
			try
			{
				var res = TcEnumerateFlows(hIfc);
				res?.WriteValues();
			}
			finally
			{
				hIfc.Dispose();
			}
		}
		finally
		{
			hCli.Dispose();
		}

		void NotifyHandler(IntPtr ClRegCtx, IntPtr ClIfcCtx, TC_NOTIFY Event, IntPtr SubCode, uint BufSize, IntPtr Buffer)
		{
		}
	}

	[Test]
	public void TcAddFilterTest()
	{
		TCI_CLIENT_FUNC_LIST list = new() { ClNotifyHandler = NotifyHandler };
		Assert.That(TcRegisterClient(CURRENT_TCI_VERSION, default, list, out var hCli), ResultIs.Successful);
		try
		{
			string ifcName = TcEnumerateInterfaces(hCli).First(i => i.AddressListDesc.AddressList.AddressCount > 0).pInterfaceName;
			TestContext.WriteLine($"Interface: {ifcName}");
			Assert.That(TcOpenInterface(ifcName, hCli, default, out var hIfc), ResultIs.Successful);
			try
			{
				TC_GEN_FLOW flow = new()
				{
					SendingFlowspec = new FLOWSPEC(SERVICETYPE.SERVICETYPE_GUARANTEED, 10000, maxSduSize: 344, minimumPolicedSize: 12, peakBandwidth: 32000, tokenBucketSize: 680),
					ReceivingFlowspec = new(SERVICETYPE.SERVICETYPE_GUARANTEED, 10000),
					TcObjects = new IQoSObjectHdr[] { new QOS_DS_CLASS { ObjectHdr = QOS_OBJECT_HDR.Init<QOS_DS_CLASS>(), DSField = 0x2E }, QOS_OBJECT_HDR.EndOfList }
				};
				Assert.That(TcAddFlow(hIfc, default, default, flow, out var hFlow), ResultIs.Successful);
				try
				{
					IP_PATTERN pattern = new() { ProtocolId = (byte)IPPROTO.IPPROTO_UDP, tcDstPort = 5000 };
					IP_PATTERN mask = new() { ProtocolId = 0xFF, tcDstPort = 0xFFFF };
					TC_GEN_FILTER filter = TC_GEN_FILTER.Create(NDIS_PROTOCOL_ID.NDIS_PROTOCOL_ID_TCP_IP, pattern, mask, out var mem);
					Assert.That(TcAddFilter(hFlow, filter, out SafeHFILTER hFilt), ResultIs.Successful);
					hFilt.Dispose();
				}
				finally
				{
					Assert.That(TcDeleteFlow(hFlow), ResultIs.Successful);
					hFlow.Dispose();
				}
				var res = TcEnumerateFlows(hIfc);
				res?.WriteValues();
			}
			finally
			{
				hIfc.Dispose();
			}
		}
		finally
		{
			hCli.Dispose();
		}

		void NotifyHandler(IntPtr ClRegCtx, IntPtr ClIfcCtx, TC_NOTIFY Event, IntPtr SubCode, uint BufSize, IntPtr Buffer)
		{
		}
	}

	[Test]
	public void QOS2Test()
	{
		using var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

		Assert.That(QOSCreateHandle(out var hQos), ResultIs.Successful);
		using (hQos)
		{
			using var skadd = new SOCKADDR(new SOCKADDR_IN(new IN_ADDR(192,168,0,149), 80));
			//Assert.That(QOSStartTrackingClient(hQos, skadd), ResultIs.Successful);

			uint flowId = 0;
			Assert.That(QOSAddSocketToFlow(hQos, socket.Handle, skadd, QOS_TRAFFIC_TYPE.QOSTrafficTypeBestEffort, QOS_FLOW_TYPE.QOS_NON_ADAPTIVE_FLOW, ref flowId), ResultIs.Successful);

			uint dscp = 40;
			using var pin = new PinnedObject(dscp);
			Assert.That(QOSSetFlow(hQos, flowId, QOS_SET_FLOW.QOSSetOutgoingDSCPValue, 4, pin), ResultIs.Successful);

			uint[] flowIds = null;
			Assert.That(() => flowIds = QOSEnumerateFlows(hQos), Throws.Nothing);
			Assert.That(flowIds, Is.Not.Empty);
			flowIds.WriteValues();

			Assert.That(() => QOSQueryFlow<ulong>(hQos, flowIds[0], QOS_QUERY_FLOW.QOSQueryOutgoingRate, false).WriteValues(), Throws.Nothing);

			Assert.That(QOSRemoveSocketFromFlow(hQos, socket.Handle, flowId), ResultIs.Successful);

			//Assert.That(QOSStopTrackingClient(hQos, skadd), ResultIs.Successful);
		}
	}
}