namespace Vanara.PInvoke;

public static partial class Kernel32
{
	/// <summary>Represents feature support for the an I/O ring API version.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ntioring_x/ne-ntioring_x-ioring_feature_flags typedef enum
	// IORING_FEATURE_FLAGS { IORING_FEATURE_FLAGS_NONE, IORING_FEATURE_UM_EMULATION, IORING_FEATURE_SET_COMPLETION_EVENT } ;
	[PInvokeData("ntioring_x.h", MSDNShortId = "NE:ntioring_x.IORING_FEATURE_FLAGS")]
	[Flags]
	public enum IORING_FEATURE_FLAGS
	{
		/// <summary>None.</summary>
		IORING_FEATURE_FLAGS_NONE = 0,

		/// <summary>
		/// I/O ring support is emulated in User Mode. When this flag is set there is no underlying kernel support for I/O ring.
		/// However, a user mode emulation layer is available to provide application compatibility, without the benefit of kernel
		/// support. This provides application compatibility at the expense of performance, allowing apps to make a choice at run-time.
		/// As of the current release, Microsoft does not provide an emulated I/O ring implementation. This value is provided to support
		/// potential emulated future emulated implementations.
		/// </summary>
		IORING_FEATURE_UM_EMULATION = 0x00000001,

		/// <summary>If this flag is present the IoRingSetCompletionEvent API is available and supported</summary>
		IORING_FEATURE_SET_COMPLETION_EVENT = 0x00000002,
	}

	/// <summary>Specifies the type of an I/O ring operation.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ntioring_x/ne-ntioring_x-ioring_op_code typedef enum IORING_OP_CODE {
	// IORING_OP_NOP, IORING_OP_READ, IORING_OP_REGISTER_FILES, IORING_OP_REGISTER_BUFFERS, IORING_OP_CANCEL } ;
	[PInvokeData("ntioring_x.h", MSDNShortId = "NE:ntioring_x.IORING_OP_CODE")]
	public enum IORING_OP_CODE
	{
		/// <summary>No operation. This value is provided to enable testing queue management and overhead performance./</summary>
		IORING_OP_NOP,

		/// <summary>Read from a file to a buffer.</summary>
		IORING_OP_READ,

		/// <summary>
		/// <para>Register an array of file handles with the I/O ring.</para>
		/// <para>
		/// If any existing registration exists, it is completely replaced by the registration for this opcode. Any entries in the array
		/// with INVALID_HANDLE_VALUE are sparse entries and are not used, which can be used to release one or more of the previously
		/// registered files.
		/// </para>
		/// <para>
		/// Unregistration of all current files is accomplished by providing a zero length array. The input array must remain valid
		/// until the operation completes. The change impacts all entries in the queue after this completes. I.e. This implicitly has
		/// "link" semantics in that any subsequent entry will not start until after this is completed.
		/// </para>
		/// </summary>
		IORING_OP_REGISTER_FILES,

		/// <summary>
		/// <para>Register an array of</para>
		/// <para>IORING_BUFFER_INFO</para>
		/// <para>with the IORING.</para>
		/// <para>
		/// If any existing registration exists, it is completely replaced by the registration for this opcode. Any entries in the array
		/// with INVALID_HANDLE_VALUE are sparse entries and are not used, which can be used to release one or more of the previously
		/// registered files.
		/// </para>
		/// <para>
		/// Unregistration of all current files is accomplished by providing a zero length array. The input array must remain valid
		/// until the operation completes. The change impacts all entries in the queue after this completes. I.e. This implicitly has
		/// "link" semantics in that any subsequent entry will not start until after this is completed.
		/// </para>
		/// </summary>
		IORING_OP_REGISTER_BUFFERS,

		/// <summary>
		/// <para>Request cancellation of a previously submitted operation. The</para>
		/// <para>UserData</para>
		/// <para>
		/// passed in when the operation was initiated is used to identify the operation to be cancelled. The cancellation operation
		/// completes after the canceled operation completes unless there is an error attempting the cancellation. For example, if no
		/// operation is found with the specified
		/// </para>
		/// <para>UserData</para>
		/// <para>.</para>
		/// </summary>
		IORING_OP_CANCEL,
	}

	/// <summary>Specifies the I/O ring API version.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ntioring_x/ne-ntioring_x-ioring_version typedef enum IORING_VERSION {
	// IORING_VERSION_INVALID, IORING_VERSION_1 } ;
	[PInvokeData("ntioring_x.h", MSDNShortId = "NE:ntioring_x.IORING_VERSION")]
	public enum IORING_VERSION
	{
		/// <summary>Invalid version.</summary>
		IORING_VERSION_INVALID = 0,

		/// <summary>Version 1.</summary>
		IORING_VERSION_1,
	}

	/// <summary>Represents a data buffer that can be registered with an I/O ring.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ntioring_x/ns-ntioring_x-ioring_buffer_info typedef struct IORING_BUFFER_INFO
	// { void *Address; UINT32 Length; } IORING_BUFFER_INFO;
	[PInvokeData("ntioring_x.h", MSDNShortId = "NS:ntioring_x.IORING_BUFFER_INFO")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IORING_BUFFER_INFO
	{
		/// <summary>A <c>VOID</c> pointer representing the address of the data buffer.</summary>
		public IntPtr Address;

		/// <summary>The length of the data buffer, in bytes.</summary>
		public uint Length;
	}

	/// <summary>Represents a buffer that has been registered with an I/O ring with a call to BuildIoRingRegisterBuffers.</summary>
	/// <remarks>
	/// By using both a buffer index within the submission queue and an offset within the buffer, you can use large buffers and schedule
	/// multiple I/O ring operations within the same buffer to be performed asynchronously.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ntioring_x/ns-ntioring_x-ioring_registered_buffer typedef struct
	// IORING_REGISTERED_BUFFER { UINT32 BufferIndex; UINT32 Offset; } IORING_REGISTERED_BUFFER;
	[PInvokeData("ntioring_x.h", MSDNShortId = "NS:ntioring_x.IORING_REGISTERED_BUFFER")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IORING_REGISTERED_BUFFER
	{
		/// <summary>A <c>UINT32</c> specifying the index of the registered buffer.</summary>
		public uint BufferIndex;

		/// <summary>A <c>UINT32</c> specifying the offset into the registered buffer.</summary>
		public uint Offset;
	}
}