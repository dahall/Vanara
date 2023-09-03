using NUnit.Framework;
using System.IO;
using Vanara.PInvoke;

namespace Vanara.Extensions.Tests;

[TestFixture()]
public class IOExtensionsTests
{
	[Test()]
	public void WriteTest()
	{
		using var ms = new MemoryStream();
		var bw = new BinaryWriter(ms);
		bw.Write(257);
		bw.Write(new RECT(1, 1, 1, 1));
		bw.Write(new PRECT(1, 1, 1, 1));
		bw.Write<string?>(null);
		Assert.That(() => bw.Write(DateTime.Today), Throws.ArgumentException);
		var buf = ms.ToArray();
		Assert.That(buf.Length == Marshal.SizeOf(typeof(int)) + Marshal.SizeOf(typeof(RECT)) + Marshal.SizeOf(typeof(PRECT)));
		Assert.That(buf[0] == 1 && buf[1] == 1 && buf[4] == 1);
	}

	[Test()]
	public void ReadTest()
	{
		using var ms = new MemoryStream(new byte[] { 1, 1, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0 });
		var br = new BinaryReader(ms);
		Assert.That(() => br.Read<DateTime>(), Throws.ArgumentException);
		Assert.That(br.Read<int>() == 257);
		Assert.That(br.Read<RECT>() == new RECT(1, 1, 1, 1));
	}
}