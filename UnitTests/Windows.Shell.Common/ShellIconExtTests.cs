using NUnit.Framework;
using System.Threading;
using Vanara.PInvoke.Tests;
using static Vanara.PInvoke.Shell32;

namespace Vanara.Windows.Shell.Tests;

[TestFixture]
public class ShellIconExtTests
{
	[Test]
	public void ExtTest()
	{
		ClearIconCache();

		//using var psf = new ShellFolder(@"C:\Temp");
		using var psf = new ShellFolder(KNOWNFOLDERID.FOLDERID_SkyDriveDocuments);
		ShellIconExtractor extr = new(psf, bmpSize: 96);
		var tw = TestContext.Out;
		ManualResetEvent evt = new(false);
		extr.IconExtracted += (s, e) => tw.WriteLine($"{e.ItemID} = {e.ImageListIndex}");
		extr.Complete += (s, e) => { tw.WriteLine("Done"); evt.Set(); };
		extr.Start();
		Assert.That(evt.WaitOne(5000), Is.True);
	}

	private static void ClearIconCache() => Assert.That(SystemVolumeCache.CreateInitializedInstance().Purge(), ResultIs.Successful);

	/*[Test]
		public void CreateTest()
		{
			Ole32.CoInitialize();
			new MyForm().ShowDialog();
			Ole32.CoUninitialize();
		}

		public class MyForm : Form
		{
			const int icoSz = 64;
			readonly Timer timer = new Timer { Interval = 5000 };
			readonly ShellIconExtractor extr;
			readonly ShellDataTable data;
			private ListView lv;
			private readonly System.Threading.CancellationTokenSource cTokSrc = new System.Threading.CancellationTokenSource();
			private readonly List<(string, int)> misses = new List<(string, int)>();

			public MyForm()
			{
				SIZE = new SIZE(700, 800);
				StartPosition = FormStartPosition.CenterScreen;
				TopMost = true;
				FormClosing += (s, e) => cTokSrc.Cancel();
				Load += MyForm_Load;

				var fld = new ShellFolder(TestCaseSources.TempDir);
				data = new ShellDataTable(fld);
				extr = new ShellIconExtractor(fld) { ImageSize = icoSz };
				Controls.Add(lv = new ListView() { Dock = DockStyle.Fill, LargeImageList = extr.ImageList, View = View.LargeIcon });

				data.RowChanged += (s, e) => { if (e.Action == System.Data.DataRowAction.Add) lv.Invoke((MethodInvoker)(() => { lv.Items.Add(new ListViewItem(e.Row[0].ToString()) { Name = data.GetPIDL(e.Row).ToString(SIGDN.SIGDN_DESKTOPABSOLUTEPARSING) }); })); };
				extr.IconExtracted += (s, e) => lv.Invoke((MethodInvoker)(() =>
				{
					var str = e.ItemID.ToString(SIGDN.SIGDN_DESKTOPABSOLUTEPARSING);
					var lvi = lv.Items[str];
					if (lvi != null)
					{
						lvi.ImageIndex = e.ImageListIndex;
						lv.Refresh();
					}
					else
						misses.Add((str, e.ImageListIndex));
				}));
				timer.Tick += (s, e) => { timer.Enabled = false; Close(); };
				//timer.Enabled = true;
			}

			private async void MyForm_Load(object sender, EventArgs e)
			{
				await data.RefreshAsync(cTokSrc.Token);
				//await System.Threading.Tasks.Task.Delay(500);
				await extr.GetIconsAsync(cTokSrc.Token);
				foreach (var i in misses)
					lv.Items[i.Item1].ImageIndex = i.Item2;
				misses.Clear();
				lv.Refresh();
			}

			//protected override void OnPaint(PaintEventArgs e)
			//{
			//	using var psf = new ShellFolder(TestCaseSources.TempDir);
			//	var isf = psf.IShellFolder;
			//	var pt = e.ClipRectangle.Location;
			//	var span = icoSz + padSz;
			//	foreach (var pidl in isf.EnumObjects(SHCONTF.SHCONTF_FOLDERS | SHCONTF.SHCONTF_NONFOLDERS | SHCONTF.SHCONTF_INCLUDEHIDDEN))
			//	{
			//		try
			//		{
			//			var lsz = icoSz;
			//			using var hlbmp = ShellIconExtractor.LoadThumbnail(isf, pidl, ref lsz);
			//			var ssz = icoSz2;
			//			using var hsbmp = ShellIconExtractor.LoadThumbnail(isf, pidl, ref ssz);

			//			if (hlbmp != null)
			//			{
			//				var bmp = hlbmp.ToBitmap();
			//				e.Graphics.DrawImage(bmp, new Rectangle(pt.X + padSz, pt.Y + padSz, bmp.Width, bmp.Height), new Rectangle(POINT.Empty, bmp.Size));
			//			}
			//			if (hsbmp != null)
			//			{
			//				var bmp = hsbmp.ToBitmap();
			//				e.Graphics.DrawImage(bmp, new Rectangle(pt.X + padSz * 2 + (int)icoSz, pt.Y + padSz, bmp.Width, bmp.Height), new Rectangle(POINT.Empty, bmp.Size));
			//			}
			//		}
			//		catch
			//		{
			//		}
			//		var x = pt.X + span;
			//		pt = x > (e.ClipRectangle.Right - span) ? new POINT(e.ClipRectangle.Left, pt.Y + (int)icoSz + (padSz * 2)) : new POINT(x, pt.Y);
			//	}
			//}
		}

		[Test]
		public void GetIconLocationTest()
		{
			//using var psf = ShellItem.Open("shell:::{20D04FE0-3AEA-1069-A2D8-08002B30309D}") as ShellFolder;
			using var psf = new ShellFolder(TestCaseSources.TempDir);
			var isf = psf.IShellFolder;
			var list = new List<long>();
			foreach (var pidl in isf.EnumObjects(SHCONTF.SHCONTF_FOLDERS | SHCONTF.SHCONTF_NONFOLDERS | SHCONTF.SHCONTF_INCLUDEHIDDEN))
			{
				var watch = Stopwatch.StartNew();
				var (hr, file, iIdx, wFlags) = GetIconLocation(isf, pidl);
				watch.Stop();
				list.Add(watch.ElapsedMilliseconds);
				TestContext.WriteLine($"{watch.ElapsedMilliseconds,4} = {pidl}; {hr.ToString().TrimEnd('\r', '\n')}; {file},{iIdx}; {wFlags}");
			}
		}

		[Test]
		public void ExtractTest()
		{
			//using var psf = ShellItem.Open("shell:::{20D04FE0-3AEA-1069-A2D8-08002B30309D}") as ShellFolder;
			using var psf = new ShellFolder(TestCaseSources.TempDir);
			var isf = psf.IShellFolder;
			var list = new List<long>();
			foreach (var pidl in isf.EnumObjects(SHCONTF.SHCONTF_FOLDERS | SHCONTF.SHCONTF_NONFOLDERS | SHCONTF.SHCONTF_INCLUDEHIDDEN))
			{
				var watch = Stopwatch.StartNew();
				var loc = GetIconLocation(isf, pidl);
				if (loc.hr.Failed) { watch.Stop(); continue; }
				var hr = ExtractIcons(isf, pidl, loc.file, loc.iIdx, 32, 16, out var ilg, out var ism);
				watch.Stop();
				list.Add(watch.ElapsedMilliseconds);
				TestContext.WriteLine($"{watch.ElapsedMilliseconds,4} = {pidl}; {hr.ToString().TrimEnd('\r', '\n')};");
				ilg?.Dispose(); ism?.Dispose();
			}
		}

		static (HRESULT hr, string file, int iIdx, GetIconLocationResultFlags wFlags) GetIconLocation(IShellFolder psf, PIDL pidl, GetIconLocationFlags flags = GetIconLocationFlags.GIL_FORSHELL)
		{
			var szIconFile = new StringBuilder(Kernel32.MAX_PATH);
			HRESULT hr;
			if (psf.GetUIObjectOf(HWND.NULL, 1, new[] { (IntPtr)pidl }, typeof(IExtractIconW).GUID, default, out var eiw).Succeeded)
			{
				try
				{
					hr = ((IExtractIconW)eiw).GetIconLocation(flags, szIconFile, szIconFile.Capacity, out var piTempIcon, out var wFlags);
					return (hr, hr.Succeeded ? szIconFile.ToString() : null, piTempIcon, wFlags);
				}
				finally
				{
					Marshal.ReleaseComObject(eiw);
				}
			}
			else if ((hr = psf.GetUIObjectOf(default, 1, new[] { (IntPtr)pidl }, typeof(IExtractIconA).GUID, default, out var ei)).Succeeded)
			{
				try
				{
					hr = ((IExtractIconA)ei).GetIconLocation(flags, szIconFile, szIconFile.Capacity, out var piTempIcon, out var wFlags);
					return (hr, hr.Succeeded ? szIconFile.ToString() : null, piTempIcon, wFlags);
				}
				finally
				{
					Marshal.ReleaseComObject(ei);
				}
			}
			return (hr, null, 0, 0);
		}

		static HRESULT ExtractIcons(IShellFolder psf, PIDL pidl, string szIconFile, int iIndex, ushort lg, ushort sm, out SafeHICON hIcoLg, out SafeHICON hIcoSm)
		{
			HRESULT hr;

			//// Try IShellIcon first to get icon from system
			//if (psf is IShellIcon shi)
			//{
			//	hr = shi.GetIconOf(pidl, flags, out var iIndex);
			//	if (hr.Succeeded)
			//	{
			//		SHGetImageList((SHIL)iconSize, typeof(IImageList).GUID, out var il).ThrowIfFailed();
			//		return il.GetIcon(index, IMAGELISTDRAWFLAGS.ILD_TRANSPARENT);
			//	}
			//}

			// Try IExtractIcon(A&W) next to extract icons
			if (psf.GetUIObjectOf(default, 1, new[] { (IntPtr)pidl }, typeof(IExtractIconW).GUID, default, out var eiw).Succeeded)
			{
				try
				{
					return ((IExtractIconW)eiw).Extract(szIconFile, (uint)iIndex, lg, out hIcoLg, sm, out hIcoSm);
				}
				finally
				{
					Marshal.ReleaseComObject(eiw);
				}
			}
			else if ((hr = psf.GetUIObjectOf(default, 1, new[] { (IntPtr)pidl }, typeof(IExtractIconA).GUID, default, out var ei)).Succeeded)
			{
				try
				{
					return ((IExtractIconA)ei).Extract(szIconFile, (uint)iIndex, lg, out hIcoLg, sm, out hIcoSm);
				}
				finally
				{
					Marshal.ReleaseComObject(ei);
				}
			}

			//// Try SHGetFileInfo last
			//if (SHGetIDListFromObject(psf, out var fpidl).Succeeded)
			//{
			//	var shfi = new SHFILEINFO();
			//	var ptr = SHGetFileInfo(PIDL.Combine(fpidl, pidl), 0, ref shfi, SHFILEINFO.Size, SHGFI.SHGFI_ICON | SHGFI.SHGFI_ADDOVERLAYS | SHGFI.SHGFI_PIDL);
			//}
			hIcoLg = hIcoSm = null;
			return hr;
		}
	}*/
}