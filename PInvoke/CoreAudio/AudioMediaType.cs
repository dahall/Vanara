using System;
using System.Runtime.InteropServices;
using static Vanara.PInvoke.WinMm;

namespace Vanara.PInvoke;

public static partial class CoreAudio
{
	/// <summary>The function uses the format specified by the caller to create a media type object that describes the audio format.</summary>
	/// <param name="pAudioFormat">Specifies a pointer to a WAVEFORMATEX structure.</param>
	/// <param name="cbAudioFormatSize">Specifies the size of the WAVEFORMATEX structure pointed to by the <c>pAudioFormat</c> parameter.</param>
	/// <param name="ppIAudioMediaType">Specifies a pointer to an IAudioMediaType interface.</param>
	/// <returns>
	/// The function returns S_OK if the call to the function is successful. Otherwise, it returns an appropriate HRESULT error code.
	/// </returns>
	/// <remarks>
	/// When you implement custom audio system effects, the function works with IAudioSystemEffectsCustomFormats::GetFormat to represent a
	/// custom audio data format and to provide information about the custom format.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/audiomediatype/nf-audiomediatype-createaudiomediatype HRESULT
	// CreateAudioMediaType( const WAVEFORMATEX *pAudioFormat, UINT32 cbAudioFormatSize, IAudioMediaType **ppIAudioMediaType );
	[PInvokeData("audiomediatype.h", MSDNShortId = "NF:audiomediatype.CreateAudioMediaType")]
	public delegate HRESULT CreateAudioMediaType(in WAVEFORMATEX pAudioFormat, uint cbAudioFormatSize,
		out IAudioMediaType ppIAudioMediaType);

	/// <summary>
	/// The function uses the information provided in the UNCOMPRESSEDAUDIOFORMAT structure to create a media type object that describes the
	/// audio format.
	/// </summary>
	/// <param name="pUncompressedAudioFormat">Specifies a pointer to an UNCOMPRESSEDAUDIOFORMAT structure.</param>
	/// <param name="ppIAudioMediaType">Specifies a pointer to an IAudioMediaType interface.</param>
	/// <returns>
	/// The function returns S_OK if the call to the function is successful. Otherwise, it returns an appropriate HRESULT error code.
	/// </returns>
	/// <remarks>
	/// When you implement custom audio system effects, the function works with IAudioSystemEffectsCustomFormats::GetFormat to represent a
	/// custom audio data format and to provide information about the custom format.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/audiomediatype/nf-audiomediatype-createaudiomediatypefromuncompressedaudioformat
	// HRESULT CreateAudioMediaTypeFromUncompressedAudioFormat( const UNCOMPRESSEDAUDIOFORMAT *pUncompressedAudioFormat, IAudioMediaType
	// **ppIAudioMediaType );
	[PInvokeData("audiomediatype.h", MSDNShortId = "NF:audiomediatype.CreateAudioMediaTypeFromUncompressedAudioFormat")]
	public delegate HRESULT CreateAudioMediaTypeFromUncompressedAudioFormat(in UNCOMPRESSEDAUDIOFORMAT pUncompressedAudioFormat,
		out IAudioMediaType ppIAudioMediaType);

	/// <summary>These flags indicate the degree of similarity between the two media types.</summary>
	[PInvokeData("audiomediatype.h", MSDNShortId = "NN:audiomediatype.IAudioMediaType")]
	[Flags]
	public enum UDIOMEDIATYPE_EQUAL
	{
		/// <summary>The audio format types are the same.</summary>
		AUDIOMEDIATYPE_EQUAL_FORMAT_TYPES = 0x00000002,

		/// <summary>The format information matches, not including extra data beyond the base WAVEFORMATEX structure.</summary>
		AUDIOMEDIATYPE_EQUAL_FORMAT_DATA = 0x00000004,

		/// <summary>The extra data is identical, or neither media type contains extra data.</summary>
		AUDIOMEDIATYPE_EQUAL_FORMAT_USER_DATA = 0x00000008,
	}

