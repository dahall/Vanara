using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Vanara.InteropServices.Tests;

#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
[TestFixture()]
public class NativeMemoryStreamTests
{
	private const string testStr = "0123456789";

	[Test]
	public void BytesTest()
	{
		using var ms = new NativeMemoryStream(20, 10);
		Assert.That(ms.Length, Is.EqualTo(0));
		Assert.That(() => ms.Write(null, 0, 0), Throws.ArgumentNullException);
		var bytes = new byte[] { 0, 0, 0, 0, 0, 0, 0, 3 };
		Assert.That(() => ms.Write(bytes, 1, 8), Throws.ArgumentException);
		Assert.That(() => ms.Write(bytes, -1, 8), Throws.TypeOf<ArgumentOutOfRangeException>());
		Assert.That(() => ms.Write(bytes, 1, -8), Throws.TypeOf<ArgumentOutOfRangeException>());
		Assert.That(() => ms.Write(bytes, 0, 8), Throws.Nothing);
		Assert.That(ms.Length, Is.EqualTo(8));
		Assert.That(ms.Position, Is.EqualTo(8));
		Assert.That(ms.Capacity, Is.EqualTo(20));
		var ones = new byte[22];
		for (var i = 0; i < ones.Length; i++) ones[i] = 1;
		Array.ForEach(ones, b => b = 1);
		Assert.That(() => ms.Write(ones, 0, ones.Length), Throws.Nothing);
		Assert.That(ms.Length, Is.EqualTo(30));
		Assert.That(ms.Position, Is.EqualTo(30));
		Assert.That(ms.Capacity, Is.EqualTo(30));

		ms.Flush();
		ms.Position = 0;

		Assert.That(() => ms.Read(null, 0, 0), Throws.ArgumentNullException);
		var rbytes = new byte[bytes.Length];
		Assert.That(() => ms.Read(rbytes, 5, bytes.Length), Throws.ArgumentException);
		Assert.That(() => ms.Read(rbytes, -1, 1), Throws.InstanceOf<ArgumentOutOfRangeException>());
		Assert.That(() => ms.Read(rbytes, 0, -1), Throws.InstanceOf<ArgumentOutOfRangeException>());
		Assert.That(ms.Read(rbytes, 0, bytes.Length), Is.EqualTo(bytes.Length));
		Assert.That(rbytes, Is.EquivalentTo(bytes));
		Assert.That(ms.Position, Is.EqualTo(bytes.Length));
		rbytes = new byte[ms.Length];
		Assert.That(() => ms.Read(rbytes, (int)ms.Position, 40), Throws.ArgumentException);
		Assert.That(ms.Read(rbytes, (int)ms.Position, ones.Length), Is.EqualTo(ones.Length));
		for (var i = bytes.Length; i < ms.Position; i++)
			Assert.That(rbytes[i], Is.EqualTo(1));
		Assert.That(() => ms.Read(rbytes, 0, 2), Throws.InstanceOf<ArgumentOutOfRangeException>());
	}

	[Test]
	public void CapacityTest()
	{
		using var ms = new NativeMemoryStream(10, 10, 20);
		Assert.That(ms.Capacity, Is.EqualTo(10));
		ms.Write(Guid.NewGuid());
		Assert.That(ms.Capacity, Is.EqualTo(20));
		Assert.That(ms.Length, Is.EqualTo(16));

		Assert.That(() => ms.EnsureCapacity(-100), Throws.TypeOf<ArgumentOutOfRangeException>());
		Assert.That(() => ms.EnsureCapacity(40), Throws.TypeOf<ArgumentOutOfRangeException>());
	}

