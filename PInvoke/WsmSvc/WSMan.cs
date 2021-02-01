using System;
using System.Runtime.InteropServices;
using System.Text;
using Vanara.InteropServices;

namespace Vanara.PInvoke
{
	/// <summary>Items from the WsmSvc.dll</summary>
	public static partial class WsmSvc
	{
		/// <summary>Code page option name to be used with WSManCreateShell API to remotely set the code page</summary>
		public const string WSMAN_CMDSHELL_OPTION_CODEPAGE = "WINRS_CODEPAGE";

		/// <summary>
		/// Option name used with WSManRunShellCommand API to indicate that the client side mode of standard input is Console; default
		/// implies Pipe.
		/// </summary>
		public const string WSMAN_CMDSHELL_OPTION_CONSOLEMODE_STDIN = "WINRS_CONSOLEMODE_STDIN";

		/// <summary>To be used with WSManRunShellCommand API to not use cmd.exe /c prefix when launching the command</summary>
		public const string WSMAN_CMDSHELL_OPTION_SKIP_CMD_SHELL = "WINRS_SKIP_CMD_SHELL";

		/// <summary>pre-defined command states</summary>
		public const string WSMAN_COMMAND_STATE_DONE = "/CommandState/Done";

		/// <summary>pre-defined command states</summary>
		public const string WSMAN_COMMAND_STATE_PENDING = "/CommandState/Pending";

		/// <summary>pre-defined command states</summary>
		public const string WSMAN_COMMAND_STATE_RUNNING = "/CommandState/Running";

		/// <summary>Option name used with WSManCreateShell API to not load the user profile on the remote server</summary>
		public const string WSMAN_SHELL_OPTION_NOPROFILE = "WINRS_NOPROFILE";

		/// <summary/>
		public const string WSMAN_STREAM_ID_STDERR = "stderr";

		/// <summary/>
		public const string WSMAN_STREAM_ID_STDIN = "stdin";

		/// <summary/>
		public const string WSMAN_STREAM_ID_STDOUT = "stdout";

		private const string Lib_WsmSvc = "WsmSvc.dll";

		/// <summary>
		/// <para>Authorizes a specific operation.</para>
		/// <para>The DLL entry point name for this method must be <c>WSManPluginAuthzOperation</c>.</para>
		/// </summary>
		/// <param name="pluginContext">
		/// Specifies the context that was returned by a call to WSManPluginStartup. This parameter represents a specific application
		/// initialization of a WinRM plug-in.
		/// </param>
		/// <param name="senderDetails"/>
		/// <param name="flags">Reserved for future use. Must be set to zero.</param>
		/// <param name="operation">
		/// <para>Represents the operation that is being performed. This parameter can be one of the following values:</para>
		/// <para>Get</para>
		/// <para>WSManOperationGet</para>
		/// <para>Put</para>
		/// <para>WSManOperationPut</para>
		/// <para>Create</para>
		/// <para>WSManOperationCreate</para>
		/// <para>Delete</para>
		/// <para>WSManOperationDelete</para>
		/// <para>Enumerate</para>
		/// <para>WSManOperationEnumerate</para>
		/// <para>Subscribe</para>
		/// <para>WSManOperationSubscribe</para>
		/// <para>Shell</para>
		/// <para>WSManOperationShell</para>
		/// <para>Command</para>
		/// <para>WSManOperationCommand</para>
		/// <para>Invoke</para>
		/// <para>WSManOperationInvoke</para>
		/// </param>
		/// <param name="action">
		/// <para>Specifies the action of the request received. This parameter can be one of the following values:</para>
		/// <para>Get</para>
		/// <para>http://schemas.xmlsoap.org/ws/2004/09/transfer/Get</para>
		/// <para>Put</para>
		/// <para>http://schemas.xmlsoap.org/ws/2004/09/transfer/Put</para>
		/// <para>Create</para>
		/// <para>http://schemas.xmlsoap.org/ws/2004/09/transfer/Create</para>
		/// <para><c>Note</c> Shell creation will appear as Create.</para>
		/// <para>Delete</para>
		/// <para>http://schemas.xmlsoap.org/ws/2004/09/transfer/Delete</para>
		/// <para>Enumerate</para>
		/// <para>http://schemas.xmlsoap.org/ws/2004/09/enumeration/Enumerate</para>
		/// <para>Subscribe</para>
		/// <para>http://schemas.xmlsoap.org/ws/2004/08/eventing/Subscribe</para>
		/// <para>Command</para>
		/// <para>http://schemas.microsoft.com/wbem/wsman/1/windows/shell/Command</para>
		/// <para>Invoke</para>
		/// <para>This operation will have a custom string.</para>
		/// </param>
		/// <param name="resourceUri">Specifies the resource URI of the inbound operation.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// The plug-in must call WSManPluginAuthzOperationComplete to report either that the user was successfully authorized to perform
		/// the operation with <c>NO_ERROR</c> or that the user was not authorized with <c>ERROR_ACCESS_DENIED</c>. All other errors report
		/// a failure to the client, but no specific information is reported.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/nc-wsman-wsman_plugin_authorize_operation
		// WSMAN_PLUGIN_AUTHORIZE_OPERATION WsmanPluginAuthorizeOperation; void WsmanPluginAuthorizeOperation( PVOID pluginContext,
		// WSMAN_SENDER_DETAILS *senderDetails, DWORD flags, DWORD operation, PCWSTR action, PCWSTR resourceUri ) {...}
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		[PInvokeData("wsman.h", MSDNShortId = "NC:wsman.WSMAN_PLUGIN_AUTHORIZE_OPERATION")]
		public delegate void WSMAN_PLUGIN_AUTHORIZE_OPERATION([In] IntPtr pluginContext, in WSMAN_SENDER_DETAILS senderDetails,
			[Optional] uint flags, uint operation, [MarshalAs(UnmanagedType.LPWStr)] string action,
			[MarshalAs(UnmanagedType.LPWStr)] string resourceUri);

		/// <summary>
		/// <para>
		/// Retrieves quota information for the user after a connection has been authorized. This method will be called only if the
		/// configuration specifies that quotas are enabled within the authorization plug-in.
		/// </para>
		/// <para>The DLL entry point name for this method must be <c>WSManPluginAuthzQueryQuota</c>.</para>
		/// </summary>
		/// <param name="pluginContext">
		/// Specifies the context that was returned by a call to WSManPluginStartup. This parameter represents a specific application
		/// initialization of a WinRM plug-in.
		/// </param>
		/// <param name="senderDetails"/>
		/// <param name="flags">Reserved for future use. Must be zero.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The quota is queried on the first call by a particular user and will not be requeried until after the user record times out due
		/// to an idle time-out of activity or until a system-wide configuration period is exceeded.
		/// </para>
		/// <para>
		/// The plug-in must call the WSManPluginAuthzQueryQuotaComplete function to terminate the operation whether or not the plug-in can
		/// carry out the request. If successful, the plug-in should give a set of quota information that is relevant for this particular
		/// user. If the plug-in fails to process the request for any reason, an appropriate error should be recorded through the callback
		/// method and the error will get propagated back to the client as a Simple Object Access Protocol (SOAP) fault if possible;
		/// otherwise, the error will be an empty HTTP 500 status error.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/nc-wsman-wsman_plugin_authorize_query_quota
		// WSMAN_PLUGIN_AUTHORIZE_QUERY_QUOTA WsmanPluginAuthorizeQueryQuota; void WsmanPluginAuthorizeQueryQuota( PVOID pluginContext,
		// WSMAN_SENDER_DETAILS *senderDetails, DWORD flags ) {...}
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		[PInvokeData("wsman.h", MSDNShortId = "NC:wsman.WSMAN_PLUGIN_AUTHORIZE_QUERY_QUOTA")]
		public delegate void WSMAN_PLUGIN_AUTHORIZE_QUERY_QUOTA(IntPtr pluginContext, in WSMAN_SENDER_DETAILS senderDetails, uint flags);

		/// <summary>
		/// <para>
		/// Releases the context that a plug-in reports from either WSManPluginAuthzUserComplete or WSManPluginAuthzOperationComplete. For a
		/// particular user, the context reported for both calls is allowed to be the same, as long as the plug-in infrastructure handles
		/// the scenario appropriately. This method is synchronous, and there are no callbacks that are called as a result.
		/// </para>
		/// <para>This method will be called under the following scenarios:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// After the operation is complete, the WSManPluginAuthzOperationComplete context is released. For some operations, such as get,
		/// the context will be released after the response is sent for the get operation. For more complex operations, such as enumeration,
		/// the context will not be released until the enumeration has completed.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// When the user record times out due to inactivity, the WSManPluginAuthzUser method will be called again the next time a request
		/// comes in for that user.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// If re-authorization needs to occur, the old context will be released after the new one is acquired. The old context will always
		/// be released regardless of whether the authorization succeeds.
		/// </term>
		/// </item>
		/// </list>
		/// <para>The DLL entry point name for this method must be <c>WSManPluginAuthzReleaseContext</c>.</para>
		/// </summary>
		/// <param name="userAuthorizationContext">
		/// Specifies the context that was returned by either WSManPluginAuthzUserComplete or WSManPluginAuthzOperationComplete. If these
		/// methods return no context, this method will not be called.
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/nc-wsman-wsman_plugin_authorize_release_context
		// WSMAN_PLUGIN_AUTHORIZE_RELEASE_CONTEXT WsmanPluginAuthorizeReleaseContext; void WsmanPluginAuthorizeReleaseContext( PVOID
		// userAuthorizationContext ) {...}
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		[PInvokeData("wsman.h", MSDNShortId = "NC:wsman.WSMAN_PLUGIN_AUTHORIZE_RELEASE_CONTEXT")]
		public delegate void WSMAN_PLUGIN_AUTHORIZE_RELEASE_CONTEXT(IntPtr userAuthorizationContext);

		/// <summary>
		/// <para>
		/// Authorizes a connection. The plug-in should verify that this user is allowed to perform any operations. If the user is allowed
		/// to perform operations, the plug-in must report a success. If the user is not allowed to carry out any type of operation, a
		/// failure must be returned.
		/// </para>
		/// <para>
		/// Every new connection does not need to be authorized. After a user has been authorized to connect, a user record is created to
		/// track the activities of the user. While that record exists, all new connections will automatically be authorized. The user
		/// record will time-out after a configurable amount of time after no activity is detected.
		/// </para>
		/// <para>The DLL entry point name for this method must be <c>WSManPluginAuthzUser</c>.</para>
		/// </summary>
		/// <param name="pluginContext">
		/// Specifies the context that was returned by a call to WSManPluginStartup. This parameter represents a specific application
		/// initialization of a WinRM plug-in.
		/// </param>
		/// <param name="senderDetails"/>
		/// <param name="flags">Reserved for future use. Must be set to zero.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// The plug-in must call WSManPluginAuthzUserComplete to report either that the user was successfully authorized with
		/// <c>NO_ERROR</c> or that the user was not authorized with <c>ERROR_ACCESS_DENIED</c>. An <c>ERROR_WSMAN_REDIRECT_REQUIRED</c>
		/// error should be reported if an HTTP redirect is required for this user, and the new HTTP URI should be recorded in
		/// extendedErrorInformation of the <c>WSManPluginAuthzUserComplete</c> method. All other errors report a failure to the client, but
		/// no specific information is reported.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/nc-wsman-wsman_plugin_authorize_user WSMAN_PLUGIN_AUTHORIZE_USER
		// WsmanPluginAuthorizeUser; void WsmanPluginAuthorizeUser( PVOID pluginContext, WSMAN_SENDER_DETAILS *senderDetails, DWORD flags ) {...}
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		[PInvokeData("wsman.h", MSDNShortId = "NC:wsman.WSMAN_PLUGIN_AUTHORIZE_USER")]
		public delegate void WSMAN_PLUGIN_AUTHORIZE_USER(IntPtr pluginContext, in WSMAN_SENDER_DETAILS senderDetails, uint flags);

		/// <summary>
		/// <para>
		/// Defines the command callback for a plug-in. This function is called when a request for a command is received. All Windows Remote
		/// Management plug-ins that support shell operations and need to create commands must implement this callback.
		/// </para>
		/// <para>The DLL entry point name must be <c>WSManPluginCommand</c>.</para>
		/// </summary>
		/// <param name="requestDetails"/>
		/// <param name="flags">Reserved for future use. Must be set to zero.</param>
		/// <param name="shellContext">Specifies the context returned from creating the shell for which this command needs to be associated.</param>
		/// <param name="commandLine">Specifies the command line to be run.</param>
		/// <param name="arguments"/>
		/// <returns>None</returns>
		/// <remarks>
		/// The WinRM (WinRM) plug-in will call the WSManPluginReportContext method to register a command context for the command. All
		/// operations on this command are passed into this context. The context must be valid until the WSManPluginOperationComplete method
		/// is called by the plug-in to indicate that either the command is complete or the shell was shut down. All parameters passed in
		/// are valid until the WinRM plug-in calls <c>WSManPluginOperationComplete</c>.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/nc-wsman-wsman_plugin_command WSMAN_PLUGIN_COMMAND WsmanPluginCommand;
		// void WsmanPluginCommand( WSMAN_PLUGIN_REQUEST *requestDetails, DWORD flags, PVOID shellContext, PCWSTR commandLine,
		// WSMAN_COMMAND_ARG_SET *arguments ) {...}
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		[PInvokeData("wsman.h", MSDNShortId = "NC:wsman.WSMAN_PLUGIN_COMMAND")]
		public delegate void WSMAN_PLUGIN_COMMAND(in WSMAN_PLUGIN_REQUEST requestDetails, uint flags, IntPtr shellContext,
			[MarshalAs(UnmanagedType.LPWStr)] string commandLine, IntPtr arguments);

		/// <summary>
		/// <para>Defines the connect callback for a plug-in.</para>
		/// <para>The DLL entry point name must be <c>WSManPluginConnect</c>.</para>
		/// </summary>
		/// <param name="requestDetails"/>
		/// <param name="flags">Reserved for future use. Must be set to zero.</param>
		/// <param name="shellContext">
		/// Specifies the context returned from creating the shell for which this connection request needs to be associated.
		/// </param>
		/// <param name="commandContext">
		/// If this request is aimed at a command and not a shell, this is the context returned from the <c>winrm create</c> operation;
		/// otherwise, this parameter is <c>NULL</c>.
		/// </param>
		/// <param name="inboundConnectInformation"/>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/nc-wsman-wsman_plugin_connect WSMAN_PLUGIN_CONNECT WsmanPluginConnect;
		// void WsmanPluginConnect( WSMAN_PLUGIN_REQUEST *requestDetails, DWORD flags, PVOID shellContext, PVOID commandContext, WSMAN_DATA
		// *inboundConnectInformation ) {...}
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		[PInvokeData("wsman.h", MSDNShortId = "NC:wsman.WSMAN_PLUGIN_CONNECT")]
		public delegate void WSMAN_PLUGIN_CONNECT(in WSMAN_PLUGIN_REQUEST requestDetails, uint flags, IntPtr shellContext,
			IntPtr commandContext, IntPtr inboundConnectInformation);

		/// <summary>
		/// <para>Defines the receive callback for a plug-in. This function is called when an inbound request to receive data is received.</para>
		/// <para>The DLL entry point name must be <c>WSManPluginReceive</c>.</para>
		/// </summary>
		/// <param name="requestDetails"/>
		/// <param name="flags">Reserved for future use. Must be zero.</param>
		/// <param name="shellContext">Specifies the context that was received when the shell was created.</param>
		/// <param name="commandContext">
		/// If this request is aimed at a command and not a shell, this is the context returned from the <c>winrm create</c> operation;
		/// otherwise, this parameter is <c>NULL</c>.
		/// </param>
		/// <param name="streamSet"/>
		/// <returns>None</returns>
		/// <remarks>
		/// Based on the client request, the <c>WSMAN_PLUGIN_RECEIVE</c> callback function can be called against the shell and/or the
		/// command. The plug-in calls the WSManPluginReceiveResult method for each piece of data that needs to be sent back to the client.
		/// After all of the data has been sent, the plug-in calls WSManPluginOperationComplete to end the stream. All parameters passed in
		/// are valid until the Windows Remote Management (WinRM) plug-in calls <c>WSManPluginOperationComplete</c>.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/nc-wsman-wsman_plugin_receive WSMAN_PLUGIN_RECEIVE WsmanPluginReceive;
		// void WsmanPluginReceive( WSMAN_PLUGIN_REQUEST *requestDetails, DWORD flags, PVOID shellContext, PVOID commandContext,
		// WSMAN_STREAM_ID_SET *streamSet ) {...}
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		[PInvokeData("wsman.h", MSDNShortId = "NC:wsman.WSMAN_PLUGIN_RECEIVE")]
		public delegate void WSMAN_PLUGIN_RECEIVE(in WSMAN_PLUGIN_REQUEST requestDetails, uint flags, IntPtr shellContext,
			IntPtr commandContext, IntPtr streamSet);

		/// <summary>
		/// <para>Defines the release command callback for the plug-in. This function is called to delete the plug-in command context.</para>
		/// <para>The DLL entry point name must be <c>WSManPluginReleaseCommandContext</c>.</para>
		/// </summary>
		/// <param name="shellContext">Specifies the context that was received when the shell was created.</param>
		/// <param name="commandContext">
		/// If this request is aimed at a command and not a shell, this is the context returned from the <c>winrm create</c> operation;
		/// otherwise, this parameter is <c>NULL</c>.
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/nc-wsman-wsman_plugin_release_command_context
		// WSMAN_PLUGIN_RELEASE_COMMAND_CONTEXT WsmanPluginReleaseCommandContext; void WsmanPluginReleaseCommandContext( PVOID shellContext,
		// PVOID commandContext ) {...}
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		[PInvokeData("wsman.h", MSDNShortId = "NC:wsman.WSMAN_PLUGIN_RELEASE_COMMAND_CONTEXT")]
		public delegate void WSMAN_PLUGIN_RELEASE_COMMAND_CONTEXT(IntPtr shellContext, IntPtr commandContext);

		/// <summary>
		/// <para>Defines the release shell callback for the plug-in. This function is called to delete the plug-in shell context.</para>
		/// <para>The DLL entry point name must be WSManPluginReleaseCommandContext.</para>
		/// </summary>
		/// <param name="shellContext">Specifies the context that was received when the shell was created.</param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/nc-wsman-wsman_plugin_release_shell_context
		// WSMAN_PLUGIN_RELEASE_SHELL_CONTEXT WsmanPluginReleaseShellContext; void WsmanPluginReleaseShellContext( PVOID shellContext ) {...}
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		[PInvokeData("wsman.h", MSDNShortId = "NC:wsman.WSMAN_PLUGIN_RELEASE_SHELL_CONTEXT")]
		public delegate void WSMAN_PLUGIN_RELEASE_SHELL_CONTEXT(IntPtr shellContext);

		/// <summary>
		/// <para>
		/// Defines the send callback for a plug-in. This function is called for each object that is received from a client. Each object
		/// received causes the callback to be called once. After the data is processed, the Windows Remote Management (WinRM) plug-in calls
		/// WSManPluginOperationComplete to acknowledge receipt and to allow the next object to be delivered.
		/// </para>
		/// <para>The DLL entry point name must be <c>WSManPluginSend</c>.</para>
		/// </summary>
		/// <param name="requestDetails"/>
		/// <param name="flags">
		/// If this is the last object for the stream, this parameter is set to <c>WSMAN_FLAG_NO_MORE_DATA</c>. Otherwise, it is set to zero.
		/// </param>
		/// <param name="shellContext">Specifies the context that was received when the shell was created.</param>
		/// <param name="commandContext">
		/// If this request is aimed at a command and not a shell, this is the context returned from the <c>winrm create</c> operation;
		/// otherwise, this parameter is <c>NULL</c>.
		/// </param>
		/// <param name="stream">Specifies the stream that is associated with the inbound object.</param>
		/// <param name="inboundData"/>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/nc-wsman-wsman_plugin_send WSMAN_PLUGIN_SEND WsmanPluginSend; void
		// WsmanPluginSend( WSMAN_PLUGIN_REQUEST *requestDetails, DWORD flags, PVOID shellContext, PVOID commandContext, PCWSTR stream,
		// WSMAN_DATA *inboundData ) {...}
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		[PInvokeData("wsman.h", MSDNShortId = "NC:wsman.WSMAN_PLUGIN_SEND")]
		public delegate void WSMAN_PLUGIN_SEND(in WSMAN_PLUGIN_REQUEST requestDetails, uint flags, IntPtr shellContext,
			IntPtr commandContext, [MarshalAs(UnmanagedType.LPWStr)] string stream, in WSMAN_DATA inboundData);

		/// <summary>
		/// <para>
		/// Defines the shell callback for a plug-in. This function is called when a request for a new shell is received. All Windows Remote
		/// Management plug-ins that support shell operations need to implement this callback.
		/// </para>
		/// <para>The DLL entry point name must be <c>WSManPluginShell</c>.</para>
		/// </summary>
		/// <param name="pluginContext">
		/// Specifies the context that was returned by a call to the WSManPluginStartup method. This parameter represents a specific
		/// application initialization of a WinRM plug-in.
		/// </param>
		/// <param name="requestDetails"/>
		/// <param name="flags">Reserved for future use. Must be set to zero.</param>
		/// <param name="startupInfo"/>
		/// <param name="inboundShellInformation"/>
		/// <returns>None</returns>
		/// <remarks>
		/// The WinRM (WinRM) plug-in calls WSManPluginReportContext to register a shell context for the shell. All operations on this shell
		/// pass into this context. If the shell has shut down or the plug-in checks the requestDetails parameter and reports that the
		/// operation was canceled, the plug-in should call WSManPluginOperationComplete. All parameters passed in are valid until the WinRM
		/// plug-in calls <c>WSManPluginOperationComplete</c>.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/nc-wsman-wsman_plugin_shell WSMAN_PLUGIN_SHELL WsmanPluginShell; void
		// WsmanPluginShell( PVOID pluginContext, WSMAN_PLUGIN_REQUEST *requestDetails, DWORD flags, WSMAN_SHELL_STARTUP_INFO *startupInfo,
		// WSMAN_DATA *inboundShellInformation ) {...}
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		[PInvokeData("wsman.h", MSDNShortId = "NC:wsman.WSMAN_PLUGIN_SHELL")]
		public delegate void WSMAN_PLUGIN_SHELL(IntPtr pluginContext, in WSMAN_PLUGIN_REQUEST requestDetails, uint flags,
			IntPtr startupInfo, IntPtr inboundShellInformation);

