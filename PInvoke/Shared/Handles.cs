using Microsoft.Win32.SafeHandles;
using System;

namespace Vanara.PInvoke
{
	public class HANDLE : SafeHandleZeroOrMinusOneIsInvalid, IEquatable<HANDLE>
	{
		public HANDLE() : base(true)
		{
		}

		protected HANDLE(IntPtr ptr, bool ownsHandle = true) : base(ownsHandle) => SetHandle(ptr);

		public bool IsNull => handle == IntPtr.Zero;

		public static bool operator !=(HANDLE h1, HANDLE h2) => !(h1 == h2);

		public static bool operator ==(HANDLE h1, HANDLE h2) => h1 is null || h2 is null ? false : h1.Equals(h2);

		public bool Equals(HANDLE other)
		{
			if (other is null)
				return false;
			if (ReferenceEquals(this, other))
				return true;
			return handle == other.handle && IsClosed == other.IsClosed;
		}

		public override bool Equals(object obj) => obj is HANDLE h ? Equals(h) : base.Equals(obj);

		public override int GetHashCode() => base.GetHashCode();

		/// <summary>
		/// Internal method that actually releases the handle. This is called by <see cref="ReleaseHandle"/> for valid handles and afterwards
		/// zeros the handle.
		/// </summary>
		/// <returns><c>true</c> to indicate successful release of the handle; <c>false</c> otherwise.</returns>
		protected virtual bool InternalReleaseHandle() => true;

		protected override bool ReleaseHandle()
		{
			if (!InternalReleaseHandle()) return false;
			handle = IntPtr.Zero;
			return true;
		}
	}

	/// <summary>Provides a handle to a Windows cursor.</summary>
	public class HCURSOR : HANDLE
	{
		/// <summary>Initializes a new instance of the <see cref="HCURSOR"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HCURSOR(IntPtr preexistingHandle) : base(preexistingHandle, true) { }

		/// <summary>Initializes a new instance of the <see cref="HCURSOR"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle"><see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).</param>
		protected HCURSOR(IntPtr preexistingHandle, bool ownsHandle) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Returns an invalid handle by instantiating a <see cref="HCURSOR"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HCURSOR NULL => new HCURSOR(IntPtr.Zero);
	}

	/// <summary>Provides a handle to a graphic device context.</summary>
	public class HDC : HANDLE
	{
		/// <summary>Initializes a new instance of the <see cref="HDC"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HDC(IntPtr preexistingHandle) : base(preexistingHandle, true) { }

		/// <summary>Initializes a new instance of the <see cref="HDC"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		protected HDC(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Returns an invalid handle by instantiating a <see cref="HDC"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HDC NULL => new HDC(IntPtr.Zero);
	}

	/// <summary>Provides a handle to a desktop.</summary>
	public class HDESK : HANDLE
	{
		/// <summary>Initializes a new instance of the <see cref="HDESK"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HDESK(IntPtr preexistingHandle) : base(preexistingHandle, true) { }

		/// <summary>Initializes a new instance of the <see cref="HDESK"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		protected HDESK(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Returns an invalid handle by instantiating a <see cref="HDESK"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HDESK NULL => new HDESK(IntPtr.Zero);
	}

	/// <summary>Provides a handle to a DPA.</summary>
	public class HDPA : HANDLE
	{
		/// <summary>Initializes a new instance of the <see cref="HDPA"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HDPA(IntPtr preexistingHandle) : base(preexistingHandle, true) { }

		/// <summary>Initializes a new instance of the <see cref="HDPA"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		protected HDPA(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Returns an invalid handle by instantiating a <see cref="HDPA"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HDPA NULL => new HDPA(IntPtr.Zero);
	}

	/// <summary>Provides a handle to a DSA.</summary>
	public class HDSA : HANDLE
	{
		/// <summary>Initializes a new instance of the <see cref="HDSA"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HDSA(IntPtr preexistingHandle) : base(preexistingHandle, true) { }

		/// <summary>Initializes a new instance of the <see cref="HDSA"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		protected HDSA(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Returns an invalid handle by instantiating a <see cref="HDSA"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HDSA NULL => new HDSA(IntPtr.Zero);
	}

	/// <summary>Provides a handle to a deferred windows position.</summary>
	public class HDWP : HANDLE
	{
		/// <summary>Initializes a new instance of the <see cref="HDWP"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HDWP(IntPtr preexistingHandle) : base(preexistingHandle, true) { }

		/// <summary>Initializes a new instance of the <see cref="HDWP"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		protected HDWP(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Returns an invalid handle by instantiating a <see cref="HDWP"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HDWP NULL => new HDWP(IntPtr.Zero);
	}


