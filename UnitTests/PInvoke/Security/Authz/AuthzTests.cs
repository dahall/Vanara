using NUnit.Framework;
using System;
using System.Linq;
using Vanara.InteropServices;
using static Vanara.PInvoke.AdvApi32;
using static Vanara.PInvoke.Authz;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests
{
	[TestFixture]
	public class AuthzTests
	{
		public static SafeAUTHZ_AUDIT_EVENT_HANDLE GetAuthzInitializeObjectAccessAuditEvent()
		{
			Assert.That(AuthzInitializeObjectAccessAuditEvent(AuthzAuditEventFlags.AUTHZ_NO_ALLOC_STRINGS, IntPtr.Zero, "", "", "", "", out SafeAUTHZ_AUDIT_EVENT_HANDLE hEvt), ResultIs.Successful);
			Assert.That(!hEvt.IsInvalid);
			return hEvt;
		}

		public static SafeAUTHZ_RESOURCE_MANAGER_HANDLE GetAuthzInitializeResourceManager()
		{
			Assert.That(AuthzInitializeResourceManager(AuthzResourceManagerFlags.AUTHZ_RM_FLAG_NO_AUDIT, null, null, null, "Test", out SafeAUTHZ_RESOURCE_MANAGER_HANDLE hResMgr), ResultIs.Successful);
			Assert.That(!hResMgr.IsInvalid);
			return hResMgr;
		}

		public static SafeHGlobalHandle GetCtxInfo(SafeAUTHZ_CLIENT_CONTEXT_HANDLE hCtx, AUTHZ_CONTEXT_INFORMATION_CLASS type)
		{
			bool b = AuthzGetInformationFromContext(hCtx, type, 0, out uint szReq, IntPtr.Zero);
			if (!b && Win32Error.GetLastError() != Win32Error.ERROR_INSUFFICIENT_BUFFER)
			{
				TestContext.WriteLine($"AuthzGetInformationFromContext:{Win32Error.GetLastError()}");
			}

			Assert.That(!b);
			if (szReq == 0)
			{
				return SafeHGlobalHandle.Null;
			}

			SafeHGlobalHandle buf = new((int)szReq);
			Assert.That(AuthzGetInformationFromContext(hCtx, type, szReq, out _, buf), ResultIs.Successful);
			return buf;
		}

		public static SafeAUTHZ_CLIENT_CONTEXT_HANDLE GetCurrentUserAuthContext(SafeAUTHZ_RESOURCE_MANAGER_HANDLE hResMgr)
		{
			Assert.That(AuthzInitializeContextFromSid(AuthzContextFlags.DEFAULT, SafePSID.Current, hResMgr, IntPtr.Zero, new LUID(), IntPtr.Zero, out SafeAUTHZ_CLIENT_CONTEXT_HANDLE hCtx), ResultIs.Successful);
			Assert.That(!hCtx.IsInvalid);
			return hCtx;
		}

		public static SafeAUTHZ_CLIENT_CONTEXT_HANDLE GetTokenAuthContext(SafeAUTHZ_RESOURCE_MANAGER_HANDLE hRM)
		{
			using SafeHTOKEN hTok = SafeHTOKEN.FromProcess(GetCurrentProcess(), TokenAccess.TOKEN_QUERY);
			Assert.That(AuthzInitializeContextFromToken(0, hTok, hRM, IntPtr.Zero, new LUID(), IntPtr.Zero, out SafeAUTHZ_CLIENT_CONTEXT_HANDLE hCtx), ResultIs.Successful);
			Assert.That(!hCtx.IsInvalid);
			return hCtx;
		}

		[Test]
		public void AuthzAddSidsToContextTest()
		{
			using SafePSID everyoneSid = ConvertStringSidToSid("S-1-1-0");
			using SafePSID localSid = ConvertStringSidToSid("S-1-2-0");
			SID_AND_ATTRIBUTES sids = new() { Sid = everyoneSid, Attributes = (uint)GroupAttributes.SE_GROUP_ENABLED };
			SID_AND_ATTRIBUTES restrictedSids = new() { Sid = localSid, Attributes = (uint)GroupAttributes.SE_GROUP_ENABLED };
			using SafeAUTHZ_RESOURCE_MANAGER_HANDLE hRM = GetAuthzInitializeResourceManager();
			using SafeAUTHZ_CLIENT_CONTEXT_HANDLE hCtx = GetCurrentUserAuthContext(hRM);
			Assert.That(AuthzAddSidsToContext(hCtx, sids, 1, restrictedSids, 1, out SafeAUTHZ_CLIENT_CONTEXT_HANDLE hNewCtx), ResultIs.Successful);
		}

		[Test]
		public void AuthzEnumerateSecurityEventSourcesTest()
		{
			var srcs = AuthzEnumerateSecurityEventSources().ToArray();
			Assert.That(srcs, Is.Not.Empty);
			Assert.That(() => TestContext.WriteLine(string.Join("\n", srcs.Select(r => r.szEventSourceName))), Throws.Nothing);
		}

		[Test]
		public void AuthzAccessCheckAndCachedTest()
		{
			using SafeAUTHZ_RESOURCE_MANAGER_HANDLE hRM = GetAuthzInitializeResourceManager();
			using SafeAUTHZ_CLIENT_CONTEXT_HANDLE hCtx = GetCurrentUserAuthContext(hRM);
			using SafeAUTHZ_AUDIT_EVENT_HANDLE hEvt = GetAuthzInitializeObjectAccessAuditEvent();
			using SafePSECURITY_DESCRIPTOR psd = AdvApi32Tests.GetSD(TestCaseSources.SmallFile);
			using AUTHZ_ACCESS_REPLY reply = new(1);
			AUTHZ_ACCESS_REQUEST req = new(ACCESS_MASK.MAXIMUM_ALLOWED);
			Assert.That(AuthzAccessCheck(AuthzAccessCheckFlags.NONE, hCtx, req, hEvt, psd, null, 0, reply, out SafeAUTHZ_ACCESS_CHECK_RESULTS_HANDLE hRes), ResultIs.Successful);
			Assert.That(reply.GrantedAccessMask, Is.Not.EqualTo(IntPtr.Zero));
			TestContext.WriteLine($"Access:{string.Join(",", reply.GrantedAccessMaskValues.Select(u => ((FileAccess)u).ToString()))}");

			Assert.That(AuthzCachedAccessCheck(0, hRes, req, default, reply), Is.True);

			hRes.Dispose();
			Assert.That(hRes.IsClosed);

			Assert.That(AuthzFreeCentralAccessPolicyCache(), Is.True);
		}

		[Test]
		public void AuthzGetInformationFromContextTest()
		{
			using SafeAUTHZ_RESOURCE_MANAGER_HANDLE hRM = GetAuthzInitializeResourceManager();
			using SafeAUTHZ_CLIENT_CONTEXT_HANDLE hCtx = GetCurrentUserAuthContext(hRM);
			SafeHGlobalHandle buf = GetCtxInfo(hCtx, AUTHZ_CONTEXT_INFORMATION_CLASS.AuthzContextInfoGroupsSids);
			TOKEN_GROUPS tg = buf.ToStructure<TOKEN_GROUPS>();
			Assert.That(tg.GroupCount, Is.GreaterThan(0));

			buf = GetCtxInfo(hCtx, AUTHZ_CONTEXT_INFORMATION_CLASS.AuthzContextInfoUserClaims);
			AUTHZ_SECURITY_ATTRIBUTES_INFORMATION ai = AUTHZ_SECURITY_ATTRIBUTES_INFORMATION.FromPtr(buf);
			if (ai == null)
			{
				return;
			}

			Assert.That(ai.Version, Is.EqualTo(1));
			TestContext.WriteLine($"AuthzGetInformationFromContext(AuthzContextInfoUserClaims)={ai.AttributeCount}");
		}

		[Test]
		public void AuthzInitializeCompoundContextTest()
		{
			using SafeAUTHZ_RESOURCE_MANAGER_HANDLE hRM = GetAuthzInitializeResourceManager();
			using SafeAUTHZ_CLIENT_CONTEXT_HANDLE hCtx = GetCurrentUserAuthContext(hRM);
			using SafeAUTHZ_CLIENT_CONTEXT_HANDLE hDevCtx = GetTokenAuthContext(hRM);
			Assert.That(AuthzInitializeCompoundContext(hCtx, hDevCtx, out SafeAUTHZ_CLIENT_CONTEXT_HANDLE hCompCtx), ResultIs.Successful);
			Assert.That(!hCompCtx.IsInvalid);
		}

		[Test]
		public void AuthzInitializeContextFromAuthzContextTest()
		{
			using SafeAUTHZ_RESOURCE_MANAGER_HANDLE hRM = GetAuthzInitializeResourceManager();
			using SafeAUTHZ_CLIENT_CONTEXT_HANDLE hCtx = GetCurrentUserAuthContext(hRM);
			Assert.That(AuthzInitializeContextFromAuthzContext(0, hCtx, long.MaxValue, new LUID(), new IntPtr(2), out SafeAUTHZ_CLIENT_CONTEXT_HANDLE hNewCtx), ResultIs.Successful);
		}

		[Test]
		public void AuthzInitializeContextFromSidTest()
		{
			using SafeAUTHZ_RESOURCE_MANAGER_HANDLE hRM = GetAuthzInitializeResourceManager();
			using SafeAUTHZ_CLIENT_CONTEXT_HANDLE hCtx = GetCurrentUserAuthContext(hRM);
			Assert.That(hCtx.IsInvalid, Is.False);
		}

		[Test]
		public void AuthzInitializeContextFromTokenTest()
		{
			using SafeAUTHZ_RESOURCE_MANAGER_HANDLE hRM = GetAuthzInitializeResourceManager();
			using SafeAUTHZ_CLIENT_CONTEXT_HANDLE hDevCtx = GetTokenAuthContext(hRM);
			Assert.That(hDevCtx.IsInvalid, Is.False);
		}

		[Test]
		public void AuthzInitializeObjectAccessAuditEventTest()
		{
			using SafeAUTHZ_AUDIT_EVENT_HANDLE hEvent = GetAuthzInitializeObjectAccessAuditEvent();
			Assert.That(hEvent.IsInvalid, Is.False);
		}

		[Test]
		public void AuthzInitializeObjectAccessAuditEvent2Test()
		{
			Assert.That(AuthzInitializeObjectAccessAuditEvent2(0, default, "", "", "", "", "", out SafeAUTHZ_AUDIT_EVENT_HANDLE hEvent), ResultIs.Successful);
			Assert.That(hEvent.IsInvalid, Is.False);
		}

		[Test]
		public void AuthzInitializeRemoteResourceManagerTest()
		{
			AUTHZ_RPC_INIT_INFO_CLIENT client = new()
			{
				version = AUTHZ_RPC_INIT_INFO_CLIENT.AUTHZ_RPC_INIT_INFO_CLIENT_VERSION_V1,
				ObjectUuid = "5fc860e0-6f6e-4fc2-83cd-46324f25e90b",
				ProtSeq = "ncacn_ip_tcp",
				NetworkAddr = "192.168.0.1",
				Endpoint = "192.168.0.202[80]"
			};
			Assert.That(AuthzInitializeRemoteResourceManager(client, out SafeAUTHZ_RESOURCE_MANAGER_HANDLE hResMgr), ResultIs.Successful);
			Assert.That(!hResMgr.IsInvalid);
		}

		[Test]
		public void AuthzInitializeResourceManagerTest() => GetAuthzInitializeResourceManager();

		[Test]
		public void AuthzInitializeResourceManagerExTest()
		{
			AUTHZ_INIT_INFO info = new()
			{
				version = AUTHZ_INIT_INFO.AUTHZ_INIT_INFO_VERSION_V1
			};
			Assert.That(AuthzInitializeResourceManagerEx(AuthzResourceManagerFlags.AUTHZ_RM_FLAG_NO_AUDIT, info, out SafeAUTHZ_RESOURCE_MANAGER_HANDLE hResMgr), ResultIs.Successful);
			Assert.That(!hResMgr.IsInvalid);
		}

		[Test]
		public void AuthzModifyClaimsTest()
		{
			using SafeAUTHZ_RESOURCE_MANAGER_HANDLE hRM = GetAuthzInitializeResourceManager();
			using SafeAUTHZ_CLIENT_CONTEXT_HANDLE hCtx = GetCurrentUserAuthContext(hRM);
			AUTHZ_SECURITY_ATTRIBUTES_INFORMATION attrs = new(new[] { new AUTHZ_SECURITY_ATTRIBUTE_V1("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", Environment.UserName) });
			Assert.That(AuthzModifyClaims(hCtx, AUTHZ_CONTEXT_INFORMATION_CLASS.AuthzContextInfoUserClaims, new[] { AUTHZ_SECURITY_ATTRIBUTE_OPERATION.AUTHZ_SECURITY_ATTRIBUTE_OPERATION_ADD }, attrs), ResultIs.Successful);
		}

		[Test]
		public void AuthzModifySecurityAttributesTest()
		{
			using SafeAUTHZ_RESOURCE_MANAGER_HANDLE hRM = GetAuthzInitializeResourceManager();
			using SafeAUTHZ_CLIENT_CONTEXT_HANDLE hCtx = GetCurrentUserAuthContext(hRM);
			AUTHZ_SECURITY_ATTRIBUTES_INFORMATION attrs = new(new[] { new AUTHZ_SECURITY_ATTRIBUTE_V1("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", Environment.UserName) });
			Assert.That(AuthzModifySecurityAttributes(hCtx, new[] { AUTHZ_SECURITY_ATTRIBUTE_OPERATION.AUTHZ_SECURITY_ATTRIBUTE_OPERATION_ADD }, attrs), ResultIs.Successful);
		}

		[Test]
		public void AuthzModifySidsTest()
		{
			using SafeAUTHZ_RESOURCE_MANAGER_HANDLE hRM = GetAuthzInitializeResourceManager();
			using SafeAUTHZ_CLIENT_CONTEXT_HANDLE hCtx = GetCurrentUserAuthContext(hRM);
			TOKEN_GROUPS tg = new(1);
			SafePSID psid = new("S-1-5-32-551");
			tg.Groups[0] = new SID_AND_ATTRIBUTES { Attributes = (uint)GroupAttributes.SE_GROUP_ENABLED, Sid = (IntPtr)psid };
			Assert.That(AuthzModifySids(hCtx, AUTHZ_CONTEXT_INFORMATION_CLASS.AuthzContextInfoGroupsSids, new[] { AUTHZ_SID_OPERATION.AUTHZ_SID_OPERATION_ADD }, in tg), ResultIs.Successful);
		}

		[Test]
		public void AuthzOpenObjectAuditTest()
		{
			using SafeAUTHZ_RESOURCE_MANAGER_HANDLE hRM = GetAuthzInitializeResourceManager();
			using SafeAUTHZ_CLIENT_CONTEXT_HANDLE hCtx = GetCurrentUserAuthContext(hRM);
			using SafeAUTHZ_AUDIT_EVENT_HANDLE hEvt = GetAuthzInitializeObjectAccessAuditEvent();
			using SafePSECURITY_DESCRIPTOR psd = AdvApi32Tests.GetSD(TestCaseSources.SmallFile);
			using AUTHZ_ACCESS_REPLY reply = new(1);
			AUTHZ_ACCESS_REQUEST req = new(ACCESS_MASK.MAXIMUM_ALLOWED);
			Assert.That(AuthzOpenObjectAudit(0, hCtx, req, hEvt, psd, null, 0, reply), ResultIs.Successful);
		}

		[Test]
		public void AuthzRegisterCapChangeNotificationTest()
		{
			Assert.That(AuthzRegisterCapChangeNotification(out SafeAUTHZ_CAP_CHANGE_SUBSCRIPTION_HANDLE hSub, callback, new IntPtr(2)), Is.True);
			// TODO: Find way to make something happen
			Assert.That(AuthzUnregisterCapChangeNotification(hSub), Is.True);

			static uint callback(IntPtr lpThreadParameter) { Assert.That(lpThreadParameter.ToInt32(), Is.EqualTo(2)); return 0; }
		}

		[Test]
		public void AuthzReportSecurityEventTest()
		{
			const int eventId = 4624;
			const string eventFile = "Some random string";
			const string eventSource = "TestAddEventSource";

			using (new ElevPriv("SeAuditPrivilege"))
			{
				AUTHZ_SOURCE_SCHEMA_REGISTRATION srcReg = new()
				{
					dwFlags = SOURCE_SCHEMA_REGISTRATION_FLAGS.AUTHZ_ALLOW_MULTIPLE_SOURCE_INSTANCES,
					szEventSourceName = eventSource,
					szEventMessageFile = eventFile,
					szEventAccessStringsFile = eventFile,
				};
				Assert.IsTrue(AuthzInstallSecurityEventSource(0, srcReg) || Win32Error.GetLastError() == Win32Error.ERROR_OBJECT_ALREADY_EXISTS);

				Assert.That(AuthzRegisterSecurityEventSource(0, eventSource, out SafeAUTHZ_SECURITY_EVENT_PROVIDER_HANDLE hEvtProv), ResultIs.Successful);
				try
				{
					Assert.That(AuthzReportSecurityEvent(APF.APF_AuditSuccess, hEvtProv, eventId, PSID.NULL, 6, __arglist(
						AUDIT_PARAM_TYPE.APT_String, "Testing",
						AUDIT_PARAM_TYPE.APT_Ulong, 123,
						AUDIT_PARAM_TYPE.APT_Guid, (IntPtr)new SafeCoTaskMemStruct<Guid>(Guid.NewGuid()),
						AUDIT_PARAM_TYPE.APT_Sid, (IntPtr)SafePSID.Current,
						AUDIT_PARAM_TYPE.APT_Int64, long.MaxValue - 1,
						AUDIT_PARAM_TYPE.APT_Time, DateTime.Now.ToFileTime()
						)), ResultIs.Successful);
				}
				finally { Assert.That(() => hEvtProv.Dispose(), Throws.Nothing); }
			}
		}

		[Test]
		public void AuthzReportSecurityEventFromParamsTest()
		{
			const int eventId = 4624;
			const string eventFile = "Some random string";
			const string eventSource = "TestAddEventSource";

			using (new ElevPriv("SeAuditPrivilege"))
			{
				AUTHZ_SOURCE_SCHEMA_REGISTRATION srcReg = new()
				{
					dwFlags = SOURCE_SCHEMA_REGISTRATION_FLAGS.AUTHZ_ALLOW_MULTIPLE_SOURCE_INSTANCES,
					szEventSourceName = eventSource,
					szEventMessageFile = eventFile,
					szEventAccessStringsFile = eventFile,
				};
				Assert.IsTrue(AuthzInstallSecurityEventSource(0, srcReg) || Win32Error.GetLastError() == Win32Error.ERROR_OBJECT_ALREADY_EXISTS);

				Assert.That(AuthzRegisterSecurityEventSource(0, eventSource, out SafeAUTHZ_SECURITY_EVENT_PROVIDER_HANDLE hEvtProv), ResultIs.Successful);
				try
				{
					using SafeCoTaskMemString data = new("Testing");
					using SafeNativeArray<AUDIT_PARAM> mem = new(new[] {
						new AUDIT_PARAM(AUDIT_PARAM_TYPE.APT_String, data),
						new AUDIT_PARAM(AUDIT_PARAM_TYPE.APT_Ulong, new IntPtr(123)),
					});
					AUDIT_PARAMS ap = new() { Count = (ushort)mem.Count, Parameters = mem };
					Assert.That(AuthzReportSecurityEventFromParams(0, hEvtProv, eventId, PSID.NULL, ap), ResultIs.Successful);
				}
				finally { Assert.That(() => hEvtProv.Dispose(), Throws.Nothing); }
			}
		}

		[Test]
		public void AuthzInstallSecurityEventSourceTest()
		{
			const string eventFile = "Some random string";
			const string eventSource = "InstTestEventSource";

			using (new ElevPriv("SeAuditPrivilege"))
			{
				AUTHZ_SOURCE_SCHEMA_REGISTRATION srcReg = new()
				{
					dwFlags = SOURCE_SCHEMA_REGISTRATION_FLAGS.AUTHZ_ALLOW_MULTIPLE_SOURCE_INSTANCES,
					szEventSourceName = eventSource,
					szEventMessageFile = eventFile,
					szEventAccessStringsFile = eventFile,
				};
				Assert.That(AuthzInstallSecurityEventSource(0, srcReg), ResultIs.Successful);
				Assert.That(AuthzUninstallSecurityEventSource(0, eventSource), Is.True);
			}
		}

		// TODO: Figure out how AuthzSetAppContainerInformation works
		// [Test]
			public void AuthzSetAppContainerInformationTest()
		{
			using SafeAUTHZ_RESOURCE_MANAGER_HANDLE hRM = GetAuthzInitializeResourceManager();
			using SafeAUTHZ_CLIENT_CONTEXT_HANDLE hCtx = GetCurrentUserAuthContext(hRM);
			using SafePSID localSid = ConvertStringSidToSid("S-1-2-0");
			using SafeHTOKEN hTok = SafeHTOKEN.FromProcess(GetCurrentProcess(), TokenAccess.TOKEN_ALL_ACCESS);
			TOKEN_APPCONTAINER_INFORMATION i = hTok.GetInfo<TOKEN_APPCONTAINER_INFORMATION>(TOKEN_INFORMATION_CLASS.TokenAppContainerSid);
			//var sids = new SID_AND_ATTRIBUTES(localSid, (uint)GroupAttributes.SE_GROUP_ENABLED);
			//var b = AuthzSetAppContainerInformation(hCtx, i.TokenAppContainer, 1, new[] { sids });
			Assert.That(AuthzSetAppContainerInformation(hCtx, i.TokenAppContainer, 0, null), ResultIs.Successful);
		}
	}
}