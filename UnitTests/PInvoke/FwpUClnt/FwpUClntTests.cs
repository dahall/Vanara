using NUnit.Framework;
using NUnit.Framework.Internal;
using Vanara.PInvoke;
using Vanara.PInvoke.Tests;
using static Vanara.PInvoke.FwpUClnt;
using static Vanara.PInvoke.Ws2_32;

namespace FwpUClnt;

[TestFixture]
public class FwpUClntTests
{
	private const string nullStr = "(null)";
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
	private SafeHFWPENG fwpEngineHandle;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

	[OneTimeSetUp]
	public void _Setup() => FwpmEngineOpen0(default, Rpc.RPC_C_AUTHN.RPC_C_AUTHN_WINNT, default, default, out fwpEngineHandle).ThrowIfFailed();

	[OneTimeTearDown]
	public void _TearDown()
	{
	}

	[Test]
	public void FwpmCalloutEnum0Test()
	{
		FWPM_CALLOUT_ENUM_TEMPLATE0 template = new() { layerKey = FWPM_LAYER_DATAGRAM_DATA_V4 };
		using SafeCoTaskMemStruct<FWPM_CALLOUT_ENUM_TEMPLATE0> pTemplate = template;
		FWPM_CALLOUT_SUBSCRIPTION0 subscr = new()
		{
			flags = FWPM_SUBSCRIPTION_FLAG.FWPM_SUBSCRIPTION_FLAG_NOTIFY_ON_ADD,
			//sessionKey = Guid.NewGuid(),
			enumTemplate = pTemplate
		};
		var changed = 0;
		using var pchng = new PinnedObject(changed);

		static void callback(IntPtr context, in FWPM_CALLOUT_CHANGE0 change) { unsafe { *(int*)context = 1; } }
		Assert.That(FwpmCalloutSubscribeChanges0(fwpEngineHandle, subscr, callback, pchng, out HFWPCALLOUTCHANGE hChange), ResultIs.Successful);

		Assert.That(FwpmCalloutSubscriptionsGet0(fwpEngineHandle, out SafeFwpmArray<FWPM_CALLOUT_SUBSCRIPTION0> subs), ResultIs.Successful);
		Assert.That(subs.Count, Is.EqualTo(1));

		FWPM_DISPLAY_DATA0 dd = new() { name = "Datagram-Data Proxy Callout", description = "Datagram-Data Proxy Callout" };
		FWPM_CALLOUT0 callout = new() { calloutKey = Guid.NewGuid(), displayData = dd, applicableLayer = FWPM_LAYER_DATAGRAM_DATA_V4 };
		Assert.That(FwpmCalloutAdd0(fwpEngineHandle, callout, default, out var id), ResultIs.Successful);

		//System.Threading.Thread.SpinWait(200);
		//Assert.That(changed, Is.Not.Zero);
		Assert.That(FwpmCalloutUnsubscribeChanges0(fwpEngineHandle, hChange), ResultIs.Successful);

		Assert.That(FwpmCalloutGetById0(fwpEngineHandle, id, out SafeFwpmStruct<FWPM_CALLOUT0> byId), ResultIs.Successful);
		Assert.True(byId.Value.HasValue && byId.Value.Value.calloutId == id);
		Assert.That(FwpmCalloutGetByKey0(fwpEngineHandle, callout.calloutKey, out SafeFwpmStruct<FWPM_CALLOUT0> byKey), ResultIs.Successful);
		Assert.True(byKey.Value.HasValue && byKey.Value.Value.calloutId == id);
		Assert.That(FwpmCalloutGetSecurityInfoByKey0(fwpEngineHandle, callout.calloutKey,
			SECURITY_INFORMATION.OWNER_SECURITY_INFORMATION|SECURITY_INFORMATION.GROUP_SECURITY_INFORMATION|SECURITY_INFORMATION.DACL_SECURITY_INFORMATION,
			out PSID sOwn, out PSID sGrp, out PACL dacl, out PACL sacl, out SafeFwpmMem sd), ResultIs.Successful);
		Assert.True(!sOwn.IsNull && !sGrp.IsNull && !dacl.IsNull);
		Assert.True(sOwn.IsValidSid() && sGrp.IsValidSid() && dacl.IsValidAcl());

		Assert.That(FwpmCalloutDeleteById0(fwpEngineHandle, id), ResultIs.Successful);

		//-----------------------------------------
		// Get the events from enumeration
		Assert.That(FwpmCalloutEnum0(fwpEngineHandle, out SafeFwpmArray<FWPM_CALLOUT0> h), ResultIs.Successful);
		foreach (FWPM_CALLOUT0 e in h)
		{
			TestContext.WriteLine($"{e.calloutKey}=({e.flags})=========");
			TestContext.WriteLine($"{e.displayData.name ?? nullStr} ({e.displayData.description ?? nullStr})");
			TestContext.WriteLine($"Prov={GetNameOf(e.providerKey.Value.GetValueOrDefault()) ?? nullStr}; Layer={GetNameOf(e.applicableLayer)}");
		}
	}

