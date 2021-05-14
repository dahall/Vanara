#pragma warning disable IDE1006 // Naming Styles

using System;
using System.Runtime.InteropServices;
using Vanara.InteropServices;
using static Vanara.PInvoke.WinMm;

namespace Vanara.PInvoke
{
	/// <summary>Items from the MsAcm32.dll</summary>
	public static partial class MsAcm32
	{
		/// <summary>The FOURCC used in the fccComp field of the ACMDRIVERDETAILS structure. This is currently an unused field.</summary>
		public static readonly uint ACMDRIVERDETAILS_FCCCOMP = 0;

		/// <summary>
		/// The FOURCC used in the fccType field of the ACMDRIVERDETAILS structure to specify that this is an ACM codec designed for audio.
		/// </summary>
		public static readonly uint ACMDRIVERDETAILS_FCCTYPE_AUDIOCODEC = MAKEFOURCC('a', 'u', 'd', 'c');

		private const int ACMFILTERDETAILS_FILTER_CHARS = 128;
		private const int ACMFILTERTAGDETAILS_FILTERTAG_CHARS = 48;
		private const int ACMFORMATDETAILS_FORMAT_CHARS = 128;
		private const int ACMFORMATTAGDETAILS_FORMATTAG_CHARS = 48;
		private const string Lib_Msacm32 = "msacm32.dll";

		/// <summary>
		/// The <c>acmDriverEnumCallback</c> function specifies a callback function used with the acmDriverEnum function. The
		/// <c>acmDriverEnumCallback</c> name is a placeholder for an application-defined function name.
		/// </summary>
		/// <param name="hadid">Handle to an ACM driver identifier.</param>
		/// <param name="dwInstance">Application-defined value specified in acmDriverEnum.</param>
		/// <param name="fdwSupport">
		/// <para>
		/// Driver-support flags specific to the driver specified by ACMDRIVERDETAILS structure. This parameter can be a combination of the
		/// following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ACMDRIVERDETAILS_SUPPORTF_ASYNC</term>
		/// <term>Driver supports asynchronous conversions.</term>
		/// </item>
		/// <item>
		/// <term>ACMDRIVERDETAILS_SUPPORTF_CODEC</term>
		/// <term>
		/// Driver supports conversion between two different format tags. For example, if a driver supports compression from WAVE_FORMAT_PCM
		/// to WAVE_FORMAT_ADPCM, this flag is set.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ACMDRIVERDETAILS_SUPPORTF_CONVERTER</term>
		/// <term>
		/// Driver supports conversion between two different formats of the same format tag. For example, if a driver supports resampling of
		/// WAVE_FORMAT_PCM, this flag is set.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ACMDRIVERDETAILS_SUPPORTF_DISABLED</term>
		/// <term>
		/// Driver has been disabled. An application must specify the ACM_DRIVERENUMF_DISABLED flag with acmDriverEnum to include disabled
		/// drivers in the enumeration.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ACMDRIVERDETAILS_SUPPORTF_FILTER</term>
		/// <term>
		/// Driver supports a filter (modification of the data without changing any of the format attributes). For example, if a driver
		/// supports volume or echo operations on WAVE_FORMAT_PCM, this flag is set.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>The callback function must return <c>TRUE</c> to continue enumeration or <c>FALSE</c> to stop enumeration.</returns>
		/// <remarks>
		/// <para>
		/// The acmDriverEnum function will return MMSYSERR_NOERROR (zero) if no ACM drivers are installed. Moreover, the callback function
		/// will not be called.
		/// </para>
		/// <para>The following functions should not be called from within the callback function: acmDriverAdd, acmDriverRemove, and acmDriverPriority.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msacm/nc-msacm-acmdriverenumcb ACMDRIVERENUMCB Acmdriverenumcb; BOOL
		// Acmdriverenumcb( HACMDRIVERID hadid, DWORD_PTR dwInstance, DWORD fdwSupport ) {...}
		[PInvokeData("msacm.h", MSDNShortId = "NC:msacm.ACMDRIVERENUMCB")]
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public delegate bool ACMDRIVERENUMCB(HACMDRIVERID hadid, IntPtr dwInstance, ACMDRIVERDETAILS_SUPPORTF fdwSupport);

		/// <summary>
		/// The <c>acmDriverProc</c> function specifies a callback function used with the ACM driver. The <c>acmDriverProc</c> name is a
		/// placeholder for an application-defined function name. The actual name must be exported by including it in the module-definition
		/// file of the executable or DLL file.
		/// </summary>
		/// <param name="unnamedParam1">Identifier of the installable ACM driver.</param>
		/// <param name="unnamedParam2">
		/// Handle to the installable ACM driver. This parameter is a unique handle the ACM assigns to the driver.
		/// </param>
		/// <param name="unnamedParam3">ACM driver message.</param>
		/// <param name="unnamedParam4">Message parameter.</param>
		/// <param name="unnamedParam5">Message parameter.</param>
		/// <returns>Returns zero if successful or an error otherwise.</returns>
		/// <remarks>
		/// Applications should not call any system-defined functions from inside a callback function, except for <c>PostMessage</c>,
		/// timeGetSystemTime, timeGetTime, timeSetEvent, timeKillEvent, midiOutShortMsg, midiOutLongMsg, and <c>OutputDebugStr</c>.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msacm/nc-msacm-acmdriverproc ACMDRIVERPROC Acmdriverproc; LRESULT
		// Acmdriverproc( DWORD_PTR unnamedParam1, HACMDRIVERID unnamedParam2, UINT unnamedParam3, LPARAM unnamedParam4, LPARAM
		// unnamedParam5 ) {...}
		[PInvokeData("msacm.h", MSDNShortId = "NC:msacm.ACMDRIVERPROC")]
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate IntPtr ACMDRIVERPROC(IntPtr unnamedParam1, HACMDRIVERID unnamedParam2, uint unnamedParam3, IntPtr unnamedParam4, IntPtr unnamedParam5);

		/// <summary>
		/// The <c>acmFilterChooseHookProc</c> function specifies a user-defined function that hooks the acmFilterChoose dialog box.
		/// </summary>
		/// <param name="hwnd">Window handle for the dialog box.</param>
		/// <param name="uMsg">Window message.</param>
		/// <param name="wParam">Message parameter.</param>
		/// <param name="lParam">Message parameter.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>To customize the dialog box selections, a hook function can optionally process the MM_ACM_FILTERCHOOSE message.</para>
		/// <para>You should use this function the same way as you use the Common Dialog hook functions for customizing common dialog boxes.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msacm/nc-msacm-acmfilterchoosehookproc ACMFILTERCHOOSEHOOKPROC
		// Acmfilterchoosehookproc; UINT Acmfilterchoosehookproc( HWND hwnd, UINT uMsg, WPARAM wParam, LPARAM lParam ) {...}
		[PInvokeData("msacm.h", MSDNShortId = "NC:msacm.ACMFILTERCHOOSEHOOKPROC")]
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate uint ACMFILTERCHOOSEHOOKPROC(HWND hwnd, uint uMsg, IntPtr wParam, IntPtr lParam);

		/// <summary>
		/// The <c>acmFilterEnumCallback</c> function specifies a callback function used with the acmFilterEnum function. The
		/// <c>acmFilterEnumCallback</c> name is a placeholder for an application-defined function name.
		/// </summary>
		/// <param name="hadid">Handle to the ACM driver identifier.</param>
		/// <param name="pafd">Pointer to an ACMFILTERDETAILS structure that contains the enumerated filter details for a filter tag.</param>
		/// <param name="dwInstance">Application-defined value specified in acmFilterEnum.</param>
		/// <param name="fdwSupport">
		/// <para>
		/// Driver-support flags specific to the driver identified by ACMDRIVERDETAILS structure, but they are specific to the filter that
		/// is being enumerated. This parameter can be a combination of the following values and identifies which operations the driver
		/// supports for the filter tag.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ACMDRIVERDETAILS_SUPPORTF_ASYNC</term>
		/// <term>Driver supports asynchronous conversions with the specified filter tag.</term>
		/// </item>
		/// <item>
		/// <term>ACMDRIVERDETAILS_SUPPORTF_CODEC</term>
		/// <term>
		/// Driver supports conversion between two different format tags while using the specified filter. For example, if a driver supports
		/// compression from WAVE_FORMAT_PCM to WAVE_FORMAT_ADPCM with the specified filter, this flag is set.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ACMDRIVERDETAILS_SUPPORTF_CONVERTER</term>
		/// <term>
		/// Driver supports conversion between two different formats of the same format tag while using the specified filter. For example,
		/// if a driver supports resampling of WAVE_FORMAT_PCM with the specified filter, this flag is set.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ACMDRIVERDETAILS_SUPPORTF_FILTER</term>
		/// <term>
		/// Driver supports a filter (modification of the data without changing any of the format attributes). For example, if a driver
		/// supports volume or echo operations on WAVE_FORMAT_PCM, this flag is set.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ACMDRIVERDETAILS_SUPPORTF_HARDWARE</term>
		/// <term>
		/// Driver supports hardware input, output, or both with the specified filter through a waveform-audio device. An application should
		/// use the acmMetrics function with the ACM_METRIC_HARDWARE_WAVE_INPUT and ACM_METRIC_HARDWARE_WAVE_OUTPUT metric indices to get
		/// the waveform-audio device identifiers associated with the supporting ACM driver.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>The callback function must return <c>TRUE</c> to continue enumeration or <c>FALSE</c> to stop enumeration.</returns>
		/// <remarks>
		/// <para>
		/// The <c>acmFilterEnum</c> function will return MMSYSERR_NOERROR (zero) if no filters are to be enumerated. Moreover, the callback
		/// function will not be called.
		/// </para>
		/// <para>
		/// The following functions should not be called from within the callback function: <c>acmDriverAdd</c>, <c>acmDriverRemove</c>, and <c>acmDriverPriority</c>.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// The msacm.h header defines ACMFILTERENUMCB as an alias which automatically selects the ANSI or Unicode version of this function
		/// based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
		/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
		/// Function Prototypes.
		/// </para>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msacm/nc-msacm-acmfilterenumcbw ACMFILTERENUMCBW Acmfilterenumcbw; BOOL
		// Acmfilterenumcbw( HACMDRIVERID hadid, LPACMFILTERDETAILSW pafd, DWORD_PTR dwInstance, DWORD fdwSupport ) {...}
		[PInvokeData("msacm.h", MSDNShortId = "NC:msacm.ACMFILTERENUMCBW")]
		[UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Auto)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public delegate bool ACMFILTERENUMCB(HACMDRIVERID hadid, in ACMFILTERDETAILS pafd, IntPtr dwInstance, ACMDRIVERDETAILS_SUPPORTF fdwSupport);

		/// <summary>
		/// The <c>acmFilterTagEnumCallback</c> function specifies a callback function used with the acmFilterTagEnum function. The
		/// <c>acmFilterTagEnumCallback</c> function name is a placeholder for an application-defined function name.
		/// </summary>
		/// <param name="hadid">Handle to the ACM driver identifier.</param>
		/// <param name="paftd">Pointer to an ACMFILTERTAGDETAILS structure that contains the enumerated filter tag details.</param>
		/// <param name="dwInstance">Application-defined value specified in acmFilterTagEnum.</param>
		/// <param name="fdwSupport">
		/// <para>
		/// Driver-support flags specific to the driver identifier ACMDRIVERDETAILS structure. This parameter can be a combination of the
		/// following values and identifies which operations the driver supports with the filter tag.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ACMDRIVERDETAILS_SUPPORTF_ASYNC</term>
		/// <term>Driver supports asynchronous conversions with the specified filter tag.</term>
		/// </item>
		/// <item>
		/// <term>ACMDRIVERDETAILS_SUPPORTF_CODEC</term>
		/// <term>
		/// Driver supports conversion between two different format tags while using the specified filter tag. For example, if a driver
		/// supports compression from WAVE_FORMAT_PCM to WAVE_FORMAT_ADPCM with the specified filter tag, this flag is set.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ACMDRIVERDETAILS_SUPPORTF_CONVERTER</term>
		/// <term>
		/// Driver supports conversion between two different formats of the same format tag while using the specified filter tag. For
		/// example, if a driver supports resampling of WAVE_FORMAT_PCM with the specified filter tag, this flag is set.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ACMDRIVERDETAILS_SUPPORTF_FILTER</term>
		/// <term>
		/// Driver supports a filter (modification of the data without changing any of the format attributes). For example, if a driver
		/// supports volume or echo operations on WAVE_FORMAT_PCM, this flag is set.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ACMDRIVERDETAILS_SUPPORTF_HARDWARE</term>
		/// <term>
		/// Driver supports hardware input, output, or both with the specified filter tag through a waveform-audio device. An application
		/// should use the acmMetrics function with the ACM_METRIC_HARDWARE_WAVE_INPUT and ACM_METRIC_HARDWARE_WAVE_OUTPUT metric indices to
		/// get the waveform-audio device identifiers associated with the supporting ACM driver.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>The callback function must return <c>TRUE</c> to continue enumeration or <c>FALSE</c> to stop enumeration.</returns>
		/// <remarks>
		/// <para>
		/// The acmFilterTagEnum function returns <c>MMSYSERR_NOERROR</c> (zero) if no filter tags are to be enumerated. Moreover, the
		/// callback function will not be called.
		/// </para>
		/// <para>The following functions should not be called from within the callback function: acmDriverAdd, acmDriverRemove, and acmDriverPriority.</para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// The msacm.h header defines ACMFILTERTAGENUMCB as an alias which automatically selects the ANSI or Unicode version of this
		/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
		/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
		/// for Function Prototypes.
		/// </para>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msacm/nc-msacm-acmfiltertagenumcbw ACMFILTERTAGENUMCBW Acmfiltertagenumcbw;
		// BOOL Acmfiltertagenumcbw( HACMDRIVERID hadid, LPACMFILTERTAGDETAILSW paftd, DWORD_PTR dwInstance, DWORD fdwSupport ) {...}
		[PInvokeData("msacm.h", MSDNShortId = "NC:msacm.ACMFILTERTAGENUMCBW")]
		[UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Auto)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public delegate bool ACMFILTERTAGENUMCB(HACMDRIVERID hadid, in ACMFILTERTAGDETAILS paftd, IntPtr dwInstance, ACMDRIVERDETAILS_SUPPORTF fdwSupport);

		/// <summary>
		/// The <c>acmFormatChooseHookProc</c> function specifies a user-defined function that hooks the acmFormatChoose dialog box. The
		/// <c>acmFormatChooseHookProc</c> name is a placeholder for an application-defined name.
		/// </summary>
		/// <param name="hwnd">Window handle for the dialog box.</param>
		/// <param name="uMsg">Window message.</param>
		/// <param name="wParam">Message parameter.</param>
		/// <param name="lParam">Message parameter.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// If the hook function processes one of the WM_CTLCOLOR messages, this function must return a handle of the brush that should be
		/// used to paint the control background.
		/// </para>
		/// <para>A hook function can optionally process the MM_ACM_FORMATCHOOSE message.</para>
		/// <para>You should use this function the same way as you use the Common Dialog hook functions for customizing common dialog boxes.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msacm/nc-msacm-acmformatchoosehookproc ACMFORMATCHOOSEHOOKPROC
		// Acmformatchoosehookproc; UINT Acmformatchoosehookproc( HWND hwnd, UINT uMsg, WPARAM wParam, LPARAM lParam ) {...}
		[PInvokeData("msacm.h", MSDNShortId = "NC:msacm.ACMFORMATCHOOSEHOOKPROC")]
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate uint ACMFORMATCHOOSEHOOKPROC(HWND hwnd, uint uMsg, IntPtr wParam, IntPtr lParam);

		/// <summary>
		/// The <c>acmFormatEnumCallback</c> function specifies a callback function used with the acmFormatEnum function. The
		/// <c>acmFormatEnumCallback</c> name is a placeholder for the application-defined function name.
		/// </summary>
		/// <param name="hadid">Handle to the ACM driver identifier.</param>
		/// <param name="pafd">Pointer to an ACMFORMATDETAILS structure that contains the enumerated format details for a format tag.</param>
		/// <param name="dwInstance">Application-defined value specified in the acmFormatEnum function.</param>
		/// <param name="fdwSupport">
		/// <para>
		/// Driver support flags specific to the driver identified by ACMDRIVERDETAILS structure, but they are specific to the format that
		/// is being enumerated. This parameter can be a combination of the following values and indicates which operations the driver
		/// supports for the format tag.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ACMDRIVERDETAILS_SUPPORTF_ASYNC</term>
		/// <term>Driver supports asynchronous conversions with the specified filter tag.</term>
		/// </item>
		/// <item>
		/// <term>ACMDRIVERDETAILS_SUPPORTF_CODEC</term>
		/// <term>
		/// Driver supports conversion between two different format tags for the specified format. For example, if a driver supports
		/// compression from WAVE_FORMAT_PCM to WAVE_FORMAT_ADPCM with the specified format, this flag is set.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ACMDRIVERDETAILS_SUPPORTF_CONVERTER</term>
		/// <term>
		/// Driver supports conversion between two different formats of the same format tag while using the specified format. For example,
		/// if a driver supports resampling of WAVE_FORMAT_PCM to the specified format, this flag is set.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ACMDRIVERDETAILS_SUPPORTF_FILTER</term>
		/// <term>
		/// Driver supports a filter (modification of the data without changing any of the format attributes) with the specified format. For
		/// example, if a driver supports volume or echo operations on WAVE_FORMAT_PCM, this flag is set.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ACMDRIVERDETAILS_SUPPORTF_HARDWARE</term>
		/// <term>
		/// Driver supports hardware input, output, or both of the specified format tags through a waveform-audio device. An application
		/// should use the acmMetrics function with the ACM_METRIC_HARDWARE_WAVE_INPUT and ACM_METRIC_HARDWARE_WAVE_OUTPUT metric indexes to
		/// get the waveform-audio device identifiers associated with the supporting ACM driver.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>The callback function must return <c>TRUE</c> to continue enumeration or <c>FALSE</c> to stop enumeration.</returns>
		/// <remarks>
		/// <para>
		/// The acmFormatEnum function will return MMSYSERR_NOERROR (zero) if no formats are to be enumerated. Moreover, the callback
		/// function will not be called.
		/// </para>
		/// <para>The following functions should not be called from within the callback function: acmDriverAdd, acmDriverRemove, and acmDriverPriority.</para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// The msacm.h header defines ACMFORMATENUMCB as an alias which automatically selects the ANSI or Unicode version of this function
		/// based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
		/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
		/// Function Prototypes.
		/// </para>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msacm/nc-msacm-acmformatenumcbw ACMFORMATENUMCBW Acmformatenumcbw; BOOL
		// Acmformatenumcbw( HACMDRIVERID hadid, LPACMFORMATDETAILSW pafd, DWORD_PTR dwInstance, DWORD fdwSupport ) {...}
		[PInvokeData("msacm.h", MSDNShortId = "NC:msacm.ACMFORMATENUMCBW")]
		[UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Auto)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public delegate bool ACMFORMATENUMCB(HACMDRIVERID hadid, in ACMFORMATDETAILS pafd, IntPtr dwInstance, ACMDRIVERDETAILS_SUPPORTF fdwSupport);

		/// <summary>
		/// The <c>acmFormatTagEnumCallback</c> function specifies a callback function used with the acmFormatTagEnum function. The
		/// <c>acmFormatTagEnumCallback</c> name is a placeholder for an application-defined function name.
		/// </summary>
		/// <param name="hadid">Handle to the ACM driver identifier.</param>
		/// <param name="paftd">Pointer to an ACMFORMATTAGDETAILS structure that contains the enumerated format tag details.</param>
		/// <param name="dwInstance">Application-defined value specified in the acmFormatTagEnum function.</param>
		/// <param name="fdwSupport">
		/// <para>
		/// Driver-support flags specific to the format tag. These flags are identical to the ACMDRIVERDETAILS structure. This parameter can
		/// be a combination of the following values and indicates which operations the driver supports with the format tag.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ACMDRIVERDETAILS_SUPPORTF_ASYNC</term>
		/// <term>Driver supports asynchronous conversions with the specified filter tag.</term>
		/// </item>
		/// <item>
		/// <term>ACMDRIVERDETAILS_SUPPORTF_CODEC</term>
		/// <term>
		/// Driver supports conversion between two different format tags where one of the tags is the specified format tag. For example, if
		/// a driver supports compression from WAVE_FORMAT_PCM to WAVE_FORMAT_ADPCM, this flag is set.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ACMDRIVERDETAILS_SUPPORTF_CONVERTER</term>
		/// <term>
		/// Driver supports conversion between two different formats of the specified format tag. For example, if a driver supports
		/// resampling of WAVE_FORMAT_PCM, this flag is set.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ACMDRIVERDETAILS_SUPPORTF_FILTER</term>
		/// <term>
		/// Driver supports a filter (modification of the data without changing any of the format attributes). For example, if a driver
		/// supports volume or echo operations on the specified format tag, this flag is set.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ACMDRIVERDETAILS_SUPPORTF_HARDWARE</term>
		/// <term>
		/// Driver supports hardware input, output, or both of the specified format tag through a waveform-audio device. An application
		/// should use acmMetrics with the ACM_METRIC_HARDWARE_WAVE_INPUT and ACM_METRIC_HARDWARE_WAVE_OUTPUT metric indexes to get the
		/// waveform-audio device identifiers associated with the supporting ACM driver.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>The callback function must return <c>TRUE</c> to continue enumeration or <c>FALSE</c> to stop enumeration.</returns>
		/// <remarks>
		/// <para>
		/// The acmFormatTagEnum function will return MMSYSERR_NOERROR (zero) if no format tags are to be enumerated. Moreover, the callback
		/// function will not be called.
		/// </para>
		/// <para>The following functions should not be called from within the callback function: acmDriverAdd, acmDriverRemove, and acmDriverPriority.</para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// The msacm.h header defines ACMFORMATTAGENUMCB as an alias which automatically selects the ANSI or Unicode version of this
		/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
		/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
		/// for Function Prototypes.
		/// </para>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msacm/nc-msacm-acmformattagenumcbw ACMFORMATTAGENUMCBW Acmformattagenumcbw;
		// BOOL Acmformattagenumcbw( HACMDRIVERID hadid, LPACMFORMATTAGDETAILSW paftd, DWORD_PTR dwInstance, DWORD fdwSupport ) {...}
		[PInvokeData("msacm.h", MSDNShortId = "NC:msacm.ACMFORMATTAGENUMCBW")]
		[UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Auto)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public delegate bool ACMFORMATTAGENUMCB(HACMDRIVERID hadid, in ACMFORMATTAGDETAILS paftd, IntPtr dwInstance, uint fdwSupport);

		/// <summary>Flags for adding ACM drivers.</summary>
		[Flags]
		public enum ACM_DRIVERADDF : uint
		{
			/// <summary>
			/// The lParam parameter is a registry value name in HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Drivers32.
			/// The value identifies a DLL that implements an ACM codec. Applications can use this flag if new registry entries are created
			/// after the application has already started using the ACM.
			/// </summary>
			ACM_DRIVERADDF_NAME = 0x00000001,

			/// <summary>
			/// The lParam parameter is a driver function address conforming to the acmDriverProc prototype. The function may reside in
			/// either an executable or DLL file.
			/// </summary>
			ACM_DRIVERADDF_FUNCTION = 0x00000003,

			/// <summary>
			/// The lParam parameter is a handle of a notification window that receives messages when changes to global driver priorities
			/// and states are made. The window message to receive is defined by the application and must be passed in dwPriority. The
			/// wParam and lParam parameters passed with the window message are reserved for future use and should be ignored.
			/// ACM_DRIVERADDF_GLOBAL cannot be specified in conjunction with this flag. For more information about driver priorities, see
			/// the description for the acmDriverPriority function.
			/// </summary>
			ACM_DRIVERADDF_NOTIFYHWND = 0x00000004,

			/// <summary>
			/// The ACM automatically gives a local driver higher priority than a global driver when searching for a driver to satisfy a
			/// function call. For more information, see Adding Drivers Within an Application.
			/// </summary>
			ACM_DRIVERADDF_LOCAL = 0x00000000,

			/// <summary>
			/// Provided for compatibility with 16-bit applications. For the Win32 API, ACM drivers added by the acmDriverAdd function can
			/// be used only by the application that added the driver. This is true whether or not ACM_DRIVERADDF_GLOBAL is specified. For
			/// more information, see Adding Drivers Within an Application.
			/// </summary>
			ACM_DRIVERADDF_GLOBAL = 0x00000008,
		}

		/// <summary>Flags for enumerating ACM drivers.</summary>
		[PInvokeData("msacm.h", MSDNShortId = "NF:msacm.acmDriverEnum")]
		[Flags]
		public enum ACM_DRIVERENUMF : uint
		{
			/// <summary>Only global drivers should be included in the enumeration.</summary>
			ACM_DRIVERENUMF_NOLOCAL = 0x40000000,

			/// <summary>
			/// Disabled ACM drivers should be included in the enumeration. Drivers can be disabled by the user through the Control Panel or
			/// by an application using the acmDriverPriority function. If a driver is disabled, the fdwSupport parameter to the callback
			/// function will have the ACMDRIVERDETAILS_SUPPORTF_DISABLED flag set.
			/// </summary>
			ACM_DRIVERENUMF_DISABLED = 0x80000000,
		}

		/// <summary>Flags for setting priorities of ACM drivers.</summary>
		[PInvokeData("msacm.h", MSDNShortId = "NF:msacm.acmDriverPriority")]
		[Flags]
		public enum ACM_DRIVERPRIORITYF : uint
		{
			/// <summary>ACM driver should be enabled if it is currently disabled. Enabling an enabled driver does nothing.</summary>
			ACM_DRIVERPRIORITYF_ENABLE = 0x00000001,

			/// <summary>ACM driver should be disabled if it is currently enabled. Disabling a disabled driver does nothing.</summary>
			ACM_DRIVERPRIORITYF_DISABLE = 0x00000002,

			/// <summary>
			/// Change notification broadcasts should be deferred. An application must reenable notification broadcasts as soon as possible
			/// with the ACM_DRIVERPRIORITYF_END flag. Note that hadid must be NULL, dwPriority must be zero, and only the
			/// ACM_DRIVERPRIORITYF_BEGIN flag can be set.
			/// </summary>
			ACM_DRIVERPRIORITYF_BEGIN = 0x00010000,

