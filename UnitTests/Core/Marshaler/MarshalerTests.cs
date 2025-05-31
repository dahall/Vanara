using AutoFixture;
using AutoFixture.Kernel;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Vanara.Marshaler.Tests;

[TestFixture]
public class MarshalerTests
{
	private static readonly byte[] control = [0x77, 0x77, 0x77, 0x77, 0, 0, 0, 0, 0x77, 0x77, 0x77, 0x77, 0x77, 0x77, 0x77, 0x77, 7, 0, 0, 0, 0, 0, 0, 0];
	private static Struct01 value = new() { iVal = 0x77777777, lVal = 0x7777777777777777, bVal = 7 };

	[Test]
	public unsafe void SimpleStructTest()
	{
		const int sz = 24;
		Assert.That(Marshaler.SizeOf<Struct01>(), Is.EqualTo(sz));
		using var result = Marshaler.ValueToPtr(value);
		Assert.That(result?.DangerousGetHandle() ?? IntPtr.Zero, Is.Not.Zero);
		UnmanagedMemoryStream stream = new((byte*)(result?.DangerousGetHandle() ?? IntPtr.Zero), sz);
		byte[] data = new byte[sz];
		stream.Read(data, 0, sz);
		Assert.That(data, Is.EquivalentTo(control));
	}

	[TestCaseSource(nameof(GetStructList), new object?[] { 1, 34 })]
	public void StructSizeTest(Type objType)
	{
		TestSize(Bitness.X32bit);
		TestSize(Bitness.X64bit);

		void TestSize(Bitness b) =>
			Assert.That(Marshaler.SizeOf(objType, new(b)), Is.EqualTo(objType.GetExpectedSize(b)), b.ToString());
	}

	[TestCaseSource(nameof(GetStructList), new object?[] { 1, 34 })]
	public void ToPtrTest(Type objType)
	{
		Fixture fixture = new();
		fixture.Customize(new SupportMutableValueTypesCustomization());
		object? obj;
		var id = int.Parse(objType.Name.Substring(6));
		if (id is 7 or 8 or 9 or 23)
		{
			obj = id switch
			{
				7 => new Struct07
				{
					bVal = (byte)Random.Shared.Next(byte.MaxValue),
					iVal = Random.Shared.Next(int.MaxValue),
					lVal = Random.Shared.Next(int.MaxValue)
				},
				8 => new Struct08
				{
					usVal = (ushort)Random.Shared.Next(ushort.MaxValue),
					iVal = Random.Shared.Next(int.MaxValue),
					lVal = Random.Shared.Next(int.MaxValue)
				},
				9 => new Struct09
				{
					usVal = (ushort)Random.Shared.Next(ushort.MaxValue),
					iVal = Random.Shared.Next(int.MaxValue),
					lVal = Random.Shared.Next(int.MaxValue)
				},
				23 => new Struct23
				{
					bitField = true,
					bitField2 = 6,
					bitField3 = 2,
					bitFieldOverflow = 0x0DF7,
					bitFieldLong = 0x0EC9,
				},
				34 => new Struct34 { bVal = 1 },
				_ => null,
			};
		}
		else
			obj = new SpecimenContext(fixture).Resolve(new SeededRequest(objType, Activator.CreateInstance(objType)));
		using var result = Marshaler.ValueToPtr(obj);
		var obj2 = Marshaler.PtrToValue(objType, result?.DangerousGetHandle() ?? IntPtr.Zero);
		Assert.That(obj, NUnit.DeepObjectCompare.Is.DeepEqualTo(obj2), $"{objType.Name} structs are not equal");
	}

	private static IEnumerable<Type> GetStructList(int start, int end)
	{
		for (int i = start; i <= end; i++)
			yield return Assembly.GetExecutingAssembly().DefinedTypes.First(t => t.Name == $"Struct{i:D2}");
	}

	//[Test]
	//public void ToPtrTest()
	//{
	//	var obj = new Fixture().Create<Struct01>();
	//	using var result = Marshaler.StructureToPtr(value);
	//	var obj2 = Marshaler.PtrToStructure<Struct01>((IntPtr)result);
	//	Assert.That(obj, Is.EqualTo(obj2), "Structs are not equal");
	//}
	//static JsonSerializerOptions jsonOptions = new() { IncludeFields = true, };
	//public static void AreEqualByJson(object? expected, object? actual)
	//{
	//	var expectedJson = System.Text.Json.JsonSerializer.Serialize(expected, jsonOptions);
	//	var actualJson = System.Text.Json.JsonSerializer.Serialize(actual, jsonOptions);
	//	Assert.That(expectedJson, Is.EqualTo(actualJson));
	//}

	//private static bool CompareStructs(object? obj1, object? obj2)
	//{
	//	if (obj1 == null && obj2 == null) return true;
	//	if (obj1 == null || obj2 == null || obj1.GetType() != obj2.GetType()) return false;

	//	var fields = obj1.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
	//	return !fields.Any(f => f.GetValue(obj1) != f.GetValue(obj2) && (f.FieldType.IsValueType || f.FieldType.Equals(typeof(string)) || !CompareStructs(f.GetValue(obj1), f.GetValue(obj2))));
	//}
}

