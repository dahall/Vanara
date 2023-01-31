using Microsoft.Win32;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.CoreAudio;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.PropSys;
using static Vanara.PInvoke.WinMm;

namespace Vanara.PInvoke.Tests;

public partial class CoreAudioTests
{
	private static readonly PROPERTYKEY PKEY_Device_FriendlyName = new PROPERTYKEY(new Guid(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0), 14);

	private static Dictionary<string, string> lookup = new Dictionary<string, string>();

	public static IEnumerable<IMMDevice> CreateIMMDeviceCollection(IMMDeviceEnumerator deviceEnumerator, EDataFlow direction = EDataFlow.eAll, DEVICE_STATE stateMasks = DEVICE_STATE.DEVICE_STATEMASK_ALL)
	{
		using var deviceCollection = ComReleaserFactory.Create(deviceEnumerator.EnumAudioEndpoints(direction, stateMasks));
		var deviceList = new List<IMMDevice>();
		var cnt = deviceCollection.Item.GetCount();
		if (cnt == 0) Assert.Inconclusive("No devices were found.");
		for (uint i = 0; i < cnt; i++)
		{
			deviceCollection.Item.Item(i, out var dev).ThrowIfFailed();
			deviceList.Add(dev);
		}
		return deviceList;
	}

	/// This test ensures that each device can use any valid COM interface returned from the Activate method. It checks to make sure
	/// each received interface is not null and an HRESULT of S_OK is returned. </summary>
	[Test]
	public void IMMDevice_Activate()
	{
		using var enumerator = ComReleaserFactory.Create(new IMMDeviceEnumerator());

		foreach (var d in CreateIMMDeviceCollection(enumerator.Item, EDataFlow.eAll, DEVICE_STATE.DEVICE_STATE_ACTIVE))
		{
			TestActivation<IAudioClient>();

			TestActivation<IAudioEndpointVolume>();

			TestActivation<IAudioMeterInformation>();

			TestActivation<IAudioSessionManager>();

			TestActivation<IAudioSessionManager2>();

			TestActivation<IDeviceTopology>();

			void TestActivation<T>() where T : class
			{
				Assert.That(d.Activate(typeof(T).GUID, CLSCTX.CLSCTX_INPROC_SERVER, default, out var objInterface), ResultIs.Successful);
				Assert.IsNotNull(objInterface as T);
				Marshal.ReleaseComObject(objInterface);
			}
		}
	}

	/// <summary>This test ensures that each device can get its ID. It also checks that the received ID is not null.</summary>
	[Test]
	public void IMMDevice_GetId()
	{
		using var enumerator = ComReleaserFactory.Create(new IMMDeviceEnumerator());

		foreach (var d in CreateIMMDeviceCollection(enumerator.Item))
		{
			string strId = null;
			Assert.That(() => strId = d.GetId(), Throws.Nothing);
			Assert.IsNotNull(strId);
			TestContext.WriteLine($"Id:{d.GetId()}, State:{d.GetState()}");
		}
	}

	/// <summary>
	/// This test ensures that each device can get its state. It also checks that the received state is a valid device state constant.
	/// </summary>
	[Test]
	public void IMMDevice_GetState()
	{
		using var enumerator = ComReleaserFactory.Create(new IMMDeviceEnumerator());

		foreach (var d in CreateIMMDeviceCollection(enumerator.Item))
		{
			DEVICE_STATE deviceState = 0;
			Assert.That(() => deviceState = d.GetState(), Throws.Nothing);
			Assert.That(Enum.IsDefined(typeof(DEVICE_STATE), deviceState), Is.True);
		}
	}

	/// <summary>
	/// This test ensures that each device can open a property store in READWRITE mode and that the received property store is non-null.
	/// It also checks that the property store object works correctly by making a call to get the property count.
	/// </summary>
	[Test]
	public void IMMDevice_OpenPropertyStore()
	{
		var tested = false;
		using var enumerator = ComReleaserFactory.Create(new IMMDeviceEnumerator());

		foreach (var d in CreateIMMDeviceCollection(enumerator.Item))
		{
			TestContext.WriteLine($"**** {GetDeviceName(d.GetId())} ****");

			// Open the property store
			IPropertyStore propertyStore = null;
			Assert.That(() => propertyStore = d.OpenPropertyStore(STGM.STGM_READ), Throws.Nothing);

			// Verify the count can be received.
			var propertyCount = uint.MaxValue;
			Assert.That(() => propertyCount = propertyStore.GetCount(), Throws.Nothing);
			Assert.AreNotEqual(uint.MaxValue, propertyCount, "The property count was not received.");

			// Get each property key, then get value.
			for (uint i = 0; i < propertyCount; i++)
			{
				PROPERTYKEY propertyKey = default;
				Assert.That(() => propertyKey = propertyStore.GetAt(i), Throws.Nothing);

				var value = GetPropertyValue(propertyStore, propertyKey);
				if (value != null)
					tested = true;
				TestContext.WriteLine($"{propertyKey.GetCanonicalName()}={value ?? "null"}");
			}
		}

		if (!tested) Assert.Inconclusive("No property values returned valid, non-null values.");
	}

