using NUnit.Framework;
using System.Linq;
using System.Threading;
using static Vanara.PInvoke.AdvApi32;

namespace Vanara.PInvoke.Tests;

[TestFixture()]
public class WinSvcTests
{
	private const string svcKey = "Windows Management Instrumentation";
	private const string svcName = "Winmgmt";
	private SafeSC_HANDLE? hSvc;
	private SafeSC_HANDLE? hSvcMgr;

	[OneTimeSetUp]
	public void _Setup()
	{
		hSvcMgr = OpenSCManager(null, null, ScManagerAccessTypes.SC_MANAGER_ALL_ACCESS);
		Assert.That(hSvcMgr!, ResultIs.ValidHandle);
		hSvc = OpenService(hSvcMgr!, svcName, ServiceAccessTypes.SERVICE_ALL_ACCESS);
		Assert.That(hSvc!, ResultIs.ValidHandle);
	}

	[OneTimeTearDown]
	public void _TearDown()
	{
		hSvc?.Dispose();
		hSvcMgr?.Dispose();
	}

	[Test]
	public void ChangeAndQueryServiceConfig2Test()
	{
		Assert.That(QueryServiceConfig2(hSvc!, ServiceConfigOption.SERVICE_CONFIG_DESCRIPTION, out SERVICE_DESCRIPTION sd), ResultIs.Successful);
		Assert.That(ChangeServiceConfig2(hSvc!, ServiceConfigOption.SERVICE_CONFIG_DESCRIPTION, sd), ResultIs.Successful);
		Thread.Sleep(10000);
	}

	[Test]
	public void ChangeAndQueryServiceConfigTest()
	{
		var st = GetStartType();
		Assert.That(ChangeServiceConfig(hSvc!, ServiceTypes.SERVICE_NO_CHANGE, ServiceStartType.SERVICE_DISABLED, ServiceErrorControlType.SERVICE_NO_CHANGE), ResultIs.Successful);
		Thread.Sleep(10000);

		Assert.That(GetStartType(), Is.EqualTo(ServiceStartType.SERVICE_DISABLED));
		Assert.That(ChangeServiceConfig(hSvc!, ServiceTypes.SERVICE_NO_CHANGE, st, ServiceErrorControlType.SERVICE_NO_CHANGE), ResultIs.Successful);
		Assert.That(GetStartType(), Is.EqualTo(st));

		ServiceStartType GetStartType()
		{
			using var info = new SafeHGlobalHandle(1024);
			Assert.That(QueryServiceConfig(hSvc!, info, info.Size, out var _), ResultIs.Successful);
			var qsc = info.ToStructure<QUERY_SERVICE_CONFIG>();
			return qsc.dwStartType;
		}
	}

	[Test]
	public void ControlServiceExTest()
	{
		var reason = new SERVICE_CONTROL_STATUS_REASON_PARAMS();
		Assert.That(ControlServiceEx(hSvc!, ServiceControl.SERVICE_CONTROL_PAUSE, ServiceInfoLevels.SERVICE_CONTROL_STATUS_REASON_INFO, ref reason), ResultIs.Successful);
		Thread.Sleep((int)reason.serviceStatus.dwWaitHint);
		Assert.That(GetState(hSvc!), Is.EqualTo(ServiceState.SERVICE_PAUSED).Or.EqualTo(ServiceState.SERVICE_PAUSE_PENDING));
		Assert.That(ControlServiceEx(hSvc!, ServiceControl.SERVICE_CONTROL_CONTINUE, ServiceInfoLevels.SERVICE_CONTROL_STATUS_REASON_INFO, ref reason), ResultIs.Successful);
		Thread.Sleep((int)reason.serviceStatus.dwWaitHint);
		Assert.That(GetState(hSvc!), Is.EqualTo(ServiceState.SERVICE_RUNNING));
	}

	[Test]
	public void ControlServiceTest()
	{
		Assert.That(ControlService(hSvc!, ServiceControl.SERVICE_CONTROL_PAUSE, out var status), ResultIs.Successful);
		Thread.Sleep((int)status.dwWaitHint);
		Assert.That(GetState(hSvc!), Is.EqualTo(ServiceState.SERVICE_PAUSED).Or.EqualTo(ServiceState.SERVICE_PAUSE_PENDING));
		Assert.That(ControlService(hSvc!, ServiceControl.SERVICE_CONTROL_CONTINUE, out status), ResultIs.Successful);
		Thread.Sleep((int)status.dwWaitHint);
		Assert.That(GetState(hSvc!), Is.EqualTo(ServiceState.SERVICE_RUNNING));
	}

	[Test]
	public void CreateDeleteServiceTest()
	{
		var access = (uint)ServiceAccessRights.SERVICE_ALL_ACCESS;
		const string path = @"C:\Temp\DummyWindowsService.exe";
		SafeSC_HANDLE hMySvc;
		Assert.That(hMySvc = CreateService(hSvcMgr!, "Dummy", "Dummy service", access, ServiceTypes.SERVICE_USER_OWN_PROCESS, ServiceStartType.SERVICE_DEMAND_START,
			ServiceErrorControlType.SERVICE_ERROR_NORMAL, path), ResultIs.ValidHandle);
		using (hMySvc)
			Assert.That(DeleteService(hMySvc), ResultIs.Successful);
	}

