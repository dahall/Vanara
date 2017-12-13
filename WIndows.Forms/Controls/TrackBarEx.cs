using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Vanara.Extensions;
using Vanara.PInvoke;
using static Vanara.PInvoke.ComCtl32;
using static Vanara.PInvoke.Macros;
using static Vanara.PInvoke.User32_Gdi;

namespace Vanara.Windows.Forms
{
	/// <summary>Extends the <see cref="TrackBar"/> class to provide full native-control functionality.</summary>
	/// <seealso cref="System.Windows.Forms.TrackBar"/>
	public class TrackBarEx : TrackBar
	{
		private bool autoTicks = true;
		private int cumulativeWheelData;
		private int lastValue;
		private bool limitThumbToSel, showSel;
		private int requestedDim;
		private int selMin, selMax, thumbLength = -1;
		private int[] ticks;

		/// <summary>Initializes a new instance of the <see cref="TrackBarEx"/> class.</summary>
		public TrackBarEx()
		{
			SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			BackColorChanged += (o, a) => { if (IsHandleCreated) RecreateHandle(); };
			requestedDim = PreferredDimension;
		}

		/// <summary>Occurs when the channel for a <see cref="TrackBarEx"/> needs to be drawn and the <see cref="OwnerDraw"/> property is set to <c>true</c>.</summary>
		public event PaintEventHandler DrawChannel;

		/// <summary>Occurs when the thumb for a <see cref="TrackBarEx"/> needs to be drawn and the <see cref="OwnerDraw"/> property is set to <c>true</c>.</summary>
		public event PaintEventHandler DrawThumb;

		/// <summary>Occurs when the ticks for a <see cref="TrackBarEx"/> need to be drawn and the <see cref="OwnerDraw"/> property is set to <c>true</c>.</summary>
		public event PaintEventHandler DrawTics;

		/// <summary>Gets or sets a value indicating whether to draw ticks based on the <see cref="TrackBar.TickFrequency"/> interval.</summary>
		/// <value><c>true</c> if automatic ticks should be shown; otherwise, <c>false</c>.</value>
		[DefaultValue(true), Category("Appearance"), Description("Specifies whether to automatically draw tick marks at the frequency defined by TickFreqency.")]
		public bool AutoTicks
		{
			get => autoTicks;
			set
			{
				if (autoTicks == value) return;
				autoTicks = value;
				if (IsHandleCreated) RecreateHandle();
			}
		}

