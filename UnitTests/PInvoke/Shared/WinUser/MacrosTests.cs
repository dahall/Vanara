using NUnit.Framework;
using static Vanara.PInvoke.Macros;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class WinUserTests
{
	[TestCase(0x0000U, ExpectedResult = 0x00)]
	[TestCase(0x000fU, ExpectedResult = 0x00)]
	[TestCase(0x00ffU, ExpectedResult = 0x00)]
	[TestCase(0x0fffU, ExpectedResult = 0x0f)]
	[TestCase(0xffffU, ExpectedResult = 0xff)]
	public byte HIBYTETest(uint value) => HIBYTE((ushort)value);

	[TestCase(0x00000000U, ExpectedResult = 0x0000)]
	[TestCase(0x000000ffU, ExpectedResult = 0x0000)]
	[TestCase(0x0000ffffU, ExpectedResult = 0x0000)]
	[TestCase(0x00ffff00U, ExpectedResult = 0x00ff)]
	[TestCase(0xffff0000U, ExpectedResult = 0xffff)]
	[TestCase(0xffffffffU, ExpectedResult = 0xffff)]
	public ushort HIWORDTest(uint value) => HIWORD(value);

	[TestCase(0x00000000U, ExpectedResult = 0x0000)]
	[TestCase(0x000000ffU, ExpectedResult = 0x0000)]
	[TestCase(0x0000ffffU, ExpectedResult = 0x0000)]
	[TestCase(0x00ffff00U, ExpectedResult = 0x00ff)]
	[TestCase(0xffff0000U, ExpectedResult = 0xffff)]
	[TestCase(0xffffffffU, ExpectedResult = 0xffff)]
	public ushort HIWORDupTest(uint value) => HIWORD(new UIntPtr(value));

	[TestCase(0x00000000, ExpectedResult = 0x0000)]
	[TestCase(0x000000ff, ExpectedResult = 0x0000)]
	[TestCase(0x0000ffff, ExpectedResult = 0x0000)]
	[TestCase(0x00ffff00, ExpectedResult = 0x00ff)]
	[TestCase(0x1fff0000, ExpectedResult = 0x1fff)]
	[TestCase(0x1fffffff, ExpectedResult = 0x1fff)]
	public ushort HIWORDipTest(int value) => HIWORD(new IntPtr(value));

	[TestCase(0x00000000, ExpectedResult = true)]
	[TestCase(0x00000001, ExpectedResult = true)]
	[TestCase(0x000000ff, ExpectedResult = true)]
	[TestCase(0x0000ffff, ExpectedResult = true)]
	[TestCase(0x00010000, ExpectedResult = false)]
	[TestCase(0x0001ffff, ExpectedResult = false)]
	[TestCase(0x7fff0000, ExpectedResult = false)]
	[TestCase(0x7fffff00, ExpectedResult = false)]
	public bool IsIntResourceTest(long i) => IS_INTRESOURCE((IntPtr)i);

	[TestCase(0x0000U, ExpectedResult = 0x00)]
	[TestCase(0x000fU, ExpectedResult = 0x0f)]
	[TestCase(0x00ffU, ExpectedResult = 0xff)]
	[TestCase(0x0fffU, ExpectedResult = 0xff)]
	[TestCase(0xffffU, ExpectedResult = 0xff)]
	public byte LOBYTETest(uint value) => LOBYTE((ushort)value);

	[TestCase(0x00000000U, ExpectedResult = 0x0000)]
	[TestCase(0x000000ffU, ExpectedResult = 0x00ff)]
	[TestCase(0x0000ffffU, ExpectedResult = 0xffff)]
	[TestCase(0x00ffff00U, ExpectedResult = 0xff00)]
	[TestCase(0xffff0000U, ExpectedResult = 0x0000)]
	[TestCase(0xffffffffU, ExpectedResult = 0xffff)]
	public ushort LOWORDTest(uint value) => LOWORD(value);

	[TestCase(0x00000000U, ExpectedResult = 0x0000)]
	[TestCase(0x000000ffU, ExpectedResult = 0x00ff)]
	[TestCase(0x0000ffffU, ExpectedResult = 0xffff)]
	[TestCase(0x00ffff00U, ExpectedResult = 0xff00)]
	[TestCase(0xffff0000U, ExpectedResult = 0x0000)]
	[TestCase(0xffffffffU, ExpectedResult = 0xffff)]
	public ushort LOWORDupTest(uint value) => LOWORD(new UIntPtr(value));

	[TestCase(0x00000000, ExpectedResult = 0x0000)]
	[TestCase(0x000000ff, ExpectedResult = 0x00ff)]
	[TestCase(0x0000ffff, ExpectedResult = 0xffff)]
	[TestCase(0x00ffff00, ExpectedResult = 0xff00)]
	[TestCase(0x1fff0000, ExpectedResult = 0x0000)]
	[TestCase(0x1fffffff, ExpectedResult = 0xffff)]
	public ushort LOWORDpTest(int value) => LOWORD(new IntPtr(value));

	[TestCase(1, ExpectedResult = "#1")]
	[TestCase(12, ExpectedResult = "#12")]
	public string MAKEINTRESOURCETest(int id) => MAKEINTRESOURCE(id).ToString();

	[TestCase(0)]
	[TestCase(-1)]
	public void MAKEINTRESOURCE1Test(int id) => Assert.That(() => MAKEINTRESOURCE(id), Throws.Exception);

	[TestCase(ushort.MinValue, ushort.MinValue, ExpectedResult = uint.MinValue)]
	[TestCase(ushort.MinValue, ushort.MaxValue, ExpectedResult = 0xffff0000U)]
	[TestCase(ushort.MaxValue, ushort.MinValue, ExpectedResult = 0x0000ffffU)]
	[TestCase(ushort.MaxValue, ushort.MaxValue, ExpectedResult = uint.MaxValue)]
	public uint MAKELONGTest(uint l, uint h) => MAKELONG((ushort)l, (ushort)h);

	[TestCase(uint.MinValue, uint.MinValue, ExpectedResult = ulong.MinValue)]
	[TestCase(uint.MinValue, uint.MaxValue, ExpectedResult = 0xffffffff00000000U)]
	[TestCase(uint.MaxValue, uint.MinValue, ExpectedResult = 0x00000000ffffffffU)]
	[TestCase(uint.MaxValue, uint.MaxValue, ExpectedResult = ulong.MaxValue)]
	public ulong MAKELONG64Test(uint l, uint h) => MAKELONG64(l, h);

	[TestCase(ushort.MinValue, ushort.MinValue, ExpectedResult = uint.MinValue)]
	//[TestCase(ushort.MinValue, ushort.MaxValue, ExpectedResult = 0xffff0000U)]
	[TestCase(ushort.MaxValue, ushort.MinValue, ExpectedResult = 0x0000ffffU)]
	//[TestCase(ushort.MaxValue, ushort.MaxValue, ExpectedResult = uint.MaxValue)]
	public long MAKELPARAMTest(uint l, uint h) => MAKELPARAM((ushort)l, (ushort)h).ToInt64();

	[TestCase(byte.MinValue, byte.MinValue, ExpectedResult = ushort.MinValue)]
	[TestCase(byte.MinValue, byte.MaxValue, ExpectedResult = 0xff00U)]
	[TestCase(byte.MaxValue, byte.MinValue, ExpectedResult = 0x00ffU)]
	[TestCase(byte.MaxValue, byte.MaxValue, ExpectedResult = ushort.MaxValue)]
	public ushort MAKEWORDTest(uint l, uint h) => MAKEWORD((byte)l, (byte)h);

	[TestCase(int.MinValue, ExpectedResult = short.MinValue)]
	[TestCase(0x000000ff, ExpectedResult = 0x0000)]
	[TestCase(0x0000ffff, ExpectedResult = 0x0000)]
	[TestCase(0x00ffff00, ExpectedResult = 0x00ff)]
	[TestCase(0x00000000, ExpectedResult = 0x0000)]
	[TestCase(int.MaxValue, ExpectedResult = short.MaxValue)]
	public short SignedHIWORDTest(int value) => SignedHIWORD(value);

	[TestCase(int.MinValue, ExpectedResult = short.MinValue)]
	[TestCase(0x000000ff, ExpectedResult = 0x0000)]
	[TestCase(0x0000ffff, ExpectedResult = 0x0000)]
	[TestCase(0x00ffff00, ExpectedResult = 0x00ff)]
	[TestCase(0x00000000, ExpectedResult = 0x0000)]
	[TestCase(int.MaxValue, ExpectedResult = short.MaxValue)]
	public short SignedHIWORDpTest(int value) => SignedHIWORD(new IntPtr(value));

	[TestCase(int.MinValue, ExpectedResult = 0x0000)]
	[TestCase(0x000000ff, ExpectedResult = 0x00ff)]
	[TestCase(0x0000ffff, ExpectedResult = -1)]
	[TestCase(0x00ffff00, ExpectedResult = -256)]
	[TestCase(0x00000000, ExpectedResult = 0x0000)]
	[TestCase(int.MaxValue, ExpectedResult = -1)]
	public short SignedLOWORDTest(int value) => SignedLOWORD(value);

	[TestCase(int.MinValue, ExpectedResult = 0x0000)]
	[TestCase(0x000000ff, ExpectedResult = 0x00ff)]
	[TestCase(0x0000ffff, ExpectedResult = -1)]
	[TestCase(0x00ffff00, ExpectedResult = -256)]
	[TestCase(0x00000000, ExpectedResult = 0x0000)]
	[TestCase(int.MaxValue, ExpectedResult = -1)]
	public short SignedLOWORDpTest(int value) => SignedLOWORD(new IntPtr(value));
}