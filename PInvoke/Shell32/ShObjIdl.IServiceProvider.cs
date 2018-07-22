using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Shell32
	{
		/// <summary>Defines a mechanism for retrieving a service object; that is, an object that provides custom support to other objects.</summary>
		[ComImport, Guid("6d5140c1-7436-11ce-8034-00aa006009fa"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		[PInvokeData("servprov.h")]
		public interface IServiceProvider
		{
			/// <summary>Performs as a factory for services that are exposed through an implementation of IServiceProvider.</summary>
			/// <param name="guidService">A unique identifier of the requested service.</param>
			/// <param name="riid">A unique identifier of the interface which the caller wishes to receive for the service.</param>
			/// <returns>The interface specified by the riid parameter.</returns>
			[return: MarshalAs(UnmanagedType.IUnknown)]
			object QueryService([In, MarshalAs(UnmanagedType.LPStruct)] Guid guidService, [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid);
		};
	}
}