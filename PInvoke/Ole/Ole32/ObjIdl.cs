using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using Vanara.Extensions;
using Vanara.InteropServices;
using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;
using STATSTG = System.Runtime.InteropServices.ComTypes.STATSTG;

namespace Vanara.PInvoke
{
	public static partial class Ole32
	{
		/// <summary>
		/// <para>Specifies various capabilities in CoInitializeSecurity and IClientSecurity::SetBlanket (or its helper function CoSetProxyBlanket).</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// When the EOAC_APPID flag is set, CoInitializeSecurity looks for the authentication level under the AppID. If the authentication
		/// level is not found, it looks for the default authentication level. If the default authentication level is not found, it generates
		/// a default authentication level of connect. If the authentication level is not RPC_C_AUTHN_LEVEL_NONE, <c>CoInitializeSecurity</c>
		/// looks for the access permission value under the AppID. If not found, it looks for the default access permission value. If not
		/// found, it generates a default access permission. All the other security settings are determined the same way as for a legacy application.
		/// </para>
		/// <para>
		/// If the AppID is NULL, <c>CoInitializeSecurity</c> looks up the application .exe name in the registry and uses the AppID stored
		/// there. If the AppID does not exist, the machine defaults are used.
		/// </para>
		/// <para>
		/// The IClientSecurity::SetBlanket method and CoSetProxyBlanket function return an error if any of the following flags are set in
		/// the capabilities parameter: EOAC_SECURE_REFS, EOAC_ACCESS_CONTROL, EOAC_APPID, EOAC_DYNAMIC, EOAC_REQUIRE_FULLSIC,
		/// EOAC_DISABLE_AAA, or EOAC_NO_CUSTOM_MARSHAL.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidlbase/ne-objidlbase-tageole_authentication_capabilities typedef enum
		// tagEOLE_AUTHENTICATION_CAPABILITIES { EOAC_NONE , EOAC_MUTUAL_AUTH , EOAC_STATIC_CLOAKING , EOAC_DYNAMIC_CLOAKING ,
		// EOAC_ANY_AUTHORITY , EOAC_MAKE_FULLSIC , EOAC_DEFAULT , EOAC_SECURE_REFS , EOAC_ACCESS_CONTROL , EOAC_APPID , EOAC_DYNAMIC ,
		// EOAC_REQUIRE_FULLSIC , EOAC_AUTO_IMPERSONATE , EOAC_DISABLE_AAA , EOAC_NO_CUSTOM_MARSHAL , EOAC_RESERVED1 } EOLE_AUTHENTICATION_CAPABILITIES;
		[PInvokeData("objidlbase.h", MSDNShortId = "cf3396d0-6674-4f12-bd4a-227a8d32bc92")]
		[Flags]
		public enum EOLE_AUTHENTICATION_CAPABILITIES : uint
		{
			/// <summary>Indicates that no capability flags are set.</summary>
			EOAC_NONE = 0x0000,

			/// <summary>
			/// If this flag is specified, it will be ignored. Support for mutual authentication is automatically provided by some
			/// authentication services. See COM and Security Packages for more information.
			/// </summary>
			EOAC_MUTUAL_AUTH = 0x0001,

			/// <summary>
			/// Sets static cloaking. When this flag is set, DCOM uses the thread token (if present) when determining the client's identity.
			/// However, the client's identity is determined on the first call on each proxy (if SetBlanket is not called) and each time
			/// CoSetProxyBlanket is called on the proxy. For more information about static cloaking, see Cloaking. CoInitializeSecurity and
			/// IClientSecurity::SetBlanket return errors if both cloaking flags are set or if either flag is set when Schannel is the
			/// authentication service.
			/// </summary>
			EOAC_STATIC_CLOAKING = 0x0020,

