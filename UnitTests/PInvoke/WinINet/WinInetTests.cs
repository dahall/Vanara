using NUnit.Framework;
using System;
using System.IO;
using System.Linq;
using System.Text;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.WinINet;

namespace Vanara.PInvoke.Tests
{
	[TestFixture()]
	public class WinInetTests
	{
		private const string exturl = "https://microsoft.com";
		private const string host = "localhost";
		private const string url = "http://" + host;
		private static readonly SafeHINTERNET hOpen = InternetOpen("Test");

		[Test]
		public void CreateMD5SSOHashTest()
		{
			var hash = new byte[35];
			Assert.That(CreateMD5SSOHash("IAMACHALLENGE", null, null, hash), ResultIs.Successful); // not supported
		}

		[Test]
		public void CreateUrlCacheContainerTest()
		{
			var icci = INTERNET_CACHE_CONFIG_INFO.Default;
			var flags = CACHE_CONFIG_FC.CACHE_CONFIG_CONTENT_PATHS_FC | CACHE_CONFIG_FC.CACHE_CONFIG_COOKIES_PATHS_FC | CACHE_CONFIG_FC.CACHE_CONFIG_HISTORY_PATHS_FC |
				CACHE_CONFIG_FC.CACHE_CONFIG_QUOTA_FC | CACHE_CONFIG_FC.CACHE_CONFIG_STICKY_CONTENT_USAGE_FC;
			Assert.That(GetUrlCacheConfigInfo(ref icci, default, flags), ResultIs.Successful);
			icci.WriteValues();
			var path = icci.CachePaths[0].CachePath;

			Assert.That(CreateUrlCacheContainer("Log", "Log:", path, 0, INTERNET_CACHE_CONTAINER.INTERNET_CACHE_CONTAINER_NOSUBDIRS), ResultIs.Successful);
			Assert.That(DeleteUrlCacheContainer("Log"), ResultIs.Successful);
		}

		[Test]
		public void CreateUrlCacheEntryTest()
		{
			using (var tmp = new TempFile())
			{
				var url = "temp://" + Guid.NewGuid().ToString("N");
				var sb = new StringBuilder(512);
				Assert.That(CreateUrlCacheEntry(url, 0, "tmp", sb), ResultIs.Successful);

				try
				{
					System.IO.File.Copy(tmp.FullName, sb.ToString(), true);
					Assert.That(CommitUrlCacheEntry(url, sb.ToString()), ResultIs.Successful);

					Assert.That(FindUrlCacheEntries().Where(e => e.lpszSourceUrlName == url), Is.Not.Empty);

					using (var mem = new SafeHGlobalHandle(4096))
					{
						uint sz = mem.Size;
						Assert.That(GetUrlCacheEntryInfo(url, mem, ref sz), ResultIs.Successful);
						var ei = mem.ToStructure<INTERNET_CACHE_ENTRY_INFO>();
						new INTERNET_CACHE_ENTRY_INFO_MGD(ei).WriteValues();

						ei.LastModifiedTime = DateTime.Now.ToFileTimeStruct();
						Assert.That(SetUrlCacheEntryInfo(url, ei, CACHE_ENTRY_FC.CACHE_ENTRY_MODTIME_FC), ResultIs.Successful);

						sz = mem.Size;
						Assert.That(GetUrlCacheEntryInfoEx(url, mem, ref sz), ResultIs.Successful);
						new INTERNET_CACHE_ENTRY_INFO_MGD(mem.ToStructure<INTERNET_CACHE_ENTRY_INFO>()).WriteValues();

						sz = 0;
						Assert.That(RetrieveUrlCacheEntryStream(url, default, ref sz, false), ResultIs.Not.ValidHandle);
						using (var infomem = new SafeHGlobalHandle(sz))
						{
							using (var hStr = RetrieveUrlCacheEntryStream(url, infomem, ref sz, false))
							{
								Assert.That(hStr, ResultIs.ValidHandle);
								var info = new INTERNET_CACHE_ENTRY_INFO_MGD(infomem.ToStructure<INTERNET_CACHE_ENTRY_INFO>());
								info.WriteValues();

								using (var buf = new SafeHGlobalHandle(info.dwSize))
								{
									uint bufSz = buf.Size;
									Assert.That(ReadUrlCacheEntryStream(hStr, 0, buf, ref bufSz), ResultIs.Successful);
									TestContext.WriteLine(buf.DangerousGetHandle().ToHexDumpString(buf.Size));
								}
							}
						}

						sz = 0;
						Assert.That(RetrieveUrlCacheEntryFile(url, default, ref sz), ResultIs.Failure);
						using (var infomem = new SafeHGlobalHandle(sz))
						{
							Assert.That(RetrieveUrlCacheEntryFile(url, infomem, ref sz), ResultIs.Successful);
							new INTERNET_CACHE_ENTRY_INFO_MGD(infomem.ToStructure<INTERNET_CACHE_ENTRY_INFO>()).WriteValues();
							Assert.That(UnlockUrlCacheEntryFile(url), ResultIs.Successful);
						}
					}
				}
				finally
				{
					Assert.That(DeleteUrlCacheEntry(url), ResultIs.Successful);
				}
			}
		}

