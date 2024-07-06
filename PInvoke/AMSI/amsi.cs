namespace Vanara.PInvoke;

/// <summary>Items from the AMSI.dll.</summary>
public static partial class AMSI
{
	private const string Lib_Amsi = "amsi.dll";

	/// <summary>The <c>AMSI_ATTRIBUTE</c> enumeration specifies the types of attributes that can be requested by IAmsiStream::GetAttribute.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/amsi/ne-amsi-amsi_attribute typedef enum AMSI_ATTRIBUTE {
	// AMSI_ATTRIBUTE_APP_NAME, AMSI_ATTRIBUTE_CONTENT_NAME, AMSI_ATTRIBUTE_CONTENT_SIZE, AMSI_ATTRIBUTE_CONTENT_ADDRESS,
	// AMSI_ATTRIBUTE_SESSION, AMSI_ATTRIBUTE_REDIRECT_CHAIN_SIZE, AMSI_ATTRIBUTE_REDIRECT_CHAIN_ADDRESS, AMSI_ATTRIBUTE_ALL_SIZE,
	// AMSI_ATTRIBUTE_ALL_ADDRESS, AMSI_ATTRIBUTE_QUIET } ;
	[PInvokeData("amsi.h", MSDNShortId = "NE:amsi.AMSI_ATTRIBUTE")]
	public enum AMSI_ATTRIBUTE
	{
		/// <summary>Return the name, version, or GUID string of the calling application, copied from a <c>LPWSTR</c>.</summary>
		[CorrespondingType(typeof(string))]
		AMSI_ATTRIBUTE_APP_NAME = 0,

		/// <summary>Return the filename, URL, unique script ID, or similar of the content, copied from a <c>LPWSTR</c>.</summary>
		[CorrespondingType(typeof(string))]
		AMSI_ATTRIBUTE_CONTENT_NAME,

		/// <summary>Return the size of the input, as a <c>ULONGLONG</c>.</summary>
		[CorrespondingType(typeof(ulong))]
		AMSI_ATTRIBUTE_CONTENT_SIZE,

		/// <summary>Return the memory address if the content is fully loaded into memory.</summary>
		[CorrespondingType(typeof(IntPtr))]
		AMSI_ATTRIBUTE_CONTENT_ADDRESS,

		/// <summary>
		/// Session is used to associate different scan calls, such as if the contents to be scanned belong to the sample original script.
		/// Return a <c>PVOID</c> to the next portion of the content to be scanned. Return NULL if the content is self-contained.
		/// </summary>
		[CorrespondingType(typeof(HAMSISESSION))]
		AMSI_ATTRIBUTE_SESSION,

		/// <summary/>
		AMSI_ATTRIBUTE_REDIRECT_CHAIN_SIZE,

		/// <summary/>
		AMSI_ATTRIBUTE_REDIRECT_CHAIN_ADDRESS,

		/// <summary/>
		AMSI_ATTRIBUTE_ALL_SIZE,

		/// <summary/>
		AMSI_ATTRIBUTE_ALL_ADDRESS,

		/// <summary/>
		AMSI_ATTRIBUTE_QUIET,
	}

	/// <summary>The <c>AMSI_RESULT</c> enumeration specifies the types of results returned by scans.</summary>
	/// <remarks>
	/// <para>
	/// The antimalware provider may return a result between 1 and 32767, inclusive, as an estimated risk level. The larger the result,
	/// the riskier it is to continue with the content. These values are provider specific, and may indicate a malware family or ID.
	/// </para>
	/// <para>
	/// Results within the range of <c>AMSI_RESULT_BLOCKED_BY_ADMIN_START</c> and <c>AMSI_RESULT_BLOCKED_BY_ADMIN_END</c> values
	/// (inclusive) are officially blocked by the admin specified policy. In these cases, the script in question will be blocked from
	/// executing. The range is large to accommodate future additions in functionality.
	/// </para>
	/// <para>
	/// Any return result equal to or larger than 32768 is considered malware, and the content should be blocked. An app should use
	/// AmsiResultIsMalware to determine if this is the case.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/amsi/ne-amsi-amsi_result typedef enum AMSI_RESULT { AMSI_RESULT_CLEAN,
	// AMSI_RESULT_NOT_DETECTED, AMSI_RESULT_BLOCKED_BY_ADMIN_START, AMSI_RESULT_BLOCKED_BY_ADMIN_END, AMSI_RESULT_DETECTED } ;
	[PInvokeData("amsi.h", MSDNShortId = "NE:amsi.AMSI_RESULT")]
	public enum AMSI_RESULT : uint
	{
		/// <summary>Known good. No detection found, and the result is likely not going to change after a future definition update.</summary>
		AMSI_RESULT_CLEAN = 0,

