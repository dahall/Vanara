using System.Linq;

namespace Vanara.InteropServices;

/// <summary>Marshals an array of strings to a concatenated list of strings with an extra NULL terminator.</summary>
/// <seealso cref="ICustomMarshaler"/>
public class NullTermStringArrayMarshaler : ICustomMarshaler
{
	private readonly CharSet charSet = CharSet.Unicode;
	private int memSize = 0;

	private NullTermStringArrayMarshaler(string cookie)
	{
		if (string.IsNullOrEmpty(cookie)) return;
		try { charSet = (CharSet)Enum.Parse(typeof(CharSet), cookie, true); } catch { }
	}

	/// <summary>Gets the instance.</summary>
	/// <param name="cookie">The cookie.</param>
	/// <returns>A new instance of this class.</returns>
	public static ICustomMarshaler GetInstance(string cookie) => new NullTermStringArrayMarshaler(cookie);

	/// <inheritdoc/>
	void ICustomMarshaler.CleanUpManagedData(object ManagedObj) { }

	/// <inheritdoc/>
	void ICustomMarshaler.CleanUpNativeData(IntPtr pNativeData) => Marshal.FreeCoTaskMem(pNativeData);

	/// <inheritdoc/>
	int ICustomMarshaler.GetNativeDataSize() => memSize;

	/// <inheritdoc/>
	IntPtr ICustomMarshaler.MarshalManagedToNative(object ManagedObj)
	{
		if (ManagedObj == null) return IntPtr.Zero;
		string[]? sa = null;
		if (ManagedObj is string s)
			sa = [s];
		if (ManagedObj is string[] _sa)
			sa = _sa;
		return sa == null
			? throw new InvalidOperationException($"{nameof(NullTermStringArrayMarshaler)} can only marshal object types of {typeof(string)} or {typeof(string[])}.")
			: sa.MarshalToPtr(StringListPackMethod.Concatenated, Marshal.AllocCoTaskMem, out memSize, charSet);
	}

	/// <inheritdoc/>
	object ICustomMarshaler.MarshalNativeToManaged(IntPtr pNativeData) => pNativeData.ToStringEnum(charSet).ToArray();
}