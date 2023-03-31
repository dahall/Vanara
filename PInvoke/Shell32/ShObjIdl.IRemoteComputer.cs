using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke;

public static partial class Shell32
{
	/// <summary>
	/// Exposes a method that enumerates or initializes a namespace extension when it is invoked on a remote object. This interface is
	/// used, for example, to initialize the remote printers virtual folder.
	/// </summary>
	/// <remarks>
	/// <para>Implement <c>IRemoteComputer</c> when your namespace extension may be invoked on a remote computer.</para>
	/// <para>
	/// You do not call this interface directly. <c>IRemoteComputer</c> is used by the operating system only when it has confirmed that
	/// your application is aware of this interface.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-iremotecomputer
	[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.IRemoteComputer")]
	[ComImport, Guid("000214FE-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IRemoteComputer
	{
		/// <summary>
		/// Used by Windows Explorer or Windows Internet Explorer when it is initializing or enumerating a namespace extension invoked
		/// on a remote computer.
		/// </summary>
		/// <param name="pszMachine">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>A pointer to a buffer containing the machine name of the remote computer.</para>
		/// </param>
		/// <param name="bEnumerating">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// A value that is set to <c>TRUE</c> if Windows Explorer is enumerating the namespace extension, or <c>FALSE</c> if it is
		/// initializing it.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns S_OK if successful, or standard OLE error values otherwise.</para>
		/// </returns>
		/// <remarks>
		/// If failure is returned, the extension won't appear for the specified computer. Otherwise, the extension will appear and
		/// target the remote computer.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iremotecomputer-initialize HRESULT
		// Initialize( LPCWSTR pszMachine, BOOL bEnumerating );
		[PreserveSig]
		HRESULT Initialize([MarshalAs(UnmanagedType.LPWStr)] string pszMachine, [MarshalAs(UnmanagedType.Bool)] bool bEnumerating);
	}
}