	[Test]
	public void EnumDependentServicesTest()
	{
		var l = EnumDependentServices(hSvc!);
		TestContext.WriteLine(string.Join("; ", l.Select(i => i.lpDisplayName)));
		Assert.That(l, Is.Not.Empty);
	}

	[Test]
	public void EnumServicesStatusExTest()
	{
		var l = EnumServicesStatusEx(hSvcMgr!); //, ServiceTypes.SERVICE_DRIVER, SERVICE_STATE.SERVICE_ACTIVE);
		TestContext.WriteLine(string.Join("; ", l.Select(i => i.lpDisplayName)));
		Assert.That(l, Is.Not.Empty);
	}

	[Test]
	public void EnumServicesStatusTest()
	{
		var l = EnumServicesStatus(hSvcMgr!);
		TestContext.WriteLine(string.Join("; ", l.Select(i => i.lpDisplayName)));
		Assert.That(l, Is.Not.Empty);
	}

	[Test]
	public void GetServiceDisplayNameTest()
	{
		var sb = new StringBuilder(1024, 1024);
		var sz = (uint)sb.Capacity;
		Assert.That(GetServiceDisplayName(hSvcMgr!, svcName, sb, ref sz), ResultIs.Successful);
		Assert.That(sb.ToString(), Is.EqualTo(svcKey));
	}

	[Test]
	public void GetServiceKeyNameTest()
	{
		var sb = new StringBuilder(1024, 1024);
		var sz = (uint)sb.Capacity;
		Assert.That(GetServiceKeyName(hSvcMgr!, svcKey, sb, ref sz), ResultIs.Successful);
		TestContext.WriteLine(sb);
		Assert.That(sb.ToString(), Is.EqualTo(svcName));
	}

	[Test]
	public void LockServiceDatabaseTest()
	{
		SC_LOCK hLock;
		Assert.That(hLock = LockServiceDatabase(hSvcMgr!), ResultIs.ValidHandle);
		Assert.That(UnlockServiceDatabase(hLock), ResultIs.Successful);
	}

	[Test]
	public void NotifyServiceStatusChangeTest()
	{
		var cnt = 0;
		ManualResetEvent evt;
		Thread.BeginThreadAffinity();
		try
		{
			PFN_SC_NOTIFY_CALLBACK callback = ChangeDelegate;
			var svcNotify = new SERVICE_NOTIFY_2
			{
				dwVersion = 2,
				pfnNotifyCallback = Marshal.GetFunctionPointerForDelegate(callback),
			};
			using (evt = new ManualResetEvent(false))
			using (var pNotify = new PinnedObject(svcNotify))
			{
				Assert.That(NotifyServiceStatusChange(hSvc!, SERVICE_NOTIFY_FLAGS.SERVICE_NOTIFY_PAUSED | SERVICE_NOTIFY_FLAGS.SERVICE_NOTIFY_PAUSE_PENDING | SERVICE_NOTIFY_FLAGS.SERVICE_NOTIFY_CONTINUE_PENDING, pNotify), ResultIs.Successful);
				var th = new Thread(ThreadExec);
				th.Start((SC_HANDLE)hSvc!);
				while (!evt.WaitOne(5)) ;
				Assert.That(cnt, Is.GreaterThan(0));
			}
		}
		finally
		{
			Thread.EndThreadAffinity();
		}

		void ChangeDelegate(IntPtr pParameter)
		{
			System.Diagnostics.Debug.WriteLine(pParameter.ToStructure<SERVICE_NOTIFY_2>().ServiceStatus.dwCurrentState);
			cnt++;
		}

		void ThreadExec(object? handle)
		{
			var svc = (SC_HANDLE)handle!;
			System.Diagnostics.Debug.WriteLine("Pausing...");
			if (!ControlService(svc, ServiceControl.SERVICE_CONTROL_PAUSE, out _))
				System.Diagnostics.Debug.WriteLine($"Pausing failed: {Win32Error.GetLastError()}");
			WaitForServiceStatus(svc, ServiceState.SERVICE_PAUSED);
			System.Diagnostics.Debug.WriteLine("Continuing...");
			if (!ControlService(svc, ServiceControl.SERVICE_CONTROL_CONTINUE, out _))
				System.Diagnostics.Debug.WriteLine($"Pausing failed: {Win32Error.GetLastError()}");
			WaitForServiceStatus(svc, ServiceState.SERVICE_RUNNING);
			System.Diagnostics.Debug.WriteLine("Running...");
			evt.Set();
		}
	}

	[Test]
	public void OpenCloseSCManagerTest()
	{
		using var scm = OpenSCManager(null, null, ScManagerAccessTypes.SC_MANAGER_CONNECT);
		Assert.That(scm, ResultIs.ValidHandle);
	}

