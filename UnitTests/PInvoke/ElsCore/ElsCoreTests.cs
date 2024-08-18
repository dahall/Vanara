using NUnit.Framework;
using NUnit.Framework.Internal;
using static Vanara.PInvoke.ElsCore;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class ElsCoreTests
{
	const string USER_TEXT = "Skip This is a simple sentence. \x0422\x0445\x0438\x0441 \x0438\x0441 \x0415\x043d\x0433\x043b\x0438\x0441\x0445.";
	const int USER_TEXT_SKIP = 5;

	[Test]
	public void AsyncTest()
	{
		// Using the Language Auto-Detection Guid to enumerate LAD only:
		using var pGuid = new PinnedObject(ELS_GUID_LANGUAGE_DETECTION);
		MAPPING_ENUM_OPTIONS enumOptions = new() { Size = Marshal.SizeOf(typeof(MAPPING_ENUM_OPTIONS)), pGuid = (IntPtr)pGuid };

		Assert.That(MappingGetServices(enumOptions, out var prgServices), ResultIs.Successful);
		Assert.That(prgServices.Count, Is.GreaterThan(0));

		using var SyncEvent = CreateEvent();
		Assert.That(SyncEvent.DangerousGetHandle(), Is.Not.EqualTo(IntPtr.Zero));

		var output = TestContext.Out;
		MAPPING_PROPERTY_BAG bag = new();
		MAPPING_OPTIONS options = new(RecognizeCallback, new SafeHGlobalStruct<IntPtr>(SyncEvent.DangerousGetHandle()));

		// MappingRecognizeText's dwIndex parameter specifies the first index inside the text from where the recognition should start. We
		// pass USER_TEXT_SKIP, thus skipping the "Skip " part of the input string.
		Assert.That(MappingRecognizeText(prgServices[0], USER_TEXT, USER_TEXT.Length, USER_TEXT_SKIP, options, ref bag), ResultIs.Successful);

		// We are using an event to synchronize our waiting for the call to end,
		// because some objects have to be valid till the end of the callback call:
		// - the input text
		// - the property bag
		// - the options
		// - the service
		Assert.That(WaitForSingleObject(SyncEvent, 1000), Is.EqualTo(WAIT_STATUS.WAIT_OBJECT_0));

		void RecognizeCallback(in MAPPING_PROPERTY_BAG pBag, IntPtr data, uint dwDataSize, HRESULT Result)
		{
			if (Result.Succeeded)
			{
				output.WriteLine(string.Join(',', pBag.rgResultRanges![0].pData.ToStringEnum(CharSet.Unicode)));
				MappingFreePropertyBag(pBag);
			}
			SetEvent((HEVENT)Marshal.ReadIntPtr(data));
		}
	}

	[Test]
	public void SyncTest()
	{
		// Using the Language Auto-Detection Guid to enumerate LAD only:
		using var pGuid = new PinnedObject(ELS_GUID_LANGUAGE_DETECTION);
		MAPPING_ENUM_OPTIONS enumOptions = new() { Size = Marshal.SizeOf(typeof(MAPPING_ENUM_OPTIONS)), pGuid = (IntPtr)pGuid };

		Assert.That(MappingGetServices(enumOptions, out var prgServices), ResultIs.Successful);
		Assert.That(prgServices.Count, Is.GreaterThan(0));

		MAPPING_PROPERTY_BAG bag = new();

		// MappingRecognizeText's dwIndex parameter specifies the first index inside the text from where the recognition should start. We
		// pass USER_TEXT_SKIP, thus skipping the "Skip " part of the input string.
		Assert.That(MappingRecognizeText(prgServices[0], USER_TEXT, USER_TEXT.Length, USER_TEXT_SKIP, default, ref bag), ResultIs.Successful);

		TestContext.WriteLine(string.Join(',', bag.rgResultRanges![0].pData.ToStringEnum(CharSet.Unicode)));
		MappingFreePropertyBag(bag);
	}
}