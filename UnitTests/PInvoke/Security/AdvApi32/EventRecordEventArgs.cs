using System;
using static Vanara.PInvoke.AdvApi32;

namespace Vanara.PInvoke.Tests;

public partial class EvnTraceTests
{
	public class EventRecordEventArgs : EventArgs
	{
		public EventRecordEventArgs(in EVENT_RECORD record) => Record = record;

		public bool Cancel { get; set; }
		public EVENT_RECORD Record { get; private set; }
	}
}