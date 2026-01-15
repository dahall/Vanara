using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using Vanara.Extensions;
using Vanara.Extensions.Reflection;
using Vanara.InteropServices;
using Vanara.PInvoke;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Vanara.Marshaler;

public static partial class Marshaler
{
	internal interface IProvideFieldInfo
	{
		FieldInfo FieldInfo { get; }
	}

	internal interface IProvideFieldList
	{
		IReadOnlyList<TypeMarshaler> Fields { get; }
	}

	internal interface IPreprocessMarshaler
	{
		int PreprocessWrite(MarshaledTypeInfo mti, object obj);
	}

	internal abstract class TypeMarshaler(MarshalerOptions options, int size = 0)
	{
		public int Offset;
		public abstract int Alignment { get; protected set; }
		public virtual Encoding Encoding => Options.Encoding;
		public virtual int MaxFieldSize => Size;
		public MarshalerOptions Options { get; } = options;
		public virtual int Size { get; protected set; } = size;

		public abstract void Read(IntPtr p, int offset, MarshaledTypeInfo mti, object? obj);
		public abstract void Write<TMem>(object? value, nint ptr, int offset, ISafeMemoryHandle p) where TMem : ISafeMemoryHandleFactory;

		protected Type RealType(Type t)
		{
			if (t.IsNativeSized())
				return (int)Options.Bitness switch { 8 => typeof(sbyte), 16 => typeof(short), 32 => typeof(int), _ => typeof(long) };
			else if (t == typeof(char))
				return StringHelper.GetCharSize(Encoding) switch { 1 => typeof(byte), 2 => typeof(ushort), _ => typeof(uint) };
			else if (t.IsEnum)
				return Enum.GetUnderlyingType(t);
			else
				return t;
		}
	}

	internal abstract class DirectData : TypeMarshaler
	{
		private Type nativeType;

		public DirectData(Type nativeType, MarshalerOptions options) : base(options) => NativeType = RealType(nativeType);

		[MemberNotNull(nameof(nativeType))]
		public virtual Type NativeType
		{
			get => nativeType ?? throw new InvalidOperationException("NativeType must not be null.");
			protected set
			{
				nativeType = value ?? throw new ArgumentNullException(nameof(NativeType));
				Size = SizeOf(nativeType, Options);
				Alignment = nativeType.IsMarshaledType() ? MarshaledTypeInfo.Get(nativeType, Options).Alignment : nativeType.GetAlignment();
			}
		}
		public override int Alignment { get; protected set; }
		public override int MaxFieldSize => NativeType.HasMembers() ? Alignment : Size;
	}

	internal abstract class IndirectMarshaler(FieldInfo fieldInfo, MarshalerOptions options) : TypeMarshaler(options, (int)options.Bitness / 8), IProvideFieldInfo
	{
		public override int Alignment { get; protected set; } = (int)options.Bitness / 8;
		public FieldInfo FieldInfo { get; } = fieldInfo;

		protected IntPtr ReadPtr(IntPtr ptr, int offset)
		{
			var realPtrType = RealType(typeof(IntPtr));
			var ptrVal = ptr.ToStructure(realPtrType, offset: offset);
			return (IntPtr)(Extensions.ChangeType(ptrVal, typeof(IntPtr)) ?? IntPtr.Zero);
		}

		protected void WritePtr(IHandle alloc, IntPtr ptr, int offset, ISafeMemoryHandle p)
		{
			if (alloc is IDisposable h)
				p.AddSubReference(h);
			else
				throw new InvalidOperationException("Memory handle must be a IDisposable.");
			ptr.Write(alloc.DangerousGetHandle().AdjustBitness(Options.Bitness), offset);
		}
	}

