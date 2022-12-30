using NUnit.Framework;
using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Vanara.PInvoke;
using Vanara.PInvoke.Tests;
using static Vanara.PInvoke.Shell32;
using Clipboard = Vanara.Windows.Shell.NativeClipboard;
using WFClipboard = System.Windows.Forms.Clipboard;

namespace Vanara.Windows.Shell.Tests
{
	[TestFixture/*, SingleThreaded*/]
	public class ClipboardTests
	{
		private const string html = "<pre style=\"font-family:Consolas;font-size:13px;color:#dadada;\"><span style=\"color:#dcdcaa;\">“We’ve been here”</span></pre>";

		[Test]
		public void CtorTest()
		{
			const string txt = "Test";
			using (var cb = new Clipboard(true, User32.GetDesktopWindow()))
				cb.SetText(txt, txt, txt);
			using (var cb = new Clipboard(false, User32.GetDesktopWindow()))
				Assert.That(cb.GetText(TextDataFormat.UnicodeText), Is.EqualTo(txt));
			using (var cb = new Clipboard())
				Assert.That(cb.GetText(TextDataFormat.UnicodeText), Is.EqualTo(txt));
			using (var cb = new Clipboard(true))
				cb.SetText(txt, txt, txt);
			using (var cb = new Clipboard())
				Assert.That(cb.GetText(TextDataFormat.UnicodeText), Is.EqualTo(txt));
			using (var cb = new Clipboard(false, User32.GetDesktopWindow()))
				Assert.That(cb.GetText(TextDataFormat.UnicodeText), Is.EqualTo(txt));
		}

		[Test]
		public void DumpWFClipboardTest()
		{
			TestContext.WriteLine($"ContainsAudio: {WFClipboard.ContainsAudio()}");
			TestContext.WriteLine($"ContainsData: {WFClipboard.ContainsData(DataFormats.StringFormat)}");
			TestContext.WriteLine($"ContainsFileDropList: {WFClipboard.ContainsFileDropList()}");
			TestContext.WriteLine($"ContainsImage: {WFClipboard.ContainsImage()}");
			TestContext.WriteLine($"ContainsText: {WFClipboard.ContainsText()}");
			TestContext.WriteLine($"GetAudioStream: {WFClipboard.GetAudioStream()}");
			TestContext.WriteLine($"GetData: {WFClipboard.GetData(DataFormats.StringFormat)}");
			TestContext.WriteLine($"GetDataObject: {WFClipboard.GetDataObject()}");
			TestContext.WriteLine($"GetFileDropList: {string.Join("\n", WFClipboard.GetFileDropList().Cast<string>())}");
			TestContext.WriteLine($"GetImage: {WFClipboard.GetImage()}");
			TestContext.WriteLine($"GetText: {WFClipboard.GetText()}");
		}

		[Test]
		public void EnumFormatsTest()
		{
			using var cb = new Clipboard();
			var fmts = cb.EnumAvailableFormats();
			Assert.That(fmts, Is.Not.Empty);
			TestContext.Write(string.Join(", ", fmts.Select(f => Clipboard.GetFormatName(f))));

			var fmt = fmts.First();
			Assert.IsTrue(Clipboard.IsFormatAvailable(fmt));
		}

		[Test]
		public void GetNativeTextTest()
		{
			using var cb = new Clipboard();
			foreach (TextDataFormat e in Enum.GetValues(typeof(TextDataFormat)))
				TestContext.WriteLine($"{e}: {cb.GetText(e)}");
		}

		[Test]
		public void GetPriorityFormatTest()
		{
			var fmts = Clipboard.CurrentlySupportedFormats.ToArray();
			Assert.That(Clipboard.GetFirstFormatAvailable(fmts), Is.GreaterThan(0));
		}

		[Test, Apartment(ApartmentState.STA)]
		public void GetSetShellItems1()
		{
			//Ole32.CoInitializeEx(default, Ole32.COINIT.COINIT_APARTMENTTHREADED).ThrowIfFailed();
			//Clipboard.DataObject = null;
			string[] files = { TestCaseSources.SmallFile, TestCaseSources.ImageFile, TestCaseSources.LogFile };
			ShellItemArray items = new(Array.ConvertAll(files, f => new ShellItem(f)));
			Clipboard.SetShellItems(items);
			var shArray = Clipboard.GetShellItemArray();
			Assert.That(shArray.Count, Is.GreaterThan(0));
			Assert.IsTrue(files.SequenceEqual(shArray.Select(s => s.FileSystemPath)));
		}

		[Test]
		public void GetSetShellItems2()
		{
			Clipboard.DataObject = null;
			string[] files = { TestCaseSources.SmallFile, TestCaseSources.ImageFile, TestCaseSources.LogFile };
			ShellItem[] items = Array.ConvertAll(files, f => new ShellItem(f));
			Clipboard.SetShellItems(items);
			var shArray = Clipboard.GetShellItemArray();
			Assert.That(shArray.Count, Is.GreaterThan(0));
			Assert.IsTrue(files.SequenceEqual(shArray.Select(s => s.FileSystemPath)));
		}

		[Test]
		public void SetNativeTextHtmlTest()
		{
			using (var cb = new Clipboard(true))
				cb.SetText(html, TextDataFormat.Html);
			using (var cb = new Clipboard())
			{
				var outVal = cb.GetText(TextDataFormat.Html);
				Assert.That(outVal, Is.EqualTo(html));
			}
		}

		[Test]
		public void SetNativeTextMultTest()
		{
			const string stxt = "112233";
			using (var cb = new Clipboard(true))
				cb.SetText(stxt);
			using (var cb = new Clipboard())
				Assert.That(cb.GetText(TextDataFormat.Text), Is.EqualTo(stxt));

			const string txt = @"“0’0©0è0”";
			using (var cb = new Clipboard(true))
				cb.SetText(txt, $"<p>{txt}</p>");
			using (var cb = new Clipboard())
			{
				Assert.That(cb.GetText(TextDataFormat.Text), Is.EqualTo(txt));
				Assert.That(cb.GetText(TextDataFormat.UnicodeText), Is.EqualTo(txt));
				Assert.That(cb.GetText(TextDataFormat.Html), Contains.Substring(txt));
				TestContext.WriteLine(cb.GetText(TextDataFormat.Html));
			}
		}

		[Test]
		public void SetNativeTextUnicodeTest()
		{
			const string txt = @"“0’0©0è0”";
			using (var cb = new Clipboard(true))
				cb.SetText(txt, TextDataFormat.UnicodeText);
			using (var cb = new Clipboard())
				Assert.That(cb.GetText(TextDataFormat.UnicodeText), Is.EqualTo(txt));
		}

		//[Test]
		public void ChangeEventTest()
		{
			var sawChange = new System.Threading.ManualResetEvent(false);
			Clipboard.ClipboardUpdate += OnUpdate;
			System.Threading.Thread.SpinWait(1000);
			WFClipboard.SetText("Hello");
			//using var cb = new Clipboard();
			//cb.SetText("Hello");
			Assert.IsTrue(sawChange.WaitOne(5000));
			Clipboard.ClipboardUpdate -= OnUpdate;

			void OnUpdate(object sender, EventArgs e) => sawChange.Set();
		}
	}
}