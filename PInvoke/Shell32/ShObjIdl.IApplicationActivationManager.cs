using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke;

public static partial class Shell32
{
	/// <summary>One or more of the following flags used to support design mode, debugging, and testing scenarios.</summary>
	[PInvokeData("shobjidl_core.h", MSDNShortId = "NF:shobjidl_core.IApplicationActivationManager.ActivateApplication")]
	[Flags]
	public enum ACTIVATEOPTIONS
	{
		/// <summary>No flags are set.</summary>
		AO_NONE = 0,

		/// <summary>
		/// The app is being activated for design mode, so it can't create its normal window. The creation of the app's window must be
		/// done by design tools that load the necessary components by communicating with a designer-specified service on the site chain
		/// established through the activation manager. Note that this means that the splash screen seen during regular activations
		/// won't be seen.
		/// <para>Note that you must enable debug mode on the app's package to succesfully use design mode.</para>
		/// </summary>
		AO_DESIGNMODE = 0x1,

		/// <summary>Do not display an error dialog if the app fails to activate.</summary>
		AO_NOERRORUI = 0x2,

		/// <summary>
		/// Do not display the app's splash screen when the app is activated. You must enable debug mode on the app's package when you
		/// use this flag; otherwise, the PLM will terminate the app after a few seconds.
		/// </summary>
		AO_NOSPLASHSCREEN = 0x4,

		/// <summary>The application is being activated in prelaunch mode. This value is supported starting in Windows 10.</summary>
		AO_PRELAUNCH = 0x2000000
	}

	/// <summary>
	/// Provides methods which activate Windows Store apps for the Launch, File, and Protocol extensions. You will normally use this
	/// interface in debuggers and design tools.
	/// </summary>
	/// <remarks>
	/// <para>When to Implement</para>
	/// <para>
	/// Do not implement this interface yourself. Windows provides an implementation as part of the CApplicationActivationManager class.
	/// To get an instance of this class, call CoCreateInstance with the CLSID_ApplicationActivationManager class ID.
	/// </para>
	/// <para>Usage notes</para>
	/// <para>
	/// An <c>IApplicationActivationManager</c> object creates a thread in its host process to serve any activated event arguments
	/// objects (LaunchActivatedEventArgs, FileActivatedEventArgs, and ProtocolActivatedEventArgs) that are passed to the app. If the
	/// calling process is long-lived, you can create this object in-proc, based on the assumption that the event arguments will exist
	/// long enough for the target app to use them. However, if the calling process is spawned only to launch the target app, it should
	/// create the <c>IApplicationActivationManager</c> object out-of-process, by using CLSCTX_LOCAL_SERVER. This causes the object to
	/// be created in a Dllhost.exe instance that automatically manages the object's lifetime based on outstanding references to the
	/// activated event argument objects.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-iapplicationactivationmanager
	[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.IApplicationActivationManager")]
	[ComImport, Guid("2e941141-7f97-4756-ba1d-9decde894a3d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(ApplicationActivationManager))]
	public interface IApplicationActivationManager
	{
		/// <summary>Activates the specified Windows Store app for the generic launch contract (Windows.Launch) in the current session.</summary>
		/// <param name="appUserModelId">The application user model ID of the Windows Store app.</param>
		/// <param name="arguments">A pointer to an optional, app-specific, argument string.</param>
		/// <param name="options">
		/// <para>One or more of the following flags used to support design mode, debugging, and testing scenarios.</para>
		/// <para>AO_NONE (0x00000000)</para>
		/// <para>No flags are set.</para>
		/// <para>AO_DESIGNMODE (0x00000001)</para>
		/// <para>
		/// The app is being activated for design mode, so it can't create its normal window. The creation of the app's window must be
		/// done by design tools that load the necessary components by communicating with a designer-specified service on the site chain
		/// established through the activation manager. Note that this means that the splash screen seen during regular activations
		/// won't be seen.
		/// </para>
		/// <para>Note that you must enable debug mode on the app's package to succesfully use design mode.</para>
		/// <para>AO_NOERRORUI (0x00000002)</para>
		/// <para>Do not display an error dialog if the app fails to activate.</para>
		/// <para>AO_NOSPLASHSCREEN (0x00000004)</para>
		/// <para>
		/// Do not display the app's splash screen when the app is activated. You must enable debug mode on the app's package when you
		/// use this flag; otherwise, the PLM will terminate the app after a few seconds.
		/// </para>
		/// <para>AO_PRELAUNCH (0x2000000)</para>
		/// <para>The application is being activated in prelaunch mode. This value is supported starting in Windows 10.</para>
		/// </param>
		/// <param name="processId">
		/// A pointer to a value that, when this method returns successfully, receives the process ID of the app instance that fulfils
		/// this contract.
		/// </param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iapplicationactivationmanager-activateapplication
		// HRESULT ActivateApplication( LPCWSTR appUserModelId, LPCWSTR arguments, ACTIVATEOPTIONS options, DWORD *processId );
		void ActivateApplication([MarshalAs(UnmanagedType.LPWStr)] string appUserModelId, [MarshalAs(UnmanagedType.LPWStr)] string arguments, ACTIVATEOPTIONS options, out uint processId);

		/// <summary>Activates the specified Windows Store app for the file contract (Windows.File).</summary>
		/// <param name="appUserModelId">The application user model ID of the Windows Store app.</param>
		/// <param name="itemArray">
		/// A pointer to an array of Shell items, each representing a file. This value is converted to a VectorView of StorageItem
		/// objects that is passed to the app through FileActivatedEventArgs.
		/// </param>
		/// <param name="verb">The verb being applied to the file or files specified by itemArray.</param>
		/// <param name="processId">
		/// A pointer to a value that, when this method returns successfully, receives the process ID of the app instance that fulfils
		/// this contract.
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iapplicationactivationmanager-activateforfile
		// HRESULT ActivateForFile( LPCWSTR appUserModelId, IShellItemArray *itemArray, LPCWSTR verb, DWORD *processId );
		void ActivateForFile([MarshalAs(UnmanagedType.LPWStr)] string appUserModelId, IShellItemArray itemArray, [MarshalAs(UnmanagedType.LPWStr)] string verb, out uint processId);

		/// <summary>Activates the specified Windows Store app for the protocol contract (Windows.Protocol).</summary>
		/// <param name="appUserModelId">The application user model ID of the Windows Store app.</param>
		/// <param name="itemArray">
		/// A pointer to an array of a single Shell item. The first item in the array is converted into a Uri object that is passed to
		/// the app through ProtocolActivatedEventArgs. Any items in the array except for the first element are ignored.
		/// </param>
		/// <param name="processId">
		/// A pointer to a value that, when this method returns successfully, receives the process ID of the app instance that fulfils
		/// this contract.
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iapplicationactivationmanager-activateforprotocol
		// HRESULT ActivateForProtocol( LPCWSTR appUserModelId, IShellItemArray *itemArray, DWORD *processId );
		void ActivateForProtocol([MarshalAs(UnmanagedType.LPWStr)] string appUserModelId, IShellItemArray itemArray, out uint processId);
	}

	/// <summary>CLSID_ApplicationActivationManager</summary>
	[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.IDesktopWallpaper")]
	[ComImport, Guid("45BA127D-10A8-46EA-8AB7-56EA9078943C"), ClassInterface(ClassInterfaceType.None)]
	public class ApplicationActivationManager { }
}