using NUnit.Framework;
using System.Drawing;

namespace Vanara.Windows.Forms.Tests;

[TestFixture()]
public class ThemedControlTests
{
	[OneTimeSetUp]
	public void SetupFixture() => Application.EnableVisualStyles();

	[Test()]
	public void ThemedLabelTest()
	{
		var frm = MakeGlassTestForm();
		var tl = new ThemedLabel { Text = "Test text", GlowingText = false, SupportGlass = false, Location = new System.Drawing.Point(5, 5) };
		tl.SetTheme("Button", 1, 1);
		frm.Controls.Add(tl);
		frm.Controls.Add(new Label { Text = "Control label", Location = new Point(5, 100) });
		frm.ShowDialog();
	}

	[Test()]
	public void ThemedPanelTest()
	{
		var frm = MakeGlassTestForm();

		var t1 = new ThemedPanel { SupportGlass = true, Bounds = new Rectangle(5, 5, 100, 50), UnfocusedStyleState = 2 };
		SetTheme(t1);
		frm.Controls.Add(t1);

		var t2 = new ThemedPanel { SupportGlass = false, Bounds = new Rectangle(155, 5, 100, 50), UnfocusedStyleState = 2 };
		SetTheme(t2);
		frm.Controls.Add(t2);

		var t3 = new ThemedPanel { Bounds = new Rectangle(5, 155, 100, 50), UnfocusedStyleState = 2 };
		SetTheme(t3);
		frm.Controls.Add(t3);

		var t4 = new ThemedPanel { Bounds = new Rectangle(155, 155, 100, 50) };
		SetTheme(t4);
		frm.Controls.Add(t4);

		frm.ShowDialog();

		void SetTheme(ThemedPanel t) => t.SetTheme("Window", 1, 1);
	}

	private static Form MakeGlassTestForm()
	{
		var frm = new Form { Size = new Size(300, 300) };
		frm.HandleCreated += (s, e) => frm.ExtendFrameIntoClientArea(new Padding(0, 150, 0, 0));
		return frm;
	}
}