	internal class ArrayMarshaler(FieldInfo fieldInfo, MarshalFieldAs.ArrayAttribute arrAttr, MarshalerOptions options) :
		IndirectMarshaler(fieldInfo, options), IPreprocessMarshaler
	{
		private readonly int size = arrAttr.SizeConst > 0 ? arrAttr.SizeConst : 0;
		private readonly FieldInfo? sizeField = arrAttr.SizeFieldName != null ? fieldInfo.DeclaringType?.GetField(arrAttr.SizeFieldName, Extensions.allInstFields) : null;
		public override Encoding Encoding { get; } = arrAttr.Encoding;

		public int PreprocessWrite(MarshaledTypeInfo mti, object obj)
		{
			if (obj is null) return 0;
			var arr = FieldInfo.GetValue(obj) as Array;
			if (arr is not null && arr!.Rank != 1)
				throw new MarshalException($"Field {FieldInfo.DeclaringType!.FullName}.{FieldInfo.Name} must be a one-dimensional array.");
			if (sizeField is not null)
			{
				var writeVal = Convert.ChangeType(arr?.Length ?? 0, sizeField.FieldType);
				sizeField.SetValue(obj, writeVal);
			}
			else if ((arr?.Length ?? 0) < size)
				throw new MarshalException($"Field {FieldInfo.DeclaringType!.FullName}.{FieldInfo.Name} must be at least {size} elements long.");
			return 0;
		}
		public override void Read(IntPtr ptr, int offset, MarshaledTypeInfo mti, object? obj)
		{
			if (obj is null || ptr == default) return;
			int sz = size;
			if (sizeField is not null)
			{
				var szfi = mti.Fields.OfType<DirectMarshaler>().Where(f => f.FieldInfo.Name == sizeField.Name).FirstOrDefault() ?? throw new MarshalException($"Field {sizeField.DeclaringType!.FullName}.{sizeField.Name} must exist.");
				var szVal = szfi.ReadValueFromPtr(ptr, szfi.Offset) ?? throw new MarshalException($"Field {sizeField.DeclaringType!.FullName}.{sizeField.Name} must provide an integral value.");
				sz = (int)Convert.ChangeType(szVal, typeof(int));
			}
			var aptr = ReadPtr(ptr, offset);
			var arr = arrAttr.Layout switch
			{
				ArrayLayout.LPArray => FixedArrayMarshaler.ReadArray(aptr, 0, FieldInfo.FieldType.GetElementType()!, sz, Options),
				ArrayLayout.LPArrayNullTerm => ReadArrayUntilDefault(aptr, 0, FieldInfo.FieldType.GetElementType()!, Options),
				//case ArrayLayout.SafeArray:
				//	len = aptr.GetNulledPtrArrayLength();
				//	break;
				_ => throw new MarshalException($"Invalid array layout {arrAttr.Layout}."),
			};
			FieldInfo.SetValue(obj, arr);
		}
		public override void Write<TMem>(object? value, nint ptr, int offset, ISafeMemoryHandle p)
		{
			if (value is null || ptr == default) return;
			var items = (Array?)FieldInfo.GetValue(value);
			if (items is null)
				return;
			ISafeMemoryHandle aptr;
			int sz;
			var elemType = FieldInfo.FieldType.GetElementType()!;
			switch (arrAttr.Layout)
			{
				case ArrayLayout.LPArray:
					aptr = Extensions.CreateSafeMemory<TMem>(sz = SizeOf(elemType, Options) * items.Length);
					FixedArrayMarshaler.WriteArray<TMem>(items, elemType, aptr.DangerousGetHandle(), 0, p, Options);
					break;
				case ArrayLayout.LPArrayNullTerm:
					aptr = Extensions.CreateSafeMemory<TMem>(sz = SizeOf(elemType, Options) * (items.Length + 1));
					FixedArrayMarshaler.WriteArray<TMem>(items, elemType, aptr.DangerousGetHandle(), 0, p, Options);
					break;
				//case ArrayLayout.SafeArray:
				//	// TODO: Add support for SAFEARRAY allocation
				//	var s = new SafeArrayMarshal(items);
				//	break;
				default:
					throw new MarshalException($"Invalid array layout {arrAttr.Layout}.");
			}
			WritePtr(aptr, ptr, offset, p);
		}

		/// <summary>
		/// Reads an array of elements from a pointer, stopping when the default value of the element type is encountered.
		/// </summary>
		internal static Array? ReadArrayUntilDefault(nint ptr, int offset, Type elemType, MarshalerOptions options)
		{
			if (ptr == default) return null;
			var size = SizeOf(elemType, options);
			var list = new List<object?>();
			int i = 0;
			object? defVal = elemType.IsValueType ? Activator.CreateInstance(elemType) : null;
			while (true)
			{
				var elemPtr = ptr.Offset(offset + i * size);
				object? elem;
				if (elemType.IsMarshaledType())
					elem = MarshaledTypeInfo.ReadInstanceFromMemory(elemType, elemPtr, options);
				else
					elem = elemPtr.ToStructure(elemType);

				if ((elem == null && defVal == null) || (elem != null && elem.Equals(defVal)))
					break;

				list.Add(elem);
				i++;
			}
			var arr = Array.CreateInstance(elemType, list.Count);
			for (int j = 0; j < list.Count; j++)
				arr.SetValue(list[j], j);
			return arr;
		}
	}

/*	internal static SIZE_T SizeOf(System.Collections.IEnumerable items, MarshalerOptions options, out Type elemType, out int count)
	{
		int c = 0;
		Type? elem = null;
		foreach (object? item in items)
		{
			c++;
			if (item is null)
				continue;

			if (elem is null)
				elem = item.GetType();
			else if (item.GetType() != elem)
				throw new MarshalException($"All items in the collection must be of the same type. Expected {elem}, got {item.GetType()}.");
		}
	}

	public static SIZE_T Write(this IntPtr ptr, System.Collections.IEnumerable items, SIZE_T offset = default, SIZE_T allocatedBytes = default, MarshalerOptions? options = null)
	{
		options ??= new();
		int c = 0;
		Type? elemType = null;
		foreach (object? item in items)
		{
			c++;
			if (item is null)
				continue;

			if (elemType is null)
				elemType = item.GetType();
			else if (item.GetType() != elemType)
				throw new MarshalException($"All items in the collection must be of the same type. Expected {elemType}, got {item.GetType()}.");
		}

		if (c == 0)
			return 0;


			if (item is string str)
			{
				ptr.Write(str, offset, options);
				offset += str.GetByteCount(options);
				continue;
			}
			if (item is Array str)
			{
				ptr.Write(str, offset, options);
				offset += str.GetByteCount(options);
				continue;
			}
			if (item is IEnumerable<object> objList)
			{
				ptr.Write(objList, offset, allocatedBytes, options);
				offset += objList.GetByteCount(options);
				continue;
			}
		}
		var count = items?.Count() ?? 0;
		if (count == 0) return 0;

		Type ttype = TrueType(typeof(T), out var stSize);
		if (!ttype.IsMarshalable())
			throw new ArgumentException(@"Structure layout is not sequential or explicit.");

		var bytesReq = stSize * count + offset;
		if (allocatedBytes > 0 && bytesReq > allocatedBytes)
			throw new InsufficientMemoryException();

		var i = 0;
		foreach (object? item in items!.Select(v => Convert.ChangeType(v, ttype)).Where(v => v != null))
			WriteNoChecks(ptr, item, offset + i++ * stSize, allocatedBytes);

		return bytesReq - offset;
	}
*/

