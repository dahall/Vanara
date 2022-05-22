using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Vanara.Extensions;
using Vanara.Extensions.Reflection;
using Vanara.InteropServices;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke
{
	/// <summary>Platform invokable enumerated types, constants and functions from ntdll.h</summary>
	public static partial class NtDll
	{
		/// <summary>
		/// <para>The <c>KEY_INFORMATION_CLASS</c> enumeration type represents the type of information to supply about a registry key.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Use the <c>KEY_INFORMATION_CLASS</c> values to specify the type of data to be supplied by the ZwEnumerateKey and ZwQueryKey routines.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/content/wdm/ne-wdm-_key_information_class typedef enum
		// _KEY_INFORMATION_CLASS { KeyBasicInformation , KeyNodeInformation , KeyFullInformation , KeyNameInformation ,
		// KeyCachedInformation , KeyFlagsInformation , KeyVirtualizationInformation , KeyHandleTagsInformation , KeyTrustInformation ,
		// KeyLayerInformation , MaxKeyInfoClass } KEY_INFORMATION_CLASS;
		[PInvokeData("wdm.h", MSDNShortId = "cb531a0e-c934-4f3e-9b92-07eb3ab75673")]
		public enum KEY_INFORMATION_CLASS : uint
		{
			/// <summary>A KEY_BASIC_INFORMATION structure is supplied.</summary>
			[CorrespondingType(typeof(KEY_BASIC_INFORMATION))]
			KeyBasicInformation,

			/// <summary>A KEY_NODE_INFORMATION structure is supplied.</summary>
			[CorrespondingType(typeof(KEY_NODE_INFORMATION))]
			KeyNodeInformation,

			/// <summary>A KEY_FULL_INFORMATION structure is supplied.</summary>
			[CorrespondingType(typeof(KEY_FULL_INFORMATION))]
			KeyFullInformation,

			/// <summary>A KEY_NAME_INFORMATION structure is supplied.</summary>
			[CorrespondingType(typeof(KEY_NAME_INFORMATION))]
			KeyNameInformation,

			/// <summary>A KEY_CACHED_INFORMATION structure is supplied.</summary>
			KeyCachedInformation,

			/// <summary>Reserved for system use.</summary>
			KeyFlagsInformation,

			/// <summary>A KEY_VIRTUALIZATION_INFORMATION structure is supplied.</summary>
			KeyVirtualizationInformation,

			/// <summary>Reserved for system use.</summary>
			KeyHandleTagsInformation,

			/// <summary/>
			KeyTrustInformation,

			/// <summary/>
			KeyLayerInformation,

			/// <summary>The maximum value in this enumeration type.</summary>
			MaxKeyInfoClass,
		}

		/// <summary>
		/// <para>The <c>DbgBreakPoint</c> routine breaks into the kernel debugger.</para>
		/// </summary>
		/// <returns>
		/// <para>None</para>
		/// </returns>
		/// <remarks>
		/// <para>The <c>DbgBreakPoint</c> routine is the kernel-mode equivalent of <c>DebugBreak</c>.</para>
		/// <para>
		/// This routine raises an exception that is handled by the kernel debugger if one is installed; otherwise, it is handled by the
		/// debug system. If a debugger is not connected to the system, the exception can be handled in the standard way.
		/// </para>
		/// <para>
		/// In kernel mode, a break exception that is not handled will cause a bug check. You can, however, connect a kernel-mode debugger
		/// to a target computer that has stopped responding and has kernel debugging enabled. For more information, see Windows Debugging.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/content/wdm/nf-wdm-dbgbreakpoint __analysis_noreturn VOID
		// DbgBreakPoint( );
		[DllImport(Lib.NtDll, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wdm.h", MSDNShortId = "deeac910-2cc3-4a54-bf3b-aeb56d0004dc")]
		public static extern void DbgBreakPoint();

		/// <summary>
		/// <para>The <c>DbgPrint</c> routine sends a message to the kernel debugger. </para>
		/// <para>
		/// In Windows Vista and later versions of Windows, <c>DbgPrint</c> sends a message only when the conditions that you specify
		/// apply (see the <a href="#remarks">Remarks</a> section for information).
		/// </para>
		/// </summary>
		/// <param name="Format">
		/// <para>
		/// Specifies a pointer to the format string to print. The Format string supports most of the printf-style format specification fields.
		/// However, the Unicode format codes (%C, %S, %lc, %ls, %wc, %ws, and %wZ) can only be used with IRQL = PASSIVE_LEVEL.
		/// The <c>DbgPrint</c> routine does not support any of the floating point types (%f, %e, %E, %g, %G, %a, or %A).
		/// </para>
		/// </param>
		/// <param name="arguments">
		/// <para>Specifies arguments for the format string, as in <c>printf</c>.</para>
		/// </param>
		/// <returns>
		/// <para>If successful, <c>DbgPrint</c> returns the NTSTATUS code STATUS_SUCCESS; otherwise it returns the appropriate error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>DbgPrint</c> and <c>DbgPrintEx</c> can be called at IRQL&lt;=DIRQL. However, Unicode format codes (%wc and %ws) can be used only
		/// at IRQL=PASSIVE_LEVEL. Also, because the debugger uses interprocess interrupts (IPIs) to communicate with other processors,
		/// calling <c>DbgPrint</c> at IRQL&gt;DIRQL can cause deadlocks.
		/// </para>
		/// <para> Only kernel-mode drivers can call the <c>DbgPrint</c> routine. </para>
		/// <para>
		/// In Microsoft Windows Server 2003 and earlier versions of Windows, the <c>DbgPrint</c> routine sends a message to the kernel debugger.
		/// In Windows Vista and later versions of Windows, <c>DbgPrint</c> sends a message only if certain conditions apply.
		/// Specifically, it behaves like the DbgPrintEx routine with the DEFAULT component and a message importance level of DPFLTR_INFO_LEVEL.
		/// <code>
		/// DbgPrint ( Format, arguments ),
		/// DbgPrintEx ( DPFLTR_DEFAULT_ID, DPFLTR_INFO_LEVEL, Format, arguments )
		/// </code>
		/// </para>
		/// <para> For more information about message filtering, components, and message importance level, see Reading and Filtering Debugging Messages. </para>
		/// <para>
		/// Regardless of which version of Windows you are using, it is recommended that you use <c>DbgPrintEx</c> instead of <c>DbgPrint</c>,
		/// since this allows you to control the conditions under which the message is sent.
		/// </para>
		/// <para>
		/// Unless it is absolutely necessary, you should not obtain a string from user input or another process and pass it to <c>DbgPrint</c>.
		/// If you do use a string that you did not create, you must verify that this is a valid format string, and that the format codes
		/// match the argument list in type and quantity. The best coding practice is for all Format strings to be static and defined at compile time.
		/// </para>
		/// <para>
		/// There is no upper limit to the size of the Format string or the number of arguments. However, any single call to <c>DbgPrint</c>
		/// will only transmit 512 bytes of information. There is also a limit to the size of the <c>DbgPrint</c> buffer.
		/// See DbgPrint Buffer and the Debugger for details.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-dbgprint ULONG DbgPrint([in] PCSTR Format,...);
		[DllImport(Lib.NtDll, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wdm.h", MSDNShortId = "NF:wdm.DbgPrint")]
		public static extern NTStatus DbgPrint([MarshalAs(UnmanagedType.LPTStr)] string Format, IntPtr arguments);

		/// <summary>
		/// <para>The <c>DbgPrintEx</c> routine sends a string to the kernel debugger if the conditions you specify are met. </para>
		/// </summary>
		/// <param name="ComponentId">
		/// <para>Specifies the component calling this routine. This must be one of the component name filter IDs defined in the Dpfilter.h header file.
		/// To avoid mixing your driver's output with the output of Windows components, you should use only the following values for <i>ComponentId</i>:</para>
		/// <ul><li>DPFLTR_IHVVIDEO_ID</li>
		/// <li>DPFLTR_IHVAUDIO_ID</li>
		/// <li>DPFLTR_IHVNETWORK_ID</li>
		/// <li>DPFLTR_IHVSTREAMING_ID</li>
		/// <li>DPFLTR_IHVBUS_ID</li>
		/// <li>DPFLTR_IHVDRIVER_ID</li></ul>
		/// </param>
		/// <param name="Level">
		/// <para>Specifies the severity of the message being sent. This can be any 32-bit integer. Values between 0 and 31 (inclusive)
		/// are treated differently than values between 32 and 0xFFFFFFFF.
		/// For details, see Reading and Filtering Debugging Messages.</para>
		/// </param>
		/// <param name="Format">
		/// <para>
		/// Specifies a pointer to the format string to print. The Format string supports most of the printf-style format specification fields.
		/// However, the Unicode format codes (%C, %S, %lc, %ls, %wc, %ws, and %wZ) can only be used with IRQL = PASSIVE_LEVEL.
		/// The <c>DbgPrintEx</c> routine does not support any of the floating point types (%f, %e, %E, %g, %G, %a, or %A).
		/// </para>
		/// </param>
		/// <param name="arguments">
		/// <para>Specifies arguments for the format string, as in <c>printf</c>.</para>
		/// </param>
		/// <returns>
		/// <para>If successful, <c>DbgPrintEx</c> returns the NTSTATUS code STATUS_SUCCESS; otherwise it returns the appropriate error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Only kernel-mode drivers can call the  <c>DbgPrintEx</c> routine.
		/// </para>
		/// <para>
		/// <c>DbgPrint</c> and <c>DbgPrintEx</c> can be called at IRQL&lt;=DIRQL. However, Unicode format codes (%wc and %ws) can be used only
		/// at IRQL=PASSIVE_LEVEL. Also, because the debugger uses interprocess interrupts (IPIs) to communicate with other processors,
		/// calling <c>DbgPrint</c> at IRQL&gt;DIRQL can cause deadlocks.</para>
		/// <para>
		/// <c>DbgPrintEx</c> either passes the specified string to the kernel debugger or does nothing at all, depending on the values of
		/// ComponentId, Level, and the corresponding component filter masks. For details, see Reading and Filtering Debugging Messages.
		/// </para>
		/// <para>
		/// Unless it is absolutely necessary, you should not obtain a string from user input or another process and pass it to <c>DbgPrintEx</c>.
		/// If you do use a string that you did not create, you must verify that this is a valid format string, and that the format codes
		/// match the argument list in type and quantity. The best coding practice is for all Format strings to be static and defined at compile time.
		/// </para>
		/// <para>
		/// There is no upper limit to the size of the Format string or the number of arguments. However, any single call to <c>DbgPrintEx</c>
		/// will only transmit 512 bytes of information. There is also a limit to the size of the <c>DbgPrint</c> buffer.
		/// See DbgPrint Buffer and the Debugger for details.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-dbgprintex NTSYSAPI ULONG
		// DbgPrintEx([in] ULONG ComponentId, [in] ULONG Level,[in] PCSTR Format,...);
		[DllImport(Lib.NtDll, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wdm.h", MSDNShortId = "NF:wdm.DbgPrintEx"")]
		public static extern NTStatus DbgPrintEx(uint ComponentId, uint Level, [MarshalAs(UnmanagedType.LPTStr)] string Format, IntPtr arguments);

		/// <summary>
		/// <para>
		/// The <c>ZwCommitComplete</c> routine notifies KTM that the calling resource manager has finished committing a transaction's data.
		/// </para>
		/// </summary>
		/// <param name="EnlistmentHandle">
		/// <para>
		/// A handle to an enlistment object that was obtained by a previous call to ZwCreateEnlistment or ZwOpenEnlistment. The handle must
		/// have ENLISTMENT_SUBORDINATE_RIGHTS access to the object.
		/// </para>
		/// </param>
		/// <param name="TmVirtualClock">
		/// <para>A pointer to a virtual clock value. This parameter is optional and can be <c>NULL</c>.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// <c>ZwCommitComplete</c> returns STATUS_SUCCESS if the operation succeeds. Otherwise, this routine might return one of the
		/// following values:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>STATUS_OBJECT_TYPE_MISMATCH</term>
		/// <term>The specified handle is not a handle to an enlistment object.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_INVALID_HANDLE</term>
		/// <term>The object handle is invalid.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_ACCESS_DENIED</term>
		/// <term>The caller does not have appropriate access to the enlistment object.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_TRANSACTION_NOT_REQUESTED</term>
		/// <term>The transaction or its enlistment is not in the correct state.</term>
		/// </item>
		/// </list>
		/// <para>The routine might return other NTSTATUS values.</para>
		/// </returns>
		/// <remarks>
		/// <para>A resource manager must call <c>ZwCommitComplete</c> after it has finished servicing a TRANSACTION_NOTIFY_COMMIT notification.</para>
		/// <para>For more information about <c>ZwCommitComplete</c>, see Handling Commit Operations.</para>
		/// <para>
		/// For calls from kernel-mode drivers, the <c>NtXxx</c> and <c>ZwXxx</c> versions of a Windows Native System Services routine can
		/// behave differently in the way that they handle and interpret input parameters. For more information about the relationship
		/// between the <c>NtXxx</c> and <c>ZwXxx</c> versions of a routine, see Using Nt and Zw Versions of the Native System Services Routines.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/content/wdm/nf-wdm-ntcommitcomplete __kernel_entry NTSYSCALLAPI
		// NTSTATUS NtCommitComplete( HANDLE EnlistmentHandle, PLARGE_INTEGER TmVirtualClock );
		[DllImport(Lib.NtDll, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wdm.h", MSDNShortId = "d0b968bc-bbab-4b6f-bb1f-9e36ac7c1e05")]
		public static extern NTStatus NtCommitComplete([In] SafeEnlistmentHandle EnlistmentHandle, in long TmVirtualClock);

		/// <summary>
		/// <para>
		/// The <c>ZwCommitComplete</c> routine notifies KTM that the calling resource manager has finished committing a transaction's data.
		/// </para>
		/// </summary>
		/// <param name="EnlistmentHandle">
		/// <para>
		/// A handle to an enlistment object that was obtained by a previous call to ZwCreateEnlistment or ZwOpenEnlistment. The handle must
		/// have ENLISTMENT_SUBORDINATE_RIGHTS access to the object.
		/// </para>
		/// </param>
		/// <param name="TmVirtualClock">
		/// <para>A pointer to a virtual clock value. This parameter is optional and can be <c>NULL</c>.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// <c>ZwCommitComplete</c> returns STATUS_SUCCESS if the operation succeeds. Otherwise, this routine might return one of the
		/// following values:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>STATUS_OBJECT_TYPE_MISMATCH</term>
		/// <term>The specified handle is not a handle to an enlistment object.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_INVALID_HANDLE</term>
		/// <term>The object handle is invalid.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_ACCESS_DENIED</term>
		/// <term>The caller does not have appropriate access to the enlistment object.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_TRANSACTION_NOT_REQUESTED</term>
		/// <term>The transaction or its enlistment is not in the correct state.</term>
		/// </item>
		/// </list>
		/// <para>The routine might return other NTSTATUS values.</para>
		/// </returns>
		/// <remarks>
		/// <para>A resource manager must call <c>ZwCommitComplete</c> after it has finished servicing a TRANSACTION_NOTIFY_COMMIT notification.</para>
		/// <para>For more information about <c>ZwCommitComplete</c>, see Handling Commit Operations.</para>
		/// <para>
		/// For calls from kernel-mode drivers, the <c>NtXxx</c> and <c>ZwXxx</c> versions of a Windows Native System Services routine can
		/// behave differently in the way that they handle and interpret input parameters. For more information about the relationship
		/// between the <c>NtXxx</c> and <c>ZwXxx</c> versions of a routine, see Using Nt and Zw Versions of the Native System Services Routines.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/content/wdm/nf-wdm-ntcommitcomplete __kernel_entry NTSYSCALLAPI
		// NTSTATUS NtCommitComplete( HANDLE EnlistmentHandle, PLARGE_INTEGER TmVirtualClock );
		[DllImport(Lib.NtDll, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wdm.h", MSDNShortId = "d0b968bc-bbab-4b6f-bb1f-9e36ac7c1e05")]
		public static extern NTStatus NtCommitComplete([In] SafeEnlistmentHandle EnlistmentHandle, [In, Optional] IntPtr TmVirtualClock);

		/// <summary>
		/// <para>The <c>ZwCommitEnlistment</c> routine initiates the commit operation for a specified enlistment's transaction.</para>
		/// </summary>
		/// <param name="EnlistmentHandle">
		/// <para>
		/// A handle to an enlistment object that was obtained by a previous call to ZwCreateEnlistment or ZwOpenEnlistment. The object must
		/// represent a superior enlistment and the handle must have ENLISTMENT_SUPERIOR_RIGHTS access to the object.
		/// </para>
		/// </param>
		/// <param name="TmVirtualClock">
		/// <para>A pointer to a virtual clock value. This parameter is optional and can be <c>NULL</c>.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// <c>ZwCommitEnlistment</c> returns STATUS_SUCCESS if the operation succeeds. Otherwise, this routine might return one of the
		/// following values:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>STATUS_OBJECT_TYPE_MISMATCH</term>
		/// <term>The specified handle is not a handle to an enlistment object.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_INVALID_HANDLE</term>
		/// <term>The object handle is invalid.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_ACCESS_DENIED</term>
		/// <term>The caller does not have appropriate access to the enlistment object.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_ENLISTMENT_NOT_SUPERIOR</term>
		/// <term>The caller is not a superior transaction manager for the enlistment.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_TRANSACTION_RESPONSE_NOT_ENLISTED</term>
		/// <term>The caller did not register to receive TRANSACTION_NOTIFY_COMMIT_COMPLETE notifications.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_TRANSACTION_REQUEST_NOT_VALID</term>
		/// <term>The enlistment's transaction is not in a state that allows it to be committed.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_TRANSACTION_NOT_ACTIVE</term>
		/// <term>The commit operation for this transaction has already been started.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_TRANSACTION_ALREADY_ABORTED</term>
		/// <term>The transaction cannot be committed because it has been rolled back.</term>
		/// </item>
		/// </list>
		/// <para>The routine might return other NTSTATUS values.</para>
		/// </returns>
		/// <remarks>
		/// <para>Only superior transaction managers can call <c>ZwCommitEnlistment</c>.</para>
		/// <para>Callers of <c>ZwCommitEnlistment</c> must register to receive TRANSACTION_NOTIFY_COMMIT_COMPLETE notifications.</para>
		/// <para>
		/// The <c>ZwCommitEnlistment</c> routine causes KTM to send TRANSACTION_NOTIFY_COMMIT notifications to all resource managers that
		/// have enlisted in the transaction.
		/// </para>
		/// <para>
		/// For more information about <c>ZwCommitEnlistment</c>, see Creating a Superior Transaction Manager and Handling Commit Operations.
		/// </para>
		/// <para>
		/// For calls from kernel-mode drivers, the <c>NtXxx</c> and <c>ZwXxx</c> versions of a Windows Native System Services routine can
		/// behave differently in the way that they handle and interpret input parameters. For more information about the relationship
		/// between the <c>NtXxx</c> and <c>ZwXxx</c> versions of a routine, see Using Nt and Zw Versions of the Native System Services Routines.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/content/wdm/nf-wdm-ntcommitenlistment __kernel_entry NTSYSCALLAPI
		// NTSTATUS NtCommitEnlistment( HANDLE EnlistmentHandle, PLARGE_INTEGER TmVirtualClock );
		[DllImport(Lib.NtDll, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wdm.h", MSDNShortId = "9c7f3e24-1d7c-450e-bbef-df0479911bc6")]
		public static extern NTStatus NtCommitEnlistment([In] SafeEnlistmentHandle EnlistmentHandle, in long TmVirtualClock);

		/// <summary>
		/// <para>The <c>ZwCommitEnlistment</c> routine initiates the commit operation for a specified enlistment's transaction.</para>
		/// </summary>
		/// <param name="EnlistmentHandle">
		/// <para>
		/// A handle to an enlistment object that was obtained by a previous call to ZwCreateEnlistment or ZwOpenEnlistment. The object must
		/// represent a superior enlistment and the handle must have ENLISTMENT_SUPERIOR_RIGHTS access to the object.
		/// </para>
		/// </param>
		/// <param name="TmVirtualClock">
		/// <para>A pointer to a virtual clock value. This parameter is optional and can be <c>NULL</c>.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// <c>ZwCommitEnlistment</c> returns STATUS_SUCCESS if the operation succeeds. Otherwise, this routine might return one of the
		/// following values:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>STATUS_OBJECT_TYPE_MISMATCH</term>
		/// <term>The specified handle is not a handle to an enlistment object.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_INVALID_HANDLE</term>
		/// <term>The object handle is invalid.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_ACCESS_DENIED</term>
		/// <term>The caller does not have appropriate access to the enlistment object.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_ENLISTMENT_NOT_SUPERIOR</term>
		/// <term>The caller is not a superior transaction manager for the enlistment.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_TRANSACTION_RESPONSE_NOT_ENLISTED</term>
		/// <term>The caller did not register to receive TRANSACTION_NOTIFY_COMMIT_COMPLETE notifications.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_TRANSACTION_REQUEST_NOT_VALID</term>
		/// <term>The enlistment's transaction is not in a state that allows it to be committed.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_TRANSACTION_NOT_ACTIVE</term>
		/// <term>The commit operation for this transaction has already been started.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_TRANSACTION_ALREADY_ABORTED</term>
		/// <term>The transaction cannot be committed because it has been rolled back.</term>
		/// </item>
		/// </list>
		/// <para>The routine might return other NTSTATUS values.</para>
		/// </returns>
		/// <remarks>
		/// <para>Only superior transaction managers can call <c>ZwCommitEnlistment</c>.</para>
		/// <para>Callers of <c>ZwCommitEnlistment</c> must register to receive TRANSACTION_NOTIFY_COMMIT_COMPLETE notifications.</para>
		/// <para>
		/// The <c>ZwCommitEnlistment</c> routine causes KTM to send TRANSACTION_NOTIFY_COMMIT notifications to all resource managers that
		/// have enlisted in the transaction.
		/// </para>
		/// <para>
		/// For more information about <c>ZwCommitEnlistment</c>, see Creating a Superior Transaction Manager and Handling Commit Operations.
		/// </para>
		/// <para>
		/// For calls from kernel-mode drivers, the <c>NtXxx</c> and <c>ZwXxx</c> versions of a Windows Native System Services routine can
		/// behave differently in the way that they handle and interpret input parameters. For more information about the relationship
		/// between the <c>NtXxx</c> and <c>ZwXxx</c> versions of a routine, see Using Nt and Zw Versions of the Native System Services Routines.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/content/wdm/nf-wdm-ntcommitenlistment __kernel_entry NTSYSCALLAPI
		// NTSTATUS NtCommitEnlistment( HANDLE EnlistmentHandle, PLARGE_INTEGER TmVirtualClock );
		[DllImport(Lib.NtDll, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wdm.h", MSDNShortId = "9c7f3e24-1d7c-450e-bbef-df0479911bc6")]
		public static extern NTStatus NtCommitEnlistment([In] SafeEnlistmentHandle EnlistmentHandle, [In, Optional] IntPtr TmVirtualClock);

		/// <summary>
		/// <para>The <c>ZwCommitTransaction</c> routine initiates a commit operation for a specified transaction.</para>
		/// </summary>
		/// <param name="TransactionHandle">
		/// <para>
		/// A handle to a transaction object. Your component receives this handle from ZwCreateTransaction or ZwOpenTransaction. The handle
		/// must have TRANSACTION_COMMIT access to the object.
		/// </para>
		/// </param>
		/// <param name="Wait">
		/// <para>
		/// A Boolean value that the caller sets to <c>TRUE</c> for synchronous operation or <c>FALSE</c> for asynchronous operation. If
		/// this parameter is <c>TRUE</c>, the call returns after the commit operation is complete.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>
		/// <c>ZwCommitTransaction</c> returns STATUS_SUCCESS if the operation succeeds. Otherwise, this routine might return one of the
		/// following values:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>STATUS_OBJECT_TYPE_MISMATCH</term>
		/// <term>The handle that was specified for the TransactionHandle parameter is not a handle to a transaction object.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_INVALID_HANDLE</term>
		/// <term>The specified transaction object handle is invalid.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_ACCESS_DENIED</term>
		/// <term>The caller does not have appropriate access to the transaction object.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_TRANSACTION_SUPERIOR_EXISTS</term>
		/// <term>The caller cannot commit the transaction because a superior transaction manager exists.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_TRANSACTION_ALREADY_ABORTED</term>
		/// <term>The transaction cannot be committed because it has been rolled back.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_TRANSACTION_ALREADY_COMMITTED</term>
		/// <term>The transaction is already committed.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_TRANSACTION_REQUEST_NOT_VALID</term>
		/// <term>The commit operation for this transaction has already been started.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_PENDING</term>
		/// <term>Commit notifications have been queued to resource managers, and the caller specified FALSE for the Wait parameter.</term>
		/// </item>
		/// </list>
		/// <para>The routine might return other NTSTATUS values.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// For more information about how transaction clients should use the <c>ZwCommitTransaction</c> routine, see Creating a
		/// Transactional Client.
		/// </para>
		/// <para>For more information about commit operations, see Handling Commit Operations.</para>
		/// <para>
		/// For calls from kernel-mode drivers, the <c>NtXxx</c> and <c>ZwXxx</c> versions of a Windows Native System Services routine can
		/// behave differently in the way that they handle and interpret input parameters. For more information about the relationship
		/// between the <c>NtXxx</c> and <c>ZwXxx</c> versions of a routine, see Using Nt and Zw Versions of the Native System Services Routines.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/content/wdm/nf-wdm-ntcommittransaction __kernel_entry NTSYSCALLAPI
		// NTSTATUS NtCommitTransaction( HANDLE TransactionHandle, BOOLEAN Wait );
		[DllImport(Lib.NtDll, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wdm.h", MSDNShortId = "145646f3-ff90-41d6-bf76-947cdf93b489")]
		public static extern NTStatus NtCommitTransaction([In] IntPtr TransactionHandle, [MarshalAs(UnmanagedType.U1)] bool Wait);

		/// <summary>
		/// <para>The <c>ZwCreateEnlistment</c> routine creates a new enlistment object for a transaction.</para>
		/// </summary>
		/// <param name="EnlistmentHandle">
		/// <para>
		/// A pointer to a caller-allocated variable that receives a handle to the new enlistment object if the call to
		/// <c>ZwCreateEnlistment</c> succeeds.
		/// </para>
		/// </param>
		/// <param name="DesiredAccess">
		/// <para>
		/// An ACCESS_MASK value that specifies the caller's requested access to the enlistment object. In addition to the access rights
		/// that are defined for all kinds of objects (see ACCESS_MASK), the caller can specify any of the following access right flags for
		/// enlistment objects:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>ACCESS_MASK flag</term>
		/// <term>Allows the caller to</term>
		/// </listheader>
		/// <item>
		/// <term>ENLISTMENT_QUERY_INFORMATION</term>
		/// <term>Query information about the enlistment (see ZwQueryInformationEnlistment).</term>
		/// </item>
		/// <item>
		/// <term>ENLISTMENT_SET_INFORMATION</term>
		/// <term>Set information for the enlistment (see ZwSetInformationEnlistment).</term>
		/// </item>
		/// <item>
		/// <term>ENLISTMENT_RECOVER</term>
		/// <term>Recover the enlistment (see ZwRecoverEnlistment).</term>
		/// </item>
		/// <item>
		/// <term>ENLISTMENT_SUBORDINATE_RIGHTS</term>
		/// <term>
		/// Perform operations that a resource manager that is not superior performs (see ZwRollbackEnlistment, ZwPrePrepareComplete,
		/// ZwPrepareComplete, ZwCommitComplete, ZwRollbackComplete, ZwSinglePhaseReject, ZwReadOnlyEnlistment).
		/// </term>
		/// </item>
		/// <item>
		/// <term>ENLISTMENT_SUPERIOR_RIGHTS</term>
		/// <term>
		/// Perform operations that a superior transaction manager must perform (see ZwPrepareEnlistment, ZwPrePrepareEnlistment, ZwCommitEnlistment).
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// Alternatively, you can specify one or more of the following ACCESS_MASK bitmaps. These bitmaps combine the flags from the
		/// previous table with the STANDARD_RIGHTS_XXX flags that are described on the ACCESS_MASK reference page. You can also combine
		/// these bitmaps together with additional flags from the previous table. The following table shows how the bitmaps correspond to
		/// specific access rights.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Generic access right</term>
		/// <term>Set of specific access rights</term>
		/// </listheader>
		/// <item>
		/// <term>ENLISTMENT_GENERIC_READ</term>
		/// <term>STANDARD_RIGHTS_READ and ENLISTMENT_QUERY_INFORMATION</term>
		/// </item>
		/// <item>
		/// <term>ENLISTMENT_GENERIC_WRITE</term>
		/// <term>
		/// STANDARD_RIGHTS_WRITE, ENLISTMENT_SET_INFORMATION, ENLISTMENT_RECOVER, ENLISTMENT_REFERENCE, ENLISTMENT_SUBORDINATE_RIGHTS, and ENLISTMENT_SUPERIOR_RIGHTS
		/// </term>
		/// </item>
		/// <item>
		/// <term>ENLISTMENT_GENERIC_EXECUTE</term>
		/// <term>STANDARD_RIGHTS_EXECUTE, ENLISTMENT_RECOVER, ENLISTMENT_SUBORDINATE_RIGHTS, and ENLISTMENT_SUPERIOR_RIGHTS</term>
		/// </item>
		/// <item>
		/// <term>ENLISTMENT_ALL_ACCESS</term>
		/// <term>STANDARD_RIGHTS_REQUIRED, ENLISTMENT_GENERIC_READ, ENLISTMENT_GENERIC_WRITE, and ENLISTMENT_GENERIC_EXECUTE</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="ResourceManagerHandle">
		/// <para>A handle to the caller's resource manager object that was obtained by a previous call to ZwCreateResourceManager or ZwOpenResourceManager.</para>
		/// </param>
		/// <param name="TransactionHandle">
		/// <para>
		/// A handle to a transaction object that was obtained by a previous call to ZwCreateTransaction or ZwOpenTransaction. KTM adds this
		/// transaction to the list of transactions that the calling resource manager is handling.
		/// </para>
		/// </param>
		/// <param name="ObjectAttributes">
		/// <para>
		/// A pointer to an OBJECT_ATTRIBUTES structure that specifies the object name and other attributes. Use the
		/// InitializeObjectAttributes routine to initialize this structure. If the caller is not running in a system thread context, it
		/// must set the OBJ_KERNEL_HANDLE attribute when it calls <c>InitializeObjectAttributes</c>. This parameter is optional and can be <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="CreateOptions">
		/// <para>Enlistment option flags. The following table contains the only available flag.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>CreateOptions flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ENLISTMENT_SUPERIOR</term>
		/// <term>The caller is enlisting as a superior transaction manager for the specified transaction.</term>
		/// </item>
		/// </list>
		/// <para>This parameter is optional and can be zero.</para>
		/// </param>
		/// <param name="NotificationMask">
		/// <para>
		/// A bitwise OR of TRANSACTION_NOTIFY_XXX values that are defined in Ktmtypes.h. This mask specifies the types of transaction
		/// notifications that KTM sends to the caller.
		/// </para>
		/// </param>
		/// <param name="EnlistmentKey">
		/// <para>
		/// A pointer to caller-defined information that uniquely identifies the enlistment. The resource manager receives this pointer when
		/// it calls ZwGetNotificationResourceManager or when KTM calls the ResourceManagerNotification callback routine. The resource
		/// manager can maintain a reference count for this key by calling TmReferenceEnlistmentKey and TmDereferenceEnlistmentKey. This
		/// parameter is optional and can be <c>NULL</c>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>
		/// <c>ZwCreateEnlistment</c> returns STATUS_SUCCESS if the operation succeeds. Otherwise, this routine might return one of the
		/// following values:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>STATUS_INVALID_HANDLE</term>
		/// <term>An object handle is invalid.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_INVALID_PARAMETER</term>
		/// <term>
		/// The CreateOptions or NotificationMask parameter's value is invalid, or KTM could not find the transaction that the
		/// TransactionHandle parameter specifies.
		/// </term>
		/// </item>
		/// <item>
		/// <term>STATUS_INSUFFICIENT_RESOURCES</term>
		/// <term>A memory allocation failed.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_TRANSACTIONMANAGER_NOT_ONLINE</term>
		/// <term>The enlistment failed because KTM or the resource manager is not in an operational state.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_TRANSACTION_NOT_ACTIVE</term>
		/// <term>The enlistment failed because the transaction that the TransactionHandle parameter specifies is not active.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_TRANSACTION_SUPERIOR_EXISTS</term>
		/// <term>The caller tried to register as a superior transaction manager but a superior transaction manager already exists.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_TM_VOLATILE</term>
		/// <term>
		/// The caller is trying to register as a superior transaction manager, but the caller's resource manager object is volatile while
		/// the associated transaction manager object is not volatile.
		/// </term>
		/// </item>
		/// <item>
		/// <term>STATUS_ACCESS_DENIED</term>
		/// <term>The value of the DesiredAccess parameter is invalid.</term>
		/// </item>
		/// </list>
		/// <para>The routine might return other NTSTATUS values.</para>
		/// </returns>
		/// <remarks>
		/// <para>A resource manager calls <c>ZwCreateEnlistment</c> to enlist in a transaction.</para>
		/// <para>Resource managers that are not superior must include the ENLISTMENT_SUBORDINATE_RIGHTS flag in their access mask.</para>
		/// <para>
		/// Superior transaction managers must include the ENLISTMENT_SUPERIOR_RIGHTS flag in their access masks. Typically, a superior
		/// transaction manager includes code that calls ZwRollbackEnlistment, so it must also include the ENLISTMENT_SUBORDINATE_RIGHTS flag.
		/// </para>
		/// <para>A resource manager that calls <c>ZwCreateEnlistment</c> must eventually call ZwClose to close the object handle.</para>
		/// <para>
		/// Your resource manager can use the EnlistmentKey parameter to assign a unique value to each enlistment, such as a pointer to a
		/// data structure that contains information about the enlistment. For example, if the resource manager stores the enlistment
		/// object's handle in the structure, the resource manager can do the following:
		/// </para>
		/// <para>
		/// For more information about <c>ZwCreateEnlistment</c>, see Creating a Resource Manager and Creating a Superior Transaction Manager.
		/// </para>
		/// <para>
		/// For calls from kernel-mode drivers, the <c>NtXxx</c> and <c>ZwXxx</c> versions of a Windows Native System Services routine can
		/// behave differently in the way that they handle and interpret input parameters. For more information about the relationship
		/// between the <c>NtXxx</c> and <c>ZwXxx</c> versions of a routine, see Using Nt and Zw Versions of the Native System Services Routines.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/content/wdm/nf-wdm-ntcreateenlistment __kernel_entry NTSYSCALLAPI
		// NTSTATUS NtCreateEnlistment( PHANDLE EnlistmentHandle, ACCESS_MASK DesiredAccess, HANDLE ResourceManagerHandle, HANDLE
		// TransactionHandle, POBJECT_ATTRIBUTES ObjectAttributes, ULONG CreateOptions, NOTIFICATION_MASK NotificationMask, PVOID
		// EnlistmentKey );
		[DllImport(Lib.NtDll, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wdm.h", MSDNShortId = "5ffd8262-10b3-4c40-bd3e-050271338508")]
		public static extern NTStatus NtCreateEnlistment(out SafeEnlistmentHandle EnlistmentHandle, ACCESS_MASK DesiredAccess, [In] SafeResourceManagerHandle ResourceManagerHandle,
			[In] SafeTransactionHandle TransactionHandle, in OBJECT_ATTRIBUTES ObjectAttributes, [Optional] uint CreateOptions, NOTIFICATION_MASK NotificationMask, [In, Optional] IntPtr EnlistmentKey);

		/// <summary>
		/// <para>The <c>ZwCreateEnlistment</c> routine creates a new enlistment object for a transaction.</para>
		/// </summary>
		/// <param name="EnlistmentHandle">
		/// <para>
		/// A pointer to a caller-allocated variable that receives a handle to the new enlistment object if the call to
		/// <c>ZwCreateEnlistment</c> succeeds.
		/// </para>
		/// </param>
		/// <param name="DesiredAccess">
		/// <para>
		/// An ACCESS_MASK value that specifies the caller's requested access to the enlistment object. In addition to the access rights
		/// that are defined for all kinds of objects (see ACCESS_MASK), the caller can specify any of the following access right flags for
		/// enlistment objects:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>ACCESS_MASK flag</term>
		/// <term>Allows the caller to</term>
		/// </listheader>
		/// <item>
		/// <term>ENLISTMENT_QUERY_INFORMATION</term>
		/// <term>Query information about the enlistment (see ZwQueryInformationEnlistment).</term>
		/// </item>
		/// <item>
		/// <term>ENLISTMENT_SET_INFORMATION</term>
		/// <term>Set information for the enlistment (see ZwSetInformationEnlistment).</term>
		/// </item>
		/// <item>
		/// <term>ENLISTMENT_RECOVER</term>
		/// <term>Recover the enlistment (see ZwRecoverEnlistment).</term>
		/// </item>
		/// <item>
		/// <term>ENLISTMENT_SUBORDINATE_RIGHTS</term>
		/// <term>
		/// Perform operations that a resource manager that is not superior performs (see ZwRollbackEnlistment, ZwPrePrepareComplete,
		/// ZwPrepareComplete, ZwCommitComplete, ZwRollbackComplete, ZwSinglePhaseReject, ZwReadOnlyEnlistment).
		/// </term>
		/// </item>
		/// <item>
		/// <term>ENLISTMENT_SUPERIOR_RIGHTS</term>
		/// <term>
		/// Perform operations that a superior transaction manager must perform (see ZwPrepareEnlistment, ZwPrePrepareEnlistment, ZwCommitEnlistment).
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// Alternatively, you can specify one or more of the following ACCESS_MASK bitmaps. These bitmaps combine the flags from the
		/// previous table with the STANDARD_RIGHTS_XXX flags that are described on the ACCESS_MASK reference page. You can also combine
		/// these bitmaps together with additional flags from the previous table. The following table shows how the bitmaps correspond to
		/// specific access rights.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Generic access right</term>
		/// <term>Set of specific access rights</term>
		/// </listheader>
		/// <item>
		/// <term>ENLISTMENT_GENERIC_READ</term>
		/// <term>STANDARD_RIGHTS_READ and ENLISTMENT_QUERY_INFORMATION</term>
		/// </item>
		/// <item>
		/// <term>ENLISTMENT_GENERIC_WRITE</term>
		/// <term>
		/// STANDARD_RIGHTS_WRITE, ENLISTMENT_SET_INFORMATION, ENLISTMENT_RECOVER, ENLISTMENT_REFERENCE, ENLISTMENT_SUBORDINATE_RIGHTS, and ENLISTMENT_SUPERIOR_RIGHTS
		/// </term>
		/// </item>
		/// <item>
		/// <term>ENLISTMENT_GENERIC_EXECUTE</term>
		/// <term>STANDARD_RIGHTS_EXECUTE, ENLISTMENT_RECOVER, ENLISTMENT_SUBORDINATE_RIGHTS, and ENLISTMENT_SUPERIOR_RIGHTS</term>
		/// </item>
		/// <item>
		/// <term>ENLISTMENT_ALL_ACCESS</term>
		/// <term>STANDARD_RIGHTS_REQUIRED, ENLISTMENT_GENERIC_READ, ENLISTMENT_GENERIC_WRITE, and ENLISTMENT_GENERIC_EXECUTE</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="ResourceManagerHandle">
		/// <para>A handle to the caller's resource manager object that was obtained by a previous call to ZwCreateResourceManager or ZwOpenResourceManager.</para>
		/// </param>
		/// <param name="TransactionHandle">
		/// <para>
		/// A handle to a transaction object that was obtained by a previous call to ZwCreateTransaction or ZwOpenTransaction. KTM adds this
		/// transaction to the list of transactions that the calling resource manager is handling.
		/// </para>
		/// </param>
		/// <param name="ObjectAttributes">
		/// <para>
		/// A pointer to an OBJECT_ATTRIBUTES structure that specifies the object name and other attributes. Use the
		/// InitializeObjectAttributes routine to initialize this structure. If the caller is not running in a system thread context, it
		/// must set the OBJ_KERNEL_HANDLE attribute when it calls <c>InitializeObjectAttributes</c>. This parameter is optional and can be <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="CreateOptions">
		/// <para>Enlistment option flags. The following table contains the only available flag.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>CreateOptions flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ENLISTMENT_SUPERIOR</term>
		/// <term>The caller is enlisting as a superior transaction manager for the specified transaction.</term>
		/// </item>
		/// </list>
		/// <para>This parameter is optional and can be zero.</para>
		/// </param>
		/// <param name="NotificationMask">
		/// <para>
		/// A bitwise OR of TRANSACTION_NOTIFY_XXX values that are defined in Ktmtypes.h. This mask specifies the types of transaction
		/// notifications that KTM sends to the caller.
		/// </para>
		/// </param>
		/// <param name="EnlistmentKey">
		/// <para>
		/// A pointer to caller-defined information that uniquely identifies the enlistment. The resource manager receives this pointer when
		/// it calls ZwGetNotificationResourceManager or when KTM calls the ResourceManagerNotification callback routine. The resource
		/// manager can maintain a reference count for this key by calling TmReferenceEnlistmentKey and TmDereferenceEnlistmentKey. This
		/// parameter is optional and can be <c>NULL</c>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>
		/// <c>ZwCreateEnlistment</c> returns STATUS_SUCCESS if the operation succeeds. Otherwise, this routine might return one of the
		/// following values:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>STATUS_INVALID_HANDLE</term>
		/// <term>An object handle is invalid.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_INVALID_PARAMETER</term>
		/// <term>
		/// The CreateOptions or NotificationMask parameter's value is invalid, or KTM could not find the transaction that the
		/// TransactionHandle parameter specifies.
		/// </term>
		/// </item>
		/// <item>
		/// <term>STATUS_INSUFFICIENT_RESOURCES</term>
		/// <term>A memory allocation failed.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_TRANSACTIONMANAGER_NOT_ONLINE</term>
		/// <term>The enlistment failed because KTM or the resource manager is not in an operational state.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_TRANSACTION_NOT_ACTIVE</term>
		/// <term>The enlistment failed because the transaction that the TransactionHandle parameter specifies is not active.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_TRANSACTION_SUPERIOR_EXISTS</term>
		/// <term>The caller tried to register as a superior transaction manager but a superior transaction manager already exists.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_TM_VOLATILE</term>
		/// <term>
		/// The caller is trying to register as a superior transaction manager, but the caller's resource manager object is volatile while
		/// the associated transaction manager object is not volatile.
		/// </term>
		/// </item>
		/// <item>
		/// <term>STATUS_ACCESS_DENIED</term>
		/// <term>The value of the DesiredAccess parameter is invalid.</term>
		/// </item>
		/// </list>
		/// <para>The routine might return other NTSTATUS values.</para>
		/// </returns>
		/// <remarks>
		/// <para>A resource manager calls <c>ZwCreateEnlistment</c> to enlist in a transaction.</para>
		/// <para>Resource managers that are not superior must include the ENLISTMENT_SUBORDINATE_RIGHTS flag in their access mask.</para>
		/// <para>
		/// Superior transaction managers must include the ENLISTMENT_SUPERIOR_RIGHTS flag in their access masks. Typically, a superior
		/// transaction manager includes code that calls ZwRollbackEnlistment, so it must also include the ENLISTMENT_SUBORDINATE_RIGHTS flag.
		/// </para>
		/// <para>A resource manager that calls <c>ZwCreateEnlistment</c> must eventually call ZwClose to close the object handle.</para>
		/// <para>
		/// Your resource manager can use the EnlistmentKey parameter to assign a unique value to each enlistment, such as a pointer to a
		/// data structure that contains information about the enlistment. For example, if the resource manager stores the enlistment
		/// object's handle in the structure, the resource manager can do the following:
		/// </para>
		/// <para>
		/// For more information about <c>ZwCreateEnlistment</c>, see Creating a Resource Manager and Creating a Superior Transaction Manager.
		/// </para>
		/// <para>
		/// For calls from kernel-mode drivers, the <c>NtXxx</c> and <c>ZwXxx</c> versions of a Windows Native System Services routine can
		/// behave differently in the way that they handle and interpret input parameters. For more information about the relationship
		/// between the <c>NtXxx</c> and <c>ZwXxx</c> versions of a routine, see Using Nt and Zw Versions of the Native System Services Routines.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/content/wdm/nf-wdm-ntcreateenlistment __kernel_entry NTSYSCALLAPI
		// NTSTATUS NtCreateEnlistment( PHANDLE EnlistmentHandle, ACCESS_MASK DesiredAccess, HANDLE ResourceManagerHandle, HANDLE
		// TransactionHandle, POBJECT_ATTRIBUTES ObjectAttributes, ULONG CreateOptions, NOTIFICATION_MASK NotificationMask, PVOID
		// EnlistmentKey );
		[DllImport(Lib.NtDll, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wdm.h", MSDNShortId = "5ffd8262-10b3-4c40-bd3e-050271338508")]
		public static extern NTStatus NtCreateEnlistment(out SafeEnlistmentHandle EnlistmentHandle, ACCESS_MASK DesiredAccess, [In] SafeResourceManagerHandle ResourceManagerHandle,
			[In] SafeTransactionHandle TransactionHandle, [In, Optional] IntPtr ObjectAttributes, [Optional] uint CreateOptions, NOTIFICATION_MASK NotificationMask, [In, Optional] IntPtr EnlistmentKey);

		/// <summary>
		/// <para>The <c>ZwCreateResourceManager</c> routine creates a resource manager object.</para>
		/// </summary>
		/// <param name="ResourceManagerHandle">
		/// <para>
		/// A pointer to a caller-allocated variable that receives a handle to the new resource manager object if the call to
		/// <c>ZwCreateResourceManager</c> is successful.
		/// </para>
		/// </param>
		/// <param name="DesiredAccess">
		/// <para>
		/// An ACCESS_MASK value that specifies the caller's requested access to the resource manager object. In addition to the access
		/// rights that are defined for all kinds of objects (see <c>ACCESS_MASK</c>), the caller can specify any of the following access
		/// right flags for resource manager objects:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>ACCESS_MASK flag</term>
		/// <term>Allows the caller to</term>
		/// </listheader>
		/// <item>
		/// <term>RESOURCEMANAGER_ENLIST</term>
		/// <term>Enlist in transactions (see ZwCreateEnlistment).</term>
		/// </item>
		/// <item>
		/// <term>RESOURCEMANAGER_GET_NOTIFICATION</term>
		/// <term>Receive notifications about the transactions that are associated with this resource manager (see ZwGetNotificationResourceManager).</term>
		/// </item>
		/// <item>
		/// <term>RESOURCEMANAGER_REGISTER_PROTOCOL</term>
		/// <term>Not used.</term>
		/// </item>
		/// <item>
		/// <term>RESOURCEMANAGER_QUERY_INFORMATION</term>
		/// <term>Query information about the resource manager (see ZwQueryInformationResourceManager).</term>
		/// </item>
		/// <item>
		/// <term>RESOURCEMANAGER_SET_INFORMATION</term>
		/// <term>Not used.</term>
		/// </item>
		/// <item>
		/// <term>RESOURCEMANAGER_RECOVER</term>
		/// <term>Recover the resource manager (see ZwRecoverResourceManager).</term>
		/// </item>
		/// <item>
		/// <term>RESOURCEMANAGER_COMPLETE_PROPAGATION</term>
		/// <term>Not used.</term>
		/// </item>
		/// </list>
		/// <para>
		/// Alternatively, you can specify one or more of the following generic ACCESS_MASK flags. (The STANDARD_RIGHTS_Xxx flags are
		/// predefined system values that are used to enforce security on system objects.) You can also combine these generic flags with
		/// additional flags from the preceding table. The following table shows how generic access rights correspond to specific access rights.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Generic access right</term>
		/// <term>Set of specific access rights</term>
		/// </listheader>
		/// <item>
		/// <term>RESOURCEMANAGER_GENERIC_READ</term>
		/// <term>STANDARD_RIGHTS_READ, RESOURCEMANAGER_QUERY_INFORMATION, and SYNCHRONIZE</term>
		/// </item>
		/// <item>
		/// <term>RESOURCEMANAGER_GENERIC_WRITE</term>
		/// <term>
		/// STANDARD_RIGHTS_WRITE, RESOURCEMANAGER_SET_INFORMATION, RESOURCEMANAGER_RECOVER, RESOURCEMANAGER_ENLIST,
		/// RESOURCEMANAGER_GET_NOTIFICATION, RESOURCEMANAGER_REGISTER_PROTOCOL, RESOURCEMANAGER_COMPLETE_PROPAGATION, and SYNCHRONIZE
		/// </term>
		/// </item>
		/// <item>
		/// <term>RESOURCEMANAGER_GENERIC_EXECUTE</term>
		/// <term>
		/// STANDARD_RIGHTS_EXECUTE, RESOURCEMANAGER_RECOVER, RESOURCEMANAGER_ENLIST, RESOURCEMANAGER_GET_NOTIFICATION,
		/// RESOURCEMANAGER_COMPLETE_PROPAGATION, and SYNCHRONIZE
		/// </term>
		/// </item>
		/// <item>
		/// <term>RESOURCEMANAGER_ALL_ACCESS</term>
		/// <term>STANDARD_RIGHTS_REQUIRED, RESOURCEMANAGER_GENERIC_READ, RESOURCEMANAGER_GENERIC_WRITE, and RESOURCEMANAGER_GENERIC_EXECUTE</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="TmHandle">
		/// <para>A handle to a transaction manager object that was obtained by a previous all to ZwCreateTransactionManager or ZwOpenTransactionManager.</para>
		/// </param>
		/// <param name="RmGuid">
		/// <para>
		/// A pointer to a GUID that KTM will use to identify the resource manager. If this pointer is <c>NULL</c>, KTM generates a GUID.
		/// </para>
		/// </param>
		/// <param name="ObjectAttributes">
		/// <para>
		/// A pointer to an OBJECT_ATTRIBUTES structure that specifies the object name and other attributes. Use the
		/// InitializeObjectAttributes routine to initialize this structure. If the caller is not running in a system thread context, it
		/// must set the OBJ_KERNEL_HANDLE attribute when it calls <c>InitializeObjectAttributes</c>. This parameter is optional and can be <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="CreateOptions">
		/// <para>Optional object creation flags. The following table contains the available flags, which are defined in Ktmtypes.h.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>CreateOptions flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>RESOURCE_MANAGER_COMMUNICATION</term>
		/// <term>For internal use only.</term>
		/// </item>
		/// <item>
		/// <term>RESOURCE_MANAGER_VOLATILE</term>
		/// <term>The caller will manage volatile resources. It will be non-persistent and will not perform recovery.</term>
		/// </item>
		/// </list>
		/// <para>This parameter is optional and can be zero.</para>
		/// </param>
		/// <param name="Description">
		/// <para>
		/// A pointer to a caller-supplied UNICODE_STRING structure that contains a NULL-terminated string. The string provides a
		/// description of the resource manager. KTM stores a copy of the string and includes the string in messages that it writes to the
		/// log stream. The maximum string length is MAX_RESOURCEMANAGER_DESCRIPTION_LENGTH. This parameter is optional and can be <c>NULL</c>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>
		/// <c>ZwCreateResourceManager</c> returns STATUS_SUCCESS if the operation succeeds. Otherwise, this routine might return one of the
		/// following values:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>STATUS_OBJECT_TYPE_MISMATCH</term>
		/// <term>The handle that TmHandle specifies is not a handle to a transaction object.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_INVALID_HANDLE</term>
		/// <term>The handle that TmHandle specifies is invalid.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_ACCESS_DENIED</term>
		/// <term>The caller does not have appropriate access to the specified transaction manager object.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_TRANSACTION_OBJECT_EXPIRED</term>
		/// <term>The handle that TmHandle specifies is closed.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_INVALID_PARAMETER</term>
		/// <term>The CreateOptions parameter's value is invalid or the Description parameter's string is too long.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_TM_VOLATILE</term>
		/// <term>
		/// The CreateOptions parameter does not specify RESOURCE_MANAGER_VOLATILE but the transaction manager that TmHandle specifies is volatile.
		/// </term>
		/// </item>
		/// <item>
		/// <term>STATUS_OBJECT_NAME_COLLISION</term>
		/// <term>The GUID that ResourceManagerGuid specifies already exists.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_ACCESS_DENIED</term>
		/// <term>The value of the DesiredAccess parameter is invalid.</term>
		/// </item>
		/// </list>
		/// <para>The routine might return other NTSTATUS values.</para>
		/// </returns>
		/// <remarks>
		/// <para>A resource manager that calls <c>ZwCreateResourceManager</c> must eventually call ZwClose to close the object handle.</para>
		/// <para>For more information about <c>ZwCreateResourceManager</c>, see Creating a Resource Manager.</para>
		/// <para>
		/// For calls from kernel-mode drivers, the <c>NtXxx</c> and <c>ZwXxx</c> versions of a Windows Native System Services routine can
		/// behave differently in the way that they handle and interpret input parameters. For more information about the relationship
		/// between the <c>NtXxx</c> and <c>ZwXxx</c> versions of a routine, see Using Nt and Zw Versions of the Native System Services Routines.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/content/wdm/nf-wdm-ntcreateresourcemanager __kernel_entry
		// NTSYSCALLAPI NTSTATUS NtCreateResourceManager( PHANDLE ResourceManagerHandle, ACCESS_MASK DesiredAccess, HANDLE TmHandle, LPGUID
		// RmGuid, POBJECT_ATTRIBUTES ObjectAttributes, ULONG CreateOptions, PUNICODE_STRING Description );
		[DllImport(Lib.NtDll, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wdm.h", MSDNShortId = "4812eeb4-134f-4ecb-870b-dbab04c1137b")]
		public static extern NTStatus NtCreateResourceManager(out SafeResourceManagerHandle ResourceManagerHandle, ACCESS_MASK DesiredAccess, SafeTransactionManagerHandle TmHandle, in Guid RmGuid,
			in OBJECT_ATTRIBUTES ObjectAttributes, [Optional] uint CreateOptions, [In, Optional, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UnicodeStringMarshaler))] string Description);

		/// <summary>
		/// <para>The <c>ZwCreateResourceManager</c> routine creates a resource manager object.</para>
		/// </summary>
		/// <param name="ResourceManagerHandle">
		/// <para>
		/// A pointer to a caller-allocated variable that receives a handle to the new resource manager object if the call to
		/// <c>ZwCreateResourceManager</c> is successful.
		/// </para>
		/// </param>
		/// <param name="DesiredAccess">
		/// <para>
		/// An ACCESS_MASK value that specifies the caller's requested access to the resource manager object. In addition to the access
		/// rights that are defined for all kinds of objects (see <c>ACCESS_MASK</c>), the caller can specify any of the following access
		/// right flags for resource manager objects:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>ACCESS_MASK flag</term>
		/// <term>Allows the caller to</term>
		/// </listheader>
		/// <item>
		/// <term>RESOURCEMANAGER_ENLIST</term>
		/// <term>Enlist in transactions (see ZwCreateEnlistment).</term>
		/// </item>
		/// <item>
		/// <term>RESOURCEMANAGER_GET_NOTIFICATION</term>
		/// <term>Receive notifications about the transactions that are associated with this resource manager (see ZwGetNotificationResourceManager).</term>
		/// </item>
		/// <item>
		/// <term>RESOURCEMANAGER_REGISTER_PROTOCOL</term>
		/// <term>Not used.</term>
		/// </item>
		/// <item>
		/// <term>RESOURCEMANAGER_QUERY_INFORMATION</term>
		/// <term>Query information about the resource manager (see ZwQueryInformationResourceManager).</term>
		/// </item>
		/// <item>
		/// <term>RESOURCEMANAGER_SET_INFORMATION</term>
		/// <term>Not used.</term>
		/// </item>
		/// <item>
		/// <term>RESOURCEMANAGER_RECOVER</term>
		/// <term>Recover the resource manager (see ZwRecoverResourceManager).</term>
		/// </item>
		/// <item>
		/// <term>RESOURCEMANAGER_COMPLETE_PROPAGATION</term>
		/// <term>Not used.</term>
		/// </item>
		/// </list>
		/// <para>
		/// Alternatively, you can specify one or more of the following generic ACCESS_MASK flags. (The STANDARD_RIGHTS_Xxx flags are
		/// predefined system values that are used to enforce security on system objects.) You can also combine these generic flags with
		/// additional flags from the preceding table. The following table shows how generic access rights correspond to specific access rights.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Generic access right</term>
		/// <term>Set of specific access rights</term>
		/// </listheader>
		/// <item>
		/// <term>RESOURCEMANAGER_GENERIC_READ</term>
		/// <term>STANDARD_RIGHTS_READ, RESOURCEMANAGER_QUERY_INFORMATION, and SYNCHRONIZE</term>
		/// </item>
		/// <item>
		/// <term>RESOURCEMANAGER_GENERIC_WRITE</term>
		/// <term>
		/// STANDARD_RIGHTS_WRITE, RESOURCEMANAGER_SET_INFORMATION, RESOURCEMANAGER_RECOVER, RESOURCEMANAGER_ENLIST,
		/// RESOURCEMANAGER_GET_NOTIFICATION, RESOURCEMANAGER_REGISTER_PROTOCOL, RESOURCEMANAGER_COMPLETE_PROPAGATION, and SYNCHRONIZE
		/// </term>
		/// </item>
		/// <item>
		/// <term>RESOURCEMANAGER_GENERIC_EXECUTE</term>
		/// <term>
		/// STANDARD_RIGHTS_EXECUTE, RESOURCEMANAGER_RECOVER, RESOURCEMANAGER_ENLIST, RESOURCEMANAGER_GET_NOTIFICATION,
		/// RESOURCEMANAGER_COMPLETE_PROPAGATION, and SYNCHRONIZE
		/// </term>
		/// </item>
		/// <item>
		/// <term>RESOURCEMANAGER_ALL_ACCESS</term>
		/// <term>STANDARD_RIGHTS_REQUIRED, RESOURCEMANAGER_GENERIC_READ, RESOURCEMANAGER_GENERIC_WRITE, and RESOURCEMANAGER_GENERIC_EXECUTE</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="TmHandle">
		/// <para>A handle to a transaction manager object that was obtained by a previous all to ZwCreateTransactionManager or ZwOpenTransactionManager.</para>
		/// </param>
		/// <param name="RmGuid">
		/// <para>
		/// A pointer to a GUID that KTM will use to identify the resource manager. If this pointer is <c>NULL</c>, KTM generates a GUID.
		/// </para>
		/// </param>
		/// <param name="ObjectAttributes">
		/// <para>
		/// A pointer to an OBJECT_ATTRIBUTES structure that specifies the object name and other attributes. Use the
		/// InitializeObjectAttributes routine to initialize this structure. If the caller is not running in a system thread context, it
		/// must set the OBJ_KERNEL_HANDLE attribute when it calls <c>InitializeObjectAttributes</c>. This parameter is optional and can be <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="CreateOptions">
		/// <para>Optional object creation flags. The following table contains the available flags, which are defined in Ktmtypes.h.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>CreateOptions flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>RESOURCE_MANAGER_COMMUNICATION</term>
		/// <term>For internal use only.</term>
		/// </item>
		/// <item>
		/// <term>RESOURCE_MANAGER_VOLATILE</term>
		/// <term>The caller will manage volatile resources. It will be non-persistent and will not perform recovery.</term>
		/// </item>
		/// </list>
		/// <para>This parameter is optional and can be zero.</para>
		/// </param>
		/// <param name="Description">
		/// <para>
		/// A pointer to a caller-supplied UNICODE_STRING structure that contains a NULL-terminated string. The string provides a
		/// description of the resource manager. KTM stores a copy of the string and includes the string in messages that it writes to the
		/// log stream. The maximum string length is MAX_RESOURCEMANAGER_DESCRIPTION_LENGTH. This parameter is optional and can be <c>NULL</c>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>
		/// <c>ZwCreateResourceManager</c> returns STATUS_SUCCESS if the operation succeeds. Otherwise, this routine might return one of the
		/// following values:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>STATUS_OBJECT_TYPE_MISMATCH</term>
		/// <term>The handle that TmHandle specifies is not a handle to a transaction object.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_INVALID_HANDLE</term>
		/// <term>The handle that TmHandle specifies is invalid.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_ACCESS_DENIED</term>
		/// <term>The caller does not have appropriate access to the specified transaction manager object.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_TRANSACTION_OBJECT_EXPIRED</term>
		/// <term>The handle that TmHandle specifies is closed.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_INVALID_PARAMETER</term>
		/// <term>The CreateOptions parameter's value is invalid or the Description parameter's string is too long.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_TM_VOLATILE</term>
		/// <term>
		/// The CreateOptions parameter does not specify RESOURCE_MANAGER_VOLATILE but the transaction manager that TmHandle specifies is volatile.
		/// </term>
		/// </item>
		/// <item>
		/// <term>STATUS_OBJECT_NAME_COLLISION</term>
		/// <term>The GUID that ResourceManagerGuid specifies already exists.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_ACCESS_DENIED</term>
		/// <term>The value of the DesiredAccess parameter is invalid.</term>
		/// </item>
		/// </list>
		/// <para>The routine might return other NTSTATUS values.</para>
		/// </returns>
		/// <remarks>
		/// <para>A resource manager that calls <c>ZwCreateResourceManager</c> must eventually call ZwClose to close the object handle.</para>
		/// <para>For more information about <c>ZwCreateResourceManager</c>, see Creating a Resource Manager.</para>
		/// <para>
		/// For calls from kernel-mode drivers, the <c>NtXxx</c> and <c>ZwXxx</c> versions of a Windows Native System Services routine can
		/// behave differently in the way that they handle and interpret input parameters. For more information about the relationship
		/// between the <c>NtXxx</c> and <c>ZwXxx</c> versions of a routine, see Using Nt and Zw Versions of the Native System Services Routines.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/content/wdm/nf-wdm-ntcreateresourcemanager __kernel_entry
		// NTSYSCALLAPI NTSTATUS NtCreateResourceManager( PHANDLE ResourceManagerHandle, ACCESS_MASK DesiredAccess, HANDLE TmHandle, LPGUID
		// RmGuid, POBJECT_ATTRIBUTES ObjectAttributes, ULONG CreateOptions, PUNICODE_STRING Description );
		[DllImport(Lib.NtDll, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wdm.h", MSDNShortId = "4812eeb4-134f-4ecb-870b-dbab04c1137b")]
		public static extern NTStatus NtCreateResourceManager(out SafeResourceManagerHandle ResourceManagerHandle, ACCESS_MASK DesiredAccess, SafeTransactionManagerHandle TmHandle, in Guid RmGuid,
			[In, Optional] IntPtr ObjectAttributes, [Optional] uint CreateOptions, [In, Optional, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UnicodeStringMarshaler))] string Description);

		/// <summary>
		/// <para>The <c>ZwCreateTransaction</c> routine creates a transaction object.</para>
		/// </summary>
		/// <param name="TransactionHandle">
		/// <para>
		/// A pointer to a caller-allocated variable that receives a handle to the new transaction object, if the call to
		/// <c>ZwCreateTransaction</c> succeeds.
		/// </para>
		/// </param>
		/// <param name="DesiredAccess">
		/// <para>
		/// An ACCESS_MASK value that specifies the caller's requested access to the transaction object. In addition to the access rights
		/// that are defined for all kinds of objects (see ACCESS_MASK), the caller can specify any of the following flags for transaction objects.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Access mask</term>
		/// <term>Allows the caller to</term>
		/// </listheader>
		/// <item>
		/// <term>TRANSACTION_COMMIT</term>
		/// <term>Commit the transaction (see ZwCommitTransaction).</term>
		/// </item>
		/// <item>
		/// <term>TRANSACTION_ENLIST</term>
		/// <term>Create an enlistment for the transaction (see ZwCreateEnlistment).</term>
		/// </item>
		/// <item>
		/// <term>TRANSACTION_PROPAGATE</term>
		/// <term>Do not use.</term>
		/// </item>
		/// <item>
		/// <term>TRANSACTION_QUERY_INFORMATION</term>
		/// <term>Obtain information about the transaction (see ZwQueryInformationTransaction).</term>
		/// </item>
		/// <item>
		/// <term>TRANSACTION_ROLLBACK</term>
		/// <term>Roll back the transaction (see ZwRollbackTransaction).</term>
		/// </item>
		/// <item>
		/// <term>TRANSACTION_SET_INFORMATION</term>
		/// <term>Set information for the transaction (see ZwSetInformationTransaction).</term>
		/// </item>
		/// </list>
		/// <para>
		/// Alternatively, you can specify one or more of the following ACCESS_MASK bitmaps. These bitmaps combine the flags from the
		/// previous table with the STANDARD_RIGHTS_XXX flags that are described on the ACCESS_MASK reference page. You can also combine
		/// these bitmaps with additional flags from the preceding table. The following table shows how the bitmaps correspond to specific
		/// access rights.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Rights bitmap</term>
		/// <term>Set of specific access rights</term>
		/// </listheader>
		/// <item>
		/// <term>TRANSACTION_GENERIC_READ</term>
		/// <term>STANDARD_RIGHTS_READ, TRANSACTION_QUERY_INFORMATION, and SYNCHRONIZE</term>
		/// </item>
		/// <item>
		/// <term>TRANSACTION_GENERIC_WRITE</term>
		/// <term>
		/// STANDARD_RIGHTS_WRITE, TRANSACTION_SET_INFORMATION, TRANSACTION_COMMIT, TRANSACTION_ENLIST, TRANSACTION_ROLLBACK,
		/// TRANSACTION_PROPAGATE, TRANSACTION_SAVEPOINT, and SYNCHRONIZE
		/// </term>
		/// </item>
		/// <item>
		/// <term>TRANSACTION_GENERIC_EXECUTE</term>
		/// <term>STANDARD_RIGHTS_EXECUTE, TRANSACTION_COMMIT, TRANSACTION_ROLLBACK, and SYNCHRONIZE</term>
		/// </item>
		/// <item>
		/// <term>TRANSACTION_ALL_ACCESS</term>
		/// <term>STANDARD_RIGHTS_REQUIRED, TRANSACTION_GENERIC_READ, TRANSACTION_GENERIC_WRITE, and TRANSACTION_GENERIC_EXECUTE</term>
		/// </item>
		/// <item>
		/// <term>TRANSACTION_RESOURCE_MANAGER_RIGHTS</term>
		/// <term>
		/// STANDARD_RIGHTS_WRITE, TRANSACTION_GENERIC_READ, TRANSACTION_SET_INFORMATION, TRANSACTION_ENLIST, TRANSACTION_ROLLBACK,
		/// TRANSACTION_PROPAGATE, and SYNCHRONIZE
		/// </term>
		/// </item>
		/// </list>
		/// <para>Typically, a resource manager specifies TRANSACTION_RESOURCE_MANAGER_RIGHTS.</para>
		/// <para>The DesiredAccess value cannot be zero.</para>
		/// </param>
		/// <param name="ObjectAttributes">
		/// <para>
		/// A pointer to an OBJECT_ATTRIBUTES structure that specifies the object name and other attributes. Use the
		/// InitializeObjectAttributes routine to initialize this structure. If the caller is not running in a system thread context, it
		/// must set the OBJ_KERNEL_HANDLE attribute when it calls <c>InitializeObjectAttributes</c>. This parameter is optional and can be <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="Uow">
		/// <para>
		/// A pointer to a GUID that KTM uses as the new transaction object's unit of work (UOW) identifier. This parameter is optional and
		/// can be <c>NULL</c>. If this parameter is <c>NULL</c>, KTM generates a GUID and assigns it to the transaction object. For more
		/// information, see the following Remarks section.
		/// </para>
		/// </param>
		/// <param name="TmHandle">
		/// <para>
		/// A handle to a transaction manager object that was obtained by a previous call to ZwCreateTransactionManager or
		/// ZwOpenTransactionManager. KTM assigns the new transaction object to the specified transaction manager object. If this parameter
		/// is <c>NULL</c>, KTM assigns the new transaction object to a transaction manager later, when a resource manager creates an
		/// enlistment for the transaction.
		/// </para>
		/// </param>
		/// <param name="CreateOptions">
		/// <para>Optional object creation flags. The following table contains the available flags, which are defined in Ktmtypes.h.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Option flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TRANSACTION_DO_NOT_PROMOTE</term>
		/// <term>Reserved for future use.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="IsolationLevel">
		/// <para>Reserved for future use. Callers must set this parameter to zero.</para>
		/// </param>
		/// <param name="IsolationFlags">
		/// <para>Reserved for future use. Callers should set this parameter to zero.</para>
		/// </param>
		/// <param name="Timeout">
		/// <para>
		/// A pointer to a time-out value. If the transaction has not been committed by the time specified by this parameter, KTM rolls back
		/// the transaction. The time-out value is expressed in system time units (100-nanosecond intervals), and can specify either an
		/// absolute time or a relative time. If the value pointed to by Timeout is negative, the expiration time is relative to the current
		/// system time. Otherwise, the expiration time is absolute. This pointer is optional and can be <c>NULL</c> if you do not want the
		/// transaction to have a time-out value. If Timeout = <c>NULL</c> or *Timeout = 0, the transaction never times out. (You can also
		/// use ZwSetInformationTransaction to set a time-out value.)
		/// </para>
		/// </param>
		/// <param name="Description">
		/// <para>
		/// A pointer to a caller-supplied UNICODE_STRING structure that contains a NULL-terminated string. The string provides a
		/// description of the transaction. KTM stores a copy of the string and includes the string in messages that it writes to the log
		/// stream. The maximum string length is MAX_TRANSACTION_DESCRIPTION_LENGTH. This parameter is optional and can be <c>NULL</c>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>
		/// <c>ZwCreateTransaction</c> returns STATUS_SUCCESS if the operation succeeds. Otherwise, this routine might return one of the
		/// following values:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>STATUS_INVALID_PARAMETER</term>
		/// <term>
		/// The CreateOptions parameter contains an invalid flag, the DesiredAccess parameter is zero, or the Description parameter's string
		/// is too long.
		/// </term>
		/// </item>
		/// <item>
		/// <term>STATUS_INSUFFICIENT_RESOURCES</term>
		/// <term>KTM could not allocate system resources (typically memory).</term>
		/// </item>
		/// <item>
		/// <term>STATUS_INVALID_ACL</term>
		/// <term>A security descriptor contains an invalid access control list (ACL).</term>
		/// </item>
		/// <item>
		/// <term>STATUS_INVALID_SID</term>
		/// <term>A security descriptor contains an invalid security identifier (SID).</term>
		/// </item>
		/// <item>
		/// <term>STATUS_OBJECT_NAME_EXISTS</term>
		/// <term>The object name that the ObjectAttributes parameter specifies already exists.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_OBJECT_NAME_INVALID</term>
		/// <term>The object name that the ObjectAttributes parameter specifies is invalid.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_ACCESS_DENIED</term>
		/// <term>The value of the DesiredAccess parameter is invalid.</term>
		/// </item>
		/// </list>
		/// <para>The routine might return other NTSTATUS values.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The caller can use the Uow parameter to specify a UOW identifier for the transaction object. If the caller does not specify a
		/// UOW identifier, KTM generates a GUID and assigns it to the transaction object. The caller can later obtain this GUID by calling ZwQueryInformationTransaction.
		/// </para>
		/// <para>
		/// Typically, you should let KTM generate a GUID for the transaction object, unless your component communicates with another TPS
		/// component that has already generated a UOW identifier for the transaction.
		/// </para>
		/// <para>
		/// To close the transaction handle, the component that called <c>ZwCreateTransaction</c> must call ZwClose. If the last transaction
		/// handle closes before any component calls ZwCommitTransaction for the transaction, KTM rolls back the transaction.
		/// </para>
		/// <para>
		/// For more information about how transaction clients should use <c>ZwCreateTransaction</c>, see Creating a Transactional Client.
		/// </para>
		/// <para>
		/// For calls from kernel-mode drivers, the <c>NtXxx</c> and <c>ZwXxx</c> versions of a Windows Native System Services routine can
		/// behave differently in the way that they handle and interpret input parameters. For more information about the relationship
		/// between the <c>NtXxx</c> and <c>ZwXxx</c> versions of a routine, see Using Nt and Zw Versions of the Native System Services Routines.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/content/wdm/nf-wdm-ntcreatetransaction __kernel_entry NTSYSCALLAPI
		// NTSTATUS NtCreateTransaction( PHANDLE TransactionHandle, ACCESS_MASK DesiredAccess, POBJECT_ATTRIBUTES ObjectAttributes, LPGUID
		// Uow, HANDLE TmHandle, ULONG CreateOptions, ULONG IsolationLevel, ULONG IsolationFlags, PLARGE_INTEGER Timeout, PUNICODE_STRING
		// Description );
		[DllImport(Lib.NtDll, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("wdm.h", MSDNShortId = "b4c2dd68-3c1a-46d3-ab9c-be2291ed80f4")]
		public static extern NTStatus NtCreateTransaction(out SafeTransactionHandle TransactionHandle, ACCESS_MASK DesiredAccess, in OBJECT_ATTRIBUTES ObjectAttributes,
			in Guid Uow, SafeTransactionManagerHandle TmHandle, [Optional] uint CreateOptions, [Optional] uint IsolationLevel, [Optional] uint IsolationFlags, in long Timeout,
			[In, Optional, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UnicodeStringMarshaler))] string Description);

		/// <summary>
		/// <para>The <c>ZwCreateTransaction</c> routine creates a transaction object.</para>
		/// </summary>
		/// <param name="TransactionHandle">
		/// <para>
		/// A pointer to a caller-allocated variable that receives a handle to the new transaction object, if the call to
		/// <c>ZwCreateTransaction</c> succeeds.
		/// </para>
		/// </param>
		/// <param name="DesiredAccess">
		/// <para>
		/// An ACCESS_MASK value that specifies the caller's requested access to the transaction object. In addition to the access rights
		/// that are defined for all kinds of objects (see ACCESS_MASK), the caller can specify any of the following flags for transaction objects.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Access mask</term>
		/// <term>Allows the caller to</term>
		/// </listheader>
		/// <item>
		/// <term>TRANSACTION_COMMIT</term>
		/// <term>Commit the transaction (see ZwCommitTransaction).</term>
		/// </item>
		/// <item>
		/// <term>TRANSACTION_ENLIST</term>
		/// <term>Create an enlistment for the transaction (see ZwCreateEnlistment).</term>
		/// </item>
		/// <item>
		/// <term>TRANSACTION_PROPAGATE</term>
		/// <term>Do not use.</term>
		/// </item>
		/// <item>
		/// <term>TRANSACTION_QUERY_INFORMATION</term>
		/// <term>Obtain information about the transaction (see ZwQueryInformationTransaction).</term>
		/// </item>
		/// <item>
		/// <term>TRANSACTION_ROLLBACK</term>
		/// <term>Roll back the transaction (see ZwRollbackTransaction).</term>
		/// </item>
		/// <item>
		/// <term>TRANSACTION_SET_INFORMATION</term>
		/// <term>Set information for the transaction (see ZwSetInformationTransaction).</term>
		/// </item>
		/// </list>
		/// <para>
		/// Alternatively, you can specify one or more of the following ACCESS_MASK bitmaps. These bitmaps combine the flags from the
		/// previous table with the STANDARD_RIGHTS_XXX flags that are described on the ACCESS_MASK reference page. You can also combine
		/// these bitmaps with additional flags from the preceding table. The following table shows how the bitmaps correspond to specific
		/// access rights.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Rights bitmap</term>
		/// <term>Set of specific access rights</term>
		/// </listheader>
		/// <item>
		/// <term>TRANSACTION_GENERIC_READ</term>
		/// <term>STANDARD_RIGHTS_READ, TRANSACTION_QUERY_INFORMATION, and SYNCHRONIZE</term>
		/// </item>
		/// <item>
		/// <term>TRANSACTION_GENERIC_WRITE</term>
		/// <term>
		/// STANDARD_RIGHTS_WRITE, TRANSACTION_SET_INFORMATION, TRANSACTION_COMMIT, TRANSACTION_ENLIST, TRANSACTION_ROLLBACK,
		/// TRANSACTION_PROPAGATE, TRANSACTION_SAVEPOINT, and SYNCHRONIZE
		/// </term>
		/// </item>
		/// <item>
		/// <term>TRANSACTION_GENERIC_EXECUTE</term>
		/// <term>STANDARD_RIGHTS_EXECUTE, TRANSACTION_COMMIT, TRANSACTION_ROLLBACK, and SYNCHRONIZE</term>
		/// </item>
		/// <item>
		/// <term>TRANSACTION_ALL_ACCESS</term>
		/// <term>STANDARD_RIGHTS_REQUIRED, TRANSACTION_GENERIC_READ, TRANSACTION_GENERIC_WRITE, and TRANSACTION_GENERIC_EXECUTE</term>
		/// </item>
		/// <item>
		/// <term>TRANSACTION_RESOURCE_MANAGER_RIGHTS</term>
		/// <term>
		/// STANDARD_RIGHTS_WRITE, TRANSACTION_GENERIC_READ, TRANSACTION_SET_INFORMATION, TRANSACTION_ENLIST, TRANSACTION_ROLLBACK,
		/// TRANSACTION_PROPAGATE, and SYNCHRONIZE
		/// </term>
		/// </item>
		/// </list>
		/// <para>Typically, a resource manager specifies TRANSACTION_RESOURCE_MANAGER_RIGHTS.</para>
		/// <para>The DesiredAccess value cannot be zero.</para>
		/// </param>
		/// <param name="ObjectAttributes">
		/// <para>
		/// A pointer to an OBJECT_ATTRIBUTES structure that specifies the object name and other attributes. Use the
		/// InitializeObjectAttributes routine to initialize this structure. If the caller is not running in a system thread context, it
		/// must set the OBJ_KERNEL_HANDLE attribute when it calls <c>InitializeObjectAttributes</c>. This parameter is optional and can be <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="Uow">
		/// <para>
		/// A pointer to a GUID that KTM uses as the new transaction object's unit of work (UOW) identifier. This parameter is optional and
		/// can be <c>NULL</c>. If this parameter is <c>NULL</c>, KTM generates a GUID and assigns it to the transaction object. For more
		/// information, see the following Remarks section.
		/// </para>
		/// </param>
		/// <param name="TmHandle">
		/// <para>
		/// A handle to a transaction manager object that was obtained by a previous call to ZwCreateTransactionManager or
		/// ZwOpenTransactionManager. KTM assigns the new transaction object to the specified transaction manager object. If this parameter
		/// is <c>NULL</c>, KTM assigns the new transaction object to a transaction manager later, when a resource manager creates an
		/// enlistment for the transaction.
		/// </para>
		/// </param>
		/// <param name="CreateOptions">
		/// <para>Optional object creation flags. The following table contains the available flags, which are defined in Ktmtypes.h.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Option flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TRANSACTION_DO_NOT_PROMOTE</term>
		/// <term>Reserved for future use.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="IsolationLevel">
		/// <para>Reserved for future use. Callers must set this parameter to zero.</para>
		/// </param>
		/// <param name="IsolationFlags">
		/// <para>Reserved for future use. Callers should set this parameter to zero.</para>
		/// </param>
		/// <param name="Timeout">
		/// <para>
		/// A pointer to a time-out value. If the transaction has not been committed by the time specified by this parameter, KTM rolls back
		/// the transaction. The time-out value is expressed in system time units (100-nanosecond intervals), and can specify either an
		/// absolute time or a relative time. If the value pointed to by Timeout is negative, the expiration time is relative to the current
		/// system time. Otherwise, the expiration time is absolute. This pointer is optional and can be <c>NULL</c> if you do not want the
		/// transaction to have a time-out value. If Timeout = <c>NULL</c> or *Timeout = 0, the transaction never times out. (You can also
		/// use ZwSetInformationTransaction to set a time-out value.)
		/// </para>
		/// </param>
		/// <param name="Description">
		/// <para>
		/// A pointer to a caller-supplied UNICODE_STRING structure that contains a NULL-terminated string. The string provides a
		/// description of the transaction. KTM stores a copy of the string and includes the string in messages that it writes to the log
		/// stream. The maximum string length is MAX_TRANSACTION_DESCRIPTION_LENGTH. This parameter is optional and can be <c>NULL</c>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>
		/// <c>ZwCreateTransaction</c> returns STATUS_SUCCESS if the operation succeeds. Otherwise, this routine might return one of the
		/// following values:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>STATUS_INVALID_PARAMETER</term>
		/// <term>
		/// The CreateOptions parameter contains an invalid flag, the DesiredAccess parameter is zero, or the Description parameter's string
		/// is too long.
		/// </term>
		/// </item>
		/// <item>
		/// <term>STATUS_INSUFFICIENT_RESOURCES</term>
		/// <term>KTM could not allocate system resources (typically memory).</term>
		/// </item>
		/// <item>
		/// <term>STATUS_INVALID_ACL</term>
		/// <term>A security descriptor contains an invalid access control list (ACL).</term>
		/// </item>
		/// <item>
		/// <term>STATUS_INVALID_SID</term>
		/// <term>A security descriptor contains an invalid security identifier (SID).</term>
		/// </item>
		/// <item>
		/// <term>STATUS_OBJECT_NAME_EXISTS</term>
		/// <term>The object name that the ObjectAttributes parameter specifies already exists.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_OBJECT_NAME_INVALID</term>
		/// <term>The object name that the ObjectAttributes parameter specifies is invalid.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_ACCESS_DENIED</term>
		/// <term>The value of the DesiredAccess parameter is invalid.</term>
		/// </item>
		/// </list>
		/// <para>The routine might return other NTSTATUS values.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The caller can use the Uow parameter to specify a UOW identifier for the transaction object. If the caller does not specify a
		/// UOW identifier, KTM generates a GUID and assigns it to the transaction object. The caller can later obtain this GUID by calling ZwQueryInformationTransaction.
		/// </para>
		/// <para>
		/// Typically, you should let KTM generate a GUID for the transaction object, unless your component communicates with another TPS
		/// component that has already generated a UOW identifier for the transaction.
		/// </para>
		/// <para>
		/// To close the transaction handle, the component that called <c>ZwCreateTransaction</c> must call ZwClose. If the last transaction
		/// handle closes before any component calls ZwCommitTransaction for the transaction, KTM rolls back the transaction.
		/// </para>
		/// <para>
		/// For more information about how transaction clients should use <c>ZwCreateTransaction</c>, see Creating a Transactional Client.
		/// </para>
		/// <para>
		/// For calls from kernel-mode drivers, the <c>NtXxx</c> and <c>ZwXxx</c> versions of a Windows Native System Services routine can
		/// behave differently in the way that they handle and interpret input parameters. For more information about the relationship
		/// between the <c>NtXxx</c> and <c>ZwXxx</c> versions of a routine, see Using Nt and Zw Versions of the Native System Services Routines.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/content/wdm/nf-wdm-ntcreatetransaction __kernel_entry NTSYSCALLAPI
		// NTSTATUS NtCreateTransaction( PHANDLE TransactionHandle, ACCESS_MASK DesiredAccess, POBJECT_ATTRIBUTES ObjectAttributes, LPGUID
		// Uow, HANDLE TmHandle, ULONG CreateOptions, ULONG IsolationLevel, ULONG IsolationFlags, PLARGE_INTEGER Timeout, PUNICODE_STRING
		// Description );
		[DllImport(Lib.NtDll, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("wdm.h", MSDNShortId = "b4c2dd68-3c1a-46d3-ab9c-be2291ed80f4")]
		public static extern NTStatus NtCreateTransaction(out SafeTransactionHandle TransactionHandle, ACCESS_MASK DesiredAccess, [In, Optional] IntPtr ObjectAttributes,
			[In, Optional] IntPtr Uow, [In, Optional] IntPtr TmHandle, [Optional] uint CreateOptions, [Optional] uint IsolationLevel,
			[Optional] uint IsolationFlags, [In, Optional] IntPtr Timeout, [In, Optional, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UnicodeStringMarshaler))] string Description);

		/// <summary>
		/// <para>The <c>ZwCreateTransactionManager</c> routine creates a new transaction manager object.</para>
		/// </summary>
		/// <param name="TmHandle">
		/// <para>A pointer to a caller-allocated variable that receives a handle to the new transaction manager object.</para>
		/// </param>
		/// <param name="DesiredAccess">
		/// <para>
		/// An ACCESS_MASK value that specifies the caller's requested access to the transaction manager object. In addition to the access
		/// rights that are defined for all kinds of objects (see ACCESS_MASK), the caller can specify any of the following access right
		/// flags for transaction manager objects.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>ACCESS_MASK flag</term>
		/// <term>Allows the caller to</term>
		/// </listheader>
		/// <item>
		/// <term>TRANSACTIONMANAGER_CREATE_RM</term>
		/// <term>Create a resource manager (see ZwCreateResourceManager).</term>
		/// </item>
		/// <item>
		/// <term>TRANSACTIONMANAGER_QUERY_INFORMATION</term>
		/// <term>
		/// Obtain information about the transaction manager (see ZwQueryInformationTransactionManager and ZwEnumerateTransactionObject).
		/// Also required for ZwOpenResourceManager, ZwCreateTransaction, and ZwOpenTransaction.)
		/// </term>
		/// </item>
		/// <item>
		/// <term>TRANSACTIONMANAGER_RECOVER</term>
		/// <term>Recover the transaction manager (see ZwRecoverTransactionManager and ZwRollforwardTransactionManager).</term>
		/// </item>
		/// <item>
		/// <term>TRANSACTIONMANAGER_RENAME</term>
		/// <term>Not used.</term>
		/// </item>
		/// <item>
		/// <term>TRANSACTIONMANAGER_SET_INFORMATION</term>
		/// <term>Not used.</term>
		/// </item>
		/// </list>
		/// <para>
		/// Alternatively, you can specify one or more of the following ACCESS_MASK bitmaps. These bitmaps combine the flags from the
		/// previous table with the STANDARD_RIGHTS_XXX flags that are described on the <c>ACCESS_MASK</c> reference page. You can also
		/// combine these bitmaps with additional flags from the preceding table. The following table shows how the bitmaps correspond to
		/// specific access rights.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Rights bitmap</term>
		/// <term>Set of specific access rights</term>
		/// </listheader>
		/// <item>
		/// <term>TRANSACTIONMANAGER_GENERIC_READ</term>
		/// <term>STANDARD_RIGHTS_READ and TRANSACTIONMANAGER_QUERY_INFORMATION</term>
		/// </item>
		/// <item>
		/// <term>TRANSACTIONMANAGER_GENERIC_WRITE</term>
		/// <term>
		/// STANDARD_RIGHTS_WRITE, TRANSACTIONMANAGER_SET_INFORMATION, TRANSACTIONMANAGER_RECOVER, TRANSACTIONMANAGER_RENAME, and TRANSACTIONMANAGER_CREATE_RM
		/// </term>
		/// </item>
		/// <item>
		/// <term>TRANSACTIONMANAGER_GENERIC_EXECUTE</term>
		/// <term>STANDARD_RIGHTS_EXECUTE</term>
		/// </item>
		/// <item>
		/// <term>TRANSACTIONMANAGER_ALL_ACCESS</term>
		/// <term>STANDARD_RIGHTS_REQUIRED, TRANSACTIONMANAGER_GENERIC_READ, TRANSACTIONMANAGER_GENERIC_WRITE, and TRANSACTIONMANAGER_GENERIC_EXECUTE</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="ObjectAttributes">
		/// <para>
		/// A pointer to an OBJECT_ATTRIBUTES structure that specifies the object name and other attributes. Use the
		/// InitializeObjectAttributes routine to initialize this structure. If the caller is not running in a system thread context, it
		/// must set the OBJ_KERNEL_HANDLE attribute when it calls <c>InitializeObjectAttributes</c>. This parameter is optional and can be <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="LogFileName">
		/// <para>
		/// A pointer to a UNICODE_STRING structure that contains the path and file name of a CLFS log file stream to be associated with the
		/// transaction manager object. This parameter must be <c>NULL</c> if the CreateOptions parameter is TRANSACTION_MANAGER_VOLATILE.
		/// Otherwise, this parameter must be non- <c>NULL</c>. For more information, see the following Remarks section.
		/// </para>
		/// </param>
		/// <param name="CreateOptions">
		/// <para>Optional object creation flags. The following table contains the available flags, which are defined in Ktmtypes.h.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Option flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TRANSACTION_MANAGER_VOLATILE</term>
		/// <term>The transaction manager object will be volatile. Therefore, it will not use a log file.</term>
		/// </item>
		/// <item>
		/// <term>TRANSACTION_MANAGER_COMMIT_DEFAULT</term>
		/// <term>For internal use only.</term>
		/// </item>
		/// <item>
		/// <term>TRANSACTION_MANAGER_COMMIT_SYSTEM_VOLUME</term>
		/// <term>For internal use only.</term>
		/// </item>
		/// <item>
		/// <term>TRANSACTION_MANAGER_COMMIT_SYSTEM_HIVES</term>
		/// <term>For internal use only.</term>
		/// </item>
		/// <item>
		/// <term>TRANSACTION_MANAGER_COMMIT_LOWEST</term>
		/// <term>For internal use only.</term>
		/// </item>
		/// <item>
		/// <term>TRANSACTION_MANAGER_CORRUPT_FOR_RECOVERY</term>
		/// <term>For internal use only.</term>
		/// </item>
		/// <item>
		/// <term>TRANSACTION_MANAGER_CORRUPT_FOR_PROGRESS</term>
		/// <term>For internal use only.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="CommitStrength">
		/// <para>Reserved for future use. This parameter must be zero.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// <c>ZwCreateTransactionManager</c> returns STATUS_SUCCESS if the operation succeeds. Otherwise, this routine might return one of
		/// the following values:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>STATUS_INVALID_PARAMETER</term>
		/// <term>The value of an input parameter is invalid.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_INSUFFICIENT_RESOURCES</term>
		/// <term>KTM could not allocate system resources (typically memory).</term>
		/// </item>
		/// <item>
		/// <term>STATUS_LOG_CORRUPTION_DETECTED</term>
		/// <term>KTM encountered an error while creating or opening the log file.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_INVALID_ACL</term>
		/// <term>A security descriptor contains an invalid access control list (ACL).</term>
		/// </item>
		/// <item>
		/// <term>STATUS_INVALID_SID</term>
		/// <term>A security descriptor contains an invalid security identifier (SID).</term>
		/// </item>
		/// <item>
		/// <term>STATUS_OBJECT_NAME_EXISTS</term>
		/// <term>The object name that the ObjectAttributes parameter specifies already exists.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_OBJECT_NAME_COLLISION</term>
		/// <term>The operating system detected a duplicate object name. The error might indicate that the log stream is already being used.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_OBJECT_NAME_INVALID</term>
		/// <term>The object name that the ObjectAttributes parameter specifies is invalid.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_ACCESS_DENIED</term>
		/// <term>The value of the DesiredAccess parameter is invalid.</term>
		/// </item>
		/// </list>
		/// <para>The routine might return other NTSTATUS values.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If the log file stream that the LogFileName parameter specifies does not exist, KTM calls CLFS to create the stream. If the
		/// stream already exists, KTM calls CLFS to open the stream.
		/// </para>
		/// <para>Your TPS component must call ZwRecoverTransactionManager after it has called <c>ZwCreateTransactionManager</c></para>
		/// <para>
		/// If your TPS component specifies the TRANSACTION_MANAGER_VOLATILE flag in the CreateOptions parameter, all resource managers that
		/// are associated with the transaction manager object must specify the RESOURCE_MANAGER_VOLATILE flag when they call ZwCreateResourceManager.
		/// </para>
		/// <para>A TPS component that calls <c>ZwCreateTransactionManager</c> must eventually call ZwClose to close the object handle.</para>
		/// <para>For more information about how use <c>ZwCreateTransactionManager</c>, see Creating a Resource Manager.</para>
		/// <para>
		/// <c>NtCreateTransactionManager</c> and <c>ZwCreateTransactionManager</c> are two versions of the same Windows Native System
		/// Services routine.
		/// </para>
		/// <para>
		/// For calls from kernel-mode drivers, the <c>NtXxx</c> and <c>ZwXxx</c> versions of a Windows Native System Services routine can
		/// behave differently in the way that they handle and interpret input parameters. For more information about the relationship
		/// between the <c>NtXxx</c> and <c>ZwXxx</c> versions of a routine, see Using Nt and Zw Versions of the Native System Services Routines.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/content/wdm/nf-wdm-ntcreatetransactionmanager __kernel_entry
		// NTSYSCALLAPI NTSTATUS NtCreateTransactionManager( PHANDLE TmHandle, ACCESS_MASK DesiredAccess, POBJECT_ATTRIBUTES
		// ObjectAttributes, PUNICODE_STRING LogFileName, ULONG CreateOptions, ULONG CommitStrength );
		[DllImport(Lib.NtDll, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("wdm.h", MSDNShortId = "9c9f0a8b-7add-4ab1-835d-39f508ce32a9")]
		public static extern NTStatus NtCreateTransactionManager(out SafeTransactionManagerHandle TmHandle, ACCESS_MASK DesiredAccess, in OBJECT_ATTRIBUTES ObjectAttributes,
			[In, Optional, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UnicodeStringMarshaler))] string LogFileName, [Optional] uint CreateOptions, [Optional] uint CommitStrength);

		/// <summary>
		/// <para>The <c>ZwCreateTransactionManager</c> routine creates a new transaction manager object.</para>
		/// </summary>
		/// <param name="TmHandle">
		/// <para>A pointer to a caller-allocated variable that receives a handle to the new transaction manager object.</para>
		/// </param>
		/// <param name="DesiredAccess">
		/// <para>
		/// An ACCESS_MASK value that specifies the caller's requested access to the transaction manager object. In addition to the access
		/// rights that are defined for all kinds of objects (see ACCESS_MASK), the caller can specify any of the following access right
		/// flags for transaction manager objects.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>ACCESS_MASK flag</term>
		/// <term>Allows the caller to</term>
		/// </listheader>
		/// <item>
		/// <term>TRANSACTIONMANAGER_CREATE_RM</term>
		/// <term>Create a resource manager (see ZwCreateResourceManager).</term>
		/// </item>
		/// <item>
		/// <term>TRANSACTIONMANAGER_QUERY_INFORMATION</term>
		/// <term>
		/// Obtain information about the transaction manager (see ZwQueryInformationTransactionManager and ZwEnumerateTransactionObject).
		/// Also required for ZwOpenResourceManager, ZwCreateTransaction, and ZwOpenTransaction.)
		/// </term>
		/// </item>
		/// <item>
		/// <term>TRANSACTIONMANAGER_RECOVER</term>
		/// <term>Recover the transaction manager (see ZwRecoverTransactionManager and ZwRollforwardTransactionManager).</term>
		/// </item>
		/// <item>
		/// <term>TRANSACTIONMANAGER_RENAME</term>
		/// <term>Not used.</term>
		/// </item>
		/// <item>
		/// <term>TRANSACTIONMANAGER_SET_INFORMATION</term>
		/// <term>Not used.</term>
		/// </item>
		/// </list>
		/// <para>
		/// Alternatively, you can specify one or more of the following ACCESS_MASK bitmaps. These bitmaps combine the flags from the
		/// previous table with the STANDARD_RIGHTS_XXX flags that are described on the <c>ACCESS_MASK</c> reference page. You can also
		/// combine these bitmaps with additional flags from the preceding table. The following table shows how the bitmaps correspond to
		/// specific access rights.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Rights bitmap</term>
		/// <term>Set of specific access rights</term>
		/// </listheader>
		/// <item>
		/// <term>TRANSACTIONMANAGER_GENERIC_READ</term>
		/// <term>STANDARD_RIGHTS_READ and TRANSACTIONMANAGER_QUERY_INFORMATION</term>
		/// </item>
		/// <item>
		/// <term>TRANSACTIONMANAGER_GENERIC_WRITE</term>
		/// <term>
		/// STANDARD_RIGHTS_WRITE, TRANSACTIONMANAGER_SET_INFORMATION, TRANSACTIONMANAGER_RECOVER, TRANSACTIONMANAGER_RENAME, and TRANSACTIONMANAGER_CREATE_RM
		/// </term>
		/// </item>
		/// <item>
		/// <term>TRANSACTIONMANAGER_GENERIC_EXECUTE</term>
		/// <term>STANDARD_RIGHTS_EXECUTE</term>
		/// </item>
		/// <item>
		/// <term>TRANSACTIONMANAGER_ALL_ACCESS</term>
		/// <term>STANDARD_RIGHTS_REQUIRED, TRANSACTIONMANAGER_GENERIC_READ, TRANSACTIONMANAGER_GENERIC_WRITE, and TRANSACTIONMANAGER_GENERIC_EXECUTE</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="ObjectAttributes">
		/// <para>
		/// A pointer to an OBJECT_ATTRIBUTES structure that specifies the object name and other attributes. Use the
		/// InitializeObjectAttributes routine to initialize this structure. If the caller is not running in a system thread context, it
		/// must set the OBJ_KERNEL_HANDLE attribute when it calls <c>InitializeObjectAttributes</c>. This parameter is optional and can be <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="LogFileName">
		/// <para>
		/// A pointer to a UNICODE_STRING structure that contains the path and file name of a CLFS log file stream to be associated with the
		/// transaction manager object. This parameter must be <c>NULL</c> if the CreateOptions parameter is TRANSACTION_MANAGER_VOLATILE.
		/// Otherwise, this parameter must be non- <c>NULL</c>. For more information, see the following Remarks section.
		/// </para>
		/// </param>
		/// <param name="CreateOptions">
		/// <para>Optional object creation flags. The following table contains the available flags, which are defined in Ktmtypes.h.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Option flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TRANSACTION_MANAGER_VOLATILE</term>
		/// <term>The transaction manager object will be volatile. Therefore, it will not use a log file.</term>
		/// </item>
		/// <item>
		/// <term>TRANSACTION_MANAGER_COMMIT_DEFAULT</term>
		/// <term>For internal use only.</term>
		/// </item>
		/// <item>
		/// <term>TRANSACTION_MANAGER_COMMIT_SYSTEM_VOLUME</term>
		/// <term>For internal use only.</term>
		/// </item>
		/// <item>
		/// <term>TRANSACTION_MANAGER_COMMIT_SYSTEM_HIVES</term>
		/// <term>For internal use only.</term>
		/// </item>
		/// <item>
		/// <term>TRANSACTION_MANAGER_COMMIT_LOWEST</term>
		/// <term>For internal use only.</term>
		/// </item>
		/// <item>
		/// <term>TRANSACTION_MANAGER_CORRUPT_FOR_RECOVERY</term>
		/// <term>For internal use only.</term>
		/// </item>
		/// <item>
		/// <term>TRANSACTION_MANAGER_CORRUPT_FOR_PROGRESS</term>
		/// <term>For internal use only.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="CommitStrength">
		/// <para>Reserved for future use. This parameter must be zero.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// <c>ZwCreateTransactionManager</c> returns STATUS_SUCCESS if the operation succeeds. Otherwise, this routine might return one of
		/// the following values:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>STATUS_INVALID_PARAMETER</term>
		/// <term>The value of an input parameter is invalid.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_INSUFFICIENT_RESOURCES</term>
		/// <term>KTM could not allocate system resources (typically memory).</term>
		/// </item>
		/// <item>
		/// <term>STATUS_LOG_CORRUPTION_DETECTED</term>
		/// <term>KTM encountered an error while creating or opening the log file.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_INVALID_ACL</term>
		/// <term>A security descriptor contains an invalid access control list (ACL).</term>
		/// </item>
		/// <item>
		/// <term>STATUS_INVALID_SID</term>
		/// <term>A security descriptor contains an invalid security identifier (SID).</term>
		/// </item>
		/// <item>
		/// <term>STATUS_OBJECT_NAME_EXISTS</term>
		/// <term>The object name that the ObjectAttributes parameter specifies already exists.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_OBJECT_NAME_COLLISION</term>
		/// <term>The operating system detected a duplicate object name. The error might indicate that the log stream is already being used.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_OBJECT_NAME_INVALID</term>
		/// <term>The object name that the ObjectAttributes parameter specifies is invalid.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_ACCESS_DENIED</term>
		/// <term>The value of the DesiredAccess parameter is invalid.</term>
		/// </item>
		/// </list>
		/// <para>The routine might return other NTSTATUS values.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If the log file stream that the LogFileName parameter specifies does not exist, KTM calls CLFS to create the stream. If the
		/// stream already exists, KTM calls CLFS to open the stream.
		/// </para>
		/// <para>Your TPS component must call ZwRecoverTransactionManager after it has called <c>ZwCreateTransactionManager</c></para>
		/// <para>
		/// If your TPS component specifies the TRANSACTION_MANAGER_VOLATILE flag in the CreateOptions parameter, all resource managers that
		/// are associated with the transaction manager object must specify the RESOURCE_MANAGER_VOLATILE flag when they call ZwCreateResourceManager.
		/// </para>
		/// <para>A TPS component that calls <c>ZwCreateTransactionManager</c> must eventually call ZwClose to close the object handle.</para>
		/// <para>For more information about how use <c>ZwCreateTransactionManager</c>, see Creating a Resource Manager.</para>
		/// <para>
		/// <c>NtCreateTransactionManager</c> and <c>ZwCreateTransactionManager</c> are two versions of the same Windows Native System
		/// Services routine.
		/// </para>
		/// <para>
		/// For calls from kernel-mode drivers, the <c>NtXxx</c> and <c>ZwXxx</c> versions of a Windows Native System Services routine can
		/// behave differently in the way that they handle and interpret input parameters. For more information about the relationship
		/// between the <c>NtXxx</c> and <c>ZwXxx</c> versions of a routine, see Using Nt and Zw Versions of the Native System Services Routines.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/content/wdm/nf-wdm-ntcreatetransactionmanager __kernel_entry
		// NTSYSCALLAPI NTSTATUS NtCreateTransactionManager( PHANDLE TmHandle, ACCESS_MASK DesiredAccess, POBJECT_ATTRIBUTES
		// ObjectAttributes, PUNICODE_STRING LogFileName, ULONG CreateOptions, ULONG CommitStrength );
		[DllImport(Lib.NtDll, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("wdm.h", MSDNShortId = "9c9f0a8b-7add-4ab1-835d-39f508ce32a9")]
		public static extern NTStatus NtCreateTransactionManager(out SafeTransactionManagerHandle TmHandle, ACCESS_MASK DesiredAccess, [In, Optional] IntPtr ObjectAttributes,
			[In, Optional, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UnicodeStringMarshaler))] string LogFileName, [Optional] uint CreateOptions, [Optional] uint CommitStrength);

		/// <summary>
		/// <para>
		/// The <c>ZwQueryKey</c> routine provides information about the class of a registry key, and the number and sizes of its subkeys.
		/// </para>
		/// </summary>
		/// <param name="KeyHandle">
		/// <para>
		/// Handle to the registry key to obtain information about. This handle is created by a successful call to ZwCreateKey or ZwOpenKey.
		/// </para>
		/// </param>
		/// <param name="KeyInformationClass">
		/// <para>Specifies a KEY_INFORMATION_CLASS value that determines the type of information returned in the KeyInformation buffer.</para>
		/// </param>
		/// <param name="KeyInformation">
		/// <para>Pointer to a caller-allocated buffer that receives the requested information.</para>
		/// </param>
		/// <param name="Length">
		/// <para>Specifies the size, in bytes, of the KeyInformation buffer.</para>
		/// </param>
		/// <param name="ResultLength">
		/// <para>
		/// Pointer to a variable that receives the size, in bytes, of the requested key information. If <c>ZwQueryKey</c> returns
		/// STATUS_SUCCESS, the variable contains the amount of data returned. If <c>ZwQueryKey</c> returns STATUS_BUFFER_OVERFLOW or
		/// STATUS_BUFFER_TOO_SMALL, you can use the value of the variable to determine the required buffer size.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>
		/// <c>ZwQueryKey</c> returns STATUS_SUCCESS on success, or the appropriate error code on failure. Possible error code values include:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>STATUS_BUFFER_OVERFLOW</term>
		/// <term>
		/// The buffer supplied is too small, and only partial data has been written to the buffer. *ResultLength is set to the minimum size
		/// required to hold the requested information.
		/// </term>
		/// </item>
		/// <item>
		/// <term>STATUS_BUFFER_TOO_SMALL</term>
		/// <term>
		/// The buffer supplied is too small, and no data has been written to the buffer. *ResultLength is set to the minimum size required
		/// to hold the requested information.
		/// </term>
		/// </item>
		/// <item>
		/// <term>STATUS_INVALID_PARAMETER</term>
		/// <term>The KeyInformationClass parameter is not a valid KEY_INFORMATION_CLASS value.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The KeyHandle passed to <c>ZwQueryKey</c> must have been opened with KEY_QUERY_VALUE access. This is accomplished by passing
		/// KEY_QUERY_VALUE, KEY_READ, or KEY_ALL_ACCESS as the DesiredAccess parameter to ZwCreateKey or ZwOpenKey.
		/// </para>
		/// <para>
		/// <c>ZwQueryKey</c> can be used to obtain information that you can use to allocate buffers to hold registry data, such as the
		/// maximum size of a key's value entries or subkey names, or the number of subkeys. For example, you can call <c>ZwQueryKey</c>,
		/// use the returned information to allocate a buffer for a subkey, call ZwEnumerateKey to get the name of the subkey, and pass that
		/// name to an <c>Rtl</c><c>Xxx</c><c>Registry</c> routine.
		/// </para>
		/// <para>For more information about working with registry keys, see Using the Registry in a Driver.</para>
		/// <para>
		/// For calls from kernel-mode drivers, the <c>NtXxx</c> and <c>ZwXxx</c> versions of a Windows Native System Services routine can
		/// behave differently in the way that they handle and interpret input parameters. For more information about the relationship
		/// between the <c>NtXxx</c> and <c>ZwXxx</c> versions of a routine, see Using Nt and Zw Versions of the Native System Services Routines.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/content/wdm/nf-wdm-zwquerykey NTSYSAPI NTSTATUS ZwQueryKey( HANDLE
		// KeyHandle, KEY_INFORMATION_CLASS KeyInformationClass, PVOID KeyInformation, ULONG Length, PULONG ResultLength );
		[DllImport(Lib.NtDll, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("wdm.h", MSDNShortId = "3b2d3a8b-a21f-4067-a1f0-9aa66c1973f5")]
		// public static extern NTSYSAPI NTSTATUS ZwQueryKey(IntPtr KeyHandle, KEY_INFORMATION_CLASS KeyInformationClass, IntPtr
		// KeyInformation, uint Length, ref uint ResultLength);
		public static extern NTStatus NtQueryKey(HKEY KeyHandle, KEY_INFORMATION_CLASS KeyInformationClass, [Out] SafeHGlobalHandle KeyInformation, uint Length, out uint ResultLength);

		/// <summary>
		/// <para>
		/// A driver sets an IRP's I/O status block to indicate the final status of an I/O request, before calling IoCompleteRequest for the IRP.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Unless a driver's dispatch routine completes an IRP with an error status value, the lowest-level driver in the chain frequently
		/// sets the IRP's I/O status block to the values that will be returned to the original requester of the I/O operation.
		/// </para>
		/// <para>
		/// The IoCompletion routines of higher-level drivers usually check the I/O status block in IRPs completed by lower drivers. By
		/// design, the I/O status block in an IRP is the only information passed back from the underlying device driver to all higher-level
		/// drivers' IoCompletion routines.
		/// </para>
		/// <para>
		/// The operating system implements support routines that write <c>IO_STATUS_BLOCK</c> values to caller-supplied output buffers. For
		/// example, see ZwOpenFile or NtOpenFile. These routines return status codes that might not match the status codes in the
		/// <c>IO_STATUS_BLOCK</c> structures. If one of these routines returns STATUS_PENDING, the caller should wait for the I/O operation
		/// to complete, and then check the status code in the <c>IO_STATUS_BLOCK</c> structure to determine the final status of the
		/// operation. If the routine returns a status code other than STATUS_PENDING, the caller should rely on this status code instead of
		/// the status code in the <c>IO_STATUS_BLOCK</c> structure.
		/// </para>
		/// <para>For more information, see I/O Status Blocks.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/content/wdm/ns-wdm-_io_status_block typedef struct _IO_STATUS_BLOCK
		// { union { NTSTATUS Status; PVOID Pointer; } DUMMYUNIONNAME; ULONG_PTR Information; } IO_STATUS_BLOCK, *PIO_STATUS_BLOCK;
		[PInvokeData("wdm.h", MSDNShortId = "1ce2b1d0-a8b2-4a05-8895-e13802690a7b")]
		[StructLayout(LayoutKind.Sequential)]
		public struct IO_STATUS_BLOCK
		{
			/// <summary>
			/// This is the completion status, either STATUS_SUCCESS if the requested operation was completed successfully or an
			/// informational, warning, or error STATUS_XXX value. For more information, see Using NTSTATUS values.
			/// </summary>
			public uint Status;

			/// <summary>
			/// This is set to a request-dependent value. For example, on successful completion of a transfer request, this is set to the
			/// number of bytes transferred. If a transfer request is completed with another STATUS_XXX, this member is set to zero.
			/// </summary>
			public IntPtr Information;
		}

		/// <summary>
		/// <para>The <c>KEY_BASIC_INFORMATION</c> structure defines a subset of the full information that is available for a registry key.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The ZwEnumerateKey and ZwQueryKey routines use the <c>KEY_BASIC_INFORMATION</c> structure to contain the basic information for a
		/// registry key. When the KeyInformationClass parameter of either routine is <c>KeyBasicInformation</c>, the KeyInformation buffer
		/// is treated as a <c>KEY_BASIC_INFORMATION</c> structure. For more information about the <c>KeyBasicInformation</c> enumeration
		/// value, see KEY_INFORMATION_CLASS.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/content/wdm/ns-wdm-_key_basic_information typedef struct
		// _KEY_BASIC_INFORMATION { LARGE_INTEGER LastWriteTime; ULONG TitleIndex; ULONG NameLength; WCHAR Name[1]; } KEY_BASIC_INFORMATION, *PKEY_BASIC_INFORMATION;
		[PInvokeData("wdm.h", MSDNShortId = "789c60b6-a5a4-4570-bb0c-acfe1166a302")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct KEY_BASIC_INFORMATION
		{
			/// <summary>
			/// <para>
			/// The last time this key or any of its values changed. This time value is expressed in absolute system time format. Absolute
			/// system time is the number of 100-nanosecond intervals since the start of the year 1601 in the Gregorian calendar.
			/// </para>
			/// </summary>
			public long LastWriteTime;

			/// <summary>
			/// <para>Device and intermediate drivers should ignore this member.</para>
			/// </summary>
			public uint TitleIndex;

			/// <summary>
			/// <para>The size, in bytes, of the key name string in the <c>Name</c> array.</para>
			/// </summary>
			public uint NameLength;

			/// <summary>
			/// <para>
			/// An array of wide characters that contains the name of the registry key. This character string is null-terminated. Only the
			/// first element in this array is included in the <c>KEY_BASIC_INFORMATION</c> structure definition. The storage for the
			/// remaining elements in the array immediately follows this element.
			/// </para>
			/// </summary>
			public StrPtrUni Name;
		}

		/// <summary>
		/// <para>
		/// The <c>KEY_FULL_INFORMATION</c> structure defines the information available for a registry key, including information about its
		/// subkeys and the maximum length for their names and value entries. This information can be used to size buffers to get the names
		/// of subkeys and their value entries.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The ZwEnumerateKey and ZwQueryKey routines use the <c>KEY_FULL_INFORMATION</c> structure to contain the full information for a
		/// registry key. When the KeyInformationClass parameter of either routine is <c>KeyFullInformation</c>, the KeyInformation buffer
		/// is treated as a <c>KEY_FULL_INFORMATION</c> structure. For more information about the <c>KeyFullInformation</c> enumeration
		/// value, see KEY_INFORMATION_CLASS.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/content/wdm/ns-wdm-_key_full_information typedef struct
		// _KEY_FULL_INFORMATION { LARGE_INTEGER LastWriteTime; ULONG TitleIndex; ULONG ClassOffset; ULONG ClassLength; ULONG SubKeys; ULONG
		// MaxNameLen; ULONG MaxClassLen; ULONG Values; ULONG MaxValueNameLen; ULONG MaxValueDataLen; WCHAR Class[1]; }
		// KEY_FULL_INFORMATION, *PKEY_FULL_INFORMATION;
		[PInvokeData("wdm.h", MSDNShortId = "dd099435-e3e3-4d78-a829-0f12f2db46d9")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct KEY_FULL_INFORMATION
		{
			/// <summary>
			/// <para>
			/// The last time this key or any of its values changed. This time value is expressed in absolute system time format. Absolute
			/// system time is the number of 100-nanosecond intervals since the start of the year 1601 in the Gregorian calendar.
			/// </para>
			/// </summary>
			public long LastWriteTime;

			/// <summary>
			/// <para>Device and intermediate drivers should ignore this member.</para>
			/// </summary>
			public uint TitleIndex;

			/// <summary>
			/// <para>The byte offset from the start of this structure to the <c>Class</c> member.</para>
			/// </summary>
			public uint ClassOffset;

			/// <summary>
			/// <para>The size, in bytes, of the key class name string in the <c>Class</c> array.</para>
			/// </summary>
			public uint ClassLength;

			/// <summary>
			/// <para>The number of subkeys for this key.</para>
			/// </summary>
			public uint SubKeys;

			/// <summary>
			/// <para>The maximum size, in bytes, of any name for a subkey.</para>
			/// </summary>
			public uint MaxNameLen;

			/// <summary>
			/// <para>The maximum size, in bytes, of a class name.</para>
			/// </summary>
			public uint MaxClassLen;

			/// <summary>
			/// <para>The number of value entries for this key.</para>
			/// </summary>
			public uint Values;

			/// <summary>
			/// <para>The maximum size, in bytes, of a value entry name.</para>
			/// </summary>
			public uint MaxValueNameLen;

			/// <summary>
			/// <para>The maximum size, in bytes, of a value entry data field.</para>
			/// </summary>
			public uint MaxValueDataLen;

			/// <summary>
			/// <para>
			/// An array of wide characters that contains the name of the class of the key. This character string is null-terminated. Only
			/// the first element in this array is included in the <c>KEY_FULL_INFORMATION</c> structure definition. The storage for the
			/// remaining elements in the array immediately follows this element.
			/// </para>
			/// </summary>
			public StrPtrUni Class;
		}

		/// <summary>
		/// <para>The <c>KEY_NODE_INFORMATION</c> structure defines the basic information available for a registry (sub)key.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The ZwEnumerateKey and ZwQueryKey routines use the <c>KEY_NODE_INFORMATION</c> structure to contain the registry key name and
		/// key class name. When the KeyInformationClass parameter of either routine is <c>KeyNodeInformation</c>, the KeyInformation buffer
		/// is treated as a <c>KEY_NODE_INFORMATION</c> structure. For more information about the <c>KeyNodeInformation</c> enumeration
		/// value, see KEY_INFORMATION_CLASS.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/content/wdm/ns-wdm-_key_node_information typedef struct
		// _KEY_NODE_INFORMATION { LARGE_INTEGER LastWriteTime; ULONG TitleIndex; ULONG ClassOffset; ULONG ClassLength; ULONG NameLength;
		// WCHAR Name[1]; } KEY_NODE_INFORMATION, *PKEY_NODE_INFORMATION;
		[PInvokeData("wdm.h", MSDNShortId = "2eed1a3d-fc40-4416-ad61-d82bf4fb69a1")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct KEY_NODE_INFORMATION
		{
			/// <summary>
			/// <para>
			/// The last time this key or any of its values changed. This time value is expressed in absolute system time format. Absolute
			/// system time is the number of 100-nanosecond intervals since the start of the year 1601 in the Gregorian calendar.
			/// </para>
			/// </summary>
			public long LastWriteTime;

			/// <summary>
			/// <para>Device and intermediate drivers should ignore this member.</para>
			/// </summary>
			public uint TitleIndex;

			/// <summary>
			/// <para>
			/// The byte offset from the start of this structure to the class name string, which is located in the <c>Name</c> array
			/// immediately following the key name string. Like the key name string, the class name string is not null-terminated.
			/// </para>
			/// </summary>
			public uint ClassOffset;

			/// <summary>
			/// <para>The size, in bytes, in the class name string.</para>
			/// </summary>
			public uint ClassLength;

			/// <summary>
			/// <para>The size, in bytes, of the key name string contained in the <c>Name</c> array.</para>
			/// </summary>
			public uint NameLength;

			/// <summary>
			/// <para>
			/// An array of wide characters that contains the name of the registry key. This character string is null-terminated. Only the
			/// first element in this array is included in the <c>KEY_NODE_INFORMATION</c> structure definition. The storage for the
			/// remaining elements in the array immediately follows this element.
			/// </para>
			/// </summary>
			public StrPtrUni Name;
		}
/*
ACCESS_STATE structure
ACL structure
ClfsCreateMarshallingAreaEx function
DIRECTORY_NOTIFY_INFORMATION_CLASS enumeration
DRIVER_DIRECTORY_TYPE enumeration
ExInitializeWorkItem function
ExQueueWorkItem function
FAST_IO_DISPATCH structure
FILE_INFORMATION_CLASS enumeration
FILE_MEMORY_PARTITION_INFORMATION structure
FILE_SFIO_RESERVE_INFORMATION structure
FS_INFORMATION_CLASS enumeration
IoGetTopLevelIrp function
IoRemoveLinkShareAccessEx function
IoSetTopLevelIrp function
LOCK_OPERATION enumeration
LUID_AND_ATTRIBUTES structure
SeCaptureSubjectContext function
SECURITY_IMPERSONATION_LEVEL enumeration
SECURITY_SUBJECT_CONTEXT structure
SeLockSubjectContext function
SeReleaseSubjectContext function
SeUnlockSubjectContext function
VPB structure
WORK_QUEUE_ITEM structure

ASSERTMSG macro
DbgBreakPoint function
DbgBreakPointWithStatus function
DbgPrint function
DbgPrintEx function
EtwActivityIdControl function
ETWENABLECALLBACK callback function
EtwEventEnabled function
EtwProviderEnabled function
EtwRegister function
EtwUnregister function
EtwWrite function
EtwWriteEx function
EtwWriteString function
EtwWriteTransfer function
FAULT_INFORMATION structure
FAULT_INFORMATION_ARCH enumeration
FAULT_INFORMATION_ARM64 structure
FAULT_INFORMATION_ARM64_FLAGS structure
FAULT_INFORMATION_ARM64_TYPE enumeration
KBUGCHECK_CALLBACK_RECORD structure
KBUGCHECK_REASON_CALLBACK_RECORD structure
KBUGCHECK_REMOVE_PAGES structure
KBUGCHECK_SECONDARY_DUMP_DATA_EX structure
KBUGCHECK_TRIAGE_DUMP_DATA structure
KdBreakPointWithStatus macro
KdChangeOption function
KdDisableDebugger function
KdEnableDebugger function
KdPrint macro
KdPrintEx macro
KdRefreshDebuggerNotPresent function
KeInitializeTriageDumpDataArray function
KTRIAGE_DUMP_DATA_ARRAY structure
PCW_CALLBACK callback function
PCW_CALLBACK_INFORMATION union
PCW_CALLBACK_TYPE enumeration
PCW_COUNTER_DESCRIPTOR structure
PCW_COUNTER_INFORMATION structure
PCW_DATA structure
PCW_MASK_INFORMATION structure
PCW_REGISTRATION_INFORMATION structure
PcwAddInstance function
PcwCloseInstance function
PcwCreateInstance function
PcwRegister function
PcwUnregister function
SeEtwWriteKMCveEvent function
vDbgPrintEx function
vDbgPrintExWithPrefix function

DMA_ADAPTER structure
DMA_OPERATIONS structure
_BitTest64 function
_BitTestAndComplement64 function
_BitTestAndReset64 function
_BitTestAndSet64 function
ACPI_INTERFACE_STANDARD2 structure
ALLOCATE_FUNCTION_EX callback function
AppendTailList function
ARM64_SYSREG_CRM macro
ARM64_SYSREG_CRN macro
ARM64_SYSREG_OP1 macro
ARM64_SYSREG_OP2 macro
BOOTDISK_INFORMATION structure
BOOTDISK_INFORMATION_EX structure
BOUND_CALLBACK callback function
BOUND_CALLBACK_STATUS enumeration
BUS_INTERFACE_STANDARD structure
BUS_RESOURCE_UPDATE_INTERFACE structure
CLFS_CONTEXT_MODE enumeration
CLFS_LOG_NAME_INFORMATION structure
CLFS_MGMT_CLIENT_REGISTRATION structure
CLFS_MGMT_POLICY structure
CLFS_MGMT_POLICY_TYPE enumeration
CLFS_STREAM_ID_INFORMATION structure
ClfsAddLogContainer function
ClfsAddLogContainerSet function
ClfsAdvanceLogBase function
ClfsAlignReservedLog function
ClfsAllocReservedLog function
ClfsCloseAndResetLogFile function
ClfsCloseLogFileObject function
ClfsCreateLogFile function
ClfsCreateMarshallingArea function
ClfsCreateScanContext function
ClfsDeleteLogByPointer function
ClfsDeleteLogFile function
ClfsDeleteMarshallingArea function
ClfsFlushBuffers function
ClfsFlushToLsn function
ClfsGetContainerName function
ClfsGetIoStatistics function
ClfsLsnBlockOffset function
ClfsLsnContainer function
ClfsLsnCreate function
ClfsLsnEqual function
ClfsLsnGreater function
ClfsLsnLess function
ClfsLsnNull function
ClfsLsnRecordSequence function
ClfsMgmtDeregisterManagedClient function
ClfsMgmtHandleLogFileFull function
ClfsMgmtInstallPolicy function
ClfsMgmtQueryPolicy function
ClfsMgmtRegisterManagedClient function
ClfsMgmtRemovePolicy function
ClfsMgmtSetLogFileSize function
ClfsMgmtSetLogFileSizeAsClient function
ClfsMgmtTailAdvanceFailure function
ClfsQueryLogFileInformation function
ClfsReadLogRecord function
ClfsReadNextLogRecord function
ClfsReadPreviousRestartArea function
ClfsReadRestartArea function
ClfsRemoveLogContainer function
ClfsRemoveLogContainerSet function
ClfsReserveAndAppendLog function
ClfsReserveAndAppendLogAligned function
ClfsScanLogContainers function
ClfsSetArchiveTail function
ClfsSetEndOfLog function
ClfsSetLogFileInformation function
ClfsTerminateReadLog function
ClfsWriteRestartArea function
CLS_CONTAINER_INFORMATION structure
CLS_INFORMATION structure
CLS_IO_STATISTICS structure
CLS_IO_STATISTICS_HEADER structure
CLS_LOG_INFORMATION_CLASS enumeration
CLS_LSN structure
CLS_SCAN_CONTEXT structure
CLS_WRITE_ENTRY structure
CM_EISA_FUNCTION_INFORMATION structure
CM_EISA_SLOT_INFORMATION structure
CM_FLOPPY_DEVICE_DATA structure
CM_FULL_RESOURCE_DESCRIPTOR structure
CM_INT13_DRIVE_PARAMETER structure
CM_KEYBOARD_DEVICE_DATA structure
CM_MCA_POS_DATA structure
CM_PARTIAL_RESOURCE_DESCRIPTOR structure
CM_PARTIAL_RESOURCE_LIST structure
CM_POWER_DATA structure
CM_RESOURCE_LIST structure
CM_SCSI_DEVICE_DATA structure
CM_SERIAL_DEVICE_DATA structure
CmCallbackGetKeyObjectID function
CmCallbackGetKeyObjectIDEx function
CmCallbackReleaseKeyObjectIDEx function
CmGetBoundTransaction function
CmGetCallbackVersion function
CmRegisterCallback function
CmRegisterCallbackEx function
CmSetCallbackObjectContext function
CmUnRegisterCallback function
COUNTED_REASON_CONTEXT structure
D3COLD_AUX_POWER_AND_TIMING_INTERFACE structure
D3COLD_LAST_TRANSITION_STATUS enumeration
D3COLD_REQUEST_AUX_POWER callback function
D3COLD_REQUEST_CORE_POWER_RAIL callback function
D3COLD_REQUEST_PERST_DELAY callback function
D3COLD_SUPPORT_INTERFACE structure
DEVICE_BUS_SPECIFIC_RESET_INFO structure
DEVICE_BUS_SPECIFIC_RESET_TYPE union
DEVICE_CAPABILITIES structure
DEVICE_DESCRIPTION structure
DEVICE_DIRECTORY_TYPE enumeration
DEVICE_FAULT_CONFIGURATION structure
DEVICE_INSTALL_STATE enumeration
DEVICE_INTERFACE_CHANGE_NOTIFICATION structure
DEVICE_OBJECT structure
DEVICE_POWER_STATE enumeration
DEVICE_REGISTRY_PROPERTY enumeration
DEVICE_REMOVAL_POLICY enumeration
DEVICE_RESET_INTERFACE_STANDARD structure
DEVICE_RESET_TYPE enumeration
DEVICE_USAGE_NOTIFICATION_TYPE enumeration
DEVICE_WAKE_DEPTH enumeration
DMA_ADAPTER_INFO structure
DMA_ADAPTER_INFO_V1 structure
DMA_COMMON_BUFFER_EXTENDED_CONFIGURATION_TYPE enumeration
DMA_COMPLETION_ROUTINE callback function
DMA_COMPLETION_STATUS enumeration
DMA_IOMMU_INTERFACE structure
DMA_IOMMU_INTERFACE_EX structure
DMA_IOMMU_INTERFACE_V1 structure
DMA_IOMMU_INTERFACE_V2 structure
DMA_TRANSFER_INFO structure
DMA_TRANSFER_INFO_V1 structure
DMA_TRANSFER_INFO_V2 structure
DOMAIN_CONFIGURATION structure
DOMAIN_CONFIGURATION_ARCH enumeration
DOMAIN_CONFIGURATION_ARM64 structure
DOMAIN_CONFIGURATION_X64 structure
DRIVER_ADD_DEVICE callback function
DRIVER_CANCEL callback function
DRIVER_CONTROL callback function
DRIVER_DISPATCH callback function
DRIVER_INITIALIZE callback function
DRIVER_LIST_CONTROL callback function
DRIVER_OBJECT structure
DRIVER_REGKEY_TYPE enumeration
DRIVER_STARTIO callback function
DRIVER_UNLOAD callback function
ENLISTMENT_BASIC_INFORMATION structure
ENLISTMENT_INFORMATION_CLASS enumeration
EX_CALLBACK_FUNCTION callback function
EX_POOL_PRIORITY enumeration
ExAcquirePushLockExclusive macro
ExAcquirePushLockShared macro
ExAcquireResourceExclusiveLite function
ExAcquireResourceSharedLite function
ExAcquireRundownProtection function
ExAcquireRundownProtectionEx function
ExAcquireSharedStarveExclusive function
ExAcquireSharedWaitForExclusive function
ExAllocateFromLookasideListEx function
ExAllocateFromNPagedLookasideList function
ExAllocateFromPagedLookasideList function
ExAllocatePool function
ExAllocatePool2 function
ExAllocatePool3 function
ExAllocatePoolPriorityUninitialized function
ExAllocatePoolPriorityZero function
ExAllocatePoolQuotaUninitialized function
ExAllocatePoolQuotaZero function
ExAllocatePoolUninitialized function
ExAllocatePoolWithQuota function
ExAllocatePoolWithQuotaTag function
ExAllocatePoolWithTag function
ExAllocatePoolWithTagPriority function
ExAllocatePoolZero function
ExAllocateTimer function
ExCancelTimer function
ExConvertExclusiveToSharedLite function
ExCreateCallback function
ExCreatePool function
ExDeleteLookasideListEx function
ExDeleteNPagedLookasideList function
ExDeletePagedLookasideList function
ExDeleteResourceLite function
ExDeleteTimer function
ExDestroyPool function
ExFlushLookasideListEx function
ExFreePool function
ExFreePool2 function
ExFreePoolWithTag function
ExFreeToLookasideListEx function
ExFreeToNPagedLookasideList function
ExFreeToPagedLookasideList function
ExGetExclusiveWaiterCount function
ExGetFirmwareEnvironmentVariable function
ExGetFirmwareType function
ExGetPreviousMode function
ExGetSharedWaiterCount function
ExInitializeDeleteTimerParameters function
ExInitializeDeviceAts function
ExInitializeDriverRuntime function
ExInitializeFastMutex function
ExInitializeLookasideListEx function
ExInitializeNPagedLookasideList function
ExInitializePagedLookasideList function
ExInitializePushLock function
ExInitializeResourceLite function
ExInitializeRundownProtection function
ExInitializeSetTimerParameters function
ExInterlockedAddLargeInteger function
ExInterlockedAddLargeStatistic macro
ExInterlockedAddUlong function
ExInterlockedCompareExchange64 macro
ExInterlockedFlushSList function
ExInterlockedInsertHeadList function
ExInterlockedInsertTailList function
ExInterlockedPopEntryList function
ExInterlockedPopEntrySList function
ExInterlockedPushEntryList function
ExInterlockedPushEntrySList function
ExInterlockedRemoveHeadList function
ExIsProcessorFeaturePresent function
ExIsResourceAcquiredExclusiveLite function
ExIsResourceAcquiredSharedLite function
ExIsSoftBoot function
ExLocalTimeToSystemTime function
ExNotifyCallback function
ExQueryDepthSList function
ExQueryTimerResolution function
ExRaiseStatus function
ExRegisterCallback function
ExReinitializeResourceLite function
ExReInitializeRundownProtection function
ExReleasePushLockExclusive macro
ExReleasePushLockShared macro
ExReleaseResourceForThreadLite function
ExReleaseResourceLite function
ExReleaseRundownProtection function
ExReleaseRundownProtectionEx function
ExReleaseSpinLockExclusive function
ExReleaseSpinLockShared function
ExRundownCompleted function
ExSecurePoolUpdate function
ExSecurePoolValidate function
ExSetFirmwareEnvironmentVariable function
ExSetResourceOwnerPointer function
ExSetResourceOwnerPointerEx function
ExSetTimer function
ExSetTimerResolution function
ExSystemTimeToLocalTime function
EXT_CALLBACK callback function
EXT_DELETE_CALLBACK callback function
EXT_DELETE_PARAMETERS structure
EXT_SET_PARAMETERS structure
ExTryConvertSharedSpinLockExclusive function
ExUnregisterCallback function
ExWaitForRundownProtectionRelease function
FIELD_OFFSET macro
FILE_BASIC_INFORMATION structure
FILE_FS_DEVICE_INFORMATION structure
FILE_FULL_EA_INFORMATION structure
FILE_IO_PRIORITY_HINT_INFORMATION structure
FILE_IS_REMOTE_DEVICE_INFORMATION structure
FILE_NETWORK_OPEN_INFORMATION structure
FILE_OBJECT structure
FILE_POSITION_INFORMATION structure
FILE_STANDARD_INFORMATION structure
FILE_STANDARD_INFORMATION_EX structure
FirstEntrySList function
FPGA_BUS_SCAN callback function
FPGA_CONTROL_CONFIG_SPACE callback function
FPGA_CONTROL_ERROR_REPORTING callback function
FPGA_CONTROL_INTERFACE structure
FPGA_CONTROL_LINK callback function
FREE_FUNCTION_EX callback function
FUNCTION_LEVEL_DEVICE_RESET_PARAMETERS structure
GENERIC_MAPPING structure
GET_D3COLD_CAPABILITY callback function
GET_D3COLD_LAST_TRANSITION_STATUS callback function
GET_DMA_ADAPTER callback function
GET_IDLE_WAKE_INFO callback function
GET_SDEV_IDENTIFIER callback function
GET_SET_DEVICE_DATA callback function
GET_UPDATED_BUS_RESOURCE callback function
HWPROFILE_CHANGE_NOTIFICATION structure
IMAGE_POLICY_ENTRY structure
IMAGE_POLICY_ENTRY_TYPE enumeration
IMAGE_POLICY_ID enumeration
IMAGE_POLICY_METADATA structure
IMAGE_POLICY_OVERRIDE macro
InitializeListHead function
InitializeSListHead function
INPUT_MAPPING_ELEMENT structure
InsertHeadList function
InsertTailList function
INTERFACE structure
INTERFACE_TYPE enumeration
InterlockedAnd function
InterlockedCompareExchange function
InterlockedCompareExchangePointer function
InterlockedDecrement function
InterlockedExchange function
InterlockedExchangeAdd function
InterlockedExchangePointer function
InterlockedIncrement function
InterlockedOr function
InterlockedXor function
IO_ACCESS_MODE enumeration
IO_ACCESS_TYPE enumeration
IO_ALLOCATION_ACTION enumeration
IO_COMPLETION_ROUTINE callback function
IO_CONNECT_INTERRUPT_PARAMETERS structure
IO_CONTAINER_INFORMATION_CLASS enumeration
IO_CONTAINER_NOTIFICATION_CLASS enumeration
IO_CSQ_ACQUIRE_LOCK callback function
IO_CSQ_COMPLETE_CANCELED_IRP callback function
IO_CSQ_INSERT_IRP callback function
IO_CSQ_INSERT_IRP_EX callback function
IO_CSQ_PEEK_NEXT_IRP callback function
IO_CSQ_RELEASE_LOCK callback function
IO_CSQ_REMOVE_IRP callback function
IO_DISCONNECT_INTERRUPT_PARAMETERS structure
IO_DPC_ROUTINE callback function
IO_ERROR_LOG_PACKET structure
IO_INTERRUPT_MESSAGE_INFO structure
IO_INTERRUPT_MESSAGE_INFO_ENTRY structure
IO_NOTIFICATION_EVENT_CATEGORY enumeration
IO_PAGING_PRIORITY enumeration
IO_PRIORITY_HINT enumeration
IO_REPORT_INTERRUPT_ACTIVE_STATE_PARAMETERS structure
IO_RESOURCE_DESCRIPTOR structure
IO_RESOURCE_LIST structure
IO_RESOURCE_REQUIREMENTS_LIST structure
IO_SECURITY_CONTEXT structure
IO_SESSION_CONNECT_INFO structure
IO_SESSION_EVENT enumeration
IO_SESSION_NOTIFICATION_FUNCTION callback function
IO_SESSION_STATE enumeration
IO_SESSION_STATE_INFORMATION structure
IO_SESSION_STATE_NOTIFICATION structure
IO_STACK_LOCATION structure
IO_STATUS_BLOCK structure
IO_STATUS_BLOCK64 structure
IO_TIMER_ROUTINE callback function
IO_WORKITEM_ROUTINE callback function
IO_WORKITEM_ROUTINE_EX callback function
IoAcquireKsrPersistentMemory function
IoAcquireKsrPersistentMemoryEx function
IoAcquireRemoveLock macro
IoAdjustPagingPathCount macro
IoAllocateDriverObjectExtension function
IoAllocateErrorLogEntry function
IoAllocateIrp function
IoAllocateIrpEx function
IoAllocateMdl function
IoAllocateWorkItem function
IoAttachDevice function
IoAttachDeviceToDeviceStack function
IoBuildAsynchronousFsdRequest function
IoBuildDeviceIoControlRequest function
IoBuildPartialMdl function
IoBuildSynchronousFsdRequest function
IoCallDriver macro
IoCancelIrp function
IoCheckLinkShareAccess function
IoCheckShareAccess function
IoCheckShareAccessEx function
IoConnectInterrupt function
IoConnectInterruptEx function
IoCopyCurrentIrpStackLocationToNext function
IoCreateDevice function
IoCreateFile function
IoCreateNotificationEvent function
IoCreateSymbolicLink function
IoCreateSynchronizationEvent function
IoCreateSystemThread function
IoCreateUnprotectedSymbolicLink function
IoCsqInitialize function
IoCsqInitializeEx function
IoCsqInsertIrp function
IoCsqInsertIrpEx function
IoCsqRemoveIrp function
IoCsqRemoveNextIrp function
IoDeleteDevice function
IoDeleteSymbolicLink function
IoDetachDevice function
IoDisconnectInterrupt function
IoDisconnectInterruptEx function
IoEnumerateKsrPersistentMemoryEx function
IofCallDriver function
IofCompleteRequest function
IoForwardIrpSynchronously function
IoFreeErrorLogEntry function
IoFreeIrp function
IoFreeKsrPersistentMemory function
IoFreeMdl function
IoFreeWorkItem function
IoGetAffinityInterrupt function
IoGetAttachedDeviceReference function
IoGetBootDiskInformation function
IoGetContainerInformation function
IoGetCurrentIrpStackLocation function
IoGetCurrentProcess function
IoGetDeviceDirectory function
IoGetDeviceInterfaceAlias function
IoGetDeviceInterfacePropertyData function
IoGetDeviceInterfaces function
IoGetDeviceNumaNode function
IoGetDeviceObjectPointer function
IoGetDeviceProperty function
IoGetDevicePropertyData function
IoGetDmaAdapter function
IoGetDriverDirectory function
IoGetDriverObjectExtension function
IoGetFunctionCodeFromCtlCode macro
IoGetInitialStack function
IoGetIommuInterface function
IoGetIommuInterfaceEx function
IoGetIoPriorityHint function
IoGetNextIrpStackLocation function
IoGetRelatedDeviceObject function
IoGetRemainingStackSize function
IoGetStackLimits function
IoInitializeDpcRequest function
IoInitializeIrp function
IoInitializeRemoveLock macro
IoInitializeTimer function
IoInitializeWorkItem function
IoInvalidateDeviceRelations function
IoInvalidateDeviceState function
IoIs32bitProcess function
IoIsErrorUserInduced macro
IoIsWdmVersionAvailable function
IoMarkIrpPending function
IOMMU_DEVICE_CREATE callback function
IOMMU_DEVICE_CREATION_CONFIGURATION structure
IOMMU_DEVICE_CREATION_CONFIGURATION_ACPI structure
IOMMU_DEVICE_CREATION_CONFIGURATION_TYPE enumeration
IOMMU_DEVICE_DELETE callback function
IOMMU_DEVICE_FAULT_HANDLER callback function
IOMMU_DEVICE_QUERY_DOMAIN_TYPES callback function
IOMMU_DMA_DOMAIN_CREATION_FLAGS union
IOMMU_DMA_DOMAIN_TYPE enumeration
IOMMU_DMA_LOGICAL_ADDRESS_TOKEN structure
IOMMU_DMA_LOGICAL_ADDRESS_TOKEN_MAPPED_SEGMENT structure
IOMMU_DMA_LOGICAL_ALLOCATOR_CONFIG structure
IOMMU_DMA_LOGICAL_ALLOCATOR_TYPE enumeration
IOMMU_DMA_RESERVED_REGION structure
IOMMU_DOMAIN_ATTACH_DEVICE callback function
IOMMU_DOMAIN_ATTACH_DEVICE_EX callback function
IOMMU_DOMAIN_CONFIGURE callback function
IOMMU_DOMAIN_CREATE callback function
IOMMU_DOMAIN_CREATE_EX callback function
IOMMU_DOMAIN_DELETE callback function
IOMMU_DOMAIN_DETACH_DEVICE callback function
IOMMU_DOMAIN_DETACH_DEVICE_EX callback function
IOMMU_FLUSH_DOMAIN callback function
IOMMU_FLUSH_DOMAIN_VA_LIST callback function
IOMMU_FREE_RESERVED_LOGICAL_ADDRESS_RANGE callback function
IOMMU_INTERFACE_STATE_CHANGE structure
IOMMU_INTERFACE_STATE_CHANGE_CALLBACK callback function
IOMMU_INTERFACE_STATE_CHANGE_FIELDS union
IOMMU_MAP_IDENTITY_RANGE callback function
IOMMU_MAP_IDENTITY_RANGE_EX callback function
IOMMU_MAP_LOGICAL_RANGE callback function
IOMMU_MAP_LOGICAL_RANGE_EX callback function
IOMMU_MAP_PHYSICAL_ADDRESS structure
IOMMU_MAP_PHYSICAL_ADDRESS_TYPE enumeration
IOMMU_MAP_RESERVED_LOGICAL_RANGE callback function
IOMMU_QUERY_INPUT_MAPPINGS callback function
IOMMU_REGISTER_INTERFACE_STATE_CHANGE_CALLBACK callback function
IOMMU_RESERVE_LOGICAL_ADDRESS_RANGE callback function
IOMMU_SET_DEVICE_FAULT_REPORTING callback function
IOMMU_SET_DEVICE_FAULT_REPORTING_EX callback function
IOMMU_UNMAP_IDENTITY_RANGE callback function
IOMMU_UNMAP_IDENTITY_RANGE_EX callback function
IOMMU_UNMAP_LOGICAL_RANGE callback function
IOMMU_UNMAP_RESERVED_LOGICAL_RANGE callback function
IOMMU_UNREGISTER_INTERFACE_STATE_CHANGE_CALLBACK callback function
IoOpenDeviceInterfaceRegistryKey function
IoOpenDeviceRegistryKey function
IoOpenDriverRegistryKey function
IoQueryKsrPersistentMemorySize function
IoQueryKsrPersistentMemorySizeEx function
IoQueueWorkItem function
IoQueueWorkItemEx function
IoRegisterContainerNotification function
IoRegisterDeviceInterface function
IoRegisterLastChanceShutdownNotification function
IoRegisterPlugPlayNotification function
IoRegisterShutdownNotification function
IoReleaseRemoveLock macro
IoReleaseRemoveLockAndWait macro
IoRemoveLinkShareAccess function
IoRemoveShareAccess function
IoReportInterruptActive function
IoReportInterruptInactive function
IoReportTargetDeviceChange function
IoReportTargetDeviceChangeAsynchronous function
IoRequestDeviceEject function
IoRequestDpc function
IoReserveKsrPersistentMemory function
IoReserveKsrPersistentMemoryEx function
IoReuseIrp function
Iosb64ToIosb macro
IosbToIosb64 macro
IoSetCancelRoutine function
IoSetCompletionRoutine function
IoSetCompletionRoutineEx function
IoSetDeviceInterfacePropertyData function
IoSetDeviceInterfaceState function
IoSetDevicePropertyData function
IoSetIoPriorityHint function
IoSetLinkShareAccess function
IoSetNextIrpStackLocation function
IoSetShareAccess function
IoSetShareAccessEx function
IoSetStartIoAttributes function
IoSizeOfIrp macro
IoSizeofWorkItem function
IoStartNextPacket function
IoStartNextPacketByKey function
IoStartPacket function
IoStartTimer function
IoStopTimer function
IoUninitializeWorkItem function
IoUnregisterContainerNotification function
IoUnregisterPlugPlayNotification function
IoUnregisterPlugPlayNotificationEx function
IoUnregisterShutdownNotification function
IoUpdateLinkShareAccess function
IoUpdateLinkShareAccessEx function
IoUpdateShareAccess function
IoValidateDeviceIoControlAccess function
IoWithinStackLimits function
IoWMIAllocateInstanceIds function
IoWMIDeviceObjectToInstanceName function
IoWMIDeviceObjectToProviderId function
IoWMIExecuteMethod function
IoWMIHandleToInstanceName function
IoWMIOpenBlock function
IoWMIQueryAllData function
IoWMIQueryAllDataMultiple function
IoWMIQuerySingleInstance function
IoWMIQuerySingleInstanceMultiple function
IoWMIRegistrationControl function
IoWMISetNotificationCallback function
IoWMISetSingleInstance function
IoWMISetSingleItem function
IoWMISuggestInstanceName function
IoWMIWriteEvent function
IoWriteErrorLogEntry function
IoWriteKsrPersistentMemory function
IRP structure
IRQ_DEVICE_POLICY enumeration
IRQ_PRIORITY enumeration
IsListEmpty function
KBUGCHECK_ADD_PAGES structure
KBUGCHECK_CALLBACK_REASON enumeration
KBUGCHECK_CALLBACK_ROUTINE callback function
KBUGCHECK_DUMP_IO structure
KBUGCHECK_DUMP_IO_TYPE enumeration
KBUGCHECK_REASON_CALLBACK_ROUTINE callback function
KBUGCHECK_SECONDARY_DUMP_DATA structure
KDEFERRED_ROUTINE callback function
KDPC_WATCHDOG_INFORMATION structure
KE_PROCESSOR_CHANGE_NOTIFY_CONTEXT structure
KeAcquireSpinLock macro
KeAcquireSpinLockAtDpcLevel function
KeAddTriageDumpDataBlock function
KeAreAllApcsDisabled function
KeAreApcsDisabled function
KeBugCheckEx function
KeCancelTimer function
KeClearEvent function
KeConvertAuxiliaryCounterToPerformanceCounter function
KeConvertPerformanceCounterToAuxiliaryCounter function
KeDelayExecutionThread function
KeDeregisterBoundCallback function
KeDeregisterBugCheckCallback function
KeDeregisterBugCheckReasonCallback function
KeDeregisterNmiCallback function
KeDeregisterProcessorChangeCallback function
KeEnterCriticalRegion function
KeEnterGuardedRegion function
KeFlushIoBuffers function
KeFlushQueuedDpcs function
KefReleaseSpinLockFromDpcLevel function
KeGetCurrentIrql function
KeGetCurrentNodeNumber function
KeGetCurrentProcessorNumberEx function
KeGetCurrentThread function
KeGetProcessorIndexFromNumber function
KeGetProcessorNumberFromIndex function
KeGetRecommendedSharedDataAlignment function
KeInitializeCrashDumpHeader function
KeInitializeDeviceQueue function
KeInitializeDpc function
KeInitializeEvent function
KeInitializeGuardedMutex function
KeInitializeMutex function
KeInitializeSemaphore function
KeInitializeSpinLock function
KeInitializeThreadedDpc function
KeInitializeTimer function
KeInitializeTimerEx function
KeInsertByKeyDeviceQueue function
KeInsertDeviceQueue function
KeInsertQueueDpc function
KeIpiGenericCall function
KeIsExecutingDpc function
KeLeaveCriticalRegion function
KeLeaveGuardedRegion function
KeLowerIrql function
KeMemoryBarrier function
KeQueryActiveGroupCount function
KeQueryActiveProcessorCount function
KeQueryActiveProcessorCountEx function
KeQueryActiveProcessors function
KeQueryAuxiliaryCounterFrequency function
KeQueryDpcWatchdogInformation function
KeQueryGroupAffinity function
KeQueryHighestNodeNumber function
KeQueryInterruptTime function
KeQueryInterruptTimePrecise function
KeQueryLogicalProcessorRelationship function
KeQueryMaximumGroupCount function
KeQueryMaximumProcessorCount function
KeQueryMaximumProcessorCountEx function
KeQueryNodeActiveAffinity function
KeQueryNodeActiveAffinity2 function
KeQueryNodeActiveProcessorCount function
KeQueryNodeMaximumProcessorCount function
KeQueryPerformanceCounter function
KeQueryPriorityThread function
KeQueryRuntimeThread function
KeQuerySystemTime function
KeQuerySystemTimePrecise function
KeQueryTickCount macro
KeQueryTimeIncrement function
KeQueryTotalCycleTimeThread function
KeQueryUnbiasedInterruptTime function
KeRaiseIrql macro
KeRaiseIrqlToDpcLevel function
KeReadStateEvent function
KeReadStateMutex function
KeReadStateSemaphore function
KeReadStateTimer function
KeRegisterBoundCallback function
KeRegisterBugCheckCallback function
KeRegisterBugCheckReasonCallback function
KeRegisterNmiCallback function
KeRegisterProcessorChangeCallback function
KeReleaseGuardedMutex function
KeReleaseGuardedMutexUnsafe function
KeReleaseInStackQueuedSpinLock function
KeReleaseInStackQueuedSpinLockForDpc function
KeReleaseInStackQueuedSpinLockFromDpcLevel function
KeReleaseInterruptSpinLock function
KeReleaseMutex function
KeReleaseSemaphore function
KeReleaseSpinLock function
KeReleaseSpinLockForDpc function
KeReleaseSpinLockFromDpcLevel function
KeRemoveByKeyDeviceQueue function
KeRemoveDeviceQueue function
KeRemoveEntryDeviceQueue function
KeRemoveQueueDpc function
KeResetEvent function
KeRestoreExtendedProcessorState function
KeRestoreFloatingPointState function
KeRevertToUserAffinityThreadEx function
KeRevertToUserGroupAffinityThread function
KERNEL_CET_CONTEXT structure
KERNEL_SOFT_RESTART_NOTIFICATION structure
KeSaveExtendedProcessorState function
KeSaveFloatingPointState function
KeSetCoalescableTimer function
KeSetEvent function
KeSetImportanceDpc function
KeSetPriorityThread function
KeSetSystemAffinityThread function
KeSetSystemAffinityThreadEx function
KeSetSystemGroupAffinityThread function
KeSetTargetProcessorDpc function
KeSetTargetProcessorDpcEx function
KeSetTimer function
KeSetTimerEx function
KeShouldYieldProcessor function
KeStallExecutionProcessor function
KeSynchronizeExecution function
KeTestSpinLock function
KeTryToAcquireGuardedMutex function
KeTryToAcquireSpinLockAtDpcLevel function
KeWaitForMultipleObjects function
KeWaitForSingleObject function
KEY_BASIC_INFORMATION structure
KEY_FULL_INFORMATION structure
KEY_INFORMATION_CLASS enumeration
KEY_NODE_INFORMATION structure
KEY_SET_INFORMATION_CLASS enumeration
KEY_VALUE_BASIC_INFORMATION structure
KEY_VALUE_ENTRY structure
KEY_VALUE_FULL_INFORMATION structure
KEY_VALUE_INFORMATION_CLASS enumeration
KEY_VALUE_PARTIAL_INFORMATION structure
KEY_WRITE_TIME_INFORMATION structure
KINTERRUPT_MODE enumeration
KINTERRUPT_POLARITY enumeration
KIPI_BROADCAST_WORKER callback function
KMESSAGE_SERVICE_ROUTINE callback function
KMUTANT structure
KSERVICE_ROUTINE callback function
KSTART_ROUTINE callback function
KSYNCHRONIZE_ROUTINE callback function
KTMOBJECT_CURSOR structure
KTMOBJECT_TYPE enumeration
KzLowerIrql function
KzRaiseIrql function
LINK_SHARE_ACCESS structure
MAILSLOT_CREATE_PARAMETERS structure
MDL structure
MEM_EXTENDED_PARAMETER structure
MEM_EXTENDED_PARAMETER_TYPE enumeration
MEM_SECTION_EXTENDED_PARAMETER_TYPE enumeration
MEMORY_CACHING_TYPE enumeration
MEMORY_PARTITION_DEDICATED_MEMORY_OPEN_INFORMATION structure
MM_MDL_ROUTINE callback function
MM_PHYSICAL_ADDRESS_LIST structure
MmAdvanceMdl function
MmAllocateContiguousMemory function
MmAllocateContiguousMemoryEx function
MmAllocateContiguousMemorySpecifyCache function
MmAllocateContiguousMemorySpecifyCacheNode function
MmAllocateContiguousNodeMemory function
MmAllocateMappingAddress function
MmAllocateMappingAddressEx function
MmAllocateMdlForIoSpace function
MmAllocateNodePagesForMdlEx function
MmAllocatePagesForMdl function
MmAllocatePagesForMdlEx function
MmBuildMdlForNonPagedPool function
MmFreeContiguousMemory function
MmFreeContiguousMemorySpecifyCache function
MmFreeMappingAddress function
MmFreePagesFromMdl function
MmGetMdlByteCount macro
MmGetSystemAddressForMdl macro
MmGetSystemRoutineAddress function
MmGetSystemRoutineAddressEx function
MmIsDriverSuspectForVerifier function
MmIsDriverVerifying function
MmIsDriverVerifyingByAddress function
MmLockPagableCodeSection macro
MmLockPagableDataSection function
MmMapIoSpace function
MmMapIoSpaceEx function
MmMapLockedPages function
MmMapLockedPagesSpecifyCache function
MmMapLockedPagesWithReservedMapping function
MmMapMdl function
MmMapMemoryDumpMdlEx function
MmPageEntireDriver function
MmProbeAndLockPages function
MmProbeAndLockSelectedPages function
MmProtectDriverSection function
MmProtectMdlSystemAddress function
MmQuerySystemSize function
MmResetDriverPaging function
MmSizeOfMdl function
MmUnlockPagableImageSection function
MmUnlockPages function
MmUnmapIoSpace function
MmUnmapLockedPages function
MmUnmapReservedMapping function
MONITOR_DISPLAY_STATE enumeration
NAMED_PIPE_CREATE_PARAMETERS structure
NtCommitComplete function
NtCommitEnlistment function
NtCommitTransaction function
NtCreateEnlistment function
NtCreateResourceManager function
NtCreateTransaction function
NtCreateTransactionManager function
NtEnumerateTransactionObject function
NtGetNotificationResourceManager function
NtManagePartition function
NtOpenEnlistment function
NtOpenResourceManager function
NtOpenTransaction function
NtOpenTransactionManager function
NtPowerInformation function
NtPrepareComplete function
NtPrepareEnlistment function
NtPrePrepareComplete function
NtPrePrepareEnlistment function
NtQueryInformationEnlistment function
NtQueryInformationResourceManager function
NtQueryInformationTransaction function
NtQueryInformationTransactionManager function
NtReadOnlyEnlistment function
NtRecoverEnlistment function
NtRecoverResourceManager function
NtRecoverTransactionManager function
NtRenameTransactionManager function
NtRollbackComplete function
NtRollbackEnlistment function
NtRollbackTransaction function
NtRollforwardTransactionManager function
NtSetInformationEnlistment function
NtSetInformationResourceManager function
NtSetInformationTransaction function
NtSetInformationTransactionManager function
NtSinglePhaseReject function
OB_CALLBACK_REGISTRATION structure
OB_OPERATION_REGISTRATION structure
OB_POST_CREATE_HANDLE_INFORMATION structure
OB_POST_DUPLICATE_HANDLE_INFORMATION structure
OB_POST_OPERATION_INFORMATION structure
OB_POST_OPERATION_PARAMETERS union
OB_PRE_CREATE_HANDLE_INFORMATION structure
OB_PRE_DUPLICATE_HANDLE_INFORMATION structure
OB_PRE_OPERATION_INFORMATION structure
OB_PRE_OPERATION_PARAMETERS union
ObCloseHandle function
ObDereferenceObject macro
ObDereferenceObjectDeferDelete function
ObDereferenceObjectDeferDeleteWithTag function
ObDereferenceObjectWithTag macro
ObfReferenceObject function
ObGetObjectSecurity function
ObReferenceObject macro
ObReferenceObjectByHandle function
ObReferenceObjectByHandleWithTag function
ObReferenceObjectByPointer function
ObReferenceObjectByPointerWithTag function
ObReferenceObjectSafe function
ObReferenceObjectWithTag macro
ObRegisterCallbacks function
ObReleaseObjectSecurity function
ObUnRegisterCallbacks function
OSVERSIONINFOEXW structure
OSVERSIONINFOW structure
PALLOCATE_ADAPTER_CHANNEL callback function
PALLOCATE_ADAPTER_CHANNEL_EX callback function
PALLOCATE_COMMON_BUFFER callback function
PALLOCATE_COMMON_BUFFER_EX callback function
PALLOCATE_COMMON_BUFFER_VECTOR callback function
PALLOCATE_COMMON_BUFFER_WITH_BOUNDS callback function
PALLOCATE_DOMAIN_COMMON_BUFFER callback function
PBUILD_MDL_FROM_SCATTER_GATHER_LIST callback function
PBUILD_SCATTER_GATHER_LIST callback function
PBUILD_SCATTER_GATHER_LIST_EX callback function
PCALCULATE_SCATTER_GATHER_LIST_SIZE callback function
PCANCEL_ADAPTER_CHANNEL callback function
PCANCEL_MAPPED_TRANSFER callback function
PCI_ATS_INTERFACE structure
PCI_COMMON_CONFIG structure
PCI_MSIX_MASKUNMASK_ENTRY callback function
PCI_MSIX_SET_ENTRY callback function
PCI_MSIX_TABLE_CONFIG_INTERFACE structure
PCI_SECURITY_INTERFACE2 structure
PCI_SEGMENT_BUS_NUMBER structure
PCI_SLOT_NUMBER structure
PCLFS_CLIENT_ADVANCE_TAIL_CALLBACK callback function
PCLFS_CLIENT_LFF_HANDLER_COMPLETE_CALLBACK callback function
PCLFS_CLIENT_LOG_UNPINNED_CALLBACK callback function
PCONFIGURE_ADAPTER_CHANNEL callback function
PDEVICE_RESET_HANDLER callback function
PFLUSH_ADAPTER_BUFFERS callback function
PFLUSH_ADAPTER_BUFFERS_EX callback function
PFLUSH_DMA_BUFFER callback function
PFREE_ADAPTER_CHANNEL callback function
PFREE_ADAPTER_OBJECT callback function
PFREE_COMMON_BUFFER callback function
PFREE_COMMON_BUFFER_FROM_VECTOR callback function
PFREE_COMMON_BUFFER_VECTOR callback function
PFREE_MAP_REGISTERS callback function
PGET_COMMON_BUFFER_FROM_VECTOR_BY_INDEX callback function
PGET_DEVICE_RESET_STATUS callback function
PGET_DMA_ADAPTER_INFO callback function
PGET_DMA_ALIGNMENT callback function
PGET_DMA_DOMAIN callback function
PGET_DMA_TRANSFER_INFO callback function
PGET_SCATTER_GATHER_LIST callback function
PGET_SCATTER_GATHER_LIST_EX callback function
PINITIALIZE_DMA_TRANSFER_CONTEXT callback function
PINTERFACE_DEREFERENCE callback function
PINTERFACE_REFERENCE callback function
PJOIN_DMA_DOMAIN callback function
PLEAVE_DMA_DOMAIN callback function
PLUGPLAY_NOTIFICATION_HEADER structure
PMAP_TRANSFER callback function
PMAP_TRANSFER_EX callback function
PNP_BUS_INFORMATION structure
PO_FX_COMPONENT_ACTIVE_CONDITION_CALLBACK callback function
PO_FX_COMPONENT_CRITICAL_TRANSITION_CALLBACK callback function
PO_FX_COMPONENT_IDLE_CONDITION_CALLBACK callback function
PO_FX_COMPONENT_IDLE_STATE structure
PO_FX_COMPONENT_IDLE_STATE_CALLBACK callback function
PO_FX_COMPONENT_PERF_INFO structure
PO_FX_COMPONENT_PERF_SET structure
PO_FX_COMPONENT_PERF_STATE_CALLBACK callback function
PO_FX_COMPONENT_V1 structure
PO_FX_COMPONENT_V2 structure
PO_FX_DEVICE_POWER_NOT_REQUIRED_CALLBACK callback function
PO_FX_DEVICE_POWER_REQUIRED_CALLBACK callback function
PO_FX_DEVICE_V1 structure
PO_FX_DEVICE_V2 structure
PO_FX_DEVICE_V3 structure
PO_FX_DIRECTED_POWER_DOWN_CALLBACK callback function
PO_FX_DIRECTED_POWER_UP_CALLBACK callback function
PO_FX_PERF_STATE structure
PO_FX_PERF_STATE_CHANGE structure
PO_FX_PERF_STATE_TYPE enumeration
PO_FX_PERF_STATE_UNIT enumeration
PO_FX_POWER_CONTROL_CALLBACK callback function
POB_POST_OPERATION_CALLBACK callback function
POB_PRE_OPERATION_CALLBACK callback function
PoCallDriver function
PoClearPowerRequest function
PoCreatePowerRequest function
PoDeletePowerRequest function
PoEndDeviceBusy function
PoFxActivateComponent function
PoFxCompleteDevicePowerNotRequired function
PoFxCompleteDirectedPowerDown function
PoFxCompleteIdleCondition function
PoFxCompleteIdleState function
PoFxIdleComponent function
PoFxIssueComponentPerfStateChange function
PoFxIssueComponentPerfStateChangeMultiple function
PoFxNotifySurprisePowerOn function
PoFxPowerControl function
PoFxPowerOnCrashdumpDevice function
PoFxQueryCurrentComponentPerfState function
PoFxRegisterComponentPerfStates function
PoFxRegisterCrashdumpDevice function
PoFxRegisterDevice function
PoFxReportDevicePoweredOn function
PoFxSetComponentLatency function
PoFxSetComponentResidency function
PoFxSetComponentWake function
PoFxSetDeviceIdleTimeout function
PoFxSetTargetDripsDevicePowerState function
PoFxStartDevicePowerManagement function
PoFxUnregisterDevice function
PoGetSystemWake function
POOL_CREATE_EXTENDED_PARAMS structure
POOL_EXTENDED_PARAMETER structure
POOL_EXTENDED_PARAMETER_TYPE enumeration
POOL_EXTENDED_PARAMS_SECURE_POOL structure
POOL_TYPE enumeration
PopEntryList function
PoQueryWatchdogTime function
PoRegisterDeviceForIdleDetection function
PoRegisterPowerSettingCallback function
PoRegisterSystemState function
PoRequestPowerIrp function
PoSetDeviceBusyEx function
PoSetPowerRequest function
PoSetPowerState function
PoSetSystemState function
PoSetSystemWake function
PoSetSystemWakeDevice function
PoStartDeviceBusy function
PoStartNextPowerIrp function
PoUnregisterPowerSettingCallback function
PoUnregisterSystemState function
POWER_ACTION enumeration
POWER_INFORMATION_LEVEL enumeration
POWER_PLATFORM_INFORMATION structure
POWER_REQUEST_TYPE enumeration
POWER_SESSION_ALLOW_EXTERNAL_DMA_DEVICES structure
POWER_STATE union
POWER_STATE_TYPE enumeration
PPUT_DMA_ADAPTER callback function
PPUT_SCATTER_GATHER_LIST callback function
PREAD_DMA_COUNTER callback function
PREENUMERATE_SELF callback function
PRIVILEGE_SET structure
ProbeForRead function
ProbeForWrite function
PROCESSOR_HALT_ROUTINE callback function
PsAllocateAffinityToken function
PsCreateSystemThread function
PsFreeAffinityToken function
PsGetCurrentThread function
PsGetVersion function
PsQueryTotalCycleTimeProcess function
PsRevertToUserMultipleGroupAffinityThread function
PsSetSystemMultipleGroupAffinityThread function
PsTerminateSystemThread function
PTM_CONTROL_INTERFACE structure
PTM_RM_NOTIFICATION callback function
PushEntryList function
READ_PORT_BUFFER_UCHAR function
READ_PORT_BUFFER_ULONG function
READ_PORT_BUFFER_USHORT function
READ_PORT_UCHAR function
READ_PORT_ULONG function
READ_PORT_USHORT function
READ_REGISTER_BUFFER_UCHAR function
READ_REGISTER_BUFFER_ULONG function
READ_REGISTER_BUFFER_ULONG64 function
READ_REGISTER_BUFFER_USHORT function
READ_REGISTER_UCHAR function
READ_REGISTER_ULONG function
READ_REGISTER_ULONG64 function
READ_REGISTER_USHORT function
ReadInt32Acquire function
ReadInt32NoFence function
ReadInt32Raw function
ReadUInt32Acquire function
ReadUInt32NoFence function
ReadUInt32Raw function
REENUMERATE_SELF_INTERFACE_STANDARD structure
REG_CALLBACK_CONTEXT_CLEANUP_INFORMATION structure
REG_CREATE_KEY_INFORMATION structure
REG_CREATE_KEY_INFORMATION_V1 structure
REG_DELETE_KEY_INFORMATION structure
REG_DELETE_VALUE_KEY_INFORMATION structure
REG_ENUMERATE_KEY_INFORMATION structure
REG_ENUMERATE_VALUE_KEY_INFORMATION structure
REG_KEY_HANDLE_CLOSE_INFORMATION structure
REG_LOAD_KEY_INFORMATION structure
REG_LOAD_KEY_INFORMATION_V2 structure
REG_NOTIFY_CLASS enumeration
REG_POST_CREATE_KEY_INFORMATION structure
REG_POST_OPERATION_INFORMATION structure
REG_PRE_CREATE_KEY_INFORMATION structure
REG_QUERY_KEY_INFORMATION structure
REG_QUERY_KEY_NAME structure
REG_QUERY_KEY_SECURITY_INFORMATION structure
REG_QUERY_MULTIPLE_VALUE_KEY_INFORMATION structure
REG_QUERY_VALUE_KEY_INFORMATION structure
REG_RENAME_KEY_INFORMATION structure
REG_REPLACE_KEY_INFORMATION structure
REG_RESTORE_KEY_INFORMATION structure
REG_SAVE_KEY_INFORMATION structure
REG_SAVE_MERGED_KEY_INFORMATION structure
REG_SET_INFORMATION_KEY_INFORMATION structure
REG_SET_KEY_SECURITY_INFORMATION structure
REG_SET_VALUE_KEY_INFORMATION structure
REG_UNLOAD_KEY_INFORMATION structure
RemoveEntryList function
RemoveHeadList function
RemoveTailList function
REQUEST_POWER_COMPLETE callback function
RESOURCEMANAGER_BASIC_INFORMATION structure
RESOURCEMANAGER_COMPLETION_INFORMATION structure
RESOURCEMANAGER_INFORMATION_CLASS enumeration
RTL_QUERY_REGISTRY_ROUTINE callback function
RtlAnsiStringToUnicodeSize macro
RtlAnsiStringToUnicodeString function
RtlAppendUnicodeStringToString function
RtlAppendUnicodeToString function
RtlAreBitsClear function
RtlAreBitsSet function
RtlCheckBit function
RtlCheckRegistryKey function
RtlClearAllBits function
RtlClearBit function
RtlClearBits function
RtlCmDecodeMemIoResource function
RtlCmEncodeMemIoResource function
RtlCompareMemory function
RtlCompareUnicodeString function
RtlConvertLongToLargeInteger function
RtlConvertUlongToLargeInteger function
RtlCopyMemory macro
RtlCopyMemoryNonTemporal function
RtlCopyUnicodeString function
RtlCreateRegistryKey function
RtlCreateSecurityDescriptor function
RtlDeleteRegistryValue function
RtlDowncaseUnicodeChar function
RtlEqualMemory macro
RtlEqualUnicodeString function
RtlFillMemory macro
RtlFillMemoryNonTemporal function
RtlFindClearBits function
RtlFindClearBitsAndSet function
RtlFindClearRuns function
RtlFindFirstRunClear function
RtlFindLastBackwardRunClear function
RtlFindLeastSignificantBit function
RtlFindLongestRunClear function
RtlFindMostSignificantBit function
RtlFindNextForwardRunClear function
RtlFindSetBits function
RtlFindSetBitsAndClear function
RtlFreeAnsiString function
RtlFreeUnicodeString function
RtlFreeUTF8String function
RtlGetVersion function
RtlGUIDFromString function
RtlHashUnicodeString function
RtlInitAnsiString function
RtlInitializeBitMap function
RtlInitString function
RtlInitStringEx function
RtlInitUnicodeString function
RtlInitUTF8String function
RtlInitUTF8StringEx function
RtlInt64ToUnicodeString function
RtlIntegerToUnicodeString function
RtlIntPtrToUnicodeString macro
RtlIoDecodeMemIoResource function
RtlIoEncodeMemIoResource function
RtlIsNtDdiVersionAvailable function
RtlIsServicePackVersionInstalled function
RtlLengthSecurityDescriptor function
RtlMoveMemory macro
RtlNumberOfClearBits function
RtlNumberOfSetBits function
RtlNumberOfSetBitsUlongPtr function
RtlPrefetchMemoryNonTemporal function
RtlQueryRegistryValues function
RtlSanitizeUnicodeStringPadding function
RtlSecureZeroMemory function
RtlSetAllBits function
RtlSetBit function
RtlSetBits function
RtlSetDaclSecurityDescriptor function
RtlStringFromGUID function
RtlTestBit function
RtlTimeFieldsToTime function
RtlTimeToTimeFields function
RtlUlongByteSwap function
RtlUlonglongByteSwap function
RtlUnicodeStringToAnsiSize macro
RtlUnicodeStringToAnsiString function
RtlUnicodeStringToInteger function
RtlUnicodeStringToUTF8String function
RtlUnicodeToUTF8N function
RtlUpcaseUnicodeChar function
RtlUshortByteSwap function
RtlUTF8StringToUnicodeString function
RtlUTF8ToUnicodeN function
RtlValidRelativeSecurityDescriptor function
RtlValidSecurityDescriptor function
RtlVerifyVersionInfo function
RtlWriteRegistryValue function
RtlxAnsiStringToUnicodeSize function
RtlxUnicodeStringToAnsiSize function
RtlZeroMemory macro
SCATTER_GATHER_LIST structure
SDEV_IDENTIFIER_INTERFACE structure
SE_IMAGE_TYPE enumeration
SeAccessCheck function
SeAssignSecurity function
SeAssignSecurityEx function
SECTION_OBJECT_POINTERS structure
SeDeassignSecurity function
SET_D3COLD_SUPPORT callback function
SeValidSecurityDescriptor function
SLIST_ENTRY structure
SYSTEM_POOL_ZEROING_INFORMATION structure
SYSTEM_POWER_STATE enumeration
SYSTEM_POWER_STATE_CONTEXT structure
TARGET_DEVICE_CUSTOM_NOTIFICATION structure
TARGET_DEVICE_REMOVAL_NOTIFICATION structure
TIME_FIELDS structure
TmCommitComplete function
TmCommitEnlistment function
TmCommitTransaction function
TmCreateEnlistment function
TmDereferenceEnlistmentKey function
TmEnableCallbacks function
TmGetTransactionId function
TmInitializeTransactionManager function
TmIsTransactionActive function
TmPrepareComplete function
TmPrepareEnlistment function
TmPrePrepareComplete function
TmPrePrepareEnlistment function
TmReadOnlyEnlistment function
TmRecoverEnlistment function
TmRecoverResourceManager function
TmRecoverTransactionManager function
TmReferenceEnlistmentKey function
TmRenameTransactionManager function
TmRequestOutcomeEnlistment function
TmRollbackComplete function
TmRollbackEnlistment function
TmRollbackTransaction function
TmSinglePhaseReject function
TRACE_INFORMATION_CLASS enumeration
TRANSACTION_BASIC_INFORMATION structure
TRANSACTION_ENLISTMENT_PAIR structure
TRANSACTION_ENLISTMENTS_INFORMATION structure
TRANSACTION_INFORMATION_CLASS enumeration
TRANSACTION_OUTCOME enumeration
TRANSACTION_PROPERTIES_INFORMATION structure
TRANSACTION_STATE enumeration
TRANSACTIONMANAGER_BASIC_INFORMATION structure
TRANSACTIONMANAGER_INFORMATION_CLASS enumeration
TRANSACTIONMANAGER_LOG_INFORMATION structure
TRANSACTIONMANAGER_LOGPATH_INFORMATION structure
TRANSACTIONMANAGER_RECOVERY_INFORMATION structure
TRANSLATE_BUS_ADDRESS callback function
VslCreateSecureSection function
VslDeleteSecureSection function
WAIT_CONTEXT_BLOCK structure
WmiQueryTraceInformation function
WmiTraceMessage function
WmiTraceMessageVa function
WORK_QUEUE_TYPE enumeration
WRITE_PORT_BUFFER_UCHAR function
WRITE_PORT_BUFFER_ULONG function
WRITE_PORT_BUFFER_USHORT function
WRITE_PORT_UCHAR function
WRITE_PORT_ULONG function
WRITE_PORT_USHORT function
WRITE_REGISTER_BUFFER_UCHAR function
WRITE_REGISTER_BUFFER_ULONG function
WRITE_REGISTER_BUFFER_ULONG64 function
WRITE_REGISTER_BUFFER_USHORT function
WRITE_REGISTER_UCHAR function
WRITE_REGISTER_ULONG function
WRITE_REGISTER_ULONG64 function
WRITE_REGISTER_USHORT function
WriteInt32NoFence function
WriteInt32Raw function
WriteInt32Release function
WriteUInt32NoFence function
WriteUInt32Raw function
WriteUInt32Release function
XSAVE_CET_U_FORMAT structure
ZwClose function
ZwCommitComplete function
ZwCommitEnlistment function
ZwCommitTransaction function
ZwCreateDirectoryObject function
ZwCreateEnlistment function
ZwCreateFile function
ZwCreateKey function
ZwCreateKeyTransacted function
ZwCreateResourceManager function
ZwCreateSection function
ZwCreateTransaction function
ZwCreateTransactionManager function
ZwDeleteKey function
ZwDeleteValueKey function
ZwEnumerateKey function
ZwEnumerateTransactionObject function
ZwEnumerateValueKey function
ZwFlushKey function
ZwGetNotificationResourceManager function
ZwLoadDriver function
ZwMakeTemporaryObject function
ZwMapViewOfSection function
ZwOpenEnlistment function
ZwOpenEvent function
ZwOpenFile function
ZwOpenKey function
ZwOpenKeyEx function
ZwOpenKeyTransacted function
ZwOpenKeyTransactedEx function
ZwOpenResourceManager function
ZwOpenSection function
ZwOpenSymbolicLinkObject function
ZwOpenTransaction function
ZwOpenTransactionManager function
ZwPrepareComplete function
ZwPrepareEnlistment function
ZwPrePrepareComplete function
ZwPrePrepareEnlistment function
ZwQueryFullAttributesFile function
ZwQueryInformationByName function
ZwQueryInformationEnlistment function
ZwQueryInformationFile function
ZwQueryInformationResourceManager function
ZwQueryInformationTransaction function
ZwQueryInformationTransactionManager function
ZwQueryKey function
ZwQuerySymbolicLinkObject function
ZwQueryValueKey function
ZwReadFile function
ZwReadOnlyEnlistment function
ZwRecoverEnlistment function
ZwRecoverResourceManager function
ZwRecoverTransactionManager function
ZwRollbackComplete function
ZwRollbackEnlistment function
ZwRollbackTransaction function
ZwRollforwardTransactionManager function
ZwSetInformationEnlistment function
ZwSetInformationFile function
ZwSetInformationResourceManager function
ZwSetInformationTransaction function
ZwSetValueKey function
ZwSinglePhaseReject function
ZwUnloadDriver function
ZwUnmapViewOfSection function
ZwWriteFile function
*/
	}
}
