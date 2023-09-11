using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Vanara.Extensions;
using static Vanara.PInvoke.Gdi32;
using static Vanara.PInvoke.UxTheme;
using static Vanara.PInvoke.WinBase;

namespace Vanara.Drawing
{
	/// <summary>Represents the types of trigger which can change the visual state of a control.</summary>
	public enum VisualStateTriggerTypes
	{
		/// <summary>The control receives input focus.</summary>
		Focused,

		/// <summary>The mouse is over the control.</summary>
		Hot,

		/// <summary>The left mouse button is pressed on the control.</summary>
		Pushed,

		/// <summary>The control is disabled.</summary>
		Disabled
	}

	/// <summary>
	/// Attaches to a System.Windows.Forms.Control and provides buffered painting functionality.
	/// <para>Uses TState to represent the visual state of the control. Animations are attached to transitions between states.</para>
	/// </summary>
	/// <typeparam name="TState">Any type representing the visual state of the control.</typeparam>
	public class BufferedPainter<TState> : IDisposable
	{
		private bool animationsNeedCleanup;
		private TState currentState;
		private TState defaultState;
		private TState newState;
		private Size oldSize;
		private bool focused, disabled, hot, pushed;

		/// <summary>Initializes a new instance of the BufferedPainter class.</summary>
		/// <param name="control">
		/// Control this instance is attached to.
		/// <para>For best results, use a control which does not paint its background.</para>
		/// <para>Note: Buffered painting does not work if the OptimizedDoubleBuffer newDS is set for the control.</para>
		/// </param>
		public BufferedPainter(Control control, TState defaultState, TState hotState, TState pressedState, TState disabledState)
		{
			defaultState = currentState = newState = default(TState);

			Control = control;
			BufferedPaintSupported = Environment.OSVersion.Version.Major >= 6 && VisualStyleRenderer.IsSupported && Application.RenderWithVisualStyles && !Control.IsDesignMode();
			oldSize = Control.Size;

			Control.Resize += Control_Resize;
			Control.Disposed += Control_Disposed;
			Control.Paint += Control_Paint;
			Control.HandleCreated += Control_HandleCreated;
			Control.EnabledChanged += EvalTriggers;
			Control.MouseEnter += EvalTriggers;
			Control.MouseLeave += EvalTriggers;
			Control.MouseMove += EvalTriggers;
			Control.GotFocus += EvalTriggers;
			Control.LostFocus += EvalTriggers;
			Control.MouseDown += EvalTriggers;
			Control.MouseUp += EvalTriggers;
		}

		/// <summary>Fired when the control must be painted in a particular state.</summary>
		public event EventHandler<BufferedPaintEventArgs<TState>> PaintVisualState;

		/// <summary>Gets whether buffered painting is supported for the current OS/configuration.</summary>
		public bool BufferedPaintSupported { get; }

		/// <summary>Gets the control this instance is attached to.</summary>
		public Control Control { get; }

		/// <summary>Gets or sets the default animation duration (in milliseconds) for state transitions. The default is zero (not animated).</summary>
		public int DefaultDuration { get; set; }

		/// <summary>Gets or sets the default visual state. The default value is 'default(TState)'.</summary>
		public TState DefaultState
		{
			get { return defaultState; }
			set
			{
				var usingOldDefault = Equals(currentState, defaultState);
				defaultState = value;
				if (usingOldDefault) currentState = newState = defaultState;
			}
		}

		/// <summary>Gets or sets the current visual state.</summary>
		public TState State
		{
			get { return currentState; }
			set
			{
				var diff = !Equals(currentState, value);
				newState = value;
				if (diff)
				{
					if (animationsNeedCleanup && Control.IsHandleCreated) BufferedPaintStopAllAnimations(new HandleRef(Control, Control.Handle));
					Control.Invalidate();
				}
			}
		}

		/// <summary>Gets the collection of state transitions and their animation durations. Only one item for each unique state transition is permitted.</summary>
		public ICollection<BufferedPaintTransition<TState>> Transitions { get; } = new HashSet<BufferedPaintTransition<TState>>();

