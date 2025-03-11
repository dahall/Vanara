﻿using System.Runtime.CompilerServices;
using System.Security;

namespace Vanara.PInvoke;

public static partial class Kernel32
{
	/// <summary>Indicates that the namespace is destroyed on closing.</summary>
	public const uint PRIVATE_NAMESPACE_FLAG_DESTROY = 0x00000001;

	/// <summary>
	/// <para>Adds a new required security identifier (SID) to the specified boundary descriptor.</para>
	/// </summary>
	/// <param name="BoundaryDescriptor">
	/// <para>A handle to the boundary descriptor. The CreateBoundaryDescriptor function returns this handle.</para>
	/// </param>
	/// <param name="IntegrityLabel">
	/// <para>
	/// A pointer to a SID structure that represents the mandatory integrity level for the namespace. Use one of the following RID values
	/// to create the SID:
	/// </para>
	/// <para>
	/// <c>SECURITY_MANDATORY_UNTRUSTED_RID</c><c>SECURITY_MANDATORY_LOW_RID</c><c>SECURITY_MANDATORY_MEDIUM_RID</c><c>SECURITY_MANDATORY_SYSTEM_RID</c><c>SECURITY_MANDATORY_PROTECTED_PROCESS_RID</c>
	/// For more information, see Well-Known SIDs.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// A process can create a private namespace only with an integrity level that is equal to or lower than the current integrity level
	/// of the process. Therefore, a high integrity-level process can create a high, medium or low integrity-level namespace. A medium
	/// integrity-level process can create only a medium or low integrity-level namespace.
	/// </para>
	/// <para>
	/// A process would usually specify a namespace at the same integrity level as the process for protection against squatting attacks
	/// by lower integrity-level processes.
	/// </para>
	/// <para>
	/// The security descriptor that the creator places on the namespace determines who can open the namespace. So a low or medium
	/// integrity-level process could be given permission to open a high integrity level namespace if the security descriptor of the
	/// namespace permits it.
	/// </para>
	/// <para>To compile an application that uses this function, define <c>_WIN32_WINNT</c> as 0x0601 or later.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-addintegritylabeltoboundarydescriptor BOOL
	// AddIntegrityLabelToBoundaryDescriptor( HANDLE *BoundaryDescriptor, PSID IntegrityLabel );
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winbase.h", MSDNShortId = "6b56e664-7795-4e30-8bca-1e4df2764606")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AddIntegrityLabelToBoundaryDescriptor(ref BoundaryDescriptorHandle BoundaryDescriptor, PSID IntegrityLabel);

	/// <summary>Adds a security identifier (SID) to the specified boundary descriptor.</summary>
	/// <param name="BoundaryDescriptor">
	/// A handle to the boundary descriptor. The <c>CreateBoundaryDescriptor</c> function returns this handle.
	/// </param>
	/// <param name="RequiredSid">A pointer to a <c>SID</c> structure.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// BOOL WINAPI AddSIDToBoundaryDescriptor( _Inout_ HANDLE *BoundaryDescriptor, _In_ PSID RequiredSid); https://msdn.microsoft.com/en-us/library/windows/desktop/ms681937(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("WinBase.h", MSDNShortId = "ms681937")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AddSIDToBoundaryDescriptor(ref BoundaryDescriptorHandle BoundaryDescriptor, PSID RequiredSid);

	/// <summary>Closes an open namespace handle.</summary>
	/// <param name="Handle">The namespace handle. This handle is created by CreatePrivateNamespace or OpenPrivateNamespace.</param>
	/// <param name="Flags">If this parameter is <c>PRIVATE_NAMESPACE_FLAG_DESTROY</c> (0x00000001), the namespace is destroyed.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>To compile an application that uses this function, define <c>_WIN32_WINNT</c> as 0x0600 or later.</remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/namespaceapi/nf-namespaceapi-closeprivatenamespace
	// BOOLEAN ClosePrivateNamespace( HANDLE Handle, ULONG Flags );
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("namespaceapi.h", MSDNShortId = "b9b74cf2-bf13-4ceb-9242-bc6a884ac6f1")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern bool ClosePrivateNamespace(NamespaceHandle Handle, [Optional] uint Flags);

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
	public static extern SafeBoundaryDescriptorHandle CreateBoundaryDescriptor(string Name, [Optional] uint Flags);

