using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke;

/// <summary>Items from the WinMm.dll</summary>
public static partial class WinMm
{
	/// <summary>Format type.</summary>
	[PInvokeData("mmreg.h", MSDNShortId = "NS:mmreg.waveformat_tag")]
	[Flags]
	public enum WAVE_FORMAT : ushort
	{
		/// <summary>Microsoft Corporation</summary>
		WAVE_FORMAT_UNKNOWN = 0x0000,

		/// <summary>Waveform-audio data is PCM.</summary>
		WAVE_FORMAT_PCM,

		/// <summary>Microsoft Corporation</summary>
		WAVE_FORMAT_ADPCM = 0x0002,

		/// <summary>Microsoft Corporation</summary>
		WAVE_FORMAT_IEEE_FLOAT = 0x0003,

		/// <summary>Compaq Computer Corp.</summary>
		WAVE_FORMAT_VSELP = 0x0004,

		/// <summary>IBM Corporation</summary>
		WAVE_FORMAT_IBM_CVSD = 0x0005,

		/// <summary>Microsoft Corporation</summary>
		WAVE_FORMAT_ALAW = 0x0006,

		/// <summary>Microsoft Corporation</summary>
		WAVE_FORMAT_MULAW = 0x0007,

		/// <summary>Microsoft Corporation</summary>
		WAVE_FORMAT_DTS = 0x0008,

		/// <summary>Microsoft Corporation</summary>
		WAVE_FORMAT_DRM = 0x0009,

		/// <summary>Microsoft Corporation</summary>
		WAVE_FORMAT_WMAVOICE9 = 0x000A,

		/// <summary>Microsoft Corporation</summary>
		WAVE_FORMAT_WMAVOICE10 = 0x000B,

		/// <summary>OKI</summary>
		WAVE_FORMAT_OKI_ADPCM = 0x0010,

		/// <summary>Intel Corporation</summary>
		WAVE_FORMAT_DVI_ADPCM = 0x0011,

		/// <summary>Intel Corporation</summary>
		WAVE_FORMAT_IMA_ADPCM = WAVE_FORMAT_DVI_ADPCM,

		/// <summary>Videologic</summary>
		WAVE_FORMAT_MEDIASPACE_ADPCM = 0x0012,

		/// <summary>Sierra Semiconductor Corp</summary>
		WAVE_FORMAT_SIERRA_ADPCM = 0x0013,

		/// <summary>Antex Electronics Corporation</summary>
		WAVE_FORMAT_G723_ADPCM = 0x0014,

		/// <summary>DSP Solutions, Inc.</summary>
		WAVE_FORMAT_DIGISTD = 0x0015,

		/// <summary>DSP Solutions, Inc.</summary>
		WAVE_FORMAT_DIGIFIX = 0x0016,

		/// <summary>Dialogic Corporation</summary>
		WAVE_FORMAT_DIALOGIC_OKI_ADPCM = 0x0017,

		/// <summary>Media Vision, Inc.</summary>
		WAVE_FORMAT_MEDIAVISION_ADPCM = 0x0018,

		/// <summary>Hewlett-Packard Company</summary>
		WAVE_FORMAT_CU_CODEC = 0x0019,

		/// <summary>Hewlett-Packard Company</summary>
		WAVE_FORMAT_HP_DYN_VOICE = 0x001A,

		/// <summary>Yamaha Corporation of America</summary>
		WAVE_FORMAT_YAMAHA_ADPCM = 0x0020,

		/// <summary>Speech Compression</summary>
		WAVE_FORMAT_SONARC = 0x0021,

		/// <summary>DSP Group, Inc</summary>
		WAVE_FORMAT_DSPGROUP_TRUESPEECH = 0x0022,

		/// <summary>Echo Speech Corporation</summary>
		WAVE_FORMAT_ECHOSC1 = 0x0023,

		/// <summary>Virtual Music, Inc.</summary>
		WAVE_FORMAT_AUDIOFILE_AF36 = 0x0024,

		/// <summary>Audio Processing Technology</summary>
		WAVE_FORMAT_APTX = 0x0025,

		/// <summary>Virtual Music, Inc.</summary>
		WAVE_FORMAT_AUDIOFILE_AF10 = 0x0026,

		/// <summary>Aculab plc</summary>
		WAVE_FORMAT_PROSODY_1612 = 0x0027,

		/// <summary>Merging Technologies S.A.</summary>
		WAVE_FORMAT_LRC = 0x0028,

		/// <summary>Dolby Laboratories</summary>
		WAVE_FORMAT_DOLBY_AC2 = 0x0030,

		/// <summary>Microsoft Corporation</summary>
		WAVE_FORMAT_GSM610 = 0x0031,

		/// <summary>Microsoft Corporation</summary>
		WAVE_FORMAT_MSNAUDIO = 0x0032,

		/// <summary>Antex Electronics Corporation</summary>
		WAVE_FORMAT_ANTEX_ADPCME = 0x0033,

		/// <summary>Control Resources Limited</summary>
		WAVE_FORMAT_CONTROL_RES_VQLPC = 0x0034,

