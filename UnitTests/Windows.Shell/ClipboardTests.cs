using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;
using System.Windows.Forms;
using Vanara.Extensions;
using Vanara.InteropServices;
using Vanara.PInvoke;
using Vanara.PInvoke.Tests;
using static Vanara.PInvoke.Shell32;
using Clipboard = Vanara.Windows.Shell.NativeClipboard;
using WFClipboard = System.Windows.Forms.Clipboard;

namespace Vanara.Windows.Shell.Tests
{
	[TestFixture, SingleThreaded]
	public class ClipboardTests
	{
		private const string html = "<pre style=\"font-family:Consolas;font-size:13px;color:#dadada;\"><span style=\"color:#dcdcaa;\">“We’ve been here”</span></pre>";
		readonly string[] files = { TestCaseSources.SmallFile, TestCaseSources.ImageFile, TestCaseSources.LogFile };
		const string txt = @"“0’0©0è0”";
		const string ptxt = "ABC123";
		private const string url = "https://microsoft.com";

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
			SHCreateDataObject(ppv: out var ido).ThrowIfFailed();
			ido.SetData(CLIPFORMAT.CF_UNICODETEXT, "Test");

			var fmts = ido.EnumFormats().ToArray();
			Assert.That(fmts, Is.Not.Empty);
			TestContext.Write(string.Join(", ", fmts.Select(f => Clipboard.GetFormatName((uint)f.cfFormat))));

			var fmt = fmts.First();
			Assert.IsTrue(ido.IsFormatAvailable((uint)fmt.cfFormat));
		}

		[Test]
		public void GetPriorityFormatTest()
		{
			var fmts = Clipboard.CurrentlySupportedFormats.ToArray();
			Assert.That(Clipboard.GetFirstFormatAvailable(fmts), Is.GreaterThan(0));
		}

		[Test]
		public void GetSetShellItems1()
		{
			ShellItemArray items = new(Array.ConvertAll(files, f => new ShellItem(f)));
			var ido = items.ToDataObject();
			var shArray = ShellItemArray.FromDataObject(ido);
			Assert.That(shArray.Count, Is.GreaterThan(0));
			CollectionAssert.AreEquivalent(files, shArray.Select(s => s.FileSystemPath));
		}

		[Test]
		public void GetSetShellItems2()
		{
			Clipboard.Clear();
			ShellItem[] items = Array.ConvertAll(files, f => new ShellItem(f));
			Clipboard.SetShellItems(items);
			var shArray = Clipboard.GetShellItemArray();
			Assert.That(shArray.Count, Is.GreaterThan(0));
			CollectionAssert.AreEquivalent(files, shArray.Select(s => s.FileSystemPath));
		}

