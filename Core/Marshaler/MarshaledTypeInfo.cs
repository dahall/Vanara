using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using Vanara.Extensions;
using Vanara.Extensions.Reflection;
using Vanara.InteropServices;
using static Vanara.Marshaler.Extensions;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace Vanara.Marshaler;

public static partial class Marshaler
{
	internal class MarshaledTypeInfo : IEquatable<MarshaledTypeInfo>
	{
		private static readonly Type bfType = typeof(MarshalFieldAs.BitFieldAttribute<>);
		private static readonly Dictionary<(Type, MarshalerOptions), MarshaledTypeInfo> typeList = [];
		private int alignment;
		private readonly MarshalerOptions options;

		public MarshaledTypeInfo(Type type, MarshalerOptions? opts = null)
		{
			options = opts ?? new();
			alignment = type.GetCustomAttribute<MarshaledAttribute>()?.Pack ?? 0;
			Type = type;
			options.UpdateEncoding(type.GetCustomAttribute<MarshaledAttribute>()?.StringEncoding);

			var layout = Type.GetCustomAttribute<MarshaledAttribute>()?.Layout ?? LayoutModel.Sequential;
			var fields = Type.GetFields(allInstFields);

			for (var i = 0; i < fields.Length; i++)
			{
				var fi = fields[i];
				TypeMarshaler? fd = GetMarshaler(fi, options);

				if (fd is StructPtrMarshaler spfd)
					SubTypes.Add(Get(spfd.FieldInfo.FieldType, options));

				if (fd is null)
				{
					// Handle bit values
					var bitAttr = fi.GetCustomAttributes(bfType).FirstOrDefault();
					if (bitAttr is not null)
					{
						List<TypeMarshaler> bitFields = [new DirectMarshaler(fi, null, options)];
						Type curType = bitAttr.GetType().GenericTypeArguments.First();
						int curTypeSize = curType.GetBitSize();
						int curWidth = bfType.GetPropertyValue("BitCount", 1), width = curWidth;
						if (fi.FieldType == typeof(bool) && curWidth != 1 || fi.FieldType.GetBitSize() < curWidth)
							throw new MarshalException("The fd type of a BitType must be large enough to hold the specified BitCount.");
						while (++i < fields.Length && curWidth <= curTypeSize && (bitAttr = fields[i].GetCustomAttributes(bfType).FirstOrDefault()) is not null)
						{
							fd = new DirectMarshaler(fields[i], null, options);
							if (bitAttr.GetType().GenericTypeArguments.First() == curType)
							{
								if ((width += (curWidth = bitAttr.GetPropertyValue("BitCount", 1))) <= curTypeSize && !bitAttr.GetPropertyValue("StartNewField", false))
								{
									fd.Offset = width - curWidth;
									bitFields.Add(fd);
								}
								else
								{
									Fields.Add(new BitMarshaler(curType, bitFields, options));
									bitFields = [fd];
								}
							}
							else
							{
								Fields.Add(new BitMarshaler(curType, bitFields, options));
								bitFields = [fd];
								curType = bitAttr.GetType().GenericTypeArguments.First();
								if (!curType.IsIntegral())
									throw new MarshalException("BitFieldAttribute must be a whole number type.");
								curTypeSize = Marshal.SizeOf(curType) * 8;
								curWidth = width = bitAttr.GetPropertyValue("BitCount", 1);
							}
						}
						if (bitFields.Count > 0)
							Fields.Add(new BitMarshaler(curType, bitFields, options));
						continue;
					}

					/*// Handle union values
					var unionId = fi.GetCustomAttribute<MarshalFieldAs.UnionFieldAttribute>()?.UnionId;
					if (unionId is not null)
					{
						List<TypeMarshaler> uFields = [fd];
						while (++i < fields.Length && fields[i].GetCustomAttribute<MarshalFieldAs.UnionFieldAttribute>()?.UnionId == unionId)
						{
							fd = GetMarshaler(fields[i], options);
							uFields.Add(fd);
							if (fd.NativeType.HasMembers())
								SubTypes.Add(Get(fields[i].FieldType, options));
						}
						Fields.Add(new UnionMarshaler(unionId, uFields, options));
						continue;
					}*/

					throw new MarshalException($"Unable to marshal the fd '{fi.DeclaringType!.FullName}.{fi.Name}' due to an unrecognized fd type and attribute combination.");
				}

				// Default handler
				Fields.Add(fd);
			}

			if (Fields.Count == 0)
				return;

			if (Fields.Count == 1)
			{
				NativeSize = Math.Max(Fields[0].Size, Alignment);
				return;
			}

			// Calculate the offset of each fd of the structure and the total size of the structure
			int div = Alignment, size = 0;
			switch (layout)
			{
				case LayoutModel.Union:
					size = Fields.Max(f => f.Size);
					break;

				case LayoutModel.Sequential:
				default:
					{
						var offset = Fields[0].Size;
						for (var i = 1; i < Fields.Count; i++)
						{
							var pad = div - offset % div;
							var fd = Fields[i];
							if (pad == 0 || fd.MaxFieldSize <= pad)
							{
								fd.Offset = offset;
								offset += fd.Size;
							}
							else
							{
								fd.Offset = offset + pad;
								offset += fd.Size + pad;
							}
						}
						size = offset % div == 0 ? offset : offset + div - offset % div;
						break;
					}
			}

			NativeSize = Math.Max(size, type.GetCustomAttribute<MarshaledAttribute>()?.Size ?? 0);
		}

