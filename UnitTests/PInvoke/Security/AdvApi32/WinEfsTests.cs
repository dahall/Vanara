using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.AdvApi32;
using static Vanara.PInvoke.Crypt32;

namespace Vanara.PInvoke.Tests
{
	[TestFixture()]
	public class WinEfsTests
	{
		[Test]
		public unsafe void AddUsersToEncryptedFileTest()
		{
			using (var tmp = new TempFile())
			{
				Assert.That(EncryptFile(tmp.FullName), ResultIs.Successful);
				using (var hStore = CertOpenSystemStore(default, "TrustedPeople"))
				{
					Assert.That(hStore, ResultIs.ValidHandle);
					var pCertContext = CertFindCertificateInStore(hStore, CertEncodingType.X509_ASN_ENCODING | CertEncodingType.PKCS_7_ASN_ENCODING, 0, CertFindType.CERT_FIND_SUBJECT_STR, new SafeCoTaskMemString(Environment.UserName), default);
					Assert.That(pCertContext, ResultIs.ValidHandle);
					try
					{
						var ctx = pCertContext.ToStructure<CERT_CONTEXT>();
						var ecblob = new EFS_CERTIFICATE_BLOB { dwCertEncodingType = ctx.dwCertEncodingType, cbData = ctx.cbCertEncoded, pbData = ctx.pbCertEncoded };
						var ec = new ENCRYPTION_CERTIFICATE { pUserSid = SafePSID.Current, cbTotalLength = (uint)Marshal.SizeOf<ENCRYPTION_CERTIFICATE>(), pCertBlob = (IntPtr)(void*)&ecblob };
						var pec = &ec;
						var ecl = new ENCRYPTION_CERTIFICATE_LIST { nUsers = 1, pUsers = (IntPtr)(void*)&pec };
						Assert.That(AddUsersToEncryptedFile(tmp.FullName, ecl), ResultIs.Successful);

						using (var tmp2 = new TempFile())
						{
							Assert.That(DuplicateEncryptionInfoFile(tmp.FullName, tmp2.FullName, Kernel32.CreationOption.OPEN_EXISTING, 0), ResultIs.Successful);
						}

						Assert.That(QueryRecoveryAgentsOnEncryptedFile(tmp.FullName, out var pAgents), ResultIs.Successful);
						using (pAgents)
						{
							Assert.That(pAgents, ResultIs.ValidHandle);
							var agents = pAgents.Items;
							foreach (var user in agents)
								TestContext.WriteLine($"{(user.pUserSid.IsValidSid() ? user.pUserSid.ToString("N") : "")} = {user.lpDisplayInformation}");
						}

						Assert.That(QueryUsersOnEncryptedFile(tmp.FullName, out var pUsers), ResultIs.Successful);
						using (pUsers)
						{
							Assert.That(pUsers, ResultIs.ValidHandle);
							var users = pUsers.Items;
							foreach (var user in users)
								TestContext.WriteLine($"{(user.pUserSid.IsValidSid() ? user.pUserSid.ToString("N") : "")} = {user.lpDisplayInformation}");

							// TODO: I cannot get this to do anything but return ERROR_ACCESS_DENIED
							Assert.That(RemoveUsersFromEncryptedFile(tmp.FullName, pUsers), ResultIs.Failure);
						}
					}
					finally
					{
						Assert.That(CertFreeCertificateContext(pCertContext), ResultIs.Successful);
					}
				}
			}
		}

		[Test]
		public void CertEnumSystemStoreTest()
		{
			var list = new List<string>();
			Assert.That(CertEnumSystemStore(CertSystemStore.CERT_SYSTEM_STORE_CURRENT_USER, IntPtr.Zero, IntPtr.Zero, Callback), ResultIs.Successful);
			TestContext.Write(string.Join("\n", list));

			bool Callback(IntPtr pvSystemStore, uint dwFlags, in CERT_SYSTEM_STORE_INFO pStoreInfo, IntPtr pvReserved, IntPtr pvArg)
			{
				var ss = StringHelper.GetString(pvSystemStore, CharSet.Unicode);
				if (!string.IsNullOrEmpty(ss))
					list.Add(ss);
				return true;
			}
		}

		[Test]
		public void EncryptionDisableTest()
		{
			var dir = System.IO.Path.Combine(TestCaseSources.TempDirWhack, System.IO.Path.GetRandomFileName());
			var dirInfo = System.IO.Directory.CreateDirectory(dir);
			try
			{
				Assert.That(EncryptionDisable(dirInfo.FullName, true), ResultIs.Successful);
				Assert.That(EncryptionDisable(dirInfo.FullName, false), ResultIs.Successful);
			}
			finally
			{
				dirInfo.Delete(true);
			}
		}

		[Test]
		public void SetUserFileEncryptionKeyTest()
		{
			using (var hStore = CertOpenSystemStore(default, "My"))
			{
				Assert.That(hStore, ResultIs.ValidHandle);
				var pCertContext = CertFindCertificateInStore(hStore, CertEncodingType.X509_ASN_ENCODING | CertEncodingType.PKCS_7_ASN_ENCODING, 0, CertFindType.CERT_FIND_SUBJECT_STR, new SafeCoTaskMemString(Environment.UserName), default);
				Assert.That(pCertContext, ResultIs.ValidHandle);
				try
				{
					var ctx = pCertContext.ToStructure<CERT_CONTEXT>();

					var ec = new ENCRYPTION_CERTIFICATE { cbTotalLength = (uint)Marshal.SizeOf<ENCRYPTION_CERTIFICATE>(), pCertBlob = ctx.pbCertEncoded };
					// TODO: Can only get this to return RPC_S_INVALID_BOUND
					Assert.That(SetUserFileEncryptionKey(ec), ResultIs.Failure);
				}
				finally
				{
					Assert.That(CertFreeCertificateContext(pCertContext), ResultIs.Successful);
				}
			}
		}
	}
}