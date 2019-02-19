using Microsoft.Win32.SafeHandles;
using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	/// <summary>Signals that a structure or class holds a handle to a synchronization object.</summary>
	public interface IGraphicsObjectHandle : IHandle { }

	/// <summary>Signals that a structure or class holds a HANDLE.</summary>
	public interface IHandle
	{
		/// <summary>Returns the value of the handle field.</summary>
		/// <returns>An IntPtr representing the value of the handle field.</returns>
		IntPtr DangerousGetHandle();
	}

	/// <summary>Signals that a structure or class holds a handle to a synchronization object.</summary>
	public interface IKernelHandle : IHandle { }

	/// <summary>Signals that a structure or class holds a pointer to a security object.</summary>
	public interface ISecurityObject : IHandle { }

	/// <summary>Signals that a structure or class holds a handle to a synchronization object.</summary>
	public interface IShellHandle : IHandle { }

	/// <summary>Signals that a structure or class holds a handle to a synchronization object.</summary>
	public interface ISyncHandle : IKernelHandle { }

	/// <summary>Signals that a structure or class holds a handle to a synchronization object.</summary>
	public interface IUserHandle : IHandle { }

	/// <summary>Provides a handle to an accelerator table.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct HACCEL : IHandle
	{
		private IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HACCEL"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HACCEL(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HACCEL"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HACCEL NULL => new HACCEL(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="HACCEL"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HACCEL h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HACCEL"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HACCEL(IntPtr h) => new HACCEL(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HACCEL h1, HACCEL h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HACCEL h1, HACCEL h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object obj) => obj is HACCEL h ? handle == h.handle : false;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a generic handle.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct HANDLE : IHandle
	{
		private IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HANDLE"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HANDLE(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HANDLE"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HANDLE NULL => new HANDLE(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="HANDLE"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HANDLE h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HANDLE"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HANDLE(IntPtr h) => new HANDLE(h);

		/// <summary>Performs an implicit conversion from <see cref="SafeHANDLE"/> to <see cref="HANDLE"/>.</summary>
		/// <param name="h">The h.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HANDLE(SafeHANDLE h) => new HANDLE(h.DangerousGetHandle());

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HANDLE h1, HANDLE h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HANDLE h1, HANDLE h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object obj) => obj is HANDLE h ? handle == h.handle : false;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a handle to a bitmap.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct HBITMAP : IGraphicsObjectHandle
	{
		private IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HBITMAP"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HBITMAP(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HBITMAP"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HBITMAP NULL => new HBITMAP(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="HBITMAP"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HBITMAP h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HBITMAP"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HBITMAP(IntPtr h) => new HBITMAP(h);

		/// <summary>Performs an implicit conversion from <see cref="HGDIOBJ"/> to <see cref="HBITMAP"/>.</summary>
		/// <param name="h">The pointer to a GDI handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HBITMAP(HGDIOBJ h) => new HBITMAP((IntPtr)h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HBITMAP h1, HBITMAP h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HBITMAP h1, HBITMAP h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object obj) => obj is HBITMAP h ? handle == h.handle : false;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a handle to a drawing brush.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct HBRUSH : IGraphicsObjectHandle
	{
		private IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HBRUSH"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HBRUSH(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HBRUSH"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HBRUSH NULL => new HBRUSH(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="HBRUSH"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HBRUSH h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HBRUSH"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HBRUSH(IntPtr h) => new HBRUSH(h);

		/// <summary>Performs an implicit conversion from <see cref="HGDIOBJ"/> to <see cref="HBRUSH"/>.</summary>
		/// <param name="h">The pointer to a GDI handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HBRUSH(HGDIOBJ h) => new HBRUSH((IntPtr)h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HBRUSH h1, HBRUSH h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HBRUSH h1, HBRUSH h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object obj) => obj is HBRUSH h ? handle == h.handle : false;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a handle to a Windows cursor.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct HCURSOR : IGraphicsObjectHandle
	{
		private IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HCURSOR"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HCURSOR(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HCURSOR"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HCURSOR NULL => new HCURSOR(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="HCURSOR"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HCURSOR h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HCURSOR"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HCURSOR(IntPtr h) => new HCURSOR(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HCURSOR h1, HCURSOR h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HCURSOR h1, HCURSOR h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object obj) => obj is HCURSOR h ? handle == h.handle : false;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a handle to a graphic device context.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct HDC : IHandle
	{
		private IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HDC"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HDC(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HDC"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HDC NULL => new HDC(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="HDC"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HDC h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HDC"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HDC(IntPtr h) => new HDC(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HDC h1, HDC h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HDC h1, HDC h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object obj) => obj is HDC h ? handle == h.handle : false;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a handle to a desktop.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct HDESK : IKernelHandle
	{
		private IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HDESK"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HDESK(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HDESK"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HDESK NULL => new HDESK(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="HDESK"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HDESK h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HDESK"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HDESK(IntPtr h) => new HDESK(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HDESK h1, HDESK h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HDESK h1, HDESK h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object obj) => obj is HDESK h ? handle == h.handle : false;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a handle to a DPA.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct HDPA : IKernelHandle
	{
		private IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HDPA"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HDPA(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HDPA"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HDPA NULL => new HDPA(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="HDPA"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HDPA h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HDPA"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HDPA(IntPtr h) => new HDPA(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HDPA h1, HDPA h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HDPA h1, HDPA h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object obj) => obj is HDPA h ? handle == h.handle : false;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a handle to a Windows drop operation.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct HDROP : IShellHandle
	{
		private IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HDROP"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HDROP(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HDROP"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HDROP NULL => new HDROP(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="HDROP"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HDROP h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HDROP"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HDROP(IntPtr h) => new HDROP(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HDROP h1, HDROP h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HDROP h1, HDROP h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object obj) => obj is HDROP h ? handle == h.handle : false;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a handle to a DSA.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct HDSA : IKernelHandle
	{
		private IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HDSA"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HDSA(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HDSA"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HDSA NULL => new HDSA(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="HDSA"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HDSA h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HDSA"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HDSA(IntPtr h) => new HDSA(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HDSA h1, HDSA h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HDSA h1, HDSA h2) => h1.Equals(h2);

		/// <summary>Determines whether the specified <see cref="System.Object"/>, is equal to this instance.</summary>
		/// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
		/// <returns><c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
		public override bool Equals(object obj) => obj is HDSA h ? handle == h.handle : false;

		/// <summary>Returns a hash code for this instance.</summary>
		/// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a handle to a deferred windows position.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct HDWP : IUserHandle
	{
		private IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HDWP"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HDWP(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HDWP"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HDWP NULL => new HDWP(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="HDWP"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HDWP h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HDWP"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HDWP(IntPtr h) => new HDWP(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HDWP h1, HDWP h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HDWP h1, HDWP h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object obj) => obj is HDWP h ? handle == h.handle : false;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a handle to an enhanced metafile.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct HENHMETAFILE : IHandle
	{
		private IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HENHMETAFILE"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HENHMETAFILE(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HENHMETAFILE"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HENHMETAFILE NULL => new HENHMETAFILE(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="HENHMETAFILE"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HENHMETAFILE h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HENHMETAFILE"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HENHMETAFILE(IntPtr h) => new HENHMETAFILE(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HENHMETAFILE h1, HENHMETAFILE h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HENHMETAFILE h1, HENHMETAFILE h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object obj) => obj is HENHMETAFILE h ? handle == h.handle : false;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a handle to a file.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct HFILE : IKernelHandle
	{
		/// <summary>Represents an invalid handle.</summary>
		public static readonly IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);

		private IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HFILE"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HFILE(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HFILE"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HFILE NULL => new HFILE(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is an invalid handle (INVALID_HANDLE_VALUE).</summary>
		public bool IsInvalid => handle == INVALID_HANDLE_VALUE;

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="HFILE"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HFILE h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HFILE"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HFILE(IntPtr h) => new HFILE(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HFILE h1, HFILE h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HFILE h1, HFILE h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object obj) => obj is HFILE h ? handle == h.handle : false;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a handle to a font.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct HFONT : IGraphicsObjectHandle
	{
		private IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HFONT"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HFONT(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HFONT"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HFONT NULL => new HFONT(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="HFONT"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HFONT h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HFONT"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HFONT(IntPtr h) => new HFONT(h);

		/// <summary>Performs an implicit conversion from <see cref="HGDIOBJ"/> to <see cref="HFONT"/>.</summary>
		/// <param name="h">The pointer to a GDI handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HFONT(HGDIOBJ h) => new HFONT((IntPtr)h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HFONT h1, HFONT h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HFONT h1, HFONT h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object obj) => obj is HFONT h ? handle == h.handle : false;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a handle to a graphic device object.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct HGDIOBJ : IGraphicsObjectHandle
	{
		private IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HGDIOBJ"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HGDIOBJ(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HGDIOBJ"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HGDIOBJ NULL => new HGDIOBJ(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="HGDIOBJ"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HGDIOBJ h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HGDIOBJ"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HGDIOBJ(IntPtr h) => new HGDIOBJ(h);

		/// <summary>Performs an implicit conversion from <see cref="HBITMAP"/> to <see cref="HGDIOBJ"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HGDIOBJ(HBITMAP h) => new HGDIOBJ((IntPtr)h);

		/// <summary>Performs an implicit conversion from <see cref="HBRUSH"/> to <see cref="HGDIOBJ"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HGDIOBJ(HBRUSH h) => new HGDIOBJ((IntPtr)h);

		/// <summary>Performs an implicit conversion from <see cref="HFONT"/> to <see cref="HGDIOBJ"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HGDIOBJ(HFONT h) => new HGDIOBJ((IntPtr)h);

		/// <summary>Performs an implicit conversion from <see cref="HPALETTE"/> to <see cref="HGDIOBJ"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HGDIOBJ(HPALETTE h) => new HGDIOBJ((IntPtr)h);

		/// <summary>Performs an implicit conversion from <see cref="HPEN"/> to <see cref="HGDIOBJ"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HGDIOBJ(HPEN h) => new HGDIOBJ((IntPtr)h);

		/// <summary>Performs an implicit conversion from <see cref="HRGN"/> to <see cref="HGDIOBJ"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HGDIOBJ(HRGN h) => new HGDIOBJ((IntPtr)h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HGDIOBJ h1, HGDIOBJ h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HGDIOBJ h1, HGDIOBJ h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object obj) => obj is HGDIOBJ h ? handle == h.handle : false;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a handle to a Windows icon.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct HICON : IUserHandle
	{
		private IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HICON"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HICON(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HICON"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HICON NULL => new HICON(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="HICON"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HICON h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HICON"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HICON(IntPtr h) => new HICON(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HICON h1, HICON h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HICON h1, HICON h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object obj) => obj is HICON h ? handle == h.handle : false;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a handle to a Windows image list.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct HIMAGELIST : IShellHandle
	{
		private IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HIMAGELIST"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HIMAGELIST(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HIMAGELIST"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HIMAGELIST NULL => new HIMAGELIST(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="HIMAGELIST"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HIMAGELIST h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HIMAGELIST"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HIMAGELIST(IntPtr h) => new HIMAGELIST(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HIMAGELIST h1, HIMAGELIST h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HIMAGELIST h1, HIMAGELIST h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object obj) => obj is HIMAGELIST h ? handle == h.handle : false;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a handle to a module or library instance.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct HINSTANCE : IKernelHandle
	{
		private IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HINSTANCE"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HINSTANCE(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HINSTANCE"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HINSTANCE NULL => new HINSTANCE(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="HINSTANCE"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HINSTANCE h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HINSTANCE"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HINSTANCE(IntPtr h) => new HINSTANCE(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HINSTANCE h1, HINSTANCE h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HINSTANCE h1, HINSTANCE h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object obj) => obj is HINSTANCE h ? handle == h.handle : false;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a handle to a Windows registry key.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct HKEY : IKernelHandle
	{
		private IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HKEY"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HKEY(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HKEY"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HKEY NULL => new HKEY(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>
		/// Registry entries subordinate to this key define types (or classes) of documents and the properties associated with those types.
		/// Shell and COM applications use the information stored under this key.
		/// </summary>
		public static readonly HKEY HKEY_CLASSES_ROOT = new HKEY(new IntPtr(unchecked((int)0x80000000)));

		/// <summary>
		/// Contains information about the current hardware profile of the local computer system. The information under HKEY_CURRENT_CONFIG
		/// describes only the differences between the current hardware configuration and the standard configuration. Information about the
		/// standard hardware configuration is stored under the Software and System keys of HKEY_LOCAL_MACHINE.
		/// </summary>
		public static readonly HKEY HKEY_CURRENT_CONFIG = new HKEY(new IntPtr(unchecked((int)0x80000005)));

		/// <summary>
		/// Registry entries subordinate to this key define the preferences of the current user. These preferences include the settings of
		/// environment variables, data about program groups, colors, printers, network connections, and application preferences. This key
		/// makes it easier to establish the current user's settings; the key maps to the current user's branch in HKEY_USERS. In
		/// HKEY_CURRENT_USER, software vendors store the current user-specific preferences to be used within their applications. Microsoft,
		/// for example, creates the HKEY_CURRENT_USER\Software\Microsoft key for its applications to use, with each application creating its
		/// own subkey under the Microsoft key.
		/// </summary>
		public static readonly HKEY HKEY_CURRENT_USER = new HKEY(new IntPtr(unchecked((int)0x80000001)));

		/// <summary></summary>
		public static readonly HKEY HKEY_DYN_DATA = new HKEY(new IntPtr(unchecked((int)0x80000006)));

		/// <summary>
		/// Registry entries subordinate to this key define the physical state of the computer, including data about the bus type, system
		/// memory, and installed hardware and software. It contains subkeys that hold current configuration data, including Plug and Play
		/// information (the Enum branch, which includes a complete list of all hardware that has ever been on the system), network logon
		/// preferences, network security information, software-related information (such as server names and the location of the server),
		/// and other system information.
		/// </summary>
		public static readonly HKEY HKEY_LOCAL_MACHINE = new HKEY(new IntPtr(unchecked((int)0x80000002)));

		/// <summary>
		/// Registry entries subordinate to this key allow you to access performance data. The data is not actually stored in the registry;
		/// the registry functions cause the system to collect the data from its source.
		/// </summary>
		public static readonly HKEY HKEY_PERFORMANCE_DATA = new HKEY(new IntPtr(unchecked((int)0x80000004)));

		/// <summary>
		/// Registry entries subordinate to this key define the default user configuration for new users on the local computer and the user
		/// configuration for the current user.
		/// </summary>
		public static readonly HKEY HKEY_USERS = new HKEY(new IntPtr(unchecked((int)0x80000003)));

		/// <summary>Performs an explicit conversion from <see cref="HKEY"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HKEY h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HKEY"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HKEY(IntPtr h) => new HKEY(h);

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HKEY"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HKEY(SafeRegistryHandle h) => new HKEY(h.DangerousGetHandle());

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HKEY h1, HKEY h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HKEY h1, HKEY h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object obj) => obj is HKEY h ? handle == h.handle : false;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a handle to a menu.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct HMENU : IUserHandle
	{
		private IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HMENU"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HMENU(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HMENU"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HMENU NULL => new HMENU(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="HMENU"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HMENU h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HMENU"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HMENU(IntPtr h) => new HMENU(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HMENU h1, HMENU h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HMENU h1, HMENU h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object obj) => obj is HMENU h ? handle == h.handle : false;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a handle to a metafile.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct HMETAFILE : IHandle
	{
		private IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HMETAFILE"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HMETAFILE(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HMETAFILE"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HMETAFILE NULL => new HMETAFILE(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="HMETAFILE"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HMETAFILE h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HMETAFILE"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HMETAFILE(IntPtr h) => new HMETAFILE(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HMETAFILE h1, HMETAFILE h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HMETAFILE h1, HMETAFILE h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object obj) => obj is HMETAFILE h ? handle == h.handle : false;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a handle to a monitor.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct HMONITOR : IKernelHandle
	{
		private IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HMONITOR"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HMONITOR(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HMONITOR"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HMONITOR NULL => new HMONITOR(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="HMONITOR"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HMONITOR h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HMONITOR"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HMONITOR(IntPtr h) => new HMONITOR(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HMONITOR h1, HMONITOR h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HMONITOR h1, HMONITOR h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object obj) => obj is HMONITOR h ? handle == h.handle : false;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a handle to a palette.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct HPALETTE : IGraphicsObjectHandle
	{
		private IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HPALETTE"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HPALETTE(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HPALETTE"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HPALETTE NULL => new HPALETTE(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="HPALETTE"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HPALETTE h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HPALETTE"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HPALETTE(IntPtr h) => new HPALETTE(h);

		/// <summary>Performs an implicit conversion from <see cref="HGDIOBJ"/> to <see cref="HPALETTE"/>.</summary>
		/// <param name="h">The pointer to a GDI handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HPALETTE(HGDIOBJ h) => new HPALETTE((IntPtr)h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HPALETTE h1, HPALETTE h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HPALETTE h1, HPALETTE h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object obj) => obj is HPALETTE h ? handle == h.handle : false;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a handle to a drawing pen.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct HPEN : IGraphicsObjectHandle
	{
		private IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HPEN"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HPEN(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HPEN"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HPEN NULL => new HPEN(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="HPEN"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HPEN h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HPEN"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HPEN(IntPtr h) => new HPEN(h);

		/// <summary>Performs an implicit conversion from <see cref="HGDIOBJ"/> to <see cref="HPEN"/>.</summary>
		/// <param name="h">The pointer to a GDI handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HPEN(HGDIOBJ h) => new HPEN((IntPtr)h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HPEN h1, HPEN h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HPEN h1, HPEN h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object obj) => obj is HPEN h ? handle == h.handle : false;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a handle to a process.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct HPROCESS : ISyncHandle
	{
		private IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HPROCESS"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HPROCESS(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HPROCESS"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HPROCESS NULL => new HPROCESS(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="HPROCESS"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HPROCESS h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HPROCESS"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HPROCESS(IntPtr h) => new HPROCESS(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HPROCESS h1, HPROCESS h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HPROCESS h1, HPROCESS h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object obj) => obj is HPROCESS h ? handle == h.handle : false;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a handle to a Windows property sheet.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct HPROPSHEET : IUserHandle
	{
		private IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HPROPSHEET"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HPROPSHEET(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HPROPSHEET"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HPROPSHEET NULL => new HPROPSHEET(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="HPROPSHEET"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HPROPSHEET h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HPROPSHEET"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HPROPSHEET(IntPtr h) => new HPROPSHEET(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HPROPSHEET h1, HPROPSHEET h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HPROPSHEET h1, HPROPSHEET h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object obj) => obj is HPROPSHEET h ? handle == h.handle : false;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a handle to a property sheet page.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct HPROPSHEETPAGE : IUserHandle
	{
		private IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HPROPSHEETPAGE"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HPROPSHEETPAGE(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HPROPSHEETPAGE"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HPROPSHEETPAGE NULL => new HPROPSHEETPAGE(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="HPROPSHEETPAGE"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HPROPSHEETPAGE h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HPROPSHEETPAGE"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HPROPSHEETPAGE(IntPtr h) => new HPROPSHEETPAGE(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HPROPSHEETPAGE h1, HPROPSHEETPAGE h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HPROPSHEETPAGE h1, HPROPSHEETPAGE h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object obj) => obj is HPROPSHEETPAGE h ? handle == h.handle : false;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a handle to a drawing region.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct HRGN : IGraphicsObjectHandle
	{
		private IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HRGN"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HRGN(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HRGN"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HRGN NULL => new HRGN(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="HRGN"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HRGN h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HRGN"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HRGN(IntPtr h) => new HRGN(h);

		/// <summary>Performs an implicit conversion from <see cref="HGDIOBJ"/> to <see cref="HRGN"/>.</summary>
		/// <param name="h">The pointer to a GDI handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HRGN(HGDIOBJ h) => new HRGN((IntPtr)h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HRGN h1, HRGN h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HRGN h1, HRGN h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object obj) => obj is HRGN h ? handle == h.handle : false;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a handle to a Windows theme.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct HTHEME : IHandle
	{
		private IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HTHEME"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HTHEME(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HTHEME"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HTHEME NULL => new HTHEME(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="HTHEME"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HTHEME h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HTHEME"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HTHEME(IntPtr h) => new HTHEME(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HTHEME h1, HTHEME h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HTHEME h1, HTHEME h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object obj) => obj is HTHEME h ? handle == h.handle : false;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a handle to a thread.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct HTHREAD : ISyncHandle
	{
		private IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HTHREAD"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HTHREAD(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HTHREAD"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HTHREAD NULL => new HTHREAD(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="HTHREAD"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HTHREAD h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HTHREAD"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HTHREAD(IntPtr h) => new HTHREAD(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HTHREAD h1, HTHREAD h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HTHREAD h1, HTHREAD h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object obj) => obj is HTHREAD h ? handle == h.handle : false;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a handle to a Windows thumbnail.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct HTHUMBNAIL : IShellHandle
	{
		private IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HTHUMBNAIL"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HTHUMBNAIL(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HTHUMBNAIL"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HTHUMBNAIL NULL => new HTHUMBNAIL(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="HTHUMBNAIL"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HTHUMBNAIL h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HTHUMBNAIL"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HTHUMBNAIL(IntPtr h) => new HTHUMBNAIL(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HTHUMBNAIL h1, HTHUMBNAIL h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HTHUMBNAIL h1, HTHUMBNAIL h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object obj) => obj is HTHUMBNAIL h ? handle == h.handle : false;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a handle to an access token .</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct HTOKEN : IKernelHandle
	{
		private IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HTOKEN"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HTOKEN(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HTOKEN"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HTOKEN NULL => new HTOKEN(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="HTOKEN"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HTOKEN h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HTOKEN"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HTOKEN(IntPtr h) => new HTOKEN(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HTOKEN h1, HTOKEN h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HTOKEN h1, HTOKEN h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object obj) => obj is HTOKEN h ? handle == h.handle : false;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a handle to a windows station.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct HWINSTA : IKernelHandle
	{
		private IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HWINSTA"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HWINSTA(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HWINSTA"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HWINSTA NULL => new HWINSTA(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="HWINSTA"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HWINSTA h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HWINSTA"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HWINSTA(IntPtr h) => new HWINSTA(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HWINSTA h1, HWINSTA h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HWINSTA h1, HWINSTA h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object obj) => obj is HWINSTA h ? handle == h.handle : false;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a handle to a window or dialog.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct HWND : IUserHandle
	{
		private IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HWND"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HWND(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HWND"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HWND NULL => new HWND(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="HWND"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HWND h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HWND"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HWND(IntPtr h) => new HWND(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HWND h1, HWND h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HWND h1, HWND h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object obj) => obj is HWND h ? handle == h.handle : false;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a pointer to an access control entry.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct PACE : ISecurityObject
	{
		private IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="PACE"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public PACE(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="PACE"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static PACE NULL => new PACE(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="PACE"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(PACE h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="PACE"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator PACE(IntPtr h) => new PACE(h);

		/// <inheritdoc/>
		public override bool Equals(object obj) => obj is PACE h ? handle == h.handle : false;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a pointer to an access control list.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct PACL : ISecurityObject
	{
		private IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="PACL"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public PACL(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="PACL"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static PACL NULL => new PACL(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="PACL"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(PACL h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="PACL"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator PACL(IntPtr h) => new PACL(h);

		/// <inheritdoc/>
		public override bool Equals(object obj) => obj is PACL h ? handle == h.handle : false;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a pointer to a security descriptor.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct PSECURITY_DESCRIPTOR : ISecurityObject
	{
		private IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="PSECURITY_DESCRIPTOR"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public PSECURITY_DESCRIPTOR(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="PSECURITY_DESCRIPTOR"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static PSECURITY_DESCRIPTOR NULL => new PSECURITY_DESCRIPTOR(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="PSECURITY_DESCRIPTOR"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(PSECURITY_DESCRIPTOR h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="PSECURITY_DESCRIPTOR"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator PSECURITY_DESCRIPTOR(IntPtr h) => new PSECURITY_DESCRIPTOR(h);

		/// <inheritdoc/>
		public override bool Equals(object obj) => obj is PSECURITY_DESCRIPTOR h ? handle == h.handle : false;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a pointer to a security identifier.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct PSID : ISecurityObject
	{
		private IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="PSID"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public PSID(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="PSID"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static PSID NULL => new PSID(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="PSID"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(PSID h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="PSID"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator PSID(IntPtr h) => new PSID(h);

		/// <inheritdoc/>
		public override bool Equals(object obj) => obj is PSID h ? handle == h.handle : false;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Base class for all native handles.</summary>
	/// <seealso cref="Microsoft.Win32.SafeHandles.SafeHandleZeroOrMinusOneIsInvalid"/>
	/// <seealso cref="System.IEquatable{T}"/>
	/// <seealso cref="Vanara.PInvoke.IHandle"/>
	public abstract class SafeHANDLE : SafeHandleZeroOrMinusOneIsInvalid, IEquatable<SafeHANDLE>, IHandle
	{
		/// <summary>Initializes a new instance of the <see cref="SafeHANDLE"/> class.</summary>
		public SafeHANDLE() : base(true)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="SafeHANDLE"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		protected SafeHANDLE(IntPtr preexistingHandle, bool ownsHandle = true) : base(ownsHandle) => SetHandle(preexistingHandle);

		/// <summary>Gets a value indicating whether this instance is null.</summary>
		/// <value><c>true</c> if this instance is null; otherwise, <c>false</c>.</value>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(SafeHANDLE h1, SafeHANDLE h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(SafeHANDLE h1, SafeHANDLE h2) => h1?.Equals(h2) ?? h2 is null;

		/// <summary>Determines whether the specified <see cref="SafeHANDLE"/>, is equal to this instance.</summary>
		/// <param name="other">The <see cref="SafeHANDLE"/> to compare with this instance.</param>
		/// <returns><c>true</c> if the specified <see cref="SafeHANDLE"/> is equal to this instance; otherwise, <c>false</c>.</returns>
		public bool Equals(SafeHANDLE other)
		{
			if (other is null)
				return false;
			if (ReferenceEquals(this, other))
				return true;
			return handle == other.handle && IsClosed == other.IsClosed;
		}

		/// <summary>Determines whether the specified <see cref="System.Object"/>, is equal to this instance.</summary>
		/// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
		/// <returns><c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
		public override bool Equals(object obj) => obj is SafeHANDLE h ? Equals(h) : base.Equals(obj);

		/// <summary>Returns a hash code for this instance.</summary>
		/// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
		public override int GetHashCode() => base.GetHashCode();

		/// <summary>
		/// Internal method that actually releases the handle. This is called by <see cref="ReleaseHandle"/> for valid handles and afterwards
		/// zeros the handle.
		/// </summary>
		/// <returns><c>true</c> to indicate successful release of the handle; <c>false</c> otherwise.</returns>
		protected abstract bool InternalReleaseHandle();

		/// <inheritdoc/>
		protected override bool ReleaseHandle()
		{
			if (IsInvalid) return true;
			if (!InternalReleaseHandle()) return false;
			handle = IntPtr.Zero;
			return true;
		}
	}
}