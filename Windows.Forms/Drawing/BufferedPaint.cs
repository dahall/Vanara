using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Vanara.PInvoke;
using static Vanara.PInvoke.Gdi32;
using static Vanara.PInvoke.UxTheme;

namespace Vanara.Drawing;

/// <summary>Buffered painting helper class.</summary>
public static class BufferedPaint
{
	private static readonly Dictionary<IntPtr, Tuple<object, object>> paintAnimationInstances = new Dictionary<IntPtr, Tuple<object, object>>();

	/// <summary>A method delegate that retrieves a duration, in milliseconds, to use as the time over which buffered painting occurs.</summary>
	/// <typeparam name="TState">The type of the state that is used to determine the transition duration.</typeparam>
	/// <param name="oldState">The old state value.</param>
	/// <param name="newState">The new state value.</param>
	/// <returns>A duration, in milliseconds, to use as the time over which buffered painting occurs.</returns>
	public delegate int GetDuration<in TState>(TState oldState, TState newState);

	/// <summary>A method delegate to paint a stateful image.</summary>
	/// <typeparam name="TState">The type of the state that is used to determine the image to paint.</typeparam>
	/// <typeparam name="TParam">The type of the parameter that is passed into this method.</typeparam>
	/// <param name="graphics">The graphics instance on which to paint the image.</param>
	/// <param name="bounds">The bounds within which to paint the image.</param>
	/// <param name="currentState">The current state to paint.</param>
	/// <param name="data">The custom data passed into this method.</param>
	public delegate void PaintAction<in TState, in TParam>(Graphics graphics, Rectangle bounds, TState currentState, TParam data);

	/// <summary>Performs a buffered paint operation.</summary>
	/// <typeparam name="TState">The type of the state that is used to determine the image to paint.</typeparam>
	/// <typeparam name="TParam">The type of the parameter that is passed into this method.</typeparam>
	/// <param name="graphics">The target DC on which the buffer is painted.</param>
	/// <param name="bounds">Specifies the area of the target DC in which to draw.</param>
	/// <param name="paintAction">A method delegate that performs the painting of the control at the provided state.</param>
	/// <param name="currentState">The current state to use to start drawing the animation.</param>
	/// <param name="data">User-defined data to pass to the <paramref name="paintAction"/> callback.</param>
	public static void Paint<TState, TParam>(Graphics graphics, Rectangle bounds, PaintAction<TState, TParam> paintAction, TState currentState, TParam data)
	{
		using (var g = new SafeTempHDC(graphics))
		using (var bp = new BufferedPainter(g, bounds))
			paintAction(bp.Graphics, bounds, currentState, data);
	}

	/// <summary>Performs a buffered animation operation. The animation consists of a cross-fade between the contents of two buffers over a specified period of time.</summary>
	/// <typeparam name="TState">The type of the state that is used to determine the image to paint.</typeparam>
	/// <param name="graphics">The target DC on which the buffer is animated.</param>
	/// <param name="ctrl">The window in which the animations play.</param>
	/// <param name="bounds">Specifies the area of the target DC in which to draw.</param>
	/// <param name="paintAction">A method delegate that performs the painting of the control at a given state.</param>
	/// <param name="currentState">The current state to use to start drawing the animation.</param>
	/// <param name="newState">The final state to use to finish drawing the animation.</param>
	/// <param name="getDuration">A method delegate that gets the duration of the animation, in milliseconds.</param>
	public static void PaintAnimation<TState>(Graphics graphics, IWin32Window ctrl, Rectangle bounds, PaintAction<TState, int> paintAction,
		TState currentState, TState newState, GetDuration<TState> getDuration)
		=> PaintAnimation(graphics, ctrl, bounds, paintAction, currentState, newState, getDuration, 0);

