using NUnit.Framework;
using NUnit.Framework.Internal;
using static Vanara.PInvoke.User32;
using static Vanara.PInvoke.MsftEdit;
using static Vanara.PInvoke.Macros;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class MsftEditTests
{
	[OneTimeSetUp]
	public void _Setup()
	{
		MsftEditThreadInit();
	}

	[OneTimeTearDown]
	public void _TearDown()
	{
	}

	[Test]
	public void IRichEditOleTest()
	{
		SafeHWND? hEdit = null;
		VisibleWindow.Run(WndProc, System.Reflection.MethodBase.GetCurrentMethod()!.Name);

		IntPtr WndProc(HWND hwnd, uint msg, IntPtr wParam, IntPtr lParam)
		{
			System.Diagnostics.Debug.WriteLine($"TestWndProc={(WindowMessage)msg}");
			try
			{
				switch (msg)
				{
					case (uint)WindowMessage.WM_CREATE:
						GetClientRect(hwnd, out var rc);
						hEdit = CreateWindowEx(0, MSFTEDIT_CLASS, "Type here.", (WindowStyles)EditStyle.ES_MULTILINE | WindowStyles.WS_VISIBLE | WindowStyles.WS_CHILD | WindowStyles.WS_BORDER | WindowStyles.WS_TABSTOP, 0, 0, rc.Width, rc.Height, hwnd);
						IRichEditOle iEdit = RichEdit_GetOleInterface(hEdit);
						Assert.That(iEdit, Is.Not.Null);
						Assert.That(iEdit.GetLinkCount(), Is.Zero);
						ITextDocument2 iDoc = (ITextDocument2)iEdit;
						Assert.That(iDoc, Is.Not.Null);
						Assert.That(iDoc.GetDefaultTabStop(), Is.Not.Zero);
						iDoc.Open(TestCaseSources.TempDirWhack + "Test.rtf");
						Assert.That(iDoc.GetName(), Is.SamePath(TestCaseSources.TempDirWhack + "Test.rtf"));
						Assert.That(iDoc.GetSaved(), Is.EqualTo(tomConstants.tomTrue));
						var iFont = iDoc.GetDocumentFont();
						Assert.That(iFont, Is.Not.Null);
						TestContext.WriteLine($"Font: {iFont.GetName()}, {iFont.GetSize()}, {iFont.GetForeColor():X}");
						break;
					case (uint)WindowMessage.WM_SIZE:
						if (hEdit is not null)
							MoveWindow(hEdit, 0, 0, LOWORD(lParam), HIWORD(lParam), true);
						return default;
				}
			}
			catch (Exception ex)
			{
				TestContext.Error.WriteLine(ex.ToString());
			}
			return DefWindowProc(hwnd, msg, wParam, lParam);
		}
	}
}