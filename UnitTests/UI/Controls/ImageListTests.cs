using NUnit.Framework;
using System;
using System.Windows.Forms;
using Vanara.Extensions;
using static Vanara.PInvoke.ComCtl32;
using System.Drawing;
using Vanara.PInvoke;

namespace Vanara.Windows.Forms.Tests
{
	[TestFixture]
	public class ImageListTests
	{
		[Test]
		public void GetIImageListTest()
		{
			var il = new ImageList();
			var iil = il.GetIImageList();
			Assert.That(iil, Is.Not.Null);
			Assert.That(iil.GetImageCount(), Is.Zero);
		}

		[Test]
		public void ImageListFromHandleTest()
		{
			var himl = ImageList_Create(32, 32, ILC.ILC_COLOR32 | ILC.ILC_MASK, 8, 8);
			himl.Interface.Add((Image.FromFile(@"C:\Temp\TriggerTypeLogon.png", true) as Bitmap).GetHbitmap(), IntPtr.Zero);
			Assert.That(himl.IsInvalid, Is.False);
			var il2 = ImageListExtension.ImageListFromHandle(himl);
			Assert.That(il2.HandleCreated, Is.True);
			Assert.That(il2.ColorDepth, Is.EqualTo(ColorDepth.Depth32Bit));
			Assert.That(il2.ImageSize, Is.EqualTo(new Size(32, 32)));
			Assert.That(il2.Images.Count, Is.EqualTo(1));
		}

		[Test]
		public void AddOverlayAndDrawTest()
		{
			var il = new ImageList() { ColorDepth = ColorDepth.Depth32Bit, ImageSize = new Size(32, 32) };
			il.Images.Add(new Icon(@"C:\Temp\help.ico"));
			Assert.That(il.Images.Count, Is.EqualTo(1));
			var ovIdx = il.AddOverlay(new Bitmap(@"C:\Temp\overlay32.png"), Color.Transparent);
			Assert.That(il.Images.Count, Is.EqualTo(2));
			var bmp = new Bitmap(32, 32, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
			using (var g = Graphics.FromImage(bmp))
				il.Draw(g, new Rectangle(0, 0, 32, 32), 0, Color.Transparent, COLORREF.None, overlayImageIndex: ovIdx);
			ShowImage(bmp);
		}

		[Test]
		public void MergeTest()
		{
			var il = new ImageList() { ColorDepth = ColorDepth.Depth32Bit, ImageSize = new Size(32, 32) };
			il.SetBackgroundColor(Color.Transparent);
			var img1 = Image.FromFile(@"C:\Temp\tsnew32.png", true);
			il.Images.Add(img1, Color.Transparent);
			ShowImage(il.Images[0]);
			var il2 = new ImageList() { ColorDepth = ColorDepth.Depth32Bit, ImageSize = new Size(32, 32) };
			il2.SetBackgroundColor(Color.Transparent);
			var img2 = Image.FromFile(@"C:\Temp\TriggerTypeLogon.png", true);
			il2.Images.Add(img2, Color.Transparent);
			ShowImage(il2.Images[0]);
			var ico = il.MergeImage(0, il2, 0);
			ShowImage(ico.ToAlphaBitmap());
		}

		internal static void ShowImage(Image img, [System.Runtime.CompilerServices.CallerMemberName] string title = "", int timeOut = 3)
		{
			Application.EnableVisualStyles();
			var frm = new Form { Size = new Size(300, 300), FormBorderStyle = FormBorderStyle.Sizable, Text = title };
			var pbox = new PictureBox { Dock = DockStyle.Fill, Image = img, SizeMode = PictureBoxSizeMode.CenterImage };
			pbox.DoubleClick += (s, e) => pbox.SizeMode = PictureBoxSizeMode.Zoom;
			frm.KeyDown += (s, e) => frm.BackColor = Color.Red;
			frm.Controls.Add(pbox);
			if (timeOut > 0)
				frm.Shown += (s,e) => FormTimeout();
			frm.ShowDialog();

			void FormTimeout()
			{
				var t = new Timer { Interval = timeOut * 1000 };
				t.Tick += (s, e) => { t.Stop(); frm.Close(); };
				t.Start();
			}
		}
	}
}