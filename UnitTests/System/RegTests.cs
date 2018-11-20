using System;
using Vanara.Registry;
using NUnit.Framework;
using System.Text;
using System.Threading;

namespace Vanara.Registry.Tests
{
	[TestFixture]
	public class RegTests
	{
		[Test]
		public void TestRegMonitor()
		{
			const string subkey = @"Software\Vanara";
			const string subkey2 = "Test";
			var m = new RegistryEventMonitor { RegistryKeyName = @"HKEY_CURRENT_USER\" + subkey, IncludeSubKeys = true };
			var ev1 = new AutoResetEvent(false);
			var ev2 = new AutoResetEvent(false);
			m.ValueChanged += (s, e) => { TestContext.WriteLine("Value changed."); ev1.Set(); };
			m.SubkeyChanged += (s, e) => { TestContext.WriteLine("Subkey changed."); ev2.Set(); };
			m.EnableRaisingEvents = true;
			using (var k = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(subkey, true))
			{
				var sk = k.CreateSubKey(subkey2);
				sk.SetValue("uint", 2U, Microsoft.Win32.RegistryValueKind.DWord);
				sk.DeleteValue("uint");
				Assert.That(WaitHandle.WaitAll(new WaitHandle[] { ev1, ev2 }, 5000));

				m.IncludeSubKeys = false;
				Assert.That(m.EnableRaisingEvents, Is.False);
				ev1.Reset();

				m.EnableRaisingEvents = true;
				k.SetValue("uint", 2U, Microsoft.Win32.RegistryValueKind.DWord);
				k.DeleteValue("uint");
				Assert.That(ev1.WaitOne(100));

				ev1.Reset();
				sk.SetValue("uint", 2U, Microsoft.Win32.RegistryValueKind.DWord);
				Assert.That(ev1.WaitOne(100), Is.False);

				ev2.Reset();
				k.DeleteSubKey(subkey2);
				Assert.That(ev2.WaitOne(1000));
			}
		}
	}
}
