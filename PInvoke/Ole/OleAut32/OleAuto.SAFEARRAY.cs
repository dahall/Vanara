using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.Ole32;

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
			/// An array that contains records. When set, there will be a pointer to the IRecordInfo interface at negative offset 4 in the
			/// array descriptor.
			/// </summary>
			FADF_RECORD = 0x0020,

			/// <summary>
			/// An array that has an IID identifying interface. When set, there will be a GUID at negative offset 16 in the safe array
			/// descriptor. Flag is set only when FADF_DISPATCH or FADF_UNKNOWN is also set.
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

		/// <summary>
		/// <para>Increments the lock count of an array, and retrieves a pointer to the array data.</para>
		/// </summary>
		/// <param name="psa">
		/// <para>An array descriptor created by SafeArrayCreate.</para>
		/// </param>
		/// <param name="ppvData">
		/// <para>The array data.</para>
		/// </param>
		/// <returns>
		/// <para>This function can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Success.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The argument psa is not valid.</term>
		/// </item>
		/// <item>
		/// <term>E_UNEXPECTED</term>
		/// <term>The array could not be locked.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>After calling <c>SafeArrayAccessData</c>, you must call the SafeArrayUnaccessData function to unlock the array.</para>
		/// <para>Examples</para>
		/// <para>
		/// The following example sorts a safe array of one dimension that contains BSTRs by accessing the array elements directly. This
		/// approach is faster than using SafeArrayGetElement and SafeArrayPutElement.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/oleauto/nf-oleauto-safearrayaccessdata HRESULT SafeArrayAccessData( SAFEARRAY
		// *psa, void HUGEP **ppvData );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "ded2112e-f6cd-4982-bacb-b95370e80187")]
		public static extern HRESULT SafeArrayAccessData(SafeSAFEARRAY psa, out IntPtr ppvData);

		/// <summary>
		/// <para>
		/// The safe array for which the pinning reference count of the descriptor should increase. While that count remains greater than 0,
		/// the memory for the descriptor is prevented from being freed by calls to the SafeArrayDestroy or SafeArrayDestroyDescriptor functions.
		/// </para>
		/// <para>
		/// Returns the safe array data for which a pinning reference was added, if <c>SafeArrayAddRef</c> also added a pinning reference
		/// for the safe array data. This parameter is NULL if <c>SafeArrayAddRef</c> did not add a pinning reference for the safe array
		/// data. <c>SafeArrayAddRef</c> does not add a pinning reference for the safe array data if that safe array data was not
		/// dynamically allocated.
		/// </para>
		/// </summary>
		/// <param name="psa">
		/// <para>
		/// The safe array for which the pinning reference count of the descriptor should increase. While that count remains greater than 0,
		/// the memory for the descriptor is prevented from being freed by calls to the SafeArrayDestroy or SafeArrayDestroyDescriptor functions.
		/// </para>
		/// </param>
		/// <param name="ppDataToRelease">
		/// <para>
		/// Returns the safe array data for which a pinning reference was added, if <c>SafeArrayAddRef</c> also added a pinning reference
		/// for the safe array data. This parameter is NULL if <c>SafeArrayAddRef</c> did not add a pinning reference for the safe array
		/// data. <c>SafeArrayAddRef</c> does not add a pinning reference for the safe array data if that safe array data was not
		/// dynamically allocated.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Safe arrays have not traditionally had a reference count. All existing usage of safe arrays will continue to work with no
		/// changes. The <c>SafeArrayAddRef</c>, SafeArrayReleaseData, SafeArrayReleaseDescriptor functions add the ability to use reference
		/// counting to pin the safe array into memory before calling from an untrusted script into an IDispatch method that may not expect
		/// the script to free that memory before the method returns, so that the script cannot force the code for that method into
		/// accessing memory that has been freed. After such a method safely returns, the pinning references should be released. You can
		/// release the pinning references by calling the following functions:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>SafeArrayReleaseData, for the data that the ppDataToRelease parameter points to, if it is not null.</term>
		/// </item>
		/// <item>
		/// <term>SafeArrayReleaseDescriptor, for the descriptor that the psa parameter specifies.</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/oleauto/nf-oleauto-safearrayaddref HRESULT SafeArrayAddRef( SAFEARRAY *psa,
		// PVOID *ppDataToRelease );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "0745D2E7-447E-4688-ADCF-1F889BC55BFB")]
		public static extern HRESULT SafeArrayAddRef(SafeSAFEARRAY psa, out IntPtr ppDataToRelease);

		/// <summary>
		/// <para>Allocates memory for a safe array, based on a descriptor created with SafeArrayAllocDescriptor.</para>
		/// </summary>
		/// <param name="psa">
		/// <para>A safe array descriptor created by SafeArrayAllocDescriptor.</para>
		/// </param>
		/// <returns>
		/// <para>This function can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Success.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The argument psa is not valid.</term>
		/// </item>
		/// <item>
		/// <term>E_UNEXPECTED</term>
		/// <term>The array could not be locked.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/oleauto/nf-oleauto-safearrayallocdata HRESULT SafeArrayAllocData( SAFEARRAY
		// *psa );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "a1f984cd-9638-415d-8582-25b1bdfbd694")]
		public static extern HRESULT SafeArrayAllocData(SafeDescriptorSAFEARRAY psa);

		/// <summary>
		/// <para>Allocates memory for a safe array descriptor.</para>
		/// </summary>
		/// <param name="cDims">
		/// <para>The number of dimensions of the array.</para>
		/// </param>
		/// <param name="ppsaOut">
		/// <para>The safe array descriptor.</para>
		/// </param>
		/// <returns>
		/// <para>This function can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Success.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The argument psa was not valid.</term>
		/// </item>
		/// <item>
		/// <term>E_UNEXPECTED</term>
		/// <term>The array could not be locked.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This function allows the creation of safe arrays that contain elements with data types other than those provided by
		/// SafeArrayCreate. After creating an array descriptor using <c>SafeArrayAllocDescriptor</c>, set the element size in the array
		/// descriptor, an call SafeArrayAllocData to allocate memory for the array elements.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following example creates a safe array using the <c>SafeArrayAllocDescriptor</c> and SafeArrayAllocData functions.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/oleauto/nf-oleauto-safearrayallocdescriptor HRESULT
		// SafeArrayAllocDescriptor( UINT cDims, SAFEARRAY **ppsaOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "8fe5c802-cdc0-4e7a-9410-ba65f9a5140e")]
		public static extern HRESULT SafeArrayAllocDescriptor(uint cDims, out SafeDescriptorSAFEARRAY ppsaOut);

		/// <summary>
		/// <para>
		/// Creates a safe array descriptor for an array of any valid variant type, including VT_RECORD, without allocating the array data.
		/// </para>
		/// </summary>
		/// <param name="vt">
		/// <para>The variant type.</para>
		/// </param>
		/// <param name="cDims">
		/// <para>The number of dimensions in the array.</para>
		/// </param>
		/// <param name="ppsaOut">
		/// <para>The safe array descriptor.</para>
		/// </param>
		/// <returns>
		/// <para>This function can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Success.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The argument psa was not valid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Because SafeArrayAllocDescriptor does not take a VARTYPE, it is not possible to use it to create the safe array descriptor for
		/// an array of records. The <c>SafeArrayAllocDescriptorEx</c> is used to allocate a safe array descriptor for an array of records
		/// of the given dimensions.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/oleauto/nf-oleauto-safearrayallocdescriptorex HRESULT
		// SafeArrayAllocDescriptorEx( VARTYPE vt, UINT cDims, SAFEARRAY **ppsaOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "c368d278-ef62-4cf3-a7f8-c48549207c09")]
		public static extern HRESULT SafeArrayAllocDescriptorEx(VARTYPE vt, uint cDims, out SafeDescriptorSAFEARRAY ppsaOut);

		/// <summary>
		/// <para>Creates a copy of an existing safe array.</para>
		/// </summary>
		/// <param name="psa">
		/// <para>A safe array descriptor created by SafeArrayCreate.</para>
		/// </param>
		/// <param name="ppsaOut">
		/// <para>The safe array descriptor.</para>
		/// </param>
		/// <returns>
		/// <para>This function can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Success.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The argument psa was not valid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>Insufficient memory to complete the operation.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>SafeArrayCopy</c> calls the string or variant manipulation functions if the array to copy contains either of these data
		/// types. If the array being copied contains object references, the reference counts for the objects are incremented.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/oleauto/nf-oleauto-safearraycopy HRESULT SafeArrayCopy( SAFEARRAY *psa,
		// SAFEARRAY **ppsaOut );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "8f84d4f6-1852-4ad8-b174-f3fa37e5bbd6")]
		public static extern HRESULT SafeArrayCopy(SafeSAFEARRAY psa, out SafeSAFEARRAY ppsaOut);

		/// <summary>
		/// <para>
		/// Copies the source array to the specified target array after releasing any resources in the target array. This is similar to
		/// SafeArrayCopy, except that the target array has to be set up by the caller. The target is not allocated or reallocated.
		/// </para>
		/// </summary>
		/// <param name="psaSource">
		/// <para>The safe array to copy.</para>
		/// </param>
		/// <param name="psaTarget">
		/// <para>The target safe array.</para>
		/// </param>
		/// <returns>
		/// <para>This function can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Success.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The argument psa was not valid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>Insufficient memory to complete the operation.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/oleauto/nf-oleauto-safearraycopydata HRESULT SafeArrayCopyData( SAFEARRAY
		// *psaSource, SAFEARRAY *psaTarget );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "32c1fc4f-3fe0-490f-b5af-640514a8cecc")]
		public static extern HRESULT SafeArrayCopyData(SafeSAFEARRAY psaSource, SafeSAFEARRAY psaTarget);

		/// <summary>
		/// <para>
		/// Creates a new array descriptor, allocates and initializes the data for the array, and returns a pointer to the new array descriptor.
		/// </para>
		/// </summary>
		/// <param name="vt">
		/// <para>
		/// The base type of the array (the VARTYPE of each element of the array). The VARTYPE is restricted to a subset of the variant
		/// types. Neither the VT_ARRAY nor the VT_BYREF flag can be set. VT_EMPTY and VT_NULL are not valid base types for the array. All
		/// other types are legal.
		/// </para>
		/// </param>
		/// <param name="cDims">
		/// <para>The number of dimensions in the array. The number cannot be changed after the array is created.</para>
		/// </param>
		/// <param name="rgsabound">
		/// <para>A vector of bounds (one for each dimension) to allocate for the array.</para>
		/// </param>
		/// <returns>
		/// <para>A safe array descriptor, or null if the array could not be created.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/oleauto/nf-oleauto-safearraycreate SAFEARRAY * SafeArrayCreate( VARTYPE vt,
		// UINT cDims, SAFEARRAYBOUND *rgsabound );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "5b94f1a2-a558-473f-85dd-9545c0464cc7")]
		public static extern SafeSAFEARRAY SafeArrayCreate(VARTYPE vt, uint cDims, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] SAFEARRAYBOUND[] rgsabound);

		/// <summary>
		/// <para>Creates and returns a safe array descriptor from the specified VARTYPE, number of dimensions and bounds.</para>
		/// </summary>
		/// <param name="vt">
		/// <para>
		/// The base type or the VARTYPE of each element of the array. The FADF_RECORD flag can be set for a variant type VT_RECORD, The
		/// FADF_HAVEIID flag can be set for VT_DISPATCH or VT_UNKNOWN, and FADF_HAVEVARTYPE can be set for all other VARTYPEs.
		/// </para>
		/// </param>
		/// <param name="cDims">
		/// <para>The number of dimensions in the array.</para>
		/// </param>
		/// <param name="rgsabound">
		/// <para>A vector of bounds (one for each dimension) to allocate for the array.</para>
		/// </param>
		/// <param name="pvExtra">
		/// <para>
		/// the type information of the user-defined type, if you are creating a safe array of user-defined types. If the vt parameter is
		/// VT_RECORD, then pvExtra will be a pointer to an IRecordInfo describing the record. If the vt parameter is VT_DISPATCH or
		/// VT_UNKNOWN, then pvExtra will contain a pointer to a GUID representing the type of interface being passed to the array.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>A safe array descriptor, or null if the array could not be created.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If the VARTYPE is VT_RECORD then SafeArraySetRecordInfo is called. If the VARTYPE is VT_DISPATCH or VT_UNKNOWN then the elements
		/// of the array must contain interfaces of the same type. Part of the process of marshaling this array to other processes does
		/// include generating the proxy/stub code of the IID pointed to by the pvExtra parameter. To actually pass heterogeneous interfaces
		/// one will need to specify either IID_IUnknown or IID_IDispatch in pvExtra and provide some other means for the caller to identify
		/// how to query for the actual interface.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following example describes how a safe array of user-defined types is stored into a variant of type VT_RECORD.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/oleauto/nf-oleauto-safearraycreateex SAFEARRAY * SafeArrayCreateEx( VARTYPE
		// vt, UINT cDims, SAFEARRAYBOUND *rgsabound, PVOID pvExtra );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "63117428-6676-4fb5-a0ae-7e3b22546d77")]
		// public static extern SAFEARRAY * SafeArrayCreateEx(VARTYPE vt, uint cDims, ref SAFEARRAYBOUND rgsabound, IntPtr pvExtra);
		public static extern SafeSAFEARRAY SafeArrayCreateEx(VARTYPE vt, uint cDims, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] SAFEARRAYBOUND[] rgsabound, IntPtr pvExtra);

		/// <summary>
		/// <para>Creates and returns a safe array descriptor from the specified VARTYPE, number of dimensions and bounds.</para>
		/// </summary>
		/// <param name="vt">
		/// <para>
		/// The base type or the VARTYPE of each element of the array. The FADF_RECORD flag can be set for a variant type VT_RECORD, The
		/// FADF_HAVEIID flag can be set for VT_DISPATCH or VT_UNKNOWN, and FADF_HAVEVARTYPE can be set for all other VARTYPEs.
		/// </para>
		/// </param>
		/// <param name="cDims">
		/// <para>The number of dimensions in the array.</para>
		/// </param>
		/// <param name="rgsabound">
		/// <para>A vector of bounds (one for each dimension) to allocate for the array.</para>
		/// </param>
		/// <param name="pvExtra">
		/// <para>
		/// the type information of the user-defined type, if you are creating a safe array of user-defined types. If the vt parameter is
		/// VT_RECORD, then pvExtra will be a pointer to an IRecordInfo describing the record. If the vt parameter is VT_DISPATCH or
		/// VT_UNKNOWN, then pvExtra will contain a pointer to a GUID representing the type of interface being passed to the array.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>A safe array descriptor, or null if the array could not be created.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If the VARTYPE is VT_RECORD then SafeArraySetRecordInfo is called. If the VARTYPE is VT_DISPATCH or VT_UNKNOWN then the elements
		/// of the array must contain interfaces of the same type. Part of the process of marshaling this array to other processes does
		/// include generating the proxy/stub code of the IID pointed to by the pvExtra parameter. To actually pass heterogeneous interfaces
		/// one will need to specify either IID_IUnknown or IID_IDispatch in pvExtra and provide some other means for the caller to identify
		/// how to query for the actual interface.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following example describes how a safe array of user-defined types is stored into a variant of type VT_RECORD.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/oleauto/nf-oleauto-safearraycreateex SAFEARRAY * SafeArrayCreateEx( VARTYPE
		// vt, UINT cDims, SAFEARRAYBOUND *rgsabound, PVOID pvExtra );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "63117428-6676-4fb5-a0ae-7e3b22546d77")]
		// public static extern SAFEARRAY * SafeArrayCreateEx(VARTYPE vt, uint cDims, ref SAFEARRAYBOUND rgsabound, IntPtr pvExtra);
		public static extern SafeSAFEARRAY SafeArrayCreateEx(VARTYPE vt, uint cDims, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] SAFEARRAYBOUND[] rgsabound, IRecordInfo pvExtra);

		/// <summary>
		/// <para>Creates and returns a safe array descriptor from the specified VARTYPE, number of dimensions and bounds.</para>
		/// </summary>
		/// <param name="vt">
		/// <para>
		/// The base type or the VARTYPE of each element of the array. The FADF_RECORD flag can be set for a variant type VT_RECORD, The
		/// FADF_HAVEIID flag can be set for VT_DISPATCH or VT_UNKNOWN, and FADF_HAVEVARTYPE can be set for all other VARTYPEs.
		/// </para>
		/// </param>
		/// <param name="cDims">
		/// <para>The number of dimensions in the array.</para>
		/// </param>
		/// <param name="rgsabound">
		/// <para>A vector of bounds (one for each dimension) to allocate for the array.</para>
		/// </param>
		/// <param name="pvExtra">
		/// <para>
		/// the type information of the user-defined type, if you are creating a safe array of user-defined types. If the vt parameter is
		/// VT_RECORD, then pvExtra will be a pointer to an IRecordInfo describing the record. If the vt parameter is VT_DISPATCH or
		/// VT_UNKNOWN, then pvExtra will contain a pointer to a GUID representing the type of interface being passed to the array.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>A safe array descriptor, or null if the array could not be created.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If the VARTYPE is VT_RECORD then SafeArraySetRecordInfo is called. If the VARTYPE is VT_DISPATCH or VT_UNKNOWN then the elements
		/// of the array must contain interfaces of the same type. Part of the process of marshaling this array to other processes does
		/// include generating the proxy/stub code of the IID pointed to by the pvExtra parameter. To actually pass heterogeneous interfaces
		/// one will need to specify either IID_IUnknown or IID_IDispatch in pvExtra and provide some other means for the caller to identify
		/// how to query for the actual interface.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following example describes how a safe array of user-defined types is stored into a variant of type VT_RECORD.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/oleauto/nf-oleauto-safearraycreateex SAFEARRAY * SafeArrayCreateEx( VARTYPE
		// vt, UINT cDims, SAFEARRAYBOUND *rgsabound, PVOID pvExtra );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "63117428-6676-4fb5-a0ae-7e3b22546d77")]
		// public static extern SAFEARRAY * SafeArrayCreateEx(VARTYPE vt, uint cDims, ref SAFEARRAYBOUND rgsabound, IntPtr pvExtra);
		public static extern SafeSAFEARRAY SafeArrayCreateEx(VARTYPE vt, uint cDims, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] SAFEARRAYBOUND[] rgsabound, in Guid pvExtra);

		/// <summary>
		/// <para>
		/// Creates a one-dimensional array. A safe array created with <c>SafeArrayCreateVector</c> is a fixed size, so the constant
		/// FADF_FIXEDSIZE is always set.
		/// </para>
		/// </summary>
		/// <param name="vt">
		/// <para>
		/// The base type of the array (the VARTYPE of each element of the array). The VARTYPE is restricted to a subset of the variant
		/// types. Neither the VT_ARRAY nor the VT_BYREF flag can be set. VT_EMPTY and VT_NULL are not valid base types for the array. All
		/// other types are legal.
		/// </para>
		/// </param>
		/// <param name="lLbound">
		/// <para>The lower bound for the array. This parameter can be negative.</para>
		/// </param>
		/// <param name="cElements">
		/// <para>The number of elements in the array.</para>
		/// </param>
		/// <returns>
		/// <para>A safe array descriptor, or null if the array could not be created.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/oleauto/nf-oleauto-safearraycreatevector SAFEARRAY * SafeArrayCreateVector(
		// VARTYPE vt, LONG lLbound, ULONG cElements );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "b794b8c6-a523-4636-8681-a936dff3fc6f")]
		public static extern SafeSAFEARRAY SafeArrayCreateVector(VARTYPE vt, int lLbound, uint cElements);

		/// <summary>
		/// <para>Creates and returns a one-dimensional safe array of the specified VARTYPE and bounds.</para>
		/// </summary>
		/// <param name="vt">
		/// <para>
		/// The base type of the array (the VARTYPE of each element of the array). The FADF_RECORD flag can be set for VT_RECORD. The
		/// FADF_HAVEIID can be set for VT_DISPATCH or VT_UNKNOWN and FADF_HAVEVARTYPE can be set for all other types.
		/// </para>
		/// </param>
		/// <param name="lLbound">
		/// <para>The lower bound for the array. This parameter can be negative.</para>
		/// </param>
		/// <param name="cElements">
		/// <para>The number of elements in the array.</para>
		/// </param>
		/// <param name="pvExtra">
		/// <para>
		/// The type information of the user-defined type, if you are creating a safe array of user-defined types. If the vt parameter is
		/// VT_RECORD, then pvExtra will be a pointer to an IRecordInfo describing the record. If the vt parameter is VT_DISPATCH or
		/// VT_UNKNOWN, then pvExtra will contain a pointer to a GUID representing the type of interface being passed to the array.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>A safe array descriptor, or null if the array could not be created.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/oleauto/nf-oleauto-safearraycreatevectorex SAFEARRAY *
		// SafeArrayCreateVectorEx( VARTYPE vt, LONG lLbound, ULONG cElements, PVOID pvExtra );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "45f2ba42-4189-42eb-9f6c-772198296906")]
		public static extern SafeSAFEARRAY SafeArrayCreateVectorEx(VARTYPE vt, int lLbound, uint cElements, IntPtr pvExtra);

		/// <summary>
		/// <para>Creates and returns a one-dimensional safe array of the specified VARTYPE and bounds.</para>
		/// </summary>
		/// <param name="vt">
		/// <para>
		/// The base type of the array (the VARTYPE of each element of the array). The FADF_RECORD flag can be set for VT_RECORD. The
		/// FADF_HAVEIID can be set for VT_DISPATCH or VT_UNKNOWN and FADF_HAVEVARTYPE can be set for all other types.
		/// </para>
		/// </param>
		/// <param name="lLbound">
		/// <para>The lower bound for the array. This parameter can be negative.</para>
		/// </param>
		/// <param name="cElements">
		/// <para>The number of elements in the array.</para>
		/// </param>
		/// <param name="pvExtra">
		/// <para>
		/// The type information of the user-defined type, if you are creating a safe array of user-defined types. If the vt parameter is
		/// VT_RECORD, then pvExtra will be a pointer to an IRecordInfo describing the record. If the vt parameter is VT_DISPATCH or
		/// VT_UNKNOWN, then pvExtra will contain a pointer to a GUID representing the type of interface being passed to the array.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>A safe array descriptor, or null if the array could not be created.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/oleauto/nf-oleauto-safearraycreatevectorex SAFEARRAY *
		// SafeArrayCreateVectorEx( VARTYPE vt, LONG lLbound, ULONG cElements, PVOID pvExtra );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "45f2ba42-4189-42eb-9f6c-772198296906")]
		public static extern SafeSAFEARRAY SafeArrayCreateVectorEx(VARTYPE vt, int lLbound, uint cElements, IRecordInfo pvExtra);

		/// <summary>
		/// <para>Creates and returns a one-dimensional safe array of the specified VARTYPE and bounds.</para>
		/// </summary>
		/// <param name="vt">
		/// <para>
		/// The base type of the array (the VARTYPE of each element of the array). The FADF_RECORD flag can be set for VT_RECORD. The
		/// FADF_HAVEIID can be set for VT_DISPATCH or VT_UNKNOWN and FADF_HAVEVARTYPE can be set for all other types.
		/// </para>
		/// </param>
		/// <param name="lLbound">
		/// <para>The lower bound for the array. This parameter can be negative.</para>
		/// </param>
		/// <param name="cElements">
		/// <para>The number of elements in the array.</para>
		/// </param>
		/// <param name="pvExtra">
		/// <para>
		/// The type information of the user-defined type, if you are creating a safe array of user-defined types. If the vt parameter is
		/// VT_RECORD, then pvExtra will be a pointer to an IRecordInfo describing the record. If the vt parameter is VT_DISPATCH or
		/// VT_UNKNOWN, then pvExtra will contain a pointer to a GUID representing the type of interface being passed to the array.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>A safe array descriptor, or null if the array could not be created.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/oleauto/nf-oleauto-safearraycreatevectorex SAFEARRAY *
		// SafeArrayCreateVectorEx( VARTYPE vt, LONG lLbound, ULONG cElements, PVOID pvExtra );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "45f2ba42-4189-42eb-9f6c-772198296906")]
		public static extern SafeSAFEARRAY SafeArrayCreateVectorEx(VARTYPE vt, int lLbound, uint cElements, in Guid pvExtra);

		/// <summary>
		/// <para>
		/// Destroys an existing array descriptor and all of the data in the array. If objects are stored in the array, <c>Release</c> is
		/// called on each object in the array.
		/// </para>
		/// </summary>
		/// <param name="psa">
		/// <para>An array descriptor created by SafeArrayCreate.</para>
		/// </param>
		/// <returns>
		/// <para>This function can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Success.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The argument psa is not valid.</term>
		/// </item>
		/// <item>
		/// <term>DISP_E_ARRAYISLOCKED</term>
		/// <term>The array is locked.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Safe arrays of variant will have the VariantClear function called on each member and safe arrays of BSTR will have the
		/// SysFreeString function called on each element. IRecordInfo::RecordClear will be called to release object references and other
		/// values of a record without deallocating the record.
		/// </para>
		/// <para>Examples</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/oleauto/nf-oleauto-safearraydestroy HRESULT SafeArrayDestroy( SAFEARRAY *psa );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "fc94f7e7-b903-4c78-905c-54df1f8d13fa")]
		public static extern HRESULT SafeArrayDestroy(IntPtr psa);

		/// <summary>
		/// <para>Destroys all the data in the specified safe array.</para>
		/// </summary>
		/// <param name="psa">
		/// <para>A safe array descriptor.</para>
		/// </param>
		/// <returns>
		/// <para>This function can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Success.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The argument psa was not valid.</term>
		/// </item>
		/// <item>
		/// <term>DISP_E_ARRAYISLOCKED</term>
		/// <term>The array is locked.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This function is typically used when freeing safe arrays that contain elements with data types other than variants. If objects
		/// are stored in the array, Release is called on each object in the array. Safe arrays of variant will have the VariantClear
		/// function called on each member and safe arrays of BSTR will have the SysFreeString function called on each element.
		/// IRecordInfo::RecordClear will be called to release object references and other values of a record without deallocating the record.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/oleauto/nf-oleauto-safearraydestroydata HRESULT SafeArrayDestroyData(
		// SAFEARRAY *psa );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "aa9c62ba-79b5-4fcf-b3ed-664016486dfc")]
		public static extern HRESULT SafeArrayDestroyData(SafeSAFEARRAY psa);

		/// <summary>
		/// <para>Destroys the descriptor of the specified safe array.</para>
		/// </summary>
		/// <param name="psa">
		/// <para>A safe array descriptor.</para>
		/// </param>
		/// <returns>
		/// <para>This function can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Success.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The argument psa was not valid.</term>
		/// </item>
		/// <item>
		/// <term>DISP_E_ARRAYISLOCKED</term>
		/// <term>The array is locked.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This function is typically used to destroy the descriptor of a safe array that contains elements with data types other than
		/// variants. Destroying the array descriptor does not destroy the elements in the array. Before destroying the array descriptor,
		/// call SafeArrayDestroyData to free the elements.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/oleauto/nf-oleauto-safearraydestroydescriptor HRESULT
		// SafeArrayDestroyDescriptor( SAFEARRAY *psa );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "f1e8de45-673b-4f20-a639-18c724c82df1")]
		public static extern HRESULT SafeArrayDestroyDescriptor(IntPtr psa);

		/// <summary>
		/// <para>Gets the number of dimensions in the array.</para>
		/// </summary>
		/// <param name="psa">
		/// <para>An array descriptor created by SafeArrayCreate.</para>
		/// </param>
		/// <returns>
		/// <para>The number of dimensions in the array.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/oleauto/nf-oleauto-safearraygetdim UINT SafeArrayGetDim( SAFEARRAY *psa );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "bc52b23b-d323-478c-881f-d2a31a3289c5")]
		public static extern uint SafeArrayGetDim(SafeSAFEARRAY psa);

		/// <summary>
		/// <para>Retrieves a single element of the array.</para>
		/// </summary>
		/// <param name="psa">
		/// <para>An array descriptor created by SafeArrayCreate.</para>
		/// </param>
		/// <param name="rgIndices">
		/// <para>
		/// A vector of indexes for each dimension of the array. The right-most (least significant) dimension is rgIndices[0]. The left-most
		/// dimension is stored at .
		/// </para>
		/// </param>
		/// <param name="pv">
		/// <para>The element of the array.</para>
		/// </param>
		/// <returns>
		/// <para>This function can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Success.</term>
		/// </item>
		/// <item>
		/// <term>DISP_E_BADINDEX</term>
		/// <term>The specified index is not valid.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One of the arguments is not valid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>Memory could not be allocated for the element.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This function calls SafeArrayLock and SafeArrayUnlock automatically, before and after retrieving the element. The caller must
		/// provide a storage area of the correct size to receive the data. If the data element is a string, object, or variant, the
		/// function copies the element in the correct way.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following example is taken from the COM Fundamentals SPoly sample (Cenumpt.cpp).</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/oleauto/nf-oleauto-safearraygetelement HRESULT SafeArrayGetElement( SAFEARRAY
		// *psa, LONG *rgIndices, void *pv );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "47e9ee31-1e3b-4193-8467-6ef0db05966e")]
		public static extern HRESULT SafeArrayGetElement(SafeSAFEARRAY psa, [MarshalAs(UnmanagedType.LPArray)] int[] rgIndices, [Out] IntPtr pv);

		/// <summary>
		/// <para>Retrieves a single element of the array.</para>
		/// </summary>
		/// <param name="psa">
		/// <para>An array descriptor created by SafeArrayCreate.</para>
		/// </param>
		/// <param name="rgIndices">
		/// <para>
		/// A vector of indexes for each dimension of the array. The right-most (least significant) dimension is rgIndices[0]. The left-most
		/// dimension is stored at .
		/// </para>
		/// </param>
		/// <param name="pv">
		/// <para>The element of the array.</para>
		/// </param>
		/// <returns>
		/// <para>This function can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Success.</term>
		/// </item>
		/// <item>
		/// <term>DISP_E_BADINDEX</term>
		/// <term>The specified index is not valid.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One of the arguments is not valid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>Memory could not be allocated for the element.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This function calls SafeArrayLock and SafeArrayUnlock automatically, before and after retrieving the element. The caller must
		/// provide a storage area of the correct size to receive the data. If the data element is a string, object, or variant, the
		/// function copies the element in the correct way.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following example is taken from the COM Fundamentals SPoly sample (Cenumpt.cpp).</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/oleauto/nf-oleauto-safearraygetelement HRESULT SafeArrayGetElement( SAFEARRAY
		// *psa, LONG *rgIndices, void *pv );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "47e9ee31-1e3b-4193-8467-6ef0db05966e")]
		public static extern HRESULT SafeArrayGetElement(SafeSAFEARRAY psa, in int rgIndices, [Out] IntPtr pv);

		/// <summary>
		/// <para>Gets the size of an element.</para>
		/// </summary>
		/// <param name="psa">
		/// <para>An array descriptor created by SafeArrayCreate.</para>
		/// </param>
		/// <returns>
		/// <para>The size of an element in a safe array, in bytes.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/oleauto/nf-oleauto-safearraygetelemsize UINT SafeArrayGetElemsize( SAFEARRAY
		// *psa );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "27bd4a3f-0e9d-45f7-ad7c-0c0b59579dd0")]
		public static extern int SafeArrayGetElemsize(SafeSAFEARRAY psa);

		/// <summary>
		/// <para>Gets the GUID of the interface contained within the specified safe array.</para>
		/// </summary>
		/// <param name="psa">
		/// <para>An array descriptor created by SafeArrayCreate.</para>
		/// </param>
		/// <param name="pguid">
		/// <para>The GUID of the interface.</para>
		/// </param>
		/// <returns>
		/// <para>This function can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Success.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The argument psa is null or the array descriptor does not have the FADF_HAVEIID flag set.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/oleauto/nf-oleauto-safearraygetiid HRESULT SafeArrayGetIID( SAFEARRAY *psa,
		// GUID *pguid );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "9416f7f8-aee0-4e6a-be4f-ca6061adb244")]
		public static extern HRESULT SafeArrayGetIID(SafeSAFEARRAY psa, out Guid pguid);

		/// <summary>
		/// <para>Gets the lower bound for any dimension of the specified safe array.</para>
		/// </summary>
		/// <param name="psa">
		/// <para>An array descriptor created by SafeArrayCreate.</para>
		/// </param>
		/// <param name="nDim">
		/// <para>The array dimension for which to get the lower bound.</para>
		/// </param>
		/// <param name="plLbound">
		/// <para>The lower bound.</para>
		/// </param>
		/// <returns>
		/// <para>This function can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Success.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One of the arguments is not valid.</term>
		/// </item>
		/// <item>
		/// <term>DISP_E_BADINDEX</term>
		/// <term>The specified index is out of bounds.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/oleauto/nf-oleauto-safearraygetlbound HRESULT SafeArrayGetLBound( SAFEARRAY
		// *psa, UINT nDim, LONG *plLbound );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "f3134cc9-759b-4908-ada0-d025a525e795")]
		public static extern HRESULT SafeArrayGetLBound(SafeSAFEARRAY psa, uint nDim, out int plLbound);

		/// <summary>
		/// <para>Retrieves the IRecordInfo interface of the UDT contained in the specified safe array.</para>
		/// </summary>
		/// <param name="psa">
		/// <para>An array descriptor created by SafeArrayCreate.</para>
		/// </param>
		/// <param name="prinfo">
		/// <para>The IRecordInfo interface.</para>
		/// </param>
		/// <returns>
		/// <para>This function can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Success.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The argument psa is null or the array descriptor does not have the FADF_RECORD flag set.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/oleauto/nf-oleauto-safearraygetrecordinfo HRESULT SafeArrayGetRecordInfo(
		// SAFEARRAY *psa, IRecordInfo **prinfo );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "1584c00e-06a5-44f4-8c4b-a2b23737a652")]
		public static extern HRESULT SafeArrayGetRecordInfo(SafeSAFEARRAY psa, out IRecordInfo prinfo);

		/// <summary>
		/// <para>Gets the upper bound for any dimension of the specified safe array.</para>
		/// </summary>
		/// <param name="psa">
		/// <para>An array descriptor created by SafeArrayCreate.</para>
		/// </param>
		/// <param name="nDim">
		/// <para>The array dimension for which to get the upper bound.</para>
		/// </param>
		/// <param name="plUbound">
		/// <para>The upper bound.</para>
		/// </param>
		/// <returns>
		/// <para>This function can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Success.</term>
		/// </item>
		/// <item>
		/// <term>DISP_E_BADINDEX</term>
		/// <term>The specified index is out of bounds.</term>
		/// </item>
		/// <item>
		/// <term>DISP_E_OVERFLOW</term>
		/// <term>Overflow occurred while computing the upper bound.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One of the arguments is not valid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/oleauto/nf-oleauto-safearraygetubound HRESULT SafeArrayGetUBound( SAFEARRAY
		// *psa, UINT nDim, LONG *plUbound );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "aed339d5-d962-4adc-ac01-6c15a54c51ca")]
		public static extern HRESULT SafeArrayGetUBound(SafeSAFEARRAY psa, uint nDim, out int plUbound);

		/// <summary>
		/// <para>Gets the VARTYPE stored in the specified safe array.</para>
		/// </summary>
		/// <param name="psa">
		/// <para>An array descriptor created by SafeArrayCreate.</para>
		/// </param>
		/// <param name="pvt">
		/// <para>The VARTYPE.</para>
		/// </param>
		/// <returns>
		/// <para>This function can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Success.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One of the arguments is not valid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If FADF_HAVEVARTYPE is set, <c>SafeArrayGetVartype</c> returns the VARTYPE stored in the array descriptor. If FADF_RECORD is
		/// set, it returns VT_RECORD; if FADF_DISPATCH is set, it returns VT_DISPATCH; and if FADF_UNKNOWN is set, it returns VT_UNKNOWN.
		/// </para>
		/// <para>
		/// <c>SafeArrayGetVartype</c> can fail to return VT_UNKNOWN for SAFEARRAY types that are based on <c>IUnknown</c>. Callers should
		/// additionally check whether the SAFEARRAY type's <c>fFeatures</c> field has the FADF_UNKNOWN flag set.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/oleauto/nf-oleauto-safearraygetvartype HRESULT SafeArrayGetVartype( SAFEARRAY
		// *psa, VARTYPE *pvt );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "8ec0e736-bac8-4df4-ba32-433cd8478c55")]
		public static extern HRESULT SafeArrayGetVartype(SafeSAFEARRAY psa, out VARTYPE pvt);

		/// <summary>
		/// <para>Increments the lock count of an array, and places a pointer to the array data in pvData of the array descriptor.</para>
		/// </summary>
		/// <param name="psa">
		/// <para>An array descriptor created by SafeArrayCreate.</para>
		/// </param>
		/// <returns>
		/// <para>This function can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Success.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The argument psa is not valid.</term>
		/// </item>
		/// <item>
		/// <term>E_UNEXPECTED</term>
		/// <term>The array could not be locked.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The pointer in the array descriptor is valid until the SafeArrayUnlock function is called. Calls to <c>SafeArrayLock</c> can be
		/// nested, in which case an equal number of calls to <c>SafeArrayUnlock</c> are required.
		/// </para>
		/// <para>An array cannot be deleted while it is locked.</para>
		/// <para>Thread Safety</para>
		/// <para>
		/// All public static (Shared in Visual Basic) members of the SAFEARRAY data type are thread safe. Instance members are not
		/// guaranteed to be thread safe.
		/// </para>
		/// <para>
		/// For example, consider an application that uses the SafeArrayLock and SafeArrayUnlock functions. If these functions are called
		/// concurrently from different threads on the same SAFEARRAY data type instance, an inconsistent lock count may be created. This
		/// will eventually cause the <c>SafeArrayUnlock</c> function to return E_UNEXPECTED. You can prevent this by providing your own
		/// synchronization code.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/oleauto/nf-oleauto-safearraylock HRESULT SafeArrayLock( SAFEARRAY *psa );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "cb29d862-c7c5-4852-b017-c29e88d5f1c4")]
		public static extern HRESULT SafeArrayLock(SafeSAFEARRAY psa);

		/// <summary>Gets a pointer to an array element.</summary>
		/// <param name="psa">An array descriptor created by <c>SafeArrayCreate</c>.</param>
		/// <param name="rgIndices">
		/// An array of index values that identify an element of the array. All indexes for the element must be specified.
		/// </param>
		/// <param name="ppvData">The array element.</param>
		/// <returns>
		/// <para>This function can return one of these values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Success.</term>
		/// </item>
		/// <item>
		/// <term>DISP_E_BADINDEX</term>
		/// <term>The specified index is not valid.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One of the arguments is not valid.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </returns>
		// HRESULT SafeArrayPtrOfIndex( _In_ SAFEARRAY *psa, _In_ LONG *rgIndices, _Out_ void **ppvData); https://msdn.microsoft.com/en-us/library/windows/desktop/ms221452(v=vs.85).aspx
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("OleAuto.h", MSDNShortId = "ms221452")]
		public static extern HRESULT SafeArrayPtrOfIndex(SafeSAFEARRAY psa, [In] int[] rgIndices, out IntPtr ppvData);

		/// <summary>Gets a pointer to an array element.</summary>
		/// <param name="psa">An array descriptor created by <c>SafeArrayCreate</c>.</param>
		/// <param name="rgIndices">
		/// An array of index values that identify an element of the array. All indexes for the element must be specified.
		/// </param>
		/// <param name="ppvData">The array element.</param>
		/// <returns>
		/// <para>This function can return one of these values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Success.</term>
		/// </item>
		/// <item>
		/// <term>DISP_E_BADINDEX</term>
		/// <term>The specified index is not valid.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One of the arguments is not valid.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </returns>
		// HRESULT SafeArrayPtrOfIndex( _In_ SAFEARRAY *psa, _In_ LONG *rgIndices, _Out_ void **ppvData); https://msdn.microsoft.com/en-us/library/windows/desktop/ms221452(v=vs.85).aspx
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("OleAuto.h", MSDNShortId = "ms221452")]
		public static extern HRESULT SafeArrayPtrOfIndex(SafeSAFEARRAY psa, in int rgIndices, out IntPtr ppvData);

		/// <summary>
		/// <para>Stores the data element at the specified location in the array.</para>
		/// </summary>
		/// <param name="psa">
		/// <para>An array descriptor created by SafeArrayCreate.</para>
		/// </param>
		/// <param name="rgIndices">
		/// <para>
		/// A vector of indexes for each dimension of the array. The right-most (least significant) dimension is rgIndices[0]. The left-most
		/// dimension is stored at .
		/// </para>
		/// </param>
		/// <param name="pv">
		/// <para>
		/// The data to assign to the array. The variant types VT_DISPATCH, VT_UNKNOWN, and VT_BSTR are pointers, and do not require another
		/// level of indirection.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>This function can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Success.</term>
		/// </item>
		/// <item>
		/// <term>DISP_E_BADINDEX</term>
		/// <term>The specified index is not valid.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One of the arguments is not valid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>Memory could not be allocated for the element.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This function automatically calls SafeArrayLock and SafeArrayUnlock before and after assigning the element. If the data element
		/// is a string, object, or variant, the function copies it correctly when the safe array is destroyed. If the existing element is a
		/// string, object, or variant, it is cleared correctly. If the data element is a VT_DISPATCH or VT_UNKNOWN, <c>AddRef</c> is called
		/// to increment the object's reference count.
		/// </para>
		/// <para><c>Note</c> Multiple locks can be on an array. Elements can be put into an array while the array is locked by other operations.</para>
		/// <para>
		/// For an example that demonstrates calling <c>SafeArrayPutElement</c>, see the COM Fundamentals Lines sample (CLines::Add in Lines.cpp).
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/oleauto/nf-oleauto-safearrayputelement HRESULT SafeArrayPutElement( SAFEARRAY
		// *psa, LONG *rgIndices, void *pv );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "7c837b4f-d319-4d98-934a-b585fe521bf8")]
		public static extern HRESULT SafeArrayPutElement(SafeSAFEARRAY psa, [MarshalAs(UnmanagedType.LPArray)] int[] rgIndices, [In] IntPtr pv);

		/// <summary>
		/// <para>Stores the data element at the specified location in the array.</para>
		/// </summary>
		/// <param name="psa">
		/// <para>An array descriptor created by SafeArrayCreate.</para>
		/// </param>
		/// <param name="rgIndices">
		/// <para>
		/// A vector of indexes for each dimension of the array. The right-most (least significant) dimension is rgIndices[0]. The left-most
		/// dimension is stored at .
		/// </para>
		/// </param>
		/// <param name="pv">
		/// <para>
		/// The data to assign to the array. The variant types VT_DISPATCH, VT_UNKNOWN, and VT_BSTR are pointers, and do not require another
		/// level of indirection.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>This function can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Success.</term>
		/// </item>
		/// <item>
		/// <term>DISP_E_BADINDEX</term>
		/// <term>The specified index is not valid.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One of the arguments is not valid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>Memory could not be allocated for the element.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This function automatically calls SafeArrayLock and SafeArrayUnlock before and after assigning the element. If the data element
		/// is a string, object, or variant, the function copies it correctly when the safe array is destroyed. If the existing element is a
		/// string, object, or variant, it is cleared correctly. If the data element is a VT_DISPATCH or VT_UNKNOWN, <c>AddRef</c> is called
		/// to increment the object's reference count.
		/// </para>
		/// <para><c>Note</c> Multiple locks can be on an array. Elements can be put into an array while the array is locked by other operations.</para>
		/// <para>
		/// For an example that demonstrates calling <c>SafeArrayPutElement</c>, see the COM Fundamentals Lines sample (CLines::Add in Lines.cpp).
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/oleauto/nf-oleauto-safearrayputelement HRESULT SafeArrayPutElement( SAFEARRAY
		// *psa, LONG *rgIndices, void *pv );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "7c837b4f-d319-4d98-934a-b585fe521bf8")]
		public static extern HRESULT SafeArrayPutElement(SafeSAFEARRAY psa, in int rgIndices, [In] IntPtr pv);

		/// <summary>
		/// <para>Stores the data element at the specified location in the array.</para>
		/// </summary>
		/// <param name="psa">
		/// <para>An array descriptor created by SafeArrayCreate.</para>
		/// </param>
		/// <param name="rgIndices">
		/// <para>
		/// A vector of indexes for each dimension of the array. The right-most (least significant) dimension is rgIndices[0]. The left-most
		/// dimension is stored at .
		/// </para>
		/// </param>
		/// <param name="pv">
		/// <para>
		/// The data to assign to the array. The variant types VT_DISPATCH, VT_UNKNOWN, and VT_BSTR are pointers, and do not require another
		/// level of indirection.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>This function can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Success.</term>
		/// </item>
		/// <item>
		/// <term>DISP_E_BADINDEX</term>
		/// <term>The specified index is not valid.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One of the arguments is not valid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>Memory could not be allocated for the element.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This function automatically calls SafeArrayLock and SafeArrayUnlock before and after assigning the element. If the data element
		/// is a string, object, or variant, the function copies it correctly when the safe array is destroyed. If the existing element is a
		/// string, object, or variant, it is cleared correctly. If the data element is a VT_DISPATCH or VT_UNKNOWN, <c>AddRef</c> is called
		/// to increment the object's reference count.
		/// </para>
		/// <para><c>Note</c> Multiple locks can be on an array. Elements can be put into an array while the array is locked by other operations.</para>
		/// <para>
		/// For an example that demonstrates calling <c>SafeArrayPutElement</c>, see the COM Fundamentals Lines sample (CLines::Add in Lines.cpp).
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/oleauto/nf-oleauto-safearrayputelement HRESULT SafeArrayPutElement( SAFEARRAY
		// *psa, LONG *rgIndices, void *pv );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "7c837b4f-d319-4d98-934a-b585fe521bf8")]
		public static extern HRESULT SafeArrayPutElement(SafeSAFEARRAY psa, [MarshalAs(UnmanagedType.LPArray)] int[] rgIndices, [In, MarshalAs(UnmanagedType.Struct)] object pv);

		/// <summary>
		/// <para>Stores the data element at the specified location in the array.</para>
		/// </summary>
		/// <param name="psa">
		/// <para>An array descriptor created by SafeArrayCreate.</para>
		/// </param>
		/// <param name="rgIndices">
		/// <para>
		/// A vector of indexes for each dimension of the array. The right-most (least significant) dimension is rgIndices[0]. The left-most
		/// dimension is stored at .
		/// </para>
		/// </param>
		/// <param name="pv">
		/// <para>
		/// The data to assign to the array. The variant types VT_DISPATCH, VT_UNKNOWN, and VT_BSTR are pointers, and do not require another
		/// level of indirection.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>This function can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Success.</term>
		/// </item>
		/// <item>
		/// <term>DISP_E_BADINDEX</term>
		/// <term>The specified index is not valid.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One of the arguments is not valid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>Memory could not be allocated for the element.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This function automatically calls SafeArrayLock and SafeArrayUnlock before and after assigning the element. If the data element
		/// is a string, object, or variant, the function copies it correctly when the safe array is destroyed. If the existing element is a
		/// string, object, or variant, it is cleared correctly. If the data element is a VT_DISPATCH or VT_UNKNOWN, <c>AddRef</c> is called
		/// to increment the object's reference count.
		/// </para>
		/// <para><c>Note</c> Multiple locks can be on an array. Elements can be put into an array while the array is locked by other operations.</para>
		/// <para>
		/// For an example that demonstrates calling <c>SafeArrayPutElement</c>, see the COM Fundamentals Lines sample (CLines::Add in Lines.cpp).
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/oleauto/nf-oleauto-safearrayputelement HRESULT SafeArrayPutElement( SAFEARRAY
		// *psa, LONG *rgIndices, void *pv );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "7c837b4f-d319-4d98-934a-b585fe521bf8")]
		public static extern HRESULT SafeArrayPutElement(SafeSAFEARRAY psa, in int rgIndices, [In, MarshalAs(UnmanagedType.Struct)] object pv);

		/// <summary>
		/// <para>Stores the data element at the specified location in the array.</para>
		/// </summary>
		/// <param name="psa">
		/// <para>An array descriptor created by SafeArrayCreate.</para>
		/// </param>
		/// <param name="rgIndices">
		/// <para>
		/// A vector of indexes for each dimension of the array. The right-most (least significant) dimension is rgIndices[0]. The left-most
		/// dimension is stored at .
		/// </para>
		/// </param>
		/// <param name="pv">
		/// <para>
		/// The data to assign to the array. The variant types VT_DISPATCH, VT_UNKNOWN, and VT_BSTR are pointers, and do not require another
		/// level of indirection.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>This function can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Success.</term>
		/// </item>
		/// <item>
		/// <term>DISP_E_BADINDEX</term>
		/// <term>The specified index is not valid.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One of the arguments is not valid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>Memory could not be allocated for the element.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This function automatically calls SafeArrayLock and SafeArrayUnlock before and after assigning the element. If the data element
		/// is a string, object, or variant, the function copies it correctly when the safe array is destroyed. If the existing element is a
		/// string, object, or variant, it is cleared correctly. If the data element is a VT_DISPATCH or VT_UNKNOWN, <c>AddRef</c> is called
		/// to increment the object's reference count.
		/// </para>
		/// <para><c>Note</c> Multiple locks can be on an array. Elements can be put into an array while the array is locked by other operations.</para>
		/// <para>
		/// For an example that demonstrates calling <c>SafeArrayPutElement</c>, see the COM Fundamentals Lines sample (CLines::Add in Lines.cpp).
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/oleauto/nf-oleauto-safearrayputelement HRESULT SafeArrayPutElement( SAFEARRAY
		// *psa, LONG *rgIndices, void *pv );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "7c837b4f-d319-4d98-934a-b585fe521bf8")]
		public static extern HRESULT SafeArrayPutElement(SafeSAFEARRAY psa, [MarshalAs(UnmanagedType.LPArray)] int[] rgIndices, [In, MarshalAs(UnmanagedType.BStr)] string pv);

		/// <summary>
		/// <para>Stores the data element at the specified location in the array.</para>
		/// </summary>
		/// <param name="psa">
		/// <para>An array descriptor created by SafeArrayCreate.</para>
		/// </param>
		/// <param name="rgIndices">
		/// <para>
		/// A vector of indexes for each dimension of the array. The right-most (least significant) dimension is rgIndices[0]. The left-most
		/// dimension is stored at .
		/// </para>
		/// </param>
		/// <param name="pv">
		/// <para>
		/// The data to assign to the array. The variant types VT_DISPATCH, VT_UNKNOWN, and VT_BSTR are pointers, and do not require another
		/// level of indirection.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>This function can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Success.</term>
		/// </item>
		/// <item>
		/// <term>DISP_E_BADINDEX</term>
		/// <term>The specified index is not valid.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One of the arguments is not valid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>Memory could not be allocated for the element.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This function automatically calls SafeArrayLock and SafeArrayUnlock before and after assigning the element. If the data element
		/// is a string, object, or variant, the function copies it correctly when the safe array is destroyed. If the existing element is a
		/// string, object, or variant, it is cleared correctly. If the data element is a VT_DISPATCH or VT_UNKNOWN, <c>AddRef</c> is called
		/// to increment the object's reference count.
		/// </para>
		/// <para><c>Note</c> Multiple locks can be on an array. Elements can be put into an array while the array is locked by other operations.</para>
		/// <para>
		/// For an example that demonstrates calling <c>SafeArrayPutElement</c>, see the COM Fundamentals Lines sample (CLines::Add in Lines.cpp).
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/oleauto/nf-oleauto-safearrayputelement HRESULT SafeArrayPutElement( SAFEARRAY
		// *psa, LONG *rgIndices, void *pv );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "7c837b4f-d319-4d98-934a-b585fe521bf8")]
		public static extern HRESULT SafeArrayPutElement(SafeSAFEARRAY psa, in int rgIndices, [In, MarshalAs(UnmanagedType.BStr)] string pv);

		/// <summary>
		/// <para>Changes the right-most (least significant) bound of the specified safe array.</para>
		/// </summary>
		/// <param name="psa">
		/// <para>A safe array descriptor.</para>
		/// </param>
		/// <param name="psaboundNew">
		/// <para>
		/// A new safe array bound structure that contains the new array boundary. You can change only the least significant dimension of an array.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>This function can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Success.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The argument psa is not valid.</term>
		/// </item>
		/// <item>
		/// <term>DISP_E_ARRAYISLOCKED</term>
		/// <term>The array is locked.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If you reduce the bound of an array, <c>SafeArrayRedim</c> deallocates the array elements outside the new array boundary. If the
		/// bound of an array is increased, <c>SafeArrayRedim</c> allocates and initializes the new array elements. The data is preserved
		/// for elements that exist in both the old and new array.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/oleauto/nf-oleauto-safearrayredim HRESULT SafeArrayRedim( SAFEARRAY *psa,
		// SAFEARRAYBOUND *psaboundNew );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "1c7fa627-e5e4-4bb9-8237-2f7358ebc4b8")]
		public static extern HRESULT SafeArrayRedim(SafeSAFEARRAY psa, in SAFEARRAYBOUND psaboundNew);

		/// <summary>
		/// <para>The safe array data for which the pinning reference count should decrease.</para>
		/// </summary>
		/// <param name="pData">
		/// <para>The safe array data for which the pinning reference count should decrease.</para>
		/// </param>
		/// <returns>
		/// <para>This function does not return a value.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A call to the <c>SafeArrayReleaseData</c> function should match every previous call to the SafeArrayAddRef function that
		/// returned a non-null value in the ppDataToRelease parameter.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/oleauto/nf-oleauto-safearrayreleasedata void SafeArrayReleaseData( PVOID
		// pData );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "AF3C36A3-2B3A-4159-8183-DB082FBFD215")]
		public static extern void SafeArrayReleaseData(IntPtr pData);

		/// <summary>
		/// <para>The safe array for which the pinning reference count of the descriptor should decrease.</para>
		/// </summary>
		/// <param name="psa">
		/// <para>The safe array for which the pinning reference count of the descriptor should decrease.</para>
		/// </param>
		/// <returns>
		/// <para>This function does not return a value.</para>
		/// </returns>
		/// <remarks>
		/// <para>A call to the <c>SafeArrayReleaseDescriptor</c> function should match every previous call to the SafeArrayAddRef function.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/oleauto/nf-oleauto-safearrayreleasedescriptor void
		// SafeArrayReleaseDescriptor( SAFEARRAY *psa );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "D6678B17-B537-46CF-AC64-4D0C0DC4CDF3")]
		public static extern void SafeArrayReleaseDescriptor(SafeSAFEARRAY psa);

		/// <summary>
		/// <para>Sets the GUID of the interface for the specified safe array.</para>
		/// </summary>
		/// <param name="psa">
		/// <para>The safe array descriptor.</para>
		/// </param>
		/// <param name="guid">
		/// <para>The IID.</para>
		/// </param>
		/// <returns>
		/// <para>This function can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Success.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The argument psa is null or the array descriptor does not have the FADF_HAVEIID flag set.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/oleauto/nf-oleauto-safearraysetiid HRESULT SafeArraySetIID( SAFEARRAY *psa,
		// REFGUID guid );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "851b8a44-9da4-418c-88bc-80c9fc55d25c")]
		public static extern HRESULT SafeArraySetIID(SafeSAFEARRAY psa, in Guid guid);

		/// <summary>
		/// <para>Sets the record info in the specified safe array.</para>
		/// </summary>
		/// <param name="psa">
		/// <para>The array descriptor.</para>
		/// </param>
		/// <param name="prinfo">
		/// <para>The record info.</para>
		/// </param>
		/// <returns>
		/// <para>This function can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Success.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The argument psa is null or the array descriptor does not have the FADF_RECORD flag set.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/oleauto/nf-oleauto-safearraysetrecordinfo HRESULT SafeArraySetRecordInfo(
		// SAFEARRAY *psa, IRecordInfo *prinfo );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "85317e8e-7625-4799-9c34-73245f164f85")]
		public static extern HRESULT SafeArraySetRecordInfo(SafeSAFEARRAY psa, IRecordInfo prinfo);

		/// <summary>
		/// <para>Decrements the lock count of an array, and invalidates the pointer retrieved by SafeArrayAccessData.</para>
		/// </summary>
		/// <param name="psa">
		/// <para>An array descriptor created by SafeArrayCreate.</para>
		/// </param>
		/// <returns>
		/// <para>This function can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Success.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The argument psa is not valid.</term>
		/// </item>
		/// <item>
		/// <term>E_UNEXPECTED</term>
		/// <term>The array could not be unlocked.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/oleauto/nf-oleauto-safearrayunaccessdata HRESULT SafeArrayUnaccessData(
		// SAFEARRAY *psa );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "61b482cb-f0a3-4efb-9a68-f373f241e89a")]
		public static extern HRESULT SafeArrayUnaccessData(SafeSAFEARRAY psa);

		/// <summary>
		/// <para>Decrements the lock count of an array so it can be freed or resized.</para>
		/// </summary>
		/// <param name="psa">
		/// <para>An array descriptor created by SafeArrayCreate.</para>
		/// </param>
		/// <returns>
		/// <para>This function can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Success.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The argument psa is not valid.</term>
		/// </item>
		/// <item>
		/// <term>E_UNEXPECTED</term>
		/// <term>The array could not be unlocked.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>This function is called after access to the data in an array is finished.</para>
		/// <para>Thread Safety</para>
		/// <para>
		/// All public static members of the SAFEARRAY data type are thread safe. Instance members are not guaranteed to be thread safe.
		/// </para>
		/// <para>
		/// For example, consider an application that uses the SafeArrayLock and SafeArrayUnlock functions. If these functions are called
		/// concurrently from different threads on the same SAFEARRAY data type instance, an inconsistent lock count may be created. This
		/// will eventually cause the SafeArrayUnlock function to return E_UNEXPECTED. You can prevent this by providing your own
		/// synchronization code.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/oleauto/nf-oleauto-safearrayunlock HRESULT SafeArrayUnlock( SAFEARRAY *psa );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleauto.h", MSDNShortId = "654995ab-1959-44dc-9e26-11c34e489c14")]
		public static extern HRESULT SafeArrayUnlock(SafeSAFEARRAY psa);

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

			/// <summary>Initializes a new instance of the <see cref="SAFEARRAYBOUND"/> struct.</summary>
			/// <param name="upperBound">The number of elements in the dimension.</param>
			/// <param name="lowerBound">The lower bound of the dimension.</param>
			public SAFEARRAYBOUND(int upperBound, int lowerBound = 0)
			{
				lLbound = lowerBound;
				cElements = (uint)(upperBound + 1 - lowerBound);
			}
		}

		/// <summary>Construct for handling the paired calling of <see cref="SafeArrayAccessData"/> and <see cref="SafeArrayUnaccessData"/>.</summary>
		/// <example>
		/// <code>
		///using (var data = new SafeArrayScopedAccessData(safeArray))
		///{
		///  // The Data property provides access to the array's data while in scope.
		///  FILETIME ft = (FILETIME)Marshal.PtrToStructure(data.Data, typeof(FILETIME));
		///}
		/// </code>
		/// </example>
		/// <seealso cref="System.IDisposable"/>
		[PInvokeData("OleAuto.h")]
		public class SafeArrayScopedAccessData : IDisposable
		{
			private readonly SafeSAFEARRAY psa;
			private IntPtr ppvData;

			/// <summary>
			/// Initializes a new instance of the <see cref="SafeArrayScopedAccessData"/> class using the array descriptor that holds the data.
			/// </summary>
			/// <param name="psa">An array descriptor created by SafeArrayCreate.</param>
			public SafeArrayScopedAccessData(SafeSAFEARRAY psa)
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

		/// <summary>Provides a safe handle for items created with <see cref="SafeArrayAllocDescriptor"/>.</summary>
		/// <seealso cref="Vanara.PInvoke.OleAut32.SafeSAFEARRAY"/>
		public class SafeDescriptorSAFEARRAY : SafeSAFEARRAY
		{
			/// <summary>Initializes a new instance of the <see cref="SafeDescriptorSAFEARRAY"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafeDescriptorSAFEARRAY(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SafeDescriptorSAFEARRAY"/> class.</summary>
			private SafeDescriptorSAFEARRAY() : base() { }

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() => SafeArrayDestroyDescriptor(handle).Succeeded;
		}

		/// <summary>
		/// Provides a <see cref="SafeHandle"/> to a safe array that releases a created SAFEARRAY instance at disposal using SafeArrayDestroy.
		/// </summary>
		public class SafeSAFEARRAY : SafeHANDLE
		{
			/// <summary>Initializes a new instance of the <see cref="SafeSAFEARRAY"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafeSAFEARRAY(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SafeSAFEARRAY"/> class.</summary>
			protected SafeSAFEARRAY() : base() { }

			/// <summary>Gets the total number of elements in all the dimensions of the array.</summary>
			/// <value>The total number of elements in all the dimensions of the array; zero if there are no elements in the array.</value>
			public int Length
			{
				get
				{
					var len = 0;
					for (uint d = 1; d <= SafeArrayGetDim(this); d++)
					{
						SafeArrayGetLBound(this, d, out var lb);
						SafeArrayGetUBound(this, d, out var ub);
						var cnt = ub - lb + 1;
						len = len == 0 ? cnt : len * cnt;
					}
					return len;
				}
			}

			/// <summary>
			/// Gets the rank (number of dimensions) of the Array. For example, a one-dimensional array returns 1, a two-dimensional array
			/// returns 2, and so on.
			/// </summary>
			/// <value>The rank (number of dimensions) of the Array.</value>
			public int Rank => (int)SafeArrayGetDim(this);

			/// <summary>Gets the VARTYPE stored in the specified safe array.</summary>
			/// <value>The type of the variable.</value>
			/// <remarks>
			/// If FADF_HAVEVARTYPE is set, <c>SafeArrayGetVartype</c> returns the VARTYPE stored in the array descriptor. If FADF_RECORD is
			/// set, it returns VT_RECORD; if FADF_DISPATCH is set, it returns VT_DISPATCH; and if FADF_UNKNOWN is set, it returns VT_UNKNOWN.
			/// </remarks>
			public VARTYPE VarType { get { SafeArrayGetVartype(this, out var vt).ThrowIfFailed(); return vt; } }

			/// <summary>Creates a SAFEARRAY from a .NET array.</summary>
			/// <param name="array">
			/// The array used to initialize the SAFEARRAY. This can be a single or multi-dimensional array, but cannot be a jagged array
			/// (array of arrays).
			/// </param>
			/// <param name="elementVarType">The type of the element as a VARTYPE.</param>
			/// <returns>A SafeSAFEARRAY initialize with the values in <paramref name="array"/>.</returns>
			public static SafeSAFEARRAY CreateFromArray(Array array, VARTYPE elementVarType)
			{
				var elemType = array.GetType().GetElementType();
				if (elemType.IsArray) throw new ArgumentException("Input array cannot be jagged.", nameof(array));
				// Create list of bounds in reverse
				var bounds = new SAFEARRAYBOUND[array.Rank];
				for (int d = 0; d < bounds.Length; d++)
					bounds[bounds.Length - d - 1] = new SAFEARRAYBOUND(array.GetUpperBound(d), array.GetLowerBound(d));
				// Create safe array
				var sa = SafeArrayCreate(elementVarType, (uint)array.Rank, bounds);
				// Copy values
				if (elemType == typeof(object))
				{
					switch (elementVarType)
					{
						case VARTYPE.VT_VARIANT:
							foreach (var (from, to) in BuildIndexList(bounds))
								SafeArrayPutElement(sa, to, array.GetValue(from)).ThrowIfFailed();
							break;

						case VARTYPE.VT_DISPATCH:
						case VARTYPE.VT_UNKNOWN:
							foreach (var (from, to) in BuildIndexList(bounds))
								SafeArrayPutElement(sa, to, Marshal.GetIUnknownForObject(array.GetValue(from))).ThrowIfFailed();
							break;

						default:
							sa.Dispose();
							throw new ArgumentException("An invalid VARTYPE was supplied for arrays of objects.", nameof(elementVarType));
					}
				}
				else if (elemType == typeof(string))
				{
					switch (elementVarType)
					{
						case VARTYPE.VT_LPSTR:
							foreach (var (from, to) in BuildIndexList(bounds))
								using (var str = new SafeCoTaskMemString(array.GetValue(from).ToString(), CharSet.Ansi))
									SafeArrayPutElement(sa, to, (IntPtr)str).ThrowIfFailed();
							break;

						case VARTYPE.VT_LPWSTR:
							foreach (var (from, to) in BuildIndexList(bounds))
								using (var str = new SafeCoTaskMemString(array.GetValue(from).ToString(), CharSet.Unicode))
									SafeArrayPutElement(sa, to, (IntPtr)str).ThrowIfFailed();
							break;

						case VARTYPE.VT_BSTR:
							foreach (var (from, to) in BuildIndexList(bounds))
								SafeArrayPutElement(sa, to, array.GetValue(from).ToString()).ThrowIfFailed();
							break;

						default:
							sa.Dispose();
							throw new ArgumentException("An invalid VARTYPE was supplied for arrays of strings.", nameof(elementVarType));
					}
				}
				else if (elemType.IsBlittable())
				{
					using var mem = new SafeCoTaskMemHandle(Vanara.Extensions.InteropExtensions.SizeOf(elemType));
					foreach (var (from, to) in BuildIndexList(bounds))
					{
						Marshal.StructureToPtr(array.GetValue(from), mem.DangerousGetHandle(), false);
						SafeArrayPutElement(sa, to, (IntPtr)mem).ThrowIfFailed();
					}
				}
				else
				{
					sa.Dispose();
					throw new ArgumentException("Unable to add element type of array.", nameof(array));
				}
				return sa;
			}

			/// <summary>Performs an implicit conversion from <see cref="SafeSAFEARRAY"/> to <see cref="SAFEARRAY"/>.</summary>
			/// <param name="h">The safe handle instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator SAFEARRAY(SafeSAFEARRAY h) => h.IsInvalid ? new SAFEARRAY() : h.handle.ToStructure<SAFEARRAY>();

			/// <summary>Gets the lower bound for any dimension of the specified safe array.</summary>
			/// <param name="dimension">The array dimension for which to get the lower bound.</param>
			/// <returns>The lower bound.</returns>
			public int GetLowerBound(int dimension)
			{
				SafeArrayGetLBound(this, (uint)dimension + 1, out var lb).ThrowIfFailed();
				return lb;
			}

			/// <summary>Gets the upper bound for any dimension of the specified safe array.</summary>
			/// <param name="dimension">The array dimension for which to get the upper bound.</param>
			/// <returns>The upper bound.</returns>
			public int GetUpperBound(int dimension)
			{
				SafeArrayGetUBound(this, (uint)dimension + 1, out var ub).ThrowIfFailed();
				return ub;
			}

			/// <summary>Gets the value at the specified position in the one-dimensional Array. The index is specified as a 32-bit integer.</summary>
			/// <param name="index">A 32-bit integer that represents the position of the Array element to get.</param>
			/// <returns>The value returned from the specified position in the one-dimensional array.</returns>
			public object GetValue(int index)
			{
				using var mem = GetValuePointer(index);
				return mem.DangerousGetHandle().Convert(mem.Size, VarType.GetCorrespondingType());
			}

			/// <summary>
			/// Gets the value at the specified position in the multi-dimensional Array. The indexes are specified as an array of 32-bit integers.
			/// </summary>
			/// <param name="indices">
			/// 32-bit integers that represents the position of the Array element to get.
			/// <para>The order of the indices follows .NET <see cref="Array"/> order and not the backwards ordering imposed by <c>SafeArrayGetElement</c>.</para>
			/// </param>
			/// <returns>The value returned from the specified position in the multi-dimensional array.</returns>
			public object GetValue(params int[] indices)
			{
				using var mem = GetValuePointer(indices);
				return mem.DangerousGetHandle().Convert(mem.Size, VarType.GetCorrespondingType());
			}

			/// <summary>
			/// Gets the value of a specified type at the specified position in the one-dimensional Array. The index is specified as a
			/// 32-bit integer.
			/// </summary>
			/// <typeparam name="T">The type to return.</typeparam>
			/// <param name="index">A 32-bit integer that represents the position of the Array element to get.</param>
			/// <returns>The value returned from the specified position in the one-dimensional array.</returns>
			public T GetValue<T>(int index) where T : struct
			{
				using var mem = GetValuePointer(index);
				return mem.ToStructure<T>();
			}

			/// <summary>
			/// Gets the value of a specified type at the specified position in the multi-dimensional Array. The indexes are specified as an
			/// array of 32-bit integers.
			/// </summary>
			/// <typeparam name="T">The type to return.</typeparam>
			/// <param name="indices">
			/// 32-bit integers that represents the position of the array element to get.
			/// <para>The order of the indices follows .NET <see cref="Array"/> order and not the backwards ordering imposed by <c>SafeArrayGetElement</c>.</para>
			/// </param>
			/// <returns>The value returned from the specified position in the multi-dimensional array.</returns>
			public T GetValue<T>(params int[] indices) where T : struct
			{
				using var mem = GetValuePointer(indices);
				return mem.ToStructure<T>();
			}

			/// <summary>
			/// Gets the handle to the memory of the value at the specified position in the one-dimensional Array. The index is specified as
			/// a 32-bit integer.
			/// </summary>
			/// <param name="index">A 32-bit integer that represents the position of the Array element to get.</param>
			/// <returns>The handle of the memory returned from the specified position in the one-dimensional array.</returns>
			public SafeCoTaskMemHandle GetValuePointer(int index)
			{
				var mem = new SafeCoTaskMemHandle(SafeArrayGetElemsize(this));
				SafeArrayGetElement(this, index, mem).ThrowIfFailed();
				return mem;
			}

			/// <summary>
			/// Gets the handle to the memory of the value at the specified position in the multi-dimensional Array. The indexes are
			/// specified as an array of 32-bit integers.
			/// </summary>
			/// <param name="indices">
			/// A 32-bit integer that represents the position of the Array element to get.
			/// <para>The order of the indices follows .NET <see cref="Array"/> order and not the backwards ordering imposed by <c>SafeArrayGetElement</c>.</para>
			/// </param>
			/// <returns>The handle of the memory returned from the specified position in the multi-dimensional array.</returns>
			public SafeCoTaskMemHandle GetValuePointer(params int[] indices)
			{
				Array.Reverse(indices);
				var mem = new SafeCoTaskMemHandle(SafeArrayGetElemsize(this));
				SafeArrayGetElement(this, indices, mem).ThrowIfFailed();
				return mem;
			}

			/// <summary>Increments the lock count of an array, and places a pointer to the array data in pvData of the array descriptor.</summary>
			/// <returns>
			/// <para>This function can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>The argument psa is not valid.</term>
			/// </item>
			/// <item>
			/// <term>E_UNEXPECTED</term>
			/// <term>The array could not be locked.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// The pointer in the array descriptor is valid until the SafeArrayUnlock function is called. Calls to <c>SafeArrayLock</c> can
			/// be nested, in which case an equal number of calls to <c>SafeArrayUnlock</c> are required.
			/// </para>
			/// <para>An array cannot be deleted while it is locked.</para>
			/// <para>Thread Safety</para>
			/// <para>
			/// All public static (Shared in Visual Basic) members of the SAFEARRAY data type are thread safe. Instance members are not
			/// guaranteed to be thread safe.
			/// </para>
			/// <para>
			/// For example, consider an application that uses the SafeArrayLock and SafeArrayUnlock functions. If these functions are
			/// called concurrently from different threads on the same SAFEARRAY data type instance, an inconsistent lock count may be
			/// created. This will eventually cause the <c>SafeArrayUnlock</c> function to return E_UNEXPECTED. You can prevent this by
			/// providing your own synchronization code.
			/// </para>
			/// </remarks>
			public HRESULT Lock() => SafeArrayLock(this);

			/// <summary>
			/// Sets a value to the element at the specified position in the one-dimensional Array. The index is specified as a 32-bit integer.
			/// </summary>
			/// <param name="value">The new value for the specified element.</param>
			/// <param name="index">A 32-bit integer that represents the position of the Array element to set.</param>
			/// <exception cref="ArgumentException">To take objects, the SAFEARRAY must be for VARIANTS.</exception>
			public void SetValue(object value, int index)
			{
				if (VarType != VARTYPE.VT_VARIANT)
					throw new ArgumentException("To take objects, the SAFEARRAY must be for VARIANTS.");
				SafeArrayPutElement(this, index, value).ThrowIfFailed();
			}

			/// <summary>
			/// Sets a value to the element at the specified position in the multi-dimensional Array. The indexes are specified as an array
			/// of 32-bit integers.
			/// </summary>
			/// <param name="value">The new value for the specified element.</param>
			/// <param name="indices">
			/// A one-dimensional array of 32-bit integers that represent the indexes specifying the position of the element to set.
			/// <para>The order of the indices follows .NET <see cref="Array"/> order and not the backwards ordering imposed by <c>SafeArrayGetElement</c>.</para>
			/// </param>
			/// <exception cref="ArgumentException">To take objects, the SAFEARRAY must be for VARIANTS.</exception>
			public void SetValue(object value, params int[] indices)
			{
				if (VarType != VARTYPE.VT_VARIANT)
					throw new ArgumentException("To take objects, the SAFEARRAY must be for VARIANTS.");
				Array.Reverse(indices);
				SafeArrayPutElement(this, indices, value).ThrowIfFailed();
			}

			/// <summary>
			/// Sets a value to the element at the specified position in the one-dimensional Array. The index is specified as a 32-bit integer.
			/// </summary>
			/// <typeparam name="T">The type of the element.</typeparam>
			/// <param name="value">The new value for the specified element.</param>
			/// <param name="index">A 32-bit integer that represents the position of the Array element to set.</param>
			/// <exception cref="ArgumentException">To take objects, the SAFEARRAY must be for VARIANTS.</exception>
			public void SetValue<T>(in T value, int index) where T : struct
			{
				using var mem = SafeCoTaskMemHandle.CreateFromStructure(value);
				SafeArrayPutElement(this, index, (IntPtr)mem).ThrowIfFailed();
			}

			/// <summary>
			/// Sets a value to the element at the specified position in the multi-dimensional Array. The indexes are specified as an array
			/// of 32-bit integers.
			/// </summary>
			/// <typeparam name="T">The type of the element.</typeparam>
			/// <param name="value">The new value for the specified element.</param>
			/// <param name="indices">
			/// A one-dimensional array of 32-bit integers that represent the indexes specifying the position of the element to set.
			/// <para>The order of the indices follows .NET <see cref="Array"/> order and not the backwards ordering imposed by <c>SafeArrayGetElement</c>.</para>
			/// </param>
			/// <exception cref="ArgumentException">To take objects, the SAFEARRAY must be for VARIANTS.</exception>
			public void SetValue<T>(in T value, params int[] indices) where T : struct
			{
				Array.Reverse(indices);
				using var mem = SafeCoTaskMemHandle.CreateFromStructure(value);
				SafeArrayPutElement(this, indices, (IntPtr)mem).ThrowIfFailed();
			}

			/// <summary>Converts the contents of the SAFEARRAY to a .NET array.</summary>
			/// <returns>A .NET array with the same dimensions and values as this SAFEARRAY instance.</returns>
			/// <exception cref="InvalidCastException">Unable to extract a valid type from the SAFEARRAY.</exception>
			public Array ToArray()
			{
				// Determine element type
				var vt = VarType;
				var eType = CorrespondingTypeAttribute.GetCorrespondingTypes(vt).FirstOrDefault();
				if (eType is null && eType != typeof(string) && eType != typeof(object) && !eType.IsValueType)
					throw new InvalidCastException("Unable to extract a valid type from the SAFEARRAY.");
				var eTypeVal = Activator.CreateInstance(eType);

				// Get details and build Array instance
				var dims = Rank;
				var bounds = new SAFEARRAYBOUND[dims];
				for (int i = 1; i <= dims; i++)
				{
					SafeArrayGetLBound(this, (uint)i, out var lb);
					SafeArrayGetUBound(this, (uint)i, out var ub);
					bounds[dims - i] = new SAFEARRAYBOUND(ub, lb);
				}
				var ret = Array.CreateInstance(eType, Array.ConvertAll(bounds, b => (int)b.cElements), Array.ConvertAll(bounds, b => b.lLbound));

				// Fill in values
				using var mem = new SafeCoTaskMemHandle(SafeArrayGetElemsize(this));
				foreach (var (from, to) in BuildIndexList(bounds))
				{
					SafeArrayGetElement(this, from, mem).ThrowIfFailed();
					object val = eTypeVal switch
					{
						string when vt == VARTYPE.VT_BSTR => Marshal.PtrToStringBSTR(mem),
						string when vt == VARTYPE.VT_LPSTR => Marshal.PtrToStringAnsi(mem),
						string when vt == VARTYPE.VT_LPWSTR => Marshal.PtrToStringUni(mem),
						object o when eType.IsValueType => mem.DangerousGetHandle().Convert(mem.Size, eType),
						_ => Marshal.GetObjectForNativeVariant(mem),
					};
					ret.SetValue(val, to);
				}
				return ret;
			}

			/// <summary>Decrements the lock count of an array so it can be freed or resized.</summary>
			/// <returns>
			/// <para>This function can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>The argument psa is not valid.</term>
			/// </item>
			/// <item>
			/// <term>E_UNEXPECTED</term>
			/// <term>The array could not be unlocked.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>This function is called after access to the data in an array is finished.</para>
			/// <para>Thread Safety</para>
			/// <para>
			/// All public static members of the SAFEARRAY data type are thread safe. Instance members are not guaranteed to be thread safe.
			/// </para>
			/// <para>
			/// For example, consider an application that uses the SafeArrayLock and SafeArrayUnlock functions. If these functions are
			/// called concurrently from different threads on the same SAFEARRAY data type instance, an inconsistent lock count may be
			/// created. This will eventually cause the SafeArrayUnlock function to return E_UNEXPECTED. You can prevent this by providing
			/// your own synchronization code.
			/// </para>
			/// </remarks>
			public HRESULT Unlock() => SafeArrayUnlock(this);

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() => SafeArrayDestroy(handle).Succeeded;

			private static IEnumerable<(int[] from, int[] to)> BuildIndexList(SAFEARRAYBOUND[] bounds)
			{
				return DimRecurse(0, new int[bounds.Length]);

				IEnumerable<(int[] from, int[] to)> DimRecurse(int dim, int[] f)
				{
					for (int i = 0; i < bounds[dim].cElements; i++)
					{
						f[dim] = i;
						if (dim + 1 == bounds.Length)
						{
							var rev = (int[])f.Clone();
							Array.Reverse(rev);
							yield return (rev, (int[])f.Clone());
						}
						else
							foreach (var v in DimRecurse(dim + 1, f))
								yield return v;
					}
				}
			}
		}
	}
}