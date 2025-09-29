using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Collections.Generic;
using System.Linq;
using static Vanara.PInvoke.Hid;
using static Vanara.PInvoke.Kernel32;
using static Vanara.PInvoke.SetupAPI;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class HidTests
{
	string? devicePath = null;
	SafeHFILE hDeviceObject = SafeHFILE.Null;

	[OneTimeSetUp]
	public void _Setup()
	{
		HidD_GetHidGuid(out var hidGuid);
		using SafeHDEVINFO hardwareDeviceInfo = SetupDiGetClassDevs(hidGuid, default, default, DIGCF.DIGCF_PRESENT | DIGCF.DIGCF_DEVICEINTERFACE);
		var idid = SetupDiEnumDeviceInterfaces(hardwareDeviceInfo, hidGuid).First();
		if (SetupDiGetDeviceInterfaceDetail(hardwareDeviceInfo, idid, out devicePath, out _))
			hDeviceObject = CreateFile(devicePath!, FileAccess.GENERIC_READ | FileAccess.GENERIC_WRITE, FILE_SHARE.FILE_SHARE_READ | FILE_SHARE.FILE_SHARE_WRITE, null, CreationOption.OPEN_EXISTING, 0);
	}

	[OneTimeTearDown]
	public void _TearDown()
	{
		hDeviceObject.Dispose();
	}

	[Test]
	public void Test()
	{
		HidD_GetHidGuid(out var hidGuid);
		using var hardwareDeviceInfo = SetupDiGetClassDevs(hidGuid, default, default, DIGCF.DIGCF_PRESENT | DIGCF.DIGCF_DEVICEINTERFACE);
		Assert.That(hardwareDeviceInfo, ResultIs.ValidHandle);
		var HidDevices = SetupDiEnumDeviceInterfaces(hardwareDeviceInfo, hidGuid).
			Select(GetDev).ToList();

		HID_DEVICE GetDev(SP_DEVICE_INTERFACE_DATA did)
		{
			if (SetupDiGetDeviceInterfaceDetail(hardwareDeviceInfo, did, out var path, out var data))
			{
				if (!OpenHidDevice(path!, false, false, false, false, out HID_DEVICE hidDeviceInst))
					hidDeviceInst = new() { DevicePath = path };
				return hidDeviceInst;
			}
			throw Win32Error.GetExceptionForLastError()!;
		}
	}

	[Test]
	public void GetHidDStringsTest()
	{
		StringBuilder sb = new(2048);
		uint sz = (uint)sb.Capacity;
		Assert.That(HidD_GetManufacturerString(hDeviceObject, sb, sz), ResultIs.Successful);
		TestContext.WriteLine("Manufacturer: " + sb.ToString());
		sb.Clear();
		Assert.That(HidD_GetProductString(hDeviceObject, sb, sz), ResultIs.Successful);
		TestContext.WriteLine("Product: " + sb.ToString());
		sb.Clear();
		Assert.That(HidD_GetSerialNumberString(hDeviceObject, sb, sz), ResultIs.Successful);
		TestContext.WriteLine("Serial Number: " + sb.ToString());
	}

	[Test]
	public void HidP_GetExtendedAttributesTest()
	{
		Assert.That(HidD_GetPreparsedData(hDeviceObject, out var ppd), ResultIs.Successful);
		using SafeCoTaskMemStruct<HIDP_EXTENDED_ATTRIBUTES> attrs = new();
		uint l = attrs.Size;
		var err = HidP_GetExtendedAttributes(HIDP_REPORT_TYPE.HidP_Input, 0, ppd, attrs, ref l);
		if (err == NTStatus.HIDP_STATUS_BUFFER_TOO_SMALL)
		{
			attrs.Size = l;
			err = HidP_GetExtendedAttributes(HIDP_REPORT_TYPE.HidP_Input, 0, ppd, attrs, ref l);
		}
		Assert.That(err, ResultIs.Successful);
		attrs.Value.WriteValues();
	}

	[Test]
	public void HidP_GetLinkCollectionNodesTest()
	{
		Assert.That(HidD_GetPreparsedData(hDeviceObject, out var ppd), ResultIs.Successful);
		uint l = 0;
		Assert.That(HidP_GetLinkCollectionNodes([], ref l, ppd), ResultIs.Failure);
		Assert.That(l, Is.GreaterThan(0));
		var nodes = new HIDP_LINK_COLLECTION_NODE[l];
		Assert.That(HidP_GetLinkCollectionNodes(nodes, ref l, ppd), ResultIs.Successful);
		nodes.WriteValues();
	}

	/*++
	RoutineDescription:
		Given the HardwareDeviceInfo, representing a handle to the plug and
		play information, and deviceInfoData, representing a specific hid device,
		open that device and fill in all the relivant information in the given
		HID_DEVICE structure.

		return if the open and initialization was successfull or not.

	--*/
	static bool OpenHidDevice(string DevicePath, bool HasReadAccess, bool HasWriteAccess, bool IsOverlapped, bool IsExclusive, out HID_DEVICE HidDevice)
	{
		FileAccess accessFlags = 0;
		FILE_SHARE sharingFlags = 0;
		bool bRet = false;

		HidDevice = new() { HidDevice = SafeHFILE.Null };

		if (default == DevicePath)
		{
			goto Done;
		}

		HidDevice.DevicePath = DevicePath;

		if (HasReadAccess)
		{
			accessFlags |= FileAccess.GENERIC_READ;
		}

		if (HasWriteAccess)
		{
			accessFlags |= FileAccess.GENERIC_WRITE;
		}

		if (!IsExclusive)
		{
			sharingFlags = FILE_SHARE.FILE_SHARE_READ | FILE_SHARE.FILE_SHARE_WRITE;
		}

		//
		// The hid.dll api's do not pass the overlapped structure into deviceiocontrol
		// so to use them we must have a non overlapped device. If the request is for
		// an overlapped device we will close the device below and get a handle to an
		// overlapped device
		//

		HidDevice.HidDevice = CreateFile(DevicePath, accessFlags, sharingFlags, null, CreationOption.OPEN_EXISTING, 0);

		if (HidDevice.HidDevice.IsInvalid)
		{
			goto Done;
		}

		HidDevice.OpenedForRead = HasReadAccess;
		HidDevice.OpenedForWrite = HasWriteAccess;
		HidDevice.OpenedOverlapped = IsOverlapped;
		HidDevice.OpenedExclusive = IsExclusive;

		//
		// If the device was not opened as overlapped, then fill in the rest of the
		// HidDevice structure. However, if opened as overlapped, this handle cannot
		// be used in the calls to the HidD_ exported functions since each of these
		// functions does synchronous I/O.
		//

		if (!HidD_GetPreparsedData(HidDevice.HidDevice, out HidDevice.Ppd))
		{
			goto Done;
		}

		if (!HidD_GetAttributes(HidDevice.HidDevice, ref HidDevice.Attributes))
		{
			goto Done;
		}

		if (HidP_GetCaps(HidDevice.Ppd, out HidDevice.Caps).Failed)
		{
			goto Done;
		}

		//
		// At this point the client has a choice. It may chose to look at the
		// Usage and Page of the top level collection found in the HIDP_CAPS
		// structure. In this way it could just use the usages it knows about.
		// If either HidP_GetUsages or HidP_GetUsageValue return an error then
		// that particular usage does not exist in the report.
		// This is most likely the preferred method as the application can only
		// use usages of which it already knows.
		// In this case the app need not even call GetButtonCaps or GetValueCaps.
		//
		// In this example, however, we will call FillDeviceInfo to look for all
		// of the usages in the device.
		//

		if (false == FillDeviceInfo(HidDevice))
		{
			goto Done;
		}

		if (IsOverlapped)
		{
			HidDevice.HidDevice.Dispose();

			HidDevice.HidDevice = CreateFile(DevicePath, accessFlags, sharingFlags, null, CreationOption.OPEN_EXISTING, FileFlagsAndAttributes.FILE_FLAG_OVERLAPPED);

			if (HidDevice.HidDevice.IsInvalid)
			{
				goto Done;
			}
		}

		bRet = true;

		Done:
		if (!bRet)
		{
			HidDevice.Dispose();
		}

		return bRet;
	}

	static bool FillDeviceInfo(HID_DEVICE HidDevice)
	{
		int numValues;
		ushort numCaps;
		HIDP_BUTTON_CAPS[] buttonCaps;
		HIDP_VALUE_CAPS[] valueCaps;
		HID_DATA[] data;
		int ibuttonCaps = 0, ivalueCaps = 0, idata = 0;
		int i;
		USAGE usage;
		int dataIdx;
		uint newFeatureDataLength;
		uint tmpSum;
		bool bRet = false;

		//
		// setup Input Data buffers.
		//

		//
		// Allocate memory to hold the button and value capabilities.
		// NumberXXCaps is in terms of array elements.
		//

		HidDevice.InputButtonCaps = buttonCaps = new HIDP_BUTTON_CAPS[HidDevice.Caps.NumberInputButtonCaps];

		HidDevice.InputValueCaps = valueCaps = new HIDP_VALUE_CAPS[HidDevice.Caps.NumberInputValueCaps];

		//
		// Have the HidP_X functions fill in the capability structure arrays.
		//

		numCaps = HidDevice.Caps.NumberInputButtonCaps;

		if (numCaps > 0)
		{
			if (HidP_GetButtonCaps(HIDP_REPORT_TYPE.HidP_Input, buttonCaps, ref numCaps, HidDevice.Ppd).Failed)
			{
				goto Done;
			}
		}

		numCaps = HidDevice.Caps.NumberInputValueCaps;

		if (numCaps > 0)
		{
			if (HidP_GetValueCaps(HIDP_REPORT_TYPE.HidP_Input, valueCaps, ref numCaps, HidDevice.Ppd).Failed)
			{
				goto Done;
			}
		}


		//
		// Depending on the device, some value caps structures may represent more
		// than one value. (A range). In the interest of being verbose, over
		// efficient, we will expand these so that we have one and only one
		// struct HID_DATA for each value.
		//
		// To do this we need to count up the total number of values are listed
		// in the value caps structure. For each element in the array we test
		// for range if it is a range then UsageMax and UsageMin describe the
		// usages for this range INCLUSIVE.
		//

		numValues = 0;
		for (i = 0; i < HidDevice.Caps.NumberInputValueCaps; i++, ivalueCaps++)
		{
			if (valueCaps[ivalueCaps].IsRange)
			{
				numValues += (int)valueCaps[ivalueCaps].Range.UsageMax - (int)valueCaps[ivalueCaps].Range.UsageMin + 1;
				if (valueCaps[ivalueCaps].Range.UsageMin > valueCaps[ivalueCaps].Range.UsageMax)
				{
					goto Done; // overrun check
				}
			}
			else
			{
				numValues++;
			}
		}

		valueCaps = HidDevice.InputValueCaps;
		ivalueCaps = 0;

		//
		// Allocate a buffer to hold the struct HID_DATA structures.
		// One element for each set of buttons, and one element for each value
		// found.
		//

		HidDevice.InputDataLength = HidDevice.Caps.NumberInputButtonCaps + numValues;

		HidDevice.InputData = data = new HID_DATA[HidDevice.InputDataLength];

		//
		// Fill in the button data
		//
		dataIdx = 0;
		for (i = 0;
		i < HidDevice.Caps.NumberInputButtonCaps;
		i++, idata++, ibuttonCaps++, dataIdx++)
		{
			HID_DATA d = new();
			d.IsButtonData = true;
			d.Status = NTStatus.HIDP_STATUS_SUCCESS;
			d.UsagePage = buttonCaps[ibuttonCaps].UsagePage;
			d.ButtonData = new();
			if (buttonCaps[ibuttonCaps].IsRange)
			{
				d.ButtonData.UsageMin = buttonCaps[ibuttonCaps].Range.UsageMin;
				d.ButtonData.UsageMax = buttonCaps[ibuttonCaps].Range.UsageMax;
			}
			else
			{
				d.ButtonData.UsageMin = d.ButtonData.UsageMax = buttonCaps[ibuttonCaps].NotRange.Usage;
			}

			d.ButtonData.MaxUsageLength = HidP_MaxUsageListLength(HIDP_REPORT_TYPE.HidP_Input,
			buttonCaps[ibuttonCaps].UsagePage,
			HidDevice.Ppd);
			d.ButtonData.Usages = new USAGE[d.ButtonData.MaxUsageLength];

			d.ReportID = buttonCaps[ibuttonCaps].ReportID;
			data[idata] = d;
		}

		//
		// Fill in the value data
		//

		for (i = 0; i < HidDevice.Caps.NumberInputValueCaps; i++, ivalueCaps++)
		{
			if (valueCaps[ivalueCaps].IsRange)
			{
				for (usage = valueCaps[ivalueCaps].Range.UsageMin;
				usage <= valueCaps[ivalueCaps].Range.UsageMax;
				usage++)
				{
					if (dataIdx >= HidDevice.InputDataLength)
					{
						goto Done; // error case
					}
					HID_DATA d = new();
					d.IsButtonData = false;
					d.Status = NTStatus.HIDP_STATUS_SUCCESS;
					d.UsagePage = valueCaps[ivalueCaps].UsagePage;
					d.ValueData = new() { Usage = usage };
					d.ReportID = valueCaps[ivalueCaps].ReportID;
					data[idata] = d;
					idata++;
					dataIdx++;
				}
			}
			else
			{
				if (dataIdx >= HidDevice.InputDataLength)
				{
					goto Done; // error case
				}
				HID_DATA d = new();
				d.IsButtonData = false;
				d.Status = NTStatus.HIDP_STATUS_SUCCESS;
				d.UsagePage = valueCaps[ivalueCaps].UsagePage;
				d.ValueData = new() { Usage = valueCaps[ivalueCaps].NotRange.Usage };
				d.ReportID = valueCaps[ivalueCaps].ReportID;
				data[idata] = d;
				idata++;
				dataIdx++;
			}
		}

		//
		// setup Output Data buffers.
		//

		HidDevice.OutputButtonCaps = buttonCaps = new HIDP_BUTTON_CAPS[HidDevice.Caps.NumberOutputButtonCaps];
		ibuttonCaps = 0;

		HidDevice.OutputValueCaps = valueCaps = new HIDP_VALUE_CAPS[HidDevice.Caps.NumberOutputValueCaps];
		ivalueCaps = 0;

		numCaps = HidDevice.Caps.NumberOutputButtonCaps;
		if (numCaps > 0)
		{
			if (HidP_GetButtonCaps(HIDP_REPORT_TYPE.HidP_Output, buttonCaps, ref numCaps, HidDevice.Ppd).Failed)
			{
				goto Done;
			}
		}

		numCaps = HidDevice.Caps.NumberOutputValueCaps;
		if (numCaps > 0)
		{
			if (HidP_GetValueCaps(HIDP_REPORT_TYPE.HidP_Output, valueCaps, ref numCaps, HidDevice.Ppd).Failed)
			{
				goto Done;
			}
		}

		numValues = 0;
		for (i = 0; i < HidDevice.Caps.NumberOutputValueCaps; i++, ivalueCaps++)
		{
			if (valueCaps[ivalueCaps].IsRange)
			{
				numValues += valueCaps[ivalueCaps].Range.UsageMax
				- valueCaps[ivalueCaps].Range.UsageMin + 1;
			}
			else
			{
				numValues++;
			}
		}
		valueCaps = HidDevice.OutputValueCaps;
		ivalueCaps = 0;

		HidDevice.OutputDataLength = HidDevice.Caps.NumberOutputButtonCaps
		+ numValues;

		HidDevice.OutputData = data = new HID_DATA[HidDevice.OutputDataLength];
		idata = 0;

		for (i = 0;
		i < HidDevice.Caps.NumberOutputButtonCaps;
		i++, idata++, ibuttonCaps++)
		{
			if (i >= HidDevice.OutputDataLength)
			{
				goto Done;
			}

			HIDP_VALUE_CAPS.RangeUnion range = valueCaps.Length == 0 ? default : valueCaps[ivalueCaps].Range;
			if (ULongAdd(HidDevice.Caps.NumberOutputButtonCaps,
			(uint)range.UsageMax, out tmpSum).Failed)
			{
				goto Done;
			}

			if ((uint)range.UsageMin == tmpSum)
			{
				goto Done;
			}

			HID_DATA d = new();
			d.IsButtonData = true;
			d.Status = NTStatus.HIDP_STATUS_SUCCESS;
			d.UsagePage = buttonCaps[ibuttonCaps].UsagePage;

			if (buttonCaps[ibuttonCaps].IsRange)
			{
				d.ButtonData = new() { UsageMin = buttonCaps[ibuttonCaps].Range.UsageMin, UsageMax = buttonCaps[ibuttonCaps].Range.UsageMax };
			}
			else
			{
				d.ButtonData = new() { UsageMin = buttonCaps[ibuttonCaps].NotRange.Usage, UsageMax = buttonCaps[ibuttonCaps].NotRange.Usage };
			}

			d.ButtonData.MaxUsageLength = HidP_MaxUsageListLength(HIDP_REPORT_TYPE.HidP_Output,
			buttonCaps[ibuttonCaps].UsagePage,
			HidDevice.Ppd);

			d.ButtonData.Usages = new USAGE[d.ButtonData.MaxUsageLength];

			d.ReportID = buttonCaps[ibuttonCaps].ReportID;
			data[idata] = d;
		}

		for (i = 0; i < HidDevice.Caps.NumberOutputValueCaps; i++, ivalueCaps++)
		{
			if (valueCaps[ivalueCaps].IsRange)
			{
				for (usage = valueCaps[ivalueCaps].Range.UsageMin;
				usage <= valueCaps[ivalueCaps].Range.UsageMax;
				usage++)
				{
					HID_DATA d = new();
					d.IsButtonData = false;
					d.Status = NTStatus.HIDP_STATUS_SUCCESS;
					d.UsagePage = valueCaps[ivalueCaps].UsagePage;
					d.ValueData = new() { Usage = usage };
					d.ReportID = valueCaps[ivalueCaps].ReportID;
					data[idata] = d;
					idata++;
				}
			}
			else
			{
				HID_DATA d = new();
				d.IsButtonData = false;
				d.Status = NTStatus.HIDP_STATUS_SUCCESS;
				d.UsagePage = valueCaps[ivalueCaps].UsagePage;
				d.ValueData = new() { Usage = valueCaps[ivalueCaps].NotRange.Usage };
				d.ReportID = valueCaps[ivalueCaps].ReportID;
				data[idata] = d;
				idata++;
			}
		}

		//
		// setup Feature Data buffers.
		//

		HidDevice.FeatureButtonCaps = buttonCaps = new HIDP_BUTTON_CAPS[HidDevice.Caps.NumberFeatureButtonCaps];
		ibuttonCaps = 0;

		HidDevice.FeatureValueCaps = valueCaps = new HIDP_VALUE_CAPS[HidDevice.Caps.NumberFeatureValueCaps];
		ivalueCaps = 0;

		numCaps = HidDevice.Caps.NumberFeatureButtonCaps;
		if (numCaps > 0)
		{
			if (HidP_GetButtonCaps(HIDP_REPORT_TYPE.HidP_Feature, buttonCaps, ref numCaps, HidDevice.Ppd).Failed)
			{
				goto Done;
			}
		}

		numCaps = HidDevice.Caps.NumberFeatureValueCaps;
		if (numCaps > 0)
		{
			if (HidP_GetValueCaps(HIDP_REPORT_TYPE.HidP_Feature, valueCaps, ref numCaps, HidDevice.Ppd).Failed)
			{
				goto Done;
			}
		}

		numValues = 0;
		for (i = 0; i < HidDevice.Caps.NumberFeatureValueCaps; i++, ivalueCaps++)
		{
			if (valueCaps[ivalueCaps].IsRange)
			{
				numValues += valueCaps[ivalueCaps].Range.UsageMax
				- valueCaps[ivalueCaps].Range.UsageMin + 1;
			}
			else
			{
				numValues++;
			}
		}
		valueCaps = HidDevice.FeatureValueCaps;
		ivalueCaps = 0;

		if (ULongAdd(HidDevice.Caps.NumberFeatureButtonCaps,
		(uint)numValues, out newFeatureDataLength).Failed)
		{
			goto Done;
		}

		HidDevice.FeatureDataLength = (int)newFeatureDataLength;

		HidDevice.FeatureData = data = new HID_DATA[HidDevice.FeatureDataLength];
		idata = 0;

		dataIdx = 0;
		for (i = 0;
		i < HidDevice.Caps.NumberFeatureButtonCaps;
		i++, idata++, ibuttonCaps++, dataIdx++)
		{
			HID_DATA d = new();
			d.IsButtonData = true;
			d.Status = NTStatus.HIDP_STATUS_SUCCESS;
			d.UsagePage = buttonCaps[ibuttonCaps].UsagePage;
			d.ButtonData = new();
			if (buttonCaps[ibuttonCaps].IsRange)
			{
				d.ButtonData.UsageMin = buttonCaps[ibuttonCaps].Range.UsageMin;
				d.ButtonData.UsageMax = buttonCaps[ibuttonCaps].Range.UsageMax;
			}
			else
			{
				d.ButtonData.UsageMin = d.ButtonData.UsageMax = buttonCaps[ibuttonCaps].NotRange.Usage;
			}

			d.ButtonData.MaxUsageLength = HidP_MaxUsageListLength(HIDP_REPORT_TYPE.HidP_Feature,
			buttonCaps[ibuttonCaps].UsagePage,
			HidDevice.Ppd);
			d.ButtonData.Usages = new USAGE[d.ButtonData.MaxUsageLength];

			d.ReportID = buttonCaps[ibuttonCaps].ReportID;
			data[idata] = d;
		}

		for (i = 0; i < HidDevice.Caps.NumberFeatureValueCaps; i++, ivalueCaps++)
		{
			if (valueCaps[ivalueCaps].IsRange)
			{
				for (usage = valueCaps[ivalueCaps].Range.UsageMin;
				usage <= valueCaps[ivalueCaps].Range.UsageMax;
				usage++)
				{
					if (dataIdx >= HidDevice.FeatureDataLength)
					{
						goto Done; // error case
					}
					HID_DATA d = new();
					d.IsButtonData = false;
					d.Status = NTStatus.HIDP_STATUS_SUCCESS;
					d.UsagePage = valueCaps[ivalueCaps].UsagePage;
					d.ValueData = new() { Usage = usage };
					d.ReportID = valueCaps[ivalueCaps].ReportID;
					data[idata] = d;
					idata++;
					dataIdx++;
				}
			}
			else
			{
				if (dataIdx >= HidDevice.FeatureDataLength)
				{
					goto Done; // error case
				}
				HID_DATA d = new();
				d.IsButtonData = false;
				d.Status = NTStatus.HIDP_STATUS_SUCCESS;
				d.UsagePage = valueCaps[ivalueCaps].UsagePage;
				d.ValueData = new() { Usage = valueCaps[ivalueCaps].NotRange.Usage };
				d.ReportID = valueCaps[ivalueCaps].ReportID;
				data[idata] = d;
				idata++;
				dataIdx++;
			}
		}

		bRet = true;

		Done:
		//
		// We leave the resource clean-up to the caller. 
		//
		return bRet;

		static HRESULT ULongAdd(uint a, uint b, out uint c)
		{
			c = uint.MaxValue;
			if (a > uint.MaxValue - b)
				return HRESULT.HRESULT_FROM_WIN32(Win32Error.ERROR_ARITHMETIC_OVERFLOW);
			c = a + b;
			return HRESULT.S_OK;
		}
	}

#pragma warning disable 0649
	class HID_DEVICE : IDisposable
	{
		public string? DevicePath;
		public SafeHFILE HidDevice = SafeHFILE.Null; // A file handle to the hid device.
		public bool OpenedForRead;
		public bool OpenedForWrite;
		public bool OpenedOverlapped;
		public bool OpenedExclusive;
		public SafePHIDP_PREPARSED_DATA Ppd = SafePHIDP_PREPARSED_DATA.Null; // The opaque parser info describing this device
		public HIDP_CAPS Caps; // The Capabilities of this hid device.
		public HIDD_ATTRIBUTES Attributes;
		public string? InputReportBuffer;
		public HID_DATA[] InputData = []; // array of hid dataPtrIdx structures
		public int InputDataLength; // Num elements in this array.
		public HIDP_BUTTON_CAPS[] InputButtonCaps = [];
		public HIDP_VALUE_CAPS[] InputValueCaps = [];
		public string? OutputReportBuffer;
		public HID_DATA[] OutputData = [];
		public int OutputDataLength;
		public HIDP_BUTTON_CAPS[] OutputButtonCaps = [];
		public HIDP_VALUE_CAPS[] OutputValueCaps = [];
		public string? FeatureReportBuffer;
		public HID_DATA[] FeatureData = [];
		public int FeatureDataLength;
		public HIDP_BUTTON_CAPS[] FeatureButtonCaps = [];
		public HIDP_VALUE_CAPS[] FeatureValueCaps = [];

		public override string? ToString() => DevicePath;

		public void Dispose()
		{
			HidDevice.Dispose();
			Ppd.Dispose();
		}
	}

	class HID_DATA
	{
		public bool IsButtonData;
		public USAGE UsagePage; // The usage page for which we are looking.
		public NTStatus Status; // The last status returned from the accessor function when updating this field.
		public uint ReportID; // ReportID for this given dataPtrIdx structure
		public bool IsDataSet; // Variable to track whether a given dataPtrIdx structure has already been added to a report structure
		public BUTTON_DATA? ButtonData;
		public VALUE_DATA? ValueData;

		public class BUTTON_DATA
		{
			public USAGE UsageMin; // Variables to track the usage minimum and Math.Max
			public USAGE UsageMax; // If equal, then only a single usage
			public uint MaxUsageLength; // Usages buffer length.
			public USAGE[] Usages = []; // list of usages (buttons ``down'' on the device.
		}
		public class VALUE_DATA
		{
			public USAGE Usage; // The usage describing this value;
			public uint Value;
			public int ScaledValue;
		}
   }
}