			/// <summary>
			/// Calling task wants to reenable change notification broadcasts. An application must call acmDriverPriority with
			/// ACM_DRIVERPRIORITYF_END for each successful call with the ACM_DRIVERPRIORITYF_BEGIN flag. Note that hadid must be NULL,
			/// dwPriority must be zero, and only the ACM_DRIVERPRIORITYF_END flag can be set.
			/// </summary>
			ACM_DRIVERPRIORITYF_END = 0x00020000,
		}

		/// <summary>Flags for getting the details.</summary>
		[Flags]
		public enum ACM_FILTERDETAILSF : uint
		{
			/// <summary>
			/// A filter index for the filter tag was given in the dwFilterIndex member of the ACMFILTERDETAILS structure. The filter
			/// details will be returned in the structure defined by pafd. The index ranges from zero to one less than the cStandardFilters
			/// member returned in the ACMFILTERTAGDETAILS structure for a filter tag. An application must specify a driver handle for had
			/// when retrieving filter details with this flag. For information about what members should be initialized before calling this
			/// function, see the ACMFILTERDETAILS structure.
			/// </summary>
			ACM_FILTERDETAILSF_INDEX = 0x00000000,

			/// <summary>
			/// A WAVEFILTER structure pointed to by the pwfltr member of the ACMFILTERDETAILS structure was given and the remaining details
			/// should be returned. The dwFilterTag member of the ACMFILTERDETAILS structure must be initialized to the same filter tag
			/// pwfltr specifies. This query type can be used to get a string description of an arbitrary filter structure. If an
			/// application specifies an ACM driver handle for had, details on the filter will be returned for that driver. If an
			/// application specifies NULL for had, the ACM finds the first acceptable driver to return the details.
			/// </summary>
			ACM_FILTERDETAILSF_FILTER = 0x00000001,
		}

		/// <summary>Optional flags for restricting the type of filters listed in the dialog box.</summary>
		[PInvokeData("msacm.h", MSDNShortId = "NS:msacm.tACMFILTERCHOOSE")]
		[Flags]
		public enum ACM_FILTERENUMF : uint
		{
			/// <summary>
			/// The dwFilterTag member of the WAVEFILTER structure pointed to by the pwfltrEnum member is valid. The enumerator will only
			/// enumerate a filter that conforms to this attribute.
			/// </summary>
			ACM_FILTERENUMF_DWFILTERTAG = 0x00010000
		}

		/// <summary>Flags for getting the details.</summary>
		[PInvokeData("msacm.h", MSDNShortId = "NF:msacm.acmFilterTagDetailsW")]
		[Flags]
		public enum ACM_FILTERTAGDETAILSF : uint
		{
			/// <summary></summary>
			ACM_FILTERTAGDETAILSF_INDEX = 0x00000000,

			/// <summary></summary>
			ACM_FILTERTAGDETAILSF_FILTERTAG = 0x00000001,

			/// <summary></summary>
			ACM_FILTERTAGDETAILSF_LARGESTSIZE = 0x00000002,
		}

		/// <summary>Flags for getting the waveform-audio format tag details.</summary>
		[PInvokeData("msacm.h", MSDNShortId = "NF:msacm.acmFormatDetailsW")]
		[Flags]
		public enum ACM_FORMATDETAILSF : uint
		{
			/// <summary>
			/// A format index for the format tag was given in the dwFormatIndex member of the ACMFORMATDETAILS structure. The format
			/// details will be returned in the structure defined by pafd. The index ranges from zero to one less than the cStandardFormats
			/// member returned in the ACMFORMATTAGDETAILS structure for a format tag. An application must specify a driver handle for had
			/// when retrieving format details with this flag. For information about which members should be initialized before calling this
			/// function, see the ACMFORMATDETAILS structure.
			/// </summary>
			ACM_FORMATDETAILSF_INDEX = 0x00000000,

			/// <summary>
			/// ACMFORMATDETAILS structure was given and the remaining details should be returned. The dwFormatTag member of the
			/// ACMFORMATDETAILS structure must be initialized to the same format tag as pwfx specifies. This query type can be used to get
			/// a string description of an arbitrary format structure. If an application specifies an ACM driver handle for had , details on
			/// the format will be returned for that driver. If an application specifies NULL for had , the ACM finds the first acceptable
			/// driver to return the details.
			/// </summary>
			ACM_FORMATDETAILSF_FORMAT = 0x00000001,
		}

		/// <summary>Optional flags for restricting the type of formats listed in the dialog box.</summary>
		[PInvokeData("msacm.h", MSDNShortId = "NS:msacm.tACMFORMATCHOOSE")]
		[Flags]
		public enum ACM_FORMATENUMF : uint
		{
			/// <summary>
			/// The wFormatTag member of the WAVEFORMATEX structure pointed to by the pwfxEnum member is valid. The enumerator will
			/// enumerate only a format that conforms to this attribute.
			/// </summary>
			ACM_FORMATENUMF_WFORMATTAG = 0x00010000,

			/// <summary>
			/// The nChannels member of the WAVEFORMATEX structure pointed to by the pwfxEnum member is valid. The enumerator will enumerate
			/// only a format that conforms to this attribute.
			/// </summary>
			ACM_FORMATENUMF_NCHANNELS = 0x00020000,

			/// <summary>
			/// The nSamplesPerSec member of the WAVEFORMATEX structure pointed to by the pwfxEnum member is valid. The enumerator will
			/// enumerate only a format that conforms to this attribute.
			/// </summary>
			ACM_FORMATENUMF_NSAMPLESPERSEC = 0x00040000,

			/// <summary>
			/// The wBitsPerSample member of the WAVEFORMATEX structure pointed to by the pwfxEnum member is valid. The enumerator will
			/// enumerate only a format that conforms to this attribute.
			/// </summary>
			ACM_FORMATENUMF_WBITSPERSAMPLE = 0x00080000,

			/// <summary>
			/// The WAVEFORMATEX structure pointed to by the pwfxEnum member is valid. The enumerator will enumerate only destination
			/// formats that can be converted from the given pwfxEnum format.
			/// </summary>
			ACM_FORMATENUMF_CONVERT = 0x00100000,

			/// <summary>
			/// The WAVEFORMATEX structure pointed to by the pwfxEnum member is valid. The enumerator will enumerate all suggested
			/// destination formats for the given pwfxEnum format.
			/// </summary>
			ACM_FORMATENUMF_SUGGEST = 0x00200000,

			/// <summary>
			/// The enumerator should enumerate only formats that are supported in hardware by one or more of the installed waveform-audio
			/// devices. This flag provides a way for an application to choose only formats native to an installed waveform-audio device.
			/// </summary>
			ACM_FORMATENUMF_HARDWARE = 0x00400000,

			/// <summary>The enumerator should enumerate only formats that are supported for input (recording).</summary>
			ACM_FORMATENUMF_INPUT = 0x00800000,

			/// <summary>The enumerator should enumerate only formats that are supported for output (playback).</summary>
			ACM_FORMATENUMF_OUTPUT = 0x01000000,
		}

		/// <summary>Flags for matching the desired destination format.</summary>
		[PInvokeData("msacm.h", MSDNShortId = "NF:msacm.acmFormatSuggest")]
		[Flags]
		public enum ACM_FORMATSUGGESTF : uint
		{
			/// <summary>
			/// The wFormatTag member of the structure pointed to by pwfxDst is valid. The ACM will query acceptable installed drivers that
			/// can suggest a destination format matching wFormatTag or fail.
			/// </summary>
			ACM_FORMATSUGGESTF_WFORMATTAG = 0x00010000,

			/// <summary>
			/// The nChannels member of the structure pointed to by pwfxDst is valid. The ACM will query acceptable installed drivers that
			/// can suggest a destination format matching nChannels or fail.
			/// </summary>
			ACM_FORMATSUGGESTF_NCHANNELS = 0x00020000,

			/// <summary>
			/// The nSamplesPerSec member of the structure pointed to by pwfxDst is valid. The ACM will query acceptable installed drivers
			/// that can suggest a destination format matching nSamplesPerSec or fail.
			/// </summary>
			ACM_FORMATSUGGESTF_NSAMPLESPERSEC = 0x00040000,

			/// <summary>
			/// The wBitsPerSample member of the structure pointed to by pwfxDst is valid. The ACM will query acceptable installed drivers
			/// that can suggest a destination format matching wBitsPerSample or fail.
			/// </summary>
			ACM_FORMATSUGGESTF_WBITSPERSAMPLE = 0x00080000,
		}

		/// <summary>Flags for getting the details.</summary>
		[PInvokeData("msacm.h", MSDNShortId = "NF:msacm.acmFormatTagDetailsW")]
		[Flags]
		public enum ACM_FORMATTAGDETAILSF : uint
		{
			/// <summary>
			/// ACMDRIVERDETAILS structure for an ACM driver. An application must specify a driver handle forhadwhen retrieving format tag
			/// details with this flag.
			/// </summary>
			ACM_FORMATTAGDETAILSF_INDEX = 0x00000000,

			/// <summary>
			/// ACMFORMATTAGDETAILS structure. The format tag details will be returned in the structure pointed to bypaftd. If an
			/// application specifies an ACM driver handle forhad, details on the format tag will be returned for that driver. If an
			/// application specifiesNULLforhad, the ACM finds the first acceptable driver to return the details.
			/// </summary>
			ACM_FORMATTAGDETAILSF_FORMATTAG = 0x00000001,

			/// <summary>
			/// ACMFORMATTAGDETAILS structure must either be WAVE_FORMAT_UNKNOWN or the format tag to find the largest size for. If an
			/// application specifies an ACM driver handle forhad, details on the largest format tag will be returned for that driver. If an
			/// application specifiesNULLforhad, the ACM finds an acceptable driver with the largest format tag requested to return the details.
			/// </summary>
			ACM_FORMATTAGDETAILSF_LARGESTSIZE = 0x00000002,
		}

		/// <summary>Metric index to be returned in pMetric.</summary>
		[PInvokeData("msacm.h", MSDNShortId = "NF:msacm.acmMetrics")]
		public enum ACM_METRIC
		{
			/// <summary>
			/// Returned value is the total number of enabled global ACM drivers (of all support types) in the system. The hao parameter
			/// must be NULL for this metric index. The pMetric parameter must point to a buffer of a size equal to a DWORD value.
			/// </summary>
			[CorrespondingType(typeof(uint))]
			ACM_METRIC_COUNT_DRIVERS = 1,

			/// <summary>
			/// Returned value is the number of global ACM compressor or decompressor drivers in the system. The hao parameter must be NULL
			/// for this metric index. The pMetric parameter must point to a buffer of a size equal to a DWORD value.
			/// </summary>
			[CorrespondingType(typeof(uint))]
			ACM_METRIC_COUNT_CODECS,

			/// <summary>
			/// Returned value is the number of global ACM converter drivers in the system. The hao parameter must be NULL for this metric
			/// index. The pMetric parameter must point to a buffer of a size equal to a DWORD value.
			/// </summary>
			[CorrespondingType(typeof(uint))]
			ACM_METRIC_COUNT_CONVERTERS,

			/// <summary>
			/// Returned value is the number of global ACM filter drivers in the system. The hao parameter must be NULL for this metric
			/// index. The pMetric parameter must point to a buffer of a size equal to a DWORD value.
			/// </summary>
			[CorrespondingType(typeof(uint))]
			ACM_METRIC_COUNT_FILTERS,

			/// <summary>
			/// Returned value is the total number of global disabled ACM drivers (of all support types) in the system. The hao parameter
			/// must be NULL for this metric index. The pMetric parameter must point to a buffer of a size equal to a DWORD value. The sum
			/// of the ACM_METRIC_COUNT_DRIVERS and ACM_METRIC_COUNT_DISABLED metric indices is the total number of globally installed ACM drivers.
			/// </summary>
			[CorrespondingType(typeof(uint))]
			ACM_METRIC_COUNT_DISABLED,

			/// <summary>
			/// Returned value is the number of global ACM hardware drivers in the system. The hao parameter must be NULL for this metric
			/// index. The pMetric parameter must point to a buffer of a size equal to a DWORD value.
			/// </summary>
			[CorrespondingType(typeof(uint))]
			ACM_METRIC_COUNT_HARDWARE,

			/// <summary>
			/// Returned value is the total number of enabled local ACM drivers (of all support types) for the calling task. The hao
			/// parameter must be NULL for this metric index. The pMetric parameter must point to a buffer of a size equal to a DWORD value.
			/// </summary>
			[CorrespondingType(typeof(uint))]
			ACM_METRIC_COUNT_LOCAL_DRIVERS = 20,

			/// <summary>
			/// Returned value is the number of local ACM compressor drivers, ACM decompressor drivers, or both for the calling task. The
			/// hao parameter must be NULL for this metric index. The pMetric parameter must point to a buffer of a size equal to a DWORD value.
			/// </summary>
			[CorrespondingType(typeof(uint))]
			ACM_METRIC_COUNT_LOCAL_CODECS,

			/// <summary>
			/// Returned value is the number of local ACM converter drivers for the calling task. The hao parameter must be NULL for this
			/// metric index. The pMetric parameter must point to a buffer of a size equal to a DWORD value.
			/// </summary>
			[CorrespondingType(typeof(uint))]
			ACM_METRIC_COUNT_LOCAL_CONVERTERS,

			/// <summary>
			/// Returned value is the number of local ACM filter drivers for the calling task. The hao parameter must be NULL for this
			/// metric index. The pMetric parameter must point to a buffer of a size equal to a DWORD value.
			/// </summary>
			[CorrespondingType(typeof(uint))]
			ACM_METRIC_COUNT_LOCAL_FILTERS,

			/// <summary>
			/// Returned value is the total number of local disabled ACM drivers, of all support types, for the calling task. The hao
			/// parameter must be NULL for this metric index. The pMetric parameter must point to a buffer of a size equal to a DWORD value.
			/// The sum of the ACM_METRIC_COUNT_LOCAL_DRIVERS and ACM_METRIC_COUNT_LOCAL_DISABLED metric indices is the total number of
			/// locally installed ACM drivers.
			/// </summary>
			[CorrespondingType(typeof(uint))]
			ACM_METRIC_COUNT_LOCAL_DISABLED,

			/// <summary>
			/// Returned value is the waveform-audio input device identifier associated with the specified driver. The hao parameter must be
			/// a valid ACM driver identifier of the HACMDRIVERID data type that supports the ACMDRIVERDETAILS_SUPPORTF_HARDWARE flag. If no
			/// waveform-audio input device is associated with the driver, MMSYSERR_NOTSUPPORTED is returned. The pMetric parameter must
			/// point to a buffer of a size equal to a DWORD value.
			/// </summary>
			[CorrespondingType(typeof(uint))]
			ACM_METRIC_HARDWARE_WAVE_INPUT = 30,

			/// <summary>
			/// Returned value is the waveform-audio output device identifier associated with the specified driver. The hao parameter must
			/// be a valid ACM driver identifier of the HACMDRIVERID data type that supports the ACMDRIVERDETAILS_SUPPORTF_HARDWARE flag. If
			/// no waveform-audio output device is associated with the driver, MMSYSERR_NOTSUPPORTED is returned. The pMetric parameter must
			/// point to a buffer of a size equal to a DWORD value.
			/// </summary>
			[CorrespondingType(typeof(uint))]
			ACM_METRIC_HARDWARE_WAVE_OUTPUT,

			/// <summary>
			/// Returned value is the size of the largest WAVEFORMATEX structure. If hao is NULL, the return value is the largest
			/// WAVEFORMATEX structure in the system. If hao identifies an open instance of an ACM driver of the HACMDRIVER data type or an
			/// ACM driver identifier of the HACMDRIVERID data type, the largest WAVEFORMATEX structure for that driver is returned. The
			/// pMetric parameter must point to a buffer of a size equal to a DWORD value. This metric is not allowed for an ACM stream
			/// handle of the HACMSTREAM data type.
			/// </summary>
			[CorrespondingType(typeof(uint))]
			ACM_METRIC_MAX_SIZE_FORMAT = 50,

			/// <summary>
			/// Returned value is the size of the largest WAVEFILTER structure. If hao is NULL, the return value is the largest WAVEFILTER
			/// structure in the system. If hao identifies an open instance of an ACM driver of the HACMDRIVER data type or an ACM driver
			/// identifier of the HACMDRIVERID data type, the largest WAVEFILTER structure for that driver is returned. The pMetric
			/// parameter must point to a buffer of a size equal to a DWORD value. This metric is not allowed for an ACM stream handle of
			/// the HACMSTREAM data type.
			/// </summary>
			[CorrespondingType(typeof(uint))]
			ACM_METRIC_MAX_SIZE_FILTER,

			/// <summary>
			/// Returned value is the fdwSupport flags for the specified driver. The hao parameter must be a valid ACM driver identifier of
			/// the HACMDRIVERID data type. The pMetric parameter must point to a buffer of a size equal to a DWORD value.
			/// </summary>
			[CorrespondingType(typeof(uint))]
			ACM_METRIC_DRIVER_SUPPORT = 100,

			/// <summary>
			/// Returned value is the current priority for the specified driver. The hao parameter must be a valid ACM driver identifier of
			/// the HACMDRIVERID data type. The pMetric parameter must point to a buffer of a size equal to a DWORD value.
			/// </summary>
			[CorrespondingType(typeof(uint))]
			ACM_METRIC_DRIVER_PRIORITY,
		}

		/// <summary>Flags for doing the conversion.</summary>
		[Flags]
		public enum ACM_STREAMCONVERTF : uint
		{
			/// <summary>
			/// Only integral numbers of blocks will be converted. Converted data will end on block-aligned boundaries. An application
			/// should use this flag for all conversions on a stream until there is not enough source data to convert to a block-aligned
			/// destination. In this case, the last conversion should be specified without this flag.
			/// </summary>
			ACM_STREAMCONVERTF_BLOCKALIGN = 0x00000004,

			/// <summary>
			/// ACM conversion stream should reinitialize its instance data. For example, if a conversion stream holds instance data, such
			/// as delta or predictor information, this flag will restore the stream to starting defaults. This flag can be specified with
			/// the ACM_STREAMCONVERTF_END flag.
			/// </summary>
			ACM_STREAMCONVERTF_START = 0x00000010,

			/// <summary>
			/// ACM conversion stream should begin returning pending instance data. For example, if a conversion stream holds instance data,
			/// such as the end of an echo filter operation, this flag will cause the stream to start returning this remaining data with
			/// optional source data. This flag can be specified with the ACM_STREAMCONVERTF_START flag.
			/// </summary>
			ACM_STREAMCONVERTF_END = 0x00000020,
		}

		/// <summary></summary>
		[Flags]
		public enum ACM_STREAMOPENF : uint
		{
			/// <summary>
			/// ACM will be queried to determine whether it supports the given conversion. A conversion stream will not be opened, and no
			/// handle will be returned in the phas parameter.
			/// </summary>
			ACM_STREAMOPENF_QUERY = 0x00000001,

			/// <summary>ACMSTREAMHEADER structure for the ACMSTREAMHEADER_STATUSF_DONE flag.</summary>
			ACM_STREAMOPENF_ASYNC = 0x00000002,

			/// <summary>
			/// ACM will not consider time constraints when converting the data. By default, the driver will attempt to convert the data in
			/// real time. For some formats, specifying this flag might improve the audio quality or other characteristics.
			/// </summary>
			ACM_STREAMOPENF_NONREALTIME = 0x00000004,

			/// <summary>The dwCallback parameter is a window handle.</summary>
			CALLBACK_WINDOW = 0x00010000,

			/// <summary>The dwCallback parameter is a callback procedure address.</summary>
			CALLBACK_FUNCTION = 0x00030000,

			/// <summary>The dwCallback parameter is an event handle.</summary>
			CALLBACK_EVENT = 0x00050000,
		}

		/// <summary>Flags for the stream size query.</summary>
		[PInvokeData("msacm.h", MSDNShortId = "NF:msacm.acmStreamSize")]
		[Flags]
		public enum ACM_STREAMSIZEF : uint
		{
			/// <summary>
			/// The cbInput parameter contains the size of the source buffer. The pdwOutputBytes parameter will receive the recommended
			/// destination buffer size, in bytes.
			/// </summary>
			ACM_STREAMSIZEF_SOURCE = 0x00000000,

			/// <summary>
			/// The cbInput parameter contains the size of the destination buffer. The pdwOutputBytes parameter will receive the recommended
			/// source buffer size, in bytes.
			/// </summary>
			ACM_STREAMSIZEF_DESTINATION = 0x00000001,
		}

		/// <summary>Support flags for the driver.</summary>
		[PInvokeData("msacm.h", MSDNShortId = "NS:msacm.tACMDRIVERDETAILS")]
		[Flags]
		public enum ACMDRIVERDETAILS_SUPPORTF : uint
		{
			/// <summary>
			/// Driver supports conversion between two different format tags. For example, if a driver supports compression from
			/// WAVE_FORMAT_PCM to WAVE_FORMAT_ADPCM, this flag is set.
			/// </summary>
			ACMDRIVERDETAILS_SUPPORTF_CODEC = 0x00000001,

			/// <summary>
			/// Driver supports conversion between two different formats of the same format tag. For example, if a driver supports
			/// resampling of WAVE_FORMAT_PCM, this flag is set.
			/// </summary>
			ACMDRIVERDETAILS_SUPPORTF_CONVERTER = 0x00000002,

			/// <summary>
			/// Driver supports a filter (modification of the data without changing any of the format attributes). For example, if a driver
			/// supports volume or echo operations on WAVE_FORMAT_PCM, this flag is set.
			/// </summary>
			ACMDRIVERDETAILS_SUPPORTF_FILTER = 0x00000004,

			/// <summary>
			/// Driver supports hardware input, output, or both through a waveform-audio device. An application should use the acmMetrics
			/// function with the ACM_METRIC_HARDWARE_WAVE_INPUT and ACM_METRIC_HARDWARE_WAVE_OUTPUT metric indexes to get the
			/// waveform-audio device identifiers associated with the supporting ACM driver.
			/// </summary>
			ACMDRIVERDETAILS_SUPPORTF_HARDWARE = 0x00000008,

			/// <summary>Driver supports asynchronous conversions.</summary>
			ACMDRIVERDETAILS_SUPPORTF_ASYNC = 0x00000010,

			/// <summary>The driver has been installed locally with respect to the current task.</summary>
			ACMDRIVERDETAILS_SUPPORTF_LOCAL = 0x40000000,

			/// <summary>
			/// Driver has been disabled. This flag is set by the ACM for a driver when it has been disabled for any of a number of reasons.
			/// Disabled drivers cannot be opened and can be used only under very limited circumstances.
			/// </summary>
			ACMDRIVERDETAILS_SUPPORTF_DISABLED = 0x80000000,
		}

		/// <summary>Optional style flags for the acmFilterChoose function.</summary>
		[PInvokeData("msacm.h", MSDNShortId = "NS:msacm.tACMFILTERCHOOSE")]
		[Flags]
		public enum ACMFILTERCHOOSE_STYLEF : uint
		{
			/// <summary>
			/// A help button will appear in the dialog box. To use a custom Help file, an application must register the ACMHELPMSGSTRING
			/// value with the RegisterWindowMessage function. When the user presses the help button, the registered message is posted to
			/// the owner.
			/// </summary>
			ACMFILTERCHOOSE_STYLEF_SHOWHELP = 0x00000004,

			/// <summary>
			/// Enables the hook function specified in the pfnHook member. An application can use hook functions for a variety of
			/// customizations, including answering the MM_ACM_FILTERCHOOSE message.
			/// </summary>
			ACMFILTERCHOOSE_STYLEF_ENABLEHOOK = 0x00000008,

			/// <summary>Causes the ACM to create the dialog box template identified by the hInstance and pszTemplateName members.</summary>
			ACMFILTERCHOOSE_STYLEF_ENABLETEMPLATE = 0x00000010,

			/// <summary>
			/// The hInstance member identifies a data block that contains a preloaded dialog box template. If this flag is specified, the
			/// ACM ignores the pszTemplateName member.
			/// </summary>
			ACMFILTERCHOOSE_STYLEF_ENABLETEMPLATEHANDLE = 0x00000020,

			/// <summary>
			/// The buffer pointed to by pwfltr contains a valid WAVEFILTER structure that the dialog box will use as the initial selection.
			/// </summary>
			ACMFILTERCHOOSE_STYLEF_INITTOFILTERSTRUCT = 0x00000040,

			/// <summary>
			/// Context-sensitive help will be available in the dialog box. To use this feature, an application must register the
			/// ACMHELPMSGCONTEXTMENU and ACMHELPMSGCONTEXTHELP constants, using the RegisterWindowMessage function. When the user invokes
			/// help, the registered message will be posted to the owning window. The message will contain the wParam and lParam parameters
			/// from the original WM_CONTEXTMENU or WM_CONTEXTHELP message.
			/// </summary>
			ACMFILTERCHOOSE_STYLEF_CONTEXTHELP = 0x00000080,
		}

		/// <summary>Optional style flags for the acmFormatChoose function.</summary>
		[PInvokeData("msacm.h", MSDNShortId = "NS:msacm.tACMFORMATCHOOSE")]
		[Flags]
		public enum ACMFORMATCHOOSE_STYLEF : uint
		{
			/// <summary>
			/// A help button will appear in the dialog box. To use a custom Help file, an application must register the ACMHELPMSGSTRING
			/// constant with the RegisterWindowMessage function. When the user presses the help button, the registered message will be
			/// posted to the owner.
			/// </summary>
			ACMFORMATCHOOSE_STYLEF_SHOWHELP = 0x00000004,

			/// <summary>
			/// Enables the hook function pointed to by the pfnHook member. An application can use hook functions for a variety of
			/// customizations, including answering the MM_ACM_FORMATCHOOSE message.
			/// </summary>
			ACMFORMATCHOOSE_STYLEF_ENABLEHOOK = 0x00000008,

			/// <summary>Causes the ACM to create the dialog box template identified by hInstance and pszTemplateName.</summary>
			ACMFORMATCHOOSE_STYLEF_ENABLETEMPLATE = 0x00000010,

			/// <summary>
			/// The hInstance member identifies a data block that contains a preloaded dialog box template. If this flag is specified, the
			/// ACM ignores the pszTemplateName member.
			/// </summary>
			ACMFORMATCHOOSE_STYLEF_ENABLETEMPLATEHANDLE = 0x00000020,

			/// <summary>
			/// The buffer pointed to by pwfx contains a valid WAVEFORMATEX structure that the dialog box will use as the initial selection.
			/// </summary>
			ACMFORMATCHOOSE_STYLEF_INITTOWFXSTRUCT = 0x00000040,

