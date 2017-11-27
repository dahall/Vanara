using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Vanara.Extensions;
using static Vanara.PInvoke.ComCtl32;
using static Vanara.PInvoke.User32;

// ReSharper disable InconsistentNaming

namespace Vanara.Windows.Forms
{
	/// <summary>
	/// An Internet Protocol (IP) address control allows the user to enter an IP address in an easily understood format.
	/// </summary>
	/// <seealso cref="System.Windows.Forms.Control" />
	[DefaultEvent(nameof(FieldChanged)), DefaultProperty(nameof(Text))]
	//[Designer(typeof(IPAddressBoxDesigner))]
	public partial class IPAddressBox : Control
	{
		internal const string defaultText = "0.0.0.0";

		private BorderStyle borderStyle = BorderStyle.Fixed3D;

		/// <summary>Initializes a new instance of the <see cref="IPAddressBox"/> class.</summary>
		public IPAddressBox()
		{
			InitializeComponent();
			SetStyle(ControlStyles.FixedHeight, true);
			SetStyle(ControlStyles.StandardClick | ControlStyles.StandardDoubleClick | ControlStyles.UseTextForAccessibility | ControlStyles.UserPaint, false);
		}

		/// <summary>Occurs when one of the fields change. To change the value set in the control, set the <see cref="IPAddressFieldChangedEventArgs.Value"/> property.</summary>
		public event EventHandler<IPAddressFieldChangedEventArgs> FieldChanged;

		[Category("Appearance"), DefaultValue(BorderStyle.Fixed3D), Description("")]
		public BorderStyle BorderStyle
		{
			get => borderStyle; set
			{
				if (borderStyle != value)
				{
					borderStyle = value;
					UpdateStyles();
					RecreateHandle();
				}
			}
		}

