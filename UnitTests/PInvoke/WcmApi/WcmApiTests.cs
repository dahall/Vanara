using NUnit.Framework;
using System.Linq;
using Vanara.PInvoke.Tests;
using static Vanara.PInvoke.WcmApi;
using static Vanara.PInvoke.WlanApi;

namespace WcmApi;

public class Tests
{
	private bool? conn;
	private SafeHWLANSESSION hWlan = null;
	private Guid? intf;
	private string profName;

	private Guid PrimaryInterface
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

	private string ProfileName
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

	private bool WlanConnected
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
	public void WcmGetProfileListTest()
	{
		Assert.That(WcmGetProfileList(default, out var list), ResultIs.Successful);
		Assert.That(list.dwNumberOfItems, Is.EqualTo(list.ProfileInfo.Length));
		list.WriteValues();
	}

	[Test]
	public void WcmQueryPropertyTest([Values] WCM_PROPERTY e)
	{
		var t = CorrespondingTypeAttribute.GetCorrespondingTypes(e, CorrespondingAction.Get).FirstOrDefault();
		if (t is null) Assert.Pass($"{e} ignored.");
		TestContext.WriteLine($"{e}");
		uint sz;
		SafeWcmMemory data;
		var global = e.ToString().Contains("_global_");
		if (global)
			Assert.That(WcmQueryProperty(IntPtr.Zero, IntPtr.Zero, e, default, out sz, out data), ResultIs.Successful);
		else
			Assert.That(WcmQueryProperty(PrimaryInterface, ProfileName, e, default, out sz, out data), ResultIs.Successful);
		if (data != null && !data.IsInvalid)
		{
			data.DangerousGetHandle().Convert(sz, t).WriteValues();
			//t = CorrespondingTypeAttribute.GetCorrespondingTypes(e, CorrespondingAction.Set).FirstOrDefault();
			//if (t is null) Assert.Pass($"Set {e} ignored.");
			//if (global)
			//	Assert.That(WcmSetProperty(IntPtr.Zero, IntPtr.Zero, e, default, sz, data), ResultIs.Successful);
			//else
			//	Assert.That(WcmSetProperty(PrimaryInterface, ProfileName, e, default, sz, data), ResultIs.Successful);
			data.Dispose();
		}
	}

	[Test]
	public void WcmQueryPropertyTest2()
	{
		Assert.That(WcmQueryProperty(WCM_PROPERTY.wcm_global_property_domain_policy, ppData: out WCM_POLICY_VALUE data), ResultIs.Successful);
		Assert.That(data.fValue, Is.False);
	}

	[Test]
	public void WcmSetProfileListTest()
	{
		var list = new WCM_PROFILE_INFO_LIST { dwNumberOfItems = 1, ProfileInfo = new[] { new WCM_PROFILE_INFO { AdapterGUID = PrimaryInterface, strProfileName = ProfileName, Media = WCM_MEDIA_TYPE.wcm_media_wlan } } };
		Assert.That(WcmSetProfileList(list, 0, true), ResultIs.Successful);
	}

	[Test]
	public void WcmSetPropertyTest()
	{
		var data = new WCM_DATAPLAN_STATUS
		{
			InboundBandwidthInKbps = WCM_UNKNOWN_DATAPLAN_STATUS,
			MaxTransferSizeInMegabytes = WCM_UNKNOWN_DATAPLAN_STATUS,
			OutboundBandwidthInKbps = WCM_UNKNOWN_DATAPLAN_STATUS,
			DataLimitInMegabytes = 10240,
			BillingCycle = new WCM_BILLING_CYCLE_INFO
			{
				Duration = new WCM_TIME_INTERVAL { wMonth = 1 },
				Reset = true,
				StartDate = DateTime.Now.ToFileTimeStruct()
			}
		};
		Assert.That(WcmSetProperty(WCM_PROPERTY.wcm_intf_property_dataplan_status, PrimaryInterface, ProfileName, data), ResultIs.Successful);
	}

	[Test]
	public void WcmSetPropertyTest2()
	{
		var data = new WCM_CONNECTION_COST_DATA { ConnectionCost = WCM_CONNECTION_COST.WCM_CONNECTION_COST_FIXED };
		Assert.That(WcmSetProperty(WCM_PROPERTY.wcm_intf_property_connection_cost, PrimaryInterface, ProfileName, data), ResultIs.Successful);
		//var data = new WCM_POLICY_VALUE { fIsGroupPolicy = false, fValue = false };
		//Assert.That(WcmSetProperty(WCM_PROPERTY.wcm_global_property_roaming_policy, null, ProfileName, data), ResultIs.Successful);
	}
}