using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Shell32
	{
		/// <summary>Flags used in IOperationsProgressDialog::StartProgressDialog</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-ioperationsprogressdialog-startprogressdialog
		[PInvokeData("shobjidl_core.h", MSDNShortId = "5d6f44e0-259f-42d3-9912-877d90f0e7fc")]
		[Flags]
		public enum OPPROGDLGF
		{
			/// <summary>Default operation.</summary>
			OPPROGDLG_DEFAULT = 0x00000000,

			/// <summary>Add a pause button (operation can be paused)</summary>
			OPPROGDLG_ENABLEPAUSE = 0x00000080,

			/// <summary>The operation can be undone in the dialog. (The Stop button becomes Undo)</summary>
			OPPROGDLG_ALLOWUNDO = 0x00000100,

			/// <summary>Don't display the path of source file in progress dialog</summary>
			OPPROGDLG_DONTDISPLAYSOURCEPATH = 0x00000200,

			/// <summary>Don't display the path of destination file in progress dialog</summary>
			OPPROGDLG_DONTDISPLAYDESTPATH = 0x00000400,

			/// <summary>deprecated - progress dialog no longer displays &gt; 1 day estimates</summary>
			OPPROGDLG_NOMULTIDAYESTIMATES = 0x00000800,

			/// <summary>Don't display the location line in the progress dialog</summary>
			OPPROGDLG_DONTDISPLAYLOCATIONS = 0x00001000,
		}

		/// <summary>Flags used in IOperationsProgressDialog::SetMode</summary>
		[PInvokeData("shobjidl_core.h")]
		[Flags]
		public enum PDMODE
		{
			/// <summary>0x00000000. Use the default progress dialog operations mode.</summary>
			PDM_DEFAULT = 0x00000000,

			/// <summary>0x00000001. The operation is running.</summary>
			PDM_RUN = 0x00000001,

			/// <summary>0x00000002. The operation is gathering data before it begins, such as calculating the predicted operation time.</summary>
			PDM_PREFLIGHT = 0x00000002,

			/// <summary>0x00000004. The operation is rolling back due to an Undo command from the user.</summary>
			PDM_UNDOING = 0x00000004,

			/// <summary>0x00000008. Error dialogs are blocking progress from continuing.</summary>
			PDM_ERRORSBLOCKING = 0x00000008,

			/// <summary>
			/// 0x00000010. The length of the operation is indeterminate. Do not show a timer and display the progress bar in marquee mode.
			/// </summary>
			PDM_INDETERMINATE = 0x00000010,
		}

		/// <summary>Provides operation status flags for IOperationsProgressDialog::GetOperationStatus</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/ne-shobjidl_core-pdopstatus typedef enum PDOPSTATUS {
		// PDOPS_RUNNING , PDOPS_PAUSED , PDOPS_CANCELLED , PDOPS_STOPPED , PDOPS_ERRORS } ;
		[PInvokeData("shobjidl_core.h", MSDNShortId = "f9fd5cbe-2cb7-4ae7-9cf2-f8545095eec8")]
		public enum PDOPSTATUS
		{
			/// <summary>Operation is running, no user intervention.</summary>
			PDOPS_RUNNING = 1,

			/// <summary>Operation has been paused by the user.</summary>
			PDOPS_PAUSED = 2,

			/// <summary>Operation has been canceled by the user - now go undo.</summary>
			PDOPS_CANCELLED = 3,

			/// <summary>Operation has been stopped by the user - terminate completely.</summary>
			PDOPS_STOPPED = 4,

			/// <summary>Operation has gone as far as it can go without throwing error dialogs.</summary>
			PDOPS_ERRORS = 5,
		}

		/// <summary>
		/// <para>Describes an action being performed that requires progress to be shown to the user using an IActionProgress interface.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/ne-shobjidl_core-_spaction
		[PInvokeData("shobjidl_core.h", MSDNShortId = "fc5a0f96-e8c2-483f-86b0-d8c870a9f77a")]
		public enum SPACTION
		{
			/// <summary>No action is being performed.</summary>
			SPACTION_NONE,

			/// <summary>Files are being moved.</summary>
			SPACTION_MOVING,

			/// <summary>Files are being copied.</summary>
			SPACTION_COPYING,

			/// <summary>Files are being deleted.</summary>
			SPACTION_RECYCLING,

			/// <summary>A set of attributes are being applied to files.</summary>
			SPACTION_APPLYINGATTRIBS,

			/// <summary>A file is being downloaded from a remote source.</summary>
			SPACTION_DOWNLOADING,

			/// <summary>An Internet search is being performed.</summary>
			SPACTION_SEARCHING_INTERNET,

			/// <summary>A calculation is being performed.</summary>
			SPACTION_CALCULATING,

			/// <summary>A file is being uploaded to a remote source.</summary>
			SPACTION_UPLOADING,

			/// <summary>A local search is being performed.</summary>
			SPACTION_SEARCHING_FILES,

			/// <summary>Windows Vista and later. A deletion is being performed.</summary>
			SPACTION_DELETING,

			/// <summary>Windows Vista and later. A renaming action is being performed.</summary>
			SPACTION_RENAMING,

			/// <summary>Windows Vista and later. A formatting action is being performed.</summary>
			SPACTION_FORMATTING,

			/// <summary>Windows 7 and later. A copy or move action is being performed.</summary>
			SPACTION_COPY_MOVING,
		}

		/// <summary>
		/// <para>Exposes methods for posting a cancel window message to the process thread from the Progress Dialog.</para>
		/// <para>
		/// This interface enables the progress dialog to post a thread message through PostThreadMessage to the worker thread to cancel its
		/// operations. The worker thread must periodically check the message queue through GetMessage, PeekMessage or MsgWaitForMultipleObjectsEx.
		/// </para>
		/// <para>
		/// The IIOCancelInformation::SetCancelInformation method tells the progress dialog which thread ID and what message to
		/// PostThreadMessage when the user clicks <c>Cancel</c>. A thread ID of "zero" disables the sending operation for the cancel message.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-iiocancelinformation
		[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.IIOCancelInformation")]
		[ComImport, Guid("f5b0bf81-8cb5-4b1b-9449-1a159e0c733c"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IIOCancelInformation
		{
			/// <summary>
			/// Sets information that is posted when a user selects <c>Cancel</c> from the progress UI. Allows the main object to tell the
			/// progress dialog thread about the process thread so that the progress dialog can send the process thread the message id when
			/// the user clicks <c>Cancel</c>.
			/// </summary>
			/// <param name="dwThreadID">
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The ID of the process thread to be canceled.</para>
			/// </param>
			/// <param name="uMsgCancel">
			/// <para>Type: <c>UINT</c></para>
			/// <para>The cancel message to be posted to the thread.</para>
			/// </param>
			/// <remarks>
			/// When the user selects <c>Cancel</c> from the progress UI, the dwThreadID will cancel any pending or future input/output
			/// (I/O) requests. Also the uMsgCancel message, received from the progress dialog, will be posted to the thread to tell it to
			/// exit a wait state, if asynchronous I/O is pending.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iiocancelinformation-setcancelinformation
			// HRESULT SetCancelInformation( DWORD dwThreadID, UINT uMsgCancel );
			void SetCancelInformation(uint dwThreadID, uint uMsgCancel);

			/// <summary>
			/// Returns information that is posted when a user selects <c>Cancel</c> from the progress UI. The process thread uses this
			/// method to find out which message the progress dialog will send to the process thread when the user hits cancel. The process
			/// thread then listens for this message and does its own cleanup upon receipt.
			/// </summary>
			/// <param name="pdwThreadID">
			/// <para>Type: <c>DWORD*</c></para>
			/// <para>When this method returns, contains a pointer to the ID of the process thread.</para>
			/// </param>
			/// <param name="puMsgCancel">
			/// <para>Type: <c>UINT*</c></para>
			/// <para>
			/// When this method returns, contains a pointer to uMsgCancel that the process thread should post if the operation is canceled.
			/// </para>
			/// </param>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iiocancelinformation-getcancelinformation
			// HRESULT GetCancelInformation( DWORD *pdwThreadID, UINT *puMsgCancel );
			void GetCancelInformation(out uint pdwThreadID, out uint puMsgCancel);
		}

		/// <summary>Exposes methods to get, set, and query a progress dialog.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nn-shobjidl_core-ioperationsprogressdialog
		[PInvokeData("shobjidl_core.h", MSDNShortId = "0d95f407-0e09-441d-b9e2-665995ea1362")]
		[ComImport, Guid("0C9FB851-E5C9-43EB-A370-F0677B13874C"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(ProgressDialog))]
		public interface IOperationsProgressDialog
		{
			/// <summary>
			/// <para>Starts the specified progress dialog.</para>
			/// </summary>
			/// <param name="hwndOwner">
			/// <para>Type: <c>HWND</c></para>
			/// <para>A handle to the parent window.</para>
			/// </param>
			/// <param name="flags"/>
			/// <remarks>
			/// <para>
			/// The progress dialog should be created on a separate thread than the file operation on which the dialog is reporting. If the
			/// dialog is running in the same thread as the file operation, progress messages are, at best, only sent as resources allow.
			/// Progress messages on the same thread as the file operation might not be sent at all.
			/// </para>
			/// <para>
			/// Once <c>IOperationsProgressDialog::StartProgressDialog</c> is called, that instance of the <c>CLSID_ProgressDialog</c>
			/// object cannot be accessed by <see cref="IProgressDialog"/>, <see cref="IActionProgressDialog"/>, or
			/// <see cref="IActionProgress"/>. Although QueryInterface can be used to access these interfaces, most of their methods cannot be
			/// invoked. IOperationsProgressDialog is the interface used to display the new progress dialog for the Windows Vista and later
			/// operations engine.
			/// </para>
			/// </remarks>
			void StartProgressDialog([In] HWND hwndOwner, [In] OPPROGDLGF flags);

			/// <summary>Stops current progress dialog.</summary>
			void StopProgressDialog();

			/// <summary>
			/// <para>Sets which progress dialog operation is occurring, and whether we are in pre-flight or undo mode.</para>
			/// </summary>
			/// <param name="action">
			/// <para>Type: <c>SPACTION</c></para>
			/// <para>Specifies operation. See SPACTION.</para>
			/// </param>
			void SetOperation([In] SPACTION action);

			/// <summary>
			/// <para>Sets progress dialog operations mode.</para>
			/// </summary>
			/// <param name="mode">
			/// <para>Type: <c>PDMODE</c></para>
			/// <para>Specifies the operation mode. The following are valid values.</para>
			/// <para>PDM_DEFAULT</para>
			/// <para>0x00000000. Use the default progress dialog operations mode.</para>
			/// <para>PDM_RUN</para>
			/// <para>0x00000001. The operation is running.</para>
			/// <para>PDM_PREFLIGHT</para>
			/// <para>0x00000002. The operation is gathering data before it begins, such as calculating the predicted operation time.</para>
			/// <para>PDM_UNDOING</para>
			/// <para>0x00000004. The operation is rolling back due to an Undo command from the user.</para>
			/// <para>PDM_ERRORSBLOCKING</para>
			/// <para>0x00000008. Error dialogs are blocking progress from continuing.</para>
			/// <para>PDM_INDETERMINATE</para>
			/// <para>
			/// 0x00000010. The length of the operation is indeterminate. Do not show a timer and display the progress bar in marquee mode.
			/// </para>
			/// </param>
			void SetMode([In] PDMODE mode);

			/// <summary>
			/// <para>Updates the current progress dialog, as specified.</para>
			/// </summary>
			/// <param name="ullPointsCurrent">
			/// <para>Type: <c>ULONGLONG</c></para>
			/// <para>Current points, used for showing progress in points.</para>
			/// </param>
			/// <param name="ullPointsTotal">
			/// <para>Type: <c>ULONGLONG</c></para>
			/// <para>Total points, used for showing progress in points.</para>
			/// </param>
			/// <param name="ullSizeCurrent">
			/// <para>Type: <c>ULONGLONG</c></para>
			/// <para>Current size in bytes, used for showing progress in bytes.</para>
			/// </param>
			/// <param name="ullSizeTotal">
			/// <para>Type: <c>ULONGLONG</c></para>
			/// <para>Total size in bytes, used for showing progress in bytes.</para>
			/// </param>
			/// <param name="ullItemsCurrent">
			/// <para>Type: <c>ULONGLONG</c></para>
			/// <para>Current items, used for showing progress in items.</para>
			/// </param>
			/// <param name="ullItemsTotal">
			/// <para>Type: <c>ULONGLONG</c></para>
			/// <para>Specifies total items, used for showing progress in items.</para>
			/// </param>
			void UpdateProgress(ulong ullPointsCurrent, ulong ullPointsTotal, ulong ullSizeCurrent, ulong ullSizeTotal, ulong ullItemsCurrent,
				ulong ullItemsTotal);

			/// <summary>
			/// <para>Called to specify the text elements stating the source and target in the current progress dialog.</para>
			/// </summary>
			/// <param name="psiSource">
			/// <para>Type: <c>IShellItem*</c></para>
			/// <para>A pointer to an IShellItem that represents the source Shell item.</para>
			/// </param>
			/// <param name="psiTarget">
			/// <para>Type: <c>IShellItem*</c></para>
			/// <para>A pointer to an IShellItem that represents the target Shell item.</para>
			/// </param>
			/// <param name="psiItem">
			/// <para>Type: <c>IShellItem*</c></para>
			/// <para>
			/// A pointer to an IShellItem that represents the item currently being operated on by the operation engine. This parameter is
			/// only used in Windows 7 and later. In earlier versions, this parameter should be <c>NULL</c>.
			/// </para>
			/// </param>
			void UpdateLocations([In] IShellItem psiSource, [In] IShellItem psiTarget, [In, Optional] IShellItem psiItem);

			/// <summary>
			/// <para>Resets progress dialog timer to 0.</para>
			/// </summary>
			void ResetTimer();

			/// <summary>
			/// <para>Pauses progress dialog timer.</para>
			/// </summary>
			void PauseTimer();

			/// <summary>
			/// <para>Resumes progress dialog timer.</para>
			/// </summary>
			void ResumeTimer();

			/// <summary>Gets elapsed and remaining time for progress dialog.</summary>
			/// <param name="pullElapsed">
			/// <para>Type: <c>ULONGLONG*</c></para>
			/// <para>A pointer to the elapsed time in milliseconds.</para>
			/// </param>
			/// <param name="pullRemaining">
			/// <para>Type: <c>ULONGLONG*</c></para>
			/// <para>A pointer to the remaining time in milliseconds.</para>
			/// </param>
			void GetMilliseconds(out ulong pullElapsed, out ulong pullRemaining);

			/// <summary>
			/// <para>Gets operation status for progress dialog.</para>
			/// </summary>
			/// <returns>
			/// <para>Type: <c>PDOPSTATUS*</c></para>
			/// <para>Contains pointer to the operation status. See PDOPSTATUS.</para>
			/// </returns>
			PDOPSTATUS GetOperationStatus();
		}
	}
}