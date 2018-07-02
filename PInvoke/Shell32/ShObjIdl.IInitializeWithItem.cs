using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Shell32
	{
		/// <summary>Exposes a method used to initialize a handler, such as a property handler, thumbnail handler, or preview handler, with an IShellItem.</summary>
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("7f73be3f-fb79-493c-a6c7-7ee14e245841")]
		public interface IInitializeWithItem
		{
			/// <summary>Initializes a handler with an IShellItem.</summary>
			/// <param name="psi">A pointer to an IShellItem.</param>
			/// <param name="grfMode">One of the following STGM values that indicate the access mode for psi..</param>
			void Initialize(IShellItem psi, STGM grfMode);
		}
	}
}