using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Threading;
using static Vanara.PInvoke.WinBio;
using TestContext = System.Console;

namespace Vanara.PInvoke.Tests;

[TestFixture]
[Apartment(ApartmentState.MTA)]
public class WinBioTests
{
	const uint compMsg = 0x8EEF;

	//[MTAThread]
	//public static void Main()
	//{
	//	bool setup = false;
	//	WinBioTests test = new();
	//	try
	//	{
	//		test._Setup();

	//		test.WinBioAsyncEnumBiometricUnitsCallbackTest();

	//		setup = true;
	//	}
	//	catch (Exception ex)
	//	{
	//		TestContext.WriteLine(ex.ToString());
	//	}
	//	finally
	//	{
	//		if (setup)
	//			test._TearDown();
	//	}
	//}

	WINBIO_SESSION_HANDLE sessionHandle;

	[OneTimeSetUp]
	public void _Setup()
	{
		WinBioOpenSession(WINBIO_BIOMETRIC_TYPE.WINBIO_TYPE_FINGERPRINT, // Service provider
			WINBIO_POOL_TYPE.WINBIO_POOL_SYSTEM, // Pool type
			WINBIO_SESSION_FLAGS.WINBIO_FLAG_RAW | WINBIO_SESSION_FLAGS.WINBIO_FLAG_DEFAULT, // Access: Capture raw data
			default, // Array of biometric unit IDs
			0, // Count of biometric unit IDs
			default, // Default database
			out sessionHandle).ThrowIfFailed(); // [out] Session handle
	}

	[OneTimeTearDown]
	public void _TearDown()
	{
		WinBioCloseSession(sessionHandle);
	}

	[Test]
	public void StructTest() => TestHelper.GetNestedStructSizes(typeof(Vanara.PInvoke.WinBio)).WriteValues();

	//[Test]
	public void WinBioAsyncEnumBiometricUnitsCallbackTest()
	{
		ManualResetEvent evt = new(false);
		var cbPtr = new PWINBIO_ASYNC_COMPLETION_CALLBACK(Callback);
		Assert.That(WinBioAsyncOpenFramework(WINBIO_ASYNC_NOTIFICATION_METHOD.WINBIO_ASYNC_NOTIFY_CALLBACK, default, default,
			Marshal.GetFunctionPointerForDelegate(cbPtr), default, false, out var hFramework), ResultIs.Successful);
		try
		{
			Assert.That(WinBioAsyncEnumBiometricUnits(hFramework, WINBIO_BIOMETRIC_TYPE.WINBIO_TYPE_FINGERPRINT), ResultIs.Successful);
			evt.WaitOne(5000);
		}
		finally
		{
			WinBioCloseFramework(hFramework);
		}

		void Callback(IntPtr pRes)
		{
			try
			{
				WINBIO_ASYNC_RESULT war = pRes.ToStructure<WINBIO_ASYNC_RESULT>();
				if (war.Operation == WINBIO_OPERATION_TYPE.WINBIO_OPERATION_ENUM_BIOMETRIC_UNITS)
				{
					foreach (var s in war.Parameters.EnumBiometricUnits.UnitSchemaArray)
						TestContext.WriteLine($"{s.UnitId} : {s.Model} : {s.Description}");
					evt.Set();
				}
				if (war.Operation == WINBIO_OPERATION_TYPE.WINBIO_OPERATION_CLOSE_FRAMEWORK)
					WinBioFree(pRes);
			}
			catch { }
		}
	}

	[Test]
	public void WinBioAsyncEnumBiometricUnitsTest()
	{
		ManualResetEvent evt = new(false);
		using var wnd = new MsgWnd(Callback);
		Assert.That(WinBioAsyncOpenFramework(WINBIO_ASYNC_NOTIFICATION_METHOD.WINBIO_ASYNC_NOTIFY_MESSAGE, wnd.MessageWindowHandle, compMsg, null, default, false, out var hFramework), ResultIs.Successful);
		try
		{
			Assert.That(WinBioAsyncEnumBiometricUnits(hFramework, WINBIO_BIOMETRIC_TYPE.WINBIO_TYPE_FINGERPRINT), ResultIs.Successful);
			Assert.That(evt.WaitOne(5000));
		}
		finally
		{
			WinBioCloseFramework(hFramework);
		}

		IntPtr Callback(HWND hwnd, uint msg, IntPtr wParam, IntPtr lParam)
		{
			try
			{
				WINBIO_ASYNC_RESULT war = lParam.ToStructure<WINBIO_ASYNC_RESULT>();
				switch (war.Operation)
				{
					case WINBIO_OPERATION_TYPE.WINBIO_OPERATION_ENUM_BIOMETRIC_UNITS:
						foreach (var s in war.Parameters.EnumBiometricUnits.UnitSchemaArray)
							TestContext.WriteLine($"{s.UnitId} : {s.Model} : {s.Description}");
						evt.Set();
						break;

					case WINBIO_OPERATION_TYPE.WINBIO_OPERATION_CLOSE_FRAMEWORK:
						WinBioFree(lParam);
						break;
				}
			}
			catch { }
			return default;
		}
	}

