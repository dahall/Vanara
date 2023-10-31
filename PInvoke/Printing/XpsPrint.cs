namespace Vanara.PInvoke;

/// <summary>XPS Print Api functions and interfaces.</summary>
public static partial class XpsPrint
{
	/// <summary>
	/// <para>[ <c>XPS_JOB_COMPLETION</c> is not supported and may be altered or unavailable in the future. ]</para>
	/// <para>Indicates the completion status of a print job.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsprint/ne-xpsprint-xps_job_completion typedef enum
	// __MIDL___MIDL_itf_xpsprint_0000_0000_0001 { XPS_JOB_IN_PROGRESS, XPS_JOB_COMPLETED, XPS_JOB_CANCELLED, XPS_JOB_FAILED } XPS_JOB_COMPLETION;
	[PInvokeData("xpsprint.h", MSDNShortId = "a0bfb708-033a-4493-a878-0ebdcaae672f")]
	public enum XPS_JOB_COMPLETION
	{
		/// <summary>The print job is running.</summary>
		XPS_JOB_IN_PROGRESS,

		/// <summary>The print job finished without an error.</summary>
		XPS_JOB_COMPLETED,

		/// <summary>
		/// The print job was cancelled by a call to IXpsPrintJob::Cancel, or cancelled while it was being processed by the print spooler.
		/// </summary>
		XPS_JOB_CANCELLED,

		/// <summary>The print job failed. The jobStatus member of XPS_JOB_STATUS contains the error code of the failure.</summary>
		XPS_JOB_FAILED
	}

