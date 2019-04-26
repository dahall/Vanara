using NUnit.Framework;
using System;
using Vanara.InteropServices;
using static Vanara.PInvoke.WinINet;

namespace Vanara.PInvoke.Tests
{
	[TestFixture()]
	public class WinInetTests
	{
		[Test()]
		public void InternetOpenTest()
		{
			var hOpen = InternetOpen("Test", InternetOpenType.INTERNET_OPEN_TYPE_DIRECT, null, null, 0);
			Assert.That(hOpen.IsInvalid, Is.False);
			hOpen.Dispose();
			Assert.That(hOpen.IsInvalid, Is.True);
		}

		[Test]
		public void InternetConnectTest()
		{
			using (var hOpen = InternetOpen("Test", InternetOpenType.INTERNET_OPEN_TYPE_DIRECT, null, null, 0))
			{
				var hCon = InternetConnect(hOpen, "hallan-svr", 32400, null, null, InternetService.INTERNET_SERVICE_HTTP, 0, IntPtr.Zero);
				Assert.That(hCon.IsInvalid, Is.False);
				hCon.Dispose();
				Assert.That(hCon.IsInvalid, Is.True);
			}
		}

		[Test]
		public void InternetQueryOptionTest()
		{
			using (var hOpen = InternetOpen("Test", InternetOpenType.INTERNET_OPEN_TYPE_DIRECT, null, null, 0))
			{
				var sz = sizeof(int);
				var hMem = new SafeCoTaskMemHandle(sz);
				var ret = InternetQueryOption(hOpen, InternetOptionFlags.INTERNET_OPTION_HANDLE_TYPE, (IntPtr) hMem, ref sz);
				Assert.That(ret, Is.True);
				var hType = (InternetOptionHandleType)hMem.ToStructure<int>();
				Assert.That(hType, Is.Not.Zero);
				TestContext.WriteLine($"Handle is {hType}");

				hType = hOpen.InternetQueryOption<InternetOptionHandleType>(InternetOptionFlags.INTERNET_OPTION_HANDLE_TYPE);
				Assert.That(hType, Is.Not.Zero);
				TestContext.WriteLine($"Handle is {hType}");

				var str = hOpen.InternetQueryOption<string>(InternetOptionFlags.INTERNET_OPTION_USER_AGENT);
				Assert.That(str, Is.EqualTo("Test"));

				var b = hOpen.InternetQueryOption<bool>(InternetOptionFlags.INTERNET_OPTION_ENCODE_EXTRA);
				Assert.That(b, Is.False);

				var hParent = new SafeInternetHandle(hOpen.InternetQueryOption<IntPtr>(InternetOptionFlags.INTERNET_OPTION_PARENT_HANDLE));
				Assert.That(hParent.IsClosed, Is.False);

				Assert.That(() => hOpen.InternetQueryOption<uint>(InternetOptionFlags.INTERNET_OPTION_ENCODE_EXTRA), Throws.Exception);

				Assert.That(() => hOpen.InternetQueryOption<IntPtr>(InternetOptionFlags.INTERNET_OPTION_CACHE_STREAM_HANDLE), Throws.Exception);

				var ver = hOpen.InternetQueryOption<INTERNET_VERSION_INFO>(InternetOptionFlags.INTERNET_OPTION_VERSION);
				Assert.That(ver.dwMajorVersion, Is.Not.Zero);
				TestContext.WriteLine($"Ver is {ver.dwMajorVersion}.{ver.dwMinorVersion}");
			}

			var pi = SafeInternetHandle.Null.InternetQueryOption<INTERNET_PROXY_INFO>(InternetOptionFlags.INTERNET_OPTION_PROXY);
			Assert.That(pi.dwAccessType, Is.Not.Zero);
			TestContext.WriteLine($"Proxy is {pi.dwAccessType}={pi.lpszProxy}");

			//var ci = SafeInternetHandle.Null.InternetQueryOption<INTERNET_CERTIFICATE_INFO>(InternetOptionFlags.INTERNET_OPTION_SECURITY_CERTIFICATE_STRUCT);
			//TestContext.WriteLine($"Cert is {ci.ftStart}, {ci.ftExpiry}, {ci.lpszSubjectInfo}, {ci.lpszProtocolName}");
		}

		[Test]
		public void InternetSetOptionTest()
		{
			using (var hOpen = InternetOpen("Test", InternetOpenType.INTERNET_OPEN_TYPE_DIRECT, null, null, 0))
			{
				hOpen.InternetSetOption(InternetOptionFlags.INTERNET_OPTION_USER_AGENT, "dahall");
				var un = hOpen.InternetQueryOption<string>(InternetOptionFlags.INTERNET_OPTION_USER_AGENT);
				Assert.That(un, Is.EqualTo("dahall"));

				hOpen.InternetSetOption(InternetOptionFlags.INTERNET_OPTION_CONNECT_RETRIES, 3U);
				var r = hOpen.InternetQueryOption<uint>(InternetOptionFlags.INTERNET_OPTION_CONNECT_RETRIES);
				Assert.That(r, Is.EqualTo(3U));
				Assert.That(() => hOpen.InternetSetOption(InternetOptionFlags.INTERNET_OPTION_HANDLE_TYPE), Throws.Exception);
				Assert.That(() => hOpen.InternetSetOption(InternetOptionFlags.INTERNET_OPTION_HANDLE_TYPE, InternetOptionHandleType.INTERNET_HANDLE_TYPE_CONNECT_FTP), Throws.Exception);

				Assert.That(() => hOpen.InternetSetOption(InternetOptionFlags.INTERNET_OPTION_DIGEST_AUTH_UNLOAD), Throws.Nothing);

				Assert.That(() => hOpen.InternetSetOption(InternetOptionFlags.INTERNET_OPTION_URL), Throws.Exception);

				Assert.That(() => hOpen.InternetSetOption(InternetOptionFlags.INTERNET_OPTION_CACHE_STREAM_HANDLE), Throws.Exception);
			}
		}
	}
}