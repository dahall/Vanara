using System;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.Ole32;

// ReSharper disable InconsistentNaming
// ReSharper disable FieldCanBeMadeReadOnly.Global ReSharper disable InconsistentNaming

namespace Vanara.PInvoke
{
	public static partial class OleAut32
	{
		/// <summary>SafeArray advanced features.</summary>
		[Flags]
		[PInvokeData("OAIdl.h", MSDNShortId = "cc237824")]
		public enum ADVFEATUREFLAGS : ushort
		{
			/// <summary>An array that is allocated on the stack.</summary>
			FADF_AUTO = 0x0001,

			/// <summary>An array that is statically allocated.</summary>
			FADF_STATIC = 0x0002,

			/// <summary>An array that is embedded in a structure.</summary>
			FADF_EMBEDDED = 0x0004,

			/// <summary>An array that may not be resized or reallocated.</summary>
			FADF_FIXEDSIZE = 0x0010,

			/// <summary>
			/// An array that contains records. When set, there will be a pointer to the IRecordInfo interface at negative offset 4 in the array descriptor.
			/// </summary>
			FADF_RECORD = 0x0020,

			/// <summary>
			/// An array that has an IID identifying interface. When set, there will be a GUID at negative offset 16 in the safe array descriptor. Flag is set
			/// only when FADF_DISPATCH or FADF_UNKNOWN is also set.
			/// </summary>
			FADF_HAVEIID = 0x0040,

			/// <summary>An array that has a variant type. The variant type can be retrieved with SafeArrayGetVartype.</summary>
			FADF_HAVEVARTYPE = 0x0080,

			/// <summary>An array of BSTRs.</summary>
			FADF_BSTR = 0x0100,

			/// <summary>An array of IUnknown*.</summary>
			FADF_UNKNOWN = 0x0200,

			/// <summary>An array of IDispatch*.</summary>
			FADF_DISPATCH = 0x0400,

			/// <summary>An array of VARIANTs.</summary>
			FADF_VARIANT = 0x0800
		}

		/// <summary>Increments the lock count of an array, and retrieves a pointer to the array data.</summary>
		/// <remarks>After calling SafeArrayAccessData, you must call the SafeArrayUnaccessData function to unlock the array.</remarks>
		/// <param name="psa">An array descriptor created by SafeArrayCreate.</param>
		/// <param name="ppvData">The array data.</param>
		/// <returns>An HRESULT indicating the outcome of the operation.</returns>
		[DllImport(Lib.OleAut32, ExactSpelling = true)]
		[PInvokeData("OleAuto.h", MSDNShortId = "ms221620")]
		public static extern HRESULT SafeArrayAccessData(SafeSafeArrayDescriptor psa, out IntPtr ppvData);

		/// <summary>Creates a new array descriptor, allocates and initializes the data for the array, and returns a pointer to the new array descriptor.</summary>
		/// <param name="vt">
		/// The base type of the array (the VARTYPE of each element of the array). The VARTYPE is restricted to a subset of the variant types. Neither the
		/// VT_ARRAY nor the VT_BYREF flag can be set. VT_EMPTY and VT_NULL are not valid base types for the array. All other types are legal.
		/// </param>
		/// <param name="cDims">The number of dimensions in the array. The number cannot be changed after the array is created.</param>
		/// <param name="rgsabound">A vector of bounds (one for each dimension) to allocate for the array.</param>
		/// <returns>A safe array descriptor, or null if the array could not be created.</returns>
		[DllImport(Lib.OleAut32, ExactSpelling = true)]
		[PInvokeData("OleAuto.h", MSDNShortId = "ms221234")]
		public static extern IntPtr SafeArrayCreate(VARTYPE vt, uint cDims, ref SAFEARRAYBOUND rgsabound);

