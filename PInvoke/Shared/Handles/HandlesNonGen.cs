using Microsoft.Win32.SafeHandles;
using System.Diagnostics;

namespace Vanara.PInvoke;

public partial struct HANDLE
{
	/// <summary>Performs an implicit conversion from <see cref="HANDLE"/> to <see cref="SafeHandle"/>.</summary>
	/// <param name="h">The pointer to a handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator HANDLE(SafeHandle h) => new(h.DangerousGetHandle());
}

public partial struct HBITMAP
{
	/// <summary>Performs an implicit conversion from <see cref="HGDIOBJ"/> to <see cref="HBITMAP"/>.</summary>
	/// <param name="h">The pointer to a GDI handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator HBITMAP(HGDIOBJ h) => new((IntPtr)h);
}

public partial struct HBRUSH
{
	/// <summary>Performs an implicit conversion from <see cref="HGDIOBJ"/> to <see cref="HBRUSH"/>.</summary>
	/// <param name="h">The pointer to a GDI handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator HBRUSH(HGDIOBJ h) => new((IntPtr)h);
}

public partial struct HCOLORSPACE
{
	/// <summary>Performs an implicit conversion from <see cref="HGDIOBJ"/> to <see cref="HCOLORSPACE"/>.</summary>
	/// <param name="h">The pointer to a GDI handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator HCOLORSPACE(HGDIOBJ h) => new((IntPtr)h);
}

public partial struct HCURSOR
{
	/// <summary>Performs an implicit conversion from <see cref="HGDIOBJ"/> to <see cref="HCURSOR"/>.</summary>
	/// <param name="h">The pointer to a GDI handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator HCURSOR(HGDIOBJ h) => new((IntPtr)h);
}

public partial struct HFILE
{
	/// <summary>Represents an invalid handle.</summary>
	public static readonly HFILE INVALID_HANDLE_VALUE = new IntPtr(-1);

	/// <summary>Performs an implicit conversion from <see cref="SafeFileHandle"/> to <see cref="HFILE"/>.</summary>
	/// <param name="h">The pointer to a handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator HFILE(SafeFileHandle h) => new(h?.DangerousGetHandle() ?? IntPtr.Zero);
}

public partial struct HFONT
{
	/// <summary>Performs an implicit conversion from <see cref="HGDIOBJ"/> to <see cref="HFONT"/>.</summary>
	/// <param name="h">The pointer to a GDI handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator HFONT(HGDIOBJ h) => new((IntPtr)h);
}

public partial struct HGDIOBJ
{
	/// <summary>Performs an implicit conversion from <see cref="HBITMAP"/> to <see cref="HGDIOBJ"/>.</summary>
	/// <param name="h">The pointer to a handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator HGDIOBJ(HBITMAP h) => new((IntPtr)h);

	/// <summary>Performs an implicit conversion from <see cref="HBRUSH"/> to <see cref="HGDIOBJ"/>.</summary>
	/// <param name="h">The pointer to a handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator HGDIOBJ(HBRUSH h) => new((IntPtr)h);

	/// <summary>Performs an implicit conversion from <see cref="HCOLORSPACE"/> to <see cref="HGDIOBJ"/>.</summary>
	/// <param name="h">The pointer to a handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator HGDIOBJ(HCOLORSPACE h) => new((IntPtr)h);

	/// <summary>Performs an implicit conversion from <see cref="HCURSOR"/> to <see cref="HGDIOBJ"/>.</summary>
	/// <param name="h">The pointer to a handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator HGDIOBJ(HCURSOR h) => new((IntPtr)h);

	/// <summary>Performs an implicit conversion from <see cref="HFONT"/> to <see cref="HGDIOBJ"/>.</summary>
	/// <param name="h">The pointer to a handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator HGDIOBJ(HFONT h) => new((IntPtr)h);

	/// <summary>Performs an implicit conversion from <see cref="HPALETTE"/> to <see cref="HGDIOBJ"/>.</summary>
	/// <param name="h">The pointer to a handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator HGDIOBJ(HPALETTE h) => new((IntPtr)h);

	/// <summary>Performs an implicit conversion from <see cref="HPEN"/> to <see cref="HGDIOBJ"/>.</summary>
	/// <param name="h">The pointer to a handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator HGDIOBJ(HPEN h) => new((IntPtr)h);

	/// <summary>Performs an implicit conversion from <see cref="HRGN"/> to <see cref="HGDIOBJ"/>.</summary>
	/// <param name="h">The pointer to a handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator HGDIOBJ(HRGN h) => new((IntPtr)h);
}

public partial struct HKEY
{
	/// <summary>
	/// Registry entries subordinate to this key define types (or classes) of documents and the properties associated with those types. Shell
	/// and COM applications use the information stored under this key.
	/// </summary>
	public static readonly HKEY HKEY_CLASSES_ROOT = new(new IntPtr(unchecked((int)0x80000000)));

