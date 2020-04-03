using NUnit.Framework;
using System;
using System.Linq;
using System.Text;
using Vanara;
using Vanara.Extensions;
using Vanara.InteropServices;
using Vanara.PInvoke;
using Vanara.PInvoke.Tests;
using static Vanara.PInvoke.WlanApi;

namespace WlanApi
{
	public class Tests
	{
		private SafeHWLANSESSION hWlan = null;
		private Guid? intf;
		private bool? conn;
		private string profName;

		Guid PrimaryInterface
		{
			get
			{
				if (!intf.HasValue)
				{
					WlanEnumInterfaces(hWlan, default, out var list).ThrowIfFailed();
					if (list.dwNumberOfItems < 1)
						throw new InvalidOperationException("No WLAN interfaces.");
					intf = list.InterfaceInfo[0].InterfaceGuid;
					conn = list.InterfaceInfo[0].isState == WLAN_INTERFACE_STATE.wlan_interface_state_connected;
				}
				return intf.Value;
			}
		}

		string ProfileName
		{
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
			get
			{
				if (!conn.HasValue)
				{
					var g = PrimaryInterface;
				}
				return conn.Value;
			}
		}

		[OneTimeSetUp]
		public void _Setup() => hWlan = WlanOpenHandle();

		[OneTimeTearDown]
		public void _TearDown() => hWlan?.Dispose();

		[Test]
		public void WlanAllocateMemoryTest()
		{
			SafeHWLANMEM mem;
			Assert.That(mem = WlanAllocateMemory(256), ResultIs.ValidHandle);
			Assert.That(() => mem.Dispose(), Throws.Nothing);
		}

		[Test]
		public void WlanConnectDisconnectTest()
		{
			Assert.IsTrue(WlanConnected);
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
			Assert.IsTrue(WlanConnected);
			Assert.That(WlanGetAvailableNetworkList(hWlan, PrimaryInterface, 3, default, out var list), ResultIs.Successful);
			Assert.That(list.dwNumberOfItems, Is.GreaterThan(0U));
			Assert.That(list.Network.Length, Is.EqualTo(list.dwNumberOfItems));
			TestContext.Write(string.Join("\n", list.Network.Select(n => $"{n.strProfileName}, {n.dot11BssType}, con={n.bNetworkConnectable}, qual={n.wlanSignalQuality}, sec={n.bSecurityEnabled}")));
		}

