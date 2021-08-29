using NUnit.Framework;
using System;
using System.Linq;
using System.Windows.Forms;
using Vanara.PInvoke;
using static Vanara.PInvoke.Shell32;
using Clipboard = Vanara.Windows.Shell.NativeClipboard;
using WFClipboard = System.Windows.Forms.Clipboard;

namespace Vanara.Windows.Shell.Tests
{
	[TestFixture, SingleThreaded]
	public class ClipboardTests
	{
		private const string html = "<pre style=\"font-family:Consolas;font-size:13px;color:#dadada;\"><span style=\"color:#dcdcaa;\">“We’ve been here”</span></pre>";

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
			TestContext.Write(string.Join(", ", fmts.Select(f => f.Name)));

			var fmt = fmts.First();
			Assert.IsTrue(Clipboard.IsFormatAvailable(fmt.Id));
			Assert.IsTrue(Clipboard.IsFormatAvailable(fmt.Name));
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
			var fmts = Clipboard.CurrentlySupportedFormats.Select(f => f.Id).ToArray();
			Assert.That(Clipboard.GetFirstFormatAvailable(fmts), Is.GreaterThan(0));
		}

		[Test]
		public void SetNativeTextHtmlTest()
		{
			using (var cb = new Clipboard())
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
			const string txt = @"“We’ve been here”";
			using var cb = new Clipboard();
			cb.SetText(txt, html);
		}

		[Test]
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