		public int Alignment => alignment == 0 && Fields.Count > 0 ? alignment = CalcAlignment() : alignment;
		public Bitness Bitness { get; }
		public List<TypeMarshaler> Fields { get; } = [];
		public int NativeSize { get; set; } = 0;
		public List<MarshaledTypeInfo> SubTypes { get; } = [];
		public Type Type { get; }

		public static MarshaledTypeInfo Get(Type type, MarshalerOptions? opts = null)
		{
			opts ??= new();
			type = type.AsNonNullable();
			if (!typeList.TryGetValue((type, opts), out var info))
				typeList.Add((type, opts), info = new(type, opts));
			return info;
		}

		public static object? ReadInstanceFromMemory(Type type, nint ptr, MarshalerOptions? opts = null)
		{
			if (ptr == IntPtr.Zero)
				return type.IsNullable() || type.IsClass ? null : throw new ArgumentNullException(nameof(ptr), "Pointer cannot be null for a non-nullable type.");

			opts ??= new();
			if (!type.AsNonNullable().IsMarshaledType())
				return ptr.Convert(uint.MaxValue, type.AsNonNullable(), opts.Encoding);

			var ti = Get(type, opts);
			return ReadFields(ti, ptr);

			static object? ReadFields(MarshaledTypeInfo mti, IntPtr ptr)
			{
				if (mti.Fields.Count == 0)
					return default;
				var obj = Activator.CreateInstance(mti.Type);
				for (int i = 0; i < mti.Fields.Count; i++)
				{
					TypeMarshaler fd = mti.Fields[i];
					fd.Read(ptr, fd.Offset, mti, obj);
				}
				return obj!;
			}
		}

		public static ISafeMemoryHandle WriteInstanceToMemory<TMem>(object? value, MarshalerOptions? opts = null) where TMem : ISafeMemoryHandleFactory
		{
			if (value is null)
				return CreateSafeMemory<TMem>(0);

			opts ??= new();
			var ti = Get(value.GetType(), opts);

			// Walk through each fd of each object recursively setting any general values, like SizeOf and ArrayPtr references.
			int asz = Preprocess(ti, value);

			// Create memory for the write
			var p = CreateSafeMemory<TMem>(ti.NativeSize + asz);

			// Walk through each fd of each object recursively and pass value to the matched fd data
			WriteFields(ti, value, p.DangerousGetHandle());
			return p;

			int Preprocess(MarshaledTypeInfo mti, object obj)
			{
				int addSz = 0;
				for (int i = 0; i < mti.Fields.Count; i++)
				{
					if (mti.Fields[i] is not IPreprocessMarshaler fd)
						continue;
					addSz += fd.PreprocessWrite(mti, obj);
				}
				return addSz;
			}

			void WriteFields(MarshaledTypeInfo mti, object obj, IntPtr ptr)
			{
				for (int i = 0; i < mti.Fields.Count; i++)
				{
					TypeMarshaler fd = mti.Fields[i];
					fd.Write<TMem>(obj, ptr, fd.Offset, p);
				}
			}
		}