		/// <summary>DSP Solutions, Inc.</summary>
		WAVE_FORMAT_DIGIREAL = 0x0035,

		/// <summary>DSP Solutions, Inc.</summary>
		WAVE_FORMAT_DIGIADPCM = 0x0036,

		/// <summary>Control Resources Limited</summary>
		WAVE_FORMAT_CONTROL_RES_CR10 = 0x0037,

		/// <summary>Natural MicroSystems</summary>
		WAVE_FORMAT_NMS_VBXADPCM = 0x0038,

		/// <summary>Crystal Semiconductor IMA ADPCM</summary>
		WAVE_FORMAT_CS_IMAADPCM = 0x0039,

		/// <summary>Echo Speech Corporation</summary>
		WAVE_FORMAT_ECHOSC3 = 0x003A,

		/// <summary>Rockwell International</summary>
		WAVE_FORMAT_ROCKWELL_ADPCM = 0x003B,

		/// <summary>Rockwell International</summary>
		WAVE_FORMAT_ROCKWELL_DIGITALK = 0x003C,

		/// <summary>Xebec Multimedia Solutions Limited</summary>
		WAVE_FORMAT_XEBEC = 0x003D,

		/// <summary>Antex Electronics Corporation</summary>
		WAVE_FORMAT_G721_ADPCM = 0x0040,

		/// <summary>Antex Electronics Corporation</summary>
		WAVE_FORMAT_G728_CELP = 0x0041,

		/// <summary>Microsoft Corporation</summary>
		WAVE_FORMAT_MSG723 = 0x0042,

		/// <summary>Intel Corp.</summary>
		WAVE_FORMAT_INTEL_G723_1 = 0x0043,

		/// <summary>Intel Corp.</summary>
		WAVE_FORMAT_INTEL_G729 = 0x0044,

		/// <summary>Sharp</summary>
		WAVE_FORMAT_SHARP_G726 = 0x0045,

		/// <summary>Microsoft Corporation</summary>
		WAVE_FORMAT_MPEG = 0x0050,

		/// <summary>InSoft, Inc.</summary>
		WAVE_FORMAT_RT24 = 0x0052,

		/// <summary>InSoft, Inc.</summary>
		WAVE_FORMAT_PAC = 0x0053,

		/// <summary>ISO/MPEG Layer3 Format Tag</summary>
		WAVE_FORMAT_MPEGLAYER3 = 0x0055,

		/// <summary>Lucent Technologies</summary>
		WAVE_FORMAT_LUCENT_G723 = 0x0059,

		/// <summary>Cirrus Logic</summary>
		WAVE_FORMAT_CIRRUS = 0x0060,

		/// <summary>ESS Technology</summary>
		WAVE_FORMAT_ESPCM = 0x0061,

		/// <summary>Voxware Inc</summary>
		WAVE_FORMAT_VOXWARE = 0x0062,

		/// <summary>Canopus, co., Ltd.</summary>
		WAVE_FORMAT_CANOPUS_ATRAC = 0x0063,

		/// <summary>APICOM</summary>
		WAVE_FORMAT_G726_ADPCM = 0x0064,

		/// <summary>APICOM</summary>
		WAVE_FORMAT_G722_ADPCM = 0x0065,

		/// <summary>Microsoft Corporation</summary>
		WAVE_FORMAT_DSAT = 0x0066,

		/// <summary>Microsoft Corporation</summary>
		WAVE_FORMAT_DSAT_DISPLAY = 0x0067,

		/// <summary>Voxware Inc</summary>
		WAVE_FORMAT_VOXWARE_BYTE_ALIGNED = 0x0069,

		/// <summary>Voxware Inc</summary>
		WAVE_FORMAT_VOXWARE_AC8 = 0x0070,

		/// <summary>Voxware Inc</summary>
		WAVE_FORMAT_VOXWARE_AC10 = 0x0071,

		/// <summary>Voxware Inc</summary>
		WAVE_FORMAT_VOXWARE_AC16 = 0x0072,

		/// <summary>Voxware Inc</summary>
		WAVE_FORMAT_VOXWARE_AC20 = 0x0073,

		/// <summary>Voxware Inc</summary>
		WAVE_FORMAT_VOXWARE_RT24 = 0x0074,

		/// <summary>Voxware Inc</summary>
		WAVE_FORMAT_VOXWARE_RT29 = 0x0075,

		/// <summary>Voxware Inc</summary>
		WAVE_FORMAT_VOXWARE_RT29HW = 0x0076,

		/// <summary>Voxware Inc</summary>
		WAVE_FORMAT_VOXWARE_VR12 = 0x0077,

		/// <summary>Voxware Inc</summary>
		WAVE_FORMAT_VOXWARE_VR18 = 0x0078,

		/// <summary>Voxware Inc</summary>
		WAVE_FORMAT_VOXWARE_TQ40 = 0x0079,

		/// <summary>Voxware Inc</summary>
		WAVE_FORMAT_VOXWARE_SC3 = 0x007A,

