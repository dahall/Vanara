using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.AdvApi32;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests
{
	[TestFixture()]
	public partial class EvnTraceTests
	{
		private const string logfilePath = TestCaseSources.EventFile;

		[Test]
		public void EnumerateTraceGuidsTest()
		{
			var memList = new List<SafeHGlobalHandle>();
			var sz = Marshal.SizeOf<TRACE_GUID_PROPERTIES>();
			var pprovs = new IntPtr[1];
			memList.Add(new SafeHGlobalHandle(sz));
			pprovs[0] = memList[0];
			try
			{
				Assert.That(EnumerateTraceGuids(pprovs, 0, out var req), ResultIs.FailureCode(Win32Error.ERROR_MORE_DATA));

				Array.Resize(ref pprovs, (int)req);
				for (int i = 1; i < req; i++)
				{
					memList.Add(new SafeHGlobalHandle(sz));
					pprovs[i] = memList[i];
				}

				Assert.That(EnumerateTraceGuids(pprovs, (uint)pprovs.Length, out req), ResultIs.Successful);
			}
			finally
			{
				for (int i = 0; i < memList.Count; i++)
				{
					TestContext.Write($"({i}) ");
					memList[i].ToStructure<TRACE_GUID_PROPERTIES>().WriteValues();
					memList[i].Dispose();
				}
			}
		}

		[Test]
		public void EnumerateTraceGuidsExTest()
		{
			foreach (var guid in EnumerateTraceGuidsEx<Guid>(TRACE_QUERY_INFO_CLASS.TraceGuidQueryList))
			{
				TestContext.WriteLine($"{guid} =============================");
				using (var infoBlocks = EnumerateTraceGuidsEx<Guid>(TRACE_QUERY_INFO_CLASS.TraceGuidQueryInfo, guid))
				{
					var info = infoBlocks.ToStructure<TRACE_GUID_INFO>();
					var providerPtr = infoBlocks.DangerousGetHandle().Offset(Marshal.SizeOf(typeof(TRACE_GUID_INFO)));
					for (var i = 0; i < info.InstanceCount; i++)
					{
						var provInfo = providerPtr.ToStructure<TRACE_PROVIDER_INSTANCE_INFO>();
						TestContext.WriteLine($"  ProcId: {provInfo.Pid}; Flags: {provInfo.Flags}");
						var enablePtr = providerPtr.Offset(Marshal.SizeOf(typeof(TRACE_PROVIDER_INSTANCE_INFO)));
						var enableSz = Marshal.SizeOf(typeof(TRACE_ENABLE_INFO));
						for (var j = 0; j < provInfo.EnableCount; j++)
						{
							var enable = enablePtr.ToStructure<TRACE_ENABLE_INFO>();
							TestContext.WriteLine($"    Enabled: {enable.IsEnabled}; Lvl: {enable.Level}; Prop: {enable.EnableProperty}");
							enablePtr = enablePtr.Offset(enableSz);
						}
						providerPtr = providerPtr.Offset(provInfo.NextOffset);
					}
				}
			}
		}

		[Test]
		public void EventAccessTest()
		{
			var etp = EVENT_TRACE_PROPERTIES.Create(Guid.NewGuid());
			etp.LogFileMode = LogFileMode.EVENT_TRACE_FILE_MODE_SEQUENTIAL;
			etp.MaximumFileSize = 1;
			etp.LogFileName = logfilePath;
			etp.LoggerName = "MySession";
			var sess = new EventTraceSession(etp);

			var sz = 1024U;
			using (var sd = new SafePSECURITY_DESCRIPTOR((int)sz))
			{
				Assert.That(EventAccessQuery(sess.ProviderGuid, sd, ref sz), ResultIs.Successful);
				Assert.That(EventAccessControl(sess.ProviderGuid, EVENTSECURITYOPERATION.EventSecurityAddDACL, SafePSID.Current, TRACELOG_RIGHTS.WMIGUID_QUERY, true), ResultIs.Successful);
				Assert.That(EventAccessRemove(sess.ProviderGuid), ResultIs.Successful);
			}
		}

		[Test]
		public void QueryAllTracesTest()
		{
			Assert.That(() =>
			{
				Assert.That(EventTraceSession.ActiveSessions.Count, Is.GreaterThan(0));
				foreach (var s in EventTraceSession.ActiveSessions)
					s.WriteValues();
			}, Throws.Nothing);
		}

		[Test]
		public void QueryTraceTest()
		{
			var sess = EventTraceSession.ActiveSessions.First();
			var prop = EVENT_TRACE_PROPERTIES.Create();
			Assert.That(QueryTrace(sess.TraceSessionHandle, null, ref prop), ResultIs.Successful);
			prop.WriteValues();
		}

		[Test]
		public void OpenProcessCloseTraceTest()
		{
			var callbackCount = 0;
			Assert.That(() =>
			{
				var logFile = new EventLogFile(logfilePath);
				logFile.EventCallback = EvtCallback;
				using (var log = new EventTraceSingleLog(logFile))
				{
					using (var mem = SafeHGlobalHandle.CreateFromStructure<ETW_TRACE_PARTITION_INFORMATION>())
					{
						Assert.That(QueryTraceProcessingHandle(log.Handle, ETW_PROCESS_HANDLE_INFO_TYPE.EtwQueryPartitionInformation, default, 0, mem, mem.Size, out var retLen), ResultIs.Successful);
						mem.ToStructure<ETW_TRACE_PARTITION_INFORMATION>().WriteValues();
					}
					log.ProcessTrace();
				}
			}, Throws.Nothing);

			void EvtCallback(in EVENT_TRACE pEvent)
			{
				if (callbackCount++ == 0)
				{
				}
			}
		}

		[Test]
		public void StartEnableStopTraceTest()
		{
			var etp = EVENT_TRACE_PROPERTIES.Create(Guid.NewGuid());
			etp.LogFileMode = LogFileMode.EVENT_TRACE_FILE_MODE_SEQUENTIAL;
			etp.MaximumFileSize = 1;
			etp.LogFileName = logfilePath;
			etp.LoggerName = "MySession";
			var sess = new EventTraceSession(etp);
			sess.Start();
			try
			{
				var pguid = new Guid("{D8909C24-5BE9-4502-98CA-AB7BDC24899D}");
				var tl = (TRACE_LEVEL)0xff;
				sess.EnableProviderTrace(pguid, true, 0, tl);

				using (var mem = SafeHGlobalHandle.CreateFromStructure<TRACE_PERIODIC_CAPTURE_STATE_INFO>())
				{
					Assert.That(TraceQueryInformation(sess.TraceSessionHandle, TRACE_QUERY_INFO_CLASS.TracePeriodicCaptureStateInfo, mem, mem.Size, out var retLen), ResultIs.Successful);
					mem.ToStructure<TRACE_PERIODIC_CAPTURE_STATE_INFO>().WriteValues();

					Marshal.WriteByte(mem, 1); // BOOLEAN = TRUE
					Assert.That(TraceSetInformation(sess.TraceSessionHandle, TRACE_QUERY_INFO_CLASS.TraceProviderBinaryTracking, mem, 1), ResultIs.Successful);
				}

				Assert.That(EnableTraceEx2(sess.TraceSessionHandle, pguid, EVENT_CONTROL_CODE.EVENT_CONTROL_CODE_DISABLE_PROVIDER, tl), ResultIs.Successful);
				Assert.That(EnableTraceEx(pguid, IntPtr.Zero, sess.TraceSessionHandle, true, tl), ResultIs.Successful);
				sess.EnableProviderTrace(pguid, false, 0, tl);
			}
			finally
			{
				Assert.That(StopTrace(sess.TraceSessionHandle, etp.LoggerName, ref etp), ResultIs.Successful);
				//sess.Stop();
			}
		}

		[StructLayout(LayoutKind.Sequential)]
		private class MY_EVENT : PEVENT_TRACE_HEADER
		{
			public int Value;

			public MY_EVENT(in Guid guid, int value)
			{
				Header.Size = (ushort)Marshal.SizeOf(this);
				Header.Guid = guid;
				Header.Flags = WNODE_FLAG.WNODE_FLAG_TRACED_GUID;
				Header.Class.Type = EVENT_TRACE_TYPE.EVENT_TRACE_TYPE_START;
				Header.Class.Version = 1;
				Value = value;
			}
		}

		[StructLayout(LayoutKind.Sequential)]
		private class MyEventInst : PEVENT_INSTANCE_HEADER
		{
			public int Value;

			public MyEventInst(int value)
			{
				Header.Size = (ushort)Marshal.SizeOf(this);
				Header.Union.Flags = WNODE_FLAG.WNODE_FLAG_TRACED_GUID;
				Header.Class.Type = value == 0 ? EVENT_TRACE_TYPE.EVENT_TRACE_TYPE_START : EVENT_TRACE_TYPE.EVENT_TRACE_TYPE_END;
				Value = value;
			}
		}

		[Test]
		public unsafe void TraceTest()
		{
			var ProviderGuid = Guid.NewGuid();
			var MyCategoryGuid = Guid.NewGuid();
			var pMyCategoryGuid = SafeHGlobalHandle.CreateFromStructure(MyCategoryGuid);
			var tempID = Guid.NewGuid();

			TRACEHANDLE g_SessionHandle = default;
			bool g_TraceOn = false;

			var guidReg = new TRACE_GUID_REGISTRATION { Guid = (IntPtr)pMyCategoryGuid };
			var EventClassGuids = new[] { guidReg };

			Assert.That(RegisterTraceGuids(ControlCallback, default, ProviderGuid, (uint)EventClassGuids.Length, EventClassGuids, null, default, out var RegistrationHandle), ResultIs.Successful);
			//Assert.That(UnsafeRegisterTraceGuids(ControlCallback, null, &ProviderGuid, (uint)EventClassGuids.Length, &guidReg, null, null, out var RegistrationHandle), ResultIs.Successful);
			try
			{
				if (g_TraceOn)
					Assert.That(ProvideEvents(), ResultIs.Successful);
				//Assert.That(ProvideInstanceEvents(EventClassGuids[0]), ResultIs.Successful);
			}
			finally
			{
				Assert.That(UnregisterTraceGuids(RegistrationHandle), ResultIs.Successful);
			}

			Win32Error ControlCallback(WMIDPREQUESTCODE RequestCode, IntPtr Context, ref uint Reserved, IntPtr Buffer)
			{
				var TempSessionHandle = GetTraceLoggerHandle((IntPtr)Buffer);
				if (TempSessionHandle.IsInvalid)
					return Win32Error.GetLastError();

				switch (RequestCode)
				{
					case WMIDPREQUESTCODE.WMI_ENABLE_EVENTS:
						Debug.WriteLine($"Callback: Level={GetTraceEnableLevel(TempSessionHandle)}, Flags={GetTraceEnableFlags(TempSessionHandle)})");
						g_TraceOn = true;
						break;

					case WMIDPREQUESTCODE.WMI_DISABLE_EVENTS:
						Debug.WriteLine("Logging disabled");
						g_TraceOn = false;
						break;

					default:
						return Win32Error.ERROR_INVALID_PARAMETER;
				}
				return Win32Error.ERROR_SUCCESS;
			}

			Win32Error ProvideEvents()
			{
				const string szActionMsg = "The next action is ";

				// Output next action
				var ulError = TraceMessage(g_SessionHandle, TRACE_MESSAGE.TRACE_MESSAGE_SEQUENCE | TRACE_MESSAGE.TRACE_MESSAGE_GUID | TRACE_MESSAGE.TRACE_MESSAGE_TIMESTAMP | TRACE_MESSAGE.TRACE_MESSAGE_SYSTEMINFO,
					tempID, 502, __arglist(szActionMsg, szActionMsg.Length, 5, Marshal.SizeOf(5), null, 0));
				if (ulError.Failed)
					return ulError;

				var evt = new MY_EVENT(MyCategoryGuid, 5);
				return TraceEvent(g_SessionHandle, evt);
				//using (var mem = new SafeHGlobalHandle(Marshal.SizeOf<EVENT_TRACE_HEADER>() + 4))
				//{
				//	Marshal.StructureToPtr(evt.Header, mem, false);
				//	Marshal.StructureToPtr(evt.Value, mem.DangerousGetHandle().Offset(Marshal.SizeOf<EVENT_TRACE_HEADER>()), false);
				//	return TraceEvent(g_hProvider, mem);
				//}
			}

			Win32Error ProvideInstanceEvents(in TRACE_GUID_REGISTRATION TraceGuidReg)
			{
				// The event instance info for the whole LiftUp group of events
				EVENT_INSTANCE_INFO evtInst = default;
				CreateTraceInstanceId(TraceGuidReg.RegHandle, ref evtInst);
				return TraceEventInstance(g_SessionHandle, new MyEventInst(5), evtInst);
			}
		}
	}

	/*private class Controller
	{
		private bool m_bInited;
		private Guid m_ProviderGuid;
		private TRACEHANDLE m_hSessionHandle;
		private EVENT_TRACE_PROPERTIES m_pSessionProperties;

		public Controller() => m_ProviderGuid = SystemTraceControlGuid;

		public void Start()
		{
			if (m_bInited)
				return;

			if (m_pSessionProperties.BufferSize == 0)
				MakeSessionProperties(m_ProviderGuid, false, out m_pSessionProperties);

			StartTrace(out m_hSessionHandle, KERNEL_LOGGER_NAME, ref m_pSessionProperties).ThrowIfFailed();
			m_bInited = true;
		}

		public void Stop()
		{
			if (m_pSessionProperties.BufferSize == 0)
			{
				MakeSessionProperties(m_ProviderGuid, false, out var pSessionProperties);
				StopTrace(ref m_hSessionHandle, ref pSessionProperties);
			}
			else
			{
				StopTrace(ref m_hSessionHandle, ref m_pSessionProperties);
			}
		}

		public void Enable(uint EnableFlag, TRACE_LEVEL EnableLevel) => EnableTrace(true, EnableFlag, EnableLevel, m_ProviderGuid, m_hSessionHandle).ThrowIfFailed();

		private void StopTrace(ref TRACEHANDLE hSessionHandle, ref EVENT_TRACE_PROPERTIES pSessionProperties)
		{
			if (!hSessionHandle.IsNull)
			{
				ControlTrace(hSessionHandle, null, ref pSessionProperties, EVENT_TRACE_CONTROL.EVENT_TRACE_CONTROL_STOP).ThrowIfFailed();
				hSessionHandle = TRACEHANDLE.NULL;
			}
			else
			{
				ControlTrace(TRACEHANDLE.NULL, KERNEL_LOGGER_NAME, ref pSessionProperties, EVENT_TRACE_CONTROL.EVENT_TRACE_CONTROL_STOP).ThrowIfFailed();
			}

			pSessionProperties = default;
		}

		private static void MakeSessionProperties(in Guid sessionId, bool createForQuery, out EVENT_TRACE_PROPERTIES pSessionProperties)
		{
			var uBufferSize = (uint)Marshal.SizeOf<EVENT_TRACE_PROPERTIES>();
			pSessionProperties = new EVENT_TRACE_PROPERTIES
			{
				Wnode = new WNODE_HEADER
				{
					BufferSize = uBufferSize,
					Guid = sessionId,
					Flags = WNODE_FLAG.WNODE_FLAG_TRACED_GUID,
					ClientContext = 1,
				},
				LogFileMode = createForQuery ? 0 : LogFileMode.EVENT_TRACE_REAL_TIME_MODE,
				LoggerNameOffset = uBufferSize - (uint)((EVENT_TRACE_PROPERTIES.MaxLogFileNameLength + EVENT_TRACE_PROPERTIES.MaxLoggerNameLength) * StringHelper.GetCharSize())
			};
		}
	}*/
}