		[Test]
		public void CreateUrlCacheGroupTest()
		{
			long grp;
			Assert.That(grp = CreateUrlCacheGroup(), ResultIs.Not.Value(0L));
			try
			{
				Assert.That(FindUrlCacheGroups(), Contains.Item(grp));
			}
			finally
			{
				Assert.That(DeleteUrlCacheGroup(grp, CACHEGROUP_FLAG.CACHEGROUP_FLAG_FLUSHURL_ONDELETE), ResultIs.Successful);
			}
		}

		[Test]
		public void DetectAutoProxyUrlTest()
		{
			var sb = new StringBuilder(4096);
			var sz = (uint)sb.Capacity;
			Assert.That(() => DetectAutoProxyUrl(sb, sz, (PROXY_AUTO_DETECT_TYPE)3), Throws.Nothing);
		}

		[TestCaseSource(typeof(TestCaseSources), nameof(TestCaseSources.RemoteConnections), new object[] { true, 0b00111 })]
		public void FtpCommandTest(string host, string ip, string user, string domain, string pwd)
		{
			Assert.That(hOpen, ResultIs.ValidHandle);
			using (var hCon = InternetConnect(hOpen, ip, INTERNET_PORT.INTERNET_DEFAULT_FTP_PORT, user, pwd, InternetService.INTERNET_SERVICE_FTP, InternetApiFlags.INTERNET_FLAG_PASSIVE))
			{
				Assert.That(hCon, ResultIs.ValidHandle);
				Assert.That(FtpCommand(hCon, true, FTP_TRANSER_TYPE.FTP_TRANSER_TYPE_BINARY, "SYST", default, out var hFtp), ResultIs.Successful);
				hFtp.Dispose();
			}
		}

