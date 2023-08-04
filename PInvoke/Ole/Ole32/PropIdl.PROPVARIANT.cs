#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable IDE1006 // Naming Styles
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security;
using static Vanara.PInvoke.OleAut32;
using static Vanara.PInvoke.PropSys;

namespace Vanara.PInvoke;

/// <summary></summary>
public static partial class Ole32
{
	/// <summary>
	/// Structure to mimic behavior of VT_BLOB type. "DWORD count of bytes, followed by that many bytes of data. The byte count does not
	/// include the four bytes for the length of the count itself; an empty blob member would have a count of zero, followed by zero bytes."
	/// </summary>
	[StructLayout(LayoutKind.Sequential, Pack = 0)]
	public struct BLOB
	{
		/// <summary>The count of bytes</summary>
		public uint cbSize;

		/// <summary>A pointer to the allocated array of bytes.</summary>
		public IntPtr pBlobData;
	}

	/// <summary>Structure to hold VT_CLIPDATE content.</summary>
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct CLIPDATA
	{
		/// <summary>The size of the buffer pointed to by pClipData, plus sizeof(ulClipFmt)</summary>
		public int cbSize;

		/// <summary>The clipboard format.</summary>
		public int ulClipFmt;

		/// <summary>The clipboard data.</summary>
		public IntPtr pClipData;

		/// <summary>Initializes a new instance of the <see cref="CLIPDATA"/> struct.</summary>
		/// <param name="clipFmt">The clipboard format.</param>
		/// <param name="dataPtr">A pointer to the data.</param>
		/// <param name="dataLength">
		/// Length of the data in bytes. Do not include any length other than that pointed to by <paramref name="dataPtr"/>.
		/// </param>
		public CLIPDATA(int clipFmt, IntPtr dataPtr, int dataLength)
		{
			cbSize = dataLength + Marshal.SizeOf(typeof(int));
			ulClipFmt = clipFmt;
			pClipData = dataPtr;
		}

		/// <summary>Initializes a new instance of the <see cref="CLIPDATA"/> struct.</summary>
		/// <param name="clipFmt">The string value to register as a new clipboard format using RegisterClipboardFormat.</param>
		public CLIPDATA(string clipFmt)
		{
			pClipData = Marshal.StringToHGlobalAuto(clipFmt);
			ulClipFmt = clipFmt.Length + 1;
			cbSize = ulClipFmt * Marshal.SystemDefaultCharSize + Marshal.SizeOf(typeof(int));
		}

		/// <summary>The clipboard format.</summary>
		public uint ClipboardFormat => ulClipFmt is (-1) or (-2) ? (uint)Marshal.ReadInt32(pClipData) : 0;

		/// <summary>The clipboard name.</summary>
		public string? ClipboardFormatName => ulClipFmt > 0 ? Marshal.PtrToStringUni(pClipData) : null;

		/// <summary>The clipboard format id.</summary>
		public Guid FMTID => ulClipFmt == -3 ? pClipData.ToStructure<Guid>() : Guid.Empty;

		/// <inheritdoc/>
		public override string ToString() => ulClipFmt switch
		{
			0 => "[No data]",
			-1 or -2 => $"CF={ClipboardFormat}",
			-3 => $"FMTID={FMTID:B}",
			_ => $"Name={ClipboardFormatName}",
		};
	}

	[StructLayout(LayoutKind.Sequential, Pack = 2)]
	public struct PACKEDMETA
	{
		public ushort mm;
		public ushort xExt;
		public ushort yExt;
		public ushort reserved;
	}

	/// <summary>
	/// The PROPVARIANT structure is used in the ReadMultiple and WriteMultiple methods of IPropertyStorage to define the type tag and
	/// the value of a property in a property set.
	/// <para>
	/// The PROPVARIANT structure is also used by the GetValue and SetValue methods of IPropertyStore, which replaces IPropertySetStorage
	/// as the primary way to program item properties in Windows Vista. For more information, see Property Handlers.
	/// </para>
	/// <para>
	/// There are five members. The first member, the value-type tag, and the last member, the value of the property, are significant.
	/// The middle three members are reserved for future use.
	/// </para>
	/// </summary>
	[StructLayout(LayoutKind.Explicit, Pack = 8)]
	public sealed class PROPVARIANT : ICloneable, IComparable, IComparable<PROPVARIANT>, IDisposable, IEquatable<PROPVARIANT>
	{
		/// <summary>Value type tag.</summary>
		[FieldOffset(0)] public VARTYPE vt;

		/// <summary>Reserved for future use.</summary>
		[FieldOffset(2)] public ushort wReserved1;

		/// <summary>Reserved for future use.</summary>
		[FieldOffset(4)] public ushort wReserved2;

		/// <summary>Reserved for future use.</summary>
		[FieldOffset(6)] public ushort wReserved3;

		/// <summary>The decimal value when VT_DECIMAL.</summary>
		[FieldOffset(0)] internal decimal _decimal;

		/// <summary>The raw data pointer.</summary>
		[FieldOffset(8)] internal IntPtr _ptr;

		/// <summary>The FILETIME when VT_FILETIME.</summary>
		[FieldOffset(8)] internal FILETIME _ft;

		/// <summary>The BLOB when VT_BLOB</summary>
		[FieldOffset(8)] internal BLOB _blob;

		/// <summary>The value when a numeric value less than 8 bytes.</summary>
		[FieldOffset(8)] internal ulong _ulong;

		/// <summary>Initializes a new instance of the <see cref="PROPVARIANT"/> class as VT_EMPTY.</summary>
		public PROPVARIANT()
		{
		}

		/// <summary>Initializes a new instance of the <see cref="PROPVARIANT"/> class with an object.</summary>
		/// <param name="obj">The object to wrap. Based on the object type, it will infer the value type and allocate memory as needed.</param>
		/// <param name="type">If not VT_EMPTY, this value will override the inferred value type.</param>
		public PROPVARIANT(object? obj, VarEnum type = VarEnum.VT_EMPTY)
		{
			if (obj is null)
				VarType = type;
			else if (obj is PROPVARIANT pv)
				PropVariantCopy(this, pv);
			else
				SetValue(obj, type);
		}

		/// <summary>Finalizes an instance of the <see cref="PROPVARIANT"/> class.</summary>
		~PROPVARIANT()
		{
			Dispose();
		}

		/// <summary>Gets the BLOB value.</summary>
		public BLOB blob => GetRawValue<BLOB>().GetValueOrDefault();

		/// <summary>Gets the boolean value.</summary>
		public bool boolVal => GetRawValue<bool>().GetValueOrDefault();

		/// <summary>Gets the BSTR value.</summary>
		public string? bstrVal => GetString(VarType);

