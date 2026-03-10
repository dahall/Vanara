using NUnit.Framework;
using static Vanara.PInvoke.AdvApi32;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests;

[TestFixture()]
public class WinBaseTests
{
	private const string objType = "TestObj";
	private const string subSys = "Files";
	private const SECURITY_INFORMATION siNoSacl = SECURITY_INFORMATION.DACL_SECURITY_INFORMATION | SECURITY_INFORMATION.OWNER_SECURITY_INFORMATION | SECURITY_INFORMATION.GROUP_SECURITY_INFORMATION;
	private SafePSID? pCurSid;
	private ElevPriv? secPriv;

	[OneTimeSetUp]
	public void _SetupTests()
	{
		pCurSid = SafePSID.Current;
		secPriv = new ElevPriv(["SeSecurityPrivilege", "SeAuditPrivilege"]);
	}

	[OneTimeTearDown]
	public void _TearDownTests()
	{
		pCurSid?.Dispose();
		secPriv?.Dispose();
	}

	[Test]
	public void AccessCheckAndAuditAlarmTest()
	{
		using ElevPriv priv = new("SeAuditPrivilege", GetCurrentProcess(), TokenAccess.TOKEN_DUPLICATE | TokenAccess.TOKEN_QUERY | TokenAccess.TOKEN_IMPERSONATE | TokenAccess.TOKEN_ADJUST_PRIVILEGES);
		using ImpersonationContext ic = new(priv.hTok);
		using var pSD = AdvApi32Tests.GetSD(AdvApi32Tests.fn, siNoSacl);
		var gm = GENERIC_MAPPING.GenericFileMapping;
		ACCESS_MASK accessMask = ACCESS_MASK.GENERIC_READ;
		MapGenericMask(ref accessMask, gm);
		Assert.That(AccessCheckAndAuditAlarm(subSys, 1, objType, null, pSD, accessMask, gm, true, out var access, out var status, out var gen), ResultIs.Successful);
		Assert.That(access, Is.EqualTo((uint)FileAccess.FILE_GENERIC_READ));
		Assert.That(status, Is.True);
	}

	internal class ImpersonationContext : IDisposable
	{
		public readonly SafeHTOKEN hTok;
		public ImpersonationContext(SafeHTOKEN hTok, SECURITY_IMPERSONATION_LEVEL impLevel = SECURITY_IMPERSONATION_LEVEL.SecurityImpersonation)
		{
			this.hTok = hTok.Duplicate(impLevel);
			Assert.That(ImpersonateLoggedOnUser(hTok), ResultIs.Successful);
		}
		public ImpersonationContext(HPROCESS proc = default, TokenAccess desiredAccess = TokenAccess.TOKEN_DUPLICATE | TokenAccess.TOKEN_QUERY | TokenAccess.TOKEN_IMPERSONATE | TokenAccess.TOKEN_ADJUST_PRIVILEGES)
			: this(SafeHTOKEN.FromProcess(proc.IsNull ? GetCurrentProcess() : proc, desiredAccess))
		{
		}
		public void Dispose()
		{
			Assert.That(RevertToSelf(), ResultIs.Successful);
			GC.SuppressFinalize(this);
		}
	}

