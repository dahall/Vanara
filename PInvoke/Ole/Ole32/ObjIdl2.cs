using System.Runtime.InteropServices.ComTypes;
using STATSTG = System.Runtime.InteropServices.ComTypes.STATSTG;

namespace Vanara.PInvoke;

public static partial class Ole32
{
	/// <summary>
	/// The <c>ILockBytes</c> interface is implemented on a byte array object that is backed by some physical storage, such as a disk
	/// file, global memory, or a database. It is used by a COM compound file storage object to give its root storage access to the
	/// physical device, while isolating the root storage from the details of accessing the physical storage.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nn-objidl-ilockbytes
	[PInvokeData("objidl.h", MSDNShortId = "bb2c5d0d-8dc8-4844-9a20-ef8e4def5731")]
	[ComImport, Guid("0000000a-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ILockBytes
	{
		/// <summary>
		/// The <c>ReadAt</c> method reads a specified number of bytes starting at a specified offset from the beginning of the byte
		/// array object.
		/// </summary>
		/// <param name="ulOffset">Specifies the starting point from the beginning of the byte array for reading data.</param>
		/// <param name="pv">Pointer to the buffer into which the byte array is read. The size of this buffer is contained in cb.</param>
		/// <param name="cb">Specifies the number of bytes of data to attempt to read from the byte array.</param>
		/// <param name="pcbRead">
		/// Pointer to a <c>ULONG</c> where this method writes the actual number of bytes read from the byte array. You can set this
		/// pointer to <c>NULL</c> to indicate that you are not interested in this value. In this case, this method does not provide the
		/// actual number of bytes that were read.
		/// </param>
		/// <remarks>
		/// <para>
		/// <c>ILockBytes::ReadAt</c> reads bytes from the byte array object. It reports the number of bytes that were actually read.
		/// This value may be less than the number of bytes requested if an error occurs or if the end of the byte array is reached
		/// during the read.
		/// </para>
		/// <para>
		/// It is not an error to read less than the specified number of bytes if the operation encounters the end of the byte array.
		/// Note that this is the same end-of-file behavior as found in MS-DOS file allocation table (FAT) file system files.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ilockbytes-readat HRESULT ReadAt( ULARGE_INTEGER
		// ulOffset, void *pv, ULONG cb, ULONG *pcbRead );
		[PInvokeData("objidl.h", MSDNShortId = "0478d6f0-65c4-445b-946a-692f2373e8f1")]
		void ReadAt(ulong ulOffset, [Out] IntPtr pv, uint cb, out uint pcbRead);

		/// <summary>
		/// The <c>WriteAt</c> method writes the specified number of bytes starting at a specified offset from the beginning of the byte array.
		/// </summary>
		/// <param name="ulOffset">Specifies the starting point from the beginning of the byte array for the data to be written.</param>
		/// <param name="pv">Pointer to the buffer containing the data to be written.</param>
		/// <param name="cb">Specifies the number of bytes of data to attempt to write into the byte array.</param>
		/// <param name="pcbWritten">
		/// Pointer to a location where this method specifies the actual number of bytes written to the byte array. You can set this
		/// pointer to <c>NULL</c> to indicate that you are not interested in this value. In this case, this method does not provide the
		/// actual number of bytes written.
		/// </param>
		/// <remarks>
		/// <para>
		/// <c>ILockBytes::WriteAt</c> writes the specified data at the specified location in the byte array. The number of bytes
		/// actually written must always be returned in pcbWritten, even if an error is returned. If the byte count is zero bytes, the
		/// write operation has no effect.
		/// </para>
		/// <para>
		/// If ulOffset is past the end of the byte array and cb is greater than zero, <c>ILockBytes::WriteAt</c> increases the size of
		/// the byte array. The fill bytes written to the byte array are not initialized to any particular value.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ilockbytes-writeat HRESULT WriteAt( ULARGE_INTEGER
		// ulOffset, const void *pv, ULONG cb, ULONG *pcbWritten );
		[PInvokeData("objidl.h", MSDNShortId = "a27af4e1-293d-438a-8068-87275a51fd48")]
		void WriteAt(ulong ulOffset, [In] IntPtr pv, uint cb, out uint pcbWritten);

		/// <summary>
		/// The <c>Flush</c> method ensures that any internal buffers maintained by the ILockBytes implementation are written out to the
		/// underlying physical storage.
		/// </summary>
		/// <remarks>
		/// <para><c>ILockBytes::Flush</c> flushes internal buffers to the underlying storage device.</para>
		/// <para>
		/// The COM-provided implementation of compound files calls this method during a transacted commit operation to provide a
		/// two-phase commit process that protects against loss of data.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ilockbytes-flush HRESULT Flush( );
		[PInvokeData("objidl.h", MSDNShortId = "9396c44f-ad76-49f4-9796-d29570466a27")]
		void Flush();

		/// <summary>The <c>SetSize</c> method changes the size of the byte array.</summary>
		/// <param name="cb">Specifies the new size of the byte array as a number of bytes.</param>
		/// <remarks>
		/// <para>
		/// <c>ILockBytes::SetSize</c> changes the size of the byte array. If the cb parameter is larger than the current byte array, the
		/// byte array is extended to the indicated size by filling the intervening space with bytes of undefined value, as does
		/// ILockBytes::WriteAt, if the seek pointer is past the current end-of-stream.
		/// </para>
		/// <para>If the cb parameter is smaller than the current byte array, the byte array is truncated to the indicated size.</para>
		/// <para>Notes to Callers</para>
		/// <para>
		/// Callers cannot rely on STG_E_MEDIUMFULL being returned at the appropriate time because of cache buffering in the operating
		/// system or network. However, callers must be able to deal with this return code because some ILockBytes implementations might
		/// support it.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ilockbytes-setsize HRESULT SetSize( ULARGE_INTEGER cb );
		[PInvokeData("objidl.h", MSDNShortId = "13b3237b-d113-4505-b397-b06916368fef")]
		void SetSize(ulong cb);

		/// <summary>The <c>LockRegion</c> method restricts access to a specified range of bytes in the byte array.</summary>
		/// <param name="libOffset">Specifies the byte offset for the beginning of the range.</param>
		/// <param name="cb">Specifies, in bytes, the length of the range to be restricted.</param>
		/// <param name="dwLockType">
		/// Specifies the type of restrictions being requested on accessing the range. This parameter uses one of the values from the
		/// LOCKTYPE enumeration.
		/// </param>
		/// <remarks>
		/// <para>
		/// <c>ILockBytes::LockRegion</c> restricts access to the specified range of bytes. Once a region is locked, attempts by others
		/// to gain access to the restricted range must fail with the STG_E_ACCESSDENIED error.
		/// </para>
		/// <para>
		/// The byte range can extend past the current end of the byte array. Locking beyond the end of an array is useful as a method of
		/// communication between different instances of the byte array object without changing data that is actually part of the byte
		/// array. For example, an implementation of ILockBytes for compound files could rely on locking past the current end of the
		/// array as a means of access control, using specific locked regions to indicate permissions currently granted.
		/// </para>
		/// <para>
		/// The dwLockType parameter specifies one of three types of locking, using values from the LOCKTYPE enumeration. The types are
		/// as follows: locking to exclude other writers, locking to exclude other readers or writers, and locking that allows only one
		/// requester to obtain a lock on the given range. This third type of locking is usually an alias for one of the other two lock
		/// types, and permits an Implementer to add other behavior as well. A given byte array might support either of the first two
		/// types, or both.
		/// </para>
		/// <para>
		/// To determine the lock types supported by a particular ILockBytes implementation, you can examine the <c>grfLocksSupported</c>
		/// member of the STATSTG structure returned by a call to ILockBytes::Stat.
		/// </para>
		/// <para>
		/// Any region locked with <c>ILockBytes::LockRegion</c> must later be explicitly unlocked by calling ILockBytes::UnlockRegion
		/// with exactly the same values for the libOffset, cb, and dwLockType parameters. The region must be unlocked before the stream
		/// is released. Two adjacent regions cannot be locked separately and then unlocked with a single unlock call.
		/// </para>
		/// <para>Notes to Callers</para>
		/// <para>
		/// Since the type of locking supported is optional and can vary in different implementations of ILockBytes, you must provide
		/// code to deal with the STG_E_INVALIDFUNCTION error.
		/// </para>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// Support for this method depends on how the storage object built on top of the ILockBytes implementation is used. If you know
		/// that only one storage object at any given time can be opened on the storage device that underlies the byte array, then your
		/// <c>ILockBytes</c> implementation does not need to support locking. However, if multiple simultaneous openings of a storage
		/// object are possible, then region locking is needed to coordinate them.
		/// </para>
		/// <para>
		/// A <c>LockRegion</c> implementation can choose to support all, some, or none of the lock types. For unsupported lock types,
		/// the implementation should return STG_E_INVALIDFUNCTION.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ilockbytes-lockregion HRESULT LockRegion( ULARGE_INTEGER
		// libOffset, ULARGE_INTEGER cb, DWORD dwLockType );
		[PInvokeData("objidl.h", MSDNShortId = "cea59e2a-99d8-472d-8e4f-2e2474789c20")]
		void LockRegion(ulong libOffset, ulong cb, LOCKTYPE dwLockType);

		/// <summary>The <c>UnlockRegion</c> method removes the access restriction on a previously locked range of bytes.</summary>
		/// <param name="libOffset">Specifies the byte offset for the beginning of the range.</param>
		/// <param name="cb">Specifies, in bytes, the length of the range that is restricted.</param>
		/// <param name="dwLockType">
		/// Specifies the type of access restrictions previously placed on the range. This parameter uses a value from the LOCKTYPE enumeration.
		/// </param>
		/// <remarks>
		/// <c>ILockBytes::UnlockRegion</c> unlocks a region previously locked with a call to ILockBytes::LockRegion. Each region locked
		/// must be explicitly unlocked, using the same values for the libOffset, cb, and dwLockType parameters as in the matching calls
		/// to <c>ILockBytes::LockRegion</c>. Two adjacent regions cannot be locked separately and then unlocked with a single unlock call.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ilockbytes-unlockregion HRESULT UnlockRegion(
		// ULARGE_INTEGER libOffset, ULARGE_INTEGER cb, DWORD dwLockType );
		[PInvokeData("objidl.h", MSDNShortId = "036ba242-8630-4013-860d-dd37919253be")]
		void UnlockRegion(ulong libOffset, ulong cb, LOCKTYPE dwLockType);

		/// <summary>The <c>Stat</c> method retrieves a STATSTG structure containing information for this byte array object.</summary>
		/// <param name="pstatstg">
		/// Pointer to a STATSTG structure in which this method places information about this byte array object. The pointer is
		/// <c>NULL</c> if an error occurs.
		/// </param>
		/// <param name="grfStatFlag">
		/// Specifies whether this method should supply the <c>pwcsName</c> member of the STATSTG structure through values taken from the
		/// STATFLAG enumeration. If the STATFLAG_NONAME is specified, the <c>pwcsName</c> member of <c>STATSTG</c> is not supplied, thus
		/// saving a memory-allocation operation. The other possible value, STATFLAG_DEFAULT, indicates that all members of the
		/// <c>STATSTG</c> structure be supplied.
		/// </param>
		/// <remarks><c>ILockBytes::Stat</c> should supply information about the byte array object in a STATSTG structure.</remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ilockbytes-stat HRESULT Stat( STATSTG *pstatstg, DWORD
		// grfStatFlag );
		[PInvokeData("objidl.h", MSDNShortId = "e7953f21-ac34-44e3-9b6f-b93ac89e2e32")]
		void Stat(out STATSTG pstatstg, STATFLAG grfStatFlag);
	}

	/// <summary>
	/// Enables application developers to monitor (spy on) memory allocation, detect memory leaks, and simulate memory failure in calls
	/// to IMalloc methods.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nn-objidl-imallocspy
	[PInvokeData("objidl.h", MSDNShortId = "8ba500f7-c070-4788-b7fe-58b6a4e6a94c")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("0000001d-0000-0000-C000-000000000046")]
	public interface IMallocSpy
	{
		/// <summary>Performs operations required before calling IMalloc::Alloc.</summary>
		/// <param name="cbRequest">The number of bytes specified in the allocation request the caller is passing to Alloc.</param>
		/// <returns>The number of bytes specified in the call to Alloc, which can be greater than or equal to the value of cbRequest.</returns>
		/// <remarks>
		/// <para>
		/// The <c>PreAlloc</c> implementation may extend and/or modify the allocation to store debug-specific information with the allocation.
		/// </para>
		/// <para>
		/// <c>PreAlloc</c> can force memory allocation failure by returning 0, allowing testing to ensure that the application handles
		/// allocation failure gracefully in all cases. In this case, IMallocSpy::PostAlloc is not called and Alloc returns <c>NULL</c>.
		/// Forcing allocation failure is effective only if cbRequest is not equal to 0. If <c>PreAlloc</c> is forcing failure by
		/// returning <c>NULL</c>, <c>PostAlloc</c> is not called. However, <c>Alloc</c> encounters a real memory failure and returns
		/// <c>NULL</c>, <c>PostAlloc</c> is called.
		/// </para>
		/// <para>The call to <c>PreAlloc</c> through the return from PostAlloc is guaranteed to be thread-safe.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-imallocspy-prealloc SizeT PreAlloc( SizeT cbRequest );
		[PreserveSig]
		SizeT PreAlloc(SizeT cbRequest);

		/// <summary>Performs operations required after calling IMalloc::Alloc.</summary>
		/// <param name="pActual">The pointer returned from Alloc.</param>
		/// <returns>
		/// This method returns a pointer to the beginning of the block of memory actually allocated. This pointer is also returned to
		/// the caller of Alloc. If debug information is written at the front of the caller's allocation, this should be a forward offset
		/// from pActual. The value is the same as pActual if debug information is appended or if no debug information is attached.
		/// </returns>
		/// <remarks>
		/// When a spy object implementing IMallocSpy is registered using the CoRegisterMallocSpy function, COM calls <c>PostAlloc</c>
		/// after any call to Alloc. It takes as input a pointer to the allocation done by the call to <c>Alloc</c>, and returns a
		/// pointer to the beginning of the total allocation, which could include a forward offset from the other value if
		/// IMallocSpy::PreAlloc was implemented to attach debug information to the allocation in this way. If not, the same pointer is
		/// returned and also becomes the return value to the caller of <c>Alloc</c>.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-imallocspy-postalloc void * PostAlloc( void *pActual );
		[PreserveSig]
		IntPtr PostAlloc(IntPtr pActual);

		/// <summary>
		/// Performs operations required before calling IMalloc::Free. This method ensures that the pointer passed to <c>Free</c> points
		/// to the beginning of the actual allocation.
		/// </summary>
		/// <param name="pRequest">A pointer to the block of memory that the caller is passing to Free.</param>
		/// <param name="fSpyed">Indicates whether the block of memory to be freed was allocated while the current spy was active.</param>
		/// <returns>The value to be passed to IMalloc::Free.</returns>
		/// <remarks>
		/// If IMallocSpy::PreAlloc modified the original allocation request passed to IMalloc::Alloc (or IMalloc::Realloc),
		/// <c>PreFree</c> must supply a pointer to the actual allocation, which COM will pass to IMalloc::Free. For example, if the
		/// <c>PreAlloc</c>/PostAlloc pair attached a header used to store debug information to the beginning of the caller's allocation,
		/// <c>PreFree</c> must return a pointer to the beginning of this header so that all of the block that was allocated can be freed.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-imallocspy-prefree void * PreFree( void *pRequest, BOOL
		// fSpyed );
		IntPtr PreFree(IntPtr pRequest, [MarshalAs(UnmanagedType.Bool)] bool fSpyed);

		/// <summary>Performs operations required after calling IMalloc::Free.</summary>
		/// <param name="fSpyed">Indicates whether the block of memory to be freed was allocated while the current spy was active.</param>
		/// <returns>This method does not return a value.</returns>
		/// <remarks>
		/// When a spy object implementing IMallocSpy is registered using CoRegisterMallocSpy function, COM calls this method immediately
		/// after any call to IMalloc::Free. This method is included for completeness and consistencyâ€”it is not anticipated that
		/// developers will implement significant functionality in this method.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-imallocspy-postfree void PostFree( BOOL fSpyed );
		[PreserveSig]
		void PostFree([MarshalAs(UnmanagedType.Bool)] bool fSpyed);

		/// <summary>Performs operations required before calling IMalloc::Realloc.</summary>
		/// <param name="pRequest">The pointer to the block of memory specified in the call to IMalloc::Realloc.</param>
		/// <param name="cbRequest">The byte count of the block of memory as specified in the original call to IMalloc::Realloc.</param>
		/// <param name="ppNewRequest">
		/// Address of pointer variable that receives a pointer to the memory block to be reallocated. This may be different from the
		/// pointer in pRequest if the implementation of <c>PreRealloc</c> extends or modifies the reallocation. This is pointer should
		/// always be stored by <c>PreRealloc</c>.
		/// </param>
		/// <param name="fSpyed">Indicates whether the block of memory was allocated while this spy was active.</param>
		/// <returns>The byte count to be passed to IMalloc::Realloc.</returns>
		/// <remarks>
		/// <para>
		/// The <c>PreRealloc</c> implementation may extend and/or modify the allocation to store debug-specific information with the
		/// allocation. Thus, the ppNewRequest parameter may differ from pRequest, a pointer to the request specified in the original
		/// call to Realloc.
		/// </para>
		/// <para>
		/// <c>PreRealloc</c> can force memory allocation failure by returning 0, allowing testing to ensure that the application handles
		/// allocation failure gracefully in all cases. In this case, PostRealloc is not called and Realloc returns <c>NULL</c>. However,
		/// if <c>Realloc</c> encounters a real memory failure and returns <c>NULL</c>, <c>PostRealloc</c> is called. Forcing allocation
		/// failure is effective only if cbRequest is not equal to 0.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-imallocspy-prerealloc SizeT PreRealloc( void *pRequest,
		// SizeT cbRequest, void **ppNewRequest, BOOL fSpyed );
		[PreserveSig]
		SizeT PreRealloc(IntPtr pRequest, SizeT cbRequest, out IntPtr ppNewRequest, [MarshalAs(UnmanagedType.Bool)] bool fSpyed);

		/// <summary>Performs operations required after calling IMalloc::Realloc.</summary>
		/// <param name="pActual">The pointer specified in the call to Realloc.</param>
		/// <param name="fSpyed">Indicates whether the block of memory was allocated while the current spy was active.</param>
		/// <returns>
		/// The method returns a pointer to the beginning of the block actually allocated. This pointer is also returned to the caller of
		/// IMalloc::Realloc. If debug information is written at the front of the caller's allocation, it should be a forward offset from
		/// pActual. The value should be the same as pActual if debug information is appended or if no debug information is attached.
		/// </returns>
		/// <remarks>
		/// If memory is successfully reallocated while the spy is active, fSpyed will be <c>TRUE</c> in subsequent calls to IMallocSpy
		/// methods that track the reallocated memory, even if fSpyed was previously <c>FALSE</c>.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-imallocspy-postrealloc void * PostRealloc( void *pActual,
		// BOOL fSpyed );
		[PreserveSig]
		IntPtr PostRealloc(IntPtr pActual, [MarshalAs(UnmanagedType.Bool)] bool fSpyed);

		/// <summary>Performs operations required before calling IMalloc::GetSize.</summary>
		/// <param name="pRequest">The pointer that the caller is passing to GetSize.</param>
		/// <param name="fSpyed">Indicates whether the block of memory was allocated while the current spy was active.</param>
		/// <returns>A pointer to the actual allocation for which the size is to be determined.</returns>
		/// <remarks>
		/// <para>
		/// The <c>PreGetSize</c> method receives as its pRequest parameter the pointer the caller is passing to IMalloc::GetSize. It
		/// must then return a pointer to the actual allocation, which may have altered pRequest in the implementation of either the
		/// PreAlloc or the PreRealloc method of IMallocSpy. The pointer to the true allocation is then passed to <c>GetSize</c> as its
		/// pv parameter.
		/// </para>
		/// <para>IMalloc::GetSize then returns the size determined, and COM passes this value to IMallocSpy::PostGetSize in cbActual.</para>
		/// <para>
		/// The size determined by GetSize is the value returned by the HeapSize function. This is the size originally requested. For
		/// example, a memory allocation request of 27 bytes returns an allocation of 32 bytes and <c>GetSize</c> returns 27.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-imallocspy-pregetsize void * PreGetSize( void *pRequest,
		// BOOL fSpyed );
		IntPtr PreGetSize(IntPtr pRequest, [MarshalAs(UnmanagedType.Bool)] bool fSpyed);

		/// <summary>Performs operations required after calling IMalloc::GetSize.</summary>
		/// <param name="cbActual">The number of bytes in the allocation, as returned by GetSize.</param>
		/// <param name="fSpyed">Indicates whether the block of memory was allocated while the current spy was active.</param>
		/// <returns>The value returned by IMalloc::GetSize, which is the size of the allocated block of memory, in bytes.</returns>
		/// <remarks>
		/// The size determined by GetSize is the value returned by the HeapSize function. This is the size originally requested. For
		/// example, a memory allocation request of 27 bytes returns an allocation of 32 bytes and <c>GetSize</c> returns 27.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-imallocspy-postgetsize SizeT PostGetSize( SizeT
		// cbActual, BOOL fSpyed );
		[PreserveSig]
		SizeT PostGetSize(SizeT cbActual, [MarshalAs(UnmanagedType.Bool)] bool fSpyed);

		/// <summary>Performs operations required before calling IMalloc::DidAlloc.</summary>
		/// <param name="pRequest">The pointer specified in the call to DidAlloc.</param>
		/// <param name="fSpyed">Indicates whether the allocation was done while this spy was active.</param>
		/// <returns>The value passed to DidAlloc as the fActual parameter.</returns>
		/// <remarks>
		/// When a spy object implementing IMallocSpy is registered with the CoRegisterMallocSpy function, COM calls this method
		/// immediately before any call to IMalloc::DidAlloc. This method is included for completeness and consistencyâ€”it is not
		/// anticipated that developers will implement significant functionality in this method.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-imallocspy-predidalloc void * PreDidAlloc( void *pRequest,
		// BOOL fSpyed );
		[PreserveSig]
		IntPtr PreDidAlloc(IntPtr pRequest, [MarshalAs(UnmanagedType.Bool)] bool fSpyed);

		/// <summary>Performs operations required after calling IMalloc::DidAlloc.</summary>
		/// <param name="pRequest">The pointer specified in the call to DidAlloc.</param>
		/// <param name="fSpyed">Indicates whether the allocation was done while this spy was active.</param>
		/// <param name="fActual">The value returned by DidAlloc.</param>
		/// <returns>The value returned to the caller of DidAlloc.</returns>
		/// <remarks>
		/// <para>
		/// When a spy object implementing IMallocSpy is registered using the CoRegisterMallocSpy function, COM calls this method
		/// immediately after any call to DidAlloc. This method is included for completeness and consistencyâ€”it is not anticipated that
		/// developers will implement significant functionality in this method.
		/// </para>
		/// <para>
		/// For convenience, pRequest, the original pointer passed in the call to DidAlloc, is passed to <c>PostDidAlloc</c>. In
		/// addition, the parameter fActual is a Boolean value that indicates whether this value was actually passed to <c>DidAlloc</c>.
		/// If not, it would indicate that IMallocSpy::PreDidAlloc was implemented to alter this pointer for some debugging purpose.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-imallocspy-postdidalloc int PostDidAlloc( void *pRequest,
		// BOOL fSpyed, int fActual );
		[PreserveSig]
		int PostDidAlloc(IntPtr pRequest, [MarshalAs(UnmanagedType.Bool)] bool fSpyed, int fActual);

		/// <summary>Performs operations required before calling IMalloc::HeapMinimize.</summary>
		/// <returns>This method does not return a value.</returns>
		/// <remarks>
		/// This method is included for completeness; it is not anticipated that developers will implement significant functionality in
		/// this method.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-imallocspy-preheapminimize void PreHeapMinimize( );
		[PreserveSig]
		void PreHeapMinimize();

		/// <summary>Performs operations required after calling IMalloc::HeapMinimize.</summary>
		/// <returns>This method does not return a value.</returns>
		/// <remarks>
		/// When a spy object implementing IMallocSpy is registered using the CoRegisterMallocSpy function, COM calls this method
		/// immediately after any call to IMalloc::Free. This method is included for completeness and consistencyâ€”it is not anticipated
		/// that developers will implement significant functionality in this method.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-imallocspy-postheapminimize void PostHeapMinimize( );
		[PreserveSig]
		void PostHeapMinimize();
	}

	/// <summary>
	/// <para>This interface allows an application to capture a message before it is dispatched to a control or form.</para>
	/// <para>
	/// A class that implements the IMessageFilter interface can be added to the application's message pump to filter out a message or
	/// perform other operations before the message is dispatched to a form or control. To add the message filter to an application's
	/// message pump, use the AddMessageFilter method in the Application class.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.imessagefilter?view=netframework-4.8
	[PInvokeData("", MSDNShortId = "System.Windows.Forms.IMessageFilter")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("00000016-0000-0000-C000-000000000046")]
	public interface IMessageFilter
	{
		/// <summary>
		/// <para>Provides a single entry point for incoming calls.</para>
		/// <para>
		/// This method is called prior to each method invocation originating outside the current process and provides the ability to
		/// filter or reject incoming calls (or callbacks) to an object or a process.
		/// </para>
		/// </summary>
		/// <param name="dwCallType">The type of incoming call that has been received. Possible values are from the enumeration CALLTYPE.</param>
		/// <param name="htaskCaller">The thread id of the caller.</param>
		/// <param name="dwTickCount">
		/// The elapsed tick count since the outgoing call was made, if dwCallType is not CALLTYPE_TOPLEVEL. If dwCallType is
		/// CALLTYPE_TOPLEVEL, dwTickCount should be ignored.
		/// </param>
		/// <param name="lpInterfaceInfo">
		/// A pointer to an INTERFACEINFO structure that identifies the object, interface, and method being called. In the case of DDE
		/// calls, lpInterfaceInfo can be <c>NULL</c> because the DDE layer does not return interface information.
		/// </param>
		/// <returns>
		/// <para>This method can return the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>SERVERCALL_ISHANDLED</term>
		/// <term>The application might be able to process the call.</term>
		/// </item>
		/// <item>
		/// <term>SERVERCALL_REJECTED</term>
		/// <term>
		/// The application cannot handle the call due to an unforeseen problem, such as network unavailability, or if it is in the
		/// process of terminating.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SERVERCALL_RETRYLATER</term>
		/// <term>
		/// The application cannot handle the call at this time. An application might return this value when it is in a user-controlled
		/// modal state.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>If implemented, <c>HandleInComingCall</c> is called by COM when an incoming COM message is received.</para>
		/// <para>
		/// Depending on an application's current state, a call is either accepted and processed or rejected (permanently or
		/// temporarily). If SERVERCALL_ISHANDLED is returned, the application may be able to process the call, although success depends
		/// on the interface for which the call is destined. If the call cannot be processed, COM returns RPC_E_CALL_REJECTED.
		/// </para>
		/// <para>Input-synchronized and asynchronous calls are dispatched even if the application returns SERVERCALL_REJECTED or SERVERCALL_RETRYLATER.</para>
		/// <para>
		/// <c>HandleInComingCall</c> should not be used to hold off updates to objects during operations such as band printing. For that
		/// purpose, use IViewObject::Freeze.
		/// </para>
		/// <para>
		/// You can also use <c>HandleInComingCall</c> to set up the application's state so that the call can be processed in the future.
		/// </para>
		/// <para>
		/// <c>Note</c> Although the htaskCaller parameter is typed as an HTASK, it contains the thread id of the calling thread. When
		/// you implement the IMessageFilter interface, you can call the OpenThread function to get the thread handle from the
		/// htaskCaller parameter, and you can call the GetProcessIdOfThread function to get the process id.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-imessagefilter-handleincomingcall DWORD
		// HandleInComingCall( DWORD dwCallType, HTASK htaskCaller, DWORD dwTickCount, LPINTERFACEINFO lpInterfaceInfo );
		[PreserveSig]
		SERVERCALL HandleInComingCall(CALLTYPE dwCallType, HTASK htaskCaller, uint dwTickCount, [Optional] INTERFACEINFO? lpInterfaceInfo);

		/// <summary>
		/// Provides applications with an opportunity to display a dialog box offering retry, cancel, or task-switching options.
		/// </summary>
		/// <param name="htaskCallee">The thread id of the called application.</param>
		/// <param name="dwTickCount">The number of elapsed ticks since the call was made.</param>
		/// <param name="dwRejectType">Specifies either SERVERCALL_REJECTED or SERVERCALL_RETRYLATER, as returned by the object application.</param>
		/// <returns>
		/// <para>This method can return the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>-1</term>
		/// <term>The call should be canceled. COM then returns RPC_E_CALL_REJECTED from the original method call.</term>
		/// </item>
		/// <item>
		/// <term>0 ≤ value &lt; 100</term>
		/// <term>The call is to be retried immediately.</term>
		/// </item>
		/// <item>
		/// <term>100 ≤ value</term>
		/// <term>COM will wait for this many milliseconds and then retry the call.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// COM calls <c>RetryRejectedCall</c> on the caller's IMessageFilter interface immediately after receiving SERVERCALL_RETRYLATER
		/// or SERVERCALL_REJECTED from the IMessageFilter::HandleInComingCall method on the callee's <c>IMessageFilter</c> interface.
		/// </para>
		/// <para>
		/// If a called task rejects a call, the application is probably in a state where it cannot handle such calls, possibly only
		/// temporarily. When this occurs, COM returns to the caller and issues <c>RetryRejectedCall</c> to determine whether it should
		/// retry the rejected call.
		/// </para>
		/// <para>
		/// Applications should silently retry calls that have returned with SERVERCALL_RETRYLATER. If, after a reasonable amount of time
		/// has passed, say about 30 seconds, the application should display the busy dialog box; a standard implementation of this
		/// dialog box is available in the OLEDLG library. The callee may momentarily be in a state where calls can be handled. The
		/// option to wait and retry is provided for special kinds of calling applications, such as background tasks executing macros or
		/// scripts, so that they can retry the calls in a nonintrusive way.
		/// </para>
		/// <para>
		/// If, after a dialog box is displayed, the user chooses to cancel, <c>RetryRejectedCall</c> returns -1 and the call will appear
		/// to fail with RPC_E_CALL_REJECTED.
		/// </para>
		/// <para>
		/// If a client implements IMessageFilter and calls a server method on a remote machine, <c>RetryRejectedCall</c> will not be called.
		/// </para>
		/// <para>
		/// <c>Note</c> Although the htaskCallee parameter is typed as an HTASK, it contains the thread id of the called thread. When you
		/// implement the IMessageFilter interface, you can call the OpenThread function to get the thread handle from the htaskCallee
		/// parameter, and you can call the GetProcessIdOfThread function to get the process id.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-imessagefilter-retryrejectedcall DWORD RetryRejectedCall(
		// HTASK htaskCallee, DWORD dwTickCount, DWORD dwRejectType );
		[PreserveSig]
		uint RetryRejectedCall(HTASK htaskCallee, uint dwTickCount, SERVERCALL dwRejectType);

		/// <summary>
		/// <para>Indicates that a message has arrived while COM is waiting to respond to a remote call.</para>
		/// <para>
		/// Handling input while waiting for an outgoing call to finish can introduce complications. The application should determine
		/// whether to process the message without interrupting the call, to continue waiting, or to cancel the operation.
		/// </para>
		/// </summary>
		/// <param name="htaskCallee">The thread id of the called application.</param>
		/// <param name="dwTickCount">The number of ticks since the call was made. It is calculated from the GetTickCount function.</param>
		/// <param name="dwPendingType">
		/// The type of call made during which a message or event was received. Possible values are from the enumeration PENDINGTYPE,
		/// where PENDINGTYPE_TOPLEVEL means the outgoing call was not nested within a call from another application and
		/// PENDINTGYPE_NESTED means the outgoing call was nested within a call from another application.
		/// </param>
		/// <returns>
		/// <para>This method can return the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>PENDINGMSG_CANCELCALL</term>
		/// <term>
		/// Cancel the outgoing call. This should be returned only under extreme conditions. Canceling a call that has not replied or
		/// been rejected can create orphan transactions and lose resources. COM fails the original call and returns RPC_E_CALL_CANCELLED.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PENDINGMSG_WAITNOPROCESS</term>
		/// <term>Unused.</term>
		/// </item>
		/// <item>
		/// <term>PENDINGMSG_WAITDEFPROCESS</term>
		/// <term>
		/// Keyboard and mouse messages are no longer dispatched. However there are some cases where mouse and keyboard messages could
		/// cause the system to deadlock, and in these cases, mouse and keyboard messages are discarded. WM_PAINT messages are
		/// dispatched. Task-switching and activation messages are handled as before.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// COM calls <c>MessagePending</c> after an application has made a COM method call and a Windows message occurs before the call
		/// has returned. A Windows message is sent, for example, when the user selects a menu command or double-clicks an object. Before
		/// COM makes the <c>MessagePending</c> call, it calculates the elapsed time since the original COM method call was made. COM
		/// delivers the elapsed time in the dwTickCount parameter. In the meantime, COM does not remove the message from the queue.
		/// </para>
		/// <para>
		/// Windows messages that appear in the caller's queue should remain in the queue until sufficient time has passed to ensure that
		/// the messages are probably not the result of typing ahead, but are instead an attempt to get attention. Set the delay with the
		/// dwTickCount parameter —a two-second or three-second delay is recommended. If that amount of time passes and the call has not
		/// been completed, the caller should flush the messages from the queue and the OLE UI busy dialog box should be displayed
		/// offering the user the choice of retrying the call (continue waiting) or switching to the specified task. This ensures the
		/// following behaviors:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>If calls are completed in a reasonable amount of time, type ahead will be treated correctly.</term>
		/// </item>
		/// <item>
		/// <term>
		/// If the callee does not respond, type ahead is not misinterpreted and the user is able to act to solve the problem. For
		/// example, OLE 1 servers can queue up requests without responding when they are in modal dialog boxes.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// Handling input while waiting for an outgoing call to finish can introduce complications. The application should determine
		/// whether to process the message without interrupting the call, to continue waiting, or to cancel the operation.
		/// </para>
		/// <para>
		/// When there is no response to the original COM call, the application can cancel the call and restore the COM object to a
		/// consistent state by calling IStorage::Revert on its storage. The object can be released when the container can shut down.
		/// However, canceling a call can create orphaned operations and resource leaks. Canceling should be used only as a last resort.
		/// It is strongly recommended that applications not allow such calls to be canceled.
		/// </para>
		/// <para>
		/// <c>Note</c> Although the htaskCallee parameter is typed as an HTASK, it contains the thread id of the called thread. When you
		/// implement the IMessageFilter interface, you can call the OpenThread function to get the thread handle from the htaskCallee
		/// parameter, and you can call the GetProcessIdOfThread function to get the process id.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-imessagefilter-messagepending DWORD MessagePending( HTASK
		// htaskCallee, DWORD dwTickCount, DWORD dwPendingType );
		[PreserveSig]
		PENDINGMSG MessagePending(HTASK htaskCallee, uint dwTickCount, PENDINGTYPE dwPendingType);
	}

	/// <summary>
	/// <para>
	/// Provides the CLSID of an object that can be stored persistently in the system. Allows the object to specify which object handler
	/// to use in the client process, as it is used in the default implementation of marshaling.
	/// </para>
	/// <para>
	/// <c>IPersist</c> is the base interface for three other interfaces: IPersistStorage, IPersistStream, and IPersistFile. Each of
	/// these interfaces, therefore, includes the GetClassID method, and the appropriate one of these three interfaces is implemented on
	/// objects that can be serialized to a storage, a stream, or a file. The methods of these interfaces allow the state of these
	/// objects to be saved for later instantiations, and load the object using the saved state. Typically, the persistence interfaces
	/// are implemented by an embedded or linked object, and are called by the container application or the default object handler.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nn-objidl-ipersist
	[PInvokeData("objidl.h", MSDNShortId = "932eb0e2-35a6-482e-9138-00cff30508a9")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("0000010c-0000-0000-C000-000000000046")]
	public interface IPersist
	{
		/// <summary>Retrieves the class identifier (CLSID) of the object.</summary>
		/// <returns>
		/// <para>
		/// A pointer to the location that receives the CLSID on return. The CLSID is a globally unique identifier (GUID) that uniquely
		/// represents an object class that defines the code that can manipulate the object's data.
		/// </para>
		/// <para>If the method succeeds, the return value is S_OK. Otherwise, it is E_FAIL.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>GetClassID</c> method retrieves the class identifier (CLSID) for an object, used in later operations to load
		/// object-specific code into the caller's context.
		/// </para>
		/// <para>Notes to Callers</para>
		/// <para>
		/// A container application might call this method to retrieve the original CLSID of an object that it is treating as a
		/// different class. Such a call would be necessary if a user performed an editing operation that required the object to be
		/// saved. If the container were to save it using the treat-as CLSID, the original application would no longer be able to edit
		/// the object. Typically, in this case, the container calls the OleSave helper function, which performs all the necessary
		/// steps. For this reason, most container applications have no need to call this method directly.
		/// </para>
		/// <para>
		/// The exception would be a container that provides an object handler for certain objects. In particular, a container
		/// application should not get an object's CLSID and then use it to retrieve class specific information from the registry.
		/// Instead, the container should use IOleObject and IDataObject interfaces to retrieve such class-specific information directly
		/// from the object.
		/// </para>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// Typically, implementations of this method simply supply a constant CLSID for an object. If, however, the object's
		/// <c>TreatAs</c> registry key has been set by an application that supports emulation (and so is treating the object as one of
		/// a different class), a call to <c>GetClassID</c> must supply the CLSID specified in the <c>TreatAs</c> key. For more
		/// information on emulation, see CoTreatAsClass.
		/// </para>
		/// <para>
		/// When an object is in the running state, the default handler calls an implementation of <c>GetClassID</c> that delegates the
		/// call to the implementation in the object. When the object is not running, the default handler instead calls the ReadClassStg
		/// function to read the CLSID that is saved in the object's storage.
		/// </para>
		/// <para>
		/// If you are writing a custom object handler for your object, you might want to simply delegate this method to the default
		/// handler implementation (see OleCreateDefaultHandler).
		/// </para>
		/// <para>URL Moniker Notes</para>
		/// <para>This method returns CLSID_StdURLMoniker.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ipersist-getclassid HRESULT GetClassID( CLSID *pClassID );
		Guid GetClassID();
	}

	/// <summary>
	/// Enables a container application to pass a storage object to one of its contained objects and to load and save the storage object.
	/// This interface supports the structured storage model, in which each contained object has its own storage that is nested within
	/// the container's storage.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nn-objidl-ipersiststorage
	[PInvokeData("objidl.h", MSDNShortId = "1c1a20fc-c101-4cbc-a7a6-30613aa387d7")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("0000010a-0000-0000-C000-000000000046")]
	public interface IPersistStorage : IPersist
	{
		/// <summary>Retrieves the class identifier (CLSID) of the object.</summary>
		/// <returns>
		/// <para>
		/// A pointer to the location that receives the CLSID on return. The CLSID is a globally unique identifier (GUID) that uniquely
		/// represents an object class that defines the code that can manipulate the object's data.
		/// </para>
		/// <para>If the method succeeds, the return value is S_OK. Otherwise, it is E_FAIL.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>GetClassID</c> method retrieves the class identifier (CLSID) for an object, used in later operations to load
		/// object-specific code into the caller's context.
		/// </para>
		/// <para>Notes to Callers</para>
		/// <para>
		/// A container application might call this method to retrieve the original CLSID of an object that it is treating as a different
		/// class. Such a call would be necessary if a user performed an editing operation that required the object to be saved. If the
		/// container were to save it using the treat-as CLSID, the original application would no longer be able to edit the object.
		/// Typically, in this case, the container calls the OleSave helper function, which performs all the necessary steps. For this
		/// reason, most container applications have no need to call this method directly.
		/// </para>
		/// <para>
		/// The exception would be a container that provides an object handler for certain objects. In particular, a container
		/// application should not get an object's CLSID and then use it to retrieve class specific information from the registry.
		/// Instead, the container should use IOleObject and IDataObject interfaces to retrieve such class-specific information directly
		/// from the object.
		/// </para>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// Typically, implementations of this method simply supply a constant CLSID for an object. If, however, the object's
		/// <c>TreatAs</c> registry key has been set by an application that supports emulation (and so is treating the object as one of a
		/// different class), a call to <c>GetClassID</c> must supply the CLSID specified in the <c>TreatAs</c> key. For more information
		/// on emulation, see CoTreatAsClass.
		/// </para>
		/// <para>
		/// When an object is in the running state, the default handler calls an implementation of <c>GetClassID</c> that delegates the
		/// call to the implementation in the object. When the object is not running, the default handler instead calls the ReadClassStg
		/// function to read the CLSID that is saved in the object's storage.
		/// </para>
		/// <para>
		/// If you are writing a custom object handler for your object, you might want to simply delegate this method to the default
		/// handler implementation (see OleCreateDefaultHandler).
		/// </para>
		/// <para>URL Moniker Notes</para>
		/// <para>This method returns CLSID_StdURLMoniker.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ipersist-getclassid HRESULT GetClassID( CLSID *pClassID );
		new Guid GetClassID();

		/// <summary>Determines whether an object has changed since it was last saved to its current storage.</summary>
		/// <returns>This method returns S_OK to indicate that the object has changed. Otherwise, it returns S_FALSE.</returns>
		/// <remarks>
		/// <para>
		/// Use this method to determine whether an object should be saved before closing it. The dirty flag for an object is
		/// conditionally cleared in the IPersistStorage::Save method.
		/// </para>
		/// <para>
		/// For example, you could optimize a <c>File Save</c> operation by calling the <c>IPersistStorage::IsDirty</c> method for each
		/// object and then calling the IPersistStorage::Save method only for those objects that are dirty.
		/// </para>
		/// <para>Notes to Callers</para>
		/// <para>
		/// You should treat any error return codes as an indication that the object has changed. Unless this method explicitly returns
		/// S_FALSE, assume that the object must be saved.
		/// </para>
		/// <para>Notes to Implementers</para>
		/// <para>An object with no contained objects simply checks its dirty flag to return the appropriate result.</para>
		/// <para>
		/// A container with one or more contained objects must maintain an internal dirty flag that is set when any of its contained
		/// objects has changed since it was last saved.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-ipersiststorage-isdirty HRESULT IsDirty( );
		[PreserveSig]
		HRESULT IsDirty();

		/// <summary>Initializes a new storage object.</summary>
		/// <param name="pStg">
		/// An IStorage pointer to the new storage object to be initialized. The container creates a nested storage object in its storage
		/// object (see IStorage::CreateStorage). Then, the container calls the WriteClassStg function to initialize the new storage
		/// object with the object class identifier (CLSID).
		/// </param>
		/// <remarks>
		/// <para>
		/// A container application can call this method when it needs to initialize a new object, for example, with an InsertObject command.
		/// </para>
		/// <para>
		/// An object that supports the IPersistStorage interface must have access to a valid storage object at all times while it is
		/// running. This includes the time just after the object has been created but before it has been made persistent. The object's
		/// container must provide the object with a valid IStorage pointer to the storage during this time through the call to
		/// <c>IPersistStorage::InitNew</c>. Depending on the container's state, a temporary file might have to be created for this purpose.
		/// </para>
		/// <para>If the object wants to retain the IStorage instance, it must call AddRef to increment its reference count.</para>
		/// <para>
		/// After the call to <c>IPersistStorage::InitNew</c>, the object is in either the loaded or running state. For example, if the
		/// object class has an in-process server, the object will be in the running state. However, if the object uses the default
		/// handler, the container's call to <c>InitNew</c> only invokes the handler's implementation which does not run the object.
		/// Later if the container runs the object, the handler calls the <c>InitNew</c> method for the object.
		/// </para>
		/// <para>Notes to Callers</para>
		/// <para>
		/// Rather than calling <c>IPersistStorage::InitNew</c> directly, you typically call the OleCreate helper function which does the following:
		/// </para>
		/// <list type="number">
		/// <item>
		/// <term>Calls the CoCreateInstance function to create an instance of the object class.</term>
		/// </item>
		/// <item>
		/// <term>Queries the new instance for the IPersistStorage interface.</term>
		/// </item>
		/// <item>
		/// <term>Calls the <c>InitNew</c> method to initialize the object.</term>
		/// </item>
		/// </list>
		/// <para>
		/// The container application should cache the IPersistStorage pointer to the object for use in later operations on the object.
		/// </para>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// An implementation of <c>IPersistStorage::InitNew</c> should initialize the object to its default state, taking the following steps:
		/// </para>
		/// <list type="number">
		/// <item>
		/// <term>Pre-open and cache the pointers to any streams or storages that the object will need to save itself to this storage.</term>
		/// </item>
		/// <item>
		/// <term>Call AddRef and cache the storage pointer that is passed in.</term>
		/// </item>
		/// <item>
		/// <term>
		/// Call the WriteFmtUserTypeStg function to write the native clipboard format and user type string for the object to the storage object.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Set the dirty flag for the object.</term>
		/// </item>
		/// </list>
		/// <para>
		/// The first two steps are particularly important for ensuring that the object can save itself in low memory situations.
		/// Pre-opening and holding onto pointers to the stream and storage interfaces guarantee that a save operation to this storage
		/// will not fail due to insufficient memory.
		/// </para>
		/// <para>
		/// Your implementation of this method should return the CO_E_ALREADYINITIALIZED error code if it receives a call to either the
		/// <c>IPersistStorage::InitNew</c> method or the IPersistStorage::Load method after it is already initialized.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-ipersiststorage-initnew HRESULT InitNew( IStorage *pStg );
		void InitNew([In] IStorage pStg);

		/// <summary>Loads an object from its existing storage.</summary>
		/// <param name="pStg">An IStorage pointer to the existing storage from which the object is to be loaded.</param>
		/// <remarks>
		/// <para>
		/// This method initializes an object from an existing storage. The object is placed in the loaded state if this method is called
		/// by the container application. If called by the default handler, this method places the object in the running state.
		/// </para>
		/// <para>Either the default handler or the object itself can hold onto the IStorage pointer while the object is loaded or running.</para>
		/// <para>Notes to Callers</para>
		/// <para>
		/// Rather than calling <c>IPersistStorage::Load</c> directly, you typically call the OleLoad helper function which does the following:
		/// </para>
		/// <list type="number">
		/// <item>
		/// <term>Create an uninitialized instance of the object class.</term>
		/// </item>
		/// <item>
		/// <term>Query the new instance for the IPersistStorage interface.</term>
		/// </item>
		/// <item>
		/// <term>Call <c>Load</c> to initialize the object from the existing storage.</term>
		/// </item>
		/// </list>
		/// <para>
		/// You also call this method indirectly when you call the OleCreateFromData function or the OleCreateFromFile function to insert
		/// an object into a compound file (as in a drag-and-drop or clipboard paste operation).
		/// </para>
		/// <para>The container should cache the IPersistStorage pointer for use in later operations on the object.</para>
		/// <para>Notes to Implementers</para>
		/// <para>Your implementation should perform the following steps to load an object:</para>
		/// <list type="number">
		/// <item>
		/// <term>Open the object's streams in the storage object, and read the necessary data into the object's internal data structures.</term>
		/// </item>
		/// <item>
		/// <term>Clear the object's dirty flag.</term>
		/// </item>
		/// <item>
		/// <term>Call the AddRef method and cache the passed in storage pointer.</term>
		/// </item>
		/// <item>
		/// <term>Keep open and cache the pointers to any streams or storages that the object will need to save itself to this storage.</term>
		/// </item>
		/// <item>
		/// <term>Perform any other default initialization required for the object.</term>
		/// </item>
		/// </list>
		/// <para>
		/// Steps 3 and 4 are particularly important for ensuring that the object can save itself in low memory situations. Holding onto
		/// pointers to the storage and stream interfaces guarantees that a save operation to this storage will not fail due to
		/// insufficient memory.
		/// </para>
		/// <para>
		/// Your implementation of this method should return the CO_E_ALREADYINITIALIZED error code if it receives a call to either the
		/// IPersistStorage::InitNew method or the <c>IPersistStorage::Load</c> method after it is already initialized.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-ipersiststorage-load HRESULT Load( IStorage *pStg );
		void Load([In] IStorage pStg);

		/// <summary>
		/// Saves an object, and any nested objects that it contains, into the specified storage object. The object enters NoScribble mode.
		/// </summary>
		/// <param name="pStgSave">An IStorage pointer to the storage into which the object is to be saved.</param>
		/// <param name="fSameAsLoad">
		/// <para>
		/// Indicates whether the specified storage is the current one, which was passed to the object by one of the following calls:
		/// IPersistStorage::InitNew, IPersistStorage::Load, or IPersistStorage::SaveCompleted.
		/// </para>
		/// <para>
		/// This parameter is set to <c>FALSE</c> when performing a <c>Save As</c> or <c>Save A Copy To</c> operation or when performing
		/// a full save. In the latter case, this method saves to a temporary file, deletes the original file, and renames the temporary file.
		/// </para>
		/// <para>
		/// This parameter is set to <c>TRUE</c> to perform a full save in a low-memory situation or to perform a fast incremental save
		/// in which only the dirty components are saved.
		/// </para>
		/// </param>
		/// <remarks>
		/// <para>
		/// This method saves an object, and any nested objects it contains, into the specified storage. It also places the object into
		/// NoScribble mode. Thus, the object cannot write to its storage until a subsequent call to the IPersistStorage::SaveCompleted
		/// method returns the object to Normal mode.
		/// </para>
		/// <para>
		/// If the storage object is the same as the one it was loaded or created from, the save operation may be able to write
		/// incremental changes to the storage object. Otherwise, a full save must be done.
		/// </para>
		/// <para>
		/// This method recursively calls the <c>IPersistStorage::Save</c> method, the OleSave function, or the IStorage::CopyTo method
		/// to save its nested objects.
		/// </para>
		/// <para>
		/// This method does not call the IStorage::Commit method. Nor does it write the CLSID to the storage object. Both of these tasks
		/// are the responsibilities of the caller.
		/// </para>
		/// <para>Notes to Callers</para>
		/// <para>
		/// Rather than calling <c>IPersistStorage::Save</c> directly, you typically call the OleSave helper function which performs the
		/// following steps:
		/// </para>
		/// <list type="number">
		/// <item>
		/// <term>Call the WriteClassStg function to write the class identifier for the object to the storage.</term>
		/// </item>
		/// <item>
		/// <term>Call the <c>IPersistStorage::Save</c> method.</term>
		/// </item>
		/// <item>
		/// <term>If needed, call the IStorage::Commit method on the storage object.</term>
		/// </item>
		/// </list>
		/// <para>
		/// Then, a container application performs any other operations necessary to complete the save and calls the SaveCompleted method
		/// for each object.
		/// </para>
		/// <para>
		/// If an embedded object passes the <c>IPersistStorage::Save</c> method to its nested objects, it must receive a call to its
		/// IPersistStorage::SaveCompleted method before calling this method for its nested objects.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-ipersiststorage-save HRESULT Save( IStorage *pStgSave,
		// BOOL fSameAsLoad );
		void Save([In] IStorage pStgSave, [MarshalAs(UnmanagedType.Bool)] bool fSameAsLoad);

		/// <summary>
		/// Notifies the object that it can write to its storage object. It does this by notifying the object that it can revert from
		/// NoScribble mode (in which it must not write to its storage object), to Normal mode (in which it can). The object enters
		/// NoScribble mode when it receives an IPersistStorage::Save call.
		/// </summary>
		/// <param name="pStgNew">
		/// An IStorage pointer to the new storage object, if different from the storage object prior to saving. This pointer can be
		/// <c>NULL</c> if the current storage object does not change during the save operation. If the object is in HandsOff mode, this
		/// parameter must be non- <c>NULL</c>.
		/// </param>
		/// <remarks>
		/// <para>
		/// This method notifies an object that it can revert to Normal mode and can once again write to its storage object. The object
		/// exits NoScribble mode or HandsOff mode.
		/// </para>
		/// <para>
		/// If the object is reverting from HandsOff mode, the pStgNew parameter must be non- <c>NULL</c>. In HandsOffFromNormal mode,
		/// this parameter is the new storage object that replaces the one that was revoked by the IPersistStorage::HandsOffStorage
		/// method. The data in the storage object is a copy of the data from the revoked storage object. In HandsOffAfterSave mode, the
		/// data is the same as the data that was most recently saved. It is not the same as the data in the revoked storage object.
		/// </para>
		/// <para>
		/// If the object is reverting from NoScribble mode, the pStgNew parameter can be <c>NULL</c> or non- <c>NULL</c>. If
		/// <c>NULL</c>, the object once again has access to its storage object. If it is not <c>NULL</c>, the component object should
		/// simulate receiving a call to its HandsOffStorage method. If the component object cannot simulate this call, its container
		/// must be prepared to actually call the <c>HandsOffStorage</c> method.
		/// </para>
		/// <para>This method must recursively call any nested objects that are loaded or running.</para>
		/// <para>
		/// If this method returns an error code, the object is not returned to Normal mode. Thus, the container object can attempt
		/// different save strategies.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-ipersiststorage-savecompleted HRESULT SaveCompleted(
		// IStorage *pStgNew );
		void SaveCompleted([In] IStorage? pStgNew);

		/// <summary>
		/// Instructs the object to release all storage objects that have been passed to it by its container and to enter HandsOff mode.
		/// </summary>
		/// <remarks>
		/// <para>
		/// This method causes an object to release any storage objects that it is holding and to enter the HandsOff mode until a
		/// subsequent IPersistStorage::SaveCompleted call. In HandsOff mode, the object cannot do anything and the only operation that
		/// works is a close operation.
		/// </para>
		/// <para>
		/// A container application typically calls this method during a full save or low-memory full save operation to force the object
		/// to release all pointers to its current storage. In these scenarios, the <c>HandsOffStorage</c> call comes after a call to
		/// either OleSave or IPersistStorage::Save, putting the object in HandsOffAfterSave mode. Calling this method is necessary so
		/// the container application can delete the current file as part of a full save, or so it can call the
		/// IRootStorage::SwitchToFile method as part of a low-memory save.
		/// </para>
		/// <para>
		/// A container application also calls this method when an object is in Normal mode to put the object in HandsOffFromNormal mode.
		/// </para>
		/// <para>
		/// While the component object is in either HandsOffAfterSave or HandsOffFromNormal mode, most operations on the object will
		/// fail. Thus, the container should restore the object to Normal mode as soon as possible. The container application does this
		/// by calling the IPersistStorage::SaveCompleted method, which passes a storage pointer back to the component object for the new
		/// storage object.
		/// </para>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// This method must release all pointers to the current storage object, including pointers to any nested streams and storages.
		/// If the object contains nested objects, the container application must recursively call this method for any nested objects
		/// that are loaded or running.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-ipersiststorage-handsoffstorage HRESULT HandsOffStorage( );
		void HandsOffStorage();
	}

	/// <summary>Enables the saving and loading of objects that use a simple serial stream for their storage needs.</summary>
	/// <remarks>
	/// <para>
	/// One way in which this interface is used is to support OLE moniker implementations. Each of the OLE-provided moniker interfaces
	/// provides an <c>IPersistStream</c> implementation through which the moniker saves or loads itself. An instance of the OLE generic
	/// composite moniker class calls the <c>IPersistStream</c> methods of its component monikers to load or save the components in the
	/// proper sequence in a single stream.
	/// </para>
	/// <para>IPersistStream URL Moniker Implementation</para>
	/// <para>
	/// The URL moniker implementation of <c>IPersistStream</c> is found on an URL moniker object, which supports IUnknown,
	/// <c>IAsyncMoniker</c>, and IMoniker. The <c>IMoniker</c> interface inherits its definition from <c>IPersistStream</c> and thus,
	/// the URL moniker also provides an implementation of <c>IPersistStream</c> as part of its implementation of <c>IMoniker</c>.
	/// </para>
	/// <para>
	/// The IAsyncMoniker interface on an URL moniker is simply IUnknown (there are no additional methods); it is used to allow clients
	/// to determine if a moniker supports asynchronous binding. To get a pointer to the IMoniker interface on this object, call the
	/// <c>CreateURLMonikerEx</c> function. Then, to get a pointer to <c>IPersistStream</c>, call the QueryInterface method.
	/// </para>
	/// <para>
	/// <c>IPersistStream</c>, in addition to inheriting its definition from IUnknown, also inherits the single method of IPersist, GetClassID.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nn-objidl-ipersiststream
	[PInvokeData("objidl.h", MSDNShortId = "97ea64ee-d950-4872-add6-1f532a6eb33f")]
	[ComImport, Guid("00000109-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IPersistStream : IPersist
	{
		/// <summary>Retrieves the class identifier (CLSID) of the object.</summary>
		/// <returns>
		/// <para>
		/// A pointer to the location that receives the CLSID on return. The CLSID is a globally unique identifier (GUID) that uniquely
		/// represents an object class that defines the code that can manipulate the object's data.
		/// </para>
		/// <para>If the method succeeds, the return value is S_OK. Otherwise, it is E_FAIL.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>GetClassID</c> method retrieves the class identifier (CLSID) for an object, used in later operations to load
		/// object-specific code into the caller's context.
		/// </para>
		/// <para>Notes to Callers</para>
		/// <para>
		/// A container application might call this method to retrieve the original CLSID of an object that it is treating as a
		/// different class. Such a call would be necessary if a user performed an editing operation that required the object to be
		/// saved. If the container were to save it using the treat-as CLSID, the original application would no longer be able to edit
		/// the object. Typically, in this case, the container calls the OleSave helper function, which performs all the necessary
		/// steps. For this reason, most container applications have no need to call this method directly.
		/// </para>
		/// <para>
		/// The exception would be a container that provides an object handler for certain objects. In particular, a container
		/// application should not get an object's CLSID and then use it to retrieve class specific information from the registry.
		/// Instead, the container should use IOleObject and IDataObject interfaces to retrieve such class-specific information directly
		/// from the object.
		/// </para>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// Typically, implementations of this method simply supply a constant CLSID for an object. If, however, the object's
		/// <c>TreatAs</c> registry key has been set by an application that supports emulation (and so is treating the object as one of
		/// a different class), a call to <c>GetClassID</c> must supply the CLSID specified in the <c>TreatAs</c> key. For more
		/// information on emulation, see CoTreatAsClass.
		/// </para>
		/// <para>
		/// When an object is in the running state, the default handler calls an implementation of <c>GetClassID</c> that delegates the
		/// call to the implementation in the object. When the object is not running, the default handler instead calls the ReadClassStg
		/// function to read the CLSID that is saved in the object's storage.
		/// </para>
		/// <para>
		/// If you are writing a custom object handler for your object, you might want to simply delegate this method to the default
		/// handler implementation (see OleCreateDefaultHandler).
		/// </para>
		/// <para>URL Moniker Notes</para>
		/// <para>This method returns CLSID_StdURLMoniker.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ipersist-getclassid HRESULT GetClassID( CLSID *pClassID );
		new Guid GetClassID();

		/// <summary>Determines whether an object has changed since it was last saved to its stream.</summary>
		/// <returns>This method returns S_OK to indicate that the object has changed. Otherwise, it returns S_FALSE.</returns>
		/// <remarks>
		/// <para>
		/// Use this method to determine whether an object should be saved before closing it. The dirty flag for an object is
		/// conditionally cleared in the IPersistStream::Save method.
		/// </para>
		/// <para>Notes to Callers</para>
		/// <para>
		/// You should treat any error return codes as an indication that the object has changed. Unless this method explicitly returns
		/// S_FALSE, assume that the object must be saved.
		/// </para>
		/// <para>
		/// Note that the OLE-provided implementations of the <c>IPersistStream::IsDirty</c> method in the OLE-provided moniker
		/// interfaces always return S_FALSE because their internal state never changes.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ipersiststream-isdirty HRESULT IsDirty( );
		[PreserveSig]
		HRESULT IsDirty();

		/// <summary>Initializes an object from the stream where it was saved previously.</summary>
		/// <param name="pstm">The PSTM.</param>
		/// <remarks>
		/// <para>
		/// This method loads an object from its associated stream. The seek pointer is set as it was in the most recent
		/// IPersistStream::Save method. This method can seek and read from the stream, but cannot write to it.
		/// </para>
		/// <para>Notes to Callers</para>
		/// <para>
		/// Rather than calling <c>IPersistStream::Load</c> directly, you typically call the OleLoadFromStream function does the following:
		/// </para>
		/// <list type="number">
		/// <item>
		/// <term>Calls the ReadClassStm function to get the class identifier from the stream.</term>
		/// </item>
		/// <item>
		/// <term>Calls the CoCreateInstance function to create an instance of the object.</term>
		/// </item>
		/// <item>
		/// <term>Queries the instance for IPersistStream.</term>
		/// </item>
		/// <item>
		/// <term>Calls <c>IPersistStream::Load</c>.</term>
		/// </item>
		/// </list>
		/// <para>
		/// The OleLoadFromStream function assumes that objects are stored in the stream with a class identifier followed by the object
		/// data. This storage pattern is used by the generic, composite-moniker implementation provided by OLE.
		/// </para>
		/// <para>If the objects are not stored using this pattern, you must call the methods separately yourself.</para>
		/// <para>URL Moniker Notes</para>
		/// <para>
		/// Initializes an URL moniker from data within a stream, usually stored there previously using its IPersistStream::Save (using
		/// OleSaveToStream). The binary format of the URL moniker is its URL string in Unicode (may be a full or partial URL string,
		/// see CreateURLMonikerEx for details). This is represented as a <c>ULONG</c> count of characters followed by that many Unicode characters.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ipersiststream-load HRESULT Load( IStream *pStm );
		void Load([In, MarshalAs(UnmanagedType.Interface)] IStream pstm);

		/// <summary>Saves an object to the specified stream.</summary>
		/// <param name="pstm">The PSTM.</param>
		/// <param name="fClearDirty">
		/// Indicates whether to clear the dirty flag after the save is complete. If <c>TRUE</c>, the flag should be cleared. If
		/// <c>FALSE</c>, the flag should be left unchanged.
		/// </param>
		/// <remarks>
		/// <para>
		/// <c>IPersistStream::Save</c> saves an object into the specified stream and indicates whether the object should reset its
		/// dirty flag.
		/// </para>
		/// <para>
		/// The seek pointer is positioned at the location in the stream at which the object should begin writing its data. The object
		/// calls the ISequentialStream::Write method to write its data.
		/// </para>
		/// <para>
		/// On exit, the seek pointer must be positioned immediately past the object data. The position of the seek pointer is undefined
		/// if an error returns.
		/// </para>
		/// <para>Notes to Callers</para>
		/// <para>
		/// Rather than calling <c>IPersistStream::Save</c> directly, you typically call the OleSaveToStream helper function which does
		/// the following:
		/// </para>
		/// <list type="number">
		/// <item>
		/// <term>Calls GetClassID to get the object's CLSID.</term>
		/// </item>
		/// <item>
		/// <term>Calls the WriteClassStm function to write the object's CLSID to the stream.</term>
		/// </item>
		/// <item>
		/// <term>Calls <c>IPersistStream::Save</c>.</term>
		/// </item>
		/// </list>
		/// <para>If you call these methods directly, you can write other data into the stream after the CLSID before calling <c>IPersistStream::Save</c>.</para>
		/// <para>The OLE-provided implementation of IPersistStream follows this same pattern.</para>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// The <c>IPersistStream::Save</c> method does not write the CLSID to the stream. The caller is responsible for writing the CLSID.
		/// </para>
		/// <para>
		/// The <c>IPersistStream::Save</c> method can read from, write to, and seek in the stream; but it must not seek to a location
		/// in the stream before that of the seek pointer on entry.
		/// </para>
		/// <para>URL Moniker Notes</para>
		/// <para>
		/// Saves an URL moniker to a stream. The binary format of URL moniker is its URL string in Unicode (may be a full or partial
		/// URL string, see CreateURLMonikerEx for details). This is represented as a <c>ULONG</c> count of characters followed by that
		/// many Unicode characters.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ipersiststream-save HRESULT Save( IStream *pStm, BOOL
		// fClearDirty );
		void Save([In, MarshalAs(UnmanagedType.Interface)] IStream pstm, [In, MarshalAs(UnmanagedType.Bool)] bool fClearDirty);

		/// <summary>Retrieves the size of the stream needed to save the object.</summary>
		/// <returns>The size in bytes of the stream needed to save this object, in bytes.</returns>
		/// <remarks>
		/// <para>
		/// This method returns the size needed to save an object. You can call this method to determine the size and set the necessary
		/// buffers before calling the IPersistStream::Save method.
		/// </para>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// The <c>GetSizeMax</c> implementation should return a conservative estimate of the necessary size because the caller might
		/// call the IPersistStream::Save method with a non-growable stream.
		/// </para>
		/// <para>URL Moniker Notes</para>
		/// <para>
		/// This method retrieves the maximum number of bytes in the stream that will be required by a subsequent call to
		/// IPersistStream::Save. This value is sizeof(ULONG)==4 plus sizeof(WCHAR)*n where n is the length of the full or partial URL
		/// string, including the NULL terminator.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ipersiststream-getsizemax HRESULT GetSizeMax(
		// ULARGE_INTEGER *pcbSize );
		ulong GetSizeMax();
	}

	/// <summary>
	/// <para>[The use of this interface is not recommended; use the IProcessInitControl interface instead.]</para>
	/// <para>Used by ISurrogateService to prevent the process from terminating due to a time-out.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nn-objidl-iprocesslock
	[PInvokeData("objidl.h", MSDNShortId = "NN:objidl.IProcessLock")]
	[ComImport, Guid("000001d5-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IProcessLock
	{
		/// <summary>Increments the reference count of the process.</summary>
		/// <returns>This method returns the new reference count.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-iprocesslock-addrefonprocess ULONG AddRefOnProcess();
		[PreserveSig]
		uint AddRefOnProcess();

		/// <summary>Decrements the reference count of the process.</summary>
		/// <returns>This method returns the new reference count.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-iprocesslock-releaserefonprocess ULONG ReleaseRefOnProcess();
		[PreserveSig]
		uint ReleaseRefOnProcess();
	}

	/// <summary>Enables applications and other objects to receive notifications of changes in the progress of a downloading operation.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nn-objidl-iprogressnotify
	[PInvokeData("objidl.h", MSDNShortId = "NN:objidl.IProgressNotify")]
	[ComImport, Guid("a9d758a0-4617-11cf-95fc-00aa00680db4"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IProgressNotify
	{
		/// <summary>Notifies registered objects and applications of the progress of a downloading operation.</summary>
		/// <param name="dwProgressCurrent">The amount of data available.</param>
		/// <param name="dwProgressMaximum">The total amount of data to be downloaded.</param>
		/// <param name="fAccurate">
		/// Indicates the accuracy of the values in dwProgressCurrent and dwProgressMaximum. They are either reliable ( <c>TRUE</c>) or
		/// unreliable ( <c>FALSE</c>). The <c>FALSE</c> value indicates that control structures for determining the actual position of,
		/// or amount of, data yet to be downloaded are not available.
		/// </param>
		/// <param name="fOwner">
		/// Indicates whether this <c>OnProgress</c> call can control the blocking behavior of the operation. If <c>TRUE</c>, the caller
		/// can use return values from <c>OnProgress</c> to block (STG_S_BLOCK), retry (STG_S_RETRYNOW), or monitor (STG_S_MONITORING)
		/// the operation. If <c>FALSE</c>, the return value from <c>OnProgress</c> has no influence on blocking behavior.
		/// </param>
		/// <returns>
		/// <para>
		/// This method can return the standard return values E_FAIL, E_INVALIDARG, E_OUTOFMEMORY, and E_UNEXPECTED, as well as the
		/// following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>STG_S_RETRYNOW</term>
		/// <term>
		/// The caller is to retry the operation immediately. (This value is most useful for applications that do blocking from within
		/// the callback routine.)
		/// </term>
		/// </item>
		/// <item>
		/// <term>STG_S_BLOCK</term>
		/// <term>
		/// The caller is to block the download and retry the call as needed to determine if additional data is available. This is the
		/// default behavior if no sinks are registered on the connection point.
		/// </term>
		/// </item>
		/// <item>
		/// <term>STG_S_MONITORING</term>
		/// <term>
		/// The callback recipient reliquishes control of the downloading process to one of the other objects or applications that have
		/// registered progress notification sinks on the same stream. This is useful if the notification sink is interested only in
		/// gathering statistics.
		/// </term>
		/// </item>
		/// <item>
		/// <term>E_PENDING</term>
		/// <term>
		/// Data is currently unavailable. The caller is to try again after some desired interval. The notification sink returns this
		/// value if the asynchronous storage is to operate in nonblocking mode.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Sinks may be inherited by any substorage or substream of a given storage. If no sink is registered, the thread will block
		/// until the requested data becomes available, or the download is canceled by the downloader.
		/// </para>
		/// <para>
		/// Where multiple objects or applications have registered progress notification sinks on a single stream, only one of them can
		/// control the behavior of a download. Ownership of the download goes to the first sink to register with the storage or stream,
		/// or any advise skinks that may have been inherited from the parent storage (if the storage was created with ASYNC_MODE_COMPATIBILITY.)
		/// </para>
		/// <para>
		/// Any one of the sinks can relinquish control to the next connection point by returning STG_S_MONITORING to the connection
		/// point making the current caller. After a connection point obtains control (through receiving STG_S_BLOCK or STG_S_RETRYNOW),
		/// all subsequent connection points calling <c>OnProgress</c> will set fOwner to <c>FALSE</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-iprogressnotify-onprogress HRESULT OnProgress( DWORD
		// dwProgressCurrent, DWORD dwProgressMaximum, BOOL fAccurate, BOOL fOwner );
		[PreserveSig]
		HRESULT OnProgress(uint dwProgressCurrent, uint dwProgressMaximum, [MarshalAs(UnmanagedType.Bool)] bool fAccurate, [MarshalAs(UnmanagedType.Bool)] bool fOwner);
	}

	/// <summary>Implemented by monikers to enable the running object table (ROT) to compare monikers against each other.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nn-objidl-irotdata
	[PInvokeData("objidl.h", MSDNShortId = "NN:objidl.IROTData")]
	[ComImport, Guid("f29f6bc0-5021-11ce-aa15-00006901293f"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IROTData
	{
		/// <summary>Retrieves data from a moniker that can be used to test the moniker for equality against another moniker.</summary>
		/// <param name="pbData">A pointer to a buffer that receives the comparison data.</param>
		/// <param name="cbMax">The length of the buffer specified in pbData.</param>
		/// <param name="pcbData">A pointer to a variable that receives the length of the comparison data.</param>
		/// <returns>This method can return the standard return values E_OUTOFMEMORY and S_OK.</returns>
		/// <remarks>
		/// <para>
		/// The <c>GetComparisonData</c> method is primarily called by the running object table (ROT). The comparison data returned by
		/// the method is tested for binary equality against the comparison data returned by another moniker. The pcbData parameter
		/// enables the ROT to locate the end of the data retrieved.
		/// </para>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// The comparison data that you return must uniquely identify the moniker, while still being as short as possible. The
		/// comparison data should include information about the internal state of the moniker, as well as the moniker's CLSID. For
		/// example, the comparison data for a file moniker would include the path name stored within the moniker, as well as the CLSID
		/// of the file moniker implementation. This makes it possible to distinguish two monikers that happen to store similar state
		/// information but are instances of different moniker classes.
		/// </para>
		/// <para>
		/// The comparison data for a moniker cannot exceed 2048 bytes in length. For composite monikers, the total length of the
		/// comparison data for all of its components cannot exceed 2048 bytes; consequently, if your moniker can be a component within
		/// a composite moniker, the comparison data you return must be significantly less than 2048 bytes.
		/// </para>
		/// <para>
		/// If your comparison data is longer than the value specified by the cbMax parameter, you must return an error. Note that when
		/// <c>GetComparisonData</c> is called on the components of a composite moniker, the value of cbMax becomes smaller for each
		/// moniker in sequence.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-irotdata-getcomparisondata HRESULT GetComparisonData(
		// byte *pbData, ULONG cbMax, ULONG *pcbData );
		[PreserveSig]
		HRESULT GetComparisonData([Out] IntPtr pbData, uint cbMax, out uint pcbData);
	}

	/// <summary>
	/// Enables a container to control the running of its embedded objects. In the case of an object implemented with a local server,
	/// calling the Run method launches the server's .EXE file. In the case of an object implemented with an in-process server, calling
	/// <c>Run</c> causes the object .DLL file to transition into the running state.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nn-objidl-irunnableobject
	[PInvokeData("objidl.h", MSDNShortId = "NN:objidl.IRunnableObject")]
	[ComImport, Guid("00000126-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IRunnableObject
	{
		/// <summary>Retrieves the CLSID of a running object.</summary>
		/// <param name="lpClsid">A pointer to the object's class identifier.</param>
		/// <returns>This method can return the standard return values E_INVALIDARG, E_UNEXPECTED, and S_OK.</returns>
		/// <remarks>
		/// If an embedded document was created by an application that is not available on the user's computer, the document, by a call
		/// to CoTreatAsClass, may be able to display itself for editing by emulating a class that is supported on the user's machine.
		/// In this case, the CLSID returned by a call to <c>IRunnableObject::GetRunningClass</c> will be that of the class being
		/// emulated, rather than the document's native class.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-irunnableobject-getrunningclass HRESULT GetRunningClass(
		// LPCLSID lpClsid );
		[PreserveSig]
		HRESULT GetRunningClass(out Guid lpClsid);

		/// <summary>Forces an object to run.</summary>
		/// <param name="pbc">A pointer to the binding context of the run operation. See IBindCtx. This parameter can be <c>NULL</c>.</param>
		/// <returns>This method can return the standard return values E_INVALIDARG, E_UNEXPECTED, and S_OK.</returns>
		/// <remarks>
		/// <para>
		/// Containers call <c>IRunnableObject::Run</c> to force their objects to enter the running state. If the object is not already
		/// running, calling <c>Run</c> can be an expensive operation, on the order of many seconds. If the object is already running,
		/// then this method has no effect on the object.
		/// </para>
		/// <para>Notes to Callers</para>
		/// <para>
		/// When called on a linked object that has been converted to a new class since the link was last activated,
		/// <c>IRunnableObject::Run</c> may return OLE_E_CLASSDIFF. In this case, the client should call IOleLink::BindToSource.
		/// </para>
		/// <para>
		/// OleRun is a helper function that conveniently repackages the functionality offered by <c>IRunnableObject::Run</c>. With the
		/// release of OLE 2.01, the implementation of <c>OleRun</c> was changed so that it calls QueryInterface, asks for
		/// IRunnableObject, and then calls <c>IRunnableObject::Run</c>. In other words, you can use the interface and the helper
		/// function interchangeably.
		/// </para>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// The object should register in the running object table if it has a moniker assigned. The object should not hold any strong
		/// locks on itself; instead, it should remain in the unstable, unlocked state. The object should be locked when the first
		/// external connection is made to the object.
		/// </para>
		/// <para>
		/// An embedded object must hold a lock on its embedding container while it is in the running state. The default handler
		/// provided by OLE 2 takes care of locking the embedding container on behalf of objects implemented by an EXE object
		/// application. Objects implemented by a DLL object application must explicitly put a lock on their embedding containers, which
		/// they do by first calling IOleClientSite::GetContainer to get a pointer to the container, then calling
		/// IOleContainer::LockContainer to actually place the lock. This lock must be released when IOleObject::Close is called.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-irunnableobject-run HRESULT Run( LPBINDCTX pbc );
		[PreserveSig]
		HRESULT Run(IBindCtx? pbc);

		/// <summary>Determines whether an object is currently in the running state.</summary>
		/// <returns>If the object is in the running state, the return value is <c>TRUE</c>. Otherwise, it is <c>FALSE</c>.</returns>
		/// <remarks>
		/// <para>
		/// A container application could call <c>IRunnableObject::IsRunning</c> when it needs to know if the server is immediately
		/// available. For example, a container's implementation of the IOleItemContainer::GetObject method would return an error if the
		/// server is not running and the bindspeed parameter specifies BINDSPEED_IMMEDIATE.
		/// </para>
		/// <para>
		/// An object handler could call <c>IRunnableObject::IsRunning</c> when it wants to avoid conflicts with a running server or
		/// when the running server might have more up-to-date information. For example, a handler's implementation of
		/// IOleObject::GetExtent would delegate to the object server if it is running, because the server's information might be more
		/// current than that in the handler's cache.
		/// </para>
		/// <para>
		/// OleIsRunning is a helper function that conveniently repackages the functionality offered by
		/// <c>IRunnableObject::IsRunning</c>. With the release of OLE 2.01, the implementation of <c>OleIsRunning</c> was changed so
		/// that it calls QueryInterface, asks for IRunnableObject, and then calls <c>IRunnableObject::IsRunning</c>. In other words,
		/// you can use the interface and the helper function interchangeably.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-irunnableobject-isrunning BOOL IsRunning();
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.Bool)]
		bool IsRunning();

		/// <summary>Locks an already running object into its running state or unlocks it from its running state.</summary>
		/// <param name="fLock">
		/// <c>TRUE</c> locks the object into its running state. <c>FALSE</c> unlocks the object from its running state.
		/// </param>
		/// <param name="fLastUnlockCloses">
		/// <c>TRUE</c> specifies that if the connection being released is the last external lock on the object, the object should
		/// close. <c>FALSE</c> specifies that the object should remain open until closed by the user or another process.
		/// </param>
		/// <returns>This method can return the standard return values E_INVALIDARG, E_OUTOFMEMORY, E_UNEXPECTED, E_FAIL, and S_OK.</returns>
		/// <remarks>
		/// <para>Most implementations of <c>IRunnableObject::LockRunning</c> call CoLockObjectExternal.</para>
		/// <para>
		/// OleLockRunning is a helper function that conveniently repackages the functionality offered by
		/// <c>IRunnableObject::LockRunning</c>. With the release of OLE 2.01, the implementation of <c>OleLockRunning</c> was changed
		/// to call QueryInterface, ask for IRunnableObject, and then call <c>IRunnableObject::LockRunning</c>. In other words, you can
		/// use the interface and the helper function interchangeably.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-irunnableobject-lockrunning HRESULT LockRunning( BOOL
		// fLock, BOOL fLastUnlockCloses );
		[PreserveSig]
		HRESULT LockRunning([MarshalAs(UnmanagedType.Bool)] bool fLock, [MarshalAs(UnmanagedType.Bool)] bool fLastUnlockCloses);

		/// <summary>
		/// Notifies an object that it is embedded in an OLE container, which ensures that reference counting is done correctly for
		/// containers that support links to embedded objects.
		/// </summary>
		/// <param name="fContained">
		/// <c>TRUE</c> specifies that the object is contained in an OLE container. <c>FALSE</c> indicates that it is not.
		/// </param>
		/// <returns>This method can return the standard return values E_INVALIDARG, E_OUTOFMEMORY, E_UNEXPECTED, and S_OK.</returns>
		/// <remarks>
		/// <para>
		/// The <c>SetContainedObject</c> method enables a container to inform an object handler that it is embedded in the container,
		/// rather than acting as a link. This call changes the container's reference on the object from strong, the default for
		/// external connections, to weak. When the object is running visibly, this method is of little significance because the end
		/// user has a lock on the object. During a silent update of an embedded link source, however, the container should not be able
		/// to hold an object in the running state after the link has been broken. For this reason, the container's reference to the
		/// object must be weak.
		/// </para>
		/// <para>Notes to Callers</para>
		/// <para>
		/// A container application must call <c>SetContainedObject</c> if it supports linking to embedded objects. It normally makes
		/// the call immediately after calling OleLoad or OleCreate and never calls the method again, even before it closes. Moreover, a
		/// container almost always calls this method with fContained set to <c>TRUE</c>. The use of this method with fContained set to
		/// <c>FALSE</c> is rare.
		/// </para>
		/// <para>
		/// Calling <c>SetContainedObject</c> is optional only when you know that the embedded object will not be referenced by any
		/// client other than the container. If your container application does not support linking to embedded objects; it is
		/// preferable, but not necessary, to call <c>SetContainedObject</c>.
		/// </para>
		/// <para>
		/// OleSetContainedObject is a helper function that conveniently repackages the functionality offered by
		/// <c>SetContainedObject</c>. With the release of OLE 2.01, the implementation of <c>OleSetContainedObject</c> was changed to
		/// call QueryInterface, ask for IRunnableObject, and then call <c>IRunnableObject::SetContainedObject</c>. In other words, you
		/// can use the interface and the helper function interchangeably.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-irunnableobject-setcontainedobject HRESULT
		// SetContainedObject( BOOL fContained );
		[PreserveSig]
		HRESULT SetContainedObject([MarshalAs(UnmanagedType.Bool)] bool fContained);
	}
}