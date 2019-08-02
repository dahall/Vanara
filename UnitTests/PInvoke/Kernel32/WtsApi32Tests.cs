using NUnit.Framework;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests
{
	[TestFixture]
	public partial class WtsApi32Tests
	{
		[Test]
		public void WTSGetActiveConsoleSessionIdTest()
		{
			Assert.That(WTSGetActiveConsoleSessionId(), ResultIs.Not.Value(uint.MaxValue));
		}
	}
}