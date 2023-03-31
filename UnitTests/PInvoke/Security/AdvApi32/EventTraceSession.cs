using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.AdvApi32;

namespace Vanara.PInvoke.Tests;

[Flags]
public enum EventTraceLoggingModes : uint
{
	FileModeNone = LogFileMode.EVENT_TRACE_FILE_MODE_NONE,
	FileModeSequential = LogFileMode.EVENT_TRACE_FILE_MODE_SEQUENTIAL,
	FileModeCircular = LogFileMode.EVENT_TRACE_FILE_MODE_CIRCULAR,
	FileModeAppend = LogFileMode.EVENT_TRACE_FILE_MODE_APPEND,
	FileModeNewFile = LogFileMode.EVENT_TRACE_FILE_MODE_NEWFILE,
	FileModePreAllocate = LogFileMode.EVENT_TRACE_FILE_MODE_PREALLOCATE,
	RealTimeMode = LogFileMode.EVENT_TRACE_REAL_TIME_MODE,
	DelayOpenFileMode = LogFileMode.EVENT_TRACE_DELAY_OPEN_FILE_MODE,
	BufferingMode = LogFileMode.EVENT_TRACE_BUFFERING_MODE,
	PrivateLoggerMode = LogFileMode.EVENT_TRACE_PRIVATE_LOGGER_MODE,
	AddHeaderMode = LogFileMode.EVENT_TRACE_ADD_HEADER_MODE,
	UseGlobalSequence = LogFileMode.EVENT_TRACE_USE_GLOBAL_SEQUENCE,
	UseLocalSequence = LogFileMode.EVENT_TRACE_USE_LOCAL_SEQUENCE,
	RelogMode = LogFileMode.EVENT_TRACE_RELOG_MODE,
	UsePagedMemory = LogFileMode.EVENT_TRACE_USE_PAGED_MEMORY
}

public class EventTraceException : Exception
{
	internal EventTraceException(string message) : base(message)
	{
	}

	internal EventTraceException(Win32Error err, string message = null) : base(message ?? err.ToString(), err.GetException())
	{
	}

	internal EventTraceException(Exception ex) : base(null, ex)
	{
	}
}

public class EventTraceSession
{
	protected TRACEHANDLE traceSession;

	public EventTraceSession()
	{
	}

	public EventTraceSession(string name)
	{
		Name = name;
		GetSessionHandleFromLoggerName();
	}

	public EventTraceSession(string name, string loggingFile, EventTraceLoggingModes flags)
	{
		Name = name;
		LogFilePath = loggingFile;
		TraceLogMode = flags;
	}

	internal EventTraceSession(in EVENT_TRACE_PROPERTIES cprops) => UpdateFromNative(cprops);

	public static IReadOnlyCollection<EventTraceSession> ActiveSessions { get; } = new EventTraceSessionCollection();

	// <summary>Time delay before unused buffers are freed, in minutes.</summary>
	public TimeSpan AgeLimit { get; set; }

	// <summary>The amount of memory allocated for each event tracing session buffer in kilobytes.</summary>
	public int BufferSize { get; set; }

	// <summary>Number of buffers written.</summary>
	public int BuffersWritten { get; private set; }

	// <summary>Number of event traces that were not recorded.</summary>
	public int EventsLost { get; private set; }

	// <summary>The time delay before dirty buffers get scheduled to be flushed, in seconds.</summary>
	public TimeSpan FlushTimer { get; set; }

	// <summary>Number of buffers that are allocated but unused in the event tracing session's buffer pool.</summary>
	public int FreeBuffers { get; private set; }

	// <summary>Number of buffers that could not be written to the log file.</summary>
	public int LogBuffersLost { get; private set; }

	// <summary>The path of the logging file.</summary>
	public string LogFilePath { get; set; }

	// <summary>The maximum number of buffers allocated for the event tracing session's buffer pool.</summary>
	public int MaximumBuffers { get; set; }

	// <summary>The maximum size of the file used to log event traces, in megabytes.</summary>
	public int MaximumFileSize { get; set; }

	// <summary>The minimum number of buffers allocated for the event tracing session's buffer pool.</summary>
	public int MinimumBuffers { get; set; }

	// <summary>Name of the tracing session.</summary>
	public string Name { get; set; }

	// <summary>Number of buffers allocated for the event tracing session's buffer pool.</summary>
	public int NumberOfBuffers { get; private set; }

	// <summary>The provider description from XML file for the GUID</summary>
	public string ProviderDescription { get; private set; }

	// <summary>The GUID for the information in this structure</summary>
	public Guid ProviderGuid { get; set; }

