using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using static Vanara.PInvoke.FwpUClnt;
using Vanara.Extensions;
using System.CodeDom;
using System.Reflection;
using System.Runtime.InteropServices;
using System.IO;
using System.Linq;
using Vanara.Extensions.Reflection;
using Vanara.InteropServices;
using System.Collections.Generic;
using System.Collections;
using ICSharpCode.Decompiler.TypeSystem;
using System.Drawing.Drawing2D;
using Newtonsoft.Json.Linq;
using System.Text;
using static Vanara.PInvoke.Ws2_32;
using System.Net;
using System.ComponentModel.Design;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class FwpUClntTests
{
	private SafeHFWPENG fwpEngineHandle;

	[OneTimeSetUp]
	public void _Setup()
	{
		FwpmEngineOpen0(default, Rpc.RPC_C_AUTHN.RPC_C_AUTHN_WINNT, default, default, out fwpEngineHandle).ThrowIfFailed();
	}

	[OneTimeTearDown]
	public void _TearDown()
	{
	}

	[Test]
	public void FwpmNetEventEnum0Test()
	{
		//-----------------------------------------
		// Get the events from enumeration
		Assert.That(FwpmNetEventEnum0(fwpEngineHandle, out var h), ResultIs.Successful);
		foreach (var e in h)
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
		Assert.That(FwpmNetEventEnum1(fwpEngineHandle, out var h), ResultIs.Successful);
		foreach (var e in h)
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
		Assert.That(FwpmNetEventEnum2(fwpEngineHandle, out var h), ResultIs.Successful);
		foreach (var e in h)
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
		Assert.That(FwpmNetEventEnum3(fwpEngineHandle, out var h), ResultIs.Successful);
		foreach (var e in h)
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

	private const string nullStr = "(null)";

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
		int changed = 0;
		using var pchng = new PinnedObject(changed);
		void callback(IntPtr context, in FWPM_CALLOUT_CHANGE0 change) { unsafe { *((int*)context) = 1; } }
		Assert.That(FwpmCalloutSubscribeChanges0(fwpEngineHandle, subscr, callback, pchng, out var hChange), ResultIs.Successful);

		Assert.That(FwpmCalloutSubscriptionsGet0(fwpEngineHandle, out var subs), ResultIs.Successful);
		Assert.That(subs.Count, Is.EqualTo(1));

		FWPM_DISPLAY_DATA0 dd = new() { name = "Datagram-Data Proxy Callout", description = "Datagram-Data Proxy Callout" };
		FWPM_CALLOUT0 callout = new() { calloutKey = Guid.NewGuid(), displayData = dd, applicableLayer = FWPM_LAYER_DATAGRAM_DATA_V4 };
		Assert.That(FwpmCalloutAdd0(fwpEngineHandle, callout, default, out var id), ResultIs.Successful);

		//System.Threading.Thread.SpinWait(200);
		//Assert.That(changed, Is.Not.Zero);
		Assert.That(FwpmCalloutUnsubscribeChanges0(fwpEngineHandle, hChange), ResultIs.Successful);

		Assert.That(FwpmCalloutGetById0(fwpEngineHandle, id, out var byId), ResultIs.Successful);
		Assert.True(byId.Value.HasValue && byId.Value.Value.calloutId == id);
		Assert.That(FwpmCalloutGetByKey0(fwpEngineHandle, callout.calloutKey, out var byKey), ResultIs.Successful);
		Assert.True(byKey.Value.HasValue && byKey.Value.Value.calloutId == id);
		Assert.That(FwpmCalloutGetSecurityInfoByKey0(fwpEngineHandle, callout.calloutKey,
			SECURITY_INFORMATION.OWNER_SECURITY_INFORMATION|SECURITY_INFORMATION.GROUP_SECURITY_INFORMATION|SECURITY_INFORMATION.DACL_SECURITY_INFORMATION,
			out var sOwn, out var sGrp, out var dacl, out var sacl, out var sd), ResultIs.Successful);
		Assert.True(!sOwn.IsNull && !sGrp.IsNull && !dacl.IsNull);
		Assert.True(sOwn.IsValidSid() && sGrp.IsValidSid() && dacl.IsValidAcl());

		Assert.That(FwpmCalloutDeleteById0(fwpEngineHandle, id), ResultIs.Successful);

		//-----------------------------------------
		// Get the events from enumeration
		Assert.That(FwpmCalloutEnum0(fwpEngineHandle, out var h), ResultIs.Successful);
		foreach (var e in h)
		{
			TestContext.WriteLine($"{e.calloutKey}=({e.flags})=========");
			TestContext.WriteLine($"{e.displayData.name ?? nullStr} ({e.displayData.description ?? nullStr})");
			TestContext.WriteLine($"Prov={GetNameOf(e.providerKey.Value.GetValueOrDefault()) ?? nullStr}; Layer={GetNameOf(e.applicableLayer)}");
		}
	}

	[Test]
	public void FwpmFilterEnum0Test()
	{
		Assert.That(FwpmFilterEnum0(fwpEngineHandle, out var h), ResultIs.Successful);
		foreach (FWPM_FILTER0 e in h)
		{
			TestContext.WriteLine($"{e.filterKey}=({e.flags})=========");
			TestContext.WriteLine($"{e.displayData.name ?? nullStr} ({e.displayData.description ?? nullStr})");
			TestContext.WriteLine($"Prov={GetNameOf(e.providerKey.Value.GetValueOrDefault()) ?? nullStr}; Layer={GetNameOf(e.layerKey)}");
		}
	}

	[Test]
	public void FwpmLayerEnum0Test()
	{
		Assert.That(FwpmLayerEnum0(fwpEngineHandle, out var h), ResultIs.Successful);
		foreach (FWPM_LAYER0 e in h)
		{
			TestContext.WriteLine($"{GetNameOf(e.layerKey)}==========");
			e.WriteValues();
		}
	}

	[Test]
	public void FwpmProviderEnum0Test()
	{
		Assert.That(FwpmProviderEnum0(fwpEngineHandle, out var h), ResultIs.Successful);
		foreach (FWPM_PROVIDER0 e in h)
		{
			TestContext.WriteLine($"{GetNameOf(e.providerKey)}==========");
			e.WriteValues();
		}
	}

	[Test]
	public void FwpmSessionEnum0Test()
	{
		Assert.That(FwpmSessionEnum0(fwpEngineHandle, out var h), ResultIs.Successful);
		foreach (FWPM_SESSION0 e in h)
		{
			TestContext.WriteLine($"{e.sessionKey}==========");
			e.WriteValues();
		}
	}

	[Test]
	public void FwpmSubLayerEnum0Test()
	{
		Assert.That(FwpmSubLayerEnum0(fwpEngineHandle, out var h), ResultIs.Successful);
		foreach (FWPM_SUBLAYER0 e in h)
		{
			TestContext.WriteLine($"{GetNameOf(e.subLayerKey)}==========");
			e.WriteValues();
		}
	}

	[Test]
	public void FwpmProviderContextEnum0Test()
	{
		Assert.That(FwpmProviderContextEnum0(fwpEngineHandle, out var h), ResultIs.Successful);
		foreach (var e in h)
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
		Assert.That(FwpmProviderContextEnum1(fwpEngineHandle, out var h), ResultIs.Successful);
		foreach (var e in h)
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
		Assert.That(FwpmProviderContextEnum2(fwpEngineHandle, out var h), ResultIs.Successful);
		foreach (var e in h)
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
	public void FwpmConnectionEnum0Test()
	{
		Assert.That(FwpmConnectionEnum0(fwpEngineHandle, out var h), ResultIs.Successful);
		foreach (var e in h)
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
		Assert.That(FwpmConnectionSubscribe0(fwpEngineHandle, subscr, callback, default, out var hChange), ResultIs.Successful);
		Assert.That(FwpmConnectionUnsubscribe0(fwpEngineHandle, hChange), ResultIs.Successful);
	}

	[Test]
	public void StructTest()
	{
		typeof(Vanara.PInvoke.FwpUClnt).GetNestedStructSizes().WriteValues();
	}

	[Test]
	public void FwpmIPsecTunnelAdd0Test()
	{
		string policyName = "Unknown";
		Guid providerKey = new("5fb216a8-e2e8-4024-b853-391a4168641e");
		IN_ADDR localAddr = new IN_ADDR(192, 68, 0, 1);
		IN_ADDR remoteAddr = new IN_ADDR(192, 68, 0, 10);

		IPSEC_TUNNEL_ENDPOINTS0 endpoints = new();
		endpoints.ipVersion = FWP_IP_VERSION.FWP_IP_VERSION_V4;
		endpoints.localV4Address = localAddr;
		endpoints.remoteV4Address = remoteAddr;

		FWP_BYTE_BLOB presharedKey = new();
		IKEEXT_AUTHENTICATION_METHOD0[] mmAuthMethods = new IKEEXT_AUTHENTICATION_METHOD0[1];
		mmAuthMethods[0].authenticationMethodType = IKEEXT_AUTHENTICATION_METHOD_TYPE.IKEEXT_PRESHARED_KEY;
		mmAuthMethods[0].presharedKeyAuthentication = new IKEEXT_PRESHARED_KEY_AUTHENTICATION0 { presharedKey = presharedKey };

		IKEEXT_PROPOSAL0[] mmProposals = new IKEEXT_PROPOSAL0[1];
		mmProposals[0].cipherAlgorithm.algoIdentifier = IKEEXT_CIPHER_TYPE.IKEEXT_CIPHER_AES_128;
		mmProposals[0].integrityAlgorithm.algoIdentifier = IKEEXT_INTEGRITY_TYPE.IKEEXT_INTEGRITY_SHA1;
		mmProposals[0].maxLifetimeSeconds = 8 * 60 * 60;
		mmProposals[0].dhGroup = IKEEXT_DH_GROUP.IKEEXT_DH_GROUP_2;

		IKEEXT_POLICY0 mmPolicy = new() {
			numAuthenticationMethods = (uint)mmAuthMethods.Length,
			authenticationMethods = SafeCoTaskMemHandle.CreateFromList(mmAuthMethods),
			numIkeProposals = (uint)mmProposals.Length,
			ikeProposals = SafeCoTaskMemHandle.CreateFromList(mmProposals) };

		FWPM_PROVIDER_CONTEXT0 mmProvCtxt = new();
		mmProvCtxt.displayData.name = policyName;
		mmProvCtxt.providerKey = (SafeCoTaskMemStruct<Guid>)providerKey;
		mmProvCtxt.type = FWPM_PROVIDER_CONTEXT_TYPE.FWPM_IPSEC_IKE_MM_CONTEXT;
		mmProvCtxt.authIpMmPolicy = mmPolicy;

		IPSEC_AUTH_AND_CIPHER_TRANSFORM0 qmTransform00 = new();
		qmTransform00.authTransform.authTransformId = IPSEC_AUTH_TRANSFORM_ID_HMAC_SHA_1_96;
		qmTransform00.cipherTransform.cipherTransformId = IPSEC_CIPHER_TRANSFORM_ID_AES_128;

		IPSEC_SA_LIFETIME0 qmLifetime = new() {
			lifetimeSeconds = 3600,
			lifetimeKilobytes = 100000,
			lifetimePackets = 0x7FFFFFFF };

		IPSEC_SA_TRANSFORM0[] qmTransforms0 = new IPSEC_SA_TRANSFORM0[1];
		qmTransforms0[0].ipsecTransformType = IPSEC_TRANSFORM_TYPE.IPSEC_TRANSFORM_ESP_AUTH_AND_CIPHER;
		qmTransforms0[0].espAuthAndCipherTransform = qmTransform00;

		IPSEC_PROPOSAL0[] qmProposals = new IPSEC_PROPOSAL0[1];
		qmProposals[0].lifetime = qmLifetime;
		qmProposals[0].numSaTransforms = (uint)qmTransforms0.Length;
		qmProposals[0].saTransforms = SafeCoTaskMemHandle.CreateFromList(qmTransforms0);

		IPSEC_TUNNEL_POLICY0 qmPolicy = new() {
			numIpsecProposals = (uint)qmProposals.Length,
			ipsecProposals = SafeCoTaskMemHandle.CreateFromList(qmProposals),
			tunnelEndpoints = endpoints,
			saIdleTimeout = new() { idleTimeoutSeconds = 300, idleTimeoutSecondsFailOver = 60 } };

		FWPM_PROVIDER_CONTEXT0 qmProvCtxt = default;
		qmProvCtxt.displayData.name = policyName;
		qmProvCtxt.providerKey = (SafeCoTaskMemStruct<Guid>)providerKey;
		qmProvCtxt.type = FWPM_PROVIDER_CONTEXT_TYPE.FWPM_IPSEC_IKE_QM_TUNNEL_CONTEXT;
		qmProvCtxt.ikeQmTunnelPolicy = qmPolicy;

		FWP_CONDITION_VALUE0 cv1 = new() { type = FWP_DATA_TYPE.FWP_UINT32, uint32 = localAddr };
		FWP_CONDITION_VALUE0 cv2 = new() { type = FWP_DATA_TYPE.FWP_UINT32, uint32 = remoteAddr };
		FWPM_FILTER_CONDITION0[] filterConditions = new FWPM_FILTER_CONDITION0[] {
			new() { fieldKey = FWPM_CONDITION_IP_LOCAL_ADDRESS, matchType = FWP_MATCH_TYPE.FWP_MATCH_EQUAL, conditionValue = cv1 },
			new() { fieldKey = FWPM_CONDITION_IP_REMOTE_ADDRESS, matchType = FWP_MATCH_TYPE.FWP_MATCH_EQUAL, conditionValue = cv2 },
		};
		Assert.That(FwpmIPsecTunnelAdd0(fwpEngineHandle, FWPM_TUNNEL_FLAG.FWPM_TUNNEL_FLAG_POINT_TO_POINT,
			mmProvCtxt, qmProvCtxt, (uint)filterConditions.Length, filterConditions), ResultIs.Successful);
	}

	static readonly string[] imports = { "System", "System.Reflection", "System.Runtime.InteropServices" };

	[Test]
	public void TestS1() => TestType(new TestTypes.Nest.S1 { size = 3, data = new RECT[] { new(0, 1, 0, 1), new(0, 2, 0, 2), new(0, 16, 0, 16) } });

	[Test]
	public void TestS2() => TestType(new TestTypes.Nest.S2 { data = new(0, 1, 0, 1), ndata = new(0, 2, 0, 2), pdata = new(0, 16, 0, 16),
		str = "string00001", pstr = "string00002", nested = new TestTypes.S4 { data = imports },
		pnested = new TestTypes.Nest.S1 { size = 3, data = new RECT[] { new(0, 1, 0, 1), new(0, 2, 0, 2), new(0, 16, 0, 16) } }
	});

	[Test]
	public void TestS2Null() => TestType(new TestTypes.Nest.S2());

	[Test]
	public void TestS3() => TestType(new TestTypes.S3 { data = imports });

	[Test]
	public void TestS4() => TestType(new TestTypes.S4 { data = imports });

	private static void TestType<T>(T value) => TestType(typeof(T), value);

	private static void TestType(Type type, object value)
	{
		Assert.True(VanaraMarshaler.CanMarshal(type, out var m));
		using var mem = m.MarshalManagedToNative(value);

		TestContext.WriteLine($"Ptr={mem.DangerousGetHandle()}; Len={(long)mem.Size}");
		TestContext.WriteLine(mem.Dump);
		TestContext.WriteLine(new string('=', 40));

		TestContext.WriteLine("In " + new string('-', 10));
		value.WriteValues();
		TestContext.WriteLine("Out" + new string('-', 10));
		var retInst = m.MarshalNativeToManaged(mem, mem.Size);
		retInst.WriteValues();
	}
}

public class MyMarshaler<T> : IVanaraMarshaler
{
	private class Info
	{
		public FieldInfo fi;
		public Type nType;
		public VMarshalAsAttribute vattr;
		public MarshalAsAttribute maattr;
	}

	static readonly Dictionary<Type, (Assembly asm, List<Info> fields, Type newType, CharSet charSet)> assemblyCache = new();
	static readonly Dictionary<Type, CodeTypeDeclaration> typeDecls = new();

	static (List<Info> fields, CharSet charSet, string typeName) AddDecl(Type type, CodeCompileUnit compUnit)
	{
		CodeTypeDeclaration decl = new(type.Name) { IsStruct = true };
		decl.TypeAttributes |= TypeAttributes.SequentialLayout | TypeAttributes.Public;
		CharSet charSet = type.GetCustomAttribute<StructLayoutAttribute>()?.CharSet ?? CharSet.Auto;
		decl.TypeAttributes |= charSet switch { CharSet.Unicode => TypeAttributes.UnicodeClass, CharSet.Ansi => TypeAttributes.AnsiClass, _ => TypeAttributes.AutoClass };
		typeDecls.Add(type, decl);
		//AddReferences(type, compUnit.ReferencedAssemblies);
		compUnit.ReferencedAssemblies.AddRange(GetRefAsms(type));
		var nsp = AddNamespaces(type, compUnit.Namespaces);
		var fields = type.GetOrderedFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).Select(f => new Info { fi = f }).ToList();
		foreach (var f in fields)
		{
			f.vattr = f.fi.GetCustomAttribute<VMarshalAsAttribute>();
			f.nType = f.vattr?.FieldType is null ? f.fi.FieldType : typeof(IntPtr);
			if (!compUnit.ReferencedAssemblies.Contains(f.nType.Assembly.Location))
				AddDecl(f.nType, compUnit);
			CodeMemberField mbr = new(f.nType, f.fi.Name) { Attributes = MemberAttributes.Public };
			f.maattr = f.fi.GetCustomAttribute<MarshalAsAttribute>();
			if (f.maattr is not null)
				mbr.CustomAttributes.Add(MakeCAttr(f.maattr));
			decl.Members.Add(mbr);
		}

		StringBuilder fullTypeName = new(nsp.Name + ".");
		if (type.IsNested)
		{
			Stack<Type> parentChain = new();
			var pType = type.DeclaringType;
			while (pType != null)
			{
				parentChain.Push(pType);
				pType = pType.DeclaringType;
			}
			CodeTypeDeclaration topParent = null, lastParent = null;
			fullTypeName.Append(string.Join("+", parentChain.Select(t => t.Name)) + "+");
			while (parentChain.Count > 0)
			{
				if (!typeDecls.ContainsKey(parentChain.Peek()))
					typeDecls.Add(parentChain.Peek(), MakeSealedClass(parentChain.Peek()));
				var classDecl = typeDecls[parentChain.Peek()];
				topParent ??= classDecl;
				if (lastParent is not null)
					lastParent.Members.Add(classDecl);
				lastParent = classDecl;
				parentChain.Pop();
			}
			lastParent.Members.Add(decl);
			if (nsp.Types.Cast<CodeTypeDeclaration>().FirstOrDefault(d => d.Name == topParent.Name) is null)
				nsp.Types.Add(topParent);
		}
		else
			nsp.Types.Add(decl);
		fullTypeName.Append(type.Name);
		return (fields, charSet, fullTypeName.ToString());

		static CodeNamespace AddNamespaces(Type type, CodeNamespaceCollection coll)
		{
			var nsp = coll.Cast<CodeNamespace>().FirstOrDefault(cn => cn.Name == type.Namespace);
			if (nsp is null)
				coll.Add(nsp = new CodeNamespace(type.Namespace));
			return nsp;
		}

		static void AddReferences(Type type, System.Collections.Specialized.StringCollection coll) => 
			coll.AddRange(coll.Cast<string>().Except(GetRefAsms(type)).ToArray());

		static string[] GetRefAsms(Type type) => type.Assembly.GetReferencedAssemblies().
			Select(name => AppDomain.CurrentDomain.GetAssemblies().SingleOrDefault(a => a.FullName == name.FullName)?.Location).
			Where(l => l != null).ToArray();

		static CodeAttributeDeclaration MakeCAttr(MarshalAsAttribute att)
		{
			CodeAttributeDeclaration cattr = new(new CodeTypeReference(att.GetType()));
			cattr.Arguments.Add(new CodeAttributeArgument(new CodeFieldReferenceExpression(new CodeTypeReferenceExpression(typeof(UnmanagedType)), att.Value.ToString())));
			foreach (var fi in typeof(MarshalAsAttribute).GetFields(BindingFlags.Instance | BindingFlags.Public))
			{
				if (fi.IsInitOnly)
					continue;
				var fiVal = fi.GetValue(att);
				object defVal = null;
				try { defVal = Activator.CreateInstance(fi.FieldType); } catch { }
				if (Equals(fiVal, defVal))
					continue;
				if (fi.FieldType.IsEnum)
					cattr.Arguments.Add(new CodeAttributeArgument(fi.Name, new CodeFieldReferenceExpression(new CodeTypeReferenceExpression(fi.FieldType), fiVal?.ToString())));
				else if (fi.FieldType.IsPrimitive)
					cattr.Arguments.Add(new CodeAttributeArgument(fi.Name, new CodePrimitiveExpression(fiVal)));
				else if (fi.FieldType == typeof(Type) && fiVal is not null)
					cattr.Arguments.Add(new CodeAttributeArgument(fi.Name, new CodeTypeOfExpression((Type)fi.GetValue(att))));
			}
			return cattr;
		}

		static CodeTypeDeclaration MakeSealedClass(Type type) =>
			new(type.Name) { IsClass = true, TypeAttributes = TypeAttributes.Sealed | TypeAttributes.Public };
	}

	static (Type newType, List<Info> fields, CharSet charSet) GetTypeInfo(Type type)
	{
		if (assemblyCache.TryGetValue(type, out var asm))
			return (asm.newType, asm.fields, asm.charSet);

		if (!type.IsLayoutSequential)
			throw new NotSupportedException();

		CodeCompileUnit compUnit = new();
		var (fields, charSet, typeName) = AddDecl(type, compUnit);

		CSharpCodeProvider csharp = new();

#if DEBUG
		using (var src = new StringWriter())
		{
			csharp.GenerateCodeFromCompileUnit(compUnit, src, new CodeGeneratorOptions() { BracingStyle = "C" });
			System.Diagnostics.Debug.WriteLine(src.ToString());
		}
#endif
		CompilerParameters opts = new() { GenerateInMemory = true, GenerateExecutable = false, CompilerOptions = "" };
		CompilerResults result = csharp.CompileAssemblyFromDom(opts, compUnit);
		if (result.Errors.Count > 0)
			throw new AggregateException("Unable to compile translated object.", result.Errors.Cast<CompilerError>().Select(e => new Exception(e.ErrorText)));
		var newType = result.CompiledAssembly.GetType(typeName) ?? throw new InvalidOperationException("Unable to retrieve psuedo-type.");
		assemblyCache.Add(type, (result.CompiledAssembly, fields, newType, charSet));
		return (newType, fields, charSet);
	}

	SizeT IVanaraMarshaler.GetNativeSize()
	{
		var (newType, _, _) = GetTypeInfo(typeof(T));
		return InteropExtensions.SizeOf(newType);
	}

	SafeAllocatedMemoryHandle IVanaraMarshaler.MarshalManagedToNative(object value)
	{
		// Handle bad input
		if (!Equals(value?.GetType(), typeof(T)))
			throw new ArgumentException($"Object to marshal is not of the expected type: {nameof(T)}");

		// Get detail of translated type
		var (newType, fields, charSet) = GetTypeInfo(typeof(T));
		var newTypeSize = InteropExtensions.SizeOf(newType);
		System.Diagnostics.Debug.WriteLine($"New Type Size={newTypeSize}");
		var newInst = Activator.CreateInstance(newType, true);

		// Stream structure and memory allocated values into allocated memory
		SafeCoTaskMemHandle mem = new(256 + newTypeSize);
		NativeMemoryStream memStr = new(mem) { Position = newTypeSize, CharSet = charSet };
		memStr.SetLength(newTypeSize);
		Dictionary<string, long> ptrFieldOffs = new();
		List<(Info f, SafeAllocatedMemoryHandle m)> marshaledFields = new();
		foreach (Info f in fields)
		{
			var curVal = f.fi.GetValue(value);
			bool save = true;
			// Handle fields converted to pointers
			if (!Equals(f.fi.FieldType, f.nType) && f.nType == typeof(IntPtr))
			{
				if (curVal is null || Equals(curVal, IntPtr.Zero))
					curVal = IntPtr.Zero;
				else
				{
					var ptr = memStr.Position;
					if (f.fi.FieldType == typeof(string) && f.vattr?.FieldType == NativeType.StringPtr)
					{
						memStr.Write((string)curVal, f.vattr?.CharSet == CharSet.None ? charSet : f.vattr.CharSet);
					}
					else if (f.fi.FieldType.IsArray)
					{
						var count = GetFieldSize(f, value, fields);
						if (curVal is IEnumerable<string> ies)
							memStr.Write(ies.Take(count < 0 ? int.MaxValue : count), f.vattr?.FieldType == NativeType.DblNullTermStringArray ? StringListPackMethod.Concatenated : StringListPackMethod.Packed);
						else
							memStr.Write(((IEnumerable)curVal).Cast<object>().Take(count), f.vattr?.FieldType == NativeType.ByRefArray);
					}
					else
						memStr.WriteObject(curVal);
					ptrFieldOffs.Add(f.fi.Name, ptr);
					save = false;
				}
			}
			else if (VanaraMarshaler.CanMarshal(f.nType, out var vm))
			{
				SafeAllocatedMemoryHandle fmem = vm.MarshalManagedToNative(curVal);
				if (fmem is not ISafeMemoryHandle imem)
					throw new InvalidCastException("Subobjects must convert to an ISafeMemoryHandle object.");
				mem.AddSubReference(imem);
				marshaledFields.Add((f, fmem));
			}
			if (save)
				newInst.SetFieldValue(f.fi.Name, curVal);
		}
		memStr.Flush();
		mem.Size = memStr.Length;
		// Poke into the marshaled memory all the pointers to memory
		foreach (var nv in ptrFieldOffs)
			newInst.SetFieldValue(nv.Key, mem.DangerousGetHandle().Offset(nv.Value));
		// Write the struct into the marshaled memory
		Marshal.StructureToPtr(newInst, mem, false);
		// Write any vanara marshaled fields into marshed memory
		foreach (var (f, m) in marshaledFields)
		{
			var sz = InteropExtensions.SizeOf(f.nType);
			var off = Marshal.OffsetOf(newType, f.fi.Name).ToInt32();
			mem.Write(m.GetBytes(0, sz), false, off);
		}

		System.Diagnostics.Debug.WriteLine($"Alloc Ptr={mem.DangerousGetHandle()}; Len={(long)mem.Size}");
		System.Diagnostics.Debug.WriteLine(mem.Dump);

		return mem;
	}

	int GetFieldSize(Info f, object v, List<Info> fields)
	{
		var count = f.vattr?.SizeConst ?? -1;
		if (count == -1)
		{
			var sfn = f.vattr?.SizeFieldName;
			var sfi = sfn is null ? fields[0].fi : fields.First(f => f.fi.Name == sfn).fi;
			if (sfi.FieldType.IsPrimitive)
				count = Convert.ToInt32(sfi.GetValue(v));
		}
		return count;
	}

	object IVanaraMarshaler.MarshalNativeToManaged(IntPtr pNativeData, SizeT allocatedBytes)
	{
		var (newType, fields, charSet) = GetTypeInfo(typeof(T));
		var newReadInst = pNativeData.Convert(allocatedBytes, newType, charSet);
		var retInst = Activator.CreateInstance(typeof(T), true);
		foreach (var f in fields)
		{
			var curVal = newReadInst.GetFieldValue<object>(f.fi.Name);
			if (!Equals(f.fi.FieldType, f.nType) && f.nType == typeof(IntPtr) && curVal.GetType() == typeof(IntPtr))
			{
				if (Equals(curVal, IntPtr.Zero))
					curVal = null;
				else if (f.fi.FieldType == typeof(string) && f.vattr?.FieldType == NativeType.StringPtr)
				{
					curVal = StringHelper.GetString((IntPtr)curVal, f.vattr?.CharSet == CharSet.None ? charSet : f.vattr.CharSet);
				}
				else if (f.fi.FieldType.IsArray)
				{
					var count = GetFieldSize(f, retInst, fields);
					var elemType = f.fi.FieldType.GetElementType();
					if (elemType == typeof(string))
					{
						if (f.vattr?.FieldType == NativeType.DblNullTermStringArray)
							curVal = ((IntPtr)curVal).ToStringEnum(charSet).Take(count < 0 ? int.MaxValue : count).ToArray();
						else
						{
							if (count < 0) throw new InvalidOperationException("Cannot determine array size during unmarshaling.");
							curVal = ((IntPtr)curVal).ToStringEnum(count, charSet).ToArray();
						}
					}
					else
					{
						if (count < 0) throw new InvalidOperationException("Cannot determine array size during unmarshaling.");
						curVal = ((IntPtr)curVal).ToArray(elemType, count);
					}
				}
				else
					curVal = ((IntPtr)curVal).Convert(allocatedBytes, f.fi.FieldType, charSet);
			}
			// Handle vmarshaled structs
			else if (VanaraMarshaler.CanMarshal(f.fi.FieldType, out var vm))
			{
				var foff = Marshal.OffsetOf(newType, f.fi.Name).ToInt32();
				curVal = vm.MarshalNativeToManaged(pNativeData.Offset(foff), allocatedBytes);
			}
			retInst.SetFieldValue(f.fi.Name, curVal);
		}
		return retInst;
	}
}

