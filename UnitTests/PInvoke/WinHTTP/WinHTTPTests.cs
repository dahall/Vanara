using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Linq;
using static Vanara.PInvoke.WinHTTP;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class WinHTTPTests
{
	private const string host = "www.microsoft.com";
	private const string userAgent = "A WinHTTP Example Program/1.0";

	[OneTimeSetUp]
	public void _Setup()
	{
	}

	[OneTimeTearDown]
	public void _TearDown()
	{
	}

	[Test]
	public void WinHttpCheckPlatformTest() => Assert.That(WinHttpCheckPlatform(), Is.True);

	[Test]
	public void WinHttpCrackUrlTest()
	{
		const string url = "https://www.example.com/index.html?query1=value1&query2=value2#section";

		WINHTTP_URL_COMPONENTS comps = new();
		Assert.That(WinHttpCrackUrl(url, 0, 0, ref comps), ResultIs.Successful);

		uint len = 0U;
		Assert.That(WinHttpCreateUrl(comps, 0, null, ref len), ResultIs.Failure);
		StringBuilder sb = new((int)len);
		Assert.That(WinHttpCreateUrl(comps, 0, sb, ref len), ResultIs.Successful);
		Assert.That(sb.ToString(), Is.EqualTo(url));
	}

	[Test]
	public void WinHttpDetectAutoProxyConfigUrlTest()
	{
		Assert.That(WinHttpDetectAutoProxyConfigUrl(WINHTTP_AUTO_DETECT_TYPE.WINHTTP_AUTO_DETECT_TYPE_DHCP | WINHTTP_AUTO_DETECT_TYPE.WINHTTP_AUTO_DETECT_TYPE_DNS_A, out SafeHGlobalHandle url), ResultIs.Successful);
		TestContext.Write(url.ToString(-1));
	}

	[Test]
	public void WinHttpGetDefaultProxyConfigurationTest()
	{
		Assert.That(WinHttpGetDefaultProxyConfiguration(out WINHTTP_PROXY_INFO pInfo), ResultIs.Successful);
		pInfo.WriteValues();
	}

	[Test]
	public void WinHttpGetIEProxyConfigForCurrentUserTest()
	{
		Assert.That(WinHttpGetIEProxyConfigForCurrentUser(out WINHTTP_CURRENT_USER_IE_PROXY_CONFIG prxCfg), ResultIs.Successful);
		prxCfg.WriteValues();
	}

	[Test, RequiresThread]
	public void WinHttpGetProxyForUrlExTest()
	{
		// Use WinHttpOpen to obtain a session handle.
		using SafeHINTERNET hSession = WinHttpOpen(userAgent, dwFlags: WINHTTP_OPEN_FLAG.WINHTTP_FLAG_ASYNC);
		Assert.That(hSession, ResultIs.ValidHandle);

		if (!WinHttpGetIEProxyConfigForCurrentUser(out WINHTTP_CURRENT_USER_IE_PROXY_CONFIG prxCfg))
		{
			Win32Error.ThrowLastErrorUnless(Win32Error.ERROR_FILE_NOT_FOUND);
		}

		Assert.That(WinHttpCreateProxyResolver(hSession, out SafeHINTERNET hResolver), ResultIs.Successful);

		using System.Threading.ManualResetEvent evt = new(false);
		Win32Error cbErr = Win32Error.ERROR_SUCCESS;
		IntPtr prevCb = WinHttpSetStatusCallback(hResolver, callback, WINHTTP_CALLBACK_FLAG.WINHTTP_CALLBACK_FLAG_REQUEST_ERROR | WINHTTP_CALLBACK_FLAG.WINHTTP_CALLBACK_FLAG_GETPROXYFORURL_COMPLETE);
		Assert.That(prevCb, Is.Not.EqualTo(WINHTTP_INVALID_STATUS_CALLBACK));

		WINHTTP_AUTOPROXY_OPTIONS opts;
		if (prxCfg.fAutoDetect)
		{
			opts = new()
			{
				dwFlags = WINHTTP_AUTOPROXY.WINHTTP_AUTOPROXY_AUTO_DETECT,
				dwAutoDetectFlags = WINHTTP_AUTO_DETECT_TYPE.WINHTTP_AUTO_DETECT_TYPE_DNS_A | WINHTTP_AUTO_DETECT_TYPE.WINHTTP_AUTO_DETECT_TYPE_DHCP,
				fAutoLogonIfChallenged = true,
			};
			// Call WinHttpGetProxyForUrl with our target URL, then set the proxy info on the request handle.
			Assert.That(WinHttpGetProxyForUrlEx(hResolver, "https://www.microsoft.com/ms.htm", opts), Is.EqualTo((Win32Error)Win32Error.ERROR_IO_PENDING));
		}

		evt.WaitOne(5000);
		Assert.That(cbErr, ResultIs.Successful);

		void callback(HINTERNET hInternet, IntPtr dwContext, WINHTTP_CALLBACK_STATUS dwInternetStatus, IntPtr lpvStatusInformation, uint dwStatusInformationLength)
		{
			if (dwInternetStatus == WINHTTP_CALLBACK_STATUS.WINHTTP_CALLBACK_STATUS_REQUEST_ERROR)
			{
				WINHTTP_ASYNC_RESULT res = lpvStatusInformation.ToStructure<WINHTTP_ASYNC_RESULT>(dwStatusInformationLength);
				if (res.dwResult != ASYNC_RESULT.API_GET_PROXY_FOR_URL)
				{
					return;
				}

				cbErr = res.dwError;
			}
			else if (dwInternetStatus == WINHTTP_CALLBACK_STATUS.WINHTTP_CALLBACK_STATUS_GETPROXYFORURL_COMPLETE)
			{
				cbErr = WinHttpGetProxyResult(hInternet, out WINHTTP_PROXY_RESULT proxyRes);
				if (cbErr.Succeeded)
				{
					proxyRes.WriteValues();
					WinHttpFreeProxyResult(ref proxyRes);
				}
			}
			evt.Set();
		}
	}

	[Test]
	public void WinHttpGetProxyForUrlTest()
	{
		// Use WinHttpOpen to obtain a session handle.
		using SafeHINTERNET hSession = WinHttpOpen(userAgent);
		Assert.That(hSession, ResultIs.ValidHandle);
		// Specify an HTTP server.
		using SafeHINTERNET hConnect = WinHttpConnect(hSession, host, INTERNET_DEFAULT_HTTPS_PORT);
		Assert.That(hConnect, ResultIs.ValidHandle);
		// Create an HTTP request handle.
		using SafeHINTERNET hRequest = WinHttpOpenRequest(hConnect, "GET", "ms.htm");
		Assert.That(hRequest, ResultIs.ValidHandle);

		// Call WinHttpGetProxyForUrl with our target URL, then set the proxy info on the request handle.
		WINHTTP_AUTOPROXY_OPTIONS opts = new()
		{
			dwFlags = WINHTTP_AUTOPROXY.WINHTTP_AUTOPROXY_AUTO_DETECT,
			dwAutoDetectFlags = WINHTTP_AUTO_DETECT_TYPE.WINHTTP_AUTO_DETECT_TYPE_DNS_A | WINHTTP_AUTO_DETECT_TYPE.WINHTTP_AUTO_DETECT_TYPE_DHCP,
			fAutoLogonIfChallenged = true,
		};
		if (WinHttpGetProxyForUrl(hSession, "https://www.microsoft.com/", opts, out WINHTTP_PROXY_INFO info))
		{
			try
			{
				TestContext.WriteLine($"{info.dwAccessType}; {info.lpszProxy}; {info.lpszProxyBypass}");
				// A proxy configuration was found, set it on the request handle.
				Assert.That(WinHttpSetOption(hRequest, WINHTTP_OPTION.WINHTTP_OPTION_PROXY, info), ResultIs.Successful);
			}
			finally
			{
				info.FreeMemory();
			}
		}

		// Send the request.
		Assert.That(WinHttpSendRequest(hRequest), ResultIs.Successful);

		// Wait for the response.
		Assert.That(WinHttpReceiveResponse(hRequest), ResultIs.Successful);
	}

	[Test] // TODO: Need to find URL where this works
	public void WinHttpQueryAuthSchemesTest()
	{
		// Use WinHttpOpen to obtain a session handle.
		using SafeHINTERNET hSession = WinHttpOpen(userAgent);
		Assert.That(hSession, ResultIs.ValidHandle);
		// Specify an HTTP server.
		using SafeHINTERNET hConnect = WinHttpConnect(hSession, "drive.google.com", INTERNET_DEFAULT_HTTPS_PORT);
		Assert.That(hConnect, ResultIs.ValidHandle);
		// Create an HTTP request handle.
		using SafeHINTERNET hRequest = WinHttpOpenRequest(hConnect, "GET", "file/d/0ByJOdIdwOr5COHpTRTNFakgzSk0/view?usp=sharing&resourcekey=0-TUcpJ5N1-M9-Mw1DP4VT7A", dwFlags: WINHTTP_OPENREQ_FLAG.WINHTTP_FLAG_SECURE);
		Assert.That(hRequest, ResultIs.ValidHandle);
		// Send the request.
		Assert.That(WinHttpSendRequest(hRequest), ResultIs.Successful);
		// Wait for the response.
		Assert.That(WinHttpReceiveResponse(hRequest), ResultIs.Successful);
		
		var stat = WinHttpQueryHeaders<uint>(hRequest, WINHTTP_QUERY.WINHTTP_QUERY_FLAG_NUMBER | WINHTTP_QUERY.WINHTTP_QUERY_STATUS_CODE);
		Assert.That(stat, Is.EqualTo(401).Or.EqualTo(407));

		Assert.That(WinHttpQueryAuthSchemes(hRequest, out var sch, out var first, out var target), ResultIs.Successful);
		TestContext.Write($"Auth: {sch}, {first}, {target}");
	}

	//[Test] // Can't get this ever pass
	public void WinHttpQueryConnectionGroupTest()
	{
		// Use WinHttpOpen to obtain a session handle.
		using SafeHINTERNET hSession = WinHttpOpen(userAgent);
		Assert.That(hSession, ResultIs.ValidHandle);
		// Specify an HTTP server.
		using SafeHINTERNET hConnect = WinHttpConnect(hSession, host, INTERNET_DEFAULT_HTTPS_PORT);
		Assert.That(hConnect, ResultIs.ValidHandle);
		try
		{
			IntPtr res = default;
			Assert.That(WinHttpQueryConnectionGroup(hConnect, default, 0, ref res), ResultIs.Successful);
			WinHttpFreeQueryConnectionGroupResult(res);
		}
		finally
		{
			if (!hConnect.IsNull)
			{
				WinHttpCloseHandle(hSession);
			}

			if (!hSession.IsNull)
			{
				WinHttpCloseHandle(hSession);
			}
		}
	}

	[Test]
	public void WinHttpQueryHeadersExTest()
	{
		// Use WinHttpOpen to obtain a session handle.
		using SafeHINTERNET hSession = WinHttpOpen(userAgent);
		Assert.That(hSession, ResultIs.ValidHandle);
		// Specify an HTTP server.
		using SafeHINTERNET hConnect = WinHttpConnect(hSession, host, INTERNET_DEFAULT_HTTPS_PORT);
		Assert.That(hConnect, ResultIs.ValidHandle);
		// Create an HTTP request handle.
		using SafeHINTERNET hRequest = WinHttpOpenRequest(hConnect, "GET", dwFlags: WINHTTP_OPENREQ_FLAG.WINHTTP_FLAG_SECURE);
		Assert.That(hRequest, ResultIs.ValidHandle);
		// Add a request header.
		WINHTTP_EXTENDED_HEADER[] hdr = new WINHTTP_EXTENDED_HEADER[] { ("If-Modified-Since", "Mon, 20 Nov 2000 20:00:00 GMT"), ("Accept-Charset", "utf-8") };
		Assert.That(WinHttpAddRequestHeadersEx(hRequest, WINHTTP_ADDREQ_FLAG.WINHTTP_ADDREQ_FLAG_ADD,
			WINHTTP_EXTENDED_HEADER_FLAG.WINHTTP_EXTENDED_HEADER_FLAG_UNICODE, 0, hdr.Length, hdr), ResultIs.Successful);
		// Send a request.
		Assert.That(WinHttpSendRequest(hRequest), ResultIs.Successful);
		// End the request.
		Assert.That(WinHttpReceiveResponse(hRequest), ResultIs.Successful);
		// Get status header
		uint sz = 256U;
		using var pin = new SafeHGlobalHandle(sz);
		Assert.That(WinHttpQueryHeadersEx(hRequest, WINHTTP_QUERY.WINHTTP_QUERY_CONNECTION, 0, 0,
			default, default, pin, ref sz, out var hdrs, out var cHdrs), ResultIs.Successful);
		Assert.That(sz, Is.GreaterThan(0));
		Assert.That(cHdrs, Is.GreaterThan(0));
		hdrs.ToArray<WINHTTP_EXTENDED_HEADER>((int)cHdrs)![0].WriteValues();
	}

	[Test]
	public void WinHttpQueryHeadersTest()
	{
		// Use WinHttpOpen to obtain a session handle.
		using SafeHINTERNET hSession = WinHttpOpen(userAgent);
		Assert.That(hSession, ResultIs.ValidHandle);
		// Specify an HTTP server.
		using SafeHINTERNET hConnect = WinHttpConnect(hSession, host, INTERNET_DEFAULT_HTTP_PORT);
		Assert.That(hConnect, ResultIs.ValidHandle);
		// Create an HTTP request handle.
		using SafeHINTERNET hRequest = WinHttpOpenRequest(hConnect, "GET");
		Assert.That(hRequest, ResultIs.ValidHandle);
		// Add a request header.
		Assert.That(WinHttpAddRequestHeaders(hRequest, "If-Modified-Since: Mon, 20 Nov 2000 20:00:00 GMT\r\nAccept-Charset: utf-8", -1, WINHTTP_ADDREQ_FLAG.WINHTTP_ADDREQ_FLAG_ADD), ResultIs.Successful);
		// Send a request.
		Assert.That(WinHttpSendRequest(hRequest), ResultIs.Successful);
		// End the request.
		Assert.That(WinHttpReceiveResponse(hRequest), ResultIs.Successful);

		Assert.That(WinHttpQueryHeaders<uint>(hRequest, WINHTTP_QUERY.WINHTTP_QUERY_FLAG_NUMBER | WINHTTP_QUERY.WINHTTP_QUERY_STATUS_CODE), Is.GreaterThanOrEqualTo(200));
		Assert.That(WinHttpQueryHeaders<SYSTEMTIME>(hRequest, WINHTTP_QUERY.WINHTTP_QUERY_FLAG_SYSTEMTIME | WINHTTP_QUERY.WINHTTP_QUERY_DATE).wYear, Is.EqualTo(DateTime.Today.Year));
		//uint idx = 2;
		//Assert.That(() => WinHttpQueryHeaders<string>(hRequest, WINHTTP_QUERY.WINHTTP_QUERY_RAW_HEADERS, null, ref idx), Throws.Nothing);

		for (uint i = 0; i < 78; i++)
		{
			try
			{
				string hdrs = WinHttpQueryHeaders<string>(hRequest, (WINHTTP_QUERY)i);
				TestContext.WriteLine($"{i}) {(WINHTTP_QUERY)i}: {hdrs}");
			}
			catch (System.ComponentModel.Win32Exception wex) when (wex.NativeErrorCode == 0x2f76) { }
			catch (Exception ex)
			{
				TestContext.WriteLine($"{i}) {(WINHTTP_QUERY)i}: ERR: {ex.Message}");
			}
		}
	}

	[Test]
	public void WinHttpQueryOptionTest()
	{
		// Use WinHttpOpen to obtain a session handle.
		using SafeHINTERNET hSession = WinHttpOpen(userAgent);
		Assert.That(hSession, ResultIs.ValidHandle);
		uint data = WinHttpQueryOption<uint>(hSession, WINHTTP_OPTION.WINHTTP_OPTION_CONNECT_TIMEOUT);
		TestContext.Write($"Connection timeout: {data} ms\n");
	}

	[Test]
	public void WinHttpQueryOptionTypeTest()
	{
		// Use WinHttpOpen to obtain a session handle.
		using SafeHINTERNET hSession = WinHttpOpen(userAgent);
		Assert.That(hSession, ResultIs.ValidHandle);
		// Specify an HTTP server.
		using SafeHINTERNET hConnect = WinHttpConnect(hSession, host, INTERNET_DEFAULT_HTTPS_PORT);
		Assert.That(hConnect, ResultIs.ValidHandle);
		// Create an HTTP request handle.
		using SafeHINTERNET hRequest = WinHttpOpenRequest(hConnect, "GET", dwFlags: WINHTTP_OPENREQ_FLAG.WINHTTP_FLAG_SECURE);
		Assert.That(hRequest, ResultIs.ValidHandle);
		// Send a request.
		Assert.That(WinHttpSendRequest(hRequest), ResultIs.Successful);
		// End the request.
		Assert.That(WinHttpReceiveResponse(hRequest), ResultIs.Successful);

		foreach (WINHTTP_OPTION opt in Enum.GetValues(typeof(WINHTTP_OPTION)))
		{
			uint len = 0;
			TestContext.Write($"{opt} ({(int)opt}): ");
			var err = WinHttpQueryOption(hSession, opt, default, ref len) ? Win32Error.ERROR_SUCCESS : Win32Error.GetLastError();
			if (err.Failed)
			{
				if (err == Win32Error.ERROR_INTERNET_INCORRECT_HANDLE_TYPE)
				{
					len = 0;
					err = WinHttpQueryOption(hRequest, opt, default, ref len) ? Win32Error.ERROR_SUCCESS : Win32Error.GetLastError();
				}
				if (err == Win32Error.ERROR_INVALID_PARAMETER &&
					CorrespondingTypeAttribute.GetAttrForEnum(opt, CorrespondingAction.Get).FirstOrDefault() is null)
				{
					TestContext.WriteLine("SET ONLY");
					continue;
				}
				if (err != Win32Error.ERROR_INSUFFICIENT_BUFFER)
				{
					TestContext.WriteLine($"Err = {err}");
					continue;
				}
			}
			var type = CorrespondingTypeAttribute.GetCorrespondingTypes(opt).FirstOrDefault();
			TestContext.WriteLine($"{type?.Name ?? "[Unk]"} = {len}");
			if (type is not null && type.IsValueType && opt != WINHTTP_OPTION.WINHTTP_OPTION_CLIENT_CERT_ISSUER_LIST &&
				opt != WINHTTP_OPTION.WINHTTP_OPTION_SELECTED_PROXY_CONFIG_INFO)
				Assert.That((uint)InteropExtensions.SizeOf(type), Is.LessThanOrEqualTo(len));
		}
	}

	[Test]
	public void WinHttpReadDataTest()
	{
		// Use WinHttpOpen to obtain a session handle.
		using SafeHINTERNET hSession = WinHttpOpen(userAgent);
		Assert.That(hSession, ResultIs.ValidHandle);
		// Specify an HTTP server.
		using SafeHINTERNET hConnect = WinHttpConnect(hSession, host, INTERNET_DEFAULT_HTTPS_PORT);
		Assert.That(hConnect, ResultIs.ValidHandle);
		// Create an HTTP request handle.
		using SafeHINTERNET hRequest = WinHttpOpenRequest(hConnect, "GET", dwFlags: WINHTTP_OPENREQ_FLAG.WINHTTP_FLAG_SECURE);
		Assert.That(hRequest, ResultIs.ValidHandle);
		// Send a request.
		Assert.That(WinHttpSendRequest(hRequest), ResultIs.Successful);
		// End the request.
		Assert.That(WinHttpReceiveResponse(hRequest), ResultIs.Successful);
		// Report data size
		Assert.That(WinHttpQueryDataAvailable(hRequest, out uint bytes), ResultIs.Successful);
		TestContext.Write($"Bytes in request: {bytes}");
		Assert.That(bytes, Is.GreaterThan(0));
		// Read from stream
		using var mem = new SafeHGlobalHandle(bytes + 1);
		Assert.That(WinHttpReadData(hRequest, mem, bytes, out var read), ResultIs.Successful);
		Assert.That(read, Is.LessThanOrEqualTo((uint)mem.Size));
		TestContext.WriteLine($", Bytes read: {read}");
		TestContext.WriteLine(mem.ToString(-1, CharSet.Ansi));
	}

	[Test]
	public void WinHttpResetAutoProxyTest()
	{
		// Use WinHttpOpen to obtain a session handle.
		using SafeHINTERNET hSession = WinHttpOpen(userAgent);
		Assert.That(hSession, ResultIs.ValidHandle);

		Assert.That(WinHttpResetAutoProxy(hSession, WINHTTP_RESET.WINHTTP_RESET_STATE), ResultIs.Successful);
	}

	[Test]
	public void WinHttpSetDefaultProxyConfigurationTest()
	{
		Assert.That(WinHttpGetDefaultProxyConfiguration(out WINHTTP_PROXY_INFO pInfo), ResultIs.Successful);
		pInfo.WriteValues();
		Assert.That(WinHttpSetDefaultProxyConfiguration(pInfo), ResultIs.Successful);
	}

	[Test]
	public void WinHttpSetTimeoutsTest()
	{
		// Use WinHttpOpen to obtain a session handle.
		using SafeHINTERNET hSession = WinHttpOpen(userAgent);

		var rslv = WinHttpQueryOption<int>(hSession, WINHTTP_OPTION.WINHTTP_OPTION_RESOLVE_TIMEOUT);
		var conn = WinHttpQueryOption<int>(hSession, WINHTTP_OPTION.WINHTTP_OPTION_CONNECT_TIMEOUT);
		var send = WinHttpQueryOption<int>(hSession, WINHTTP_OPTION.WINHTTP_OPTION_SEND_TIMEOUT);
		var recv = WinHttpQueryOption<int>(hSession, WINHTTP_OPTION.WINHTTP_OPTION_RECEIVE_TIMEOUT);
		Assert.That(WinHttpSetTimeouts(hSession, rslv, conn, send, recv), ResultIs.Successful);
	}

	[Test]
	public void WinHttpTimeFromSystemTimeTest()
	{
		var st = new SYSTEMTIME(2000, 2, 20, 14, 20, 2);
		var sb = new StringBuilder(256);
		Assert.That(WinHttpTimeFromSystemTime(st, sb), ResultIs.Successful);
		Assert.That(sb.ToString(), Contains.Substring("2000"));

		Assert.That(WinHttpTimeToSystemTime(sb.ToString(), out var st2), ResultIs.Successful);
		Assert.That(st.Ticks, Is.EqualTo(st2.Ticks));
	}
}