	[Test]
	public void DisposedTest()
	{
		var ms = new NativeMemoryStream(20);
		ms.Dispose();
		Assert.That(ms.CanRead, Is.False);
		Assert.That(ms.CanSeek, Is.False);
		Assert.That(ms.CanWrite, Is.False);
		Assert.That(() => ms.Capacity > 0, Throws.InstanceOf<ObjectDisposedException>());
		Assert.That(() => ms.Read<int>(), Throws.InstanceOf<ObjectDisposedException>());
		Assert.That(() => ms.Read(typeof(int)), Throws.InstanceOf<ObjectDisposedException>());
		Assert.That(() => ms.Read(new byte[3], 0, 3), Throws.InstanceOf<ObjectDisposedException>());
		Assert.That(ms.ReadByte, Throws.InstanceOf<ObjectDisposedException>());
		Assert.That(() => ms.ReadArray(typeof(byte), 1, false), Throws.InstanceOf<ObjectDisposedException>());
		Assert.That(() => ms.ReadReference<int>(), Throws.InstanceOf<ObjectDisposedException>());
		Assert.That(() => ms.ReadReference<string>(), Throws.InstanceOf<ObjectDisposedException>());
		Assert.That(() => ms.Seek(0, SeekOrigin.Begin), Throws.InstanceOf<ObjectDisposedException>());
		Assert.That(() => ms.SetLength(20), Throws.InstanceOf<ObjectDisposedException>());
		Assert.That(() => ms.Write("X"), Throws.InstanceOf<ObjectDisposedException>());
		Assert.That(() => ms.Write("X", CharSet.Ansi), Throws.InstanceOf<ObjectDisposedException>());
		Assert.That(() => ms.Write(new[] { "X", "Y" }), Throws.InstanceOf<ObjectDisposedException>());
		Assert.That(() => ms.Write(new byte[3], 0, 3), Throws.InstanceOf<ObjectDisposedException>());
		Assert.That(() => ms.Write(new[] { 1, 2 }), Throws.InstanceOf<ObjectDisposedException>());
		Assert.That(() => ms.Write(256), Throws.InstanceOf<ObjectDisposedException>());
		Assert.That(() => ms.WriteByte(1), Throws.InstanceOf<ObjectDisposedException>());
		Assert.That(() => ms.WriteObject(Guid.NewGuid()), Throws.InstanceOf<ObjectDisposedException>());
		Assert.That(() => ms.WriteReference("X"), Throws.InstanceOf<ObjectDisposedException>());
		Assert.That(() => ms.WriteReference(256), Throws.InstanceOf<ObjectDisposedException>());
		Assert.That(() => ms.WriteReferenceObject(Guid.NewGuid()), Throws.InstanceOf<ObjectDisposedException>());
	}

	[TestCase(0)]
	[TestCase(1)]
	[TestCase(256)]
	[TestCase(8196)]
	public void NativeMemoryStreamTest(int sz)
	{
		using var ms = new NativeMemoryStream(sz);
		if (sz <= 0)
			Assert.That(() => ms.Capacity, Throws.Exception);
		else
			Assert.That(ms.Capacity, Is.EqualTo(sz));
	}

	[Test]
	public void NativeMemoryStreamTest2()
	{
		using var m = new SafeHGlobalHandle(10);
		Assert.That(() => new NativeMemoryStream(null, 10, 20), Throws.ArgumentNullException);
		using var ms = new NativeMemoryStream(m, 10, 20);
		Assert.That(ms.Capacity, Is.EqualTo(10));
		Assert.That(ms.MaxCapacity, Is.EqualTo(20));
		Assert.That(ms.Pointer, Is.EqualTo((IntPtr)m));
		Assert.That(() => ms.Write(Guid.NewGuid()), Throws.Nothing);
		Assert.That(ms.Capacity, Is.EqualTo(20));
		Assert.That(() => ms.Write(Guid.NewGuid()), Throws.Exception);
	}

	[Test]
	public void NativeVsNormalTest()
	{
		var buffer = new byte[1000];
		var temp1 = new MemoryStream();
		var temp2 = new NativeMemoryStream();

		temp1.Write(new byte[1000]);
		temp2.Write(new byte[1000]);

		Assert.That(temp1.Read(buffer, 0, 100), Is.EqualTo(0)); // Normal for MemoryStream, return value is 0
		Assert.That(temp2.Read(buffer, 0, 100), Is.EqualTo(0)); // NativeMemoryStream throw ArgumentOutOfRangeException here
	}

