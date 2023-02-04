using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using STATSTG = System.Runtime.InteropServices.ComTypes.STATSTG;

namespace Vanara.PInvoke
{
	public static partial class Ole32
	{
		/// <summary>Undocumented.</summary>
		[PInvokeData("objidl.h")]
		public enum ACTIVATIONTYPE
		{
			/// <summary>Undocumented.</summary>
			ACTIVATIONTYPE_UNCATEGORIZED = 0x0,

			/// <summary>Undocumented.</summary>
			ACTIVATIONTYPE_FROM_MONIKER = 0x1,

			/// <summary>Undocumented.</summary>
			ACTIVATIONTYPE_FROM_DATA = 0x2,

			/// <summary>Undocumented.</summary>
			ACTIVATIONTYPE_FROM_STORAGE = 0x4,

			/// <summary>Undocumented.</summary>
			ACTIVATIONTYPE_FROM_STREAM = 0x8,

			/// <summary>Undocumented.</summary>
			ACTIVATIONTYPE_FROM_FILE = 0x10
		}

		/// <summary/>
		[PInvokeData("objidl.h", MSDNShortId = "NN:objidl.ISurrogateService")]
		public enum ApplicationType
		{
			/// <summary/>
			ServerApplication,

			/// <summary/>
			LibraryApplication
		}

		/// <summary>Controls aspects of moniker binding operations.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/ne-objidl-tagbind_flags typedef enum tagBIND_FLAGS {
		// BIND_MAYBOTHERUSER, BIND_JUSTTESTEXISTENCE } BIND_FLAGS;
		[PInvokeData("objidl.h", MSDNShortId = "e8884e82-5de2-4a1f-b79c-d431afe9e87e")]
		[Flags]
		public enum BIND_FLAGS
		{
			/// <summary>
			/// If this flag is specified, the moniker implementation can interact with the end user. Otherwise, the moniker implementation
			/// should not interact with the user in any way, such as by asking for a password for a network volume that needs mounting. If
			/// prohibited from interacting with the user when it otherwise would, a moniker implementation can use a different algorithm
			/// that does not require user interaction, or it can fail with the error MK_E_MUSTBOTHERUSER.
			/// </summary>
			BIND_MAYBOTHERUSER = 1,

			/// <summary>
			/// If this flag is specified, the caller is not interested in having the operation carried out, but only in learning whether
			/// the operation could have been carried out had this flag not been specified. For example, this flag lets the caller indicate
			/// only an interest in finding out whether an object actually exists by using this flag in a IMoniker::BindToObject call.
			/// Moniker implementations can, however, ignore this possible optimization and carry out the operation in full. Callers must be
			/// able to deal with both cases.
			/// </summary>
			BIND_JUSTTESTEXISTENCE = 2,
		}

		/// <summary>Specifies the call types used by IMessageFilter::HandleInComingCall.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/ne-objidl-calltype typedef enum tagCALLTYPE { CALLTYPE_TOPLEVEL,
		// CALLTYPE_NESTED, CALLTYPE_ASYNC, CALLTYPE_TOPLEVEL_CALLPENDING, CALLTYPE_ASYNC_CALLPENDING } CALLTYPE;
		[PInvokeData("objidl.h", MSDNShortId = "341d429d-8f45-461f-bc77-36e191faecc2")]
		public enum CALLTYPE
		{
			/// <summary>
			/// A top-level call has arrived and the object is not currently waiting for a reply from a previous outgoing call. Calls of
			/// this type should always be handled.
			/// </summary>
			CALLTYPE_TOPLEVEL = 1,

			/// <summary>
			/// A call has arrived bearing the same logical thread identifier as that of a previous outgoing call for which the object is
			/// still awaiting a reply. Calls of this type should always be handled.
			/// </summary>
			CALLTYPE_NESTED,

			/// <summary>An asynchronous call has arrived. Calls of this type cannot be rejected. OLE always delivers calls of this type.</summary>
			CALLTYPE_ASYNC,

			/// <summary>
			/// A new top-level call has arrived with a new logical thread identifier and the object is currently waiting for a reply from a
			/// previous outgoing call. Calls of this type may be handled or rejected.
			/// </summary>
			CALLTYPE_TOPLEVEL_CALLPENDING,

			/// <summary>
			/// An asynchronous call has arrived with a new logical thread identifier and the object is currently waiting for a reply from a
			/// previous outgoing call. Calls of this type cannot be rejected.
			/// </summary>
			CALLTYPE_ASYNC_CALLPENDING,
		}

		/// <summary>Specifies the return values for the IMessageFilter::MessagePending method.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/ne-objidl-pendingmsg typedef enum tagPENDINGMSG {
		// PENDINGMSG_CANCELCALL, PENDINGMSG_WAITNOPROCESS, PENDINGMSG_WAITDEFPROCESS } PENDINGMSG;
		[PInvokeData("objidl.h", MSDNShortId = "105bbcd4-b1b2-444d-bd55-7f6e564fec42")]
		public enum PENDINGMSG
		{
			/// <summary>Cancel the outgoing call.</summary>
			PENDINGMSG_CANCELCALL,

			/// <summary>Wait for the return and don't dispatch the message.</summary>
			PENDINGMSG_WAITNOPROCESS,

			/// <summary>Wait and dispatch the message.</summary>
			PENDINGMSG_WAITDEFPROCESS,
		}

		/// <summary>Indicates the level of nesting in the IMessageFilter::MessagePending method.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/ne-objidl-pendingtype typedef enum tagPENDINGTYPE {
		// PENDINGTYPE_TOPLEVEL, PENDINGTYPE_NESTED } PENDINGTYPE;
		[PInvokeData("objidl.h", MSDNShortId = "8f167342-5398-4ecc-9b56-dcf2b4248c65")]
		public enum PENDINGTYPE
		{
			/// <summary>Top-level call.</summary>
			PENDINGTYPE_TOPLEVEL = 1,

			/// <summary>Nested call.</summary>
			PENDINGTYPE_NESTED,
		}

		/// <summary>Flags used by <see cref="IRunningObjectTable.Register"/></summary>
		[PInvokeData("wtypes.h")]
		[Flags]
		public enum ROTFLAGS
		{
			/// <summary>When set, indicates a strong registration for the object.</summary>
			ROTFLAGS_REGISTRATIONKEEPSALIVE = 0x1,

			/// <summary>
			/// When set, any client can connect to the running object through its entry in the ROT.When not set, only clients in the window
			/// station that registered the object can connect to it.
			/// </summary>
			ROTFLAGS_ALLOWANYCLIENT = 0x2,
		}

		/// <summary>Indicates the status of server call.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/ne-objidl-servercall typedef enum tagSERVERCALL { SERVERCALL_ISHANDLED,
		// SERVERCALL_REJECTED, SERVERCALL_RETRYLATER } SERVERCALL;
		[PInvokeData("objidl.h", MSDNShortId = "2a9b5e85-44b9-43c1-b3e5-a8f2c140b674")]
		public enum SERVERCALL
		{
			/// <summary>The object may be able to process the call.</summary>
			SERVERCALL_ISHANDLED,

			/// <summary>The object cannot handle the call due to an unforeseen problem, such as network unavailability.</summary>
			SERVERCALL_REJECTED,

			/// <summary>
			/// The object cannot handle the call at this time. For example, an application might return this value when it is in a
			/// user-controlled modal state.
			/// </summary>
			SERVERCALL_RETRYLATER,
		}

		/// <summary/>
		[PInvokeData("objidl.h", MSDNShortId = "NN:objidl.ISurrogateService")]
		public enum ShutdownType
		{
			/// <summary/>
			IdleShutdown,

			/// <summary/>
			ForcedShutdown
		}