	[Test]
	public void FwpmConnectionEnum0Test()
	{
		Assert.That(FwpmConnectionEnum0(fwpEngineHandle, out SafeFwpmArray<FWPM_CONNECTION0> h), ResultIs.Successful);
		foreach (FWPM_CONNECTION0 e in h)
		{
			TestContext.WriteLine($"{e.connectionId}==============");
			e.WriteValues();
		}

		FWPM_CONNECTION_ENUM_TEMPLATE0 template = new() { connectionId = 0 };
		using var pTemplate = new SafeCoTaskMemStruct<FWPM_CONNECTION_ENUM_TEMPLATE0>(template);
		FWPM_CONNECTION_SUBSCRIPTION0 subscr = new()
		{
			sessionKey = Guid.NewGuid(),
			enumTemplate = pTemplate
		};
		static void callback(IntPtr context, FWPM_CONNECTION_EVENT_TYPE eventType, in FWPM_CONNECTION0 connection) { }
		Assert.That(FwpmConnectionSubscribe0(fwpEngineHandle, subscr, callback, default, out HFWPCONNEVENT hChange), ResultIs.Successful);
		Assert.That(FwpmConnectionUnsubscribe0(fwpEngineHandle, hChange), ResultIs.Successful);
	}

	[Test]
	public void FwpmFilterEnum0Test()
	{
		Assert.That(FwpmFilterEnum0(fwpEngineHandle, out SafeFwpmArray<FWPM_FILTER0> h), ResultIs.Successful);
		foreach (FWPM_FILTER0 e in h)
		{
			TestContext.WriteLine($"{e.filterKey}=({e.flags})=========");
			TestContext.WriteLine($"{e.displayData.name ?? nullStr} ({e.displayData.description ?? nullStr})");
			TestContext.WriteLine($"Prov={GetNameOf(e.providerKey.Value.GetValueOrDefault()) ?? nullStr}; Layer={GetNameOf(e.layerKey)}");
		}
	}

