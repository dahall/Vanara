using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Vanara.Marshaler;

/// <summary>Base exception for marshaling errors.</summary>
/// <seealso cref="System.Exception"/>
public class MarshalException(string message) : Exception(message)
{
}

/// <summary>General options for marshaling.</summary>
public record MarshalerOptions
{
	/// <summary>Initializes a new instance of the <see cref="MarshalerOptions"/> class.</summary>
	/// <param name="encoding">The string encoding.</param>
	/// <param name="bitness">The bitness used to process marshaled pointers and system-specific types.</param>
	public MarshalerOptions(StringEncoding encoding = StringEncoding.Default, Bitness bitness = Bitness.Auto)
	{
		StringEncoding = encoding;
		Bitness = bitness.Resolve();
	}

	/// <summary>Initializes a new instance of the <see cref="MarshalerOptions"/> class.</summary>
	/// <param name="bitness">The bitness used to process marshaled pointers and system-specific types.</param>
	/// <param name="charSet">The character set.</param>
	public MarshalerOptions(Bitness bitness, CharSet charSet = CharSet.Auto) : this((StringEncoding)charSet.Resolve(), bitness) { }

	/// <summary>Gets or sets the bitness used to process marshaled pointers and system-specific types.</summary>
	public Bitness Bitness { get; set; }

	/// <summary>Gets or sets the memory methods used to allocate and free memory.</summary>
	public IMemoryMethods MemoryMethods { get; set; } = new CoTaskMemoryMethods();

	/// <summary>Gets or sets a value indicating whether to marshal <see langword="null"/> as <see cref="IntPtr.Zero"/>.</summary>
	public bool NullAsPointer { get; set; } = true;

	/// <summary>Gets or sets the character encoding used to process marshaled strings.</summary>
	public StringEncoding StringEncoding { get; private set; }

	/// <summary>Gets or sets the string list packing method.</summary>
	public StringListPackMethod StringListPackMethod { get; set; } = StringListPackMethod.Concatenated;

	/// <summary>Gets or sets the character encoding used to process marshaled strings.</summary>
	internal Encoding Encoding => StringEncoding.ToEncoding();

	internal void UpdateEncoding(StringEncoding? add) { if (add is not null) StringEncoding = add.Value; }
}

/// <summary>Contains static methods for marshaling objects.</summary>
public static partial class Marshaler
{
	/// <summary>Marshals data from an unmanaged block of memory to a newly allocated managed object of the specified type.</summary>
	/// <typeparam name="T">The type of object to be created. This object must represent a formatted class or a structure.</typeparam>
	/// <param name="ptr">A pointer to an unmanaged block of memory.</param>
	/// <param name="opts">Marshaling options.</param>
	/// <returns>A managed object containing the data pointed to by the <paramref name="ptr"/> parameter or <see langword="null"/> if <paramref name="ptr"/> was NULL.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerStepThrough]
	public static T? PtrToValue<T>(IntPtr ptr, MarshalerOptions? opts = null) => PtrToValue(typeof(T), ptr, opts) is T t ? t : default;

	/// <summary>Marshals data from an unmanaged block of memory to a newly allocated managed object of the specified type.</summary>
	/// <param name="type">The type of object to be created. This object must represent a formatted class or a structure.</param>
	/// <param name="ptr">A pointer to an unmanaged block of memory.</param>
	/// <param name="opts">Marshaling options.</param>
	/// <returns>A managed object containing the data pointed to by the <paramref name="ptr"/> parameter or <see langword="null"/> if <paramref name="ptr"/> was NULL.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerStepThrough]
	public static object? PtrToValue(Type type, IntPtr ptr, MarshalerOptions? opts = null) =>
		MarshaledTypeInfo.ReadInstanceFromMemory(type, ptr, opts);

	/// <summary>Returns the size of an object in bytes.</summary>
	/// <param name="value">The object whose size is to be returned.</param>
	/// <param name="opts">The optional options to use when marshaling.</param>
	/// <returns>The size of the specified type in memory.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerStepThrough]
	public static int SizeOf(object value, MarshalerOptions? opts = null) => value is null ? 0 : SizeOf(value.GetType(), opts);

	/// <summary>Returns the size of a type in bytes.</summary>
	/// <typeparam name="T">The type whose size is to be returned.</typeparam>
	/// <param name="opts">The optional options to use when marshaling.</param>
	/// <returns>The size of the specified type in memory.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerStepThrough]
	public static int SizeOf<T>(MarshalerOptions? opts = null) => SizeOf(typeof(T), opts);

	/// <summary>Returns the size of a type in bytes.</summary>
	/// <param name="type">The type whose size is to be returned.</param>
	/// <param name="opts">The optional options to use when marshaling.</param>
	/// <returns>The size of the specified type in memory.</returns>
	public static int SizeOf(Type type, MarshalerOptions? opts = null)
	{
		if (!type.IsMarshaledType())
			return InteropExtensions.SizeOf(type);
		var ti = MarshaledTypeInfo.Get(type, opts);
		ti.DebugDump();
		return ti.NativeSize;
	}

	/// <summary>Marshals data from a managed object to an unmanaged block of memory.</summary>
	/// <typeparam name="TMem">The type of the memory.</typeparam>
	/// <param name="value">A managed object that holds the data to be marshaled. The object must be a structure or an instance of a formatted class.</param>
	/// <param name="opts">The optional options to use when marshaling.</param>
	/// <returns>A pointer to an unmanaged block of memory, which is allocated using <typeparamref name="TMem"/> methods.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerStepThrough]
	public static ISafeMemoryHandle ValueToPtr<TMem>(object? value, MarshalerOptions? opts = null) where TMem : ISafeMemoryHandleFactory =>
		MarshaledTypeInfo.WriteInstanceToMemory<TMem>(value, opts);

	/// <summary>Marshals data from a managed object to an unmanaged block of memory.</summary>
	/// <param name="value">A managed object that holds the data to be marshaled. The object must be a structure or an instance of a formatted class.</param>
	/// <param name="opts">The optional options to use when marshaling.</param>
	/// <returns>A pointer to an unmanaged block of memory, which is allocated using <see cref="SafeCoTaskMemHandle"/> methods.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining), DebuggerStepThrough]
	public static ISafeMemoryHandle ValueToPtr(object? value, MarshalerOptions? opts = null) =>
		MarshaledTypeInfo.WriteInstanceToMemory<SafeCoTaskMemHandle>(value, opts);
}