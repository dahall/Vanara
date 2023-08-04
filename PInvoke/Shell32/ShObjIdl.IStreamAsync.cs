using System.Runtime.InteropServices.ComTypes;
using System.Threading;

using STATSTG = System.Runtime.InteropServices.ComTypes.STATSTG;

namespace Vanara.PInvoke;

public static partial class Shell32
{
	/// <summary>Exposes methods to manage input/outpout (I/O) to an asynchronous stream.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nn-shobjidl-istreamasync
	[ComImport, Guid("fe0b6665-e0ca-49b9-a178-2b5cb48d92a5"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public unsafe interface IStreamAsync : IStream
	{
		/// <inheritdoc/>
		new void Read(byte[] pv, int cb, IntPtr pcbRead);

		/// <inheritdoc/>
		new void Write(byte[] pv, int cb, IntPtr pcbWritten);

		/// <inheritdoc/>
		new void Seek(long dlibMove, int dwOrigin, IntPtr plibNewPosition);

		/// <inheritdoc/>
		new void SetSize(long libNewSize);

		/// <inheritdoc/>
		new void CopyTo(IStream pstm, long cb, IntPtr pcbRead, IntPtr pcbWritten);

		/// <inheritdoc/>
		new void Commit(int grfCommitFlags);

		/// <inheritdoc/>
		new void Revert();

		/// <inheritdoc/>
		new void LockRegion(long libOffset, long cb, int dwLockType);

		/// <inheritdoc/>
		new void UnlockRegion(long libOffset, long cb, int dwLockType);

		/// <inheritdoc/>
		new void Stat(out STATSTG pstatstg, int grfStatFlag);

		/// <inheritdoc/>
		new void Clone(out IStream ppstm);

		/// <summary>
		/// Reads information from a stream asynchronously. For example, the Shell implements this interface on file items when
		/// transferring them asynchronously.
		/// </summary>
		/// <param name="pv">
		/// <para>Type: <c>void*</c></para>
		/// <para>
		/// When this method returns successfully, returns a buffer that is cb bytes long and contains pcbRead bytes of information from
		/// the read operation.
		/// </para>
		/// </param>
		/// <param name="cb">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The number of bytes to read from the stream.</para>
		/// </param>
		/// <param name="pcbRead">
		/// <para>Type: <c>LPDWORD</c></para>
		/// <para>
		/// Pointer to a <c>DWORD</c> value that, when this method returns successfully, states the actual number of bytes read to the
		/// buffer pointed to by pv. This value can be <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="lpOverlapped">
		/// <para>Type: <c>LPOVERLAPPED</c></para>
		/// <para>A pointer to an OVERLAPPED structure that contains information used in the asynchronous read operation.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// <c>IStreamAsync::ReadAsync</c> should reset the event specified by the <c>hEvent</c> member of the OVERLAPPED structure to a
		/// nonsignaled state when it begins the input/output (I/O) operation.
		/// </para>
		/// <para>This method has been implemented in the Shell as a thin wrapper around the public ReadFile API.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-istreamasync-readasync HRESULT ReadAsync( void *pv,
		// DWORD cb, LPDWORD pcbRead, LPOVERLAPPED lpOverlapped );
		void ReadAsync([Out] IntPtr pv, uint cb, out uint pcbRead, [In] NativeOverlapped* lpOverlapped);

		/// <summary>
		/// Writes information to a stream asynchronously. For example, the Shell implements this method on file items when transferring
		/// them asynchronously.
		/// </summary>
		/// <param name="lpBuffer">
		/// <para>Type: <c>const void*</c></para>
		/// <para>A pointer to a buffer of size cb bytes that contains the information to be written to the stream.</para>
		/// </param>
		/// <param name="cb">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The size of the buffer pointed to by lpBuffer, in bytes.</para>
		/// </param>
		/// <param name="pcbWritten">
		/// <para>Type: <c>LPDWORD</c></para>
		/// <para>
		/// Pointer to a <c>DWORD</c> value that, when the method returns successfully, states the actual number of bytes written to the
		/// stream. This value can be <c>NULL</c> if this information is not needed.
		/// </para>
		/// </param>
		/// <param name="lpOverlapped">
		/// <para>Type: <c>LPOVERLAPPED</c></para>
		/// <para>A pointer to an OVERLAPPED structure that contains information used in the asynchronous write operation.</para>
		/// </param>
		/// <remarks>
		/// <c>WriteAsync</c> should reset the event specified by the <c>hEvent</c> member of the OVERLAPPED structure to a nonsignaled
		/// state when it begins the input/output (I/O) operation.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-istreamasync-writeasync HRESULT WriteAsync( const
		// void *lpBuffer, DWORD cb, LPDWORD pcbWritten, LPOVERLAPPED lpOverlapped );
		void WriteAsync([In] IntPtr lpBuffer, uint cb, out uint pcbWritten, [In] NativeOverlapped* lpOverlapped);

		/// <summary>Retrieves the results of an overlapped operation.</summary>
		/// <param name="lpOverlapped">
		/// <para>Type: <c>LPOVERLAPPED*</c></para>
		/// <para>A pointer to the OVERLAPPED structure that was specified when the overlapped operation was started.</para>
		/// </param>
		/// <param name="lpNumberOfBytesTransferred">
		/// <para>Type: <c>LPDWORD</c></para>
		/// <para>When this method returns, contains the number of bytes that were actually transferred by a read or write operation.</para>
		/// </param>
		/// <param name="bWait">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// If <c>TRUE</c> the method does not return until the operation has been completed. If <c>FALSE</c> and an operation is
		/// pending, the method returns the HRESULT equivalent to ERROR_IO_INCOMPLETE.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-istreamasync-overlappedresult HRESULT
		// OverlappedResult( LPOVERLAPPED lpOverlapped, LPDWORD lpNumberOfBytesTransferred, BOOL bWait );
		void OverlappedResult([In] NativeOverlapped* lpOverlapped, out uint lpNumberOfBytesTransferred, [MarshalAs(UnmanagedType.Bool)] bool bWait);

		/// <summary>Marks all pending input/output (I/O) operations as canceled.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-istreamasync-cancelio HRESULT CancelIo();
		void CancelIo();
	}

	/// <summary>Exposes a method that determines the sector size as an aid to byte alignment.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nn-shobjidl-istreamunbufferedinfo
	[PInvokeData("shobjidl.h", MSDNShortId = "NN:shobjidl.IStreamUnbufferedInfo")]
	[ComImport, Guid("8a68fdda-1fdc-4c20-8ceb-416643b5a625"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IStreamUnbufferedInfo
	{
		/// <summary>
		/// Retrieves the number of bytes per sector on the disk currently being used. When using unbuffered input/output (I/O), it is
		/// important to know the size of the sectors on the disk being read in order to ensure proper byte alignment.
		/// </summary>
		/// <param name="pcbSectorSize">
		/// <para>Type: <c>ULONG*</c></para>
		/// <para>
		/// When this method returns successfully, contains a pointer to a <c>ULONG</c> value that represents the number of bytes per
		/// sector for the disk.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-istreamunbufferedinfo-getsectorsize HRESULT
		// GetSectorSize( ULONG *pcbSectorSize );
		[PreserveSig]
		HRESULT GetSectorSize(out uint pcbSectorSize);
	}
}