using NUnit.Framework;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using static Vanara.PInvoke.DwmApi;

namespace Vanara.PInvoke.Tests;

[TestFixture()]
public class DwmApiTests
{
	[Test()]
	public void DwmEnableBlurBehindWindowTest()
	{
		var wnd = new Form { Size = new Size(50, 50), TopMost = true, ControlBox = false, FormBorderStyle = FormBorderStyle.None };
		wnd.Show();
		Thread.Sleep(1000);
		var bb = new DWM_BLURBEHIND(true);
		var err = DwmEnableBlurBehindWindow(wnd.Handle, bb);
		Assert.That(err.Succeeded);
		Thread.Sleep(1000);
		using (var g = wnd.CreateGraphics())
		using (var hrgn = Gdi32.CreateRectRgnIndirect(new RECT(0, 0, 20, 20)))
		{
			bb.hRgnBlur = hrgn;
			bb.dwFlags |= DWM_BLURBEHIND_Mask.DWM_BB_BLURREGION;
			err = DwmEnableBlurBehindWindow(wnd.Handle, bb);
			Assert.That(err.Succeeded);
			Thread.Sleep(1000);
		}
		var bb2 = new DWM_BLURBEHIND(false);
		err = DwmEnableBlurBehindWindow(wnd.Handle, bb2);
		Assert.That(err.Succeeded);
		Thread.Sleep(1000);
		wnd.Hide();
	}

	[Test()]
	public void DwmEnableCompositionTest()
	{
		var err = DwmEnableComposition(true);
		Assert.That(err.Succeeded);
		Assert.That(DwmIsCompositionEnabled(out var b).Succeeded);
		Assert.That(b);
	}

	[Test()]
	public void DwmExtendFrameIntoClientAreaTest()
	{
		var wnd = new Form { Size = new Size(50, 50), TopMost = true, ControlBox = false, FormBorderStyle = FormBorderStyle.None };
		wnd.Show();
		Thread.Sleep(1000);
		var margins = new MARGINS(10);
		var err = DwmExtendFrameIntoClientArea(wnd.Handle, margins);
		Assert.That(err.Succeeded);
		wnd.Hide();
	}

	[Test()]
	public void DwmGetColorizationParametersTest()
	{
		var err = DwmpGetColorizationParameters(out var p);
		Assert.That(err.Succeeded);
		TestContext.WriteLine($"Colorization: Color={p.clrColor:X}, AfterGlow={p.clrAfterGlow:X}, AGBalance={p.clrAfterGlowBalance:X}, BlurBal={p.clrBlurBalance:X}, Intensity={p.nIntensity}, GlassReflInt={p.clrGlassReflectionIntensity}, Opaque={p.fOpaque}");
	}

	[Test()]
	public void DwmGetWindowAttributeTest()
	{
		var wnd = new Form { Size = new Size(50, 50), TopMost = true, ControlBox = false, FormBorderStyle = FormBorderStyle.None };
		wnd.Show();
		var err = DwmGetWindowAttribute(wnd.Handle, DWMWINDOWATTRIBUTE.DWMWA_CAPTION_BUTTON_BOUNDS, out RECT r2);
		if (err.Failed) TestContext.WriteLine($"Err:DWMWA_CAPTION_BUTTON_BOUNDS={err}");
		Assert.That(err.Succeeded);
		err = DwmGetWindowAttribute(wnd.Handle, DWMWINDOWATTRIBUTE.DWMWA_NCRENDERING_ENABLED, out bool b2);
		if (err.Failed) TestContext.WriteLine($"Err:DWMWA_NCRENDERING_ENABLE={err}");
		Assert.That(err.Succeeded);
		err = DwmGetWindowAttribute(wnd.Handle, DWMWINDOWATTRIBUTE.DWMWA_CLOAKED, out DWM_CLOAKED i2);
		if (err.Failed) TestContext.WriteLine($"Err:DWMWA_NCRENDERING_POLICY={err}");
		Assert.That(err.Succeeded);
		wnd.Hide();
	}

	[Test()]
	public void DwmSetColorizationParametersTest()
	{
		var err = DwmpGetColorizationParameters(out var p);
		Assert.That(err.Succeeded);
		err = DwmpSetColorizationParameters(p, 0);
		Assert.That(err.Succeeded);
	}

	[Test()]
	public void DwmSetWindowAttributeTest()
	{
		var wnd = new Form { Size = new Size(50, 50), TopMost = true, ControlBox = false, FormBorderStyle = FormBorderStyle.None };
		wnd.Show();
		var err = DwmSetWindowAttribute(wnd.Handle, DWMWINDOWATTRIBUTE.DWMWA_CLOAK, true);
		if (err.Failed) TestContext.WriteLine($"Err:DWMWA_CLOAK={err}");
		Assert.That(err.Succeeded);
		err = DwmSetWindowAttribute(wnd.Handle, DWMWINDOWATTRIBUTE.DWMWA_NCRENDERING_POLICY, DWMNCRENDERINGPOLICY.DWMNCRP_USEWINDOWSTYLE);
		if (err.Failed) TestContext.WriteLine($"Err:DWMWA_NCRENDERING_POLICY={err}");
		Assert.That(err.Succeeded);
		wnd.Hide();
	}
}