using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Kernel32
	{
		/// <summary>Used by HEAPENTRY32</summary>
		[PInvokeData("tlhelp32.h", MSDNShortId = "c5f1dc66-d44f-4491-b0b7-961b163d0f1f")]
		[Flags]
		public enum HEAPENTRY32_FLAGS
		{
			/// <summary>The memory block has a fixed (unmovable) location.</summary>
			LF32_FIXED = 0x00000001,

			/// <summary>The memory block is not used.</summary>
			LF32_FREE = 0x00000002,

			/// <summary>The memory block location can be moved.</summary>
			LF32_MOVEABLE = 0x00000004,
		}

		/// <summary>Used by HEAPLIST32</summary>
		[PInvokeData("tlhelp32.h", MSDNShortId = "61e01d23-9f15-44c5-9f6d-45df4809ccad")]
		[Flags]
		public enum HEAPLIST32_FLAGS
		{
			/// <summary>Process's default heap</summary>
			HF32_DEFAULT = 1,

			/// <summary>Process's shared heap</summary>
			HF32_SHARED = 2
		}

		/// <summary>Flags used by <see cref="CreateToolhelp32Snapshot"/>.</summary>
		[PInvokeData("tlhelp32.h", MSDNShortId = "df643c25-7558-424c-b187-b3f86ba51358")]
		public enum TH32CS : uint
		{
			/// <summary>Indicates that the snapshot handle is to be inheritable.</summary>
			TH32CS_INHERIT = 0x80000000,

			/// <summary>Includes all heaps of the process specified in th32ProcessID in the snapshot. To enumerate the heaps, see Heap32ListFirst.</summary>
			TH32CS_SNAPHEAPLIST = 0x00000001,

			/// <summary>
			/// Includes all modules of the process specified in th32ProcessID in the snapshot. To enumerate the modules, see Module32First.
			/// If the function fails with ERROR_BAD_LENGTH, retry the function until it succeeds.
			/// <para>
			/// 64-bit Windows: Using this flag in a 32-bit process includes the 32-bit modules of the process specified in th32ProcessID,
			/// while using it in a 64-bit process includes the 64-bit modules. To include the 32-bit modules of the process specified in
			/// th32ProcessID from a 64-bit process, use the TH32CS_SNAPMODULE32 flag.
			/// </para>
			/// </summary>
			TH32CS_SNAPMODULE = 0x00000008,

			/// <summary>
			/// Includes all 32-bit modules of the process specified in th32ProcessID in the snapshot when called from a 64-bit process. This
			/// flag can be combined with TH32CS_SNAPMODULE or TH32CS_SNAPALL. If the function fails with ERROR_BAD_LENGTH, retry the
			/// function until it succeeds.
			/// </summary>
			TH32CS_SNAPMODULE32 = 0x00000010,

			/// <summary>Includes all processes in the system in the snapshot. To enumerate the processes, see Process32First.</summary>
			TH32CS_SNAPPROCESS = 0x00000002,

			/// <summary>
			/// Includes all threads in the system in the snapshot. To enumerate the threads, see Thread32First.
			/// <para>
			/// To identify the threads that belong to a specific process, compare its process identifier to the th32OwnerProcessID member of
			/// the THREADENTRY32 structure when enumerating the threads.
			/// </para>
			/// </summary>
			TH32CS_SNAPTHREAD = 0x00000004,

			/// <summary>
			/// Includes all processes and threads in the system, plus the heaps and modules of the process specified in th32ProcessID.
			/// Equivalent to specifying the TH32CS_SNAPHEAPLIST, TH32CS_SNAPMODULE, TH32CS_SNAPPROCESS, and TH32CS_SNAPTHREAD values
			/// combined using an OR operation ('|').
			/// </summary>
			TH32CS_SNAPALL = (TH32CS_SNAPHEAPLIST | TH32CS_SNAPPROCESS | TH32CS_SNAPTHREAD | TH32CS_SNAPMODULE),
		}

		/// <summary>
		/// <para>Takes a snapshot of the specified processes, as well as the heaps, modules, and threads used by these processes.</para>
		/// </summary>
		/// <param name="dwFlags">
		/// <para>The portions of the system to be included in the snapshot. This parameter can be one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TH32CS_INHERIT 0x80000000</term>
		/// <term>Indicates that the snapshot handle is to be inheritable.</term>
		/// </item>
		/// <item>
		/// <term>TH32CS_SNAPALL</term>
		/// <term>
		/// Includes all processes and threads in the system, plus the heaps and modules of the process specified in . Equivalent to
		/// specifying the TH32CS_SNAPHEAPLIST, TH32CS_SNAPMODULE, TH32CS_SNAPPROCESS, and TH32CS_SNAPTHREAD values combined using an OR
		/// operation ('|').
		/// </term>
		/// </item>
		/// <item>
		/// <term>TH32CS_SNAPHEAPLIST 0x00000001</term>
		/// <term>Includes all heaps of the process specified in in the snapshot. To enumerate the heaps, see Heap32ListFirst.</term>
		/// </item>
		/// <item>
		/// <term>TH32CS_SNAPMODULE 0x00000008</term>
		/// <term>
		/// Includes all modules of the process specified in in the snapshot. To enumerate the modules, see Module32First. If the function
		/// fails with ERROR_BAD_LENGTH, retry the function until it succeeds. 64-bit Windows: Using this flag in a 32-bit process includes
		/// the 32-bit modules of the process specified in , while using it in a 64-bit process includes the 64-bit modules. To include the
		/// 32-bit modules of the process specified in from a 64-bit process, use the TH32CS_SNAPMODULE32 flag.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TH32CS_SNAPMODULE32 0x00000010</term>
		/// <term>
		/// Includes all 32-bit modules of the process specified in in the snapshot when called from a 64-bit process. This flag can be
		/// combined with TH32CS_SNAPMODULE or TH32CS_SNAPALL. If the function fails with ERROR_BAD_LENGTH, retry the function until it succeeds.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TH32CS_SNAPPROCESS 0x00000002</term>
		/// <term>Includes all processes in the system in the snapshot. To enumerate the processes, see Process32First.</term>
		/// </item>
		/// <item>
		/// <term>TH32CS_SNAPTHREAD 0x00000004</term>
		/// <term>
		/// Includes all threads in the system in the snapshot. To enumerate the threads, see Thread32First. To identify the threads that
		/// belong to a specific process, compare its process identifier to the th32OwnerProcessID member of the THREADENTRY32 structure when
		/// enumerating the threads.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="th32ProcessID">
		/// <para>
		/// The process identifier of the process to be included in the snapshot. This parameter can be zero to indicate the current process.
		/// This parameter is used when the <c>TH32CS_SNAPHEAPLIST</c>, <c>TH32CS_SNAPMODULE</c>, <c>TH32CS_SNAPMODULE32</c>, or
		/// <c>TH32CS_SNAPALL</c> value is specified. Otherwise, it is ignored and all processes are included in the snapshot.
		/// </para>
		/// <para>
		/// If the specified process is the Idle process or one of the CSRSS processes, this function fails and the last error code is
		/// <c>ERROR_ACCESS_DENIED</c> because their access restrictions prevent user-level code from opening them.
		/// </para>
		/// <para>
		/// If the specified process is a 64-bit process and the caller is a 32-bit process, this function fails and the last error code is
		/// <c>ERROR_PARTIAL_COPY</c> (299).
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, it returns an open handle to the specified snapshot.</para>
		/// <para>
		/// If the function fails, it returns <c>INVALID_HANDLE_VALUE</c>. To get extended error information, call GetLastError. Possible
		/// error codes include <c>ERROR_BAD_LENGTH</c>.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The snapshot taken by this function is examined by the other tool help functions to provide their results. Access to the snapshot
		/// is read only. The snapshot handle acts as an object handle and is subject to the same rules regarding which processes and threads
		/// it is valid in.
		/// </para>
		/// <para>
		/// To enumerate the heap or module states for all processes, specify <c>TH32CS_SNAPALL</c> and set to zero. Then, for each
		/// additional process in the snapshot, call <c>CreateToolhelp32Snapshot</c> again, specifying its process identifier and the
		/// <c>TH32CS_SNAPHEAPLIST</c> or <c>TH32_SNAPMODULE</c> value.
		/// </para>
		/// <para>
		/// When taking snapshots that include heaps and modules for a process other than the current process, the
		/// <c>CreateToolhelp32Snapshot</c> function can fail or return incorrect information for a variety of reasons. For example, if the
		/// loader data table in the target process is corrupted or not initialized, or if the module list changes during the function call
		/// as a result of DLLs being loaded or unloaded, the function might fail with <c>ERROR_BAD_LENGTH</c> or other error code. Ensure
		/// that the target process was not started in a suspended state, and try calling the function again. If the function fails with
		/// <c>ERROR_BAD_LENGTH</c> when called with <c>TH32CS_SNAPMODULE</c> or <c>TH32CS_SNAPMODULE32</c>, call the function again until it succeeds.
		/// </para>
		/// <para>
		/// The <c>TH32CS_SNAPMODULE</c> and <c>TH32CS_SNAPMODULE32</c> flags do not retrieve handles for modules that were loaded with the
		/// <c>LOAD_LIBRARY_AS_DATAFILE</c> or similar flags. For more information, see LoadLibraryEx.
		/// </para>
		/// <para>To destroy the snapshot, use the CloseHandle function.</para>
		/// <para>
		/// Note that you can use the QueryFullProcessImageName function to retrieve the full name of an executable image for both 32- and
		/// 64-bit processes from a 32-bit process.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Taking a Snapshot and Viewing Processes.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/tlhelp32/nf-tlhelp32-createtoolhelp32snapshot HANDLE
		// CreateToolhelp32Snapshot( DWORD dwFlags, DWORD th32ProcessID );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("tlhelp32.h", MSDNShortId = "df643c25-7558-424c-b187-b3f86ba51358")]
		public static extern SafeHSNAPSHOT CreateToolhelp32Snapshot(TH32CS dwFlags, uint th32ProcessID);

		/// <summary>
		/// <para>Retrieves information about the first block of a heap that has been allocated by a process.</para>
		/// </summary>
		/// <param name="lphe">
		/// <para>A pointer to a HEAPENTRY32 structure.</para>
		/// </param>
		/// <param name="th32ProcessID">
		/// <para>The identifier of the process context that owns the heap.</para>
		/// </param>
		/// <param name="th32HeapID">
		/// <para>The identifier of the heap to be enumerated.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// Returns <c>TRUE</c> if information for the first heap block has been copied to the buffer or <c>FALSE</c> otherwise. The
		/// <c>ERROR_NO_MORE_FILES</c> error value is returned by the GetLastError function if the heap is invalid or empty.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The calling application must set the <c>dwSize</c> member of HEAPENTRY32 to the size, in bytes, of the structure.
		/// <c>Heap32First</c> changes <c>dwSize</c> to the number of bytes written to the structure. This will never be greater than the
		/// initial value of <c>dwSize</c>, but it may be smaller. If the value is smaller, do not rely on the values of any members whose
		/// offsets are greater than this value.
		/// </para>
		/// <para>To access subsequent blocks of the same heap, use the Heap32Next function.</para>
		/// <para>Examples</para>
		/// <para>For an example, see Traversing the Heap List.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/tlhelp32/nf-tlhelp32-heap32first BOOL Heap32First( LPHEAPENTRY32 lphe, DWORD
		// th32ProcessID, ULONG_PTR th32HeapID );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("tlhelp32.h", MSDNShortId = "79d01e3a-b11b-46b5-99d0-b445000288a7")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool Heap32First(ref HEAPENTRY32 lphe, uint th32ProcessID, UIntPtr th32HeapID);

		/// <summary>
		/// <para>Retrieves information about the first heap that has been allocated by a specified process.</para>
		/// </summary>
		/// <param name="hSnapshot">
		/// <para>A handle to the snapshot returned from a previous call to the CreateToolhelp32Snapshot function.</para>
		/// </param>
		/// <param name="lphl">
		/// <para>A pointer to a HEAPLIST32 structure.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// Returns <c>TRUE</c> if the first entry of the heap list has been copied to the buffer or <c>FALSE</c> otherwise. The
		/// <c>ERROR_NO_MORE_FILES</c> error value is returned by the GetLastError function when no heap list exists or the snapshot does not
		/// contain heap list information.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The calling application must set the <c>dwSize</c> member of HEAPLIST32 to the size, in bytes, of the structure.
		/// <c>Heap32ListFirst</c> changes <c>dwSize</c> to the number of bytes written to the structure. This will never be greater than the
		/// initial value of <c>dwSize</c>, but it may be smaller. If the value is smaller, do not rely on the values of any members whose
		/// offsets are greater than this value.
		/// </para>
		/// <para>To retrieve information about other heaps in the heap list, use the Heap32ListNext function.</para>
		/// <para>Examples</para>
		/// <para>For an example, see Traversing the Heap List.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/tlhelp32/nf-tlhelp32-heap32listfirst BOOL Heap32ListFirst( HANDLE hSnapshot,
		// LPHEAPLIST32 lphl );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("tlhelp32.h", MSDNShortId = "b9a2992b-0dc1-41c3-aa23-796def674831")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool Heap32ListFirst(HSNAPSHOT hSnapshot, ref HEAPLIST32 lphl);

		/// <summary>
		/// <para>Retrieves information about the next heap that has been allocated by a process.</para>
		/// </summary>
		/// <param name="hSnapshot">
		/// <para>A handle to the snapshot returned from a previous call to the CreateToolhelp32Snapshot function.</para>
		/// </param>
		/// <param name="lphl">
		/// <para>A pointer to a HEAPLIST32 structure.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// Returns <c>TRUE</c> if the next entry of the heap list has been copied to the buffer or <c>FALSE</c> otherwise. The
		/// <c>ERROR_NO_MORE_FILES</c> error value is returned by the GetLastError function when no more entries in the heap list exist.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>To retrieve information about the first heap in a heap list, use the Heap32ListFirst function.</para>
		/// <para>Examples</para>
		/// <para>For an example, see Traversing the Heap List.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/tlhelp32/nf-tlhelp32-heap32listnext BOOL Heap32ListNext( HANDLE hSnapshot,
		// LPHEAPLIST32 lphl );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("tlhelp32.h", MSDNShortId = "bb4d573c-a82f-48ac-be22-440d6a1d0c9c")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool Heap32ListNext(HSNAPSHOT hSnapshot, ref HEAPLIST32 lphl);

		/// <summary>
		/// <para>Retrieves information about the next block of a heap that has been allocated by a process.</para>
		/// </summary>
		/// <param name="lphe">
		/// <para>A pointer to a HEAPENTRY32 structure.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// Returns <c>TRUE</c> if information about the next block in the heap has been copied to the buffer or <c>FALSE</c> otherwise. The
		/// GetLastError function returns <c>ERROR_NO_MORE_FILES</c> when no more objects in the heap exist and <c>ERROR_INVALID_DATA</c> if
		/// the heap appears to be corrupt or is modified during the walk in such a way that <c>Heap32Next</c> cannot continue.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>To retrieve information for the first block of a heap, use the Heap32First function.</para>
		/// <para>
		/// The <c>Heap32Next</c> function does not maintain a reference to the target process. If the target process dies, the system may
		/// create a new process using the same process identifier. Therefore, the caller should maintain a reference to the target process
		/// as long as it is using <c>Heap32Next</c>.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Traversing the Heap List.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/tlhelp32/nf-tlhelp32-heap32next BOOL Heap32Next( LPHEAPENTRY32 lphe );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("tlhelp32.h", MSDNShortId = "cc3becd0-edba-47cf-ac2d-26a5d98390e7")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool Heap32Next(ref HEAPENTRY32 lphe);

		/// <summary>
		/// <para>Retrieves information about the first module associated with a process.</para>
		/// </summary>
		/// <param name="hSnapshot">
		/// <para>A handle to the snapshot returned from a previous call to the CreateToolhelp32Snapshot function.</para>
		/// </param>
		/// <param name="lpme">
		/// <para>A pointer to a MODULEENTRY32 structure.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// Returns <c>TRUE</c> if the first entry of the module list has been copied to the buffer or <c>FALSE</c> otherwise. The
		/// <c>ERROR_NO_MORE_FILES</c> error value is returned by the GetLastError function if no modules exist or the snapshot does not
		/// contain module information.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>The calling application must set the <c>dwSize</c> member of MODULEENTRY32 to the size, in bytes, of the structure.</para>
		/// <para>To retrieve information about other modules associated with the specified process, use the Module32Next function.</para>
		/// <para>Examples</para>
		/// <para>For an example, see Traversing the Module List.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/tlhelp32/nf-tlhelp32-module32first BOOL Module32First( HANDLE hSnapshot,
		// LPMODULEENTRY32 lpme );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("tlhelp32.h", MSDNShortId = "bb41cab9-13a1-469d-bf76-68c172e982f6")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool Module32First(HSNAPSHOT hSnapshot, out MODULEENTRY32 lpme);

		/// <summary>
		/// <para>Retrieves information about the next module associated with a process or thread.</para>
		/// </summary>
		/// <param name="hSnapshot">
		/// <para>A handle to the snapshot returned from a previous call to the CreateToolhelp32Snapshot function.</para>
		/// </param>
		/// <param name="lpme">
		/// <para>A pointer to a MODULEENTRY32 structure.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// Returns <c>TRUE</c> if the next entry of the module list has been copied to the buffer or <c>FALSE</c> otherwise. The
		/// <c>ERROR_NO_MORE_FILES</c> error value is returned by the GetLastError function if no more modules exist.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>To retrieve information about first module associated with a process, use the Module32First function.</para>
		/// <para>Examples</para>
		/// <para>For an example, see Traversing the Module List.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/tlhelp32/nf-tlhelp32-module32next BOOL Module32Next( HANDLE hSnapshot,
		// LPMODULEENTRY32 lpme );
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("tlhelp32.h", MSDNShortId = "88ec1af4-bae7-4cd7-b830-97a98fb337f4")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool Module32Next(HSNAPSHOT hSnapshot, out MODULEENTRY32 lpme);

		/// <summary>
		/// <para>Retrieves information about the first process encountered in a system snapshot.</para>
		/// </summary>
		/// <param name="hSnapshot">
		/// <para>A handle to the snapshot returned from a previous call to the CreateToolhelp32Snapshot function.</para>
		/// </param>
		/// <param name="lppe">
		/// <para>
		/// A pointer to a PROCESSENTRY32 structure. It contains process information such as the name of the executable file, the process
		/// identifier, and the process identifier of the parent process.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>
		/// Returns <c>TRUE</c> if the first entry of the process list has been copied to the buffer or <c>FALSE</c> otherwise. The
		/// <c>ERROR_NO_MORE_FILES</c> error value is returned by the GetLastError function if no processes exist or the snapshot does not
		/// contain process information.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>The calling application must set the <c>dwSize</c> member of PROCESSENTRY32 to the size, in bytes, of the structure.</para>
		/// <para>To retrieve information about other processes recorded in the same snapshot, use the Process32Next function.</para>
		/// <para>Examples</para>
		/// <para>For an example, see Taking a Snapshot and Viewing Processes.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/tlhelp32/nf-tlhelp32-process32first BOOL Process32First( HANDLE hSnapshot,
		// LPPROCESSENTRY32 lppe );
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("tlhelp32.h", MSDNShortId = "097790e8-30c2-4b00-9256-fa26e2ceb893")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool Process32First(HSNAPSHOT hSnapshot, ref PROCESSENTRY32 lppe);

		/// <summary>
		/// <para>Retrieves information about the next process recorded in a system snapshot.</para>
		/// </summary>
		/// <param name="hSnapshot">
		/// <para>A handle to the snapshot returned from a previous call to the CreateToolhelp32Snapshot function.</para>
		/// </param>
		/// <param name="lppe">
		/// <para>A pointer to a PROCESSENTRY32 structure.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// Returns <c>TRUE</c> if the next entry of the process list has been copied to the buffer or <c>FALSE</c> otherwise. The
		/// <c>ERROR_NO_MORE_FILES</c> error value is returned by the GetLastError function if no processes exist or the snapshot does not
		/// contain process information.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>To retrieve information about the first process recorded in a snapshot, use the Process32First function.</para>
		/// <para>Examples</para>
		/// <para>For an example, see Taking a Snapshot and Viewing Processes.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/tlhelp32/nf-tlhelp32-process32next BOOL Process32Next( HANDLE hSnapshot,
		// LPPROCESSENTRY32 lppe );
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("tlhelp32.h", MSDNShortId = "843a95fd-27ae-4215-83d0-82fc402b82b6")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool Process32Next(HSNAPSHOT hSnapshot, ref PROCESSENTRY32 lppe);

		/// <summary>
		/// <para>Retrieves information about the first thread of any process encountered in a system snapshot.</para>
		/// </summary>
		/// <param name="hSnapshot">
		/// <para>A handle to the snapshot returned from a previous call to the CreateToolhelp32Snapshot function.</para>
		/// </param>
		/// <param name="lpte">
		/// <para>A pointer to a THREADENTRY32 structure.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// Returns <c>TRUE</c> if the first entry of the thread list has been copied to the buffer or <c>FALSE</c> otherwise. The
		/// <c>ERROR_NO_MORE_FILES</c> error value is returned by the GetLastError function if no threads exist or the snapshot does not
		/// contain thread information.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The calling application must set the <c>dwSize</c> member of THREADENTRY32 to the size, in bytes, of the structure.
		/// <c>Thread32First</c> changes <c>dwSize</c> to the number of bytes written to the structure. This will never be greater than the
		/// initial value of <c>dwSize</c>, but it may be smaller. If the value is smaller, do not rely on the values of any members whose
		/// offsets are greater than this value.
		/// </para>
		/// <para>To retrieve information about other threads recorded in the same snapshot, use the Thread32Next function.</para>
		/// <para>Examples</para>
		/// <para>For an example, see Traversing the Thread List.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/tlhelp32/nf-tlhelp32-thread32first BOOL Thread32First( HANDLE hSnapshot,
		// LPTHREADENTRY32 lpte );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("tlhelp32.h", MSDNShortId = "d4cb7a19-850e-43b5-bda5-91be48382d2a")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool Thread32First(HSNAPSHOT hSnapshot, ref THREADENTRY32 lpte);

		/// <summary>
		/// <para>Retrieves information about the next thread of any process encountered in the system memory snapshot.</para>
		/// </summary>
		/// <param name="hSnapshot">
		/// <para>A handle to the snapshot returned from a previous call to the CreateToolhelp32Snapshot function.</para>
		/// </param>
		/// <param name="lpte">
		/// <para>A pointer to a THREADENTRY32 structure.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// Returns <c>TRUE</c> if the next entry of the thread list has been copied to the buffer or <c>FALSE</c> otherwise. The
		/// <c>ERROR_NO_MORE_FILES</c> error value is returned by the GetLastError function if no threads exist or the snapshot does not
		/// contain thread information.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>To retrieve information about the first thread recorded in a snapshot, use the Thread32First function.</para>
		/// <para>Examples</para>
		/// <para>For an example, see Traversing the Thread List.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/tlhelp32/nf-tlhelp32-thread32next BOOL Thread32Next( HANDLE hSnapshot,
		// LPTHREADENTRY32 lpte );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("tlhelp32.h", MSDNShortId = "5efe514e-626c-4138-97a0-bdad217c424f")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool Thread32Next(HSNAPSHOT hSnapshot, ref THREADENTRY32 lpte);

		/// <summary>
		/// <para>Copies memory allocated to another process into an application-supplied buffer.</para>
		/// </summary>
		/// <param name="th32ProcessID">
		/// <para>
		/// The identifier of the process whose memory is being copied. This parameter can be zero to copy the memory of the current process.
		/// </para>
		/// </param>
		/// <param name="lpBaseAddress">
		/// <para>
		/// The base address in the specified process to read. Before transferring any data, the system verifies that all data in the base
		/// address and memory of the specified size is accessible for read access. If this is the case, the function proceeds. Otherwise,
		/// the function fails.
		/// </para>
		/// </param>
		/// <param name="lpBuffer">
		/// <para>A pointer to a buffer that receives the contents of the address space of the specified process.</para>
		/// </param>
		/// <param name="cbRead">
		/// <para>The number of bytes to read from the specified process.</para>
		/// </param>
		/// <param name="lpNumberOfBytesRead">
		/// <para>The number of bytes copied to the specified buffer. If this parameter is <c>NULL</c>, it is ignored.</para>
		/// </param>
		/// <returns>
		/// <para>Returns <c>TRUE</c> if successful.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/tlhelp32/nf-tlhelp32-toolhelp32readprocessmemory BOOL
		// Toolhelp32ReadProcessMemory( DWORD th32ProcessID, LPCVOID lpBaseAddress, LPVOID lpBuffer, SIZE_T cbRead, SIZE_T
		// *lpNumberOfBytesRead );
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("tlhelp32.h", MSDNShortId = "e579b813-32ef-481d-8dc6-f959ec9b6bad")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool Toolhelp32ReadProcessMemory(uint th32ProcessID, IntPtr lpBaseAddress, IntPtr lpBuffer, SizeT cbRead, out SizeT lpNumberOfBytesRead);

		/// <summary>
		/// <para>Describes one entry (block) of a heap that is being examined.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/tlhelp32/ns-tlhelp32-tagheapentry32 typedef struct tagHEAPENTRY32 { SIZE_T
		// dwSize; HANDLE hHandle; ULONG_PTR dwAddress; SIZE_T dwBlockSize; DWORD dwFlags; DWORD dwLockCount; DWORD dwResvd; DWORD
		// th32ProcessID; ULONG_PTR th32HeapID; } HEAPENTRY32;
		[PInvokeData("tlhelp32.h", MSDNShortId = "c5f1dc66-d44f-4491-b0b7-961b163d0f1f")]
		[StructLayout(LayoutKind.Sequential)]
		public struct HEAPENTRY32
		{
			/// <summary>
			/// <para>
			/// The size of the structure, in bytes. Before calling the Heap32First function, set this member to . If you do not initialize
			/// <c>dwSize</c>, <c>Heap32First</c> fails.
			/// </para>
			/// </summary>
			public SizeT dwSize;

			/// <summary>
			/// <para>A handle to the heap block.</para>
			/// </summary>
			public IntPtr hHandle;

			/// <summary>
			/// <para>The linear address of the start of the block.</para>
			/// </summary>
			public UIntPtr dwAddress;

			/// <summary>
			/// <para>The size of the heap block, in bytes.</para>
			/// </summary>
			public SizeT dwBlockSize;

			/// <summary>
			/// <para>This member can be one of the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>LF32_FIXED</term>
			/// <term>The memory block has a fixed (unmovable) location.</term>
			/// </item>
			/// <item>
			/// <term>LF32_FREE</term>
			/// <term>The memory block is not used.</term>
			/// </item>
			/// <item>
			/// <term>LF32_MOVEABLE</term>
			/// <term>The memory block location can be moved.</term>
			/// </item>
			/// </list>
			/// </summary>
			public uint dwFlags;

			/// <summary>
			/// <para>This member is no longer used and is always set to zero.</para>
			/// </summary>
			public uint dwLockCount;

			/// <summary>
			/// <para>Reserved; do not use or alter.</para>
			/// </summary>
			public uint dwResvd;

			/// <summary>
			/// <para>The identifier of the process that uses the heap.</para>
			/// </summary>
			public uint th32ProcessID;

			/// <summary>
			/// <para>The heap identifier. This is not a handle, and has meaning only to the tool help functions.</para>
			/// </summary>
			public UIntPtr th32HeapID;
		}

		/// <summary>
		/// <para>Describes an entry from a list that enumerates the heaps used by a specified process.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/tlhelp32/ns-tlhelp32-tagheaplist32 typedef struct tagHEAPLIST32 { SIZE_T
		// dwSize; DWORD th32ProcessID; ULONG_PTR th32HeapID; DWORD dwFlags; } HEAPLIST32;
		[PInvokeData("tlhelp32.h", MSDNShortId = "61e01d23-9f15-44c5-9f6d-45df4809ccad")]
		[StructLayout(LayoutKind.Sequential)]
		public struct HEAPLIST32
		{
			/// <summary>
			/// <para>
			/// The size of the structure, in bytes. Before calling the Heap32ListFirst function, set this member to . If you do not
			/// initialize <c>dwSize</c>, <c>Heap32ListFirst</c> will fail.
			/// </para>
			/// </summary>
			public SizeT dwSize;

			/// <summary>
			/// <para>The identifier of the process to be examined.</para>
			/// </summary>
			public uint th32ProcessID;

			/// <summary>
			/// <para>The heap identifier. This is not a handle, and has meaning only to the tool help functions.</para>
			/// </summary>
			public UIntPtr th32HeapID;

			/// <summary>
			/// <para>This member can be one of the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>HF32_DEFAULT</term>
			/// <term>Process's default heap</term>
			/// </item>
			/// </list>
			/// </summary>
			public HEAPLIST32_FLAGS dwFlags;
		}

		/// <summary>Provides a handle to a snapshot.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct HSNAPSHOT : IKernelHandle
		{
			private IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="HSNAPSHOT"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public HSNAPSHOT(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="HSNAPSHOT"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static HSNAPSHOT NULL => new HSNAPSHOT(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="HSNAPSHOT"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(HSNAPSHOT h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HSNAPSHOT"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator HSNAPSHOT(IntPtr h) => new HSNAPSHOT(h);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(HSNAPSHOT h1, HSNAPSHOT h2) => !(h1 == h2);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(HSNAPSHOT h1, HSNAPSHOT h2) => h1.Equals(h2);

			/// <inheritdoc/>
			public override bool Equals(object obj) => obj is HSNAPSHOT h ? handle == h.handle : false;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
		}

		/// <summary>
		/// <para>Describes an entry from a list of the modules belonging to the specified process.</para>
		/// </summary>
		/// <remarks>
		/// <para>The <c>modBaseAddr</c> and <c>hModule</c> members are valid only in the context of the process specified by th32ProcessID.</para>
		/// <para>Examples</para>
		/// <para>For an example that uses <c>MODULEENTRY32</c>, see Traversing the Module List.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/tlhelp32/ns-tlhelp32-tagmoduleentry32 typedef struct tagMODULEENTRY32 { DWORD
		// dwSize; DWORD th32ModuleID; DWORD th32ProcessID; DWORD GlblcntUsage; DWORD ProccntUsage; BYTE *modBaseAddr; DWORD modBaseSize;
		// HMODULE hModule; char szModule[MAX_MODULE_NAME32 + 1]; char szExePath[MAX_PATH]; } MODULEENTRY32;
		[PInvokeData("tlhelp32.h", MSDNShortId = "305fab35-625c-42e3-a434-e2513e4c8870")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct MODULEENTRY32
		{
			private const int MAX_MODULE_NAME32 = 255;

			/// <summary>
			/// <para>
			/// The size of the structure, in bytes. Before calling the Module32First function, set this member to . If you do not initialize
			/// <c>dwSize</c>, <c>Module32First</c> fails.
			/// </para>
			/// </summary>
			public uint dwSize;

			/// <summary>
			/// <para>This member is no longer used, and is always set to one.</para>
			/// </summary>
			public uint th32ModuleID;

			/// <summary>
			/// <para>The identifier of the process whose modules are to be examined.</para>
			/// </summary>
			public uint th32ProcessID;

			/// <summary>
			/// <para>The load count of the module, which is not generally meaningful, and usually equal to 0xFFFF.</para>
			/// </summary>
			public uint GlblcntUsage;

			/// <summary>
			/// <para>The load count of the module (same as GlblcntUsage), which is not generally meaningful, and usually equal to 0xFFFF.</para>
			/// </summary>
			public uint ProccntUsage;

			/// <summary>
			/// <para>The base address of the module in the context of the owning process.</para>
			/// </summary>
			public IntPtr modBaseAddr;

			/// <summary>
			/// <para>The size of the module, in bytes.</para>
			/// </summary>
			public uint modBaseSize;

			/// <summary>
			/// <para>A handle to the module in the context of the owning process.</para>
			/// </summary>
			public HINSTANCE hModule;

			/// <summary>
			/// <para>The module name.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_MODULE_NAME32 + 1)]
			public string szModule;

			/// <summary>
			/// <para>The module path.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
			public string szExePath;
		}

		/// <summary>
		/// <para>Describes an entry from a list of the processes residing in the system address space when a snapshot was taken.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/tlhelp32/ns-tlhelp32-tagprocessentry32 typedef struct tagPROCESSENTRY32 {
		// DWORD dwSize; DWORD cntUsage; DWORD th32ProcessID; ULONG_PTR th32DefaultHeapID; DWORD th32ModuleID; DWORD cntThreads; DWORD
		// th32ParentProcessID; LONG pcPriClassBase; DWORD dwFlags; CHAR szExeFile[MAX_PATH]; } PROCESSENTRY32;
		[PInvokeData("tlhelp32.h", MSDNShortId = "9e2f7345-52bf-4bfc-9761-90b0b374c727")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct PROCESSENTRY32
		{
			/// <summary>
			/// <para>
			/// The size of the structure, in bytes. Before calling the Process32First function, set this member to . If you do not
			/// initialize <c>dwSize</c>, <c>Process32First</c> fails.
			/// </para>
			/// </summary>
			public uint dwSize;

			/// <summary>
			/// <para>This member is no longer used and is always set to zero.</para>
			/// </summary>
			public uint cntUsage;

			/// <summary>
			/// <para>The process identifier.</para>
			/// </summary>
			public uint th32ProcessID;

			/// <summary>
			/// <para>This member is no longer used and is always set to zero.</para>
			/// </summary>
			public UIntPtr th32DefaultHeapID;

			/// <summary>
			/// <para>This member is no longer used and is always set to zero.</para>
			/// </summary>
			public uint th32ModuleID;

			/// <summary>
			/// <para>The number of execution threads started by the process.</para>
			/// </summary>
			public uint cntThreads;

			/// <summary>
			/// <para>The identifier of the process that created this process (its parent process).</para>
			/// </summary>
			public uint th32ParentProcessID;

			/// <summary>
			/// <para>The base priority of any threads created by this process.</para>
			/// </summary>
			public int pcPriClassBase;

			/// <summary>
			/// <para>This member is no longer used, and is always set to zero.</para>
			/// </summary>
			public uint dwFlags;

			/// <summary>
			/// <para>
			/// The name of the executable file for the process. To retrieve the full path to the executable file, call the Module32First
			/// function and check the <c>szExePath</c> member of the MODULEENTRY32 structure that is returned. However, if the calling
			/// process is a 32-bit process, you must call the QueryFullProcessImageName function to retrieve the full path of the executable
			/// file for a 64-bit process.
			/// </para>
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
			public string szExeFile;
		}

		/// <summary>
		/// <para>Describes an entry from a list of the threads executing in the system when a snapshot was taken.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/tlhelp32/ns-tlhelp32-tagthreadentry32 typedef struct tagTHREADENTRY32 { DWORD
		// dwSize; DWORD cntUsage; DWORD th32ThreadID; DWORD th32OwnerProcessID; LONG tpBasePri; LONG tpDeltaPri; DWORD dwFlags; } THREADENTRY32;
		[PInvokeData("tlhelp32.h", MSDNShortId = "923feca1-8807-4752-8a5a-79075688aabd")]
		[StructLayout(LayoutKind.Sequential)]
		public struct THREADENTRY32
		{
			/// <summary>
			/// <para>
			/// The size of the structure, in bytes. Before calling the Thread32First function, set this member to . If you do not initialize
			/// <c>dwSize</c>, <c>Thread32First</c> fails.
			/// </para>
			/// </summary>
			public uint dwSize;

			/// <summary>
			/// <para>This member is no longer used and is always set to zero.</para>
			/// </summary>
			public uint cntUsage;

			/// <summary>
			/// <para>The thread identifier, compatible with the thread identifier returned by the CreateProcess function.</para>
			/// </summary>
			public uint th32ThreadID;

			/// <summary>
			/// <para>The identifier of the process that created the thread.</para>
			/// </summary>
			public uint th32OwnerProcessID;

			/// <summary>
			/// <para>
			/// The kernel base priority level assigned to the thread. The priority is a number from 0 to 31, with 0 representing the lowest
			/// possible thread priority. For more information, see <c>KeQueryPriorityThread</c>.
			/// </para>
			/// </summary>
			public int tpBasePri;

			/// <summary>
			/// <para>This member is no longer used and is always set to zero.</para>
			/// </summary>
			public int tpDeltaPri;

			/// <summary>
			/// <para>This member is no longer used and is always set to zero.</para>
			/// </summary>
			public uint dwFlags;
		}

		/// <summary>Provides a <see cref="SafeHandle"/> to a snapshot that releases a created HSNAPSHOT instance at disposal using CloseHandle.</summary>
		public class SafeHSNAPSHOT : SafeKernelHandle
		{
			/// <summary>Initializes a new instance of the <see cref="HSNAPSHOT"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafeHSNAPSHOT(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			private SafeHSNAPSHOT() : base() { }

			/// <summary>Performs an implicit conversion from <see cref="SafeHSNAPSHOT"/> to <see cref="HSNAPSHOT"/>.</summary>
			/// <param name="h">The safe handle instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator HSNAPSHOT(SafeHSNAPSHOT h) => h.handle;
		}
	}
}