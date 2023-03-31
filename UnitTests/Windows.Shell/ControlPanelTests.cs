using NUnit.Framework;
using System;
using System.Runtime.InteropServices;
using System.Text;
using Vanara.InteropServices;
using Vanara.PInvoke;
using static Vanara.PInvoke.Shell32;

namespace Vanara.Windows.Shell.Tests;

[TestFixture]
public class ControlPanelTests
{
	[Test]
	public void ControlPanelOpenTest()
	{
		const int sz = 128;
		var cp = new IOpenControlPanel();
		var sb = new StringBuilder(sz, sz);
		//var mem = new SafeCoTaskMemString("Microsoft.Display", CharSet.Unicode);
		cp.GetPath(null, sb, sz);
		Assert.That(sb.Length, Is.GreaterThan(0));
		cp = null;
		//Assert.That(ControlPanel.Open(), Is.True);
		//Assert.That(ControlPanel.Open(ControlPanelItem.BitLockerDriveEncryption), Is.True);
		//Assert.That(ControlPanel.Open((ControlPanelItem)0xFFFF), Is.False);
		//Assert.That(ControlPanel.Open(ControlPanelItem.DefaultPrograms, "pageFileAssoc"), Is.True);
		//Assert.That(ControlPanel.Open(ControlPanelItem.DefaultPrograms, "XX"), Is.False);
		//Assert.That(ControlPanel.Open(ControlPanelItem.AutoPlay), Is.True);
		//Assert.That(() => ControlPanel.IsClassicView, Throws.Nothing);
		//Assert.That(() => ControlPanel.GetPath(null), Throws.Nothing);
		//bool found = false;
		//foreach (ControlPanelItem cpi in System.Enum.GetValues(typeof(ControlPanelItem)))
		//	try { TestContext.WriteLine($"{cpi} = {ControlPanel.GetPath(cpi)}"); found = true; }
		//	catch { }
		//Assert.That(found);
		//Assert.That(() => ControlPanel.GetPath(ControlPanelItem.DefaultPrograms), Throws.Nothing);
		//Assert.That(() => ControlPanel.GetPath(ControlPanelItem.AutoPlay), Throws.Nothing);
	}
}