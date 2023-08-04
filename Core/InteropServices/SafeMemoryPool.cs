using System.Collections.Generic;

namespace Vanara.InteropServices;

/// <summary>A memory pool that will automatically release all memory pointers on disposal.</summary>
/// <typeparam name="TMem">The type of the memory allocator.</typeparam>
/// <seealso cref="IDisposable"/>
public class SafeMemoryPool<TMem> : IDisposable where TMem : IMemoryMethods, new()
{
	private static readonly TMem mem = new();
	private readonly Stack<IntPtr> stack = new();
	private bool disposedValue;

	/// <summary>Finalizes an instance of the <see cref="SafeMemoryPool{TMem}"/> class.</summary>
	~SafeMemoryPool()
	{
		// Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
		Dispose(disposing: false);
	}

	/// <summary>Adds the specified pointer to the memory pool.</summary>
	/// <param name="ptr">The pointer to memory allocated with the same allocator as specified by <typeparamref name="TMem"/>.</param>
	/// <returns>The value of <paramref name="ptr"/>.</returns>
	public IntPtr Add(IntPtr ptr) { stack.Push(ptr); return ptr; }

	/// <summary>Adds the specified string to the memory pool.</summary>
	/// <param name="value">The string value.</param>
	/// <param name="charSet">The character set.</param>
	/// <returns>The pointer to the allocated memory.</returns>
	public IntPtr Add(string value, CharSet charSet = CharSet.Auto) => Add(StringHelper.AllocString(value, charSet, mem.AllocMem));

	/// <summary>Adds the specified value to the memory pool.</summary>
	/// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
	/// <param name="value">The value.</param>
	/// <returns>The pointer to the allocated memory.</returns>
	public IntPtr Add<T>(T value) where T : notnull => Add(value.MarshalToPtr(mem.AllocMem, out _, 0, mem.LockMem, mem.UnlockMem));

	/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
	public void Dispose()
	{
		// Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	/// <summary>Releases unmanaged and - optionally - managed resources.</summary>
	/// <param name="disposing">
	/// <see langword="true"/> to release both managed and unmanaged resources; <see langword="false"/> to release only unmanaged resources.
	/// </param>
	protected virtual void Dispose(bool disposing)
	{
		if (!disposedValue)
		{
			while (stack.Count > 0)
				mem.FreeMem(stack.Pop());
			disposedValue = true;
		}
	}
}