		/// <summary>Gets the byte value.</summary>
		public byte bVal => GetRawValue<byte>().GetValueOrDefault();

		/// <summary>Gets the boolean array value.</summary>
		public IEnumerable<bool> cabool => GetVector<short>().Select(s => s != 0);

		/// <summary>Gets the string array value.</summary>
		public IEnumerable<string?> cabstr => GetStringVector();

		/// <summary>Gets the sbyte array value.</summary>
		public IEnumerable<sbyte> cac => GetVector<sbyte>();

		/// <summary>Gets the CLIPDATA array value.</summary>
		public IEnumerable<CLIPDATA> caclipdata => GetVector<CLIPDATA>();

		/// <summary>Gets the decimal array value.</summary>
		public IEnumerable<decimal> cacy => GetVector<long>().Select(decimal.FromOACurrency);

		/// <summary>Gets the DateTime array value.</summary>
		public IEnumerable<DateTime> cadate => GetVector<double>().Select(DateTime.FromOADate);

		/// <summary>Gets the double array value.</summary>
		public IEnumerable<double> cadbl => GetVector<double>();

		/// <summary>Gets the FILETIME array value.</summary>
		public IEnumerable<FILETIME> cafiletime => GetVector<FILETIME>();

		/// <summary>Gets the float array value.</summary>
		public IEnumerable<float> caflt => GetVector<float>();

		/// <summary>Gets the long array value.</summary>
		public IEnumerable<long> cah => GetVector<long>();

		/// <summary>Gets the short array value.</summary>
		public IEnumerable<short> cai => GetVector<short>();

		/// <summary>Gets the int array value.</summary>
		public IEnumerable<int> cal => GetVector<int>();

		/// <summary>Gets the ANSI string array value.</summary>
		public IEnumerable<string?> calpstr => GetStringVector();

		/// <summary>Gets the Unicode string array value.</summary>
		public IEnumerable<string?> calpwstr => GetStringVector();

		/// <summary>Gets the PROPVARIANT array value.</summary>
		public IEnumerable<PROPVARIANT> capropvar => GetVector<PROPVARIANT>();

		/// <summary>Gets the Win32Error array value.</summary>
		public IEnumerable<Win32Error> cascode => GetVector<Win32Error>();

		/// <summary>Gets the byte array value.</summary>
		public IEnumerable<byte> caub => GetVector<byte>();

		/// <summary>Gets the ulong array value.</summary>
		public IEnumerable<ulong> cauh => GetVector<ulong>();

		/// <summary>Gets the ushort array value.</summary>
		public IEnumerable<ushort> caui => GetVector<ushort>();

		/// <summary>Gets the uint array value.</summary>
		public IEnumerable<uint> caul => GetVector<uint>();

		/// <summary>Gets the Guid array value.</summary>
		public IEnumerable<Guid> cauuid => GetVector<Guid>();

		/// <summary>Gets the sbyte value.</summary>
		public sbyte cVal => GetRawValue<sbyte>().GetValueOrDefault();

		/// <summary>Gets the decimal value.</summary>
		public decimal cyVal => decimal.FromOACurrency(GetRawValue<long>().GetValueOrDefault());

		/// <summary>Gets the date.</summary>
		public DateTime date => DateTime.FromOADate(GetRawValue<double>().GetValueOrDefault());

		/// <summary>Gets the double value.</summary>
		public double dblVal => GetRawValue<double>().GetValueOrDefault();

		/// <summary>Gets the FILETIME.</summary>
		public FILETIME filetime => _ft;

		/// <summary>Gets the float value.</summary>
		public float fltVal => GetRawValue<float>().GetValueOrDefault();

		/// <summary>Gets the long value.</summary>
		public long hVal => GetRawValue<long>().GetValueOrDefault();

		/// <summary>Gets the int value.</summary>
		public int intVal => GetRawValue<int>().GetValueOrDefault();

		//public IntPtr pparray { get { return GetRefValue<sbyte>(); } }

		/// <summary>Gets a value indicating whether this instance is by reference.</summary>
		/// <value><c>true</c> if this instance is null or empty; otherwise, <c>false</c>.</value>
		public bool IsByRef => vt.IsFlagSet(VARTYPE.VT_BYREF);

		/// <summary>Gets a value indicating whether this instance is null or empty.</summary>
		/// <value><c>true</c> if this instance is null or empty; otherwise, <c>false</c>.</value>
		public bool IsNullOrEmpty => vt is VARTYPE.VT_EMPTY or VARTYPE.VT_NULL;

		/// <summary>Gets a value indicating whether this instance is a string.</summary>
		/// <value><c>true</c> if this instance is a VT_BSTR or VT_LPWSTR; otherwise, <c>false</c>.</value>
		public bool IsString => vt is VARTYPE.VT_BSTR or VARTYPE.VT_LPWSTR;

		/// <summary>Gets a value indicating whether this instance has a vector type.</summary>
		/// <value><c>true</c> if this instance is a VT_ARRAY or VT_VECTOR; otherwise, <c>false</c>.</value>
		public bool IsVector => vt.IsFlagSet(VARTYPE.VT_ARRAY) || vt.IsFlagSet(VARTYPE.VT_VECTOR);

		/// <summary>Gets the short value.</summary>
		public short iVal => GetRawValue<short>().GetValueOrDefault();

		/// <summary>Gets the int value.</summary>
		public int lVal => GetRawValue<int>().GetValueOrDefault();

		/// <summary>Gets the array of objects.</summary>
		public IEnumerable<object?> parray => GetSafeArray();

		/// <summary>Gets the "by value" boolean value.</summary>
		public bool? pboolVal => GetRawValue<bool>();

		/// <summary>Gets the "by value" string value.</summary>
		public IntPtr pbstrVal => _ptr;

		/// <summary>Gets the "by value" byte value.</summary>
		public byte? pbVal => GetRawValue<byte>();

		/// <summary>Gets the "by value" CLIPDATA value.</summary>
		public CLIPDATA pclipdata => GetRawValue<CLIPDATA>().GetValueOrDefault();

		/// <summary>Gets the "by value" sbyte value.</summary>
		public sbyte? pcVal => GetRawValue<sbyte>();

		/// <summary>Gets the "by value" decimal value.</summary>
		public decimal? pcyVal
		{
			get
			{
				var d = GetRawValue<long>();
				return d.HasValue ? decimal.FromOACurrency(d.Value) : null;
			}
		}

		/// <summary>Gets the "by value" DateTime value.</summary>
		public DateTime? pdate
		{
			get
			{
				var d = GetRawValue<double>();
				return d.HasValue ? DateTime.FromOADate(d.Value) : null;
			}
		}