		/// <summary>
		/// <para>
		/// Defines the shutdown callback for the plug-in. This function is called after all operations have been canceled and before the
		/// Windows Remote Management plug-in DLL is unloaded. All WinRM plug-ins must implement this callback function.
		/// </para>
		/// <para>The DLL entry point name must be <c>WSManPluginShutdown</c>.</para>
		/// </summary>
		/// <param name="pluginContext">
		/// Specifies the context that was returned by a call to the WSManPluginStartup method. This parameter represents a specific
		/// application initialization of a WinRM plug-in. The shutdown entry point will be called for each application that initialized it.
		/// </param>
		/// <param name="flags">Reserved for future use. Must be set to zero.</param>
		/// <param name="reason">
		/// <para>Specifies the reason that the plug-in is shutting down.</para>
		/// <para>WSMAN_PLUGIN_SHUTDOWN_SYSTEM</para>
		/// <para>The system shut down.</para>
		/// <para>WSMAN_PLUGIN_SHUTDOWN_SERVICE</para>
		/// <para>The WinRM service shut down.</para>
		/// <para>WSMAN_PLUGIN_SHUTDOWN_IISHOST</para>
		/// <para>The IIS host shut down.</para>
		/// </param>
		/// <returns>
		/// <para>The method returns <c>NO_ERROR</c> if it succeeded; otherwise, it returns an error code.</para>
		/// <para><c>Note</c> If this method fails, the plug-in will not call back in.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Each successful call to WSManPluginStartup will result in a call to this function before the WinRM plug-in DLL is unloaded. It
		/// is important to ensure that the WinRM plug-in tracks the number of times that this startup entry point is called so that the
		/// plug-in is not shut down prematurely.
		/// </para>
		/// <para>
		/// This function must ensure that all plug-in threads are shut down before it returns. If the plug-in handles only synchronous
		/// operations and all threads report a cancellation result before they return, this function performs only plug-in cleanup.
		/// However, for an asynchronous plug-in, any threads that are used to process the plug-in threads, including the ones that just
		/// reported the cancellation for all operations, need to be completely shut down. If all of the threads are not shut down, crashes
		/// in the DLL might occur because code might be executed after the DLL is unloaded.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/nc-wsman-wsman_plugin_shutdown WSMAN_PLUGIN_SHUTDOWN
		// WsmanPluginShutdown; DWORD WsmanPluginShutdown( PVOID pluginContext, DWORD flags, DWORD reason ) {...}
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		[PInvokeData("wsman.h", MSDNShortId = "NC:wsman.WSMAN_PLUGIN_SHUTDOWN")]
		public delegate uint WSMAN_PLUGIN_SHUTDOWN(IntPtr pluginContext, uint flags, WSMAN_SHUTDOWN reason);

		/// <summary>
		/// <para>Defines the signal callback for a plug-in. This function is called when an inbound signal is received from a client call.</para>
		/// <para>The DLL entry point name for this method must be <c>WSManPluginSignal</c>.</para>
		/// </summary>
		/// <param name="requestDetails"/>
		/// <param name="flags">Reserved for future use. Must be zero.</param>
		/// <param name="shellContext">Specifies the context that was received when the shell was created.</param>
		/// <param name="commandContext">
		/// If this request is aimed at a command and not a shell, this is the context returned from the <c>winrm create</c> operation;
		/// otherwise, this parameter is <c>NULL</c>.
		/// </param>
		/// <param name="code">
		/// <para>Specifies the signal that is received from the client. The following codes are common.</para>
		/// <para>WSMAN_SIGNAL_SHELL_CODE_TERMINATE</para>
		/// <para>The shell or Command Prompt window was closed. The plug-in should call the WSManPluginOperationComplete function.</para>
		/// <para>WSMAN_SIGNAL_SHELL_CODE_CTRL_C</para>
		/// <para>
		/// The signal for CTRL+C was received, and the process was halted. The plug-in should call the WSManPluginOperationComplete function.
		/// </para>
		/// <para>WSMAN_SIGNAL_SHELL_CODE_CTRL_BREAK</para>
		/// <para>
		/// The signal for CTRL+BREAK was received, and the process was halted. The plug-in should call the WSManPluginOperationComplete function.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// A signal can be received for processing a CTRL+C sequence or one of many other types of custom signals. The callback is called
		/// once for each signal that is received. The plug-in determines which signals cause commands and/or shells to be shut down.
		/// Because signals are shell-specific, the plug-in must initiate the shutdown by calling the WSManPluginOperationComplete method.
		/// For each call, the plug-in should call <c>WSManPluginOperationComplete</c> to acknowledge receipt and to allow the next signal
		/// to be received.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/nc-wsman-wsman_plugin_signal WSMAN_PLUGIN_SIGNAL WsmanPluginSignal; void
		// WsmanPluginSignal( WSMAN_PLUGIN_REQUEST *requestDetails, DWORD flags, PVOID shellContext, PVOID commandContext, PCWSTR code ) {...}
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		[PInvokeData("wsman.h", MSDNShortId = "NC:wsman.WSMAN_PLUGIN_SIGNAL")]
		public delegate void WSMAN_PLUGIN_SIGNAL(in WSMAN_PLUGIN_REQUEST requestDetails, uint flags, IntPtr shellContext,
			IntPtr commandContext, [MarshalAs(UnmanagedType.LPWStr)] string code);

		/// <summary>
		/// <para>
		/// Defines the startup callback for the plug-in. Because multiple applications can be hosted in the same process, this method can
		/// be called multiple times, but only once for each application initialization. A plug-in can be initialized more than once within
		/// the same process but only once for each applicationIdentification value. The context that is returned from this method should be
		/// application specific. The returned context will be passed into all future plug-in calls that are specific to the application.
		/// All Windows Remote Management (WinRM) plug-ins must implement this callback function.
		/// </para>
		/// <para>The DLL entry point name for this method must be <c>WSManPluginStartup</c>.</para>
		/// </summary>
		/// <param name="flags">Reserved for future use. Must be zero.</param>
		/// <param name="applicationIdentification">
		/// A unique identifier for the hosted application. For the main WinRM service, the default is <c>wsman</c>. For an Internet
		/// Information Services (IIS) host, this identifier is related to the application endpoint for that host. For example, <c>wsman/MyCompany/MyApplication</c>.
		/// </param>
		/// <param name="extraInfo">
		/// A string that contains configuration information, if any information was stored when the plug-in was registered. When the
		/// plug-in is registered using the WinRM configuration, the plug-in can add extra configuration parameters that are useful during
		/// initialization to an optional node. This information can be especially useful if a plug-in is used in different IIS hosting
		/// scenarios and requires slightly different run-time semantics during initialization. This string is a copy of the XML from the
		/// configuration, if one is present. Otherwise, this parameter is set to <c>NULL</c>.
		/// </param>
		/// <param name="pluginContext"/>
		/// <returns>
		/// The method returns <c>NO_ERROR</c> if it succeeded; otherwise, it returns an error code. If this method returns an error, the
		/// WSManPluginShutdown entry point will not be called.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/nc-wsman-wsman_plugin_startup WSMAN_PLUGIN_STARTUP WsmanPluginStartup;
		// DWORD WsmanPluginStartup( DWORD flags, PCWSTR applicationIdentification, PCWSTR extraInfo, PVOID *pluginContext ) {...}
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		[PInvokeData("wsman.h", MSDNShortId = "NC:wsman.WSMAN_PLUGIN_STARTUP")]
		public delegate uint WSMAN_PLUGIN_STARTUP(uint flags, [MarshalAs(UnmanagedType.LPWStr)] string applicationIdentification,
			[Optional, MarshalAs(UnmanagedType.LPWStr)] string extraInfo, out IntPtr pluginContext);

		/// <summary>The callback function that is called for shell operations, which result in a remote request.</summary>
		/// <param name="operationContext">
		/// Represents user-defined context passed to the WinRM (WinRM) Client Shell application programming interface (API) .
		/// </param>
		/// <param name="flags">Specifies one or more flags from the WSManCallbackFlags enumeration.</param>
		/// <param name="error"/>
		/// <param name="shell">
		/// Specifies the shell handle associated with the user context. The shell handle must be closed by calling the WSManCloseShell method.
		/// </param>
		/// <param name="command">
		/// Specifies the command handle associated with the user context. The command handle must be closed by calling the
		/// WSManCloseCommand API method.
		/// </param>
		/// <param name="operationHandle">
		/// Defines the operation handle associated with the user context. The operation handle is valid only for callbacks that are
		/// associated with WSManReceiveShellOutput, WSManSendShellInput, and WSManSignalShell calls. This handle must be closed by calling
		/// the WSManCloseOperation method.
		/// </param>
		/// <param name="data"/>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/nc-wsman-wsman_shell_completion_function WSMAN_SHELL_COMPLETION_FUNCTION
		// WsmanShellCompletionFunction; void WsmanShellCompletionFunction( PVOID operationContext, DWORD flags, WSMAN_ERROR *error,
		// WSMAN_SHELL_HANDLE shell, WSMAN_COMMAND_HANDLE command, WSMAN_OPERATION_HANDLE operationHandle, WSMAN_RESPONSE_DATA *data ) {...}
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		[PInvokeData("wsman.h", MSDNShortId = "NC:wsman.WSMAN_SHELL_COMPLETION_FUNCTION")]
		public delegate void WSMAN_SHELL_COMPLETION_FUNCTION(IntPtr operationContext, WSManCallbackFlags flags, in WSMAN_ERROR error,
			[In, Optional] WSMAN_SHELL_HANDLE shell, [In, Optional] WSMAN_COMMAND_HANDLE command, [In, Optional] WSMAN_OPERATION_HANDLE operationHandle,
			[In, Optional] IntPtr data);

		/// <summary>Flags for <see cref="WSManInitialize"/>.</summary>
		[PInvokeData("wsman.h", MSDNShortId = "NF:wsman.WSManInitialize")]
		public enum WSMAN_FLAG_REQUESTED_API_VERSION
		{
			/// <summary/>
			WSMAN_FLAG_REQUESTED_API_VERSION_1_0 = 0x0,

			/// <summary>For clients that will use the disconnect-reconnect functionality.</summary>
			WSMAN_FLAG_REQUESTED_API_VERSION_1_1 = 0x1
		}

		/// <summary/>
		[Flags]
		public enum WSMAN_FLAG_SERVER_BUFFERING_MODE : uint
		{
			/// <summary>
			/// Turn off compression for Send/Receive operations. By default compression is turned on, but if communicating with a
			/// down-level box it may be necessary to do this. Other reasons for turning it off is due to the extra memory consumption and
			/// CPU utilization that is used as a result of compression.
			/// </summary>
			WSMAN_FLAG_NO_COMPRESSION = 0x1,

			/// <summary/>
			WSMAN_FLAG_DELETE_SERVER_SESSION = 0x2,

			/// <summary>Enable the service to drop operation output when running disconnected.</summary>
			WSMAN_FLAG_SERVER_BUFFERING_MODE_DROP = 0x4,

			/// <summary>Enable the service to block operation progress when output buffers are full.</summary>
			WSMAN_FLAG_SERVER_BUFFERING_MODE_BLOCK = 0x8,

			/// <summary>Enable receive call to not immediately retrieve results. Only applicable for Receive calls on commands</summary>
			WSMAN_FLAG_RECEIVE_DELAY_OUTPUT_STREAM = 0X10
		}

		/// <summary>Specifies the options that are available for retrieval.</summary>
		[PInvokeData("wsman.h", MSDNShortId = "NF:wsman.WSManPluginGetOperationParameters")]
		public enum WSMAN_PLUGIN_PARAMS_OP
		{
			/// <summary>
			/// <para>
			/// Specifies the maximum size of the operation response packet. The size includes the size of the data along with the Simple
			/// Object Access Protocol (SOAP) overhead.
			/// </para>
			/// <para>
			/// <c>Note</c> Some operations have a single call into the plug-in that can cause multiple roundtrips to occur. If no requests
			/// are waiting for data when this method is called, the maximum envelope size for the previous packet is given.
			/// </para>
			/// </summary>
			WSMAN_PLUGIN_PARAMS_MAX_ENVELOPE_SIZE = 1,

			/// <summary>
			/// <para>Specifies the time-out of the current operation.</para>
			/// <para>
			/// <c>Note</c> Some operations have a single call into the plug-in that can cause multiple roundtrips to occur. If no requests
			/// are waiting for data when this method is called, the time-out for the previous packet is given.
			/// </para>
			/// </summary>
			WSMAN_PLUGIN_PARAMS_TIMEOUT = 2,

			/// <summary>
			/// <para>
			/// Specifies how much space is left for data for the current operation. The size is based on the type of operation. For
			/// example, this flag would represent how large the single result item can be for a get operation. For enumerations, the size
			/// will decrease after each object is added. After the current packet has been filled with enumerations and get operations, it
			/// will be returned to the client even though more data is being accepted and cached.
			/// </para>
			/// <para>
			/// <c>Note</c> Some operations have a single call into the plug-in that can cause multiple roundtrips to occur. If no requests
			/// are waiting for data when this method is called, the remaining size is given for a cached item.
			/// </para>
			/// </summary>
			WSMAN_PLUGIN_PARAMS_REMAINING_RESULT_SIZE = 3,

			/// <summary>Specifies the maximum size of the data for the current operation.</summary>
			WSMAN_PLUGIN_PARAMS_LARGEST_RESULT_SIZE = 4,

			/// <summary>Specifies the language locale that was requested by the client for the operation.</summary>
			WSMAN_PLUGIN_PARAMS_GET_REQUESTED_LOCALE = 5, /* Returns WSMAN_DATA_TEXT */

			/// <summary>Specifies the language locale of the data that was requested by the client.</summary>
			WSMAN_PLUGIN_PARAMS_GET_REQUESTED_DATA_LOCALE = 6, /* Returns WSMAN_DATA_TEXT */
		}

		/// <summary>Specifies the reason that the plug-in is shutting down.</summary>
		[PInvokeData("wsman.h", MSDNShortId = "NC:wsman.WSMAN_PLUGIN_SHUTDOWN")]
		public enum WSMAN_SHUTDOWN
		{
			/// <summary>The system shut down.</summary>
			WSMAN_PLUGIN_SHUTDOWN_SYSTEM = 1,

			/// <summary>The WinRM service shut down.</summary>
			WSMAN_PLUGIN_SHUTDOWN_SERVICE = 2,

			/// <summary>The IIS host shut down.</summary>
			WSMAN_PLUGIN_SHUTDOWN_IISHOST = 3,

			/// <summary/>
			WSMAN_PLUGIN_SHUTDOWN_IDLETIMEOUT_ELAPSED = 4,
		}

		/// <summary>Determines the authentication method for the operation.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/ne-wsman-wsmanauthenticationflags typedef enum WSManAuthenticationFlags
		// { WSMAN_FLAG_DEFAULT_AUTHENTICATION, WSMAN_FLAG_NO_AUTHENTICATION, WSMAN_FLAG_AUTH_DIGEST, WSMAN_FLAG_AUTH_NEGOTIATE,
		// WSMAN_FLAG_AUTH_BASIC, WSMAN_FLAG_AUTH_KERBEROS, WSMAN_FLAG_AUTH_CREDSSP, WSMAN_FLAG_AUTH_CLIENT_CERTIFICATE } ;
		[PInvokeData("wsman.h", MSDNShortId = "NE:wsman.WSManAuthenticationFlags")]
		[Flags]
		public enum WSManAuthenticationFlags
		{
			/// <summary>Use the default authentication.</summary>
			WSMAN_FLAG_DEFAULT_AUTHENTICATION = 0x0,

			/// <summary>Use no authentication for a remote operation.</summary>
			WSMAN_FLAG_NO_AUTHENTICATION = 0x1,

			/// <summary>
			/// Use Digest authentication. Only the client computer can initiate a Digest authentication request. The client sends a request
			/// to the server to authenticate and receives from the server a token string. The client then sends the resource request,
			/// including the user name and a cryptographic hash of the password combined with the token string. Digest authentication is
			/// supported for HTTP and HTTPS. WinRM Shell client scripts and applications can specify Digest authentication, but the service cannot.
			/// </summary>
			WSMAN_FLAG_AUTH_DIGEST = 0x2,

			/// <summary>
			/// Use Negotiate authentication. The client sends a request to the server to authenticate. The server determines whether to use
			/// Kerberos or NTLM. In general, Kerberos is selected to authenticate a domain account and NTLM is selected for local computer
			/// accounts. But there are also some special cases in which Kerberos/NTLM are selected. The user name should be specified in
			/// the form DOMAIN\username for a domain user or SERVERNAME\username for a local user on a server computer.
			/// </summary>
			WSMAN_FLAG_AUTH_NEGOTIATE = 0x4,

			/// <summary>
			/// Use Basic authentication. The client presents credentials in the form of a user name and password that are directly
			/// transmitted in the request message. You can specify the credentials only of a local administrator account on the remote computer.
			/// </summary>
			WSMAN_FLAG_AUTH_BASIC = 0x8,

			/// <summary>Use Kerberos authentication. The client and server mutually authenticate by using Kerberos certificates.</summary>
			WSMAN_FLAG_AUTH_KERBEROS = 0x10,

			/// <summary>
			/// Use CredSSP authentication for a remote operation. If a certificate from the local machine is used to authenticate the
			/// server, the Network service must be allowed access to the private key of the certificate.
			/// </summary>
			WSMAN_FLAG_AUTH_CREDSSP = 0x80,

			/// <summary>
			/// Use client certificate authentication. The certificate thumbprint is passed as part of the WSMAN_AUTHENTICATION_CREDENTIALS
			/// structure. The WinRM client will try to find the certificate in the computer store and then, if it is not found, in the
			/// current user store. If no matching certificate is found, an error will be reported to the user.
			/// </summary>
			WSMAN_FLAG_AUTH_CLIENT_CERTIFICATE = 0x20,
		}

		/// <summary>Defines a set of flags used by all callback functions.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/ne-wsman-wsmancallbackflags typedef enum WSManCallbackFlags {
		// WSMAN_FLAG_CALLBACK_END_OF_OPERATION, WSMAN_FLAG_CALLBACK_END_OF_STREAM, WSMAN_FLAG_CALLBACK_SHELL_SUPPORTS_DISCONNECT,
		// WSMAN_FLAG_CALLBACK_SHELL_AUTODISCONNECTED, WSMAN_FLAG_CALLBACK_NETWORK_FAILURE_DETECTED,
		// WSMAN_FLAG_CALLBACK_RETRYING_AFTER_NETWORK_FAILURE, WSMAN_FLAG_CALLBACK_RECONNECTED_AFTER_NETWORK_FAILURE,
		// WSMAN_FLAG_CALLBACK_SHELL_AUTODISCONNECTING, WSMAN_FLAG_CALLBACK_RETRY_ABORTED_DUE_TO_INTERNAL_ERROR,
		// WSMAN_FLAG_CALLBACK_RECEIVE_DELAY_STREAM_REQUEST_PROCESSED } ;
		[PInvokeData("wsman.h", MSDNShortId = "NE:wsman.WSManCallbackFlags")]
		[Flags]
		public enum WSManCallbackFlags
		{
			/// <summary>
			/// Indicates the end of a single step of a multi-step operation. This flag is used for optimization purposes if the shell
			/// cannot be determined.
			/// </summary>
			WSMAN_FLAG_CALLBACK_END_OF_OPERATION = 0x1,

			/// <summary>
			/// Indicates the end of a particular stream. This flag is used for optimization purposes if an indication has been provided to
			/// the shell that no more output will occur for this stream.
			/// </summary>
			WSMAN_FLAG_CALLBACK_END_OF_STREAM = 0x8,

			/// <summary>Flag that if present on CreateShell callback indicates that it supports disconnect</summary>
			WSMAN_FLAG_CALLBACK_SHELL_SUPPORTS_DISCONNECT = 0x20,

			/// <summary>Flag that indicates that the shell got disconnected due to netowrk failure</summary>
			WSMAN_FLAG_CALLBACK_SHELL_AUTODISCONNECTED = 0x40,

			/// <summary>Flag indicates that the client shell detected a network failure</summary>
			WSMAN_FLAG_CALLBACK_NETWORK_FAILURE_DETECTED = 0x100,

			/// <summary>Flag indicates that client shell is retrying to establish network connection with the server</summary>
			WSMAN_FLAG_CALLBACK_RETRYING_AFTER_NETWORK_FAILURE = 0x200,

			/// <summary>
			/// Flag indicates that client shell successfully reconnected with the server after attempting to reconnect to the server
			/// </summary>
			WSMAN_FLAG_CALLBACK_RECONNECTED_AFTER_NETWORK_FAILURE = 0x400,

			/// <summary>Flag indicates that the client shell attempts to reconnect to the server failed and hence it is AutoDisconnecting</summary>
			WSMAN_FLAG_CALLBACK_SHELL_AUTODISCONNECTING = 0x800,

			/// <summary>
			/// Flag indicates that the client shell got into broken state in the middle of retry notification sequence due to some internal
			/// error at wsman layer
			/// </summary>
			WSMAN_FLAG_CALLBACK_RETRY_ABORTED_DUE_TO_INTERNAL_ERROR = 0x1000,

			/// <summary>Flag that indicates for a receive operation that a delay stream request has been processed</summary>
			WSMAN_FLAG_CALLBACK_RECEIVE_DELAY_STREAM_REQUEST_PROCESSED = 0x2000,
		}

		/// <summary>Specifies the current data type of the union in the WSMAN_DATA structure.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/ne-wsman-wsmandatatype typedef enum WSManDataType { WSMAN_DATA_NONE,
		// WSMAN_DATA_TYPE_TEXT, WSMAN_DATA_TYPE_BINARY, WSMAN_DATA_TYPE_DWORD } ;
		[PInvokeData("wsman.h", MSDNShortId = "NE:wsman.WSManDataType")]
		public enum WSManDataType
		{
			/// <summary>The structure is not valid yet.</summary>
			WSMAN_DATA_NONE = 0,

			/// <summary>The structure contains text.</summary>
			WSMAN_DATA_TYPE_TEXT = 1,

			/// <summary>The structure contains binary data.</summary>
			WSMAN_DATA_TYPE_BINARY = 2,

			/// <summary>The structure contains a DWORD integer.</summary>
			WSMAN_DATA_TYPE_DWORD = 4,
		}

		/// <summary>Defines the proxy access type.</summary>
		/// <remarks>
		/// <para>
		/// The <c>WSMAN_OPTION_PROXY_IE_PROXY_CONFIG</c> option returns the current user Internet Explorer proxy settings for the current
		/// active network connection. This option requires the user profile to be loaded. This option can be directly used when called
		/// within a process that is running under an interactive user account identity. If the client application is running under a user
		/// context that is different than the interactive user, the client application must explicitly load the user profile prior to using
		/// this option.
		/// </para>
		/// <para>
		/// If the Windows Remote Management API is called from a service, <c>WSMAN_OPTION_PROXY_WINHTTP_PROXY_CONFIG</c> or
		/// <c>WSMAN_OPTION_PROXY_AUTO_DETECT</c> should be used if a proxy is required.
		/// </para>
		/// <para>
		/// The <c>WSMAN_OPTION_PROXY_WINHTTP_PROXY_CONFIG</c> option translates into the <c>WINHTTP_ACCESS_TYPE_DEFAULT_PROXY</c> option in
		/// WinHTTP. WinHTTP retrieves the static proxy or direct configuration from the registry. <c>WINHTTP_ACCESS_TYPE_DEFAULT_PROXY</c>
		/// does not inherit browser proxy settings. WinHTTP does not share any proxy settings with Internet Explorer. This option gets the
		/// WinHTTP proxy configuration set by the ProxyCfg.exe utility.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/ne-wsman-wsmanproxyaccesstype typedef enum WSManProxyAccessType {
		// WSMAN_OPTION_PROXY_IE_PROXY_CONFIG, WSMAN_OPTION_PROXY_WINHTTP_PROXY_CONFIG, WSMAN_OPTION_PROXY_AUTO_DETECT,
		// WSMAN_OPTION_PROXY_NO_PROXY_SERVER } ;
		[PInvokeData("wsman.h", MSDNShortId = "NE:wsman.WSManProxyAccessType")]
		[Flags]
		public enum WSManProxyAccessType
		{
			/// <summary>Use the Internet Explorer proxy configuration for the current user. This is the default setting.</summary>
			WSMAN_OPTION_PROXY_IE_PROXY_CONFIG = 1,

			/// <summary>Use the proxy settings configured for WinHTTP.</summary>
			WSMAN_OPTION_PROXY_WINHTTP_PROXY_CONFIG = 2,

			/// <summary>Force autodetection of a proxy.</summary>
			WSMAN_OPTION_PROXY_AUTO_DETECT = 4,

			/// <summary>Do not use a proxy server. All host names are resolved locally.</summary>
			WSMAN_OPTION_PROXY_NO_PROXY_SERVER = 8,
		}

