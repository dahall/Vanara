using NUnit.Framework;
using Vanara.InteropServices;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests
{
	[TestFixture]
	public partial class WinNTTests
	{
		[Test]
		public void RtlMoveMemoryTest()
		{
			var strings = new[] { "One", "Two", "Three" };
			using (var src = SafeHGlobalHandle.CreateFromStringList(strings))
			using (var dest = new SafeHGlobalHandle(src.Size))
			{
				Assert.That(() => RtlZeroMemory(dest, dest.Size), Throws.Nothing);
				Assert.That(() => RtlMoveMemory(dest, src, src.Size), Throws.Nothing);
				Assert.That(dest.ToStringEnum(), Is.EquivalentTo(strings));
			}
		}
	}
}