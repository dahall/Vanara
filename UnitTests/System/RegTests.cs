using NUnit.Framework;
using System.Threading;

namespace Vanara.Registry.Tests;

[TestFixture]
public class RegTests
{
	[Test, Apartment(ApartmentState.MTA)]
	public void TestRegMonitor()
	{
		const string subkey = @"Software\Vanara";
		const string subkey2 = "Test";

		using var m = new RegistryEventMonitor { RegistryKeyName = @"HKEY_CURRENT_USER\" + subkey, IncludeSubKeys = true };
		using var evVal = new AutoResetEvent(false);
		using var evKey = new AutoResetEvent(false);
		m.ValueChanged += (s, e) => { TestContext.WriteLine("Value changed."); evVal.Set(); };
		m.SubkeyChanged += (s, e) => { TestContext.WriteLine("Subkey changed."); evKey.Set(); };

		using var k = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(subkey, true);
		Assert.That(k, Is.Not.Null);
		k!.DeleteSubKeyTree(subkey2, false);
		m.EnableRaisingEvents = true;

		evKey.Reset();
		var sk = k!.CreateSubKey(subkey2);
		Assert.That(evKey.WaitOne(100));

		evVal.Reset();
		sk.SetValue("uint", 2U, Microsoft.Win32.RegistryValueKind.DWord);
		sk.DeleteValue("uint");
		Assert.That(evVal.WaitOne(100));

		m.IncludeSubKeys = false;
		Assert.That(m.EnableRaisingEvents, Is.False);

		evVal.Reset();
		m.EnableRaisingEvents = true;
		k.SetValue("uint", 2U, Microsoft.Win32.RegistryValueKind.DWord);
		k.DeleteValue("uint");
		Assert.That(evVal.WaitOne(100));

		evVal.Reset();
		sk.SetValue("uint", 2U, Microsoft.Win32.RegistryValueKind.DWord);
		Assert.That(evVal.WaitOne(100), Is.False);

		evKey.Reset();
		m.IncludeSubKeys = false;
		m.EnableRaisingEvents = true;
		k.DeleteSubKey(subkey2, true);
		Assert.That(evKey.WaitOne(100));
	}
}
