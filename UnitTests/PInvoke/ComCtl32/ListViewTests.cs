using NUnit.Framework;
using static Vanara.PInvoke.ComCtl32;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class ListViewTests
{
	[Test]
	public void TestLVGROUP()
	{
		LVGROUP grp = new() { Header = "Grp1", Alignment = ListViewGroupAlignment.LVGA_HEADER_CENTER, Subtitle = "Sub1" };
		Assert.AreEqual(grp.mask, ListViewGroupMask.LVGF_HEADER | ListViewGroupMask.LVGF_ALIGN | ListViewGroupMask.LVGF_SUBTITLE);
		InteropExtensions.SizeOf(grp).WriteValues();
		LVINSERTGROUPSORTED insert = new() { lvGroup = grp };
		Assert.DoesNotThrow(() => new SafeCoTaskMemStruct<LVINSERTGROUPSORTED>(insert));
		InteropExtensions.SizeOf(insert).WriteValues();
	}
}