	[Test]
	public void MixedReadWriteTest()
	{
		using var m = new SafeHGlobalHandle(512);
		var str = "Test1";
		var guid = Guid.NewGuid();
		var lVal = 1208L;
		byte b = 18;
		using var ms = new NativeMemoryStream(m) { CharSet = CharSet.Unicode };
		Assert.That(() => ms.WriteReference(str), Throws.Nothing);
		Assert.That(() => ms.Write(str), Throws.Nothing);
		Assert.That(() => ms.WriteReference(guid), Throws.Nothing);
		Assert.That(() => ms.Write(guid), Throws.Nothing);
		Assert.That(() => ms.WriteReference(lVal), Throws.Nothing);
		Assert.That(() => ms.Write(lVal), Throws.Nothing);
		Assert.That(() => ms.WriteReference(b), Throws.Nothing);
		Assert.That(() => ms.Write(b), Throws.Nothing);
		Assert.That(() => ms.WriteReference(str), Throws.Nothing);

		ms.Flush();
		ms.Position = 0;

		Assert.That(ms.ReadReference<string>(CharSet.Unicode), Is.EqualTo(str));
		Assert.That(ms.Read<string>(CharSet.Unicode), Is.EqualTo(str));
		Assert.That(ms.ReadReference<Guid>(), Is.EqualTo(guid));
		Assert.That(ms.Read<Guid>(), Is.EqualTo(guid));
		Assert.That(ms.ReadReference<long>(), Is.EqualTo(lVal));
		Assert.That(ms.Read<long>(), Is.EqualTo(lVal));
		Assert.That(ms.ReadReference<byte>(), Is.EqualTo(b));
		Assert.That(ms.Read<byte>(), Is.EqualTo(b));
		Assert.That(ms.ReadReference<string>(CharSet.Unicode), Is.EqualTo(str));
	}

	[Test]
	public void PropTest()
	{
		using var m = new SafeHGlobalHandle(1000);
		using var ms = new NativeMemoryStream((IntPtr)m, m.Size);
		Assert.That(ms.Capacity, Is.EqualTo(1000));
		Assert.That(ms.CanWrite, Is.False);
		Assert.That(ms.CanSeek, Is.True);
		Assert.That(ms.CanRead, Is.True);
		Assert.That(ms.Length, Is.EqualTo(0));

		Assert.That(() => ms.EnsureCapacity(2000), Throws.InvalidOperationException);
	}