	/// <summary>Provides a handle to a Windows drop operation.</summary>
	public class HDROP : HANDLE
	{
		/// <summary>Initializes a new instance of the <see cref="HDROP"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HDROP(IntPtr preexistingHandle) : base(preexistingHandle, true) { }

		/// <summary>Returns an invalid handle by instantiating a <see cref="HDROP"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HDROP NULL => new HDROP(IntPtr.Zero);
	}

	/// <summary>Provides a handle to a file.</summary>
	public class HFILE : HANDLE
	{
		/// <summary>Initializes a new instance of the <see cref="HFILE"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HFILE(IntPtr preexistingHandle) : base(preexistingHandle, true) { }

		/// <summary>Initializes a new instance of the <see cref="HFILE"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		protected HFILE(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Returns an invalid handle by instantiating a <see cref="HFILE"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HFILE NULL => new HFILE(IntPtr.Zero);
	}

	/// <summary>Provides a handle to a graphic device object.</summary>
	public class HGDIOBJ : HANDLE
	{
		/// <summary>Initializes a new instance of the <see cref="HGDIOBJ"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HGDIOBJ(IntPtr preexistingHandle) : base(preexistingHandle, true) { }

		/// <summary>Initializes a new instance of the <see cref="HGDIOBJ"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		protected HGDIOBJ(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Returns an invalid handle by instantiating a <see cref="HGDIOBJ"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HGDIOBJ NULL => new HGDIOBJ(IntPtr.Zero);

		/// <summary>Performs an explicit conversion from <see cref="IntPtr"/> to <see cref="HGDIOBJ"/>.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator HGDIOBJ(IntPtr preexistingHandle) => new HGDIOBJ(preexistingHandle);
	}

	/// <summary>Provides a handle to a Windows icon.</summary>
	public class HICON : HANDLE
	{
		/// <summary>Initializes a new instance of the <see cref="HICON"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HICON(IntPtr preexistingHandle) : base(preexistingHandle, true) { }

		/// <summary>Initializes a new instance of the <see cref="HICON"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		protected HICON(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Returns an invalid handle by instantiating a <see cref="HICON"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HICON NULL => new HICON(IntPtr.Zero);
	}

	/// <summary>Provides a handle to a Windows image list.</summary>
	public class HIMAGELIST : HANDLE
	{
		/// <summary>Initializes a new instance of the <see cref="HIMAGELIST"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HIMAGELIST(IntPtr preexistingHandle) : base(preexistingHandle, true) { }

		/// <summary>Initializes a new instance of the <see cref="HIMAGELIST"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		protected HIMAGELIST(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Returns an invalid handle by instantiating a <see cref="HIMAGELIST"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HIMAGELIST NULL => new HIMAGELIST(IntPtr.Zero);

		public static implicit operator IntPtr(HIMAGELIST hwnd) => hwnd.DangerousGetHandle();

		public static implicit operator HIMAGELIST(IntPtr ptr) => new HIMAGELIST(ptr);
	}

	/// <summary>Provides a handle to a library or module instance.</summary>
	public class HINSTANCE : HANDLE
	{
		/// <summary>Initializes a new instance of the <see cref="HINSTANCE"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HINSTANCE(IntPtr preexistingHandle) : base(preexistingHandle, true) { }

		/// <summary>Initializes a new instance of the <see cref="HINSTANCE"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		protected HINSTANCE(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Returns an invalid handle by instantiating a <see cref="HINSTANCE"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HINSTANCE NULL => new HINSTANCE(IntPtr.Zero);
	}

	/// <summary>Provides a handle to a Windows registry key.</summary>
	public class HKEY : HANDLE
	{
		/// <summary>Initializes a new instance of the <see cref="HKEY"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HKEY(IntPtr preexistingHandle) : base(preexistingHandle, true) { }

		/// <summary>Returns an invalid handle by instantiating a <see cref="HKEY"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HKEY NULL => new HKEY(IntPtr.Zero);
	}

	/// <summary>Provides a handle to a menu.</summary>
	public class HMENU : HANDLE
	{
		/// <summary>Initializes a new instance of the <see cref="HMENU"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HMENU(IntPtr preexistingHandle) : base(preexistingHandle, true) { }

		/// <summary>Initializes a new instance of the <see cref="HMENU"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		protected HMENU(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Returns an invalid handle by instantiating a <see cref="HMENU"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HMENU NULL => new HMENU(IntPtr.Zero);
	}

