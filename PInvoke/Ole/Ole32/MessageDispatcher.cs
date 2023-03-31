using System;
using System.Runtime.InteropServices;
using System.Security;
using Vanara.InteropServices;

namespace Vanara.PInvoke;

public static partial class Ole32
{
	/// <summary>Represents the trust level of an activatable class.</summary>
	/// <remarks>
	/// <para>Classes can be activated depending on the trust level of the caller and the trust classification of the activatable class.</para>
	/// <para>RegisteredTrustLevel is an alias for this enumeration.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/inspectable/ne-inspectable-trustlevel typedef enum TrustLevel { BaseTrust,
	// PartialTrust, FullTrust } ;
	[PInvokeData("inspectable.h", MSDNShortId = "75E30E4B-EE5F-41C4-AC22-91D542E920EB")]
	public enum TrustLevel
	{
		/// <summary>The component has access to resources that are not protected.</summary>
		BaseTrust,

		/// <summary>The component has access to resources requested in the app manifest and approved by the user.</summary>
		PartialTrust,

		/// <summary>The component requires the full privileges of the user.</summary>
		FullTrust,
	}

	/// <summary>Provides functionality required for all Windows Runtime classes.</summary>
	/// <remarks><c>IInspectable</c> methods have no effect on COM apartments and are safe to call from user interface threads.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/inspectable/nn-inspectable-iinspectable
	[PInvokeData("inspectable.h", MSDNShortId = "0657E51F-D4C0-46C6-927D-B01E54B6846C")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("AF86E2E0-B12D-4c6a-9C5A-D7AA65101E90")]
	public interface IInspectable
	{
		/// <summary>Gets the interfaces that are implemented by the current Windows Runtime class.</summary>
		/// <param name="iidCount">
		/// <para>Type: <c>ULONG*</c></para>
		/// <para>
		/// The number of interfaces that are implemented by the current Windows Runtime object, excluding the IUnknown and IInspectable implementations.
		/// </para>
		/// </param>
		/// <param name="iids">
		/// <para>Type: <c>IID**</c></para>
		/// <para>
		/// A pointer to an array that contains an IID for each interface implemented by the current Windows Runtime object. The IUnknown
		/// and IInspectable interfaces are excluded.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This function can return the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The HSTRING was created successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>Failed to allocate iids.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Use the <c>GetIids</c> method to discover the interfaces that are implemented by a Windows Runtime object.</para>
		/// <para>A QueryInterface call on any IID in the iids array must succeed.</para>
		/// <para>The caller is responsible for freeing the IID array by using the CoTaskMemFree function.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/inspectable/nf-inspectable-iinspectable-getiids HRESULT GetIids( ULONG
		// *iidCount, IID **iids );
		[PreserveSig]
		HRESULT GetIids(out uint iidCount, out SafeCoTaskMemHandle iids);

		/// <summary>Gets the fully qualified name of the current Windows Runtime object.</summary>
		/// <param name="className">
		/// <para>Type: <c>HSTRING*</c></para>
		/// <para>The fully qualified name of the current Windows Runtime object.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This function can return the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The className string was created successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>Failed to allocate className string.</term>
		/// </item>
		/// <item>
		/// <term>E_ILLEGAL_METHOD_CALL</term>
		/// <term>className refers to a class factory or a static interface.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Use the <c>GetRuntimeClassName</c> method to retrieve the namespace-qualified name of a Windows Runtime object.</para>
		/// <para>The caller is responsible for freeing the className string by using the WindowsDeleteString function.</para>
		/// <para>The following table shows example class name strings that cold be returned by the <c>GetRuntimeClassName</c> method.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Example Class Name</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>Fabrikam.Kitchen.IToaster</term>
		/// <term>An interface in the Fabrikam.Kitchen namespace.</term>
		/// </item>
		/// <item>
		/// <term>Fabrikam.Kitchen.Chef</term>
		/// <term>An class in the Fabrikam.Kitchen namespace.</term>
		/// </item>
		/// <item>
		/// <term>Windows.Foundation.Collections.IVector`1&lt;TailspinToys.IStore&gt;</term>
		/// <term>A vector of TailspinToys.IStore interfaces.</term>
		/// </item>
		/// <item>
		/// <term>Windows.Foundation.Collections.IVector`1&lt;Windows.Foundation.Collections.IMapâ€™2&lt;String, TailspinToys.IStore&gt;&gt;</term>
		/// <term>A vector of maps of strings to TailspinToys.IStore interfaces.</term>
		/// </item>
		/// </list>
		/// <para>
		/// The <c>GetRuntimeClassName</c> method provides the most specific type information that the server object guarantees that it
		/// implements. The type name may be a runtime class name, interface group name, interface name, or parameterized interface name.
		/// </para>
		/// <para>
		/// The <c>GetRuntimeClassName</c> method returns <c>E_ILLEGAL_METHOD_CALL</c> if the class name refers to a class factory or a
		/// static interface.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/inspectable/nf-inspectable-iinspectable-getruntimeclassname HRESULT
		// GetRuntimeClassName( HSTRING *className );
		[PreserveSig]
		HRESULT GetRuntimeClassName([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(HStringMarshaler))] out string className);

