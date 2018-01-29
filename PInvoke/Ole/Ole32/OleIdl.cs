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
		[PInvokeData("Oleidl.h")]
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

		/// <summary>
		/// Indicates the number of menu items in each of the six menu groups of a menu shared between a container and an object server during an in-place
		/// editing session. This is the mechanism for building a shared menu.
		/// </summary>
		[PInvokeData("Oleidl.h", MSDNShortId = "ms693766")]
		[StructLayout(LayoutKind.Sequential)]
		public struct OLEMENUGROUPWIDTHS
		{
			/// <summary>
			/// An array whose elements contain the number of menu items in each of the six menu groups of a shared in-place editing menu. Each menu group can
			/// have any number of menu items. The container uses elements 0, 2, and 4 to indicate the number of menu items in its File, View, and Window menu
			/// groups. The object server uses elements 1, 3, and 5 to indicate the number of menu items in its Edit, Object, and Help menu groups.
			/// </summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)] public uint[] width;
		}
	}
}