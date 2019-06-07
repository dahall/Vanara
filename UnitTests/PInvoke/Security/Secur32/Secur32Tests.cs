using NUnit.Framework;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.AdvApi32;
using static Vanara.PInvoke.Schannel;
using static Vanara.PInvoke.Secur32;

namespace Vanara.PInvoke.Tests
{
	[TestFixture()]
	public class Secur32Tests
	{
		private SafeLsaConnectionHandle hLsaConn;

		[Test]
		public void AcquireCredentialsHandleTest()
		{
			var hCred = SafeCredHandle.Null;
			Assert.That(() => hCred = SafeCredHandle.Acquire("Kerberos", SECPKG_CRED.SECPKG_CRED_OUTBOUND), Throws.Nothing);
			Assert.That(hCred.DangerousGetHandle().IsInvalid, Is.False);
			Assert.That(() => ((IDisposable)hCred).Dispose(), Throws.Nothing);

			var sid = new SEC_WINNT_AUTH_IDENTITY(Environment.UserName, Environment.UserDomainName, "");
			Assert.That(() => hCred = SafeCredHandle.Acquire<SEC_WINNT_AUTH_IDENTITY>(NTLMSP_NAME, SECPKG_CRED.SECPKG_CRED_OUTBOUND, sid, null, null, out _), Throws.Nothing);
			Assert.That(hCred.DangerousGetHandle().IsInvalid, Is.False);
			Assert.That(() => ((IDisposable)hCred).Dispose(), Throws.Nothing);
		}

		// This just fails and is largely undocumented [Test]
		public void AddDelSecurityPackageTest()
		{
			const string pkgName = "MyTestPkg";
			var mem = new SafeHGlobalHandle(64);
			var opt = new SECURITY_PACKAGE_OPTIONS
			{
				Size = (uint)Marshal.SizeOf(typeof(SECURITY_PACKAGE_OPTIONS)),
				Type = SECPKG_OPTIONS_TYPE.SECPKG_OPTIONS_TYPE_LSA,
				Signature = (IntPtr)mem,
				SignatureSize = (uint)mem.Size
			};
			Assert.That(AddSecurityPackage(pkgName, opt), Is.EqualTo(HRESULT.S_OK));
			Assert.That(DeleteSecurityPackage(pkgName), Is.EqualTo(HRESULT.S_OK));
		}

		[Test]
		public void ApplyControlTokenTest()
		{
			using (var hCred = AcqCredHandle())
			using (var hCtx = GetSecContext(hCred, out var pSecDesc))
			{
				using (var sbd = new SafeSecBufferDesc())
				{
					Assert.That(ApplyControlToken(hCtx, pSecDesc.GetRef()), Is.EqualTo((HRESULT)HRESULT.SEC_E_UNSUPPORTED_FUNCTION));
				}
			}
		}

		[Test]
		public void ChangeAccountPasswordTest()
		{
			using (var secBuf = new SafeSecBufferDesc(SecBufferType.SECBUFFER_CHANGE_PASS_RESPONSE))
				Assert.That(ChangeAccountPassword("NTLM", Environment.UserDomainName, Environment.UserName, "XXX", "YYY", true, 0, ref secBuf.GetRef()), Is.EqualTo((HRESULT)HRESULT.SEC_E_LOGON_DENIED));
		}

		[Test]
		public void CompleteAuthTokenTest()
		{
			using (var hCred = AcqCredHandle())
			using (var hCtx = GetSecContext(hCred, out var secBuf))
			{
				Assert.That(CompleteAuthToken(hCtx, secBuf.GetRef()), Is.EqualTo((HRESULT)0));
			}
		}

