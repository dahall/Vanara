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
			var b = AuthzInitializeObjectAccessAuditEvent(AuthzAuditEventFlags.AUTHZ_NO_ALLOC_STRINGS, IntPtr.Zero, "", "", "", "", out var hEvt);
			if (!b) TestContext.WriteLine($"AuthzInitializeObjectAccessAuditEvent:{Win32Error.GetLastError()}");
			Assert.That(b);
			Assert.That(!hEvt.IsInvalid);
			return hEvt;
		}

		public static SafeAUTHZ_RESOURCE_MANAGER_HANDLE GetAuthzInitializeResourceManager()
		{
			var b = AuthzInitializeResourceManager(AuthzResourceManagerFlags.AUTHZ_RM_FLAG_NO_AUDIT, null, null, null, "Test", out var hResMgr);
			if (!b) TestContext.WriteLine($"AuthzInitializeResourceManager:{Win32Error.GetLastError()}");
			Assert.That(b);
			Assert.That(!hResMgr.IsInvalid);
			return hResMgr;
		}

		public static SafeHGlobalHandle GetCtxInfo(SafeAUTHZ_CLIENT_CONTEXT_HANDLE hCtx, AUTHZ_CONTEXT_INFORMATION_CLASS type)
		{
			var b = AuthzGetInformationFromContext(hCtx, type, 0, out var szReq, IntPtr.Zero);
			if (!b && Win32Error.GetLastError() != Win32Error.ERROR_INSUFFICIENT_BUFFER) TestContext.WriteLine($"AuthzGetInformationFromContext:{Win32Error.GetLastError()}");
			Assert.That(!b);
			if (szReq == 0) return SafeHGlobalHandle.Null;
			var buf = new SafeHGlobalHandle((int)szReq);
			b = AuthzGetInformationFromContext(hCtx, type, szReq, out szReq, (IntPtr)buf);
			if (!b) TestContext.WriteLine($"AuthzGetInformationFromContext:{Win32Error.GetLastError()}");
			Assert.That(b);
			return buf;
		}

		public static SafeAUTHZ_CLIENT_CONTEXT_HANDLE GetCurrentUserAuthContext(SafeAUTHZ_RESOURCE_MANAGER_HANDLE hResMgr)
		{
			var b = AuthzInitializeContextFromSid(AuthzContextFlags.DEFAULT, PSIDTests.GetCurrentSid(), hResMgr, IntPtr.Zero, new LUID(), IntPtr.Zero, out var hCtx);
			if (!b) TestContext.WriteLine($"AuthzInitializeContextFromSid:{Win32Error.GetLastError()}");
			Assert.That(b);
			Assert.That(!hCtx.IsInvalid);
			return hCtx;
		}

		public static SafeAUTHZ_CLIENT_CONTEXT_HANDLE GetTokenAuthContext(SafeAUTHZ_RESOURCE_MANAGER_HANDLE hRM)
		{
			using (var hTok = SafeHTOKEN.FromProcess(GetCurrentProcess(), TokenAccess.TOKEN_QUERY))
			{
				var b = AuthzInitializeContextFromToken(0, hTok, hRM, IntPtr.Zero, new LUID(), IntPtr.Zero, out var hCtx);
				if (!b) TestContext.WriteLine($"AuthzAccessCheck:{Win32Error.GetLastError()}");
				Assert.That(b);
				Assert.That(!hCtx.IsInvalid);
				return hCtx;
			}
		}

		[Test]
		public void AuthzAddSidsToContextTest()
		{
			using (var everyoneSid = ConvertStringSidToSid("S-1-1-0"))
			using (var localSid = ConvertStringSidToSid("S-1-2-0"))
			{
				var sids = new SID_AND_ATTRIBUTES { Sid = everyoneSid, Attributes = (uint)GroupAttributes.SE_GROUP_ENABLED };
				var restrictedSids = new SID_AND_ATTRIBUTES { Sid = localSid, Attributes = (uint)GroupAttributes.SE_GROUP_ENABLED };
				using (var hRM = GetAuthzInitializeResourceManager())
				using (var hCtx = GetCurrentUserAuthContext(hRM))
					Assert.That(AuthzAddSidsToContext(hCtx, sids, 1, restrictedSids, 1, out var hNewCtx), Is.True);
			}
		}

		[Test]
		public void AuthzEnumerateSecurityEventSourcesTest()
		{
			var mem = new SafeNativeArray<AUTHZ_SOURCE_SCHEMA_REGISTRATION>(200);
			var sz = (uint)mem.Size;
			var b = AuthzEnumerateSecurityEventSources(0, (IntPtr)mem, out var len, ref sz);
			Assert.That(b, Is.True);
			Assert.That(sz, Is.LessThanOrEqualTo(mem.Size));
			Assert.That(len, Is.GreaterThan(0));
			Assert.That(() => TestContext.WriteLine(mem[0].szEventSourceName), Throws.Nothing);
		}

		[Test]
		public void AuthzAccessCheckAndCachedTest()
		{
			using (var hRM = GetAuthzInitializeResourceManager())
			using (var hCtx = GetCurrentUserAuthContext(hRM))
			using (var hEvt = GetAuthzInitializeObjectAccessAuditEvent())
			using (var psd = AdvApi32Tests.GetSD(@"C:\Temp\help.ico"))
			using (var reply = new AUTHZ_ACCESS_REPLY(1))
			{
				var req = new AUTHZ_ACCESS_REQUEST((uint)ACCESS_MASK.MAXIMUM_ALLOWED);
				var b = AuthzAccessCheck(AuthzAccessCheckFlags.NONE, hCtx, req, hEvt, psd, null, 0, reply, out var hRes);
				if (!b) TestContext.WriteLine($"AuthzAccessCheck:{Win32Error.GetLastError()}");
				Assert.That(b);
				Assert.That(reply.GrantedAccessMask, Is.Not.EqualTo(IntPtr.Zero));
				TestContext.WriteLine($"Access:{string.Join(",", reply.GrantedAccessMaskValues.Select(u => ((FileAccess)u).ToString()))}");

				Assert.That(AuthzCachedAccessCheck(0, hRes, req, default, reply), Is.True);

				hRes.Dispose();
				Assert.That(hRes.IsClosed);

				Assert.That(AuthzFreeCentralAccessPolicyCache(), Is.True);
			}
		}

		[Test]
		public void AuthzGetInformationFromContextTest()
		{
			using (var hRM = GetAuthzInitializeResourceManager())
			using (var hCtx = GetCurrentUserAuthContext(hRM))
			{
				var buf = GetCtxInfo(hCtx, AUTHZ_CONTEXT_INFORMATION_CLASS.AuthzContextInfoGroupsSids);
				var tg = buf.ToStructure<TOKEN_GROUPS>();
				Assert.That(tg.GroupCount, Is.GreaterThan(0));

				buf = GetCtxInfo(hCtx, AUTHZ_CONTEXT_INFORMATION_CLASS.AuthzContextInfoUserClaims);
				var ai = AUTHZ_SECURITY_ATTRIBUTES_INFORMATION.FromPtr((IntPtr)buf);
				if (ai == null) return;
				Assert.That(ai.Version, Is.EqualTo(1));
				TestContext.WriteLine($"AuthzGetInformationFromContext(AuthzContextInfoUserClaims)={ai.AttributeCount}");
			}
		}

		[Test]
		public void AuthzInitializeCompoundContextTest()
		{
			using (var hRM = GetAuthzInitializeResourceManager())
			using (var hCtx = GetCurrentUserAuthContext(hRM))
			using (var hDevCtx = GetTokenAuthContext(hRM))
			{
				var b = AuthzInitializeCompoundContext(hCtx, hDevCtx, out var hCompCtx);
				if (!b) TestContext.WriteLine($"AuthzAccessCheck:{Win32Error.GetLastError()}");
				Assert.That(b);
				Assert.That(!hCompCtx.IsInvalid);
			}
		}

		[Test]
		public void AuthzInitializeContextFromAuthzContextTest()
		{
			using (var hRM = GetAuthzInitializeResourceManager())
			using (var hCtx = GetCurrentUserAuthContext(hRM))
			{
				var b = AuthzInitializeContextFromAuthzContext(0, hCtx, long.MaxValue, new LUID(), new IntPtr(2), out var hNewCtx);
				Assert.That(b, Is.True);
			}
		}

		[Test]
		public void AuthzInitializeContextFromSidTest()
		{
			using (var hRM = GetAuthzInitializeResourceManager())
			using (var hCtx = GetCurrentUserAuthContext(hRM))
			{
				Assert.That(hCtx.IsInvalid, Is.False);
			}
		}

		[Test]
		public void AuthzInitializeContextFromTokenTest()
		{
			using (var hRM = GetAuthzInitializeResourceManager())
			using (var hDevCtx = GetTokenAuthContext(hRM))
			{
				Assert.That(hDevCtx.IsInvalid, Is.False);
			}
		}

		[Test]
		public void AuthzInitializeObjectAccessAuditEventTest()
		{
			using (var hEvent = GetAuthzInitializeObjectAccessAuditEvent())
				Assert.That(hEvent.IsInvalid, Is.False);
		}

		[Test]
		public void AuthzInitializeObjectAccessAuditEvent2Test()
		{
			var b = AuthzInitializeObjectAccessAuditEvent2(0, default, "", "", "", "", "", out var hEvent);
			if (!b) TestContext.WriteLine($"AuthzInitializeObjectAccessAuditEvent2:{Win32Error.GetLastError()}");
			Assert.That(b, Is.True);
			Assert.That(hEvent.IsInvalid, Is.False);
		}

		[Test]
		public void AuthzInitializeRemoteResourceManagerTest()
		{
			var client = new AUTHZ_RPC_INIT_INFO_CLIENT
			{
				version = AUTHZ_RPC_INIT_INFO_CLIENT.AUTHZ_RPC_INIT_INFO_CLIENT_VERSION_V1,
				ObjectUuid = "5fc860e0-6f6e-4fc2-83cd-46324f25e90b",
				ProtSeq = "ncacn_ip_tcp",
				NetworkAddr = "192.168.0.1",
				Endpoint = "192.168.0.202[80]"
			};
			var b = AuthzInitializeRemoteResourceManager(client, out var hResMgr);
			if (!b) TestContext.WriteLine($"AuthzInitializeResourceManager:{Win32Error.GetLastError()}");
			Assert.That(b);
			Assert.That(!hResMgr.IsInvalid);
		}

		[Test]
		public void AuthzInitializeResourceManagerTest()
		{
			GetAuthzInitializeResourceManager();
		}

		[Test]
		public void AuthzInitializeResourceManagerExTest()
		{
			var info = new AUTHZ_INIT_INFO
			{
				version = AUTHZ_INIT_INFO.AUTHZ_INIT_INFO_VERSION_V1
			};
			var b = AuthzInitializeResourceManagerEx(AuthzResourceManagerFlags.AUTHZ_RM_FLAG_NO_AUDIT, info, out var hResMgr);
			if (!b) TestContext.WriteLine($"AuthzInitializeResourceManager:{Win32Error.GetLastError()}");
			Assert.That(b);
			Assert.That(!hResMgr.IsInvalid);
		}

		[Test]
		public void AuthzModifyClaimsTest()
		{
			using (var hRM = GetAuthzInitializeResourceManager())
			using (var hCtx = GetCurrentUserAuthContext(hRM))
			{
				var attrs = new AUTHZ_SECURITY_ATTRIBUTES_INFORMATION(new[] { new AUTHZ_SECURITY_ATTRIBUTE_V1("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", Environment.UserName) });
				var b = AuthzModifyClaims(hCtx, AUTHZ_CONTEXT_INFORMATION_CLASS.AuthzContextInfoUserClaims, new[] { AUTHZ_SECURITY_ATTRIBUTE_OPERATION.AUTHZ_SECURITY_ATTRIBUTE_OPERATION_ADD }, attrs);
				if (!b) TestContext.WriteLine($"AuthzModifyClaims:{Win32Error.GetLastError()}");
				Assert.That(b);
			}
		}

		[Test]
		public void AuthzModifySecurityAttributesTest()
		{
			using (var hRM = GetAuthzInitializeResourceManager())
			using (var hCtx = GetCurrentUserAuthContext(hRM))
			{
				var attrs = new AUTHZ_SECURITY_ATTRIBUTES_INFORMATION(new[] { new AUTHZ_SECURITY_ATTRIBUTE_V1("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", Environment.UserName) });
				var b = AuthzModifySecurityAttributes(hCtx, new[] { AUTHZ_SECURITY_ATTRIBUTE_OPERATION.AUTHZ_SECURITY_ATTRIBUTE_OPERATION_ADD }, attrs);
				if (!b) TestContext.WriteLine($"AuthzModifySecurityAttributes:{Win32Error.GetLastError()}");
				Assert.That(b);
			}
		}

		[Test]
		public void AuthzModifySidsTest()
		{
			using (var hRM = GetAuthzInitializeResourceManager())
			using (var hCtx = GetCurrentUserAuthContext(hRM))
			{
				var tg = new TOKEN_GROUPS(1);
				var psid = new SafePSID("S-1-5-32-551");
				tg.Groups[0] = new SID_AND_ATTRIBUTES { Attributes = (uint)GroupAttributes.SE_GROUP_ENABLED, Sid = (IntPtr)psid };
				var b = AuthzModifySids(hCtx, AUTHZ_CONTEXT_INFORMATION_CLASS.AuthzContextInfoGroupsSids, new[] { AUTHZ_SID_OPERATION.AUTHZ_SID_OPERATION_ADD }, in tg);
				if (!b) TestContext.WriteLine($"AuthzModifySids:{Win32Error.GetLastError()}");
				Assert.That(b);
			}
		}

		[Test]
		public void AuthzOpenObjectAuditTest()
		{
			using (var hRM = GetAuthzInitializeResourceManager())
			using (var hCtx = GetCurrentUserAuthContext(hRM))
			using (var hEvt = GetAuthzInitializeObjectAccessAuditEvent())
			using (var psd = AdvApi32Tests.GetSD(@"C:\Temp\help.ico"))
			using (var reply = new AUTHZ_ACCESS_REPLY(1))
			{
				var req = new AUTHZ_ACCESS_REQUEST((uint)ACCESS_MASK.MAXIMUM_ALLOWED);
				var b = AuthzOpenObjectAudit(0, hCtx, req, hEvt, psd, null, 0, reply);
				if (!b) TestContext.WriteLine($"AuthzOpenObjectAudit:{Win32Error.GetLastError()}");
				Assert.That(b, Is.True);
			}
		}

		[Test]
		public void AuthzRegisterCapChangeNotificationTest()
		{
			Assert.That(AuthzRegisterCapChangeNotification(out var hSub, callback, new IntPtr(2)), Is.True);
			// TODO: Find way to make something happen
			Assert.That(AuthzUnregisterCapChangeNotification(hSub), Is.True);

			uint callback(IntPtr lpThreadParameter) { Assert.That(lpThreadParameter.ToInt32(), Is.EqualTo(2)); return 0; }
		}

		[Test]
		public void AuthzRegisterSecurityEventSourceTest()
		{
			const string eventSource = "TestEventSource";

			using (new PrivBlock("SeAuditPrivilege"))
			{
				var srcReg = new AUTHZ_SOURCE_SCHEMA_REGISTRATION_IN { szEventSourceName = eventSource, szEventAccessStringsFile = @"%SystemRoot%\System32\MsObjs.dll" };
				Assert.That(AuthzInstallSecurityEventSource(0, srcReg), Is.True);
				var b = AuthzRegisterSecurityEventSource(0, eventSource, out var hEvtProv);
				if (!b) TestContext.WriteLine($"AuthzRegisterSecurityEventSource:{Win32Error.GetLastError()}");
				//Assert.That(b, Is.True); This is due to a Domain-defined Local policy

				if (b)
				{
					using (var data = new SafeHGlobalHandle("Testing"))
					using (var mem = SafeHGlobalHandle.CreateFromStructure(new AUDIT_PARAM { Type = AUDIT_PARAM_TYPE.APT_String, Data0 = (IntPtr)data }))
					{
						var ap = new AUDIT_PARAMS { Count = 1, Parameters = (IntPtr)mem };
						b = AuthzReportSecurityEventFromParams(0, hEvtProv, 4624, PSID.NULL, ap);
						if (!b) TestContext.WriteLine($"AuthzReportSecurityEvent:{Win32Error.GetLastError()}");
						Assert.That(b, Is.True);
					}

					b = AuthzReportSecurityEvent(APF.APF_AuditSuccess, hEvtProv, 4624, PSID.NULL, 1, __arglist(AUDIT_PARAM_TYPE.APT_String, "Testing"));
					if (!b) TestContext.WriteLine($"AuthzReportSecurityEvent:{Win32Error.GetLastError()}");
					Assert.That(b, Is.True);

					Assert.That(AuthzUnregisterSecurityEventSource(0, hEvtProv), Is.True);
				}

				Assert.That(AuthzUninstallSecurityEventSource(0, eventSource), Is.True);
			}
		}

		// TODO: Figure out how AuthzSetAppContainerInformation works
		// [Test]
		public void AuthzSetAppContainerInformationTest()
		{
			using (var hRM = GetAuthzInitializeResourceManager())
			using (var hCtx = GetCurrentUserAuthContext(hRM))
			using (var localSid = ConvertStringSidToSid("S-1-2-0"))
			using (var hTok = SafeHTOKEN.FromProcess(GetCurrentProcess(), TokenAccess.TOKEN_ALL_ACCESS))
			{
				var i = hTok.GetInfo<TOKEN_APPCONTAINER_INFORMATION>(TOKEN_INFORMATION_CLASS.TokenAppContainerSid);
				//var sids = new SID_AND_ATTRIBUTES(localSid, (uint)GroupAttributes.SE_GROUP_ENABLED);
				//var b = AuthzSetAppContainerInformation(hCtx, i.TokenAppContainer, 1, new[] { sids });
				var b = AuthzSetAppContainerInformation(hCtx, i.TokenAppContainer, 0, null);
				if (!b) TestContext.WriteLine($"AuthzSetAppContainerInformation:{Win32Error.GetLastError()}");
				Assert.That(b, Is.True);
			}
		}
	}

	internal class PrivBlock : IDisposable
	{
		SafeCoTaskMemHandle prevState;
		SafeHTOKEN tok;

		public PrivBlock(string priv)
		{
			tok = SafeHTOKEN.FromProcess(GetCurrentProcess(), TokenAccess.TOKEN_ADJUST_PRIVILEGES | TokenAccess.TOKEN_QUERY);
			var newPriv = new PTOKEN_PRIVILEGES(LUID.FromName(priv), PrivilegeAttributes.SE_PRIVILEGE_ENABLED);
			prevState = PTOKEN_PRIVILEGES.GetAllocatedAndEmptyInstance();
			if (!AdjustTokenPrivileges(tok, false, newPriv, (uint)prevState.Size, prevState, out var retLen))
				Win32Error.ThrowLastError();
		}

		public void Dispose()
		{
			AdjustTokenPrivileges(tok, false, prevState);
			prevState.Dispose();
			tok.Dispose();
		}
	}
}