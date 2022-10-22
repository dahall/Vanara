using NUnit.Framework;
using System;
using Vanara.InteropServices;
using Vanara.PInvoke;
using Vanara.PInvoke.Tests;
using static Vanara.PInvoke.WlanApi;

namespace WlanApi
{
	[TestFixture]
	public class AdhocTests
	{
		public const string ADHOC_PWD = "adhocpwd4testing";
		public const string ADHOC_SSID = "ADHOCWIFI";
		public const int geoId = 244; // USA

		[Test]
		public void AdhocMgrTest()
		{
			IDot11AdHocManager AdHocManager = new();
			cManagerSink mSink = new();
			using var pConnectionPointContainer = new ComConnectionPoint(AdHocManager, mSink);

			var networks = AdHocManager.GetIEnumDot11AdHocNetworks();

			IDot11AdHocNetwork myNet = null;
			foreach (var network in new Vanara.Collections.IEnumFromCom<IDot11AdHocNetwork>(networks.Next, networks.Reset))
			{
				var ssid = network.GetSSID();
				TestContext.WriteLine("\tssid = {0}", ssid);
				if (ssid == ADHOC_SSID)
					myNet = network;
			}

			var sink = new cSink();
			if (myNet is not null)
			{
				using var netcp = new ComConnectionPoint(myNet, sink);
				myNet.Connect(ADHOC_PWD, geoId, false, false);
			}
			else
			{
				var securitySettings = new cSecuritySettings();
				myNet = AdHocManager.CreateNetwork(ADHOC_SSID, ADHOC_PWD, geoId, default, securitySettings);
				using var netcp = new ComConnectionPoint(myNet, sink);
				AdHocManager.CommitCreatedNetwork(myNet, false, false);
			}
		}

		private class cManagerSink : IDot11AdHocManagerNotificationSink
		{
			HRESULT IDot11AdHocManagerNotificationSink.OnInterfaceAdd(IDot11AdHocInterface pIAdHocInterface)
			{
				TestContext.Write("[ManagerNotif] New interface\n");
				return HRESULT.S_OK;
			}

			HRESULT IDot11AdHocManagerNotificationSink.OnInterfaceRemove(in Guid Signature)
			{
				TestContext.Write("[ManagerNotif] interface removed\n");
				return HRESULT.S_OK;
			}

			HRESULT IDot11AdHocManagerNotificationSink.OnNetworkAdd(IDot11AdHocNetwork pIAdHocNetwork)
			{
				TestContext.Write("[ManagerNotif] New network : {0}\n", pIAdHocNetwork.GetSSID());
				return HRESULT.S_OK;
			}

			HRESULT IDot11AdHocManagerNotificationSink.OnNetworkRemove(in Guid Signature)
			{
				TestContext.Write("[ManagerNotif] network removed\n");
				return HRESULT.S_OK;
			}
		}

		private class cSecuritySettings : IDot11AdHocSecuritySettings
		{
			DOT11_ADHOC_AUTH_ALGORITHM IDot11AdHocSecuritySettings.GetDot11AuthAlgorithm() => DOT11_ADHOC_AUTH_ALGORITHM.DOT11_ADHOC_AUTH_ALGO_80211_OPEN;

			DOT11_ADHOC_CIPHER_ALGORITHM IDot11AdHocSecuritySettings.GetDot11CipherAlgorithm() => DOT11_ADHOC_CIPHER_ALGORITHM.DOT11_ADHOC_CIPHER_ALGO_WEP;
		}

		private class cSink : IDot11AdHocNetworkNotificationSink
		{
			HRESULT IDot11AdHocNetworkNotificationSink.OnConnectFail(DOT11_ADHOC_CONNECT_FAIL_REASON reason)
			{
				TestContext.WriteLine($"[NetworkNotif] Connection failed : {reason}");
				return HRESULT.S_OK;
			}

			HRESULT IDot11AdHocNetworkNotificationSink.OnStatusChange(DOT11_ADHOC_NETWORK_CONNECTION_STATUS status)
			{
				TestContext.WriteLine($"[NetworkNotif] Status changed : {status}");
				return HRESULT.S_OK;
			}
		}
	}
}