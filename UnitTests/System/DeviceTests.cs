using NUnit.Framework;
using System.Linq;
using Vanara.PInvoke.Tests;
using static Vanara.PInvoke.SetupAPI;

namespace Vanara.Diagnostics.Tests;

[TestFixture]
public class DeviceTests
{
	[Test]
	public void ClassNamesTest()
	{
		var coll = DeviceManager.LocalInstance.GetSetupClasses();
		Assert.That(coll, Is.Not.Empty);
		TestContext.Write(string.Join("\r\n", coll.Select(c => c.Description).OrderBy(s => s)));
	}

	[Test]
	public void ClassPropsTest()
	{
		using var cl = new DeviceClass("DiskDrive");
		cl.Guid.WriteValues();
		cl.Name.WriteValues();
		cl.Description.WriteValues();
		cl.BitmapIndex.WriteValues();
		cl.ImageIndex.WriteValues();
		cl.NoDisplay.WriteValues();
		cl.NoInstall.WriteValues();
		foreach (var kv in cl.Properties)
			TestContext.WriteLine($"{kv.Key.LookupName()} = {kv.Value.GetStringVal()}");
		foreach (var kv in cl.RegistryProperties)
			TestContext.WriteLine($"{kv.Key} = {kv.Value.GetStringVal()}");
	}

	[Test]
	public void EnumDevicesTest()
	{
		using var coll = new DeviceCollection(GUID_DEVCLASS_DISKDRIVE);//, null, null, DIGCF.DIGCF_ALLCLASSES);
		var devs = coll.ToArray();
		Assert.That(devs, Is.Not.Empty);
		TestContext.WriteLine($"Found {devs.Length} devices.");
		TestContext.Write(string.Join("\r\n", devs.Select(c => c.Name).OrderBy(s => s)));
	}

	[Test]
	public void PropsTest()
	{
		using var cl = new DeviceClass(GUID_DEVCLASS_DISKDRIVE);
		var devs = cl.GetDevices().ToArray();
		TestContext.WriteLine($"Found {devs.Length} devices.");
		foreach (var dev in devs)
		{
			TestContext.WriteLine(new string('=', 20) + dev.Name + new string('=', 20));
			dev.Description.WriteValues();
			dev.DriverPath.WriteValues();
			dev.InstallFlags.WriteValues();
			dev.InstallFlagsEx.WriteValues();
			dev.InstanceId.WriteValues();
			foreach (var kv in dev.Properties)
				TestContext.WriteLine($"{kv.Key.LookupName()} = {kv.Value.GetStringVal()}");
			foreach (var kv in dev.RegistryProperties)
				TestContext.WriteLine($"{kv.Key} = {kv.Value.GetStringVal()}");
		}
	}

	[Test]
	public void SetClassPropTest()
	{
		using var cl = new DeviceClass(GUID_DEVCLASS_DISKDRIVE);
		var val = cl.Properties[DEVPKEY_DeviceClass_Exclusive];
		Assert.IsNull(val);
		try
		{
			cl.Properties[DEVPKEY_DeviceClass_Exclusive] = false;
			val = cl.Properties[DEVPKEY_DeviceClass_Exclusive];
			Assert.IsFalse((bool)val);
		}
		finally
		{
			Assert.That(cl.Properties.Remove(DEVPKEY_DeviceClass_Exclusive), ResultIs.Successful);
		}
	}

	[Test]
	public void SetClassRegPropTest()
	{
		using var cl = new DeviceClass(GUID_DEVCLASS_DISKDRIVE);
		var val = cl.RegistryProperties[SPCRP.SPCRP_LOWERFILTERS];
		try
		{
			cl.RegistryProperties[SPCRP.SPCRP_LOWERFILTERS] = new[] { "MyFilter" };
			var newval = cl.RegistryProperties[SPCRP.SPCRP_LOWERFILTERS];
			Assert.That(newval, Is.Not.EqualTo(val));
		}
		finally
		{
			cl.RegistryProperties[SPCRP.SPCRP_LOWERFILTERS] = val;
		}
	}
}