		/// <summary>Gets the "by value" double value.</summary>
		public double? pdblVal => GetRawValue<double>();

		/// <summary>Gets the "by value" decimal value.</summary>
		public decimal? pdecVal => GetRawValue<decimal>();

		/// <summary>Gets the "by value" pointer value.</summary>
		public object? pdispVal => punkVal;

		/// <summary>Gets the "by value" float value.</summary>
		public float? pfltVal => GetRawValue<float>();

		/// <summary>Gets the "by value" int value.</summary>
		public int? pintVal => GetRawValue<int>();

		/// <summary>Gets the "by value" short value.</summary>
		public short? piVal => GetRawValue<short>();

		/// <summary>Gets the "by value" int value.</summary>
		public int? plVal => GetRawValue<int>();

		/// <summary>Gets the IDispatch value.</summary>
		public object ppdispVal => ppunkVal;

		/// <summary>Gets the IUnknown value.</summary>
		public object ppunkVal => GetRawValue<IntPtr>().GetValueOrDefault();

		/// <summary>Gets the "by value" Win32Error value.</summary>
		public Win32Error? pscode
		{
			get
			{
				var r = GetRawValue<uint>();
				return r.HasValue ? new Win32Error(r.Value) : null;
			}
		}

		/// <summary>Gets the IStorage value.</summary>
		public IStorage? pStorage => (IStorage?)punkVal;

		/// <summary>Gets the IStream value.</summary>
		public IStream? pStream => (IStream?)punkVal;

		/// <summary>Gets the ANSI string value.</summary>
		public string? pszVal => GetString(VarType);

		/// <summary>Gets the "by value" uint value.</summary>
		public uint? puintVal => GetRawValue<uint>();

		/// <summary>Gets the "by value" ushort value.</summary>
		public ushort? puiVal => GetRawValue<ushort>();

		/// <summary>Gets the "by value" uint value.</summary>
		public uint? pulVal => GetRawValue<uint>();

		/// <summary>Gets the "by value" IUnknown value.</summary>
		public object? punkVal => _ptr == IntPtr.Zero ? null : Marshal.GetObjectForIUnknown(_ptr);

		/// <summary>Gets the "by value" Guid value.</summary>
		public Guid? puuid => GetRawValue<Guid>();

		/// <summary>Gets the "by value" PROPVARIANT value.</summary>
		public PROPVARIANT? pvarVal => _ptr.ToStructure<PROPVARIANT>();

		/// <summary>Gets a stream with a Guid version.</summary>
		public IntPtr pVersionedStream => GetRawValue<IntPtr>().GetValueOrDefault();

		/// <summary>Gets the Unicode string value.</summary>
		public string? pwszVal => GetString(VarType);

		/// <summary>Gets the Win32Error value.</summary>
		public Win32Error scode => new(GetRawValue<uint>().GetValueOrDefault());

		/// <summary>Gets the ulong value.</summary>
		public ulong uhVal => GetRawValue<ulong>().GetValueOrDefault();

		/// <summary>Gets the uint value.</summary>
		public uint uintVal => GetRawValue<uint>().GetValueOrDefault();

		/// <summary>Gets the ushort value.</summary>
		public ushort uiVal => GetRawValue<ushort>().GetValueOrDefault();

		/// <summary>Gets the uint value.</summary>
		public uint ulVal => GetRawValue<uint>().GetValueOrDefault();

		/// <summary>Gets the value base on the <see cref="vt"/> value.</summary>
		public object? Value
		{
			get => GetValue();
			private set => SetValue(value);
		}

		/// <summary>Gets or sets the type of the variable.</summary>
		/// <value>The value type.</value>
		public VarEnum VarType { get => (VarEnum)vt; set => vt = (VARTYPE)value; }

		private bool IsPrimitive => vt switch
		{
			// Signed
			VARTYPE.VT_I1 or VARTYPE.VT_I2 or VARTYPE.VT_I4 or VARTYPE.VT_I8 or VARTYPE.VT_UI1 or VARTYPE.VT_UI2 or VARTYPE.VT_UI4 or VARTYPE.VT_UI8 or VARTYPE.VT_BOOL or VARTYPE.VT_ERROR or VARTYPE.VT_HRESULT or VARTYPE.VT_INT or VARTYPE.VT_UINT or VARTYPE.VT_R4 or VARTYPE.VT_R8 or VARTYPE.VT_DATE or VARTYPE.VT_FILETIME => true,
			_ => false,
		};

		/// <summary>Creates a new <see cref="PROPVARIANT"/> instance from a pointer to a VARIANT.</summary>
		/// <param name="pSrcNativeVariant">A pointer to a native in-memory VARIANT.</param>
		/// <returns>A new <see cref="PROPVARIANT"/> instance converted from the VARIANT pointer.</returns>
		public static PROPVARIANT FromNativeVariant(IntPtr pSrcNativeVariant)
		{
			var pv = new PROPVARIANT();
			VariantToPropVariant(pSrcNativeVariant, pv).ThrowIfFailed();
			return pv;
		}

		/// <summary>Gets the Type for a provided VARTYPE.</summary>
		/// <param name="vt">The VARTYPE value to lookup.</param>
		/// <returns>A best fit <see cref="Type"/> for the provided VARTYPE.</returns>
		public static Type? GetType(VARTYPE vt)
		{
			// Safe arrays are always pointers
			if (vt.IsFlagSet(VARTYPE.VT_ARRAY)) return typeof(IntPtr);
			var elemType = (VARTYPE)((int)vt & 0xFFF);
			// VT_NULL is always DBNull
			if (elemType == VARTYPE.VT_NULL) return typeof(DBNull);
			// Get type of element, return null if VT_EMPTY or not found
			Type? type = CorrespondingTypeAttribute.GetCorrespondingTypes(elemType).FirstOrDefault();
			if (type == null || elemType == 0) return null;
			// Change type if by reference
			if (vt.IsFlagSet(VARTYPE.VT_BYREF))
			{
				type = Nullable.GetUnderlyingType(type);
				if (type is not null && type.IsValueType)
					type = typeof(Nullable<>).MakeGenericType(type);
			}
			// Change type if vector
			if (vt.IsFlagSet(VARTYPE.VT_VECTOR) && type is not null)
			{
				type = typeof(IEnumerable<>).MakeGenericType(type);
			}
			return type;
		}