		[TestCaseSource(typeof(TestCaseSources), nameof(TestCaseSources.RemoteConnections), new object[] { true, 0b00111 })]
		public void FtpTest(string host, string ip, string user, string domain, string pwd)
		{
			const string dirName = "Temp";
			const string newName = "File.bin";

			Assert.That(InternetSetStatusCallback(hOpen, Callback), ResultIs.Not.Value(INTERNET_INVALID_STATUS_CALLBACK));
			try
			{
				Assert.That(hOpen, ResultIs.ValidHandle);
				using (var hCon = InternetConnect(hOpen, ip, INTERNET_PORT.INTERNET_DEFAULT_FTP_PORT, user, pwd, InternetService.INTERNET_SERVICE_FTP, InternetApiFlags.INTERNET_FLAG_PASSIVE))
				{
					Assert.That(hCon, ResultIs.ValidHandle);

					var sb = new StringBuilder(1024);
					var sz = (uint)sb.Capacity;
					Assert.That(FtpGetCurrentDirectory(hCon, sb, ref sz), ResultIs.Successful);
					Assert.That(FtpCreateDirectory(hCon, dirName), ResultIs.Successful);
					Assert.That(FtpSetCurrentDirectory(hCon, dirName), ResultIs.Successful);

					Assert.That(FtpPutFile(hCon, TestCaseSources.SmallFile, System.IO.Path.GetFileName(TestCaseSources.SmallFile), INTERNET_FLAG.INTERNET_FLAG_TRANSFER_BINARY), ResultIs.Successful);
					var hFile = SafeHINTERNET.Null;
					Assert.That(hFile = FtpFindFirstFile(hCon, System.IO.Path.GetFileName(TestCaseSources.SmallFile), out var fd, 0), ResultIs.ValidHandle);
					Assert.That(InternetFindNextFile(hFile, out fd), ResultIs.Failure);
					hFile.Dispose();

					Assert.That(hFile = FtpOpenFile(hCon, System.IO.Path.GetFileName(TestCaseSources.SmallFile), ACCESS_MASK.GENERIC_READ, FTP_TRANSER_TYPE.FTP_TRANSER_TYPE_BINARY), ResultIs.ValidHandle);
					uint low;
					Assert.That(low = FtpGetFileSize(hFile, out var high), ResultIs.Not.Value(0U));

					var fileContent = File.ReadAllBytes(TestCaseSources.ImageFile);
					Assert.That(InternetWriteFile(hFile, fileContent, fileContent.Length, out var written), ResultIs.Failure);

					hFile.Dispose();

					Assert.That(FtpRenameFile(hCon, Path.GetFileName(TestCaseSources.SmallFile), newName), ResultIs.Successful);
					using (var tmpFile = new TempFile(null))
						Assert.That(FtpGetFile(hCon, newName, tmpFile.FullName, true, 0, INTERNET_FLAG.INTERNET_FLAG_TRANSFER_BINARY), ResultIs.Successful);
					Assert.That(FtpDeleteFile(hCon, newName), ResultIs.Successful);

					Assert.That(FtpSetCurrentDirectory(hCon, sb.ToString()), ResultIs.Successful);
					Assert.That(FtpRemoveDirectory(hCon, dirName), ResultIs.Successful);
				}
			}
			finally
			{
				InternetSetStatusCallback(hOpen, null);
			}

			void Callback(HINTERNET hInternet, IntPtr dwContext, InternetStatus dwInternetStatus, IntPtr lpvStatusInformation, uint dwStatusInformationLength)
			{
				System.Diagnostics.Debug.WriteLine(dwInternetStatus);
			}
		}

		[Test]
		public void HttpSendRequestExTest()
		{
			using (var hCon = InternetConnect(hOpen, host, dwService: InternetService.INTERNET_SERVICE_HTTP))
			{
				Assert.That(hCon, ResultIs.ValidHandle);

				using (var hReq = HttpOpenRequest(hCon, null, "", null, ""))
				{
					Assert.That(hReq, ResultIs.ValidHandle);

					var ibuf = INTERNET_BUFFERS.Default;
					ibuf.dwBufferTotal = 4096;
					Assert.That(HttpSendRequestEx(hReq, ibuf, dwContext: new IntPtr(1)), ResultIs.Successful);

					Assert.That(HttpEndRequest(hReq), ResultIs.Successful);
				}
			}
		}