	/// <summary>
	/// <para>
	/// The interface exposes methods that allow an sAPO to get information that is used to negotiate with the audio engine for the
	/// appropriate audio data format. An sAPO also returns this interface in response to a call to IAudioSystemEffectsCustomFormats::GetFormat.
	/// </para>
	/// <para>inherits from <c>IUnknown</c> and also supports the following methods:</para>
	/// <list/>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/audiomediatype/nn-audiomediatype-iaudiomediatype
	[PInvokeData("audiomediatype.h", MSDNShortId = "NN:audiomediatype.IAudioMediaType")]
	[ComImport, Guid("4E997F73-B71F-4798-873B-ED7DFCF15B4D"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAudioMediaType
	{
		/// <summary>The method determines whether the audio data format is a compressed format.</summary>
		/// <returns>Receives a Boolean value. The value is <c>TRUE</c> if the format is compressed or <c>FALSE</c> if the format is uncompressed.</returns>
		/// <remarks>None.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/audiomediatype/nf-audiomediatype-iaudiomediatype-iscompressedformat HRESULT
		// IsCompressedFormat( [out] BOOL *pfCompressed );
		[return: MarshalAs(UnmanagedType.Bool)]
		bool IsCompressedFormat();

		/// <summary>The method compares two media types and determines whether they are identical.</summary>
		/// <param name="pIAudioType">Specifies a pointer to an IAudioMediaType interface of the media type to compare.</param>
		/// <returns>
		/// <para>
		/// Specifies a pointer to a DWORD variable that contains the bitwise OR result of zero or more flags. These flags indicate the
		/// degree of similarity between the two media types. The following table shows the supported flags.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>AUDIOMEDIATYPE_EQUAL_FORMAT_TYPES</term>
		/// <term>The audio format types are the same.</term>
		/// </item>
		/// <item>
		/// <term>AUDIOMEDIATYPE_EQUAL_FORMAT_DATA</term>
		/// <term>The format information matches, not including extra data beyond the base WAVEFORMATEX structure.</term>
		/// </item>
		/// <item>
		/// <term>AUDIOMEDIATYPE_EQUAL_FORMAT_USER_DATA</term>
		/// <term>The extra data is identical, or neither media type contains extra data.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Both media types must have a major type, otherwise the method returns E_INVALIDARG. For more information about media types, see
		/// Media Types.
		/// </para>
		/// <para>
		/// The MF_MEDIATYPE_EQUAL_FORMAT_DATA flag indicates that both media types have compatible attributes, although one might be a
		/// superset of the other. This method of comparison means that you can compare a partially-specified media type against a complete
		/// media type. For example, you might have two video types that describe the same format, but one type includes attributes for
		/// extended color information (chroma siting, nominal range, and so forth).
		/// </para>
		/// <para>
		/// If the method succeeds and all the comparison flags are set in <c>pdwFlags</c>, the return value is S_OK. If the method succeeds
		/// but some comparison flags are not set, the method returns S_FALSE.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/audiomediatype/nf-audiomediatype-iaudiomediatype-isequal HRESULT IsEqual( [in]
		// IAudioMediaType *pIAudioType, [out] DWORD *pdwFlags );
		UDIOMEDIATYPE_EQUAL IsEqual([In] IAudioMediaType pIAudioType);

		/// <summary>The method returns the WAVEFORMATEX structure for the audio data format.</summary>
		/// <returns>The method returns a pointer to a WAVEFORMATEX structure.</returns>
		/// <remarks>The pointer that is returned is valid only while the <c>IAudioMediaType</c> interface is referenced.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/audiomediatype/nf-audiomediatype-iaudiomediatype-getaudioformat const
		// WAVEFORMATEX * GetAudioFormat();
		[PreserveSig]
		IntPtr GetAudioFormat();

		/// <summary>The returns information about the audio data format.</summary>
		/// <returns>Specifies a pointer to an UNCOMPRESSEDAUDIOFORMAT structure.</returns>
		/// <remarks>
		/// The information that is returned is useful for uncompressed formats. However, this method call will succeed for compressed
		/// formats as well. When you make this function call for a compressed audio data format, you must determine whether the returned
		/// information is applicable to your compressed format.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/audiomediatype/nf-audiomediatype-iaudiomediatype-getuncompressedaudioformat
		// HRESULT GetUncompressedAudioFormat( [out] UNCOMPRESSEDAUDIOFORMAT *pUncompressedAudioFormat );
		UNCOMPRESSEDAUDIOFORMAT GetUncompressedAudioFormat();
	}

	/// <summary>
	/// The UNCOMPRESSEDAUDIOFORMAT structure specifies the frame rate, channel mask, and other attributes of the uncompressed audio data format.
	/// </summary>
	/// <remarks>This structure provides access to the parameters that describe an uncompressed PCM audio format.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/audiomediatype/ns-audiomediatype-uncompressedaudioformat typedef struct
	// _UNCOMPRESSEDAUDIOFORMAT { GUID guidFormatType; DWORD dwSamplesPerFrame; DWORD dwBytesPerSampleContainer; DWORD dwValidBitsPerSample;
	// FLOAT fFramesPerSecond; DWORD dwChannelMask; } UNCOMPRESSEDAUDIOFORMAT;
	[PInvokeData("audiomediatype.h", MSDNShortId = "NS:audiomediatype._UNCOMPRESSEDAUDIOFORMAT")]
	[StructLayout(LayoutKind.Sequential)]
	public struct UNCOMPRESSEDAUDIOFORMAT
	{
		/// <summary>Specifies the GUID of the data format type.</summary>
		public Guid guidFormatType;

		/// <summary>Specifies the number of samples per frame.</summary>
		public uint dwSamplesPerFrame;

		/// <summary>Specifies the number of bytes that make up a unit container of the sample.</summary>
		public uint dwBytesPerSampleContainer;

		/// <summary>Specifies the number of valid bits per sample.</summary>
		public uint dwValidBitsPerSample;

		/// <summary>Specifies the number of frames per second of streaming audio data.</summary>
		public float fFramesPerSecond;

		/// <summary>Specifies the channel mask that is used by the uncompressed audio data.</summary>
		public uint dwChannelMask;
	}
}