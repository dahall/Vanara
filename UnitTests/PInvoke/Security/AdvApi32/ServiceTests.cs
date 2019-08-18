using NUnit.Framework;
using System;
using System.Linq;
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
			Assert.That(hSvcMgr, ResultIs.ValidHandle);
			hSvc = OpenService(hSvcMgr, svcName, ServiceAccessTypes.SERVICE_ALL_ACCESS);
			Assert.That(hSvc, ResultIs.ValidHandle);
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
			Assert.That(GetServiceKeyName(hSvcMgr, svcKey, sb, ref sz), ResultIs.Successful);
			TestContext.WriteLine(sb);
			Assert.That(sb.ToString(), Is.EqualTo(svcName));
		}

		[Test]
		public void NotifyServiceStatusChangeTest()
		{
			var cnt = 0;
			Thread.BeginThreadAffinity();
			var callback = new PFN_SC_NOTIFY_CALLBACK(ChangeDelegate);
			GC.KeepAlive(callback);
			var svcNotify = new SERVICE_NOTIFY_2
			{
				dwVersion = 2,
				pfnNotifyCallback = callback
			};
			GC.KeepAlive(svcNotify);
			//Assert.That(NotifyServiceStatusChange(hSvc, SERVICE_NOTIFY_FLAGS.SERVICE_NOTIFY_PAUSED | SERVICE_NOTIFY_FLAGS.SERVICE_NOTIFY_PAUSE_PENDING | SERVICE_NOTIFY_FLAGS.SERVICE_NOTIFY_CONTINUE_PENDING, svcNotify), ResultIs.Successful);
			var th = new Thread(ThreadExec);
			th.Start((SC_HANDLE)hSvc);
			while (th.IsAlive)
				Kernel32.SleepEx(100, true);
			Thread.EndThreadAffinity();
			//Assert.That(cnt, Is.EqualTo(3));

			void ChangeDelegate(in SERVICE_NOTIFY_2 pParameter)
			{
				cnt++;
				System.Diagnostics.Debug.WriteLine(pParameter.ServiceStatus.dwCurrentState);
			}

			void ThreadExec(object handle)
			{
				var svc = (SC_HANDLE)handle;
				System.Diagnostics.Debug.WriteLine("Pausing...");
				if (!ControlService(svc, ServiceControl.SERVICE_CONTROL_PAUSE, out _))
					System.Diagnostics.Debug.WriteLine($"Pausing failed: {Win32Error.GetLastError()}");
				WaitForServiceStatus(svc, ServiceState.SERVICE_PAUSED);
				System.Diagnostics.Debug.WriteLine("Continuing...");
				if (!ControlService(svc, ServiceControl.SERVICE_CONTROL_CONTINUE, out _))
					System.Diagnostics.Debug.WriteLine($"Pausing failed: {Win32Error.GetLastError()}");
				WaitForServiceStatus(svc, ServiceState.SERVICE_RUNNING);
			}
		}

		[Test]
		public void OpenCloseSCManagerTest()
		{
			using (var scm = OpenSCManager(null, null, ScManagerAccessTypes.SC_MANAGER_CONNECT))
			{
				Assert.That(scm, ResultIs.ValidHandle);
			}
		}

		[Test]
		public void OpenCloseServiceTest()
		{
			//opens task scheduler service
			using (var service = OpenService(hSvcMgr, "Schedule", ServiceAccessTypes.SERVICE_QUERY_STATUS))
			{
				Assert.That(service, ResultIs.ValidHandle);
			}
		}

		[Test]
		public void QueryServiceStatusExTest()
		{
			//query service status
			var status = QueryServiceStatusEx<SERVICE_STATUS_PROCESS>(hSvc, SC_STATUS_TYPE.SC_STATUS_PROCESS_INFO);

			Assert.That(status.dwServiceType, Is.EqualTo(ServiceTypes.SERVICE_WIN32));
			Assert.That(status.dwServiceFlags, Is.EqualTo(0));
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
		public void StartStopServiceTest()
		{
			using (var hSvcLocal = OpenService(hSvcMgr, "DsSvc", ServiceAccessTypes.SERVICE_ALL_ACCESS))
			{
				if (GetState(hSvcLocal) == ServiceState.SERVICE_RUNNING)
				{
					Assert.That(StopService(hSvcLocal, out var _), ResultIs.Successful);

					WaitForServiceStatus(hSvcLocal, ServiceState.SERVICE_STOPPED);

					Assert.That(StartService(hSvcLocal), ResultIs.Successful);
				}
				else
				{
					Assert.That(StartService(hSvcLocal), ResultIs.Successful);

					WaitForServiceStatus(hSvcLocal, ServiceState.SERVICE_RUNNING);

					Assert.That(StopService(hSvcLocal, out var _), ResultIs.Successful);
				}
			}
		}

		private static ServiceState GetState(SC_HANDLE handle) => QueryServiceStatus(handle, out var i) ? i.dwCurrentState : throw Win32Error.GetLastError().GetException();

		private static void WaitForServiceStatus(SC_HANDLE service, ServiceState status)
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