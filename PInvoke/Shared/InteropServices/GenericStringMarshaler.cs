namespace Vanara.InteropServices;

/// <summary>Marshals strings that are allocated by native code and must be freed after use.</summary>
/// <remarks>
/// The supplied cookie must be a string representation of a <see cref="CharSet"/> value. If no cookie is supplied, the value
/// <see cref="CharSet.Unicode"/> is used.
/// </remarks>
/// <typeparam name="TMem">The type of the memory allocator.</typeparam>
/// <seealso cref="GenericStringMarshalerBase{TMem}"/>
/// <seealso cref="ICustomMarshaler"/>
public class GenericStringMarshaler<TMem> : GenericStringMarshalerBase<TMem> where TMem : ISimpleMemoryMethods, new()
{
	private GenericStringMarshaler(CharSet charSet) : base(charSet) { }

	/// <summary>Gets the instance.</summary>
	/// <param name="cookie">The cookie.</param>
	/// <returns>A new instance of this class.</returns>
	public static ICustomMarshaler GetInstance(string cookie) => new GenericStringMarshaler<TMem>(CharSetFromString(cookie));
}

/// <summary>Base abstract class for marshaling strings that are allocated by native code and must be freed after use.</summary>
/// <typeparam name="TMem">The type of the memory allocator.</typeparam>
/// <remarks>
/// The supplied cookie must be a string representation of a <see cref="CharSet"/> value. If no cookie is supplied, the value
/// <see cref="CharSet.Unicode"/> is used.
/// </remarks>
/// <seealso cref="ICustomMarshaler"/>
public abstract class GenericStringMarshalerBase<TMem> : ICustomMarshaler where TMem : ISimpleMemoryMethods, new()
{
	private static readonly TMem mem = new();
	private readonly CharSet charSet;

	/// <summary>Initializes a new instance of the <see cref="GenericStringMarshalerBase{TMem}"/> class.</summary>
	/// <param name="charSet">The character set.</param>
	protected GenericStringMarshalerBase(CharSet charSet) => this.charSet = charSet;

	/// <summary>Performs necessary cleanup of the managed data when it is no longer needed.</summary>
	/// <param name="ManagedObj">The managed object to be destroyed.</param>
	public virtual void CleanUpManagedData(object ManagedObj) { }

	/// <summary>Performs necessary cleanup of the unmanaged data when it is no longer needed.</summary>
	/// <param name="pNativeData">A pointer to the unmanaged data to be destroyed.</param>
	public virtual void CleanUpNativeData(IntPtr pNativeData) => mem.FreeMem(pNativeData);

	/// <summary>Returns the size of the native data to be marshaled.</summary>
	/// <returns>The size in bytes of the native data.</returns>
	public virtual int GetNativeDataSize() => IntPtr.Size;

	/// <summary>Converts the managed data to unmanaged data.</summary>
	/// <param name="ManagedObj">The managed object to be converted.</param>
	/// <returns>Returns the COM view of the managed object.</returns>
	public virtual IntPtr MarshalManagedToNative(object ManagedObj) => StringHelper.AllocString(ManagedObj as string, charSet, mem.AllocMem);

	/// <summary>Converts the unmanaged data to managed data.</summary>
	/// <param name="pNativeData">A pointer to the unmanaged data to be wrapped.</param>
	/// <returns>Returns the managed view of the COM data.</returns>
	public virtual object MarshalNativeToManaged(IntPtr pNativeData) => StringHelper.GetString(pNativeData, charSet)!;

	/// <summary>Gets the CharSet from a string.</summary>
	/// <param name="value">The string value.</param>
	/// <param name="defaultValue">The default value if <paramref name="value"/> is not a valid CharSet.</param>
	/// <returns>A CharSet value.</returns>
	protected static CharSet CharSetFromString(string value, CharSet defaultValue = CharSet.Unicode)
	{
		if (!string.IsNullOrEmpty(value))
			try { return (CharSet)Enum.Parse(typeof(CharSet), value, true); } catch { }
		return defaultValue;
	}
}