using NUnit.Framework;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using static Vanara.PInvoke.Kernel32;
using static Vanara.PInvoke.Shell32;
using static Vanara.PInvoke.User32;

namespace Vanara.PInvoke.Tests
{
	[TestFixture]
	public class Shell32_IconTests
	{
		[Test]
		public void ExtractAssociatedIconTest()
		{
			const string icoFile = TestCaseSources.WordDoc;
			var sb = new StringBuilder(icoFile, MAX_PATH);
			ushort iidx = 0;
			using (var hIcon = ExtractAssociatedIcon(HINSTANCE.NULL, sb, ref iidx))
				Assert.That(hIcon.IsInvalid, Is.False);
			TestContext.WriteLine(sb);
		}

		[Test]
		public void ExtractAssociatedIconExTest()
		{
			const string icoFile = TestCaseSources.WordDoc;
			var sb = new StringBuilder(icoFile, MAX_PATH);
			ushort iidx = 0, iid = 0;
			using (var hIcon = ExtractAssociatedIconEx(HINSTANCE.NULL, sb, ref iidx, ref iid))
			{
				Assert.That(hIcon.IsInvalid, Is.False);
				TestContext.WriteLine($"{sb}:{iidx}:{iid}");

				using (var hDupIcon = DuplicateIcon(HINSTANCE.NULL, hIcon))
					Assert.That(hDupIcon.IsInvalid, Is.False);
			}
		}

		[Test]
		public void ExtractIconTest()
		{
			using (var ico1 = ExtractIcon(HINSTANCE.NULL, "notepad.exe", 0))
				Assert.That(ico1.IsInvalid, Is.False);
			using (var ico2 = ExtractIcon(HINSTANCE.NULL, "notepad.exe", -2))
				Assert.That(ico2.IsInvalid, Is.False);
			using (var icoCnt = ExtractIcon(HINSTANCE.NULL, "notepad.exe", -1))
				Assert.That(icoCnt.DangerousGetHandle().ToInt32(), Is.EqualTo(1));
		}

		[Test]
		public void ExtractIconExTest()
		{
			var smIco = new[] { new HICON(IntPtr.Zero) };
			var lgIco = new[] { new HICON(IntPtr.Zero) };
			var ico1 = ExtractIconEx("notepad.exe", 0, lgIco, smIco, 1);
			Assert.That(ico1, Is.EqualTo(2));
			Free();
			var ico2 = ExtractIconEx("notepad.exe", -2, lgIco, smIco, 1);
			Assert.That(ico2, Is.EqualTo(2));
			Free();
			var icoCnt = ExtractIconEx("notepad.exe", -1, null, null, 0);
			Assert.That(icoCnt, Is.EqualTo(1));

			void Free()
			{
				DestroyIcon(smIco[0]);
				DestroyIcon(lgIco[0]);
			}
		}

		[Test]
		public void ExtractIconExTest2()
		{
			var ico1 = ExtractIconEx("notepad.exe", 0, 1, out var lgIco, out var smIco);
			Assert.That(ico1, Is.EqualTo(2));
			Assert.That(lgIco, Is.Not.Null.And.Length.EqualTo(1));
			var ico2 = ExtractIconEx("notepad.exe", -2, 1, out lgIco, out smIco);
			Assert.That(ico2, Is.EqualTo(2));
			var icoCnt = ExtractIconEx("notepad.exe", -1, 0, out lgIco, out smIco);
			Assert.That(icoCnt, Is.EqualTo(1));
			Assert.That(lgIco, Is.Null);
		}

		[Test]
		public void PickIconDlgTest()
		{
			var sb = new StringBuilder("moricons.dll", MAX_PATH);
			var idx = 0;
			Assert.That(PickIconDlg(HWND.NULL, sb, (uint)sb.Length + 1, ref idx), Is.True);
		}

		[Test]
		public void SHCreateDefaultExtractIconTest()
		{
			Assert.That(SHCreateDefaultExtractIcon(typeof(IDefaultExtractIconInit).GUID, out var ppv), Is.EqualTo((HRESULT)0));
			Assert.That(ppv, Is.Not.Null);
			Marshal.FinalReleaseComObject(ppv);
		}

		[Test]
		public void SHCreateFileExtractIconWTest()
		{
			const string icoFile = @"notepad.exe";
			Assert.That(SHCreateFileExtractIconW(icoFile, FileFlagsAndAttributes.FILE_ATTRIBUTE_NORMAL, typeof(IExtractIcon).GUID, out var ppv), Is.EqualTo((HRESULT)0));
			Assert.That(ppv, Is.Not.Null);
			((IExtractIcon)ppv).Extract(icoFile, 0, out var lg, out var sm, Macros.MAKELONG(48, 16)).ThrowIfFailed();
			Assert.That(sm.IsInvalid, Is.False);
			Assert.That(sm.ToIcon().Height, Is.EqualTo(16));
			Marshal.FinalReleaseComObject(ppv);
		}

		[Test]
		public void SHDefExtractIconTest()
		{
			const string icoFile = @"notepad.exe";
			Assert.That(SHDefExtractIcon(icoFile, -2, 0, out var lg, out var sm, Macros.MAKELONG(48, 16)), Is.EqualTo((HRESULT)0));
			Assert.That(sm.IsInvalid, Is.False);
			Assert.That(sm.ToIcon().Height, Is.EqualTo(16));
		}

		[Test]
		public void SHGetIconOverlayIndexTest()
		{
			Assert.That(SHGetIconOverlayIndex(null, IDO_SHGIOI_LINK), Is.Not.Zero);
		}

		[Test]
		public void SHGetStockIconInfoTest()
		{
			var psii = new SHSTOCKICONINFO { cbSize = (uint)Marshal.SizeOf(typeof(SHSTOCKICONINFO)) };
			Assert.That(SHGetStockIconInfo(SHSTOCKICONID.SIID_APPLICATION, SHGSI.SHGSI_ICON, ref psii), Is.EqualTo((HRESULT)0));
			Assert.That(psii.hIcon.IsNull, Is.False);
			DestroyIcon(psii.hIcon);
		}

		[Test]
		public void SHLoadNonloadedIconOverlayIdentifiersTest()
		{
			Assert.That(SHLoadNonloadedIconOverlayIdentifiers(), Is.EqualTo((HRESULT)0));
		}

		/*
		Shell_NotifyIcon
		Shell_NotifyIconGetRect
		*/
	}
}
