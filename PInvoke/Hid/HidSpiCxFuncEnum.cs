namespace Vanara.PInvoke;

public static partial class Hid
{
	/// <summary/>
	[PInvokeData("hidspicxfuncenum.h")]
	public enum HIDSPICXFUNCENUM
	{
		/// <summary/>
		HidSpiCxDeviceInitConfigTableIndex = 0,

		/// <summary/>
		HidSpiCxDeviceConfigureTableIndex = 1,

		/// <summary/>
		HidSpiCxNotifyDeviceResetTableIndex = 2,

		/// <summary/>
		HidspicxFunctionTableNumEntries = 3,
	}
}