		/// <summary>Voxware Inc</summary>
		WAVE_FORMAT_VOXWARE_SC3_1 = 0x007B,

		/// <summary>Softsound, Ltd.</summary>
		WAVE_FORMAT_SOFTSOUND = 0x0080,

		/// <summary>Voxware Inc</summary>
		WAVE_FORMAT_VOXWARE_TQ60 = 0x0081,

		/// <summary>Microsoft Corporation</summary>
		WAVE_FORMAT_MSRT24 = 0x0082,

		/// <summary>AT&amp;T Labs, Inc.</summary>
		WAVE_FORMAT_G729A = 0x0083,

		/// <summary>Motion Pixels</summary>
		WAVE_FORMAT_MVI_MVI2 = 0x0084,

		/// <summary>DataFusion Systems (Pty) (Ltd)</summary>
		WAVE_FORMAT_DF_G726 = 0x0085,

		/// <summary>DataFusion Systems (Pty) (Ltd)</summary>
		WAVE_FORMAT_DF_GSM610 = 0x0086,

		/// <summary>Iterated Systems, Inc.</summary>
		WAVE_FORMAT_ISIAUDIO = 0x0088,

		/// <summary>OnLive! Technologies, Inc.</summary>
		WAVE_FORMAT_ONLIVE = 0x0089,

		/// <summary>Multitude Inc.</summary>
		WAVE_FORMAT_MULTITUDE_FT_SX20 = 0x008A,

		/// <summary>Infocom</summary>
		WAVE_FORMAT_INFOCOM_ITS_G721_ADPCM = 0x008B,

		/// <summary>Convedia Corp.</summary>
		WAVE_FORMAT_CONVEDIA_G729 = 0x008C,

		/// <summary>Congruency Inc.</summary>
		WAVE_FORMAT_CONGRUENCY = 0x008D,

		/// <summary>Siemens Business Communications Sys</summary>
		WAVE_FORMAT_SBC24 = 0x0091,

		/// <summary>Sonic Foundry</summary>
		WAVE_FORMAT_DOLBY_AC3_SPDIF = 0x0092,

		/// <summary>MediaSonic</summary>
		WAVE_FORMAT_MEDIASONIC_G723 = 0x0093,

		/// <summary>Aculab plc</summary>
		WAVE_FORMAT_PROSODY_8KBPS = 0x0094,

		/// <summary>ZyXEL Communications, Inc.</summary>
		WAVE_FORMAT_ZYXEL_ADPCM = 0x0097,

		/// <summary>Philips Speech Processing</summary>
		WAVE_FORMAT_PHILIPS_LPCBB = 0x0098,

		/// <summary>Studer Professional Audio AG</summary>
		WAVE_FORMAT_PACKED = 0x0099,

		/// <summary>Malden Electronics Ltd.</summary>
		WAVE_FORMAT_MALDEN_PHONYTALK = 0x00A0,

		/// <summary>Racal recorders</summary>
		WAVE_FORMAT_RACAL_RECORDER_GSM = 0x00A1,

		/// <summary>Racal recorders</summary>
		WAVE_FORMAT_RACAL_RECORDER_G720_A = 0x00A2,

		/// <summary>Racal recorders</summary>
		WAVE_FORMAT_RACAL_RECORDER_G723_1 = 0x00A3,

		/// <summary>Racal recorders</summary>
		WAVE_FORMAT_RACAL_RECORDER_TETRA_ACELP = 0x00A4,

		/// <summary>NEC Corp.</summary>
		WAVE_FORMAT_NEC_AAC = 0x00B0,

		/// <summary>For Raw AAC, with format block AudioSpecificConfig() (as defined by MPEG-4), that follows WAVEFORMATEX</summary>
		WAVE_FORMAT_RAW_AAC1 = 0x00FF,

		/// <summary>Rhetorex Inc.</summary>
		WAVE_FORMAT_RHETOREX_ADPCM = 0x0100,

		/// <summary>BeCubed Software Inc.</summary>
		WAVE_FORMAT_IRAT = 0x0101,

		/// <summary>Vivo Software</summary>
		WAVE_FORMAT_VIVO_G723 = 0x0111,

		/// <summary>Vivo Software</summary>
		WAVE_FORMAT_VIVO_SIREN = 0x0112,

		/// <summary>Philips Speech Processing</summary>
		WAVE_FORMAT_PHILIPS_CELP = 0x0120,

		/// <summary>Philips Speech Processing</summary>
		WAVE_FORMAT_PHILIPS_GRUNDIG = 0x0121,

		/// <summary>Digital Equipment Corporation</summary>
		WAVE_FORMAT_DIGITAL_G723 = 0x0123,

		/// <summary>Sanyo Electric Co., Ltd.</summary>
		WAVE_FORMAT_SANYO_LD_ADPCM = 0x0125,

		/// <summary>Sipro Lab Telecom Inc.</summary>
		WAVE_FORMAT_SIPROLAB_ACEPLNET = 0x0130,

		/// <summary>Sipro Lab Telecom Inc.</summary>
		WAVE_FORMAT_SIPROLAB_ACELP4800 = 0x0131,