		[Test]
		public void WlanGetFilterListTest()
		{
			foreach (WLAN_FILTER_LIST_TYPE e in Enum.GetValues(typeof(WLAN_FILTER_LIST_TYPE)))
			{
				Assert.That(WlanGetFilterList(hWlan, e, default, out var list), ResultIs.Successful);
				if (list is null)
					TestContext.WriteLine($"{e} => [none]");
				else
				{
					Assert.That(list.dwNumberOfItems, Is.GreaterThan(0U));
					Assert.That(list.Network.Length, Is.EqualTo(list.dwNumberOfItems));
					TestContext.WriteLine("{0} => {1}", e, string.Join(", ", list.Network.Select(n => $"{n.dot11BssType}")));
				}
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
			var list = mem.DangerousGetHandle().ToStructure<WLAN_BSS_LIST>();
			TestContext.WriteLine($"Size: {list.dwTotalSize}");
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
		public void WlanGetSecuritySettingsTest()
		{
			foreach (WLAN_SECURABLE_OBJECT e in Enum.GetValues(typeof(WLAN_SECURABLE_OBJECT)))
			{
				if (e == WLAN_SECURABLE_OBJECT.WLAN_SECURABLE_OBJECT_COUNT) continue;
				Assert.That(WlanGetSecuritySettings(hWlan, e, out var value, out var sddl, out var access), ResultIs.Successful);
				TestContext.WriteLine($"{e}: {access}, {value}\n\t{sddl}");
			}
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
		public void WlanHostedNetworkQueryPropertyTest()
		{
			foreach (WLAN_HOSTED_NETWORK_OPCODE e in Enum.GetValues(typeof(WLAN_HOSTED_NETWORK_OPCODE)))
			{
				var err = WlanHostedNetworkQueryProperty(hWlan, e, out var sz, out var data, out var type);
				if (err == Win32Error.ERROR_BAD_CONFIGURATION) continue;
				Assert.That(err, ResultIs.Successful);
				TestContext.WriteLine($"{e} = {type}");
				var t = CorrespondingTypeAttribute.GetCorrespondingTypes(e, CorrespondingAction.Get).First();
				data.DangerousGetHandle().Convert(sz, t).WriteValues();
			}
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
			using var mem = new SafeHGlobalHandle(128);
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
			Assert.That(() => h.Dispose(), Throws.Nothing);
		}

		[Test]
		public void WlanQueryAutoConfigParameterTest()
		{
			foreach (WLAN_AUTOCONF_OPCODE e in Enum.GetValues(typeof(WLAN_AUTOCONF_OPCODE)))
			{
				var t = CorrespondingTypeAttribute.GetCorrespondingTypes(e, CorrespondingAction.Get).FirstOrDefault();
				if (t is null) continue;
				Assert.That(WlanQueryAutoConfigParameter(hWlan, e, default, out var sz, out var data, out var type), ResultIs.Successful);
				TestContext.WriteLine($"{e} = {type}");
				data.DangerousGetHandle().Convert(sz, t).WriteValues();
			}
		}

		[Test]
		public void WlanQueryInterfaceTest()
		{
			foreach (WLAN_INTF_OPCODE e in Enum.GetValues(typeof(WLAN_INTF_OPCODE)))
			{
				var t = CorrespondingTypeAttribute.GetCorrespondingTypes(e, CorrespondingAction.Get).FirstOrDefault();
				if (t is null) continue;
				if (WlanQueryInterface(hWlan, PrimaryInterface, e, default, out var sz, out var data, out var type).Failed) continue;
				TestContext.WriteLine($"{e} = {type}");
				data.DangerousGetHandle().Convert(sz, t).WriteValues();
			}
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

			void Callback(ref WLAN_NOTIFICATION_DATA Arg1, IntPtr Arg2)
			{
				Arg1.WriteValues();
			}
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
			Assert.That(WlanSaveTemporaryProfile(hWlan, PrimaryInterface, ProfileName, null, WLAN_PROFILE_FLAGS.WLAN_PROFILE_CONNECTION_MODE_SET_BY_CLIENT, false), ResultIs.Successful);
		}

		[Test]
		public void WlanScanTest()
		{
			Assert.That(WlanScan(hWlan, PrimaryInterface), ResultIs.Successful);
		}

		[Test]
		public void WlanSetAutoConfigParameterTest()
		{
			foreach (WLAN_AUTOCONF_OPCODE e in Enum.GetValues(typeof(WLAN_AUTOCONF_OPCODE)))
			{
				var t = CorrespondingTypeAttribute.GetCorrespondingTypes(e, CorrespondingAction.Set).FirstOrDefault();
				if (t is null) continue;
				Assert.That(WlanQueryAutoConfigParameter(hWlan, e, default, out var sz, out var data, out var type), ResultIs.Successful);
				Assert.That(WlanSetAutoConfigParameter(hWlan, e, sz, data), ResultIs.Successful);
			}
		}

		[Test]
		public void WlanSetFilterListTest()
		{
			Assert.That(WlanSetFilterList(hWlan, WLAN_FILTER_LIST_TYPE.wlan_filter_list_type_user_permit, null), ResultIs.Successful);
		}

		[Test]
		public void WlanSetInterfaceTest()
		{
			foreach (WLAN_INTF_OPCODE e in Enum.GetValues(typeof(WLAN_INTF_OPCODE)))
			{
				var t = CorrespondingTypeAttribute.GetCorrespondingTypes(e, CorrespondingAction.Set).FirstOrDefault();
				if (t is null || e == WLAN_INTF_OPCODE.wlan_intf_opcode_radio_state) continue;
				if (WlanQueryInterface(hWlan, PrimaryInterface, e, default, out var sz, out var data, out var type).Failed) continue;
				Assert.That(WlanSetInterface(hWlan, PrimaryInterface, e, sz, data), ResultIs.Successful);
			}
		}

		[Test]
		public void WlanSetProfileTest()
		{
			WLAN_PROFILE_FLAGS flags = 0;
			Assert.That(WlanGetProfile(hWlan, PrimaryInterface, ProfileName, default, out var xml, ref flags, out var access), ResultIs.Successful);
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
			Assert.That(WlanUIEditProfile(1, ProfileName, PrimaryInterface, HWND.NULL, WL_DISPLAY_PAGES.WLConnectionPage, default, out var reason), ResultIs.Successful);
		}
	}
}