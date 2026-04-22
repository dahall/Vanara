namespace Vanara.PInvoke;

//static partial class SizeDefTestMethods
//{
//	static partial void Func1([SizeDef("len", SizingMethod.Count /* default */)] StringBuilder? sb, [Range(0, 50)] int len);
//	static partial void Func2([SizeDef("len", SizingMethod.Count | SizingMethod.Bytes)] StringBuilder? sb, [Range(0, 50)] int len);
//	static partial void Func3([SizeDef("len", SizingMethod.Count | SizingMethod.Bytes | SizingMethod.InclNullTerm)] StringBuilder? sb, [Range(0, 50)] int len);
//	static partial void Func4([SizeDef("len", SizingMethod.Query)] StringBuilder? sb, [Range(0, 50)] ref int len);
//	static partial void Func5([SizeDef("len", SizingMethod.Query | SizingMethod.Bytes)] StringBuilder? sb, [Range(0, 50)] ref int len);
//	static partial void Func6([SizeDef("len", SizingMethod.Query, OutVarName = "lenReq")] StringBuilder? sb, [Range(0, 50)] int len, out int lenReq);

//	static partial void Func7([SizeDef("len", SizingMethod.Count /* default */)] int[]? arr, [Range(0, 50)] int len);
//	static partial void Func8([SizeDef("len", SizingMethod.Count | SizingMethod.Bytes)] int[]? arr, [Range(0, 50)] int len);
//	static partial void Func11([SizeDef("len", SizingMethod.Query)] int[]? arr, [Range(0, 50)] ref int len);
//	static partial void Func12([SizeDef("len", SizingMethod.Query | SizingMethod.Bytes)] int[]? arr, [Range(0, 50)] ref int len);
//	static partial void Func13([SizeDef("len", SizingMethod.Query, OutVarName = "lenReq")] int[]? arr, [Range(0, 50)] int len, out int lenReq);
//}

/// <summary>Specifies the method used to determine the size of a field or array.</summary>
[Flags]
public enum SizingMethod
{
	/// <summary>Size is determined by the size of the field.</summary>
	Count = 0x0,

	/// <summary>Size is determined by the size of the array.</summary>
	Bytes = 0x1,

	/// <summary>Size includes the null terminator.</summary>
	InclNullTerm = 0x2,

	/// <summary>Size is determined by a query to the field.</summary>
	Query = 0x4,

	/// <summary>Size is returned as the result of the method.</summary>
	QueryResultInReturn = 0xC,

	/// <summary>Size is determined by checking the last error after a query for ERROR_INSUFFICIENT_BUFFER.</summary>
	CheckLastError = 0x14,

	/// <summary>Size should be guessed by gradually increasing the value</summary>
	Guess = 0x20,
}

/// <summary>
/// <note type="implement">This attribute does not yet have an implemented generator.</note>
/// Attribute to indicate the size of a string or array field or parameter.</summary>
[AttributeUsage(AttributeTargets.Field | AttributeTargets.Parameter, Inherited = false, AllowMultiple = false)]
public sealed class SizeDefAttribute(string? refVarName, SizingMethod method = SizingMethod.Count) : Attribute
{
	/// <summary>Initializes a new instance of the <see cref="SizeDefAttribute"/> class using a fixed size.</summary>
	public SizeDefAttribute(int count) : this(count.ToString()) { }

	/// <summary>Gets the sizing method used to determine the size of an element.</summary>
	public SizingMethod Method { get; } = method;

	/// <summary>
	/// Gets or sets the name of the variable that receives the required size of the field or parameter after a query. This value is
	/// initialized to the value of <see cref="RefVarName"/>.
	/// </summary>
	public string? OutVarName { get; set; } = refVarName;

	/// <summary>Gets the name of the reference variable.</summary>
	public string? RefVarName { get; } = refVarName;

	/// <summary>
	/// Gets or sets the size of the initial buffer set before the first call to the method in a query scenario. This is used to initialize
	/// the buffer size for the first call when using a sizing method that involves querying for the required size. The generator will use
	/// this value for the initial call, and then update it based on the returned required size for subsequent calls if necessary. If zero,
	/// the generator will set the buffer pointer to NULL. If -1, the generator will use the default size of the type (byte for IntPtr,
	/// element size for arrays and structures). If a positive value, the generator will use that value as the initial buffer size. This
	/// allows for optimization in cases where a typical size is known, reducing the number of calls needed to determine the required size.
	/// </summary>
	public int InitSize { get; set; } = 0;
}

/// <summary>Attribute to indicate that a field or parameter should be ignored when generating code.</summary>
[AttributeUsage(AttributeTargets.Field | AttributeTargets.Parameter, Inherited = false, AllowMultiple = false)]
public sealed class IgnoreAttribute() : Attribute
{
}

/// <summary>
/// Specifies metadata for pointer definitions used in interop scenarios, enabling customization of marshaling and memory management between
/// managed and unmanaged code.
/// </summary>
public abstract class PointerDefAttribute : Attribute
{
	/// <summary>Gets or sets the character set used for string marshalling. This is relevant when the pointer represents a string or structure containing strings.</summary>
	public CharSet CharSet { get; set; } = CharSet.Auto;

