﻿using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Ole32
	{
		/// <summary>
		/// The function to be called inside the object context if <see cref="IContextCallback.ContextCallback(PFNCONTEXTCALL, in
		/// ComCallData, in Guid, int, IntPtr)"/>.
		/// </summary>
		/// <param name="data">The data passed to the function when it is called in the context.</param>
		/// <returns>The result. Typically the result of <see cref="CoDisconnectContext(uint)"/>.</returns>
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		[PInvokeData("ctxtcall.h", MSDNShortId = "NN:ctxtcall.IContextCallback")]
		public delegate HRESULT PFNCONTEXTCALL(in ComCallData data);

		/// <summary>Provides a mechanism to execute a function inside a specific COM+ object context.</summary>
		/// <remarks>An instance of this interface for the current context can be obtained using CoGetObjectContext.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctxtcall/nn-ctxtcall-icontextcallback
		[PInvokeData("ctxtcall.h", MSDNShortId = "NN:ctxtcall.IContextCallback")]
		[ComImport, Guid("000001da-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IContextCallback
		{
			/// <summary>Enters the object context, executes the specified function, and returns.</summary>
			/// <param name="pfnCallback">The function to be called inside the object context.</param>
			/// <param name="pParam">The data to be passed to the function when it is called in the context.</param>
			/// <param name="riid">The IID of the call that is being simulated. See Remarks for more information.</param>
			/// <param name="iMethod">The method number of the call that is being simulated. See Remarks for more information.</param>
			/// <param name="pUnk">This parameter is reserved and must be <c>NULL</c>.</param>
			/// <returns>
			/// This method can return the standard return values E_INVALIDARG, E_OUTOFMEMORY, E_UNEXPECTED, and E_FAIL. If none of these
			/// failures occur, the return value of this function is the <c>HRESULT</c> value returned by the pfnCallback function.
			/// </returns>
			/// <remarks>
			/// <para>
			/// This method simulates a method call on an object inside the context. It is intended for low-level operations, such as
			/// cleanup/lazy marshaling, that respect the application's reentrancy expectations.
			/// </para>
			/// <para>
			/// To give the infrastructure information, an interface and method number must be specified. The parameter riid must not be
			/// IID_IUnknown, and the method number must not be less than 3.
			/// </para>
			/// <para>If riid is set to IID_IEnterActivityWithNoLock, the function is executed without an activity lock.</para>
			/// <para>
			/// If riid is set to IID_ICallbackWithNoReentrancyToApplicationSTA, the function does not reenter an ASTA arbitrarily. Most
			/// apps should set riid to this values for general purpose use.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/ctxtcall/nf-ctxtcall-icontextcallback-contextcallback
			[PreserveSig]
			HRESULT ContextCallback(
				[MarshalAs(UnmanagedType.FunctionPtr)] PFNCONTEXTCALL pfnCallback,
				in ComCallData pParam,
				in Guid riid,
				int iMethod,
				[In, Optional] IntPtr pUnk);
		}

		/// <summary/>
		[PInvokeData("ctxtcall.h", MSDNShortId = "NN:ctxtcall.IContextCallback")]
		[StructLayout(LayoutKind.Sequential)]
		public struct ComCallData
		{
			/// <summary/>
			public int dwDispid;

			/// <summary/>
			public int dwReserved;

			/// <summary/>
			public IntPtr pUserDefined;
		}

		/// <summary>Provides a mechanism to execute a function inside a specific COM+ object context.</summary>
		/// <remarks>An instance of this interface for the current context can be obtained using CoGetObjectContext.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctxtcall/nn-ctxtcall-icontextcallback
		[ComImport, Guid("0000034e-0000-0000-C000-000000000046"), ClassInterface(ClassInterfaceType.None)]
		public class ContextSwitcher : IContextCallback
		{
			/// <inheritdoc/>
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
			public virtual extern HRESULT ContextCallback(
				[MarshalAs(UnmanagedType.FunctionPtr)] PFNCONTEXTCALL pfnCallback,
				in ComCallData pParam,
				in Guid riid,
				int iMethod,
				IntPtr pUnk = new IntPtr());
		}

		/// <summary>CLSID_ContextSwitcher</summary>
		public static readonly Guid CLSID_ContextSwitcher = new Guid(0x0000034e, 0x0000, 0x0000, 0xc0, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x46);

		/// <summary>IID_IEnterActivityWithNoLock</summary>
		public static readonly Guid IID_IEnterActivityWithNoLock = new Guid(0xd7174f82, 0x36b8, 0x4aa8, 0x80, 0x0a, 0xe9, 0x63, 0xab, 0x2d, 0xfa, 0xb9);

		/// <summary>IID_ICallbackWithNoReentrancyToApplicationSTA</summary>
		public static readonly Guid IID_ICallbackWithNoReentrancyToApplicationSTA = new Guid(0x0a299774, 0x3e4e, 0xfc42, 0x1d, 0x9d, 0x72, 0xce, 0xe1, 0x05, 0xca, 0x57);
	}
}