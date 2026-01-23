using NUnit.Framework;
using System.Buffers;
using Vanara.PInvoke;

namespace Vanara.InteropServices.Tests;

public class SafeCoTaskStruct<T> : SafeMemStruct<T, CoTaskMemoryMethods> where T : struct
{
	public SafeCoTaskStruct(SizeT capacity = default) : base(capacity) { }
	public SafeCoTaskStruct(in T value, SizeT capacity = default) : base(value, capacity) { }
}

[TestFixture]
public class SafeMemStructTests
{
	[Test]
	public void AsRefTest()
	{
		var immutVal = new FILETIME { dwHighDateTime = 0x2000000, dwLowDateTime = 0x33333333 };
		var s = new SafeCoTaskStruct<FILETIME>(immutVal);
		var bytes = s.DangerousGetHandle().ToByteArray(8)!;
		Assert.That(BitConverter.ToUInt32(bytes, 4), Is.EqualTo(immutVal.dwHighDateTime));

		ref FILETIME r = ref s.AsRef();
		Assert.That(r.dwHighDateTime, Is.EqualTo(immutVal.dwHighDateTime));
		r.dwHighDateTime = 0;

		bytes = s.DangerousGetHandle().ToByteArray(8)!;
		Assert.That(BitConverter.ToUInt32(bytes, 4), Is.Zero);

		var newhVal = 0x22222222U;
		s.DangerousGetHandle().Write(newhVal, 4, 8);
		Assert.That(r.dwHighDateTime, Is.EqualTo(newhVal));
	}

	[Test]
	public void AsSpanTest()
	{
		var immutVal = new FILETIME { dwHighDateTime = 0x2000000, dwLowDateTime = 0x33333333 };
		var s = new SafeCoTaskStruct<FILETIME>(immutVal);
		var bytes = s.DangerousGetHandle().ToByteArray(8)!;
		Assert.That(BitConverter.ToUInt32(bytes, 4), Is.EqualTo(immutVal.dwHighDateTime));

		var sp = s.AsSpan();
		sp.Fill(default);
		bytes = s.DangerousGetHandle().ToByteArray(8)!;
		Assert.That(BitConverter.ToUInt32(bytes, 4), Is.Zero);

		var bsp = MemoryMarshal.AsBytes(sp);
		Assert.That(bsp.Length, Is.EqualTo((int)s.Size));
		bsp[4] = 2;
		Assert.That(s.ToType<FILETIME>().dwHighDateTime, Is.EqualTo(2));
	}
}