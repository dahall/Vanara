using System.Diagnostics;
using WINBIO_UNIT_ID = System.UInt32;

namespace Vanara.PInvoke;

/// <summary>Items from the WinBio.dll</summary>
public static partial class WinBio
{
	/// <summary>
	/// Can be used for scenarios prior to starting Windows. Typically, the database is part of the sensor chip or is part of the BIOS
	/// and can only be used for template enrollment and deletion.
	/// </summary>
	public static readonly GuidPtr WINBIO_DB_BOOTSTRAP = (IntPtr)2;

	/// <summary>Each biometric unit in the sensor pool uses the default database specified in the default biometric unit configuration.</summary>
	public static readonly GuidPtr WINBIO_DB_DEFAULT = (IntPtr)1;

	/// <summary>The database resides on the sensor chip.</summary>
	public static readonly GuidPtr WINBIO_DB_ONCHIP = (IntPtr)3;

	private const string Lib_Winbio = "winbio.dll";

	/// <summary>
	/// Called by the Windows Biometric Framework to notify the client application that an asynchronous operation has completed. The
	/// callback is defined by the client application and called by the Windows Biometric Framework.
	/// </summary>
	/// <param name="AsyncResult">
	/// Pointer to a WINBIO_ASYNC_RESULT structure that contains information about the completed operation. The structure is created by
	/// the Windows Biometric Framework. You must call WinBioFree to release the structure.
	/// </param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>
	/// You must create this callback if you open a biometric session by using the WinBioAsyncOpenSession function or the
	/// WinBioAsyncOpenFramework function and you set <c>WINBIO_ASYNC_NOTIFY_CALLBACK</c> in the NotificationMethod parameter of either function.
	/// </para>
	/// <para>
	/// <c>Important</c> The WINBIO_ASYNC_RESULT structure is allocated internally by the Windows Biometric Framework. Therefore, when
	/// you are through using it, call WinBioFree to release the allocated memory and avoid leaks. Because this also releases all nested
	/// data structures, you should not keep a copy of any pointers returned in the <c>WINBIO_ASYNC_RESULT</c> structure. If you want to
	/// save any data returned in a nested structure, make a private copy of that data before calling <c>WinBioFree</c>.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbio/nc-winbio-pwinbio_async_completion_callback
	// PWINBIO_ASYNC_COMPLETION_CALLBACK PwinbioAsyncCompletionCallback; void PwinbioAsyncCompletionCallback( PWINBIO_ASYNC_RESULT
	// AsyncResult ) {...}
	[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
	[PInvokeData("winbio.h", MSDNShortId = "NC:winbio.PWINBIO_ASYNC_COMPLETION_CALLBACK")]
	public delegate void PWINBIO_ASYNC_COMPLETION_CALLBACK(/*in WINBIO_ASYNC_RESULT*/ [In] IntPtr AsyncResult);

	/// <summary>
	/// <para>
	/// Called by the Windows Biometric Framework to return results from the asynchronous WinBioCaptureSampleWithCallback function. The
	/// client application must implement this function.
	/// </para>
	/// <para>
	/// <c>Important</c> We recommend that, beginning with Windows 8, you no longer use the <c>PWINBIO_CAPTURE_CALLBACK</c>/
	/// <c>WinBioCaptureSampleWithCallback</c> combination. Instead, do the following:
	/// </para>
	/// </summary>
	/// <param name="CaptureCallbackContext">
	/// Pointer to a buffer defined by the application and passed to the CaptureCallbackContext parameter of the
	/// WinBioCaptureSampleWithCallback function. The buffer is not modified by the framework or the biometric unit. Your application
	/// can use the data to help it determine what actions to perform or to maintain additional information about the biometric capture.
	/// </param>
	/// <param name="OperationStatus">Error code returned by the capture operation.</param>
	/// <param name="UnitId">Biometric unit ID number.</param>
	/// <param name="Sample">Pointer to the sample data.</param>
	/// <param name="SampleSize">Size, in bytes, of the sample data pointed to by the Sample parameter.</param>
	/// <param name="RejectDetail">
	/// Additional information about the failure, if any, to perform the operation. For more information, see Remarks.
	/// </param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>
	/// Currently, the Windows Biometric Framework supports only fingerprint readers. Therefore, if an operation fails and returns
	/// additional information in a <c>WINBIO_REJECT_DETAIL</c> constant, it will be one of the following values:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>WINBIO_FP_TOO_HIGH</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FP_TOO_LOW</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FP_TOO_LEFT</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FP_TOO_RIGHT</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FP_TOO_FAST</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FP_TOO_SLOW</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FP_POOR_QUALITY</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FP_TOO_SKEWED</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FP_TOO_SHORT</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FP_MERGE_FAILURE</term>
	/// </item>
	/// </list>
	/// <para>Examples</para>
	/// <para>
	/// The following code example captures a sample asynchronously by calling WinBioCaptureSampleWithCallback and passing a pointer to
	/// a custom callback function, CaptureSampleCallback. Link to the Winbio.lib static library and include the following header files:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>Windows.h</term>
	/// </item>
	/// <item>
	/// <term>Stdio.h</term>
	/// </item>
	/// <item>
	/// <term>Conio.h</term>
	/// </item>
	/// <item>
	/// <term>Winbio.h</term>
	/// </item>
	/// </list>
	/// <para>
	/// <code>HRESULT CaptureSampleWithCallback(BOOL bCancel) { HRESULT hr = S_OK; WINBIO_SESSION_HANDLE sessionHandle = NULL; // Connect to the system pool. hr = WinBioOpenSession( WINBIO_TYPE_FINGERPRINT, // Service provider WINBIO_POOL_SYSTEM, // Pool type WINBIO_FLAG_RAW, // Raw access NULL, // Array of biometric unit IDs 0, // Count of biometric unit IDs WINBIO_DB_DEFAULT, // Default database &amp;sessionHandle // [out] Session handle ); if (FAILED(hr)) { wprintf_s(L"\n WinBioOpenSession failed. hr = 0x%x\n", hr); goto e_Exit; } // Capture a biometric sample asynchronously. wprintf_s(L"\n Calling WinBioCaptureSampleWithCallback "); hr = WinBioCaptureSampleWithCallback( sessionHandle, // Open session handle WINBIO_NO_PURPOSE_AVAILABLE, // Intended use of the sample WINBIO_DATA_FLAG_RAW, // Sample format CaptureSampleCallback, // Callback function NULL // Optional context ); if (FAILED(hr)) { wprintf_s(L"\n WinBioCaptureSampleWithCallback failed. "); wprintf_s(L"hr = 0x%x\n", hr); goto e_Exit; } wprintf_s(L"\n Swipe the sensor ...\n"); // Cancel the capture process if the bCancel flag is set. if (bCancel) { wprintf_s(L"\n Starting CANCEL timer..."); Sleep( 7000 ); wprintf_s(L"\n Calling WinBioCancel\n"); hr = WinBioCancel( sessionHandle ); if (FAILED(hr)) { wprintf_s(L"\n WinBioCancel failed. hr = 0x%x\n", hr); goto e_Exit; } } // Wait for the asynchronous capture process to complete // or be canceled. hr = WinBioWait( sessionHandle ); if (FAILED(hr)) { wprintf_s(L"\n WinBioWait failed. hr = 0x%x\n", hr); } e_Exit: if (sessionHandle != NULL) { WinBioCloseSession(sessionHandle); sessionHandle = NULL; } wprintf_s(L"\n Press any key to exit..."); _getch(); return hr; } //------------------------------------------------------------------------ // The following function is the callback for WinBioCaptureSampleWithCallback. // The function filters the response from the biometric subsystem and // writes a result to the console window. // VOID CALLBACK CaptureSampleCallback( __in_opt PVOID CaptureCallbackContext, __in HRESULT OperationStatus, __in WINBIO_UNIT_ID UnitId, __in_bcount(SampleSize) PWINBIO_BIR Sample, __in SIZE_T SampleSize, __in WINBIO_REJECT_DETAIL RejectDetail ) { UNREFERENCED_PARAMETER(CaptureCallbackContext); wprintf_s(L"\n CaptureSampleCallback executing"); wprintf_s(L"\n Swipe processed - Unit ID: %d", UnitId); if (FAILED(OperationStatus)) { if (OperationStatus == WINBIO_E_BAD_CAPTURE) { wprintf_s(L"\n Bad capture; reason: %d\n", RejectDetail); } else { wprintf_s(L"\n WinBioCaptureSampleWithCallback failed. "); wprintf_s(L" OperationStatus = 0x%x\n", OperationStatus); } goto e_Exit; } wprintf_s(L"\n Captured %d bytes.\n", SampleSize); e_Exit: if (Sample != NULL) { WinBioFree(Sample); Sample = NULL; } }</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbio/nc-winbio-pwinbio_capture_callback PWINBIO_CAPTURE_CALLBACK
	// PwinbioCaptureCallback; void PwinbioCaptureCallback( PVOID CaptureCallbackContext, HRESULT OperationStatus, WINBIO_UNIT_ID
	// UnitId, PWINBIO_BIR Sample, SIZE_T SampleSize, WINBIO_REJECT_DETAIL RejectDetail ) {...}
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	[PInvokeData("winbio.h", MSDNShortId = "NC:winbio.PWINBIO_CAPTURE_CALLBACK")]
	public delegate void PWINBIO_CAPTURE_CALLBACK([In, Optional] IntPtr CaptureCallbackContext, [In] HRESULT OperationStatus, uint UnitId, [In] IntPtr Sample, SIZE_T SampleSize, WINBIO_REJECT_DETAIL RejectDetail);

	/// <summary>
	/// <para>
	/// The <c>PWINBIO_ENROLL_CAPTURE_CALLBACK</c> function is called by the Windows Biometric Framework to return results from the
	/// asynchronous WinBioEnrollCaptureWithCallback function. The client application must implement this function.
	/// </para>
	/// <para>
	/// <c>Important</c> We recommend that, beginning with Windows 8, you no longer use the <c>PWINBIO_ENROLL_CAPTURE_CALLBACK</c>/
	/// <c>WinBioEnrollCaptureWithCallback</c> combination. Instead, do the following:
	/// </para>
	/// </summary>
	/// <param name="EnrollCallbackContext">
	/// Pointer to a buffer defined by the application and passed to the EnrollCallback parameter of the WinBioEnrollCaptureWithCallback
	/// function. The buffer is not modified by the framework or the biometric unit. Your application can use the data to help it
	/// determine what actions to perform or to maintain additional information about the biometric capture.
	/// </param>
	/// <param name="OperationStatus">Error code returned by the capture operation.</param>
	/// <param name="RejectDetail">
	/// Additional information about the failure, if any, to perform the operation. For more information, see Remarks.
	/// </param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>
	/// Currently, the Windows Biometric Framework supports only fingerprint readers. Therefore, if an operation fails and returns
	/// additional information in a <c>WINBIO_REJECT_DETAIL</c> constant, it will be one of the following values:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>WINBIO_FP_TOO_HIGH</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FP_TOO_LOW</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FP_TOO_LEFT</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FP_TOO_RIGHT</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FP_TOO_FAST</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FP_TOO_SLOW</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FP_POOR_QUALITY</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FP_TOO_SKEWED</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FP_TOO_SHORT</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FP_MERGE_FAILURE</term>
	/// </item>
	/// </list>
	/// <para>Examples</para>
	/// <para>
	/// The following code example enrolls a fingerprint asynchronously by calling WinBioEnrollCaptureWithCallback and passing a pointer
	/// to a custom callback function, EnrollCaptureCallback. Link to the Winbio.lib static library.
	/// </para>
	/// <para>
	/// <code>//------------------------------------------------------------------------ // EnrollSystemPoolWithCallback.cpp : console application entry point. // #include &lt;windows.h&gt; #include &lt;stdio.h&gt; #include &lt;conio.h&gt; #include &lt;winbio.h&gt; //------------------------------------------------------------------------ // Forward declarations. // HRESULT EnrollSysPoolWithCallback( BOOL bCancel, BOOL bDiscard, WINBIO_BIOMETRIC_SUBTYPE subFactor); VOID CALLBACK EnrollCaptureCallback( __in_opt PVOID EnrollCallbackContext, __in HRESULT OperationStatus, __in WINBIO_REJECT_DETAIL RejectDetail); typedef struct _ENROLL_CALLBACK_CONTEXT { WINBIO_SESSION_HANDLE SessionHandle; WINBIO_UNIT_ID UnitId; WINBIO_BIOMETRIC_SUBTYPE SubFactor; } ENROLL_CALLBACK_CONTEXT, *PENROLL_CALLBACK_CONTEXT; //------------------------------------------------------------------------ int wmain() { HRESULT hr = S_OK; hr = EnrollSysPoolWithCallback( FALSE, FALSE, WINBIO_ANSI_381_POS_RH_INDEX_FINGER); return 0; } //------------------------------------------------------------------------ // The following function enrolls a user's fingerprint in the system pool. // The function calls WinBioEnrollCaptureWithCallback and waits for the // asynchronous enrollment process to be completed or canceled. // HRESULT EnrollSysPoolWithCallback( BOOL bCancel, BOOL bDiscard, WINBIO_BIOMETRIC_SUBTYPE subFactor) { // Declare variables HRESULT hr = S_OK; WINBIO_IDENTITY identity = {0}; WINBIO_SESSION_HANDLE sessionHandle = NULL; WINBIO_UNIT_ID unitId = 0; BOOLEAN isNewTemplate = TRUE; ENROLL_CALLBACK_CONTEXT callbackContext = {0}; // Connect to the system pool. hr = WinBioOpenSession( WINBIO_TYPE_FINGERPRINT, // Service provider WINBIO_POOL_SYSTEM, // Pool type WINBIO_FLAG_DEFAULT, // Configuration and access NULL, // Array of biometric unit IDs 0, // Count of biometric unit IDs NULL, // Database ID &amp;sessionHandle // [out] Session handle ); if (FAILED(hr)) { wprintf_s(L"\n WinBioEnumBiometricUnits failed. "); wprintf_s(L"hr = 0x%x\n", hr); goto e_Exit; } // Locate the sensor. wprintf_s(L"\n Swipe your finger to locate the sensor...\n"); hr = WinBioLocateSensor( sessionHandle, &amp;unitId); if (FAILED(hr)) { wprintf_s(L"\n WinBioLocateSensor failed. hr = 0x%x\n", hr); goto e_Exit; } // Begin the enrollment sequence. hr = WinBioEnrollBegin( sessionHandle, // Handle to open biometric session subFactor, // Finger to create template for unitId // Biometric unit ID ); if (FAILED(hr)) { wprintf_s(L"\n WinBioEnrollBegin failed. hr = 0x%x\n", hr); goto e_Exit; } // Set up the custom callback context structure. callbackContext.SessionHandle = sessionHandle; callbackContext.UnitId = unitId; callbackContext.SubFactor = subFactor; // Call WinBioEnrollCaptureWithCallback. This is an asynchronous // method that returns immediately. hr = WinBioEnrollCaptureWithCallback( sessionHandle, // Handle to open biometric session EnrollCaptureCallback, // Callback function &amp;callbackContext // Pointer to the custom context ); if (FAILED(hr)) { wprintf_s(L"\n WinBioEnrollCaptureWithCallback failed. "); wprintf_s(L"hr = 0x%x\n", hr); goto e_Exit; } wprintf_s(L"\n Swipe the sensor with the appropriate finger...\n"); // Cancel the enrollment if the bCancel flag is set. if (bCancel) { wprintf_s(L"\n Starting CANCEL timer...\n"); Sleep( 7000 ); wprintf_s(L"\n Calling WinBioCancel\n"); hr = WinBioCancel( sessionHandle ); if (FAILED(hr)) { wprintf_s(L"\n WinBioCancel failed. hr = 0x%x\n", hr); goto e_Exit; } } // Wait for the asynchronous enrollment process to complete // or be canceled. hr = WinBioWait( sessionHandle ); if (FAILED(hr)) { wprintf_s(L"\n WinBioWait failed. hr = 0x%x\n", hr); } // Discard the enrollment if the bDiscard flag is set. // Commit the enrollment if the flag is not set. if (bDiscard) { wprintf_s(L"\n Discarding enrollment...\n"); hr = WinBioEnrollDiscard( sessionHandle ); if (FAILED(hr)) { wprintf_s(L"\n WinBioLocateSensor failed. "); wprintf_s(L"hr = 0x%x\n", hr); } goto e_Exit; } else { wprintf_s(L"\n Committing enrollment...\n"); hr = WinBioEnrollCommit( sessionHandle, // Handle to open biometric session &amp;identity, // WINBIO_IDENTITY object for the user &amp;isNewTemplate); // Is this a new template if (FAILED(hr)) { wprintf_s(L"\n WinBioEnrollCommit failed. hr = 0x%x\n", hr); goto e_Exit; } } e_Exit: if (sessionHandle != NULL) { WinBioCloseSession(sessionHandle); sessionHandle = NULL; } wprintf_s(L"\n Press any key to exit..."); _getch(); return hr; } //------------------------------------------------------------------------ // The following function is the callback for the Windows Biometric // Framework WinBioEnrollCaptureWithCallback() function. // VOID CALLBACK EnrollCaptureCallback( __in_opt PVOID EnrollCallbackContext, __in HRESULT OperationStatus, __in WINBIO_REJECT_DETAIL RejectDetail ) { // Declare variables. HRESULT hr = S_OK; static SIZE_T swipeCount = 1; PENROLL_CALLBACK_CONTEXT callbackContext = (PENROLL_CALLBACK_CONTEXT)EnrollCallbackContext; wprintf_s(L"\n EnrollCaptureCallback executing\n"); wprintf_s(L"\n Sample %d captured", swipeCount++); // The capture was not acceptable or the enrollment operation // failed. if (FAILED(OperationStatus)) { if (OperationStatus == WINBIO_E_BAD_CAPTURE) { wprintf_s(L"\n Bad capture; reason: %d\n", RejectDetail); wprintf_s(L"\n Swipe your finger to capture another sample.\n"); // Try again. hr = WinBioEnrollCaptureWithCallback( callbackContext-&gt;SessionHandle, // Open session handle EnrollCaptureCallback, // Callback function EnrollCallbackContext // Callback context ); if (FAILED(hr)) { wprintf_s(L"WinBioEnrollCaptureWithCallback failed."); wprintf_s(L"hr = 0x%x\n", hr); } } else { wprintf_s(L"EnrollCaptureCallback failed."); wprintf_s(L"OperationStatus = 0x%x\n", OperationStatus); } goto e_Exit; } // The enrollment operation requires more fingerprint swipes. // This is normal and depends on your hardware. Typically, at least // three swipes are required. if (OperationStatus == WINBIO_I_MORE_DATA) { wprintf_s(L"\n More data required."); wprintf_s(L"\n Swipe your finger on the sensor again."); hr = WinBioEnrollCaptureWithCallback( callbackContext-&gt;SessionHandle, EnrollCaptureCallback, EnrollCallbackContext ); if (FAILED(hr)) { wprintf_s(L"WinBioEnrollCaptureWithCallback failed. "); wprintf_s(L"hr = 0x%x\n", hr); } goto e_Exit; } wprintf_s(L"\n Template completed\n"); e_Exit: return; }</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbio/nc-winbio-pwinbio_enroll_capture_callback
	// PWINBIO_ENROLL_CAPTURE_CALLBACK PwinbioEnrollCaptureCallback; void PwinbioEnrollCaptureCallback( PVOID EnrollCallbackContext,
	// HRESULT OperationStatus, WINBIO_REJECT_DETAIL RejectDetail ) {...}
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	[PInvokeData("winbio.h", MSDNShortId = "NC:winbio.PWINBIO_ENROLL_CAPTURE_CALLBACK")]
	public delegate void PWINBIO_ENROLL_CAPTURE_CALLBACK([In, Optional] IntPtr EnrollCallbackContext, [In] HRESULT OperationStatus, WINBIO_REJECT_DETAIL RejectDetail);

	/// <summary>
	/// Called by the Windows Biometric Framework to return results from the asynchronous WinBioRegisterEventMonitor function. The
	/// client application must implement this function.
	/// </summary>
	/// <param name="EventCallbackContext">
	/// Pointer to a buffer defined by the application and passed to the EventCallbackContext parameter of the
	/// WinBioRegisterEventMonitor function. The buffer is not modified by the framework or the biometric unit. Your application can use
	/// the data to help it determine what actions to perform or to maintain additional information about the biometric capture.
	/// </param>
	/// <param name="OperationStatus">Error code returned by the capture operation.</param>
	/// <param name="Event">Pointer to a WINBIO_EVENT value. For more information, see WINBIO_EVENT Constants.</param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbio/nc-winbio-pwinbio_event_callback PWINBIO_EVENT_CALLBACK
	// PwinbioEventCallback; void PwinbioEventCallback( PVOID EventCallbackContext, HRESULT OperationStatus, PWINBIO_EVENT Event ) {...}
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	[PInvokeData("winbio.h", MSDNShortId = "NC:winbio.PWINBIO_EVENT_CALLBACK")]
	public delegate void PWINBIO_EVENT_CALLBACK([In, Optional] IntPtr EventCallbackContext, [In] HRESULT OperationStatus, in WINBIO_EVENT Event);

	/// <summary>
	/// <para>
	/// The <c>PWINBIO_IDENTIFY_CALLBACK</c> function is called by the Windows Biometric Framework to return results from the
	/// asynchronous WinBioIdentifyWithCallback function. The client application must implement this function.
	/// </para>
	/// <para>
	/// <c>Important</c> We recommend that, beginning with Windows 8, you no longer use the <c>PWINBIO_IDENTIFY_CALLBACK</c>/
	/// <c>WinBioIdentifyWithCallback</c> combination. Instead, do the following:
	/// </para>
	/// </summary>
	/// <param name="IdentifyCallbackContext">
	/// Pointer to a buffer defined by the application and passed to the IdentifyCallbackContext parameter of the
	/// WinBioIdentifyWithCallback function. The buffer is not modified by the framework or the biometric unit. Your application can use
	/// the data to help it determine what actions to perform or to maintain additional information about the biometric capture.
	/// </param>
	/// <param name="OperationStatus">Error code returned by the capture operation.</param>
	/// <param name="UnitId">Biometric unit ID number.</param>
	/// <param name="Identity">A WINBIO_IDENTITY structure that receives the GUID or SID of the user providing the biometric sample.</param>
	/// <param name="SubFactor">
	/// A <c>WINBIO_BIOMETRIC_SUBTYPE</c> value that receives the sub-factor associated with the biometric sample. See the Remarks
	/// section for more details.
	/// </param>
	/// <param name="RejectDetail">
	/// Additional information about the failure, if any, to perform the operation. For more information, see Remarks.
	/// </param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>
	/// Currently, the Windows Biometric Framework supports only fingerprint readers. Therefore, if an operation fails and returns
	/// additional information in a <c>WINBIO_REJECT_DETAIL</c> constant, it will be one of the following values:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>WINBIO_FP_TOO_HIGH</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FP_TOO_LOW</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FP_TOO_LEFT</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FP_TOO_RIGHT</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FP_TOO_FAST</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FP_TOO_SLOW</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FP_POOR_QUALITY</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FP_TOO_SKEWED</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FP_TOO_SHORT</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FP_MERGE_FAILURE</term>
	/// </item>
	/// </list>
	/// <para>Examples</para>
	/// <para>
	/// The following code example calls WinBioIdentifyWithCallback to identify a user from a biometric scan.
	/// <c>WinBioIdentifyWithCallback</c> is an asynchronous function that configures the biometric subsystem to process biometric input
	/// on another thread. Output from the biometric subsystem is then sent to a custom callback function named IdentifyCallback. Link
	/// to the Winbio.lib static library and include the following header files:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>Windows.h</term>
	/// </item>
	/// <item>
	/// <term>Stdio.h</term>
	/// </item>
	/// <item>
	/// <term>Conio.h</term>
	/// </item>
	/// <item>
	/// <term>Winbio.h</term>
	/// </item>
	/// </list>
	/// <para>
	/// <code>HRESULT IdentifyWithCallback(BOOL bCancel) { // Declare variables. HRESULT hr = S_OK; WINBIO_SESSION_HANDLE sessionHandle = NULL; // Connect to the system pool. hr = WinBioOpenSession( WINBIO_TYPE_FINGERPRINT, // Service provider WINBIO_POOL_SYSTEM, // Pool type WINBIO_FLAG_DEFAULT, // Configuration and access NULL, // Array of biometric unit IDs 0, // Count of biometric unit IDs WINBIO_DB_DEFAULT, // Database ID &amp;sessionHandle // [out] Session handle ); if (FAILED(hr)) { wprintf_s(L"\n WinBioOpenSession failed. hr = 0x%x\n", hr); goto e_Exit; } // Call WinBioIdentifyWithCallback. The method is asynchronous // and returns immediately. wprintf_s(L"\n Calling WinBioIdentifyWithCallback"); wprintf_s(L"\n Swipe the sensor ...\n"); hr = WinBioIdentifyWithCallback( sessionHandle, // Open biometric session IdentifyCallback, // Callback function NULL // Optional context ); if (FAILED(hr)) { wprintf_s(L"\n WinBioIdentifyWithCallback failed. hr = 0x%x\n", hr); goto e_Exit; } // Cancel user identification if the bCancel flag is set. if (bCancel) { wprintf_s(L"\n Starting CANCEL timer...\n"); Sleep( 7000 ); wprintf_s(L"\n Calling WinBioCancel\n"); hr = WinBioCancel( sessionHandle ); if (FAILED(hr)) { wprintf_s(L"\n WinBioCancel failed. hr = 0x%x\n", hr); goto e_Exit; } } // Wait for the asynchronous identification process to complete // or be canceled. hr = WinBioWait( sessionHandle ); if (FAILED(hr)) { wprintf_s(L"\n WinBioWait failed. hr = 0x%x\n", hr); } e_Exit: if (sessionHandle != NULL) { wprintf_s(L"\n Closing the session.\n"); hr = WinBioCloseSession(sessionHandle); if (FAILED(hr)) { wprintf_s(L"\n WinBioCloseSession failed. hr = 0x%x\n", hr); } sessionHandle = NULL; } wprintf_s(L"\n Hit any key to exit..."); _getch(); return hr; } //------------------------------------------------------------------------ // The following function is the callback for WinBioIdentifyWithCallback. // The function filters the response from the biometric subsystem and // writes a result to the console window. // VOID CALLBACK IdentifyCallback( __in_opt PVOID IdentifyCallbackContext, __in HRESULT OperationStatus, __in WINBIO_UNIT_ID UnitId, __in WINBIO_IDENTITY *Identity, __in WINBIO_BIOMETRIC_SUBTYPE SubFactor, __in WINBIO_REJECT_DETAIL RejectDetail ) { UNREFERENCED_PARAMETER(IdentifyCallbackContext); UNREFERENCED_PARAMETER(Identity); wprintf_s(L"\n IdentifyCallback executing"); wprintf_s(L"\n Swipe processed for unit ID %d\n", UnitId); // The attempt to process the fingerprint failed. if (FAILED(OperationStatus)) { if (OperationStatus == WINBIO_E_UNKNOWN_ID) { wprintf_s(L"\n Unknown identity.\n"); } else if (OperationStatus == WINBIO_E_BAD_CAPTURE) { wprintf_s(L"\n Bad capture; reason: %d\n", RejectDetail); } else { wprintf_s(L"IdentifyCallback failed."); wprintf_s(L"OperationStatus = 0x%x\n", OperationStatus); } } // Processing succeeded and the finger swiped is written // to the console window. else { wprintf_s(L"\n The following finger was used:"); switch (SubFactor) { case WINBIO_SUBTYPE_NO_INFORMATION: wprintf_s(L"\n No information\n"); break; case WINBIO_ANSI_381_POS_RH_THUMB: wprintf_s(L"\n RH thumb\n"); break; case WINBIO_ANSI_381_POS_RH_INDEX_FINGER: wprintf_s(L"\n RH index finger\n"); break; case WINBIO_ANSI_381_POS_RH_MIDDLE_FINGER: wprintf_s(L"\n RH middle finger\n"); break; case WINBIO_ANSI_381_POS_RH_RING_FINGER: wprintf_s(L"\n RH ring finger\n"); break; case WINBIO_ANSI_381_POS_RH_LITTLE_FINGER: wprintf_s(L"\n RH little finger\n"); break; case WINBIO_ANSI_381_POS_LH_THUMB: wprintf_s(L"\n LH thumb\n"); break; case WINBIO_ANSI_381_POS_LH_INDEX_FINGER: wprintf_s(L"\n LH index finger\n"); break; case WINBIO_ANSI_381_POS_LH_MIDDLE_FINGER: wprintf_s(L"\n LH middle finger\n"); break; case WINBIO_ANSI_381_POS_LH_RING_FINGER: wprintf_s(L"\n LH ring finger\n"); break; case WINBIO_ANSI_381_POS_LH_LITTLE_FINGER: wprintf_s(L"\n LH little finger\n"); break; case WINBIO_SUBTYPE_ANY: wprintf_s(L"\n Any finger\n"); break; default: break; } } }</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbio/nc-winbio-pwinbio_identify_callback PWINBIO_IDENTIFY_CALLBACK
	// PwinbioIdentifyCallback; void PwinbioIdentifyCallback( PVOID IdentifyCallbackContext, HRESULT OperationStatus, WINBIO_UNIT_ID
	// UnitId, WINBIO_IDENTITY *Identity, WINBIO_BIOMETRIC_SUBTYPE SubFactor, WINBIO_REJECT_DETAIL RejectDetail ) {...}
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	[PInvokeData("winbio.h", MSDNShortId = "NC:winbio.PWINBIO_IDENTIFY_CALLBACK")]
	public delegate void PWINBIO_IDENTIFY_CALLBACK([In, Optional] IntPtr IdentifyCallbackContext, HRESULT OperationStatus, uint UnitId, in WINBIO_IDENTITY Identity, WINBIO_BIOMETRIC_SUBTYPE SubFactor, WINBIO_REJECT_DETAIL RejectDetail);

	/// <summary>
	/// <para>
	/// Called by the Windows Biometric Framework to return results from the asynchronous WinBioLocateSensorWithCallback function. The
	/// client application must implement this function.
	/// </para>
	/// <para>
	/// <c>Important</c> We recommend that, beginning with Windows 8, you no longer use the <c>PWINBIO_LOCATE_SENSOR_CALLBACK</c>/
	/// <c>WinBioLocateSensorWithCallback</c> combination. Instead, do the following:
	/// </para>
	/// </summary>
	/// <param name="LocateCallbackContext">
	/// Pointer to a buffer defined by the application and passed to the LocateCallbackContext parameter of the
	/// WinBioLocateSensorWithCallback function. The buffer is not modified by the framework or the biometric unit. Your application can
	/// use the data to help it determine what actions to perform or to maintain additional information about the biometric capture.
	/// </param>
	/// <param name="OperationStatus">Error code returned by the capture operation.</param>
	/// <param name="UnitId">Biometric unit ID number.</param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbio/nc-winbio-pwinbio_locate_sensor_callback PWINBIO_LOCATE_SENSOR_CALLBACK
	// PwinbioLocateSensorCallback; void PwinbioLocateSensorCallback( PVOID LocateCallbackContext, HRESULT OperationStatus,
	// WINBIO_UNIT_ID UnitId ) {...}
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	[PInvokeData("winbio.h", MSDNShortId = "NC:winbio.PWINBIO_LOCATE_SENSOR_CALLBACK")]
	public delegate void PWINBIO_LOCATE_SENSOR_CALLBACK([In, Optional] IntPtr LocateCallbackContext, HRESULT OperationStatus, uint UnitId);

	/// <summary>
	/// <para>
	/// Called by the Windows Biometric Framework to return results from the asynchronous WinBioVerifyWithCallback function. The client
	/// application must implement this function.
	/// </para>
	/// <para>
	/// <c>Important</c> We recommend that, beginning with Windows 8, you no longer use the <c>PWINBIO_VERIFY_CALLBACK</c>/
	/// <c>WinBioVerifyWithCallback</c> combination. Instead, do the following:
	/// </para>
	/// </summary>
	/// <param name="VerifyCallbackContext">
	/// Pointer to a buffer defined by the application and passed to the VerifyCallbackContext parameter of the WinBioVerifyWithCallback
	/// function. The buffer is not modified by the framework or the biometric unit. Your application can use the data to help it
	/// determine what actions to perform or to maintain additional information about the biometric capture.
	/// </param>
	/// <param name="OperationStatus">Error code returned by the capture operation.</param>
	/// <param name="UnitId">Biometric unit ID number.</param>
	/// <param name="Match">
	/// A Boolean value that specifies whether the captured sample matched the user identity specified by the Identity parameter.
	/// </param>
	/// <param name="RejectDetail">
	/// Additional information about the failure, if any, to perform the operation. For more information, see Remarks.
	/// </param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>
	/// Currently, the Windows Biometric Framework supports only fingerprint readers. Therefore, if an operation fails and returns
	/// additional information in a <c>WINBIO_REJECT_DETAIL</c> constant, it will be one of the following values:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>WINBIO_FP_TOO_HIGH</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FP_TOO_LOW</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FP_TOO_LEFT</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FP_TOO_RIGHT</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FP_TOO_FAST</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FP_TOO_SLOW</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FP_POOR_QUALITY</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FP_TOO_SKEWED</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FP_TOO_SHORT</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FP_MERGE_FAILURE</term>
	/// </item>
	/// </list>
	/// <para>Examples</para>
	/// <para>
	/// The following function calls WinBioVerifyWithCallback to asynchronously determine whether a biometric sample matches the logged
	/// on identity of the current user. The callback routine, VerifyCallback, and a helper function, GetCurrentUserIdentity, are also
	/// included. Link to the Winbio.lib static library and include the following header files:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>Windows.h</term>
	/// </item>
	/// <item>
	/// <term>Stdio.h</term>
	/// </item>
	/// <item>
	/// <term>Conio.h</term>
	/// </item>
	/// <item>
	/// <term>Winbio.h</term>
	/// </item>
	/// </list>
	/// <para>
	/// <code>HRESULT VerifyWithCallback(BOOL bCancel, WINBIO_BIOMETRIC_SUBTYPE subFactor) { // Declare variables. HRESULT hr = S_OK; WINBIO_SESSION_HANDLE sessionHandle = NULL; WINBIO_UNIT_ID unitId = 0; WINBIO_REJECT_DETAIL rejectDetail = 0; WINBIO_IDENTITY identity = {0}; // Find the identity of the user. hr = GetCurrentUserIdentity( &amp;identity ); if (FAILED(hr)) { wprintf_s(L"\n User identity not found. hr = 0x%x\n", hr); goto e_Exit; } // Connect to the system pool. hr = WinBioOpenSession( WINBIO_TYPE_FINGERPRINT, // Service provider WINBIO_POOL_SYSTEM, // Pool type WINBIO_FLAG_DEFAULT, // Configuration and access NULL, // Array of biometric unit IDs 0, // Count of biometric unit IDs NULL, // Database ID &amp;sessionHandle // [out] Session handle ); if (FAILED(hr)) { wprintf_s(L"\n WinBioOpenSession failed. hr = 0x%x\n", hr); goto e_Exit; } // Verify a biometric sample asynchronously. wprintf_s(L"\n Calling WinBioVerifyWithCallback.\n"); hr = WinBioVerifyWithCallback( sessionHandle, // Open session handle &amp;identity, // User SID or GUID subFactor, // Sample sub-factor VerifyCallback, // Callback function NULL // Optional context ); if (FAILED(hr)) { wprintf_s(L"\n WinBioVerifyWithCallback failed. hr = 0x%x\n", hr); goto e_Exit; } wprintf_s(L"\n Swipe the sensor ...\n"); // Cancel the identification if the bCancel flag is set. if (bCancel) { wprintf_s(L"\n Starting CANCEL timer...\n"); Sleep( 7000 ); wprintf_s(L"\n Calling WinBioCancel\n"); hr = WinBioCancel( sessionHandle ); if (FAILED(hr)) { wprintf_s(L"\n WinBioCancel failed. hr = 0x%x\n", hr); goto e_Exit; } } // Wait for the asynchronous identification process to complete // or be canceled. hr = WinBioWait( sessionHandle ); if (FAILED(hr)) { wprintf_s(L"\n WinBioWait failed. hr = 0x%x\n", hr); } e_Exit: if (sessionHandle != NULL) { WinBioCloseSession(sessionHandle); sessionHandle = NULL; } wprintf_s(L"\n Hit any key to continue..."); _getch(); return hr; } //------------------------------------------------------------------------ // The following function is the callback for WinBioVerifyWithCallback. // The function filters the response from the biometric subsystem and // writes a result to the console window. // VOID CALLBACK VerifyCallback( __in_opt PVOID VerifyCallbackContext, __in HRESULT OperationStatus, __in WINBIO_UNIT_ID UnitId, __in BOOLEAN Match, __in WINBIO_REJECT_DETAIL RejectDetail ) { UNREFERENCED_PARAMETER(VerifyCallbackContext); UNREFERENCED_PARAMETER(Match); wprintf_s(L"\n VerifyCallback executing"); wprintf_s(L"\n Swipe processed for unit ID %d\n", UnitId); // The identity could not be verified. if (FAILED(OperationStatus)) { wprintf_s(L"\n Verification failed for the following reason:"); if (OperationStatus == WINBIO_E_NO_MATCH) { wprintf_s(L"\n No match.\n"); } else if (OperationStatus == WINBIO_E_BAD_CAPTURE) { wprintf_s(L"\n Bad capture.\n "); wprintf_s(L"\n Bad capture; reason: %d\n", RejectDetail); } else { wprintf_s(L"VerifyCallback failed."); wprintf_s(L"OperationStatus = 0x%x\n", OperationStatus); } goto e_Exit; } // The user identity was verified. wprintf_s(L"\n Fingerprint verified:\n"); e_Exit: return; } //------------------------------------------------------------------------ // The following function retrieves the identity of the current user. // This is a helper function and is not part of the Windows Biometric // Framework API. // HRESULT GetCurrentUserIdentity(__inout PWINBIO_IDENTITY Identity) { // Declare variables. HRESULT hr = S_OK; HANDLE tokenHandle = NULL; DWORD bytesReturned = 0; struct{ TOKEN_USER tokenUser; BYTE buffer[SECURITY_MAX_SID_SIZE]; } tokenInfoBuffer; // Zero the input identity and specify the type. ZeroMemory( Identity, sizeof(WINBIO_IDENTITY)); Identity-&gt;Type = WINBIO_ID_TYPE_NULL; // Open the access token associated with the // current process if (!OpenProcessToken( GetCurrentProcess(), // Process handle TOKEN_READ, // Read access only &amp;tokenHandle)) // Access token handle { DWORD win32Status = GetLastError(); wprintf_s(L"Cannot open token handle: %d\n", win32Status); hr = HRESULT_FROM_WIN32(win32Status); goto e_Exit; } // Zero the tokenInfoBuffer structure. ZeroMemory(&amp;tokenInfoBuffer, sizeof(tokenInfoBuffer)); // Retrieve information about the access token. In this case, // retrieve a SID. if (!GetTokenInformation( tokenHandle, // Access token handle TokenUser, // User for the token &amp;tokenInfoBuffer.tokenUser, // Buffer to fill sizeof(tokenInfoBuffer), // Size of the buffer &amp;bytesReturned)) // Size needed { DWORD win32Status = GetLastError(); wprintf_s(L"Cannot query token information: %d\n", win32Status); hr = HRESULT_FROM_WIN32(win32Status); goto e_Exit; } // Copy the SID from the tokenInfoBuffer structure to the // WINBIO_IDENTITY structure. CopySid( SECURITY_MAX_SID_SIZE, Identity-&gt;Value.AccountSid.Data, tokenInfoBuffer.tokenUser.User.Sid ); // Specify the size of the SID and assign WINBIO_ID_TYPE_SID // to the type member of the WINBIO_IDENTITY structure. Identity-&gt;Value.AccountSid.Size = GetLengthSid(tokenInfoBuffer.tokenUser.User.Sid); Identity-&gt;Type = WINBIO_ID_TYPE_SID; e_Exit: if (tokenHandle != NULL) { CloseHandle(tokenHandle); } return hr; }</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbio/nc-winbio-pwinbio_verify_callback PWINBIO_VERIFY_CALLBACK
	// PwinbioVerifyCallback; void PwinbioVerifyCallback( PVOID VerifyCallbackContext, HRESULT OperationStatus, WINBIO_UNIT_ID UnitId,
	// BOOLEAN Match, WINBIO_REJECT_DETAIL RejectDetail ) {...}
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	[PInvokeData("winbio.h", MSDNShortId = "NC:winbio.PWINBIO_VERIFY_CALLBACK")]
	public delegate void PWINBIO_VERIFY_CALLBACK([In, Optional] IntPtr VerifyCallbackContext, HRESULT OperationStatus, uint UnitId, [MarshalAs(UnmanagedType.U1)] bool Match, WINBIO_REJECT_DETAIL RejectDetail);

	private delegate HRESULT EnumFunc(WINBIO_BIOMETRIC_TYPE Factor, out SafeWinBioMemory array, out SIZE_T count);

	/// <summary>
	/// Defines constants that specify how completion notifications for asynchronous operations are to be delivered to the client
	/// application. This enumeration is used by the WinBioAsyncOpenFramework and WinBioAsyncOpenSession functions.
	/// </summary>
	[PInvokeData("winbio.h")]
	public enum WINBIO_ASYNC_NOTIFICATION_METHOD
	{
		/// <summary>The operation is synchronous.</summary>
		WINBIO_ASYNC_NOTIFY_NONE = 0,   // Operation is synchronous
		/// <summary>The client-implemented PWINBIO_ASYNC_COMPLETION_CALLBACK function is called by the framework.</summary>
		WINBIO_ASYNC_NOTIFY_CALLBACK,   // Caller receives a new-style callback
		/// <summary>The framework sends completion notices to the client application window message queue.</summary>
		WINBIO_ASYNC_NOTIFY_MESSAGE,    // Caller receives a window message
	}

	/// <summary>Acquires window focus.</summary>
	/// <returns>
	/// <para>
	/// If the function succeeds, it returns <c>S_OK</c>. If the function fails, it returns an <c>HRESULT</c> value that indicates the
	/// error. Possible values include, but are not limited to, those in the following table. For a list of common error codes, see
	/// Common HRESULT Values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_ACCESSDENIED</term>
	/// <term>The calling process must be running under the Local System account.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>The Windows Biometric Framework uses window focus to arbitrate among multiple sessions connected to the system pool.</para>
	/// <para>
	/// The manner in which you acquire focus depends on the type of application you are writing. For example, if you are creating a GUI
	/// application you can implement a message handler that captures a WM_ACTIVATE, WM_SETFOCUS, or other appropriate message. If you
	/// are writing a CUI application, call <c>GetConsoleWindow</c> to retrieve a handle to the console window and pass that handle to
	/// the <c>SetForegroundWindow</c> function to force the console window into the foreground and assign it focus. If your application
	/// is running in a detached process or is a Windows service and has no window, use <c>WinBioAcquireFocus</c> and WinBioReleaseFocus
	/// to manually control focus.
	/// </para>
	/// <para>The following list summarizes the major points to consider before calling this function.</para>
	/// <list type="bullet">
	/// <item>
	/// <term>The calling process must be running under the Local System account.</term>
	/// </item>
	/// <item>
	/// <term>
	/// A process that directly displays a user interface should not call this function. See the preceding discussion to determine how
	/// to acquire focus for GUI and CUI applications.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// Only a service or a detached process that does not directly display a user interface during biometric API calls should call this function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>If the function succeeds, you must call WinBioReleaseFocus to release focus.</term>
	/// </item>
	/// </list>
	/// <para>If you do not acquire focus when calling the following functions, they will behave in unexpected ways:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>WinBioEnrollBegin</term>
	/// </item>
	/// <item>
	/// <term>WinBioEnrollCapture</term>
	/// </item>
	/// <item>
	/// <term>WinBioEnrollCaptureWithCallback</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbio/nf-winbio-winbioacquirefocus HRESULT WinBioAcquireFocus();
	[DllImport(Lib_Winbio, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winbio.h", MSDNShortId = "NF:winbio.WinBioAcquireFocus")]
	public static extern HRESULT WinBioAcquireFocus();

	/// <summary>
	/// Asynchronously enumerates all attached biometric units that match the input factor type. For a synchronous version of this
	/// function, see WinBioEnumBiometricUnits. Starting with Windows 10, build 1607, this function is available to use with a mobile image.
	/// </summary>
	/// <param name="FrameworkHandle">Handle to the framework session opened by calling WinBioAsyncOpenFramework.</param>
	/// <param name="Factor">
	/// A bitmask of WINBIO_BIOMETRIC_TYPE flags that specifies the biometric unit types to be enumerated. Only
	/// <c>WINBIO_TYPE_FINGERPRINT</c> is currently supported.
	/// </param>
	/// <returns>
	/// <para>
	/// The function returns an <c>HRESULT</c> indicating success or failure. Note that success indicates only that the arguments were
	/// valid. Failures encountered during the execution of the operation will be returned asynchronously to a WINBIO_ASYNC_RESULT
	/// structure using the notification method specified in the call to WinBioAsyncOpenFramework.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_HANDLE</term>
	/// <term>You must set the FrameworkHandle argument.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>The bitmask contained in the Factor parameter contains one or more an invalid type bits.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>There was insufficient memory to complete the request.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_E_DISABLED</term>
	/// <term>Current administrative policy prohibits use of the Windows Biometric Framework API.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_E_INCORRECT_SESSION_TYPE</term>
	/// <term>The FrameworkHandle argument must represent an asynchronous framework session.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_E_SESSION_HANDLE_CLOSED</term>
	/// <term>The session handle has been marked for closure.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>WinBioAsyncEnumBiometricUnits</c> function uses a handle to the framework session opened by calling
	/// WinBioAsyncOpenFramework. The framework allocates a WINBIO_ASYNC_RESULT structure and uses it to return information about
	/// operation success or failure. If the enumeration operation is successful, the framework returns an array of schemas that include
	/// information about each enumerated biometric unit. If the operation is unsuccessful, the framework uses the
	/// <c>WINBIO_ASYNC_RESULT</c> structure to return error information. The structure is returned to the application callback or to
	/// the application message queue, depending on the value you set in the NotificationMethod parameter of the
	/// <c>WinBioAsyncOpenFramework</c> function.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// If you choose to receive completion notices by using a callback, you must implement a PWINBIO_ASYNC_COMPLETION_CALLBACK function
	/// and set the NotificationMethod parameter to <c>WINBIO_ASYNC_NOTIFY_CALLBACK</c>.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If you choose to receive completion notices by using the application message queue, you must set the NotificationMethod
	/// parameter to <c>WINBIO_ASYNC_NOTIFY_MESSAGE</c>. The framework returns a WINBIO_ASYNC_RESULT pointer to the <c>LPARAM</c> field
	/// of the window message.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// The array of schemas is returned in an <c>EnumBiometricUnits</c> structure nested inside the WINBIO_ASYNC_RESULT structure. You
	/// must call WinBioFree to release the <c>WINBIO_ASYNC_RESULT</c> structure after you have finished using it.
	/// </para>
	/// <para>Calling <c>WinBioAsyncEnumBiometricUnits</c> causes a single notification to be sent to the client application.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbio/nf-winbio-winbioasyncenumbiometricunits HRESULT
	// WinBioAsyncEnumBiometricUnits( WINBIO_FRAMEWORK_HANDLE FrameworkHandle, WINBIO_BIOMETRIC_TYPE Factor );
	[DllImport(Lib_Winbio, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winbio.h", MSDNShortId = "NF:winbio.WinBioAsyncEnumBiometricUnits")]
	public static extern HRESULT WinBioAsyncEnumBiometricUnits(WINBIO_FRAMEWORK_HANDLE FrameworkHandle, WINBIO_BIOMETRIC_TYPE Factor);

	/// <summary>
	/// Asynchronously enumerates all registered databases that match a specified type. For a synchronous version of this function, see WinBioEnumDatabases.
	/// </summary>
	/// <param name="FrameworkHandle">Handle to the framework session opened by calling WinBioAsyncOpenFramework.</param>
	/// <param name="Factor">
	/// A bitmask of WINBIO_BIOMETRIC_TYPE flags that specifies the biometric database types to be enumerated. Only
	/// <c>WINBIO_TYPE_FINGERPRINT</c> is currently supported.
	/// </param>
	/// <returns>
	/// <para>
	/// The function returns an <c>HRESULT</c> indicating success or failure. Note that success indicates only that the function's
	/// arguments were valid. Failures encountered during the execution of the operation will be returned asynchronously to a
	/// WINBIO_ASYNC_RESULT structure using the notification method specified in the call to WinBioAsyncOpenFramework.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_HANDLE</term>
	/// <term>You must set the FrameworkHandle argument.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>The bitmask contained in the Factor parameter contains one or more an invalid type bits.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>There was insufficient memory to complete the request.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_E_INCORRECT_SESSION_TYPE</term>
	/// <term>The FrameworkHandle argument must represent an asynchronous framework session.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>WinBioAsyncEnumDatabases</c> function uses a handle to the framework session opened by calling WinBioAsyncOpenFramework.
	/// The framework allocates a WINBIO_ASYNC_RESULT structure and uses it to return information about operation success or failure. If
	/// the enumeration operation is successful, the framework returns an array of schemas that include information about each
	/// enumerated database. If the operation is unsuccessful, the framework uses the <c>WINBIO_ASYNC_RESULT</c> structure to return
	/// error information. The structure is returned to the application callback or to the application message queue, depending on the
	/// value you set in the NotificationMethod parameter of the <c>WinBioAsyncOpenFramework</c> function.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// If you choose to receive completion notices by using a callback, you must implement a PWINBIO_ASYNC_COMPLETION_CALLBACK function
	/// and set the NotificationMethod parameter to <c>WINBIO_ASYNC_NOTIFY_CALLBACK</c>.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If you choose to receive completion notices by using the application message queue, you must set the NotificationMethod
	/// parameter to <c>WINBIO_ASYNC_NOTIFY_MESSAGE</c>. The framework returns a WINBIO_ASYNC_RESULT pointer to the <c>LPARAM</c> field
	/// of the window message.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// The array of schemas is returned in an <c>EnumDatabases</c> structure nested inside the WINBIO_ASYNC_RESULT structure. You must
	/// call WinBioFree to release the <c>WINBIO_ASYNC_RESULT</c> structure after you have finished using it.
	/// </para>
	/// <para>Calling <c>WinBioAsyncEnumDatabases</c> causes a single notification to be sent to the client application.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbio/nf-winbio-winbioasyncenumdatabases HRESULT WinBioAsyncEnumDatabases(
	// WINBIO_FRAMEWORK_HANDLE FrameworkHandle, WINBIO_BIOMETRIC_TYPE Factor );
	[DllImport(Lib_Winbio, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winbio.h", MSDNShortId = "NF:winbio.WinBioAsyncEnumDatabases")]
	public static extern HRESULT WinBioAsyncEnumDatabases(WINBIO_FRAMEWORK_HANDLE FrameworkHandle, WINBIO_BIOMETRIC_TYPE Factor);

	/// <summary>
	/// Asynchronously returns information about installed biometric service providers. Starting with Windows 10, build 1607, this
	/// function is available to use with a mobile image. For a synchronous version of this function, see WinBioEnumServiceProviders.
	/// </summary>
	/// <param name="FrameworkHandle">Handle to the framework session opened by calling WinBioAsyncOpenFramework.</param>
	/// <param name="Factor">
	/// A bitmask of WINBIO_BIOMETRIC_TYPE flags that specifies the biometric service provider types to be enumerated. For Windows 8,
	/// only <c>WINBIO_TYPE_FINGERPRINT</c> is supported.
	/// </param>
	/// <returns>
	/// <para>
	/// The function returns an <c>HRESULT</c> indicating success or failure. Note that success indicates only that the function's
	/// arguments were valid. Failures encountered during the execution of the operation will be returned asynchronously to a
	/// WINBIO_ASYNC_RESULT structure using the notification method specified in the call to WinBioAsyncOpenFramework.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_HANDLE</term>
	/// <term>You must set the FrameworkHandle argument.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>The bitmask contained in the Factor parameter contains one or more an invalid type bits.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>There was insufficient memory to complete the request.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_E_INCORRECT_SESSION_TYPE</term>
	/// <term>The FrameworkHandle argument must represent an asynchronous framework session.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>WinBioAsyncEnumServiceProviders</c> function uses a handle to the framework session opened by calling
	/// WinBioAsyncOpenFramework. The framework allocates a WINBIO_ASYNC_RESULT structure and uses it to return information about
	/// operation success or failure. If the enumeration operation is successful, the framework returns an array of schemas that include
	/// information about each enumerated provider. If the operation is unsuccessful, the framework uses the <c>WINBIO_ASYNC_RESULT</c>
	/// structure to return error information. The structure is returned to the application callback or to the application message
	/// queue, depending on the value you set in the NotificationMethod parameter of the <c>WinBioAsyncOpenFramework</c> function.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// If you choose to receive completion notices by using a callback, you must implement a PWINBIO_ASYNC_COMPLETION_CALLBACK function
	/// and set the NotificationMethod parameter to <c>WINBIO_ASYNC_NOTIFY_CALLBACK</c>.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If you choose to receive completion notices by using the application message queue, you must set the NotificationMethod
	/// parameter to <c>WINBIO_ASYNC_NOTIFY_MESSAGE</c>. The framework returns a WINBIO_ASYNC_RESULT pointer to the <c>LPARAM</c> field
	/// of the window message.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// The array of schemas is returned in an <c>EnumServiceProviders</c> structure nested inside the WINBIO_ASYNC_RESULT structure.
	/// You must call WinBioFree to release the <c>WINBIO_ASYNC_RESULT</c> structure after you have finished using it.
	/// </para>
	/// <para>Calling <c>WinBioAsyncEnumServiceProviders</c> causes a single notification to be sent to the client application.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbio/nf-winbio-winbioasyncenumserviceproviders HRESULT
	// WinBioAsyncEnumServiceProviders( WINBIO_FRAMEWORK_HANDLE FrameworkHandle, WINBIO_BIOMETRIC_TYPE Factor );
	[DllImport(Lib_Winbio, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winbio.h", MSDNShortId = "NF:winbio.WinBioAsyncEnumServiceProviders")]
	public static extern HRESULT WinBioAsyncEnumServiceProviders(WINBIO_FRAMEWORK_HANDLE FrameworkHandle, WINBIO_BIOMETRIC_TYPE Factor);

	/// <summary>
	/// Starts an asynchronous monitor of changes to the biometric framework. Currently, the only monitored changes that are supported
	/// occur when a biometric unit is attached to or detached from the computer.
	/// </summary>
	/// <param name="FrameworkHandle">Handle to the framework session opened by calling WinBioAsyncOpenFramework.</param>
	/// <param name="ChangeTypes">
	/// <para>
	/// A bitmask of type <c>WINBIO_FRAMEWORK_CHANGE_TYPE</c> flags that indicates the types of events that should generate asynchronous
	/// notifications. Beginning with Windows 8, the following flag is available:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>WINBIO_FRAMEWORK_CHANGE_UNIT</term>
	/// <term>A biometric unit has been attached to or detached from the computer.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>
	/// The function returns an <c>HRESULT</c> indicating success or failure. Note that success indicates only that the function
	/// arguments were valid. Failures encountered during the execution of the operation will be returned asynchronously to a
	/// WINBIO_ASYNC_RESULT structure using the notification method specified in WinBioAsyncOpenFramework.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_HANDLE</term>
	/// <term>You must set the FrameworkHandle argument.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>
	/// The bitmask contained in the ChangeTypes parameter contains one or more an invalid type bits. Currently, the only available
	/// value is WINBIO_FRAMEWORK_CHANGE_UNIT.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WINBIO_E_INCORRECT_SESSION_TYPE</term>
	/// <term>The FrameworkHandle argument must represent an asynchronous framework session.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Once started, this monitor will continue generating events until the client application calls WinBioCancel or
	/// WinBioCloseFramework. Creating a monitor for <c>WINBIO_FRAMEWORK_CHANGE_UNIT</c> events will generate two types of asynchronous notifications:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>WINBIO_OPERATION_UNIT_ARRIVAL</term>
	/// <term>A biometric unit is attached.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_OPERATION_UNIT_REMOVAL</term>
	/// <term>A biometric unit is detached.</term>
	/// </item>
	/// </list>
	/// <para>
	/// The <c>WinBioAsyncMonitorFrameworkChanges</c> function uses a handle to the framework session opened by calling
	/// WinBioAsyncOpenFramework. The framework allocates a WINBIO_ASYNC_RESULT structure and uses it to return information about
	/// operation success or failure. If a biometric unit is attached to or detached from the computer, the framework sets the
	/// <c>Operation</c> member of the structure. If a problem is encountered during the operation, the framework uses the
	/// <c>WINBIO_ASYNC_RESULT</c> structure to return error information. The structure is returned to the application callback or to
	/// the application message queue, depending on the value you set in the NotificationMethod parameter of the
	/// <c>WinBioAsyncOpenFramework</c> function.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// If you choose to receive completion notices by using a callback, you must implement a PWINBIO_ASYNC_COMPLETION_CALLBACK function
	/// and set the NotificationMethod parameter to <c>WINBIO_ASYNC_NOTIFY_CALLBACK</c>.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If you choose to receive completion notices by using the application message queue, you must set the NotificationMethod
	/// parameter to <c>WINBIO_ASYNC_NOTIFY_MESSAGE</c>. The framework returns a WINBIO_ASYNC_RESULT pointer to the <c>LPARAM</c> field
	/// of the window message.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// Notifications are returned in an <c>EnumServiceProviders</c> structure nested inside the WINBIO_ASYNC_RESULT structure. You must
	/// call WinBioFree to release the <c>WINBIO_ASYNC_RESULT</c> structure after you have finished using it.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbio/nf-winbio-winbioasyncmonitorframeworkchanges HRESULT
	// WinBioAsyncMonitorFrameworkChanges( WINBIO_FRAMEWORK_HANDLE FrameworkHandle, WINBIO_FRAMEWORK_CHANGE_TYPE ChangeTypes );
	[DllImport(Lib_Winbio, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winbio.h", MSDNShortId = "NF:winbio.WinBioAsyncMonitorFrameworkChanges")]
	public static extern HRESULT WinBioAsyncMonitorFrameworkChanges(WINBIO_FRAMEWORK_HANDLE FrameworkHandle, WINBIO_FRAMEWORK_CHANGE_TYPE ChangeTypes);

	/// <summary>
	/// Opens a handle to the biometric framework. Starting with Windows 10, build 1607, this function is available to use with a mobile
	/// image. You can use this handle to asynchronously enumerate biometric units, databases, and service providers and to receive
	/// asynchronous notification when biometric units are attached to the computer or removed.
	/// </summary>
	/// <param name="NotificationMethod">
	/// <para>
	/// Specifies how completion notifications for asynchronous operations in this framework session are to be delivered to the client
	/// application. This must be one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>WINBIO_ASYNC_NOTIFY_CALLBACK</term>
	/// <term>The framework invokes the callback function defined by the application.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_ASYNC_NOTIFY_MESSAGE</term>
	/// <term>The framework posts a window message to the application's message queue.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="TargetWindow">
	/// Handle of the window that will receive the completion notices. This value is ignored unless the NotificationMethod parameter is
	/// set to <c>WINBIO_ASYNC_NOTIFY_MESSAGE</c>.
	/// </param>
	/// <param name="MessageCode">
	/// <para>
	/// Window message code the framework must send to signify completion notices. This value is ignored unless the NotificationMethod
	/// parameter is set to <c>WINBIO_ASYNC_NOTIFY_MESSAGE</c>. The value must be within the range WM_APP (0x8000) to 0xBFFF.
	/// </para>
	/// <para>
	/// The Windows Biometric Framework sets the <c>LPARAM</c> value of the message to the address of the WINBIO_ASYNC_RESULT structure
	/// that contains the results of the operation. You must call WinBioFree to release the structure after you have finished using it.
	/// </para>
	/// </param>
	/// <param name="CallbackRoutine">
	/// Address of the callback routine to be invoked for completion notices. This value is ignored unless the NotificationMethod
	/// parameter is set to <c>WINBIO_ASYNC_NOTIFY_CALLBACK</c>.
	/// </param>
	/// <param name="UserData">
	/// Address of a buffer supplied by the caller. The buffer is not modified by the framework or the biometric unit. It is returned in
	/// the WINBIO_ASYNC_RESULT structure. Your application can use the data to help it determine what actions to perform upon receipt
	/// of the completion notice or to maintain additional information about the requested operation.
	/// </param>
	/// <param name="AsynchronousOpen">
	/// <para>
	/// Specifies whether to block until the framework session has been opened. Specifying <c>FALSE</c> causes the process to block.
	/// Specifying <c>TRUE</c> causes the session to be opened asynchronously.
	/// </para>
	/// <para>
	/// If you specify <c>FALSE</c> to open the framework session synchronously, success or failure is returned to the caller directly
	/// by this function in the <c>HRESULT</c> return value. If the session is opened successfully, the first asynchronous completion
	/// event your application receives will be for an asynchronous operation requested after the framework has been open.
	/// </para>
	/// <para>
	/// If you specify <c>TRUE</c> to open the framework session asynchronously, the first asynchronous completion notice received will
	/// be for opening the framework. If the NotificationMethod parameter is set to <c>WINBIO_ASYNC_NOTIFY_CALLBACK</c>, operation
	/// results are delivered to the WINBIO_ASYNC_RESULT structure in the callback function specified by the CallbackRoutine parameter.
	/// If the NotificationMethod parameter is set to <c>WINBIO_ASYNC_NOTIFY_MESSAGE</c>, operation results are delivered to the
	/// <c>WINBIO_ASYNC_RESULT</c> structure pointed to by the <c>LPARAM</c> field of the window message.
	/// </para>
	/// </param>
	/// <param name="FrameworkHandle">
	/// <para>If the function does not succeed, this parameter will be <c>NULL</c>.</para>
	/// <para>If the session is opened synchronously and successfully, this parameter will contain a pointer to the session handle.</para>
	/// <para>
	/// If you specify that the session be opened asynchronously, this method returns immediately, the session handle will be
	/// <c>NULL</c>, and you must examine the WINBIO_ASYNC_RESULT structure to determine whether the session was successfully opened.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, it returns <c>S_OK</c>. If the function fails, it returns an <c>HRESULT</c> value that indicates the
	/// error. Possible values include, but are not limited to, those in the following table. For a list of common error codes, see
	/// Common HRESULT Values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>There is not enough memory available to create the framework session.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>
	/// If you set the notification method to WINBIO_ASYNC_NOTIFY_MESSAGE, the TargetWindow parameter cannot be NULL or HWND_BROADCAST
	/// and the MessageCode parameter cannot be zero (0).
	/// </term>
	/// </item>
	/// <item>
	/// <term>E_POINTER</term>
	/// <term>
	/// The FrameworkHandle parameter and the AsynchronousOpen parameter must be set. If you set the notification method to
	/// WINBIO_ASYNC_NOTIFY_CALLBACK, you must also specify the address of a callback function in the CallbackRoutine parameter.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The framework handle returned by the <c>WinBioAsyncOpenFramework</c> function can be used to generate asynchronous completion
	/// notifications for the following functions:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>WinBioAsyncEnumBiometricUnits</term>
	/// </item>
	/// <item>
	/// <term>WinBioAsyncEnumDatabases</term>
	/// </item>
	/// <item>
	/// <term>WinBioAsyncEnumServiceProviders</term>
	/// </item>
	/// <item>
	/// <term>WinBioAsyncMonitorFrameworkChanges</term>
	/// </item>
	/// </list>
	/// <para>
	/// The AsynchronousOpen parameter determines only whether the open operation will block. This parameter has no effect on the
	/// completion behavior of subsequent calls that use the session handle.
	/// </para>
	/// <para>
	/// If you set the AsynchronousOpen parameter to <c>TRUE</c>, this function will return <c>S_OK</c> as soon as it has performed an
	/// initial validation of the arguments. Any errors detected beyond that point will be reported to the caller using the method
	/// specified by the NotificationMethod parameter. That is, a successful return value indicates only that the
	/// <c>WinBioAsyncOpenFramework</c> parameters were fine and not that the open operation succeeded. To determine whether the open
	/// operation succeeded, you must examine the WINBIO_ASYNC_RESULT structure.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbio/nf-winbio-winbioasyncopenframework HRESULT WinBioAsyncOpenFramework(
	// WINBIO_ASYNC_NOTIFICATION_METHOD NotificationMethod, HWND TargetWindow, UINT MessageCode, PWINBIO_ASYNC_COMPLETION_CALLBACK
	// CallbackRoutine, PVOID UserData, BOOL AsynchronousOpen, WINBIO_FRAMEWORK_HANDLE *FrameworkHandle );
	[DllImport(Lib_Winbio, SetLastError = false, ExactSpelling = true, CallingConvention = CallingConvention.Winapi)]
	[PInvokeData("winbio.h", MSDNShortId = "NF:winbio.WinBioAsyncOpenFramework")]
	public static extern HRESULT WinBioAsyncOpenFramework(WINBIO_ASYNC_NOTIFICATION_METHOD NotificationMethod, [In, Optional] HWND TargetWindow, [In, Optional] uint MessageCode,
		/*[In, Optional, MarshalAs(UnmanagedType.FunctionPtr)] PWINBIO_ASYNC_COMPLETION_CALLBACK*/ [In, Optional] IntPtr CallbackRoutine, [In, Optional] IntPtr UserData,
		[MarshalAs(UnmanagedType.Bool)] bool AsynchronousOpen, out WINBIO_FRAMEWORK_HANDLE FrameworkHandle);

	/// <summary>
	/// Opens a handle to the biometric framework. Starting with Windows 10, build 1607, this function is available to use with a mobile
	/// image. You can use this handle to asynchronously enumerate biometric units, databases, and service providers and to receive
	/// asynchronous notification when biometric units are attached to the computer or removed.
	/// </summary>
	/// <param name="NotificationMethod">
	/// <para>
	/// Specifies how completion notifications for asynchronous operations in this framework session are to be delivered to the client
	/// application. This must be one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>WINBIO_ASYNC_NOTIFY_CALLBACK</term>
	/// <term>The framework invokes the callback function defined by the application.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_ASYNC_NOTIFY_MESSAGE</term>
	/// <term>The framework posts a window message to the application's message queue.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="TargetWindow">
	/// Handle of the window that will receive the completion notices. This value is ignored unless the NotificationMethod parameter is
	/// set to <c>WINBIO_ASYNC_NOTIFY_MESSAGE</c>.
	/// </param>
	/// <param name="MessageCode">
	/// <para>
	/// Window message code the framework must send to signify completion notices. This value is ignored unless the NotificationMethod
	/// parameter is set to <c>WINBIO_ASYNC_NOTIFY_MESSAGE</c>. The value must be within the range WM_APP (0x8000) to 0xBFFF.
	/// </para>
	/// <para>
	/// The Windows Biometric Framework sets the <c>LPARAM</c> value of the message to the address of the WINBIO_ASYNC_RESULT structure
	/// that contains the results of the operation. You must call WinBioFree to release the structure after you have finished using it.
	/// </para>
	/// </param>
	/// <param name="CallbackRoutine">
	/// Address of the callback routine to be invoked for completion notices. This value is ignored unless the NotificationMethod
	/// parameter is set to <c>WINBIO_ASYNC_NOTIFY_CALLBACK</c>.
	/// </param>
	/// <param name="UserData">
	/// Address of a buffer supplied by the caller. The buffer is not modified by the framework or the biometric unit. It is returned in
	/// the WINBIO_ASYNC_RESULT structure. Your application can use the data to help it determine what actions to perform upon receipt
	/// of the completion notice or to maintain additional information about the requested operation.
	/// </param>
	/// <param name="AsynchronousOpen">
	/// <para>
	/// Specifies whether to block until the framework session has been opened. Specifying <c>FALSE</c> causes the process to block.
	/// Specifying <c>TRUE</c> causes the session to be opened asynchronously.
	/// </para>
	/// <para>
	/// If you specify <c>FALSE</c> to open the framework session synchronously, success or failure is returned to the caller directly
	/// by this function in the <c>HRESULT</c> return value. If the session is opened successfully, the first asynchronous completion
	/// event your application receives will be for an asynchronous operation requested after the framework has been open.
	/// </para>
	/// <para>
	/// If you specify <c>TRUE</c> to open the framework session asynchronously, the first asynchronous completion notice received will
	/// be for opening the framework. If the NotificationMethod parameter is set to <c>WINBIO_ASYNC_NOTIFY_CALLBACK</c>, operation
	/// results are delivered to the WINBIO_ASYNC_RESULT structure in the callback function specified by the CallbackRoutine parameter.
	/// If the NotificationMethod parameter is set to <c>WINBIO_ASYNC_NOTIFY_MESSAGE</c>, operation results are delivered to the
	/// <c>WINBIO_ASYNC_RESULT</c> structure pointed to by the <c>LPARAM</c> field of the window message.
	/// </para>
	/// </param>
	/// <param name="FrameworkHandle">
	/// <para>If the function does not succeed, this parameter will be <c>NULL</c>.</para>
	/// <para>If the session is opened synchronously and successfully, this parameter will contain a pointer to the session handle.</para>
	/// <para>
	/// If you specify that the session be opened asynchronously, this method returns immediately, the session handle will be
	/// <c>NULL</c>, and you must examine the WINBIO_ASYNC_RESULT structure to determine whether the session was successfully opened.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, it returns <c>S_OK</c>. If the function fails, it returns an <c>HRESULT</c> value that indicates the
	/// error. Possible values include, but are not limited to, those in the following table. For a list of common error codes, see
	/// Common HRESULT Values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>There is not enough memory available to create the framework session.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>
	/// If you set the notification method to WINBIO_ASYNC_NOTIFY_MESSAGE, the TargetWindow parameter cannot be NULL or HWND_BROADCAST
	/// and the MessageCode parameter cannot be zero (0).
	/// </term>
	/// </item>
	/// <item>
	/// <term>E_POINTER</term>
	/// <term>
	/// The FrameworkHandle parameter and the AsynchronousOpen parameter must be set. If you set the notification method to
	/// WINBIO_ASYNC_NOTIFY_CALLBACK, you must also specify the address of a callback function in the CallbackRoutine parameter.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The framework handle returned by the <c>WinBioAsyncOpenFramework</c> function can be used to generate asynchronous completion
	/// notifications for the following functions:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>WinBioAsyncEnumBiometricUnits</term>
	/// </item>
	/// <item>
	/// <term>WinBioAsyncEnumDatabases</term>
	/// </item>
	/// <item>
	/// <term>WinBioAsyncEnumServiceProviders</term>
	/// </item>
	/// <item>
	/// <term>WinBioAsyncMonitorFrameworkChanges</term>
	/// </item>
	/// </list>
	/// <para>
	/// The AsynchronousOpen parameter determines only whether the open operation will block. This parameter has no effect on the
	/// completion behavior of subsequent calls that use the session handle.
	/// </para>
	/// <para>
	/// If you set the AsynchronousOpen parameter to <c>TRUE</c>, this function will return <c>S_OK</c> as soon as it has performed an
	/// initial validation of the arguments. Any errors detected beyond that point will be reported to the caller using the method
	/// specified by the NotificationMethod parameter. That is, a successful return value indicates only that the
	/// <c>WinBioAsyncOpenFramework</c> parameters were fine and not that the open operation succeeded. To determine whether the open
	/// operation succeeded, you must examine the WINBIO_ASYNC_RESULT structure.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbio/nf-winbio-winbioasyncopenframework HRESULT WinBioAsyncOpenFramework(
	// WINBIO_ASYNC_NOTIFICATION_METHOD NotificationMethod, HWND TargetWindow, UINT MessageCode, PWINBIO_ASYNC_COMPLETION_CALLBACK
	// CallbackRoutine, PVOID UserData, BOOL AsynchronousOpen, WINBIO_FRAMEWORK_HANDLE *FrameworkHandle );
	[DllImport(Lib_Winbio, SetLastError = false, ExactSpelling = true, CallingConvention = CallingConvention.Winapi)]
	[PInvokeData("winbio.h", MSDNShortId = "NF:winbio.WinBioAsyncOpenFramework")]
	public static extern HRESULT WinBioAsyncOpenFramework(WINBIO_ASYNC_NOTIFICATION_METHOD NotificationMethod, [In, Optional] HWND TargetWindow, [In, Optional] uint MessageCode,
		[In, Optional, MarshalAs(UnmanagedType.FunctionPtr)] PWINBIO_ASYNC_COMPLETION_CALLBACK? CallbackRoutine, [In, Optional] IntPtr UserData,
		[MarshalAs(UnmanagedType.Bool)] bool AsynchronousOpen, out WINBIO_FRAMEWORK_HANDLE FrameworkHandle);

	/// <summary>
	/// <para>
	/// Asynchronously connects to a biometric service provider and one or more biometric units. Starting with Windows 10, build 1607,
	/// this function is available to use with a mobile image. If successful, the function returns a biometric session handle. Every
	/// operation performed by using this handle will be completed asynchronously, including WinBioCloseSession, and the results will be
	/// returned to the client application by using the method specified in the NotificationMethod parameter.
	/// </para>
	/// <para>For a synchronous version of this function, see WinBioOpenSession.</para>
	/// </summary>
	/// <param name="Factor">
	/// A bitmask of WINBIO_BIOMETRIC_TYPE flags that specifies the biometric unit types to be enumerated. Only
	/// <c>WINBIO_TYPE_FINGERPRINT</c> is currently supported.
	/// </param>
	/// <param name="PoolType">
	/// <para>
	/// A <c>ULONG</c> value that specifies the type of the biometric units that will be used in the session. This can be one of the
	/// following values:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>WINBIO_POOL_SYSTEM</term>
	/// <term>The session connects to a shared collection of biometric units managed by the service provider.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_POOL_PRIVATE</term>
	/// <term>The session connects to a collection of biometric units that are managed by the caller.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="Flags">
	/// <para>
	/// A <c>ULONG</c> value that specifies biometric unit configuration and access characteristics for the new session. Configuration
	/// flags specify the general configuration of units in the session. Access flags specify how the application will use the biometric
	/// units. You must specify one configuration flag but you can combine that flag with any access flag.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>WINBIO_FLAG_DEFAULT</term>
	/// <term>
	/// Group: configuration The biometric units operate in the manner specified during installation. You must use this value when the
	///        PoolType parameter is WINBIO_POOL_SYSTEM.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FLAG_BASIC</term>
	/// <term>
	/// Group: configuration The biometric units operate only as basic capture devices. All processing, matching, and storage operations
	///        is performed by software plug-ins.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FLAG_ADVANCED</term>
	/// <term>Group: configuration The biometric units use internal processing and storage capabilities.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FLAG_RAW</term>
	/// <term>Group: access The client application captures raw biometric data using WinBioCaptureSample.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FLAG_MAINTENANCE</term>
	/// <term>Group: access The client performs vendor-defined control operations on a biometric unit by calling WinBioControlUnitPrivileged.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="UnitArray">
	/// Pointer to an array of biometric unit identifiers to be included in the session. You can call WinBioEnumBiometricUnits to
	/// enumerate the biometric units. Set this value to <c>NULL</c> if the PoolType parameter is <c>WINBIO_POOL_SYSTEM</c>.
	/// </param>
	/// <param name="UnitCount">
	/// A value that specifies the number of elements in the array pointed to by the UnitArray parameter. Set this value to zero if the
	/// PoolType parameter is <c>WINBIO_POOL_SYSTEM</c>.
	/// </param>
	/// <param name="DatabaseId">
	/// <para>
	/// A value that specifies the database(s) to be used by the session. If the PoolType parameter is <c>WINBIO_POOL_PRIVATE</c>, you
	/// must specify the GUID of an installed database. If the PoolType parameter is not <c>WINBIO_POOL_PRIVATE</c>, you can specify one
	/// of the following common values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>WINBIO_DB_DEFAULT</term>
	/// <term>
	/// Each biometric unit in the sensor pool uses the default database specified in the default biometric unit configuration. You must
	/// specify this value if the PoolType parameter is WINBIO_POOL_SYSTEM. You cannot use this value if the PoolType parameter is WINBIO_POOL_PRIVATE
	/// </term>
	/// </item>
	/// <item>
	/// <term>WINBIO_DB_BOOTSTRAP</term>
	/// <term>
	/// You can specify this value to be used for scenarios prior to starting Windows. Typically, the database is part of the sensor
	/// chip or is part of the BIOS and can only be used for template enrollment and deletion.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WINBIO_DB_ONCHIP</term>
	/// <term>The database is on the sensor chip and is available for enrollment and matching.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="NotificationMethod">
	/// <para>
	/// Specifies how completion notifications for asynchronous operations in this biometric session are to be delivered to the client
	/// application. This must be one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>WINBIO_ASYNC_NOTIFY_CALLBACK</term>
	/// <term>The session invokes the callback function defined by the application.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_ASYNC_NOTIFY_MESSAGE</term>
	/// <term>The session posts a window message to the application's message queue.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="TargetWindow">
	/// Handle of the window that will receive the completion notices. This value is ignored unless the NotificationMethod parameter is
	/// set to <c>WINBIO_ASYNC_NOTIFY_MESSAGE</c>.
	/// </param>
	/// <param name="MessageCode">
	/// <para>
	/// Window message code the framework must send to signify completion notices. This value is ignored unless the NotificationMethod
	/// parameter is set to <c>WINBIO_ASYNC_NOTIFY_MESSAGE</c>. The value must be within the range WM_APP(0x8000) to 0xBFFF.
	/// </para>
	/// <para>
	/// The Windows Biometric Framework sets the <c>LPARAM</c> value of the message to the address of the WINBIO_ASYNC_RESULT structure
	/// that contains the results of the operation. You must call WinBioFree to release the structure after you have finished using it.
	/// </para>
	/// </param>
	/// <param name="CallbackRoutine">
	/// Address of callback routine to be invoked when the operation started by using the session handle completes. This value is
	/// ignored unless the NotificationMethod parameter is set to <c>WINBIO_ASYNC_NOTIFY_CALLBACK</c>.
	/// </param>
	/// <param name="UserData">
	/// Address of a buffer supplied by the caller. The buffer is not modified by the framework or the biometric unit. It is returned in
	/// the WINBIO_ASYNC_RESULT structure. Your application can use the data to help it determine what actions to perform upon receipt
	/// of the completion notice or to maintain additional information about the requested operation.
	/// </param>
	/// <param name="AsynchronousOpen">
	/// <para>
	/// Specifies whether to block until the framework session has been opened. Specifying <c>FALSE</c> causes the process to block.
	/// Specifying <c>TRUE</c> causes the session to be opened asynchronously.
	/// </para>
	/// <para>
	/// If you specify <c>FALSE</c> to open the framework session synchronously, success or failure is returned to the caller directly
	/// by this function in the <c>HRESULT</c> return value. If the session is opened successfully, the first asynchronous completion
	/// event your application receives will be for an asynchronous operation requested after the framework has been open.
	/// </para>
	/// <para>
	/// If you specify <c>TRUE</c> to open the framework session asynchronously, the first asynchronous completion notice received will
	/// be for opening the framework. If the NotificationMethod parameter is set to <c>WINBIO_ASYNC_NOTIFY_CALLBACK</c>, operation
	/// results are delivered to the WINBIO_ASYNC_RESULT structure in the callback function specified by the CallbackRoutine parameter.
	/// If the NotificationMethod parameter is set to <c>WINBIO_ASYNC_NOTIFY_MESSAGE</c>, operation results are delivered to the
	/// <c>WINBIO_ASYNC_RESULT</c> structure pointed to by the LPARAM field of the window message.
	/// </para>
	/// </param>
	/// <param name="SessionHandle">
	/// <para>If the function does not succeed, this parameter will be <c>NULL</c>.</para>
	/// <para>If the session is opened synchronously and successfully, this parameter will contain a pointer to the session handle.</para>
	/// <para>
	/// If you specify that the session be opened asynchronously, this method returns immediately, the session handle will be
	/// <c>NULL</c>, and you must examine the WINBIO_ASYNC_RESULT structure to determine whether the session was successfully opened.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, it returns <c>S_OK</c>. If the function fails, it returns an <c>HRESULT</c> value that indicates the
	/// error. Possible values include, but are not limited to, those in the following table. For a list of common error codes, see
	/// Common HRESULT Values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>There is not enough memory available to create the biometric session.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>
	/// If you set the notification method to WINBIO_ASYNC_NOTIFY_MESSAGE, the TargetWindow parameter cannot be NULL or HWND_BROADCAST
	/// and the MessageCode parameter cannot be zero (0).
	/// </term>
	/// </item>
	/// <item>
	/// <term>E_POINTER</term>
	/// <term>
	/// The SessionHandle parameter and the AsynchronousOpen parameter must be set. If you set the notification method to
	/// WINBIO_ASYNC_NOTIFY_CALLBACK, you must also specify the address of a callback function in the CallbackRoutine parameter.
	/// </term>
	/// </item>
	/// <item>
	/// <term>E_ACCESSDENIED</term>
	/// <term>
	/// The Flags parameter contains the WINBIO_FLAG_RAW or the WINBIO_FLAG_MAINTENANCE flag and the caller has not been granted either
	/// access permission.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WINBIO_E_INVALID_UNIT</term>
	/// <term>One or more of the biometric unit numbers specified in the UnitArray parameter is not valid.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_E_NOT_ACTIVE_CONSOLE</term>
	/// <term>The client application is running on a remote desktop client and is attempting to open a system pool session.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_E_SENSOR_UNAVAILABLE</term>
	/// <term>The PoolType parameter is set to WINBIO_POOL_PRIVATE and one or more of the requested sensors in that pool is not available.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_E_DISABLED</term>
	/// <term>Current administrative policy prohibits use of the Windows Biometric Framework API.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The session handle returned by the <c>WinBioAsyncOpenSession</c> function can be used to generate asynchronous completion
	/// notifications for any of the following functions:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>WinBioCancel</term>
	/// </item>
	/// <item>
	/// <term>WinBioCaptureSample</term>
	/// </item>
	/// <item>
	/// <term>WinBioCloseSession</term>
	/// </item>
	/// <item>
	/// <term>WinBioControlUnit</term>
	/// </item>
	/// <item>
	/// <term>WinBioControlUnitPrivileged</term>
	/// </item>
	/// <item>
	/// <term>WinBioDeleteTemplate</term>
	/// </item>
	/// <item>
	/// <term>WinBioEnrollBegin</term>
	/// </item>
	/// <item>
	/// <term>WinBioEnrollCapture</term>
	/// </item>
	/// <item>
	/// <term>WinBioEnrollCommit</term>
	/// </item>
	/// <item>
	/// <term>WinBioEnrollDiscard</term>
	/// </item>
	/// <item>
	/// <term>WinBioEnumEnrollments</term>
	/// </item>
	/// <item>
	/// <term>WinBioGetProperty</term>
	/// </item>
	/// <item>
	/// <term>WinBioIdentify</term>
	/// </item>
	/// <item>
	/// <term>WinBioLocateSensor</term>
	/// </item>
	/// <item>
	/// <term>WinBioLockUnit</term>
	/// </item>
	/// <item>
	/// <term>WinBioLogonIdentifiedUser</term>
	/// </item>
	/// <item>
	/// <term>WinBioRegisterEventMonitor</term>
	/// </item>
	/// <item>
	/// <term>WinBioUnlockUnit</term>
	/// </item>
	/// <item>
	/// <term>WinBioUnregisterEventMonitor</term>
	/// </item>
	/// <item>
	/// <term>WinBioVerify</term>
	/// </item>
	/// <item>
	/// <term>WinBioWait</term>
	/// </item>
	/// </list>
	/// <para>The session handle returned by <c>WinBioAsyncOpenSession</c> cannot be used with the following functions:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>WinBioCaptureSampleWithCallback</term>
	/// </item>
	/// <item>
	/// <term>WinBioEnrollCaptureWithCallback</term>
	/// </item>
	/// <item>
	/// <term>WinBioIdentifyWithCallback</term>
	/// </item>
	/// <item>
	/// <term>WinBioIdentifyWithCallback</term>
	/// </item>
	/// </list>
	/// <para>
	/// These functions, first available in Windows 7, have an incompatible callback signature, and their use in new applications is
	/// discouraged. Developers who want asynchronous callbacks should instead use <c>WinBioAsyncOpenSession</c> with a
	/// NotificationMethod of <c>WINBIO_ASYNC_NOTIFY_CALLBACK</c>.
	/// </para>
	/// <para>
	/// The AsynchronousOpen parameter determines only whether the open operation will block. This parameter has no effect on the
	/// completion behavior of subsequent calls that use the session handle.
	/// </para>
	/// <para>
	/// If you set the AsynchronousOpen parameter to <c>TRUE</c>, this function will return <c>S_OK</c> as soon as it has performed an
	/// initial validation of the arguments. Any errors detected beyond that point will be reported to the caller using the method
	/// specified by the NotificationMethod parameter. That is, a successful return value indicates only that the
	/// <c>WinBioAsyncOpenSession</c> parameters were fine and not that the open operation succeeded. To determine whether the open
	/// operation succeeded, you must examine the WINBIO_ASYNC_RESULT structure.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbio/nf-winbio-winbioasyncopensession HRESULT WinBioAsyncOpenSession(
	// WINBIO_BIOMETRIC_TYPE Factor, WINBIO_POOL_TYPE PoolType, WINBIO_SESSION_FLAGS Flags, WINBIO_UNIT_ID *UnitArray, SIZE_T UnitCount,
	// GUID *DatabaseId, WINBIO_ASYNC_NOTIFICATION_METHOD NotificationMethod, HWND TargetWindow, UINT MessageCode,
	// PWINBIO_ASYNC_COMPLETION_CALLBACK CallbackRoutine, PVOID UserData, BOOL AsynchronousOpen, WINBIO_SESSION_HANDLE *SessionHandle );
	[DllImport(Lib_Winbio, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winbio.h", MSDNShortId = "NF:winbio.WinBioAsyncOpenSession")]
	public static extern HRESULT WinBioAsyncOpenSession(WINBIO_BIOMETRIC_TYPE Factor, WINBIO_POOL_TYPE PoolType, WINBIO_SESSION_FLAGS Flags,
		[In, Optional, MarshalAs(UnmanagedType.LPArray)] uint[]? UnitArray, [Optional] SIZE_T UnitCount, in Guid DatabaseId,
		WINBIO_ASYNC_NOTIFICATION_METHOD NotificationMethod, [In, Optional] HWND TargetWindow,
		[In, Optional] uint MessageCode, [In, Optional] PWINBIO_ASYNC_COMPLETION_CALLBACK? CallbackRoutine,
		[In, Optional] IntPtr UserData, [MarshalAs(UnmanagedType.Bool)] bool AsynchronousOpen,
		out WINBIO_SESSION_HANDLE SessionHandle);

	/// <summary>
	/// <para>
	/// Asynchronously connects to a biometric service provider and one or more biometric units. Starting with Windows 10, build 1607,
	/// this function is available to use with a mobile image. If successful, the function returns a biometric session handle. Every
	/// operation performed by using this handle will be completed asynchronously, including WinBioCloseSession, and the results will be
	/// returned to the client application by using the method specified in the NotificationMethod parameter.
	/// </para>
	/// <para>For a synchronous version of this function, see WinBioOpenSession.</para>
	/// </summary>
	/// <param name="Factor">
	/// A bitmask of WINBIO_BIOMETRIC_TYPE flags that specifies the biometric unit types to be enumerated. Only
	/// <c>WINBIO_TYPE_FINGERPRINT</c> is currently supported.
	/// </param>
	/// <param name="PoolType">
	/// <para>
	/// A <c>ULONG</c> value that specifies the type of the biometric units that will be used in the session. This can be one of the
	/// following values:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>WINBIO_POOL_SYSTEM</term>
	/// <term>The session connects to a shared collection of biometric units managed by the service provider.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_POOL_PRIVATE</term>
	/// <term>The session connects to a collection of biometric units that are managed by the caller.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="Flags">
	/// <para>
	/// A <c>ULONG</c> value that specifies biometric unit configuration and access characteristics for the new session. Configuration
	/// flags specify the general configuration of units in the session. Access flags specify how the application will use the biometric
	/// units. You must specify one configuration flag but you can combine that flag with any access flag.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>WINBIO_FLAG_DEFAULT</term>
	/// <term>
	/// Group: configuration The biometric units operate in the manner specified during installation. You must use this value when the
	///        PoolType parameter is WINBIO_POOL_SYSTEM.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FLAG_BASIC</term>
	/// <term>
	/// Group: configuration The biometric units operate only as basic capture devices. All processing, matching, and storage operations
	///        is performed by software plug-ins.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FLAG_ADVANCED</term>
	/// <term>Group: configuration The biometric units use internal processing and storage capabilities.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FLAG_RAW</term>
	/// <term>Group: access The client application captures raw biometric data using WinBioCaptureSample.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FLAG_MAINTENANCE</term>
	/// <term>Group: access The client performs vendor-defined control operations on a biometric unit by calling WinBioControlUnitPrivileged.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="UnitArray">
	/// Pointer to an array of biometric unit identifiers to be included in the session. You can call WinBioEnumBiometricUnits to
	/// enumerate the biometric units. Set this value to <c>NULL</c> if the PoolType parameter is <c>WINBIO_POOL_SYSTEM</c>.
	/// </param>
	/// <param name="UnitCount">
	/// A value that specifies the number of elements in the array pointed to by the UnitArray parameter. Set this value to zero if the
	/// PoolType parameter is <c>WINBIO_POOL_SYSTEM</c>.
	/// </param>
	/// <param name="DatabaseId">
	/// <para>
	/// A value that specifies the database(s) to be used by the session. If the PoolType parameter is <c>WINBIO_POOL_PRIVATE</c>, you
	/// must specify the GUID of an installed database. If the PoolType parameter is not <c>WINBIO_POOL_PRIVATE</c>, you can specify one
	/// of the following common values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>WINBIO_DB_DEFAULT</term>
	/// <term>
	/// Each biometric unit in the sensor pool uses the default database specified in the default biometric unit configuration. You must
	/// specify this value if the PoolType parameter is WINBIO_POOL_SYSTEM. You cannot use this value if the PoolType parameter is WINBIO_POOL_PRIVATE
	/// </term>
	/// </item>
	/// <item>
	/// <term>WINBIO_DB_BOOTSTRAP</term>
	/// <term>
	/// You can specify this value to be used for scenarios prior to starting Windows. Typically, the database is part of the sensor
	/// chip or is part of the BIOS and can only be used for template enrollment and deletion.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WINBIO_DB_ONCHIP</term>
	/// <term>The database is on the sensor chip and is available for enrollment and matching.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="NotificationMethod">
	/// <para>
	/// Specifies how completion notifications for asynchronous operations in this biometric session are to be delivered to the client
	/// application. This must be one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>WINBIO_ASYNC_NOTIFY_CALLBACK</term>
	/// <term>The session invokes the callback function defined by the application.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_ASYNC_NOTIFY_MESSAGE</term>
	/// <term>The session posts a window message to the application's message queue.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="TargetWindow">
	/// Handle of the window that will receive the completion notices. This value is ignored unless the NotificationMethod parameter is
	/// set to <c>WINBIO_ASYNC_NOTIFY_MESSAGE</c>.
	/// </param>
	/// <param name="MessageCode">
	/// <para>
	/// Window message code the framework must send to signify completion notices. This value is ignored unless the NotificationMethod
	/// parameter is set to <c>WINBIO_ASYNC_NOTIFY_MESSAGE</c>. The value must be within the range WM_APP(0x8000) to 0xBFFF.
	/// </para>
	/// <para>
	/// The Windows Biometric Framework sets the <c>LPARAM</c> value of the message to the address of the WINBIO_ASYNC_RESULT structure
	/// that contains the results of the operation. You must call WinBioFree to release the structure after you have finished using it.
	/// </para>
	/// </param>
	/// <param name="CallbackRoutine">
	/// Address of callback routine to be invoked when the operation started by using the session handle completes. This value is
	/// ignored unless the NotificationMethod parameter is set to <c>WINBIO_ASYNC_NOTIFY_CALLBACK</c>.
	/// </param>
	/// <param name="UserData">
	/// Address of a buffer supplied by the caller. The buffer is not modified by the framework or the biometric unit. It is returned in
	/// the WINBIO_ASYNC_RESULT structure. Your application can use the data to help it determine what actions to perform upon receipt
	/// of the completion notice or to maintain additional information about the requested operation.
	/// </param>
	/// <param name="AsynchronousOpen">
	/// <para>
	/// Specifies whether to block until the framework session has been opened. Specifying <c>FALSE</c> causes the process to block.
	/// Specifying <c>TRUE</c> causes the session to be opened asynchronously.
	/// </para>
	/// <para>
	/// If you specify <c>FALSE</c> to open the framework session synchronously, success or failure is returned to the caller directly
	/// by this function in the <c>HRESULT</c> return value. If the session is opened successfully, the first asynchronous completion
	/// event your application receives will be for an asynchronous operation requested after the framework has been open.
	/// </para>
	/// <para>
	/// If you specify <c>TRUE</c> to open the framework session asynchronously, the first asynchronous completion notice received will
	/// be for opening the framework. If the NotificationMethod parameter is set to <c>WINBIO_ASYNC_NOTIFY_CALLBACK</c>, operation
	/// results are delivered to the WINBIO_ASYNC_RESULT structure in the callback function specified by the CallbackRoutine parameter.
	/// If the NotificationMethod parameter is set to <c>WINBIO_ASYNC_NOTIFY_MESSAGE</c>, operation results are delivered to the
	/// <c>WINBIO_ASYNC_RESULT</c> structure pointed to by the LPARAM field of the window message.
	/// </para>
	/// </param>
	/// <param name="SessionHandle">
	/// <para>If the function does not succeed, this parameter will be <c>NULL</c>.</para>
	/// <para>If the session is opened synchronously and successfully, this parameter will contain a pointer to the session handle.</para>
	/// <para>
	/// If you specify that the session be opened asynchronously, this method returns immediately, the session handle will be
	/// <c>NULL</c>, and you must examine the WINBIO_ASYNC_RESULT structure to determine whether the session was successfully opened.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, it returns <c>S_OK</c>. If the function fails, it returns an <c>HRESULT</c> value that indicates the
	/// error. Possible values include, but are not limited to, those in the following table. For a list of common error codes, see
	/// Common HRESULT Values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>There is not enough memory available to create the biometric session.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>
	/// If you set the notification method to WINBIO_ASYNC_NOTIFY_MESSAGE, the TargetWindow parameter cannot be NULL or HWND_BROADCAST
	/// and the MessageCode parameter cannot be zero (0).
	/// </term>
	/// </item>
	/// <item>
	/// <term>E_POINTER</term>
	/// <term>
	/// The SessionHandle parameter and the AsynchronousOpen parameter must be set. If you set the notification method to
	/// WINBIO_ASYNC_NOTIFY_CALLBACK, you must also specify the address of a callback function in the CallbackRoutine parameter.
	/// </term>
	/// </item>
	/// <item>
	/// <term>E_ACCESSDENIED</term>
	/// <term>
	/// The Flags parameter contains the WINBIO_FLAG_RAW or the WINBIO_FLAG_MAINTENANCE flag and the caller has not been granted either
	/// access permission.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WINBIO_E_INVALID_UNIT</term>
	/// <term>One or more of the biometric unit numbers specified in the UnitArray parameter is not valid.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_E_NOT_ACTIVE_CONSOLE</term>
	/// <term>The client application is running on a remote desktop client and is attempting to open a system pool session.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_E_SENSOR_UNAVAILABLE</term>
	/// <term>The PoolType parameter is set to WINBIO_POOL_PRIVATE and one or more of the requested sensors in that pool is not available.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_E_DISABLED</term>
	/// <term>Current administrative policy prohibits use of the Windows Biometric Framework API.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The session handle returned by the <c>WinBioAsyncOpenSession</c> function can be used to generate asynchronous completion
	/// notifications for any of the following functions:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>WinBioCancel</term>
	/// </item>
	/// <item>
	/// <term>WinBioCaptureSample</term>
	/// </item>
	/// <item>
	/// <term>WinBioCloseSession</term>
	/// </item>
	/// <item>
	/// <term>WinBioControlUnit</term>
	/// </item>
	/// <item>
	/// <term>WinBioControlUnitPrivileged</term>
	/// </item>
	/// <item>
	/// <term>WinBioDeleteTemplate</term>
	/// </item>
	/// <item>
	/// <term>WinBioEnrollBegin</term>
	/// </item>
	/// <item>
	/// <term>WinBioEnrollCapture</term>
	/// </item>
	/// <item>
	/// <term>WinBioEnrollCommit</term>
	/// </item>
	/// <item>
	/// <term>WinBioEnrollDiscard</term>
	/// </item>
	/// <item>
	/// <term>WinBioEnumEnrollments</term>
	/// </item>
	/// <item>
	/// <term>WinBioGetProperty</term>
	/// </item>
	/// <item>
	/// <term>WinBioIdentify</term>
	/// </item>
	/// <item>
	/// <term>WinBioLocateSensor</term>
	/// </item>
	/// <item>
	/// <term>WinBioLockUnit</term>
	/// </item>
	/// <item>
	/// <term>WinBioLogonIdentifiedUser</term>
	/// </item>
	/// <item>
	/// <term>WinBioRegisterEventMonitor</term>
	/// </item>
	/// <item>
	/// <term>WinBioUnlockUnit</term>
	/// </item>
	/// <item>
	/// <term>WinBioUnregisterEventMonitor</term>
	/// </item>
	/// <item>
	/// <term>WinBioVerify</term>
	/// </item>
	/// <item>
	/// <term>WinBioWait</term>
	/// </item>
	/// </list>
	/// <para>The session handle returned by <c>WinBioAsyncOpenSession</c> cannot be used with the following functions:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>WinBioCaptureSampleWithCallback</term>
	/// </item>
	/// <item>
	/// <term>WinBioEnrollCaptureWithCallback</term>
	/// </item>
	/// <item>
	/// <term>WinBioIdentifyWithCallback</term>
	/// </item>
	/// <item>
	/// <term>WinBioIdentifyWithCallback</term>
	/// </item>
	/// </list>
	/// <para>
	/// These functions, first available in Windows 7, have an incompatible callback signature, and their use in new applications is
	/// discouraged. Developers who want asynchronous callbacks should instead use <c>WinBioAsyncOpenSession</c> with a
	/// NotificationMethod of <c>WINBIO_ASYNC_NOTIFY_CALLBACK</c>.
	/// </para>
	/// <para>
	/// The AsynchronousOpen parameter determines only whether the open operation will block. This parameter has no effect on the
	/// completion behavior of subsequent calls that use the session handle.
	/// </para>
	/// <para>
	/// If you set the AsynchronousOpen parameter to <c>TRUE</c>, this function will return <c>S_OK</c> as soon as it has performed an
	/// initial validation of the arguments. Any errors detected beyond that point will be reported to the caller using the method
	/// specified by the NotificationMethod parameter. That is, a successful return value indicates only that the
	/// <c>WinBioAsyncOpenSession</c> parameters were fine and not that the open operation succeeded. To determine whether the open
	/// operation succeeded, you must examine the WINBIO_ASYNC_RESULT structure.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbio/nf-winbio-winbioasyncopensession HRESULT WinBioAsyncOpenSession(
	// WINBIO_BIOMETRIC_TYPE Factor, WINBIO_POOL_TYPE PoolType, WINBIO_SESSION_FLAGS Flags, WINBIO_UNIT_ID *UnitArray, SIZE_T UnitCount,
	// GUID *DatabaseId, WINBIO_ASYNC_NOTIFICATION_METHOD NotificationMethod, HWND TargetWindow, UINT MessageCode,
	// PWINBIO_ASYNC_COMPLETION_CALLBACK CallbackRoutine, PVOID UserData, BOOL AsynchronousOpen, WINBIO_SESSION_HANDLE *SessionHandle );
	[DllImport(Lib_Winbio, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winbio.h", MSDNShortId = "NF:winbio.WinBioAsyncOpenSession")]
	public static extern HRESULT WinBioAsyncOpenSession(WINBIO_BIOMETRIC_TYPE Factor, WINBIO_POOL_TYPE PoolType, WINBIO_SESSION_FLAGS Flags,
		[In, Optional, MarshalAs(UnmanagedType.LPArray)] uint[]? UnitArray, [Optional] SIZE_T UnitCount, [In, Optional] GuidPtr DatabaseId,
		WINBIO_ASYNC_NOTIFICATION_METHOD NotificationMethod, [In, Optional] HWND TargetWindow,
		[In, Optional] uint MessageCode, [In, Optional] PWINBIO_ASYNC_COMPLETION_CALLBACK? CallbackRoutine,
		[In, Optional] IntPtr UserData, [MarshalAs(UnmanagedType.Bool)] bool AsynchronousOpen,
		out WINBIO_SESSION_HANDLE SessionHandle);

	/// <summary>
	/// Cancels all pending biometric operations for a specified session. Starting with Windows 10, build 1607, this function is
	/// available to use with a mobile image.
	/// </summary>
	/// <param name="SessionHandle">
	/// A <c>WINBIO_SESSION_HANDLE</c> value that identifies an open biometric session. Open a synchronous session handle by calling
	/// WinBioOpenSession. Open an asynchronous session handle by calling WinBioAsyncOpenSession.
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, it returns S_OK. If the function fails, it returns an <c>HRESULT</c> value that indicates the error.
	/// Possible values include, but are not limited to, those in the following table. For a list of common error codes, see Common
	/// HRESULT Values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_HANDLE</term>
	/// <term>The session handle is not valid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// To use <c>WinBioCancel</c> synchronously, call the function with a session handle created by calling WinBioOpenSession. When you
	/// call the function by using a synchronous session handle:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>If there are no pending operations, the function returns S_OK and performs no other actions.</term>
	/// </item>
	/// <item>
	/// <term>Pending asynchronous operations receive a callback notification for which the OperationStatus parameter is set to <c>WINBIO_E_CANCELED</c>.</term>
	/// </item>
	/// <item>
	/// <term>Blocked asynchronous operations started by other threads in the process return <c>WINBIO_E_CANCELED</c>.</term>
	/// </item>
	/// </list>
	/// <para>
	/// To use <c>WinBioCancel</c> asynchronously, call the function with a session handle created by calling WinBioAsyncOpenSession.
	/// When you call the function with an asynchronous session handle:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>The function verifies the input parameter and returns immediately with either S_OK or an error code.</term>
	/// </item>
	/// <item>
	/// <term>
	/// Pending asynchronous operations receive a completion notification that sets the <c>ApiStatus</c> member of their respective
	/// WINBIO_ASYNC_RESULT structures to <c>WINBIO_E_CANCELED</c>.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// The framework also allocates a WINBIO_ASYNC_RESULT structure for <c>WinBioCancel</c> and uses it to return information about
	/// cancellation success or failure. The <c>WINBIO_ASYNC_RESULT</c> structure is returned to the application callback or to the
	/// application message queue, depending on the value you set in the NotificationMethod parameter of the WinBioAsyncOpenSession function:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// If you choose to receive completion notices by using a callback, you must implement a PWINBIO_ASYNC_COMPLETION_CALLBACK function
	/// and set the NotificationMethod parameter to <c>WINBIO_ASYNC_NOTIFY_CALLBACK</c>.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If you choose to receive completion notices by using the application message queue, you must set the NotificationMethod
	/// parameter to <c>WINBIO_ASYNC_NOTIFY_MESSAGE</c>. The framework returns a WINBIO_ASYNC_RESULT pointer to the <c>LPARAM</c> field
	/// of the window message.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// To prevent memory leaks, you must call WinBioFree to release the WINBIO_ASYNC_RESULT structure after you have finished using it.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following code example captures a sample asynchronously by calling WinBioCaptureSampleWithCallback. You can pass a Boolean
	/// value to the function that will, if set to <c>TRUE</c>, cancel the capture operation. Link to the Winbio.lib static library and
	/// include the following header files:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>Windows.h</term>
	/// </item>
	/// <item>
	/// <term>Stdio.h</term>
	/// </item>
	/// <item>
	/// <term>Conio.h</term>
	/// </item>
	/// <item>
	/// <term>Winbio.h</term>
	/// </item>
	/// </list>
	/// <para>
	/// <code>HRESULT CaptureSampleWithCallback(BOOL bCancel) { HRESULT hr = S_OK; WINBIO_SESSION_HANDLE sessionHandle = NULL; // Connect to the system pool. hr = WinBioOpenSession( WINBIO_TYPE_FINGERPRINT, // Service provider WINBIO_POOL_SYSTEM, // Pool type WINBIO_FLAG_RAW, // Raw access NULL, // Array of biometric unit IDs 0, // Count of biometric unit IDs WINBIO_DB_DEFAULT, // Default database &amp;sessionHandle // [out] Session handle ); if (FAILED(hr)) { wprintf_s(L"\n WinBioOpenSession failed. hr = 0x%x\n", hr); goto e_Exit; } // Capture a biometric sample asynchronously. wprintf_s(L"\n Calling WinBioCaptureSampleWithCallback "); hr = WinBioCaptureSampleWithCallback( sessionHandle, // Open session handle WINBIO_NO_PURPOSE_AVAILABLE, // Intended use of the sample WINBIO_DATA_FLAG_RAW, // Sample format CaptureSampleCallback, // Callback function NULL // Optional context ); if (FAILED(hr)) { wprintf_s(L"\n WinBioCaptureSampleWithCallback failed. "); wprintf_s(L"hr = 0x%x\n", hr); goto e_Exit; } wprintf_s(L"\n Swipe the sensor ...\n"); // Cancel the capture operation if the bCancel flag is set. if (bCancel) { wprintf_s(L"\n Starting CANCEL timer..."); Sleep( 7000 ); wprintf_s(L"\n Calling WinBioCancel\n"); hr = WinBioCancel( sessionHandle ); if (FAILED(hr)) { wprintf_s(L"\n WinBioCancel failed. hr = 0x%x\n", hr); goto e_Exit; } } // Wait for the asynchronous capture process to complete // or be canceled. hr = WinBioWait( sessionHandle ); if (FAILED(hr)) { wprintf_s(L"\n WinBioWait failed. hr = 0x%x\n", hr); } e_Exit: if (sessionHandle != NULL) { WinBioCloseSession(sessionHandle); sessionHandle = NULL; } wprintf_s(L"\n Press any key to exit..."); _getch(); return hr; } //------------------------------------------------------------------------ // The following function is the callback for WinBioCaptureSampleWithCallback. // The function filters the response from the biometric subsystem and // writes a result to the console window. // VOID CALLBACK CaptureSampleCallback( __in_opt PVOID CaptureCallbackContext, __in HRESULT OperationStatus, __in WINBIO_UNIT_ID UnitId, __in_bcount(SampleSize) PWINBIO_BIR Sample, __in SIZE_T SampleSize, __in WINBIO_REJECT_DETAIL RejectDetail ) { UNREFERENCED_PARAMETER(CaptureCallbackContext); wprintf_s(L"\n CaptureSampleCallback executing"); wprintf_s(L"\n Swipe processed - Unit ID: %d", UnitId); if (FAILED(OperationStatus)) { if (OperationStatus == WINBIO_E_BAD_CAPTURE) { wprintf_s(L"\n Bad capture; reason: %d\n", RejectDetail); } else { wprintf_s(L"\n WinBioCaptureSampleWithCallback failed. "); wprintf_s(L" OperationStatus = 0x%x\n", OperationStatus); } goto e_Exit; } wprintf_s(L"\n Captured %d bytes.\n", SampleSize); e_Exit: if (Sample != NULL) { WinBioFree(Sample); Sample = NULL; } }</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbio/nf-winbio-winbiocancel HRESULT WinBioCancel( WINBIO_SESSION_HANDLE
	// SessionHandle );
	[DllImport(Lib_Winbio, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winbio.h", MSDNShortId = "NF:winbio.WinBioCancel")]
	public static extern HRESULT WinBioCancel(WINBIO_SESSION_HANDLE SessionHandle);

	/// <summary>Captures a biometric sample and fills a biometric information record (BIR) with the raw or processed data.</summary>
	/// <param name="SessionHandle">
	/// A <c>WINBIO_SESSION_HANDLE</c> value that identifies an open biometric session. Open a synchronous session handle by calling
	/// WinBioOpenSession. Open an asynchronous session handle by calling WinBioAsyncOpenSession.
	/// </param>
	/// <param name="Purpose">
	/// <para>
	/// A <c>WINBIO_BIR_PURPOSE</c> bitmask that specifies the intended use of the sample. This can be a bitwise <c>OR</c> of the
	/// following values:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term><c>WINBIO_PURPOSE_VERIFY</c></term>
	/// </item>
	/// <item>
	/// <term><c>WINBIO_PURPOSE_IDENTIFY</c></term>
	/// </item>
	/// <item>
	/// <term><c>WINBIO_PURPOSE_ENROLL</c></term>
	/// </item>
	/// <item>
	/// <term><c>WINBIO_PURPOSE_ENROLL_FOR_VERIFICATION</c></term>
	/// </item>
	/// <item>
	/// <term><c>WINBIO_PURPOSE_ENROLL_FOR_IDENTIFICATION</c></term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="Flags">
	/// <para>
	/// A value that specifies the type of processing to be applied to the captured sample. This can be a bitwise <c>OR</c> of the
	/// following security and processing level flags:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term><c>WINBIO_DATA_FLAG_PRIVACY</c></term>
	/// </item>
	/// </list>
	/// <para>Encrypt the sample.</para>
	/// <list type="bullet">
	/// <item>
	/// <term><c>WINBIO_DATA_FLAG_INTEGRITY</c></term>
	/// </item>
	/// </list>
	/// <para>Sign the sample or protect it by using a message authentication code (MAC)</para>
	/// <list type="bullet">
	/// <item>
	/// <term><c>WINBIO_DATA_FLAG_SIGNED</c></term>
	/// </item>
	/// </list>
	/// <para>
	/// If this flag and the WINBIO_DATA_FLAG_INTEGRITY flag are set, sign the sample. If this flag is not set but the
	/// WINBIO_DATA_FLAG_INTEGRITY flag is set, compute a MAC.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term><c>WINBIO_DATA_FLAG_RAW</c></term>
	/// </item>
	/// </list>
	/// <para>Return the sample exactly as it was captured by the sensor.</para>
	/// <list type="bullet">
	/// <item>
	/// <term><c>WINBIO_DATA_FLAG_INTERMEDIATE</c></term>
	/// </item>
	/// </list>
	/// <para>Return the sample after it has been cleaned and filtered.</para>
	/// <list type="bullet">
	/// <item>
	/// <term><c>WINBIO_DATA_FLAG_PROCESSED</c></term>
	/// </item>
	/// </list>
	/// <para>Return the sample after it is ready to be used for the purpose specified by the Purpose parameter.</para>
	/// </param>
	/// <param name="UnitId">
	/// A pointer to a <c>WINBIO_UNIT_ID</c> value that contains the ID of the biometric unit that generated the sample.
	/// </param>
	/// <param name="Sample">
	/// Address of a variable that receives a pointer to a WINBIO_BIR structure that contains the sample. When you have finished using
	/// the structure, you must pass the pointer to WinBioFree to release the memory allocated for the sample.
	/// </param>
	/// <param name="SampleSize">
	/// A pointer to a <c>SIZE_T</c> value that contains the size, in bytes, of the WINBIO_BIR structure returned in the Sample parameter.
	/// </param>
	/// <param name="RejectDetail">
	/// <para>
	/// A pointer to a <c>WINBIO_REJECT_DETAIL</c> value that contains additional information about the failure to capture a biometric
	/// sample. If the capture succeeded, this parameter is set to zero. The following values are defined for fingerprint capture:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term><c>WINBIO_FP_TOO_HIGH</c></term>
	/// </item>
	/// <item>
	/// <term><c>WINBIO_FP_TOO_LOW</c></term>
	/// </item>
	/// <item>
	/// <term><c>WINBIO_FP_TOO_LEFT</c></term>
	/// </item>
	/// <item>
	/// <term><c>WINBIO_FP_TOO_RIGHT</c></term>
	/// </item>
	/// <item>
	/// <term><c>WINBIO_FP_TOO_FAST</c></term>
	/// </item>
	/// <item>
	/// <term><c>WINBIO_FP_TOO_SLOW</c></term>
	/// </item>
	/// <item>
	/// <term><c>WINBIO_FP_POOR_QUALITY</c></term>
	/// </item>
	/// <item>
	/// <term><c>WINBIO_FP_TOO_SKEWED</c></term>
	/// </item>
	/// <item>
	/// <term><c>WINBIO_FP_TOO_SHORT</c></term>
	/// </item>
	/// <item>
	/// <term><c>WINBIO_FP_MERGE_FAILURE</c></term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, it returns <c>S_OK</c>. If the function fails, it returns an <c>HRESULT</c> value that indicates the
	/// error. Possible values include, but are not limited to, those in the following table. For a list of common error codes, see
	/// Common HRESULT Values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_ACCESSDENIED</term>
	/// <term>
	/// The caller does not have permission to capture raw samples, or the session was not opened by using the WINBIO_FLAG_RAW flag.
	/// </term>
	/// </item>
	/// <item>
	/// <term>E_HANDLE</term>
	/// <term>The session handle is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_NOTIMPL</term>
	/// <term>The biometric unit does not support the requested operation.</term>
	/// </item>
	/// <item>
	/// <term>E_POINTER</term>
	/// <term>The UnitId, Sample, SampleSize, and RejectDetail pointers cannot be NULL.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_E_ENROLLMENT_IN_PROGRESS</term>
	/// <term>
	/// The operation could not be completed because the biometric unit is currently being used for an enrollment transaction (system
	/// pool only).
	/// </term>
	/// </item>
	/// <item>
	/// <term>WINBIO_E_INVALID_OPERATION</term>
	/// <term>The operation could not be completed because a secure sensor is present in the sensor pool.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// To call this function successfully, you must open the session handle by specifying <c>WINBIO_FLAG_RAW</c> in the Flags parameter
	/// of the WinBioOpenSession or WinBioAsyncOpenSession functions. Currently, only applications running under the Administrators and
	/// Local System accounts have the necessary privileges.
	/// </para>
	/// <para>
	/// Valid combinations of the Purpose and Flags parameters depend on the capabilities of the biometric unit being used. Consult the
	/// vendor's sensor documentation to determine which combinations of valid Purpose and Flags values are supported and how they
	/// affect the captured data. After you are finished using the sample, your application must call WinBioFree to release the memory
	/// allocated for it by the <c>WinBioCaptureSample</c> function.
	/// </para>
	/// <para>
	/// To use <c>WinBioCaptureSample</c> synchronously, call the function with a session handle created by calling WinBioOpenSession.
	/// The function blocks until a sample has been captured or an error is encountered. Calls to <c>WinBioCaptureSample</c> using the
	/// system pool will block until the calling application has window focus and the user provides a sample to one of the sensors in
	/// the pool. If the sensor chosen by the user is already being used for an enrollment transaction, the function fails and returns <c>WINBIO_E_ENROLLMENT_IN_PROGRESS</c>.
	/// </para>
	/// <para>
	/// To use <c>WinBioCaptureSample</c> asynchronously, call the function with a session handle created by calling
	/// WinBioAsyncOpenSession. The framework allocates a WINBIO_ASYNC_RESULT structure and uses it to return information about
	/// operation success or failure. If the capture operation is successful, the framework returns information about the sample in a
	/// nested <c>CaptureSample</c> structure. If the operation is unsuccessful, the framework returns error information. The
	/// <c>WINBIO_ASYNC_RESULT</c> structure is returned to the application callback or to the application message queue, depending on
	/// the value you set in the NotificationMethod parameter of the <c>WinBioAsyncOpenSession</c> function:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// If you choose to receive completion notices by using a callback, you must implement a PWINBIO_ASYNC_COMPLETION_CALLBACK function
	/// and set the NotificationMethod parameter to <c>WINBIO_ASYNC_NOTIFY_CALLBACK</c>.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If you choose to receive completion notices by using the application message queue, you must set the NotificationMethod
	/// parameter to <c>WINBIO_ASYNC_NOTIFY_MESSAGE</c>. The framework returns a WINBIO_ASYNC_RESULT pointer to the <c>LPARAM</c> field
	/// of the window message.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// To prevent memory leaks, you must call WinBioFree to release the WINBIO_ASYNC_RESULT structure after you have finished using it.
	/// </para>
	/// <para>
	/// <c>Windows 7:</c> You can perform this operation asynchronously by using the WinBioCaptureSampleWithCallback function. The
	/// function verifies the input arguments and returns immediately. If the input arguments are not valid, the function returns an
	/// error code. Otherwise, the framework starts the operation on another thread. When the asynchronous operation completes or
	/// encounters an error, the framework sends the results to the PWINBIO_CAPTURE_CALLBACK function implemented by your application.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following function calls <c>WinBioCaptureSample</c> to capture a biometric sample from a user. Link to the Winbio.lib static
	/// library and include the following header files:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>Windows.h</term>
	/// </item>
	/// <item>
	/// <term>Stdio.h</term>
	/// </item>
	/// <item>
	/// <term>Conio.h</term>
	/// </item>
	/// <item>
	/// <term>Winbio.h</term>
	/// </item>
	/// </list>
	/// <para>
	/// <code>HRESULT CaptureSample() { HRESULT hr = S_OK; WINBIO_SESSION_HANDLE sessionHandle = NULL; WINBIO_UNIT_ID unitId = 0; WINBIO_REJECT_DETAIL rejectDetail = 0; PWINBIO_BIR sample = NULL; SIZE_T sampleSize = 0; // Connect to the system pool. hr = WinBioOpenSession( WINBIO_TYPE_FINGERPRINT, // Service provider WINBIO_POOL_SYSTEM, // Pool type WINBIO_FLAG_RAW, // Access: Capture raw data NULL, // Array of biometric unit IDs 0, // Count of biometric unit IDs WINBIO_DB_DEFAULT, // Default database &amp;sessionHandle // [out] Session handle ); if (FAILED(hr)) { wprintf_s(L"\n WinBioOpenSession failed. hr = 0x%x\n", hr); goto e_Exit; } // Capture a biometric sample. wprintf_s(L"\n Calling WinBioCaptureSample - Swipe sensor...\n"); hr = WinBioCaptureSample( sessionHandle, WINBIO_NO_PURPOSE_AVAILABLE, WINBIO_DATA_FLAG_RAW, &amp;unitId, &amp;sample, &amp;sampleSize, &amp;rejectDetail ); if (FAILED(hr)) { if (hr == WINBIO_E_BAD_CAPTURE) { wprintf_s(L"\n Bad capture; reason: %d\n", rejectDetail); } else { wprintf_s(L"\n WinBioCaptureSample failed. hr = 0x%x\n", hr); } goto e_Exit; } wprintf_s(L"\n Swipe processed - Unit ID: %d\n", unitId); wprintf_s(L"\n Captured %d bytes.\n", sampleSize); e_Exit: if (sample != NULL) { WinBioFree(sample); sample = NULL; } if (sessionHandle != NULL) { WinBioCloseSession(sessionHandle); sessionHandle = NULL; } wprintf_s(L"\n Press any key to exit..."); _getch(); return hr; }</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbio/nf-winbio-winbiocapturesample HRESULT WinBioCaptureSample(
	// WINBIO_SESSION_HANDLE SessionHandle, WINBIO_BIR_PURPOSE Purpose, WINBIO_BIR_DATA_FLAGS Flags, WINBIO_UNIT_ID *UnitId, PWINBIO_BIR
	// *Sample, SIZE_T *SampleSize, WINBIO_REJECT_DETAIL *RejectDetail );
	[DllImport(Lib_Winbio, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winbio.h", MSDNShortId = "NF:winbio.WinBioCaptureSample")]
	public static extern HRESULT WinBioCaptureSample(WINBIO_SESSION_HANDLE SessionHandle, WINBIO_BIR_PURPOSE Purpose, WINBIO_BIR_DATA_FLAGS Flags,
		out uint UnitId, out SafeWinBioMemory Sample, out SIZE_T SampleSize, out WINBIO_REJECT_DETAIL RejectDetail);

	/// <summary>
	/// <para>
	/// Captures a biometric sample asynchronously and returns the raw or processed data in a biometric information record (BIR). The
	/// function returns immediately to the caller, captures the sample on a separate thread, and calls into an application-defined
	/// callback function to update operation status.
	/// </para>
	/// <para><c>Important</c>
	/// <para></para>
	/// We recommend that, beginning with Windows 8, you no longer use this function to start an asynchronous operation. Instead, do the following:
	/// </para>
	/// </summary>
	/// <param name="SessionHandle">A <c>WINBIO_SESSION_HANDLE</c> value that identifies an open biometric session.</param>
	/// <param name="Purpose">
	/// <para>
	/// A <c>WINBIO_BIR_PURPOSE</c> bitmask that specifies the intended use of the sample. This can be a bitwise <c>OR</c> of the
	/// following values:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term><c>WINBIO_PURPOSE_VERIFY</c></term>
	/// </item>
	/// <item>
	/// <term><c>WINBIO_PURPOSE_IDENTIFY</c></term>
	/// </item>
	/// <item>
	/// <term><c>WINBIO_PURPOSE_ENROLL</c></term>
	/// </item>
	/// <item>
	/// <term><c>WINBIO_PURPOSE_ENROLL_FOR_VERIFICATION</c></term>
	/// </item>
	/// <item>
	/// <term><c>WINBIO_PURPOSE_ENROLL_FOR_IDENTIFICATION</c></term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="Flags">
	/// <para>
	/// A value that specifies the type of processing to be applied to the captured sample. This can be a bitwise <c>OR</c> of the
	/// following security and processing level flags:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term><c>WINBIO_DATA_FLAG_PRIVACY</c></term>
	/// </item>
	/// </list>
	/// <para>Encrypt the sample.</para>
	/// <list type="bullet">
	/// <item>
	/// <term><c>WINBIO_DATA_FLAG_INTEGRITY</c></term>
	/// </item>
	/// </list>
	/// <para>Sign the sample or protect it by using a message authentication code (MAC).</para>
	/// <list type="bullet">
	/// <item>
	/// <term><c>WINBIO_DATA_FLAG_SIGNED</c></term>
	/// </item>
	/// </list>
	/// <para>
	/// If this flag and the WINBIO_DATA_FLAG_INTEGRITYflag are set, sign the sample. If this flag is not set but the
	/// WINBIO_DATA_FLAG_INTEGRITY flag is set, compute a MAC.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term><c>WINBIO_DATA_FLAG_RAW</c></term>
	/// </item>
	/// </list>
	/// <para>Return the sample exactly as it was captured by the sensor.</para>
	/// <list type="bullet">
	/// <item>
	/// <term><c>WINBIO_DATA_FLAG_INTERMEDIATE</c></term>
	/// </item>
	/// </list>
	/// <para>Return the sample after it has been cleaned and filtered.</para>
	/// <list type="bullet">
	/// <item>
	/// <term><c>WINBIO_DATA_FLAG_PROCESSED</c></term>
	/// </item>
	/// </list>
	/// <para>Return the sample after it is ready to be used for the purpose specified by the parameter.</para>
	/// </param>
	/// <param name="CaptureCallback">
	/// Address of a callback function that will be called by the <c>WinBioCaptureSampleWithCallback</c> function when the capture
	/// operation succeeds or fails. You must create the callback.
	/// </param>
	/// <param name="CaptureCallbackContext">
	/// Address of an application-defined data structure that is passed to the callback function in its CaptureCallbackContext
	/// parameter. This structure can contain any data that the custom callback function is designed to handle.
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, it returns <c>S_OK</c>. If the function fails, it returns an <c>HRESULT</c> value that indicates the
	/// error. Possible values include, but are not limited to, those in the following table. For a list of common error codes, see
	/// Common HRESULT Values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_ACCESSDENIED</term>
	/// <term>
	/// The caller does not have permission to capture raw samples, or the session was not opened by using the WINBIO_FLAG_RAW flag.
	/// </term>
	/// </item>
	/// <item>
	/// <term>E_HANDLE</term>
	/// <term>The session handle is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_NOTIMPL</term>
	/// <term>The biometric unit does not support the requested operation.</term>
	/// </item>
	/// <item>
	/// <term>E_POINTER</term>
	/// <term>The UnitId, Sample, SampleSize, and RejectDetail pointers cannot be NULL.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_E_ENROLLMENT_IN_PROGRESS</term>
	/// <term>
	/// The operation could not be completed because the biometric unit is currently being used for an enrollment transaction (system
	/// pool only).
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>WinBioCaptureSampleWithCallback</c> function captures samples asynchronously. To call this function successfully, the
	/// session handle must have been opened by specifying <c>WINBIO_FLAG_RAW</c>. Only the Administrators and Local System accounts
	/// have the necessary privileges.
	/// </para>
	/// <para>
	/// Valid combinations of the Purpose and Flags parameters depend on the capabilities of the biometric unit being used. Consult the
	/// vendor sensor documentation to determine what combinations are supported and how they affect the captured data.
	/// </para>
	/// <para>Callers are responsible for releasing the WINBIO_BIR structure returned by the Sample parameter.</para>
	/// <para>The callback routine must have the following signature:</para>
	/// <para>
	/// <code>VOID CALLBACK CaptureCallback( __in_opt PVOID CaptureCallbackContext, __in HRESULT OperationStatus, __in WINBIO_UNIT_ID UnitId, __in_bcount(SampleSize) PWINBIO_BIR Sample, __in SIZE_T SampleSize, __in WINBIO_REJECT_DETAIL RejectDetail );</code>
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following code example captures a sample asynchronously by calling <c>WinBioCaptureSampleWithCallback</c> and passing a
	/// pointer to a custom callback function. The callback function, CaptureSampleCallback, is also shown. Link to the Winbio.lib
	/// static library and include the following header files:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>Windows.h</term>
	/// </item>
	/// <item>
	/// <term>Stdio.h</term>
	/// </item>
	/// <item>
	/// <term>Conio.h</term>
	/// </item>
	/// <item>
	/// <term>Winbio.h</term>
	/// </item>
	/// </list>
	/// <para>
	/// <code>HRESULT CaptureSampleWithCallback(BOOL bCancel) { HRESULT hr = S_OK; WINBIO_SESSION_HANDLE sessionHandle = NULL; // Connect to the system pool. hr = WinBioOpenSession( WINBIO_TYPE_FINGERPRINT, // Service provider WINBIO_POOL_SYSTEM, // Pool type WINBIO_FLAG_RAW, // Raw access NULL, // Array of biometric unit IDs 0, // Count of biometric unit IDs WINBIO_DB_DEFAULT, // Default database &amp;sessionHandle // [out] Session handle ); if (FAILED(hr)) { wprintf_s(L"\n WinBioOpenSession failed. hr = 0x%x\n", hr); goto e_Exit; } // Capture a biometric sample asynchronously. wprintf_s(L"\n Calling WinBioCaptureSampleWithCallback "); hr = WinBioCaptureSampleWithCallback( sessionHandle, // Open session handle WINBIO_NO_PURPOSE_AVAILABLE, // Intended use of the sample WINBIO_DATA_FLAG_RAW, // Sample format CaptureSampleCallback, // Callback function NULL // Optional context ); if (FAILED(hr)) { wprintf_s(L"\n WinBioCaptureSampleWithCallback failed. "); wprintf_s(L"hr = 0x%x\n", hr); goto e_Exit; } wprintf_s(L"\n Swipe the sensor ...\n"); // Cancel the capture process if the bCancel flag is set. if (bCancel) { wprintf_s(L"\n Starting CANCEL timer..."); Sleep( 7000 ); wprintf_s(L"\n Calling WinBioCancel\n"); hr = WinBioCancel( sessionHandle ); if (FAILED(hr)) { wprintf_s(L"\n WinBioCancel failed. hr = 0x%x\n", hr); goto e_Exit; } } // Wait for the asynchronous capture process to complete // or be canceled. hr = WinBioWait( sessionHandle ); if (FAILED(hr)) { wprintf_s(L"\n WinBioWait failed. hr = 0x%x\n", hr); } e_Exit: if (sessionHandle != NULL) { WinBioCloseSession(sessionHandle); sessionHandle = NULL; } wprintf_s(L"\n Press any key to exit..."); _getch(); return hr; } //------------------------------------------------------------------------ // The following function is the callback for WinBioCaptureSampleWithCallback. // The function filters the response from the biometric subsystem and // writes a result to the console window. // VOID CALLBACK CaptureSampleCallback( __in_opt PVOID CaptureCallbackContext, __in HRESULT OperationStatus, __in WINBIO_UNIT_ID UnitId, __in_bcount(SampleSize) PWINBIO_BIR Sample, __in SIZE_T SampleSize, __in WINBIO_REJECT_DETAIL RejectDetail ) { UNREFERENCED_PARAMETER(CaptureCallbackContext); wprintf_s(L"\n CaptureSampleCallback executing"); wprintf_s(L"\n Swipe processed - Unit ID: %d", UnitId); if (FAILED(OperationStatus)) { if (OperationStatus == WINBIO_E_BAD_CAPTURE) { wprintf_s(L"\n Bad capture; reason: %d\n", RejectDetail); } else { wprintf_s(L"\n WinBioCaptureSampleWithCallback failed. "); wprintf_s(L" OperationStatus = 0x%x\n", OperationStatus); } goto e_Exit; } wprintf_s(L"\n Captured %d bytes.\n", SampleSize); e_Exit: if (Sample != NULL) { WinBioFree(Sample); Sample = NULL; } }</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbio/nf-winbio-winbiocapturesamplewithcallback HRESULT
	// WinBioCaptureSampleWithCallback( WINBIO_SESSION_HANDLE SessionHandle, WINBIO_BIR_PURPOSE Purpose, WINBIO_BIR_DATA_FLAGS Flags,
	// PWINBIO_CAPTURE_CALLBACK CaptureCallback, PVOID CaptureCallbackContext );
	[DllImport(Lib_Winbio, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winbio.h", MSDNShortId = "NF:winbio.WinBioCaptureSampleWithCallback")]
	public static extern HRESULT WinBioCaptureSampleWithCallback(WINBIO_SESSION_HANDLE SessionHandle, WINBIO_BIR_PURPOSE Purpose, WINBIO_BIR_DATA_FLAGS Flags,
		[In] PWINBIO_CAPTURE_CALLBACK CaptureCallback, [In, Optional] IntPtr CaptureCallbackContext);

	/// <summary>
	/// Closes a framework handle previously opened with WinBioAsyncOpenFramework. Starting with Windows 10, build 1607, this function
	/// is available to use with a mobile image.
	/// </summary>
	/// <param name="FrameworkHandle">Handle to the framework session that will be closed.</param>
	/// <returns>
	/// If the function succeeds, it returns <c>S_OK</c>. If the function fails, it returns an <c>HRESULT</c> value that indicates the error.
	/// </returns>
	/// <remarks>This function never blocks.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbio/nf-winbio-winbiocloseframework HRESULT WinBioCloseFramework(
	// WINBIO_FRAMEWORK_HANDLE FrameworkHandle );
	[DllImport(Lib_Winbio, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winbio.h", MSDNShortId = "NF:winbio.WinBioCloseFramework")]
	public static extern HRESULT WinBioCloseFramework(WINBIO_FRAMEWORK_HANDLE FrameworkHandle);

	/// <summary>
	/// Closes a biometric session and releases associated resources. Starting with Windows 10, build 1607, this function is available
	/// to use with a mobile image.
	/// </summary>
	/// <param name="SessionHandle">
	/// A <c>WINBIO_SESSION_HANDLE</c> value that identifies an open biometric session. Open a synchronous session handle by calling
	/// WinBioOpenSession. Open an asynchronous session handle by calling WinBioAsyncOpenSession.
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, it returns S_OK. If the function fails, it returns an <c>HRESULT</c> value that indicates the error.
	/// Possible values include, but are not limited to, those in the following table. For a list of common error codes, see Common
	/// HRESULT Values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_HANDLE</term>
	/// <term>The session handle is not valid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// To use <c>WinBioCloseSession</c> synchronously, call the function with a session handle created by calling WinBioOpenSession.
	/// The function blocks until the operation completes or an error is encountered.
	/// </para>
	/// <para>
	/// To use <c>WinBioCloseSession</c> asynchronously, call the function with a session handle created by calling
	/// WinBioAsyncOpenSession. The framework allocates a WINBIO_ASYNC_RESULT structure and uses it to return information about
	/// operation success or failure. The <c>WINBIO_ASYNC_RESULT</c> structure is returned to the application callback or to the
	/// application message queue, depending on the value you set in the NotificationMethod parameter of the
	/// <c>WinBioAsyncOpenSession</c> function.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// If you choose to receive completion notices by using a callback, you must implement a PWINBIO_ASYNC_COMPLETION_CALLBACK function
	/// and set the NotificationMethod parameter to <c>WINBIO_ASYNC_NOTIFY_CALLBACK</c>.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If you choose to receive completion notices by using the application message queue, you must set the NotificationMethod
	/// parameter to <c>WINBIO_ASYNC_NOTIFY_MESSAGE</c>. The framework returns a WINBIO_ASYNC_RESULT pointer to the <c>LPARAM</c> field
	/// of the window message.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// To prevent memory leaks, you must call WinBioFree from your callback implementation to release the WINBIO_ASYNC_RESULT structure
	/// after you have finished using it.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following function shows how to enumerate the biometric sub-factors enrolled for a template. The sample creates a connection
	/// to the system pool and keeps the connection open until calling <c>WinBioCloseSession</c> during cleanup. Link to the Winbio.lib
	/// static library and include the following header files:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>Windows.h</term>
	/// </item>
	/// <item>
	/// <term>Stdio.h</term>
	/// </item>
	/// <item>
	/// <term>Conio.h</term>
	/// </item>
	/// <item>
	/// <term>Winbio.h</term>
	/// </item>
	/// </list>
	/// <para>
	/// <code>HRESULT EnumEnrollments( ) { // Declare variables. HRESULT hr = S_OK; WINBIO_IDENTITY identity = {0}; WINBIO_SESSION_HANDLE sessionHandle = NULL; WINBIO_UNIT_ID unitId = 0; PWINBIO_BIOMETRIC_SUBTYPE subFactorArray = NULL; WINBIO_BIOMETRIC_SUBTYPE SubFactor = 0; SIZE_T subFactorCount = 0; WINBIO_REJECT_DETAIL rejectDetail = 0; WINBIO_BIOMETRIC_SUBTYPE subFactor = WINBIO_SUBTYPE_NO_INFORMATION; // Connect to the system pool. hr = WinBioOpenSession( WINBIO_TYPE_FINGERPRINT, // Service provider WINBIO_POOL_SYSTEM, // Pool type WINBIO_FLAG_DEFAULT, // Configuration and access NULL, // Array of biometric unit IDs 0, // Count of biometric unit IDs NULL, // Database ID &amp;sessionHandle // [out] Session handle ); if (FAILED(hr)) { wprintf_s(L"\n WinBioOpenSession failed. hr = 0x%x\n", hr); goto e_Exit; } // Locate the biometric sensor and retrieve a WINBIO_IDENTITY object. wprintf_s(L"\n Calling WinBioIdentify - Swipe finger on sensor...\n"); hr = WinBioIdentify( sessionHandle, // Session handle &amp;unitId, // Biometric unit ID &amp;identity, // User SID &amp;subFactor, // Finger sub factor &amp;rejectDetail // Rejection information ); wprintf_s(L"\n Swipe processed - Unit ID: %d\n", unitId); if (FAILED(hr)) { if (hr == WINBIO_E_UNKNOWN_ID) { wprintf_s(L"\n Unknown identity.\n"); } else if (hr == WINBIO_E_BAD_CAPTURE) { wprintf_s(L"\n Bad capture; reason: %d\n", rejectDetail); } else { wprintf_s(L"\n WinBioEnumBiometricUnits failed. hr = 0x%x\n", hr); } goto e_Exit; } // Retrieve the biometric sub-factors for the template. hr = WinBioEnumEnrollments( sessionHandle, // Session handle unitId, // Biometric unit ID &amp;identity, // Template ID &amp;subFactorArray, // Subfactors &amp;subFactorCount // Count of subfactors ); if (FAILED(hr)) { wprintf_s(L"\n WinBioEnumEnrollments failed. hr = 0x%x\n", hr); goto e_Exit; } // Print the sub-factor(s) to the console. wprintf_s(L"\n Enrollments for this user on Unit ID %d:", unitId); for (SIZE_T index = 0; index &lt; subFactorCount; ++index) { SubFactor = subFactorArray[index]; switch (SubFactor) { case WINBIO_ANSI_381_POS_RH_THUMB: wprintf_s(L"\n RH thumb\n"); break; case WINBIO_ANSI_381_POS_RH_INDEX_FINGER: wprintf_s(L"\n RH index finger\n"); break; case WINBIO_ANSI_381_POS_RH_MIDDLE_FINGER: wprintf_s(L"\n RH middle finger\n"); break; case WINBIO_ANSI_381_POS_RH_RING_FINGER: wprintf_s(L"\n RH ring finger\n"); break; case WINBIO_ANSI_381_POS_RH_LITTLE_FINGER: wprintf_s(L"\n RH little finger\n"); break; case WINBIO_ANSI_381_POS_LH_THUMB: wprintf_s(L"\n LH thumb\n"); break; case WINBIO_ANSI_381_POS_LH_INDEX_FINGER: wprintf_s(L"\n LH index finger\n"); break; case WINBIO_ANSI_381_POS_LH_MIDDLE_FINGER: wprintf_s(L"\n LH middle finger\n"); break; case WINBIO_ANSI_381_POS_LH_RING_FINGER: wprintf_s(L"\n LH ring finger\n"); break; case WINBIO_ANSI_381_POS_LH_LITTLE_FINGER: wprintf_s(L"\n LH little finger\n"); break; default: wprintf_s(L"\n The sub-factor is not correct\n"); break; } } e_Exit: if (subFactorArray!= NULL) { WinBioFree(subFactorArray); subFactorArray = NULL; } if (sessionHandle != NULL) { WinBioCloseSession(sessionHandle); sessionHandle = NULL; } wprintf_s(L"\n Press any key to exit..."); _getch(); return hr; }</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbio/nf-winbio-winbioclosesession HRESULT WinBioCloseSession(
	// WINBIO_SESSION_HANDLE SessionHandle );
	[DllImport(Lib_Winbio, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winbio.h", MSDNShortId = "NF:winbio.WinBioCloseSession")]
	public static extern HRESULT WinBioCloseSession(WINBIO_SESSION_HANDLE SessionHandle);

	/// <summary>
	/// Allows the caller to perform vendor-defined control operations on a biometric unit. Starting with Windows 10, build 1607, this
	/// function is available to use with a mobile image. This function is provided for access to extended vendor operations for which
	/// elevated privileges are not required. If access rights are required, call the WinBioControlUnitPrivileged function.
	/// </summary>
	/// <param name="SessionHandle">
	/// A <c>WINBIO_SESSION_HANDLE</c> value that identifies an open biometric session. Open a synchronous session handle by calling
	/// WinBioOpenSession. Open an asynchronous session handle by calling WinBioAsyncOpenSession.
	/// </param>
	/// <param name="UnitId">
	/// A <c>WINBIO_UNIT_ID</c> value that identifies the biometric unit. This value must correspond to the unit ID used previously in
	/// the WinBioLockUnit function.
	/// </param>
	/// <param name="Component">
	/// <para>
	/// A <c>WINBIO_COMPONENT</c> value that specifies the component within the biometric unit that should perform the operation. This
	/// can be one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>WINBIO_COMPONENT_SENSOR</term>
	/// <term>Send the command to the sensor adapter.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_COMPONENT_ENGINE</term>
	/// <term>Send the command to the engine adapter.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_COMPONENT_STORAGE</term>
	/// <term>Send the command to the storage adapter.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="ControlCode">
	/// A vendor-defined code recognized by the biometric unit specified by the UnitId parameter and the adapter specified by the
	/// Component parameter.
	/// </param>
	/// <param name="SendBuffer">
	/// Address of the buffer that contains the control information to be sent to the adapter specified by the Component parameter. The
	/// format and content of the buffer is vendor-defined.
	/// </param>
	/// <param name="SendBufferSize">Size, in bytes, of the buffer specified by the SendBuffer parameter.</param>
	/// <param name="ReceiveBuffer">
	/// Address of the buffer that receives information sent by the adapter specified by the Component parameter. The format and content
	/// of the buffer is vendor-defined.
	/// </param>
	/// <param name="ReceiveBufferSize">Size, in bytes, of the buffer specified by the ReceiveBuffer parameter.</param>
	/// <param name="ReceiveDataSize">
	/// Pointer to a <c>SIZE_T</c> value that contains the size, in bytes, of the data written to the buffer specified by the
	/// ReceiveBuffer parameter.
	/// </param>
	/// <param name="OperationStatus">
	/// Pointer to an integer that contains a vendor-defined status code that specifies the outcome of the control operation.
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, it returns S_OK. If the function fails, it returns an <c>HRESULT</c> value that indicates the error.
	/// Possible values include, but are not limited to, those in the following table. For a list of common error codes, see Common
	/// HRESULT Values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_HANDLE</term>
	/// <term>The session handle is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>The value specified in the ControlCode parameter is not recognized.</term>
	/// </item>
	/// <item>
	/// <term>E_POINTER</term>
	/// <term>The SendBuffer, ReceiveBuffer, ReceiveDataSize, OperationStatus parameters cannot be NULL.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_E_INVALID_CONTROL_CODE</term>
	/// <term>The value specified in the ControlCode parameter is not recognized.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_E_LOCK_VIOLATION</term>
	/// <term>The biometric unit specified by the UnitId parameter must be locked before any control operations can be performed.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// You must call WinBioLockUnit before calling <c>WinBioControlUnit</c>. The <c>WinBioLockUnit</c> function creates a locked region
	/// in which vendor-defined operations can be securely performed.
	/// </para>
	/// <para>
	/// Vendors who create plug-ins must decide which extended operations are privileged and which are available to all clients. To
	/// perform a privileged operation, the client application must call the WinBioControlUnitPrivileged function. The Windows Biometric
	/// Framework allows only clients that have the appropriate access rights to call <c>WinBioControlUnitPrivileged</c>.
	/// </para>
	/// <para>
	/// To use <c>WinBioControlUnit</c> synchronously, call the function with a session handle created by calling WinBioOpenSession. The
	/// function blocks until the operation completes or an error is encountered.
	/// </para>
	/// <para>
	/// To use <c>WinBioControlUnit</c> asynchronously, call the function with a session handle created by calling
	/// WinBioAsyncOpenSession. The framework allocates a WINBIO_ASYNC_RESULT structure and uses it to return information about
	/// operation success or failure. The <c>WINBIO_ASYNC_RESULT</c> structure is returned to the application callback or to the
	/// application message queue, depending on the value you set in the NotificationMethod parameter of the
	/// <c>WinBioAsyncOpenSession</c> function.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// If you choose to receive completion notices by using a callback, you must implement a PWINBIO_ASYNC_COMPLETION_CALLBACK function
	/// and set the NotificationMethod parameter to <c>WINBIO_ASYNC_NOTIFY_CALLBACK</c>.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If you choose to receive completion notices by using the application message queue, you must set the NotificationMethod
	/// parameter to <c>WINBIO_ASYNC_NOTIFY_MESSAGE</c>. The framework returns a WINBIO_ASYNC_RESULT pointer to the <c>LPARAM</c> field
	/// of the window message.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// To prevent memory leaks, you must call WinBioFree to release the WINBIO_ASYNC_RESULT structure after you have finished using it.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbio/nf-winbio-winbiocontrolunit HRESULT WinBioControlUnit(
	// WINBIO_SESSION_HANDLE SessionHandle, WINBIO_UNIT_ID UnitId, WINBIO_COMPONENT Component, ULONG ControlCode, PUCHAR SendBuffer,
	// SIZE_T SendBufferSize, PUCHAR ReceiveBuffer, SIZE_T ReceiveBufferSize, SIZE_T *ReceiveDataSize, ULONG *OperationStatus );
	[DllImport(Lib_Winbio, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winbio.h", MSDNShortId = "NF:winbio.WinBioControlUnit")]
	public static extern HRESULT WinBioControlUnit(WINBIO_SESSION_HANDLE SessionHandle, WINBIO_UNIT_ID UnitId, WINBIO_COMPONENT Component, uint ControlCode,
		[In] IntPtr SendBuffer, SIZE_T SendBufferSize, [Out] IntPtr ReceiveBuffer, SIZE_T ReceiveBufferSize,
		out SIZE_T ReceiveDataSize, out uint OperationStatus);

	/// <summary>
	/// Allows the caller to perform privileged vendor-defined control operations on a biometric unit. Starting with Windows 10, build
	/// 1607, this function is available to use with a mobile image. The client must call this function to perform extended vendor
	/// operations that require elevated access rights. If no privileges are required, the client can call the WinBioControlUnit function.
	/// </summary>
	/// <param name="SessionHandle">
	/// A <c>WINBIO_SESSION_HANDLE</c> value that identifies an open biometric session. Open a synchronous session handle by calling
	/// WinBioOpenSession. Open an asynchronous session handle by calling WinBioAsyncOpenSession.
	/// </param>
	/// <param name="UnitId">
	/// A <c>WINBIO_UNIT_ID</c> value that identifies the biometric unit. This value must correspond to the unit ID used previously in
	/// the WinBioLockUnit function.
	/// </param>
	/// <param name="Component">
	/// <para>
	/// A <c>WINBIO_COMPONENT</c> value that specifies the component within the biometric unit that should perform the operation. This
	/// can be one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>WINBIO_COMPONENT_SENSOR</term>
	/// <term>Send the command to the sensor adapter.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_COMPONENT_ENGINE</term>
	/// <term>Send the command to the engine adapter.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_COMPONENT_STORAGE</term>
	/// <term>Send the command to the storage adapter.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="ControlCode">
	/// A vendor-defined code recognized by the biometric unit specified by the UnitId parameter and the adapter specified by the
	/// Component parameter.
	/// </param>
	/// <param name="SendBuffer">
	/// Address of the buffer that contains the control information to be sent to the adapter specified by the Component parameter. The
	/// format and content of the buffer is vendor-defined.
	/// </param>
	/// <param name="SendBufferSize">Size, in bytes, of the buffer specified by the SendBuffer parameter.</param>
	/// <param name="ReceiveBuffer">
	/// Address of the buffer that receives information sent by the adapter specified by the Component parameter. The format and content
	/// of the buffer is vendor-defined.
	/// </param>
	/// <param name="ReceiveBufferSize">Size, in bytes, of the buffer specified by the ReceiveBuffer parameter.</param>
	/// <param name="ReceiveDataSize">
	/// Pointer to a <c>SIZE_T</c> value that contains the size, in bytes, of the data written to the buffer specified by the
	/// ReceiveBuffer parameter.
	/// </param>
	/// <param name="OperationStatus">
	/// Pointer to an integer that contains a vendor-defined status code that specifies the outcome of the control operation.
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, it returns S_OK. If the function fails, it returns an <c>HRESULT</c> value that indicates the error.
	/// Possible values include, but are not limited to, those in the following table. For a list of common error codes, see Common
	/// HRESULT Values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_HANDLE</term>
	/// <term>The session handle is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>The value specified in the ControlCode parameter is not recognized.</term>
	/// </item>
	/// <item>
	/// <term>E_POINTER</term>
	/// <term>The SendBuffer, ReceiveBuffer, ReceiveDataSize, OperationStatus parameters cannot be NULL.</term>
	/// </item>
	/// <item>
	/// <term>E_ACCESSDENIED</term>
	/// <term>The caller does not have permission to perform the operation, or the session was not opened by using WINBIO_FLAG_MAINTENANCE.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>The value specified in the ControlCode parameter is not recognized.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_E_LOCK_VIOLATION</term>
	/// <term>The biometric unit specified by the UnitId parameter must be locked before any control operations can be performed.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Vendors who create plug-ins must decide which extended operations are privileged and which are available to all clients. To
	/// perform a privileged operation, the client application must call the <c>WinBioControlUnitPrivileged</c> function. The Windows
	/// Biometric Framework allows only clients that have the appropriate access rights to call this function. To perform an operation
	/// that does not require privileges, the client should call the WinBioControlUnit function.
	/// </para>
	/// <para>
	/// You must call WinBioLockUnit before calling <c>WinBioControlUnitPrivileged</c>. The <c>WinBioLockUnit</c> function creates a
	/// locked region in which vendor-defined operations can be securely performed.
	/// </para>
	/// <para>
	/// To call this function successfully, the session handle must have been opened by specifying <c>WINBIO_FLAG_MAINTENANCE</c>. Only
	/// the Administrators and Local System accounts have the necessary privileges.
	/// </para>
	/// <para>
	/// To use <c>WinBioControlUnitPrivileged</c> synchronously, call the function with a session handle created by calling
	/// WinBioOpenSession. The function blocks until the operation completes or an error is encountered.
	/// </para>
	/// <para>
	/// To use <c>WinBioControlUnitPrivileged</c> asynchronously, call the function with a session handle created by calling
	/// WinBioAsyncOpenSession. The framework allocates a WINBIO_ASYNC_RESULT structure and uses it to return information about
	/// operation success or failure. The <c>WINBIO_ASYNC_RESULT</c> structure is returned to the application callback or to the
	/// application message queue, depending on the value you set in the NotificationMethod parameter of the
	/// <c>WinBioAsyncOpenSession</c> function.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// If you choose to receive completion notices by using a callback, you must implement a PWINBIO_ASYNC_COMPLETION_CALLBACK function
	/// and set the NotificationMethod parameter to <c>WINBIO_ASYNC_NOTIFY_CALLBACK</c>.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If you choose to receive completion notices by using the application message queue, you must set the NotificationMethod
	/// parameter to <c>WINBIO_ASYNC_NOTIFY_MESSAGE</c>. The framework returns a WINBIO_ASYNC_RESULT pointer to the <c>LPARAM</c> field
	/// of the window message.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// To prevent memory leaks, you must call WinBioFree to release the WINBIO_ASYNC_RESULT structure after you have finished using it.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbio/nf-winbio-winbiocontrolunitprivileged HRESULT
	// WinBioControlUnitPrivileged( WINBIO_SESSION_HANDLE SessionHandle, WINBIO_UNIT_ID UnitId, WINBIO_COMPONENT Component, ULONG
	// ControlCode, PUCHAR SendBuffer, SIZE_T SendBufferSize, PUCHAR ReceiveBuffer, SIZE_T ReceiveBufferSize, SIZE_T *ReceiveDataSize,
	// ULONG *OperationStatus );
	[DllImport(Lib_Winbio, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winbio.h", MSDNShortId = "NF:winbio.WinBioControlUnitPrivileged")]
	public static extern HRESULT WinBioControlUnitPrivileged(WINBIO_SESSION_HANDLE SessionHandle, WINBIO_UNIT_ID UnitId, WINBIO_COMPONENT Component,
		uint ControlCode, [In] IntPtr SendBuffer, SIZE_T SendBufferSize, [Out] IntPtr ReceiveBuffer, SIZE_T ReceiveBufferSize,
		out SIZE_T ReceiveDataSize, out uint OperationStatus);

	/// <summary>
	/// Deletes a biometric template from the template store. Starting with Windows 10, build 1607, this function is available to use
	/// with a mobile image.
	/// </summary>
	/// <param name="SessionHandle">
	/// A <c>WINBIO_SESSION_HANDLE</c> value that identifies an open biometric session. Open a synchronous session handle by calling
	/// WinBioOpenSession. Open an asynchronous session handle by calling WinBioAsyncOpenSession.
	/// </param>
	/// <param name="UnitId">A <c>WINBIO_UNIT_ID</c> value that identifies the biometric unit where the template is located.</param>
	/// <param name="Identity">
	/// Pointer to a WINBIO_IDENTITY structure that contains the GUID or SID of the template to be deleted. If the <c>Type</c> member of
	/// the <c>WINBIO_IDENTITY</c> structure is <c>WINBIO_ID_TYPE_WILDCARD</c>, templates matching the SubFactor parameter will be
	/// deleted for all identities. Only administrators can perform wildcard identity deletion.
	/// </param>
	/// <param name="SubFactor">
	/// A <c>WINBIO_BIOMETRIC_SUBTYPE</c> value that provides additional information about the template to be deleted. If you specify
	/// WINBIO_SUBTYPE_ANY, all templates for the biometric unit specified by the UnitId parameter are deleted.
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, it returns S_OK. If the function fails, it returns an <c>HRESULT</c> value that indicates the error.
	/// Possible values include, but are not limited to, those in the following table. For a list of common error codes, see Common
	/// HRESULT Values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_HANDLE</term>
	/// <term>The session handle is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>The UnitId parameter contains zero or the SubFactor contains WINBIO_SUBTYPE_NO_INFORMATION.</term>
	/// </item>
	/// <item>
	/// <term>E_POINTER</term>
	/// <term>The pointer specified in the Identity parameter cannot be NULL.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_E_ENROLLMENT_IN_PROGRESS</term>
	/// <term>The operation could not be completed because the biometric unit is currently being used for an enrollment transaction.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// To use <c>WinBioDeleteTemplate</c> synchronously, call the function with a session handle created by calling WinBioOpenSession.
	/// The function blocks until the operation completes or an error is encountered.
	/// </para>
	/// <para>
	/// To use <c>WinBioDeleteTemplate</c> asynchronously, call the function with a session handle created by calling
	/// WinBioAsyncOpenSession. The framework allocates a WINBIO_ASYNC_RESULT structure and uses it to return information about
	/// operation success or failure. If the deletion operation is successful, the framework returns <c>WINBIO_IDENTITY</c> and
	/// <c>WINBIO_BIOMETRIC_SUBTYPE</c> information in a nested <c>DeleteTemplate</c> structure. If the operation is unsuccessful, the
	/// framework returns error information. The <c>WINBIO_ASYNC_RESULT</c> structure is returned to the application callback or to the
	/// application message queue, depending on the value you set in the NotificationMethod parameter of the
	/// <c>WinBioAsyncOpenSession</c> function:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// If you choose to receive completion notices by using a callback, you must implement a PWINBIO_ASYNC_COMPLETION_CALLBACK function
	/// and set the NotificationMethod parameter to <c>WINBIO_ASYNC_NOTIFY_CALLBACK</c>.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If you choose to receive completion notices by using the application message queue, you must set the NotificationMethod
	/// parameter to <c>WINBIO_ASYNC_NOTIFY_MESSAGE</c>. The framework returns a WINBIO_ASYNC_RESULT pointer to the <c>LPARAM</c> field
	/// of the window message.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// To prevent memory leaks, you must call WinBioFree to release the WINBIO_ASYNC_RESULT structure after you have finished using it.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following code example calls <c>WinBioDeleteTemplate</c> to delete a specific biometric template. Link to the Winbio.lib
	/// static library and include the following header files:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>Windows.h</term>
	/// </item>
	/// <item>
	/// <term>Stdio.h</term>
	/// </item>
	/// <item>
	/// <term>Conio.h</term>
	/// </item>
	/// <item>
	/// <term>Winbio.h</term>
	/// </item>
	/// </list>
	/// <para>
	/// <code>HRESULT DeleteTemplate(WINBIO_BIOMETRIC_SUBTYPE subFactor) { HRESULT hr = S_OK; WINBIO_IDENTITY identity = {0}; WINBIO_SESSION_HANDLE sessionHandle = NULL; WINBIO_UNIT_ID unitId = 0; // Find the identity of the user. hr = GetCurrentUserIdentity( &amp;identity ); if (FAILED(hr)) { wprintf_s(L"\n User identity not found. hr = 0x%x\n", hr); goto e_Exit; } // Connect to the system pool. // hr = WinBioOpenSession( WINBIO_TYPE_FINGERPRINT, // Service provider WINBIO_POOL_SYSTEM, // Pool type WINBIO_FLAG_DEFAULT, // Configuration and access NULL, // Array of biometric unit IDs 0, // Count of biometric unit IDs NULL, // Database ID &amp;sessionHandle // [out] Session handle ); if (FAILED(hr)) { wprintf_s(L"\n WinBioEnumBiometricUnits failed. hr = 0x%x\n", hr); goto e_Exit; } // Locate the sensor. // wprintf_s(L"\n Swipe your finger on the sensor...\n"); hr = WinBioLocateSensor( sessionHandle, &amp;unitId); if (FAILED(hr)) { wprintf_s(L"\n WinBioLocateSensor failed. hr = 0x%x\n", hr); goto e_Exit; } // Delete the template identified by the subFactor argument. // hr = WinBioDeleteTemplate( sessionHandle, unitId, &amp;identity, subFactor ); if (FAILED(hr)) { wprintf_s(L"\n WinBioDeleteTemplate failed. hr = 0x%x\n", hr); goto e_Exit; } e_Exit: if (sessionHandle != NULL) { WinBioCloseSession(sessionHandle); sessionHandle = NULL; } wprintf_s(L"Press any key to exit..."); _getch(); return hr; } //------------------------------------------------------------------------ // The following function retrieves the identity of the current user. // This is a helper function and is not part of the Windows Biometric // Framework API. // HRESULT GetCurrentUserIdentity(__inout PWINBIO_IDENTITY Identity) { // Declare variables. HRESULT hr = S_OK; HANDLE tokenHandle = NULL; DWORD bytesReturned = 0; struct{ TOKEN_USER tokenUser; BYTE buffer[SECURITY_MAX_SID_SIZE]; } tokenInfoBuffer; // Zero the input identity and specify the type. ZeroMemory( Identity, sizeof(WINBIO_IDENTITY)); Identity-&gt;Type = WINBIO_ID_TYPE_NULL; // Open the access token associated with the // current process if (!OpenProcessToken( GetCurrentProcess(), // Process handle TOKEN_READ, // Read access only &amp;tokenHandle)) // Access token handle { DWORD win32Status = GetLastError(); wprintf_s(L"Cannot open token handle: %d\n", win32Status); hr = HRESULT_FROM_WIN32(win32Status); goto e_Exit; } // Zero the tokenInfoBuffer structure. ZeroMemory(&amp;tokenInfoBuffer, sizeof(tokenInfoBuffer)); // Retrieve information about the access token. In this case, // retrieve a SID. if (!GetTokenInformation( tokenHandle, // Access token handle TokenUser, // User for the token &amp;tokenInfoBuffer.tokenUser, // Buffer to fill sizeof(tokenInfoBuffer), // Size of the buffer &amp;bytesReturned)) // Size needed { DWORD win32Status = GetLastError(); wprintf_s(L"Cannot query token information: %d\n", win32Status); hr = HRESULT_FROM_WIN32(win32Status); goto e_Exit; } // Copy the SID from the tokenInfoBuffer structure to the // WINBIO_IDENTITY structure. CopySid( SECURITY_MAX_SID_SIZE, Identity-&gt;Value.AccountSid.Data, tokenInfoBuffer.tokenUser.User.Sid ); // Specify the size of the SID and assign WINBIO_ID_TYPE_SID // to the type member of the WINBIO_IDENTITY structure. Identity-&gt;Value.AccountSid.Size = GetLengthSid(tokenInfoBuffer.tokenUser.User.Sid); Identity-&gt;Type = WINBIO_ID_TYPE_SID; e_Exit: if (tokenHandle != NULL) { CloseHandle(tokenHandle); } return hr; }</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbio/nf-winbio-winbiodeletetemplate HRESULT WinBioDeleteTemplate(
	// WINBIO_SESSION_HANDLE SessionHandle, WINBIO_UNIT_ID UnitId, WINBIO_IDENTITY *Identity, WINBIO_BIOMETRIC_SUBTYPE SubFactor );
	[DllImport(Lib_Winbio, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winbio.h", MSDNShortId = "NF:winbio.WinBioDeleteTemplate")]
	public static extern HRESULT WinBioDeleteTemplate(WINBIO_SESSION_HANDLE SessionHandle, WINBIO_UNIT_ID UnitId, in WINBIO_IDENTITY Identity, WINBIO_BIOMETRIC_SUBTYPE SubFactor);

	/// <summary>
	/// Initiates a biometric enrollment sequence and creates an empty biometric template. Starting with Windows 10, build 1607, this
	/// function is available to use with a mobile image.
	/// </summary>
	/// <param name="SessionHandle">
	/// A <c>WINBIO_SESSION_HANDLE</c> value that identifies an open biometric session. Open a synchronous session handle by calling
	/// WinBioOpenSession. Open an asynchronous session handle by calling WinBioAsyncOpenSession.
	/// </param>
	/// <param name="SubFactor">
	/// <para>
	/// A <c>WINBIO_BIOMETRIC_SUBTYPE</c> value that provides additional information about the enrollment. This must be one of the
	/// following values:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>WINBIO_ANSI_381_POS_RH_THUMB</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_ANSI_381_POS_RH_INDEX_FINGER</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_ANSI_381_POS_RH_MIDDLE_FINGER</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_ANSI_381_POS_RH_RING_FINGER</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_ANSI_381_POS_RH_LITTLE_FINGER</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_ANSI_381_POS_LH_THUMB</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_ANSI_381_POS_LH_INDEX_FINGER</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_ANSI_381_POS_LH_MIDDLE_FINGER</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_ANSI_381_POS_LH_RING_FINGER</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_ANSI_381_POS_LH_LITTLE_FINGER</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_ANSI_381_POS_RH_FOUR_FINGERS</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_ANSI_381_POS_LH_FOUR_FINGERS</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="UnitId">
	/// A <c>WINBIO_UNIT_ID</c> value that identifies the biometric unit. This value cannot be zero. You can find a unit ID by calling
	/// the WinBioEnumBiometricUnits or WinBioLocateSensor functions.
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, it returns S_OK. If the function fails, it returns an <c>HRESULT</c> value that indicates the error.
	/// Possible values include, but are not limited to, those in the following table. For a list of common error codes, see Common
	/// HRESULT Values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_ACCESSDENIED</term>
	/// <term>The caller does not have permission to enroll.</term>
	/// </item>
	/// <item>
	/// <term>E_HANDLE</term>
	/// <term>The session handle is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>
	/// The SubFactor parameter cannot equal WINBIO_SUBTYPE_NO_INFORMATION or WINBIO_SUBTYPE_ANY, and the UnitId parameter cannot equal zero.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WINBIO_E_ENROLLMENT_IN_PROGRESS</term>
	/// <term>An enrollment operation is already in progress, and only one enrollment can occur at a given time.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_E_LOCK_VIOLATION</term>
	/// <term>The biometric unit is in use and is locked.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// A single biometric enrollment requires the collection of multiple samples from a user. Only one enrollment operation can take
	/// place at any time, and all of the biometric samples that apply to a single enrollment must be generated by the same sensor. This
	/// sensor is specified by the UnitId parameter.
	/// </para>
	/// <para>
	/// Any application that enrolls by using a biometric unit in the system pool must have window focus when it calls
	/// <c>WinBioEnrollBegin</c>. If it does not, the call blocks until the application acquires window focus and the user has provided
	/// a biometric sample. We recommend, therefore, that your application not call <c>WinBioEnrollBegin</c> until it has acquired
	/// focus. The manner in which you acquire focus depends on the type of application you are writing. For example, if you are
	/// creating a GUI application you can implement a message handler that captures a WM_ACTIVATE, WM_SETFOCUS, or other appropriate
	/// message. If you are writing a CUI application, call <c>GetConsoleWindow</c> to retrieve a handle to the console window and pass
	/// that handle to the <c>SetForegroundWindow</c> function to force the console window into the foreground and assign it focus. If
	/// your application is running in a detached process and has no window or is a Windows service, use WinBioAcquireFocus and
	/// WinBioReleaseFocus to manually control focus.
	/// </para>
	/// <para>
	/// To use <c>WinBioEnrollBegin</c> synchronously, call the function with a session handle created by calling WinBioOpenSession. The
	/// function blocks until the operation completes or an error is encountered.
	/// </para>
	/// <para>
	/// To use <c>WinBioEnrollBegin</c> asynchronously, call the function with a session handle created by calling
	/// WinBioAsyncOpenSession. The framework allocates a WINBIO_ASYNC_RESULT structure and uses it to return information about
	/// operation success or failure. If the operation is successful, the framework returns <c>WINBIO_BIOMETRIC_SUBTYPE</c> information
	/// in a nested <c>EnrollBegin</c> structure. If the operation is unsuccessful, the framework returns error information. The
	/// <c>WINBIO_ASYNC_RESULT</c> structure is returned to the application callback or to the application message queue, depending on
	/// the value you set in the NotificationMethod parameter of the <c>WinBioAsyncOpenSession</c> function:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// If you choose to receive completion notices by using a callback, you must implement a PWINBIO_ASYNC_COMPLETION_CALLBACK function
	/// and set the NotificationMethod parameter to <c>WINBIO_ASYNC_NOTIFY_CALLBACK</c>.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If you choose to receive completion notices by using the application message queue, you must set the NotificationMethod
	/// parameter to <c>WINBIO_ASYNC_NOTIFY_MESSAGE</c>. The framework returns a WINBIO_ASYNC_RESULT pointer to the <c>LPARAM</c> field
	/// of the window message.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// To prevent memory leaks, you must call WinBioFree to release the WINBIO_ASYNC_RESULT structure after you have finished using it.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following function enrolls a biometric template in the system pool. It calls <c>WinBioEnrollBegin</c> to start the
	/// enrollment sequence. Link to the Winbio.lib static library and include the following header files:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>Windows.h</term>
	/// </item>
	/// <item>
	/// <term>Stdio.h</term>
	/// </item>
	/// <item>
	/// <term>Conio.h</term>
	/// </item>
	/// <item>
	/// <term>Winbio.h</term>
	/// </item>
	/// </list>
	/// <para>
	/// <code>HRESULT EnrollSysPool( BOOL discardEnrollment, WINBIO_BIOMETRIC_SUBTYPE subFactor) { HRESULT hr = S_OK; WINBIO_IDENTITY identity = {0}; WINBIO_SESSION_HANDLE sessionHandle = NULL; WINBIO_UNIT_ID unitId = 0; WINBIO_REJECT_DETAIL rejectDetail = 0; BOOLEAN isNewTemplate = TRUE; // Connect to the system pool. hr = WinBioOpenSession( WINBIO_TYPE_FINGERPRINT, // Service provider WINBIO_POOL_SYSTEM, // Pool type WINBIO_FLAG_DEFAULT, // Configuration and access NULL, // Array of biometric unit IDs 0, // Count of biometric unit IDs NULL, // Database ID &amp;sessionHandle // [out] Session handle ); if (FAILED(hr)) { wprintf_s(L"\n WinBioOpenSession failed. "); wprintf_s(L"hr = 0x%x\n", hr); goto e_Exit; } // Locate a sensor. wprintf_s(L"\n Swipe your finger on the sensor...\n"); hr = WinBioLocateSensor( sessionHandle, &amp;unitId); if (FAILED(hr)) { wprintf_s(L"\n WinBioLocateSensor failed. hr = 0x%x\n", hr); goto e_Exit; } // Begin the enrollment sequence. wprintf_s(L"\n Starting enrollment sequence...\n"); hr = WinBioEnrollBegin( sessionHandle, // Handle to open biometric session subFactor, // Finger to create template for unitId // Biometric unit ID ); if (FAILED(hr)) { wprintf_s(L"\n WinBioEnrollBegin failed. hr = 0x%x\n", hr); goto e_Exit; } // Capture enrollment information by swiping the sensor with // the finger identified by the subFactor argument in the // WinBioEnrollBegin function. for (int swipeCount = 1;; ++swipeCount) { wprintf_s(L"\n Swipe the sensor to capture %s sample.", (swipeCount == 1)?L"the first":L"another"); hr = WinBioEnrollCapture( sessionHandle, // Handle to open biometric session &amp;rejectDetail // [out] Failure information ); wprintf_s(L"\n Sample %d captured from unit number %d.", swipeCount, unitId); if (hr == WINBIO_I_MORE_DATA) { wprintf_s(L"\n More data required.\n"); continue; } if (FAILED(hr)) { if (hr == WINBIO_E_BAD_CAPTURE) { wprintf_s(L"\n Error: Bad capture; reason: %d", rejectDetail); continue; } else { wprintf_s(L"\n WinBioEnrollCapture failed. hr = 0x%x", hr); goto e_Exit; } } else { wprintf_s(L"\n Template completed.\n"); break; } } // Discard the enrollment if the appropriate flag is set. // Commit the enrollment if it is not discarded. if (discardEnrollment == TRUE) { wprintf_s(L"\n Discarding enrollment...\n\n"); hr = WinBioEnrollDiscard( sessionHandle ); if (FAILED(hr)) { wprintf_s(L"\n WinBioLocateSensor failed. hr = 0x%x\n", hr); } goto e_Exit; } else { wprintf_s(L"\n Committing enrollment...\n"); hr = WinBioEnrollCommit( sessionHandle, // Handle to open biometric session &amp;identity, // WINBIO_IDENTITY object for the user &amp;isNewTemplate); // Is this a new template if (FAILED(hr)) { wprintf_s(L"\n WinBioEnrollCommit failed. hr = 0x%x\n", hr); goto e_Exit; } } e_Exit: if (sessionHandle != NULL) { WinBioCloseSession(sessionHandle); sessionHandle = NULL; } wprintf_s(L" Press any key to continue..."); _getch(); return hr; }</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbio/nf-winbio-winbioenrollbegin HRESULT WinBioEnrollBegin(
	// WINBIO_SESSION_HANDLE SessionHandle, WINBIO_BIOMETRIC_SUBTYPE SubFactor, WINBIO_UNIT_ID UnitId );
	[DllImport(Lib_Winbio, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winbio.h", MSDNShortId = "NF:winbio.WinBioEnrollBegin")]
	public static extern HRESULT WinBioEnrollBegin(WINBIO_SESSION_HANDLE SessionHandle, WINBIO_BIOMETRIC_SUBTYPE SubFactor, WINBIO_UNIT_ID UnitId);

	/// <summary>
	/// Captures a biometric sample and adds it to a template. Starting with Windows 10, build 1607, this function is available to use
	/// with a mobile image.
	/// </summary>
	/// <param name="SessionHandle">
	/// A <c>WINBIO_SESSION_HANDLE</c> value that identifies an open biometric session. Open a synchronous session handle by calling
	/// WinBioOpenSession. Open an asynchronous session handle by calling WinBioAsyncOpenSession.
	/// </param>
	/// <param name="RejectDetail">
	/// <para>
	/// A pointer to a <c>ULONG</c> value that contains additional information the failure to capture a biometric sample. If the capture
	/// succeeded, this parameter is set to zero. The following values are defined for fingerprint capture:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>WINBIO_FP_TOO_HIGH</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FP_TOO_LOW</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FP_TOO_LEFT</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FP_TOO_RIGHT</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FP_TOO_FAST</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FP_TOO_SLOW</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FP_POOR_QUALITY</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FP_TOO_SKEWED</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FP_TOO_SHORT</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FP_MERGE_FAILURE</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, it returns S_OK. If the function fails, it returns an <c>HRESULT</c> value that indicates the error.
	/// Possible values include, but are not limited to, those in the following table. For a list of common error codes, see Common
	/// HRESULT Values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_ACCESSDENIED</term>
	/// <term>The calling account is not allowed to perform enrollment.</term>
	/// </item>
	/// <item>
	/// <term>E_HANDLE</term>
	/// <term>The session handle is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_POINTER</term>
	/// <term>The pointer specified by the RejectDetail parameter cannot be NULL.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_E_BAD_CAPTURE</term>
	/// <term>The sample could not be captured. Use the RejectDetail value for more information.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_E_LOCK_VIOLATION</term>
	/// <term>The biometric unit is in use and is locked.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_I_MORE_DATA</term>
	/// <term>
	/// The matching engine requires one or more additional samples to generate a reliable template. You should update instructions to
	/// the user to submit more samples and call WinBioEnrollCapture again.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Any application that enrolls by using a biometric unit in the system pool must have window focus when it calls
	/// WinBioEnrollBegin. If it does not, the call blocks until the application acquires window focus and the user has provided a
	/// biometric sample. We recommend, therefore, that your application not call <c>WinBioEnrollBegin</c> until it has acquired focus.
	/// The manner in which you acquire focus depends on the type of application you are writing. For example, if you are creating a GUI
	/// application you can implement a message handler that captures a WM_ACTIVATE, WM_SETFOCUS, or other appropriate message. If you
	/// are writing a CUI application, call <c>GetConsoleWindow</c> to retrieve a handle to the console window and pass that handle to
	/// the <c>SetForegroundWindow</c> function to force the console window into the foreground and assign it focus. If your application
	/// is running in a detached process and has no window or is a Windows service, use WinBioAcquireFocus and WinBioReleaseFocus to
	/// manually control focus.
	/// </para>
	/// <para>
	/// To use <c>WinBioEnrollCapture</c> synchronously, call the function with a session handle created by calling WinBioOpenSession.
	/// The function blocks until the operation completes or an error is encountered.
	/// </para>
	/// <para>
	/// To use <c>WinBioEnrollCapture</c> asynchronously, call the function with a session handle created by calling
	/// WinBioAsyncOpenSession. The framework allocates a WINBIO_ASYNC_RESULT structure and uses it to return information about
	/// operation success or failure. If the operation is unsuccessful, the framework returns <c>WINBIO_REJECT_DETAIL</c> information in
	/// a nested <c>EnrollCapture</c> structure. The <c>WINBIO_ASYNC_RESULT</c> structure is returned to the application callback or to
	/// the application message queue, depending on the value you set in the NotificationMethod parameter of the
	/// <c>WinBioAsyncOpenSession</c> function:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// If you choose to receive completion notices by using a callback, you must implement a PWINBIO_ASYNC_COMPLETION_CALLBACK function
	/// and set the NotificationMethod parameter to <c>WINBIO_ASYNC_NOTIFY_CALLBACK</c>.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If you choose to receive completion notices by using the application message queue, you must set the NotificationMethod
	/// parameter to <c>WINBIO_ASYNC_NOTIFY_MESSAGE</c>. The framework returns a WINBIO_ASYNC_RESULT pointer to the <c>LPARAM</c> field
	/// of the window message.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// To prevent memory leaks, you must call WinBioFree from your callback implementation to release the WINBIO_ASYNC_RESULT structure
	/// after you have finished using it.
	/// </para>
	/// <para>
	/// <c>Windows 7:</c> You can perform this operation asynchronously by using the WinBioEnrollCaptureWithCallback function. The
	/// function verifies the input arguments and returns immediately. If the input arguments are not valid, the function returns an
	/// error code. Otherwise, the framework starts the operation on another thread. When the asynchronous operation completes or
	/// encounters an error, the framework sends the results to the PWINBIO_ENROLL_CAPTURE_CALLBACK function implemented by your application.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following function enrolls a biometric template in the system pool by calling <c>WinBioEnrollCapture</c>. Link to the
	/// Winbio.lib static library and include the following header files:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>Windows.h</term>
	/// </item>
	/// <item>
	/// <term>Stdio.h</term>
	/// </item>
	/// <item>
	/// <term>Conio.h</term>
	/// </item>
	/// <item>
	/// <term>Winbio.h</term>
	/// </item>
	/// </list>
	/// <para>
	/// <code>HRESULT EnrollSysPool( BOOL discardEnrollment, WINBIO_BIOMETRIC_SUBTYPE subFactor) { HRESULT hr = S_OK; WINBIO_IDENTITY identity = {0}; WINBIO_SESSION_HANDLE sessionHandle = NULL; WINBIO_UNIT_ID unitId = 0; WINBIO_REJECT_DETAIL rejectDetail = 0; BOOLEAN isNewTemplate = TRUE; // Connect to the system pool. hr = WinBioOpenSession( WINBIO_TYPE_FINGERPRINT, // Service provider WINBIO_POOL_SYSTEM, // Pool type WINBIO_FLAG_DEFAULT, // Configuration and access NULL, // Array of biometric unit IDs 0, // Count of biometric unit IDs NULL, // Database ID &amp;sessionHandle // [out] Session handle ); if (FAILED(hr)) { wprintf_s(L"\n WinBioOpenSession failed. "); wprintf_s(L"hr = 0x%x\n", hr); goto e_Exit; } // Locate a sensor. wprintf_s(L"\n Swipe your finger on the sensor...\n"); hr = WinBioLocateSensor( sessionHandle, &amp;unitId); if (FAILED(hr)) { wprintf_s(L"\n WinBioLocateSensor failed. hr = 0x%x\n", hr); goto e_Exit; } // Begin the enrollment sequence. wprintf_s(L"\n Starting enrollment sequence...\n"); hr = WinBioEnrollBegin( sessionHandle, // Handle to open biometric session subFactor, // Finger to create template for unitId // Biometric unit ID ); if (FAILED(hr)) { wprintf_s(L"\n WinBioEnrollBegin failed. hr = 0x%x\n", hr); goto e_Exit; } // Capture enrollment information by swiping the sensor with // the finger identified by the subFactor argument in the // WinBioEnrollBegin function. for (int swipeCount = 1;; ++swipeCount) { wprintf_s(L"\n Swipe the sensor to capture %s sample.", (swipeCount == 1)?L"the first":L"another"); hr = WinBioEnrollCapture( sessionHandle, // Handle to open biometric session &amp;rejectDetail // [out] Failure information ); wprintf_s(L"\n Sample %d captured from unit number %d.", swipeCount, unitId); if (hr == WINBIO_I_MORE_DATA) { wprintf_s(L"\n More data required.\n"); continue; } if (FAILED(hr)) { if (hr == WINBIO_E_BAD_CAPTURE) { wprintf_s(L"\n Error: Bad capture; reason: %d", rejectDetail); continue; } else { wprintf_s(L"\n WinBioEnrollCapture failed. hr = 0x%x", hr); goto e_Exit; } } else { wprintf_s(L"\n Template completed.\n"); break; } } // Discard the enrollment if the appropriate flag is set. // Commit the enrollment if it is not discarded. if (discardEnrollment == TRUE) { wprintf_s(L"\n Discarding enrollment...\n\n"); hr = WinBioEnrollDiscard( sessionHandle ); if (FAILED(hr)) { wprintf_s(L"\n WinBioLocateSensor failed. hr = 0x%x\n", hr); } goto e_Exit; } else { wprintf_s(L"\n Committing enrollment...\n"); hr = WinBioEnrollCommit( sessionHandle, // Handle to open biometric session &amp;identity, // WINBIO_IDENTITY object for the user &amp;isNewTemplate); // Is this a new template if (FAILED(hr)) { wprintf_s(L"\n WinBioEnrollCommit failed. hr = 0x%x\n", hr); goto e_Exit; } } e_Exit: if (sessionHandle != NULL) { WinBioCloseSession(sessionHandle); sessionHandle = NULL; } wprintf_s(L" Press any key to continue..."); _getch(); return hr; }</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbio/nf-winbio-winbioenrollcapture HRESULT WinBioEnrollCapture(
	// WINBIO_SESSION_HANDLE SessionHandle, WINBIO_REJECT_DETAIL *RejectDetail );
	[DllImport(Lib_Winbio, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winbio.h", MSDNShortId = "NF:winbio.WinBioEnrollCapture")]
	public static extern HRESULT WinBioEnrollCapture(WINBIO_SESSION_HANDLE SessionHandle, out WINBIO_REJECT_DETAIL RejectDetail);

	/// <summary>
	/// <para>
	/// Asynchronously captures a biometric sample and adds it to a template. The function returns immediately to the caller, performs
	/// enrollment on a separate thread, and calls into an application-defined callback function to update operation status.
	/// </para>
	/// <para><c>Important</c>
	/// <para></para>
	/// We recommend that, beginning with Windows 8, you no longer use this function to start an asynchronous operation. Instead, do the following:
	/// </para>
	/// </summary>
	/// <param name="SessionHandle">A <c>WINBIO_SESSION_HANDLE</c> value that identifies an open biometric session.</param>
	/// <param name="EnrollCallback">
	/// Address of a callback function that will be called by the <c>WinBioEnrollCaptureWithCallback</c> function when the capture
	/// operation succeeds or fails. You must create the callback.
	/// </param>
	/// <param name="EnrollCallbackContext">
	/// Pointer to an optional application-defined structure that is passed to the EnrollCallbackContext parameter of the callback
	/// function. This structure can contain any data that the custom callback function is designed to handle.
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, it returns <c>S_OK</c>. If the function fails, it returns an <c>HRESULT</c> value that indicates the
	/// error. Possible values include, but are not limited to, those in the following table. For a list of common error codes, see
	/// Common HRESULT Values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_ACCESSDENIED</term>
	/// <term>The calling account is not allowed to perform enrollment.</term>
	/// </item>
	/// <item>
	/// <term>E_HANDLE</term>
	/// <term>The session handle is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_POINTER</term>
	/// <term>The pointer specified by the EnrollCallback parameter cannot be NULL.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If the SessionHandle parameter refers to the system sensor pool, the callback function will not be called until the application
	/// acquires window focus and the user has provided a biometric sample. The manner in which you acquire focus depends on the type of
	/// application you are writing. For example, if you are creating a GUI application you can implement a message handler that
	/// captures a WM_ACTIVATE, WM_SETFOCUS, or other appropriate message. If you are writing a CUI application, call
	/// <c>GetConsoleWindow</c> to retrieve a handle to the console window and pass that handle to the <c>SetForegroundWindow</c>
	/// function to force the console window into the foreground and assign it focus. If your application is running in a detached
	/// process and has no window or is a Windows service, use WinBioAcquireFocus and WinBioReleaseFocus to manually control focus.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following code example enrolls a fingerprint asynchronously by calling <c>WinBioEnrollCaptureWithCallback</c> and passing a
	/// pointer to a custom callback function. The callback function, EnrollCaptureCallback, is also shown. Link to the Winbio.lib
	/// static library.
	/// </para>
	/// <para>
	/// <code>//------------------------------------------------------------------------ // EnrollSystemPoolWithCallback.cpp : console application entry point. // #include &lt;windows.h&gt; #include &lt;stdio.h&gt; #include &lt;conio.h&gt; #include &lt;winbio.h&gt; //------------------------------------------------------------------------ // Forward declarations. // HRESULT EnrollSysPoolWithCallback( BOOL bCancel, BOOL bDiscard, WINBIO_BIOMETRIC_SUBTYPE subFactor); VOID CALLBACK EnrollCaptureCallback( __in_opt PVOID EnrollCallbackContext, __in HRESULT OperationStatus, __in WINBIO_REJECT_DETAIL RejectDetail); typedef struct _ENROLL_CALLBACK_CONTEXT { WINBIO_SESSION_HANDLE SessionHandle; WINBIO_UNIT_ID UnitId; WINBIO_BIOMETRIC_SUBTYPE SubFactor; } ENROLL_CALLBACK_CONTEXT, *PENROLL_CALLBACK_CONTEXT; //------------------------------------------------------------------------ int wmain() { HRESULT hr = S_OK; hr = EnrollSysPoolWithCallback( FALSE, FALSE, WINBIO_ANSI_381_POS_RH_INDEX_FINGER); return 0; } //------------------------------------------------------------------------ // The following function enrolls a user's fingerprint in the system pool. // The function calls WinBioEnrollCaptureWithCallback and waits for the // asynchronous enrollment process to be completed or canceled. // HRESULT EnrollSysPoolWithCallback( BOOL bCancel, BOOL bDiscard, WINBIO_BIOMETRIC_SUBTYPE subFactor) { // Declare variables HRESULT hr = S_OK; WINBIO_IDENTITY identity = {0}; WINBIO_SESSION_HANDLE sessionHandle = NULL; WINBIO_UNIT_ID unitId = 0; BOOLEAN isNewTemplate = TRUE; ENROLL_CALLBACK_CONTEXT callbackContext = {0}; // Connect to the system pool. hr = WinBioOpenSession( WINBIO_TYPE_FINGERPRINT, // Service provider WINBIO_POOL_SYSTEM, // Pool type WINBIO_FLAG_DEFAULT, // Configuration and access NULL, // Array of biometric unit IDs 0, // Count of biometric unit IDs NULL, // Database ID &amp;sessionHandle // [out] Session handle ); if (FAILED(hr)) { wprintf_s(L"\n WinBioEnumBiometricUnits failed. "); wprintf_s(L"hr = 0x%x\n", hr); goto e_Exit; } // Locate the sensor. wprintf_s(L"\n Swipe your finger to locate the sensor...\n"); hr = WinBioLocateSensor( sessionHandle, &amp;unitId); if (FAILED(hr)) { wprintf_s(L"\n WinBioLocateSensor failed. hr = 0x%x\n", hr); goto e_Exit; } // Begin the enrollment sequence. hr = WinBioEnrollBegin( sessionHandle, // Handle to open biometric session subFactor, // Finger to create template for unitId // Biometric unit ID ); if (FAILED(hr)) { wprintf_s(L"\n WinBioEnrollBegin failed. hr = 0x%x\n", hr); goto e_Exit; } // Set up the custom callback context structure. callbackContext.SessionHandle = sessionHandle; callbackContext.UnitId = unitId; callbackContext.SubFactor = subFactor; // Call WinBioEnrollCaptureWithCallback. This is an asynchronous // method that returns immediately. hr = WinBioEnrollCaptureWithCallback( sessionHandle, // Handle to open biometric session EnrollCaptureCallback, // Callback function &amp;callbackContext // Pointer to the custom context ); if (FAILED(hr)) { wprintf_s(L"\n WinBioEnrollCaptureWithCallback failed. "); wprintf_s(L"hr = 0x%x\n", hr); goto e_Exit; } wprintf_s(L"\n Swipe the sensor with the appropriate finger...\n"); // Cancel the enrollment if the bCancel flag is set. if (bCancel) { wprintf_s(L"\n Starting CANCEL timer...\n"); Sleep( 7000 ); wprintf_s(L"\n Calling WinBioCancel\n"); hr = WinBioCancel( sessionHandle ); if (FAILED(hr)) { wprintf_s(L"\n WinBioCancel failed. hr = 0x%x\n", hr); goto e_Exit; } } // Wait for the asynchronous enrollment process to complete // or be canceled. hr = WinBioWait( sessionHandle ); if (FAILED(hr)) { wprintf_s(L"\n WinBioWait failed. hr = 0x%x\n", hr); } // Discard the enrollment if the bDiscard flag is set. // Commit the enrollment if the flag is not set. if (bDiscard) { wprintf_s(L"\n Discarding enrollment...\n"); hr = WinBioEnrollDiscard( sessionHandle ); if (FAILED(hr)) { wprintf_s(L"\n WinBioLocateSensor failed. "); wprintf_s(L"hr = 0x%x\n", hr); } goto e_Exit; } else { wprintf_s(L"\n Committing enrollment...\n"); hr = WinBioEnrollCommit( sessionHandle, // Handle to open biometric session &amp;identity, // WINBIO_IDENTITY object for the user &amp;isNewTemplate); // Is this a new template if (FAILED(hr)) { wprintf_s(L"\n WinBioEnrollCommit failed. hr = 0x%x\n", hr); goto e_Exit; } } e_Exit: if (sessionHandle != NULL) { WinBioCloseSession(sessionHandle); sessionHandle = NULL; } wprintf_s(L"\n Press any key to exit..."); _getch(); return hr; } //------------------------------------------------------------------------ // The following function is the callback for the Windows Biometric // Framework WinBioEnrollCaptureWithCallback() function. // VOID CALLBACK EnrollCaptureCallback( __in_opt PVOID EnrollCallbackContext, __in HRESULT OperationStatus, __in WINBIO_REJECT_DETAIL RejectDetail ) { // Declare variables. HRESULT hr = S_OK; static SIZE_T swipeCount = 1; PENROLL_CALLBACK_CONTEXT callbackContext = (PENROLL_CALLBACK_CONTEXT)EnrollCallbackContext; wprintf_s(L"\n EnrollCaptureCallback executing\n"); wprintf_s(L"\n Sample %d captured", swipeCount++); // The capture was not acceptable or the enrollment operation // failed. if (FAILED(OperationStatus)) { if (OperationStatus == WINBIO_E_BAD_CAPTURE) { wprintf_s(L"\n Bad capture; reason: %d\n", RejectDetail); wprintf_s(L"\n Swipe your finger to capture another sample.\n"); // Try again. hr = WinBioEnrollCaptureWithCallback( callbackContext-&gt;SessionHandle, // Open session handle EnrollCaptureCallback, // Callback function EnrollCallbackContext // Callback context ); if (FAILED(hr)) { wprintf_s(L"WinBioEnrollCaptureWithCallback failed."); wprintf_s(L"hr = 0x%x\n", hr); } } else { wprintf_s(L"EnrollCaptureCallback failed."); wprintf_s(L"OperationStatus = 0x%x\n", OperationStatus); } goto e_Exit; } // The enrollment operation requires more fingerprint swipes. // This is normal and depends on your hardware. Typically, at least // three swipes are required. if (OperationStatus == WINBIO_I_MORE_DATA) { wprintf_s(L"\n More data required."); wprintf_s(L"\n Swipe your finger on the sensor again."); hr = WinBioEnrollCaptureWithCallback( callbackContext-&gt;SessionHandle, EnrollCaptureCallback, EnrollCallbackContext ); if (FAILED(hr)) { wprintf_s(L"WinBioEnrollCaptureWithCallback failed. "); wprintf_s(L"hr = 0x%x\n", hr); } goto e_Exit; } wprintf_s(L"\n Template completed\n"); e_Exit: return; }</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbio/nf-winbio-winbioenrollcapturewithcallback HRESULT
	// WinBioEnrollCaptureWithCallback( WINBIO_SESSION_HANDLE SessionHandle, PWINBIO_ENROLL_CAPTURE_CALLBACK EnrollCallback, PVOID
	// EnrollCallbackContext );
	[DllImport(Lib_Winbio, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winbio.h", MSDNShortId = "NF:winbio.WinBioEnrollCaptureWithCallback")]
	public static extern HRESULT WinBioEnrollCaptureWithCallback(WINBIO_SESSION_HANDLE SessionHandle, [In] PWINBIO_ENROLL_CAPTURE_CALLBACK EnrollCallback, [In, Optional] IntPtr EnrollCallbackContext);

	/// <summary>
	/// Finalizes a pending biometric template and saves it to the database associated with the biometric unit used for enrollment.
	/// Starting with Windows 10, build 1607, this function is available to use with a mobile image.
	/// </summary>
	/// <param name="SessionHandle">
	/// A <c>WINBIO_SESSION_HANDLE</c> value that identifies an open biometric session. Open a synchronous session handle by calling
	/// WinBioOpenSession. Open an asynchronous session handle by calling WinBioAsyncOpenSession.
	/// </param>
	/// <param name="Identity">Pointer to a WINBIO_IDENTITY structure that receives the identifier (GUID or SID) of the template.</param>
	/// <param name="IsNewTemplate">Pointer to a Boolean value that specifies whether the template being added to the database is new.</param>
	/// <returns>
	/// <para>
	/// If the function succeeds, it returns S_OK. If the function fails, it returns an <c>HRESULT</c> value that indicates the error.
	/// Possible values include, but are not limited to, those in the following table. For a list of common error codes, see Common
	/// HRESULT Values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_HANDLE</term>
	/// <term>The session handle is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_POINTER</term>
	/// <term>The pointers specified by the Identity and IsNewTemplate parameters cannot be NULL.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_E_DATABASE_FULL</term>
	/// <term>There is no space available in the database for the template.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_E_DUPLICATE_TEMPLATE</term>
	/// <term>The template matches one already saved in the database with a different identity or sub-factor (system pool only).</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_E_LOCK_VIOLATION</term>
	/// <term>The biometric unit is in use and is locked.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If the pending template is a duplicate of one that already exists in the database, the Identity parameter will point to the
	/// existing template and the value pointed to by the IsNewTemplate parameter will be <c>FALSE</c>.
	/// </para>
	/// <para>If the <c>WinBioEnrollCommit</c> function succeeds, the following registry value is set to 0x01.</para>
	/// <para><c>HKEY_LOCAL_MACHINE</c><c>System</c><c>CurrentControlSet</c><c>Services</c><c>WbioSrvc</c><c>Parameters</c><c>EnrollmentCommitted</c></para>
	/// <para><c>Note</c> This registry value is never deleted by the Windows Biometric Framework (WBF).</para>
	/// <para>
	/// To use <c>WinBioEnrollCommit</c> synchronously, call the function with a session handle created by calling WinBioOpenSession.
	/// The function blocks until the operation completes or an error is encountered.
	/// </para>
	/// <para>
	/// To use <c>WinBioEnrollCommit</c> asynchronously, call the function with a session handle created by calling
	/// WinBioAsyncOpenSession. The framework allocates a WINBIO_ASYNC_RESULT structure and uses it to return information about
	/// operation success or failure. If the operation is successful, the framework returns <c>WINBIO_IDENTITY</c> information and a
	/// flag indicating whether the template is new in a nested <c>EnrollCommit</c> structure. If the operation is unsuccessful, the
	/// framework returns error information. The <c>WINBIO_ASYNC_RESULT</c> structure is returned to the application callback or to the
	/// application message queue, depending on the value you set in the NotificationMethod parameter of the
	/// <c>WinBioAsyncOpenSession</c> function:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// If you choose to receive completion notices by using a callback, you must implement a PWINBIO_ASYNC_COMPLETION_CALLBACK function
	/// and set the NotificationMethod parameter to <c>WINBIO_ASYNC_NOTIFY_CALLBACK</c>.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If you choose to receive completion notices by using the application message queue, you must set the NotificationMethod
	/// parameter to <c>WINBIO_ASYNC_NOTIFY_MESSAGE</c>. The framework returns a WINBIO_ASYNC_RESULT pointer to the <c>LPARAM</c> field
	/// of the window message.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// To prevent memory leaks, you must call WinBioFree to release the WINBIO_ASYNC_RESULT structure after you have finished using it.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following function calls <c>WinBioEnrollCommit</c> to commit a biometric enrollment to system pool. Link to the Winbio.lib
	/// static library and include the following header files:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>Windows.h</term>
	/// </item>
	/// <item>
	/// <term>Stdio.h</term>
	/// </item>
	/// <item>
	/// <term>Conio.h</term>
	/// </item>
	/// <item>
	/// <term>Winbio.h</term>
	/// </item>
	/// </list>
	/// <para>
	/// <code>HRESULT EnrollSysPool( BOOL discardEnrollment, WINBIO_BIOMETRIC_SUBTYPE subFactor) { HRESULT hr = S_OK; WINBIO_IDENTITY identity = {0}; WINBIO_SESSION_HANDLE sessionHandle = NULL; WINBIO_UNIT_ID unitId = 0; WINBIO_REJECT_DETAIL rejectDetail = 0; BOOLEAN isNewTemplate = TRUE; // Connect to the system pool. hr = WinBioOpenSession( WINBIO_TYPE_FINGERPRINT, // Service provider WINBIO_POOL_SYSTEM, // Pool type WINBIO_FLAG_DEFAULT, // Configuration and access NULL, // Array of biometric unit IDs 0, // Count of biometric unit IDs NULL, // Database ID &amp;sessionHandle // [out] Session handle ); if (FAILED(hr)) { wprintf_s(L"\n WinBioOpenSession failed. "); wprintf_s(L"hr = 0x%x\n", hr); goto e_Exit; } // Locate a sensor. wprintf_s(L"\n Swipe your finger on the sensor...\n"); hr = WinBioLocateSensor( sessionHandle, &amp;unitId); if (FAILED(hr)) { wprintf_s(L"\n WinBioLocateSensor failed. hr = 0x%x\n", hr); goto e_Exit; } // Begin the enrollment sequence. wprintf_s(L"\n Starting enrollment sequence...\n"); hr = WinBioEnrollBegin( sessionHandle, // Handle to open biometric session subFactor, // Finger to create template for unitId // Biometric unit ID ); if (FAILED(hr)) { wprintf_s(L"\n WinBioEnrollBegin failed. hr = 0x%x\n", hr); goto e_Exit; } // Capture enrollment information by swiping the sensor with // the finger identified by the subFactor argument in the // WinBioEnrollBegin function. for (int swipeCount = 1;; ++swipeCount) { wprintf_s(L"\n Swipe the sensor to capture %s sample.", (swipeCount == 1)?L"the first":L"another"); hr = WinBioEnrollCapture( sessionHandle, // Handle to open biometric session &amp;rejectDetail // [out] Failure information ); wprintf_s(L"\n Sample %d captured from unit number %d.", swipeCount, unitId); if (hr == WINBIO_I_MORE_DATA) { wprintf_s(L"\n More data required.\n"); continue; } if (FAILED(hr)) { if (hr == WINBIO_E_BAD_CAPTURE) { wprintf_s(L"\n Error: Bad capture; reason: %d", rejectDetail); continue; } else { wprintf_s(L"\n WinBioEnrollCapture failed. hr = 0x%x", hr); goto e_Exit; } } else { wprintf_s(L"\n Template completed.\n"); break; } } // Discard the enrollment if the appropriate flag is set. // Commit the enrollment if it is not discarded. if (discardEnrollment == TRUE) { wprintf_s(L"\n Discarding enrollment...\n\n"); hr = WinBioEnrollDiscard( sessionHandle ); if (FAILED(hr)) { wprintf_s(L"\n WinBioLocateSensor failed. hr = 0x%x\n", hr); } goto e_Exit; } else { wprintf_s(L"\n Committing enrollment...\n"); hr = WinBioEnrollCommit( sessionHandle, // Handle to open biometric session &amp;identity, // WINBIO_IDENTITY object for the user &amp;isNewTemplate); // Is this a new template if (FAILED(hr)) { wprintf_s(L"\n WinBioEnrollCommit failed. hr = 0x%x\n", hr); goto e_Exit; } } e_Exit: if (sessionHandle != NULL) { WinBioCloseSession(sessionHandle); sessionHandle = NULL; } wprintf_s(L" Press any key to continue..."); _getch(); return hr; }</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbio/nf-winbio-winbioenrollcommit HRESULT WinBioEnrollCommit(
	// WINBIO_SESSION_HANDLE SessionHandle, WINBIO_IDENTITY *Identity, BOOLEAN *IsNewTemplate );
	[DllImport(Lib_Winbio, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winbio.h", MSDNShortId = "NF:winbio.WinBioEnrollCommit")]
	public static extern HRESULT WinBioEnrollCommit(WINBIO_SESSION_HANDLE SessionHandle, out WINBIO_IDENTITY Identity, [MarshalAs(UnmanagedType.U1)] out bool IsNewTemplate);

	/// <summary>
	/// Ends the enrollment sequence and discards a pending biometric template. Starting with Windows 10, build 1607, this function is
	/// available to use with a mobile image.
	/// </summary>
	/// <param name="SessionHandle">
	/// A <c>WINBIO_SESSION_HANDLE</c> value that identifies an open biometric session. Open a synchronous session handle by calling
	/// WinBioOpenSession. Open an asynchronous session handle by calling WinBioAsyncOpenSession.
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, it returns S_OK. If the function fails, it returns an <c>HRESULT</c> value that indicates the error.
	/// Possible values include, but are not limited to, those in the following table. For a list of common error codes, see Common
	/// HRESULT Values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_ACCESSDENIED</term>
	/// <term>The caller does not have permission to enroll.</term>
	/// </item>
	/// <item>
	/// <term>E_HANDLE</term>
	/// <term>The session handle is not valid.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_E_LOCK_VIOLATION</term>
	/// <term>The biometric unit is in use and is locked.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// You can use this function to allow a user to stop an enrollment sequence before saving a biometric template to the template database.
	/// </para>
	/// <para>
	/// To use <c>WinBioEnrollDiscard</c> synchronously, call the function with a session handle created by calling WinBioOpenSession.
	/// The function blocks until the operation completes or an error is encountered.
	/// </para>
	/// <para>
	/// To use <c>WinBioEnrollDiscard</c> asynchronously, call the function with a session handle created by calling
	/// WinBioAsyncOpenSession. The framework allocates a WINBIO_ASYNC_RESULT structure and uses it to return information about
	/// operation success or failure. The <c>WINBIO_ASYNC_RESULT</c> structure is returned to the application callback or to the
	/// application message queue, depending on the value you set in the NotificationMethod parameter of the
	/// <c>WinBioAsyncOpenSession</c> function:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// If you choose to receive completion notices by using a callback, you must implement a PWINBIO_ASYNC_COMPLETION_CALLBACK function
	/// and set the NotificationMethod parameter to <c>WINBIO_ASYNC_NOTIFY_CALLBACK</c>.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If you choose to receive completion notices by using the application message queue, you must set the NotificationMethod
	/// parameter to <c>WINBIO_ASYNC_NOTIFY_MESSAGE</c>. The framework returns a WINBIO_ASYNC_RESULT pointer to the <c>LPARAM</c> field
	/// of the window message.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// To prevent memory leaks, you must call WinBioFree to release the WINBIO_ASYNC_RESULT structure after you have finished using it.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following function enrolls a biometric template in the system pool. You can pass a Boolean value to the function which
	/// enables you to discard an enrollment by calling <c>WinBioEnrollDiscard</c>. Link to the Winbio.lib static library and include
	/// the following header files:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>Windows.h</term>
	/// </item>
	/// <item>
	/// <term>Stdio.h</term>
	/// </item>
	/// <item>
	/// <term>Conio.h</term>
	/// </item>
	/// <item>
	/// <term>Winbio.h</term>
	/// </item>
	/// </list>
	/// <para>
	/// <code>HRESULT EnrollSysPool( BOOL discardEnrollment, WINBIO_BIOMETRIC_SUBTYPE subFactor) { HRESULT hr = S_OK; WINBIO_IDENTITY identity = {0}; WINBIO_SESSION_HANDLE sessionHandle = NULL; WINBIO_UNIT_ID unitId = 0; WINBIO_REJECT_DETAIL rejectDetail = 0; BOOLEAN isNewTemplate = TRUE; // Connect to the system pool. hr = WinBioOpenSession( WINBIO_TYPE_FINGERPRINT, // Service provider WINBIO_POOL_SYSTEM, // Pool type WINBIO_FLAG_DEFAULT, // Configuration and access NULL, // Array of biometric unit IDs 0, // Count of biometric unit IDs NULL, // Database ID &amp;sessionHandle // [out] Session handle ); if (FAILED(hr)) { wprintf_s(L"\n WinBioOpenSession failed. "); wprintf_s(L"hr = 0x%x\n", hr); goto e_Exit; } // Locate a sensor. wprintf_s(L"\n Swipe your finger on the sensor...\n"); hr = WinBioLocateSensor( sessionHandle, &amp;unitId); if (FAILED(hr)) { wprintf_s(L"\n WinBioLocateSensor failed. hr = 0x%x\n", hr); goto e_Exit; } // Begin the enrollment sequence. wprintf_s(L"\n Starting enrollment sequence...\n"); hr = WinBioEnrollBegin( sessionHandle, // Handle to open biometric session subFactor, // Finger to create template for unitId // Biometric unit ID ); if (FAILED(hr)) { wprintf_s(L"\n WinBioEnrollBegin failed. hr = 0x%x\n", hr); goto e_Exit; } // Capture enrollment information by swiping the sensor with // the finger identified by the subFactor argument in the // WinBioEnrollBegin function. for (int swipeCount = 1;; ++swipeCount) { wprintf_s(L"\n Swipe the sensor to capture %s sample.", (swipeCount == 1)?L"the first":L"another"); hr = WinBioEnrollCapture( sessionHandle, // Handle to open biometric session &amp;rejectDetail // [out] Failure information ); wprintf_s(L"\n Sample %d captured from unit number %d.", swipeCount, unitId); if (hr == WINBIO_I_MORE_DATA) { wprintf_s(L"\n More data required.\n"); continue; } if (FAILED(hr)) { if (hr == WINBIO_E_BAD_CAPTURE) { wprintf_s(L"\n Error: Bad capture; reason: %d", rejectDetail); continue; } else { wprintf_s(L"\n WinBioEnrollCapture failed. hr = 0x%x", hr); goto e_Exit; } } else { wprintf_s(L"\n Template completed.\n"); break; } } // Discard the enrollment if the appropriate flag is set. // Commit the enrollment if it is not discarded. if (discardEnrollment == TRUE) { wprintf_s(L"\n Discarding enrollment...\n\n"); hr = WinBioEnrollDiscard( sessionHandle ); if (FAILED(hr)) { wprintf_s(L"\n WinBioLocateSensor failed. hr = 0x%x\n", hr); } goto e_Exit; } else { wprintf_s(L"\n Committing enrollment...\n"); hr = WinBioEnrollCommit( sessionHandle, // Handle to open biometric session &amp;identity, // WINBIO_IDENTITY object for the user &amp;isNewTemplate); // Is this a new template if (FAILED(hr)) { wprintf_s(L"\n WinBioEnrollCommit failed. hr = 0x%x\n", hr); goto e_Exit; } } e_Exit: if (sessionHandle != NULL) { WinBioCloseSession(sessionHandle); sessionHandle = NULL; } wprintf_s(L" Press any key to continue..."); _getch(); return hr; }</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbio/nf-winbio-winbioenrolldiscard HRESULT WinBioEnrollDiscard(
	// WINBIO_SESSION_HANDLE SessionHandle );
	[DllImport(Lib_Winbio, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winbio.h", MSDNShortId = "NF:winbio.WinBioEnrollDiscard")]
	public static extern HRESULT WinBioEnrollDiscard(WINBIO_SESSION_HANDLE SessionHandle);

	/// <summary>
	/// Specifies the individual that you want to enroll when data that represents multiple individuals is present in the sample buffer.
	/// Starting with Windows 10, build 1607, this function is available to use with a mobile image.
	/// </summary>
	/// <param name="SessionHandle">
	/// <para>
	/// A <c>WINBIO_SESSION_HANDLE</c> value that identifies an open biometric session. Open a synchronous session handle by calling
	/// WinBioOpenSession. Open an asynchronous session handle by calling WinBioAsyncOpenSession.
	/// </para>
	/// <para>
	/// For enrollment in facial recognition, use WinBioAsyncOpenSession with the PoolType parameter set to <c>WINBIO_POOL_SYSTEM</c> to
	/// get the handle.
	/// </para>
	/// </param>
	/// <param name="SelectorValue">A value that identifies that individual that you want to select for enrollment.</param>
	/// <returns>
	/// <para>
	/// If the function succeeds, it returns S_OK. If the function fails, it returns an <c>HRESULT</c> value that indicates the error.
	/// Possible values include, but are not limited to, those in the following table. For a list of common error codes, see Common
	/// HRESULT Values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_HANDLE</term>
	/// <term>The session handle is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>The SelectorValue parameter cannot equal zero.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_E_INCORRECT_SESSION_TYPE</term>
	/// <term>The session handle does not correspond to a biometric session.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>For enrollment in facial recognition, you can find the correct selector value in either of two ways:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>The value of the <c>Id</c> member of one of the WINBIO_PRESENCE structures previously sent.</term>
	/// </item>
	/// <item>
	/// <term>The data produced by the NUI face-tracking APIs.</term>
	/// </item>
	/// </list>
	/// <para>
	/// Call <c>WinBioEnrollSelect</c> to set the selector value after you call WinBioEnrollBegin to start an enrollment sequence. The
	/// selector value applies to all subsequent WinBioEnrollCapture calls. The selection setting is temporary and is automatically
	/// cleared when you finish the enrollment sequence by calling WinBioEnrollCommit or WinBioEnrollDiscard.
	/// </para>
	/// <para>
	/// If you call <c>WinBioEnrollSelect</c> for biometric factors that do not require disambiguation, such as fingerprints, the return
	/// value for the function indicates success, but function ignores the selector value.
	/// </para>
	/// <para>
	/// If you do not call <c>WinBioEnrollSelect</c> for a biometric factor that requires you to call the function, subsequent calls to
	/// WinBioEnrollCapture fail with the <c>WINBIO_E_SELECTION_REQUIRED</c> error.
	/// </para>
	/// <para>For Windows 10, the factors that require you to call <c>WinBioEnrollSelect</c> are facial features and iris.</para>
	/// <para>
	/// You can call <c>WinBioEnrollSelect</c> by using either a synchronous or asynchronous session handle. As with other calls to
	/// Windows Biometric Framework API functions, when you call <c>WinBioEnrollSelect</c> with an asynchronous session handle, the
	/// return value indicates only that the function parameters were acceptable. The actual success or failure of the operation itself
	/// will be returned to your notification routine in a WINBIO_ASYNC_RESULT structure.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbio/nf-winbio-winbioenrollselect HRESULT WinBioEnrollSelect(
	// WINBIO_SESSION_HANDLE SessionHandle, ULONGLONG SelectorValue );
	[DllImport(Lib_Winbio, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winbio.h", MSDNShortId = "NF:winbio.WinBioEnrollSelect")]
	public static extern HRESULT WinBioEnrollSelect(WINBIO_SESSION_HANDLE SessionHandle, ulong SelectorValue);

	/// <summary>Enumerates all attached biometric units that match the input type.</summary>
	/// <param name="Factor">
	/// A bitmask of WINBIO_BIOMETRIC_TYPE flags that specifies the biometric unit types to be enumerated. Only
	/// <c>WINBIO_TYPE_FINGERPRINT</c> is currently supported.
	/// </param>
	/// <param name="UnitSchemaArray">
	/// Address of a variable that receives a pointer to an array of WINBIO_UNIT_SCHEMA structures that contain information about each
	/// enumerated biometric unit. If the function does not succeed, the pointer is set to <c>NULL</c>. If the function succeeds, you
	/// must pass the pointer to WinBioFree to release memory allocated internally for the array.
	/// </param>
	/// <param name="UnitCount">Pointer to a value that specifies the number of structures pointed to by the UnitSchemaArray parameter.</param>
	/// <returns>
	/// <para>
	/// If the function succeeds, it returns S_OK. If the function fails, it returns an <c>HRESULT</c> value that indicates the error.
	/// Possible values include, but are not limited to, those in the following table. For a list of common error codes, see Common
	/// HRESULT Values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>The bitmask contained in the Factor parameter contains one or more an invalid type bits.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>There was insufficient memory to complete the request.</term>
	/// </item>
	/// <item>
	/// <term>E_POINTER</term>
	/// <term>The UnitSchemaArray and UnitCount parameters cannot be NULL.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_E_DISABLED</term>
	/// <term>Current administrative policy prohibits use of the Windows Biometric Framework API.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>Only <c>WINBIO_TYPE_FINGERPRINT</c> is currently supported in the Factor parameter.</para>
	/// <para>
	/// If information about multiple installed biometric units is returned in the array of structures pointed to by the UnitSchemaArray
	/// parameter, the units are not guaranteed to be in any particular order.
	/// </para>
	/// <para>
	/// After you are finished using the structures returned to the UnitSchemaArray parameter, you must call WinBioFree to release the
	/// memory allocated internally for the array.
	/// </para>
	/// <para>
	/// If all of the factor bits in the Factor bitmask refer to unsupported biometric types, the function returns S_OK but the value
	/// pointed to by the UnitSchemaArray parameter will be NULL and the UnitCount parameter will contain zero. Although it is not an
	/// error to inquire about unsupported biometric factors, the result of the query will be an empty set.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following function calls <c>WinBioEnumBiometricUnits</c> to enumerate the installed biometric units. Link to the Winbio.lib
	/// static library and include the following header files:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>Windows.h</term>
	/// </item>
	/// <item>
	/// <term>Stdio.h</term>
	/// </item>
	/// <item>
	/// <term>Conio.h</term>
	/// </item>
	/// <item>
	/// <term>Winbio.h</term>
	/// </item>
	/// </list>
	/// <para>
	/// <code>HRESULT EnumerateSensors( ) { // Declare variables. HRESULT hr = S_OK; PWINBIO_UNIT_SCHEMA unitSchema = NULL; SIZE_T unitCount = 0; SIZE_T index = 0; // Enumerate the installed biometric units. hr = WinBioEnumBiometricUnits( WINBIO_TYPE_FINGERPRINT, // Type of biometric unit &amp;unitSchema, // Array of unit schemas &amp;unitCount ); // Count of unit schemas if (FAILED(hr)) { wprintf_s(L"\n WinBioEnumBiometricUnits failed. hr = 0x%x\n", hr); goto e_Exit; } // Display information for each installed biometric unit. wprintf_s(L"\nSensors: \n"); for (index = 0; index &lt; unitCount; ++index) { wprintf_s(L"\n[%d]: \tUnit ID: %d\n", index, unitSchema[index].UnitId ); wprintf_s(L"\tDevice instance ID: %s\n", unitSchema[index].DeviceInstanceId ); wprintf_s(L"\tPool type: %d\n", unitSchema[index].PoolType ); wprintf_s(L"\tBiometric factor: %d\n", unitSchema[index].BiometricFactor ); wprintf_s(L"\tSensor subtype: %d\n", unitSchema[index].SensorSubType ); wprintf_s(L"\tSensor capabilities: 0x%08x\n", unitSchema[index].Capabilities ); wprintf_s(L"\tDescription: %s\n", unitSchema[index].Description ); wprintf_s(L"\tManufacturer: %s\n", unitSchema[index].Manufacturer ); wprintf_s(L"\tModel: %s\n", unitSchema[index].Model ); wprintf_s(L"\tSerial no: %s\n", unitSchema[index].SerialNumber ); wprintf_s(L"\tFirmware version: [%d.%d]\n", unitSchema[index].FirmwareVersion.MajorVersion, unitSchema[index].FirmwareVersion.MinorVersion); } e_Exit: if (unitSchema != NULL) { WinBioFree(unitSchema); unitSchema = NULL; } wprintf_s(L"\nPress any key to exit..."); _getch(); return hr; }</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbio/nf-winbio-winbioenumbiometricunits HRESULT WinBioEnumBiometricUnits(
	// WINBIO_BIOMETRIC_TYPE Factor, WINBIO_UNIT_SCHEMA **UnitSchemaArray, SIZE_T *UnitCount );
	[DllImport(Lib_Winbio, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winbio.h", MSDNShortId = "NF:winbio.WinBioEnumBiometricUnits")]
	public static extern HRESULT WinBioEnumBiometricUnits(WINBIO_BIOMETRIC_TYPE Factor, out SafeWinBioMemory UnitSchemaArray, out SIZE_T UnitCount);

	/// <summary>Enumerates all attached biometric units that match the input type.</summary>
	/// <param name="Factor">
	/// A bitmask of WINBIO_BIOMETRIC_TYPE flags that specifies the biometric unit types to be enumerated. Only
	/// <c>WINBIO_TYPE_FINGERPRINT</c> is currently supported.
	/// </param>
	/// <param name="UnitSchemaArray">
	/// Address of a variable that receives a pointer to an array of WINBIO_UNIT_SCHEMA structures that contain information about each
	/// enumerated biometric unit.
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, it returns S_OK. If the function fails, it returns an <c>HRESULT</c> value that indicates the error.
	/// Possible values include, but are not limited to, those in the following table. For a list of common error codes, see Common
	/// HRESULT Values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>The bitmask contained in the Factor parameter contains one or more an invalid type bits.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>There was insufficient memory to complete the request.</term>
	/// </item>
	/// <item>
	/// <term>E_POINTER</term>
	/// <term>The UnitSchemaArray and UnitCount parameters cannot be NULL.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_E_DISABLED</term>
	/// <term>Current administrative policy prohibits use of the Windows Biometric Framework API.</term>
	/// </item>
	/// </list>
	/// </returns>
	[PInvokeData("winbio.h", MSDNShortId = "NF:winbio.WinBioEnumBiometricUnits")]
	public static HRESULT WinBioEnumBiometricUnits(WINBIO_BIOMETRIC_TYPE Factor, out WINBIO_UNIT_SCHEMA[] UnitSchemaArray) => GetEnum(WinBioEnumBiometricUnits, Factor, out UnitSchemaArray);

	/// <summary>Enumerates all registered databases that match a specified type.</summary>
	/// <param name="Factor">
	/// A bitmask of WINBIO_BIOMETRIC_TYPE flags that specifies the biometric unit types to be enumerated. Only
	/// <c>WINBIO_TYPE_FINGERPRINT</c> is currently supported.
	/// </param>
	/// <param name="StorageSchemaArray">
	/// Address of a variable that receives a pointer to an array of WINBIO_STORAGE_SCHEMA structures that contain information about
	/// each database. If the function does not succeed, the pointer is set to <c>NULL</c>. If the function succeeds, you must pass the
	/// pointer to WinBioFree to release memory allocated internally for the array.
	/// </param>
	/// <param name="StorageCount">
	/// Pointer to a value that specifies the number of structures pointed to by the StorageSchemaArray parameter.
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, it returns S_OK. If the function fails, it returns an <c>HRESULT</c> value that indicates the error.
	/// Possible values include, but are not limited to, those in the following table. For a list of common error codes, see Common
	/// HRESULT Values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>The bitmask contained in the Factor parameter contains one or more an invalid type bits.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>There was insufficient memory to complete the request.</term>
	/// </item>
	/// <item>
	/// <term>E_POINTER</term>
	/// <term>The StorageSchemaArray and StorageCount parameters cannot be NULL.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>Only <c>WINBIO_TYPE_FINGERPRINT</c> is currently supported in the Factor parameter.</para>
	/// <para>
	/// If information about multiple databases is returned in the array of structures pointed to by the StorageSchemaArray parameter,
	/// the databases are not guaranteed to be in any particular order.
	/// </para>
	/// <para>
	/// After you are finished using the structures returned to the StorageSchemaArray parameter, you must call WinBioFree to release
	/// the memory allocated internally for the array.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following code example calls <c>WinBioEnumDatabases</c> to enumerate the biometric databases on the system. The example also
	/// includes a function, DisplayGuid, to display the database ID. Link to the Winbio.lib static library and include the following
	/// header files:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>Windows.h</term>
	/// </item>
	/// <item>
	/// <term>Stdio.h</term>
	/// </item>
	/// <item>
	/// <term>Conio.h</term>
	/// </item>
	/// <item>
	/// <term>Winbio.h</term>
	/// </item>
	/// </list>
	/// <para>
	/// <code>HRESULT EnumDatabases( ) { // Declare variables. HRESULT hr = S_OK; PWINBIO_STORAGE_SCHEMA storageSchemaArray = NULL; SIZE_T storageCount = 0; SIZE_T index = 0; // Enumerate the databases. hr = WinBioEnumDatabases( WINBIO_TYPE_FINGERPRINT, // Type of biometric unit &amp;storageSchemaArray, // Array of database schemas &amp;storageCount ); // Number of database schemas if (FAILED(hr)) { wprintf_s(L"\nWinBioEnumDatabases failed. hr = 0x%x\n", hr); goto e_Exit; } // Display information for each database. wprintf_s(L"\nDatabases:\n"); for (index = 0; index &lt; storageCount; ++index) { wprintf_s(L"\n[%d]: \tBiometric factor: 0x%08x\n", index, storageSchemaArray[index].BiometricFactor ); wprintf_s(L"\tDatabase ID: "); DisplayGuid(&amp;storageSchemaArray[index].DatabaseId); wprintf_s(L"\n"); wprintf_s(L"\tData format: "); DisplayGuid(&amp;storageSchemaArray[index].DataFormat); wprintf_s(L"\n"); wprintf_s(L"\tAttributes: 0x%08x\n", storageSchemaArray[index].Attributes); wprintf_s(L"\tFile path: %ws\n", storageSchemaArray[index].FilePath ); wprintf_s(L"\tCnx string: %ws\n", storageSchemaArray[index].ConnectionString ); wprintf_s(L"\n"); } e_Exit: if (storageSchemaArray != NULL) { WinBioFree(storageSchemaArray); storageSchemaArray = NULL; } wprintf_s(L"\nPress any key to exit..."); _getch(); return hr; } //------------------------------------------------------------------------ // The following function displays a GUID to the console window. // VOID DisplayGuid( __in PWINBIO_UUID Guid ) { wprintf_s( L"{%08X-%04X-%04X-%02X%02X-%02X%02X%02X%02X%02X%02X}", Guid-&gt;Data1, Guid-&gt;Data2, Guid-&gt;Data3, Guid-&gt;Data4[0], Guid-&gt;Data4[1], Guid-&gt;Data4[2], Guid-&gt;Data4[3], Guid-&gt;Data4[4], Guid-&gt;Data4[5], Guid-&gt;Data4[6], Guid-&gt;Data4[7] ); }</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbio/nf-winbio-winbioenumdatabases HRESULT WinBioEnumDatabases(
	// WINBIO_BIOMETRIC_TYPE Factor, WINBIO_STORAGE_SCHEMA **StorageSchemaArray, SIZE_T *StorageCount );
	[DllImport(Lib_Winbio, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winbio.h", MSDNShortId = "NF:winbio.WinBioEnumDatabases")]
	public static extern HRESULT WinBioEnumDatabases(WINBIO_BIOMETRIC_TYPE Factor, out SafeWinBioMemory StorageSchemaArray, out SIZE_T StorageCount);

	/// <summary>Enumerates all registered databases that match a specified type.</summary>
	/// <param name="Factor">
	/// A bitmask of WINBIO_BIOMETRIC_TYPE flags that specifies the biometric unit types to be enumerated. Only
	/// <c>WINBIO_TYPE_FINGERPRINT</c> is currently supported.
	/// </param>
	/// <param name="StorageSchemaArray">
	/// Address of a variable that receives a pointer to an array of WINBIO_STORAGE_SCHEMA structures that contain information about
	/// each database. If the function does not succeed, the pointer is set to <c>NULL</c>. If the function succeeds, you must pass the
	/// pointer to WinBioFree to release memory allocated internally for the array.
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, it returns S_OK. If the function fails, it returns an <c>HRESULT</c> value that indicates the error.
	/// Possible values include, but are not limited to, those in the following table. For a list of common error codes, see Common
	/// HRESULT Values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>The bitmask contained in the Factor parameter contains one or more an invalid type bits.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>There was insufficient memory to complete the request.</term>
	/// </item>
	/// <item>
	/// <term>E_POINTER</term>
	/// <term>The StorageSchemaArray and StorageCount parameters cannot be NULL.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbio/nf-winbio-winbioenumdatabases HRESULT WinBioEnumDatabases(
	// WINBIO_BIOMETRIC_TYPE Factor, WINBIO_STORAGE_SCHEMA **StorageSchemaArray, SIZE_T *StorageCount );
	[PInvokeData("winbio.h", MSDNShortId = "NF:winbio.WinBioEnumDatabases")]
	public static HRESULT WinBioEnumDatabases(WINBIO_BIOMETRIC_TYPE Factor, out WINBIO_STORAGE_SCHEMA[] StorageSchemaArray) => GetEnum(WinBioEnumDatabases, Factor, out StorageSchemaArray);

	/// <summary>
	/// Retrieves the biometric sub-factors enrolled for a specified identity and biometric unit. Starting with Windows 10, build 1607,
	/// this function is available to use with a mobile image.
	/// </summary>
	/// <param name="SessionHandle">
	/// A <c>WINBIO_SESSION_HANDLE</c> value that identifies an open biometric session. Open a synchronous session handle by calling
	/// WinBioOpenSession. Open an asynchronous session handle by calling WinBioAsyncOpenSession.
	/// </param>
	/// <param name="UnitId">A <c>WINBIO_UNIT_ID</c> value that specifies the biometric unit.</param>
	/// <param name="Identity">
	/// Pointer to a WINBIO_IDENTITY structure that contains the GUID or SID of the template from which the sub-factors are to be retrieved.
	/// </param>
	/// <param name="SubFactorArray">
	/// Address of a variable that receives a pointer to an array of sub-factors. If the function does not succeed, the pointer is set
	/// to <c>NULL</c>. If the function succeeds, you must pass the pointer to WinBioFree to release memory allocated internally for the array.
	/// </param>
	/// <param name="SubFactorCount">
	/// Pointer to a value that specifies the number of elements in the array pointed to by the SubFactorArray parameter. If the
	/// function does not succeed, this value is set to zero.
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, it returns S_OK. If the function fails, it returns an <c>HRESULT</c> value that indicates the error.
	/// Possible values include, but are not limited to, those in the following table. For a list of common error codes, see Common
	/// HRESULT Values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_HANDLE</term>
	/// <term>The session handle is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>The UnitId parameter cannot be zero.</term>
	/// </item>
	/// <item>
	/// <term>E_POINTER</term>
	/// <term>The Identity, SubFactorArray, and SubFactorCount parameters cannot be NULL.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_E_ENROLLMENT_IN_PROGRESS</term>
	/// <term>
	/// The operation could not be completed because the biometric unit specified by the UnitId parameter is currently being used for an
	/// enrollment transaction.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WINBIO_E_UNKNOWN_ID</term>
	/// <term>The GUID or SID specified by the Identity parameter cannot be found.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>WinBioEnumEnrollments</c> function is supplied primarily so that the applications can provide user feedback. For example,
	/// your application can call this function to tell the user which fingerprints are already enrolled on a specific fingerprint reader.
	/// </para>
	/// <para>
	/// After you are finished using the structures returned to the SubFactorArray parameter, you must call WinBioFree to release the
	/// memory allocated internally for the array.
	/// </para>
	/// <para>
	/// To use <c>WinBioEnumEnrollments</c> synchronously, call the function with a session handle created by calling WinBioOpenSession.
	/// The function blocks until the operation completes or an error is encountered.
	/// </para>
	/// <para>
	/// To use <c>WinBioEnumEnrollments</c> asynchronously, call the function with a session handle created by calling
	/// WinBioAsyncOpenSession. The framework allocates a WINBIO_ASYNC_RESULT structure and uses it to return information about
	/// operation success or failure. If the operation is successful, the framework returns <c>WINBIO_IDENTITY</c> and
	/// <c>WINBIO_BIOMETRIC_SUBTYPE</c> information in a nested <c>EnumEnrollments</c> structure. If the operation is unsuccessful, the
	/// framework returns error information. The <c>WINBIO_ASYNC_RESULT</c> structure is returned to the application callback or to the
	/// application message queue, depending on the value you set in the NotificationMethod parameter of the
	/// <c>WinBioAsyncOpenSession</c> function:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// If you choose to receive completion notices by using a callback, you must implement a PWINBIO_ASYNC_COMPLETION_CALLBACK function
	/// and set the NotificationMethod parameter to <c>WINBIO_ASYNC_NOTIFY_CALLBACK</c>.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If you choose to receive completion notices by using the application message queue, you must set the NotificationMethod
	/// parameter to <c>WINBIO_ASYNC_NOTIFY_MESSAGE</c>. The framework returns a WINBIO_ASYNC_RESULT pointer to the <c>LPARAM</c> field
	/// of the window message.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// To prevent memory leaks, you must call WinBioFree to release the WINBIO_ASYNC_RESULT structure after you have finished using it.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following function calls <c>WinBioEnumEnrollments</c> to enumerate the biometric sub-factors enrolled for a template. Link
	/// to the Winbio.lib static library and include the following header files:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>Windows.h</term>
	/// </item>
	/// <item>
	/// <term>Stdio.h</term>
	/// </item>
	/// <item>
	/// <term>Conio.h</term>
	/// </item>
	/// <item>
	/// <term>Winbio.h</term>
	/// </item>
	/// </list>
	/// <para>
	/// <code>HRESULT EnumEnrollments( ) { // Declare variables. HRESULT hr = S_OK; WINBIO_IDENTITY identity = {0}; WINBIO_SESSION_HANDLE sessionHandle = NULL; WINBIO_UNIT_ID unitId = 0; PWINBIO_BIOMETRIC_SUBTYPE subFactorArray = NULL; WINBIO_BIOMETRIC_SUBTYPE SubFactor = 0; SIZE_T subFactorCount = 0; WINBIO_REJECT_DETAIL rejectDetail = 0; WINBIO_BIOMETRIC_SUBTYPE subFactor = WINBIO_SUBTYPE_NO_INFORMATION; // Connect to the system pool. hr = WinBioOpenSession( WINBIO_TYPE_FINGERPRINT, // Service provider WINBIO_POOL_SYSTEM, // Pool type WINBIO_FLAG_DEFAULT, // Configuration and access NULL, // Array of biometric unit IDs 0, // Count of biometric unit IDs NULL, // Database ID &amp;sessionHandle // [out] Session handle ); if (FAILED(hr)) { wprintf_s(L"\n WinBioOpenSession failed. hr = 0x%x\n", hr); goto e_Exit; } // Locate the biometric sensor and retrieve a WINBIO_IDENTITY object. wprintf_s(L"\n Calling WinBioIdentify - Swipe finger on sensor...\n"); hr = WinBioIdentify( sessionHandle, // Session handle &amp;unitId, // Biometric unit ID &amp;identity, // User SID &amp;subFactor, // Finger sub factor &amp;rejectDetail // Rejection information ); wprintf_s(L"\n Swipe processed - Unit ID: %d\n", unitId); if (FAILED(hr)) { if (hr == WINBIO_E_UNKNOWN_ID) { wprintf_s(L"\n Unknown identity.\n"); } else if (hr == WINBIO_E_BAD_CAPTURE) { wprintf_s(L"\n Bad capture; reason: %d\n", rejectDetail); } else { wprintf_s(L"\n WinBioEnumBiometricUnits failed. hr = 0x%x\n", hr); } goto e_Exit; } // Retrieve the biometric sub-factors for the template. hr = WinBioEnumEnrollments( sessionHandle, // Session handle unitId, // Biometric unit ID &amp;identity, // Template ID &amp;subFactorArray, // Subfactors &amp;subFactorCount // Count of subfactors ); if (FAILED(hr)) { wprintf_s(L"\n WinBioEnumEnrollments failed. hr = 0x%x\n", hr); goto e_Exit; } // Print the sub-factor(s) to the console. wprintf_s(L"\n Enrollments for this user on Unit ID %d:", unitId); for (SIZE_T index = 0; index &lt; subFactorCount; ++index) { SubFactor = subFactorArray[index]; switch (SubFactor) { case WINBIO_ANSI_381_POS_RH_THUMB: wprintf_s(L"\n RH thumb\n"); break; case WINBIO_ANSI_381_POS_RH_INDEX_FINGER: wprintf_s(L"\n RH index finger\n"); break; case WINBIO_ANSI_381_POS_RH_MIDDLE_FINGER: wprintf_s(L"\n RH middle finger\n"); break; case WINBIO_ANSI_381_POS_RH_RING_FINGER: wprintf_s(L"\n RH ring finger\n"); break; case WINBIO_ANSI_381_POS_RH_LITTLE_FINGER: wprintf_s(L"\n RH little finger\n"); break; case WINBIO_ANSI_381_POS_LH_THUMB: wprintf_s(L"\n LH thumb\n"); break; case WINBIO_ANSI_381_POS_LH_INDEX_FINGER: wprintf_s(L"\n LH index finger\n"); break; case WINBIO_ANSI_381_POS_LH_MIDDLE_FINGER: wprintf_s(L"\n LH middle finger\n"); break; case WINBIO_ANSI_381_POS_LH_RING_FINGER: wprintf_s(L"\n LH ring finger\n"); break; case WINBIO_ANSI_381_POS_LH_LITTLE_FINGER: wprintf_s(L"\n LH little finger\n"); break; default: wprintf_s(L"\n The sub-factor is not correct\n"); break; } } e_Exit: if (subFactorArray!= NULL) { WinBioFree(subFactorArray); subFactorArray = NULL; } if (sessionHandle != NULL) { WinBioCloseSession(sessionHandle); sessionHandle = NULL; } wprintf_s(L"\n Press any key to exit..."); _getch(); return hr; }</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbio/nf-winbio-winbioenumenrollments HRESULT WinBioEnumEnrollments(
	// WINBIO_SESSION_HANDLE SessionHandle, WINBIO_UNIT_ID UnitId, WINBIO_IDENTITY *Identity, WINBIO_BIOMETRIC_SUBTYPE **SubFactorArray,
	// SIZE_T *SubFactorCount );
	[DllImport(Lib_Winbio, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winbio.h", MSDNShortId = "NF:winbio.WinBioEnumEnrollments")]
	public static extern HRESULT WinBioEnumEnrollments(WINBIO_SESSION_HANDLE SessionHandle, WINBIO_UNIT_ID UnitId, in WINBIO_IDENTITY Identity, out SafeWinBioMemory SubFactorArray, out SIZE_T SubFactorCount);

	/// <summary>
	/// Retrieves the biometric sub-factors enrolled for a specified identity and biometric unit. Starting with Windows 10, build 1607,
	/// this function is available to use with a mobile image.
	/// </summary>
	/// <param name="SessionHandle">
	/// A <c>WINBIO_SESSION_HANDLE</c> value that identifies an open biometric session. Open a synchronous session handle by calling
	/// WinBioOpenSession. Open an asynchronous session handle by calling WinBioAsyncOpenSession.
	/// </param>
	/// <param name="UnitId">A <c>WINBIO_UNIT_ID</c> value that specifies the biometric unit.</param>
	/// <param name="Identity">
	/// Pointer to a WINBIO_IDENTITY structure that contains the GUID or SID of the template from which the sub-factors are to be retrieved.
	/// </param>
	/// <param name="SubFactorArray">
	/// Address of a variable that receives a pointer to an array of sub-factors. If the function does not succeed, the pointer is set
	/// to <c>NULL</c>. If the function succeeds, you must pass the pointer to WinBioFree to release memory allocated internally for the array.
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, it returns S_OK. If the function fails, it returns an <c>HRESULT</c> value that indicates the error.
	/// Possible values include, but are not limited to, those in the following table. For a list of common error codes, see Common
	/// HRESULT Values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_HANDLE</term>
	/// <term>The session handle is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>The UnitId parameter cannot be zero.</term>
	/// </item>
	/// <item>
	/// <term>E_POINTER</term>
	/// <term>The Identity, SubFactorArray, and SubFactorCount parameters cannot be NULL.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_E_ENROLLMENT_IN_PROGRESS</term>
	/// <term>
	/// The operation could not be completed because the biometric unit specified by the UnitId parameter is currently being used for an
	/// enrollment transaction.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WINBIO_E_UNKNOWN_ID</term>
	/// <term>The GUID or SID specified by the Identity parameter cannot be found.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>WinBioEnumEnrollments</c> function is supplied primarily so that the applications can provide user feedback. For example,
	/// your application can call this function to tell the user which fingerprints are already enrolled on a specific fingerprint reader.
	/// </para>
	/// <para>
	/// After you are finished using the structures returned to the SubFactorArray parameter, you must call WinBioFree to release the
	/// memory allocated internally for the array.
	/// </para>
	/// <para>
	/// To use <c>WinBioEnumEnrollments</c> synchronously, call the function with a session handle created by calling WinBioOpenSession.
	/// The function blocks until the operation completes or an error is encountered.
	/// </para>
	/// <para>
	/// To use <c>WinBioEnumEnrollments</c> asynchronously, call the function with a session handle created by calling
	/// WinBioAsyncOpenSession. The framework allocates a WINBIO_ASYNC_RESULT structure and uses it to return information about
	/// operation success or failure. If the operation is successful, the framework returns <c>WINBIO_IDENTITY</c> and
	/// <c>WINBIO_BIOMETRIC_SUBTYPE</c> information in a nested <c>EnumEnrollments</c> structure. If the operation is unsuccessful, the
	/// framework returns error information. The <c>WINBIO_ASYNC_RESULT</c> structure is returned to the application callback or to the
	/// application message queue, depending on the value you set in the NotificationMethod parameter of the
	/// <c>WinBioAsyncOpenSession</c> function:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// If you choose to receive completion notices by using a callback, you must implement a PWINBIO_ASYNC_COMPLETION_CALLBACK function
	/// and set the NotificationMethod parameter to <c>WINBIO_ASYNC_NOTIFY_CALLBACK</c>.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If you choose to receive completion notices by using the application message queue, you must set the NotificationMethod
	/// parameter to <c>WINBIO_ASYNC_NOTIFY_MESSAGE</c>. The framework returns a WINBIO_ASYNC_RESULT pointer to the <c>LPARAM</c> field
	/// of the window message.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// To prevent memory leaks, you must call WinBioFree to release the WINBIO_ASYNC_RESULT structure after you have finished using it.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following function calls <c>WinBioEnumEnrollments</c> to enumerate the biometric sub-factors enrolled for a template. Link
	/// to the Winbio.lib static library and include the following header files:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>Windows.h</term>
	/// </item>
	/// <item>
	/// <term>Stdio.h</term>
	/// </item>
	/// <item>
	/// <term>Conio.h</term>
	/// </item>
	/// <item>
	/// <term>Winbio.h</term>
	/// </item>
	/// </list>
	/// <para>
	/// <code>HRESULT EnumEnrollments( ) { // Declare variables. HRESULT hr = S_OK; WINBIO_IDENTITY identity = {0}; WINBIO_SESSION_HANDLE sessionHandle = NULL; WINBIO_UNIT_ID unitId = 0; PWINBIO_BIOMETRIC_SUBTYPE subFactorArray = NULL; WINBIO_BIOMETRIC_SUBTYPE SubFactor = 0; SIZE_T subFactorCount = 0; WINBIO_REJECT_DETAIL rejectDetail = 0; WINBIO_BIOMETRIC_SUBTYPE subFactor = WINBIO_SUBTYPE_NO_INFORMATION; // Connect to the system pool. hr = WinBioOpenSession( WINBIO_TYPE_FINGERPRINT, // Service provider WINBIO_POOL_SYSTEM, // Pool type WINBIO_FLAG_DEFAULT, // Configuration and access NULL, // Array of biometric unit IDs 0, // Count of biometric unit IDs NULL, // Database ID &amp;sessionHandle // [out] Session handle ); if (FAILED(hr)) { wprintf_s(L"\n WinBioOpenSession failed. hr = 0x%x\n", hr); goto e_Exit; } // Locate the biometric sensor and retrieve a WINBIO_IDENTITY object. wprintf_s(L"\n Calling WinBioIdentify - Swipe finger on sensor...\n"); hr = WinBioIdentify( sessionHandle, // Session handle &amp;unitId, // Biometric unit ID &amp;identity, // User SID &amp;subFactor, // Finger sub factor &amp;rejectDetail // Rejection information ); wprintf_s(L"\n Swipe processed - Unit ID: %d\n", unitId); if (FAILED(hr)) { if (hr == WINBIO_E_UNKNOWN_ID) { wprintf_s(L"\n Unknown identity.\n"); } else if (hr == WINBIO_E_BAD_CAPTURE) { wprintf_s(L"\n Bad capture; reason: %d\n", rejectDetail); } else { wprintf_s(L"\n WinBioEnumBiometricUnits failed. hr = 0x%x\n", hr); } goto e_Exit; } // Retrieve the biometric sub-factors for the template. hr = WinBioEnumEnrollments( sessionHandle, // Session handle unitId, // Biometric unit ID &amp;identity, // Template ID &amp;subFactorArray, // Subfactors &amp;subFactorCount // Count of subfactors ); if (FAILED(hr)) { wprintf_s(L"\n WinBioEnumEnrollments failed. hr = 0x%x\n", hr); goto e_Exit; } // Print the sub-factor(s) to the console. wprintf_s(L"\n Enrollments for this user on Unit ID %d:", unitId); for (SIZE_T index = 0; index &lt; subFactorCount; ++index) { SubFactor = subFactorArray[index]; switch (SubFactor) { case WINBIO_ANSI_381_POS_RH_THUMB: wprintf_s(L"\n RH thumb\n"); break; case WINBIO_ANSI_381_POS_RH_INDEX_FINGER: wprintf_s(L"\n RH index finger\n"); break; case WINBIO_ANSI_381_POS_RH_MIDDLE_FINGER: wprintf_s(L"\n RH middle finger\n"); break; case WINBIO_ANSI_381_POS_RH_RING_FINGER: wprintf_s(L"\n RH ring finger\n"); break; case WINBIO_ANSI_381_POS_RH_LITTLE_FINGER: wprintf_s(L"\n RH little finger\n"); break; case WINBIO_ANSI_381_POS_LH_THUMB: wprintf_s(L"\n LH thumb\n"); break; case WINBIO_ANSI_381_POS_LH_INDEX_FINGER: wprintf_s(L"\n LH index finger\n"); break; case WINBIO_ANSI_381_POS_LH_MIDDLE_FINGER: wprintf_s(L"\n LH middle finger\n"); break; case WINBIO_ANSI_381_POS_LH_RING_FINGER: wprintf_s(L"\n LH ring finger\n"); break; case WINBIO_ANSI_381_POS_LH_LITTLE_FINGER: wprintf_s(L"\n LH little finger\n"); break; default: wprintf_s(L"\n The sub-factor is not correct\n"); break; } } e_Exit: if (subFactorArray!= NULL) { WinBioFree(subFactorArray); subFactorArray = NULL; } if (sessionHandle != NULL) { WinBioCloseSession(sessionHandle); sessionHandle = NULL; } wprintf_s(L"\n Press any key to exit..."); _getch(); return hr; }</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbio/nf-winbio-winbioenumenrollments HRESULT WinBioEnumEnrollments(
	// WINBIO_SESSION_HANDLE SessionHandle, WINBIO_UNIT_ID UnitId, WINBIO_IDENTITY *Identity, WINBIO_BIOMETRIC_SUBTYPE **SubFactorArray,
	// SIZE_T *SubFactorCount );
	[PInvokeData("winbio.h", MSDNShortId = "NF:winbio.WinBioEnumEnrollments")]
	public static HRESULT WinBioEnumEnrollments(WINBIO_SESSION_HANDLE SessionHandle, WINBIO_UNIT_ID UnitId, in WINBIO_IDENTITY Identity, out WINBIO_BIOMETRIC_SUBTYPE[] SubFactorArray)
	{
		var ret = WinBioEnumEnrollments(SessionHandle, UnitId, Identity, out var a, out var c);
		SubFactorArray = ret.Succeeded ? a.DangerousGetHandle().ToArray<WINBIO_BIOMETRIC_SUBTYPE>(c)! : new WINBIO_BIOMETRIC_SUBTYPE[0];
		return ret;
	}

	/// <summary>
	/// Retrieves information about installed biometric service providers. Starting with Windows 10, build 1607, this function is
	/// available to use with a mobile image.
	/// </summary>
	/// <param name="Factor">
	/// A bitmask of WINBIO_BIOMETRIC_TYPE flags that specifies the biometric unit types to be enumerated. Only
	/// <c>WINBIO_TYPE_FINGERPRINT</c> is currently supported.
	/// </param>
	/// <param name="BspSchemaArray">
	/// Address of a variable that receives a pointer to an array of WINBIO_BSP_SCHEMA structures that contain information about each of
	/// the available service providers. If the function does not succeed, the pointer is set to <c>NULL</c>. If the function succeeds,
	/// you must pass the pointer to WinBioFree to release memory allocated internally for the array.
	/// </param>
	/// <param name="BspCount">Pointer to a value that specifies the number of structures pointed to by the BspSchemaArray parameter.</param>
	/// <returns>
	/// <para>
	/// If the function succeeds, it returns S_OK. If the function fails, it returns an <c>HRESULT</c> value that indicates the error.
	/// Possible values include, but are not limited to, those in the following table. For a list of common error codes, see Common
	/// HRESULT Values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>The bitmask contained in the Factor parameter contains one or more an invalid type bits.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>There was insufficient memory to complete the request.</term>
	/// </item>
	/// <item>
	/// <term>E_POINTER</term>
	/// <term>The BspSchemaArray and BspCount parameters cannot be NULL.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>Only <c>WINBIO_TYPE_FINGERPRINT</c> is currently supported in the Factor parameter.</para>
	/// <para>
	/// After you are finished using the structures returned to the BspSchemaArray parameter, you must call WinBioFree to release the
	/// memory allocated internally for the array.
	/// </para>
	/// <para>
	/// If all of the factor bits in the Factor bitmask refer to unsupported biometric types, the function returns S_OK but the value
	/// pointed to by the BspSchemaArray parameter will be <c>NULL</c> and the BspCount parameter will contain zero. Although it is not
	/// an error to inquire about unsupported biometric factors, the result of the query will be an empty set.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following code example calls <c>WinBioEnumServiceProviders</c> to enumerate the installed service providers. The example
	/// also includes a function, DisplayGuid, to display the provider ID. Link to the Winbio.lib static library and include the
	/// following header files:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>Windows.h</term>
	/// </item>
	/// <item>
	/// <term>Stdio.h</term>
	/// </item>
	/// <item>
	/// <term>Conio.h</term>
	/// </item>
	/// <item>
	/// <term>Winbio.h</term>
	/// </item>
	/// </list>
	/// <para>
	/// <code>HRESULT EnumSvcProviders( ) { // Declare variables. HRESULT hr = S_OK; PWINBIO_BSP_SCHEMA bspSchemaArray = NULL; SIZE_T bspCount = 0; SIZE_T index = 0; // Enumerate the service providers. hr = WinBioEnumServiceProviders( WINBIO_TYPE_FINGERPRINT, // Provider to enumerate &amp;bspSchemaArray, // Provider schema array &amp;bspCount ); // Number of schemas returned if (FAILED(hr)) { wprintf_s(L"\n WinBioEnumServiceProviders failed. hr = 0x%x\n", hr); goto e_Exit; } // Display the schema information. wprintf_s(L"\nService providers: \n"); for (index = 0; index &lt; bspCount; ++index) { wprintf_s(L"\n[%d]: \tBiometric factor: 0x%08x\n", index, bspSchemaArray[index].BiometricFactor ); wprintf_s(L"\tBspId: "); DisplayGuid(&amp;bspSchemaArray[index].BspId); wprintf_s(L"\n"); wprintf_s(L"\tDescription: %ws\n", bspSchemaArray[index].Description); wprintf_s(L"\tVendor: %ws\n", bspSchemaArray[index].Vendor ); wprintf_s(L"\tVersion: %d.%d\n", bspSchemaArray[index].Version.MajorVersion, bspSchemaArray[index].Version.MinorVersion); wprintf_s(L"\n"); } e_Exit: if (bspSchemaArray != NULL) { WinBioFree(bspSchemaArray); bspSchemaArray = NULL; } wprintf_s(L"\nPress any key to exit..."); _getch(); return hr; } //------------------------------------------------------------------------ // The following function displays a GUID to the console window. // VOID DisplayGuid( __in PWINBIO_UUID Guid ) { wprintf_s( L"{%08X-%04X-%04X-%02X%02X-%02X%02X%02X%02X%02X%02X}", Guid-&gt;Data1, Guid-&gt;Data2, Guid-&gt;Data3, Guid-&gt;Data4[0], Guid-&gt;Data4[1], Guid-&gt;Data4[2], Guid-&gt;Data4[3], Guid-&gt;Data4[4], Guid-&gt;Data4[5], Guid-&gt;Data4[6], Guid-&gt;Data4[7] ); }</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbio/nf-winbio-winbioenumserviceproviders HRESULT
	// WinBioEnumServiceProviders( WINBIO_BIOMETRIC_TYPE Factor, WINBIO_BSP_SCHEMA **BspSchemaArray, SIZE_T *BspCount );
	[DllImport(Lib_Winbio, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winbio.h", MSDNShortId = "NF:winbio.WinBioEnumServiceProviders")]
	public static extern HRESULT WinBioEnumServiceProviders(WINBIO_BIOMETRIC_TYPE Factor, out SafeWinBioMemory BspSchemaArray, out SIZE_T BspCount);

	/// <summary>
	/// Retrieves information about installed biometric service providers. Starting with Windows 10, build 1607, this function is
	/// available to use with a mobile image.
	/// </summary>
	/// <param name="Factor">
	/// A bitmask of WINBIO_BIOMETRIC_TYPE flags that specifies the biometric unit types to be enumerated. Only
	/// <c>WINBIO_TYPE_FINGERPRINT</c> is currently supported.
	/// </param>
	/// <param name="BspSchemaArray">
	/// Address of a variable that receives a pointer to an array of WINBIO_BSP_SCHEMA structures that contain information about each of
	/// the available service providers. If the function does not succeed, the pointer is set to <c>NULL</c>. If the function succeeds,
	/// you must pass the pointer to WinBioFree to release memory allocated internally for the array.
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, it returns S_OK. If the function fails, it returns an <c>HRESULT</c> value that indicates the error.
	/// Possible values include, but are not limited to, those in the following table. For a list of common error codes, see Common
	/// HRESULT Values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>The bitmask contained in the Factor parameter contains one or more an invalid type bits.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>There was insufficient memory to complete the request.</term>
	/// </item>
	/// <item>
	/// <term>E_POINTER</term>
	/// <term>The BspSchemaArray and BspCount parameters cannot be NULL.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>Only <c>WINBIO_TYPE_FINGERPRINT</c> is currently supported in the Factor parameter.</para>
	/// <para>
	/// After you are finished using the structures returned to the BspSchemaArray parameter, you must call WinBioFree to release the
	/// memory allocated internally for the array.
	/// </para>
	/// <para>
	/// If all of the factor bits in the Factor bitmask refer to unsupported biometric types, the function returns S_OK but the value
	/// pointed to by the BspSchemaArray parameter will be <c>NULL</c> and the BspCount parameter will contain zero. Although it is not
	/// an error to inquire about unsupported biometric factors, the result of the query will be an empty set.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following code example calls <c>WinBioEnumServiceProviders</c> to enumerate the installed service providers. The example
	/// also includes a function, DisplayGuid, to display the provider ID. Link to the Winbio.lib static library and include the
	/// following header files:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>Windows.h</term>
	/// </item>
	/// <item>
	/// <term>Stdio.h</term>
	/// </item>
	/// <item>
	/// <term>Conio.h</term>
	/// </item>
	/// <item>
	/// <term>Winbio.h</term>
	/// </item>
	/// </list>
	/// <para>
	/// <code>HRESULT EnumSvcProviders( ) { // Declare variables. HRESULT hr = S_OK; PWINBIO_BSP_SCHEMA bspSchemaArray = NULL; SIZE_T bspCount = 0; SIZE_T index = 0; // Enumerate the service providers. hr = WinBioEnumServiceProviders( WINBIO_TYPE_FINGERPRINT, // Provider to enumerate &amp;bspSchemaArray, // Provider schema array &amp;bspCount ); // Number of schemas returned if (FAILED(hr)) { wprintf_s(L"\n WinBioEnumServiceProviders failed. hr = 0x%x\n", hr); goto e_Exit; } // Display the schema information. wprintf_s(L"\nService providers: \n"); for (index = 0; index &lt; bspCount; ++index) { wprintf_s(L"\n[%d]: \tBiometric factor: 0x%08x\n", index, bspSchemaArray[index].BiometricFactor ); wprintf_s(L"\tBspId: "); DisplayGuid(&amp;bspSchemaArray[index].BspId); wprintf_s(L"\n"); wprintf_s(L"\tDescription: %ws\n", bspSchemaArray[index].Description); wprintf_s(L"\tVendor: %ws\n", bspSchemaArray[index].Vendor ); wprintf_s(L"\tVersion: %d.%d\n", bspSchemaArray[index].Version.MajorVersion, bspSchemaArray[index].Version.MinorVersion); wprintf_s(L"\n"); } e_Exit: if (bspSchemaArray != NULL) { WinBioFree(bspSchemaArray); bspSchemaArray = NULL; } wprintf_s(L"\nPress any key to exit..."); _getch(); return hr; } //------------------------------------------------------------------------ // The following function displays a GUID to the console window. // VOID DisplayGuid( __in PWINBIO_UUID Guid ) { wprintf_s( L"{%08X-%04X-%04X-%02X%02X-%02X%02X%02X%02X%02X%02X}", Guid-&gt;Data1, Guid-&gt;Data2, Guid-&gt;Data3, Guid-&gt;Data4[0], Guid-&gt;Data4[1], Guid-&gt;Data4[2], Guid-&gt;Data4[3], Guid-&gt;Data4[4], Guid-&gt;Data4[5], Guid-&gt;Data4[6], Guid-&gt;Data4[7] ); }</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbio/nf-winbio-winbioenumserviceproviders HRESULT
	// WinBioEnumServiceProviders( WINBIO_BIOMETRIC_TYPE Factor, WINBIO_BSP_SCHEMA **BspSchemaArray, SIZE_T *BspCount );
	[PInvokeData("winbio.h", MSDNShortId = "NF:winbio.WinBioEnumServiceProviders")]
	public static HRESULT WinBioEnumServiceProviders(WINBIO_BIOMETRIC_TYPE Factor, out WINBIO_BSP_SCHEMA[] BspSchemaArray) => GetEnum(WinBioEnumServiceProviders, Factor, out BspSchemaArray);

	/// <summary>
	/// Releases memory allocated for the client application by an earlier call to a Windows Biometric Framework API function. Starting
	/// with Windows 10, build 1607, this function is available to use with a mobile image.
	/// </summary>
	/// <param name="Address">Address of the memory block to delete.</param>
	/// <returns>
	/// <para>
	/// If the function succeeds, it returns S_OK. If the function fails, it returns an <c>HRESULT</c> value that indicates the error.
	/// Possible values include, but are not limited to, those in the following table. For a list of common error codes, see Common
	/// HRESULT Values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_POINTER</term>
	/// <term>The Address parameter cannot be NULL.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Multiple functions in the Windows Biometric Framework API allocate memory for the client application and pass the address of
	/// that memory to the client. To prevent memory leaks, you must call <c>WinBioFree</c> to delete the block when you are done using
	/// the information it contains. You delete the memory by passing its address to <c>WinBioFree</c>. You can find the address by
	/// de-referencing the pointer specified by the appropriate parameter in each of the following functions.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Function</term>
	/// <term>Parameter</term>
	/// <term>Type of block allocated</term>
	/// </listheader>
	/// <item>
	/// <term>WinBioCaptureSample</term>
	/// <term>Sample</term>
	/// <term>Structure</term>
	/// </item>
	/// <item>
	/// <term>WinBioEnumBiometricUnits</term>
	/// <term>UnitSchemaArray</term>
	/// <term>Array of structures</term>
	/// </item>
	/// <item>
	/// <term>WinBioEnumDatabases</term>
	/// <term>StorageSchemaArray</term>
	/// <term>Array of structures</term>
	/// </item>
	/// <item>
	/// <term>WinBioEnumEnrollments</term>
	/// <term>SubFactorArray</term>
	/// <term>Array of integers</term>
	/// </item>
	/// <item>
	/// <term>WinBioEnumServiceProviders</term>
	/// <term>BspSchemaArray</term>
	/// <term>Array of structures</term>
	/// </item>
	/// <item>
	/// <term>EventCallBack</term>
	/// <term>Event</term>
	/// <term>Structure</term>
	/// </item>
	/// <item>
	/// <term>CaptureCallback</term>
	/// <term>Sample</term>
	/// <term>Structure</term>
	/// </item>
	/// </list>
	/// <para>Examples</para>
	/// <para>
	/// The following function calls WinBioEnumBiometricUnits to enumerate the installed biometric sensors, and it calls
	/// <c>WinBioFree</c> to release the memory created by <c>WinBioEnumBiometricUnits</c>. Link to the Winbio.lib static library and
	/// include the following header files:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>Windows.h</term>
	/// </item>
	/// <item>
	/// <term>Stdio.h</term>
	/// </item>
	/// <item>
	/// <term>Conio.h</term>
	/// </item>
	/// <item>
	/// <term>Winbio.h</term>
	/// </item>
	/// </list>
	/// <para>
	/// <code>HRESULT EnumerateSensors( ) { HRESULT hr = S_OK; PWINBIO_UNIT_SCHEMA unitSchema = NULL; SIZE_T unitCount = 0; // Enumerate the installed biometric units. hr = WinBioEnumBiometricUnits( WINBIO_TYPE_FINGERPRINT, // Type of biometric unit &amp;unitSchema, // Array of unit schemas &amp;unitCount ); // Count of unit schemas if (FAILED(hr)) { wprintf_s(L"\nWinBioEnumBiometricUnits failed. hr = 0x%x\n", hr); goto e_Exit; } e_Exit: // Free memory. if (unitSchema != NULL) { WinBioFree(unitSchema); unitSchema = NULL; } return hr; }</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbio/nf-winbio-winbiofree HRESULT WinBioFree( PVOID Address );
	[DllImport(Lib_Winbio, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winbio.h", MSDNShortId = "NF:winbio.WinBioFree")]
	public static extern HRESULT WinBioFree(IntPtr Address);

	/// <summary>
	/// Retrieves a value that specifies whether credentials have been set for the specified user. Starting with Windows 10, build 1607,
	/// this function is available to use with a mobile image.
	/// </summary>
	/// <param name="Identity">
	/// A WINBIO_IDENTITY structure that contains the SID of the user account for which the credential is being queried.
	/// </param>
	/// <param name="Type">
	/// <para>A WINBIO_CREDENTIAL_TYPE value that specifies the credential type. This can be one of the following values:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>WINBIO_CREDENTIAL_PASSWORD</term>
	/// <term>The password-based credential is checked.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="CredentialState">
	/// <para>
	/// Pointer to a WINBIO_CREDENTIAL_STATE enumeration value that specifies whether user credentials have been set. This can be one of
	/// the following values:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>WINBIO_CREDENTIAL_NOT_SET</term>
	/// <term>A credential has not been specified.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_CREDENTIAL_SET</term>
	/// <term>A credential has been specified.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, it returns S_OK. If the function fails, it returns an <c>HRESULT</c> value that indicates the error.
	/// Possible values include, but are not limited to, those in the following table. For a list of common error codes, see Common
	/// HRESULT Values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_ACCESSDENIED</term>
	/// <term>The caller does not have permission to retrieve the credential state.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_E_UNKNOWN_ID</term>
	/// <term>The specified identity does not exist.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_E_CRED_PROV_DISABLED</term>
	/// <term>Current administrative policy prohibits use of the credential provider.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>WinBioGetCredentialState</c> is typically used to provide feedback about credential state in a user interface. For
	/// example, an enrollment application might query credential state before prompting a user for credentials.
	/// </para>
	/// <para>Call the WinBioSetCredential function to associate credentials with a user.</para>
	/// <para>
	/// Users who do not have elevated privileges can retrieve information about only their own credentials. Elevated users can retrieve
	/// information for any credential.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following function calls <c>WinBioGetCredentialState</c> to retrieve the credential state for a user. Link to the Winbio.lib
	/// static library and include the following header files:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>Windows.h</term>
	/// </item>
	/// <item>
	/// <term>Stdio.h</term>
	/// </item>
	/// <item>
	/// <term>Conio.h</term>
	/// </item>
	/// <item>
	/// <term>Winbio.h</term>
	/// </item>
	/// </list>
	/// <para>
	/// <code>HRESULT GetCredentialState() { // Declare variables. HRESULT hr = S_OK; WINBIO_IDENTITY identity; WINBIO_CREDENTIAL_STATE credState; // Find the identity of the user. wprintf_s(L"\n Finding user identity.\n"); hr = GetCurrentUserIdentity( &amp;identity ); if (FAILED(hr)) { wprintf_s(L"\n User identity not found. hr = 0x%x\n", hr); return hr; } // Find the credential state for the user. wprintf_s(L"\n Calling WinBioGetCredentialState.\n"); hr = WinBioGetCredentialState( identity, // User GUID or SID WINBIO_CREDENTIAL_PASSWORD, // Credential type &amp;credState // [out] Credential state ); if (FAILED(hr)) { wprintf_s(L"\n WinBioGetCredentialState failed. hr = 0x%x\n", hr); goto e_Exit; } // Print the credential state. switch(credState) { case WINBIO_CREDENTIAL_SET: wprintf_s(L"\n Credential set.\n"); break; case WINBIO_CREDENTIAL_NOT_SET: wprintf_s(L"\n Credential NOT set.\n"); break; default: wprintf_s(L"\n ERROR: Invalid credential state.\n"); hr = E_FAIL; } e_Exit: wprintf_s(L"\n Press any key to exit..."); _getch(); return hr; } //------------------------------------------------------------------------ // The following function retrieves the identity of the current user. // This is a helper function and is not part of the Windows Biometric // Framework API. // HRESULT GetCurrentUserIdentity(__inout PWINBIO_IDENTITY Identity) { // Declare variables. HRESULT hr = S_OK; HANDLE tokenHandle = NULL; DWORD bytesReturned = 0; struct{ TOKEN_USER tokenUser; BYTE buffer[SECURITY_MAX_SID_SIZE]; } tokenInfoBuffer; // Zero the input identity and specify the type. ZeroMemory( Identity, sizeof(WINBIO_IDENTITY)); Identity-&gt;Type = WINBIO_ID_TYPE_NULL; // Open the access token associated with the // current process if (!OpenProcessToken( GetCurrentProcess(), // Process handle TOKEN_READ, // Read access only &amp;tokenHandle)) // Access token handle { DWORD win32Status = GetLastError(); wprintf_s(L"Cannot open token handle: %d\n", win32Status); hr = HRESULT_FROM_WIN32(win32Status); goto e_Exit; } // Zero the tokenInfoBuffer structure. ZeroMemory(&amp;tokenInfoBuffer, sizeof(tokenInfoBuffer)); // Retrieve information about the access token. In this case, // retrieve a SID. if (!GetTokenInformation( tokenHandle, // Access token handle TokenUser, // User for the token &amp;tokenInfoBuffer.tokenUser, // Buffer to fill sizeof(tokenInfoBuffer), // Size of the buffer &amp;bytesReturned)) // Size needed { DWORD win32Status = GetLastError(); wprintf_s(L"Cannot query token information: %d\n", win32Status); hr = HRESULT_FROM_WIN32(win32Status); goto e_Exit; } // Copy the SID from the tokenInfoBuffer structure to the // WINBIO_IDENTITY structure. CopySid( SECURITY_MAX_SID_SIZE, Identity-&gt;Value.AccountSid.Data, tokenInfoBuffer.tokenUser.User.Sid ); // Specify the size of the SID and assign WINBIO_ID_TYPE_SID // to the type member of the WINBIO_IDENTITY structure. Identity-&gt;Value.AccountSid.Size = GetLengthSid(tokenInfoBuffer.tokenUser.User.Sid); Identity-&gt;Type = WINBIO_ID_TYPE_SID; e_Exit: if (tokenHandle != NULL) { CloseHandle(tokenHandle); } return hr; }</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbio/nf-winbio-winbiogetcredentialstate HRESULT WinBioGetCredentialState(
	// WINBIO_IDENTITY Identity, WINBIO_CREDENTIAL_TYPE Type, WINBIO_CREDENTIAL_STATE *CredentialState );
	[DllImport(Lib_Winbio, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winbio.h", MSDNShortId = "NF:winbio.WinBioGetCredentialState")]
	public static extern HRESULT WinBioGetCredentialState(WINBIO_IDENTITY Identity, WINBIO_CREDENTIAL_TYPE Type, out WINBIO_CREDENTIAL_STATE CredentialState);

	/// <summary>Retrieves a value that specifies whether users can log on to a domain by using biometric information.</summary>
	/// <param name="Value">Pointer to a Boolean value that specifies whether biometric domain logons are enabled.</param>
	/// <param name="Source">
	/// <para>
	/// Pointer to a <c>WINBIO_SETTING_SOURCE_TYPE</c> value that specifies the setting source. This can be one of the following values:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>WINBIO_SETTING_SOURCE_INVALID</term>
	/// <term>The setting is not valid.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_SETTING_SOURCE_DEFAULT</term>
	/// <term>The setting originated from built-in policy.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_SETTING_SOURCE_LOCAL</term>
	/// <term>The setting originated in the local computer registry.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_SETTING_SOURCE_POLICY</term>
	/// <term>The setting was created by Group Policy.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// If the function succeeds, it returns S_OK. If the function fails, it returns an <c>HRESULT</c> value that indicates the error.
	/// For a list of common error codes, see Common HRESULT Values.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbio/nf-winbio-winbiogetdomainlogonsetting void WinBioGetDomainLogonSetting(
	// BOOLEAN *Value, PWINBIO_SETTING_SOURCE_TYPE Source );
	[DllImport(Lib_Winbio, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winbio.h", MSDNShortId = "NF:winbio.WinBioGetDomainLogonSetting")]
	public static extern void WinBioGetDomainLogonSetting([MarshalAs(UnmanagedType.U1)] out bool Value, out WINBIO_SETTING_SOURCE_TYPE Source);

	/// <summary>Retrieves a value that specifies whether the Windows Biometric Framework is currently enabled.</summary>
	/// <param name="Value">Pointer to a Boolean value that specifies whether the Windows Biometric Framework is currently enabled.</param>
	/// <param name="Source">
	/// <para>
	/// Pointer to a <c>WINBIO_SETTING_SOURCE_TYPE</c> value that specifics the setting source. This can be one of the following values:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>WINBIO_SETTING_SOURCE_INVALID</term>
	/// <term>The setting is not valid.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_SETTING_SOURCE_DEFAULT</term>
	/// <term>The setting originated from built-in policy.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_SETTING_SOURCE_LOCAL</term>
	/// <term>The setting originated in the local computer registry.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_SETTING_SOURCE_POLICY</term>
	/// <term>The setting was created by Group Policy.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// If the function succeeds, it returns S_OK. If the function fails, it returns an <c>HRESULT</c> value that indicates the error.
	/// For a list of common error codes, see Common HRESULT Values.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbio/nf-winbio-winbiogetenabledsetting void WinBioGetEnabledSetting( BOOLEAN
	// *Value, PWINBIO_SETTING_SOURCE_TYPE Source );
	[DllImport(Lib_Winbio, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winbio.h", MSDNShortId = "NF:winbio.WinBioGetEnabledSetting")]
	public static extern void WinBioGetEnabledSetting([MarshalAs(UnmanagedType.U1)] out bool Value, out WINBIO_SETTING_SOURCE_TYPE Source);

	/// <summary>
	/// Gets information about the biometric enrollments that the specified user has on the computer. Biometric enrollments include
	/// enrollments for facial recognition, fingerprint scanning, iris scanning, and so on.
	/// </summary>
	/// <param name="AccountOwner"><para>A WINBIO_IDENTITY structure for the user whose biometric enrollments you want to get. For example:</para>
	/// <para><code>WINBIO_IDENTITY identity = {};
	/// identity.Type = WINBIO_ID_TYPE_SID;
	/// // Move an account SID into identity.Value.AccountSid.Data.
	/// // For example, CopySid(...)</code></para>
	/// <para>To see the enrollments for every user on the computer, specify the <c>WINBIO_ID_TYPE_WILDCARD</c> identity type for the
	/// WINBIO_IDENTITY structure that you specify for the AccountOwner parameter. For example:</para>
	/// <para><code>WINBIO_IDENTITY identity = {};
	/// identity.Type = WINBIO_ID_TYPE_WILDCARD;</code></para></param>
	/// <param name="EnrolledFactors">
	/// <para>
	/// A set of WINBIO_BIOMETRIC_TYPE flags that indicate the biometric enrollments that the specified user has on the computer. A
	/// value of 0 indicates that the user has no biometric enrollments.
	/// </para>
	/// <para>
	/// These enrollments represent system pool enrollments only, such as enrollments that you can use to authenticate a user for
	/// sign-in, unlock, and so on. This value does not include private pool enrollments.
	/// </para>
	/// <para>
	/// If you specify the wildcard identity type for the WINBIO_IDENTITY structure that you use for the AccountOwner parameter, this
	/// set of flags represents the combined set of enrollments for all users with accounts on the computer.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, it returns <c>S_OK</c>. If the function fails, it returns an <c>HRESULT</c> value that indicates the
	/// error. Possible values include, but are not limited to, those in the following table. For a list of common error codes, see
	/// Common HRESULT Values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_POINTER</term>
	/// <term>The AccountOwner and EnrolledFactors parameters cannot be NULL.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>
	/// The Type member of the WINBIO_IDENTITY structure that the AccountOnwer parameter specified was not WINBIO_ID_TYPE_SID or
	/// WINBIO_ID_TYPE_WILDCARD, or the AccountSid member of the WINBIO_IDENTITY structure was not valid.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>WinBioGetEnrolledFactors</c> does not require a biometric session handle and does not activate the biometric service.
	/// Consequently, <c>WinBioGetEnrolledFactors</c> runs quickly and is useful when your code needs to make quick decisions about how
	/// to proceed when time is critical for the set of operations you need to perform.
	/// </para>
	/// <para>
	/// <c>WinBioGetEnrolledFactors</c> provides credential providers with a way to tailor their UI appropriately. For example, the
	/// login screen calls <c>WinBioGetEnrolledFactors</c> to determine whether to display the option to login with a fingerprint.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// <code>WINBIO_BIOMETRIC_TYPE enrolledFactors = WINBIO_NO_TYPE_AVAILABLE;
	/// WINBIO_IDENTITY identity = {};
	/// identity.Type = WINBIO_ID_TYPE_SID;
	/// // Move an account SID into identity.Value.AccountSid.Data.
	/// // e.g., CopySid(...)
	/// HRESULT hr = WinBioGetEnrolledFactors(&amp;identity, &amp;enrolledFactors);</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbio/nf-winbio-winbiogetenrolledfactors HRESULT WinBioGetEnrolledFactors(
	// WINBIO_IDENTITY *AccountOwner, WINBIO_BIOMETRIC_TYPE *EnrolledFactors );
	[DllImport(Lib_Winbio, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winbio.h", MSDNShortId = "NF:winbio.WinBioGetEnrolledFactors")]
	public static extern HRESULT WinBioGetEnrolledFactors(in WINBIO_IDENTITY AccountOwner, out WINBIO_BIOMETRIC_TYPE EnrolledFactors);

	/// <summary>Retrieves a value that indicates whether users can log on by using biometric information.</summary>
	/// <param name="Value">Pointer to a Boolean value that specifies whether biometric logons are enabled.</param>
	/// <param name="Source">
	/// <para>
	/// Pointer to a <c>WINBIO_SETTING_SOURCE_TYPE</c> value that specifics the setting source. This can be one of the following values:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>WINBIO_SETTING_SOURCE_INVALID</term>
	/// <term>The setting is not valid.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_SETTING_SOURCE_DEFAULT</term>
	/// <term>The setting originated from built-in policy.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_SETTING_SOURCE_LOCAL</term>
	/// <term>The setting originated in the local computer registry.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_SETTING_SOURCE_POLICY</term>
	/// <term>The setting was created by Group Policy.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// If the function succeeds, it returns S_OK. If the function fails, it returns an <c>HRESULT</c> value that indicates the error.
	/// For a list of common error codes, see Common HRESULT Values.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbio/nf-winbio-winbiogetlogonsetting void WinBioGetLogonSetting( BOOLEAN
	// *Value, PWINBIO_SETTING_SOURCE_TYPE Source );
	[DllImport(Lib_Winbio, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winbio.h", MSDNShortId = "NF:winbio.WinBioGetLogonSetting")]
	public static extern void WinBioGetLogonSetting([MarshalAs(UnmanagedType.U1)] out bool Value, out WINBIO_SETTING_SOURCE_TYPE Source);

	/// <summary>
	/// Retrieves a session, unit, or template property. Starting with Windows 10, build 1607, this function is available to use with a
	/// mobile image.
	/// </summary>
	/// <param name="SessionHandle">
	/// A WINBIO_SESSION_HANDLE value that identifies an open biometric session. Open a synchronous session handle by calling
	/// WinBioOpenSession. Open an asynchronous session handle by calling WinBioAsyncOpenSession.
	/// </param>
	/// <param name="PropertyType">
	/// A WINBIO_PROPERTY_TYPE value that specifies the source of the property information. Currently this must be
	/// WINBIO_PROPERTY_TYPE_UNIT or WINBIO_PROPERTY_TYPE_ACCOUNT. For more information about property types, see WINBIO_PROPERTY_TYPE Constants.
	/// <para>The WINBIO_PROPERTY_TYPE_ACCOUNT value is supported starting in Windows 10.</para>
	/// </param>
	/// <param name="PropertyId">A WINBIO_PROPERTY_ID value that specifies the property that you want to query.</param>
	/// <param name="UnitId">
	/// A WINBIO_UNIT_ID value that identifies the biometric unit. You can find a unit identifier by calling the
	/// WinBioEnumBiometricUnits or WinBioLocateSensor functions.
	/// <para>
	/// If you specify WINBIO_PROPERTY_ANTI_SPOOF_POLICY as the value for the PropertyId parameter, specify 0 for the UnitId
	/// parameter.If you specify any other property with the PropertyId parameter, you cannot specify 0 for the UnitId parameter.
	/// </para>
	/// </param>
	/// <param name="Identity">
	/// A WINBIO_IDENTITY structure that provides the SID of the account for which you want to get the antispoofing policy, if you
	/// specify WINBIO_PROPERTY_ANTI_SPOOF_POLICY as the value of the PropertyId parameter.
	/// <para>If you specify any other value for the PropertyId parameter, the Identity parameter must be NULL.</para>
	/// </param>
	/// <param name="SubFactor">Reserved. This must be WINBIO_SUBTYPE_NO_INFORMATION.</param>
	/// <param name="PropertyBuffer">
	/// Address of a pointer to a buffer that receives the property value. For information about the contents of this buffer for
	/// different properties, see the descriptions of the property values for the PropertyId parameter.
	/// </param>
	/// <param name="PropertyBufferSize">
	/// Pointer to a variable that receives the size, in bytes, of the buffer pointed to by the PropertyBuffer parameter.
	/// </param>
	/// <returns>
	/// If the function succeeds, it returns S_OK. If the function fails, it returns an HRESULT value that indicates the error. Possible
	/// values include, but are not limited to, those in the following table. For a list of common error codes, see Common HRESULT Values.
	/// </returns>
	/// <remarks>
	/// <para>
	/// To use WinBioGetProperty synchronously, call the function with a session handle created by calling WinBioOpenSession. The
	/// function blocks until the operation completes or an error is encountered. To prevent memory leaks when you use WinBioGetProperty
	/// synchronously, you must call WinBioFree to release the memory pointed to by the PropertyBuffer parameter when you are finished
	/// using the data contained in the buffer.
	/// </para>
	/// <para>
	/// To use WinBioGetProperty asynchronously, call the function with a session handle created by calling WinBioAsyncOpenSession. The
	/// framework allocates a WINBIO_ASYNC_RESULT structure and uses it to return information about operation success or failure. If the
	/// operation is successful, the framework returns information in a nested GetProperty structure. The WINBIO_ASYNC_RESULT structure
	/// is returned to the application callback or to the application message queue, depending on the value you set in the
	/// NotificationMethod parameter of the WinBioAsyncOpenSession function:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// If you choose to receive completion notices by using a callback, you must implement a PWINBIO_ASYNC_COMPLETION_CALLBACK function
	/// and set the NotificationMethod parameter to WINBIO_ASYNC_NOTIFY_CALLBACK.
	/// </item>
	/// <item>
	/// If you choose to receive completion notices by using the application message queue, you must set the NotificationMethod
	/// parameter to WINBIO_ASYNC_NOTIFY_MESSAGE. The framework returns a WINBIO_ASYNC_RESULT pointer to the LPARAM field of the window message.
	/// </item>
	/// </list>
	/// <para>
	/// To prevent memory leaks when you use WinBioGetProperty asynchronously, you must call WinBioFree to release the
	/// WINBIO_ASYNC_RESULT structure after you have finished using it. The WINBIO_ASYNC_RESULT structure and the property buffer occupy
	/// a single block of memory, so your application only needs to pass the address of the WINBIO_ASYNC_RESULT structure to WinBioFree.
	/// When you call WinBioFree this way, WinBioFree automatically releases both the WINBIO_ASYNC_RESULT structure and the property
	/// buffer. If you try to release the property buffer separately in this case, the application stops responding.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbio/nf-winbio-winbiogetproperty
	[DllImport(Lib_Winbio, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winbio.h", MSDNShortId = "NF:winbio.WinBioGetProperty")]
	public static extern HRESULT WinBioGetProperty(WINBIO_SESSION_HANDLE SessionHandle, WINBIO_PROPERTY_TYPE PropertyType, WINBIO_PROPERTY_ID PropertyId,
		[In, Optional] WINBIO_UNIT_ID UnitId, [In, Optional] IntPtr Identity, [In, Optional] WINBIO_BIOMETRIC_SUBTYPE SubFactor,
		out SafeWinBioMemory PropertyBuffer, out SIZE_T PropertyBufferSize);

	/// <summary>
	/// Retrieves a session, unit, or template property. Starting with Windows 10, build 1607, this function is available to use with a
	/// mobile image.
	/// </summary>
	/// <param name="SessionHandle">
	/// A WINBIO_SESSION_HANDLE value that identifies an open biometric session. Open a synchronous session handle by calling
	/// WinBioOpenSession. Open an asynchronous session handle by calling WinBioAsyncOpenSession.
	/// </param>
	/// <param name="PropertyType">
	/// A WINBIO_PROPERTY_TYPE value that specifies the source of the property information. Currently this must be
	/// WINBIO_PROPERTY_TYPE_UNIT or WINBIO_PROPERTY_TYPE_ACCOUNT. For more information about property types, see WINBIO_PROPERTY_TYPE Constants.
	/// <para>The WINBIO_PROPERTY_TYPE_ACCOUNT value is supported starting in Windows 10.</para>
	/// </param>
	/// <param name="PropertyId">A WINBIO_PROPERTY_ID value that specifies the property that you want to query.</param>
	/// <param name="UnitId">
	/// A WINBIO_UNIT_ID value that identifies the biometric unit. You can find a unit identifier by calling the
	/// WinBioEnumBiometricUnits or WinBioLocateSensor functions.
	/// <para>
	/// If you specify WINBIO_PROPERTY_ANTI_SPOOF_POLICY as the value for the PropertyId parameter, specify 0 for the UnitId
	/// parameter.If you specify any other property with the PropertyId parameter, you cannot specify 0 for the UnitId parameter.
	/// </para>
	/// </param>
	/// <param name="Identity">
	/// A WINBIO_IDENTITY structure that provides the SID of the account for which you want to get the antispoofing policy, if you
	/// specify WINBIO_PROPERTY_ANTI_SPOOF_POLICY as the value of the PropertyId parameter.
	/// <para>If you specify any other value for the PropertyId parameter, the Identity parameter must be NULL.</para>
	/// </param>
	/// <param name="SubFactor">Reserved. This must be WINBIO_SUBTYPE_NO_INFORMATION.</param>
	/// <param name="PropertyBuffer">
	/// Address of a pointer to a buffer that receives the property value. For information about the contents of this buffer for
	/// different properties, see the descriptions of the property values for the PropertyId parameter.
	/// </param>
	/// <param name="PropertyBufferSize">
	/// Pointer to a variable that receives the size, in bytes, of the buffer pointed to by the PropertyBuffer parameter.
	/// </param>
	/// <returns>
	/// If the function succeeds, it returns S_OK. If the function fails, it returns an HRESULT value that indicates the error. Possible
	/// values include, but are not limited to, those in the following table. For a list of common error codes, see Common HRESULT Values.
	/// </returns>
	/// <remarks>
	/// <para>
	/// To use WinBioGetProperty synchronously, call the function with a session handle created by calling WinBioOpenSession. The
	/// function blocks until the operation completes or an error is encountered. To prevent memory leaks when you use WinBioGetProperty
	/// synchronously, you must call WinBioFree to release the memory pointed to by the PropertyBuffer parameter when you are finished
	/// using the data contained in the buffer.
	/// </para>
	/// <para>
	/// To use WinBioGetProperty asynchronously, call the function with a session handle created by calling WinBioAsyncOpenSession. The
	/// framework allocates a WINBIO_ASYNC_RESULT structure and uses it to return information about operation success or failure. If the
	/// operation is successful, the framework returns information in a nested GetProperty structure. The WINBIO_ASYNC_RESULT structure
	/// is returned to the application callback or to the application message queue, depending on the value you set in the
	/// NotificationMethod parameter of the WinBioAsyncOpenSession function:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// If you choose to receive completion notices by using a callback, you must implement a PWINBIO_ASYNC_COMPLETION_CALLBACK function
	/// and set the NotificationMethod parameter to WINBIO_ASYNC_NOTIFY_CALLBACK.
	/// </item>
	/// <item>
	/// If you choose to receive completion notices by using the application message queue, you must set the NotificationMethod
	/// parameter to WINBIO_ASYNC_NOTIFY_MESSAGE. The framework returns a WINBIO_ASYNC_RESULT pointer to the LPARAM field of the window message.
	/// </item>
	/// </list>
	/// <para>
	/// To prevent memory leaks when you use WinBioGetProperty asynchronously, you must call WinBioFree to release the
	/// WINBIO_ASYNC_RESULT structure after you have finished using it. The WINBIO_ASYNC_RESULT structure and the property buffer occupy
	/// a single block of memory, so your application only needs to pass the address of the WINBIO_ASYNC_RESULT structure to WinBioFree.
	/// When you call WinBioFree this way, WinBioFree automatically releases both the WINBIO_ASYNC_RESULT structure and the property
	/// buffer. If you try to release the property buffer separately in this case, the application stops responding.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbio/nf-winbio-winbiogetproperty
	[DllImport(Lib_Winbio, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winbio.h", MSDNShortId = "NF:winbio.WinBioGetProperty")]
	public static extern HRESULT WinBioGetProperty(WINBIO_SESSION_HANDLE SessionHandle, WINBIO_PROPERTY_TYPE PropertyType, WINBIO_PROPERTY_ID PropertyId,
		[In, Optional] WINBIO_UNIT_ID UnitId, in WINBIO_IDENTITY Identity, [In, Optional] WINBIO_BIOMETRIC_SUBTYPE SubFactor,
		out SafeWinBioMemory PropertyBuffer, out SIZE_T PropertyBufferSize);

	/// <summary>
	/// Captures a biometric sample and determines whether it matches an existing biometric template. Starting with Windows 10, build
	/// 1607, this function is available to use with a mobile image.
	/// </summary>
	/// <param name="SessionHandle">
	/// A <c>WINBIO_SESSION_HANDLE</c> value that identifies an open biometric session. Open a synchronous session handle by calling
	/// WinBioOpenSession. Open an asynchronous session handle by calling WinBioAsyncOpenSession.
	/// </param>
	/// <param name="UnitId">A pointer to a <c>ULONG</c> value that specifies the biometric unit used to perform the identification.</param>
	/// <param name="Identity">
	/// Pointer to a WINBIO_IDENTITY structure that receives the GUID or SID of the user providing the biometric sample.
	/// </param>
	/// <param name="SubFactor">
	/// Pointer to a <c>WINBIO_BIOMETRIC_SUBTYPE</c> value that receives the sub-factor associated with the biometric sample. See the
	/// Remarks section for more details.
	/// </param>
	/// <param name="RejectDetail">
	/// <para>
	/// A pointer to a <c>ULONG</c> value that contains additional information about the failure, if any, to capture a biometric sample.
	/// If the capture succeeded, this parameter is set to zero. The following values are defined for fingerprint capture:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>WINBIO_FP_TOO_HIGH</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FP_TOO_LOW</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FP_TOO_LEFT</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FP_TOO_RIGHT</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FP_TOO_FAST</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FP_TOO_SLOW</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FP_POOR_QUALITY</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FP_TOO_SKEWED</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FP_TOO_SHORT</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FP_MERGE_FAILURE</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, it returns S_OK. If the function fails, it returns an <c>HRESULT</c> value that indicates the error.
	/// Possible values include, but are not limited to, those in the following table. For a list of common error codes, see Common
	/// HRESULT Values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_HANDLE</term>
	/// <term>The session handle is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_POINTER</term>
	/// <term>The pointer specified by the UnitId, Identity, SubFactor, or RejectDetail parameters cannot be NULL.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_E_BAD_CAPTURE</term>
	/// <term>The sample could not be captured. Use the RejectDetail value for more information.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_E_ENROLLMENT_IN_PROGRESS</term>
	/// <term>
	/// The operation could not be completed because the biometric unit is currently being used for an enrollment transaction (system
	/// pool only).
	/// </term>
	/// </item>
	/// <item>
	/// <term>WINBIO_E_UNKNOWN_ID</term>
	/// <term>The biometric sample does not match any saved in the database.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The value returned in the SubFactor parameter specifies the sub-factor associated with the biometric sample. The Windows
	/// Biometric Framework (WBF) currently supports only fingerprint capture and uses the following constants to represent sub-type information.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>WINBIO_ANSI_381_POS_RH_THUMB</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_ANSI_381_POS_RH_INDEX_FINGER</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_ANSI_381_POS_RH_MIDDLE_FINGER</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_ANSI_381_POS_RH_RING_FINGER</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_ANSI_381_POS_RH_LITTLE_FINGER</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_ANSI_381_POS_LH_THUMB</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_ANSI_381_POS_LH_INDEX_FINGER</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_ANSI_381_POS_LH_MIDDLE_FINGER</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_ANSI_381_POS_LH_RING_FINGER</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_ANSI_381_POS_LH_LITTLE_FINGER</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_ANSI_381_POS_RH_FOUR_FINGERS</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_ANSI_381_POS_LH_FOUR_FINGERS</term>
	/// </item>
	/// </list>
	/// <para>
	/// To use <c>WinBioIdentify</c> synchronously, call the function with a session handle created by calling WinBioOpenSession. The
	/// function blocks until the operation completes or an error is encountered.
	/// </para>
	/// <para>
	/// To use <c>WinBioIdentify</c> asynchronously, call the function with a session handle created by calling WinBioAsyncOpenSession.
	/// The framework allocates a WINBIO_ASYNC_RESULT structure and uses it to return information about operation success or failure. If
	/// the operation is successful, the framework returns <c>WINBIO_IDENTITY</c> and <c>WINBIO_BIOMETRIC_SUBTYPE</c> information in a
	/// nested <c>Identify</c> structure. If the operation is unsuccessful, the framework returns <c>WINBIO_REJECT_DETAIL</c>
	/// information in the <c>Identify</c> structure. The <c>WINBIO_ASYNC_RESULT</c> structure is returned to the application callback
	/// or to the application message queue, depending on the value you set in the NotificationMethod parameter of the
	/// <c>WinBioAsyncOpenSession</c> function:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// If you choose to receive completion notices by using a callback, you must implement a PWINBIO_ASYNC_COMPLETION_CALLBACK function
	/// and set the NotificationMethod parameter to <c>WINBIO_ASYNC_NOTIFY_CALLBACK</c>.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If you choose to receive completion notices by using the application message queue, you must set the NotificationMethod
	/// parameter to <c>WINBIO_ASYNC_NOTIFY_MESSAGE</c>. The framework returns a WINBIO_ASYNC_RESULT pointer to the <c>LPARAM</c> field
	/// of the window message.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// To prevent memory leaks, you must call WinBioFree to release the WINBIO_ASYNC_RESULT structure after you have finished using it.
	/// </para>
	/// <para>
	/// <c>Windows 7:</c> You can perform this operation asynchronously by using the WinBioIdentifyWithCallback function. The function
	/// verifies the input arguments and returns immediately. If the input arguments are not valid, the function returns an error code.
	/// Otherwise, the framework starts the operation on another thread. When the asynchronous operation completes or encounters an
	/// error, the framework sends the results to the PWINBIO_IDENTIFY_CALLBACK function implemented by your application.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following function calls WinBioEnumEnrollments to enumerate the biometric sub-factors enrolled for a template, and it calls
	/// <c>WinBioIdentify</c> to retrieve a WINBIO_IDENTITY object that identifies the user. Link to the Winbio.lib static library and
	/// include the following header files:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>Windows.h</term>
	/// </item>
	/// <item>
	/// <term>Stdio.h</term>
	/// </item>
	/// <item>
	/// <term>Conio.h</term>
	/// </item>
	/// <item>
	/// <term>Winbio.h</term>
	/// </item>
	/// </list>
	/// <para>
	/// <code>HRESULT EnumEnrollments( ) { // Declare variables. HRESULT hr = S_OK; WINBIO_IDENTITY identity = {0}; WINBIO_SESSION_HANDLE sessionHandle = NULL; WINBIO_UNIT_ID unitId = 0; PWINBIO_BIOMETRIC_SUBTYPE subFactorArray = NULL; WINBIO_BIOMETRIC_SUBTYPE SubFactor = 0; SIZE_T subFactorCount = 0; WINBIO_REJECT_DETAIL rejectDetail = 0; WINBIO_BIOMETRIC_SUBTYPE subFactor = WINBIO_SUBTYPE_NO_INFORMATION; // Connect to the system pool. hr = WinBioOpenSession( WINBIO_TYPE_FINGERPRINT, // Service provider WINBIO_POOL_SYSTEM, // Pool type WINBIO_FLAG_DEFAULT, // Configuration and access NULL, // Array of biometric unit IDs 0, // Count of biometric unit IDs NULL, // Database ID &amp;sessionHandle // [out] Session handle ); if (FAILED(hr)) { wprintf_s(L"\n WinBioOpenSession failed. hr = 0x%x\n", hr); goto e_Exit; } // Locate the biometric sensor and retrieve a WINBIO_IDENTITY object. wprintf_s(L"\n Calling WinBioIdentify - Swipe finger on sensor...\n"); hr = WinBioIdentify( sessionHandle, // Session handle &amp;unitId, // Biometric unit ID &amp;identity, // User SID &amp;subFactor, // Finger sub factor &amp;rejectDetail // Rejection information ); wprintf_s(L"\n Swipe processed - Unit ID: %d\n", unitId); if (FAILED(hr)) { if (hr == WINBIO_E_UNKNOWN_ID) { wprintf_s(L"\n Unknown identity.\n"); } else if (hr == WINBIO_E_BAD_CAPTURE) { wprintf_s(L"\n Bad capture; reason: %d\n", rejectDetail); } else { wprintf_s(L"\n WinBioEnumBiometricUnits failed. hr = 0x%x\n", hr); } goto e_Exit; } // Retrieve the biometric sub-factors for the template. hr = WinBioEnumEnrollments( sessionHandle, // Session handle unitId, // Biometric unit ID &amp;identity, // Template ID &amp;subFactorArray, // Subfactors &amp;subFactorCount // Count of subfactors ); if (FAILED(hr)) { wprintf_s(L"\n WinBioEnumEnrollments failed. hr = 0x%x\n", hr); goto e_Exit; } // Print the sub-factor(s) to the console. wprintf_s(L"\n Enrollments for this user on Unit ID %d:", unitId); for (SIZE_T index = 0; index &lt; subFactorCount; ++index) { SubFactor = subFactorArray[index]; switch (SubFactor) { case WINBIO_ANSI_381_POS_RH_THUMB: wprintf_s(L"\n RH thumb\n"); break; case WINBIO_ANSI_381_POS_RH_INDEX_FINGER: wprintf_s(L"\n RH index finger\n"); break; case WINBIO_ANSI_381_POS_RH_MIDDLE_FINGER: wprintf_s(L"\n RH middle finger\n"); break; case WINBIO_ANSI_381_POS_RH_RING_FINGER: wprintf_s(L"\n RH ring finger\n"); break; case WINBIO_ANSI_381_POS_RH_LITTLE_FINGER: wprintf_s(L"\n RH little finger\n"); break; case WINBIO_ANSI_381_POS_LH_THUMB: wprintf_s(L"\n LH thumb\n"); break; case WINBIO_ANSI_381_POS_LH_INDEX_FINGER: wprintf_s(L"\n LH index finger\n"); break; case WINBIO_ANSI_381_POS_LH_MIDDLE_FINGER: wprintf_s(L"\n LH middle finger\n"); break; case WINBIO_ANSI_381_POS_LH_RING_FINGER: wprintf_s(L"\n LH ring finger\n"); break; case WINBIO_ANSI_381_POS_LH_LITTLE_FINGER: wprintf_s(L"\n LH little finger\n"); break; default: wprintf_s(L"\n The sub-factor is not correct\n"); break; } } e_Exit: if (subFactorArray!= NULL) { WinBioFree(subFactorArray); subFactorArray = NULL; } if (sessionHandle != NULL) { WinBioCloseSession(sessionHandle); sessionHandle = NULL; } wprintf_s(L"\n Press any key to exit..."); _getch(); return hr; }</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbio/nf-winbio-winbioidentify HRESULT WinBioIdentify( WINBIO_SESSION_HANDLE
	// SessionHandle, WINBIO_UNIT_ID *UnitId, WINBIO_IDENTITY *Identity, WINBIO_BIOMETRIC_SUBTYPE *SubFactor, WINBIO_REJECT_DETAIL
	// *RejectDetail );
	[DllImport(Lib_Winbio, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winbio.h", MSDNShortId = "NF:winbio.WinBioIdentify")]
	public static extern HRESULT WinBioIdentify(WINBIO_SESSION_HANDLE SessionHandle, out WINBIO_UNIT_ID UnitId,
		out WINBIO_IDENTITY Identity, out WINBIO_BIOMETRIC_SUBTYPE SubFactor, out WINBIO_REJECT_DETAIL RejectDetail);

	/// <summary>
	/// <para>
	/// Asynchronously captures a biometric sample and determines whether it matches an existing biometric template. The function
	/// returns immediately to the caller, performs capture and identification on a separate thread, and calls into an
	/// application-defined callback function to update operation status.
	/// </para>
	/// <para><c>Important</c>
	/// <para></para>
	/// We recommend that, beginning with Windows 8, you no longer use this function to start an asynchronous operation. Instead, do the following:
	/// </para>
	/// </summary>
	/// <param name="SessionHandle">A <c>WINBIO_SESSION_HANDLE</c> value that identifies an open biometric session.</param>
	/// <param name="IdentifyCallback">
	/// Address of a callback function that will be called by the <c>WinBioIdentifyWithCallback</c> function when identification
	/// succeeds or fails. You must create the callback.
	/// </param>
	/// <param name="IdentifyCallbackContext">
	/// Pointer to an application-defined data structure that is passed to the callback function in its IdentifyCallbackContext
	/// parameter. This structure can contain any data that the custom callback function is designed to handle.
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, it returns <c>S_OK</c>. If the function fails, it returns an <c>HRESULT</c> value that indicates the
	/// error. Possible values include, but are not limited to, those in the following table. For a list of common error codes, see
	/// Common HRESULT Values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_HANDLE</term>
	/// <term>The session handle is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_POINTER</term>
	/// <term>The SessionHandle and IdentifyCallback parameters cannot be NULL.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>The callback routine must have the following signature:</para>
	/// <para>
	/// <code>VOID CALLBACK IdentifyCallback( __in_opt PVOID IdentifyCallbackContext, __in HRESULT OperationStatus, __in WINBIO_UNIT_ID UnitId, __in WINBIO_IDENTITY *Identity, __in WINBIO_BIOMETRIC_SUBTYPE SubFactor, __in WINBIO_REJECT_DETAIL RejectDetail );</code>
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following code example calls <c>WinBioIdentifyWithCallback</c> to identify a user from a biometric scan.
	/// <c>WinBioIdentifyWithCallback</c> is an asynchronous function that configures the biometric subsystem to process biometric input
	/// on another thread. Output from the biometric subsystem is then sent to a custom callback function named IdentifyCallback. Link
	/// to the Winbio.lib static library and include the following header files:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>Windows.h</term>
	/// </item>
	/// <item>
	/// <term>Stdio.h</term>
	/// </item>
	/// <item>
	/// <term>Conio.h</term>
	/// </item>
	/// <item>
	/// <term>Winbio.h</term>
	/// </item>
	/// </list>
	/// <para>
	/// <code>HRESULT IdentifyWithCallback(BOOL bCancel) { // Declare variables. HRESULT hr = S_OK; WINBIO_SESSION_HANDLE sessionHandle = NULL; // Connect to the system pool. hr = WinBioOpenSession( WINBIO_TYPE_FINGERPRINT, // Service provider WINBIO_POOL_SYSTEM, // Pool type WINBIO_FLAG_DEFAULT, // Configuration and access NULL, // Array of biometric unit IDs 0, // Count of biometric unit IDs WINBIO_DB_DEFAULT, // Database ID &amp;sessionHandle // [out] Session handle ); if (FAILED(hr)) { wprintf_s(L"\n WinBioOpenSession failed. hr = 0x%x\n", hr); goto e_Exit; } // Call WinBioIdentifyWithCallback. The method is asynchronous // and returns immediately. wprintf_s(L"\n Calling WinBioIdentifyWithCallback"); wprintf_s(L"\n Swipe the sensor ...\n"); hr = WinBioIdentifyWithCallback( sessionHandle, // Open biometric session IdentifyCallback, // Callback function NULL // Optional context ); if (FAILED(hr)) { wprintf_s(L"\n WinBioIdentifyWithCallback failed. hr = 0x%x\n", hr); goto e_Exit; } // Cancel user identification if the bCancel flag is set. if (bCancel) { wprintf_s(L"\n Starting CANCEL timer...\n"); Sleep( 7000 ); wprintf_s(L"\n Calling WinBioCancel\n"); hr = WinBioCancel( sessionHandle ); if (FAILED(hr)) { wprintf_s(L"\n WinBioCancel failed. hr = 0x%x\n", hr); goto e_Exit; } } // Wait for the asynchronous identification process to complete // or be canceled. hr = WinBioWait( sessionHandle ); if (FAILED(hr)) { wprintf_s(L"\n WinBioWait failed. hr = 0x%x\n", hr); } e_Exit: if (sessionHandle != NULL) { wprintf_s(L"\n Closing the session.\n"); hr = WinBioCloseSession(sessionHandle); if (FAILED(hr)) { wprintf_s(L"\n WinBioCloseSession failed. hr = 0x%x\n", hr); } sessionHandle = NULL; } wprintf_s(L"\n Hit any key to exit..."); _getch(); return hr; } //------------------------------------------------------------------------ // The following function is the callback for WinBioIdentifyWithCallback. // The function filters the response from the biometric subsystem and // writes a result to the console window. // VOID CALLBACK IdentifyCallback( __in_opt PVOID IdentifyCallbackContext, __in HRESULT OperationStatus, __in WINBIO_UNIT_ID UnitId, __in WINBIO_IDENTITY *Identity, __in WINBIO_BIOMETRIC_SUBTYPE SubFactor, __in WINBIO_REJECT_DETAIL RejectDetail ) { UNREFERENCED_PARAMETER(IdentifyCallbackContext); UNREFERENCED_PARAMETER(Identity); wprintf_s(L"\n IdentifyCallback executing"); wprintf_s(L"\n Swipe processed for unit ID %d\n", UnitId); // The attempt to process the fingerprint failed. if (FAILED(OperationStatus)) { if (OperationStatus == WINBIO_E_UNKNOWN_ID) { wprintf_s(L"\n Unknown identity.\n"); } else if (OperationStatus == WINBIO_E_BAD_CAPTURE) { wprintf_s(L"\n Bad capture; reason: %d\n", RejectDetail); } else { wprintf_s(L"IdentifyCallback failed."); wprintf_s(L"OperationStatus = 0x%x\n", OperationStatus); } } // Processing succeeded and the finger swiped is written // to the console window. else { wprintf_s(L"\n The following finger was used:"); switch (SubFactor) { case WINBIO_SUBTYPE_NO_INFORMATION: wprintf_s(L"\n No information\n"); break; case WINBIO_ANSI_381_POS_RH_THUMB: wprintf_s(L"\n RH thumb\n"); break; case WINBIO_ANSI_381_POS_RH_INDEX_FINGER: wprintf_s(L"\n RH index finger\n"); break; case WINBIO_ANSI_381_POS_RH_MIDDLE_FINGER: wprintf_s(L"\n RH middle finger\n"); break; case WINBIO_ANSI_381_POS_RH_RING_FINGER: wprintf_s(L"\n RH ring finger\n"); break; case WINBIO_ANSI_381_POS_RH_LITTLE_FINGER: wprintf_s(L"\n RH little finger\n"); break; case WINBIO_ANSI_381_POS_LH_THUMB: wprintf_s(L"\n LH thumb\n"); break; case WINBIO_ANSI_381_POS_LH_INDEX_FINGER: wprintf_s(L"\n LH index finger\n"); break; case WINBIO_ANSI_381_POS_LH_MIDDLE_FINGER: wprintf_s(L"\n LH middle finger\n"); break; case WINBIO_ANSI_381_POS_LH_RING_FINGER: wprintf_s(L"\n LH ring finger\n"); break; case WINBIO_ANSI_381_POS_LH_LITTLE_FINGER: wprintf_s(L"\n LH little finger\n"); break; case WINBIO_SUBTYPE_ANY: wprintf_s(L"\n Any finger\n"); break; default: break; } } }</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbio/nf-winbio-winbioidentifywithcallback HRESULT
	// WinBioIdentifyWithCallback( WINBIO_SESSION_HANDLE SessionHandle, PWINBIO_IDENTIFY_CALLBACK IdentifyCallback, PVOID
	// IdentifyCallbackContext );
	[DllImport(Lib_Winbio, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winbio.h", MSDNShortId = "NF:winbio.WinBioIdentifyWithCallback")]
	public static extern HRESULT WinBioIdentifyWithCallback(WINBIO_SESSION_HANDLE SessionHandle, [In] PWINBIO_IDENTIFY_CALLBACK IdentifyCallback, [In, Optional] IntPtr IdentifyCallbackContext);

	/// <summary>Retrieves the ID number of a biometric unit selected interactively by a user.</summary>
	/// <param name="SessionHandle">
	/// A <c>WINBIO_SESSION_HANDLE</c> value that identifies an open biometric session. Open a synchronous session handle by calling
	/// WinBioOpenSession. Open an asynchronous session handle by calling WinBioAsyncOpenSession.
	/// </param>
	/// <param name="UnitId">A pointer to a <c>ULONG</c> value that specifies the biometric unit.</param>
	/// <returns>
	/// <para>
	/// If the function succeeds, it returns S_OK. If the function fails, it returns an <c>HRESULT</c> value that indicates the error.
	/// Possible values include, but are not limited to, those in the following table. For a list of common error codes, see Common
	/// HRESULT Values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_HANDLE</term>
	/// <term>The session handle is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_POINTER</term>
	/// <term>The pointer specified by the UnitId parameter cannot be NULL.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_E_ENROLLMENT_IN_PROGRESS</term>
	/// <term>
	/// The operation could not be completed because the biometric unit is currently being used for an enrollment transaction (system
	/// pool only).
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// You can use this function on systems with multiple sensors to determine which sensor is preferred for enrollment by the user. No
	/// identification information is returned by this function. It is provided only to indicate user sensor selection.
	/// </para>
	/// <para>
	/// Calls to this function using the system pool will block until the application acquires window focus and the user has provided a
	/// biometric sample. We recommend, therefore, that your application not call <c>WinBioLocateSensor</c> until it has acquired focus.
	/// The manner in which you acquire focus depends on the type of application you are writing. For example, if you are creating a GUI
	/// application you can implement a message handler that captures a WM_ACTIVATE, WM_SETFOCUS, or other appropriate message. If you
	/// are writing a CUI application, call <c>GetConsoleWindow</c> to retrieve a handle to the console window and pass that handle to
	/// the <c>SetForegroundWindow</c> function to force the console window into the foreground and assign it focus. If your application
	/// is running in a detached process and has no window or is a Windows service, use WinBioAcquireFocus and WinBioReleaseFocus to
	/// manually control focus.
	/// </para>
	/// <para>
	/// To use <c>WinBioLocateSensor</c> synchronously, call the function with a session handle created by calling WinBioOpenSession.
	/// The function blocks until the operation completes or an error is encountered.
	/// </para>
	/// <para>
	/// To use <c>WinBioLocateSensor</c> asynchronously, call the function with a session handle created by calling
	/// WinBioAsyncOpenSession. The framework allocates a WINBIO_ASYNC_RESULT structure and uses it to return information about
	/// operation success or failure. The <c>WINBIO_ASYNC_RESULT</c> structure is returned to the application callback or to the
	/// application message queue, depending on the value you set in the NotificationMethod parameter of the
	/// <c>WinBioAsyncOpenSession</c> function:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// If you choose to receive completion notices by using a callback, you must implement a PWINBIO_ASYNC_COMPLETION_CALLBACK function
	/// and set the NotificationMethod parameter to <c>WINBIO_ASYNC_NOTIFY_CALLBACK</c>.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If you choose to receive completion notices by using the application message queue, you must set the NotificationMethod
	/// parameter to <c>WINBIO_ASYNC_NOTIFY_MESSAGE</c>. The framework returns a WINBIO_ASYNC_RESULT pointer to the <c>LPARAM</c> field
	/// of the window message.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// To prevent memory leaks, you must call WinBioFree to release the WINBIO_ASYNC_RESULT structure after you have finished using it.
	/// </para>
	/// <para>
	/// <c>Windows 7:</c> You can perform this operation asynchronously by using the WinBioLocateSensorWithCallback function. The
	/// function verifies the input arguments and returns immediately. If the input arguments are not valid, the function returns an
	/// error code. Otherwise, the framework starts the operation on another thread. When the asynchronous operation completes or
	/// encounters an error, the framework sends the results to the PWINBIO_LOCATE_SENSOR_CALLBACK function implemented by your application.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following function calls <c>WinBioLocateSensor</c> to locate an installed biometric sensor. Link to the Winbio.lib static
	/// library and include the following header files:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>Windows.h</term>
	/// </item>
	/// <item>
	/// <term>Stdio.h</term>
	/// </item>
	/// <item>
	/// <term>Conio.h</term>
	/// </item>
	/// <item>
	/// <term>Winbio.h</term>
	/// </item>
	/// </list>
	/// <para>
	/// <code>HRESULT LocateSensor( ) { HRESULT hr = S_OK; WINBIO_SESSION_HANDLE sessionHandle = NULL; WINBIO_UNIT_ID unitId = 0; // Connect to the system pool. hr = WinBioOpenSession( WINBIO_TYPE_FINGERPRINT, // Service provider WINBIO_POOL_SYSTEM, // Pool type WINBIO_FLAG_DEFAULT, // Configuration and access NULL, // Array of biometric unit IDs 0, // Count of biometric unit IDs NULL, // Database ID &amp;sessionHandle // [out] Session handle ); if (FAILED(hr)) { wprintf_s(L"\n WinBioEnumBiometricUnits failed. hr = 0x%x\n", hr); goto e_Exit; } // Locate the sensor. wprintf_s(L"\n Tap the sensor once...\n"); hr = WinBioLocateSensor( sessionHandle, &amp;unitId); if (FAILED(hr)) { wprintf_s(L"\n WinBioLocateSensor failed. hr = 0x%x\n", hr); goto e_Exit; } wprintf_s(L"\n Sensor located successfully. "); wprintf_s(L"\n Unit ID = %d \n", unitId); e_Exit: if (sessionHandle != NULL) { WinBioCloseSession(sessionHandle); sessionHandle = NULL; } wprintf_s(L"\n Hit any key to exit..."); _getch(); return hr; }</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbio/nf-winbio-winbiolocatesensor HRESULT WinBioLocateSensor(
	// WINBIO_SESSION_HANDLE SessionHandle, WINBIO_UNIT_ID *UnitId );
	[DllImport(Lib_Winbio, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winbio.h", MSDNShortId = "NF:winbio.WinBioLocateSensor")]
	public static extern HRESULT WinBioLocateSensor(WINBIO_SESSION_HANDLE SessionHandle, out WINBIO_UNIT_ID UnitId);

	/// <summary>
	/// <para>
	/// Asynchronously retrieves the ID number of the biometric unit selected interactively by a user. The function returns immediately
	/// to the caller, processes on a separate thread, and reports the selected biometric unit by calling an application-defined
	/// callback function.
	/// </para>
	/// <para><c>Important</c>
	/// <para></para>
	/// We recommend that, beginning with Windows 8, you no longer use this function to start an asynchronous operation. Instead, do the following:
	/// </para>
	/// </summary>
	/// <param name="SessionHandle">A <c>WINBIO_SESSION_HANDLE</c> value that identifies an open biometric session.</param>
	/// <param name="LocateCallback">
	/// Address of a callback function that will be called by the <c>WinBioLocateSensorWithCallback</c> function when sensor location
	/// succeeds or fails. You must create the callback.
	/// </param>
	/// <param name="LocateCallbackContext">
	/// Address of an application-defined data structure that is passed to the callback function in its LocateCallbackContext parameter.
	/// This structure can contain any data that the custom callback function is designed to handle.
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, it returns <c>S_OK</c>. If the function fails, it returns an <c>HRESULT</c> value that indicates the
	/// error. Possible values include, but are not limited to, those in the following table. For a list of common error codes, see
	/// Common HRESULT Values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_HANDLE</term>
	/// <term>The session handle is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_POINTER</term>
	/// <term>The address specified by the LocateCallback parameter cannot be NULL.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// You can use this function on systems with multiple sensors to determine which sensor is preferred for enrollment by the user. No
	/// identification information is returned by this function. It is provided only to indicate user sensor selection.
	/// </para>
	/// <para>
	/// If the SessionHandle parameter refers to the system sensor pool, the callback function will not be called until the application
	/// acquires window focus and the user has provided a biometric sample. The manner in which you acquire focus depends on the type of
	/// application you are writing. For example, if you are creating a GUI application you can implement a message handler that
	/// captures a WM_ACTIVATE, WM_SETFOCUS, or other appropriate message. If you are writing a CUI application, call
	/// <c>GetConsoleWindow</c> to retrieve a handle to the console window and pass that handle to the <c>SetForegroundWindow</c>
	/// function to force the console window into the foreground and assign it focus. If your application is running in a detached
	/// process and has no window or is a Windows service, use WinBioAcquireFocus and WinBioReleaseFocus to manually control focus.
	/// </para>
	/// <para>The callback routine must have the following signature:</para>
	/// <para>
	/// <code> VOID CALLBACK LocateCallback( __in_opt PVOID LocateCallbackContext, __in HRESULT OperationStatus, __in WINBIO_UNIT_ID UnitId );</code>
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following function calls <c>WinBioLocateSensorWithCallback</c> to locate biometric sensor. The
	/// <c>WinBioLocateSensorWithCallback</c> is an asynchronous function that configures the biometric subsystem to locate the sensor
	/// on another thread. Output from the biometric subsystem is sent to a custom callback function named LocateSensorCallback. Link to
	/// the Winbio.lib static library and include the following header files:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>Windows.h</term>
	/// </item>
	/// <item>
	/// <term>Stdio.h</term>
	/// </item>
	/// <item>
	/// <term>Conio.h</term>
	/// </item>
	/// <item>
	/// <term>Winbio.h</term>
	/// </item>
	/// </list>
	/// <para>
	/// <code>HRESULT LocateSensorWithCallback(BOOL bCancel) { HRESULT hr = S_OK; WINBIO_SESSION_HANDLE sessionHandle = NULL; WINBIO_UNIT_ID unitId = 0; // Connect to the system pool. hr = WinBioOpenSession( WINBIO_TYPE_FINGERPRINT, // Service provider WINBIO_POOL_SYSTEM, // Pool type WINBIO_FLAG_DEFAULT, // Configuration and access NULL, // Array of biometric unit IDs 0, // Count of biometric unit IDs NULL, // Database ID &amp;sessionHandle // [out] Session handle ); if (FAILED(hr)) { wprintf_s(L"\n WinBioOpenSession failed. hr = 0x%x\n", hr); goto e_Exit; } wprintf_s(L"\n Calling WinBioLocateSensorWithCallback."); hr = WinBioLocateSensorWithCallback( sessionHandle, // Open biometric session LocateSensorCallback, // Callback function NULL // Optional context ); if (FAILED(hr)) { wprintf_s(L"\n WinBioLocateSensorWithCallback failed."); wprintf_s(L"hr = 0x%x\n", hr); goto e_Exit; } wprintf_s(L"\n Swipe the sensor ...\n"); // Cancel the identification if the bCancel flag is set. if (bCancel) { wprintf_s(L"\n Starting CANCEL timer...\n"); Sleep( 7000 ); wprintf_s(L"\n Calling WinBioCancel\n"); hr = WinBioCancel( sessionHandle ); if (FAILED(hr)) { wprintf_s(L"\n WinBioCancel failed. hr = 0x%x\n", hr); goto e_Exit; } } // Wait for the asynchronous identification process to complete // or be canceled. hr = WinBioWait( sessionHandle ); if (FAILED(hr)) { wprintf_s(L"\n WinBioWait failed. hr = 0x%x\n", hr); } e_Exit: if (sessionHandle != NULL) { wprintf_s(L"\n Closing the session.\n"); hr = WinBioCloseSession(sessionHandle); if (FAILED(hr)) { wprintf_s(L"\n WinBioCloseSession failed. hr = 0x%x\n", hr); } sessionHandle = NULL; } wprintf_s(L"\n Hit any key to exit..."); _getch(); return hr; } //------------------------------------------------------------------------ // The following function is the callback for // WinBioLocateSensorWithCallback. The function filters the response // from the biometric subsystem and writes a result to the console window. // VOID CALLBACK LocateSensorCallback( __in_opt PVOID LocateCallbackContext, __in HRESULT OperationStatus, __in WINBIO_UNIT_ID UnitId ) { UNREFERENCED_PARAMETER(LocateCallbackContext); wprintf_s(L"\n LocateSensorCallback executing."); // A sensor could not be located. if (FAILED(OperationStatus)) { wprintf_s(L"\n LocateSensorCallback failed."); wprintf_s(L"OperationStatus = 0x%x\n", OperationStatus); } // A sensor was located. else { wprintf_s(L"\n Selected unit ID: %d\n", UnitId); } }</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbio/nf-winbio-winbiolocatesensorwithcallback HRESULT
	// WinBioLocateSensorWithCallback( WINBIO_SESSION_HANDLE SessionHandle, PWINBIO_LOCATE_SENSOR_CALLBACK LocateCallback, PVOID
	// LocateCallbackContext );
	[DllImport(Lib_Winbio, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winbio.h", MSDNShortId = "NF:winbio.WinBioLocateSensorWithCallback")]
	public static extern HRESULT WinBioLocateSensorWithCallback(WINBIO_SESSION_HANDLE SessionHandle, [In] PWINBIO_LOCATE_SENSOR_CALLBACK LocateCallback, [In, Optional] IntPtr LocateCallbackContext);

	/// <summary>
	/// Locks a biometric unit for exclusive use by a single session. Starting with Windows 10, build 1607, this function is available
	/// to use with a mobile image.
	/// </summary>
	/// <param name="SessionHandle">
	/// A <c>WINBIO_SESSION_HANDLE</c> value that identifies an open biometric session. Open a synchronous session handle by calling
	/// WinBioOpenSession. Open an asynchronous session handle by calling WinBioAsyncOpenSession.
	/// </param>
	/// <param name="UnitId">A <c>WINBIO_UNIT_ID</c> value that specifies the biometric unit to be locked.</param>
	/// <returns>
	/// <para>
	/// If the function succeeds, it returns S_OK. If the function fails, it returns an <c>HRESULT</c> value that indicates the error.
	/// Possible values include, but are not limited to, those in the following table. For a list of common error codes, see Common
	/// HRESULT Values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_HANDLE</term>
	/// <term>The session handle is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>The UnitId parameter cannot contain zero.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_E_ENROLLMENT_IN_PROGRESS</term>
	/// <term>
	/// The operation could not be completed because the specified biometric unit is currently being used for an enrollment transaction
	/// (system pool only).
	/// </term>
	/// </item>
	/// <item>
	/// <term>WINBIO_E_LOCK_VIOLATION</term>
	/// <term>The biometric unit cannot be locked because the specified session already has another unit locked.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If the specified biometric unit is locked by another session, <c>WinBioLockUnit</c> will block the calling thread until the
	/// session that owns the biometric unit releases its lock.
	/// </para>
	/// <para>Call the WinBioUnlockUnit function to cancel any pending lock request and release all locks held by the session.</para>
	/// <para>
	/// To use <c>WinBioLockUnit</c> synchronously, call the function with a session handle created by calling WinBioOpenSession. The
	/// function blocks until the operation completes or an error is encountered.
	/// </para>
	/// <para>
	/// To use <c>WinBioLockUnit</c> asynchronously, call the function with a session handle created by calling WinBioAsyncOpenSession.
	/// The framework allocates a WINBIO_ASYNC_RESULT structure and uses it to return information about operation success or failure.
	/// The <c>WINBIO_ASYNC_RESULT</c> structure is returned to the application callback or to the application message queue, depending
	/// on the value you set in the NotificationMethod parameter of the <c>WinBioAsyncOpenSession</c> function:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// If you choose to receive completion notices by using a callback, you must implement a PWINBIO_ASYNC_COMPLETION_CALLBACK function
	/// and set the NotificationMethod parameter to <c>WINBIO_ASYNC_NOTIFY_CALLBACK</c>.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If you choose to receive completion notices by using the application message queue, you must set the NotificationMethod
	/// parameter to <c>WINBIO_ASYNC_NOTIFY_MESSAGE</c>. The framework returns a WINBIO_ASYNC_RESULT pointer to the <c>LPARAM</c> field
	/// of the window message.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// To prevent memory leaks, you must call WinBioFree to release the WINBIO_ASYNC_RESULT structure after you have finished using it.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following function calls <c>WinBioLockUnit</c> to lock the biometric unit before calling WinBioIdentify to identify the
	/// user. Link to the Winbio.lib static library and include the following header files:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>Windows.h</term>
	/// </item>
	/// <item>
	/// <term>Stdio.h</term>
	/// </item>
	/// <item>
	/// <term>Conio.h</term>
	/// </item>
	/// <item>
	/// <term>Winbio.h</term>
	/// </item>
	/// </list>
	/// <para>
	/// <code>HRESULT LockUnlock( ) { // Declare variables. HRESULT hr = S_OK; WINBIO_IDENTITY identity = {0}; WINBIO_SESSION_HANDLE sessionHandle = NULL; WINBIO_UNIT_ID unitId = 0; WINBIO_REJECT_DETAIL rejectDetail = 0; WINBIO_BIOMETRIC_SUBTYPE subFactor = WINBIO_SUBTYPE_NO_INFORMATION; BOOL lockAcquired = FALSE; // Connect to the system pool. hr = WinBioOpenSession( WINBIO_TYPE_FINGERPRINT, // Service provider WINBIO_POOL_SYSTEM, // Pool type WINBIO_FLAG_DEFAULT, // Configuration and access NULL, // Array of biometric unit IDs 0, // Count of biometric unit IDs NULL, // Database ID &amp;sessionHandle // [out] Session handle ); if (FAILED(hr)) { wprintf_s(L"\n WinBioEnumBiometricUnits failed. hr = 0x%x\n", hr); goto e_Exit; } // Lock the session. The Biometric unit ID (1) is hard coded in // this example. hr = WinBioLockUnit( sessionHandle, 1 ); if (FAILED(hr)) { wprintf_s(L"\n WinBioLockUnit failed. hr = 0x%x\n", hr); goto e_Exit; } wprintf_s(L"\n Biometric unit #1 is locked.\n"); lockAcquired = TRUE; // Locate the biometric sensor and retrieve a WINBIO_IDENTITY object. // You must swipe your finger on the sensor. wprintf_s(L"\n Calling WinBioIdentify - Swipe finger on sensor...\n"); hr = WinBioIdentify( sessionHandle, &amp;unitId, &amp;identity, &amp;subFactor, &amp;rejectDetail ); wprintf_s(L"\n Swipe processed - Unit ID: %d\n", unitId); if (FAILED(hr)) { wprintf_s(L"\n WinBioIdentify failed. hr = 0x%x\n", hr); goto e_Exit; } e_Exit: // Unlock the biometric unit if it is locked. if (lockAcquired == TRUE) { hr = WinBioUnlockUnit( sessionHandle, 1 ); if (FAILED(hr)) { wprintf_s(L"\n WinBioUnlockUnit failed. hr = 0x%x\n", hr); } wprintf_s(L"\n Biometric unit #1 is unlocked.\n"); lockAcquired = FALSE; } if (sessionHandle != NULL) { WinBioCloseSession(sessionHandle); sessionHandle = NULL; } wprintf_s(L"\n Press any key to exit..."); _getch(); return hr; }</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbio/nf-winbio-winbiolockunit HRESULT WinBioLockUnit( WINBIO_SESSION_HANDLE
	// SessionHandle, WINBIO_UNIT_ID UnitId );
	[DllImport(Lib_Winbio, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winbio.h", MSDNShortId = "NF:winbio.WinBioLockUnit")]
	public static extern HRESULT WinBioLockUnit(WINBIO_SESSION_HANDLE SessionHandle, WINBIO_UNIT_ID UnitId);

	/// <summary>
	/// The <c>WinBioLogonIdentifiedUser</c> function causes a fast user switch to the account associated with the last successful
	/// identification operation performed by the biometric session.
	/// </summary>
	/// <param name="SessionHandle">
	/// A <c>WINBIO_SESSION_HANDLE</c> value that identifies the biometric session that has recently performed a successful
	/// identification operation. Open the session handle by calling WinBioOpenSession.
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, it returns <c>S_OK</c>. If the function fails, it returns an <c>HRESULT</c> value that indicates the
	/// error. Possible values include, but are not limited to, those in the following table. For a list of common error codes, see
	/// Common HRESULT Values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_ACCESSDENIED</term>
	/// <term>The caller does not have permission to switch users or the biometric session is out of date.</term>
	/// </item>
	/// <item>
	/// <term>E_HANDLE</term>
	/// <term>The session handle is not valid.</term>
	/// </item>
	/// <item>
	/// <term>S_FALSE</term>
	/// <term>The user identified by the SessionHandle parameter is the same as the current user.</term>
	/// </item>
	/// <item>
	/// <term>SEC_E_LOGON_DENIED</term>
	/// <term>The user could not be logged on.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_E_CRED_PROV_DISABLED</term>
	/// <term>Current administrative policy prohibits use of the credential provider.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_E_FAST_USER_SWITCH_DISABLED</term>
	/// <term>Fast user switching is not enabled.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_E_SAS_ENABLED</term>
	/// <term>Fast user switching cannot be performed because secure logon (CTRL+ALT+DELETE) is currently enabled.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>WinBioLogonIdentifiedUser</c> function is typically called by applications that support fast user switching when they
	/// identify a user other than the one who is currently logged on.
	/// </para>
	/// <para>
	/// The fast user switch attempt can leave a logon event in the security log, but the identity is not automatically stored when the
	/// credential manager terminates.
	/// </para>
	/// <para>
	/// The biometric session specified by the SessionHandle parameter controls the target account for the fast user switch event. If
	/// that handle has been used recently to perform an identification operation, the resulting identity will be logged in after the
	/// fast user switch.
	/// </para>
	/// <para>
	/// For security reasons, the Windows Biometric Framework requires that the identification operation and the call to
	/// <c>WinBioLogonIdentifiedUser</c> happen within a short period of time. After that period, the identification is considered to be
	/// out of date and the call to <c>WinBioLogonIdentifiedUser</c> will fail. The default timeout interval is five seconds, but an
	/// administrator can make it as large as 60 seconds.
	/// </para>
	/// <para>
	/// Calling this function when the target user is the same as the current user returns <c>S_FALSE</c> and the fast user switch
	/// attempt is ignored.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following function calls WinBioLogonIdentifiedUser to log on a previously identified user. For this function to work
	/// correctly, secure logon must not be enabled. Link to the Winbio.lib static library and include the following header files:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>Windows.h</term>
	/// </item>
	/// <item>
	/// <term>Stdio.h</term>
	/// </item>
	/// <item>
	/// <term>Conio.h</term>
	/// </item>
	/// <item>
	/// <term>Winbio.h</term>
	/// </item>
	/// </list>
	/// <para>
	/// <code>HRESULT LogonIdentifiedUser() { // Declare variables. HRESULT hr; WINBIO_SESSION_HANDLE sessionHandle = NULL; WINBIO_UNIT_ID UnitId; WINBIO_IDENTITY Identity; WINBIO_BIOMETRIC_SUBTYPE SubFactor; WINBIO_REJECT_DETAIL RejectDetail; BOOL bContinue = TRUE; // Connect to the system pool. hr = WinBioOpenSession( WINBIO_TYPE_FINGERPRINT, // Service provider WINBIO_POOL_SYSTEM, // Pool type WINBIO_FLAG_DEFAULT, // Configuration and access NULL, // Array of biometric unit IDs 0, // Count of biometric unit IDs WINBIO_DB_DEFAULT, // Database ID &amp;sessionHandle // [out] Session handle ); if (FAILED(hr)) { wprintf_s(L"\n WinBioOpenSession failed. hr = 0x%x\n", hr); goto e_Exit; } // Locate the biometric sensor and retrieve a WINBIO_IDENTITY object. // You must swipe your finger on the sensor. wprintf_s(L"\n Calling WinBioIdentify - Swipe finger on sensor...\n"); while(bContinue) { hr = WinBioIdentify( sessionHandle, // Session handle &amp;UnitId, // Biometric unit ID &amp;Identity, // User SID or GUID &amp;SubFactor, // Finger sub factor &amp;RejectDetail // rejection information ); switch(hr) { case S_OK: bContinue = FALSE; break; default: wprintf_s(L"\n WinBioIdentify failed. hr = 0x%x\n", hr); break; } } if (SUCCEEDED(hr)) { // Switch to the target after receiving a good identity. hr = WinBioLogonIdentifiedUser(sessionHandle); switch(hr) { case S_FALSE: printf("\n Target is the logged on user. No action taken.\n"); break; case S_OK: printf("\n Fast user switch initiated.\n"); break; default: wprintf_s(L"\n WinBioLogonIdentifiedUser failed. hr = 0x%x\n", hr); break; } } e_Exit: if (sessionHandle != NULL) { WinBioCloseSession(sessionHandle); sessionHandle = NULL; } wprintf_s(L"\n Press any key to exit..."); _getch(); return hr; }</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbio/nf-winbio-winbiologonidentifieduser HRESULT WinBioLogonIdentifiedUser(
	// WINBIO_SESSION_HANDLE SessionHandle );
	[DllImport(Lib_Winbio, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winbio.h", MSDNShortId = "NF:winbio.WinBioLogonIdentifiedUser")]
	public static extern HRESULT WinBioLogonIdentifiedUser(WINBIO_SESSION_HANDLE SessionHandle);

	/// <summary>
	/// Turns on the face-recognition or iris-monitoring mechanism for the specified biometric unit. Starting with Windows 10, build
	/// 1607, this function is available to use with a mobile image.
	/// </summary>
	/// <param name="SessionHandle">
	/// An asynchronous handle for the biometric session that you obtained by calling the WinBioAsyncOpenSession function with the
	/// PoolType parameter set to <c>WINBIO_POOL_SYSTEM</c>.
	/// </param>
	/// <param name="UnitId">
	/// The identifier of the biometric unit for which you want to turn on the face-recognition or iris-monitoring mechanism.
	/// </param>
	/// <returns>
	/// <para>
	/// If the function parameters are acceptable, it returns <c>S_OK</c>. If the function parameters are not acceptable, it returns an
	/// <c>HRESULT</c> value that indicates the error. Possible values include, but are not limited to, those in the following table.
	/// For a list of common error codes, see Common HRESULT Values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_HANDLE</term>
	/// <term>The session handle is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>The UnitId parameter cannot equal zero.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_E_INCORRECT_SESSION_TYPE</term>
	/// <term>The session handle does not correspond to an asynchronous biometric session.</term>
	/// </item>
	/// </list>
	/// <para>
	/// The actual success or failure of the operation itself is returned to the your notification function in a WINBIO_ASYNC_RESULT structure.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>A single biometric session can have only one active presence monitor at any point in time.</para>
	/// <para>
	/// After you successfully call <c>WinBioMonitorPresence</c>, your notification function receives notifications in the form of a
	/// WINBIO_ASYNC_RESULT structure with an <c>Operation</c> member equal to <c>WINBIO_OPERATION_MONITOR_PRESENCE</c>. You should then
	/// examine the <c>Parameters.MonitorPresence</c> member of the <c>WINBIO_ASYNC_RESULT</c> structure for more information.
	/// </para>
	/// <para>
	/// To stop receiving notifications, call either WinBioCancel or WinBioCloseSession with the original asynchronous handle value.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbio/nf-winbio-winbiomonitorpresence HRESULT WinBioMonitorPresence(
	// WINBIO_SESSION_HANDLE SessionHandle, WINBIO_UNIT_ID UnitId );
	[DllImport(Lib_Winbio, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winbio.h", MSDNShortId = "NF:winbio.WinBioMonitorPresence")]
	public static extern HRESULT WinBioMonitorPresence(WINBIO_SESSION_HANDLE SessionHandle, WINBIO_UNIT_ID UnitId);

	/// <summary>Connects to a biometric service provider and one or more biometric units.</summary>
	/// <param name="Factor">
	/// A bitmask of WINBIO_BIOMETRIC_TYPE flags that specifies the biometric unit types to be enumerated. Only
	/// <c>WINBIO_TYPE_FINGERPRINT</c> is currently supported.
	/// </param>
	/// <param name="PoolType">
	/// <para>
	/// A <c>ULONG</c> value that specifies the type of the biometric units that will be used in the session. This can be one of the
	/// following values:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>WINBIO_POOL_SYSTEM</term>
	/// <term>The session connects to a shared collection of biometric units managed by the service provider.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_POOL_PRIVATE</term>
	/// <term>The session connects to a collection of biometric units that are managed by the caller.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="Flags">
	/// <para>
	/// A <c>ULONG</c> value that specifies biometric unit configuration and access characteristics for the new session. Configuration
	/// flags specify the general configuration of units in the session. Access flags specify how the application will use the biometric
	/// units. You must specify one configuration flag but you can combine that flag with any access flag.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>WINBIO_FLAG_DEFAULT</term>
	/// <term>
	/// Group: configuration The biometric units operate in the manner specified during installation. You must use this value when the
	///        PoolType parameter is WINBIO_POOL_SYSTEM.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FLAG_BASIC</term>
	/// <term>
	/// Group: configuration The biometric units operate only as basic capture devices. All processing, matching, and storage operations
	///        is performed by software plug-ins.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FLAG_ADVANCED</term>
	/// <term>Group: configuration The biometric units use internal processing and storage capabilities.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FLAG_RAW</term>
	/// <term>Group: access The client application captures raw biometric data using WinBioCaptureSample.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FLAG_MAINTENANCE</term>
	/// <term>Group: access The client performs vendor-defined control operations on a biometric unit by calling WinBioControlUnitPrivileged.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="UnitArray">
	/// Pointer to an array of biometric unit identifiers to be included in the session. You can call WinBioEnumBiometricUnits to
	/// enumerate the biometric units. Set this value to <c>NULL</c> if the PoolType parameter is <c>WINBIO_POOL_SYSTEM</c>.
	/// </param>
	/// <param name="UnitCount">
	/// A value that specifies the number of elements in the array pointed to by the UnitArray parameter. Set this value to zero if the
	/// PoolType parameter is <c>WINBIO_POOL_SYSTEM</c>.
	/// </param>
	/// <param name="DatabaseId">
	/// <para>
	/// A value that specifies the database(s) to be used by the session. If the PoolType parameter is <c>WINBIO_POOL_PRIVATE</c>, you
	/// must specify the GUID of an installed database. If the PoolType parameter is not <c>WINBIO_POOL_PRIVATE</c>, you can specify one
	/// of the following common values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>WINBIO_DB_DEFAULT</term>
	/// <term>
	/// Each biometric unit in the sensor pool uses the default database specified in the default biometric unit configuration. You must
	/// specify this value if the PoolType parameter is WINBIO_POOL_SYSTEM. You cannot use this value if the PoolType parameter is WINBIO_POOL_PRIVATE
	/// </term>
	/// </item>
	/// <item>
	/// <term>WINBIO_DB_BOOTSTRAP</term>
	/// <term>
	/// You can specify this value to be used for scenarios prior to starting Windows. Typically, the database is part of the sensor
	/// chip or is part of the BIOS and can only be used for template enrollment and deletion.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WINBIO_DB_ONCHIP</term>
	/// <term>The database is on the sensor chip and is available for enrollment and matching.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="SessionHandle">Pointer to the new session handle. If the function does not succeed, the handle is set to zero.</param>
	/// <returns>
	/// <para>
	/// If the function succeeds, it returns S_OK. If the function fails, it returns an <c>HRESULT</c> value that indicates the error.
	/// Possible values include, but are not limited to, those in the following table. For a list of common error codes, see Common
	/// HRESULT Values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One or more arguments have incorrect values or are incompatible with other arguments.</term>
	/// </item>
	/// <item>
	/// <term>E_POINTER</term>
	/// <term>The session handle pointer in the SessionHandle parameter cannot be NULL.</term>
	/// </item>
	/// <item>
	/// <term>E_ACCESSDENIED</term>
	/// <term>
	/// The Flags parameter contains the WINBIO_FLAG_RAW or the WINBIO_FLAG_MAINTENANCE flag and the caller has not been granted either
	/// access permission.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WINBIO_E_INVALID_UNIT</term>
	/// <term>One or more of the biometric unit numbers specified in the UnitArray parameter is not valid.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_E_NOT_ACTIVE_CONSOLE</term>
	/// <term>The client application is running on a remote desktop client and is attempting to open a system pool session.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_E_SENSOR_UNAVAILABLE</term>
	/// <term>The PoolType parameter is set to WINBIO_POOL_PRIVATE and one or more of the requested sensors in that pool is not available.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_E_DISABLED</term>
	/// <term>Current administrative policy prohibits use of the Windows Biometric Framework API.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbio/nf-winbio-winbioopensession HRESULT WinBioOpenSession(
	// WINBIO_BIOMETRIC_TYPE Factor, WINBIO_POOL_TYPE PoolType, WINBIO_SESSION_FLAGS Flags, WINBIO_UNIT_ID *UnitArray, SIZE_T UnitCount,
	// GUID *DatabaseId, WINBIO_SESSION_HANDLE *SessionHandle );
	[DllImport(Lib_Winbio, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winbio.h", MSDNShortId = "NF:winbio.WinBioOpenSession")]
	public static extern HRESULT WinBioOpenSession(WINBIO_BIOMETRIC_TYPE Factor, WINBIO_POOL_TYPE PoolType, WINBIO_SESSION_FLAGS Flags,
		[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] WINBIO_UNIT_ID[]? UnitArray, [In, Optional] SIZE_T UnitCount,
		in Guid DatabaseId, out WINBIO_SESSION_HANDLE SessionHandle);

	/// <summary>Connects to a biometric service provider and one or more biometric units.</summary>
	/// <param name="Factor">
	/// A bitmask of WINBIO_BIOMETRIC_TYPE flags that specifies the biometric unit types to be enumerated. Only
	/// <c>WINBIO_TYPE_FINGERPRINT</c> is currently supported.
	/// </param>
	/// <param name="PoolType">
	/// <para>
	/// A <c>ULONG</c> value that specifies the type of the biometric units that will be used in the session. This can be one of the
	/// following values:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>WINBIO_POOL_SYSTEM</term>
	/// <term>The session connects to a shared collection of biometric units managed by the service provider.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_POOL_PRIVATE</term>
	/// <term>The session connects to a collection of biometric units that are managed by the caller.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="Flags">
	/// <para>
	/// A <c>ULONG</c> value that specifies biometric unit configuration and access characteristics for the new session. Configuration
	/// flags specify the general configuration of units in the session. Access flags specify how the application will use the biometric
	/// units. You must specify one configuration flag but you can combine that flag with any access flag.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>WINBIO_FLAG_DEFAULT</term>
	/// <term>
	/// Group: configuration The biometric units operate in the manner specified during installation. You must use this value when the
	///        PoolType parameter is WINBIO_POOL_SYSTEM.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FLAG_BASIC</term>
	/// <term>
	/// Group: configuration The biometric units operate only as basic capture devices. All processing, matching, and storage operations
	///        is performed by software plug-ins.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FLAG_ADVANCED</term>
	/// <term>Group: configuration The biometric units use internal processing and storage capabilities.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FLAG_RAW</term>
	/// <term>Group: access The client application captures raw biometric data using WinBioCaptureSample.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FLAG_MAINTENANCE</term>
	/// <term>Group: access The client performs vendor-defined control operations on a biometric unit by calling WinBioControlUnitPrivileged.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="UnitArray">
	/// Pointer to an array of biometric unit identifiers to be included in the session. You can call WinBioEnumBiometricUnits to
	/// enumerate the biometric units. Set this value to <c>NULL</c> if the PoolType parameter is <c>WINBIO_POOL_SYSTEM</c>.
	/// </param>
	/// <param name="UnitCount">
	/// A value that specifies the number of elements in the array pointed to by the UnitArray parameter. Set this value to zero if the
	/// PoolType parameter is <c>WINBIO_POOL_SYSTEM</c>.
	/// </param>
	/// <param name="DatabaseId">
	/// <para>
	/// A value that specifies the database(s) to be used by the session. If the PoolType parameter is <c>WINBIO_POOL_PRIVATE</c>, you
	/// must specify the GUID of an installed database. If the PoolType parameter is not <c>WINBIO_POOL_PRIVATE</c>, you can specify one
	/// of the following common values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>WINBIO_DB_DEFAULT</term>
	/// <term>
	/// Each biometric unit in the sensor pool uses the default database specified in the default biometric unit configuration. You must
	/// specify this value if the PoolType parameter is WINBIO_POOL_SYSTEM. You cannot use this value if the PoolType parameter is WINBIO_POOL_PRIVATE
	/// </term>
	/// </item>
	/// <item>
	/// <term>WINBIO_DB_BOOTSTRAP</term>
	/// <term>
	/// You can specify this value to be used for scenarios prior to starting Windows. Typically, the database is part of the sensor
	/// chip or is part of the BIOS and can only be used for template enrollment and deletion.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WINBIO_DB_ONCHIP</term>
	/// <term>The database is on the sensor chip and is available for enrollment and matching.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="SessionHandle">Pointer to the new session handle. If the function does not succeed, the handle is set to zero.</param>
	/// <returns>
	/// <para>
	/// If the function succeeds, it returns S_OK. If the function fails, it returns an <c>HRESULT</c> value that indicates the error.
	/// Possible values include, but are not limited to, those in the following table. For a list of common error codes, see Common
	/// HRESULT Values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One or more arguments have incorrect values or are incompatible with other arguments.</term>
	/// </item>
	/// <item>
	/// <term>E_POINTER</term>
	/// <term>The session handle pointer in the SessionHandle parameter cannot be NULL.</term>
	/// </item>
	/// <item>
	/// <term>E_ACCESSDENIED</term>
	/// <term>
	/// The Flags parameter contains the WINBIO_FLAG_RAW or the WINBIO_FLAG_MAINTENANCE flag and the caller has not been granted either
	/// access permission.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WINBIO_E_INVALID_UNIT</term>
	/// <term>One or more of the biometric unit numbers specified in the UnitArray parameter is not valid.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_E_NOT_ACTIVE_CONSOLE</term>
	/// <term>The client application is running on a remote desktop client and is attempting to open a system pool session.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_E_SENSOR_UNAVAILABLE</term>
	/// <term>The PoolType parameter is set to WINBIO_POOL_PRIVATE and one or more of the requested sensors in that pool is not available.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_E_DISABLED</term>
	/// <term>Current administrative policy prohibits use of the Windows Biometric Framework API.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbio/nf-winbio-winbioopensession HRESULT WinBioOpenSession(
	// WINBIO_BIOMETRIC_TYPE Factor, WINBIO_POOL_TYPE PoolType, WINBIO_SESSION_FLAGS Flags, WINBIO_UNIT_ID *UnitArray, SIZE_T UnitCount,
	// GUID *DatabaseId, WINBIO_SESSION_HANDLE *SessionHandle );
	[DllImport(Lib_Winbio, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winbio.h", MSDNShortId = "NF:winbio.WinBioOpenSession")]
	public static extern HRESULT WinBioOpenSession(WINBIO_BIOMETRIC_TYPE Factor, WINBIO_POOL_TYPE PoolType, WINBIO_SESSION_FLAGS Flags,
		[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] WINBIO_UNIT_ID[]? UnitArray, [In, Optional] SIZE_T UnitCount,
		[In, Optional] GuidPtr DatabaseId, out WINBIO_SESSION_HANDLE SessionHandle);

	/// <summary>
	/// The <c>WinBioRegisterEventMonitor</c> function Registers a callback function to receive event notifications from the service
	/// provider associated with an open session.
	/// </summary>
	/// <param name="SessionHandle">
	/// A <c>WINBIO_SESSION_HANDLE</c> value that identifies the open biometric session. Open the session handle by calling WinBioOpenSession.
	/// </param>
	/// <param name="EventMask">
	/// <para>
	/// A value that specifies the types of events to monitor. Only the fingerprint provider is currently supported. You must specify
	/// one of the following flags.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term><c>WINBIO_EVENT_FP_UNCLAIMED</c></term>
	/// </item>
	/// </list>
	/// <para>
	/// The sensor detected a finger swipe that was not requested by the application, or the requesting application does not have window
	/// focus. The Windows Biometric Framework calls into your callback function to indicate that a finger swipe has occurred but does
	/// not try to identify the fingerprint.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term><c>WINBIO_EVENT_FP_UNCLAIMED_IDENTIFY</c></term>
	/// </item>
	/// </list>
	/// <para>
	/// The sensor detected a finger swipe that was not requested by the application, or the requesting application does not have window
	/// focus. The Windows Biometric Framework attempts to identify the fingerprint and passes the result of that process to your
	/// callback function.
	/// </para>
	/// </param>
	/// <param name="EventCallback">
	/// Address of a callback function that receives the event notifications sent by the Windows Biometric Framework. You must define
	/// this function.
	/// </param>
	/// <param name="EventCallbackContext">
	/// An optional application-defined value that is returned in the pvContext parameter of the callback function. This value can
	/// contain any data that the custom callback function is designed to handle.
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, it returns S_OK. If the function fails, it returns an <c>HRESULT</c> value that indicates the error.
	/// Possible values include, but are not limited to, those in the following table. For a list of common error codes, see Common
	/// HRESULT Values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_HANDLE</term>
	/// <term>The session handle is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_POINTER</term>
	/// <term>The address of the callback function specified by the EventCallback parameter cannot be NULL.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>
	/// The EventMask parameter cannot be zero and you cannot specify both WINBIO_EVENT_FP_UNCLAIMED and
	/// WINBIO_EVENT_FP_UNCLAIMED_IDENTIFY at the same time.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WINBIO_E_EVENT_MONITOR_ACTIVE</term>
	/// <term>An active event monitor has already been registered.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_E_INVALID_OPERATION</term>
	/// <term>The service provider does not support event notification.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>This function is only valid for sessions connected to a System sensor pool.</para>
	/// <para>
	/// Event callbacks are delivered to the client application serially. Therefore, subsequent event notifications will not be
	/// delivered until the client returns from the current callback. Events that occur while a callback is still executing may be
	/// discarded by the system. To avoid losing events, you should not perform any time-consuming work in your callback routine.
	/// </para>
	/// <para>
	/// The client application should be prepared to receive events as soon as <c>WinBioRegisterEventMonitor</c> is called. The
	/// application must call WinBioFree to release the structure returned in the Event argument of the callback. Failure to do so will
	/// result in a memory leak in the calling process.
	/// </para>
	/// <para>
	/// After an event monitor has been started, the session with which the monitor is associated will not be able to process other
	/// Windows Biometric Framework API calls until the event monitor has been stopped. If your application needs to perform other API
	/// calls while still receiving event monitor notifications, you should open two sessions - one for the event monitor and another
	/// for other operations.
	/// </para>
	/// <para>Call WinBioUnregisterEventMonitor to stop sending event notifications to your callback function.</para>
	/// <para>
	/// If an application registers a <c>WinBio</c> event monitor and leaves that monitor active during a sleep/wake cycle, systems that
	/// implement biometric pre-boot authentication (PBA)/single sign-on features may not always work. The problem is that the PBA
	/// biometric call is intercepted by the event monitor before the system's biometric credential provider has a chance to perform its
	/// first WinBioIdentify operation. Apps that use the <c>WinBio</c> event monitoring feature should unregister their monitors before
	/// the system sleeps, and re-register them after system wakeup. For more information on handling events during power state changes,
	/// see About Power Management.
	/// </para>
	/// <para>The callback routine must have the following signature:</para>
	/// <para>
	/// <code> VOID CALLBACK EventCallback( __in_opt PVOID EventCallbackContext, __in HRESULT OperationStatus, __in PWINBIO_EVENT Event );</code>
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following function registers an event monitor by calling the <c>WinBioRegisterEventMonitor</c> function and passing the
	/// address of a callback routine. The callback, also included, receives event notifications from the Windows biometric framework.
	/// Link to the Winbio.lib static library and include the following header files:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>Windows.h</term>
	/// </item>
	/// <item>
	/// <term>Stdio.h</term>
	/// </item>
	/// <item>
	/// <term>Conio.h</term>
	/// </item>
	/// <item>
	/// <term>Winbio.h</term>
	/// </item>
	/// </list>
	/// <para>
	/// <code>HRESULT RegisterSystemEventMonitor(BOOL bCancel) { HRESULT hr = S_OK; WINBIO_SESSION_HANDLE sessionHandle = NULL; WINBIO_UNIT_ID unitId = 0; // Connect to the system pool. hr = WinBioOpenSession( WINBIO_TYPE_FINGERPRINT, // Service provider WINBIO_POOL_SYSTEM, // Pool type WINBIO_FLAG_DEFAULT, // Configuration and access NULL, // Array of biometric unit IDs 0, // Count of biometric unit IDs NULL, // Database ID &amp;sessionHandle // [out] Session handle ); if (FAILED(hr)) { wprintf_s(L"\n WinBioOpenSession failed. hr = 0x%x\n", hr); goto e_Exit; } // Call the WinBioRegisterEventMonitor function. wprintf_s(L"\n Calling WinBioRegisterEventMonitor.\n"); hr = WinBioRegisterEventMonitor( sessionHandle, // Open session handle WINBIO_EVENT_FP_UNCLAIMED, // Events to monitor EventMonitorCallback, // Callback function NULL // Optional context. ); if (FAILED(hr)) { wprintf_s(L"\n WinBioRegisterEventMonitor failed."); wprintf_s(L"hr = 0x%x\n", hr); goto e_Exit; } wprintf_s(L"\n Waiting for an event.\n"); // Cancel the identification if the bCancel flag is set. if (bCancel) { wprintf_s(L"\n Starting CANCEL timer...\n"); Sleep( 7000 ); wprintf_s(L"\n Calling WinBioCancel\n"); hr = WinBioCancel( sessionHandle ); if (FAILED(hr)) { wprintf_s(L"\n WinBioCancel failed. hr = 0x%x\n", hr); goto e_Exit; } } // Wait for an event to happen. //wprintf_s(L"\n Swipe the sensor to receive an event notice "); //wprintf_s(L"\n or press any key to stop waiting...\n"); wprintf_s(L"\n Swipe the sensor one or more times "); wprintf_s(L"to generate events."); wprintf_s(L"\n When done, press a key to exit...\n"); _getch(); // Unregister the event monitor. wprintf_s(L"\n Calling WinBioUnregisterEventMonitor\n"); hr = WinBioUnregisterEventMonitor( sessionHandle); if (FAILED(hr)) { wprintf_s(L"\n WinBioUnregisterEventMonitor failed."); wprintf_s(L"hr = 0x%x\n", hr); } e_Exit: if (sessionHandle != NULL) { wprintf_s(L"\n Closing the session.\n"); hr = WinBioCloseSession(sessionHandle); if (FAILED(hr)) { wprintf_s(L"\n WinBioCloseSession failed. hr = 0x%x\n", hr); } sessionHandle = NULL; } wprintf_s(L"\n Press any key to exit..."); _getch(); return hr; } //------------------------------------------------------------------------ // The following function is the callback for WinBioRegisterEventMonitor. // The function filters any event notice from the biometric subsystem and // writes a result to the console window. // VOID CALLBACK EventMonitorCallback( __in_opt PVOID EventCallbackContext, __in HRESULT OperationStatus, __in PWINBIO_EVENT Event ) { UNREFERENCED_PARAMETER(EventCallbackContext); wprintf_s(L"\n EventMonitorCallback executing."); // Failure. if (FAILED(OperationStatus)) { wprintf_s(L"\n EventMonitorCallback failed. "); wprintf_s(L" OperationStatus = 0x%x\n", OperationStatus); goto e_Exit; } // An event notice was received. if (Event != NULL) { wprintf_s(L"\n MonitorEvent: "); switch (Event-&gt;Type) { case WINBIO_EVENT_FP_UNCLAIMED: wprintf_s(L"WINBIO_EVENT_FP_UNCLAIMED"); wprintf_s(L"\n Unit ID: %d", Event-&gt;Parameters.Unclaimed.UnitId); wprintf_s(L"\n Reject detail: %d\n", Event-&gt;Parameters.Unclaimed.RejectDetail); break; case WINBIO_EVENT_FP_UNCLAIMED_IDENTIFY: wprintf_s(L"WINBIO_EVENT_FP_UNCLAIMED_IDENTIFY"); wprintf_s(L"\n Unit ID: %d", Event-&gt;Parameters.UnclaimedIdentify.UnitId); wprintf_s(L"\n Reject detail: %d\n", Event-&gt;Parameters.UnclaimedIdentify.RejectDetail); break; case WINBIO_EVENT_ERROR: wprintf_s(L"WINBIO_EVENT_ERROR\n"); break; default: wprintf_s(L"(0x%08x - Invalid type)\n", Event-&gt;Type); break; } } e_Exit: if (Event != NULL) { //wprintf_s(L"\n Press any key to continue...\n"); WinBioFree(Event); Event = NULL; } }</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbio/nf-winbio-winbioregistereventmonitor HRESULT
	// WinBioRegisterEventMonitor( WINBIO_SESSION_HANDLE SessionHandle, WINBIO_EVENT_TYPE EventMask, PWINBIO_EVENT_CALLBACK
	// EventCallback, PVOID EventCallbackContext );
	[DllImport(Lib_Winbio, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winbio.h", MSDNShortId = "NF:winbio.WinBioRegisterEventMonitor")]
	public static extern HRESULT WinBioRegisterEventMonitor(WINBIO_SESSION_HANDLE SessionHandle, WINBIO_EVENT_TYPE EventMask, PWINBIO_EVENT_CALLBACK EventCallback, [In, Optional] IntPtr EventCallbackContext);

	/// <summary>Releases window focus.</summary>
	/// <returns>
	/// <para>
	/// If the function succeeds, it returns <c>S_OK</c>. If the function fails, it returns an <c>HRESULT</c> value that indicates the
	/// error. Possible values include, but are not limited to, those in the following table. For a list of common error codes, see
	/// Common HRESULT Values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_ACCESSDENIED</term>
	/// <term>The calling process must be running under the Local System account.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>The Windows Biometric Framework uses window focus to arbitrate among multiple sessions connected to the system pool.</para>
	/// <para>
	/// The manner in which you acquire focus depends on the type of application you are writing. For example, if you are creating a GUI
	/// application you can implement a message handler that captures a WM_ACTIVATE, WM_SETFOCUS, or other appropriate message. If you
	/// are writing a CUI application, call <c>GetConsoleWindow</c> to retrieve a handle to the console window and pass that handle to
	/// the <c>SetForegroundWindow</c> function to force the console window into the foreground and assign it focus. If your application
	/// is running in a detached process or is a Windows service and has no window, use WinBioAcquireFocus and <c>WinBioReleaseFocus</c>
	/// to manually control focus.
	/// </para>
	/// <para>The following list summarizes the major points to consider before calling WinBioAcquireFocus and <c>WinBioReleaseFocus</c>.</para>
	/// <list type="bullet">
	/// <item>
	/// <term>The calling process must be running under the Local System account.</term>
	/// </item>
	/// <item>
	/// <term>
	/// A process that directly displays a user interface should not call WinBioAcquireFocus. See the preceding discussion to determine
	/// how to acquire focus for GUI and CUI applications.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// Only a service or a detached process that does not directly display a user interface during biometric API calls should call this function.
	/// </term>
	/// </item>
	/// </list>
	/// <para>If you do not acquire focus when calling the following functions, they will behave in unexpected ways:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>WinBioEnrollBegin</term>
	/// </item>
	/// <item>
	/// <term>WinBioEnrollCapture</term>
	/// </item>
	/// <item>
	/// <term>WinBioEnrollCaptureWithCallback</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbio/nf-winbio-winbioreleasefocus HRESULT WinBioReleaseFocus();
	[DllImport(Lib_Winbio, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winbio.h", MSDNShortId = "NF:winbio.WinBioReleaseFocus")]
	public static extern HRESULT WinBioReleaseFocus();

	/// <summary>
	/// Removes all credentials from the store. Starting with Windows 10, build 1607, this function is available to use with a mobile image.
	/// </summary>
	/// <returns>
	/// If the function succeeds, it returns S_OK. If the function fails, it returns an <c>HRESULT</c> value that indicates the error.
	/// For a list of common error codes, see Common HRESULT Values.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbio/nf-winbio-winbioremoveallcredentials HRESULT WinBioRemoveAllCredentials();
	[DllImport(Lib_Winbio, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winbio.h", MSDNShortId = "NF:winbio.WinBioRemoveAllCredentials")]
	public static extern HRESULT WinBioRemoveAllCredentials();

	/// <summary>
	/// Removes all user credentials for the current domain from the store. Starting with Windows 10, build 1607, this function is
	/// available to use with a mobile image.
	/// </summary>
	/// <returns>
	/// If the function succeeds, it returns S_OK. If the function fails, it returns an <c>HRESULT</c> value that indicates the error.
	/// For a list of common error codes, see Common HRESULT Values.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbio/nf-winbio-winbioremovealldomaincredentials HRESULT WinBioRemoveAllDomainCredentials();
	[DllImport(Lib_Winbio, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winbio.h", MSDNShortId = "NF:winbio.WinBioRemoveAllDomainCredentials")]
	public static extern HRESULT WinBioRemoveAllDomainCredentials();

	/// <summary>
	/// Deletes a biometric logon credential for a specified user. Starting with Windows 10, build 1607, this function is available to
	/// use with a mobile image.
	/// </summary>
	/// <param name="Identity">
	/// A WINBIO_IDENTITY structure that contains the SID of the user account for which the logon credential will be removed.
	/// </param>
	/// <param name="Type">
	/// <para>A WINBIO_CREDENTIAL_TYPE value that specifies the credential type. This can be one of the following values:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>WINBIO_CREDENTIAL_PASSWORD</term>
	/// <term>The password-based credential will be deleted.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_CREDENTIAL_ALL</term>
	/// <term>All logon credentials for the user will be deleted.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, it returns S_OK. If the function fails, it returns an <c>HRESULT</c> value that indicates the error.
	/// Possible values include, but are not limited to, those in the following table. For a list of common error codes, see Common
	/// HRESULT Values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_ACCESSDENIED</term>
	/// <term>The caller does not have permission to delete the credential.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_E_CRED_PROV_NO_CREDENTIAL</term>
	/// <term>The specified identity does not exist or does not have any related records in the credential store.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Users who do not have elevated privileges can delete only their own credentials. Elevated users can remove credentials for any
	/// user account. Deleting a credential does not affect any biometric enrollments for that user. Deleting a biometric credential
	/// does not prevent the user from logging on by using a password. Only medium and higher integrity processes can delete
	/// credentials. If a lower integrity process attempts to delete credentials, the function returns E_ACCESSDENIED.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following function shows how to call <c>WinBioRemoveCredential</c> to remove credentials for a specific user. The helper
	/// function GetCurrentUserIdentity is also included. Link to the Winbio.lib static library and include the following header files:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>Windows.h</term>
	/// </item>
	/// <item>
	/// <term>Stdio.h</term>
	/// </item>
	/// <item>
	/// <term>Conio.h</term>
	/// </item>
	/// <item>
	/// <term>Winbio.h</term>
	/// </item>
	/// </list>
	/// <para>
	/// <code>HRESULT RemoveCredential() { HRESULT hr = S_OK; WINBIO_IDENTITY identity; // Find the identity of the user. wprintf_s(L"\n Finding user identity.\n"); hr = GetCurrentUserIdentity( &amp;identity ); if (FAILED(hr)) { wprintf(L"\n User identity not found. hr = 0x%x\n", hr); goto e_Exit; } // Remove the user credentials. hr = WinBioRemoveCredential(identity, WINBIO_CREDENTIAL_PASSWORD); if (FAILED(hr)) { wprintf(L"\n WinBioRemoveCredential failed. hr = 0x%x\n", hr); goto e_Exit; } wprintf_s(L"\n User credentials successfully removed.\n"); e_Exit: wprintf_s(L"\n Press any key to exit..."); _getch(); return hr; } //------------------------------------------------------------------------ // The following function retrieves the identity of the current user. // This is a helper function and is not part of the Windows Biometric // Framework API. // HRESULT GetCurrentUserIdentity(__inout PWINBIO_IDENTITY Identity) { // Declare variables. HRESULT hr = S_OK; HANDLE tokenHandle = NULL; DWORD bytesReturned = 0; struct{ TOKEN_USER tokenUser; BYTE buffer[SECURITY_MAX_SID_SIZE]; } tokenInfoBuffer; // Zero the input identity and specify the type. ZeroMemory( Identity, sizeof(WINBIO_IDENTITY)); Identity-&gt;Type = WINBIO_ID_TYPE_NULL; // Open the access token associated with the // current process if (!OpenProcessToken( GetCurrentProcess(), // Process handle TOKEN_READ, // Read access only &amp;tokenHandle)) // Access token handle { DWORD win32Status = GetLastError(); wprintf_s(L"Cannot open token handle: %d\n", win32Status); hr = HRESULT_FROM_WIN32(win32Status); goto e_Exit; } // Zero the tokenInfoBuffer structure. ZeroMemory(&amp;tokenInfoBuffer, sizeof(tokenInfoBuffer)); // Retrieve information about the access token. In this case, // retrieve a SID. if (!GetTokenInformation( tokenHandle, // Access token handle TokenUser, // User for the token &amp;tokenInfoBuffer.tokenUser, // Buffer to fill sizeof(tokenInfoBuffer), // Size of the buffer &amp;bytesReturned)) // Size needed { DWORD win32Status = GetLastError(); wprintf_s(L"Cannot query token information: %d\n", win32Status); hr = HRESULT_FROM_WIN32(win32Status); goto e_Exit; } // Copy the SID from the tokenInfoBuffer structure to the // WINBIO_IDENTITY structure. CopySid( SECURITY_MAX_SID_SIZE, Identity-&gt;Value.AccountSid.Data, tokenInfoBuffer.tokenUser.User.Sid ); // Specify the size of the SID and assign WINBIO_ID_TYPE_SID // to the type member of the WINBIO_IDENTITY structure. Identity-&gt;Value.AccountSid.Size = GetLengthSid(tokenInfoBuffer.tokenUser.User.Sid); Identity-&gt;Type = WINBIO_ID_TYPE_SID; e_Exit: if (tokenHandle != NULL) { CloseHandle(tokenHandle); } return hr; }</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbio/nf-winbio-winbioremovecredential HRESULT WinBioRemoveCredential(
	// WINBIO_IDENTITY Identity, WINBIO_CREDENTIAL_TYPE Type );
	[DllImport(Lib_Winbio, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winbio.h", MSDNShortId = "NF:winbio.WinBioRemoveCredential")]
	public static extern HRESULT WinBioRemoveCredential(WINBIO_IDENTITY Identity, WINBIO_CREDENTIAL_TYPE Type);

	/// <summary>
	/// Saves a biometric logon credential for the current user. Starting with Windows 10, build 1607, this function is available to use
	/// with a mobile image.
	/// </summary>
	/// <param name="Type">A WINBIO_CREDENTIAL_TYPE value that specifies the credential type. Currently, this can be WINBIO_CREDENTIAL_PASSWORD.</param>
	/// <param name="Credential">
	/// A pointer to a variable length array of bytes that contains the credential. The format depends on the Type and Format parameters.
	/// </param>
	/// <param name="CredentialSize">Size, in bytes, of the value specified by the Credential parameter.</param>
	/// <param name="Format">
	/// <para>
	/// A WINBIO_CREDENTIAL_FORMAT enumeration value that specifies the format of the credential. If the Type parameter is
	/// <c>WINBIO_CREDENTIAL_PASSWORD</c>, this can be one of the following:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>WINBIO_PASSWORD_GENERIC</term>
	/// <term>The credential is a plaintext NULL-terminated Unicode string.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_PASSWORD_PACKED</term>
	/// <term>
	/// The credential was wrapped by using the CredProtect function and packed by using the CredPackAuthenticationBuffer function. This
	/// is recommended.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WINBIO_PASSWORD_PROTECTED</term>
	/// <term>The password credential was wrapped with CredProtect.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, it returns S_OK. If the function fails, it returns an <c>HRESULT</c> value that indicates the error.
	/// Possible values include, but are not limited to, those in the following table. For a list of common error codes, see Common
	/// HRESULT Values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_ACCESSDENIED</term>
	/// <term>The caller does not have permission to set the credential.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_E_UNKNOWN_ID</term>
	/// <term>The user has not enrolled a biometric sample.</term>
	/// </item>
	/// <item>
	/// <term>SEC_E_LOGON_DENIED</term>
	/// <term>The credential was not valid for the current user.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_E_CRED_PROV_DISABLED</term>
	/// <term>Current administrative policy prohibits use of the credential provider.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If the current user has an existing logon credential of the specified type, <c>WinBioSetCredential</c> will overwrite it. The
	/// function verifies both the user credential and interactive logon privileges and fails if verification fails. An event related to
	/// the logon attempt is placed in the event log. Credentials for domain accounts can be saved only if permitted by Group Policy.
	/// </para>
	/// <para>
	/// You should call SecureZeroMemory to securely zero the credential if you pass <c>WINBIO_PASSWORD_PACKED</c> in the Format parameter.
	/// </para>
	/// <para>
	/// Only medium and higher integrity processes can set credentials. If a lower integrity process attempts to set credentials, the
	/// function returns E_ACCESSDENIED.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following function retrieves the identity and credentials of the current user and then calls <c>WinBioSetCredential</c> to
	/// set the credentials. Two helper functions, GetCredentials and GetCurrentUserIdentity, are also included. Link to the Winbio.lib
	/// static library and include the following header files:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>Windows.h</term>
	/// </item>
	/// <item>
	/// <term>Wincred.h</term>
	/// </item>
	/// <item>
	/// <term>Stdio.h</term>
	/// </item>
	/// <item>
	/// <term>Conio.h</term>
	/// </item>
	/// <item>
	/// <term>Winbio.h</term>
	/// </item>
	/// </list>
	/// <para>
	/// <code>HRESULT SetCredential() { // Declare variables. HRESULT hr = S_OK; PVOID pvAuthBlob = NULL; ULONG cbAuthBlob = 0; WINBIO_IDENTITY identity; PSID pSid = NULL; // Find the identity of the user. wprintf_s(L"\n Finding user identity.\n"); hr = GetCurrentUserIdentity( &amp;identity ); if (FAILED(hr)) { wprintf_s(L"\n User identity not found. hr = 0x%x\n", hr); return hr; } // Set a pointer to the security descriptor for the user. pSid = identity.Value.AccountSid.Data; // Retrieve a byte array that contains credential information. hr = GetCredentials(pSid, &amp;pvAuthBlob, &amp;cbAuthBlob); if (FAILED(hr)) { wprintf_s(L"\n GetCredentials failed. hr = 0x%x\n", hr); goto e_Exit; } // Set the credentials. hr = WinBioSetCredential( WINBIO_CREDENTIAL_PASSWORD, // Type of credential. (PUCHAR)pvAuthBlob, // Credentials byte array cbAuthBlob, // Size of credentials WINBIO_PASSWORD_PACKED); // Credentials format if (FAILED(hr)) { wprintf_s(L"\n WinBioSetCredential failed. hr = 0x%x\n", hr); goto e_Exit; } wprintf_s(L"\n Credentials successfully set.\n"); e_Exit: // Delete the authentication byte array. if (NULL != pvAuthBlob) { SecureZeroMemory(pvAuthBlob, cbAuthBlob); CoTaskMemFree(pvAuthBlob); pvAuthBlob = NULL; } wprintf_s(L"\n Press any key to exit..."); _getch(); return hr; } //------------------------------------------------------------------------ // The following function displays a dialog box to prompt a user // for credentials. // HRESULT GetCredentials(PSID pSid, PVOID* ppvAuthBlob, ULONG* pcbAuthBlob) { HRESULT hr = S_OK; DWORD dwResult; WCHAR szUsername[MAX_PATH] = {0}; DWORD cchUsername = ARRAYSIZE(szUsername); WCHAR szPassword[MAX_PATH] = {0}; WCHAR szDomain[MAX_PATH] = {0}; DWORD cchDomain = ARRAYSIZE(szDomain); WCHAR szDomainAndUser[MAX_PATH] = {0}; DWORD cchDomainAndUser = ARRAYSIZE(szDomainAndUser); PVOID pvInAuthBlob = NULL; ULONG cbInAuthBlob = 0; PVOID pvAuthBlob = NULL; ULONG cbAuthBlob = 0; CREDUI_INFOW ui; ULONG ulAuthPackage = 0; BOOL fSave = FALSE; static const WCHAR WINBIO_CREDPROV_TEST_PASSWORD_PROMPT_MESSAGE[] = L"Enter your current password to enable biometric logon."; static const WCHAR WINBIO_CREDPROV_TEST_PASSWORD_PROMPT_CAPTION[] = L"Biometric Log On Enrollment"; if (NULL == pSid || NULL == ppvAuthBlob || NULL == pcbAuthBlob) { return E_INVALIDARG; } // Retrieve the user name and domain name. SID_NAME_USE SidUse; DWORD cchTmpUsername = cchUsername; DWORD cchTmpDomain = cchDomain; if (!LookupAccountSidW( NULL, // Local computer pSid, // Security identifier for user szUsername, // User name &amp;cchTmpUsername, // Size of user name szDomain, // Domain name &amp;cchTmpDomain, // Size of domain name &amp;SidUse)) // Account type { dwResult = GetLastError(); hr = HRESULT_FROM_WIN32(dwResult); wprintf_s(L"\n LookupAccountSidLocalW failed: hr = 0x%x\n", hr); return hr; } // Combine the domain and user names. swprintf_s( szDomainAndUser, cchDomainAndUser, L"%s\\%s", szDomain, szUsername); // Call CredPackAuthenticationBufferW once to determine the size, // in bytes, of the authentication buffer. if (!CredPackAuthenticationBufferW( 0, // Reserved szDomainAndUser, // Domain\User name szPassword, // User Password NULL, // Packed credentials &amp;cbInAuthBlob) // Size, in bytes, of credentials &amp;&amp; GetLastError() != ERROR_INSUFFICIENT_BUFFER) { dwResult = GetLastError(); hr = HRESULT_FROM_WIN32(dwResult); wprintf_s(L"\n CredPackAuthenticationBufferW (1) failed: "); wprintf_s(L"hr = 0x%x\n", hr); } // Allocate memory for the input buffer. pvInAuthBlob = CoTaskMemAlloc(cbInAuthBlob); if (!pvInAuthBlob) { cbInAuthBlob = 0; wprintf_s(L"\n CoTaskMemAlloc() Out of memory %d\n"); return HRESULT_FROM_WIN32(ERROR_OUTOFMEMORY); } // Call CredPackAuthenticationBufferW again to retrieve the // authentication buffer. if (!CredPackAuthenticationBufferW( 0, szDomainAndUser, szPassword, (PBYTE)pvInAuthBlob, &amp;cbInAuthBlob)) { dwResult = GetLastError(); hr = HRESULT_FROM_WIN32(dwResult); wprintf_s(L"\n CredPackAuthenticationBufferW (2) failed: "); wprintf_s(L"hr = 0x%x\n", hr); goto e_Exit; } // Display a dialog box to request credentials. ui.cbSize = sizeof(ui); ui.hwndParent = GetConsoleWindow(); ui.pszMessageText = WINBIO_CREDPROV_TEST_PASSWORD_PROMPT_MESSAGE; ui.pszCaptionText = WINBIO_CREDPROV_TEST_PASSWORD_PROMPT_CAPTION; ui.hbmBanner = NULL; dwResult = CredUIPromptForWindowsCredentialsW( &amp;ui, // Customizing information 0, // Error code to display &amp;ulAuthPackage, // Authorization package pvInAuthBlob, // Credential byte array cbInAuthBlob, // Size of credential input buffer &amp;pvAuthBlob, // Output credential byte array &amp;cbAuthBlob, // Size of credential byte array &amp;fSave, // Select the save check box. CREDUIWIN_IN_CRED_ONLY | CREDUIWIN_ENUMERATE_CURRENT_USER ); if (dwResult != NO_ERROR) { hr = HRESULT_FROM_WIN32(dwResult); wprintf_s(L"\n CredUIPromptForWindowsCredentials failed: "); wprintf_s(L"0x%08x\n", dwResult); goto e_Exit; } *ppvAuthBlob = pvAuthBlob; *pcbAuthBlob = cbAuthBlob; e_Exit: // Delete the input authentication byte array. if (pvInAuthBlob) { SecureZeroMemory(pvInAuthBlob, cbInAuthBlob); CoTaskMemFree(pvInAuthBlob); pvInAuthBlob = NULL; }; return hr; } //------------------------------------------------------------------------ // The following function retrieves the identity of the current user. // This is a helper function and is not part of the Windows Biometric // Framework API. // HRESULT GetCurrentUserIdentity(__inout PWINBIO_IDENTITY Identity) { // Declare variables. HRESULT hr = S_OK; HANDLE tokenHandle = NULL; DWORD bytesReturned = 0; struct{ TOKEN_USER tokenUser; BYTE buffer[SECURITY_MAX_SID_SIZE]; } tokenInfoBuffer; // Zero the input identity and specify the type. ZeroMemory( Identity, sizeof(WINBIO_IDENTITY)); Identity-&gt;Type = WINBIO_ID_TYPE_NULL; // Open the access token associated with the // current process if (!OpenProcessToken( GetCurrentProcess(), // Process handle TOKEN_READ, // Read access only &amp;tokenHandle)) // Access token handle { DWORD win32Status = GetLastError(); wprintf_s(L"Cannot open token handle: %d\n", win32Status); hr = HRESULT_FROM_WIN32(win32Status); goto e_Exit; } // Zero the tokenInfoBuffer structure. ZeroMemory(&amp;tokenInfoBuffer, sizeof(tokenInfoBuffer)); // Retrieve information about the access token. In this case, // retrieve a SID. if (!GetTokenInformation( tokenHandle, // Access token handle TokenUser, // User for the token &amp;tokenInfoBuffer.tokenUser, // Buffer to fill sizeof(tokenInfoBuffer), // Size of the buffer &amp;bytesReturned)) // Size needed { DWORD win32Status = GetLastError(); wprintf_s(L"Cannot query token information: %d\n", win32Status); hr = HRESULT_FROM_WIN32(win32Status); goto e_Exit; } // Copy the SID from the tokenInfoBuffer structure to the // WINBIO_IDENTITY structure. CopySid( SECURITY_MAX_SID_SIZE, Identity-&gt;Value.AccountSid.Data, tokenInfoBuffer.tokenUser.User.Sid ); // Specify the size of the SID and assign WINBIO_ID_TYPE_SID // to the type member of the WINBIO_IDENTITY structure. Identity-&gt;Value.AccountSid.Size = GetLengthSid(tokenInfoBuffer.tokenUser.User.Sid); Identity-&gt;Type = WINBIO_ID_TYPE_SID; e_Exit: if (tokenHandle != NULL) { CloseHandle(tokenHandle); } return hr; }</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbio/nf-winbio-winbiosetcredential HRESULT WinBioSetCredential(
	// WINBIO_CREDENTIAL_TYPE Type, PUCHAR Credential, SIZE_T CredentialSize, WINBIO_CREDENTIAL_FORMAT Format );
	[DllImport(Lib_Winbio, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winbio.h", MSDNShortId = "NF:winbio.WinBioSetCredential")]
	public static extern HRESULT WinBioSetCredential(WINBIO_CREDENTIAL_TYPE Type, [In] IntPtr Credential, SIZE_T CredentialSize, WINBIO_CREDENTIAL_FORMAT Format);

	/// <summary>
	/// Sets the value of a standard property associated with a biometric session, unit, template, or account. Starting with Windows 10,
	/// build 1607, this function is available to use with a mobile image.
	/// </summary>
	/// <param name="SessionHandle">
	/// A <c>WINBIO_SESSION_HANDLE</c> value that identifies an open biometric session. Open a synchronous session handle by calling
	/// WinBioOpenSession. Open an asynchronous session handle by calling WinBioAsyncOpenSession.
	/// </param>
	/// <param name="PropertyType">
	/// A <c>WINBIO_PROPERTY_TYPE</c> value that specifies the type of the property that you want to set. Currently this must be <c>WINBIO_PROPERTY_TYPE_ACCOUNT</c>.
	/// </param>
	/// <param name="PropertyId">
	/// A <c>WINBIO_PROPERTY_ID</c> value that specifies the property to set. Currently this must be
	/// <c>WINBIO_PROPERTY_ANTI_SPOOF_POLICY</c>. All other properties are read-only.
	/// </param>
	/// <param name="UnitId">
	/// A <c>WINBIO_UNIT_ID</c> value that identifies the biometric unit. For the <c>WINBIO_PROPERTY_ANTI_SPOOF_POLICY</c> property,
	/// this value must be 0.
	/// </param>
	/// <param name="Identity">Address of a WINBIO_IDENTITY structure that specifies the account for which you want to set the property.</param>
	/// <param name="SubFactor">Reserved. This must be <c>WINBIO_SUBTYPE_NO_INFORMATION</c>.</param>
	/// <param name="PropertyBuffer">
	/// A pointer to a structure that specifies the new value for the property. This value cannot be NULL. For setting the
	/// <c>WINBIO_PROPERTY_ANTI_SPOOF_POLICY</c> property, the structure must be a WINBIO_ANTI_SPOOF_POLICY structure.
	/// </param>
	/// <param name="PropertyBufferSize">
	/// The size, in bytes, of the structure to which the PropertyBuffer parameter points. This value cannot be 0.
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, it returns <c>S_OK</c>. If the function fails, it returns an <c>HRESULT</c> value that indicates the
	/// error. Possible values include, but are not limited to, those in the following table. For a list of common error codes, see
	/// Common HRESULT Values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_HANDLE</term>
	/// <term>The session handle specified by the SessionHandle parameter is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_POINTER</term>
	/// <term>The Identity and PropertyBuffer parameters cannot be NULL.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>The PropertyType, PropertyId, or PropertyBufferSize parameter cannot be 0.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_E_INVALID_PROPERTY_TYPE</term>
	/// <term>The value of the PropertyType argument is incorrect.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_E_INVALID_PROPERTY_ID</term>
	/// <term>The value of the PropertyId argument is incorrect.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_E_LOCK_VIOLATION</term>
	/// <term>The caller attempted to set a property that resides inside of a locked region.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_E_UNSUPPORTED_PROPERTY</term>
	/// <term>The object does not support the specified property.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_E_ENROLLMENT_IN_PROGRESS</term>
	/// <term>
	/// The operation could not be completed because the specified biometric unit is currently being used for an enrollment transaction
	/// (system pool only).
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// To use <c>WinBioSetProperty</c> synchronously, call the function with a session handle created by calling WinBioOpenSession. The
	/// function blocks until the operation completes or an error is encountered. To prevent memory leaks, you must call WinBioFree to
	/// release the memory pointed to by the PropertyBuffer parameter when you are finished using the data contained in the buffer.
	/// </para>
	/// <para>
	/// To use <c>WinBioSetProperty</c> asynchronously, call the function with a session handle created by calling
	/// WinBioAsyncOpenSession. The framework allocates a WINBIO_ASYNC_RESULT structure and uses it to return information about
	/// operation success or failure. The <c>WINBIO_ASYNC_RESULT</c> structure is returned to the application callback or to the
	/// application message queue, depending on the value you set in the NotificationMethod parameter of the
	/// <c>WinBioAsyncOpenSession</c> function:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// If you choose to receive completion notices by using a callback, you must implement a PWINBIO_ASYNC_COMPLETION_CALLBACK function
	/// and set the NotificationMethod parameter to <c>WINBIO_ASYNC_NOTIFY_CALLBACK</c>.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If you choose to receive completion notices by using the application message queue, you must set the NotificationMethod
	/// parameter to <c>WINBIO_ASYNC_NOTIFY_MESSAGE</c>. The framework returns a WINBIO_ASYNC_RESULT pointer to the <c>LPARAM</c> field
	/// of the window message.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// To prevent memory leaks, you must call WinBioFree to release the WINBIO_ASYNC_RESULT structure after you have finished using it.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbio/nf-winbio-winbiosetproperty HRESULT WinBioSetProperty(
	// WINBIO_SESSION_HANDLE SessionHandle, WINBIO_PROPERTY_TYPE PropertyType, WINBIO_PROPERTY_ID PropertyId, WINBIO_UNIT_ID UnitId,
	// WINBIO_IDENTITY *Identity, WINBIO_BIOMETRIC_SUBTYPE SubFactor, PVOID PropertyBuffer, SIZE_T PropertyBufferSize );
	[DllImport(Lib_Winbio, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winbio.h", MSDNShortId = "NF:winbio.WinBioSetProperty")]
	public static extern HRESULT WinBioSetProperty(WINBIO_SESSION_HANDLE SessionHandle, WINBIO_PROPERTY_TYPE PropertyType, WINBIO_PROPERTY_ID PropertyId,
		[Optional] WINBIO_UNIT_ID UnitId, in WINBIO_IDENTITY Identity, [Optional] WINBIO_BIOMETRIC_SUBTYPE SubFactor, [In] IntPtr PropertyBuffer, SIZE_T PropertyBufferSize);

	/// <summary>
	/// Sets the value of a standard property associated with a biometric session, unit, template, or account. Starting with Windows 10,
	/// build 1607, this function is available to use with a mobile image.
	/// </summary>
	/// <param name="SessionHandle">
	/// A <c>WINBIO_SESSION_HANDLE</c> value that identifies an open biometric session. Open a synchronous session handle by calling
	/// WinBioOpenSession. Open an asynchronous session handle by calling WinBioAsyncOpenSession.
	/// </param>
	/// <param name="PropertyType">
	/// A <c>WINBIO_PROPERTY_TYPE</c> value that specifies the type of the property that you want to set. Currently this must be <c>WINBIO_PROPERTY_TYPE_ACCOUNT</c>.
	/// </param>
	/// <param name="PropertyId">
	/// A <c>WINBIO_PROPERTY_ID</c> value that specifies the property to set. Currently this must be
	/// <c>WINBIO_PROPERTY_ANTI_SPOOF_POLICY</c>. All other properties are read-only.
	/// </param>
	/// <param name="UnitId">
	/// A <c>WINBIO_UNIT_ID</c> value that identifies the biometric unit. For the <c>WINBIO_PROPERTY_ANTI_SPOOF_POLICY</c> property,
	/// this value must be 0.
	/// </param>
	/// <param name="Identity">Address of a WINBIO_IDENTITY structure that specifies the account for which you want to set the property.</param>
	/// <param name="SubFactor">Reserved. This must be <c>WINBIO_SUBTYPE_NO_INFORMATION</c>.</param>
	/// <param name="PropertyBuffer">
	/// A pointer to a structure that specifies the new value for the property. This value cannot be NULL. For setting the
	/// <c>WINBIO_PROPERTY_ANTI_SPOOF_POLICY</c> property, the structure must be a WINBIO_ANTI_SPOOF_POLICY structure.
	/// </param>
	/// <param name="PropertyBufferSize">
	/// The size, in bytes, of the structure to which the PropertyBuffer parameter points. This value cannot be 0.
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, it returns <c>S_OK</c>. If the function fails, it returns an <c>HRESULT</c> value that indicates the
	/// error. Possible values include, but are not limited to, those in the following table. For a list of common error codes, see
	/// Common HRESULT Values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_HANDLE</term>
	/// <term>The session handle specified by the SessionHandle parameter is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_POINTER</term>
	/// <term>The Identity and PropertyBuffer parameters cannot be NULL.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>The PropertyType, PropertyId, or PropertyBufferSize parameter cannot be 0.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_E_INVALID_PROPERTY_TYPE</term>
	/// <term>The value of the PropertyType argument is incorrect.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_E_INVALID_PROPERTY_ID</term>
	/// <term>The value of the PropertyId argument is incorrect.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_E_LOCK_VIOLATION</term>
	/// <term>The caller attempted to set a property that resides inside of a locked region.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_E_UNSUPPORTED_PROPERTY</term>
	/// <term>The object does not support the specified property.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_E_ENROLLMENT_IN_PROGRESS</term>
	/// <term>
	/// The operation could not be completed because the specified biometric unit is currently being used for an enrollment transaction
	/// (system pool only).
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// To use <c>WinBioSetProperty</c> synchronously, call the function with a session handle created by calling WinBioOpenSession. The
	/// function blocks until the operation completes or an error is encountered. To prevent memory leaks, you must call WinBioFree to
	/// release the memory pointed to by the PropertyBuffer parameter when you are finished using the data contained in the buffer.
	/// </para>
	/// <para>
	/// To use <c>WinBioSetProperty</c> asynchronously, call the function with a session handle created by calling
	/// WinBioAsyncOpenSession. The framework allocates a WINBIO_ASYNC_RESULT structure and uses it to return information about
	/// operation success or failure. The <c>WINBIO_ASYNC_RESULT</c> structure is returned to the application callback or to the
	/// application message queue, depending on the value you set in the NotificationMethod parameter of the
	/// <c>WinBioAsyncOpenSession</c> function:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// If you choose to receive completion notices by using a callback, you must implement a PWINBIO_ASYNC_COMPLETION_CALLBACK function
	/// and set the NotificationMethod parameter to <c>WINBIO_ASYNC_NOTIFY_CALLBACK</c>.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If you choose to receive completion notices by using the application message queue, you must set the NotificationMethod
	/// parameter to <c>WINBIO_ASYNC_NOTIFY_MESSAGE</c>. The framework returns a WINBIO_ASYNC_RESULT pointer to the <c>LPARAM</c> field
	/// of the window message.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// To prevent memory leaks, you must call WinBioFree to release the WINBIO_ASYNC_RESULT structure after you have finished using it.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbio/nf-winbio-winbiosetproperty HRESULT WinBioSetProperty(
	// WINBIO_SESSION_HANDLE SessionHandle, WINBIO_PROPERTY_TYPE PropertyType, WINBIO_PROPERTY_ID PropertyId, WINBIO_UNIT_ID UnitId,
	// WINBIO_IDENTITY *Identity, WINBIO_BIOMETRIC_SUBTYPE SubFactor, PVOID PropertyBuffer, SIZE_T PropertyBufferSize );
	[DllImport(Lib_Winbio, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winbio.h", MSDNShortId = "NF:winbio.WinBioSetProperty")]
	public static extern HRESULT WinBioSetProperty(WINBIO_SESSION_HANDLE SessionHandle, WINBIO_PROPERTY_TYPE PropertyType, WINBIO_PROPERTY_ID PropertyId,
		[Optional] WINBIO_UNIT_ID UnitId, [In, Optional] IntPtr Identity, [Optional] WINBIO_BIOMETRIC_SUBTYPE SubFactor, [In] IntPtr PropertyBuffer, SIZE_T PropertyBufferSize);

	/// <summary>Releases the session lock on the specified biometric unit.</summary>
	/// <param name="SessionHandle">
	/// A <c>WINBIO_SESSION_HANDLE</c> value that identifies an open biometric session. Open a synchronous session handle by calling
	/// WinBioOpenSession. Open an asynchronous session handle by calling WinBioAsyncOpenSession.
	/// </param>
	/// <param name="UnitId">A <c>WINBIO_UNIT_ID</c> value that specifies the biometric unit to unlock.</param>
	/// <returns>
	/// <para>
	/// If the function succeeds, it returns S_OK. If the function fails, it returns an <c>HRESULT</c> value that indicates the error.
	/// Possible values include, but are not limited to, those in the following table. For a list of common error codes, see Common
	/// HRESULT Values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_HANDLE</term>
	/// <term>The session handle is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>The UnitId parameter cannot contain zero.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_E_LOCK_VIOLATION</term>
	/// <term>The biometric unit specified by the UnitId parameter is not currently locked by the session.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Calling <c>WinBioUnlockUnit</c> automatically releases any locks held by the session. This function will fail if the biometric
	/// unit specified by the UnitId has not been previously locked by calling the WinBioLockUnit function.
	/// </para>
	/// <para>
	/// To use <c>WinBioUnlockUnit</c> synchronously, call the function with a session handle created by calling WinBioOpenSession. The
	/// function blocks until the operation completes or an error is encountered.
	/// </para>
	/// <para>
	/// To use <c>WinBioUnlockUnit</c> asynchronously, call the function with a session handle created by calling
	/// WinBioAsyncOpenSession. The framework allocates a WINBIO_ASYNC_RESULT structure and uses it to return information about
	/// operation success or failure. The <c>WINBIO_ASYNC_RESULT</c> structure is returned to the application callback or to the
	/// application message queue, depending on the value you set in the NotificationMethod parameter of the
	/// <c>WinBioAsyncOpenSession</c> function:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// If you choose to receive completion notices by using a callback, you must implement a PWINBIO_ASYNC_COMPLETION_CALLBACK function
	/// and set the NotificationMethod parameter to <c>WINBIO_ASYNC_NOTIFY_CALLBACK</c>.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If you choose to receive completion notices by using the application message queue, you must set the NotificationMethod
	/// parameter to <c>WINBIO_ASYNC_NOTIFY_MESSAGE</c>. The framework returns a WINBIO_ASYNC_RESULT pointer to the <c>LPARAM</c> field
	/// of the window message.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// To prevent memory leaks, you must call WinBioFree to release the WINBIO_ASYNC_RESULT structure after you have finished using it.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following function calls WinBioLockUnit to lock the biometric unit before calling WinBioIdentify to identify the user. It
	/// calls <c>WinBioUnlockUnit</c> to unlock the biometric union before closing the open session. Link to the Winbio.lib static
	/// library and include the following header files:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>Windows.h</term>
	/// </item>
	/// <item>
	/// <term>Stdio.h</term>
	/// </item>
	/// <item>
	/// <term>Conio.h</term>
	/// </item>
	/// <item>
	/// <term>Winbio.h</term>
	/// </item>
	/// </list>
	/// <para>
	/// <code>HRESULT LockUnlock( ) { // Declare variables. HRESULT hr = S_OK; WINBIO_IDENTITY identity = {0}; WINBIO_SESSION_HANDLE sessionHandle = NULL; WINBIO_UNIT_ID unitId = 0; WINBIO_REJECT_DETAIL rejectDetail = 0; WINBIO_BIOMETRIC_SUBTYPE subFactor = WINBIO_SUBTYPE_NO_INFORMATION; BOOL lockAcquired = FALSE; // Connect to the system pool. hr = WinBioOpenSession( WINBIO_TYPE_FINGERPRINT, // Service provider WINBIO_POOL_SYSTEM, // Pool type WINBIO_FLAG_DEFAULT, // Configuration and access NULL, // Array of biometric unit IDs 0, // Count of biometric unit IDs NULL, // Database ID &amp;sessionHandle // [out] Session handle ); if (FAILED(hr)) { wprintf_s(L"\n WinBioEnumBiometricUnits failed. hr = 0x%x\n", hr); goto e_Exit; } // Lock the session. The Biometric unit ID (1) is hard coded in // this example. hr = WinBioLockUnit( sessionHandle, 1 ); if (FAILED(hr)) { wprintf_s(L"\n WinBioLockUnit failed. hr = 0x%x\n", hr); goto e_Exit; } wprintf_s(L"\n Biometric unit #1 is locked.\n"); lockAcquired = TRUE; // Locate the biometric sensor and retrieve a WINBIO_IDENTITY object. // You must swipe your finger on the sensor. wprintf_s(L"\n Calling WinBioIdentify - Swipe finger on sensor...\n"); hr = WinBioIdentify( sessionHandle, &amp;unitId, &amp;identity, &amp;subFactor, &amp;rejectDetail ); wprintf_s(L"\n Swipe processed - Unit ID: %d\n", unitId); if (FAILED(hr)) { wprintf_s(L"\n WinBioIdentify failed. hr = 0x%x\n", hr); goto e_Exit; } e_Exit: // Unlock the biometric unit if it is locked. if (lockAcquired == TRUE) { hr = WinBioUnlockUnit( sessionHandle, 1 ); if (FAILED(hr)) { wprintf_s(L"\n WinBioUnlockUnit failed. hr = 0x%x\n", hr); } wprintf_s(L"\n Biometric unit #1 is unlocked.\n"); lockAcquired = FALSE; } if (sessionHandle != NULL) { WinBioCloseSession(sessionHandle); sessionHandle = NULL; } wprintf_s(L"\n Press any key to exit..."); _getch(); return hr; }</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbio/nf-winbio-winbiounlockunit HRESULT WinBioUnlockUnit(
	// WINBIO_SESSION_HANDLE SessionHandle, WINBIO_UNIT_ID UnitId );
	[DllImport(Lib_Winbio, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winbio.h", MSDNShortId = "NF:winbio.WinBioUnlockUnit")]
	public static extern HRESULT WinBioUnlockUnit(WINBIO_SESSION_HANDLE SessionHandle, WINBIO_UNIT_ID UnitId);

	/// <summary>
	/// The <c>WinBioUnregisterEventMonitor</c> function cancels event notifications from the service provider associated with an open
	/// biometric session.
	/// </summary>
	/// <param name="SessionHandle">
	/// A <c>WINBIO_SESSION_HANDLE</c> value that identifies the open biometric session. Open the session handle by calling WinBioOpenSession.
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, it returns S_OK. If the function fails, it returns an <c>HRESULT</c> value that indicates the error.
	/// Possible values include, but are not limited to, those in the following table. For a list of common error codes, see Common
	/// HRESULT Values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_HANDLE</term>
	/// <term>The session handle is not valid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>Call the WinBioRegisterEventMonitor function to begin receiving event notifications.</para>
	/// <para>
	/// If an application registers a <c>WinBio</c> event monitor and leaves that monitor active during a sleep/wake cycle, systems that
	/// implement biometric pre-boot authentication (PBA)/single sign-on features may not always work. The problem is that the PBA
	/// biometric call is intercepted by the event monitor before the system's biometric credential provider has a chance to perform its
	/// first WinBioIdentify operation. Apps that use the <c>WinBio</c> event monitoring feature should unregister their monitors before
	/// the system sleeps, and re-register them after system wakeup. For more information on handling events during power state changes,
	/// see About Power Management.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following function registers an event monitor by calling the WinBioRegisterEventMonitor function and passing the address of
	/// a callback routine. The callback, also included, receives event notifications from the Windows biometric framework. The function
	/// also calls <c>WinBioUnregisterEventMonitor</c> before closing the biometric session. Link to the Winbio.lib static library and
	/// include the following header files:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>Windows.h</term>
	/// </item>
	/// <item>
	/// <term>Stdio.h</term>
	/// </item>
	/// <item>
	/// <term>Conio.h</term>
	/// </item>
	/// <item>
	/// <term>Winbio.h</term>
	/// </item>
	/// </list>
	/// <para>
	/// <code>HRESULT RegisterSystemEventMonitor(BOOL bCancel) { HRESULT hr = S_OK; WINBIO_SESSION_HANDLE sessionHandle = NULL; WINBIO_UNIT_ID unitId = 0; // Connect to the system pool. hr = WinBioOpenSession( WINBIO_TYPE_FINGERPRINT, // Service provider WINBIO_POOL_SYSTEM, // Pool type WINBIO_FLAG_DEFAULT, // Configuration and access NULL, // Array of biometric unit IDs 0, // Count of biometric unit IDs NULL, // Database ID &amp;sessionHandle // [out] Session handle ); if (FAILED(hr)) { wprintf_s(L"\n WinBioOpenSession failed. hr = 0x%x\n", hr); goto e_Exit; } // Call the WinBioRegisterEventMonitor function. wprintf_s(L"\n Calling WinBioRegisterEventMonitor.\n"); hr = WinBioRegisterEventMonitor( sessionHandle, // Open session handle WINBIO_EVENT_FP_UNCLAIMED, // Events to monitor EventMonitorCallback, // Callback function NULL // Optional context. ); if (FAILED(hr)) { wprintf_s(L"\n WinBioRegisterEventMonitor failed."); wprintf_s(L"hr = 0x%x\n", hr); goto e_Exit; } wprintf_s(L"\n Waiting for an event.\n"); // Cancel the identification if the bCancel flag is set. if (bCancel) { wprintf_s(L"\n Starting CANCEL timer...\n"); Sleep( 7000 ); wprintf_s(L"\n Calling WinBioCancel\n"); hr = WinBioCancel( sessionHandle ); if (FAILED(hr)) { wprintf_s(L"\n WinBioCancel failed. hr = 0x%x\n", hr); goto e_Exit; } } // Wait for an event to happen. //wprintf_s(L"\n Swipe the sensor to receive an event notice "); //wprintf_s(L"\n or press any key to stop waiting...\n"); wprintf_s(L"\n Swipe the sensor one or more times "); wprintf_s(L"to generate events."); wprintf_s(L"\n When done, press a key to exit...\n"); _getch(); // Unregister the event monitor. wprintf_s(L"\n Calling WinBioUnregisterEventMonitor\n"); hr = WinBioUnregisterEventMonitor( sessionHandle); if (FAILED(hr)) { wprintf_s(L"\n WinBioUnregisterEventMonitor failed."); wprintf_s(L"hr = 0x%x\n", hr); } e_Exit: if (sessionHandle != NULL) { wprintf_s(L"\n Closing the session.\n"); hr = WinBioCloseSession(sessionHandle); if (FAILED(hr)) { wprintf_s(L"\n WinBioCloseSession failed. hr = 0x%x\n", hr); } sessionHandle = NULL; } wprintf_s(L"\n Press any key to exit..."); _getch(); return hr; } //------------------------------------------------------------------------ // The following function is the callback for WinBioRegisterEventMonitor. // The function filters any event notice from the biometric subsystem and // writes a result to the console window. // VOID CALLBACK EventMonitorCallback( __in_opt PVOID EventCallbackContext, __in HRESULT OperationStatus, __in PWINBIO_EVENT Event ) { UNREFERENCED_PARAMETER(EventCallbackContext); wprintf_s(L"\n EventMonitorCallback executing."); // Failure. if (FAILED(OperationStatus)) { wprintf_s(L"\n EventMonitorCallback failed. "); wprintf_s(L" OperationStatus = 0x%x\n", OperationStatus); goto e_Exit; } // An event notice was received. if (Event != NULL) { wprintf_s(L"\n MonitorEvent: "); switch (Event-&gt;Type) { case WINBIO_EVENT_FP_UNCLAIMED: wprintf_s(L"WINBIO_EVENT_FP_UNCLAIMED"); wprintf_s(L"\n Unit ID: %d", Event-&gt;Parameters.Unclaimed.UnitId); wprintf_s(L"\n Reject detail: %d\n", Event-&gt;Parameters.Unclaimed.RejectDetail); break; case WINBIO_EVENT_FP_UNCLAIMED_IDENTIFY: wprintf_s(L"WINBIO_EVENT_FP_UNCLAIMED_IDENTIFY"); wprintf_s(L"\n Unit ID: %d", Event-&gt;Parameters.UnclaimedIdentify.UnitId); wprintf_s(L"\n Reject detail: %d\n", Event-&gt;Parameters.UnclaimedIdentify.RejectDetail); break; case WINBIO_EVENT_ERROR: wprintf_s(L"WINBIO_EVENT_ERROR\n"); break; default: wprintf_s(L"(0x%08x - Invalid type)\n", Event-&gt;Type); break; } } e_Exit: if (Event != NULL) { //wprintf_s(L"\n Press any key to continue...\n"); WinBioFree(Event); Event = NULL; } }</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbio/nf-winbio-winbiounregistereventmonitor HRESULT
	// WinBioUnregisterEventMonitor( WINBIO_SESSION_HANDLE SessionHandle );
	[DllImport(Lib_Winbio, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winbio.h", MSDNShortId = "NF:winbio.WinBioUnregisterEventMonitor")]
	public static extern HRESULT WinBioUnregisterEventMonitor(WINBIO_SESSION_HANDLE SessionHandle);

	/// <summary>
	/// Captures a biometric sample and determines whether the sample corresponds to the specified user identity. Starting with Windows
	/// 10, build 1607, this function is available to use with a mobile image.
	/// </summary>
	/// <param name="SessionHandle">
	/// A <c>WINBIO_SESSION_HANDLE</c> value that identifies an open biometric session. Open a synchronous session handle by calling
	/// WinBioOpenSession. Open an asynchronous session handle by calling WinBioAsyncOpenSession.
	/// </param>
	/// <param name="Identity">
	/// Pointer to a WINBIO_IDENTITY structure that contains the GUID or SID of the user providing the biometric sample.
	/// </param>
	/// <param name="SubFactor">
	/// <para>
	/// A <c>WINBIO_BIOMETRIC_SUBTYPE</c> value that specifies the sub-factor associated with the biometric sample. The Windows
	/// Biometric Framework (WBF) currently supports only fingerprint capture and can use the following constants to represent sub-type information.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>WINBIO_ANSI_381_POS_RH_THUMB</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_ANSI_381_POS_RH_INDEX_FINGER</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_ANSI_381_POS_RH_MIDDLE_FINGER</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_ANSI_381_POS_RH_RING_FINGER</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_ANSI_381_POS_RH_LITTLE_FINGER</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_ANSI_381_POS_LH_THUMB</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_ANSI_381_POS_LH_INDEX_FINGER</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_ANSI_381_POS_LH_MIDDLE_FINGER</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_ANSI_381_POS_LH_RING_FINGER</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_ANSI_381_POS_LH_LITTLE_FINGER</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_ANSI_381_POS_RH_FOUR_FINGERS</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_ANSI_381_POS_LH_FOUR_FINGERS</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_SUBTYPE_ANY</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="UnitId">A pointer to a <c>WINBIO_UNIT_ID</c> value that specifies the biometric unit that performed the verification.</param>
	/// <param name="Match">
	/// Pointer to a Boolean value that specifies whether the captured sample matched the user identity specified by the Identity parameter.
	/// </param>
	/// <param name="RejectDetail">
	/// <para>
	/// A pointer to a <c>ULONG</c> value that contains additional information about the failure to capture a biometric sample. If the
	/// capture succeeded, this parameter is set to zero. The following values are defined for fingerprint capture:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>WINBIO_FP_TOO_HIGH</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FP_TOO_LOW</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FP_TOO_LEFT</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FP_TOO_RIGHT</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FP_TOO_FAST</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FP_TOO_SLOW</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FP_POOR_QUALITY</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FP_TOO_SKEWED</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FP_TOO_SHORT</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FP_MERGE_FAILURE</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, it returns S_OK. If the function fails, it returns an <c>HRESULT</c> value that indicates the error.
	/// Possible values include, but are not limited to, those in the following table. For a list of common error codes, see Common
	/// HRESULT Values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_HANDLE</term>
	/// <term>The session handle is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>The SubFactor argument is incorrect.</term>
	/// </item>
	/// <item>
	/// <term>E_POINTER</term>
	/// <term>The pointer specified by the UnitId, Identity, SubFactor, or RejectDetail parameters cannot be NULL.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_E_BAD_CAPTURE</term>
	/// <term>The biometric sample could not be captured. Use the RejectDetail value for more information.</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_E_ENROLLMENT_IN_PROGRESS</term>
	/// <term>
	/// The operation could not be completed because the specified biometric unit is currently being used for an enrollment transaction
	/// (system pool only).
	/// </term>
	/// </item>
	/// <item>
	/// <term>WINBIO_E_NO_MATCH</term>
	/// <term>The biometric sample does not correspond to the specified Identity and SubFactor combination.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If capture of the biometric sample fails, the UnitId parameter will contain the unit number of the sensor that attempted to
	/// perform the capture.
	/// </para>
	/// <para>
	/// Calls to this function using the system pool will block until the application acquires window focus and the user has provided a
	/// biometric sample. We recommend, therefore, that your application not call <c>WinBioVerify</c> until it has acquired focus. The
	/// manner in which you acquire focus depends on the type of application you are writing. For example, if you are creating a GUI
	/// application you can implement a message handler that captures a WM_ACTIVATE, WM_SETFOCUS, or other appropriate message. If you
	/// are writing a CUI application, call <c>GetConsoleWindow</c> to retrieve a handle to the console window and pass that handle to
	/// the <c>SetForegroundWindow</c> function to force the console window into the foreground and assign it focus. If your application
	/// is running in a detached process and has no window or is a Windows service, use WinBioAcquireFocus and WinBioReleaseFocus to
	/// manually control focus.
	/// </para>
	/// <para>
	/// To use <c>WinBioVerify</c> synchronously, call the function with a session handle created by calling WinBioOpenSession. The
	/// function blocks until the operation completes or an error is encountered.
	/// </para>
	/// <para>
	/// To use <c>WinBioVerify</c> asynchronously, call the function with a session handle created by calling WinBioAsyncOpenSession.
	/// The framework allocates a WINBIO_ASYNC_RESULT structure and uses it to return information about operation success or failure. If
	/// the operation is successful, the framework returns a <c>BOOLEAN</c> match value in a nested <c>Verify</c> structure. If the
	/// operation is unsuccessful, the framework returns <c>WINBIO_REJECT_DETAIL</c> information in the <c>Verify</c> structure. The
	/// <c>WINBIO_ASYNC_RESULT</c> structure is returned to the application callback or to the application message queue, depending on
	/// the value you set in the NotificationMethod parameter of the <c>WinBioAsyncOpenSession</c> function:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// If you choose to receive completion notices by using a callback, you must implement a PWINBIO_ASYNC_COMPLETION_CALLBACK function
	/// and set the NotificationMethod parameter to <c>WINBIO_ASYNC_NOTIFY_CALLBACK</c>.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If you choose to receive completion notices by using the application message queue, you must set the NotificationMethod
	/// parameter to <c>WINBIO_ASYNC_NOTIFY_MESSAGE</c>. The framework returns a WINBIO_ASYNC_RESULT pointer to the <c>LPARAM</c> field
	/// of the window message.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// To prevent memory leaks, you must call WinBioFree to release the WINBIO_ASYNC_RESULT structure after you have finished using it.
	/// </para>
	/// <para>
	/// <c>Windows 7:</c> You can perform this operation asynchronously by using the WinBioVerifyWithCallback function. The function
	/// verifies the input arguments and returns immediately. If the input arguments are not valid, the function returns an error code.
	/// Otherwise, the framework starts the operation on another thread. When the asynchronous operation completes or encounters an
	/// error, the framework sends the results to the PWINBIO_VERIFY_CALLBACK function implemented by your application.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following function calls <c>WinBioVerify</c> to determine whether a biometric sample matches the logged on identity of the
	/// current user. The helper function GetCurrentUserIdentity is also included. Link to the Winbio.lib static library and include the
	/// following header files:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>Windows.h</term>
	/// </item>
	/// <item>
	/// <term>Stdio.h</term>
	/// </item>
	/// <item>
	/// <term>Conio.h</term>
	/// </item>
	/// <item>
	/// <term>Winbio.h</term>
	/// </item>
	/// </list>
	/// <para>
	/// <code>HRESULT Verify(WINBIO_BIOMETRIC_SUBTYPE subFactor) { HRESULT hr = S_OK; WINBIO_SESSION_HANDLE sessionHandle = NULL; WINBIO_UNIT_ID unitId = 0; WINBIO_REJECT_DETAIL rejectDetail = 0; WINBIO_IDENTITY identity = {0}; BOOLEAN match = FALSE; // Find the identity of the user. hr = GetCurrentUserIdentity( &amp;identity ); if (FAILED(hr)) { wprintf_s(L"\n User identity not found. hr = 0x%x\n", hr); goto e_Exit; } // Connect to the system pool. hr = WinBioOpenSession( WINBIO_TYPE_FINGERPRINT, // Service provider WINBIO_POOL_SYSTEM, // Pool type WINBIO_FLAG_DEFAULT, // Configuration and access NULL, // Array of biometric unit IDs 0, // Count of biometric unit IDs NULL, // Database ID &amp;sessionHandle // [out] Session handle ); if (FAILED(hr)) { wprintf_s(L"\n WinBioOpenSession failed. hr = 0x%x\n", hr); goto e_Exit; } // Verify a biometric sample. wprintf_s(L"\n Calling WinBioVerify - Swipe finger on sensor...\n"); hr = WinBioVerify( sessionHandle, &amp;identity, subFactor, &amp;unitId, &amp;match, &amp;rejectDetail ); wprintf_s(L"\n Swipe processed - Unit ID: %d\n", unitId); if (FAILED(hr)) { if (hr == WINBIO_E_NO_MATCH) { wprintf_s(L"\n- NO MATCH - identity verification failed.\n"); } else if (hr == WINBIO_E_BAD_CAPTURE) { wprintf_s(L"\n- Bad capture; reason: %d\n", rejectDetail); } else { wprintf_s(L"\n WinBioVerify failed. hr = 0x%x\n", hr); } goto e_Exit; } wprintf_s(L"\n Fingerprint verified:\n", unitId); e_Exit: if (sessionHandle != NULL) { WinBioCloseSession(sessionHandle); sessionHandle = NULL; } wprintf_s(L"\n Press any key to exit..."); _getch(); return hr; } //------------------------------------------------------------------------ // The following function retrieves the identity of the current user. // This is a helper function and is not part of the Windows Biometric // Framework API. // HRESULT GetCurrentUserIdentity(__inout PWINBIO_IDENTITY Identity) { // Declare variables. HRESULT hr = S_OK; HANDLE tokenHandle = NULL; DWORD bytesReturned = 0; struct{ TOKEN_USER tokenUser; BYTE buffer[SECURITY_MAX_SID_SIZE]; } tokenInfoBuffer; // Zero the input identity and specify the type. ZeroMemory( Identity, sizeof(WINBIO_IDENTITY)); Identity-&gt;Type = WINBIO_ID_TYPE_NULL; // Open the access token associated with the // current process if (!OpenProcessToken( GetCurrentProcess(), // Process handle TOKEN_READ, // Read access only &amp;tokenHandle)) // Access token handle { DWORD win32Status = GetLastError(); wprintf_s(L"Cannot open token handle: %d\n", win32Status); hr = HRESULT_FROM_WIN32(win32Status); goto e_Exit; } // Zero the tokenInfoBuffer structure. ZeroMemory(&amp;tokenInfoBuffer, sizeof(tokenInfoBuffer)); // Retrieve information about the access token. In this case, // retrieve a SID. if (!GetTokenInformation( tokenHandle, // Access token handle TokenUser, // User for the token &amp;tokenInfoBuffer.tokenUser, // Buffer to fill sizeof(tokenInfoBuffer), // Size of the buffer &amp;bytesReturned)) // Size needed { DWORD win32Status = GetLastError(); wprintf_s(L"Cannot query token information: %d\n", win32Status); hr = HRESULT_FROM_WIN32(win32Status); goto e_Exit; } // Copy the SID from the tokenInfoBuffer structure to the // WINBIO_IDENTITY structure. CopySid( SECURITY_MAX_SID_SIZE, Identity-&gt;Value.AccountSid.Data, tokenInfoBuffer.tokenUser.User.Sid ); // Specify the size of the SID and assign WINBIO_ID_TYPE_SID // to the type member of the WINBIO_IDENTITY structure. Identity-&gt;Value.AccountSid.Size = GetLengthSid(tokenInfoBuffer.tokenUser.User.Sid); Identity-&gt;Type = WINBIO_ID_TYPE_SID; e_Exit: if (tokenHandle != NULL) { CloseHandle(tokenHandle); } return hr; }</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbio/nf-winbio-winbioverify HRESULT WinBioVerify( WINBIO_SESSION_HANDLE
	// SessionHandle, WINBIO_IDENTITY *Identity, WINBIO_BIOMETRIC_SUBTYPE SubFactor, WINBIO_UNIT_ID *UnitId, BOOLEAN *Match,
	// WINBIO_REJECT_DETAIL *RejectDetail );
	[DllImport(Lib_Winbio, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winbio.h", MSDNShortId = "NF:winbio.WinBioVerify")]
	public static extern HRESULT WinBioVerify(WINBIO_SESSION_HANDLE SessionHandle, in WINBIO_IDENTITY Identity, WINBIO_BIOMETRIC_SUBTYPE SubFactor,
		out WINBIO_UNIT_ID UnitId, [MarshalAs(UnmanagedType.U1)] out bool Match, out WINBIO_REJECT_DETAIL RejectDetail);

	/// <summary>
	/// <para>
	/// Asynchronously captures a biometric sample and determines whether the sample corresponds to the specified user identity. The
	/// function returns immediately to the caller, performs capture and verification on a separate thread, and calls into an
	/// application-defined callback function to update operation status.
	/// </para>
	/// <para><c>Important</c>
	/// <para></para>
	/// We recommend that, beginning with Windows 8, you no longer use this function to start an asynchronous operation. Instead, do the following:
	/// </para>
	/// </summary>
	/// <param name="SessionHandle">A <c>WINBIO_SESSION_HANDLE</c> value that identifies an open biometric session.</param>
	/// <param name="Identity">
	/// Pointer to a WINBIO_IDENTITY structure that contains the GUID or SID of the user providing the biometric sample.
	/// </param>
	/// <param name="SubFactor">
	/// A <c>WINBIO_BIOMETRIC_SUBTYPE</c> value that specifies the sub-factor associated with the biometric sample. See the Remarks
	/// section for more details.
	/// </param>
	/// <param name="VerifyCallback">
	/// Address of a callback function that will be called by the <c>WinBioVerifyWithCallback</c> function when verification succeeds or
	/// fails. You must create the callback.
	/// </param>
	/// <param name="VerifyCallbackContext">
	/// An optional application-defined structure that is returned in the VerifyCallbackContext parameter of the callback function. This
	/// structure can contain any data that the custom callback function is designed to handle.
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, it returns <c>S_OK</c>. If the function fails, it returns an <c>HRESULT</c> value that indicates the
	/// error. Possible values include, but are not limited to, those in the following table. For a list of common error codes, see
	/// Common HRESULT Values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_HANDLE</term>
	/// <term>The session handle is not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>The SubFactor argument is incorrect.</term>
	/// </item>
	/// <item>
	/// <term>E_POINTER</term>
	/// <term>The pointer specified by the Identity and VerifyCallback parameters cannot be NULL.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The SubFactor parameter specifies the sub-factor associated with the biometric sample. The Windows Biometric Framework (WBF)
	/// currently supports only fingerprint capture and uses the following constants to represent sub-type information.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term><c>WINBIO_ANSI_381_POS_RH_THUMB</c></term>
	/// </item>
	/// <item>
	/// <term><c>WINBIO_ANSI_381_POS_RH_INDEX_FINGER</c></term>
	/// </item>
	/// <item>
	/// <term><c>WINBIO_ANSI_381_POS_RH_MIDDLE_FINGER</c></term>
	/// </item>
	/// <item>
	/// <term><c>WINBIO_ANSI_381_POS_RH_RING_FINGER</c></term>
	/// </item>
	/// <item>
	/// <term><c>WINBIO_ANSI_381_POS_RH_LITTLE_FINGER</c></term>
	/// </item>
	/// <item>
	/// <term><c>WINBIO_ANSI_381_POS_LH_THUMB</c></term>
	/// </item>
	/// <item>
	/// <term><c>WINBIO_ANSI_381_POS_LH_INDEX_FINGER</c></term>
	/// </item>
	/// <item>
	/// <term><c>WINBIO_ANSI_381_POS_LH_MIDDLE_FINGER</c></term>
	/// </item>
	/// <item>
	/// <term><c>WINBIO_ANSI_381_POS_LH_RING_FINGER</c></term>
	/// </item>
	/// <item>
	/// <term><c>WINBIO_ANSI_381_POS_LH_LITTLE_FINGER</c></term>
	/// </item>
	/// <item>
	/// <term><c>WINBIO_ANSI_381_POS_RH_FOUR_FINGERS</c></term>
	/// </item>
	/// <item>
	/// <term><c>WINBIO_ANSI_381_POS_LH_FOUR_FINGERS</c></term>
	/// </item>
	/// </list>
	/// <para>
	/// The callback routine executes in the context of an arbitrary thread in the calling process. The caller is responsible for
	/// synchronizing access to any memory that may be shared between the callback and other parts of the application.
	/// </para>
	/// <para>
	/// The <c>WinBioVerifyWithCallback</c> function returns immediately and passes S_OK to the caller. To determine the status of the
	/// capture and verification process, you must examine the OperationStatus parameter in your callback function.
	/// </para>
	/// <para>
	/// You can call the WinBioCancel function to cancel a pending callback operation. Closing a session also implicitly cancels
	/// callbacks for that session.
	/// </para>
	/// <para>The callback routine must have the following signature:</para>
	/// <para>
	/// <code> VOID CALLBACK VerifyCallback( __in_opt PVOID VerifyCallbackContext, __in HRESULT OperationStatus, __in WINBIO_UNIT_ID UnitId, __in BOOLEAN Match, __in WINBIO_REJECT_DETAIL RejectDetail );</code>
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following function calls <c>WinBioVerifyWithCallback</c> to asynchronously determine whether a biometric sample matches the
	/// logged on identity of the current user. The callback routine, VerifyCallback, and a helper function, GetCurrentUserIdentity, are
	/// also included. Link to the Winbio.lib static library and include the following header files:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>Windows.h</term>
	/// </item>
	/// <item>
	/// <term>Stdio.h</term>
	/// </item>
	/// <item>
	/// <term>Conio.h</term>
	/// </item>
	/// <item>
	/// <term>Winbio.h</term>
	/// </item>
	/// </list>
	/// <para>
	/// <code>HRESULT VerifyWithCallback(BOOL bCancel, WINBIO_BIOMETRIC_SUBTYPE subFactor) { // Declare variables. HRESULT hr = S_OK; WINBIO_SESSION_HANDLE sessionHandle = NULL; WINBIO_UNIT_ID unitId = 0; WINBIO_REJECT_DETAIL rejectDetail = 0; WINBIO_IDENTITY identity = {0}; // Find the identity of the user. hr = GetCurrentUserIdentity( &amp;identity ); if (FAILED(hr)) { wprintf_s(L"\n User identity not found. hr = 0x%x\n", hr); goto e_Exit; } // Connect to the system pool. hr = WinBioOpenSession( WINBIO_TYPE_FINGERPRINT, // Service provider WINBIO_POOL_SYSTEM, // Pool type WINBIO_FLAG_DEFAULT, // Configuration and access NULL, // Array of biometric unit IDs 0, // Count of biometric unit IDs NULL, // Database ID &amp;sessionHandle // [out] Session handle ); if (FAILED(hr)) { wprintf_s(L"\n WinBioOpenSession failed. hr = 0x%x\n", hr); goto e_Exit; } // Verify a biometric sample asynchronously. wprintf_s(L"\n Calling WinBioVerifyWithCallback.\n"); hr = WinBioVerifyWithCallback( sessionHandle, // Open session handle &amp;identity, // User SID or GUID subFactor, // Sample sub-factor VerifyCallback, // Callback function NULL // Optional context ); if (FAILED(hr)) { wprintf_s(L"\n WinBioVerifyWithCallback failed. hr = 0x%x\n", hr); goto e_Exit; } wprintf_s(L"\n Swipe the sensor ...\n"); // Cancel the identification if the bCancel flag is set. if (bCancel) { wprintf_s(L"\n Starting CANCEL timer...\n"); Sleep( 7000 ); wprintf_s(L"\n Calling WinBioCancel\n"); hr = WinBioCancel( sessionHandle ); if (FAILED(hr)) { wprintf_s(L"\n WinBioCancel failed. hr = 0x%x\n", hr); goto e_Exit; } } // Wait for the asynchronous identification process to complete // or be canceled. hr = WinBioWait( sessionHandle ); if (FAILED(hr)) { wprintf_s(L"\n WinBioWait failed. hr = 0x%x\n", hr); } e_Exit: if (sessionHandle != NULL) { WinBioCloseSession(sessionHandle); sessionHandle = NULL; } wprintf_s(L"\n Hit any key to continue..."); _getch(); return hr; } //------------------------------------------------------------------------ // The following function is the callback for WinBioVerifyWithCallback. // The function filters the response from the biometric subsystem and // writes a result to the console window. // VOID CALLBACK VerifyCallback( __in_opt PVOID VerifyCallbackContext, __in HRESULT OperationStatus, __in WINBIO_UNIT_ID UnitId, __in BOOLEAN Match, __in WINBIO_REJECT_DETAIL RejectDetail ) { UNREFERENCED_PARAMETER(VerifyCallbackContext); UNREFERENCED_PARAMETER(Match); wprintf_s(L"\n VerifyCallback executing"); wprintf_s(L"\n Swipe processed for unit ID %d\n", UnitId); // The identity could not be verified. if (FAILED(OperationStatus)) { wprintf_s(L"\n Verification failed for the following reason:"); if (OperationStatus == WINBIO_E_NO_MATCH) { wprintf_s(L"\n No match.\n"); } else if (OperationStatus == WINBIO_E_BAD_CAPTURE) { wprintf_s(L"\n Bad capture.\n "); wprintf_s(L"\n Bad capture; reason: %d\n", RejectDetail); } else { wprintf_s(L"VerifyCallback failed."); wprintf_s(L"OperationStatus = 0x%x\n", OperationStatus); } goto e_Exit; } // The user identity was verified. wprintf_s(L"\n Fingerprint verified:\n"); e_Exit: return; } //------------------------------------------------------------------------ // The following function retrieves the identity of the current user. // This is a helper function and is not part of the Windows Biometric // Framework API. // HRESULT GetCurrentUserIdentity(__inout PWINBIO_IDENTITY Identity) { // Declare variables. HRESULT hr = S_OK; HANDLE tokenHandle = NULL; DWORD bytesReturned = 0; struct{ TOKEN_USER tokenUser; BYTE buffer[SECURITY_MAX_SID_SIZE]; } tokenInfoBuffer; // Zero the input identity and specify the type. ZeroMemory( Identity, sizeof(WINBIO_IDENTITY)); Identity-&gt;Type = WINBIO_ID_TYPE_NULL; // Open the access token associated with the // current process if (!OpenProcessToken( GetCurrentProcess(), // Process handle TOKEN_READ, // Read access only &amp;tokenHandle)) // Access token handle { DWORD win32Status = GetLastError(); wprintf_s(L"Cannot open token handle: %d\n", win32Status); hr = HRESULT_FROM_WIN32(win32Status); goto e_Exit; } // Zero the tokenInfoBuffer structure. ZeroMemory(&amp;tokenInfoBuffer, sizeof(tokenInfoBuffer)); // Retrieve information about the access token. In this case, // retrieve a SID. if (!GetTokenInformation( tokenHandle, // Access token handle TokenUser, // User for the token &amp;tokenInfoBuffer.tokenUser, // Buffer to fill sizeof(tokenInfoBuffer), // Size of the buffer &amp;bytesReturned)) // Size needed { DWORD win32Status = GetLastError(); wprintf_s(L"Cannot query token information: %d\n", win32Status); hr = HRESULT_FROM_WIN32(win32Status); goto e_Exit; } // Copy the SID from the tokenInfoBuffer structure to the // WINBIO_IDENTITY structure. CopySid( SECURITY_MAX_SID_SIZE, Identity-&gt;Value.AccountSid.Data, tokenInfoBuffer.tokenUser.User.Sid ); // Specify the size of the SID and assign WINBIO_ID_TYPE_SID // to the type member of the WINBIO_IDENTITY structure. Identity-&gt;Value.AccountSid.Size = GetLengthSid(tokenInfoBuffer.tokenUser.User.Sid); Identity-&gt;Type = WINBIO_ID_TYPE_SID; e_Exit: if (tokenHandle != NULL) { CloseHandle(tokenHandle); } return hr; }</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbio/nf-winbio-winbioverifywithcallback HRESULT WinBioVerifyWithCallback(
	// WINBIO_SESSION_HANDLE SessionHandle, WINBIO_IDENTITY *Identity, WINBIO_BIOMETRIC_SUBTYPE SubFactor, PWINBIO_VERIFY_CALLBACK
	// VerifyCallback, PVOID VerifyCallbackContext );
	[DllImport(Lib_Winbio, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winbio.h", MSDNShortId = "NF:winbio.WinBioVerifyWithCallback")]
	public static extern HRESULT WinBioVerifyWithCallback(WINBIO_SESSION_HANDLE SessionHandle, in WINBIO_IDENTITY Identity,
		WINBIO_BIOMETRIC_SUBTYPE SubFactor, [In] PWINBIO_VERIFY_CALLBACK VerifyCallback, [In, Optional] IntPtr VerifyCallbackContext);

	/// <summary>
	/// Blocks caller execution until all pending biometric operations for a session have been completed or canceled. Starting with
	/// Windows 10, build 1607, this function is available to use with a mobile image.
	/// </summary>
	/// <param name="SessionHandle">
	/// A <c>WINBIO_SESSION_HANDLE</c> value that identifies an open biometric session. Open a synchronous session handle by calling
	/// WinBioOpenSession. Open an asynchronous session handle by calling WinBioAsyncOpenSession.
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, it returns S_OK. If the function fails, it returns an <c>HRESULT</c> value that indicates the error.
	/// Possible values include, but are not limited to, those in the following table. For a list of common error codes, see Common
	/// HRESULT Values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_HANDLE</term>
	/// <term>The session handle is not valid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>WinBioWait</c> blocks the caller's thread regardless of whether you pass a synchronous or an asynchronous session handle to
	/// the SessionHandle parameter.
	/// </para>
	/// <para>
	/// Unlike all other functions that can be called by using an asynchronous session handle, the framework does not create a
	/// WINBIO_ASYNC_RESULT structure for the <c>WinBioWait</c> function.
	/// </para>
	/// <para>
	/// Do not call <c>WinBioWait</c> from the context of a callback routine or from any function that can be called indirectly from a
	/// callback routine. Doing so will cause a permanent deadlock.
	/// </para>
	/// <para>
	/// Do not call <c>WinBioWait</c> from a window procedure. Doing so will cause the user interface to freeze until the event
	/// notification arrives.
	/// </para>
	/// <para>
	/// If you call <c>WinBioWait</c> from an asynchronous session that generates window messages, there is no guarantee of the order in
	/// which the window message and the wake-from-wait message will arrive. We recommend that you not write any code that depends on
	/// the order of these events.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following code example shows how to call the <c>WinBioWait</c> function to block execution and wait for an asynchronous
	/// thread to finish processing. Link to the Winbio.lib static library and include the following header files:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>Windows.h</term>
	/// </item>
	/// <item>
	/// <term>Stdio.h</term>
	/// </item>
	/// <item>
	/// <term>Conio.h</term>
	/// </item>
	/// <item>
	/// <term>Winbio.h</term>
	/// </item>
	/// </list>
	/// <para>
	/// <code>HRESULT CaptureSampleWithCallback(BOOL bCancel) { HRESULT hr = S_OK; WINBIO_SESSION_HANDLE sessionHandle = NULL; // Connect to the system pool. hr = WinBioOpenSession( WINBIO_TYPE_FINGERPRINT, // Service provider WINBIO_POOL_SYSTEM, // Pool type WINBIO_FLAG_RAW, // Raw access NULL, // Array of biometric unit IDs 0, // Count of biometric unit IDs WINBIO_DB_DEFAULT, // Default database &amp;sessionHandle // [out] Session handle ); if (FAILED(hr)) { wprintf_s(L"\n WinBioOpenSession failed. hr = 0x%x\n", hr); goto e_Exit; } // Capture a biometric sample asynchronously. wprintf_s(L"\n Calling WinBioCaptureSampleWithCallback "); hr = WinBioCaptureSampleWithCallback( sessionHandle, // Open session handle WINBIO_NO_PURPOSE_AVAILABLE, // Intended use of the sample WINBIO_DATA_FLAG_RAW, // Sample format CaptureSampleCallback, // Callback function NULL // Optional context ); if (FAILED(hr)) { wprintf_s(L"\n WinBioCaptureSampleWithCallback failed. "); wprintf_s(L"hr = 0x%x\n", hr); goto e_Exit; } wprintf_s(L"\n Swipe the sensor ...\n"); // Cancel the identification if the bCancel flag is set. if (bCancel) { wprintf_s(L"\n Starting CANCEL timer..."); Sleep( 7000 ); wprintf_s(L"\n Calling WinBioCancel\n"); hr = WinBioCancel( sessionHandle ); if (FAILED(hr)) { wprintf_s(L"\n WinBioCancel failed. hr = 0x%x\n", hr); goto e_Exit; } } // Wait for the asynchronous identification process to complete // or be canceled. hr = WinBioWait( sessionHandle ); if (FAILED(hr)) { wprintf_s(L"\n WinBioWait failed. hr = 0x%x\n", hr); } e_Exit: if (sessionHandle != NULL) { WinBioCloseSession(sessionHandle); sessionHandle = NULL; } wprintf_s(L"\n Press any key to exit..."); _getch(); return hr; } //------------------------------------------------------------------------ // The following function is the callback for WinBioCaptureSampleWithCallback. // The function filters the response from the biometric subsystem and // writes a result to the console window. // VOID CALLBACK CaptureSampleCallback( __in_opt PVOID CaptureCallbackContext, __in HRESULT OperationStatus, __in WINBIO_UNIT_ID UnitId, __in_bcount(SampleSize) PWINBIO_BIR Sample, __in SIZE_T SampleSize, __in WINBIO_REJECT_DETAIL RejectDetail ) { UNREFERENCED_PARAMETER(CaptureCallbackContext); wprintf_s(L"\n CaptureSampleCallback executing"); wprintf_s(L"\n Swipe processed - Unit ID: %d", UnitId); if (FAILED(OperationStatus)) { if (OperationStatus == WINBIO_E_BAD_CAPTURE) { wprintf_s(L"\n Bad capture; reason: %d\n", RejectDetail); } else { wprintf_s(L"\n WinBioCaptureSampleWithCallback failed. "); wprintf_s(L" OperationStatus = 0x%x\n", OperationStatus); } goto e_Exit; } wprintf_s(L"\n Captured %d bytes.\n", SampleSize); e_Exit: if (Sample != NULL) { WinBioFree(Sample); Sample = NULL; } }</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbio/nf-winbio-winbiowait HRESULT WinBioWait( WINBIO_SESSION_HANDLE
	// SessionHandle );
	[DllImport(Lib_Winbio, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winbio.h", MSDNShortId = "NF:winbio.WinBioWait")]
	public static extern HRESULT WinBioWait(WINBIO_SESSION_HANDLE SessionHandle);

	private static HRESULT GetEnum<T>(EnumFunc f, WINBIO_BIOMETRIC_TYPE Factor, out T[] array)
	{
		var ret = f(Factor, out var a, out var c);
		array = ret.Succeeded ? a.DangerousGetHandle().ToArray<T>(c)! : new T[0];
		return ret;
	}

	/// <summary>The <c>WINBIO_ASYNC_RESULT</c> structure contains the results of an asynchronous operation.</summary>
	/// <remarks>
	/// <para>
	/// Asynchronous operations are begun by opening a biometric session or a framework session. Call WinBioAsyncOpenSession to open a
	/// biometric session. Call WinBioAsyncOpenFramework to open a framework session.
	/// </para>
	/// <para>You can use an asynchronous biometric session handle to call any of the following operations asynchronously:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>WinBioCancel</term>
	/// </item>
	/// <item>
	/// <term>WinBioCaptureSample</term>
	/// </item>
	/// <item>
	/// <term>WinBioCloseSession</term>
	/// </item>
	/// <item>
	/// <term>WinBioControlUnit</term>
	/// </item>
	/// <item>
	/// <term>WinBioControlUnitPrivileged</term>
	/// </item>
	/// <item>
	/// <term>WinBioDeleteTemplate</term>
	/// </item>
	/// <item>
	/// <term>WinBioEnrollBegin</term>
	/// </item>
	/// <item>
	/// <term>WinBioEnrollCapture</term>
	/// </item>
	/// <item>
	/// <term>WinBioEnrollCommit</term>
	/// </item>
	/// <item>
	/// <term>WinBioEnrollDiscard</term>
	/// </item>
	/// <item>
	/// <term>WinBioEnumEnrollments</term>
	/// </item>
	/// <item>
	/// <term>WinBioGetProperty</term>
	/// </item>
	/// <item>
	/// <term>WinBioIdentify</term>
	/// </item>
	/// <item>
	/// <term>WinBioLocateSensor</term>
	/// </item>
	/// <item>
	/// <term>WinBioLockUnit</term>
	/// </item>
	/// <item>
	/// <term>WinBioLogonIdentifiedUser</term>
	/// </item>
	/// <item>
	/// <term>WinBioRegisterEventMonitor</term>
	/// </item>
	/// <item>
	/// <term>WinBioUnlockUnit</term>
	/// </item>
	/// <item>
	/// <term>WinBioUnregisterEventMonitor</term>
	/// </item>
	/// <item>
	/// <term>WinBioVerify</term>
	/// </item>
	/// <item>
	/// <term>WinBioWait</term>
	/// </item>
	/// <item>
	/// <term>WinBioSetProperty</term>
	/// </item>
	/// <item>
	/// <term>WinBioEnrollSelect</term>
	/// </item>
	/// <item>
	/// <term>WinBioMonitorPresence</term>
	/// </item>
	/// </list>
	/// <para>You can use an asynchronous framework handle to call the following operations asynchronously:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>WinBioAsyncEnumBiometricUnits</term>
	/// </item>
	/// <item>
	/// <term>WinBioAsyncEnumDatabases</term>
	/// </item>
	/// <item>
	/// <term>WinBioAsyncOpenFramework</term>
	/// </item>
	/// <item>
	/// <term>WinBioAsyncEnumServiceProviders</term>
	/// </item>
	/// <item>
	/// <term>WinBioAsyncMonitorFrameworkChanges</term>
	/// </item>
	/// </list>
	/// <para>
	/// The <c>WINBIO_ASYNC_RESULT</c> structure is allocated internally by the Windows Biometric Framework. Therefore, when you are
	/// through using it, call WinBioFree to release the allocated memory and avoid leaks. Because this also releases all nested data
	/// structures, you should not keep a copy of any pointers returned in the <c>WINBIO_ASYNC_RESULT</c> structure. If you want to save
	/// any data returned in a nested structure, make a private copy of that data before calling <c>WinBioFree</c>.
	/// </para>
	/// <para>
	/// <c>Windows 8, Windows Server 2012, Windows 8.1 and Windows Server 2012 R2:</c> The Windows Biometric Framework supports only
	/// fingerprint readers. Therefore, if an operation fails and returns additional information in a <c>WINBIO_REJECT_DETAIL</c>
	/// constant, it will be one of the following values:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>WINBIO_FP_TOO_HIGH</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FP_TOO_LOW</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FP_TOO_LEFT</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FP_TOO_RIGHT</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FP_TOO_FAST</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FP_TOO_SLOW</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FP_POOR_QUALITY</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FP_TOO_SKEWED</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FP_TOO_SHORT</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_FP_MERGE_FAILURE</term>
	/// </item>
	/// </list>
	/// <para>Further, if an operation uses a <c>WINBIO_BIOMETRIC_SUBTYPE</c> data type, it will be one of the following values:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>WINBIO_ANSI_381_POS_UNKNOWN</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_ANSI_381_POS_RH_THUMB</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_ANSI_381_POS_RH_INDEX_FINGER</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_ANSI_381_POS_RH_MIDDLE_FINGER</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_ANSI_381_POS_RH_RING_FINGER</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_ANSI_381_POS_RH_LITTLE_FINGER</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_ANSI_381_POS_LH_THUMB</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_ANSI_381_POS_LH_INDEX_FINGER</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_ANSI_381_POS_LH_MIDDLE_FINGER</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_ANSI_381_POS_LH_RING_FINGER</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_ANSI_381_POS_LH_LITTLE_FINGER</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_ANSI_381_POS_RH_FOUR_FINGERS</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_ANSI_381_POS_LH_FOUR_FINGERS</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_ANSI_381_POS_TWO_THUMBS</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbio/ns-winbio-winbio_async_result typedef struct _WINBIO_ASYNC_RESULT {
	// WINBIO_SESSION_HANDLE SessionHandle; WINBIO_OPERATION_TYPE Operation; ULONGLONG SequenceNumber; LONGLONG TimeStamp; HRESULT
	// ApiStatus; WINBIO_UNIT_ID UnitId; PVOID UserData; union { struct { BOOLEAN Match; WINBIO_REJECT_DETAIL RejectDetail; } Verify;
	// struct { WINBIO_IDENTITY Identity; WINBIO_BIOMETRIC_SUBTYPE SubFactor; WINBIO_REJECT_DETAIL RejectDetail; } Identify; struct {
	// WINBIO_BIOMETRIC_SUBTYPE SubFactor; } EnrollBegin; struct { WINBIO_REJECT_DETAIL RejectDetail; } EnrollCapture; struct {
	// WINBIO_IDENTITY Identity; BOOLEAN IsNewTemplate; } EnrollCommit; struct { WINBIO_IDENTITY Identity; SIZE_T SubFactorCount;
	// WINBIO_BIOMETRIC_SUBTYPE *SubFactorArray; } EnumEnrollments; struct { PWINBIO_BIR Sample; SIZE_T SampleSize; WINBIO_REJECT_DETAIL
	// RejectDetail; } CaptureSample; struct { WINBIO_IDENTITY Identity; WINBIO_BIOMETRIC_SUBTYPE SubFactor; } DeleteTemplate; struct {
	// WINBIO_PROPERTY_TYPE PropertyType; WINBIO_PROPERTY_ID PropertyId; WINBIO_IDENTITY Identity; WINBIO_BIOMETRIC_SUBTYPE SubFactor;
	// SIZE_T PropertyBufferSize; PVOID PropertyBuffer; } GetProperty; struct { WINBIO_PROPERTY_TYPE PropertyType; WINBIO_PROPERTY_ID
	// PropertyId; WINBIO_IDENTITY Identity; WINBIO_BIOMETRIC_SUBTYPE SubFactor; SIZE_T PropertyBufferSize; PVOID PropertyBuffer; }
	// SetProperty; struct { WINBIO_EVENT Event; } GetEvent; struct { WINBIO_COMPONENT Component; ULONG ControlCode; ULONG
	// OperationStatus; PUCHAR SendBuffer; SIZE_T SendBufferSize; PUCHAR ReceiveBuffer; SIZE_T ReceiveBufferSize; SIZE_T
	// ReceiveDataSize; } ControlUnit; struct { SIZE_T BspCount; WINBIO_BSP_SCHEMA *BspSchemaArray; } EnumServiceProviders; struct {
	// SIZE_T UnitCount; WINBIO_UNIT_SCHEMA *UnitSchemaArray; } EnumBiometricUnits; struct { SIZE_T StorageCount; WINBIO_STORAGE_SCHEMA
	// *StorageSchemaArray; } EnumDatabases; struct { BOOLEAN Match; WINBIO_REJECT_DETAIL RejectDetail; WINBIO_PROTECTION_TICKET Ticket;
	// } VerifyAndReleaseTicket; struct { WINBIO_IDENTITY Identity; WINBIO_BIOMETRIC_SUBTYPE SubFactor; WINBIO_REJECT_DETAIL
	// RejectDetail; WINBIO_PROTECTION_TICKET Ticket; } IdentifyAndReleaseTicket; struct { ULONGLONG SelectorValue; } EnrollSelect;
	// struct { WINBIO_PRESENCE_CHANGE ChangeType; SIZE_T PresenceCount; WINBIO_PRESENCE *PresenceArray; } MonitorPresence; struct {
	// WINBIO_IDENTITY Identity; WINBIO_PROTECTION_POLICY Policy; } GetProtectionPolicy; struct { WINBIO_EXTENDED_UNIT_STATUS
	// ExtendedStatus; } NotifyUnitStatusChange; } Parameters; } WINBIO_ASYNC_RESULT, *PWINBIO_ASYNC_RESULT;
	[PInvokeData("winbio.h", MSDNShortId = "NS:winbio._WINBIO_ASYNC_RESULT")]
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct WINBIO_ASYNC_RESULT
	{
		/// <summary>
		/// Handle of an asynchronous session started by calling the WinBioAsyncOpenSession function or the WinBioAsyncOpenFramework function.
		/// </summary>
		public uint SessionHandle;

		/// <summary>Type of the asynchronous operation. For more information, see WINBIO_OPERATION_TYPE Constants.</summary>
		public WINBIO_OPERATION_TYPE Operation;

		/// <summary>
		/// Sequence number of the asynchronous operation. The integers are assigned sequentially for each operation in a biometric
		/// session, starting at one (1). For any session, the open operation is always assigned the first sequence number and the close
		/// operation is assigned the last sequence number. If your application queues multiple operations, you can use sequence numbers
		/// to perform error handling. For example, you can ignore operation results until a specific sequence number is sent to the application.
		/// </summary>
		public ulong SequenceNumber;

		/// <summary>
		/// System date and time at which the biometric operation began. For more information, see the <c>GetSystemTimeAsFileTime</c> function.
		/// </summary>
		public long TimeStamp;

		/// <summary>Error code returned by the operation.</summary>
		public HRESULT ApiStatus;

		/// <summary>The numeric unit identifier of the biometric unit that performed the operation.</summary>
		public uint UnitId;

		/// <summary>
		/// Address of an optional buffer supplied by the caller. The buffer is not modified by the framework or the biometric unit.
		/// Your application can use the data to help it determine what actions to perform upon receipt of the completion notice or to
		/// maintain additional information about the requested operation.
		/// </summary>
		public IntPtr UserData;

		private readonly uint pad1;

		/// <summary>
		/// Union that encloses nested structures that contain additional information about the success or failure of asynchronous
		/// operations begun by the client application.
		/// </summary>
		public PARAMETERS Parameters;

		/// <summary>
		/// Union that encloses nested structures that contain additional information about the success or failure of asynchronous
		/// operations begun by the client application.
		/// </summary>
		[StructLayout(LayoutKind.Explicit)]
		public struct PARAMETERS
		{
			/// <summary>Contains the results of an asynchronous call to WinBioVerify.</summary>
			[FieldOffset(0)]
			public VERIFY Verify;

			/// <summary>Contains the results of an asynchronous call to WinBioVerify.</summary>
			[StructLayout(LayoutKind.Sequential, Pack = 4)]
			public struct VERIFY
			{
				/// <summary>Specifies whether the captured sample matched the user identity.</summary>
				[MarshalAs(UnmanagedType.U1)]
				public bool Match;

				/// <summary>Additional information about verification failure. For more information, see Remarks.</summary>
				public WINBIO_REJECT_DETAIL RejectDetail;
			}

			/// <summary>Contains the results of an asynchronous call to WinBioIdentify.</summary>
			[FieldOffset(0)]
			public IDENTIFY Identify;

			/// <summary>Contains the results of an asynchronous call to WinBioIdentify.</summary>
			[StructLayout(LayoutKind.Sequential, Pack = 4)]
			public struct IDENTIFY
			{
				/// <summary>GUID or SID of the user providing the biometric sample.</summary>
				public WINBIO_IDENTITY Identity;

				/// <summary>Sub-factor associated with the biometric sample. For more information, see Remarks.</summary>
				public WINBIO_BIOMETRIC_SUBTYPE SubFactor;

				/// <summary>
				/// Additional information about the failure, if any, to capture and identify a biometric sample. For more information,
				/// see Remarks.
				/// </summary>
				public WINBIO_REJECT_DETAIL RejectDetail;
			}

			/// <summary>Contains the results of an asynchronous call to WinBioEnrollBegin.</summary>
			[FieldOffset(0)]
			public ENROLLBEGIN EnrollBegin;

			/// <summary>Contains the results of an asynchronous call to WinBioEnrollBegin.</summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct ENROLLBEGIN
			{
				/// <summary>Additional information about the enrollment. For more information, see Remarks.</summary>
				public WINBIO_BIOMETRIC_SUBTYPE SubFactor;
			}

			/// <summary>Contains the results of an asynchronous call to WinBioEnrollCapture.</summary>
			[FieldOffset(0)]
			public ENROLLCAPTURE EnrollCapture;

			/// <summary>Contains the results of an asynchronous call to WinBioEnrollCapture.</summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct ENROLLCAPTURE
			{
				/// <summary>Additional information about the failure to capture a biometric sample. For more information, see Remarks.</summary>
				public WINBIO_REJECT_DETAIL RejectDetail;
			}

			/// <summary>Contains the results of an asynchronous call to WinBioEnrollCommit.</summary>
			[FieldOffset(0)]
			public ENROLLCOMMIT EnrollCommit;

			/// <summary>Contains the results of an asynchronous call to WinBioEnrollCommit.</summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct ENROLLCOMMIT
			{
				/// <summary>GUID or SID of the template to be saved.</summary>
				public WINBIO_IDENTITY Identity;

				/// <summary>Specifies whether the template being added to the database is new.</summary>
				[MarshalAs(UnmanagedType.U1)]
				public bool IsNewTemplate;
			}

			/// <summary>Contains the results of an asynchronous call to WinBioEnumEnrollments.</summary>
			[FieldOffset(0)]
			public ENUMENROLLMENTS EnumEnrollments;

			/// <summary>Contains the results of an asynchronous call to WinBioEnumEnrollments.</summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct ENUMENROLLMENTS
			{
				/// <summary>GUID or SID of the template from which the sub-factors were retrieved.</summary>
				public WINBIO_IDENTITY Identity;

				/// <summary>Number of elements in the array pointed to by the <c>SubFactorArray</c> member.</summary>
				public SIZE_T SubFactorCount;

				/// <summary>Pointer to an array of sub-factors. For more information, see Remarks.</summary>
				public IntPtr _SubFactorArray;

				/// <summary>Pointer to an array of sub-factors. For more information, see Remarks.</summary>
				public WINBIO_BIOMETRIC_SUBTYPE[] SubFactorArray => _SubFactorArray.ToArray<WINBIO_BIOMETRIC_SUBTYPE>(SubFactorCount) ?? new WINBIO_BIOMETRIC_SUBTYPE[0];
			}

			/// <summary>Contains the results of an asynchronous call to WinBioCaptureSample.</summary>
			[FieldOffset(0)]
			public CAPTURESAMPLE CaptureSample;

			/// <summary>Contains the results of an asynchronous call to WinBioCaptureSample.</summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct CAPTURESAMPLE
			{
				/// <summary>Pointer to a WINBIO_BIR structure that contains the sample.</summary>
				public IntPtr Sample;

				/// <summary>Size, in bytes, of the WINBIO_BIR structure returned in the <c>Sample</c> member.</summary>
				public SIZE_T SampleSize;

				/// <summary>Additional information about the failure to capture a biometric sample. For more information, see Remarks.</summary>
				public WINBIO_REJECT_DETAIL RejectDetail;
			}

			/// <summary>Contains the results of an asynchronous call to WinBioDeleteTemplate.</summary>
			[FieldOffset(0)]
			public DELETETEMPLATE DeleteTemplate;

			/// <summary>Contains the results of an asynchronous call to WinBioDeleteTemplate.</summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct DELETETEMPLATE
			{
				/// <summary>GUID or SID of the template that was deleted.</summary>
				public WINBIO_IDENTITY Identity;

				/// <summary>Additional information about the template.</summary>
				public WINBIO_BIOMETRIC_SUBTYPE SubFactor;
			}

			/// <summary>Contains the results of an asynchronous call to WinBioGetProperty.</summary>
			[FieldOffset(0)]
			public GETPROPERTY GetProperty;

			/// <summary>Contains the results of an asynchronous call to WinBioGetProperty.</summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct GETPROPERTY
			{
				/// <summary>Source of the property information. Currently this will be <c>WINBIO_PROPERTY_TYPE_UNIT</c>.</summary>
				public WINBIO_PROPERTY_TYPE PropertyType;

				/// <summary>The property that was queried. Currently this will be <c>WINBIO_PROPERTY_SAMPLE_HINT</c>.</summary>
				public WINBIO_PROPERTY_ID PropertyId;

				/// <summary>This is a reserved value and will be <c>NULL</c>.</summary>
				public WINBIO_IDENTITY Identity;

				/// <summary>This is reserved and will be <c>WINBIO_SUBTYPE_NO_INFORMATION</c>.</summary>
				public WINBIO_BIOMETRIC_SUBTYPE SubFactor;

				/// <summary>Size, in bytes, of the property value pointed to by the <c>PropertyBuffer</c> member.</summary>
				public SIZE_T PropertyBufferSize;

				/// <summary>Pointer to the property value.</summary>
				public IntPtr PropertyBuffer;
			}

			/// <summary>
			/// <para>
			/// Contains the results of an asynchronous call to WinBioSetProperty. This member is supported starting in Windows 10.
			/// </para>
			/// <para>SetProperty.PropretyBufferSize</para>
			/// <para>The size, in bytes, of the structure to which the PropertyBuffer parameter points.</para>
			/// </summary>
			[FieldOffset(0)]
			public SETPROPERTY SetProperty;

			/// <summary>
			/// <para>
			/// Contains the results of an asynchronous call to WinBioSetProperty. This member is supported starting in Windows 10.
			/// </para>
			/// <para>SetProperty.PropretyBufferSize</para>
			/// <para>The size, in bytes, of the structure to which the PropertyBuffer parameter points.</para>
			/// </summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct SETPROPERTY
			{
				/// <summary>
				/// A <c>WINBIO_PROPERTY_TYPE</c> value that specifies the type of the property that was set. Currently this can only be <c>WINBIO_PROPERTY_TYPE_ACCOUNT</c>.
				/// </summary>
				public WINBIO_PROPERTY_TYPE PropertyType;

				/// <summary>
				/// A <c>WINBIO_PROPERTY_ID</c> value that specifies the property that was set. Currently this value can only be
				/// <c>WINBIO_PROPERTY_ANTI_SPOOF_POLICY</c>. All other properties are read-only.
				/// </summary>
				public WINBIO_PROPERTY_ID PropertyId;

				/// <summary>A WINBIO_IDENTITY structure that specifies the account for which the property was set.</summary>
				public WINBIO_IDENTITY Identity;

				/// <summary>Reserved. Currently, this value will always be <c>WINBIO_SUBTYPE_NO_INFORMATION</c>.</summary>
				public WINBIO_BIOMETRIC_SUBTYPE SubFactor;

				/// <summary/>
				public SIZE_T PropertyBufferSize;

				/// <summary>
				/// A pointer to a structure that specifies the value to which the property was set. For the
				/// <c>WINBIO_PROPERTY_ANTI_SPOOF_POLICY</c> property, the structure is a WINBIO_ANTI_SPOOF_POLICY structure.
				/// </summary>
				public IntPtr PropertyBuffer;
			}

			/// <summary>Contains status information about the event that was raised.</summary>
			[FieldOffset(0)]
			public GETEVENT GetEvent;

			/// <summary>Contains status information about the event that was raised.</summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct GETEVENT
			{
				/// <summary>Contains event information.</summary>
				public WINBIO_EVENT Event;
			}

			/// <summary>Contains the results of an asynchronous call to WinBioControlUnit or WinBioControlUnitPrivileged.</summary>
			[FieldOffset(0)]
			public CONTROLUNIT ControlUnit;

			/// <summary>Contains the results of an asynchronous call to WinBioControlUnit or WinBioControlUnitPrivileged.</summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct CONTROLUNIT
			{
				/// <summary>The component within the biometric unit that performed the operation.</summary>
				public WINBIO_COMPONENT Component;

				/// <summary>
				/// Vendor-defined code recognized by the biometric unit specified by the UnitId parameter of the WinBioControlUnit or
				/// WinBioControlUnitPrivileged function and the adapter specified by the Component parameter.
				/// </summary>
				public uint ControlCode;

				/// <summary>Vendor-defined status code that specifies the outcome of the control operation.</summary>
				public uint OperationStatus;

				/// <summary>
				/// Pointer to a buffer that contains the control information sent to the adapter by the component. The format and
				/// content of the buffer is vendor-defined.
				/// </summary>
				public IntPtr SendBuffer;

				/// <summary>Size, in bytes, of the buffer specified by the <c>SendBuffer</c> member.</summary>
				public SIZE_T SendBufferSize;

				/// <summary>
				/// Pointer to a buffer that receives information sent by the adapter specified by the <c>Component</c> member. The
				/// format and content of the buffer is vendor-defined.
				/// </summary>
				public IntPtr ReceiveBuffer;

				/// <summary>Size, in bytes, of the buffer specified by the <c>ReceiveBuffer</c> member.</summary>
				public SIZE_T ReceiveBufferSize;

				/// <summary>Size, in bytes, of the data written to the buffer specified by the <c>ReceiveBuffer</c> member.</summary>
				public SIZE_T ReceiveDataSize;
			}

			/// <summary>Contains the results of an asynchronous call to WinBioEnumServiceProviders or WinBioAsyncEnumServiceProviders.</summary>
			[FieldOffset(0)]
			public ENUMSERVICEPROVIDERS EnumServiceProviders;

			/// <summary>Contains the results of an asynchronous call to WinBioEnumServiceProviders or WinBioAsyncEnumServiceProviders.</summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct ENUMSERVICEPROVIDERS
			{
				/// <summary>The number of structures pointed to by the <c>BspSchemaArray</c> member.</summary>
				public SIZE_T BspCount;

				/// <summary>
				/// Pointer to an array of WINBIO_BSP_SCHEMA structures that contain information about each of the available service providers.
				/// </summary>
				public IntPtr _BspSchemaArray;

				/// <summary>
				/// An array of WINBIO_BSP_SCHEMA structures that contain information about each of the available service providers.
				/// </summary>
				public WINBIO_BSP_SCHEMA[] BspSchemaArray => _BspSchemaArray.ToArray<WINBIO_BSP_SCHEMA>(BspCount) ?? new WINBIO_BSP_SCHEMA[0];
			}

			/// <summary>Contains the results of an asynchronous call to WinBioEnumBiometricUnits or WinBioAsyncEnumBiometricUnits.</summary>
			[FieldOffset(0)]
			public ENUMBIOMETRICUNITS EnumBiometricUnits;

			/// <summary>Contains the results of an asynchronous call to WinBioEnumBiometricUnits or WinBioAsyncEnumBiometricUnits.</summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct ENUMBIOMETRICUNITS
			{
				/// <summary>Number of structures pointed to by the <c>UnitSchemaArray</c> member.</summary>
				public SIZE_T UnitCount;

				/// <summary>An array of WINBIO_UNIT_SCHEMA structures that contain information about each enumerated biometric unit.</summary>
				public IntPtr _UnitSchemaArray;

				/// <summary>An array of WINBIO_UNIT_SCHEMA structures that contain information about each enumerated biometric unit.</summary>
				public WINBIO_UNIT_SCHEMA[] UnitSchemaArray => _UnitSchemaArray.ToArray<WINBIO_UNIT_SCHEMA>(UnitCount) ?? new WINBIO_UNIT_SCHEMA[0];
			}

			/// <summary>Contains the results of an asynchronous call to WinBioEnumDatabases or WinBioAsyncEnumDatabases.</summary>
			[FieldOffset(0)]
			public ENUMDATABASES EnumDatabases;

			/// <summary>Contains the results of an asynchronous call to WinBioEnumDatabases or WinBioAsyncEnumDatabases.</summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct ENUMDATABASES
			{
				/// <summary>Number of structures pointed to by the <c>StorageSchemaArray</c> member.</summary>
				public SIZE_T StorageCount;

				/// <summary>Array of WINBIO_STORAGE_SCHEMA structures that contain information about each database.</summary>
				public IntPtr _StorageSchemaArray;

				/// <summary>Array of WINBIO_STORAGE_SCHEMA structures that contain information about each database.</summary>
				public WINBIO_STORAGE_SCHEMA[] StorageSchemaArray => _StorageSchemaArray.ToArray<WINBIO_STORAGE_SCHEMA>(StorageCount) ?? new WINBIO_STORAGE_SCHEMA[0];
			}

			/// <summary>Reserved. This member is supported starting in Windows 10.</summary>
			[FieldOffset(0)]
			public VERIFYANDRELEASETICKET VerifyAndReleaseTicket;

			/// <summary>Reserved. This member is supported starting in Windows 10.</summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct VERIFYANDRELEASETICKET
			{
				/// <summary>Reserved.</summary>
				[MarshalAs(UnmanagedType.U1)]
				public bool Match;

				/// <summary>Reserved.</summary>
				public WINBIO_REJECT_DETAIL RejectDetail;

				/// <summary>Reserved.</summary>
				public ulong Ticket;
			}

			/// <summary>Reserved. This member is supported starting in Windows 10.</summary>
			[FieldOffset(0)]
			public IDENTIFYANDRELEASETICKET IdentifyAndReleaseTicket;

			/// <summary>Reserved. This member is supported starting in Windows 10.</summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct IDENTIFYANDRELEASETICKET
			{
				/// <summary>Reserved.</summary>
				public WINBIO_IDENTITY Identity;

				/// <summary>Reserved.</summary>
				public WINBIO_BIOMETRIC_SUBTYPE SubFactor;

				/// <summary>Reserved.</summary>
				public WINBIO_REJECT_DETAIL RejectDetail;

				/// <summary>Reserved.</summary>
				public ulong Ticket;
			}

			/// <summary>
			/// Contains the results of an asynchronous call to WinBioEnrollSelect. This member is supported starting in Windows 10.
			/// </summary>
			[FieldOffset(0)]
			public ENROLLSELECT EnrollSelect;

			/// <summary>
			/// Contains the results of an asynchronous call to WinBioEnrollSelect. This member is supported starting in Windows 10.
			/// </summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct ENROLLSELECT
			{
				/// <summary>A value that identifies that individual that was selected for enrollment.</summary>
				public ulong SelectorValue;
			}

			/// <summary>
			/// Contains the results of an asynchronous call to WinBioMonitorPresence. This member is supported starting in Windows 10.
			/// </summary>
			[FieldOffset(0)]
			public MONITORPRESENCE MonitorPresence;

			/// <summary>
			/// Contains the results of an asynchronous call to WinBioMonitorPresence. This member is supported starting in Windows 10.
			/// </summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct MONITORPRESENCE
			{
				/// <summary>A <c>WINBIO_PRESENCE_CHANGE</c> value that indicates the type of event that occurred.</summary>
				public WINBIO_PRESENCE_CHANGE ChangeType;

				/// <summary>The size of the array that the <c>MonitorPresence.PresenceArray</c> member points to.</summary>
				public SIZE_T PresenceCount;

				/// <summary>Address of the array of WINBIO_PRESENCE structures, one for each individual monitored.</summary>
				public IntPtr _PresenceArray;

				/// <summary>Address of the array of WINBIO_PRESENCE structures, one for each individual monitored.</summary>
				public WINBIO_PRESENCE[] PresenceArray => _PresenceArray.ToArray<WINBIO_PRESENCE>(PresenceCount) ?? new WINBIO_PRESENCE[0];
			}

			/// <summary/>
			[FieldOffset(0)]
			public GETPROTECTIONPOLICY GetProtectionPolicy;

			/// <summary/>
			[StructLayout(LayoutKind.Sequential)]
			public struct GETPROTECTIONPOLICY
			{
				/// <summary/>
				public WINBIO_IDENTITY Identity;

				/// <summary/>
				public WINBIO_PROTECTION_POLICY Policy;
			}

			/// <summary/>
			[FieldOffset(0)]
			public NOTIFYUNITSTATUSCHANGE NotifyUnitStatusChange;

			/// <summary/>
			[StructLayout(LayoutKind.Sequential)]
			public struct NOTIFYUNITSTATUSCHANGE
			{
				/// <summary/>
				public WINBIO_EXTENDED_UNIT_STATUS ExtendedStatus;
			}
		}
	}

	/// <summary>An unsigned long integer that contains the handle for an open framework session.</summary>
	[PInvokeData("winbio.h")]
	[DebuggerDisplay("{value}")]
	[StructLayout(LayoutKind.Sequential, Size = 4)]
	public struct WINBIO_FRAMEWORK_HANDLE
	{
		private readonly uint value;

		/// <summary>Performs an implicit conversion from <see cref="WINBIO_FRAMEWORK_HANDLE"/> to <see cref="System.UInt32"/>.</summary>
		/// <param name="handle">The handle.</param>
		/// <returns>The resulting <see cref="System.UInt32"/> instance from the conversion.</returns>
		public static implicit operator uint(WINBIO_FRAMEWORK_HANDLE handle) => handle.value;
	}

	/// <summary>An unsigned long integer that contains the handle for an open biometric session.</summary>
	[PInvokeData("winbio.h")]
	[DebuggerDisplay("{value}")]
	[StructLayout(LayoutKind.Sequential, Size = 4)]
	public struct WINBIO_SESSION_HANDLE
	{
		private readonly uint value;

		/// <summary>Performs an implicit conversion from <see cref="WINBIO_SESSION_HANDLE"/> to <see cref="System.UInt32"/>.</summary>
		/// <param name="handle">The handle.</param>
		/// <returns>The resulting <see cref="System.UInt32"/> instance from the conversion.</returns>
		public static implicit operator uint(WINBIO_SESSION_HANDLE handle) => handle.value;
	}

	/// <summary>A safe handle for memory allocated by WinBio methods and freed using <see cref="WinBioFree"/>.</summary>
	/// <seealso cref="SafeHANDLE"/>
	[AutoSafeHandle("WinBioFree(handle).Succeeded")]
	public partial class SafeWinBioMemory
	{
		/// <summary>
		/// Marshals data from an unmanaged block of memory to a newly allocated managed object of the type specified by a generic type parameter.
		/// </summary>
		/// <typeparam name="T">The type of the object to which the data is to be copied. This must be a structure.</typeparam>
		/// <param name="allocatedBytes">If known, the total number of bytes allocated to the native memory in this handle.</param>
		/// <param name="offset">The number of bytes to skip before reading the element.</param>
		/// <returns>A managed object that contains the data pointed to by this safe handle.</returns>
		public T ToStructure<T>(SIZE_T allocatedBytes, uint offset = 0) where T : struct => handle.ToStructure<T>(allocatedBytes, (int)offset);
	}

	/// <summary>A structure handler based on unmanaged memory allocated by AllocCoTaskMem.</summary>
	/// <typeparam name="TStruct">The type of the structure.</typeparam>
	/// <seealso cref="SafeMemStruct{TStruct, TMem}"/>
	public class SafeWinBioStruct<TStruct> : SafeMemStruct<TStruct, WinBioMemoryMethods> where TStruct : struct
	{
		/// <summary>Represents the <see langword="null"/> equivalent of this class instances.</summary>
		public static readonly SafeWinBioStruct<TStruct> Null = new(IntPtr.Zero, false);

		/// <summary>Initializes a new instance of the <see cref="SafeWinBioStruct{TStruct}"/> class.</summary>
		/// <param name="s">The TStruct value.</param>
		/// <param name="capacity">The capacity of the buffer, in bytes.</param>
		public SafeWinBioStruct(in TStruct s, SIZE_T capacity = default) : base(s, capacity) { }

		/// <summary>Initializes a new instance of the <see cref="SafeWinBioStruct{TStruct}"/> class.</summary>
		/// <param name="capacity">The capacity of the buffer, in bytes.</param>
		public SafeWinBioStruct(SIZE_T capacity = default) : base(capacity) { }

		/// <summary>Initializes a new instance of the <see cref="SafeWinBioStruct{TStruct}"/> class.</summary>
		/// <param name="ptr">The PTR.</param>
		/// <param name="ownsHandle"><c>true</c> to reliably release the handle during finalization; <c>false</c> to prevent it.</param>
		/// <param name="allocatedBytes">The number of bytes allocated to <paramref name="ptr"/>.</param>
		[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
		public SafeWinBioStruct(IntPtr ptr, bool ownsHandle = true, SIZE_T allocatedBytes = default) : base(ptr, ownsHandle, allocatedBytes) { }
		/// <summary>Performs an implicit conversion from <see cref="Nullable{TStruct}"/> to <see cref="SafeCoTaskMemStruct{TStruct}"/>.</summary>
		/// <param name="s">The value of the <typeparamref name="TStruct"/> instance or <see langword="null"/>.</param>
		/// <returns>The resulting <see cref="SafeWinBioStruct{TStruct}"/> instance from the conversion.</returns>
		public static implicit operator SafeWinBioStruct<TStruct>(TStruct? s) => s.HasValue ? new SafeWinBioStruct<TStruct>(s.Value) : new SafeWinBioStruct<TStruct>(IntPtr.Zero);
	}

	/// <summary>Internal use only.</summary>
	/// <seealso cref="MemoryMethodsBase"/>
	public sealed class WinBioMemoryMethods : MemoryMethodsBase
	{
		/// <summary>Gets a handle to a memory allocation of the specified size.</summary>
		/// <param name="size">The size, in bytes, of memory to allocate.</param>
		/// <returns>A memory handle.</returns>
		/// <exception cref="NotImplementedException"></exception>
		public override IntPtr AllocMem(int size) => throw new NotImplementedException();
		/// <summary>Frees the memory associated with a handle.</summary>
		/// <param name="hMem">A memory handle.</param>
		public override void FreeMem(IntPtr hMem) => WinBioFree(hMem);
	}
}