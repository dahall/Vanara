using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using Vanara.InteropServices;
using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;
using STATSTG = System.Runtime.InteropServices.ComTypes.STATSTG;

namespace Vanara.PInvoke
{
	public static partial class Ole32
	{
		/// <summary>
		/// <para>
		/// The <c>CreateILockBytesOnHGlobal</c> function creates a byte array object that uses an HGLOBAL memory handle to store the bytes
		/// intended for in-memory storage of a compound file. This object is the OLE-provided implementation of the ILockBytes interface.
		/// </para>
		/// <para>
		/// The returned byte array object supports both reading and writing, but does not support region locking . The object calls the
		/// GlobalReAlloc function to grow the memory block as required.
		/// </para>
		/// </summary>
		/// <param name="hGlobal">
		/// A memory handle allocated by the GlobalAlloc function, or if <c>NULL</c> a new handle is to be allocated instead. The handle must
		/// be allocated as moveable and nondiscardable.
		/// </param>
		/// <param name="fDeleteOnRelease">
		/// A flag that specifies whether the underlying handle for this byte array object should be automatically freed when the object is
		/// released. If set to <c>FALSE</c>, the caller must free the hGlobal after the final release. If set to <c>TRUE</c>, the final
		/// release will automatically free the hGlobal parameter.
		/// </param>
		/// <param name="pplkbyt">
		/// The address of ILockBytes pointer variable that receives the interface pointer to the new byte array object.
		/// </param>
		/// <returns>This function supports the standard return values <c>E_INVALIDARG</c> and <c>E_OUTOFMEMORY</c>, as well as the following:</returns>
		/// <remarks>
		/// <para>
		/// If hGlobal is <c>NULL</c>, the <c>CreateILockBytesOnHGlobal</c> allocates a new memory handle and the byte array is empty initially.
		/// </para>
		/// <para>
		/// If hGlobal is not <c>NULL</c>, the initial contents of the byte array object are the current contents of the memory block. Thus,
		/// this function can be used to open an existing byte array in memory, for example to reload a storage object previously created by
		/// the StgCreateDocfileOnILockBytes function. The memory handle and its contents are undisturbed by the creation of the new byte
		/// array object.
		/// </para>
		/// <para>
		/// The initial size of the byte array is the size of hGlobal as returned by the GlobalSize function. This is not necessarily the
		/// same size that was originally allocated for the handle because of rounding. If the logical size of the byte array is important,
		/// follow the call to <c>CreateILockBytesOnHGlobal</c> with a call to ILockBytes::SetSize.
		/// </para>
		/// <para>
		/// After creating the byte array object with CreateStreamOnHGlobal, StgCreateDocfileOnILockBytes can be used to create a new storage
		/// object in memory, or StgOpenStorageOnILockBytes can be used to reopen a previously existing storage object that is already
		/// contained in the memory block. GetHGlobalFromILockBytes can be called to retrieve the memory handle associated with the byte
		/// array object.
		/// </para>
		/// <para>
		/// If a memory handle is passed to <c>CreateILockBytesOnHGlobal</c> or if GetHGlobalFromILockBytes is called, the memory handle of
		/// this function can be directly accessed by the caller while it is still in use by the byte array object. Appropriate caution
		/// should be exercised in the use of this capability and its implications:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// Do not free the hGlobal memory handle during the lifetime of the byte array object. ILockBytes::Releasemust be called before the
		/// memory handle is freed.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// Do not call GlobalReAlloc to change the size of the memory handle during the lifetime of the byte array object. This may cause
		/// application crashes or memory corruption. Avoid creating multiple byte array objects on the same memory handle, because
		/// ILockBytes::WriteAt and ILockBytes::SetSize methods may internally call <c>GlobalReAlloc</c>.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// If possible, avoid accessing the memory block during the lifetime of the byte array object, because the object may internally
		/// call GlobalReAlloc and do not make assumptions about its size and location. If the memory block must be accessed, the memory
		/// access calls should be surrounded by calls to GlobalLock and GlobalUnLock.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// Avoid calling the object’s methods while the memory handle is locked with GlobalLock. This can cause method calls to fail unpredictably.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// If the caller sets the fDeleteOnRelease parameter to <c>FALSE</c>, then the caller must also free the hGlobal after the final
		/// release. If the caller sets the fDeleteOnRelease parameter to <c>TRUE</c>, the final release will automatically free the hGlobal.
		/// The memory handle passed as the hGlobal parameter must be allocated as movable and nondiscardable, as shown in the following example:
		/// </para>
		/// <para>
		/// <c>CreateILockBytesOnHGlobal</c> will accept memory allocated with GMEM_FIXED, but this usage is not recommended. HGLOBALs
		/// allocated with <c>GMEM_FIXED</c> are not really handles and their value can change when they are reallocated. If the memory
		/// handle was allocated with <c>GMEM_FIXED</c> and fDeleteOnRelease is <c>FALSE</c>, then the caller must call
		/// GetHGlobalFromILockBytes to get the correct HGLOBAL value in order to free the handle.
		/// </para>
		/// <para>
		/// This implementation of ILockBytes does not support region locking. Applications that use this implementation with the
		/// StgCreateDocfileOnILockBytes or StgOpenStorageOnILockBytes functions should avoid opening multiple concurrent instances on the
		/// same <c>ILockBytes</c> object.
		/// </para>
		/// <para>
		/// Prior to Windows 7 and Windows Server 2008 R2, this implementation did not zero memory when calling GlobalReAlloc to grow the
		/// memory block. Increasing the size of the byte array with ILockBytes::SetSize or by writing to a location past the current end of
		/// the byte array will leave any unwritten portions of the newly allocated memory uninitialized. The storage objects returned by the
		/// StgCreateDocfileOnILockBytes and StgOpenStorageOnILockBytes may increase the size of the byte array without initializing all of
		/// the newly allocated space.
		/// </para>
		/// <para>
		/// Compound files in memory are typically used as scratch space or with APIs that require a storage object, and in these cases the
		/// uninitialized memory is generally not a concern. However, if the contents of the memory block will be written to a file, consider
		/// the following alternatives to avoid potential information disclosure:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// Copy the logical contents of the in-memory compound file to the destination file using the IStorage::CopyTo method rather than
		/// directly writing the contents of the memory block.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// Instead of a compound file in memory, create a temporary file by calling StgCreateStorageEx with a <c>NULL</c> value for the
		/// pwcsName parameter. When it is time to write to the destination file, use the IRootStorage::SwitchToFile method.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// Implement the ILockBytes interface such that memory reallocations are zeroed (see for example the <c>HEAP_ZERO_MEMORY</c> flag in
		/// HeapReAlloc). The memory contents of this byte array can then be written to a file.
		/// </term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/coml2api/nf-coml2api-createilockbytesonhglobal HRESULT
		// CreateILockBytesOnHGlobal( HGLOBAL hGlobal, BOOL fDeleteOnRelease, LPLOCKBYTES *pplkbyt );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("coml2api.h", MSDNShortId = "e7963be7-ccd8-49fb-85bb-e22fbbb6dc5c")]
		public static extern HRESULT CreateILockBytesOnHGlobal([Optional] IntPtr hGlobal, [MarshalAs(UnmanagedType.Bool)] bool fDeleteOnRelease, out ILockBytes pplkbyt);

		/// <summary>
		/// <para>
		/// The <c>CreateILockBytesOnHGlobal</c> function creates a byte array object that uses an HGLOBAL memory handle to store the bytes
		/// intended for in-memory storage of a compound file. This object is the OLE-provided implementation of the ILockBytes interface.
		/// </para>
		/// <para>
		/// The returned byte array object supports both reading and writing, but does not support region locking . The object calls the
		/// GlobalReAlloc function to grow the memory block as required.
		/// </para>
		/// </summary>
		/// <param name="hGlobal">
		/// A memory handle allocated by the GlobalAlloc function, or if <c>NULL</c> a new handle is to be allocated instead. The handle must
		/// be allocated as moveable and nondiscardable.
		/// </param>
		/// <param name="fDeleteOnRelease">
		/// A flag that specifies whether the underlying handle for this byte array object should be automatically freed when the object is
		/// released. If set to <c>FALSE</c>, the caller must free the hGlobal after the final release. If set to <c>TRUE</c>, the final
		/// release will automatically free the hGlobal parameter.
		/// </param>
		/// <param name="pplkbyt">
		/// The address of ILockBytes pointer variable that receives the interface pointer to the new byte array object.
		/// </param>
		/// <returns>This function supports the standard return values <c>E_INVALIDARG</c> and <c>E_OUTOFMEMORY</c>, as well as the following:</returns>
		/// <remarks>
		/// <para>
		/// If hGlobal is <c>NULL</c>, the <c>CreateILockBytesOnHGlobal</c> allocates a new memory handle and the byte array is empty initially.
		/// </para>
		/// <para>
		/// If hGlobal is not <c>NULL</c>, the initial contents of the byte array object are the current contents of the memory block. Thus,
		/// this function can be used to open an existing byte array in memory, for example to reload a storage object previously created by
		/// the StgCreateDocfileOnILockBytes function. The memory handle and its contents are undisturbed by the creation of the new byte
		/// array object.
		/// </para>
		/// <para>
		/// The initial size of the byte array is the size of hGlobal as returned by the GlobalSize function. This is not necessarily the
		/// same size that was originally allocated for the handle because of rounding. If the logical size of the byte array is important,
		/// follow the call to <c>CreateILockBytesOnHGlobal</c> with a call to ILockBytes::SetSize.
		/// </para>
		/// <para>
		/// After creating the byte array object with CreateStreamOnHGlobal, StgCreateDocfileOnILockBytes can be used to create a new storage
		/// object in memory, or StgOpenStorageOnILockBytes can be used to reopen a previously existing storage object that is already
		/// contained in the memory block. GetHGlobalFromILockBytes can be called to retrieve the memory handle associated with the byte
		/// array object.
		/// </para>
		/// <para>
		/// If a memory handle is passed to <c>CreateILockBytesOnHGlobal</c> or if GetHGlobalFromILockBytes is called, the memory handle of
		/// this function can be directly accessed by the caller while it is still in use by the byte array object. Appropriate caution
		/// should be exercised in the use of this capability and its implications:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// Do not free the hGlobal memory handle during the lifetime of the byte array object. ILockBytes::Releasemust be called before the
		/// memory handle is freed.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// Do not call GlobalReAlloc to change the size of the memory handle during the lifetime of the byte array object. This may cause
		/// application crashes or memory corruption. Avoid creating multiple byte array objects on the same memory handle, because
		/// ILockBytes::WriteAt and ILockBytes::SetSize methods may internally call <c>GlobalReAlloc</c>.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// If possible, avoid accessing the memory block during the lifetime of the byte array object, because the object may internally
		/// call GlobalReAlloc and do not make assumptions about its size and location. If the memory block must be accessed, the memory
		/// access calls should be surrounded by calls to GlobalLock and GlobalUnLock.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// Avoid calling the object’s methods while the memory handle is locked with GlobalLock. This can cause method calls to fail unpredictably.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// If the caller sets the fDeleteOnRelease parameter to <c>FALSE</c>, then the caller must also free the hGlobal after the final
		/// release. If the caller sets the fDeleteOnRelease parameter to <c>TRUE</c>, the final release will automatically free the hGlobal.
		/// The memory handle passed as the hGlobal parameter must be allocated as movable and nondiscardable, as shown in the following example:
		/// </para>
		/// <para>
		/// <c>CreateILockBytesOnHGlobal</c> will accept memory allocated with GMEM_FIXED, but this usage is not recommended. HGLOBALs
		/// allocated with <c>GMEM_FIXED</c> are not really handles and their value can change when they are reallocated. If the memory
		/// handle was allocated with <c>GMEM_FIXED</c> and fDeleteOnRelease is <c>FALSE</c>, then the caller must call
		/// GetHGlobalFromILockBytes to get the correct HGLOBAL value in order to free the handle.
		/// </para>
		/// <para>
		/// This implementation of ILockBytes does not support region locking. Applications that use this implementation with the
		/// StgCreateDocfileOnILockBytes or StgOpenStorageOnILockBytes functions should avoid opening multiple concurrent instances on the
		/// same <c>ILockBytes</c> object.
		/// </para>
		/// <para>
		/// Prior to Windows 7 and Windows Server 2008 R2, this implementation did not zero memory when calling GlobalReAlloc to grow the
		/// memory block. Increasing the size of the byte array with ILockBytes::SetSize or by writing to a location past the current end of
		/// the byte array will leave any unwritten portions of the newly allocated memory uninitialized. The storage objects returned by the
		/// StgCreateDocfileOnILockBytes and StgOpenStorageOnILockBytes may increase the size of the byte array without initializing all of
		/// the newly allocated space.
		/// </para>
		/// <para>
		/// Compound files in memory are typically used as scratch space or with APIs that require a storage object, and in these cases the
		/// uninitialized memory is generally not a concern. However, if the contents of the memory block will be written to a file, consider
		/// the following alternatives to avoid potential information disclosure:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// Copy the logical contents of the in-memory compound file to the destination file using the IStorage::CopyTo method rather than
		/// directly writing the contents of the memory block.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// Instead of a compound file in memory, create a temporary file by calling StgCreateStorageEx with a <c>NULL</c> value for the
		/// pwcsName parameter. When it is time to write to the destination file, use the IRootStorage::SwitchToFile method.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// Implement the ILockBytes interface such that memory reallocations are zeroed (see for example the <c>HEAP_ZERO_MEMORY</c> flag in
		/// HeapReAlloc). The memory contents of this byte array can then be written to a file.
		/// </term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/coml2api/nf-coml2api-createilockbytesonhglobal HRESULT
		// CreateILockBytesOnHGlobal( HGLOBAL hGlobal, BOOL fDeleteOnRelease, LPLOCKBYTES *pplkbyt );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("coml2api.h", MSDNShortId = "e7963be7-ccd8-49fb-85bb-e22fbbb6dc5c")]
		public static extern HRESULT CreateILockBytesOnHGlobal(SafeHGlobalHandle hGlobal, [MarshalAs(UnmanagedType.Bool)] bool fDeleteOnRelease, out ILockBytes pplkbyt);

