namespace Vanara.PInvoke;

public static partial class ClfsW32
{
	/// <summary>
	/// The <c>LOG_FULL_HANDLER_CALLBACK</c> function is an application-defined callback function that receives notification that the call to
	/// HandleLogFull is complete. The callback is invoked in the context of an asynchronous procedure call (APC) on the thread that
	/// registered for log management.
	/// </summary>
	/// <param name="hLogFile">The handle to the log.</param>
	/// <param name="dwError">The status of the operation.</param>
	/// <param name="fLogIsPinned">
	/// Specifies if the log is considered "pinned". If <c>fLogIsPinned</c> is <c>TRUE</c> and the log is then unpinned, the
	/// LOG_UNPINNED_CALLBACK is invoked.
	/// </param>
	/// <param name="pvClientContext">A pointer to the client context.</param>
	/// <remarks>The client application determines which actions this callback function performs.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfsmgmtw32/nc-clfsmgmtw32-plog_full_handler_callback PLOG_FULL_HANDLER_CALLBACK
	// PlogFullHandlerCallback; void PlogFullHandlerCallback( [in] HLOG hLogFile, [in] DWORD dwError, [in] BOOL fLogIsPinned, [in] PVOID
	// pvClientContext ) {...}
	[PInvokeData("clfsmgmtw32.h", MSDNShortId = "NC:clfsmgmtw32.PLOG_FULL_HANDLER_CALLBACK")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	public delegate void PLOG_FULL_HANDLER_CALLBACK([In] HLOG hLogFile, [In] Win32Error dwError, [MarshalAs(UnmanagedType.Bool)] bool fLogIsPinned,
		[In] IntPtr pvClientContext);

	/// <summary>
	/// The <c>LOG_TAIL_ADVANCE_CALLBACK</c> function is an application-defined callback function that advances the log tail. The callback is
	/// invoked in the context of an asynchronous procedure call (APC) on the thread that registers for log management.
	/// </summary>
	/// <param name="hLogFile">The handle to the log.</param>
	/// <param name="lsnTarget">
	/// Specifies the log sequence number (LSN) to which the client is advised to advance to or beyond. The <c>lsnTarget</c> may not refer to
	/// an actual record in the log.
	/// </param>
	/// <param name="pvClientContext">A pointer to the client context.</param>
	/// <returns>None</returns>
	/// <remarks>
	/// This callback can be invoked at any time. This callback function should advance the base LSN of the log to greater than or equal to
	/// the value of <c>lsnTarget</c>.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfsmgmtw32/nc-clfsmgmtw32-plog_tail_advance_callback PLOG_TAIL_ADVANCE_CALLBACK
	// PlogTailAdvanceCallback; void PlogTailAdvanceCallback( [in] HLOG hLogFile, [in] CLFS_LSN lsnTarget, [in] PVOID pvClientContext ) {...}
	[PInvokeData("clfsmgmtw32.h", MSDNShortId = "NC:clfsmgmtw32.PLOG_TAIL_ADVANCE_CALLBACK")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	public delegate void PLOG_TAIL_ADVANCE_CALLBACK([In] HLOG hLogFile, [In] CLS_LSN lsnTarget, [In] IntPtr pvClientContext);

	/// <summary>
	/// The <c>LOG_UNPINNED_CALLBACK</c> function is an application-defined callback function that receives notification that the log has
	/// become unpinned. The callback is invoked in the context of an asynchronous procedure call (APC) on the thread that registers for log management.
	/// </summary>
	/// <param name="hLogFile">The handle to the log.</param>
	/// <param name="pvClientContext">
	/// A pointer to the client context. This is the same context specified when registering the client, which is a member of LOG_MANAGEMENT_CALLBACKS.
	/// </param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfsmgmtw32/nc-clfsmgmtw32-plog_unpinned_callback PLOG_UNPINNED_CALLBACK
	// PlogUnpinnedCallback; void PlogUnpinnedCallback( [in] HLOG hLogFile, [in] PVOID pvClientContext ) {...}
	[PInvokeData("clfsmgmtw32.h", MSDNShortId = "NC:clfsmgmtw32.PLOG_UNPINNED_CALLBACK")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	public delegate void PLOG_UNPINNED_CALLBACK([In] HLOG hLogFile, [In] IntPtr pvClientContext);

	/// <summary>The <c>DeregisterManageableLogClient</c> function deregisters a client with the log manager.</summary>
	/// <param name="hLog">The handle to deregister.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. For extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfsmgmtw32/nf-clfsmgmtw32-deregistermanageablelogclient CLFSUSER_API BOOL
	// DeregisterManageableLogClient( [in] HLOG hLog );
	[DllImport(Lib_Clfsw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("clfsmgmtw32.h", MSDNShortId = "NF:clfsmgmtw32.DeregisterManageableLogClient")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DeregisterManageableLogClient([In] HLOG hLog);

	/// <summary>
	/// The <c>HandleLogFull</c> function is called by a managed log client when an attempt to reserve or append to a log fails with a log
	/// full error message. The log manager attempts to resolve the log full condition for the client, and notifies the client when the
	/// outcome is known. As a result of this call, the log may get larger in size.
	/// </summary>
	/// <param name="hLog">A handle to the log on which to resolve the log full condition. The handle must have been registered with RegisterManageableLogClient.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>
	/// If the function fails, the return value is zero. To get extended error information, call GetLastError. Valid values include the following:
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>If containers are created to resolve a log-full condition, they are created using the calling application's security context.</para>
	/// <para>
	/// <c>HandleLogFull</c> always results in asynchronous behavior or an error; if it returns false and GetLastError returns
	/// <c>ERROR_IO_PENDING</c>, the result is asynchronous behavior. If a request is asynchronous, a notification is sent to the client when
	/// the handler has either resolved the log full condition or it fails.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfsmgmtw32/nf-clfsmgmtw32-handlelogfull CLFSUSER_API BOOL HandleLogFull( [in]
	// HLOG hLog );
	[DllImport(Lib_Clfsw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("clfsmgmtw32.h", MSDNShortId = "NF:clfsmgmtw32.HandleLogFull")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool HandleLogFull([In] HLOG hLog);

	/// <summary>Installs (sets) a policy for a log.</summary>
	/// <param name="hLog">A handle to a log.</param>
	/// <param name="pPolicy">A pointer to a CLFS_MGMT_POLICY structure that represents the desired policy to install.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>Installing a log policy does not trigger an immediate change in behavior.</para>
	/// <para>Examples</para>
	/// <para>For an example that uses this function, see Creating a Log File.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfsmgmtw32/nf-clfsmgmtw32-installlogpolicy CLFSUSER_API BOOL InstallLogPolicy(
	// [in] HLOG hLog, [in] PCLFS_MGMT_POLICY pPolicy );
	[DllImport(Lib_Clfsw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("clfsmgmtw32.h", MSDNShortId = "NF:clfsmgmtw32.InstallLogPolicy")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool InstallLogPolicy([In] HLOG hLog, in CLFS_MGMT_POLICY pPolicy);

	/// <summary>
	/// The <c>LogTailAdvanceFailure</c> function is called by a log client to indicate that it cannot comply with a request from log
	/// management to advance its tail.
	/// </summary>
	/// <param name="hLog">A handle to the log on which to resolve the log full condition.</param>
	/// <param name="dwReason">Win32 error code with the reason for the failure For a list of possible values, see System Error Codes.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>
	/// If the function fails, the return value is zero. To get extended error information, call GetLastError. Valid values include the following:
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfsmgmtw32/nf-clfsmgmtw32-logtailadvancefailure CLFSUSER_API BOOL
	// LogTailAdvanceFailure( [in] HLOG hLog, [in] DWORD dwReason );
	[DllImport(Lib_Clfsw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("clfsmgmtw32.h", MSDNShortId = "NF:clfsmgmtw32.LogTailAdvanceFailure")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool LogTailAdvanceFailure([In] HLOG hLog, [In] Win32Error dwReason);

	/// <summary>The <c>QueryLogPolicy</c> function allows you to obtain a policy that is installed for the specified log.</summary>
	/// <param name="hLog">The handle to the log to query.</param>
	/// <param name="ePolicyType">Specifies the type of policy to query for. Policy types are enumerated in CLFS_MGMT_POLICY_TYPE.</param>
	/// <param name="pPolicyBuffer">A pointer to a buffer to receive the returned policies.</param>
	/// <param name="pcbPolicyBuffer">
	/// A pointer to the size of <c>pPolicyBuffer</c>. If the buffer is not large enough, <c>pcbPolicyBuffer</c> receives the size buffer
	/// required to successfully retrieve the specified policies.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero (0). To get extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfsmgmtw32/nf-clfsmgmtw32-querylogpolicy CLFSUSER_API BOOL QueryLogPolicy( [in]
	// HLOG hLog, [in] CLFS_MGMT_POLICY_TYPE ePolicyType, [out] PCLFS_MGMT_POLICY pPolicyBuffer, [in, out] PULONG pcbPolicyBuffer );
	[DllImport(Lib_Clfsw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("clfsmgmtw32.h", MSDNShortId = "NF:clfsmgmtw32.QueryLogPolicy")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool QueryLogPolicy([In] HLOG hLog, [In] CLFS_MGMT_POLICY_TYPE ePolicyType,
		[Out] SafeCoTaskMemStruct<CLFS_MGMT_POLICY> pPolicyBuffer, ref uint pcbPolicyBuffer);

	/// <summary>
	/// The <c>ReadLogNotification</c> function retrieves notifications from the log manager. It retrieves a queued notification from the log
	/// manager immediately if a notification is available; otherwise the request remains pending until a notification is generated.
	/// </summary>
	/// <param name="hLog">The handle to the log.</param>
	/// <param name="pNotification">Receives the notification type, and if the type has parameters associated with it, the parameters.</param>
	/// <param name="lpOverlapped">
	/// A pointer to an OVERLAPPED structure that is required for asynchronous operation. If asynchronous operation is not used, this
	/// parameter can be <c>NULL</c>.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>
	/// If the function fails, the return value is zero. To get extended error information, call GetLastError. The following is a possible
	/// error code:
	/// </para>
	/// </returns>
	/// <remarks>
	/// If the log handle is not created with the <c>FILE_FLAG_OVERLAPPED</c> file option, no operations can start on the log handle while
	/// the call to <c>ReadLogNotification</c> is pending.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfsmgmtw32/nf-clfsmgmtw32-readlognotification CLFSUSER_API BOOL
	// ReadLogNotification( [in] HLOG hLog, [out] PCLFS_MGMT_NOTIFICATION pNotification, [in] LPOVERLAPPED lpOverlapped );
	[DllImport(Lib_Clfsw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("clfsmgmtw32.h", MSDNShortId = "NF:clfsmgmtw32.ReadLogNotification")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ReadLogNotification([In] HLOG hLog, out CLFS_MGMT_NOTIFICATION pNotification,
		in NativeOverlapped lpOverlapped);

	/// <summary>
	/// The <c>ReadLogNotification</c> function retrieves notifications from the log manager. It retrieves a queued notification from the log
	/// manager immediately if a notification is available; otherwise the request remains pending until a notification is generated.
	/// </summary>
	/// <param name="hLog">The handle to the log.</param>
	/// <param name="pNotification">Receives the notification type, and if the type has parameters associated with it, the parameters.</param>
	/// <param name="lpOverlapped">
	/// A pointer to an OVERLAPPED structure that is required for asynchronous operation. If asynchronous operation is not used, this
	/// parameter can be <c>NULL</c>.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>
	/// If the function fails, the return value is zero. To get extended error information, call GetLastError. The following is a possible
	/// error code:
	/// </para>
	/// </returns>
	/// <remarks>
	/// If the log handle is not created with the <c>FILE_FLAG_OVERLAPPED</c> file option, no operations can start on the log handle while
	/// the call to <c>ReadLogNotification</c> is pending.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfsmgmtw32/nf-clfsmgmtw32-readlognotification CLFSUSER_API BOOL
	// ReadLogNotification( [in] HLOG hLog, [out] PCLFS_MGMT_NOTIFICATION pNotification, [in] LPOVERLAPPED lpOverlapped );
	[DllImport(Lib_Clfsw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("clfsmgmtw32.h", MSDNShortId = "NF:clfsmgmtw32.ReadLogNotification")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ReadLogNotification([In] HLOG hLog, out CLFS_MGMT_NOTIFICATION pNotification,
		[In, Optional] IntPtr lpOverlapped);

	/// <summary>
	/// The <c>RegisterForLogWriteNotification</c> function is called by a managed log client to enable or disable log write notifications.
	/// </summary>
	/// <param name="hLog">A handle to the log on which to resolve the log full condition.</param>
	/// <param name="cbThreshold">Number of bytes to be written to the log file before the notification is sent.</param>
	/// <param name="fEnable">If <c>TRUE</c>, the notification is enabled. If <c>FALSE</c>, the notification is disabled.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>
	/// If the function fails, the return value is zero. To get extended error information, call GetLastError. Valid values include the following:
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfsmgmtw32/nf-clfsmgmtw32-registerforlogwritenotification CLFSUSER_API BOOL
	// RegisterForLogWriteNotification( [in] HLOG hLog, [in] ULONG cbThreshold, [in] BOOL fEnable );
	[DllImport(Lib_Clfsw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("clfsmgmtw32.h", MSDNShortId = "NF:clfsmgmtw32.RegisterForLogWriteNotification")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool RegisterForLogWriteNotification([In] HLOG hLog, [In] uint cbThreshold, [MarshalAs(UnmanagedType.Bool)] bool fEnable);

	/// <summary>
	/// The <c>RegisterManageableLogClient</c> function registers a client with the log manager. A client can specify whether to receive
	/// notifications by using callbacks, or have the notifications queued for retrieval by using ReadLogNotification.
	/// </summary>
	/// <param name="hLog">The handle to the log to register. Only one registration per unique opening of the log is allowed.</param>
	/// <param name="pCallbacks">
	/// Specifies the callbacks that the client is registering for. Valid callbacks are enumerated by LOG_MANAGEMENT_CALLBACKS. Specify zero
	/// to queue notifications instead.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>A client can deregister either by closing the log handle, or by calling DeregisterManageableLogClient.</para>
	/// <para>Examples</para>
	/// <para>For an example that uses this function, see Creating a Log File.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfsmgmtw32/nf-clfsmgmtw32-registermanageablelogclient CLFSUSER_API BOOL
	// RegisterManageableLogClient( [in] HLOG hLog, [in] PLOG_MANAGEMENT_CALLBACKS pCallbacks );
	[DllImport(Lib_Clfsw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("clfsmgmtw32.h", MSDNShortId = "NF:clfsmgmtw32.RegisterManageableLogClient")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool RegisterManageableLogClient([In] HLOG hLog, in LOG_MANAGEMENT_CALLBACKS pCallbacks);

	/// <summary>Resets the specified policy to its default behavior.</summary>
	/// <param name="hLog">Handle to the log to reset the policy for.</param>
	/// <param name="ePolicyType">Specifies the policy to reset. Policy types are enumerated in CLFS_MGMT_POLICY_TYPE.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero (0). To get extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfsmgmtw32/nf-clfsmgmtw32-removelogpolicy CLFSUSER_API BOOL RemoveLogPolicy( [in]
	// HLOG hLog, [in] CLFS_MGMT_POLICY_TYPE ePolicyType );
	[DllImport(Lib_Clfsw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("clfsmgmtw32.h", MSDNShortId = "NF:clfsmgmtw32.RemoveLogPolicy")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool RemoveLogPolicy([In] HLOG hLog, [In] CLFS_MGMT_POLICY_TYPE ePolicyType);

	/// <summary>Adds or deletes containers from a log based on the state of the installed policies.</summary>
	/// <param name="hLog">A handle to a log.</param>
	/// <param name="pDesiredSize">
	/// <para>
	/// A pointer to a value that specifies the requested log size, expressed as one of the following values. For the actual resultant size,
	/// refer to the <c>pResultingSize</c> parameter.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>0</term>
	/// <term>
	/// Enforce the minimum size policy. If a minimum size policy is not installed, one of the following occurs: If a minimum size policy is
	/// installed, one of the following occurs: For more information, see InstallLogPolicy.
	/// </term>
	/// </item>
	/// <item>
	/// <term>1</term>
	/// <term>Not a valid value; the function call fails with <c>ERROR_INVALID_PARAMETER</c>.</term>
	/// </item>
	/// <item>
	/// <term>2–1023</term>
	/// <term>
	/// The desired size of the log, expressed as the number of containers. If this number is smaller than the minimum number of containers
	/// specified by the installed policy, the function call fails with <c>ERROR_COULD_NOT_RESIZE_LOG</c>. If this number is larger than the
	/// maximum number of containers specified by the installed policy, the log expands only as far as the policy-specified maximum number of
	/// containers, and the function succeeds with no error.
	/// </term>
	/// </item>
	/// <item>
	/// <term>1024–MAXULONGLONG</term>
	/// <term>
	/// If no maximum size policy is installed, the function call fails with <c>ERROR_LOG_POLICY_CONFLICT</c>. If a maximum size policy is
	/// installed, the log expands to the maximum number of containers specified by the maximum size policy and the function succeeds with no error.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pResultingSize">
	/// A pointer to a valid ULONGLONG data variable, receives the number of containers in the resized log upon success.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call the GetLastError function.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Containers are created using the same security attributes as the .blf file and are created within the context of the application, not
	/// the context of the owner of the .blf file. For more information about .blf files, see Log Types. If containers are deleted, they are
	/// deleted using the security context of the calling application.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example that uses this function, see Creating a Log File.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfsmgmtw32/nf-clfsmgmtw32-setlogfilesizewithpolicy CLFSUSER_API BOOL
	// SetLogFileSizeWithPolicy( [in] HLOG hLog, [in] PULONGLONG pDesiredSize, [out] PULONGLONG pResultingSize );
	[DllImport(Lib_Clfsw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("clfsmgmtw32.h", MSDNShortId = "NF:clfsmgmtw32.SetLogFileSizeWithPolicy")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetLogFileSizeWithPolicy([In] HLOG hLog, in ulong pDesiredSize, out ulong pResultingSize);

	/// <summary>
	/// The <c>LOG_MANAGEMENT_CALLBACKS</c> structure is used to register with the Common Log File System (CLFS) for the callbacks that a
	/// client program requires information from.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfsmgmtw32/ns-clfsmgmtw32-log_management_callbacks typedef struct
	// _LOG_MANAGEMENT_CALLBACKS { PVOID CallbackContext; PLOG_TAIL_ADVANCE_CALLBACK AdvanceTailCallback; PLOG_FULL_HANDLER_CALLBACK
	// LogFullHandlerCallback; PLOG_UNPINNED_CALLBACK LogUnpinnedCallback; } LOG_MANAGEMENT_CALLBACKS, *PLOG_MANAGEMENT_CALLBACKS;
	[PInvokeData("clfsmgmtw32.h", MSDNShortId = "NS:clfsmgmtw32._LOG_MANAGEMENT_CALLBACKS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct LOG_MANAGEMENT_CALLBACKS
	{
		/// <summary>
		/// A pointer to the context which is a client-defined value. CLFS ignores this value other than to pass it with every callback to
		/// the client.
		/// </summary>
		public IntPtr CallbackContext;

		/// <summary>Called when the management functionality determines that the client should advance the tail of its log.</summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public PLOG_TAIL_ADVANCE_CALLBACK AdvanceTailCallback;

		/// <summary>Called when an asynchronous request is initiated when HandleLogFull completes.</summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public PLOG_FULL_HANDLER_CALLBACK LogFullHandlerCallback;

		/// <summary>Called when a pinned log becomes unpinned.</summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public PLOG_UNPINNED_CALLBACK LogUnpinnedCallback;
	}
}