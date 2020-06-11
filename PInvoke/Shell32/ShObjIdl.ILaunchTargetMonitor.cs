using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Shell32
	{
		/// <summary>Provides a method for retrieving the target monitor for the application being launched.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-ilaunchtargetmonitor
		[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.ILaunchTargetMonitor")]
		[ComImport, Guid("266FBC7E-490D-46ED-A96B-2274DB252003"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface ILaunchTargetMonitor
		{
			/// <summary>Retrieves the target monitor for the application being launched.</summary>
			/// <param name="monitor">
			/// <para>Type: <c>HMONITOR*</c></para>
			/// <para>Contains the address of a pointer to the target monitor's handle.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ilaunchtargetmonitor-getmonitor HRESULT
			// GetMonitor( HMONITOR *monitor );
			[PreserveSig]
			HRESULT GetMonitor(out HMONITOR monitor);
		}
	}
}