		/// <summary>Short-hand method for adding a state transition.</summary>
		/// <param name="fromState">The previous visual state.</param>
		/// <param name="toState">The new visual state.</param>
		/// <param name="duration">Duration of the animation (in milliseconds).</param>
		public void AddTransition(TState fromState, TState toState, int duration)
		{
			Transitions.Add(new BufferedPaintTransition<TState>(fromState, toState, duration));
		}

		/// <summary>
		/// Adds the transition matrix.
		/// </summary>
		/// <param name="matrix">The matrix.</param>
		public void AddTransitionMatrix(int[,] matrix)
		{
			var eVals = Enum.GetValues(typeof(TState));
			var eValCnt = eVals.Length;
			if (matrix.Length != eValCnt * eValCnt)
				throw new ArgumentOutOfRangeException(nameof(matrix), $"The array for {nameof(matrix)} must be [{eValCnt},{eValCnt}].");
			for (var i = 0; i < eValCnt; i++)
				for (var j = 0; j < eValCnt; j++)
					AddTransition((TState)eVals.GetValue(i), (TState)eVals.GetValue(j), matrix[i, j]);
		}

		public void Dispose()
		{
			if (Control == null) return;

			Control.Resize -= Control_Resize;
			Control.Disposed -= Control_Disposed;
			Control.Paint -= Control_Paint;
			Control.HandleCreated -= Control_HandleCreated;
			Control.EnabledChanged -= EvalTriggers;
			Control.MouseEnter -= EvalTriggers;
			Control.MouseLeave -= EvalTriggers;
			Control.MouseMove -= EvalTriggers;
			Control.GotFocus -= EvalTriggers;
			Control.LostFocus -= EvalTriggers;
			Control.MouseDown -= EvalTriggers;
			Control.MouseUp -= EvalTriggers;
		}

		/// <summary>Raises the PaintVisualState event.</summary>
		/// <param name="e">BufferedPaintEventArgs instance.</param>
		protected virtual void OnPaintVisualState(BufferedPaintEventArgs<TState> e)
		{
			PaintVisualState?.Invoke(this, e);
		}

		/// <summary>Helper method for EvalTriggers().</summary>
		/// <param name="type">Type of trigger to search for.</param>
		/// <param name="stateIfTrue">Reference to the visual state variable to update (if the trigger occurs).</param>
		private void ApplyCondition(VisualStateTriggerTypes type, ref TState stateIfTrue)
		{
			foreach (var trigger in Triggers.Where(x => x.Type == type))
			{
				var bounds = trigger.Bounds != Rectangle.Empty ? trigger.Bounds : Control.ClientRectangle;
				var inRect = bounds.Contains(Control.PointToClient(Cursor.Position));
				var other = true;

				switch (type)
				{
					case VisualStateTriggerTypes.Disabled:
						other = !Control.Enabled;
						inRect = true;
						break;

					case VisualStateTriggerTypes.Focused:
						other = Control.Focused;
						inRect = true;
						break;

					case VisualStateTriggerTypes.Pushed:
						other = (Control.MouseButtons & MouseButtons.Left) == MouseButtons.Left;
						break;
				}
				if (other && inRect) stateIfTrue = trigger.State;
			}
		}

		/// <summary>Deactivates buffered painting.</summary>
		private void CleanupAnimations()
		{
			if (Control.InvokeRequired)
			{
				Control.Invoke(new MethodInvoker(CleanupAnimations));
			}
			else if (animationsNeedCleanup)
			{
				if (Control.IsHandleCreated) BufferedPaintStopAllAnimations(new HandleRef(Control, Control.Handle));
				BufferedPaintUnInit();
				animationsNeedCleanup = false;
			}
		}

		private void Control_Disposed(object sender, EventArgs e)
		{
			if (animationsNeedCleanup)
			{
				BufferedPaintUnInit();
				animationsNeedCleanup = false;
			}
		}

		private void Control_HandleCreated(object sender, EventArgs e)
		{
			if (BufferedPaintSupported)
			{
				BufferedPaintInit();
				animationsNeedCleanup = true;
			}
		}

