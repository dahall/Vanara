using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Shell32
	{
		/// <summary>
		/// Enables a client of Shell item activation (including callers of ShellExecuteEx and IContextMenu::InvokeCommand) to be given a
		/// chance to veto or perform some action before the activation of verb handlers.
		/// </summary>
		/// <remarks>
		/// This interface is implemented by an object reachable through the site chain provided to ShellExecuteEx or the context menu
		/// handler. Applications will return this object in their <c>IServiceProvider::QueryService</c> implementation when asked for the
		/// service ID <c>SID_SHandlerActivationHost</c>.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-ihandleractivationhost
		[ComImport, Guid("35094a87-8bb1-4237-96c6-c417eebdb078"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IHandlerActivationHost
		{
			/// <summary>
			/// Notifies a client of ShellExecuteEx that a handler is about to be created, giving that client the opportunity to display UI
			/// confirming the use of that handler or reject it by returning a specific error code.
			/// </summary>
			/// <param name="clsidHandler">Identifies the handler.</param>
			/// <param name="itemsBeingActivated">
			/// The Shell item objects that will be passed to the handler. Typically there is only one, but in some cases there can be more
			/// than one.
			/// </param>
			/// <param name="handlerInfo">
			/// Provides access to information about the handler that will be invoked. This object also supports <c>IHandlerInfo2</c> on
			/// versions of Windows that support that interface.
			/// </param>
			/// <returns>
			/// If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code,
			/// <c>HRESULT_FROM_WIN32(ERROR_CANCELLED)</c> inciates that the ShellExecute call should be canceled,
			/// <c>EXECUTE_E_LAUNCH_APPLICATION</c> indicates that this handler should not be used, but if there is another it should be used.
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ihandleractivationhost-beforecocreateinstance
			// HRESULT BeforeCoCreateInstance( REFCLSID clsidHandler, IShellItemArray *itemsBeingActivated, IHandlerInfo *handlerInfo );
			[PreserveSig]
			HRESULT BeforeCoCreateInstance(in Guid clsidHandler, IShellItemArray itemsBeingActivated, IHandlerInfo handlerInfo);

			/// <summary>
			/// Notifies a client of ShellExecuteEx that a process is about to created, giving that client the opportunity to display UI
			/// confirming that or reject it by returning a specific error code.
			/// </summary>
			/// <param name="applicationPath">The fully qualified path to the process executable, or in some cases a DLL path.</param>
			/// <param name="commandLine">
			/// The full command line that will be passed to <c>CreateProcess</c> including the arguments that the handler requested via its registration.
			/// </param>
			/// <param name="handlerInfo">
			/// Provides access to information about the handler that will be invoked. This object also supports <c>IHandlerInfo2</c> on
			/// versions of windows that support that interface. This object also implements IObjectWithSelection. This can be used to get
			/// the Shell item, or items in some cases, that are being launched.
			/// </param>
			/// <returns>
			/// If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code,
			/// <c>HRESULT_FROM_WIN32(ERROR_CANCELLED)</c> inciates that the ShellExecute call should be canceled.
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ihandleractivationhost-beforecreateprocess
			// HRESULT BeforeCreateProcess( LPCWSTR applicationPath, LPCWSTR commandLine, IHandlerInfo *handlerInfo );
			[PreserveSig]
			HRESULT BeforeCreateProcess([MarshalAs(UnmanagedType.LPWStr)] string applicationPath, [MarshalAs(UnmanagedType.LPWStr)] string commandLine, IHandlerInfo handlerInfo);
		}

		/// <summary>Supplies methods that provide information about the handler to methods of the IHandlerActivationHost interface.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-ihandlerinfo
		[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.IHandlerInfo")]
		[ComImport, Guid("997706ef-f880-453b-8118-39e1a2d2655a"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IHandlerInfo
		{
			/// <summary>Retrieves the display name of the application that implemented the handler.</summary>
			/// <param name="value">
			/// <para>Type: <c>LPWSTR*</c></para>
			/// <para>
			/// A pointer to a string that, when this method returns successfully, receives the display name. If no display name could be
			/// found, the name of the application's .exe file is used.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ihandlerinfo-getapplicationdisplayname
			// HRESULT GetApplicationDisplayName( LPWSTR *value );
			[PreserveSig]
			HRESULT GetApplicationDisplayName([MarshalAs(UnmanagedType.LPWStr)] out string value);

			/// <summary>Retrieves the name of the publisher of the application that implemented the handler.</summary>
			/// <param name="value">
			/// <para>Type: <c>LPWSTR*</c></para>
			/// <para>A pointer to a string that, when this method returns successfully, receives the publisher's name.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ihandlerinfo-getapplicationpublisher
			// HRESULT GetApplicationPublisher( LPWSTR *value );
			[PreserveSig]
			HRESULT GetApplicationPublisher([MarshalAs(UnmanagedType.LPWStr)] out string value);

			/// <summary>Retrieves the icon of the application that implemented the handler.</summary>
			/// <param name="value">
			/// <para>Type: <c>LPWSTR*</c></para>
			/// <para>A pointer to a string that, when this method returns successfully, receives the path of the icon.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ihandlerinfo-getapplicationiconreference
			// HRESULT GetApplicationIconReference( LPWSTR *value );
			[PreserveSig]
			HRESULT GetApplicationIconReference([MarshalAs(UnmanagedType.LPWStr)] out string value);
		}

		/// <summary>Undocumented.</summary>
		/// <seealso cref="Vanara.PInvoke.Shell32.IHandlerInfo"/>
		[PInvokeData("shobjidl_core.h")]
		[ComImport, Guid("31cca04c-04d3-4ea9-90de-97b15e87a532"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IHandlerInfo2 : IHandlerInfo
		{
			/// <summary>Undocumented.</summary>
			/// <param name="value">
			/// <para>Type: <c>LPWSTR*</c></para>
			/// <para>A pointer to a string that, when this method returns successfully, receives the application identifier.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			[PreserveSig]
			HRESULT GetApplicationId([MarshalAs(UnmanagedType.LPWStr)] out string value);
		}
	}
}