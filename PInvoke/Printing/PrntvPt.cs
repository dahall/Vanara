using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	/// <summary>Functions and structures from prntvpt.h.</summary>
	public static partial class PrntvPt
	{
		/// <summary>
		/// <para>
		/// [This function is not supported and might be disabled or deleted in future versions of Windows. <c>PTOpenProviderEx</c> provides
		/// equivalent functionality and should be used instead.]
		/// </para>
		/// <para>Opens an instance of a print ticket provider.</para>
		/// </summary>
		/// <param name="pszPrinterName">The full name of a print queue.</param>
		/// <param name="maxVersion">The latest version of the Print Schema that the caller supports.</param>
		/// <param name="prefVersion">The version of the Print Schema requested by the caller.</param>
		/// <param name="phProvider">A pointer to a handle to the print ticket provider.</param>
		/// <param name="usedVersion">The version of the Print Schema that the print ticket provider will use.</param>
		/// <returns>
		/// If the method succeeds, it returns <c>S_OK</c>; otherwise, it returns an <c>HRESULT</c> error code. For more information about
		/// COM error codes, see Error Handling.
		/// </returns>
		/// <remarks>Before calling this function, the calling thread must initialize COM by calling <c>CoInitializeEx</c>.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/printdocs/bindptproviderthunk HRESULT BindPTProviderThunk( _In_ LPTSTR
		// pszPrinterName, _In_ INT maxVersion, _In_ INT prefVersion, _Out_ HPTPROVIDER *phProvider, _Out_ INT *usedVersion );
		[DllImport(Lib.PrntvPt, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("", MSDNShortId = "815cc360-8dcd-4c58-a64d-5d77436a8623")]
		public static extern HRESULT BindPTProviderThunk(string pszPrinterName, int maxVersion, int prefVersion, out SafeHPTPROVIDER phProvider, out int usedVersion);

		/// <summary>
		/// <para>[This function is not supported and might be disabled or deleted in future versions of Windows. <c>PTGetPrintCapabilities</c> provides equivalent functionality and should be used instead.]</para>
		/// <para>Retrieves the printer's capabilities formatted in compliance with the XML Print Schema.</para>
		/// </summary>
		/// <param name="hProvider">A handle to an open print ticket provider. This handle is returned by the <c>BindPTProviderThunk</c> function.</param>
		/// <param name="pPrintTicket">The buffer that contains the print ticket data, expressed in XML as described in the Print Schema.</param>
		/// <param name="cbPrintTicket">The size, in bytes, of the buffer referenced by pPrintTicket.</param>
		/// <param name="ppbPrintCapabilities">The address of the buffer that is allocated by this function and contains the valid print capabilities information, encoded as XML. This function calls <c>CoTaskMemAlloc</c> to allocate this buffer. When the buffer is no longer needed, the caller must free it by calling <c>CoTaskMemFree</c>.</param>
		/// <param name="pcbPrintCapabilitiesLength">The size, in bytes, of the buffer referenced by ppbPrintCapabilities.</param>
		/// <param name="pbstrErrorMessage">A pointer to a string that specifies what, if anything, is invalid about pPrintTicket. If it is valid, this value is <c>NULL</c>. If pbstrErrorMessage is not <c>NULL</c> when the function returns, the caller must free the string with <c>SysFreeString</c>.</param>
		/// <returns>If the method succeeds, it returns <c>S_OK</c>; otherwise, it returns an <c>HRESULT</c> error code. For more information about COM error codes, see Error Handling.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/printdocs/getprintcapabilitiesthunk2
		// HRESULT GetPrintCapabilitiesThunk2( _In_ HPTPROVIDER hProvider, _In_ BYTE *pPrintTicket, _In_ INT cbPrintTicket, _Out_ BYTE **ppbPrintCapabilities, _Out_ INT *pcbPrintCapabilitiesLength, _Out_opt_ BSTR *pbstrErrorMessage );
		[DllImport(Lib.PrntvPt, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winspool.h", MSDNShortId = "15219c19-b64c-4c51-9357-15a797557693")]
		public static extern HRESULT GetPrintCapabilitiesThunk2(HPTPROVIDER hProvider, [In] IntPtr pPrintTicket, int cbPrintTicket, out IntPtr ppbPrintCapabilities, out int pcbPrintCapabilitiesLength, [MarshalAs(UnmanagedType.BStr)] out string pbstrErrorMessage);

		/// <summary>Closes a print ticket provider handle.</summary>
		/// <param name="hProvider">A handle to the provider. This handle is returned by the PTOpenProvider or PTOpenProviderEx function.</param>
		/// <returns>
		/// <para>If the operation succeeds, the return value is S_OK, otherwise the <c>HRESULT</c> contains an error code.</para>
		/// <para>If hProvider was opened in a different thread, the <c>HRESULT</c> is E_INVALIDARG.</para>
		/// <para>For more information about COM error codes, see Error Handling.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>Note</c> This is a blocking or synchronous function and might not return immediately. How quickly this function returns
		/// depends on run-time factors such as network status, print server configuration, and printer driver implementation—factors that
		/// are difficult to predict when writing an application. Calling this function from a thread that manages interaction with the user
		/// interface could make the application appear to be unresponsive.
		/// </para>
		/// <para>
		/// The hProvider parameter must be a handle that was opened in the same thread as the thread in which it is used for this function.
		/// </para>
		/// <para>A handle cannot be used after it is closed.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/prntvpt/nf-prntvpt-ptcloseprovider HRESULT PTCloseProvider( HPTPROVIDER
		// hProvider );
		[DllImport(Lib.PrntvPt, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("prntvpt.h", MSDNShortId = "28e85b53-fd0c-4210-ae2b-794efaf65bd4")]
		public static extern HRESULT PTCloseProvider(HPTPROVIDER hProvider);

		/// <summary>
		/// <para>
		/// [This function is not supported and might be disabled or deleted in future versions of Windows. <c>PTCloseProvider</c> provides
		/// equivalent functionality and should be used instead.]
		/// </para>
		/// <para>Closes a handle to a print ticket provider.</para>
		/// </summary>
		/// <param name="hProvider">
		/// A handle to an open print ticket provider. This handle is returned by the <c>BindPTProviderThunk</c> function.
		/// </param>
		/// <returns>
		/// If the method succeeds, it returns <c>S_OK</c>; otherwise, it returns an <c>HRESULT</c> error code. For more information about
		/// COM error codes, see Error Handling.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/printdocs/unbindptproviderthunk HRESULT UnbindPTProviderThunk( _In_ HPTPROVIDER
		// hProvider );
		[DllImport(Lib.PrntvPt, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("", MSDNShortId = "ce979c89-9f9d-4e89-b142-beed414caa3f")]
		public static extern HRESULT UnbindPTProviderThunk(HPTPROVIDER hProvider);

		/// <summary>Provides a handle to a print provider.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct HPTPROVIDER : IHandle
		{
			private IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="HPTPROVIDER"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public HPTPROVIDER(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="HPTPROVIDER"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static HPTPROVIDER NULL => new HPTPROVIDER(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="HPTPROVIDER"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(HPTPROVIDER h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HPTPROVIDER"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator HPTPROVIDER(IntPtr h) => new HPTPROVIDER(h);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(HPTPROVIDER h1, HPTPROVIDER h2) => !(h1 == h2);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(HPTPROVIDER h1, HPTPROVIDER h2) => h1.Equals(h2);

			/// <inheritdoc/>
			public override bool Equals(object obj) => obj is HPTPROVIDER h ? handle == h.handle : false;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
		}

		/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="HPTPROVIDER"/> that is disposed using <see cref="PTCloseProvider"/>.</summary>
		public class SafeHPTPROVIDER : SafeHANDLE
		{
			/// <summary>Initializes a new instance of the <see cref="SafeHPTPROVIDER"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafeHPTPROVIDER(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SafeHPTPROVIDER"/> class.</summary>
			private SafeHPTPROVIDER() : base() { }

			/// <summary>Performs an implicit conversion from <see cref="SafeHPTPROVIDER"/> to <see cref="HPTPROVIDER"/>.</summary>
			/// <param name="h">The safe handle instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator HPTPROVIDER(SafeHPTPROVIDER h) => h.handle;

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() => PTCloseProvider(handle).Succeeded;
		}

		/*
		ConvertDevModeToPrintTicketThunk2
		ConvertPrintTicketToDevModeThunk2
		MergeAndValidatePrintTicketThunk2
		PTConvertDevModeToPrintTicket
		PTConvertPrintTicketToDevMode
		PTGetPrintCapabilities
		PTGetPrintDeviceCapabilities
		PTGetPrintDeviceResources
		PTMergeAndValidatePrintTicket
		PTOpenProvider
		PTOpenProviderEx
		PTQuerySchemaVersionSupport
		PTReleaseMemory
		*/
	}
}