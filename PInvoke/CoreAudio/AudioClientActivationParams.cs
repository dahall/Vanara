using System.Runtime.InteropServices;

namespace Vanara.PInvoke;

public static partial class CoreAudio
{
	/// <summary>Specifies the activation type for an AUDIOCLIENT_ACTIVATION_PARAMS structure passed into a call to ActivateAudioInterfaceAsync.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/audioclientactivationparams/ne-audioclientactivationparams-audioclient_activation_type
	// typedef enum AUDIOCLIENT_ACTIVATION_TYPE { AUDIOCLIENT_ACTIVATION_TYPE_DEFAULT, AUDIOCLIENT_ACTIVATION_TYPE_PROCESS_LOOPBACK } ;
	[PInvokeData("audioclientactivationparams.h", MSDNShortId = "NE:audioclientactivationparams.AUDIOCLIENT_ACTIVATION_TYPE")]
	public enum AUDIOCLIENT_ACTIVATION_TYPE
	{
		/// <summary>Default activation.</summary>
		AUDIOCLIENT_ACTIVATION_TYPE_DEFAULT,

		/// <summary>
		/// <para>
		/// Process loopback activation, allowing for the inclusion or exclusion of audio rendered by the specified process and its child
		/// processes. For sample code that demonstrates the process loopback capture scenario, see the
		/// </para>
		/// <para>Application Loopback API Capture Sample</para>
		/// <para>.</para>
		/// </summary>
		AUDIOCLIENT_ACTIVATION_TYPE_PROCESS_LOOPBACK,
	}

	/// <summary>Specifies the loopback mode for an AUDIOCLIENT_ACTIVATION_PARAMS structure passed into a call to ActivateAudioInterfaceAsync.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/audioclientactivationparams/ne-audioclientactivationparams-process_loopback_mode
	// typedef enum PROCESS_LOOPBACK_MODE { PROCESS_LOOPBACK_MODE_INCLUDE_TARGET_PROCESS_TREE,
	// PROCESS_LOOPBACK_MODE_EXCLUDE_TARGET_PROCESS_TREE } ;
	[PInvokeData("audioclientactivationparams.h", MSDNShortId = "NE:audioclientactivationparams.PROCESS_LOOPBACK_MODE")]
	public enum PROCESS_LOOPBACK_MODE
	{
		/// <summary>
		/// Render streams from the specified process and its child processes are included in the activated process loopback stream.
		/// </summary>
		PROCESS_LOOPBACK_MODE_INCLUDE_TARGET_PROCESS_TREE,

		/// <summary>
		/// Render streams from the specified process and its child processes are excluded from the activated process loopback stream.
		/// </summary>
		PROCESS_LOOPBACK_MODE_EXCLUDE_TARGET_PROCESS_TREE,
	}

	/// <summary>Specifies the activation parameters for a call to ActivateAudioInterfaceAsync.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/audioclientactivationparams/ns-audioclientactivationparams-audioclient_activation_params
	// typedef struct AUDIOCLIENT_ACTIVATION_PARAMS { AUDIOCLIENT_ACTIVATION_TYPE ActivationType; union { AUDIOCLIENT_PROCESS_LOOPBACK_PARAMS
	// ProcessLoopbackParams; } DUMMYUNIONNAME; } AUDIOCLIENT_ACTIVATION_PARAMS;
	[PInvokeData("audioclientactivationparams.h", MSDNShortId = "NS:audioclientactivationparams.AUDIOCLIENT_ACTIVATION_PARAMS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct AUDIOCLIENT_ACTIVATION_PARAMS
	{
		/// <summary>
		/// A member of the AUDIOCLIENT_ACTIVATION_TYPE specifying the type of audio interface activation. Currently default activation and
		/// loopback activation are supported.
		/// </summary>
		public AUDIOCLIENT_ACTIVATION_TYPE ActivationType;

		/// <summary>A AUDIOCLIENT_PROCESS_LOOPBACK_PARAMS specifying the loopback parameters for the audio interface activation.</summary>
		private AUDIOCLIENT_PROCESS_LOOPBACK_PARAMS ProcessLoopbackParams;
	}

	/// <summary>Specifies parameters for a call to ActivateAudioInterfaceAsync where loopback activation is requested.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/audioclientactivationparams/ns-audioclientactivationparams-audioclient_process_loopback_params
	// typedef struct AUDIOCLIENT_PROCESS_LOOPBACK_PARAMS { DWORD TargetProcessId; PROCESS_LOOPBACK_MODE ProcessLoopbackMode; } AUDIOCLIENT_PROCESS_LOOPBACK_PARAMS;
	[PInvokeData("audioclientactivationparams.h", MSDNShortId = "NS:audioclientactivationparams.AUDIOCLIENT_PROCESS_LOOPBACK_PARAMS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct AUDIOCLIENT_PROCESS_LOOPBACK_PARAMS
	{
		/// <summary>
		/// The ID of the process for which the render streams, and the render streams of its child processes, will be included or excluded
		/// when activating the process loopback stream.
		/// </summary>
		public uint TargetProcessId;

		/// <summary>
		/// A value from the PROCESS_LOOPBACK_MODE enumeration specifying whether the render streams for the process and child processes
		/// specified in the TargetProcessId field should be included or excluded when activating the audio interface. For sample code that
		/// demonstrates the process loopback capture scenario, see the Application Loopback API Capture Sample.
		/// </summary>
		public PROCESS_LOOPBACK_MODE ProcessLoopbackMode;
	}
}