	/// <summary>
	/// Tests that the individual render and capture device collections have a combined count equal to the total device count.
	/// </summary>
	[Test]
	public void IMMDeviceCollection_GetCount()
	{
		using var enumerator = ComReleaserFactory.Create(new IMMDeviceEnumerator());

		var allCaptureDevices = enumerator.Item.EnumAudioEndpoints(EDataFlow.eCapture, DEVICE_STATE.DEVICE_STATEMASK_ALL);
		var allRenderDevices = enumerator.Item.EnumAudioEndpoints(EDataFlow.eRender, DEVICE_STATE.DEVICE_STATEMASK_ALL);
		var allDevices = enumerator.Item.EnumAudioEndpoints(EDataFlow.eAll, DEVICE_STATE.DEVICE_STATEMASK_ALL);

		Assert.IsNotNull(allCaptureDevices, "The IMMDeviceCollection object is null.");
		Assert.IsNotNull(allRenderDevices, "The IMMDeviceCollection object is null.");
		Assert.IsNotNull(allDevices, "The IMMDeviceCollection object is null.");

		uint captureCount = uint.MaxValue, renderCount = uint.MaxValue, allCount = uint.MaxValue;

		Assert.That(() => captureCount = allCaptureDevices.GetCount(), Throws.Nothing);
		Assert.AreNotEqual(uint.MaxValue, captureCount, "Device count was not received.");

		Assert.That(() => renderCount = allRenderDevices.GetCount(), Throws.Nothing);
		Assert.AreNotEqual(uint.MaxValue, renderCount, "Device count was not received.");

		Assert.That(() => allCount = allDevices.GetCount(), Throws.Nothing);
		Assert.AreNotEqual(uint.MaxValue, allDevices, "Device count was not received.");

		Assert.AreEqual(allCount, captureCount + renderCount, "The combined number of capture and render devices is not equal to the total device count.");
	}

	/// <summary>Tests the all devices from index zero to [count - 1] can be received with S_OK HRESULT and each device is not null.</summary>
	[Test]
	public void IMMDeviceCollection_Item()
	{
		using var enumerator = ComReleaserFactory.Create(new IMMDeviceEnumerator());

		IMMDeviceCollection allDevices = null;
		Assert.That(() => allDevices = enumerator.Item.EnumAudioEndpoints(EDataFlow.eAll, DEVICE_STATE.DEVICE_STATEMASK_ALL), Throws.Nothing);
		Assert.IsNotNull(allDevices, "The IMMDeviceCollection object is null");

		uint count = 0;
		Assert.That(() => count = allDevices.GetCount(), Throws.Nothing);

		IMMDevice device;
		for (uint i = 0; i < count; i++)
		{
			Assert.That(allDevices.Item(i, out device), ResultIs.Successful);
		}
	}

	/// <summary>
	/// This test method does nothing. Testing of the EnumAudioEndpoints method is implicit by testing other aspects of the IMMDevice API.
	/// </summary>
	[Test]
	public void IMMDeviceEnumerator_EnumAudioEndpoints()
	{
		// This method is thouroughly tested through various other unit tests. The entry point for most other tests starts with calling EnumAudioEndpoints.
		// TODO: Add specific test for this.
	}