	[Test]
	public void WinBioAsyncEnumDatabasesTest()
	{
		ManualResetEvent evt = new(false);
		using var wnd = new MsgWnd(Callback);
		Assert.That(WinBioAsyncOpenFramework(WINBIO_ASYNC_NOTIFICATION_METHOD.WINBIO_ASYNC_NOTIFY_MESSAGE, wnd.MessageWindowHandle, compMsg, null, default, false, out var hFramework), ResultIs.Successful);
		try
		{
			Assert.That(WinBioAsyncEnumDatabases(hFramework, WINBIO_BIOMETRIC_TYPE.WINBIO_TYPE_FINGERPRINT), ResultIs.Successful);
			Assert.That(evt.WaitOne(5000));
		}
		finally
		{
			WinBioCloseFramework(hFramework);
		}

		IntPtr Callback(HWND hwnd, uint msg, IntPtr wParam, IntPtr lParam)
		{
			try
			{
				WINBIO_ASYNC_RESULT war = lParam.ToStructure<WINBIO_ASYNC_RESULT>();
				switch (war.Operation)
				{
					case WINBIO_OPERATION_TYPE.WINBIO_OPERATION_ENUM_DATABASES:
						foreach (var s in war.Parameters.EnumDatabases.StorageSchemaArray)
							TestContext.WriteLine($"{s.FilePath} : {s.Attributes}");
						evt.Set();
						break;

					case WINBIO_OPERATION_TYPE.WINBIO_OPERATION_CLOSE_FRAMEWORK:
						WinBioFree(lParam);
						break;
				}
			}
			catch { }
			return default;
		}
	}

	[Test]
	public void WinBioAsyncEnumServiceProvidersTest()
	{
		ManualResetEvent evt = new(false);
		using var wnd = new MsgWnd(Callback);
		Assert.That(WinBioAsyncOpenFramework(WINBIO_ASYNC_NOTIFICATION_METHOD.WINBIO_ASYNC_NOTIFY_MESSAGE, wnd.MessageWindowHandle, compMsg, null, default, false, out var hFramework), ResultIs.Successful);
		try
		{
			Assert.That(WinBioAsyncEnumServiceProviders(hFramework, WINBIO_BIOMETRIC_TYPE.WINBIO_TYPE_FINGERPRINT), ResultIs.Successful);
			Assert.That(evt.WaitOne(5000));
		}
		finally
		{
			WinBioCloseFramework(hFramework);
		}

		IntPtr Callback(HWND hwnd, uint msg, IntPtr wParam, IntPtr lParam)
		{
			try
			{
				WINBIO_ASYNC_RESULT war = lParam.ToStructure<WINBIO_ASYNC_RESULT>();
				switch (war.Operation)
				{
					case WINBIO_OPERATION_TYPE.WINBIO_OPERATION_ENUM_SERVICE_PROVIDERS:
						foreach (var s in war.Parameters.EnumServiceProviders.BspSchemaArray)
							TestContext.WriteLine($"{s.Vendor} : {s.Version} : {s.Description}");
						evt.Set();
						break;

					case WINBIO_OPERATION_TYPE.WINBIO_OPERATION_CLOSE_FRAMEWORK:
						WinBioFree(lParam);
						break;
				}
			}
			catch { }
			return default;
		}
	}

	//[Test]
	public void WinBioAsyncMonitorFrameworkChangesTest()
	{
		ManualResetEvent evt = new(false);
		using var wnd = new MsgWnd(Callback);
		Assert.That(WinBioAsyncOpenFramework(WINBIO_ASYNC_NOTIFICATION_METHOD.WINBIO_ASYNC_NOTIFY_MESSAGE, wnd.MessageWindowHandle, compMsg, null, default, false, out var hFramework), ResultIs.Successful);
		try
		{
			Assert.That(WinBioAsyncMonitorFrameworkChanges(hFramework, WINBIO_FRAMEWORK_CHANGE_TYPE.WINBIO_FRAMEWORK_CHANGE_UNIT), ResultIs.Successful);
			Assert.That(evt.WaitOne(5000));
		}
		finally
		{
			WinBioCloseFramework(hFramework);
		}

		IntPtr Callback(HWND hwnd, uint msg, IntPtr wParam, IntPtr lParam)
		{
			try
			{
				WINBIO_ASYNC_RESULT war = lParam.ToStructure<WINBIO_ASYNC_RESULT>();
				switch (war.Operation)
				{
					case WINBIO_OPERATION_TYPE.WINBIO_OPERATION_UNIT_ARRIVAL:
						TestContext.WriteLine($"Arrived");
						evt.Set();
						break;

					case WINBIO_OPERATION_TYPE.WINBIO_OPERATION_UNIT_REMOVAL:
						TestContext.WriteLine($"Removed");
						evt.Set();
						break;

					case WINBIO_OPERATION_TYPE.WINBIO_OPERATION_CLOSE_FRAMEWORK:
						WinBioFree(lParam);
						break;
				}
			}
			catch { }
			return default;
		}
	}

