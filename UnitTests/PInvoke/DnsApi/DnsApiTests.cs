using Microsoft.Win32.SafeHandles;
using NUnit.Framework;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.DnsApi;

namespace Vanara.PInvoke.Tests
{
	public class DnsApiTests
	{
		private const string dnsSvr = "c1dns.cableone.net";
		private const string dnsSvrIp = "24.116.0.53";

		[Test]
		public void DnsAcquireContextHandleTest()
		{
			Assert.That(DnsAcquireContextHandle(true, default, out var ctx), ResultIs.Successful);
			Assert.That(ctx, ResultIs.ValidHandle);
			Assert.That(() => ctx.Dispose(), Throws.Nothing);
		}

		[Test]
		public void DnsExtractRecordsFromMessageTest()
		{
			using var mem = new SafeHGlobalHandle(64);
			Assert.That(DnsExtractRecordsFromMessage(mem, (ushort)(uint)mem.Size, out var results), ResultIs.Successful);
		}

		[Test]
		public void DnsGetProxyInformationTest()
		{
			var pi = new DNS_PROXY_INFORMATION { version = 1 };
			var rpi = new DNS_PROXY_INFORMATION { version = 1 };
			Assert.That(DnsGetProxyInformation(dnsSvr, ref pi, ref rpi), ResultIs.Successful);
			if (pi.proxyName != default)
				DnsFreeProxyName(pi.proxyName);
			if (rpi.proxyName != default)
				DnsFreeProxyName(rpi.proxyName);
		}

		[Test]
		public void DnsModifyRecordsInSetTest()
		{
			Assert.That(DnsQuery(dnsSvr, DNS_TYPE.DNS_TYPE_ALL, 0, default, out var results), ResultIs.Successful);
			Assert.That(results, ResultIs.ValidHandle);
			Assert.That(DnsModifyRecordsInSet(results, results, DNS_UPDATE.DNS_UPDATE_SECURITY_USE_DEFAULT), ResultIs.Value(Win32Error.ERROR_TIMEOUT));
		}

		[Test]
		public void DnsNameCompareTest()
		{
			Assert.That(DnsNameCompare(dnsSvr, dnsSvr), Is.True);
		}

		[Test]
		public void DnsQueryConfigTest([Values] DNS_CONFIG_TYPE ctype)
		{
			var type = CorrespondingTypeAttribute.GetCorrespondingTypes(ctype, CorrespondingAction.GetSet).FirstOrDefault();
			if (type is null || type == typeof(StrPtrAnsi)) Assert.Pass($"{ctype} Ignored");
			var sz = 1024U;
			using var mem = new SafeCoTaskMemHandle(sz);
			Assert.That(DnsQueryConfig(ctype, 0, null, default, mem, ref sz), ResultIs.Successful);
			mem.DangerousGetHandle().Convert(sz, type, CharSet.Unicode).WriteValues();
		}

		[Test]
		public void DnsQueryExTest()
		{
			using var evt = new System.Threading.AutoResetEvent(false);
			var req = new DNS_QUERY_REQUEST
			{
				Version = DNS_QUERY_REQUEST_VERSION1,
				QueryName = dnsSvr,
				QueryOptions = DNS_QUERY_OPTIONS.DNS_QUERY_STANDARD,
				QueryType = DNS_TYPE.DNS_TYPE_ALL,
				pQueryCompletionCallback = Callback
			};
			var res = new DNS_QUERY_RESULT { Version = DNS_QUERY_REQUEST_VERSION1 };
			Assert.That(DnsQueryEx(req, ref res, out var cancel), ResultIs.Value(Win32Error.DNS_REQUEST_PENDING));
			if (!evt.WaitOne(20000))
			{
				Assert.That(DnsCancelQuery(cancel), ResultIs.Successful);
				Assert.Fail("Completion callback not called.");
			}
			if (res.pQueryRecords != default)
				DnsRecordListFree(res.pQueryRecords);

			void Callback(IntPtr pQueryContext, ref DNS_QUERY_RESULT pQueryResults)
			{
				evt.Set();
			}
		}

		[Test]
		public void DnsQueryTest()
		{
			Assert.That(DnsQuery(dnsSvr, DNS_TYPE.DNS_TYPE_ALL, 0, default, out var results), ResultIs.Successful);
			Assert.That(results, ResultIs.ValidHandle);
			results.ToArray().WriteValues();
		}

		[Test]
		public void DnsRecordCompareTest()
		{
			var r1 = new DNS_RECORD { pName = dnsSvr, wType = DNS_TYPE.DNS_TYPE_A, Data = new DNS_A_DATA { IpAddress = 0xFFFFFF0U } };
			Assert.That(DnsRecordCompare(r1, r1), Is.True);
		}

		[Test]
		public void DnsRecordSetCompareTest()
		{
			Assert.That(DnsQuery(dnsSvr, DNS_TYPE.DNS_TYPE_ALL, 0, default, out var results), ResultIs.Successful);
			Assert.That(DnsRecordSetCompare(results, results, out var p1, out var p2), ResultIs.Successful);
		}