	/// <summary>
	/// Tests that the default audio endpoint for all combinations of data flow and roles can be created with S_OK HRESULT and that each
	/// device is not null.
	/// </summary>
	[Test]
	public void IMMDeviceEnumerator_GetDefaultAudioEndpoint()
	{
		IMMDevice device = null;
		using var enumerator = ComReleaserFactory.Create(new IMMDeviceEnumerator());

		// data flow - eAll (this should always produce HRESULT of E_INVALIDARG, which is 0x80070057)
		Assert.That(() => device = enumerator.Item.GetDefaultAudioEndpoint(EDataFlow.eAll, ERole.eCommunications), Throws.Exception);
		Assert.That(() => device = enumerator.Item.GetDefaultAudioEndpoint(EDataFlow.eAll, ERole.eConsole), Throws.Exception);
		Assert.That(() => device = enumerator.Item.GetDefaultAudioEndpoint(EDataFlow.eAll, ERole.eMultimedia), Throws.Exception);

		// data flow - eCapture
		Assert.That(() => device = enumerator.Item.GetDefaultAudioEndpoint(EDataFlow.eCapture, ERole.eCommunications), Throws.Nothing);
		Assert.IsNotNull(device);

		Assert.That(() => device = enumerator.Item.GetDefaultAudioEndpoint(EDataFlow.eCapture, ERole.eConsole), Throws.Nothing);
		Assert.IsNotNull(device);

		Assert.That(() => device = enumerator.Item.GetDefaultAudioEndpoint(EDataFlow.eCapture, ERole.eMultimedia), Throws.Nothing);
		Assert.IsNotNull(device);

		// data flow - eRender
		Assert.That(() => device = enumerator.Item.GetDefaultAudioEndpoint(EDataFlow.eRender, ERole.eCommunications), Throws.Nothing);
		Assert.IsNotNull(device);

		Assert.That(() => device = enumerator.Item.GetDefaultAudioEndpoint(EDataFlow.eRender, ERole.eConsole), Throws.Nothing);
		Assert.IsNotNull(device);

		Assert.That(() => device = enumerator.Item.GetDefaultAudioEndpoint(EDataFlow.eRender, ERole.eMultimedia), Throws.Nothing);
		Assert.IsNotNull(device);
	}

	/// <summary>Tests that the GetDevice method can get each audio device individually, by ID.</summary>
	[Test]
	public void IMMDeviceEnumerator_GetDevice()
	{
		using var enumerator = ComReleaserFactory.Create(new IMMDeviceEnumerator());

		foreach (var device in CreateIMMDeviceCollection(enumerator.Item))
		{
			// Get the device ID.
			string deviceId = null;
			Assert.That(() => deviceId = device.GetId(), Throws.Nothing);
			Assert.IsNotNull(deviceId, "The device string is null.");

			// Get the IMMDevice directly from the ID.
			IMMDevice deviceFromId = null;
			Assert.That(() => deviceFromId = enumerator.Item.GetDevice(deviceId), Throws.Nothing);
			Assert.IsNotNull(deviceFromId, "The IMMDevice object is null.");

			// Ensure the IDs of each device match.
			string deviceId2 = null;
			Assert.That(() => deviceId2 = deviceFromId.GetId(), Throws.Nothing);
			Assert.IsNotNull(deviceId2, "The device string is null.");

			Assert.AreEqual(deviceId, deviceId2, "The device IDs are not equal.");
		}
	}

	/// <summary>Tests that a valid client can be registered and an HRESULT of S_OK is returned.</summary>
	[Test]
	public void IMMDeviceEnumerator_RegisterEndpointNotificationCallback()
	{
		var cTok = new CancellationTokenSource();
		var task = Task.Run(() =>
		{
			using var enumerator = ComReleaserFactory.Create(new IMMDeviceEnumerator());
			var client = new MMDeviceNotifyClient(TestContext.Out);
			Assert.That(() => enumerator.Item.RegisterEndpointNotificationCallback(client), Throws.Nothing);
			while (!cTok.Token.IsCancellationRequested)
				Thread.Sleep(50);
			Assert.That(() => enumerator.Item.UnregisterEndpointNotificationCallback(client), Throws.Nothing);
		}, cTok.Token);

		try
		{
			// Make changes
			using var enumerator = ComReleaserFactory.Create(new IMMDeviceEnumerator());
			var activeEndpoints = CreateIMMDeviceCollection(enumerator.Item, EDataFlow.eAll, DEVICE_STATE.DEVICE_STATE_ACTIVE).ToList();
			using var ep = ComReleaserFactory.Create(enumerator.Item.GetDefaultAudioEndpoint(EDataFlow.eRender, ERole.eMultimedia));
			using var alt = ComReleaserFactory.Create(activeEndpoints.First(d => d.GetId() != ep.Item.GetId()));
			using var pc = ComReleaserFactory.Create(new CoreAudio.IPolicyConfig());
			Assert.That(pc.Item.SetDefaultEndpoint(alt.Item.GetId(), ERole.eMultimedia), ResultIs.Successful);
			Thread.Sleep(250);
			Assert.That(pc.Item.SetDefaultEndpoint(ep.Item.GetId(), ERole.eMultimedia), ResultIs.Successful);
			Thread.Sleep(250);

			// Registry hack to disable
			//Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\MMDevices\Audio\Render\{14b8ed7a-b84f-43b1-8de6-dc678cd96836}", "DeviceState", 0x2, RegistryValueKind.DWord);
			//Thread.Sleep(100);
			//Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\MMDevices\Audio\Render\{14b8ed7a-b84f-43b1-8de6-dc678cd96836}", "DeviceState", 0x1, RegistryValueKind.DWord);
			//Thread.Sleep(100);

			//using var vol = ComReleaserFactory.Create(ep.Item.Activate<IAudioEndpointVolume>());
			//var mute = vol.Item.GetMute();
			//vol.Item.SetMute(!mute, Guid.NewGuid());
			//Thread.Sleep(100);
			//Assert.That(vol.Item.GetMute(), Is.EqualTo(!mute));
			//vol.Item.SetMute(mute, Guid.NewGuid());
			//Thread.Sleep(100);
			//Assert.That(vol.Item.GetMute(), Is.EqualTo(mute));
		}
		finally
		{
			cTok.Cancel();
			task.Wait(1000);
		}
	}

