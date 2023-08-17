using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using Vanara.Extensions.Reflection;
using Vanara.PInvoke;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.Shell32;
using BIND_OPTS = System.Runtime.InteropServices.ComTypes.BIND_OPTS;

namespace Vanara.Windows.Shell;

/// <summary>Wraps the <see cref="IBindCtx"/> COM type.</summary>
/// <seealso cref="IDisposable"/>
[ComVisible(true)]
public class BindContext : IDisposable, IBindCtxV, IBindCtx
{
	private IBindCtxV iBindCtx;

	/// <summary>Initializes a new instance of the <see cref="BindContext"/> class.</summary>
#pragma warning disable IL2050 // Correctness of COM interop cannot be guaranteed after trimming. Interfaces and interface members might be removed.
	public BindContext() => CreateBindCtx(0, out iBindCtx).ThrowIfFailed();
#pragma warning restore IL2050 // Correctness of COM interop cannot be guaranteed after trimming. Interfaces and interface members might be removed.

	/// <summary>Initializes a new instance of the <see cref="BindContext"/> class.</summary>
	/// <param name="openMode">
	/// Represents flags that should be used when opening the file that contains the object identified by the moniker.
	/// </param>
	/// <param name="timeout">
	/// Indicates the amount of time (clock time in milliseconds) that the caller specified to complete the binding operation.
	/// </param>
	/// <param name="bindFlags">Flags that control aspects of moniker binding operations.</param>
	public BindContext(STGM openMode = STGM.STGM_READWRITE | STGM.STGM_SHARE_DENY_NONE, TimeSpan timeout = default, BIND_FLAGS bindFlags = 0)
	{
#pragma warning disable IL2050 // Correctness of COM interop cannot be guaranteed after trimming. Interfaces and interface members might be removed.
		CreateBindCtx(0, out iBindCtx).ThrowIfFailed();
#pragma warning restore IL2050 // Correctness of COM interop cannot be guaranteed after trimming. Interfaces and interface members might be removed.
		var opts = new BIND_OPTS_V
		{
			dwTickCountDeadline = (uint)timeout.TotalMilliseconds,
			grfMode = openMode,
			grfFlags = bindFlags,
		};
		iBindCtx.SetBindOptions(opts);
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="BindContext"/> class with system file information to enable "simple parsing" which
	/// avoids having to access the file. This avoids the expense of getting the information from the file and allows for parsing items
	/// that may not necessarily exist.
	/// </summary>
	/// <param name="findData">The system file information as a <see cref="WIN32_FIND_DATA"/> structure.</param>
	public BindContext(in WIN32_FIND_DATA findData) : this(STGM.STGM_CREATE)
	{
		var pfsbd = new CFileSysBindData(findData);
		RegisterObjectParam(STR_FILE_SYS_BIND_DATA, pfsbd);
	}

	/// <summary>Flags that control aspects of moniker binding operations.</summary>
	public BIND_FLAGS BindFlags
	{
		get => GetOptionValue<BIND_FLAGS>(nameof(BIND_OPTS_V.grfFlags));
		set => SetOptionValue(nameof(BIND_OPTS_V.grfFlags), value);
	}

	/// <summary>
	/// The class context, taken from the CLSCTX enumeration, that is to be used for instantiating the object. Monikers typically pass
	/// this value to the dwClsContext parameter of CoCreateInstance.
	/// </summary>
	public CLSCTX ClassContext
	{
		get => GetOptionValue<CLSCTX>(nameof(BIND_OPTS2.dwClassContext));
		set => SetOptionValue(nameof(BIND_OPTS2.dwClassContext), value);
	}

	/// <summary>
	/// <para>
	/// The clock time by which the caller would like the binding operation to be completed. This member lets the caller limit the
	/// execution time of an operation when speed is of primary importance. A value of zero indicates that there is no deadline. Callers
	/// most often use this capability when calling the IMoniker::GetTimeOfLastChange method, though it can be usefully applied to other
	/// operations as well. The CreateBindCtx function initializes this field to zero.
	/// </para>
	/// <para>
	/// Typical deadlines allow for a few hundred milliseconds of execution. This deadline is a recommendation, not a requirement;
	/// however, operations that exceed their deadline by a large amount may cause delays for the end user. Each moniker implementation
	/// should try to complete its operation by the deadline, or fail with the error MK_E_EXCEEDEDDEADLINE.
	/// </para>
	/// <para>
	/// If a binding operation exceeds its deadline because one or more objects that it needs are not running, the moniker
	/// implementation should register the objects responsible in the bind context using the IBindCtxV::RegisterObjectParam. The objects
	/// should be registered under the parameter names "ExceededDeadline", "ExceededDeadline1", "ExceededDeadline2", and so on. If the
	/// caller later finds the object in the running object table, the caller can retry the binding operation.
	/// </para>
	/// </summary>
	public TimeSpan Deadline
	{
		get => TimeSpan.FromMilliseconds(GetOptionValue<uint>(nameof(BIND_OPTS_V.dwTickCountDeadline)));
		set => SetOptionValue(nameof(BIND_OPTS_V.dwTickCountDeadline), (uint)value.TotalMilliseconds);
	}

	/// <summary>
	/// The LCID value indicating the client's preference for the locale to be used by the object to which they are binding. A moniker
	/// passes this value to IClassActivator::GetClassObject.
	/// </summary>
	public LCID Locale
	{
		get => GetOptionValue<uint>(nameof(BIND_OPTS2.locale));
		set => SetOptionValue(nameof(BIND_OPTS2.locale), (uint)value);
	}

	/// <summary>
	/// Flags that should be used when opening the file that contains the object identified by the moniker. The binding operation uses
	/// these flags in the call to IPersistFile::Load when loading the file. If the object is already running, these flags are ignored
	/// by the binding operation. The default value is STGM_READWRITE.
	/// </summary>
	public STGM OpenMode
	{
		get => GetOptionValue<STGM>(nameof(BIND_OPTS_V.grfMode));
		set => SetOptionValue(nameof(BIND_OPTS_V.grfMode), value);
	}

	/// <summary>
	/// <para>
	/// A moniker can use this value during link tracking. If the original persisted data that the moniker is referencing has been
	/// moved, the moniker can attempt to reestablish the link by searching for the original data though some adequate mechanism. This
	/// member provides additional information on how the link should be resolved. See the documentation of the fFlags parameter in IShellLink::Resolve.
	/// </para>
	/// <para>COM's file moniker implementation uses the shell link mechanism to reestablish links and passes these flags to IShellLink::Resolve.</para>
	/// </summary>
	public SLR_FLAGS TrackFlags
	{
		get => (SLR_FLAGS)GetOptionValue<uint>(nameof(BIND_OPTS2.dwTrackFlags));
		set => SetOptionValue(nameof(BIND_OPTS2.dwTrackFlags), (uint)value);
	}

	/// <summary>
	/// A handle to the window that becomes the owner of the elevation UI, if applicable. If <c>hwnd</c> is <c>NULL</c>, COM will call
	/// the GetActiveWindow function to find a window handle associated with the current thread. This case might occur if the client is
	/// a script, which cannot fill in a <c>BIND_OPTS3</c> structure. In this case, COM will try to use the window associated with the
	/// script thread.
	/// </summary>
	public HWND WindowHandle
	{
		get => GetOptionValue<HWND>(nameof(BIND_OPTS3.hwnd));
		set => SetOptionValue(nameof(BIND_OPTS3.hwnd), value);
	}

	/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
	public void Dispose() => GC.SuppressFinalize(this);

	/// <summary>
	/// Retrieves a pointer to an interface that can be used to enumerate the keys of the bind context's string-keyed table of pointers.
	/// </summary>
	/// <returns>A list of keys of the bind context's string-keyed table of pointers.</returns>
	/// <remarks>
	/// <para>The keys returned by the enumerator are the ones previously specified in calls to IBindCtxV::RegisterObjectParam.</para>
	/// <para>Notes to Callers</para>
	/// <para>
	/// A bind context maintains a table of interface pointers, each associated with a string key. This enables communication between a
	/// moniker implementation and the caller that initiated the binding operation. One party can store an interface pointer under a
	/// string known to both parties so that the other party can later retrieve it from the bind context.
	/// </para>
	/// <para>
	/// In the system implementation of the IBindCtxV interface, this method is not implemented. Therefore, calling this method results
	/// in a return value of E_NOTIMPL.
	/// </para>
	/// </remarks>
	public IEnumerable<string> EnumObjectParam() => ((IBindCtxV)this).EnumObjectParam(out var ppenum).Succeeded ? ppenum.Enum().ToArray() : new string[0];

	/// <summary>
	/// Retrieves an interface pointer to the object associated with the specified key in the bind context's string-keyed table of pointers.
	/// </summary>
	/// <param name="pszKey">The bind context string key to be searched for. Key string comparison is case-sensitive.</param>
	/// <returns>
	/// An IUnknown interface pointer to the object associated with pszKey. When successful, the implementation calls AddRef. It is the
	/// caller's responsibility to call Release. If an error occurs, the implementation sets this value to <see langword="null"/>.
	/// </returns>
	/// <remarks>
	/// <para>
	/// A bind context maintains a table of interface pointers, each associated with a string key. This enables communication between a
	/// moniker implementation and the caller that initiated the binding operation. One party can store an interface pointer under a
	/// string known to both parties so that the other party can later retrieve it from the bind context.
	/// </para>
	/// <para>
	/// The pointer this method retrieves must have previously been inserted into the table using the IBindCtxV::RegisterObjectParam method.
	/// </para>
	/// <para>Notes to Callers</para>
	/// <para>
	/// Objects using monikers to locate other objects can call this method when a binding operation fails to get specific information
	/// about the error that occurred. Depending on the error, it may be possible to correct the situation and retry the binding
	/// operation. See IBindCtxV::RegisterObjectParam for more information.
	/// </para>
	/// <para>
	/// Moniker implementations can call this method to handle situations where a caller initiates a binding operation and requests
	/// specific information. By convention, the implementer should use key names that begin with the string form of the CLSID of a
	/// moniker class. (See the StringFromCLSID function.)
	/// </para>
	/// </remarks>
	public object GetObjectParam(string pszKey)
	{
		((IBindCtxV)this).GetObjectParam(pszKey, out var ppunk).ThrowIfFailed();
		return ppunk!;
	}

	/// <summary>
	/// Retrieves an interface pointer to the running object table (ROT) for the computer on which this bind context is running.
	/// </summary>
	/// <returns>
	/// A IRunningObjectTable for the running object table. If an error occurs, this value is <see langword="null"/>. If the value is
	/// non- <see langword="null"/>, the implementation calls AddRef on the running table object; it is the caller's responsibility to
	/// call Release.
	/// </returns>
	/// <remarks>
	/// <para>
	/// The running object table is a globally accessible table on each computer. It keeps track of all the objects that are currently
	/// running on the computer.
	/// </para>
	/// <para>Notes to Callers</para>
	/// <para>
	/// Typically, those implementing a new moniker class (through an implementation of IMoniker interface) call
	/// <c>GetRunningObjectTable</c>. It is useful to call this method in an implementation of IMoniker::BindToObject or
	/// IMoniker::IsRunning to check whether an object is currently running. You can also call this method in the implementation of
	/// IMoniker::GetTimeOfLastChange to learn when a running object was last modified.
	/// </para>
	/// <para>
	/// Moniker implementations should call this method instead of using the <c>GetRunningObjectTable</c> function. This makes it
	/// possible for future implementations of IBindCtxV to modify binding behavior.
	/// </para>
	/// </remarks>
	public Ole32.IRunningObjectTable GetRunningObjectTable()
	{
		((IBindCtxV)this).GetRunningObjectTable(out var pprot).ThrowIfFailed();
		return pprot;
	}

	/// <summary>Registers an object with the bind context to ensure that the object remains active until the bind context is released.</summary>
	/// <param name="punk">A pointer to the IUnknown interface on the object that is being registered as bound.</param>
	/// <remarks>
	/// <para>
	/// Those writing a new moniker class (through an implementation of the IMoniker interface) should call this method whenever the
	/// implementation activates an object. This happens most often in the course of binding a moniker, but it can also happen while
	/// retrieving a moniker's display name, parsing a display name into a moniker, or retrieving the time that an object was last modified.
	/// </para>
	/// <para>
	/// <c>RegisterObjectBound</c> calls AddRef to create an additional reference to the object. You must, however, still release your
	/// own copy of the pointer. Calling this method twice for the same object creates two references to that object. You can release a
	/// reference obtained through a call to this method by calling IBindCtxV::RevokeObjectBound. All references held by the bind
	/// context are released when the bind context itself is released.
	/// </para>
	/// <para>
	/// Calling <c>RegisterObjectBound</c> to register an object with a bind context keeps the object active until the bind context is
	/// released. Reusing a bind context in a subsequent binding operation (either for another piece of the same composite moniker or
	/// for a different moniker) can make the subsequent binding operation more efficient because it doesn't have to reload that object.
	/// This, however, improves performance only if the subsequent binding operation requires some of the same objects as the original
	/// one, so you need to balance the possible performance improvement of reusing a bind context against the costs of keeping objects
	/// activated unnecessarily.
	/// </para>
	/// <para>
	/// IBindCtxV does not provide a method to retrieve a pointer to an object registered using <c>RegisterObjectBound</c>. Assuming the
	/// object has registered itself with the running object table, moniker implementations can call IRunningObjectTable::GetObject to
	/// retrieve a pointer to the object.
	/// </para>
	/// </remarks>
	public void RegisterObjectBound(object punk) => ((IBindCtxV)this).RegisterObjectBound(punk).ThrowIfFailed();

	/// <summary>Associates an object with a string key in the bind context's string-keyed table of pointers.</summary>
	/// <param name="pszKey">The bind context string key under which the object is being registered. Key string comparison is case-sensitive.</param>
	/// <param name="punk">
	/// <para>A pointer to the IUnknown interface on the object that is to be registered.</para>
	/// <para>The method calls AddRef on the pointer.</para>
	/// </param>
	/// <remarks>
	/// <para>
	/// A bind context maintains a table of interface pointers, each associated with a string key. This enables communication between a
	/// moniker implementation and the caller that initiated the binding operation. One party can store an interface pointer under a
	/// string known to both parties so that the other party can later retrieve it from the bind context.
	/// </para>
	/// <para>Binding operations subsequent to the use of this method can use IBindCtxV::GetObjectParam to retrieve the stored pointer.</para>
	/// <para>Notes to Callers</para>
	/// <para>
	/// <c>RegisterObjectParam</c> is useful to those implementing a new moniker class (through an implementation of IMoniker) and to
	/// moniker clients (those who use monikers to bind to objects).
	/// </para>
	/// <para>
	/// In implementing a new moniker class, you call this method when an error occurs during moniker binding to inform the caller of
	/// the cause of the error. The key that you would obtain with a call to this method would depend on the error condition. Following
	/// is a list of common moniker binding errors, describing for each the keys that would be appropriate:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// MK_E_EXCEEDEDDEADLINEâ€”If a binding operation exceeds its deadline because a given object is not running, you should register
	/// the object's moniker using the first unused key from the list: "ExceededDeadline", "ExceededDeadline1", "ExceededDeadline2", and
	/// so on. If the caller later finds the moniker in the running object table, the caller can retry the binding operation.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// MK_E_CONNECTMANUALLYâ€”The "ConnectManually" key indicates a moniker whose binding requires assistance from the end user. To
	/// request that the end user manually connect to the object, the caller can retry the binding operation after showing the moniker's
	/// display name. Common reasons for this error are that a password is needed or that a floppy needs to be mounted.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// E_CLASSNOTFOUNDâ€”The "ClassNotFound" key indicates a moniker whose class could not be found. (The server for the object
	/// identified by this moniker could not be located.) If this key is used for an OLE compound-document object, the caller can use
	/// IMoniker::BindToStorage to bind to the object and then try to carry out a <c>Treat As...</c> or <c>Convert To...</c> operation
	/// to associate the object with a different server. If this is successful, the caller can retry the binding operation.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// A moniker client with detailed knowledge of the implementation of the moniker can also call this method to pass private
	/// information to that implementation.
	/// </para>
	/// <para>
	/// You can define new strings as keys for storing pointers. By convention, you should use key names that begin with the string form
	/// of the CLSID of the moniker class. (See the StringFromCLSID function.)
	/// </para>
	/// <para>
	/// If the pszKey parameter matches the name of an existing key in the bind context's table, the new object replaces the existing
	/// object in the table.
	/// </para>
	/// <para>When you register an object using this method, the object is not released until one of the following occurs:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>It is replaced in the table by another object with the same key.</term>
	/// </item>
	/// <item>
	/// <term>It is removed from the table by a call to IBindCtxV::RevokeObjectParam.</term>
	/// </item>
	/// <item>
	/// <term>The bind context is released. All registered objects are released when the bind context is released.</term>
	/// </item>
	/// </list>
	/// </remarks>
	public void RegisterObjectParam(string pszKey, object punk) => ((IBindCtxV)this).RegisterObjectParam(pszKey, punk).ThrowIfFailed();

	/// <summary>
	/// Removes the specified key and its associated pointer from the bind context's string-keyed table of objects. The key must have
	/// previously been inserted into the table with a call to RegisterObjectParam.
	/// </summary>
	/// <param name="pszKey">The bind context string key to be removed. Key string comparison is case-sensitive.</param>
	/// <remarks>
	/// <para>
	/// A bind context maintains a table of interface pointers, each associated with a string key. This enables communication between a
	/// moniker implementation and the caller that initiated the binding operation. One party can store an interface pointer under a
	/// string known to both parties so that the other party can later retrieve it from the bind context.
	/// </para>
	/// <para>
	/// This method is used to remove an entry from the table. If the specified key is found, the bind context also releases its
	/// reference to the object.
	/// </para>
	/// </remarks>
	public void RevokeObjectParam(string pszKey) => ((IBindCtxV)this).RevokeObjectParam(pszKey).ThrowIfFailed();

	/// <summary>
	/// Retrieves a pointer to an interface that can be used to enumerate the keys of the bind context's string-keyed table of pointers.
	/// </summary>
	/// <param name="ppenum">
	/// The address of an IEnumString* pointer variable that receives the interface pointer to the enumerator. If an error occurs,
	/// *ppenum is set to <c>NULL</c>. If *ppenum is non- <c>NULL</c>, the implementation calls AddRef on *ppenum; it is the caller's
	/// responsibility to call Release.
	/// </param>
	/// <returns>This method can return the standard return values E_OUTOFMEMORY and S_OK.</returns>
	/// <remarks>
	/// <para>The keys returned by the enumerator are the ones previously specified in calls to IBindCtxV::RegisterObjectParam.</para>
	/// <para>Notes to Callers</para>
	/// <para>
	/// A bind context maintains a table of interface pointers, each associated with a string key. This enables communication between a
	/// moniker implementation and the caller that initiated the binding operation. One party can store an interface pointer under a
	/// string known to both parties so that the other party can later retrieve it from the bind context.
	/// </para>
	/// <para>
	/// In the system implementation of the IBindCtxV interface, this method is not implemented. Therefore, calling this method results
	/// in a return value of E_NOTIMPL.
	/// </para>
	/// </remarks>
	HRESULT IBindCtxV.EnumObjectParam(out IEnumString ppenum) => iBindCtx.EnumObjectParam(out ppenum);

	/// <summary>
	/// Retrieves a pointer to an interface that can be used to enumerate the keys of the bind context's string-keyed table of pointers.
	/// </summary>
	/// <param name="ppenum">
	/// The address of an IEnumString* pointer variable that receives the interface pointer to the enumerator. If an error occurs,
	/// *ppenum is set to <c>NULL</c>. If *ppenum is non- <c>NULL</c>, the implementation calls AddRef on *ppenum; it is the caller's
	/// responsibility to call Release.
	/// </param>
	/// <returns>This method can return the standard return values E_OUTOFMEMORY and S_OK.</returns>
	/// <remarks>
	/// <para>The keys returned by the enumerator are the ones previously specified in calls to IBindCtx::RegisterObjectParam.</para>
	/// <para>Notes to Callers</para>
	/// <para>
	/// A bind context maintains a table of interface pointers, each associated with a string key. This enables communication between a
	/// moniker implementation and the caller that initiated the binding operation. One party can store an interface pointer under a
	/// string known to both parties so that the other party can later retrieve it from the bind context.
	/// </para>
	/// <para>
	/// In the system implementation of the IBindCtx interface, this method is not implemented. Therefore, calling this method results
	/// in a return value of E_NOTIMPL.
	/// </para>
	/// </remarks>
	void IBindCtx.EnumObjectParam(out IEnumString ppenum) => iBindCtx.EnumObjectParam(out ppenum).ThrowIfFailed();

	/// <summary>Retrieves the binding options stored in this bind context.</summary>
	/// <param name="pbindopts">
	/// A pointer to an initialized structure that receives the current binding parameters on return. See BIND_OPTS, BIND_OPTS2, and BIND_OPTS3.
	/// </param>
	/// <returns>This method can return the standard return values E_UNEXPECTED and S_OK.</returns>
	/// <remarks>
	/// <para>
	/// A bind context contains a block of parameters that are common to most IMoniker operations and that do not change as the
	/// operation moves from piece to piece of a composite moniker.
	/// </para>
	/// <para>Notes to Callers</para>
	/// <para>
	/// You typically call this method if you are writing your own moniker class. (This requires that you implement the IMoniker
	/// interface.) You call this method to retrieve the parameters specified by the moniker client.
	/// </para>
	/// <para>
	/// You must initialize the structure that is filled in by this method. Before calling this method, you must initialize the
	/// <c>cbStruct</c> member to the size of the structure.
	/// </para>
	/// </remarks>
	HRESULT IBindCtxV.GetBindOptions([In, Out] BIND_OPTS_V pbindopts) => iBindCtx.GetBindOptions(pbindopts);

	/// <summary>Retrieves the binding options stored in this bind context.</summary>
	/// <param name="pbindopts">
	/// A pointer to an initialized structure that receives the current binding parameters on return. See BIND_OPTS, BIND_OPTS2, and BIND_OPTS3.
	/// </param>
	/// <returns>This method can return the standard return values E_UNEXPECTED and S_OK.</returns>
	/// <remarks>
	/// <para>
	/// A bind context contains a block of parameters that are common to most IMoniker operations and that do not change as the
	/// operation moves from piece to piece of a composite moniker.
	/// </para>
	/// <para>Notes to Callers</para>
	/// <para>
	/// You typically call this method if you are writing your own moniker class. (This requires that you implement the IMoniker
	/// interface.) You call this method to retrieve the parameters specified by the moniker client.
	/// </para>
	/// <para>
	/// You must initialize the structure that is filled in by this method. Before calling this method, you must initialize the
	/// <c>cbStruct</c> member to the size of the structure.
	/// </para>
	/// </remarks>
	void IBindCtx.GetBindOptions(ref BIND_OPTS pbindopts) { var bo = new BIND_OPTS_V(); iBindCtx.GetBindOptions(bo).ThrowIfFailed(); pbindopts = bo; }

	/// <summary>
	/// Retrieves an interface pointer to the object associated with the specified key in the bind context's string-keyed table of pointers.
	/// </summary>
	/// <param name="pszKey">The bind context string key to be searched for. Key string comparison is case-sensitive.</param>
	/// <param name="ppunk">
	/// The address of an IUnknown* pointer variable that receives the interface pointer to the object associated with pszKey. When
	/// successful, the implementation calls AddRef on *ppunk. It is the caller's responsibility to call Release. If an error occurs,
	/// the implementation sets *ppunk to <c>NULL</c>.
	/// </param>
	/// <returns>If the method succeeds, the return value is S_OK. Otherwise, it is E_FAIL.</returns>
	/// <remarks>
	/// <para>
	/// A bind context maintains a table of interface pointers, each associated with a string key. This enables communication between a
	/// moniker implementation and the caller that initiated the binding operation. One party can store an interface pointer under a
	/// string known to both parties so that the other party can later retrieve it from the bind context.
	/// </para>
	/// <para>
	/// The pointer this method retrieves must have previously been inserted into the table using the IBindCtxV::RegisterObjectParam method.
	/// </para>
	/// <para>Notes to Callers</para>
	/// <para>
	/// Objects using monikers to locate other objects can call this method when a binding operation fails to get specific information
	/// about the error that occurred. Depending on the error, it may be possible to correct the situation and retry the binding
	/// operation. See IBindCtxV::RegisterObjectParam for more information.
	/// </para>
	/// <para>
	/// Moniker implementations can call this method to handle situations where a caller initiates a binding operation and requests
	/// specific information. By convention, the implementer should use key names that begin with the string form of the CLSID of a
	/// moniker class. (See the StringFromCLSID function.)
	/// </para>
	/// </remarks>
	HRESULT IBindCtxV.GetObjectParam([MarshalAs(UnmanagedType.LPWStr)] string pszKey, [MarshalAs(UnmanagedType.Interface)] out object? ppunk) => iBindCtx.GetObjectParam(pszKey, out ppunk);

	/// <summary>
	/// Retrieves an interface pointer to the object associated with the specified key in the bind context's string-keyed table of pointers.
	/// </summary>
	/// <param name="pszKey">The bind context string key to be searched for. Key string comparison is case-sensitive.</param>
	/// <param name="ppunk">
	/// The address of an IUnknown* pointer variable that receives the interface pointer to the object associated with pszKey. When
	/// successful, the implementation calls AddRef on *ppunk. It is the caller's responsibility to call Release. If an error occurs,
	/// the implementation sets *ppunk to <c>NULL</c>.
	/// </param>
	/// <returns>If the method succeeds, the return value is S_OK. Otherwise, it is E_FAIL.</returns>
	/// <remarks>
	/// <para>
	/// A bind context maintains a table of interface pointers, each associated with a string key. This enables communication between a
	/// moniker implementation and the caller that initiated the binding operation. One party can store an interface pointer under a
	/// string known to both parties so that the other party can later retrieve it from the bind context.
	/// </para>
	/// <para>
	/// The pointer this method retrieves must have previously been inserted into the table using the IBindCtx::RegisterObjectParam method.
	/// </para>
	/// <para>Notes to Callers</para>
	/// <para>
	/// Objects using monikers to locate other objects can call this method when a binding operation fails to get specific information
	/// about the error that occurred. Depending on the error, it may be possible to correct the situation and retry the binding
	/// operation. See IBindCtx::RegisterObjectParam for more information.
	/// </para>
	/// <para>
	/// Moniker implementations can call this method to handle situations where a caller initiates a binding operation and requests
	/// specific information. By convention, the implementer should use key names that begin with the string form of the CLSID of a
	/// moniker class. (See the StringFromCLSID function.)
	/// </para>
	/// </remarks>
	void IBindCtx.GetObjectParam(string pszKey, out object? ppunk) => iBindCtx.GetObjectParam(pszKey, out ppunk);

	/// <summary>
	/// Retrieves an interface pointer to the running object table (ROT) for the computer on which this bind context is running.
	/// </summary>
	/// <param name="pprot">
	/// The address of a IRunningObjectTable* pointer variable that receives the interface pointer to the running object table. If an
	/// error occurs, *pprot is set to <c>NULL</c>. If *pprot is non- <c>NULL</c>, the implementation calls AddRef on the running table
	/// object; it is the caller's responsibility to call Release.
	/// </param>
	/// <returns>This method can return the standard return values E_OUTOFMEMORY, E_UNEXPECTED, and S_OK.</returns>
	/// <remarks>
	/// <para>
	/// The running object table is a globally accessible table on each computer. It keeps track of all the objects that are currently
	/// running on the computer.
	/// </para>
	/// <para>Notes to Callers</para>
	/// <para>
	/// Typically, those implementing a new moniker class (through an implementation of IMoniker interface) call
	/// <c>GetRunningObjectTable</c>. It is useful to call this method in an implementation of IMoniker::BindToObject or
	/// IMoniker::IsRunning to check whether an object is currently running. You can also call this method in the implementation of
	/// IMoniker::GetTimeOfLastChange to learn when a running object was last modified.
	/// </para>
	/// <para>
	/// Moniker implementations should call this method instead of using the <c>GetRunningObjectTable</c> function. This makes it
	/// possible for future implementations of IBindCtxV to modify binding behavior.
	/// </para>
	/// </remarks>
	HRESULT IBindCtxV.GetRunningObjectTable(out Ole32.IRunningObjectTable pprot) => iBindCtx.GetRunningObjectTable(out pprot);

	/// <summary>
	/// Retrieves an interface pointer to the running object table (ROT) for the computer on which this bind context is running.
	/// </summary>
	/// <param name="pprot">
	/// The address of a IRunningObjectTable* pointer variable that receives the interface pointer to the running object table. If an
	/// error occurs, *pprot is set to <c>NULL</c>. If *pprot is non- <c>NULL</c>, the implementation calls AddRef on the running table
	/// object; it is the caller's responsibility to call Release.
	/// </param>
	/// <returns>This method can return the standard return values E_OUTOFMEMORY, E_UNEXPECTED, and S_OK.</returns>
	/// <remarks>
	/// <para>
	/// The running object table is a globally accessible table on each computer. It keeps track of all the objects that are currently
	/// running on the computer.
	/// </para>
	/// <para>Notes to Callers</para>
	/// <para>
	/// Typically, those implementing a new moniker class (through an implementation of IMoniker interface) call
	/// <c>GetRunningObjectTable</c>. It is useful to call this method in an implementation of IMoniker::BindToObject or
	/// IMoniker::IsRunning to check whether an object is currently running. You can also call this method in the implementation of
	/// IMoniker::GetTimeOfLastChange to learn when a running object was last modified.
	/// </para>
	/// <para>
	/// Moniker implementations should call this method instead of using the <c>GetRunningObjectTable</c> function. This makes it
	/// possible for future implementations of IBindCtx to modify binding behavior.
	/// </para>
	/// </remarks>
	void IBindCtx.GetRunningObjectTable(out System.Runtime.InteropServices.ComTypes.IRunningObjectTable pprot)
	{
		iBindCtx.GetRunningObjectTable(out var rot).ThrowIfFailed();
		pprot = (System.Runtime.InteropServices.ComTypes.IRunningObjectTable)Marshal.GetObjectForIUnknown(Marshal.GetComInterfaceForObject(rot, typeof(System.Runtime.InteropServices.ComTypes.IRunningObjectTable)));
	}

	/// <summary>Registers an object with the bind context to ensure that the object remains active until the bind context is released.</summary>
	/// <param name="punk">A pointer to the IUnknown interface on the object that is being registered as bound.</param>
	/// <returns>This method can return the standard return values E_OUTOFMEMORY and S_OK.</returns>
	/// <remarks>
	/// <para>
	/// Those writing a new moniker class (through an implementation of the IMoniker interface) should call this method whenever the
	/// implementation activates an object. This happens most often in the course of binding a moniker, but it can also happen while
	/// retrieving a moniker's display name, parsing a display name into a moniker, or retrieving the time that an object was last modified.
	/// </para>
	/// <para>
	/// <c>RegisterObjectBound</c> calls AddRef to create an additional reference to the object. You must, however, still release your
	/// own copy of the pointer. Calling this method twice for the same object creates two references to that object. You can release a
	/// reference obtained through a call to this method by calling IBindCtxV::RevokeObjectBound. All references held by the bind
	/// context are released when the bind context itself is released.
	/// </para>
	/// <para>
	/// Calling <c>RegisterObjectBound</c> to register an object with a bind context keeps the object active until the bind context is
	/// released. Reusing a bind context in a subsequent binding operation (either for another piece of the same composite moniker or
	/// for a different moniker) can make the subsequent binding operation more efficient because it doesn't have to reload that object.
	/// This, however, improves performance only if the subsequent binding operation requires some of the same objects as the original
	/// one, so you need to balance the possible performance improvement of reusing a bind context against the costs of keeping objects
	/// activated unnecessarily.
	/// </para>
	/// <para>
	/// IBindCtxV does not provide a method to retrieve a pointer to an object registered using <c>RegisterObjectBound</c>. Assuming the
	/// object has registered itself with the running object table, moniker implementations can call IRunningObjectTable::GetObject to
	/// retrieve a pointer to the object.
	/// </para>
	/// </remarks>
	HRESULT IBindCtxV.RegisterObjectBound([In, MarshalAs(UnmanagedType.Interface)] object punk) => iBindCtx.RegisterObjectBound(punk);

	/// <summary>Associates an object with a string key in the bind context's string-keyed table of pointers.</summary>
	/// <param name="pszKey">The bind context string key under which the object is being registered. Key string comparison is case-sensitive.</param>
	/// <param name="punk">
	/// <para>A pointer to the IUnknown interface on the object that is to be registered.</para>
	/// <para>The method calls AddRef on the pointer.</para>
	/// </param>
	/// <returns>This method can return the standard return values E_OUTOFMEMORY and S_OK.</returns>
	/// <remarks>
	/// <para>
	/// A bind context maintains a table of interface pointers, each associated with a string key. This enables communication between a
	/// moniker implementation and the caller that initiated the binding operation. One party can store an interface pointer under a
	/// string known to both parties so that the other party can later retrieve it from the bind context.
	/// </para>
	/// <para>Binding operations subsequent to the use of this method can use IBindCtxV::GetObjectParam to retrieve the stored pointer.</para>
	/// <para>Notes to Callers</para>
	/// <para>
	/// <c>RegisterObjectParam</c> is useful to those implementing a new moniker class (through an implementation of IMoniker) and to
	/// moniker clients (those who use monikers to bind to objects).
	/// </para>
	/// <para>
	/// In implementing a new moniker class, you call this method when an error occurs during moniker binding to inform the caller of
	/// the cause of the error. The key that you would obtain with a call to this method would depend on the error condition. Following
	/// is a list of common moniker binding errors, describing for each the keys that would be appropriate:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// MK_E_EXCEEDEDDEADLINEâ€”If a binding operation exceeds its deadline because a given object is not running, you should register
	/// the object's moniker using the first unused key from the list: "ExceededDeadline", "ExceededDeadline1", "ExceededDeadline2", and
	/// so on. If the caller later finds the moniker in the running object table, the caller can retry the binding operation.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// MK_E_CONNECTMANUALLYâ€”The "ConnectManually" key indicates a moniker whose binding requires assistance from the end user. To
	/// request that the end user manually connect to the object, the caller can retry the binding operation after showing the moniker's
	/// display name. Common reasons for this error are that a password is needed or that a floppy needs to be mounted.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// E_CLASSNOTFOUNDâ€”The "ClassNotFound" key indicates a moniker whose class could not be found. (The server for the object
	/// identified by this moniker could not be located.) If this key is used for an OLE compound-document object, the caller can use
	/// IMoniker::BindToStorage to bind to the object and then try to carry out a <c>Treat As...</c> or <c>Convert To...</c> operation
	/// to associate the object with a different server. If this is successful, the caller can retry the binding operation.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// A moniker client with detailed knowledge of the implementation of the moniker can also call this method to pass private
	/// information to that implementation.
	/// </para>
	/// <para>
	/// You can define new strings as keys for storing pointers. By convention, you should use key names that begin with the string form
	/// of the CLSID of the moniker class. (See the StringFromCLSID function.)
	/// </para>
	/// <para>
	/// If the pszKey parameter matches the name of an existing key in the bind context's table, the new object replaces the existing
	/// object in the table.
	/// </para>
	/// <para>When you register an object using this method, the object is not released until one of the following occurs:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>It is replaced in the table by another object with the same key.</term>
	/// </item>
	/// <item>
	/// <term>It is removed from the table by a call to IBindCtxV::RevokeObjectParam.</term>
	/// </item>
	/// <item>
	/// <term>The bind context is released. All registered objects are released when the bind context is released.</term>
	/// </item>
	/// </list>
	/// </remarks>
	HRESULT IBindCtxV.RegisterObjectParam([MarshalAs(UnmanagedType.LPWStr)] string pszKey, [In, MarshalAs(UnmanagedType.Interface)] object punk) =>
		iBindCtx.RegisterObjectParam(pszKey, punk ?? new CDummyUnknown(Guid.Empty));

	/// <summary>Releases all pointers to all objects that were previously registered by calls to RegisterObjectBound.</summary>
	/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	/// <remarks>
	/// <para>
	/// You rarely call this method directly. The system's IBindCtxV implementation calls this method when the pointer to the
	/// <c>IBindCtxV</c> interface on the bind context is released (the bind context is released). If a bind context is not released,
	/// all of the registered objects remain active.
	/// </para>
	/// <para>
	/// If the same object has been registered more than once, this method calls the Release method on the object the number of times it
	/// was registered.
	/// </para>
	/// </remarks>
	HRESULT IBindCtxV.ReleaseBoundObjects() => iBindCtx.ReleaseBoundObjects();

	/// <summary>Releases all pointers to all objects that were previously registered by calls to RegisterObjectBound.</summary>
	/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	/// <remarks>
	/// <para>
	/// You rarely call this method directly. The system's IBindCtx implementation calls this method when the pointer to the
	/// <c>IBindCtx</c> interface on the bind context is released (the bind context is released). If a bind context is not released, all
	/// of the registered objects remain active.
	/// </para>
	/// <para>
	/// If the same object has been registered more than once, this method calls the Release method on the object the number of times it
	/// was registered.
	/// </para>
	/// </remarks>
	void IBindCtx.ReleaseBoundObjects() => iBindCtx.ReleaseBoundObjects();

	/// <summary>Removes the object from the bind context, undoing a previous call to RegisterObjectBound.</summary>
	/// <param name="punk">A pointer to the IUnknown interface on the object to be removed.</param>
	/// <returns>
	/// <para>This method can return the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>The object was released successfully.</term>
	/// </item>
	/// <item>
	/// <term>MK_E_NOTBOUND</term>
	/// <term>The object was not previously registered.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>You would rarely call this method. It is documented primarily for completeness.</remarks>
	HRESULT IBindCtxV.RevokeObjectBound([In, MarshalAs(UnmanagedType.Interface)] object punk) => iBindCtx.RevokeObjectBound(punk);

	/// <summary>Removes the object from the bind context, undoing a previous call to RegisterObjectBound.</summary>
	/// <param name="punk">A pointer to the IUnknown interface on the object to be removed.</param>
	/// <returns>
	/// <para>This method can return the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>The object was released successfully.</term>
	/// </item>
	/// <item>
	/// <term>MK_E_NOTBOUND</term>
	/// <term>The object was not previously registered.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>You would rarely call this method. It is documented primarily for completeness.</remarks>
	void IBindCtx.RevokeObjectBound([In, MarshalAs(UnmanagedType.Interface)] object punk) => iBindCtx.RevokeObjectBound(punk);

	/// <summary>
	/// Removes the specified key and its associated pointer from the bind context's string-keyed table of objects. The key must have
	/// previously been inserted into the table with a call to RegisterObjectParam.
	/// </summary>
	/// <param name="pszKey">The bind context string key to be removed. Key string comparison is case-sensitive.</param>
	/// <returns>
	/// <para>This method can return the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>The specified key was removed successfully.</term>
	/// </item>
	/// <item>
	/// <term>S_FALSE</term>
	/// <term>The object was not previously registered.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// A bind context maintains a table of interface pointers, each associated with a string key. This enables communication between a
	/// moniker implementation and the caller that initiated the binding operation. One party can store an interface pointer under a
	/// string known to both parties so that the other party can later retrieve it from the bind context.
	/// </para>
	/// <para>
	/// This method is used to remove an entry from the table. If the specified key is found, the bind context also releases its
	/// reference to the object.
	/// </para>
	/// </remarks>
	HRESULT IBindCtxV.RevokeObjectParam([MarshalAs(UnmanagedType.LPWStr)] string pszKey) => iBindCtx.RevokeObjectParam(pszKey);

	/// <summary>
	/// Removes the specified key and its associated pointer from the bind context's string-keyed table of objects. The key must have
	/// previously been inserted into the table with a call to RegisterObjectParam.
	/// </summary>
	/// <param name="pszKey">The bind context string key to be removed. Key string comparison is case-sensitive.</param>
	/// <returns>
	/// <para>This method can return the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>The specified key was removed successfully.</term>
	/// </item>
	/// <item>
	/// <term>S_FALSE</term>
	/// <term>The object was not previously registered.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// A bind context maintains a table of interface pointers, each associated with a string key. This enables communication between a
	/// moniker implementation and the caller that initiated the binding operation. One party can store an interface pointer under a
	/// string known to both parties so that the other party can later retrieve it from the bind context.
	/// </para>
	/// <para>
	/// This method is used to remove an entry from the table. If the specified key is found, the bind context also releases its
	/// reference to the object.
	/// </para>
	/// </remarks>
	int IBindCtx.RevokeObjectParam([MarshalAs(UnmanagedType.LPWStr)] string pszKey) => (int)iBindCtx.RevokeObjectParam(pszKey);

	/// <summary>Sets new values for the binding parameters stored in the bind context.</summary>
	/// <param name="pbindopts">A pointer to a BIND_OPTS, BIND_OPTS2, or BIND_OPTS3 structure containing the binding parameters.</param>
	/// <returns>This method can return the standard return values E_OUTOFMEMORY and S_OK.</returns>
	/// <remarks>
	/// <para>
	/// A bind context contains a block of parameters that are common to most IMoniker operations. These parameters do not change as the
	/// operation moves from piece to piece of a composite moniker.
	/// </para>
	/// <para>Subsequent binding operations can call IBindCtxV::GetBindOptions to retrieve these parameters.</para>
	/// <para>Notes to Callers</para>
	/// <para>This method can be called by moniker clients (those who use monikers to acquire interface pointers to objects).</para>
	/// <para>
	/// When you first create a bind context by using the CreateBindCtx function, the fields of the BIND_OPTS structure are initialized
	/// to the following values:
	/// </para>
	/// <para>
	/// You can use the <c>IBindCtxV::SetBindOptions</c> method to modify these values before using the bind context, if you want values
	/// other than the defaults.
	/// </para>
	/// <para>
	/// <c>SetBindOptions</c> copies the members of the specified structure, but not the COSERVERINFO structure and the pointers it
	/// contains. Callers may not free these pointers until the bind context is released.
	/// </para>
	/// </remarks>
	HRESULT IBindCtxV.SetBindOptions([In] BIND_OPTS_V pbindopts) => iBindCtx.SetBindOptions(pbindopts);

	/// <summary>Sets new values for the binding parameters stored in the bind context.</summary>
	/// <param name="pbindopts">A pointer to a BIND_OPTS, BIND_OPTS2, or BIND_OPTS3 structure containing the binding parameters.</param>
	/// <returns>This method can return the standard return values E_OUTOFMEMORY and S_OK.</returns>
	/// <remarks>
	/// <para>
	/// A bind context contains a block of parameters that are common to most IMoniker operations. These parameters do not change as the
	/// operation moves from piece to piece of a composite moniker.
	/// </para>
	/// <para>Subsequent binding operations can call IBindCtx::GetBindOptions to retrieve these parameters.</para>
	/// <para>Notes to Callers</para>
	/// <para>This method can be called by moniker clients (those who use monikers to acquire interface pointers to objects).</para>
	/// <para>
	/// When you first create a bind context by using the CreateBindCtx function, the fields of the BIND_OPTS structure are initialized
	/// to the following values:
	/// </para>
	/// <para>
	/// You can use the <c>IBindCtx::SetBindOptions</c> method to modify these values before using the bind context, if you want values
	/// other than the defaults.
	/// </para>
	/// <para>
	/// <c>SetBindOptions</c> copies the members of the specified structure, but not the COSERVERINFO structure and the pointers it
	/// contains. Callers may not free these pointers until the bind context is released.
	/// </para>
	/// </remarks>
	void IBindCtx.SetBindOptions(ref BIND_OPTS pbindopts) => iBindCtx.SetBindOptions(pbindopts).ThrowIfFailed();

	[DllImport(Lib.Ole32, ExactSpelling = true)]
	private static extern HRESULT CreateBindCtx([Optional] uint reserved, out IBindCtxV ppbc);

	private BIND_OPTS_V GetBindOps()
	{
		var bo = Environment.OSVersion.Version.Major < 6 ? new BIND_OPTS2() : new BIND_OPTS3();
		((IBindCtxV)this).GetBindOptions(bo).ThrowIfFailed();
		return bo;
	}

	private T GetOptionValue<T>(string fieldName) => GetBindOps().GetFieldValue<T>(fieldName) ?? throw new ArgumentException("Unrecognized field name.", nameof(fieldName));

	private void SetOptionValue<T>(string fieldName, T value)
	{
		var bo = GetBindOps();
		bo.SetFieldValue(fieldName, value);
		((IBindCtxV)this).SetBindOptions(bo).ThrowIfFailed();
	}

	[ComVisible(true)]
	private class CDummyUnknown : IPersist
	{
		private readonly Guid _clsid;

		public CDummyUnknown(in Guid clsid) => _clsid = clsid;

		public Guid GetClassID() => _clsid;
	}

	[ComVisible(true)]
	private class CFileSysBindData : IFileSystemBindData, IFileSystemBindData2
	{
		// file system bind data is a parameter passed to IShellFolder::ParseDisplayName() to provide the item information to the file system
		// data source. this will enable parsing of items that do not exist and avoiding accessing the disk in the parse operation {fc0a77e6-9d70-4258-9783-6dab1d0fe31e}
		private static readonly Guid CLSID_UnknownJunction = new(0xfc0a77e6, 0x9d70, 0x4258, 0x97, 0x83, 0x6d, 0xab, 0x1d, 0x0f, 0xe3, 0x1e);

		private Guid _clsidJunction = CLSID_UnknownJunction;
		private WIN32_FIND_DATA _fd;
		private long _liFileID;

		public CFileSysBindData(in WIN32_FIND_DATA pfd) => SetFindData(pfd);

		public HRESULT GetFileID(out long pliFileID) { pliFileID = _liFileID; return HRESULT.S_OK; }

		public HRESULT GetFindData(out WIN32_FIND_DATA pfd) { pfd = _fd; return HRESULT.S_OK; }

		public HRESULT GetJunctionCLSID(out Guid pclsid)
		{
			if (_clsidJunction != CLSID_UnknownJunction)
			{
				pclsid = _clsidJunction;
				return HRESULT.S_OK;
			}
			pclsid = Guid.Empty;
			return HRESULT.E_FAIL;
		}

		public HRESULT SetFileID(long liFileID) { _liFileID = liFileID; return HRESULT.S_OK; }

		public HRESULT SetFindData(in WIN32_FIND_DATA pfd) { _fd = pfd; return HRESULT.S_OK; }

		public HRESULT SetJunctionCLSID(in Guid clsid) { _clsidJunction = clsid; return HRESULT.S_OK; }
	}
}