namespace Vanara.PInvoke;

public static partial class Shell32
{
	/// <summary>Represents the state of a Windows app package.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/ne-shobjidl_core-package_execution_state typedef enum
	// PACKAGE_EXECUTION_STATE { PES_UNKNOWN, PES_RUNNING, PES_SUSPENDING, PES_SUSPENDED, PES_TERMINATED } ;
	[PInvokeData("shobjidl_core.h", MSDNShortId = "NE:shobjidl_core.PACKAGE_EXECUTION_STATE")]
	public enum PACKAGE_EXECUTION_STATE
	{
		/// <summary>The package is in an unknown state.</summary>
		PES_UNKNOWN,

		/// <summary>The package is running.</summary>
		PES_RUNNING,

		/// <summary>The package is being suspended.</summary>
		PES_SUSPENDING,

		/// <summary>The package is suspended.</summary>
		PES_SUSPENDED,

		/// <summary>The package was terminated.</summary>
		PES_TERMINATED,
	}

	/// <summary>Enables debugger developers to control the life cycle of a Windows Store app, such as suspending or resuming.</summary>
	/// <remarks>
	/// <para>Any debug options set remain in effect until they are cleared or this interface is released.</para>
	/// <para>
	/// For debug settings to take effect on Internet Explorer in the new Windows UI, use "DefaultBrowser_NOPUBLISHERID" as the
	/// packageFullName parameter for IPackageDebugSettings methods.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-ipackagedebugsettings
	[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.IPackageDebugSettings")]
	[ComImport, Guid("F27C3930-8029-4AD1-94E3-3DBA417810C1"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(PackageDebugSettings))]
	public interface IPackageDebugSettings
	{
		/// <summary>Enables debug mode for the processes of the specified package.</summary>
		/// <param name="packageFullName">The package full name.</param>
		/// <param name="debuggerCommandLine">The command line to use to launch processes from this package. This parameter is optional.</param>
		/// <param name="environment">Any environment strings to pass to processes. This parameter is optional.</param>
		/// <remarks>
		/// <para>Enabling debug mode has the following effects:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Optionally enables debugger attach on activation.</term>
		/// </item>
		/// <item>
		/// <term>Disables activation timeouts.</term>
		/// </item>
		/// <item>
		/// <term>Disables automatic process suspension.</term>
		/// </item>
		/// <item>
		/// <term>Disables automatic process termination.</term>
		/// </item>
		/// <item>
		/// <term>Disables automatic process resumption.</term>
		/// </item>
		/// </list>
		/// <para>To restore normal operation, call the DisableDebugging method.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ipackagedebugsettings-enabledebugging
		// HRESULT EnableDebugging( LPCWSTR packageFullName, LPCWSTR debuggerCommandLine, PZZWSTR environment );
		void EnableDebugging([MarshalAs(UnmanagedType.LPWStr)] string packageFullName, [Optional, MarshalAs(UnmanagedType.LPWStr)] string? debuggerCommandLine, [In, Optional] IntPtr environment);

		/// <summary>Disables debug mode for the processes of the specified package.</summary>
		/// <param name="packageFullName">The package full name.</param>
		/// <remarks>This method has no effect if the EnableDebugging method was not previously called for this package.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ipackagedebugsettings-disabledebugging
		// HRESULT DisableDebugging( LPCWSTR packageFullName );
		void DisableDebugging([MarshalAs(UnmanagedType.LPWStr)] string packageFullName);

		/// <summary>Suspends the processes of the package if they are currently running.</summary>
		/// <param name="packageFullName">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>The package full name.</para>
		/// </param>
		/// <remarks>
		/// Each process receives the <c>Suspending</c> event. It can be useful for developers to step through how their apps respond to
		/// this event.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/winrt/ipackagedebugsettings-suspend HRESULT Suspend( [in] LPCWSTR
		// packageFullName );
		void Suspend([MarshalAs(UnmanagedType.LPWStr)] string packageFullName);

		/// <summary>Resumes the processes of the package if they are currently suspended.</summary>
		/// <param name="packageFullName">The package full name.</param>
		/// <remarks>
		/// Each process receives the Resuming event, which is useful for stepping through your apps as they respond to this event.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ipackagedebugsettings-resume HRESULT
		// Resume( LPCWSTR packageFullName );
		void Resume([MarshalAs(UnmanagedType.LPWStr)] string packageFullName);

		/// <summary>Terminates all processes for the specified package.</summary>
		/// <param name="packageFullName">The package full name.</param>
		/// <remarks>
		/// This method does not suspend the processes first. To test suspension followed by termination, call the Suspend method before
		/// calling TerminateAllProcesses.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ipackagedebugsettings-terminateallprocesses
		// HRESULT TerminateAllProcesses( LPCWSTR packageFullName );
		void TerminateAllProcesses([MarshalAs(UnmanagedType.LPWStr)] string packageFullName);

		/// <summary>Sets the session identifier.</summary>
		/// <param name="sessionId">The session identifier.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ipackagedebugsettings-settargetsessionid
		// HRESULT SetTargetSessionId( ULONG sessionId );
		void SetTargetSessionId(uint sessionId);

		/// <summary>Gets the background tasks that are provided by the specified package.</summary>
		/// <param name="packageFullName">The package full name to query for background tasks.</param>
		/// <param name="taskCount">The count of taskIds and taskNames entries.</param>
		/// <param name="taskIds">
		/// An array of background task identifiers. You can use these identifiers in the ActivateBackgroundTask method to activate
		/// specified tasks.
		/// </param>
		/// <param name="taskNames">An array of task names that corresponds with background taskIds.</param>
		/// <remarks>
		/// Both parameters taskIds and taskNames have the same ordering of tasks. If you need to know the user-readable task name
		/// associated with taskId[0], refer to taskNames[0].
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ipackagedebugsettings-enumeratebackgroundtasks
		// HRESULT EnumerateBackgroundTasks( LPCWSTR packageFullName, ULONG *taskCount, LPCGUID *taskIds, LPCWSTR **taskNames );
		void EnumerateBackgroundTasks([MarshalAs(UnmanagedType.LPWStr)] string packageFullName, out uint taskCount, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] out Guid[] taskIds,
			[Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr, SizeParamIndex = 1)] out string[] taskNames);

