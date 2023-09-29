namespace Vanara.Windows.Forms.Tests;

[TestFixture()]
public class VisualThemeTests
{
	[Test()]
	public void ConstructorTest()
	{
		var th = new VisualTheme("AeroWizard");
		Assert.That(th.Handle.IsInvalid, Is.False);
		th.Dispose();
		Assert.That(th.Handle.IsInvalid, Is.True);

		th = new VisualTheme(new IntPtr(1));
		Assert.That(th.Handle.IsInvalid, Is.False);
		th.Dispose();
		Assert.That(th.Handle.IsInvalid, Is.False);

		var form = new Form() { Size = new System.Drawing.Size(100, 100) };
		form.Show();
		th = new VisualTheme(form, "BUTTON");
		Assert.That(th.Handle.IsInvalid, Is.False);
		th.Dispose();
		Assert.That(th.Handle.IsInvalid, Is.True);
		form.Close();
	}

	[Test()]
	public void GetBitmapTest()
	{
		using (var th = new VisualTheme("Button"))
		{
			Assert.That(th.GetBitmap(2, 1, VisualTheme.BitmapProperty.BackgroundImage), Is.Null);
			Assert.That(th.GetBitmap(2, 1, VisualTheme.BitmapProperty.GlyphImage), Is.Not.Null);
			Assert.That(th.GetBitmap(2, 1, VisualTheme.BitmapProperty.Handle), Is.Null);
		}
	}
}