		/// <summary>Sipro Lab Telecom Inc.</summary>
		WAVE_FORMAT_SIPROLAB_ACELP8V3 = 0x0132,

		/// <summary>Sipro Lab Telecom Inc.</summary>
		WAVE_FORMAT_SIPROLAB_G729 = 0x0133,

		/// <summary>Sipro Lab Telecom Inc.</summary>
		WAVE_FORMAT_SIPROLAB_G729A = 0x0134,

		/// <summary>Sipro Lab Telecom Inc.</summary>
		WAVE_FORMAT_SIPROLAB_KELVIN = 0x0135,

		/// <summary>VoiceAge Corp.</summary>
		WAVE_FORMAT_VOICEAGE_AMR = 0x0136,

		/// <summary>Dictaphone Corporation</summary>
		WAVE_FORMAT_G726ADPCM = 0x0140,

		/// <summary>Dictaphone Corporation</summary>
		WAVE_FORMAT_DICTAPHONE_CELP68 = 0x0141,

		/// <summary>Dictaphone Corporation</summary>
		WAVE_FORMAT_DICTAPHONE_CELP54 = 0x0142,

		/// <summary>Qualcomm, Inc.</summary>
		WAVE_FORMAT_QUALCOMM_PUREVOICE = 0x0150,

		/// <summary>Qualcomm, Inc.</summary>
		WAVE_FORMAT_QUALCOMM_HALFRATE = 0x0151,

		/// <summary>Ring Zero Systems, Inc.</summary>
		WAVE_FORMAT_TUBGSM = 0x0155,

		/// <summary>Microsoft Corporation</summary>
		WAVE_FORMAT_MSAUDIO1 = 0x0160,

		/// <summary>Microsoft Corporation</summary>
		WAVE_FORMAT_WMAUDIO2 = 0x0161,

		/// <summary>Microsoft Corporation</summary>
		WAVE_FORMAT_WMAUDIO3 = 0x0162,

		/// <summary>Microsoft Corporation</summary>
		WAVE_FORMAT_WMAUDIO_LOSSLESS = 0x0163,

		/// <summary>Microsoft Corporation</summary>
		WAVE_FORMAT_WMASPDIF = 0x0164,

		/// <summary>Unisys Corp.</summary>
		WAVE_FORMAT_UNISYS_NAP_ADPCM = 0x0170,

		/// <summary>Unisys Corp.</summary>
		WAVE_FORMAT_UNISYS_NAP_ULAW = 0x0171,

		/// <summary>Unisys Corp.</summary>
		WAVE_FORMAT_UNISYS_NAP_ALAW = 0x0172,

		/// <summary>Unisys Corp.</summary>
		WAVE_FORMAT_UNISYS_NAP_16K = 0x0173,

		/// <summary>SyCom Technologies</summary>
		WAVE_FORMAT_SYCOM_ACM_SYC008 = 0x0174,

		/// <summary>SyCom Technologies</summary>
		WAVE_FORMAT_SYCOM_ACM_SYC701_G726L = 0x0175,

		/// <summary>SyCom Technologies</summary>
		WAVE_FORMAT_SYCOM_ACM_SYC701_CELP54 = 0x0176,

		/// <summary>SyCom Technologies</summary>
		WAVE_FORMAT_SYCOM_ACM_SYC701_CELP68 = 0x0177,

		/// <summary>Knowledge Adventure, Inc.</summary>
		WAVE_FORMAT_KNOWLEDGE_ADVENTURE_ADPCM = 0x0178,

		/// <summary>Fraunhofer IIS</summary>
		WAVE_FORMAT_FRAUNHOFER_IIS_MPEG2_AAC = 0x0180,

		/// <summary>Digital Theatre Systems, Inc.</summary>
		WAVE_FORMAT_DTS_DS = 0x0190,

		/// <summary>Creative Labs, Inc</summary>
		WAVE_FORMAT_CREATIVE_ADPCM = 0x0200,

		/// <summary>Creative Labs, Inc</summary>
		WAVE_FORMAT_CREATIVE_FASTSPEECH8 = 0x0202,

		/// <summary>Creative Labs, Inc</summary>
		WAVE_FORMAT_CREATIVE_FASTSPEECH10 = 0x0203,

		/// <summary>UHER informatic GmbH</summary>
		WAVE_FORMAT_UHER_ADPCM = 0x0210,

		/// <summary>Ulead Systems, Inc.</summary>
		WAVE_FORMAT_ULEAD_DV_AUDIO = 0x0215,

		/// <summary>Ulead Systems, Inc.</summary>
		WAVE_FORMAT_ULEAD_DV_AUDIO_1 = 0x0216,

		/// <summary>Quarterdeck Corporation</summary>
		WAVE_FORMAT_QUARTERDECK = 0x0220,

		/// <summary>I-link Worldwide</summary>
		WAVE_FORMAT_ILINK_VC = 0x0230,

		/// <summary>Aureal Semiconductor</summary>
		WAVE_FORMAT_RAW_SPORT = 0x0240,

