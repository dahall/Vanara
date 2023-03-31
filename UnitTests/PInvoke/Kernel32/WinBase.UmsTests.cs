using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Vanara.InteropServices;
using static Vanara.PInvoke.AdvApi32;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public partial class WinBaseTests_Ums
{
	[Test]
	public void UmsTest()
	{
		Assert.That(CreateUmsCompletionList(out SafePUMS_COMPLETION_LIST compList), ResultIs.Successful);
		Assert.That(compList, ResultIs.ValidHandle);
		UMS_SCHEDULER_STARTUP_INFO si = new(SchProc, default, compList);
		//Assert.That(EnterUmsSchedulingMode(si), ResultIs.Successful);
		SchProc(RTL_UMS_SCHEDULER_REASON.UmsSchedulerStartup, default, default);

		void SchProc(RTL_UMS_SCHEDULER_REASON Reason, IntPtr ActivationPayload, IntPtr SchedulerParam)
		{
			if (Reason == RTL_UMS_SCHEDULER_REASON.UmsSchedulerStartup)
			{
				Assert.That(CreateUmsThreadContext(out SafePUMS_CONTEXT ctx), ResultIs.Successful);
				Assert.That(ctx, ResultIs.ValidHandle);
				using SafeProcThreadAttributeList atList = SafeProcThreadAttributeList.Create(new Dictionary<PROC_THREAD_ATTRIBUTE, object>
					{ { PROC_THREAD_ATTRIBUTE.PROC_THREAD_ATTRIBUTE_UMS_THREAD, new UMS_CREATE_THREAD_ATTRIBUTES(ctx, compList) } });
				using SafeHTHREAD hThread = CreateRemoteThreadEx(GetCurrentProcess(), null, 0, UmsWorkerThread, SchedulerParam, 0, atList, out uint threadId);
				Assert.That(hThread, ResultIs.ValidHandle);
			}

			Assert.That(DequeueUmsCompletionListItems(compList, 0, out PUMS_CONTEXT cl), ResultIs.Successful);
			Assert.That(GetNextUmsListItem(cl), ResultIs.Not.ValidHandle);
			//Assert.That(ExecuteUmsThread(cl), ResultIs.Successful);
			//Assert.That(GetCurrentUmsThread(), ResultIs.ValidHandle);
			Assert.That(() => cl.IsSuspended, Throws.Nothing);
			Assert.That(GetUmsCompletionListEvent(compList, out SafeEventHandle compEvnt), ResultIs.Successful);
			UMS_SYSTEM_THREAD_INFORMATION info = UMS_SYSTEM_THREAD_INFORMATION.Default;
			Assert.That(GetUmsSystemThreadInformation(GetCurrentThread(), ref info), ResultIs.Successful);
			//Assert.That(info.ThreadUmsFlags, Is.InRange(ThreadUmsFlags.IsUmsSchedulerThread, ThreadUmsFlags.IsUmsWorkerThread));
		}

		uint UmsWorkerThread(IntPtr SchedulerParam)
		{
			Sleep(250);
			Assert.That(UmsThreadYield(SchedulerParam), ResultIs.Successful);
			return 0;
		}
	}
}