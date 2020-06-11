using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Shell32
	{
		/// <summary>
		/// Defines the set of possible general window (app view) size preferences. Used by
		/// ILaunchSourceViewSizePreference::GetSourceViewSizePreference and ILaunchTargetViewSizePreference::GetTargetViewSizePreference.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/ne-shobjidl_core-application_view_size_preference typedef enum
		// APPLICATION_VIEW_SIZE_PREFERENCE { AVSP_DEFAULT, AVSP_USE_LESS, AVSP_USE_HALF, AVSP_USE_MORE, AVSP_USE_MINIMUM, AVSP_USE_NONE,
		// AVSP_CUSTOM } ;
		[PInvokeData("shobjidl_core.h", MSDNShortId = "NE:shobjidl_core.APPLICATION_VIEW_SIZE_PREFERENCE")]
		public enum APPLICATION_VIEW_SIZE_PREFERENCE
		{
			/// <summary>
			/// The app does not specify a window size preference. Windows, rather than the app, sets the size preference, which defaults to AVSP_USE_HALF.
			/// </summary>
			AVSP_DEFAULT,

			/// <summary>Prefers to use less than 50% of the available horizontal screen pixels.</summary>
			AVSP_USE_LESS,

			/// <summary>Prefers to use 50% (half) of the available horizontal screen pixels.</summary>
			AVSP_USE_HALF,

			/// <summary>Prefers to use more than 50% of the available horizontal screen pixels.</summary>
			AVSP_USE_MORE,

			/// <summary>Prefers to use the minimum horizontal pixel width (either 320 or 500 pixels) specified in the app's manifest.</summary>
			AVSP_USE_MINIMUM,

			/// <summary>The window has no visible component.</summary>
			AVSP_USE_NONE,

			/// <summary/>
			AVSP_CUSTOM,
		}

		/// <summary>Provides a method for retrieving an AppUserModelId.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-ilaunchsourceappusermodelid
		[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.ILaunchSourceAppUserModelId")]
		[ComImport, Guid("989191AC-28FF-4CF0-9584-E0D078BC2396"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface ILaunchSourceAppUserModelId
		{
			/// <summary>Retrieves an AppUserModelId from the source application.</summary>
			/// <param name="launchingApp">
			/// <para>Type: <c>LPWSTR*</c></para>
			/// <para>Contains a pointer to a string that contains the AppUserModelId.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ilaunchsourceappusermodelid-getappusermodelid
			// HRESULT GetAppUserModelId( LPWSTR *launchingApp );
			[PreserveSig]
			HRESULT GetAppUserModelId([MarshalAs(UnmanagedType.LPWStr)] out string launchingApp);
		}

		/// <summary>Provides methods for retrieving information about the source application.</summary>
		/// <remarks>
		/// <para>When to implement</para>
		/// <para>--&gt;</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-ilaunchsourceviewsizepreference
		[ComImport, Guid("E5AA01F7-1FB8-4830-8720-4E6734CBD5F3"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface ILaunchSourceViewSizePreference
		{
			/// <summary>Retrieves the position of the source application window.</summary>
			/// <param name="hwnd">
			/// <para>Type: <c>HWND*</c></para>
			/// <para>Contains the address of a pointer to a window handle.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ilaunchsourceviewsizepreference-getsourceviewtoposition
			// HRESULT GetSourceViewToPosition( HWND *hwnd );
			[PreserveSig]
			HRESULT GetSourceViewToPosition(out HWND hwnd);

			/// <summary>Retrieves the view size preference of the application after the application has launched.</summary>
			/// <param name="sourceSizeAfterLaunch">
			/// <para>Type: <c>APPLICATION_VIEW_SIZE_PREFERENCE*</c></para>
			/// <para>Contains the address of a pointer to an APPLICATION_VIEW_SIZE_PREFERENCE.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ilaunchsourceviewsizepreference-getsourceviewsizepreference
			// HRESULT GetSourceViewSizePreference( APPLICATION_VIEW_SIZE_PREFERENCE *sourceSizeAfterLaunch );
			[PreserveSig]
			HRESULT GetSourceViewSizePreference(out APPLICATION_VIEW_SIZE_PREFERENCE sourceSizeAfterLaunch);
		}

		/// <summary>Provides a method for retrieving the preferred view size for a new application window.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-ilaunchtargetviewsizepreference
		[ComImport, Guid("2F0666C6-12F7-4360-B511-A394A0553725"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface ILaunchTargetViewSizePreference
		{
			/// <summary>Retrieves the preferred view size of the application being launched.</summary>
			/// <param name="targetSizeOnLaunch">
			/// <para>Type: <c>APPLICATION_VIEW_SIZE_PREFERENCE*</c></para>
			/// <para>Contains the address of a pointer to an APPLICATION_VIEW_SIZE_PREFERENCE for the target application.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ilaunchtargetviewsizepreference-gettargetviewsizepreference
			// HRESULT GetTargetViewSizePreference( APPLICATION_VIEW_SIZE_PREFERENCE *targetSizeOnLaunch );
			[PreserveSig]
			HRESULT GetTargetViewSizePreference(out APPLICATION_VIEW_SIZE_PREFERENCE targetSizeOnLaunch);
		}
	}
}