	/// <summary>Gets or sets the type used to marshal data between managed and unmanaged code.</summary>
	public Type? Marshaler { get; set; }

	/// <summary>
	/// Gets or sets the type used to manage memory for the structure. This should be used when the structure is allocated by the unmanaged
	/// code and needs to be freed after use.
	/// </summary>
	//If this is set, <see cref="FreeStatement"/> is ignored.
	public Type? MemoryManager { get; set; }
}

/// <summary>Specifies that a parameter represents a pointer to an array for interop scenarios.</summary>
[AttributeUsage(AttributeTargets.Parameter, Inherited = false, AllowMultiple = false)]
public sealed class ArrayPointerAttribute(Type elementType, string elemCountVarName) : PointerDefAttribute
{
	/// <summary>
	/// Treat elements as by reference (i.e., pointers to the elements) rather than by value. This is useful when the native array is a set
	/// of pointers to structures rather than an array of structures. When set to true, the generator will treat each element as a pointer
	/// and generate code accordingly.
	/// </summary>
	public bool ElementsAreByRef { get; set; } = false;

	/// <summary>Gets the name of the variable that contains the count of elements in the array.</summary>
	public string ElementCountVarName { get; } = elemCountVarName;

	/// <summary>Gets the structure type that the parameter points to.</summary>
	public Type ElementType { get; } = elementType;
}

/// <summary>
/// Specifies that a parameter is a pointer to a structure type, enabling control over marshaling behavior between managed and unmanaged code
/// in platform invoke (P/Invoke) scenarios.
/// </summary>
/// <remarks>
/// Apply this attribute to a parameter to indicate that it represents a pointer to a structure, and to control whether the structure is
/// automatically marshaled or handled as a raw pointer. This is particularly useful when interoperating with native APIs that require
/// pointers to structures, especially when those structures contain fields that are themselves pointers to allocated memory. Setting marshal
/// to false allows advanced scenarios where manual memory management or custom marshaling is required.
/// </remarks>
/// <param name="structType">
/// The type of the structure that the parameter points to. Must be a valid structure type compatible with the unmanaged API.
/// </param>
/// <param name="marshal">
/// true to marshal the structure between managed and unmanaged code (default); false to return a pointer wrapped in a memory handle instead
/// of marshaling.
/// </param>
[AttributeUsage(AttributeTargets.Parameter, Inherited = false, AllowMultiple = false)]
public sealed class StructPointerAttribute(Type structType, bool marshal = true) : PointerDefAttribute
{
	/// <summary>Gets the structure type that the parameter points to.</summary>
	public Type StructType { get; } = structType;

	/// <summary>
	/// Gets a value indicating whether the structure should be marshaled between managed and unmanaged code. If set to <see
	/// langword="true"/> (the default), the generator will return the marshaled value. If set to false, the generator will return the
	/// pointer wrapped in a memory handle. This is useful in scenarios where the structure contains fields that are pointers to allocated memory.
	/// </summary>
	public bool Marshal { get; } = marshal;

