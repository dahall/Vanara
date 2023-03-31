using NUnit.Framework;
using System.Runtime.InteropServices;
using static Vanara.PInvoke.Lz32;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class Lz32Tests
{
	[Test]
	public void Test()
	{
		OFSTRUCT openStruct = new() { cBytes = (byte)Marshal.SizeOf(typeof(OFSTRUCT)) };
		var hSrc = LZOpenFile(@"C:\Windows\IME\IMETC\HELP\IMTCEN14.CHM", ref openStruct, LZ_OF.OF_READ);
		Assert.That((int)hSrc, Is.GreaterThanOrEqualTo(0));
		openStruct.WriteValues();
		LZClose(hSrc);
	}
}