	/// <summary>Creates a private namespace.</summary>
	/// <param name="lpPrivateNamespaceAttributes">
	/// A pointer to a <c>SECURITY_ATTRIBUTES</c> structure that specifies the security attributes of the namespace object.
	/// </param>
	/// <param name="lpBoundaryDescriptor">
	/// A descriptor that defines how the namespace is to be isolated. The caller must be within this boundary. The
	/// <c>CreateBoundaryDescriptor</c> function creates a boundary descriptor.
	/// </param>
	/// <param name="lpAliasPrefix">
	/// <para>The prefix for the namespace. To create an object in this namespace, specify the object name as prefix\objectname.</para>
	/// <para>The system supports multiple private namespaces with the same name, as long as they define different boundaries.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns a handle to the new namespace.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// HANDLE WINAPI CreatePrivateNamespace( _In_opt_ LPSECURITY_ATTRIBUTES lpPrivateNamespaceAttributes, _In_ LPVOID
	// lpBoundaryDescriptor, _In_ LPCTSTR lpAliasPrefix); https://msdn.microsoft.com/en-us/library/windows/desktop/ms682419(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("WinBase.h", MSDNShortId = "ms682419")]
	public static extern SafeNamespaceHandle CreatePrivateNamespace([In, Optional] SECURITY_ATTRIBUTES? lpPrivateNamespaceAttributes, [In] BoundaryDescriptorHandle lpBoundaryDescriptor, string lpAliasPrefix);

	/// <summary>Deletes the specified boundary descriptor.</summary>
	/// <param name="BoundaryDescriptor">A handle to the boundary descriptor. The CreateBoundaryDescriptor function returns this handle.</param>
	/// <returns>This function does not return a value.</returns>
	/// <remarks>To compile an application that uses this function, define <c>_WIN32_WINNT</c> as 0x0600 or later.</remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/namespaceapi/nf-namespaceapi-deleteboundarydescriptor
	// void DeleteBoundaryDescriptor( HANDLE BoundaryDescriptor );
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[SecurityCritical, SuppressUnmanagedCodeSecurity]
	[PInvokeData("namespaceapi.h", MSDNShortId = "759d9cd9-9ef2-4bbe-9e99-8aec87f5ba4a")]
	public static extern void DeleteBoundaryDescriptor([In] BoundaryDescriptorHandle BoundaryDescriptor);

	/// <summary>Opens a private namespace.</summary>
	/// <param name="lpBoundaryDescriptor">
	/// A descriptor that defines how the namespace is to be isolated. The <c>CreateBoundaryDescriptor</c> function creates a boundary descriptor.
	/// </param>
	/// <param name="lpAliasPrefix">
	/// The prefix for the namespace. To create an object in this namespace, specify the object name as prefix\objectname.
	/// </param>
	/// <returns>The function returns the handle to the existing namespace.</returns>
	// HANDLE WINAPI OpenPrivateNamespace( _In_ LPVOID lpBoundaryDescriptor, _In_ LPCTSTR lpAliasPrefix); https://msdn.microsoft.com/en-us/library/windows/desktop/ms684318(v=vs.85).aspx
	[PInvokeData("WinBase.h", MSDNShortId = "ms684318")]
	public static SafeNamespaceHandle OpenPrivateNamespace([In] BoundaryDescriptorHandle lpBoundaryDescriptor, string lpAliasPrefix)
	{
		var h = OpenPrivateNamespaceInternal(lpBoundaryDescriptor, lpAliasPrefix);
		h.flag = 0;
		return h;
	}

	/// <summary>Opens a private namespace.</summary>
	/// <param name="lpBoundaryDescriptor">
	/// A descriptor that defines how the namespace is to be isolated. The <c>CreateBoundaryDescriptor</c> function creates a boundary descriptor.
	/// </param>
	/// <param name="lpAliasPrefix">
	/// The prefix for the namespace. To create an object in this namespace, specify the object name as prefix\objectname.
	/// </param>
	/// <returns>The function returns the handle to the existing namespace.</returns>
	[DllImport(Lib.Kernel32, SetLastError = false, CharSet = CharSet.Auto, EntryPoint = "OpenPrivateNamespace")]
	[PInvokeData("WinBase.h", MSDNShortId = "ms684318")]
	private static extern SafeNamespaceHandle OpenPrivateNamespaceInternal([In] BoundaryDescriptorHandle lpBoundaryDescriptor, string lpAliasPrefix);

	public partial class SafeBoundaryDescriptorHandle
	{
		/// <summary>Adds a security identifier (SID) to the boundary descriptor.</summary>
		/// <param name="pSid">A pointer to a <c>SID</c> structure.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		public bool AddSid(PSID pSid)
		{
			BoundaryDescriptorHandle h = handle;
			return Marshal.ReadByte(pSid.DangerousGetHandle(), 7) == 16
				? AddIntegrityLabelToBoundaryDescriptor(ref h, pSid)
				: AddSIDToBoundaryDescriptor(ref h, pSid);
		}
	}

	public partial class SafeNamespaceHandle
	{
		internal uint flag = PRIVATE_NAMESPACE_FLAG_DESTROY;
	}
}