	internal class StringArrayMarshaler(FieldInfo fieldInfo, MarshalFieldAs.ArrayAttribute arrAttr, MarshalerOptions options) :
		IndirectMarshaler(fieldInfo, options), IPreprocessMarshaler
	{
		private readonly int size = arrAttr.SizeConst > 0 ? arrAttr.SizeConst : 0;
		private readonly FieldInfo? sizeField = arrAttr.SizeFieldName != null ? fieldInfo.DeclaringType?.GetField(arrAttr.SizeFieldName, Extensions.allInstFields) : null;
		public override Encoding Encoding { get; } = arrAttr.Encoding;

		public int PreprocessWrite(MarshaledTypeInfo mti, object obj)
		{
			if (obj is null || arrAttr.Layout is ArrayLayout.StringPtrArrayNullTerm or ArrayLayout.ConcatenatedStringArray) return 0;

			var arr = FieldInfo.GetValue(obj) as string[];
			if (sizeField is not null)
			{
				//ulong sizeVal = (ulong)Convert.ChangeType(sizeField.GetValue(value) ?? 0, typeof(ulong));
				var writeVal = Convert.ChangeType(arr?.Length ?? 0, sizeField.FieldType);
				sizeField.SetValue(obj, writeVal);
			}
			else if ((arr?.Length ?? 0) < size)
				throw new MarshalException($"Field {FieldInfo.DeclaringType!.FullName}.{FieldInfo.Name} must be at least {size} elements long.");

			return 0;
		}
		public override void Read(IntPtr ptr, int offset, MarshaledTypeInfo mti, object? obj)
		{
			if (obj is null || ptr == default) return;
			string?[]? arr = null;
			var saptr = ReadPtr(ptr, offset);
			switch (arrAttr.Layout)
			{
				case ArrayLayout.StringPtrArray:
					int sz = size;
					if (sizeField is not null)
					{
						var szfi = mti.Fields.OfType<DirectMarshaler>().Where(f => f.FieldInfo.Name == sizeField.Name).FirstOrDefault() ?? throw new MarshalException($"Field {sizeField.DeclaringType!.FullName}.{sizeField.Name} must exist.");
						var szVal = szfi.ReadValueFromPtr(ptr, szfi.Offset) ?? throw new MarshalException($"Field {sizeField.DeclaringType!.FullName}.{sizeField.Name} must provide an integral value.");
						sz = (int)Convert.ChangeType(szVal, typeof(int));
					}
					arr = [.. saptr.ToStringEnum(sz, Encoding, 0)];
					break;
				case ArrayLayout.StringPtrArrayNullTerm:
					sz = saptr.GetNulledArrayLength(RealType(typeof(IntPtr)));
					arr = [.. saptr.ToStringEnum(sz, Encoding, 0)];
					break;
				case ArrayLayout.ConcatenatedStringArray:
					arr = [.. saptr.ToStringEnum(Encoding)];
					break;
				default:
					throw new MarshalException("Invalid string array layout.");
			}
			FieldInfo.SetValue(obj, arr);
		}
		public override void Write<TMem>(object? value, nint ptr, int offset, ISafeMemoryHandle p)
		{
			if (value is null || ptr == default) return;
			var sa = (string[])FieldInfo.GetValue(value)!;
			if (arrAttr.Layout is ArrayLayout.StringPtrArrayNullTerm or ArrayLayout.ConcatenatedStringArray && sa.Any(s => s is null))
				throw new MarshalException($"Field {FieldInfo.DeclaringType!.FullName}.{FieldInfo.Name} must not contain null strings.");

			int ptrsz = Marshal.SizeOf(RealType(typeof(IntPtr)));
			var stringsAsBytes = sa.Select(s => StringHelper.GetBytes(s, Encoding, true)).ToArray();
			int strszsum = stringsAsBytes.Sum(b => b.Length);
			int soffset = arrAttr.Layout switch
			{
				ArrayLayout.StringPtrArray => sa.Length * ptrsz,
				ArrayLayout.StringPtrArrayNullTerm => (sa.Length + 1) * ptrsz,
				ArrayLayout.ConcatenatedStringArray => 0,
				_ => throw new MarshalException("Invalid string array layout.")
			};
			int totsz = arrAttr.Layout switch
			{
				ArrayLayout.StringPtrArray or ArrayLayout.StringPtrArrayNullTerm => soffset + strszsum,
				ArrayLayout.ConcatenatedStringArray => strszsum + StringHelper.GetCharSize(Encoding),
				_ => throw new MarshalException("Invalid string array layout.")
			};

			var aptr = Extensions.CreateSafeMemory<TMem>(totsz);
			var sptrs = new IntPtr[sa.Length + (arrAttr.Layout == ArrayLayout.StringPtrArrayNullTerm ? 1 : 0)];
			for (int i = 0, soff = soffset; i < stringsAsBytes.Length; i++)
			{
				sptrs[i] = aptr.DangerousGetHandle().Offset(soff);
				soff += aptr.DangerousGetHandle().Write(stringsAsBytes[i], soff, totsz);
			}

			if (arrAttr.Layout is ArrayLayout.StringPtrArray or ArrayLayout.StringPtrArrayNullTerm)
				for (int i = 0; i < sptrs.Length; i++)
					aptr.DangerousGetHandle().Write(sptrs[i].AdjustBitness(Options.Bitness), i * ptrsz, totsz);

			WritePtr(aptr, ptr, offset, p);
		}
	}