	/*struct UNMGD
	{
		public int Field1;
		public int Field2;
	}

	internal struct MGD
	{
		[MarshalAs(UnmanagedType.LPStr)]
		public string Field1;
		public int Field2;
	}

	internal class MMGD : IVanaraMarshaler
	{
		SizeT IVanaraMarshaler.GetNativeSize() => throw new NotImplementedException();
		SafeAllocatedMemoryHandle IVanaraMarshaler.MarshalManagedToNative(object? managedObject) => throw new NotImplementedException();
		object? IVanaraMarshaler.MarshalNativeToManaged(nint pNativeData, SizeT allocatedBytes) => throw new NotImplementedException();
	}

	[DllImport("X"), System.Runtime.CompilerServices.OverloadResolutionPriority(1)] static extern Win32Error SampleMethod([Out, SizeDef(nameof(bufferLength), SizingMethod.Query), StructPointer(typeof(MGD))] IntPtr buffer, ref uint bufferLength);
	[DllImport("X")] static unsafe extern Win32Error SampleMethod([Out, SizeDef(nameof(bufferLength), SizingMethod.Query), StructPointer(typeof(MGD))] void* buffer, ref uint bufferLength);
	[DllImport("X")] static unsafe extern Win32Error SampleMethod([Out, SizeDef(nameof(bufferLength), SizingMethod.Query), StructPointer(typeof(UNMGD))] UNMGD* buffer, ref uint bufferLength);
	/// <inheritdoc cref="SampleMethod(IntPtr, ref uint)" />
	[PInvokeData("appmodel.h", MSDNShortId = "4CFC707A-2A5A-41FE-BB5F-6FECACC99271")]
	internal static Win32Error SampleMethod(out MGD buffer)
	{
		buffer = default;
		uint bufferLength = 0;
		Win32Error ret = SampleMethod(default, ref bufferLength);
		if (FailedHelper.FAILED(ret, true))
			return ret;
		int __cElem = Convert.ToInt32(bufferLength);
		byte[] __buffer = new byte[__cElem];
		ret = SampleMethod(global::System.Runtime.InteropServices.Marshal.UnsafeAddrOfPinnedArrayElement(__buffer, 0), ref bufferLength);
		if (global::Vanara.PInvoke.FailedHelper.FAILED(ret, false))
			return ret;
		buffer = global::System.Runtime.InteropServices.Marshal.UnsafeAddrOfPinnedArrayElement(__buffer, 0).ToStructure<MGD>(__cElem);
		return ret;
	}

	[DllImport("X"), System.Runtime.CompilerServices.OverloadResolutionPriority(1)] static extern Win32Error SampleMethodM([Out, SizeDef(nameof(bufferLength), SizingMethod.Query), StructPointer(typeof(MGD), Marshaler = typeof(MMGD))] IntPtr buffer, ref uint bufferLength);
	internal static Win32Error SampleMethodM(out MGD buffer)
	{
		buffer = default;
		uint bufferLength = 0;
		Win32Error ret = SampleMethod(default, ref bufferLength);
		if (FailedHelper.FAILED(ret, true))
			return ret;
		int __cElem = Convert.ToInt32(bufferLength);
		byte[] __buffer = new byte[__cElem];
		ret = SampleMethod(global::System.Runtime.InteropServices.Marshal.UnsafeAddrOfPinnedArrayElement(__buffer, 0), ref bufferLength);
		if (global::Vanara.PInvoke.FailedHelper.FAILED(ret, false))
			return ret;
		buffer = global::Vanara.InteropServices.MarshalHelper.MarshalFromNative<MMGD, MGD>(__buffer);
		return ret;
	}

	[DllImport("X")] static extern Win32Error SampleMethodInPtr([In, SizeDef(nameof(bufferLength)), StructPointer(typeof(MGD))] IntPtr buffer, uint bufferLength);
	internal static Win32Error SampleMethodInPtr(in MGD buffer)
	{
		using SafeHGlobalStruct<MGD> __buffer = buffer;
		Win32Error ret = SampleMethodInPtr(__buffer, __buffer.Size);
		return ret;
	}
	[DllImport("X")] static extern Win32Error SampleMethodIn([In, SizeDef(nameof(bufferLength))] in MGD buffer, uint bufferLength);
	internal static Win32Error SampleMethodIn(in MGD buffer)
	{
		uint bufferLength = global::Vanara.Extensions.InteropExtensions.SizeOf<MGD>();
		IntPtr __buffer = global::Vanara.Extensions.InteropExtensions.IsBlittable(buffer.GetType()) ? new global::Vanara.InteropServices.PinnedObject(buffer) : global::Vanara.InteropServices.SafeHGlobalHandle.CreateFromStructure(buffer);
		Win32Error ret = SampleMethodInPtr(__buffer, bufferLength);
		return ret;
	}
	[DllImport("X")] static unsafe extern Win32Error SampleMethod([In, SizeDef(nameof(bufferLength)), StructPointer(typeof(MGD))] void* buffer, uint bufferLength);
	[DllImport("X")] static unsafe extern Win32Error SampleMethod([In, SizeDef(nameof(bufferLength)), StructPointer(typeof(UNMGD))] UNMGD* buffer, uint bufferLength);


	[DllImport("X")] static extern Win32Error SampleMethodFree([Out, StructPointer(typeof(MGD))] out ISafeMemoryHandleBase buffer);
	internal static Win32Error SampleMethodFree(out MGD buffer)
	{
		Win32Error ret;
		buffer = default;
		if (FailedHelper.FAILED(ret = SampleMethodFree(out ISafeMemoryHandleBase __buffer), true))
			return ret;
		using (__buffer)
			buffer = __buffer.DangerousGetHandle().ToStructure<MGD>(__buffer.Size);
		return ret;
	}

	[DllImport("X")] static extern Win32Error SampleMethodFreePtr([Out, StructPointer(typeof(BOOL), MemoryManager = typeof(CoTaskMemoryMethods))] out IntPtr buffer);
	internal static Win32Error SampleMethodFreePtr(out BOOL buffer)
	{
		Win32Error ret;
		buffer = default;
		if (FailedHelper.FAILED(ret = SampleMethodFreePtr(out IntPtr __buffer), true))
			return ret;
		if (__buffer != default) {
			try {
				global::Vanara.PInvoke.SizeT __memSz = CoTaskMemoryMethods.Instance is global::Vanara.InteropServices.IGetMemorySize __igetmemsz ? __igetmemsz.GetSize(__buffer) : uint.MaxValue;
				buffer = __buffer.ToStructure<BOOL>(__memSz);
			}
			finally { CoTaskMemoryMethods.Instance.FreeMem(__buffer); }
		}
		return ret;
	}

	[DllImport("X"), OverloadResolutionPriority(1)] static extern Win32Error SampleMethodOptOut([Out, Optional, StructPointer(typeof(uint))] IntPtr buffer);
	internal static Win32Error SampleMethodOptOut(out uint buffer)
	{
		buffer = default;
		using var __buffer = new PinnedObject(buffer);
		return SampleMethodOptOut(__buffer);
	}*/
}