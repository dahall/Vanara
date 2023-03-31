using NUnit.Framework;
using Vanara.PInvoke;
using Vanara.PInvoke.Tests;

namespace Vanara.Windows.Shell.Tests;

[TestFixture]
public class TaskbarTests
{
	[Test]
	public void TaskbarTest()
	{
		Assert.That(TaskBar.Taskbar.Handle, ResultIs.ValidHandle);
		Assert.That(TaskBar.Taskbar.Bounds, Is.Not.EqualTo(RECT.Empty));
		Assert.That(() => TaskBar.Taskbar.AutoHide, Throws.Nothing);

		TestContext.Write($"{TaskBar.Taskbar.Bounds}; {TaskBar.Taskbar.AutoHide}; {TaskBar.Taskbar.Edge}");
	}

	[Test]
	public void TrayTest()
	{
		Assert.That(TaskBar.Taskbar.TrayIcons, Is.Not.Empty);
		TaskBar.Taskbar.TrayIcons.WriteValues();
	}

	[Test]
	public void StructTest()
	{
		TestHelper.GetNestedStructSizes(typeof(ComCtl32), "TB", "NMTB", "TOOLBAR").WriteValues();
	}
}