		/// <summary>Gets the VARTYPE for a provided type.</summary>
		/// <param name="type">The type to analyze.</param>
		/// <returns>A best fit <see cref="VARTYPE"/> for the provided type.</returns>
		public static VARTYPE GetVarType(Type? type)
		{
			if (type == null)
				return VARTYPE.VT_NULL;
			var elemtype = type.GetElementType() ?? type;

			if (type.IsArray && elemtype == typeof(object)) return VARTYPE.VT_ARRAY | VARTYPE.VT_VARIANT;

			var isEnumerable = type.IsArray || type != typeof(string) && typeof(IEnumerable).IsAssignableFrom(type);
			VARTYPE ret = 0;
			if (isEnumerable)
			{
				ret |= VARTYPE.VT_VECTOR;
				var i = type.GetInterface("IEnumerable`1");
				if (i != null)
				{
					var args = i.GetGenericArguments();
					if (args.Length == 1)
						elemtype = args[0];
				}
			}
			if (elemtype.IsNullable()) ret |= VARTYPE.VT_BYREF;

			if (elemtype == typeof(BLOB))
				return ret | VARTYPE.VT_BLOB;
			if (elemtype == typeof(BStrWrapper))
				return ret | VARTYPE.VT_BSTR;
			if (elemtype == typeof(CLIPDATA))
				return ret | VARTYPE.VT_CF;
			if (elemtype == typeof(Guid))
				return ret | VARTYPE.VT_CLSID;
			if (elemtype == typeof(CurrencyWrapper))
				return ret | VARTYPE.VT_CY;
			if (elemtype == typeof(Win32Error))
				return ret | VARTYPE.VT_ERROR;
			if (elemtype == typeof(FILETIME))
				return ret | VARTYPE.VT_FILETIME;
			if (elemtype == typeof(HRESULT))
				return ret | VARTYPE.VT_HRESULT;
			if (elemtype.IsCOMObject)
			{
#pragma warning disable IL2065 // The method has a DynamicallyAccessedMembersAttribute (which applies to the implicit 'this' parameter), but the value used for the 'this' parameter can not be statically analyzed.
				Type[] intf = elemtype!.GetInterfaces();
#pragma warning restore IL2065 // The method has a DynamicallyAccessedMembersAttribute (which applies to the implicit 'this' parameter), but the value used for the 'this' parameter can not be statically analyzed.
				if (intf.Contains(typeof(IStream))) return ret | VARTYPE.VT_STREAM;
				if (intf.Contains(typeof(IStorage))) return ret | VARTYPE.VT_STORAGE;
				return ret | VARTYPE.VT_UNKNOWN;
			}
			if (elemtype == typeof(IntPtr))
				return VARTYPE.VT_PTR;
			return Type.GetTypeCode(elemtype) switch
			{
				TypeCode.DBNull => ret | VARTYPE.VT_NULL,
				TypeCode.Boolean => ret | VARTYPE.VT_BOOL,
				TypeCode.Char => ret | VARTYPE.VT_LPWSTR,
				TypeCode.SByte => ret | VARTYPE.VT_I1,
				TypeCode.Byte => ret | VARTYPE.VT_UI1,
				TypeCode.Int16 => ret | VARTYPE.VT_I2,
				TypeCode.UInt16 => ret | VARTYPE.VT_UI2,
				TypeCode.Int32 => ret | VARTYPE.VT_I4,
				TypeCode.UInt32 => ret | VARTYPE.VT_UI4,
				TypeCode.Int64 => ret | VARTYPE.VT_I8,
				TypeCode.UInt64 => ret | VARTYPE.VT_UI8,
				TypeCode.Single => ret | VARTYPE.VT_R4,
				TypeCode.Double => ret | VARTYPE.VT_R8,
				TypeCode.Decimal => type.IsArray ? VARTYPE.VT_VECTOR | VARTYPE.VT_DECIMAL : VARTYPE.VT_DECIMAL | VARTYPE.VT_BYREF,
				TypeCode.DateTime => ret | VARTYPE.VT_DATE,
				TypeCode.String => ret | VARTYPE.VT_LPWSTR,
				_ => ret | VARTYPE.VT_USERDEFINED,
			};
		}

		/// <summary>
		/// Frees all elements that can be freed in this instance. For complex elements with known element pointers, the underlying
		/// elements are freed prior to freeing the containing element.
		/// </summary>
		[SecurityCritical, SecuritySafeCritical]
		public void Clear()
		{
			switch (vt)
			{
				case VARTYPE.VT_VECTOR | VARTYPE.VT_BSTR:
					foreach (var ptr in _blob.pBlobData.ToIEnum<IntPtr>((int)_blob.cbSize))
						Marshal.FreeBSTR(ptr);
					Marshal.FreeCoTaskMem(_blob.pBlobData);
					break;
				case VARTYPE.VT_VECTOR | VARTYPE.VT_LPSTR:
				case VARTYPE.VT_VECTOR | VARTYPE.VT_LPWSTR:
					foreach (var ptr in _blob.pBlobData.ToIEnum<IntPtr>((int)_blob.cbSize))
						Marshal.FreeCoTaskMem(ptr);
					Marshal.FreeCoTaskMem(_blob.pBlobData);
					break;
				case VARTYPE.VT_VECTOR | VARTYPE.VT_I1:
				case VARTYPE.VT_VECTOR | VARTYPE.VT_R4:
				case VARTYPE.VT_VECTOR | VARTYPE.VT_CLSID:
				case VARTYPE.VT_VECTOR | VARTYPE.VT_DECIMAL:
				case VARTYPE.VT_CF:
				case VARTYPE.VT_VECTOR | VARTYPE.VT_CF:
					Marshal.FreeCoTaskMem(_ptr);
					break;
				case VARTYPE.VT_UNKNOWN:
				case VARTYPE.VT_DISPATCH:
				case VARTYPE.VT_STREAM:
				case VARTYPE.VT_STREAMED_OBJECT:
				case VARTYPE.VT_STORAGE:
				case VARTYPE.VT_STORED_OBJECT:
					Marshal.Release(_ptr);
					break;
				case VARTYPE.VT_VECTOR | VARTYPE.VT_UNKNOWN:
				case VARTYPE.VT_VECTOR | VARTYPE.VT_DISPATCH:
					foreach (var iunk in GetVector<IntPtr>())
						Marshal.Release(iunk);
					Marshal.FreeCoTaskMem(_ptr);
					break;
				case VARTYPE.VT_VECTOR | VARTYPE.VT_VARIANT:
					foreach (var pv in GetVector<PROPVARIANT>())
						pv.Dispose();
					Marshal.FreeCoTaskMem(_ptr);
					break;
				default:
					PropVariantClear(this);
					break;
			}
			vt = 0;
			_blob = default;
		}

		/// <summary>Copies the contents of one PROPVARIANT structure to another.</summary>
		/// <param name="clone">The cloned copy.</param>
		public void Clone(out PROPVARIANT clone)
		{
			clone = new PROPVARIANT();
			PropVariantCopy(clone, this);
		}