		[Test]
		public void GetSetDataTest()
		{
			SHCreateDataObject(ppv: out var ido).ThrowIfFailed();

			//using var hPal = Gdi32.CreatePalette(new LOGPALETTE() { palNumEntries = 256, palVersion = 0x0300, palPalEntry = new PALETTEENTRY[256] });
			//ido.SetData(CLIPFORMAT.CF_PALETTE, hPal);
			//Assert.That((HPALETTE)ido.GetData(CLIPFORMAT.CF_PALETTE), Is.EqualTo((HPALETTE)hPal));

			using System.Drawing.Bitmap bmp = new(TestCaseSources.BmpFile);
			using Gdi32.SafeHBITMAP hBmp = new(bmp.GetHbitmap());
			ido.SetData(CLIPFORMAT.CF_BITMAP, hBmp);
			Assert.AreEqual((HBITMAP)ido.GetData(CLIPFORMAT.CF_BITMAP), (HBITMAP)hBmp);

			//using System.Drawing.Imaging.Metafile enhMeta = new System.Drawing.Imaging.Metafile(TestCaseSources.TempChildDirWhack + "test.wmf");
			//using Gdi32.SafeHENHMETAFILE hEnh = new(enhMeta.GetHenhmetafile());
			//ido.SetData(CLIPFORMAT.CF_ENHMETAFILE, hEnh);
			//Assert.That((HENHMETAFILE)ido.GetData(CLIPFORMAT.CF_ENHMETAFILE), Is.EqualTo((HENHMETAFILE)hEnh));

			ido.SetData(CLIPFORMAT.CF_HDROP, files);
			ido.SetData(ShellClipboardFormat.CFSTR_FILENAMEMAPA, files);
			ido.SetData(ShellClipboardFormat.CFSTR_FILENAMEMAPW, files);
			CollectionAssert.AreEquivalent(files, (string[])ido.GetData(CLIPFORMAT.CF_HDROP));
			CollectionAssert.AreEquivalent(files, (string[])ido.GetData(ShellClipboardFormat.CFSTR_FILENAMEMAPA));
			CollectionAssert.AreEquivalent(files, (string[])ido.GetData(ShellClipboardFormat.CFSTR_FILENAMEMAPW));

			ido.SetData(CLIPFORMAT.CF_OEMTEXT, ptxt);
			Assert.AreEqual(ido.GetData(CLIPFORMAT.CF_OEMTEXT), ptxt);

			ido.SetData(CLIPFORMAT.CF_TEXT, txt);
			Assert.AreEqual(ido.GetData(CLIPFORMAT.CF_TEXT), txt);

			ido.SetData(CLIPFORMAT.CF_UNICODETEXT, txt);
			Assert.AreEqual(ido.GetData(CLIPFORMAT.CF_UNICODETEXT), txt);

			var r = new RECT(0, 8, 16, 32);
			ido.SetData("RECT", r);
			Assert.AreEqual(ido.GetData<RECT>("RECT"), r);

			var lcid = Kernel32.GetUserDefaultLCID();
			ido.SetData(CLIPFORMAT.CF_LOCALE, lcid);
			//Assert.AreEqual(ido.GetData<LCID>(CLIPFORMAT.CF_LOCALE), lcid);
			//Assert.That(ido.GetData(CLIPFORMAT.CF_LOCALE), lcid);

			const string csv = "a,b,c,d\n1,2,3,4";
			ido.SetData(ShellClipboardFormat.CF_CSV, csv);
			Assert.AreEqual(ido.GetData(ShellClipboardFormat.CF_CSV), csv);

			ido.SetData(ShellClipboardFormat.CF_HTML, html);
			Assert.AreEqual(ido.GetData(ShellClipboardFormat.CF_HTML), html);

			var rtf = System.IO.File.ReadAllText(TestCaseSources.TempDirWhack + "Test.rtf");
			ido.SetData(ShellClipboardFormat.CF_RTF, rtf);
			Assert.AreEqual(ido.GetData(ShellClipboardFormat.CF_RTF), rtf);

			ido.SetData(ShellClipboardFormat.CF_RTFNOOBJS, rtf);
			Assert.AreEqual(ido.GetData(ShellClipboardFormat.CF_RTFNOOBJS), rtf);

			DROPDESCRIPTION dropDesc = new() { type = DROPIMAGETYPE.DROPIMAGE_COPY, szMessage = "Move this" };
			ido.SetData(ShellClipboardFormat.CFSTR_DROPDESCRIPTION, dropDesc);
			Assert.AreEqual(((DROPDESCRIPTION)ido.GetData(ShellClipboardFormat.CFSTR_DROPDESCRIPTION)).szMessage, dropDesc.szMessage);

			FILE_ATTRIBUTES_ARRAY faa = new() { cItems = 1, rgdwFileAttributes = new[] { 4U } };
			ido.SetData(ShellClipboardFormat.CFSTR_FILE_ATTRIBUTES_ARRAY, faa);
			Assert.AreEqual(((FILE_ATTRIBUTES_ARRAY)ido.GetData(ShellClipboardFormat.CFSTR_FILE_ATTRIBUTES_ARRAY)).cItems, faa.cItems);

			FILEGROUPDESCRIPTOR fgd = new() { cItems = (uint)files.Length, fgd = new FILEDESCRIPTOR[files.Length] };
			for (int i = 0; i < files.Length; i++)
			{
				if (i == 0) { ido.SetData(ShellClipboardFormat.CFSTR_FILENAMEA, files[i]); ido.SetData(ShellClipboardFormat.CFSTR_FILENAMEW, files[i]); }
				fgd.fgd[i] = new FileInfo(files[i]);
				ShlwApi.SHCreateStreamOnFileEx(fgd.fgd[i].cFileName, STGM.STGM_READ | STGM.STGM_SHARE_DENY_WRITE, 0, false, null, out IStream istream).ThrowIfFailed();
				ido.SetData(ShellClipboardFormat.CFSTR_FILECONTENTS, istream, DVASPECT.DVASPECT_CONTENT, i);
			}
			ido.SetData(ShellClipboardFormat.CFSTR_FILEDESCRIPTORW, fgd);
			Assert.AreEqual(((FILEGROUPDESCRIPTOR)ido.GetData(ShellClipboardFormat.CFSTR_FILEDESCRIPTORW)).cItems, fgd.cItems);
			Assert.That(() => { var ist = (Ole32.IStreamV)ido.GetData(ShellClipboardFormat.CFSTR_FILECONTENTS, index: 1); ist.Seek(0, Ole32.STREAM_SEEK.STREAM_SEEK_SET, out _).ThrowIfFailed(); }, Throws.Nothing);
			Assert.That(ido.GetData(ShellClipboardFormat.CFSTR_FILENAMEA), Is.TypeOf<string>().And.Not.Null);
			Assert.That(ido.GetData(ShellClipboardFormat.CFSTR_FILENAMEW), Is.TypeOf<string>().And.Not.Null);

			ido.SetUrl(url, "Microsoft");
			Assert.That(ido.GetData(ShellClipboardFormat.CFSTR_INETURLA), Does.StartWith(url));
			Assert.That(ido.GetData(ShellClipboardFormat.CFSTR_INETURLW), Does.StartWith(url));

			ido.SetData(ShellClipboardFormat.CFSTR_INDRAGLOOP, true);
			Assert.AreEqual((BOOL)ido.GetData(ShellClipboardFormat.CFSTR_INDRAGLOOP), true);

			ido.SetData(ShellClipboardFormat.CFSTR_INVOKECOMMAND_DROPPARAM, ptxt);
			Assert.AreEqual(ido.GetData(ShellClipboardFormat.CFSTR_INVOKECOMMAND_DROPPARAM), ptxt);

			ido.SetData(ShellClipboardFormat.CFSTR_LOGICALPERFORMEDDROPEFFECT, Ole32.DROPEFFECT.DROPEFFECT_COPY);
			Assert.AreEqual(ido.GetData(ShellClipboardFormat.CFSTR_LOGICALPERFORMEDDROPEFFECT), Ole32.DROPEFFECT.DROPEFFECT_COPY);

			ido.SetData(ShellClipboardFormat.CFSTR_MOUNTEDVOLUME, ptxt);
			Assert.AreEqual(ido.GetData(ShellClipboardFormat.CFSTR_MOUNTEDVOLUME), ptxt);

			SafeLPTSTR remName = new("WINSTATION");
			NRESARRAY nres = new() { cItems = 1, nr = new NETRESOURCE[] { new() { lpRemoteName = remName } } };
			ido.SetData(ShellClipboardFormat.CFSTR_NETRESOURCES, nres);
			Assert.AreEqual(((NRESARRAY)ido.GetData(ShellClipboardFormat.CFSTR_NETRESOURCES)).cItems, nres.cItems);

			ido.SetData(ShellClipboardFormat.CFSTR_PASTESUCCEEDED, Ole32.DROPEFFECT.DROPEFFECT_COPY);
			Assert.AreEqual(ido.GetData(ShellClipboardFormat.CFSTR_PASTESUCCEEDED), Ole32.DROPEFFECT.DROPEFFECT_COPY);

			ido.SetData(ShellClipboardFormat.CFSTR_PERFORMEDDROPEFFECT, Ole32.DROPEFFECT.DROPEFFECT_COPY);
			Assert.AreEqual(ido.GetData(ShellClipboardFormat.CFSTR_PERFORMEDDROPEFFECT), Ole32.DROPEFFECT.DROPEFFECT_COPY);

			ido.SetData(ShellClipboardFormat.CFSTR_PREFERREDDROPEFFECT, Ole32.DROPEFFECT.DROPEFFECT_COPY);
			Assert.AreEqual(ido.GetData(ShellClipboardFormat.CFSTR_PREFERREDDROPEFFECT), Ole32.DROPEFFECT.DROPEFFECT_COPY);

			ido.SetData(ShellClipboardFormat.CFSTR_PRINTERGROUP, ptxt);
			Assert.AreEqual(ido.GetData(ShellClipboardFormat.CFSTR_PRINTERGROUP), ptxt);

			var guid = Guid.NewGuid();
			ido.SetData(ShellClipboardFormat.CFSTR_SHELLDROPHANDLER, guid);
			Assert.AreEqual(ido.GetData(ShellClipboardFormat.CFSTR_SHELLDROPHANDLER), guid);

			ido.SetData(ShellClipboardFormat.CFSTR_TARGETCLSID, guid);
			Assert.AreEqual(ido.GetData(ShellClipboardFormat.CFSTR_TARGETCLSID), guid);

			ido.SetData(ShellClipboardFormat.CFSTR_UNTRUSTEDDRAGDROP, 16U);
			Assert.AreEqual(ido.GetData(ShellClipboardFormat.CFSTR_UNTRUSTEDDRAGDROP), 16U);

			ido.SetData("ByteArray", new byte[] { 1,2,3,4,5,6,7,8 });
			Assert.AreEqual(((byte[])ido.GetData("ByteArray")).Length, 8);

			//using var fs = File.OpenRead(files[0]);
			//ido.SetData("Stream", fs);
			//Assert.That(ido.GetData("Stream"), Is.TypeOf<IStream>());

			//ido.SetData("StringArray", files);
			//CollectionAssert.AreEquivalent(files, ido.GetData<string[]>("StringArray"));

			// CFSTR_SHELLIDLIST

			ShlwApi.SHCreateStreamOnFileEx(files[0], STGM.STGM_READ | STGM.STGM_SHARE_DENY_WRITE, 0, false, null, out var istream2).ThrowIfFailed();
			ido.SetData("IStream", istream2);
			Assert.That(ido.GetData("IStream") as IStream, Is.Not.Null);

			// IStorage

			//var fi = new FileInfo(files[0]);
			//ido.SetData("File", fi);
			//Assert.AreEqual(ido.GetData("File"), files[0]);

			// ISerializable
			ido.SetData("NetBmp", bmp);
			Assert.That(ido.GetData("NetBmp"), Is.TypeOf<System.Drawing.Bitmap>());

			// SafeAllocated
			//SafeCoTaskMemHandle h = SafeCoTaskMemHandle.CreateFromStringList(files);
			//ido.SetData("hMem", h);
			//Assert.AreEqual(ido.GetData("hMem") as byte[], h.GetBytes());
		}