		[Test]
		public void EnDecryptMessageTest()
		{
			const string msg = "This is the message.";
			using (var hCred = AcqCredHandle(UNISP_NAME, SECPKG_CRED.SECPKG_CRED_OUTBOUND))
			using (var pOut = new SafeSecBufferDesc())
			{
				pOut.Add(SecBufferType.SECBUFFER_TOKEN);
				pOut.Add(SecBufferType.SECBUFFER_EMPTY);
				using (var hCtx = GetSecContext(hCred, pOut, Environment.MachineName))
				using (var memSz = SafeHGlobalHandle.CreateFromStructure<SecPkgContext_Sizes>())
				{
					SecPkgContext_Sizes szs = default;
					Assert.That(() => szs = QueryContextAttributes<SecPkgContext_Sizes>(hCtx, SECPKG_ATTR.SECPKG_ATTR_SIZES), Throws.Nothing);

					using (var edesc = new SafeSecBufferDesc())
					{
						edesc.Add((int)szs.cbSecurityTrailer, SecBufferType.SECBUFFER_TOKEN);
						edesc.Add(SecBufferType.SECBUFFER_DATA, msg);
						edesc.Add((int)szs.cbBlockSize, SecBufferType.SECBUFFER_PADDING);

						Assert.That(EncryptMessage(hCtx, 0, ref edesc.GetRef(), 0), Is.EqualTo((HRESULT)0));

						using (var ddesc = new SafeSecBufferDesc())
						using (var mem = new SafeHGlobalHandle(edesc[1].cbBuffer + edesc[2].cbBuffer))
						{
							edesc[1].pvBuffer.CopyTo((IntPtr)mem, edesc[1].cbBuffer);
							edesc[2].pvBuffer.CopyTo(((IntPtr)mem).Offset(edesc[1].cbBuffer), edesc[2].cbBuffer);

							ddesc.Add(new SecBuffer(SecBufferType.SECBUFFER_STREAM) { pvBuffer = (IntPtr)mem, cbBuffer = mem.Size });
							ddesc.Add(new SecBuffer(SecBufferType.SECBUFFER_DATA));

							Assert.That(DecryptMessage(hCtx, ref ddesc.GetRef(), 0, out _), Is.EqualTo((HRESULT)0));
							Assert.That(StringHelper.GetString(ddesc[1].pvBuffer, CharSet.Unicode, ddesc[1].cbBuffer), Is.EqualTo(msg));
						}
					}
				}
			}
		}

		[Test]
		public void EnumerateSecurityPackagesTest()
		{
			Assert.That((int)EnumerateSecurityPackages(out var count, out var buf), Is.Zero);
			Assert.That(count, Is.GreaterThan(0));
			foreach (var pi in buf.ToArray<SecPkgInfo>((int)count))
			{
				foreach (var fi in typeof(SecPkgInfo).GetFields())
					TestContext.WriteLine($"{fi.Name}: {fi.GetValue(pi)}");
				TestContext.WriteLine();
			}
		}

		[Test]
		public void ExImportSecurityContextTest()
		{
			using (var hCred = AcqCredHandle())
			using (var hCtx = GetSecContext(hCred, out _))
			{
				var secBuf = new SecBuffer(SecBufferType.SECBUFFER_EMPTY);
				Assert.That(ExportSecurityContext(hCtx, SECPKG_CONTEXT_EXPORT.SECPKG_CONTEXT_EXPORT_RESET_NEW, ref secBuf, out var hTok), Is.EqualTo((HRESULT)HRESULT.SEC_E_UNSUPPORTED_FUNCTION));
				Assert.That(secBuf.pvBuffer, Is.EqualTo(IntPtr.Zero));
				var hBuf = new SafeContextBuffer(secBuf.pvBuffer);
				Assert.That(ImportSecurityContext(MICROSOFT_KERBEROS_NAME, ref secBuf, hTok, out var hNewCtx), Is.EqualTo((HRESULT)HRESULT.SEC_E_INVALID_TOKEN));
			}
		}

		[Test]
		public void GetComputerObjectNameTest()
		{
			uint sz = 1024;
			var sb = new StringBuilder((int)sz);
			var b = GetComputerObjectName(EXTENDED_NAME_FORMAT.NameFullyQualifiedDN, sb, ref sz);
			if (!b) TestContext.WriteLine($"Error in GetComputerObjectName: {Win32Error.GetLastError()}");
			Assert.That(b, Is.True);
			TestContext.WriteLine(sb);
		}

		[Test]
		public void GetUserNameExTranslateTest()
		{
			uint sz = 1024;
			var sb = new StringBuilder((int)sz);
			var b = GetUserNameEx(EXTENDED_NAME_FORMAT.NameUserPrincipal, sb, ref sz);
			if (!b) TestContext.WriteLine($"Error in GetUserNameEx: {Win32Error.GetLastError()}");
			Assert.That(b, Is.True);
			TestContext.WriteLine(sb);

			uint sz1 = 1024;
			var sb1 = new StringBuilder((int)sz1);
			b = TranslateName(sb.ToString(), EXTENDED_NAME_FORMAT.NameUserPrincipal, EXTENDED_NAME_FORMAT.NameDisplay, sb1, ref sz1);
			if (!b) TestContext.WriteLine($"Error in TranslateName: {Win32Error.GetLastError()}");
			Assert.That(b, Is.True);
			TestContext.WriteLine(sb1);
		}

		[Test]
		public void ImpersonateSecurityContextTest()
		{
			using (var hCred = AcqCredHandle())
			using (var hCtx = GetSecContext(hCred, out _))
			{
				Assert.That(ImpersonateSecurityContext(hCtx), Is.EqualTo((HRESULT)0));
			}
		}