		[Test]
		public void HttpSendRequestTest()
		{
			using (var hCon = InternetConnect(hOpen, host, dwService: InternetService.INTERNET_SERVICE_HTTP))
			{
				Assert.That(hCon, ResultIs.ValidHandle);

				using (var hReq = HttpOpenRequest(hCon, null, "", null, ""))
				{
					Assert.That(hReq, ResultIs.ValidHandle);

					Assert.That(HttpAddRequestHeaders(hReq, "Accept: text/html, application/xhtml+xml, */*\r\n", -1, HTTP_ADDREQ_FLAG.HTTP_ADDREQ_FLAG_ADD | HTTP_ADDREQ_FLAG.HTTP_ADDREQ_FLAG_REPLACE), ResultIs.Successful);

					Assert.That(HttpSendRequest(hReq), ResultIs.Successful);

					foreach (var e in Enum.GetValues(typeof(HTTP_QUERY)).OfType<HTTP_QUERY>().Where(v => (int)v < 0x10000000))
					{
						uint idx = 0;
						try
						{
							var mem = HttpQueryInfo(hReq, e, ref idx);
							TestContext.WriteLine($"{e} = {HttpQueryInfo<string>(hReq, e, ref idx)}");
						}
						catch (Exception ex)
						{
							TestContext.WriteLine($"{e} caused exception {ex.Message}");
						}
					}

					Assert.That(InternetSetFilePointer(hReq, 0, 0, SeekOrigin.Begin), ResultIs.Successful);
					using (var mem = new SafeHGlobalHandle(1024))
						Assert.That(InternetReadFile(hReq, mem, mem.Size, out var read), ResultIs.Successful);
				}
			}
		}

		[Test]
		public void InternetAttemptConnectTest()
		{
			Assert.That(InternetAttemptConnect(), ResultIs.Successful);
		}

		[Test]
		public void InternetAutodialTest()
		{
			Assert.That(InternetAutodial(INTERNET_AUTODIAL.INTERNET_AUTODIAL_FORCE_ONLINE, HWND.NULL), ResultIs.Successful);
			Assert.That(InternetAutodialHangup(), ResultIs.Successful);
		}

		[Test]
		public void InternetCanonicalizeUrlTest()
		{
			var sb = new StringBuilder(1024);
			var sz = (uint)sb.Capacity;
			Assert.That(InternetCanonicalizeUrl(url + "/issstart.htm", sb, ref sz, ICU.ICU_BROWSER_MODE), ResultIs.Successful);
			TestContext.Write(sb);
		}

		[Test]
		public void InternetCheckConnectionTest()
		{
			Assert.That(InternetCheckConnection(exturl, FLAG_ICC.FLAG_ICC_FORCE_CONNECTION), ResultIs.Successful);
			Assert.That(InternetCheckConnection(), ResultIs.Successful);
		}

		[Test]
		public void InternetClearAllPerSiteCookieDecisionsTest()
		{
			Assert.That(InternetClearAllPerSiteCookieDecisions(), ResultIs.Successful);
		}

		[Test]
		public void InternetConfirmZoneCrossingTest()
		{
			Assert.That(InternetConfirmZoneCrossing(HWND.NULL, url, "http://microsoft.com"), ResultIs.Successful);
		}

		[Test]
		public void InternetConnectTest()
		{
			using (var hCon = InternetConnect(hOpen, host, dwService: InternetService.INTERNET_SERVICE_HTTP))
				Assert.That(hCon, ResultIs.ValidHandle);
		}

		[Test]
		public void InternetCrackUrlTest()
		{
			const string crkUrl = "https://docs.microsoft.com:443/en-us/windows/win32/api/wininet/ns-wininet-url_componentsa#remarks";
			var comp = new URL_COMPONENTS_MGD();
			Assert.That(InternetCrackUrl(crkUrl, (uint)crkUrl.Length + 1, ICU.ICU_DECODE, ref comp.GetRef()), ResultIs.Successful);
			comp.WriteValues();
			comp.GetRef().WriteValues();
		}

