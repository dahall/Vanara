using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Vanara.Extensions;
using static Vanara.PInvoke.Shell32;

namespace Vanara.Windows.Shell;

/// <summary></summary>
public enum Visibility : byte
{
	/// <summary>The collapsed</summary>
	Collapsed = 2,

	/// <summary>The hidden</summary>
	Hidden = 1,

	/// <summary>The visible</summary>
	Visible = 0
}

/// <summary>A button in the toolbar associated with thumbnails displayed on a taskbar button.</summary>
/// <seealso cref="System.ComponentModel.INotifyPropertyChanged"/>
[DefaultProperty("Description"), DefaultEvent("Click")]
public partial class ThumbnailToolbarButton : INotifyPropertyChanged
{
	internal THUMBBUTTON btn;
	internal ImageIndexer indexer = new();
	private Icon icon;
	private ThumbnailToolbar parent;
	private Visibility visibility;

	/// <summary>Initializes a new instance of the <see cref="ThumbnailToolbarButton"/> class.</summary>
	public ThumbnailToolbarButton()
	{
	}

	/// <summary>Occurs when the button is clicked.</summary>
	[Category("Behavior")]
	public event EventHandler Click;

	/// <summary>Occurs when a property has changed.</summary>
	public event PropertyChangedEventHandler PropertyChanged;

	/// <summary>Gets or sets the description displayed as a tooltip for the button.</summary>
	/// <value>The description text.</value>
	[DefaultValue(null), Category("Appearance")]
	public string Description
	{
		get => btn.szTip;
		set { btn.szTip = value; btn.dwMask |= THUMBBUTTONMASK.THB_TOOLTIP; OnPropertyChanged(); }
	}

	/// <summary>Gets or sets a value indicating whether to dismiss the thumbnail when this button is clicked.</summary>
	/// <value><see langword="true"/> to dismiss when clicked; otherwise, <see langword="false"/>.</value>
	[DefaultValue(false), Category("Behavior")]
	public bool DismissWhenClicked
	{
		get => GetFlagValue(THUMBBUTTONFLAGS.THBF_DISMISSONCLICK);
		set => SetFlagValue(THUMBBUTTONFLAGS.THBF_DISMISSONCLICK, value);
	}

	/// <summary>Gets or sets a value indicating whether to draw the button's border.</summary>
	/// <value><see langword="true"/> if button border is drawn; otherwise, <see langword="false"/>.</value>
	[DefaultValue(true), Category("Appearance")]
	public bool DrawButtonBorder
	{
		get => !GetFlagValue(THUMBBUTTONFLAGS.THBF_NOBACKGROUND);
		set => SetFlagValue(THUMBBUTTONFLAGS.THBF_NOBACKGROUND, !value);
	}

	/// <summary>Gets or sets the icon shown on the toolbar button.</summary>
	/// <value>The button icon.</value>
	[Description("ButtonImageDescr"), Localizable(true), Category("Appearance")]
	[DefaultValue(null)]
	public Icon Icon
	{
		get => icon;
		set
		{
			if (icon != value)
			{
				icon = value;
				if (icon != null)
					ImageIndex = -1;
				UpdateImageInfo();
				OnPropertyChanged();
			}
		}
	}