	// <summary>Provider Id of driver returning this buffer</summary>
	public int ProviderId { get; private set; }

	// <summary>The provider name from XML file for the GUID</summary>
	public string ProviderName { get; private set; }

	// <summary>Number of buffers that could not be delivered in real-time.</summary>
	public int RealTimeBuffersLost { get; private set; }

	// <summary>The thread identifier for the event tracing session.</summary>
	public int SessionThreadID { get; private set; }

	// <summary>Timestamp as returned in units of 100ns since 1/1/1601</summary>
	public DateTime? TimeStamp { get; private set; }

	// <summary>Must contain WNODE_FLAG_TRACED_GUID to indicate that the structure contains event tracing information.</summary>
	public int TraceFlags { get; private set; }

	// <summary>Specifies current logging modes for the event tracing session.</summary>
	public EventTraceLoggingModes TraceLogMode { get; set; }

	// <summary>Logger in use</summary>
	public TRACEHANDLE TraceSessionHandle { get; private set; }

	public void AddTraceLogMode(EventTraceLoggingModes mode) => TraceLogMode |= mode;

	public virtual void EnableProviderTrace(in Guid guidProvider, bool enable, uint flags, TRACE_LEVEL level)
	{
		if (traceSession.IsInvalid)
			GetSessionHandleFromLoggerName();

		if (traceSession.IsInvalid)
			throw new EventTraceException(Win32Error.ERROR_FILE_NOT_FOUND);

		try
		{
			// Set properties from .NET prop container
			ToNative(out var cprops);

			// Start the event trace
			new EventTraceController(traceSession).EnableTrace(guidProvider, enable, flags, level);
		}
		catch (EventTraceException) { throw; }
		catch (Exception ex) { throw new EventTraceException(ex); }
	}

	public virtual void EnableTrace(bool enable, uint flags, TRACE_LEVEL level)
	{
		if (traceSession.IsInvalid)
			GetSessionHandleFromLoggerName();

		if (traceSession.IsInvalid)
			throw new EventTraceException(Win32Error.ERROR_FILE_NOT_FOUND);

		try
		{
			// Set properties from .NET prop container
			ToNative(out var cprops);

			// Start the event trace
			new EventTraceController(traceSession).EnableTrace(cprops, enable, flags, level);
		}
		catch (EventTraceException) { throw; }
		catch (Exception ex) { throw new EventTraceException(ex); }
	}

	public virtual void Query()
	{
		if (traceSession.IsInvalid)
			GetSessionHandleFromLoggerName();

		if (traceSession.IsInvalid)
			throw new EventTraceException(Win32Error.ERROR_FILE_NOT_FOUND);

		try
		{
			// Set properties from .NET prop container
			ToNative(out var cprops);

			// Start the event trace
			new EventTraceController(traceSession).Query(ref cprops);

			// Set properties from StartTrace back to .NET prop container
			UpdateFromNative(cprops);
		}
		catch (EventTraceException) { throw; }
		catch (Exception ex) { throw new EventTraceException(ex); }
	}

	public void RemoveTraceLogMode(EventTraceLoggingModes mode) => TraceLogMode &= ~mode;

	public virtual void Start()
	{
		if (!traceSession.IsInvalid)
		{
			throw new EventTraceException("Object already has an event tracing session attached.");
		}

		try
		{
			// Set properties from instance
			ToNative(out var cprops);

			// Start the event trace
			new EventTraceController(traceSession).Start(ref cprops);

			traceSession = cprops.Wnode.HistoricalContext;

			// Set properties from StartTrace back to .NET prop container
			UpdateFromNative(cprops);
		}
		catch (EventTraceException) { throw; }
		catch (Exception ex) { throw new EventTraceException(ex); }
	}

	public virtual void Stop()
	{
		if (traceSession.IsInvalid)
			GetSessionHandleFromLoggerName();

		if (traceSession.IsInvalid)
			throw new EventTraceException(Win32Error.ERROR_FILE_NOT_FOUND);

		try
		{
			// Set properties from .NET prop container
			ToNative(out var cprops);

			// Start the event trace
			new EventTraceController(traceSession).Stop(ref cprops);

			// Set properties from StartTrace back to .NET prop container
			UpdateFromNative(cprops);
		}
		catch (EventTraceException) { throw; }
		catch (Exception ex) { throw new EventTraceException(ex); }
	}

