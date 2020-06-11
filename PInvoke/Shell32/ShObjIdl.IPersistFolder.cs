using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using static Vanara.PInvoke.Ole32;

namespace Vanara.PInvoke
{
	public static partial class Shell32
	{
		/// <summary>Exposes a method that initializes Shell folder objects.</summary>
		/// <remarks>
		/// <para>
		/// When you implement a Shell namespace extension, specifically the IShellFolder interface, you must implement this interface so
		/// the folder object can be initialized. Implementation of this interface is how the folder is told where it is in the Shell namespace.
		/// </para>
		/// <para>
		/// You do not use this interface directly. It is used by the file system implementation of the IShellFolder::BindToObject interface
		/// when it is initializing a Shell folder object.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-ipersistfolder
		[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.IPersistFolder")]
		[ComImport, Guid("000214EA-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IPersistFolder : IPersist
		{
			/// <summary>Retrieves the class identifier (CLSID) of the object.</summary>
			/// <returns>
			/// <para>
			/// A pointer to the location that receives the CLSID on return. The CLSID is a globally unique identifier (GUID) that uniquely
			/// represents an object class that defines the code that can manipulate the object's data.
			/// </para>
			/// <para>If the method succeeds, the return value is S_OK. Otherwise, it is E_FAIL.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// The <c>GetClassID</c> method retrieves the class identifier (CLSID) for an object, used in later operations to load
			/// object-specific code into the caller's context.
			/// </para>
			/// <para>Notes to Callers</para>
			/// <para>
			/// A container application might call this method to retrieve the original CLSID of an object that it is treating as a
			/// different class. Such a call would be necessary if a user performed an editing operation that required the object to be
			/// saved. If the container were to save it using the treat-as CLSID, the original application would no longer be able to edit
			/// the object. Typically, in this case, the container calls the OleSave helper function, which performs all the necessary
			/// steps. For this reason, most container applications have no need to call this method directly.
			/// </para>
			/// <para>
			/// The exception would be a container that provides an object handler for certain objects. In particular, a container
			/// application should not get an object's CLSID and then use it to retrieve class specific information from the registry.
			/// Instead, the container should use IOleObject and IDataObject interfaces to retrieve such class-specific information directly
			/// from the object.
			/// </para>
			/// <para>Notes to Implementers</para>
			/// <para>
			/// Typically, implementations of this method simply supply a constant CLSID for an object. If, however, the object's
			/// <c>TreatAs</c> registry key has been set by an application that supports emulation (and so is treating the object as one of
			/// a different class), a call to <c>GetClassID</c> must supply the CLSID specified in the <c>TreatAs</c> key. For more
			/// information on emulation, see CoTreatAsClass.
			/// </para>
			/// <para>
			/// When an object is in the running state, the default handler calls an implementation of <c>GetClassID</c> that delegates the
			/// call to the implementation in the object. When the object is not running, the default handler instead calls the ReadClassStg
			/// function to read the CLSID that is saved in the object's storage.
			/// </para>
			/// <para>
			/// If you are writing a custom object handler for your object, you might want to simply delegate this method to the default
			/// handler implementation (see OleCreateDefaultHandler).
			/// </para>
			/// <para>URL Moniker Notes</para>
			/// <para>This method returns CLSID_StdURLMoniker.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ipersist-getclassid HRESULT GetClassID( CLSID *pClassID );
			new Guid GetClassID();

			/// <summary>Instructs a Shell folder object to initialize itself based on the information passed.</summary>
			/// <param name="pidl">
			/// <para>Type: <c>LPCITEMIDLIST</c></para>
			/// <para>The address of the ITEMIDLIST (item identifier list) structure that specifies the absolute location of the folder.</para>
			/// </param>
			/// <remarks>
			/// <para>
			/// All objects that implement the IShellFolder interface for use in the Shell's namespace must implement this method. When a
			/// folder's location in the namespace is not a relevant consideration, this method can simply return S_OK. When the location is
			/// relevant to the folder, you should store the fully qualified IDLIST passed in for later reference.
			/// </para>
			/// <para>
			/// For example, if the folder implementation needs to construct a fully qualified pointer to an item identifier list (PIDL) to
			/// elements that it contains, the PIDL passed to this method should be used to construct the fully qualified PIDLs.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ipersistfolder-initialize HRESULT
			// Initialize( PCIDLIST_ABSOLUTE pidl );
			void Initialize([In] PIDL pidl);
		}

		/// <summary>Exposes methods that obtain information from Shell folder objects.</summary>
		/// <remarks>
		/// <para>This interface also provides the methods of the IPersist, IPersistFolder interfaces, from which it inherits.</para>
		/// <para>When to Implement</para>
		/// <para>
		/// When implementing a Shell namespace extension, specifically the IShellFolder interface, you need to implement this interface so
		/// that the Shell folder object's ITEMIDLIST can be retrieved.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-ipersistfolder2
		[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.IPersistFolder2")]
		[ComImport, Guid("1AC3D9F0-175C-11d1-95BE-00609797EA4F"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IPersistFolder2 : IPersistFolder
		{
			/// <summary>Retrieves the class identifier (CLSID) of the object.</summary>
			/// <returns>
			/// <para>
			/// A pointer to the location that receives the CLSID on return. The CLSID is a globally unique identifier (GUID) that uniquely
			/// represents an object class that defines the code that can manipulate the object's data.
			/// </para>
			/// <para>If the method succeeds, the return value is S_OK. Otherwise, it is E_FAIL.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// The <c>GetClassID</c> method retrieves the class identifier (CLSID) for an object, used in later operations to load
			/// object-specific code into the caller's context.
			/// </para>
			/// <para>Notes to Callers</para>
			/// <para>
			/// A container application might call this method to retrieve the original CLSID of an object that it is treating as a
			/// different class. Such a call would be necessary if a user performed an editing operation that required the object to be
			/// saved. If the container were to save it using the treat-as CLSID, the original application would no longer be able to edit
			/// the object. Typically, in this case, the container calls the OleSave helper function, which performs all the necessary
			/// steps. For this reason, most container applications have no need to call this method directly.
			/// </para>
			/// <para>
			/// The exception would be a container that provides an object handler for certain objects. In particular, a container
			/// application should not get an object's CLSID and then use it to retrieve class specific information from the registry.
			/// Instead, the container should use IOleObject and IDataObject interfaces to retrieve such class-specific information directly
			/// from the object.
			/// </para>
			/// <para>Notes to Implementers</para>
			/// <para>
			/// Typically, implementations of this method simply supply a constant CLSID for an object. If, however, the object's
			/// <c>TreatAs</c> registry key has been set by an application that supports emulation (and so is treating the object as one of
			/// a different class), a call to <c>GetClassID</c> must supply the CLSID specified in the <c>TreatAs</c> key. For more
			/// information on emulation, see CoTreatAsClass.
			/// </para>
			/// <para>
			/// When an object is in the running state, the default handler calls an implementation of <c>GetClassID</c> that delegates the
			/// call to the implementation in the object. When the object is not running, the default handler instead calls the ReadClassStg
			/// function to read the CLSID that is saved in the object's storage.
			/// </para>
			/// <para>
			/// If you are writing a custom object handler for your object, you might want to simply delegate this method to the default
			/// handler implementation (see OleCreateDefaultHandler).
			/// </para>
			/// <para>URL Moniker Notes</para>
			/// <para>This method returns CLSID_StdURLMoniker.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ipersist-getclassid HRESULT GetClassID( CLSID *pClassID );
			new Guid GetClassID();

			/// <summary>Instructs a Shell folder object to initialize itself based on the information passed.</summary>
			/// <param name="pidl">
			/// <para>Type: <c>LPCITEMIDLIST</c></para>
			/// <para>The address of the ITEMIDLIST (item identifier list) structure that specifies the absolute location of the folder.</para>
			/// </param>
			/// <remarks>
			/// <para>
			/// All objects that implement the IShellFolder interface for use in the Shell's namespace must implement this method. When a
			/// folder's location in the namespace is not a relevant consideration, this method can simply return S_OK. When the location is
			/// relevant to the folder, you should store the fully qualified IDLIST passed in for later reference.
			/// </para>
			/// <para>
			/// For example, if the folder implementation needs to construct a fully qualified pointer to an item identifier list (PIDL) to
			/// elements that it contains, the PIDL passed to this method should be used to construct the fully qualified PIDLs.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ipersistfolder-initialize HRESULT
			// Initialize( PCIDLIST_ABSOLUTE pidl );
			new void Initialize([In] PIDL pidl);

			/// <summary>Gets the ITEMIDLIST for the folder object.</summary>
			/// <param name="ppidl">
			/// <para>Type: <c>LPITEMIDLIST*</c></para>
			/// <para>
			/// The address of an ITEMIDLIST pointer. This PIDL represents the absolute location of the folder and must be relative to the
			/// desktop. This is typically a copy of the PIDL passed to Initialize.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			/// <remarks>If the folder object has not been initialized, this method returns S_FALSE and ppidl is set to <c>NULL</c>.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ipersistfolder2-getcurfolder HRESULT
			// GetCurFolder( PIDLIST_ABSOLUTE *ppidl );
			[PreserveSig]
			HRESULT GetCurFolder(ref PIDL ppidl);
		}

		/// <summary>
		/// Extends the IPersistFolder and IPersistFolder2 interfaces by allowing a folder object to implement nondefault handling of folder shortcuts.
		/// </summary>
		/// <remarks>
		/// <para>
		/// This interface also provides the methods of the IPersist, IPersistFolder, and IPersistFolder2 interfaces, from which it inherits.
		/// </para>
		/// <para>In Windows versions earlier than Windows Vista, this interface was declared in Shlobj.h.</para>
		/// <para>When to Implement</para>
		/// <para>Namespace extensions implement this interface if they need to perform nondefault handling of folder shortcuts.</para>
		/// <para>When to Use</para>
		/// <para>Applications do not normally use this interface directly.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-ipersistfolder3
		[ComImport, Guid("CEF04FDF-FE72-11d2-87A5-00C04F6837CF"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IPersistFolder3 : IPersistFolder2
		{
			/// <summary>Retrieves the class identifier (CLSID) of the object.</summary>
			/// <returns>
			/// <para>
			/// A pointer to the location that receives the CLSID on return. The CLSID is a globally unique identifier (GUID) that uniquely
			/// represents an object class that defines the code that can manipulate the object's data.
			/// </para>
			/// <para>If the method succeeds, the return value is S_OK. Otherwise, it is E_FAIL.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// The <c>GetClassID</c> method retrieves the class identifier (CLSID) for an object, used in later operations to load
			/// object-specific code into the caller's context.
			/// </para>
			/// <para>Notes to Callers</para>
			/// <para>
			/// A container application might call this method to retrieve the original CLSID of an object that it is treating as a
			/// different class. Such a call would be necessary if a user performed an editing operation that required the object to be
			/// saved. If the container were to save it using the treat-as CLSID, the original application would no longer be able to edit
			/// the object. Typically, in this case, the container calls the OleSave helper function, which performs all the necessary
			/// steps. For this reason, most container applications have no need to call this method directly.
			/// </para>
			/// <para>
			/// The exception would be a container that provides an object handler for certain objects. In particular, a container
			/// application should not get an object's CLSID and then use it to retrieve class specific information from the registry.
			/// Instead, the container should use IOleObject and IDataObject interfaces to retrieve such class-specific information directly
			/// from the object.
			/// </para>
			/// <para>Notes to Implementers</para>
			/// <para>
			/// Typically, implementations of this method simply supply a constant CLSID for an object. If, however, the object's
			/// <c>TreatAs</c> registry key has been set by an application that supports emulation (and so is treating the object as one of
			/// a different class), a call to <c>GetClassID</c> must supply the CLSID specified in the <c>TreatAs</c> key. For more
			/// information on emulation, see CoTreatAsClass.
			/// </para>
			/// <para>
			/// When an object is in the running state, the default handler calls an implementation of <c>GetClassID</c> that delegates the
			/// call to the implementation in the object. When the object is not running, the default handler instead calls the ReadClassStg
			/// function to read the CLSID that is saved in the object's storage.
			/// </para>
			/// <para>
			/// If you are writing a custom object handler for your object, you might want to simply delegate this method to the default
			/// handler implementation (see OleCreateDefaultHandler).
			/// </para>
			/// <para>URL Moniker Notes</para>
			/// <para>This method returns CLSID_StdURLMoniker.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ipersist-getclassid HRESULT GetClassID( CLSID *pClassID );
			new Guid GetClassID();

			/// <summary>Instructs a Shell folder object to initialize itself based on the information passed.</summary>
			/// <param name="pidl">
			/// <para>Type: <c>LPCITEMIDLIST</c></para>
			/// <para>The address of the ITEMIDLIST (item identifier list) structure that specifies the absolute location of the folder.</para>
			/// </param>
			/// <remarks>
			/// <para>
			/// All objects that implement the IShellFolder interface for use in the Shell's namespace must implement this method. When a
			/// folder's location in the namespace is not a relevant consideration, this method can simply return S_OK. When the location is
			/// relevant to the folder, you should store the fully qualified IDLIST passed in for later reference.
			/// </para>
			/// <para>
			/// For example, if the folder implementation needs to construct a fully qualified pointer to an item identifier list (PIDL) to
			/// elements that it contains, the PIDL passed to this method should be used to construct the fully qualified PIDLs.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ipersistfolder-initialize HRESULT
			// Initialize( PCIDLIST_ABSOLUTE pidl );
			new void Initialize([In] PIDL pidl);

			/// <summary>Gets the ITEMIDLIST for the folder object.</summary>
			/// <param name="ppidl">
			/// <para>Type: <c>LPITEMIDLIST*</c></para>
			/// <para>
			/// The address of an ITEMIDLIST pointer. This PIDL represents the absolute location of the folder and must be relative to the
			/// desktop. This is typically a copy of the PIDL passed to Initialize.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			/// <remarks>If the folder object has not been initialized, this method returns S_FALSE and ppidl is set to <c>NULL</c>.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ipersistfolder2-getcurfolder HRESULT
			// GetCurFolder( PIDLIST_ABSOLUTE *ppidl );
			[PreserveSig]
			new HRESULT GetCurFolder(ref PIDL ppidl);

			/// <summary>
			/// Initializes a folder and specifies its location in the namespace. If the folder is a shortcut, this method also specifies
			/// the location of the target folder.
			/// </summary>
			/// <param name="pbc">
			/// <para>Type: <c>IBindCtx*</c></para>
			/// <para>A pointer to an IBindCtx object that provides the bind context. This parameter can be <c>NULL</c>.</para>
			/// </param>
			/// <param name="pidlRoot">
			/// <para>Type: <c>LPCITEMIDLIST</c></para>
			/// <para>
			/// A pointer to a fully qualified PIDL that specifies the absolute location of a folder or folder shortcut. The calling
			/// application is responsible for allocating and freeing this PIDL.
			/// </para>
			/// </param>
			/// <param name="ppfti">
			/// <para>Type: <c>const PERSIST_FOLDER_TARGET_INFO*</c></para>
			/// <para>A pointer to a PERSIST_FOLDER_TARGET_INFO structure that specifies the location of the target folder and its attributes.</para>
			/// <para>If ppfti points to a valid structure, pidlRoot represents a folder shortcut.</para>
			/// <para>
			/// If ppfti is set to <c>NULL</c>, pidlRoot represents a normal folder. In that case, <c>InitializeEx</c> should behave as if
			/// Initialize had been called.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			/// <remarks>
			/// This function is an extended version of IPersistFolder::Initialize. It allows the Shell to initialize folder shortcuts as
			/// well as normal folders.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ipersistfolder3-initializeex HRESULT
			// InitializeEx( IBindCtx *pbc, PCIDLIST_ABSOLUTE pidlRoot, const PERSIST_FOLDER_TARGET_INFO *ppfti );
			void InitializeEx([In] IBindCtx pbc, [In] PIDL pidlRoot, in PERSIST_FOLDER_TARGET_INFO ppfti);

			/// <summary>Provides the location and attributes of a folder shortcut's target folder.</summary>
			/// <returns>
			/// <para>Type: <c>PERSIST_FOLDER_TARGET_INFO*</c></para>
			/// <para>A pointer to a PERSIST_FOLDER_TARGET_INFO structure used to return the target folder's location and attributes.</para>
			/// </returns>
			/// <remarks>
			/// The PERSIST_FOLDER_TARGET_INFO structure might not be initialized by the caller. <c>GetFolderTargetInfo</c> must assign
			/// values to all members of the structure before returning it to the caller.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ipersistfolder3-getfoldertargetinfo HRESULT
			// GetFolderTargetInfo( PERSIST_FOLDER_TARGET_INFO *ppfti );
			PERSIST_FOLDER_TARGET_INFO GetFolderTargetInfo();
		}

		/// <summary>
		/// Specifies a folder shortcut's target folder and its attributes. This structure is used by IPersistFolder3::GetFolderTargetInfo
		/// and IPersistFolder3::InitializeEx.
		/// </summary>
		/// <remarks>
		/// Any or all of the <c>pidlTargetFolder</c>, <c>szTargetParsingName</c>, and <c>csidl</c> members can be used to specify the
		/// target folder's location.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/ns-shobjidl_core-persist_folder_target_info typedef struct
		// _PERSIST_FOLDER_TARGET_INFO { PIDLIST_ABSOLUTE pidlTargetFolder; WCHAR szTargetParsingName[260]; WCHAR szNetworkProvider[260];
		// DWORD dwAttributes; int csidl; } PERSIST_FOLDER_TARGET_INFO;
		[PInvokeData("shobjidl_core.h", MSDNShortId = "NS:shobjidl_core._PERSIST_FOLDER_TARGET_INFO")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct PERSIST_FOLDER_TARGET_INFO
		{
			/// <summary>
			/// <para>Type: <c>PIDLIST_ABSOLUTE</c></para>
			/// <para>A fully qualified PIDL of the target folder. Set <c>pidlTargetFolder</c> to <c>NULL</c> if not specified.</para>
			/// </summary>
			public IntPtr pidlTargetFolder;

			/// <summary>
			/// <para>Type: <c>WCHAR[MAX_PATH]</c></para>
			/// <para>
			/// A null-terminated Unicode string with the target folder's parsing name. Set <c>szTargetParsingName</c> to an empty string if
			/// not specified.
			/// </para>
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
			public string szTargetParsingName;

			/// <summary>
			/// <para>Type: <c>WCHAR[MAX_PATH]</c></para>
			/// <para>
			/// A null-terminated Unicode string that specifies the type of network provider that will be used when binding to the target
			/// folder. The format is the same as that used by the WNet API. Set <c>szNetworkProvider</c> to an empty string if not specified.
			/// </para>
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
			public string szNetworkProvider;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// A <c>DWORD</c> value that contains FILE_ATTRIBUTE_* flags as defined in Winnt.h. Set <c>dwAttributes</c> to -1 if not specified.
			/// </para>
			/// </summary>
			public FileFlagsAndAttributes dwAttributes;

			/// <summary>
			/// <para>Type: <c>int</c></para>
			/// <para>
			/// The target folder's CSIDL value, if it has one. Set <c>csidl</c> to -1 if the target folder does not have a CSIDL. In
			/// addition to the CSIDL value, you can also set the following two flags.
			/// </para>
			/// <para>CSIDL_FLAG_PFTI_TRACKTARGET</para>
			/// <para>Indicates that the target folder should change if the user changes the target folder's underlying CSIDL value.</para>
			/// <para>CSIDL_FLAG_CREATE</para>
			/// <para>Indicates that the target folder should be created if it does not already exist.</para>
			/// </summary>
			public CSIDL csidl;
		}
	}
}