using NUnit.Framework;
using Vanara;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vanara.InteropServices;
using Vanara.Extensions;
using System.Runtime.InteropServices;

namespace Vanara.InteropServices.Tests
{
	[TestFixture()]
	public class NativeMemoryStreamTests
	{
		[TestCase(0)]
		[TestCase(1)]
		[TestCase(256)]
		[TestCase(8196)]
		public void NativeMemoryStreamTest(int sz)
		{
			using (var ms = new NativeMemoryStream(sz))
				Assert.That(ms.Capacity, Is.EqualTo(sz));
		}

		/*[Test()]
		public void FlushTest()
		{
			using (var m = new SafeHGlobalHandle(1000))
			using (var ms = new NativeMemoryStream((IntPtr) m, m.Size))
			{
				ms.Flush();
			}
		}

		[Test()]
		public void SeekTest()
		{
			using (var m = new SafeHGlobalHandle(1000))
			using (var ms = new NativeMemoryStream((IntPtr) m, m.Size))
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
			using (var ms = new NativeMemoryStream((IntPtr) m, m.Size))
			{
				Assert.That(() => ms.SetLength(1), Throws.Exception);
			}
		}

		[Test]
		public void PropTest()
		{
			using (var m = new SafeHGlobalHandle(1000))
			using (var ms = new NativeMemoryStream((IntPtr)m, m.Size))
			{
				Assert.That(ms.Length, Is.EqualTo(1000));
				Assert.That(ms.CanWrite, Is.True);
				Assert.That(ms.CanSeek, Is.True);
				Assert.That(ms.CanRead, Is.True);
			}
		}*/

		[Test]
		public void WriteBytesTest()
		{
			using (var ms = new NativeMemoryStream(20))
			{
				Assert.That(ms.Length, Is.EqualTo(0));
				Assert.That(() => ms.Write(null, 0, 0), Throws.ArgumentNullException);
				var bytes = new byte[] {0, 0, 0, 0, 0, 0, 0, 3};
				Assert.That(() => ms.Write(bytes, 1, 8), Throws.ArgumentException);
				Assert.That(() => ms.Write(bytes, -1, 8), Throws.TypeOf<ArgumentOutOfRangeException>());
				Assert.That(() => ms.Write(bytes, 1, -8), Throws.TypeOf<ArgumentOutOfRangeException>());
				Assert.That(() => ms.Write(bytes, 0, 8), Throws.Nothing);
				Assert.That(ms.Length, Is.EqualTo(8));
				Assert.That(ms.Position, Is.EqualTo(8));
				Assert.That(ms.Capacity, Is.EqualTo(20));
				Assert.That(() => ms.Write(new byte[22], 0, 22), Throws.Nothing);
				Assert.That(ms.Length, Is.EqualTo(30));
				Assert.That(ms.Position, Is.EqualTo(30));
				Assert.That(ms.Capacity, Is.GreaterThan(20));

				/*ms.Write(new []{ "A", "B", "C"});
				Assert.That(ms.Position, Is.GreaterThan(0));
				Assert.That(() => ms.Write(new byte[100], 0, 100), Throws.ArgumentException);

				Assert.That(() => ms.Write(new Vanara.PInvoke.User32_Gdi.ICONINFO()), Throws.ArgumentException);
				ms.Write((SafeHGlobalHandle)null);
				Assert.That(ms.Position, Is.Zero);
				ms.Write((string[])null);
				Assert.That(ms.Position, Is.Zero);*/
			}
		}