		/// <summary>Gets the bounds of the channel (slider track).</summary>
		/// <value>The channel bounds.</value>
		[Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Rectangle ChannelBounds
		{
			get
			{
				var r = new RECT();
				if (IsHandleCreated)
					SendMsg(TrackBarMessage.TBM_GETCHANNELRECT, ref r);
				return r;
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether to limit thumb movement to the selection.
		/// </summary>
		/// <value><c>true</c> if movement is limited to selection; otherwise, <c>false</c>.</value>
		[DefaultValue(false), Category("Appearance"), Description("Indicates if thumb movement is limited to the selection range.")]
		public bool LimitThumbToSelection
		{
			get => limitThumbToSel;
			set
			{
				if (limitThumbToSel == value) return;
				limitThumbToSel = value;
				if (!showSel) return;
				if (Value < SelectionStart)
					Value = SelectionStart;
				else if (Value > SelectionEnd)
					Value = SelectionEnd;
			}
		}

		/// <summary>Gets or sets a value indicating the horizontal or vertical orientation of the track bar.</summary>
		[DefaultValue(Orientation.Horizontal), Category("Appearance"), Description("Indicates orientation of the trackbar.")]
		public new Orientation Orientation
		{
			get => base.Orientation;
			set
			{
				//valid values are 0x0 to 0x1
				if (value != Orientation.Horizontal && value != Orientation.Vertical)
					throw new InvalidEnumArgumentException(nameof(Orientation), (int)value, typeof(Orientation));

				if (base.Orientation != value)
				{
					if (value == Orientation.Horizontal)
						Width = requestedDim;
					else
						Height = requestedDim;

					base.Orientation = value;

					if (IsHandleCreated)
						AdjustSize();
				}
			}
		}

		/// <summary>Gets or sets a value indicating whether the control is drawn by the operating system or by code that you provide.</summary>
		/// <value><c>true</c> if the control is drawn by code that you provide; <c>false</c> if the control is drawn by the operating system. The default is <c>false</c>.</value>
		[DefaultValue(false), Category("Behavior"), Description("Specifies whether to custom draw the trackbar.")]
		public bool OwnerDraw { get; set; }

		/// <summary>Gets or sets the upper limit of the selection range this TrackBar is working with.</summary>
		/// <value>The logical position at which the selection ends. This value must be less than or equal to the value of the <see cref="TrackBar.Maximum"/> property.</value>
		[DefaultValue(0), Category("Behavior"), Description("The ending logical position of the current selection range in a trackbar.")]
		public int SelectionEnd
		{
			get => selMax;
			set => SetSelectionRange(selMin, value);
		}

		/// <summary>Gets or sets the lower limit of the selection range this TrackBar is working with.</summary>
		/// <value>The logical position at which the selection starts. This value must be greater than or equal to the value of the <see cref="TrackBar.Minimum"/> property.</value>
		[DefaultValue(0), Category("Behavior"), Description("The starting logical position of the current selection range in a trackbar.")]
		public int SelectionStart
		{
			get => selMin;
			set => SetSelectionRange(value, selMax);
		}

		/// <summary>Gets or sets a value indicating whether to show the selection area defined by <see cref="SelectionStart"/> and <see cref="SelectionEnd"/>.</summary>
		/// <value><c>true</c> if showing selection area; otherwise, <c>false</c>.</value>
		[DefaultValue(false), Category("Appearance"), Description("Indicates if the TaskBar shows a selection range.")]
		public bool ShowSelection
		{
			get => showSel;
			set
			{
				if (showSel == value) return;
				showSel = value;
				if (IsHandleCreated) RecreateHandle();
			}
		}

		/// <summary>Gets the bounds of the thumb slider in its current position.</summary>
		/// <value>The thumb bounds.</value>
		[Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Rectangle ThumbBounds
		{
			get
			{
				var r = new RECT();
				if (IsHandleCreated)
					SendMsg(TrackBarMessage.TBM_GETTHUMBRECT, ref r);
				return r;
			}
		}

		/// <summary>Gets or sets the length of the thumb, overriding the default.</summary>
		/// <value>The length of the thumb. This is the vertical length if the orientation is horizontal and the horizontal length if the orientation is vertical.</value>
		[Category("Appearance"), Description("The length of the slider in a trackbar.")]
		public int ThumbLength
		{
			get => IsHandleCreated ? SendMsg(TrackBarMessage.TBM_GETTHUMBLENGTH).ToInt32() : (thumbLength == -1 ? (TickStyle == TickStyle.Both ? 21 : 19) : thumbLength);
			set
			{
				if (thumbLength == value) return;
				thumbLength = value;
				if (IsHandleCreated) RecreateHandle();
			}
		}

		/// <summary>Gets or sets an array that contains the positions of the tick marks for a trackbar.</summary>
		/// <value>The elements of the array specify the logical positions of the trackbar's tick marks, not including the first and last tick marks created by the trackbar. The logical positions can be any of the integer values in the trackbar's range of minimum to maximum slider positions.</value>
		[DefaultValue(null), Category("Appearance"), Description("Indicates the logical values of the trackbar where ticks are drawn.")]
		public int[] TickPositions
		{
			get
			{
				if (!IsHandleCreated || TickStyle == TickStyle.None) return null;
				var ptr = SendMsg(TrackBarMessage.TBM_GETPTICS);
				return ptr.ToIEnum<int>(SendMsg(TrackBarMessage.TBM_GETNUMTICS).ToInt32() - 2).OrderBy(i => i).Distinct().ToArray();
			}
			set
			{
				if (value != null)
				{
					if (value.Min() < Minimum || value.Max() > Maximum) throw new ArgumentOutOfRangeException(nameof(TickPositions), "All values must be between Minimum and Maximum range values.");
					if (TickStyle == TickStyle.None) throw new ArgumentException("Tick positions cannot be set when TickStyle is None.");
				}
				if (ticks != null) SendMsg(TrackBarMessage.TBM_CLEARTICS);
				ticks = value;
				if (IsHandleCreated)
					RecreateHandle();
			}
		}

		/// <inheritdoc />
		protected override CreateParams CreateParams
		{
			get
			{
				var cp = base.CreateParams;
				cp.Style |= (int)TrackBarStyle.TBS_NOTIFYBEFOREMOVE;
				cp.Style = showSel ? cp.Style | (int)TrackBarStyle.TBS_ENABLESELRANGE : cp.Style & ~(int)TrackBarStyle.TBS_ENABLESELRANGE;
				cp.Style = BackColor == Color.Transparent ? cp.Style | (int)TrackBarStyle.TBS_TRANSPARENTBKGND : cp.Style & ~(int)TrackBarStyle.TBS_TRANSPARENTBKGND;
				cp.Style = thumbLength >= 0 ? cp.Style | (int)TrackBarStyle.TBS_FIXEDLENGTH : cp.Style & ~(int)TrackBarStyle.TBS_FIXEDLENGTH;
				cp.Style = autoTicks && TickStyle != TickStyle.None ? cp.Style | (int)TrackBarStyle.TBS_AUTOTICKS : cp.Style & ~(int)TrackBarStyle.TBS_AUTOTICKS;
				return cp;
			}
		}

		/// <inheritdoc />
		protected override Size DefaultSize => new Size(104, PreferredDimension);

		private int PreferredDimension
		{
			get
			{
				var track = TickStyle == TickStyle.None ? 6 : (TickStyle == TickStyle.Both ? 22 : 14);
				return ThumbLength + track;
			}
		}

		/// <summary>Sets the starting and ending positions for the available selection range in a trackbar.</summary>
		/// <param name="rangeMin">The starting logical position for the selection range.</param>
		/// <param name="rangeMax">The ending logical position for the selection range.</param>
		/// <param name="redrawAll">If this parameter is TRUE, the trackbar is redrawn after the selection range is set. If this parameter is FALSE, the message sets the selection range but does not redraw the trackbar.</param>
		public void SetSelectionRange(int rangeMin, int rangeMax, bool redrawAll = true)
		{
			if (rangeMin == selMin && rangeMax == selMax) return;
			if (rangeMin < 0) throw new ArgumentOutOfRangeException(nameof(rangeMin));
			if (rangeMax < 0 || rangeMax < rangeMin) throw new ArgumentOutOfRangeException(nameof(rangeMax));
			if (rangeMin == rangeMax)
			{
				ShowSelection = false;
			}
			else
			{
				ShowSelection = true;
				if (rangeMin < Minimum) rangeMin = Minimum;
				if (rangeMin > Maximum) rangeMax = Maximum;
			}
			selMin = rangeMin;
			selMax = rangeMax;
			SendMsg(TrackBarMessage.TBM_SETSELEND, 0, rangeMax);
			SendMsg(TrackBarMessage.TBM_SETSELSTART, redrawAll ? 1 : 0, rangeMin);
		}

		/// <summary>Adjusts the size of the control.</summary>
		protected virtual void AdjustSize()
		{
			if (IsHandleCreated)
			{
				var saveDim = requestedDim;
				try
				{
					if (Orientation == Orientation.Horizontal)
						Height = AutoSize ? PreferredDimension : saveDim;
					else
						Width = AutoSize ? PreferredDimension : saveDim;
				}
				finally
				{
					requestedDim = saveDim;
				}
			}
		}

		/// <inheritdoc />
		protected override void OnAutoSizeChanged(EventArgs e)
		{
			base.OnAutoSizeChanged(e);
			AdjustSize();
		}

		/// <summary>Raises the <see cref="E:DrawChannel" /> event.</summary>
		/// <param name="pe">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
		/// <returns>If overwritten, the method should return <c>true</c> to indicate that all drawing has been done by the method and the system should not draw this item. If this method returns <c>false</c>, the system will draw the item.</returns>
		protected virtual bool OnDrawChannel(PaintEventArgs pe)
		{
			DrawChannel?.Invoke(this, pe);
			return DrawChannel != null;
		}

		/// <summary>Raises the <see cref="E:DrawThumb" /> event.</summary>
		/// <param name="pe">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
		/// <returns>If overwritten, the method should return <c>true</c> to indicate that all drawing has been done by the method and the system should not draw this item. If this method returns <c>false</c>, the system will draw the item.</returns>
		protected virtual bool OnDrawThumb(PaintEventArgs pe)
		{
			DrawThumb?.Invoke(this, pe);
			return DrawThumb != null;
		}

		/// <summary>Raises the <see cref="E:DrawTics" /> event.</summary>
		/// <param name="pe">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
		/// <returns>If overwritten, the method should return <c>true</c> to indicate that all drawing has been done by the method and the system should not draw this item. If this method returns <c>false</c>, the system will draw the item.</returns>
		protected virtual bool OnDrawTics(PaintEventArgs pe)
		{
			DrawTics?.Invoke(this, pe);
			return DrawTics != null;
		}

		/// <inheritdoc />
		protected override void OnHandleCreated(EventArgs e)
		{
			base.OnHandleCreated(e);
			if (showSel) SetSelectionRange(selMin, selMax);
			if (thumbLength >= 0) SendMsg(TrackBarMessage.TBM_SETTHUMBLENGTH, thumbLength);
			if (ticks != null && TickStyle != TickStyle.None) SetTicks();
			AdjustSize();
		}

		protected override void OnMouseWheel(MouseEventArgs e)
		{
			const int WHEEL_DELTA = 120;
			var hme = e as HandledMouseEventArgs;
			if (hme != null)
			{
				if (hme.Handled) return;
				hme.Handled = true;
			}
 
			if ((ModifierKeys & (Keys.Shift | Keys.Alt)) != 0 || MouseButtons != MouseButtons.None)
				return; // Do not scroll when Shift or Alt key is down, or when a mouse button is down.
 
			var wheelScrollLines = SystemInformation.MouseWheelScrollLines;
			if (wheelScrollLines == 0) return; // Do not scroll when the user system setting is 0 lines per notch
 
			Debug.Assert(cumulativeWheelData > -WHEEL_DELTA, "cumulativeWheelData is too small");
			Debug.Assert(cumulativeWheelData < WHEEL_DELTA, "cumulativeWheelData is too big");
			cumulativeWheelData += e.Delta;

			var partialNotches = cumulativeWheelData / (float)WHEEL_DELTA;
 
			if (wheelScrollLines == -1)
				wheelScrollLines = TickFrequency;
 
			// Evaluate number of bands to scroll
			var scrollBands = (int)(wheelScrollLines * partialNotches);
 
			if (scrollBands != 0)
			{
				int absScrollBands;
				if (scrollBands > 0) {
					absScrollBands = scrollBands;
					Value = Math.Min(absScrollBands+Value, showSel && limitThumbToSel ? selMax : Maximum);
					cumulativeWheelData -= (int)(scrollBands * (WHEEL_DELTA / (float)wheelScrollLines));
				}
				else {
					absScrollBands = -scrollBands;
					Value = Math.Max(Value-absScrollBands, showSel && limitThumbToSel ? selMin : Minimum);
					cumulativeWheelData -= (int)(scrollBands * (WHEEL_DELTA / (float)wheelScrollLines));
				}
			}
 
			if (e.Delta != Value) {
				OnScroll(EventArgs.Empty);
				OnValueChanged(EventArgs.Empty);
			}
		}

		protected override void OnValueChanged(EventArgs e)
		{
			base.OnValueChanged(e);
			Debug.WriteLine($">> TB ValueChg={Value} from {lastValue}");
			lastValue = Value;
		}

		/// <summary>Sends the supplied message and parameters to the underlying TRACKBAR system control.</summary>
		/// <param name="msg">The Windows message identifier.</param>
		/// <param name="wParam">The wParam.</param>
		/// <param name="lParam">The lParam.</param>
		/// <returns>The result value defined for the message.</returns>
		protected IntPtr SendMsg(TrackBarMessage msg, int wParam = 0, int lParam = 0) => IsHandleCreated ? SendMessage(new HandleRef(this, Handle), (uint)msg, wParam, lParam) : IntPtr.Zero;

		/// <inheritdoc />
		protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
		{
			requestedDim = Orientation == Orientation.Horizontal ? height : width;

			if (AutoSize)
			{
				if (Orientation == Orientation.Horizontal)
				{
					if ((specified & BoundsSpecified.Height) != BoundsSpecified.None)
						height = PreferredDimension;
				}
				else
				{
					if ((specified & BoundsSpecified.Width) != BoundsSpecified.None)
						width = PreferredDimension;
				}
			}
			// Call base method on Control and not TrackBar
			typeof(Control).GetMethod("SetBoundsCore", BindingFlags.Instance | BindingFlags.NonPublic).InvokeNotOverride(this, x, y, width, height, specified);
		}

		/// <inheritdoc />
		protected override void WndProc(ref Message m)
		{
			var msg = (WindowMessage) m.Msg;
			//Debug.WriteLine($"TB WndProc: Msg={msg}");
			if (msg == (WindowMessage.WM_NOTIFY | WindowMessage.WM_REFLECT))
			{
				if (OwnerDraw)
				{
					var hdr = (NMHDR)m.GetLParam(typeof(NMHDR));
					if (hdr.code == (int) CommonControlNotification.NM_CUSTOMDRAW)
					{
						var cd = (NMCUSTOMDRAW) m.GetLParam(typeof(NMCUSTOMDRAW));
						Debug.WriteLine($"{new TimeSpan(Environment.TickCount)} TBCustDraw: {cd.dwDrawStage}, {cd.dwItemSpec.ToInt32()}, {cd.uItemState}, {(Rectangle) cd.rc}");
						m.Result = new IntPtr((int) CustomDraw(ref cd));
						return;
					}
				}
			}
			else if (msg == (WindowMessage.WM_HSCROLL | WindowMessage.WM_REFLECT) || msg == (WindowMessage.WM_VSCROLL | WindowMessage.WM_REFLECT))
			{
				var pos = Value;
				var code = (TrackBarScrollNotification)LOWORD(m.WParam);
				Debug.WriteLine($"TB_SCROLL: pos={pos}, lastPos={lastValue}, code={code}, sel={showSel}, limit={limitThumbToSel}, selMin={selMin}, selMax={selMax}");
				if (showSel && limitThumbToSel)
				{
					if (pos > selMax) SendMsg(TrackBarMessage.TBM_SETPOS, 1, selMax);
					else if (pos < selMin) SendMsg(TrackBarMessage.TBM_SETPOS, 1, selMin);
				}
				if (code != TrackBarScrollNotification.TB_THUMBPOSITION && code != TrackBarScrollNotification.TB_ENDTRACK && lastValue != Value)
				{
					var e = new ScrollEventArgs((ScrollEventType)code, lastValue, pos, m.Msg == (int)WindowMessage.WM_HSCROLL ? ScrollOrientation.HorizontalScroll : ScrollOrientation.VerticalScroll);
					OnScroll(e);
					OnValueChanged(EventArgs.Empty);
				}
				return;
			}
			base.WndProc(ref m);
		}

		private CustomDrawResponse CustomDraw(ref NMCUSTOMDRAW cd)
		{
			switch (cd.dwDrawStage)
			{
				case CustomDrawStage.CDDS_PREPAINT:
					return CustomDrawResponse.CDRF_NOTIFYITEMDRAW; // | CustomDrawResponse.CDRF_NOTIFYPOSTPAINT;

				case CustomDrawStage.CDDS_ITEMPREPAINT:
					switch ((TrackBarCustomDraw)cd.dwItemSpec.ToInt32())
					{
						case TrackBarCustomDraw.TBCD_CHANNEL:
							using (var g = Graphics.FromHdc(cd.hdc))
							{
								if (OnDrawChannel(new PaintEventArgs(g, cd.rc)))
									return CustomDrawResponse.CDRF_SKIPDEFAULT;
							}
							break;

						case TrackBarCustomDraw.TBCD_THUMB:
							using (var g = Graphics.FromHdc(cd.hdc))
							{
								if (OnDrawThumb(new PaintEventArgs(g, cd.rc)))
									return CustomDrawResponse.CDRF_SKIPDEFAULT;
							}
							break;

						case TrackBarCustomDraw.TBCD_TICS:
							using (var g = Graphics.FromHdc(cd.hdc))
							{
								if (OnDrawTics(new PaintEventArgs(g, cd.rc)))
									return CustomDrawResponse.CDRF_SKIPDEFAULT;
							}
							break;
					}
					break;
			}
			return CustomDrawResponse.CDRF_DODEFAULT;
		}

		private void ResetThumbLength()
		{
			thumbLength = -1;
			if (IsHandleCreated) RecreateHandle();
		}

		private IntPtr SendMsg(TrackBarMessage msg, ref RECT rect) => SendMessage(new HandleRef(this, Handle), (uint)msg, IntPtr.Zero, ref rect);

		private void SetTicks()
		{
			if (ticks == null) return;
			foreach (var t in ticks)
				SendMsg(TrackBarMessage.TBM_SETTIC, 0, t);
		}

		private bool ShouldSerializeThumbLength() => thumbLength >= 0;

		private bool ShouldSerializeTickPositions() => ticks != null;
	}
}