		/// <summary>ESS Technology, Inc.</summary>
		WAVE_FORMAT_ESST_AC3 = 0x0241,

		/// <summary></summary>
		WAVE_FORMAT_GENERIC_PASSTHRU = 0x0249,

		/// <summary>Interactive Products, Inc.</summary>
		WAVE_FORMAT_IPI_HSX = 0x0250,

		/// <summary>Interactive Products, Inc.</summary>
		WAVE_FORMAT_IPI_RPELP = 0x0251,

		/// <summary>Consistent Software</summary>
		WAVE_FORMAT_CS2 = 0x0260,

		/// <summary>Sony Corp.</summary>
		WAVE_FORMAT_SONY_SCX = 0x0270,

		/// <summary>Sony Corp.</summary>
		WAVE_FORMAT_SONY_SCY = 0x0271,

		/// <summary>Sony Corp.</summary>
		WAVE_FORMAT_SONY_ATRAC3 = 0x0272,

		/// <summary>Sony Corp.</summary>
		WAVE_FORMAT_SONY_SPC = 0x0273,

		/// <summary>Telum Inc.</summary>
		WAVE_FORMAT_TELUM_AUDIO = 0x0280,

		/// <summary>Telum Inc.</summary>
		WAVE_FORMAT_TELUM_IA_AUDIO = 0x0281,

		/// <summary>Norcom Electronics Corp.</summary>
		WAVE_FORMAT_NORCOM_VOICE_SYSTEMS_ADPCM = 0x0285,

		/// <summary>Fujitsu Corp.</summary>
		WAVE_FORMAT_FM_TOWNS_SND = 0x0300,

		/// <summary>Micronas Semiconductors, Inc.</summary>
		WAVE_FORMAT_MICRONAS = 0x0350,

		/// <summary>Micronas Semiconductors, Inc.</summary>
		WAVE_FORMAT_MICRONAS_CELP833 = 0x0351,

		/// <summary>Brooktree Corporation</summary>
		WAVE_FORMAT_BTV_DIGITAL = 0x0400,

		/// <summary>Intel Corp.</summary>
		WAVE_FORMAT_INTEL_MUSIC_CODER = 0x0401,

		/// <summary>Ligos</summary>
		WAVE_FORMAT_INDEO_AUDIO = 0x0402,

		/// <summary>QDesign Corporation</summary>
		WAVE_FORMAT_QDESIGN_MUSIC = 0x0450,

		/// <summary>On2 Technologies</summary>
		WAVE_FORMAT_ON2_VP7_AUDIO = 0x0500,

		/// <summary>On2 Technologies</summary>
		WAVE_FORMAT_ON2_VP6_AUDIO = 0x0501,

		/// <summary>AT&amp;T Labs, Inc.</summary>
		WAVE_FORMAT_VME_VMPCM = 0x0680,

		/// <summary>AT&amp;T Labs, Inc.</summary>
		WAVE_FORMAT_TPC = 0x0681,

		/// <summary>Clearjump</summary>
		WAVE_FORMAT_LIGHTWAVE_LOSSLESS = 0x08AE,

		/// <summary>Ing C. Olivetti &amp; C., S.p.A.</summary>
		WAVE_FORMAT_OLIGSM = 0x1000,

		/// <summary>Ing C. Olivetti &amp; C., S.p.A.</summary>
		WAVE_FORMAT_OLIADPCM = 0x1001,

		/// <summary>Ing C. Olivetti &amp; C., S.p.A.</summary>
		WAVE_FORMAT_OLICELP = 0x1002,

		/// <summary>Ing C. Olivetti &amp; C., S.p.A.</summary>
		WAVE_FORMAT_OLISBC = 0x1003,

		/// <summary>Ing C. Olivetti &amp; C., S.p.A.</summary>
		WAVE_FORMAT_OLIOPR = 0x1004,

		/// <summary>Lernout &amp; Hauspie</summary>
		WAVE_FORMAT_LH_CODEC = 0x1100,

		/// <summary>Lernout &amp; Hauspie</summary>
		WAVE_FORMAT_LH_CODEC_CELP = 0x1101,

		/// <summary>Lernout &amp; Hauspie</summary>
		WAVE_FORMAT_LH_CODEC_SBC8 = 0x1102,

		/// <summary>Lernout &amp; Hauspie</summary>
		WAVE_FORMAT_LH_CODEC_SBC12 = 0x1103,

		/// <summary>Lernout &amp; Hauspie</summary>
		WAVE_FORMAT_LH_CODEC_SBC16 = 0x1104,

		/// <summary>Norris Communications, Inc.</summary>
		WAVE_FORMAT_NORRIS = 0x1400,

		/// <summary>ISIAudio</summary>
		WAVE_FORMAT_ISIAUDIO_2 = 0x1401,

		/// <summary>AT&amp;T Labs, Inc.</summary>
		WAVE_FORMAT_SOUNDSPACE_MUSICOMPRESS = 0x1500,

		/// <summary>Microsoft Corporation</summary>
		WAVE_FORMAT_MPEG_ADTS_AAC = 0x1600,

