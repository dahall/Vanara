using NUnit.Framework;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using Vanara.InteropServices;
using static Vanara.PInvoke.Crypt32;
using static Vanara.PInvoke.CryptUI;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class CryptUITests
{
	[Test]
	public void CryptUIWizDigitalSignTest()
	{
		using var cert = new X509Certificate2(TestCaseSources.TempDirWhack + "test.cer", "~CertPassword~");
		using var pBlob = new SafeHGlobalHandle(System.IO.File.ReadAllBytes(TestCaseSources.ResourceFile));
		using var pBlobInfo = new SafeHGlobalStruct<CRYPTUI_WIZ_DIGITAL_SIGN_BLOB_INFO>(new CRYPTUI_WIZ_DIGITAL_SIGN_BLOB_INFO(pBlob));

		CRYPTUI_WIZ_DIGITAL_SIGN_INFO signInfo = new()
		{
			dwSize = (uint)Marshal.SizeOf(typeof(CRYPTUI_WIZ_DIGITAL_SIGN_INFO)),
			dwSubjectChoice = CryptUIWizToSign.CRYPTUI_WIZ_DIGITAL_SIGN_SUBJECT_BLOB,
			ToSign = new() { pSignBlobInfo = pBlobInfo },
			dwSigningCertChoice = CryptUIWizSignLoc.CRYPTUI_WIZ_DIGITAL_SIGN_CERT,
			pSigningCertObject = cert.Handle,
		};

		Assert.That(CryptUIWizDigitalSign(CryptUIWizFlags.CRYPTUI_WIZ_NO_UI, default, default, signInfo, out _), ResultIs.Successful);
	}

	[Test]
	public void CryptUIWizDigitalSignFileTest()
	{
		using var cert = new X509Certificate2(TestCaseSources.TempDirWhack + "test.cer", "~CertPassword~");
		using SafeCoTaskMemString pFile = new(TestCaseSources.ResourceFile);

		var signInfo = new CRYPTUI_WIZ_DIGITAL_SIGN_INFO()
		{
			dwSize = (uint)Marshal.SizeOf(typeof(CRYPTUI_WIZ_DIGITAL_SIGN_INFO)),
			dwSubjectChoice = CryptUIWizToSign.CRYPTUI_WIZ_DIGITAL_SIGN_SUBJECT_FILE,
			ToSign = new() { pwszFileName = (System.IntPtr)pFile },
			dwSigningCertChoice = CryptUIWizSignLoc.CRYPTUI_WIZ_DIGITAL_SIGN_CERT,
			pSigningCertObject = cert.Handle,
		};

		Assert.That(CryptUIWizDigitalSign(CryptUIWizFlags.CRYPTUI_WIZ_NO_UI, default, default, signInfo, out _), ResultIs.Successful);
	}

	[Test]
	public void WizTest()
	{
		var signInfo = new CRYPTUI_WIZ_DIGITAL_SIGN_INFO() { dwSize = (uint)Marshal.SizeOf(typeof(CRYPTUI_WIZ_DIGITAL_SIGN_INFO)), };
		Assert.That(CryptUIWizDigitalSign(0, default, default, signInfo, out _), ResultIs.Successful);
	}
}