		/// <summary>No detection found, but the result might change after a future definition update.</summary>
		AMSI_RESULT_NOT_DETECTED = 1,

		/// <summary>Administrator policy blocked this content on this machine (beginning of range).</summary>
		AMSI_RESULT_BLOCKED_BY_ADMIN_START = 0x4000,

		/// <summary>Administrator policy blocked this content on this machine (end of range).</summary>
		AMSI_RESULT_BLOCKED_BY_ADMIN_END = 0x4fff,

		/// <summary>Detection found. The content is considered malware and should be blocked.</summary>
		AMSI_RESULT_DETECTED = 32768,
	}

	/// <summary>Close a session that was opened by AmsiOpenSession.</summary>
	/// <param name="amsiContext">The handle of type HAMSICONTEXT that was initially received from AmsiInitialize.</param>
	/// <param name="amsiSession">The handle of type HAMSISESSION that was initially received from AmsiOpenSession.</param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/amsi/nf-amsi-amsiclosesession void AmsiCloseSession( [in] HAMSICONTEXT
	// amsiContext, [in] HAMSISESSION amsiSession );
	[DllImport(Lib_Amsi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("amsi.h", MSDNShortId = "NF:amsi.AmsiCloseSession")]
	public static extern void AmsiCloseSession([In] HAMSICONTEXT amsiContext, [In] HAMSISESSION amsiSession);

	/// <summary>Initialize the AMSI API.</summary>
	/// <param name="appName">The name, version, or GUID string of the app calling the AMSI API.</param>
	/// <param name="amsiContext">A handle of type HAMSICONTEXT that must be passed to all subsequent calls to the AMSI API.</param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	/// <remarks>When the app is finished with the AMSI API it must call AmsiUninitialize.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/amsi/nf-amsi-amsiinitialize HRESULT AmsiInitialize( [in] LPCWSTR appName, [out]
	// HAMSICONTEXT *amsiContext );
	[DllImport(Lib_Amsi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("amsi.h", MSDNShortId = "NF:amsi.AmsiInitialize")]
	public static extern HRESULT AmsiInitialize([MarshalAs(UnmanagedType.LPWStr)] string appName, out SafeHAMSICONTEXT amsiContext);

	/// <summary>
	/// Sends to the antimalware provider a notification of an arbitrary operation. The notification doesn't imply the request of an
	/// antivirus scan. Rather, <c>IAntimalwareProvider2::Notify</c> is designed to provide a quick and lightweight mechanism to
	/// communicate to the antimalware provider that an event has taken place. In general, the antimalware provider should process the
	/// notification, and return to the caller as quickly as possible.
	/// </summary>
	/// <param name="amsiContext">
	/// <para>Type: _In_ <c>HAMSICONTEXT</c></para>
	/// <para>The handle (of type <c>HAMSICONTEXT</c>) that was initially received from AmsiInitialize.</para>
	/// </param>
	/// <param name="buffer">
	/// <para>Type: _In_reads_bytes_(length) <c>PVOID</c></para>
	/// <para>The buffer that contains the notification data.</para>
	/// </param>
	/// <param name="length">
	/// <para>Type: _In_ <c>ULONG</c></para>
	/// <para>The length, in bytes, of the data to be read from buffer.</para>
	/// </param>
	/// <param name="contentName">
	/// <para>Type: _In_opt_ <c>LPCWSTR</c></para>
	/// <para>The filename, URL, unique script ID, or similar of the content being scanned.</para>
	/// </param>
	/// <param name="result">
	/// <para>Type: _Out_ <c>AMSI_RESULT*</c></para>
	/// <para>The result of the scan.</para>
	/// <para>You should use AmsiResultIsMalware to determine whether the content should be blocked.</para>
	/// </param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/amsi/nf-amsi-amsinotifyoperation HRESULT AmsiNotifyOperation( HAMSICONTEXT
	// amsiContext, PVOID buffer, ULONG length, LPCWSTR contentName, AMSI_RESULT *result );
	[DllImport(Lib_Amsi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("amsi.h", MSDNShortId = "NF:amsi.AmsiNotifyOperation")]
	public static extern HRESULT AmsiNotifyOperation([In] HAMSICONTEXT amsiContext, [In] IntPtr buffer, [In] uint length,
		[Optional, MarshalAs(UnmanagedType.LPWStr)] string? contentName, out AMSI_RESULT result);

	/// <summary>Opens a session within which multiple scan requests can be correlated.</summary>
	/// <param name="amsiContext">The handle of type HAMSICONTEXT that was initially received from AmsiInitialize.</param>
	/// <param name="amsiSession">
	/// A handle of type HAMSISESSION that must be passed to all subsequent calls to the AMSI API within the session.
	/// </param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	/// <remarks>When the app is finished with the session it must call AmsiCloseSession.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/amsi/nf-amsi-amsiopensession HRESULT AmsiOpenSession( [in] HAMSICONTEXT
	// amsiContext, [out] HAMSISESSION *amsiSession );
	public static HRESULT AmsiOpenSession([In] HAMSICONTEXT amsiContext, out SafeHAMSISESSION amsiSession)
	{
		HRESULT hr = AmsiOpenSessionInternal(amsiContext, out HAMSISESSION h);
		amsiSession = hr.Succeeded ? new SafeHAMSISESSION((IntPtr)h, true) : new SafeHAMSISESSION(IntPtr.Zero, false);
		return hr;
	}

	/// <summary>Determines if the result of a scan indicates that the content should be blocked.</summary>
	/// <param name="r">The AMSI_RESULT returned by AmsiScanBuffer or AmsiScanString.</param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/amsi/nf-amsi-amsiresultismalware void AmsiResultIsMalware( [in] r );
	[PInvokeData("amsi.h", MSDNShortId = "NF:amsi.AmsiResultIsMalware")]
	public static bool AmsiResultIsMalware(AMSI_RESULT r) => r >= AMSI_RESULT.AMSI_RESULT_DETECTED;

	/// <summary>Scans a buffer-full of content for malware.</summary>
	/// <param name="amsiContext">The handle of type HAMSICONTEXT that was initially received from AmsiInitialize.</param>
	/// <param name="buffer">The buffer from which to read the data to be scanned.</param>
	/// <param name="length">The length, in bytes, of the data to be read from <c>buffer</c>.</param>
	/// <param name="contentName">The filename, URL, unique script ID, or similar of the content being scanned.</param>
	/// <param name="amsiSession">
	/// If multiple scan requests are to be correlated within a session, set <c>session</c> to the handle of type HAMSISESSION that was
	/// initially received from AmsiOpenSession. Otherwise, set <c>session</c> to <c>nullptr</c>.
	/// </param>
	/// <param name="result">
	/// <para>The result of the scan. See AMSI_RESULT.</para>
	/// <para>An app should use AmsiResultIsMalware to determine whether the content should be blocked.</para>
	/// </param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/amsi/nf-amsi-amsiscanbuffer HRESULT AmsiScanBuffer( [in] HAMSICONTEXT
	// amsiContext, [in] PVOID buffer, [in] ULONG length, [in] LPCWSTR contentName, [in, optional] HAMSISESSION amsiSession, [out]
	// AMSI_RESULT *result );
	[DllImport(Lib_Amsi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("amsi.h", MSDNShortId = "NF:amsi.AmsiScanBuffer")]
	public static extern HRESULT AmsiScanBuffer([In] HAMSICONTEXT amsiContext, [In] IntPtr buffer, uint length,
		[Optional, MarshalAs(UnmanagedType.LPWStr)] string? contentName, [In, Optional] HAMSISESSION amsiSession, out AMSI_RESULT result);

	/// <summary>Scans a string for malware.</summary>
	/// <param name="amsiContext">The handle of type HAMSICONTEXT that was initially received from AmsiInitialize.</param>
	/// <param name="str">The string to be scanned.</param>
	/// <param name="contentName">The filename, URL, unique script ID, or similar of the content being scanned.</param>
	/// <param name="amsiSession">
	/// If multiple scan requests are to be correlated within a session, set <c>session</c> to the handle of type HAMSISESSION that was
	/// initially received from AmsiOpenSession. Otherwise, set <c>session</c> to <c>nullptr</c>.
	/// </param>
	/// <param name="result">
	/// <para>The result of the scan. See AMSI_RESULT.</para>
	/// <para>An app should use AmsiResultIsMalware to determine whether the content should be blocked.</para>
	/// </param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/amsi/nf-amsi-amsiscanstring HRESULT AmsiScanString( [in] HAMSICONTEXT
	// amsiContext, [in] LPCWSTR string, [in] LPCWSTR contentName, [in, optional] HAMSISESSION amsiSession, [out] AMSI_RESULT *result );
	[DllImport(Lib_Amsi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("amsi.h", MSDNShortId = "NF:amsi.AmsiScanString")]
	public static extern HRESULT AmsiScanString(HAMSICONTEXT amsiContext, [MarshalAs(UnmanagedType.LPWStr)] string str,
		[Optional, MarshalAs(UnmanagedType.LPWStr)] string? contentName, [In, Optional] HAMSISESSION amsiSession, out AMSI_RESULT result);

	/// <summary>Remove the instance of the AMSI API that was originally opened by AmsiInitialize.</summary>
	/// <param name="amsiContext">The handle of type HAMSICONTEXT that was initially received from AmsiInitialize.</param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/amsi/nf-amsi-amsiuninitialize void AmsiUninitialize( [in] HAMSICONTEXT
	// amsiContext );
	[DllImport(Lib_Amsi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("amsi.h", MSDNShortId = "NF:amsi.AmsiUninitialize")]
	public static extern void AmsiUninitialize(HAMSICONTEXT amsiContext);

	[DllImport(Lib_Amsi, SetLastError = false, EntryPoint = "AmsiOpenSession")]
	private static extern HRESULT AmsiOpenSessionInternal([In] HAMSICONTEXT amsiContext, out HAMSISESSION amsiSession);

	/// <summary>Provides a handle to an AMSI context.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct HAMSICONTEXT : IHandle
	{
		private readonly IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HAMSICONTEXT"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HAMSICONTEXT(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HAMSICONTEXT"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HAMSICONTEXT NULL { get; } = default;

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="HAMSICONTEXT"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HAMSICONTEXT h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HAMSICONTEXT"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HAMSICONTEXT(IntPtr h) => new(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HAMSICONTEXT h1, HAMSICONTEXT h2) => h1.handle != h2.handle;

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HAMSICONTEXT h1, HAMSICONTEXT h2) => h1.handle == h2.handle;

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj is IHandle h && handle == h.DangerousGetHandle() || obj is IntPtr p && handle == p;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a handle to an AMSI session.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct HAMSISESSION : IHandle
	{
		private readonly IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HAMSISESSION"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HAMSISESSION(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HAMSISESSION"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HAMSISESSION NULL { get; } = default;

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="HAMSISESSION"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HAMSISESSION h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HAMSISESSION"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HAMSISESSION(IntPtr h) => new(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HAMSISESSION h1, HAMSISESSION h2) => h1.handle != h2.handle;

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HAMSISESSION h1, HAMSISESSION h2) => h1.handle == h2.handle;

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj is IHandle h && handle == h.DangerousGetHandle() || obj is IntPtr p && handle == p;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="HAMSICONTEXT"/> that is disposed using <see cref="AmsiUninitialize"/>.</summary>
	public class SafeHAMSICONTEXT : SafeHANDLE
	{
		/// <summary>Initializes a new instance of the <see cref="SafeHAMSICONTEXT"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		public SafeHAMSICONTEXT(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Initializes a new instance of the <see cref="SafeHAMSICONTEXT"/> class.</summary>
		private SafeHAMSICONTEXT() : base() { }

		/// <summary>Performs an implicit conversion from <see cref="SafeHAMSICONTEXT"/> to <see cref="HAMSICONTEXT"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HAMSICONTEXT(SafeHAMSICONTEXT h) => h.handle;

		/// <summary>Represents a NULL handle.</summary>
		public static readonly SafeHAMSICONTEXT Null = new(IntPtr.Zero, false);

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() { AmsiUninitialize(handle); return true; }
	}

	/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="HAMSISESSION"/> that is disposed using <see cref="AmsiCloseSession"/>.</summary>
	public class SafeHAMSISESSION : SafeHANDLE
	{
		private SafeHAMSICONTEXT ctx;

		/// <summary>Initializes a new instance of the <see cref="SafeHAMSISESSION"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		public SafeHAMSISESSION(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) => ctx = SafeHAMSICONTEXT.Null;

		/// <summary>Initializes a new instance of the <see cref="SafeHAMSISESSION"/> class.</summary>
		/// <param name="context">The context.</param>
		public SafeHAMSISESSION(HAMSICONTEXT context) : base() => Open(ctx = new(context.DangerousGetHandle(), false));

		/// <summary>Initializes a new instance of the <see cref="SafeHAMSISESSION"/> class.</summary>
		/// <param name="appName">The name, version, or GUID string of the app calling the AMSI API.</param>
		public SafeHAMSISESSION(string appName) : base()
		{
			AmsiInitialize(appName, out SafeHAMSICONTEXT hc).ThrowIfFailed();
			Open(ctx = hc);
		}

		/// <summary>Initializes a new instance of the <see cref="SafeHAMSISESSION"/> class.</summary>
		private SafeHAMSISESSION() : base() => ctx = SafeHAMSICONTEXT.Null;

		/// <summary>Gets or sets the handle of type HAMSICONTEXT that was initially received from AmsiInitialize.</summary>
		/// <value>The context handle.</value>
		public HAMSICONTEXT Context { get => ctx; set => ctx = new SafeHAMSICONTEXT((IntPtr)value, false); }

		/// <summary>Performs an implicit conversion from <see cref="SafeHAMSISESSION"/> to <see cref="HAMSISESSION"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HAMSISESSION(SafeHAMSISESSION h) => h.handle;

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() { AmsiCloseSession(Context, handle); ctx?.Dispose(); return true; }

		private void Open(HAMSICONTEXT context)
		{
			AmsiOpenSessionInternal(context, out HAMSISESSION h).ThrowIfFailed();
			SetHandle((IntPtr)h);
		}
	}
}