	[Test]
	public void AccessCheckByTypeAndAuditAlarmTest()
	{
		using ElevPriv priv = new("SeAuditPrivilege", GetCurrentProcess(), TokenAccess.TOKEN_DUPLICATE | TokenAccess.TOKEN_QUERY | TokenAccess.TOKEN_IMPERSONATE | TokenAccess.TOKEN_ADJUST_PRIVILEGES);
		using ImpersonationContext ic = new(priv.hTok);
		using var pSD = AdvApi32Tests.GetSD(AdvApi32Tests.fn, siNoSacl);
		var gm = GENERIC_MAPPING.GenericFileMapping;
		ACCESS_MASK accessMask = ACCESS_MASK.GENERIC_READ;
		MapGenericMask(ref accessMask, gm);
		OBJECT_TYPE_LIST[] otl = [OBJECT_TYPE_LIST.Self, new(ObjectTypeListLevel.ACCESS_PROPERTY_SET_GUID)];
		Assert.That(AccessCheckByTypeAndAuditAlarm(subSys, default, objType, null, pSD, pCurSid ?? PSID.NULL, accessMask, AUDIT_EVENT_TYPE.AuditEventObjectAccess,
			AccessCheckFlags.AUDIT_ALLOW_NO_PRIVILEGE, otl, (uint)otl.Length, gm, false, out var access, out var status, out var gen), ResultIs.Successful);
		//Assert.That(access, Is.EqualTo((uint)FileAccess.FILE_GENERIC_READ));
		//Assert.That(status, Is.True);
	}

	[Test]
	public void AccessCheckByTypeResultListAndAuditAlarmTest()
	{
		using ElevPriv priv = new("SeAuditPrivilege", GetCurrentProcess(), TokenAccess.TOKEN_DUPLICATE | TokenAccess.TOKEN_QUERY | TokenAccess.TOKEN_IMPERSONATE | TokenAccess.TOKEN_ADJUST_PRIVILEGES);
		using ImpersonationContext ic = new(priv.hTok);
		using var pSD = AdvApi32Tests.GetSD(AdvApi32Tests.fn, siNoSacl);
		var gm = GENERIC_MAPPING.GenericFileMapping;
		ACCESS_MASK accessMask = ACCESS_MASK.GENERIC_READ;
		MapGenericMask(ref accessMask, gm);
		OBJECT_TYPE_LIST[] otl = [OBJECT_TYPE_LIST.Self, new(ObjectTypeListLevel.ACCESS_PROPERTY_SET_GUID)];
		Assert.That(AccessCheckByTypeResultListAndAuditAlarm(subSys, default, objType, null, pSD, pCurSid ?? PSID.NULL, accessMask, AUDIT_EVENT_TYPE.AuditEventObjectAccess,
			AccessCheckFlags.AUDIT_ALLOW_NO_PRIVILEGE, otl, gm, false, out var access, out var status, out var gen), ResultIs.Successful);
		Assert.That(access[0], Is.EqualTo((uint)FileAccess.FILE_GENERIC_READ));
		Assert.That(status[0], Is.Zero);
	}

	[Test]
	public void AccessCheckByTypeResultListAndAuditAlarmByHandleTest()
	{
		using ElevPriv priv = new("SeAuditPrivilege", GetCurrentProcess(), TokenAccess.TOKEN_DUPLICATE | TokenAccess.TOKEN_QUERY | TokenAccess.TOKEN_IMPERSONATE | TokenAccess.TOKEN_ADJUST_PRIVILEGES);
		using ImpersonationContext ic = new(priv.hTok);
		using var pSD = AdvApi32Tests.GetSD(AdvApi32Tests.fn, siNoSacl);
		var gm = GENERIC_MAPPING.GenericFileMapping;
		ACCESS_MASK accessMask = ACCESS_MASK.GENERIC_READ;
		MapGenericMask(ref accessMask, gm);
		OBJECT_TYPE_LIST[] otl = [OBJECT_TYPE_LIST.Self, new(ObjectTypeListLevel.ACCESS_PROPERTY_SET_GUID)];
		Assert.That(AccessCheckByTypeResultListAndAuditAlarmByHandle(subSys, 1, ic.hTok, objType, null, pSD, PSID.NULL, accessMask, AUDIT_EVENT_TYPE.AuditEventObjectAccess,
			AccessCheckFlags.AUDIT_ALLOW_NO_PRIVILEGE, otl, gm, false, out var access, out var status, out var gen), ResultIs.Successful);
		Assert.That(access[0], Is.EqualTo((uint)FileAccess.FILE_GENERIC_READ));
		Assert.That(status[0], Is.Zero);
	}

