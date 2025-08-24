using NUnit.Framework;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public partial class WinNTTests
{
	[Test]
	public void RtlMoveMemoryTest()
	{
		string[] strings = ["One", "Two", "Three"];
		using SafeHGlobalHandle src = SafeHGlobalHandle.CreateFromStringList(strings);
		using SafeHGlobalHandle dest = new(src.Size);
		Assert.That(() => RtlZeroMemory(dest, dest.Size), Throws.Nothing);
		Assert.That(() => RtlMoveMemory(dest, src, src.Size), Throws.Nothing);
		Assert.That(dest.ToStringEnum(), Is.EquivalentTo(strings));
	}
}