			/// <summary>
			/// Sets dynamic cloaking. When this flag is set, DCOM uses the thread token (if present) when determining the client's identity.
			/// On each call to a proxy, the current thread token is examined to determine whether the client's identity has changed
			/// (incurring an additional performance cost) and the client is authenticated again only if necessary. Dynamic cloaking can be
			/// set by clients only. For more information about dynamic cloaking, see Cloaking. CoInitializeSecurity and
			/// IClientSecurity::SetBlanket return errors if both cloaking flags are set or if either flag is set when Schannel is the
			/// authentication service.
			/// </summary>
			EOAC_DYNAMIC_CLOAKING = 0x0040,

			/// <summary>This flag is obsolete.</summary>
			EOAC_ANY_AUTHORITY = 0x0080,

			/// <summary>
			/// Causes DCOM to send Schannel server principal names in fullsic format to clients as part of the default security negotiation.
			/// The name is extracted from the server certificate. For more information about the fullsic form, see Principal Names.
			/// </summary>
			EOAC_MAKE_FULLSIC = 0x0100,

			/// <summary>
			/// Tells DCOM to use the valid capabilities from the call to CoInitializeSecurity. If CoInitializeSecurity was not called,
			/// EOAC_NONE will be used for the capabilities flag. This flag can be set only by clients in a call to
			/// IClientSecurity::SetBlanket or CoSetProxyBlanket.
			/// </summary>
			EOAC_DEFAULT = 0x0800,

			/// <summary>
			/// Authenticates distributed reference count calls to prevent malicious users from releasing objects that are still being used.
			/// If this flag is set, which can be done only in a call to CoInitializeSecurity by the client, the authentication level (in
			/// dwAuthnLevel) cannot be set to none. The server always authenticates Release calls. Setting this flag prevents an
			/// authenticated client from releasing the objects of another authenticated client. It is recommended that clients always set
			/// this flag, although performance is affected because of the overhead associated with the extra security.
			/// </summary>
			EOAC_SECURE_REFS = 0x0002,

			/// <summary>
			/// Indicates that the pSecDesc parameter to CoInitializeSecurity is a pointer to a GUID that is an AppID. The
			/// CoInitializeSecurity function looks up the AppID in the registry and reads the security settings from there. If this flag is
			/// set, all other parameters to CoInitializeSecurity are ignored and must be zero. Only the server can set this flag. For more
			/// information about this capability flag, see the Remarks section below. CoInitializeSecurity returns an error if both the
			/// EOAC_APPID and EOAC_ACCESS_CONTROL flags are set.
			/// </summary>
			EOAC_APPID = 0x0008,

			/// <summary>
			/// Specifying this flag helps protect server security when using DCOM or COM+. It reduces the chances of executing arbitrary
			/// DLLs because it allows the marshaling of only CLSIDs that are implemented in Ole32.dll, ComAdmin.dll, ComSvcs.dll, or Es.dll,
			/// or that implement the CATID_MARSHALER category ID. Any service that is critical to system operation should set this flag.
			/// </summary>
			EOAC_NO_CUSTOM_MARSHAL = 0x2000,

			/// <summary/>
			EOAC_RESERVED1 = 0x4000,

			/// <summary>
			/// Indicates that the pSecDesc parameter to CoInitializeSecurity is a pointer to an IAccessControl interface on an access
			/// control object. When DCOM makes security checks, it calls IAccessControl::IsAccessAllowed. This flag is set only by the
			/// server. CoInitializeSecurity returns an error if both the EOAC_APPID and EOAC_ACCESS_CONTROL flags are set.
			/// </summary>
			EOAC_ACCESS_CONTROL = 0x0004,

			/// <summary>Reserved.</summary>
			EOAC_DYNAMIC = 0x0010,

			/// <summary>
			/// Causes DCOM to fail CoSetProxyBlanket calls where an Schannel principal name is specified in any format other than fullsic.
			/// This flag is currently for clients only. For more information about the fullsic form, see Principal Names.
			/// </summary>
			EOAC_REQUIRE_FULLSIC = 0x0200,

			/// <summary>Reserved.</summary>
			EOAC_AUTO_IMPERSONATE = 0x0400,