		[Test]
		public void WriteRefStringTest()
		{
			using (var ms = new NativeMemoryStream(20))
			{
				Assert.That(() => ms.WriteReference(""), Throws.Nothing);
				Assert.That(ms.Length, Is.EqualTo(2 + IntPtr.Size));
				Assert.That(ms.Position, Is.EqualTo(IntPtr.Size));
				Assert.That(ms.Capacity, Is.EqualTo(20));
				Assert.That(() => ms.WriteReference("0123456789"), Throws.Nothing);
				Assert.That(ms.Length, Is.EqualTo(24 + IntPtr.Size * 2));
				Assert.That(ms.Position, Is.EqualTo(IntPtr.Size * 2));
				Assert.That(ms.Capacity, Is.EqualTo(20));
				Assert.That(ms.Pointer.ToArray(IntPtr.Size == 4 ? typeof(uint) : typeof(ulong), 2), Is.EquivalentTo(new[] { 0, 0 }));
				ms.Flush();
				Assert.That(ms.Pointer.ToArray(IntPtr.Size == 4 ? typeof(uint) : typeof(ulong), 2), Is.Not.EquivalentTo(new[] { 0, 0 }));
				Assert.That(ms.Capacity, Is.GreaterThan(20));
			}
		}

		[Test]
		public void WriteRefStructTest()
		{
			using (var ms = new NativeMemoryStream(8, 16, 100))
			{
				Assert.That(() => ms.WriteReference(256), Throws.Nothing);
				var i = sizeof(int) + IntPtr.Size;
				Assert.That(ms.Length, Is.EqualTo(i));
				Assert.That(ms.Position, Is.EqualTo(IntPtr.Size));
				Assert.That(ms.Capacity, Is.EqualTo(8));
				Assert.That(() => ms.WriteReference((ushort)256), Throws.Nothing);
				i += sizeof(ushort) + IntPtr.Size;
				Assert.That(ms.Length, Is.EqualTo(i));
				Assert.That(ms.Position, Is.EqualTo(IntPtr.Size * 2));
				Assert.That(ms.Capacity, Is.EqualTo(8));
				Assert.That(() => ms.WriteReference((long)1), Throws.Nothing);
				i += sizeof(long) + IntPtr.Size;
				Assert.That(ms.Length, Is.EqualTo(i));
				Assert.That(ms.Position, Is.EqualTo(IntPtr.Size * 3));
				Assert.That(ms.Capacity, Is.EqualTo(24));
				Assert.That(ms.Pointer.ToArray(IntPtr.Size == 4 ? typeof(uint) : typeof(ulong), 3), Is.EquivalentTo(new[] { 0, 0, 0 }));
				Assert.That(() => ms.WriteReference(Guid.NewGuid()), Throws.Nothing);
				i += Marshal.SizeOf(typeof(Guid)) + IntPtr.Size;
				Assert.That(ms.Length, Is.EqualTo(i));
				Assert.That(ms.Position, Is.EqualTo(IntPtr.Size * 4));
				Assert.That(ms.Capacity, Is.EqualTo(24));
				ms.Flush();
				Assert.That(ms.Length, Is.EqualTo(ms.Position));
				Assert.That(ms.Capacity, Is.GreaterThanOrEqualTo(ms.Length));
			}
		}