#region Structs
#pragma warning disable CS0649, CS0169

[Marshaled, Info(Bitness.Auto, 24)]
internal struct Struct01
{
	public int iVal;
	public long lVal;
	public byte bVal;
}

[Marshaled, Info(Bitness.Auto, 16)]
internal struct Struct02
{
	public int iVal;
	public ushort usVal;
	public long lVal;
}

[Marshaled, Info(Bitness.Auto, 16)]
internal struct Struct03
{
	public long lVal;
	public int iVal;
	public ushort usVal;
}

[Marshaled, Info(Bitness.Auto, 24)]
internal struct Struct04
{
	public long lVal;
	public int iVal;
	public ushort usVal;
	public byte bVal1;
	public byte bVal2;
	public byte bVal3;
}

[Marshaled, Info(Bitness.Auto, 8)]
internal struct Struct05
{
	public ushort usVal;
	public byte bVal1;
	public byte bVal2;
	public byte bVal3;
	public byte bVal4;
	public byte bVal5;
}

[Marshaled, Info(Bitness.Auto, 5)]
internal struct Struct06
{
	public byte bVal1;
	public byte bVal2;
	public byte bVal3;
	public byte bVal4;
	public byte bVal5;
}

[Marshaled, Info(Bitness.X32bit, 12)]
[Info(Bitness.X64bit, 24)]
internal struct Struct07
{
	public int iVal;
	public nint lVal;
	public byte bVal;
}

[Marshaled, Info(Bitness.X32bit, 12)]
[Info(Bitness.X64bit, 16)]
internal struct Struct08
{
	public int iVal;
	public ushort usVal;
	public nint lVal;
}

[Marshaled, Info(Bitness.X32bit, 12)]
[Info(Bitness.X64bit, 16)]
internal struct Struct09
{
	public nint lVal;
	public int iVal;
	public ushort usVal;
}

[Marshaled(Size = 80), Info(Bitness.Auto, 80)]
internal struct Struct10
{
	public int iVal;
	public long lVal;
	public byte bVal;
}

[Marshaled(Size = 20), Info(Bitness.Auto, 24)]
internal struct Struct11
{
	public int iVal;
	public long lVal;
	public byte bVal;
}

[Marshaled(Pack = 8), Info(Bitness.Auto, 8)]
internal struct Struct12
{
	public byte bVal1;
	public byte bVal2;
	public byte bVal3;
	public byte bVal4;
	public byte bVal5;
}

[Marshaled, Info(Bitness.Auto, 24)]
internal struct Struct13
{
	public long val1;
	public uint val2;
	public uint val3;
	public short val4;
	public short val5;
	public short val6;
	public short val7;
}

[Marshaled, Info(Bitness.Auto, 24)]
internal struct Struct14
{
	public long val1;
	public TimeSpan val3;
	public uint val2;
}

[Marshaled, Info(Bitness.Auto, 1)]
internal struct Struct15
{
	[MarshalAs(UnmanagedType.U1)]
	public bool val1;
}

[Marshaled, Info(Bitness.Auto, 4)]
internal struct Struct16
{
	public bool val1;
}

[Marshaled(StringEncoding = StringEncoding.Default), Info(Bitness.Auto, 1)]
internal struct Struct17
{
	public char val1;
}

[Marshaled(StringEncoding = StringEncoding.Unicode), Info(Bitness.Auto, 2)]
internal struct Struct18
{
	public char val1;
}

[Marshaled(StringEncoding = StringEncoding.Default), Info(Bitness.Auto, 2)]
internal struct Struct19
{
	public char val1;
	public byte val2;
}

[Marshaled(StringEncoding = StringEncoding.Unicode), Info(Bitness.Auto, 4)]
internal struct Struct20
{
	public char val1;
	public byte val2;
}

[Marshaled, Info(Bitness.X32bit, 8), Info(Bitness.X64bit, 16)]
internal struct Struct21
{
	[MarshalFieldAs.StructPtr]
	public Struct01? val1;

	public int val2;
}

[Marshaled, Info(Bitness.X32bit, 12), Info(Bitness.X64bit, 24)]
//[Marshaled, Info(Bitness.X32bit, 8), Info(Bitness.X64bit, 16)]
internal struct Struct22
{
	public Struct17 val1;
	public Struct21 val2;
}

[Marshaled, Info(Bitness.Auto, 24)]
internal struct Struct23
{
	[MarshalFieldAs.SizeOf]
	private uint size;

	[MarshalFieldAs.BitField<uint>]
	public bool bitField;

	[MarshalFieldAs.BitField<uint>(3)]
	public byte bitField2;

	[MarshalFieldAs.BitField<uint>(2, StartNewField = true)]
	public byte bitField3;

	[MarshalFieldAs.BitField<uint>(31)]
	public uint bitFieldOverflow;

	[MarshalFieldAs.BitField<ulong>(62)]
	public uint bitFieldLong;
}

