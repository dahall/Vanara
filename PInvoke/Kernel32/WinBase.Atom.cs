using System.Runtime.InteropServices;
using System.Text;

namespace Vanara.PInvoke
{
	public static partial class Kernel32
	{
		/// <summary>Adds a character string to the local atom table and returns a unique value (an atom) identifying the string.</summary>
		/// <param name="lpString">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>
		/// The null-terminated string to be added. The string can have a maximum size of 255 bytes. Strings differing only in case are considered identical. The
		/// case of the first string added is preserved and returned by the <c>GetAtomName</c> function.
		/// </para>
		/// <para>Alternatively, you can use an integer atom that has been converted using the <c>MAKEINTATOM</c> macro. See the Remarks for more information.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ATOM</c></para>
		/// <para>If the function succeeds, the return value is the newly created atom.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// ATOM WINAPI AddAtom( _In_ LPCTSTR lpString); https://msdn.microsoft.com/en-us/library/windows/desktop/ms649056(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("Winbase.h", MSDNShortId = "ms649056")]
		public static extern ushort AddAtom([In] string lpString);

		/// <summary>
		/// Decrements the reference count of a local string atom. If the atom's reference count is reduced to zero, <c>DeleteAtom</c> removes the string
		/// associated with the atom from the local atom table.
		/// </summary>
		/// <param name="nAtom">
		/// <para>Type: <c>ATOM</c></para>
		/// <para>The atom to be deleted.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ATOM</c></para>
		/// <para>If the function succeeds, the return value is zero.</para>
		/// <para>If the function fails, the return value is the nAtom parameter. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// ATOM WINAPI DeleteAtom( _In_ ATOM nAtom); https://msdn.microsoft.com/en-us/library/windows/desktop/ms649057(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("Winbase.h", MSDNShortId = "ms649057")]
		public static extern ushort DeleteAtom(ushort nAtom);

		/// <summary>Searches the local atom table for the specified character string and retrieves the atom associated with that string.</summary>
		/// <param name="lpString">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>The character string for which to search.</para>
		/// <para>Alternatively, you can use an integer atom that has been converted using the <c>MAKEINTATOM</c> macro. See Remarks for more information.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ATOM</c></para>
		/// <para>If the function succeeds, the return value is the atom associated with the given string.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// ATOM WINAPI FindAtom( _In_ LPCTSTR lpString); https://msdn.microsoft.com/en-us/library/windows/desktop/ms649058(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("Winbase.h", MSDNShortId = "ms649058")]
		public static extern ushort FindAtom([In] string lpString);

		/// <summary>Retrieves a copy of the character string associated with the specified local atom.</summary>
		/// <param name="nAtom">
		/// <para>Type: <c>ATOM</c></para>
		/// <para>The local atom that identifies the character string to be retrieved.</para>
		/// </param>
		/// <param name="lpBuffer">
		/// <para>Type: <c>LPTSTR</c></para>
		/// <para>The character string.</para>
		/// </param>
		/// <param name="nSize">
		/// <para>Type: <c>int</c></para>
		/// <para>The size, in characters, of the buffer.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// If the function succeeds, the return value is the length of the string copied to the buffer, in characters, not including the terminating null character.
		/// </para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// UINT WINAPI GetAtomName( _In_ ATOM nAtom, _Out_ LPTSTR lpBuffer, _In_ int nSize); https://msdn.microsoft.com/en-us/library/windows/desktop/ms649059(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("Winbase.h", MSDNShortId = "ms649059")]
		public static extern uint GetAtomName(ushort nAtom, [Out] StringBuilder lpBuffer, int nSize);

		/// <summary>Adds a character string to the global atom table and returns a unique value (an atom) identifying the string.</summary>
		/// <param name="lpString">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>
		/// The null-terminated string to be added. The string can have a maximum size of 255 bytes. Strings that differ only in case are considered identical.
		/// The case of the first string of this name added to the table is preserved and returned by the <c>GlobalGetAtomName</c> function.
		/// </para>
		/// <para>Alternatively, you can use an integer atom that has been converted using the <c>MAKEINTATOM</c> macro. See the Remarks for more information.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ATOM</c></para>
		/// <para>If the function succeeds, the return value is the newly created atom.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// ATOM WINAPI GlobalAddAtom( _In_ LPCTSTR lpString); https://msdn.microsoft.com/en-us/library/windows/desktop/ms649060(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("Winbase.h", MSDNShortId = "ms649060")]
		public static extern ushort GlobalAddAtom([In] string lpString);

