using static Vanara.PInvoke.AdvApi32;

namespace Vanara.PInvoke.Tests;

internal class EventTraceController
{
	protected TRACEHANDLE m_hTraceSession;

	public EventTraceController()
	{
	}

	public EventTraceController(string loggerName) : this(EventTraceSession.GetSessionHandleFromLoggerName(loggerName))
	{
	}

	public EventTraceController(in EVENT_TRACE_PROPERTIES props) : this(props.Wnode.HistoricalContext)
	{
	}

	public EventTraceController(TRACEHANDLE hTraceSession) => m_hTraceSession = hTraceSession;

	public void EnableTrace(in Guid guidProvider, bool bEnable = true, uint lFlags = 0, TRACE_LEVEL lLevel = 0) => AdvApi32.EnableTrace(bEnable, lFlags, lLevel, guidProvider, m_hTraceSession).ThrowIfFailed();

	public void EnableTrace(in EVENT_TRACE_PROPERTIES props, bool bEnable = true, uint lFlags = 0, TRACE_LEVEL lLevel = 0) => AdvApi32.EnableTrace(bEnable, lFlags, lLevel, props.Wnode.Guid, m_hTraceSession).ThrowIfFailed();

	public void Query(ref EVENT_TRACE_PROPERTIES props) => ControlTrace(m_hTraceSession, null, ref props, EVENT_TRACE_CONTROL.EVENT_TRACE_CONTROL_QUERY).ThrowIfFailed();

	public void Start(ref EVENT_TRACE_PROPERTIES props) => StartTrace(out m_hTraceSession, props.LoggerName, ref props).ThrowIfFailed();

	public void Stop()
	{
		var props = EVENT_TRACE_PROPERTIES.Create();
		Stop(ref props);
	}

	public void Stop(ref EVENT_TRACE_PROPERTIES props) => ControlTrace(m_hTraceSession, null, ref props, EVENT_TRACE_CONTROL.EVENT_TRACE_CONTROL_STOP).ThrowIfFailed();

	public void Update(ref EVENT_TRACE_PROPERTIES props) => ControlTrace(m_hTraceSession, null, ref props, EVENT_TRACE_CONTROL.EVENT_TRACE_CONTROL_UPDATE).ThrowIfFailed();
};