		public bool Equals(MarshaledTypeInfo? other) => Type.Equals(other?.Type) && Bitness.Equals(other?.Bitness);
		public override bool Equals(object? obj) => obj is MarshaledTypeInfo mti && Equals(mti);
		public TypeMarshaler? FindData(FieldInfo fi) =>
			Fields.OfType<IProvideFieldInfo>().FirstOrDefault(f => f.FieldInfo == fi) as TypeMarshaler ??
			Fields.OfType<IProvideFieldList>().SelectMany(f => f.Fields).OfType<IProvideFieldInfo>().FirstOrDefault(f => f.FieldInfo == fi) as TypeMarshaler;
		public override int GetHashCode() => (Type, Bitness).GetHashCode();

		[Conditional("DEBUG")]
		internal void DebugDump()
		{
			StringBuilder sb = new();
			WriteFields(sb, this, 0);
			Debug.Write(sb);

			static void WriteFields(StringBuilder sb, MarshaledTypeInfo ti, int indent)
			{
				string ind = new(' ', indent * 2);
				sb.AppendLine($"{ind}{ti.Type.Name}: align:{ti.Alignment}, bit:{ti.Bitness}, sz:{ti.NativeSize}\n{ind}Fields:");
				int i = 0;
				foreach (TypeMarshaler field in ti.Fields)
					sb.AppendLine($"{ind}{++i:D2}) {field.GetType().Name}: max:{field.MaxFieldSize} sz:{field.Size}");
				if (ti.SubTypes.Count > 0)
				{
					sb.AppendLine("Sub-types:");
					foreach (var st in ti.SubTypes)
						WriteFields(sb, st, indent + 1);
				}
			}
		}

