using System;
using System.Drawing;
using System.Windows.Forms;
using Vanara.PInvoke;
using static Vanara.PInvoke.DwmApi;

namespace Vanara.Windows.Forms;

/// <summary>Extracts all or a portion of a window and renders it as a thumbnail on another portion of the desktop.</summary>
public class LiveThumbnail : IDisposable
{
	private readonly HTHUMBNAIL hThumbnail;
	private DWM_THUMBNAIL_PROPERTIES tProps;

	/// <summary>Initializes a new instance of the <see cref="LiveThumbnail"/> class.</summary>
	/// <param name="win">The window.</param>
	internal LiveThumbnail(IWin32Window win)
	{
		hThumbnail = DesktopWindowManager.thumbnailMgr.Register(win);
		SourceClientAreaOnly = true;
		tProps.opacity = 255;
	}

	/// <summary>Gets or sets the area in the destination window where the thumbnail will be rendered.</summary>
	/// <value>The destination rectangle.</value>
	public Rectangle DestinationRectangle
	{
		get => tProps.rcDestination;
		set
		{
			tProps.dwFlags = DWM_TNP.DWM_TNP_RECTDESTINATION;
			tProps.rcDestination = value;
			DwmUpdateThumbnailProperties(hThumbnail, tProps).ThrowIfFailed();
		}
	}

	/// <summary>
	/// Gets or sets the opacity with which to render the thumbnail. 0 is fully transparent while 255 is fully opaque. The default value is 255.
	/// </summary>
	/// <value>The opacity.</value>
	public byte Opacity
	{
		get => tProps.opacity;
		set
		{
			tProps.dwFlags = DWM_TNP.DWM_TNP_OPACITY;
			tProps.opacity = value;
			DwmUpdateThumbnailProperties(hThumbnail, tProps).ThrowIfFailed();
		}
	}

	/// <summary>Gets or sets a value indicating whether to use only the thumbnail source's client area.</summary>
	/// <value>TRUE to use only the thumbnail source's client area; otherwise, FALSE. The default is FALSE.</value>
	public bool SourceClientAreaOnly
	{
		get => tProps.fSourceClientAreaOnly;
		set
		{
			tProps.dwFlags = DWM_TNP.DWM_TNP_SOURCECLIENTAREAONLY;
			tProps.fSourceClientAreaOnly = value;
			DwmUpdateThumbnailProperties(hThumbnail, tProps).ThrowIfFailed();
		}
	}

	/// <summary>Gets or sets the region of the source window to use as the thumbnail. By default, the entire window is used as the thumbnail.</summary>
	/// <value>The source region rectangle.</value>
	public Rectangle SourceRectangle
	{
		get => tProps.rcSource;
		set
		{
			tProps.dwFlags = DWM_TNP.DWM_TNP_RECTSOURCE;
			tProps.rcSource = value;
			DwmUpdateThumbnailProperties(hThumbnail, tProps).ThrowIfFailed();
		}
	}

	/// <summary>Gets the size of the source.</summary>
	/// <value>The size of the source.</value>
	public Size SourceSize
	{
		get
		{
			DwmQueryThumbnailSourceSize(hThumbnail, out var sz).ThrowIfFailed();
			return sz;
		}
	}

	/// <summary>Gets a value indicating whether this <see cref="LiveThumbnail"/> is visible.</summary>
	/// <value><c>true</c> if visible; otherwise, <c>false</c>.</value>
	public bool Visible
	{
		get => tProps.fVisible;
		private set
		{
			tProps.dwFlags = DWM_TNP.DWM_TNP_VISIBLE;
			tProps.fVisible = value;
			DwmUpdateThumbnailProperties(hThumbnail, tProps).ThrowIfFailed();
		}
	}

	/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
	public void Dispose() => DesktopWindowManager.thumbnailMgr.Unregister(hThumbnail);

	/// <summary>Hides the thumbnail.</summary>
	public void Hide() => Visible = false;

	/// <summary>Shows the thumbnail at the location specified by <see cref="DestinationRectangle"/>.</summary>
	public void Show() => Visible = true;

	/// <summary>Shows the thumbnail at the location specified by <paramref name="destRect"/>.</summary>
	/// <param name="destRect">The destination window where the thumbnail will be rendered.</param>
	public void Show(Rectangle destRect)
	{
		tProps.dwFlags = DWM_TNP.DWM_TNP_VISIBLE | DWM_TNP.DWM_TNP_RECTDESTINATION;
		tProps.fVisible = true;
		tProps.rcDestination = destRect;
		DwmUpdateThumbnailProperties(hThumbnail, tProps).ThrowIfFailed();
	}

	/// <summary>Shows the thumbnail at the location specified by <paramref name="destRect"/> and at the specified opacity.</summary>
	/// <param name="destRect">The destination window where the thumbnail will be rendered.</param>
	/// <param name="opacity">The opacity with which to render the thumbnail. 0 is fully transparent while 255 is fully opaque.</param>
	public void Show(Rectangle destRect, byte opacity)
	{
		tProps.dwFlags = DWM_TNP.DWM_TNP_VISIBLE | DWM_TNP.DWM_TNP_RECTDESTINATION | DWM_TNP.DWM_TNP_OPACITY;
		tProps.fVisible = true;
		tProps.rcDestination = destRect;
		tProps.opacity = opacity;
		DwmUpdateThumbnailProperties(hThumbnail, tProps).ThrowIfFailed();
	}
}