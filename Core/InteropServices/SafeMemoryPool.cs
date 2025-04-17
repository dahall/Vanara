using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Vanara.InteropServices;

/// <summary>A memory pool that will automatically release all memory pointers on disposal.</summary>
/// <typeparam name="TMem">The type of the memory allocator.</typeparam>
/// <seealso cref="IDisposable"/>
public class SafeMemoryPool<TMem> : IDisposable, IDictionary<string, IntPtr> where TMem : IMemoryMethods, new()
{
	private static readonly TMem mem = new();
	private readonly List<(string key, IntPtr ptr)> list = [];
	private bool disposedValue;

	/// <summary>Finalizes an instance of the <see cref="SafeMemoryPool{TMem}"/> class.</summary>
	~SafeMemoryPool()
	{
		// Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
		Dispose(disposing: false);
	}

	/// <inheritdoc/>
	public int Count => list.Count;

	/// <inheritdoc/>
	public ICollection<string> Keys => [.. list.Select(e => e.key)];

	/// <inheritdoc/>
	public ICollection<IntPtr> Values => [.. list.Select(e => e.ptr)];

	bool ICollection<KeyValuePair<string, IntPtr>>.IsReadOnly => false;

	IntPtr IDictionary<string, IntPtr>.this[string key]
	{
		get => TryGetValue(key, out var p) ? p : throw new IndexOutOfRangeException();
		set { var i = list.FindIndex(0, e => e.key == key); if (i < 0) Add(key, value); else list[i] = (key, value); }
	}

	/// <summary>Adds the specified pointer to the memory pool.</summary>
	/// <param name="ptr">The pointer to memory allocated with the same allocator as specified by <typeparamref name="TMem"/>.</param>
	/// <returns>The value of <paramref name="ptr"/>.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public IntPtr Add(IntPtr ptr) => Add(Guid.NewGuid().ToString("N"), ptr);

	/// <summary>Adds the specified string to the memory pool.</summary>
	/// <param name="value">The string value.</param>
	/// <param name="charSet">The character set.</param>
	/// <returns>The pointer to the allocated memory.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public IntPtr Add(string value, CharSet charSet = CharSet.Auto) => Add(Guid.NewGuid().ToString("N"), value, charSet);

	/// <summary>Adds the specified value to the memory pool.</summary>
	/// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
	/// <param name="value">The value.</param>
	/// <returns>The pointer to the allocated memory.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public IntPtr Add<T>(T value) where T : notnull => Add(Guid.NewGuid().ToString("N"), value);

	/// <summary>Adds the specified pointer to the memory pool.</summary>
	/// <param name="key">The key used to identify the entry.</param>
	/// <param name="ptr">The pointer to memory allocated with the same allocator as specified by <typeparamref name="TMem"/>.</param>
	/// <returns>The value of <paramref name="ptr"/>.</returns>
	public IntPtr Add(string key, IntPtr ptr)
	{ list.Add((key, ptr)); return ptr; }

	/// <summary>Adds the specified string to the memory pool.</summary>
	/// <param name="key">The key used to identify the entry.</param>
	/// <param name="value">The string value.</param>
	/// <param name="charSet">The character set.</param>
	/// <returns>The pointer to the allocated memory.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public IntPtr Add(string key, string value, CharSet charSet = CharSet.Auto) => Add(key, StringHelper.AllocString(value, charSet, mem.AllocMem));

	/// <summary>Adds the specified value to the memory pool.</summary>
	/// <param name="key">The key used to identify the entry.</param>
	/// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
	/// <param name="value">The value.</param>
	/// <returns>The pointer to the allocated memory.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public IntPtr Add<T>(string key, T value) where T : notnull => Add(key, value.MarshalToPtr(mem.AllocMem, out _, 0, mem.LockMem, mem.UnlockMem));

	/// <inheritdoc/>
	public bool Contains(KeyValuePair<string, IntPtr> item) => TryGetValue(item.Key, out var p) && p == item.Value;

	/// <inheritdoc/>
	public bool ContainsKey(string key) => TryGetValue(key, out _);

	/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
	public void Dispose()
	{
		// Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	/// <inheritdoc/>
	public bool TryGetValue(string key, out IntPtr value)
	{
		var res = list.FirstOrDefault(e => e.key == key);
		value = res.ptr;
		return res.key is not null;
	}

	void IDictionary<string, IntPtr>.Add(string key, IntPtr value) => Add(key, value);

	void ICollection<KeyValuePair<string, IntPtr>>.Add(KeyValuePair<string, IntPtr> item) => Add(item.Key, item.Value);

	void ICollection<KeyValuePair<string, IntPtr>>.Clear()
	{
		list.ForEach(e => mem.FreeMem(e.ptr));
		list.Clear();
	}

	void ICollection<KeyValuePair<string, IntPtr>>.CopyTo(KeyValuePair<string, IntPtr>[] array, int arrayIndex) => throw new NotImplementedException();

	IEnumerator<KeyValuePair<string, IntPtr>> IEnumerable<KeyValuePair<string, IntPtr>>.GetEnumerator() => list.Select(e => new KeyValuePair<string, IntPtr>(e.key, e.ptr)).GetEnumerator();

	IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable<KeyValuePair<string, IntPtr>>)this).GetEnumerator();

	bool IDictionary<string, IntPtr>.Remove(string key) => throw new NotImplementedException();

	bool ICollection<KeyValuePair<string, IntPtr>>.Remove(KeyValuePair<string, IntPtr> item) => throw new NotImplementedException();

	/// <summary>Releases unmanaged and - optionally - managed resources.</summary>
	/// <param name="disposing">
	/// <see langword="true"/> to release both managed and unmanaged resources; <see langword="false"/> to release only unmanaged resources.
	/// </param>
	protected virtual void Dispose(bool disposing)
	{
		if (!disposedValue)
		{
			((ICollection<KeyValuePair<string, IntPtr>>)this).Clear();
			disposedValue = true;
		}
	}
}