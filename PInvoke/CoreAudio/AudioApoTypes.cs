using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class CoreAudio
	{
		/// <summary>Defines the buffer validation flags for the APO_CONNECTION_PROPERTY structure associated with each APO connection.</summary>
		/// <remarks>The Remote Desktop Services AudioEndpoint API is for use in Remote Desktop scenarios; it is not for client applications.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioapotypes/ne-audioapotypes-apo_buffer_flags typedef enum APO_BUFFER_FLAGS
		// { BUFFER_INVALID, BUFFER_VALID, BUFFER_SILENT } ;
		[PInvokeData("audioapotypes.h", MSDNShortId = "996b56d7-1187-4ed7-b5f5-7d77291113f6")]
		public enum APO_BUFFER_FLAGS
		{
			/// <summary>
			/// There is no valid data in the connection buffer. The buffer pointer is valid and the buffer is capable of holding the amount
			/// of valid audio data specified in the APO_CONNECTION_PROPERTY structure. While processing audio data, the audio engine marks
			/// every connection as BUFFER_INVALID before calling IAudioOutputEndpoint::GetOutputDataPointer or IAudioInputEndpointRT::GetInputDataPointer.
			/// </summary>
			BUFFER_INVALID,

			/// <summary>
			/// The connection buffer contains valid data. This is the operational state of the connection buffer. The APO sets this flag
			/// after it starts writing valid data into the buffer.Capture endpoints should set this flag in the GetInputDataPointer method
			/// upon successful completion of the call.
			/// </summary>
			BUFFER_VALID,

			/// <summary>
			/// The connection buffer must be treated as if it contains silence. If the endpoint receives an input connection buffer that is
			/// identified as BUFFER_SILENT, then the endpoint can assume the data represents silence. When capturing, the endpoint can also
			/// set this flag, if necessary for a capture buffer.
			/// </summary>
			BUFFER_SILENT,
		}

		/// <summary>
		/// The <c>AUDIO_CURVE_TYPE</c> enumeration defines constants that specify a curve algorithm to be applied to set a volume level.
		/// </summary>
		/// <remarks>
		/// <para>
		/// The following snippet of pseudocode shows the logic for the algorithm that is applied to the volume setting to reach the target
		/// volume level.
		/// </para>
		/// <para>And the following diagram shows a graphical representation of the preceding pseudocode for setting the volume level.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/ksmedia/ne-ksmedia-audio_curve_type typedef enum {
		// AUDIO_CURVE_TYPE_NONE, AUDIO_CURVE_TYPE_WINDOWS_FADE } AUDIO_CURVE_TYPE;
		[PInvokeData("AudioAPITypes.h", MSDNShortId = "E3CE3385-8744-4E3F-A5EF-41AC4E3E4375")]
		public enum AUDIO_CURVE_TYPE
		{
			/// <summary>
			/// Specifies that no curve algorithm will be applied. When this curve is specified, the duration of the curve specified must be
			/// equal to 0.
			/// </summary>
			AUDIO_CURVE_TYPE_NONE,

			/// <summary>
			/// Specifies that the algorithm that is applied to the volume setting must follow the curve shown in the diagram in the Remarks section.
			/// </summary>
			AUDIO_CURVE_TYPE_WINDOWS_FADE,
		}

		/// <summary>Contains the dynamically changing connection properties.</summary>
		/// <remarks>The Remote Desktop Services AudioEndpoint API is for use in Remote Desktop scenarios; it is not for client applications.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioapotypes/ns-audioapotypes-apo_connection_property typedef struct
		// APO_CONNECTION_PROPERTY { UINT_PTR pBuffer; UINT32 u32ValidFrameCount; APO_BUFFER_FLAGS u32BufferFlags; UINT32 u32Signature; } APO_CONNECTION_PROPERTY;
		[PInvokeData("audioapotypes.h", MSDNShortId = "dbf7ed62-445e-4f15-bc21-46117e694dc0")]
		[StructLayout(LayoutKind.Sequential)]
		public struct APO_CONNECTION_PROPERTY
		{
			/// <summary>A pointer to the connection buffer. Endpoints use this buffer to read and write audio data.</summary>
			public IntPtr pBuffer;

			/// <summary>
			/// The number of valid frames in the connection buffer. An APO uses the valid frame count to determine the amount of data to
			/// read and process in the input buffer. An APO sets the valid frame count after writing data into its output connection.
			/// </summary>
			public uint u32ValidFrameCount;

			/// <summary>
			/// The connection flags for this buffer. This indicates the validity status of the APOs. For more information about these
			/// flags, see APO_BUFFER_FLAGS.
			/// </summary>
			public APO_BUFFER_FLAGS u32BufferFlags;

			/// <summary>A tag that identifies a valid <c>APO_CONNECTION_PROPERTY</c> structure. A valid structure is marked as <c>APO_CONNECTION_PROPERTY_SIGNATURE</c>.</summary>
			public uint u32Signature;
		}
	}
}