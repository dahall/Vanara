using System;
using System.Runtime.InteropServices;
using System.Security;
using Vanara.InteropServices;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedParameter.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable FieldCanBeMadeReadOnly.Global
// ReSharper disable InconsistentNaming
// ReSharper disable MemberHidesStaticFromOuterClass
// ReSharper disable UnusedMethodReturnValue.Global

namespace Vanara.PInvoke
{
	public static partial class Shell32
	{
		/// <summary>Exposes methods that enable clients to access items in a collection of objects that support IUnknown.</summary>
		[SuppressUnmanagedCodeSecurity]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("92CA9DCD-5622-4bba-A805-5E9F541BD8C9")]
		[PInvokeData("Shobjidl.h", MSDNShortId = "dd378311")]
		public interface IObjectArray
		{
			/// <summary>Provides a count of the objects in the collection.</summary>
			/// <returns>The number of objects in the collection.</returns>
			uint GetCount();

			/// <summary>
			/// Provides a pointer to a specified object's interface. The object and interface are specified by index and interface ID.
			/// </summary>
			/// <param name="uiIndex">The index of the object</param>
			/// <param name="riid">Reference to the desired interface ID.</param>
			/// <returns>Receives the interface pointer requested in riid.</returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			object GetAt([In] uint uiIndex, [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid);
		}

		/// <summary>
		/// Extends the IObjectArray interface by providing methods that enable clients to add and remove objects that support IUnknown in a collection.
		/// </summary>
		[SuppressUnmanagedCodeSecurity]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("5632b1a4-e38a-400a-928a-d4cd63230295"), CoClass(typeof(CEnumerableObjectCollection))]
		[PInvokeData("Shobjidl.h", MSDNShortId = "dd378307")]
		public interface IObjectCollection
		{
			/// <summary>Provides a count of the objects in the collection.</summary>
			/// <returns>The number of objects in the collection.</returns>
			uint GetCount();

			/// <summary>
			/// Provides a pointer to a specified object's interface. The object and interface are specified by index and interface ID.
			/// </summary>
			/// <param name="uiIndex">The index of the object</param>
			/// <param name="riid">Reference to the desired interface ID.</param>
			/// <returns>Receives the interface pointer requested in riid.</returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			object GetAt([In] uint uiIndex, [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid);

			/// <summary>Adds a single object to the collection.</summary>
			/// <param name="punk">Pointer to the IUnknown of the object to be added to the collection.</param>
			void AddObject([In, MarshalAs(UnmanagedType.Interface)] object punk);

			/// <summary>Adds the objects contained in an IObjectArray to the collection.</summary>
			/// <param name="poaSource">Pointer to the IObjectArray whose contents are to be added to the collection.</param>
			void AddFromArray(IObjectArray poaSource);

			/// <summary>Removes a single, specified object from the collection.</summary>
			/// <param name="uiIndex">A pointer to the index of the object within the collection.</param>
			void RemoveObjectAt(uint uiIndex);

			/// <summary>Removes all objects from the collection.</summary>
			void Clear();
		}

		/// <summary>
		/// Exposes methods that allow implementers of a custom IAssocHandler object to provide access to its explicit Application User Model
		/// ID (AppUserModelID). This information is used to determine whether a particular file type can be added to an application's Jump List.
		/// </summary>
		[SuppressUnmanagedCodeSecurity]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("36db0196-9665-46d1-9ba7-d3709eecf9ed")]
		[PInvokeData("Shobjidl.h", MSDNShortId = "dd378302")]
		public interface IObjectWithAppUserModelId
		{
			/// <summary>Sets the application identifier.</summary>
			/// <param name="pszAppID">The PSZ application identifier.</param>
			void SetAppID([MarshalAs(UnmanagedType.LPWStr)] string pszAppID);

			/// <summary>Retrieves a file type handler's explicit Application User Model ID (AppUserModelID), if one has been declared.</summary>
			/// <returns></returns>
			SafeCoTaskMemString GetAppID();
		}

		/// <summary>Exposes methods that provide access to the ProgID associated with an object.</summary>
		[SuppressUnmanagedCodeSecurity]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("71e806fb-8dee-46fc-bf8c-7748a8a1ae13")]
		[PInvokeData("Shobjidl.h", MSDNShortId = "dd378294")]
		public interface IObjectWithProgId
		{
			/// <summary>Sets the ProgID of an object.</summary>
			/// <param name="pszProgID">A pointer to a string that contains the new ProgID.</param>
			void SetProgID([MarshalAs(UnmanagedType.LPWStr)] string pszProgID);

			/// <summary>Retrieves the ProgID associated with an object.</summary>
			/// <returns>A pointer to a string that, when this method returns successfully, contains the ProgID.</returns>
			SafeCoTaskMemString GetProgID();
		}

		/// <summary>
		/// Provides a simple way to support communication between an object and its site in the container.
		/// <para>
		/// Often an object needs to communicate directly with a container site object and, in effect, manage the site object itself.Outside
		/// of IOleObject::SetClientSite, there is no generic means through which an object becomes aware of its site. IObjectWithSite
		/// provides simple objects with a simple siting mechanism (lighter than IOleObject) This interface should only be used when
		/// IOleObject is not already in use.
		/// </para>
		/// <para>
		/// Through IObjectWithSite, a container can pass the IUnknown pointer of its site to the object through
		/// IObjectWithSite::SetSite.Callers can also retrieve the latest site passed to SetSite through IObjectWithSite::GetSite.This latter
		/// method is included as a hooking mechanism, allowing a third party to intercept calls from the object to the site.
		/// </para>
		/// </summary>
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("fc4801a3-2ba9-11cf-a229-00aa003d7352")]
		[PInvokeData("ocidl.h")]
		public interface IObjectWithSite
		{
			/// <summary>Enables a container to pass an object a pointer to the interface for its site.</summary>
			/// <param name="pUnkSite">
			/// A pointer to the IUnknown interface pointer of the site managing this object. If NULL, the object should call Release on any
			/// existing site at which point the object no longer knows its site.
			/// </param>
			void SetSite([In, MarshalAs(UnmanagedType.IUnknown)] object pUnkSite);

			/// <summary>Retrieves the latest site passed using SetSite.</summary>
			/// <param name="riid">The IID of the interface pointer that should be returned in ppvSite.</param>
			/// <returns>
			/// Address of pointer variable that receives the interface pointer requested in riid. Upon successful return, *ppvSite contains
			/// the requested interface pointer to the site last seen in SetSite. The specific interface returned depends on the riid
			/// argument in essence, the two arguments act identically to those in QueryInterface. If the appropriate interface pointer is
			/// available, the object must call AddRef on that pointer before returning successfully. If no site is available, or the
			/// requested interface is not supported, this method must *ppvSite to NULL and return a failure code.
			/// </returns>
			[return: MarshalAs(UnmanagedType.IUnknown)]
			object GetSite([In, MarshalAs(UnmanagedType.LPStruct)] Guid riid);
		}
	}
}