		/// <summary>
		/// The <c>FmtIdToPropStgName</c> function converts a property set format identifier (FMTID) to its storage or stream name.
		/// </summary>
		/// <param name="pfmtid">A pointer to the FMTID of the property set.</param>
		/// <param name="oszName">
		/// A pointer to a null-terminated string that receives the storage or stream name of the property set identified by pfmtid. The
		/// array allocated for this string must be at least CCH_MAX_PROPSTG_NAME (32) characters in length.
		/// </param>
		/// <returns>This function supports the standard return value E_INVALIDARG as well as the following:</returns>
		/// <remarks>
		/// <para>
		/// <c>FmtIdToPropStgName</c> maps a property set FMTID to its stream name for a simple property set or to its storage name for a
		/// nonsimple property set.
		/// </para>
		/// <para>
		/// This function is useful in creating or opening a property set using the PROPSETFLAG_UNBUFFERED value with the StgCreatePropStg
		/// and StgOpenPropStg functions. For more information about PROPSETFLAG_UNBUFFERED, see PROPSETFLAG Constants.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/coml2api/nf-coml2api-fmtidtopropstgname HRESULT FmtIdToPropStgName( const
		// FMTID *pfmtid, LPOLESTR oszName );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("coml2api.h", MSDNShortId = "044f8883-bbd2-4cd3-b9dc-739ecb711bdd")]
		public static extern HRESULT FmtIdToPropStgName(in Guid pfmtid, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder oszName);

		/// <summary>The <c>GetConvertStg</c> function returns the current value of the convert bit for the specified storage object.</summary>
		/// <param name="pStg">IStorage pointer to the storage object from which the convert bit is to be retrieved.</param>
		/// <returns>IStorage::OpenStream, IStorage::OpenStorage, and ISequentialStream::Read storage and stream access errors.</returns>
		/// <remarks>
		/// <para>
		/// The <c>GetConvertStg</c> function is called by object servers that support the conversion of an object from one format to
		/// another. The server must be able to read the storage object using the format of its previous class identifier (CLSID) and write
		/// the object using the format of its new CLSID to support the object's conversion. For example, a spreadsheet created by one
		/// application can be converted to the format used by a different application.
		/// </para>
		/// <para>
		/// The convert bit is set by a call to the SetConvertStg function. A container application can call this function on the request of
		/// an end user, or a setup program can call it when installing a new version of an application. An end user requests converting an
		/// object through the <c>Convert To</c> dialog box. When an object is converted, the new CLSID is permanently assigned to the
		/// object, so the object is subsequently associated with the new CLSID.
		/// </para>
		/// <para>
		/// Then, when the object is activated, its server calls the <c>GetConvertStg</c> function to retrieve the value of the convert bit
		/// from the storage object. If the bit is set, the object's CLSID has been changed, and the server must read the old format and
		/// write the new format for the storage object.
		/// </para>
		/// <para>
		/// After retrieving the bit value, the object application should clear the convert bit by calling the SetConvertStg function with
		/// its fConvert parameter set to <c>FALSE</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/coml2api/nf-coml2api-getconvertstg HRESULT GetConvertStg( LPSTORAGE pStg );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("coml2api.h", MSDNShortId = "748649a2-cf75-4ffa-ac1f-4a148b845d21")]
		public static extern HRESULT GetConvertStg(IStorage pStg);

		/// <summary>
		/// The <c>GetHGlobalFromILockBytes</c> function retrieves a global memory handle to a byte array object created using the
		/// CreateILockBytesOnHGlobal function.
		/// </summary>
		/// <param name="plkbyt">
		/// Pointer to the ILockBytes interface on the byte-array object previously created by a call to the CreateILockBytesOnHGlobal function.
		/// </param>
		/// <param name="phglobal">Pointer to the current memory handle used by the specified byte-array object.</param>
		/// <returns>This function returns HRESULT.</returns>
		/// <remarks>
		/// <para>
		/// After a call to CreateILockBytesOnHGlobal, which creates a byte array object on global memory, <c>GetHGlobalFromILockBytes</c>
		/// retrieves a pointer to the handle of the global memory underlying the byte array object. The handle this function returns might
		/// be different from the original handle due to intervening calls to the GlobalReAlloc function.
		/// </para>
		/// <para>
		/// The contents of the returned memory handle can be written to a clean disk file, and then opened as a storage object using the
		/// StgOpenStorage function.
		/// </para>
		/// <para>This function only works within the same process from which the byte array was created.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/coml2api/nf-coml2api-gethglobalfromilockbytes HRESULT
		// GetHGlobalFromILockBytes( LPLOCKBYTES plkbyt, HGLOBAL *phglobal );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("coml2api.h", MSDNShortId = "084fcd1d-5b85-448c-862a-378353e1e2e6")]
		public static extern HRESULT GetHGlobalFromILockBytes([In] ILockBytes plkbyt, out IntPtr phglobal);

		/// <summary>The <c>PropStgNameToFmtId</c> function converts a property set storage or stream name to its format identifier.</summary>
		/// <param name="oszName">
		/// A pointer to a null-terminated Unicode string that contains the stream name of a simple property set or the storage name of a
		/// nonsimple property set.
		/// </param>
		/// <param name="pfmtid">A pointer to a FMTID variable that receives the format identifier of the property set specified by oszName.</param>
		/// <returns>This function supports the standard return value E_INVALIDARG as well as the following:</returns>
		/// <remarks>
		/// <para>
		/// The <c>PropStgNameToFmtId</c> function maps the stream name of a simple property set or the storage name of a nonsimple property
		/// set to its format identifier.
		/// </para>
		/// <para>
		/// This function is useful in creating or opening a property set using the PROPSETFLAG_UNBUFFERED value with the StgCreatePropStg
		/// and StgOpenPropStg functions. For more information about PROPSETFLAG_UNBUFFERED, see PROPSETFLAG Constants.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/coml2api/nf-coml2api-propstgnametofmtid HRESULT PropStgNameToFmtId( const
		// LPOLESTR oszName, FMTID *pfmtid );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("coml2api.h", MSDNShortId = "bbbaf5a3-df17-42fd-ba2b-ad5b572c8a3f")]
		public static extern HRESULT PropStgNameToFmtId([MarshalAs(UnmanagedType.LPWStr)] string oszName, out Guid pfmtid);

		/// <summary>The <c>ReadClassStg</c> function reads the CLSID previously written to a storage object with the WriteClassStg function.</summary>
		/// <param name="pStg">Pointer to the IStorage interface on the storage object containing the CLSID to be retrieved.</param>
		/// <param name="pclsid">Pointer to where the CLSID is written. May return CLSID_NULL.</param>
		/// <returns>
		/// <para>This function supports the standard return value E_OUTOFMEMORY, in addition to the following:</para>
		/// <para>This function also returns any of the error values returned by the IStorage::Stat method.</para>
		/// </returns>
		/// <remarks>
		/// <c>ReadClassStg</c> is a helper function that calls the IStorage::Stat method and retrieves the CLSID previously written to the
		/// storage object with a call to WriteClassStg from the STATSTG structure.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/coml2api/nf-coml2api-readclassstg HRESULT ReadClassStg( LPSTORAGE pStg, CLSID
		// *pclsid );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("coml2api.h", MSDNShortId = "90256fcd-54ce-48e1-aa12-d8f91cd4dfb1")]
		public static extern HRESULT ReadClassStg([In] IStorage pStg, out Guid pclsid);

		/// <summary>The <c>ReadClassStm</c> function reads the CLSID previously written to a stream object with the WriteClassStm function.</summary>
		/// <param name="pStm">
		/// A pointer to the IStream interface on the stream object that contains the CLSID to be read. This CLSID must have been previously
		/// written to the stream object using WriteClassStm.
		/// </param>
		/// <param name="pclsid">A pointer to where the CLSID is to be written.</param>
		/// <returns>This function also returns any of the error values returned by the ISequentialStream::Read method.</returns>
		/// <remarks>
		/// Most applications do not call the <c>ReadClassStm</c> function directly. COM calls it before making a call to an object's
		/// IPersistStream::Load implementation.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/coml2api/nf-coml2api-readclassstm HRESULT ReadClassStm( LPSTREAM pStm, CLSID
		// *pclsid );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("coml2api.h", MSDNShortId = "bcf11c5b-e164-4a0f-b30f-ee9e76c4356d")]
		public static extern HRESULT ReadClassStm([In] IStream pStm, out Guid pclsid);

