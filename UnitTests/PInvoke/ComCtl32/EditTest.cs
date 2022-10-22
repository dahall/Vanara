﻿using System;
using System.Windows.Forms;
using NUnit.Framework;
using static Vanara.PInvoke.ComCtl32;
using static Vanara.PInvoke.User32;

namespace Vanara.PInvoke.Tests
{
	[TestFixture]
	public class ButtonTest
	{
		[Test]
		public void TestMethod1()
		{
			Application.EnableVisualStyles();
			var f = new Form { Size = new System.Drawing.Size(100, 100) };
			var btn = new TextBox { Size = new System.Drawing.Size(50, 12), Location = new POINT(5, 5) };
			var tip = new EDITBALLOONTIP("Test", "tested");
			btn.HandleCreated += (s, a) => SendMessage(btn.Handle, EditMessage.EM_SHOWBALLOONTIP, 0, ref tip);
			f.Controls.Add(btn);
			f.ShowDialog();
		}
	}
}