		/// <summary>
		/// The <c>STGTY</c> enumeration values are used in the <c>type</c> member of the STATSTG structure to indicate the type of the
		/// storage element. A storage element is a storage object, a stream object, or a byte-array object (LOCKBYTES).
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/ne-objidl-stgty typedef enum tagSTGTY { STGTY_STORAGE, STGTY_STREAM,
		// STGTY_LOCKBYTES, STGTY_PROPERTY } STGTY;
		[PInvokeData("objidl.h", MSDNShortId = "67189e7a-b089-4a29-adf8-ad7c459c7974")]
		public enum STGTY : uint
		{
			/// <summary>Indicates that the storage element is a storage object.</summary>
			STGTY_STORAGE = 1,

			/// <summary>Indicates that the storage element is a stream object.</summary>
			STGTY_STREAM,

			/// <summary>Indicates that the storage element is a byte-array object.</summary>
			STGTY_LOCKBYTES,

			/// <summary>Indicates that the storage element is a property storage object.</summary>
			STGTY_PROPERTY,
		}

		/// <summary>
		/// The <c>IAdviseSink2</c> interface is an extension of the IAdviseSink interface, adding the method OnLinkSrcChange to the
		/// contract to handle a change in the moniker of a linked object. This avoids overloading the implementation IAdviseSink::OnRename
		/// to handle the renaming of both embedded objects and linked objects. In applications where different blocks of code might execute
		/// depending on which of these two similar events has occurred, using the same method for both events complicates testing and debugging.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nn-objidl-iadvisesink2
		[PInvokeData("objidl.h", MSDNShortId = "NN:objidl.IAdviseSink2")]
		[ComImport, Guid("00000125-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IAdviseSink2 : IAdviseSink
		{
			/// <summary>
			/// Notifies the container that registered the advise sink that a link source has changed (either name or location), enabling
			/// the container to update the link's moniker.
			/// </summary>
			/// <param name="pmk">A pointer to the IMoniker interface identifying the source of a linked object.</param>
			/// <returns>None</returns>
			/// <remarks>
			/// <para>
			/// A container of linked objects implements this method to receive notification in the event of a change in the moniker of its
			/// link source.
			/// </para>
			/// <para>
			/// <c>OnLinkSrcChange</c> is called by the OLE link object when it receives the OnRename notification from the link-source
			/// (object) application. The link object updates its moniker and sends the <c>OnLinkSrcChange</c> notification to containers
			/// that have implemented IAdviseSink2.
			/// </para>
			/// <para>Notes to Implementers</para>
			/// <para>
			/// Nothing prevents a link object from notifying its container of the moniker change by calling OnRename instead of
			/// <c>OnLinkSrcChange</c>. In practice, however, overloading <c>OnRename</c> to mean either that a link object's moniker has
			/// changed or that an embedded object's server name has changed makes it difficult for applications to determine which of these
			/// events has occurred. If the two events trigger different processing, as will often be the case, calling a different method
			/// for each makes the job of determining which event occurred much easier.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-iadvisesink2-onlinksrcchange void OnLinkSrcChange(
			// IMoniker *pmk );
			[PreserveSig]
			void OnLinkSrcChange([In] IMoniker pmk);
		}

		/// <summary>Marks an interface as agile across apartments.</summary>
		/// <remarks>
		/// <para>
		/// The <c>IAgileObject</c> interface is a marker interface that indicates that an object is free threaded and can be called from
		/// any apartment.
		/// </para>
		/// <para>
		/// Unlike what happens when aggregating the Free Threaded Marshaler (FTM), implementing the <c>IAgileObject</c> interface doesn't
		/// affect what happens when marshaling a call. Instead, the <c>IAgileObject</c> interface is recognized by the Global Interface
		/// Table (GIT). When an object that implements the <c>IAgileObject</c> interface is placed in the GIT and localized to another
		/// apartment, the object is called directly in the new apartment, rather than marshaling.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nn-objidl-iagileobject
		[PInvokeData("objidl.h", MSDNShortId = "787A22DE-AEAB-4570-BB97-C49D656E5D40")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("94ea2b94-e9cc-49e0-c0ff-ee64ca8f5b90")]
		public interface IAgileObject
		{
		}

		/// <summary>Enables retrieving an agile reference to an object.</summary>
		/// <remarks>Call the RoGetAgileReference function to create an agile reference to an object.</remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nn-objidl-iagilereference
		[PInvokeData("objidl.h", MSDNShortId = "51787A45-BCDE-4028-A338-1C16F2DE79AD")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("C03F6A43-65A4-9818-987E-E0B810D2A6F2")]
		public interface IAgileReference
		{
			/// <summary>Gets the interface ID of an agile reference to an object.</summary>
			/// <param name="riid">The riid.</param>
			/// <returns>On successful completion, *ppvObjectReference is a pointer to the interface specified by riid.</returns>
			/// <remarks>
			/// Call the RoGetAgileReference function to create an agile reference to an object. Call the <c>Resolve</c> method to localize
			/// the object into the apartment in which <c>Resolve</c> is called.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-iagilereference-resolve%28q_%29 HRESULT __clrcall
			// Resolve( Q **pp, );
			[return: MarshalAs(UnmanagedType.IUnknown)]
			object Resolve(in Guid riid);
		}

		/// <summary>
		/// Provides access to a bind context, which is an object that stores information about a particular moniker binding operation.
		/// </summary>
		/// <remarks>
		/// <para>A bind context includes the following information:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// A BIND_OPTS structure containing a set of parameters that do not change during the binding operation. When a composite moniker
		/// is bound, each component uses the same bind context, so it acts as a mechanism for passing the same parameters to each component
		/// of a composite moniker.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// A set of pointers to objects that the binding operation has activated. The bind context holds pointers to these bound objects,
		/// keeping them loaded and thus eliminating redundant activations if the objects are needed again during subsequent binding operations.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// A pointer to the running object table (ROT) on the same computer as the process that started the bind operation. Moniker
		/// implementations that need to access the ROT should use the IBindCtx::GetRunningObjectTable method rather than using the
		/// GetRunningObjectTable function. This allows future enhancements to the system's <c>IBindCtx</c> implementation to modify binding behavior.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// A table of interface pointers, each associated with a string key. This capability enables moniker implementations to store
		/// interface pointers under a well-known string so that they can later be retrieved from the bind context. For example, OLE defines
		/// several string keys ("ExceededDeadline", "ConnectManually", and so on) that can be used to store a pointer to the object that
		/// caused an error during a binding operation.
		/// </term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nn-objidl-ibindctx
		[PInvokeData("objidl.h", MSDNShortId = "e4c8abb5-0c89-44dd-8d95-efbfcc999b46")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("0000000e-0000-0000-C000-000000000046")]
		public interface IBindCtxV
		{
			/// <summary>
			/// Registers an object with the bind context to ensure that the object remains active until the bind context is released.
			/// </summary>
			/// <param name="punk">A pointer to the IUnknown interface on the object that is being registered as bound.</param>
			/// <returns>This method can return the standard return values E_OUTOFMEMORY and S_OK.</returns>
			/// <remarks>
			/// <para>
			/// Those writing a new moniker class (through an implementation of the IMoniker interface) should call this method whenever the
			/// implementation activates an object. This happens most often in the course of binding a moniker, but it can also happen while
			/// retrieving a moniker's display name, parsing a display name into a moniker, or retrieving the time that an object was last modified.
			/// </para>
			/// <para>
			/// <c>RegisterObjectBound</c> calls AddRef to create an additional reference to the object. You must, however, still release
			/// your own copy of the pointer. Calling this method twice for the same object creates two references to that object. You can
			/// release a reference obtained through a call to this method by calling IBindCtx::RevokeObjectBound. All references held by
			/// the bind context are released when the bind context itself is released.
			/// </para>
			/// <para>
			/// Calling <c>RegisterObjectBound</c> to register an object with a bind context keeps the object active until the bind context
			/// is released. Reusing a bind context in a subsequent binding operation (either for another piece of the same composite
			/// moniker or for a different moniker) can make the subsequent binding operation more efficient because it doesn't have to
			/// reload that object. This, however, improves performance only if the subsequent binding operation requires some of the same
			/// objects as the original one, so you need to balance the possible performance improvement of reusing a bind context against
			/// the costs of keeping objects activated unnecessarily.
			/// </para>
			/// <para>
			/// IBindCtx does not provide a method to retrieve a pointer to an object registered using <c>RegisterObjectBound</c>. Assuming
			/// the object has registered itself with the running object table, moniker implementations can call
			/// IRunningObjectTable::GetObject to retrieve a pointer to the object.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ibindctx-registerobjectbound HRESULT
			// RegisterObjectBound( IUnknown *punk );
			[PInvokeData("objidl.h", MSDNShortId = "84d49231-5fdd-4a89-8e76-1f0e56bc553f")]
			[PreserveSig]
			HRESULT RegisterObjectBound([In, MarshalAs(UnmanagedType.Interface)] object punk);

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
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ibindctx-revokeobjectbound HRESULT RevokeObjectBound(
			// IUnknown *punk );
			[PInvokeData("objidl.h", MSDNShortId = "c49421a3-1733-4f54-8e30-d23641f13c38")]
			[PreserveSig]
			HRESULT RevokeObjectBound([In, MarshalAs(UnmanagedType.Interface)] object punk);

			/// <summary>Releases all pointers to all objects that were previously registered by calls to RegisterObjectBound.</summary>
			/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
			/// <remarks>
			/// <para>
			/// You rarely call this method directly. The system's IBindCtx implementation calls this method when the pointer to the
			/// <c>IBindCtx</c> interface on the bind context is released (the bind context is released). If a bind context is not released,
			/// all of the registered objects remain active.
			/// </para>
			/// <para>
			/// If the same object has been registered more than once, this method calls the Release method on the object the number of
			/// times it was registered.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ibindctx-releaseboundobjects HRESULT
			// ReleaseBoundObjects( );
			[PInvokeData("objidl.h", MSDNShortId = "12107633-6e7f-4d41-8e5c-5739cff98552")]
			[PreserveSig]
			HRESULT ReleaseBoundObjects();

			/// <summary>Sets new values for the binding parameters stored in the bind context.</summary>
			/// <param name="pbindopts">A pointer to a BIND_OPTS, BIND_OPTS2, or BIND_OPTS3 structure containing the binding parameters.</param>
			/// <returns>This method can return the standard return values E_OUTOFMEMORY and S_OK.</returns>
			/// <remarks>
			/// <para>
			/// A bind context contains a block of parameters that are common to most IMoniker operations. These parameters do not change as
			/// the operation moves from piece to piece of a composite moniker.
			/// </para>
			/// <para>Subsequent binding operations can call IBindCtx::GetBindOptions to retrieve these parameters.</para>
			/// <para>Notes to Callers</para>
			/// <para>This method can be called by moniker clients (those who use monikers to acquire interface pointers to objects).</para>
			/// <para>
			/// When you first create a bind context by using the CreateBindCtx function, the fields of the BIND_OPTS structure are
			/// initialized to the following values:
			/// </para>
			/// <para>
			/// You can use the <c>IBindCtx::SetBindOptions</c> method to modify these values before using the bind context, if you want
			/// values other than the defaults.
			/// </para>
			/// <para>
			/// <c>SetBindOptions</c> copies the members of the specified structure, but not the COSERVERINFO structure and the pointers it
			/// contains. Callers may not free these pointers until the bind context is released.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ibindctx-setbindoptions HRESULT SetBindOptions(
			// BIND_OPTS *pbindopts );
			[PInvokeData("objidl.h", MSDNShortId = "9dcce48e-567e-42b4-8df2-2bc861cb5fcb")]
			[PreserveSig]
			HRESULT SetBindOptions([In] BIND_OPTS_V pbindopts);

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
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ibindctx-getbindoptions HRESULT GetBindOptions(
			// BIND_OPTS *pbindopts );
			[PInvokeData("objidl.h", MSDNShortId = "ccb239ee-922f-4e66-8aca-7651c0243a2b")]
			[PreserveSig]
			HRESULT GetBindOptions([In, Out] BIND_OPTS_V pbindopts);

			/// <summary>
			/// Retrieves an interface pointer to the running object table (ROT) for the computer on which this bind context is running.
			/// </summary>
			/// <param name="pprot">
			/// The address of a IRunningObjectTable pointer variable that receives the interface pointer to the running object table. If an
			/// error occurs, *pprot is set to <c>NULL</c>. If *pprot is non- <c>NULL</c>, the implementation calls AddRef on the running
			/// table object; it is the caller's responsibility to call Release.
			/// </param>
			/// <returns>This method can return the standard return values E_OUTOFMEMORY, E_UNEXPECTED, and S_OK.</returns>
			/// <remarks>
			/// <para>
			/// The running object table is a globally accessible table on each computer. It keeps track of all the objects that are
			/// currently running on the computer.
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
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ibindctx-getrunningobjecttable HRESULT
			// GetRunningObjectTable( IRunningObjectTable **pprot );
			[PInvokeData("objidl.h", MSDNShortId = "26938d07-d772-4e72-a6aa-57dd2f2cece1")]
			[PreserveSig]
			HRESULT GetRunningObjectTable(out IRunningObjectTable pprot);

			/// <summary>Associates an object with a string key in the bind context's string-keyed table of pointers.</summary>
			/// <param name="pszKey">The bind context string key under which the object is being registered. Key string comparison is case-sensitive.</param>
			/// <param name="punk">
			/// <para>A pointer to the IUnknown interface on the object that is to be registered.</para>
			/// <para>The method calls AddRef on the pointer.</para>
			/// </param>
			/// <returns>This method can return the standard return values E_OUTOFMEMORY and S_OK.</returns>
			/// <remarks>
			/// <para>
			/// A bind context maintains a table of interface pointers, each associated with a string key. This enables communication
			/// between a moniker implementation and the caller that initiated the binding operation. One party can store an interface
			/// pointer under a string known to both parties so that the other party can later retrieve it from the bind context.
			/// </para>
			/// <para>Binding operations subsequent to the use of this method can use IBindCtx::GetObjectParam to retrieve the stored pointer.</para>
			/// <para>Notes to Callers</para>
			/// <para>
			/// <c>RegisterObjectParam</c> is useful to those implementing a new moniker class (through an implementation of IMoniker) and
			/// to moniker clients (those who use monikers to bind to objects).
			/// </para>
			/// <para>
			/// In implementing a new moniker class, you call this method when an error occurs during moniker binding to inform the caller
			/// of the cause of the error. The key that you would obtain with a call to this method would depend on the error condition.
			/// Following is a list of common moniker binding errors, describing for each the keys that would be appropriate:
			/// </para>
			/// <list type="bullet">
			/// <item>
			/// <term>
			/// MK_E_EXCEEDEDDEADLINEâ€”If a binding operation exceeds its deadline because a given object is not running, you should
			/// register the object's moniker using the first unused key from the list: "ExceededDeadline", "ExceededDeadline1",
			/// "ExceededDeadline2", and so on. If the caller later finds the moniker in the running object table, the caller can retry the
			/// binding operation.
			/// </term>
			/// </item>
			/// <item>
			/// <term>
			/// MK_E_CONNECTMANUALLYâ€”The "ConnectManually" key indicates a moniker whose binding requires assistance from the end user. To
			/// request that the end user manually connect to the object, the caller can retry the binding operation after showing the
			/// moniker's display name. Common reasons for this error are that a password is needed or that a floppy needs to be mounted.
			/// </term>
			/// </item>
			/// <item>
			/// <term>
			/// E_CLASSNOTFOUNDâ€”The "ClassNotFound" key indicates a moniker whose class could not be found. (The server for the object
			/// identified by this moniker could not be located.) If this key is used for an OLE compound-document object, the caller can
			/// use IMoniker::BindToStorage to bind to the object and then try to carry out a <c>Treat As...</c> or <c>Convert To...</c>
			/// operation to associate the object with a different server. If this is successful, the caller can retry the binding operation.
			/// </term>
			/// </item>
			/// </list>
			/// <para>
			/// A moniker client with detailed knowledge of the implementation of the moniker can also call this method to pass private
			/// information to that implementation.
			/// </para>
			/// <para>
			/// You can define new strings as keys for storing pointers. By convention, you should use key names that begin with the string
			/// form of the CLSID of the moniker class. (See the StringFromCLSID function.)
			/// </para>
			/// <para>
			/// If the pszKey parameter matches the name of an existing key in the bind context's table, the new object replaces the
			/// existing object in the table.
			/// </para>
			/// <para>When you register an object using this method, the object is not released until one of the following occurs:</para>
			/// <list type="bullet">
			/// <item>
			/// <term>It is replaced in the table by another object with the same key.</term>
			/// </item>
			/// <item>
			/// <term>It is removed from the table by a call to IBindCtx::RevokeObjectParam.</term>
			/// </item>
			/// <item>
			/// <term>The bind context is released. All registered objects are released when the bind context is released.</term>
			/// </item>
			/// </list>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ibindctx-registerobjectparam HRESULT
			// RegisterObjectParam( LPOLESTR pszKey, IUnknown *punk );
			[PInvokeData("objidl.h", MSDNShortId = "7ee2b5b2-9b9c-41f1-8e58-7432ebc0f9ed")]
			[PreserveSig]
			HRESULT RegisterObjectParam([MarshalAs(UnmanagedType.LPWStr)] string pszKey, [In, MarshalAs(UnmanagedType.Interface)] object punk);

			/// <summary>
			/// Retrieves an interface pointer to the object associated with the specified key in the bind context's string-keyed table of pointers.
			/// </summary>
			/// <param name="pszKey">The bind context string key to be searched for. Key string comparison is case-sensitive.</param>
			/// <param name="ppunk">
			/// The address of an IUnknown pointer variable that receives the interface pointer to the object associated with pszKey. When
			/// successful, the implementation calls AddRef on *ppunk. It is the caller's responsibility to call Release. If an error
			/// occurs, the implementation sets *ppunk to <c>NULL</c>.
			/// </param>
			/// <returns>If the method succeeds, the return value is S_OK. Otherwise, it is E_FAIL.</returns>
			/// <remarks>
			/// <para>
			/// A bind context maintains a table of interface pointers, each associated with a string key. This enables communication
			/// between a moniker implementation and the caller that initiated the binding operation. One party can store an interface
			/// pointer under a string known to both parties so that the other party can later retrieve it from the bind context.
			/// </para>
			/// <para>
			/// The pointer this method retrieves must have previously been inserted into the table using the IBindCtx::RegisterObjectParam method.
			/// </para>
			/// <para>Notes to Callers</para>
			/// <para>
			/// Objects using monikers to locate other objects can call this method when a binding operation fails to get specific
			/// information about the error that occurred. Depending on the error, it may be possible to correct the situation and retry the
			/// binding operation. See IBindCtx::RegisterObjectParam for more information.
			/// </para>
			/// <para>
			/// Moniker implementations can call this method to handle situations where a caller initiates a binding operation and requests
			/// specific information. By convention, the implementer should use key names that begin with the string form of the CLSID of a
			/// moniker class. (See the StringFromCLSID function.)
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ibindctx-getobjectparam HRESULT GetObjectParam(
			// LPOLESTR pszKey, IUnknown **ppunk );
			[PInvokeData("objidl.h", MSDNShortId = "8f423495-7a34-4901-968e-1fe204680d8a")]
			[PreserveSig]
			HRESULT GetObjectParam([MarshalAs(UnmanagedType.LPWStr)] string pszKey, [MarshalAs(UnmanagedType.Interface)] out object ppunk);

			/// <summary>
			/// Retrieves a pointer to an interface that can be used to enumerate the keys of the bind context's string-keyed table of pointers.
			/// </summary>
			/// <param name="ppenum">
			/// The address of an IEnumString pointer variable that receives the interface pointer to the enumerator. If an error occurs,
			/// *ppenum is set to <c>NULL</c>. If *ppenum is non- <c>NULL</c>, the implementation calls AddRef on *ppenum; it is the caller's
			/// responsibility to call Release.
			/// </param>
			/// <returns>This method can return the standard return values E_OUTOFMEMORY and S_OK.</returns>
			/// <remarks>
			/// <para>The keys returned by the enumerator are the ones previously specified in calls to IBindCtx::RegisterObjectParam.</para>
			/// <para>Notes to Callers</para>
			/// <para>
			/// A bind context maintains a table of interface pointers, each associated with a string key. This enables communication
			/// between a moniker implementation and the caller that initiated the binding operation. One party can store an interface
			/// pointer under a string known to both parties so that the other party can later retrieve it from the bind context.
			/// </para>
			/// <para>
			/// In the system implementation of the IBindCtx interface, this method is not implemented. Therefore, calling this method
			/// results in a return value of E_NOTIMPL.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ibindctx-enumobjectparam HRESULT EnumObjectParam(
			// IEnumString **ppenum );
			[PInvokeData("objidl.h", MSDNShortId = "9e799ce4-e9b3-4b31-98a0-2167a0c19848")]
			[PreserveSig]
			HRESULT EnumObjectParam(out IEnumString ppenum);

			/// <summary>
			/// Removes the specified key and its associated pointer from the bind context's string-keyed table of objects. The key must
			/// have previously been inserted into the table with a call to RegisterObjectParam.
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
			/// A bind context maintains a table of interface pointers, each associated with a string key. This enables communication
			/// between a moniker implementation and the caller that initiated the binding operation. One party can store an interface
			/// pointer under a string known to both parties so that the other party can later retrieve it from the bind context.
			/// </para>
			/// <para>
			/// This method is used to remove an entry from the table. If the specified key is found, the bind context also releases its
			/// reference to the object.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ibindctx-revokeobjectparam HRESULT RevokeObjectParam(
			// LPOLESTR pszKey );
			[PInvokeData("objidl.h", MSDNShortId = "e7dbf9c8-0ecf-4076-8bec-4da457c60cee")]
			[PreserveSig]
			HRESULT RevokeObjectParam([MarshalAs(UnmanagedType.LPWStr)] string pszKey);
		}

		/// <summary>Provides a semaphore that can be used to provide temporarily exclusive access to a shared resource such as a file.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nn-objidl-iblockinglock
		[PInvokeData("objidl.h", MSDNShortId = "NN:objidl.IBlockingLock")]
		[ComImport, Guid("30f3d47a-6447-11d1-8e3c-00c04fb9386d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IBlockingLock
		{
			/// <summary>Requests a lock on a shared resource.</summary>
			/// <param name="dwTimeout">The time interval after which the attempted lock operation fails.</param>
			/// <returns>This method can return the standard return values E_INVALIDARG, E_OUTOFMEMORY, E_UNEXPECTED, E_FAIL, and S_OK.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-iblockinglock-lock HRESULT Lock( DWORD dwTimeout );
			[PreserveSig]
			HRESULT Lock(uint dwTimeout);

			/// <summary>Releases a lock on a shared resource.</summary>
			/// <returns>This method can return the standard return values E_INVALIDARG, E_OUTOFMEMORY, E_UNEXPECTED, E_FAIL, and S_OK.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-iblockinglock-unlock HRESULT Unlock();
			[PreserveSig]
			HRESULT Unlock();
		}

		/// <summary>Specifies a method that retrieves a class object.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nn-objidl-iclassactivator
		[PInvokeData("objidl.h", MSDNShortId = "NN:objidl.IClassActivator")]
		[ComImport, Guid("00000140-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IClassActivator
		{
			/// <summary>Retrieves a class object.</summary>
			/// <param name="rclsid">The CLSID that identifies the class whose class object is to be retrieved.</param>
			/// <param name="dwClassContext">The context in which the class is expected to run. For a list of values, see the CLSCTX enumeration.</param>
			/// <param name="locale">An LCID constant as defined in WinNls.h.</param>
			/// <param name="riid">The IID of the interface on the object to which a pointer is desired.</param>
			/// <param name="ppv">
			/// The address of pointer variable that receives the interface pointer requested in riid. Upon successful return, *ppv contains
			/// the requested interface pointer.
			/// </param>
			/// <returns>If the method succeeds, the return value is S_OK. Otherwise, it is E_FAIL.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-iclassactivator-getclassobject HRESULT GetClassObject(
			// REFCLSID rclsid, DWORD dwClassContext, LCID locale, REFIID riid, void **ppv );
			[PreserveSig]
			HRESULT GetClassObject(in Guid rclsid, CLSCTX dwClassContext, LCID locale, in Guid riid, [MarshalAs(UnmanagedType.Interface, IidParameterIndex = 3)] out object ppv);
		}

		/// <summary>
		/// <para>
		/// Creates and manages advisory connections between a data object and one or more advise sinks. Its methods are intended to be used
		/// to implement the advisory methods of IDataObject. <c>IDataAdviseHolder</c> is implemented on an advise holder object. Its
		/// methods establish and delete data advisory connections and send notification of change in data from a data object to an object
		/// that requires this notification, such as an OLE container, which must contain an advise sink.
		/// </para>
		/// <para>
		/// Advise sinks are objects that require notification of change in the data the object contains and implement the IAdviseSink
		/// interface. Advise sinks are also usually associated with OLE compound document containers.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nn-objidl-idataadviseholder
		[PInvokeData("objidl.h", MSDNShortId = "740a6366-6ab1-4a20-82df-1efdd62211eb")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("00000110-0000-0000-C000-000000000046")]
		public interface IDataAdviseHolder
		{
			/// <summary>Creates a connection between an advise sink and a data object for receiving notifications.</summary>
			/// <param name="pDataObject">
			/// A pointer to the IDataObject interface on the data object for which notifications are requested. If data in this object
			/// changes, a notification is sent to the advise sinks that have requested notification.
			/// </param>
			/// <param name="pFetc">
			/// A pointer to a FORMATETC structure that contains the specified format, medium, and target device that is of interest to the
			/// advise sink requesting notification. For example, one sink may want to know only when the bitmap representation of the data
			/// in the data object changes. Another sink may be interested in only the metafile format of the same object. Each advise sink
			/// is notified when the data of interest changes. This data is passed back to the advise sink when notification occurs.
			/// </param>
			/// <param name="advf">
			/// <para>
			/// A group of flags that control the advisory connection. Possible values are from the ADVF enumeration. However, only some of
			/// the possible <c>ADVF</c> values are relevant for this method. The following table briefly describes the relevant values; a
			/// more detailed description can be found in the description of the <c>ADVF</c> enumeration.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>ADVF_NODATA</term>
			/// <term>Asks that no data be sent along with the notification.</term>
			/// </item>
			/// <item>
			/// <term>ADVF_ONLYONCE</term>
			/// <term>
			/// Causes the advisory connection to be destroyed after the first notification is sent. An implicit call to
			/// IDataAdviseHolder::Unadvise is made on behalf of the caller to remove the connection.
			/// </term>
			/// </item>
			/// <item>
			/// <term>ADVF_PRIMEFIRST</term>
			/// <term>Causes an initial notification to be sent regardless of whether data has changed from its current state.</term>
			/// </item>
			/// <item>
			/// <term>ADVF_DATAONSTOP</term>
			/// <term>
			/// When specified with ADVF_NODATA, this flag causes a last notification with the data included to be sent before the data
			/// object is destroyed. When ADVF_NODATA is not specified, this flag has no effect.
			/// </term>
			/// </item>
			/// </list>
			/// </param>
			/// <param name="pAdvise">A pointer to the IAdviseSink interface on the advisory sink that receives the change notification.</param>
			/// <param name="pdwConnection">
			/// A pointer to a variable that receives a token that identifies this connection. The calling object can later delete the
			/// advisory connection by passing this token to IDataAdviseHolder::Unadvise. If this value is zero, the connection was not established.
			/// </param>
			/// <returns>This method returns S_OK on success.</returns>
			/// <remarks>
			/// <para>
			/// Through the connection established through this method, the advisory sink can receive future notifications in a call to IAdviseSink::OnDataChange.
			/// </para>
			/// <para>
			/// An object issues a call to IDataObject::DAdvise to request notification on changes to the format, medium, or target device
			/// of interest. This data is specified in the pFormatetc parameter. The <c>DAdvise</c> method is usually implemented to call
			/// <c>IDataAdviseHolder::Advise</c> to delegate the task of setting up and tracking a connection to the advise holder. When the
			/// format, medium, or target device in question changes, the data object calls IDataAdviseHolder::SendOnDataChange to send the
			/// necessary notifications.
			/// </para>
			/// <para>The established connection can be deleted by passing the value in pdwConnection in a call to IDataAdviseHolder::Unadvise.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-idataadviseholder-advise HRESULT Advise( IDataObject
			// *pDataObject, FORMATETC *pFetc, DWORD advf, IAdviseSink *pAdvise, DWORD *pdwConnection );
			[PreserveSig]
			HRESULT Advise([Optional] IDataObject pDataObject, in FORMATETC pFetc, ADVF advf, IAdviseSink pAdvise, out uint pdwConnection);

			/// <summary>
			/// Removes a connection between a data object and an advisory sink that was set up through a previous call to
			/// IDataAdviseHolder::Advise. This method is typically called in the implementation of IDataObject::DUnadvise.
			/// </summary>
			/// <param name="dwConnection">
			/// A token that specifies the connection to be removed. This value was returned by IDataAdviseHolder::Advise when the
			/// connection was originally established.
			/// </param>
			/// <returns>
			/// <para>This method returns S_OK on success. Other possible values include the following.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>OLE_E_NOCONNECTION</term>
			/// <term>The dwConnection parameter does not specify a valid connection.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-idataadviseholder-unadvise HRESULT Unadvise( DWORD
			// dwConnection );
			[PreserveSig]
			HRESULT Unadvise(uint dwConnection);

			/// <summary>Returns an object that can be used to enumerate the current advisory connections.</summary>
			/// <param name="ppenumAdvise">
			/// A pointer to an IEnumSTATDATA pointer variable that receives the interface pointer to the new enumerator object. If the
			/// implementation returns NULL in *ppenumAdvise, there are no connections to advise sinks at this time.
			/// </param>
			/// <returns>This method returns S_OK if the enumerator object is successfully instantiated or there are no connections.</returns>
			/// <remarks>
			/// <para>
			/// This method must supply a pointer to an implementation of the IEnumSTATDATA interface. Its methods allow you to enumerate
			/// the data stored in an array of STATDATA structures. You get a pointer to the OLE implementation of IDataAdviseHolder through
			/// a call to CreateDataAdviseHolder, and then call <c>IDataAdviseHolder::EnumAdvise</c> to implement IDataObject::EnumDAdvise.
			/// </para>
			/// <para>
			/// Adding more advisory connections while the enumerator object is active has an undefined effect on the enumeration that
			/// results from this method.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/zh-cn/windows/win32/api/objidl/nf-objidl-idataadviseholder-enumadvise HRESULT EnumAdvise(
			// IEnumSTATDATA **ppenumAdvise );
			[PreserveSig]
			HRESULT EnumAdvise(out IEnumSTATDATA ppenumAdvise);

			/// <summary>
			/// Sends notifications to each advise sink for which there is a connection established by calling the IAdviseSink::OnDataChange
			/// method for each advise sink currently being handled by this instance of the advise holder object.
			/// </summary>
			/// <param name="pDataObject">
			/// A pointer to the IDataObject interface on the data object in which the data has just changed. This pointer is used in
			/// subsequent calls to IAdviseSink::OnDataChange.
			/// </param>
			/// <param name="dwReserved">This parameter is reserved and must be 0.</param>
			/// <param name="advf">
			/// Container for advise flags that specify how the call to IAdviseSink::OnDataChange is made. These flag values are from the
			/// enumeration ADVF. Typically, the value for advf is <c>NULL</c>. The only exception occurs when the data object is shutting
			/// down and must send a final notification that includes the actual data to sinks that have specified ADVF_DATAONSTOP and
			/// ADVF_NODATA in their call to IDataObject::DAdvise. In this case, advf contains ADVF_DATAONSTOP.
			/// </param>
			/// <returns>This method returns S_OK on success.</returns>
			/// <remarks>
			/// <para>
			/// The data object must call this method when it detects a change that would be of interest to an advise sink that has
			/// previously requested notification.
			/// </para>
			/// <para>
			/// Most notifications include the actual data with them. The only exception is if the ADVF_NODATA flag was previously specified
			/// when the connection was initially set up in the IDataAdviseHolder::Advise method.
			/// </para>
			/// <para>
			/// Before calling the IAdviseSink::OnDataChange method for each advise sink, this method obtains the actual data by calling the
			/// IDataObject::GetData method through the pointer specified in the pDataObject parameter.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-idataadviseholder-sendondatachange HRESULT
			// SendOnDataChange( IDataObject *pDataObject, DWORD dwReserved, DWORD advf );
			[PreserveSig]
			HRESULT SendOnDataChange(IDataObject pDataObject, [Optional] uint dwReserved, ADVF advf);
		}

		/// <summary>
		/// <para>
		/// Enables data transfer and notification of changes in data. Data transfer methods specify the format of the transferred data along
		/// with the medium through which the data is to be transferred. Optionally, the data can be rendered for a specific target device.
		/// In addition to methods for retrieving and storing data, the <c>IDataObject</c> interface specifies methods for enumerating
		/// available formats and managing connections to advisory sinks for handling change notifications.
		/// </para>
		/// <para>
		/// The term <c>data object</c> is used to mean any object that supports an implementation of the <c>IDataObject</c> interface.
		/// Implementations vary, depending on what the data object is required to do; in some data objects, the implementation of certain
		/// methods not supported by the object could simply be the return of E_NOTIMPL. For example, some data objects do not allow callers
		/// to send them data. Other data objects do not support advisory connections and change notifications. However, for those data
		/// objects that do support change notifications, OLE provides an object called a data advise holder. An interface pointer to this
		/// holder is available through a call to the helper function CreateDataAdviseHolder. A data object can have multiple connections,
		/// each with its own set of attributes. The OLE data advise holder simplifies the task of managing these connections and sending the
		/// appropriate notifications.
		/// </para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/objidl/nn-objidl-idataobject
		[PInvokeData("objidl.h", MSDNShortId = "NN:objidl.IDataObject")]
		[ComImport, Guid("0000010e-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IDataObjectV
		{
			/// <summary>
			/// Called by a data consumer to obtain data from a source data object. The <c>GetData</c> method renders the data described in
			/// the specified FORMATETC structure and transfers it through the specified STGMEDIUM structure. The caller then assumes
			/// responsibility for releasing the <c>STGMEDIUM</c> structure.
			/// </summary>
			/// <param name="pformatetcIn">
			/// A pointer to the FORMATETC structure that defines the format, medium, and target device to use when passing the data. It is
			/// possible to specify more than one medium by using the Boolean OR operator, allowing the method to choose the best medium
			/// among those specified.
			/// </param>
			/// <param name="pmedium">
			/// A pointer to the STGMEDIUM structure that indicates the storage medium containing the returned data through its tymed member,
			/// and the responsibility for releasing the medium through the value of its <c>pUnkForRelease</c> member. If
			/// <c>pUnkForRelease</c> is <c>NULL</c>, the receiver of the medium is responsible for releasing it; otherwise,
			/// <c>pUnkForRelease</c> points to the IUnknown on the appropriate object so its Release method can be called. The medium must
			/// be allocated and filled in by <c>GetData</c>.
			/// </param>
			/// <returns>
			/// <para>This method returns S_OK on success. Other possible values include the following.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term><c>DV_E_LINDEX</c></term>
			/// <term>The value for <c>lindex</c> is not valid; currently, only -1 is supported.</term>
			/// </item>
			/// <item>
			/// <term><c>DV_E_FORMATETC</c></term>
			/// <term>The value for <c>pformatetcIn</c> is not valid.</term>
			/// </item>
			/// <item>
			/// <term><c>DV_E_TYMED</c></term>
			/// <term>The <c>tymed</c> value is not valid.</term>
			/// </item>
			/// <item>
			/// <term><c>DV_E_DVASPECT</c></term>
			/// <term>The <c>dwAspect</c> value is not valid.</term>
			/// </item>
			/// <item>
			/// <term><c>OLE_E_NOTRUNNING</c></term>
			/// <term>The object application is not running.</term>
			/// </item>
			/// <item>
			/// <term><c>STG_E_MEDIUMFULL</c></term>
			/// <term>An error occurred when allocating the medium.</term>
			/// </item>
			/// <item>
			/// <term><c>E_UNEXPECTED</c></term>
			/// <term>An unexpected error has occurred.</term>
			/// </item>
			/// <item>
			/// <term><c>E_INVALIDARG</c></term>
			/// <term>The <c>dwDirection</c> value is not valid.</term>
			/// </item>
			/// <item>
			/// <term><c>E_OUTOFMEMORY</c></term>
			/// <term>There was insufficient memory available for this operation.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// A data consumer calls <c>GetData</c> to retrieve data from a data object, conveyed through a storage medium (defined through
			/// the STGMEDIUM structure).
			/// </para>
			/// <para>Notes to Callers</para>
			/// <para>
			/// You can specify more than one acceptable <c>tymed</c> medium with the Boolean OR operator. <c>GetData</c> must choose from
			/// the OR'd values the medium that best represents the data, do the allocation, and indicate responsibility for releasing the medium.
			/// </para>
			/// <para>
			/// Data transferred across a stream extends from position zero of the stream pointer through to the position immediately before
			/// the current stream pointer (that is, the stream pointer position upon exit).
			/// </para>
			/// <para>Notes to Implementers</para>
			/// <para>
			/// <c>GetData</c> must check all fields in the FORMATETC structure. It is important that <c>GetData</c> render the requested
			/// aspect and, if possible, use the requested medium. If the data object cannot comply with the information specified in the
			/// <c>FORMATETC</c>, the method should return DV_E_FORMATETC. If an attempt to allocate the medium fails, the method should
			/// return STG_E_MEDIUMFULL. It is important to fill in all of the fields in the STGMEDIUM structure.
			/// </para>
			/// <para>
			/// Although the caller can specify more than one medium for returning the data, <c>GetData</c> can provide only one medium. If
			/// the initial transfer fails with the selected medium, this method can be implemented to try one of the other media specified
			/// before returning an error.
			/// </para>
			/// </remarks>
			// https://learn.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-idataobject-getdata HRESULT GetData( [in] FORMATETC
			// *pformatetcIn, [out] STGMEDIUM *pmedium );
			[PreserveSig]
			HRESULT GetData(in FORMATETC pformatetcIn, out STGMEDIUM pmedium);

			/// <summary>
			/// Called by a data consumer to obtain data from a source data object. This method differs from the GetData method in that the
			/// caller must allocate and free the specified storage medium.
			/// </summary>
			/// <param name="pformatetc">
			/// A pointer to the FORMATETC structure that defines the format, medium, and target device to use when passing the data. Only
			/// one medium can be specified in <c>tymed</c>, and only the following values are valid: TYMED_ISTORAGE, TYMED_ISTREAM,
			/// TYMED_HGLOBAL, or TYMED_FILE.
			/// </param>
			/// <param name="pmedium">
			/// A pointer to the STGMEDIUM structure that defines the storage medium containing the data being transferred. The medium must
			/// be allocated by the caller and filled in by <c>GetDataHere</c>. The caller must also free the medium. The implementation of
			/// this method must always supply a value of <c>NULL</c> for the <c>punkForRelease</c> member of the <c>STGMEDIUM</c> structure
			/// to which this parameter points.
			/// </param>
			/// <returns>
			/// <para>This method returns S_OK on success. Other possible values include the following.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term><c>DV_E_LINDEX</c></term>
			/// <term>The value for <c>lindex</c> is not valid; currently, only -1 is supported.</term>
			/// </item>
			/// <item>
			/// <term><c>DV_E_FORMATETC</c></term>
			/// <term>The value for <c>pformatetc</c> is not valid.</term>
			/// </item>
			/// <item>
			/// <term><c>DV_E_TYMED</c></term>
			/// <term>The <c>tymed</c> value is not valid.</term>
			/// </item>
			/// <item>
			/// <term><c>DV_E_DVASPECT</c></term>
			/// <term>The <c>dwAspect</c> value is not valid.</term>
			/// </item>
			/// <item>
			/// <term><c>OLE_E_NOTRUNNING</c></term>
			/// <term>The object application is not running.</term>
			/// </item>
			/// <item>
			/// <term><c>STG_E_MEDIUMFULL</c></term>
			/// <term>An error occurred when allocating the medium.</term>
			/// </item>
			/// <item>
			/// <term><c>E_UNEXPECTED</c></term>
			/// <term>An unexpected error has occurred.</term>
			/// </item>
			/// <item>
			/// <term><c>E_INVALIDARG</c></term>
			/// <term>The <c>dwDirection</c> parameter is not valid.</term>
			/// </item>
			/// <item>
			/// <term><c>E_OUTOFMEMORY</c></term>
			/// <term>There was insufficient memory available for this operation.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// The <c>GetDataHere</c> method is similar to IDataObject::GetData, except that the caller must both allocate and free the
			/// medium specified in <c>pmedium</c>. <c>GetDataHere</c> renders the data described in a FORMATETC structure and copies the
			/// data into that caller-provided STGMEDIUM structure. For example, if the medium is TYMED_HGLOBAL, this method cannot resize
			/// the medium or allocate a new hGlobal.
			/// </para>
			/// <para>
			/// Some media are not appropriate in a call to <c>GetDataHere</c>, including GDI types such as metafiles. The <c>GetDataHere</c>
			/// method cannot put data into a caller-provided metafile. In general, the only storage media it is necessary to support in this
			/// method are TYMED_ISTORAGE, TYMED_ISTREAM, and TYMED_FILE.
			/// </para>
			/// <para>
			/// When the transfer medium is a stream, OLE makes assumptions about where the data is being returned and the position of the
			/// stream's seek pointer. In a GetData call, the data returned is from stream position zero through just before the current seek
			/// pointer of the stream (that is, the position on exit). For <c>GetDataHere</c>, the data returned is from the stream position
			/// on entry through just before the position on exit.
			/// </para>
			/// </remarks>
			// https://learn.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-idataobject-getdatahere HRESULT GetDataHere( [in]
			// FORMATETC *pformatetc, [in, out] STGMEDIUM *pmedium );
			[PreserveSig]
			HRESULT GetDataHere(in FORMATETC pformatetc, ref STGMEDIUM pmedium);

			/// <summary>
			/// Determines whether the data object is capable of rendering the data as specified. Objects attempting a paste or drop
			/// operation can call this method before calling IDataObject::GetData to get an indication of whether the operation may be successful.
			/// </summary>
			/// <param name="pformatetc">
			/// A pointer to the FORMATETC structure defining the format, medium, and target device to use for the query.
			/// </param>
			/// <returns>
			/// <para>This method returns S_OK on success. Other possible values include the following</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term><c>DV_E_LINDEX</c></term>
			/// <term>Invalid value for <c>lindex</c>; currently, only -1 is supported.</term>
			/// </item>
			/// <item>
			/// <term><c>DV_E_FORMATETC</c></term>
			/// <term>Invalid value for <c>pformatetc</c>.</term>
			/// </item>
			/// <item>
			/// <term><c>DV_E_TYMED</c></term>
			/// <term>The <c>tymed</c> value is not valid.</term>
			/// </item>
			/// <item>
			/// <term><c>DV_E_DVASPECT</c></term>
			/// <term>The <c>dwAspect</c> value is not valid.</term>
			/// </item>
			/// <item>
			/// <term><c>OLE_E_NOTRUNNING</c></term>
			/// <term>The object application is not running.</term>
			/// </item>
			/// <item>
			/// <term><c>E_UNEXPECTED</c></term>
			/// <term>An unexpected error has occurred.</term>
			/// </item>
			/// <item>
			/// <term><c>E_INVALIDARG</c></term>
			/// <term>The <c>dwDirection</c> value is not valid.</term>
			/// </item>
			/// <item>
			/// <term><c>E_OUTOFMEMORY</c></term>
			/// <term>There is insufficient memory available for this operation.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// The client of a data object calls <c>QueryGetData</c> to determine whether passing the specified FORMATETC structure to a
			/// subsequent call to IDataObject::GetData is likely to be successful. A successful return from this method does not necessarily
			/// ensure the success of the subsequent paste or drop operation.
			/// </remarks>
			// https://learn.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-idataobject-querygetdata HRESULT QueryGetData( [in]
			// FORMATETC *pformatetc );
			[PreserveSig]
			HRESULT QueryGetData(in FORMATETC pformatetc);

			/// <summary>
			/// Provides a potentially different but logically equivalent FORMATETC structure. You use this method to determine whether two
			/// different <c>FORMATETC</c> structures would return the same data, removing the need for duplicate rendering.
			/// </summary>
			/// <param name="pformatectIn">
			/// A pointer to the FORMATETC structure that defines the format, medium, and target device that the caller would like to use to
			/// retrieve data in a subsequent call such as IDataObject::GetData. The <c>tymed</c> member is not significant in this case and
			/// should be ignored.
			/// </param>
			/// <param name="pformatetcOut">
			/// A pointer to a FORMATETC structure that contains the most general information possible for a specific rendering, making it
			/// canonically equivalent to <c>pformatetcIn</c>. The caller must allocate this structure and the <c>GetCanonicalFormatEtc</c>
			/// method must fill in the data. To retrieve data in a subsequent call like IDataObject::GetData, the caller uses the specified
			/// value of <c>pformatetcOut</c>, unless the value specified is <c>NULL</c>. This value is <c>NULL</c> if the method returns
			/// DATA_S_SAMEFORMATETC. The <c>tymed</c> member is not significant in this case and should be ignored.
			/// </param>
			/// <returns>
			/// <para>This method can return the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term><c>S_OK</c></term>
			/// <term>The returned FORMATETC structure is different from the one that was passed.</term>
			/// </item>
			/// <item>
			/// <term><c>DATA_S_SAMEFORMATETC</c></term>
			/// <term>The FORMATETC structures are the same and <c>NULL</c> is returned in <c>pformatetcOut</c>.</term>
			/// </item>
			/// <item>
			/// <term><c>DV_E_LINDEX</c></term>
			/// <term>The value for <c>lindex</c> is not valid; currently, only -1 is supported.</term>
			/// </item>
			/// <item>
			/// <term><c>DV_E_FORMATETC</c></term>
			/// <term>The value for <c>pformatetc</c> is not valid.</term>
			/// </item>
			/// <item>
			/// <term><c>OLE_E_NOTRUNNING</c></term>
			/// <term>The object application is not running.</term>
			/// </item>
			/// <item>
			/// <term><c>E_UNEXPECTED</c></term>
			/// <term>An unexpected error has occurred.</term>
			/// </item>
			/// <item>
			/// <term><c>E_INVALIDARG</c></term>
			/// <term>The <c>dwDirection</c> parameter is not valid.</term>
			/// </item>
			/// <item>
			/// <term><c>E_OUTOFMEMORY</c></term>
			/// <term>There was insufficient memory available for this operation.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// If a data object can supply exactly the same data for more than one requested FORMATETC structure,
			/// <c>GetCanonicalFormatEtc</c> can supply a "canonical", or standard <c>FORMATETC</c> that gives the same rendering as a set of
			/// more complicated <c>FORMATETC</c> structures. For example, it is common for the data returned to be insensitive to the target
			/// device specified in any one of a set of otherwise similar <c>FORMATETC</c> structures.
			/// </para>
			/// <para>Notes to Callers</para>
			/// <para>
			/// A call to this method can determine whether two calls to IDataObject::GetData on a data object, specifying two different
			/// FORMATETC structures, would actually produce the same renderings, thus eliminating the need for the second call and improving
			/// performance. If the call to <c>GetCanonicalFormatEtc</c> results in a canonical format being written to the
			/// <c>pformatetcOut</c> parameter, the caller then uses that structure in a subsequent call to <c>IDataObject::GetData</c>.
			/// </para>
			/// <para>Notes to Implementers</para>
			/// <para>
			/// Conceptually, it is possible to think of FORMATETC structures in groups defined by a canonical <c>FORMATETC</c> that provides
			/// the same results as each of the group members. In constructing the canonical <c>FORMATETC</c>, you should make sure it
			/// contains the most general information possible that still produces a specific rendering.
			/// </para>
			/// <para>
			/// For data objects that never provide device-specific renderings, the simplest implementation of this method is to copy the
			/// input FORMATETC to the output <c>FORMATETC</c>, store a <c>NULL</c> in the <c>ptd</c> member of the output <c>FORMATETC</c>,
			/// and return DATA_S_SAMEFORMATETC.
			/// </para>
			/// </remarks>
			// https://learn.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-idataobject-getcanonicalformatetc HRESULT
			// GetCanonicalFormatEtc( [in] FORMATETC *pformatectIn, [out] FORMATETC *pformatetcOut );
			[PreserveSig]
			HRESULT GetCanonicalFormatEtc(in FORMATETC pformatectIn, out FORMATETC pformatetcOut);

			/// <summary>Called by an object containing a data source to transfer data to the object that implements this method.</summary>
			/// <param name="pformatetc">
			/// A pointer to the FORMATETC structure defining the format used by the data object when interpreting the data contained in the
			/// storage medium.
			/// </param>
			/// <param name="pmedium">A pointer to the STGMEDIUM structure defining the storage medium in which the data is being passed.</param>
			/// <param name="fRelease">
			/// If <c>TRUE</c>, the data object called, which implements <c>SetData</c>, owns the storage medium after the call returns. This
			/// means it must free the medium after it has been used by calling the ReleaseStgMedium function. If <c>FALSE</c>, the caller
			/// retains ownership of the storage medium and the data object called uses the storage medium for the duration of the call only.
			/// </param>
			/// <returns>
			/// <para>This method returns S_OK on success. Other possible values include the following.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term><c>DV_E_LINDEX</c></term>
			/// <term>Invalid value for <c>lindex</c>; currently, only -1 is supported.</term>
			/// </item>
			/// <item>
			/// <term><c>DV_E_FORMATETC</c></term>
			/// <term>The value for <c>pformatetc</c> is not valid.</term>
			/// </item>
			/// <item>
			/// <term><c>DV_E_TYMED</c></term>
			/// <term>The <c>tymed</c> value is not valid.</term>
			/// </item>
			/// <item>
			/// <term><c>DV_E_DVASPECT</c></term>
			/// <term>The <c>dwAspect</c> value is not valid.</term>
			/// </item>
			/// <item>
			/// <term><c>OLE_E_NOTRUNNING</c></term>
			/// <term>The object application is not running.</term>
			/// </item>
			/// <item>
			/// <term><c>E_FAIL</c></term>
			/// <term>The operation failed.</term>
			/// </item>
			/// <item>
			/// <term><c>E_UNEXPECTED</c></term>
			/// <term>An unexpected error has occurred.</term>
			/// </item>
			/// <item>
			/// <term><c>E_INVALIDARG</c></term>
			/// <term>The <c>dwDirection</c> value is not valid.</term>
			/// </item>
			/// <item>
			/// <term><c>E_OUTOFMEMORY</c></term>
			/// <term>There was insufficient memory available for this operation.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// <c>SetData</c> allows another object to attempt to send data to the implementing data object. A data object implements this
			/// method if it supports receiving data from another object. If it does not support this, it should be implemented to return E_NOTIMPL.
			/// </para>
			/// <para>
			/// The caller allocates the storage medium indicated by the <c>pmedium</c> parameter, in which the data is passed. The data
			/// object called does not take ownership of the data until it has successfully received it and no error code is returned. The
			/// value of the <c>fRelease</c> parameter indicates the ownership of the medium after the call returns. <c>FALSE</c> indicates
			/// the caller still owns the medium, and the data object only has the use of it during the call; <c>TRUE</c> indicates that the
			/// data object now owns it and must release it when it is no longer needed.
			/// </para>
			/// <para>
			/// The type of medium specified in the <c>pformatetc</c> and <c>pmedium</c> parameters must be the same. For example, one cannot
			/// be a global handle and the other a stream.
			/// </para>
			/// </remarks>
			// https://learn.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-idataobject-setdata HRESULT SetData( [in] FORMATETC
			// *pformatetc, [in] STGMEDIUM *pmedium, [in] BOOL fRelease );
			[PreserveSig]
			HRESULT SetData(in FORMATETC pformatetc, in STGMEDIUM pmedium, [MarshalAs(UnmanagedType.Bool)] bool fRelease);

			/// <summary>Creates an object to enumerate the formats supported by a data object.</summary>
			/// <param name="dwDirection">
			/// <para>The direction of the data. Possible values come from the DATADIR enumeration.</para>
			/// <para>
			/// The value DATADIR_GET enumerates the formats that can be passed in to a call to IDataObject::GetData. The value DATADIR_SET
			/// enumerates those formats that can be passed in to a call to IDataObject::SetData.
			/// </para>
			/// </param>
			/// <param name="ppenumFormatEtc">
			/// A pointer to an IEnumFORMATETC pointer variable that receives the interface pointer to the new enumerator object.
			/// </param>
			/// <returns>
			/// <para>This method returns S_OK on success. Other possible values include the following.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term><c>E_INVALIDARG</c></term>
			/// <term>The supplied <c>dwDirection</c> is invalid.</term>
			/// </item>
			/// <item>
			/// <term><c>E_OUTOFMEMORY</c></term>
			/// <term>Insufficient memory available for this operation.</term>
			/// </item>
			/// <item>
			/// <term><c>E_NOTIMPL</c></term>
			/// <term>The direction specified by <c>dwDirection</c> is not supported.</term>
			/// </item>
			/// <item>
			/// <term><c>OLE_S_USEREG</c></term>
			/// <term>Requests that OLE enumerate the formats from the registry.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// <c>EnumFormatEtc</c> creates an enumerator object that can be used to determine all of the ways the data object can describe
			/// data in a FORMATETC structure, and provides a pointer to its IEnumFORMATETC interface. This is one of the standard enumerator interfaces.
			/// </para>
			/// <para>Notes to Callers</para>
			/// <para>
			/// Having obtained the pointer, the caller can enumerate the FORMATETC structures by calling the enumeration methods of
			/// IEnumFORMATETC. Because the formats can change over time, there is no guarantee that an enumerated format is currently
			/// supported because the formats can change over time. Accordingly, applications should treat the enumeration as a hint of the
			/// format types that can be passed. The caller is responsible for calling Release when it is finished with the enumerator.
			/// </para>
			/// <para><c>EnumFormatEtc</c> is called when one of the following actions occurs:</para>
			/// <list type="bullet">
			/// <item>
			/// <term>
			/// An application calls OleSetClipboard. OLE must determine what data to place on the clipboard and whether it is necessary to
			/// put OLE 1 compatibility formats on the clipboard.
			/// </term>
			/// </item>
			/// <item>
			/// <term>Data is being pasted from the clipboard or dropped. An application uses the first acceptable format.</term>
			/// </item>
			/// <item>
			/// <term>
			/// The <c>Paste Special</c> dialog box is displayed. The target application builds the list of formats from the FORMATETC entries.
			/// </term>
			/// </item>
			/// </list>
			/// <para>Notes to Implementers</para>
			/// <para>
			/// Formats can be registered statically in the registry or dynamically during object initialization. If an object has an
			/// unchanging list of formats and these formats are registered in the registry, OLE provides an implementation of a FORMATETC
			/// enumeration object that can enumerate formats registered under a specific CLSID in the registry. A pointer to its
			/// IEnumFORMATETC interface is available through a call to the helper function OleRegEnumFormatEtc. In this situation,
			/// therefore, you can implement the <c>EnumFormatEtc</c> method simply with a call to this function.
			/// </para>
			/// <para>
			/// EXE applications can effectively do the same thing by implementing the method to return the value OLE_S_USEREG. This return
			/// value instructs the default object handler to call OleRegEnumFormatEtc. Object applications that are implemented as DLL
			/// object applications cannot return OLE_S_USEREG, so must call <c>OleRegEnumFormatEtc</c> directly.
			/// </para>
			/// <para>
			/// Private formats can be enumerated for OLE 1 objects, if they are registered with the RequestDataFormats or SetDataFormats
			/// keys in the registry. Also, private formats can be enumerated for OLE objects (all versions after OLE 1), if they are
			/// registered with the GetDataFormats or SetDataFormats keys.
			/// </para>
			/// <para>
			/// For OLE 1 objects whose servers do not have RequestDataFormats or SetDataFormats information registered in the registry, a
			/// call to <c>EnumFormatEtc</c> passing DATADIR_GET only enumerates the native and metafile formats, regardless of whether they
			/// support these formats or others. Calling <c>EnumFormatEtc</c> passing DATADIR_SET on such objects only enumerates native,
			/// regardless of whether the object supports being set with other formats.
			/// </para>
			/// <para>
			/// The FORMATETC structure returned by the enumeration usually indicates a <c>NULL</c> target device (ptd). This is appropriate
			/// because, unlike the other members of <c>FORMATETC</c>, the target device does not participate in the object's decision as to
			/// whether it can accept or provide the data in either a SetData or GetData call.
			/// </para>
			/// <para>
			/// The <c>tymed</c> member of FORMATETC often indicates that more than one kind of storage medium is acceptable. You should
			/// always mask and test for this by using a Boolean OR operator.
			/// </para>
			/// </remarks>
			// https://learn.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-idataobject-enumformatetc HRESULT EnumFormatEtc( [in]
			// DWORD dwDirection, [out] IEnumFORMATETC **ppenumFormatEtc );
			[PreserveSig]
			HRESULT EnumFormatEtc(DATADIR dwDirection, [MarshalAs(UnmanagedType.Interface)] out IEnumFORMATETC ppenumFormatEtc);

			/// <summary>
			/// Called by an object supporting an advise sink to create a connection between a data object and the advise sink. This enables
			/// the advise sink to be notified of changes in the data of the object.
			/// </summary>
			/// <param name="pformatetc">
			/// A pointer to a FORMATETC structure that defines the format, target device, aspect, and medium that will be used for future
			/// notifications. For example, one sink may want to know only when the bitmap representation of the data in the data object
			/// changes. Another sink may be interested in only the metafile format of the same object. Each advise sink is notified when the
			/// data of interest changes. This data is passed back to the advise sink when notification occurs.
			/// </param>
			/// <param name="advf">
			/// <para>
			/// A group of flags for controlling the advisory connection. Possible values are from the ADVF enumeration. However, only some
			/// of the possible <c>ADVF</c> values are relevant for this method. The following table briefly describes the relevant values.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>ADVF Value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>ADVF_NODATA</term>
			/// <term>
			/// Asks the data object to avoid sending data with the notifications. Typically data is sent. This flag is a way to override the
			/// default behavior. When ADVF_NODATA is used, the <c>tymed</c> member of the STGMEDIUM structure that is passed to OnDataChange
			/// will usually contain TYMED_NULL. The caller can then retrieve the data with a subsequent IDataObject::GetData call.
			/// </term>
			/// </item>
			/// <item>
			/// <term>ADVF_ONLYONCE</term>
			/// <term>
			/// Causes the advisory connection to be destroyed after the first change notification is sent. An implicit call to
			/// IDataObject::DUnadvise is made on behalf of the caller to remove the connection.
			/// </term>
			/// </item>
			/// <item>
			/// <term>ADVF_PRIMEFIRST</term>
			/// <term>
			/// Asks for an additional initial notification. The combination of ADVF_ONLYONCE and ADVF_PRIMEFIRST provides, in effect, an
			/// asynchronous IDataObject::GetData call.
			/// </term>
			/// </item>
			/// <item>
			/// <term>ADVF_DATAONSTOP</term>
			/// <term>
			/// When specified with ADVF_NODATA, this flag causes a last notification with the data included to to be sent before the data
			/// object is destroyed. If used without ADVF_NODATA, <c>DAdvise</c> can be implemented in one of the following ways: A change
			/// notification is sent only in the shutdown case. Data changes prior to shutdown do not cause a notification to be sent.
			/// </term>
			/// </item>
			/// </list>
			/// </param>
			/// <param name="pAdvSink">A pointer to the IAdviseSink interface on the advisory sink that will receive the change notification.</param>
			/// <param name="pdwConnection">
			/// A token that identifies this connection. You can use this token later to delete the advisory connection (by passing it to
			/// IDataObject::DUnadvise). If this value is 0, the connection was not established.
			/// </param>
			/// <returns>
			/// <para>This method returns S_OK on success. Other possible values include the following.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term><c>E_NOTIMPL</c></term>
			/// <term>This method is not implemented on the data object.</term>
			/// </item>
			/// <item>
			/// <term><c>DV_E_LINDEX</c></term>
			/// <term>The value for <c>lindex</c> is not valid; currently, only -1 is supported.</term>
			/// </item>
			/// <item>
			/// <term><c>DV_E_FORMATETC</c></term>
			/// <term>The value for <c>pformatetc</c> is not valid.</term>
			/// </item>
			/// <item>
			/// <term><c>OLE_E_ADVISENOTSUPPORTED</c></term>
			/// <term>The data object does not support change notification.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// <c>DAdvise</c> creates a change notification connection between a data object and the caller. The caller provides an advisory
			/// sink to which the notifications can be sent when the object's data changes.
			/// </para>
			/// <para>
			/// Objects used simply for data transfer typically do not support advisory notifications and return OLE_E_ADVISENOTSUPPORTED
			/// from <c>DAdvise</c>.
			/// </para>
			/// <para>Notes to Callers</para>
			/// <para>
			/// The object supporting the advise sink calls <c>DAdvise</c> to set up the connection, specifying the format, aspect, medium,
			/// and/or target device of interest in the FORMATETC structure passed in. If the data object does not support one or more of the
			/// requested attributes or the sending of notifications at all, it can refuse the connection by returning OLE_E_ADVISENOTSUPPORTED.
			/// </para>
			/// <para>
			/// Containers of linked objects can set up advisory connections directly with the bound link source or indirectly through the
			/// standard OLE link object that manages the connection. Connections set up with the bound link source are not automatically
			/// deleted. The container must explicitly call IDataObject::DUnadvise on the bound link source to delete an advisory connection.
			/// The OLE link object, manipulated through the IOleLink interface, is implemented in the default handler. Connections set up
			/// through the OLE link object are destroyed when the link object is deleted.
			/// </para>
			/// <para>
			/// The OLE default link object creates a "wildcard advise" with the link source so OLE can maintain the time of last change.
			/// This advise is specifically used to note the time that anything changed. OLE ignores all data formats that may have changed,
			/// noting only the time of last change. To allow wildcard advises, set the FORMATETC members as follows before calling <c>DAdvise</c>:
			/// </para>
			/// <para>The advise flags should also include ADVF_NODATA. Wildcard advises from OLE should always be accepted by applications.</para>
			/// <para>Notes to Implementers</para>
			/// <para>
			/// To simplify the implementation of <c>DAdvise</c> and the other notification methods in IDataObject (DUnadvise and
			/// EnumDAdvise) that supports notification, OLE provides an advise holder object that manages the registration and sending of
			/// notifications. To get a pointer to this object, call the helper function CreateDataAdviseHolder on the first invocation of
			/// <c>DAdvise</c>. This supplies a pointer to the object's IDataAdviseHolder interface. Then, delegate the call to the
			/// IDataAdviseHolder::Advise method in the data advise holder, which creates, and subsequently manages, the requested connection.
			/// </para>
			/// </remarks>
			// https://learn.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-idataobject-dadvise HRESULT DAdvise( [in] FORMATETC
			// *pformatetc, [in] DWORD advf, [in] IAdviseSink *pAdvSink, [out] DWORD *pdwConnection );
			[PreserveSig]
			HRESULT DAdvise(in FORMATETC pformatetc, ADVF advf, [In, Optional, MarshalAs(UnmanagedType.Interface)] IAdviseSink pAdvSink, out uint pdwConnection);

			/// <summary>Destroys a notification connection that had been previously set up.</summary>
			/// <param name="dwConnection">
			/// A token that specifies the connection to be removed. Use the value returned by IDataObject::DAdvise when the connection was
			/// originally established.
			/// </param>
			/// <returns>
			/// <para>This method returns S_OK on success. Other possible values include the following.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term><c>OLE_E_NOCONNECTION</c></term>
			/// <term>The specified value for <c>dwConnection</c> is not a valid connection.</term>
			/// </item>
			/// <item>
			/// <term><c>OLE_E_ADVISENOTSUPPORTED</c></term>
			/// <term>This IDataObject implementation does not support notification.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>This methods destroys a notification created with a call to the IDataObject::DAdvise method.</para>
			/// <para>
			/// If the advisory connection being deleted was initially set up by delegating the IDataObject::DAdvise call to
			/// IDataAdviseHolder::Advise, you must delegate this call to IDataAdviseHolder::Unadvise to delete it.
			/// </para>
			/// </remarks>
			// https://learn.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-idataobject-dunadvise HRESULT DUnadvise( [in] DWORD
			// dwConnection );
			[PreserveSig]
			HRESULT DUnadvise(uint dwConnection);

			/// <summary>Creates an object that can be used to enumerate the current advisory connections.</summary>
			/// <param name="ppenumAdvise">
			/// A pointer to an IEnumSTATDATA pointer variable that receives the interface pointer to the new enumerator object. If the
			/// implementation sets * <c>ppenumAdvise</c> to <c>NULL</c>, there are no connections to advise sinks at this time.
			/// </param>
			/// <returns>
			/// <para>
			/// This method returns S_OK if the enumerator object is successfully instantiated or there are no connections. Other possible
			/// values include the following.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term><c>E_OUTOFMEMORY</c></term>
			/// <term>Insufficient memory is available for the operation.</term>
			/// </item>
			/// <item>
			/// <term><c>OLE_E_ADVISENOTSUPPORTED</c></term>
			/// <term>Advisory notifications are not supported by this object.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// The enumerator object created by this method implements the IEnumSTATDATA interface. <c>IEnumSTATDATA</c> permits the
			/// enumeration of the data stored in an array of STATDATA structures. Each of these structures provides information on a single
			/// advisory connection, and includes FORMATETC and ADVF information, as well as the pointer to the advise sink and the token
			/// representing the connection.
			/// </para>
			/// <para>Notes to Callers</para>
			/// <para>
			/// It is recommended that you use the OLE data advise holder object to handle advisory connections. With the pointer obtained
			/// through a call to CreateDataAdviseHolder, implementing <c>IDataObject::EnumDAdvise</c> becomes a simple matter of delegating
			/// the call to IDataAdviseHolder::EnumAdvise. This creates the enumerator and supplies the pointer to the OLE implementation of
			/// IEnumSTATDATA. At that point, you can call its methods to enumerate the current advisory connections.
			/// </para>
			/// </remarks>
			// https://learn.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-idataobject-enumdadvise HRESULT EnumDAdvise( [out]
			// IEnumSTATDATA **ppenumAdvise );
			[PreserveSig]
			HRESULT EnumDAdvise([Optional, MarshalAs(UnmanagedType.Interface)] out IEnumSTATDATA ppenumAdvise);
		}

		/// <summary>
		/// The <c>IDirectWriterLock</c> interface enables a single writer to obtain exclusive write access to a root storage object opened
		/// in direct mode while allowing concurrent access by multiple readers. This single-writer, multiple-reader mode does not require
		/// the overhead of making a snapshot copy of the storage for the readers.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/Objidl/nn-objidl-idirectwriterlock
		[PInvokeData("objidl.h", MSDNShortId = "cff56e4f-b8c5-4d87-9289-f8f2212d7c42")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("0e6d4d92-6738-11cf-9608-00aa00680db4")]
		public interface IDirectWriterLock
		{
			/// <summary>The <c>WaitForWriteAccess</c> method obtains exclusive write access to a storage object.</summary>
			/// <param name="dwTimeout">
			/// Specifies the time in milliseconds that this method blocks while waiting to obtain exclusive write access to the storage
			/// object. If dwTimeout is zero, the method does not block waiting for exclusive access for writing. The INFINITE time-out
			/// defined in the Platform SDK is allowed for dwTimeout.
			/// </param>
			/// <returns>
			/// This method can return one of these values.
			/// <list type="bullet">
			/// <item>
			/// <term>S_OK</term>
			/// <description>The caller has successfully obtained exclusive write access to the storage.</description>
			/// </item>
			/// <item>
			/// <term>S_FALSE</term>
			/// <description>This method was called again without an intervening call to IDirectWriterLock::ReleaseWriteAccess.</description>
			/// </item>
			/// <item>
			/// <term>STG_E_INUSE</term>
			/// <description>The specified time-out expired without obtaining exclusive write access.</description>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// When a storage is opened in direct mode (STGM_DIRECT) with the STGM_READWRITE|STGM_SHARE_DENY_WRITE, you can call this
			/// method to obtain exclusive write access to the storage.
			/// </para>
			/// <para>
			/// This method returns immediately if no readers have the storage open. If the storage is still open for reading, this method
			/// blocks for the specified dwTimeout or until the current readers close the storage.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-idirectwriterlock-waitforwriteaccess HRESULT
			// WaitForWriteAccess( DWORD dwTimeout );
			[PInvokeData("objidl.h", MSDNShortId = "e4505bed-325b-494e-93bd-7bf23b3a1215")]
			[PreserveSig]
			HRESULT WaitForWriteAccess(uint dwTimeout);

			/// <summary>The <c>ReleaseWriteAccess</c> method releases the write lock previously obtained.</summary>
			/// <remarks>
			/// <para>The writer calls this method to release exclusive access to the storage object previously taken by calling IDirectWriterLock::WaitForWriteAccess.</para>
			/// <para>
			/// After the writer calls this method, it is safe to allow readers to reopen the storage again until the next call to IDirectWriterLock::WaitForWriteAccess.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-idirectwriterlock-releasewriteaccess HRESULT
			// ReleaseWriteAccess( );
			[PInvokeData("objidl.h", MSDNShortId = "849eeb79-60fd-4345-9e04-2ed7a7ede5ca")]
			void ReleaseWriteAccess();

			/// <summary>The <c>HaveWriteAccess</c> method indicates whether the write lock has been taken.</summary>
			/// <returns>
			/// This method can return one of these values.
			/// <list type="bullet">
			/// <item>
			/// <term>S_OK</term>
			/// <description>The storage object is currently locked for write access.</description>
			/// </item>
			/// <item>
			/// <term>S_FALSE</term>
			/// <description>The storage object is not currently locked for write access.</description>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-idirectwriterlock-havewriteaccess HRESULT
			// HaveWriteAccess( );
			[PInvokeData("objidl.h", MSDNShortId = "8366b6b5-73c3-4b05-be68-c24ecd2eab96")]
			[PreserveSig]
			HRESULT HaveWriteAccess();
		}

		/// <summary>
		/// The IEnumSTATSTG interface enumerates an array of STATSTG structures. These structures contain statistical data about open
		/// storage, stream, or byte array objects.
		/// </summary>
		[ComImport, Guid("0000000D-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		[PInvokeData("Objidl.h", MSDNShortId = "aa379217")]
		public interface IEnumSTATSTG : Vanara.Collections.ICOMEnum<STATSTG>
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
			/// specified in the celt parameter. S_FALSE = The number of STATSTG structures returned is less than the number specified in
			/// the celt parameter.
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
		/// Enumerates objects with the IUnknown interface. It can be used to enumerate through the objects in a component containing
		/// multiple objects.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nn-objidl-ienumunknown
		[PInvokeData("objidl.h", MSDNShortId = "5aaed96f-39c1-4201-80d0-a2a8a177b65e")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("00000100-0000-0000-C000-000000000046")]
		public interface IEnumUnknown : Vanara.Collections.ICOMEnum<IntPtr>
		{
			/// <summary>Retrieves the specified number of items in the enumeration sequence.</summary>
			/// <param name="celt">
			/// The number of items to be retrieved. If there are fewer than the requested number of items left in the sequence, this method
			/// retrieves the remaining elements.
			/// </param>
			/// <param name="rgelt">
			/// <para>An array of enumerated items.</para>
			/// <para>
			/// The enumerator is responsible for calling AddRef, and the caller is responsible for calling Release through each pointer
			/// enumerated. If celt is greater than 1, the caller must also pass a non-NULL pointer passed to pceltFetched to know how many
			/// pointers to release.
			/// </para>
			/// </param>
			/// <param name="pceltFetched">
			/// The number of items that were retrieved. This parameter is always less than or equal to the number of items requested.
			/// </param>
			/// <returns>If the method retrieves the number of items requested, the return value is S_OK. Otherwise, it is S_FALSE.</returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ienumunknown-next HRESULT Next( ULONG celt, IUnknown
			// **rgelt, ULONG *pceltFetched );
			[PreserveSig]
			HRESULT Next(uint celt, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] IntPtr[] rgelt, out uint pceltFetched);

			/// <summary>Skips over the specified number of items in the enumeration sequence.</summary>
			/// <param name="celt">The number of items to be skipped.</param>
			/// <returns>If the method skips the number of items requested, the return value is S_OK. Otherwise, it is S_FALSE.</returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ienumunknown-skip HRESULT Skip( ULONG celt );
			[PreserveSig]
			HRESULT Skip(uint celt);

			/// <summary>Resets the enumeration sequence to the beginning.</summary>
			/// <remarks>
			/// There is no guarantee that the same set of objects will be enumerated after the reset operation has completed. A static
			/// collection is reset to the beginning, but it can be too expensive for some collections, such as files in a directory, to
			/// guarantee this condition.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ienumunknown-reset HRESULT Reset( );
			void Reset();

			/// <summary>
			/// <para>Creates a new enumerator that contains the same enumeration state as the current one.</para>
			/// <para>
			/// This method makes it possible to record a point in the enumeration sequence in order to return to that point at a later
			/// time. The caller must release this new enumerator separately from the first enumerator.
			/// </para>
			/// </summary>
			/// <returns>A pointer to the cloned enumerator object.</returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ienumunknown-clone HRESULT Clone( IEnumUnknown **ppenum );
			IEnumUnknown Clone();
		}

		/// <summary>
		/// The <c>IFillLockBytes</c> interface enables downloading code to write data asynchronously to a structured storage byte array.
		/// When the downloading code has new data available, it calls IFillLockBytes::FillAppend or IFillLockBytes::FillAt to write the
		/// data to the byte array. An application attempting to access this data, through calls to the ILockBytes interface, can do so even
		/// as the downloader continues to make calls to <c>IFillLockBytes</c>. If the application attempts to access data that has not
		/// already been downloaded through a call to <c>IFillLockBytes</c>, then <c>ILockBytes</c> returns a new error, E_PENDING.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/Objidl/nn-objidl-ifilllockbytes
		[PInvokeData("objidl.h", MSDNShortId = "99caf010-415e-11cf-8814-00aa00b569f5")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("0e6d4d92-6738-11cf-9608-00aa00680db4")]
		public interface IFillLockBytes
		{
			/// <summary>The <c>FillAppend</c> method writes a new block of bytes to the end of a byte array.</summary>
			/// <param name="pv">
			/// Pointer to the data to be appended to the end of an existing byte array. This operation does not create a danger of a memory
			/// leak or a buffer overrun.
			/// </param>
			/// <param name="cb">Size of pv in bytes.</param>
			/// <param name="pcbWritten">Number of bytes that were successfully written.</param>
			/// <remarks>
			/// The <c>FillAppend</c> method is used for sequential downloading, where bytes are written to the end of the byte array in the
			/// order in which they are received. This method obtains the current size of the byte array (for example, lockbytes object) and
			/// writes a new block of data to the end of the array. As each block of data becomes available, the downloader calls this
			/// method to write it to the byte array. Subsequent calls by the compound file implementation to ILockBytes::ReadAt return any
			/// available data or return E_PENDING if data is currently unavailable.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ifilllockbytes-fillappend HRESULT FillAppend( const void
			// *pv, ULONG cb, ULONG *pcbWritten );
			[PInvokeData("objidl.h", MSDNShortId = "3f25c48f-85a4-4778-b262-ad0c52cb1ac9")]
			void FillAppend([In] IntPtr pv, uint cb, out uint pcbWritten);

			/// <summary>The <c>FillAt</c> method writes a new block of data to a specified location in the byte array.</summary>
			/// <param name="ulOffset">The offset, expressed in number of bytes, from the first element of the byte array.</param>
			/// <param name="pv">Pointer to the data to be written at the location specified by uIOffset.</param>
			/// <param name="cb">Size of pv in bytes.</param>
			/// <param name="pcbWritten">Number of bytes that were successfully written.</param>
			/// <remarks>
			/// <para>
			/// The <c>FillAt</c> method is used for nonsequential downloading (for example, HTTP byte range requests). In nonsequential
			/// downloading the caller specifies ranges in the byte array where various blocks of data are to be written. Subsequent calls
			/// by the compound file implementation to ILockBytes::ReadAt are passed by the byte array wrapper object's own implementation
			/// of ILockBytes to the underlying byte array. This method is not currently implemented and will return E_NOTIMPL.
			/// </para>
			/// <para><c>Note</c> The system-supplied IFillLockBytes implementation does not support <c>FillAt</c> and returns E_NOTIMPL.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ifilllockbytes-fillat HRESULT FillAt( ULARGE_INTEGER
			// ulOffset, const void *pv, ULONG cb, ULONG *pcbWritten );
			[PInvokeData("objidl.h", MSDNShortId = "d378d87b-e081-4950-b87b-9b1ad6dfb29d")]
			void FillAt(ulong ulOffset, [In] IntPtr pv, uint cb, out uint pcbWritten);

			/// <summary>The <c>SetFillSize</c> method sets the expected size of the byte array.</summary>
			/// <param name="ulSize">Size in bytes of the byte array object that is to be filled in subsequent calls to IFillLockBytes::FillAppend.</param>
			/// <remarks>
			/// If <c>SetFillSize</c> has not been called, any call to ILockBytes::ReadAt that attempts to access data that has not yet been
			/// written using IFillLockBytes::FillAppend or IFillLockBytes::FillAt will return a new error message, E_PENDING. After
			/// <c>SetFillSize</c> has been called, any call to <c>ReadAt</c> that attempts to access data beyond the current size, as set
			/// by <c>SetFillSize</c>, returns E_FAIL instead of E_PENDING.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ifilllockbytes-setfillsize HRESULT SetFillSize(
			// ULARGE_INTEGER ulSize );
			[PInvokeData("objidl.h", MSDNShortId = "1336079e-02d2-4799-a58f-d097ec80c03b")]
			void SetFillSize(ulong ulSize);

			/// <summary>
			/// The <c>Terminate</c> method informs the byte array that the download has been terminated, either successfully or unsuccessfully.
			/// </summary>
			/// <param name="bCanceled">
			/// Download is complete. If <c>TRUE</c>, the download was terminated unsuccessfully. If <c>FALSE</c>, the download terminated successfully.
			/// </param>
			/// <remarks>After this method has been called, the byte array will no longer return E_PENDING.</remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ifilllockbytes-terminate HRESULT Terminate( BOOL
			// bCanceled );
			[PInvokeData("objidl.h", MSDNShortId = "21ea78c7-51f1-4418-915c-79db47c25715")]
			void Terminate([MarshalAs(UnmanagedType.Bool)] bool bCanceled);
		}

		/// <summary>Transfers the foreground window to the process hosting the COM server.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nn-objidl-iforegroundtransfer
		[PInvokeData("objidl.h", MSDNShortId = "NN:objidl.IForegroundTransfer")]
		[ComImport, Guid("00000145-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IForegroundTransfer
		{
			/// <summary>Yields the foreground window to the COM server process.</summary>
			/// <param name="lpvReserved">This parameter is reserved and must be <c>NULL</c>.</param>
			/// <returns>
			/// <para>This method can return the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method completed successfully.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>The lpvReserved parameter is not NULL, or this interface is on a proxy that does not support foreground control.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-iforegroundtransfer-allowforegroundtransfer HRESULT
			// AllowForegroundTransfer( void *lpvReserved );
			[PreserveSig]
			HRESULT AllowForegroundTransfer(IntPtr lpvReserved = default);
		}

		/// <summary>Performs initialization or cleanup when entering or exiting a COM apartment.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nn-objidl-iinitializespy
		[PInvokeData("objidl.h", MSDNShortId = "9cf1a3fa-dbc6-4760-a9e9-ef237737acfb")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("00000034-0000-0000-C000-000000000046")]
		public interface IInitializeSpy
		{
			/// <summary>Performs initialization steps required before calling the CoInitializeEx function.</summary>
			/// <param name="dwCoInit">The apartment type passed to CoInitializeEx, specified as a member of the COINIT enumeration.</param>
			/// <param name="dwCurThreadAptRefs">The number of times CoInitializeEx has been called on this thread.</param>
			/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-iinitializespy-preinitialize HRESULT PreInitialize( DWORD
			// dwCoInit, DWORD dwCurThreadAptRefs );
			[PreserveSig]
			HRESULT PreInitialize(COINIT dwCoInit, uint dwCurThreadAptRefs);

			/// <summary>Performs initialization steps required after calling the CoInitializeEx function.</summary>
			/// <param name="hrCoInit">The value returned by CoInitializeEx.</param>
			/// <param name="dwCoInit">The apartment type passed to CoInitializeEx, specified as a member of the COINIT enumeration.</param>
			/// <param name="dwNewThreadAptRefs">The number of times CoInitializeEx has been called on this thread.</param>
			/// <returns>
			/// This method returns the value that it intends the CoInitializeEx call to return to its caller. For more information, see the
			/// Remarks section.
			/// </returns>
			/// <remarks>
			/// <para>
			/// The return value from <c>PostInitialize</c> is intended to be the returned <c>HRESULT</c> from the call to CoInitializeEx.
			/// This is always the case for a single active registration on this thread.
			/// </para>
			/// <para>
			/// For cases where there are multiple registrations active on this thread, the returned <c>HRESULT</c> is arrived at by
			/// chaining of the various <c>PostInitialize</c> methods as follows: The COM determined <c>HRESULT</c> will be passed as the
			/// hrCoInit parameter to the first <c>PostInitialize</c> method called. The <c>HRESULT</c> from that <c>PostInitialize</c> call
			/// will be passed as the hrCoInit parameter to the next <c>PostInitialize</c> call. This chaining continues leading to the
			/// <c>HRESULT</c> from the last <c>PostInitialize</c> call being returned as the <c>HRESULT</c> from the call to CoInitializeEx.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-iinitializespy-postinitialize HRESULT PostInitialize(
			// HRESULT hrCoInit, DWORD dwCoInit, DWORD dwNewThreadAptRefs );
			[PreserveSig]
			HRESULT PostInitialize(HRESULT hrCoInit, COINIT dwCoInit, uint dwNewThreadAptRefs);

			/// <summary>Performs cleanup steps required before calling the CoUninitialize function.</summary>
			/// <param name="dwCurThreadAptRefs">The number of times CoInitializeEx has been called on this thread.</param>
			/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-iinitializespy-preuninitialize HRESULT PreUninitialize(
			// DWORD dwCurThreadAptRefs );
			[PreserveSig]
			HRESULT PreUninitialize(uint dwCurThreadAptRefs);

			/// <summary>Performs cleanup steps required after calling the CoUninitialize function.</summary>
			/// <param name="dwNewThreadAptRefs">The number of calls to CoUninitialize remaining on this thread.</param>
			/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-iinitializespy-postuninitialize HRESULT PostUninitialize(
			// DWORD dwNewThreadAptRefs );
			[PreserveSig]
			HRESULT PostUninitialize(uint dwNewThreadAptRefs);
		}

		/// <summary>
		/// <para>
		/// The <c>ILayoutStorage</c> interface enables an application to optimize the layout of its compound files for efficient
		/// downloading across a slow link. The goal is to enable a browser or other application to download data in the order in which it
		/// will actually be required.
		/// </para>
		/// <para>To optimize a compound file, an application calls CopyTo to layout a docfile, thus improving performance in most scenarios.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nn-objidl-ilayoutstorage
		[PInvokeData("objidl.h", MSDNShortId = "72201600-4bbb-4346-a13f-927e8463b6ec")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("0e6d4d90-6738-11cf-9608-00aa00680db4")]
		public interface ILayoutStorage
		{
			/// <summary>
			/// The <c>LayoutScript</c> method provides explicit directions for reordering the storages, streams, and controls in a compound
			/// file to match the order in which they are accessed during the download.
			/// </summary>
			/// <param name="pStorageLayout">Pointer to an array of StorageLayout structures.</param>
			/// <param name="nEntries">Number of entries in the array of StorageLayout structures.</param>
			/// <param name="glfInterleavedFlag">Reserved for future use.</param>
			/// <remarks>
			/// <para>
			/// To provide explicit layout instructions, the application calls <c>ILayoutStorage::LayoutScript</c>, passing an array of
			/// StorageLayout structures. Each structure defines a single storage or stream data block and specifies where the block is to
			/// be written in the ILockBytes byte array.
			/// </para>
			/// <para>An application can combine scripted layout with monitoring, as the structure of a particular compound file may dictate.</para>
			/// <para>
			/// When the optimal data-layout pattern of an entire compound file has been determined, the application calls
			/// ILayoutStorage::ReLayoutDocfile to restructure the compound file to match the order in which its data sectors were accessed.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ilayoutstorage-layoutscript HRESULT LayoutScript(
			// StorageLayout *pStorageLayout, DWORD nEntries, DWORD glfInterleavedFlag );
			[PInvokeData("objidl.h", MSDNShortId = "22ae3485-15d9-47e4-988e-fb760e67595b")]
			void LayoutScript([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] StorageLayout[] pStorageLayout, uint nEntries, uint glfInterleavedFlag = 0);

			/// <summary>
			/// The <c>BeginMonitor</c> method is used to begin monitoring when a loading operation is started. When the operation is
			/// complete, the application must call ILayoutStorage::EndMonitor.
			/// </summary>
			/// <remarks>
			/// <para>
			/// Normally an application calls <c>BeginMonitor</c> before the actual loading begins. Once this method has been called, the
			/// compound file implementation regards any operation performed on the files storages and streams as part of the desired access
			/// pattern. The result is a layout script like that created explicitly by calling ILayoutStorage::LayoutScript.
			/// </para>
			/// <para>
			/// Applications will usually use monitoring to obtain the access pattern of embedded objects. Monitoring also makes possible
			/// generic layout tools, that launch existing applications and monitor their access patterns.
			/// </para>
			/// <para>
			/// A call to ILayoutStorage::EndMonitor ends monitoring. Multiple calls to <c>BeginMonitor</c> and <c>EndMonitor</c> are
			/// permitted. Monitoring can also be mixed with calls to ILayoutStorage::LayoutScript.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ilayoutstorage-beginmonitor HRESULT BeginMonitor( );
			[PInvokeData("objidl.h", MSDNShortId = "16371d6c-adb9-43c2-80a4-377e94854bbb")]
			void BeginMonitor();

			/// <summary>The <c>EndMonitor</c> method ends monitoring of a compound file. Must be preceded by a call to ILayoutStorage::BeginMonitor.</summary>
			/// <remarks>
			/// A call to <c>EndMonitor</c> is generally followed by a call to ILayoutStorage::RelayoutDocfile, which uses the access
			/// pattern detected by the monitoring to restructure the compound file.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ilayoutstorage-endmonitor HRESULT EndMonitor( );
			[PInvokeData("objidl.h", MSDNShortId = "83b9486b-78b6-473c-9a9a-33f470a4d70f")]
			void EndMonitor();

			/// <summary>
			/// The <c>ReLayoutDocfile</c> method rewrites the compound file, using the layout script obtained through monitoring, or
			/// provided through explicit layout scripting, to create a new compound file.
			/// </summary>
			/// <param name="pwcsNewDfName">
			/// Pointer to the name of the compound file to be rewritten. This name must be a valid filename, distinct from the name of the
			/// original compound file. The original compound file will be optimized and written to the new pwcsNewDfName.
			/// </param>
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ilayoutstorage-relayoutdocfile HRESULT ReLayoutDocfile(
			// OLECHAR *pwcsNewDfName );
			[PInvokeData("objidl.h", MSDNShortId = "5db3a26c-595a-4c9b-bb6d-b170eb9864df")]
			void ReLayoutDocfile(string pwcsNewDfName);

			/// <summary>
			/// <para>Not supported.</para>
			/// <para>The <c>ReLayoutDocfileOnILockBytes</c> method is not implemented. If called, it returns <c>STG_E_UNIMPLEMENTEDFUNCTION</c>.</para>
			/// </summary>
			/// <param name="pILockBytes">
			/// A pointer to the ILockBytes interface on the underlying byte-array object where the compound file is to be rewritten.
			/// </param>
			/// <remarks>
			/// If implemented, it would rewrite the compound file in the byte-array object specified by the caller. It would return
			/// <c>S_OK</c> for success or one of the <c>STG_E_*</c> error codes for failure.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ilayoutstorage-relayoutdocfileonilockbytes HRESULT
			// ReLayoutDocfileOnILockBytes( ILockBytes *pILockBytes );
			[PInvokeData("objidl.h", MSDNShortId = "4d62ea35-d9cb-4ec6-ad71-7b32096953f1")]
			[Obsolete("Not implemented.")]
			void ReLayoutDocfileOnILockBytes([In] ILockBytes pILockBytes);
		}
	}
}