	[Test]
	public void FwpmIPsecTunnelAdd0Test()
	{
		var policyName = "Unknown";
		Guid providerKey = new("5fb216a8-e2e8-4024-b853-391a4168641e");
		var localAddr = new IN_ADDR(192, 68, 0, 1);
		var remoteAddr = new IN_ADDR(192, 68, 0, 10);

		IPSEC_TUNNEL_ENDPOINTS0 endpoints = new()
		{
			ipVersion = FWP_IP_VERSION.FWP_IP_VERSION_V4,
			localV4Address = localAddr,
			remoteV4Address = remoteAddr
		};

		FWP_BYTE_BLOB presharedKey = new();
		var mmAuthMethods = new IKEEXT_AUTHENTICATION_METHOD0[1];
		mmAuthMethods[0].authenticationMethodType = IKEEXT_AUTHENTICATION_METHOD_TYPE.IKEEXT_PRESHARED_KEY;
		mmAuthMethods[0].presharedKeyAuthentication = new IKEEXT_PRESHARED_KEY_AUTHENTICATION0 { presharedKey = presharedKey };

		var mmProposals = new IKEEXT_PROPOSAL0[1];
		mmProposals[0].cipherAlgorithm.algoIdentifier = IKEEXT_CIPHER_TYPE.IKEEXT_CIPHER_AES_128;
		mmProposals[0].integrityAlgorithm.algoIdentifier = IKEEXT_INTEGRITY_TYPE.IKEEXT_INTEGRITY_SHA1;
		mmProposals[0].maxLifetimeSeconds = 8 * 60 * 60;
		mmProposals[0].dhGroup = IKEEXT_DH_GROUP.IKEEXT_DH_GROUP_2;

		IKEEXT_POLICY0 mmPolicy = new()
		{
			numAuthenticationMethods = (uint)mmAuthMethods.Length,
			authenticationMethods = SafeCoTaskMemHandle.CreateFromList(mmAuthMethods),
			numIkeProposals = (uint)mmProposals.Length,
			ikeProposals = SafeCoTaskMemHandle.CreateFromList(mmProposals)
		};

		FWPM_PROVIDER_CONTEXT0 mmProvCtxt = new();
		mmProvCtxt.displayData.name = policyName;
		mmProvCtxt.providerKey = (SafeCoTaskMemStruct<Guid>)providerKey;
		mmProvCtxt.type = FWPM_PROVIDER_CONTEXT_TYPE.FWPM_IPSEC_IKE_MM_CONTEXT;
		mmProvCtxt.authIpMmPolicy = mmPolicy;

		IPSEC_AUTH_AND_CIPHER_TRANSFORM0 qmTransform00 = new();
		qmTransform00.authTransform.authTransformId = IPSEC_AUTH_TRANSFORM_ID_HMAC_SHA_1_96;
		qmTransform00.cipherTransform.cipherTransformId = IPSEC_CIPHER_TRANSFORM_ID_AES_128;

		IPSEC_SA_LIFETIME0 qmLifetime = new()
		{
			lifetimeSeconds = 3600,
			lifetimeKilobytes = 100000,
			lifetimePackets = 0x7FFFFFFF
		};

		var qmTransforms0 = new IPSEC_SA_TRANSFORM0[1];
		qmTransforms0[0].ipsecTransformType = IPSEC_TRANSFORM_TYPE.IPSEC_TRANSFORM_ESP_AUTH_AND_CIPHER;
		qmTransforms0[0].espAuthAndCipherTransform = qmTransform00;

		var qmProposals = new IPSEC_PROPOSAL0[1];
		qmProposals[0].lifetime = qmLifetime;
		qmProposals[0].numSaTransforms = (uint)qmTransforms0.Length;
		qmProposals[0].saTransforms = SafeCoTaskMemHandle.CreateFromList(qmTransforms0);

		IPSEC_TUNNEL_POLICY0 qmPolicy = new()
		{
			numIpsecProposals = (uint)qmProposals.Length,
			ipsecProposals = SafeCoTaskMemHandle.CreateFromList(qmProposals),
			tunnelEndpoints = endpoints,
			saIdleTimeout = new() { idleTimeoutSeconds = 300, idleTimeoutSecondsFailOver = 60 }
		};

		FWPM_PROVIDER_CONTEXT0 qmProvCtxt = default;
		qmProvCtxt.displayData.name = policyName;
		qmProvCtxt.providerKey = (SafeCoTaskMemStruct<Guid>)providerKey;
		qmProvCtxt.type = FWPM_PROVIDER_CONTEXT_TYPE.FWPM_IPSEC_IKE_QM_TUNNEL_CONTEXT;
		qmProvCtxt.ikeQmTunnelPolicy = qmPolicy;

		FWP_CONDITION_VALUE0 cv1 = new() { type = FWP_DATA_TYPE.FWP_UINT32, uint32 = localAddr };
		FWP_CONDITION_VALUE0 cv2 = new() { type = FWP_DATA_TYPE.FWP_UINT32, uint32 = remoteAddr };
		var filterConditions = new FWPM_FILTER_CONDITION0[] {
			new() { fieldKey = FWPM_CONDITION_IP_LOCAL_ADDRESS, matchType = FWP_MATCH_TYPE.FWP_MATCH_EQUAL, conditionValue = cv1 },
			new() { fieldKey = FWPM_CONDITION_IP_REMOTE_ADDRESS, matchType = FWP_MATCH_TYPE.FWP_MATCH_EQUAL, conditionValue = cv2 },
		};
		Assert.That(FwpmIPsecTunnelAdd0(fwpEngineHandle, FWPM_TUNNEL_FLAG.FWPM_TUNNEL_FLAG_POINT_TO_POINT,
			mmProvCtxt, qmProvCtxt, (uint)filterConditions.Length, filterConditions), ResultIs.Successful);
	}