	internal class BitMarshaler(Type nativeType, List<TypeMarshaler> fields, MarshalerOptions options) : DirectData(nativeType, options), IProvideFieldList
	{
		public IReadOnlyList<TypeMarshaler> Fields { get; } = fields;
		public override void Read(nint p, int offset, MarshaledTypeInfo mti, object? obj)
		{
			if (obj is null || p == default) return;
			var val = (ulong)Convert.ChangeType(p.ToStructure(NativeType, offset: offset)!, typeof(ulong));
			byte shift = 0, bits = 0;
			foreach (var field in Fields.Cast<DirectMarshaler>())
			{
				bits = (byte)GetBitWidth(field.FieldInfo);
				shift = (byte)field.Offset;
				var ul = BitHelper.GetBits(val, shift, bits);
				var readVal = Convert.ChangeType(ul, field.FieldInfo.FieldType);
				field.FieldInfo.SetValue(obj, readVal);
			}
		}
		public override void Write<TMem>(object? value, nint ptr, int offset, ISafeMemoryHandle p)
		{
			if (value is null) return;
			ulong ret = 0;
			foreach (var field in Fields.Cast<DirectMarshaler>())
			{
				var ul = (ulong)Convert.ChangeType(field.FieldInfo.GetValue(value)!, typeof(ulong));
				var bits = GetBitWidth(field.FieldInfo);
				var maskedVal = ul.Mask(bits);
				if (ul != maskedVal) throw new MarshalException($"Value supplied for {field.FieldInfo.DeclaringType!.FullName}.{field.FieldInfo.Name} ({ul}) exceeds the maximum value allowed within {bits} bits.");
				ret |= maskedVal << field.Offset;
			}
			ptr.Write(Convert.ChangeType(ret, NativeType), offset);
		}

		private static int GetBitWidth(FieldInfo fi)
		{
			var bitAttr = fi.GetCustomAttributes(typeof(MarshalFieldAs.BitFieldAttribute<>)).FirstOrDefault();
			return bitAttr is null ? 0 : bitAttr.GetPropertyValue("BitCount", 1);
		}
	}

	internal class CurrencyMarshaler(FieldInfo fieldInfo, MarshalerOptions options) : DirectMarshaler(fieldInfo, typeof(long), options)
	{
		public override void Read(nint ptr, int offset, MarshaledTypeInfo mti, object? obj)
		{
			if (obj is null) return;
			long readVal = (long)ptr.ToStructure(NativeType, offset: offset)!;
			FieldInfo.SetValue(obj, decimal.FromOACurrency(readVal));
		}

		public override void Write<TMem>(object? value, nint ptr, int offset, ISafeMemoryHandle p)
		{
			if (value is null) return;
			Debug.Assert(FieldInfo.FieldType == typeof(decimal) && NativeType == typeof(long));
			decimal dec = (decimal)FieldInfo.GetValue(value)!;
			ptr.Write(decimal.ToOACurrency(dec), offset);
		}
	}

	// TODO: Complete
	internal class CustomMarshalerMarshaler(FieldInfo fieldInfo, Type customMarshaler, MarshalerOptions options) : IndirectMarshaler(fieldInfo, options)
	{
		public Type CustomMarshaler { get; } = customMarshaler;

