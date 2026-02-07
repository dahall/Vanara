using NUnit.Framework;
using static Vanara.PInvoke.Crypt32;

namespace Vanara.PInvoke.Tests;

[TestFixture()]
public class CryptTests
{
	[Test]
	public void CryptEnumOIDFunctionTest()
	{
		var ret = CryptEnumOIDFunction();
		Assert.That(ret, Is.Not.Empty);
		foreach (var oid in ret)
		{
			TestContext.WriteLine($"{oid.encType} {oid.funcName} {oid.oid}");
			foreach (var (valueName, value) in oid.values)
				TestContext.WriteLine($"  {valueName} = {(value is string[] a ? string.Join(",", a) : value?.ToString())}");
		}
	}

	[Test]
	public void CryptEnumOIDInfoTest()
	{
		var ret = CryptEnumOIDInfo();
		Assert.That(ret, Is.Not.Empty);
		foreach (var oid in ret)
		{
			TestContext.WriteLine(((SafeOID)(IntPtr)oid.pszOID).ToString());
			oid.WriteValues();
		}
	}

	private static PCCERT_CONTEXT GetValidCert(Func<PCCERT_CONTEXT, bool>? isvalid = null)
	{
		// Open the My system store.
		using var hCertStore = SafeHCERTSTORE.OpenSystem("MY");

		// Loop through the certificates in the store, return the first that matches the validator.
		PCCERT_CONTEXT pCertContext = default;
		while (pCertContext = CertEnumCertificatesInStore(hCertStore, pCertContext))
		{
			if (isvalid is null || isvalid(pCertContext))
				return pCertContext;
		}
		return default;
	}

	[Test]
	public void CertNameToStrRoundtripTest()
	{
		PCCERT_CONTEXT pCertContext = GetValidCert();
		Assert.That(!pCertContext.IsInvalid);

		Assert.That(CertNameToStr(pCertContext.AsRef().dwCertEncodingType, pCertContext.AsRef().pCertInfo.AsRef().Subject,
			CertNameStringFormat.CERT_OID_NAME_STR, out var psz), ResultIs.Not.Value(0));
		TestContext.WriteLine($"Certificate for {psz} found.");
		Assert.That(psz, Is.Not.Null.And.Not.Empty);

		Assert.That(CertStrToName(pCertContext.AsRef().dwCertEncodingType, psz!, CertNameStringFormat.CERT_OID_NAME_STR,
			out var blobEncName, out _), ResultIs.Successful);
		Assert.That(blobEncName, Is.Not.Null.And.Not.Empty);

		// Validate that the encoded name matches the original
		var originalName = pCertContext.AsRef().pCertInfo.AsRef().Subject.GetBytes();
		Assert.That(originalName, Is.EquivalentTo(blobEncName!));
	}

	[Test]
	public void CryptStringToBinaryRoundtripTest()
	{
		PCCERT_CONTEXT pCertContext = GetValidCert();
		Assert.That(!pCertContext.IsInvalid);

		const string str = "aGVsbG8gd29ybGQ="; // "hello world" in base64
		Assert.That(CryptStringToBinary(str, CryptStringFormat.CRYPT_STRING_BASE64, out var pBin, out _, out var pFmt), ResultIs.Successful);
		Assert.That(pBin, Is.Not.Null.And.Not.Empty);

		Assert.That(CryptBinaryToString(pBin!, pFmt | CryptStringFormat.CRYPT_STRING_NOCRLF, out var psz), ResultIs.Successful);
		Assert.That(psz, Is.Not.Null.And.Not.Empty);

		// Validate that the encoded name matches the original
		Assert.That(psz, Is.EqualTo(str));
	}

