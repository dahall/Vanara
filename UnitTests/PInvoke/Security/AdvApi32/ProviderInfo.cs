using System;
using static Vanara.PInvoke.AdvApi32;

namespace Vanara.PInvoke.Tests;

public partial class EvnTraceTests
{
	public class ProviderInfo
	{
		public const ulong DefaultKeywords = 0;
		public const TRACE_LEVEL DefaultLevel = (TRACE_LEVEL)0xFF; // Match any level
																   // Match all events

		public ProviderInfo(Guid id, ulong keywords = DefaultKeywords, TRACE_LEVEL level = DefaultLevel)
		{
			if (id == Guid.Empty)
				throw new ArgumentException(nameof(id));

			Id = id;
			Keywords = keywords;
			Level = level;
		}

		public Guid Id { get; private set; }

		public ulong Keywords { get; private set; }

		public TRACE_LEVEL Level { get; private set; }
	}
}