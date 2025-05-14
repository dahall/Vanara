using System.Runtime.InteropServices;
using Vanara.Marshaler;

namespace UnitTests;

// 32, 64: 16
[Marshaled]
internal struct TestSizeBitStruct
{
	[MarshalFieldAs.SizeOf]
	public uint size;

	[MarshalFieldAs.BitField<uint>]
	public bool bitField;

	[MarshalFieldAs.BitField<uint>(3)]
	public byte bitField2;

	[MarshalFieldAs.BitField<uint>(2, StartNewField = true)]
	public bool bitField3;

	[MarshalFieldAs.BitField<uint>(31)]
	public uint bitFieldOverflow;
}

[StructLayout(LayoutKind.Sequential)]
internal struct NativeSizeBitStruct
{
	public uint size;
	private uint bitField1;
	private uint bitField2;
	private uint bitField3;
}

[Marshaled]
internal struct TestNestedStruct
{
	public int iVal;
	public SimpleStruct nestedStruct;
	public IntPtr ptr;
}

[StructLayout(LayoutKind.Sequential)]
internal struct NativeNestedStruct
{
	public int iVal;
	public NativeSimpleStruct nestedStruct;
	public IntPtr ptr;
}

// 32, 64: 48
[Marshaled]
internal struct TestUnionItemsStruct
{
	public int iVal;

	[MarshalFieldAs.UnionField]
	public string union1Value1;

	[MarshalFieldAs.UnionField]
	public IntPtr union1Value2;

	[MarshalFieldAs.UnionField]
	public SimpleStruct union1Value3;

	public TestUnionStruct unionSet;

	public uint uVal;
}

internal struct NativeUnionItemsStruct
{
	public int iVal;
	public NativeSimpleStruct union1Value3; // largest field in set of union fields
	public NativeUnionStruct unionSet;
	public uint uVal;
}

// 32, 64: 8
[Marshaled(LayoutModel.Union)]
internal struct TestUnionStruct
{
	public int iVal;
	public long lVal;
	public byte bVal;
}

internal struct NativeUnionStruct
{
	public long lVal; // largest field in union
}

// 32, 64: 64
[Marshaled]
internal struct TestByValArrayStruct
{
	[MarshalFieldAs.ArrayPtr(ArrayLayout.ByValArray, SizeConst = 4)]
	public Guid[] pointerToArray;
}

internal struct NativeByValArrayStruct
{
	public unsafe fixed byte pointerToArray[16 * 4]; // sizeof(Guid) * SizeConst
}

// 32, 64: 20
[Marshaled]
internal struct TestAnySizeArrayStruct
{
	[MarshalFieldAs.SizeOf]
	public uint size;

	private uint arrayCount;

	[MarshalFieldAs.ArrayPtr(ArrayLayout.ByValArray, SizeFieldName = nameof(arrayCount), SingleElementPlaceholder = true)]
	public Guid[] array;
}

internal struct NativeAnySizeArrayStruct
{
	public uint size; // Initialized to 24 (4 + 4 + 16)
	public uint arrayCount;
	public unsafe fixed byte array[16 * 1]; // sizeof(Guid) * arrayCount
}

// 32: 8, 64: 16
[Marshaled]
internal struct TestArrayPtrStruct
{
	private uint arrayCount;

	[MarshalFieldAs.ArrayPtr(ArrayLayout.LPArray, SizeFieldName = nameof(arrayCount))]
	public Guid[] array;
}

internal struct NativeArrayPtrStruct
{
	public uint arrayCount;
	public IntPtr array;
}

// 32, 64: 24
[Marshaled]
internal struct SimpleStruct
{
	public int iVal;
	public long lVal;
	public byte bVal;
}

internal struct NativeSimpleStruct
{
	public int iVal;
	public long lVal;
	public byte bVal;
}

// 32, 64: 64
[Marshaled]
internal struct MultiDimArrayStruct
{
	[MarshalFieldAs.ArrayPtr(ArrayLayout.ByValArray, SizeConst = 16)]
	public float[,] pointerToArray;
}

internal struct NativeMultiDimArrayStruct
{
	public unsafe fixed byte array[4 * 16]; // sizeof(float) * SizeConst
}

// 32, 64: 8
[Marshaled(LayoutModel.Union)]
internal struct SimpleUnionStruct
{
	public int iVal;
	public long lVal;
	public byte bVal;
}

internal struct NativeSimpleUnionStruct
{
	public long lVal; // largest field in structure
}

// 32: 8, 64: 16
[Marshaled]
internal struct MarshalAsStruct
{
	[MarshalAs(UnmanagedType.I1)]
	public bool bVal;

	[MarshalAs(UnmanagedType.LPWStr)]
	public string sVal;
}

internal struct NativeMarshalAsStruct
{
	public byte bVal;
	public IntPtr sVal;
}

// 32: 8, 64: 16
[Marshaled]
internal struct StructPtrStruct
{
	public int iVal;

	[MarshalFieldAs.StructPtr]
	public Guid? guid;
}

internal struct NativeStructPtrStruct
{
	public int iVal;
	public IntPtr guid;
}