		private void Control_Paint(object sender, PaintEventArgs e)
		{
			if (BufferedPaintSupported)
			{
				var stateChanged = !Equals(currentState, newState);

				using (var hdc = new SafeDCHandle(e.Graphics))
				{
					if (!hdc.IsInvalid)
					{
						// see if this paint was generated by a soft-fade animation
						if (!BufferedPaintRenderAnimation(new HandleRef(Control, Control.Handle), hdc))
						{
							var animParams = new BP_ANIMATIONPARAMS(BP_ANIMATIONSTYLE.BPAS_LINEAR);

							// get appropriate animation time depending on state transition (or 0 if unchanged)
							if (stateChanged)
							{
								var transition = Transitions.SingleOrDefault(x => Equals(x.FromState, currentState) && Equals(x.ToState, newState));
								animParams.Duration = transition?.Duration ?? DefaultDuration;
							}

							using (var h = new BufferedPaintHandle(Control, hdc, Control.ClientRectangle, animParams, BP_PAINTPARAMS.NoClip))
							{
								if (!h.IsInvalid)
								{
									if (h.SourceGraphics != null)
										OnPaintVisualState(new BufferedPaintEventArgs<TState>(currentState, h.SourceGraphics));
									if (h.Graphics != null)
										OnPaintVisualState(new BufferedPaintEventArgs<TState>(newState, h.Graphics));
								}
								else
								{
									currentState = newState;
									OnPaintVisualState(new BufferedPaintEventArgs<TState>(currentState, e.Graphics));
								}
							}
						}
					}
				}
			}
			else
			{
				// buffered painting not supported, just paint using the current state
				currentState = newState;
				OnPaintVisualState(new BufferedPaintEventArgs<TState>(currentState, e.Graphics));
			}
		}

		private void Control_Resize(object sender, EventArgs e)
		{
			// resizing stops all playing animations
			if (animationsNeedCleanup && Control.IsHandleCreated) BufferedPaintStopAllAnimations(new HandleRef(Control, Control.Handle));

			// update trigger bounds according to anchor styles
			foreach (var trigger in Triggers)
			{
				if (trigger.Bounds == Rectangle.Empty) continue;

				var newBounds = trigger.Bounds;

				if ((trigger.Anchor & AnchorStyles.Left) != AnchorStyles.Left)
					newBounds.X += Control.Width - oldSize.Width;

				if ((trigger.Anchor & AnchorStyles.Top) != AnchorStyles.Top)
					newBounds.Y += Control.Height - oldSize.Height;

				if ((trigger.Anchor & AnchorStyles.Right) == AnchorStyles.Right)
					newBounds.Width += Control.Width - oldSize.Width;

				if ((trigger.Anchor & AnchorStyles.Bottom) == AnchorStyles.Bottom)
					newBounds.Height += Control.Height - oldSize.Height;

				trigger.Bounds = newBounds;
			}

			// save old size for next resize
			oldSize = Control.Size;
		}

		/// <summary>Evaluates all state change triggers.</summary>
		private void EvalTriggers(object sender, EventArgs e)
		{
			if (Triggers.Count == 0) return;

			var nState = DefaultState;

			ApplyCondition(VisualStateTriggerTypes.Focused, ref nState);
			ApplyCondition(VisualStateTriggerTypes.Hot, ref nState);
			ApplyCondition(VisualStateTriggerTypes.Pushed, ref nState);
			ApplyCondition(VisualStateTriggerTypes.Disabled, ref nState);

			State = nState;
		}
	}

	/// <summary>EventArgs class for the BufferedPainter.PaintVisualState event.</summary>
	/// <typeparam name="TState">Any type representing the visual state of the control.</typeparam>
	public class BufferedPaintEventArgs<TState> : EventArgs
	{
		/// <summary>Initializes a new instance of the BufferedPaintEventArgs class.</summary>
		/// <param name="state">Visual state to paint.</param>
		/// <param name="graphics">Graphics object on which to paint.</param>
		public BufferedPaintEventArgs(TState state, Graphics graphics)
		{
			State = state;
			Graphics = graphics;
		}

		/// <summary>Gets the Graphics object on which to paint.</summary>
		public Graphics Graphics { get; }

		/// <summary>Gets the visual state to paint.</summary>
		public TState State { get; }
	}