	/// <summary>Performs a buffered animation operation. The animation consists of a cross-fade between the contents of two buffers over a specified period of time.</summary>
	/// <typeparam name="TState">The type of the state that is used to determine the image to paint.</typeparam>
	/// <typeparam name="TParam">The type of the parameter that is passed into this method.</typeparam>
	/// <param name="graphics">The target DC on which the buffer is animated.</param>
	/// <param name="ctrl">The window in which the animations play.</param>
	/// <param name="bounds">Specifies the area of the target DC in which to draw.</param>
	/// <param name="paintAction">A method delegate that performs the painting of the control at a given state.</param>
	/// <param name="currentState">The current state to use to start drawing the animation.</param>
	/// <param name="newState">The final state to use to finish drawing the animation.</param>
	/// <param name="getDuration">A method delegate that gets the duration of the animation, in milliseconds.</param>
	/// <param name="data">User-defined data to pass to the <paramref name="paintAction"/> callback.</param>
	public static void PaintAnimation<TState, TParam>(Graphics graphics, IWin32Window ctrl, Rectangle bounds,
		PaintAction<TState, TParam> paintAction, TState currentState, TState newState, GetDuration<TState> getDuration, TParam data)
	{
		try
		{
			if (System.Environment.OSVersion.Version.Major >= 6)
			{
				// If this handle is running with a different state, stop the animations
				if (paintAnimationInstances.TryGetValue(ctrl.Handle, out var val))
				{
					if (!Equals(val.Item1, currentState) || !Equals(val.Item2, newState))
					{
						BufferedPaintStopAllAnimations(ctrl.Handle);
						System.Diagnostics.Debug.WriteLine("BufferedPaintStop.");
						paintAnimationInstances[ctrl.Handle] = new Tuple<object, object>(currentState, newState);
					}
				}
				else
					paintAnimationInstances.Add(ctrl.Handle, new Tuple<object, object>(currentState, newState));

				using (var hdc = new SafeTempHDC(graphics))
				{
					if (hdc.IsNull) return;
					// see if this paint was generated by a soft-fade animation
					if (BufferedPaintRenderAnimation(ctrl.Handle, hdc))
					{
						paintAnimationInstances.Remove(ctrl.Handle);
						return;
					}

					var animParams = new BP_ANIMATIONPARAMS(BP_ANIMATIONSTYLE.BPAS_LINEAR, getDuration?.Invoke(currentState, newState) ?? 0);
					using (var h = new BufferedAnimationPainter(ctrl, hdc, bounds, animParams, BP_PAINTPARAMS.NoClip))
					{
						if (!h.IsInvalid)
						{
							if (h.SourceGraphics != null)
								paintAction(h.SourceGraphics, bounds, currentState, data);
							if (h.DestinationGraphics != null)
								paintAction(h.DestinationGraphics, bounds, newState, data);
						}
						else
						{
							// hdc.Dispose();
							paintAction(graphics, bounds, newState, data);
						}
					}
				}
			}
			else
				paintAction(graphics, bounds, newState, data);
		}
		catch { }
		System.Diagnostics.Debug.WriteLine($"BufferedPaint state items = {paintAnimationInstances.Count}.");
	}
}

/// <summary>Use to paint a buffered animation.</summary>
/// <seealso cref="System.IDisposable"/>
public class BufferedAnimationPainter : IDisposable
{
	private static readonly BufferedPaintBlock block = new BufferedPaintBlock();

	private bool disposedValue = false;
	private SafeHANIMATIONBUFFER hba;

	/// <summary>
	/// Initializes a new instance of the <see cref="BufferedPainter"/> class and begins a buffered animation operation. The animation consists of a
	/// cross-fade between the contents of two buffers over a specified period of time.
	/// </summary>
	/// <param name="wnd">The window in which the animations play.</param>
	/// <param name="hdc">A handle of the target DC on which the buffer is animated.</param>
	/// <param name="targetRectangle">Specifies the area of the target DC in which to draw.</param>
	/// <param name="animationParams">A structure that defines the animation operation parameters. This value can be <see langword="null"/>.</param>
	/// <param name="paintParams">A class that defines the paint operation parameters. This value can be <see langword="null"/>.</param>
	/// <param name="fmt">The format of the buffer.</param>
	/// <exception cref="Win32Exception">Buffered animation could not initialize.</exception>
	public BufferedAnimationPainter(IWin32Window wnd, HDC hdc, Rectangle targetRectangle, BP_ANIMATIONPARAMS? animationParams = null,
		BP_PAINTPARAMS paintParams = null, BP_BUFFERFORMAT fmt = BP_BUFFERFORMAT.BPBF_TOPDOWNDIB)
	{
		RECT rc = targetRectangle;
		var ap = animationParams ?? BP_ANIMATIONPARAMS.Empty;
		hba = BeginBufferedAnimation(wnd.Handle, hdc, rc, fmt, paintParams, ap, out var hdcFrom, out var hdcTo);
		if (hba.IsInvalid) throw new Win32Exception();
		if (!hdcFrom.IsNull) SourceGraphics = Graphics.FromHdc((IntPtr)hdcFrom);
		if (!hdcTo.IsNull) DestinationGraphics = Graphics.FromHdc((IntPtr)hdcTo);
	}