		/// <summary>Microsoft Corporation</summary>
		WAVE_FORMAT_MPEG_RAW_AAC = 0x1601,

		/// <summary>Microsoft Corporation (MPEG-4 Audio Transport Streams (LOAS/LATM)</summary>
		WAVE_FORMAT_MPEG_LOAS = 0x1602,

		/// <summary>Microsoft Corporation</summary>
		WAVE_FORMAT_NOKIA_MPEG_ADTS_AAC = 0x1608,

		/// <summary>Microsoft Corporation</summary>
		WAVE_FORMAT_NOKIA_MPEG_RAW_AAC = 0x1609,

		/// <summary>Microsoft Corporation</summary>
		WAVE_FORMAT_VODAFONE_MPEG_ADTS_AAC = 0x160A,

		/// <summary>Microsoft Corporation</summary>
		WAVE_FORMAT_VODAFONE_MPEG_RAW_AAC = 0x160B,

		/// <summary>
		/// Microsoft Corporation (MPEG-2 AAC or MPEG-4 HE-AAC v1/v2 streams with any payload (ADTS, ADIF, LOAS/LATM, RAW). Format block
		/// includes MP4 AudioSpecificConfig() -- see HEAACWAVEFORMAT below
		/// </summary>
		WAVE_FORMAT_MPEG_HEAAC = 0x1610,

		/// <summary>Voxware Inc.</summary>
		WAVE_FORMAT_VOXWARE_RT24_SPEECH = 0x181C,

		/// <summary>Sonic Foundry</summary>
		WAVE_FORMAT_SONICFOUNDRY_LOSSLESS = 0x1971,

		/// <summary>Innings Telecom Inc.</summary>
		WAVE_FORMAT_INNINGS_TELECOM_ADPCM = 0x1979,

		/// <summary>Lucent Technologies</summary>
		WAVE_FORMAT_LUCENT_SX8300P = 0x1C07,

		/// <summary>Lucent Technologies</summary>
		WAVE_FORMAT_LUCENT_SX5363S = 0x1C0C,

		/// <summary>CUSeeMe</summary>
		WAVE_FORMAT_CUSEEME = 0x1F03,

		/// <summary>NTCSoft</summary>
		WAVE_FORMAT_NTCSOFT_ALF2CM_ACM = 0x1FC4,

		/// <summary>FAST Multimedia AG</summary>
		WAVE_FORMAT_DVM = 0x2000,

		/// <summary></summary>
		WAVE_FORMAT_DTS2 = 0x2001,

		/// <summary></summary>
		WAVE_FORMAT_MAKEAVIS = 0x3313,

		/// <summary>Divio, Inc.</summary>
		WAVE_FORMAT_DIVIO_MPEG4_AAC = 0x4143,

		/// <summary>Nokia</summary>
		WAVE_FORMAT_NOKIA_ADAPTIVE_MULTIRATE = 0x4201,

		/// <summary>Divio, Inc.</summary>
		WAVE_FORMAT_DIVIO_G726 = 0x4243,

		/// <summary>LEAD Technologies</summary>
		WAVE_FORMAT_LEAD_SPEECH = 0x434C,

		/// <summary>LEAD Technologies</summary>
		WAVE_FORMAT_LEAD_VORBIS = 0x564C,

		/// <summary>xiph.org</summary>
		WAVE_FORMAT_WAVPACK_AUDIO = 0x5756,

		/// <summary>Apple Lossless</summary>
		WAVE_FORMAT_ALAC = 0x6C61,

		/// <summary>Ogg Vorbis</summary>
		WAVE_FORMAT_OGG_VORBIS_MODE_1 = 0x674F,

		/// <summary>Ogg Vorbis</summary>
		WAVE_FORMAT_OGG_VORBIS_MODE_2 = 0x6750,

		/// <summary>Ogg Vorbis</summary>
		WAVE_FORMAT_OGG_VORBIS_MODE_3 = 0x6751,

		/// <summary>Ogg Vorbis</summary>
		WAVE_FORMAT_OGG_VORBIS_MODE_1_PLUS = 0x676F,

		/// <summary>Ogg Vorbis</summary>
		WAVE_FORMAT_OGG_VORBIS_MODE_2_PLUS = 0x6770,

		/// <summary>Ogg Vorbis</summary>
		WAVE_FORMAT_OGG_VORBIS_MODE_3_PLUS = 0x6771,

		/// <summary>3COM Corp.</summary>
		WAVE_FORMAT_3COM_NBX = 0x7000,

		/// <summary>Opus</summary>
		WAVE_FORMAT_OPUS = 0x704F,

		/// <summary></summary>
		WAVE_FORMAT_FAAD_AAC = 0x706D,

		/// <summary>AMR Narrowband</summary>
		WAVE_FORMAT_AMR_NB = 0x7361,

		/// <summary>AMR Wideband</summary>
		WAVE_FORMAT_AMR_WB = 0x7362,

		/// <summary>AMR Wideband Plus</summary>
		WAVE_FORMAT_AMR_WP = 0x7363,

