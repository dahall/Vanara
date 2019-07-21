using System;
using System.Runtime.InteropServices;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke
{
	public static partial class Wer
	{
		/// <summary>Closes the specified report.</summary>
		/// <param name="hReportHandle">A handle to the report. This handle is returned by the WerReportCreate function.</param>
		/// <returns>This function returns <c>S_OK</c> on success or an error code on failure.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/werapi/nf-werapi-werreportclosehandle HRESULT WerReportCloseHandle( HREPORT
		// hReportHandle );
		[DllImport(Lib.Wer, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("werapi.h", MSDNShortId = "b7326003-cd25-4988-9ed4-31c2e030beec")]
		public static extern HRESULT WerReportCloseHandle(HREPORT hReportHandle);

		/// <summary>Creates a problem report that describes an application event.</summary>
		/// <param name="pwzEventType">A pointer to a Unicode string that specifies the name of the event.</param>
		/// <param name="repType">
		/// <para>The type of report. This parameter can be one of the following values from the <c>WER_REPORT_TYPE</c> enumeration type.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WerReportApplicationCrash 2</term>
		/// <term>An error that has caused the application to stop running has occurred.</term>
		/// </item>
		/// <item>
		/// <term>WerReportApplicationHang 3</term>
		/// <term>An error that has caused the application to stop responding has occurred.</term>
		/// </item>
		/// <item>
		/// <term>WerReportInvalid 5</term>
		/// <term>An error that has called out a return that is not valid has occurred.</term>
		/// </item>
		/// <item>
		/// <term>WerReportKernel 4</term>
		/// <term>An error in the kernel has occurred.</term>
		/// </item>
		/// <item>
		/// <term>WerReportCritical 1</term>
		/// <term>
		/// A critical error, such as a crash or non-response, has occurred. By default, processes that experience a critical error are
		/// terminated or restarted.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WerReportNonCritical 0</term>
		/// <term>
		/// An error that is not critical has occurred. This type of report shows no UI; the report is silently queued. It may then be sent
		/// silently to the server in the background if adequate user consent is available.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pReportInformation">A pointer to a WER_REPORT_INFORMATION structure that specifies information for the report.</param>
		/// <param name="phReportHandle">A handle to the report. If the function fails, this handle is <c>NULL</c>.</param>
		/// <returns>This function returns <c>S_OK</c> on success or an error code on failure.</returns>
		/// <remarks>
		/// <para>Use the following functions to specify additional information to be submitted:</para>
		/// <para>
		/// WerReportAddDump WerReportAddFile WerReportSetParameter To submit the information, call the WerReportSubmit function. When you
		/// have finished with the report handle, call the WerReportCloseHandle function.
		/// </para>
		/// <para>
		/// Applications can also indicate that they would like the opportunity to recover data or restart on failure. For more information,
		/// see Application Recovery and Restart.
		/// </para>
		/// <para>To view the reports submitted by your application, go to Windows Quality Online Services.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/werapi/nf-werapi-werreportcreate HRESULT WerReportCreate( PCWSTR pwzEventType,
		// WER_REPORT_TYPE repType, PWER_REPORT_INFORMATION pReportInformation, HREPORT *phReportHandle );
		[DllImport(Lib.Wer, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("werapi.h", MSDNShortId = "41f68dde-5e43-45a6-8e0b-3ae0c6180e8b")]
		public static extern HRESULT WerReportCreate(string pwzEventType, WER_REPORT_TYPE repType, in WER_REPORT_INFORMATION pReportInformation, out SafeHREPORT phReportHandle);

		/// <summary>Provides a handle to a problem report.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct HREPORT : IHandle
		{
			private IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="HREPORT"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public HREPORT(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="HREPORT"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static HREPORT NULL => new HREPORT(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="HREPORT"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(HREPORT h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HREPORT"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator HREPORT(IntPtr h) => new HREPORT(h);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(HREPORT h1, HREPORT h2) => !(h1 == h2);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(HREPORT h1, HREPORT h2) => h1.Equals(h2);

			/// <inheritdoc/>
			public override bool Equals(object obj) => obj is HREPORT h ? handle == h.handle : false;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
		}

		/// <summary>Contains information used by the WerReportCreate function.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/werapi/ns-werapi-wer_report_information typedef struct _WER_REPORT_INFORMATION
		// { DWORD dwSize; HANDLE hProcess; WCHAR wzConsentKey[64]; WCHAR wzFriendlyEventName[128]; WCHAR wzApplicationName[128]; WCHAR
		// wzApplicationPath[MAX_PATH]; WCHAR wzDescription[512]; HWND hwndParent; } WER_REPORT_INFORMATION, *PWER_REPORT_INFORMATION;
		[PInvokeData("werapi.h", MSDNShortId = "3efe2b43-53ac-48e3-bc39-4a9fe6041fca")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct WER_REPORT_INFORMATION
		{
			/// <summary>The size of this structure, in bytes.</summary>
			public uint dwSize;

			/// <summary>
			/// A handle to the process for which the report is being generated. If this member is <c>NULL</c>, this is the calling process.
			/// </summary>
			public HPROCESS hProcess;

			/// <summary>
			/// The name used to look up consent settings. If this member is empty, the default is the name specified by the pwzEventType
			/// parameter of WerReportCreate.
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
			public string wzConsentKey;

			/// <summary>The display name. If this member is empty, the default is the name specified by pwzEventType parameter of WerReportCreate.</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
			public string wzFriendlyEventName;

			/// <summary>The name of the application. If this parameter is empty, the default is the base name of the image file.</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
			public string wzApplicationName;

			/// <summary>The full path to the application.</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
			public string wzApplicationPath;

			/// <summary>
			/// A description of the problem. This description is displayed in <c>Problem Reports and Solutions</c> on Windows Vista or the
			/// problem reports pane of the <c>Action Center</c> on Windows 7.
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
			public string wzDescription;

			/// <summary>A handle to the parent window.</summary>
			public HWND hwndParent;

			/// <summary>A default instance with the size field set.</summary>
			public static readonly WER_REPORT_INFORMATION Default = new WER_REPORT_INFORMATION { dwSize = (uint)Marshal.SizeOf(typeof(WER_REPORT_INFORMATION)) };
		}

		/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="HREPORT"/> that is disposed using <see cref="WerReportClose"/>.</summary>
		public class SafeHREPORT : SafeHANDLE
		{
			/// <summary>Initializes a new instance of the <see cref="SafeHREPORT"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafeHREPORT(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SafeHREPORT"/> class.</summary>
			private SafeHREPORT() : base() { }

			/// <summary>Performs an implicit conversion from <see cref="SafeHREPORT"/> to <see cref="HREPORT"/>.</summary>
			/// <param name="h">The safe handle instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator HREPORT(SafeHREPORT h) => h.handle;

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() => WerReportCloseHandle(handle).Succeeded;
		}

		/*
		RegisterWaitChainCOMCallback https://docs.microsoft.com/en-us/windows/win32/api/wct/nf-wct-registerwaitchaincomcallback
		GetThreadWaitChain https://docs.microsoft.com/en-us/windows/win32/api/wct/nf-wct-getthreadwaitchain
		CloseThreadWaitChainSession https://docs.microsoft.com/en-us/windows/win32/api/wct/nf-wct-closethreadwaitchainsession
		OpenThreadWaitChainSession https://docs.microsoft.com/en-us/windows/win32/api/wct/nf-wct-openthreadwaitchainsession
		WerAddExcludedApplication https://docs.microsoft.com/en-us/windows/win32/api/werapi/nf-werapi-weraddexcludedapplication
		WerFreeString https://docs.microsoft.com/en-us/windows/desktop/api/werapi/nf-werapi-werfreestring
		WerReportAddDump https://docs.microsoft.com/en-us/windows/desktop/api/werapi/nf-werapi-werreportadddump
		WerStoreGetFirstReportKey https://docs.microsoft.com/en-us/windows/desktop/api/werapi/nf-werapi-werstoregetfirstreportkey
		WerReportSubmit https://docs.microsoft.com/en-us/windows/desktop/api/werapi/nf-werapi-werreportsubmit
		WerStoreOpen https://docs.microsoft.com/en-us/windows/win32/api/werapi/nf-werapi-werstoreopen
		WerStoreGetNextReportKey https://docs.microsoft.com/en-us/windows/desktop/api/werapi/nf-werapi-werstoregetnextreportkey
		WerStoreQueryReportMetadataV2 https://docs.microsoft.com/en-us/windows/desktop/api/werapi/nf-werapi-werstorequeryreportmetadatav2
		WerReportSetParameter https://docs.microsoft.com/en-us/windows/desktop/api/werapi/nf-werapi-werreportsetparameter
		WerReportSetUIOption https://docs.microsoft.com/en-us/windows/desktop/api/werapi/nf-werapi-werreportsetuioption
		WerReportAddFile https://docs.microsoft.com/en-us/windows/desktop/api/werapi/nf-werapi-werreportaddfile
		WerRemoveExcludedApplication https://docs.microsoft.com/en-us/windows/win32/api/werapi/nf-werapi-werremoveexcludedapplication
		WerStoreClose https://docs.microsoft.com/en-us/windows/win32/api/werapi/nf-werapi-werstoreclose
		*/
	}
}