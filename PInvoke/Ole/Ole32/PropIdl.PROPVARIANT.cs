#pragma warning disable IDE1006 // Naming Styles
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security;
using Vanara.Collections;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.OleAut32;
using static Vanara.PInvoke.PropSys;

namespace Vanara.PInvoke;

public static partial class Ole32
{
	internal delegate HRESULT InitFunc<T>(T[] vector, uint vsz, ref PROPVARIANT_UNMGD pv) where T : struct;

	/// <summary>
	/// Structure to mimic behavior of VT_BLOB type. "DWORD count of bytes, followed by that many bytes of data. The byte count does not
	/// include the four bytes for the length of the count itself; an empty blob member would have a count of zero, followed by zero bytes."
	/// </summary>
	[StructLayout(LayoutKind.Sequential, Pack = 0)]
	public struct BLOB(uint cbSize, IntPtr pBlobData)
	{
		/// <summary>The count of bytes</summary>
		public uint cbSize = cbSize;

		/// <summary>A pointer to the allocated array of bytes.</summary>
		public IntPtr pBlobData = Dup(pBlobData, cbSize);

		/// <summary>Returns a span containing the elements of the collection.</summary>
		/// <remarks>
		/// The returned span reflects the current state of the collection. Modifying the span will modify the underlying data if the
		/// collection is mutable.
		/// </remarks>
		/// <returns>
		/// A span of bytes that provides access to the elements in the collection. The span's length is equal to the number of elements in
		/// the collection.
		/// </returns>
		public readonly Span<byte> AsSpan() => pBlobData.AsSpan<byte>(cbSize);

		/// <summary>
		/// Defines an implicit conversion from a SafeAllocatedMemoryHandleBase to a CA&gt;T&lt; structure, interpreting the memory as a byte array.
		/// </summary>
		/// <param name="mem">The memory handle containing the data to be interpreted as a byte array.</param>
		public static implicit operator BLOB(SafeAllocatedMemoryHandleBase mem) => new((uint)mem.Size, mem);

		/// <summary>Defines an implicit conversion from a BLOB to a span of bytes representing its contents.</summary>
		/// <remarks>
		/// This operator enables direct use of a BLOB instance as a Span&lt;byte&gt; without explicit casting. The returned span reflects
		/// the current contents of the BLOB; modifications to the span affect the underlying data.
		/// </remarks>
		/// <param name="blob">The BLOB structure.</param>
		public static implicit operator Span<byte>(BLOB blob) => blob.AsSpan();

		private static IntPtr Dup(IntPtr p, uint sz) { if (p == default || sz == 0) return default; var m = Marshal.AllocCoTaskMem((int)sz); p.CopyTo(m, sz); return m; }
	}

	/// <summary>
	/// A generic structure used by <see cref="PROPVARIANT_IMMUTABLE"/> to represent arrays of unmanaged types. The <see cref="cElems"/>
	/// field specifies the number of elements in the array, and the <see cref="pElems"/> field is a pointer to the first element of the array.
	/// </summary>
	/// <typeparam name="T">The unmanaged array element type.</typeparam>
	[StructLayout(LayoutKind.Sequential)]
	public struct CA<T> where T : unmanaged
	{
		/// <summary>The number of elements in the array.</summary>
		public uint cElems;

		/// <summary>A pointer to the first element of the array.</summary>
		public ArrayPointer<T> pElems;

		/// <summary>Returns a span containing the elements of the collection.</summary>
		/// <remarks>
		/// The returned span reflects the current state of the collection. Modifying the span will modify the underlying data if the
		/// collection is mutable.
		/// </remarks>
		/// <returns>
		/// A span of type T that provides access to the elements in the collection. The span's length is equal to the number of elements in
		/// the collection.
		/// </returns>
		public readonly Span<T> AsSpan() => pElems.AsSpan(cElems);

		/// <summary>
		/// Defines an implicit conversion from a SafeAllocatedMemoryHandleBase to a CA&lt;T&gt; structure, interpreting the memory as an
		/// array of elements of type <typeparamref name="T"/>.
		/// </summary>
		/// <remarks>
		/// The number of elements is determined by dividing the total memory size by the size of type <typeparamref name="T"/>. The caller
		/// is responsible for ensuring that the memory layout matches the expected structure of CA&lt;T&gt; and that the memory remains
		/// valid for the lifetime of the resulting CA&lt;T&gt; instance.
		/// </remarks>
		/// <param name="mem">
		/// The memory handle containing the data to be interpreted as an array of <typeparamref name="T"/> elements. The memory must be
		/// properly allocated and sized for the intended element type.
		/// </param>
		public static implicit operator CA<T>(SafeAllocatedMemoryHandleBase mem) => new() { cElems = (uint)mem.Size / (uint)Marshal.SizeOf<T>(), pElems = mem.DangerousGetHandle() };

		/// <summary>Defines an implicit conversion from a BLOB to a span of bytes representing its contents.</summary>
		/// <remarks>
		/// This operator enables direct use of a BLOB instance as a Span&lt;T&gt; without explicit casting. The returned span reflects the
		/// current contents of the CA&lt;T&gt; structure; modifications to the span affect the underlying data.
		/// </remarks>
		/// <param name="ca">The CA&lt;T&gt; structure value.</param>
		public static implicit operator Span<T>(CA<T> ca) => ca.AsSpan();
	}