		/// <summary>Gets the trust level of the current Windows Runtime object.</summary>
		/// <param name="trustLevel">
		/// <para>Type: <c>TrustLevel*</c></para>
		/// <para>The trust level of the current Windows Runtime object. The default is <c>BaseLevel</c>.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method always returns <c>S_OK</c>.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/inspectable/nf-inspectable-iinspectable-gettrustlevel HRESULT
		// GetTrustLevel( TrustLevel *trustLevel );
		[PreserveSig]
		HRESULT GetTrustLevel(out TrustLevel trustLevel);
	}

	/// <summary>
	/// Callback interface implemented by components that need to perform special processing of window messages on an ASTA thread.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/imessagedispatcher/nn-imessagedispatcher-imessagedispatcher
	[PInvokeData("imessagedispatcher.h", MSDNShortId = "60FD9084-CC79-48FE-AB26-C8FCB4288851")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("F5F84C8F-CFD0-4CD6-B66B-C5D26FF1689D")]
	public interface IMessageDispatcher : IInspectable
	{
		/// <summary>Gets the interfaces that are implemented by the current Windows Runtime class.</summary>
		/// <param name="iidCount">
		/// <para>Type: <c>ULONG*</c></para>
		/// <para>
		/// The number of interfaces that are implemented by the current Windows Runtime object, excluding the IUnknown and IInspectable implementations.
		/// </para>
		/// </param>
		/// <param name="iids">
		/// <para>Type: <c>IID**</c></para>
		/// <para>
		/// A pointer to an array that contains an IID for each interface implemented by the current Windows Runtime object. The IUnknown
		/// and IInspectable interfaces are excluded.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This function can return the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The HSTRING was created successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>Failed to allocate iids.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Use the <c>GetIids</c> method to discover the interfaces that are implemented by a Windows Runtime object.</para>
		/// <para>A QueryInterface call on any IID in the iids array must succeed.</para>
		/// <para>The caller is responsible for freeing the IID array by using the CoTaskMemFree function.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/inspectable/nf-inspectable-iinspectable-getiids HRESULT GetIids( ULONG
		// *iidCount, IID **iids );
		[PreserveSig]
		new HRESULT GetIids(out uint iidCount, out SafeCoTaskMemHandle iids);

		/// <summary>Gets the fully qualified name of the current Windows Runtime object.</summary>
		/// <param name="className">
		/// <para>Type: <c>HSTRING*</c></para>
		/// <para>The fully qualified name of the current Windows Runtime object.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This function can return the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The className string was created successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>Failed to allocate className string.</term>
		/// </item>
		/// <item>
		/// <term>E_ILLEGAL_METHOD_CALL</term>
		/// <term>className refers to a class factory or a static interface.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Use the <c>GetRuntimeClassName</c> method to retrieve the namespace-qualified name of a Windows Runtime object.</para>
		/// <para>The caller is responsible for freeing the className string by using the WindowsDeleteString function.</para>
		/// <para>The following table shows example class name strings that cold be returned by the <c>GetRuntimeClassName</c> method.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Example Class Name</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>Fabrikam.Kitchen.IToaster</term>
		/// <term>An interface in the Fabrikam.Kitchen namespace.</term>
		/// </item>
		/// <item>
		/// <term>Fabrikam.Kitchen.Chef</term>
		/// <term>An class in the Fabrikam.Kitchen namespace.</term>
		/// </item>
		/// <item>
		/// <term>Windows.Foundation.Collections.IVector`1&lt;TailspinToys.IStore&gt;</term>
		/// <term>A vector of TailspinToys.IStore interfaces.</term>
		/// </item>
		/// <item>
		/// <term>Windows.Foundation.Collections.IVector`1&lt;Windows.Foundation.Collections.IMapâ€™2&lt;String, TailspinToys.IStore&gt;&gt;</term>
		/// <term>A vector of maps of strings to TailspinToys.IStore interfaces.</term>
		/// </item>
		/// </list>
		/// <para>
		/// The <c>GetRuntimeClassName</c> method provides the most specific type information that the server object guarantees that it
		/// implements. The type name may be a runtime class name, interface group name, interface name, or parameterized interface name.
		/// </para>
		/// <para>
		/// The <c>GetRuntimeClassName</c> method returns <c>E_ILLEGAL_METHOD_CALL</c> if the class name refers to a class factory or a
		/// static interface.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/inspectable/nf-inspectable-iinspectable-getruntimeclassname HRESULT
		// GetRuntimeClassName( HSTRING *className );
		[PreserveSig]
		new HRESULT GetRuntimeClassName([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(HStringMarshaler))] out string className);

		/// <summary>Gets the trust level of the current Windows Runtime object.</summary>
		/// <param name="trustLevel">
		/// <para>Type: <c>TrustLevel*</c></para>
		/// <para>The trust level of the current Windows Runtime object. The default is <c>BaseLevel</c>.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method always returns <c>S_OK</c>.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/inspectable/nf-inspectable-iinspectable-gettrustlevel HRESULT
		// GetTrustLevel( TrustLevel *trustLevel );
		[PreserveSig]
		new HRESULT GetTrustLevel(out TrustLevel trustLevel);

		/// <summary>Performs custom dispatching when window messages are available to be dispatched on an ASTA thread.</summary>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/imessagedispatcher/nf-imessagedispatcher-imessagedispatcher-pumpmessages
		// HRESULT PumpMessages( );
		[PreserveSig]
		HRESULT PumpMessages();
	}

	/// <summary>
	/// Called by message dispatchers on an ASTA thread after dispatching a windows message to provide an opportunity for short-running
	/// infrastructural COM calls and other high-priority or short-running COM work to be dispatched between messages. This helps to
	/// provide similar responsiveness to these infrastructural calls in an ASTA as in a classic STA, even when there is a long stream of
	/// window messages to be handled.
	/// </summary>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	/// <remarks>
	/// <para>
	/// This function dispatches any high-priority COM calls or work that are queued on the ASTA thread, then returns. It returns quickly
	/// if there is no work to perform.
	/// </para>
	/// <para>This function silently does nothing when called on non-ASTA threads.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/messagedispatcherapi/nf-messagedispatcherapi-cohandlepriorityeventsfrommessagepump
	// void CoHandlePriorityEventsFromMessagePump( );
	[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("messagedispatcherapi.h", MSDNShortId = "24EA766D-82F8-4E57-AAB8-A06ECE644319")]
	public static extern void CoHandlePriorityEventsFromMessagePump();

	/// <summary>
	/// Registers or unregisters the per-thread message dispatcher that is to be invoked when there are window messages available to
	/// dispatch within COM wait APIs on an ASTA thread. This function is usually called by CoreWindow, but in certain circumstances
	/// other components that need to specialize how messages are dispatched on an ASTA thread can also call this function.
	/// </summary>
	/// <param name="pMessageDispatcher">
	/// If non-null, message dispatcher object to register. This object must also implement IWeakReferenceSource. If null, unregisters
	/// the current message dispatcher.
	/// </param>
	/// <remarks>
	/// <para>
	/// This function is supported only in ASTA threads. An attempt to set the message dispatcher on a non-ASTA thread silently fails
	/// with no side effects.
	/// </para>
	/// <para>An attempt to set an object that does not implement IWeakReferenceSource silently fails with no side effects.</para>
	/// <para>
	/// A call to this function with a valid and non-null pMessageDispatcher parameter registers this object to receive a PumpMessages
	/// callback whenever there are window messages available to dispatch with COM wait APIs on that ASTA thread. A Windows Runtime weak
	/// reference to this object is held, and the object receives callbacks, until the registration is replaced or the ASTA
	/// uninitialized. Each call to this function replaces the previously registered message dispatcher, if any.
	/// </para>
	/// <para>
	/// There is no way to check if a message dispatcher is registered on an ASTA thread or to retrieve a previously registered message
	/// dispatcher. This function should only be called under circumstances where it is known that this will not collide with another
	/// registration, specifically:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// In Windows Store app UI threads, this function is called by CoreWindow to register its dispatcher. No other components should
	/// call this function on these threads.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// UI frameworks may support an authoring mode, in which applications are run in the desktop environment and therefore do not have a
	/// CoreWindow in their UI threads. In lieu of CoreWindow support, these UI frameworks may register a message dispatcher on UI
	/// threads to handle special window message processing usually handled by CoreWindow (such as accelerators). It is not required to
	/// call this function if the UI framework has no need for this functionality.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// IAppVisibility browsers are not restricted to the Windows Store app APIs and therefore may have their own custom window message
	/// processing using user32 APIs. However, these applications still have ASTA UI threads as provided by app object, and may register
	/// a message dispatcher to handle this special processing. It is not required to call this function if the browser has no need for
	/// this functionality.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// The case of IAppVisibility browsers requires care to avoid CoreWindow replacing the browser’s message dispatcher. It is assumed
	/// that the browser has no need for CoreWindow’s dispatcher. The browser should call <c>CoSetMessageDispatcher</c> no sooner than
	/// its IViewProvider::Initialize, or, in the case of views that implement IInitializeWithWindowFactory, no sooner than after it has
	/// created a window on the thread.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/messagedispatcherapi/nf-messagedispatcherapi-cosetmessagedispatcher void
	// CoSetMessageDispatcher( PMessageDispatcher pMessageDispatcher );
	[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("messagedispatcherapi.h", MSDNShortId = "3D6CFE01-8D3D-474E-A7D0-9B129ECD4EEA")]
	public static extern void CoSetMessageDispatcher(IMessageDispatcher pMessageDispatcher);


	/// <summary>Marshals HSTRING values.</summary>
	/// <seealso cref="System.Runtime.InteropServices.ICustomMarshaler"/>
	internal class HStringMarshaler : ICustomMarshaler
	{
		private HStringMarshaler(string cookie)
		{
		}

		/// <summary>Gets the instance.</summary>
		/// <param name="cookie">The cookie.</param>
		/// <returns>A new instance of this class.</returns>
		public static ICustomMarshaler GetInstance(string cookie) => new HStringMarshaler(cookie);

		/// <summary>Performs necessary cleanup of the managed data when it is no longer needed.</summary>
		/// <param name="ManagedObj">The managed object to be destroyed.</param>
		public void CleanUpManagedData(object ManagedObj) { }

		/// <summary>Performs necessary cleanup of the unmanaged data when it is no longer needed.</summary>
		/// <param name="pNativeData">A pointer to the unmanaged data to be destroyed.</param>
		[SecurityCritical]
		public void CleanUpNativeData(IntPtr pNativeData)
		{
			if (pNativeData != IntPtr.Zero)
				WindowsDeleteString(pNativeData);
		}

		/// <summary>Returns the size of the native data to be marshaled.</summary>
		/// <returns>The size in bytes of the native data.</returns>
		public int GetNativeDataSize() => 0;

		/// <summary>Converts the managed data to unmanaged data.</summary>
		/// <param name="ManagedObj">The managed object to be converted.</param>
		/// <returns>Returns the COM view of the managed object.</returns>
		[SecurityCritical]
		public IntPtr MarshalManagedToNative(object ManagedObj)
		{
			var s = ManagedObj?.ToString();
			WindowsCreateString(s, s?.Length ?? 0, out var hstring).ThrowIfFailed();
			return hstring;
		}

		/// <summary>Converts the unmanaged data to managed data.</summary>
		/// <param name="pNativeData">A pointer to the unmanaged data to be wrapped.</param>
		/// <returns>Returns the managed view of the COM data.</returns>
		[SecurityCritical]
		public object MarshalNativeToManaged(IntPtr pNativeData) => pNativeData == IntPtr.Zero ? null : (string)WindowsGetStringRawBuffer(pNativeData, out var len);

		[DllImport("api-ms-win-core-winrt-string-l1-1-0.dll", CallingConvention = CallingConvention.StdCall)]
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		private static extern HRESULT WindowsCreateString([MarshalAs(UnmanagedType.LPWStr)] string sourceString, int length, out IntPtr hstring);

		[DllImport("api-ms-win-core-winrt-string-l1-1-0.dll", CallingConvention = CallingConvention.StdCall)]
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		private static extern HRESULT WindowsDeleteString(IntPtr hstring);

		[DllImport("api-ms-win-core-winrt-string-l1-1-0.dll", CallingConvention = CallingConvention.StdCall)]
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		private static extern StrPtrUni WindowsGetStringRawBuffer(IntPtr hstring, out uint length);
	}
}