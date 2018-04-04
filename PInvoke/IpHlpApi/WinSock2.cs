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
			AF_UNSPEC = 0,       // unspecified
			AF_UNIX = 1,         // local to host (pipes, portals)
			AF_INET = 2,         // internetwork: UDP, TCP, etc.
			AF_IMPLINK = 3,      // arpanet imp addresses
			AF_PUP = 4,          // pup protocols: e.g. BSP
			AF_CHAOS = 5,        // mit CHAOS protocols
			AF_NS = 6,           // XEROX NS protocols
			AF_IPX = AF_NS,      // IPX protocols: IPX, SPX, etc.
			AF_ISO = 7,          // ISO protocols
			AF_OSI = AF_ISO,     // OSI is ISO
			AF_ECMA = 8,         // european computer manufacturers
			AF_DATAKIT = 9,      // datakit protocols
			AF_CCITT = 10,       // CCITT protocols, X.25 etc
			AF_SNA = 11,         // IBM SNA
			AF_DECnet = 12,      // DECnet
			AF_DLI = 13,         // Direct data link interface
			AF_LAT = 14,         // LAT
			AF_HYLINK = 15,      // NSC Hyperchannel
			AF_APPLETALK = 16,   // AppleTalk
			AF_NETBIOS = 17,     // NetBios-style addresses
			AF_VOICEVIEW = 18,   // VoiceView
			AF_FIREFOX = 19,     // Protocols from Firefox
			AF_UNKNOWN1 = 20,    // Somebody is using this!
			AF_BAN = 21,         // Banyan
			AF_ATM = 22,         // Native ATM Services
			AF_INET6 = 23,       // Internetwork Version 6
			AF_CLUSTER = 24,     // Microsoft Wolfpack
			AF_12844 = 25,       // IEEE 1284.4 WG AF
			AF_IRDA = 26,        // IrDA
			AF_NETDES = 28,      // Network Designers OSI & gateway
			AF_TCNPROCESS = 29,
			AF_TCNMESSAGE = 30,
			AF_ICLFXBM = 31,
			AF_BTH = 32,         // Bluetooth RFCOMM/L2CAP protocols
			AF_LINK = 33,
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
		public unsafe struct IN6_ADDR
		{
			private const int IN6_ADDR_SIZE = 16;

			private fixed byte _u_bytes[IN6_ADDR_SIZE];

			public IN6_ADDR(byte[] v6addr)
			{
				u_bytes = v6addr;
			}

			public byte[] u_bytes
			{
				get
				{
					var v6addr = new byte[IN6_ADDR_SIZE];
					fixed (byte* src = _u_bytes, dest = v6addr)
					{
						for (var i = 0; i < IN6_ADDR_SIZE; i++)
							*(dest + i) = *(src + i);
					}
					return v6addr;
				}
				set
				{
					if (value == null) value = new byte[IN6_ADDR_SIZE];
					if (value.Length != IN6_ADDR_SIZE)
						throw new ArgumentException("Byte array must have 16 items.", nameof(value));
					fixed (byte* src = value, dest = _u_bytes)
					{
						for (var i = 0; i < IN6_ADDR_SIZE; i++)
							*(dest + i) = *(src + i);
					}
				}
			}

			public ushort[] u_words
			{
				get
				{
					var v6addr = new ushort[IN6_ADDR_SIZE / 2];
					fixed (byte* pbytes = _u_bytes)
					fixed (ushort* dest = v6addr)
					{
						var src = (ushort*)pbytes;
						for (var i = 0; i < IN6_ADDR_SIZE / 2; i++)
							*(dest + i) = *(src + i);
					}
					return v6addr;
				}
				set
				{
					if (value == null) value = new ushort[IN6_ADDR_SIZE / 2];
					if (value.Length != IN6_ADDR_SIZE / 2)
						throw new ArgumentException("UInt16 array must have 8 items.", nameof(value));
					fixed (ushort* src = value)
					fixed (byte* pbytes = _u_bytes)
					{
						var dest = (ushort*)pbytes;
						for (var i = 0; i < IN6_ADDR_SIZE / 2; i++)
							*(dest + i) = *(src + i);
					}
				}
			}

			public static implicit operator IN6_ADDR(byte[] a) => new IN6_ADDR(a);

			public static implicit operator byte[] (IN6_ADDR a) => a.u_bytes;

			public override string ToString()
			{
				const string numberFormat = "{0:x4}:{1:x4}:{2:x4}:{3:x4}:{4:x4}:{5:x4}:{6}.{7}.{8}.{9}";
				var m_Numbers = u_words;
				return string.Format(System.Globalization.CultureInfo.InvariantCulture, numberFormat,
					m_Numbers[0], m_Numbers[1], m_Numbers[2], m_Numbers[3], m_Numbers[4], m_Numbers[5],
					((m_Numbers[6] >> 8) & 0xFF), (m_Numbers[6] & 0xFF), ((m_Numbers[7] >> 8) & 0xFF), (m_Numbers[7] & 0xFF));
			}
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

			public SOCKADDR_IN6(IN6_ADDR addr, uint scope_id, ushort port = 0) : this(addr.u_bytes, scope_id, port) { }

			public SOCKADDR_IN6(byte[] addr, uint scope_id, ushort port = 0)
			{
				if (addr.Length != 16) throw new ArgumentException();
				sin6_family = ADDRESS_FAMILY.AF_INET6;
				sin6_port = port;
				sin6_flowinfo = 0;
				sin6_addr = new byte[16];
				Array.ConstrainedCopy(addr, 0, sin6_addr, 0, addr.Length);
				sin6_scope_id = scope_id;
			}

			public override string ToString() => $"{sin6_addr}" + (sin6_scope_id == 0 ? "" : "%" + sin6_scope_id.ToString()) + $":{sin6_port}";
		}

		[PInvokeData("winsock2.h")]
		[StructLayout(LayoutKind.Explicit)]
		public struct SOCKADDR_INET
		{
			[FieldOffset(0)]
			public SOCKADDR_IN Ipv4;
			[FieldOffset(0)]
			public SOCKADDR_IN6 Ipv6;
			[FieldOffset(0)]
			public ADDRESS_FAMILY si_family;

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