using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.CompilerServices;
using Vanara.Extensions.Reflection;
using Vanara.PInvoke;

namespace Vanara.Marshaler;

internal static class Extensions
{
	public const BindingFlags allInstFields = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;

	public static bool HasMembers(this Type type)
	{
		var f = type.GetFields(allInstFields);
		return f.Length switch
		{
			0 => false,
			> 1 => true,
			_ => f[0].FieldType != type
		};
	}

	/// <summary>Gets a value that determines if the type is a blittable type.</summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool IsMarshaledType(this Type type) => type.GetCustomAttribute<MarshaledAttribute>() != null;

	//public static bool IsBlittable2(this Type type) => type.IsPrimitive || type.IsMarshalByRef || type.IsEnum ||
	//	(type.IsLayoutSequential && type.GetFields(allInstFields).All(fi => fi.FieldType.IsBlittable2()));
	public static bool IsBlittable2(this Type? type)
	{
		// Try to prevent exception-based check by doing a bunch of checks
		if (type is not null && (type.IsBlittablePrimitive() || type.IsBlittableArray() ||
			(!type.IsPrimitive && type.IsLayoutSequential && type.GetFields(allInstFields).All(Vanara.Extensions.Reflection.ReflectionExtensions.IsBlittableField))))
		{
			// Final check: Non-blittable types cannot allocate pinned handle
			try
			{
				Marshal.SizeOf(type!);
				return true;
			}
			catch { }
		}
		return false;
	}

	public static ISafeMemoryHandle CreateEx<TMem>(this TMem h, SIZE_T size) where TMem : ISafeMemoryHandleFactory => CreateSafeMemory<TMem>(size);

	public static ISafeMemoryHandle CreateSafeMemory<TMem>(SIZE_T size) where TMem : ISafeMemoryHandleFactory =>
#if NET7_0_OR_GREATER
		TMem.Create(size);
#else
		typeof(TMem).GetMethod("Create", BindingFlags.Public | BindingFlags.Static, null, [typeof(SIZE_T)], null)?.
			Invoke(null, [size]) as ISafeMemoryHandle ?? throw new NotSupportedException($"Cannot create SafeMemoryHandle of type {typeof(TMem).Name}.");
#endif

	public static ISafeMemoryHandle CreateSafeMemory<TMem>(byte[] bytes) where TMem : ISafeMemoryHandleFactory =>
#if NET7_0_OR_GREATER
		TMem.Create(bytes);
#else
		typeof(TMem).GetMethod("Create", BindingFlags.Public | BindingFlags.Static, null, [typeof(byte[])], null)?.
			Invoke(null, [bytes]) as ISafeMemoryHandle ?? throw new NotSupportedException($"Cannot create SafeMemoryHandle of type {typeof(TMem).Name}.");
#endif

	public static T Mask<T>(this T value, int bitsToMask) where T :
#if NET7_0_OR_GREATER
		IBinaryInteger<T> => (T.One << bitsToMask) - T.One & value;
#elif NETFRAMEWORK || NETSTANDARD2_0_OR_GREATER
		unmanaged, IConvertible => (T)(object)((1UL << bitsToMask) - 1 & value.ToUInt64(null));
#else
		unmanaged, IConvertible => (T)(dynamic)((1UL << bitsToMask) - 1 & value.ToUInt64(null));
#endif

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static T MaskAndShift<T>(this T value, int bitsToMask, int shift = 0) where T :
#if NET7_0_OR_GREATER
		IBinaryInteger<T> => value.Mask(bitsToMask) << shift;
#elif NETFRAMEWORK || NETSTANDARD2_0_OR_GREATER
		unmanaged, IConvertible => (T)(object)(value.ToUInt64(null).Mask(bitsToMask) << shift);
#else
		unmanaged, IConvertible => (T)(dynamic)(value.ToUInt64(null).Mask(bitsToMask) << shift);
#endif

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static object AdjustBitness(this IntPtr ptr, Bitness bitness) => bitness == Bitness.X32bit ? ptr.ToInt32() : ptr.ToInt64();

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Bitness Resolve(this Bitness b) => b == Bitness.Auto ? (Bitness)(IntPtr.Size * 8) : b;

	public static object? ChangeType(object? value, Type dest) => value switch
	{
		null => null,
		IntPtr ip => Convert.ChangeType(ip.ToInt64(), dest),
		UIntPtr up => Convert.ChangeType(up.ToUInt64(), dest),
		_ when dest == typeof(IntPtr) => (IntPtr)(long)Convert.ChangeType(value, typeof(long)),
		_ when dest == typeof(UIntPtr) => (UIntPtr)(ulong)Convert.ChangeType(value, typeof(ulong)),
		_ => Convert.ChangeType(value, dest),
	};

	public static Encoding ToEncoding(this StringEncoding stringEncoding) => stringEncoding switch
	{
		StringEncoding.ASCII => Encoding.ASCII,
		StringEncoding.Unicode => Encoding.Unicode,
		StringEncoding.UTF8 => Encoding.UTF8,
		StringEncoding.UTF32 => Encoding.UTF32,
		_ => Encoding.Default,
	};
}