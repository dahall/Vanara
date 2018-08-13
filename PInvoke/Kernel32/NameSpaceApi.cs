using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Kernel32
	{
		/// <summary>Indicates that the namespace is destroyed on closing.</summary>
		public const uint PRIVATE_NAMESPACE_FLAG_DESTROY = 0x00000001;

		/// <summary>Adds a security identifier (SID) to the specified boundary descriptor.</summary>
		/// <param name="BoundaryDescriptor">A handle to the boundary descriptor. The <c>CreateBoundaryDescriptor</c> function returns this handle.</param>
		/// <param name="RequiredSid">A pointer to a <c>SID</c> structure.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI AddSIDToBoundaryDescriptor( _Inout_ HANDLE *BoundaryDescriptor, _In_ PSID RequiredSid); https://msdn.microsoft.com/en-us/library/windows/desktop/ms681937(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms681937")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool AddSIDToBoundaryDescriptor(ref IntPtr BoundaryDescriptor, IntPtr RequiredSid);

		/// <summary>Closes an open namespace handle.</summary>
		/// <param name="Handle">The namespace handle. This handle is created by <c>CreatePrivateNamespace</c> or <c>OpenPrivateNamespace</c>.</param>
		/// <param name="Flags">If this parameter is <c>PRIVATE_NAMESPACE_FLAG_DESTROY</c> (0x00000001), the namespace is destroyed.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOLEAN WINAPI ClosePrivateNamespace( _In_ HANDLE Handle, _In_ ULONG Flags); https://msdn.microsoft.com/en-us/library/windows/desktop/ms682026(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms682026")]
		[return: MarshalAs(UnmanagedType.U1)]
		public static extern bool ClosePrivateNamespace(IntPtr Handle, uint Flags);

		/// <summary>Creates a boundary descriptor.</summary>
		/// <param name="Name">The name of the boundary descriptor.</param>
		/// <param name="Flags">This parameter is reserved for future use.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is a handle to the boundary descriptor.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// HANDLE WINAPI CreateBoundaryDescriptor( _In_ LPCTSTR Name, _In_ ULONG Flags); https://msdn.microsoft.com/en-us/library/windows/desktop/ms682121(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms682121")]
		public static extern IntPtr CreateBoundaryDescriptor(string Name, [Optional] uint Flags);

		/// <summary>Creates a private namespace.</summary>
		/// <param name="lpPrivateNamespaceAttributes">
		/// A pointer to a <c>SECURITY_ATTRIBUTES</c> structure that specifies the security attributes of the namespace object.
		/// </param>
		/// <param name="lpBoundaryDescriptor">
		/// A descriptor that defines how the namespace is to be isolated. The caller must be within this boundary. The <c>CreateBoundaryDescriptor</c> function
		/// creates a boundary descriptor.
		/// </param>
		/// <param name="lpAliasPrefix">
		/// <para>The prefix for the namespace. To create an object in this namespace, specify the object name as prefix\objectname.</para>
		/// <para>The system supports multiple private namespaces with the same name, as long as they define different boundaries.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, it returns a handle to the new namespace.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// HANDLE WINAPI CreatePrivateNamespace( _In_opt_ LPSECURITY_ATTRIBUTES lpPrivateNamespaceAttributes, _In_ LPVOID lpBoundaryDescriptor, _In_ LPCTSTR
		// lpAliasPrefix); https://msdn.microsoft.com/en-us/library/windows/desktop/ms682419(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms682419")]
		public static extern IntPtr CreatePrivateNamespace(SECURITY_ATTRIBUTES lpPrivateNamespaceAttributes, IntPtr lpBoundaryDescriptor, string lpAliasPrefix);

		/// <summary>Deletes the specified boundary descriptor.</summary>
		/// <param name="BoundaryDescriptor">A handle to the boundary descriptor. The <c>CreateBoundaryDescriptor</c> function returns this handle.</param>
		/// <returns>This function does not return a value.</returns>
		// VOID WINAPI DeleteBoundaryDescriptor( _In_ HANDLE BoundaryDescriptor); https://msdn.microsoft.com/en-us/library/windows/desktop/ms682549(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms682549")]
		public static extern void DeleteBoundaryDescriptor(IntPtr BoundaryDescriptor);

		/// <summary>Opens a private namespace.</summary>
		/// <param name="lpBoundaryDescriptor">
		/// A descriptor that defines how the namespace is to be isolated. The <c>CreateBoundaryDescriptor</c> function creates a boundary descriptor.
		/// </param>
		/// <param name="lpAliasPrefix">The prefix for the namespace. To create an object in this namespace, specify the object name as prefix\objectname.</param>
		/// <returns>The function returns the handle to the existing namespace.</returns>
		// HANDLE WINAPI OpenPrivateNamespace( _In_ LPVOID lpBoundaryDescriptor, _In_ LPCTSTR lpAliasPrefix); https://msdn.microsoft.com/en-us/library/windows/desktop/ms684318(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms684318")]
		public static extern IntPtr OpenPrivateNamespace(IntPtr lpBoundaryDescriptor, string lpAliasPrefix);
	}
}