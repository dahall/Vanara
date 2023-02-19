using System;

namespace Vanara.PInvoke;

/// <summary>A disposable context for which a delegate is called at entry and exit.</summary>
/// <example>
/// This class can be used as follows:
/// <code>using (var ctx = new BeginEndEventContext(h =&gt; RegisterForEvents(out h), h =&gt; UnregisterForEvents(h)))
/// {
///     // Check to see if begin function succeeded
///     if (!ctx.BeginSucceeded)
///         return;
///
///     // Do some work
/// }
/// // End function has been called</code></example>
/// <seealso cref="System.IDisposable" />
public class BeginEndEventContext : IDisposable
{
	private readonly Func<object?, bool>? end;
	private bool disposedValue;
	private object? obj = null;

	/// <summary>Initializes a new instance of the <see cref="BeginEndEventContext"/> class.</summary>
	/// <param name="onBegin">The optional delegate to call when creating the context.</param>
	/// <param name="onEnd">The optional delegate to call when the context is disposed or goes out of scope.</param>
	public BeginEndEventContext(Func<bool>? onBegin, Func<bool>? onEnd = null) : this(onBegin is null ? null : o => onBegin(), onEnd is null ? null : o => onEnd())
	{
	}

	/// <summary>Initializes a new instance of the <see cref="BeginEndEventContext"/> class.</summary>
	/// <param name="onBegin">The optional delegate to call when creating the context.</param>
	/// <param name="onEnd">The optional delegate to call when the context is disposed or goes out of scope.</param>
	public BeginEndEventContext(Func<object?, bool>? onBegin = null, Func<object?, bool>? onEnd = null)
	{
		end = onEnd;
		BeginSucceeded = onBegin?.Invoke(obj) ?? true;
	}

	/// <summary>Gets the return value of the <c>onBegin</c> delegate.</summary>
	public bool BeginSucceeded { get; }

	/// <summary>Gets the return value of the <c>onEnd</c> delegate.</summary>
	public bool EndSucceeded { get; private set; }

	/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	/// <summary>Releases unmanaged and managed resources.</summary>
	/// <param name="disposing">
	/// <see langword="true"/> to release both managed and unmanaged resources; <see langword="false"/> to release only unmanaged resources.
	/// </param>
	protected virtual void Dispose(bool disposing)
	{
		if (!disposedValue)
		{
			if (disposing)
			{
				EndSucceeded = end?.Invoke(obj) ?? true;
			}

			obj = null;
			disposedValue = true;
		}
	}
}