	//[Test]
	public void WinBioAsyncOpenFrameworkCallbackTest()
	{
		var cbPtr = new PWINBIO_ASYNC_COMPLETION_CALLBACK(Callback);
		Assert.That(WinBioAsyncOpenFramework(WINBIO_ASYNC_NOTIFICATION_METHOD.WINBIO_ASYNC_NOTIFY_CALLBACK, default, default,
			Marshal.GetFunctionPointerForDelegate(cbPtr), default, true, out var hFramework), ResultIs.Successful);
		Assert.That((uint)hFramework, Is.Zero);

		static void Callback(IntPtr AsyncResult)
		{
		}
	}

	[Test]
	public void WinBioAsyncOpenFrameworkHwnd2Test()
	{
		using var wnd = new MsgWnd();
		Assert.That(WinBioAsyncOpenFramework(WINBIO_ASYNC_NOTIFICATION_METHOD.WINBIO_ASYNC_NOTIFY_MESSAGE, wnd.MessageWindowHandle, compMsg, null, default, false, out var hFramework), ResultIs.Successful);
		try
		{
			Assert.That((uint)hFramework, Is.Not.Zero);
		}
		finally
		{
			WinBioCloseFramework(hFramework);
		}
	}

	[Test]
	public void WinBioAsyncOpenFrameworkHwndTest()
	{
		using var wnd = new MsgWnd();
		Assert.That(WinBioAsyncOpenFramework(WINBIO_ASYNC_NOTIFICATION_METHOD.WINBIO_ASYNC_NOTIFY_MESSAGE, wnd.MessageWindowHandle, compMsg, null, default, true, out var hFramework), ResultIs.Successful);
		Assert.That((uint)hFramework, Is.Zero);
	}

	//[Test]
	public void WinBioAsyncOpenSessionTest()
	{
		Assert.That(WinBioAsyncOpenSession(WINBIO_BIOMETRIC_TYPE.WINBIO_TYPE_FINGERPRINT,
			WINBIO_POOL_TYPE.WINBIO_POOL_SYSTEM,
			WINBIO_SESSION_FLAGS.WINBIO_FLAG_RAW,
			NotificationMethod: WINBIO_ASYNC_NOTIFICATION_METHOD.WINBIO_ASYNC_NOTIFY_CALLBACK,
			DatabaseId: WINBIO_DB_DEFAULT, CallbackRoutine: Callback, AsynchronousOpen: true,
			SessionHandle: out var hSess), ResultIs.Successful);
		try
		{

		}
		finally
		{
			WinBioCloseSession(hSess);
		}

		static void Callback(IntPtr AsyncResult)
		{
			using var str = new SafeWinBioStruct<WINBIO_ASYNC_RESULT>(AsyncResult, true);
			str.Value.WriteValues();
		}
	}

	//[Test]
	public void WinBioCaptureSampleTest()
	{
		// Capture a biometric sample.
		var hr = WinBioCaptureSample(sessionHandle,
			WINBIO_BIR_PURPOSE.WINBIO_NO_PURPOSE_AVAILABLE,
			WINBIO_BIR_DATA_FLAGS.WINBIO_DATA_FLAG_RAW,
			out _,
			out var sample,
			out var sampleSize,
			out _);
		Assert.That(hr, ResultIs.Successful);
		Assert.That(!sample.IsInvalid);

		var value = sample.ToStructure<WINBIO_BIR>(sampleSize);
		WINBIO_BIR_HEADER BirHeader = sample.ToStructure<WINBIO_BIR_HEADER>(sampleSize, value.HeaderBlock.Offset);
		BirHeader.WriteValues();
		WINBIO_BDB_ANSI_381_HEADER AnsiBdbHeader = sample.ToStructure<WINBIO_BDB_ANSI_381_HEADER>(sampleSize, value.StandardDataBlock.Offset);
		AnsiBdbHeader.WriteValues();
		WINBIO_BDB_ANSI_381_RECORD AnsiBdbRecord = sample.ToStructure<WINBIO_BDB_ANSI_381_RECORD>(sampleSize, value.StandardDataBlock.Offset + (uint)Marshal.SizeOf(typeof(WINBIO_BDB_ANSI_381_HEADER)));
		AnsiBdbRecord.WriteValues();

		//int width = AnsiBdbRecord.HorizontalLineLength; // Width of image in pixels
		//int height = AnsiBdbRecord.VerticalLineLength; // Height of image in pixels

		//IntPtr firstPixel = ((IntPtr)sample).Offset(sample.Value.StandardDataBlock.Offset + Marshal.SizeOf(typeof(WINBIO_BDB_ANSI_381_HEADER)) + Marshal.SizeOf(typeof(WINBIO_BDB_ANSI_381_RECORD)));

		//Bitmap bmp = new Bitmap(width, height, 3 * width, System.Drawing.Imaging.PixelFormat.Format24bppRgb, firstPixel);
		//using var tmp = new TempFile(null);
		//bmp.Save(tmp.FullName);
	}

