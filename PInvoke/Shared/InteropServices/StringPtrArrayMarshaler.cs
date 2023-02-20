using System;
using System.Linq;
using System.Runtime.InteropServices;
using Vanara.Extensions;

namespace Vanara.InteropServices;

/// <summary>Marshals an array of strings to an array of pointers to strings with a NULL pointer at the end of the array.</summary>
/// <seealso cref="System.Runtime.InteropServices.ICustomMarshaler"/>
public class StringPtrArrayMarshaler : ICustomMarshaler
{
	private readonly CharSet charSet = CharSet.Unicode;
	private int memSize = 0;

	private StringPtrArrayMarshaler(string cookie)
	{
		if (string.IsNullOrEmpty(cookie)) return;
		try { charSet = (CharSet)Enum.Parse(typeof(CharSet), cookie, true); } catch { }
	}

	/// <summary>Gets the instance.</summary>
	/// <param name="cookie">The cookie.</param>
	/// <returns>A new instance of this class.</returns>
	public static ICustomMarshaler GetInstance(string cookie) => new StringPtrArrayMarshaler(cookie);

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
			sa = new string[] { s };
		if (ManagedObj is string[] _sa)
			sa = _sa;
		return sa != null
			? sa.MarshalToPtr(InteropServices.StringListPackMethod.Packed, Marshal.AllocCoTaskMem, out memSize, charSet)
			: throw new InvalidOperationException($"{nameof(StringPtrArrayMarshaler)} can only marshal object types of {typeof(string)} or {typeof(string[])}.");
	}

	/// <inheritdoc/>
	object ICustomMarshaler.MarshalNativeToManaged(IntPtr pNativeData) => pNativeData.ToStringEnum(pNativeData.GetNulledPtrArrayLength(), charSet).ToArray();
}