		[Test]
		public void SetNativeTextHtmlTest()
		{
			SHCreateDataObject(ppv: out var ido).ThrowIfFailed();
			ido.SetData(ShellClipboardFormat.Register(ShellClipboardFormat.CF_HTML), html);
			var outVal = ido.GetData(ShellClipboardFormat.Register(ShellClipboardFormat.CF_HTML));
			Assert.That(outVal, Is.EqualTo(html));
		}

		[Test]
		public void SetNativeTextMultTest()
		{
			const string stxt = "112233";
			Clipboard.SetText(stxt);
			Assert.That(Clipboard.GetText(TextDataFormat.Text), Is.EqualTo(stxt));

			Clipboard.SetText(txt, txt);
			Assert.That(Clipboard.GetText(TextDataFormat.Text), Is.EqualTo(txt));
			Assert.That(Clipboard.GetText(TextDataFormat.UnicodeText), Is.EqualTo(txt));
			Assert.That(Clipboard.GetText(TextDataFormat.Html), Is.EqualTo(txt));
			TestContext.WriteLine(Clipboard.GetText(TextDataFormat.Html));
		}

		[Test]
		public void SetNativeTextUnicodeTest()
		{
			const string txt = @"“0’0©0è0”";
			Clipboard.SetText(txt, TextDataFormat.UnicodeText);
			Assert.That(Clipboard.GetText(TextDataFormat.UnicodeText), Is.EqualTo(txt));
		}

		//[Test]
		public void ChangeEventTest()
		{
			var sawChange = new ManualResetEvent(false);
			Clipboard.ClipboardUpdate += OnUpdate;
			Thread.SpinWait(1000);
			WFClipboard.SetText("Hello");
			//using var Clipboard = new Clipboard();
			//Clipboard.SetText("Hello");
			Assert.IsTrue(sawChange.WaitOne(5000));
			Clipboard.ClipboardUpdate -= OnUpdate;

			void OnUpdate(object sender, EventArgs e) => sawChange.Set();
		}
	}
}