	[Test]
	public void ReadWriteOnlyTest()
	{
		using (var m = new SafeHGlobalHandle(10))
		using (var ms = new NativeMemoryStream((IntPtr)m, m.Size))
		{
			Assert.That(ms.CanWrite, Is.False);
			Assert.That(ms.CanSeek, Is.True);
			Assert.That(ms.CanRead, Is.True);

			Assert.That(() => ms.Write("X"), Throws.InstanceOf<NotSupportedException>());
			Assert.That(() => ms.Write("X", CharSet.Ansi), Throws.InstanceOf<NotSupportedException>());
			Assert.That(() => ms.Write(new[] { "X", "Y" }), Throws.InstanceOf<NotSupportedException>());
			Assert.That(() => ms.Write(new byte[3], 0, 3), Throws.InstanceOf<NotSupportedException>());
			Assert.That(() => ms.Write(new[] { 1, 2 }), Throws.InstanceOf<NotSupportedException>());
			Assert.That(() => ms.Write(256), Throws.InstanceOf<NotSupportedException>());
			Assert.That(() => ms.WriteByte(1), Throws.InstanceOf<NotSupportedException>());
			Assert.That(() => ms.WriteObject(Guid.NewGuid()), Throws.InstanceOf<NotSupportedException>());
			Assert.That(() => ms.WriteReference("X"), Throws.InstanceOf<NotSupportedException>());
			Assert.That(() => ms.WriteReference(256), Throws.InstanceOf<NotSupportedException>());
			Assert.That(() => ms.WriteReferenceObject(Guid.NewGuid()), Throws.InstanceOf<NotSupportedException>());
		}

		using (var ms = new NativeMemoryStream(10, 10, 20, FileAccess.Write))
		{
			Assert.That(ms.CanWrite, Is.True);
			Assert.That(ms.CanSeek, Is.True);
			Assert.That(ms.CanRead, Is.False);

			Assert.That(() => ms.Read<int>(), Throws.InstanceOf<NotSupportedException>());
			Assert.That(() => ms.Read(typeof(int)), Throws.InstanceOf<NotSupportedException>());
			Assert.That(() => ms.Read(new byte[3], 0, 3), Throws.InstanceOf<NotSupportedException>());
			Assert.That(ms.ReadByte, Throws.InstanceOf<NotSupportedException>());
			Assert.That(() => ms.ReadArray(typeof(byte), 1, false), Throws.InstanceOf<NotSupportedException>());
			Assert.That(() => ms.ReadReference<int>(), Throws.InstanceOf<NotSupportedException>());
			Assert.That(() => ms.ReadReference<string>(), Throws.InstanceOf<NotSupportedException>());
		}
	}

	[Test]
	public void RefStringTest()
	{
		using var ms = new NativeMemoryStream(20, 20);
		Assert.That(() => ms.WriteReference(""), Throws.Nothing);
		Assert.That(ms.Length, Is.EqualTo(2 + IntPtr.Size));
		Assert.That(ms.Position, Is.EqualTo(IntPtr.Size));
		Assert.That(ms.Capacity, Is.EqualTo(20));
		Assert.That(() => ms.WriteReference(testStr), Throws.Nothing);
		Assert.That(ms.Length, Is.EqualTo(24 + IntPtr.Size * 2));
		Assert.That(ms.Position, Is.EqualTo(IntPtr.Size * 2));
		Assert.That(() => ms.WriteReference((string?)null), Throws.Nothing);
		Assert.That(ms.Length, Is.EqualTo(24 + IntPtr.Size * 3));
		Assert.That(ms.Position, Is.EqualTo(IntPtr.Size * 3));
		var ptrs = ms.Pointer.ToArray<IntPtr>(3);
		Assert.That(ptrs, Is.EquivalentTo(new[] { IntPtr.Zero, IntPtr.Zero, IntPtr.Zero }));
		ms.Flush();
		Assert.That(ms.Capacity, Is.EqualTo((ms.Length / 20 + 1) * 20));
		ptrs = ms.Pointer.ToArray<IntPtr>(3)!;
		Assert.That(ptrs, Is.Not.EquivalentTo(new[] { IntPtr.Zero, IntPtr.Zero, IntPtr.Zero }));
		Assert.That(StringHelper.GetString(ptrs[0], ms.CharSet), Is.EqualTo(""));
		Assert.That(StringHelper.GetString(ptrs[1], ms.CharSet), Is.EqualTo(testStr));
		Assert.That(StringHelper.GetString(ptrs[2], ms.CharSet), Is.Null);

		TestContext.WriteLine(ms.Pointer.ToHexDumpString((int)ms.Length, 32));
		ms.Position = 0;

		Assert.That(ms.ReadReference<string>(), Is.EqualTo(string.Empty));
		Assert.That(ms.Position, Is.EqualTo(IntPtr.Size));
		Assert.That(ms.ReadReference<string>(), Is.EqualTo(testStr));
		Assert.That(ms.ReadReference<string>(), Is.Null);
		Assert.That(ms.Read<string>(), Is.EqualTo(string.Empty));
		Assert.That(ms.Read<string>(), Is.EqualTo(testStr));
	}