	/// <summary>
	/// Represents a transition between two visual states. Describes the duration of the animation. Two transitions are considered equal if they represent the
	/// same change in visual state.
	/// </summary>
	/// <typeparam name="TState">Any type representing the visual state of the control.</typeparam>
	public class BufferedPaintTransition<TState> : IEquatable<BufferedPaintTransition<TState>>
	{
		/// <summary>Initializes a new instance of the BufferedPaintTransition class.</summary>
		/// <param name="fromState">The previous visual state.</param>
		/// <param name="toState">The new visual state.</param>
		/// <param name="duration">Duration of the animation (in milliseconds).</param>
		public BufferedPaintTransition(TState fromState, TState toState, int duration)
		{
			FromState = fromState;
			ToState = toState;
			Duration = duration;
		}

		/// <summary>Gets or sets the duration (in milliseconds) of the animation.</summary>
		public int Duration { get; set; }

		/// <summary>Gets the previous visual state.</summary>
		public TState FromState { get; }

		/// <summary>Gets the new visual state.</summary>
		public TState ToState { get; }

		/// <summary>Determines if two instances are equal.</summary>
		/// <param name="obj">The object to compare.</param>
		/// <returns></returns>
		public override bool Equals(object? obj)
		{
			var other = obj as BufferedPaintTransition<TState>;
			return other != null ? ((IEquatable<BufferedPaintTransition<TState>>)this).Equals(other) : base.Equals(obj);
		}

		/// <summary>Serves as a hash function for a particular type.</summary>
		/// <returns></returns>
		public override int GetHashCode() => ((object)FromState ?? 0).GetHashCode() ^ ((object)ToState ?? 0).GetHashCode();

		bool IEquatable<BufferedPaintTransition<TState>>.Equals(BufferedPaintTransition<TState> other)
		{
			return other != null && Equals(FromState, other.FromState) && Equals(ToState, other.ToState);
		}
	}

	/// <summary>Represents a trigger for a particular visual state. Two triggers are considered equal if they are of the same type and visual state.</summary>
	/// <typeparam name="TState">Any type representing the visual state of the control.</typeparam>
	public class VisualStateTrigger<TState> : IEquatable<VisualStateTrigger<TState>>
	{
		/// <summary>Initializes a new instance of the VisualStateTrigger class.</summary>
		/// <param name="type">Type of trigger.</param>
		/// <param name="state">Visual state applied when the trigger occurs.</param>
		/// <param name="bounds">Bounds within which the trigger applies.</param>
		/// <param name="anchor">Anchor for drawn items.</param>
		public VisualStateTrigger(VisualStateTriggerTypes type, TState state, Rectangle bounds = default(Rectangle), AnchorStyles anchor = AnchorStyles.Top | AnchorStyles.Left)
		{
			Type = type;
			State = state;
			Bounds = bounds;
			Anchor = anchor;
		}

		/// <summary>Gets or sets how the bounds are anchored to the edge of the control.</summary>
		public AnchorStyles Anchor { get; set; }

		/// <summary>Gets or sets the bounds within which the trigger applies.</summary>
		public Rectangle Bounds { get; set; }

		/// <summary>Gets the visual state applied when the trigger occurs.</summary>
		public TState State { get; }

		/// <summary>Gets the type of trigger.</summary>
		public VisualStateTriggerTypes Type { get; }

		/// <summary>Determines if two instances are equal.</summary>
		/// <param name="obj">The object to compare.</param>
		/// <returns></returns>
		public override bool Equals(object? obj)
		{
			var other = obj as VisualStateTrigger<TState>;
			return other != null ? ((IEquatable<VisualStateTrigger<TState>>)this).Equals(other) : base.Equals(obj);
		}

		/// <summary>Serves as a hash function for a particular type.</summary>
		/// <returns></returns>
		public override int GetHashCode() => Type.GetHashCode() ^ ((object)State ?? 0).GetHashCode();

		bool IEquatable<VisualStateTrigger<TState>>.Equals(VisualStateTrigger<TState> other)
		{
			return other != null && (Type == other.Type) && Equals(State, other.State);
		}
	}
}