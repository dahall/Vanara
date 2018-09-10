using System;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using Vanara.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class IpHlpApi
	{
		[PInvokeData("winsock2.h")]
		public enum ADDRESS_FAMILY : ushort
		{
			/// <summary>Unspecified address family.</summary>
			AF_UNSPEC = 0,
			/// <summary>Unix local to host address.</summary>
			AF_UNIX = 1,
			/// <summary>Address for IP version 4.</summary>
			AF_INET = 2,
			/// <summary>ARPANET IMP address.</summary>
			AF_IMPLINK = 3,
			/// <summary>Address for PUP protocols.</summary>
			AF_PUP = 4,
			/// <summary>Address for MIT CHAOS protocols.</summary>
			AF_CHAOS = 5,
			/// <summary>Address for Xerox NS protocols.</summary>
			AF_NS = 6,
			/// <summary>IPX or SPX address.</summary>
			AF_IPX = AF_NS,
			/// <summary>Address for ISO protocols.</summary>
			AF_ISO = 7,
			/// <summary>Address for OSI protocols.</summary>
			AF_OSI = AF_ISO,
			/// <summary>European Computer Manufacturers Association (ECMA) address.</summary>
			AF_ECMA = 8,
			/// <summary>Address for Datakit protocols.</summary>
			AF_DATAKIT = 9,
			/// <summary>Addresses for CCITT protocols, such as X.25.</summary>
			AF_CCITT = 10,
			/// <summary>IBM SNA address.</summary>
			AF_SNA = 11,
			/// <summary>DECnet address.</summary>
			AF_DECnet = 12,
			/// <summary>Direct data-link interface address.</summary>
			AF_DLI = 13,
			/// <summary>LAT address.</summary>
			AF_LAT = 14,
			/// <summary>NSC Hyperchannel address.</summary>
			AF_HYLINK = 15,
			/// <summary>AppleTalk address.</summary>
			AF_APPLETALK = 16,
			/// <summary>NetBios address.</summary>
			AF_NETBIOS = 17,
			/// <summary>VoiceView address.</summary>
			AF_VOICEVIEW = 18,
			/// <summary>FireFox address.</summary>
			AF_FIREFOX = 19,
			/// <summary>Undocumented.</summary>
			AF_UNKNOWN1 = 20,
			/// <summary>Banyan address.</summary>
			AF_BAN = 21,
			/// <summary>Native ATM services address.</summary>
			AF_ATM = 22,
			/// <summary>Address for IP version 6.</summary>
			AF_INET6 = 23,
			/// <summary>Address for Microsoft cluster products.</summary>
			AF_CLUSTER = 24,
			/// <summary>IEEE 1284.4 workgroup address.</summary>
			AF_12844 = 25,
			/// <summary>IrDA address.</summary>
			AF_IRDA = 26,
			/// <summary>Address for Network Designers OSI gateway-enabled protocols.</summary>
			AF_NETDES = 28,
			/// <summary>Undocumented.</summary>
			AF_TCNPROCESS = 29,
			/// <summary>Undocumented.</summary>
			AF_TCNMESSAGE = 30,
			/// <summary>Undocumented.</summary>
			AF_ICLFXBM = 31,
			/// <summary>Bluetooth RFCOMM/L2CAP protocols.</summary>
			AF_BTH = 32,
			/// <summary>Link layer interface.</summary>
			AF_LINK = 33,
			/// <summary>Windows Hyper-V.</summary>
			AF_HYPERV = 34,
		}

		/// <summary>The IN_ADDR structure represents an IPv4 address.</summary>
		[PInvokeData("winsock2.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct IN_ADDR
		{
			/// <summary>An IPv4 address formatted as a u_long.</summary>
			public uint S_addr;

			/// <summary>Initializes a new instance of the <see cref="IN_ADDR"/> struct.</summary>
			/// <param name="v4addr">An IPv4 address.</param>
			public IN_ADDR(uint v4addr) { S_addr = v4addr; }

			/// <summary>Initializes a new instance of the <see cref="IN_ADDR"/> struct.</summary>
			/// <param name="v4addr">An IPv4 address</param>
			/// <exception cref="ArgumentException">Byte array must have 4 items. - v4addr</exception>
			public IN_ADDR(byte[] v4addr)
			{
				if (v4addr == null && v4addr.Length != 4)
					throw new ArgumentException("Byte array must have 4 items.", nameof(v4addr));
				S_addr = BitConverter.ToUInt32(v4addr, 0);
			}

			/// <summary>Initializes a new instance of the <see cref="IN_ADDR"/> struct.</summary>
			/// <param name="b1">The first byte.</param>
			/// <param name="b2">The second byte.</param>
			/// <param name="b3">The third byte.</param>
			/// <param name="b4">The fourth byte.</param>
			public IN_ADDR(byte b1, byte b2, byte b3, byte b4)
			{
				S_addr = b1 | (uint)b2 << 8 | (uint)b3 << 16 | (uint)b4 << 24;
			}

			/// <summary>Gets the address represented as four bytes.</summary>
			/// <value>An IPv4 address formatted as four u_chars.</value>
			public byte[] S_un_b => BitConverter.GetBytes(S_addr);

			/// <summary>Performs an implicit conversion from <see cref="IN_ADDR"/> to <see cref="System.UInt32"/>.</summary>
			/// <param name="a">An IN_ADDR value.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator uint(IN_ADDR a) => a.S_addr;

			/// <summary>Performs an implicit conversion from <see cref="IN_ADDR"/> to <see cref="System.Int64"/>.</summary>
			/// <param name="a">An IN_ADDR value.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator long(IN_ADDR a) => (long)a.S_addr;

			/// <summary>Performs an implicit conversion from <see cref="IN_ADDR"/> to <see cref="T:byte[]"/>.</summary>
			/// <param name="a">An IN_ADDR value.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator byte[](IN_ADDR a) => BitConverter.GetBytes(a.S_addr);

			/// <summary>Performs an implicit conversion from <see cref="System.UInt32"/> to <see cref="IN_ADDR"/>.</summary>
			/// <param name="a">A UInt32 value.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator IN_ADDR(uint a) => new IN_ADDR(a);

			/// <summary>Performs an implicit conversion from <see cref="System.Int64"/> to <see cref="IN_ADDR"/>.</summary>
			/// <param name="a">An Int64 value.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator IN_ADDR(long a) => new IN_ADDR((uint)a);

			/// <summary>Returns a <see cref="System.String" /> that represents this instance.</summary>
			/// <returns>A <see cref="System.String" /> that represents this instance.</returns>
			public override string ToString()
			{
				var b = S_un_b;
				return $"{b[0]}.{b[1]}.{b[2]}.{b[3]}";
			}
		}

		[PInvokeData("winsock2.h")]
		[StructLayout(LayoutKind.Sequential, Size = IN6_ADDR_SIZE)]
		public struct IN6_ADDR : IEquatable<IN6_ADDR>
		{
			private const int IN6_ADDR_SIZE = 16;

			private ulong lower;
			private ulong upper;

			public static readonly IN6_ADDR Loopback = new IN6_ADDR { lower = 0xff_01_00_00_00_00_00_00, upper = 0x00_00_00_00_00_00_00_01 };
			public static readonly IN6_ADDR Unspecified = new IN6_ADDR { lower = 0, upper = 0 };

			public IN6_ADDR(byte[] v6addr)
			{
				lower = upper = 0;
				bytes = v6addr;
			}

			public unsafe byte[] bytes
			{
				get
				{
					var v6addr = new byte[IN6_ADDR_SIZE];
					fixed (byte* usp = &v6addr[0])
					{
						var ulp2 = (ulong*)usp;
						ulp2[0] = lower;
						ulp2[1] = upper;
					}
					return v6addr;
				}
				set
				{
					if (value == null) value = new byte[IN6_ADDR_SIZE];
					if (value.Length != IN6_ADDR_SIZE)
						throw new ArgumentException("Byte array must have 16 items.", nameof(value));
					fixed (byte* bp = &value[0])
					{
						var ulp = (ulong*)bp;
						lower = ulp[0];
						upper = ulp[1];
					}
				}
			}

			public unsafe ushort[] words
			{
				get
				{
					var v6addr = new ushort[IN6_ADDR_SIZE / 2];
					fixed (ushort* usp = &v6addr[0])
					{
						var ulp2 = (ulong*)usp;
						ulp2[0] = lower;
						ulp2[1] = upper;
					}
					return v6addr;
				}
				set
				{
					if (value == null) value = new ushort[IN6_ADDR_SIZE / 2];
					if (value.Length != IN6_ADDR_SIZE / 2)
						throw new ArgumentException("UInt16 array must have 8 items.", nameof(value));
					fixed (ushort* bp = &value[0])
					{
						var ulp = (ulong*)bp;
						lower = ulp[0];
						upper = ulp[1];
					}
				}
			}

			public static implicit operator IN6_ADDR(byte[] a) => new IN6_ADDR(a);

			public static implicit operator byte[] (IN6_ADDR a) => a.bytes;

			public override string ToString()
			{
				const string numberFormat = "{0:x4}:{1:x4}:{2:x4}:{3:x4}:{4:x4}:{5:x4}:{6}.{7}.{8}.{9}";
				var m_Numbers = words;
				return string.Format(System.Globalization.CultureInfo.InvariantCulture, numberFormat,
					m_Numbers[0], m_Numbers[1], m_Numbers[2], m_Numbers[3], m_Numbers[4], m_Numbers[5],
					((m_Numbers[6] >> 8) & 0xFF), (m_Numbers[6] & 0xFF), ((m_Numbers[7] >> 8) & 0xFF), (m_Numbers[7] & 0xFF));
			}

			public bool Equals(IN6_ADDR other) => lower == other.lower && upper == other.upper;
		}

		[PInvokeData("winsock2.h")]
		[StructLayout(LayoutKind.Sequential, Pack = 2)]
		public struct SOCKADDR_IN
		{
			public ADDRESS_FAMILY sin_family;
			public ushort sin_port;
			public IN_ADDR sin_addr;
			public ulong sin_zero;

			public SOCKADDR_IN(IN_ADDR addr, ushort port = 0)
			{
				sin_family = ADDRESS_FAMILY.AF_INET;
				sin_port = port;
				sin_addr = addr;
				sin_zero = 0;
			}

			public static implicit operator SOCKADDR_IN(IN_ADDR addr) => new SOCKADDR_IN(addr);

			public override string ToString() => $"{sin_addr}:{sin_port}";
		}

		[PInvokeData("winsock2.h")]
		[StructLayout(LayoutKind.Sequential, Pack = 2)]
		public struct SOCKADDR_IN6
		{
			public ADDRESS_FAMILY sin6_family;
			public ushort sin6_port;
			public uint sin6_flowinfo;
			public IN6_ADDR sin6_addr;
			public uint sin6_scope_id;

			public SOCKADDR_IN6(byte[] addr, uint scope_id, ushort port = 0) : this(new IN6_ADDR(addr), scope_id, port) { }

			public SOCKADDR_IN6(IN6_ADDR addr, uint scope_id, ushort port = 0)
			{
				sin6_family = ADDRESS_FAMILY.AF_INET6;
				sin6_port = port;
				sin6_flowinfo = 0;
				sin6_addr = addr;
				sin6_scope_id = scope_id;
			}

			public static implicit operator SOCKADDR_IN6(IN6_ADDR addr) => new SOCKADDR_IN6(addr, 0);

			public override string ToString() => $"{sin6_addr}" + (sin6_scope_id == 0 ? "" : "%" + sin6_scope_id.ToString()) + $":{sin6_port}";
		}

		/// <summary>
		/// <para>
		/// The <c>SOCKADDR_IN6_PAIR</c> structure contains pointers to a pair of IP addresses that represent a source and destination
		/// address pair.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>The <c>SOCKADDR_IN6_PAIR</c> structure is defined on Windows Vista and later.</para>
		/// <para>
		/// Any IPv4 addresses in the <c>SOCKADDR_IN6_PAIR</c> structure must be represented in the IPv4-mapped IPv6 address format which
		/// enables an IPv6 only application to communicate with an IPv4 node. For more information on the IPv4-mapped IPv6 address format,
		/// see Dual-Stack Sockets.
		/// </para>
		/// <para>The <c>SOCKADDR_IN6_PAIR</c> structure is used by the CreateSortedAddressPairs function.</para>
		/// <para>Note that the Ws2ipdef.h header file is automatically included in Ws2tcpip.h header file, and should never be used directly.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ws2ipdef/ns-ws2ipdef-_sockaddr_in6_pair
		// typedef struct _sockaddr_in6_pair { PSOCKADDR_IN6 SourceAddress; PSOCKADDR_IN6 DestinationAddress; } SOCKADDR_IN6_PAIR, *PSOCKADDR_IN6_PAIR;
		[PInvokeData("ws2ipdef.h", MSDNShortId = "0265f8e0-8b35-4d9d-bf22-e98e9ff36a17")]
		[StructLayout(LayoutKind.Sequential)]
		public struct SOCKADDR_IN6_PAIR
		{
			private IntPtr _SourceAddress;
			private IntPtr _DestinationAddress;
			/// <summary><para>A pointer to an IP source address represented as a SOCKADDR_IN6 structure. The address family is in host byte order and the IPv6 address, port, flow information, and zone ID are in network byte order.</para></summary>
			public SOCKADDR_IN6 SourceAddress => _SourceAddress.ToStructure<SOCKADDR_IN6>();
			/// <summary><para>A pointer to an IP source address represented as a SOCKADDR_IN6 structure. The address family is in host byte order and the IPv6 address, port, flow information, and zone ID are in network byte order.</para></summary>
			public SOCKADDR_IN6 DestinationAddress => _DestinationAddress.ToStructure<SOCKADDR_IN6>();
		}

		[PInvokeData("winsock2.h")]
		[StructLayout(LayoutKind.Explicit)]
		public struct SOCKADDR_INET : IEquatable<SOCKADDR_INET>, IEquatable<SOCKADDR_IN>, IEquatable<SOCKADDR_IN6>
		{
			[FieldOffset(0)]
			public SOCKADDR_IN Ipv4;
			[FieldOffset(0)]
			public SOCKADDR_IN6 Ipv6;
			[FieldOffset(0)]
			public ADDRESS_FAMILY si_family;

			public bool Equals(SOCKADDR_INET other) => (si_family == ADDRESS_FAMILY.AF_INET && Ipv4.Equals(other.Ipv4)) || (si_family == ADDRESS_FAMILY.AF_INET6 && Ipv6.Equals(other.Ipv6));
			public bool Equals(SOCKADDR_IN other) => si_family == ADDRESS_FAMILY.AF_INET && Ipv4.Equals(other);
			public bool Equals(SOCKADDR_IN6 other) => si_family == ADDRESS_FAMILY.AF_INET6 && Ipv6.Equals(other);

			public static implicit operator SOCKADDR_INET(SOCKADDR_IN address) => new SOCKADDR_INET { Ipv4 = address };
			public static implicit operator SOCKADDR_INET(SOCKADDR_IN6 address) => new SOCKADDR_INET { Ipv6 = address };

			public override string ToString()
			{
				var sb = new System.Text.StringBuilder($"{si_family}");
				if (si_family == ADDRESS_FAMILY.AF_INET)
					sb.Append(":").Append(Ipv4);
				else if (si_family == ADDRESS_FAMILY.AF_INET6)
					sb.Append(":").Append(Ipv6);
				return sb.ToString();
			}
		}

		[PInvokeData("winsock2.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct SOCKET_ADDRESS
		{
			public IntPtr lpSockAddr;
			public int iSockaddrLength;

			public SOCKADDR_INET GetSOCKADDR() => lpSockAddr.ToStructure<SOCKADDR_INET>();

			public override string ToString() => GetSOCKADDR().ToString();
		}

		[PInvokeData("winsock2.h")]
		public class SOCKADDR : SafeMemoryHandle<CoTaskMemoryMethods>
		{
			public SOCKADDR(uint addr, ushort port = 0) : this(BitConverter.GetBytes(addr), port) { }

			public SOCKADDR(byte[] addr, ushort port = 0, uint scopeId = 0) :
				base(addr.Length == 4 ? Marshal.SizeOf(typeof(SOCKADDR_IN)) : Marshal.SizeOf(typeof(SOCKADDR_IN6)))
			{
				if (addr.Length == 4)
				{
					var in4 = new SOCKADDR_IN(new IN_ADDR(addr), port);
					Marshal.StructureToPtr(in4, handle, false);
				}
				else if (addr.Length == 16)
				{
					var in6 = new SOCKADDR_IN6(addr, scopeId, port);
					Marshal.StructureToPtr(in6, handle, false);
				}
				else
					throw new ArgumentOutOfRangeException(nameof(addr));
			}

			public byte[] sa_data => GetBytes(2, 14);
			public ushort sa_family => handle.ToStructure<ushort>();
		}
	}
}