		/// <summary>
		/// <para>
		/// The <c>StgCreateDocfile</c> function creates a new compound file storage object using the COM-provided compound file
		/// implementation for the IStorage interface.
		/// </para>
		/// <para>
		/// <c>Note</c> Applications should use the new function, StgCreateStorageEx, instead of <c>StgCreateDocfile</c>, to take advantage
		/// of enhanced Structured Storage features. This function, <c>StgCreateDocfile</c>, still exists for compatibility with Windows 2000.
		/// </para>
		/// </summary>
		/// <param name="pwcsName">
		/// A pointer to a null-terminated Unicode string name for the compound file being created. It is passed uninterpreted to the file
		/// system. This can be a relative name or <c>NULL</c>. If <c>NULL</c>, a temporary compound file is allocated with a unique name.
		/// </param>
		/// <param name="grfMode">
		/// Specifies the access mode to use when opening the new storage object. For more information, see STGM Constants. If the caller
		/// specifies transacted mode together with STGM_CREATE or STGM_CONVERT, the overwrite or conversion takes place when the commit
		/// operation is called for the root storage. If IStorage::Commit is not called for the root storage object, previous contents of the
		/// file will be restored. STGM_CREATE and STGM_CONVERT cannot be combined with the STGM_NOSNAPSHOT flag, because a snapshot copy is
		/// required when a file is overwritten or converted in the transacted mode.
		/// </param>
		/// <param name="reserved">Reserved for future use; must be zero.</param>
		/// <param name="ppstgOpen">A pointer to the location of the IStorage pointer to the new storage object.</param>
		/// <returns>
		/// <c>StgCreateDocfile</c> can also return any file system errors or system errors wrapped in an <c>HRESULT</c>. For more
		/// information, see Error Handling Strategies and Handling Unknown Errors.
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>StgCreateDocfile</c> function creates a new storage object using the COM-provided, compound-file implementation for the
		/// IStorage interface. The name of the open compound file can be retrieved by calling the IStorage::Stat method.
		/// </para>
		/// <para>
		/// <c>StgCreateDocfile</c> creates the file if it does not exist. If it does exist, the use of the STGM_CREATE, STGM_CONVERT, and
		/// STGM_FAILIFTHERE flags in the grfMode parameter indicate how to proceed. For more information, see STGM Constants.
		/// </para>
		/// <para>
		/// If the compound file is opened in transacted mode (the grfMode parameter specifies STGM_TRANSACTED) and a file with this name
		/// already exists, the existing file is not altered until all outstanding changes are committed. If the calling process lacks write
		/// access to the existing file (because of access control in the file system), the grfMode parameter can only specify STGM_READ and
		/// not STGM_WRITE or STGM_READWRITE. The resulting new open compound file can still be written to, but a subsequent commit operation
		/// will fail (in transacted mode, write permissions are enforced at commit time).
		/// </para>
		/// <para>
		/// Specifying STGM_SIMPLE provides a much faster implementation of a compound file object in a limited, but frequently used case.
		/// This can be used by applications that require a compound-file implementation with multiple streams and no storages. The simple
		/// mode does not support all of the methods on IStorage. For more information, see STGM Constants.
		/// </para>
		/// <para>
		/// If the grfMode parameter specifies STGM_TRANSACTED and no file yet exists with the name specified by the pwcsName parameter, the
		/// file is created immediately. In an access-controlled file system, the caller must have write permissions in the file system
		/// directory in which the compound file is created. If STGM_TRANSACTED is not specified, and STGM_CREATE is specified, an existing
		/// file with the same name is destroyed before the new file is created.
		/// </para>
		/// <para>
		/// <c>StgCreateDocfile</c> can be used to create a temporary compound file by passing a <c>NULL</c> value for the pwcsName
		/// parameter. However, these files are temporary only in the sense that they have a system-provided unique name — likely one that is
		/// meaningless to the user. The caller is responsible for deleting the temporary file when finished with it, unless
		/// STGM_DELETEONRELEASE was specified for the grfMode parameter.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/coml2api/nf-coml2api-stgcreatedocfile HRESULT StgCreateDocfile( const WCHAR
		// *pwcsName, DWORD grfMode, DWORD reserved, IStorage **ppstgOpen );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("coml2api.h", MSDNShortId = "3292484b-8eff-438d-b989-b58ae323872b")]
		public static extern HRESULT StgCreateDocfile([MarshalAs(UnmanagedType.LPWStr)] string pwcsName, STGM grfMode, [Optional] uint reserved, out IStorage ppstgOpen);

		/// <summary>
		/// The <c>StgCreateDocfileOnILockBytes</c> function creates and opens a new compound file storage object on top of a byte-array
		/// object provided by the caller. The storage object supports the COM-provided, compound-file implementation for the IStorage interface.
		/// </summary>
		/// <param name="plkbyt">
		/// A pointer to the ILockBytes interface on the underlying byte-array object on which to create a compound file.
		/// </param>
		/// <param name="grfMode">
		/// Specifies the access mode to use when opening the new compound file. For more information, see STGM Constants and the Remarks
		/// section below.
		/// </param>
		/// <param name="reserved">Reserved for future use; must be zero.</param>
		/// <param name="ppstgOpen">A pointer to the location of the IStorage pointer on the new storage object.</param>
		/// <returns>
		/// The <c>StgCreateDocfileOnILockBytes</c> function can also return any file system errors, or system errors wrapped in an
		/// <c>HRESULT</c>, or ILockBytes interface error return values. For more information, see Error Handling Strategies and Handling
		/// Unknown Errors.
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>StgCreateDocfileOnILockBytes</c> function creates a storage object on top of a byte array object using the COM-provided,
		/// compound-file implementation of the IStorage interface. <c>StgCreateDocfileOnILockBytes</c> can be used to store a document in an
		/// arbitrary data store, such as memory or a relational database. The byte array (indicated by the pLkbyt parameter, which points to
		/// the ILockBytes interface on the object) is used for the underlying storage in place of a disk file.
		/// </para>
		/// <para>
		/// Except for specifying a programmer-provided byte-array object, <c>StgCreateDocfileOnILockBytes</c> is similar to the
		/// StgCreateDocfile function.
		/// </para>
		/// <para>
		/// The newly created compound file is opened according to the access modes in the grfMode parameter, subject to the following restrictions:
		/// </para>
		/// <para>
		/// Sharing mode behavior and transactional isolation depend on the ILockBytes implementation supporting LockRegion and UnlockRegion
		/// with LOCK_ONLYONCE semantics. Implementations can indicate to structured storage they support this functionality by setting the
		/// <c>LOCK_ONLYONCE</c> bit in the <c>grfLocksSupported</c> member of STATSTG. If an <c>ILockBytes</c> implementation does not
		/// support this functionality, sharing modes will not be enforced, and root-level transactional commits will not coordinate properly
		/// with other transactional instances opened on the same byte array. Applications that use an <c>ILockBytes</c> implementation that
		/// does not support region locking, such as the CreateStreamOnHGlobal implementation, should avoid opening multiple concurrent
		/// instances on the same byte array.
		/// </para>
		/// <para><c>StgCreateDocfileOnILockBytes</c> does not support simple mode. The STGM_SIMPLE flag, if present, is ignored.</para>
		/// <para>
		/// For conversion purposes, the file is considered to already exist. As a result, it is not useful to use the STGM_FAILIFTHERE
		/// value, because it causes an error to be returned. However, both STGM_CREATE and STGM_CONVERT remain useful.
		/// </para>
		/// <para>
		/// The ability to build a compound file on top of a byte-array object is provided to support having the data (underneath an IStorage
		/// and IStream tree structure) live in a nonpersistent space. Given this capability, there is nothing preventing a document that is
		/// stored in a file from using this facility. For example, a container might do this to minimize the impact on its file format
		/// caused by adopting COM. However, it is recommended that COM documents adopt the <c>IStorage</c> interface for their own
		/// outer-level storage. This has the following advantages:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// The storage structure of the document is the same as its storage structure when it is an embedded object, reducing the number of
		/// cases the application needs to handle.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// One can write tools to access the OLE embedded and linked objects within the document without special knowledge of the document's
		/// file format. An example of such a tool is a copy utility that copies all the documents included in a container containing linked
		/// objects. A copy utility like this needs access to the contained links to determine the extent of files to be copied.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// The IStorage implementation addresses the problem of how to commit the changes to the file. An application using the ILockBytes
		/// interface must handle these issues itself.
		/// </term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/coml2api/nf-coml2api-stgcreatedocfileonilockbytes HRESULT
		// StgCreateDocfileOnILockBytes( ILockBytes *plkbyt, DWORD grfMode, DWORD reserved, IStorage **ppstgOpen );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("coml2api.h", MSDNShortId = "8af5098d-db04-4273-8f5f-6d1a1d9541de")]
		public static extern HRESULT StgCreateDocfileOnILockBytes([In] ILockBytes plkbyt, STGM grfMode, [Optional] uint reserved, out IStorage ppstgOpen);

		/// <summary>
		/// The <c>StgCreatePropSetStg</c> function creates a property set storage object from a specified storage object. The property set
		/// storage object supplies the system-provided, stand-alone implementation of the IPropertySetStorage interface.
		/// </summary>
		/// <param name="pStorage">A pointer to the storage object that contains or will contain one or more property sets.</param>
		/// <param name="dwReserved">Reserved for future use; must be zero.</param>
		/// <param name="ppPropSetStg">
		/// A pointer to IPropertySetStorage* pointer variable that receives the interface pointer to the property-set storage object.
		/// </param>
		/// <returns>This function supports the standard return value <c>E_INVALIDARG</c> as well as the following:</returns>
		/// <remarks>
		/// <para>
		/// The <c>StgCreatePropSetStg</c> function creates an IPropertySetStorage interface that will act on the given IStorage interface
		/// specified by the pStorage parameter. This function does not modify this <c>IStorage</c> by itself, although subsequent calls to
		/// the <c>IPropertySetStorage</c> interface might.
		/// </para>
		/// <para>
		/// <c>StgCreatePropSetStg</c> calls IUnknown::AddRef on the storage object specified by pStorage. The caller must release the object
		/// when it is no longer required by calling Release.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following example code shows how this function creates a property set within a storage object.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/coml2api/nf-coml2api-stgcreatepropsetstg HRESULT StgCreatePropSetStg(
		// IStorage *pStorage, DWORD dwReserved, IPropertySetStorage **ppPropSetStg );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("coml2api.h", MSDNShortId = "0113b29d-23aa-4590-b8ac-33789a7a2ed4")]
		public static extern HRESULT StgCreatePropSetStg([In] IStorage pStorage, [Optional] uint dwReserved, out IPropertySetStorage ppPropSetStg);