		/// <summary>
		/// Compares the current instance with another object of the same type and returns an integer that indicates whether the current
		/// instance precedes, follows, or occurs in the same position in the sort order as the other object.
		/// </summary>
		/// <param name="other">An object to compare with this instance.</param>
		/// <returns>
		/// A value that indicates the relative order of the objects being compared. The return value has these meanings: Value Meaning
		/// Less than zero This instance precedes <paramref name="other"/> in the sort order. Zero This instance occurs in the same
		/// position in the sort order as <paramref name="other"/>. Greater than zero This instance follows <paramref name="other"/> in
		/// the sort order.
		/// </returns>
		public int CompareTo(object? other)
		{
			var v = Value;
			if (other is null) return v == null ? 0 : 1;
			if (other is PROPVARIANT pv) return PropVariantCompare(this, pv);
			if (v is null) return -1;
			var pvDest = new PROPVARIANT();
			if (PropVariantChangeType(pvDest, this, PROPVAR_CHANGE_FLAGS.PVCHF_DEFAULT, GetVarType(other.GetType())).Succeeded)
				return PropVariantCompare(this, pvDest);
			throw new ArgumentException(@"Unable to compare supplied object to PROPVARIANT.", nameof(other));
		}

		/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
		public void Dispose()
		{
			Clear();
			GC.SuppressFinalize(this);
		}

		/// <summary>Determines whether the specified <see cref="object"/>, is equal to this instance.</summary>
		/// <param name="obj">The <see cref="object"/> to compare with this instance.</param>
		/// <returns><c>true</c> if the specified <see cref="object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
		public override bool Equals(object? obj) => obj is PROPVARIANT pv ? Equals(pv.Value) : obj == this;

		/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
		public bool Equals(PROPVARIANT? other) => CompareTo(other) == 0;

		/// <summary>Returns a hash code for this instance.</summary>
		/// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
		public override int GetHashCode() => vt.GetHashCode();

		/// <summary>Returns a <see cref="string"/> that represents this instance.</summary>
		/// <returns>A <see cref="string"/> that represents this instance.</returns>
		public override string ToString()
		{
			string s = "";
			if (IsVector && Value is IEnumerable ie)
				s = string.Join(",", ie.Cast<object>().Select(o => o.ToString()).ToArray());
			else if (PropVariantToStringAlloc(this, out var str).Succeeded)
				s = str;
			return $"{vt}={s ?? "null"}";
		}

		/// <summary>Creates a new object that is a copy of the current instance.</summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		object ICloneable.Clone()
		{
			Clone(out var pv);
			return pv;
		}

		/// <summary>Compares the current object with another object of the same type.</summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>
		/// A 32-bit signed integer that indicates the relative order of the objects being compared. The return value has the following
		/// meanings: Value Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is
		/// equal to <paramref name="other"/>. Greater than zero This object is greater than <paramref name="other"/>.
		/// </returns>
		int IComparable<PROPVARIANT>.CompareTo(PROPVARIANT? other) => CompareTo(other);

		private static IEnumerable<T> ConvertToEnum<T>(object array, Func<object, T>? conv = null)
		{
			if (array is null) return new T[0];

			if (array is IEnumerable<T> iet) return iet;

			conv ??= (o => (T)Convert.ChangeType(o, typeof(T)));

			try
			{
				var ie = array as IEnumerable;
				return ie?.Cast<object>().Select(conv) ?? new[] { conv(array) };
			}
			catch
			{
				return new T[0];
			}
		}

		private static string? GetString(VarEnum ve, IntPtr ptr) => (VARTYPE)ve switch
		{
			VARTYPE.VT_LPSTR => Marshal.PtrToStringAnsi(ptr),
			VARTYPE.VT_LPWSTR => Marshal.PtrToStringUni(ptr),
			VARTYPE.VT_BSTR or VARTYPE.VT_BSTR | VARTYPE.VT_BYREF => Marshal.PtrToStringBSTR(ptr),
			_ => throw new InvalidCastException("Cannot cast this type to a string."),
		};

		private T? GetRawValue<T>() where T : struct
		{
			if (((int)vt <= 1 || (vt & VARTYPE.VT_BYREF) != 0) && _ptr == IntPtr.Zero)
				return null;

			var type = typeof(T);
			if (vt == (VARTYPE.VT_DECIMAL | VARTYPE.VT_BYREF) && type != typeof(decimal))
				return null;
			if (type == typeof(IntPtr)) return (T)(object)_ptr;
			if (type == typeof(bool)) return (T)(object)((ushort)_ulong != 0);
			if (type.IsPrimitive)
			{
				unsafe
				{
					fixed (void* dataPtr = &_ulong)
					{
						/*if (vt.IsFlagSet(IntVARTYPE.VT_R4))
							try { return (T)Convert.ChangeType((float)Marshal.PtrToStructure(new IntPtr(dataPtr), typeof(float)), typeof(T)); } catch { return null; }
						if (vt.IsFlagSet(IntVARTYPE.VT_R8))
							try { return (T)Convert.ChangeType((double)Marshal.PtrToStructure(new IntPtr(dataPtr), typeof(double)), typeof(T)); } catch { return null; }*/
						return new IntPtr(dataPtr).ToStructure<T>();
					}
				}
			}
			if (type == typeof(FILETIME)) return (T)(object)_ft;
			if (type == typeof(BLOB)) return (T)(object)_blob;
			if (type == typeof(decimal)) return (T)(object)_decimal;
			return _ptr.ToNullableStructure<T>();
		}

		private IEnumerable<object?> GetSafeArray()
		{
			if (_ptr == IntPtr.Zero) return new object[0];
			var sa = new SafeSAFEARRAY(_ptr, false);
			var dims = SafeArrayGetDim(sa);
			if (dims != 1) throw new NotSupportedException("Only single-dimensional arrays are supported");
			SafeArrayGetLBound(sa, 1U, out var lBound);
			SafeArrayGetUBound(sa, 1U, out var uBound);

			// If these are variants, then use Marshal to get them all
			if (vt.IsFlagSet(VARTYPE.VT_VARIANT))
			{
				using var d = new SafeArrayScopedAccessData(sa);
				return Marshal.GetObjectsForNativeVariants(d.Data, uBound - lBound + 1);
			}
			// Otherwise, pull each element out separately and stuff in an object array
			else
			{
				var ret = new object[uBound - lBound + 1];
				var elemSz = SafeArrayGetElemsize(sa);
				if (elemSz == 0) throw new Win32Exception();
				using var mem = new SafeCoTaskMemHandle(elemSz);
				SafeArrayGetVartype(sa, out var elemVT);
				Type? elemType = GetType(elemVT);
				if (elemType is not null)
				{
					for (int i = lBound; i <= uBound; i++)
					{
						SafeArrayGetElement(sa, i, mem).ThrowIfFailed();
						ret[i - lBound] = mem.DangerousGetHandle().Convert(mem.Size, elemType)!;
					}
				}
				return ret;
			}
		}

