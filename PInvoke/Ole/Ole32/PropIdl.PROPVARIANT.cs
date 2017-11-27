using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.OleAut32;
using static Vanara.PInvoke.PropSys;
using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;

// ReSharper disable InconsistentNaming ReSharper disable FieldCanBeMadeReadOnly.Global ReSharper disable BitwiseOperatorOnEnumWithoutFlags

namespace Vanara.PInvoke
{
	/// <summary></summary>
	public static partial class Ole32
	{
		/// <summary>
		/// Structure to mimic behavior of VT_BLOB type. "DWORD count of bytes, followed by that many bytes of data. The byte count does not include the four
		/// bytes for the length of the count itself; an empty blob member would have a count of zero, followed by zero bytes."
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
			/// <param name="dataLength">Length of the data in bytes. Do not include any length other than that pointed to by <paramref name="dataPtr"/>.</param>
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

			public uint ClipboardFormat => ulClipFmt == -1 || ulClipFmt == -2 ? (uint)Marshal.ReadInt32(pClipData) : 0;

			public string ClipboardFormatName => ulClipFmt > 0 ? Marshal.PtrToStringUni(pClipData) : null;

			public Guid FMTID => ulClipFmt == -3 ? pClipData.ToStructure<Guid>() : Guid.Empty;

			public override string ToString()
			{
				switch (ulClipFmt)
				{
					case 0:
						return "[No data]";
					case -1:
					case -2:
						return $"CF={ClipboardFormat}";
					case -3:
						return $"FMTID={FMTID:B}";
					default:
						return $"Name={ClipboardFormatName}";
				}
			}
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
		/// The PROPVARIANT structure is used in the ReadMultiple and WriteMultiple methods of IPropertyStorage to define the type tag and the value of a
		/// property in a property set.
		/// <para>
		/// The PROPVARIANT structure is also used by the GetValue and SetValue methods of IPropertyStore, which replaces IPropertySetStorage as the primary way
		/// to program item properties in Windows Vista. For more information, see Property Handlers.
		/// </para>
		/// <para>
		/// There are five members. The first member, the value-type tag, and the last member, the value of the property, are significant. The middle three
		/// members are reserved for future use.
		/// </para>
		/// </summary>
		[StructLayout(LayoutKind.Explicit, Size = 16, Pack = 8)]
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
			public PROPVARIANT(object obj, VarEnum type = VarEnum.VT_EMPTY)
			{
				if (obj == null)
					VarType = type;
				else
					SetValue(obj, type);
			}

			/// <summary>Initializes a new instance of the <see cref="PROPVARIANT"/> class from another <c>PROPVARIANT</c>.</summary>
			/// <param name="sourceVar">An existing <see cref="PROPVARIANT"/> instance.</param>
			public PROPVARIANT(PROPVARIANT sourceVar)
			{
				PropVariantCopy(this, sourceVar);
			}

			/// <summary>Gets the BLOB value.</summary>
			public BLOB blob => GetRawValue<BLOB>().GetValueOrDefault();

			/// <summary>Gets the boolean value.</summary>
			public bool boolVal => GetRawValue<bool>().GetValueOrDefault();

			/// <summary>Gets the BSTR value.</summary>
			public string bstrVal => GetString(VarType);

			/// <summary>Gets the byte value.</summary>
			public byte bVal => GetRawValue<byte>().GetValueOrDefault();

			/// <summary>Gets the boolean array value.</summary>
			public IEnumerable<bool> cabool => GetVector<short>().Select(s => s != 0);

			/// <summary>Gets the string array value.</summary>
			public IEnumerable<string> cabstr => GetStringVector();

			/// <summary>Gets the sbyte array value.</summary>
			public IEnumerable<sbyte> cac => GetVector<sbyte>();

			/// <summary>Gets the CLIPDATA array value.</summary>
			public IEnumerable<CLIPDATA> caclipdata => GetVector<CLIPDATA>();

			/// <summary>Gets the decimal array value.</summary>
			public IEnumerable<decimal> cacy
			{
				get
				{
					foreach (var s in GetVector<long>())
						yield return decimal.FromOACurrency(s);
				}
			}

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
			public IEnumerable<string> calpstr => GetStringVector();

			/// <summary>Gets the Unicode string array value.</summary>
			public IEnumerable<string> calpwstr => GetStringVector();

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

			/// <summary>Gets the short value.</summary>
			public short iVal => GetRawValue<short>().GetValueOrDefault();

			/// <summary>Gets the int value.</summary>
			public int lVal => GetRawValue<int>().GetValueOrDefault();

			/// <summary>Gets the array of objects.</summary>
			public IEnumerable<object> parray => GetSafeArray();

			/// <summary>Gets the "by value" boolean value.</summary>
			public bool? pboolVal => GetRawValue<bool>();

