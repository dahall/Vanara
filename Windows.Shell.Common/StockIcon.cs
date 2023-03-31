using System;
using Vanara.PInvoke;
using static Vanara.PInvoke.Gdi32;
using static Vanara.PInvoke.Shell32;
using static Vanara.PInvoke.User32;

namespace Vanara.Windows.Shell;

/// <summary>Represents a standard system icon.</summary>
public class StockIcon : IDisposable
{
	private SHGSI curFlags;
	private SHSTOCKICONID curId;
	private HICON hIcon;
	private IconLocation location;
	private int systemImageIndex;

	static StockIcon() => FileIconInit(false);

	/// <summary>Creates a new StockIcon instance with the specified identifer and options.</summary>
	/// <param name="id">A value that identifies the icon represented by this instance.</param>
	/// <param name="size">A value that indicates the size of the stock icon.</param>
	/// <param name="isLinkOverlay">A bool value that indicates whether the icon has a link overlay.</param>
	/// <param name="isSelected">A bool value that indicates whether the icon is in a selected state.</param>
	public StockIcon(SHSTOCKICONID id, ShellIconType size = ShellIconType.Large, bool isLinkOverlay = false, bool isSelected = false)
	{
		Identifier = id;
		LinkOverlay = isLinkOverlay;
		Selected = isSelected;
		Size = size;
	}

	/// <summary>Finalizes an instance of the <see cref="StockIcon"/> class.</summary>
	~StockIcon()
	{
		Dispose(false);
	}

	/// <summary>Gets the icon handle.</summary>
	/// <value>The icon handle.</value>
	public HICON IconHandle => hIcon;

	/// <summary>Gets or sets the Stock Icon identifier associated with this icon.</summary>
	public SHSTOCKICONID Identifier { get; set; }

	/// <summary>Gets or sets a value that cotrols whether to put a link overlay on the icon.</summary>
	/// <value>A <see cref="bool"/> value.</value>
	public bool LinkOverlay { get; set; }

	/// <summary>Gets the icon location, composed of a resource path and the icon's index.</summary>
	/// <value>The icon location.</value>
	public IconLocation Location { get { Refresh(); return location; } }

	/// <summary>Gets or sets a value indicating whether the icon appears selected.</summary>
	/// <value>A <see cref="bool"/> value.</value>
	public bool Selected { get; set; }

	/// <summary>Gets or sets a value that controls the size of the Stock Icon.</summary>
	/// <value>A <see cref="ShellIconType"/> value.</value>
	public ShellIconType Size { get; set; }

	/// <summary>Gets the index of the image in the system icon cache.</summary>
	/// <value>The index of the system image.</value>
	public int SystemImageIndex { get { Refresh(); return systemImageIndex; } }

	/// <summary>Release the native objects</summary>
	public void Dispose()
	{
		Dispose(true);
		System.GC.SuppressFinalize(this);
	}

	/// <summary>Release the native and managed objects</summary>
	/// <param name="disposing">Indicates that this is being called from Dispose(), rather than the finalizer.</param>
	protected virtual void Dispose(bool disposing)
	{
		if (disposing)
		{
			// dispose managed resources here
		}

		// Unmanaged resources
		if (hIcon != IntPtr.Zero)
			DestroyIcon(hIcon);
	}

	private SHGSI GetFlags() => SHGSI.SHGSI_ICON | SHGSI.SHGSI_ICONLOCATION | SHGSI.SHGSI_SYSICONINDEX | (SHGSI)Size | (Selected ? SHGSI.SHGSI_SELECTED : 0) | (LinkOverlay ? SHGSI.SHGSI_LINKOVERLAY : 0);

	private void Refresh()
	{
		var flags = GetFlags();
		if (curFlags == flags && curId == Identifier)
			return;

		if (hIcon != IntPtr.Zero)
		{
			DestroyIcon(hIcon);
			hIcon = default;
		}

		var info = SHSTOCKICONINFO.Default;
		var hr = SHGetStockIconInfo(curId = Identifier, curFlags = flags, ref info);

		// If we get an error, return null as the icon requested might not be supported on the current system
		if (hr == HRESULT.E_INVALIDARG)
			throw new InvalidOperationException("Invalid identifier.");
		else if (hr.Succeeded)
		{
			hIcon = info.hIcon;
			location = new IconLocation(info.szPath, info.iIcon);
			systemImageIndex = info.iSysImageIndex;
		}
		else
		{
			location = null;
			systemImageIndex = 0;
		}
	}
}