		public override void Read(nint ptr, int offset, MarshaledTypeInfo mti, object? obj) => throw new NotImplementedException();
		public override void Write<TMem>(object? value, nint ptr, int offset, ISafeMemoryHandle p) => throw new NotImplementedException();
	}

	internal class DirectMarshaler(FieldInfo fieldInfo, Type? nativeType, MarshalerOptions options) : DirectData(nativeType ?? fieldInfo.FieldType, options), IProvideFieldInfo
	{
		public FieldInfo FieldInfo { get; } = fieldInfo;

		public override void Read(nint ptr, int offset, MarshaledTypeInfo mti, object? obj)
		{
			if (obj is null) return;
			object? readVal = ReadValueFromPtr(ptr, offset);
			FieldInfo.SetValue(obj, readVal);
		}

		internal object? ReadValueFromPtr(nint ptr, int offset)
		{
			var readVal = ptr.Offset(offset).Convert(uint.MaxValue, NativeType, Encoding);
			if (NativeType != FieldInfo.FieldType)
				readVal = Extensions.ChangeType(readVal, FieldInfo.FieldType);
			return readVal;
		}

		public override void Write<TMem>(object? value, nint ptr, int offset, ISafeMemoryHandle p)
		{
			if (value is null) return;
			object? writeVal = FieldInfo.GetValue(value);
			if (FieldInfo.FieldType != NativeType)
				writeVal = Extensions.ChangeType(writeVal, NativeType);
			ptr.Write(writeVal, offset);
		}
	}

	internal class FixedArrayMarshaler : DirectMarshaler, IPreprocessMarshaler
	{
		private readonly ArrayLayout layout;
		private readonly FieldInfo? sizeField;
		private readonly int elemSize;
		public int Length { get; }

		public FixedArrayMarshaler(FieldInfo fieldInfo, MarshalFieldAs.ArrayAttribute arrAttr, MarshalerOptions options) : base(fieldInfo, fieldInfo.FieldType.GetElementType()!, options)
		{
			layout = arrAttr.Layout;
			elemSize = base.Size;
			sizeField = arrAttr.SizeFieldName != null ? fieldInfo.DeclaringType?.GetField(arrAttr.SizeFieldName, Extensions.allInstFields) : null;
			Length = arrAttr.Layout switch { ArrayLayout.ByValArray => arrAttr.SizeConst, ArrayLayout.ByValAnySizeArray => 1, _ => 0 };
			Size = Length * elemSize;
		}
		public FixedArrayMarshaler(FieldInfo fieldInfo, int sizeConst, MarshalerOptions options) :
			this(fieldInfo, new MarshalFieldAs.ArrayAttribute(ArrayLayout.ByValArray) { SizeConst = sizeConst }, options) { }
		public int PreprocessWrite(MarshaledTypeInfo mti, object obj)
		{
			if (obj is null) return 0;
			var arr = FieldInfo.GetValue(obj) as Array;
			if (arr is not null && arr!.Rank != 1)
				throw new MarshalException($"Field {FieldInfo.DeclaringType!.FullName}.{FieldInfo.Name} must be a one-dimensional array.");
			if (sizeField is not null)
			{
				var writeVal = Convert.ChangeType(arr?.Length ?? 0, sizeField.FieldType);
				sizeField.SetValue(obj, writeVal);
				if (arr is not null && layout is ArrayLayout.ByValAnySizeArray or ArrayLayout.ByValAppendedArray)
					return (arr.Length - (layout == ArrayLayout.ByValAnySizeArray ? 1 : 0)) * elemSize;
			}
			else if (layout is ArrayLayout.ByValAnySizeArray or ArrayLayout.ByValAppendedArray)
				throw new MarshalException($"Field {FieldInfo.DeclaringType!.FullName}.{FieldInfo.Name} must have an associated size field.");
			else if ((arr?.Length ?? 0) < Length)
				throw new MarshalException($"Field {FieldInfo.DeclaringType!.FullName}.{FieldInfo.Name} must be at least {Length} elements long.");
			return 0;
		}
		public override void Read(nint ptr, int offset, MarshaledTypeInfo mti, object? obj)
		{
			if (obj is null || ptr == default) return;
			int len = Length;
			if (sizeField is not null)
			{
				var szfi = mti.Fields.OfType<DirectMarshaler>().Where(f => f.FieldInfo.Name == sizeField.Name).FirstOrDefault() ?? throw new MarshalException($"Field {sizeField.DeclaringType!.FullName}.{sizeField.Name} must exist.");
				var szVal = szfi.ReadValueFromPtr(ptr, szfi.Offset) ?? throw new MarshalException($"Field {sizeField.DeclaringType!.FullName}.{sizeField.Name} must provide an integral value.");
				len = (int)Convert.ChangeType(szVal, typeof(int));
			}
			FieldInfo.SetValue(obj, ReadArray(ptr, offset, NativeType, len, Options));
		}
		public override void Write<TMem>(object? value, nint ptr, int offset, ISafeMemoryHandle p)
		{
			if (value is null || ptr == default) return;
			Array writeVal = (Array?)FieldInfo.GetValue(value) ?? Array.CreateInstance(NativeType, Length);
			if (writeVal.Rank != 1 || (writeVal.Length != Length && layout == ArrayLayout.ByValArray))
				throw new MarshalException($"Field {FieldInfo.DeclaringType!.FullName}.{FieldInfo.Name} must be a one-dimensional array of length {Length}.");
			WriteArray<TMem>(writeVal, NativeType, ptr, offset, p, Options);
		}