public enum NativeType
{
	ByValArray,
	ByRefArray,
	DblNullTermStringArray,
	StructPtr,
	StringPtr,
}

[System.AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
sealed class VMarshalAsAttribute : Attribute
{
	public VMarshalAsAttribute(NativeType fieldType) => FieldType = fieldType;

	public NativeType FieldType { get; }

	public string SizeFieldName { get; set; }

	public int SizeConst { get; set; } = -1;

	public CharSet CharSet { get; set; } = CharSet.None;
}

public static class TestTypes
{
	public static class Nest
	{
		[VanaraMarshaler(typeof(MyMarshaler<S1>))]
		[StructLayout(LayoutKind.Sequential)]
		public struct S1
		{
			[MarshalAs(UnmanagedType.I4, SizeConst = 4, MarshalCookie = "cookie")]
			public int size;

			[VMarshalAs(NativeType.ByValArray, SizeFieldName = nameof(size))]
			public RECT[] data;
		}

		[VanaraMarshaler(typeof(MyMarshaler<S2>))]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
		public struct S2
		{
			[VMarshalAs(NativeType.StructPtr)]
			public RECT? ndata;

			[VMarshalAs(NativeType.StructPtr)]
			public RECT pdata;

			public RECT data;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
			public string str;

			[VMarshalAs(NativeType.StringPtr)]
			public string pstr;

			public S4 nested;

			[VMarshalAs(NativeType.StructPtr)]
			public S1? pnested;
		}
	}

	[VanaraMarshaler(typeof(MyMarshaler<S3>))]
	[StructLayout(LayoutKind.Sequential)]
	public struct S3
	{
		[VMarshalAs(NativeType.ByRefArray, SizeConst = 3)]
		public string[] data;
	}

	[VanaraMarshaler(typeof(MyMarshaler<S4>))]
	[StructLayout(LayoutKind.Sequential)]
	public struct S4
	{
		[VMarshalAs(NativeType.DblNullTermStringArray)]
		public string[] data;
	}
}