	/// <summary>Provides a handle to a monitor.</summary>
	public class HMONITOR : HANDLE
	{
		/// <summary>Initializes a new instance of the <see cref="HMONITOR"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HMONITOR(IntPtr preexistingHandle) : base(preexistingHandle, true) { }

		/// <summary>Initializes a new instance of the <see cref="HMONITOR"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		protected HMONITOR(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Returns an invalid handle by instantiating a <see cref="HMONITOR"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HMONITOR NULL => new HMONITOR(IntPtr.Zero);
	}

	/// <summary>Provides a handle to a Windows property sheet.</summary>
	public class HPROPSHEET : HANDLE
	{
		/// <summary>Initializes a new instance of the <see cref="HPROPSHEET"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HPROPSHEET(IntPtr preexistingHandle) : base(preexistingHandle, true) { }

		/// <summary>Returns an invalid handle by instantiating a <see cref="HPROPSHEET"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HPROPSHEET NULL => new HPROPSHEET(IntPtr.Zero);
	}

	/// <summary>Provides a handle to a property sheet page.</summary>
	public class HPROPSHEETPAGE : HANDLE
	{
		/// <summary>Initializes a new instance of the <see cref="HPROPSHEETPAGE"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HPROPSHEETPAGE(IntPtr preexistingHandle) : base(preexistingHandle, true) { }

		/// <summary>Initializes a new instance of the <see cref="HPROPSHEETPAGE"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		protected HPROPSHEETPAGE(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Returns an invalid handle by instantiating a <see cref="HPROPSHEETPAGE"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HPROPSHEETPAGE NULL => new HPROPSHEETPAGE(IntPtr.Zero);
	}

	/// <summary>Provides a handle to a Windows theme.</summary>
	public class HTHEME : HANDLE
	{
		/// <summary>Initializes a new instance of the <see cref="HTHEME"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HTHEME(IntPtr preexistingHandle) : base(preexistingHandle, true) { }

		/// <summary>Initializes a new instance of the <see cref="HTHEME"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		protected HTHEME(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Returns an invalid handle by instantiating a <see cref="HTHEME"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HTHEME NULL => new HTHEME(IntPtr.Zero);
	}

	/// <summary>Provides a handle to a Windows .</summary>
	public class HTHUMBNAIL : HANDLE
	{
		/// <summary>Initializes a new instance of the <see cref="HTHUMBNAIL"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HTHUMBNAIL(IntPtr preexistingHandle) : base(preexistingHandle, true) { }
		/// <summary>Returns an invalid handle by instantiating a <see cref="HTHUMBNAIL"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HTHUMBNAIL NULL => new HTHUMBNAIL(IntPtr.Zero);
	}

	/// <summary>Provides a handle to an access token .</summary>
	public class HTOKEN : HANDLE
	{
		/// <summary>Initializes a new instance of the <see cref="HTOKEN"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HTOKEN(IntPtr preexistingHandle) : base(preexistingHandle, true) { }

		/// <summary>Initializes a new instance of the <see cref="HTOKEN"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		protected HTOKEN(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Returns an invalid handle by instantiating a <see cref="HTOKEN"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HTOKEN NULL => new HTOKEN(IntPtr.Zero);
	}

	/// <summary>Provides a handle to a window or dialog.</summary>
	public class HWND : HANDLE
	{
		/// <summary>Initializes a new instance of the <see cref="HWND"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HWND(IntPtr preexistingHandle) : base(preexistingHandle, true) { }

		/// <summary>Initializes a new instance of the <see cref="HWND"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		protected HWND(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Returns an invalid handle by instantiating a <see cref="HWND"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HWND NULL => new HWND(IntPtr.Zero);

		public static implicit operator IntPtr(HWND hwnd) => hwnd.DangerousGetHandle();

		public static implicit operator HWND(IntPtr ptr) => new HWND(ptr);
	}

	/// <summary>Provides a handle to a windows station.</summary>
	public class HWINSTA : HANDLE
	{
		/// <summary>Initializes a new instance of the <see cref="HWINSTA"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HWINSTA(IntPtr preexistingHandle) : base(preexistingHandle, true) { }

		/// <summary>Initializes a new instance of the <see cref="HWINSTA"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		protected HWINSTA(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Returns an invalid handle by instantiating a <see cref="HWINSTA"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HWINSTA NULL => new HWINSTA(IntPtr.Zero);
	}

	/*
HCOLORSPACE
HCONV
HCONVLIST
HDDEDATA
HENHMETAFILE
HGLOBAL
HHOOK
HKL
HLOCAL
HMETAFILE
HPALETTE
HRSRC
HSZ

	*/
}