		internal static Array? ReadArray(nint ptr, int offset, Type elemType, int length, MarshalerOptions options)
		{
			if (!elemType.IsMarshaledType())
				return ptr.ToArray(elemType, length, offset);

			var size = SizeOf(elemType, options);
			Array readVal = Array.CreateInstance(elemType, length);
			for (int i = 0; i < length; i++)
			{
				var elem = MarshaledTypeInfo.ReadInstanceFromMemory(elemType, ptr.Offset(offset + i * size), options);
				readVal.SetValue(elem, i);
			}
			return readVal;
		}

		internal static void WriteArray<TMem>(Array? writeVal, Type elemType, IntPtr ptr, int offset, ISafeMemoryHandle p, MarshalerOptions options) where TMem : ISafeMemoryHandleFactory
		{
			if (writeVal is null) return;
			var length = writeVal.Length;
			var size = SizeOf(elemType, options);
			for (int b = writeVal.GetLowerBound(0), i = 0; b < length; b++, i++)
			{
				var item = writeVal.GetValue(b);
				if (item is null) continue;
				if (elemType.IsMarshaledType())
				{
					var mem = MarshaledTypeInfo.WriteInstanceToMemory<TMem>(item, options);
					mem.DangerousGetHandle().CopyTo(ptr.Offset(offset + i * size), mem.Size);
					p.AddSubReference(mem);
				}
				else
					ptr.Write(item, offset + i * size);
			}
		}
	}

	internal class AppendedStringMarshaler : DirectMarshaler, IPreprocessMarshaler
	{
		private readonly FieldInfo? sizeField;

		public AppendedStringMarshaler(FieldInfo fieldInfo, MarshalFieldAs.AppendedStringAttribute arrAttr, MarshalerOptions options) : base(fieldInfo, typeof(byte), options)
		{
			Encoding = arrAttr.Encoding;
			NativeType = RealType(typeof(char));
			Size = Encoding.GetCharSize() * arrAttr.EmbeddedCharacters;
			sizeField = arrAttr.StringLenFieldName != null ? fieldInfo.DeclaringType?.GetField(arrAttr.StringLenFieldName, Extensions.allInstFields) : null;
		}

		public override Encoding Encoding { get; }

		public int PreprocessWrite(MarshaledTypeInfo mti, object obj)
		{
			if (obj is null) return 0;
			var str = FieldInfo.GetValue(obj) as string;
			if (sizeField is not null)
			{
				var writeVal = Convert.ChangeType(str?.Length ?? 0, sizeField.FieldType);
				sizeField.SetValue(obj, writeVal);
			}
			return str is null ? 0 : str.GetByteCount(Encoding, true) - Size;
		}
		public override void Read(nint ptr, int offset, MarshaledTypeInfo mti, object? obj)
		{
			if (obj is null) return;
			int len = int.MaxValue;
			if (sizeField is not null)
			{
				var szfi = mti.Fields.OfType<DirectMarshaler>().Where(f => f.FieldInfo.Name == sizeField.Name).FirstOrDefault() ?? throw new MarshalException($"Field {sizeField.DeclaringType!.FullName}.{sizeField.Name} must exist.");
				var szVal = szfi.ReadValueFromPtr(ptr, szfi.Offset) ?? throw new MarshalException($"Field {sizeField.DeclaringType!.FullName}.{sizeField.Name} must provide an integral value.");
				len = (int)Convert.ChangeType(szVal, typeof(int));
			}
			FieldInfo.SetValue(obj, StringHelper.GetString(ptr.Offset(offset), Encoding, out _, len * Encoding.GetCharSize()));
		}
		public override void Write<TMem>(object? value, nint ptr, int offset, ISafeMemoryHandle p)
		{
			if (value is null) return;
			var s = FieldInfo.GetValue(value) as string;
			ptr.Offset(offset).FillMemory(0, Size);
			if (s is not null)
				StringHelper.Write(s, ptr.Offset(offset), Encoding, true);
		}
	}

	internal class FixedStringMarshaler : DirectMarshaler
	{
		private readonly int maxLen;
		private readonly bool nullTerm;

		public FixedStringMarshaler(FieldInfo fieldInfo, int stringLength, bool nullTerm, StringEncoding encoding, MarshalerOptions options) : base(fieldInfo, typeof(byte), options)
		{
			StringLength = stringLength;
			maxLen = nullTerm ? StringLength - 1 : StringLength;
			this.nullTerm = nullTerm;
			Encoding = encoding.ToEncoding();
			NativeType = RealType(typeof(char));
			Size = Encoding.GetCharSize() * StringLength;
		}

