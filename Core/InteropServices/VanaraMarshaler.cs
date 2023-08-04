using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Vanara.PInvoke;

namespace Vanara.InteropServices;

/// <summary>Smarter custom marshaler.</summary>
public interface IVanaraMarshaler
{
	/// <summary>Gets the size of the native data.</summary>
	/// <returns>
	/// The size, in bytes, of the base object in memory. This should return the equivalent of the sizeof(X) function in C/C++.
	/// </returns>
	SizeT GetNativeSize();

	/// <summary>Marshals the managed object to its native, in-memory, value.</summary>
	/// <param name="managedObject">The managed object to marshal.</param>
	/// <returns>The self-destroying handle to the binary representation.</returns>
	SafeAllocatedMemoryHandle MarshalManagedToNative(object? managedObject);

	/// <summary>Marshals the native memory to a managed object.</summary>
	/// <param name="pNativeData">The pointer to the native data.</param>
	/// <param name="allocatedBytes">The number of allocated bytes.</param>
	/// <returns>The type instance.</returns>
	object? MarshalNativeToManaged(IntPtr pNativeData, SizeT allocatedBytes);
}

/// <summary>Provides methods to assist with custom marshaling.</summary>
public static class VanaraMarshaler
{
	/// <summary>Determines whether a type can be marshaled.</summary>
	/// <param name="t">The type to check.</param>
	/// <param name="marshaler">On success, the marshaler instance.</param>
	/// <returns><see langword="true"/> if this type can marshaled; otherwise, <see langword="false"/>.</returns>
	public static bool CanMarshal(Type t, [NotNullWhen(true)] out IVanaraMarshaler? marshaler)
	{
		var vattr = t.GetCustomAttributes<VanaraMarshalerAttribute>(true).FirstOrDefault();
		if (vattr != null)
		{
			var cookie = vattr.Cookie;
			marshaler = cookie is null ?
				Activator.CreateInstance(vattr.MarshalType) as IVanaraMarshaler :
				Activator.CreateInstance(vattr.MarshalType, cookie) as IVanaraMarshaler;
			return marshaler != null;
		}
		if (typeof(IVanaraMarshaler).IsAssignableFrom(t))
		{
			marshaler = Activator.CreateInstance(t) as IVanaraMarshaler;
			return marshaler != null;
		}
		marshaler = null;
		return false;
	}

	/// <summary>Determines whether a type can be marshaled.</summary>
	/// <typeparam name="T">The type to check.</typeparam>
	/// <param name="marshaler">On success, the marshaler instance.</param>
	/// <returns><see langword="true"/> if this type can marshaled; otherwise, <see langword="false"/>.</returns>
	public static bool CanMarshal<T>([NotNullWhen(true)] out IVanaraMarshaler? marshaler) => CanMarshal(typeof(T), out marshaler);
}

/// <summary>Provides an <see cref="ICustomMarshaler"/> instance that utilizes an <see cref="IVanaraMarshaler"/> implementation.</summary>
/// <typeparam name="T">
/// The type that either implements <see cref="IVanaraMarshaler"/> or uses <see cref="VanaraMarshalerAttribute"/> to specify a type.
/// </typeparam>
/// <seealso cref="ICustomMarshaler"/>
public class VanaraCustomMarshaler<T> : ICustomMarshaler
{
	private SafeAllocatedMemoryHandle? mem;
	private readonly string? cookie;

	private VanaraCustomMarshaler(string? cookie) => this.cookie = cookie;

	/// <summary>Gets the instance.</summary>
	/// <param name="cookie">The cookie.</param>
	/// <returns></returns>
	public static ICustomMarshaler GetInstance(string? cookie) => new VanaraCustomMarshaler<T>(cookie);

	void ICustomMarshaler.CleanUpManagedData(object ManagedObj)
	{
	}

	void ICustomMarshaler.CleanUpNativeData(IntPtr pNativeData) => mem?.Dispose();

	int ICustomMarshaler.GetNativeDataSize() => VanaraMarshaler.CanMarshal<T>(out var m) ? (int)m!.GetNativeSize() : -1;

	IntPtr ICustomMarshaler.MarshalManagedToNative(object ManagedObj) => VanaraMarshaler.CanMarshal<T>(out var m) ? (mem = m!.MarshalManagedToNative(ManagedObj)) : throw new InvalidOperationException("Cannot marshal this type.");

	object ICustomMarshaler.MarshalNativeToManaged(IntPtr pNativeData) => VanaraMarshaler.CanMarshal<T>(out var m) ? m!.MarshalNativeToManaged(pNativeData, SizeT.MaxValue) ?? throw new ArgumentNullException(nameof(pNativeData)) : throw new InvalidOperationException("Cannot marshal this type.");
}

/// <summary>Apply this attribute to a class or structure to have all Vanara interop function process via the marshaler.</summary>
/// <seealso cref="Attribute"/>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false)]
public class VanaraMarshalerAttribute : Attribute
{
	/// <summary>Initializes a new instance of the <see cref="VanaraMarshalerAttribute"/> class.</summary>
	/// <param name="marshalType">A type that derives from <see cref="IVanaraMarshaler"/> that will marshal this class or structure.</param>
	/// <param name="cookie">The cookie value to pass to the constructor.</param>
	/// <exception cref="ArgumentNullException">marshalType</exception>
	/// <exception cref="ArgumentException">The supplied type must inherit from {nameof(IVanaraMarshaler)}. - marshalType</exception>
	public VanaraMarshalerAttribute(Type marshalType, string? cookie = null)
	{
		if (marshalType is null)
			throw new ArgumentNullException(nameof(marshalType));
		if (!typeof(IVanaraMarshaler).IsAssignableFrom(marshalType))
			throw new ArgumentException($"The supplied type ({marshalType?.FullName}) must inherit from {nameof(IVanaraMarshaler)}.", nameof(marshalType));
		MarshalType = marshalType;
		Cookie = cookie;
	}

	/// <summary>Gets the cookie value, that if not <see langword="null"/>, will get passed to the constructor of <see cref="MarshalType"/>.</summary>
	public string? Cookie { get; }

	/// <summary>Gets the type that will marshal this class or structure.</summary>
	public Type MarshalType { get; }
}