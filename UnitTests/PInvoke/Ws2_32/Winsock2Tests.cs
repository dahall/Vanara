using NUnit.Framework;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using static Vanara.PInvoke.Ws2_32;

namespace Vanara.PInvoke.Tests;

[TestFixture()]
public class Winsock2Tests
{
	static readonly string saddr4 = TestCaseSources.GetValueOrDefault("IPv4Host", "192.168.0.1")!;
	const string saddr6 = "2001:db8:aaaa:1::100";

	public static readonly IPAddress? localIP4 = Dns.GetHostEntry(Dns.GetHostName()).AddressList.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);

	public static SafeSOCKET GetTcpSocket() => socket(ADDRESS_FAMILY.AF_INET, SOCK.SOCK_STREAM, IPPROTO.IPPROTO_TCP);

	[Test]
	public void gethostnameTest()
	{
		var sb = new StringBuilder(256);
		Assert.That(gethostname(sb, sb.Capacity), ResultIs.Not.Value(-1));
		TestContext.WriteLine(sb);
	}

	[Test]
	public void GetHostNameWTest()
	{
		var sb = new StringBuilder(256);
		Assert.That(GetHostNameW(sb, sb.Capacity), ResultIs.Not.Value(-1));
		TestContext.WriteLine(sb);
	}

	[Test]
	public unsafe void getprotobynameTest()
	{
		var p = getprotobyname_unsafe("TCP");
		Assert.That((IntPtr)p, Is.Not.EqualTo(IntPtr.Zero));
		TestContext.WriteLine($"{p->p_name}: {p->p_proto}, {string.Join(",", p->Aliases)}");

		var p2 = getprotobyname("TCP");
		Assert.That(p2, Is.Not.EqualTo(IntPtr.Zero));
		Assert.That(p2.ToStructure<PROTOENT>().p_proto, Is.EqualTo(p->p_proto));
	}

	[Test]
	public unsafe void getprotobynumberTest()
	{
		var p = getprotobynumber_unsafe(6);
		Assert.That((IntPtr)p, Is.Not.EqualTo(IntPtr.Zero));
		TestContext.WriteLine($"{p->p_name}: {p->p_proto}, {string.Join(",", p->Aliases)}");

		var p2 = getprotobynumber(6);
		Assert.That(p2, Is.Not.EqualTo(IntPtr.Zero));
		Assert.That(p2.ToStructure<PROTOENT>().p_proto, Is.EqualTo(p->p_proto));
	}

	[Test]
	public void getservbynameTest()
	{
		const string svcName = "finger";
		var ps = getservbyname(svcName);
		Assert.That(ps, Is.Not.EqualTo(IntPtr.Zero));
		var s = ps.ToStructure<SERVENT>();
		TestContext.WriteLine($"{s.s_name}: {s.s_port}, {s.s_proto}, {string.Join(",", s.s_aliases)}");
	}

	[Test]
	public void getservbyportTest()
	{
		const short svcPort = 20224; // finger (79 reversed)
		var ps = getservbyport(svcPort, "TCP");
		Assert.That(ps, ResultIs.Not.Value(IntPtr.Zero));
		var s = ps.ToStructure<SERVENT>();
		TestContext.WriteLine($"{s.s_name}: {s.s_port}, {s.s_proto}, {string.Join(",", s.s_aliases)}");
	}

	[Test]
	public void getsocknameTest()
	{
		using var sckt = GetTcpSocket();
		var cname = new SOCKADDR(inet_addr(saddr4), htons(80));
		Assert.That(connect(sckt, cname, cname.Size), ResultIs.Not.Value(-1));
		var addr = SOCKADDR.Empty;
		var sz = (int)addr.Size;
		Assert.That(getsockname(sckt, addr, ref sz), ResultIs.Not.Value(-1));
		Assert.That(sz, Is.LessThanOrEqualTo((int)addr.Size));
	}

	[Test]
	public void getsockoptTest()
	{
		var sz = 256;
		using var sckt = GetTcpSocket();
		using var mem = new SafeHGlobalHandle(sz);
		Assert.That(getsockopt(sckt, SOL_SOCKET, SO_ACCEPTCONN, mem, ref sz), ResultIs.Not.Value(-1));
	}

	[Test]
	public void htonlTest()
	{
		Assert.That(htonl(0x04030201), Is.EqualTo(0x01020304));
	}

	[Test]
	public void htonsTest()
	{
		Assert.That(htons(0x0201), Is.EqualTo(0x0102));
	}

	[Test]
	public void inet_addrTest()
	{
		Assert.That(inet_addr("255.255.255.0"), Is.EqualTo(0x00FFFFFFU));
	}

	[Test]
	public void inet_ntoaTest()
	{
		Assert.That(inet_ntoa(new IN_ADDR(0x00FFFFFFU)).ToString(), Is.EqualTo("255.255.255.0"));
	}

	[Test]
	public void ntohlTest()
	{
		Assert.That(ntohl(0x04030201), Is.EqualTo(0x01020304));
	}

	[Test]
	public void ntohsTest()
	{
		Assert.That(ntohs(0x0201), Is.EqualTo(0x0102));
	}
}