	/// <summary>
	/// <para>[IXpsPrintJob is not supported and may be altered or unavailable in the future. ]</para>
	/// <para>Provides access to a print job that is currently in progress.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsprint/nn-xpsprint-ixpsprintjob
	[PInvokeData("xpsprint.h", MSDNShortId = "aa17e059-6208-4348-87f3-556a3818f2b9")]
	[ComImport, Guid("5ab89b06-8194-425f-ab3b-d7a96e350161"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IXpsPrintJob
	{
		/// <summary>
		/// [IXpsPrintJob::Cancel is not supported and may be altered or unavailable in the future.]
		/// <para>Cancels the print job.</para>
		/// </summary>
		/// <returns>If the method succeeds, it returns S_OK; otherwise, it returns an HRESULT error code.</returns>
		/// <remarks>
		/// Any spooling or printing that is in progress at the time this method is called will be canceled.
		/// <para>This function is thread-safe and synchronized with the job status of the print job object.</para>
		/// </remarks>
		[PreserveSig]
		HRESULT Cancel();

		/// <summary>
		/// [IXpsPrintJob::GetJobSatus is not supported and may be altered or unavailable in the future.]
		/// <para>Gets the current status of the print job.</para>
		/// </summary>
		/// <returns>
		/// The current status of the print job. For information about the data that is returned in this structure, see XPS_JOB_STATUS.
		/// </returns>
		/// <remarks>
		/// <para>
		/// GetJobStatus may be called during the print job processing or after the print job has completed. The values returned in
		/// XPS_JOB_STATUS represent the current state of the print job at the time GetJobStatus is called, so it is possible to miss
		/// intermediate states between calls to this method.
		/// </para>
		/// <para>
		/// The values of jobStatus.currentDocument and jobStatus.currentPage are guaranteed to progress sequentially: from the first
		/// document to the last, and from the first page to the last within each document.
		/// </para>
		/// <para>
		/// The job ID of a print job that has been sent to the Microsoft XPS Document Writer (MXDW) is zero. If the interface is that
		/// of a print job that has been sent to the MXDW, zero will be returned in jobStatus.jobId.
		/// </para>
		/// <para>
		/// If no job ID has been assigned to the print job, or the print job is printed without spooling, zero will be returned in jobStatus.jobId.
		/// </para>
		/// </remarks>
		XPS_JOB_STATUS GetJobStatus();
	}

	/// <summary>
	/// <para>[IXpsPrintJobStream is not supported and may be altered or unavailable in the future. ]</para>
	/// <para>A write-only stream interface into which an application writes print job data.</para>
	/// </summary>
	/// <remarks><c>Note</c> The Close method must be called before this interface is released.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsprint/nn-xpsprint-ixpsprintjobstream
	[PInvokeData("xpsprint.h", MSDNShortId = "a7855015-32db-48ff-8f8d-3d84d2843fde")]
	[ComImport, Guid("7a77dc5f-45d6-4dff-9307-d8cb846347ca"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IXpsPrintJobStream
	{
		/// <summary>
		/// [IXpsPrintJobStream::Close is not supported and may be altered or unavailable in the future.]
		/// <para>
		/// Closes the stream and indicates to the print job that the entire document has been written to the print queue by the application.
		/// </para>
		/// </summary>
		/// <returns>If the method succeeds, it returns S_OK; otherwise, it returns an HRESULT error code.</returns>
		[PreserveSig]
		HRESULT Close();
	}

	/// <summary>
	/// <para>[StartXpsPrintJob is not supported and may be altered or unavailable in the future. ]</para>
	/// <para>Starts printing an XPS document stream to a printer.</para>
	/// </summary>
	/// <param name="printerName">The name of the printer with which this job will be associated.</param>
	/// <param name="jobName">
	/// A user-specified job name to be associated with this job. If the job does not require a separate, user-specified name, this
	/// parameter can be set to <c>NULL</c>.
	/// </param>
	/// <param name="outputFileName">
	/// The file name of the file or port into which the output of this job is to be redirected. Setting this value will cause the
	/// output of the print job to be directed to the specified file or port. To send the print job to the printer that is specified by
	/// printerName, this parameter must be set to <c>NULL</c>.
	/// </param>
	/// <param name="progressEvent">
	/// <para>An event handle that is signaled when the following print job changes occur:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>A job ID is assigned to the print job</term>
	/// </item>
	/// <item>
	/// <term>Printing of a page has finished</term>
	/// </item>
	/// <item>
	/// <term>Printing of a document has finished</term>
	/// </item>
	/// <item>
	/// <term>The print job has been canceled or has ended because of an error</term>
	/// </item>
	/// </list>
	/// <para><c>Note</c> This event will not be signaled until after the application has started sending data to the print job.</para>
	/// <para>The XPS Print API does not reset this event—that is the caller's responsibility.</para>
	/// <para>If no progress notification is required, this parameter can be set to <c>NULL</c>.</para>
	/// </param>
	/// <param name="completionEvent">
	/// <para>
	/// An event handle that is signaled when the print job finishes. This event is guaranteed to be signaled exactly once per
	/// <c>StartXpsPrintJob</c> call. The XPS Print API does not reset this event—that is the caller's responsibility.
	/// </para>
	/// <para>If no completion notification is required, this parameter can be set to <c>NULL</c>.</para>
	/// </param>
	/// <param name="printablePagesOn">
	/// <para>
	/// The parameter references a UINT8 array whose elements specify a subset of a document's pages to be printed. As shown in the
	/// table that follows, the value of each element indicates whether the page is to be printed.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Array Element Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>0</term>
	/// <term>Do not print the page.</term>
	/// </item>
	/// <item>
	/// <term>Non-zero</term>
	/// <term>Print the page.</term>
	/// </item>
	/// </list>
	/// <para>Progress events will be signaled only for the pages that are designated for printing.</para>
	/// <para>
	/// The elements in the array represent all pages that are designated for printing, in all documents of the XPS package. For
	/// example, if the package contains two documents that have three pages each, the array shown in the following table designates the
	/// printing of pages 0 and 2 from document 1, and pages 0 and 2 from document 2.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Element index</term>
	/// <term>Element Value</term>
	/// <term>Print?</term>
	/// <term>Document number</term>
	/// <term>Page number</term>
	/// </listheader>
	/// <item>
	/// <term>5</term>
	/// <term>1</term>
	/// <term>Yes</term>
	/// <term>2</term>
	/// <term>2</term>
	/// </item>
	/// <item>
	/// <term>4</term>
	/// <term>0</term>
	/// <term>No</term>
	/// <term>2</term>
	/// <term>1</term>
	/// </item>
	/// <item>
	/// <term>3</term>
	/// <term>1</term>
	/// <term>Yes</term>
	/// <term>2</term>
	/// <term>0</term>
	/// </item>
	/// <item>
	/// <term>2</term>
	/// <term>1</term>
	/// <term>Yes</term>
	/// <term>1</term>
	/// <term>2</term>
	/// </item>
	/// <item>
	/// <term>1</term>
	/// <term>0</term>
	/// <term>No</term>
	/// <term>1</term>
	/// <term>1</term>
	/// </item>
	/// <item>
	/// <term>0</term>
	/// <term>1</term>
	/// <term>Yes</term>
	/// <term>1</term>
	/// <term>0</term>
	/// </item>
	/// </list>
	/// <para>If printablePagesOn is <c>NULL</c>, all pages in the package will be printed.</para>
	/// <para>If printablePagesOn has more elements than there are pages in the package, the superfluous elements will be ignored.</para>
	/// <para>
	/// If the array has fewer elements than there are pages in the document, the value of the last array element of the array is
	/// applied to the remaining pages. This rule makes it easier to specify a range that is open-ended or that gets only a few pages of
	/// a large document printed.
	/// </para>
	/// </param>
	/// <param name="printablePagesOnCount">
	/// The number of elements in the array that is referenced by printablePagesOn. If printablePagesOn is <c>NULL</c>, this parameter
	/// is ignored.
	/// </param>
	/// <param name="xpsPrintJob">
	/// A pointer to the IXpsPrintJob interface that represents the print job that is created by <c>StartXpsPrintJob</c>. To get the
	/// status of the print job or to cancel it, use the <c>IXpsPrintJob</c> interface. If an <c>IXpsPrintJob</c> is not required, this
	/// parameter can be set to <c>NULL</c>.
	/// </param>
	/// <param name="documentStream">
	/// A pointer to the IXpsPrintJobStream interface into which the caller writes the XPS document to be printed by this print job.
	/// </param>
	/// <param name="printTicketStream">
	/// A pointer to the IXpsPrintJobStream interface that is used by the caller to write the job-level print ticket that will be
	/// associated with this job. If this parameter is set to <c>NULL</c>, the print tickets (if any exist) from the XPS document that
	/// is written to documentStream will be used.
	/// </param>
	/// <returns>
	/// <para>The method returns an <c>HRESULT</c>. Possible values include, but are not limited to, those in the following table.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>The method succeeded.</term>
	/// </item>
	/// <item>
	/// <term>E_POINTER</term>
	/// <term>printerName or documentStream is NULL.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>Not enough memory to create a new IXpsPrintJob object.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>StartXpsPrintJob</c> is an asynchronous function, which can return before the print spooler creates or starts a print job.
	/// </para>
	/// <para>
	/// The interfaces that are returned in xpsPrintJob, documentStream, and printTicketStream must not be used until
	/// <c>StartXpsPrintJob</c> has returned successfully.
	/// </para>
	/// <para>
	/// After the caller starts sending data, it should monitor the progress events that are signaled to the event that is passed in
	/// progressEvent. When the event is signaled, the caller must call IXpsPrintJob::GetJobStatus to get the current status of the
	/// print job.
	/// </para>
	/// <para>
	/// When the print job finishes, whether successfully or not, the event that is passed in completionEvent is signaled once and only
	/// once. To prevent data loss, the caller should monitor this event and the thread or the application of the caller should not be
	/// terminated until the event has been signaled.
	/// </para>
	/// <para>
	/// Job states are neither stored nor queued by the print spooler. Because job processing does not wait for the status to be read
	/// after events are signaled, the caller might miss some state changes, depending on the delay between the time the application
	/// received the change notification and the time it called IXpsPrintJob::GetJobStatus. To receive subsequent notifications, the
	/// application must reset the progress event after it has received the notification.
	/// </para>
	/// <para>
	/// If a call to <c>StartXpsPrintJob</c> fails, the job status will be updated, the completion and progress events will be signaled,
	/// and an error code will be returned. To get the status of the failed print job, call IXpsPrintJob::GetJobStatus.
	/// </para>
	/// <para>
	/// <c>StartXpsPrintJob</c> calls <c>DuplicateHandle</c> on completionEvent and progressEvent to ensure that they remain valid for
	/// the lifetime of the job. Because the print spooler is using a duplicate handle for the events, it is possible for the caller to
	/// close these handles at any point without affecting job execution. The recommended procedure, however, is for the caller to close
	/// these handles only after the completionEvent event has been signaled and observed by the caller.
	/// </para>
	/// <para>
	/// The IXpsPrintJobStream interfaces that are returned in documentStream and printTicketStream are write-only streams that do not
	/// permit seeking but that can be closed. The caller writes the XPS document and print ticket content into these streams, and then
	/// calls Close after all data has been written. Calls to the streams' <c>Write</c> method are thread-safe; however, if such calls
	/// are made from different threads, they are not guaranteed to be committed to the stream in the expected order.
	/// </para>
	/// <para>
	/// <c>Note</c> When printing to a file, the application is responsible for providing the value that will be passed in the
	/// outputFileName parameter for print-to-file operations. To print to a printer which uses a driver that outputs to the FILE: port,
	/// the caller must retrieve the file name from the user by displaying the common file dialog.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsprint/nf-xpsprint-startxpsprintjob HRESULT StartXpsPrintJob( LPCWSTR
	// printerName, LPCWSTR jobName, LPCWSTR outputFileName, HANDLE progressEvent, HANDLE completionEvent, UINT8 *printablePagesOn,
	// UINT32 printablePagesOnCount, IXpsPrintJob **xpsPrintJob, IXpsPrintJobStream **documentStream, IXpsPrintJobStream
	// **printTicketStream );
	[DllImport(Lib.XpsPrint, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("xpsprint.h", MSDNShortId = "d982ae2e-c68f-4197-b419-22a63e61db8a")]
	public static extern HRESULT StartXpsPrintJob([MarshalAs(UnmanagedType.LPWStr)] string printerName, [Optional, MarshalAs(UnmanagedType.LPWStr)] string? jobName,
		[Optional, MarshalAs(UnmanagedType.LPWStr)] string? outputFileName, [Optional] HEVENT progressEvent, [Optional] HEVENT completionEvent, [Optional] byte[]? printablePagesOn,
		uint printablePagesOnCount, out IXpsPrintJob xpsPrintJob, out IXpsPrintJobStream documentStream, out IXpsPrintJobStream printTicketStream);

	/// <summary>
	/// <para>[StartXpsPrintJob1 is not supported and may be altered or unavailable in the future. ]</para>
	/// <para>
	/// Creates a print job for sending XPS document content to a printer.This function creates a more efficient print path than StartXpsPrintJob.
	/// </para>
	/// </summary>
	/// <param name="printerName">The name of the printer with which this job will be associated.</param>
	/// <param name="jobName">
	/// A user-specified job name to be associated with this job. You can set this parameter to <c>NULL</c> if the job does not require
	/// a separate, user-specified name.
	/// </param>
	/// <param name="outputFileName">
	/// The file name of the file or port into which the output of this job is to be redirected. Setting this value will cause the
	/// output of the print job to be directed to the specified file or port. To send the print job to the printer that is specified by
	/// printerName, you must set this parameter to <c>NULL</c>.
	/// </param>
	/// <param name="progressEvent">
	/// <para>An event handle that is signaled when one of the following print job changes occur:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>A job ID is assigned to the print job</term>
	/// </item>
	/// <item>
	/// <term>Printing of a page has finished</term>
	/// </item>
	/// <item>
	/// <term>Printing of a document has finished</term>
	/// </item>
	/// <item>
	/// <term>The print job has been canceled or has ended because of an error</term>
	/// </item>
	/// </list>
	/// <para><c>Note</c> This event will not be signaled until after the application has started sending data to the print job.</para>
	/// <para>The XPS Print API does not reset this event—that is the caller's responsibility.</para>
	/// <para>Set this parameter to <c>NULL</c> if you do not want to be notified about progress.</para>
	/// </param>
	/// <param name="completionEvent">
	/// <para>
	/// An event handle that is signaled when the print job finishes. This event is guaranteed to be signaled exactly once per
	/// <c>StartXpsPrintJob1</c> call. The XPS Print API does not reset this event—that is the caller's responsibility.
	/// </para>
	/// <para>Set this parameter to <c>NULL</c> if do not want to be notified about completion.</para>
	/// </param>
	/// <param name="xpsPrintJob">
	/// A pointer to the IXpsPrintJob interface that represents the print job that <c>StartXpsPrintJob1</c> created. To get the status
	/// of the print job or to cancel it, use the <c>IXpsPrintJob</c> interface. Set this parameter to <c>NULL</c> if you do not need it.
	/// </param>
	/// <param name="printContentReceiver">
	/// <para>
	/// A pointer to the IXpsOMPackageTarget interface that this function created. This parameter is required and you cannot set it to <c>NULL</c>.
	/// </para>
	/// <para>
	/// To send document content to the print job that this function created, use the IXpsOMPackageWriter interface that you create by
	/// calling the CreateXpsOMPackageWriter method of the IXpsOMPackageTarget interface returned in xpsOMPackageTarget.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>The method returns an <c>HRESULT</c>. Possible values include, but are not limited to, those in the following table.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>The method succeeded.</term>
	/// </item>
	/// <item>
	/// <term>E_POINTER</term>
	/// <term>printerName or xpsOMPackageTarget is NULL.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>Not enough memory to create a new IXpsPrintJob object.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>StartXpsPrintJob1</c> is an asynchronous function, and therefore it can return before the print spooler creates or starts a
	/// print job.
	/// </para>
	/// <para>
	/// Do not use the interfaces that are returned in xpsPrintJob and xpsOMPackageTarget until <c>StartXpsPrintJob1</c> has returned successfully.
	/// </para>
	/// <para>
	/// After the caller starts sending data, it is a good programming practice to monitor the progress events that are signaled to the
	/// event that is passed in progressEvent. When the event is signaled, the caller must call IXpsPrintJob::GetJobStatus to get the
	/// current status of the print job.
	/// </para>
	/// <para>
	/// When the print job finishes, whether successfully or not, the event that is passed in completionEvent is signaled only once. To
	/// prevent data loss, it is a good programming practice for the caller to monitor the completion event and ensure that neither the
	/// thread nor the application that created the print job are terminated until the completion event has been signaled.
	/// </para>
	/// <para>
	/// Job states are neither stored nor queued by the print spooler. Because job processing does not wait for the status to be read
	/// after events are signaled, the caller might miss some state changes, depending on the delay between the time the application
	/// received the change notification and the time it called IXpsPrintJob::GetJobStatus. To receive subsequent notifications, the
	/// application must reset the progress event after it has received the notification.
	/// </para>
	/// <para>
	/// If a call to <c>StartXpsPrintJob1</c> fails, the print spooler updates the job status, signals the completion and progress
	/// events, and returns an error code. To get the status of the failed print job, call IXpsPrintJob::GetJobStatus.
	/// </para>
	/// <para>
	/// <c>StartXpsPrintJob1</c> calls <c>DuplicateHandle</c> on completionEvent and progressEvent to ensure that they remain valid for
	/// the lifetime of the job. Because the print spooler is using a duplicate handle for the events, the caller can close these
	/// handles at any point without affecting job execution. However, we recommend for the caller to close these handles only after the
	/// completionEvent event has been signaled and the caller observed it.
	/// </para>
	/// <para>
	/// <c>Note</c> When your application prints to a file, the application is responsible for providing the value to pass in the
	/// outputFileName parameter for print-to-file operations. To print to a printer that uses a driver that outputs to the FILE: port,
	/// the caller must retrieve the file name from the user by displaying the common file dialog box.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsprint/nf-xpsprint-startxpsprintjob1 HRESULT StartXpsPrintJob1( LPCWSTR
	// printerName, LPCWSTR jobName, LPCWSTR outputFileName, HANDLE progressEvent, HANDLE completionEvent, IXpsPrintJob **xpsPrintJob,
	// IXpsOMPackageTarget **printContentReceiver );
	[DllImport(Lib.XpsPrint, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("xpsprint.h", MSDNShortId = "91D0BA4D-60A6-43F8-8BD3-9183DC6CD50D")]
	public static extern HRESULT StartXpsPrintJob1([MarshalAs(UnmanagedType.LPWStr)] string printerName, [Optional, MarshalAs(UnmanagedType.LPWStr)] string? jobName,
		[Optional, MarshalAs(UnmanagedType.LPWStr)] string? outputFileName, [Optional] HEVENT progressEvent, [Optional] HEVENT completionEvent,
		out IXpsPrintJob xpsPrintJob, out IntPtr printContentReceiver);

	/// <summary>
	/// <para>[ <c>XPS_JOB_STATUS</c> is not supported and may be altered or unavailable in the future. ]</para>
	/// <para>Contains a snapshot of job status.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsprint/ns-xpsprint-xps_job_status typedef struct
	// __MIDL___MIDL_itf_xpsprint_0000_0000_0002 { UINT32 jobId; INT32 currentDocument; INT32 currentPage; INT32 currentPageTotal;
	// XPS_JOB_COMPLETION completion; HRESULT jobStatus; } XPS_JOB_STATUS;
	[PInvokeData("xpsprint.h", MSDNShortId = "c4e13960-4f26-460a-b47e-98b833fcdfd5")]
	[StructLayout(LayoutKind.Sequential)]
	public struct XPS_JOB_STATUS
	{
		/// <summary>The spooler job ID that is assigned to the print job. If no job ID has yet been assigned, jobId will be 0.</summary>
		public uint jobId;

		/// <summary>
		/// The zero-based index of the most recently processed document in the print job; 0 is the first document, 1 is the next, and
		/// so on. If no documents have been processed, currentDocument will have a value of -1.
		/// </summary>
		public int currentDocument;

		/// <summary>
		/// The zero-based index of the most recently processed page in the current document; 0 is the first page, 1 is the next, and so
		/// on. If no pages have been processed, currentPage will have a value of -1.
		/// </summary>
		public int currentPage;

		/// <summary>
		/// A running total of the number of pages that have been processed by the print job. At the beginning of the job, this value is
		/// 0. As each page in each document is processed by the job, this value increases monotonically.
		/// </summary>
		public int currentPageTotal;

		/// <summary>
		/// The XPS_JOB_COMPLETION value that indicates the completion status of the job. This value will change when the event passed
		/// in the <c>completionEvent</c> parameter of StartXpsPrintJob is signaled at the end of a job. If the print job fails, this
		/// value will be <c>XPS_JOB_FAILED</c>, with jobStatus containing the error code of the failure.
		/// </summary>
		public XPS_JOB_COMPLETION completion;

		/// <summary>
		/// The error state of the job. If the job finishes without an error, this value will be <c>S_OK</c>. If an error causes the
		/// print job to exit, this value will be the error code of the failure.
		/// </summary>
		public HRESULT jobStatus;
	}
}