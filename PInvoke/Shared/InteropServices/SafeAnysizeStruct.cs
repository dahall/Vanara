using System.Linq;
using System.Reflection;
using Vanara.PInvoke;

namespace Vanara.InteropServices;

/// <summary>
/// For structures with a single array as the last field that are intended to be variable length, this class manages the structure and
/// automatically marshals the correct structure to memory.
/// </summary>
/// <typeparam name="T">The type of the structure.</typeparam>
public class SafeAnysizeStruct<T> : SafeAnysizeStructBase<T>
{
	private FieldInfo? fiCount;

	/// <summary>Initializes a new instance of the <see cref="SafeAnysizeStruct{T}"/> class.</summary>
	/// <param name="value">The initial value of the structure, if provided.</param>
	/// <param name="sizeFieldName">
	/// The name of the field in <typeparamref name="T"/> that holds the length of the array. If <see langword="null"/>, the first
	/// public field will be selected. If "*", then the array size will be determined by the amount of allocated memory.
	/// </param>
	/// <exception cref="InvalidOperationException">This class can only manange sequential layout structures.</exception>
	public SafeAnysizeStruct(in T value, string? sizeFieldName = null) : base(baseSz)
	{
		InitCountField(sizeFieldName);
		ToNative(value);
	}

	/// <summary>Initializes a new instance of the <see cref="SafeAnysizeStruct{T}"/> class from a pointer.</summary>
	/// <param name="allocatedMemory">A pointer to memory that holds the value of an instance of <typeparamref name="T"/>.</param>
	/// <param name="size">The size of the allocated memory in <paramref name="allocatedMemory"/> in bytes.</param>
	/// <param name="sizeFieldName">
	/// The name of the field in <typeparamref name="T"/> that holds the length of the array. If <see langword="null"/>, the first
	/// public field will be selected. If "*", then the array size will be determined by the amount of allocated memory.
	/// </param>
	public SafeAnysizeStruct(IntPtr allocatedMemory, SizeT size, string? sizeFieldName = null) : base(allocatedMemory, size, false)
	{
		if (allocatedMemory == IntPtr.Zero) throw new ArgumentNullException(nameof(allocatedMemory));
		if (baseSz > size) throw new OutOfMemoryException();
		InitCountField(sizeFieldName);
	}

	/// <summary>Initializes a new instance of the <see cref="SafeAnysizeStruct{T}"/> class with an initial empty memory allocation.</summary>
	/// <param name="size">The size of the reserved memory in bytes.</param>
	/// <param name="sizeFieldName">
	/// The name of the field in <typeparamref name="T"/> that holds the length of the array. If <see langword="null"/>, the first
	/// public field will be selected.
	/// </param>
	public SafeAnysizeStruct(SizeT size, string? sizeFieldName = null) : base(size) => InitCountField(sizeFieldName);

