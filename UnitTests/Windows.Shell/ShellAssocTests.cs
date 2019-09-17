using NUnit.Framework;
using System;
using static Vanara.PInvoke.Shell32;

namespace Vanara.Windows.Shell.Tests
{
	[TestFixture]
	public class ShellAssocTests
	{
		[Test]
		public void ShellAssocTest()
		{
			var sha = ShellAssociation.FileAssociations[".xlsx"];
			Assert.That(sha.FriendlyAppName, Is.EqualTo(@"Excel"));
		}

		[Test]
		public void ReadProgIDTest()
		{
			using (var pi = new ProgId("Word.Document.12"))
			{
				Assert.That(pi.ReadOnly, Is.True);
				Assert.That(pi.DefaultIcon.ToString(), Is.EqualTo(@"C:\Program Files (x86)\Microsoft Office\Root\VFS\Windows\Installer\{90160000-000F-0000-0000-0000000FF1CE}\wordicon.exe,13"));
				Assert.That(pi.AllowSilentDefaultTakeOver, Is.False);
				Assert.That(pi.AppUserModelID, Is.Null);
				Assert.That(pi.EditFlags, Is.EqualTo(PInvoke.ShlwApi.FILETYPEATTRIBUTEFLAGS.FTA_None));
				Assert.That(pi.Verbs, Has.Count.EqualTo(8));
				Assert.That(pi.Verbs["Close"], Is.Null);
				//Assert.That(pi.Verbs["New"].DisplayName, Is.EqualTo("&New"));
			}
			using (var pi = new ProgId("Acrobat.Document.DC"))
			{
				Assert.That(pi.EditFlags, Is.EqualTo(PInvoke.ShlwApi.FILETYPEATTRIBUTEFLAGS.FTA_OpenIsSafe));
				Assert.That(pi.CLSID, Is.EqualTo(new Guid("{B801CA65-A1FC-11D0-85AD-444553540000}")));
				Assert.That(pi.Verbs["Print"].Command, Has.Length.GreaterThan(0));
			}
			using (var pi = new ProgId("CABFolder"))
			{
				Assert.That(pi.EditFlags, Is.EqualTo(PInvoke.ShlwApi.FILETYPEATTRIBUTEFLAGS.FTA_SafeForElevation));
				Assert.That(pi.FriendlyTypeName.ToString(), Is.EqualTo(@"@C:\WINDOWS\system32\cabview.dll,-20"));
				Assert.That(pi.FriendlyTypeName.Value, Has.Length.GreaterThan(0));
				Assert.That(pi.InfoTip.ToString(), Is.EqualTo(@"@C:\WINDOWS\system32\cabview.dll,-21"));
				Assert.That((pi.InfoTip as IndirectString)?.Value, Has.Length.GreaterThan(0));
			}
			using (var pi = new ProgId("cdafile"))
				Assert.That(pi.Verbs, Has.Count.EqualTo(0));
			using (var pi = new ProgId("Msi.Package"))
			{
				Assert.That(pi.Verbs, Has.Count.EqualTo(4));
				Assert.That(pi.Verbs.Order, Has.Count.EqualTo(4));
				Assert.That(pi.Verbs.Order[3].Name, Is.EqualTo("runasuser"));
			}
		}

		[Test]
		public void WriteProgIDTest()
		{
			const string sProgId = "My.Crazy.1";
			const string testStr = "Testing123";

			ShellRegistrar.UnregisterProgID(sProgId);

			using (var progid = ShellRegistrar.RegisterProgID(sProgId, "Testing Vanara ProgId"))
			using (var reg = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(sProgId))
			{
				Assert.That(reg, Is.Not.Null);
				Assert.That(reg.GetValue(null).ToString(), Is.EqualTo(progid.FriendlyName));
				Assert.That(progid.ID, Is.EqualTo(sProgId));
				Assert.That(progid.ReadOnly, Is.False);

				progid.AllowSilentDefaultTakeOver = true;
				Assert.That(progid.AllowSilentDefaultTakeOver, Is.True);
				progid.AllowSilentDefaultTakeOver = false;
				Assert.That(progid.AllowSilentDefaultTakeOver, Is.False);

				progid.AppUserModelID = testStr;
				Assert.That(progid.AppUserModelID, Is.EqualTo(testStr));
				progid.AppUserModelID = null;
				Assert.That(progid.AppUserModelID, Is.Null);

				var g = Guid.NewGuid();
				progid.CLSID = g;
				Assert.That(progid.CLSID.Value, Is.EqualTo(g));
				progid.CLSID = null;
				Assert.That(progid.CLSID, Is.Null);

				var i = new IconLocation(Vanara.PInvoke.Tests.TestCaseSources.ResourceFile, -1);
				progid.DefaultIcon = i;
				Assert.That(progid.DefaultIcon.ToString(), Is.EqualTo(i.ToString()));
				progid.DefaultIcon = null;
				Assert.That(progid.DefaultIcon, Is.Null);

				var f = PInvoke.ShlwApi.FILETYPEATTRIBUTEFLAGS.FTA_NoEditIcon | PInvoke.ShlwApi.FILETYPEATTRIBUTEFLAGS.FTA_NoEdit;
				progid.EditFlags = f;
				Assert.That(progid.EditFlags, Is.EqualTo(f));
				progid.EditFlags = 0;
				Assert.That(progid.EditFlags, Is.EqualTo(PInvoke.ShlwApi.FILETYPEATTRIBUTEFLAGS.FTA_None));

				var fn = new IndirectString(Vanara.PInvoke.Tests.TestCaseSources.ResourceFile, -1);
				progid.FriendlyTypeName = fn;
				Assert.That(progid.FriendlyTypeName.ToString(), Is.EqualTo(fn.ToString()));
				progid.FriendlyTypeName = null;
				Assert.That(progid.FriendlyTypeName, Is.Null);

				progid.InfoTip = fn;
				Assert.That(progid.InfoTip.ToString(), Is.EqualTo(fn.ToString()));
				progid.InfoTip = null;
				Assert.That(progid.InfoTip, Is.Null);

				var vopen = progid.Verbs.Add("Open", "&Open", "notepad.exe %1");
				var vprint = progid.Verbs.Add("Print", "&Print", "notepad.exe %1");
				var vend = progid.Verbs.Add("Terminate", "&End", "notepad.exe %1");
				progid.Verbs.Order = new[] { vend, vprint };
			}
		}
	}
}