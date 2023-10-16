#define AVRT
using NUnit.Framework;
using System.Linq;
#if AVRT
using static Vanara.PInvoke.Avrt;
#endif
using static Vanara.PInvoke.CoreAudio;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests;

public partial class CoreAudioTests
{
	static readonly Guid AUDIO_EFFECT_TYPE_ACOUSTIC_ECHO_CANCELLATION = new("6f64adbe-8211-11e2-8c70-2c27d7f001fa");

	[Test]
	public void EnumDevices()
	{
		IMMDeviceEnumerator deviceEnumerator = new();
		IMMDeviceCollection? spDeviceCollection = deviceEnumerator.EnumAudioEndpoints(EDataFlow.eRender, DEVICE_STATE.DEVICE_STATE_ACTIVE);
		Assert.IsNotNull(spDeviceCollection);
		for (uint i = 0; i < spDeviceCollection!.GetCount(); i++)
		{
			spDeviceCollection.Item(i, out var device);
			Assert.IsNotNull(device);
			var properties = device!.OpenPropertyStore(STGM.STGM_READ);
			Assert.IsNotNull(properties);
			TestContext.WriteLine($"{i + 1}: {properties!.GetValue(PKEY_Device_FriendlyName)}");
		}
	}

	[Test]
	public void EchoCancellationTest()
	{
		IMMDeviceEnumerator deviceEnumerator = new();
		IMMDevice? device = deviceEnumerator.GetDefaultAudioEndpoint(EDataFlow.eCapture, ERole.eCommunications);
		IAudioClient2? audioClient = device?.Activate<IAudioClient2>(CLSCTX.CLSCTX_INPROC_SERVER);
		Assert.IsNotNull(audioClient);
		AudioClientProperties clientProperties = new() { cbSize = InteropExtensions.SizeOf<AudioClientProperties>(), eCategory = AUDIO_STREAM_CATEGORY.AudioCategory_Communications };
		audioClient!.SetClientProperties(clientProperties);
		audioClient.GetMixFormat(out var fmtMem).ThrowIfFailed();
		audioClient.Initialize(AUDCLNT_SHAREMODE.AUDCLNT_SHAREMODE_SHARED, AUDCLNT_STREAMFLAGS.AUDCLNT_STREAMFLAGS_EVENTCALLBACK, 10000000, 0, fmtMem).ThrowIfFailed();

		var audioEffectsManager = audioClient.GetService<IAudioEffectsManager>();
		Assert.IsNotNull(audioEffectsManager);
		var effects = audioEffectsManager!.GetAudioEffects();
		var ispresent = effects.Any(e => e.id == AUDIO_EFFECT_TYPE_ACOUSTIC_ECHO_CANCELLATION);
		TestContext.WriteLine($"Capture stream is {(ispresent ? "" : "not ")}echo cancelled.");

		string? deviceId = device?.GetId() ?? SafeCoTaskMemString.Null;
		TestContext.WriteLine($"Created communications stream on capture endpoint {deviceId}");
		var captureClient = audioClient.GetService<IAudioCaptureClient>();
		Assert.IsNotNull(captureClient);

		using var terminationEvent = CreateEvent(default, false, false);
		using var captureThread = CreateThread(default, default, p => {
#if AVRT
			uint mmcssTaskIndex = 0;
			using SafeHANDLE mmcssTaskHandle = AvSetMmThreadCharacteristics("Audio", ref mmcssTaskIndex);
#endif
			using var bufferComplete = CreateEvent(default, false, false);
			audioClient.SetEventHandle(bufferComplete);
			while (WaitForMultipleObjects(new[] { bufferComplete, terminationEvent }, false, INFINITE) != WAIT_STATUS.WAIT_OBJECT_0)
			{
				while (captureClient!.GetNextPacketSize(out var packetLen).Succeeded && packetLen > 0)
				{
					captureClient.GetBuffer(out var buffer, out var numFramesRead, out var flags, out _, out _).ThrowIfFailed();
					captureClient.ReleaseBuffer(numFramesRead);
				}
			}
			audioClient.Stop();
			return 0;
		}, default, default, out _);

		if (ispresent)
		{
			try
			{
				IAcousticEchoCancellationControl? aecControl = audioClient.GetService<IAcousticEchoCancellationControl>();
				aecControl?.SetEchoCancellationRenderEndpoint(null);
			}
			catch { }
		}
		Sleep(10000);
		terminationEvent.Set();
		WaitForSingleObject(captureThread, 1000);
	}
}