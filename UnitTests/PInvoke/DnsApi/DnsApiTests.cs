using Microsoft.Win32.SafeHandles;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
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
		public void DnsGetCacheDataTableTest()
		{
			Assert.That(DnsGetCacheDataTable(out var table), ResultIs.Successful);
			foreach (var d in table)
				TestContext.WriteLine($"{d.pszName} => {d.wType}");
			Assert.That(() => table.Dispose(), Throws.Nothing);
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
			var sz = 0U;
			var err = DnsQueryConfig(ctype, 0, null, default, default, ref sz);
			Assert.That(sz, Is.GreaterThan(0U));
			using var mem = new SafeCoTaskMemHandle(sz);
			Assert.That(DnsQueryConfig(ctype, 0, null, default, mem, ref sz), ResultIs.Successful);
			mem.DangerousGetHandle().Convert(sz, type, CharSet.Unicode).WriteValues();
		}

		[Test]
		public void DnsQueryExTest()
		{
			using var evt = new System.Threading.AutoResetEvent(false);
			var cancel = new DNS_QUERY_CANCEL();
			var req = new DNS_QUERY_REQUEST
			{
				Version = DNS_QUERY_REQUEST_VERSION1,
				QueryName = dnsSvr,
				QueryOptions = DNS_QUERY_OPTIONS.DNS_QUERY_WIRE_ONLY | DNS_QUERY_OPTIONS.DNS_QUERY_BYPASS_CACHE,
				QueryType = DNS_TYPE.DNS_TYPE_ALL,
				pQueryCompletionCallback = Callback
			};
			var res = new DNS_QUERY_RESULT { Version = DNS_QUERY_REQUEST_VERSION1 };
			var err = DnsQueryEx(req, ref res, ref cancel);
			if (err == Win32Error.DNS_REQUEST_PENDING && !evt.WaitOne(20000))
			{
				Assert.That(DnsCancelQuery(ref cancel), ResultIs.Successful);
				Assert.Fail("Completion callback not called.");
			}
			else if (err.Failed)
				Assert.Fail(err.ToString());
			if (res.pQueryRecords != default)
			{
				using var rlist = new SafeDnsRecordList(res.pQueryRecords);
				foreach (var r in rlist)
					r.WriteValues();
			}

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
			const int timeout = 20000;
			const string query = "_http._tcp.local";

			using var evt = Kernel32.CreateEvent(null, false, false);

			var br = new DNS_SERVICE_BROWSE_REQUEST
			{
				Version = DNS_QUERY_REQUEST_VERSION1,
				QueryName = query,
				pQueryContext = (IntPtr)evt,
				Callback = new() { pBrowseCallback = (DNS_SERVICE_BROWSE_CALLBACK)Callback }
			};
			Assert.That(DnsServiceBrowse(br, out var cancel), ResultIs.Value(Win32Error.DNS_REQUEST_PENDING));
			if (Kernel32.WaitForSingleObject(evt, timeout) != Kernel32.WAIT_STATUS.WAIT_OBJECT_0)
			{
				Assert.That(DnsServiceBrowseCancel(cancel), ResultIs.Successful);
				Assert.Fail("Browse callback not called.");
			}

			var queryRequest = new MDNS_QUERY_REQUEST
			{
				Version = DNS_QUERY_REQUEST_VERSION1,
				Query = query,
				QueryType = DNS_TYPE.DNS_TYPE_PTR,
				QueryOptions = (ulong)DNS_QUERY_OPTIONS.DNS_QUERY_STANDARD,
				pQueryCallback = QueryCallback,
				pQueryContext = (IntPtr)evt
			};
			Assert.That(DnsStartMulticastQuery(queryRequest, out var queryHandle), ResultIs.Successful);
			if (Kernel32.WaitForSingleObject(evt, timeout) != Kernel32.WAIT_STATUS.WAIT_OBJECT_0)
			{
				Assert.That(DnsStopMulticastQuery(queryHandle), ResultIs.Successful);
				Assert.Fail("Multicast callback not called.");
			}

			void Callback(Win32Error Status, IntPtr pQueryContext, IntPtr pDnsRecord)
			{
				using var recs = new SafeDnsRecordList(pDnsRecord);
				System.Diagnostics.Debug.WriteLine($"Stat:{(Win32Error)Status}; Name:{recs.FirstOrDefault().pName}");
				Kernel32.SetEvent(pQueryContext);
			}

			void QueryCallback(IntPtr pQueryContext, IntPtr pQueryHandle, IntPtr pQueryResults)
			{
				ref DNS_QUERY_RESULT pQR = ref pQueryResults.AsRef<DNS_QUERY_RESULT>();
				System.Diagnostics.Debug.WriteLine($"Stat:{pQR.QueryStatus}; Opt:{pQR.QueryOptions}");
				using var recs = new SafeDnsRecordList(pQR.pQueryRecords);
				using var qevt = Kernel32.CreateEvent(null, false, true);
				var rec = recs.FirstOrDefault();
				if (rec.wDataLength == 0)
					return;
				var resolveRequest = new DNS_SERVICE_RESOLVE_REQUEST
				{
					Version = DNS_QUERY_REQUEST_VERSION1,
					QueryName = rec.Data is DNS_PTR_DATA d ? d.pNameHost : null,
					pResolveCompletionCallback = (DNS_SERVICE_RESOLVE_COMPLETE)ResolveCallback,
					pQueryContext = (IntPtr)qevt
				};
				Assert.That(DnsServiceResolve(resolveRequest, out var cancel), ResultIs.Value(Win32Error.DNS_REQUEST_PENDING));
				if (Kernel32.WaitForSingleObject(qevt, timeout) != Kernel32.WAIT_STATUS.WAIT_OBJECT_0)
				{
					Assert.That(DnsServiceResolveCancel(cancel), ResultIs.Successful);
					Assert.Fail("Resolve callback not called.");
				}
				Kernel32.SetEvent(pQueryContext);
			}

			void ResolveCallback(Win32Error Status, IntPtr pQueryContext, IntPtr pInstance)
			{
				using var inst = new SafePDNS_SERVICE_INSTANCE(pInstance);
				System.Diagnostics.Debug.WriteLine($"Stat:{(Win32Error)Status}; Name:{inst.pszInstanceName}");
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

			void Callback(Win32Error Status, IntPtr pQueryContext, IntPtr pInstance) => callbackCalled = true;
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

		[Test]
		public void DnsCacheDataTable()
		{
			// Ensure RAW_DNS_RECORD is the same size as defined in WinAPI
			Assert.That(Marshal.SizeOf<RAW_DNS_RECORD>(), Is.EqualTo(Environment.Is64BitProcess ? 48 : 40));
			
			DnsGetCacheDataTable(out var dnsCacheDataTable);

			foreach (DNS_CACHE_ENTRY dnsCacheEntry in dnsCacheDataTable)
			{
				DnsQuery(
					dnsCacheEntry.pszName,
					dnsCacheEntry.wType,
					DNS_QUERY_OPTIONS.DNS_QUERY_NO_WIRE_QUERY | DNS_QUERY_OPTIONS.DNS_QUERY_LOCAL,
					IntPtr.Zero,
					out var dnsRecords,
					IntPtr.Zero);

				// Iterate using DNS_RECORD structure
				var cacheUsingStruct = DnsIterateDnsCache(dnsRecords).ToList();

				// Iterate using pointer
				var cacheUsingPointer = DnsIterateDnsCache(
					dnsRecords.GetRecordPointers().Select(dnsRecordPtr => dnsRecordPtr.ToStructure<DNS_RECORD>())).ToList();

				// Iterate using raw DNS_RECORD structure
				var cacheUsingRawStruct = DnsIterateDnsCache(DnsIterateRecords(dnsRecords)).ToList();

				Assert.That(cacheUsingStruct, Is.EquivalentTo(cacheUsingPointer));
				Assert.That(cacheUsingPointer, Is.EquivalentTo(cacheUsingRawStruct));
			}
		}

		private static IEnumerable<IPAddress> DnsIterateDnsCache(IEnumerable<DNS_RECORD> dnsRecords)
		{
			foreach (var dnsRecord in dnsRecords)
			{
				switch (dnsRecord.wType)
				{
					case DNS_TYPE.DNS_TYPE_A:
						yield return new IPAddress(((DNS_A_DATA)dnsRecord.Data).IpAddress.S_un_b);
						break;
					case DNS_TYPE.DNS_TYPE_AAAA:
						yield return new IPAddress(((DNS_AAAA_DATA)dnsRecord.Data).Ip6Address.bytes);
						break;
				}
			}
		}

		private static unsafe List<DNS_RECORD> DnsIterateRecords(SafeDnsRecordList dnsRecords)
		{
			var ret = new List<DNS_RECORD>();

			for (var dnsRecordPtr = (RAW_DNS_RECORD*) dnsRecords.DangerousGetHandle().ToPointer();
				dnsRecordPtr != null;
				dnsRecordPtr = (RAW_DNS_RECORD*) dnsRecordPtr->pNext)
			{
				ret.Add(new DNS_RECORD
				{
					pNext = dnsRecordPtr->pNext,
					pName = Marshal.PtrToStringUni(dnsRecordPtr->pName),
					wType = dnsRecordPtr->wType,
					wDataLength = dnsRecordPtr->wDataLength,
					Flags = dnsRecordPtr->Flags,
					dwTtl = dnsRecordPtr->dwTtl,
					dwReserved = dnsRecordPtr->dwReserved,
					Data = dnsRecordPtr->Address
				});
			}

			return ret;
		}

		[StructLayout(LayoutKind.Sequential)]
		private struct RAW_DNS_RECORD
		{
			public IntPtr pNext;
			public IntPtr pName;
			public DNS_TYPE wType;
			public ushort wDataLength;
			public DNS_RECORD_FLAGS Flags;
			public uint dwTtl;
			public uint dwReserved;
			public AddressData Address;

			[StructLayout(LayoutKind.Sequential, Pack = 1)]
			public struct AddressData
			{
				public uint Part1;
				public uint Part2;
				public ulong Part3;
			}
		}
	}
}