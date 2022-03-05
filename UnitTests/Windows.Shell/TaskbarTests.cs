using NUnit.Framework;
using Vanara.PInvoke;
using Vanara.PInvoke.Tests;

namespace Vanara.Windows.Shell.Tests
{
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
	}
}