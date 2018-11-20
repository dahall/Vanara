using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class User32
	{
		/// <summary>
		/// An application-defined callback function used with the EnumProps function. The function receives property entries from a window's
		/// property list. The <c>PROPENUMPROC</c> type defines a pointer to this callback function. PropEnumProc is a placeholder for the
		/// application-defined function name.
		/// </summary>
		/// <param name="hwnd">Handle to the window whose property list is being enumerated.</param>
		/// <param name="lpszString">
		/// Pointer to a null-terminated string. This string is the string component of a property list entry. This is the string that was
		/// specified, along with a data handle, when the property was added to the window's property list via a call to the SetProp function.
		/// </param>
		/// <param name="hData">Handle to data. This handle is the data component of a property list entry.</param>
		/// <returns>
		/// <para>Type: <c>Type: <c>BOOL</c></c></para>
		/// <para>Return <c>TRUE</c> to continue the property list enumeration.</para>
		/// <para>Return <c>FALSE</c> to stop the property list enumeration.</para>
		/// </returns>
		/// <remarks>
		/// <para>The following restrictions apply to this callback function:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// The callback function can call the RemoveProp function. However, <c>RemoveProp</c> can remove only the property passed to the
		/// callback function through the callback function's parameters.
		/// </term>
		/// </item>
		/// <item>
		/// <term>The callback function should not attempt to add properties.</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nc-winuser-propenumproca PROPENUMPROCA Propenumproca; BOOL
		// Propenumproca( HWND Arg1, LPCSTR Arg2, HANDLE Arg3 ) {...}
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		[PInvokeData("winuser.h", MSDNShortId = "propenumproc")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public delegate bool PropEnumProc(HWND hwnd, string lpszString, IntPtr hData);

		/// <summary>
		/// Application-defined callback function used with the EnumPropsEx function. The function receives property entries from a window's
		/// property list. The PROPENUMPROCEX type defines a pointer to this callback function. <c>PropEnumProcEx</c> is a placeholder for
		/// the application-defined function name.
		/// </summary>
		/// <param name="hwnd">Handle to the window whose property list is being enumerated.</param>
		/// <param name="lpszString">
		/// Pointer to a null-terminated string. This string is the string component of a property list entry. This is the string that was
		/// specified, along with a data handle, when the property was added to the window's property list via a call to the SetProp function.
		/// </param>
		/// <param name="hData">Handle to data. This handle is the data component of a property list entry.</param>
		/// <param name="dwData">
		/// Application-defined data. This is the value that was specified as the lParam parameter of the call to EnumPropsEx that initiated
		/// the enumeration.
		/// </param>
		/// <returns>
		/// <para>Type: <c>Type: <c>BOOL</c></c></para>
		/// <para>Return <c>TRUE</c> to continue the property list enumeration.</para>
		/// <para>Return <c>FALSE</c> to stop the property list enumeration.</para>
		/// </returns>
		/// <remarks>
		/// <para>The following restrictions apply to this callback function:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// The callback function can call the RemoveProp function. However, <c>RemoveProp</c> can remove only the property passed to the
		/// callback function through the callback function's parameters.
		/// </term>
		/// </item>
		/// <item>
		/// <term>The callback function should not attempt to add properties.</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nc-winuser-propenumprocexa PROPENUMPROCEXA Propenumprocexa; BOOL
		// Propenumprocexa( HWND Arg1, LPSTR Arg2, HANDLE Arg3, ULONG_PTR Arg4 ) {...}
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		[PInvokeData("winuser.h", MSDNShortId = "propenumprocex")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public delegate bool PropEnumProcEx(HWND hwnd, string lpszString, IntPtr hData, UIntPtr dwData);

		/// <summary>
		/// <para>
		/// Enumerates all entries in the property list of a window by passing them, one by one, to the specified callback function.
		/// <c>EnumProps</c> continues until the last entry is enumerated or the callback function returns <c>FALSE</c>.
		/// </para>
		/// <para>To pass application-defined data to the callback function, use EnumPropsEx function.</para>
		/// </summary>
		/// <param name="hWnd">
		/// <para>Type: <c>HWND</c></para>
		/// <para>A handle to the window whose property list is to be enumerated.</para>
		/// </param>
		/// <param name="lpEnumFunc">
		/// <para>Type: <c>PROPENUMPROC</c></para>
		/// <para>A pointer to the callback function. For more information about the callback function, see the PropEnumProc function.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>Type: <c>int</c></c></para>
		/// <para>
		/// The return value specifies the last value returned by the callback function. It is -1 if the function did not find a property for enumeration.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// An application can remove only those properties it has added. It must not remove properties added by other applications or by the
		/// system itself.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-enumpropsa int EnumPropsA( HWND hWnd, PROPENUMPROCA
		// lpEnumFunc );
		[DllImport(Lib.User32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("winuser.h", MSDNShortId = "enumprops")]
		public static extern int EnumProps(HWND hWnd, PropEnumProc lpEnumFunc);

		/// <summary>
		/// <para>
		/// Enumerates all entries in the property list of a window by passing them, one by one, to the specified callback function.
		/// <c>EnumPropsEx</c> continues until the last entry is enumerated or the callback function returns <c>FALSE</c>.
		/// </para>
		/// </summary>
		/// <param name="hWnd">
		/// <para>Type: <c>HWND</c></para>
		/// <para>A handle to the window whose property list is to be enumerated.</para>
		/// </param>
		/// <param name="lpEnumFunc">
		/// <para>Type: <c>PROPENUMPROCEX</c></para>
		/// <para>A pointer to the callback function. For more information about the callback function, see the PropEnumProcEx function.</para>
		/// </param>
		/// <param name="lParam">
		/// <para>Type: <c>LPARAM</c></para>
		/// <para>Application-defined data to be passed to the callback function.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>Type: <c>int</c></c></para>
		/// <para>
		/// The return value specifies the last value returned by the callback function. It is -1 if the function did not find a property for enumeration.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// An application can remove only those properties it has added. It must not remove properties added by other applications or by the
		/// system itself.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Listing Window Properties for a Given Window.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-enumpropsexa int EnumPropsExA( HWND hWnd, PROPENUMPROCEXA
		// lpEnumFunc, LPARAM lParam );
		[DllImport(Lib.User32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("winuser.h", MSDNShortId = "enumpropsex")]
		public static extern int EnumPropsEx(HWND hWnd, PropEnumProcEx lpEnumFunc, IntPtr lParam);

		/// <summary>
		/// <para>
		/// Retrieves a data handle from the property list of the specified window. The character string identifies the handle to be
		/// retrieved. The string and handle must have been added to the property list by a previous call to the SetProp function.
		/// </para>
		/// </summary>
		/// <param name="hWnd">
		/// <para>Type: <c>HWND</c></para>
		/// <para>A handle to the window whose property list is to be searched.</para>
		/// </param>
		/// <param name="lpString">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>
		/// An atom that identifies a string. If this parameter is an atom, it must have been created by using the GlobalAddAtom function.
		/// The atom, a 16-bit value, must be placed in the low-order word of the lpString parameter; the high-order word must be zero.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>Type: <c>HANDLE</c></c></para>
		/// <para>
		/// If the property list contains the string, the return value is the associated data handle. Otherwise, the return value is <c>NULL</c>.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getpropa HANDLE GetPropA( HWND hWnd, LPCSTR lpString );
		[DllImport(Lib.User32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("winuser.h", MSDNShortId = "getprop")]
		public static extern IntPtr GetProp(HWND hWnd, string lpString);

		/// <summary>
		/// <para>
		/// Removes an entry from the property list of the specified window. The specified character string identifies the entry to be removed.
		/// </para>
		/// </summary>
		/// <param name="hWnd">
		/// <para>Type: <c>HWND</c></para>
		/// <para>A handle to the window whose property list is to be changed.</para>
		/// </param>
		/// <param name="lpString">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>
		/// A null-terminated character string or an atom that identifies a string. If this parameter is an atom, it must have been created
		/// using the GlobalAddAtom function. The atom, a 16-bit value, must be placed in the low-order word of lpString; the high-order word
		/// must be zero.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>Type: <c>HANDLE</c></c></para>
		/// <para>
		/// The return value identifies the specified data. If the data cannot be found in the specified property list, the return value is <c>NULL</c>.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The return value is the hData value that was passed to SetProp; it is an application-defined value. Note, this function only
		/// destroys the association between the data and the window. If appropriate, the application must free the data handles associated
		/// with entries removed from a property list. The application can remove only those properties it has added. It must not remove
		/// properties added by other applications or by the system itself.
		/// </para>
		/// <para>
		/// The <c>RemoveProp</c> function returns the data handle associated with the string so that the application can free the data
		/// associated with the handle.
		/// </para>
		/// <para>
		/// Starting with Windows Vista, <c>RemoveProp</c> is subject to the restrictions of User Interface Privilege Isolation (UIPI). A
		/// process can only call this function on a window belonging to a process of lesser or equal integrity level. When UIPI blocks
		/// property changes, GetLastError will return <c>5</c>.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Deleting a Window Property.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-removepropa HANDLE RemovePropA( HWND hWnd, LPCSTR lpString );
		[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("winuser.h", MSDNShortId = "removeprop")]
		public static extern IntPtr RemoveProp(HWND hWnd, string lpString);

		/// <summary>
		/// <para>
		/// Adds a new entry or changes an existing entry in the property list of the specified window. The function adds a new entry to the
		/// list if the specified character string does not exist already in the list. The new entry contains the string and the handle.
		/// Otherwise, the function replaces the string's current handle with the specified handle.
		/// </para>
		/// </summary>
		/// <param name="hWnd">
		/// <para>Type: <c>HWND</c></para>
		/// <para>A handle to the window whose property list receives the new entry.</para>
		/// </param>
		/// <param name="lpString">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>
		/// A null-terminated string or an atom that identifies a string. If this parameter is an atom, it must be a global atom created by a
		/// previous call to the GlobalAddAtom function. The atom must be placed in the low-order word of lpString; the high-order word must
		/// be zero.
		/// </para>
		/// </param>
		/// <param name="hData">
		/// <para>Type: <c>HANDLE</c></para>
		/// <para>A handle to the data to be copied to the property list. The data handle can identify any value useful to the application.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>Type: <c>BOOL</c></c></para>
		/// <para>If the data handle and string are added to the property list, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Before a window is destroyed (that is, before it returns from processing the WM_NCDESTROY message), an application must remove
		/// all entries it has added to the property list. The application must use the RemoveProp function to remove the entries.
		/// </para>
		/// <para>
		/// <c>SetProp</c> is subject to the restrictions of User Interface Privilege Isolation (UIPI). A process can only call this function
		/// on a window belonging to a process of lesser or equal integrity level. When UIPI blocks property changes, GetLastError will
		/// return 5.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Adding a Window Property.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-setpropa BOOL SetPropA( HWND hWnd, LPCSTR lpString, HANDLE
		// hData );
		[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("winuser.h", MSDNShortId = "setprop")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetProp(HWND hWnd, string lpString, IntPtr hData);
	}
}