		/// <summary>GSMA/3GPP</summary>
		WAVE_FORMAT_GSM_AMR_CBR = 0x7A21,

		/// <summary>GSMA/3GPP</summary>
		WAVE_FORMAT_GSM_AMR_VBR_SID = 0x7A22,

		/// <summary>Comverse Infosys</summary>
		WAVE_FORMAT_COMVERSE_INFOSYS_G723_1 = 0xA100,

		/// <summary>Comverse Infosys</summary>
		WAVE_FORMAT_COMVERSE_INFOSYS_AVQSBC = 0xA101,

		/// <summary>Comverse Infosys</summary>
		WAVE_FORMAT_COMVERSE_INFOSYS_SBC = 0xA102,

		/// <summary>Symbol Technologies</summary>
		WAVE_FORMAT_SYMBOL_G729_A = 0xA103,

		/// <summary>VoiceAge Corp.</summary>
		WAVE_FORMAT_VOICEAGE_AMR_WB = 0xA104,

		/// <summary>Ingenient Technologies, Inc.</summary>
		WAVE_FORMAT_INGENIENT_G726 = 0xA105,

		/// <summary>ISO/MPEG-4</summary>
		WAVE_FORMAT_MPEG4_AAC = 0xA106,

		/// <summary>Encore Software</summary>
		WAVE_FORMAT_ENCORE_G726 = 0xA107,

		/// <summary>ZOLL Medical Corp.</summary>
		WAVE_FORMAT_ZOLL_ASAO = 0xA108,

		/// <summary>xiph.org</summary>
		WAVE_FORMAT_SPEEX_VOICE = 0xA109,

		/// <summary>Vianix LLC</summary>
		WAVE_FORMAT_VIANIX_MASC = 0xA10A,

		/// <summary>Microsoft</summary>
		WAVE_FORMAT_WM9_SPECTRUM_ANALYZER = 0xA10B,

		/// <summary>Microsoft</summary>
		WAVE_FORMAT_WMF_SPECTRUM_ANAYZER = 0xA10C,

		/// <summary></summary>
		WAVE_FORMAT_GSM_610 = 0xA10D,

		/// <summary></summary>
		WAVE_FORMAT_GSM_620 = 0xA10E,

		/// <summary></summary>
		WAVE_FORMAT_GSM_660 = 0xA10F,

		/// <summary></summary>
		WAVE_FORMAT_GSM_690 = 0xA110,

		/// <summary></summary>
		WAVE_FORMAT_GSM_ADAPTIVE_MULTIRATE_WB = 0xA111,

		/// <summary>Polycom</summary>
		WAVE_FORMAT_POLYCOM_G722 = 0xA112,

		/// <summary>Polycom</summary>
		WAVE_FORMAT_POLYCOM_G728 = 0xA113,

		/// <summary>Polycom</summary>
		WAVE_FORMAT_POLYCOM_G729_A = 0xA114,

		/// <summary>Polycom</summary>
		WAVE_FORMAT_POLYCOM_SIREN = 0xA115,

		/// <summary>Global IP</summary>
		WAVE_FORMAT_GLOBAL_IP_ILBC = 0xA116,

		/// <summary>RadioTime</summary>
		WAVE_FORMAT_RADIOTIME_TIME_SHIFT_RADIO = 0xA117,

		/// <summary>Nice Systems</summary>
		WAVE_FORMAT_NICE_ACA = 0xA118,

		/// <summary>Nice Systems</summary>
		WAVE_FORMAT_NICE_ADPCM = 0xA119,

		/// <summary>Vocord Telecom</summary>
		WAVE_FORMAT_VOCORD_G721 = 0xA11A,

		/// <summary>Vocord Telecom</summary>
		WAVE_FORMAT_VOCORD_G726 = 0xA11B,

		/// <summary>Vocord Telecom</summary>
		WAVE_FORMAT_VOCORD_G722_1 = 0xA11C,

		/// <summary>Vocord Telecom</summary>
		WAVE_FORMAT_VOCORD_G728 = 0xA11D,

		/// <summary>Vocord Telecom</summary>
		WAVE_FORMAT_VOCORD_G729 = 0xA11E,

		/// <summary>Vocord Telecom</summary>
		WAVE_FORMAT_VOCORD_G729_A = 0xA11F,

		/// <summary>Vocord Telecom</summary>
		WAVE_FORMAT_VOCORD_G723_1 = 0xA120,

		/// <summary>Vocord Telecom</summary>
		WAVE_FORMAT_VOCORD_LBC = 0xA121,

		/// <summary>Nice Systems</summary>
		WAVE_FORMAT_NICE_G728 = 0xA122,

		/// <summary>France Telecom</summary>
		WAVE_FORMAT_FRACE_TELECOM_G729 = 0xA123,

		/// <summary>CODIAN</summary>
		WAVE_FORMAT_CODIAN = 0xA124,

		/// <summary>flac.sourceforge.net</summary>
		WAVE_FORMAT_FLAC = 0xF1AC,

