using NUnit.Framework;
using NUnit.Framework.Internal;
using static Vanara.PInvoke.Dcomp;
using static Vanara.PInvoke.DXGI;
using static Vanara.PInvoke.D3D11;
using static Vanara.PInvoke.Gdi32;
using static Vanara.PInvoke.User32;
using System.Runtime.Versioning;
using static ICSharpCode.Decompiler.TypeSystem.ReflectionHelper;
using System.Linq;

namespace Vanara.PInvoke.Tests;

[SupportedOSPlatform("windows10.0")]
[TestFixture]
public class DcompTests
{
	[OneTimeSetUp]
	public void _Setup()
	{
	}

	[OneTimeTearDown]
	public void _TearDown()
	{
	}

	[Test]
	public void CreateDeviceTest()
	{
		SafeHBITMAP[] m_hBitmaps = [
			new(LoadImage(default, OBM_CLOSE, LoadImageType.IMAGE_BITMAP, 0, 0, 0)),
			new(LoadImage(default, OBM_SIZE, LoadImageType.IMAGE_BITMAP, 0, 0, 0)),
			new(LoadImage(default, OBM_ZOOM, LoadImageType.IMAGE_BITMAP, 0, 0, 0)),
			new(LoadImage(default, OBM_REDUCE, LoadImageType.IMAGE_BITMAP, 0, 0, 0)),
		];
		Assert.That(m_hBitmaps.All(b => !b.IsInvalid));
		ID3D11Device? m_pD3D11Device = null;
		IDCompositionDevice? m_pDevice = null;
		IDCompositionTarget? m_pCompTarget = null;

		VisibleWindow.Run(WndProc, "Test", new(600, 600));

		IntPtr WndProc(HWND hwnd, uint msg, IntPtr wParam, IntPtr lParam)
		{
			switch ((WindowMessage)msg)
			{
				case WindowMessage.WM_CREATE:
					{
						// Create the D3D device object. The D3D11_CREATE_DEVICE_BGRA_SUPPORT flag enables rendering on surfaces using Direct2D.
						Assert.That(D3D11CreateDevice(default, D3D_DRIVER_TYPE.D3D_DRIVER_TYPE_HARDWARE, default, D3D11_CREATE_DEVICE_FLAG.D3D11_CREATE_DEVICE_BGRA_SUPPORT,
							default, 0, D3D11_SDK_VERSION, out m_pD3D11Device, out _, out _), ResultIs.Successful);

						// Create the DXGI device used to create bitmap surfaces.
						IDXGIDevice? pDXGIDevice = null;
						Assert.That(() => pDXGIDevice = (IDXGIDevice)m_pD3D11Device, Throws.Nothing);

						// Create the DirectComposition device object.
						Assert.That(DCompositionCreateDevice(pDXGIDevice, out m_pDevice), ResultIs.Successful);

						// Create the composition target object based on the specified application window.
						Assert.That(m_pDevice!.CreateTargetForHwnd(hwnd, true, out m_pCompTarget), ResultIs.Successful);
					}
					break;
				case WindowMessage.WM_LBUTTONDOWN:
					OnClientClick();
					break;
				case WindowMessage.WM_DISPLAYCHANGE:
					InvalidateRect(hwnd, default, false);
					break;
			}
			return DefWindowProc(hwnd, msg, wParam, lParam);
		}

		void OnClientClick()
		{
			// Create a visual objects and set their content. 
			IDCompositionVisual[] pVisuals = new IDCompositionVisual[m_hBitmaps.Length];
			SIZE[] bmpSizes = new SIZE[m_hBitmaps.Length];
			for (int i = 0; i < m_hBitmaps.Length; i++)
			{
				pVisuals[i] = m_pDevice!.CreateVisual();

				// This application-defined function creates a DirectComposition surface and renders a GDI bitmap onto the surface.
				MyCreateGDIRenderedDCompSurface(m_hBitmaps[i], out var pSurface, out bmpSizes[i]);

				// Set the bitmap content. 
				pVisuals[i].SetContent(pSurface);

				Marshal.ReleaseComObject(pSurface!);
			}

			float xPosRoot = 10.0f;
			float yPosRoot = 10.0f;

			// Set the horizontal and vertical position of the root visual. 
			pVisuals[0].SetOffsetX(xPosRoot);
			pVisuals[0].SetOffsetY(yPosRoot);

			// Set the root visual of the visual tree. 
			m_pCompTarget!.SetRoot(pVisuals[0]);

			float xPosChild = 5.0f;
			float yPosChild = 5.0f;

			// Set the positions of the child visuals and add them to the visual tree.
			for (int i = 1; i < m_hBitmaps.Length; i++)
			{
				pVisuals[i].SetOffsetX(xPosChild);
				pVisuals[i].SetOffsetY((yPosChild * i) + (bmpSizes[i].Height * (i - 1)));

				// Add the child visuals as children of the root visual.
				pVisuals[0].AddVisual(pVisuals[i], true, default);
			}

			// Commit the visual to be composed and displayed.
			m_pDevice!.Commit();
		}

		void MyCreateGDIRenderedDCompSurface(SafeHBITMAP hBitmap, out IDCompositionSurface? pSurface, out SIZE bmpSize)
		{
			// Get information about the bitmap.
			var bmp = GetObject<BITMAP>(hBitmap);
			bmpSize = new(bmp.bmWidth, bmp.bmHeight);
			Assert.That(!bmpSize.IsEmpty);

			// Create a DirectComposition-compatible surface that is the same size as the bitmap.
			pSurface = m_pDevice.CreateSurface((uint)bmp.bmWidth, (uint)bmp.bmHeight, DXGI_FORMAT.DXGI_FORMAT_B8G8R8A8_UNORM, DXGI_ALPHA_MODE.DXGI_ALPHA_MODE_IGNORE);
			Assert.That(pSurface, Is.Not.Null);

			IDXGISurface1? pDXGISurface = null;
			Assert.That(pSurface!.BeginDraw(default, typeof(IDXGISurface1).GUID, out var ppv, out var pointOffset), ResultIs.Successful);
			Assert.That(pDXGISurface = ppv as IDXGISurface1, Is.Not.Null);

			Assert.That(pDXGISurface!.GetDC(false, out var hSurfaceDC), ResultIs.Successful);

			using var hBitmapDC = CreateCompatibleDC(hSurfaceDC);
			Assert.That(hBitmapDC, ResultIs.ValidHandle);
			using (hBitmapDC.SelectObject(hBitmap))
				BitBlt(hSurfaceDC, pointOffset.x, pointOffset.y, bmp.bmWidth, bmp.bmHeight, hBitmapDC, 0, 0, RasterOperationMode.SRCCOPY);

			Assert.That(pDXGISurface!.ReleaseDC(default), ResultIs.Successful);
			Assert.That(pSurface!.EndDraw(), ResultIs.Successful);
		}
	}
}