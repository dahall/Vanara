using NUnit.Framework;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Vanara.InteropServices;
using static Vanara.PInvoke.Ws2_32;

namespace Vanara.PInvoke.Tests
{
	[TestFixture()]
	public class WSATests
	{
		const string saddr4 = "192.168.0.1";
		const string saddr6 = "2001:db8:aaaa:1::100";

		public static readonly IPAddress localIP4 = Dns.GetHostEntry(Dns.GetHostName()).AddressList.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);
		public static readonly SOCKET tcpSocket = socket(ADDRESS_FAMILY.AF_INET, SOCK.SOCK_STREAM, IPPROTO.IPPROTO_TCP);

		//[OneTimeTearDown]
		//public void _OneTimeTearDown()
		//{
		//	WSACleanup();
		//}

		[Test]
		public void WSAAddressToStringTest()
		{
			var addr = new SOCKADDR(localIP4);
			var len = 256U;
			var sb = new StringBuilder((int)len);
			Assert.That(WSAAddressToString(addr, addr.Size, default, sb, ref len), ResultIs.Not.Value(-1));
			TestContext.Write(sb);
			Assert.That(sb.ToString(), Is.EqualTo(localIP4.ToString()));
		}

		[Test]
		public void WSACreateEventTest()
		{
			var evt = WSACreateEvent();
			Assert.That(evt, ResultIs.ValidHandle);
			Assert.That(WSAResetEvent(evt), ResultIs.Successful);
			Assert.That(WSASetEvent(evt), ResultIs.Successful);
			Assert.That(() => evt.Dispose(), Throws.Nothing);
		}

		[Test]
		public void WSAEnumNameSpaceProvidersTest()
		{
			var len = 0U;
			Assert.That(WSAEnumNameSpaceProviders(ref len, default), ResultIs.Value(-1));
			//Assert.That(WSAGetLastError(), Is.EqualTo((Win32Error)Win32Error.WSAEFAULT));
			Assert.That(len, Is.GreaterThan(0));
			using var mem = new SafeHGlobalHandle(len);
			var cnt = WSAEnumNameSpaceProviders(ref len, mem);
			Assert.That(cnt, ResultIs.Not.Value(-1));
			TestContext.Write(string.Join("\n", mem.ToEnumerable<WSANAMESPACE_INFOW>(cnt).Select(n => $"{n.lpszIdentifier.ToString()}: {n.NSProviderId}, {n.dwNameSpace}, {n.fActive}")));
		}

		[Test]
		public void WSAEnumNameSpaceProvidersExTest()
		{
			var len = 0U;
			Assert.That(WSAEnumNameSpaceProvidersEx(ref len, default), ResultIs.Value(-1));
			//Assert.That(WSAGetLastError(), Is.EqualTo((Win32Error)Win32Error.WSAEFAULT));
			Assert.That(len, Is.GreaterThan(0));
			using var mem = new SafeHGlobalHandle(len);
			var cnt = WSAEnumNameSpaceProvidersEx(ref len, mem);
			Assert.That(cnt, ResultIs.Not.Value(-1));
			TestContext.Write(string.Join("\n", mem.ToEnumerable<WSANAMESPACE_INFOEXW>(cnt).Select(n => $"{n.lpszIdentifier.ToString()}: {n.NSProviderId}, {n.dwNameSpace}, {n.fActive}")));
		}

		[Test]
		public void WSAEnumNetworkEventsTest()
		{
			var ListenSocket = tcpSocket;
			var InetAddr = new SOCKADDR(IN_ADDR.INADDR_ANY, htons(27015));
			Assert.That(bind(ListenSocket, InetAddr, InetAddr.Size), ResultIs.Not.Value(-1));
			using var evt = WSACreateEvent();
			Assert.That(evt, ResultIs.ValidHandle);
			Assert.That(WSAEventSelect(ListenSocket, evt, FD.FD_ACCEPT | FD.FD_CLOSE), ResultIs.Not.Value(-1));
			Assert.That(listen(ListenSocket, 10), ResultIs.Not.Value(-1));
			var EventArray = new WSAEVENT[] { evt };
			WSAWaitForMultipleEvents((uint)EventArray.Length, EventArray, true, 500, false);
			Assert.That(WSAEnumNetworkEvents(ListenSocket, evt, out var nets), ResultIs.Not.Value(-1));
		}

		[Test]
		public void WSAEnumProtocolsTest()
		{
			var len = 0U;
			Assert.That(WSAEnumProtocols(null, default, ref len), ResultIs.Value(-1));
			Assert.That(len, Is.GreaterThan(0));
			using var mem = new SafeHGlobalHandle(len);
			var cnt = WSAEnumProtocols(null, mem, ref len);
			Assert.That(cnt, ResultIs.Not.Value(-1));
			TestContext.Write(string.Join("\n", mem.ToEnumerable<WSAPROTOCOL_INFO>(cnt).Select(p => $"{p.szProtocol}: {(ADDRESS_FAMILY)p.iAddressFamily}, {p.iSocketType}, {p.iProtocol}")));
		}

		[Test]
		public void WSAHtonlTest()
		{
			Assert.That(WSAHtonl(tcpSocket, 0x01020304, out var ret), ResultIs.Not.Value(-1));
			Assert.That(ret, Is.EqualTo(0x04030201));
		}
	}
}