	/// <summary>
	/// Contains information about the current hardware profile of the local computer system. The information under HKEY_CURRENT_CONFIG
	/// describes only the differences between the current hardware configuration and the standard configuration. Information about the
	/// standard hardware configuration is stored under the Software and System keys of HKEY_LOCAL_MACHINE.
	/// </summary>
	public static readonly HKEY HKEY_CURRENT_CONFIG = new(new IntPtr(unchecked((int)0x80000005)));

	/// <summary>
	/// Registry entries subordinate to this key define the preferences of the current user. These preferences include the settings of
	/// environment variables, data about program groups, colors, printers, network connections, and application preferences. This key makes
	/// it easier to establish the current user's settings; the key maps to the current user's branch in HKEY_USERS. In HKEY_CURRENT_USER,
	/// software vendors store the current user-specific preferences to be used within their applications. Microsoft, for example, creates
	/// the HKEY_CURRENT_USER\Software\Microsoft key for its applications to use, with each application creating its own subkey under the
	/// Microsoft key.
	/// </summary>
	public static readonly HKEY HKEY_CURRENT_USER = new(new IntPtr(unchecked((int)0x80000001)));

	/// <summary></summary>
	public static readonly HKEY HKEY_DYN_DATA = new(new IntPtr(unchecked((int)0x80000006)));

	/// <summary>
	/// Registry entries subordinate to this key define the physical state of the computer, including data about the bus type, system memory,
	/// and installed hardware and software. It contains subkeys that hold current configuration data, including Plug and Play information
	/// (the Enum branch, which includes a complete list of all hardware that has ever been on the system), network logon preferences,
	/// network security information, software-related information (such as server names and the location of the server), and other system information.
	/// </summary>
	public static readonly HKEY HKEY_LOCAL_MACHINE = new(new IntPtr(unchecked((int)0x80000002)));

	/// <summary>
	/// Registry entries subordinate to this key allow you to access performance data. The data is not actually stored in the registry; the
	/// registry functions cause the system to collect the data from its source.
	/// </summary>
	public static readonly HKEY HKEY_PERFORMANCE_DATA = new(new IntPtr(unchecked((int)0x80000004)));

	/// <summary>
	/// Registry entries subordinate to this key define the default user configuration for new users on the local computer and the user
	/// configuration for the current user.
	/// </summary>
	public static readonly HKEY HKEY_USERS = new(new IntPtr(unchecked((int)0x80000003)));

	/// <summary>Performs an implicit conversion from <see cref="HKEY"/> to <see cref="SafeRegistryHandle"/>.</summary>
	/// <param name="h">The pointer to a handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator HKEY(SafeRegistryHandle h) => new(h.DangerousGetHandle());
}

public partial struct HPALETTE
{
	/// <summary>Performs an implicit conversion from <see cref="HGDIOBJ"/> to <see cref="HPALETTE"/>.</summary>
	/// <param name="h">The pointer to a GDI handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator HPALETTE(HGDIOBJ h) => new((IntPtr)h);
}

public partial struct HPEN
{
	/// <summary>Performs an implicit conversion from <see cref="HGDIOBJ"/> to <see cref="HPEN"/>.</summary>
	/// <param name="h">The pointer to a GDI handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator HPEN(HGDIOBJ h) => new((IntPtr)h);
}

public partial struct HPROCESS
{
	/// <summary>Performs an implicit conversion from <see cref="HPROCESS"/> to <see cref="Process"/>.</summary>
	/// <param name="h">The pointer to a handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator HPROCESS(Process h) => new(h.Handle);
}

public partial struct HRGN
{
	/// <summary>Performs an implicit conversion from <see cref="HGDIOBJ"/> to <see cref="HRGN"/>.</summary>
	/// <param name="h">The pointer to a GDI handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator HRGN(HGDIOBJ h) => new((IntPtr)h);
}

public partial struct HWND
{
	/// <summary>
	/// Places the window at the bottom of the Z order. If the hWnd parameter identifies a topmost window, the window loses its topmost
	/// status and is placed at the bottom of all other windows.
	/// </summary>
	public static readonly HWND HWND_BOTTOM = new IntPtr(1);

	/// <summary>
	/// Used by <c>SendMessage</c> and <c>PostMessage</c> to send a message to all top-level windows in the system, including disabled or
	/// invisible unowned windows, overlapped windows, and pop-up windows; but the message is not sent to child windows.
	/// </summary>
	public static readonly HWND HWND_BROADCAST = new IntPtr(0xffff);

	/// <summary>Use as parent in CreateWindow or CreateWindowEx call to indicate a message-only window.</summary>
	public static readonly HWND HWND_MESSAGE = new IntPtr(-3);

	/// <summary>
	/// Places the window above all non-topmost windows (that is, behind all topmost windows). This flag has no effect if the window is
	/// already a non-topmost window.
	/// </summary>
	public static readonly HWND HWND_NOTOPMOST = new IntPtr(-2);

	/// <summary>Places the window at the top of the Z order.</summary>
	public static readonly HWND HWND_TOP = new IntPtr(0);

	/// <summary>Places the window above all non-topmost windows. The window maintains its topmost position even when it is deactivated.</summary>
	public static readonly HWND HWND_TOPMOST = new IntPtr(-1);
}