		[Test]
		public void InternetCreateUrlTest()
		{
			var comps = new URL_COMPONENTS_MGD("https", "docs.microsoft.com", "/en-us/windows/win32/api/wininet/ns-wininet-url_componentsa", "#remarks", INTERNET_PORT.INTERNET_DEFAULT_HTTPS_PORT);
			var sb = new StringBuilder(1024);
			var sz = (uint)sb.Capacity;
			Assert.That(InternetCreateUrl(ref comps.GetRef(), 0, sb, ref sz), ResultIs.Successful);
			TestContext.WriteLine(sb);
		}

		[Test]
		public void InternetDialTest()
		{
			Assert.That(InternetDial(HWND.NULL, null, INTERNET_DIAL.INTERNET_DIAL_UNATTENDED, out var id), ResultIs.Successful);
			Assert.That(InternetHangUp(id), ResultIs.Successful);
		}

		[Test]
		public void InternetEnumPerSiteCookieDecisionTest()
		{
			Assert.That(InternetSetPerSiteCookieDecision("hpe.com", InternetCookieState.COOKIE_STATE_ACCEPT), ResultIs.Successful);
			Assert.That(InternetGetPerSiteCookieDecision("hpe.com", out var state), ResultIs.Successful);
			Assert.That(state, Is.EqualTo(InternetCookieState.COOKIE_STATE_ACCEPT));

			var sb = new StringBuilder(1024);
			uint i = 0;
			do
			{
				var sz = (uint)sb.Capacity;
				if (!InternetEnumPerSiteCookieDecision(sb, ref sz, out var dec, i))
					Assert.That(Win32Error.GetLastError(), Is.EqualTo((Win32Error)Win32Error.ERROR_NO_MORE_ITEMS));
				TestContext.Write($"{i}: {sb}; {dec}");
			} while (i++ < 50);
		}

		[Test]
		public void InternetErrorDlgTest()
		{
			using (var hCon = InternetConnect(hOpen, host, dwService: InternetService.INTERNET_SERVICE_HTTP))
			{
				Assert.That(hCon, ResultIs.ValidHandle);
				using (var hReq = HttpOpenRequest(hCon, null, "", null, ""))
				{
					Assert.That(hReq, ResultIs.ValidHandle);
					Assert.That(HttpSendRequest(hReq), ResultIs.Successful);

					Assert.That(InternetErrorDlg(HWND.NULL, hReq, Win32Error.ERROR_INTERNET_INCORRECT_PASSWORD, FLAGS_ERROR_UI.FLAGS_ERROR_UI_FLAGS_NO_UI, IntPtr.Zero), ResultIs.Successful);
				}
			}
		}

		[Test]
		public void InternetGetConnectedStateExTest()
		{
			var sb = new StringBuilder(1024);
			Assert.That(InternetGetConnectedStateEx(out var flags, sb, (uint)sb.Capacity), ResultIs.Successful);
			TestContext.Write($"{flags}; {sb}");
		}

		[Test]
		public void InternetGetConnectedStateTest()
		{
			Assert.That(InternetGetConnectedState(out var flags), ResultIs.Successful);
			TestContext.Write(flags);
		}

		[Test]
		public void InternetGetCookieExTest()
		{
			var sb = new StringBuilder(1024);
			var sz = (uint)sb.Capacity;
			Assert.That(InternetGetCookieEx(exturl, null, sb, ref sz, 0), ResultIs.Successful);
			TestContext.Write(sb);
			Assert.That(InternetSetCookieEx(exturl, "TestOnly", "blahblahblah", 0), ResultIs.Not.Value(InternetCookieState.COOKIE_STATE_UNKNOWN));
		}

		[Test]
		public void InternetGetCookieTest()
		{
			var sb = new StringBuilder(1024);
			var sz = (uint)sb.Capacity;
			Assert.That(InternetGetCookie(exturl, null, sb, ref sz), ResultIs.Successful);
			TestContext.Write(sb);
			Assert.That(InternetSetCookie(exturl, "TestOnly", "blahblahblah"), ResultIs.Successful);
		}

