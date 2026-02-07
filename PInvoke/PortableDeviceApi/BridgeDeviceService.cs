#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
using static Vanara.PInvoke.Ole32;

namespace Vanara.PInvoke;

public static partial class PortableDeviceApi
{
	/*****************************************************************************/
	/*  MTP Format Codes for Generic and Media Types                             */
	/*****************************************************************************/

	/*  FORMAT_Undefined
	 *
	 *  MTP Format: Undefined  (0x3000)
	 *  Suggested MIME Type:
	 */

	public static Guid FORMAT_Undefined => new(0x30000000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

	public const string NAME_Undefined = "Undefined";


	/*  FORMAT_Association
	 *
	 *  MTP Format: Association  (0x3001)
	 *  Suggested MIME Type:
	 */

	public static Guid FORMAT_Association => new(0x30010000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

	public const string NAME_Association = "Association";


	/*  FORMAT_DeviceScript
	 *
	 *  MTP Format: Device model-specific script  (0x3002)
	 *  Suggested MIME Type:
	 */

	public static Guid FORMAT_DeviceScript => new(0x30020000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

	public const string NAME_DeviceScript = "DeviceScript";


	/*  FORMAT_DeviceExecutable
	 *
	 *  MTP Format: Device model-specific executable  (0x3003)
	 *  Suggested MIME Type:
	 */

	public static Guid FORMAT_DeviceExecutable => new(0x30030000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

	public const string NAME_DeviceExecutable = "DeviceExecutable";


	/*  FORMAT_TextDocument
	 *
	 *  MTP Format: Text file  (0x3004)
	 *  Suggested MIME Type: text/plain 
	 */

	public static Guid FORMAT_TextDocument => new(0x30040000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

	public const string NAME_TextDocument = "TextDocument";


	/*  FORMAT_HTMLDocument
	 *
	 *  MTP Format: HTML file  (0x3005)
	 *  Suggested MIME Type:
	 */

	public static Guid FORMAT_HTMLDocument => new(0x30050000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

	public const string NAME_HTMLDocument = "HTMLDocument";


	/*  FORMAT_DPOFDocument
	 *
	 *  MTP Format: Digital Print Order Format file  (0x3006)
	 *  Suggested MIME Type:
	 */

	public static Guid FORMAT_DPOFDocument => new(0x30060000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

	public const string NAME_DPOFDocument = "DPOFDocument";


	/*  FORMAT_AIFFFile
	 *
	 *  MTP Format: AIFF file  (0x3007)
	 *  Suggested MIME Type: audio/aiff 
	 */

	public static Guid FORMAT_AIFFFile => new(0x30070000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

	public const string NAME_AIFFFile = "AIFFFile";


	/*  FORMAT_WAVFile
	 *
	 *  MTP Format: WAV file  (0x3008)
	 *  Suggested MIME Type: audio/wav 
	 */

	public static Guid FORMAT_WAVFile => new(0x30080000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

	public const string NAME_WAVFile = "WAVFile";


	/*  FORMAT_MP3File
	 *
	 *  MTP Format: MP3 file  (0x3009)
	 *  Suggested MIME Type: audio/mpeg 
	 */

	public static Guid FORMAT_MP3File => new(0x30090000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

	public const string NAME_MP3File = "MP3File";


	/*  FORMAT_AVIFile
	 *
	 *  MTP Format: AVI file  (0x300A)
	 *  Suggested MIME Type: video/avi 
	 */

	public static Guid FORMAT_AVIFile => new(0x300A0000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

	public const string NAME_AVIFile = "AVIFile";


	/*  FORMAT_MPEGFile
	 *
	 *  MTP Format: MPEG file  (0x300B)
	 *  Suggested MIME Type: video/mpeg 
	 */

	public static Guid FORMAT_MPEGFile => new(0x300B0000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

	public const string NAME_MPEGFile = "MPEGFile";


	/*  FORMAT_ASFFile
	 *
	 *  MTP Format: ASF File  (0x300C)
	 *  Suggested MIME Type: audio/asf 
	 */

	public static Guid FORMAT_ASFFile => new(0x300C0000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

	public const string NAME_ASFFile = "ASFFile";


	/*  FORMAT_UnknownImage
	 *
	 *  MTP Format: Unknown Image  (0x3800)
	 *  Suggested MIME Type:
	 */

	public static Guid FORMAT_UnknownImage => new(0x38000000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

	public const string NAME_UnknownImage = "UnknownImage";


	/*  FORMAT_EXIFImage
	 *
	 *  MTP Format: EXIF/JPEG file  (0x3801)
	 *  Suggested MIME Type: image/jpeg 
	 */

	public static Guid FORMAT_EXIFImage => new(0x38010000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

	public const string NAME_EXIFImage = "EXIFImage";


	/*  FORMAT_TIFFEPImage
	 *
	 *  MTP Format: TIFF/EP (Electronic Photography) file  (0x3802)
	 *  Suggested MIME Type: image/tif 
	 */

	public static Guid FORMAT_TIFFEPImage => new(0x38020000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

	public const string NAME_TIFFEPImage = "TIFFEPImage";


	/*  FORMAT_FlashPixImage
	 *
	 *  MTP Format: Structured Storage Image Format  (0x3803)
	 *  Suggested MIME Type: image/fpx 
	 */

	public static Guid FORMAT_FlashPixImage => new(0x38030000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

	public const string NAME_FlashPixImage = "FlashPixImage";


	/*  FORMAT_BMPImage
	 *
	 *  MTP Format: Microsoft Windows Bitmap file  (0x3804)
	 *  Suggested MIME Type: image/bmp 
	 */

	public static Guid FORMAT_BMPImage => new(0x38040000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

	public const string NAME_BMPImage = "BMPImage";


	/*  FORMAT_CIFFImage
	 *
	 *  MTP Format: Canon Camera Image File format  (0x3805)
	 *  Suggested MIME Type:
	 */

	public static Guid FORMAT_CIFFImage => new(0x38050000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

	public const string NAME_CIFFImage = "CIFFImage";


	/*  FORMAT_GIFImage
	 *
	 *  MTP Format: Graphics Interchange Format  (0x3807)
	 *  Suggested MIME Type: image/gif 
	 */

	public static Guid FORMAT_GIFImage => new(0x38070000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

	public const string NAME_GIFImage = "GIFImage";


	/*  FORMAT_JFIFImage
	 *
	 *  MTP Format: JPEF File Interchange Format  (0x3808)
	 *  Suggested MIME Type: image/jfif 
	 */

	public static Guid FORMAT_JFIFImage => new(0x38080000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

	public const string NAME_JFIFImage = "JFIFImage";


	/*  FORMAT_PCDImage
	 *
	 *  MTP Format: PhotoCD Image Pac  (0x3809)
	 *  Suggested MIME Type: image/pcd 
	 */

	public static Guid FORMAT_PCDImage => new(0x38090000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

	public const string NAME_PCDImage = "PCDImage";


	/*  FORMAT_PICTImage
	 *
	 *  MTP Format: Quickdraw Image Format  (0x380A)
	 *  Suggested MIME Type: image/pict 
	 */

	public static Guid FORMAT_PICTImage => new(0x380A0000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

	public const string NAME_PICTImage = "PICTImage";


	/*  FORMAT_PNGImage
	 *
	 *  MTP Format: Portable Network Graphics  (0x380B)
	 *  Suggested MIME Type: image/png 
	 */

	public static Guid FORMAT_PNGImage => new(0x380B0000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

	public const string NAME_PNGImage = "PNGImage";


	/*  FORMAT_TIFFImage
	 *
	 *  MTP Format: TIFF File  (0x380D)
	 *  Suggested MIME Type: image/tif 
	 */

	public static Guid FORMAT_TIFFImage => new(0x380D0000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

	public const string NAME_TIFFImage = "TIFFImage";


	/*  FORMAT_TIFFITImage
	 *
	 *  MTP Format: TIFF/IT (Graphics Arts) file  (0x380E)
	 *  Suggested MIME Type: image/tif 
	 */

	public static Guid FORMAT_TIFFITImage => new(0x380E0000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

	public const string NAME_TIFFITImage = "TIFFITImage";


	/*  FORMAT_JP2Image
	 *
	 *  MTP Format: JPEG2000 Baseline File Format  (0x380F)
	 *  Suggested MIME Type: image/jp2 
	 */

	public static Guid FORMAT_JP2Image => new(0x380F0000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

	public const string NAME_JP2Image = "JP2Image";


	/*  FORMAT_JPXImage
	 *
	 *  MTP Format: JPEG2000 Extended File Format  (0x3810)
	 *  Suggested MIME Type: image/jp2 
	 */

	public static Guid FORMAT_JPXImage => new(0x38100000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

	public const string NAME_JPXImage = "JPXImage";


	/*  FORMAT_FirmwareFile
	 *
	 *  MTP Format: Firmware  (0xB802)
	 *  Suggested MIME Type:
	 */

	public static Guid FORMAT_FirmwareFile => new(0xB8020000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

	public const string NAME_FirmwareFile = "FirmwareFile";


	/*  FORMAT_WBMPImage
	 *
	 *  MTP Format: Wireless Application Protocol Bitmap Format  (0xB803)
	 *  Suggested MIME Type: image/vnd.wap.wbmp 
	 */

	public static Guid FORMAT_WBMPImage => new(0xB8030000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

	public const string NAME_WBMPImage = "WBMPImage";


	/*  FORMAT_JPEGXRImage
	 *
	 *  MTP Format: JPEG XR, also known as HD Photo  (0xB804)
	 *  Suggested MIME Type: image/vnd.ms-photo 
	 */

	public static Guid FORMAT_JPEGXRImage => new(0xB8040000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

	public const string NAME_JPEGXRImage = "JPEGXRImage";


	/*  FORMAT_HDPhotoImage
	 *
	 *  MTP Format: HD Photo (Windows Media Photo) file  (0xB881)
	 *  Suggested MIME Type: image/vnd.ms-photo 
	 */

	public static Guid FORMAT_HDPhotoImage => new(0xB8810000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

	public const string NAME_HDPhotoImage = "HDPhotoImage";


	/*  FORMAT_UndefinedAudio
	 *
	 *  MTP Format: Undefined Audio  (0xB900)
	 *  Suggested MIME Type:
	 */

	public static Guid FORMAT_UndefinedAudio => new(0xB9000000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

	public const string NAME_UndefinedAudio = "UndefinedAudio";


	/*  FORMAT_WMAFile
	 *
	 *  MTP Format: WMA file  (0xB901)
	 *  Suggested MIME Type: audio/x-ms-wma 
	 */

	public static Guid FORMAT_WMAFile => new(0xB9010000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

	public const string NAME_WMAFile = "WMAFile";


	/*  FORMAT_OGGFile
	 *
	 *  MTP Format: OGG file  (0xB902)
	 *  Suggested MIME Type: audio/x-ogg 
	 */

	public static Guid FORMAT_OGGFile => new(0xB9020000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

	public const string NAME_OGGFile = "OGGFile";


	/*  FORMAT_AACFile
	 *
	 *  MTP Format: AAC file  (0xB903)
	 *  Suggested MIME Type:
	 */

	public static Guid FORMAT_AACFile => new(0xB9030000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

	public const string NAME_AACFile = "AACFile";


	/*  FORMAT_AudibleFile
	 *
	 *  MTP Format: Audible file  (0xB904)
	 *  Suggested MIME Type:
	 */

	public static Guid FORMAT_AudibleFile => new(0xB9040000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

	public const string NAME_AudibleFile = "AudibleFile";


	/*  FORMAT_FLACFile
	 *
	 *  MTP Format: FLAC file  (0xB906)
	 *  Suggested MIME Type:
	 */

	public static Guid FORMAT_FLACFile => new(0xB9060000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

	public const string NAME_FLACFile = "FLACFile";


	/*  FORMAT_QCELPFile
	 *
	 *  MTP Format: QCELP file  (0xB907)
	 *  Suggested MIME Type: audio/qcelp 
	 */

	public static Guid FORMAT_QCELPFile => new(0xB9070000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

	public const string NAME_QCELPFile = "QCELPFile";


	/*  FORMAT_AMRFile
	 *
	 *  MTP Format: AMR file  (0xB908)
	 *  Suggested MIME Type: audio/amr 
	 */

	public static Guid FORMAT_AMRFile => new(0xB9080000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

	public const string NAME_AMRFile = "AMRFile";


	/*  FORMAT_UndefinedVideo
	 *
	 *  MTP Format: Undefined Video  (0xB980)
	 *  Suggested MIME Type:
	 */

	public static Guid FORMAT_UndefinedVideo => new(0xB9890000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

	public const string NAME_UndefinedVideo = "UndefinedVideo";


	/*  FORMAT_WMVFile
	 *
	 *  MTP Format: WMV file  (0xB981)
	 *  Suggested MIME Type: video/x-ms-wmv 
	 */

	public static Guid FORMAT_WMVFile => new(0xB9810000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

	public const string NAME_WMVFile = "WMVFile";


	/*  FORMAT_MPEG4File
	 *
	 *  MTP Format: MPEG-4 Video file  (0xB982)
	 *  Suggested MIME Type: video/mp4v-es 
	 */

	public static Guid FORMAT_MPEG4File => new(0xB9820000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

	public const string NAME_MPEG4File = "MPEG4File";


	/*  FORMAT_MPEG2File
	 *
	 *  MTP Format: MPEG-2 Video file  (0xB983)
	 *  Suggested MIME Type: video/mpeg 
	 */

	public static Guid FORMAT_MPEG2File => new(0xB9830000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

	public const string NAME_MPEG2File = "MPEG2File";


	/*  FORMAT_3GPPFile
	 *
	 *  MTP Format: 3GPP Video file  (0xB984)
	 *  Suggested MIME Type: video/3gpp 
	 */

	public static Guid FORMAT_3GPPFile => new(0xB9840000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

	public const string NAME_3GPPFile = "3GPPFile";


	/*  FORMAT_3GPP2File
	 *
	 *  MTP Format: 3GPP2 Video file  (0xB985)
	 *  Suggested MIME Type: video/3gpp2 
	 */

	public static Guid FORMAT_3GPP2File => new(0xB9850000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

	public const string NAME_3GPP2File = "3GPP2File";


	/*  FORMAT_AVCHDFile
	 *
	 *  MTP Format: AVCHD Video file  (0xB986)
	 *  Suggested MIME Type: video/mp2t 
	 */

	public static Guid FORMAT_AVCHDFile => new(0xB9860000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

	public const string NAME_AVCHDFile = "AVCHDFile";


	/*  FORMAT_ATSCTSFile
	 *
	 *  MTP Format: ATSC-TS Video file  (0xB987)
	 *  Suggested MIME Type: video/mp2t 
	 */

	public static Guid FORMAT_ATSCTSFile => new(0xB9870000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

	public const string NAME_ATSCTSFile = "ATSCTSFile";


	/*  FORMAT_DVBTSFile
	 *
	 *  MTP Format: DVB-TS Video file  (0xB988)
	 *  Suggested MIME Type: video/mp2t 
	 */

	public static Guid FORMAT_DVBTSFile => new(0xB9880000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

	public const string NAME_DVBTSFile = "DVBTSFile";


	/*  FORMAT_UndefinedCollection
	 *
	 *  MTP Format: Undefined Collection  (0xBA00)
	 *  Suggested MIME Type:
	 */

	public static Guid FORMAT_UndefinedCollection => new(0xBA000000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

	public const string NAME_UndefinedCollection = "UndefinedCollection";


	/*  FORMAT_AbstractMultimediaAlbum
	 *
	 *  MTP Format: Abstract Multimedia Album  (0xBA01)
	 *  Suggested MIME Type:
	 */

	public static Guid FORMAT_AbstractMultimediaAlbum => new(0xBA010000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

	public const string NAME_AbstractMultimediaAlbum = "AbstractMultimediaAlbum";


	/*  FORMAT_AbstractImageAlbum
	 *
	 *  MTP Format: Abstract Image Album  (0xBA02)
	 *  Suggested MIME Type:
	 */

	public static Guid FORMAT_AbstractImageAlbum => new(0xBA020000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

	public const string NAME_AbstractImageAlbum = "AbstractImageAlbum";


	/*  FORMAT_AbstractAudioAlbum
	 *
	 *  MTP Format: Abstract Audio Album  (0xBA03)
	 *  Suggested MIME Type:
	 */

	public static Guid FORMAT_AbstractAudioAlbum => new(0xBA030000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

	public const string NAME_AbstractAudioAlbum = "AbstractAudioAlbum";


	/*  FORMAT_AbstractVideoAlbum
	 *
	 *  MTP Format: Abstract Video Album  (0xBA04)
	 *  Suggested MIME Type:
	 */

	public static Guid FORMAT_AbstractVideoAlbum => new(0xBA040000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

	public const string NAME_AbstractVideoAlbum = "AbstractVideoAlbum";


	/*  FORMAT_AbstractAudioVideoAlbum
	 *
	 *  MTP Format: Abstract Audio & Video Playlist  (0xBA05)
	 *  Suggested MIME Type:
	 */

	public static Guid FORMAT_AbstractAudioVideoAlbum => new(0xBA050000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

	public const string NAME_AbstractAudioVideoAlbum = "AbstractAudioVideoAlbum";


	/*  FORMAT_AbstractChapteredProduction
	 *
	 *  MTP Format: Abstract Chaptered Production  (0xBA08)
	 *  Suggested MIME Type:
	 */

	public static Guid FORMAT_AbstractChapteredProduction => new(0xBA080000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

	public const string NAME_AbstractChapteredProduction = "AbstractChapteredProduction";


	/*  FORMAT_AbstractAudioPlaylist
	 *
	 *  MTP Format: Abstract Audio Playlist  (0xBA09)
	 *  Suggested MIME Type:
	 */

	public static Guid FORMAT_AbstractAudioPlaylist => new(0xBA090000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

	public const string NAME_AbstractAudioPlaylist = "AbstractAudioPlaylist";


	/*  FORMAT_AbstractVideoPlaylist
	 *
	 *  MTP Format: Abstract Video Playlist  (0xBA0A)
	 *  Suggested MIME Type:
	 */

	public static Guid FORMAT_AbstractVideoPlaylist => new(0xBA0A0000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

	public const string NAME_AbstractVideoPlaylist = "AbstractVideoPlaylist";


	/*  FORMAT_AbstractMediacast
	 *
	 *  MTP Format: Abstract Mediacast  (0xBA0B)
	 *  Suggested MIME Type:
	 */

	public static Guid FORMAT_AbstractMediacast => new(0xBA0B0000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

	public const string NAME_AbstractMediacast = "AbstractMediacast";


	/*  FORMAT_WPLPlaylist
	 *
	 *  MTP Format: WPL Playlist  (0xBA10)
	 *  Suggested MIME Type:
	 */

	public static Guid FORMAT_WPLPlaylist => new(0xBA100000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

	public const string NAME_WPLPlaylist = "WPLPlaylist";


	/*  FORMAT_M3UPlaylist
	 *
	 *  MTP Format: M3U Playlist  (0xBA11)
	 *  Suggested MIME Type: audio/mpeg-url 
	 */

	public static Guid FORMAT_M3UPlaylist => new(0xBA110000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

	public const string NAME_M3UPlaylist = "M3UPlaylist";


	/*  FORMAT_MPLPlaylist
	 *
	 *  MTP Format: MPL Playlist  (0xBA12)
	 *  Suggested MIME Type:
	 */

	public static Guid FORMAT_MPLPlaylist => new(0xBA120000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

	public const string NAME_MPLPlaylist = "MPLPlaylist";


	/*  FORMAT_ASXPlaylist
	 *
	 *  MTP Format: ASX Playlist  (0xBA13)
	 *  Suggested MIME Type: video/x-ms-asf 
	 */

	public static Guid FORMAT_ASXPlaylist => new(0xBA130000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

	public const string NAME_ASXPlaylist = "ASXPlaylist";


	/*  FORMAT_PSLPlaylist
	 *
	 *  MTP Format: PLS Playlist  (0xBA14)
	 *  Suggested MIME Type:
	 */

	public static Guid FORMAT_PSLPlaylist => new(0xBA140000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

	public const string NAME_PSLPlaylist = "PSLPlaylist";


	/*  FORMAT_UndefinedDocument
	 *
	 *  MTP Format: Undefined Document  (0xBA80)
	 *  Suggested MIME Type:
	 */

	public static Guid FORMAT_UndefinedDocument => new(0xBA800000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

	public const string NAME_UndefinedDocument = "UndefinedDocument";


	/*  FORMAT_AbstractDocument
	 *
	 *  MTP Format: Abstract Document  (0xBA81)
	 *  Suggested MIME Type:
	 */

	public static Guid FORMAT_AbstractDocument => new(0xBA810000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

	public const string NAME_AbstractDocument = "AbstractDocument";


	/*  FORMAT_XMLDocument
	 *
	 *  MTP Format: XML Document  (0xBA82)
	 *  Suggested MIME Type: text/xml 
	 */

	public static Guid FORMAT_XMLDocument => new(0xBA820000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

	public const string NAME_XMLDocument = "XMLDocument";


	/*  FORMAT_WordDocument
	 *
	 *  MTP Format: Microsoft Word Document  (0xBA83)
	 *  Suggested MIME Type: application/msword 
	 */

	public static Guid FORMAT_WordDocument => new(0xBA830000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

	public const string NAME_WordDocument = "WordDocument";


	/*  FORMAT_MHTDocument
	 *
	 *  MTP Format: MHT Compiled HTML Document  (0xBA84)
	 *  Suggested MIME Type: message/rfc822 
	 */

	public static Guid FORMAT_MHTDocument => new(0xBA840000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

	public const string NAME_MHTDocument = "MHTDocument";


	/*  FORMAT_ExcelDocument
	 *
	 *  MTP Format: Microsoft Excel Document  (0xBA85)
	 *  Suggested MIME Type: application/msexcel 
	 */

	public static Guid FORMAT_ExcelDocument => new(0xBA850000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

	public const string NAME_ExcelDocument = "ExcelDocument";


	/*  FORMAT_PowerPointDocument
	 *
	 *  MTP Format:  Microsoft PowerPoint Document  (0xBA86)
	 *  Suggested MIME Type: application/mspowerpoint 
	 */

	public static Guid FORMAT_PowerPointDocument => new(0xBA860000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

	public const string NAME_PowerPointDocument = "PowerPointDocument";


	/*****************************************************************************/
	/*  MTP Object Property Codes for Generic and Media Types                    */
	/*****************************************************************************/

	/// <summary>GenericObj.ObjectID
	/// MTP Property: ()
	/// Type: UInt128 
	/// Form: None 
	/// </summary>

#if NET7_0_OR_GREATER
 	[CorrespondingType(typeof(UInt128))]
#endif
	public static PROPERTYKEY PKEY_GenericObj_ObjectID => new(new(0xEF6B490D, 0x5CD8, 0x437A, 0xAF, 0xFC, 0xDA, 0x8B, 0x60, 0xEE, 0x4A, 0x3C), 2);

	public const string NAME_GenericObj_ObjectID = "ObjectID";


	/// <summary>GenericObj.ReferenceParentID
	/// MTP Property: This write only property is used when creating object references to help hint the responder implementation to the parent item that this object will be associated with.
	/// Type: UInt32 
	/// Form: ObjectID 
	/// </summary>
	[CorrespondingType(typeof(uint))]
	public static PROPERTYKEY PKEY_GenericObj_ReferenceParentID => new(new(0xEF6B490D, 0x5CD8, 0x437A, 0xAF, 0xFC, 0xDA, 0x8B, 0x60, 0xEE, 0x4A, 0x3C), 47);

	public const string NAME_GenericObj_ReferenceParentID = "ReferenceParentID";


	/// <summary>GenericObj.StorageID
	/// MTP Property: Storage ID  (0xDC01)
	/// Type: UInt32 
	/// Form: None 
	/// </summary>

	[CorrespondingType(typeof(uint))]
	public static PROPERTYKEY PKEY_GenericObj_StorageID => new(new(0xEF6B490D, 0x5CD8, 0x437A, 0xAF, 0xFC, 0xDA, 0x8B, 0x60, 0xEE, 0x4A, 0x3C), 23);

	public const string NAME_GenericObj_StorageID = "StorageID";


	/// <summary>GenericObj.ObjectFormat
	/// MTP Property: Object Format  (0xDC02)
	/// Type: UInt16 
	/// Form: None 
	/// </summary>

	[CorrespondingType(typeof(ushort))]
	public static PROPERTYKEY PKEY_GenericObj_ObjectFormat => new(new(0xEF6B490D, 0x5CD8, 0x437A, 0xAF, 0xFC, 0xDA, 0x8B, 0x60, 0xEE, 0x4A, 0x3C), 6);

	public const string NAME_GenericObj_ObjectFormat = "ObjectFormat";


	/// <summary>GenericObj.ProtectionStatus
	/// MTP Property: Protection Status  (0xDC03)
	/// Type: UInt16 
	/// Form: Enum 
	/// </summary>

	[CorrespondingType(typeof(ushort))]
	public static PROPERTYKEY PKEY_GenericObj_ProtectionStatus => new(new(0xEF6B490D, 0x5CD8, 0x437A, 0xAF, 0xFC, 0xDA, 0x8B, 0x60, 0xEE, 0x4A, 0x3C), 26);

	public const string NAME_GenericObj_ProtectionStatus = "ProtectionStatus";


	/// <summary>GenericObj.ObjectSize
	/// MTP Property: Object Size  (0xDC04)
	/// Type: UInt64 
	/// Form: None 
	/// </summary>

	[CorrespondingType(typeof(ulong))]
	public static PROPERTYKEY PKEY_GenericObj_ObjectSize => new(new(0xEF6B490D, 0x5CD8, 0x437A, 0xAF, 0xFC, 0xDA, 0x8B, 0x60, 0xEE, 0x4A, 0x3C), 11);

	public const string NAME_GenericObj_ObjectSize = "ObjectSize";


	/// <summary>GenericObj.AssociationType
	/// MTP Property: Association Type  (0xDC05)
	/// Type: UInt16 
	/// Form: Enum 
	/// </summary>

	[CorrespondingType(typeof(ushort))]
	public static PROPERTYKEY PKEY_GenericObj_AssociationType => new(new(0xEF6B490D, 0x5CD8, 0x437A, 0xAF, 0xFC, 0xDA, 0x8B, 0x60, 0xEE, 0x4A, 0x3C), 32);

	public const string NAME_GenericObj_AssociationType = "AssociationType";


	/// <summary>GenericObj.AssociationDesc
	/// MTP Property: Association Desc  (0xDC06)
	/// Type: UInt16 
	/// Form: Enum 
	/// </summary>

	[CorrespondingType(typeof(ushort))]
	public static PROPERTYKEY PKEY_GenericObj_AssociationDesc => new(new(0xEF6B490D, 0x5CD8, 0x437A, 0xAF, 0xFC, 0xDA, 0x8B, 0x60, 0xEE, 0x4A, 0x3C), 33);

	public const string NAME_GenericObj_AssociationDesc = "AssociationDesc";


	/// <summary>GenericObj.ObjectFileName
	/// MTP Property: Object File Name  (0xDC07)
	/// Type: String 
	/// Form: None/RegEx 
	/// </summary>

	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_GenericObj_ObjectFileName => new(new(0xEF6B490D, 0x5CD8, 0x437A, 0xAF, 0xFC, 0xDA, 0x8B, 0x60, 0xEE, 0x4A, 0x3C), 12);

	public const string NAME_GenericObj_ObjectFileName = "ObjectFileName";


	/// <summary>GenericObj.DateCreated
	/// MTP Property: Date Created  (0xDC08)
	/// Type: String 
	/// Form: DateTime 
	/// </summary>

	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_GenericObj_DateCreated => new(new(0xEF6B490D, 0x5CD8, 0x437A, 0xAF, 0xFC, 0xDA, 0x8B, 0x60, 0xEE, 0x4A, 0x3C), 39);

	public const string NAME_GenericObj_DateCreated = "DateCreated";


	/// <summary>GenericObj.DateModified
	/// MTP Property: Date Modified  (0xDC09)
	/// Type: String 
	/// Form: DateTime 
	/// </summary>

	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_GenericObj_DateModified => new(new(0xEF6B490D, 0x5CD8, 0x437A, 0xAF, 0xFC, 0xDA, 0x8B, 0x60, 0xEE, 0x4A, 0x3C), 40);

	public const string NAME_GenericObj_DateModified = "DateModified";


	/// <summary>GenericObj.Keywords
	/// MTP Property: Keywords  (0xDC0A)
	/// Type: String 
	/// Form: None 
	/// </summary>

	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_GenericObj_Keywords => new(new(0xEF6B490D, 0x5CD8, 0x437A, 0xAF, 0xFC, 0xDA, 0x8B, 0x60, 0xEE, 0x4A, 0x3C), 15);

	public const string NAME_GenericObj_Keywords = "Keywords";


	/// <summary>GenericObj.ParentID
	/// MTP Property: Parent Object  (0xDC0B)
	/// Type: UInt32 
	/// Form: ObjectID 
	/// </summary>

	[CorrespondingType(typeof(uint))]
	public static PROPERTYKEY PKEY_GenericObj_ParentID => new(new(0xEF6B490D, 0x5CD8, 0x437A, 0xAF, 0xFC, 0xDA, 0x8B, 0x60, 0xEE, 0x4A, 0x3C), 3);

	public const string NAME_GenericObj_ParentID = "ParentID";


	/// <summary>GenericObj.AllowedFolderContents
	/// MTP Property: Allowed Folder Contents  (0xDC0C)
	/// Type: ushort 
	/// Form: None 
	/// </summary>

	[CorrespondingType(typeof(ushort))]
	public static PROPERTYKEY PKEY_GenericObj_AllowedFolderContents => new(new(0xEF6B490D, 0x5CD8, 0x437A, 0xAF, 0xFC, 0xDA, 0x8B, 0x60, 0xEE, 0x4A, 0x3C), 34);

	public const string NAME_GenericObj_AllowedFolderContents = "AllowedFolderContents";


	/// <summary>GenericObj.Hidden
	/// MTP Property: Hidden  (0xDC0D)
	/// Type: UInt16 
	/// Form: Enum 
	/// </summary>

	[CorrespondingType(typeof(ushort))]
	public static PROPERTYKEY PKEY_GenericObj_Hidden => new(new(0xEF6B490D, 0x5CD8, 0x437A, 0xAF, 0xFC, 0xDA, 0x8B, 0x60, 0xEE, 0x4A, 0x3C), 28);

	public const string NAME_GenericObj_Hidden = "Hidden";


	/// <summary>GenericObj.SystemObject
	/// MTP Property: System Object  (0xDC0E)
	/// Type: UInt16 
	/// Form: Enum 
	/// </summary>

	[CorrespondingType(typeof(ushort))]
	public static PROPERTYKEY PKEY_GenericObj_SystemObject => new(new(0xEF6B490D, 0x5CD8, 0x437A, 0xAF, 0xFC, 0xDA, 0x8B, 0x60, 0xEE, 0x4A, 0x3C), 29);

	public const string NAME_GenericObj_SystemObject = "SystemObject";


	/// <summary>GenericObj.PersistentUID
	/// MTP Property: Persistent Unique Object ID  (0xDC41)
	/// Type: UInt128 
	/// Form: None 
	/// </summary>

#if NET7_0_OR_GREATER
 	[CorrespondingType(typeof(UInt128))]
#endif
	public static PROPERTYKEY PKEY_GenericObj_PersistentUID => new(new(0xEF6B490D, 0x5CD8, 0x437A, 0xAF, 0xFC, 0xDA, 0x8B, 0x60, 0xEE, 0x4A, 0x3C), 5);

	public const string NAME_GenericObj_PersistentUID = "PersistentUID";


	/// <summary>GenericObj.SyncID
	/// MTP Property: Sync ID  (0xDC42)
	/// Type: String 
	/// Form: None 
	/// </summary>

	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_GenericObj_SyncID => new(new(0xEF6B490D, 0x5CD8, 0x437A, 0xAF, 0xFC, 0xDA, 0x8B, 0x60, 0xEE, 0x4A, 0x3C), 16);

	public const string NAME_GenericObj_SyncID = "SyncID";


	/// <summary>GenericObj.PropertyBag
	/// MTP Property: Property Bag  (0xDC43)
	/// Type: ushort 
	/// Form: LongString 
	/// </summary>

	[CorrespondingType(typeof(ushort))]
	public static PROPERTYKEY PKEY_GenericObj_PropertyBag => new(new(0xEF6B490D, 0x5CD8, 0x437A, 0xAF, 0xFC, 0xDA, 0x8B, 0x60, 0xEE, 0x4A, 0x3C), 35);

	public const string NAME_GenericObj_PropertyBag = "PropertyBag";


	/// <summary>GenericObj.Name
	/// MTP Property: Name  (0xDC44)
	/// Type: String 
	/// Form: None 
	/// </summary>

	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_GenericObj_Name => new(new(0xEF6B490D, 0x5CD8, 0x437A, 0xAF, 0xFC, 0xDA, 0x8B, 0x60, 0xEE, 0x4A, 0x3C), 4);

	public const string NAME_GenericObj_Name = "Name";


	/// <summary>MediaObj.Artist
	/// MTP Property: Artist  (0xDC46)
	/// Type: String 
	/// Form: None 
	/// </summary>

	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_MediaObj_Artist => new(new(0x2ED8BA05, 0x0AD3, 0x42DC, 0xB0, 0xD0, 0xBC, 0x95, 0xAC, 0x39, 0x6A, 0xC8), 24);

	public const string NAME_MediaObj_Artist = "Artist";


	/// <summary>GenericObj.DateAuthored
	/// MTP Property: Date Authored  (0xDC47)
	/// Type: String 
	/// Form: None 
	/// </summary>

	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_GenericObj_DateAuthored => new(new(0xEF6B490D, 0x5CD8, 0x437A, 0xAF, 0xFC, 0xDA, 0x8B, 0x60, 0xEE, 0x4A, 0x3C), 41);

	public const string NAME_GenericObj_DateAuthored = "DateAuthored";


	/// <summary>GenericObj.Description
	/// MTP Property: Description  (0xDC48)
	/// Type: ushort 
	/// Form: LongString 
	/// </summary>

	[CorrespondingType(typeof(ushort))]
	public static PROPERTYKEY PKEY_GenericObj_Description => new(new(0xEF6B490D, 0x5CD8, 0x437A, 0xAF, 0xFC, 0xDA, 0x8B, 0x60, 0xEE, 0x4A, 0x3C), 45);

	public const string NAME_GenericObj_Description = "Description";


	/// <summary>GenericObj.LanguageLocale
	/// MTP Property: Language Locale  (0xDC4A)
	/// Type: String 
	/// Form: RegEx 
	/// </summary>

	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_GenericObj_LanguageLocale => new(new(0xEF6B490D, 0x5CD8, 0x437A, 0xAF, 0xFC, 0xDA, 0x8B, 0x60, 0xEE, 0x4A, 0x3C), 27);

	public const string NAME_GenericObj_LanguageLocale = "LanguageLocale";


	/// <summary>GenericObj.Copyright
	/// MTP Property: Copyright Information  (0xDC4B)
	/// Type: ushort 
	/// Form: LongString 
	/// </summary>

	[CorrespondingType(typeof(ushort))]
	public static PROPERTYKEY PKEY_GenericObj_Copyright => new(new(0xEF6B490D, 0x5CD8, 0x437A, 0xAF, 0xFC, 0xDA, 0x8B, 0x60, 0xEE, 0x4A, 0x3C), 38);

	public const string NAME_GenericObj_Copyright = "Copyright";


	/// <summary>VideoObj.Source
	/// MTP Property: Source  (0xDC4C)
	/// Type: String 
	/// Form: None 
	/// </summary>

	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_VideoObj_Source => new(new(0x346F2163, 0xF998, 0x4146, 0x8B, 0x01, 0xD1, 0x9B, 0x4C, 0x00, 0xDE, 0x9A), 4);

	public const string NAME_VideoObj_Source = "Source";


	/// <summary>MediaObj.GeographicOrigin
	/// MTP Property: Origin Location  (0xDC4D)
	/// Type: String 
	/// Form: None 
	/// </summary>

	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_MediaObj_GeographicOrigin => new(new(0x2ED8BA05, 0x0AD3, 0x42DC, 0xB0, 0xD0, 0xBC, 0x95, 0xAC, 0x39, 0x6A, 0xC8), 40);

	public const string NAME_MediaObj_GeographicOrigin = "GeographicOrigin";


	/// <summary>GenericObj.DateAdded
	/// MTP Property: Date Added  (0xDC4E)
	/// Type: String 
	/// Form: DateTime 
	/// </summary>

	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_GenericObj_DateAdded => new(new(0xEF6B490D, 0x5CD8, 0x437A, 0xAF, 0xFC, 0xDA, 0x8B, 0x60, 0xEE, 0x4A, 0x3C), 36);

	public const string NAME_GenericObj_DateAdded = "DateAdded";


	/// <summary>GenericObj.NonConsumable
	/// MTP Property: Non-Consumable  (0xDC4F)
	/// Type: UInt8 
	/// Form: Enum 
	/// </summary>

	[CorrespondingType(typeof(byte))]
	public static PROPERTYKEY PKEY_GenericObj_NonConsumable => new(new(0xEF6B490D, 0x5CD8, 0x437A, 0xAF, 0xFC, 0xDA, 0x8B, 0x60, 0xEE, 0x4A, 0x3C), 30);

	public const string NAME_GenericObj_NonConsumable = "NonConsumable";


	/// <summary>GenericObj.Corrupt
	/// MTP Property: Corrupt  (0xDC50)
	/// Type: UInt8 
	/// Form: Enum 
	/// </summary>

	[CorrespondingType(typeof(byte))]
	public static PROPERTYKEY PKEY_GenericObj_Corrupt => new(new(0xEF6B490D, 0x5CD8, 0x437A, 0xAF, 0xFC, 0xDA, 0x8B, 0x60, 0xEE, 0x4A, 0x3C), 37);

	public const string NAME_GenericObj_Corrupt = "Corrupt";


	/// <summary>MediaObj.Width
	/// MTP Property: Width  (0xDC87)
	/// Type: UInt32 
	/// Form: Range 
	/// </summary>

	[CorrespondingType(typeof(uint))]
	public static PROPERTYKEY PKEY_MediaObj_Width => new(new(0x2ED8BA05, 0x0AD3, 0x42DC, 0xB0, 0xD0, 0xBC, 0x95, 0xAC, 0x39, 0x6A, 0xC8), 22);

	public const string NAME_MediaObj_Width = "Width";


	/// <summary>MediaObj.Height
	/// MTP Property: Height  (0xDC88)
	/// Type: UInt32 
	/// Form: Range 
	/// </summary>

	[CorrespondingType(typeof(uint))]
	public static PROPERTYKEY PKEY_MediaObj_Height => new(new(0x2ED8BA05, 0x0AD3, 0x42DC, 0xB0, 0xD0, 0xBC, 0x95, 0xAC, 0x39, 0x6A, 0xC8), 23);

	public const string NAME_MediaObj_Height = "Height";


	/// <summary>MediaObj.Duration
	/// MTP Property: Duration  (0xDC89)
	/// Type: UInt32 
	/// Form: None 
	/// </summary>

	[CorrespondingType(typeof(uint))]
	public static PROPERTYKEY PKEY_MediaObj_Duration => new(new(0x2ED8BA05, 0x0AD3, 0x42DC, 0xB0, 0xD0, 0xBC, 0x95, 0xAC, 0x39, 0x6A, 0xC8), 19);

	public const string NAME_MediaObj_Duration = "Duration";


	/// <summary>MediaObj.UserRating
	/// MTP Property: Rating  (0xDC8A)
	/// Type: UInt16 
	/// Form: Range 
	/// </summary>

	[CorrespondingType(typeof(ushort))]
	public static PROPERTYKEY PKEY_MediaObj_UserRating => new(new(0x2ED8BA05, 0x0AD3, 0x42DC, 0xB0, 0xD0, 0xBC, 0x95, 0xAC, 0x39, 0x6A, 0xC8), 17);

	public const string NAME_MediaObj_UserRating = "UserRating";


	/// <summary>MediaObj.Track
	/// MTP Property: Track  (0xDC8B)
	/// Type: UInt16 
	/// Form: None 
	/// </summary>

	[CorrespondingType(typeof(ushort))]
	public static PROPERTYKEY PKEY_MediaObj_Track => new(new(0x2ED8BA05, 0x0AD3, 0x42DC, 0xB0, 0xD0, 0xBC, 0x95, 0xAC, 0x39, 0x6A, 0xC8), 43);

	public const string NAME_MediaObj_Track = "Track";


	/// <summary>MediaObj.Genre
	/// MTP Property: Genre  (0xDC8C)
	/// Type: String 
	/// Form: Enum 
	/// </summary>

	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_MediaObj_Genre => new(new(0x2ED8BA05, 0x0AD3, 0x42DC, 0xB0, 0xD0, 0xBC, 0x95, 0xAC, 0x39, 0x6A, 0xC8), 32);

	public const string NAME_MediaObj_Genre = "Genre";


	/// <summary>MediaObj.Credits
	/// MTP Property: Credits  (0xDC8D)
	/// Type: ushort 
	/// Form: LongString 
	/// </summary>

	[CorrespondingType(typeof(ushort))]
	public static PROPERTYKEY PKEY_MediaObj_Credits => new(new(0x2ED8BA05, 0x0AD3, 0x42DC, 0xB0, 0xD0, 0xBC, 0x95, 0xAC, 0x39, 0x6A, 0xC8), 47);

	public const string NAME_MediaObj_Credits = "Credits";


	/// <summary>AudioObj.Lyrics
	/// MTP Property: Lyrics  (0xDC8E)
	/// Type: ushort 
	/// Form: LongString 
	/// </summary>

	[CorrespondingType(typeof(ushort))]
	public static PROPERTYKEY PKEY_AudioObj_Lyrics => new(new(0xB324F56A, 0xDC5D, 0x46E5, 0xB6, 0xDF, 0xD2, 0xEA, 0x41, 0x48, 0x88, 0xC6), 6);

	public const string NAME_AudioObj_Lyrics = "Lyrics";


	/// <summary>MediaObj.SubscriptionContentID
	/// MTP Property: Subscription Content ID  (0xDC8F)
	/// Type: String 
	/// Form: RegEx 
	/// </summary>

	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_MediaObj_SubscriptionContentID => new(new(0x2ED8BA05, 0x0AD3, 0x42DC, 0xB0, 0xD0, 0xBC, 0x95, 0xAC, 0x39, 0x6A, 0xC8), 5);

	public const string NAME_MediaObj_SubscriptionContentID = "SubscriptionContentID";


	/// <summary>MediaObj.Producer
	/// MTP Property: Produced By  (0xDC90)
	/// Type: String 
	/// Form: None 
	/// </summary>

	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_MediaObj_Producer => new(new(0x2ED8BA05, 0x0AD3, 0x42DC, 0xB0, 0xD0, 0xBC, 0x95, 0xAC, 0x39, 0x6A, 0xC8), 45);

	public const string NAME_MediaObj_Producer = "Producer";


	/// <summary>MediaObj.UseCount
	/// MTP Property: Use Count  (0xDC91)
	/// Type: UInt32 
	/// Form: None 
	/// </summary>

	[CorrespondingType(typeof(uint))]
	public static PROPERTYKEY PKEY_MediaObj_UseCount => new(new(0x2ED8BA05, 0x0AD3, 0x42DC, 0xB0, 0xD0, 0xBC, 0x95, 0xAC, 0x39, 0x6A, 0xC8), 6);

	public const string NAME_MediaObj_UseCount = "UseCount";


	/// <summary>MediaObj.SkipCount
	/// MTP Property: Skip Count  (0xDC92)
	/// Type: UInt32 
	/// Form: None 
	/// </summary>

	[CorrespondingType(typeof(uint))]
	public static PROPERTYKEY PKEY_MediaObj_SkipCount => new(new(0x2ED8BA05, 0x0AD3, 0x42DC, 0xB0, 0xD0, 0xBC, 0x95, 0xAC, 0x39, 0x6A, 0xC8), 7);

	public const string NAME_MediaObj_SkipCount = "SkipCount";


	/// <summary>GenericObj.DateAccessed
	/// MTP Property: Last Accessed  (0xDC93)
	/// Type: String 
	/// Form: DateTime 
	/// </summary>

	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_GenericObj_DateAccessed => new(new(0xEF6B490D, 0x5CD8, 0x437A, 0xAF, 0xFC, 0xDA, 0x8B, 0x60, 0xEE, 0x4A, 0x3C), 42);

	public const string NAME_GenericObj_DateAccessed = "DateAccessed";


	/// <summary>MediaObj.ParentalRating
	/// MTP Property: Parental Rating  (0xDC94)
	/// Type: String 
	/// Form: None 
	/// </summary>

	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_MediaObj_ParentalRating => new(new(0x2ED8BA05, 0x0AD3, 0x42DC, 0xB0, 0xD0, 0xBC, 0x95, 0xAC, 0x39, 0x6A, 0xC8), 9);

	public const string NAME_MediaObj_ParentalRating = "ParentalRating";


	/// <summary>MediaObj.MediaType
	/// MTP Property: Meta Genre  (0xDC95)
	/// Type: UInt16 
	/// Form: Enum 
	/// </summary>

	[CorrespondingType(typeof(ushort))]
	public static PROPERTYKEY PKEY_MediaObj_MediaType => new(new(0x2ED8BA05, 0x0AD3, 0x42DC, 0xB0, 0xD0, 0xBC, 0x95, 0xAC, 0x39, 0x6A, 0xC8), 10);

	public const string NAME_MediaObj_MediaType = "MediaType";


	/// <summary>MediaObj.Composer
	/// MTP Property: Composer  (0xDC96)
	/// Type: String 
	/// Form: None 
	/// </summary>

	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_MediaObj_Composer => new(new(0x2ED8BA05, 0x0AD3, 0x42DC, 0xB0, 0xD0, 0xBC, 0x95, 0xAC, 0x39, 0x6A, 0xC8), 11);

	public const string NAME_MediaObj_Composer = "Composer";


	/// <summary>MediaObj.EffectiveRating
	/// MTP Property: Effective Rating  (0xDC97)
	/// Type: UInt16 
	/// Form: Range 
	/// </summary>

	[CorrespondingType(typeof(ushort))]
	public static PROPERTYKEY PKEY_MediaObj_EffectiveRating => new(new(0x2ED8BA05, 0x0AD3, 0x42DC, 0xB0, 0xD0, 0xBC, 0x95, 0xAC, 0x39, 0x6A, 0xC8), 12);

	public const string NAME_MediaObj_EffectiveRating = "EffectiveRating";


	/// <summary>MediaObj.Subtitle
	/// MTP Property: Subtitle  (0xDC98)
	/// Type: String 
	/// Form: None 
	/// </summary>

	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_MediaObj_Subtitle => new(new(0x2ED8BA05, 0x0AD3, 0x42DC, 0xB0, 0xD0, 0xBC, 0x95, 0xAC, 0x39, 0x6A, 0xC8), 13);

	public const string NAME_MediaObj_Subtitle = "Subtitle";


	/// <summary>MediaObj.DateOriginalRelease
	/// MTP Property: Original Release Date  (0xDC99)
	/// Type: String 
	/// Form: DateTime 
	/// </summary>

	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_MediaObj_DateOriginalRelease => new(new(0x2ED8BA05, 0x0AD3, 0x42DC, 0xB0, 0xD0, 0xBC, 0x95, 0xAC, 0x39, 0x6A, 0xC8), 41);

	public const string NAME_MediaObj_DateOriginalRelease = "DateOriginalRelease";


	/// <summary>MediaObj.AlbumName
	/// MTP Property: Album Name  (0xDC9A)
	/// Type: String 
	/// Form: None 
	/// </summary>

	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_MediaObj_AlbumName => new(new(0x2ED8BA05, 0x0AD3, 0x42DC, 0xB0, 0xD0, 0xBC, 0x95, 0xAC, 0x39, 0x6A, 0xC8), 42);

	public const string NAME_MediaObj_AlbumName = "AlbumName";


	/// <summary>MediaObj.AlbumArtist
	/// MTP Property: Album Artist  (0xDC9B)
	/// Type: String 
	/// Form: None 
	/// </summary>

	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_MediaObj_AlbumArtist => new(new(0x2ED8BA05, 0x0AD3, 0x42DC, 0xB0, 0xD0, 0xBC, 0x95, 0xAC, 0x39, 0x6A, 0xC8), 25);

	public const string NAME_MediaObj_AlbumArtist = "AlbumArtist";


	/// <summary>MediaObj.Mood
	/// MTP Property: Mood  (0xDC9C)
	/// Type: String 
	/// Form: None 
	/// </summary>

	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_MediaObj_Mood => new(new(0x2ED8BA05, 0x0AD3, 0x42DC, 0xB0, 0xD0, 0xBC, 0x95, 0xAC, 0x39, 0x6A, 0xC8), 44);

	public const string NAME_MediaObj_Mood = "Mood";


	/// <summary>GenericObj.DRMStatus
	/// MTP Property: DRM Status  (0xDC9D)
	/// Type: UInt16 
	/// Form: Enum 
	/// </summary>

	[CorrespondingType(typeof(ushort))]
	public static PROPERTYKEY PKEY_GenericObj_DRMStatus => new(new(0xEF6B490D, 0x5CD8, 0x437A, 0xAF, 0xFC, 0xDA, 0x8B, 0x60, 0xEE, 0x4A, 0x3C), 31);

	public const string NAME_GenericObj_DRMStatus = "DRMStatus";


	/// <summary>GenericObj.SubDescription
	/// MTP Property: Sub Description  (0xDC9E)
	/// Type: ushort 
	/// Form: LongString 
	/// </summary>

	[CorrespondingType(typeof(ushort))]
	public static PROPERTYKEY PKEY_GenericObj_SubDescription => new(new(0xEF6B490D, 0x5CD8, 0x437A, 0xAF, 0xFC, 0xDA, 0x8B, 0x60, 0xEE, 0x4A, 0x3C), 46);

	public const string NAME_GenericObj_SubDescription = "SubDescription";


	/// <summary>ImageObj.IsCropped
	/// MTP Property: Is Cropped  (0xDCD1)
	/// Type: UInt16 
	/// Form: Enum 
	/// </summary>

	[CorrespondingType(typeof(ushort))]
	public static PROPERTYKEY PKEY_ImageObj_IsCropped => new(new(0x63D64908, 0x9FA1, 0x479F, 0x85, 0xBA, 0x99, 0x52, 0x21, 0x64, 0x47, 0xDB), 4);

	public const string NAME_ImageObj_IsCropped = "IsCropped";


	/// <summary>ImageObj.IsColorCorrected
	/// MTP Property: Is Colour Corrected  (0xDCD2)
	/// Type: UInt16 
	/// Form: Enum 
	/// </summary>

	[CorrespondingType(typeof(ushort))]
	public static PROPERTYKEY PKEY_ImageObj_IsColorCorrected => new(new(0x63D64908, 0x9FA1, 0x479F, 0x85, 0xBA, 0x99, 0x52, 0x21, 0x64, 0x47, 0xDB), 5);

	public const string NAME_ImageObj_IsColorCorrected = "IsColorCorrected";


	/// <summary>ImageObj.ImageBitDepth
	/// MTP Property: Image Bit Depth  (0xDCD3)
	/// Type: UInt32 
	/// Form: Range/Enum 
	/// </summary>

	[CorrespondingType(typeof(uint))]
	public static PROPERTYKEY PKEY_ImageObj_ImageBitDepth => new(new(0x63D64908, 0x9FA1, 0x479F, 0x85, 0xBA, 0x99, 0x52, 0x21, 0x64, 0x47, 0xDB), 3);

	public const string NAME_ImageObj_ImageBitDepth = "ImageBitDepth";


	/// <summary>ImageObj.Aperature
	/// MTP Property: Fnumber  (0xDCD4)
	/// Type: UInt16 
	/// Form: Enum 
	/// </summary>

	[CorrespondingType(typeof(ushort))]
	public static PROPERTYKEY PKEY_ImageObj_Aperature => new(new(0x63D64908, 0x9FA1, 0x479F, 0x85, 0xBA, 0x99, 0x52, 0x21, 0x64, 0x47, 0xDB), 6);

	public const string NAME_ImageObj_Aperature = "Aperature";


	/// <summary>ImageObj.Exposure
	/// MTP Property: Exposure Time  (0xDCD5)
	/// Type: UInt32 
	/// Form: Range/Enum 
	/// </summary>

	[CorrespondingType(typeof(uint))]
	public static PROPERTYKEY PKEY_ImageObj_Exposure => new(new(0x63D64908, 0x9FA1, 0x479F, 0x85, 0xBA, 0x99, 0x52, 0x21, 0x64, 0x47, 0xDB), 7);

	public const string NAME_ImageObj_Exposure = "Exposure";


	/// <summary>ImageObj.ISOSpeed
	/// MTP Property: Exposure Index  (0xDCD6)
	/// Type: UInt16 
	/// Form: Range/Enum 
	/// </summary>

	[CorrespondingType(typeof(ushort))]
	public static PROPERTYKEY PKEY_ImageObj_ISOSpeed => new(new(0x63D64908, 0x9FA1, 0x479F, 0x85, 0xBA, 0x99, 0x52, 0x21, 0x64, 0x47, 0xDB), 8);

	public const string NAME_ImageObj_ISOSpeed = "ISOSpeed";


	/// <summary>MediaObj.Owner
	/// MTP Property: Owner  (0xDD5D)
	/// Type: String 
	/// Form: None 
	/// </summary>

	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_MediaObj_Owner => new(new(0x2ED8BA05, 0x0AD3, 0x42DC, 0xB0, 0xD0, 0xBC, 0x95, 0xAC, 0x39, 0x6A, 0xC8), 26);

	public const string NAME_MediaObj_Owner = "Owner";


	/// <summary>MediaObj.Editor
	/// MTP Property: Editor  (0xDD5E)
	/// Type: String 
	/// Form: None 
	/// </summary>

	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_MediaObj_Editor => new(new(0x2ED8BA05, 0x0AD3, 0x42DC, 0xB0, 0xD0, 0xBC, 0x95, 0xAC, 0x39, 0x6A, 0xC8), 27);

	public const string NAME_MediaObj_Editor = "Editor";


	/// <summary>MediaObj.WebMaster
	/// MTP Property: WebMaster  (0xDD5F)
	/// Type: String 
	/// Form: None 
	/// </summary>

	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_MediaObj_WebMaster => new(new(0x2ED8BA05, 0x0AD3, 0x42DC, 0xB0, 0xD0, 0xBC, 0x95, 0xAC, 0x39, 0x6A, 0xC8), 28);

	public const string NAME_MediaObj_WebMaster = "WebMaster";


	/// <summary>MediaObj.URLSource
	/// MTP Property: URL Source  (0xDD60)
	/// Type: String 
	/// Form: None 
	/// </summary>

	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_MediaObj_URLSource => new(new(0x2ED8BA05, 0x0AD3, 0x42DC, 0xB0, 0xD0, 0xBC, 0x95, 0xAC, 0x39, 0x6A, 0xC8), 29);

	public const string NAME_MediaObj_URLSource = "URLSource";


	/// <summary>MediaObj.URLLink
	/// MTP Property: URL Destination  (0xDD61)
	/// Type: String 
	/// Form: None 
	/// </summary>

	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_MediaObj_URLLink => new(new(0x2ED8BA05, 0x0AD3, 0x42DC, 0xB0, 0xD0, 0xBC, 0x95, 0xAC, 0x39, 0x6A, 0xC8), 30);

	public const string NAME_MediaObj_URLLink = "URLLink";


	/// <summary>MediaObj.BookmarkTime
	/// MTP Property: Time Bookmark  (0xDD62)
	/// Type: UInt32 
	/// Form: None 
	/// </summary>

	[CorrespondingType(typeof(uint))]
	public static PROPERTYKEY PKEY_MediaObj_BookmarkTime => new(new(0x2ED8BA05, 0x0AD3, 0x42DC, 0xB0, 0xD0, 0xBC, 0x95, 0xAC, 0x39, 0x6A, 0xC8), 33);

	public const string NAME_MediaObj_BookmarkTime = "BookmarkTime";


	/// <summary>MediaObj.BookmarkObject
	/// MTP Property: Object Bookmark  (0xDD63)
	/// Type: UInt32 
	/// Form: ObjectID 
	/// </summary>

	[CorrespondingType(typeof(uint))]
	public static PROPERTYKEY PKEY_MediaObj_BookmarkObject => new(new(0x2ED8BA05, 0x0AD3, 0x42DC, 0xB0, 0xD0, 0xBC, 0x95, 0xAC, 0x39, 0x6A, 0xC8), 34);

	public const string NAME_MediaObj_BookmarkObject = "BookmarkObject";


	/// <summary>MediaObj.BookmarkByte
	/// MTP Property: Byte Bookmark  (0xDD64)
	/// Type: UInt64 
	/// Form: None 
	/// </summary>

	[CorrespondingType(typeof(ulong))]
	public static PROPERTYKEY PKEY_MediaObj_BookmarkByte => new(new(0x2ED8BA05, 0x0AD3, 0x42DC, 0xB0, 0xD0, 0xBC, 0x95, 0xAC, 0x39, 0x6A, 0xC8), 36);

	public const string NAME_MediaObj_BookmarkByte = "BookmarkByte";


	/// <summary>GenericObj.DateRevised
	/// MTP Property: Last Build Date  (0xDD70)
	/// Type: String 
	/// Form: DateTime 
	/// </summary>

	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_GenericObj_DateRevised => new(new(0xEF6B490D, 0x5CD8, 0x437A, 0xAF, 0xFC, 0xDA, 0x8B, 0x60, 0xEE, 0x4A, 0x3C), 43);

	public const string NAME_GenericObj_DateRevised = "DateRevised";


	/// <summary>GenericObj.TimeToLive
	/// MTP Property: Time To Live  (0xDD71)
	/// Type: UInt64 
	/// Form: None 
	/// </summary>

	[CorrespondingType(typeof(ulong))]
	public static PROPERTYKEY PKEY_GenericObj_TimeToLive => new(new(0xEF6B490D, 0x5CD8, 0x437A, 0xAF, 0xFC, 0xDA, 0x8B, 0x60, 0xEE, 0x4A, 0x3C), 44);

	public const string NAME_GenericObj_TimeToLive = "TimeToLive";


	/// <summary>MediaObj.MediaUID
	/// MTP Property: Media GUID  (0xDD72)
	/// Type: String 
	/// Form: None 
	/// </summary>

	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_MediaObj_MediaUID => new(new(0x2ED8BA05, 0x0AD3, 0x42DC, 0xB0, 0xD0, 0xBC, 0x95, 0xAC, 0x39, 0x6A, 0xC8), 38);

	public const string NAME_MediaObj_MediaUID = "MediaUID";


	/// <summary>MediaObj.TotalBitRate
	/// MTP Property: Total Bit Rate  (0xDE91)
	/// Type: UInt32 
	/// Form: Range/Enum 
	/// </summary>

	[CorrespondingType(typeof(uint))]
	public static PROPERTYKEY PKEY_MediaObj_TotalBitRate => new(new(0x2ED8BA05, 0x0AD3, 0x42DC, 0xB0, 0xD0, 0xBC, 0x95, 0xAC, 0x39, 0x6A, 0xC8), 2);

	public const string NAME_MediaObj_TotalBitRate = "TotalBitRate";


	/// <summary>MediaObj.BitRateType
	/// MTP Property: Bit Rate Type  (0xDE92)
	/// Type: UInt16 
	/// Form: Enum 
	/// </summary>

	[CorrespondingType(typeof(ushort))]
	public static PROPERTYKEY PKEY_MediaObj_BitRateType => new(new(0x2ED8BA05, 0x0AD3, 0x42DC, 0xB0, 0xD0, 0xBC, 0x95, 0xAC, 0x39, 0x6A, 0xC8), 3);

	public const string NAME_MediaObj_BitRateType = "BitRateType";


	/// <summary>MediaObj.SampleRate
	/// MTP Property: Sample Rate  (0xDE93)
	/// Type: UInt32 
	/// Form: Range/Enum 
	/// </summary>

	[CorrespondingType(typeof(uint))]
	public static PROPERTYKEY PKEY_MediaObj_SampleRate => new(new(0x2ED8BA05, 0x0AD3, 0x42DC, 0xB0, 0xD0, 0xBC, 0x95, 0xAC, 0x39, 0x6A, 0xC8), 15);

	public const string NAME_MediaObj_SampleRate = "SampleRate";


	/// <summary>AudioObj.Channels
	/// MTP Property: Number of Channels  (0xDE94)
	/// Type: UInt16 
	/// Form: Enum 
	/// </summary>

	[CorrespondingType(typeof(ushort))]
	public static PROPERTYKEY PKEY_AudioObj_Channels => new(new(0xB324F56A, 0xDC5D, 0x46E5, 0xB6, 0xDF, 0xD2, 0xEA, 0x41, 0x48, 0x88, 0xC6), 10);

	public const string NAME_AudioObj_Channels = "Channels";


	/// <summary>AudioObj.AudioBitDepth
	/// MTP Property: Audio Bit Depth  (0xDE95)
	/// Type: UInt32 
	/// Form: Enum 
	/// </summary>

	[CorrespondingType(typeof(uint))]
	public static PROPERTYKEY PKEY_AudioObj_AudioBitDepth => new(new(0xB324F56A, 0xDC5D, 0x46E5, 0xB6, 0xDF, 0xD2, 0xEA, 0x41, 0x48, 0x88, 0xC6), 12);

	public const string NAME_AudioObj_AudioBitDepth = "AudioBitDepth";


	/// <summary>AudioObj.AudioBlockAlignment
	/// MTP Property: Audio Block Alignment  (0xDE96)
	/// Type: UInt32 
	/// Form: None 
	/// </summary>

	[CorrespondingType(typeof(uint))]
	public static PROPERTYKEY PKEY_AudioObj_AudioBlockAlignment => new(new(0xB324F56A, 0xDC5D, 0x46E5, 0xB6, 0xDF, 0xD2, 0xEA, 0x41, 0x48, 0x88, 0xC6), 13);

	public const string NAME_AudioObj_AudioBlockAlignment = "AudioBlockAlignment";


	/// <summary>VideoObj.ScanType
	/// MTP Property: Video Scan Type  (0xDE97)
	/// Type: UInt16 
	/// Form: Enum 
	/// </summary>

	[CorrespondingType(typeof(ushort))]
	public static PROPERTYKEY PKEY_VideoObj_ScanType => new(new(0x346F2163, 0xF998, 0x4146, 0x8B, 0x01, 0xD1, 0x9B, 0x4C, 0x00, 0xDE, 0x9A), 12);

	public const string NAME_VideoObj_ScanType = "ScanType";


	/// <summary>AudioObj.AudioFormatCode
	/// MTP Property: Audio WAVE Codec  (0xDE99)
	/// Type: UInt32 
	/// Form: Enum 
	/// </summary>

	[CorrespondingType(typeof(uint))]
	public static PROPERTYKEY PKEY_AudioObj_AudioFormatCode => new(new(0xB324F56A, 0xDC5D, 0x46E5, 0xB6, 0xDF, 0xD2, 0xEA, 0x41, 0x48, 0x88, 0xC6), 11);

	public const string NAME_AudioObj_AudioFormatCode = "AudioFormatCode";


	/// <summary>AudioObj.AudioBitRate
	/// MTP Property: Audio Bit Rate  (0xDE9A)
	/// Type: UInt32 
	/// Form: Range/Enum 
	/// </summary>

	[CorrespondingType(typeof(uint))]
	public static PROPERTYKEY PKEY_AudioObj_AudioBitRate => new(new(0xB324F56A, 0xDC5D, 0x46E5, 0xB6, 0xDF, 0xD2, 0xEA, 0x41, 0x48, 0x88, 0xC6), 9);

	public const string NAME_AudioObj_AudioBitRate = "AudioBitRate";


	/// <summary>VideoObj.VideoFormatCode
	/// MTP Property: Video FourCC Codec  (0xDE9B)
	/// Type: UInt32 
	/// Form: Enum 
	/// </summary>

	[CorrespondingType(typeof(uint))]
	public static PROPERTYKEY PKEY_VideoObj_VideoFormatCode => new(new(0x346F2163, 0xF998, 0x4146, 0x8B, 0x01, 0xD1, 0x9B, 0x4C, 0x00, 0xDE, 0x9A), 14);

	public const string NAME_VideoObj_VideoFormatCode = "VideoFormatCode";


	/// <summary>VideoObj.VideoBitRate
	/// MTP Property: Video Bit Rate  (0xDE9C)
	/// Type: UInt32 
	/// Form: Range/Enum 
	/// </summary>

	[CorrespondingType(typeof(uint))]
	public static PROPERTYKEY PKEY_VideoObj_VideoBitRate => new(new(0x346F2163, 0xF998, 0x4146, 0x8B, 0x01, 0xD1, 0x9B, 0x4C, 0x00, 0xDE, 0x9A), 13);

	public const string NAME_VideoObj_VideoBitRate = "VideoBitRate";


	/// <summary>VideoObj.VideoFrameRate
	/// MTP Property: Frames Per Thousand Seconds  (0xDE9D)
	/// Type: UInt32 
	/// Form: Range/Enum 
	/// </summary>

	[CorrespondingType(typeof(uint))]
	public static PROPERTYKEY PKEY_VideoObj_VideoFrameRate => new(new(0x346F2163, 0xF998, 0x4146, 0x8B, 0x01, 0xD1, 0x9B, 0x4C, 0x00, 0xDE, 0x9A), 15);

	public const string NAME_VideoObj_VideoFrameRate = "VideoFrameRate";


	/// <summary>VideoObj.KeyFrameDistance
	/// MTP Property: Key Frame Distance  (0xDE9E)
	/// Type: UInt32 
	/// Form: Range 
	/// </summary>

	[CorrespondingType(typeof(uint))]
	public static PROPERTYKEY PKEY_VideoObj_KeyFrameDistance => new(new(0x346F2163, 0xF998, 0x4146, 0x8B, 0x01, 0xD1, 0x9B, 0x4C, 0x00, 0xDE, 0x9A), 10);

	public const string NAME_VideoObj_KeyFrameDistance = "KeyFrameDistance";


	/// <summary>MediaObj.BufferSize
	/// MTP Property: Buffer Size  (0xDE9F)
	/// Type: UInt32 
	/// Form: Range 
	/// </summary>

	[CorrespondingType(typeof(uint))]
	public static PROPERTYKEY PKEY_MediaObj_BufferSize => new(new(0x2ED8BA05, 0x0AD3, 0x42DC, 0xB0, 0xD0, 0xBC, 0x95, 0xAC, 0x39, 0x6A, 0xC8), 46);

	public const string NAME_MediaObj_BufferSize = "BufferSize";


	/// <summary>MediaObj.EncodingQuality
	/// MTP Property: Encoding Quality  (0xDEA0)
	/// Type: UInt32 
	/// Form: Range 
	/// </summary>

	[CorrespondingType(typeof(uint))]
	public static PROPERTYKEY PKEY_MediaObj_EncodingQuality => new(new(0x2ED8BA05, 0x0AD3, 0x42DC, 0xB0, 0xD0, 0xBC, 0x95, 0xAC, 0x39, 0x6A, 0xC8), 48);

	public const string NAME_MediaObj_EncodingQuality = "EncodingQuality";


	/// <summary>MediaObj.EncodingProfile
	/// MTP Property: Encoding Profile  (0xDEA1)
	/// Type: String 
	/// Form: Enum 
	/// </summary>

	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_MediaObj_EncodingProfile => new(new(0x2ED8BA05, 0x0AD3, 0x42DC, 0xB0, 0xD0, 0xBC, 0x95, 0xAC, 0x39, 0x6A, 0xC8), 21);

	public const string NAME_MediaObj_EncodingProfile = "EncodingProfile";


	/// <summary>MediaObj.AudioEncodingProfile
	/// MTP Property: Audio Encoding Profile  (0xDEA2)
	/// Type: String 
	/// Form: Enum 
	/// </summary>

	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_MediaObj_AudioEncodingProfile => new(new(0x2ED8BA05, 0x0AD3, 0x42DC, 0xB0, 0xD0, 0xBC, 0x95, 0xAC, 0x39, 0x6A, 0xC8), 49);

	public const string NAME_MediaObj_AudioEncodingProfile = "AudioEncodingProfile";

}