		/// <summary>Creates and returns a safe array descriptor from the specified VARTYPE, number of dimensions and bounds.</summary>
		/// <param name="vt">
		/// The base type of the array (the VARTYPE of each element of the array). The VARTYPE is restricted to a subset of the variant types. Neither the
		/// VT_ARRAY nor the VT_BYREF flag can be set. VT_EMPTY and VT_NULL are not valid base types for the array. All other types are legal.
		/// </param>
		/// <param name="cDims">The number of dimensions in the array. The number cannot be changed after the array is created.</param>
		/// <param name="rgsabound">A vector of bounds (one for each dimension) to allocate for the array.</param>
		/// <param name="pvExtra">
		/// The type information of the user-defined type, if you are creating a safe array of user-defined types. If the vt parameter is VT_RECORD, then pvExtra
		/// will be a pointer to an IRecordInfo describing the record. If the vt parameter is VT_DISPATCH or VT_UNKNOWN, then pvExtra will contain a pointer to a
		/// GUID representing the type of interface being passed to the array.
		/// </param>
		/// <returns>A safe array descriptor, or null if the array could not be created.</returns>
		[DllImport(Lib.OleAut32, ExactSpelling = true)]
		[PInvokeData("OleAuto.h", MSDNShortId = "ms221198")]
		public static extern IntPtr SafeArrayCreateEx(VARTYPE vt, uint cDims, ref SAFEARRAYBOUND rgsabound, IntPtr pvExtra);

		/// <summary>
		/// Creates a one-dimensional array. A safe array created with SafeArrayCreateVector is a fixed size, so the constant FADF_FIXEDSIZE is always set.
		/// </summary>
		/// <param name="vt">
		/// The base type of the array (the VARTYPE of each element of the array). The VARTYPE is restricted to a subset of the variant types. Neither the
		/// VT_ARRAY nor the VT_BYREF flag can be set. VT_EMPTY and VT_NULL are not valid base types for the array. All other types are legal.
		/// </param>
		/// <param name="lowerBound">The lower bound for the array. This parameter can be negative.</param>
		/// <param name="cElems">The number of elements in the array.</param>
		/// <returns>A safe array descriptor, or null if the array could not be created.</returns>
		[DllImport(Lib.OleAut32, ExactSpelling = true)]
		[PInvokeData("OleAuto.h", MSDNShortId = "ms221558")]
		public static extern IntPtr SafeArrayCreateVector(VARTYPE vt, int lowerBound, uint cElems);

		/// <summary>
		/// Destroys an existing array descriptor and all of the data in the array. If objects are stored in the array, Release is called on each object in the array.
		/// </summary>
		/// <param name="psa">An array descriptor created by SafeArrayCreate.</param>
		/// <returns>An HRESULT indicating the outcome of the operation.</returns>
		[DllImport(Lib.OleAut32, ExactSpelling = true)]
		[PInvokeData("OleAuto.h", MSDNShortId = "ms221702")]
		public static extern HRESULT SafeArrayDestroy(IntPtr psa);

		/// <summary>Gets the number of dimensions in the array.</summary>
		/// <param name="psa">An array descriptor created by SafeArrayCreate.</param>
		/// <returns>The number of dimensions in the array.</returns>
		[DllImport(Lib.OleAut32, ExactSpelling = true)]
		[PInvokeData("OleAuto.h", MSDNShortId = "ms221539")]
		public static extern uint SafeArrayGetDim(SafeSafeArrayDescriptor psa);

		/// <summary>Retrieves a single element of the array.</summary>
		/// <param name="psa">An array descriptor created by SafeArrayCreate.</param>
		/// <param name="rgIndices">
		/// A vector of indexes for each dimension of the array. The right-most (least significant) dimension is rgIndices[0]. The left-most dimension is stored
		/// at rgIndices[psa-&gt;cDims – 1].
		/// </param>
		/// <param name="pv">The element of the array.</param>
		/// <returns>An HRESULT indicating the outcome of the operation.</returns>
		[DllImport(Lib.OleAut32, ExactSpelling = true)]
		[PInvokeData("OleAuto.h", MSDNShortId = "ms221255")]
		public static extern HRESULT SafeArrayGetElement(SafeSafeArrayDescriptor psa, [MarshalAs(UnmanagedType.LPArray)] int[] rgIndices, [Out] IntPtr pv);

