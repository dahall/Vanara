namespace Vanara.PInvoke;

public static partial class Kernel32
{
	/// <summary>Indicates that FlsAlloc cannout allocate an index.</summary>
	public const uint FLS_OUT_OF_INDEXES = 0xFFFFFFFF;

	/// <summary>
	/// An application-defined function. If the FLS slot is in use, FlsCallback is called on fiber deletion, thread exit, and when an FLS
	/// index is freed. Specify this function when calling the FlsAlloc function. The PFLS_CALLBACK_FUNCTION type defines a pointer to
	/// this callback function. FlsCallback is a placeholder for the application-defined function name.
	/// </summary>
	/// <param name="lpFlsData">The value stored in the FLS slot for the calling fiber.</param>
	public delegate void FlsCallback(IntPtr lpFlsData);

	/// <summary>
	/// Allocates a fiber local storage (FLS) index. Any fiber in the process can subsequently use this index to store and retrieve
	/// values that are local to the fiber.
	/// </summary>
	/// <param name="lpCallback">
	/// A pointer to the application-defined callback function of type <c>PFLS_CALLBACK_FUNCTION</c>. This parameter is optional. For
	/// more information, see <c>FlsCallback</c>.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is an FLS index initialized to zero.</para>
	/// <para>If the function fails, the return value is FLS_OUT_OF_INDEXES. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// DWORD WINAPI FlsAlloc( _In_ PFLS_CALLBACK_FUNCTION lpCallback); https://msdn.microsoft.com/en-us/library/windows/desktop/ms682664(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("WinBase.h", MSDNShortId = "ms682664")]
	public static extern uint FlsAlloc([Optional] FlsCallback lpCallback);

	/// <summary>Releases a fiber local storage (FLS) index, making it available for reuse.</summary>
	/// <param name="dwFlsIndex">The FLS index that was allocated by the <c>FlsAlloc</c> function.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// BOOL WINAPI FlsFree( _In_ DWORD dwFlsIndex); https://msdn.microsoft.com/en-us/library/windows/desktop/ms682667(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("WinBase.h", MSDNShortId = "ms682667")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool FlsFree(uint dwFlsIndex);

	/// <summary>
	/// Retrieves the value in the calling fiber's fiber local storage (FLS) slot for the specified FLS index. Each fiber has its own
	/// slot for each FLS index.
	/// </summary>
	/// <param name="dwFlsIndex">The FLS index that was allocated by the <c>FlsAlloc</c> function.</param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is the value stored in the calling fiber's FLS slot associated with the specified index.
	/// </para>
	/// <para>If the function fails, the return value is NULL. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// PVOID WINAPI FlsGetValue( _In_ DWORD dwFlsIndex); https://msdn.microsoft.com/en-us/library/windows/desktop/ms683141(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("WinBase.h", MSDNShortId = "ms683141")]
	public static extern IntPtr FlsGetValue(uint dwFlsIndex);

	/// <summary>
	/// Stores a value in the calling fiber's fiber local storage (FLS) slot for the specified FLS index. Each fiber has its own slot for
	/// each FLS index.
	/// </summary>
	/// <param name="dwFlsIndex">The FLS index that was allocated by the <c>FlsAlloc</c> function.</param>
	/// <param name="lpFlsData">The value to be stored in the FLS slot for the calling fiber.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>
	/// If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>. The following
	/// errors can be returned.
	/// </para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>The index is not in range.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_MEMORY</term>
	/// <term>The FLS array has not been allocated.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </returns>
	// BOOL WINAPI FlsSetValue( _In_ DWORD dwFlsIndex, _In_opt_ PVOID lpFlsData); https://msdn.microsoft.com/en-us/library/windows/desktop/ms683146(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("WinBase.h", MSDNShortId = "ms683146")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool FlsSetValue(uint dwFlsIndex, IntPtr lpFlsData);

	/// <summary>Determines whether the current thread is a fiber.</summary>
	/// <returns>The function returns <c>TRUE</c> if the thread is a fiber and <c>FALSE</c> otherwise.</returns>
	// BOOL WINAPI IsThreadAFiber(void); https://msdn.microsoft.com/en-us/library/windows/desktop/ms684131(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("WinBase.h", MSDNShortId = "ms684131")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool IsThreadAFiber();
}