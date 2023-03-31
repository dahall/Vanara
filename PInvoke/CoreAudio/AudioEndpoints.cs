using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke;

/// <summary>Functions, structures and constants from Windows Core Audio Api.</summary>
public static partial class CoreAudio
{
	/// <summary>Allows the application to specify which formats are reset.</summary>
	[PInvokeData("audioendpoints.h", MSDNShortId = "7FF7DCF2-0580-4B50-8EA9-87DB9478B1E8")]
	[Flags]
	public enum ENDPOINT_RESET
	{
		/// <summary>Only reset the mix format. The endpoint's device format will not be reset if this flag is set.</summary>
		ENDPOINT_FORMAT_RESET_MIX_ONLY = 0x00000001
	}

	/// <summary>Used for resetting the current audio endpoint device format.</summary>
	/// <remarks>
	/// This setting is exposed to the user through the "Sounds" control panel and can be read from the endpoint property store using PKEY_AudioEngine_DeviceFormat.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/audioendpoints/nn-audioendpoints-iaudioendpointformatcontrol
	[PInvokeData("audioendpoints.h", MSDNShortId = "7FF7DCF2-0580-4B50-8EA9-87DB9478B1E8")]
	[ComImport, Guid("784CFD40-9F89-456E-A1A6-873B006A664E"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAudioEndpointFormatControl
	{
		/// <summary>Resets the format to the default setting provided by the device manufacturer.</summary>
		/// <param name="ResetFlags">
		/// <para>
		/// Allows the application to specify which formats are reset. If no flags are set, then this method reevaluates both the
		/// endpoint's device format and mix format and sets them to their default values.
		/// </para>
		/// <para>
		/// ENDPOINT_FORMAT_RESET_MIX_ONLY: Only reset the mix format. The endpoint's device format will not be reset if this flag is set.
		/// </para>
		/// </param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioendpoints/nf-audioendpoints-iaudioendpointformatcontrol-resettodefault
		// HRESULT ResetToDefault( DWORD ResetFlags );
		HRESULT ResetToDefault(ENDPOINT_RESET ResetFlags);
	}
}