	[Test]
	public void OpenCloseServiceTest()
	{
		//opens task scheduler service
		using var service = OpenService(hSvcMgr!, "Schedule", ServiceAccessTypes.SERVICE_QUERY_STATUS);
		Assert.That(service, ResultIs.ValidHandle);
	}

	[Test()]
	public void QueryServiceConfig2Test()
	{
		Assert.That(QueryServiceConfig2(hSvc!, ServiceConfigOption.SERVICE_CONFIG_DESCRIPTION, out SERVICE_DESCRIPTION sd), ResultIs.Successful);
		Assert.That(sd.lpDescription, Is.Not.Null);
		TestContext.WriteLine(sd.lpDescription);
	}

	[Test]
	public void QueryServiceStatusExTest()
	{
		//query service status
		var status = QueryServiceStatusEx<SERVICE_STATUS_PROCESS>(hSvc!, SC_STATUS_TYPE.SC_STATUS_PROCESS_INFO);

		Assert.That(status.dwServiceType, Is.EqualTo(ServiceTypes.SERVICE_WIN32));
		Assert.That(status.dwServiceFlags, Is.EqualTo(0));
		status.WriteValues();
	}

	[Test]
	public void QueryServiceStatusTest()
	{
		Assert.That(QueryServiceStatus(hSvc!, out var i), ResultIs.Successful);
		i.WriteValues();
	}

	[Test]
	public void QuerySetServiceObjectSecurityTest()
	{
		using var pSD = new SafePSECURITY_DESCRIPTOR(1024);
		Assert.That(QueryServiceObjectSecurity(hSvc!, SECURITY_INFORMATION.DACL_SECURITY_INFORMATION, pSD, pSD.Size, out var req), ResultIs.Successful);
		Assert.That(SetServiceObjectSecurity(hSvc!, SECURITY_INFORMATION.DACL_SECURITY_INFORMATION, pSD), ResultIs.Successful);
	}

	// [Test] These functions can only be called from within a service executable
	public void RegisterQueryBitsServiceCtrlHandlerTest()
	{
		SERVICE_STATUS_HANDLE hSt;
		Assert.That(hSt = RegisterServiceCtrlHandler(svcName, HandlerProc), ResultIs.ValidHandle);
		Assert.That(SetServiceBits(hSt, 3, true, true), ResultIs.Successful);
		Assert.That(QueryServiceDynamicInformation(hSt, SERVICE_DYNAMIC_INFORMATION_LEVEL_START_REASON, out var info), ResultIs.Successful);
		using (info)
			TestContext.Write(info.ToStructure<SERVICE_START_REASON>().dwReason);

		static void HandlerProc(ServiceControl dwControl)
		{
		}
	}

	// [Test] These functions can only be called from within a service executable
	public void RegisterServiceCtrlHandlerExTest()
	{
		SERVICE_STATUS_HANDLE hSt;
		Assert.That(hSt = RegisterServiceCtrlHandlerEx(svcName, HandlerProc, default), ResultIs.ValidHandle);
		var hServStatus = new SERVICE_STATUS
		{
			dwServiceType = ServiceTypes.SERVICE_WIN32_OWN_PROCESS,
			dwCurrentState = ServiceState.SERVICE_START_PENDING,
			dwControlsAccepted = ServiceAcceptedControlCodes.SERVICE_ACCEPT_STOP | ServiceAcceptedControlCodes.SERVICE_ACCEPT_SHUTDOWN | ServiceAcceptedControlCodes.SERVICE_ACCEPT_PAUSE_CONTINUE,
			dwWin32ExitCode = Win32Error.ERROR_SERVICE_SPECIFIC_ERROR,
			dwWaitHint = 2 * 100
		};
		Assert.That(SetServiceStatus(hSt, hServStatus), ResultIs.Successful);

		static Win32Error HandlerProc(ServiceControl dwControl, uint dwEventType, IntPtr lpEventData, IntPtr lpContext) => Win32Error.ERROR_SUCCESS;
	}

	// [Test] These functions can only be called from within a service executable
	public void StartServiceCtrlDispatcherTest()
	{
		var dispatchTable = new[]
		{
			new SERVICE_TABLE_ENTRY("Dummy", DummyProc),
			new SERVICE_TABLE_ENTRY()
		};
		Assert.That(StartServiceCtrlDispatcher(dispatchTable), ResultIs.Successful);

		static void DummyProc(uint dwNumServicesArgs, string[] lpServiceArgVectors) => throw new NotImplementedException();
	}

	[Test]
	public void StartStopServiceTest()
	{
		using var hSvcLocal = OpenService(hSvcMgr!, "DsSvc", ServiceAccessTypes.SERVICE_ALL_ACCESS);
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

	private static ServiceState GetState(SC_HANDLE handle) => QueryServiceStatus(handle, out var i) ? i.dwCurrentState : throw Win32Error.GetLastError().GetException()!;

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