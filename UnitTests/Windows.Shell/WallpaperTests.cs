using NUnit.Framework;
using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Vanara.Extensions;
using Vanara.InteropServices;
using Vanara.PInvoke.Tests;
using static Vanara.PInvoke.Shell32;

namespace Vanara.Windows.Shell.Tests
{
	[TestFixture]
	public class WallpaperTests
	{
		[Test]
		public void ReadPropTest()
		{
			//Assert.IsTrue(WallpaperManager.Enabled);
			TestContext.WriteLine($"Enabled={WallpaperManager.Enabled}, Bkg={WallpaperManager.BackgroundColor}, Pos={WallpaperManager.WallpaperFit}");
			Assert.That(WallpaperManager.Monitors.Count, Is.GreaterThanOrEqualTo(1));
			TestContext.WriteLine("Monitors:\n" + string.Join("\n", WallpaperManager.Monitors));
			if (!WallpaperManager.Slideshow.IsEnabled) return;
			TestContext.WriteLine($"Slideshow: Interval={WallpaperManager.Slideshow.Interval}, Shuffle={WallpaperManager.Slideshow.Shuffle}");
			TestContext.WriteLine(string.Join("\n", WallpaperManager.Slideshow.Images));
		}

		[Test]
		public void BackgroundColorTest()
		{
			var clr = WallpaperManager.BackgroundColor;
			try
			{
				var newClr = Color.FromArgb(unchecked((byte)~clr.R), unchecked((byte)~clr.G), unchecked((byte)~clr.B));
				Assert.That(() => WallpaperManager.BackgroundColor = newClr, Throws.Nothing);
				Assert.That(newClr.ToArgb(), Is.EqualTo(WallpaperManager.BackgroundColor.ToArgb()));
			}
			finally
			{
				WallpaperManager.BackgroundColor = clr;
			}
		}

		[Test]
		public void EnabledTest()
		{
			var enabled = WallpaperManager.Enabled;
			Assert.That(() => WallpaperManager.Enabled = !enabled, Throws.Nothing);
			Assert.That(() => WallpaperManager.Enabled = enabled, Throws.Nothing);
		}

		[Test]
		public void WallpaperPositionrTest()
		{
			var pos = WallpaperManager.WallpaperFit;
			try
			{
				var newPos = (++pos).IsValid() ? pos : 0;
				Assert.That(() => WallpaperManager.WallpaperFit = newPos, Throws.Nothing);
				Assert.That(newPos, Is.EqualTo(WallpaperManager.WallpaperFit));
			}
			finally
			{
				WallpaperManager.WallpaperFit = pos;
			}
		}

		[Test]
		public void MonitorTest()
		{
			Assert.That(WallpaperManager.Monitors.Count, Is.GreaterThanOrEqualTo(1));
			string prev = WallpaperManager.Slideshow.IsEnabled ? string.Join(";", WallpaperManager.Slideshow.Images.Select(shi => shi.FileSystemPath)) : '@' + WallpaperManager.Monitors[0].ImagePath;
			try
			{
				Assert.That(() => WallpaperManager.Monitors[0].ImagePath = TestCaseSources.ImageFile, Throws.Nothing);
				StringAssert.AreEqualIgnoringCase(WallpaperManager.Monitors[0].ImagePath, TestCaseSources.ImageFile);
			}
			finally
			{
				var files = prev.Split(';');
				if (files.Length == 1 && files[0].StartsWith("@"))
					WallpaperManager.Monitors[0].ImagePath = files[0].TrimStart('@');
				else
					WallpaperManager.Slideshow.Images = files.Select(f => new ShellItem(f)).ToArray();
			}
		}

		[Test]
		public void SlideShowTest()
		{
			Assert.That(WallpaperManager.Monitors.Count, Is.GreaterThanOrEqualTo(1));
			string prev = WallpaperManager.Slideshow.IsEnabled ? string.Join(";", WallpaperManager.Slideshow.Images.Select(shi => shi.FileSystemPath)) : '@' + WallpaperManager.Monitors[0].ImagePath;
			try
			{
				Assert.That(() => WallpaperManager.Slideshow.Images = new[] { new ShellItem(TestCaseSources.TempDir) }, Throws.Nothing);
				Assert.That(WallpaperManager.Slideshow.Images.Count, Is.EqualTo(1));
				Assert.That(() => WallpaperManager.Slideshow.Images = new[] { new ShellItem(TestCaseSources.ImageFile), new ShellItem(TestCaseSources.Image2File) }, Throws.Nothing);
				Assert.That(WallpaperManager.Slideshow.Images.Count, Is.EqualTo(2));

				var shuf = WallpaperManager.Slideshow.Shuffle;
				Assert.That(() => WallpaperManager.Slideshow.Shuffle = !shuf, Throws.Nothing);
				Assert.That(WallpaperManager.Slideshow.Shuffle, Is.EqualTo(!shuf));
				Assert.That(() => WallpaperManager.Slideshow.Shuffle = shuf, Throws.Nothing);

				var dur = WallpaperManager.Slideshow.Interval;
				var newDur = dur + TimeSpan.FromDays(40);
				Assert.That(() => WallpaperManager.Slideshow.Interval = newDur, Throws.Nothing);
				Assert.That(WallpaperManager.Slideshow.Interval, Is.EqualTo(newDur));
				Assert.That(() => WallpaperManager.Slideshow.Interval = dur, Throws.Nothing);
			}
			finally
			{
				var files = prev.Split(';');
				if (files.Length == 1 && files[0].StartsWith("@"))
					WallpaperManager.Monitors[0].ImagePath = files[0].TrimStart('@');
				else
					WallpaperManager.Slideshow.Images = files.Select(f => new ShellItem(f)).ToArray();
			}
		}

		[Test]
		public void SetTest()
		{
			string prev = WallpaperManager.Slideshow.IsEnabled ? string.Join(";", WallpaperManager.Slideshow.Images.Select(shi => shi.FileSystemPath)) : '@' + WallpaperManager.Monitors[0].ImagePath;
			var pos = WallpaperManager.WallpaperFit;
			var clr = WallpaperManager.BackgroundColor;

			try
			{
				Assert.That(() => WallpaperManager.SetSolidBackground(Color.Black), Throws.Nothing);
				Assert.That(WallpaperManager.Enabled, Is.False);
				Assert.That(WallpaperManager.Monitors[0].ImagePath, Is.Empty);
				Assert.That(() => WallpaperManager.SetPicture(TestCaseSources.ImageFile, DESKTOP_WALLPAPER_POSITION.DWPOS_CENTER, 0), Throws.Nothing);
				Assert.That(WallpaperManager.Slideshow.Images, Is.Empty);
				Assert.That(() => WallpaperManager.SetSlideshow(TestCaseSources.TempDir, DESKTOP_WALLPAPER_POSITION.DWPOS_SPAN), Throws.Nothing);
				Assert.That(WallpaperManager.Monitors[0].ImagePath, Is.Not.Empty);
			}
			finally
			{
				var files = prev.Split(';');
				if (files.Length == 1 && files[0].StartsWith("@"))
					WallpaperManager.Monitors[0].ImagePath = files[0].TrimStart('@');
				else
					WallpaperManager.Slideshow.Images = files.Select(f => new ShellItem(f)).ToArray();
				WallpaperManager.BackgroundColor = clr;
				WallpaperManager.WallpaperFit = pos;
			}
		}
	}
}