	[Test]
	public void RefStructTest()
	{
		using var ms = new NativeMemoryStream(8, 16, 100);
		Assert.That(() => ms.WriteReference(256), Throws.Nothing);
		var isz = sizeof(int);
		var pcnt = 1;
		Assert.That(ms.Length, Is.EqualTo(Len()));
		Assert.That(ms.Position, Is.EqualTo(Pos()));
		Assert.That(ms.Capacity, Is.EqualTo(24));
		Assert.That(() => ms.WriteReference((ushort)256), Throws.Nothing);
		isz += sizeof(ushort); pcnt++;
		Assert.That(ms.Length, Is.EqualTo(Len()));
		Assert.That(ms.Position, Is.EqualTo(Pos()));
		Assert.That(ms.Capacity, Is.EqualTo(24));
		Assert.That(() => ms.WriteReference((long)1), Throws.Nothing);
		isz += sizeof(long); pcnt++;
		Assert.That(ms.Length, Is.EqualTo(Len()));
		Assert.That(ms.Position, Is.EqualTo(Pos()));
		Assert.That(ms.Capacity, Is.EqualTo(40));
		Assert.That(ms.Pointer.ToArray(IntPtr.Size == 4 ? typeof(uint) : typeof(ulong), pcnt), Is.EquivalentTo(new[] { 0, 0, 0 }));
		var newGuid = Guid.NewGuid();
		Assert.That(() => ms.WriteReference(newGuid), Throws.Nothing);
		isz += Marshal.SizeOf(typeof(Guid)); pcnt++;
		Assert.That(ms.Length, Is.EqualTo(Len()));
		Assert.That(ms.Position, Is.EqualTo(Pos()));
		Assert.That(ms.Capacity, Is.EqualTo(62));
		ms.Flush();
		Assert.That(ms.Length, Is.EqualTo(ms.Position));
		Assert.That(ms.Capacity, Is.GreaterThanOrEqualTo(ms.Length));
		var arr = ms.Pointer.ToArray(IntPtr.Size == 4 ? typeof(uint) : typeof(ulong), pcnt);
		Assert.That(arr, Is.Not.EquivalentTo(new[] { 0, 0, 0, 0 }));

		ms.Position = 0;

		Assert.That(ms.ReadReference<int>(), Is.EqualTo(256));
		Assert.That(ms.ReadReference<ushort>(), Is.EqualTo(256));
		Assert.That(ms.ReadReference<long>(), Is.EqualTo(1));
		Assert.That(ms.ReadReference<Guid>(), Is.EqualTo(newGuid));

		int Len() => Pos() + isz;
		int Pos() => pcnt * IntPtr.Size;
	}

	[Test()]
	public void SeekTest()
	{
		using var m = new SafeHGlobalHandle(1000);
		using var ms = new NativeMemoryStream((IntPtr)m, m.Size);
		Assert.That(ms.Seek(20, SeekOrigin.Begin), Is.EqualTo(20));
		Assert.That(ms.Seek(20, SeekOrigin.Current), Is.EqualTo(40));
		Assert.That(ms.Seek(-100, SeekOrigin.End), Is.EqualTo(900));
		Assert.That(() => ms.Seek(-1, SeekOrigin.Begin), Throws.ArgumentException);
		Assert.That(() => ms.Seek(1, SeekOrigin.End), Throws.ArgumentException);
	}

	[Test()]
	public void SetLengthTest()
	{
		using var m = new SafeHGlobalHandle(1000);
		using var ms = new NativeMemoryStream((IntPtr)m, m.Size);
		Assert.That(() => ms.SetLength(-1), Throws.TypeOf<ArgumentOutOfRangeException>());
		Assert.That(() => ms.SetLength(1001), Throws.Exception);
		Assert.That(() => ms.SetLength(100), Throws.Nothing);
	}