		[Test]
		public void InitializeSecurityContextTest()
		{
			using (var hCred = AcqCredHandle())
			{
				const ASC_REQ STANDARD_CONTEXT_ATTRIBUTES = ASC_REQ.ASC_REQ_CONNECTION | ASC_REQ.ASC_REQ_ALLOCATE_MEMORY;
				var un = WindowsIdentity.GetCurrent().Name;
				var safeBuffMem = SafeHGlobalHandle.CreateFromStructure(new SecBuffer { BufferType = SecBufferType.SECBUFFER_TOKEN });
				var sbb = SecBufferDesc.Default;
				sbb.cBuffers = 1;
				sbb.pBuffers = (IntPtr)safeBuffMem;
				var hNewCtxt = CtxtHandle.Null;
				var hr = InitializeSecurityContext(hCred, IntPtr.Zero, un, STANDARD_CONTEXT_ATTRIBUTES, 0,
					DREP.SECURITY_NATIVE_DREP, IntPtr.Zero, 0, ref hNewCtxt, ref sbb, out var attr, out var exp);
				Assert.That(hr, Is.EqualTo((HRESULT)0).Or.Property("Succeeded").True);
				Assert.That(DeleteSecurityContext(hNewCtxt), Is.EqualTo((HRESULT)0));
				Assert.That(FreeContextBuffer(safeBuffMem.ToStructure<SecBuffer>().pvBuffer), Is.EqualTo((HRESULT)0));
			}
		}

		[Test]
		public void InitializeSecurityContextTest2()
		{
			var sid = new SEC_WINNT_AUTH_IDENTITY(Environment.UserName, Environment.UserDomainName, "");
			using (var hCred = SafeCredHandle.Acquire<SEC_WINNT_AUTH_IDENTITY>(NTLMSP_NAME, SECPKG_CRED.SECPKG_CRED_OUTBOUND, sid))
			{
				var hCtxt = new SafeCtxtHandle();
				var fContextReq = ASC_REQ.ASC_REQ_REPLAY_DETECT | ASC_REQ.ASC_REQ_SEQUENCE_DETECT | ASC_REQ.ASC_REQ_CONFIDENTIALITY | ASC_REQ.ASC_REQ_DELEGATE;
				var hr = InitializeSecurityContext(hCred, hCtxt, WindowsIdentity.GetCurrent().Name, fContextReq, DREP.SECURITY_NATIVE_DREP,
					null, SecBufferType.SECBUFFER_TOKEN, out var sbd, out _, out _);
				Assert.That(hr, Is.EqualTo((HRESULT)0).Or.Property("Succeeded").True);
				Assert.That(hCtxt.DangerousGetHandle().IsNull, Is.False);
				Assert.That(sbd.Count, Is.EqualTo(1));
				Assert.That(sbd[0].pvBuffer, Is.Not.EqualTo(IntPtr.Zero));
				Assert.That(() => sbd.Dispose(), Throws.Nothing);
			}
		}

		[Test]
		public void InitSecurityInterfaceTest()
		{
			unsafe
			{
				var ptable = InitSecurityInterface();
				Assert.That(ptable == null, Is.False);
				Assert.That(ptable->EncryptMessag, Is.Not.EqualTo(IntPtr.Zero));
			}
		}

		[Test]
		public void LsaCallAuthenticationPackageTest()
		{
			Assert.That(LsaLookupAuthenticationPackage(hLsaConn, MICROSOFT_KERBEROS_NAME, out var pkg), Is.EqualTo((NTStatus)0));

			var krr = new KERB_RETRIEVE_TKT_REQUEST { MessageType = KERB_PROTOCOL_MESSAGE_TYPE.KerbRetrieveTicketMessage };
			var mem = SafeHGlobalHandle.CreateFromStructure(krr);
			Assert.That(LsaCallAuthenticationPackage(hLsaConn, pkg, (IntPtr)mem, (uint)mem.Size, out var buf, out var len, out var status), Is.EqualTo((NTStatus)0));
			Assert.That(status, Is.EqualTo((NTStatus)0));
			Assert.That(len, Is.GreaterThan(0));
			var respTick = buf.ToStructure<KERB_RETRIEVE_TKT_RESPONSE>().Ticket;
		}

		[Test]
		public void LsaEnumerateLogonSessionsTest()
		{
			Assert.That(LsaEnumerateLogonSessions(out var count, out var buf), Is.EqualTo((NTStatus)0));
			Assert.That(count, Is.GreaterThan(0));
			Assert.That(() => buf.ToArray<LUID>((int)count), Throws.Nothing);
		}