	/// <summary>Structure to hold VT_CLIPDATE content.</summary>
	/// <remarks>Initializes a new instance of the <see cref="CLIPDATA"/> struct.</remarks>
	/// <param name="clipFmt">The clipboard format.</param>
	/// <param name="dataPtr">A pointer to the data.</param>
	/// <param name="dataLength">
	/// Length of the data in bytes. Do not include any length other than that pointed to by <paramref name="dataPtr"/>.
	/// </param>
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct CLIPDATA(int clipFmt, IntPtr dataPtr, int dataLength)
	{
		/// <summary>The size of the buffer pointed to by pClipData, plus sizeof(ulClipFmt)</summary>
		public int cbSize = dataLength + Marshal.SizeOf<int>();

		/// <summary>The clipboard format.</summary>
		public int ulClipFmt = clipFmt;

		/// <summary>The clipboard data.</summary>
		public IntPtr pClipData = dataPtr;

		/// <summary>Initializes a new instance of the <see cref="CLIPDATA"/> struct.</summary>
		/// <param name="clipFmt">The string value to register as a new clipboard format using RegisterClipboardFormat.</param>
		public CLIPDATA(string clipFmt) : this(clipFmt.Length + 1, Marshal.StringToHGlobalAuto(clipFmt), (clipFmt.Length + 1) * Marshal.SystemDefaultCharSize) { }

		/// <summary>Initializes a new instance of the <see cref="CLIPDATA"/> struct.</summary>
		/// <param name="clipFmt">The clipboard format.</param>
		/// <param name="mem">A memory handle that holds the data.</param>
		public CLIPDATA(int clipFmt, SafeAllocatedMemoryHandleBase mem) : this(clipFmt, mem, mem.Size + Marshal.SizeOf<int>()) { }

		/// <summary>The clipboard format.</summary>
		public readonly uint ClipboardFormat => ulClipFmt is (-1) or (-2) ? (uint)Marshal.ReadInt32(pClipData) : 0;

		/// <summary>The clipboard name.</summary>
		public readonly string? ClipboardFormatName => ulClipFmt > 0 ? Marshal.PtrToStringUni(pClipData) : null;

		/// <summary>The clipboard format id.</summary>
		public readonly Guid FMTID => ulClipFmt == -3 ? pClipData.ToStructure<Guid>() : Guid.Empty;

		/// <inheritdoc/>
		public override readonly string ToString() => ulClipFmt switch
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

	[StructLayout(LayoutKind.Sequential)]
	public struct VERSIONEDSTREAM
	{
		public Guid guidVersion;
		private IntPtr _pStream;

		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		public IStream pStream { readonly get { try { return _pStream != default ? (IStream)Marshal.GetObjectForIUnknown(_pStream) : null!; } catch { return null!; } } set => _pStream = Marshal.GetIUnknownForObject(value); }
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
	[StructLayout(LayoutKind.Sequential)]
	public sealed class PROPVARIANT(VarEnum type = VarEnum.VT_EMPTY) : ICloneable, IComparable, IComparable<PROPVARIANT>, IDisposable, IEquatable<PROPVARIANT>
	{
		internal PROPVARIANT_UNMGD _pv = new() { vt = (VARTYPE)type };

		/// <summary>Initializes a new instance of the <see cref="PROPVARIANT"/> class with an object.</summary>
		/// <param name="obj">The object to wrap. Based on the object type, it will infer the value type and allocate memory as needed.</param>
		/// <param name="type">If not VT_EMPTY, this value will override the inferred value type.</param>
		public PROPVARIANT(object? obj, VarEnum type = VarEnum.VT_EMPTY) : this(type)
		{
			if (obj is PROPVARIANT pv)
				PropVariantCopy(this, pv);
			else
				_pv.SetValue(obj, type);
		}

		/// <summary>Initializes a new instance of the PROPVARIANT structure using the specified unmanaged PROPVARIANT value.</summary>
		/// <remarks>
		/// This constructor is typically used when interoperating with native code that provides PROPVARIANT values. The input value is
		/// copied into the managed structure. This will effectively transfer ownership to the created <see cref="PROPVARIANT"/> class for
		/// disposal. <see cref="PropVariantClear(ref PROPVARIANT_UNMGD)"/> should NOT be called on <paramref name="pv"/>.
		/// </remarks>
		/// <param name="pv">The unmanaged PROPVARIANT value to initialize this instance with.</param>
		public PROPVARIANT(in PROPVARIANT_UNMGD pv) : this() => _pv = pv;

		/// <summary>Initializes a new instance of the PROPVARIANT structure using the specified unmanaged PROPVARIANT value.</summary>
		/// <remarks>
		/// This constructor is typically used when interoperating with native code that provides PROPVARIANT values. The input value is
		/// copied into the managed structure. This will effectively clone <paramref name="pv"/>.
		/// </remarks>
		/// <param name="pv">The PROPVARIANT value to initialize this instance with.</param>
		public PROPVARIANT([In] PROPVARIANT pv) : this() => PropVariantCopy(ref _pv, pv).ThrowIfFailed();

		/// <summary>Finalizes an instance of the <see cref="PROPVARIANT"/> class.</summary>
		~PROPVARIANT() => Dispose();

		/// <summary>Value type tag.</summary>
		public VARTYPE vt { get => _pv.vt; set => _pv.vt = value; }

		/// <summary>Reserved for future use.</summary>
		public ushort wReserved1 { get => _pv.wReserved1; set => _pv.wReserved1 = value; }

		/// <summary>Reserved for future use.</summary>
		public ushort wReserved2 { get => _pv.wReserved2; set => _pv.wReserved2 = value; }

		/// <summary>Reserved for future use.</summary>
		public ushort wReserved3 { get => _pv.wReserved3; set => _pv.wReserved3 = value; }

		/// <summary>Gets the BLOB value.</summary>
		public BLOB blob => _pv.blob;

		/// <summary>Gets the boolean value.</summary>
		public bool boolVal => _pv.boolVal;

		/// <summary>Gets the BSTR value.</summary>
		public string? bstrVal => GetString(_pv.vt);

		/// <summary>Gets the byte value.</summary>
		public byte bVal => _pv.bVal;

		/// <summary>Gets the boolean array value.</summary>
		public IEnumerable<bool> cabool => Array.ConvertAll(_pv.cabool.AsSpan().ToArray(), b => (bool)b);

		/// <summary>Gets the string array value.</summary>
		public IEnumerable<string?> cabstr => _pv.GetStringVector();

		/// <summary>Gets the sbyte array value.</summary>
		public IEnumerable<sbyte> cac => _pv.cac.AsSpan().ToArray();

		/// <summary>Gets the CLIPDATA array value.</summary>
		public IEnumerable<CLIPDATA> caclipdata => _pv.caclipdata.AsSpan().ToArray();

		/// <summary>Gets the decimal array value.</summary>
		public IEnumerable<decimal> cacy => Array.ConvertAll(_pv.cacy.AsSpan().ToArray(), cy => (decimal)cy);

		/// <summary>Gets the DateTime array value.</summary>
		public IEnumerable<DateTime> cadate => Array.ConvertAll(_pv.cadate.AsSpan().ToArray(), d => d.Value);

		/// <summary>Gets the double array value.</summary>
		public IEnumerable<double> cadbl => _pv.cadbl.AsSpan().ToArray();

		/// <summary>Gets the FILETIME array value.</summary>
		public IEnumerable<FILETIME> cafiletime => _pv.cafiletime.AsSpan().ToArray();

		/// <summary>Gets the float array value.</summary>
		public IEnumerable<float> caflt => _pv.caflt.AsSpan().ToArray();

		/// <summary>Gets the long array value.</summary>
		public IEnumerable<long> cah => _pv.cah.AsSpan().ToArray();

		/// <summary>Gets the short array value.</summary>
		public IEnumerable<short> cai => _pv.cai.AsSpan().ToArray();

		/// <summary>Gets the int array value.</summary>
		public IEnumerable<int> cal => _pv.cal.AsSpan().ToArray();

		/// <summary>Gets the ANSI string array value.</summary>
		public IEnumerable<string?> calpstr => _pv.GetStringVector();

		/// <summary>Gets the Unicode string array value.</summary>
		public IEnumerable<string?> calpwstr => _pv.GetStringVector();

		/// <summary>Gets the PROPVARIANT array value.</summary>
		public IEnumerable<PROPVARIANT> capropvar => Array.ConvertAll(_pv.capropvar.AsSpan().ToArray(), p => new PROPVARIANT(p));

		/// <summary>Gets the Win32Error array value.</summary>
		public IEnumerable<Win32Error> cascode => Array.ConvertAll(_pv.cascode.AsSpan().ToArray(), d => new Win32Error(unchecked((uint)d)));

		/// <summary>Gets the byte array value.</summary>
		public IEnumerable<byte> caub => _pv.caub.AsSpan().ToArray();

		/// <summary>Gets the ulong array value.</summary>
		public IEnumerable<ulong> cauh => _pv.cauh.AsSpan().ToArray();

		/// <summary>Gets the ushort array value.</summary>
		public IEnumerable<ushort> caui => _pv.caui.AsSpan().ToArray();

		/// <summary>Gets the uint array value.</summary>
		public IEnumerable<uint> caul => _pv.caul.AsSpan().ToArray();

		/// <summary>Gets the Guid array value.</summary>
		public IEnumerable<Guid> cauuid => _pv.cauuid.AsSpan().ToArray();

		/// <summary>Gets the sbyte value.</summary>
		public sbyte cVal => _pv.cVal;

		/// <summary>Gets the decimal value.</summary>
		public decimal cyVal => _pv.cyVal.Value;

		/// <summary>Gets the date.</summary>
		public DateTime date => _pv.date.Value;

		/// <summary>Gets the double value.</summary>
		public double dblVal => _pv.dblVal;

		/// <summary>Gets the FILETIME.</summary>
		public FILETIME filetime => _pv.filetime;

		/// <summary>Gets the float value.</summary>
		public float fltVal => _pv.fltVal;

		/// <summary>Gets the long value.</summary>
		public long hVal => _pv.hVal;

		/// <summary>Gets the int value.</summary>
		public int intVal => _pv.intVal;

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
		public short iVal => _pv.iVal;

		/// <summary>Gets the int value.</summary>
		public int lVal => _pv.lVal;

		/// <summary>Gets the array of objects.</summary>
		public IEnumerable<object?> parray => _pv.GetSafeArray();

		/// <summary>Gets the boolean value as a reference accounting for its source potentially being a pointer to NULL..</summary>
		public StructPointer<VARIANT_BOOL> pboolVal => _pv.pboolVal;

		/// <summary>Gets the string value as a reference accounting for its source potentially being a pointer to NULL..</summary>
		public StructPointer<IntPtr> pbstrVal => _pv.pbstrVal;

		/// <summary>Gets the byte value as a reference accounting for its source potentially being a pointer to NULL..</summary>
		public StructPointer<byte> pbVal => _pv.pbVal;

		/// <summary>Gets the CLIPDATA value as a reference accounting for its source potentially being a pointer to NULL..</summary>
		public StructPointer<CLIPDATA> pclipdata => _pv.pclipdata;

		/// <summary>Gets the sbyte value as a reference accounting for its source potentially being a pointer to NULL..</summary>
		public StructPointer<sbyte> pcVal => _pv.pcVal;

		/// <summary>Gets the decimal value as a reference accounting for its source potentially being a pointer to NULL..</summary>
		public StructPointer<CY> pcyVal => _pv.pcyVal;

		/// <summary>Gets the DateTime value as a reference accounting for its source potentially being a pointer to NULL..</summary>
		public StructPointer<DATE> pdate => _pv.pdate;

		/// <summary>Gets the double value as a reference accounting for its source potentially being a pointer to NULL..</summary>
		public StructPointer<double> pdblVal => _pv.pdblVal;

		/// <summary>Gets the decimal value as a reference accounting for its source potentially being a pointer to NULL..</summary>
		public StructPointer<DECIMAL> pdecVal => _pv.pdecVal;

		/// <summary>Gets the pointer value as a reference accounting for its source potentially being a pointer to NULL..</summary>
		public object? pdispVal => _pv.pdispVal;

		/// <summary>Gets the float value as a reference accounting for its source potentially being a pointer to NULL..</summary>
		public StructPointer<float> pfltVal => _pv.pfltVal;

		/// <summary>Gets the int value as a reference accounting for its source potentially being a pointer to NULL..</summary>
		public StructPointer<int> pintVal => _pv.pintVal;

		/// <summary>Gets the short value as a reference accounting for its source potentially being a pointer to NULL..</summary>
		public StructPointer<short> piVal => _pv.piVal;

		/// <summary>Gets the int value as a reference accounting for its source potentially being a pointer to NULL..</summary>
		public StructPointer<int> plVal => _pv.plVal;

		/// <summary>Gets the IDispatch value.</summary>
		public IDispatch? ppdispVal => _pv.GetIUnkVal() as IDispatch;

		/// <summary>Gets the IUnknown value.</summary>
		public object? ppunkVal => _pv.GetIUnkVal();

		/// <summary>Gets the Win32Error value as a reference accounting for its source potentially being a pointer to NULL..</summary>
		public StructPointer<int> pscode => _pv.pscode;

		/// <summary>Gets the IStorage value.</summary>
		public IStorage? pStorage => _pv.pStorage;

		/// <summary>Gets the IStream value.</summary>
		public IStream? pStream => _pv.pStream;

		/// <summary>Gets the ANSI string value.</summary>
		public string? pszVal => GetString(_pv.vt);

		/// <summary>Gets the uint value as a reference accounting for its source potentially being a pointer to NULL..</summary>
		public StructPointer<uint> puintVal => _pv.puintVal;

		/// <summary>Gets the ushort value as a reference accounting for its source potentially being a pointer to NULL..</summary>
		public StructPointer<ushort> puiVal => _pv.puiVal;

		/// <summary>Gets the uint value as a reference accounting for its source potentially being a pointer to NULL..</summary>
		public StructPointer<uint> pulVal => _pv.pulVal;

		/// <summary>Gets the IUnknown value as a reference accounting for its source potentially being a pointer to NULL..</summary>
		public object? punkVal => _pv.punkVal;

		/// <summary>Gets the Guid value as a reference accounting for its source potentially being a pointer to NULL..</summary>
		public GuidPtr puuid => _pv.puuid;

		/// <summary>Gets the PROPVARIANT value as a reference accounting for its source potentially being a pointer to NULL..</summary>
		public StructPointer<PROPVARIANT_UNMGD> pvarVal => _pv.pvarVal;

		/// <summary>Gets a stream with a Guid version.</summary>
		public StructPointer<VERSIONEDSTREAM> pVersionedStream => _pv.pVersionedStream;

		/// <summary>Gets the Unicode string value.</summary>
		public string? pwszVal => GetString(_pv.vt);

		/// <summary>Gets the Win32Error value.</summary>
		public Win32Error scode => new(unchecked((uint)_pv.scode));

		/// <summary>Gets the ulong value.</summary>
		public ulong uhVal => _pv.uhVal;

		/// <summary>Gets the uint value.</summary>
		public uint uintVal => _pv.uintVal;

		/// <summary>Gets the ushort value.</summary>
		public ushort uiVal => _pv.uiVal;

		/// <summary>Gets the uint value.</summary>
		public uint ulVal => _pv.ulVal;

		/// <summary>Get a reference to the internal representation.</summary>
		/// <returns>A reference for the internal <see cref="PROPVARIANT_UNMGD"/> value.</returns>
		public ref PROPVARIANT_UNMGD GetRefValue() => ref _pv;

		/// <summary>Gets the value base on the <see cref="vt"/> value.</summary>
		public object? Value { get => _pv.GetValue(); set => _pv.SetValue(value); }

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
			VariantToPropVariant(pSrcNativeVariant, ref pv.GetRefValue()).ThrowIfFailed();
			return pv;
		}

		/// <summary>Gets the Type for a provided VARTYPE.</summary>
		/// <param name="vt">The VARTYPE value to lookup.</param>
		/// <returns>A best fit <see cref="Type"/> for the provided VARTYPE.</returns>
		[Obsolete("Use VARTYPE.GetCorrespondingType() extension method instead.", false)]
		public static Type? GetType(VARTYPE vt)
		{
			// Safe arrays are always pointers
			if (vt.IsFlagSet(VARTYPE.VT_ARRAY)) return typeof(IntPtr);
			Type? type = vt.GetCorrespondingType();
			if (vt.IsFlagSet(VARTYPE.VT_BYREF) && type is not null && type!.IsPointer)
				type = typeof(Nullable<>).MakeGenericType(type.GetElementType()!);
			if (vt.IsFlagSet(VARTYPE.VT_VECTOR) && type is not null)
				type = typeof(IEnumerable<>).MakeGenericType(type.GetElementType()!);
			return type;
		}

		/// <summary>Gets the VARTYPE for a provided type.</summary>
		/// <param name="type">The type to analyze.</param>
		/// <returns>A best fit <see cref="VARTYPE"/> for the provided type.</returns>
		[Obsolete("Use Type.GetVarType() extension method instead.", true)]
		public static VARTYPE GetVarType(Type? type) => type.GetVarType();

		/// <summary>
		/// Frees all elements that can be freed in this instance. For complex elements with known element pointers, the underlying
		/// elements are freed prior to freeing the containing element.
		/// </summary>
		[SecurityCritical, SecuritySafeCritical]
		public void Clear() => _pv.Clear();

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
		public int CompareTo(object? other) => _pv.CompareTo(other);

		/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
		public void Dispose()
		{
			Clear();
			GC.SuppressFinalize(this);
		}

		/// <summary>Determines whether the specified <see cref="object"/>, is equal to this instance.</summary>
		/// <param name="obj">The <see cref="object"/> to compare with this instance.</param>
		/// <returns><c>true</c> if the specified <see cref="object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
		public override bool Equals(object? obj) => _pv.Equals(obj);

		/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
		public bool Equals(PROPVARIANT? other) => other is not null && _pv.Equals(other._pv);

		/// <summary>Returns a hash code for this instance.</summary>
		/// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
		public override int GetHashCode() => _pv.decVal.GetHashCode();

		/// <summary>Returns a <see cref="string"/> that represents this instance.</summary>
		/// <returns>A <see cref="string"/> that represents this instance.</returns>
		public override string ToString() => _pv.ToString();

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

		private static string? GetString(VARTYPE ve, IntPtr ptr) => ve switch
		{
			VARTYPE.VT_LPSTR => Marshal.PtrToStringAnsi(ptr),
			VARTYPE.VT_LPWSTR => Marshal.PtrToStringUni(ptr),
			VARTYPE.VT_BSTR or VARTYPE.VT_BSTR | VARTYPE.VT_BYREF => Marshal.PtrToStringBSTR(ptr),
			_ => null,
		};

		private string? GetString(VARTYPE ve) => GetString(ve, _pv.ptr);

		private T[] GetVector<T>() => vt.IsFlagSet(VARTYPE.VT_VECTOR) ? (_pv.blob.cbSize <= 0 ? [] : _pv.blob.pBlobData.ToArray<T>((int)_pv.blob.cbSize))! : throw new InvalidCastException();
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
	[Obsolete("Use PROPVARIANT_UNMGD instead. This structure is immutable and does not support all types that PROPVARIANT does. It is only intended for use in scenarios where a fixed struct size is required, such as in arrays. For general use, PROPVARIANT_UNMGD is recommended.", false)]
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
		public static implicit operator PROPVARIANT_IMMUTABLE(PROPVARIANT pv) => new() { vt = pv.vt, wReserved1 = pv.wReserved1, wReserved2 = pv.wReserved2, wReserved3 = pv.wReserved3, _blob = pv._pv.blob };

		/// <summary>Performs an implicit conversion from <see cref="PROPVARIANT_IMMUTABLE"/> to <see cref="PROPVARIANT"/>.</summary>
		/// <param name="pv">The PROPVARIANT_IMMUTABLE instance.</param>
		/// <returns>The resulting <see cref="PROPVARIANT"/> instance from the conversion.</returns>
		public static explicit operator PROPVARIANT(in PROPVARIANT_IMMUTABLE pv) => new() { _pv = new() { vt = pv.vt, wReserved1 = pv.wReserved1, wReserved2 = pv.wReserved2, wReserved3 = pv.wReserved3, blob = pv._blob } };
	}
	
	/// <summary>
	/// The PROPVARIANT structure is used in the ReadMultiple and WriteMultiple methods of IPropertyStorage to define the type tag and the
	/// value of a property in a property set.
	/// <para>
	/// The PROPVARIANT structure is also used by the GetValue and SetValue methods of IPropertyStore, which replaces IPropertySetStorage as
	/// the primary way to program item properties in Windows Vista. For more information, see Property Handlers.
	/// </para>
	/// <para>
	/// There are five members. The first member, the value-type tag, and the last member, the value of the property, are significant. The
	/// middle three members are reserved for future use.
	/// </para>
	/// </summary>
	[StructLayout(LayoutKind.Explicit)]
	public struct PROPVARIANT_UNMGD : IComparable, IComparable<PROPVARIANT_UNMGD>, IEquatable<PROPVARIANT_UNMGD>
	{
		/// <summary>Value type tag.</summary>
		[FieldOffset(0)]
		public VARTYPE vt;

		/// <summary>The decimal value when VT_DECIMAL.</summary>
		[FieldOffset(0)]
		public decimal decVal;

		/// <summary>Reserved for future use.</summary>
		[FieldOffset(2)]
		public ushort wReserved1;

		/// <summary>Reserved for future use.</summary>
		[FieldOffset(4)]
		public ushort wReserved2;

		/// <summary>Reserved for future use.</summary>
		[FieldOffset(6)]
		public ushort wReserved3;

		/// <summary>1-byte signed integer.</summary>
		[FieldOffset(8)]
		public sbyte cVal;

		/// <summary>1-byte unsigned integer.</summary>
		[FieldOffset(8)]
		public byte bVal;

		/// <summary>Two bytes representing a 2-byte signed integer value.</summary>
		[FieldOffset(8)]
		public short iVal;

		/// <summary>2-byte unsigned integer value.</summary>
		[FieldOffset(8)]
		public ushort uiVal;

		/// <summary>4-byte signed integer value.</summary>
		[FieldOffset(8)]
		public int lVal;

		/// <summary>4-byte unsigned integer value.</summary>
		[FieldOffset(8)]
		public uint ulVal;

		/// <summary>4-byte signed integer value.</summary>
		[FieldOffset(8)]
		public int intVal;

		/// <summary>4-byte unsigned integer value.</summary>
		[FieldOffset(8)]
		public uint uintVal;

		/// <summary>8-byte signed integer value.</summary>
		[FieldOffset(8)]
		public long hVal;

		/// <summary>8-byte unsigned integer value.</summary>
		[FieldOffset(8)]
		public ulong uhVal;

		/// <summary>32-bit IEEE floating point value.</summary>
		[FieldOffset(8)]
		public float fltVal;

		/// <summary>64-bit IEEE floating point value.</summary>
		[FieldOffset(8)]
		public double dblVal;

		/// <summary>Boolean value, a WORD that contains 0 (FALSE) or -1 (TRUE).</summary>
		public bool boolVal { readonly get => iVal != 0; set => iVal = value ? (short)-1 : (short)0; }

		/// <summary>A DWORD that contains a status code.</summary>
		[FieldOffset(8)]
		public int scode;

		/// <summary>8-byte two's complement integer (scaled by 10,000). This type is commonly used for currency amounts.</summary>
		[FieldOffset(8)]
		public CY cyVal;

		/// <summary>
		/// A 64-bit floating point number representing the number of days (not seconds) since December 31, 1899. For example, January 1,
		/// 1900, is 2.0, January 2, 1900, is 3.0, and so on). This is stored in the same representation as VT_R8.
		/// </summary>
		[FieldOffset(8)]
		public DATE date;

		/// <summary>
		/// 64-bit FILETIME structure as defined by Win32. It is recommended that all times be stored in Universal Coordinate Time (UTC).
		/// </summary>
		[FieldOffset(8)]
		public FILETIME filetime;

		/// <summary>Pointer to a class identifier (CLSID) (or other globally unique identifier (GUID)).</summary>
		[FieldOffset(8)]
		public GuidPtr puuid;

		/// <summary>Pointer to a CLIPDATA structure.</summary>
		[FieldOffset(8)]
		public StructPointer<CLIPDATA> pclipdata;

		/// <summary>
		/// Pointer to a null-terminated Unicode string. The string is immediately preceded by a DWORD representing the byte count, but
		/// bstrVal points past this DWORD to the first character of the string. BSTRs must be allocated and freed using the Automation
		/// SysAllocString and SysFreeString calls.
		/// </summary>
		[FieldOffset(8)]
		public StrPtrUni bstrVal;

		/// <summary>
		/// DWORD count of bytes, followed by that many bytes of data. The byte count does not include the four bytes for the length of the
		/// count itself; an empty blob member would have a count of zero, followed by zero bytes. This is similar to the value VT_BSTR, but
		/// does not guarantee a null byte at the end of the data.
		/// </summary>
		[FieldOffset(8)]
		public BLOB bstrblobVal;

		/// <summary>For system use only.</summary>
		[FieldOffset(8)]
		public BLOB blob;

		/// <summary>A pointer to a null-terminated ANSI string in the system default code page.</summary>
		[FieldOffset(8)]
		public StrPtrAnsi pszVal;

		/// <summary>A pointer to a null-terminated Unicode string in the user default locale.</summary>
		[FieldOffset(8)]
		public StrPtrUni pwszVal;

		[FieldOffset(8)]
		internal IntPtr ptr;

		/// <summary>A pointer to an IUnknown interface</summary>
		public object? punkVal { readonly get => GetIUnkVal(); set => ptr = value is null ? IntPtr.Zero : Marshal.GetIUnknownForObject(value); }

		/// <summary>A pointer to an IDispatch interface</summary>
		public IDispatch? pdispVal { readonly get => GetIUnkVal() as IDispatch; set => ptr = value is null ? IntPtr.Zero : Marshal.GetIUnknownForObject(value); }

		/// <summary>A pointer to an IStream interface that represents a stream which is a sibling to the "Contents" stream.</summary>
		public IStream? pStream { readonly get => GetIUnkVal() as IStream; set => ptr = value is null ? IntPtr.Zero : Marshal.GetIUnknownForObject(value); }

		/// <summary>A pointer to an IStorage interface, representing a storage object that is a sibling to the "Contents" stream.</summary>
		public IStorage? pStorage { readonly get => GetIUnkVal() as IStorage; set => ptr = value is null ? IntPtr.Zero : Marshal.GetIUnknownForObject(value); }

		/// <summary>A stream with a GUID version.</summary>
		[FieldOffset(8)]
		public StructPointer<VERSIONEDSTREAM> pVersionedStream;

		/// <summary>
		/// If the type indicator is combined with VT_ARRAY by an OR operator, the value is a pointer to a SAFEARRAY. VT_ARRAY can use the OR
		/// with the following data types: VT_I1, VT_UI1, VT_I2, VT_UI2, VT_I4, VT_UI4, VT_INT, VT_UINT, VT_R4, VT_R8, VT_BOOL, VT_DECIMAL,
		/// VT_ERROR, VT_CY, VT_DATE, VT_BSTR, VT_DISPATCH, VT_UNKNOWN, and VT_VARIANT. VT_ARRAY cannot use OR with VT_VECTOR.
		/// </summary>
		[FieldOffset(8)]
		public StructPointer<SAFEARRAY> parray;

		/// <summary>
		/// If the type indicator is combined with VT_VECTOR by using an OR operator, the value is one of the counted array values. This
		/// creates a DWORD count of elements, followed by a pointer to the specified repetitions of the value. For example, a type indicator
		/// of VT_LPSTR|VT_VECTOR has a DWORD element count, followed by a pointer to an array of LPSTR elements.
		/// </summary>
		[FieldOffset(8)]
		public CA<sbyte> cac;

		/// <summary>
		/// If the type indicator is combined with VT_VECTOR by using an OR operator, the value is one of the counted array values. This
		/// creates a DWORD count of elements, followed by a pointer to the specified repetitions of the value. For example, a type indicator
		/// of VT_LPSTR|VT_VECTOR has a DWORD element count, followed by a pointer to an array of LPSTR elements.
		/// </summary>
		[FieldOffset(8)]
		public CA<byte> caub;

		/// <summary>
		/// If the type indicator is combined with VT_VECTOR by using an OR operator, the value is one of the counted array values. This
		/// creates a DWORD count of elements, followed by a pointer to the specified repetitions of the value. For example, a type indicator
		/// of VT_LPSTR|VT_VECTOR has a DWORD element count, followed by a pointer to an array of LPSTR elements.
		/// </summary>
		[FieldOffset(8)]
		public CA<short> cai;

		/// <summary>
		/// If the type indicator is combined with VT_VECTOR by using an OR operator, the value is one of the counted array values. This
		/// creates a DWORD count of elements, followed by a pointer to the specified repetitions of the value. For example, a type indicator
		/// of VT_LPSTR|VT_VECTOR has a DWORD element count, followed by a pointer to an array of LPSTR elements.
		/// </summary>
		[FieldOffset(8)]
		public CA<ushort> caui;

		/// <summary>
		/// If the type indicator is combined with VT_VECTOR by using an OR operator, the value is one of the counted array values. This
		/// creates a DWORD count of elements, followed by a pointer to the specified repetitions of the value. For example, a type indicator
		/// of VT_LPSTR|VT_VECTOR has a DWORD element count, followed by a pointer to an array of LPSTR elements.
		/// </summary>
		[FieldOffset(8)]
		public CA<int> cal;

		/// <summary>
		/// If the type indicator is combined with VT_VECTOR by using an OR operator, the value is one of the counted array values. This
		/// creates a DWORD count of elements, followed by a pointer to the specified repetitions of the value. For example, a type indicator
		/// of VT_LPSTR|VT_VECTOR has a DWORD element count, followed by a pointer to an array of LPSTR elements.
		/// </summary>
		[FieldOffset(8)]
		public CA<uint> caul;

		/// <summary>
		/// If the type indicator is combined with VT_VECTOR by using an OR operator, the value is one of the counted array values. This
		/// creates a DWORD count of elements, followed by a pointer to the specified repetitions of the value. For example, a type indicator
		/// of VT_LPSTR|VT_VECTOR has a DWORD element count, followed by a pointer to an array of LPSTR elements.
		/// </summary>
		[FieldOffset(8)]
		public CA<long> cah;

		/// <summary>
		/// If the type indicator is combined with VT_VECTOR by using an OR operator, the value is one of the counted array values. This
		/// creates a DWORD count of elements, followed by a pointer to the specified repetitions of the value. For example, a type indicator
		/// of VT_LPSTR|VT_VECTOR has a DWORD element count, followed by a pointer to an array of LPSTR elements.
		/// </summary>
		[FieldOffset(8)]
		public CA<ulong> cauh;

		/// <summary>
		/// If the type indicator is combined with VT_VECTOR by using an OR operator, the value is one of the counted array values. This
		/// creates a DWORD count of elements, followed by a pointer to the specified repetitions of the value. For example, a type indicator
		/// of VT_LPSTR|VT_VECTOR has a DWORD element count, followed by a pointer to an array of LPSTR elements.
		/// </summary>
		[FieldOffset(8)]
		public CA<float> caflt;

		/// <summary>
		/// If the type indicator is combined with VT_VECTOR by using an OR operator, the value is one of the counted array values. This
		/// creates a DWORD count of elements, followed by a pointer to the specified repetitions of the value. For example, a type indicator
		/// of VT_LPSTR|VT_VECTOR has a DWORD element count, followed by a pointer to an array of LPSTR elements.
		/// </summary>
		[FieldOffset(8)]
		public CA<double> cadbl;

		/// <summary>
		/// If the type indicator is combined with VT_VECTOR by using an OR operator, the value is one of the counted array values. This
		/// creates a DWORD count of elements, followed by a pointer to the specified repetitions of the value. For example, a type indicator
		/// of VT_LPSTR|VT_VECTOR has a DWORD element count, followed by a pointer to an array of LPSTR elements.
		/// </summary>
		[FieldOffset(8)]
		public CA<VARIANT_BOOL> cabool;

		/// <summary>
		/// If the type indicator is combined with VT_VECTOR by using an OR operator, the value is one of the counted array values. This
		/// creates a DWORD count of elements, followed by a pointer to the specified repetitions of the value. For example, a type indicator
		/// of VT_LPSTR|VT_VECTOR has a DWORD element count, followed by a pointer to an array of LPSTR elements.
		/// </summary>
		[FieldOffset(8)]
		public CA<int> cascode;

		/// <summary>
		/// If the type indicator is combined with VT_VECTOR by using an OR operator, the value is one of the counted array values. This
		/// creates a DWORD count of elements, followed by a pointer to the specified repetitions of the value. For example, a type indicator
		/// of VT_LPSTR|VT_VECTOR has a DWORD element count, followed by a pointer to an array of LPSTR elements.
		/// </summary>
		[FieldOffset(8)]
		public CA<CY> cacy;

		/// <summary>
		/// If the type indicator is combined with VT_VECTOR by using an OR operator, the value is one of the counted array values. This
		/// creates a DWORD count of elements, followed by a pointer to the specified repetitions of the value. For example, a type indicator
		/// of VT_LPSTR|VT_VECTOR has a DWORD element count, followed by a pointer to an array of LPSTR elements.
		/// </summary>
		[FieldOffset(8)]
		public CA<DATE> cadate;

		/// <summary>
		/// If the type indicator is combined with VT_VECTOR by using an OR operator, the value is one of the counted array values. This
		/// creates a DWORD count of elements, followed by a pointer to the specified repetitions of the value. For example, a type indicator
		/// of VT_LPSTR|VT_VECTOR has a DWORD element count, followed by a pointer to an array of LPSTR elements.
		/// </summary>
		[FieldOffset(8)]
		public CA<FILETIME> cafiletime;

		/// <summary>
		/// If the type indicator is combined with VT_VECTOR by using an OR operator, the value is one of the counted array values. This
		/// creates a DWORD count of elements, followed by a pointer to the specified repetitions of the value. For example, a type indicator
		/// of VT_LPSTR|VT_VECTOR has a DWORD element count, followed by a pointer to an array of LPSTR elements.
		/// </summary>
		[FieldOffset(8)]
		public CA<Guid> cauuid;

		/// <summary>
		/// If the type indicator is combined with VT_VECTOR by using an OR operator, the value is one of the counted array values. This
		/// creates a DWORD count of elements, followed by a pointer to the specified repetitions of the value. For example, a type indicator
		/// of VT_LPSTR|VT_VECTOR has a DWORD element count, followed by a pointer to an array of LPSTR elements.
		/// </summary>
		[FieldOffset(8)]
		public CA<CLIPDATA> caclipdata;

		/// <summary>
		/// If the type indicator is combined with VT_VECTOR by using an OR operator, the value is one of the counted array values. This
		/// creates a DWORD count of elements, followed by a pointer to the specified repetitions of the value. For example, a type indicator
		/// of VT_LPSTR|VT_VECTOR has a DWORD element count, followed by a pointer to an array of LPSTR elements.
		/// </summary>
		[FieldOffset(8)]
		public CA<StrPtrUni> cabstr;

		/// <summary>
		/// If the type indicator is combined with VT_VECTOR by using an OR operator, the value is one of the counted array values. This
		/// creates a DWORD count of elements, followed by a pointer to the specified repetitions of the value. For example, a type indicator
		/// of VT_LPSTR|VT_VECTOR has a DWORD element count, followed by a pointer to an array of LPSTR elements.
		/// </summary>
		[FieldOffset(8)]
		public CA<BLOB> cabstrblob;

		/// <summary>
		/// If the type indicator is combined with VT_VECTOR by using an OR operator, the value is one of the counted array values. This
		/// creates a DWORD count of elements, followed by a pointer to the specified repetitions of the value. For example, a type indicator
		/// of VT_LPSTR|VT_VECTOR has a DWORD element count, followed by a pointer to an array of LPSTR elements.
		/// </summary>
		[FieldOffset(8)]
		public CA<StrPtrAnsi> calpstr;

		/// <summary>
		/// If the type indicator is combined with VT_VECTOR by using an OR operator, the value is one of the counted array values. This
		/// creates a DWORD count of elements, followed by a pointer to the specified repetitions of the value. For example, a type indicator
		/// of VT_LPSTR|VT_VECTOR has a DWORD element count, followed by a pointer to an array of LPSTR elements.
		/// </summary>
		[FieldOffset(8)]
		public CA<StrPtrUni> calpwstr;

		/// <summary>
		/// If the type indicator is combined with VT_VECTOR by using an OR operator, the value is one of the counted array values. This
		/// creates a DWORD count of elements, followed by a pointer to the specified repetitions of the value. For example, a type indicator
		/// of VT_LPSTR|VT_VECTOR has a DWORD element count, followed by a pointer to an array of LPSTR elements.
		/// </summary>
		[FieldOffset(8)]
		public CA<PROPVARIANT_UNMGD> capropvar;

		/// <summary>
		/// If the type indicator is combined with VT_BYREF by an OR operator, the value is a reference. Reference types are interpreted as a
		/// reference to data, similar to the reference type in C++ (for example, "int&amp;").
		/// </summary>
		[FieldOffset(8)]
		public StructPointer<sbyte> pcVal;

		/// <summary>
		/// If the type indicator is combined with VT_BYREF by an OR operator, the value is a reference. Reference types are interpreted as a
		/// reference to data, similar to the reference type in C++ (for example, "int&amp;").
		/// </summary>
		[FieldOffset(8)]
		public StructPointer<byte> pbVal;

		/// <summary>
		/// If the type indicator is combined with VT_BYREF by an OR operator, the value is a reference. Reference types are interpreted as a
		/// reference to data, similar to the reference type in C++ (for example, "int&amp;").
		/// </summary>
		[FieldOffset(8)]
		public StructPointer<short> piVal;

		/// <summary>
		/// If the type indicator is combined with VT_BYREF by an OR operator, the value is a reference. Reference types are interpreted as a
		/// reference to data, similar to the reference type in C++ (for example, "int&amp;").
		/// </summary>
		[FieldOffset(8)]
		public StructPointer<ushort> puiVal;

		/// <summary>
		/// If the type indicator is combined with VT_BYREF by an OR operator, the value is a reference. Reference types are interpreted as a
		/// reference to data, similar to the reference type in C++ (for example, "int&amp;").
		/// </summary>
		[FieldOffset(8)]
		public StructPointer<int> plVal;

		/// <summary>
		/// If the type indicator is combined with VT_BYREF by an OR operator, the value is a reference. Reference types are interpreted as a
		/// reference to data, similar to the reference type in C++ (for example, "int&amp;").
		/// </summary>
		[FieldOffset(8)]
		public StructPointer<uint> pulVal;

		/// <summary>
		/// If the type indicator is combined with VT_BYREF by an OR operator, the value is a reference. Reference types are interpreted as a
		/// reference to data, similar to the reference type in C++ (for example, "int&amp;").
		/// </summary>
		[FieldOffset(8)]
		public StructPointer<long> phVal;

		/// <summary>
		/// If the type indicator is combined with VT_BYREF by an OR operator, the value is a reference. Reference types are interpreted as a
		/// reference to data, similar to the reference type in C++ (for example, "int&amp;").
		/// </summary>
		[FieldOffset(8)]
		public StructPointer<ulong> puhVal;

		/// <summary>
		/// If the type indicator is combined with VT_BYREF by an OR operator, the value is a reference. Reference types are interpreted as a
		/// reference to data, similar to the reference type in C++ (for example, "int&amp;").
		/// </summary>
		[FieldOffset(8)]
		public StructPointer<int> pintVal;

		/// <summary>
		/// If the type indicator is combined with VT_BYREF by an OR operator, the value is a reference. Reference types are interpreted as a
		/// reference to data, similar to the reference type in C++ (for example, "int&amp;").
		/// </summary>
		[FieldOffset(8)]
		public StructPointer<uint> puintVal;

		/// <summary>
		/// If the type indicator is combined with VT_BYREF by an OR operator, the value is a reference. Reference types are interpreted as a
		/// reference to data, similar to the reference type in C++ (for example, "int&amp;").
		/// </summary>
		[FieldOffset(8)]
		public StructPointer<float> pfltVal;

		/// <summary>
		/// If the type indicator is combined with VT_BYREF by an OR operator, the value is a reference. Reference types are interpreted as a
		/// reference to data, similar to the reference type in C++ (for example, "int&amp;").
		/// </summary>
		[FieldOffset(8)]
		public StructPointer<double> pdblVal;

		/// <summary>
		/// If the type indicator is combined with VT_BYREF by an OR operator, the value is a reference. Reference types are interpreted as a
		/// reference to data, similar to the reference type in C++ (for example, "int&amp;").
		/// </summary>
		[FieldOffset(8)]
		public StructPointer<VARIANT_BOOL> pboolVal;

		/// <summary>
		/// If the type indicator is combined with VT_BYREF by an OR operator, the value is a reference. Reference types are interpreted as a
		/// reference to data, similar to the reference type in C++ (for example, "int&amp;").
		/// </summary>
		[FieldOffset(8)]
		public StructPointer<DECIMAL> pdecVal;

		/// <summary>
		/// If the type indicator is combined with VT_BYREF by an OR operator, the value is a reference. Reference types are interpreted as a
		/// reference to data, similar to the reference type in C++ (for example, "int&amp;").
		/// </summary>
		[FieldOffset(8)]
		public StructPointer<int> pscode;

		/// <summary>
		/// If the type indicator is combined with VT_BYREF by an OR operator, the value is a reference. Reference types are interpreted as a
		/// reference to data, similar to the reference type in C++ (for example, "int&amp;").
		/// </summary>
		[FieldOffset(8)]
		public StructPointer<CY> pcyVal;

		/// <summary>
		/// If the type indicator is combined with VT_BYREF by an OR operator, the value is a reference. Reference types are interpreted as a
		/// reference to data, similar to the reference type in C++ (for example, "int&amp;").
		/// </summary>
		[FieldOffset(8)]
		public StructPointer<DATE> pdate;

		/// <summary>
		/// If the type indicator is combined with VT_BYREF by an OR operator, the value is a reference. Reference types are interpreted as a
		/// reference to data, similar to the reference type in C++ (for example, "int&amp;").
		/// </summary>
		[FieldOffset(8)]
		public StructPointer<IntPtr> pbstrVal;

		/// <summary>
		/// If the type indicator is combined with VT_BYREF by an OR operator, the value is a reference. Reference types are interpreted as a
		/// reference to data, similar to the reference type in C++ (for example, "int&amp;").
		/// </summary>
		[FieldOffset(8)]
		public StructPointer<IntPtr> ppunkVal;

		/// <summary>
		/// If the type indicator is combined with VT_BYREF by an OR operator, the value is a reference. Reference types are interpreted as a
		/// reference to data, similar to the reference type in C++ (for example, "int&amp;").
		/// </summary>
		[FieldOffset(8)]
		public StructPointer<IntPtr> ppdispVal;

		/// <summary>
		/// If the type indicator is combined with VT_BYREF by an OR operator, the value is a reference. Reference types are interpreted as a
		/// reference to data, similar to the reference type in C++ (for example, "int&amp;").
		/// </summary>
		[FieldOffset(8)]
		public StructPointer<StructPointer<SAFEARRAY>> pparray;

		/// <summary>
		/// If the type indicator is combined with VT_BYREF by an OR operator, the value is a reference. Reference types are interpreted as a
		/// reference to data, similar to the reference type in C++ (for example, "int&amp;").
		/// </summary>
		[FieldOffset(8)]
		public StructPointer<PROPVARIANT_UNMGD> pvarVal;

		/// <summary>Initializes a new instance of the <see cref="PROPVARIANT_UNMGD"/> class with an object.</summary>
		/// <param name="obj">The object to wrap. Based on the object type, it will infer the value type and allocate memory as needed.</param>
		/// <param name="type">If not VT_EMPTY, this value will override the inferred value type.</param>
		public PROPVARIANT_UNMGD(object? obj, VarEnum type = VarEnum.VT_EMPTY) : this()
		{
			if (obj is PROPVARIANT_UNMGD pv)
				PropVariantCopy(ref this, pv);
			else
				SetValue(obj, type);
		}

		/// <summary>Gets the value base on the <see cref="vt"/> value.</summary>
		public object? Value { readonly get => GetValue(); set => SetValue(value); }

		/// <summary>Performs an implicit conversion from <see cref="PROPVARIANT"/> to <see cref="PROPVARIANT_UNMGD"/>.</summary>
		/// <param name="pv">The PROPVARIANT instance.</param>
		/// <returns>The resulting <see cref="PROPVARIANT_UNMGD"/> instance from the conversion.</returns>
		public static implicit operator PROPVARIANT_UNMGD(PROPVARIANT pv) => pv._pv;

		/// <summary>Performs an implicit conversion from <see cref="PROPVARIANT_UNMGD"/> to <see cref="PROPVARIANT"/>.</summary>
		/// <param name="pv">The PROPVARIANT_UNMGD instance.</param>
		/// <returns>The resulting <see cref="PROPVARIANT"/> instance from the conversion.</returns>
		public static explicit operator PROPVARIANT(in PROPVARIANT_UNMGD pv) => new() { _pv = pv };

		/// <summary>Determines whether two PROPVARIANT_UNMGD instances are equal.</summary>
		/// <param name="left">The first PROPVARIANT_UNMGD instance to compare.</param>
		/// <param name="right">The second PROPVARIANT_UNMGD instance to compare.</param>
		/// <returns>true if the specified PROPVARIANT_UNMGD instances are equal; otherwise, false.</returns>
		public static bool operator ==(PROPVARIANT_UNMGD left, PROPVARIANT_UNMGD right) => left.Equals(right);

		/// <summary>Determines whether two PROPVARIANT_UNMGD instances are not equal.</summary>
		/// <param name="left">The first PROPVARIANT_UNMGD instance to compare.</param>
		/// <param name="right">The second PROPVARIANT_UNMGD instance to compare.</param>
		/// <returns>true if the specified instances are not equal; otherwise, false.</returns>
		public static bool operator !=(PROPVARIANT_UNMGD left, PROPVARIANT_UNMGD right) => !(left == right);

		/// <summary>
		/// Frees all elements that can be freed in this instance. For complex elements with known element pointers, the underlying
		/// elements are freed prior to freeing the containing element.
		/// </summary>
		[SecurityCritical, SecuritySafeCritical]
		public void Clear()
		{
			switch (vt)
			{
				case VARTYPE.VT_UNKNOWN:
				case VARTYPE.VT_DISPATCH:
				case VARTYPE.VT_STREAM:
				case VARTYPE.VT_STREAMED_OBJECT:
				case VARTYPE.VT_STORAGE:
				case VARTYPE.VT_STORED_OBJECT:
					if (ptr == default) break;
					Marshal.Release(ptr);
					break;
				case VARTYPE.VT_VECTOR | VARTYPE.VT_VARIANT:
					var pvVector = capropvar.AsSpan();
					for (int i = 0; i < pvVector.Length; i++)
						PropVariantClear(ref pvVector[i]);
					break;
				default:
					break;
			}
			PropVariantClear(ref this);
		}

		/// <summary>Creates a distincyly new instance of <see cref="PROPVARIANT_UNMGD"/> with the same value as the current instance.</summary>
		public readonly PROPVARIANT_UNMGD Clone() { PROPVARIANT_UNMGD dst = new(); PropVariantCopy(ref dst, this).ThrowIfFailed(); return dst; }

		/// <inheritdoc/>
		public readonly int CompareTo(object? other) => other switch
		{
			PROPVARIANT_UNMGD => CompareTo(other),
			PROPVARIANT pv => CompareTo(pv._pv),
			null => GetValue() is null ? 0 : 1,
			_ => GetValue() switch
			{
				null => -1,
				_ => PropVariantChangeType(out var pvDest, this, PROPVAR_CHANGE_FLAGS.PVCHF_DEFAULT, GetVarType(other.GetType())).Succeeded
					? PropVariantCompare(this, new PROPVARIANT(pvDest)._pv)
					: throw new ArgumentException(@"Unable to compare supplied object to PROPVARIANT.", nameof(other)),	
			},
		};

		/// <inheritdoc/>
		public readonly int CompareTo(PROPVARIANT_UNMGD other) => PropVariantCompare(this, other);

		/// <inheritdoc/>
		public readonly override bool Equals(object? obj) => obj switch
		{
			null => GetValue() is not null,
			PROPVARIANT_UNMGD pv => Equals(pv),
			PROPVARIANT pv => Equals(pv._pv),
			_ => object.Equals(obj, Value)
		};

		/// <inheritdoc/>
		public readonly bool Equals(PROPVARIANT_UNMGD other) => PropVariantCompare(this, other) == 0;

		/// <inheritdoc/>
		public readonly override int GetHashCode() => decVal.GetHashCode();

		internal readonly object? GetIUnkVal()
		{
			if (ptr == IntPtr.Zero || (vt & VARTYPE.VT_TYPEMASK) is not (VARTYPE.VT_UNKNOWN or VARTYPE.VT_DISPATCH or VARTYPE.VT_STORAGE or VARTYPE.VT_STORED_OBJECT or VARTYPE.VT_STREAM or VARTYPE.VT_STREAMED_OBJECT)) return null;
			try { return vt.IsFlagSet(VARTYPE.VT_BYREF) && ppunkVal.Value.GetValueOrDefault() != IntPtr.Zero ? Marshal.GetObjectForIUnknown(ppunkVal.Value!.Value) : Marshal.GetObjectForIUnknown(ptr); } catch { return null; }
		}

		internal readonly object?[] GetSafeArray()
		{
			if (ptr == IntPtr.Zero || (vt & VARTYPE.VT_ARRAY) == 0) return [];
			var sa = new SafeSAFEARRAY(ptr, false);
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
				using SafeCoTaskMemHandle mem = new(elemSz);
				SafeArrayGetVartype(sa, out var elemVT);
				Type? elemType = elemVT.GetCorrespondingType();
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

		internal readonly string?[] GetStringVector()
		{
			if (!vt.IsFlagSet(VARTYPE.VT_VECTOR)) return [];
			return (vt & VARTYPE.VT_TYPEMASK) switch
			{
				VARTYPE.VT_LPSTR => [.. blob.pBlobData.ToStringEnum((int)blob.cbSize, CharSet.Ansi)],
				VARTYPE.VT_LPWSTR or VARTYPE.VT_BSTR => GetUniStrings(this),
				_ => []
			};
			static string?[] GetUniStrings(in PROPVARIANT_UNMGD pv) { PropVariantToStringVector(pv, out var vals).ThrowIfFailed(); return vals; }
		}

		public readonly object? GetValue()
		{
			if (vt.IsFlagSet(VARTYPE.VT_ARRAY)) return GetSafeArray();
			var isVector = vt.IsFlagSet(VARTYPE.VT_VECTOR);
			var isRef = vt.IsFlagSet(VARTYPE.VT_BYREF);
			var elemType = vt & VARTYPE.VT_TYPEMASK;
			return elemType switch
			{
				VARTYPE.VT_NULL => DBNull.Value,
				VARTYPE.VT_I1 => isRef ? pcVal.Value : (isVector ? cac.AsSpan().ToArray() : cVal),
				VARTYPE.VT_UI1 => isRef ? pbVal.Value : (isVector ? caub.AsSpan().ToArray() : bVal),
				VARTYPE.VT_I2 => isRef ? piVal.Value : (isVector ? cai.AsSpan().ToArray() : iVal),
				VARTYPE.VT_UI2 => isRef ? puiVal.Value : (isVector ? caui.AsSpan().ToArray() : uiVal),
				VARTYPE.VT_INT or VARTYPE.VT_I4 => isRef ? plVal.Value : (isVector ? cal.AsSpan().ToArray() : lVal),
				VARTYPE.VT_UINT or VARTYPE.VT_UI4 => isRef ? pulVal.Value : (isVector ? caul.AsSpan().ToArray() : ulVal),
				VARTYPE.VT_I8 => isRef ? phVal.Value : (isVector ? cah.AsSpan().ToArray() : hVal),
				VARTYPE.VT_UI8 => isRef ? puhVal.Value : (isVector ? cauh.AsSpan().ToArray() : uhVal),
				VARTYPE.VT_R4 => isRef ? pfltVal.Value : (isVector ? caflt.AsSpan().ToArray() : fltVal),
				VARTYPE.VT_R8 => isRef ? pdblVal.Value : (isVector ? cadbl.AsSpan().ToArray() : dblVal),
				VARTYPE.VT_BOOL => isRef ? (bool?)pboolVal.Value : (isVector ? Array.ConvertAll(cabool.AsSpan().ToArray(), b => (bool)b) : boolVal),
				VARTYPE.VT_ERROR => isRef ? pscode.Value : (isVector ? cascode.AsSpan().ToArray() : scode),
				VARTYPE.VT_HRESULT => isRef ? (!plVal.IsNull ? new HRESULT(plVal.Value.GetValueOrDefault()) : (HRESULT?)null) : (isVector ? Array.ConvertAll(cal.AsSpan().ToArray(), i => new HRESULT(i)) : new HRESULT(lVal)),
				VARTYPE.VT_CY => isRef ? pcyVal.Value : (isVector ? cacy.AsSpan().ToArray() : cyVal),
				VARTYPE.VT_DATE => isRef ? pdate.Value : (isVector ? cadate.AsSpan().ToArray() : date),
				VARTYPE.VT_FILETIME => isRef ? null : (isVector ? cafiletime.AsSpan().ToArray() : filetime),
				VARTYPE.VT_CLSID => isRef ? puuid.Value : (isVector ? cauuid.AsSpan().ToArray() : puuid.Value),
				VARTYPE.VT_CF => isRef ? null : (isVector ? caclipdata.AsSpan().ToArray() : pclipdata.Value),
				VARTYPE.VT_BSTR => isRef ? (pbstrVal.Value.HasValue ? Marshal.PtrToStringBSTR(pbstrVal.Value!.Value) : null) : (isVector ? GetStringVector() : (string?)bstrVal),
				VARTYPE.VT_BLOB => isRef ? (BLOB?)null : (isVector ? cabstrblob.AsSpan().ToArray() : blob),
				VARTYPE.VT_LPSTR => isRef ? (string?)null : (isVector ? GetStringVector() : (string?)pszVal),
				VARTYPE.VT_LPWSTR => isRef ? (string?)null : (isVector ? GetStringVector() : (string?)pwszVal),
				VARTYPE.VT_UNKNOWN or VARTYPE.VT_DISPATCH => isRef ? ppunkVal : (isVector ? null : punkVal),
				VARTYPE.VT_STREAM or VARTYPE.VT_STREAMED_OBJECT => isRef ? pStream : (isVector ? null : pStream),
				VARTYPE.VT_STORAGE or VARTYPE.VT_STORED_OBJECT => isRef ? pStorage : (isVector ? null : pStorage),
				VARTYPE.VT_DECIMAL => isRef ? pdecVal.Value : (isVector ? null : decVal),
				VARTYPE.VT_VARIANT => isVector ? Array.ConvertAll(capropvar.AsSpan().ToArray(), p => new PROPVARIANT(p)) : (pvarVal.IsNull ? (PROPVARIANT?)null : new PROPVARIANT(pvarVal.Value!.Value)),
				VARTYPE.VT_USERDEFINED or VARTYPE.VT_RECORD or VARTYPE.VT_PTR or VARTYPE.VT_VOID => throw new ArgumentOutOfRangeException(nameof(vt), $"{vt}"),
				_ => null,
			};
		}

		/// <summary>Sets the value, clearing any existing value.</summary>
		/// <param name="value">The value.</param>
		/// <param name="vEnum">
		/// If this value equals VT_EMPTY, the method will attempt to ascertain the value type from the <paramref name="value"/>.
		/// </param>
		public void SetValue(object? value, VarEnum vEnum = VarEnum.VT_EMPTY)
		{
			Clear();
			var valueType = value?.GetType();
			var newVT = vt = vEnum == VarEnum.VT_EMPTY ? (value is null ? VARTYPE.VT_EMPTY : valueType.GetVarType()) : (VARTYPE)vEnum;

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
					SetSafeArray([.. ConvertToSequence<object>(value!)]);
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
			if (value != null && !isVector && valueType!.IsArray) vt |= VARTYPE.VT_VECTOR;

			var elemType = vt & VARTYPE.VT_TYPEMASK;

			if (isRef)
			{
				if (!isVector && elemType is VARTYPE.VT_I1 or VARTYPE.VT_UI1 or VARTYPE.VT_I2 or VARTYPE.VT_UI2 or VARTYPE.VT_I4 or VARTYPE.VT_UI4 or VARTYPE.VT_INT or VARTYPE.VT_UINT or VARTYPE.VT_R4 or
					VARTYPE.VT_R8 or VARTYPE.VT_BOOL or VARTYPE.VT_DECIMAL or VARTYPE.VT_ERROR or VARTYPE.VT_CY or VARTYPE.VT_DATE or VARTYPE.VT_BSTR or VARTYPE.VT_UNKNOWN or VARTYPE.VT_DISPATCH or VARTYPE.VT_VARIANT)
				{
					if (valueType == typeof(IntPtr) || (valueType!.IsGenericType && valueType.GetGenericTypeDefinition() == typeof(StructPointer<>)))
						ptr = (IntPtr)value!;
					else if (valueType!.IsPointer)
						unsafe { ptr = (IntPtr)System.Reflection.Pointer.Unbox(value!); }
					//else if (valueType!.IsByRef)
					//	ptr = System.Runtime.CompilerServices.Unsafe.AsPointer();
					//else if ((valueType!.GetElementType() ?? valueType).IsBlittable())
					else
						throw new ArgumentException("VT_BYREF value must be boxed pointer or IntPtr value.", nameof(value));
				}
				else
					throw new ArgumentException("Invalid VT_BYREF value.", nameof(value));
				return;
			}

			var sz = 0U;
			switch (elemType)
			{
				case VARTYPE.VT_I1:
					Init<sbyte>(AllocVector, value!);
					break;

				case VARTYPE.VT_UI1:
					Init<byte>(InitPropVariantFromBuffer, value!);
					break;

				case VARTYPE.VT_I2:
					Init<short>(InitPropVariantFromInt16Vector, value!);
					break;

				case VARTYPE.VT_UI2:
					Init<ushort>(InitPropVariantFromUInt16Vector, value!);
					break;

				case VARTYPE.VT_I4:
				case VARTYPE.VT_INT:
					Init<int>(InitPropVariantFromInt32Vector, value!);
					vt = newVT;
					break;

				case VARTYPE.VT_UI4:
				case VARTYPE.VT_UINT:
					Init<uint>(InitPropVariantFromUInt32Vector, value!);
					vt = newVT;
					break;

				case VARTYPE.VT_I8:
					Init<long>(InitPropVariantFromInt64Vector, value!);
					break;

				case VARTYPE.VT_UI8:
					Init<ulong>(InitPropVariantFromUInt64Vector, value!);
					break;

				case VARTYPE.VT_R4:
					Init<float>(AllocVector, value!);
					break;

				case VARTYPE.VT_R8:
					Init<double>(InitPropVariantFromDoubleVector, value!);
					break;

				case VARTYPE.VT_BOOL:
					static bool MakeBool(object? o) => o switch { null => false, bool b => b, VARIANT_BOOL vb => vb.Value, _ => Convert.ToBoolean(o) };
					if (isVector)
					{
						var ba = ConvertToSequence(value!, MakeBool).ToArray();
						InitPropVariantFromBooleanVector(ba, ref this).ThrowIfFailed();
					}
					else
						SetStruct<VARIANT_BOOL>(new VARIANT_BOOL(MakeBool(value)), vt);
					break;

				case VARTYPE.VT_ERROR:
					Init(InitPropVariantFromUInt32Vector, value!, o => o is Win32Error err ? (uint)err : (uint)Convert.ChangeType(o, typeof(uint)));
					vt = newVT;
					break;

				case VARTYPE.VT_HRESULT:
					Init(InitPropVariantFromInt32Vector, value!, o => o is HRESULT hr ? (int)hr : (int)Convert.ChangeType(o, typeof(int)));
					vt = newVT;
					break;

				case VARTYPE.VT_CY:
					Init(InitPropVariantFromUInt64Vector, value!, o => o switch { decimal d => (ulong)decimal.ToOACurrency(d), CY cy => (ulong)decimal.ToOACurrency(cy.Value), _ => (ulong)Convert.ChangeType(o, typeof(ulong)) });
					vt = newVT;
					break;

				case VARTYPE.VT_DATE:
					Init(InitPropVariantFromDoubleVector, value!, o => o switch { DateTime dt => dt.ToOADate(), DATE d => d.ToDouble(null), FILETIME ft => ft.ToDateTime().ToOADate(), _ => (double)Convert.ChangeType(o, typeof(double)) });
					vt = newVT;
					break;

				case VARTYPE.VT_FILETIME:
					Init(InitPropVariantFromFileTimeVector, value!, o => o switch { DateTime dt => dt.ToFileTimeStruct(), DATE d => d.Value.ToFileTimeStruct(), FILETIME ft => ft, _ => FileTimeExtensions.MakeFILETIME((ulong)Convert.ChangeType(o, typeof(ulong))) });
					break;

				case VARTYPE.VT_CLSID:
					if (isVector)
						AllocVector(GetArray<Guid>(value!, out sz), sz, ref this);
					else
						InitPropVariantFromCLSID(((Guid?)value).GetValueOrDefault(), ref this).ThrowIfFailed();
					break;

				case VARTYPE.VT_CF:
					if (isVector)
						AllocVector(GetArray<CLIPDATA>(value!, out sz), sz, ref this);
					else
						pclipdata = ((CLIPDATA)value!).MarshalToPtr(Marshal.AllocCoTaskMem, out var _);
					break;

				case VARTYPE.VT_BSTR:
					if (isVector)
						SetStringVector(ConvertToSequence<string>(value!), vt);
					else
						ptr = Marshal.StringToBSTR(value!.ToString());
					break;

				case VARTYPE.VT_BLOB:
				case VARTYPE.VT_BLOB_OBJECT:
					if (!isVector && !isRef)
						blob = (BLOB)value!;
					break;

				case VARTYPE.VT_VERSIONED_STREAM:
					if (!isVector && !isRef && value is VERSIONEDSTREAM vs)
						pVersionedStream = vs.MarshalToPtr(Marshal.AllocCoTaskMem, out var _);
					break;

				case VARTYPE.VT_LPSTR:
					if (isVector)
						SetStringVector(ConvertToSequence<string>(value!), vt);
					else
						ptr = Marshal.StringToCoTaskMemAnsi(value?.ToString());
					break;

				case VARTYPE.VT_LPWSTR:
					if (isVector)
						SetStringVector(ConvertToSequence<string>(value!), vt);
					else
						ptr = Marshal.StringToCoTaskMemUni(value?.ToString());
					break;

				case VARTYPE.VT_UNKNOWN:
					static IntPtr ToIUnkPtr(object o) => o as IntPtr? ?? Marshal.GetIUnknownForObject(o);
					if (isVector)
						AllocVector(GetArray(value!, out sz, ToIUnkPtr), sz, ref this);
					else
						SetStruct<IntPtr>(ToIUnkPtr(value!), vt);
					break;

#if !(NETSTANDARD2_0)
				case VARTYPE.VT_DISPATCH:
					static IntPtr ToIDispPtr(object o) => o as IntPtr? ?? Marshal.GetIDispatchForObject(o);
					if (isVector)
						AllocVector(GetArray(value!, out sz, ToIDispPtr), sz, ref this);
					else
						SetStruct<IntPtr>(ToIDispPtr(value!), vt);
					break;
#endif

				case VARTYPE.VT_STREAM:
				case VARTYPE.VT_STREAMED_OBJECT:
					if (!isVector && !isRef)
						SetStruct<IntPtr>(Marshal.GetComInterfaceForObject(value!, typeof(IStream)), vt);
					break;

				case VARTYPE.VT_STORAGE:
				case VARTYPE.VT_STORED_OBJECT:
					if (!isVector && !isRef)
						SetStruct<IntPtr>(Marshal.GetComInterfaceForObject(value!, typeof(IStorage)), vt);
					break;

				case VARTYPE.VT_DECIMAL:
					if (!isVector)
					{
						var tempVt = vt;
						decVal = ((decimal?)value).GetValueOrDefault();
						vt = tempVt;
					}
					break;

				case VARTYPE.VT_VARIANT:
					static PROPVARIANT_UNMGD VariantMake(object o) { PROPVARIANT_UNMGD pvu = new(); VariantToPropVariant(o, ref pvu).ThrowIfFailed(); return pvu; }
					if (isVector)
						AllocVector(GetArray(value!, out sz, o => o switch { PROPVARIANT pv => pv._pv, PROPVARIANT_UNMGD pvu => pvu, _ => VariantMake(o) }), sz, ref this);
					else
						throw new ArgumentException("Cannot set a single PROPVARIANT value. PROPVARIANT arrays are supported, but single PROPVARIANT values are not. Consider using PROPVARIANT directly for single values.", nameof(value));
					break;

				case VARTYPE.VT_USERDEFINED:
				case VARTYPE.VT_RECORD:
				case VARTYPE.VT_VOID:
				case VARTYPE.VT_PTR:
				default:
					throw new ArgumentOutOfRangeException(nameof(value), $"{vt}={value}");
			}

			static HRESULT AllocVector<T>(T[] vector, uint vsz, ref PROPVARIANT_UNMGD pv)
			{
				pv.blob.cbSize = vsz;
				pv.blob.pBlobData = vector.MarshalToPtr<T>(global::System.Runtime.InteropServices.Marshal.AllocCoTaskMem, out var _);
				return HRESULT.S_OK;
			}
		}

		/// <summary>Returns a <see cref="string"/> that represents this instance.</summary>
		/// <returns>A <see cref="string"/> that represents this instance.</returns>
		public override readonly string ToString()
		{
			string s = "";
			if ((vt & (VARTYPE.VT_ARRAY | VARTYPE.VT_VECTOR)) != 0 && Value is IEnumerable ie)
				s = string.Join(",", [.. ie.Cast<object>().Select(o => o.ToString())]);
			else if (PropVariantToStringAlloc(this, out var str).Succeeded)
				s = str;
			return $"{vt}={s ?? "null"}";
		}

		private static IEnumerable<T> ConvertToSequence<T>(object array, Func<object, T>? conv = null)
		{
			if (array is null) return [];

			if (array is IEnumerable<T> iet) return iet;

			conv ??= (o => (T)Convert.ChangeType(o, typeof(T)));

			try
			{
				var ie = array as IEnumerable;
				return ie?.Cast<object>().Select(conv) ?? [conv(array)];
			}
			catch
			{
				return [];
			}
		}

		private static T[] GetArray<T>(object value, out uint len, Func<object, T>? conv = null)
		{
			var ret = ConvertToSequence<T>(value, conv).ToArray();
			len = (uint)ret.Length;
			return ret;
		}

		private void Init<T>(InitFunc<T> init, object value, Func<object, T>? conv = null) where T : struct
		{
			if (vt.IsFlagSet(VARTYPE.VT_VECTOR))
				init(GetArray<T>(value, out uint sz, conv), sz, ref this).ThrowIfFailed();
			else
				SetStruct((T?)(conv?.Invoke(value!) ?? value), vt);
		}

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
			ptr = psa.ReleaseOwnership();
		}

		private void SetSafeArray(SafeSAFEARRAY array)
		{
			SafeArrayCopy(array, out var myArray).ThrowIfFailed();
			ptr = myArray.ReleaseOwnership();
		}

		[SecurityCritical, SecuritySafeCritical]
		private void SetStringVector(IEnumerable<string> value, VARTYPE ve)
		{
			if (value == null) throw new ArgumentNullException(nameof(value));
			calpstr = default;
			var sc = value.ToArray();
			if (sc.Length <= 0) return;
			var svt = ve & VARTYPE.VT_TYPEMASK;
			switch (svt)
			{
				case VARTYPE.VT_BSTR:
					vt = svt | VARTYPE.VT_VECTOR;
					blob.cbSize = (uint)sc.Length;
					blob.pBlobData = value.Select(Marshal.StringToBSTR).MarshalToPtr(Marshal.AllocCoTaskMem, out var _);
					break;

				case VARTYPE.VT_LPSTR:
					vt = svt | VARTYPE.VT_VECTOR;
					blob.cbSize = (uint)sc.Length;
					blob.pBlobData = value.Select(Marshal.StringToCoTaskMemAnsi).MarshalToPtr(Marshal.AllocCoTaskMem, out var _);
					break;

				case VARTYPE.VT_LPWSTR:
					InitPropVariantFromStringVector(sc, ref this).ThrowIfFailed();
					break;

				default:
					throw new ArgumentException("Invalid VarEnum value for a string array.", nameof(ve));
			}
		}

		private void SetStruct<T>(T? value, VARTYPE ve) where T : struct
		{
			if (value.HasValue)
			{
				var byRef = ve.IsFlagSet(VARTYPE.VT_BYREF);
				var type = typeof(T);
				if (type == typeof(IntPtr)) ptr = (IntPtr)(object)value.Value;
				else if (type == typeof(bool)) ptr = (IntPtr)(ushort)((bool)(object)value.Value ? -1 : 0);
				else if (type == typeof(VARIANT_BOOL)) ptr = (IntPtr)(short)(VARIANT_BOOL)(object)value.Value;
				else if (value.Value.GetType().IsPrimitive)
					unsafe { fixed (void* ptr = &uhVal) Marshal.StructureToPtr(value.Value, new IntPtr(ptr), true); }
				else if (type == typeof(FILETIME)) filetime = (FILETIME)(object)value.Value;
				else if (type == typeof(BLOB)) blob = (BLOB)(object)value.Value;
				else throw new ArgumentException($"Unrecognized structure {typeof(T).Name}"); // This would work but there is no means to free this memory. // ptr = value.Value.StructureToPtr());
			}
			else
				vt = VARTYPE.VT_NULL;
		}
	}
}