[Marshaled(StringEncoding = StringEncoding.Unicode), Info(Bitness.X32bit, 24), Info(Bitness.X64bit, 48)]
internal struct Struct24
{
	[MarshalAs(UnmanagedType.LPStr)]
	public string? val1;

	[MarshalAs(UnmanagedType.LPTStr)]
	public string? val2;

	[MarshalAs(UnmanagedType.LPWStr)]
	public string? val3;

	[MarshalAs(UnmanagedType.LPUTF8Str)]
	public string? val4;

	[MarshalAs(UnmanagedType.BStr)]
	public string? val5;

	public string val6;
}

[Marshaled, Info(Bitness.Auto, 24)]
internal struct Struct25
{
	public decimal val1;
#pragma warning disable CS0618 // Type or member is obsolete
	[MarshalAs(UnmanagedType.Currency)]
#pragma warning restore CS0618 // Type or member is obsolete
	public decimal val2;
}

[Marshaled, Info(Bitness.X32bit, 16), Info(Bitness.X64bit, 32)]
internal struct Struct26
{
	private int cval1;

	[MarshalFieldAs.Array(ArrayLayout.LPArray, SizeFieldName = nameof(cval1))]
	public int[] val1;

	private uint cval2;

	[MarshalFieldAs.Array(ArrayLayout.LPArray, SizeFieldName = nameof(cval2))]
	public Struct21[]? val2;
}

[Marshaled, Info(Bitness.X32bit, 36), Info(Bitness.X64bit, 64)]
internal struct Struct27
{
	[MarshalFieldAs.Array(ArrayLayout.ByValArray, SizeConst = 3)]
	public int[] val1;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	public Struct21[] val2;
}

[Marshaled, Info(Bitness.X32bit, 16), Info(Bitness.X64bit, 32)]
internal struct Struct28
{
	[MarshalFieldAs.Array(ArrayLayout.StringPtrArrayNullTerm, StringEncoding = StringEncoding.Default)]
	public string[] val1;

	private uint cval2;

	[MarshalFieldAs.Array(ArrayLayout.StringPtrArray, SizeFieldName = nameof(cval2))]
	public string?[] val2;

	[MarshalFieldAs.Array(ArrayLayout.ConcatenatedStringArray, StringEncoding = StringEncoding.UTF8)]
	public string[] val3;
}

[Marshaled, Info(Bitness.Auto, 320)]
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
internal struct Struct29
{
	[MarshalFieldAs.FixedString(64, false, StringEncoding.Unicode)]
	public string val1;

	[MarshalFieldAs.FixedString(128, true, StringEncoding.UTF8)]
	public string val2;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string val3;
}

[Marshaled, Info(Bitness.Auto, 24)]
internal struct Struct30
{
	[MarshalFieldAs.SizeOf]
	public uint size;

	private uint arrayCount;

	[MarshalFieldAs.Array(ArrayLayout.ByValAnySizeArray, SizeFieldName = nameof(arrayCount))]
	public Guid[] array;
}

[Marshaled, Info(Bitness.Auto, 4)]
internal struct Struct31
{
	private ushort fnlen;

	[MarshalFieldAs.AppendedString(nameof(fnlen))]
	public string fn;
}

[Marshaled, Info(Bitness.Auto, 2)]
internal struct Struct32
{
	private ushort fnlen;

	[MarshalFieldAs.AppendedString(nameof(fnlen), 0)]
	public string fn;
}

[Marshaled, Info(Bitness.Auto, 4)]
internal struct Struct33
{
	private uint arrayCount;

	[MarshalFieldAs.Array(ArrayLayout.ByValAppendedArray, SizeFieldName = nameof(arrayCount))]
	public Guid[] array;
}

#endregion Structs

[StructLayout(LayoutKind.Explicit), Info(Bitness.Auto, 8)]
internal struct Struct34
{
	[FieldOffset(0)]
	public int iVal;
	[FieldOffset(0)]
	public long lVal;
	[FieldOffset(0)]
	public byte bVal;
}

/*[Marshaled, Info(Bitness.Auto, 48)]
internal struct Struct35
{
	public int iVal;

	[MarshalFieldAs.UnionField]
	[MarshalAs(UnmanagedType.LPWStr)]
	public string? union1Value1;

	[MarshalFieldAs.UnionField]
	public IntPtr union1Value2;

	[MarshalFieldAs.UnionField]
	[MarshalFieldAs.StructPtr]
	public Struct01? union1Value3;

	public Struct34 unionSet;

	public uint uVal;
}*/

internal static class TExt
{
	public static int GetExpectedSize(this Type type, Bitness bitness) =>
		type.GetCustomAttributes<InfoAttribute>().FirstOrDefault(a => a.Bitness == bitness || a.Bitness == Bitness.Auto)?.Size ?? 0;
}

[AttributeUsage(AttributeTargets.Struct, Inherited = false, AllowMultiple = true)]
internal sealed class InfoAttribute(Bitness bitness, int size) : Attribute
{
	public Bitness Bitness { get; } = bitness;
	public int Size { get; } = size;
}