		[Test]
		public void WriteStringEnumTest()
		{
			using (var ms = new NativeMemoryStream(128, 128))
			{
				Assert.That(() => ms.Write(new[] { "A", "B", "C" }, StringListPackMethod.Concatenated), Throws.Nothing);
				var len = 14;
				var pos = len;
				Assert.That(len, Is.EqualTo(ms.Length).And.EqualTo(ms.Position));
				Assert.That(() => ms.Write(new[] { "A", "B", "C" }, StringListPackMethod.Packed), Throws.Nothing);
				Assert.That(len += 12 + IntPtr.Size * 3, Is.EqualTo(ms.Length));
				Assert.That(pos += IntPtr.Size * 3, Is.EqualTo(ms.Position));
				Assert.That(ms.Capacity, Is.EqualTo(128));
				Assert.That(() => ms.Write(new[] { "A", null, "C" }, StringListPackMethod.Concatenated), Throws.Exception);
				Assert.That(() => ms.Write(new[] { "A", null, "C" }, StringListPackMethod.Packed), Throws.Nothing);
				Assert.That(len += 8 + IntPtr.Size * 3, Is.EqualTo(ms.Length));
				Assert.That(pos += IntPtr.Size * 3, Is.EqualTo(ms.Position));
				Assert.That(ms.Capacity, Is.EqualTo(128));

				var testSz = 10;
				var strSz = 50;
				var l = new List<string>(testSz);
				for (var i = 0; i < testSz; i++)
					l.Add(new string('X', strSz));
				Assert.That(() => ms.Write(l, StringListPackMethod.Concatenated), Throws.Nothing);
				var strLen = ((strSz + 1) * testSz + 1) * StringHelper.GetCharSize();
				Assert.That(len += strLen, Is.EqualTo(ms.Length));
				Assert.That(pos += strLen, Is.EqualTo(ms.Position));
				Assert.That(ms.Capacity, Is.GreaterThan(128));

				Assert.That(() => ms.Write(l, StringListPackMethod.Packed), Throws.Nothing);
				strLen = (strSz + 1) * testSz * StringHelper.GetCharSize();
				Assert.That(len += strLen + IntPtr.Size * testSz, Is.EqualTo(ms.Length));
				Assert.That(pos += IntPtr.Size * testSz, Is.EqualTo(ms.Position));

				Assert.That(ms.Position, Is.LessThan(ms.Length));
				ms.Flush();
				Assert.That(ms.Position, Is.EqualTo(ms.Length));
				Assert.That(ms.Position, Is.LessThanOrEqualTo(ms.Capacity));

				l.Clear();
			}
		}

		[Test]
		public void WriteStringTest()
		{
			using (var ms = new NativeMemoryStream(20))
			{
				Assert.That(() => ms.Write(""), Throws.Nothing);
				Assert.That(ms.Length, Is.EqualTo(2));
				Assert.That(ms.Position, Is.EqualTo(2));
				Assert.That(ms.Capacity, Is.EqualTo(20));
				Assert.That(() => ms.Write("0123456789"), Throws.Nothing);
				Assert.That(ms.Length, Is.EqualTo(24));
				Assert.That(ms.Position, Is.EqualTo(24));
				Assert.That(ms.Capacity, Is.GreaterThan(20));
			}
		}

		[Test]
		public void WriteStructTest()
		{
			using (var ms = new NativeMemoryStream(6, 10, 100))
			{
				Assert.That(() => ms.Write(256), Throws.Nothing);
				Assert.That(ms.Length, Is.EqualTo(4));
				Assert.That(ms.Position, Is.EqualTo(4));
				Assert.That(ms.Capacity, Is.EqualTo(6));
				Assert.That(() => ms.Write((ushort)256), Throws.Nothing);
				Assert.That(ms.Length, Is.EqualTo(6));
				Assert.That(ms.Position, Is.EqualTo(6));
				Assert.That(ms.Capacity, Is.EqualTo(6));
				Assert.That(() => ms.Write((long)1), Throws.Nothing);
				Assert.That(ms.Length, Is.EqualTo(14));
				Assert.That(ms.Position, Is.EqualTo(14));
				Assert.That(ms.Capacity, Is.EqualTo(16));
				Assert.That(ms.Pointer.ToArray<byte>((int)ms.Length), Is.EquivalentTo(new byte[] { 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 }));
				Assert.That(() => ms.Write(Guid.NewGuid()), Throws.Nothing);
				Assert.That(ms.Length, Is.EqualTo(30));
				Assert.That(ms.Position, Is.EqualTo(30));
				Assert.That(ms.Capacity, Is.EqualTo(30));

				Assert.That(() => ms.Write(new Unblittable()), Throws.Exception);
			}
		}

		private struct Unblittable
		{
			public Guid g;
			[MarshalAs(UnmanagedType.LPStruct)]
			public Guid s;
			//public DateTime dt;
		}
	}
}