	/// <summary>Finalizes an instance of the <see cref="BufferedPainter"/> class.</summary>
	~BufferedAnimationPainter()
	{
		// Do not change this code. Put cleanup code in Dispose(bool disposing) above.
		Dispose(false);
	}

	/// <summary>Gets the destination graphics where the application should paint the final state of the animation.</summary>
	public virtual Graphics DestinationGraphics { get; }

	/// <summary>Gets a value indicating whether this instance is invalid.</summary>
	/// <value><c>true</c> if this instance is invalid; otherwise, <c>false</c>.</value>
	public virtual bool IsInvalid => hba.IsInvalid;

	/// <summary>Gets the source graphics where the application should paint the initial state of the animation.</summary>
	public virtual Graphics SourceGraphics { get; }

	/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
	void IDisposable.Dispose()
	{
		Dispose(true);
		GC.SuppressFinalize(this);
	}

	/// <summary>Releases unmanaged and - optionally - managed resources.</summary>
	/// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
	protected virtual void Dispose(bool disposing)
	{
		if (!disposedValue)
		{
			if (disposing)
			{
				SourceGraphics?.Dispose();
				DestinationGraphics?.Dispose();
				hba?.Dispose();
			}

			disposedValue = true;
		}
	}
}

/// <summary>Use to perform buffered painting.</summary>
/// <seealso cref="System.IDisposable"/>
public class BufferedPainter : IDisposable
{
	private static readonly BufferedPaintBlock block = new BufferedPaintBlock();

	private bool disposedValue = false;
	private SafeHPAINTBUFFER hbp;

	/// <summary>Initializes a new instance of the <see cref="BufferedPainter"/> class and begins a buffered paint operation.</summary>
	/// <param name="hdc">The handle of the target DC on which the buffer will be painted.</param>
	/// <param name="targetRectangle">Specifies the area of the target DC in which to paint.</param>
	/// <param name="paintParams">The paint operation parameters. This value can be <see langword="null"/>.</param>
	/// <param name="fmt">The format of the buffer.</param>
	/// <exception cref="Win32Exception">Buffered painting could not initialize.</exception>
	public BufferedPainter(HDC hdc, Rectangle targetRectangle, BP_PAINTPARAMS paintParams = null,
		BP_BUFFERFORMAT fmt = BP_BUFFERFORMAT.BPBF_TOPDOWNDIB)
	{
		RECT target = targetRectangle;
		hbp = BeginBufferedPaint(hdc, target, fmt, paintParams, out var phdc);
		if (hbp.IsInvalid) throw new Win32Exception();
		if (!phdc.IsNull) Graphics = Graphics.FromHdc((IntPtr)phdc);
	}

	/// <summary>Finalizes an instance of the <see cref="BufferedPainter"/> class.</summary>
	~BufferedPainter()
	{
		// Do not change this code. Put cleanup code in Dispose(bool disposing) above.
		Dispose(false);
	}

	/// <summary>Gets the destination graphics on which all painting is done.</summary>
	public virtual Graphics Graphics { get; }

	/// <summary>Gets a value indicating whether this instance is invalid.</summary>
	/// <value><c>true</c> if this instance is invalid; otherwise, <c>false</c>.</value>
	public virtual bool IsInvalid => hbp.IsInvalid;

	/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
	void IDisposable.Dispose()
	{
		Dispose(true);
		GC.SuppressFinalize(this);
	}

	/// <summary>Releases unmanaged and - optionally - managed resources.</summary>
	/// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
	protected virtual void Dispose(bool disposing)
	{
		if (!disposedValue)
		{
			if (disposing)
			{
				Graphics?.Dispose();
				hbp?.Dispose();
			}

			disposedValue = true;
		}
	}
}