		private string? GetString(VarEnum ve) => GetString(ve, _ptr);

		private string?[] GetStringVector()
		{
			var ve = (VarEnum)((int)vt & 0x0FFF);
			if (ve == VarEnum.VT_LPSTR)
				return _blob.pBlobData.ToStringEnum((int)_blob.cbSize, CharSet.Ansi).ToArray();
			PropVariantToStringVector(this, out var vals).ThrowIfFailed();
			return vals;
		}

		private object? GetValue()
		{
			if (vt.IsFlagSet(VARTYPE.VT_ARRAY)) return GetSafeArray();
			var isVector = vt.IsFlagSet(VARTYPE.VT_VECTOR);
			var isRef = vt.IsFlagSet(VARTYPE.VT_BYREF);
			var elemType = (VARTYPE)((int)vt & 0xFFF);
			return elemType switch
			{
				VARTYPE.VT_NULL => DBNull.Value,
				VARTYPE.VT_I1 => isRef ? pcVal : (isVector ? cac : cVal),
				VARTYPE.VT_UI1 => isRef ? pbVal : (isVector ? caub : bVal),
				VARTYPE.VT_I2 => isRef ? piVal : (isVector ? cai : iVal),
				VARTYPE.VT_UI2 => isRef ? puiVal : (isVector ? caui : uiVal),
				VARTYPE.VT_INT or VARTYPE.VT_I4 => isRef ? plVal : (isVector ? cal : lVal),
				VARTYPE.VT_UINT or VARTYPE.VT_UI4 => isRef ? pulVal : (isVector ? caul : ulVal),
				VARTYPE.VT_I8 => isRef ? hVal : (isVector ? cah : hVal),
				VARTYPE.VT_UI8 => isRef ? uhVal : (isVector ? cauh : uhVal),
				VARTYPE.VT_R4 => isRef ? pfltVal : (isVector ? caflt : fltVal),
				VARTYPE.VT_R8 => isRef ? dblVal : (isVector ? cadbl : dblVal),
				VARTYPE.VT_BOOL => isRef ? pboolVal : (isVector ? cabool : boolVal),
				VARTYPE.VT_ERROR => isRef ? pscode : (isVector ? cascode : scode),
				VARTYPE.VT_HRESULT => isRef ? (pulVal.HasValue ? new HRESULT(plVal.GetValueOrDefault()) : (HRESULT?)null) : (isVector ? cal.Select(u => new HRESULT(u)) : new HRESULT(lVal)),
				VARTYPE.VT_CY => isRef ? pcyVal : (isVector ? cacy : cyVal),
				VARTYPE.VT_DATE => isRef ? pdate : (isVector ? cadate : date),
				VARTYPE.VT_FILETIME => isRef ? filetime : (isVector ? cafiletime : filetime),
				VARTYPE.VT_CLSID => isRef ? puuid : (isVector ? cauuid : puuid.GetValueOrDefault()),
				VARTYPE.VT_CF => isRef ? pclipdata : (isVector ? caclipdata : pclipdata),
				VARTYPE.VT_BSTR => isRef ? pbstrVal : (isVector ? cabstr : bstrVal),
				VARTYPE.VT_BLOB => isRef ? _blob : (isVector ? null : _blob),
				VARTYPE.VT_LPSTR => isRef ? pszVal : (isVector ? calpstr : pszVal),
				VARTYPE.VT_LPWSTR => isRef ? pwszVal : (isVector ? calpwstr : pwszVal),
				VARTYPE.VT_UNKNOWN or VARTYPE.VT_DISPATCH => isVector ? GetVector<IntPtr>()?.Select(Marshal.GetObjectForIUnknown) : (isRef ? ppunkVal : punkVal),
				VARTYPE.VT_STREAM or VARTYPE.VT_STREAMED_OBJECT => isRef ? pStream : (isVector ? null : pStream),
				VARTYPE.VT_STORAGE or VARTYPE.VT_STORED_OBJECT => isRef ? pStorage : (isVector ? null : pStorage),
				VARTYPE.VT_DECIMAL => isRef ? pdecVal : (isVector ? GetVector<decimal>() : pdecVal.GetValueOrDefault()),
				VARTYPE.VT_VARIANT => isRef ? pvarVal : (isVector ? GetVector<PROPVARIANT>() : pvarVal),
				VARTYPE.VT_USERDEFINED or VARTYPE.VT_RECORD or VARTYPE.VT_PTR or VARTYPE.VT_VOID => throw new ArgumentOutOfRangeException(nameof(vt), $"{vt}"),
				_ => null,
			};
		}

		private IEnumerable<T> GetVector<T>() => vt.IsFlagSet(VARTYPE.VT_VECTOR) ? (_blob.cbSize <= 0 ? new T[0] : _blob.pBlobData.ToArray<T>((int)_blob.cbSize))! : throw new InvalidCastException();

		private void SetSafeArray(IList<object> array)
		{
			if (array == null || array.Count == 0) return;
			var psa = SafeArrayCreateVector(VARTYPE.VT_VARIANT, 0, (uint)array.Count);
			if (psa.IsNull) throw new Win32Exception();
			using (var p = new SafeArrayScopedAccessData(psa))
			{
				var elemSz = SafeArrayGetElemsize(psa);
				if (elemSz == 0) throw new Win32Exception();
				for (var i = 0; i < array.Count; ++i)
					Marshal.GetNativeVariantForObject(array[i], p.Data.Offset(i * elemSz));
			}
			_ptr = psa.DangerousGetHandle();
			psa.SetHandleAsInvalid();
		}

		private void SetSafeArray(SafeSAFEARRAY array)
		{
			SafeArrayCopy(array, out var myArray).ThrowIfFailed();
			_ptr = myArray.DangerousGetHandle();
			myArray.SetHandleAsInvalid();
		}