		/// <summary>Defines a set of extended options for the session. These options are used with the WSManSetSessionOption method.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/ne-wsman-wsmansessionoption typedef enum WSManSessionOption {
		// WSMAN_OPTION_DEFAULT_OPERATION_TIMEOUTMS, WSMAN_OPTION_MAX_RETRY_TIME, WSMAN_OPTION_TIMEOUTMS_CREATE_SHELL,
		// WSMAN_OPTION_TIMEOUTMS_RUN_SHELL_COMMAND, WSMAN_OPTION_TIMEOUTMS_RECEIVE_SHELL_OUTPUT, WSMAN_OPTION_TIMEOUTMS_SEND_SHELL_INPUT,
		// WSMAN_OPTION_TIMEOUTMS_SIGNAL_SHELL, WSMAN_OPTION_TIMEOUTMS_CLOSE_SHELL, WSMAN_OPTION_SKIP_CA_CHECK, WSMAN_OPTION_SKIP_CN_CHECK,
		// WSMAN_OPTION_UNENCRYPTED_MESSAGES, WSMAN_OPTION_UTF16, WSMAN_OPTION_ENABLE_SPN_SERVER_PORT, WSMAN_OPTION_MACHINE_ID,
		// WSMAN_OPTION_LOCALE, WSMAN_OPTION_UI_LANGUAGE, WSMAN_OPTION_MAX_ENVELOPE_SIZE_KB,
		// WSMAN_OPTION_SHELL_MAX_DATA_SIZE_PER_MESSAGE_KB, WSMAN_OPTION_REDIRECT_LOCATION, WSMAN_OPTION_SKIP_REVOCATION_CHECK,
		// WSMAN_OPTION_ALLOW_NEGOTIATE_IMPLICIT_CREDENTIALS, WSMAN_OPTION_USE_SSL, WSMAN_OPTION_USE_INTEARACTIVE_TOKEN } ;
		[PInvokeData("wsman.h", MSDNShortId = "NE:wsman.WSManSessionOption")]
		public enum WSManSessionOption
		{
			/// <summary>Default time-out in milliseconds that applies to all operations on the client side.</summary>
			[CorrespondingType(typeof(uint))]
			WSMAN_OPTION_DEFAULT_OPERATION_TIMEOUTMS = 1,

			/// <summary/>
			[CorrespondingType(typeof(uint))]
			WSMAN_OPTION_MAX_RETRY_TIME = 11,

			/// <summary>Time-out in milliseconds for WSManCreateShell operations.</summary>
			[CorrespondingType(typeof(uint))]
			WSMAN_OPTION_TIMEOUTMS_CREATE_SHELL,

			/// <summary>Time-out in milliseconds for WSManRunShellCommand operations.</summary>
			[CorrespondingType(typeof(uint))]
			WSMAN_OPTION_TIMEOUTMS_RUN_SHELL_COMMAND,

			/// <summary>Time-out in milliseconds for WSManReceiveShellOutput operations.</summary>
			[CorrespondingType(typeof(uint))]
			WSMAN_OPTION_TIMEOUTMS_RECEIVE_SHELL_OUTPUT,

			/// <summary>Time-out in milliseconds for WSManSendShellInput operations.</summary>
			[CorrespondingType(typeof(uint))]
			WSMAN_OPTION_TIMEOUTMS_SEND_SHELL_INPUT,

			/// <summary>Time-out in milliseconds for WSManSignalShell and WSManCloseCommand operations.</summary>
			[CorrespondingType(typeof(uint))]
			WSMAN_OPTION_TIMEOUTMS_SIGNAL_SHELL,

			/// <summary>Time-out in milliseconds for WSManCloseShell operations connection options.</summary>
			[CorrespondingType(typeof(uint))]
			WSMAN_OPTION_TIMEOUTMS_CLOSE_SHELL,

			/// <summary>Set to 1 to not validate the CA on the server certificate. The default is 0.</summary>
			[CorrespondingType(typeof(uint))]
			WSMAN_OPTION_SKIP_CA_CHECK,

			/// <summary>Set to 1 to not validate the CN on the server certificate. The default is 0.</summary>
			[CorrespondingType(typeof(uint))]
			WSMAN_OPTION_SKIP_CN_CHECK,

			/// <summary>Set to 1 to not encrypt messages. The default is 0.</summary>
			[CorrespondingType(typeof(uint))]
			WSMAN_OPTION_UNENCRYPTED_MESSAGES,

			/// <summary>
			/// Set to 1 to send all network packets for remote operations in UTF16. Default of 0 causes network packets to be sent in UTF8.
			/// </summary>
			[CorrespondingType(typeof(uint))]
			WSMAN_OPTION_UTF16,

			/// <summary>Set to 1 when using Negotiate authentication and the port number is included in the connection. Default is 0.</summary>
			[CorrespondingType(typeof(uint))]
			WSMAN_OPTION_ENABLE_SPN_SERVER_PORT,

			/// <summary>Set to 1 to identify this machine to the server by including the MachineID. The default is 0.</summary>
			[CorrespondingType(typeof(uint))]
			WSMAN_OPTION_MACHINE_ID,

			/// <summary>
			/// The language locale options. For more information about the language locales, see the RFC 3066 specification from the
			/// Internet Engineering Task Force at http://www.ietf.org/rfc/rfc3066.txt.
			/// </summary>
			[CorrespondingType(typeof(string))]
			WSMAN_OPTION_LOCALE = 25,

			/// <summary>
			/// The UI language options. The UI language options are defined in RFC 3066 format. For more information about the UI language
			/// options, see the RFC 3066 specification from the Internet Engineering Task Force at http://www.ietf.org/rfc/rfc3066.txt.
			/// </summary>
			[CorrespondingType(typeof(string))]
			WSMAN_OPTION_UI_LANGUAGE,

			/// <summary>The maximum Simple Object Access Protocol (SOAP) envelope size. The default is 150 KB.</summary>
			[CorrespondingType(typeof(uint))]
			WSMAN_OPTION_MAX_ENVELOPE_SIZE_KB = 28,

			/// <summary>The maximum size of the data that is provided by the client.</summary>
			[CorrespondingType(typeof(uint))]
			WSMAN_OPTION_SHELL_MAX_DATA_SIZE_PER_MESSAGE_KB,

			/// <summary>The redirect location.</summary>
			[CorrespondingType(typeof(string))]
			WSMAN_OPTION_REDIRECT_LOCATION,

			/// <summary>Set to 1 to not validate the revocation status on the server certificate. The default is 0.</summary>
			[CorrespondingType(typeof(uint))]
			WSMAN_OPTION_SKIP_REVOCATION_CHECK,

			/// <summary>Set to 1 to allow default credentials for Negotiate. The default is 0.</summary>
			[CorrespondingType(typeof(uint))]
			WSMAN_OPTION_ALLOW_NEGOTIATE_IMPLICIT_CREDENTIALS,

			/// <summary/>
			[CorrespondingType(typeof(uint))]
			WSMAN_OPTION_USE_SSL,

			/// <summary/>
			[CorrespondingType(typeof(uint))]
			WSMAN_OPTION_USE_INTEARACTIVE_TOKEN,
		}

