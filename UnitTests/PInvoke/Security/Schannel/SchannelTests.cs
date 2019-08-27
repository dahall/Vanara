using NUnit.Framework;
using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Vanara.InteropServices;
using static Vanara.PInvoke.Schannel;

namespace Vanara.PInvoke.Tests
{
	[TestFixture()]
	public class SchannelTests
	{
		[Test]
		public unsafe void SslCrackCertificateTest()
		{
			using (var store = new X509Store(StoreLocation.CurrentUser))
			{
				store.Open(OpenFlags.ReadOnly);
				var cert = store.Certificates.Find(X509FindType.FindBySubjectName, Environment.UserName, false).OfType<X509Certificate2>().First();
				fixed (byte* pData = cert.RawData)
				{
					Assert.That(SslCrackCertificate((IntPtr)pData, (uint)cert.RawData.Length, CF_CERT_FROM_FILE, out var pCert), ResultIs.Successful);
					pCert.ToStructure<PInvoke.Schannel.X509Certificate>().WriteValues();
				}
			}
		}

		[Test]
		public void SslEmptyCacheTest()
		{
			Assert.That(SslEmptyCache(), ResultIs.Successful);
		}

		[Test]
		public void SslGetServerIdentityTest()
		{
			// There is no useful documentation or samples on this function. Only checking that it is callable.
			using (var mem = new SafeHGlobalHandle(256))
				Assert.That(SslGetServerIdentity(mem, mem.Size, out var pId, out var pSz), ResultIs.FailureCode(HRESULT.SEC_E_ILLEGAL_MESSAGE));
		}
	}
}