		[SecurityCritical, SecuritySafeCritical]
		private void SetStringVector(IEnumerable<string> value, VarEnum ve)
		{
			if (value == null) throw new ArgumentNullException(nameof(value));
			var svt = ((VARTYPE)ve).ClearFlags(VARTYPE.VT_VECTOR);
			var sc = value.ToArray();
			if (sc.Length <= 0) return;
			switch (svt)
			{
				case VARTYPE.VT_BSTR:
					vt = svt | VARTYPE.VT_VECTOR;
					_blob.cbSize = (uint)sc.Length;
					_blob.pBlobData = value.Select(Marshal.StringToBSTR).MarshalToPtr(Marshal.AllocCoTaskMem, out var _);
					break;

				case VARTYPE.VT_LPSTR:
					vt = svt | VARTYPE.VT_VECTOR;
					_blob.cbSize = (uint)sc.Length;
					_blob.pBlobData = value.Select(Marshal.StringToCoTaskMemAnsi).MarshalToPtr(Marshal.AllocCoTaskMem, out var _);
					break;

				case VARTYPE.VT_LPWSTR:
					InitPropVariantFromStringVector(sc, (uint)sc.Length, this).ThrowIfFailed();
					break;

				default:
					break;
			}
		}

		private void SetStruct<T>(T? value, VarEnum ve) where T : struct
		{
			if (value.HasValue)
			{
				var type = typeof(T);
				if (type == typeof(IntPtr)) _ptr = (IntPtr)(object)value.Value;
				else if (type == typeof(bool)) _ptr = (IntPtr)(ushort)((bool)(object)value.Value ? -1 : 0);
				else if (value.Value.GetType().IsPrimitive)
					unsafe
					{
						fixed (void* ptr = &_ulong) Marshal.StructureToPtr(value.Value, new IntPtr(ptr), true);
					}
				else if (type == typeof(FILETIME)) _ft = (FILETIME)(object)value.Value;
				else if (type == typeof(BLOB)) _blob = (BLOB)(object)value.Value;
				else throw new ArgumentException($"Unrecognized structure {typeof(T).Name}"); // This would work but there is no means to free this memory. // _ptr = value.Value.StructureToPtr());
			}
			else
				vt |= VARTYPE.VT_BYREF;
		}

		/// <summary>Sets the value, clearing any existing value.</summary>
		/// <param name="value">The value.</param>
		/// <param name="vEnum">
		/// If this value equals VT_EMPTY, the method will attempt to ascertain the value type from the <paramref name="value"/>.
		/// </param>
		private void SetValue(object? value, VarEnum vEnum = VarEnum.VT_EMPTY)
		{
			Clear();
			var newVT = vt = vEnum == VarEnum.VT_EMPTY ? GetVarType(value?.GetType()) : (VARTYPE)vEnum;

			// Finished if NULL or EMPTY
			if ((int)vt <= 1) return;

			// Handle SAFEARRAY
			if (vt.IsFlagSet(VARTYPE.VT_ARRAY))
			{
				if (value is SafeSAFEARRAY sa)
				{
					SetSafeArray(sa);
					SafeArrayGetVartype(sa, out vt);
					vt |= VARTYPE.VT_ARRAY;
				}
				else
				{
					SetSafeArray(ConvertToEnum<object>(value!).ToList());
					vt = VARTYPE.VT_ARRAY | VARTYPE.VT_VARIANT;
				}
				return;
			}

			var isVector = vt.IsFlagSet(VARTYPE.VT_VECTOR);
			var isRef = vt.IsFlagSet(VARTYPE.VT_BYREF);

			// Handle BYREF null value
			if (isRef && value == null)
				return;

			// Handle case where element type is put in w/o specifying VECTOR
			if (value != null && !isVector && value.GetType().IsArray) vt |= VARTYPE.VT_VECTOR;

			var sz = 0U;
			var elemType = (VARTYPE)((int)vt & 0xFFF);
			switch (elemType)
			{
				case VARTYPE.VT_I1:
					Init<sbyte>(AllocVector);
					break;

				case VARTYPE.VT_UI1:
					Init<byte>(InitPropVariantFromBuffer);
					break;

				case VARTYPE.VT_I2:
					Init<short>(InitPropVariantFromInt16Vector);
					break;

				case VARTYPE.VT_UI2:
					Init<ushort>(InitPropVariantFromUInt16Vector);
					break;

				case VARTYPE.VT_I4:
				case VARTYPE.VT_INT:
					Init<int>(InitPropVariantFromInt32Vector);
					vt = newVT;
					break;

				case VARTYPE.VT_UI4:
				case VARTYPE.VT_UINT:
					Init<uint>(InitPropVariantFromUInt32Vector);
					vt = newVT;
					break;

				case VARTYPE.VT_I8:
					Init<long>(InitPropVariantFromInt64Vector);
					break;

				case VARTYPE.VT_UI8:
					Init<ulong>(InitPropVariantFromUInt64Vector);
					break;

				case VARTYPE.VT_R4:
					Init<float>(AllocVector);
					break;

				case VARTYPE.VT_R8:
					Init<double>(InitPropVariantFromDoubleVector);
					break;

				case VARTYPE.VT_BOOL:
					Init<bool>(InitPropVariantFromBooleanVector);
					break;

				case VARTYPE.VT_ERROR:
					Init(InitPropVariantFromUInt32Vector, o => o is Win32Error err ? (uint)err : (uint)Convert.ChangeType(o, typeof(uint)));
					vt = newVT;
					break;

				case VARTYPE.VT_HRESULT:
					Init(InitPropVariantFromUInt32Vector, o => o is HRESULT hr ? (uint)(int)hr : (uint)Convert.ChangeType(o, typeof(uint)));
					vt = newVT;
					break;

				case VARTYPE.VT_CY:
					Init(InitPropVariantFromUInt64Vector, o => o is decimal d ? (ulong)decimal.ToOACurrency(d) : (ulong)Convert.ChangeType(o, typeof(ulong)));
					vt = newVT;
					break;

				case VARTYPE.VT_DATE:
					double ToDouble(object o)
					{
						if (o is DateTime dt)
							return dt.ToOADate();
						if (o is FILETIME ft)
							return ft.ToDateTime().ToOADate();
						return (double)Convert.ChangeType(o, typeof(double));
					}
					Init(InitPropVariantFromDoubleVector, ToDouble);
					vt = newVT;
					break;

				case VARTYPE.VT_FILETIME:
					FILETIME ToFileTime(object o)
					{
						if (o is DateTime dt)
							return dt.ToFileTimeStruct();
						if (o is FILETIME ft)
							return ft;
						return FileTimeExtensions.MakeFILETIME((ulong)Convert.ChangeType(o, typeof(ulong)));
					}
					Init(InitPropVariantFromFileTimeVector, ToFileTime);
					break;

				case VARTYPE.VT_CLSID:
					if (isVector)
						AllocVector(GetArray<Guid>(out sz), sz);
					else
						InitPropVariantFromCLSID(((Guid?)value).GetValueOrDefault(), this).ThrowIfFailed();
					break;

				case VARTYPE.VT_CF:
					if (isVector)
						AllocVector(GetArray<CLIPDATA>(out sz), sz);
					else
						_ptr = ((CLIPDATA)value!).MarshalToPtr(Marshal.AllocCoTaskMem, out var _);
					break;

				case VARTYPE.VT_BSTR:
					if (isVector)
						SetStringVector(ConvertToEnum<string>(value!), VarType);
					else
					{
						if (isRef)
							SetStruct<IntPtr>((IntPtr)value!, VarType);
						else
							_ptr = Marshal.StringToBSTR(value!.ToString());
					}
					break;

				case VARTYPE.VT_BLOB:
				case VARTYPE.VT_BLOB_OBJECT:
					if (!isVector && !isRef)
						_blob = (BLOB)value!;
					break;

				case VARTYPE.VT_LPSTR:
					if (isVector)
						SetStringVector(ConvertToEnum<string>(value!), VarType);
					else
						_ptr = Marshal.StringToCoTaskMemAnsi(value?.ToString());
					break;

				case VARTYPE.VT_LPWSTR:
					if (isVector)
						SetStringVector(ConvertToEnum<string>(value!), VarType);
					else
						_ptr = Marshal.StringToCoTaskMemUni(value?.ToString());
					break;

				case VARTYPE.VT_UNKNOWN:
					IntPtr ToIUnkPtr(object o) => o as IntPtr? ?? Marshal.GetIUnknownForObject(o);
					if (isVector)
						AllocVector(GetArray(out sz, ToIUnkPtr), sz);
					else
						SetStruct<IntPtr>(ToIUnkPtr(value!), VarType);
					break;

#if !(NETSTANDARD2_0)
				case VARTYPE.VT_DISPATCH:
					IntPtr ToIDispPtr(object o) => o as IntPtr? ?? Marshal.GetIDispatchForObject(o);
					if (isVector)
						AllocVector(GetArray(out sz, ToIDispPtr), sz);
					else
						SetStruct<IntPtr>(ToIDispPtr(value!), VarType);
					break;
#endif

				case VARTYPE.VT_STREAM:
				case VARTYPE.VT_STREAMED_OBJECT:
					if (!isVector && !isRef)
						SetStruct<IntPtr>(Marshal.GetComInterfaceForObject(value!, typeof(IStream)), VarType);
					break;

				case VARTYPE.VT_STORAGE:
				case VARTYPE.VT_STORED_OBJECT:
					if (!isVector && !isRef)
						SetStruct<IntPtr>(Marshal.GetComInterfaceForObject(value!, typeof(IStorage)), VarType);
					break;

				case VARTYPE.VT_DECIMAL:
					if (!isVector)
					{
						var tempVt = vt;
						_decimal = ((decimal?)value).GetValueOrDefault();
						vt = tempVt;
					}
					break;

				case VARTYPE.VT_VARIANT:
					if (isVector)
						AllocVector(GetArray(out sz, o => { ((PROPVARIANT)o).Clone(out var oo); return oo; }), sz);
					else if (isRef)
						InitPropVariantVectorFromPropVariant((PROPVARIANT)value!, this);
					break;

				case VARTYPE.VT_USERDEFINED:
				case VARTYPE.VT_RECORD:
				case VARTYPE.VT_VOID:
				case VARTYPE.VT_PTR:
				default:
					throw new ArgumentOutOfRangeException(nameof(Value), $"{vt}={value}");
			}

			HRESULT AllocVector<T>(T[] vector, uint vsz, PROPVARIANT? pv = null)
			{
				_blob.cbSize = vsz;
				_blob.pBlobData = vector.MarshalToPtr<T>(global::System.Runtime.InteropServices.Marshal.AllocCoTaskMem, out var _);
				return HRESULT.S_OK;
			}

			T[] GetArray<T>(out uint len, Func<object, T>? conv = null)
			{
				var ret = ConvertToEnum<T>(value!, conv).ToArray();
				len = (uint)ret.Length;
				return ret;
			}

			void Init<T>(Func<T[], uint, PROPVARIANT, HRESULT> init, Func<object, T>? conv = null) where T : struct
			{
				if (isVector)
					init(GetArray<T>(out sz, conv), sz, this).ThrowIfFailed();
				else
					SetStruct((T?)(conv?.Invoke(value!) ?? value), VarType);
			}
		}
	}

