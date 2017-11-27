using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Vanara.Windows.Forms.Annotations;

namespace Vanara.Windows.Forms
{
	public class ButtonStateManager : IDisposable, INotifyPropertyChanged, IButtonControl
	{
		private PushButtonState currentState;
		private Size oldSize;
		private PushButtonState oldState;

		/// <summary>Initializes a new instance of the BufferedPainter class.</summary>
		/// <param name="control">
		/// Control this instance is attached to.
		/// <para>For best results, use a control which does not paint its background.</para>
		/// <para>Note: Buffered painting does not work if the OptimizedDoubleBuffer newDS is set for the control.</para>
		/// </param>
		public ButtonStateManager(Control control)
		{
			currentState = oldState = PushButtonState.Normal;

			Control = control;
			oldSize = Control.Size;

			Control.EnabledChanged += Control_EnabledChanged;
			Control.GotFocus += Control_GotFocus;
			Control.LostFocus += Control_LostFocus;
			Control.MouseDown += Control_MouseDown;
			Control.MouseEnter += Control_MouseEnter;
			Control.MouseLeave += Control_MouseLeave;
			Control.MouseMove += Control_MouseMove;
			Control.MouseUp += Control_MouseUp;
		}

		/// <summary>Gets the control this instance is attached to.</summary>
		public Control Control { get; }

		/// <summary>Gets or sets the current visual state.</summary>
		public virtual PushButtonState State
		{
			get { return currentState; }
			set
			{
				if (currentState == value) return;
				oldState = currentState;
				currentState = value;
				Control.Invalidate();
			}
		}

		/// <summary>Gets the last state of the button.</summary>
		/// <value>The last state of the button.</value>
		public virtual PushButtonState PriorButtonState => oldState;

		public void Dispose()
		{
			if (Control == null) return;

			Control.EnabledChanged -= Control_EnabledChanged;
			Control.GotFocus -= Control_GotFocus;
			Control.LostFocus -= Control_LostFocus;
			Control.MouseDown -= Control_MouseDown;
			Control.MouseEnter -= Control_MouseEnter;
			Control.MouseLeave -= Control_MouseLeave;
			Control.MouseMove -= Control_MouseMove;
			Control.MouseUp -= Control_MouseUp;
		}

		private void Control_EnabledChanged(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		private void Control_GotFocus(object sender, EventArgs e) { throw new NotImplementedException(); }

		private void Control_LostFocus(object sender, EventArgs eventArgs) { throw new NotImplementedException(); }

		private void Control_MouseDown(object sender, MouseEventArgs mouseEventArgs) { throw new NotImplementedException(); }

		private void Control_MouseEnter(object sender, EventArgs eventArgs) { throw new NotImplementedException(); }

		private void Control_MouseLeave(object sender, EventArgs eventArgs) { throw new NotImplementedException(); }

		private void Control_MouseMove(object sender, MouseEventArgs mouseEventArgs) { throw new NotImplementedException(); }

		private void Control_MouseUp(object sender, MouseEventArgs mouseEventArgs) { throw new NotImplementedException(); }
		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
