using NUnit.Framework;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using static Vanara.PInvoke.WlanApi;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class WlanApiTests
{
	private SafeHWLANSESSION hWlan = new(IntPtr.Zero, false);
	private Guid? intf;
	private bool? conn;
	private string? profName;

	Guid PrimaryInterface
	{
		[MemberNotNull(nameof(intf))]
		get
		{
			if (!intf.HasValue)
			{
				WlanEnumInterfaces(hWlan, default, out var list).ThrowIfFailed();
				if (list.dwNumberOfItems < 1)
					throw new InvalidOperationException("No WLAN interfaces.");
				var i = list.InterfaceInfo.FirstOrDefault(i => i.isState == WLAN_INTERFACE_STATE.wlan_interface_state_connected);
				if (i.InterfaceGuid == default) throw new InvalidOperationException("No WLAN devices are connected");
				intf = i.InterfaceGuid;
				conn = i.isState == WLAN_INTERFACE_STATE.wlan_interface_state_connected;
			}
			return intf.Value;
		}
	}

	string ProfileName
	{
		[MemberNotNull(nameof(profName))]
		get
		{
			if (profName is null)
			{
				WlanGetProfileList(hWlan, PrimaryInterface, default, out var list).ThrowIfFailed();
				if (list.dwNumberOfItems < 1)
					throw new InvalidOperationException("No WLAN interfaces.");
				profName = list.ProfileInfo[0].strProfileName;
			}
			return profName;
		}
	}

	bool WlanConnected
	{
		[MemberNotNull(nameof(conn))]
		get
		{
			if (!conn.HasValue)
			{
				_ = PrimaryInterface;
				conn ??= false;
			}
			return conn.Value;
		}
	}

	[OneTimeSetUp]
	public void _Setup() => hWlan = WlanOpenHandle();

	[OneTimeTearDown]
	public void _TearDown() => hWlan?.Dispose();

	[Test]
	public void DOT11_SSIDEncodingTest()
	{
		const string ssidStr = "₩ ¶頻xt52~$&-/@ш저反O し";
		DOT11_SSID ssid = new(ssidStr);
		var utf8 = Encoding.UTF8.GetBytes(ssidStr);
		Assert.That(ssid.ucSSID, Is.EqualTo(utf8));
		Assert.That(ssid.ucSSID.Length, Is.EqualTo(32));
		Assert.That(ssid.uSSIDLength, Is.EqualTo(utf8.Length));
		Assert.That(ssid.ToString(), Is.EqualTo(ssidStr));
	}

	[Test]
	public void WlanAllocateMemoryTest()
	{
		SafeHWLANMEM mem;
		Assert.That(mem = WlanAllocateMemory(256), ResultIs.ValidHandle);
		Assert.That(mem.Dispose, Throws.Nothing);
	}

	[Test]
	public void WlanConnectDisconnectTest()
	{
		Assert.That(WlanConnected);
		Assert.That(WlanGetAvailableNetworkList(hWlan, PrimaryInterface, 3, default, out var list), ResultIs.Successful);
		Assert.That(list.Network.Length, Is.GreaterThan(0));

		var p = new WLAN_CONNECTION_PARAMETERS
		{
			wlanConnectionMode = WLAN_CONNECTION_MODE.wlan_connection_mode_profile,
			strProfile = list.Network[0].strProfileName,
			dot11BssType = list.Network[0].dot11BssType
		};
		Assert.That(WlanConnect(hWlan, PrimaryInterface, p), ResultIs.Successful);
		Assert.That(WlanDisconnect(hWlan, PrimaryInterface), ResultIs.Successful);
	}

	[Test]
	public void WlanEnumInterfacesTest()
	{
		Assert.That(WlanEnumInterfaces(hWlan, default, out var list), ResultIs.Successful);
		Assert.That(list.dwNumberOfItems, Is.GreaterThan(0U));
		Assert.That(list.InterfaceInfo.Length, Is.EqualTo(list.dwNumberOfItems));
		TestContext.Write(string.Join("\n", list.InterfaceInfo.Select(ii => $"{ii.InterfaceGuid}: {ii.strInterfaceDescription} ({ii.isState})")));
	}

	[Test]
	public void WlanGetAvailableNetworkListTest()
	{
		Assert.That(WlanConnected);
		Assert.That(WlanGetAvailableNetworkList(hWlan, PrimaryInterface, 3, default, out var list), ResultIs.Successful);
		Assert.That(list.dwNumberOfItems, Is.GreaterThan(0U));
		Assert.That(list.Network.Length, Is.EqualTo(list.dwNumberOfItems));
		TestContext.Write(string.Join("\n", list.Network.Select(n => $"{n.strProfileName}, {n.dot11BssType}, con={n.bNetworkConnectable}, qual={n.wlanSignalQuality}, sec={n.bSecurityEnabled}")));
	}

	[Test]
	public void WlanGetFilterListTest([Values] WLAN_FILTER_LIST_TYPE listType)
	{
		Assert.That(WlanGetFilterList(hWlan, listType, default, out var list), ResultIs.Successful);
		if (list is null)
			TestContext.WriteLine($"{listType} => [none]");
		else
		{
			Assert.That(list.dwNumberOfItems, Is.GreaterThan(0U));
			Assert.That(list.Network.Length, Is.EqualTo(list.dwNumberOfItems));
			TestContext.WriteLine("{0} => {1}", listType, string.Join(", ", list.Network.Select(n => $"{n.dot11Ssid} : {n.dot11BssType}")));
		}
	}

	[Test]
	public void WlanGetInterfaceCapabilityTest()
	{
		Assert.That(WlanGetInterfaceCapability(hWlan, PrimaryInterface, default, out var list), ResultIs.Successful);
		Assert.That(list.dwNumberOfSupportedPhys, Is.GreaterThan(0U));
		TestContext.Write($"{list.interfaceType} = " + string.Join(",", list.dot11PhyTypes.Take((int)list.dwNumberOfSupportedPhys)));
	}

	[Test]
	public void WlanGetNetworkBssListTest()
	{
		Assert.That(WlanGetNetworkBssList(hWlan, PrimaryInterface, IntPtr.Zero, DOT11_BSS_TYPE.dot11_BSS_type_any, true, default, out var mem), ResultIs.Successful);
		var totalSize = mem.DangerousGetHandle().ToStructure<uint>();
		Assert.That(totalSize, Is.GreaterThanOrEqualTo((uint)Marshal.SizeOf<WLAN_BSS_LIST>()));
		TestContext.WriteLine($"Size: {totalSize}");
		var list = mem.DangerousGetHandle().ToStructure<WLAN_BSS_LIST>(totalSize)!;
		Assert.That(list.dwNumberOfItems, Is.GreaterThan(0U));
		Assert.That(list.wlanBssEntries.Length, Is.EqualTo(list.dwNumberOfItems));
		TestContext.Write(string.Join("\n", list.wlanBssEntries.Select(e => $"{e.uPhyId}\t{e.dot11Bssid}\t{e.dot11BssType}\t{e.dot11BssPhyType}\tstr={e.lRssi}\tper={e.usBeaconPeriod}\tfrq={e.ulChCenterFrequency}\t{e.ulIeOffset}:{e.ulIeSize}")));
	}

	[Test]
	public void WlanGetNetworkBssListTest2()
	{
		Assert.That(WlanQueryInterface(hWlan, PrimaryInterface, WLAN_INTF_OPCODE.wlan_intf_opcode_current_connection, default, out _, out SafeHWLANMEM? data, out _), ResultIs.Successful);
		var connectionAttributes = data.DangerousGetHandle().ToStructure<WLAN_CONNECTION_ATTRIBUTES>();
		Assert.That(WlanGetNetworkBssList(hWlan, PrimaryInterface, connectionAttributes.wlanAssociationAttributes.dot11Ssid, connectionAttributes.wlanAssociationAttributes.dot11BssType,
			connectionAttributes.wlanSecurityAttributes.bSecurityEnabled, default, out var mem), ResultIs.Successful);
		var totalSize = mem.DangerousGetHandle().ToStructure<uint>();
		TestContext.WriteLine($"Size: {totalSize}");
		Assert.That(totalSize, Is.GreaterThanOrEqualTo((uint)Marshal.SizeOf<WLAN_BSS_LIST>()));
		var list = mem.DangerousGetHandle().ToStructure<WLAN_BSS_LIST>(totalSize)!;
		Assert.That(list.dwNumberOfItems, Is.GreaterThan(0U));
		Assert.That(list.wlanBssEntries.Length, Is.EqualTo(list.dwNumberOfItems));
		TestContext.Write(string.Join("\n", list.wlanBssEntries.Select(e => $"{e.uPhyId}\t{e.dot11Bssid}\t{e.dot11BssType}\t{e.dot11BssPhyType}\tstr={e.lRssi}\tper={e.usBeaconPeriod}\tfrq={e.ulChCenterFrequency}\t{e.ulIeOffset}:{e.ulIeSize}")));
	}

	[Test]
	public void WlanGetProfileTest()
	{
		WLAN_PROFILE_FLAGS flags = 0;
		Assert.That(WlanGetProfile(hWlan, PrimaryInterface, ProfileName, default, out var xml, ref flags, out var access), ResultIs.Successful);
		Assert.That(string.IsNullOrEmpty(xml), Is.False);
		Assert.That((uint)access, Is.Not.Zero);
		TestContext.WriteLine($"{access}");
		TestContext.Write(xml);
	}

	[Test]
	public void WlanGetProfileCustomUserDataTest()
	{
		var err = WlanGetProfileCustomUserData(hWlan, PrimaryInterface, ProfileName, default, out var sz, out var mem);
		if (err.Succeeded)
			TestContext.Write(mem.DangerousGetHandle().ToHexDumpString((int)sz));
		else if (err == Win32Error.ERROR_FILE_NOT_FOUND)
			TestContext.Write("[No data]");
		else
			Assert.That(err, ResultIs.Successful);
	}

	[Test]
	public void WlanGetProfileListTest()
	{
		Assert.That(WlanGetProfileList(hWlan, PrimaryInterface, default, out var list), ResultIs.Successful);
		Assert.That(list.dwNumberOfItems, Is.GreaterThan(0U));
		Assert.That(list.ProfileInfo.Length, Is.EqualTo(list.dwNumberOfItems));
		TestContext.Write(string.Join("\n", list.ProfileInfo.Select(pi => $"{pi.strProfileName} ({pi.dwFlags})")));
	}

	[Test]
	public void WlanGetSecuritySettingsTest([Values] WLAN_SECURABLE_OBJECT e)
	{
		if (e == WLAN_SECURABLE_OBJECT.WLAN_SECURABLE_OBJECT_COUNT) return;
		Assert.That(WlanGetSecuritySettings(hWlan, e, out var value, out var sddl, out var access), ResultIs.Successful);
		TestContext.WriteLine($"{e}: {access}, {value}\n\t{sddl}");
	}

	[Test]
	public void WlanGetSupportedDeviceServicesTest()
	{
		var err = WlanGetSupportedDeviceServices(hWlan, PrimaryInterface, out var list);
		if (err == Win32Error.ERROR_NO_DATA) return;
		Assert.That(err, ResultIs.Successful);
		Assert.That(list.dwNumberOfItems, Is.GreaterThan(0U));
		Assert.That(list.DeviceService.Length, Is.EqualTo(list.dwNumberOfItems));
		TestContext.Write(string.Join("\n", list.DeviceService));
	}

	[Test]
	public void WlanHostedNetworkQueryPropertyTest([Values] WLAN_HOSTED_NETWORK_OPCODE e)
	{
		var err = WlanHostedNetworkQueryProperty(hWlan, e, out var sz, out var data, out var type);
		if (err == Win32Error.ERROR_BAD_CONFIGURATION) return;
		Assert.That(err, ResultIs.Successful);
		TestContext.WriteLine($"{e} = {type}");
		var t = CorrespondingTypeAttribute.GetCorrespondingTypes(e, CorrespondingAction.Get).First()!;
		data.DangerousGetHandle().Convert(sz, t)!.WriteValues();
	}

	[Test]
	public void WlanHostedNetworkQuerySecondaryKeyTest()
	{
		Assert.That(WlanHostedNetworkQuerySecondaryKey(hWlan, out var len, out var data, out var isPassPhrase, out var isPersist, out var reason), ResultIs.Successful);
		TestContext.WriteLine($"IsPassPhrase={isPassPhrase}, IsPersisent={isPersist}, FailReason={reason}");
		if (len > 0) TestContext.Write(data.DangerousGetHandle().ToHexDumpString((int)len));
	}

	[Test]
	public void WlanHostedNetworkQueryStatusTest()
	{
		Assert.That(WlanHostedNetworkQueryStatus(hWlan, out var stat), ResultIs.Successful);
		stat.WriteValues();
	}

	[Test]
	public void WlanHostedNetworkRefreshSecuritySettingsTest()
	{
		Assert.That(WlanHostedNetworkRefreshSecuritySettings(hWlan, out _), ResultIs.Successful);
	}

	[Test]
	public void WlanHostedNetworkSetPropertyTest()
	{
		using var mem = SafeHGlobalHandle.CreateFromStructure(new BOOL(true));
		Assert.That(WlanHostedNetworkSetProperty(hWlan, WLAN_HOSTED_NETWORK_OPCODE.wlan_hosted_network_opcode_enable, mem.Size, mem, out var reason), ResultIs.Successful);
	}

	[Test]
	public void WlanHostedNetworkSetSecondaryKeyTest()
	{
		const string ssid = "NZ@McD";
		WLAN_HOSTED_NETWORK_CONNECTION_SETTINGS s = new() { dwMaxNumberOfPeers = 20, hostedNetworkSSID = new(ssid) };
		Assert.That(WlanHostedNetworkSetProperty(hWlan, WLAN_HOSTED_NETWORK_OPCODE.wlan_hosted_network_opcode_connection_settings, (uint)Marshal.SizeOf<WLAN_HOSTED_NETWORK_CONNECTION_SETTINGS>(), SafeHGlobalHandle.CreateFromStructure(s), out _), ResultIs.Successful);
		using var mem = new SafeCoTaskMemHandle([0x1E, 0xD7, 0xD2, 0x39, 0X0E, 0x76, 0x67, 0xA4, 0xAE, 0xE1, 0xF4, 0xAB, 0x3B, 0x16, 0x45, 0x02, 0x8D, 0x04, 0x10, 0xEE, 0x80, 0x53, 0xCF, 0xDB, 0x71, 0x2D, 0x7C, 0x30, 0x00, 0x46, 0xDD, 0xF6]);
		Assert.That(WlanHostedNetworkSetSecondaryKey(hWlan, mem.Size, mem, false, false, out _), ResultIs.Successful);
	}

	[Test]
	public void WlanIhvControlTest()
	{
		using var mem = new SafeHGlobalHandle(128);
		using var omem = new SafeHGlobalHandle(128);
		Assert.That(WlanIhvControl(hWlan, PrimaryInterface, WLAN_IHV_CONTROL_TYPE.wlan_ihv_control_type_service, mem.Size, mem, omem.Size, omem, out _), ResultIs.Successful);
	}

	[Test]
	public void WlanOpenCloseHandleTest()
	{
		Assert.That(WlanOpenHandle(WLAN_API_VERSION, default, out var ver, out var h), ResultIs.Successful);
		Assert.That(ver, Is.EqualTo(WLAN_API_VERSION));
		Assert.That(h, ResultIs.ValidHandle);
		Assert.That(h.Dispose, Throws.Nothing);
	}

	[Test]
	public void WlanQueryAutoConfigParameterTest([Values] WLAN_AUTOCONF_OPCODE e)
	{
		var t = CorrespondingTypeAttribute.GetCorrespondingTypes(e, CorrespondingAction.Get).FirstOrDefault();
		if (t is null) return;
		Assert.That(WlanQueryAutoConfigParameter(hWlan, e, default, out var sz, out var data, out var type), ResultIs.Successful);
		TestContext.WriteLine($"{e} = {type}");
		data.DangerousGetHandle().Convert(sz, t)!.WriteValues();
	}

	[Test]
	public void WlanQueryInterfaceTest([Values] WLAN_INTF_OPCODE e)
	{
		var t = CorrespondingTypeAttribute.GetCorrespondingTypes(e, CorrespondingAction.Get).FirstOrDefault();
		if (t is null) return;
		if (WlanQueryInterface(hWlan, PrimaryInterface, e, default, out var sz, out var data, out var type).Failed) return;
		TestContext.WriteLine($"{e} = {type}");
		data.DangerousGetHandle().Convert(sz, t)!.WriteValues();
	}

	[Test]
	public void WlanRegisterDeviceServiceNotificationTest()
	{
		Assert.That(WlanRegisterDeviceServiceNotification(hWlan, null), ResultIs.Successful);
	}

	[Test]
	public void WlanRegisterNotificationTest()
	{
		Assert.That(WlanRegisterNotification(hWlan, WLAN_NOTIFICATION_SOURCE.WLAN_NOTIFICATION_SOURCE_ALL, true, Callback, default, default, out var prev), ResultIs.Successful);

		static void Callback(ref WLAN_NOTIFICATION_DATA Arg1, IntPtr Arg2) => Arg1.WriteValues();
	}

	[Test]
	public void WlanRegisterVirtualStationNotificationTest()
	{
		Assert.That(WlanRegisterVirtualStationNotification(hWlan, false), ResultIs.Successful);
	}

	[Test]
	public void WlanRenameProfileTest()
	{
		var oldpn = ProfileName;
		var newpn = "Testing123";
		Assert.That(WlanRenameProfile(hWlan, PrimaryInterface, oldpn, newpn), ResultIs.Successful);
		Assert.That(WlanRenameProfile(hWlan, PrimaryInterface, newpn, oldpn), ResultIs.Successful);
	}

	[Test]
	public void WlanSaveTemporaryProfileTest()
	{
		Assert.That(WlanSaveTemporaryProfile(hWlan, PrimaryInterface, ProfileName, null, 0, true), ResultIs.Successful);
	}

	[Test]
	public void WlanScanTest()
	{
		Assert.That(WlanScan(hWlan, PrimaryInterface), ResultIs.Successful);
	}

	[Test]
	public void WlanSetAutoConfigParameterTest([Values] WLAN_AUTOCONF_OPCODE e)
	{
		var t = CorrespondingTypeAttribute.GetCorrespondingTypes(e, CorrespondingAction.Set).FirstOrDefault();
		if (t is null) return;
		Assert.That(WlanQueryAutoConfigParameter(hWlan, e, default, out var sz, out var data, out _), ResultIs.Successful);
		Assert.That(WlanSetAutoConfigParameter(hWlan, e, sz, data), ResultIs.Successful);
	}

	[Test]
	public void WlanSetFilterListTest()
	{
		Assert.That(WlanGetFilterList(hWlan, WLAN_FILTER_LIST_TYPE.wlan_filter_list_type_user_permit, default, out var filters), ResultIs.Successful);

		Assert.That(WlanSetFilterList(hWlan, WLAN_FILTER_LIST_TYPE.wlan_filter_list_type_user_permit, null), ResultIs.Successful);
		Assert.That(WlanGetFilterList(hWlan, WLAN_FILTER_LIST_TYPE.wlan_filter_list_type_user_permit, default, out var clearedfilters), ResultIs.Successful);
		Assert.That(clearedfilters.dwNumberOfItems, Is.EqualTo(0U));

		DOT11_NETWORK_LIST allow_filters = new(
		[
			new("TestFilter1", DOT11_BSS_TYPE.dot11_BSS_type_infrastructure),
			new("TestFilter2", DOT11_BSS_TYPE.dot11_BSS_type_infrastructure),
			new("TestFilter3", DOT11_BSS_TYPE.dot11_BSS_type_infrastructure),
		]);
		Assert.That(WlanSetFilterList(hWlan, WLAN_FILTER_LIST_TYPE.wlan_filter_list_type_user_permit, allow_filters), ResultIs.Successful);

		Assert.That(WlanGetFilterList(hWlan, WLAN_FILTER_LIST_TYPE.wlan_filter_list_type_user_permit, default, out var addedfilters), ResultIs.Successful);
		Assert.That(addedfilters.dwNumberOfItems, Is.EqualTo(allow_filters.dwNumberOfItems));

		Assert.That(WlanSetFilterList(hWlan, WLAN_FILTER_LIST_TYPE.wlan_filter_list_type_user_permit, filters), ResultIs.Successful);
	}

	[Test]
	public void WlanSetInterfaceTest([Values] WLAN_INTF_OPCODE e)
	{
		var t = CorrespondingTypeAttribute.GetCorrespondingTypes(e, CorrespondingAction.Set).FirstOrDefault();
		if (t is null || e == WLAN_INTF_OPCODE.wlan_intf_opcode_radio_state) return;
		if (WlanQueryInterface(hWlan, PrimaryInterface, e, default, out var sz, out var data, out _).Failed) return;
		Assert.That(WlanSetInterface(hWlan, PrimaryInterface, e, sz, data), ResultIs.Successful);
	}

	[Test]
	public void WlanSetProfileTest()
	{
		WLAN_PROFILE_FLAGS flags = 0;
		Assert.That(WlanGetProfile(hWlan, PrimaryInterface, ProfileName, default, out var xml, ref flags, out _), ResultIs.Successful);
		Assert.That(WlanSetProfile(hWlan, PrimaryInterface, flags, xml, null, true, default, out var reason), ResultIs.Successful);
		var sb = new StringBuilder(255);
		Assert.That(WlanReasonCodeToString(reason, (uint)sb.Capacity, sb), ResultIs.Successful);
		TestContext.Write(sb);
	}

	[Test]
	public void WlanSetProfileCustomUserDataTest()
	{
		var err = WlanGetProfileCustomUserData(hWlan, PrimaryInterface, ProfileName, default, out var sz, out var mem);
		if (err.Failed) return;
		Assert.That(WlanSetProfileCustomUserData(hWlan, PrimaryInterface, ProfileName, sz, mem), ResultIs.Successful);
	}

	[Test]
	public void WlanSetProfileEapUserDataTest()
	{
		//Assert.That(WlanSetProfileEapUserData(), ResultIs.Successful);
		Assert.Pass("No test.");
	}

	[Test]
	public void WlanSetProfileEapXmlUserDataTest()
	{
		//Assert.That(WlanSetProfileEapXmlUserData(), ResultIs.Successful);
		Assert.Pass("No test.");
	}

	[Test]
	public void WlanSetProfileListTest()
	{
		Assert.That(WlanGetProfileList(hWlan, PrimaryInterface, default, out var list), ResultIs.Successful);
		var pnl = list.ProfileInfo.Select(p => p.strProfileName).Where(p => !string.IsNullOrEmpty(p)).ToArray();
		Assert.That(WlanSetProfileList(hWlan, PrimaryInterface, (uint)pnl.Length, pnl), ResultIs.Successful);
	}

	[Test]
	public void WlanSetProfilePositionTest()
	{
		Assert.That(WlanSetProfilePosition(hWlan, PrimaryInterface, ProfileName, 0), ResultIs.Successful);
	}

	[Test]
	public void WlanSetPsdIEDataListTest()
	{
		//Assert.That(WlanSetPsdIEDataList(), ResultIs.Successful);
		Assert.Pass("No test.");
	}

	[Test]
	public void WlanSetSecuritySettingsTest()
	{
		Assert.That(WlanGetSecuritySettings(hWlan, WLAN_SECURABLE_OBJECT.wlan_secure_permit_list, out _, out var sddl, out _), ResultIs.Successful);
		Assert.That(WlanSetSecuritySettings(hWlan, WLAN_SECURABLE_OBJECT.wlan_secure_permit_list, sddl), ResultIs.Successful);
	}

	[Test]
	public void WlanUIEditProfileTest()
	{
		Assert.That(WlanUIEditProfile(1, ProfileName, PrimaryInterface, HWND.NULL, WL_DISPLAY_PAGES.WLConnectionPage, default, out _), ResultIs.Successful);
	}
}