	[Test]
	public void AddConditionalAceTest()
	{
		using var pACL = new SafePACL(256);
		Assert.That(AddConditionalAce(pACL, ACL_REVISION, System.Security.AccessControl.AceFlags.None, System.Security.AccessControl.AceType.AccessAllowedCallback,
			(uint)FileAccess.FILE_GENERIC_READ, SafePSID.Everyone, "(exists Administrator)", out var ret), ResultIs.Successful);
	}

	[Test, TestCaseSource(typeof(TestCaseSources), nameof(TestCaseSources.GetAuthCasesFromFile), [true, true])]
	public void CreateProcessWithLogonWTest(bool validUser, bool validCred, string urn, string dn, string dc, string domain, string username, string? password, string share, string printer, string notes)
	{
		Assert.That(CreateProcessWithLogonW(username, dn, password ?? "", ProcessLogonFlags.LOGON_NETCREDENTIALS_ONLY, @"C:\Windows\notepad.exe", null, CREATE_PROCESS.NORMAL_PRIORITY_CLASS, null, null,
			new(ShowWindowCommand.SW_SHOWNORMAL), out var pi), ResultIs.Successful);
		using (pi)
			TerminateProcess(pi!.hProcess, 0);
	}

	[Test]
	public void CreateProcessWithTokenWTest()
	{
		using var hTok = SafeHTOKEN.FromProcess(GetCurrentProcess()).DuplicatePrimary(TokenAccess.TOKEN_ASSIGN_PRIMARY | TokenAccess.TOKEN_DUPLICATE | TokenAccess.TOKEN_QUERY | TokenAccess.TOKEN_ADJUST_DEFAULT | TokenAccess.TOKEN_ADJUST_SESSIONID);
		var sti = new STARTUPINFO { ShowWindowCommand = ShowWindowCommand.SW_SHOWMINIMIZED };
		Assert.That(CreateProcessWithTokenW(hTok, 0, @"C:\Windows\notepad.exe", null, CREATE_PROCESS.NORMAL_PRIORITY_CLASS, null, null,
			sti, out var pi), ResultIs.Successful);
		using (pi)
			TerminateProcess(pi!.hProcess, 0);
	}

	[Test]
	public void EnDecryptFileTest()
	{
		Assert.That(EncryptFile(AdvApi32Tests.fn), ResultIs.Successful);
		try
		{
			Assert.That(FileEncryptionStatus(AdvApi32Tests.fn, out var stat), ResultIs.Successful);
			Assert.That(stat.HasFlag(EncryptionStatus.FILE_IS_ENCRYPTED), Is.True);

			Assert.That(OpenEncryptedFileRaw(AdvApi32Tests.fn, 0, out var ctx), ResultIs.Successful);
			using (ctx)
			{
				Assert.That(ReadEncryptedFileRaw(Export, default, ctx), ResultIs.Successful);
				Assert.That(WriteEncryptedFileRaw(Import, default, ctx), ResultIs.FailureCode(Win32Error.ERROR_ACCESS_DENIED));
			}
		}
		finally
		{
			Assert.That(DecryptFile(AdvApi32Tests.fn), ResultIs.Successful);
		}

		Win32Error Export(IntPtr pbData, IntPtr pvCallbackContext, uint ulLength) => Win32Error.ERROR_SUCCESS;

		Win32Error Import(IntPtr pbData, IntPtr pvCallbackContext, ref uint ulLength) => Win32Error.ERROR_SUCCESS;
	}

	[Test]
	public void GetCurrentHwProfileTest()
	{
		Assert.That(GetCurrentHwProfile(out var hw), ResultIs.Successful);
		Assert.That(hw.szHwProfileGuid, Is.Not.Null.Or.Empty);
		hw.WriteValues();
	}

