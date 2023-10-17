using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace Vanara.PInvoke.InteropServices;

/// <summary>A COM enumerator for <see cref="string"/> values. This is used to enumerate the values of a <see cref="IEnumString"/> interface.</summary>
public class ComEnumString : IEnumString, IReadOnlyList<string>
{
	private readonly IReadOnlyList<string> list;
	private int cur;

	/// <summary>Initializes a new instance of the <see cref="ComEnumString"/> class with a sequence of strings.</summary>
	/// <param name="items">The sequence of strings.</param>
	public ComEnumString(IEnumerable<string> items) => list = items is IReadOnlyList<string> l ? l : new List<string>(items);

	/// <summary>Initializes a new instance of the <see cref="ComEnumString"/> class from an <see cref="IEnumString"/> instance.</summary>
	/// <param name="ienum">The <see cref="IEnumString"/> instance.</param>
	public ComEnumString(IEnumString ienum) : this(ienum.Enum()) { }

	/// <inheritdoc/>
	public int Count => list.Count;

	/// <inheritdoc/>
	public string this[int index] => list[index];

	/// <summary>Performs an implicit conversion from <see cref="string"/>[] to <see cref="ComEnumString"/>.</summary>
	/// <param name="items">The items.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator ComEnumString(string[] items) => new(items);

	/// <inheritdoc/>
	public IEnumerator<string> GetEnumerator() => list.GetEnumerator();

	void IEnumString.Clone(out IEnumString ppenum) => ppenum = new ComEnumString(list) { cur = cur };

	IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)list).GetEnumerator();

	int IEnumString.Next(int celt, string[] rgelt, nint pceltFetched)
	{
		if (celt < 0) return -2147024809;
		int idx = 0;
		while (cur < list.Count && celt > 0)
		{
			rgelt[idx] = list[cur];
			idx++;
			cur++;
			celt--;
		}
		if (pceltFetched != 0)
			Marshal.WriteInt32(pceltFetched, idx);
		return celt == 0 ? 0 : 1;
	}

	void IEnumString.Reset() => cur = 0;

	int IEnumString.Skip(int celt) => (cur += celt) >= list.Count ? 1 : 0;
}