	[Test]
	public void WinBioEnumBiometricUnitsTest()
	{
		Assert.That(WinBioEnumBiometricUnits(WINBIO_BIOMETRIC_TYPE.WINBIO_TYPE_FINGERPRINT, out var schemas), ResultIs.Successful);
		schemas.WriteValues();
	}

	[Test]
	public void WinBioEnumDatabasesTest()
	{
		Assert.That(WinBioEnumDatabases(WINBIO_BIOMETRIC_TYPE.WINBIO_TYPE_FINGERPRINT, out var schemas), ResultIs.Successful);
		schemas.WriteValues();
	}

	[Test]
	public void WinBioEnumEnrollmentsTest()
	{
		Assert.That(WinBioIdentify(sessionHandle, out var unitId, out var id, out _, out _), ResultIs.Successful);
		Assert.That(WinBioEnumEnrollments(sessionHandle, unitId, id, out var subs), ResultIs.Successful);
		subs.WriteValues();
	}

	[Test]
	public void WinBioEnumServiceProvidersTest()
	{
		Assert.That(WinBioEnumServiceProviders(WINBIO_BIOMETRIC_TYPE.WINBIO_TYPE_FINGERPRINT, out var schemas), ResultIs.Successful);
		schemas.WriteValues();
	}

	[Test]
	public void WinBioGetLogonSettingTest()
	{
		WinBioGetLogonSetting(out var val, out var src);
		TestContext.Write($"{val}:{src}");
	}

	[Test]
	public void WinBioGetPropertyTest()
	{
		Assert.That(WinBioLocateSensor(sessionHandle, out var unitId), ResultIs.Successful);
		Assert.That(WinBioGetProperty(sessionHandle, WINBIO_PROPERTY_TYPE.WINBIO_PROPERTY_TYPE_UNIT, WINBIO_PROPERTY_ID.WINBIO_PROPERTY_EXTENDED_SENSOR_INFO,
			unitId, default, WINBIO_BIOMETRIC_SUBTYPE.WINBIO_SUBTYPE_NO_INFORMATION, out _, out var propSize), ResultIs.Successful);

		Assert.That((long)propSize, Is.GreaterThan(0L));
	}

	[Test]
	public void WinBioIdentifyTest()
	{
		Assert.That(WinBioIdentify(sessionHandle, out var unitId, out var id, out var sub, out var det), ResultIs.Successful);
		TestContext.Write($"Session={sessionHandle}, UnitId={unitId}, Id={id.Type}, Sub={sub}, RejDet={det}");
	}

	[Test]
	public void WinBioIdentifyWithCallbackTest()
	{
		Assert.That(WinBioIdentifyWithCallback(sessionHandle, Callback), ResultIs.Successful);

		static void Callback(IntPtr IdentifyCallbackContext, HRESULT OperationStatus, uint UnitId, in WINBIO_IDENTITY Identity, WINBIO_BIOMETRIC_SUBTYPE SubFactor, WINBIO_REJECT_DETAIL RejectDetail)
		{
			Assert.That(UnitId, Is.Not.Zero);
			TestContext.WriteLine($"{UnitId} : {SubFactor} : {RejectDetail}");
			Identity.WriteValues();
		}
	}

	private class MsgWnd : SystemEventHandler
	{
		private readonly User32.WindowProc? callback;

		public MsgWnd(User32.WindowProc? callback = null) => this.callback = callback;

		protected override bool MessageFilter(HWND hwnd, uint msg, IntPtr wParam, IntPtr lParam, out IntPtr lReturn)
		{
			if (msg == compMsg)
			{
				lReturn = callback?.Invoke(hwnd, msg, wParam, lParam) ?? default;
				return true;
			}
			lReturn = default;
			return false;
		}
	}
}