		public override Encoding Encoding { get; }
		public override int MaxFieldSize => Alignment;
		public int StringLength { get; }

		public override void Read(nint ptr, int offset, MarshaledTypeInfo mti, object? obj)
		{
			if (obj is null) return;
			FieldInfo.SetValue(obj, StringHelper.GetString(ptr.Offset(offset), Encoding, out _, Size));
		}
		public override void Write<TMem>(object? value, nint ptr, int offset, ISafeMemoryHandle p)
		{
			if (value is null) return;
			var s = FieldInfo.GetValue(value) as string;
			ptr.Offset(offset).FillMemory(0, Size);
			if (s is not null)
				StringHelper.Write(s.Substring(0, Math.Min(s.Length, maxLen)), ptr.Offset(offset), Encoding, nullTerm, Size);
		}
	}

	internal class FuncPtrMarshaler(FieldInfo fieldInfo, MarshalerOptions options) : DirectMarshaler(fieldInfo, typeof(IntPtr), options)
	{
		public override void Read(nint ptr, int offset, MarshaledTypeInfo mti, object? obj)
		{
			if (obj is null) return;
			var readVal = (IntPtr)ptr.ToStructure(NativeType, offset: offset)!;
			FieldInfo.SetValue(obj, Marshal.GetDelegateForFunctionPointer(readVal, FieldInfo.FieldType));
		}

		public override void Write<TMem>(object? value, nint ptr, int offset, ISafeMemoryHandle p)
		{
			if (value is null) return;
			Debug.Assert(typeof(Delegate).IsAssignableFrom(FieldInfo.FieldType) && NativeType == typeof(IntPtr));
			ptr.Write(FieldInfo.GetValue(value) is not Delegate readVal ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(readVal), offset);
		}
	}

	internal class InterfaceMarshaler(FieldInfo fieldInfo, MarshalerOptions options) : DirectMarshaler(fieldInfo, typeof(IntPtr), options) { }

	internal class SizeOfMarshaler(FieldInfo fieldInfo, MarshalerOptions options) : DirectMarshaler(fieldInfo, fieldInfo.FieldType, options), IPreprocessMarshaler
	{
		public int PreprocessWrite(MarshaledTypeInfo mti, object obj)
		{
			if (obj is null) return 0;
			ulong ul = (ulong)Convert.ChangeType(FieldInfo.GetValue(obj), typeof(ulong))!;
			if (ul == 0)
				FieldInfo.SetValue(obj, Convert.ChangeType(mti.NativeSize, FieldInfo.FieldType));
			return 0;
		}
	}

	/// <summary>
	/// Marshaler for string types. This marshaler is used for all string types read from a pointer, including BSTR, LPSTR, LPWSTR, and LPUTF8Str.
	/// </summary>
	internal class StringMarshaler(FieldInfo fieldInfo, MarshalerOptions options) : IndirectMarshaler(fieldInfo, options)
	{
		public override void Read(nint ptr, int offset, MarshaledTypeInfo mti, object? obj)
		{
			if (obj is null) return;
			var sptr = ReadPtr(ptr, offset);
			string? readVal = GetKind(FieldInfo) switch
			{
				UnmanagedType.LPTStr => Read(sptr, Encoding),
				UnmanagedType.LPWStr => Read(sptr, Encoding.Unicode),
				UnmanagedType.LPStr => Read(sptr, Encoding.Default),
#if !NETSTANDARD2_0
				UnmanagedType.LPUTF8Str => Read(sptr, Encoding.UTF8),
#endif
				UnmanagedType.BStr => Marshal.PtrToStringBSTR(sptr),
				_ => throw new MarshalException($"Invalid string type {FieldInfo.FieldType.Name} for field {FieldInfo.Name}.")
			};
			FieldInfo.SetValue(obj, readVal);
		}

		public override void Write<TMem>(object? value, nint ptr, int offset, ISafeMemoryHandle p)
		{
			if (value is null) return;
			Debug.Assert(FieldInfo.FieldType == typeof(string));
			var str = (string?)FieldInfo.GetValue(value);
			int strSize = 0;
			var sptr = GetKind(FieldInfo) switch
			{
				UnmanagedType.LPTStr => Make<TMem>(str, Encoding, out strSize),
				UnmanagedType.LPWStr => Make<TMem>(str, Encoding.Unicode, out strSize),
				UnmanagedType.LPStr => Make<TMem>(str, Encoding.ASCII, out strSize),
				UnmanagedType.BStr => MakeBSTR<TMem>(str, out strSize),
#if !NETSTANDARD2_0
				UnmanagedType.LPUTF8Str => Make<TMem>(str, Encoding.UTF8, out strSize),
#endif
				_ => throw new MarshalException($"Invalid string type {FieldInfo.FieldType.Name} for field {FieldInfo.Name}.")
			};
			WritePtr(sptr, ptr, offset, p);
		}

