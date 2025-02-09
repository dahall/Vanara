using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Drawing;
using System.Drawing.Imaging;
using static Vanara.PInvoke.AviFil32;
using static Vanara.PInvoke.Gdi32;
using static Vanara.PInvoke.WinMm;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class aviTests
{
	[OneTimeSetUp]
	public void _Setup()
	{
		AVIFileInit();
	}

	[OneTimeTearDown]
	public void _TearDown()
	{
		AVIFileExit();
	}

	[Test]
	public void TestErr()
	{
		Assert.That(((HRESULT)(int)AVIERR.AVIERR_NODATA).ToString(), Is.Not.Null);
		foreach (AVIERR err in Enum.GetValues(typeof(AVIERR)))
			TestContext.WriteLine($"{err} = {(HRESULT)(int)err}");
	}

	[Test]
	public void AVISaveOptionsTest()
	{
		Assert.That(AVIFileOpen(out var iFile, TestCaseSources.TempDirWhack + "test.avi", Kernel32.OpenFileAction.OF_CREATE | Kernel32.OpenFileAction.OF_WRITE), ResultIs.Successful);
		try
		{
			AVISTREAMINFO strhdr = new() { dwScale = 1, fccType = streamtypeVIDEO, dwRate = 30, dwSuggestedBufferSize = 1024 };
			Assert.That(AVIFileCreateStream(iFile, out var iStream, strhdr), ResultIs.Successful);
			try
			{
				unsafe
				{
					AVICOMPRESSOPTIONS opts0 = new() { fccType = streamtypeVIDEO };
					var popts0 = &opts0;
					var ret = AVISaveOptions(User32.GetDesktopWindow(), 0, 1, new[] { iStream }, &popts0);
					Assert.That(ret, Is.EqualTo((IntPtr)1));
					Assert.That(opts0.fccType, Is.Not.EqualTo(streamtypeVIDEO));
					Assert.That(AVISaveOptionsFree(1, &popts0), ResultIs.Successful);
				}
			}
			finally
			{
				AVIStreamRelease(iStream);
			}
		}
		finally
		{
			AVIFileRelease(iFile);
		}
	}

	[Test]
	public void AVIMakeCompressedStreamTest()
	{
		int width = 640;
		int height = 480;
		uint frameSize = (uint)(4 * width * height);

		Assert.That(AVIFileOpen(out var iFile, TestCaseSources.TempDirWhack + "test.avi", Kernel32.OpenFileAction.OF_CREATE | Kernel32.OpenFileAction.OF_WRITE), ResultIs.Successful);
		try
		{
			AVISTREAMINFO strhdr = new()
			{
				fccType = streamtypeVIDEO,
				fccHandler = MAKEFOURCC("MSVC"),
				dwScale = 1,
				dwRate = 30,
				dwSuggestedBufferSize = frameSize,
				dwQuality = unchecked((uint)-1),
				rcFrame = new RECT(0, 0, width, height)
			};
			Assert.That(AVIFileCreateStream(iFile, out var iStream, strhdr), ResultIs.Successful);
			try
			{
				unsafe
				{
					AVICOMPRESSOPTIONS opts0 = new() { fccType = streamtypeVIDEO };
					var popts0 = &opts0;
					var ret = AVISaveOptions(User32.GetDesktopWindow(), 0, 1, new[] { iStream }, &popts0);
					Assert.That(ret, Is.EqualTo((IntPtr)1));
					Assert.That(opts0.fccType, Is.Not.EqualTo(streamtypeVIDEO));

					Assert.That(AVIMakeCompressedStream(out var compressedStream, iStream, opts0), ResultIs.Successful);
					try
					{
						BITMAPINFOHEADER bi = new()
						{
							biSize = (uint)Marshal.SizeOf<BITMAPINFOHEADER>(),
							biWidth = width,
							biHeight = height,
							biPlanes = 1,
							biBitCount = 24,
							biSizeImage = frameSize,
						};

						Assert.That(AVIStreamSetFormat(compressedStream, 0, new IntPtr(&bi), (int)bi.biSize), ResultIs.Successful);

						using var bmp = new Bitmap(width, height);
						for (int i = 0; i < 200; i++)
						{
							using (var graphics = Graphics.FromImage(bmp))
							{
								graphics.Clear(Color.FromArgb(new Random().Next(255)));
							}

							var bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, bmp.PixelFormat);
							try
							{
								Assert.That(AVIStreamWrite(compressedStream, i, 1, bmpData.Scan0, bmpData.Stride * bmpData.Height, 0, out _, out _), ResultIs.Successful);
							}
							finally
							{
								bmp.UnlockBits(bmpData);
							}
						}
					}
					finally
					{
						AVIStreamRelease(compressedStream);
					}
					Assert.That(AVISaveOptionsFree(1, &popts0), ResultIs.Successful);
				}
			}
			finally
			{
				AVIStreamRelease(iStream);
			}
		}
		finally
		{
			AVIFileRelease(iFile);
		}
	}

}