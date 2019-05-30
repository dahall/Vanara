using NUnit.Framework;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using static Vanara.PInvoke.AdvApi32;

namespace Vanara.PInvoke.Tests
{
	[TestFixture()]
	public class ServiceTests
	{
		private const string svcKey = "Windows Management Instrumentation";
		private const string svcName = "Winmgmt";
		private SafeSC_HANDLE hSvc;
		private SafeSC_HANDLE hSvcMgr;

		[OneTimeSetUp]
		public void _Setup()
		{
			hSvcMgr = OpenSCManager(null, null, ScManagerAccessTypes.SC_MANAGER_ALL_ACCESS);
			AssertHandleIsValid(hSvcMgr);
			hSvc = OpenService(hSvcMgr, svcName, ServiceAccessTypes.SERVICE_ALL_ACCESS);
			AssertHandleIsValid(hSvc);
		}

		[OneTimeTearDown]
		public void _TearDown()
		{
			hSvc.Dispose();
			hSvcMgr.Dispose();
		}

		[Test]
		public void ControlServiceTest()
		{
			Assert.That(ControlService(hSvc, ServiceControl.SERVICE_CONTROL_PAUSE, out var status), Is.True);
			Thread.Sleep((int)status.dwWaitHint);
			Assert.That(GetState(hSvc), Is.EqualTo(ServiceState.SERVICE_PAUSED).Or.EqualTo(ServiceState.SERVICE_PAUSE_PENDING));
			Assert.That(ControlService(hSvc, ServiceControl.SERVICE_CONTROL_CONTINUE, out status), Is.True);
			Thread.Sleep((int)status.dwWaitHint);
			Assert.That(GetState(hSvc), Is.EqualTo(ServiceState.SERVICE_RUNNING));
		}

		[Test]
		public void EnumDependentServicesTest()
		{
			var l = EnumDependentServices(hSvc);
			TestContext.WriteLine(string.Join("; ", l.Select(i => i.lpDisplayName)));
			Assert.That(l, Is.Not.Empty);
		}

		[Test]
		public void EnumServicesStatusExTest()
		{
			var l = EnumServicesStatusEx(hSvcMgr, ServiceTypes.SERVICE_DRIVER, SERVICE_STATE.SERVICE_ACTIVE);
			TestContext.WriteLine(string.Join("; ", l.Select(i => i.lpDisplayName)));
			Assert.That(l, Is.Not.Empty);
		}

		[Test]
		public void EnumServicesStatusTest()
		{
			var l = EnumServicesStatus(hSvcMgr);
			TestContext.WriteLine(string.Join("; ", l.Select(i => i.lpDisplayName)));
			Assert.That(l, Is.Not.Empty);
		}

		[Test]
		public void GetServiceDisplayNameTest()
		{
			var sb = new StringBuilder(1024, 1024);
			var sz = (uint)sb.Capacity;
			var ret = GetServiceDisplayName(hSvcMgr, svcName, sb, ref sz);
			TestContext.WriteLine(ret ? sb.ToString() : $"Error: {Win32Error.GetLastError()}");
			Assert.That(ret, Is.True);
			Assert.That(sb.ToString(), Is.EqualTo(svcKey));
		}

		[Test]
		public void GetServiceKeyNameTest()
		{
			var sb = new StringBuilder(1024, 1024);
			var sz = (uint)sb.Capacity;
			var ret = GetServiceKeyName(hSvcMgr, svcKey, sb, ref sz);
			TestContext.WriteLine(ret ? sb.ToString() : $"Error: {Win32Error.GetLastError()}");
			Assert.That(ret, Is.True);
			Assert.That(sb.ToString(), Is.EqualTo(svcName));
		}