	public virtual void Update()
	{
		if (traceSession.IsInvalid)
			GetSessionHandleFromLoggerName();

		if (traceSession.IsInvalid)
			throw new EventTraceException(Win32Error.ERROR_FILE_NOT_FOUND);

		try
		{
			// Set properties from .NET prop container
			ToNative(out var cprops);

			// Start the event trace
			new EventTraceController(traceSession).Update(ref cprops);

			// Set properties from StartTrace back to .NET prop container
			UpdateFromNative(cprops);
		}
		catch (EventTraceException) { throw; }
		catch (Exception ex) { throw new EventTraceException(ex); }
	}

	internal static TRACEHANDLE GetSessionHandleFromLoggerName(string loggerName)
	{
		if (!string.IsNullOrEmpty(loggerName))
		{
			var cprops = EVENT_TRACE_PROPERTIES.Create(null, loggerName);
			if (ControlTrace(TRACEHANDLE.NULL, loggerName, ref cprops, EVENT_TRACE_CONTROL.EVENT_TRACE_CONTROL_QUERY).Succeeded)
				return cprops.Wnode.HistoricalContext;
		}
		return TRACEHANDLE.NULL;
	}

	protected void GetSessionHandleFromLoggerName() => traceSession = GetSessionHandleFromLoggerName(Name);

	private void ToNative(out EVENT_TRACE_PROPERTIES cprops)
	{
		cprops = EVENT_TRACE_PROPERTIES.Create(LogFilePath, Name);
		if (ProviderGuid != Guid.Empty)
			cprops.Wnode.Guid = ProviderGuid;
		cprops.MinimumBuffers = (uint)MinimumBuffers;
		cprops.MaximumBuffers = (uint)MaximumBuffers;
		cprops.MaximumFileSize = (uint)MaximumFileSize;
		cprops.LogFileMode = (LogFileMode)TraceLogMode;
		cprops.FlushTimer = (uint)FlushTimer.TotalSeconds;
		cprops.AgeLimit = (int)AgeLimit.TotalMinutes;
	}

	private void UpdateFromNative(in EVENT_TRACE_PROPERTIES cprops)
	{
		ProviderGuid = cprops.Wnode.Guid;
		Name = cprops.LoggerName;
		LogFilePath = cprops.LogFileName;

		BufferSize = (int)cprops.BufferSize;
		MinimumBuffers = (int)cprops.MinimumBuffers;
		MaximumBuffers = (int)cprops.MaximumBuffers;
		MaximumFileSize = (int)cprops.MaximumFileSize;
		TraceLogMode = (EventTraceLoggingModes)cprops.LogFileMode;
		FlushTimer = TimeSpan.FromSeconds((int)cprops.FlushTimer);
		AgeLimit = TimeSpan.FromMinutes(cprops.AgeLimit);

		// Set read-only properties
		ProviderId = (int)cprops.Wnode.ProviderId;
		TraceSessionHandle = cprops.Wnode.HistoricalContext;
		TraceFlags = (int)cprops.Wnode.Flags;
		NumberOfBuffers = (int)cprops.NumberOfBuffers;
		FreeBuffers = (int)cprops.FreeBuffers;
		EventsLost = (int)cprops.EventsLost;
		BuffersWritten = (int)cprops.BuffersWritten;
		LogBuffersLost = (int)cprops.LogBuffersLost;
		RealTimeBuffersLost = (int)cprops.RealTimeBuffersLost;
		SessionThreadID = cprops.LoggerThreadId.DangerousGetHandle().ToInt32();
		TimeStamp = cprops.Wnode.TimeStamp.ToUInt64() != 0 ? cprops.Wnode.TimeStamp.ToDateTime() : (DateTime?)null;
	}

	private class EventTraceSessionCollection : IReadOnlyCollection<EventTraceSession>
	{
		internal EventTraceSessionCollection()
		{
		}

		public int Count => Items.Count();

		private IEnumerable<EventTraceSession> Items => QueryAllTraces().Select(prop => new EventTraceSession(prop));

		public static IEnumerable<EVENT_TRACE_PROPERTIES> QueryAllTraces()
		{
			const int len = 64;
			var props = new List<SafeHGlobalHandle>(len);
			var loadProp = EVENT_TRACE_PROPERTIES.Create();
			for (var i = 0; i < len; i++)
				props.Add(SafeHGlobalHandle.CreateFromStructure(loadProp));
			try
			{
				var pprops = props.Select(p => (IntPtr)p).ToArray();
				AdvApi32.QueryAllTraces(pprops, len, out var count).ThrowIfFailed();
				for (var i = 0; i < count; i++)
					yield return props[i].ToStructure<EVENT_TRACE_PROPERTIES>();
			}
			finally
			{
				for (var i = 0; i < props.Count; i++)
					props[i].Dispose();
			}
		}

		public IEnumerator<EventTraceSession> GetEnumerator() => Items.GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}