			/// <summary>Gets the "by value" string value.</summary>
			public string pbstrVal => GetString(VarType);

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
					return d.HasValue ? decimal.FromOACurrency(d.Value) : (decimal?)null;
				}
			}

			/// <summary>Gets the "by value" DateTime value.</summary>
			public DateTime? pdate
			{
				get
				{
					var d = GetRawValue<double>();
					return d.HasValue ? DateTime.FromOADate(d.Value) : (DateTime?)null;
				}
			}

			/// <summary>Gets the "by value" double value.</summary>
			public double? pdblVal => GetRawValue<double>();

			/// <summary>Gets the "by value" decimal value.</summary>
			public decimal? pdecVal => GetRawValue<decimal>();

			/// <summary>Gets the "by value" pointer value.</summary>
			public object pdispVal => punkVal;

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
					var r = GetRawValue<int>();
					return r.HasValue ? new Win32Error(r.Value) : (Win32Error?)null;
				}
			}

			/// <summary>Gets the IStorage value.</summary>
			public IStorage pStorage => (IStorage)punkVal;

			/// <summary>Gets the IStream value.</summary>
			public IStream pStream => (IStream)punkVal;

			/// <summary>Gets the ANSI string value.</summary>
			public string pszVal => GetString(VarType);

			/// <summary>Gets the "by value" uint value.</summary>
			public uint? puintVal => GetRawValue<uint>();

			/// <summary>Gets the "by value" ushort value.</summary>
			public ushort? puiVal => GetRawValue<ushort>();

			/// <summary>Gets the "by value" uint value.</summary>
			public uint? pulVal => GetRawValue<uint>();

			/// <summary>Gets the "by value" IUnknown value.</summary>
			public object punkVal => _ptr == IntPtr.Zero ? null : Marshal.GetObjectForIUnknown(_ptr);

			/// <summary>Gets the "by value" Guid value.</summary>
			public Guid? puuid => GetRawValue<Guid>();

			/// <summary>Gets the "by value" PROPVARIANT value.</summary>
			public PROPVARIANT pvarVal => _ptr.ToStructure<PROPVARIANT>();

			/// <summary>Gets a stream with a Guid version.</summary>
			public IntPtr pVersionedStream => GetRawValue<IntPtr>().GetValueOrDefault();

			/// <summary>Gets the Unicode string value.</summary>
			public string pwszVal => GetString(VarType);

			/// <summary>Gets the Win32Error value.</summary>
			public Win32Error scode => new Win32Error(GetRawValue<int>().GetValueOrDefault());

			/// <summary>Gets the ulong value.</summary>
			public ulong uhVal => GetRawValue<ulong>().GetValueOrDefault();

			/// <summary>Gets the uint value.</summary>
			public uint uintVal => GetRawValue<uint>().GetValueOrDefault();

			/// <summary>Gets the ushort value.</summary>
			public ushort uiVal => GetRawValue<ushort>().GetValueOrDefault();

			/// <summary>Gets the uint value.</summary>
			public uint ulVal => GetRawValue<uint>().GetValueOrDefault();

			//public IntPtr pparray { get { return GetRefValue<sbyte>(); } }

			/// <summary>Gets a value indicating whether this instance is null or empty.</summary>
			/// <value><c>true</c> if this instance is null or empty; otherwise, <c>false</c>.</value>
			public bool IsNullOrEmpty => vt == VARTYPE.VT_EMPTY || vt == VARTYPE.VT_NULL;

			/// <summary>Gets a value indicating whether this instance is a string.</summary>
			/// <value><c>true</c> if this instance is a VT_BSTR or VT_LPWSTR; otherwise, <c>false</c>.</value>
			public bool IsString => vt == VARTYPE.VT_BSTR || vt == VARTYPE.VT_LPWSTR;

			/// <summary>Gets a value indicating whether this instance has a vector type.</summary>
			/// <value><c>true</c> if this instance is a VT_ARRAY or VT_VECTOR; otherwise, <c>false</c>.</value>
			public bool IsVector => vt.IsFlagSet(VARTYPE.VT_ARRAY) || vt.IsFlagSet(VARTYPE.VT_VECTOR);

			/// <summary>Gets the value base on the <see cref="vt"/> value.</summary>
			public object Value
			{
				get
				{
					if (vt.IsFlagSet(VARTYPE.VT_ARRAY)) return GetSafeArray();
					var isVector = vt.IsFlagSet(VARTYPE.VT_VECTOR);
					var isRef = vt.IsFlagSet(VARTYPE.VT_BYREF);
					var elemType = (VARTYPE)((int)vt & 0xFFF);
					switch (elemType)
					{
						case VARTYPE.VT_NULL:
							return DBNull.Value;

						case VARTYPE.VT_I2:
							return isRef ? piVal : (isVector ? cai : (object)iVal);

						case VARTYPE.VT_INT:
						case VARTYPE.VT_I4:
							return isRef ? plVal : (isVector ? cal : (object)lVal);

						case VARTYPE.VT_BSTR:
							return isRef ? pbstrVal : (isVector ? cabstr : (object)bstrVal);

						case VARTYPE.VT_DISPATCH:
						case VARTYPE.VT_UNKNOWN:
							return isVector ? GetVector<IntPtr>()?.Select(Marshal.GetObjectForIUnknown) : (isRef ? ppunkVal : punkVal);

						case VARTYPE.VT_BOOL:
							return isRef ? pboolVal : (isVector ? cabool : (object)boolVal);

						case VARTYPE.VT_I1:
							return isRef ? pcVal : (isVector ? cac : (object)cVal);

						case VARTYPE.VT_UI1:
							return isRef ? pbVal : (isVector ? caub : (object)bVal);

						case VARTYPE.VT_UI2:
							return isRef ? puiVal : (isVector ? caui : (object)uiVal);

						case VARTYPE.VT_UINT:
						case VARTYPE.VT_UI4:
							return isRef ? pulVal : (isVector ? caul : (object)ulVal);

						case VARTYPE.VT_ERROR:
							return isRef ? pscode : (isVector ? cascode : (object)scode);

						case VARTYPE.VT_I8:
							return isRef ? hVal : (isVector ? cah : (object)hVal);

						case VARTYPE.VT_UI8:
							return isRef ? uhVal : (isVector ? cauh : (object)uhVal);

						case VARTYPE.VT_HRESULT:
							return isRef
								? (pulVal.HasValue ? new HRESULT(pulVal.Value) : (HRESULT?)null)
								: (isVector ? caul.Select(u => new HRESULT(u)) : (object)new HRESULT(ulVal));

						case VARTYPE.VT_PTR:
						case VARTYPE.VT_RECORD:
						case VARTYPE.VT_USERDEFINED:
						case VARTYPE.VT_VOID:
							return isRef ? IntPtr.Zero : (isVector ? GetVector<IntPtr>() : (object)_ptr);

						case VARTYPE.VT_LPSTR:
							return isRef ? pszVal : (isVector ? calpstr : (object)pszVal);

						case VARTYPE.VT_LPWSTR:
							return isRef ? pwszVal : (isVector ? calpwstr : (object)pwszVal);

						case VARTYPE.VT_R8:
							return isRef ? dblVal : (isVector ? cadbl : (object)dblVal);

						case VARTYPE.VT_DATE:
							return isRef ? pdate : (isVector ? cadate : (object)date);

						case VARTYPE.VT_CY:
							return isRef ? pcyVal : (isVector ? cacy : (object)cyVal);

						case VARTYPE.VT_DECIMAL:
							return isRef ? pdecVal : (isVector ? GetVector<decimal>() : (object)pdecVal.GetValueOrDefault());

						case VARTYPE.VT_R4:
							return isRef ? pfltVal : (isVector ? caflt : (object)fltVal);

						case VARTYPE.VT_FILETIME:
							return isRef ? filetime : (isVector ? cafiletime : (object)filetime);

						case VARTYPE.VT_BLOB:
							return isRef ? _blob : (isVector ? null : (object)_blob);

						case VARTYPE.VT_STREAM:
						case VARTYPE.VT_STREAMED_OBJECT:
							return isRef ? pStream : (isVector ? null : pStream);

						case VARTYPE.VT_STORAGE:
						case VARTYPE.VT_STORED_OBJECT:
							return isRef ? pStorage : (isVector ? null : pStorage);

						case VARTYPE.VT_CF:
							return isRef ? pclipdata : (isVector ? caclipdata : (object)pclipdata);

						case VARTYPE.VT_CLSID:
							return isRef ? puuid : (isVector ? cauuid : (object)puuid.GetValueOrDefault());

						case VARTYPE.VT_VARIANT:
							return isRef ? pvarVal : (isVector ? GetVector<PROPVARIANT>() : (object)pvarVal);

						default:
							return null;
					}
				}
				private set => SetValue(value);
			}

			/// <summary>Gets or sets the type of the variable.</summary>
			/// <value>The value type.</value>
			public VarEnum VarType { get => (VarEnum)vt; set => vt = (VARTYPE)value; }

			/// <summary>Gets the VARTYPE for a provided type.</summary>
			/// <param name="type">The type to analyze.</param>
			/// <returns>A best fit <see cref="VARTYPE"/> for the provided type.</returns>
			public static VARTYPE GetVarType(Type type)
			{
				if (type == null)
					return VARTYPE.VT_NULL;
				var elemtype = type.GetElementType() ?? type;

				if (type.IsArray && elemtype == typeof(object)) return VARTYPE.VT_ARRAY | VARTYPE.VT_VARIANT;

				var ret = type.IsArray || type != typeof(string) && typeof(IEnumerable).IsAssignableFrom(type) ? VARTYPE.VT_VECTOR : 0;
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
					var intf = elemtype.GetInterfaces();
					if (intf.Contains(typeof(IStream))) return ret | VARTYPE.VT_STREAM;
					if (intf.Contains(typeof(IStorage))) return ret | VARTYPE.VT_STORAGE;
					return ret | VARTYPE.VT_UNKNOWN;
				}
				if (elemtype == typeof(IntPtr))
					return VARTYPE.VT_PTR;
				switch (Type.GetTypeCode(elemtype))
				{
					case TypeCode.DBNull:
						return ret | VARTYPE.VT_NULL;

					case TypeCode.Boolean:
						return ret | VARTYPE.VT_BOOL;

					case TypeCode.Char:
						return ret | VARTYPE.VT_LPWSTR;

					case TypeCode.SByte:
						return ret | VARTYPE.VT_I1;

					case TypeCode.Byte:
						return ret | VARTYPE.VT_UI1;

					case TypeCode.Int16:
						return ret | VARTYPE.VT_I2;

					case TypeCode.UInt16:
						return ret | VARTYPE.VT_UI2;

					case TypeCode.Int32:
						return ret | VARTYPE.VT_I4;

					case TypeCode.UInt32:
						return ret | VARTYPE.VT_UI4;

					case TypeCode.Int64:
						return ret | VARTYPE.VT_I8;

					case TypeCode.UInt64:
						return ret | VARTYPE.VT_UI8;

					case TypeCode.Single:
						return ret | VARTYPE.VT_R4;

					case TypeCode.Double:
						return ret | VARTYPE.VT_R8;

					case TypeCode.Decimal:
						return type.IsArray ? VARTYPE.VT_VECTOR | VARTYPE.VT_DECIMAL : VARTYPE.VT_DECIMAL | VARTYPE.VT_BYREF;

					case TypeCode.DateTime:
						return ret | VARTYPE.VT_DATE;

					case TypeCode.String:
						return ret | VARTYPE.VT_LPWSTR;
				}
				return ret | VARTYPE.VT_USERDEFINED;
			}

			/// <summary>
			/// Frees all elements that can be freed in this instance. For complex elements with known element pointers, the underlying elements are freed prior
			/// to freeing the containing element.
			/// </summary>
			[SecurityCritical, SecuritySafeCritical]
			public void Clear()
			{
				PropVariantClear(this);
			}

			/// <summary>Copies the contents of one PROPVARIANT structure to another.</summary>
			/// <param name="clone">The cloned copy.</param>
			public void Clone(out PROPVARIANT clone)
			{
				clone = new PROPVARIANT();
				PropVariantCopy(clone, this);
			}

			/// <summary>Creates a new object that is a copy of the current instance.</summary>
			/// <returns>A new object that is a copy of this instance.</returns>
			object ICloneable.Clone()
			{
				Clone(out PROPVARIANT pv);
				return pv;
			}

			/// <summary>
			/// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes,
			/// follows, or occurs in the same position in the sort order as the other object.
			/// </summary>
			/// <param name="other">An object to compare with this instance.</param>
			/// <returns>
			/// A value that indicates the relative order of the objects being compared. The return value has these meanings: Value Meaning Less than zero This
			/// instance precedes <paramref name="other"/> in the sort order. Zero This instance occurs in the same position in the sort order as <paramref
			/// name="other"/>. Greater than zero This instance follows <paramref name="other"/> in the sort order.
			/// </returns>
			public int CompareTo(object other)
			{
				var v = Value;
				if (other == null) return v == null ? 0 : 1;
				if (other is PROPVARIANT pv) return PropVariantCompare(this, pv);
				if (v == null) return -1;
				var pvDest = new PROPVARIANT();
				if (PropVariantChangeType(pvDest, this, PROPVAR_CHANGE_FLAGS.PVCHF_DEFAULT, GetVarType(other.GetType())).Succeeded)
					return PropVariantCompare(this, pvDest);
				throw new ArgumentException(@"Unable to compare supplied object to PROPVARIANT.", nameof(other));
			}

			/// <summary>Compares the current object with another object of the same type.</summary>
			/// <param name="other">An object to compare with this object.</param>
			/// <returns>
			/// A 32-bit signed integer that indicates the relative order of the objects being compared. The return value has the following meanings: Value
			/// Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal to <paramref name="other"/>.
			/// Greater than zero This object is greater than <paramref name="other"/>.
			/// </returns>
			int IComparable<PROPVARIANT>.CompareTo(PROPVARIANT other) => CompareTo(other);

			/// <summary>Determines whether the specified <see cref="object"/>, is equal to this instance.</summary>
			/// <param name="obj">The <see cref="object"/> to compare with this instance.</param>
			/// <returns><c>true</c> if the specified <see cref="object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
			public override bool Equals(object obj)
			{
				var pv = obj as PROPVARIANT;
				return pv != null ? Equals(pv.Value) : obj == this;
			}

			/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
			/// <param name="other">An object to compare with this object.</param>
			/// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
			public bool Equals(PROPVARIANT other) => CompareTo(other) == 0;

			/// <summary>Creates a new <see cref="PROPVARIANT"/> instance from a pointer to a VARIANT.</summary>
			/// <param name="pSrcNativeVariant">A pointer to a native in-memory VARIANT.</param>
			/// <returns>A new <see cref="PROPVARIANT"/> instance converted from the VARIANT pointer.</returns>
			public static PROPVARIANT FromNativeVariant(IntPtr pSrcNativeVariant)
			{
				var pv = new PROPVARIANT();
				VariantToPropVariant(pSrcNativeVariant, pv).ThrowIfFailed();
				return pv;
			}

			/// <summary>Returns a hash code for this instance.</summary>
			/// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
			public override int GetHashCode() => vt.GetHashCode();

			/// <summary>Sets the value, clearing any existing value.</summary>
			/// <param name="value">The value.</param>
			/// <param name="vEnum">If this value equals VT_EMPTY, the method will attempt to ascertain the value type from the <paramref name="value"/>.</param>
			private void SetValue(object value, VarEnum vEnum = VarEnum.VT_EMPTY)
			{
				Clear();
				vt = vEnum == VarEnum.VT_EMPTY ? GetVarType(value?.GetType()) : (VARTYPE)vEnum;

				// Finished if NULL or EMPTY
				if ((int)vt <= 1) return;

				// Handle SAFEARRAY
				if (vt.IsFlagSet(VARTYPE.VT_ARRAY))
				{
					SetSafeArray((object[])value);
					return;
				}

				// Handle BYREF null value
				if (vt.IsFlagSet(VARTYPE.VT_BYREF) && value == null)
					return;

				// Handle case where element type is put in w/o specifying VECTOR
				if (value != null && !vt.IsFlagSet(VARTYPE.VT_VECTOR) && value.GetType().IsArray) vt |= VARTYPE.VT_VECTOR;

				switch (vt)
				{
					case VARTYPE.VT_I1:
					case VARTYPE.VT_BYREF | VARTYPE.VT_I1:
						SetStruct((sbyte?)value, VarType);
						break;

					case VARTYPE.VT_UI1:
					case VARTYPE.VT_BYREF | VARTYPE.VT_UI1:
						SetStruct((byte?)value, VarType);
						break;

					case VARTYPE.VT_I2:
					case VARTYPE.VT_BYREF | VARTYPE.VT_I2:
						SetStruct((short?)value, VarType);
						break;

					case VARTYPE.VT_UI2:
					case VARTYPE.VT_BYREF | VARTYPE.VT_UI2:
						SetStruct((ushort?)value, VarType);
						break;

					case VARTYPE.VT_I4:
					case VARTYPE.VT_INT:
					case VARTYPE.VT_BYREF | VARTYPE.VT_I4:
					case VARTYPE.VT_BYREF | VARTYPE.VT_INT:
						SetStruct((int?)value, VarType);
						break;

					case VARTYPE.VT_UI4:
					case VARTYPE.VT_UINT:
					case VARTYPE.VT_BYREF | VARTYPE.VT_UI4:
					case VARTYPE.VT_BYREF | VARTYPE.VT_UINT:
						SetStruct((uint?)value, VarType);
						break;

					case VARTYPE.VT_I8:
					case VARTYPE.VT_BYREF | VARTYPE.VT_I8:
						SetStruct((long?)value, VarType);
						break;

					case VARTYPE.VT_UI8:
					case VARTYPE.VT_BYREF | VARTYPE.VT_UI8:
						SetStruct((ulong?)value, VarType);
						break;

					case VARTYPE.VT_R4:
					case VARTYPE.VT_BYREF | VARTYPE.VT_R4:
						SetStruct((float?)value, VarType);
						break;

					case VARTYPE.VT_R8:
					case VARTYPE.VT_BYREF | VARTYPE.VT_R8:
						SetStruct((double?)value, VarType);
						break;

					case VARTYPE.VT_BOOL:
					case VARTYPE.VT_BYREF | VARTYPE.VT_BOOL:
						SetStruct((bool?)value, VarType);
						break;

					case VARTYPE.VT_ERROR:
					case VARTYPE.VT_BYREF | VARTYPE.VT_ERROR:
						{
							uint? i;
							if (value is Win32Error)
								i = (uint?)(int)(Win32Error)value;
							else
								i = (uint)Convert.ChangeType(value, typeof(uint));
							SetStruct(i, VarType);
						}
						break;

					case VARTYPE.VT_HRESULT:
					case VARTYPE.VT_BYREF | VARTYPE.VT_HRESULT:
						{
							uint? i;
							if (value is HRESULT)
								i = (uint?)(int)(HRESULT)value;
							else
								i = (uint)Convert.ChangeType(value, typeof(uint));
							SetStruct(i, VarType);
						}
						break;

					case VARTYPE.VT_CY:
					case VARTYPE.VT_BYREF | VARTYPE.VT_CY:
						{
							ulong? i;
							if (value is decimal)
								i = (ulong?)decimal.ToOACurrency((decimal)value);
							else
								i = (ulong)Convert.ChangeType(value, typeof(ulong));
							SetStruct(i, VarType);
						}
						break;

					case VARTYPE.VT_DATE:
					case VARTYPE.VT_BYREF | VARTYPE.VT_DATE:
						{
							double? d = null;
							var dt = value as DateTime?;
							if (dt != null)
								d = dt.Value.ToOADate();
							var ft = value as FILETIME?;
							if (ft != null)
								d = ft.Value.ToDateTime().ToOADate();
							if (d == null)
								d = (double)Convert.ChangeType(value, typeof(double));
							SetStruct(d, VarType);
						}
						break;

					case VARTYPE.VT_FILETIME:
						{
							FILETIME? ft;
							var dt = value as DateTime?;
							if (dt != null)
								ft = dt.Value.ToFileTimeStruct();
							else
								ft = value as FILETIME? ?? FileTimeExtensions.MakeFILETIME((ulong)Convert.ChangeType(value, typeof(ulong)));
							_ft = ft.GetValueOrDefault();
						}
						break;

					case VARTYPE.VT_CLSID:
						SetStruct((Guid?)value, VarType);
						break;

					case VARTYPE.VT_CF:
						SetStruct((CLIPDATA?)value, VarType);
						break;

					case VARTYPE.VT_BLOB:
					case VARTYPE.VT_BLOB_OBJECT:
						_blob = (BLOB)value;
						break;

					case VARTYPE.VT_BSTR:
					case VARTYPE.VT_BYREF | VARTYPE.VT_BSTR:
						if (value is IntPtr)
							SetStruct((IntPtr?)value, VarType);
						else
							SetString(value?.ToString(), VarType);
						break;

					case VARTYPE.VT_LPSTR:
					case VARTYPE.VT_LPWSTR:
						SetString(value?.ToString(), VarType);
						break;

					case VARTYPE.VT_UNKNOWN:
						{
							var p = value as IntPtr? ?? Marshal.GetIUnknownForObject(value);
							SetStruct<IntPtr>(p, VarType);
						}
						break;

#if !(NETSTANDARD2_0)
					case VARTYPE.VT_DISPATCH:
						{
							var p = value as IntPtr? ?? Marshal.GetIDispatchForObject(value);
							SetStruct<IntPtr>(p, VarType);
						}
						break;
#endif

					case VARTYPE.VT_STREAM:
					case VARTYPE.VT_STREAMED_OBJECT:
						SetStruct<IntPtr>(Marshal.GetComInterfaceForObject(value, typeof(IStream)), VarType);
						break;

					case VARTYPE.VT_STORAGE:
					case VARTYPE.VT_STORED_OBJECT:
						SetStruct<IntPtr>(Marshal.GetComInterfaceForObject(value, typeof(IStorage)), VarType);
						break;

					case VARTYPE.VT_VECTOR | VARTYPE.VT_I1:
						SetVector(ConvertToEnum<sbyte>(value), VarType);
						break;

					case VARTYPE.VT_VECTOR | VARTYPE.VT_UI1:
						SetVector(ConvertToEnum<byte>(value), VarType);
						break;

					case VARTYPE.VT_VECTOR | VARTYPE.VT_I2:
						SetVector(ConvertToEnum<short>(value), VarType);
						break;

					case VARTYPE.VT_VECTOR | VARTYPE.VT_UI2:
						SetVector(ConvertToEnum<ushort>(value), VarType);
						break;

					case VARTYPE.VT_VECTOR | VARTYPE.VT_I4:
					case VARTYPE.VT_VECTOR | VARTYPE.VT_INT:
						SetVector(ConvertToEnum<int>(value), VarType);
						break;

					case VARTYPE.VT_VECTOR | VARTYPE.VT_UI4:
					case VARTYPE.VT_VECTOR | VARTYPE.VT_UINT:
						SetVector(ConvertToEnum<uint>(value), VarType);
						break;

					case VARTYPE.VT_VECTOR | VARTYPE.VT_I8:
						SetVector(ConvertToEnum<long>(value), VarType);
						break;

					case VARTYPE.VT_VECTOR | VARTYPE.VT_UI8:
						SetVector(ConvertToEnum<ulong>(value), VarType);
						break;

					case VARTYPE.VT_VECTOR | VARTYPE.VT_R4:
						SetVector(ConvertToEnum<float>(value), VarType);
						break;

					case VARTYPE.VT_VECTOR | VARTYPE.VT_R8:
						SetVector(ConvertToEnum<double>(value), VarType);
						break;

					case VARTYPE.VT_VECTOR | VARTYPE.VT_BOOL:
						SetVector(ConvertToEnum<bool>(value).Select(b => (ushort)(b ? -1 : 0)), VarType);
						break;

					case VARTYPE.VT_VECTOR | VARTYPE.VT_ERROR:
						{
							var ee = (value as IEnumerable<Win32Error>)?.Select(w => (uint)(int)w) ?? ConvertToEnum<uint>(value);
							SetVector(ee, VarType);
						}
						break;

					case VARTYPE.VT_VECTOR | VARTYPE.VT_HRESULT:
						{
							var ee = (value as IEnumerable<HRESULT>)?.Select(w => (uint)(int)w) ?? ConvertToEnum<uint>(value);
							SetVector(ee, VarType);
						}
						break;

					case VARTYPE.VT_VECTOR | VARTYPE.VT_CY:
						{
							var ecy = (value as IEnumerable<decimal>)?.Select(d => (ulong)decimal.ToOACurrency(d)) ??
									  ConvertToEnum<ulong>(value);
							SetVector(ecy, VarType);
						}
						break;

					case VARTYPE.VT_VECTOR | VARTYPE.VT_DATE:
						{
							var ed = (value as IEnumerable<DateTime>)?.Select(d => d.ToOADate()) ??
									 (value as IEnumerable<FILETIME>)?.Select(ft => ft.ToDateTime().ToOADate()) ??
									 ConvertToEnum<double>(value);
							SetVector(ed, VarType);
						}
						break;

					case VARTYPE.VT_VECTOR | VARTYPE.VT_FILETIME:
						{
							var ed = value as IEnumerable<FILETIME> ??
									 (value as IEnumerable<DateTime>)?.Select(d => d.ToFileTimeStruct()) ??
									 ConvertToEnum<ulong>(value)?.Select(FileTimeExtensions.MakeFILETIME);
							SetVector(ed, VarType);
						}
						break;

					case VARTYPE.VT_VECTOR | VARTYPE.VT_CLSID:
						SetVector(ConvertToEnum<Guid>(value), VarType);
						break;

					case VARTYPE.VT_VECTOR | VARTYPE.VT_CF:
						SetVector(ConvertToEnum<CLIPDATA>(value), VarType);
						break;

					case VARTYPE.VT_VECTOR | VARTYPE.VT_BSTR:
						{
							var ep = value as IEnumerable<IntPtr>;
							if (ep != null)
								SetVector(ep, VarType);
							else
								SetStringVector(ConvertToEnum<string>(value), VarType);
						}
						break;

					case VARTYPE.VT_VECTOR | VARTYPE.VT_LPSTR:
					case VARTYPE.VT_VECTOR | VARTYPE.VT_LPWSTR:
						SetStringVector(ConvertToEnum<string>(value), VarType);
						break;

					case VARTYPE.VT_VECTOR | VARTYPE.VT_VARIANT:
						SetVector(ConvertToEnum<PROPVARIANT>(value), VarType);
						break;

					case VARTYPE.VT_VECTOR | VARTYPE.VT_DECIMAL:
						SetVector(ConvertToEnum<decimal>(value), VarType);
						break;

					case VARTYPE.VT_BYREF | VARTYPE.VT_DECIMAL:
						SetDecimal((decimal?)value);
						break;

					case VARTYPE.VT_BYREF | VARTYPE.VT_VARIANT:
						// TODO: Fix this so that it uses the system call in hopes that PropVarClear will actually release the memory.
						_ptr = this.StructureToPtr(Marshal.AllocCoTaskMem, out int _);
						break;

					case VARTYPE.VT_VOID:
					case VARTYPE.VT_PTR:
					case VARTYPE.VT_USERDEFINED:
					case VARTYPE.VT_RECORD:
					case VARTYPE.VT_BYREF | VARTYPE.VT_UNKNOWN:
					case VARTYPE.VT_BYREF | VARTYPE.VT_DISPATCH:
						_ptr = (IntPtr)value;
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}
			}

			/// <summary>Returns a <see cref="string"/> that represents this instance.</summary>
			/// <returns>A <see cref="string"/> that represents this instance.</returns>
			public override string ToString()
			{
				string s = null;
				if (PropVariantToStringAlloc(this, out SafeCoTaskMemString str).Succeeded)
					s = str;
				return $"{vt}={s ?? "null"}";
			}

			private static IEnumerable<T> ConvertToEnum<T>(object array, Func<object, T> conv = null)
			{
				if (array == null) return null;

				if (array is IEnumerable<T> iet) return iet;

				if (conv == null) conv = o => (T)Convert.ChangeType(o, typeof(T));
				try
				{
					var ie = array as IEnumerable;
					return ie?.Cast<object>().Select(conv) ?? new[] {conv(array)};
				}
				catch
				{
					return null;
				}
			}

			private static string GetString(VarEnum ve, IntPtr ptr)
			{
				switch ((VARTYPE)ve)
				{
					case VARTYPE.VT_LPSTR:
						return Marshal.PtrToStringAnsi(ptr);
					case VARTYPE.VT_LPWSTR:
						return Marshal.PtrToStringUni(ptr);
					default:
						return Marshal.PtrToStringBSTR(ptr);
				}
			}

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
							return (T)Marshal.PtrToStructure(new IntPtr(dataPtr), typeof(T));
						}
					}
				}
				if (type == typeof(FILETIME)) return (T)(object)_ft;
				if (type == typeof(BLOB)) return (T)(object)_blob;
				if (type == typeof(decimal)) return (T)(object)_decimal;
				return _ptr.ToNullableStructure<T>();
			}

			private IEnumerable<object> GetSafeArray()
			{
				if (_ptr == IntPtr.Zero) return null;
				var dims = SafeArrayGetDim(_ptr);
				if (dims != 1) throw new NotSupportedException("Only single-dimensional arrays are supported");
				SafeArrayGetLBound(_ptr, 1U, out int lBound);
				SafeArrayGetUBound(_ptr, 1U, out int uBound);
				var elemSz = SafeArrayGetElemsize(_ptr);
				if (elemSz == 0) throw new Win32Exception();
				using (var d = new SafeArrayScopedAccessData(_ptr))
					return Marshal.GetObjectsForNativeVariants(d.Data, uBound - lBound + 1);
			}

			private string GetString(VarEnum ve) => GetString(ve, _ptr);

			private IntPtr GetStringPtr(string value, VarEnum ve)
			{
				if (value == null) return IntPtr.Zero;
				var ive = (VARTYPE)ve;
				if (ive == VARTYPE.VT_LPSTR)
					return Marshal.StringToCoTaskMemAnsi(value);
				if (ive == VARTYPE.VT_LPWSTR)
					return Marshal.StringToCoTaskMemUni(value);
				if (ive.IsFlagSet(VARTYPE.VT_BSTR))
					return Marshal.StringToBSTR(value);
				throw new ArgumentOutOfRangeException(nameof(ve));
			}

			private IEnumerable<string> GetStringVector()
			{
				var ve = (VarEnum)((int)vt & 0x0FFF);
				return _blob.pBlobData.ToIEnum<IntPtr>((int)_blob.cbSize).Select(p => GetString(ve, p));
			}

			private IEnumerable<T> GetVector<T>()
			{
				if ((vt & VARTYPE.VT_VECTOR) == 0)
					throw new InvalidCastException();
				return _blob.cbSize <= 0 ? new T[0] : _blob.pBlobData.ToIEnum<T>((int)_blob.cbSize);
			}

			private void SetDecimal(decimal? decVal)
			{
				var tempVt = vt;
				_decimal = decVal.GetValueOrDefault();
				vt = tempVt;
			}

			private void SetSafeArray(IList<object> array)
			{
				vt = VARTYPE.VT_ARRAY | VARTYPE.VT_VARIANT;
				if (array == null || array.Count == 0) return;
				var psa = SafeArrayCreateVector(VARTYPE.VT_VARIANT, 0, (uint)array.Count);
				if (psa == IntPtr.Zero) throw new Win32Exception();
				using (var p = new SafeArrayScopedAccessData(psa))
				{
					var elemSz = SafeArrayGetElemsize(psa);
					if (elemSz == 0) throw new Win32Exception();
					for (var i = 0; i < array.Count; ++i)
						Marshal.GetNativeVariantForObject(array[i], p.Data.Offset(i * elemSz));
				}
				_ptr = psa;
			}

			private void SetString(string value, VarEnum ve)
			{
				VarType = ve;
				_ptr = GetStringPtr(value, ve);
				if (_ptr == IntPtr.Zero && ve == VarEnum.VT_BSTR)
					vt = VARTYPE.VT_BSTR | VARTYPE.VT_BYREF;
			}

			[SecurityCritical, SecuritySafeCritical]
			private void SetStringVector(IEnumerable<string> value, VarEnum ve)
			{
				var svt = ((VARTYPE)ve).ClearFlags(VARTYPE.VT_VECTOR);
				if (svt != VARTYPE.VT_LPWSTR && svt != VARTYPE.VT_LPSTR && svt != VARTYPE.VT_BSTR)
					throw new ArgumentException(@"String vectors must be of VARTYPE VT_LPWSTR, VT_LPSTR or VT_BSTR", nameof(ve));
				if (value == null) throw new ArgumentNullException(nameof(value));

				Clear();
				var sc = value.ToArray();
				/*using (var tmp = new PROPVARIANT())
				{
					InitPropVariantFromStringVector(sc, (uint) sc.Length, tmp).ThrowIfFailed();
					PropVariantCopy(this, tmp);
				}*/

				vt = svt | VARTYPE.VT_VECTOR;
				if (sc.Length <= 0) return;

				var destPtr = IntPtr.Zero;
				var index = 0;
				try
				{
					// TODO: Fix this so that it uses the system call in hopes that PropVarClear will actually release the memory.
					destPtr = Marshal.AllocCoTaskMem(IntPtr.Size * sc.Length);
					for (index = 0; index < sc.Length; index++)
						Marshal.WriteIntPtr(destPtr, index * IntPtr.Size, GetStringPtr(sc[index], (VarEnum)svt));
					_blob.cbSize = (uint)sc.Length;
					_blob.pBlobData = destPtr;
					destPtr = IntPtr.Zero;
				}
				finally
				{
					if (destPtr != IntPtr.Zero)
					{
						for (var i = 0; i < index; i++)
							Marshal.FreeCoTaskMem(Marshal.ReadIntPtr(destPtr, i * IntPtr.Size));
						Marshal.FreeCoTaskMem(destPtr);
					}
				}
			}

			private void SetStruct<T>(T? value, VarEnum ve) where T : struct
			{
				Clear();
				VarType = ve;
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
					else if (type == typeof(decimal)) SetDecimal((decimal) (object) value.Value);
					else throw new ArgumentException($"Unrecognized structure {typeof(T).Name}"); // This would work but there is no means to free this memory. // _ptr = value.Value.StructureToPtr());
				}
				else
					vt |= VARTYPE.VT_BYREF;
			}

			private void SetVector<T>(IEnumerable<T> array, VarEnum varEnum)
			{
				Clear();
				vt = (VARTYPE)varEnum | VARTYPE.VT_VECTOR;
				if (array == null) return;

				var enumerable = array as ICollection<T> ?? array.ToList();
				_blob.cbSize = (uint)enumerable.Count;
				var sz = Marshal.SizeOf(typeof(T));
				// TODO: Fix this so that it uses the system call in hopes that PropVarClear will actually release the memory.
				_blob.pBlobData = Marshal.AllocCoTaskMem(sz * (int)_blob.cbSize);
				enumerable.MarshalToPtr(_blob.pBlobData);
			}

			/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
			public void Dispose()
			{
				PropVariantClear(this);
				GC.SuppressFinalize(this);
			}

			/// <summary>Finalizes an instance of the <see cref="PROPVARIANT"/> class.</summary>
			~PROPVARIANT()
			{
				Dispose();
			}
		}
	}
}