		/// <summary>Deletes a command and frees the resources that are associated with it.</summary>
		/// <param name="commandHandle">Specifies the command handle to be closed. This handle is returned by a WSManRunShellCommand call.</param>
		/// <param name="flags">Reserved for future use. Must be set to zero.</param>
		/// <param name="async">
		/// Defines an asynchronous structure. The asynchronous structure contains an optional user context and a mandatory callback
		/// function. See the WSMAN_SHELL_ASYNC structure for more information. This parameter cannot be <c>NULL</c>.
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/nf-wsman-wsmanclosecommand void WSManCloseCommand( WSMAN_COMMAND_HANDLE
		// commandHandle, DWORD flags, WSMAN_SHELL_ASYNC *async );
		[DllImport(Lib_WsmSvc, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wsman.h", MSDNShortId = "NF:wsman.WSManCloseCommand")]
		public static extern void WSManCloseCommand(WSMAN_COMMAND_HANDLE commandHandle, [In, Optional] uint flags, in WSMAN_SHELL_ASYNC async);

		/// <summary>Cancels or closes an asynchronous operation. All resources that are associated with the operation are freed.</summary>
		/// <param name="operationHandle">Specifies the operation handle to be closed.</param>
		/// <param name="flags">Reserved for future use. Set to zero.</param>
		/// <returns>This method returns zero on success. Otherwise, this method returns an error code.</returns>
		/// <remarks>
		/// The method de-allocates local and remote resources associated with the operation. After the <c>WSManCloseOperation</c> method is
		/// called, the operationHandle parameter cannot be passed to any other call. If the callback associated with the operation is
		/// pending and has not completed before <c>WSManCloseOperation</c> is called, the operation is marked for deletion and the method
		/// returns immediately.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/nf-wsman-wsmancloseoperation DWORD WSManCloseOperation(
		// WSMAN_OPERATION_HANDLE operationHandle, DWORD flags );
		[DllImport(Lib_WsmSvc, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wsman.h", MSDNShortId = "NF:wsman.WSManCloseOperation")]
		public static extern Win32Error WSManCloseOperation(WSMAN_OPERATION_HANDLE operationHandle, uint flags = 0);

		/// <summary>Closes a session object.</summary>
		/// <param name="session">
		/// Specifies the session handle to close. This handle is returned by a WSManCreateSession call. This parameter cannot be NULL.
		/// </param>
		/// <param name="flags">Reserved for future use. Must be zero.</param>
		/// <returns>This method returns zero on success. Otherwise, this method returns an error code.</returns>
		/// <remarks>
		/// The <c>WSManCloseSession</c> method frees the memory associated with a session and closes all related operations before
		/// returning. This is a synchronous call. All operations are explicitly canceled. It is recommended that all pending operations are
		/// either completed or explicitly canceled before calling this function.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/nf-wsman-wsmanclosesession DWORD WSManCloseSession( WSMAN_SESSION_HANDLE
		// session, DWORD flags );
		[DllImport(Lib_WsmSvc, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wsman.h", MSDNShortId = "NF:wsman.WSManCloseSession")]
		public static extern Win32Error WSManCloseSession(WSMAN_SESSION_HANDLE session, uint flags = 0);

		/// <summary>Deletes a shell object and frees the resources associated with the shell.</summary>
		/// <param name="shellHandle">
		/// Specifies the shell handle to close. This handle is returned by a WSManCreateShell call. This parameter cannot be <c>NULL</c>.
		/// </param>
		/// <param name="flags">Reserved for future use. Must be set to zero.</param>
		/// <param name="async">
		/// Defines an asynchronous structure. The asynchronous structure contains an optional user context and a mandatory callback
		/// function. See the WSMAN_SHELL_ASYNC structure for more information. This parameter cannot be <c>NULL</c>.
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/nf-wsman-wsmancloseshell void WSManCloseShell( WSMAN_SHELL_HANDLE
		// shellHandle, DWORD flags, WSMAN_SHELL_ASYNC *async );
		[DllImport(Lib_WsmSvc, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wsman.h", MSDNShortId = "NF:wsman.WSManCloseShell")]
		public static extern void WSManCloseShell(WSMAN_SHELL_HANDLE shellHandle, [Optional] uint flags, in WSMAN_SHELL_ASYNC async);

		/// <summary>Connects to an existing server session.</summary>
		/// <param name="session">Specifies the session handle returned by a WSManCreateSession function. This parameter cannot be NULL.</param>
		/// <param name="flags">Reserved for future use. Must be zero.</param>
		/// <param name="resourceUri">
		/// Defines the shell type to which the connection will be made. The shell type is defined by a unique URI, therefore the shell
		/// object returned by the call is dependent on the URI that is specified by this parameter. The resourceUri parameter cannot be
		/// NULL and it is a null-terminated string.
		/// </param>
		/// <param name="shellID">
		/// Specifies the shell identifier that is associated with the server shell session to which the client intends to connect.
		/// </param>
		/// <param name="options">
		/// A pointer to a WSMAN_OPTION_SET structure that specifies a set of options for the shell. This parameter is optional.
		/// </param>
		/// <param name="connectXml">
		/// A pointer to a WSMAN_DATA structure that defines an open context for the connect shell operation. The content should be a valid
		/// XML string. This parameter can be NULL.
		/// </param>
		/// <param name="async">
		/// Defines an asynchronous structure that contains an optional user context and a mandatory callback function. See the
		/// WSMAN_SHELL_ASYNC structure for more information. This parameter cannot be NULL.
		/// </param>
		/// <param name="shell">
		/// Specifies a shell handle that uniquely identifies the shell object that was returned by resourceURI. The resource handle tracks
		/// the client endpoint for the shell and is used by other WinRM methods to interact with the shell object. The shell object should
		/// be deleted by calling the WSManCloseShell method. This parameter cannot be NULL.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Connects to an existing server shell session identified by the ShellId parameter. This builds the necessary client side context,
		/// represented by the return parameter shell, that can be used to carry out subsequent operations such as running commands and
		/// sending and receiving output on the server shell session. This <c>WSManConnectShell</c> function does not automatically
		/// construct the client side contexts for any commands that are currently associated with the server shell session.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/nf-wsman-wsmanconnectshell void WSManConnectShell( WSMAN_SESSION_HANDLE
		// session, DWORD flags, PCWSTR resourceUri, PCWSTR shellID, WSMAN_OPTION_SET *options, WSMAN_DATA *connectXml, WSMAN_SHELL_ASYNC
		// *async, WSMAN_SHELL_HANDLE *shell );
		[DllImport(Lib_WsmSvc, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wsman.h", MSDNShortId = "NF:wsman.WSManConnectShell")]
		public static extern void WSManConnectShell(WSMAN_SESSION_HANDLE session, uint flags, [MarshalAs(UnmanagedType.LPWStr)] string resourceUri,
			[MarshalAs(UnmanagedType.LPWStr)] string shellID, in WSMAN_OPTION_SET options, in WSMAN_DATA connectXml, in WSMAN_SHELL_ASYNC async,
			out WSMAN_SHELL_HANDLE shell);

		/// <summary>Connects to an existing server session.</summary>
		/// <param name="session">Specifies the session handle returned by a WSManCreateSession function. This parameter cannot be NULL.</param>
		/// <param name="flags">Reserved for future use. Must be zero.</param>
		/// <param name="resourceUri">
		/// Defines the shell type to which the connection will be made. The shell type is defined by a unique URI, therefore the shell
		/// object returned by the call is dependent on the URI that is specified by this parameter. The resourceUri parameter cannot be
		/// NULL and it is a null-terminated string.
		/// </param>
		/// <param name="shellID">
		/// Specifies the shell identifier that is associated with the server shell session to which the client intends to connect.
		/// </param>
		/// <param name="options">
		/// A pointer to a WSMAN_OPTION_SET structure that specifies a set of options for the shell. This parameter is optional.
		/// </param>
		/// <param name="connectXml">
		/// A pointer to a WSMAN_DATA structure that defines an open context for the connect shell operation. The content should be a valid
		/// XML string. This parameter can be NULL.
		/// </param>
		/// <param name="async">
		/// Defines an asynchronous structure that contains an optional user context and a mandatory callback function. See the
		/// WSMAN_SHELL_ASYNC structure for more information. This parameter cannot be NULL.
		/// </param>
		/// <param name="shell">
		/// Specifies a shell handle that uniquely identifies the shell object that was returned by resourceURI. The resource handle tracks
		/// the client endpoint for the shell and is used by other WinRM methods to interact with the shell object. The shell object should
		/// be deleted by calling the WSManCloseShell method. This parameter cannot be NULL.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Connects to an existing server shell session identified by the ShellId parameter. This builds the necessary client side context,
		/// represented by the return parameter shell, that can be used to carry out subsequent operations such as running commands and
		/// sending and receiving output on the server shell session. This <c>WSManConnectShell</c> function does not automatically
		/// construct the client side contexts for any commands that are currently associated with the server shell session.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/nf-wsman-wsmanconnectshell void WSManConnectShell( WSMAN_SESSION_HANDLE
		// session, DWORD flags, PCWSTR resourceUri, PCWSTR shellID, WSMAN_OPTION_SET *options, WSMAN_DATA *connectXml, WSMAN_SHELL_ASYNC
		// *async, WSMAN_SHELL_HANDLE *shell );
		[DllImport(Lib_WsmSvc, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wsman.h", MSDNShortId = "NF:wsman.WSManConnectShell")]
		public static extern void WSManConnectShell(WSMAN_SESSION_HANDLE session, uint flags, [MarshalAs(UnmanagedType.LPWStr)] string resourceUri,
			[MarshalAs(UnmanagedType.LPWStr)] string shellID, [In, Optional] IntPtr options, [In, Optional] IntPtr connectXml,
			in WSMAN_SHELL_ASYNC async, out WSMAN_SHELL_HANDLE shell);

		/// <summary>Connects to an existing command running in a shell.</summary>
		/// <param name="shell">Specifies the shell handle returned by the WSManCreateShell call. This parameter cannot be <c>NULL</c>.</param>
		/// <param name="flags">Reserved for future use. Must be zero.</param>
		/// <param name="commandID">
		/// A null-terminated string that identifies a specific command, currently running in the server session, that the client intends to
		/// connect to.
		/// </param>
		/// <param name="options">
		/// Defines a set of options for the command. These options are passed to the service to modify or refine the command execution.
		/// This parameter can be <c>NULL</c>. For more information about the options, see WSMAN_OPTION_SET.
		/// </param>
		/// <param name="connectXml">
		/// A pointer to a WSMAN_DATA structure that defines an open context for the connect shell operation. The content must be a valid
		/// XML string. This parameter can be <c>NULL</c>.
		/// </param>
		/// <param name="async">
		/// Defines an asynchronous structure to contain an optional user context and a mandatory callback function. For more information,
		/// see WSMAN_SHELL_ASYNC. This parameter cannot be <c>NULL</c>.
		/// </param>
		/// <param name="command">
		/// This handle is returned on a successful call and is used to send and receive data and to signal the command. When you have
		/// finished using this handle, close it by calling the WSManCloseCommand method. This parameter cannot be <c>NULL</c>.
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/nf-wsman-wsmanconnectshellcommand void WSManConnectShellCommand(
		// WSMAN_SHELL_HANDLE shell, DWORD flags, PCWSTR commandID, WSMAN_OPTION_SET *options, WSMAN_DATA *connectXml, WSMAN_SHELL_ASYNC
		// *async, WSMAN_COMMAND_HANDLE *command );
		[DllImport(Lib_WsmSvc, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wsman.h", MSDNShortId = "NF:wsman.WSManConnectShellCommand")]
		public static extern void WSManConnectShellCommand(WSMAN_SHELL_HANDLE shell, uint flags, [MarshalAs(UnmanagedType.LPWStr)] string commandID,
			in WSMAN_OPTION_SET options, in WSMAN_DATA connectXml, in WSMAN_SHELL_ASYNC async, out WSMAN_COMMAND_HANDLE command);

		/// <summary>Connects to an existing command running in a shell.</summary>
		/// <param name="shell">Specifies the shell handle returned by the WSManCreateShell call. This parameter cannot be <c>NULL</c>.</param>
		/// <param name="flags">Reserved for future use. Must be zero.</param>
		/// <param name="commandID">
		/// A null-terminated string that identifies a specific command, currently running in the server session, that the client intends to
		/// connect to.
		/// </param>
		/// <param name="options">
		/// Defines a set of options for the command. These options are passed to the service to modify or refine the command execution.
		/// This parameter can be <c>NULL</c>. For more information about the options, see WSMAN_OPTION_SET.
		/// </param>
		/// <param name="connectXml">
		/// A pointer to a WSMAN_DATA structure that defines an open context for the connect shell operation. The content must be a valid
		/// XML string. This parameter can be <c>NULL</c>.
		/// </param>
		/// <param name="async">
		/// Defines an asynchronous structure to contain an optional user context and a mandatory callback function. For more information,
		/// see WSMAN_SHELL_ASYNC. This parameter cannot be <c>NULL</c>.
		/// </param>
		/// <param name="command">
		/// This handle is returned on a successful call and is used to send and receive data and to signal the command. When you have
		/// finished using this handle, close it by calling the WSManCloseCommand method. This parameter cannot be <c>NULL</c>.
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/nf-wsman-wsmanconnectshellcommand void WSManConnectShellCommand(
		// WSMAN_SHELL_HANDLE shell, DWORD flags, PCWSTR commandID, WSMAN_OPTION_SET *options, WSMAN_DATA *connectXml, WSMAN_SHELL_ASYNC
		// *async, WSMAN_COMMAND_HANDLE *command );
		[DllImport(Lib_WsmSvc, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wsman.h", MSDNShortId = "NF:wsman.WSManConnectShellCommand")]
		public static extern void WSManConnectShellCommand(WSMAN_SHELL_HANDLE shell, uint flags, [MarshalAs(UnmanagedType.LPWStr)] string commandID,
			[In, Optional] IntPtr options, [In, Optional] IntPtr connectXml, in WSMAN_SHELL_ASYNC async, out WSMAN_COMMAND_HANDLE command);

		/// <summary>Creates a session object.</summary>
		/// <param name="apiHandle">Specifies the API handle returned by the WSManInitialize call. This parameter cannot be <c>NULL</c>.</param>
		/// <param name="connection">
		/// <para>
		/// Indicates to which protocol and agent to connect. If this parameter is <c>NULL</c>, the connection will default to localhost
		/// (127.0.0.1). This parameter can be a simple host name or a complete URL. The format is the following:
		/// </para>
		/// <para>[transport://]host[:port][/prefix] where:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Element</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>transport</term>
		/// <term>Either HTTP or HTTPS. Default is HTTP.</term>
		/// </item>
		/// <item>
		/// <term>host</term>
		/// <term>Can be in a DNS name, NetBIOS name, or IP address.</term>
		/// </item>
		/// <item>
		/// <term>port</term>
		/// <term>Defaults to 80 for HTTP and to 443 for HTTPS. The defaults can be changed in the local configuration.</term>
		/// </item>
		/// <item>
		/// <term>prefix</term>
		/// <term>Any string. Default is "wsman". The default can be changed in the local configuration.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="flags">Reserved for future use. Must be zero.</param>
		/// <param name="serverAuthenticationCredentials">
		/// <para>
		/// Defines the authentication method such as Negotiate, Kerberos, Digest, Basic, or client certificate. If the authentication
		/// mechanism is Negotiate, Kerberos, Digest, or Basic, the structure can also contain the credentials used for authentication. If
		/// client certificate authentication is used, the certificate thumbprint must be specified.
		/// </para>
		/// <para>
		/// If credentials are specified, this parameter contains the user name and password of a local account or domain account. If this
		/// parameter is <c>NULL</c>, the default credentials are used. The default credentials are the credentials that the current thread
		/// is executing under. The client must explicitly specify the credentials when Basic or Digest authentication is used. If explicit
		/// credentials are used, both the user name and the password must be valid. For more information about the authentication
		/// credentials, see the WSMAN_AUTHENTICATION_CREDENTIALS structure.
		/// </para>
		/// </param>
		/// <param name="proxyInfo">A pointer to a WSMAN_PROXY_INFO structure that specifies proxy information. This value can be <c>NULL</c>.</param>
		/// <param name="session">
		/// Defines the session handle that uniquely identifies the session. This parameter cannot be <c>NULL</c>. This handle should be
		/// closed by calling the WSManCloseSession method.
		/// </param>
		/// <returns>If the function succeeds, the return value is zero. Otherwise, the return value is an error code.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/nf-wsman-wsmancreatesession DWORD WSManCreateSession( WSMAN_API_HANDLE
		// apiHandle, PCWSTR connection, DWORD flags, WSMAN_AUTHENTICATION_CREDENTIALS *serverAuthenticationCredentials, WSMAN_PROXY_INFO
		// *proxyInfo, WSMAN_SESSION_HANDLE *session );
		[DllImport(Lib_WsmSvc, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wsman.h", MSDNShortId = "NF:wsman.WSManCreateSession")]
		public static extern uint WSManCreateSession(WSMAN_API_HANDLE apiHandle, [Optional, MarshalAs(UnmanagedType.LPWStr)] string connection,
			[Optional] uint flags, IntPtr serverAuthenticationCredentials, [In, Optional] IntPtr proxyInfo, out SafeWSMAN_SESSION_HANDLE session);

		/// <summary>
		/// Creates a shell object. The returned shell handle identifies an object that defines the context in which commands can be run.
		/// The context is defined by the environment variables, the input and output streams, and the working directory. The context can
		/// directly affect the behavior of a command. A shell context is created on the remote computer specified by the connection
		/// parameter and authenticated by using the credentials parameter.
		/// </summary>
		/// <param name="session">Specifies the session handle returned by a WSManCreateSession call. This parameter cannot be <c>NULL</c>.</param>
		/// <param name="flags">Reserved for future use. Must be zero.</param>
		/// <param name="resourceUri">
		/// Defines the shell type to create. The shell type is defined by a unique URI. The actual shell object returned by the call is
		/// dependent on the URI specified. This parameter cannot be <c>NULL</c>. To create a Windows cmd.exe shell, use the
		/// <c>WSMAN_CMDSHELL_URI</c> resource URI.
		/// </param>
		/// <param name="startupInfo">
		/// <para>
		/// A pointer to a WSMAN_SHELL_STARTUP_INFO structure that specifies the input and output streams, working directory, idle time-out,
		/// and options for the shell.
		/// </para>
		/// <para>If this parameter is <c>NULL</c>, the default values will be used.</para>
		/// </param>
		/// <param name="options">A pointer to a WSMAN_OPTION_SET structure that specifies a set of options for the shell.</param>
		/// <param name="createXml">
		/// A pointer to a WSMAN_DATA structure that defines an open context for the shell. The content should be a valid XML string. This
		/// parameter can be <c>NULL</c>.
		/// </param>
		/// <param name="async">
		/// Defines an asynchronous structure. The asynchronous structure contains an optional user context and a mandatory callback
		/// function. See the WSMAN_SHELL_ASYNC structure for more information. This parameter cannot be <c>NULL</c> and should be closed by
		/// calling the WSManCloseShell method.
		/// </param>
		/// <param name="shell">
		/// Defines a shell handle that uniquely identifies the shell object. The resource handle is used to track the client endpoint for
		/// the shell and is used by other WinRM methods to interact with the shell object. The shell object should be deleted by calling
		/// the WSManCloseShell method. This parameter cannot be <c>NULL</c>.
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/nf-wsman-wsmancreateshell void WSManCreateShell( WSMAN_SESSION_HANDLE
		// session, DWORD flags, PCWSTR resourceUri, WSMAN_SHELL_STARTUP_INFO *startupInfo, WSMAN_OPTION_SET *options, WSMAN_DATA
		// *createXml, WSMAN_SHELL_ASYNC *async, WSMAN_SHELL_HANDLE *shell );
		[DllImport(Lib_WsmSvc, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wsman.h", MSDNShortId = "NF:wsman.WSManCreateShell")]
		public static extern void WSManCreateShell(WSMAN_SESSION_HANDLE session, [Optional] uint flags, [MarshalAs(UnmanagedType.LPWStr)] string resourceUri,
			[In, Optional] IntPtr startupInfo, in WSMAN_OPTION_SET options, in WSMAN_DATA createXml, in WSMAN_SHELL_ASYNC async, out WSMAN_SHELL_HANDLE shell);

		/// <summary>
		/// Creates a shell object. The returned shell handle identifies an object that defines the context in which commands can be run.
		/// The context is defined by the environment variables, the input and output streams, and the working directory. The context can
		/// directly affect the behavior of a command. A shell context is created on the remote computer specified by the connection
		/// parameter and authenticated by using the credentials parameter.
		/// </summary>
		/// <param name="session">Specifies the session handle returned by a WSManCreateSession call. This parameter cannot be <c>NULL</c>.</param>
		/// <param name="flags">Reserved for future use. Must be zero.</param>
		/// <param name="resourceUri">
		/// Defines the shell type to create. The shell type is defined by a unique URI. The actual shell object returned by the call is
		/// dependent on the URI specified. This parameter cannot be <c>NULL</c>. To create a Windows cmd.exe shell, use the
		/// <c>WSMAN_CMDSHELL_URI</c> resource URI.
		/// </param>
		/// <param name="startupInfo">
		/// <para>
		/// A pointer to a WSMAN_SHELL_STARTUP_INFO structure that specifies the input and output streams, working directory, idle time-out,
		/// and options for the shell.
		/// </para>
		/// <para>If this parameter is <c>NULL</c>, the default values will be used.</para>
		/// </param>
		/// <param name="options">A pointer to a WSMAN_OPTION_SET structure that specifies a set of options for the shell.</param>
		/// <param name="createXml">
		/// A pointer to a WSMAN_DATA structure that defines an open context for the shell. The content should be a valid XML string. This
		/// parameter can be <c>NULL</c>.
		/// </param>
		/// <param name="async">
		/// Defines an asynchronous structure. The asynchronous structure contains an optional user context and a mandatory callback
		/// function. See the WSMAN_SHELL_ASYNC structure for more information. This parameter cannot be <c>NULL</c> and should be closed by
		/// calling the WSManCloseShell method.
		/// </param>
		/// <param name="shell">
		/// Defines a shell handle that uniquely identifies the shell object. The resource handle is used to track the client endpoint for
		/// the shell and is used by other WinRM methods to interact with the shell object. The shell object should be deleted by calling
		/// the WSManCloseShell method. This parameter cannot be <c>NULL</c>.
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/nf-wsman-wsmancreateshell void WSManCreateShell( WSMAN_SESSION_HANDLE
		// session, DWORD flags, PCWSTR resourceUri, WSMAN_SHELL_STARTUP_INFO *startupInfo, WSMAN_OPTION_SET *options, WSMAN_DATA
		// *createXml, WSMAN_SHELL_ASYNC *async, WSMAN_SHELL_HANDLE *shell );
		[DllImport(Lib_WsmSvc, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wsman.h", MSDNShortId = "NF:wsman.WSManCreateShell")]
		public static extern void WSManCreateShell(WSMAN_SESSION_HANDLE session, [Optional] uint flags, [MarshalAs(UnmanagedType.LPWStr)] string resourceUri,
			[In, Optional] IntPtr startupInfo, [In, Optional] IntPtr options, [In, Optional] IntPtr createXml, in WSMAN_SHELL_ASYNC async, out WSMAN_SHELL_HANDLE shell);

		/// <summary>
		/// Creates a shell object by using the same functionality as the WSManCreateShell function, with the addition of a client-specified
		/// shell ID. The returned shell handle identifies an object that defines the context in which commands can be run. The context is
		/// defined by the environment variables, the input and output streams, and the working directory. The context can directly affect
		/// the behavior of a command. A shell context is created on the remote computer specified by the connection parameter and
		/// authenticated by using the credentials parameter.
		/// </summary>
		/// <param name="session">Specifies the session handle returned by a WSManCreateSession call. This parameter cannot be <c>NULL</c>.</param>
		/// <param name="flags">Reserved for future use. Must be 0.</param>
		/// <param name="resourceUri">
		/// Defines the shell type to create. The shell type is defined by a unique URI. The actual shell object returned by the call is
		/// dependent on the URI specified. This parameter cannot be <c>NULL</c>. To create a Windows cmd.exe shell, use the
		/// <c>WSMAN_CMDSHELL_URI</c> resource URI.
		/// </param>
		/// <param name="shellId">The client specified shellID.</param>
		/// <param name="startupInfo">
		/// A pointer to a WSMAN_SHELL_STARTUP_INFO structure that specifies the input and output streams, working directory, idle timeout,
		/// and options for the shell. If this parameter is <c>NULL</c>, the default values will be used.
		/// </param>
		/// <param name="options">A pointer to a WSMAN_OPTION_SET structure that specifies a set of options for the shell.</param>
		/// <param name="createXml">
		/// A pointer to a WSMAN_DATA structure that defines an open context for the shell. The content should be a valid XML string. This
		/// parameter can be <c>NULL</c>.
		/// </param>
		/// <param name="async">
		/// Defines an asynchronous structure. The asynchronous structure contains an optional user context and a mandatory callback
		/// function. See the WSMAN_SHELL_ASYNC structure for more information. This parameter cannot be <c>NULL</c> and should be closed by
		/// calling the WSManCloseShell method.
		/// </param>
		/// <param name="shell">
		/// Defines a shell handle that uniquely identifies the shell object. The resource handle is used to track the client endpoint for
		/// the shell and is used by other WinRM methods to interact with the shell object. The shell object should be deleted by calling
		/// the WSManCloseShell method. This parameter cannot be <c>NULL</c>.
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/nf-wsman-wsmancreateshellex void WSManCreateShellEx(
		// WSMAN_SESSION_HANDLE session, DWORD flags, PCWSTR resourceUri, PCWSTR shellId, WSMAN_SHELL_STARTUP_INFO *startupInfo,
		// WSMAN_OPTION_SET *options, WSMAN_DATA *createXml, WSMAN_SHELL_ASYNC *async, WSMAN_SHELL_HANDLE *shell );
		[DllImport(Lib_WsmSvc, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wsman.h", MSDNShortId = "NF:wsman.WSManCreateShellEx")]
		public static extern void WSManCreateShellEx(WSMAN_SESSION_HANDLE session, uint flags, [MarshalAs(UnmanagedType.LPWStr)] string resourceUri,
			[MarshalAs(UnmanagedType.LPWStr)] string shellId, in WSMAN_SHELL_STARTUP_INFO_V11 startupInfo, in WSMAN_OPTION_SET options,
			in WSMAN_DATA createXml, in WSMAN_SHELL_ASYNC async, out WSMAN_SHELL_HANDLE shell);

		/// <summary>
		/// Creates a shell object by using the same functionality as the WSManCreateShell function, with the addition of a client-specified
		/// shell ID. The returned shell handle identifies an object that defines the context in which commands can be run. The context is
		/// defined by the environment variables, the input and output streams, and the working directory. The context can directly affect
		/// the behavior of a command. A shell context is created on the remote computer specified by the connection parameter and
		/// authenticated by using the credentials parameter.
		/// </summary>
		/// <param name="session">Specifies the session handle returned by a WSManCreateSession call. This parameter cannot be <c>NULL</c>.</param>
		/// <param name="flags">Reserved for future use. Must be 0.</param>
		/// <param name="resourceUri">
		/// Defines the shell type to create. The shell type is defined by a unique URI. The actual shell object returned by the call is
		/// dependent on the URI specified. This parameter cannot be <c>NULL</c>. To create a Windows cmd.exe shell, use the
		/// <c>WSMAN_CMDSHELL_URI</c> resource URI.
		/// </param>
		/// <param name="shellId">The client specified shellID.</param>
		/// <param name="startupInfo">
		/// A pointer to a WSMAN_SHELL_STARTUP_INFO structure that specifies the input and output streams, working directory, idle timeout,
		/// and options for the shell. If this parameter is <c>NULL</c>, the default values will be used.
		/// </param>
		/// <param name="options">A pointer to a WSMAN_OPTION_SET structure that specifies a set of options for the shell.</param>
		/// <param name="createXml">
		/// A pointer to a WSMAN_DATA structure that defines an open context for the shell. The content should be a valid XML string. This
		/// parameter can be <c>NULL</c>.
		/// </param>
		/// <param name="async">
		/// Defines an asynchronous structure. The asynchronous structure contains an optional user context and a mandatory callback
		/// function. See the WSMAN_SHELL_ASYNC structure for more information. This parameter cannot be <c>NULL</c> and should be closed by
		/// calling the WSManCloseShell method.
		/// </param>
		/// <param name="shell">
		/// Defines a shell handle that uniquely identifies the shell object. The resource handle is used to track the client endpoint for
		/// the shell and is used by other WinRM methods to interact with the shell object. The shell object should be deleted by calling
		/// the WSManCloseShell method. This parameter cannot be <c>NULL</c>.
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/nf-wsman-wsmancreateshellex void WSManCreateShellEx(
		// WSMAN_SESSION_HANDLE session, DWORD flags, PCWSTR resourceUri, PCWSTR shellId, WSMAN_SHELL_STARTUP_INFO *startupInfo,
		// WSMAN_OPTION_SET *options, WSMAN_DATA *createXml, WSMAN_SHELL_ASYNC *async, WSMAN_SHELL_HANDLE *shell );
		[DllImport(Lib_WsmSvc, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wsman.h", MSDNShortId = "NF:wsman.WSManCreateShellEx")]
		public static extern void WSManCreateShellEx(WSMAN_SESSION_HANDLE session, uint flags, [MarshalAs(UnmanagedType.LPWStr)] string resourceUri,
			[MarshalAs(UnmanagedType.LPWStr)] string shellId, [In, Optional] IntPtr startupInfo, [In, Optional] IntPtr options,
			[In, Optional] IntPtr createXml, in WSMAN_SHELL_ASYNC async, out WSMAN_SHELL_HANDLE shell);

		/// <summary>
		/// Deinitializes the Windows Remote Management client stack. All operations must be complete before a call to this function will
		/// return. This is a synchronous call. It is recommended that all operations are explicitly canceled and that all sessions are
		/// closed before calling this function.
		/// </summary>
		/// <param name="apiHandle">Specifies the API handle returned by a WSManInitialize call. This parameter cannot be <c>NULL</c>.</param>
		/// <param name="flags">Reserved for future use. Must be zero.</param>
		/// <returns>This method returns zero on success. Otherwise, this method returns an error code.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/nf-wsman-wsmandeinitialize DWORD WSManDeinitialize( WSMAN_API_HANDLE
		// apiHandle, DWORD flags );
		[DllImport(Lib_WsmSvc, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wsman.h", MSDNShortId = "NF:wsman.WSManDeinitialize")]
		public static extern Win32Error WSManDeinitialize(WSMAN_API_HANDLE apiHandle, uint flags = 0);

		/// <summary>Disconnects the network connection of an active shell and its associated commands.</summary>
		/// <param name="shell">Specifies the handle returned by a call to the WSManCreateShell function. This parameter cannot be <c>NULL</c>.</param>
		/// <param name="flags">
		/// Can be a <c>WSMAN_FLAG_SERVER_BUFFERING_MODE_DROP</c> flag or a <c>WSMAN_FLAG_SERVER_BUFFERING_MODE_BLOCK</c> flag.
		/// </param>
		/// <param name="disconnectInfo">
		/// A pointer to a WSMAN_SHELL_DISCONNECT_INFO structure that specifies an idle time-out that the server session may enforce. If
		/// this parameter is <c>NULL</c>, the server session idle time-out will not be changed.
		/// </param>
		/// <param name="async">
		/// Defines an asynchronous structure to contain an optional user context and a mandatory callback function. For more information,
		/// see WSMAN_SHELL_ASYNC. This parameter cannot be <c>NULL</c>.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// This function suspends network connection to an actively connected server session. Any operations performed on the shell
		/// instance, like WSManRunShellCommand, WSManSendShellInput, or WSManSignalShell, are bound to complete before disconnection. This
		/// ensures that any data sent through <c>WSManSendShellInput</c> is received by the server session before the shell disconnects.
		/// The client can optionally modify the server buffering mode by using flags. The following behavior is observed:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// <c>WSMAN_FLAG_SERVER_BUFFERING_MODE_DROP</c>–When buffers are full, the server drops earlier data in response stream buffers to
		/// ensure the corresponding command operation continues to run.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// <c>WSMAN_FLAG_SERVER_BUFFERING_MODE_BLOCK</c>–When response stream buffers are full, the server blocks command execution. If no
		/// flag is specified, the server continues to use either the configured mode or the mode specified when the shell was created. In
		/// case of a network failure, if the client is unable to contact the session to disconnect the shell, the following error is returned:
		/// <para><c>ERROR_WINRS_SHELL_DISCONNECT_OPERATION_NOT_GRACEFUL</c></para>
		/// <para>
		/// The client session still goes into a disconnected state, but it is not guaranteed that any prior operations have completed
		/// before the session is disconnected.
		/// </para>
		/// </term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/nf-wsman-wsmandisconnectshell void WSManDisconnectShell(
		// WSMAN_SHELL_HANDLE shell, DWORD flags, WSMAN_SHELL_DISCONNECT_INFO *disconnectInfo, WSMAN_SHELL_ASYNC *async );
		[DllImport(Lib_WsmSvc, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wsman.h", MSDNShortId = "NF:wsman.WSManDisconnectShell")]
		public static extern void WSManDisconnectShell(WSMAN_SHELL_HANDLE shell, WSMAN_FLAG_SERVER_BUFFERING_MODE flags, ref WSMAN_SHELL_DISCONNECT_INFO disconnectInfo, ref WSMAN_SHELL_ASYNC async);

		/// <summary>Retrieves the error messages associated with a particular error and language codes.</summary>
		/// <param name="apiHandle">Specifies the API handle returned by a WSManInitialize call. This parameter cannot be <c>NULL</c>.</param>
		/// <param name="flags">Reserved for future use. Must be zero.</param>
		/// <param name="languageCode">
		/// Specifies the language code name that should be used to localize the error. For more information about the language code names,
		/// see the RFC 3066 specification from the Internet Engineering Task Force at http://www.ietf.org/rfc/rfc3066.txt. If a language
		/// code is not specified, the user interface language of the thread is used.
		/// </param>
		/// <param name="errorCode">
		/// Specifies the error code for the requested error message. This error code can be a hexadecimal or decimal error code from a
		/// WinRM, WinHTTP, or other Windows operating system feature.
		/// </param>
		/// <param name="messageLength">
		/// Specifies the number of characters that can be stored in the output message buffer, including the <c>null</c> terminator. If
		/// this parameter is zero, the message parameter must be <c>NULL</c>.
		/// </param>
		/// <param name="message">
		/// Specifies the output buffer to store the message in. This buffer must be allocated and deallocated by the client. The buffer
		/// must be large enough to store the message and the <c>null</c> terminator. If this parameter is <c>NULL</c>, the messageLength
		/// parameter must be <c>NULL</c>.
		/// </param>
		/// <param name="messageLengthUsed">
		/// Specifies the actual number of characters written to the output buffer, including the <c>null</c> terminator. This parameter
		/// cannot be <c>NULL</c>. If either the messageLength or message parameters are zero, the function will return
		/// <c>ERROR_INSUFFICIENT_BUFFER</c> and this parameter will be set to the number of characters needed to store the message,
		/// including the <c>null</c> terminator.
		/// </param>
		/// <returns>This method returns zero on success. Otherwise, this method returns an error code.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/nf-wsman-wsmangeterrormessage DWORD WSManGetErrorMessage(
		// WSMAN_API_HANDLE apiHandle, DWORD flags, PCWSTR languageCode, DWORD errorCode, DWORD messageLength, PWSTR message, DWORD
		// *messageLengthUsed );
		[DllImport(Lib_WsmSvc, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wsman.h", MSDNShortId = "NF:wsman.WSManGetErrorMessage")]
		public static extern uint WSManGetErrorMessage(WSMAN_API_HANDLE apiHandle, [Optional] uint flags,
			[Optional, MarshalAs(UnmanagedType.LPWStr)] string languageCode, uint errorCode, uint messageLength,
			[Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder message, out uint messageLengthUsed);

		/// <summary>Gets the value of a session option.</summary>
		/// <param name="session">Specifies the handle returned by a WSManCreateSession call. This parameter cannot be <c>NULL</c>.</param>
		/// <param name="option">
		/// Specifies the option to get. Not all session options can be retrieved. The options are defined in the WSManSessionOption enumeration.
		/// </param>
		/// <param name="value">Specifies the value of specified session option.</param>
		/// <returns>This method returns zero on success. Otherwise, this method returns an error code.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/nf-wsman-wsmangetsessionoptionasdword DWORD
		// WSManGetSessionOptionAsDword( WSMAN_SESSION_HANDLE session, WSManSessionOption option, DWORD *value );
		[DllImport(Lib_WsmSvc, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wsman.h", MSDNShortId = "NF:wsman.WSManGetSessionOptionAsDword")]
		public static extern uint WSManGetSessionOptionAsDword(WSMAN_SESSION_HANDLE session, WSManSessionOption option, ref uint value);

		/// <summary>Gets the value of a session option.</summary>
		/// <param name="session">Specifies the session handle returned by a WSManCreateSession call. This parameter cannot be <c>NULL</c>.</param>
		/// <param name="option">
		/// Specifies the option to get. Not all session options can be retrieved. The values for the options are defined in the
		/// WSManSessionOption enumeration.
		/// </param>
		/// <param name="stringLength">Specifies the length of the storage location for string parameter.</param>
		/// <param name="string">A pointer to the storage location for the value of the specified session option.</param>
		/// <param name="stringLengthUsed">Specifies the length of the string returned in the string parameter.</param>
		/// <returns>This method returns zero on success. Otherwise, this method returns an error code.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/nf-wsman-wsmangetsessionoptionasstring DWORD
		// WSManGetSessionOptionAsString( WSMAN_SESSION_HANDLE session, WSManSessionOption option, DWORD stringLength, PWSTR string, DWORD
		// *stringLengthUsed );
		[DllImport(Lib_WsmSvc, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wsman.h", MSDNShortId = "NF:wsman.WSManGetSessionOptionAsString")]
		public static extern uint WSManGetSessionOptionAsString(WSMAN_SESSION_HANDLE session, WSManSessionOption option, uint stringLength,
			[MarshalAs(UnmanagedType.LPWStr)] StringBuilder @string, out uint stringLengthUsed);

		/// <summary>
		/// Initializes the Windows Remote Management Client API. <c>WSManInitialize</c> can be used by different clients on the same process.
		/// </summary>
		/// <param name="flags">
		/// A flag of type <c>WSMAN_FLAG_REQUESTED_API_VERSION_1_0</c> or <c>WSMAN_FLAG_REQUESTED_API_VERSION_1_1</c>. The client that will
		/// use the disconnect-reconnect functionality should use the <c>WSMAN_FLAG_REQUESTED_API_VERSION_1_1</c> flag.
		/// </param>
		/// <param name="apiHandle">
		/// Defines a handle that uniquely identifies the client. This parameter cannot be <c>NULL</c>. When you have finished used the
		/// handle, close it by calling the WSManDeinitialize method.
		/// </param>
		/// <returns>This method returns zero on success. Otherwise, this method returns an error code.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/nf-wsman-wsmaninitialize DWORD WSManInitialize( DWORD flags,
		// WSMAN_API_HANDLE *apiHandle );
		[DllImport(Lib_WsmSvc, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wsman.h", MSDNShortId = "NF:wsman.WSManInitialize")]
		public static extern Win32Error WSManInitialize(WSMAN_FLAG_REQUESTED_API_VERSION flags, out SafeWSMAN_API_HANDLE apiHandle);

		/// <summary>
		/// Called from the WSManPluginAuthzOperation plug-in entry point. It reports either a successful or failed authorization for a user operation.
		/// </summary>
		/// <param name="senderDetails">
		/// A pointer to the WSMAN_SENDER_DETAILS structure that was passed into the WSManPluginAuthzOperation plug-in call.
		/// </param>
		/// <param name="flags">Reserved for future use. Must be zero.</param>
		/// <param name="userAuthorizationContext">
		/// Specifies a plug-in defined context that is used to help track user context information. This context can be returned to
		/// multiple calls, to this call, or to an operation call. The plug-in manages reference counting for all calls. If the user record
		/// times out or re-authorization is required, the WinRM (WinRM) infrastructure calls WSManPluginAuthzReleaseContext.
		/// </param>
		/// <param name="errorCode">
		/// Reports either a successful or failed authorization. If the authorization is successful, the code should be
		/// <c>ERROR_SUCCESS</c>. If the user is not authorized to perform the operation, the error should be <c>ERROR_ACCESS_DENIED</c>. If
		/// a failure happens for any other reason, an appropriate error code should be used. Any error from this call will be sent back as
		/// a Simple Object Access Protocol (SOAP) fault packet.
		/// </param>
		/// <param name="extendedErrorInformation">
		/// Specifies an XML document that contains any extra error information that needs to be reported to the client. This parameter is
		/// ignored if errorCode is <c>NO_ERROR</c>. The user interface language of the thread should be used for localization.
		/// </param>
		/// <returns>
		/// The method returns <c>ERROR_SUCCESS</c> if it succeeded; otherwise, it returns <c>ERROR_INVALID_PARAMETER</c>. If
		/// <c>ERROR_INVALID_PARAMETER</c> is returned, either the senderDetails parameter was <c>NULL</c> or the flags parameter was not zero.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/nf-wsman-wsmanpluginauthzoperationcomplete DWORD
		// WSManPluginAuthzOperationComplete( WSMAN_SENDER_DETAILS *senderDetails, DWORD flags, PVOID userAuthorizationContext, DWORD
		// errorCode, PCWSTR extendedErrorInformation );
		[DllImport(Lib_WsmSvc, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wsman.h", MSDNShortId = "NF:wsman.WSManPluginAuthzOperationComplete")]
		public static extern uint WSManPluginAuthzOperationComplete(in WSMAN_SENDER_DETAILS senderDetails, [Optional] uint flags,
			[In, Optional] IntPtr userAuthorizationContext, uint errorCode, [Optional, MarshalAs(UnmanagedType.LPWStr)] string extendedErrorInformation);

		/// <summary>
		/// Called from the WSManPluginAuthzQueryQuota plug-in entry point and must be called whether or not the plug-in can carry out the request.
		/// </summary>
		/// <param name="senderDetails">
		/// A pointer to the WSMAN_SENDER_DETAILS structure that was passed into the WSManPluginAuthzQueryQuota plug-in call.
		/// </param>
		/// <param name="flags">Reserved for future use. Must be zero.</param>
		/// <param name="quota">A pointer to a WSMAN_AUTHZ_QUOTA structure that specifies quota information for a specific user.</param>
		/// <param name="errorCode">
		/// Reports either a successful or failed authorization. If the authorization is successful, the code should be
		/// <c>ERROR_SUCCESS</c>. If a failure happens for any other reason, an appropriate error code should be used. Any error from this
		/// call will be sent back as a Simple Object Access Protocol (SOAP) fault packet.
		/// </param>
		/// <param name="extendedErrorInformation">
		/// Specifies an XML document that contains any extra error information that needs to be reported to the client. This parameter is
		/// ignored if errorCode is <c>NO_ERROR</c>. The user interface language of the thread should be used for localization.
		/// </param>
		/// <returns>
		/// The method returns <c>ERROR_SUCCESS</c> if it succeeded; otherwise, it returns <c>ERROR_INVALID_PARAMETER</c>. If
		/// <c>ERROR_INVALID_PARAMETER</c> is returned, either the senderDetails parameter was <c>NULL</c> or the flags parameter was not
		/// zero. If the method fails, the default quota is used.
		/// </returns>
		/// <remarks>
		/// If the quota parameter is <c>null</c> and the errorCode is <c>NO_ERROR</c>, the method returns <c>ERROR_INVALID_PARAMETER</c>
		/// and the plug-in returns the default quota information. If the plug-in is not returning a quota, the authorization plug-in should
		/// not specify that quotas are available in the configuration because performance might be affected.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/nf-wsman-wsmanpluginauthzqueryquotacomplete DWORD
		// WSManPluginAuthzQueryQuotaComplete( WSMAN_SENDER_DETAILS *senderDetails, DWORD flags, WSMAN_AUTHZ_QUOTA *quota, DWORD errorCode,
		// PCWSTR extendedErrorInformation );
		[DllImport(Lib_WsmSvc, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wsman.h", MSDNShortId = "NF:wsman.WSManPluginAuthzQueryQuotaComplete")]
		public static extern uint WSManPluginAuthzQueryQuotaComplete(in WSMAN_SENDER_DETAILS senderDetails, [Optional] uint flags,
			in WSMAN_AUTHZ_QUOTA quota, uint errorCode, [Optional, MarshalAs(UnmanagedType.LPWStr)] string extendedErrorInformation);

		/// <summary>
		/// Called from the WSManPluginAuthzQueryQuota plug-in entry point and must be called whether or not the plug-in can carry out the request.
		/// </summary>
		/// <param name="senderDetails">
		/// A pointer to the WSMAN_SENDER_DETAILS structure that was passed into the WSManPluginAuthzQueryQuota plug-in call.
		/// </param>
		/// <param name="flags">Reserved for future use. Must be zero.</param>
		/// <param name="quota">A pointer to a WSMAN_AUTHZ_QUOTA structure that specifies quota information for a specific user.</param>
		/// <param name="errorCode">
		/// Reports either a successful or failed authorization. If the authorization is successful, the code should be
		/// <c>ERROR_SUCCESS</c>. If a failure happens for any other reason, an appropriate error code should be used. Any error from this
		/// call will be sent back as a Simple Object Access Protocol (SOAP) fault packet.
		/// </param>
		/// <param name="extendedErrorInformation">
		/// Specifies an XML document that contains any extra error information that needs to be reported to the client. This parameter is
		/// ignored if errorCode is <c>NO_ERROR</c>. The user interface language of the thread should be used for localization.
		/// </param>
		/// <returns>
		/// The method returns <c>ERROR_SUCCESS</c> if it succeeded; otherwise, it returns <c>ERROR_INVALID_PARAMETER</c>. If
		/// <c>ERROR_INVALID_PARAMETER</c> is returned, either the senderDetails parameter was <c>NULL</c> or the flags parameter was not
		/// zero. If the method fails, the default quota is used.
		/// </returns>
		/// <remarks>
		/// If the quota parameter is <c>null</c> and the errorCode is <c>NO_ERROR</c>, the method returns <c>ERROR_INVALID_PARAMETER</c>
		/// and the plug-in returns the default quota information. If the plug-in is not returning a quota, the authorization plug-in should
		/// not specify that quotas are available in the configuration because performance might be affected.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/nf-wsman-wsmanpluginauthzqueryquotacomplete DWORD
		// WSManPluginAuthzQueryQuotaComplete( WSMAN_SENDER_DETAILS *senderDetails, DWORD flags, WSMAN_AUTHZ_QUOTA *quota, DWORD errorCode,
		// PCWSTR extendedErrorInformation );
		[DllImport(Lib_WsmSvc, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wsman.h", MSDNShortId = "NF:wsman.WSManPluginAuthzQueryQuotaComplete")]
		public static extern uint WSManPluginAuthzQueryQuotaComplete(in WSMAN_SENDER_DETAILS senderDetails, [Optional] uint flags,
			[In, Optional] IntPtr quota, uint errorCode, [Optional, MarshalAs(UnmanagedType.LPWStr)] string extendedErrorInformation);

		/// <summary>
		/// Called from the WSManPluginAuthzUser plug-in entry point and reports either a successful or failed user connection authorization.
		/// </summary>
		/// <param name="senderDetails">
		/// A pointer to the WSMAN_SENDER_DETAILS structure that was passed into the WSManPluginAuthzUser plug-in call.
		/// </param>
		/// <param name="flags">Reserved for future use. Must be set to zero.</param>
		/// <param name="userAuthorizationContext">
		/// Specifies a plug-in defined context that is used to help track user context information. This context can be returned to
		/// multiple calls, to this call, or to an operation call. The plug-in manages reference counting for all calls. If the user record
		/// times out or re-authorization is required, the WinRM infrastructure calls WSManPluginAuthzReleaseContext.
		/// </param>
		/// <param name="impersonationToken">
		/// <para>
		/// Specifies the identity of the user. This parameter is the clientToken that was passed into senderDetails. If the plug-in changes
		/// the user context, a new impersonation token should be returned.
		/// </para>
		/// <para><c>Note</c> This token is released after the operation has been completed.</para>
		/// </param>
		/// <param name="userIsAdministrator">Set to <c>TRUE</c> if the user is an administrator. Otherwise, this parameter is <c>FALSE</c>.</param>
		/// <param name="errorCode">
		/// Reports either a successful or failed authorization. If the authorization is successful, the code should be
		/// <c>ERROR_SUCCESS</c>. If the user is not authorized to perform the operation, the error should be <c>ERROR_ACCESS_DENIED</c>. If
		/// a failure happens for any other reason, an appropriate error code should be used. Any error from this call will be sent back as
		/// a SOAP fault packet.
		/// </param>
		/// <param name="extendedErrorInformation">
		/// Specifies an XML document that contains any extra error information that needs to be reported to the client. This parameter is
		/// ignored if errorCode is <c>NO_ERROR</c>. The user interface language of the thread should be used for localization.
		/// </param>
		/// <returns>
		/// The method returns <c>ERROR_SUCCESS</c> if it succeeded; otherwise, it returns <c>ERROR_INVALID_PARAMETER</c>. If
		/// <c>ERROR_INVALID_PARAMETER</c> is returned, either the senderDetails parameter was <c>NULL</c> or the flags parameter was not zero.
		/// </returns>
		/// <remarks>
		/// <para>
		/// If the impersonation token passed into senderDetails is not the identity with which the operation should be performed, or if no
		/// impersonation token is available and the plug-in specifies a new identity to carry out the request, the plug-in should return
		/// the new impersonationToken that the WSMan infrastructure will use to impersonate the client before calling into the operation
		/// plug-in. If an impersonation token is provided in the senderDetails and the plug-in wants to carry out the operation under that
		/// identity, the plug-in should copy the impersonation token from the senderDetails into the impersonationToken parameter. If the
		/// plug-in wants to carry out the request under the context of the Internet Information Services (IIS) host process, the
		/// impersonationToken should be <c>NULL</c>. If the impersonationToken is <c>NULL</c>, the thread will impersonate the process
		/// token before calling into the operation plug-in.
		/// </para>
		/// <para>
		/// If the userIsAdministrator parameter is set to <c>TRUE</c>, the user is allowed to view and delete shells owned by different users.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/nf-wsman-wsmanpluginauthzusercomplete DWORD
		// WSManPluginAuthzUserComplete( WSMAN_SENDER_DETAILS *senderDetails, DWORD flags, PVOID userAuthorizationContext, HANDLE
		// impersonationToken, BOOL userIsAdministrator, DWORD errorCode, PCWSTR extendedErrorInformation );
		[DllImport(Lib_WsmSvc, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wsman.h", MSDNShortId = "NF:wsman.WSManPluginAuthzUserComplete")]
		public static extern uint WSManPluginAuthzUserComplete(in WSMAN_SENDER_DETAILS senderDetails, [Optional] uint flags,
			[In, Optional] IntPtr userAuthorizationContext, [In, Optional] HTOKEN impersonationToken,
			[MarshalAs(UnmanagedType.Bool)] bool userIsAdministrator, uint errorCode,
			[Optional, MarshalAs(UnmanagedType.LPWStr)] string extendedErrorInformation);

		/// <summary>
		/// Releases memory that is allocated for the WSMAN_PLUGIN_REQUEST structure, which is passed into operation plug-in entry points.
		/// This method is optional and can be called at any point after a plug-in entry point is called and before the entry point calls
		/// the WSManPluginOperationComplete method. After this method is called, the memory will be released and the plug-in will be unable
		/// to access any of the parameters in the WSMAN_PLUGIN_REQUEST structure.
		/// </summary>
		/// <param name="requestDetails">
		/// A pointer to a WSMAN_PLUGIN_REQUEST structure that specifies the resource URI, options, locale, shutdown flag, and handle for
		/// the request.
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/nf-wsman-wsmanpluginfreerequestdetails DWORD
		// WSManPluginFreeRequestDetails( WSMAN_PLUGIN_REQUEST *requestDetails );
		[DllImport(Lib_WsmSvc, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wsman.h", MSDNShortId = "NF:wsman.WSManPluginFreeRequestDetails")]
		public static extern uint WSManPluginFreeRequestDetails(in WSMAN_PLUGIN_REQUEST requestDetails);

		/// <summary>
		/// Gets operational information for items such as time-outs and data restrictions that are associated with the operation. A plug-in
		/// should not use these parameters for anything other than informational purposes.
		/// </summary>
		/// <param name="requestDetails">
		/// A pointer to a WSMAN_PLUGIN_REQUEST structure that specifies the resource URI, options, locale, shutdown flag, and handle for
		/// the request.
		/// </param>
		/// <param name="flags">
		/// <para>
		/// Specifies the options that are available for retrieval. This parameter must be set to either one of the following values or to a
		/// value defined by the plug-in.
		/// </para>
		/// <para>WSMAN_PLUGIN_PARAMS_MAX_ENVELOPE_SIZE (1)</para>
		/// <para>
		/// Specifies the maximum size of the operation response packet. The size includes the size of the data along with the Simple Object
		/// Access Protocol (SOAP) overhead.
		/// </para>
		/// <para>
		/// <c>Note</c> Some operations have a single call into the plug-in that can cause multiple roundtrips to occur. If no requests are
		/// waiting for data when this method is called, the maximum envelope size for the previous packet is given.
		/// </para>
		/// <para>WSMAN_PLUGIN_PARAMS_TIMEOUT (2)</para>
		/// <para>Specifies the time-out of the current operation.</para>
		/// <para>
		/// <c>Note</c> Some operations have a single call into the plug-in that can cause multiple roundtrips to occur. If no requests are
		/// waiting for data when this method is called, the time-out for the previous packet is given.
		/// </para>
		/// <para>WSMAN_PLUGIN_PARAMS_REMAINING_RESULT_SIZE (3)</para>
		/// <para>
		/// Specifies how much space is left for data for the current operation. The size is based on the type of operation. For example,
		/// this flag would represent how large the single result item can be for a get operation. For enumerations, the size will decrease
		/// after each object is added. After the current packet has been filled with enumerations and get operations, it will be returned
		/// to the client even though more data is being accepted and cached.
		/// </para>
		/// <para>
		/// <c>Note</c> Some operations have a single call into the plug-in that can cause multiple roundtrips to occur. If no requests are
		/// waiting for data when this method is called, the remaining size is given for a cached item.
		/// </para>
		/// <para>WSMAN_PLUGIN_PARAMS_LARGEST_RESULT_SIZE (4)</para>
		/// <para>Specifies the maximum size of the data for the current operation.</para>
		/// <para>WSMAN_PLUGIN_PARAMS_GET_REQUESTED_LOCALE (5)</para>
		/// <para>Specifies the language locale that was requested by the client for the operation.</para>
		/// <para>WSMAN_PLUGIN_PARAMS_GET_REQUESTED_DATA_LOCALE (6)</para>
		/// <para>Specifies the language locale of the data that was requested by the client.</para>
		/// </param>
		/// <param name="data">A pointer to a WSMAN_DATA structure that specifies the result object.</param>
		/// <returns>
		/// The method returns <c>NO_ERROR</c> if it succeeded; otherwise, it returns an error code. The following are the most common error codes:
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/nf-wsman-wsmanplugingetoperationparameters DWORD
		// WSManPluginGetOperationParameters( WSMAN_PLUGIN_REQUEST *requestDetails, DWORD flags, WSMAN_DATA *data );
		[DllImport(Lib_WsmSvc, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wsman.h", MSDNShortId = "NF:wsman.WSManPluginGetOperationParameters")]
		public static extern uint WSManPluginGetOperationParameters(in WSMAN_PLUGIN_REQUEST requestDetails, WSMAN_PLUGIN_PARAMS_OP flags,
			out WSMAN_DATA data);

		/// <summary>
		/// Reports the completion of an operation by all operation entry points except for the WSManPluginStartup and WSManPluginShutdown methods.
		/// </summary>
		/// <param name="requestDetails">
		/// A pointer to a WSMAN_PLUGIN_REQUEST structure that specifies the resource URI, options, locale, shutdown flag, and handle for
		/// the request.
		/// </param>
		/// <param name="flags">Reserved for future use. Must be zero.</param>
		/// <param name="errorCode">
		/// Reports any failure in the operation. If this parameter is not <c>NO_ERROR</c>, any result data that has not been sent will be
		/// discarded and the error will be sent.
		/// </param>
		/// <param name="extendedInformation">
		/// Specifies an XML document that contains any extra error information that needs to be reported to the client. This parameter is
		/// ignored if errorCode is <c>NO_ERROR</c>. The user interface language of the thread should be used for localization.
		/// </param>
		/// <returns>
		/// The method returns <c>NO_ERROR</c> if it succeeded; otherwise, it returns an error code. If the operation is unsuccessful, the
		/// plug-in must stop the current operation and clean up any data associated with this operation. The requestDetails structure is
		/// not valid if an error is received and must not be passed to any other WinRM (WinRM) method.
		/// </returns>
		/// <remarks>
		/// The <c>WSManPluginOperationComplete</c> function is used to report the completion of the data stream for WSManPluginReceive. The
		/// WSManPluginShell and WSManPluginCommand operations must also call this function when the shell and command operations are complete.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/nf-wsman-wsmanpluginoperationcomplete DWORD
		// WSManPluginOperationComplete( WSMAN_PLUGIN_REQUEST *requestDetails, DWORD flags, DWORD errorCode, PCWSTR extendedInformation );
		[DllImport(Lib_WsmSvc, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wsman.h", MSDNShortId = "NF:wsman.WSManPluginOperationComplete")]
		public static extern uint WSManPluginOperationComplete(in WSMAN_PLUGIN_REQUEST requestDetails, [Optional] uint flags,
			uint errorCode, [Optional, MarshalAs(UnmanagedType.LPWStr)] string extendedInformation);

		/// <summary>
		/// Reports results for the WSMAN_PLUGIN_RECEIVE plug-in call and is used by most shell plug-ins that return results. After all of
		/// the data is received, the WSManPluginOperationComplete method must be called.
		/// </summary>
		/// <param name="requestDetails">
		/// A pointer to a WSMAN_PLUGIN_REQUEST structure that specifies the resource URI, options, locale, shutdown flag, and handle for
		/// the request.
		/// </param>
		/// <param name="flags">Reserved for future use. Must be set to zero.</param>
		/// <param name="stream">
		/// Specifies the stream that the data is associated with. Any stream can be used, but the standard streams are STDIN, STDOUT, and STDERR.
		/// </param>
		/// <param name="streamResult">
		/// A pointer to a WSMAN_DATA structure that specifies the result object that is returned to the client. The result can be in either
		/// binary or XML format.
		/// </param>
		/// <param name="commandState">
		/// <para>
		/// Specifies the state of the command. This parameter must be set either to one of the following values or to a value defined by
		/// the plug-in.
		/// </para>
		/// <para>WSMAN_RECEIVE_STATE_NONE</para>
		/// <para>The operation requires no action.</para>
		/// <para>WSMAN_RECEIVE_STATE_NORMAL_TERMINATION</para>
		/// <para>The operation was terminated normally.</para>
		/// <para>WSMAN_RECEIVE_STATE_ABNORMAL_TERMINATION</para>
		/// <para>The operation was terminated unexpectedly.</para>
		/// <para>WSMAN_RECEIVE_STATE_WAITING</para>
		/// <para>The operation is waiting for input.</para>
		/// <para>WSMAN_RECEIVE_STATE_INPUT_REQUIRED</para>
		/// <para>The operation requires command-line input.</para>
		/// </param>
		/// <param name="exitCode">
		/// Ignored in all cases except when commandState is either <c>WSMAN_RECEIVE_STATE_NORMAL_TERMINATION</c> or
		/// <c>WSMAN_RECEIVE_STATE_ABNORMAL_TERMINATION</c>. Each result can have separate error codes. If the command or stream has failed,
		/// the plug-in must call the WSManPluginOperationComplete method.
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/nf-wsman-wsmanpluginreceiveresult DWORD WSManPluginReceiveResult(
		// WSMAN_PLUGIN_REQUEST *requestDetails, DWORD flags, PCWSTR stream, WSMAN_DATA *streamResult, PCWSTR commandState, DWORD exitCode );
		[DllImport(Lib_WsmSvc, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wsman.h", MSDNShortId = "NF:wsman.WSManPluginReceiveResult")]
		public static extern uint WSManPluginReceiveResult(in WSMAN_PLUGIN_REQUEST requestDetails, [Optional] uint flags,
			[Optional, MarshalAs(UnmanagedType.LPWStr)] string stream, in WSMAN_DATA streamResult,
			[Optional, MarshalAs(UnmanagedType.LPWStr)] string commandState, uint exitCode);

		/// <summary>
		/// Reports results for the WSMAN_PLUGIN_RECEIVE plug-in call and is used by most shell plug-ins that return results. After all of
		/// the data is received, the WSManPluginOperationComplete method must be called.
		/// </summary>
		/// <param name="requestDetails">
		/// A pointer to a WSMAN_PLUGIN_REQUEST structure that specifies the resource URI, options, locale, shutdown flag, and handle for
		/// the request.
		/// </param>
		/// <param name="flags">Reserved for future use. Must be set to zero.</param>
		/// <param name="stream">
		/// Specifies the stream that the data is associated with. Any stream can be used, but the standard streams are STDIN, STDOUT, and STDERR.
		/// </param>
		/// <param name="streamResult">
		/// A pointer to a WSMAN_DATA structure that specifies the result object that is returned to the client. The result can be in either
		/// binary or XML format.
		/// </param>
		/// <param name="commandState">
		/// <para>
		/// Specifies the state of the command. This parameter must be set either to one of the following values or to a value defined by
		/// the plug-in.
		/// </para>
		/// <para>WSMAN_RECEIVE_STATE_NONE</para>
		/// <para>The operation requires no action.</para>
		/// <para>WSMAN_RECEIVE_STATE_NORMAL_TERMINATION</para>
		/// <para>The operation was terminated normally.</para>
		/// <para>WSMAN_RECEIVE_STATE_ABNORMAL_TERMINATION</para>
		/// <para>The operation was terminated unexpectedly.</para>
		/// <para>WSMAN_RECEIVE_STATE_WAITING</para>
		/// <para>The operation is waiting for input.</para>
		/// <para>WSMAN_RECEIVE_STATE_INPUT_REQUIRED</para>
		/// <para>The operation requires command-line input.</para>
		/// </param>
		/// <param name="exitCode">
		/// Ignored in all cases except when commandState is either <c>WSMAN_RECEIVE_STATE_NORMAL_TERMINATION</c> or
		/// <c>WSMAN_RECEIVE_STATE_ABNORMAL_TERMINATION</c>. Each result can have separate error codes. If the command or stream has failed,
		/// the plug-in must call the WSManPluginOperationComplete method.
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/nf-wsman-wsmanpluginreceiveresult DWORD WSManPluginReceiveResult(
		// WSMAN_PLUGIN_REQUEST *requestDetails, DWORD flags, PCWSTR stream, WSMAN_DATA *streamResult, PCWSTR commandState, DWORD exitCode );
		[DllImport(Lib_WsmSvc, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wsman.h", MSDNShortId = "NF:wsman.WSManPluginReceiveResult")]
		public static extern uint WSManPluginReceiveResult(in WSMAN_PLUGIN_REQUEST requestDetails, [Optional] uint flags,
			[Optional, MarshalAs(UnmanagedType.LPWStr)] string stream, [In, Optional] IntPtr streamResult,
			[Optional, MarshalAs(UnmanagedType.LPWStr)] string commandState, uint exitCode);

		/// <summary>
		/// Reports shell and command context back to the Windows Remote Management (WinRM) infrastructure so that further operations can be
		/// performed against the shell and/or command. This method is called only for WSManPluginShell and WSManPluginCommand plug-in entry points.
		/// </summary>
		/// <param name="requestDetails">
		/// A pointer to a WSMAN_PLUGIN_REQUEST structure that specifies the resource URI, options, locale, shutdown flag, and handle for
		/// the request.
		/// </param>
		/// <param name="flags">Reserved for future use. Must be set to zero.</param>
		/// <param name="context">
		/// Defines the value to pass into all future shell and command operations. Represents either the shell or the command. This value
		/// should be unique for all shells, and it should also be unique for all commands associated with a shell.
		/// </param>
		/// <returns>
		/// The method returns <c>NO_ERROR</c> if it succeeded; otherwise, it returns an error code. If this method returns an error, the
		/// plug-in should shut down the current operation and call the WSManPluginOperationComplete method.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/nf-wsman-wsmanpluginreportcontext DWORD WSManPluginReportContext(
		// WSMAN_PLUGIN_REQUEST *requestDetails, DWORD flags, PVOID context );
		[DllImport(Lib_WsmSvc, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wsman.h", MSDNShortId = "NF:wsman.WSManPluginReportContext")]
		public static extern uint WSManPluginReportContext(in WSMAN_PLUGIN_REQUEST requestDetails, [Optional] uint flags, [In, Optional] IntPtr context);

		/// <summary>Retrieves output from a running command or from the shell.</summary>
		/// <param name="shell">Specifies the shell handle returned by a WSManCreateShell call. This parameter cannot be <c>NULL</c>.</param>
		/// <param name="command">Specifies the command handle returned by a WSManRunShellCommand call.</param>
		/// <param name="flags">Reserved for future use. Must be set to zero.</param>
		/// <param name="desiredStreamSet">Specifies the requested output from a particular stream or a list of streams.</param>
		/// <param name="async">
		/// Defines an asynchronous structure. The asynchronous structure contains an optional user context and a mandatory callback
		/// function. See the WSMAN_SHELL_ASYNC structure for more information. This parameter cannot be <c>NULL</c> and should be closed by
		/// calling the WSManCloseOperation method.
		/// </param>
		/// <param name="receiveOperation">
		/// Defines the operation handle for the receive operation. This handle is returned from a successful call of the function and can
		/// be used to asynchronously cancel the receive operation. This handle should be closed by calling the WSManCloseOperation method.
		/// This parameter cannot be <c>NULL</c>.
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/nf-wsman-wsmanreceiveshelloutput void WSManReceiveShellOutput(
		// WSMAN_SHELL_HANDLE shell, WSMAN_COMMAND_HANDLE command, DWORD flags, WSMAN_STREAM_ID_SET *desiredStreamSet, WSMAN_SHELL_ASYNC
		// *async, WSMAN_OPERATION_HANDLE *receiveOperation );
		[DllImport(Lib_WsmSvc, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wsman.h", MSDNShortId = "NF:wsman.WSManReceiveShellOutput")]
		public static extern void WSManReceiveShellOutput(WSMAN_SHELL_HANDLE shell, [In, Optional] WSMAN_COMMAND_HANDLE command, [In, Optional] uint flags,
			in WSMAN_STREAM_ID_SET desiredStreamSet, in WSMAN_SHELL_ASYNC async, out SafeWSMAN_OPERATION_HANDLE receiveOperation);

		/// <summary>Retrieves output from a running command or from the shell.</summary>
		/// <param name="shell">Specifies the shell handle returned by a WSManCreateShell call. This parameter cannot be <c>NULL</c>.</param>
		/// <param name="command">Specifies the command handle returned by a WSManRunShellCommand call.</param>
		/// <param name="flags">Reserved for future use. Must be set to zero.</param>
		/// <param name="desiredStreamSet">Specifies the requested output from a particular stream or a list of streams.</param>
		/// <param name="async">
		/// Defines an asynchronous structure. The asynchronous structure contains an optional user context and a mandatory callback
		/// function. See the WSMAN_SHELL_ASYNC structure for more information. This parameter cannot be <c>NULL</c> and should be closed by
		/// calling the WSManCloseOperation method.
		/// </param>
		/// <param name="receiveOperation">
		/// Defines the operation handle for the receive operation. This handle is returned from a successful call of the function and can
		/// be used to asynchronously cancel the receive operation. This handle should be closed by calling the WSManCloseOperation method.
		/// This parameter cannot be <c>NULL</c>.
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/nf-wsman-wsmanreceiveshelloutput void WSManReceiveShellOutput(
		// WSMAN_SHELL_HANDLE shell, WSMAN_COMMAND_HANDLE command, DWORD flags, WSMAN_STREAM_ID_SET *desiredStreamSet, WSMAN_SHELL_ASYNC
		// *async, WSMAN_OPERATION_HANDLE *receiveOperation );
		[DllImport(Lib_WsmSvc, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wsman.h", MSDNShortId = "NF:wsman.WSManReceiveShellOutput")]
		public static extern void WSManReceiveShellOutput(WSMAN_SHELL_HANDLE shell, [In, Optional] WSMAN_COMMAND_HANDLE command, [In, Optional] uint flags,
			[In, Optional] IntPtr desiredStreamSet, in WSMAN_SHELL_ASYNC async, out SafeWSMAN_OPERATION_HANDLE receiveOperation);

		/// <summary>Reconnects a previously disconnected shell session. To reconnect the shell session's associated commands, use WSManReconnectShellCommand.</summary>
		/// <param name="shell">Specifies the handle returned by a call to the WSManCreateShell function. This parameter cannot be <c>NULL</c>.</param>
		/// <param name="flags">This parameter is reserved for future use and must be set to zero.</param>
		/// <param name="async">
		/// Defines an asynchronous structure to contain an optional user context and a mandatory callback function. For more information,
		/// see WSMAN_SHELL_ASYNC. This parameter cannot be <c>NULL</c>.
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/nf-wsman-wsmanreconnectshell void WSManReconnectShell(
		// WSMAN_SHELL_HANDLE shell, DWORD flags, WSMAN_SHELL_ASYNC *async );
		[DllImport(Lib_WsmSvc, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wsman.h", MSDNShortId = "NF:wsman.WSManReconnectShell")]
		public static extern void WSManReconnectShell([In, Out] WSMAN_SHELL_HANDLE shell, uint flags, in WSMAN_SHELL_ASYNC async);

		/// <summary>Reconnects a previously disconnected command.</summary>
		/// <param name="commandHandle">
		/// Specifies the handle returned by a WSManRunShellCommand call or a WSManConnectShellCommand call. This parameter cannot be NULL.
		/// </param>
		/// <param name="flags">Reserved for future use. Must be set to zero.</param>
		/// <param name="async">
		/// Defines an asynchronous structure which will contain an optional user context and a mandatory callback function. See the
		/// WSMAN_SHELL_ASYNC structure for more information. This parameter cannot be NULL.
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/nf-wsman-wsmanreconnectshellcommand void WSManReconnectShellCommand(
		// WSMAN_COMMAND_HANDLE commandHandle, DWORD flags, WSMAN_SHELL_ASYNC *async );
		[DllImport(Lib_WsmSvc, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wsman.h", MSDNShortId = "NF:wsman.WSManReconnectShellCommand")]
		public static extern void WSManReconnectShellCommand([In, Out] WSMAN_COMMAND_HANDLE commandHandle, [Optional] uint flags,
			in WSMAN_SHELL_ASYNC async);

		/// <summary>Starts the execution of a command within an existing shell and does not wait for the completion of the command.</summary>
		/// <param name="shell">Specifies the shell handle returned by the WSManCreateShell call. This parameter cannot be <c>NULL</c>.</param>
		/// <param name="flags">Reserved for future use. Must be zero.</param>
		/// <param name="commandLine">
		/// Defines a required <c>null</c>-terminated string that represents the command to be executed. Typically, the command is specified
		/// without any arguments, which are specified separately. However, a user can specify the command line and all of the arguments by
		/// using this parameter. If arguments are specified for the commandLine parameter, the args parameter should be <c>NULL</c>.
		/// </param>
		/// <param name="args">
		/// A pointer to a WSMAN_COMMAND_ARG_SET structure that defines an array of argument values, which are passed to the command on
		/// creation. If no arguments are required, this parameter should be <c>NULL</c>.
		/// </param>
		/// <param name="options">
		/// Defines a set of options for the command. These options are passed to the service to modify or refine the command execution.
		/// This parameter can be <c>NULL</c>. For more information about the options, see WSMAN_OPTION_SET.
		/// </param>
		/// <param name="async">
		/// Defines an asynchronous structure. The asynchronous structure contains an optional user context and a mandatory callback
		/// function. See the WSMAN_SHELL_ASYNC structure for more information. This parameter cannot be <c>NULL</c> and should be closed by
		/// calling the WSManCloseCommand method.
		/// </param>
		/// <param name="command">
		/// Defines the command object associated with a command within a shell. This handle is returned on a successful call and is used to
		/// send and receive data and to signal the command. This handle should be closed by calling the WSManCloseCommand method. This
		/// parameter cannot be <c>NULL</c>.
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/nf-wsman-wsmanrunshellcommand void WSManRunShellCommand(
		// WSMAN_SHELL_HANDLE shell, DWORD flags, PCWSTR commandLine, WSMAN_COMMAND_ARG_SET *args, WSMAN_OPTION_SET *options,
		// WSMAN_SHELL_ASYNC *async, WSMAN_COMMAND_HANDLE *command );
		[DllImport(Lib_WsmSvc, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wsman.h", MSDNShortId = "NF:wsman.WSManRunShellCommand")]
		public static extern void WSManRunShellCommand(WSMAN_SHELL_HANDLE shell, [Optional] uint flags, [MarshalAs(UnmanagedType.LPWStr)] string commandLine,
			in WSMAN_COMMAND_ARG_SET args, in WSMAN_OPTION_SET options, in WSMAN_SHELL_ASYNC async, out WSMAN_COMMAND_HANDLE command);

		/// <summary>Starts the execution of a command within an existing shell and does not wait for the completion of the command.</summary>
		/// <param name="shell">Specifies the shell handle returned by the WSManCreateShell call. This parameter cannot be <c>NULL</c>.</param>
		/// <param name="flags">Reserved for future use. Must be zero.</param>
		/// <param name="commandLine">
		/// Defines a required <c>null</c>-terminated string that represents the command to be executed. Typically, the command is specified
		/// without any arguments, which are specified separately. However, a user can specify the command line and all of the arguments by
		/// using this parameter. If arguments are specified for the commandLine parameter, the args parameter should be <c>NULL</c>.
		/// </param>
		/// <param name="args">
		/// A pointer to a WSMAN_COMMAND_ARG_SET structure that defines an array of argument values, which are passed to the command on
		/// creation. If no arguments are required, this parameter should be <c>NULL</c>.
		/// </param>
		/// <param name="options">
		/// Defines a set of options for the command. These options are passed to the service to modify or refine the command execution.
		/// This parameter can be <c>NULL</c>. For more information about the options, see WSMAN_OPTION_SET.
		/// </param>
		/// <param name="async">
		/// Defines an asynchronous structure. The asynchronous structure contains an optional user context and a mandatory callback
		/// function. See the WSMAN_SHELL_ASYNC structure for more information. This parameter cannot be <c>NULL</c> and should be closed by
		/// calling the WSManCloseCommand method.
		/// </param>
		/// <param name="command">
		/// Defines the command object associated with a command within a shell. This handle is returned on a successful call and is used to
		/// send and receive data and to signal the command. This handle should be closed by calling the WSManCloseCommand method. This
		/// parameter cannot be <c>NULL</c>.
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/nf-wsman-wsmanrunshellcommand void WSManRunShellCommand(
		// WSMAN_SHELL_HANDLE shell, DWORD flags, PCWSTR commandLine, WSMAN_COMMAND_ARG_SET *args, WSMAN_OPTION_SET *options,
		// WSMAN_SHELL_ASYNC *async, WSMAN_COMMAND_HANDLE *command );
		[DllImport(Lib_WsmSvc, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wsman.h", MSDNShortId = "NF:wsman.WSManRunShellCommand")]
		public static extern void WSManRunShellCommand(WSMAN_SHELL_HANDLE shell, [Optional] uint flags, [MarshalAs(UnmanagedType.LPWStr)] string commandLine,
			[In, Optional] IntPtr args, [In, Optional] IntPtr options, in WSMAN_SHELL_ASYNC async, out WSMAN_COMMAND_HANDLE command);

		/// <summary>
		/// Provides the same functionality as the WSManRunShellCommand function, with the addition of a command ID option. If the server
		/// supports the protocol, it will create the command instance using the ID specified by the client. If a command with the specified
		/// ID already exists, the server will fail to create the command instance. This new functionality is only available when the client
		/// application passes the <c>WSMAN_FLAG_REQUESTED_API_VERSION_1_1</c> flag as part of the call to the WSManInitialize function.
		/// </summary>
		/// <param name="shell">Specifies the shell handle returned by the WSManCreateShell call. This parameter cannot be <c>NULL</c>.</param>
		/// <param name="flags">Reserved for future use. Must be 0.</param>
		/// <param name="commandId">The client specified command Id.</param>
		/// <param name="commandLine">
		/// Defines a required null-terminated string that represents the command to be executed. Typically, the command is specified
		/// without any arguments, which are specified separately. However, a user can specify the command line and all of the arguments by
		/// using this parameter. If arguments are specified for the commandLine parameter, the args parameter should be <c>NULL</c>.
		/// </param>
		/// <param name="args">
		/// A pointer to a WSMAN_COMMAND_ARG_SET structure that defines an array of argument values, which are passed to the command on
		/// creation. If no arguments are required, this parameter should be <c>NULL</c>.
		/// </param>
		/// <param name="options">
		/// Defines a set of options for the command. These options are passed to the service to modify or refine the command execution.
		/// This parameter can be <c>NULL</c>. For more information about the options, see WSMAN_OPTION_SET.
		/// </param>
		/// <param name="async">
		/// Defines an asynchronous structure. The asynchronous structure contains an optional user context and a mandatory callback
		/// function. See the WSMAN_SHELL_ASYNC structure for more information. This parameter cannot be <c>NULL</c> and should be closed by
		/// calling the WSManCloseCommand method.
		/// </param>
		/// <param name="command">
		/// Defines the command object associated with a command within a shell. This handle is returned on a successful call and is used to
		/// send and receive data and to signal the command. This handle should be closed by calling the WSManCloseCommand method. This
		/// parameter cannot be <c>NULL</c>.
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/nf-wsman-wsmanrunshellcommandex void WSManRunShellCommandEx(
		// WSMAN_SHELL_HANDLE shell, DWORD flags, PCWSTR commandId, PCWSTR commandLine, WSMAN_COMMAND_ARG_SET *args, WSMAN_OPTION_SET
		// *options, WSMAN_SHELL_ASYNC *async, WSMAN_COMMAND_HANDLE *command );
		[DllImport(Lib_WsmSvc, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wsman.h", MSDNShortId = "NF:wsman.WSManRunShellCommandEx")]
		public static extern void WSManRunShellCommandEx([In, Out] WSMAN_SHELL_HANDLE shell, [Optional] uint flags,
			[MarshalAs(UnmanagedType.LPWStr)] string commandId, [MarshalAs(UnmanagedType.LPWStr)] string commandLine,
			in WSMAN_COMMAND_ARG_SET args, in WSMAN_OPTION_SET options, in WSMAN_SHELL_ASYNC async, out WSMAN_COMMAND_HANDLE command);

		/// <summary>
		/// Provides the same functionality as the WSManRunShellCommand function, with the addition of a command ID option. If the server
		/// supports the protocol, it will create the command instance using the ID specified by the client. If a command with the specified
		/// ID already exists, the server will fail to create the command instance. This new functionality is only available when the client
		/// application passes the <c>WSMAN_FLAG_REQUESTED_API_VERSION_1_1</c> flag as part of the call to the WSManInitialize function.
		/// </summary>
		/// <param name="shell">Specifies the shell handle returned by the WSManCreateShell call. This parameter cannot be <c>NULL</c>.</param>
		/// <param name="flags">Reserved for future use. Must be 0.</param>
		/// <param name="commandId">The client specified command Id.</param>
		/// <param name="commandLine">
		/// Defines a required null-terminated string that represents the command to be executed. Typically, the command is specified
		/// without any arguments, which are specified separately. However, a user can specify the command line and all of the arguments by
		/// using this parameter. If arguments are specified for the commandLine parameter, the args parameter should be <c>NULL</c>.
		/// </param>
		/// <param name="args">
		/// A pointer to a WSMAN_COMMAND_ARG_SET structure that defines an array of argument values, which are passed to the command on
		/// creation. If no arguments are required, this parameter should be <c>NULL</c>.
		/// </param>
		/// <param name="options">
		/// Defines a set of options for the command. These options are passed to the service to modify or refine the command execution.
		/// This parameter can be <c>NULL</c>. For more information about the options, see WSMAN_OPTION_SET.
		/// </param>
		/// <param name="async">
		/// Defines an asynchronous structure. The asynchronous structure contains an optional user context and a mandatory callback
		/// function. See the WSMAN_SHELL_ASYNC structure for more information. This parameter cannot be <c>NULL</c> and should be closed by
		/// calling the WSManCloseCommand method.
		/// </param>
		/// <param name="command">
		/// Defines the command object associated with a command within a shell. This handle is returned on a successful call and is used to
		/// send and receive data and to signal the command. This handle should be closed by calling the WSManCloseCommand method. This
		/// parameter cannot be <c>NULL</c>.
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/nf-wsman-wsmanrunshellcommandex void WSManRunShellCommandEx(
		// WSMAN_SHELL_HANDLE shell, DWORD flags, PCWSTR commandId, PCWSTR commandLine, WSMAN_COMMAND_ARG_SET *args, WSMAN_OPTION_SET
		// *options, WSMAN_SHELL_ASYNC *async, WSMAN_COMMAND_HANDLE *command );
		[DllImport(Lib_WsmSvc, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wsman.h", MSDNShortId = "NF:wsman.WSManRunShellCommandEx")]
		public static extern void WSManRunShellCommandEx([In, Out] WSMAN_SHELL_HANDLE shell, [Optional] uint flags,
			[MarshalAs(UnmanagedType.LPWStr)] string commandId, [MarshalAs(UnmanagedType.LPWStr)] string commandLine,
			[In, Optional] IntPtr args, [In, Optional] IntPtr options, in WSMAN_SHELL_ASYNC async, out WSMAN_COMMAND_HANDLE command);

		/// <summary>Pipes the input stream to a running command or to the shell.</summary>
		/// <param name="shell">Specifies the shell handle returned by a WSManCreateShell call. This parameter cannot be <c>NULL</c>.</param>
		/// <param name="command">
		/// Specifies the command handle returned by a WSManRunShellCommand call. This handle should be closed by calling the
		/// WSManCloseCommand method.
		/// </param>
		/// <param name="flags">Reserved for future use. Must be set to zero.</param>
		/// <param name="streamId">Specifies the input stream ID. This parameter cannot be <c>NULL</c>.</param>
		/// <param name="streamData">
		/// Uses the WSMAN_DATA structure to specify the stream data to be sent to the command or shell. This structure should be allocated
		/// by the calling client and must remain allocated until <c>WSManSendShellInput</c> completes. If the end of the stream has been
		/// reached, the endOfStream parameter should be set to <c>TRUE</c>.
		/// </param>
		/// <param name="endOfStream">
		/// Set to <c>TRUE</c>, if the end of the stream has been reached. Otherwise, this parameter is set to <c>FALSE</c>.
		/// </param>
		/// <param name="async">
		/// Defines an asynchronous structure. The asynchronous structure contains an optional user context and a mandatory callback
		/// function. See the WSMAN_SHELL_ASYNC structure for more information. This parameter cannot be <c>NULL</c> and should be closed by
		/// calling the WSManCloseCommand method.
		/// </param>
		/// <param name="sendOperation">
		/// Defines the operation handle for the send operation. This handle is returned from a successful call of the function and can be
		/// used to asynchronously cancel the send operation. This handle should be closed by calling the WSManCloseOperation method. This
		/// parameter cannot be <c>NULL</c>.
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/nf-wsman-wsmansendshellinput void WSManSendShellInput(
		// WSMAN_SHELL_HANDLE shell, WSMAN_COMMAND_HANDLE command, DWORD flags, PCWSTR streamId, WSMAN_DATA *streamData, BOOL endOfStream,
		// WSMAN_SHELL_ASYNC *async, WSMAN_OPERATION_HANDLE *sendOperation );
		[DllImport(Lib_WsmSvc, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wsman.h", MSDNShortId = "NF:wsman.WSManSendShellInput")]
		public static extern void WSManSendShellInput(WSMAN_SHELL_HANDLE shell, [In, Optional] WSMAN_COMMAND_HANDLE command, [In, Optional] uint flags,
			[MarshalAs(UnmanagedType.LPWStr)] string streamId, in WSMAN_DATA streamData, [MarshalAs(UnmanagedType.Bool)] bool endOfStream,
			in WSMAN_SHELL_ASYNC async, out SafeWSMAN_OPERATION_HANDLE sendOperation);

		/// <summary>Sets an extended set of options for the session.</summary>
		/// <param name="session">Specifies the session handle returned by a WSManCreateSession call. This parameter cannot be <c>NULL</c>.</param>
		/// <param name="option">
		/// Specifies the option to be set. This parameter must be set to one of the values in the WSManSessionOption enumeration.
		/// </param>
		/// <param name="data">A pointer to a WSMAN_DATA structure that defines the option value.</param>
		/// <returns>This method returns zero on success. Otherwise, this method returns an error code.</returns>
		/// <remarks>
		/// <para>
		/// If the <c>WSManSetSessionOption</c> method is called with different values specified for the option parameter, the order of the
		/// different options is important. The first time <c>WSManSetSessionOption</c> is called, the transport is set for the session. If
		/// a second call requests a different type of transport, the call will fail.
		/// </para>
		/// <para>For example, the second method call will fail if the methods are called in the following order:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// <code>WSManSetSessionOption(WSMAN_OPTION_UNENCRYPTED_MESSAGES)</code>
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// <code>WSManSetSessionOption(WSMAN_OPTION_ALLOW_NEGOTIATE_IMPLICIT_CREDENTIALS)</code>
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// The first method call sets the transport to HTTP because the option parameter is set to
		/// <c>WSMAN_OPTION_UNENCRYPTED_MESSAGES</c>. The second call fails because the option that was passed is applicable for HTTPS and
		/// the transport was set to HTTP by the first message.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/nf-wsman-wsmansetsessionoption DWORD WSManSetSessionOption(
		// WSMAN_SESSION_HANDLE session, WSManSessionOption option, WSMAN_DATA *data );
		[DllImport(Lib_WsmSvc, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wsman.h", MSDNShortId = "NF:wsman.WSManSetSessionOption")]
		public static extern Win32Error WSManSetSessionOption(WSMAN_SESSION_HANDLE session, WSManSessionOption option, in WSMAN_DATA data);

		/// <summary>Sends a control code to an existing command or to the shell itself.</summary>
		/// <param name="shell">Specifies the handle returned by a WSManCreateShell call. This parameter cannot be <c>NULL</c>.</param>
		/// <param name="command">
		/// Specifies the command handle returned by a WSManRunShellCommand call. If this value is <c>NULL</c>, the signal code is sent to
		/// the shell.
		/// </param>
		/// <param name="flags">Reserved for future use. Must be set to zero.</param>
		/// <param name="code">
		/// <para>Specifies the signal code to send to the command or shell. The following codes are common.</para>
		/// <para>WSMAN_SIGNAL_SHELL_CODE_TERMINATE</para>
		/// <para>The shell or Command Prompt window was closed.</para>
		/// <para>WSMAN_SIGNAL_SHELL_CODE_CTRL_C</para>
		/// <para>The signal for CTRL+C was received, and the process was halted.</para>
		/// <para>WSMAN_SIGNAL_SHELL_CODE_CTRL_BREAK</para>
		/// <para>The signal for CTRL+BREAK was received, and the process was halted.</para>
		/// </param>
		/// <param name="async">
		/// Defines an asynchronous structure. The asynchronous structure contains an optional user context and a mandatory callback
		/// function. See the WSMAN_SHELL_ASYNC structure for more information. This parameter cannot be <c>NULL</c> and should be closed by
		/// calling the WSManCloseOperation method.
		/// </param>
		/// <param name="signalOperation">
		/// Defines the operation handle for the signal operation. This handle is returned from a successful call of the function and can be
		/// used to asynchronously cancel the signal operation. This handle should be closed by calling the WSManCloseOperation method. This
		/// parameter cannot be <c>NULL</c>.
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/nf-wsman-wsmansignalshell void WSManSignalShell( WSMAN_SHELL_HANDLE
		// shell, WSMAN_COMMAND_HANDLE command, DWORD flags, PCWSTR code, WSMAN_SHELL_ASYNC *async, WSMAN_OPERATION_HANDLE *signalOperation );
		[DllImport(Lib_WsmSvc, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wsman.h", MSDNShortId = "NF:wsman.WSManSignalShell")]
		public static extern void WSManSignalShell(WSMAN_SHELL_HANDLE shell, [In, Optional] WSMAN_COMMAND_HANDLE command,
			[Optional] uint flags, [MarshalAs(UnmanagedType.LPWStr)] string code, in WSMAN_SHELL_ASYNC async, out WSMAN_OPERATION_HANDLE signalOperation);

		/// <summary>Provides a handle to a Windows Remote Client unique identifier.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct WSMAN_API_HANDLE : IHandle
		{
			private readonly IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="WSMAN_API_HANDLE"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public WSMAN_API_HANDLE(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="WSMAN_API_HANDLE"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static WSMAN_API_HANDLE NULL => new WSMAN_API_HANDLE(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="WSMAN_API_HANDLE"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(WSMAN_API_HANDLE h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="WSMAN_API_HANDLE"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator WSMAN_API_HANDLE(IntPtr h) => new WSMAN_API_HANDLE(h);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(WSMAN_API_HANDLE h1, WSMAN_API_HANDLE h2) => !(h1 == h2);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(WSMAN_API_HANDLE h1, WSMAN_API_HANDLE h2) => h1.Equals(h2);

			/// <inheritdoc/>
			public override bool Equals(object obj) => obj is WSMAN_API_HANDLE h && handle == h.handle;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
		}

		/// <summary>Defines the authentication method and the credentials used for server or proxy authentication.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/ns-wsman-wsman_authentication_credentials typedef struct
		// _WSMAN_AUTHENTICATION_CREDENTIALS { DWORD authenticationMechanism; union { WSMAN_USERNAME_PASSWORD_CREDS userAccount; PCWSTR
		// certificateThumbprint; }; } WSMAN_AUTHENTICATION_CREDENTIALS;
		[PInvokeData("wsman.h", MSDNShortId = "NS:wsman._WSMAN_AUTHENTICATION_CREDENTIALS")]
		[StructLayout(LayoutKind.Sequential)]
		public struct WSMAN_AUTHENTICATION_CREDENTIALS
		{
			/// <summary>
			/// Defines the authentication mechanism. This member can be set to zero. If it is set to zero, the WinRM client will choose
			/// between Kerberos and Negotiate. If it is not set to zero, this member must be one of the values of the
			/// WSManAuthenticationFlags enumeration.
			/// </summary>
			public WSManAuthenticationFlags authenticationMechanism;

			/// <summary>Defines the credentials used for authentication. See WSMAN_USERNAME_PASSWORD_CREDS for more information.</summary>
			public WSMAN_USERNAME_PASSWORD_CREDS userAccount;

			/// <summary>Defines the certificate thumbprint.</summary>
			public string certificateThumbprint { get => userAccount.username; set => userAccount.username = value; }
		}

		/// <summary>Reports quota information on a per-user basis for authorization plug-ins.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/ns-wsman-wsman_authz_quota typedef struct _WSMAN_AUTHZ_QUOTA { DWORD
		// maxAllowedConcurrentShells; DWORD maxAllowedConcurrentOperations; DWORD timeslotSize; DWORD maxAllowedOperationsPerTimeslot; } WSMAN_AUTHZ_QUOTA;
		[PInvokeData("wsman.h", MSDNShortId = "NS:wsman._WSMAN_AUTHZ_QUOTA")]
		[StructLayout(LayoutKind.Sequential)]
		public struct WSMAN_AUTHZ_QUOTA
		{
			/// <summary>Specifies the maximum number of concurrent shells that a user is allowed to create.</summary>
			public uint maxAllowedConcurrentShells;

			/// <summary>
			/// Specifies the maximum number of concurrent operations that a user is allowed to perform. Only top-level operations are
			/// counted. Simple operations such as get, put, and delete are counted as one operation each. More complex operations are also
			/// counted as one. For example, the enumeration operation and any associated operations that are related to enumeration are
			/// counted as one operation.
			/// </summary>
			public uint maxAllowedConcurrentOperations;

			/// <summary>
			/// Time-slot length for determining the maximum number of operations per time slot. This value is specified in units of seconds.
			/// </summary>
			public uint timeslotSize;

			/// <summary>
			/// Specifies the maximum number of operations allowed per time slot. This value is used to throttle both top-level and
			/// follow-on operations.
			/// </summary>
			public uint maxAllowedOperationsPerTimeslot;
		}

		/// <summary>
		/// Stores client information for an inbound request that was sent with a client certificate. The individual fields represent the
		/// fields within the client certificate.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/ns-wsman-wsman_certificate_details typedef struct
		// _WSMAN_CERTIFICATE_DETAILS { PCWSTR subject; PCWSTR issuerName; PCWSTR issuerThumbprint; PCWSTR subjectName; } WSMAN_CERTIFICATE_DETAILS;
		[PInvokeData("wsman.h", MSDNShortId = "NS:wsman._WSMAN_CERTIFICATE_DETAILS")]
		[StructLayout(LayoutKind.Sequential)]
		public struct WSMAN_CERTIFICATE_DETAILS
		{
			/// <summary>Specifies the subject that is identified by the certificate.</summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string subject;

			/// <summary>Specifies the name of the issuer of the certificate.</summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string issuerName;

			/// <summary>Specifies the thumbprint of the issuer.</summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string issuerThumbprint;

			/// <summary>Specifies the subject name of the issuer.</summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string subjectName;
		}

		/// <summary>Represents the set of arguments that are passed in to the command line.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/ns-wsman-wsman_command_arg_set typedef struct _WSMAN_COMMAND_ARG_SET {
		// DWORD argsCount; PCWSTR *args; } WSMAN_COMMAND_ARG_SET;
		[PInvokeData("wsman.h", MSDNShortId = "NS:wsman._WSMAN_COMMAND_ARG_SET")]
		[StructLayout(LayoutKind.Sequential)]
		public struct WSMAN_COMMAND_ARG_SET
		{
			/// <summary>Specifies the number of arguments in the array.</summary>
			public uint argsCount;

			/// <summary>Defines an array of strings that specify the arguments.</summary>
			public IntPtr args;
		}

		/// <summary>Provides a handle to a remote management command.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct WSMAN_COMMAND_HANDLE : IHandle
		{
			private readonly IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="WSMAN_COMMAND_HANDLE"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public WSMAN_COMMAND_HANDLE(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="WSMAN_COMMAND_HANDLE"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static WSMAN_COMMAND_HANDLE NULL => new WSMAN_COMMAND_HANDLE(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="WSMAN_COMMAND_HANDLE"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(WSMAN_COMMAND_HANDLE h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="WSMAN_COMMAND_HANDLE"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator WSMAN_COMMAND_HANDLE(IntPtr h) => new WSMAN_COMMAND_HANDLE(h);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(WSMAN_COMMAND_HANDLE h1, WSMAN_COMMAND_HANDLE h2) => !(h1 == h2);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(WSMAN_COMMAND_HANDLE h1, WSMAN_COMMAND_HANDLE h2) => h1.Equals(h2);

			/// <inheritdoc/>
			public override bool Equals(object obj) => obj is WSMAN_COMMAND_HANDLE h && handle == h.handle;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
		}

		/// <summary>Contains inbound and outbound data used in the Windows Remote Management (WinRM) API.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/ns-wsman-wsman_data typedef struct _WSMAN_DATA { WSManDataType type;
		// union { WSMAN_DATA_TEXT text; WSMAN_DATA_BINARY binaryData; DWORD number; }; } WSMAN_DATA;
		[PInvokeData("wsman.h", MSDNShortId = "NS:wsman._WSMAN_DATA")]
		[StructLayout(LayoutKind.Sequential)]
		public struct WSMAN_DATA
		{
			/// <summary>Specifies the type of data currently stored in the union.</summary>
			public WSManDataType type;

			/// <summary/>
			public WSMAN_DATA_UNION union;

			/// <summary/>
			[StructLayout(LayoutKind.Explicit)]
			public struct WSMAN_DATA_UNION
			{
				/// <summary/>
				[FieldOffset(0)]
				public WSMAN_DATA_TEXT text;

				/// <summary/>
				[FieldOffset(0)]
				public WSMAN_DATA_BINARY binaryData;

				/// <summary/>
				[FieldOffset(0)]
				public uint number;
			}
		}

		/// <summary>A WSMAN_DATA structure component that holds binary data for use with various Windows Remote Management functions.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/ns-wsman-wsman_data_binary typedef struct _WSMAN_DATA_BINARY { DWORD
		// dataLength; BYTE *data; } WSMAN_DATA_BINARY;
		[PInvokeData("wsman.h", MSDNShortId = "NS:wsman._WSMAN_DATA_BINARY")]
		[StructLayout(LayoutKind.Sequential)]
		public struct WSMAN_DATA_BINARY
		{
			/// <summary>Represents the number of BYTEs stored in the data field.</summary>
			public uint dataLength;

			/// <summary>Specifies the storage location for the binary data.</summary>
			public IntPtr data;
		}

		/// <summary>A WSMAN_DATA structure component that holds textual data for use with various Windows Remote Management functions.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/ns-wsman-wsman_data_text typedef struct _WSMAN_DATA_TEXT { DWORD
		// bufferLength; PCWSTR buffer; } WSMAN_DATA_TEXT;
		[PInvokeData("wsman.h", MSDNShortId = "NS:wsman._WSMAN_DATA_TEXT")]
		[StructLayout(LayoutKind.Sequential)]
		public struct WSMAN_DATA_TEXT
		{
			/// <summary>Specifies the number of UNICODE characters stored in the buffer.</summary>
			public uint bufferLength;

			/// <summary>Specifies the storage location for the textual data.</summary>
			public StrPtrUni buffer;
		}

		/// <summary>
		/// Defines an individual environment variable by using a name and value pair. This structure is used by the WSManCreateShell
		/// method. The representation of the <c>value</c> variable is shell specific. The client and server must agree on the format of the
		/// <c>value</c> variable.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/ns-wsman-wsman_environment_variable typedef struct
		// _WSMAN_ENVIRONMENT_VARIABLE { PCWSTR name; PCWSTR value; } WSMAN_ENVIRONMENT_VARIABLE;
		[PInvokeData("wsman.h", MSDNShortId = "NS:wsman._WSMAN_ENVIRONMENT_VARIABLE")]
		[StructLayout(LayoutKind.Sequential)]
		public struct WSMAN_ENVIRONMENT_VARIABLE
		{
			/// <summary>Defines the environment variable name. This parameter cannot be <c>NULL</c>.</summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string name;

			/// <summary>Defines the environment variable value. <c>NULL</c> or empty string values are permitted.</summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string value;
		}

		/// <summary>Defines an array of environment variables.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/ns-wsman-wsman_environment_variable_set typedef struct
		// _WSMAN_ENVIRONMENT_VARIABLE_SET { DWORD varsCount; WSMAN_ENVIRONMENT_VARIABLE *vars; } WSMAN_ENVIRONMENT_VARIABLE_SET;
		[PInvokeData("wsman.h", MSDNShortId = "NS:wsman._WSMAN_ENVIRONMENT_VARIABLE_SET")]
		[StructLayout(LayoutKind.Sequential)]
		public struct WSMAN_ENVIRONMENT_VARIABLE_SET
		{
			/// <summary>Specifies the number of environment variables contained within the <c>vars</c> array.</summary>
			public uint varsCount;

			/// <summary>Defines an array of environment variables. Each element of the array is of type WSMAN_ENVIRONMENT_VARIABLE.</summary>
			public IntPtr vars;
		}

		/// <summary>
		/// Contains error information that is returned by a Windows Remote Management (WinRM) client. The WSMAN_ERROR structure is used by
		/// all callbacks to return error information and is valid only for the callback.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/ns-wsman-wsman_error typedef struct _WSMAN_ERROR { DWORD code; PCWSTR
		// errorDetail; PCWSTR language; PCWSTR machineName; PCWSTR pluginName; } WSMAN_ERROR;
		[PInvokeData("wsman.h", MSDNShortId = "NS:wsman._WSMAN_ERROR")]
		[StructLayout(LayoutKind.Sequential)]
		public struct WSMAN_ERROR
		{
			/// <summary>
			/// Specifies an error code. This error can be a general error code that is defined in winerror.h or a WinRM-specific error code.
			/// </summary>
			public uint code;

			/// <summary>
			/// Specifies extended error information that relates to a failed call. This field contains the fault detail text if it is
			/// present in the fault. If there is no fault detail, this field contains the fault reason text. This field can be set to <c>NULL</c>.
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string errorDetail;

			/// <summary>
			/// Specifies the language for the error description. This field can be set to <c>NULL</c>. For more information about the
			/// language format, see the RFC 3066 specification from the Internet Engineering Task Force at http://www.ietf.org/rfc/rfc3066.txt.
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string language;

			/// <summary>Specifies the name of the computer. This field can be set to <c>NULL</c>.</summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string machineName;

			/// <summary>Specifies the name of the plug-in that generated the error. This field can be set to <c>NULL</c>.</summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string pluginName;
		}

		/// <summary>
		/// <para>[ <c>WSMAN_FILTER</c> is reserved for future use.]</para>
		/// <para>Defines the filtering that is used for an operation.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/ns-wsman-wsman_filter typedef struct _WSMAN_FILTER { PCWSTR filter;
		// PCWSTR dialect; } WSMAN_FILTER;
		[PInvokeData("wsman.h", MSDNShortId = "NS:wsman._WSMAN_FILTER")]
		[StructLayout(LayoutKind.Sequential)]
		public struct WSMAN_FILTER
		{
			/// <summary>Reserved for future use. This parameter must be <c>NULL</c>.</summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string filter;

			/// <summary>Reserved for future use. This parameter must be <c>NULL</c>.</summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string dialect;
		}

		/// <summary>
		/// <para>[ <c>WSMAN_FRAGMENT</c> is reserved for future use.]</para>
		/// <para>Defines the fragment information for an operation. Currently, this structure is reserved for future use.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/ns-wsman-wsman_fragment typedef struct _WSMAN_FRAGMENT { PCWSTR path;
		// PCWSTR dialect; } WSMAN_FRAGMENT;
		[PInvokeData("wsman.h", MSDNShortId = "NS:wsman._WSMAN_FRAGMENT")]
		[StructLayout(LayoutKind.Sequential)]
		public struct WSMAN_FRAGMENT
		{
			/// <summary>Reserved for future use. This parameter must be <c>NULL</c>.</summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string path;

			/// <summary>Reserved for future use. This parameter must be <c>NULL</c>.</summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string dialect;
		}

		/// <summary>Represents a key and value pair within a selector set and is used to identify a particular resource.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/ns-wsman-wsman_key typedef struct _WSMAN_KEY { PCWSTR key; PCWSTR value;
		// } WSMAN_KEY;
		[PInvokeData("wsman.h", MSDNShortId = "NS:wsman._WSMAN_KEY")]
		[StructLayout(LayoutKind.Sequential)]
		public struct WSMAN_KEY
		{
			/// <summary>Specifies the key name.</summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string key;

			/// <summary>Defines the value associated with key.</summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string value;
		}

		/// <summary>Provides a handle to a remote management operation.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct WSMAN_OPERATION_HANDLE : IHandle
		{
			private readonly IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="WSMAN_OPERATION_HANDLE"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public WSMAN_OPERATION_HANDLE(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="WSMAN_OPERATION_HANDLE"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static WSMAN_OPERATION_HANDLE NULL => new WSMAN_OPERATION_HANDLE(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="WSMAN_OPERATION_HANDLE"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(WSMAN_OPERATION_HANDLE h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="WSMAN_OPERATION_HANDLE"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator WSMAN_OPERATION_HANDLE(IntPtr h) => new WSMAN_OPERATION_HANDLE(h);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(WSMAN_OPERATION_HANDLE h1, WSMAN_OPERATION_HANDLE h2) => !(h1 == h2);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(WSMAN_OPERATION_HANDLE h1, WSMAN_OPERATION_HANDLE h2) => h1.Equals(h2);

			/// <inheritdoc/>
			public override bool Equals(object obj) => obj is WSMAN_OPERATION_HANDLE h && handle == h.handle;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
		}

		/// <summary>Represents a specific resource endpoint for which the plug-in must perform the request.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/ns-wsman-wsman_operation_info typedef struct _WSMAN_OPERATION_INFO {
		// WSMAN_FRAGMENT fragment; WSMAN_FILTER filter; WSMAN_SELECTOR_SET selectorSet; WSMAN_OPTION_SET optionSet; void *reserved; DWORD
		// version; } WSMAN_OPERATION_INFO;
		[PInvokeData("wsman.h", MSDNShortId = "NS:wsman._WSMAN_OPERATION_INFO")]
		[StructLayout(LayoutKind.Sequential)]
		public struct WSMAN_OPERATION_INFO
		{
			/// <summary>
			/// A WSMAN_FRAGMENT structure that specifies the subset of data to be used for the operation. This parameter is reserved for
			/// future use and is ignored on receipt.
			/// </summary>
			public WSMAN_FRAGMENT fragment;

			/// <summary>
			/// A WSMAN_FILTER structure that specifies the filtering that is used for the operation. This parameter is reserved for future
			/// use and is ignored on receipt.
			/// </summary>
			public WSMAN_FILTER filter;

			/// <summary>A WSMAN_SELECTOR_SET structure that identifies the specific resource to use for the request.</summary>
			public WSMAN_SELECTOR_SET selectorSet;

			/// <summary>A WSMAN_OPTION_SET structure that specifies the set of options for the request.</summary>
			public WSMAN_OPTION_SET optionSet;

			/// <summary/>
			public IntPtr reserved;

			/// <summary/>
			public uint version;
		}

		/// <summary>
		/// Represents a specific option name and value pair. An option that is not understood and has a <c>mustComply</c> value of
		/// <c>TRUE</c> should result in the plug-in operation failing the request with an error.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/ns-wsman-wsman_option typedef struct _WSMAN_OPTION { PCWSTR name; PCWSTR
		// value; BOOL mustComply; } WSMAN_OPTION;
		[PInvokeData("wsman.h", MSDNShortId = "NS:wsman._WSMAN_OPTION")]
		[StructLayout(LayoutKind.Sequential)]
		public struct WSMAN_OPTION
		{
			/// <summary>Specifies the name of the option.</summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string name;

			/// <summary>Specifies the value of the option.</summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string value;

			/// <summary>
			/// Specifies whether the option must be understood and complied with. If this value is <c>TRUE</c>, the plug-in must understand
			/// and adhere to the meaning of the option; otherwise, the plug-in must return an error. If this is <c>FALSE</c>, the plug-in
			/// should ignore the option if it is not understood.
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool mustComply;
		}

		/// <summary>
		/// Represents a set of options. Additionally, this structure defines a flag that specifies whether all options must be understood.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/ns-wsman-wsman_option_set typedef struct _WSMAN_OPTION_SET { DWORD
		// optionsCount; WSMAN_OPTION *options; BOOL optionsMustUnderstand; } WSMAN_OPTION_SET;
		[PInvokeData("wsman.h", MSDNShortId = "NS:wsman._WSMAN_OPTION_SET")]
		[StructLayout(LayoutKind.Sequential)]
		public struct WSMAN_OPTION_SET
		{
			/// <summary>Specifies the number of options in the <c>options</c> array.</summary>
			public uint optionsCount;

			/// <summary>Specifies an array of option names and values</summary>
			public IntPtr options;

			/// <summary>If this member is <c>TRUE</c>, the plug-in must return an error if any of the options are not understood.</summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool optionsMustUnderstand;
		}

		/// <summary>
		/// Specifies information for a plug-in request. A pointer to a <c>WSMAN_PLUGIN_REQUEST</c> structure is passed to all operation
		/// entry points within the plug-in. All result notification methods use this pointer to match the result with the request. All
		/// information in the structure will stay valid until the plug-in calls WSManPluginOperationCompleteon the operation.
		/// </summary>
		/// <remarks>
		/// Operations must signal the callback for the operation to indicate it has been shut down. Operations are canceled in a
		/// hierarchical way to ensure that all follow-on operations are canceled before the top-level operations. A plug-in has two ways of
		/// handling the cancellation of an operation. First, the plug-in can check the <c>shutdownNotification</c> Boolean value if it
		/// iterates through a set of results. Second, if the plug-in is more asynchronous in nature, the <c>shutdownNotificationHandle</c>
		/// can be used when queuing asynchronous notification threads.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/ns-wsman-wsman_plugin_request typedef struct _WSMAN_PLUGIN_REQUEST {
		// WSMAN_SENDER_DETAILS *senderDetails; PCWSTR locale; PCWSTR resourceUri; WSMAN_OPERATION_INFO *operationInfo; BOOL
		// shutdownNotification; HANDLE shutdownNotificationHandle; PCWSTR dataLocale; } WSMAN_PLUGIN_REQUEST;
		[PInvokeData("wsman.h", MSDNShortId = "NS:wsman._WSMAN_PLUGIN_REQUEST")]
		[StructLayout(LayoutKind.Sequential)]
		public struct WSMAN_PLUGIN_REQUEST
		{
			/// <summary>
			/// A pointer to a <see cref="WSMAN_SENDER_DETAILS"/> structure that specifies details about the client that initiated the request.
			/// </summary>
			public IntPtr senderDetails;

			/// <summary>
			/// <para>
			/// Specifies the locale that the user requested results to be in. If the requested locale is not available, the following
			/// options are available:
			/// </para>
			/// <list type="bullet">
			/// <item>
			/// <term>The system locale is used.</term>
			/// </item>
			/// <item>
			/// <term>The request is rejected with an invalid locale error.</term>
			/// </item>
			/// </list>
			/// <para>
			/// Any call into the plug-in will have the locale on the thread set to the locale that is specified in this member. If the
			/// plug-in has other threads working on the request, the plug-in will need to set the locale accordingly on each thread that it uses.
			/// </para>
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string locale;

			/// <summary>Specifies the resource URI for this operation.</summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string resourceUri;

			/// <summary>
			/// A pointer to a <see cref="WSMAN_OPERATION_INFO"/> structure that contains extra information about the operation. Some of the
			/// information in this structure will be <c>NULL</c> because not all of the parameters are relevant to all operations.
			/// </summary>
			public IntPtr operationInfo;

			/// <summary>If the operation is canceled, the <c>shutdownNotification</c> member is set to <c>TRUE</c>.</summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool shutdownNotification;

			/// <summary>If the operation is canceled, <c>shutdownNotification</c> is signaled.</summary>
			public HEVENT shutdownNotificationHandle;

			/// <summary/>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string dataLocale;
		}

		/// <summary>Specifies proxy information.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/ns-wsman-wsman_proxy_info typedef struct _WSMAN_PROXY_INFO { DWORD
		// accessType; WSMAN_AUTHENTICATION_CREDENTIALS authenticationCredentials; } WSMAN_PROXY_INFO;
		[PInvokeData("wsman.h", MSDNShortId = "NS:wsman._WSMAN_PROXY_INFO")]
		[StructLayout(LayoutKind.Sequential)]
		public struct WSMAN_PROXY_INFO
		{
			/// <summary>
			/// Specifies the access type for the proxy. This member must be set to one of the values defined in the WSManProxyAccessType enumeration.
			/// </summary>
			public WSManProxyAccessType accessType;

			/// <summary>
			/// A WSMAN_AUTHENTICATION_CREDENTIALS structure that specifies the credentials and authentication scheme used for proxy access.
			/// </summary>
			public WSMAN_AUTHENTICATION_CREDENTIALS authenticationCredentials;
		}

		/// <summary>Represents the output data received from a WSManReceiveShellOutput method.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/ns-wsman-wsman_receive_data_result typedef struct
		// _WSMAN_RECEIVE_DATA_RESULT { PCWSTR streamId; WSMAN_DATA streamData; PCWSTR commandState; DWORD exitCode; } WSMAN_RECEIVE_DATA_RESULT;
		[PInvokeData("wsman.h", MSDNShortId = "NS:wsman._WSMAN_RECEIVE_DATA_RESULT")]
		[StructLayout(LayoutKind.Sequential)]
		public struct WSMAN_RECEIVE_DATA_RESULT
		{
			/// <summary>Represents the <c>streamId</c> for which <c>streamData</c> is defined.</summary>
			public StrPtrUni streamId;

			/// <summary>
			/// Represents the data associated with <c>streamId</c>. The data can be stream text, binary content, or XML. For more
			/// information about the possible data, see WSMAN_DATA.
			/// </summary>
			public WSMAN_DATA streamData;

			/// <summary>
			/// Specifies the status of the command. If this member is set to <c>WSMAN_COMMAND_STATE_DONE</c>, the command should be
			/// immediately closed.
			/// </summary>
			public StrPtrUni commandState;

			/// <summary>
			/// Defines the exit code of the command. This value is relevant only if the <c>commandState</c> member is set to <c>WSMAN_COMMAND_STATE_DONE</c>.
			/// </summary>
			public uint exitCode;
		}

		/// <summary>Represents the output data received from a WSMan operation.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/ns-wsman-wsman_response_data typedef union _WSMAN_RESPONSE_DATA {
		// WSMAN_RECEIVE_DATA_RESULT receiveData; WSMAN_CONNECT_DATA connectData; WSMAN_CREATE_SHELL_DATA createData; } WSMAN_RESPONSE_DATA;
		[PInvokeData("wsman.h", MSDNShortId = "NS:wsman._WSMAN_RESPONSE_DATA")]
		[StructLayout(LayoutKind.Explicit)]
		public struct WSMAN_RESPONSE_DATA
		{
			/// <summary>Represents the output data received from a WSManReceiveShellOutput method.</summary>
			[FieldOffset(0)]
			public WSMAN_RECEIVE_DATA_RESULT receiveData;

			/// <summary>Represents the output data received from a WSManConnectShell or WSManConnectShellCommand method.</summary>
			[FieldOffset(0)]
			public WSMAN_DATA connectData;

			/// <summary/>
			[FieldOffset(0)]
			public WSMAN_DATA createData;
		}

		/// <summary>Defines a set of keys that represent the identity of a resource.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/ns-wsman-wsman_selector_set typedef struct _WSMAN_SELECTOR_SET { DWORD
		// numberKeys; WSMAN_KEY *keys; } WSMAN_SELECTOR_SET;
		[PInvokeData("wsman.h", MSDNShortId = "NS:wsman._WSMAN_SELECTOR_SET")]
		[StructLayout(LayoutKind.Sequential)]
		public struct WSMAN_SELECTOR_SET
		{
			/// <summary>Specifies the number of keys (selectors).</summary>
			public uint numberKeys;

			/// <summary>An array of WSMAN_KEY structures that specify key names and values.</summary>
			public IntPtr keys;
		}

		/// <summary>Specifies the client details for every inbound request.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/ns-wsman-wsman_sender_details typedef struct _WSMAN_SENDER_DETAILS {
		// PCWSTR senderName; PCWSTR authenticationMechanism; WSMAN_CERTIFICATE_DETAILS *certificateDetails; HANDLE clientToken; PCWSTR
		// httpURL; } WSMAN_SENDER_DETAILS;
		[PInvokeData("wsman.h", MSDNShortId = "NS:wsman._WSMAN_SENDER_DETAILS")]
		[StructLayout(LayoutKind.Sequential)]
		public struct WSMAN_SENDER_DETAILS
		{
			/// <summary>
			/// <para>
			/// Specifies the user name of the client making the request. The content of this parameter varies depending on the type of
			/// authentication. The value of the senderName is formatted as follows:
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Authentication mechanism</term>
			/// <term>Value of senderName</term>
			/// </listheader>
			/// <item>
			/// <term>Windows Authentication</term>
			/// <term>The domain and user name.</term>
			/// </item>
			/// <item>
			/// <term>Basic Authentication</term>
			/// <term>The user name specified.</term>
			/// </item>
			/// <item>
			/// <term>Client Certificates</term>
			/// <term>The subject of the certificate.</term>
			/// </item>
			/// <item>
			/// <term>LiveID</term>
			/// <term>The LiveID PUID as a string.</term>
			/// </item>
			/// </list>
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string senderName;

			/// <summary>
			/// <para>
			/// Specifies a string that indicates which authentication mechanism was used by the client. The following values are predefined:
			/// </para>
			/// <list type="bullet">
			/// <item>
			/// <term>Basic</term>
			/// </item>
			/// <item>
			/// <term>ClientCertificate</term>
			/// </item>
			/// </list>
			/// <para>
			/// All other types are queried directly from the security package. For Internet Information Services (IIS) hosting, this string
			/// is retrieved from the IIS infrastructure.
			/// </para>
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string authenticationMechanism;

			/// <summary>
			/// A pointer to a <see cref="WSMAN_CERTIFICATE_DETAILS"/> structure that specifies the details of the client's certificate.
			/// This parameter is valid only if the authenticationMechanismis set to ClientCertificate.
			/// </summary>
			public IntPtr certificateDetails;

			/// <summary>
			/// <para>
			/// Specifies the identity token of the user if a Windows security token is available for a user. This token will be used by the
			/// thread to impersonate this user for all calls into the plug-in.
			/// </para>
			/// <para><c>Note</c> Authorization plug-ins can change the user context and use a different impersonation token.</para>
			/// </summary>
			public HTOKEN clientToken;

			/// <summary>Specifies the HTTP URL of the inbound request.</summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string httpURL;
		}

		/// <summary>Provides a handle to a remote managment session.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct WSMAN_SESSION_HANDLE : IHandle
		{
			private readonly IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="WSMAN_SESSION_HANDLE"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public WSMAN_SESSION_HANDLE(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="WSMAN_SESSION_HANDLE"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static WSMAN_SESSION_HANDLE NULL => new WSMAN_SESSION_HANDLE(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="WSMAN_SESSION_HANDLE"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(WSMAN_SESSION_HANDLE h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="WSMAN_SESSION_HANDLE"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator WSMAN_SESSION_HANDLE(IntPtr h) => new WSMAN_SESSION_HANDLE(h);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(WSMAN_SESSION_HANDLE h1, WSMAN_SESSION_HANDLE h2) => !(h1 == h2);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(WSMAN_SESSION_HANDLE h1, WSMAN_SESSION_HANDLE h2) => h1.Equals(h2);

			/// <inheritdoc/>
			public override bool Equals(object obj) => obj is WSMAN_SESSION_HANDLE h && handle == h.handle;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
		}

		/// <summary>
		/// Defines an asynchronous structure to be passed to all shell operations. It contains an optional user context and the callback function.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/ns-wsman-wsman_shell_async typedef struct _WSMAN_SHELL_ASYNC { PVOID
		// operationContext; WSMAN_SHELL_COMPLETION_FUNCTION completionFunction; } WSMAN_SHELL_ASYNC;
		[PInvokeData("wsman.h", MSDNShortId = "NS:wsman._WSMAN_SHELL_ASYNC")]
		[StructLayout(LayoutKind.Sequential)]
		public struct WSMAN_SHELL_ASYNC
		{
			/// <summary>Specifies the optional user context associated with the operation.</summary>
			public IntPtr operationContext;

			/// <summary>Specifies the WSMAN_SHELL_COMPLETION_FUNCTION callback function for the operation.</summary>
			public WSMAN_SHELL_COMPLETION_FUNCTION completionFunction;
		}

		/// <summary>Specifies the maximum duration, in milliseconds, the shell will stay open after the client has disconnected.</summary>
		/// <remarks>
		/// When the maximum duration is exceeded, the shell is automatically deleted. This value overrides the initial idle timeout that is
		/// set as part of WSMAN_SHELL_STARTUP_INFO structure in WSManCreateShell.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/ns-wsman-wsman_shell_disconnect_info typedef struct
		// _WSMAN_SHELL_DISCONNECT_INFO { DWORD idleTimeoutMs; } WSMAN_SHELL_DISCONNECT_INFO;
		[PInvokeData("wsman.h", MSDNShortId = "NS:wsman._WSMAN_SHELL_DISCONNECT_INFO")]
		[StructLayout(LayoutKind.Sequential)]
		public struct WSMAN_SHELL_DISCONNECT_INFO
		{
			/// <summary>
			/// Specifies the maximum time in milliseconds that the shell will stay open after the client has disconnected. When this
			/// maximum duration has been exceeded, the shell will be deleted. Specifying this value overrides the initial idle timeout
			/// value that is set as part of the WSMAN_SHELL_STARTUP_INFO structure in the WSManCreateShell method.
			/// </summary>
			public uint idleTimeoutMs;
		}

		/// <summary>Provides a handle to a remote management shell.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct WSMAN_SHELL_HANDLE : IHandle
		{
			private readonly IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="WSMAN_SHELL_HANDLE"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public WSMAN_SHELL_HANDLE(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="WSMAN_SHELL_HANDLE"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static WSMAN_SHELL_HANDLE NULL => new WSMAN_SHELL_HANDLE(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="WSMAN_SHELL_HANDLE"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(WSMAN_SHELL_HANDLE h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="WSMAN_SHELL_HANDLE"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator WSMAN_SHELL_HANDLE(IntPtr h) => new WSMAN_SHELL_HANDLE(h);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(WSMAN_SHELL_HANDLE h1, WSMAN_SHELL_HANDLE h2) => !(h1 == h2);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(WSMAN_SHELL_HANDLE h1, WSMAN_SHELL_HANDLE h2) => h1.Equals(h2);

			/// <inheritdoc/>
			public override bool Equals(object obj) => obj is WSMAN_SHELL_HANDLE h && handle == h.handle;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
		}

		/// <summary>
		/// <para>
		/// Defines the shell startup parameters to be used with the WSManCreateShell function. The structure must be allocated by the
		/// client and passed to the <c>WSManCreateShell</c> function.
		/// </para>
		/// <para>
		/// The configuration passed to the WSManCreateShell function can directly affect the behavior of a command executed within the
		/// shell. A typical example is the workingDirectory argument that describes the working directory associated with each process,
		/// which the operating system uses when attempting to locate files specified by using a relative path.
		/// </para>
		/// <para>
		/// In the absence of specific requirements for stream naming, clients and services should attempt to use <c>STDIN</c> for input
		/// streams, <c>STDOUT</c> for the default output stream, and <c>STDERR</c> for the error or status output stream.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/ns-wsman-wsman_shell_startup_info_v10 typedef struct
		// _WSMAN_SHELL_STARTUP_INFO_V10 { WSMAN_STREAM_ID_SET *inputStreamSet; WSMAN_STREAM_ID_SET *outputStreamSet; DWORD idleTimeoutMs;
		// PCWSTR workingDirectory; WSMAN_ENVIRONMENT_VARIABLE_SET *variableSet; } WSMAN_SHELL_STARTUP_INFO_V10;
		[PInvokeData("wsman.h", MSDNShortId = "NS:wsman._WSMAN_SHELL_STARTUP_INFO_V10")]
		[StructLayout(LayoutKind.Sequential)]
		public struct WSMAN_SHELL_STARTUP_INFO_V10
		{
			/// <summary>
			/// A pointer to a WSMAN_STREAM_ID_SET structure that specifies a set of input streams for the shell. Streams not present in the
			/// filter can be ignored by the shell implementation. For the Windows Cmd.exe shell, this value should be L"stdin". If the
			/// value is <c>NULL</c>, the implementation uses an array with L"stdin" as the default value.
			/// </summary>
			public IntPtr inputStreamSet;

			/// <summary>
			/// A pointer to a WSMAN_STREAM_ID_SET structure that specifies a set of output streams for the shell. Streams not present in
			/// the filter can be ignored by the shell implementation. For the Windows cmd.exe shell, this value should be L"stdout stderr".
			/// If the value is <c>NULL</c>, the implementation uses an array with L"stdout" and L"stderr" as the default value.
			/// </summary>
			public IntPtr outputStreamSet;

			/// <summary>
			/// Specifies the maximum duration, in milliseconds, the shell will stay open without any client request. When the maximum
			/// duration is exceeded, the shell is automatically deleted. Any value from 0 to 0xFFFFFFFF can be set. This duration has a
			/// maximum value specified by the Idle time-out GPO setting, if enabled, or by the IdleTimeout local configuration. The default
			/// value of the maximum duration in the GPO/local configuration is 15 minutes. However, a system administrator can change this
			/// value. To use the maximum value from the GPO/local configuration, the client should specify 0 (zero) in this field. If an
			/// explicit value between 0 to 0xFFFFFFFF is used, the minimum value between the explicit API value and the value from the
			/// GPO/local configuration is used.
			/// </summary>
			public uint idleTimeoutMs;

			/// <summary>
			/// Specifies the starting directory for a shell. It is used with any execution command. If this member is a <c>NULL</c> value,
			/// a default directory will be used by the remote machine when executing the command. An empty value is treated by the
			/// underlying protocol as an omitted value.
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string workingDirectory;

			/// <summary>
			/// A pointer to a WSMAN_ENVIRONMENT_VARIABLE_SET structure that specifies an array of variable name and value pairs, which
			/// describe the starting environment for the shell. The content of these elements is shell specific and can be defined in terms
			/// of other environment variables. If a <c>NULL</c> value is passed, the default environment is used on the server side.
			/// </summary>
			public IntPtr variableSet;
		}

		/// <summary>
		/// <para>
		/// Defines the shell startup parameters to be used with the WSManCreateShell function. The structure must be allocated by the
		/// client and passed to the <c>WSManCreateShell</c> function.
		/// </para>
		/// <para>
		/// The configuration passed to the WSManCreateShell function can directly affect the behavior of a command executed within the
		/// shell. A typical example is the workingDirectory argument that describes the working directory associated with each process,
		/// which the operating system uses when attempting to locate files specified by using a relative path.
		/// </para>
		/// <para>
		/// In the absence of specific requirements for stream naming, clients and services should attempt to use <c>STDIN</c> for input
		/// streams, <c>STDOUT</c> for the default output stream, and <c>STDERR</c> for the error or status output stream.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/ns-wsman-wsman_shell_startup_info_v11 typedef struct
		// _WSMAN_SHELL_STARTUP_INFO_V11 : _WSMAN_SHELL_STARTUP_INFO_V10 { PCWSTR name; } WSMAN_SHELL_STARTUP_INFO_V11;
		[PInvokeData("wsman.h", MSDNShortId = "NS:wsman._WSMAN_SHELL_STARTUP_INFO_V11")]
		[StructLayout(LayoutKind.Sequential)]
		public struct WSMAN_SHELL_STARTUP_INFO_V11
		{
			/// <summary>
			/// A pointer to a WSMAN_STREAM_ID_SET structure that specifies a set of input streams for the shell. Streams not present in the
			/// filter can be ignored by the shell implementation. For the Windows Cmd.exe shell, this value should be L"stdin". If the
			/// value is <c>NULL</c>, the implementation uses an array with L"stdin" as the default value.
			/// </summary>
			public IntPtr inputStreamSet;

			/// <summary>
			/// A pointer to a WSMAN_STREAM_ID_SET structure that specifies a set of output streams for the shell. Streams not present in
			/// the filter can be ignored by the shell implementation. For the Windows cmd.exe shell, this value should be L"stdout stderr".
			/// If the value is <c>NULL</c>, the implementation uses an array with L"stdout" and L"stderr" as the default value.
			/// </summary>
			public IntPtr outputStreamSet;

			/// <summary>
			/// Specifies the maximum duration, in milliseconds, the shell will stay open without any client request. When the maximum
			/// duration is exceeded, the shell is automatically deleted. Any value from 0 to 0xFFFFFFFF can be set. This duration has a
			/// maximum value specified by the Idle time-out GPO setting, if enabled, or by the IdleTimeout local configuration. The default
			/// value of the maximum duration in the GPO/local configuration is 15 minutes. However, a system administrator can change this
			/// value. To use the maximum value from the GPO/local configuration, the client should specify 0 (zero) in this field. If an
			/// explicit value between 0 to 0xFFFFFFFF is used, the minimum value between the explicit API value and the value from the
			/// GPO/local configuration is used.
			/// </summary>
			public uint idleTimeoutMs;

			/// <summary>
			/// Specifies the starting directory for a shell. It is used with any execution command. If this member is a <c>NULL</c> value,
			/// a default directory will be used by the remote machine when executing the command. An empty value is treated by the
			/// underlying protocol as an omitted value.
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string workingDirectory;

			/// <summary>
			/// A pointer to a WSMAN_ENVIRONMENT_VARIABLE_SET structure that specifies an array of variable name and value pairs, which
			/// describe the starting environment for the shell. The content of these elements is shell specific and can be defined in terms
			/// of other environment variables. If a <c>NULL</c> value is passed, the default environment is used on the server side.
			/// </summary>
			public IntPtr variableSet;

			/// <summary>
			/// Specifies an optional friendly name to be associated with the shell. This parameter is only functional when the client
			/// passes the flag <c>WSMAN_FLAG_REQUESTED_API_VERSION_1_1</c> to WSManInitialize.
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string name;
		}

		/// <summary>Lists all the streams that are used for either input or output for the shell and commands.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/ns-wsman-wsman_stream_id_set typedef struct _WSMAN_STREAM_ID_SET { DWORD
		// streamIDsCount; PCWSTR *streamIDs; } WSMAN_STREAM_ID_SET;
		[PInvokeData("wsman.h", MSDNShortId = "NS:wsman._WSMAN_STREAM_ID_SET")]
		[StructLayout(LayoutKind.Sequential)]
		public struct WSMAN_STREAM_ID_SET
		{
			/// <summary>Defines the number of stream IDs in <c>streamIDs</c>.</summary>
			public uint streamIDsCount;

			/// <summary>Specifies an array of stream IDs.</summary>
			public IntPtr streamIDs;
		}

		/// <summary>Defines the credentials used for authentication.</summary>
		/// <remarks>
		/// <para>
		/// The client can specify the credentials to use when creating a shell on a computer. The user name should be specified in the form
		/// DOMAIN\username for a domain account or SERVERNAME\username for a local account on a server computer.
		/// </para>
		/// <para>
		/// If this structure is used, it should have both the user name and password fields specified. It can be used with Basic, Digest,
		/// Negotiate, or Kerberos authentication. The client must explicitly specify the credentials when either Basic or Digest
		/// authentication is used.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsman/ns-wsman-wsman_username_password_creds typedef struct
		// _WSMAN_USERNAME_PASSWORD_CREDS { PCWSTR username; PCWSTR password; } WSMAN_USERNAME_PASSWORD_CREDS;
		[PInvokeData("wsman.h", MSDNShortId = "NS:wsman._WSMAN_USERNAME_PASSWORD_CREDS")]
		[StructLayout(LayoutKind.Sequential)]
		public struct WSMAN_USERNAME_PASSWORD_CREDS
		{
			/// <summary>Defines the user name for a local or domain account. It cannot be <c>NULL</c>.</summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string username;

			/// <summary>Defines the password for a local or domain account. It cannot be <c>NULL</c>.</summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string password;
		}

		/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="WSMAN_API_HANDLE"/> that is disposed using <see cref="WSManDeinitialize"/>.</summary>
		public class SafeWSMAN_API_HANDLE : SafeHANDLE
		{
			/// <summary>Initializes a new instance of the <see cref="SafeWSMAN_API_HANDLE"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafeWSMAN_API_HANDLE(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SafeWSMAN_API_HANDLE"/> class.</summary>
			private SafeWSMAN_API_HANDLE() : base() { }

			/// <summary>Performs an implicit conversion from <see cref="SafeWSMAN_API_HANDLE"/> to <see cref="WSMAN_API_HANDLE"/>.</summary>
			/// <param name="h">The safe handle instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator WSMAN_API_HANDLE(SafeWSMAN_API_HANDLE h) => h.handle;

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() => WSManDeinitialize(handle).Succeeded;
		}

		/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="WSMAN_OPERATION_HANDLE"/> that is disposed using <see cref="WSManCloseOperation"/>.</summary>
		public class SafeWSMAN_OPERATION_HANDLE : SafeHANDLE
		{
			/// <summary>Initializes a new instance of the <see cref="SafeWSMAN_OPERATION_HANDLE"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafeWSMAN_OPERATION_HANDLE(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SafeWSMAN_OPERATION_HANDLE"/> class.</summary>
			private SafeWSMAN_OPERATION_HANDLE() : base() { }

			/// <summary>Performs an implicit conversion from <see cref="SafeWSMAN_OPERATION_HANDLE"/> to <see cref="WSMAN_OPERATION_HANDLE"/>.</summary>
			/// <param name="h">The safe handle instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator WSMAN_OPERATION_HANDLE(SafeWSMAN_OPERATION_HANDLE h) => h.handle;

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() => WSManCloseOperation(handle).Succeeded;
		}

		/// <summary>
		/// Provides a <see cref="SafeHandle"/> for <see cref="WSMAN_SESSION_HANDLE"/> that is disposed using <see
		/// cref="WSManCloseSession(WSMAN_SESSION_HANDLE, uint)"/>.
		/// </summary>
		public class SafeWSMAN_SESSION_HANDLE : SafeHANDLE
		{
			/// <summary>Initializes a new instance of the <see cref="SafeWSMAN_SESSION_HANDLE"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafeWSMAN_SESSION_HANDLE(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SafeWSMAN_SESSION_HANDLE"/> class.</summary>
			private SafeWSMAN_SESSION_HANDLE() : base() { }

			/// <summary>Performs an implicit conversion from <see cref="SafeWSMAN_SESSION_HANDLE"/> to <see cref="WSMAN_SESSION_HANDLE"/>.</summary>
			/// <param name="h">The safe handle instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator WSMAN_SESSION_HANDLE(SafeWSMAN_SESSION_HANDLE h) => h.handle;

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() => WSManCloseSession(handle).Succeeded;
		}
	}
}