using NUnit.Framework;
using System.Drawing;
using Vanara.InteropServices;

namespace Vanara.PInvoke.Tests;

[TestFixture()]
public class SIZETests
{
	[Test()]
	public void SIZETest()
	{
		using (var h = SafeHGlobalHandle.CreateFromStructure(new SIZE(1, 2)))
		{
			var sz = h.ToStructure<SIZE>();
			Assert.That(sz.cx == 1);
			Assert.That(sz.cy == 2);
			Size ms = sz;
			Assert.That(ms, Is.EqualTo(new Size(1,2)));
			SIZE sz2 = ms;
			Assert.That(sz2, Is.EqualTo(sz));
		}
	}

	[TestCase(1, 1, 2, 2, false)]
	[TestCase(1, 1, 1, 1, true)]
	[TestCase(0, 0, 0, 0, true)]
	[TestCase(-1, -1, -1, -1, true)]
	[TestCase(-1, -1, 1, 1, false)]
	public void SIZEEqualityTest(int cx1, int cy1, int cx2, int cy2, bool eq)
	{
		var sz1 = new SIZE(cx1, cy1);
		var sz2 = new SIZE(cx2, cy2);
		Assert.That(sz1 == sz2, Is.EqualTo(eq));
		Assert.That(sz1 != sz2, Is.Not.EqualTo(eq));
		Assert.That(sz1.Equals(sz2), Is.EqualTo(eq));
		var size2 = new Size(cx2, cy2);
		Assert.That(sz1.Equals(size2), Is.EqualTo(eq));
		Assert.That(sz1.Equals((object)sz2), Is.EqualTo(eq));
		Assert.That(sz1.Equals((object)size2), Is.EqualTo(eq));
		Assert.That(sz1.Equals(cy2), Is.False);

		Assert.That(sz2.ToSize(), Is.EqualTo(size2));
		Assert.That(sz2.GetHashCode(), Is.EqualTo(new SIZE(cx2, cy2).GetHashCode()));
		Assert.That(sz1.IsEmpty, Is.EqualTo(cx1 == 0 && cy1 == 0));
		Assert.That(sz1.ToString(), Is.EqualTo($"{{cx={sz1.cx}, cy={sz1.cy}}}"));
	}
}