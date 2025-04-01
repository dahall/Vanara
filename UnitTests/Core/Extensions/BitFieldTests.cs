using NUnit.Framework;

namespace Vanara.Extensions.Tests;

[TestFixture]
public class BitFieldTests
{
	[Test]
	public void BitFieldBoolTest()
	{
		const uint val = 0x12345678;
		var bf = new BitField<uint>(val); // 0001 0010 0011 0100 0101 0110 0111 1000
		for (var i = 0; i < 32; i++)
		{
			Assert.That(bf[i], Is.EqualTo((val & (1u << i)) != 0));
			TestContext.Write(bf[i] ? 1 : 0);
		}
	}

	[Test]
	public void BitFieldSetTest()
	{
		var bf = new BitField<uint>(0xFFFFFFFF);
		bf[0] = false;
		Assert.That((uint)bf, Is.EqualTo(0xFFFFFFFE));
		bf[31] = false;
		Assert.That((uint)bf, Is.EqualTo(0x7FFFFFFE));
		bf[0] = true;
		Assert.That((uint)bf, Is.EqualTo(0x7FFFFFFF));
	}

	[Test]
	public void BitFieldRangeTest()
	{
		var bf = new BitField<uint>(0x12345678);
		Assert.That(bf[0..3], Is.EqualTo(0x8));
		Assert.That(bf[4..7], Is.EqualTo(0x7));
		Assert.That(bf[8..11], Is.EqualTo(0x6));
		Assert.That(bf[12..15], Is.EqualTo(0x5));
		Assert.That(bf[16..19], Is.EqualTo(0x4));
		Assert.That(bf[20..23], Is.EqualTo(0x3));
		Assert.That(bf[24..27], Is.EqualTo(0x2));
		Assert.That(bf[28..31], Is.EqualTo(0x1));
	}

	[Test]
	public void BitFieldSetRangeTest()
	{
		var bf = new BitField<uint>(0x12345678);
		bf[0..3] = 0x1;
		bf[4..7] = 0x2;
		bf[8..11] = 0x3;
		bf[12..15] = 0x4;
		bf[16..19] = 0x5;
		bf[20..23] = 0x6;
		bf[24..27] = 0x7;
		bf[28..31] = 0x8;
		Assert.That((uint)bf, Is.EqualTo(0x87654321));
	}
}