		/// <summary>Adds a character string to the global atom table and returns a unique value (an atom) identifying the string.</summary>
		/// <param name="lpString">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>
		/// The null-terminated string to be added. The string can have a maximum size of 255 bytes. Strings that differ only in case are considered identical.
		/// The case of the first string of this name added to the table is preserved and returned by the <c>GlobalGetAtomName</c> function.
		/// </para>
		/// <para>Alternatively, you can use an integer atom that has been converted using the <c>MAKEINTATOM</c> macro. See the Remarks for more information.</para>
		/// </param>
		/// <param name="Flags">The flags.</param>
		/// <returns>
		/// <para>Type: <c>ATOM</c></para>
		/// <para>If the function succeeds, the return value is the newly created atom.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// ATOM WINAPI GlobalAddAtom( _In_ LPCTSTR lpString); https://msdn.microsoft.com/en-us/library/windows/desktop/dn764994(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("Winbase.h", MSDNShortId = "dn764994")]
		public static extern ushort GlobalAddAtomEx([In] string lpString, uint Flags);

		/// <summary>
		/// Decrements the reference count of a global string atom. If the atom's reference count reaches zero, <c>GlobalDeleteAtom</c> removes the string
		/// associated with the atom from the global atom table.
		/// </summary>
		/// <param name="nAtom">
		/// <para>Type: <c>ATOM</c></para>
		/// <para>The atom and character string to be deleted.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ATOM</c></para>
		/// <para>The function always returns ( <c>ATOM</c>) 0.</para>
		/// <para>
		/// To determine whether the function has failed, call <c>SetLastError</c> with <c>ERROR_SUCCESS</c> before calling <c>GlobalDeleteAtom</c>, then call
		/// <c>GetLastError</c>. If the last error code is still <c>ERROR_SUCCESS</c>, <c>GlobalDeleteAtom</c> has succeeded.
		/// </para>
		/// </returns>
		// ATOM WINAPI GlobalDeleteAtom( _In_ ATOM nAtom); https://msdn.microsoft.com/en-us/library/windows/desktop/ms649061(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("Winbase.h", MSDNShortId = "ms649061")]
		public static extern ushort GlobalDeleteAtom(ushort nAtom);

		/// <summary>Searches the global atom table for the specified character string and retrieves the global atom associated with that string.</summary>
		/// <param name="lpString">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>The null-terminated character string for which to search.</para>
		/// <para>Alternatively, you can use an integer atom that has been converted using the <c>MAKEINTATOM</c> macro. See the Remarks for more information.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ATOM</c></para>
		/// <para>If the function succeeds, the return value is the global atom associated with the given string.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// ATOM WINAPI GlobalFindAtom( _In_ LPCTSTR lpString); https://msdn.microsoft.com/en-us/library/windows/desktop/ms649062(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("Winbase.h", MSDNShortId = "ms649062")]
		public static extern ushort GlobalFindAtom([In] string lpString);

		/// <summary>Retrieves a copy of the character string associated with the specified global atom.</summary>
		/// <param name="nAtom">
		/// <para>Type: <c>ATOM</c></para>
		/// <para>The global atom associated with the character string to be retrieved.</para>
		/// </param>
		/// <param name="lpBuffer">
		/// <para>Type: <c>LPTSTR</c></para>
		/// <para>The buffer for the character string.</para>
		/// </param>
		/// <param name="nSize">
		/// <para>Type: <c>int</c></para>
		/// <para>The size, in characters, of the buffer.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// If the function succeeds, the return value is the length of the string copied to the buffer, in characters, not including the terminating null character.
		/// </para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// UINT WINAPI GlobalGetAtomName( _In_ ATOM nAtom, _Out_ LPTSTR lpBuffer, _In_ int nSize); https://msdn.microsoft.com/en-us/library/windows/desktop/ms649063(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("Winbase.h", MSDNShortId = "ms649063")]
		public static extern uint GlobalGetAtomName(ushort nAtom, [Out] StringBuilder lpBuffer, int nSize);

		/// <summary>Initializes the local atom table and sets the number of hash buckets to the specified size.</summary>
		/// <param name="nSize">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The number of hash buckets to use for the atom table. If this parameter is zero, the default number of hash buckets are created.</para>
		/// <para>To achieve better performance, specify a prime number in nSize.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero.</para>
		/// </returns>
		// BOOL WINAPI InitAtomTable( _In_ DWORD nSize); https://msdn.microsoft.com/en-us/library/windows/desktop/ms649064(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Winbase.h", MSDNShortId = "ms649064")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool InitAtomTable(uint nSize);
	}
}