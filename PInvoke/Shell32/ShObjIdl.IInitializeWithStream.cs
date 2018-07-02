using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace Vanara.PInvoke
{
	public static partial class Shell32
	{
		/// <summary>Exposes a method that initializes a handler, such as a property handler, thumbnail handler, or preview handler, with a stream.</summary>
		[ComImport, Guid("b824b49d-22ac-4161-ac8a-9916e8fa3f7f"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IInitializeWithStream
		{
			/// <summary>Initializes a handler with a stream.</summary>
			/// <param name="pstream">A pointer to an IStream interface that represents the stream source.</param>
			/// <param name="grfMode">One of the following STGM values that indicates the access mode for pstream.</param>
			void Initialize([In] IStream pstream, STGM grfMode);
		}
	}
}