	[Test]
	public void FwpmLayerEnum0Test()
	{
		Assert.That(FwpmLayerEnum0(fwpEngineHandle, out SafeFwpmArray<FWPM_LAYER0> h), ResultIs.Successful);
		foreach (FWPM_LAYER0 e in h)
		{
			TestContext.WriteLine($"{GetNameOf(e.layerKey)}==========");
			e.WriteValues();
		}
	}

	[Test]
	public void FwpmNetEventEnum0Test()
	{
		//-----------------------------------------
		// Get the events from enumeration
		Assert.That(FwpmNetEventEnum0(fwpEngineHandle, out SafeFwpmArray<FWPM_NET_EVENT0> h), ResultIs.Successful);
		foreach (FWPM_NET_EVENT0 e in h)
		{
			TestContext.WriteLine($"{e.type}===============");
			e.header.WriteValues();
			((object)(e.type switch
			{
				FWPM_NET_EVENT_TYPE.FWPM_NET_EVENT_TYPE_IKEEXT_MM_FAILURE => e.ikeMmFailure.Value,
				FWPM_NET_EVENT_TYPE.FWPM_NET_EVENT_TYPE_IKEEXT_QM_FAILURE => e.ikeQmFailure.Value,
				FWPM_NET_EVENT_TYPE.FWPM_NET_EVENT_TYPE_IKEEXT_EM_FAILURE => e.ikeEmFailure.Value,
				FWPM_NET_EVENT_TYPE.FWPM_NET_EVENT_TYPE_CLASSIFY_DROP => e.classifyDrop.Value,
				FWPM_NET_EVENT_TYPE.FWPM_NET_EVENT_TYPE_IPSEC_KERNEL_DROP => e.ipsecDrop.Value,
				FWPM_NET_EVENT_TYPE.FWPM_NET_EVENT_TYPE_IPSEC_DOSP_DROP => e.idpDrop.Value,
				_ => "",
			})).WriteValues();
		}
	}

	[Test]
	public void FwpmNetEventEnum1Test()
	{
		//-----------------------------------------
		// Get the events from enumeration
		Assert.That(FwpmNetEventEnum1(fwpEngineHandle, out SafeFwpmArray<FWPM_NET_EVENT1> h), ResultIs.Successful);
		foreach (FWPM_NET_EVENT1 e in h)
		{
			TestContext.WriteLine($"{e.type}===============");
			e.header.WriteValues();
			((object)(e.type switch
			{
				FWPM_NET_EVENT_TYPE.FWPM_NET_EVENT_TYPE_IKEEXT_MM_FAILURE => e.ikeMmFailure.Value,
				FWPM_NET_EVENT_TYPE.FWPM_NET_EVENT_TYPE_IKEEXT_QM_FAILURE => e.ikeQmFailure.Value,
				FWPM_NET_EVENT_TYPE.FWPM_NET_EVENT_TYPE_IKEEXT_EM_FAILURE => e.ikeEmFailure.Value,
				FWPM_NET_EVENT_TYPE.FWPM_NET_EVENT_TYPE_CLASSIFY_DROP => e.classifyDrop.Value,
				FWPM_NET_EVENT_TYPE.FWPM_NET_EVENT_TYPE_IPSEC_KERNEL_DROP => e.ipsecDrop.Value,
				FWPM_NET_EVENT_TYPE.FWPM_NET_EVENT_TYPE_IPSEC_DOSP_DROP => e.idpDrop.Value,
				_ => "",
			})).WriteValues();
		}
	}