		/// <summary>Microsoft</summary>
		WAVE_FORMAT_EXTENSIBLE = 0xFFFE,

		/// <summary>
		/// New wave format development should be based on the WAVEFORMATEXTENSIBLE structure. WAVEFORMATEXTENSIBLE allows you to avoid
		/// having to register a new format tag with Microsoft. However, if you must still define a new format tag, the
		/// WAVE_FORMAT_DEVELOPMENT format tag can be used during the development phase of a new wave format. Before shipping, you MUST
		/// acquire an official format tag from Microsoft.
		/// </summary>
		WAVE_FORMAT_DEVELOPMENT = 0xFFFF,
	}

	/// <summary>
	/// The <c>PCMWAVEFORMAT</c> structure describes the data format for PCM waveform-audio data. This structure has been superseded by
	/// the WAVEFORMATEX structure.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmreg/ns-mmreg-pcmwaveformat typedef struct pcmwaveformat_tag { WAVEFORMAT wf;
	// WORD wBitsPerSample; } PCMWAVEFORMAT;
	[PInvokeData("mmreg.h", MSDNShortId = "NS:mmreg.pcmwaveformat_tag")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PCMWAVEFORMAT
	{
		/// <summary>A WAVEFORMAT structure containing general information about the format of the data.</summary>
		public WAVEFORMAT wf;

		/// <summary>Number of bits per sample.</summary>
		public ushort wBitsPerSample;
	}

	/// <summary>
	/// The <c>WAVEFILTER</c> structure defines a filter for waveform-audio data. Only filter information common to all waveform-audio
	/// data filters is included in this structure. For filters that require additional information, this structure is included as the
	/// first member in another structure along with the additional information.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmreg/ns-mmreg-wavefilter typedef struct wavefilter_tag { DWORD cbStruct;
	// DWORD dwFilterTag; DWORD fdwFilter; DWORD dwReserved[5]; } WAVEFILTER;
	[PInvokeData("mmreg.h", MSDNShortId = "NS:mmreg.wavefilter_tag")]
	[StructLayout(LayoutKind.Sequential)]
	public struct WAVEFILTER
	{
		/// <summary>
		/// Size, in bytes, of the <c>WAVEFILTER</c> structure. The size specified in this member must be large enough to contain the
		/// base <c>WAVEFILTER</c> structure.
		/// </summary>
		public uint cbStruct;

		/// <summary>Waveform-audio filter type. Filter tags are registered with Microsoft Corporation for various filter algorithms.</summary>
		public uint dwFilterTag;

		/// <summary>
		/// Flags for the <c>dwFilterTag</c> member. The flags defined for this member are universal to all filters. Currently, no flags
		/// are defined.
		/// </summary>
		public uint fdwFilter;

		/// <summary>Reserved for system use; should not be examined or modified by an application.</summary>
		private readonly uint dwReserved1;

		private readonly uint dwReserved2;
		private readonly uint dwReserved3;
		private readonly uint dwReserved4;
		private readonly uint dwReserved5;
	}

	/// <summary>
	/// The <c>WAVEFORMAT</c> structure describes the format of waveform-audio data. Only format information common to all
	/// waveform-audio data formats is included in this structure. This structure has been superseded by the WAVEFORMATEX structure.
	/// </summary>
	/// <remarks>
	/// For formats that require additional information, this structure is included as a member in another structure along with the
	/// additional information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmreg/ns-mmreg-waveformat typedef struct waveformat_tag { WORD wFormatTag;
	// WORD nChannels; DWORD nSamplesPerSec; DWORD nAvgBytesPerSec; WORD nBlockAlign; } WAVEFORMAT;
	[PInvokeData("mmreg.h", MSDNShortId = "NS:mmreg.waveformat_tag")]
	[StructLayout(LayoutKind.Sequential)]
	public struct WAVEFORMAT
	{
		/// <summary>
		/// <para>Format type. The following type is defined:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Name</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>WAVE_FORMAT_PCM</term>
		/// <term>Waveform-audio data is PCM.</term>
		/// </item>
		/// </list>
		/// </summary>
		public WAVE_FORMAT wFormatTag;

		/// <summary>Number of channels in the waveform-audio data. Mono data uses one channel and stereo data uses two channels.</summary>
		public ushort nChannels;

		/// <summary>Sample rate, in samples per second.</summary>
		public uint nSamplesPerSec;

		/// <summary>
		/// Required average data transfer rate, in bytes per second. For example, 16-bit stereo at 44.1 kHz has an average data rate of
		/// 176,400 bytes per second (2 channels — 2 bytes per sample per channel — 44,100 samples per second).
		/// </summary>
		public uint nAvgBytesPerSec;

		/// <summary>
		/// Block alignment, in bytes. The block alignment is the minimum atomic unit of data. For PCM data, the block alignment is the
		/// number of bytes used by a single sample, including data for both channels if the data is stereo. For example, the block
		/// alignment for 16-bit stereo PCM is 4 bytes (2 channels — 2 bytes per sample).
		/// </summary>
		public ushort nBlockAlign;
	}
}