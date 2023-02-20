namespace Vanara.PInvoke;

/// <summary>
/// Indicates a spoofed device scale factor, as a percent. Used by IApplicationDesignModeSettings::SetApplicationViewState and IApplicationDesignModeSettings::IsApplicationViewStateSupported
/// </summary>
// https://docs.microsoft.com/en-us/windows/win32/api/shtypes/ne-shtypes-device_scale_factor typedef enum DEVICE_SCALE_FACTOR {
// DEVICE_SCALE_FACTOR_INVALID, SCALE_100_PERCENT, SCALE_120_PERCENT, SCALE_125_PERCENT, SCALE_140_PERCENT, SCALE_150_PERCENT,
// SCALE_160_PERCENT, SCALE_175_PERCENT, SCALE_180_PERCENT, SCALE_200_PERCENT, SCALE_225_PERCENT, SCALE_250_PERCENT, SCALE_300_PERCENT,
// SCALE_350_PERCENT, SCALE_400_PERCENT, SCALE_450_PERCENT, SCALE_500_PERCENT } ;
[PInvokeData("shtypes.h", MSDNShortId = "NE:shtypes.DEVICE_SCALE_FACTOR")]
public enum DEVICE_SCALE_FACTOR
{
	/// <summary/>
	DEVICE_SCALE_FACTOR_INVALID = 0,

	/// <summary>100%. The scale factor for the device is 1x.</summary>
	SCALE_100_PERCENT = 100,

	/// <summary>120%. The scale factor for the device is 1.2x.</summary>
	SCALE_120_PERCENT = 120,

	/// <summary/>
	SCALE_125_PERCENT = 125,

	/// <summary>140%. The scale factor for the device is 1.4x.</summary>
	SCALE_140_PERCENT = 140,

	/// <summary>150%. The scale factor for the device is 1.5x.</summary>
	SCALE_150_PERCENT = 150,

	/// <summary>160%. The scale factor for the device is 1.6x.</summary>
	SCALE_160_PERCENT = 160,

	/// <summary/>
	SCALE_175_PERCENT = 175,

	/// <summary>180%. The scale factor for the device is 1.8x.</summary>
	SCALE_180_PERCENT = 180,

	/// <summary/>
	SCALE_200_PERCENT = 200,

	/// <summary>225%. The scale factor for the device is 2.25x.</summary>
	SCALE_225_PERCENT = 225,

	/// <summary/>
	SCALE_250_PERCENT = 250,

	/// <summary/>
	SCALE_300_PERCENT = 300,

	/// <summary/>
	SCALE_350_PERCENT = 350,

	/// <summary/>
	SCALE_400_PERCENT = 400,

	/// <summary/>
	SCALE_450_PERCENT = 450,

	/// <summary/>
	SCALE_500_PERCENT = 500,
}