		/// <summary>Gets the size of an element.</summary>
		/// <param name="pSafeArray">An array descriptor created by SafeArrayCreate.</param>
		/// <returns>The size of an element in a safe array, in bytes.</returns>
		[DllImport(Lib.OleAut32, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("OleAuto.h", MSDNShortId = "ms221074")]
		public static extern int SafeArrayGetElemsize(SafeSafeArrayDescriptor pSafeArray);

		/// <summary>Gets the lower bound for any dimension of the specified safe array.</summary>
		/// <param name="psa">An array descriptor created by SafeArrayCreate.</param>
		/// <param name="nDim">The array dimension for which to get the lower bound.</param>
		/// <param name="plLbound">The lower bound.</param>
		/// <returns>An HRESULT indicating the outcome of the operation.</returns>
		[DllImport(Lib.OleAut32, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("OleAuto.h", MSDNShortId = "ms221622")]
		public static extern HRESULT SafeArrayGetLBound(SafeSafeArrayDescriptor psa, uint nDim, out int plLbound);

		/// <summary>Gets the upper bound for any dimension of the specified safe array.</summary>
		/// <param name="psa">An array descriptor created by SafeArrayCreate.</param>
		/// <param name="nDim">The array dimension for which to get the upper bound.</param>
		/// <param name="plUbound">The upper bound.</param>
		/// <returns>An HRESULT indicating the outcome of the operation.</returns>
		[DllImport(Lib.OleAut32, ExactSpelling = true)]
		[PInvokeData("OleAuto.h", MSDNShortId = "ms221584")]
		public static extern HRESULT SafeArrayGetUBound(SafeSafeArrayDescriptor psa, uint nDim, out int plUbound);

		/// <summary>Stores the data element at the specified location in the array.</summary>
		/// <param name="psa">An array descriptor created by SafeArrayCreate.</param>
		/// <param name="rgIndicies">
		/// A vector of indexes for each dimension of the array. The right-most (least significant) dimension is rgIndices[0]. The left-most dimension is stored
		/// at rgIndices[psa-&gt;cDims – 1].
		/// </param>
		/// <param name="pv">
		/// The data to assign to the array. The variant types VT_DISPATCH, VT_UNKNOWN, and VT_BSTR are pointers, and do not require another level of indirection.
		/// </param>
		/// <returns>An HRESULT indicating the outcome of the operation.</returns>
		[DllImport(Lib.OleAut32, ExactSpelling = true)]
		[PInvokeData("OleAuto.h", MSDNShortId = "ms221283")]
		public static extern HRESULT SafeArrayPutElement(SafeSafeArrayDescriptor psa, [MarshalAs(UnmanagedType.LPArray)] int[] rgIndicies, [In] IntPtr pv);

		/// <summary>Decrements the lock count of an array, and invalidates the pointer retrieved by SafeArrayAccessData.</summary>
		/// <param name="psa">An array descriptor created by SafeArrayCreate.</param>
		/// <returns>An HRESULT indicating the outcome of the operation.</returns>
		[DllImport(Lib.OleAut32, ExactSpelling = true)]
		[PInvokeData("OleAuto.h", MSDNShortId = "ms221203")]
		public static extern HRESULT SafeArrayUnaccessData(SafeSafeArrayDescriptor psa);

		/// <summary>Represents a safe array.</summary>
		/// <seealso cref="System.IDisposable"/>
		[StructLayout(LayoutKind.Sequential, Pack = 4)]
		[PInvokeData("OaIdl.h", MSDNShortId = "ms221482")]
		public struct SAFEARRAY
		{
			/// <summary>The number of dimensions.</summary>
			public ushort cDims;

			/// <summary>Flags.</summary>
			public ADVFEATUREFLAGS fFeatures;

			/// <summary>The size of an array element.</summary>
			public uint cbElements;

			/// <summary>The number of times the array has been locked without a corresponding unlock.</summary>
			public uint cLocks;

			/// <summary>The data.</summary>
			public IntPtr pvData;

			/// <summary>One bound for each dimension.</summary>
			public IntPtr rgsabound;

			/// <summary>Gets the bounds pointed to by <see cref="rgsabound"/>.</summary>
			public SAFEARRAYBOUND[] Bounds => rgsabound.ToArray<SAFEARRAYBOUND>(cDims);
		}

		/// <summary>Represents the bounds of one dimension of the array.</summary>
		[StructLayout(LayoutKind.Sequential, Pack = 4)]
		[PInvokeData("OaIdl.h", MSDNShortId = "ms221167")]
		public struct SAFEARRAYBOUND
		{
			/// <summary>The number of elements in the dimension.</summary>
			public uint cElements;

			/// <summary>The lower bound of the dimension.</summary>
			public int lLbound;
		}

		/// <summary>Construct for handling the paired calling of <see cref="SafeArrayAccessData"/> and <see cref="SafeArrayUnaccessData"/>.</summary>
		/// <example>
		/// <code>
		/// using (var data = new SafeArrayScopedAccessData(safeArray))
		/// {
		///    // The Data property provides access to the array's data while in scope.
		///    FILETIME ft = (FILETIME)Marshal.PtrToStructure(data.Data, typeof(FILETIME));
		/// }
		/// </code>
		/// </example>
		/// <seealso cref="System.IDisposable"/>
		[PInvokeData("OleAuto.h")]
		public class SafeArrayScopedAccessData : IDisposable
		{
			private IntPtr ppvData;
			private readonly IntPtr psa;

			/// <summary>Initializes a new instance of the <see cref="SafeArrayScopedAccessData"/> class using the array descriptor that holds the data.</summary>
			/// <param name="psa">An array descriptor created by SafeArrayCreate.</param>
			public SafeArrayScopedAccessData(IntPtr psa)
			{
				var hr = SafeArrayAccessData(psa, out ppvData);
				hr.ThrowIfFailed();
				this.psa = psa;
			}

			/// <summary>Gets the pointer exposed by the call to <see cref="SafeArrayAccessData"/>.</summary>
			/// <value>A pointer to the raw data within the array descriptor.</value>
			public IntPtr Data => ppvData;

			/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
			public void Dispose()
			{
				SafeArrayUnaccessData(psa);
				ppvData = IntPtr.Zero;
			}
		}

		/// <summary>A <see cref="SafeHandle"/> for holding array descriptors where <see cref="SafeArrayDestroy(IntPtr)"/> is called when disposed.</summary>
		/// <seealso cref="GenericSafeHandle"/>
		[PInvokeData("OleAuto.h")]
		public class SafeSafeArrayDescriptor : GenericSafeHandle
		{
			/// <summary>Initializes an empty instance of the <see cref="SafeSafeArrayDescriptor"/> class.</summary>
			public SafeSafeArrayDescriptor() : this(IntPtr.Zero) { }

			/// <summary>Initializes a new instance of the <see cref="SafeSafeArrayDescriptor"/> class using an existing array descriptor.</summary>
			/// <param name="psa">An array descriptor created by SafeArrayCreate.</param>
			/// <param name="own">if set to <c>true</c> this <see cref="SafeHandle"/> will call <see cref="SafeArrayDestroy(IntPtr)"/> when disposed.</param>
			public SafeSafeArrayDescriptor(IntPtr psa, bool own = true) : base(psa, h => SafeArrayDestroy(h).Succeeded, own) { }

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="SafeSafeArrayDescriptor"/>.</summary>
			/// <param name="psa">An array descriptor created by SafeArrayCreate.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator SafeSafeArrayDescriptor(IntPtr psa) => new SafeSafeArrayDescriptor(psa);
		}
	}
}