	[Test]
	public void FwpmNetEventEnum2Test()
	{
		//-----------------------------------------
		// Get the events from enumeration
		Assert.That(FwpmNetEventEnum2(fwpEngineHandle, out SafeFwpmArray<FWPM_NET_EVENT2> h), ResultIs.Successful);
		foreach (FWPM_NET_EVENT2 e in h)
		{
			TestContext.WriteLine($"{e.type}===============");
			e.header.WriteValues();
			((object)(e.type switch
			{
				FWPM_NET_EVENT_TYPE.FWPM_NET_EVENT_TYPE_IKEEXT_MM_FAILURE => e.ikeMmFailure.Value,
				FWPM_NET_EVENT_TYPE.FWPM_NET_EVENT_TYPE_IKEEXT_QM_FAILURE => e.ikeQmFailure.Value,
				FWPM_NET_EVENT_TYPE.FWPM_NET_EVENT_TYPE_IKEEXT_EM_FAILURE => e.ikeEmFailure.Value,
				FWPM_NET_EVENT_TYPE.FWPM_NET_EVENT_TYPE_CLASSIFY_DROP => e.classifyDrop.Value,
				FWPM_NET_EVENT_TYPE.FWPM_NET_EVENT_TYPE_IPSEC_KERNEL_DROP => e.ipsecDrop.Value,
				FWPM_NET_EVENT_TYPE.FWPM_NET_EVENT_TYPE_IPSEC_DOSP_DROP => e.idpDrop.Value,
				_ => "",
			})).WriteValues();
		}
	}

	[Test]
	public void FwpmNetEventEnum3Test()
	{
		//-----------------------------------------
		// Get the events from enumeration
		Assert.That(FwpmNetEventEnum3(fwpEngineHandle, out SafeFwpmArray<FWPM_NET_EVENT3> h), ResultIs.Successful);
		foreach (FWPM_NET_EVENT3 e in h)
		{
			TestContext.WriteLine($"{e.type}===============");
			e.header.WriteValues();
			((object)(e.type switch
			{
				FWPM_NET_EVENT_TYPE.FWPM_NET_EVENT_TYPE_IKEEXT_MM_FAILURE => e.ikeMmFailure.Value,
				FWPM_NET_EVENT_TYPE.FWPM_NET_EVENT_TYPE_IKEEXT_QM_FAILURE => e.ikeQmFailure.Value,
				FWPM_NET_EVENT_TYPE.FWPM_NET_EVENT_TYPE_IKEEXT_EM_FAILURE => e.ikeEmFailure.Value,
				FWPM_NET_EVENT_TYPE.FWPM_NET_EVENT_TYPE_CLASSIFY_DROP => e.classifyDrop.Value,
				FWPM_NET_EVENT_TYPE.FWPM_NET_EVENT_TYPE_IPSEC_KERNEL_DROP => e.ipsecDrop.Value,
				FWPM_NET_EVENT_TYPE.FWPM_NET_EVENT_TYPE_IPSEC_DOSP_DROP => e.idpDrop.Value,
				_ => "",
			})).WriteValues();
		}
	}