			/// <summary>
			/// Context-sensitive help will be available in the dialog box. To use this feature, an application must register the
			/// ACMHELPMSGCONTEXTMENU and ACMHELPMSGCONTEXTHELP constants, using the RegisterWindowMessage function. When the user invokes
			/// help, the registered message will be posted to the owning window. The message will contain the wParam and lParam parameters
			/// from the original WM_CONTEXTMENU or WM_CONTEXTHELP message.
			/// </summary>
			ACMFORMATCHOOSE_STYLEF_CONTEXTHELP = 0x00000080,
		}

		/// <summary>Flags giving information about the conversion buffers.</summary>
		[PInvokeData("msacm.h", MSDNShortId = "NS:msacm.tACMSTREAMHEADER")]
		[Flags]
		public enum ACMSTREAMHEADER_STATUSF : uint
		{
			/// <summary>
			/// Set by the ACM or driver to indicate that it is finished with the conversion and is returning the buffers to the application.
			/// </summary>
			ACMSTREAMHEADER_STATUSF_DONE = 0x00010000,

			/// <summary>Set by the ACM to indicate that the buffers have been prepared by using the acmStreamPrepareHeader function.</summary>
			ACMSTREAMHEADER_STATUSF_PREPARED = 0x00020000,

			/// <summary>Set by the ACM or driver to indicate that the buffers are queued for conversion.</summary>
			ACMSTREAMHEADER_STATUSF_INQUEUE = 0x00100000,
		}