		/// <summary>
		/// The <c>StgCreatePropStg</c> function creates and opens a property set in a specified storage or stream object. The property set
		/// supplies the system-provided, stand-alone implementation of the IPropertyStorage interface.
		/// </summary>
		/// <param name="pUnk">
		/// A pointer to the <c>IUnknown</c> interface on the storage or stream object that stores the new property set.
		/// </param>
		/// <param name="fmtid">The FMTID of the property set to be created.</param>
		/// <param name="pclsid">
		/// A Pointer to the initial CLSID for this property set. May be <c>NULL</c>, in which case pclsid is set to all zeroes.
		/// </param>
		/// <param name="grfFlags">The values from PROPSETFLAG Constants that determine how the property set is created and opened.</param>
		/// <param name="dwReserved">Reserved; must be zero.</param>
		/// <param name="ppPropStg">
		/// The address of an IPropertyStorage* pointer variable that receives the interface pointer to the new property set.
		/// </param>
		/// <returns>This function supports the standard return values E_INVALIDARG and E_UNEXPECTED, in addition to the following:</returns>
		/// <remarks>
		/// <para>
		/// <c>StgCreatePropStg</c> creates and opens a new property set which supplies the system-provided, stand-alone implementation of
		/// the IPropertyStorage interface. The new property set is contained in the storage or stream object specified by pUnk. The value of
		/// the grfFlags parameter indicates whether pUnk specifies a storage or stream object. For example, if PROPSETFLAG_NONSIMPLE is set,
		/// then pUnk can be queried for an IStorage interface on a storage object.
		/// </para>
		/// <para>
		/// In either case, this function calls pUnk-&gt;AddRef for the storage or stream object containing the property set. It is the
		/// responsibility of the caller to release the object when it is no longer needed.
		/// </para>
		/// <para>
		/// This function is similar to the IPropertySetStorage::Create method. However, <c>StgCreatePropStg</c> adds the pUnk parameter and
		/// supports the PROPSETFLAG_UNBUFFERED value for the grfFlags parameter. Use this function instead of the <c>Create</c> method if
		/// you have an IStorage interface that does not support the IPropertySetStorage interface, or if you want to use the
		/// PROPSETFLAG_UNBUFFERED value. For more information about using this PROPSETFLAG_UNBUFFERED enumeration value, see PROPSETFLAG Constants.
		/// </para>
		/// <para>
		/// The property set automatically contains code page and locale identifier (ID) properties. These are set to the current system
		/// default and the current user default, respectively.
		/// </para>
		/// <para>
		/// The grfFlags parameter is a combination of values taken from PROPSETFLAG Constants. The new enumeration value
		/// PROPSETFLAG_UNBUFFERED is supported. For more information, see <c>PROPSETFLAG Constants</c>.
		/// </para>
		/// <para>
		/// This function is exported out of the redistributable Iprop.dll, which is included in Windows NT 4.0 with Service Pack 2 (SP2) and
		/// later and available as a redistributable in Windows 95, Windows 98 and later. In Windows 2000 and Windows XP, it is exported out
		/// of ole32.dll. It can also be exported out of iprop.dll in Windows 2000 and Windows XP, but the call gets forwarded to ole32.dll.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/coml2api/nf-coml2api-stgcreatepropstg HRESULT StgCreatePropStg( IUnknown
		// *pUnk, REFFMTID fmtid, const CLSID *pclsid, DWORD grfFlags, DWORD dwReserved, IPropertyStorage **ppPropStg );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("coml2api.h", MSDNShortId = "fc171888-3723-4894-a356-1b234352c4e8")]
		public static extern HRESULT StgCreatePropStg([In, MarshalAs(UnmanagedType.IUnknown)] object pUnk, in Guid fmtid, in Guid pclsid, PROPSETFLAG grfFlags, [Optional] uint dwReserved, out IPropertyStorage ppPropStg);