	[Test]
	public void FwpmProviderContextEnum0Test()
	{
		Assert.That(FwpmProviderContextEnum0(fwpEngineHandle, out SafeFwpmArray<FWPM_PROVIDER_CONTEXT0> h), ResultIs.Successful);
		foreach (FWPM_PROVIDER_CONTEXT0 e in h)
		{
			TestContext.WriteLine($"{e.type}===============");
			((object)(e.type switch
			{
				FWPM_PROVIDER_CONTEXT_TYPE.FWPM_CLASSIFY_OPTIONS_CONTEXT => e.classifyOptions.Value,
				FWPM_PROVIDER_CONTEXT_TYPE.FWPM_IPSEC_KEYING_CONTEXT => e.keyingPolicy.Value,
				FWPM_PROVIDER_CONTEXT_TYPE.FWPM_IPSEC_IKE_QM_TRANSPORT_CONTEXT => e.ikeQmTransportPolicy.Value,
				FWPM_PROVIDER_CONTEXT_TYPE.FWPM_IPSEC_IKE_QM_TUNNEL_CONTEXT => e.ikeQmTunnelPolicy.Value,
				FWPM_PROVIDER_CONTEXT_TYPE.FWPM_IPSEC_AUTHIP_QM_TRANSPORT_CONTEXT => e.authipQmTransportPolicy.Value,
				FWPM_PROVIDER_CONTEXT_TYPE.FWPM_IPSEC_AUTHIP_QM_TUNNEL_CONTEXT => e.ikeQmTunnelPolicy.Value,
				FWPM_PROVIDER_CONTEXT_TYPE.FWPM_IPSEC_IKE_MM_CONTEXT => e.ikeMmPolicy.Value,
				FWPM_PROVIDER_CONTEXT_TYPE.FWPM_IPSEC_AUTHIP_MM_CONTEXT => e.authIpMmPolicy.Value,
				FWPM_PROVIDER_CONTEXT_TYPE.FWPM_GENERAL_CONTEXT => e.dataBuffer.Value,
				_ => "",
			})).WriteValues();
		}
	}

	[Test]
	public void FwpmProviderContextEnum1Test()
	{
		Assert.That(FwpmProviderContextEnum1(fwpEngineHandle, out SafeFwpmArray<FWPM_PROVIDER_CONTEXT1> h), ResultIs.Successful);
		foreach (FWPM_PROVIDER_CONTEXT1 e in h)
		{
			TestContext.WriteLine($"{e.type}===============");
			((object)(e.type switch
			{
				FWPM_PROVIDER_CONTEXT_TYPE.FWPM_CLASSIFY_OPTIONS_CONTEXT => e.classifyOptions.Value,
				FWPM_PROVIDER_CONTEXT_TYPE.FWPM_IPSEC_KEYING_CONTEXT => e.keyingPolicy.Value,
				FWPM_PROVIDER_CONTEXT_TYPE.FWPM_IPSEC_IKE_QM_TRANSPORT_CONTEXT => e.ikeQmTransportPolicy.Value,
				FWPM_PROVIDER_CONTEXT_TYPE.FWPM_IPSEC_IKE_QM_TUNNEL_CONTEXT => e.ikeQmTunnelPolicy.Value,
				FWPM_PROVIDER_CONTEXT_TYPE.FWPM_IPSEC_AUTHIP_QM_TRANSPORT_CONTEXT => e.authipQmTransportPolicy.Value,
				FWPM_PROVIDER_CONTEXT_TYPE.FWPM_IPSEC_AUTHIP_QM_TUNNEL_CONTEXT => e.ikeQmTunnelPolicy.Value,
				FWPM_PROVIDER_CONTEXT_TYPE.FWPM_IPSEC_IKE_MM_CONTEXT => e.ikeMmPolicy.Value,
				FWPM_PROVIDER_CONTEXT_TYPE.FWPM_IPSEC_AUTHIP_MM_CONTEXT => e.authIpMmPolicy.Value,
				FWPM_PROVIDER_CONTEXT_TYPE.FWPM_GENERAL_CONTEXT => e.dataBuffer.Value,
				FWPM_PROVIDER_CONTEXT_TYPE.FWPM_IPSEC_IKEV2_QM_TUNNEL_CONTEXT => e.ikeV2QmTunnelPolicy.Value,
				FWPM_PROVIDER_CONTEXT_TYPE.FWPM_IPSEC_IKEV2_MM_CONTEXT => e.ikeV2MmPolicy.Value,
				_ => "",
			})).WriteValues();
		}
	}

