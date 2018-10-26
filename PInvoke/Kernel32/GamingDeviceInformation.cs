using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Kernel32
	{
		/// <summary>
		/// <para>Indicates the type of device that the game is running on.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// This is a Win32 API that's supported in both Win32 and UWP apps. While it works on any device family, it's only really of value
		/// on Xbox devices.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/gamingdeviceinformation/ne-gamingdeviceinformation-gaming_device_device_id
		// typedef enum GAMING_DEVICE_DEVICE_ID { GAMING_DEVICE_DEVICE_ID_NONE , GAMING_DEVICE_DEVICE_ID_XBOX_ONE ,
		// GAMING_DEVICE_DEVICE_ID_XBOX_ONE_S , GAMING_DEVICE_DEVICE_ID_XBOX_ONE_X , GAMING_DEVICE_DEVICE_ID_XBOX_ONE_X_DEVKIT } ;
		[PInvokeData("gamingdeviceinformation.h", MSDNShortId = "DA196767-940E-47CF-8444-4A2C37E3718B")]
		public enum GAMING_DEVICE_DEVICE_ID
		{
			/// <summary>The device is not in the Xbox family.</summary>
			GAMING_DEVICE_DEVICE_ID_NONE,

			/// <summary>The device is an Xbox One (original).</summary>
			GAMING_DEVICE_DEVICE_ID_XBOX_ONE,

			/// <summary>The device is an Xbox One S.</summary>
			GAMING_DEVICE_DEVICE_ID_XBOX_ONE_S,

			/// <summary>The device is an Xbox One X.</summary>
			GAMING_DEVICE_DEVICE_ID_XBOX_ONE_X,

			/// <summary>The device is an Xbox One X dev kit.</summary>
			GAMING_DEVICE_DEVICE_ID_XBOX_ONE_X_DEVKIT,
		}

		/// <summary>
		/// <para>Indicates the vendor of the console that the game is running on.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// This is a Win32 API that's supported in both Win32 and UWP apps. While it works on any device family, it's only really of value
		/// on Xbox devices.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/gamingdeviceinformation/ne-gamingdeviceinformation-gaming_device_vendor_id
		// typedef enum GAMING_DEVICE_VENDOR_ID { GAMING_DEVICE_VENDOR_ID_NONE , GAMING_DEVICE_VENDOR_ID_MICROSOFT } ;
		[PInvokeData("gamingdeviceinformation.h", MSDNShortId = "0A74E610-9853-4299-A278-41C3B7F47D9C")]
		public enum GAMING_DEVICE_VENDOR_ID
		{
			/// <summary>The vendor of the device is not known.</summary>
			GAMING_DEVICE_VENDOR_ID_NONE,

			/// <summary>The vendor of the device is Microsoft.</summary>
			GAMING_DEVICE_VENDOR_ID_MICROSOFT,
		}

		/// <summary>
		/// <para>Gets information about the device that the game is running on.</para>
		/// </summary>
		/// <param name="information">
		/// <para>A structure containing information about the device that the game is running on.</para>
		/// </param>
		/// <returns>
		/// <para>This function does not return a value.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This is a Win32 API that's supported in both Win32 and UWP apps. While it works on any device family, it's only really of value
		/// on Xbox devices.
		/// </para>
		/// <para>
		/// This function gets information about the console that the game is running on, including the type of console (Xbox One, Xbox One
		/// S, etc.) and the vendor. On non-Xbox devices, it returns <c>GAMING_DEVICE_DEVICE_ID_NONE</c> and <c>GAMING_DEVICE_VENDOR_ID_NONE</c>.
		/// </para>
		/// <para>
		/// If the game is running in an emulation mode, the type of device being emulated is returned. For example, if the game is running
		/// on an Xbox One X dev kit in Xbox One emulation mode, <c>GAMING_DEVICE_DEVICE_ID_XBOX_ONE</c> is returned.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/gamingdeviceinformation/nf-gamingdeviceinformation-getgamingdevicemodelinformation
		// HRESULT GetGamingDeviceModelInformation( GAMING_DEVICE_MODEL_INFORMATION *information );
		[DllImport(Lib.KernelBase, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("gamingdeviceinformation.h", MSDNShortId = "78101CBA-63B5-4B3F-9CEC-A215F32D9EB8")]
		public static extern HRESULT GetGamingDeviceModelInformation(out GAMING_DEVICE_MODEL_INFORMATION information);

		/// <summary>
		/// <para>Contains information about the device that the game is running on.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// This is a Win32 API that's supported in both Win32 and UWP apps. While it works on any device family, it's only really of value
		/// on Xbox devices.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/gamingdeviceinformation/ns-gamingdeviceinformation-gaming_device_model_information
		// typedef struct GAMING_DEVICE_MODEL_INFORMATION { GAMING_DEVICE_VENDOR_ID vendorId; GAMING_DEVICE_DEVICE_ID deviceId; };
		[PInvokeData("gamingdeviceinformation.h", MSDNShortId = "0D5A6358-0F82-4414-BD17-BDE22EDBBB15")]
		[StructLayout(LayoutKind.Sequential)]
		public struct GAMING_DEVICE_MODEL_INFORMATION
		{
			/// <summary>
			/// <para>The vendor of the device.</para>
			/// </summary>
			public GAMING_DEVICE_VENDOR_ID vendorId;

			/// <summary>
			/// <para>The type of device.</para>
			/// </summary>
			public GAMING_DEVICE_DEVICE_ID deviceId;
		}
	}
}