		[Test]
		public void InternetGetLastResponseInfoTest()
		{
			var sb = new StringBuilder(1024);
			var sz = (uint)sb.Capacity;
			Assert.That(InternetGetLastResponseInfo(out var err, sb, ref sz), ResultIs.Successful);
		}

		[Test]
		public void InternetGoOnlineTest()
		{
			Assert.That(InternetGoOnline(url, HWND.NULL), ResultIs.Successful);
		}

		[Test]
		public void InternetInitializeAutoProxyDllTest()
		{
			Assert.That(InternetInitializeAutoProxyDll(), ResultIs.Successful);
		}

		[Test]
		public void InternetLockRequestFileTest()
		{
			using (var hFile = InternetOpenUrl(hOpen, url, null, 0, 0))
			{
				Assert.That(hFile, ResultIs.ValidHandle);

				Assert.That(InternetQueryDataAvailable(hFile, out var num), ResultIs.Successful);
				TestContext.Write(num);

				Assert.That(InternetLockRequestFile(hFile, out var hLock), ResultIs.Successful);
				using (var mem = new SafeHGlobalHandle(1024))
				{
					var ib = INTERNET_BUFFERS.Default;
					ib.dwBufferLength = mem.Size;
					ib.lpvBuffer = mem;
					Assert.That(InternetReadFileEx(hFile, ref ib, IRF.IRF_SYNC), ResultIs.Successful);
				}
				Assert.That(InternetUnlockRequestFile(hLock), ResultIs.Successful);
			}
		}

		[Test()]
		public void InternetOpenTest()
		{
			var hOpen2 = InternetOpen("Test", InternetOpenType.INTERNET_OPEN_TYPE_DIRECT, null, null, 0);
			Assert.That(hOpen2, ResultIs.ValidHandle);
			hOpen2.Dispose();
			Assert.That(hOpen2.IsInvalid, Is.True);
		}

		[Test]
		public void InternetQueryOptionTest()
		{
			var sz = sizeof(int);
			var hMem = new SafeCoTaskMemHandle(sz);
			var ret = InternetQueryOption(hOpen, InternetOptionFlags.INTERNET_OPTION_HANDLE_TYPE, hMem, ref sz);
			Assert.That(ret, Is.True);
			var hType = (InternetOptionHandleType)hMem.ToStructure<int>();
			Assert.That(hType, Is.Not.Zero);
			TestContext.WriteLine($"Handle is {hType}");

			hType = InternetQueryOption<InternetOptionHandleType>(hOpen, InternetOptionFlags.INTERNET_OPTION_HANDLE_TYPE);
			Assert.That(hType, Is.Not.Zero);
			TestContext.WriteLine($"Handle is {hType}");

			var str = InternetQueryOption<string>(hOpen, InternetOptionFlags.INTERNET_OPTION_USER_AGENT);
			Assert.That(str, Is.EqualTo("Test"));

			var b = InternetQueryOption<bool>(hOpen, InternetOptionFlags.INTERNET_OPTION_ENCODE_EXTRA);
			Assert.That(b, Is.False);

			var hParent = new SafeHINTERNET(InternetQueryOption<IntPtr>(hOpen, InternetOptionFlags.INTERNET_OPTION_PARENT_HANDLE));
			Assert.That(hParent.IsClosed, Is.False);

			Assert.That(() => InternetQueryOption<uint>(hOpen, InternetOptionFlags.INTERNET_OPTION_ENCODE_EXTRA), Throws.Exception);

			Assert.That(() => InternetQueryOption<IntPtr>(hOpen, InternetOptionFlags.INTERNET_OPTION_CACHE_STREAM_HANDLE), Throws.Exception);

			var ver = InternetQueryOption<INTERNET_VERSION_INFO>(hOpen, InternetOptionFlags.INTERNET_OPTION_VERSION);
			Assert.That(ver.dwMajorVersion, Is.Not.Zero);
			TestContext.WriteLine($"Ver is {ver.dwMajorVersion}.{ver.dwMinorVersion}");

			var pi = InternetQueryOption<INTERNET_PROXY_INFO>(HINTERNET.NULL, InternetOptionFlags.INTERNET_OPTION_PROXY);
			Assert.That(pi.dwAccessType, Is.Not.Zero);
			TestContext.WriteLine($"Proxy is {pi.dwAccessType}={pi.lpszProxy}");
		}