	[Test]
	public void GetSetFileSecurityTest()
	{
		using var tmp = new TempFile();
		SafePSECURITY_DESCRIPTOR psd;
		Assert.That(psd = GetFileSecurity(tmp.FullName), ResultIs.ValidHandle);
		using (psd)
			Assert.That(SetFileSecurity(tmp.FullName, SECURITY_INFORMATION.OWNER_SECURITY_INFORMATION, psd), ResultIs.Successful);
	}

	[Test]
	public void GetUserNameTest()
	{
		var sb = new StringBuilder(UNLEN + 1);
		var sz = (uint)sb.Capacity;
		Assert.That(GetUserName(sb, ref sz), ResultIs.Successful);
		Assert.That(sb.ToString(), Is.EqualTo(Environment.UserName));
	}

	[Test]
	public void ImpersonateNamedPipeClientTest()
	{
		using (new ElevPriv("SeImpersonatePrivilege"))
		using (var hPipe = CreateNamedPipe(@"\\.\pipe\testpipe", PIPE_ACCESS.PIPE_ACCESS_DUPLEX, PIPE_TYPE.PIPE_SERVER_END, 1, 1024, 1024, 0))
		{
			Assert.That(hPipe, ResultIs.ValidHandle);
			Assert.That(ImpersonateNamedPipeClient(hPipe), ResultIs.FailureCode(Win32Error.ERROR_CANNOT_IMPERSONATE));
		}
	}

	[Test]
	public void IsTextUnicodeTest()
	{
		var aBuf = "a".GetBytes(true, CharSet.Ansi);
		var isNotUni = IS_TEXT_UNICODE.IS_TEXT_UNICODE_ASCII16;
		Assert.That(IsTextUnicode(aBuf, aBuf.Length, ref isNotUni), ResultIs.Successful);

		var uBuf = new SafeCoTaskMemString("a");
		var isUni = IS_TEXT_UNICODE.IS_TEXT_UNICODE_ASCII16;
		Assert.That(IsTextUnicode(uBuf, uBuf.Size, ref isUni), ResultIs.Successful);
		Assert.That(isUni.HasFlag(IS_TEXT_UNICODE.IS_TEXT_UNICODE_ASCII16));
	}

	[Test, TestCaseSource(typeof(TestCaseSources), nameof(TestCaseSources.AuthCasesFromFile))]
	public void LogonUserTest(bool validUser, bool validCred, string? urn, string? dn, string? dc, string? domain, string? username, string? pwd, string? share, string? printer, string? notes)
	{
		Assert.That(LogonUser(urn!, domain, pwd, LogonUserType.LOGON32_LOGON_INTERACTIVE, LogonUserProvider.LOGON32_PROVIDER_DEFAULT, out var hTok),
			validCred && validUser ? (NUnit.Framework.Constraints.IResolveConstraint)ResultIs.Successful : ResultIs.Failure);
		hTok.Dispose();
	}

	[Test, TestCaseSource(typeof(TestCaseSources), nameof(TestCaseSources.AuthCasesFromFile))]
	public void LogonUserExTest(bool validUser, bool validCred, string? urn, string? dn, string? dc, string? domain, string? username, string? pwd, string? share, string? printer, string? notes)
	{
		Assert.That(LogonUserEx(urn!, domain, pwd, LogonUserType.LOGON32_LOGON_INTERACTIVE, LogonUserProvider.LOGON32_PROVIDER_DEFAULT),
			validCred && validUser ? (NUnit.Framework.Constraints.IResolveConstraint)ResultIs.Successful : ResultIs.Failure);
	}