		/// <summary>Gets or sets the IP address.</summary>
		/// <value>The IP address.</value>
		[Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public IPAddress IPAddress
		{
			get
			{
				var ip = UIntPtr.Zero;
				SendMessage(IPAddressMessage.IPM_GETADDRESS, UIntPtr.Zero, ip);
				return new IPAddress(GET_IPADDRESS(ip));
			}
			set
			{
				if (value != null && value.AddressFamily != AddressFamily.InterNetwork)
					throw new ArgumentException("Only IP v4 addresses are permissible.");
				try { SendMessage(IPAddressMessage.IPM_SETADDRESS, UIntPtr.Zero, MAKEIPADDRESS(value?.GetAddressBytes())); }
				catch (Exception e) { Debug.WriteLine($"set_IPAddress:{e}"); }
			}
		}

		/// <summary>Gets a value indicating whether the value is blank (0.0.0.0).</summary>
		/// <value><c>true</c> if the value is blank; otherwise, <c>false</c>.</value>
		[DefaultValue(true), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool IsBlank => SendMessage(IPAddressMessage.IPM_ISBLANK).ToInt32() > 0;

		[Category("Layout"), Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced),
		 DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Description("")]
		public int PreferredHeight
		{
			get
			{
				var height = FontHeight;
				if (borderStyle != BorderStyle.None)
					height += SystemInformation.BorderSize.Height*4 + 3;
				return height;
			}
		}

		/// <summary>Gets or sets the text associated with this control.</summary>
		/// <returns>The text associated with this control.</returns>
		[DefaultValue(defaultText)]
		public override string Text
		{
			get => base.Text; set
			{
				if (value == Name) return;
				if (!string.IsNullOrEmpty(value) && !System.Text.RegularExpressions.Regex.Match(value, @"^(?:[0-9]{1,3}\.){3}[0-9]{1,3}$").Success)
					throw new ArgumentException($"Invalid format. Text cannot be assigned a value of '{value}'.", nameof(Text));
				try { if (value != base.Text) IPAddress = string.IsNullOrEmpty(value) ? null : IPAddress.Parse(value); } catch { }
			}
		}

		/// <summary>Gets the required creation parameters when the control handle is created.</summary>
		protected override CreateParams CreateParams
		{
			get
			{
				var cp = base.CreateParams;
				cp.ClassName = WC_IPADDRESS;
				cp.ExStyle &= (~(int)WindowStylesEx.WS_EX_CLIENTEDGE);
				cp.Style &= (~(int)WindowStyles.WS_BORDER);
				switch (borderStyle)
				{
					case BorderStyle.Fixed3D:
						cp.ExStyle |= (int)WindowStylesEx.WS_EX_CLIENTEDGE;
						break;
					case BorderStyle.FixedSingle:
						cp.Style |= (int)WindowStyles.WS_BORDER;
						break;
				}
				cp.Height = 23;
				return cp;
			}
		}

		protected override Size DefaultSize => new Size(100, PreferredHeight);

		/// <summary>Clears the value and resets it to 0.0.0.0.</summary>
		public void Clear()
		{
			SendMessage(IPAddressMessage.IPM_CLEARADDRESS);
		}

		public override Size GetPreferredSize(Size proposedConstraints)
		{
			const string measureString = "  255  .  255  .  255  .  255  ";

			// 3px vertical space is required between the text and the border to keep the last
			// line from being clipped.
			// This 3 pixel size was added in everett and we do this to maintain compat.
			// old everett behavior was FontHeight + [SystemInformation.BorderSize.Height * 4 + 3]
			// however the [ ] was only added if borderstyle was not none.
			var bordersAndPadding = SizeFromClientSize(Size.Empty) + Padding.Size;

			if (BorderStyle != BorderStyle.None)
				bordersAndPadding += new Size(0, 3);

			if (BorderStyle == BorderStyle.FixedSingle)
			{
				// VSWhidbey 321520: bump these by 2px to match BorderStyle.Fixed3D - they'll be omitted from the SizeFromClientSize call.
				bordersAndPadding.Width += 2;
				bordersAndPadding.Height += 2;
			}
			// Reduce constraints by border/padding size
			proposedConstraints -= bordersAndPadding;

			// Fit the text to the remaining space
			// Fix for Dev10 

			var format = TextFormatFlags.NoPrefix;
			format |= TextFormatFlags.SingleLine;
			var textSize = TextRenderer.MeasureText(measureString, Font, proposedConstraints, format);

			// We use this old computation as a lower bound to ensure backwards compatibility.
			textSize.Height = Math.Max(textSize.Height, FontHeight);
			var preferredSize = textSize + bordersAndPadding;
			return preferredSize;
		}

		/// <summary>
		/// Sets the valid range for the specified field in the IP address control.
		/// </summary>
		/// <param name="field">A zero-based field index to which the range will be applied.</param>
		/// <param name="minValue">The lower limit of the range (inclusive).</param>
		/// <param name="maxValue">The upper limit of the range (inclusive).</param>
		/// <exception cref="System.ArgumentOutOfRangeException">field - Field must be a value from 0 to 3.</exception>
		public bool SetFieldRange(int field, byte minValue, byte maxValue)
		{
			if (field < 0 || field > 3)
				throw new ArgumentOutOfRangeException(nameof(field), @"Field must be a value from 0 to 3.");
			return SendMessage(IPAddressMessage.IPM_SETRANGE, (UIntPtr)field, MAKEIPRANGE(minValue, maxValue)).ToInt32() > 0;
		}

		/// <summary>Raises the <see cref="E:FieldChanged"/> event.</summary>
		/// <param name="e">The <see cref="IPAddressFieldChangedEventArgs"/> instance containing the event data.</param>
		protected void OnFieldChanged(IPAddressFieldChangedEventArgs e)
		{
			FieldChanged?.Invoke(this, e);
		}

		/// <summary>
		/// Processes reflected notification messages.
		/// </summary>
		/// <param name="m">The Windows <see cref="T:System.Windows.Forms.Message" /> to process.</param>
		/// <returns><c>true</c> if message handled; otherwise <c>false</c>.</returns>
		protected virtual bool WmReflectNotify(ref Message m)
		{
			var hdr = m.LParam.ToStructure<NMHDR>();
			if (hdr.code == (int)IPAddressNotification.IPN_FIELDCHANGED)
			{
				var ipAddr = m.LParam.ToStructure<NMIPADDRESS>();
				var e = new IPAddressFieldChangedEventArgs(ipAddr.iField, ipAddr.iValue);
				OnFieldChanged(e);
				if (e.Value != ipAddr.iValue)
					Marshal.WriteInt32(m.LParam, Marshal.OffsetOf(typeof(NMIPADDRESS), "iValue").ToInt32(), e.Value);
				return true;
			}
			return false;
		}

		/// <summary>Processes Windows messages.</summary>
		/// <param name="m">The Windows <see cref="T:System.Windows.Forms.Message"/> to process.</param>
		protected override void WndProc(ref Message m)
		{
			if (m.Msg == (int)WindowMessage.WM_REFLECT + (int)WindowMessage.WM_NOTIFY)
				if (WmReflectNotify(ref m))
					return;
			base.WndProc(ref m);
		}

		private IntPtr SendMessage(IPAddressMessage msg, UIntPtr wParam = default(UIntPtr), UIntPtr lParam = default(UIntPtr)) =>
			PInvoke.User32.SendMessage(new HandleRef(this, Handle), (uint)msg, wParam, lParam);
	}

	/// <summary>
	/// Contains the arguments needed to handle the <see cref="IPAddressBox.FieldChanged"/> event.
	/// </summary>
	/// <seealso cref="System.EventArgs" />
	public class IPAddressFieldChangedEventArgs : EventArgs
	{
		/// <summary>Initializes a new instance of the <see cref="IPAddressFieldChangedEventArgs"/> class.</summary>
		/// <param name="field">The IP address field (0-3).</param>
		/// <param name="value">The value for the indicated field.</param>
		internal IPAddressFieldChangedEventArgs(int field, int value)
		{
			Field = field;
			Value = (byte)value;
		}

		/// <summary>The zero-based number of the field that was changed.</summary>
		/// <value>The field number.</value>
		public int Field { get; }

		/// <summary>
		/// The new value of the field specified in the <see cref="Field"/> property. This property can be set to any value that is within the range of the field
		/// and the control will place this new value in the field.
		/// </summary>
		/// <value>The value set by the user on input and the value to place in the control on output.</value>
		public byte Value { get; set; }
	}

	/*internal class IPAddressBoxDesigner : Design.RichControlDesigner<IPAddressBox>
	{
		public override void InitializeNewComponent(IDictionary defaultValues)
		{
			base.InitializeNewComponent(defaultValues);
			var descriptor = TypeDescriptor.GetProperties(Control)["Text"];
			if ((descriptor != null) && (descriptor.PropertyType == typeof(string)) && !descriptor.IsReadOnly && descriptor.IsBrowsable)
				descriptor.SetValue(Control, IPAddressBox.defaultText);
		}
	}*/
}