		/// <summary>
		/// <para>
		/// The <c>StgCreateStorageEx</c> function creates a new storage object using a provided implementation for the IStorage or
		/// IPropertySetStorage interfaces. To open an existing file, use the StgOpenStorageEx function instead.
		/// </para>
		/// <para>
		/// Applications written for Windows 2000, Windows Server 2003 and Windows XP must use <c>StgCreateStorageEx</c> rather than
		/// StgCreateDocfile to take advantage of the enhanced Windows 2000 and Windows XP Structured Storage features.
		/// </para>
		/// </summary>
		/// <param name="pwcsName">
		/// <para>
		/// A pointer to the path of the file to create. It is passed uninterpreted to the file system. This can be a relative name or
		/// <c>NULL</c>. If <c>NULL</c>, a temporary file is allocated with a unique name. If non- <c>NULL</c>, the string size must not
		/// exceed MAX_PATH characters.
		/// </para>
		/// <para><c>Windows 2000:</c> Unlike the CreateFile function, you cannot exceed the MAX_PATH limit by using the "\?" prefix.</para>
		/// </param>
		/// <param name="grfMode">
		/// A value that specifies the access mode to use when opening the new storage object. For more information, see STGM Constants. If
		/// the caller specifies transacted mode together with STGM_CREATE or STGM_CONVERT, the overwrite or conversion takes place when the
		/// commit operation is called for the root storage. If IStorage::Commit is not called for the root storage object, previous contents
		/// of the file will be restored. STGM_CREATE and STGM_CONVERT cannot be combined with the STGM_NOSNAPSHOT flag, because a snapshot
		/// copy is required when a file is overwritten or converted in the transacted mode.
		/// </param>
		/// <param name="stgfmt">A value that specifies the storage file format. For more information, see the STGFMT enumeration.</param>
		/// <param name="grfAttrs">
		/// <para>A value that depends on the value of the stgfmt parameter.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Parameter Values</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>STGFMT_DOCFILE</term>
		/// <term>
		/// 0, or FILE_FLAG_NO_BUFFERING. For more information, see CreateFile. If the sector size of the file, specified in pStgOptions, is
		/// not an integer multiple of the underlying disk's physical sector size, this operation will fail.
		/// </term>
		/// </item>
		/// <item>
		/// <term>All other values of stgfmt</term>
		/// <term>Must be 0.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pStgOptions">
		/// The pStgOptions parameter is valid only if the stgfmt parameter is set to STGFMT_DOCFILE. If the stgfmt parameter is set to
		/// STGFMT_DOCFILE, pStgOptions points to the STGOPTIONS structure, which specifies features of the storage object, such as the
		/// sector size. This parameter may be <c>NULL</c>, which creates a storage object with a default sector size of 512 bytes. If non-
		/// <c>NULL</c>, the <c>ulSectorSize</c> member must be set to either 512 or 4096. If set to 4096, STGM_SIMPLE may not be specified
		/// in the grfMode parameter. The <c>usVersion</c> member must be set before calling <c>StgCreateStorageEx</c>. For more information,
		/// see <c>STGOPTIONS</c>.
		/// </param>
		/// <param name="pSecurityDescriptor">
		/// <para>
		/// Enables the ACLs to be set when the file is created. If not <c>NULL</c>, needs to be a pointer to the SECURITY_ATTRIBUTES
		/// structure. See CreateFile for information on how to set ACLs on files.
		/// </para>
		/// <para><c>Windows Server 2003, Windows 2000 Server, Windows XP and Windows 2000 Professional:</c> Value must be <c>NULL</c>.</para>
		/// </param>
		/// <param name="riid">
		/// A value that specifies the interface identifier (IID) of the interface pointer to return. This IID may be for the IStorage
		/// interface or the IPropertySetStorage interface.
		/// </param>
		/// <param name="ppObjectOpen">
		/// A pointer to an interface pointer variable that receives a pointer for an interface on the new storage object; contains
		/// <c>NULL</c> if operation failed.
		/// </param>
		/// <returns>
		/// This function can also return any file system errors or system errors wrapped in an <c>HRESULT</c>. For more information, see
		/// Error Handling Strategies and Handling Unknown Errors.
		/// </returns>
		/// <remarks>
		/// <para>
		/// When an application modifies its file, it usually creates a copy of the original. The <c>StgCreateStorageEx</c> function is one
		/// way for creating a copy. This function works indirectly with the Encrypting File System (EFS) duplication API. When you use this
		/// function, you will need to set the options for the file storage in the STGOPTIONS structure.
		/// </para>
		/// <para>
		/// <c>StgCreateStorageEx</c> is a superset of the StgCreateDocfile function, and should be used by new code. Future enhancements to
		/// Structured Storage will be exposed through the <c>StgCreateStorageEx</c> function. See the following Requirements section for
		/// information on supported platforms.
		/// </para>
		/// <para>
		/// The <c>StgCreateStorageEx</c> function creates a new storage object using one of the system-provided, structured-storage
		/// implementations. This function can be used to obtain an IStorage compound file implementation, an IPropertySetStorage compound
		/// file implementation, or to obtain an IPropertySetStorage NTFS implementation.
		/// </para>
		/// <para>
		/// When a new file is created, the storage implementation used depends on the flag that you specify and on the type of drive on
		/// which the file is stored. For more information, see the STGFMT enumeration.
		/// </para>
		/// <para>
		/// <c>StgCreateStorageEx</c> creates the file if it does not exist. If it does exist, the use of the STGM_CREATE, STGM_CONVERT, and
		/// STGM_FAILIFTHERE flags in the grfMode parameter indicate how to proceed. For more information on these values, see STGM
		/// Constants. It is not valid, in direct mode, to specify the STGM_READ mode in the grfMode parameter (direct mode is indicated by
		/// not specifying the STGM_TRANSACTED flag). This function cannot be used to open an existing file; use the StgOpenStorageEx
		/// function instead.
		/// </para>
		/// <para>
		/// You can use the <c>StgCreateStorageEx</c> function to get access to the root storage of a structured-storage document or the
		/// property set storage of any file that supports property sets. See the STGFMT documentation for information about which IIDs are
		/// supported for different <c>STGFMT</c> values.
		/// </para>
		/// <para>
		/// When a file is created with this function to access the NTFS property set implementation, special sharing rules apply. For more
		/// information, see IPropertySetStorage-NTFS Implementation.
		/// </para>
		/// <para>
		/// If a compound file is created in transacted mode (by specifying STGM_TRANSACTED) and read-only mode (by specifying STGM_READ), it
		/// is possible to make changes to the returned storage object. For example, it is possible to call IStorage::CreateStream. However,
		/// it is not possible to commit those changes by calling IStorage::Commit. Therefore, such changes will be lost.
		/// </para>
		/// <para>
		/// Specifying STGM_SIMPLE provides a much faster implementation of a compound file object in a limited, but frequently used case
		/// involving applications that require a compound file implementation with multiple streams and no storages. For more information,
		/// see STGM Constants. It is not valid to specify that STGM_TRANSACTED if STGM_SIMPLE is specified.
		/// </para>
		/// <para>
		/// The simple mode does not support all the methods on IStorage. Specifically, in simple mode, supported <c>IStorage</c> methods are
		/// CreateStream, Commit, and SetClass as well as the COM IUnknown methods of QueryInterface, AddRef and Release. In addition,
		/// SetElementTimes is supported with a <c>NULL</c> name, allowing applications to set times on a root storage. All the other methods
		/// of <c>IStorage</c> return STG_E_INVALIDFUNCTION.
		/// </para>
		/// <para>
		/// If the grfMode parameter specifies STGM_TRANSACTED and no file yet exists with the name specified by the pwcsName parameter, the
		/// file is created immediately. In an access-controlled file system, the caller must have write permissions for the file system
		/// directory in which the compound file is created. If STGM_TRANSACTED is not specified, and STGM_CREATE is specified, an existing
		/// file with the same name is destroyed before creating the new file.
		/// </para>
		/// <para>
		/// You can also use <c>StgCreateStorageEx</c> to create a temporary compound file by passing a <c>NULL</c> value for the pwcsName
		/// parameter. However, these files are temporary only in the sense that they have a unique system-provided name – one that is
		/// probably meaningless to the user. The caller is responsible for deleting the temporary file when finished with it, unless
		/// STGM_DELETEONRELEASE was specified for the grfMode parameter. For more information on these flags, see STGM Constants.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/coml2api/nf-coml2api-stgcreatestorageex HRESULT StgCreateStorageEx( const
		// WCHAR *pwcsName, DWORD grfMode, DWORD stgfmt, DWORD grfAttrs, STGOPTIONS *pStgOptions, PSECURITY_DESCRIPTOR pSecurityDescriptor,
		// REFIID riid, void **ppObjectOpen );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("coml2api.h", MSDNShortId = "6442977d-e980-419e-abe9-9d15dbb045c1")]
		public static extern HRESULT StgCreateStorageEx([In, Optional, MarshalAs(UnmanagedType.LPWStr)] string pwcsName, STGM grfMode, STGFMT stgfmt, FileFlagsAndAttributes grfAttrs, in STGOPTIONS pStgOptions,
			[Optional] PSECURITY_DESCRIPTOR pSecurityDescriptor, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 6)] out object ppObjectOpen);

		/// <summary>
		/// <para>
		/// The <c>StgCreateStorageEx</c> function creates a new storage object using a provided implementation for the IStorage or
		/// IPropertySetStorage interfaces. To open an existing file, use the StgOpenStorageEx function instead.
		/// </para>
		/// <para>
		/// Applications written for Windows 2000, Windows Server 2003 and Windows XP must use <c>StgCreateStorageEx</c> rather than
		/// StgCreateDocfile to take advantage of the enhanced Windows 2000 and Windows XP Structured Storage features.
		/// </para>
		/// </summary>
		/// <param name="pwcsName">
		/// <para>
		/// A pointer to the path of the file to create. It is passed uninterpreted to the file system. This can be a relative name or
		/// <c>NULL</c>. If <c>NULL</c>, a temporary file is allocated with a unique name. If non- <c>NULL</c>, the string size must not
		/// exceed MAX_PATH characters.
		/// </para>
		/// <para><c>Windows 2000:</c> Unlike the CreateFile function, you cannot exceed the MAX_PATH limit by using the "\?" prefix.</para>
		/// </param>
		/// <param name="grfMode">
		/// A value that specifies the access mode to use when opening the new storage object. For more information, see STGM Constants. If
		/// the caller specifies transacted mode together with STGM_CREATE or STGM_CONVERT, the overwrite or conversion takes place when the
		/// commit operation is called for the root storage. If IStorage::Commit is not called for the root storage object, previous contents
		/// of the file will be restored. STGM_CREATE and STGM_CONVERT cannot be combined with the STGM_NOSNAPSHOT flag, because a snapshot
		/// copy is required when a file is overwritten or converted in the transacted mode.
		/// </param>
		/// <param name="stgfmt">A value that specifies the storage file format. For more information, see the STGFMT enumeration.</param>
		/// <param name="grfAttrs">
		/// <para>A value that depends on the value of the stgfmt parameter.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Parameter Values</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>STGFMT_DOCFILE</term>
		/// <term>
		/// 0, or FILE_FLAG_NO_BUFFERING. For more information, see CreateFile. If the sector size of the file, specified in pStgOptions, is
		/// not an integer multiple of the underlying disk's physical sector size, this operation will fail.
		/// </term>
		/// </item>
		/// <item>
		/// <term>All other values of stgfmt</term>
		/// <term>Must be 0.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pStgOptions">
		/// The pStgOptions parameter is valid only if the stgfmt parameter is set to STGFMT_DOCFILE. If the stgfmt parameter is set to
		/// STGFMT_DOCFILE, pStgOptions points to the STGOPTIONS structure, which specifies features of the storage object, such as the
		/// sector size. This parameter may be <c>NULL</c>, which creates a storage object with a default sector size of 512 bytes. If non-
		/// <c>NULL</c>, the <c>ulSectorSize</c> member must be set to either 512 or 4096. If set to 4096, STGM_SIMPLE may not be specified
		/// in the grfMode parameter. The <c>usVersion</c> member must be set before calling <c>StgCreateStorageEx</c>. For more information,
		/// see <c>STGOPTIONS</c>.
		/// </param>
		/// <param name="pSecurityDescriptor">
		/// <para>
		/// Enables the ACLs to be set when the file is created. If not <c>NULL</c>, needs to be a pointer to the SECURITY_ATTRIBUTES
		/// structure. See CreateFile for information on how to set ACLs on files.
		/// </para>
		/// <para><c>Windows Server 2003, Windows 2000 Server, Windows XP and Windows 2000 Professional:</c> Value must be <c>NULL</c>.</para>
		/// </param>
		/// <param name="riid">
		/// A value that specifies the interface identifier (IID) of the interface pointer to return. This IID may be for the IStorage
		/// interface or the IPropertySetStorage interface.
		/// </param>
		/// <param name="ppObjectOpen">
		/// A pointer to an interface pointer variable that receives a pointer for an interface on the new storage object; contains
		/// <c>NULL</c> if operation failed.
		/// </param>
		/// <returns>
		/// This function can also return any file system errors or system errors wrapped in an <c>HRESULT</c>. For more information, see
		/// Error Handling Strategies and Handling Unknown Errors.
		/// </returns>
		/// <remarks>
		/// <para>
		/// When an application modifies its file, it usually creates a copy of the original. The <c>StgCreateStorageEx</c> function is one
		/// way for creating a copy. This function works indirectly with the Encrypting File System (EFS) duplication API. When you use this
		/// function, you will need to set the options for the file storage in the STGOPTIONS structure.
		/// </para>
		/// <para>
		/// <c>StgCreateStorageEx</c> is a superset of the StgCreateDocfile function, and should be used by new code. Future enhancements to
		/// Structured Storage will be exposed through the <c>StgCreateStorageEx</c> function. See the following Requirements section for
		/// information on supported platforms.
		/// </para>
		/// <para>
		/// The <c>StgCreateStorageEx</c> function creates a new storage object using one of the system-provided, structured-storage
		/// implementations. This function can be used to obtain an IStorage compound file implementation, an IPropertySetStorage compound
		/// file implementation, or to obtain an IPropertySetStorage NTFS implementation.
		/// </para>
		/// <para>
		/// When a new file is created, the storage implementation used depends on the flag that you specify and on the type of drive on
		/// which the file is stored. For more information, see the STGFMT enumeration.
		/// </para>
		/// <para>
		/// <c>StgCreateStorageEx</c> creates the file if it does not exist. If it does exist, the use of the STGM_CREATE, STGM_CONVERT, and
		/// STGM_FAILIFTHERE flags in the grfMode parameter indicate how to proceed. For more information on these values, see STGM
		/// Constants. It is not valid, in direct mode, to specify the STGM_READ mode in the grfMode parameter (direct mode is indicated by
		/// not specifying the STGM_TRANSACTED flag). This function cannot be used to open an existing file; use the StgOpenStorageEx
		/// function instead.
		/// </para>
		/// <para>
		/// You can use the <c>StgCreateStorageEx</c> function to get access to the root storage of a structured-storage document or the
		/// property set storage of any file that supports property sets. See the STGFMT documentation for information about which IIDs are
		/// supported for different <c>STGFMT</c> values.
		/// </para>
		/// <para>
		/// When a file is created with this function to access the NTFS property set implementation, special sharing rules apply. For more
		/// information, see IPropertySetStorage-NTFS Implementation.
		/// </para>
		/// <para>
		/// If a compound file is created in transacted mode (by specifying STGM_TRANSACTED) and read-only mode (by specifying STGM_READ), it
		/// is possible to make changes to the returned storage object. For example, it is possible to call IStorage::CreateStream. However,
		/// it is not possible to commit those changes by calling IStorage::Commit. Therefore, such changes will be lost.
		/// </para>
		/// <para>
		/// Specifying STGM_SIMPLE provides a much faster implementation of a compound file object in a limited, but frequently used case
		/// involving applications that require a compound file implementation with multiple streams and no storages. For more information,
		/// see STGM Constants. It is not valid to specify that STGM_TRANSACTED if STGM_SIMPLE is specified.
		/// </para>
		/// <para>
		/// The simple mode does not support all the methods on IStorage. Specifically, in simple mode, supported <c>IStorage</c> methods are
		/// CreateStream, Commit, and SetClass as well as the COM IUnknown methods of QueryInterface, AddRef and Release. In addition,
		/// SetElementTimes is supported with a <c>NULL</c> name, allowing applications to set times on a root storage. All the other methods
		/// of <c>IStorage</c> return STG_E_INVALIDFUNCTION.
		/// </para>
		/// <para>
		/// If the grfMode parameter specifies STGM_TRANSACTED and no file yet exists with the name specified by the pwcsName parameter, the
		/// file is created immediately. In an access-controlled file system, the caller must have write permissions for the file system
		/// directory in which the compound file is created. If STGM_TRANSACTED is not specified, and STGM_CREATE is specified, an existing
		/// file with the same name is destroyed before creating the new file.
		/// </para>
		/// <para>
		/// You can also use <c>StgCreateStorageEx</c> to create a temporary compound file by passing a <c>NULL</c> value for the pwcsName
		/// parameter. However, these files are temporary only in the sense that they have a unique system-provided name – one that is
		/// probably meaningless to the user. The caller is responsible for deleting the temporary file when finished with it, unless
		/// STGM_DELETEONRELEASE was specified for the grfMode parameter. For more information on these flags, see STGM Constants.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/coml2api/nf-coml2api-stgcreatestorageex HRESULT StgCreateStorageEx( const
		// WCHAR *pwcsName, DWORD grfMode, DWORD stgfmt, DWORD grfAttrs, STGOPTIONS *pStgOptions, PSECURITY_DESCRIPTOR pSecurityDescriptor,
		// REFIID riid, void **ppObjectOpen );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("coml2api.h", MSDNShortId = "6442977d-e980-419e-abe9-9d15dbb045c1")]
		public static extern HRESULT StgCreateStorageEx([In, Optional, MarshalAs(UnmanagedType.LPWStr)] string pwcsName, STGM grfMode, STGFMT stgfmt, FileFlagsAndAttributes grfAttrs, [Optional] IntPtr pStgOptions,
			[Optional] PSECURITY_DESCRIPTOR pSecurityDescriptor, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 6)] out object ppObjectOpen);

		/// <summary>The <c>StgIsStorageFile</c> function indicates whether a particular disk file contains a storage object.</summary>
		/// <param name="pwcsName">
		/// Pointer to the null-terminated Unicode string name of the disk file to be examined. The pwcsName parameter is passed
		/// uninterpreted to the underlying file system.
		/// </param>
		/// <returns>
		/// <c>StgIsStorageFile</c> function can also return any file system errors or system errors wrapped in an <c>HRESULT</c>. See Error
		/// Handling Strategies and Handling Unknown Errors
		/// </returns>
		/// <remarks>
		/// <para>
		/// At the beginning of the disk file underlying a storage object is a signature distinguishing a storage object from other file
		/// formats. The <c>StgIsStorageFile</c> function is useful to applications whose documents use a disk file format that might or
		/// might not use storage objects.
		/// </para>
		/// <para>If a root compound file has been created in transacted mode but not yet committed, this method still return S_OK.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/coml2api/nf-coml2api-stgisstoragefile HRESULT StgIsStorageFile( const WCHAR
		// *pwcsName );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("coml2api.h", MSDNShortId = "6a0d2da5-4d5c-4da7-9ea6-3b52cd6673fc")]
		public static extern HRESULT StgIsStorageFile([MarshalAs(UnmanagedType.LPWStr)] string pwcsName);

		/// <summary>The <c>StgIsStorageILockBytes</c> function indicates whether the specified byte array contains a storage object.</summary>
		/// <param name="plkbyt">ILockBytes pointer to the byte array to be examined.</param>
		/// <returns>
		/// This function can also return any file system errors, or system errors wrapped in an <c>HRESULT</c>, or ILockBytes interface
		/// error return values. See Error Handling Strategies and Handling Unknown Errors
		/// </returns>
		/// <remarks>
		/// At the beginning of the byte array underlying a storage object is a signature distinguishing a storage object (supporting the
		/// IStorage interface) from other file formats. The <c>StgIsStorageILockBytes</c> function is useful to applications whose documents
		/// use a byte array (a byte array object supports the ILockBytes interface) that might or might not use storage objects.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/coml2api/nf-coml2api-stgisstorageilockbytes HRESULT StgIsStorageILockBytes(
		// ILockBytes *plkbyt );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("coml2api.h", MSDNShortId = "ce0e29fd-1b21-4064-8e37-1a5d5df8bb61")]
		public static extern HRESULT StgIsStorageILockBytes([In] ILockBytes plkbyt);

		/// <summary>
		/// The <c>StgOpenPropStg</c> function opens a specified property set in a specified storage or stream object. The property set
		/// supplies the system-provided, stand-alone implementation of the IPropertyStorage interface.
		/// </summary>
		/// <param name="pUnk">
		/// The interface pointer for <c>IUnknown</c> interface on the storage or stream object that contains the requested property set object.
		/// </param>
		/// <param name="fmtid">The FMTID of the property set to be opened.</param>
		/// <param name="grfFlags">The values from PROPSETFLAG Constants.</param>
		/// <param name="dwReserved">Reserved for future use; must be zero.</param>
		/// <param name="ppPropStg">
		/// A pointer to an IPropertyStorage* pointer variable that receives the interface pointer to the requested property set.
		/// </param>
		/// <returns>This function supports the standard return values E_INVALIDARG and E_UNEXPECTED, in addition to the following:</returns>
		/// <remarks>
		/// <para>
		/// <c>StgOpenPropStg</c> opens the requested property set and supplies the system-provided, stand-alone implementation of the
		/// IPropertyStorage interface. The requested property set is contained in the storage or stream object specified by pUnk. The value
		/// of the grfFlags parameter indicates whether pUnk specifies a storage or stream object. For example, if PROPSETFLAG_NONSIMPLE is
		/// set, then pUnk can be queried for an IStorage interface on a storage object.
		/// </para>
		/// <para>
		/// In either case, this function calls pUnk-&gt;AddRef for the storage or stream object containing the property set. The caller must
		/// release the object when no longer required.
		/// </para>
		/// <para>
		/// This function is similar to the IPropertySetStorage::Open method. However, <c>StgOpenPropStg</c> adds the pUnk and grfFlags
		/// parameters, including the PROPSETFLAG_UNBUFFERED value for the grfFlags parameter. Use this function instead of the Open method
		/// if you have an IStorage interface that does not support the IPropertySetStorage interface, or if you want to use the
		/// PROPSETFLAG_UNBUFFERED value. For more information about using PROPSETFLAG_UNBUFFERED, see PROPSETFLAG Constants.
		/// </para>
		/// <para>
		/// The grfFlags parameter is a combination of values taken from PROPSETFLAG Constants. The new enumeration value
		/// PROPSETFLAG_UNBUFFERED is supported. For more information, see <c>PROPSETFLAG Constants</c>.
		/// </para>
		/// <para>
		/// This function is exported out of the redistributable iprop.dll, which is included in Windows NT 4.0 with Service Pack 2 (SP2) and
		/// available as a redistributable in Windows 95 and later. In Windows 2000, it is exported out of Ole32.dll. It can also be exported
		/// out of iprop.dll in Windows 2000, but the call gets forwarded to ole32.dll.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/coml2api/nf-coml2api-stgopenpropstg HRESULT StgOpenPropStg( IUnknown *pUnk,
		// REFFMTID fmtid, DWORD grfFlags, DWORD dwReserved, IPropertyStorage **ppPropStg );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("coml2api.h", MSDNShortId = "ecc78e49-f1c2-4c2d-8390-b2b6f1dc776e")]
		public static extern HRESULT StgOpenPropStg([MarshalAs(UnmanagedType.IUnknown)] object pUnk, in Guid fmtid, PROPSETFLAG grfFlags, [Optional] uint dwReserved, out IPropertyStorage ppPropStg);

		/// <summary>
		/// <para>
		/// The <c>StgOpenStorage</c> function opens an existing root storage object in the file system. Use this function to open compound
		/// files. Do not use it to open directories, files, or summary catalogs. Nested storage objects can only be opened using their
		/// parent IStorage::OpenStorage method.
		/// </para>
		/// <para>
		/// <c>Note</c> Applications should use the new function, StgOpenStorageEx, instead of <c>StgOpenStorage</c>, to take advantage of
		/// the enhanced and Windows Structured Storage features. This function, <c>StgOpenStorage</c>, still exists for compatibility with
		/// applications running on Windows 2000.
		/// </para>
		/// </summary>
		/// <param name="pwcsName">
		/// A pointer to the path of the <c>null</c>-terminated Unicode string file that contains the storage object to open. This parameter
		/// is ignored if the pstgPriority parameter is not <c>NULL</c>.
		/// </param>
		/// <param name="pstgPriority">
		/// <para>
		/// A pointer to the IStorage interface that should be <c>NULL</c>. If not <c>NULL</c>, this parameter is used as described below in
		/// the Remarks section.
		/// </para>
		/// <para>
		/// After <c>StgOpenStorage</c> returns, the storage object specified in pStgPriority may have been released and should no longer be used.
		/// </para>
		/// </param>
		/// <param name="grfMode">Specifies the access mode to use to open the storage object.</param>
		/// <param name="snbExclude">
		/// If not <c>NULL</c>, pointer to a block of elements in the storage to be excluded as the storage object is opened. The exclusion
		/// occurs regardless of whether a snapshot copy happens on the open. Can be <c>NULL</c>.
		/// </param>
		/// <param name="reserved">Indicates reserved for future use; must be zero.</param>
		/// <param name="ppstgOpen">A pointer to a IStorage* pointer variable that receives the interface pointer to the opened storage.</param>
		/// <returns>
		/// The <c>StgOpenStorage</c> function can also return any file system errors or system errors wrapped in an <c>HRESULT</c>. For more
		/// information, see Error Handling Strategies and Handling Unknown Errors.
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>StgOpenStorage</c> function opens the specified root storage object according to the access mode in the grfMode parameter,
		/// and, if successful, supplies an IStorage pointer to the opened storage object in the ppstgOpen parameter.
		/// </para>
		/// <para>
		/// To support the simple mode for saving a storage object with no substorages, the <c>StgOpenStorage</c> function accepts one of the
		/// following two flag combinations as valid modes in the grfMode parameter.
		/// </para>
		/// <para>
		/// To support the single-writer, multireader, direct mode, the first flag combination is the valid grfMode parameter for the writer.
		/// The second flag combination is valid for readers.
		/// </para>
		/// <para>In direct mode, one of the following three combinations are valid.</para>
		/// <para>
		/// <c>Note</c> Opening a storage object in read/write mode without denying write permission to others (the grfMode parameter
		/// specifies STGM_SHARE_DENY_WRITE) can be a time-consuming operation because the <c>StgOpenStorage</c> call must make a snapshot of
		/// the entire storage object.
		/// </para>
		/// <para>
		/// Applications often try to open storage objects with the following access permissions. If the application succeeds, it never needs
		/// to make a snapshot copy.
		/// </para>
		/// <para>
		/// The application can revert to using the permissions and make a snapshot copy, if the previous access permissions fail. The
		/// application should prompt the user before making a time-consuming copy.
		/// </para>
		/// <para>
		/// If the document-sharing semantics implied by the access modes are appropriate, the application could try to open the storage as
		/// follows. In this case, if the application succeeds, a snapshot copy will not have been made (because <c>STGM_SHARE_DENY_WRITE</c>
		/// was specified, denying others write access).
		/// </para>
		/// <para>
		/// <c>Note</c> To reduce the expense of making a snapshot copy, applications can open storage objects in priority mode (grfMode
		/// specifies <c>STGM_PRIORITY</c>).
		/// </para>
		/// <para>
		/// The snbExclude parameter specifies a set of element names in this storage object that are to be emptied as the storage object is
		/// opened: streams are set to a length of zero; storage objects have all their elements removed. By excluding certain streams, the
		/// expense of making a snapshot copy can be significantly reduced. Almost always, this approach is used after first opening the
		/// storage object in priority mode, then completely reading the now-excluded elements into memory. This earlier priority-mode
		/// opening of the storage object should be passed through the pstgPriority parameter to remove the exclusion implied by priority
		/// mode. The calling application is responsible for rewriting the contents of excluded items before committing. Thus, this technique
		/// is most likely useful only to applications whose documents do not require constant access to their storage objects while they are active.
		/// </para>
		/// <para>
		/// The pstgPriority parameter is intended as a convenience for callers replacing an existing storage object, often one opened in
		/// priority mode, with a new storage object opened on the same file but in a different mode. When pstgPriority is not <c>NULL</c>,
		/// it is used to specify the file name instead of pwcsName, which is ignored. However, it is recommended that applications always
		/// pass <c>NULL</c> for pstgPriority because <c>StgOpenStorage</c> releases the object under some circumstances, and does not
		/// release it under other circumstances. In particular, if the function returns a failure result, it is not possible for the caller
		/// to determine whether or not the storage object was released.
		/// </para>
		/// <para>
		/// The functionality of the pstgPriority parameter can be duplicated by the caller in a safer manner as shown in the following example:
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/coml2api/nf-coml2api-stgopenstorage HRESULT StgOpenStorage( const WCHAR
		// *pwcsName, IStorage *pstgPriority, DWORD grfMode, SNB snbExclude, DWORD reserved, IStorage **ppstgOpen );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("coml2api.h", MSDNShortId = "5ff18dc8-b24f-42bb-8c32-efc4d3696687")]
		public static extern HRESULT StgOpenStorage([In, Optional, MarshalAs(UnmanagedType.LPWStr)] string pwcsName, [In, Optional] IStorage pstgPriority, STGM grfMode, SNB snbExclude, [Optional] uint reserved, out IStorage ppstgOpen);

		/// <summary>
		/// <para>
		/// The <c>StgOpenStorageEx</c> function opens an existing root storage object in the file system. Use this function to open Compound
		/// Files and regular files. To create a new file, use the StgCreateStorageEx function.
		/// </para>
		/// <para>
		/// <c>Note</c> To use enhancements, all Windows 2000, Windows XP, and Windows Server 2003 applications should call
		/// <c>StgOpenStorageEx</c>, instead of StgOpenStorage. The <c>StgOpenStorage</c> function is used for compatibility with Windows
		/// 2000 and earlier applications.
		/// </para>
		/// </summary>
		/// <param name="pwcsName">
		/// <para>
		/// A pointer to the path of the null-terminated Unicode string file that contains the storage object. This string size cannot exceed
		/// <c>MAX_PATH</c> characters.
		/// </para>
		/// <para>
		/// <c>Windows Server 2003 and Windows XP/2000:</c> Unlike the CreateFile function, the <c>MAX_PATH</c> limit cannot be exceeded by
		/// using the "\?" prefix.
		/// </para>
		/// </param>
		/// <param name="grfMode">
		/// <para>
		/// A value that specifies the access mode to open the new storage object. For more information, see STGM Constants. If the caller
		/// specifies transacted mode together with <c>STGM_CREATE</c> or <c>STGM_CONVERT</c>, the overwrite or conversion occurs when the
		/// commit operation is called for the root storage. If IStorage::Commit is not called for the root storage object, previous contents
		/// of the file will be restored. <c>STGM_CREATE</c> and <c>STGM_CONVERT</c> cannot be combined with the <c>STGM_NOSNAPSHOT</c> flag,
		/// because a snapshot copy is required when a file is overwritten or converted in transacted mode.
		/// </para>
		/// <para>
		/// If the storage object is opened in direct mode ( <c>STGM_DIRECT</c>) with access to either <c>STGM_WRITE</c> or
		/// <c>STGM_READWRITE</c>, the sharing mode must be <c>STGM_SHARE_EXCLUSIVE</c> unless the <c>STGM_DIRECT_SWMR</c> mode is specified.
		/// For more information, see the Remarks section. If the storage object is opened in direct mode with access to <c>STGM_READ</c>,
		/// the sharing mode must be either <c>STGM_SHARE_EXCLUSIVE</c> or <c>STGM_SHARE_DENY_WRITE</c>, unless <c>STGM_PRIORITY</c> or
		/// <c>STGM_DIRECT_SWMR</c> is specified. For more information, see the Remarks section.
		/// </para>
		/// <para>
		/// The mode in which a file is opened can affect implementation performance. For more information, see Compound File Implementation Limits.
		/// </para>
		/// </param>
		/// <param name="stgfmt">A value that specifies the storage file format. For more information, see the STGFMT enumeration.</param>
		/// <param name="grfAttrs">
		/// <para>A value that depends upon the value of the stgfmt parameter.</para>
		/// <para>
		/// <c>STGFMT_DOCFILE</c> must be zero (0) or <c>FILE_FLAG_NO_BUFFERING</c>. For more information about this value, see CreateFile.
		/// If the sector size of the file, specified in pStgOptions, is not an integer multiple of the physical sector size of the
		/// underlying disk, then this operation will fail. All other values of stgfmt must be zero.
		/// </para>
		/// </param>
		/// <param name="pStgOptions">
		/// A pointer to an STGOPTIONS structure that contains data about the storage object opened. The pStgOptions parameter is valid only
		/// if the stgfmt parameter is set to <c>STGFMT_DOCFILE</c>. The <c>usVersion</c> member must be set before calling
		/// <c>StgOpenStorageEx</c>. For more information, see the <c>STGOPTIONS</c> structure.
		/// </param>
		/// <param name="pSecurityDescriptor">Reserved; must be zero.</param>
		/// <param name="riid">
		/// A value that specifies the GUID of the interface pointer to return. Can also be the header-specified value for
		/// <c>IID_IStorage</c> to obtain the IStorage interface or for <c>IID_IPropertySetStorage</c> to obtain the IPropertySetStorage interface.
		/// </param>
		/// <param name="ppObjectOpen">
		/// The address of an interface pointer variable that receives a pointer for an interface on the storage object opened; contains
		/// <c>NULL</c> if operation failed.
		/// </param>
		/// <returns>
		/// This function can also return any file system errors or system errors wrapped in an <c>HRESULT</c>. For more information, see
		/// Error Handling Strategies and Handling Unknown Errors.
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>StgOpenStorageEx</c> is a superset of the StgOpenStorage function, and should be used by new code. Future enhancements to
		/// structured storage will be exposed through this function. For more information about supported platforms, see the Requirements section.
		/// </para>
		/// <para>
		/// The <c>StgOpenStorageEx</c> function opens the specified root storage object according to the access mode in the grfMode
		/// parameter, and, if successful, supplies an interface pointer for the opened storage object in the ppObjectOpen parameter. This
		/// function can be used to obtain an IStorage compound file implementation, an IPropertySetStorage compound file implementation, or
		/// an NTFS file system implementation of IPropertySetStorage.
		/// </para>
		/// <para>
		/// When you open a file, the system selects a structured storage implementation depending on which STGFMT flag you specify on the
		/// file type and on the type of drive where the file is stored.
		/// </para>
		/// <para>
		/// Use the <c>StgOpenStorageEx</c> function to access the root storage of a structured storage document or the property set storage
		/// of any file that supports property sets. For more information about which interface identifiers (IIDs) are supported for the
		/// different STGFMT values, see STGFMT.
		/// </para>
		/// <para>
		/// When a file is opened with this function to access the NTFS property set implementation, special sharing rules apply. For more
		/// information, see IPropertySetStorage-NTFS Implementation.
		/// </para>
		/// <para>
		/// If a compound file is opened in transacted mode, by specifying STGM_TRANSACTED, and read-only mode, by specifying STGM_READ, it
		/// is possible to change the returned storage object. For example, it is possible to call IStorage::CreateStream. However, it is not
		/// possible to commit those changes by calling IStorage::Commit. Therefore, such changes will be lost.
		/// </para>
		/// <para>
		/// It is not valid to use the <c>STGM_CREATE</c>, <c>STGM_DELETEONRELEASE</c>, or <c>STGM_CONVERT</c> flags in the grfMode parameter
		/// for this function.
		/// </para>
		/// <para>
		/// To support the simple mode for saving a storage object with no substorages, the <c>StgOpenStorageEx</c> function accepts one of
		/// the following two flag combinations as valid modes in the grfMode parameter:
		/// </para>
		/// <para>
		/// To support the single-writer, multireader, direct mode, the first flag combination is the valid grfMode parameter for the writer.
		/// The second flag combination is valid for readers.
		/// </para>
		/// <para>For more information about simple mode and single-writer/multiple-reader modes, see STGM Constants.</para>
		/// <para>
		/// <c>Note</c> Opening a transacted mode storage object in read and/or write mode without denying write permissions to others (for
		/// example, the grfMode parameter specifies <c>STGM_SHARE_DENY_WRITE</c>) can be time-consuming because the <c>StgOpenStorageEx</c>
		/// call must create a snapshot copy of the entire storage object.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/coml2api/nf-coml2api-stgopenstorageex HRESULT StgOpenStorageEx( const WCHAR
		// *pwcsName, DWORD grfMode, DWORD stgfmt, DWORD grfAttrs, STGOPTIONS *pStgOptions, PSECURITY_DESCRIPTOR pSecurityDescriptor, REFIID
		// riid, void **ppObjectOpen );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("coml2api.h", MSDNShortId = "4f2138fb-1f80-4345-a3cb-9c11023457b1")]
		public static extern HRESULT StgOpenStorageEx([In, Optional, MarshalAs(UnmanagedType.LPWStr)] string pwcsName, STGM grfMode, STGFMT stgfmt, FileFlagsAndAttributes grfAttrs, in STGOPTIONS pStgOptions,
			[Optional] PSECURITY_DESCRIPTOR pSecurityDescriptor, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 6)] out object ppObjectOpen);

		/// <summary>
		/// <para>
		/// The <c>StgOpenStorageEx</c> function opens an existing root storage object in the file system. Use this function to open Compound
		/// Files and regular files. To create a new file, use the StgCreateStorageEx function.
		/// </para>
		/// <para>
		/// <c>Note</c> To use enhancements, all Windows 2000, Windows XP, and Windows Server 2003 applications should call
		/// <c>StgOpenStorageEx</c>, instead of StgOpenStorage. The <c>StgOpenStorage</c> function is used for compatibility with Windows
		/// 2000 and earlier applications.
		/// </para>
		/// </summary>
		/// <param name="pwcsName">
		/// <para>
		/// A pointer to the path of the null-terminated Unicode string file that contains the storage object. This string size cannot exceed
		/// <c>MAX_PATH</c> characters.
		/// </para>
		/// <para>
		/// <c>Windows Server 2003 and Windows XP/2000:</c> Unlike the CreateFile function, the <c>MAX_PATH</c> limit cannot be exceeded by
		/// using the "\?" prefix.
		/// </para>
		/// </param>
		/// <param name="grfMode">
		/// <para>
		/// A value that specifies the access mode to open the new storage object. For more information, see STGM Constants. If the caller
		/// specifies transacted mode together with <c>STGM_CREATE</c> or <c>STGM_CONVERT</c>, the overwrite or conversion occurs when the
		/// commit operation is called for the root storage. If IStorage::Commit is not called for the root storage object, previous contents
		/// of the file will be restored. <c>STGM_CREATE</c> and <c>STGM_CONVERT</c> cannot be combined with the <c>STGM_NOSNAPSHOT</c> flag,
		/// because a snapshot copy is required when a file is overwritten or converted in transacted mode.
		/// </para>
		/// <para>
		/// If the storage object is opened in direct mode ( <c>STGM_DIRECT</c>) with access to either <c>STGM_WRITE</c> or
		/// <c>STGM_READWRITE</c>, the sharing mode must be <c>STGM_SHARE_EXCLUSIVE</c> unless the <c>STGM_DIRECT_SWMR</c> mode is specified.
		/// For more information, see the Remarks section. If the storage object is opened in direct mode with access to <c>STGM_READ</c>,
		/// the sharing mode must be either <c>STGM_SHARE_EXCLUSIVE</c> or <c>STGM_SHARE_DENY_WRITE</c>, unless <c>STGM_PRIORITY</c> or
		/// <c>STGM_DIRECT_SWMR</c> is specified. For more information, see the Remarks section.
		/// </para>
		/// <para>
		/// The mode in which a file is opened can affect implementation performance. For more information, see Compound File Implementation Limits.
		/// </para>
		/// </param>
		/// <param name="stgfmt">A value that specifies the storage file format. For more information, see the STGFMT enumeration.</param>
		/// <param name="grfAttrs">
		/// <para>A value that depends upon the value of the stgfmt parameter.</para>
		/// <para>
		/// <c>STGFMT_DOCFILE</c> must be zero (0) or <c>FILE_FLAG_NO_BUFFERING</c>. For more information about this value, see CreateFile.
		/// If the sector size of the file, specified in pStgOptions, is not an integer multiple of the physical sector size of the
		/// underlying disk, then this operation will fail. All other values of stgfmt must be zero.
		/// </para>
		/// </param>
		/// <param name="pStgOptions">
		/// A pointer to an STGOPTIONS structure that contains data about the storage object opened. The pStgOptions parameter is valid only
		/// if the stgfmt parameter is set to <c>STGFMT_DOCFILE</c>. The <c>usVersion</c> member must be set before calling
		/// <c>StgOpenStorageEx</c>. For more information, see the <c>STGOPTIONS</c> structure.
		/// </param>
		/// <param name="pSecurityDescriptor">Reserved; must be zero.</param>
		/// <param name="riid">
		/// A value that specifies the GUID of the interface pointer to return. Can also be the header-specified value for
		/// <c>IID_IStorage</c> to obtain the IStorage interface or for <c>IID_IPropertySetStorage</c> to obtain the IPropertySetStorage interface.
		/// </param>
		/// <param name="ppObjectOpen">
		/// The address of an interface pointer variable that receives a pointer for an interface on the storage object opened; contains
		/// <c>NULL</c> if operation failed.
		/// </param>
		/// <returns>
		/// This function can also return any file system errors or system errors wrapped in an <c>HRESULT</c>. For more information, see
		/// Error Handling Strategies and Handling Unknown Errors.
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>StgOpenStorageEx</c> is a superset of the StgOpenStorage function, and should be used by new code. Future enhancements to
		/// structured storage will be exposed through this function. For more information about supported platforms, see the Requirements section.
		/// </para>
		/// <para>
		/// The <c>StgOpenStorageEx</c> function opens the specified root storage object according to the access mode in the grfMode
		/// parameter, and, if successful, supplies an interface pointer for the opened storage object in the ppObjectOpen parameter. This
		/// function can be used to obtain an IStorage compound file implementation, an IPropertySetStorage compound file implementation, or
		/// an NTFS file system implementation of IPropertySetStorage.
		/// </para>
		/// <para>
		/// When you open a file, the system selects a structured storage implementation depending on which STGFMT flag you specify on the
		/// file type and on the type of drive where the file is stored.
		/// </para>
		/// <para>
		/// Use the <c>StgOpenStorageEx</c> function to access the root storage of a structured storage document or the property set storage
		/// of any file that supports property sets. For more information about which interface identifiers (IIDs) are supported for the
		/// different STGFMT values, see STGFMT.
		/// </para>
		/// <para>
		/// When a file is opened with this function to access the NTFS property set implementation, special sharing rules apply. For more
		/// information, see IPropertySetStorage-NTFS Implementation.
		/// </para>
		/// <para>
		/// If a compound file is opened in transacted mode, by specifying STGM_TRANSACTED, and read-only mode, by specifying STGM_READ, it
		/// is possible to change the returned storage object. For example, it is possible to call IStorage::CreateStream. However, it is not
		/// possible to commit those changes by calling IStorage::Commit. Therefore, such changes will be lost.
		/// </para>
		/// <para>
		/// It is not valid to use the <c>STGM_CREATE</c>, <c>STGM_DELETEONRELEASE</c>, or <c>STGM_CONVERT</c> flags in the grfMode parameter
		/// for this function.
		/// </para>
		/// <para>
		/// To support the simple mode for saving a storage object with no substorages, the <c>StgOpenStorageEx</c> function accepts one of
		/// the following two flag combinations as valid modes in the grfMode parameter:
		/// </para>
		/// <para>
		/// To support the single-writer, multireader, direct mode, the first flag combination is the valid grfMode parameter for the writer.
		/// The second flag combination is valid for readers.
		/// </para>
		/// <para>For more information about simple mode and single-writer/multiple-reader modes, see STGM Constants.</para>
		/// <para>
		/// <c>Note</c> Opening a transacted mode storage object in read and/or write mode without denying write permissions to others (for
		/// example, the grfMode parameter specifies <c>STGM_SHARE_DENY_WRITE</c>) can be time-consuming because the <c>StgOpenStorageEx</c>
		/// call must create a snapshot copy of the entire storage object.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/coml2api/nf-coml2api-stgopenstorageex HRESULT StgOpenStorageEx( const WCHAR
		// *pwcsName, DWORD grfMode, DWORD stgfmt, DWORD grfAttrs, STGOPTIONS *pStgOptions, PSECURITY_DESCRIPTOR pSecurityDescriptor, REFIID
		// riid, void **ppObjectOpen );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("coml2api.h", MSDNShortId = "4f2138fb-1f80-4345-a3cb-9c11023457b1")]
		public static extern HRESULT StgOpenStorageEx([In, Optional, MarshalAs(UnmanagedType.LPWStr)] string pwcsName, STGM grfMode, STGFMT stgfmt, FileFlagsAndAttributes grfAttrs, [Optional] IntPtr pStgOptions,
			[Optional] PSECURITY_DESCRIPTOR pSecurityDescriptor, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 6)] out object ppObjectOpen);

		/// <summary>
		/// The <c>StgOpenStorageOnILockBytes</c> function opens an existing storage object that does not reside in a disk file, but instead
		/// has an underlying byte array provided by the caller.
		/// </summary>
		/// <param name="plkbyt">ILockBytes pointer to the underlying byte array object that contains the storage object to be opened.</param>
		/// <param name="pstgPriority">
		/// <para>
		/// A pointer to the IStorage interface that should be <c>NULL</c>. If not <c>NULL</c>, this parameter is used as described below in
		/// the Remarks section.
		/// </para>
		/// <para>
		/// After <c>StgOpenStorageOnILockBytes</c> returns, the storage object specified in pStgPriority may have been released and should
		/// no longer be used.
		/// </para>
		/// </param>
		/// <param name="grfMode">
		/// Specifies the access mode to use to open the storage object. For more information, see STGM Constants and the Remarks section below.
		/// </param>
		/// <param name="snbExclude">
		/// Can be <c>NULL</c>. If not <c>NULL</c>, this parameter points to a block of elements in this storage that are to be excluded as
		/// the storage object is opened. This exclusion occurs independently of whether a snapshot copy happens on the open.
		/// </param>
		/// <param name="reserved">Indicates reserved for future use; must be zero.</param>
		/// <param name="ppstgOpen">Points to the location of an IStorage pointer to the opened storage on successful return.</param>
		/// <returns>
		/// The <c>StgOpenStorageOnILockBytes</c> function can also return any file system errors, or system errors wrapped in an
		/// <c>HRESULT</c>, or ILockBytes interface error return values. See Error Handling Strategies and Handling Unknown Errors.
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>StgOpenStorageOnILockBytes</c> opens the specified root storage object. A pointer to the IStorage interface on the opened
		/// storage object is supplied through the ppstgOpen parameter.
		/// </para>
		/// <para>The storage object must have been previously created by the StgCreateDocfileOnILockBytes function.</para>
		/// <para>
		/// Except for specifying a programmer-provided byte-array object, <c>StgOpenStorageOnILockBytes</c> is similar to the StgOpenStorage
		/// function. The storage object is opened according to the access modes in the grfMode parameter, subject to the following restrictions:
		/// </para>
		/// <para>
		/// Sharing mode behavior and transactional isolation depend on the ILockBytes implementation supporting LockRegion and UnlockRegion
		/// with LOCK_ONLYONCE semantics. Implementations can indicate to structured storage they support this functionality by setting the
		/// <c>LOCK_ONLYONCE</c> bit in the <c>grfLocksSupported</c> member of STATSTG. If an <c>ILockBytes</c> implementation does not
		/// support this functionality, sharing modes will not be enforced, and root-level transactional commits will not coordinate properly
		/// with other transactional instances opened on the same byte array. Applications that use an <c>ILockBytes</c> implementation that
		/// does not support region locking, such as the CreateStreamOnHGlobal implementation, should avoid opening multiple concurrent
		/// instances on the same byte array.
		/// </para>
		/// <para><c>StgOpenStorageOnILockBytes</c> does not support simple mode. The STGM_SIMPLE flag, if present, is ignored.</para>
		/// <para>
		/// The pStgPriority parameter is intended as a convenience for callers replacing an existing storage object, often one opened in
		/// priority mode, with a new storage object opened on the same byte array. Unlike the pStgPriority parameter of StgOpenStorage, this
		/// parameter does not affect the open operation performed by <c>StgOpenStorageOnILockBytes</c> and is simply an existing storage
		/// object the caller would like released. Callers should always pass <c>NULL</c> for this parameter because
		/// <c>StgOpenStorageOnILockBytes</c> releases the object under some circumstances, and does not release it under other
		/// circumstances. The use of the pStgPriority parameter can be duplicated by the caller in a safer manner by instead releasing the
		/// object before calling <c>StgOpenStorageOnILockBytes</c>, as shown in the following example:
		/// </para>
		/// <para>For more information, refer to StgOpenStorage.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/coml2api/nf-coml2api-stgopenstorageonilockbytes HRESULT
		// StgOpenStorageOnILockBytes( ILockBytes *plkbyt, IStorage *pstgPriority, DWORD grfMode, SNB snbExclude, DWORD reserved, IStorage
		// **ppstgOpen );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("coml2api.h", MSDNShortId = "7920bd46-0a8f-42e0-9988-59d85edb64e2")]
		public static extern HRESULT StgOpenStorageOnILockBytes([In] ILockBytes plkbyt, [In, Optional] IStorage pstgPriority, STGM grfMode, SNB snbExclude, [Optional] uint reserved, out IStorage ppstgOpen);

		/// <summary>
		/// The <c>StgSetTimes</c> function sets the creation, access, and modification times of the indicated file, if supported by the
		/// underlying file system.
		/// </summary>
		/// <param name="lpszName">Pointer to the name of the file to be changed.</param>
		/// <param name="pctime">Pointer to the new value for the creation time.</param>
		/// <param name="patime">Pointer to the new value for the access time.</param>
		/// <param name="pmtime">Pointer to the new value for the modification time.</param>
		/// <returns>
		/// The <c>StgSetTimes</c> function can also return any file system errors or system errors wrapped in an <c>HRESULT</c>. See Error
		/// Handling Strategies and Handling Unknown Errors.
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>StgSetTimes</c> function sets the time values for the specified file. Each of the time value parameters can be
		/// <c>NULL</c>, indicating that no modification should occur.
		/// </para>
		/// <para>
		/// It is possible that one or more of these time values are not supported by the underlying file system. This function sets the
		/// times that can be set and ignores the rest.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/coml2api/nf-coml2api-stgsettimes HRESULT StgSetTimes( const WCHAR *lpszName,
		// const FILETIME *pctime, const FILETIME *patime, const FILETIME *pmtime );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("coml2api.h", MSDNShortId = "5ade3e7a-a22a-458f-b463-1680893edc15")]
		public static extern HRESULT StgSetTimes([In, MarshalAs(UnmanagedType.LPWStr)] string lpszName, in FILETIME pctime, in FILETIME patime, in FILETIME pmtime);

		/// <summary>
		/// The <c>StgSetTimes</c> function sets the creation, access, and modification times of the indicated file, if supported by the
		/// underlying file system.
		/// </summary>
		/// <param name="lpszName">Pointer to the name of the file to be changed.</param>
		/// <param name="pctime">Pointer to the new value for the creation time.</param>
		/// <param name="patime">Pointer to the new value for the access time.</param>
		/// <param name="pmtime">Pointer to the new value for the modification time.</param>
		/// <returns>
		/// The <c>StgSetTimes</c> function can also return any file system errors or system errors wrapped in an <c>HRESULT</c>. See Error
		/// Handling Strategies and Handling Unknown Errors.
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>StgSetTimes</c> function sets the time values for the specified file. Each of the time value parameters can be
		/// <c>NULL</c>, indicating that no modification should occur.
		/// </para>
		/// <para>
		/// It is possible that one or more of these time values are not supported by the underlying file system. This function sets the
		/// times that can be set and ignores the rest.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/coml2api/nf-coml2api-stgsettimes HRESULT StgSetTimes( const WCHAR *lpszName,
		// const FILETIME *pctime, const FILETIME *patime, const FILETIME *pmtime );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("coml2api.h", MSDNShortId = "5ade3e7a-a22a-458f-b463-1680893edc15")]
		public static extern HRESULT StgSetTimes([In, MarshalAs(UnmanagedType.LPWStr)] string lpszName, [Optional] IntPtr pctime, [Optional] IntPtr patime, [Optional] IntPtr pmtime);

		/// <summary>The <c>WriteClassStg</c> function stores the specified class identifier (CLSID) in a storage object.</summary>
		/// <param name="pStg">IStorage pointer to the storage object that gets a new CLSID.</param>
		/// <param name="rclsid">Pointer to the CLSID to be stored with the object.</param>
		/// <returns>This function returns HRESULT.</returns>
		/// <remarks>
		/// The <c>WriteClassStg</c> function writes a CLSID to the specified storage object so that it can be read by the ReadClassStg
		/// function. Container applications typically call this function before calling the IPersistStorage::Save method.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/coml2api/nf-coml2api-writeclassstg HRESULT WriteClassStg( LPSTORAGE pStg,
		// REFCLSID rclsid );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("coml2api.h", MSDNShortId = "5f2f16d1-923f-4ba7-8d4b-7e8535f6f15e")]
		public static extern HRESULT WriteClassStg(IStorage pStg, in Guid rclsid);

		/// <summary>The <c>WriteClassStm</c> function stores the specified CLSID in the stream.</summary>
		/// <param name="pStm">IStream pointer to the stream into which the CLSID is to be written.</param>
		/// <param name="rclsid">Specifies the CLSID to write to the stream.</param>
		/// <returns>This function returns HRESULT.</returns>
		/// <remarks>
		/// The <c>WriteClassStm</c> function writes a CLSID to the specified stream object so it can be read by the ReadClassStm function.
		/// Most applications do not call <c>WriteClassStm</c> directly. OLE calls it before making a call to an object's
		/// IPersistStream::Save method.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/coml2api/nf-coml2api-writeclassstm HRESULT WriteClassStm( LPSTREAM pStm,
		// REFCLSID rclsid );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("coml2api.h", MSDNShortId = "c08bfbc8-f7ac-4534-8c98-c732c6daa2f7")]
		public static extern HRESULT WriteClassStm(IStream pStm, in Guid rclsid);
	}
}