		/// <summary>
		/// The <c>acmDriverAdd</c> function adds a driver to the list of available ACM drivers. The driver type and location are dependent
		/// on the flags used to add ACM drivers. After a driver is successfully added, the driver entry function will receive ACM driver messages.
		/// </summary>
		/// <param name="phadid">
		/// Pointer to the buffer that receives a handle identifying the installed driver. This handle is used to identify the driver in
		/// calls to other ACM functions.
		/// </param>
		/// <param name="hinstModule">
		/// Handle to the instance of the module whose executable or dynamic-link library (DLL) contains the driver entry function.
		/// </param>
		/// <param name="lParam">Driver function address or a notification window handle, depending on the fdwAdd flags.</param>
		/// <param name="dwPriority">
		/// Window message to send for notification broadcasts. This parameter is used only with the ACM_DRIVERADDF_NOTIFYHWND flag. All
		/// other flags require this member to be set to zero.
		/// </param>
		/// <param name="fdwAdd">
		/// <para>Flags for adding ACM drivers. The following values are defined.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ACM_DRIVERADDF_FUNCTION</term>
		/// <term>
		/// The lParam parameter is a driver function address conforming to the acmDriverProc prototype. The function may reside in either
		/// an executable or DLL file.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ACM_DRIVERADDF_GLOBAL</term>
		/// <term>
		/// Provided for compatibility with 16-bit applications. For the Win32 API, ACM drivers added by the acmDriverAdd function can be
		/// used only by the application that added the driver. This is true whether or not ACM_DRIVERADDF_GLOBAL is specified. For more
		/// information, see Adding Drivers Within an Application.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ACM_DRIVERADDF_LOCAL</term>
		/// <term>
		/// The ACM automatically gives a local driver higher priority than a global driver when searching for a driver to satisfy a
		/// function call. For more information, see Adding Drivers Within an Application.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ACM_DRIVERADDF_NAME</term>
		/// <term>
		/// The lParam parameter is a registry value name in HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Drivers32. The
		/// value identifies a DLL that implements an ACM codec. Applications can use this flag if new registry entries are created after
		/// the application has already started using the ACM.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ACM_DRIVERADDF_NOTIFYHWND</term>
		/// <term>
		/// The lParam parameter is a handle of a notification window that receives messages when changes to global driver priorities and
		/// states are made. The window message to receive is defined by the application and must be passed in dwPriority. The wParam and
		/// lParam parameters passed with the window message are reserved for future use and should be ignored. ACM_DRIVERADDF_GLOBAL cannot
		/// be specified in conjunction with this flag. For more information about driver priorities, see the description for the
		/// acmDriverPriority function.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Returns zero if successful or an error otherwise. Possible error values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>MMSYSERR_INVALFLAG</term>
		/// <term>At least one flag is invalid.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALPARAM</term>
		/// <term>At least one parameter is invalid.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_NOMEM</term>
		/// <term>The system is unable to allocate resources.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Note</para>
		/// <para>
		/// The msacm.h header defines acmDriverAdd as an alias which automatically selects the ANSI or Unicode version of this function
		/// based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
		/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
		/// Function Prototypes.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msacm/nf-msacm-acmdriveraddw MMRESULT ACMAPI acmDriverAddW( LPHACMDRIVERID
		// phadid, HINSTANCE hinstModule, LPARAM lParam, DWORD dwPriority, DWORD fdwAdd );
		[DllImport(Lib_Msacm32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("msacm.h", MSDNShortId = "NF:msacm.acmDriverAddW")]
		public static extern MMRESULT acmDriverAdd(out HACMDRIVERID phadid, HINSTANCE hinstModule, IntPtr lParam, uint dwPriority, ACM_DRIVERADDF fdwAdd);

		/// <summary>
		/// The <c>acmDriverClose</c> function closes a previously opened ACM driver instance. If the function is successful, the handle is invalidated.
		/// </summary>
		/// <param name="had">Handle to the open driver instance to be closed.</param>
		/// <param name="fdwClose">Reserved; must be zero.</param>
		/// <returns>
		/// <para>Returns zero if successful or an error otherwise. Possible error values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ACMERR_BUSY</term>
		/// <term>The driver is in use and cannot be closed.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALFLAG</term>
		/// <term>At least one flag is invalid.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALHANDLE</term>
		/// <term>The specified handle is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msacm/nf-msacm-acmdriverclose MMRESULT ACMAPI acmDriverClose( HACMDRIVER had,
		// DWORD fdwClose );
		[DllImport(Lib_Msacm32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("msacm.h", MSDNShortId = "NF:msacm.acmDriverClose")]
		public static extern MMRESULT acmDriverClose(HACMDRIVER had, uint fdwClose = 0);

		/// <summary>The <c>acmDriverDetails</c> function queries a specified ACM driver to determine its capabilities.</summary>
		/// <param name="hadid">Handle to the driver identifier of an installed ACM driver. Disabled drivers can be queried for details.</param>
		/// <param name="padd">
		/// Pointer to an ACMDRIVERDETAILS structure that will receive the driver details. The <c>cbStruct</c> member must be initialized to
		/// the size, in bytes, of the structure.
		/// </param>
		/// <param name="fdwDetails">Reserved; must be zero.</param>
		/// <returns>
		/// <para>Returns zero if successful or an error otherwise. Possible error values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>MMSYSERR_INVALFLAG</term>
		/// <term>At least one flag is invalid.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALHANDLE</term>
		/// <term>The specified handle is invalid.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALPARAM</term>
		/// <term>At least one parameter is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Note</para>
		/// <para>
		/// The msacm.h header defines ACMDRIVERDETAILS as an alias which automatically selects the ANSI or Unicode version of this function
		/// based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
		/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
		/// Function Prototypes.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msacm/nf-msacm-acmdriverdetailsw MMRESULT ACMAPI acmDriverDetailsW(
		// HACMDRIVERID hadid, LPACMDRIVERDETAILSW padd, DWORD fdwDetails );
		[DllImport(Lib_Msacm32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("msacm.h", MSDNShortId = "NF:msacm.acmDriverDetailsW")]
		public static extern MMRESULT acmDriverDetails(HACMDRIVERID hadid, ACMDRIVERDETAILS padd, uint fdwDetails = 0);

		/// <summary>
		/// The <c>acmDriverEnum</c> function enumerates the available ACM drivers, continuing until there are no more drivers or the
		/// callback function returns <c>FALSE</c>.
		/// </summary>
		/// <param name="fnCallback">Procedure instance address of the application-defined callback function.</param>
		/// <param name="dwInstance">
		/// A 64-bit (DWORD_PTR) or 32-bit (DWORD) application-defined value that is passed to the callback function along with ACM driver information.
		/// </param>
		/// <param name="fdwEnum">
		/// <para>Flags for enumerating ACM drivers. The following values are defined.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ACM_DRIVERENUMF_DISABLED</term>
		/// <term>
		/// Disabled ACM drivers should be included in the enumeration. Drivers can be disabled by the user through the Control Panel or by
		/// an application using the acmDriverPriority function. If a driver is disabled, the fdwSupport parameter to the callback function
		/// will have the ACMDRIVERDETAILS_SUPPORTF_DISABLED flag set.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ACM_DRIVERENUMF_NOLOCAL</term>
		/// <term>Only global drivers should be included in the enumeration.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Returns zero if successful or an error otherwise. Possible error values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>MMSYSERR_INVALFLAG</term>
		/// <term>At least one flag is invalid.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALPARAM</term>
		/// <term>At least one parameter is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// The <c>acmDriverEnum</c> function will return MMSYSERR_NOERROR (zero) if no ACM drivers are installed. Moreover, the callback
		/// function will not be called.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msacm/nf-msacm-acmdriverenum MMRESULT ACMAPI acmDriverEnum( ACMDRIVERENUMCB
		// fnCallback, DWORD_PTR dwInstance, DWORD fdwEnum );
		[DllImport(Lib_Msacm32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("msacm.h", MSDNShortId = "NF:msacm.acmDriverEnum")]
		public static extern MMRESULT acmDriverEnum(ACMDRIVERENUMCB fnCallback, IntPtr dwInstance, ACM_DRIVERENUMF fdwEnum);

		/// <summary>
		/// The <c>acmDriverID</c> function returns the handle of an ACM driver identifier associated with an open ACM driver instance or
		/// stream handle.
		/// </summary>
		/// <param name="hao">
		/// Handle to the open driver instance or stream handle. This is the handle of an ACM object, such as <c>HACMDRIVER</c> or <c>HACMSTREAM</c>.
		/// </param>
		/// <param name="phadid">Pointer to a buffer that receives a handle identifying the installed driver that is associated with hao.</param>
		/// <param name="fdwDriverID">Reserved; must be zero.</param>
		/// <returns>
		/// <para>Returns zero if successful or an error otherwise. Possible error values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>MMSYSERR_INVALFLAG</term>
		/// <term>At least one flag is invalid.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALHANDLE</term>
		/// <term>The specified handle is invalid.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALPARAM</term>
		/// <term>At least one parameter is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msacm/nf-msacm-acmdriverid MMRESULT ACMAPI acmDriverID( HACMOBJ hao,
		// LPHACMDRIVERID phadid, DWORD fdwDriverID );
		[DllImport(Lib_Msacm32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("msacm.h", MSDNShortId = "NF:msacm.acmDriverID")]
		public static extern MMRESULT acmDriverID(HACMOBJ hao, out HACMDRIVERID phadid, uint fdwDriverID = 0);

		/// <summary>The <c>acmDriverMessage</c> function sends a user-defined message to a given ACM driver instance.</summary>
		/// <param name="had">Handle to the ACM driver instance to which the message will be sent.</param>
		/// <param name="uMsg">
		/// Message that the ACM driver must process. This message must be in the ACMDM_USER message range (above or equal to ACMDM_USER and
		/// less than ACMDM_RESERVED_LOW). The exceptions to this restriction are the ACMDM_DRIVER_ABOUT, DRV_QUERYCONFIGURE, and
		/// DRV_CONFIGURE messages.
		/// </param>
		/// <param name="lParam1">Message parameter.</param>
		/// <param name="lParam2">Message parameter.</param>
		/// <returns>
		/// <para>
		/// The return value is specific to the user-defined ACM driver message specified by the uMsg parameter. However, possible error
		/// values include the following.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>MMSYSERR_INVALHANDLE</term>
		/// <term>The specified handle is invalid.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALPARAM</term>
		/// <term>The uMsg parameter is not in the ACMDM_USER range.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_NOTSUPPORTED</term>
		/// <term>The ACM driver did not process the message.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// To display a custom About dialog box from an ACM driver, an application must send the ACMDM_DRIVER_ABOUT message to the driver.
		/// The lParam1 parameter should be the handle of the owner window for the custom About dialog box, and lParam2 must be set to zero.
		/// If the driver does not support a custom About dialog box, MMSYSERR_NOTSUPPORTED will be returned and it is the application's
		/// responsibility to display its own dialog box. For example, the Control Panel Sound Mapper option will display a default About
		/// dialog box based on the <c>ACMDRIVERDETAILS</c> structure when an ACM driver returns MMSYSERR_NOTSUPPORTED. An application can
		/// query a driver for custom About dialog box support without the dialog box being displayed by setting lParam1 to –1L. If the
		/// driver supports a custom About dialog box, MMSYSERR_NOERROR will be returned. Otherwise, the return value is MMSYSERR_NOTSUPPORTED.
		/// </para>
		/// <para>
		/// User-defined messages must be sent only to an ACM driver that specifically supports the messages. The caller should verify that
		/// the ACM driver is the correct driver by retrieving the driver details and checking the <c>wMid</c>, <c>wPid</c>, and
		/// <c>vdwDriver</c> members of the <c>ACMDRIVERDETAILS</c> structure.
		/// </para>
		/// <para>Never send user-defined messages to an unknown ACM driver.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msacm/nf-msacm-acmdrivermessage LRESULT ACMAPI acmDriverMessage( HACMDRIVER
		// had, UINT uMsg, LPARAM lParam1, LPARAM lParam2 );
		[DllImport(Lib_Msacm32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("msacm.h", MSDNShortId = "NF:msacm.acmDriverMessage")]
		public static extern IntPtr acmDriverMessage(HACMDRIVER had, uint uMsg, IntPtr lParam1, IntPtr lParam2);

		/// <summary>
		/// The <c>acmDriverOpen</c> function opens the specified ACM driver and returns a driver instance handle that can be used to
		/// communicate with the driver.
		/// </summary>
		/// <param name="phad">
		/// Pointer to a buffer that receives the new driver instance handle that can be used to communicate with the driver.
		/// </param>
		/// <param name="hadid">Handle to the driver identifier of an installed and enabled ACM driver.</param>
		/// <param name="fdwOpen">Reserved; must be zero.</param>
		/// <returns>
		/// <para>Returns zero if successful or an error otherwise. Possible error values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>MMSYSERR_INVALFLAG</term>
		/// <term>At least one flag is invalid.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALHANDLE</term>
		/// <term>The specified handle is invalid.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALPARAM</term>
		/// <term>At least one parameter is invalid.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_NOMEM</term>
		/// <term>The system is unable to allocate resources.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_NOTENABLED</term>
		/// <term>The driver is not enabled.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msacm/nf-msacm-acmdriveropen MMRESULT ACMAPI acmDriverOpen( LPHACMDRIVER phad,
		// HACMDRIVERID hadid, DWORD fdwOpen );
		[DllImport(Lib_Msacm32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("msacm.h", MSDNShortId = "NF:msacm.acmDriverOpen")]
		public static extern MMRESULT acmDriverOpen(out SafeHACMDRIVER phad, HACMDRIVERID hadid, uint fdwOpen = 0);

		/// <summary>The <c>acmDriverPriority</c> function modifies the priority and state of an ACM driver.</summary>
		/// <param name="hadid">
		/// Handle to the driver identifier of an installed ACM driver. If the ACM_DRIVERPRIORITYF_BEGIN and ACM_DRIVERPRIORITYF_END flags
		/// are specified, this parameter must be <c>NULL</c>.
		/// </param>
		/// <param name="dwPriority">
		/// New priority for a global ACM driver identifier. A zero value specifies that the priority of the driver identifier should remain
		/// unchanged. A value of 1 specifies that the driver should be placed as the highest search priority driver. A value of –1
		/// specifies that the driver should be placed as the lowest search priority driver. Priorities are used only for global drivers.
		/// </param>
		/// <param name="fdwPriority">
		/// <para>Flags for setting priorities of ACM drivers. The following values are defined.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ACM_DRIVERPRIORITYF_BEGIN</term>
		/// <term>
		/// Change notification broadcasts should be deferred. An application must reenable notification broadcasts as soon as possible with
		/// the ACM_DRIVERPRIORITYF_END flag. Note that hadid must be NULL, dwPriority must be zero, and only the ACM_DRIVERPRIORITYF_BEGIN
		/// flag can be set.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ACM_DRIVERPRIORITYF_DISABLE</term>
		/// <term>ACM driver should be disabled if it is currently enabled. Disabling a disabled driver does nothing.</term>
		/// </item>
		/// <item>
		/// <term>ACM_DRIVERPRIORITYF_ENABLE</term>
		/// <term>ACM driver should be enabled if it is currently disabled. Enabling an enabled driver does nothing.</term>
		/// </item>
		/// <item>
		/// <term>ACM_DRIVERPRIORITYF_END</term>
		/// <term>
		/// Calling task wants to reenable change notification broadcasts. An application must call acmDriverPriority with
		/// ACM_DRIVERPRIORITYF_END for each successful call with the ACM_DRIVERPRIORITYF_BEGIN flag. Note that hadid must be NULL,
		/// dwPriority must be zero, and only the ACM_DRIVERPRIORITYF_END flag can be set.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Returns zero if successful or an error otherwise. Possible error values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>MMSYSERR_ALLOCATED</term>
		/// <term>The deferred broadcast lock is owned by a different task.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALFLAG</term>
		/// <term>At least one flag is invalid.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALHANDLE</term>
		/// <term>The specified handle is invalid.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALPARAM</term>
		/// <term>At least one parameter is invalid.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_NOTSUPPORTED</term>
		/// <term>
		/// The requested operation is not supported for the specified driver. For example, local and notify driver identifiers do not
		/// support priorities (but can be enabled and disabled). If an application specifies a nonzero value for dwPriority for local and
		/// notify driver identifiers, this error will be returned.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>All driver identifiers can be enabled and disabled, including global, local and notification driver identifiers.</para>
		/// <para>
		/// If more than one global driver identifier needs to be enabled, disabled or shifted in priority, an application should defer
		/// change notification broadcasts by using the ACM_DRIVERPRIORITYF_BEGIN flag. A single change notification will be broadcast when
		/// the ACM_DRIVERPRIORITYF_END flag is specified.
		/// </para>
		/// <para>
		/// An application can use the function with the <c>acmMetrics</c> ACM_METRIC_DRIVER_PRIORITY metric index to retrieve the current
		/// priority of a global driver. Drivers are always enumerated from highest to lowest priority by the <c>acmDriverEnum</c> function.
		/// </para>
		/// <para>
		/// All enabled driver identifiers will receive change notifications. An application can register a notification message by using
		/// the <c>acmDriverAdd</c> function in conjunction with the ACM_DRIVERADDF_NOTIFYHWND flag. Changes to nonglobal driver identifiers
		/// will not be broadcast.
		/// </para>
		/// <para>
		/// Priorities are simply used for the search order when an application does not specify a driver. Boosting the priority of a driver
		/// will have no effect on the performance of a driver.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msacm/nf-msacm-acmdriverpriority MMRESULT ACMAPI acmDriverPriority(
		// HACMDRIVERID hadid, DWORD dwPriority, DWORD fdwPriority );
		[DllImport(Lib_Msacm32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("msacm.h", MSDNShortId = "NF:msacm.acmDriverPriority")]
		public static extern MMRESULT acmDriverPriority([In, Optional] HACMDRIVERID hadid, uint dwPriority, ACM_DRIVERPRIORITYF fdwPriority);

		/// <summary>
		/// The <c>acmDriverRemove</c> function removes an ACM driver from the list of available ACM drivers. The driver will be removed for
		/// the calling application only. If the driver is globally installed, other applications will still be able to use it.
		/// </summary>
		/// <param name="hadid">Handle to the driver identifier to be removed.</param>
		/// <param name="fdwRemove">Reserved; must be zero.</param>
		/// <returns>
		/// <para>Returns zero if successful or an error otherwise. Possible error values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ACMERR_BUSY</term>
		/// <term>The driver is in use and cannot be removed.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALFLAG</term>
		/// <term>At least one flag is invalid.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALHANDLE</term>
		/// <term>The specified handle is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msacm/nf-msacm-acmdriverremove MMRESULT ACMAPI acmDriverRemove( HACMDRIVERID
		// hadid, DWORD fdwRemove );
		[DllImport(Lib_Msacm32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("msacm.h", MSDNShortId = "NF:msacm.acmDriverRemove")]
		public static extern MMRESULT acmDriverRemove(HACMDRIVERID hadid, uint fdwRemove = 0);

		/// <summary>
		/// The <c>acmFilterChoose</c> function creates an ACM-defined dialog box that enables the user to select a waveform-audio filter.
		/// </summary>
		/// <param name="pafltrc">
		/// <para>
		/// Pointer to an ACMFILTERCHOOSE structure that contains information used to initialize the dialog box. When <c>acmFilterChoose</c>
		/// returns, this structure contains information about the user's filter selection.
		/// </para>
		/// <para>
		/// The <c>pwfltr</c> member of this structure must contain a valid pointer to a memory location that will contain the returned
		/// filter header structure. The <c>cbwfltr</c> member must be filled in with the size, in bytes, of this memory buffer.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Returns MMSYSERR_NOERROR if successful or an error otherwise. Possible error values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ACMERR_CANCELED</term>
		/// <term>The user chose the Cancel button or the Close command on the System menu to close the dialog box.</term>
		/// </item>
		/// <item>
		/// <term>ACMERR_NOTPOSSIBLE</term>
		/// <term>
		/// The buffer identified by the [ACMFILTERCHOOSE](./nf-msacm-acmfilterchoose.md) structure is too small to contain the selected filter.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALFLAG</term>
		/// <term>At least one flag is invalid.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALHANDLE</term>
		/// <term>The specified handle is invalid.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALPARAM</term>
		/// <term>At least one parameter is invalid.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_NODRIVER</term>
		/// <term>A suitable driver is not available to provide valid filter selections.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Note</para>
		/// <para>
		/// The msacm.h header defines ACMFILTERCHOOSE as an alias which automatically selects the ANSI or Unicode version of this function
		/// based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
		/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
		/// Function Prototypes.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msacm/nf-msacm-acmfilterchoosew MMRESULT ACMAPI acmFilterChooseW(
		// LPACMFILTERCHOOSEW pafltrc );
		[DllImport(Lib_Msacm32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("msacm.h", MSDNShortId = "NF:msacm.acmFilterChooseW")]
		public static extern MMRESULT acmFilterChoose(ref ACMFILTERCHOOSE pafltrc);

		/// <summary>
		/// The <c>acmFilterDetails</c> function queries the ACM for details about a filter with a specific waveform-audio filter tag.
		/// </summary>
		/// <param name="had">
		/// Handle to the ACM driver to query for waveform-audio filter details for a filter tag. If this parameter is <c>NULL</c>, the ACM
		/// uses the details from the first suitable ACM driver.
		/// </param>
		/// <param name="pafd">Pointer to the ACMFILTERDETAILS structure that is to receive the filter details for the given filter tag.</param>
		/// <param name="fdwDetails">
		/// <para>Flags for getting the details. The following values are defined.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ACM_FILTERDETAILSF_FILTER</term>
		/// <term>
		/// [ACMFILTERDETAILS](./nf-msacm-acmfilterdetails.md) structure was given and the remaining details should be returned. The
		/// dwFilterTag member of the ACMFILTERDETAILS structure must be initialized to the same filter tag pwfltr specifies. This query
		/// type can be used to get a string description of an arbitrary filter structure. If an application specifies an ACM driver handle
		/// for had , details on the filter will be returned for that driver. If an application specifies NULL for had , the ACM finds the
		/// first acceptable driver to return the details.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ACM_FILTERDETAILSF_INDEX</term>
		/// <term>
		/// A filter index for the filter tag was given in the dwFilterIndex member of the ACMFILTERDETAILS structure. The filter details
		/// will be returned in the structure defined by pafd. The index ranges from zero to one less than the cStandardFilters member
		/// returned in the ACMFILTERTAGDETAILS structure for a filter tag. An application must specify a driver handle for had when
		/// retrieving filter details with this flag. For information about what members should be initialized before calling this function,
		/// see the ACMFILTERDETAILS structure.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Returns zero if successful or an error otherwise. Possible error values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ACMERR_NOTPOSSIBLE</term>
		/// <term>The details requested are not available.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALFLAG</term>
		/// <term>At least one flag is invalid.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALHANDLE</term>
		/// <term>The specified handle is invalid.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALPARAM</term>
		/// <term>At least one parameter is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Note</para>
		/// <para>
		/// The msacm.h header defines ACMFILTERDETAILS as an alias which automatically selects the ANSI or Unicode version of this function
		/// based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
		/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
		/// Function Prototypes.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msacm/nf-msacm-acmfilterdetailsw MMRESULT ACMAPI acmFilterDetailsW( HACMDRIVER
		// had, LPACMFILTERDETAILSW pafd, DWORD fdwDetails );
		[DllImport(Lib_Msacm32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("msacm.h", MSDNShortId = "NF:msacm.acmFilterDetailsW")]
		public static extern MMRESULT acmFilterDetails([In, Optional] HACMDRIVER had, ref ACMFILTERDETAILS pafd, ACM_FILTERDETAILSF fdwDetails);

		/// <summary>
		/// The <c>acmFilterEnum</c> function enumerates waveform-audio filters available for a given filter tag from an ACM driver. This
		/// function continues enumerating until there are no more suitable filters for the filter tag or the callback function returns <c>FALSE</c>.
		/// </summary>
		/// <param name="had">
		/// Handle to the ACM driver to query for waveform-audio filter details. If this parameter is <c>NULL</c>, the ACM uses the details
		/// from the first suitable ACM driver.
		/// </param>
		/// <param name="pafd">
		/// Pointer to the ACMFILTERDETAILS structure that contains the filter details when it is passed to the function specified by
		/// fnCallback. When your application calls <c>acmFilterEnum</c>, the <c>cbStruct</c>, <c>pwfltr</c>, and <c>cbwfltr</c> members of
		/// this structure must be initialized. The <c>dwFilterTag</c> member must also be initialized to either WAVE_FILTER_UNKNOWN or a
		/// valid filter tag.
		/// </param>
		/// <param name="fnCallback">Procedure-instance address of the application-defined callback function.</param>
		/// <param name="dwInstance">
		/// A 32-bit (DWORD), 64-bit (DWORD_PTR) application-defined value that is passed to the callback function along with ACM filter details.
		/// </param>
		/// <param name="fdwEnum">
		/// <para>Flags for enumerating the filters for a given filter tag. The following values are defined.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ACM_FILTERENUMF_DWFILTERTAG</term>
		/// <term>
		/// [ACMFILTERDETAILS](./nf-msacm-acmfilterdetails.md) structure is valid. The enumerator will enumerate only a filter that conforms
		/// to this attribute. The dwFilterTag member of the ACMFILTERDETAILS structure must be equal to the dwFilterTag member of the
		/// WAVEFILTER structure.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Returns zero if successful or an error otherwise. Possible error values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ACMERR_NOTPOSSIBLE</term>
		/// <term>The details for the filter cannot be returned.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALFLAG</term>
		/// <term>At least one flag is invalid.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALHANDLE</term>
		/// <term>The specified handle is invalid.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALPARAM</term>
		/// <term>At least one parameter is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>acmFilterEnum</c> function will return MMSYSERR_NOERROR (zero) if no suitable ACM drivers are installed. Moreover, the
		/// callback function will not be called.
		/// </para>
		/// <para>
		/// The following functions should not be called from within the callback function: <c>acmDriverAdd</c>, <c>acmDriverRemove</c>, and <c>acmDriverPriority</c>.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// The msacm.h header defines acmFilterEnum as an alias which automatically selects the ANSI or Unicode version of this function
		/// based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
		/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
		/// Function Prototypes.
		/// </para>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msacm/nf-msacm-acmfilterenumw MMRESULT ACMAPI acmFilterEnumW( HACMDRIVER had,
		// LPACMFILTERDETAILSW pafd, ACMFILTERENUMCBW fnCallback, DWORD_PTR dwInstance, DWORD fdwEnum );
		[DllImport(Lib_Msacm32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("msacm.h", MSDNShortId = "NF:msacm.acmFilterEnumW")]
		public static extern MMRESULT acmFilterEnum([In, Optional] HACMDRIVER had, ref ACMFILTERDETAILS pafd, [In] ACMFILTERENUMCB fnCallback, IntPtr dwInstance, ACM_FILTERENUMF fdwEnum);

		/// <summary>The <c>acmFilterTagDetails</c> function queries the ACM for details about a specific waveform-audio filter tag.</summary>
		/// <param name="had">
		/// Handle to the ACM driver to query for waveform-audio filter tag details. If this parameter is <c>NULL</c>, the ACM uses the
		/// details from the first suitable ACM driver. An application must specify a valid <c>HACMDRIVER</c> or <c>HACMDRIVERID</c>
		/// identifier when using the ACM_FILTERTAGDETAILSF_INDEX query type. Driver identifiers for disabled drivers are not allowed.
		/// </param>
		/// <param name="paftd">Pointer to the ACMFILTERTAGDETAILS structure that is to receive the filter tag details.</param>
		/// <param name="fdwDetails">
		/// <para>Flags for getting the details. The following values are defined.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ACM_FILTERTAGDETAILSF_FILTERTAG</term>
		/// <term>
		/// [ACMFILTERTAGDETAILS](./nf-msacm-acmfiltertagdetails.md) structure. The filter tag details will be returned in the structure
		/// pointed to by paftd . If an application specifies an ACM driver handle for had , details on the filter tag will be returned for
		/// that driver. If an application specifies NULL for had , the ACM finds the first acceptable driver to return the details.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ACM_FILTERTAGDETAILSF_INDEX</term>
		/// <term>
		/// [ACMDRIVERDETAILS](./nf-msacm-acmdriverdetails.md) structure for an ACM driver. An application must specify a driver handle for
		/// had when retrieving filter tag details with this flag.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ACM_FILTERTAGDETAILSF_LARGESTSIZE</term>
		/// <term>
		/// Details on the filter tag with the largest filter size, in bytes, are to be returned. The dwFilterTag member must either be
		/// WAVE_FILTER_UNKNOWN or the filter tag to find the largest size for. If an application specifies an ACM driver handle for had,
		/// details on the largest filter tag will be returned for that driver. If an application specifies NULL for had, the ACM finds an
		/// acceptable driver with the largest filter tag requested to return the details.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Returns zero if successful or an error otherwise. Possible error values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ACMERR_NOTPOSSIBLE</term>
		/// <term>The details requested are not available.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALFLAG</term>
		/// <term>At least one flag is invalid.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALHANDLE</term>
		/// <term>The specified handle is invalid.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALPARAM</term>
		/// <term>At least one parameter is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Note</para>
		/// <para>
		/// The msacm.h header defines ACMFILTERTAGDETAILS as an alias which automatically selects the ANSI or Unicode version of this
		/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
		/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
		/// for Function Prototypes.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msacm/nf-msacm-acmfiltertagdetailsw MMRESULT ACMAPI acmFilterTagDetailsW(
		// HACMDRIVER had, LPACMFILTERTAGDETAILSW paftd, DWORD fdwDetails );
		[DllImport(Lib_Msacm32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("msacm.h", MSDNShortId = "NF:msacm.acmFilterTagDetailsW")]
		public static extern MMRESULT acmFilterTagDetails([In, Optional] HACMDRIVER had, ref ACMFILTERTAGDETAILS paftd, ACM_FILTERTAGDETAILSF fdwDetails);

		/// <summary>
		/// The <c>acmFilterTagEnum</c> function enumerates waveform-audio filter tags available from an ACM driver. This function continues
		/// enumerating until there are no more suitable filter tags or the callback function returns <c>FALSE</c>.
		/// </summary>
		/// <param name="had">
		/// Handle to the ACM driver to query for waveform-audio filter tag details. If this parameter is <c>NULL</c>, the ACM uses the
		/// details from the first suitable ACM driver.
		/// </param>
		/// <param name="paftd">
		/// Pointer to the ACMFILTERTAGDETAILS structure that contains the filter tag details when it is passed to the <c>fnCallback</c>
		/// function. When your application calls <c>acmFilterTagEnum</c>, the <c>cbStruct</c> member of this structure must be initialized.
		/// </param>
		/// <param name="fnCallback">Procedure instance address of the application-defined callback function.</param>
		/// <param name="dwInstance">
		/// A 64-bit (DWORD_PTR) or 32-bit (DWORD) application-defined value that is passed to the callback function along with ACM filter
		/// tag details.
		/// </param>
		/// <param name="fdwEnum">Reserved; must be zero.</param>
		/// <returns>
		/// <para>Returns zero if successful or an error otherwise. Possible error values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>MMSYSERR_INVALFLAG</term>
		/// <term>At least one flag is invalid.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALHANDLE</term>
		/// <term>The specified handle is invalid.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALPARAM</term>
		/// <term>At least one parameter is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This function will return MMSYSERR_NOERROR (zero) if no suitable ACM drivers are installed. Moreover, the callback function will
		/// not be called.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// The msacm.h header defines acmFilterTagEnum as an alias which automatically selects the ANSI or Unicode version of this function
		/// based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
		/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
		/// Function Prototypes.
		/// </para>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msacm/nf-msacm-acmfiltertagenumw MMRESULT ACMAPI acmFilterTagEnumW( HACMDRIVER
		// had, LPACMFILTERTAGDETAILSW paftd, ACMFILTERTAGENUMCBW fnCallback, DWORD_PTR dwInstance, DWORD fdwEnum );
		[DllImport(Lib_Msacm32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("msacm.h", MSDNShortId = "NF:msacm.acmFilterTagEnumW")]
		public static extern MMRESULT acmFilterTagEnum([In, Optional] HACMDRIVER had, ref ACMFILTERTAGDETAILS paftd, ACMFILTERTAGENUMCB fnCallback, IntPtr dwInstance, uint fdwEnum);

		/// <summary>
		/// The <c>acmFormatChoose</c> function creates an ACM-defined dialog box that enables the user to select a waveform-audio format.
		/// </summary>
		/// <param name="pafmtc">
		/// <para>
		/// Pointer to an ACMFORMATCHOOSE structure that contains information used to initialize the dialog box. When this function returns,
		/// this structure contains information about the user's format selection.
		/// </para>
		/// <para>
		/// The <c>pwfx</c> member of this structure must contain a valid pointer to a memory location that will contain the returned format
		/// header structure. Moreover, the <c>cbwfx</c> member must be filled in with the size, in bytes, of this memory buffer.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Returns MMSYSERR_NOERROR if successful or an error otherwise. Possible return values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ACMERR_CANCELED</term>
		/// <term>The user chose the Cancel button or the Close command on the System menu to close the dialog box.</term>
		/// </item>
		/// <item>
		/// <term>ACMERR_NOTPOSSIBLE</term>
		/// <term>The buffer identified by the pwfx member of the ACMFORMATCHOOSE structure is too small to contain the selected format.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALFLAG</term>
		/// <term>At least one flag is invalid.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALHANDLE</term>
		/// <term>The specified handle is invalid.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALPARAM</term>
		/// <term>At least one parameter is invalid.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_NODRIVER</term>
		/// <term>A suitable driver is not available to provide valid format selections.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Note</para>
		/// <para>
		/// The msacm.h header defines ACMFORMATCHOOSE as an alias which automatically selects the ANSI or Unicode version of this function
		/// based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
		/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
		/// Function Prototypes.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msacm/nf-msacm-acmformatchoosew MMRESULT ACMAPI acmFormatChooseW(
		// LPACMFORMATCHOOSEW pafmtc );
		[DllImport(Lib_Msacm32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("msacm.h", MSDNShortId = "NF:msacm.acmFormatChooseW")]
		public static extern MMRESULT acmFormatChoose(ref ACMFORMATCHOOSE pafmtc);

		/// <summary>The <c>acmFormatDetails</c> function queries the ACM for format details for a specific waveform-audio format tag.</summary>
		/// <param name="had">
		/// Handle to the ACM driver to query for waveform-audio format details for a format tag. If this parameter is <c>NULL</c>, the ACM
		/// uses the details from the first suitable ACM driver.
		/// </param>
		/// <param name="pafd">Pointer to an ACMFORMATDETAILS structure to contain the format details for the given format tag.</param>
		/// <param name="fdwDetails">
		/// <para>Flags for getting the waveform-audio format tag details. The following values are defined.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ACM_FORMATDETAILSF_FORMAT</term>
		/// <term>
		/// ACMFORMATDETAILS structure was given and the remaining details should be returned. The dwFormatTag member of the
		/// ACMFORMATDETAILS structure must be initialized to the same format tag as pwfx specifies. This query type can be used to get a
		/// string description of an arbitrary format structure. If an application specifies an ACM driver handle for had , details on the
		/// format will be returned for that driver. If an application specifies NULL for had , the ACM finds the first acceptable driver to
		/// return the details.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ACM_FORMATDETAILSF_INDEX</term>
		/// <term>
		/// A format index for the format tag was given in the dwFormatIndex member of the ACMFORMATDETAILS structure. The format details
		/// will be returned in the structure defined by pafd. The index ranges from zero to one less than the cStandardFormats member
		/// returned in the ACMFORMATTAGDETAILS structure for a format tag. An application must specify a driver handle for had when
		/// retrieving format details with this flag. For information about which members should be initialized before calling this
		/// function, see the ACMFORMATDETAILS structure.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Returns zero if successful or an error otherwise. Possible error values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ACMERR_NOTPOSSIBLE</term>
		/// <term>The details requested are not available.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALFLAG</term>
		/// <term>At least one flag is invalid.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALHANDLE</term>
		/// <term>The specified handle is invalid.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALPARAM</term>
		/// <term>At least one parameter is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Note</para>
		/// <para>
		/// The msacm.h header defines ACMFORMATDETAILS as an alias which automatically selects the ANSI or Unicode version of this function
		/// based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
		/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
		/// Function Prototypes.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msacm/nf-msacm-acmformatdetailsw MMRESULT ACMAPI acmFormatDetailsW( HACMDRIVER
		// had, LPACMFORMATDETAILSW pafd, DWORD fdwDetails );
		[DllImport(Lib_Msacm32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("msacm.h", MSDNShortId = "NF:msacm.acmFormatDetailsW")]
		public static extern MMRESULT acmFormatDetails([In, Optional] HACMDRIVER had, ref ACMFORMATDETAILS pafd, ACM_FORMATDETAILSF fdwDetails);

		/// <summary>
		/// The <c>acmFormatEnum</c> function enumerates waveform-audio formats available for a given format tag from an ACM driver. This
		/// function continues enumerating until there are no more suitable formats for the format tag or the callback function returns <c>FALSE</c>.
		/// </summary>
		/// <param name="had">
		/// Handle to the ACM driver to query for waveform-audio format details. If this parameter is <c>NULL</c>, the ACM uses the details
		/// from the first suitable ACM driver.
		/// </param>
		/// <param name="pafd">
		/// <para>
		/// Pointer to an ACMFORMATDETAILS structure to contain the format details passed to the <c>fnCallback</c> function. This structure
		/// must have the <c>cbStruct</c>, <c>pwfx</c>, and <c>cbwfx</c> members of the <c>ACMFORMATDETAILS</c> structure initialized. The
		/// <c>dwFormatTag</c> member must also be initialized to either WAVE_FORMAT_UNKNOWN or a valid format tag.
		/// </para>
		/// <para>The <c>fdwSupport</c> member of the structure must be initialized to zero.</para>
		/// <para>To find the required size of the <c>pwfx</c> buffer, call acmMetrics with the ACM_METRIC_MAX_SIZE_FORMAT flag.</para>
		/// </param>
		/// <param name="fnCallback">
		/// Address of an application-defined callback function. See acmFormatEnumCallback. This parameter cannot be <c>NULL</c>.
		/// </param>
		/// <param name="dwInstance">
		/// A 64-bit (DWORD_PTR) or 32-bit (DWORD) application-defined value that is passed to the callback function along with ACM format details.
		/// </param>
		/// <param name="fdwEnum">
		/// <para>Flags for enumerating the formats for a given format tag. The following values are defined.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ACM_FORMATENUMF_CONVERT</term>
		/// <term>
		/// ACMFORMATDETAILS structure is valid. The enumerator will only enumerate destination formats that can be converted from the given
		/// pwfx format.If this flag is used, the wFormatTag member of the WAVEFORMATEX structure cannot be WAVE_FORMAT_UNKNOWN.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ACM_FORMATENUMF_HARDWARE</term>
		/// <term>
		/// The enumerator should only enumerate formats that are supported as native input or output formats on one or more of the
		/// installed waveform-audio devices. This flag provides a way for an application to choose only formats native to an installed
		/// waveform-audio device. This flag must be used with one or both of the ACM_FORMATENUMF_INPUT and ACM_FORMATENUMF_OUTPUT flags.
		/// Specifying both ACM_FORMATENUMF_INPUT and ACM_FORMATENUMF_OUTPUT will enumerate only formats that can be opened for input or
		/// output. This is true regardless of whether this flag is specified.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ACM_FORMATENUMF_INPUT</term>
		/// <term>Enumerator should enumerate only formats that are supported for input (recording).</term>
		/// </item>
		/// <item>
		/// <term>ACM_FORMATENUMF_NCHANNELS</term>
		/// <term>ACMFORMATDETAILS structure is valid. The enumerator will enumerate only a format that conforms to this attribute.</term>
		/// </item>
		/// <item>
		/// <term>ACM_FORMATENUMF_NSAMPLESPERSEC</term>
		/// <term>
		/// The nSamplesPerSec member of the WAVEFORMATEX structure pointed to by the pwfx member of the ACMFORMATDETAILS structure is
		/// valid. The enumerator will enumerate only a format that conforms to this attribute.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ACM_FORMATENUMF_OUTPUT</term>
		/// <term>Enumerator should enumerate only formats that are supported for output (playback).</term>
		/// </item>
		/// <item>
		/// <term>ACM_FORMATENUMF_SUGGEST</term>
		/// <term>
		/// ACMFORMATDETAILS structure is valid. The enumerator will enumerate all suggested destination formats for the given pwfx format.
		/// This mechanism can be used instead of the acmFormatSuggest function to allow an application to choose the best suggested format
		/// for conversion. The dwFormatIndex member will always be set to zero on return.If this flag is used, the wFormatTag member of the
		/// WAVEFORMATEX structure cannot be WAVE_FORMAT_UNKNOWN.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ACM_FORMATENUMF_WBITSPERSAMPLE</term>
		/// <term>
		/// The wBitsPerSample member of the WAVEFORMATEX structure pointed to by the pwfx member of the ACMFORMATDETAILS structure is
		/// valid. The enumerator will enumerate only a format that conforms to this attribute.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ACM_FORMATENUMF_WFORMATTAG</term>
		/// <term>
		/// The wFormatTag member of the WAVEFORMATEX structure pointed to by the pwfx member of the ACMFORMATDETAILS structure is valid.
		/// The enumerator will enumerate only a format that conforms to this attribute. The dwFormatTag member of the ACMFORMATDETAILS
		/// structure must be equal to the wFormatTag member.The value of wFormatTag cannot be WAVE_FORMAT_UNKNOWN in this case.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Returns zero if successful or an error otherwise. Possible error values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ACMERR_NOTPOSSIBLE</term>
		/// <term>The details for the format cannot be returned.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALFLAG</term>
		/// <term>At least one flag is invalid.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALHANDLE</term>
		/// <term>The specified handle is invalid.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALPARAM</term>
		/// <term>At least one parameter is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This function will return MMSYSERR_NOERROR (zero) if no suitable ACM drivers are installed. Moreover, the callback function will
		/// not be called.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following example shows how to enumerate formats that have the WAVE_FORMAT_MPEGLAYER3 format tag.</para>
		/// <para>
		/// <code> MMRESULT EnumerateMP3Codecs() { DWORD cbMaxSize = 0; MMRESULT result = MMSYSERR_NOERROR; ACMFORMATDETAILS acmFormatDetails; // Buffer to hold the format information. BYTE *pFormat = NULL; // Caller allocated. // Find the largest format buffer needed. result = acmMetrics(NULL, ACM_METRIC_MAX_SIZE_FORMAT, &amp;cbMaxSize); if (result != MMSYSERR_NOERROR) { return result; } // Allocate the format buffer. pFormat = new BYTE[cbMaxSize]; if (pFormat == NULL) { return MMSYSERR_NOMEM; } ZeroMemory(pFormat, cbMaxSize); // Ask for WAVE_FORMAT_MPEGLAYER3 formats. WAVEFORMATEX* pWaveFormat = (WAVEFORMATEX*)pFormat; pWaveFormat-&gt;wFormatTag = WAVE_FORMAT_MPEGLAYER3; // Set up the acmFormatDetails structure. ZeroMemory(&amp;acmFormatDetails, sizeof(acmFormatDetails)); acmFormatDetails.cbStruct = sizeof(ACMFORMATDETAILS); acmFormatDetails.pwfx = pWaveFormat; acmFormatDetails.cbwfx = cbMaxSize; // For the ACM_FORMATENUMF_WFORMATTAG request, the format // tag in acmFormatDetails must match the format tag in // the pFormat buffer. acmFormatDetails.dwFormatTag = WAVE_FORMAT_MPEGLAYER3; result = acmFormatEnum(NULL, &amp;acmFormatDetails, acmFormatEnumCallback, 0, ACM_FORMATENUMF_WFORMATTAG); delete [] pFormat; return result; }</code>
		/// </para>
		/// <para>
		/// The next example shows the callback function for the previous example. The callback function is called once for each matching
		/// format or until the callback returns <c>FALSE</c>.
		/// </para>
		/// <para>
		/// <code> BOOL CALLBACK acmFormatEnumCallback( HACMDRIVERID hadid, LPACMFORMATDETAILS pafd, DWORD_PTR dwInstance, DWORD fdwSupport ) { BOOL bContinue = TRUE; MPEGLAYER3WAVEFORMAT *pMP3WaveFormat = NULL; if (pafd-&gt;pwfx-&gt;wFormatTag == WAVE_FORMAT_MPEGLAYER3) { pMP3WaveFormat = (MPEGLAYER3WAVEFORMAT*)pafd-&gt;pwfx; // TODO: Examine the format. // To halt the enumeration, set bContinue to FALSE. } return bContinue; }</code>
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// The msacm.h header defines acmFormatEnum as an alias which automatically selects the ANSI or Unicode version of this function
		/// based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
		/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
		/// Function Prototypes.
		/// </para>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msacm/nf-msacm-acmformatenumw MMRESULT ACMAPI acmFormatEnumW( HACMDRIVER had,
		// LPACMFORMATDETAILSW pafd, ACMFORMATENUMCBW fnCallback, DWORD_PTR dwInstance, DWORD fdwEnum );
		[DllImport(Lib_Msacm32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("msacm.h", MSDNShortId = "NF:msacm.acmFormatEnumW")]
		public static extern MMRESULT acmFormatEnum([In, Optional] HACMDRIVER had, ref ACMFORMATDETAILS pafd, ACMFORMATENUMCB fnCallback, IntPtr dwInstance, ACM_FORMATENUMF fdwEnum);

		/// <summary>
		/// The <c>acmFormatSuggest</c> function queries the ACM or a specified ACM driver to suggest a destination format for the supplied
		/// source format. For example, an application can use this function to determine one or more valid PCM formats to which a
		/// compressed format can be decompressed.
		/// </summary>
		/// <param name="had">
		/// Handle to an open instance of a driver to query for a suggested destination format. If this parameter is <c>NULL</c>, the ACM
		/// attempts to find the best driver to suggest a destination format.
		/// </param>
		/// <param name="pwfxSrc">
		/// Pointer to a WAVEFORMATEX structure that identifies the source format for which a destination format will be suggested by the
		/// ACM or specified driver.
		/// </param>
		/// <param name="pwfxDst">
		/// Pointer to a WAVEFORMATEX structure that will receive the suggested destination format for the pwfxSrc format. Depending on the
		/// fdwSuggest parameter, some members of the structure pointed to by pwfxDst may require initialization.
		/// </param>
		/// <param name="cbwfxDst">
		/// Size, in bytes, available for the destination format. The acmMetrics and acmFormatTagDetails functions can be used to determine
		/// the maximum size required for any format available for the specified driver (or for all installed ACM drivers).
		/// </param>
		/// <param name="fdwSuggest">
		/// <para>Flags for matching the desired destination format. The following values are defined.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <description>ACM_FORMATSUGGESTF_NCHANNELS</description>
		/// <description>
		/// The nChannels member of the structure pointed to by pwfxDst is valid. The ACM will query acceptable installed drivers that can
		/// suggest a destination format matching nChannels or fail.
		/// </description>
		/// </item>
		/// <item>
		/// <description>ACM_FORMATSUGGESTF_NSAMPLESPERSEC</description>
		/// <description>
		/// The nSamplesPerSec member of the structure pointed to by pwfxDst is valid. The ACM will query acceptable installed drivers that
		/// can suggest a destination format matching nSamplesPerSec or fail.
		/// </description>
		/// </item>
		/// <item>
		/// <description>ACM_FORMATSUGGESTF_WBITSPERSAMPLE</description>
		/// <description>
		/// The wBitsPerSample member of the structure pointed to by pwfxDst is valid. The ACM will query acceptable installed drivers that
		/// can suggest a destination format matching wBitsPerSample or fail.
		/// </description>
		/// </item>
		/// <item>
		/// <description>ACM_FORMATSUGGESTF_WFORMATTAG</description>
		/// <description>
		/// The wFormatTag member of the structure pointed to by pwfxDst is valid. The ACM will query acceptable installed drivers that can
		/// suggest a destination format matching wFormatTag or fail.
		/// </description>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Returns zero if successful or an error otherwise. Possible error values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <description>MMSYSERR_INVALFLAG</description>
		/// <description>At least one flag is invalid.</description>
		/// </item>
		/// <item>
		/// <description>MMSYSERR_INVALHANDLE</description>
		/// <description>The specified handle is invalid.</description>
		/// </item>
		/// <item>
		/// <description>MMSYSERR_INVALPARAM</description>
		/// <description>At least one parameter is invalid.</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msacm/nf-msacm-acmformatsuggest MMRESULT ACMAPI acmFormatSuggest( HACMDRIVER
		// had, LPWAVEFORMATEX pwfxSrc, LPWAVEFORMATEX pwfxDst, DWORD cbwfxDst, DWORD fdwSuggest );
		[DllImport(Lib_Msacm32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("msacm.h", MSDNShortId = "NF:msacm.acmFormatSuggest")]
		public static extern MMRESULT acmFormatSuggest([In, Optional] HACMDRIVER had, in WAVEFORMATEX pwfxSrc, out WAVEFORMATEX pwfxDst, uint cbwfxDst, ACM_FORMATSUGGESTF fdwSuggest);

		/// <summary>
		/// The <c>acmFormatSuggest</c> function queries the ACM or a specified ACM driver to suggest a destination format for the supplied
		/// source format. For example, an application can use this function to determine one or more valid PCM formats to which a
		/// compressed format can be decompressed.
		/// </summary>
		/// <param name="had">
		/// Handle to an open instance of a driver to query for a suggested destination format. If this parameter is <c>NULL</c>, the ACM
		/// attempts to find the best driver to suggest a destination format.
		/// </param>
		/// <param name="pwfxSrc">
		/// Pointer to a WAVEFORMATEX structure that identifies the source format for which a destination format will be suggested by the
		/// ACM or specified driver.
		/// </param>
		/// <param name="pwfxDst">
		/// Pointer to a WAVEFORMATEX structure that will receive the suggested destination format for the pwfxSrc format. Depending on the
		/// fdwSuggest parameter, some members of the structure pointed to by pwfxDst may require initialization.
		/// </param>
		/// <param name="cbwfxDst">
		/// Size, in bytes, available for the destination format. The acmMetrics and acmFormatTagDetails functions can be used to determine
		/// the maximum size required for any format available for the specified driver (or for all installed ACM drivers).
		/// </param>
		/// <param name="fdwSuggest">
		/// <para>Flags for matching the desired destination format. The following values are defined.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <description>ACM_FORMATSUGGESTF_NCHANNELS</description>
		/// <description>
		/// The nChannels member of the structure pointed to by pwfxDst is valid. The ACM will query acceptable installed drivers that can
		/// suggest a destination format matching nChannels or fail.
		/// </description>
		/// </item>
		/// <item>
		/// <description>ACM_FORMATSUGGESTF_NSAMPLESPERSEC</description>
		/// <description>
		/// The nSamplesPerSec member of the structure pointed to by pwfxDst is valid. The ACM will query acceptable installed drivers that
		/// can suggest a destination format matching nSamplesPerSec or fail.
		/// </description>
		/// </item>
		/// <item>
		/// <description>ACM_FORMATSUGGESTF_WBITSPERSAMPLE</description>
		/// <description>
		/// The wBitsPerSample member of the structure pointed to by pwfxDst is valid. The ACM will query acceptable installed drivers that
		/// can suggest a destination format matching wBitsPerSample or fail.
		/// </description>
		/// </item>
		/// <item>
		/// <description>ACM_FORMATSUGGESTF_WFORMATTAG</description>
		/// <description>
		/// The wFormatTag member of the structure pointed to by pwfxDst is valid. The ACM will query acceptable installed drivers that can
		/// suggest a destination format matching wFormatTag or fail.
		/// </description>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Returns zero if successful or an error otherwise. Possible error values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <description>MMSYSERR_INVALFLAG</description>
		/// <description>At least one flag is invalid.</description>
		/// </item>
		/// <item>
		/// <description>MMSYSERR_INVALHANDLE</description>
		/// <description>The specified handle is invalid.</description>
		/// </item>
		/// <item>
		/// <description>MMSYSERR_INVALPARAM</description>
		/// <description>At least one parameter is invalid.</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msacm/nf-msacm-acmformatsuggest MMRESULT ACMAPI acmFormatSuggest( HACMDRIVER
		// had, LPWAVEFORMATEX pwfxSrc, LPWAVEFORMATEX pwfxDst, DWORD cbwfxDst, DWORD fdwSuggest );
		[DllImport(Lib_Msacm32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("msacm.h", MSDNShortId = "NF:msacm.acmFormatSuggest")]
		public static extern MMRESULT acmFormatSuggest([In, Optional] HACMDRIVER had, in WAVEFORMATEX pwfxSrc, [Out] IntPtr pwfxDst, uint cbwfxDst, ACM_FORMATSUGGESTF fdwSuggest);

		/// <summary>The <c>acmFormatTagDetails</c> function queries the ACM for details on a specific waveform-audio format tag.</summary>
		/// <param name="had">
		/// Handle to the ACM driver to query for waveform-audio format tag details. If this parameter is <c>NULL</c>, the ACM uses the
		/// details from the first suitable ACM driver. An application must specify a valid handle or driver identifier when using the
		/// ACM_FORMATTAGDETAILSF_INDEX query type. Driver identifiers for disabled drivers are not allowed.
		/// </param>
		/// <param name="paftd">Pointer to the ACMFORMATTAGDETAILS structure that is to receive the format tag details.</param>
		/// <param name="fdwDetails">
		/// <para>Flags for getting the details. The following values are defined.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ACM_FORMATTAGDETAILSF_FORMATTAG</term>
		/// <term>
		/// ACMFORMATTAGDETAILS structure. The format tag details will be returned in the structure pointed to bypaftd. If an application
		/// specifies an ACM driver handle forhad, details on the format tag will be returned for that driver. If an application
		/// specifiesNULLforhad, the ACM finds the first acceptable driver to return the details.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ACM_FORMATTAGDETAILSF_INDEX</term>
		/// <term>
		/// ACMDRIVERDETAILS structure for an ACM driver. An application must specify a driver handle forhadwhen retrieving format tag
		/// details with this flag.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ACM_FORMATTAGDETAILSF_LARGESTSIZE</term>
		/// <term>
		/// ACMFORMATTAGDETAILS structure must either be WAVE_FORMAT_UNKNOWN or the format tag to find the largest size for. If an
		/// application specifies an ACM driver handle forhad, details on the largest format tag will be returned for that driver. If an
		/// application specifiesNULLforhad, the ACM finds an acceptable driver with the largest format tag requested to return the details.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Returns zero if successful or an error otherwise. Possible error values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ACMERR_NOTPOSSIBLE</term>
		/// <term>The details requested are not available.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALFLAG</term>
		/// <term>At least one flag is invalid.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALHANDLE</term>
		/// <term>The specified handle is invalid.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALPARAM</term>
		/// <term>At least one parameter is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Note</para>
		/// <para>
		/// The msacm.h header defines ACMFORMATTAGDETAILS as an alias which automatically selects the ANSI or Unicode version of this
		/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
		/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
		/// for Function Prototypes.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msacm/nf-msacm-acmformattagdetailsw MMRESULT ACMAPI acmFormatTagDetailsW(
		// HACMDRIVER had, LPACMFORMATTAGDETAILSW paftd, DWORD fdwDetails );
		[DllImport(Lib_Msacm32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("msacm.h", MSDNShortId = "NF:msacm.acmFormatTagDetailsW")]
		public static extern MMRESULT acmFormatTagDetails([In, Optional] HACMDRIVER had, ref ACMFORMATTAGDETAILS paftd, ACM_FORMATTAGDETAILSF fdwDetails);

		/// <summary>
		/// The <c>acmFormatTagEnum</c> function enumerates waveform-audio format tags available from an ACM driver. This function continues
		/// enumerating until there are no more suitable format tags or the callback function returns <c>FALSE</c>.
		/// </summary>
		/// <param name="had">
		/// Handle to the ACM driver to query for waveform-audio format tag details. If this parameter is <c>NULL</c>, the ACM uses the
		/// details from the first suitable ACM driver.
		/// </param>
		/// <param name="paftd">
		/// Pointer to the ACMFORMATTAGDETAILS structure that is to receive the format tag details passed to the function specified in
		/// fnCallback. This structure must have the <c>cbStruct</c> member of the <c>ACMFORMATTAGDETAILS</c> structure initialized.
		/// </param>
		/// <param name="fnCallback">Procedure instance address of the application-defined callback function.</param>
		/// <param name="dwInstance">
		/// A 64-bit (DWORD_PTR) or 32-bit (DWORD) application-defined value that is passed to the callback function along with ACM format
		/// tag details.
		/// </param>
		/// <param name="fdwEnum">Reserved; must be zero.</param>
		/// <returns>
		/// <para>Returns zero if successful or an error otherwise. Possible error values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>MMSYSERR_INVALFLAG</term>
		/// <term>At least one flag is invalid.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALHANDLE</term>
		/// <term>The specified handle is invalid.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALPARAM</term>
		/// <term>At least one parameter is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This function will return MMSYSERR_NOERROR (zero) if no suitable ACM drivers are installed. Moreover, the callback function will
		/// not be called.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// The msacm.h header defines acmFormatTagEnum as an alias which automatically selects the ANSI or Unicode version of this function
		/// based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
		/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
		/// Function Prototypes.
		/// </para>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msacm/nf-msacm-acmformattagenumw MMRESULT ACMAPI acmFormatTagEnumW( HACMDRIVER
		// had, LPACMFORMATTAGDETAILSW paftd, ACMFORMATTAGENUMCBW fnCallback, DWORD_PTR dwInstance, DWORD fdwEnum );
		[DllImport(Lib_Msacm32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("msacm.h", MSDNShortId = "NF:msacm.acmFormatTagEnumW")]
		public static extern MMRESULT acmFormatTagEnum([In, Optional] HACMDRIVER had, ref ACMFORMATTAGDETAILS paftd, ACMFORMATTAGENUMCB fnCallback, IntPtr dwInstance, uint fdwEnum = 0);

		/// <summary>The <c>acmGetVersion</c> function returns the version number of the ACM.</summary>
		/// <returns>
		/// The version number is returned as a hexadecimal number of the form 0xAABBCCCC, where AA is the major version number, BB is the
		/// minor version number, and CCCC is the build number.
		/// </returns>
		/// <remarks>
		/// <para>
		/// Win32 applications must verify that the ACM version is at least 0x03320000 (version 3.50) or greater before attempting to use
		/// any other ACM functions. The build number (CCCC) is always zero for the retail (non-debug) version of the ACM.
		/// </para>
		/// <para>
		/// To display the ACM version for a user, an application should use the following format (note that the values should be printed as
		/// unsigned decimals):
		/// </para>
		/// <para>
		/// <code> { DWORD dw; TCHAR ach[10]; dw = acmGetVersion(); _stprintf_s(ach, TEXT("%u.%.02u"), HIWORD(dw) &gt;&gt; 8, HIWORD(dw) &amp; 0x00FF); }</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msacm/nf-msacm-acmgetversion DWORD ACMAPI acmGetVersion();
		[DllImport(Lib_Msacm32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("msacm.h", MSDNShortId = "NF:msacm.acmGetVersion")]
		public static extern uint acmGetVersion();

		/// <summary>The <c>acmMetrics</c> function returns various metrics for the ACM or related ACM objects.</summary>
		/// <param name="hao">
		/// Handle to the ACM object to query for the metric specified in uMetric. For some queries, this parameter can be <c>NULL</c>.
		/// </param>
		/// <param name="uMetric">
		/// <para>Metric index to be returned in pMetric.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ACM_METRIC_COUNT_CODECS</term>
		/// <term>
		/// Returned value is the number of global ACM compressor or decompressor drivers in the system. The hao parameter must be NULL for
		/// this metric index. The pMetric parameter must point to a buffer of a size equal to a DWORD value.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ACM_METRIC_COUNT_CONVERTERS</term>
		/// <term>
		/// Returned value is the number of global ACM converter drivers in the system. The hao parameter must be NULL for this metric
		/// index. The pMetric parameter must point to a buffer of a size equal to a DWORD value.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ACM_METRIC_COUNT_DISABLED</term>
		/// <term>
		/// Returned value is the total number of global disabled ACM drivers (of all support types) in the system. The hao parameter must
		/// be NULL for this metric index. The pMetric parameter must point to a buffer of a size equal to a DWORD value. The sum of the
		/// ACM_METRIC_COUNT_DRIVERS and ACM_METRIC_COUNT_DISABLED metric indices is the total number of globally installed ACM drivers.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ACM_METRIC_COUNT_DRIVERS</term>
		/// <term>
		/// Returned value is the total number of enabled global ACM drivers (of all support types) in the system. The hao parameter must be
		/// NULL for this metric index. The pMetric parameter must point to a buffer of a size equal to a DWORD value.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ACM_METRIC_COUNT_FILTERS</term>
		/// <term>
		/// Returned value is the number of global ACM filter drivers in the system. The hao parameter must be NULL for this metric index.
		/// The pMetric parameter must point to a buffer of a size equal to a DWORD value.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ACM_METRIC_COUNT_HARDWARE</term>
		/// <term>
		/// Returned value is the number of global ACM hardware drivers in the system. The hao parameter must be NULL for this metric index.
		/// The pMetric parameter must point to a buffer of a size equal to a DWORD value.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ACM_METRIC_COUNT_LOCAL_CODECS</term>
		/// <term>
		/// Returned value is the number of local ACM compressor drivers, ACM decompressor drivers, or both for the calling task. The hao
		/// parameter must be NULL for this metric index. The pMetric parameter must point to a buffer of a size equal to a DWORD value.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ACM_METRIC_COUNT_LOCAL_CONVERTERS</term>
		/// <term>
		/// Returned value is the number of local ACM converter drivers for the calling task. The hao parameter must be NULL for this metric
		/// index. The pMetric parameter must point to a buffer of a size equal to a DWORD value.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ACM_METRIC_COUNT_LOCAL_DISABLED</term>
		/// <term>
		/// Returned value is the total number of local disabled ACM drivers, of all support types, for the calling task. The hao parameter
		/// must be NULL for this metric index. The pMetric parameter must point to a buffer of a size equal to a DWORD value. The sum of
		/// the ACM_METRIC_COUNT_LOCAL_DRIVERS and ACM_METRIC_COUNT_LOCAL_DISABLED metric indices is the total number of locally installed
		/// ACM drivers.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ACM_METRIC_COUNT_LOCAL_DRIVERS</term>
		/// <term>
		/// Returned value is the total number of enabled local ACM drivers (of all support types) for the calling task. The hao parameter
		/// must be NULL for this metric index. The pMetric parameter must point to a buffer of a size equal to a DWORD value.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ACM_METRIC_COUNT_LOCAL_FILTERS</term>
		/// <term>
		/// Returned value is the number of local ACM filter drivers for the calling task. The hao parameter must be NULL for this metric
		/// index. The pMetric parameter must point to a buffer of a size equal to a DWORD value.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ACM_METRIC_DRIVER_PRIORITY</term>
		/// <term>
		/// Returned value is the current priority for the specified driver. The hao parameter must be a valid ACM driver identifier of the
		/// HACMDRIVERID data type. The pMetric parameter must point to a buffer of a size equal to a DWORD value.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ACM_METRIC_DRIVER_SUPPORT</term>
		/// <term>
		/// Returned value is the fdwSupport flags for the specified driver. The hao parameter must be a valid ACM driver identifier of the
		/// HACMDRIVERID data type. The pMetric parameter must point to a buffer of a size equal to a DWORD value.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ACM_METRIC_HARDWARE_WAVE_INPUT</term>
		/// <term>
		/// Returned value is the waveform-audio input device identifier associated with the specified driver. The hao parameter must be a
		/// valid ACM driver identifier of the HACMDRIVERID data type that supports the ACMDRIVERDETAILS_SUPPORTF_HARDWARE flag. If no
		/// waveform-audio input device is associated with the driver, MMSYSERR_NOTSUPPORTED is returned. The pMetric parameter must point
		/// to a buffer of a size equal to a DWORD value.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ACM_METRIC_HARDWARE_WAVE_OUTPUT</term>
		/// <term>
		/// Returned value is the waveform-audio output device identifier associated with the specified driver. The hao parameter must be a
		/// valid ACM driver identifier of the HACMDRIVERID data type that supports the ACMDRIVERDETAILS_SUPPORTF_HARDWARE flag. If no
		/// waveform-audio output device is associated with the driver, MMSYSERR_NOTSUPPORTED is returned. The pMetric parameter must point
		/// to a buffer of a size equal to a DWORD value.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ACM_METRIC_MAX_SIZE_FILTER</term>
		/// <term>
		/// Returned value is the size of the largest WAVEFILTER structure. If hao is NULL, the return value is the largest WAVEFILTER
		/// structure in the system. If hao identifies an open instance of an ACM driver of the HACMDRIVER data type or an ACM driver
		/// identifier of the HACMDRIVERID data type, the largest WAVEFILTER structure for that driver is returned. The pMetric parameter
		/// must point to a buffer of a size equal to a DWORD value. This metric is not allowed for an ACM stream handle of the HACMSTREAM
		/// data type.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ACM_METRIC_MAX_SIZE_FORMAT</term>
		/// <term>
		/// Returned value is the size of the largest WAVEFORMATEX structure. If hao is NULL, the return value is the largest WAVEFORMATEX
		/// structure in the system. If hao identifies an open instance of an ACM driver of the HACMDRIVER data type or an ACM driver
		/// identifier of the HACMDRIVERID data type, the largest WAVEFORMATEX structure for that driver is returned. The pMetric parameter
		/// must point to a buffer of a size equal to a DWORD value. This metric is not allowed for an ACM stream handle of the HACMSTREAM
		/// data type.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pMetric">Pointer to the buffer to receive the metric details. The exact definition depends on the uMetric index.</param>
		/// <returns>
		/// <para>Returns zero if successful or an error otherwise. Possible error values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ACMERR_NOTPOSSIBLE</term>
		/// <term>The index specified in uMetric cannot be returned for the specified hao.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALHANDLE</term>
		/// <term>The specified handle is invalid.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALPARAM</term>
		/// <term>At least one parameter is invalid.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_NOTSUPPORTED</term>
		/// <term>The index specified in uMetric is not supported.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msacm/nf-msacm-acmmetrics MMRESULT ACMAPI acmMetrics( HACMOBJ hao, UINT
		// uMetric, LPVOID pMetric );
		[DllImport(Lib_Msacm32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("msacm.h", MSDNShortId = "NF:msacm.acmMetrics")]
		public static extern MMRESULT acmMetrics([In, Optional] HACMOBJ hao, ACM_METRIC uMetric, [Out] IntPtr pMetric);

		/// <summary>The <c>acmMetrics</c> function returns various metrics for the ACM or related ACM objects.</summary>
		/// <param name="hao">
		/// Handle to the ACM object to query for the metric specified in uMetric. For some queries, this parameter can be <c>NULL</c>.
		/// </param>
		/// <param name="uMetric">
		/// <para>Metric index to be returned in pMetric.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ACM_METRIC_COUNT_CODECS</term>
		/// <term>
		/// Returned value is the number of global ACM compressor or decompressor drivers in the system. The hao parameter must be NULL for
		/// this metric index. The pMetric parameter must point to a buffer of a size equal to a DWORD value.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ACM_METRIC_COUNT_CONVERTERS</term>
		/// <term>
		/// Returned value is the number of global ACM converter drivers in the system. The hao parameter must be NULL for this metric
		/// index. The pMetric parameter must point to a buffer of a size equal to a DWORD value.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ACM_METRIC_COUNT_DISABLED</term>
		/// <term>
		/// Returned value is the total number of global disabled ACM drivers (of all support types) in the system. The hao parameter must
		/// be NULL for this metric index. The pMetric parameter must point to a buffer of a size equal to a DWORD value. The sum of the
		/// ACM_METRIC_COUNT_DRIVERS and ACM_METRIC_COUNT_DISABLED metric indices is the total number of globally installed ACM drivers.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ACM_METRIC_COUNT_DRIVERS</term>
		/// <term>
		/// Returned value is the total number of enabled global ACM drivers (of all support types) in the system. The hao parameter must be
		/// NULL for this metric index. The pMetric parameter must point to a buffer of a size equal to a DWORD value.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ACM_METRIC_COUNT_FILTERS</term>
		/// <term>
		/// Returned value is the number of global ACM filter drivers in the system. The hao parameter must be NULL for this metric index.
		/// The pMetric parameter must point to a buffer of a size equal to a DWORD value.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ACM_METRIC_COUNT_HARDWARE</term>
		/// <term>
		/// Returned value is the number of global ACM hardware drivers in the system. The hao parameter must be NULL for this metric index.
		/// The pMetric parameter must point to a buffer of a size equal to a DWORD value.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ACM_METRIC_COUNT_LOCAL_CODECS</term>
		/// <term>
		/// Returned value is the number of local ACM compressor drivers, ACM decompressor drivers, or both for the calling task. The hao
		/// parameter must be NULL for this metric index. The pMetric parameter must point to a buffer of a size equal to a DWORD value.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ACM_METRIC_COUNT_LOCAL_CONVERTERS</term>
		/// <term>
		/// Returned value is the number of local ACM converter drivers for the calling task. The hao parameter must be NULL for this metric
		/// index. The pMetric parameter must point to a buffer of a size equal to a DWORD value.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ACM_METRIC_COUNT_LOCAL_DISABLED</term>
		/// <term>
		/// Returned value is the total number of local disabled ACM drivers, of all support types, for the calling task. The hao parameter
		/// must be NULL for this metric index. The pMetric parameter must point to a buffer of a size equal to a DWORD value. The sum of
		/// the ACM_METRIC_COUNT_LOCAL_DRIVERS and ACM_METRIC_COUNT_LOCAL_DISABLED metric indices is the total number of locally installed
		/// ACM drivers.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ACM_METRIC_COUNT_LOCAL_DRIVERS</term>
		/// <term>
		/// Returned value is the total number of enabled local ACM drivers (of all support types) for the calling task. The hao parameter
		/// must be NULL for this metric index. The pMetric parameter must point to a buffer of a size equal to a DWORD value.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ACM_METRIC_COUNT_LOCAL_FILTERS</term>
		/// <term>
		/// Returned value is the number of local ACM filter drivers for the calling task. The hao parameter must be NULL for this metric
		/// index. The pMetric parameter must point to a buffer of a size equal to a DWORD value.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ACM_METRIC_DRIVER_PRIORITY</term>
		/// <term>
		/// Returned value is the current priority for the specified driver. The hao parameter must be a valid ACM driver identifier of the
		/// HACMDRIVERID data type. The pMetric parameter must point to a buffer of a size equal to a DWORD value.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ACM_METRIC_DRIVER_SUPPORT</term>
		/// <term>
		/// Returned value is the fdwSupport flags for the specified driver. The hao parameter must be a valid ACM driver identifier of the
		/// HACMDRIVERID data type. The pMetric parameter must point to a buffer of a size equal to a DWORD value.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ACM_METRIC_HARDWARE_WAVE_INPUT</term>
		/// <term>
		/// Returned value is the waveform-audio input device identifier associated with the specified driver. The hao parameter must be a
		/// valid ACM driver identifier of the HACMDRIVERID data type that supports the ACMDRIVERDETAILS_SUPPORTF_HARDWARE flag. If no
		/// waveform-audio input device is associated with the driver, MMSYSERR_NOTSUPPORTED is returned. The pMetric parameter must point
		/// to a buffer of a size equal to a DWORD value.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ACM_METRIC_HARDWARE_WAVE_OUTPUT</term>
		/// <term>
		/// Returned value is the waveform-audio output device identifier associated with the specified driver. The hao parameter must be a
		/// valid ACM driver identifier of the HACMDRIVERID data type that supports the ACMDRIVERDETAILS_SUPPORTF_HARDWARE flag. If no
		/// waveform-audio output device is associated with the driver, MMSYSERR_NOTSUPPORTED is returned. The pMetric parameter must point
		/// to a buffer of a size equal to a DWORD value.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ACM_METRIC_MAX_SIZE_FILTER</term>
		/// <term>
		/// Returned value is the size of the largest WAVEFILTER structure. If hao is NULL, the return value is the largest WAVEFILTER
		/// structure in the system. If hao identifies an open instance of an ACM driver of the HACMDRIVER data type or an ACM driver
		/// identifier of the HACMDRIVERID data type, the largest WAVEFILTER structure for that driver is returned. The pMetric parameter
		/// must point to a buffer of a size equal to a DWORD value. This metric is not allowed for an ACM stream handle of the HACMSTREAM
		/// data type.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ACM_METRIC_MAX_SIZE_FORMAT</term>
		/// <term>
		/// Returned value is the size of the largest WAVEFORMATEX structure. If hao is NULL, the return value is the largest WAVEFORMATEX
		/// structure in the system. If hao identifies an open instance of an ACM driver of the HACMDRIVER data type or an ACM driver
		/// identifier of the HACMDRIVERID data type, the largest WAVEFORMATEX structure for that driver is returned. The pMetric parameter
		/// must point to a buffer of a size equal to a DWORD value. This metric is not allowed for an ACM stream handle of the HACMSTREAM
		/// data type.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pMetric">Pointer to the buffer to receive the metric details. The exact definition depends on the uMetric index.</param>
		/// <returns>
		/// <para>Returns zero if successful or an error otherwise. Possible error values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ACMERR_NOTPOSSIBLE</term>
		/// <term>The index specified in uMetric cannot be returned for the specified hao.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALHANDLE</term>
		/// <term>The specified handle is invalid.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALPARAM</term>
		/// <term>At least one parameter is invalid.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_NOTSUPPORTED</term>
		/// <term>The index specified in uMetric is not supported.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msacm/nf-msacm-acmmetrics MMRESULT ACMAPI acmMetrics( HACMOBJ hao, UINT
		// uMetric, LPVOID pMetric );
		[DllImport(Lib_Msacm32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("msacm.h", MSDNShortId = "NF:msacm.acmMetrics")]
		public static extern MMRESULT acmMetrics([In, Optional] HACMOBJ hao, ACM_METRIC uMetric, out uint pMetric);

		/// <summary>
		/// The <c>acmStreamClose</c> function closes an ACM conversion stream. If the function is successful, the handle is invalidated.
		/// </summary>
		/// <param name="has">Handle to the open conversion stream to be closed.</param>
		/// <param name="fdwClose">Reserved; must be zero.</param>
		/// <returns>
		/// <para>Returns zero if successful or an error otherwise. Possible error values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ACMERR_BUSY</term>
		/// <term>The conversion stream cannot be closed because an asynchronous conversion is still in progress.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALFLAG</term>
		/// <term>At least one flag is invalid.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALHANDLE</term>
		/// <term>The specified handle is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msacm/nf-msacm-acmstreamclose MMRESULT ACMAPI acmStreamClose( HACMSTREAM has,
		// DWORD fdwClose );
		[DllImport(Lib_Msacm32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("msacm.h", MSDNShortId = "NF:msacm.acmStreamClose")]
		public static extern MMRESULT acmStreamClose(HACMSTREAM has, uint fdwClose = 0);

		/// <summary>
		/// The <c>acmStreamConvert</c> function requests the ACM to perform a conversion on the specified conversion stream. A conversion
		/// may be synchronous or asynchronous, depending on how the stream was opened.
		/// </summary>
		/// <param name="has">Handle to the open conversion stream.</param>
		/// <param name="pash">
		/// Pointer to a stream header that describes source and destination buffers for a conversion. This header must have been prepared
		/// previously by using the acmStreamPrepareHeader function.
		/// </param>
		/// <param name="fdwConvert">
		/// <para>Flags for doing the conversion. The following values are defined.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ACM_STREAMCONVERTF_BLOCKALIGN</term>
		/// <term>
		/// Only integral numbers of blocks will be converted. Converted data will end on block-aligned boundaries. An application should
		/// use this flag for all conversions on a stream until there is not enough source data to convert to a block-aligned destination.
		/// In this case, the last conversion should be specified without this flag.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ACM_STREAMCONVERTF_END</term>
		/// <term>
		/// ACM conversion stream should begin returning pending instance data. For example, if a conversion stream holds instance data,
		/// such as the end of an echo filter operation, this flag will cause the stream to start returning this remaining data with
		/// optional source data. This flag can be specified with the ACM_STREAMCONVERTF_START flag.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ACM_STREAMCONVERTF_START</term>
		/// <term>
		/// ACM conversion stream should reinitialize its instance data. For example, if a conversion stream holds instance data, such as
		/// delta or predictor information, this flag will restore the stream to starting defaults. This flag can be specified with the
		/// ACM_STREAMCONVERTF_END flag.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Returns zero if successful or an error otherwise. Possible error values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ACMERR_BUSY</term>
		/// <term>The stream header specified in pash is currently in use and cannot be reused.</term>
		/// </item>
		/// <item>
		/// <term>ACMERR_UNPREPARED</term>
		/// <term>The stream header specified in pash is currently not prepared by the acmStreamPrepareHeader function.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALFLAG</term>
		/// <term>At least one flag is invalid.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALHANDLE</term>
		/// <term>The specified handle is invalid.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALPARAM</term>
		/// <term>At least one parameter is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// You must use the acmStreamPrepareHeader function to prepare the source and destination buffers before they are passed to <c>acmStreamConvert</c>.
		/// </para>
		/// <para>
		/// If an asynchronous conversion request is successfully queued by the ACM or driver and the conversion is later determined to be
		/// impossible, the ACMSTREAMHEADER structure is posted back to the application's callback function with the <c>cbDstLengthUsed</c>
		/// member set to zero.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msacm/nf-msacm-acmstreamconvert MMRESULT ACMAPI acmStreamConvert( HACMSTREAM
		// has, LPACMSTREAMHEADER pash, DWORD fdwConvert );
		[DllImport(Lib_Msacm32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("msacm.h", MSDNShortId = "NF:msacm.acmStreamConvert")]
		public static extern MMRESULT acmStreamConvert(HACMSTREAM has, ref ACMSTREAMHEADER pash, ACM_STREAMCONVERTF fdwConvert);

		/// <summary>The <c>acmStreamMessage</c> function sends a driver-specific message to an ACM driver.</summary>
		/// <param name="has">Handle to an open conversion stream.</param>
		/// <param name="uMsg">Message to send.</param>
		/// <param name="lParam1">Message parameter.</param>
		/// <param name="lParam2">Message parameter.</param>
		/// <returns>Returns the value returned by the ACM device driver.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msacm/nf-msacm-acmstreammessage MMRESULT ACMAPI acmStreamMessage( HACMSTREAM
		// has, UINT uMsg, LPARAM lParam1, LPARAM lParam2 );
		[DllImport(Lib_Msacm32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("msacm.h", MSDNShortId = "NF:msacm.acmStreamMessage")]
		public static extern MMRESULT acmStreamMessage(HACMSTREAM has, uint uMsg, IntPtr lParam1, IntPtr lParam2);

		/// <summary>
		/// The <c>acmStreamOpen</c> function opens an ACM conversion stream. Conversion streams are used to convert data from one specified
		/// audio format to another.
		/// </summary>
		/// <param name="phas">
		/// Pointer to a handle that will receive the new stream handle that can be used to perform conversions. This handle is used to
		/// identify the stream in calls to other ACM stream conversion functions. If the ACM_STREAMOPENF_QUERY flag is specified, this
		/// parameter should be <c>NULL</c>.
		/// </param>
		/// <param name="had">
		/// Handle to an ACM driver. If this handle is specified, it identifies a specific driver to be used for a conversion stream. If
		/// this parameter is <c>NULL</c>, all suitable installed ACM drivers are queried until a match is found.
		/// </param>
		/// <param name="pwfxSrc">Pointer to a WAVEFORMATEX structure that identifies the desired source format for the conversion.</param>
		/// <param name="pwfxDst">Pointer to a WAVEFORMATEX structure that identifies the desired destination format for the conversion.</param>
		/// <param name="pwfltr">
		/// Pointer to a WAVEFILTER structure that identifies the desired filtering operation to perform on the conversion stream. If no
		/// filtering operation is desired, this parameter can be <c>NULL</c>. If a filter is specified, the source (pwfxSrc) and
		/// destination (pwfxDst) formats must be the same.
		/// </param>
		/// <param name="dwCallback">
		/// Pointer to a callback function, a handle of a window, or a handle of an event. A callback function will be called only if the
		/// conversion stream is opened with the ACM_STREAMOPENF_ASYNC flag. A callback function is notified when the conversion stream is
		/// opened or closed and after each buffer is converted. If the conversion stream is opened without the ACM_STREAMOPENF_ASYNC flag,
		/// this parameter should be set to zero.
		/// </param>
		/// <param name="dwInstance">
		/// User-instance data passed to the callback function specified by the dwCallback parameter. This parameter is not used with window
		/// and event callbacks. If the conversion stream is opened without the ACM_STREAMOPENF_ASYNC flag, this parameter should be set to zero.
		/// </param>
		/// <param name="fdwOpen">
		/// <para>Flags for opening the conversion stream. The following values are defined.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ACM_STREAMOPENF_ASYNC</term>
		/// <term>ACMSTREAMHEADER structure for the ACMSTREAMHEADER_STATUSF_DONE flag.</term>
		/// </item>
		/// <item>
		/// <term>ACM_STREAMOPENF_NONREALTIME</term>
		/// <term>
		/// ACM will not consider time constraints when converting the data. By default, the driver will attempt to convert the data in real
		/// time. For some formats, specifying this flag might improve the audio quality or other characteristics.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ACM_STREAMOPENF_QUERY</term>
		/// <term>
		/// ACM will be queried to determine whether it supports the given conversion. A conversion stream will not be opened, and no handle
		/// will be returned in the phas parameter.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CALLBACK_EVENT</term>
		/// <term>The dwCallback parameter is a handle of an event.</term>
		/// </item>
		/// <item>
		/// <term>CALLBACK_FUNCTION</term>
		/// <term>
		/// The dwCallback parameter is a callback procedure address. The function prototype must conform to the acmStreamConvertCallback prototype.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CALLBACK_WINDOW</term>
		/// <term>The dwCallback parameter is a window handle.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Returns zero if successful or an error otherwise. Possible error values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ACMERR_NOTPOSSIBLE</term>
		/// <term>The requested operation cannot be performed.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALFLAG</term>
		/// <term>At least one flag is invalid.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALHANDLE</term>
		/// <term>The specified handle is invalid.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALPARAM</term>
		/// <term>At least one parameter is invalid.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_NOMEM</term>
		/// <term>The system is unable to allocate resources.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If an ACM driver cannot perform real-time conversions and the ACM_STREAMOPENF_NONREALTIME flag is not specified for the fdwOpen
		/// parameter, the open operation will fail returning an ACMERR_NOTPOSSIBLE error code. An application can use the
		/// ACM_STREAMOPENF_QUERY flag to determine if real-time conversions are supported for input.
		/// </para>
		/// <para>
		/// If an application uses a window to receive callback information, the MM_ACM_OPEN, MM_ACM_CLOSE, and MM_ACM_DONE messages are
		/// sent to the window procedure function to indicate the progress of the conversion stream. In this case, the ACMSTREAMHEADER
		/// structure for MM_ACM_DONE, but it is not used for MM_ACM_OPEN and MM_ACM_CLOSE.
		/// </para>
		/// <para>
		/// If an application uses a function to receive callback information, the MM_ACM_OPEN, MM_ACM_CLOSE, and MM_ACM_DONE messages are
		/// sent to the function to indicate the progress of waveform-audio output. The callback function must reside in a dynamic-link
		/// library (DLL).
		/// </para>
		/// <para>
		/// If an application uses an event for callback notification, the event is signaled to indicate the progress of the conversion
		/// stream. The event will be signaled when a stream is opened, after each buffer is converted, and when the stream is closed.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msacm/nf-msacm-acmstreamopen MMRESULT ACMAPI acmStreamOpen( LPHACMSTREAM phas,
		// HACMDRIVER had, LPWAVEFORMATEX pwfxSrc, LPWAVEFORMATEX pwfxDst, LPWAVEFILTER pwfltr, DWORD_PTR dwCallback, DWORD_PTR dwInstance,
		// DWORD fdwOpen );
		[DllImport(Lib_Msacm32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("msacm.h", MSDNShortId = "NF:msacm.acmStreamOpen")]
		public static extern MMRESULT acmStreamOpen(out SafeHACMSTREAM phas, [In, Optional] HACMDRIVER had, in WAVEFORMATEX pwfxSrc, in WAVEFORMATEX pwfxDst, in WAVEFILTER pwfltr, IntPtr dwCallback, IntPtr dwInstance, ACM_STREAMOPENF fdwOpen);

		/// <summary>
		/// The <c>acmStreamOpen</c> function opens an ACM conversion stream. Conversion streams are used to convert data from one specified
		/// audio format to another.
		/// </summary>
		/// <param name="phas">
		/// Pointer to a handle that will receive the new stream handle that can be used to perform conversions. This handle is used to
		/// identify the stream in calls to other ACM stream conversion functions. If the ACM_STREAMOPENF_QUERY flag is specified, this
		/// parameter should be <c>NULL</c>.
		/// </param>
		/// <param name="had">
		/// Handle to an ACM driver. If this handle is specified, it identifies a specific driver to be used for a conversion stream. If
		/// this parameter is <c>NULL</c>, all suitable installed ACM drivers are queried until a match is found.
		/// </param>
		/// <param name="pwfxSrc">Pointer to a WAVEFORMATEX structure that identifies the desired source format for the conversion.</param>
		/// <param name="pwfxDst">Pointer to a WAVEFORMATEX structure that identifies the desired destination format for the conversion.</param>
		/// <param name="pwfltr">
		/// Pointer to a WAVEFILTER structure that identifies the desired filtering operation to perform on the conversion stream. If no
		/// filtering operation is desired, this parameter can be <c>NULL</c>. If a filter is specified, the source (pwfxSrc) and
		/// destination (pwfxDst) formats must be the same.
		/// </param>
		/// <param name="dwCallback">
		/// Pointer to a callback function, a handle of a window, or a handle of an event. A callback function will be called only if the
		/// conversion stream is opened with the ACM_STREAMOPENF_ASYNC flag. A callback function is notified when the conversion stream is
		/// opened or closed and after each buffer is converted. If the conversion stream is opened without the ACM_STREAMOPENF_ASYNC flag,
		/// this parameter should be set to zero.
		/// </param>
		/// <param name="dwInstance">
		/// User-instance data passed to the callback function specified by the dwCallback parameter. This parameter is not used with window
		/// and event callbacks. If the conversion stream is opened without the ACM_STREAMOPENF_ASYNC flag, this parameter should be set to zero.
		/// </param>
		/// <param name="fdwOpen">
		/// <para>Flags for opening the conversion stream. The following values are defined.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ACM_STREAMOPENF_ASYNC</term>
		/// <term>ACMSTREAMHEADER structure for the ACMSTREAMHEADER_STATUSF_DONE flag.</term>
		/// </item>
		/// <item>
		/// <term>ACM_STREAMOPENF_NONREALTIME</term>
		/// <term>
		/// ACM will not consider time constraints when converting the data. By default, the driver will attempt to convert the data in real
		/// time. For some formats, specifying this flag might improve the audio quality or other characteristics.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ACM_STREAMOPENF_QUERY</term>
		/// <term>
		/// ACM will be queried to determine whether it supports the given conversion. A conversion stream will not be opened, and no handle
		/// will be returned in the phas parameter.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CALLBACK_EVENT</term>
		/// <term>The dwCallback parameter is a handle of an event.</term>
		/// </item>
		/// <item>
		/// <term>CALLBACK_FUNCTION</term>
		/// <term>
		/// The dwCallback parameter is a callback procedure address. The function prototype must conform to the acmStreamConvertCallback prototype.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CALLBACK_WINDOW</term>
		/// <term>The dwCallback parameter is a window handle.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Returns zero if successful or an error otherwise. Possible error values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ACMERR_NOTPOSSIBLE</term>
		/// <term>The requested operation cannot be performed.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALFLAG</term>
		/// <term>At least one flag is invalid.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALHANDLE</term>
		/// <term>The specified handle is invalid.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALPARAM</term>
		/// <term>At least one parameter is invalid.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_NOMEM</term>
		/// <term>The system is unable to allocate resources.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If an ACM driver cannot perform real-time conversions and the ACM_STREAMOPENF_NONREALTIME flag is not specified for the fdwOpen
		/// parameter, the open operation will fail returning an ACMERR_NOTPOSSIBLE error code. An application can use the
		/// ACM_STREAMOPENF_QUERY flag to determine if real-time conversions are supported for input.
		/// </para>
		/// <para>
		/// If an application uses a window to receive callback information, the MM_ACM_OPEN, MM_ACM_CLOSE, and MM_ACM_DONE messages are
		/// sent to the window procedure function to indicate the progress of the conversion stream. In this case, the ACMSTREAMHEADER
		/// structure for MM_ACM_DONE, but it is not used for MM_ACM_OPEN and MM_ACM_CLOSE.
		/// </para>
		/// <para>
		/// If an application uses a function to receive callback information, the MM_ACM_OPEN, MM_ACM_CLOSE, and MM_ACM_DONE messages are
		/// sent to the function to indicate the progress of waveform-audio output. The callback function must reside in a dynamic-link
		/// library (DLL).
		/// </para>
		/// <para>
		/// If an application uses an event for callback notification, the event is signaled to indicate the progress of the conversion
		/// stream. The event will be signaled when a stream is opened, after each buffer is converted, and when the stream is closed.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msacm/nf-msacm-acmstreamopen MMRESULT ACMAPI acmStreamOpen( LPHACMSTREAM phas,
		// HACMDRIVER had, LPWAVEFORMATEX pwfxSrc, LPWAVEFORMATEX pwfxDst, LPWAVEFILTER pwfltr, DWORD_PTR dwCallback, DWORD_PTR dwInstance,
		// DWORD fdwOpen );
		[DllImport(Lib_Msacm32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("msacm.h", MSDNShortId = "NF:msacm.acmStreamOpen")]
		public static extern MMRESULT acmStreamOpen(out SafeHACMSTREAM phas, [In, Optional] HACMDRIVER had, in WAVEFORMATEX pwfxSrc, in WAVEFORMATEX pwfxDst, [In, Optional] IntPtr pwfltr, IntPtr dwCallback, IntPtr dwInstance, ACM_STREAMOPENF fdwOpen);

		/// <summary>
		/// The ACMSTREAMHEADER structure for an ACM stream conversion. This function must be called for every stream header before it can
		/// be used in a conversion stream. An application needs to prepare a stream header only once for the life of a given stream. The
		/// stream header can be reused as long as the sizes of the source and destination buffers do not exceed the sizes used when the
		/// stream header was originally prepared.
		/// </summary>
		/// <param name="has">Handle to the conversion steam.</param>
		/// <param name="pash">Pointer to an ACMSTREAMHEADER structure that identifies the source and destination buffers to be prepared.</param>
		/// <param name="fdwPrepare">Reserved; must be zero.</param>
		/// <returns>
		/// <para>Returns zero if successful or an error otherwise. Possible error values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>MMSYSERR_INVALFLAG</term>
		/// <term>At least one flag is invalid.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALHANDLE</term>
		/// <term>The specified handle is invalid.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALPARAM</term>
		/// <term>At least one parameter is invalid.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_NOMEM</term>
		/// <term>The system is unable to allocate resources.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// Preparing a stream header that has already been prepared has no effect, and the function returns zero. Nevertheless, you should
		/// ensure your application does not prepare a stream header multiple times.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msacm/nf-msacm-acmstreamprepareheader MMRESULT ACMAPI acmStreamPrepareHeader(
		// HACMSTREAM has, LPACMSTREAMHEADER pash, DWORD fdwPrepare );
		[DllImport(Lib_Msacm32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("msacm.h", MSDNShortId = "NF:msacm.acmStreamPrepareHeader")]
		public static extern MMRESULT acmStreamPrepareHeader(HACMSTREAM has, ref ACMSTREAMHEADER pash, uint fdwPrepare = 0);

		/// <summary>
		/// The <c>acmStreamReset</c> function stops conversions for a given ACM stream. All pending buffers are marked as done and returned
		/// to the application.
		/// </summary>
		/// <param name="has">Handle to the conversion stream.</param>
		/// <param name="fdwReset">Reserved; must be zero.</param>
		/// <returns>
		/// <para>Returns zero if successful or an error otherwise. Possible error values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>MMSYSERR_INVALFLAG</term>
		/// <term>At least one flag is invalid.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALHANDLE</term>
		/// <term>The specified handle is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// Resetting an ACM conversion stream is necessary only for asynchronous conversion streams. Resetting a synchronous conversion
		/// stream will succeed, but no action will be taken.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msacm/nf-msacm-acmstreamreset MMRESULT ACMAPI acmStreamReset( HACMSTREAM has,
		// DWORD fdwReset );
		[DllImport(Lib_Msacm32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("msacm.h", MSDNShortId = "NF:msacm.acmStreamReset")]
		public static extern MMRESULT acmStreamReset(HACMSTREAM has, uint fdwReset = 0);

		/// <summary>The <c>acmStreamSize</c> function returns a recommended size for a source or destination buffer on an ACM stream.</summary>
		/// <param name="has">Handle to the conversion stream.</param>
		/// <param name="cbInput">
		/// Size, in bytes, of the source or destination buffer. The fdwSize flags specify what the input parameter defines. This parameter
		/// must be nonzero.
		/// </param>
		/// <param name="pdwOutputBytes">
		/// Pointer to a variable that contains the size, in bytes, of the source or destination buffer. The fdwSize flags specify what the
		/// output parameter defines. If the <c>acmStreamSize</c> function succeeds, this location will always be filled with a nonzero value.
		/// </param>
		/// <param name="fdwSize">
		/// <para>Flags for the stream size query. The following values are defined:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ACM_STREAMSIZEF_DESTINATION</term>
		/// <term>
		/// The cbInput parameter contains the size of the destination buffer. The pdwOutputBytes parameter will receive the recommended
		/// source buffer size, in bytes.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ACM_STREAMSIZEF_SOURCE</term>
		/// <term>
		/// The cbInput parameter contains the size of the source buffer. The pdwOutputBytes parameter will receive the recommended
		/// destination buffer size, in bytes.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Returns zero if successful or an error otherwise. Possible error values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ACMERR_NOTPOSSIBLE</term>
		/// <term>The requested operation cannot be performed.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALFLAG</term>
		/// <term>At least one flag is invalid.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALHANDLE</term>
		/// <term>The specified handle is invalid.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALPARAM</term>
		/// <term>At least one parameter is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// An application can use this function to determine suggested buffer sizes for either source or destination buffers. The buffer
		/// sizes returned might be only an estimation of the actual sizes required for conversion. Because actual conversion sizes cannot
		/// always be determined without performing the conversion, the sizes returned will usually be overestimated.
		/// </para>
		/// <para>
		/// In the event of an error, the location pointed to by pdwOutputBytes will receive zero. This assumes that the pointer specified
		/// by pdwOutputBytes is valid.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msacm/nf-msacm-acmstreamsize MMRESULT ACMAPI acmStreamSize( HACMSTREAM has,
		// DWORD cbInput, LPDWORD pdwOutputBytes, DWORD fdwSize );
		[DllImport(Lib_Msacm32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("msacm.h", MSDNShortId = "NF:msacm.acmStreamSize")]
		public static extern MMRESULT acmStreamSize(HACMSTREAM has, uint cbInput, out uint pdwOutputBytes, ACM_STREAMSIZEF fdwSize);

		/// <summary>
		/// The <c>acmStreamUnprepareHeader</c> function cleans up the preparation performed by the acmStreamPrepareHeader function for an
		/// ACM stream. This function must be called after the ACM is finished with the given buffers. An application must call this
		/// function before freeing the source and destination buffers.
		/// </summary>
		/// <param name="has">Handle to the conversion steam.</param>
		/// <param name="pash">Pointer to an ACMSTREAMHEADER structure that identifies the source and destination buffers to be unprepared.</param>
		/// <param name="fdwUnprepare">Reserved; must be zero.</param>
		/// <returns>
		/// <para>Returns zero if successful or an error otherwise. Possible error values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ACMERR_BUSY</term>
		/// <term>The stream header specified in pash is currently in use and cannot be unprepared.</term>
		/// </item>
		/// <item>
		/// <term>ACMERR_UNPREPARED</term>
		/// <term>The stream header specified in pash is currently not prepared by the acmStreamPrepareHeader function.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALFLAG</term>
		/// <term>At least one flag is invalid.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALHANDLE</term>
		/// <term>The specified handle is invalid.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALPARAM</term>
		/// <term>At least one parameter is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Unpreparing a stream header that has already been unprepared is an error. An application must specify the source and destination
		/// buffer lengths ( <c>cbSrcLength</c> and <c>cbDstLength</c>, respectively) that were used during a call to the corresponding
		/// acmStreamPrepareHeader. Failing to reset these member values will cause <c>acmStreamUnprepareHeader</c> to fail with an
		/// MMSYSERR_INVALPARAM error.
		/// </para>
		/// <para>
		/// The ACM can recover from some errors. The ACM will return a nonzero error, yet the stream header will be properly unprepared. To
		/// determine whether the stream header was actually unprepared, an application can examine the ACMSTREAMHEADER_STATUSF_PREPARED
		/// flag. If <c>acmStreamUnprepareHeader</c> returns success, the header will always be unprepared.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msacm/nf-msacm-acmstreamunprepareheader MMRESULT ACMAPI
		// acmStreamUnprepareHeader( HACMSTREAM has, LPACMSTREAMHEADER pash, DWORD fdwUnprepare );
		[DllImport(Lib_Msacm32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("msacm.h", MSDNShortId = "NF:msacm.acmStreamUnprepareHeader")]
		public static extern MMRESULT acmStreamUnprepareHeader(HACMSTREAM has, ref ACMSTREAMHEADER pash, uint fdwUnprepare = 0);

		/// <summary>The <c>ACMDRIVERDETAILS</c> structure describes the features of an ACM driver.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/msacm/ns-msacm-acmdriverdetails typedef struct tACMDRIVERDETAILS { DWORD
		// cbStruct; FOURCC fccType; FOURCC fccComp; WORD wMid; WORD wPid; DWORD vdwACM; DWORD vdwDriver; DWORD fdwSupport; DWORD
		// cFormatTags; DWORD cFilterTags; HICON hicon; char szShortName[ACMDRIVERDETAILS_SHORTNAME_CHARS]; char
		// szLongName[ACMDRIVERDETAILS_LONGNAME_CHARS]; char szCopyright[ACMDRIVERDETAILS_COPYRIGHT_CHARS]; char
		// szLicensing[ACMDRIVERDETAILS_LICENSING_CHARS]; char szFeatures[ACMDRIVERDETAILS_FEATURES_CHARS]; } ACMDRIVERDETAILS,
		// *PACMDRIVERDETAILS, *LPACMDRIVERDETAILS;
		[PInvokeData("msacm.h", MSDNShortId = "NS:msacm.tACMDRIVERDETAILS")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct ACMDRIVERDETAILS
		{
			private const int ACMDRIVERDETAILS_SHORTNAME_CHARS = 32;
			private const int ACMDRIVERDETAILS_LONGNAME_CHARS = 128;
			private const int ACMDRIVERDETAILS_COPYRIGHT_CHARS = 80;
			private const int ACMDRIVERDETAILS_LICENSING_CHARS = 128;
			private const int ACMDRIVERDETAILS_FEATURES_CHARS = 512;

			/// <summary>
			/// Size, in bytes, of the valid information contained in the <c>ACMDRIVERDETAILS</c> structure. An application should
			/// initialize this member to the size, in bytes, of the desired information. The size specified in this member must be large
			/// enough to contain the <c>cbStruct</c> member of the <c>ACMDRIVERDETAILS</c> structure. When the acmDriverDetails function
			/// returns, this member contains the actual size of the information returned. The returned information will never exceed the
			/// requested size.
			/// </summary>
			public uint cbStruct;

			/// <summary>Type of the driver. For ACM drivers, set this member to ACMDRIVERDETAILS_FCCTYPE_AUDIOCODEC.</summary>
			public uint fccType;

			/// <summary>Subtype of the driver. This member is currently set to ACMDRIVERDETAILS_FCCCOMP_UNDEFINED (zero).</summary>
			public uint fccComp;

			/// <summary>Manufacturer identifier. Manufacturer identifiers are defined in Manufacturer and Product Identifiers.</summary>
			public ushort wMid;

			/// <summary>Product identifier. Product identifiers are defined in Manufacturer and Product Identifiers.</summary>
			public ushort wPid;

			/// <summary>
			/// Version of the ACM for which this driver was compiled. The version number is a hexadecimal number in the format 0xAABBCCCC,
			/// where AA is the major version number, BB is the minor version number, and CCCC is the build number. The version parts
			/// (major, minor, and build) should be displayed as decimal numbers.
			/// </summary>
			public uint vdwACM;

			/// <summary>
			/// Version of the driver. The version number is a hexadecimal number in the format 0xAABBCCCC, where AA is the major version
			/// number, BB is the minor version number, and CCCC is the build number. The version parts (major, minor, and build) should be
			/// displayed as decimal numbers.
			/// </summary>
			public uint vdwDriver;

			/// <summary>
			/// <para>Support flags for the driver. The following values are defined:</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Name</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>ACMDRIVERDETAILS_SUPPORTF_ASYNC</term>
			/// <term>Driver supports asynchronous conversions.</term>
			/// </item>
			/// <item>
			/// <term>ACMDRIVERDETAILS_SUPPORTF_CODEC</term>
			/// <term>
			/// Driver supports conversion between two different format tags. For example, if a driver supports compression from
			/// WAVE_FORMAT_PCM to WAVE_FORMAT_ADPCM, this flag is set.
			/// </term>
			/// </item>
			/// <item>
			/// <term>ACMDRIVERDETAILS_SUPPORTF_CONVERTER</term>
			/// <term>
			/// Driver supports conversion between two different formats of the same format tag. For example, if a driver supports
			/// resampling of WAVE_FORMAT_PCM, this flag is set.
			/// </term>
			/// </item>
			/// <item>
			/// <term>ACMDRIVERDETAILS_SUPPORTF_DISABLED</term>
			/// <term>
			/// Driver has been disabled. This flag is set by the ACM for a driver when it has been disabled for any of a number of reasons.
			/// Disabled drivers cannot be opened and can be used only under very limited circumstances.
			/// </term>
			/// </item>
			/// <item>
			/// <term>ACMDRIVERDETAILS_SUPPORTF_FILTER</term>
			/// <term>
			/// Driver supports a filter (modification of the data without changing any of the format attributes). For example, if a driver
			/// supports volume or echo operations on WAVE_FORMAT_PCM, this flag is set.
			/// </term>
			/// </item>
			/// <item>
			/// <term>ACMDRIVERDETAILS_SUPPORTF_HARDWARE</term>
			/// <term>
			/// Driver supports hardware input, output, or both through a waveform-audio device. An application should use the acmMetrics
			/// function with the ACM_METRIC_HARDWARE_WAVE_INPUT and ACM_METRIC_HARDWARE_WAVE_OUTPUT metric indexes to get the
			/// waveform-audio device identifiers associated with the supporting ACM driver.
			/// </term>
			/// </item>
			/// <item>
			/// <term>ACMDRIVERDETAILS_SUPPORTF_LOCAL</term>
			/// <term>The driver has been installed locally with respect to the current task.</term>
			/// </item>
			/// </list>
			/// </summary>
			public ACMDRIVERDETAILS_SUPPORTF fdwSupport;

			/// <summary>Number of unique format tags supported by this driver.</summary>
			public uint cFormatTags;

			/// <summary>Number of unique filter tags supported by this driver.</summary>
			public uint cFilterTags;

			/// <summary>
			/// Handle to a custom icon for this driver. An application can use this icon for referencing the driver visually. This member
			/// can be <c>NULL</c>.
			/// </summary>
			public HICON hicon;

			/// <summary>
			/// Null-terminated string that describes the name of the driver. This string is intended to be displayed in small spaces.
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = ACMDRIVERDETAILS_SHORTNAME_CHARS)]
			public string szShortName;

			/// <summary>
			/// Null-terminated string that describes the full name of the driver. This string is intended to be displayed in large
			/// (descriptive) spaces.
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = ACMDRIVERDETAILS_LONGNAME_CHARS)]
			public string szLongName;

			/// <summary>Null-terminated string that provides copyright information for the driver.</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = ACMDRIVERDETAILS_COPYRIGHT_CHARS)]
			public string szCopyright;

			/// <summary>Null-terminated string that provides special licensing information for the driver.</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = ACMDRIVERDETAILS_LICENSING_CHARS)]
			public string szLicensing;

			/// <summary>Null-terminated string that provides special feature information for the driver.</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = ACMDRIVERDETAILS_FEATURES_CHARS)]
			public string szFeatures;
		}

		/// <summary>
		/// The <c>ACMFILTERCHOOSE</c> structure contains information the ACM uses to initialize the system-defined waveform-audio filter
		/// selection dialog box. After the user closes the dialog box, the system returns information about the user's selection in this structure.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/msacm/ns-msacm-acmfilterchoose typedef struct tACMFILTERCHOOSE { DWORD
		// cbStruct; DWORD fdwStyle; HWND hwndOwner; LPWAVEFILTER pwfltr; DWORD cbwfltr; LPCSTR pszTitle; char
		// szFilterTag[ACMFILTERTAGDETAILS_FILTERTAG_CHARS]; char szFilter[ACMFILTERDETAILS_FILTER_CHARS]; LPSTR pszName; DWORD cchName;
		// DWORD fdwEnum; LPWAVEFILTER pwfltrEnum; HINSTANCE hInstance; LPCSTR pszTemplateName; LPARAM lCustData; ACMFILTERCHOOSEHOOKPROC
		// pfnHook; } ACMFILTERCHOOSE, *PACMFILTERCHOOSE, *LPACMFILTERCHOOSE;
		[PInvokeData("msacm.h", MSDNShortId = "NS:msacm.tACMFILTERCHOOSE")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct ACMFILTERCHOOSE
		{
			/// <summary>
			/// Size, in bytes, of the <c>ACMFILTERCHOOSE</c> structure. This member must be initialized before an application calls the
			/// acmFilterChoose function. The size specified in this member must be large enough to contain the base <c>ACMFILTERCHOOSE</c> structure.
			/// </summary>
			public uint cbStruct;

			/// <summary>
			/// <para>
			/// Optional style flags for the acmFilterChoose function. This member must be initialized to a valid combination of the
			/// following flags before an application calls the <c>acmFilterChoose</c> function. The following values are defined:
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Name</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>ACMFILTERCHOOSE_STYLEF_CONTEXTHELP</term>
			/// <term>
			/// Context-sensitive help will be available in the dialog box. To use this feature, an application must register the
			/// ACMHELPMSGCONTEXTMENU and ACMHELPMSGCONTEXTHELP constants, using the RegisterWindowMessage function. When the user invokes
			/// help, the registered message will be posted to the owning window. The message will contain the wParam and lParam parameters
			/// from the original WM_CONTEXTMENU or WM_CONTEXTHELP message.
			/// </term>
			/// </item>
			/// <item>
			/// <term>ACMFILTERCHOOSE_STYLEF_ENABLEHOOK</term>
			/// <term>
			/// Enables the hook function specified in the pfnHook member. An application can use hook functions for a variety of
			/// customizations, including answering the MM_ACM_FILTERCHOOSE message.
			/// </term>
			/// </item>
			/// <item>
			/// <term>ACMFILTERCHOOSE_STYLEF_ENABLETEMPLATE</term>
			/// <term>Causes the ACM to create the dialog box template identified by the hInstance and pszTemplateName members.</term>
			/// </item>
			/// <item>
			/// <term>ACMFILTERCHOOSE_STYLEF_ENABLETEMPLATEHANDLE</term>
			/// <term>
			/// The hInstance member identifies a data block that contains a preloaded dialog box template. If this flag is specified, the
			/// ACM ignores the pszTemplateName member.
			/// </term>
			/// </item>
			/// <item>
			/// <term>ACMFILTERCHOOSE_STYLEF_INITTOFILTERSTRUCT</term>
			/// <term>
			/// The buffer pointed to by pwfltr contains a valid WAVEFILTER structure that the dialog box will use as the initial selection.
			/// </term>
			/// </item>
			/// <item>
			/// <term>ACMFILTERCHOOSE_STYLEF_SHOWHELP</term>
			/// <term>
			/// A help button will appear in the dialog box. To use a custom Help file, an application must register the ACMHELPMSGSTRING
			/// value with the RegisterWindowMessage function. When the user presses the help button, the registered message is posted to
			/// the owner.
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			public ACMFILTERCHOOSE_STYLEF fdwStyle;

			/// <summary>
			/// Handle to the window that owns the dialog box. This member can be any valid window handle or <c>NULL</c> if the dialog box
			/// has no owner. This member must be initialized before calling the acmFilterChoose function.
			/// </summary>
			public HWND hwndOwner;

			/// <summary>
			/// Pointer to a WAVEFILTER structure. If the ACMFILTERCHOOSE_STYLEF_INITTOFILTERSTRUCT flag is specified in the <c>fdwStyle</c>
			/// member, this structure must be initialized to a valid filter. When the acmFilterChoose function returns, this buffer
			/// contains the selected filter. If the user cancels the dialog box, no changes will be made to this buffer.
			/// </summary>
			public IntPtr pwfltr;

			/// <summary>
			/// Size, in bytes, of the buffer pointed to by the <c>pwfltr</c> member. The acmFilterChoose function returns
			/// ACMERR_NOTPOSSIBLE if the buffer is too small to contain the filter information; the ACM also copies the required size into
			/// this member. An application can use the acmMetrics and acmFilterTagDetails functions to determine the largest size required
			/// for this buffer.
			/// </summary>
			public uint cbwfltr;

			/// <summary>
			/// Pointer to a string to be placed in the title bar of the dialog box. If this member is <c>NULL</c>, the ACM uses the default
			/// title (that is, "Filter Selection").
			/// </summary>
			[MarshalAs(UnmanagedType.LPTStr)]
			public string pszTitle;

			/// <summary>
			/// Buffer containing a null-terminated string describing the filter tag of the filter selection when the ACMFILTERTAGDETAILS
			/// structure returned by acmFilterTagDetails. If the user cancels the dialog box, this member will contain a null-terminated string.
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = ACMFILTERTAGDETAILS_FILTERTAG_CHARS)]
			public string szFilterTag;

			/// <summary>
			/// Buffer containing a null-terminated string describing the filter attributes of the filter selection when the
			/// ACMFILTERDETAILS structure returned by acmFilterDetails. If the user cancels the dialog box, this member will contain a
			/// null-terminated string.
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = ACMFILTERDETAILS_FILTER_CHARS)]
			public string szFilter;

			/// <summary>
			/// <para>
			/// Pointer to a string for a user-defined filter name. If this is a non-null-terminated string, the ACM attempts to match the
			/// name with a previously saved user-defined filter name. If a match is found, the dialog box is initialized to that filter. If
			/// a match is not found or this member is a null-terminated string, this member is ignored for input. When the acmFilterChoose
			/// function returns, this buffer contains a null-terminated string describing the user-defined filter. If the filter name is
			/// untitled (that is, the user has not given a name for the filter), this member will be a null-terminated string on return. If
			/// the user cancels the dialog box, no changes will be made to this buffer.
			/// </para>
			/// <para>
			/// If the ACMFILTERCHOOSE_STYLEF_INITTOFILTERSTRUCT flag is specified by the <c>fdwStyle</c> member, the <c>pszName</c> member
			/// is ignored as an input member.
			/// </para>
			/// </summary>
			[MarshalAs(UnmanagedType.LPTStr)]
			public string pszName;

			/// <summary>
			/// Size, in characters, of the buffer identified by the <c>pszName</c> member. This buffer should be at least 128 characters
			/// long. If <c>pszName</c> is <c>NULL</c>, this member is ignored.
			/// </summary>
			public uint cchName;

			/// <summary>
			/// <para>
			/// Optional flags for restricting the type of filters listed in the dialog box. These flags are identical to the fdwEnum flags
			/// for the acmFilterEnum function. If <c>pwfltrEnum</c> is <c>NULL</c>, this member should be zero.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Name</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>ACM_FILTERENUMF_DWFILTERTAG</term>
			/// <term>
			/// The dwFilterTag member of the WAVEFILTER structure pointed to by the pwfltrEnum member is valid. The enumerator will only
			/// enumerate a filter that conforms to this attribute.
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			public ACM_FILTERENUMF fdwEnum;

			/// <summary>
			/// Pointer to a WAVEFILTER structure that will be used to restrict the filters listed in the dialog box. The <c>fdwEnum</c>
			/// member defines which members of this structure should be used for the enumeration restrictions. The <c>cbStruct</c> member
			/// of this <c>WAVEFILTER</c> structure must be initialized to the size of the <c>WAVEFILTER</c> structure. If no special
			/// restrictions are desired, this member can be <c>NULL</c>.
			/// </summary>
			public IntPtr pwfltrEnum;

			/// <summary>
			/// Handle to a data block that contains a dialog box template specified by the <c>pszTemplateName</c> member. This member is
			/// used only if the <c>fdwStyle</c> member specifies the ACMFILTERCHOOSE_STYLEF_ENABLETEMPLATE or
			/// ACMFILTERCHOOSE_STYLEF_ENABLETEMPLATEHANDLE flag; otherwise, this member should be <c>NULL</c> on input.
			/// </summary>
			public HINSTANCE hInstance;

			/// <summary>
			/// Pointer to a null-terminated string that specifies the name of the resource file for the dialog box template that is to be
			/// substituted for the dialog box template in the ACM. An application can use the MAKEINTRESOURCE macro for numbered dialog box
			/// resources. This member is used only if the <c>fdwStyle</c> member specifies the ACMFILTERCHOOSE_STYLEF_ENABLETEMPLATE flag;
			/// otherwise, this member should be <c>NULL</c> on input.
			/// </summary>
			[MarshalAs(UnmanagedType.LPStr)]
			public string pszTemplateName;

			/// <summary>
			/// Application-defined data that the ACM passes to the hook function identified by the <c>pfnHook</c> member. The system passes
			/// the data in the lParam parameter of the WM_INITDIALOG message.
			/// </summary>
			public IntPtr lCustData;

			/// <summary>
			/// Pointer to a callback function that processes messages intended for the dialog box. An application must specify the
			/// ACMFILTERCHOOSE_STYLEF_ENABLEHOOK flag in the <c>fdwStyle</c> member to enable the hook; otherwise, this member should be
			/// <c>NULL</c>. The hook function should return <c>FALSE</c> to pass a message to the standard dialog box procedure or
			/// <c>TRUE</c> to discard the message. The callback function type is acmFilterChooseHookProc.
			/// </summary>
			public ACMFILTERCHOOSEHOOKPROC pfnHook;
		}

		/// <summary>The <c>ACMFILTERDETAILS</c> structure details a waveform-audio filter for a specific filter tag for an ACM driver.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/msacm/ns-msacm-acmfilterdetails typedef struct tACMFILTERDETAILS { DWORD
		// cbStruct; DWORD dwFilterIndex; DWORD dwFilterTag; DWORD fdwSupport; LPWAVEFILTER pwfltr; DWORD cbwfltr; char
		// szFilter[ACMFILTERDETAILS_FILTER_CHARS]; } ACMFILTERDETAILS, *PACMFILTERDETAILS, *LPACMFILTERDETAILS;
		[PInvokeData("msacm.h", MSDNShortId = "NS:msacm.tACMFILTERDETAILS")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct ACMFILTERDETAILS
		{
			/// <summary>
			/// Size, in bytes, of the <c>ACMFILTERDETAILS</c> structure. This member must be initialized before calling the
			/// acmFilterDetails or acmFilterEnum functions. The size specified in this member must be large enough to contain the base
			/// <c>ACMFILTERDETAILS</c> structure. When the <c>acmFilterDetails</c> function returns, this member contains the actual size
			/// of the information returned. The returned information will never exceed the requested size.
			/// </summary>
			public uint cbStruct;

			/// <summary>
			/// Index of the filter about which details will be retrieved. The index ranges from zero to one less than the number of
			/// standard filters supported by an ACM driver for a filter tag. The number of standard filters supported by a driver for a
			/// filter tag is contained in the ACMFILTERTAGDETAILS structure. The <c>dwFilterIndex</c> member is used only when querying
			/// standard filter details about a driver by index; otherwise, this member should be zero. Also, this member will be set to
			/// zero by the ACM when an application queries for details on a filter; in other words, this member is used only for input and
			/// is never returned by the ACM or an ACM driver.
			/// </summary>
			public uint dwFilterIndex;

			/// <summary>
			/// Waveform-audio filter tag that the <c>ACMFILTERDETAILS</c> structure describes. This member is used as an input for the
			/// ACM_FILTERDETAILSF_INDEX query flag. For the ACM_FILTERDETAILSF_FORMAT query flag, this member must be initialized to the
			/// same filter tag as the <c>pwfltr</c> member specifies. If the acmFilterDetails function is successful, this member is always
			/// returned. This member should be set to WAVE_FILTER_UNKNOWN for all other query flags.
			/// </summary>
			public uint dwFilterTag;

			/// <summary>
			/// <para>
			/// Driver-support flags specific to the specified filter. These flags are identical to the ACMDRIVERDETAILS structure, but they
			/// are specific to the filter that is being queried. This member can be a combination of the following values and identifies
			/// which operations the driver supports for the filter tag:
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Name</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>ACMDRIVERDETAILS_SUPPORTF_ASYNC</term>
			/// <term>Driver supports asynchronous conversions.</term>
			/// </item>
			/// <item>
			/// <term>ACMDRIVERDETAILS_SUPPORTF_CODEC</term>
			/// <term>
			/// Driver supports conversion between two different format tags while using the specified filter. For example, if a driver
			/// supports compression from WAVE_FORMAT_PCM to WAVE_FORMAT_ADPCM with the specified filter, this flag is set.
			/// </term>
			/// </item>
			/// <item>
			/// <term>ACMDRIVERDETAILS_SUPPORTF_CONVERTER</term>
			/// <term>
			/// Driver supports conversion between two different formats of the same format tag while using the specified filter. For
			/// example, if a driver supports resampling of WAVE_FORMAT_PCM with the specified filter, this flag is set.
			/// </term>
			/// </item>
			/// <item>
			/// <term>ACMDRIVERDETAILS_SUPPORTF_FILTER</term>
			/// <term>
			/// Driver supports a filter (modification of the data without changing any of the format attributes). For example, if a driver
			/// supports volume or echo operations on WAVE_FORMAT_PCM, this flag is set.
			/// </term>
			/// </item>
			/// <item>
			/// <term>ACMDRIVERDETAILS_SUPPORTF_HARDWARE</term>
			/// <term>
			/// Driver supports hardware input, output, or both with the specified filter through a waveform-audio device. An application
			/// should use the acmMetrics function with the ACM_METRIC_HARDWARE_WAVE_INPUT and ACM_METRIC_HARDWARE_WAVE_OUTPUT metric
			/// indexes to retrieve the waveform-audio device identifiers associated with the supporting ACM driver.
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			public ACMDRIVERDETAILS_SUPPORTF fdwSupport;

			/// <summary>
			/// Pointer to a WAVEFILTER structure that will receive the filter details. This structure requires no initialization by the
			/// application unless the ACM_FILTERDETAILSF_FILTER flag is specified with the acmFilterDetails function. In this case, the
			/// <c>dwFilterTag</c> member of the <c>WAVEFILTER</c> structure must be equal to the <c>dwFilterTag</c> member of the
			/// <c>ACMFILTERDETAILS</c> structure.
			/// </summary>
			public IntPtr pwfltr;

			/// <summary>
			/// Size, in bytes, available for <c>pwfltr</c> to receive the filter details. The acmMetrics and acmFilterTagDetails functions
			/// can be used to determine the maximum size required for any filter available for the specified driver (or for all installed
			/// ACM drivers).
			/// </summary>
			public uint cbwfltr;

			/// <summary>
			/// String that describes the filter for the <c>dwFilterTag</c> type. If the acmFilterDetails function is successful, this
			/// string is always returned.
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = ACMFILTERDETAILS_FILTER_CHARS)]
			public string szFilter;
		}

		/// <summary>The <c>ACMFILTERTAGDETAILS</c> structure details a waveform-audio filter tag for an ACM filter driver.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/msacm/ns-msacm-acmfiltertagdetails typedef struct tACMFILTERTAGDETAILS { DWORD
		// cbStruct; DWORD dwFilterTagIndex; DWORD dwFilterTag; DWORD cbFilterSize; DWORD fdwSupport; DWORD cStandardFilters; char
		// szFilterTag[ACMFILTERTAGDETAILS_FILTERTAG_CHARS]; } ACMFILTERTAGDETAILS, *PACMFILTERTAGDETAILS, *LPACMFILTERTAGDETAILS;
		[PInvokeData("msacm.h", MSDNShortId = "NS:msacm.tACMFILTERTAGDETAILS")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct ACMFILTERTAGDETAILS
		{
			/// <summary>
			/// Size, in bytes, of the <c>ACMFILTERTAGDETAILS</c> structure. This member must be initialized before an application calls the
			/// acmFilterTagDetails or acmFilterTagEnum function. The size specified in this member must be large enough to contain the base
			/// <c>ACMFILTERTAGDETAILS</c> structure. When the <c>acmFilterTagDetails</c> function returns, this member contains the actual
			/// size of the information returned. The returned information will never exceed the requested size.
			/// </summary>
			public uint cbStruct;

			/// <summary>
			/// Index of the filter tag to retrieve details for. The index ranges from zero to one less than the number of filter tags
			/// supported by an ACM driver. The number of filter tags supported by a driver is contained in the ACMDRIVERDETAILS structure.
			/// The <c>dwFilterTagIndex</c> member is used only when querying filter tag details about a driver by index; otherwise, this
			/// member should be zero.
			/// </summary>
			public uint dwFilterTagIndex;

			/// <summary>
			/// Waveform-audio filter tag that the <c>ACMFILTERTAGDETAILS</c> structure describes. This member is used as an input for the
			/// ACM_FILTERTAGDETAILSF_FILTERTAG and ACM_FILTERTAGDETAILSF_LARGESTSIZE query flags. This member is always returned if the
			/// acmFilterTagDetails function is successful. This member should be set to WAVE_FILTER_UNKNOWN for all other query flags.
			/// </summary>
			public uint dwFilterTag;

			/// <summary>
			/// Largest total size, in bytes, of a waveform-audio filter of the <c>dwFilterTag</c> type. For example, this member will be 40
			/// for WAVE_FILTER_ECHO and 36 for WAVE_FILTER_VOLUME.
			/// </summary>
			public uint cbFilterSize;

			/// <summary>
			/// <para>
			/// Driver-support flags specific to the filter tag. These flags are identical to the ACMDRIVERDETAILS structure. This member
			/// can be a combination of the following values and identifies which operations the driver supports with the filter tag:
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Name</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>ACMDRIVERDETAILS_SUPPORTF_ASYNC</term>
			/// <term>Driver supports asynchronous conversions.</term>
			/// </item>
			/// <item>
			/// <term>ACMDRIVERDETAILS_SUPPORTF_CODEC</term>
			/// <term>
			/// Driver supports conversion between two different format tags while using the specified filter tag. For example, if a driver
			/// supports compression from WAVE_FORMAT_PCM to WAVE_FORMAT_ADPCM with the specified filter tag, this flag is set.
			/// </term>
			/// </item>
			/// <item>
			/// <term>ACMDRIVERDETAILS_SUPPORTF_CONVERTER</term>
			/// <term>
			/// Driver supports conversion between two different formats of the same format tag while using the specified filter tag. For
			/// example, if a driver supports resampling of WAVE_FORMAT_PCM with the specified filter tag, this flag is set.
			/// </term>
			/// </item>
			/// <item>
			/// <term>ACMDRIVERDETAILS_SUPPORTF_FILTER</term>
			/// <term>
			/// Driver supports a filter (modification of the data without changing any of the format attributes). For example, if a driver
			/// supports volume or echo operations on WAVE_FORMAT_PCM, this flag is set.
			/// </term>
			/// </item>
			/// <item>
			/// <term>ACMDRIVERDETAILS_SUPPORTF_HARDWARE</term>
			/// <term>
			/// Driver supports hardware input, output, or both with the specified filter tag through a waveform-audio device. An
			/// application should use the acmMetrics function with the ACM_METRIC_HARDWARE_WAVE_INPUT and ACM_METRIC_HARDWARE_WAVE_OUTPUT
			/// metric indexes to get the waveform-audio device identifiers associated with the supporting ACM driver.
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			public ACMDRIVERDETAILS_SUPPORTF fdwSupport;

			/// <summary>
			/// Number of standard filters of the <c>dwFilterTag</c> type (that is, the combination of all filter characteristics). This
			/// value cannot specify all filters supported by the driver.
			/// </summary>
			public uint cStandardFilters;

			/// <summary>
			/// String that describes the <c>dwFilterTag</c> type. This string is always returned if the acmFilterTagDetails function is successful.
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = ACMFILTERTAGDETAILS_FILTERTAG_CHARS)]
			public string szFilterTag;
		}

		/// <summary>
		/// The <c>ACMFORMATCHOOSE</c> structure contains information the ACM uses to initialize the system-defined waveform-audio format
		/// selection dialog box. After the user closes the dialog box, the system returns information about the user's selection in this structure.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/msacm/ns-msacm-acmformatchoose typedef struct tACMFORMATCHOOSE { DWORD
		// cbStruct; DWORD fdwStyle; HWND hwndOwner; LPWAVEFORMATEX pwfx; DWORD cbwfx; LPCSTR pszTitle; char
		// szFormatTag[ACMFORMATTAGDETAILS_FORMATTAG_CHARS]; char szFormat[ACMFORMATDETAILS_FORMAT_CHARS]; LPSTR pszName; DWORD cchName;
		// DWORD fdwEnum; LPWAVEFORMATEX pwfxEnum; HINSTANCE hInstance; LPCSTR pszTemplateName; LPARAM lCustData; ACMFORMATCHOOSEHOOKPROC
		// pfnHook; } ACMFORMATCHOOSE, *PACMFORMATCHOOSE, *LPACMFORMATCHOOSE;
		[PInvokeData("msacm.h", MSDNShortId = "NS:msacm.tACMFORMATCHOOSE")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct ACMFORMATCHOOSE
		{
			/// <summary>
			/// Size, in bytes, of the <c>ACMFORMATCHOOSE</c> structure. This member must be initialized before an application calls the
			/// acmFormatChoose function. The size specified in this member must be large enough to contain the base <c>ACMFORMATCHOOSE</c> structure.
			/// </summary>
			public uint cbStruct;

			/// <summary>
			/// <para>
			/// Optional style flags for the acmFormatChoose function. This member must be initialized to a valid combination of the
			/// following flags before an application calls the <c>acmFormatChoose</c> function:
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Name</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>ACMFORMATCHOOSE_STYLEF_CONTEXTHELP</term>
			/// <term>
			/// Context-sensitive help will be available in the dialog box. To use this feature, an application must register the
			/// ACMHELPMSGCONTEXTMENU and ACMHELPMSGCONTEXTHELP constants, using the RegisterWindowMessage function. When the user invokes
			/// help, the registered message will be posted to the owning window. The message will contain the wParam and lParam parameters
			/// from the original WM_CONTEXTMENU or WM_CONTEXTHELP message.
			/// </term>
			/// </item>
			/// <item>
			/// <term>ACMFORMATCHOOSE_STYLEF_ENABLEHOOK</term>
			/// <term>
			/// Enables the hook function pointed to by the pfnHook member. An application can use hook functions for a variety of
			/// customizations, including answering the MM_ACM_FORMATCHOOSE message.
			/// </term>
			/// </item>
			/// <item>
			/// <term>ACMFORMATCHOOSE_STYLEF_ENABLETEMPLATE</term>
			/// <term>Causes the ACM to create the dialog box template identified by hInstance and pszTemplateName.</term>
			/// </item>
			/// <item>
			/// <term>ACMFORMATCHOOSE_STYLEF_ENABLETEMPLATEHANDLE</term>
			/// <term>
			/// The hInstance member identifies a data block that contains a preloaded dialog box template. If this flag is specified, the
			/// ACM ignores the pszTemplateName member.
			/// </term>
			/// </item>
			/// <item>
			/// <term>ACMFORMATCHOOSE_STYLEF_INITTOWFXSTRUCT</term>
			/// <term>
			/// The buffer pointed to by pwfx contains a valid WAVEFORMATEX structure that the dialog box will use as the initial selection.
			/// </term>
			/// </item>
			/// <item>
			/// <term>ACMFORMATCHOOSE_STYLEF_SHOWHELP</term>
			/// <term>
			/// A help button will appear in the dialog box. To use a custom Help file, an application must register the ACMHELPMSGSTRING
			/// constant with the RegisterWindowMessage function. When the user presses the help button, the registered message will be
			/// posted to the owner.
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			public ACMFORMATCHOOSE_STYLEF fdwStyle;

			/// <summary>
			/// Handle to the window that owns the dialog box. This member can be any valid window handle, or <c>NULL</c> if the dialog box
			/// has no owner. This member must be initialized before calling the acmFormatChoose function.
			/// </summary>
			public HWND hwndOwner;

			/// <summary>
			/// Pointer to a WAVEFORMATEX structure. If the ACMFORMATCHOOSE_STYLEF_INITTOWFXSTRUCT flag is specified in the <c>fdwStyle</c>
			/// member, this structure must be initialized to a valid format. When the acmFormatChoose function returns, this buffer
			/// contains the selected format. If the user cancels the dialog box, no changes will be made to this buffer.
			/// </summary>
			public IntPtr pwfx;

			/// <summary>
			/// Size, in bytes, of the buffer pointed to by <c>pwfx</c>. If the buffer is too small to contain the format information, the
			/// acmFormatChoose function returns ACMERR_NOTPOSSIBLE. Also, the ACM copies the required size into this member. An application
			/// can use the acmMetrics and acmFormatTagDetails functions to determine the largest size required for this buffer.
			/// </summary>
			public uint cbwfx;

			/// <summary>
			/// Pointer to a string to be placed in the title bar of the dialog box. If this member is <c>NULL</c>, the ACM uses the default
			/// title (that is, "Sound Selection").
			/// </summary>
			[MarshalAs(UnmanagedType.LPTStr)]
			public string pszTitle;

			/// <summary>
			/// Buffer containing a null-terminated string describing the format tag of the format selection when the ACMFORMATTAGDETAILS
			/// structure returned by the acmFormatTagDetails function. If the user cancels the dialog box, this member will contain a
			/// null-terminated string.
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = ACMFORMATTAGDETAILS_FORMATTAG_CHARS)]
			public string szFormatTag;

			/// <summary>
			/// Buffer containing a null-terminated string describing the format attributes of the format selection when the
			/// ACMFORMATDETAILS structure returned by the acmFormatDetails function. If the user cancels the dialog box, this member will
			/// contain a null-terminated string.
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = ACMFORMATDETAILS_FORMAT_CHARS)]
			public string szFormat;

			/// <summary>
			/// Pointer to a string for a user-defined format name. If this is a non-null-terminated string, the ACM will attempt to match
			/// the name with a previously saved user-defined format name. If a match is found, the dialog box is initialized to that
			/// format. If a match is not found or this member is a null-terminated string, this member is ignored on input. When the
			/// acmFormatChoose function returns, this buffer contains a null-terminated string describing the user-defined format. If the
			/// format name is untitled (that is, the user has not given a name for the format), this member will be a null-terminated
			/// string on return. If the user cancels the dialog box, no changes will be made to this buffer.
			/// </summary>
			[MarshalAs(UnmanagedType.LPTStr)]
			public string pszName;

			/// <summary>
			/// Size, in characters, of the buffer identified by the <c>pszName</c> member. This buffer should be at least 128 characters
			/// long. If the <c>pszName</c> member is <c>NULL</c>, this member is ignored.
			/// </summary>
			public uint cchName;

			/// <summary>
			/// <para>
			/// Optional flags for restricting the type of formats listed in the dialog box. These flags are identical to the fdwEnum flags
			/// for the acmFormatEnum function. If <c>pwfxEnum</c> is <c>NULL</c>, this member should be zero. The following values are defined:
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Name</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>ACM_FORMATENUMF_CONVERT</term>
			/// <term>
			/// The WAVEFORMATEX structure pointed to by the pwfxEnum member is valid. The enumerator will enumerate only destination
			/// formats that can be converted from the given pwfxEnum format.
			/// </term>
			/// </item>
			/// <item>
			/// <term>ACM_FORMATENUMF_HARDWARE</term>
			/// <term>
			/// The enumerator should enumerate only formats that are supported in hardware by one or more of the installed waveform-audio
			/// devices. This flag provides a way for an application to choose only formats native to an installed waveform-audio device.
			/// </term>
			/// </item>
			/// <item>
			/// <term>ACM_FORMATENUMF_INPUT</term>
			/// <term>The enumerator should enumerate only formats that are supported for input (recording).</term>
			/// </item>
			/// <item>
			/// <term>ACM_FORMATENUMF_NCHANNELS</term>
			/// <term>
			/// The nChannels member of the WAVEFORMATEX structure pointed to by the pwfxEnum member is valid. The enumerator will enumerate
			/// only a format that conforms to this attribute.
			/// </term>
			/// </item>
			/// <item>
			/// <term>ACM_FORMATENUMF_NSAMPLESPERSEC</term>
			/// <term>
			/// The nSamplesPerSec member of the WAVEFORMATEX structure pointed to by the pwfxEnum member is valid. The enumerator will
			/// enumerate only a format that conforms to this attribute.
			/// </term>
			/// </item>
			/// <item>
			/// <term>ACM_FORMATENUMF_OUTPUT</term>
			/// <term>The enumerator should enumerate only formats that are supported for output (playback).</term>
			/// </item>
			/// <item>
			/// <term>ACM_FORMATENUMF_SUGGEST</term>
			/// <term>
			/// The WAVEFORMATEX structure pointed to by the pwfxEnum member is valid. The enumerator will enumerate all suggested
			/// destination formats for the given pwfxEnum format.
			/// </term>
			/// </item>
			/// <item>
			/// <term>ACM_FORMATENUMF_WBITSPERSAMPLE</term>
			/// <term>
			/// The wBitsPerSample member of the WAVEFORMATEX structure pointed to by the pwfxEnum member is valid. The enumerator will
			/// enumerate only a format that conforms to this attribute.
			/// </term>
			/// </item>
			/// <item>
			/// <term>ACM_FORMATENUMF_WFORMATTAG</term>
			/// <term>
			/// The wFormatTag member of the WAVEFORMATEX structure pointed to by the pwfxEnum member is valid. The enumerator will
			/// enumerate only a format that conforms to this attribute.
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			public ACM_FORMATENUMF fdwEnum;

			/// <summary>
			/// Pointer to a <c>WAVEFORMATEX</c> structure that will be used to restrict the formats listed in the dialog box. The
			/// <c>fdwEnum</c> member defines the members of the structure pointed to by <c>pwfxEnum</c> that should be used for the
			/// enumeration restrictions. If no special restrictions are desired, this member can be <c>NULL</c>. For other requirements
			/// associated with the <c>pwfxEnum</c> member, see the description for the acmFormatEnum function.
			/// </summary>
			public IntPtr pwfxEnum;

			/// <summary>
			/// Handle to a data block that contains a dialog box template specified by the <c>pszTemplateName</c> member. This member is
			/// used only if the <c>fdwStyle</c> member specifies the ACMFORMATCHOOSE_STYLEF_ENABLETEMPLATE or
			/// ACMFORMATCHOOSE_STYLEF_ENABLETEMPLATEHANDLE flag; otherwise, this member should be <c>NULL</c> on input.
			/// </summary>
			public HINSTANCE hInstance;

			/// <summary>
			/// Pointer to a null-terminated string that specifies the name of the resource file for the dialog box template that is to be
			/// substituted for the dialog box template in the ACM. An application can use the MAKEINTRESOURCE macro for numbered dialog box
			/// resources. This member is used only if the <c>fdwStyle</c> member specifies the ACMFORMATCHOOSE_STYLEF_ENABLETEMPLATE flag;
			/// otherwise, this member should be <c>NULL</c> on input.
			/// </summary>
			[MarshalAs(UnmanagedType.LPTStr)]
			public string pszTemplateName;

			/// <summary>
			/// Application-defined data that the ACM passes to the hook function identified by the <c>pfnHook</c> member. The system passes
			/// the data in the lParam parameter of the WM_INITDIALOG message.
			/// </summary>
			public IntPtr lCustData;

			/// <summary>
			/// Pointer to a callback function that processes messages intended for the dialog box. An application must specify the
			/// ACMFORMATCHOOSE_STYLEF_ENABLEHOOK flag in the <c>fdwStyle</c> member to enable the hook; otherwise, this member should be
			/// <c>NULL</c>. The hook function should return <c>FALSE</c> to pass a message to the standard dialog box procedure or
			/// <c>TRUE</c> to discard the message. The callback function type is acmFormatChooseHookProc.
			/// </summary>
			public ACMFORMATCHOOSEHOOKPROC pfnHook;
		}

		/// <summary>The <c>ACMFORMATDETAILS</c> structure details a waveform-audio format for a specific format tag for an ACM driver.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/msacm/ns-msacm-acmformatdetails typedef struct tACMFORMATDETAILS { DWORD
		// cbStruct; DWORD dwFormatIndex; DWORD dwFormatTag; DWORD fdwSupport; LPWAVEFORMATEX pwfx; DWORD cbwfx; char
		// szFormat[ACMFORMATDETAILS_FORMAT_CHARS]; } ACMFORMATDETAILS, *PACMFORMATDETAILS, *LPACMFORMATDETAILS;
		[PInvokeData("msacm.h", MSDNShortId = "NS:msacm.tACMFORMATDETAILS")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct ACMFORMATDETAILS
		{
			/// <summary>
			/// Size, in bytes, of the <c>ACMFORMATDETAILS</c> structure. This member must be initialized before an application calls the
			/// acmFormatDetails or acmFormatEnum function. The size specified by this member must be large enough to contain the base
			/// <c>ACMFORMATDETAILS</c> structure. When the <c>acmFormatDetails</c> function returns, this member contains the actual size
			/// of the information returned. The returned information will never exceed the requested size.
			/// </summary>
			public uint cbStruct;

			/// <summary>
			/// Index of the format to retrieve details for. The index ranges from zero to one less than the number of standard formats
			/// supported by an ACM driver for a format tag. The number of standard formats supported by a driver for a format tag is
			/// contained in the ACMFORMATTAGDETAILS structure. The <c>dwFormatIndex</c> member is used only when an application queries
			/// standard format details about a driver by index; otherwise, this member should be zero. Also, this member will be set to
			/// zero by the ACM when an application queries for details on a format; in other words, this member is used only for input and
			/// is never returned by the ACM or an ACM driver.
			/// </summary>
			public uint dwFormatIndex;

			/// <summary>
			/// Waveform-audio format tag that the <c>ACMFORMATDETAILS</c> structure describes. This member is used for input for the
			/// ACM_FORMATDETAILSF_INDEX query flag. For the ACM_FORMATDETAILSF_FORMAT query flag, this member must be initialized to the
			/// same format tag as the <c>pwfx</c> member specifies. If a call to the acmFormatDetails function is successful, this member
			/// is always returned. This member should be set to WAVE_FORMAT_UNKNOWN for all other query flags.
			/// </summary>
			public uint dwFormatTag;

			/// <summary>
			/// <para>
			/// Driver-support flags specific to the specified format. These flags are identical to the ACMDRIVERDETAILS structure. This
			/// member can be a combination of the following values and indicates which operations the driver supports for the format tag:
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Name</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>ACMDRIVERDETAILS_SUPPORTF_ASYNC</term>
			/// <term>Driver supports asynchronous conversions with the specified format tag.</term>
			/// </item>
			/// <item>
			/// <term>ACMDRIVERDETAILS_SUPPORTF_CODEC</term>
			/// <term>
			/// Driver supports conversion between two different format tags for the specified format. For example, if a driver supports
			/// compression from WAVE_FORMAT_PCM to WAVE_FORMAT_ADPCM with the specified format, this flag is set.
			/// </term>
			/// </item>
			/// <item>
			/// <term>ACMDRIVERDETAILS_SUPPORTF_CONVERTER</term>
			/// <term>
			/// Driver supports conversion between two different formats of the same format tag while using the specified format. For
			/// example, if a driver supports resampling of WAVE_FORMAT_PCM to the specified format, this flag is set.
			/// </term>
			/// </item>
			/// <item>
			/// <term>ACMDRIVERDETAILS_SUPPORTF_FILTER</term>
			/// <term>
			/// Driver supports a filter (which modifies data without changing any format attributes) with the specified format. For
			/// example, if a driver supports volume or echo operations on WAVE_FORMAT_PCM, this flag is set.
			/// </term>
			/// </item>
			/// <item>
			/// <term>ACMDRIVERDETAILS_SUPPORTF_HARDWARE</term>
			/// <term>
			/// Driver supports hardware input and/or output of the specified format through a waveform-audio device. An application should
			/// use acmMetrics with the ACM_METRIC_HARDWARE_WAVE_INPUT and ACM_METRIC_HARDWARE_WAVE_OUTPUT metric indexes to get the
			/// waveform-audio device identifiers associated with the supporting ACM driver.
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			public ACMDRIVERDETAILS_SUPPORTF fdwSupport;

			/// <summary>
			/// Pointer to a WAVEFORMATEX structure that will receive the format details. This structure requires no initialization by the
			/// application unless the ACM_FORMATDETAILSF_FORMAT flag is specified in the acmFormatDetails function. In this case, the
			/// <c>wFormatTag</c> member of the <c>WAVEFORMATEX</c> structure must be equal to the <c>dwFormatTag</c> of the
			/// <c>ACMFORMATDETAILS</c> structure.
			/// </summary>
			public IntPtr pwfx;

			/// <summary>
			/// Size, in bytes, available for <c>pwfx</c> to receive the format details. The acmMetrics and acmFormatTagDetails functions
			/// can be used to determine the maximum size required for any format available for the specified driver (or for all installed
			/// ACM drivers).
			/// </summary>
			public uint cbwfx;

			/// <summary>
			/// String that describes the format for the <c>dwFormatTag</c> type. If the acmFormatDetails function is successful, this
			/// string is always returned.
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = ACMFORMATDETAILS_FORMAT_CHARS)]
			public string szFormat;
		}

		/// <summary>The <c>ACMFORMATTAGDETAILS</c> structure details a waveform-audio format tag for an ACM driver.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/msacm/ns-msacm-acmformattagdetails typedef struct tACMFORMATTAGDETAILS { DWORD
		// cbStruct; DWORD dwFormatTagIndex; DWORD dwFormatTag; DWORD cbFormatSize; DWORD fdwSupport; DWORD cStandardFormats; char
		// szFormatTag[ACMFORMATTAGDETAILS_FORMATTAG_CHARS]; } ACMFORMATTAGDETAILS, *PACMFORMATTAGDETAILS, *LPACMFORMATTAGDETAILS;
		[PInvokeData("msacm.h", MSDNShortId = "NS:msacm.tACMFORMATTAGDETAILS")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct ACMFORMATTAGDETAILS
		{
			/// <summary>
			/// Size, in bytes, of the <c>ACMFORMATTAGDETAILS</c> structure. This member must be initialized before an application calls the
			/// acmFormatTagDetails or acmFormatTagEnum function. The size specified by this member must be large enough to contain the base
			/// <c>ACMFORMATTAGDETAILS</c> structure. When the <c>acmFormatTagDetails</c> function returns, this member contains the actual
			/// size of the information returned. The returned information will never exceed the requested size.
			/// </summary>
			public uint cbStruct;

			/// <summary>
			/// Index of the format tag for which details will be retrieved. The index ranges from zero to one less than the number of
			/// format tags supported by an ACM driver. The number of format tags supported by a driver is contained in the ACMDRIVERDETAILS
			/// structure. The <c>dwFormatTagIndex</c> member is used only when querying format tag details on a driver by index; otherwise,
			/// this member should be zero.
			/// </summary>
			public uint dwFormatTagIndex;

			/// <summary>
			/// Waveform-audio format tag that the <c>ACMFORMATTAGDETAILS</c> structure describes. This member is used for input for the
			/// ACM_FORMATTAGDETAILSF_FORMATTAG and ACM_FORMATTAGDETAILSF_LARGESTSIZE query flags. If the acmFormatTagDetails function is
			/// successful, this member is always returned. This member should be set to WAVE_FORMAT_UNKNOWN for all other query flags.
			/// </summary>
			public uint dwFormatTag;

			/// <summary>
			/// Largest total size, in bytes, of a waveform-audio format of the <c>dwFormatTag</c> type. For example, this member will be 16
			/// for WAVE_FORMAT_PCM and 50 for WAVE_FORMAT_ADPCM.
			/// </summary>
			public uint cbFormatSize;

			/// <summary>
			/// <para>
			/// Driver-support flags specific to the format tag. These flags are identical to the ACMDRIVERDETAILS structure. This member
			/// may be some combination of the following values and refer to what operations the driver supports with the format tag:
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Name</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>ACMDRIVERDETAILS_SUPPORTF_ASYNC</term>
			/// <term>Driver supports asynchronous conversions with the specified format tag.</term>
			/// </item>
			/// <item>
			/// <term>ACMDRIVERDETAILS_SUPPORTF_CODEC</term>
			/// <term>
			/// Driver supports conversion between two different format tags where one of the tags is the specified format tag. For example,
			/// if a driver supports compression from WAVE_FORMAT_PCM to WAVE_FORMAT_ADPCM, this flag is set.
			/// </term>
			/// </item>
			/// <item>
			/// <term>ACMDRIVERDETAILS_SUPPORTF_CONVERTER</term>
			/// <term>
			/// Driver supports conversion between two different formats of the specified format tag. For example, if a driver supports
			/// resampling of WAVE_FORMAT_PCM, this flag is set.
			/// </term>
			/// </item>
			/// <item>
			/// <term>ACMDRIVERDETAILS_SUPPORTF_FILTER</term>
			/// <term>
			/// Driver supports a filter (modification of the data without changing any of the format attributes). For example, if a driver
			/// supports volume or echo operations on the specified format tag, this flag is set.
			/// </term>
			/// </item>
			/// <item>
			/// <term>ACMDRIVERDETAILS_SUPPORTF_HARDWARE</term>
			/// <term>
			/// Driver supports hardware input, output, or both of the specified format tag through a waveform-audio device. An application
			/// should use the acmMetrics function with the ACM_METRIC_HARDWARE_WAVE_INPUT and ACM_METRIC_HARDWARE_WAVE_OUTPUT metric
			/// indexes to get the waveform-audio device identifiers associated with the supporting ACM driver.
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			public ACMDRIVERDETAILS_SUPPORTF fdwSupport;

			/// <summary>
			/// Number of standard formats of the <c>dwFormatTag</c> type; that is, the combination of all sample rates, bits per sample,
			/// channels, and so on. This value can specify all formats supported by the driver, but not necessarily.
			/// </summary>
			public uint cStandardFormats;

			/// <summary>
			/// String that describes the <c>dwFormatTag</c> type. If the acmFormatTagDetails function is successful, this string is always returned.
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = ACMFORMATTAGDETAILS_FORMATTAG_CHARS)]
			public string szFormatTag;
		}

		/// <summary>
		/// The <c>ACMSTREAMHEADER</c> structure defines the header used to identify an ACM conversion source and destination buffer pair
		/// for a conversion stream.
		/// </summary>
		/// <remarks>
		/// Before an <c>ACMSTREAMHEADER</c> structure can be used for a conversion, it must be prepared by using the acmStreamPrepareHeader
		/// function. When an application is finished with an <c>ACMSTREAMHEADER</c> structure, it must call the acmStreamUnprepareHeader
		/// function before freeing the source and destination buffers.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msacm/ns-msacm-acmstreamheader typedef struct tACMSTREAMHEADER { DWORD
		// cbStruct; DWORD fdwStatus; DWORD_PTR dwUser; LPBYTE pbSrc; DWORD cbSrcLength; DWORD cbSrcLengthUsed; DWORD_PTR dwSrcUser; LPBYTE
		// pbDst; DWORD cbDstLength; DWORD cbDstLengthUsed; DWORD_PTR dwDstUser; DWORD dwReservedDriver[_DRVRESERVED]; } ACMSTREAMHEADER,
		// *PACMSTREAMHEADER, *LPACMSTREAMHEADER;
		[PInvokeData("msacm.h", MSDNShortId = "NS:msacm.tACMSTREAMHEADER")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto, Pack = 4)]
		public struct ACMSTREAMHEADER
		{
			/// <summary>
			/// Size, in bytes, of the <c>ACMSTREAMHEADER</c> structure. This member must be initialized before the application calls any
			/// ACM stream functions using this structure. The size specified in this member must be large enough to contain the base
			/// <c>ACMSTREAMHEADER</c> structure.
			/// </summary>
			public uint cbStruct;

			/// <summary>
			/// <para>
			/// Flags giving information about the conversion buffers. This member must be initialized to zero before the application calls
			/// the acmStreamPrepareHeader function and should not be modified by the application while the stream header remains prepared.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Name</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>ACMSTREAMHEADER_STATUSF_DONE</term>
			/// <term>Set by the ACM or driver to indicate that it is finished with the conversion and is returning the buffers to the application.</term>
			/// </item>
			/// <item>
			/// <term>ACMSTREAMHEADER_STATUSF_INQUEUE</term>
			/// <term>Set by the ACM or driver to indicate that the buffers are queued for conversion.</term>
			/// </item>
			/// <item>
			/// <term>ACMSTREAMHEADER_STATUSF_PREPARED</term>
			/// <term>Set by the ACM to indicate that the buffers have been prepared by using the acmStreamPrepareHeader function.</term>
			/// </item>
			/// </list>
			/// </summary>
			public ACMSTREAMHEADER_STATUSF fdwStatus;

			/// <summary>User data. This can be any instance data specified by the application.</summary>
			public IntPtr dwUser;

			/// <summary>
			/// Pointer to the source buffer. This pointer must always refer to the same location while the stream header remains prepared.
			/// If an application needs to change the source location, it must unprepare the header and reprepare it with the alternate location.
			/// </summary>
			public IntPtr pbSrc;

			/// <summary>
			/// Length, in bytes, of the source buffer pointed to by <c>pbSrc</c>. When the header is prepared, this member must specify the
			/// maximum size that will be used in the source buffer. Conversions can be performed on source lengths less than or equal to
			/// the original prepared size. However, this member must be reset to the original size when an application unprepares the header.
			/// </summary>
			public uint cbSrcLength;

			/// <summary>
			/// Amount of data, in bytes, used for the conversion. This member is not valid until the conversion is complete. This value can
			/// be less than or equal to <c>cbSrcLength</c>. An application must use the <c>cbSrcLengthUsed</c> member when advancing to the
			/// next piece of source data for the conversion stream.
			/// </summary>
			public uint cbSrcLengthUsed;

			/// <summary>User data. This can be any instance data specified by the application.</summary>
			public IntPtr dwSrcUser;

			/// <summary>
			/// Pointer to the destination buffer. This pointer must always refer to the same location while the stream header remains
			/// prepared. If an application needs to change the destination location, it must unprepare the header and reprepare it with the
			/// alternate location.
			/// </summary>
			public IntPtr pbDst;

			/// <summary>
			/// Length, in bytes, of the destination buffer pointed to by <c>pbDst</c>. When the header is prepared, this member must
			/// specify the maximum size that will be used in the destination buffer.
			/// </summary>
			public uint cbDstLength;

			/// <summary>
			/// Amount of data, in bytes, returned by a conversion. This member is not valid until the conversion is complete. This value
			/// can be less than or equal to <c>cbDstLength</c>. An application must use the <c>cbDstLengthUsed</c> member when advancing to
			/// the next destination location for the conversion stream.
			/// </summary>
			public uint cbDstLengthUsed;

			/// <summary>User data. This can be any instance data specified by the application.</summary>
			public IntPtr dwDstUser;

			/// <summary>
			/// Reserved; do not use. This member requires no initialization by the application and should never be modified while the
			/// header remains prepared.
			/// </summary>
			// Hack to mimic uint[_DRVRESERVED] where _DRVRESERVED is 10 on 32-bit and 15 on 64-bit
			private readonly uint dwReservedDriver1;
			private readonly uint dwReservedDriver2;
			private readonly IntPtr dwReservedDriver6;
			private readonly uint dwReservedDriver3;
			private readonly uint dwReservedDriver4;
			private readonly IntPtr dwReservedDriver7;
			private readonly IntPtr dwReservedDriver8;
			private readonly IntPtr dwReservedDriver9;
			private readonly IntPtr dwReservedDriver10;
			private readonly uint dwReservedDriver5;
		}

		/// <summary>Provides a handle to an ACM driver.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct HACMDRIVER : IHandle
		{
			private readonly IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="HACMDRIVER"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public HACMDRIVER(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="HACMDRIVER"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static HACMDRIVER NULL => new(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="HACMDRIVER"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(HACMDRIVER h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HACMDRIVER"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator HACMDRIVER(IntPtr h) => new(h);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(HACMDRIVER h1, HACMDRIVER h2) => !(h1 == h2);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(HACMDRIVER h1, HACMDRIVER h2) => h1.Equals(h2);

			/// <inheritdoc/>
			public override bool Equals(object obj) => obj is HACMDRIVER h && handle == h.handle;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
		}

		/// <summary>Provides a handle to an ACM driver.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct HACMDRIVERID : IHandle
		{
			private readonly IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="HACMDRIVERID"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public HACMDRIVERID(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="HACMDRIVERID"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static HACMDRIVERID NULL => new(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="HACMDRIVERID"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(HACMDRIVERID h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HACMDRIVERID"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator HACMDRIVERID(IntPtr h) => new(h);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(HACMDRIVERID h1, HACMDRIVERID h2) => !(h1 == h2);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(HACMDRIVERID h1, HACMDRIVERID h2) => h1.Equals(h2);

			/// <inheritdoc/>
			public override bool Equals(object obj) => obj is HACMDRIVERID h && handle == h.handle;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
		}

		/// <summary>Provides a handle to an ACM object.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct HACMOBJ : IHandle
		{
			private readonly IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="HACMOBJ"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public HACMOBJ(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="HACMOBJ"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static HACMOBJ NULL => new(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="HACMOBJ"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(HACMOBJ h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HACMOBJ"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator HACMOBJ(IntPtr h) => new(h);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(HACMOBJ h1, HACMOBJ h2) => !(h1 == h2);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(HACMOBJ h1, HACMOBJ h2) => h1.Equals(h2);

			/// <inheritdoc/>
			public override bool Equals(object obj) => obj is HACMOBJ h && handle == h.handle;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
		}

		/// <summary>Provides a handle to an ACM stream.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct HACMSTREAM : IHandle
		{
			private readonly IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="HACMSTREAM"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public HACMSTREAM(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="HACMSTREAM"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static HACMSTREAM NULL => new(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="HACMSTREAM"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(HACMSTREAM h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HACMSTREAM"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator HACMSTREAM(IntPtr h) => new(h);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(HACMSTREAM h1, HACMSTREAM h2) => !(h1 == h2);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(HACMSTREAM h1, HACMSTREAM h2) => h1.Equals(h2);

			/// <inheritdoc/>
			public override bool Equals(object obj) => obj is HACMSTREAM h && handle == h.handle;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
		}

		/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="HACMDRIVER"/> that is disposed using <see cref="acmDriverClose"/>.</summary>
		public class SafeHACMDRIVER : SafeHANDLE
		{
			/// <summary>Initializes a new instance of the <see cref="SafeHACMDRIVER"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle"><see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).</param>
			public SafeHACMDRIVER(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SafeHACMDRIVER"/> class.</summary>
			private SafeHACMDRIVER() : base() { }

			/// <summary>Performs an implicit conversion from <see cref="SafeHACMDRIVER"/> to <see cref="HACMDRIVER"/>.</summary>
			/// <param name="h">The safe handle instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator HACMDRIVER(SafeHACMDRIVER h) => h.handle;

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() => acmDriverClose(handle) == MMRESULT.MMSYSERR_NOERROR;
		}

		/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="HACMSTREAM"/> that is disposed using <see cref="acmStreamClose"/>.</summary>
		public class SafeHACMSTREAM : SafeHANDLE
		{
			/// <summary>Initializes a new instance of the <see cref="SafeHACMSTREAM"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafeHACMSTREAM(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SafeHACMSTREAM"/> class.</summary>
			private SafeHACMSTREAM() : base() { }

			/// <summary>Performs an implicit conversion from <see cref="SafeHACMSTREAM"/> to <see cref="HACMSTREAM"/>.</summary>
			/// <param name="h">The safe handle instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator HACMSTREAM(SafeHACMSTREAM h) => h.handle;

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() => acmStreamClose(handle) == MMRESULT.MMSYSERR_NOERROR;
		}
	}
}