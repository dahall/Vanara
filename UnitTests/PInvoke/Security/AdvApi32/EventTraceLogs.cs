using System;
using Vanara.Extensions;
using static Vanara.PInvoke.AdvApi32;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests;

public class EventLogFile
{
	protected internal EVENT_TRACE_LOGFILE m_log;

	public EventLogFile(string? lpszFile, string? lpszLogger = null) => InternalInit(lpszFile, lpszLogger);

	public EventLogFile(EventLogFile src) : this((string?)null) => InternalCopy(src.m_log);

	internal EventLogFile(in EVENT_TRACE_LOGFILE src) : this((string?)null) => InternalCopy(src);

	// TODO: See if you can make this an event
	public BufferCallback BufferCallback
	{
		set => m_log.BufferCallback = value;
	}

	// TODO: See if you can make this an event
	public EventClassCallback EventCallback
	{
		set => m_log.Callback.EventCallback = value;
	}

	public string? LogFilePath
	{
		get => m_log.LogFileName;
		set => m_log.LogFileName = value;
	}

	public string? LoggerName
	{
		get => m_log.LoggerName;
		set => m_log.LoggerName = value;
	}

	public Version LoggerVersion => new Version(m_log.LogfileHeader.VersionDetail.MajorVersion, m_log.LogfileHeader.VersionDetail.MinorVersion, m_log.LogfileHeader.VersionDetail.SubMinorVersion, m_log.LogfileHeader.VersionDetail.SubVersion);

	public PROCESS_TRACE_MODE ProcessTraceMode
	{
		get => m_log.ProcessTraceMode;
		set => m_log.ProcessTraceMode = value;
	}

	public DateTime? BootTime => GetNullableDateTime(m_log.LogfileHeader.BootTime);

	public uint BufferSize => m_log.BufferSize;

	public uint BuffersLost => m_log.LogfileHeader.BuffersLost;

	public uint BuffersRead => m_log.BuffersRead;

	public uint BuffersWritten => m_log.LogfileHeader.BuffersWritten;

	public EVENT_TRACE CurrentEvent => m_log.CurrentEvent;

	public DateTime? CurrentTime => GetNullableDateTime(m_log.CurrentTime);

	public DateTime? EndTime => GetNullableDateTime(m_log.LogfileHeader.EndTime);

	public uint EventsLost => m_log.EventsLost;

	public uint Filled => m_log.Filled;

	public uint MaximumFileSize => m_log.LogfileHeader.MaximumFileSize;

	public uint NumberOfProcessors => m_log.LogfileHeader.NumberOfProcessors;

	public long PerfFreq => m_log.LogfileHeader.PerfFreq;

	public uint ProviderVersion => m_log.LogfileHeader.ProviderVersion;

	public DateTime? StartTime => GetNullableDateTime(m_log.LogfileHeader.StartTime);

	public uint TimerResolution => m_log.LogfileHeader.TimerResolution;

	public TIME_ZONE_INFORMATION TimeZone => m_log.LogfileHeader.TimeZone;

	public bool IsKernelTrace() => m_log.IsKernelTrace;

	protected void InternalCopy(in EVENT_TRACE_LOGFILE src)
	{
		m_log = src;
		m_log.Context = default;
		m_log.Callback.EventCallback = null;
	}

	protected void InternalInit(string? lpszFile = null, string? lpszSession = null)
	{
		m_log = default;

		if (!string.IsNullOrEmpty(lpszFile))
			LogFilePath = lpszFile;

		if (!string.IsNullOrEmpty(lpszSession))
			LoggerName = lpszSession;
	}

	private static DateTime? GetNullableDateTime(in System.Runtime.InteropServices.ComTypes.FILETIME ft) => ft.ToUInt64() == 0 ? (DateTime?)null : ft.ToDateTime();
}

public class EventTraceMultiLogs
{
	protected const int MAX_OPENTRACES = 64;
	protected TRACEHANDLE[] m_hTraceLog = new TRACEHANDLE[MAX_OPENTRACES];

	public EventTraceMultiLogs(params EventLogFile[] eventLogs)
	{
		if (eventLogs == null) return;
		foreach (var l in eventLogs)
			AddTrace(l);
	}

	public int LogCount => Array.FindIndex(m_hTraceLog, h => !h.IsInvalid);

	public virtual TRACEHANDLE AddTrace(EventLogFile log)
	{
		var h = OpenTrace(ref log.m_log);
		if (h.IsInvalid)
			Win32Error.ThrowLastError();
		return m_hTraceLog[LogCount] = h;
	}

	public virtual void Dispose()
	{
		for (var i = 0; i < m_hTraceLog.Length; i++)
		{
			if (m_hTraceLog[i].IsInvalid)
				continue;
			CloseTrace(m_hTraceLog[i]);
			m_hTraceLog[i] = 0;
		}
	}

	public virtual void ProcessTraces() => ProcessTrace(m_hTraceLog, (uint)LogCount).ThrowIfFailed();
};

public class EventTraceSingleLog : IDisposable
{
	protected TRACEHANDLE m_hTraceLog;

	public EventTraceSingleLog(EventLogFile log)
	{
		m_hTraceLog = OpenTrace(ref log.m_log);
		if (m_hTraceLog.IsInvalid) Win32Error.ThrowLastError();
	}

	public virtual void Dispose()
	{
		if (m_hTraceLog.IsInvalid)
			return;
		CloseTrace(m_hTraceLog);
		m_hTraceLog = 0;
	}

	public TRACEHANDLE Handle => m_hTraceLog;

	public virtual void ProcessTrace() => AdvApi32.ProcessTrace(new[] { m_hTraceLog }, 1).ThrowIfFailed();
}