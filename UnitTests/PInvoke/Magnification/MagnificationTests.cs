using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Diagnostics;
using static Vanara.PInvoke.Magnification;
using static Vanara.PInvoke.User32;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class MagnificationTests
{
	static readonly MAGCOLOREFFECT grayeff = new(new[,] {
			{ 0.3f,  0.3f,  0.3f,  0.0f,  0.0f },
			{ 0.6f,  0.6f,  0.6f,  0.0f,  0.0f },
			{ 0.1f,  0.1f,  0.1f,  0.0f,  0.0f },
			{ 0.0f,  0.0f,  0.0f,  1.0f,  0.0f },
			{ 0.0f,  0.0f,  0.0f,  0.0f,  1.0f }});

	//static readonly MAGCOLOREFFECT invert = new(new[,] {
	//		{ -1.0f,  0.0f,  0.0f,  0.0f,  0.0f },
	//		{ 0.0f,  -1.0f,  0.0f,  0.0f,  0.0f },
	//		{ 0.0f,  0.0f,  -1.0f,  0.0f,  0.0f },
	//		{ 0.0f,  0.0f,  0.0f,  1.0f,  0.0f },
	//		{ 1.0f,  1.0f,  1.0f,  0.0f,  1.0f }});

	[OneTimeSetUp]
	public void _Setup()
	{
		Assert.IsTrue(MagInitialize());
	}

	[OneTimeTearDown]
	public void _TearDown()
	{
		Assert.IsTrue(MagUninitialize());
	}

	[Test]
	public void GetSetMagEffect()
	{
		VisibleWindow? hwndHost = null;
		HWND hwndMag = default;
		new System.Threading.Thread(() =>
		{
			const string WindowClassName = "Magnification Test";

			HINSTANCE hInst = Kernel32.GetModuleHandle().ReleaseOwnership();
			hwndHost = new VisibleWindow(WindowClassName, hInst, WindowClassName, new SIZE(300, 200), exStyle: WindowStylesEx.WS_EX_TOPMOST | WindowStylesEx.WS_EX_LAYERED | WindowStylesEx.WS_EX_TRANSPARENT);
			Assert.False(hwndHost.Handle.IsNull);

			// Make the window opaque.
			SetLayeredWindowAttributes(hwndHost, 0, 255, LayeredWindowAttributes.LWA_ALPHA);

			// Create a magnifier control that fills the client area.
			var r = hwndHost.ClientRect;
			var tmp = CreateWindow(WC_MAGNIFIER, "MagnifierWindow", WindowStyles.WS_CHILD | (WindowStyles)MagnifierStyles.MS_SHOWMAGNIFIEDCURSOR | WindowStyles.WS_VISIBLE,
				0, 0, r.Width, r.Height, hwndHost, default, hInst);
			if ((hwndMag = tmp.ReleaseOwnership()) != HWND.NULL)
			{
				hwndHost.Show();
				new MessagePump().Run(hwndHost);
			}
		}).Start();
		System.Threading.Thread.Yield();
		System.Threading.Thread.Sleep(500);

		try
		{
			Assert.That(hwndMag, ResultIs.ValidHandle);

			Assert.That(MagGetColorEffect(GetDesktopWindow(), out var eff), ResultIs.FailureCode(Win32Error.ERROR_NOT_SUPPORTED));
			Assert.That(MagSetColorEffect(GetDesktopWindow(), eff), ResultIs.FailureCode(Win32Error.ERROR_NOT_SUPPORTED));

			MAGTRANSFORM matrix = new(2f);
			Assert.That(MagSetWindowTransform(hwndMag, matrix), ResultIs.Successful);
			Assert.That(MagGetWindowTransform(hwndMag, out var m2), ResultIs.Successful);
			Assert.AreEqual(matrix, m2);

			Assert.That(MagGetColorEffect(hwndMag, out eff), ResultIs.Successful);
			Assert.True(eff.IsIdentity);
			Assert.That(MagSetColorEffect(hwndMag, grayeff), ResultIs.Successful);
			Assert.That(MagSetColorEffect(hwndMag), ResultIs.Successful);
		}
		finally
		{
			hwndHost?.Close();
		}
	}

	[Test]
	public void MagGetSetFullscreenTransformTest()
	{
		Assert.That(MagSetFullscreenTransform(2.0f, 400, 200), ResultIs.Successful);
		try
		{
			Assert.That(MagGetFullscreenTransform(out var mag, out var xoff, out var yoff), ResultIs.Successful);
			Assert.That(mag == 2f && xoff == 400 && yoff == 200, Is.True);
			System.Threading.Thread.Sleep(1000);
		}
		finally
		{
			Assert.That(MagSetFullscreenTransform(1.0f, 0, 0), ResultIs.Successful);
		}
	}

	[Test]
	public void MagGetSetFullscreenColorEffectTest()
	{
		Assert.That(MagSetFullscreenColorEffect(grayeff), ResultIs.Successful);
		Assert.That(MagGetFullscreenColorEffect(out var grayeff_get), ResultIs.Successful);
		Assert.AreEqual(grayeff, grayeff_get);
		System.Threading.Thread.Sleep(1000);
		Assert.That(MagSetFullscreenColorEffect(MAGCOLOREFFECT.Identity), ResultIs.Successful);
	}

	[Test]
	public void MagShowSystemCursorTest()
	{
		Assert.That(MagShowSystemCursor(false), ResultIs.Successful);
		Assert.That(MagShowSystemCursor(true), ResultIs.Successful);
	}

	[Test]
	public void CheckMAGCOLOREFFECTSizeTest()
	{
		Assert.AreEqual(sizeof(float) * 5 * 5, Marshal.SizeOf<MAGCOLOREFFECT>());
	}

	[Test]
	public void CheckMAGTRANSFORMSizeTest()
	{
		Assert.AreEqual(sizeof(float) * 3 * 3, Marshal.SizeOf<MAGTRANSFORM>());
	}

	[Test]
	public void GetSetMAGCOLOREFFECTTest()
	{
		var effect = default(MAGCOLOREFFECT);
		Assert.That(() => effect[5, 0], Throws.InstanceOf<ArgumentOutOfRangeException>());
		Assert.That(() => effect[0, 5], Throws.InstanceOf<ArgumentOutOfRangeException>());
		Assert.That(() => effect[5, 0] = 0, Throws.InstanceOf<ArgumentOutOfRangeException>());
		Assert.That(() => effect[0, 5] = 0, Throws.InstanceOf<ArgumentOutOfRangeException>());

		effect[0, 0] = 10.0f;
		effect[0, 1] = 10.1f;
		effect[1, 2] = 11.2f;
		effect[4, 4] = 14.4f;

		Assert.AreEqual(10.0f, effect[0, 0]);
		Assert.AreEqual(10.1f, effect[0, 1]);
		Assert.AreEqual(11.2f, effect[1, 2]);
		Assert.AreEqual(14.4f, effect[4, 4]);
	}

	[Test]
	public void GetSetMAGTRANSFORMTest()
	{
		var tfx = default(MAGTRANSFORM);
		Assert.That(() => tfx[3, 0], Throws.InstanceOf<ArgumentOutOfRangeException>());
		Assert.That(() => tfx[0, 3], Throws.InstanceOf<ArgumentOutOfRangeException>());
		Assert.That(() => tfx[3, 0] = 0, Throws.InstanceOf<ArgumentOutOfRangeException>());
		Assert.That(() => tfx[0, 3] = 0, Throws.InstanceOf<ArgumentOutOfRangeException>());

		tfx[0, 0] = 10.0f;
		tfx[0, 1] = 10.1f;
		tfx[1, 2] = 11.2f;
		tfx[2, 2] = 12.2f;

		Assert.AreEqual(10.0f, tfx[0, 0]);
		Assert.AreEqual(10.1f, tfx[0, 1]);
		Assert.AreEqual(11.2f, tfx[1, 2]);
		Assert.AreEqual(12.2f, tfx[2, 2]);
	}
}