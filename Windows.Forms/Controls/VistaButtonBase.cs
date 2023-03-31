using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Windows.Forms;
using Vanara.Extensions;
using static Vanara.PInvoke.ComCtl32;
using static Vanara.PInvoke.User32;

namespace Vanara.Windows.Forms;

/// <summary>
/// Implements a CommandLink button that can be used in WinForms user interfaces.
/// </summary>
[ToolboxBitmap(typeof(Button))]
public abstract class VistaButtonBase : Button
{
	private Icon icon;
	private bool showShield;

	/// <summary>
	/// Initializes a new instance of the <see cref="CommandLink"/> class.
	/// </summary>
	protected VistaButtonBase()
	{
		base.FlatStyle = FlatStyle.System;
	}

	/*/// <summary>
	/// Gets or sets the flat style.
	/// </summary>
	/// <value>
	/// The flat style.
	/// </value>
	[Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DefaultValue(typeof(FlatStyle), "System")]
	public new FlatStyle FlatStyle
	{
		get { return base.FlatStyle; }
		set { base.FlatStyle = value; }
	}*/

	/// <summary>
	/// Gets or sets the icon that is displayed on a button control.
	/// </summary>
	[Description("Gets or sets the icon that is displayed on a button control."), Category("Appearance"), DefaultValue(null)]
	public Icon Icon
	{
		get => icon;
		set
		{
			icon = value;
			if (value != null)
				Image = null;
			ShowShield = false;
			SetImage();
		}
	}

	/// <summary>
	/// Gets or sets the image that is displayed on a button control.
	/// </summary>
	/// <PermissionSet>
	///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
	///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
	///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
	///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
	/// </PermissionSet>
	[Description("Gets or sets the image that is displayed on a button control."), Category("Appearance"), DefaultValue(null)]
	public new Image Image
	{
		get => base.Image;
		set
		{
			base.Image = value;
			if (value != null)
				Icon = null;
			ShowShield = false;
			SetImage();
		}
	}

	/// <summary>
	/// Gets or sets a value indicating whether to display an elevated shield icon.
	/// </summary>
	/// <value>
	///   <c>true</c> if showing shield icon; otherwise, <c>false</c>.
	/// </value>
	[Description("Gets or sets whether if the control should use an elevated shield icon."), Category("Appearance"), DefaultValue(false)]
	public bool ShowShield
	{
		get => showShield; set
		{
			if (showShield != value && IsHandleCreated)
			{
				showShield = value;
				this.SetElevationRequiredState(value);
			}
		}
	}

	internal static bool IsPlatformSupported { get; } = Environment.OSVersion.Version.Major >= 6;

	/// <summary>
	/// Raises the <see cref="E:System.Windows.Forms.Control.HandleCreated" /> event.
	/// </summary>
	/// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
	protected override void OnHandleCreated(EventArgs e)
	{
		base.OnHandleCreated(e);
		if (showShield)
			SetShowShield();
		if (Image != null || icon != null)
			SetImage();
	}

	private void SetShowShield()
	{
		if (!IsHandleCreated) return;
		SendMessage(Handle, (uint)ButtonMessage.BCM_SETSHIELD, IntPtr.Zero, showShield ? new IntPtr(1) : IntPtr.Zero);
	}

	/// <summary>
	/// Refreshes the image displayed on the button
	/// </summary>
	private void SetImage()
	{
		if (!IsHandleCreated) return;

		var iconhandle = IntPtr.Zero;
		if (Image != null)
			iconhandle = new Bitmap(Image).GetHicon();
		else if (icon != null)
			iconhandle = Icon.Handle;

		const uint BM_SETIMAGE = 0xF7;
		SendMessage(Handle, BM_SETIMAGE, (IntPtr)1, iconhandle);
	}
}