	/// <summary>
	/// The PROPVARIANT structure is used in the ReadMultiple and WriteMultiple methods of IPropertyStorage to define the type tag and
	/// the value of a property in a property set.
	/// <para>
	/// The PROPVARIANT structure is also used by the GetValue and SetValue methods of IPropertyStore, which replaces
	/// IPropertySetStorage as the primary way to program item properties in Windows Vista. For more information, see Property Handlers.
	/// </para>
	/// <para>
	/// There are five members. The first member, the value-type tag, and the last member, the value of the property, are significant.
	/// The middle three members are reserved for future use.
	/// </para>
	/// <note>This structure is mostly used for arrays where the fixed structure size is critical for interop.</note>
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct PROPVARIANT_IMMUTABLE
	{
		/// <summary>Value type tag.</summary>
		public VARTYPE vt;

		/// <summary>Reserved for future use.</summary>
		private ushort wReserved1;

		/// <summary>Reserved for future use.</summary>
		private ushort wReserved2;

		/// <summary>Reserved for future use.</summary>
		private ushort wReserved3;

		/// <summary>The BLOB when VT_BLOB</summary>
		private BLOB _blob;

		/// <summary>Performs an implicit conversion from <see cref="PROPVARIANT"/> to <see cref="PROPVARIANT_IMMUTABLE"/>.</summary>
		/// <param name="pv">The PROPVARIANT instance.</param>
		/// <returns>The resulting <see cref="PROPVARIANT_IMMUTABLE"/> instance from the conversion.</returns>
		public static implicit operator PROPVARIANT_IMMUTABLE(PROPVARIANT pv) => new() { vt = pv.vt, wReserved1 = pv.wReserved1, wReserved2 = pv.wReserved2, wReserved3 = pv.wReserved3, _blob = pv._blob };

		/// <summary>Performs an implicit conversion from <see cref="PROPVARIANT_IMMUTABLE"/> to <see cref="PROPVARIANT"/>.</summary>
		/// <param name="pv">The PROPVARIANT_IMMUTABLE instance.</param>
		/// <returns>The resulting <see cref="PROPVARIANT"/> instance from the conversion.</returns>
		public static explicit operator PROPVARIANT(in PROPVARIANT_IMMUTABLE pv) => new() { vt = pv.vt, wReserved1 = pv.wReserved1, wReserved2 = pv.wReserved2, wReserved3 = pv.wReserved3, _blob = pv._blob };
	}
}