	/// <summary>Performs an implicit conversion from <typeparamref name="T"/> to <see cref="SafeAnysizeStructBase{T}"/>.</summary>
	/// <param name="s">The <typeparamref name="T"/> instance.</param>
	/// <returns>The result of the conversion.</returns>
	[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
	public static implicit operator SafeAnysizeStruct<T>(in T s) => new(s);

	/// <summary>Gets the length of the array from the structure.</summary>
	/// <param name="local">The local, system marshaled, structure instance extracted from the pointer.</param>
	/// <returns>The element length of the 'anysize' array.</returns>
	[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
	protected override int GetArrayLength(in T local) => fiCount is null ? GetArrLenFromSz() : (fiCount.FieldType == typeof(IntPtr) ? ((IntPtr)fiCount.GetValue(local)!).ToInt32() : Convert.ToInt32(fiCount.GetValue(local)));

	private int GetArrLenFromSz() => 1 + (Size - baseSz) / Marshal.SizeOf(elemType);

	private void InitCountField(string? sizeFieldName)
	{
		fiCount = string.IsNullOrEmpty(sizeFieldName) ? structType.GetOrderedFields(binds).First() : structType.GetField(sizeFieldName, binds);
		if (fiCount is null && sizeFieldName != "*") throw new ArgumentException("Invalid size field name.", nameof(sizeFieldName));
	}
}

/// <summary>
/// For structures with a single array as the last field that are intended to be variable length, this class manages the structure and
/// automatically marshals the correct structure to memory.
/// </summary>
/// <typeparam name="T">The type of the structure.</typeparam>
public abstract class SafeAnysizeStructBase<T> : SafeMemoryHandle<CoTaskMemoryMethods>
{
	internal const BindingFlags binds = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;

	/// <summary>The base, unextended size of T.</summary>
	protected static readonly int baseSz;

	/// <summary>The type of the anysize array's elements.</summary>
	protected static readonly Type elemType;

	/// <summary>The reflected field of the array.</summary>
	protected static readonly FieldInfo fiArray;

	/// <summary>The type of the structure.</summary>
	protected static readonly Type structType;

	static SafeAnysizeStructBase()
	{
		structType = typeof(T);
		if (!structType.IsLayoutSequential)
			throw new InvalidOperationException("This class can only manange sequential layout structures.");
		baseSz = Marshal.SizeOf(structType);
		fiArray = structType.GetOrderedFields(binds).Last();
		if (!fiArray.FieldType.IsArray)
			throw new ArgumentException("The field information must be for an array.", nameof(fiArray));
		elemType = fiArray.FieldType.FindElementType()!;
	}

	/// <summary>Initializes a new instance of the <see cref="SafeAnysizeStructBase{T}"/> class.</summary>
	/// <param name="size">The size of memory to allocate, in bytes.</param>
	protected SafeAnysizeStructBase(SizeT size) : base(size) { }

	/// <summary>Initializes a new instance of the <see cref="SafeAnysizeStructBase{T}"/> class.</summary>
	/// <param name="allocatedMemory">The allocated memory.</param>
	/// <param name="size">The size.</param>
	/// <param name="ownsHandle">if set to <see langword="true"/> [owns handle].</param>
	protected SafeAnysizeStructBase(IntPtr allocatedMemory, SizeT size, bool ownsHandle) : base(allocatedMemory, size, ownsHandle) { }

	/// <summary>Gets or sets the structure value.</summary>
	public T Value { get => FromNative(handle, Size); set => ToNative(value); }

	/// <summary>
	/// Performs an explicit conversion from <see cref="SafeAnysizeStructBase{T}"/> to <see cref="IntPtr"/>. The <c>IntPtr</c> is the
	/// memory location of the fully marshaled structure with the full final field array.
	/// </summary>
	/// <param name="s">The <see cref="SafeAnysizeStructBase{T}"/> instance.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator IntPtr(SafeAnysizeStructBase<T> s) => s?.handle ?? IntPtr.Zero;

	/// <summary>Performs an explicit conversion from <see cref="SafeAnysizeStructBase{T}"/> to <typeparamref name="T"/>.</summary>
	/// <param name="s">The <see cref="SafeAnysizeStructBase{T}"/> instance.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator T?(SafeAnysizeStructBase<T> s) => s is null ? default : s.Value;

	/// <summary>Converts the native memory to <typeparamref name="T"/>.</summary>
	/// <param name="allocatedMemory">The allocated memory.</param>
	/// <param name="size">The size.</param>
	/// <returns></returns>
	protected virtual T FromNative(IntPtr allocatedMemory, int size)
	{
		var local = (T?)Marshal.PtrToStructure(allocatedMemory, structType) ?? throw new InvalidOperationException(); // Can't use Convert or get circular ref.
		var cnt = GetArrayLength(local);
		var arrOffset = Marshal.OffsetOf(structType, fiArray.Name).ToInt32();
		Array array = elemType == typeof(string) ? allocatedMemory.ToStringEnum(cnt, GetCharSet(fiArray), arrOffset, size).ToArray() : allocatedMemory.ToArray(elemType, cnt, arrOffset, size)!;
		fiArray.SetValueDirect(__makeref(local), array);
		return local;
	}

	/// <summary>Gets the length of the array from the structure.</summary>
	/// <param name="local">The local, system marshaled, structure instance extracted from the pointer.</param>
	/// <returns>The element length of the 'anysize' array.</returns>
	protected abstract int GetArrayLength(in T local);

	/// <summary>Converts the managed instance to native.</summary>
	/// <param name="value">The managed value.</param>
	protected virtual void ToNative(T value)
	{
		// Get the current array for the last field (or create one if needed)
		var arrVal = fiArray.GetValue(value);
		if (arrVal is null || ((Array)arrVal).Length == 0)
		{
			arrVal = Array.CreateInstance(elemType, 1);
			((Array)arrVal).SetValue(Activator.CreateInstance(elemType), 0);
			fiArray.SetValueDirect(__makeref(value), arrVal);
		}
		// Determine mem required for current struct and last field value
		var arrLen = ((Array)arrVal).Length;
		if (elemType == typeof(string))
		{
			var charSet = GetCharSet(fiArray);
			// Set memory size
			Size = baseSz + (IntPtr.Size * arrLen) + ((string[])arrVal).Sum(s => StringHelper.GetCharSize(charSet) * (s.Length + 1));
			// Marshal base structure - don't use Write to prevent loops
			Marshal.StructureToPtr(value!, handle, false);
			// Push each element of the array into memory, starting with second item in array since first was pushed by StructureToPtr
			var arrOffset = Marshal.OffsetOf(structType, fiArray.Name).ToInt32();
			handle.Write((string[])arrVal, StringListPackMethod.Packed, charSet, arrOffset, Size);
		}
		else
		{
			var arrElemSz = Marshal.SizeOf(elemType);
			var memSz = baseSz + arrElemSz * (arrLen - 1);
			// Set memory size
			Size = memSz;
			// Marshal base structure - don't use Write to prevent loops
			Marshal.StructureToPtr(value!, handle, false);
			// Push each element of the array into memory, starting with second item in array since first was pushed by StructureToPtr
			for (var i = 1; i < arrLen; i++)
				handle.Write(((Array)arrVal).GetValue(i), baseSz + arrElemSz * (i - 1), memSz);
		}
	}

	private static CharSet GetCharSet(FieldInfo fi)
	{
		if (fi.FieldType.IsArray && fi.FieldType.FindElementType() == typeof(string))
		{
			var maa = fi.GetCustomAttribute<MarshalAsAttribute>();
			if (maa is not null)
				return fi.GetCustomAttribute<MarshalAsAttribute>()?.ArraySubType switch
				{
					UnmanagedType.LPWStr => CharSet.Unicode,
					UnmanagedType.LPTStr => CharSet.Auto,
					UnmanagedType.LPStr => CharSet.Ansi,
					_ => CharSet.Auto,
				};
		}
		return fi.DeclaringType!.GetCustomAttribute<StructLayoutAttribute>()?.CharSet ?? CharSet.Auto;
	}
}

/// <summary>
/// A marshaler implementation of <see cref="IVanaraMarshaler"/> to set the marshaler as an attribute using <see
/// cref="SafeAnysizeStruct{T}"/>. Use the cookie paramter of <see
/// cref="SafeAnysizeStructMarshaler{T}.SafeAnysizeStructMarshaler(string)"/> to specify the name of the field in <typeparamref
/// name="T"/> that specifies the number of elements in the last field of <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="T">The structure type to be marshaled.</typeparam>
/// <seealso cref="IVanaraMarshaler"/>
public class SafeAnysizeStructMarshaler<T> : IVanaraMarshaler
{
	private readonly string sizeFieldName;

	/// <summary>Initializes a new instance of the <see cref="SafeAnysizeStructMarshaler{T}"/> class.</summary>
	/// <param name="cookie">
	/// The name of the field in <typeparamref name="T"/> that specifies the number of elements in the last field of <typeparamref name="T"/>.
	/// </param>
	public SafeAnysizeStructMarshaler(string cookie) => sizeFieldName = cookie;

	SizeT IVanaraMarshaler.GetNativeSize() => Marshal.SizeOf(typeof(T));

	SafeAllocatedMemoryHandle IVanaraMarshaler.MarshalManagedToNative(object? managedObject) =>
		managedObject is null ? SafeCoTaskMemHandle.Null : new SafeAnysizeStruct<T>((T)managedObject, sizeFieldName);

	object? IVanaraMarshaler.MarshalNativeToManaged(IntPtr pNativeData, SizeT allocatedBytes)
	{
		if (pNativeData == IntPtr.Zero) return null;
		using var s = new SafeAnysizeStruct<T>(pNativeData, allocatedBytes, sizeFieldName);
		return s.Value;
	}
}

/// <summary>
/// A marshaler implementation of <see cref="IVanaraMarshaler"/> to marshal structures whose last field is a character array of length
/// (1) and that uses a field to determine the length of the full string.
/// <para>
/// Use the cookie paramter of <see cref="AnySizeStringMarshaler{T}"/> to specify the name of the field in <typeparamref name="T"/> that
/// specifies the length of the string in the last field of <typeparamref name="T"/> along with use indicators.
/// </para>
/// <para>
/// If the field specifies byte, rather than character length, follow the field name with a colon (:) followed by 'b' (for bytes) or 'c'
/// (for characters).
/// </para>
/// <para>
/// If the field specifies a length that does NOT include the NULL terminator, follow the field name, colon (:), and type specifier by
/// 'r' (for raw) or 'n' (for null-terminated).
/// </para>
/// <para>If the field name is "*", then the string length will be determined by the amount of allocated memory.</para>
/// </summary>
/// <typeparam name="T">The structure type to be marshaled.</typeparam>
public class AnySizeStringMarshaler<T> : IVanaraMarshaler
{
	private static readonly int charSz;
	private static readonly int baseSz;
	private readonly FieldInfo? fiCount;
	private static readonly FieldInfo fiArray;
	private static readonly int strOffset;
	private readonly bool cntIsBytes = false;
	private readonly bool cntInclNull = true;
	private readonly bool allMem = false;
	private readonly CharSet charSet;

	static AnySizeStringMarshaler()
	{
		var structType = typeof(T);
		if (!structType.IsLayoutSequential)
			throw new InvalidOperationException("This class can only manange sequential layout structures.");
		baseSz = Marshal.SizeOf(structType);
		fiArray = structType.GetOrderedFields(SafeAnysizeStructBase<T>.binds).Last();
		if (fiArray.FieldType != typeof(string))
			throw new ArgumentException("The field information must be for a string.", nameof(fiArray));
		charSz = StringHelper.GetCharSize(typeof(T).StructLayoutAttribute?.CharSet ?? CharSet.Auto);
		strOffset = Marshal.OffsetOf(structType, fiArray.Name).ToInt32();// unchecked((uint)Marshal.ReadInt32(fiArray.FieldHandle.Value.Offset(4 + IntPtr.Size))) & 0x7FFFFFF;
	}

	/// <summary>Initializes a new instance of the <see cref="AnySizeStringMarshaler{T}"/> class.</summary>
	/// <param name="cookie">
	/// The name of the field in <typeparamref name="T"/> that specifies the number of elements in the last field of <typeparamref name="T"/>.
	/// <para>
	/// If the field specifies byte, rather than character length, follow the field name with a colon (:) followed by 'b' (for bytes) or
	/// 'c' (for characters).
	/// </para>
	/// <para>
	/// If the field specifies a length that does NOT include the NULL terminator, follow the field name, colon (:), and type specifier
	/// by 'r' (for raw) or 'n' (for null-terminated).
	/// </para>
	/// </param>
	public AnySizeStringMarshaler(string cookie)
	{
		charSet = typeof(T).StructLayoutAttribute?.CharSet ?? CharSet.Auto;
		if (string.IsNullOrEmpty(cookie))
			fiCount = typeof(T).GetOrderedFields(SafeAnysizeStructBase<T>.binds).First();
		else if (cookie == "*")
			allMem = true;
		else
		{
			var parts = cookie.Split(':');
			if (parts.Length == 2 && parts[1].Length >= 2)
			{
				cntIsBytes = parts[1][0] == 'b';
				cntInclNull = parts[1].Length > 1 && parts[1][1] == 'n';
			}
			fiCount = typeof(T).GetField(parts[0], SafeAnysizeStructBase<T>.binds);
		}
		if (fiCount is null && !allMem) throw new ArgumentException("Invalid string length field name.", nameof(cookie));
	}

	SizeT IVanaraMarshaler.GetNativeSize() => baseSz;

	SafeAllocatedMemoryHandle IVanaraMarshaler.MarshalManagedToNative(object? managedObject)
	{
		if (managedObject is null) return SafeCoTaskMemHandle.Null;
		var h = new SafeCoTaskMemHandle(baseSz);
		var str = fiArray.GetValue(managedObject) as string;
		var len = allMem ? StringHelper.GetByteCount(str, true, charSet) : Convert.ToInt32(fiCount!.GetValue(managedObject));
		var clen = cntIsBytes ? len / charSz : len;
		if (cntInclNull && !allMem) --clen;
		if (str is not null && str.Length > clen)
			str = str.Substring(0, clen);
		h.Size += StringHelper.GetByteCount(str, cntInclNull, charSet) - charSz;
		Marshal.StructureToPtr(managedObject, h, false);
		StringHelper.Write(str, ((IntPtr)h).Offset(strOffset), out _, cntInclNull, charSet);
		return h;
	}

	object? IVanaraMarshaler.MarshalNativeToManaged(IntPtr pNativeData, SizeT allocatedBytes)
	{
		if (pNativeData == IntPtr.Zero) return null;
		var o = Marshal.PtrToStructure(pNativeData, typeof(T));
		int len;
		if (allMem)
			len = (allocatedBytes - strOffset) / charSz;
		else
		{
			len = Convert.ToInt32(fiCount!.GetValue(o));
			if (cntIsBytes) len /= charSz;
			if (cntInclNull) --len;
		}
		fiArray.SetValue(o, StringHelper.GetString(pNativeData.Offset(strOffset), len, charSet));
		return o;
	}
}