	[Test, TestCaseSource(typeof(TestCaseSources), nameof(TestCaseSources.AuthCasesFromFile))]
	public void LogonUserExExTest(bool validUser, bool validCred, string? urn, string? dn, string? dc, string? domain, string? username, string? pwd, string? share, string? printer, string? notes)
	{
		const GroupAttributes ga = GroupAttributes.SE_GROUP_ENABLED | GroupAttributes.SE_GROUP_ENABLED_BY_DEFAULT | GroupAttributes.SE_GROUP_MANDATORY;
		using (new ElevPriv("SeTcbPrivilege"))
		using (var hPol = LsaOpenPolicy(LsaPolicyRights.POLICY_ALL_ACCESS))
		using (var pLocalSid = SafePSID.CreateWellKnown(WELL_KNOWN_SID_TYPE.WinLocalSid))
		using (var pLocalAcctSid = SafePSID.CreateWellKnown(WELL_KNOWN_SID_TYPE.WinLocalAccountSid))
		{
			using SafeHGlobalStruct<TOKEN_GROUPS> grps = new TOKEN_GROUPS([new SID_AND_ATTRIBUTES(pLocalSid, (uint)ga), new SID_AND_ATTRIBUTES(pLocalAcctSid, (uint)ga)]);
			Assert.That(LogonUserExExW(urn!, domain, pwd, LogonUserType.LOGON32_LOGON_INTERACTIVE, LogonUserProvider.LOGON32_PROVIDER_DEFAULT),
				validCred && validUser ? (NUnit.Framework.Constraints.IResolveConstraint)ResultIs.Successful : ResultIs.Failure);
		}
	}

	[Test, TestCaseSource(typeof(TestCaseSources), nameof(TestCaseSources.AuthCasesFromFile))]
	public void LookupAccountNameSidTest(bool validUser, bool validCred, string? urn, string? dn, string? dc, string? domain, string? username, string? pwd, string? share, string? printer, string? notes)
	{
		var fun = $"{dn}\\{username}";
		TestContext.WriteLine(fun);
		Assert.That(LookupAccountName(null, fun, out var sid, out var dom, out var snu),
			validCred && validUser ? (NUnit.Framework.Constraints.IResolveConstraint)ResultIs.Successful : ResultIs.Failure); 
		Assert.That(sid.IsValidSid, Is.EqualTo(validUser));
		if (!validUser) return;

		Assert.That(dom, Is.EqualTo(dn).IgnoreCase);
		Assert.That(snu, Is.EqualTo(SID_NAME_USE.SidTypeUser));

		Assert.That(LookupAccountSid(null, sid, out var name, out var domN, out snu), ResultIs.Successful);
		Assert.That(name, Is.EqualTo(username).IgnoreCase);
		Assert.That(domN, Is.EqualTo(dn).IgnoreCase);
		Assert.That(snu, Is.EqualTo(SID_NAME_USE.SidTypeUser));

		Assert.That(LookupAccountSid2(null, sid, out var name2, out var domN2, out var snu2), ResultIs.Successful);
		Assert.That(name, Is.EqualTo(name2));
		Assert.That(domN, Is.EqualTo(domN2));
		Assert.That(snu, Is.EqualTo(snu2));
	}

	[Test]
	public void LookupPrivilegeDisplayNameTest()
	{
		var sb = new StringBuilder(1024);
		var sz = (uint)sb.Capacity;
		Assert.That(LookupPrivilegeDisplayName(null, "SeTcbPrivilege", sb, ref sz, out _), ResultIs.Successful);
		TestContext.Write(sb);
	}

	[Test()]
	public void LookupPrivilegeNameValueTest()
	{
		const string priv = "SeBackupPrivilege";
		Assert.That(LookupPrivilegeValue(null, priv, out var luid));
		var chSz = 100U;
		var sb = new StringBuilder((int)chSz);
		Assert.That(LookupPrivilegeName(null, luid, sb, ref chSz));
		Assert.That(sb.ToString(), Is.EqualTo(priv));

		// Look at bad values
		Assert.That(LookupPrivilegeValue(null, "SeBadPrivilege", out _), Is.False);
		luid = LUID.NewLUID();
		Assert.That(LookupPrivilegeName(null, luid, sb, ref chSz), Is.False);
	}

