using NUnit.Framework;
using NUnit.Framework.Internal;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;
using static Vanara.PInvoke.AdvApi32;
using static Vanara.PInvoke.WebAuthn;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class WebAuthnTests
{
	[OneTimeSetUp]
	public void _Setup()
	{
	}

	[OneTimeTearDown]
	public void _TearDown()
	{
	}

	[Test]
	public void WebAuthNGetAuthenticatorListTest()
	{
		Assert.That(WebAuthNGetAuthenticatorList(new(), out var list), ResultIs.Successful);
		list.WriteValues();
		Assert.That(list.Dispose, Throws.Nothing);
	}

	[Test]
	public unsafe void WebAuthNAuthenticatorGetAssertionTest()
	{
		ReadOnlySpan<byte> clientDataJson = "{\"type\":\"webauthn.get\",\"challenge\":\"dGVzdC1jaGFsbGVuZ2UtMTIzNDU2Nzg5MA\",\"origin\":\"https://example.com\"}"u8;
		byte[] credentialId = [0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F, 0x10];
		fixed (byte* pClientDataJson = clientDataJson)
		fixed (byte* pCredentialId = credentialId)
		{
			WEBAUTHN_CLIENT_DATA clientData = new()
			{
				pbClientDataJSON = pClientDataJson,
				cbClientDataJSON = (uint)clientDataJson.Length,
				pwszHashAlgId = WEBAUTHN_HASH_ALGORITHM_SHA_256
			};
			using SafeNativeArray<WEBAUTHN_CREDENTIAL> credentials = [(new WEBAUTHN_CREDENTIAL()
			{
				cbId = (uint)credentialId.Length,
				pbId = pCredentialId,
				pwszCredentialType = WEBAUTHN_CREDENTIAL_TYPE_PUBLIC_KEY,
			})];
			WEBAUTHN_AUTHENTICATOR_GET_ASSERTION_OPTIONS opts = new()
			{
				dwTimeoutMilliseconds = 60000,
				CredentialList = new WEBAUTHN_CREDENTIALS()
				{
					cCredentials = (uint)credentials.Count,
					pCredentials = credentials
				},
				dwAuthenticatorAttachment = WEBAUTHN_AUTHENTICATOR_ATTACHMENT.ANY,
				dwUserVerificationRequirement = WEBAUTHN_USER_VERIFICATION_REQUIREMENT.REQUIRED
			};
			Assert.That(WebAuthNAuthenticatorGetAssertion(GetDesktopWindow(), "example.com", clientData, opts, out var asrt), ResultIs.Successful);
			asrt.WriteValues();
			//Assert.That(() => WebAuthNFreeAssertion((IntPtr)asrt), Throws.Nothing);
			Assert.That(asrt.Dispose, Throws.Nothing);
		}

		[DllImport("user32.dll", SetLastError = true)]
		static extern HWND GetDesktopWindow();
	}

	[Test]
	public void WebAuthNGetPlatformCredentialListTest()
	{
		Assert.That(WebAuthNGetPlatformCredentialList(new() { pwszRpId = "example.com" }, out var list), ResultIs.Successful);
		list.WriteValues();
		Assert.That(list.Dispose, Throws.Nothing);
	}
}