		[Test]
		public void InternetSetOptionTest()
		{
			InternetSetOption(hOpen, InternetOptionFlags.INTERNET_OPTION_USER_AGENT, Environment.UserName);
			var un = InternetQueryOption<string>(hOpen, InternetOptionFlags.INTERNET_OPTION_USER_AGENT);
			Assert.That(un, Is.EqualTo(Environment.UserName));

			InternetSetOption(hOpen, InternetOptionFlags.INTERNET_OPTION_CONNECT_RETRIES, 3U);
			var r = InternetQueryOption<uint>(hOpen, InternetOptionFlags.INTERNET_OPTION_CONNECT_RETRIES);
			Assert.That(r, Is.EqualTo(3U));

			Assert.That(InternetSetOption(hOpen, InternetOptionFlags.INTERNET_OPTION_DIGEST_AUTH_UNLOAD), ResultIs.Successful);

			Assert.That(() => InternetSetOption(hOpen, InternetOptionFlags.INTERNET_OPTION_HANDLE_TYPE), Throws.ArgumentException);
			Assert.That(() => InternetSetOption(hOpen, InternetOptionFlags.INTERNET_OPTION_HANDLE_TYPE, InternetOptionHandleType.INTERNET_HANDLE_TYPE_CONNECT_FTP), Throws.ArgumentException);
			Assert.That(() => InternetSetOption(hOpen, InternetOptionFlags.INTERNET_OPTION_URL), Throws.ArgumentException);
			Assert.That(() => InternetSetOption(hOpen, InternetOptionFlags.INTERNET_OPTION_CACHE_STREAM_HANDLE), Throws.Exception);
		}

		[Test]
		public void InternetTimeFromSystemTimeTest()
		{
			var st = new SYSTEMTIME(DateTime.Now, DateTimeKind.Local);
			var sb = new StringBuilder(1024);
			Assert.That(InternetTimeFromSystemTime(st, INTERNET_RFC.INTERNET_RFC1123_FORMAT, sb, (uint)sb.Capacity), ResultIs.Successful);
			Assert.That(InternetTimeToSystemTime(sb.ToString(), out var st2), ResultIs.Successful);
			Assert.That(st.Equals(st2), Is.True);
		}

		[Test]
		public void PrivacyGetSetZonePreferenceWTest()
		{
			URLZONE zone = URLZONE.URLZONE_INTERNET;
			PrivacyType priv = PrivacyType.PRIVACY_TYPE_FIRST_PARTY;
			PrivacyTemplate iTmpl = 0;
			string pref = null;

			var sb = new StringBuilder(1024);
			foreach (var e in Enum.GetValues(typeof(URLZONE)).Cast<URLZONE>())
			{
				var sz = (uint)sb.Capacity;
				//Assert.That(PrivacyGetZonePreferenceW(e, priv, out var tmpl, sb, ref sz), ResultIs.Successful);
				if (PrivacyGetZonePreferenceW(e, priv, out var tmpl, sb, ref sz).Succeeded)
					TestContext.WriteLine($"{e} : {tmpl} : {sb}");
				if (e == zone) { pref = sb.ToString(); iTmpl = tmpl; }
			}

			Assert.That(PrivacySetZonePreferenceW(zone, priv, iTmpl, pref), ResultIs.Successful);
		}
	}
}