namespace Vanara.PInvoke;

public static partial class Shell32
{
	/// <summary>The direction that the slideshow should advance.</summary>
	[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.IDesktopWallpaper")]
	public enum DESKTOP_SLIDESHOW_DIRECTION
	{
		/// <summary>Advance the slideshow forward.</summary>
		DSD_FORWARD = 0,

		/// <summary>Advance the slideshow backward.</summary>
		DSD_BACKWARD = 1
	}

	/// <summary>Options for <see cref="IDesktopWallpaper"/>.</summary>
	[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.IDesktopWallpaper")]
	[Flags]
	public enum DESKTOP_SLIDESHOW_OPTIONS
	{
		/// <summary>Enable shuffle; advance through the slideshow in a random order.</summary>
		DSO_SHUFFLEIMAGES = 0x1
	}

	/// <summary>The status of the slideshow.</summary>
	[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.IDesktopWallpaper")]
	[Flags]
	public enum DESKTOP_SLIDESHOW_STATE
	{
		/// <summary>Slideshows are enabled.</summary>
		DSS_ENABLED = 0x1,

		/// <summary>A slideshow is currently configured.</summary>
		DSS_SLIDESHOW = 0x2,

		/// <summary>A remote session has temporarily disabled the slideshow.</summary>
		DSS_DISABLED_BY_REMOTE_SESSION = 0x4
	}

	/// <summary>Specifies how the desktop wallpaper should be displayed.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/ne-shobjidl_core-desktop_wallpaper_position typedef enum
	// DESKTOP_WALLPAPER_POSITION { DWPOS_CENTER, DWPOS_TILE, DWPOS_STRETCH, DWPOS_FIT, DWPOS_FILL, DWPOS_SPAN } ;
	[PInvokeData("shobjidl_core.h", MSDNShortId = "NE:shobjidl_core.DESKTOP_WALLPAPER_POSITION")]
	public enum DESKTOP_WALLPAPER_POSITION
	{
		/// <summary>Center the image; do not stretch. This is equivalent to the WPSTYLE_CENTER style in IActiveDesktop.</summary>
		DWPOS_CENTER,

		/// <summary>Tile the image across all monitors. This is equivalent to the WPSTYLE_TILE style in IActiveDesktop.</summary>
		DWPOS_TILE,

		/// <summary>Stretch the image to exactly fit on the monitor. This is equivalent to the WPSTYLE_STRETCH style in IActiveDesktop.</summary>
		DWPOS_STRETCH,

		/// <summary>
		/// Stretch the image to exactly the height or width of the monitor without changing its aspect ratio or cropping the image.
		/// This can result in colored letterbox bars on either side or on above and below of the image. This is equivalent to the
		/// WPSTYLE_KEEPASPECT style in IActiveDesktop.
		/// </summary>
		DWPOS_FIT,

		/// <summary>
		/// Stretch the image to fill the screen, cropping the image as necessary to avoid letterbox bars. This is equivalent to the
		/// WPSTYLE_CROPTOFIT style in IActiveDesktop.
		/// </summary>
		DWPOS_FILL,

		/// <summary>Spans a single image across all monitors attached to the system. This flag has no IActiveDesktop equivalent.</summary>
		DWPOS_SPAN,
	}

	/// <summary>Provides methods for managing the desktop wallpaper.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-idesktopwallpaper
	[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.IDesktopWallpaper")]
	[ComImport, Guid("B92B56A9-8B55-4E14-9A89-0199BBB6F93B"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(DesktopWallpaper))]
	public interface IDesktopWallpaper
	{
		/// <summary>Sets the desktop wallpaper.</summary>
		/// <param name="monitorID">
		/// The ID of the monitor. This value can be obtained through GetMonitorDevicePathAt. Set this value to NULL to set the
		/// wallpaper image on all monitors.
		/// </param>
		/// <param name="wallpaper">The full path of the wallpaper image file.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-idesktopwallpaper-setwallpaper HRESULT
		// SetWallpaper( LPCWSTR monitorID, LPCWSTR wallpaper );
		void SetWallpaper([MarshalAs(UnmanagedType.LPWStr)] string? monitorID, [MarshalAs(UnmanagedType.LPWStr)] string wallpaper);

		/// <summary>Gets the current desktop wallpaper.</summary>
		/// <param name="monitorID">
		/// <para>The ID of the monitor. This value can be obtained through GetMonitorDevicePathAt.</para>
		/// <para>
		/// This value can be set to <c>NULL</c>. In that case, if a single wallpaper image is displayed on all of the system's
		/// monitors, the method returns successfully. If this value is set to <c>NULL</c> and different monitors are displaying
		/// different wallpapers or a slideshow is running, the method returns S_FALSE and an empty string in the wallpaper parameter.
		/// </para>
		/// </param>
		/// <param name="wallpaper">
		/// <para>
		/// The address of a pointer to a buffer that, when this method returns successfully, receives the path to the wallpaper image
		/// file. Note that this image could be currently displayed on all of the system's monitors, not just the monitor specified in
		/// the monitorID parameter.
		/// </para>
		/// <para>
		/// This string will be empty if no wallpaper image is being displayed or if a monitor is displaying a solid color. The string
		/// will also be empty if the method fails.
		/// </para>
		/// </param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-idesktopwallpaper-getwallpaper HRESULT
		// GetWallpaper( LPCWSTR monitorID, LPWSTR *wallpaper );
		[PreserveSig]
		HRESULT GetWallpaper([MarshalAs(UnmanagedType.LPWStr)] string? monitorID, [MarshalAs(UnmanagedType.LPWStr)] out string wallpaper);

		/// <summary>Retrieves the unique ID of one of the system's monitors.</summary>
		/// <param name="monitorIndex">The number of the monitor. Call GetMonitorDevicePathCount to determine the total number of monitors.</param>
		/// <param name="monitorID">
		/// A pointer to the address of a buffer that, when this method returns successfully, receives the monitor's ID.
		/// </param>
		/// <returns>
		/// <para>
		/// If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code, including the following.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>A NULL pointer was provided in monitorID.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// This method can be called on monitors that are currently detached but that have an image assigned to them. Call
		/// GetMonitorRECT to distinguish between attached and detached monitors.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-idesktopwallpaper-getmonitordevicepathat
		// HRESULT GetMonitorDevicePathAt( UINT monitorIndex, LPWSTR *monitorID );
		[PreserveSig]
		HRESULT GetMonitorDevicePathAt(uint monitorIndex, [MarshalAs(UnmanagedType.LPWStr)] out string monitorID);

		/// <summary>Retrieves the number of monitors that are associated with the system.</summary>
		/// <returns>A pointer to a value that, when this method returns successfully, receives the number of monitors.</returns>
		/// <remarks>
		/// The count retrieved through this method includes monitors that are currently detached but that have an image assigned to
		/// them. Call GetMonitorRECT to distinguish between attached and detached monitors.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-idesktopwallpaper-getmonitordevicepathcount
		// HRESULT GetMonitorDevicePathCount( UINT *count );
		uint GetMonitorDevicePathCount();

		/// <summary>Retrieves the display rectangle of the specified monitor.</summary>
		/// <param name="monitorID">The ID of the monitor to query. You can get this value through GetMonitorDevicePathAt.</param>
		/// <param name="displayRect">
		/// A pointer to a RECT structure that, when this method returns successfully, receives the display rectangle of the monitor
		/// specified by monitorID, in screen coordinates.
		/// </param>
		/// <returns>
		/// <para>
		/// If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code, including the following.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>The monitor specified by monitorID is not currently attached to the system.</term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>A NULL pointer was provided in displayRect.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The ID supplied in monitorID cannot be found.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-idesktopwallpaper-getmonitorrect HRESULT
		// GetMonitorRECT( LPCWSTR monitorID, RECT *displayRect );
		[PreserveSig]
		HRESULT GetMonitorRECT([MarshalAs(UnmanagedType.LPWStr)] string monitorID, out RECT displayRect);

		/// <summary>
		/// Sets the color that is visible on the desktop when no image is displayed or when the desktop background has been disabled.
		/// This color is also used as a border when the desktop wallpaper does not fill the entire screen.
		/// </summary>
		/// <param name="color">A COLORREF value that specifies the background RGB color value.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-idesktopwallpaper-setbackgroundcolor
		// HRESULT SetBackgroundColor( COLORREF color );
		void SetBackgroundColor(COLORREF color);

		/// <summary>
		/// Retrieves the color that is visible on the desktop when no image is displayed or when the desktop background has been
		/// disabled. This color is also used as a border when the desktop wallpaper does not fill the entire screen.
		/// </summary>
		/// <returns>
		/// A pointer to a COLORREF value that, when this method returns successfully, receives the RGB color value. If this method
		/// fails, this value is set to 0.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-idesktopwallpaper-getbackgroundcolor
		// HRESULT GetBackgroundColor( COLORREF *color );
		COLORREF GetBackgroundColor();

		/// <summary>
		/// Sets the display option for the desktop wallpaper image, determining whether the image should be centered, tiled, or stretched.
		/// </summary>
		/// <param name="position">
		/// One of the DESKTOP_WALLPAPER_POSITION enumeration values that specify how the image will be displayed on the system's monitors.
		/// </param>
		/// <returns>
		/// <para>
		/// If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code, including the following.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>The desktop wallpaper is already displayed as asked for in position.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-idesktopwallpaper-setposition HRESULT
		// SetPosition( DESKTOP_WALLPAPER_POSITION position );
		[PreserveSig]
		HRESULT SetPosition(DESKTOP_WALLPAPER_POSITION position);

		/// <summary>Retrieves the current display value for the desktop background image.</summary>
		/// <returns>
		/// A pointer to a value that, when this method returns successfully, receives one of the DESKTOP_WALLPAPER_POSITION enumeration
		/// values that specify how the image is being displayed on the system's monitors.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-idesktopwallpaper-getposition HRESULT
		// GetPosition( DESKTOP_WALLPAPER_POSITION *position );
		DESKTOP_WALLPAPER_POSITION GetPosition();

		/// <summary>Specifies the images to use for the desktop wallpaper slideshow.</summary>
		/// <param name="items">
		/// A pointer to an IShellItemArray that contains the slideshow images. This array can contain individual items stored in the
		/// same container (files stored in a folder), or it can contain a single item which is the container itself (a folder that
		/// contains images). Any other configuration of the array will cause this method to fail.
		/// </param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-idesktopwallpaper-setslideshow HRESULT
		// SetSlideshow( IShellItemArray *items );
		void SetSlideshow(IShellItemArray items);

		/// <summary>Gets the images that are being displayed in the desktop wallpaper slideshow.</summary>
		/// <returns>
		/// The address of a pointer to an IShellItemArray object that, when this method returns successfully, receives the items that
		/// make up the slideshow. This array can contain individual items stored in the same container, or it can contain a single item
		/// which is the container itself.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-idesktopwallpaper-getslideshow HRESULT
		// GetSlideshow( IShellItemArray **items );
		IShellItemArray GetSlideshow();

		/// <summary>Sets the desktop wallpaper slideshow settings for shuffle and timing.</summary>
		/// <param name="options">
		/// <para>Set to either 0 to disable shuffle or the following value.</para>
		/// <para>DSO_SHUFFLEIMAGES (0x01)</para>
		/// <para>Enable shuffle; advance through the slideshow in a random order.</para>
		/// </param>
		/// <param name="slideshowTick">The amount of time, in milliseconds, between image transitions.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-idesktopwallpaper-setslideshowoptions
		// HRESULT SetSlideshowOptions( DESKTOP_SLIDESHOW_OPTIONS options, UINT slideshowTick );
		void SetSlideshowOptions(DESKTOP_SLIDESHOW_OPTIONS options, uint slideshowTick);

		/// <summary>Gets the current desktop wallpaper slideshow settings for shuffle and timing.</summary>
		/// <param name="options">
		/// <para>Type: <c>DESKTOP_SLIDESHOW_OPTIONS*</c></para>
		/// <para>
		/// A pointer to a value that, when this method returns successfully, receives either 0 to indicate that shuffle is disabled or
		/// the following value.
		/// </para>
		/// <para>DSO_SHUFFLEIMAGES (0x01)</para>
		/// <para>Shuffle is enabled; the images are shown in a random order.</para>
		/// </param>
		/// <param name="slideshowTick">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>
		/// A pointer to a value that, when this method returns successfully, receives the interval between image transitions, in milliseconds.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>
		/// If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code, including the following.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>A NULL pointer was provided in one of the parameters.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-idesktopwallpaper-getslideshowoptions
		// HRESULT GetSlideshowOptions( DESKTOP_SLIDESHOW_OPTIONS *options, UINT *slideshowTick );
		void GetSlideshowOptions(out DESKTOP_SLIDESHOW_OPTIONS options, out uint slideshowTick);

		/// <summary>Switches the wallpaper on a specified monitor to the next image in the slideshow.</summary>
		/// <param name="monitorID">
		/// The ID of the monitor on which to change the wallpaper image. This ID can be obtained through the GetMonitorDevicePathAt
		/// method. If this parameter is set to <c>NULL</c>, the monitor scheduled to change next is used.
		/// </param>
		/// <param name="direction">
		/// <para>The direction that the slideshow should advance. One of the following DESKTOP_SLIDESHOW_DIRECTION values:</para>
		/// <para>DSD_FORWARD (0)</para>
		/// <para>Advance the slideshow forward.</para>
		/// <para>DSD_BACKWARD (1)</para>
		/// <para>Advance the slideshow backward.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-idesktopwallpaper-advanceslideshow HRESULT
		// AdvanceSlideshow( LPCWSTR monitorID, DESKTOP_SLIDESHOW_DIRECTION direction );
		void AdvanceSlideshow([MarshalAs(UnmanagedType.LPWStr)] string? monitorID, DESKTOP_SLIDESHOW_DIRECTION direction);

		/// <summary>Gets the current status of the slideshow.</summary>
		/// <returns>
		/// <para>
		/// A pointer to a DESKTOP_SLIDESHOW_STATE value that, when this method returns successfully, receives one or more of the
		/// following flags.
		/// </para>
		/// <para>DSS_ENABLED (0x01)</para>
		/// <para>Slideshows are enabled.</para>
		/// <para>DSS_SLIDESHOW (0x02)</para>
		/// <para>A slideshow is currently configured.</para>
		/// <para>DSS_DISABLED_BY_REMOTE_SESSION (0x04)</para>
		/// <para>A remote session has temporarily disabled the slideshow.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-idesktopwallpaper-getstatus HRESULT
		// GetStatus( DESKTOP_SLIDESHOW_STATE *state );
		DESKTOP_SLIDESHOW_STATE GetStatus();

		/// <summary>Enables or disables the desktop background.</summary>
		/// <param name="enable"><c>TRUE</c> to enable the desktop background, <c>FALSE</c> to disable it.</param>
		/// <returns>
		/// <para>
		/// If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code, including the following.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>The desktop wallpaper is already in the state you're asking for through this call.</term>
		/// </item>
		/// <item>
		/// <term>E_FILE_NOT_FOUND</term>
		/// <term>
		/// The desktop wallpaper that would be used when the background is enabled is missing from its expected location. Call
		/// SetWallpaper to specify a new wallpaper.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>This method would normally be called to disable the desktop background for performance reasons.</para>
		/// <para>
		/// When the desktop background is disabled, a solid color is shown in its place. To get or set the specific color, use the
		/// GetBackgroundColor and SetBackgroundColor methods.
		/// </para>
		/// <para>
		/// <c>Note</c> A call to the IDesktopWallpaper_SetWallpaper or IDesktopWallpaper_SetSlideshow methods will enable the desktop
		/// background even if it is currently disabled through this method.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-idesktopwallpaper-enable HRESULT Enable(
		// BOOL enable );
		[PreserveSig]
		HRESULT Enable([MarshalAs(UnmanagedType.Bool)] bool enable);
	}

	/// <summary>CLSID_DesktopWallpaper</summary>
	[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.IDesktopWallpaper")]
	[ComImport, Guid("C2CF3110-460E-4fc1-B9D0-8A1C0C9CC4BD"), ClassInterface(ClassInterfaceType.None)]
	public class DesktopWallpaper { }
}