		private static TypeMarshaler? GetMarshaler(FieldInfo fi, MarshalerOptions options)
		{
			Type ft = fi.FieldType;
			var attrs = fi.GetCustomAttributes(true).Where(o => o is MarshalFieldAs.IMarshalAsAttr or MarshalAsAttribute).OrderBy(o => o.GetType().Name).Cast<Attribute>().ToList();

			if (attrs.Count > 1)
				throw new MarshalException($"Multiple marshaling attributes are not supported. Field: {fi.Name}");

			// Handle non attributed fields
			if (attrs.Count == 0)
			{
				if (ft.IsMarshaledType())
					return new StructMarshaler(fi, options);
				else if (ft == typeof(string))
					return new StringMarshaler(fi, options);
				else if (typeof(Delegate).IsAssignableFrom(ft))
					return new FuncPtrMarshaler(fi, options);
				//else if (ft.IsBlittableArray())
				//	return new FixedArrayMarshaler(fi, ft.GetElementType()!.GetArrayRank(), options);
				else if (ft.IsNullable() && ft.AsNonNullable().IsValueType && (ft.AsNonNullable().IsMarshaledType() || ft.AsNonNullable().IsBlittable()))
					return new StructPtrMarshaler(fi, options);
				else if (fi.IsBlittableField() || ft.IsEnum || ft.IsNativeSized() || ft == typeof(char))
					return new DirectMarshaler(fi, null, options);
				else
					throw new MarshalException($"Fields of type {fi.FieldType.Name} are not supported. Field: {fi.Name}");
			}

			// Handle attributed fields
			return attrs[0] switch
			{
				MarshalAsAttribute ma when ma.Value is >= UnmanagedType.I1 and <= UnmanagedType.R8 && (ft.IsIntegral() || ft.IsFloatingPoint()) => new DirectMarshaler(fi, GetMarshaledType(ma.Value)!, options),

				MarshalAsAttribute ma when ma.Value is UnmanagedType.Bool or UnmanagedType.U1 or UnmanagedType.VariantBool =>
					new DirectMarshaler(fi, GetMarshaledType(ft == typeof(bool) ? ma.Value : throw new MarshalException("Only the U1, VariantBool, and Bool marshal types can be applied to boolean fields."))!, options),

#pragma warning disable CS0618 // Type or member is obsolete
				MarshalAsAttribute ma when ma.Value is UnmanagedType.Currency => ft == typeof(decimal) ? new CurrencyMarshaler(fi, options) : throw new MarshalException("Only the Currency marshal type can be applied to decimal fields."),
#pragma warning restore CS0618 // Type or member is obsolete

				MarshalAsAttribute ma when ft == typeof(string) => ma.Value is UnmanagedType.BStr or UnmanagedType.LPStr or UnmanagedType.LPWStr or UnmanagedType.LPTStr or (UnmanagedType)48 ?
					new StringMarshaler(fi, options) : (ma.Value is UnmanagedType.ByValTStr ? new FixedStringMarshaler(fi, ma.SizeConst, true, (StringEncoding)GetDeclCharSet(fi), options) :
					throw new MarshalException("Only the BStr, ByValTStr, LPStr, LPWStr, LPTStr, and LPUTF8Str marshal type can be applied to string fields.")),

				MarshalAsAttribute ma when ma.Value is UnmanagedType.IUnknown or UnmanagedType.Interface or UnmanagedType.IDispatch =>
					ft == typeof(object) || ft.IsCOMObject ? new InterfaceMarshaler(fi, options) :
					throw new MarshalException("The IUnknown, Interface, and IDispatch marshal types can be applied to object or COM interface fields."),

				MarshalAsAttribute ma when ma.Value is UnmanagedType.Struct => new VariantMarshaler(fi, options),

				MarshalAsAttribute ma when ma.Value is UnmanagedType.FunctionPtr => typeof(Delegate).IsAssignableFrom(ft) ? new FuncPtrMarshaler(fi, options) : throw new MarshalException("The FunctionPtr marshal type can be applied to delegate fields."),

				MarshalAsAttribute ma when ma.Value is UnmanagedType.ByValArray => ft.IsArray ? new FixedArrayMarshaler(fi, ma.SizeConst, options) : throw new MarshalException("The ByValArray marshal type can be applied to array fields."),

				MarshalAsAttribute ma when ma.Value is UnmanagedType.CustomMarshaler =>
					new CustomMarshalerMarshaler(fi, GetCustMarshType(ma) ?? throw new MarshalException("The CustomMarshaler marshal type must specify either a MarshalType or MarshalTypeRef value."), options),

				MarshalFieldAs.AppendedStringAttribute arrAttr => fi.FieldType == typeof(string) ? new AppendedStringMarshaler(fi, arrAttr, options) :
					throw new MarshalException("MarshalFieldAs.AppendedStringAttribute may only be applied to strings."),

				MarshalFieldAs.ArrayAttribute arrAttr => GetArrayField(arrAttr),

				MarshalFieldAs.UnionFieldAttribute => null,

				MarshalFieldAs.StructPtrAttribute _ => !fi.FieldType.IsValueType && !fi.FieldType.IsClass
							? throw new MarshalException("MarshalFieldAs.StructPtrAttribute may only be applied to structures and classes.")
							: (!fi.IsBlittableField() && fi.FieldType.GetCustomAttribute<MarshaledAttribute>() is null
							? throw new MarshalException("MarshalFieldAs.StructPtrAttribute may only be applied to blittable or marshaled objects.")
							: new StructPtrMarshaler(fi, options)),

				MarshalFieldAs.SizeOfAttribute _ => ft.IsIntegral() ? new SizeOfMarshaler(fi, options) : throw new MarshalException("The MarshalFieldAs.SizeOf attribute may only be applied to integral types."),

				MarshalFieldAs.FixedStringAttribute fsa => ft == typeof(string) ? new FixedStringMarshaler(fi, fsa.Length, fsa.NullTerm, fsa.StringEncoding, options) :
					throw new MarshalException("The MarshalFieldAs.FixedString attribute may only be applied to string types."),

				MarshalFieldAs.IMarshalAsAttr ia when ia.GetType().IsGenericType && ia.GetType().GetGenericTypeDefinition() == typeof(MarshalFieldAs.BitFieldAttribute<>) => null,

				_ => throw new MarshalException($"Unable to marshal the fd '{fi.DeclaringType!.FullName}.{fi.Name}' due to an unrecognized fd type and attribute combination."),
			};

			static CharSet GetDeclCharSet(FieldInfo fi) => (fi.DeclaringType?.GetCustomAttribute<StructLayoutAttribute>())?.CharSet ?? CharSet.Auto;

#pragma warning disable IL2057 // Unrecognized value passed to the parameter of method. It's not possible to guarantee the availability of the target type.
			static Type? GetCustMarshType(MarshalAsAttribute ma) => ma.MarshalTypeRef is not null ? ma.MarshalTypeRef :
				!string.IsNullOrEmpty(ma.MarshalType) ? Type.GetType(ma.MarshalType, false) : null;
#pragma warning restore IL2057 // Unrecognized value passed to the parameter of method. It's not possible to guarantee the availability of the target type.

			static Type? GetMarshaledType(UnmanagedType umtype) => umtype switch
			{
				UnmanagedType.I1 => typeof(sbyte),
				UnmanagedType.U1 => typeof(byte),
				UnmanagedType.VariantBool or UnmanagedType.I2 => typeof(short),
				UnmanagedType.U2 => typeof(ushort),
				UnmanagedType.I4 or UnmanagedType.Error => typeof(int),
				UnmanagedType.U4 or UnmanagedType.Bool => typeof(uint),
#pragma warning disable CS0618 // Type or member is obsolete
				UnmanagedType.I8 or UnmanagedType.Currency => typeof(long),
#pragma warning restore CS0618 // Type or member is obsolete
				UnmanagedType.U8 => typeof(ulong),
				UnmanagedType.R4 => typeof(float),
				UnmanagedType.R8 => typeof(double),
				UnmanagedType.ByValTStr => typeof(byte[]),
				UnmanagedType.BStr or UnmanagedType.LPStr or UnmanagedType.LPWStr or UnmanagedType.LPTStr or UnmanagedType.IUnknown or
					UnmanagedType.IDispatch or UnmanagedType.Struct or UnmanagedType.LPStruct or UnmanagedType.Interface or
					UnmanagedType.SafeArray or UnmanagedType.ByValArray or UnmanagedType.SysInt or UnmanagedType.FunctionPtr or
					UnmanagedType.LPArray or (UnmanagedType)48 or UnmanagedType.CustomMarshaler => typeof(IntPtr),
				UnmanagedType.SysUInt => typeof(UIntPtr),
				_ => null,
			};

			TypeMarshaler GetArrayField(MarshalFieldAs.ArrayAttribute arrAttr)
			{
				// Check for bad configs
				if (!fi.FieldType.IsArray)
					throw new MarshalException("ArrayAttribute can only be applied to array types.");
				if (arrAttr.Layout is ArrayLayout.ByValArray or ArrayLayout.ByValAnySizeArray or ArrayLayout.ByValAppendedArray
					or ArrayLayout.LPArray or ArrayLayout.StringPtrArray && arrAttr.SizeConst == 0 && arrAttr.SizeFieldName is null)
					throw new MarshalException("ArrayAttribute with specified layout must set either SizeConst or StringLenFieldName.");
				if (arrAttr.SizeFieldName is not null && (fi.DeclaringType!.GetField(arrAttr.SizeFieldName, allInstFields) is null || !fi.DeclaringType!.GetField(arrAttr.SizeFieldName, allInstFields)!.FieldType.IsIntegral()))
					throw new MarshalException($"Size fd '{arrAttr.SizeFieldName}' not found in {fi.DeclaringType!.Name} or type of field is not an integral number.");

				// Check to make sure the array type can be marshaled
				var elemType = fi.FieldType.GetElementType();
				if (elemType is not null && elemType.IsMarshaledType())
					Get(elemType, options);

				return arrAttr.Layout switch
				{
					ArrayLayout.ByValArray or ArrayLayout.ByValAnySizeArray or ArrayLayout.ByValAppendedArray => new FixedArrayMarshaler(fi, arrAttr, options),
					ArrayLayout.LPArray or ArrayLayout.LPArrayNullTerm /*or ArrayLayout.SafeArray*/ => new ArrayMarshaler(fi, arrAttr, options),
					ArrayLayout.StringPtrArray or ArrayLayout.StringPtrArrayNullTerm or ArrayLayout.ConcatenatedStringArray => new StringArrayMarshaler(fi, arrAttr, options),
					_ => throw new MarshalException("Unknown array layout."),
				};
			}
		}

		private int CalcAlignment()
		{
			if (Fields.Count == 0) return 1;
			var max = Fields.Max(f => f?.Alignment ?? 0);
			if (max == 0) return 1;
			var align = 1;
			while (align < max)
				align <<= 1;
			return align;
		}
	}
}