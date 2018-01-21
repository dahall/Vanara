using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace Vanara.PInvoke
{
	public static partial class Ole32
	{
		/// <summary>
		/// The IOleWindow interface provides methods that allow an application to obtain the handle to the various windows that participate in in-place
		/// activation, and also to enter and exit context-sensitive help mode.
		/// </summary>
		[ComImport, Guid("00000114-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IOleWindow
		{
			/// <summary>Retrieves a handle to one of the windows participating in in-place activation (frame, document, parent, or in-place object window).</summary>
			/// <returns>A pointer to a variable that receives the window handle.</returns>
			IntPtr GetWindow();
			/// <summary>
			/// Determines whether context-sensitive help mode should be entered during an in-place activation session.
			/// </summary>
			/// <param name="fEnterMode"><c>true</c> if help mode should be entered; <c>false</c> if it should be exited.</param>
			void ContextSensitiveHelp([MarshalAs(UnmanagedType.Bool)] bool fEnterMode);
		}
	}
}