	/// <summary>Gets or sets the index of the image from <see cref="ThumbnailToolbar.ImageList"/>.</summary>
	/// <value>The index of the image.</value>
	/// <exception cref="ArgumentOutOfRangeException">ImageIndex</exception>
	[TypeConverter(typeof(ImageIndexConverter)), Editor("System.Windows.Forms.Design.ImageIndexEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor)), Localizable(true), DefaultValue(-1), RefreshProperties(RefreshProperties.Repaint)]
	[Description("ButtonImageIndexDescr"), Category("Appearance")]
	public int ImageIndex
	{
		get
		{
			if (indexer.Index != -1 && Parent?.ImageList != null && indexer.Index >= Parent.ImageList.Images.Count)
				return Parent.ImageList.Images.Count - 1;
			return indexer.Index;
		}
		set
		{
			if (value < -1)
				throw new ArgumentOutOfRangeException(nameof(ImageIndex));

			if (indexer.Index != value)
			{
				if (value != -1)
					icon = null;
				indexer.Index = value;
				UpdateImageInfo();
				OnPropertyChanged();
			}
		}
	}

	/// <summary>Gets or sets the image key of the image from <see cref="ThumbnailToolbar.ImageList"/>.</summary>
	/// <value>The image key value.</value>
	[TypeConverter(typeof(ImageKeyConverter)), Editor("System.Windows.Forms.Design.ImageIndexEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor)), Localizable(true), DefaultValue(""), RefreshProperties(RefreshProperties.Repaint)]
	[Description("ButtonImageIndexDescr"), Category("Appearance")]
	public string ImageKey
	{
		get => indexer.Key;
		set
		{
			if (indexer.Key != value)
			{
				if (value != null)
					icon = null;
				indexer.Key = value;
				UpdateImageInfo();
				OnPropertyChanged();
			}
		}
	}

	/// <summary>Gets or sets a value indicating whether this button is enabled.</summary>
	/// <value><see langword="true"/> if this button is enabled; otherwise, <see langword="false"/>.</value>
	[DefaultValue(true), Category("Behavior")]
	public bool IsEnabled
	{
		get => !GetFlagValue(THUMBBUTTONFLAGS.THBF_DISABLED);
		set => SetFlagValue(THUMBBUTTONFLAGS.THBF_DISABLED, !value);
	}

	/// <summary>
	/// Gets or sets a value indicating whether this button is interactive. If <see langword="false"/>, no pressed button state is
	/// drawn. This is intended for instances where the button is used in a notification.
	/// </summary>
	/// <value><see langword="true"/> if this button is interactive; otherwise, <see langword="false"/>.</value>
	[DefaultValue(true), Category("Behavior")]
	public bool IsInteractive
	{
		get => !GetFlagValue(THUMBBUTTONFLAGS.THBF_NONINTERACTIVE);
		set => SetFlagValue(THUMBBUTTONFLAGS.THBF_NONINTERACTIVE, !value);
	}

	/// <summary>Gets or sets the visibility of the button.</summary>
	/// <value>The button visibility.</value>
	[DefaultValue(typeof(Visibility), "Visible"), Category("Appearance")]
	public Visibility Visibility
	{
		get => visibility;
		set { if (visibility != value) { visibility = value; OnPropertyChanged(); } }
	}

	internal ThumbnailToolbar Parent
	{
		get => parent;
		set
		{
			parent = value;
			indexer.ImageList = value.ImageList;
		}
	}

	internal void InvokeClick() => Click?.Invoke(this, EventArgs.Empty);

	/// <summary>Called when a property has changed.</summary>
	/// <param name="propName">Name of the property.</param>
	protected virtual void OnPropertyChanged([CallerMemberName] string propName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));

	private bool GetFlagValue(THUMBBUTTONFLAGS f) => btn.dwFlags.IsFlagSet(f);

	private void SetFlagValue(THUMBBUTTONFLAGS f, bool value, [CallerMemberName] string memberName = "")
	{
		btn.dwFlags = btn.dwFlags.SetFlags(f, value);
		btn.dwMask |= THUMBBUTTONMASK.THB_FLAGS;
		OnPropertyChanged(memberName);
	}

	private void UpdateImageInfo()
	{
		if (icon == null && indexer.ActualIndex >= 0)
		{
			btn.dwMask |= THUMBBUTTONMASK.THB_ICON | THUMBBUTTONMASK.THB_BITMAP;
			btn.hIcon = IntPtr.Zero;
			btn.iBitmap = (uint)indexer.ActualIndex;
		}
		else
		{
			btn.dwMask |= THUMBBUTTONMASK.THB_ICON | THUMBBUTTONMASK.THB_BITMAP;
			if (icon == null)
				btn.hIcon = IntPtr.Zero;
			else
				btn.hIcon = icon.Handle;
			btn.iBitmap = 0;
		}
	}
}