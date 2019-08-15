using NUnit.Framework;
using System;
using Vanara.InteropServices;
using static Vanara.PInvoke.AdvApi32;

namespace Vanara.PInvoke.Tests
{
	[TestFixture()]
	public class wctTests
	{
		[Test]
		public void ThreadWaitChainSessionTest()
		{
			RegisterWaitChainCOMCallback();
			using (new PrivBlock("SeDebugPrivilege"))
			using (var hWct = OpenThreadWaitChainSession(WaitChainSessionType.WCT_SYNC_OPEN_FLAG))
			{
				Assert.That(hWct, ResultIs.ValidHandle);
				var nodes = new WAITCHAIN_NODE_INFO[WCT_MAX_NODE_COUNT];
				uint nodeCnt = (uint)nodes.Length;
				Assert.That(GetThreadWaitChain(hWct, default, WaitChainRetrievalOptions.WCTP_GETINFO_ALL_FLAGS, Kernel32.GetCurrentThreadId(),
					ref nodeCnt, nodes, out var isCycle), ResultIs.Successful);
			}
		}
	}
}