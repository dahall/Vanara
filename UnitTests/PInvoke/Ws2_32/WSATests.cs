using NUnit.Framework;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using static Vanara.PInvoke.Ws2_32;

namespace Vanara.PInvoke.Tests;

[TestFixture()]
public class WSATests
{
	static readonly string saddr4 = TestCaseSources.GetValueOrDefault("IPv4Host", "192.168.0.1")!;
	const string saddr6 = "2001:db8:aaaa:1::100";

	public static readonly IPAddress? localIP4 = Dns.GetHostEntry(Dns.GetHostName()).AddressList.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);
	public static readonly SOCKET tcpSocket = socket(ADDRESS_FAMILY.AF_INET, SOCK.SOCK_STREAM, IPPROTO.IPPROTO_TCP);

	//[OneTimeTearDown]
	//public void _OneTimeTearDown()
	//{
	//	WSACleanup();
	//}

	[Test]
	public void WSAAddressToStringTest()
	{
		var addr = new SOCKADDR(localIP4!);
		var len = 256U;
		var sb = new StringBuilder((int)len);
		Assert.That(WSAAddressToString(addr, addr.Size, default, sb, ref len), ResultIs.Successful);
		TestContext.Write(sb);
		Assert.That(sb.ToString(), Is.EqualTo(localIP4?.ToString()));
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
		Assert.That(WSAEnumNameSpaceProviders(ref len, default), ResultIs.Failure);
		//Assert.That(WSAGetLastError(), Is.EqualTo((Win32Error)Win32Error.WSAEFAULT));
		Assert.That(len, Is.GreaterThan(0));
		using var mem = new SafeHGlobalHandle(len);
		var cnt = WSAEnumNameSpaceProviders(ref len, mem);
		Assert.That(cnt, ResultIs.Successful);
		TestContext.Write(string.Join("\n", mem.ToEnumerable<WSANAMESPACE_INFOW>(cnt).Select(n => $"{n.lpszIdentifier.ToString()}: {n.NSProviderId}, {n.dwNameSpace}, {n.fActive}")));
	}

	[Test]
	public void WSAEnumNameSpaceProvidersExTest()
	{
		var len = 0U;
		Assert.That(WSAEnumNameSpaceProvidersEx(ref len, default), ResultIs.Failure);
		//Assert.That(WSAGetLastError(), Is.EqualTo((Win32Error)Win32Error.WSAEFAULT));
		Assert.That(len, Is.GreaterThan(0));
		using var mem = new SafeHGlobalHandle(len);
		var cnt = WSAEnumNameSpaceProvidersEx(ref len, mem);
		Assert.That(cnt, ResultIs.Successful);
		TestContext.Write(string.Join("\n", mem.ToEnumerable<WSANAMESPACE_INFOEXW>(cnt).Select(n => $"{n.lpszIdentifier.ToString()}: {n.NSProviderId}, {n.dwNameSpace}, {n.fActive}")));
	}

	[Test]
	public void WSAEnumNetworkEventsTest()
	{
		var ListenSocket = tcpSocket;
		var InetAddr = new SOCKADDR(IN_ADDR.INADDR_ANY, htons(27015));
		Assert.That(bind(ListenSocket, InetAddr, InetAddr.Size), ResultIs.Successful);
		using var evt = WSACreateEvent();
		Assert.That(evt, ResultIs.ValidHandle);
		Assert.That(WSAEventSelect(ListenSocket, evt, FD.FD_ACCEPT | FD.FD_CLOSE), ResultIs.Successful);
		Assert.That(listen(ListenSocket, 10), ResultIs.Successful);
		var EventArray = new WSAEVENT[] { evt };
		WSAWaitForMultipleEvents((uint)EventArray.Length, EventArray, true, 500, false);
		Assert.That(WSAEnumNetworkEvents(ListenSocket, evt, out var nets), ResultIs.Successful);
	}

	[Test]
	public void WSAEnumProtocolsTest()
	{
		var len = 0U;
		Assert.That(WSAEnumProtocols(null, default, ref len), ResultIs.Failure);
		Assert.That(len, Is.GreaterThan(0));
		using var mem = new SafeHGlobalHandle(len);
		var cnt = WSAEnumProtocols(null, mem, ref len);
		Assert.That(cnt, ResultIs.Successful);
		TestContext.Write(string.Join("\n", mem.ToEnumerable<WSAPROTOCOL_INFO>(cnt).Select(p => $"{p.szProtocol}: {(ADDRESS_FAMILY)p.iAddressFamily}, {p.iSocketType}, {p.iProtocol}")));
	}

	[Test]
	public void WSAHtonlTest()
	{
		Assert.That(WSAHtonl(tcpSocket, 0x01020304, out var ret), ResultIs.Successful);
		Assert.That(ret, Is.EqualTo(0x04030201));
	}

	[Test]
	public void WSALookupServiceTest()
	{
		WSAQUERYSET qsr = new(NS.NS_BTH);
		foreach (var qs in WSALookupService(qsr, LUP.LUP_CONTAINERS, LUP.LUP_RETURN_ALL))
			TestContext.WriteLine($"Name: {qs.lpszServiceInstanceName}; Guid: {qs.lpServiceClassId}; NS: {qs.dwNameSpace}; PrNum: {qs.lpafpProtocols?.Length ?? 0}; Ver: {qs.lpVersion}");
	}

	[Test]
	public void WSCEnumProtocolsTest()
	{
		foreach (var p in WSCEnumProtocols())
			TestContext.WriteLine($"{p.szProtocol}: {(ADDRESS_FAMILY)p.iAddressFamily}, {p.iSocketType}, {p.iProtocol}");
	}
}