		/// <summary>Activates the specified background task.</summary>
		/// <param name="taskId">The identifier of the background task to activate.</param>
		/// <remarks>Use the <c>ActivateBackgroundTask</c> method to test the code that handles your background tasks.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ipackagedebugsettings-activatebackgroundtask
		// HRESULT ActivateBackgroundTask( LPCGUID taskId );
		void ActivateBackgroundTask(in Guid taskId);

		/// <summary>
		/// Suspends and terminates the non-background portion of the apps associated with the specified package and cancels the
		/// background tasks associated with the package.
		/// </summary>
		/// <param name="packageFullName">The package full name.</param>
		/// <remarks>
		/// Use the <c>StartServicing</c> method to simulate what happens when a package is updated to a newer version. New background
		/// task activations are buffered (delayed) until you call the StopServicing method.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ipackagedebugsettings-startservicing
		// HRESULT StartServicing( LPCWSTR packageFullName );
		void StartServicing([MarshalAs(UnmanagedType.LPWStr)] string packageFullName);

		/// <summary>Completes the previous servicing operation that was started by a call to the StartServicing method.</summary>
		/// <param name="packageFullName">The package full name.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ipackagedebugsettings-stopservicing HRESULT
		// StopServicing( LPCWSTR packageFullName );
		void StopServicing([MarshalAs(UnmanagedType.LPWStr)] string packageFullName);

		/// <summary>Causes background tasks for the specified package to activate in the specified user session.</summary>
		/// <param name="packageFullName">The package full name.</param>
		/// <param name="sessionId">The identifier of the session which background tasks are redirected to.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ipackagedebugsettings-startsessionredirection
		// HRESULT StartSessionRedirection( LPCWSTR packageFullName, ULONG sessionId );
		void StartSessionRedirection([MarshalAs(UnmanagedType.LPWStr)] string packageFullName, uint sessionId);

		/// <summary>Stops redirection of background tasks for the specified package.</summary>
		/// <param name="packageFullName">The package full name.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ipackagedebugsettings-stopsessionredirection
		// HRESULT StopSessionRedirection( LPCWSTR packageFullName );
		void StopSessionRedirection([MarshalAs(UnmanagedType.LPWStr)] string packageFullName);

		/// <summary>Gets the state of the package execution.</summary>
		/// <param name="packageFullName">Full name of the package.</param>
		/// <returns>State of the package execution.</returns>
		PACKAGE_EXECUTION_STATE GetPackageExecutionState([MarshalAs(UnmanagedType.LPWStr)] string packageFullName);