	[Test]
	public void ObjectOpenCloseAuditAlarmTest()
	{
		using var pSD = AdvApi32Tests.GetSD(AdvApi32Tests.fn, siNoSacl);
		using var hTok = SafeHTOKEN.FromProcess(GetCurrentProcess(), TokenAccess.TOKEN_IMPERSONATE | TokenAccess.TOKEN_DUPLICATE | TokenAccess.TOKEN_READ).Duplicate(SECURITY_IMPERSONATION_LEVEL.SecurityImpersonation);
		var ps = PRIVILEGE_SET.InitializeWithCapacity(100);
		var psSz = ps.SizeInBytes;
		var gm = GENERIC_MAPPING.GenericFileMapping;
		ACCESS_MASK accessMask = ACCESS_MASK.GENERIC_READ;
		MapGenericMask(ref accessMask, gm);
		var otl = new[] { new OBJECT_TYPE_LIST(ObjectTypeListLevel.ACCESS_OBJECT_GUID) };
		var access = new uint[otl.Length];
		var status = new uint[otl.Length];
		Assert.That(ObjectOpenAuditAlarm(subSys, default, objType, null, pSD, hTok, accessMask, accessMask, ps, false, true, out var gen), ResultIs.FailureCode(Win32Error.ERROR_PRIVILEGE_NOT_HELD));
		//Assert.That(ps.PrivilegeCount, Is.GreaterThanOrEqualTo(0));
		//Assert.That(access[0], Is.EqualTo((uint)FileAccess.FILE_GENERIC_READ));
		//Assert.That(status[0], Is.Zero);
		Assert.That(ObjectCloseAuditAlarm(subSys, default, gen), ResultIs.Failure);
	}

	[Test]
	public void ObjectPrivilegeAuditAlarmTest()
	{
		using var hTok = SafeHTOKEN.FromProcess(GetCurrentProcess()).DuplicatePrimary(TokenAccess.TOKEN_ASSIGN_PRIMARY | TokenAccess.TOKEN_DUPLICATE | TokenAccess.TOKEN_QUERY | TokenAccess.TOKEN_ADJUST_DEFAULT | TokenAccess.TOKEN_ADJUST_SESSIONID);
		var gm = GENERIC_MAPPING.GenericFileMapping;
		ACCESS_MASK accessMask = ACCESS_MASK.GENERIC_READ;
		MapGenericMask(ref accessMask, gm);
		var ps = PRIVILEGE_SET.InitializeWithCapacity(100);
		var psSz = ps.SizeInBytes;
		Assert.That(ObjectPrivilegeAuditAlarm(subSys, default, hTok, accessMask, ps, true), ResultIs.FailureCode(Win32Error.ERROR_PRIVILEGE_NOT_HELD));
	}

	[Test]
	public void OperationStartEndTest()
	{
		const uint opId = 345;
		Assert.That(OperationStart(new OPERATION_START_PARAMETERS(opId, true)), ResultIs.Successful);
		Assert.That(OperationEnd(new OPERATION_END_PARAMETERS(opId, true)), ResultIs.Successful);
	}

	[Test]
	public void PrivilegedServiceAuditAlarmTest()
	{
		using (var hTok = SafeHTOKEN.FromProcess(GetCurrentProcess()).DuplicatePrimary())
		using (new ElevPriv("SeAuditPrivilege", hTok))
		{
			var ps = new PRIVILEGE_SET(PrivilegeSetControl.None, LUID.FromName("SeSecurityPrivilege"), PrivilegeAttributes.SE_PRIVILEGE_ENABLED);
			Assert.That(PrivilegedServiceAuditAlarm(subSys, "PrivSvc", hTok, ps, true), ResultIs.FailureCode(Win32Error.ERROR_PRIVILEGE_NOT_HELD));
		}
	}
}