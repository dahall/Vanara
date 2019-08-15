using System;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using Vanara.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class AdvApi32
	{
		public const uint WCT_MAX_NODE_COUNT = 16;

		/// <summary>
		/// <para>
		/// An application-defined callback function that receives a wait chain. Specify this address when calling the
		/// OpenThreadWaitChainSession function.
		/// </para>
		/// <para>
		/// The <c>PWAITCHAINCALLBACK</c> type defines a pointer to this callback function. WaitChainCallback is a placeholder for the
		/// application-defined function name.
		/// </para>
		/// </summary>
		/// <param name="WctHandle">A handle to the WCT session created by the OpenThreadWaitChainSession function.</param>
		/// <param name="Context">A optional pointer to an application-defined context structure specified by the GetThreadWaitChain function.</param>
		/// <param name="CallbackStatus">
		/// The callback status. This parameter can be one of the following values, or one of the other system error codes.
		/// </param>
		/// <param name="NodeCount">
		/// The number of nodes retrieved, up to WCT_MAX_NODE_COUNT. If the array cannot contain all the nodes of the wait chain, the
		/// function fails, CallbackStatus is ERROR_MORE_DATA, and this parameter receives the number of array elements required to contain
		/// all the nodes.
		/// </param>
		/// <param name="NodeInfoArray">An array of WAITCHAIN_NODE_INFO structures that receives the wait chain.</param>
		/// <param name="IsCycle">If the function detects a deadlock, this variable is set to <c>TRUE</c>; otherwise, it is set to <c>FALSE</c>.</param>
		/// <returns>This callback function does not return a value.</returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wct/nc-wct-pwaitchaincallback PWAITCHAINCALLBACK Pwaitchaincallback; void
		// Pwaitchaincallback( HWCT WctHandle, DWORD_PTR Context, DWORD CallbackStatus, LPDWORD NodeCount, PWAITCHAIN_NODE_INFO
		// NodeInfoArray, LPBOOL IsCycle ) {...}
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		[PInvokeData("wct.h", MSDNShortId = "07d987b4-3ee4-4957-a6e8-542c427b94dd")]
		public delegate void WaitChainCallback(HWCT WctHandle, IntPtr Context, Win32Error CallbackStatus, ref uint NodeCount, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] WAITCHAIN_NODE_INFO[] NodeInfoArray, [MarshalAs(UnmanagedType.Bool)] out bool IsCycle);

		/// <summary>The wait chain retrieval options.</summary>
		[PInvokeData("wct.h", MSDNShortId = "5b418fa6-1d07-465e-85ea-b7127264eebf")]
		[Flags]
		public enum WaitChainRetrievalOptions
		{
			/// <summary>
			/// Follows the wait chain into other processes. Otherwise, the function reports the first thread in a different process but does
			/// not retrieve additional information.
			/// </summary>
			WCT_OUT_OF_PROC_FLAG = 0x1,

			/// <summary>Enumerates all threads of an out-of-proc MTA COM server to find the correct thread identifier.</summary>
			WCT_OUT_OF_PROC_COM_FLAG = 0x2,

			/// <summary>Retrieves critical-section information from other processes.</summary>
			WCT_OUT_OF_PROC_CS_FLAG = 0x4,

			/// <summary/>
			WCT_NETWORK_IO_FLAG = 0x8,

			/// <summary/>
			WCTP_GETINFO_ALL_FLAGS = WCT_OUT_OF_PROC_FLAG | WCT_OUT_OF_PROC_COM_FLAG | WCT_OUT_OF_PROC_CS_FLAG,
		}

		/// <summary>The session type.</summary>
		public enum WaitChainSessionType
		{
			/// <summary>A synchronous session.</summary>
			WCT_SYNC_OPEN_FLAG = 0,

			/// <summary>An asynchronous session.</summary>
			WCT_ASYNC_OPEN_FLAG = 0x1,
		}

		/// <summary>The object status.</summary>
		[PInvokeData("wct.h", MSDNShortId = "7a333924-79a3-4522-aa5a-4fc60690667d")]
		public enum WCT_OBJECT_STATUS
		{
			WctStatusNoAccess = 1,
			WctStatusRunning,
			WctStatusBlocked,
			WctStatusPidOnly,
			WctStatusPidOnlyRpcss,
			WctStatusOwned,
			WctStatusNotOwned,
			WctStatusAbandoned,
			WctStatusUnknown,
			WctStatusError,
			WctStatusMax
		}

		/// <summary>The object type.</summary>
		[PInvokeData("wct.h", MSDNShortId = "7a333924-79a3-4522-aa5a-4fc60690667d")]
		public enum WCT_OBJECT_TYPE
		{
			WctCriticalSectionType = 1,
			WctSendMessageType,
			WctMutexType,
			WctAlpcType,
			WctComType,
			WctThreadWaitType,
			WctProcessWaitType,
			WctThreadType,
			WctComActivationType,
			WctUnknownType,
			WctSocketIoType,
			WctSmbIoType,
			WctMaxType
		}

		/// <summary>Closes the specified WCT session and cancels any outstanding asynchronous operations.</summary>
		/// <param name="WctHandle">A handle to the WCT session created by the OpenThreadWaitChainSession function.</param>
		/// <returns>This function does not return a value.</returns>
		/// <remarks>
		/// <para>
		/// If the WCT session was opened in asynchronous mode (with WCT_ASYNC_OPEN_FLAG), the function cancels any outstanding operations
		/// after their callback functions have been called and returned, and then it returns.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Using WCT.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wct/nf-wct-closethreadwaitchainsession void CloseThreadWaitChainSession( HWCT
		// WctHandle );
		[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wct.h", MSDNShortId = "dc288418-01e4-4737-9c63-e6e6b73b5d13")]
		public static extern void CloseThreadWaitChainSession(HWCT WctHandle);

		/// <summary>Retrieves the wait chain for the specified thread.</summary>
		/// <param name="WctHandle">A handle to the WCT session created by the OpenThreadWaitChainSession function.</param>
		/// <param name="Context">
		/// A pointer to an application-defined context structure to be passed to the callback function for an asynchronous session.
		/// </param>
		/// <param name="Flags">The wait chain retrieval options. This parameter can be one of more of the following values.</param>
		/// <param name="ThreadId">The identifier of the thread.</param>
		/// <param name="NodeCount">
		/// <para>
		/// On input, a number from 1 to WCT_MAX_NODE_COUNT that specifies the number of nodes in the wait chain. On return, the number of
		/// nodes retrieved. If the array cannot contain all the nodes of the wait chain, the function fails, GetLastError returns
		/// ERROR_MORE_DATA, and this parameter receives the number of array elements required to contain all the nodes.
		/// </para>
		/// <para>
		/// For asynchronous sessions, check the value that is passed to the callback function. Do not free the variable until the callback
		/// function has returned.
		/// </para>
		/// </param>
		/// <param name="NodeInfoArray">
		/// <para>An array of WAITCHAIN_NODE_INFO structures that receives the wait chain.</para>
		/// <para>
		/// For asynchronous sessions, check the value that is passed to the callback function. Do not free the array until the callback
		/// function has returned.
		/// </para>
		/// </param>
		/// <param name="IsCycle">
		/// <para>If the function detects a deadlock, this variable is set to <c>TRUE</c>; otherwise, it is set to <c>FALSE</c>.</para>
		/// <para>
		/// For asynchronous sessions, check the value that is passed to the callback function. Do not free the variable until the callback
		/// function has returned.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To retrieve extended error information, call GetLastError.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>The caller did not have sufficient privilege to open a target thread.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>One of the input parameters is invalid.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_IO_PENDING</term>
		/// <term>The WCT session was opened in asynchronous mode. The results will be returned through the WaitChainCallback callback function.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_MORE_DATA</term>
		/// <term>
		/// The NodeInfoArray buffer is not large enough to contain all the nodes in the wait chain. The NodeCount parameter contains the
		/// number of nodes in the chain. The wait chain returned is still valid.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>The operating system is not providing this service.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_OBJECT_NOT_FOUND</term>
		/// <term>The specified thread could not be located.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_TOO_MANY_THREADS</term>
		/// <term>The number of nodes exceeds WCT_MAX_NODE_COUNT. The wait chain returned is still valid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If the session is asynchronous, the function returns <c>FALSE</c> and GetLastError returns ERROR_IO_PENDING. To obtain the
		/// results, see the WaitChainCallback callback function.
		/// </para>
		/// <para>
		/// If the specified thread is not blocked or is blocked on an unsupported synchronization element, the function returns a single
		/// item in NodeInfoArray.
		/// </para>
		/// <para>
		/// The caller must have the SE_DEBUG_NAME privilege. If the caller has insufficient privileges, the function fails if the first
		/// thread cannot be accessed. Otherwise, the last node in the array will have its <c>ObjectStatus</c> member set to WctStatusNoAcces.
		/// </para>
		/// <para>If any subset of nodes in the array forms a cycle, the function sets the IsCycle parameter to <c>TRUE</c>.</para>
		/// <para>
		/// Wait chain information is dynamic; it was correct when the function was called but may be out-of-date by the time it is reviewed
		/// by the caller.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Using WCT.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wct/nf-wct-getthreadwaitchain BOOL GetThreadWaitChain( HWCT WctHandle,
		// DWORD_PTR Context, DWORD Flags, DWORD ThreadId, LPDWORD NodeCount, PWAITCHAIN_NODE_INFO NodeInfoArray, LPBOOL IsCycle );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("wct.h", MSDNShortId = "5b418fa6-1d07-465e-85ea-b7127264eebf")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetThreadWaitChain(HWCT WctHandle, IntPtr Context, WaitChainRetrievalOptions Flags, uint ThreadId, ref uint NodeCount, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] WAITCHAIN_NODE_INFO[] NodeInfoArray, [MarshalAs(UnmanagedType.Bool)] out bool IsCycle);

		/// <summary>Creates a new WCT session.</summary>
		/// <param name="Flags">The session type. This parameter can be one of the following values.</param>
		/// <param name="callback">If the session is asynchronous, this parameter can be a pointer to a WaitChainCallback callback function.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is a handle to the newly created session.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>When you have finished using the session, call the CloseThreadWaitChainSession function.</para>
		/// <para>Examples</para>
		/// <para>For an example, see Using WCT.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wct/nf-wct-openthreadwaitchainsession HWCT OpenThreadWaitChainSession( DWORD
		// Flags, PWAITCHAINCALLBACK callback );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("wct.h", MSDNShortId = "405d9f3d-c11b-4e20-acc8-9c4f7989685d")]
		public static extern SafeHWCT OpenThreadWaitChainSession(WaitChainSessionType Flags, [Optional, MarshalAs(UnmanagedType.FunctionPtr)] WaitChainCallback callback);

		/// <summary>Register COM callback functions for WCT.</summary>
		/// <param name="CallStateCallback">The address of the <c>CoGetCallState</c> function.</param>
		/// <param name="ActivationStateCallback">The address of the <c>CoGetActivationState</c> function.</param>
		/// <returns>This function does not return a value.</returns>
		/// <remarks>
		/// <para>
		/// If a thread is blocked on a COM call, WCT can retrieve COM ownership information using these callback functions. If this function
		/// is callback multiple times, only the last addresses retrieved are used.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Using WCT.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wct/nf-wct-registerwaitchaincomcallback void RegisterWaitChainCOMCallback(
		// PCOGETCALLSTATE CallStateCallback, PCOGETACTIVATIONSTATE ActivationStateCallback );
		[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wct.h", MSDNShortId = "f8adffa3-6e63-4fae-81e8-5f6643e988e9")]
		public static extern void RegisterWaitChainCOMCallback(IntPtr CallStateCallback, IntPtr ActivationStateCallback);

		/// <summary>Register COM callback functions for WCT. This method does the work of getting the method addresses and calling the Windows API function.</summary>
		/// <returns>This function does not return a value.</returns>
		/// <remarks>
		/// <para>
		/// If a thread is blocked on a COM call, WCT can retrieve COM ownership information using these callback functions. If this function
		/// is callback multiple times, only the last addresses retrieved are used.
		/// </para>
		/// </remarks>
		[PInvokeData("wct.h", MSDNShortId = "f8adffa3-6e63-4fae-81e8-5f6643e988e9")]
		public static void RegisterWaitChainCOMCallback()
		{
			using (var hLib = Kernel32.LoadLibrary(Lib.Ole32))
			{
				if (hLib.IsInvalid) Win32Error.ThrowLastError();
				var p1 = Kernel32.GetProcAddress(hLib, "CoGetCallState");
				if (p1 == IntPtr.Zero) Win32Error.ThrowLastError();
				var p2 = Kernel32.GetProcAddress(hLib, "CoGetActivationState");
				if (p2 == IntPtr.Zero) Win32Error.ThrowLastError();
				RegisterWaitChainCOMCallback(p1, p2);
			}
		}

		/// <summary>Provides a handle to a thread wait chain.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct HWCT : IHandle
		{
			private IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="HWCT"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public HWCT(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="HWCT"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static HWCT NULL => new HWCT(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="HWCT"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(HWCT h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HWCT"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator HWCT(IntPtr h) => new HWCT(h);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(HWCT h1, HWCT h2) => !(h1 == h2);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(HWCT h1, HWCT h2) => h1.Equals(h2);

			/// <inheritdoc/>
			public override bool Equals(object obj) => obj is HWCT h ? handle == h.handle : false;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
		}

		/// <summary>Represents a node in a wait chain.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wct/ns-wct-waitchain_node_info typedef struct _WAITCHAIN_NODE_INFO {
		// WCT_OBJECT_TYPE ObjectType; WCT_OBJECT_STATUS ObjectStatus; union { struct { WCHAR ObjectName[WCT_OBJNAME_LENGTH]; LARGE_INTEGER
		// Timeout; BOOL Alertable; } LockObject; struct { DWORD ProcessId; DWORD ThreadId; DWORD WaitTime; DWORD ContextSwitches; }
		// ThreadObject; }; } WAITCHAIN_NODE_INFO, *PWAITCHAIN_NODE_INFO;
		[PInvokeData("wct.h", MSDNShortId = "7a333924-79a3-4522-aa5a-4fc60690667d")]
		[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
		public struct WAITCHAIN_NODE_INFO
		{
			/// <summary>The object type. This member is one of the following values from the <c>WCT_OBJECT_TYPE</c> enumeration type.</summary>
			[FieldOffset(0)]
			public WCT_OBJECT_TYPE ObjectType;

			/// <summary>
			/// The object status. This member is one of the following values from the <c>WCT_OBJECT_STATUS</c> enumeration type.
			/// </summary>
			[FieldOffset(4)]
			public WCT_OBJECT_STATUS ObjectStatus;

			/// <summary/>
			[FieldOffset(8)]
			public LOCKOBJECT LockObject;

			/// <summary/>
			[FieldOffset(8)]
			public THREADOBJECT ThreadObject;

			/// <summary/>
			[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode, Size = 272)]
			public struct LOCKOBJECT
			{
				[FieldOffset(0)]
				private long on0;

				/// <summary>This member is reserved for future use.</summary>
				[FieldOffset(256)]
				public long Timeout;

				/// <summary>This member is reserved for future use.</summary>
				[MarshalAs(UnmanagedType.Bool)]
				[FieldOffset(264)]
				public bool Alertable;

				/// <summary>
				/// The name of the object. Object names are only available for certain object, such as mutexes. If the object does not have
				/// a name, this member is an empty string.
				/// </summary>
				public string ObjectName
				{
					get
					{
						unsafe
						{
							fixed (void* pin = &on0)
								return StringHelper.GetString((IntPtr)pin, CharSet.Unicode, 128);
						}
					}
					set
					{
						unsafe
						{
							fixed (void* pin = &on0)
								StringHelper.Write(value, (IntPtr)pin, out _, true, CharSet.Unicode, 128);
						}
					}
				}
			}

			/// <summary/>
			[StructLayout(LayoutKind.Sequential)]
			public struct THREADOBJECT
			{
				/// <summary>The process identifier.</summary>
				public uint ProcessId;

				/// <summary>The thread identifier. For COM and ALPC, this member can be 0.</summary>
				public uint ThreadId;

				/// <summary>The wait time.</summary>
				public uint WaitTime;

				/// <summary>The number of context switches.</summary>
				public uint ContextSwitches;
			}
		}

		/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="HWCT"/> that is disposed using <see cref="CloseThreadWaitChainSession"/>.</summary>
		public class SafeHWCT : SafeHANDLE
		{
			/// <summary>Initializes a new instance of the <see cref="SafeHWCT"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafeHWCT(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SafeHWCT"/> class.</summary>
			private SafeHWCT() : base() { }

			/// <summary>Performs an implicit conversion from <see cref="SafeHWCT"/> to <see cref="HWCT"/>.</summary>
			/// <param name="h">The safe handle instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator HWCT(SafeHWCT h) => h.handle;

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() { CloseThreadWaitChainSession(handle); return true; }
		}
	}
}