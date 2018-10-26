using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Kernel32
	{
		/// <summary>Retrieves a handle that can be used by the <c>UpdateResource</c> function to add, delete, or replace resources in a binary module.</summary>
		/// <param name="pFileName">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>
		/// The binary file in which to update resources. An application must be able to obtain write-access to this file; the file referenced by pFileName
		/// cannot be currently executing. If pFileName does not specify a full path, the system searches for the file in the current directory.
		/// </para>
		/// </param>
		/// <param name="bDeleteExistingResources">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// Indicates whether to delete the pFileName parameter's existing resources. If this parameter is <c>TRUE</c>, existing resources are deleted and the
		/// updated file includes only resources added with the <c>UpdateResource</c> function. If this parameter is <c>FALSE</c>, the updated file includes
		/// existing resources unless they are explicitly deleted or replaced by using <c>UpdateResource</c>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HANDLE</c></para>
		/// <para>
		/// If the function succeeds, the return value is a handle that can be used by the <c>UpdateResource</c> and <c>EndUpdateResource</c> functions. The
		/// return value is <c>NULL</c> if the specified file is not a PE, the file does not exist, or the file cannot be opened for writing. To get extended
		/// error information, call <c>GetLastError</c>.
		/// </para>
		/// </returns>
		// HANDLE WINAPI BeginUpdateResource( _In_ LPCTSTR pFileName, _In_ BOOL bDeleteExistingResources);
		// https://msdn.microsoft.com/en-us/library/windows/desktop/ms648030(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("Winbase.h", MSDNShortId = "ms648030")]
		public static extern UpdateResourceHandle BeginUpdateResource(string pFileName, [MarshalAs(UnmanagedType.Bool)] bool bDeleteExistingResources);

		/// <summary>Commits or discards changes made prior to a call to <c>UpdateResource</c>.</summary>
		/// <param name="hUpdate">
		/// <para>Type: <c>HANDLE</c></para>
		/// <para>A module handle returned by the <c>BeginUpdateResource</c> function, and used by <c>UpdateResource</c>, referencing the file to be updated.</para>
		/// </param>
		/// <param name="fDiscard">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// Indicates whether to write the resource updates to the file. If this parameter is <c>TRUE</c>, no changes are made. If it is <c>FALSE</c>, the
		/// changes are made: the resource updates will take effect.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// Returns <c>TRUE</c> if the function succeeds; <c>FALSE</c> otherwise. If the function succeeds and fDiscard is <c>TRUE</c>, then no resource updates
		/// are made to the file; otherwise all successful resource updates are made to the file. To get extended error information, call <c>GetLastError</c>.
		/// </para>
		/// </returns>
		// BOOL WINAPI EndUpdateResource( _In_ HANDLE hUpdate, _In_ BOOL fDiscard);
		// https://msdn.microsoft.com/en-us/library/windows/desktop/ms648032(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("Winbase.h", MSDNShortId = "ms648032")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool EndUpdateResource([In] UpdateResourceHandle hUpdate, [MarshalAs(UnmanagedType.Bool)] bool fDiscard);

		/// <summary>
		/// Adds, deletes, or replaces a resource in a portable executable (PE) file. There are some restrictions on resource updates in files that contain
		/// Resource Configuration (RC Config) data: language-neutral (LN) files and language-specific resource (.mui) files.
		/// </summary>
		/// <param name="hUpdate">
		/// <para>Type: <c>HANDLE</c></para>
		/// <para>A module handle returned by the <c>BeginUpdateResource</c> function, referencing the file to be updated.</para>
		/// </param>
		/// <param name="lpType">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>
		/// The resource type to be updated. Alternatively, rather than a pointer, this parameter can be <c>MAKEINTRESOURCE</c>(ID), where ID is an integer value
		/// representing a predefined resource type. If the first character of the string is a pound sign (#), then the remaining characters represent a decimal
		/// number that specifies the integer identifier of the resource type. For example, the string "#258" represents the identifier 258.
		/// </para>
		/// <para>For a list of predefined resource types, see Resource Types.</para>
		/// </param>
		/// <param name="lpName">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>
		/// The name of the resource to be updated. Alternatively, rather than a pointer, this parameter can be <c>MAKEINTRESOURCE</c>(ID), where ID is a
		/// resource ID. When creating a new resource do not use a string that begins with a '#' character for this parameter.
		/// </para>
		/// </param>
		/// <param name="wLanguage">
		/// <para>Type: <c>WORD</c></para>
		/// <para>
		/// The language identifier of the resource to be updated. For a list of the primary language identifiers and sublanguage identifiers that make up a
		/// language identifier, see the <c>MAKELANGID</c> macro.
		/// </para>
		/// </param>
		/// <param name="lpData">
		/// <para>Type: <c>LPVOID</c></para>
		/// <para>
		/// The resource data to be inserted into the file indicated by hUpdate. If the resource is one of the predefined types, the data must be valid and
		/// properly aligned. Note that this is the raw binary data to be stored in the file indicated by hUpdate, not the data provided by <c>LoadIcon</c>,
		/// <c>LoadString</c>, or other resource-specific load functions. All data containing strings or text must be in Unicode format. lpData must not point to
		/// ANSI data.
		/// </para>
		/// <para>If lpData is <c>NULL</c> and cbData is 0, the specified resource is deleted from the file indicated by hUpdate.</para>
		/// </param>
		/// <param name="cbData">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The size, in bytes, of the resource data at lpData.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Returns <c>TRUE</c> if successful or <c>FALSE</c> otherwise. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI UpdateResource( _In_ HANDLE hUpdate, _In_ LPCTSTR lpType, _In_ LPCTSTR lpName, _In_ WORD wLanguage, _In_opt_ LPVOID lpData, _In_ DWORD cbData);
		// https://msdn.microsoft.com/en-us/library/windows/desktop/ms648049(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("Winbase.h", MSDNShortId = "ms648049")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool UpdateResource([In] UpdateResourceHandle hUpdate, string lpType, string lpName, ushort wLanguage, [In] IntPtr lpData, uint cbData);

		/// <summary>Provides a handle that can be used by UpdateResource.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct UpdateResourceHandle : IHandle
		{
			private IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="UpdateResourceHandle"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public UpdateResourceHandle(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="UpdateResourceHandle"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static UpdateResourceHandle NULL => new UpdateResourceHandle(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="UpdateResourceHandle"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(UpdateResourceHandle h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="UpdateResourceHandle"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator UpdateResourceHandle(IntPtr h) => new UpdateResourceHandle(h);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(UpdateResourceHandle h1, UpdateResourceHandle h2) => !(h1 == h2);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(UpdateResourceHandle h1, UpdateResourceHandle h2) => h1.Equals(h2);

			/// <inheritdoc/>
			public override bool Equals(object obj) => obj is UpdateResourceHandle h ? handle == h.handle : false;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
		}
	}
}