	[Test]
	public void FwpmProviderContextEnum2Test()
	{
		Assert.That(FwpmProviderContextEnum2(fwpEngineHandle, out SafeFwpmArray<FWPM_PROVIDER_CONTEXT2> h), ResultIs.Successful);
		foreach (FWPM_PROVIDER_CONTEXT2 e in h)
		{
			TestContext.WriteLine($"{e.type}===============");
			((object)(e.type switch
			{
				FWPM_PROVIDER_CONTEXT_TYPE.FWPM_CLASSIFY_OPTIONS_CONTEXT => e.classifyOptions.Value,
				FWPM_PROVIDER_CONTEXT_TYPE.FWPM_IPSEC_KEYING_CONTEXT => e.keyingPolicy.Value,
				FWPM_PROVIDER_CONTEXT_TYPE.FWPM_IPSEC_IKE_QM_TRANSPORT_CONTEXT => e.ikeQmTransportPolicy.Value,
				FWPM_PROVIDER_CONTEXT_TYPE.FWPM_IPSEC_IKE_QM_TUNNEL_CONTEXT => e.ikeQmTunnelPolicy.Value,
				FWPM_PROVIDER_CONTEXT_TYPE.FWPM_IPSEC_AUTHIP_QM_TRANSPORT_CONTEXT => e.authipQmTransportPolicy.Value,
				FWPM_PROVIDER_CONTEXT_TYPE.FWPM_IPSEC_AUTHIP_QM_TUNNEL_CONTEXT => e.ikeQmTunnelPolicy.Value,
				FWPM_PROVIDER_CONTEXT_TYPE.FWPM_IPSEC_IKE_MM_CONTEXT => e.ikeMmPolicy.Value,
				FWPM_PROVIDER_CONTEXT_TYPE.FWPM_IPSEC_AUTHIP_MM_CONTEXT => e.authIpMmPolicy.Value,
				FWPM_PROVIDER_CONTEXT_TYPE.FWPM_GENERAL_CONTEXT => e.dataBuffer.Value,
				FWPM_PROVIDER_CONTEXT_TYPE.FWPM_IPSEC_IKEV2_QM_TUNNEL_CONTEXT => e.ikeV2QmTunnelPolicy.Value,
				FWPM_PROVIDER_CONTEXT_TYPE.FWPM_IPSEC_IKEV2_MM_CONTEXT => e.ikeV2MmPolicy.Value,
				FWPM_PROVIDER_CONTEXT_TYPE.FWPM_IPSEC_DOSP_CONTEXT => e.idpOptions.Value,
				FWPM_PROVIDER_CONTEXT_TYPE.FWPM_IPSEC_IKEV2_QM_TRANSPORT_CONTEXT => e.ikeV2QmTransportPolicy.Value,
				_ => "",
			})).WriteValues();
		}
	}

	[Test]
	public void FwpmProviderEnum0Test()
	{
		Assert.That(FwpmProviderEnum0(fwpEngineHandle, out SafeFwpmArray<FWPM_PROVIDER0> h), ResultIs.Successful);
		foreach (FWPM_PROVIDER0 e in h)
		{
			TestContext.WriteLine($"{GetNameOf(e.providerKey)}==========");
			e.WriteValues();
		}
	}

	[Test]
	public void FwpmSessionEnum0Test()
	{
		Assert.That(FwpmSessionEnum0(fwpEngineHandle, out SafeFwpmArray<FWPM_SESSION0> h), ResultIs.Successful);
		foreach (FWPM_SESSION0 e in h)
		{
			TestContext.WriteLine($"{e.sessionKey}==========");
			e.WriteValues();
		}
	}

	[Test]
	public void FwpmSubLayerEnum0Test()
	{
		Assert.That(FwpmSubLayerEnum0(fwpEngineHandle, out SafeFwpmArray<FWPM_SUBLAYER0> h), ResultIs.Successful);
		foreach (FWPM_SUBLAYER0 e in h)
		{
			TestContext.WriteLine($"{GetNameOf(e.subLayerKey)}==========");
			e.WriteValues();
		}
	}
}