		[Test]
		public void LsaGetLogonSessionDataTest()
		{
			Assert.That(LsaEnumerateLogonSessions(out var count, out var luids), Is.EqualTo((NTStatus)0));
			Assert.That(LsaGetLogonSessionData(luids.ToArray<LUID>((int)count).First(), out var buf), Is.EqualTo((NTStatus)0));
			Assert.That(buf.IsInvalid, Is.False);
			Assert.That(() => buf.ToStructure<SECURITY_LOGON_SESSION_DATA>(), Throws.Nothing);
		}

		[Test]
		public void LsaLogonUserTest()
		{
			const string user = "fred", domain = "contoso", pwd = "password";

			Assert.That(LsaLookupAuthenticationPackage(hLsaConn, MICROSOFT_KERBEROS_NAME, out var pkg), Is.EqualTo((NTStatus)0));
			var kerb = new KERB_INTERACTIVE_LOGON
			{
				MessageType = KERB_LOGON_SUBMIT_TYPE.KerbInteractiveLogon,
				LogonDomainName = new SafeLSA_UNICODE_STRING(domain),
				UserName = new SafeLSA_UNICODE_STRING(user),
				Password = new SafeLSA_UNICODE_STRING(pwd)
			};
			var mem = SafeHGlobalHandle.CreateFromStructure(kerb);
			AllocateLocallyUniqueId(out var srcLuid);
			var source = new TOKEN_SOURCE { SourceName = "foobar12".ToCharArray(), SourceIdentifier = srcLuid };
			Assert.That(LsaLogonUser(hLsaConn, "TestApp", SECURITY_LOGON_TYPE.Interactive, pkg, (IntPtr)mem, (uint)mem.Size, IntPtr.Zero, source,
				out var profBuf, out var profBufLen, out var logonId, out var hToken, out var quotas, out var subStat), Is.EqualTo((NTStatus)0));
		}

		[Test]
		public void LsaRegisterPolicyChangeNotificationTest()
		{
			using (var hEvent = Kernel32.CreateEvent(null, true, false))
			{
				Assert.That(LsaRegisterPolicyChangeNotification(POLICY_NOTIFICATION_INFORMATION_CLASS.PolicyNotifyDomainKerberosTicketInformation, hEvent), Is.EqualTo((NTStatus)0));
				Assert.That(LsaUnregisterPolicyChangeNotification(POLICY_NOTIFICATION_INFORMATION_CLASS.PolicyNotifyDomainKerberosTicketInformation, hEvent), Is.EqualTo((NTStatus)0));
			}
		}

		[Test]
		public void MakeVerifySignatureTest()
		{
			using (var hCred = AcqCredHandle())
			using (var hCtx = GetSecContext(hCred, out var secBuf))
			{
				Assert.That(MakeSignature(hCtx, 0, ref secBuf.GetRef(), 0), Is.EqualTo((HRESULT)0));
				Assert.That(VerifySignature(hCtx, secBuf.GetRef(), 0, out _), Is.EqualTo((HRESULT)0));
			}
		}

		[Test]
		public void QuerySetContextAttributesTest()
		{
			using (var hCred = AcqCredHandle())
			using (var hCtx = GetSecContext(hCred, out _))
			{
				using (var mem = SafeHGlobalHandle.CreateFromStructure<SecPkgContext_SessionAppData>())
				{
					Assert.That(QueryContextAttributes(hCtx, SECPKG_ATTR.SECPKG_ATTR_APP_DATA, (IntPtr)mem), Is.EqualTo((HRESULT)0));
					Assert.That(mem.ToStructure<SecPkgContext_SessionAppData>().cbAppData, Is.GreaterThan(0));

					Assert.That(SetContextAttributes(hCtx, SECPKG_ATTR.SECPKG_ATTR_APP_DATA, (IntPtr)mem, (uint)mem.Size), Is.EqualTo((HRESULT)0));
				}
				using (var mem = SafeHGlobalHandle.CreateFromStructure<SecPkgContext_SessionAppData>())
				{
					Assert.That(QueryContextAttributesEx(hCtx, SECPKG_ATTR.SECPKG_ATTR_APP_DATA, (IntPtr)mem, (uint)mem.Size), Is.EqualTo((HRESULT)0));
					Assert.That(mem.ToStructure<SecPkgContext_SessionAppData>().cbAppData, Is.GreaterThan(0));
				}
			}
		}

