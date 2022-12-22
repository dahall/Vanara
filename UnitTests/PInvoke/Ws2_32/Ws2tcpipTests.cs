using NUnit.Framework;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.Ws2_32;

namespace Vanara.PInvoke.Tests
{
	[TestFixture()]
	public class Ws2tcpipTests
	{
		const string saddr4 = "192.168.0.1";
		const string saddr6 = "2001:db8:aaaa:1::100";

		public static IPAddress localIP4 => Dns.GetHostEntry(Dns.GetHostName()).AddressList.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);

		[Test]
		public void _StructSizeTest()
		{
			foreach (var s in typeof(Vanara.PInvoke.Ws2_32).GetNestedStructSizes())
				TestContext.WriteLine(s);
		}

		[Test]
		public void ConstTest()
		{
			Assert.That(new IPAddress(IN6_ADDR.Unspecified).ToString(), Is.EqualTo("::"));
			Assert.That(new IPAddress(IN6_ADDR.Loopback).ToString(), Is.EqualTo("::1"));
		}

		[Test]
		public void gai_strerrorTest()
		{
			Assert.That(gai_strerror(WSRESULT.WSAEINVAL), Is.Not.Null);
		}

		[Test]
		public void GetAddrInfoWTest()
		{
			var hints = new ADDRINFOW { ai_flags = ADDRINFO_FLAGS.AI_CANONNAME, ai_family = ADDRESS_FAMILY.AF_UNSPEC };
			Assert.That(GetAddrInfoW(localIP4.ToString(), null, hints, out var res), ResultIs.Successful);
			TestContext.Write(string.Join(", ", res));
		}

		[Test]
		public unsafe void GetAddrInfoExWTest()
		{
			var hints = new ADDRINFOEXW { ai_flags = ADDRINFO_FLAGS.AI_CANONNAME, ai_family = ADDRESS_FAMILY.AF_INET };
			var ovl = new NativeOverlapped();
			Assert.That(GetAddrInfoExW(localIP4.ToString(), null, NS.NS_ALL, default, &hints, out var res,
				default, &ovl, GAIExCompl, null), ResultIs.Successful);
			TestContext.Write(string.Join(", ", res));
			Assert.That(GetAddrInfoExW(localIP4.ToString(), ppResult: out res), ResultIs.Successful);
			TestContext.Write(string.Join(", ", res));

			static unsafe void GAIExCompl(uint error, uint bytes, NativeOverlapped* overlapped) { }
		}

		[Test]
		public void getipv4sourcefilterTest()
		{
			IN_ADDR addr = default;
			var buf = new IN_ADDR[] { addr, addr, addr };
			var c = buf.Length;
			using var sckt = socket(ADDRESS_FAMILY.AF_INET, SOCK.SOCK_STREAM, IPPROTO.IPPROTO_TCP);
			// TODO: Figure out how to make this function return 0. Parameter problems.
			Assert.That(getipv4sourcefilter(sckt, addr, addr, out var mode, ref c, buf), ResultIs.Value(-1));
		}

		[Test]
		public void inet_ntopTest()
		{
			var chkAddr = IPAddress.Parse(saddr4);
			var addr = new IN_ADDR(chkAddr.GetAddressBytes());
			var sb = new StringBuilder(20);
			Assert.That(inet_ntop(ADDRESS_FAMILY.AF_INET, addr, sb, sb.Capacity), Is.Not.Null);
			Assert.That(sb.ToString(), Is.EqualTo(saddr4));
		}

		[Test]
		public void inet_ntop6Test()
		{
			var chkAddr = IPAddress.Parse(saddr6);
			var addr = new IN6_ADDR(chkAddr.GetAddressBytes());
			var sb = new StringBuilder(128);
			Assert.That(inet_ntop(ADDRESS_FAMILY.AF_INET6, addr, sb, sb.Capacity), Is.Not.Null);
			Assert.That(sb.ToString(), Is.EqualTo(saddr6));
		}

		[Test]
		public void inet_ptonTest()
		{
			var chkAddr = IPAddress.Parse(saddr4);
			var i = inet_pton(ADDRESS_FAMILY.AF_INET, saddr4, out IN_ADDR addr);
			if (i != 1)
				Assert.Fail($"Result is {i}: Error={WSAGetLastError()}");
			Assert.That(addr.S_un_b, Is.EquivalentTo(chkAddr.GetAddressBytes()));
		}

		[Test]
		public void inet_pton6Test()
		{
			var chkAddr = IPAddress.Parse(saddr6);
			var i = inet_pton(ADDRESS_FAMILY.AF_INET6, saddr6, out IN6_ADDR addr);
			if (i != 1)
				Assert.Fail($"Result is {i}: Error={WSAGetLastError()}");
			Assert.That(addr.bytes, Is.EquivalentTo(chkAddr.GetAddressBytes()));
		}

		[Test]
		public void InetNtopWTest()
		{
			var chkAddr = IPAddress.Parse(saddr4);
			var addr = new IN_ADDR(chkAddr.GetAddressBytes());
			var sb = new StringBuilder(20);
			Assert.That(InetNtopW(ADDRESS_FAMILY.AF_INET, addr, sb, sb.Capacity), Is.Not.Null);
			Assert.That(sb.ToString(), Is.EqualTo(saddr4));
		}

		[Test]
		public void InetNtopW6Test()
		{
			var chkAddr = IPAddress.Parse(saddr6);
			var addr = new IN6_ADDR(chkAddr.GetAddressBytes());
			var sb = new StringBuilder(128);
			Assert.That(InetNtopW(ADDRESS_FAMILY.AF_INET6, addr, sb, sb.Capacity), Is.Not.Null);
			Assert.That(sb.ToString(), Is.EqualTo(saddr6));
		}

		[Test]
		public void InetPtonWTest()
		{
			var chkAddr = IPAddress.Parse(saddr4);
			var i = InetPtonW(ADDRESS_FAMILY.AF_INET, saddr4, out IN_ADDR addr);
			if (i != 1)
				Assert.Fail($"Result is {i}: Error={WSAGetLastError()}");
			Assert.That(addr.S_un_b, Is.EquivalentTo(chkAddr.GetAddressBytes()));
		}

		[Test]
		public void InetPtonW6Test()
		{
			var chkAddr = IPAddress.Parse(saddr6);
			var i = InetPtonW(ADDRESS_FAMILY.AF_INET6, saddr6, out IN6_ADDR addr);
			if (i != 1)
				Assert.Fail($"Result is {i}: Error={WSAGetLastError()}");
			Assert.That(addr.bytes, Is.EquivalentTo(chkAddr.GetAddressBytes()));
		}

		[Test]
		public unsafe void SetAddrInfoExTest()
		{
			var chkAddr = IPAddress.Parse(saddr4);
			var addr = new SOCKADDR(new SOCKADDR_IN(new IN_ADDR(chkAddr.GetAddressBytes())));
			var saddr = new SOCKET_ADDRESS { lpSockaddr = addr, iSockaddrLength = addr.Size };
			Assert.That(SetAddrInfoEx("Temp", null, new[] { saddr }, 1), ResultIs.Value(0));
			Assert.That(SetAddrInfoEx("Temp"), ResultIs.Value(0));
		}
	}
}