		/// <summary>Register for package state-change notifications.</summary>
		/// <param name="packageFullName">The package full name.</param>
		/// <param name="pPackageExecutionStateChangeNotification">
		/// Package state-change notifications are delivered by the OnStateChanged function on pPackageExecutionStateChangeNotification.
		/// </param>
		/// <param name="pdwCookie">
		/// A unique registration identifier for the current listener. Use this identifier to unregister for package state-change
		/// notifications by using the UnregisterForPackageStateChanges method.
		/// </param>
		/// <remarks>Notifications are raised when the package enters the running, suspending, and suspended states.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ipackagedebugsettings-registerforpackagestatechanges
		// HRESULT RegisterForPackageStateChanges( LPCWSTR packageFullName, IPackageExecutionStateChangeNotification
		// *pPackageExecutionStateChangeNotification, DWORD *pdwCookie );
		void RegisterForPackageStateChanges([MarshalAs(UnmanagedType.LPWStr)] string packageFullName, IPackageExecutionStateChangeNotification pPackageExecutionStateChangeNotification, out uint pdwCookie);

		/// <summary>Stops receiving package state-change notifications associated with a previous call to RegisterForPackageStateChanges.</summary>
		/// <param name="dwCookie">
		/// The notification to cancel. This identifier is returned by a previous call to the RegisterForPackageStateChanges method.
		/// </param>
		/// <remarks>
		/// Call the <c>UnregisterForPackageStateChanges</c> to stop receiving package state-change notifications associated with a
		/// previous call to the RegisterForPackageStateChanges method.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ipackagedebugsettings-unregisterforpackagestatechanges
		// HRESULT UnregisterForPackageStateChanges( DWORD dwCookie );
		void UnregisterForPackageStateChanges(uint dwCookie);
	}

	/// <summary>Undocumented.</summary>
	/// <seealso cref="IPackageDebugSettings"/>
	[PInvokeData("shobjidl_core.h")]
	[ComImport, Guid("6E3194BB-AB82-4D22-93F5-FABDA40E7B16"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IPackageDebugSettings2 : IPackageDebugSettings
	{
		/// <summary>Enables debug mode for the processes of the specified package.</summary>
		/// <param name="packageFullName">The package full name.</param>
		/// <param name="debuggerCommandLine">The command line to use to launch processes from this package. This parameter is optional.</param>
		/// <param name="environment">Any environment strings to pass to processes. This parameter is optional.</param>
		/// <remarks>
		/// <para>Enabling debug mode has the following effects:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Optionally enables debugger attach on activation.</term>
		/// </item>
		/// <item>
		/// <term>Disables activation timeouts.</term>
		/// </item>
		/// <item>
		/// <term>Disables automatic process suspension.</term>
		/// </item>
		/// <item>
		/// <term>Disables automatic process termination.</term>
		/// </item>
		/// <item>
		/// <term>Disables automatic process resumption.</term>
		/// </item>
		/// </list>
		/// <para>To restore normal operation, call the DisableDebugging method.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ipackagedebugsettings-enabledebugging
		// HRESULT EnableDebugging( LPCWSTR packageFullName, LPCWSTR debuggerCommandLine, PZZWSTR environment );
		new void EnableDebugging([MarshalAs(UnmanagedType.LPWStr)] string packageFullName, [Optional, MarshalAs(UnmanagedType.LPWStr)] string? debuggerCommandLine, [In, Optional] IntPtr environment);

		/// <summary>Disables debug mode for the processes of the specified package.</summary>
		/// <param name="packageFullName">The package full name.</param>
		/// <remarks>This method has no effect if the EnableDebugging method was not previously called for this package.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ipackagedebugsettings-disabledebugging
		// HRESULT DisableDebugging( LPCWSTR packageFullName );
		new void DisableDebugging([MarshalAs(UnmanagedType.LPWStr)] string packageFullName);

		/// <summary>Suspends the processes of the package if they are currently running.</summary>
		/// <param name="packageFullName">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>The package full name.</para>
		/// </param>
		/// <remarks>
		/// Each process receives the <c>Suspending</c> event. It can be useful for developers to step through how their apps respond to
		/// this event.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/winrt/ipackagedebugsettings-suspend HRESULT Suspend( [in] LPCWSTR
		// packageFullName );
		new void Suspend([MarshalAs(UnmanagedType.LPWStr)] string packageFullName);

		/// <summary>Resumes the processes of the package if they are currently suspended.</summary>
		/// <param name="packageFullName">The package full name.</param>
		/// <remarks>
		/// Each process receives the Resuming event, which is useful for stepping through your apps as they respond to this event.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ipackagedebugsettings-resume HRESULT
		// Resume( LPCWSTR packageFullName );
		new void Resume([MarshalAs(UnmanagedType.LPWStr)] string packageFullName);

		/// <summary>Terminates all processes for the specified package.</summary>
		/// <param name="packageFullName">The package full name.</param>
		/// <remarks>
		/// This method does not suspend the processes first. To test suspension followed by termination, call the Suspend method before
		/// calling TerminateAllProcesses.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ipackagedebugsettings-terminateallprocesses
		// HRESULT TerminateAllProcesses( LPCWSTR packageFullName );
		new void TerminateAllProcesses([MarshalAs(UnmanagedType.LPWStr)] string packageFullName);

		/// <summary>Sets the session identifier.</summary>
		/// <param name="sessionId">The session identifier.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ipackagedebugsettings-settargetsessionid
		// HRESULT SetTargetSessionId( ULONG sessionId );
		new void SetTargetSessionId(uint sessionId);

		/// <summary>Gets the background tasks that are provided by the specified package.</summary>
		/// <param name="packageFullName">The package full name to query for background tasks.</param>
		/// <param name="taskCount">The count of taskIds and taskNames entries.</param>
		/// <param name="taskIds">
		/// An array of background task identifiers. You can use these identifiers in the ActivateBackgroundTask method to activate
		/// specified tasks.
		/// </param>
		/// <param name="taskNames">An array of task names that corresponds with background taskIds.</param>
		/// <remarks>
		/// Both parameters taskIds and taskNames have the same ordering of tasks. If you need to know the user-readable task name
		/// associated with taskId[0], refer to taskNames[0].
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ipackagedebugsettings-enumeratebackgroundtasks
		// HRESULT EnumerateBackgroundTasks( LPCWSTR packageFullName, ULONG *taskCount, LPCGUID *taskIds, LPCWSTR **taskNames );
		new void EnumerateBackgroundTasks([MarshalAs(UnmanagedType.LPWStr)] string packageFullName, out uint taskCount, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] out Guid[] taskIds,
			[Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr, SizeParamIndex = 1)] out string[] taskNames);

		/// <summary>Activates the specified background task.</summary>
		/// <param name="taskId">The identifier of the background task to activate.</param>
		/// <remarks>Use the <c>ActivateBackgroundTask</c> method to test the code that handles your background tasks.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ipackagedebugsettings-activatebackgroundtask
		// HRESULT ActivateBackgroundTask( LPCGUID taskId );
		new void ActivateBackgroundTask(in Guid taskId);

		/// <summary>
		/// Suspends and terminates the non-background portion of the apps associated with the specified package and cancels the
		/// background tasks associated with the package.
		/// </summary>
		/// <param name="packageFullName">The package full name.</param>
		/// <remarks>
		/// Use the <c>StartServicing</c> method to simulate what happens when a package is updated to a newer version. New background
		/// task activations are buffered (delayed) until you call the StopServicing method.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ipackagedebugsettings-startservicing
		// HRESULT StartServicing( LPCWSTR packageFullName );
		new void StartServicing([MarshalAs(UnmanagedType.LPWStr)] string packageFullName);

		/// <summary>Completes the previous servicing operation that was started by a call to the StartServicing method.</summary>
		/// <param name="packageFullName">The package full name.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ipackagedebugsettings-stopservicing HRESULT
		// StopServicing( LPCWSTR packageFullName );
		new void StopServicing([MarshalAs(UnmanagedType.LPWStr)] string packageFullName);

		/// <summary>Causes background tasks for the specified package to activate in the specified user session.</summary>
		/// <param name="packageFullName">The package full name.</param>
		/// <param name="sessionId">The identifier of the session which background tasks are redirected to.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ipackagedebugsettings-startsessionredirection
		// HRESULT StartSessionRedirection( LPCWSTR packageFullName, ULONG sessionId );
		new void StartSessionRedirection([MarshalAs(UnmanagedType.LPWStr)] string packageFullName, uint sessionId);

		/// <summary>Stops redirection of background tasks for the specified package.</summary>
		/// <param name="packageFullName">The package full name.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ipackagedebugsettings-stopsessionredirection
		// HRESULT StopSessionRedirection( LPCWSTR packageFullName );
		new void StopSessionRedirection([MarshalAs(UnmanagedType.LPWStr)] string packageFullName);

		/// <summary>Gets the state of the package execution.</summary>
		/// <param name="packageFullName">Full name of the package.</param>
		/// <returns>State of the package execution.</returns>
		new PACKAGE_EXECUTION_STATE GetPackageExecutionState([MarshalAs(UnmanagedType.LPWStr)] string packageFullName);

		/// <summary>Register for package state-change notifications.</summary>
		/// <param name="packageFullName">The package full name.</param>
		/// <param name="pPackageExecutionStateChangeNotification">
		/// Package state-change notifications are delivered by the OnStateChanged function on pPackageExecutionStateChangeNotification.
		/// </param>
		/// <param name="pdwCookie">
		/// A unique registration identifier for the current listener. Use this identifier to unregister for package state-change
		/// notifications by using the UnregisterForPackageStateChanges method.
		/// </param>
		/// <remarks>Notifications are raised when the package enters the running, suspending, and suspended states.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ipackagedebugsettings-registerforpackagestatechanges
		// HRESULT RegisterForPackageStateChanges( LPCWSTR packageFullName, IPackageExecutionStateChangeNotification
		// *pPackageExecutionStateChangeNotification, DWORD *pdwCookie );
		new void RegisterForPackageStateChanges([MarshalAs(UnmanagedType.LPWStr)] string packageFullName, IPackageExecutionStateChangeNotification pPackageExecutionStateChangeNotification, out uint pdwCookie);

		/// <summary>Stops receiving package state-change notifications associated with a previous call to RegisterForPackageStateChanges.</summary>
		/// <param name="dwCookie">
		/// The notification to cancel. This identifier is returned by a previous call to the RegisterForPackageStateChanges method.
		/// </param>
		/// <remarks>
		/// Call the <c>UnregisterForPackageStateChanges</c> to stop receiving package state-change notifications associated with a
		/// previous call to the RegisterForPackageStateChanges method.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ipackagedebugsettings-unregisterforpackagestatechanges
		// HRESULT UnregisterForPackageStateChanges( DWORD dwCookie );
		new void UnregisterForPackageStateChanges(uint dwCookie);

		/// <summary>Enumerates the apps.</summary>
		/// <param name="packageFullName">The package full name to query for apps.</param>
		/// <param name="appCount">The count of <paramref name="appUserModelIds"/> and <paramref name="appDisplayNames"/> entries.</param>
		/// <param name="appUserModelIds">The application user model ids.</param>
		/// <param name="appDisplayNames">The application display names.</param>
		void EnumerateApps([MarshalAs(UnmanagedType.LPWStr)] string packageFullName, out uint appCount,
			[Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr, SizeParamIndex = 1)] out string[] appUserModelIds,
			[Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr, SizeParamIndex = 1)] out string[] appDisplayNames);
	}

	/// <summary>Enables receiving package state-change notifications during Windows Store app debugging.</summary>
	/// <remarks>
	/// <para>
	/// Implement the <c>IPackageExecutionStateChangeNotification</c> interface when you need to receive package state-change
	/// notifications during Windows Store app debugging.
	/// </para>
	/// <para>Call the <see cref="IPackageDebugSettings.RegisterForPackageStateChanges"/> method to register for package state-change notifications.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-ipackageexecutionstatechangenotification
	[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.IPackageExecutionStateChangeNotification")]
	[ComImport, Guid("1BB12A62-2AD8-432B-8CCF-0C2C52AFCD5B"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IPackageExecutionStateChangeNotification
	{
		/// <summary>Called when package state changes during Windows Store app debugging.</summary>
		/// <param name="pszPackageFullName">The package full name.</param>
		/// <param name="pesNewState">The new state that the package changed to.</param>
		/// <returns>Return <c>S_OK</c> when you implement the <c>OnStateChanged</c> method.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ipackageexecutionstatechangenotification-onstatechanged
		// HRESULT OnStateChanged( LPCWSTR pszPackageFullName, PACKAGE_EXECUTION_STATE pesNewState );
		[PreserveSig]
		HRESULT OnStateChanged([MarshalAs(UnmanagedType.LPWStr)] string pszPackageFullName, PACKAGE_EXECUTION_STATE pesNewState);
	}

	/// <summary>CoClass for IPackageDebugSettings</summary>
	[PInvokeData("shobjidl.h")]
	[ComImport, Guid("B1AEC16F-2383-4852-B0E9-8F0B1DC66B4D"), ClassInterface(ClassInterfaceType.None)]
	public class PackageDebugSettings { }
}