	[Test]
	public void IMMEndpoint_GetDataFlow()
	{
		using var enumerator = ComReleaserFactory.Create(new IMMDeviceEnumerator());

		foreach (var device in CreateIMMDeviceCollection(enumerator.Item))
		{
			// Cast compiles to QueryInterface call.
			var endpoint = (IMMEndpoint)device;
			Assert.IsNotNull(endpoint);

			EDataFlow dataFlow = EDataFlow.eAll;
			Assert.That(() => dataFlow = endpoint.GetDataFlow(), Throws.Nothing);
			Assert.AreNotEqual(EDataFlow.eAll, dataFlow);
		}
	}

	private static string GetDeviceName(string devId)
	{
		if (lookup.TryGetValue(devId, out var val)) return val;
		using var pEnum = ComReleaserFactory.Create(new IMMDeviceEnumerator());
		using var pDev = ComReleaserFactory.Create(pEnum.Item.GetDevice(devId));
		using var pProps = ComReleaserFactory.Create(pDev.Item.OpenPropertyStore(STGM.STGM_READ));
		using var pv = new PROPVARIANT();
		pProps.Item.GetValue(PKEY_Device_FriendlyName, pv);
		lookup.Add(devId, pv.pwszVal);
		return pv.pwszVal;
	}

	private object GetPropertyValue(IPropertyStore propertyStore, PROPERTYKEY propertyKey)
	{
		try
		{
			using var pv = new PROPVARIANT();
			propertyStore.GetValue(propertyKey, pv);

			if (propertyKey == AudioPropertyKeys.PKEY_AudioEngine_DeviceFormat || propertyKey == AudioPropertyKeys.PKEY_AudioEngine_OEMFormat)
			{
				Assert.That(pv.vt, Is.EqualTo(VARTYPE.VT_BLOB));
				var format = pv.blob.pBlobData.ToStructure<WAVEFORMATEX>(pv.blob.cbSize);
				if (format.nChannels != 0 && format.nSamplesPerSec != 0 && format.wBitsPerSample != 0)
					Assert.AreEqual(format.nChannels * format.nSamplesPerSec * format.wBitsPerSample, format.nAvgBytesPerSec * 8, "The wave format was not valid.");
			}

			return pv.Value;
		}
		catch (Exception ex)
		{
			return "ERROR: " + ex.Message;
		}
	}

	[ComVisible(true), Guid("e5b6a8de-913e-4756-b1c7-7c73a92eeb3f")]
	public class MMDeviceNotifyClient : IMMNotificationClient
	{
		private readonly TextWriter textWriter;

		public MMDeviceNotifyClient(TextWriter writer) => textWriter = writer;

		HRESULT IMMNotificationClient.OnDefaultDeviceChanged(EDataFlow flow, ERole role, string pwstrDefaultDeviceId)
		{
			textWriter.WriteLine($"DefDevChg: flow={flow}, role={role}, dev={GetDeviceName(pwstrDefaultDeviceId)}");
			return HRESULT.S_OK;
		}

		HRESULT IMMNotificationClient.OnDeviceAdded(string pwstrDeviceId)
		{
			textWriter.WriteLine($"DevAdd: dev={GetDeviceName(pwstrDeviceId)}");
			return HRESULT.S_OK;
		}

		HRESULT IMMNotificationClient.OnDeviceRemoved(string pwstrDeviceId)
		{
			textWriter.WriteLine($"DevRmv: dev={GetDeviceName(pwstrDeviceId)}");
			return HRESULT.S_OK;
		}

		HRESULT IMMNotificationClient.OnDeviceStateChanged(string pwstrDeviceId, DEVICE_STATE dwNewState)
		{
			textWriter.WriteLine($"DevStateChg: dev={GetDeviceName(pwstrDeviceId)}, state={dwNewState}");
			return HRESULT.S_OK;
		}

		HRESULT IMMNotificationClient.OnPropertyValueChanged(string pwstrDeviceId, PROPERTYKEY key)
		{
			textWriter.WriteLine($"DefPropChg: dev={GetDeviceName(pwstrDeviceId)}, key={key}");
			return HRESULT.S_OK;
		}
	}
}