	[Test]
	public void StringEnumTest()
	{
		var abc = new[] { "A", "B", "C" };
		string?[] a_c = new[] { "A", null, "C" };
		using var ms = new NativeMemoryStream(128, 128);
		Assert.That(() => ms.Write(null, StringListPackMethod.Concatenated), Throws.Nothing);

		Assert.That(() => ms.Write(abc, StringListPackMethod.Concatenated), Throws.Nothing);
		var len = 14;
		var pos = len;
		Assert.That(len, Is.EqualTo(ms.Length).And.EqualTo(ms.Position));
		Assert.That(() => ms.Write(abc, StringListPackMethod.Packed), Throws.Nothing);
		Assert.That(len += 12 + IntPtr.Size * 3, Is.EqualTo(ms.Length));
		Assert.That(pos += IntPtr.Size * 3, Is.EqualTo(ms.Position));
		Assert.That(ms.Capacity, Is.EqualTo(128));
		Assert.That(() => ms.Write(a_c, StringListPackMethod.Concatenated), Throws.Exception);
		Assert.That(() => ms.Write(a_c, StringListPackMethod.Packed), Throws.Nothing);
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

		ms.Position = 0;

		Assert.That(ms.ReadArray(typeof(string), abc.Length, false), Is.EquivalentTo(abc));
		Assert.That(ms.ReadArray(typeof(string), abc.Length, true), Is.EquivalentTo(abc));
		Assert.That(ms.ReadArray(typeof(string), a_c.Length, true), Is.EquivalentTo(a_c));
		Assert.That(ms.ReadArray<string>(l.Count, false), Is.EquivalentTo(l));
		Assert.That(ms.ReadArray<string>(l.Count, true), Is.EquivalentTo(l));

		l.Clear();
	}

	[Test]
	public void StringTest()
	{
		using var ms = new NativeMemoryStream(20) { CharSet = CharSet.Unicode };
		Assert.That(() => ms.Write(""), Throws.Nothing);
		Assert.That(ms.Length, Is.EqualTo(2));
		Assert.That(ms.Position, Is.EqualTo(2));
		Assert.That(ms.Capacity, Is.EqualTo(20));
		Assert.That(() => ms.Write(testStr), Throws.Nothing);
		Assert.That(ms.Length, Is.EqualTo(24));
		Assert.That(ms.Position, Is.EqualTo(24));
		Assert.That(ms.Capacity, Is.GreaterThan(20));

		ms.Flush();
		ms.Position = 0;

		Assert.That(ms.Read<string>(), Is.EqualTo(string.Empty));
		Assert.That(ms.Position, Is.EqualTo(StringHelper.GetCharSize(ms.CharSet)));
		Assert.That(ms.Read<string>(), Is.EqualTo(testStr));
	}

