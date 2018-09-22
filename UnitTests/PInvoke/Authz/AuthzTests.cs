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
			var b = AuthzInitializeObjectAccessAuditEvent(AuthzAuditEventFlags.AUTHZ_NO_ALLOC_STRINGS, IntPtr.Zero, "", "", "", "", out var hEvt, 0);
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
		public void AuthzAccessCheckTest()
		{
			using (var hRM = GetAuthzInitializeResourceManager())
			using (var hCtx = GetCurrentUserAuthContext(hRM))
			using (var hEvt = GetAuthzInitializeObjectAccessAuditEvent())
			using (var psd = AdvApi32Tests.GetSD(@"C:\Temp\help.ico"))
			using (var reply = new AUTHZ_ACCESS_REPLY(1))
			{
				var req = new AUTHZ_ACCESS_REQUEST((uint)ACCESS_MASK.MAXIMUM_ALLOWED);
				var b = AuthzAccessCheck(AuthzAccessCheckFlags.NONE, hCtx, ref req, hEvt, psd, null, 0, reply, out var hRes);
				if (!b) TestContext.WriteLine($"AuthzAccessCheck:{Win32Error.GetLastError()}");
				Assert.That(b);
				Assert.That(reply.GrantedAccessMask, Is.Not.EqualTo(IntPtr.Zero));
				TestContext.WriteLine($"Access:{string.Join(",", reply.GrantedAccessMaskValues.Select(u => ((FileAccess)u).ToString()))}");
				hRes.Dispose();
				Assert.That(hRes.IsClosed);
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
		public void AuthzInitializeContextFromSidTest()
		{
			GetCurrentUserAuthContext(GetAuthzInitializeResourceManager());
		}

		[Test]
		public void AuthzInitializeContextFromTokenTest()
		{
			GetTokenAuthContext(GetAuthzInitializeResourceManager());
		}

		[Test]
		public void AuthzInitializeObjectAccessAuditEventTest()
		{
			GetAuthzInitializeObjectAccessAuditEvent();
		}

		[Test]
		public void AuthzInitializeResourceManagerTest()
		{
			GetAuthzInitializeResourceManager();
		}

		[Test]
		public void AuthzModifyClaimsTest()
		{
			using (var hRM = GetAuthzInitializeResourceManager())
			using (var hCtx = GetCurrentUserAuthContext(hRM))
			{
				var attrs = new AUTHZ_SECURITY_ATTRIBUTES_INFORMATION(new[] {new AUTHZ_SECURITY_ATTRIBUTE_V1("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", Environment.UserName)});
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
				var attrs = new AUTHZ_SECURITY_ATTRIBUTES_INFORMATION(new[] {new AUTHZ_SECURITY_ATTRIBUTE_V1("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", Environment.UserName)});
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
				var psid = new PSID("S-1-5-32-551");
				tg.Groups[0] = new SID_AND_ATTRIBUTES { Attributes = (uint)GroupAttributes.SE_GROUP_ENABLED, Sid = (IntPtr)psid};
				var b = AuthzModifySids(hCtx, AUTHZ_CONTEXT_INFORMATION_CLASS.AuthzContextInfoGroupsSids, new[] { AUTHZ_SID_OPERATION.AUTHZ_SID_OPERATION_ADD }, ref tg);
				if (!b) TestContext.WriteLine($"AuthzModifySids:{Win32Error.GetLastError()}");
				Assert.That(b);
			}
		}
	}
}