		private static GenericSafeHandle MakeBSTR<TMem>(string? str, out int strSize) where TMem : ISafeMemoryHandleFactory
		{
			strSize = -47;
			return new GenericSafeHandle(str is null ? IntPtr.Zero : Marshal.StringToBSTR(str), p => { Marshal.FreeBSTR(p); return true; }, str is not null);
		}

		private static IHandle Make<TMem>(string? str, Encoding enc, out int strSize) where TMem : ISafeMemoryHandleFactory
		{
			if (str is null)
			{
				strSize = 0;
				return new GenericSafeHandle(IntPtr.Zero, p => true, false);
			}
			var bytes = StringHelper.GetBytes(str, enc, true);
			strSize = bytes.Length;
			return Extensions.CreateSafeMemory<TMem>(bytes);
		}

		static string? Read(IntPtr ptr, Encoding enc, long allocatedBytes = long.MaxValue)
		{
			if (ptr == default)
				return null;

			unsafe
			{
				long num = 0L;
				if (StringHelper.GetCharSize(enc) == 1)
				{
					byte* ptr2 = (byte*)ptr;
					while (num < allocatedBytes && *ptr2 != 0)
					{
						num++;
						ptr2++;
					}
				}
				else
				{
					ushort* ptr3 = (ushort*)ptr;
					while (num + 2 <= allocatedBytes && *ptr3 != 0)
					{
						num += 2;
						ptr3++;
					}
				}
				return enc.GetString((byte*)ptr.ToPointer(), (int)num);
			}
		}

		private static UnmanagedType GetKind(FieldInfo fi) => fi.GetCustomAttribute<MarshalAsAttribute>()?.Value ?? UnmanagedType.LPTStr;
	}

	internal class StructMarshaler(FieldInfo fieldInfo, MarshalerOptions options) : DirectMarshaler(fieldInfo, fieldInfo.FieldType, options)
	{
		public MarshaledTypeInfo TypeInfo { get; } = MarshaledTypeInfo.Get(fieldInfo.FieldType, options);
		public override int Alignment => TypeInfo.Alignment;
		public override int MaxFieldSize => TypeInfo.Fields.Max(f => f.MaxFieldSize);
		public override int Size => TypeInfo.NativeSize;
	}

	internal class StructPtrMarshaler(FieldInfo fieldInfo, MarshalerOptions options) : IndirectMarshaler(fieldInfo, options)
	{
		public override void Read(nint ptr, int offset, MarshaledTypeInfo mti, object? obj)
		{
			if (obj is null) return;
			// TODO: Read ptr at offset, not offset
			var readVal = MarshaledTypeInfo.ReadInstanceFromMemory(FieldInfo.FieldType, ReadPtr(ptr, offset), Options);
			FieldInfo.SetValue(obj, readVal);
		}

		public override void Write<TMem>(object? value, nint ptr, int offset, ISafeMemoryHandle p)
		{
			if (value is null) return;
			var mem = MarshaledTypeInfo.WriteInstanceToMemory<TMem>(FieldInfo.GetValue(value), Options);
			WritePtr(mem, ptr, offset, p);
		}
	}

	// TODO: Complete
	internal class UnionMarshaler(string unionName, List<TypeMarshaler> fields, MarshalerOptions options) : DirectData(typeof(byte[]), options), IProvideFieldList
	{
		public override int Alignment => Fields.Max(f => f.Alignment);
		public IReadOnlyList<TypeMarshaler> Fields { get; } = fields;
		public override int MaxFieldSize => Fields.Max(f => f.MaxFieldSize);
		public override int Size => Fields.Max(f => f.Size);
		public string UnionId { get; } = unionName;
		public override void Read(nint ptr, int offset, MarshaledTypeInfo mti, object? obj) => throw new NotImplementedException();
		public override void Write<TMem>(object? value, nint ptr, int offset, ISafeMemoryHandle p) => throw new NotImplementedException();
	}

	internal class VariantMarshaler(FieldInfo fieldInfo, MarshalerOptions options) : DirectMarshaler(fieldInfo, typeof(IntPtr), options)
	{
		[StructLayout(LayoutKind.Sequential)]
		private struct VarHolder(object? d)
		{
			[MarshalAs(UnmanagedType.Struct)]
			public object? data = d;
		}

		public override void Read(nint ptr, int offset, MarshaledTypeInfo mti, object? obj)
		{
			if (obj is null) return;
			var readVal = ptr.Offset(offset).ToNullableStructure<VarHolder>()!;
			FieldInfo.SetValue(obj, readVal?.data);
		}

		public override void Write<TMem>(object? value, nint ptr, int offset, ISafeMemoryHandle p)
		{
			if (value is null) return;
			Debug.Assert(FieldInfo.FieldType == typeof(object));
			ptr.Write(new VarHolder(FieldInfo.GetValue(value)), offset);
		}
	}
}