	[Test]
	public void StructEnumTest()
	{
		using var ms = new NativeMemoryStream(48, 16);
		var arr = new[] { 1L, 2L, 3L, 4L, 5L, 6L };
		Assert.That(() => ms.Write(arr), Throws.Nothing);
		var sz = sizeof(long) * arr.Length;
		Assert.That(ms.Length, Is.EqualTo(sz));
		Assert.That(ms.Position, Is.EqualTo(sz));
		Assert.That(ms.Capacity, Is.EqualTo(48));

		var list = new List<int> { 1, 2, 3 };
		Assert.That(() => ms.Write(list), Throws.Nothing);
		sz += sizeof(int) * list.Count;
		Assert.That(ms.Length, Is.EqualTo(sz));
		Assert.That(ms.Position, Is.EqualTo(sz));
		Assert.That(ms.Capacity, Is.EqualTo(64));

		var pos = ms.Position;
		Assert.That(() => ms.Write(arr, true), Throws.Nothing);
		sz += (sizeof(long) + IntPtr.Size) * arr.Length;
		pos += IntPtr.Size * arr.Length;
		Assert.That(ms.Length, Is.EqualTo(sz));
		Assert.That(ms.Position, Is.EqualTo(pos));
		Assert.That(ms.Capacity, Is.EqualTo(160));

		Assert.That(() => ms.Write(list, true), Throws.Nothing);
		sz += (sizeof(int) + IntPtr.Size) * list.Count;
		pos += IntPtr.Size * list.Count;
		Assert.That(ms.Length, Is.EqualTo(sz));
		Assert.That(ms.Position, Is.EqualTo(pos));
		Assert.That(ms.Capacity, Is.EqualTo(192));

		ms.Flush();
		ms.Position = 0;

		Assert.That(() => ms.ReadArray(null, 0, false), Throws.ArgumentNullException);
		Assert.That(() => ms.ReadArray(typeof(int), -1, false), Throws.InstanceOf<ArgumentOutOfRangeException>());
		Assert.That(() => ms.ReadArray(typeof(int), 0, false), Throws.Nothing);
		Assert.That(ms.ReadArray(typeof(int), 0, false)!.Length, Is.Zero);
		Assert.That(() => ms.ReadArray(typeof(Guid), 100, false), Throws.InstanceOf<ArgumentOutOfRangeException>());

		Assert.That(ms.ReadArray(typeof(long), arr.Length, false), Is.EquivalentTo(arr));
		Assert.That(ms.ReadArray<int>(list.Count, false), Is.EquivalentTo(list));
		Assert.That(ms.ReadArray<long>(arr.Length, true), Is.EquivalentTo(arr));
		Assert.That(ms.ReadArray(typeof(int), list.Count, true), Is.EquivalentTo(list));
	}

	[Test]
	public void StructTest()
	{
		using var ms = new NativeMemoryStream(8, 16, 48);
		Assert.That(() => ms.Write(256), Throws.Nothing);
		var isz = sizeof(int);
		Assert.That(ms.Length, Is.EqualTo(Len()));
		Assert.That(ms.Position, Is.EqualTo(Pos()));
		Assert.That(ms.Capacity, Is.EqualTo(8));
		Assert.That(() => ms.Write((ushort)256), Throws.Nothing);
		isz += sizeof(ushort);
		Assert.That(ms.Length, Is.EqualTo(Len()));
		Assert.That(ms.Position, Is.EqualTo(Pos()));
		Assert.That(ms.Capacity, Is.EqualTo(8));
		Assert.That(() => ms.Write((long)1), Throws.Nothing);
		isz += sizeof(long);
		Assert.That(ms.Length, Is.EqualTo(Len()));
		Assert.That(ms.Position, Is.EqualTo(Pos()));
		Assert.That(ms.Capacity, Is.EqualTo(24));
		var newGuid = Guid.NewGuid();
		Assert.That(() => ms.Write(newGuid), Throws.Nothing);
		isz += Marshal.SizeOf(typeof(Guid));
		Assert.That(ms.Length, Is.EqualTo(Len()));
		Assert.That(ms.Position, Is.EqualTo(Pos()));
		Assert.That(ms.Capacity, Is.EqualTo(40));

		Assert.That(ms.Length, Is.EqualTo(ms.Position));
		Assert.That(ms.Capacity, Is.GreaterThanOrEqualTo(ms.Length));

		Assert.That(() => ms.Write(new Unblittable()), Throws.Exception);

		TestContext.WriteLine(ms.Pointer.ToHexDumpString((int)ms.Length, 32));
		ms.Position = 0;

		Assert.That(() => ms.Read(null), Throws.ArgumentNullException);

		Assert.That(ms.Read<int>(), Is.EqualTo(256));
		Assert.That(ms.Read<ushort>(), Is.EqualTo(256));
		Assert.That(ms.Read<long>(), Is.EqualTo(1));
		Assert.That(ms.Read<Guid>(), Is.EqualTo(newGuid));

		int Len() => isz;
		int Pos() => isz;
	}

#pragma warning disable CS0649
	private struct Unblittable
	{
		public DateTime dt;
		public Guid g;

		[MarshalAs(UnmanagedType.LPStruct)]
		public Guid s;
	}
#pragma warning restore CS0649
}