		[Test]
		public void QueryCredentialsAttributesTest()
		{
			using (var hCred = AcqCredHandle())
			{
				using (var mem = SafeHGlobalHandle.CreateFromStructure<SecPkgCredentials_Names>())
				{
					Assert.That(QueryCredentialsAttributes(hCred, SECPKG_CRED_ATTR.SECPKG_CRED_ATTR_NAMES, (IntPtr)mem), Is.EqualTo((HRESULT)0));
					Assert.That(mem.ToStructure<SecPkgCredentials_Names>().sUserName, Is.Not.Null);

					Assert.That(SetCredentialsAttributes(hCred, SECPKG_CRED_ATTR.SECPKG_CRED_ATTR_NAMES, (IntPtr)mem, (uint)mem.Size), Is.EqualTo((HRESULT)0));
				}
				using (var mem = SafeHGlobalHandle.CreateFromStructure<SecPkgCredentials_Names>())
				{
					Assert.That(QueryCredentialsAttributesEx(hCred, SECPKG_CRED_ATTR.SECPKG_CRED_ATTR_NAMES, (IntPtr)mem, (uint)mem.Size), Is.EqualTo((HRESULT)0));
					Assert.That(mem.ToStructure<SecPkgCredentials_Names>().sUserName, Is.Not.Null);
				}
			}
		}

		[Test]
		public void QuerySecurityContextTokenTest()
		{
			using (var hCred = AcqCredHandle())
			using (var hCtx = GetSecContext(hCred, out _))
			{
				Assert.That(QuerySecurityContextToken(hCtx, out var hTok), Is.EqualTo((HRESULT)0));
				Assert.That(hTok.IsInvalid, Is.False);
			}
		}

		[Test]
		public void QuerySecurityPackageInfoTest()
		{
			EnumerateSecurityPackages(out var c, out var b);
			using (b)
			{
				foreach (var npi in b.ToArray<SecPkgInfo>((int)c))
				{
					Assert.That(QuerySecurityPackageInfo(npi.Name, out var ppi), Is.EqualTo((HRESULT)0));
					Assert.That(() =>
					{
						var pi = ppi.ToStructure<SecPkgInfo>();
						Assert.That(pi.fCapabilities, Is.EqualTo(npi.fCapabilities));
					}, Throws.Nothing);
				}
			}
		}

		[Test]
		public void RevertSecurityContextTest()
		{
			using (var hCred = AcqCredHandle())
			using (var hCtx = GetSecContext(hCred, out _))
			{
				Assert.That(RevertSecurityContext(hCtx), Is.EqualTo((HRESULT)0));
			}
		}

		[OneTimeSetUp]
		public void Setup() => LsaConnectUntrusted(out hLsaConn).ThrowIfFailed();

		[OneTimeTearDown]
		public void TearDown() => hLsaConn.Dispose();

		private static SafeCredHandle AcqCredHandle(string secPkg = MICROSOFT_KERBEROS_NAME, SECPKG_CRED use = SECPKG_CRED.SECPKG_CRED_BOTH) => SafeCredHandle.Acquire(secPkg, use);

		private static SafeCtxtHandle GetSecContext(SafeCredHandle hCred, SafeSecBufferDesc pOutput, string target = null)
		{
			if (target is null) target = WindowsIdentity.GetCurrent().Name;
			var hCtxt = new SafeCtxtHandle();
			var hr = InitializeSecurityContext(hCred, hCtxt, target, 0, DREP.SECURITY_NATIVE_DREP, null, pOutput, out _, out _);
			if (hr == HRESULT.SEC_I_COMPLETE_NEEDED)
				hr = CompleteAuthToken(hCtxt, pOutput.GetRef());
			else if (hr == HRESULT.SEC_I_CONTINUE_NEEDED)
			{
				var pIn = pOutput;
				var hCtxt2 = SafeCtxtHandle.Null;
				unsafe
				{
					using (var pOutput2 = new SafeSecBufferDesc(SecBufferType.SECBUFFER_TOKEN))
					{
						AcceptSecurityContext(hCred, hCtxt2, pIn, ASC_REQ.ASC_REQ_ALLOCATE_MEMORY, DREP.SECURITY_NATIVE_DREP, out var hCtxt2Temp, pOutput2, out _, out _).ThrowIfFailed();
						return new SafeCtxtHandle(hCtxt2Temp);
					}
				}
			}
			hr.ThrowIfFailed();
			return hCtxt;
		}

		private static SafeCtxtHandle GetSecContext(SafeCredHandle hCred, out SafeSecBufferDesc pOutput, SecBufferType type = SecBufferType.SECBUFFER_TOKEN, string target = null)
		{
			pOutput = new SafeSecBufferDesc(type);
			return GetSecContext(hCred, pOutput, target);
		}
	}
}