		[Test]
		public void DnsServiceBrowseTest()
		{
			using var evt = Kernel32.CreateEvent(null, false, true);

			var br = new DNS_SERVICE_BROWSE_REQUEST
			{
				Version = DNS_QUERY_REQUEST_VERSION1,
				QueryName = "_windns-example._udp",
				pQueryContext = (IntPtr)evt
			};
			br.Callback.pBrowseCallback = Callback;
			Assert.That(DnsServiceBrowse(br, out var cancel), ResultIs.Value(Win32Error.DNS_REQUEST_PENDING));
			if (Kernel32.WaitForSingleObject(evt, 20000) != Kernel32.WAIT_STATUS.WAIT_OBJECT_0)
			{
				Assert.That(DnsServiceBrowseCancel(cancel), ResultIs.Successful);
				Assert.Fail("Browse callback not called.");
			}

			var queryRequest = new MDNS_QUERY_REQUEST
			{
				Version = DNS_QUERY_REQUEST_VERSION1,
				Query = "_windns-example._udp.local",
				QueryType = DNS_TYPE.DNS_TYPE_PTR,
				QueryOptions = DNS_QUERY_OPTIONS.DNS_QUERY_STANDARD,
				pQueryCallback = QueryCallback,
				pQueryContext = (IntPtr)evt
			};
			Assert.That(DnsStartMulticastQuery(queryRequest, out var queryHandle), ResultIs.Successful);
			if (Kernel32.WaitForSingleObject(evt, 20000) != Kernel32.WAIT_STATUS.WAIT_OBJECT_0)
			{
				Assert.That(DnsStopMulticastQuery(queryHandle), ResultIs.Successful);
				Assert.Fail("Multicast callback not called.");
			}

			void Callback(uint Status, IntPtr pQueryContext, IntPtr pDnsRecord)
			{
				Kernel32.SetEvent(pQueryContext);
			}

			void QueryCallback(IntPtr pQueryContext, IntPtr pQueryHandle, IntPtr pQueryResults)
			{
				var pQueryRecs = IntPtr.Zero;
				unsafe
				{
					var pQR = (DNS_QUERY_RESULT*)(void*)pQueryResults;
					pQueryResults = pQR->pQueryRecords;
				}
				using var recs = new SafeDnsRecordList(pQueryRecs);
				using var qevt = Kernel32.CreateEvent(null, false, true);
				var rec = recs.FirstOrDefault();
				if (rec.wDataLength == 0)
					return;
				var resolveRequest = new DNS_SERVICE_RESOLVE_REQUEST
				{
					Version = DNS_QUERY_REQUEST_VERSION1,
					QueryName = rec.Data is DNS_PTR_DATA d ? d.pNameHost : null,
					pResolveCompletionCallback = ResolveCallback,
					pQueryContext = (IntPtr)qevt
				};
				Assert.That(DnsServiceResolve(resolveRequest, out var cancel), ResultIs.Value(Win32Error.DNS_REQUEST_PENDING));
				if (Kernel32.WaitForSingleObject(qevt, 20000) != Kernel32.WAIT_STATUS.WAIT_OBJECT_0)
				{
					Assert.That(DnsServiceResolveCancel(cancel), ResultIs.Successful);
					Assert.Fail("Resolve callback not called.");
				}
				Kernel32.SetEvent(pQueryContext);
			}

			void ResolveCallback(uint Status, IntPtr pQueryContext, IntPtr pInstance)
			{
				Kernel32.SetEvent(pQueryContext);
			}
		}

		[Test]
		public void DnsServiceRegisterTest()
		{
			SafePDNS_SERVICE_INSTANCE si;
			Assert.That(si = DnsServiceConstructInstance("initial._windns-example._udp.local", "example.com", IntPtr.Zero, IntPtr.Zero, 1, 0, 0, 0, null, null), ResultIs.ValidHandle);

			var callbackCalled = false;
			var sr = new DNS_SERVICE_REGISTER_REQUEST
			{
				Version = DNS_QUERY_REQUEST_VERSION1,
				pRegisterCompletionCallback = Callback,
				pServiceInstance = si,
			};
			Assert.That(DnsServiceRegister(sr, out var cancel), ResultIs.Value(Win32Error.DNS_REQUEST_PENDING));
			Thread.Sleep(500);
			if (!callbackCalled)
				Assert.That(DnsServiceRegisterCancel(cancel), ResultIs.Successful);
			Assert.That(DnsServiceDeRegister(sr, cancel), ResultIs.Value(Win32Error.DNS_REQUEST_PENDING));

			void Callback(uint Status, IntPtr pQueryContext, IntPtr pInstance) => callbackCalled = true;
		}

		[Test]
		public void DnsValidateNameTest()
		{
			Assert.That(DnsValidateName(dnsSvr, DNS_NAME_FORMAT.DnsNameHostnameFull), ResultIs.Successful);
		}

		[Test]
		public void DnsValidateServerStatusTest()
		{
			Assert.That(DnsValidateServerStatus(new Ws2_32.SOCKADDR(System.Net.IPAddress.Parse(dnsSvrIp)), null, out var stat), ResultIs.Successful);
			Assert.That(stat, Is.EqualTo(DnsServerStatus.ERROR_SUCCESS));
		}

		[Test]
		public void DnsWriteQuestionToBufferTest()
		{
			var sz = 64U;
			using var mem = new SafeHGlobalHandle(sz);
			Assert.That(DnsWriteQuestionToBuffer(mem, ref sz, "microsoft", DNS_TYPE.DNS_TYPE_A, 1, true), ResultIs.Successful);
			var buf = mem.ToStructure<DNS_MESSAGE_BUFFER>();
			DNS_BYTE_FLIP_HEADER_COUNTS(ref buf);
			buf.WriteValues();
			if (sz <= mem.Size)
				TestContext.Write(string.Join(":", mem.ToArray<byte>((int)sz - 12, 12)));
		}
	}
}