	[Test]
	public void CreateCertChainTest()
	{
		PCCERT_CONTEXT pCertContext = GetValidCert();
		Assert.That(!pCertContext.IsInvalid);

		//-------------------------------------------------------------------
		// Get and display the name of subject of the certificate.

		Assert.That(CertGetNameString(pCertContext, CertNameType.CERT_NAME_SIMPLE_DISPLAY_TYPE, 0, default, out var pszNameString), ResultIs.Not.Value(0));
		TestContext.WriteLine($"Certificate for {pszNameString} found.");

		CertChainFlags dwFlags = 0;

		//---------------------------------------------------------
		// Initialize data structures.

		CERT_USAGE_MATCH CertUsage = new(UsageMatchType.USAGE_MATCH_TYPE_AND);
		CERT_CHAIN_PARA ChainPara = new(CertUsage);
		CERT_CHAIN_ENGINE_CONFIG ChainConfig = new(CertChainEngineFlags.CERT_CHAIN_CACHE_END_CERT);

		//---------------------------------------------------------
		// Create the nondefault certificate chain engine.

		Assert.That(CertCreateCertificateChainEngine(ChainConfig, out var hChainEngine), ResultIs.Successful);

		//-------------------------------------------------------------------
		// Build a chain using CertGetCertificateChain
		// and the certificate retrieved.

		Assert.That(CertGetCertificateChain(default, // use the default chain engine
			pCertContext, // pointer to the end certificate
			default, // use the default time
			default, // search no additional stores
			ChainPara, // use AND logic and enhanced key usage as indicated in the ChainPara data structure
			dwFlags,
			default, // currently reserved
			out SafePCCERT_CHAIN_CONTEXT ppChainContext), ResultIs.Successful); // return a pointer to the chain created

		//---------------------------------------------------------------
		// Display some of the contents of the chain.

		ref CERT_CHAIN_CONTEXT pChainContext = ref ppChainContext.AsRef();
		TestContext.Write("The size of the chain context is {0}. \n", pChainContext.cbSize);
		TestContext.Write("{0} simple chains found.\n", pChainContext.cChain);
		TestContext.Write($"Error status for the chain: {pChainContext.TrustStatus.dwErrorStatus}\n");
		TestContext.Write($"Info status for the chain: {pChainContext.TrustStatus.dwInfoStatus}\n\n");

		//-------------------------------------------------------------------
		// Duplicate the original chain.
		SafePCCERT_CHAIN_CONTEXT pDupContext;
		Assert.That(pDupContext = CertDuplicateCertificateChain(ppChainContext), ResultIs.ValidHandle);
	}

	static readonly SafeOID szOID_PKIX_KP_EMAIL_PROTECTION = new("1.3.6.1.5.5.7.3.4");

	[Test]
	public void CertSelectCertificateChainsTest()
	{
		using SafeNativeArray<IntPtr> rgParaEKU = [szOID_PKIX_KP_EMAIL_PROTECTION];
		var EKUCriteria = new CERT_SELECT_CRITERIA
		{
			dwType = CertSelectBy.CERT_SELECT_BY_ENHKEY_USAGE,
			cPara = (uint)rgParaEKU.Count,
			ppPara = rgParaEKU,
		};

		using SafeCoTaskMemStruct<CERT_EXTENSION> pExtDigSig = new CERT_EXTENSION { Value = new CRYPTOAPI_BLOB([(byte)CertKeyUsage.CERT_DIGITAL_SIGNATURE_KEY_USAGE]) };
		using SafeNativeArray<IntPtr> rgParaKU = [pExtDigSig];
		var KUCriteria = new CERT_SELECT_CRITERIA
		{
			dwType = CertSelectBy.CERT_SELECT_BY_KEY_USAGE,
			cPara = (uint)rgParaKU.Count,
			ppPara = rgParaKU,
		};

		var hStore = CertOpenStore(CertStoreProvider.CERT_STORE_PROV_SYSTEM, 0, default, CertStoreFlags.CERT_SYSTEM_STORE_CURRENT_USER, "MY");
		Assert.That(hStore, ResultIs.ValidHandle);

		var prgpSelection = hStore.SelectChains(default, CertSelection.CERT_SELECT_TRUSTED_ROOT | CertSelection.CERT_SELECT_HAS_PRIVATE_KEY, default, [EKUCriteria, KUCriteria]);
		Assert.That((IntPtr)prgpSelection, Is.Not.EqualTo(IntPtr.Zero));
		foreach (var chain in prgpSelection)
			chain.AsRef().WriteValues();
	}

	[Test]
	public void CryptBinaryToStringAndBack_RoundTrip()
	{
		// Prepare a small binary blob
		var src = new byte[] { 0xDE, 0xAD, 0xBE, 0xEF };

		Assert.That(CryptBinaryToString(src, CryptStringFormat.CRYPT_STRING_HEX, out var pszString), ResultIs.Successful);
		TestContext.WriteLine($"Encoded string: {pszString}");
		Assert.That(pszString, Is.Not.Null.And.Not.Empty);

		// Ask for required binary size
		Assert.That(CryptStringToBinary(pszString!, CryptStringFormat.CRYPT_STRING_HEX, out var round, out var pdwSkip, out var outFlags), ResultIs.Successful);

		// Validate round-trip
		Assert.That(round!.Length, Is.EqualTo(src.Length));
		Assert.That(round, Is.EquivalentTo(src));
	}
}