		[Test]
		public void NotifyServiceStatusChangeTest()
		{
			var svcNotify = new SERVICE_NOTIFY_2
			{
				dwVersion = 2,
				pfnNotifyCallback = ChangeDelegate
			};
			Thread.BeginThreadAffinity();
			var ret = NotifyServiceStatusChange(hSvc, SERVICE_NOTIFY_FLAGS.SERVICE_NOTIFY_PAUSED | SERVICE_NOTIFY_FLAGS.SERVICE_NOTIFY_PAUSE_PENDING | SERVICE_NOTIFY_FLAGS.SERVICE_NOTIFY_CONTINUE_PENDING, ref svcNotify);
			if (ret.Failed) TestContext.WriteLine(ret);
			Assert.That(ret.Succeeded, Is.True);
			new Thread(ThreadExec).Start();
			Kernel32.SleepEx(10000, true);
			Thread.EndThreadAffinity();

			void ChangeDelegate(ref SERVICE_NOTIFY_2 pParameter)
			{
				TestContext.WriteLine(pParameter.ServiceStatus.dwCurrentState);
			}

			void ThreadExec()
			{
				using (var mgr = OpenSCManager(null, null, ScManagerAccessTypes.SC_MANAGER_ALL_ACCESS))
				{
					if (!mgr.IsInvalid)
					{
						using (var svc = OpenService(hSvcMgr, svcName, ServiceAccessTypes.SERVICE_ALL_ACCESS))
						{
							if (!svc.IsInvalid)
							{
								TestContext.WriteLine("Pausing...");
								ControlService(svc, ServiceControl.SERVICE_CONTROL_PAUSE, out _);
								Thread.Sleep(3000);
								TestContext.WriteLine("Continuing...");
								ControlService(svc, ServiceControl.SERVICE_CONTROL_CONTINUE, out _);
								Thread.Sleep(3000);
							}
						}
					}
				}
			}
		}

		[Test]
		public void OpenCloseSCManagerTest()
		{
			using (var scm = OpenSCManager(null, null, ScManagerAccessTypes.SC_MANAGER_CONNECT))
			{
				AssertHandleIsValid(scm);
			}
		}

		[Test]
		public void OpenCloseServiceTest()
		{
			//opens task scheduler service
			using (var service = OpenService(hSvcMgr, "Schedule", ServiceAccessTypes.SERVICE_QUERY_STATUS))
			{
				AssertHandleIsValid(service);
			}
		}

		[Test]
		public void QueryServiceStatusTest()
		{
			//query service status
			var ret = QueryServiceStatus(hSvc, out var i);
			TestContext.WriteLine(ret ? i.dwCurrentState.ToString() : $"Error: {Win32Error.GetLastError()}");
			Assert.That(ret, Is.True);
		}

		[Test]
		public void QueryServiceStatusExTest()
		{
			//query service status
			var status = QueryServiceStatusEx<SERVICE_STATUS_PROCESS>(hSvc, SC_STATUS_TYPE.SC_STATUS_PROCESS_INFO);

			Assert.That(status.dwServiceType, Is.EqualTo(ServiceTypes.SERVICE_WIN32_OWN_PROCESS | ServiceTypes.SERVICE_INTERACTIVE_PROCESS));
			Assert.That(status.dwServiceFlags, Is.EqualTo(0));
		}

		[Test]
		public void StartStopServiceTest()
		{
			//query service status
			var status = QueryServiceStatusEx<SERVICE_STATUS_PROCESS>(hSvc, SC_STATUS_TYPE.SC_STATUS_PROCESS_INFO);

			if (status.dwCurrentState == ServiceState.SERVICE_RUNNING)
			{
				var ret4 = StopService(hSvc, out var _);
				if (!ret4) Win32Error.ThrowLastError();

				WaitForServiceStatus(hSvc, ServiceState.SERVICE_STOPPED);

				var ret6 = StartService(hSvc);
				if (!ret6) Win32Error.ThrowLastError();
			}
			else
			{
				var ret4 = StartService(hSvc);
				if (!ret4) Win32Error.ThrowLastError();

				WaitForServiceStatus(hSvc, ServiceState.SERVICE_RUNNING);

				var ret6 = StopService(hSvc, out var _);
				if (!ret6) Win32Error.ThrowLastError();
			}
		}

		private static void AssertHandleIsValid(SafeSC_HANDLE handle)
		{
			if (handle.IsInvalid)
				Win32Error.ThrowLastError();

			Assert.That(handle.IsNull, Is.False);
			Assert.That(handle.IsClosed, Is.False);
			Assert.That(handle.IsInvalid, Is.False);
		}

		private static ServiceState GetState(SC_HANDLE handle) => QueryServiceStatus(handle, out var i) ? i.dwCurrentState : throw Win32Error.GetLastError().GetException();

		private static void WaitForServiceStatus(SafeSC_HANDLE service, ServiceState status)
		{
			//query service status again to check that it changed
			var tests = 0;

			while (tests < 40)
			{
				if (GetState(service) == status)
					break;

				Thread.Sleep(500);
				tests++;
			}

			if (tests >= 40)
				throw new TimeoutException($"Timed-out waiting for service status {status}");
		}
	}
}