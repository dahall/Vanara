using NUnit.Framework;
using Vanara;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vanara.InteropServices;

namespace Vanara.InteropServices.Tests
{
	[TestFixture()]
	public class MarshalingStreamTests
	{
		[Test()]
		public void MarshalingStreamTest()
		{
			using (var m = new SafeHGlobalHandle(1024))
			using (var ms = new MarshalingStream((IntPtr)m, m.Size))
				Assert.That(ms.Capacity, Is.EqualTo(m.Size));
		}

		[Test()]
		public void FlushTest()
		{
			using (var m = new SafeHGlobalHandle(1000))
			using (var ms = new MarshalingStream((IntPtr) m, m.Size))
			{
				ms.Flush();
			}
		}

		[Test()]
		public void SeekTest()
		{
			using (var m = new SafeHGlobalHandle(1000))
			using (var ms = new MarshalingStream((IntPtr) m, m.Size))
			{
				Assert.That(ms.Seek(20, SeekOrigin.Begin), Is.EqualTo(20));
				Assert.That(ms.Seek(20, SeekOrigin.Current), Is.EqualTo(40));
				Assert.That(ms.Seek(-100, SeekOrigin.End), Is.EqualTo(900));
				Assert.That(() => ms.Seek(-1, SeekOrigin.Begin), Throws.ArgumentException);
				Assert.That(() => ms.Seek(1, SeekOrigin.End), Throws.ArgumentException);
			}
		}

		[Test()]
		public void SetLengthTest()
		{
			using (var m = new SafeHGlobalHandle(1000))
			using (var ms = new MarshalingStream((IntPtr) m, m.Size))
			{
				Assert.That(() => ms.SetLength(1), Throws.Exception);
			}
		}

		[Test()]
		public void PokeTest()
		{
			using (var m = new SafeHGlobalHandle(10))
			using (var ms = new MarshalingStream((IntPtr) m, m.Size))
			{
				Assert.That(() => ms.Write(0x000001FF), Throws.Nothing);
				Assert.That(ms.Position, Is.EqualTo(sizeof(int)));
				ms.Seek(0, SeekOrigin.Begin);
				var ba = new byte[] {0x2};
				Assert.That(() => ms.Poke(null, 0), Throws.ArgumentNullException);
				Assert.That(() => ms.Poke(ba, 1000), Throws.ArgumentException);
				Assert.That(() => ms.Poke(ba, -1), Throws.TypeOf<ArgumentOutOfRangeException>());
				ms.Poke(ba, 1);
				Assert.That(ms.Read<int>(), Is.EqualTo(0x00000102));
				Assert.That(() => ms.Read<ulong>(), Throws.TypeOf<ArgumentOutOfRangeException>());
			}
		}

		[Test()]
		public void PokeTest1()
		{
			using (var m = new SafeHGlobalHandle(100))
			using (var ms = new MarshalingStream((IntPtr) m, m.Size))
			{
				Assert.That(ms.Position, Is.Zero);
				Assert.That(() => ms.Write(new [] {1L, 2L}), Throws.Nothing);
				var bytes = new byte[] {0, 0, 0, 0, 0, 0, 0, 3};
				ms.Write(bytes, 0, bytes.Length);
				Assert.That(ms.Position, Is.EqualTo(sizeof(long) * 2 + 8));
				ms.Seek(0, SeekOrigin.Begin);
				Assert.That(() => ms.Poke(IntPtr.Zero, 1002), Throws.ArgumentException);
				Assert.That(() => ms.Poke(IntPtr.Zero, -1), Throws.TypeOf<ArgumentOutOfRangeException>());
				ms.Poke(IntPtr.Zero, sizeof(long));
				var buf = new byte[24];
				ms.Read(buf, 0, buf.Length);
				Assert.That(buf, Is.EquivalentTo(new byte[] {0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3}));
				Assert.That(() => ms.Read(null, 0, 0), Throws.ArgumentNullException);
				Assert.That(() => ms.Read(buf, 0, 30), Throws.ArgumentException);
				Assert.That(() => ms.Read(buf, -1, 0), Throws.TypeOf<ArgumentOutOfRangeException>());
				ms.Position = m.Size - 10;
				Assert.That(() => ms.Read(buf, 0, buf.Length), Throws.Nothing);
			}
		}

		[Test]
		public void PropTest()
		{
			using (var m = new SafeHGlobalHandle(1000))
			using (var ms = new MarshalingStream((IntPtr)m, m.Size))
			{
				Assert.That(ms.Length, Is.EqualTo(1000));
				Assert.That(ms.CanWrite, Is.True);
				Assert.That(ms.CanSeek, Is.True);
				Assert.That(ms.CanRead, Is.True);
			}
		}

		[Test]
		public void WriteTest()
		{
			using (var m = new SafeHGlobalHandle(10))
			using (var ms = new MarshalingStream((IntPtr) m, m.Size))
			{
				Assert.That(() => ms.Write(null, 0, 0), Throws.ArgumentNullException);
				var bytes = new byte[] {0, 0, 0, 0, 0, 0, 0, 3};
				Assert.That(() => ms.Write(bytes, 1, 8), Throws.ArgumentException);
				Assert.That(() => ms.Write(bytes, -1, 8), Throws.TypeOf<ArgumentOutOfRangeException>());
				Assert.That(() => ms.Write(bytes, 1, -8), Throws.TypeOf<ArgumentOutOfRangeException>());
				Assert.That(() => ms.Write(new byte[22]), Throws.ArgumentException);
				ms.Write((SafeHGlobalHandle) null);
				Assert.That(ms.Position, Is.Zero);
				ms.Write((string[]) null);
				Assert.That(ms.Position, Is.Zero);
				Assert.That(() => ms.Write(0L), Throws.Nothing);
			}
			using (var m = new SafeHGlobalHandle(100))
			using (var ms = new MarshalingStream((IntPtr)m, m.Size))
			{
				ms.Write(new []{ "A", "B", "C"});
				Assert.That(ms.Position, Is.GreaterThan(0));
				Assert.That(() => ms.Write(new byte[100], 0, 100), Throws.ArgumentException);
			}
		}
	}
}