			/// <summary>
			/// Causes any activation where a server process would be launched under the caller's identity (activate-as-activator) to fail
			/// with E_ACCESSDENIED. This value, which can be specified only in a call to CoInitializeSecurity by the client, allows an
			/// application that runs under a privileged account (such as LocalSystem) to help prevent its identity from being used to launch
			/// untrusted components. An activation call that uses CLSCTX_ENABLE_AAA of the CLSCTX enumeration will allow
			/// activate-as-activator activations for that call.
			/// </summary>
			EOAC_DISABLE_AAA = 0x1000,
		}

		/// <summary>
		/// The IEnumSTATSTG interface enumerates an array of STATSTG structures. These structures contain statistical data about open
		/// storage, stream, or byte array objects.
		/// </summary>
		[ComImport, Guid("0000000D-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		[PInvokeData("Objidl.h", MSDNShortId = "aa379217")]
		public interface IEnumSTATSTG
		{
			/// <summary>
			/// The Next method retrieves a specified number of STATSTG structures, that follow in the enumeration sequence. If there are
			/// fewer than the requested number of STATSTG structures that remain in the enumeration sequence, it retrieves the remaining
			/// STATSTG structures.
			/// </summary>
			/// <param name="celt">The number of STATSTG structures requested.</param>
			/// <param name="rgelt">An array of STATSTG structures returned.</param>
			/// <param name="pceltFetched">The number of STATSTG structures retrieved in the rgelt parameter.</param>
			/// <returns>
			/// This method supports the following return values: S_OK = The number of STATSTG structures returned is equal to the number
			/// specified in the celt parameter. S_FALSE = The number of STATSTG structures returned is less than the number specified in the
			/// celt parameter.
			/// </returns>
			[PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
			HRESULT Next([In] uint celt,
				[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] STATSTG[] rgelt,
				out uint pceltFetched);

			/// <summary>Skips a specified number of STATSTG structures in the enumeration sequence.</summary>
			/// <param name="celt">The number of STATSTG structures to skip.</param>
			/// <returns>
			/// This method supports the following return values: S_OK = The specified number of STATSTG structures that were successfully
			/// skipped. S_FALSE = The number of STATSTG structures skipped is less than the celt parameter.
			/// </returns>
			[PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
			HRESULT Skip([In] uint celt);

			/// <summary>Resets the enumeration sequence to the beginning of the STATSTG structure array.</summary>
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
			void Reset();

			/// <summary>Creates a new enumerator that contains the same enumeration state as the current STATSTG structure enumerator.</summary>
			/// <returns>An IEnumSTATSTG interface pointer.</returns>
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IEnumSTATSTG Clone();
		}

		/// <summary>
		/// The IStorage interface supports the creation and management of structured storage objects. Structured storage allows hierarchical
		/// storage of information within a single file, and is often referred to as "a file system within a file". Elements of a structured
		/// storage object are storages and streams. Storages are analogous to directories, and streams are analogous to files. Within a
		/// structured storage there will be a primary storage object that may contain substorages, possibly nested, and streams. Storages
		/// provide the structure of the object, and streams contain the data, which is manipulated through the IStream interface.
		/// <para>
		/// The IStorage interface provides methods for creating and managing the root storage object, child storage objects, and stream
		/// objects. These methods can create, open, enumerate, move, copy, rename, or delete the elements in the storage object.
		/// </para>
		/// <para>
		/// An application must release its IStorage pointers when it is done with the storage object to deallocate memory used. There are
		/// also methods for changing the date and time of an element.
		/// </para>
		/// <para>
		/// There are a number of different modes in which a storage object and its elements can be opened, determined by setting values from
		/// STGM Constants. One aspect of this is how changes are committed. You can set direct mode, in which changes to an object are
		/// immediately written to it, or transacted mode, in which changes are written to a buffer until explicitly committed. The IStorage
		/// interface provides methods for committing changes and reverting to the last-committed version. For example, a stream can be
		/// opened in read-only mode or read/write mode. For more information, see STGM Constants.
		/// </para>
		/// <para>Other methods provide access to information about a storage object and its elements through the STATSTG structure.</para>
		/// </summary>
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), ComConversionLoss, Guid("0000000B-0000-0000-C000-000000000046")]
		[PInvokeData("Objidl.h", MSDNShortId = "aa380015")]
		public interface IStorage
		{
			/// <summary>
			/// The CreateStream method creates and opens a stream object with the specified name contained in this storage object. All
			/// elements within a storage objects, both streams and other storage objects, are kept in the same name space.
			/// </summary>
			/// <param name="pwcsName">
			/// A string that contains the name of the newly created stream. The name can be used later to open or reopen the stream. The
			/// name must not exceed 31 characters in length, not including the string terminator. The 000 through 01f characters, serving as
			/// the first character of the stream/storage name, are reserved for use by OLE. This is a compound file restriction, not a
			/// structured storage restriction.
			/// </param>
			/// <param name="grfMode">
			/// Specifies the access mode to use when opening the newly created stream. For more information and descriptions of the possible
			/// values, see STGM Constants.
			/// </param>
			/// <param name="reserved1">Reserved for future use; must be zero.</param>
			/// <param name="reserved2">Reserved for future use; must be zero.</param>
			/// <returns>On return, the new IStream interface pointer.</returns>
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IStream CreateStream([In, MarshalAs(UnmanagedType.LPWStr)] string pwcsName,
				[In] STGM grfMode,
				[In] uint reserved1,
				[In] uint reserved2);

			/// <summary>The OpenStream method opens an existing stream object within this storage object in the specified access mode.</summary>
			/// <param name="pwcsName">
			/// A string that contains the name of the stream to open. The 000 through 01f characters, serving as the first character of the
			/// stream/storage name, are reserved for use by OLE. This is a compound file restriction, not a structured storage restriction.
			/// </param>
			/// <param name="reserved1">Reserved for future use; must be NULL.</param>
			/// <param name="grfMode">
			/// Specifies the access mode to be assigned to the open stream. For more information and descriptions of possible values, see
			/// STGM Constants. Other modes you choose must at least specify STGM_SHARE_EXCLUSIVE when calling this method in the compound
			/// file implementation.
			/// </param>
			/// <param name="reserved2">Reserved for future use; must be zero.</param>
			/// <returns>A IStream interface pointer to the newly opened stream object.</returns>
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IStream OpenStream([In, MarshalAs(UnmanagedType.LPWStr)] string pwcsName, [In] IntPtr reserved1,
				[In] STGM grfMode,
				[In] uint reserved2);

			/// <summary>
			/// The CreateStorage method creates and opens a new storage object nested within this storage object with the specified name in
			/// the specified access mode.
			/// </summary>
			/// <param name="pwcsName">
			/// A string that contains the name of the newly created storage object. The name can be used later to reopen the storage object.
			/// The name must not exceed 31 characters in length, not including the string terminator. The 000 through 01f characters,
			/// serving as the first character of the stream/storage name, are reserved for use by OLE. This is a compound file restriction,
			/// not a structured storage restriction.
			/// </param>
			/// <param name="grfMode">
			/// A value that specifies the access mode to use when opening the newly created storage object. For more information and a
			/// description of possible values, see STGM Constants.
			/// </param>
			/// <param name="reserved1">Reserved for future use; must be zero.</param>
			/// <param name="reserved2">Reserved for future use; must be zero.</param>
			/// <returns>On return, the new IStorage interface pointer.</returns>
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IStorage CreateStorage([In, MarshalAs(UnmanagedType.LPWStr)] string pwcsName,
				[In] STGM grfMode,
				[In] uint reserved1,
				[In] uint reserved2);

			/// <summary>The OpenStorage method opens an existing storage object with the specified name in the specified access mode.</summary>
			/// <param name="pwcsName">
			/// A string that contains the name of the storage object to open. The 000 through 01f characters, serving as the first character
			/// of the stream/storage name, are reserved for use by OLE. This is a compound file restriction, not a structured storage
			/// restriction. It is ignored if pstgPriority is non-NULL.
			/// </param>
			/// <param name="pstgPriority">Must be NULL. A non-NULL value will return STG_E_INVALIDPARAMETER.</param>
			/// <param name="grfMode">
			/// Specifies the access mode to use when opening the storage object. For descriptions of the possible values, see STGM
			/// Constants. Other modes you choose must at least specify STGM_SHARE_EXCLUSIVE when calling this method.
			/// </param>
			/// <param name="snbExclude">Must be NULL. A non-NULL value will return STG_E_INVALIDPARAMETER.</param>
			/// <param name="reserved">Reserved for future use; must be zero.</param>
			/// <returns>On return, the IStorage interface pointer to the opened storage.</returns>
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IStorage OpenStorage([In, MarshalAs(UnmanagedType.LPWStr)] string pwcsName,
				[In, MarshalAs(UnmanagedType.Interface)] IStorage pstgPriority,
				[In] STGM grfMode,
				[In] SNB snbExclude,
				[In] uint reserved);

			/// <summary>The CopyTo method copies the entire contents of an open storage object to another storage object.</summary>
			/// <param name="ciidExclude">
			/// The number of elements in the array pointed to by rgiidExclude. If rgiidExclude is NULL, then ciidExclude is ignored.
			/// </param>
			/// <param name="rgiidExclude">
			/// An array of interface identifiers (IIDs) that either the caller knows about and does not want copied or that the storage
			/// object does not support, but whose state the caller will later explicitly copy. The array can include IStorage, indicating
			/// that only stream objects are to be copied, and IStream, indicating that only storage objects are to be copied. An array
			/// length of zero indicates that only the state exposed by the IStorage object is to be copied; all other interfaces on the
			/// object are to be ignored. Passing NULL indicates that all interfaces on the object are to be copied.
			/// </param>
			/// <param name="snbExclude">
			/// A string name block (refer to SNB) that specifies a block of storage or stream objects that are not to be copied to the
			/// destination. These elements are not created at the destination. If IID_IStorage is in the rgiidExclude array, this parameter
			/// is ignored. This parameter may be NULL.
			/// </param>
			/// <param name="pstgDest">
			/// A pointer to the open storage object into which this storage object is to be copied. The destination storage object can be a
			/// different implementation of the IStorage interface from the source storage object. Thus, IStorage::CopyTo can use only
			/// publicly available methods of the destination storage object. If pstgDest is open in transacted mode, it can be reverted by
			/// calling its IStorage::Revert method.
			/// </param>
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
			void CopyTo([In] uint ciidExclude,
				[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] Guid[] rgiidExclude,
				[In] SNB snbExclude,
				[In, MarshalAs(UnmanagedType.Interface)] IStorage pstgDest);

			/// <summary>
			/// The MoveElementTo method copies or moves a substorage or stream from this storage object to another storage object.
			/// </summary>
			/// <param name="pwcsName">A string that contains the name of the element in this storage object to be moved or copied.</param>
			/// <param name="pstgDest">IStorage pointer to the destination storage object.</param>
			/// <param name="pwcsNewName">A string that contains the new name for the element in its new storage object.</param>
			/// <param name="grfFlags">
			/// Specifies whether the operation should be a move (STGMOVE_MOVE) or a copy (STGMOVE_COPY). See the STGMOVE enumeration.
			/// </param>
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
			void MoveElementTo([In, MarshalAs(UnmanagedType.LPWStr)] string pwcsName,
				[In, MarshalAs(UnmanagedType.Interface)] IStorage pstgDest, [In, MarshalAs(UnmanagedType.LPWStr)] string pwcsNewName,
				[In] STGMOVE grfFlags);

			/// <summary>
			/// The Commit method ensures that any changes made to a storage object open in transacted mode are reflected in the parent
			/// storage. For nonroot storage objects in direct mode, this method has no effect. For a root storage, it reflects the changes
			/// in the actual device; for example, a file on disk. For a root storage object opened in direct mode, always call the
			/// IStorage::Commit method prior to Release. IStorage::Commit flushes all memory buffers to the disk for a root storage in
			/// direct mode and will return an error code upon failure. Although Release also flushes memory buffers to disk, it has no
			/// capacity to return any error codes upon failure. Therefore, calling Release without first calling Commit causes indeterminate results.
			/// </summary>
			/// <param name="grfCommitFlags">
			/// Controls how the changes are committed to the storage object. See the STGC enumeration for a definition of these values.
			/// </param>
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
			void Commit([In] STGC grfCommitFlags);

			/// <summary>The Revert method discards all changes that have been made to the storage object since the last commit operation.</summary>
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
			void Revert();

			/// <summary>
			/// The EnumElements method retrieves a pointer to an enumerator object that can be used to enumerate the storage and stream
			/// objects contained within this storage object.
			/// </summary>
			/// <param name="reserved1">Reserved for future use; must be zero.</param>
			/// <param name="reserved2">Reserved for future use; must be <c>NULL</c>.</param>
			/// <param name="reserved3">Reserved for future use; must be zero.</param>
			/// <returns>The interface pointer to the new enumerator object.</returns>
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IEnumSTATSTG EnumElements([In] uint reserved1, [In] IntPtr reserved2, [In] uint reserved3);

			/// <summary>The DestroyElement method removes the specified storage or stream from this storage object.</summary>
			/// <param name="pwcsName">A string that contains the name of the storage or stream to be removed.</param>
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
			void DestroyElement([In, MarshalAs(UnmanagedType.LPWStr)] string pwcsName);

			/// <summary>The RenameElement method renames the specified substorage or stream in this storage object.</summary>
			/// <param name="pwcsOldName">A string that contains the name of the substorage or stream to be changed.</param>
			/// <param name="pwcsNewName">A string that contains the new name for the specified substorage or stream.</param>
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
			void RenameElement([In, MarshalAs(UnmanagedType.LPWStr)] string pwcsOldName,
				[In, MarshalAs(UnmanagedType.LPWStr)] string pwcsNewName);

			/// <summary>
			/// The SetElementTimes method sets the modification, access, and creation times of the specified storage element, if the
			/// underlying file system supports this method.
			/// </summary>
			/// <param name="pwcsName">
			/// The name of the storage object element whose times are to be modified. If NULL, the time is set on the root storage rather
			/// than one of its elements.
			/// </param>
			/// <param name="pctime">
			/// Either the new creation time as the first element of the array for the element or NULL if the creation time is not to be modified.
			/// </param>
			/// <param name="patime">
			/// Either the new access time as the first element of the array for the element or NULL if the access time is not to be modified.
			/// </param>
			/// <param name="pmtime">
			/// Either the new modification time as the first element of the array for the element or NULL if the modification time is not to
			/// be modified.
			/// </param>
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
			void SetElementTimes([In, MarshalAs(UnmanagedType.LPWStr)] string pwcsName,
				[In, MarshalAs(UnmanagedType.LPArray, SizeConst = 1)] FILETIME[] pctime,
				[In, MarshalAs(UnmanagedType.LPArray, SizeConst = 1)] FILETIME[] patime,
				[In, MarshalAs(UnmanagedType.LPArray, SizeConst = 1)] FILETIME[] pmtime);

			/// <summary>The SetClass method assigns the specified class identifier (CLSID) to this storage object.</summary>
			/// <param name="clsid">The CLSID that is to be associated with the storage object.</param>
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
			void SetClass(in Guid clsid);

			/// <summary>
			/// The SetStateBits method stores up to 32 bits of state information in this storage object. This method is reserved for future use.
			/// </summary>
			/// <param name="grfStateBits">
			/// Specifies the new values of the bits to set. No legal values are defined for these bits; they are all reserved for future use
			/// and must not be used by applications.
			/// </param>
			/// <param name="grfMask">A binary mask indicating which bits in grfStateBits are significant in this call.</param>
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
			void SetStateBits([In] uint grfStateBits, [In] uint grfMask);

			/// <summary>The Stat method retrieves the STATSTG structure for this open storage object.</summary>
			/// <param name="pstatstg">
			/// On return, pointer to a STATSTG structure where this method places information about the open storage object. This parameter
			/// is NULL if an error occurs.
			/// </param>
			/// <param name="grfStatFlag">
			/// Specifies that some of the members in the STATSTG structure are not returned, thus saving a memory allocation operation.
			/// Values are taken from the STATFLAG enumeration.
			/// </param>
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
			void Stat(out STATSTG pstatstg, [In] STATFLAG grfStatFlag);
		}

		/// <summary>
		/// Identifies an authentication service, authorization service, and the authentication information for the specified authentication service.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/ns-objidl-tagsole_authentication_info typedef struct
		// tagSOLE_AUTHENTICATION_INFO { DWORD dwAuthnSvc; DWORD dwAuthzSvc; void *pAuthInfo; } SOLE_AUTHENTICATION_INFO, *PSOLE_AUTHENTICATION_INFO;
		[PInvokeData("objidl.h", MSDNShortId = "23beb1b1-e4b7-4282-9868-5caf40a69a61")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct SOLE_AUTHENTICATION_INFO
		{
			/// <summary>
			/// <para>The authentication service. This member can be a single value from the Authentication Service Constants.</para>
			/// </summary>
			public RPC_C_AUTHN_LEVEL dwAuthnSvc;

			/// <summary>
			/// <para>The authorization service. This member can be a single value from the Authorization Constants.</para>
			/// </summary>
			public RPC_C_AUTHZ dwAuthzSvc;

			/// <summary>
			/// <para>A pointer to the authentication information, whose type is specific to the authentication service identified by <c>dwAuthnSvc</c>.</para>
			/// <para>
			/// For Schannel (RPC_C_AUTHN_GSS_SCHANNEL), this member either points to a CERT_CONTEXT structure that contains the client's
			/// X.509 certificate or is <c>NULL</c> if the client has no certificate or wishes to remain anonymous to the server.
			/// </para>
			/// <para>
			/// For NTLMSSP (RPC_C_AUTHN_WINNT) and Kerberos (RPC_C_AUTHN_GSS_KERBEROS), this member points to a SEC_WINNT_AUTH_IDENTITY or
			/// SEC_WINNT_AUTH_IDENTITY_EX structure that contains the user name and password.
			/// </para>
			/// <para>
			/// For Snego (RPC_C_AUTHN_GSS_NEGOTIATE), this member is either <c>NULL</c>, points to a SEC_WINNT_AUTH_IDENTITY structure, or
			/// points to a SEC_WINNT_AUTH_IDENTITY_EX structure. If it is <c>NULL</c>, Snego will pick a list of authentication services
			/// based on those available on the client computer. If it points to a <c>SEC_WINNT_AUTH_IDENTITY_EX</c> structure, the
			/// structure's <c>PackageList</c> member must point to a string containing a comma-separated list of authentication service
			/// names and the <c>PackageListLength</c> member must give the number of bytes in the <c>PackageList</c> string. If
			/// <c>PackageList</c> is <c>NULL</c>, all calls using Snego will fail.
			/// </para>
			/// <para>
			/// For authentication services not registered with DCOM, <c>pAuthInfo</c> must be set to <c>NULL</c> and DCOM will use the
			/// process identity to represent the client. For more information, see COM and Security Packages.
			/// </para>
			/// </summary>
			public IntPtr pAuthInfo;
		}

		/// <summary>
		/// Indicates the default authentication information to use with each authentication service. When DCOM negotiates the default
		/// authentication service for a proxy, it picks the default authentication information from this list.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/ns-objidl-tagsole_authentication_list typedef struct
		// tagSOLE_AUTHENTICATION_LIST { DWORD cAuthInfo; SOLE_AUTHENTICATION_INFO *aAuthInfo; } SOLE_AUTHENTICATION_LIST, *PSOLE_AUTHENTICATION_LIST;
		[PInvokeData("objidl.h", MSDNShortId = "21f7aef3-b6be-41cc-a6ed-16d3778e3cee")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct SOLE_AUTHENTICATION_LIST
		{
			/// <summary>
			/// <para>The count of pointers in the array pointed to by <c>aAuthInfo</c>.</para>
			/// </summary>
			public uint cAuthInfo;

			/// <summary>
			/// An array of SOLE_AUTHENTICATION_INFO structures. Each of these structures contains an identifier for an authentication
			/// service, an identifier for the authorization service, and a pointer to authentication information to use with the specified
			/// authentication service.
			/// </summary>
			public IntPtr aAuthInfo;
		}

		/// <summary>
		/// <para>Identifies an authentication service that a server is willing to use to communicate to a client.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/ns-objidl-tagsole_authentication_service typedef struct
		// tagSOLE_AUTHENTICATION_SERVICE { DWORD dwAuthnSvc; DWORD dwAuthzSvc; OLECHAR *pPrincipalName; HRESULT hr; } SOLE_AUTHENTICATION_SERVICE;
		[PInvokeData("objidl.h", MSDNShortId = "77fd15d7-54d4-4812-93d3-13a671e7afff")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct SOLE_AUTHENTICATION_SERVICE
		{
			/// <summary>
			/// <para>The authentication service. This member can be a single value from the Authentication Service Constants.</para>
			/// </summary>
			public RPC_C_AUTHN_LEVEL dwAuthnSvc;

			/// <summary>
			/// <para>The authorization service. This member can be a single value from the Authorization Constants.</para>
			/// </summary>
			public RPC_C_AUTHZ dwAuthzSvc;

			/// <summary>
			/// The principal name to be used with the authentication service. If the principal name is <c>NULL</c>, the current user
			/// identifier is assumed. A <c>NULL</c> principal name is allowed for NTLMSSP, Kerberos, and Snego authentication services but
			/// may not work for other authentication services. For Schannel, this member must point to a CERT_CONTEXT structure that
			/// contains the server's certificate; if it <c>NULL</c> and if a certificate for the current user does not exist,
			/// RPC_E_NO_GOOD_SECURITY_PACKAGES is returned.
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string pPrincipalName;

			/// <summary>
			/// When used in CoInitializeSecurity, set on return to indicate the status of the call to register the authentication services.
			/// </summary>
			public HRESULT hr;
		}

		/// <summary>
		/// A string name block (SNB) is a pointer to an array of pointers to strings, that ends in a NULL pointer. String name blocks are
		/// used by the IStorage interface and by function calls that open storage objects. The strings point to contained storage objects or
		/// streams that are to be excluded in the open calls.
		/// </summary>
		/// <seealso cref="System.IDisposable"/>
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public class SNB : IDisposable
		{
			private SafeCoTaskMemHandle ptr;

			/// <summary>Initializes a new instance of the <see cref="SNB"/> class.</summary>
			/// <param name="names">The list of names to associate with this instance.</param>
			public SNB(IEnumerable<string> names) => ptr = names == null ? SafeCoTaskMemHandle.Null : SafeCoTaskMemHandle.CreateFromStringList(names, StringListPackMethod.Packed, CharSet.Unicode);

			/// <summary>Prevents a default instance of the <see cref="SNB"/> class from being created.</summary>
			private SNB() { }

			/// <summary>Initializes a new instance of the <see cref="SNB"/> class.</summary>
			/// <param name="p">The native pointer.</param>
			private SNB(IntPtr p) => ptr = new SafeCoTaskMemHandle(p, 0, true);

			/// <summary>Gets the names.</summary>
			/// <value>The names.</value>
			public IEnumerable<string> Names => ptr.ToStringEnum(Count, CharSet.Unicode);

			private int Count => ptr.DangerousGetHandle().GetNulledPtrArrayLength();

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="SNB"/>.</summary>
			/// <param name="p">The native pointer to take ownership of.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator SNB(IntPtr p) => new SNB(p);

			/// <summary>Performs an implicit conversion from <see cref="IEnumerable{T}"/> to <see cref="SNB"/>.</summary>
			/// <param name="names">The names.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator SNB(string[] names) => new SNB(names);

			/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
			void IDisposable.Dispose() => ptr?.Dispose();
		}
	}
}